using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForms
{
    public partial class Voucher : System.Web.UI.Page
    {
        DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
        DataAccess.CustomHousingAgent.JobInfo CHAobj = new DataAccess.CustomHousingAgent.JobInfo();
        DataAccess.Corporate Corpobj = new DataAccess.Corporate();
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
        DataAccess.UserPermission UserObj = new DataAccess.UserPermission();
        DataAccess.FAVoucher FAobj = new DataAccess.FAVoucher();
        DataAccess.NvoccExports.BLDetails NEBLObj = new DataAccess.NvoccExports.BLDetails();
        DataAccess.NVOCC_Imports.BLDetails NIBLObj = new DataAccess.NVOCC_Imports.BLDetails();
        DataAccess.NvoccExports.JobInfo JobObj = new DataAccess.NvoccExports.JobInfo();
        DataAccess.NVOCC_Imports.JobInfo NIJobObj = new DataAccess.NVOCC_Imports.JobInfo();

        public static string strTranType;
        int branchid;
        int i;
        bool HORM;
        bool flag = false;
        int j;
        int k;
        string vessel;
        string voyage;
        string volume;
        DataTable DtSHead = new DataTable();
        DataTable dt = new DataTable();
        string blno;
        DataTable DtConDetails = new DataTable();
        DataTable DtCon = new DataTable();
        DataTable DtInfo = new DataTable();
        string wt;
        DataTable dtfa = new DataTable();
        DataTable dtvid = new DataTable();
        int voutypeid;
        System.DateTime voudate;
        string vname = "";
        string gblvname = "";
        string type1;
        string type2;
        double totcramt;
        double totdramt;
        double retention;
        System.DateTime flightdate;
        DataAccess.Accounts.OSDNCN OSDCNObj = new DataAccess.Accounts.OSDNCN();
        int custid;
        DataTable dtdebit = new DataTable();
        DataTable dtcredit = new DataTable();

        string frmtype;
        public int PBranch_ID;
        int LogIn_BrID;
        public bool LView_Flag = false;
        string osvtype;
        string temporary, FADbName;
        int logcorid;
        int Emp_Id, Div_Id, Vou_Year, BranchID;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            Emp_Id = Convert.ToInt32(Session["LoginEmpId"].ToString());
            Div_Id = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            Vou_Year = Convert.ToInt32(Session["LogYear"]);
            FADbName = Session["FADbname"].ToString();
            BranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (IsPostBack != true)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                HORM = false;
                hf_LogBr_ID.Value = Session["LoginBranchid"].ToString();
                grd.DataSource = new DataTable();
                grd.DataBind();

                if (Request.QueryString.ToString().Contains("Vno"))
                {
                    if (Convert.ToInt32(Request.QueryString["PBranch_ID"].ToString()) == 0)
                    {
                        hf_LogBr_ID.Value = Session["LoginBranchid"].ToString();
                        hf_PBranchid.Value = "0";


                    }
                    else
                    {
                        hf_LogBr_ID.Value = Request.QueryString["PBranch_ID"].ToString();
                        hf_PBranchid.Value = Request.QueryString["PBranch_ID"].ToString();
                    }

                    if (Request.QueryString.ToString().Contains("flag"))
                    {
                        hf_flag.Value = (Request.QueryString["flag"].ToString());
                        hf_vid.Value = (Request.QueryString["vid"].ToString());
                        hidfdate.Value = (Request.QueryString["fdate"].ToString());
                        hidtdate.Value = (Request.QueryString["tdate"].ToString());
                        hidvoutype.Value = (Request.QueryString["type"].ToString());
                    }

                    hf_OSV_Type.Value = Request.QueryString["OsvType"].ToString();
                    txtVoucherno.Text = Request.QueryString["Vno"].ToString();

                    //-------------- For DayaBook ---------------

                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lblheader.Text = Request.QueryString["FormName"].ToString();
                        lblHead.InnerText = lblheader.Text;

                        if (lblheader.Text == "Invoices")
                        {
                            lblheader.Text = "Invoice";
                            vname = "Invoices";
                        }
                        else
                        {
                            vname = lblheader.Text;
                        }


                        Session["vname"] = vname;
                        BranchID = Convert.ToInt32(Request.QueryString["PBranch_ID"].ToString());
                        if (BranchID == 0)
                        {
                            BranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                        }
                        txtVoucherno_TextChanged(sender, e);
                    }
                }

                //-------------- For LedgerView ---------------

                if (Request.QueryString.ToString().Contains("QueryVoucherName"))
                {
                    txtVoucherno.Text = Request.QueryString["QueryVoucherNo"].ToString();
                    lblheader.Text = Request.QueryString["QueryVoucherName"].ToString();

                    if (lblheader.Text == "Invoices")
                    {
                        lblheader.Text = "Invoice";
                        vname = "Invoices";
                    }
                    else if (lblheader.Text == "Overseas Debit Note")
                    {
                        lblheader.Text = "OS DN";
                        frmtype = "OSSI";
                        vname = "OSSI";
                    }
                    else if (lblheader.Text == "Overseas Credit Note")
                    {
                        lblheader.Text = "OS CN";
                        frmtype = "OSPI";
                        vname = "OSPI";
                    }
                    else if (lblheader.Text == "Bill of Supply")
                    {
                        lblheader.Text = "Bill of Supply";
                        vname = "BOS";
                    }
                    else if (lblheader.Text == "Credit Note - Operations")
                    {
                        vname = "Credit Note - Operations";
                    }
                    else if (lblheader.Text == "Debit Note")
                    {
                        vname = "Debit Note - Others";
                    }
                    else if (lblheader.Text == "Credit Note")
                    {
                        vname = "Credit Note - Others";
                    }
                    else if (lblheader.Text == "OSDNCN JV")
                    {
                        vname = "OSDNCNJV";
                    }
                    else
                    {
                        vname = lblheader.Text;
                    }

                    Session["vname"] = vname;
                    txtVoucherno_TextChanged(sender, e);
                }
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lblheader.Text = Request.QueryString["FormName"].ToString();
            }

            if (Request.QueryString.ToString().Contains("VoucherText"))
            {
                if (Request.QueryString["VoucherText"].ToString() != "")
                {
                    lblheader.Text = Request.QueryString["VoucherText"].ToString();
                }
            }

            if (lblheader.Text == "Overseas Debit Note")
            {
                lblheader.Text = "OS DN";
                frmtype = "OSSI";
                vname = "OSSI";
            }
            else if (lblheader.Text == "Overseas Credit Note")
            {
                lblheader.Text = "OS CN";
                frmtype = "OSPI";
                vname = "OSPI";
            }
            else if (lblheader.Text == "Invoice")
            {
                vname = "Invoices";
            }
            else if (lblheader.Text == "Credit Note - Operations")
            {
                vname = "Credit Note - Operations";
            }
            else if (lblheader.Text == "Debit Note")
            {
                vname = "Debit Note - Others";
            }
            else if (lblheader.Text == "Credit Note")
            {
                vname = "Credit Note - Others";
            }
            else if (lblheader.Text == "OSDNCN JV")
            {
                vname = "OSDNCNJV";
            }
            else
            {
                vname = lblheader.Text;
            }

            txtVoucherno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
            Session["vname"] = vname;

            lblHead.InnerText = lblheader.Text;
        }

        public void getosdncndetails()
        {
            voutypeid = FAobj.Selvoutypeid(Session["vname"].ToString(), FADbName);
            int logcorid = 0;
            logcorid = hrempobj.GetBranchId(Div_Id, "CORPORATE");
            osvtype = hf_OSV_Type.Value.ToString().Trim();

            if (osvtype != "" && osvtype != null)
            {
                dtfa = FAobj.SelFAVoucher4OSVou(Convert.ToInt32(txtVoucherno.Text), logcorid, Div_Id, voutypeid, Vou_Year, FADbName, BranchID, osvtype);
            }
            else if (PBranch_ID == 0 || LView_Flag == true)
            {
                dtfa = FAobj.SelFAVoucher(Convert.ToInt32(txtVoucherno.Text), BranchID, Div_Id, voutypeid, Vou_Year, FADbName);
            }
            else
            {
                dtfa = FAobj.SelFAVoucher4BP(Convert.ToInt32(txtVoucherno.Text), logcorid, Div_Id, voutypeid, Vou_Year, FADbName, BranchID);
            }

            if (dtfa.Rows.Count > 0)
            {
                Hid_trantype.Value = dtfa.Rows[0]["trantype"].ToString();
                strTranType = Hid_trantype.Value;

                txtjobno.Text = dtfa.Rows[0]["jobno"].ToString();

                if (dtfa.Rows.Count > 0)
                {
                    if (Session["vname"].ToString() == "OSSI")
                    {
                        DataRow dr_temp = dtfa.NewRow();
                        dr_temp["ledgername"] = "Total";
                        //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'");
                        //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'");
                        dtfa.Rows.Add(dr_temp);
                        grd.DataSource = dtfa;
                        grd.DataBind();
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                        }
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                        }

                        //grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                        //grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    }
                    else if (Session["vname"].ToString() == "OSPI")
                    {
                        DataRow dr_temp = dtfa.NewRow();
                        dr_temp["ledgername"] = "Total";
                        //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'");
                        //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'");
                        dtfa.Rows.Add(dr_temp);
                        grd.DataSource = dtfa;
                        grd.DataBind();
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                        }
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                        }
                        //grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                        // grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    }
                    else if (Session["vname"].ToString() == "OSDNCNJV" || Session["vname"].ToString() == "OSDNCN JV")
                    {
                        DataRow dr_temp = dtfa.NewRow();
                        dr_temp["ledgername"] = "Total";
                        //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'");
                        //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'");
                        dtfa.Rows.Add(dr_temp);
                        grd.DataSource = dtfa;
                        grd.DataBind();
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                        }
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                        }

                        //grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                        // grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Please Enter the valid Voucher #');", true);
                Clear();
                DataTable dtEmpty = new DataTable();
                grd.DataSource = dtEmpty;
                grd.DataBind();
                return;
            }

            DataSet ds = new DataSet();
            ds = OSDNCN.RptOSDNCNFromJobNo(strTranType, Convert.ToInt32(txtjobno.Text), BranchID);
            if (ds.Tables[1].Rows.Count > 0)
            {

            }
            else
            {
                if (ds.Tables[2].Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Voucher Not Raised in this Job');", true);
                    return;
                }
            }

            dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                txtblno.Text = Convert.ToString(dt.Rows[0][7].ToString());

                if (strTranType == "FE" || strTranType == "FI" || strTranType == "FC")
                {
                    txtvessel.Text = dt.Rows[0][5].ToString() + "  /  " + dt.Rows[0][6].ToString();
                    HORM = true;
                    object Obj_boolvalue = HORM;
                    int Bool_Value = Convert.ToInt32(Obj_boolvalue);
                    hid_BoolValue.Value = Bool_Value.ToString();
                    getFEI();
                }
                else
                {
                    txtvessel.Text = dt.Rows[0][5].ToString() + "  /  " + dt.Rows[0][6].ToString();
                    HORM = true;
                    object Obj_boolvalue = HORM;
                    int Bool_Value = Convert.ToInt32(Obj_boolvalue);
                    hid_BoolValue.Value = Bool_Value.ToString();
                    getAEI();
                }
            }

            DataTable dtd = new DataTable();
            if (lblheader.Text == "OSDNCNJV" || lblheader.Text == "OSDNCN JV")
            {
                if (Convert.ToInt32(Session["LoginBranchid"]) == logcorid)
                {
                    dtd = FAobj.SelFAVouHead4All(Convert.ToInt32(txtVoucherno.Text), Vou_Year, voutypeid, BranchID, logcorid, FADbName);
                }
                else
                {
                    dtd = FAobj.SelFAVouHead4All(Convert.ToInt32(txtVoucherno.Text), Vou_Year, voutypeid, BranchID, 0, FADbName);
                }

                if (dtd.Rows.Count > 0)
                {
                    //voudate = Convert.ToDateTime(Utility.fn_ConvertDate((dtd.Rows[0]["voudate"]).ToString()));
                    voudate = Convert.ToDateTime(((dtd.Rows[0]["voudate"]).ToString()));
                    txtremarks.Text = Convert.ToString(dtd.Rows[0]["narration"]);
                    txtvoudate.Text = dtd.Rows[0]["fdate"].ToString() + " / " + voudate.DayOfWeek;
                }
            }
            else
            {
                dtd = OSDNCN.GetOSDCNDtls(Convert.ToInt32(txtjobno.Text), strTranType, Session["vname"].ToString(), BranchID);
                if (dtd.Rows.Count > 0)
                {
                    voudate = Convert.ToDateTime((dtd.Rows[0][1]).ToString());
                    txtremarks.Text = Convert.ToString(dtd.Rows[0][5].ToString());
                    txtvoudate.Text = dtd.Rows[0]["fdate"].ToString() + " / " + voudate.DayOfWeek;

                    if (!string.IsNullOrEmpty(dtd.Rows[0]["preparedbyname"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_prepare.Text = dtd.Rows[0]["preparedbyname"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dtd.Rows[0]["approvedbyname"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_Approve.Text = dtd.Rows[0]["approvedbyname"].ToString();
                    }
                }
            }
        }


        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (lblheader.Text == "OS DN")
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[1].Text = "";
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;

                    }
                    else if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                        e.Row.Cells[2].Text = "";
                    }
                }
                else if (lblheader.Text == "OS CN")
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[1].Text = "";
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                    }
                    else if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                    }
                }
                else if (lblheader.Text == "OSDNCNJV" || lblheader.Text == "OSDNCN JV")
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[1].Text = "";
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                    }
                    else if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                    }
                }
                else
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[1].Text = "";
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                    }
                    else if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                    }
                }
            }
        }

        protected void txtVoucherno_TextChanged(object sender, EventArgs e)
        {
            // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(24071, "BOS", 1, 2020, Session["FADbname"].ToString(), Logobj.GetDate());


            txtVoucherno.Focus();
            strTranType = Session["StrTranType"].ToString();
            btnback.ToolTip = "Cancel";
            btnback1.Attributes["class"] = "btn ico-cancel";
            if (txtVoucherno.Text.ToString() != "")
            {
                if (lblheader.Text == "OS DN" || lblheader.Text == "OS CN" || lblheader.Text == "OSPI" || lblheader.Text == "OSSI" || lblheader.Text == "OSDNCN JV" || lblheader.Text == "OSDNCNJV")
                {
                    getosdncndetails();
                }
                else
                {
                    getdetails();
                }

                //HORM = false;
                modulename();
            }
        }

        public void getFEI()
        {
            if (strTranType == "FE")
            {
                if (lblheader.Text != "InvoiceWoJ")
                {
                    if (HORM == true)
                    {
                        lstvol.Items.Clear();
                        DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Text), txtjobno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));

                        if (DtConDetails.Rows.Count > 0)
                        {
                            for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                            }
                        }
                        lstcon.Items.Clear();
                        DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Text), txtjobno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                        if (DtCon.Rows.Count != 0)
                        {
                            for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
                            }
                        }
                        DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                        if (DtCon.Rows.Count != 0)
                        {
                            vessel = DtCon.Rows[0][3].ToString();
                            voyage = DtCon.Rows[0]["voyage"].ToString();
                            txtvessel.Text = vessel + " / " + voyage;
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        lstvol.Items.Clear();
                        DtInfo = FEBLobj.GetBLDetails(txtblno.Text, Convert.ToInt32(hf_LogBr_ID.Value.ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (DtInfo.Rows.Count != 0)
                        {
                            txtshipper.Text = DtInfo.Rows[0][4].ToString();
                            txtconsignee.Text = DtInfo.Rows[0][6].ToString();
                            txtnotify.Text = DtInfo.Rows[0][8].ToString();
                            DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(hf_LogBr_ID.Value.ToString()), Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                            if (DtCon.Rows.Count != 0)
                            {
                                vessel = DtCon.Rows[0][3].ToString();
                                voyage = DtCon.Rows[0][7].ToString();
                                txtvessel.Text = vessel + " / " + voyage;

                            }
                            else
                            {
                                //txtclear()
                            }
                            DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                            j = DtConDetails.Rows.Count;
                            if (j > 0)
                            {
                                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                                }
                                volume = DtConDetails.Rows[0][1].ToString();
                                lstvol.Items.Add(volume + "cbm");
                                wt = DtConDetails.Rows[0][2].ToString();
                                lstvol.Items.Add(wt + " Kgs");
                            }
                            // lstcon.Items.Clear();
                            DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Text), txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                            if (DtInfo.Rows.Count != 0)
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
                    dt = FEBLWoJobj.GetBLDetWOJob(txtblno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                    if (dt.Rows.Count != 0)
                    {
                        txtjobno.Text = "0";
                        txtshipper.Text = dt.Rows[0][3].ToString();
                        txtconsignee.Text = dt.Rows[0][6].ToString();
                        txtnotify.Text = dt.Rows[0][9].ToString();


                        //**** 33 WAS NOT FOUND IN DATATABLE*******//
                        txtvessel.Text = dt.Rows[0][33].ToString();

                    }
                }
            }
            else
            {
                if (HORM == true)
                {
                    lstvol.Items.Clear();
                    DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                    if (DtInfo.Rows.Count != 0)
                    {
                        txtjobno.Text = DtInfo.Rows[0][0].ToString();
                        vessel = DtInfo.Rows[0][3].ToString();
                        voyage = DtInfo.Rows[0][2].ToString();
                        txtvessel.Text = vessel + " / " + voyage;

                        DtCon = INVOICEobj.GetFIMblNContainers(txtjobno.Text, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                        if (DtCon.Rows.Count != 0)
                        {
                            for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());
                            }
                        }
                        DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Text), txtjobno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                        j = DtConDetails.Rows.Count;
                        if (j > 0)
                        {
                            for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                            }
                        }
                    }
                    else
                    {
                        // txtclear()
                    }
                }
                else
                {
                    lstvol.Items.Clear();
                    if (strTranType == "FC")
                    {
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text, "FI", BranchID);
                    }
                    else
                    {
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text, strTranType, BranchID);
                        //DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                    }
                    if (DtInfo.Rows.Count != 0)
                    {
                        txtjobno.Text = DtInfo.Rows[0][0].ToString();
                        txtshipper.Text = DtInfo.Rows[0][4].ToString();
                        txtconsignee.Text = DtInfo.Rows[0][5].ToString();
                        txtnotify.Text = DtInfo.Rows[0][6].ToString();
                        vessel = DtInfo.Rows[0][3].ToString();
                        voyage = DtInfo.Rows[0][2].ToString();
                        txtvessel.Text = vessel + " / " + voyage;
                    }
                    else
                    {
                        // txtclear()
                    }
                }
                DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                j = DtConDetails.Rows.Count;

                if (j > 0)
                {
                    for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                    {
                        lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                    }
                    if (strTranType == "FC")
                    {
                        volume = (INVOICEobj.GetVolume(txtblno.Text, "FI", BranchID).ToString());
                    }
                    else
                    {
                        volume = (INVOICEobj.GetVolume(txtblno.Text, strTranType, BranchID).ToString());
                    }

                    lstvol.Items.Add(volume + " cbm");

                    if (strTranType == "FC")
                    {
                        wt = (INVOICEobj.GetWeight(txtblno.Text, "FI", BranchID)).ToString();
                    }
                    else
                    {
                        wt = (INVOICEobj.GetWeight(txtblno.Text, strTranType, BranchID)).ToString();
                    }

                    lstvol.Items.Add(wt + " Kgs");
                    lstcon.Items.Clear();

                    if (strTranType == "FC")
                    {
                        DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Text), txtblno.Text, "FI", BranchID);
                    }
                    else
                    {
                        DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Text), txtblno.Text, strTranType, BranchID);
                    }

                    if (DtInfo.Rows.Count != 0)
                    {
                        for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
                        {
                            lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
                        }
                    }
                }
            }
        }


        public void modulename()
        {
            if (strTranType == "FE")
            {
                txtModule.Text = "Ocean Exports";
            }
            else if (strTranType == "CC")
            {
                txtModule.Text = "Coastal Cargo";
            }
            else if (strTranType == "FI")
            {
                txtModule.Text = "Ocean Imports";
            }
            else if (strTranType == "AE")
            {
                txtModule.Text = "Air Exports";
            }
            else if (strTranType == "AI")
            {
                txtModule.Text = "Air Imports";
            }
            else if (strTranType == "CH")
            {
                txtModule.Text = "Custom House Agent";
            }
            else if (strTranType == "BT")
            {
                txtModule.Text = "Bonded Trucking";
            }
            else if (strTranType == "FC")
            {
                txtModule.Text = "Data Warehouse";
            }
        }

        public void getAEI()
        {
            txtjobno.Text = "";

            if (HORM == true)
            {
                //lstvol.Items.Clear();
                if (strTranType == "AE")
                {
                    DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                }
                else
                {
                    DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                }
                if (DtInfo.Rows.Count != 0)
                {
                    txtjobno.Text = DtInfo.Rows[0][0].ToString();
                    flightdate = Convert.ToDateTime((DtInfo.Rows[0][1]).ToString());
                    txtvessel.Text = DtInfo.Rows[0][2] + " / " + DtInfo.Rows[0]["fdate"];
                }
                else
                {
                    // txtclear()
                }
            }
            else
            {
                lstvol.Items.Clear();
                if (strTranType == "AE")
                {
                    DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                }
                else
                {
                    DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text, strTranType, Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
                }
                if (DtInfo.Rows.Count != 0)
                {
                    txtjobno.Text = DtInfo.Rows[0][0].ToString();
                    txtshipper.Text = DtInfo.Rows[0][3].ToString();
                    txtconsignee.Text = DtInfo.Rows[0][4].ToString();
                    txtnotify.Text = DtInfo.Rows[0][5].ToString();
                    flightdate = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                    //flightdate = Convert.ToDateTime(DtInfo.Rows[0]["flightdate"].ToString());
                    txtvessel.Text = DtInfo.Rows[0][2] + " / " + DtInfo.Rows[0]["fdate"];
                }
                else
                {
                    // txtclear()
                }
            }

        }

        public void getdetails()
        {
            if (lblheader.Text == "Invoice" || lblheader.Text == "Bill of Supply" || lblheader.Text == "Debit Note" || lblheader.Text == "InvoiceWoJ" || lblheader.Text == "Proforma Invoices" || lblheader.Text == "Extentions" || lblheader.Text == "FinalBills" || lblheader.Text == "Receipt - Bank")//temporary == "c - Bank"
            {
                string voutype = "";
                if (lblheader.Text == "Bill of Supply")
                {
                    voutype = "BOS";
                }
                else
                {
                    voutype = Session["vname"].ToString();
                }
                voutypeid = FAobj.Selvoutypeid(voutype, FADbName);
                int logcorid = 0;
                logcorid = hrempobj.GetBranchId(Div_Id, "CORPORATE");

                if (osvtype != "" && osvtype != null)
                {
                    dtfa = FAobj.SelFAVoucher4OSVou(Convert.ToInt32(txtVoucherno.Text), logcorid, Div_Id, voutypeid, Vou_Year, FADbName, BranchID, osvtype);
                }
                else
                {
                    if (PBranch_ID == 0 || LView_Flag == true)
                    {
                        dtfa = FAobj.SelFAVoucher(Convert.ToInt32(txtVoucherno.Text), BranchID, Div_Id, voutypeid, Vou_Year, FADbName);
                    }
                    else
                    {
                        dtfa = FAobj.SelFAVoucher4BP(Convert.ToInt32(txtVoucherno.Text), logcorid, Div_Id, voutypeid, Vou_Year, FADbName, BranchID);
                    }
                }

                if (dtfa.Rows.Count > 0)
                {
                    strTranType = dtfa.Rows[0]["trantype"].ToString();
                    txtjobno.Text = dtfa.Rows[0]["jobno"].ToString();
                    if (grd.Rows.Count > 0)
                    {
                        for (i = 0; i <= grd.Rows.Count - 1; i++)
                        {
                            //grd.Rows.Remove(grd.Rows(0));
                        }
                    }

                    DataRow dr_temp = dtfa.NewRow();
                    dr_temp["ledgername"] = "Total";
                    //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'");
                    //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'");
                    dtfa.Rows.Add(dr_temp);
                    grd.DataSource = dtfa;
                    grd.DataBind();

                    if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                    {
                        grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                    }
                    if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                    {
                        grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    }
                    //  grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                    // grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    btnback.ToolTip = "Cancel";
                    btnback1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Please Enter the valid Voucher #');", true);
                    Clear();
                    DataTable dtEmpty = new DataTable();
                    grd.DataSource = dtEmpty;
                    grd.DataBind();
                    txtVoucherno.Focus();
                    txtVoucherno.Text = "";
                    return;
                }

                if (lblheader.Text == "Invoice")
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "Invoice", Vou_Year, BranchID);
                }


                else if (lblheader.Text == "Bill of Supply")
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "BOS", Vou_Year, BranchID);
                }
                else if (lblheader.Text == "InvoiceWoJ")
                {
                    DtSHead = INVOICEobj.ShowIPHeadWoJ(Convert.ToInt32(txtVoucherno.Text), strTranType, "Invoice", Vou_Year, BranchID);
                }
                else if (lblheader.Text == "Debit Note")
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "DNHead", Vou_Year, BranchID);
                }
                else if (lblheader.Text == "Proforma Invoices")
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "Proforma Invoices", Vou_Year, BranchID);
                }
                else if (lblheader.Text == "Extentions")
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "Extentions", Vou_Year, BranchID);
                }
                else if (lblheader.Text == "FinalBills")
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "FinalBills", Vou_Year, BranchID);
                }

                i = DtSHead.Rows.Count;
                if (i > 0)
                {
                    if (vname == "Invoices")
                    {
                        lbl_against.Text = INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtVoucherno.Text), BranchID, Vou_Year, "I");
                    }
                    else if (vname == "Debit Note")
                    {
                        lbl_against.Text = INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtVoucherno.Text), BranchID, Vou_Year, "V");
                    }


                    if (lbl_against.Text == "0")
                    {
                        lbl_against.Text = "";
                    }
                    custid = Convert.ToInt32(DtSHead.Rows[0][4].ToString());
                    txtblno.Text = DtSHead.Rows[0][5].ToString();
                    voudate = Convert.ToDateTime(DtSHead.Rows[0][1].ToString());
                    txtremarks.Text = DtSHead.Rows[0][10].ToString();

                    if (!string.IsNullOrEmpty(DtSHead.Rows[0]["preparedbyname"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_prepare.Text = DtSHead.Rows[0]["preparedbyname"].ToString();
                    }

                    if (!string.IsNullOrEmpty(DtSHead.Rows[0]["approvedbyname"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_Approve.Text = DtSHead.Rows[0]["approvedbyname"].ToString();
                    }

                    if (lblheader.Text == "FinalBills")
                    {
                        voudate = Convert.ToDateTime(Utility.fn_ConvertDate((DtSHead.Rows[0]["f_date"]).ToString()));
                        txtvoudate.Text = DtSHead.Rows[0]["f_date"].ToString() + " / " + voudate.DayOfWeek;
                    }
                    else
                    {
                        voudate = Convert.ToDateTime(Utility.fn_ConvertDate((DtSHead.Rows[0]["fdate"]).ToString()));
                        txtvoudate.Text = DtSHead.Rows[0]["fdate"].ToString() + " / " + voudate.DayOfWeek;
                    }

                    if (strTranType == "FE" || strTranType == "FI" || strTranType == "FC")
                    {
                        if (!string.IsNullOrEmpty(txtblno.Text))
                        {
                            dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(txtjobno.Text), strTranType, BranchID);
                            for (i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                blno = dt.Rows[i][0].ToString();
                                if (blno == txtblno.Text)
                                {
                                    hid_hmbl.Value = "M";
                                    HORM = true;
                                    object Obj_boolvalue = HORM;
                                    int Bool_Value = Convert.ToInt32(Obj_boolvalue);
                                    hid_BoolValue.Value = Bool_Value.ToString();
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                            getFEI();
                        }
                    }
                    else if (strTranType == "AE" || strTranType == "AI")
                    {
                        if (!string.IsNullOrEmpty(txtblno.Text))
                        {
                            dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(txtjobno.Text), strTranType, BranchID);
                            for (i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                blno = dt.Rows[i][0].ToString();
                                if (blno == txtblno.Text)
                                {
                                    hid_hmbl.Value = "M";
                                    HORM = true;
                                    object Obj_boolvalue = HORM;
                                    int Bool_Value = Convert.ToInt32(Obj_boolvalue);
                                    hid_BoolValue.Value = Bool_Value.ToString();
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                            getAEI();
                        }
                    }
                    //----------------Karthika_K
                    else if (strTranType == "BT")
                    {
                        getBTDet();
                    }
                    else
                    {
                        //if (!string.IsNullOrEmpty(txtblno.Text))
                        if (txtblno.Text != "")
                        {
                            //getCHA();
                            getNEI();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Invalid Invoice #');", true);
                    return;
                }
            }
            else
            {
                voutypeid = FAobj.Selvoutypeid(Session["vname"].ToString(), FADbName);

                if (PBranch_ID == 0 || LView_Flag == true)
                {
                    dtfa = FAobj.SelFAVoucher(Convert.ToInt32(txtVoucherno.Text), BranchID, Div_Id, voutypeid, Vou_Year, FADbName);
                }
                else
                {
                    int logcorid = 0;
                    logcorid = hrempobj.GetBranchId(Div_Id, "CORPORATE");
                    dtfa = FAobj.SelFAVoucher4BP(Convert.ToInt32(txtVoucherno.Text), logcorid, Div_Id, voutypeid, Vou_Year, FADbName, BranchID);
                }

                if (dtfa.Rows.Count > 0)
                {
                    strTranType = dtfa.Rows[0]["trantype"].ToString();
                    txtjobno.Text = dtfa.Rows[0]["jobno"].ToString();
                    if (grd.Rows.Count > 0)
                    {
                        for (i = 0; i <= grd.Rows.Count - 1; i++)
                        {
                            //grd.Rows.Remove(grd.Rows(0));
                        }
                    }

                    DataRow dr_temp = dtfa.NewRow();
                    dr_temp["ledgername"] = "Total";
                    //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'");
                    //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'");
                    dtfa.Rows.Add(dr_temp);
                    grd.DataSource = dtfa;
                    grd.DataBind();
                    if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                    {
                        grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                    }
                    if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                    {
                        grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    }

                    // grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                    // grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    btnback.ToolTip = "Cancel";
                    btnback1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Please Enter the valid Voucher #');", true);
                    Clear();
                    DataTable dtEmpty = new DataTable();
                    grd.DataSource = dtEmpty;
                    grd.DataBind();
                    txtVoucherno.Focus();
                    txtVoucherno.Text = "";
                    return;
                }

                if (lblheader.Text == "Credit Note" || lblheader.Text == "Credit Note - Others")
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "CNHead", Vou_Year, BranchID);
                }
                else if (lblheader.Text == "Debit Note" || lblheader.Text == "Debit Note - Others")
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "DNHead", Vou_Year, BranchID);
                }
                else
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtVoucherno.Text), strTranType, "PA", Vou_Year, BranchID);
                }

                i = DtSHead.Rows.Count;
                if (i > 0)
                {
                    if (vname == "Credit Note")
                    {
                        lbl_against.Text = INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtVoucherno.Text), BranchID, Vou_Year, "E");
                    }
                    else if (vname == "Credit Note - Operations")
                    {
                        lbl_against.Text = INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtVoucherno.Text), BranchID, Vou_Year, "P");
                    }
                    txtblno.Text = DtSHead.Rows[0][5].ToString();
                    voudate = Convert.ToDateTime(DtSHead.Rows[0][1].ToString());
                    txtremarks.Text = DtSHead.Rows[0][10].ToString();
                    txtvoudate.Text = DtSHead.Rows[0]["fdate"].ToString() + " / " + voudate.DayOfWeek;

                    if (!string.IsNullOrEmpty(DtSHead.Rows[0]["preparedbyname"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_prepare.Text = DtSHead.Rows[0]["preparedbyname"].ToString();
                    }

                    if (!string.IsNullOrEmpty(DtSHead.Rows[0]["approvedbyname"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_Approve.Text = DtSHead.Rows[0]["approvedbyname"].ToString();
                    }

                    if (strTranType == "FE" || strTranType == "FI" || strTranType == "FC")
                    {
                        dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(txtjobno.Text), strTranType, BranchID);
                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            blno = dt.Rows[i][0].ToString();
                            if (blno == txtblno.Text)
                            {
                                HORM = true;
                                object Obj_boolvalue = HORM;
                                int Bool_Value = Convert.ToInt32(Obj_boolvalue);
                                hid_BoolValue.Value = Bool_Value.ToString();
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                        getFEI();
                    }
                    else if (strTranType == "AE" || strTranType == "AI")
                    {
                        dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(txtjobno.Text), strTranType, BranchID);
                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            blno = dt.Rows[i][0].ToString();
                            if (blno == txtblno.Text)
                            {
                                HORM = true;
                                object Obj_boolvalue = HORM;
                                int Bool_Value = Convert.ToInt32(Obj_boolvalue);
                                hid_BoolValue.Value = Bool_Value.ToString();
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                        getAEI();
                    }

                    else if (strTranType == "BT")
                    {
                        getBTDet();
                    }
                    else
                    {
                        getCHA();
                    }
                }
            }
        }

        public void getBTDet()
        {
            txtjobno.Text = "";
            dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text, strTranType, BranchID);
            if (dt.Rows.Count > 0)
            {
                txtjobno.Text = Convert.ToString(dt.Rows[0][0]);
                txtshipper.Text = dt.Rows[0][3].ToString();
                txtconsignee.Text = dt.Rows[0][4].ToString();
                txtnotify.Text = dt.Rows[0][5].ToString();
                txtvessel.Text = dt.Rows[0][2].ToString();
            }
        }


        public void getCHA()
        {
            txtjobno.Text = "";

            dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text, "CH", Convert.ToInt32(hf_LogBr_ID.Value.ToString()));
            if (dt.Rows.Count != 0)
            {
                txtjobno.Text = Convert.ToString(dt.Rows[0][0]);
                txtshipper.Text = dt.Rows[0][3].ToString();
                txtconsignee.Text = dt.Rows[0][4].ToString();
                txtnotify.Text = dt.Rows[0][5].ToString();
                txtvessel.Text = dt.Rows[0][2].ToString();

            }
            else
            {
                //txtclear()
            }

        }

        public void getNEI()
        {
            if (strTranType == "NE")
            {
                if (lblheader.Text != "InvoiceWoJ")
                {
                    if (HORM == true)
                    {
                        lstvol.Items.Clear();
                        DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Text), txtjobno.Text, strTranType, BranchID);
                        j = DtConDetails.Rows.Count;
                        if (j > 0)
                        {
                            for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                            }
                        }
                        lstcon.Items.Clear();
                        DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Text), txtjobno.Text, strTranType, BranchID);
                        if (DtCon.Rows.Count != 0)
                        {
                            for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
                            }
                        }
                        DtCon = JobObj.SelJobDetails(BranchID, Div_Id, Convert.ToInt32(txtjobno.Text));
                        if (DtCon.Rows.Count != 0)
                        {
                            vessel = DtCon.Rows[0]["vessel"].ToString();
                            voyage = DtCon.Rows[0]["voyage"].ToString();
                            txtvessel.Text = vessel + " / " + voyage;
                        }
                    }
                    else
                    {
                        lstvol.Items.Clear();
                        DtInfo = NEBLObj.GetBLDetails(Convert.ToString(txtblno.Text), BranchID, Div_Id);
                        if (DtInfo.Rows.Count != 0)
                        {
                            txtshipper.Text = DtInfo.Rows[0]["sname"].ToString();
                            txtconsignee.Text = DtInfo.Rows[0]["conname"].ToString();
                            txtnotify.Text = DtInfo.Rows[0]["nname"].ToString();
                            DtCon = JobObj.SelJobDetails(BranchID, Div_Id, Convert.ToInt32(txtjobno.Text));
                            if (DtCon.Rows.Count != 0)
                            {
                                vessel = DtCon.Rows[0]["vessel"].ToString();
                                voyage = DtCon.Rows[0]["voyage"].ToString();
                                txtvessel.Text = vessel + " / " + voyage;
                            }
                            else
                            {
                                //txtclear()
                            }

                            DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, BranchID);
                            j = DtConDetails.Rows.Count;
                            if (j > 0)
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
                            DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Text), txtblno.Text, strTranType, BranchID);
                            if (DtInfo.Rows.Count != 0)
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
                    dt = FEBLWoJobj.GetBLDetWOJob(txtblno.Text, BranchID, BranchID);
                    if (dt.Rows.Count != 0)
                    {
                        txtjobno.Text = "0";
                        txtshipper.Text = dt.Rows[0][3].ToString();
                        txtconsignee.Text = dt.Rows[0][6].ToString();
                        txtnotify.Text = dt.Rows[0][9].ToString();
                        txtvessel.Text = dt.Rows[0][33].ToString();
                    }
                }
            }
            else
            {
                if (HORM == true)
                {
                    lstvol.Items.Clear();
                    DtInfo = NIJobObj.ShowJobInfoFromJobno(Convert.ToInt32(txtjobno.Text), BranchID, Div_Id);
                    if (DtInfo.Rows.Count != 0)
                    {
                        vessel = DtInfo.Rows[0]["vessel"].ToString();
                        voyage = DtInfo.Rows[0]["voyage"].ToString();
                        txtvessel.Text = vessel + " / " + voyage;

                        DtCon = INVOICEobj.GetFIMblNContainers(txtjobno.Text, BranchID);
                        if (DtCon.Rows.Count != 0)
                        {
                            for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());
                            }
                        }
                        DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Text), txtjobno.Text, strTranType, BranchID);
                        j = DtConDetails.Rows.Count;
                        if (j > 0)
                        {
                            for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                            }
                        }
                    }
                    else
                    {
                        // txtclear()
                    }
                }
                else
                {
                    lstvol.Items.Clear();
                    DtInfo = NIBLObj.ShowBLDetails(txtblno.Text, BranchID, Div_Id, "D");
                    if (DtInfo.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        DtInfo = NIBLObj.ShowBLDetails(txtblno.Text, BranchID, Div_Id, "F");
                    }
                    if (DtInfo.Rows.Count != 0)
                    {
                        txtjobno.Text = DtInfo.Rows[0]["jobno"].ToString();
                        txtshipper.Text = DtInfo.Rows[0]["strshipper"].ToString();
                        txtconsignee.Text = DtInfo.Rows[0]["strconsignee"].ToString();
                        txtnotify.Text = DtInfo.Rows[0]["strnotify"].ToString();

                        DtInfo = NIJobObj.ShowJobInfoFromJobno(Convert.ToInt32(txtjobno.Text), BranchID, Div_Id);
                        if (DtInfo.Rows.Count != 0)
                        {
                            vessel = DtInfo.Rows[0]["vessel"].ToString();
                            voyage = DtInfo.Rows[0]["voyage"].ToString();
                            txtvessel.Text = vessel + " / " + voyage;
                        }
                    }
                    else
                    {
                        // txtclear()
                    }
                }
                DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, BranchID);
                j = DtConDetails.Rows.Count;
                if (j > 0)
                {
                    for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                    {
                        lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                    }
                    volume = (INVOICEobj.GetVolume(txtblno.Text, strTranType, BranchID).ToString());
                    lstvol.Items.Add(volume + " cbm");
                    wt = (INVOICEobj.GetWeight(txtblno.Text, strTranType, BranchID).ToString());
                    lstvol.Items.Add(wt + " Kgs");
                    lstcon.Items.Clear();
                    DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Text), txtblno.Text, strTranType, BranchID);
                    if (DtInfo.Rows.Count != 0)
                    {
                        for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
                        {
                            lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
                        }
                    }
                }
            }
        }

        protected void btnprvs_Click(object sender, EventArgs e)
        {
            if (txtVoucherno.Text.TrimEnd().Length > 0)
            {
                txtVoucherno.Text = (int.Parse(txtVoucherno.Text) - 1).ToString();
                txtVoucherno_TextChanged(sender, e);
            }

        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (txtVoucherno.Text.TrimEnd().Length > 0)
            {
                txtVoucherno.Text = (int.Parse(txtVoucherno.Text) + 1).ToString();
                txtVoucherno_TextChanged(sender, e);
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            if (btnback.ToolTip == "Cancel")
            {
                Clear();
                DataTable dtEmpty = new DataTable();
                grd.DataSource = dtEmpty;
                grd.DataBind();

                lbl_txt.Visible = false;
            }
            else
            {
                //this.Response.End();
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

            if (hf_flag.Value != "")
            {
                flag = Convert.ToBoolean(hf_flag.Value.ToString());
                if (flag == true)
                {
                    Boolean fg;
                    fg = true;
                    Response.Redirect("../FAForms/Statistics.aspx?flagvou=" + fg + "&vid=" + hf_vid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&vtype=" + hidvoutype.Value);
                    // this.Response.End();

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
            }

            if (Request.QueryString.ToString().Contains("Str_Name"))
            {
                if (Request.QueryString["Str_Name"] == "DayBook_Voucher")
                {
                    string fromDate = Request.QueryString["FromDate"];
                    string toDate = Request.QueryString["ToDate"];
                    string RefNo = Request.QueryString["RefNo"];
                    string Amount = Request.QueryString["Amount"];
                    string ddl_VouType = Request.QueryString["ddl_VouType"];
                    string ddl_AmtType = Request.QueryString["ddl_AmtType"];
                    string FrmName = "DayBook";
                    Response.Redirect("../FAForms/DayBook.aspx?Str_Name=" + FrmName + "&From=" + fromDate + "&To=" + toDate + "&VoucherNo=" + RefNo + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType + "&ddl_AmtType=" + ddl_AmtType, false);
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
            }

            if (Request.QueryString.ToString().Contains("FrmName"))
            {
                if (Request.QueryString["FrmName"] == "LedgerView_Voucher")
                {
                    //string LedgerName = Request.QueryString["LedgerName"];
                    //string fromDate = Request.QueryString["FromDate"];
                    //string toDate = Request.QueryString["ToDate"];
                    //string LedgerNo = Request.QueryString["QueryVoucherNo"];
                    //Response.Redirect("../FAForms/FALedgerView.aspx?LedgerName=" + LedgerName + "&From=" + fromDate + "&To=" + toDate + "&LedgerNo=" + LedgerNo, false);
                    //this.Response.End();
                }
            }
        }

        protected void Clear()
        {
            txtblno.Text = "";
            txtjobno.Text = "";
            txtconsignee.Text = "";
            txtvessel.Text = "";
            txtshipper.Text = "";
            txtnotify.Text = "";
            txtremarks.Text = "";
            txtVoucherno.Text = "";
            txtvoudate.Text = "";
            txtModule.Text = "";
            lstvol.Items.Clear();
            lstcon.Items.Clear();
            txtblno.Focus();
            btnback.ToolTip = "Back";
            btnback1.Attributes["class"] = "btn ico-cancel";
        }


        protected void btnview_Click(object sender, EventArgs e)
        {
            if (txtVoucherno.Text != "")
            {
                DateTime get_date, GST_date;

                BranchID = Convert.ToInt32(hf_LogBr_ID.Value);
                get_date = Convert.ToDateTime(Utility.fn_ConvertDate(txtvoudate.Text));
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                Session["str_sfs"] = ""; Session["str_sp"] = "";
                string str_sp = "", str_sf = "", str_RptName = "", str_RptName1 = "", str_Script = "", header = "", bltype = "", agent = "";
                int LogYear = int.Parse(Session["LogYear"].ToString());
                string containernos = "";


                if (hid_BoolValue.Value == "1")
                {
                    bltype = "M";
                    HORM = true;
                }
                else
                {
                    bltype = "H";
                }



                if (strTranType == "NE" || strTranType == "NI")
                {
                    containernos = "";
                    if (lstvol.Items.Count > 0)
                    {
                        containernos = lstvol.Items[0].ToString();
                    }
                    for (int i = 0; i <= lstvol.Items.Count - 1; i++)
                    {
                        containernos = containernos + " / " + lstvol.Items[i].ToString();
                    }
                }

                if (lblheader.Text == "Invoice" || lblheader.Text == "Invoices")
                {
                    header = "Invoice";
                    if (txtVoucherno.Text != "")
                    {
                        if (strTranType == "FE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "FEMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "FEMInvoice.rpt";
                            }
                        }
                        else if (strTranType == "FI" || strTranType == "FC")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "FIMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "FIInvoice.rpt";
                            }
                        }
                        else if (strTranType == "NI")
                        {
                            if (strTranType == "NE" || strTranType == "NI")
                            {
                                containernos = "";
                                if (lstvol.Items.Count > 0)
                                {
                                    containernos = lstvol.Items[0].ToString();
                                }
                                for (int i = 0; i <= lstvol.Items.Count - 1; i++)
                                {
                                    containernos = containernos + " / " + lstvol.Items[i].ToString();
                                }

                                if (HORM == true)
                                {
                                    str_RptName = "NIMInvoice.rpt";
                                }
                                else
                                {
                                    str_RptName = "NIInvoice.rpt";
                                }
                            }
                        }
                        else if (strTranType == "NE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "NEMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "NEInvoice.rpt";
                            }
                        }
                        else if (strTranType == "AE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "AEMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "AEInvoice.rpt";
                            }
                        }
                        else if (strTranType == "AI")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "AIMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "AIInvoice.rpt";
                            }
                        }
                        else if (strTranType == "CH")
                        {
                            str_RptName = "CHInvoice.rpt";
                        }
                        else if (strTranType == "BT")
                        {
                            str_RptName = "BTInvoice.rpt";
                        }

                        if (strTranType == "NE" || strTranType == "NI" || strTranType == "BT")
                        {
                            if (strTranType == "BT")
                            {
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }
                            Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + strTranType + "' and {ACInvoiceHead.invoiceno}=" + txtVoucherno.Text + " and {ACInvoiceHead.branchid}=" + BranchID + " and {ACInvoiceHead.vouyear}=" + LogYear;
                        }
                        else
                        {
                            if (strTranType == "FE" || strTranType == "FI" || strTranType == "AE" || strTranType == "AI")
                            {
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }
                            Session["str_sfs"] = "{InvoiceHead.trantype}='" + strTranType + "' and {InvoiceHead.invoiceno}=" + txtVoucherno.Text + " and {InvoiceHead.branchid}=" + BranchID + " and {InvoiceHead.vouyear}=" + LogYear;
                        }

                        if (strTranType == "FE" || strTranType == "FI" || strTranType == "NE" || strTranType == "NI" || strTranType == "FC")
                        {
                            Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                        }
                        else
                        {
                            Session["str_sp"] = "Lcurr=INR ";
                        }
                        if (get_date >= GST_date)
                        {
                            if (strTranType == "LT")
                            {
                                str_Script = "window.open('../Reportasp/Invoicerpt1.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&blno=" + "" + "&bltype=" + bltype + "&header=" + header + "&trantype=" + strTranType + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&blno=" + "" + "&bltype=" + bltype + "&header=" + header + "&trantype=" + strTranType + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Voucher", str_Script, true);
                    }
                    Logobj.InsLogDetail(Emp_Id, 1088, 3, BranchID, strTranType + txtVoucherno.Text);
                }

                else if (lblheader.Text == "Bill of Supply")
                {
                    header = "Bill of Supply";
                    if (txtVoucherno.Text != "")
                    {
                        if (strTranType == "FE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "FEMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "FEMInvoice.rpt";
                            }
                        }
                        else if (strTranType == "FI" || strTranType == "FC")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "FIMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "FIInvoice.rpt";
                            }
                        }
                        else if (strTranType == "NI")
                        {
                            if (strTranType == "NE" || strTranType == "NI")
                            {
                                containernos = "";
                                if (lstvol.Items.Count > 0)
                                {
                                    containernos = lstvol.Items[0].ToString();
                                }
                                for (int i = 0; i <= lstvol.Items.Count - 1; i++)
                                {
                                    containernos = containernos + " / " + lstvol.Items[i].ToString();
                                }

                                if (HORM == true)
                                {
                                    str_RptName = "NIMInvoice.rpt";
                                }
                                else
                                {
                                    str_RptName = "NIInvoice.rpt";
                                }
                            }
                        }
                        else if (strTranType == "NE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "NEMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "NEInvoice.rpt";
                            }
                        }
                        else if (strTranType == "AE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "AEMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "AEInvoice.rpt";
                            }
                        }
                        else if (strTranType == "AI")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "AIMInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "AIInvoice.rpt";
                            }
                        }
                        else if (strTranType == "CH")
                        {
                            str_RptName = "CHInvoice.rpt";
                        }
                        else if (strTranType == "BT")
                        {
                            str_RptName = "BTInvoice.rpt";
                        }

                        if (strTranType == "NE" || strTranType == "NI" || strTranType == "BT")
                        {
                            if (strTranType == "BT")
                            {
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }
                            Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + strTranType + "' and {ACInvoiceHead.invoiceno}=" + txtVoucherno.Text + " and {ACInvoiceHead.branchid}=" + BranchID + " and {ACInvoiceHead.vouyear}=" + LogYear;
                        }
                        else
                        {
                            if (strTranType == "FE" || strTranType == "FI" || strTranType == "AE" || strTranType == "AI")
                            {
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }
                            Session["str_sfs"] = "{InvoiceHead.trantype}='" + strTranType + "' and {InvoiceHead.invoiceno}=" + txtVoucherno.Text + " and {InvoiceHead.branchid}=" + BranchID + " and {InvoiceHead.vouyear}=" + LogYear;
                        }

                        if (strTranType == "FE" || strTranType == "FI" || strTranType == "NE" || strTranType == "NI" || strTranType == "FC")
                        {
                            Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                        }
                        else
                        {
                            Session["str_sp"] = "Lcurr=INR ";
                        }
                        if (get_date >= GST_date)
                        {
                            if (strTranType == "LT")
                            {
                                str_Script = "window.open('../Reportasp/Invoicerpt1.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&blno=" + "" + "&bltype=" + bltype + "&header=" + header + "&trantype=" + strTranType + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&blno=" + "" + "&bltype=" + bltype + "&header=" + header + "&trantype=" + strTranType + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Voucher", str_Script, true);
                    }
                    //Logobj.InsLogDetail(Emp_Id, 1088, 3, BranchID, strTranType + txtVoucherno.Text);
                    Logobj.InsLogDetail(Emp_Id, 1929, 3, BranchID, strTranType + txtVoucherno.Text);
                }
                else if (lblheader.Text == "Debit Note" || lblheader.Text == "Credit Note" || lblheader.Text == "Debit Note - Others" || lblheader.Text == "Credit Note - Others")
                {
                    if (strTranType == "FE" || strTranType == "FI" || strTranType == "FC")
                    {
                        containernos = "";
                        if (lstvol.Items.Count > 0)
                        {
                            containernos = lstvol.Items[0].ToString();
                        }
                        for (int i = 0; i <= lstvol.Items.Count - 1; i++)
                        {
                            containernos = containernos + " / " + lstvol.Items[i].ToString();
                        }
                    }

                    if (HORM == false)
                    {
                        if (lblheader.Text == "Debit Note" || lblheader.Text == "Debit Note - Others")
                        {
                            header = "DN";
                            if (txtVoucherno.Text == "")
                            {
                                str_RptName = "OthDNRegister.rpt";
                                Session["str_sp"] = "Title=Debit Note Register";
                                Session["str_sfs"] = "{DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear;

                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                                //-------------------------------------------------------------

                                str_RptName = "OthDNRegisterNew.rpt";
                                Session["str_sp"] = "Title=Debit Note Raised After Job Closing";
                                Session["str_sfs"] = "{DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNHead.dndate} > {RPTJobDetails.closeddate}";

                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else
                            {
                                if (strTranType == "FE")
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                                }
                                else if (strTranType == "FI" || strTranType == "FC")
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        //Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";

                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        //Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";

                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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

                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                                }
                            }
                        }
                        else
                        {
                            if (txtVoucherno.Text == "")
                            {
                                str_RptName = "OthCNRegister.rpt";
                                Session["str_sfs"] = "{CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear;
                                Session["str_sp"] = "Title=Credit Note Register";

                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                                str_RptName = "OthCNRegisterNew.rpt";
                                Session["str_sfs"] = "{CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + "and {CNHead.cndate} > {RPTJobDetails.closeddate}";
                                Session["str_sp"] = "Title=Credit Note Raised After Job Closing";

                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else
                            {
                                header = "CN";
                                if (strTranType == "FE")
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                                }
                                else if (strTranType == "FI")
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblheader.Text == "Debit Note - Others")
                        {
                            header = "DN";
                            if (txtVoucherno.Text == "")
                            {
                                str_RptName = "OthDNRegister.rpt";
                                Session["str_sfs"] = "{DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear;
                                Session["str_sp"] = "Title=Debit Note Register";

                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);


                                str_RptName = "OthDNRegisterNew.rpt";
                                Session["str_sfs"] = "{DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + "and {DNHead.dndate} > {RPTJobDetails.closeddate}";
                                Session["str_sp"] = "Title=Debit Note Raised After Job Closing";

                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else
                            {
                                if (strTranType == "FE")
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                                }
                                else if (strTranType == "FI" || strTranType == "FC")
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtVoucherno.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + LogYear + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                                }
                            }
                        }
                        else
                        {
                            if (txtVoucherno.Text == "")
                            {
                                str_RptName = "OthCNRegister.rpt";
                                Session["str_sfs"] = "{CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear;
                                Session["str_sp"] = "Title=Credit Note Register";
                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                                str_RptName = "OthCNRegisterNew.rpt";
                                Session["str_sfs"] = "{CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + "and {CNHead.cndate} > {RPTJobDetails.closeddate}";
                                Session["str_sp"] = "Title=Credit Note Raised After Job Closing";
                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else
                            {
                                header = "CN";
                                if (strTranType == "FE")
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                                }
                                else if (strTranType == "FI")
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtVoucherno.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + LogYear + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + LogYear;
                                    Session["str_sp"] = "Lcurr=INR";
                                    if (get_date >= GST_date)
                                    {
                                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                                }
                            }
                        }

                    }
                }

                else if (lblheader.Text == "OSSI" || lblheader.Text == "OS DN" || lblheader.Text == "OSPI" || lblheader.Text == "OS CN")
                {
                    string Fcurr = "";

                    if (lblheader.Text == "OSSI" || lblheader.Text == "OS DN")
                    {
                        Fcurr = OSDNCN.GetCurrOSDCN(Convert.ToInt32(txtjobno.Text), strTranType, "D", BranchID);
                        frmtype = "OSSI";
                        bltype = "OSSI";
                        type1 = bltype;
                    }
                    else
                    {
                        Fcurr = OSDNCN.GetCurrOSDCN(Convert.ToInt32(txtjobno.Text), strTranType, "C", BranchID);
                        frmtype = "OSPI";
                        bltype = "OSPI";
                        type1 = bltype;
                    }

                    Session["str_sp"] = "FCurr=" + Fcurr;
                    dtdebit = OSDNCN.RptOSDNCharges(Convert.ToInt32(txtVoucherno.Text), frmtype, strTranType, LogYear, BranchID);
                    dtcredit = OSDNCN.RptOSCNCharges(Convert.ToInt32(txtVoucherno.Text), frmtype, strTranType, LogYear, BranchID);

                    if (txtVoucherno.Text != "")
                    {
                        if (lblheader.Text == "OSSI" || lblheader.Text == "OS DN")
                        {
                            if (strTranType == "FE")
                            {
                                str_RptName = "FEOSDN.rpt";
                                Session["str_sfs"] = "{OSDN.trantype}='" + strTranType + "' and {OSDN.dnno}=" + txtVoucherno.Text + " and {OSDN.branchid}=" + BranchID + " and {OSDN.vouyear}=" + LogYear;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/ProformaOverseaDebiCrediFA.aspx?refno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&branchid=" + BranchID + "&tran=" + strTranType + "&jobno=" + txtjobno.Text + "&bltype=" + type1 + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }
                        else
                        {
                            if (strTranType == "FE")
                            {
                                str_RptName = "FEOSCN.rpt";
                                Session["str_sfs"] = "{OSCN.trantype}='" + strTranType + "' and {OSCN.cnno}=" + txtVoucherno.Text + " and {OSCN.branchid}=" + BranchID + " and {OSCN.vouyear}=" + LogYear;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/ProformaOverseaDebiCrediFA.aspx?refno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&branchid=" + BranchID + "&tran=" + strTranType + "&jobno=" + txtjobno.Text + "&bltype=" + type1 + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }

                        if (lblheader.Text == "OSSI" || lblheader.Text == "OS DN")
                        {
                            if (strTranType == "AE")
                            {
                                str_RptName = "AEOSDN.rpt";
                                Session["str_sfs"] = "{OSDN.trantype}='" + strTranType + "' and {OSDN.dnno}=" + txtVoucherno.Text + " and {OSDN.branchid}=" + BranchID + " and {OSDN.vouyear}=" + LogYear;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/ProformaOverseaDebiCrediFA.aspx?refno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&branchid=" + BranchID + "&tran=" + strTranType + "&jobno=" + txtjobno.Text + "&bltype=" + type1 + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIOSDN.rpt";
                                Session["str_sfs"] = "{OSDN.trantype}='" + strTranType + "' and {OSDN.dnno}=" + txtVoucherno.Text + " and {OSDN.branchid}=" + BranchID + " and {OSDN.vouyear}=" + LogYear;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/ProformaOverseaDebiCrediFA.aspx?refno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&branchid=" + BranchID + "&tran=" + strTranType + "&jobno=" + txtjobno.Text + "&bltype=" + type1 + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }
                        else
                        {
                            if (strTranType == "AE")
                            {
                                str_RptName = "AEOSCN.rpt";
                                Session["str_sfs"] = "{OSCN.trantype}='" + strTranType + "' and {OSCN.cnno}=" + txtVoucherno.Text + " and {OSCN.branchid}=" + BranchID + " and {OSCN.vouyear}=" + LogYear;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/ProformaOverseaDebiCrediFA.aspx?refno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&branchid=" + BranchID + "&tran=" + strTranType + "&jobno=" + txtjobno.Text + "&bltype=" + type1 + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIOSCN.rpt";
                                Session["str_sfs"] = "{OSCN.trantype}='" + strTranType + "' and {OSCN.cnno}=" + txtVoucherno.Text + " and {OSCN.branchid}=" + BranchID + " and {OSCN.vouyear}=" + LogYear;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/ProformaOverseaDebiCrediFA.aspx?refno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&branchid=" + BranchID + "&tran=" + strTranType + "&jobno=" + txtjobno.Text + "&bltype=" + type1 + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }

                        if (lblheader.Text == "OSSI" || lblheader.Text == "OS DN")
                        {
                            if (strTranType == "FI")
                            {
                                str_RptName = "FIOSDN.rpt";
                                Session["str_sfs"] = "{OSDN.trantype}='" + strTranType + "' and {OSDN.dnno}=" + txtVoucherno.Text + " and {OSDN.branchid}=" + BranchID + " and {OSDN.vouyear}=" + LogYear;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/ProformaOverseaDebiCrediFA.aspx?refno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&branchid=" + BranchID + "&tran=" + strTranType + "&jobno=" + txtjobno.Text + "&bltype=" + type1 + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }
                        else
                        {
                            if (strTranType == "FI")
                            {
                                str_RptName = "FIOSCN.rpt";
                                Session["str_sfs"] = "{OSCN.trantype}='" + strTranType + "' and {OSCN.cnno}=" + txtVoucherno.Text + " and {OSCN.branchid}=" + BranchID + " and {OSCN.vouyear}=" + LogYear;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/ProformaOverseaDebiCrediFA.aspx?refno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&branchid=" + BranchID + "&tran=" + strTranType + "&jobno=" + txtjobno.Text + "&bltype=" + type1 + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }
                        //if (get_date >= GST_date)
                        //{
                        //    Session["str_sfs"] = null;
                        //}
                        //str_RptName = "SOA1.rpt";
                        //Session["str_sfs1"] = "{MasterBranch.branchid}=" + BranchID;
                        //Session["str_sp1"] = "module=" + strTranType + "~jobno=" + txtjobno.Text + "~drow=" + dtdebit.Rows.Count + "~crow=" + dtcredit.Rows.Count;

                        //   str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                        if (lblheader.Text == "OS DN")
                        {
                            Logobj.InsLogDetail(Emp_Id, 1090, 3, BranchID, strTranType + txtjobno.Text + "/V");
                        }
                        else
                        {
                            Logobj.InsLogDetail(Emp_Id, 1091, 3, BranchID, strTranType + txtjobno.Text + "/V");
                        }
                    }
                }

                else if (lblheader.Text == "Proforma Invoices")
                {
                    header = "Invoice";
                    Session["str_sfs"] = "{NIPIHead.pid}=" + txtVoucherno.Text.Trim() + " and {NIPIHead.bid}=" + BranchID + " and {NIPIHead.vouyear}=" + LogYear;
                    Session["str_sp"] = "detamt=" + 0 + "~demamt=" + 0 + "~berthedon=" + System.DateTime.Now.ToString("dd/MM/yyyy");
                }
                else if (lblheader.Text == "Extentions")
                {
                    Session["str_sfs"] = "{NIExtentionHead.eid}=" + txtVoucherno.Text.Trim() + " and {NIExtentionHead.bid}=" + BranchID + " and {NIExtentionHead.vouyear}=" + LogYear;
                    Session["str_sp"] = "detamt=" + 0 + "~demamt=" + 0 + "~berthedon=" + System.DateTime.Now.ToString("dd/MM/yyyy");
                }
                else if (lblheader.Text == "FinalBills")
                {

                }
                else if (lblheader.Text == "OSDNCN JV" || lblheader.Text == "OSDNCNJV")
                {
                    str_RptName = "rptJV.rpt";
                    Session["str_sfs"] = "{MasterVoucherHead.vouno}=" + txtVoucherno.Text.Trim() + " and {MasterVoucherHead.voutype}=101 and {MasterVoucherHead.branchid}=" + BranchID + " and {MasterVoucherHead.divisionid}=" + LogYear;
                    Session["str_sp"] = "Title=OSDNCN JV~PeriodFrom=" + "Apr" + LogYear + "~PeriodTo=" + "Mar" + LogYear;

                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                    if (lblheader.Text == "OSDNCN JV")
                    {
                        Logobj.InsLogDetail(Emp_Id, 1194, 3, BranchID, txtVoucherno.Text + "/V");
                    }
                }
                else
                {
                    if (txtVoucherno.Text != "")
                    {
                        header = "PA";
                        if (strTranType == "NE" || strTranType == "NI")
                        {
                            Session["str_sp"] = "Lcurr=INR~containernos=" + containernos;
                        }
                        else
                        {
                            Session["str_sp"] = "Lcurr=INR";
                        }

                        if (strTranType == "FE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "FEMPA.rpt";
                            }
                            else
                            {
                                str_RptName = "FEPA.rpt";
                            }
                            if (get_date >= GST_date)
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (strTranType == "FI" || strTranType == "FC")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "FIMPA.rpt";
                            }
                            else
                            {
                                str_RptName = "FIPA.rpt";
                            }
                            if (get_date >= GST_date)
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (strTranType == "NE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "NEMPA.rpt";
                            }
                            else
                            {
                                str_RptName = "NEPA.rpt";
                            }
                            if (get_date >= GST_date)
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (strTranType == "NI")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "NICFSPA.rpt";
                            }
                            else
                            {
                                str_RptName = "NIPA.rpt";
                            }
                        }
                        else if (strTranType == "AE")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "AEMPA.rpt";
                            }
                            else
                            {
                                str_RptName = "AEPA.rpt";
                            }
                            if (get_date >= GST_date)
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (strTranType == "AI")
                        {
                            if (HORM == true)
                            {
                                str_RptName = "AIMPA.rpt";
                            }
                            else
                            {
                                str_RptName = "AIPA.rpt";
                            }
                            if (get_date >= GST_date)
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (strTranType == "CH")
                        {

                            str_RptName = "CHAPA.rpt";
                            if (get_date >= GST_date)
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (strTranType == "BT")
                        {
                            str_RptName = "BTPA.rpt";
                            if (get_date >= GST_date)
                            {
                                str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }

                        if (strTranType == "BT")
                        {
                            Session["str_sfs"] = "{ACPAHead.trantype}='" + strTranType + "' and {ACPAHead.pano}=" + txtVoucherno.Text + " and {ACPAHead.branchid}=" + BranchID + " and {ACPAHead.vouyear}=" + LogYear;
                        }
                        else
                        {
                            Session["str_sfs"] = "{PAHead.trantype}='" + strTranType + "' and {PAHead.pano}=" + txtVoucherno.Text + " and {PAHead.branchid}=" + BranchID + " and {PAHead.vouyear}=" + LogYear;
                        }
                        if (get_date >= GST_date && (strTranType == "FE" || strTranType == "FI" || strTranType == "AE" || strTranType == "AI" || strTranType == "CH" || strTranType == "BT" || strTranType == "WH" || strTranType == "CT"))
                        {
                            str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtVoucherno.Text + "&vouyear=" + LogYear.ToString() + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                    }
                    Logobj.InsLogDetail(Emp_Id, 1089, 3, BranchID, strTranType + txtVoucherno.Text);
                }
                HORM = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter the voucher #')", true);
                return;
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
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            GridViewlog.Visible = true;
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            lbl_title.InnerText = lblheader.Text;
            if (lblheader.Text == "Invoice")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1088, "Inv", txtVoucherno.Text, txtVoucherno.Text, Session["StrTranType"].ToString());
            }
            else if (lblheader.Text == "Credit Note - Operations")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1089, "PA", txtVoucherno.Text, txtVoucherno.Text, Session["StrTranType"].ToString());
            }
            else if (lblheader.Text == "OSSI")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1090, "OSSI", txtVoucherno.Text, txtVoucherno.Text, Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1091, "OSPI", txtVoucherno.Text, txtVoucherno.Text, Session["StrTranType"].ToString());
            }

            if (txtVoucherno.Text != "")
            {
                JobInput.Text = txtVoucherno.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
    }
}
