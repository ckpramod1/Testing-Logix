using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess.HR;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;

namespace logix.Accounts
{
    public partial class ApprovedOSVouchers : System.Web.UI.Page
    {
        DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.OSDNCN OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();
        DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.JobInfo FIJobObj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.AirImportExports.AIEJobInfo AIEJobObj = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.Accounts.DCAdvise DebitObj = new DataAccess.Accounts.DCAdvise();
        DataAccess.ForwardingExports.BLDetails FEBLObj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingImports.BLDetails FIBLObj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.AirImportExports.AIEBLDetails AEBLObj = new DataAccess.AirImportExports.AIEBLDetails();
        DataTable dt = new DataTable();
        DataTable dtOSCN = new DataTable();
        DataTable dtOSDN = new DataTable();
        DataTable Dt = new DataTable();
        DataTable Dt1 = new DataTable();
        DataTable dtbranch = new DataTable();

        string strtrantype, damount, camount, intdnno, voutype, strblno, strcharge, strbase, activity, strtype;
        int divisionid, intagent, djobno, cjobno, vouno, intsalesperson;
        int branchid, vouyear, jobtype, logempid, cnno, intcnno, dnno;
        double damt, camt, oldamount, amount;
        double debittotal = 0, credittotal = 0, total = 0, FCTotal=0;
        int jobno, i;
        DateTime voudate, dtdate, jobdate;
        DateTime GST_date;
        string FADbName, str_dispyear;
        string vname = "";
        DataTable dtfa = new DataTable();
        int voutypeid;
        DataAccess.FAVoucher FAobj = new DataAccess.FAVoucher();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();

        DataTable DtSHead = new DataTable();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.BLDetailsWOJob FEBLWoJobj = new DataAccess.ForwardingExports.BLDetailsWOJob();
        bool HORM;
        DataTable DtInfo = new DataTable();
        string blno;
        DataTable DtConDetails = new DataTable();
        DataTable DtCon = new DataTable();
        int j;
        string Trantype;
        string refno;
        
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);




            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                appobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                OSDNCN.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                DAdvise.GetDataBase(Ccode);
                FEJobObj.GetDataBase(Ccode);
                FIJobObj.GetDataBase(Ccode);
                AIEJobObj.GetDataBase(Ccode);
                DebitObj.GetDataBase(Ccode);
                FEBLObj.GetDataBase(Ccode);

                FIBLObj.GetDataBase(Ccode);
                AEBLObj.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
                FEJobobj.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
                FEBLobj.GetDataBase(Ccode);
                FEBLWoJobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                da_obj_OSDNCN.GetDataBase(Ccode);
                da_obj_logobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               
               
            }

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Session["str_sfs1"] = "";
            Session["str_sp1"] = "";
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://SL.copperhawk.tech/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://SL.copperhawk.tech/FormMain.aspx','_top');", true);
            }
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            strtrantype = Session["StrTranType"].ToString();
            divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            branchid = Convert.ToInt32(Session["LoginBranchid"]);

            logempid = Convert.ToInt32(Session["LoginEmpId"]);
            Trantype = Session["StrTranType"].ToString();
            
            if (!this.IsPostBack)
            {
                //if (Request.QueryString.ToString().Contains("type"))
                //{
                //    frmname = Request.QueryString["type"].ToString();
                //}
                //if (Request.QueryString.ToString().Contains("FormName"))
                //{
                //    frmname = Request.QueryString["FormName"].ToString();
                //}

                

                try
                {
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        lbl_Header.Text = Request.QueryString["type"].ToString();
                    }
                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lbl_Header.Text = Request.QueryString["FormName"].ToString();
                    }

                    if (lbl_Header.Text == "OSSI")
                    {
                        ddlTypes.Items.FindByText("OSSI").Selected = true;
                        //Label4.Visible = true;
                        //pnlCCharge.Visible = true;
                        ////grddebit.Visible = true;
                        //Label8.Visible = true;
                        //txt_total.Visible = true;
                        //Label5.Visible = false;
                        //Panel2.Visible = false;
                        ////grdcredit.Visible = false;
                        //Label11.Visible = false;
                        //txttotal.Visible = false;
                        Label4.Text = "Receivable from Agent";
                        HeaderLabel.InnerText = lbl_Header.Text;
                        Label10.Visible = false;
                        txtVendorRefnodate.Visible = false;
                        Label9.Visible = false;
                        txtVendorRefno.Visible = false;
                        Label2.Text = "OSSI #";
                    }
                    else if (lbl_Header.Text == "OSPI")
                    {
                        ddlTypes.Items.FindByText("OSPI").Selected = true;
                        //Label5.Visible = true;
                        //Panel2.Visible = true;
                        ////grdcredit.Visible = true;
                        //Label11.Visible = true;
                        //txttotal.Visible = true;
                        //Label4.Visible = false;
                        //pnlCCharge.Visible = false;
                        ////grddebit.Visible = false;
                        //Label8.Visible = false;
                        //txt_total.Visible = false;
                        Label4.Text = "Payable to Agent";
                        HeaderLabel.InnerText = lbl_Header.Text;
                        Label2.Text = "OSPI #";
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
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            lblHead.InnerText = "Ocean Imports";
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            lblHead.InnerText = "Air Exports";
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            lblHead.InnerText = "Air Imports";
                        }
                    }
                    else if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC")
                    {
                        homelbl.Visible = false;
                        lblHead.InnerText = "Financial Accounts";
                        lblAcc.InnerText = "Vouchers";
                        txtyear.Enabled = false;
                        txtvoudate.Enabled = false;
                    }
                    else if (Hid_HeadTrantype.Value == "AC")
                    {
                        homelbl.Visible = false;
                        lblHead.InnerText = "Operating Accounts";
                        lblAcc.InnerText = "Vouchers";
                    }

                    txtJobno.Focus();
                    //25-05-2021
                    if (logobj.GetDate().Month < 4)
                    {
                        txtyear.Text = (logobj.GetDate().Year - 1).ToString();
                        vouyear = Convert.ToInt32((logobj.GetDate().Year - 1).ToString());
                    }
                    else
                    {
                        txtyear.Text = (logobj.GetDate().Year).ToString();
                        vouyear = Convert.ToInt32((logobj.GetDate().Year).ToString());
                    }

                    if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC")
                    {
                        txtyear.Text = Session["LogYear"].ToString();
                    }
                    txtvoudate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");

                    grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdcredit.DataBind();
                    grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                    grddebit.DataBind();
                    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd.DataBind();

                    fillBranch();
                    if (Trantype == "CO")
                    {
                        hid_Tran.Value = "CA";
                    }

                    if (hid_Tran.Value != "CA")
                    {
                        ddl_branch.Enabled = false;
                        ddl_branch.Text = Session["LoginBranchName"].ToString();
                    }
                    else
                    {
                        ddl_branch.Enabled = true;
                        ddl_branch.SelectedIndex = -1;
                    }
                    ddl_branch_SelectedIndexChanged(sender, e);
                    //Dinesh newly changes

                    //Start

                    if (Request.QueryString.ToString().Contains("jobno1"))
                    {

                        txtJobno.Text = Request.QueryString["jobno1"].ToString();
                        ddlTypes.SelectedValue = Request.QueryString["typenew"].ToString();
                        txtJobno_TextChanged(sender, e);
                        return;
                    }


                    //end

                    //DNEW
                    if (Request.QueryString.ToString().Contains("ddlprod"))
                    {
                        strtrantype = Request.QueryString["ddlprod"].ToString();
                        if (strtrantype == "FE")
                        {
                            lblHead.InnerText = "Ocean Exports";

                        }
                        else if (strtrantype == "FI")
                        {
                            lblHead.InnerText = "Ocean Imports";
                        }
                        else if (strtrantype == "AE")
                        {
                            lblHead.InnerText = "Air Exports";
                        }
                        else if (strtrantype == "AI")
                        {
                            lblHead.InnerText = "Air Imports";
                        }
                        else if (strtrantype == "CH")
                        {
                            lblHead.InnerText = "CHA";
                        }
                        txtJobno.Text = Request.QueryString["jobno3"].ToString();
                        ddlTypes.SelectedValue = Request.QueryString["typenew1"].ToString();
                        txtJobno_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("PROJ"))
                    {
                        if (Request.QueryString["PROTY"].ToString() == "OSSI")
                        {
                            ddlTypes.SelectedValue = "5";
                        }
                        else if (Request.QueryString["PROTY"].ToString() == "OSPI")
                        {
                            ddlTypes.SelectedValue = "6";
                        }

                        txtdcn.Text = Request.QueryString["PRONO"].ToString();
                        ddlTypes_SelectedIndexChanged(sender, e);

                        txtdcn_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("FAvouTYPE"))
                    {
                        ddlTypes.SelectedValue = Request.QueryString["FAvouTYPE"].ToString();

                        ddlTypes_SelectedIndexChanged(sender, e);
                        txtdcn.Text = Request.QueryString["vouno"].ToString();
                        txtdcn_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("COvouTYPE"))
                    {
                        ddlTypes.SelectedValue = Request.QueryString["COvouTYPE"].ToString();
                        Session["LoginBranchid"] = Request.QueryString["PBranch_ID"].ToString();
                        branchid = Convert.ToInt32(Session["LoginBranchid"]);
                        ddlTypes_SelectedIndexChanged(sender, e);
                        txtdcn.Text = Request.QueryString["vouno"].ToString();
                        txtdcn_TextChanged(sender, e);
                    }

                    //end

                    //if (logobj.GetDate().Month < 4)
                    //{
                    //    txtyear.Text = (logobj.GetDate().Year - 1).ToString();
                    //    vouyear = Convert.ToInt32((logobj.GetDate().Year - 1).ToString());
                    //}
                    //else
                    //{
                    //    txtyear.Text = (logobj.GetDate().Year).ToString();
                    //    vouyear = Convert.ToInt32((logobj.GetDate().Year).ToString());
                    //}

                    //grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                    //grdcredit.DataBind();
                    //grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                    //grddebit.DataBind();

                    btnback.Text = "Cancel";

                    btnback.ToolTip = "Cancel";
                    btnback1.Attributes["class"] = "btn ico-cancel";

                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

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
            txtVendorRefno.Text = "";
            txtVendorRefnodate.Text = "";
            txtModule.Text = "";
            lstagnst.Items.Clear();
            lstcon.Items.Clear();
            lstvol.Items.Clear();
            txttotal.Text = "";
            txt_total.Text = "";
            txtvoudate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
            
            grddebit.DataSource = null;
            grddebit.DataBind();

            grdcredit.DataSource = null;
            grdcredit.DataBind();

            grd.DataSource = null;
            grd.DataBind();

            btnview.Enabled = true;
            btnview.ForeColor = System.Drawing.Color.White;

            grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
            grdcredit.DataBind();
            grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
            grddebit.DataBind();
        }


        protected void btnback_Click(object sender, EventArgs e)
        {
            if (btnback.ToolTip == "Cancel")
            {
                lbl_txt.Visible = false;
                lbl_appr.Visible = false;
                txtclear();
                ddlTypes.SelectedValue = "0";
                //if (lbl_Header.Text == "OSSI")
                //{
                //    ddlTypes.Items.FindByText("OSSI").Selected = true;
                //}
                //else if (lbl_Header.Text == "OSPI")
                //{
                //    ddlTypes.Items.FindByText("OSPI").Selected = true;
                //}
              btnback.Text = "Back";

                btnback.ToolTip = "Back";
                btnback1.Attributes["class"] = "btn ico-back";

            }
            else
            {
               // this.Response.End();

                if (Session["StrTranType"] != null)
                {
                    if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "OPS&DOC")
                        {
                            //if (Session["StrTranType"].ToString() == "FE")
                            //{
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            //}
                        }
                    }
                }



            }
        }

        protected void btn_uploadpopup_Click(object sender, EventArgs e)
        {
            if (txtdcn.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_uploadpopup, typeof(Button), "Checklist", "alertify.alert('Kindly Enter the Reference # ');", true);
                txtdcn.Focus();
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


            if (txtdcn.Text != "")
            {
                string vouno;
                DataTable dt = new DataTable();
                // HdnJobNo.Value = "0";
                dt = appobj.view_invoicecnops(Convert.ToInt32(txtdcn.Text), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtyear.Text), ddlTypes.SelectedItem.Text);
                ViewState["dt"] = dt;
                if (ViewState["dt"] != null)
                {
                    DataTable dt1 = (DataTable)ViewState["dt"];
                    for (int k = 0; k < dt1.Rows.Count; k++)
                    {
                        refno = dt1.Rows[k]["refno"].ToString();
                        vouno = dt1.Rows[k]["vouno"].ToString();
                        Session["vouno"] = vouno;
                    }
                }

            }
            Session["txtjobno"] = txtJobno.Text;
            Session["hf_txtrefno"] = refno;
        }
        protected void txtJobno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //PROFORMAFTERJOBCLOSED
                
                if (Request.QueryString.ToString().Contains("ddlprod"))
                {
                    strtrantype = Request.QueryString["ddlprod"].ToString();
                }
                else
                {
                    strtrantype = Session["StrTranType"].ToString();
                }
                //
                //strtrantype = Session["StrTranType"].ToString();
                debittotal = 0;
                credittotal = 0;
                total = 0.0;
                DataSet ds = new DataSet();
                lbl.Text = "";
                ds = OSDNCN.RptOSDNCNFromJobNo(strtrantype, Convert.ToInt32(txtJobno.Text), branchid);
                if (ds.Tables.Count > 0)
                {
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
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Voucher #');", true);
                            txtclear();
                            return;
                        }
                    }


                    dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        jobno = Convert.ToInt32(dt.Rows[0][4].ToString());
                        txtcustomer.Text = dt.Rows[0][0].ToString() + Environment.NewLine + dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                        if (strtrantype == "FE" || strtrantype == "FI")
                        {
                            txtshipment.Text = "Job # : " + jobno + Environment.NewLine + "Vessel / Voyage  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                            blno = dt.Rows[0][7].ToString();
                        }
                        else
                        {
                            txtshipment.Text = "Job # : " + jobno + Environment.NewLine + "Flight # / Date  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                            blno = dt.Rows[0][7].ToString();
                        }

                        //DataTable dtdc = new DataTable();
                        //dtdc = ds.Tables[1];
                        //grddebit.DataSource = dtdc;
                        //grddebit.DataBind();
                        //DataTable dtcc = new DataTable();
                        //dtcc = ds.Tables[2];
                        //grdcredit.DataSource = dtcc;
                        //grdcredit.DataBind();
                        double amt = 0, amt1 = 0, amt2 = 0;
                        DataTable dtdc = new DataTable();
                        // dtdc = ds.Tables[1];
                        //grddebit.DataSource = dtdc;
                        //grddebit.DataBind();
                        DataTable dtcc = new DataTable();
                        //dtcc = ds.Tables[2];
                        //grdcredit.DataSource = dtcc;
                        //grdcredit.DataBind();
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

                                    Total = Total + double.Parse(dtdc.Rows[i]["amount"].ToString());
                                }
                            }
                            grddebit.DataSource = dtempty;
                            grddebit.DataBind();
                            if (grddebit.Rows.Count > 0)
                            {
                                double tot = 0, tot1 = 0;
                                for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                                {
                                    tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[8].Text);
                                    tot = tot + tot1;
                                }
                                txt_total.Text = tot.ToString("#,0.00");
                            } 
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

                                    Total = Total + double.Parse(dtnew.Rows[i]["amount"].ToString());
                                }
                            }
                            grdcredit.DataSource = dtempty1;
                            grdcredit.DataBind();
                            if (grdcredit.Rows.Count > 0)
                            {
                                double tot = 0, tot1 = 0;
                                for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                                {
                                    tot1 = Convert.ToDouble(grdcredit.Rows[i].Cells[8].Text);
                                    tot = tot + tot1;
                                }
                                txttotal.Text = tot.ToString("#,0.00");
                            } 
                        }





                      btnback.Text = "Cancel";

                        btnback.ToolTip = "Cancel";
                        btnback1.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {
                        txtclear();
                        return;
                    }

                    if (grddebit.Rows.Count != 0)
                    {
                        for (i = 0; i < grddebit.Rows.Count; i++)
                        {
                            debittotal = debittotal + System.Convert.ToDouble(grddebit.Rows[i].Cells[8].Text);
                        }
                    }
                    if (grdcredit.Rows.Count != 0)
                    {
                        for (i = 0; i < grdcredit.Rows.Count; i++)
                        {
                            credittotal = credittotal + System.Convert.ToDouble(grdcredit.Rows[i].Cells[8].Text);
                        }
                    }



                    if ((grddebit.Rows.Count > 0) && (grdcredit.Rows.Count == 0))
                    {
                        for (i = 0; i < grddebit.Rows.Count; i++)
                        {
                            total = total + System.Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);
                        }
                    }
                    else if ((grdcredit.Rows.Count > 0) && (grddebit.Rows.Count == 0))
                    {
                        for (i = 0; i < grdcredit.Rows.Count; i++)
                        {
                            total = total + System.Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);
                        }
                    }

                    total = System.Convert.ToDouble(debittotal) - System.Convert.ToDouble(credittotal);
                  //  txttotal.Text = String.Format("{0:F2}", total);

                    DataTable dtd = new DataTable();
                    dtd = OSDNCN.GetOSDCNDtls(Convert.ToInt32(txtJobno.Text), strtrantype, "OSSI", branchid);

                    if (dtd.Rows.Count > 0)
                    {
                        lbl.Text = "Debit Note";
                    }
                    else
                    {
                        dtd = OSDNCN.GetOSDCNDtls(Convert.ToInt32(txtJobno.Text), strtrantype, "OSPI", branchid);
                        if (dtd.Rows.Count > 0)
                        {
                            lbl.Text = "Credit Note";
                        }
                    }

                    if (dtd.Rows.Count > 0)
                    {
                        txtdcn.Text = dtd.Rows[0][0].ToString();
                        txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();
                        if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                        {
                            txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                        txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                        if (dtd.Rows[0]["fatransfer"].ToString() == "")
                        {
                            //btnview.Text = "Save";
                            //btnview.Enabled = true;
                        }
                        else
                        {
                            // btnview.Enabled = false;
                        }


                        if (!string.IsNullOrEmpty(dtd.Rows[0]["preparedbyname"].ToString()))
                        {
                            lbl_txt.Visible = true;
                            lbl_prepare.Text = dtd.Rows[0]["preparedbyname"].ToString();
                        }

                        if (!string.IsNullOrEmpty(dtd.Rows[0]["approvedbyname"].ToString()))
                        {
                            lbl_txt.Visible = true;
                            lbl_appr.Visible = true;
                            lbl_Approve.Text = dtd.Rows[0]["approvedbyname"].ToString();
                        }
                    }
                    else
                    {
                        //btnview.Text = "Save";
                        //btnview.Enabled = true;
                        txtdcn.Text = "";
                    }
                    btnback.Text = "Cancel";

                    btnback.ToolTip = "Cancel";
                    btnback1.Attributes["class"] = "btn ico-cancel";
                    //}


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Transfered');", true);
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

       /* protected void btnview_Click(object sender, EventArgs e)
        {
            string str_sf = "", str_sf1 = "";
            string str_sp = "", str_sp1 = "";
            string str_RptName = "", str_RptName1 = "";
            string str_frmname = "", str_frmname1 = "";
            string str_Script = "";
            string str_Script1 = "";
            string str_Script2 = "", str_trantype;

            DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();



            if (txtdcn.Text.ToString() != "")
            {
                string sp = null;
                string Fcurr = "";
                string vou = "";
                string Fcurr1 = "";
                str_trantype = Session["StrTranType"].ToString();

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
                Fcurr = da_obj_OSDNCN.GetCurrOSDCN(Convert.ToInt32(txtJobno.Text), Convert.ToString(str_trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                //}
                //else
                //{
                Fcurr1 = da_obj_OSDNCN.GetCurrOSDCN(Convert.ToInt32(txtJobno.Text), Convert.ToString(str_trantype), "C", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                //}
                str_sp = "FCurr=" + Fcurr;
                str_sp1 = "FCurr=" + Fcurr1;
                //if (!string.IsNullOrEmpty(txtdcn.Text))
                //{
                //    if (vou == "OSSI")
                //    {
                //        if (str_trantype == "FE")
                //        {
                //            str_RptName = "FEOSDN.rpt";
                //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(str_trantype) + "\" and {OSDN.dnno}=" + Convert.ToString(txtdcn.Text) + " and {OSDN.branchid}=" + branchid + " and {OSDN.vouyear}=" + Convert.ToString(txtyear.Text);
                //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true); 
                //            Session["str_sfs"] = str_sf;
                //            Session["str_sp"] = str_sp;
                //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                //        }

                //    }
                //    else
                //    {
                //        if (str_trantype == "FE")
                //        {
                //            //str_frmname = "OSPI";
                //            str_RptName = "FEOSCN.rpt";
                //            str_sf = "{OSCN.trantype}=\"" + Convert.ToString(str_trantype) + "\"' and {OSCN.cnno}=" + Convert.ToString(txtdcn.Text) + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {OSCN.vouyear}=" + Convert.ToString(txtyear.Text);
                //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                //            Session["str_sfs"] = str_sf;
                //            Session["str_sp"] = str_sp;
                //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);

                //        }

                //    }

                //    if (vou == "OSSI")
                //    {
                //        if (str_trantype == "AE")
                //        {
                //            str_frmname = "OSSI";
                //            str_RptName = "AEOSDN.rpt";
                //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(str_trantype) + "\" and {OSDN.dnno}=" + Convert.ToString(txtdcn.Text) + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {OSDN.vouyear}=" + Convert.ToString(txtyear.Text);
                //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                //            Session["str_sfs"] = str_sf;
                //            Session["str_sp"] = str_sp;
                //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                //        }
                //        else if (str_trantype == "AI")
                //        {
                //            str_frmname = "OSSI";
                //            str_RptName = "AIOSDN.rpt";
                //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(str_trantype) + "\" and {OSDN.dnno}=" + Convert.ToString(txtdcn.Text) + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {OSDN.vouyear}=" + Convert.ToString(txtyear.Text);
                //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true); 
                //            Session["str_sfs"] = str_sf;
                //            Session["str_sp"] = str_sp;
                //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                //        }
                //    }
                //    else
                //    {
                //        if (str_trantype == "AE")
                //        {
                //            str_frmname = "OSPI";
                //            str_RptName = "AEOSCN.rpt";
                //            str_sf = "{OSCN.trantype}=\"" + Convert.ToString(str_trantype) + "\" and {OSCN.cnno}=" + Convert.ToString(txtdcn.Text) + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {OSCN.vouyear}=" + Convert.ToString(txtyear.Text);
                //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                //            Session["str_sfs"] = str_sf;
                //            Session["str_sp"] = str_sp;
                //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                //        }
                //        else if (str_trantype == "AI")
                //        {
                //            str_frmname = "OSPI";
                //            str_RptName = "AIOSCN.rpt";
                //            str_sf = "{OSCN.trantype}=\"" + Convert.ToString(str_trantype) + "\" and {OSCN.cnno}=" + Convert.ToString(txtdcn.Text) + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {OSCN.vouyear}=" + Convert.ToString(txtyear.Text);
                //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                //            Session["str_sfs"] = str_sf;
                //            Session["str_sp"] = str_sp;
                //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                //        }

                //    }

                //    if (vou == "OSSI")
                //    {
                //        if (str_trantype == "FI")
                //        {
                //            str_frmname = "OSSI";
                //            str_RptName = "FIOSDN.rpt";
                //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(str_trantype) + "\" and {OSDN.dnno}=" + Convert.ToString(txtdcn.Text) + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {OSDN.vouyear}=" + Convert.ToString(txtyear.Text);
                //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                //            Session["str_sfs"] = str_sf;
                //            Session["str_sp"] = str_sp;
                //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);

                //        }
                //    }
                //    else
                //    {
                //        if (str_trantype == "FI")
                //        {
                //            str_frmname = "OSPI";
                //            str_RptName = "FIOSCN.rpt";
                //            str_sf = "{OSCN.trantype}=\"" + Convert.ToString(str_trantype) + "\" and {OSCN.cnno}=" + Convert.ToString(txtdcn.Text) + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {OSCN.vouyear}=" + Convert.ToString(txtyear.Text);
                //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                //            Session["str_sfs"] = str_sf;
                //            Session["str_sp"] = str_sp;
                //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);

                //        }

                //    }
                //da_obj_OSDNCN.InsOSDCNAnnexure(Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                //str_RptName1 = "SOA1.rpt";
                //str_sf1 = "{MasterBranch.branchid}=" + branchid;
                //str_sp1 = "module=" + Convert.ToString(str_trantype + "~jobno=" + Convert.ToString(txtJobno.Text) + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count);
                //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                ////str_Script = str_Script1 + ";" + str_Script2;
                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script2, true);
                //Session["str_sfs1"] = str_sf1;
                //Session["str_sp1"] = str_sp1;


                DataTable DTRetve = new DataTable();
                string Vouch1 = "", Vouch2 = "";
                int Ref1 = 0, Ref2 = 0;
                string strTranType = Session["StrTranType"].ToString();


                if (!string.IsNullOrEmpty(txtdcn.Text))
                {
                    DTRetve = DAdvise.getRetriveCnDnNum(Convert.ToString(strTranType), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
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
                                    str_RptName = "FEOSDN.rpt";
                                    str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

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
                                    str_RptName = "FEOSCN.rpt";
                                    str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                }

                            }
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                        }
                        else if (strTranType == "FI")
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
                                    str_RptName = "FIOSDN.rpt";
                                    str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

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
                                    str_RptName = "FIOSCN.rpt";
                                    str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                }

                            }
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
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
                                    str_RptName = "AEOSDN.rpt";
                                    str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

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
                                    str_RptName = "AEOSCN.rpt";
                                    str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                }

                            }
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
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
                                    str_RptName = "AIOSDN.rpt";
                                    str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

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
                                    str_RptName = "AIOSCN.rpt";
                                    str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                }

                            }
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                        }


                        //if (DTRetve.Rows.Count > 0)
                        //{


                        //    DataView dt_check = DTRetve.DefaultView;
                        //    dt_check.RowFilter = "type = 'OSSI'";
                        //    DataTable dtNew_check = dt_check.ToTable();
                        //    if (dtNew_check.Rows.Count > 0)
                        //    {
                        //        Vouch1 = dtNew_check.Rows[0][1].ToString();
                        //        Ref1 = Convert.ToInt32(dtNew_check.Rows[0][0].ToString());
                        //    }

                        //    DataView dt_check1 = DTRetve.DefaultView;
                        //    dt_check1.RowFilter = "type = 'OSPI'";
                        //    DataTable dtNew_check1 = dt_check1.ToTable();
                        //    if (dtNew_check1.Rows.Count > 0)
                        //    {
                        //        Vouch2 = dtNew_check1.Rows[0][1].ToString();
                        //        Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());

                        //    }

                        //    if (strTranType == "FE")
                        //    {
                        //        if (Vouch1 == "OSSI" && Vouch2 == "OSPI")
                        //        {
                        //            // DAdvise.InsTempTableCreditDebit(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));

                        //            //report.strfrmname = "OSSI";
                        //            str_RptName = "FEOSDN.rpt";
                        //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                        //            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                        //            Session["str_sfs"] = str_sf;
                        //            Session["str_sp"] = str_sp;

                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);

                        //            str_RptName = "FEOSCN.rpt";
                        //            str_sf1 = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                        //            str_Script1 = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //            Session["str_sfs1"] = str_sf1;
                        //            Session["str_sp1"] = str_sp1;

                        //            //str_frmname = "SOA";
                        //            //str_RptName1 = "SOA1.rpt";
                        //            //str_sf1 = "{MasterBranch.branchid}=" + Convert.ToInt32(hf_branchid.Value);
                        //            //str_sp1 = "module=" + Convert.ToString(str_trantype) + "~jobno=" + txtJobno.Text + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count;
                        //            //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //            //str_Script = str_Script1 + ";" + str_Script2;
                        //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);

                        //        }
                        //        else
                        //        {
                        //            if (Vouch1 == "OSSI")
                        //            {
                        //                str_RptName = "FEOSDN.rpt";
                        //                str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                        //                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtdcn.Text);
                        //                Session["str_sfs"] = str_sf;
                        //                Session["str_sp"] = str_sp;
                        //                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script, true);
                        //            }
                        //            else
                        //            {
                        //                str_RptName = "FEOSCN.rpt";
                        //                str_sf1 = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;

                        //                str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtdcn.Text + "/" + Convert.ToString(Vouch1));
                        //                Session["str_sfs"] = str_sf1;
                        //                Session["str_sp"] = str_sp1;
                        //                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //                //str_frmname = "SOA";
                        //                //str_RptName1 = "SOA1.rpt";
                        //                //str_sf1 = "{MasterBranch.branchid}=" + Convert.ToInt32(hf_branchid.Value);
                        //                //str_sp1 = "module=" + Convert.ToString(str_trantype) + "~jobno=" + txtJobno.Text + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count;
                        //                //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //                //str_Script = str_Script1 + ";" + str_Script2;
                        //                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                        //            }
                        //        }

                        //    }
                        //    else if (strTranType == "FI")
                        //    {
                        //        if (Vouch1 == "OSSI" && Vouch2 == "OSPI")
                        //        {
                        //            //  DAdvise.InsTempTableCreditDebit(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));

                        //            //report.strfrmname = "OSSI";
                        //            str_RptName = "FIOSDN.rpt";
                        //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                        //            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //            Session["str_sp"] = str_sp;



                        //            str_RptName = "FIOSCN.rpt";
                        //            str_sf1 = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                        //            str_Script1 = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //            Session["str_sfs1"] = str_sf1;
                        //            Session["str_sp1"] = str_sp1;

                        //            //str_frmname = "SOA";
                        //            //str_RptName1 = "SOA1.rpt";
                        //            //str_sf1 = "{MasterBranch.branchid}=" + Convert.ToInt32(hf_branchid.Value);
                        //            //str_sp1 = "module=" + Convert.ToString(str_trantype) + "~jobno=" + txtJobno.Text + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count;
                        //            //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //            //str_Script = str_Script1 + ";" + str_Script2;
                        //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);

                        //        }
                        //        else
                        //        {

                        //            if (Vouch1 == "OSSI")
                        //            {
                        //                str_RptName = "FIOSDN.rpt";
                        //                str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                        //                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //                Session["str_sfs"] = str_sf;
                        //                Session["str_sp"] = str_sp;
                        //                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script, true);
                        //            }
                        //            else
                        //            {
                        //                str_RptName = "FIOSCN.rpt";
                        //                str_sf1 = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                        //                str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //                Session["str_sfs"] = str_sf1;
                        //                Session["str_sp"] = str_sp1;

                        //                //str_frmname = "SOA";
                        //                //str_RptName1 = "SOA1.rpt";
                        //                //str_sf1 = "{MasterBranch.branchid}=" + Convert.ToInt32(hf_branchid.Value);
                        //                //str_sp1 = "module=" + Convert.ToString(str_trantype) + "~jobno=" + txtJobno.Text + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count;
                        //                //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //                //str_Script = str_Script1 + ";" + str_Script2;
                        //                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                        //            }
                        //        }

                        //    }
                        //    else if (strTranType == "AE")
                        //    {
                        //        if (Vouch1 == "OSSI" && Vouch2 == "OSPI")
                        //        {
                        //            // DAdvise.InsTempTableCreditDebit(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));

                        //            //report.strfrmname = "OSSI";
                        //            str_RptName = "AEOSDN.rpt";
                        //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                        //            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //            Session["str_sfs"] = str_sf;
                        //            Session["str_sp"] = str_sp;



                        //            str_RptName = "AEOSCN.rpt";
                        //            str_sf1 = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                        //            str_Script1 = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //             Session["str_sfs1"] = str_sf1;
                        //            Session["str_sp1"] = str_sp1;
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);

                        //            //str_frmname = "SOA";
                        //            //str_RptName1 = "SOA1.rpt";
                        //            //str_sf1 = "{MasterBranch.branchid}=" + Convert.ToInt32(hf_branchid.Value);
                        //            //str_sp1 = "module=" + Convert.ToString(str_trantype) + "~jobno=" + txtJobno.Text + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count;
                        //            //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //            //str_Script = str_Script1 + ";" + str_Script2;
                        //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);

                        //        }

                        //        if (Vouch1 == "OSSI")
                        //        {
                        //            str_RptName = "AEOSDN.rpt";
                        //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                        //            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //            Session["str_sfs"] = str_sf;
                        //            Session["str_sp"] = str_sp;
                        //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script, true);
                        //        }
                        //        else
                        //        {
                        //            str_RptName = "AEOSCN.rpt";
                        //            str_sf1 = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                        //            str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //            Session["str_sfs"] = str_sf1;
                        //            Session["str_sp"] = str_sp1;

                        //            //str_frmname = "SOA";
                        //            //str_RptName1 = "SOA1.rpt";
                        //            //str_sf1 = "{MasterBranch.branchid}=" + Convert.ToInt32(hf_branchid.Value);
                        //            //str_sp1 = "module=" + Convert.ToString(str_trantype) + "~jobno=" + txtJobno.Text + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count;
                        //            //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //            //str_Script = str_Script1 + ";" + str_Script2;
                        //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                        //        }

                        //    }
                        //    else if (strTranType == "AI")
                        //    {
                        //        if (Vouch1 == "OSSI" && Vouch2 == "OSPI")
                        //        {
                        //            // DAdvise.InsTempTableCreditDebit(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));

                        //            //report.strfrmname = "OSSI";
                        //            str_RptName = "AIOSDN.rpt";
                        //            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                        //            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //            Session["str_sfs"] = str_sf;
                        //            Session["str_sp"] = str_sp;



                        //            str_RptName = "AIOSCN.rpt";
                        //            str_sf1 = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                        //            str_Script1 = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //            Session["str_sfs1"] = str_sf1;
                        //            Session["str_sp1"] = str_sp1;

                        //            //str_frmname = "SOA";
                        //            //str_RptName1 = "SOA1.rpt";
                        //            //str_sf1 = "{MasterBranch.branchid}=" + Convert.ToInt32(hf_branchid.Value);
                        //            //str_sp1 = "module=" + Convert.ToString(str_trantype) + "~jobno=" + txtJobno.Text + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count;
                        //            //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //            //str_Script = str_Script1 + ";" + str_Script2;
                        //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);

                        //        }
                        //        else
                        //        {

                        //            if (Vouch1 == "OSSI")
                        //            {
                        //                str_RptName = "AIOSDN.rpt";
                        //                str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                        //                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //                Session["str_sfs"] = str_sf;
                        //                Session["str_sp"] = str_sp;
                        //                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script, true);
                        //            }
                        //            else
                        //            {
                        //                str_RptName = "AIOSCN.rpt";
                        //                str_sf1 = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                        //                str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txtJobno.Text);
                        //                Session["str_sfs"] = str_sf1;
                        //                Session["str_sp"] = str_sp1;

                        //                //str_frmname = "SOA";
                        //                //str_RptName1 = "SOA1.rpt";
                        //                //str_sf1 = "{MasterBranch.branchid}=" + Convert.ToInt32(hf_branchid.Value);
                        //                //str_sp1 = "module=" + Convert.ToString(str_trantype) + "~jobno=" + txtJobno.Text + "~drow=" + grddebit.Rows.Count + "~crow=" + grdcredit.Rows.Count;
                        //                //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //                //str_Script = str_Script1 + ";" + str_Script2;
                        //                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "OS DN/CN", str_Script1, true);
                        //            }
                        //        }


                    }
                    else
                    {
                        string message = "OSDN/CN has not been raised for this Job";
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }

                }
            }
        }
        */
        protected void btnview_Click(object sender, EventArgs e)
        {
            string str_sf = "", str_sf1 = "";
            string str_sp = "", str_sp1 = "";
            string str_RptName = "", str_RptName1 = "";
            string str_frmname = "", str_frmname1 = "";
            string str_Script = "";
            string str_Script1 = "";
            string str_Script2 = "", str_trantype;

            //DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
            DateTime get_date;

            if (txtdcn.Text.ToString() != "")
            {
                string sp = null;
                string Fcurr = "";
                string vou = "";
                string Fcurr1 = "";
                str_trantype = Session["OStrTranType"].ToString();

                

                DataTable DTRetve = new DataTable();
                string Vouch1 = "", Vouch2 = "";
                int Ref1 = 0, Ref2 = 0;
                string strTranType = Session["OStrTranType"].ToString();
                DataTable dttp = new DataTable();
                DataTable dtp = new DataTable();
                if (!string.IsNullOrEmpty(txtdcn.Text))
                {
                    DTRetve = DAdvise.getRetriveCnDnNum_new(Session["OStrTranType"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtdcn.Text), Convert.ToInt32(txtyear.Text));
                    if (DTRetve.Rows.Count > 0)
                    {
                        if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "OE")
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
                                    dttp = da_obj_OSDNCN.GetCurrOSDCN1OSV(Convert.ToInt32(txtJobno.Text), Session["OStrTranType"].ToString(), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref1);
                                    if (dttp.Rows.Count > 0)
                                    {
                                        for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                        {
                                            Fcurr = dttp.Rows[c]["curr"].ToString();
                                            str_sp = "FCurr=" + Fcurr;
                                            str_RptName = "FEOSDN.rpt";
                                            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                        }
                                        if (get_date >= GST_date)
                                        {
                                            str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                        else
                                        {
                                            str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                    }

                                    
                                }

                            }

                            DataView dt_check1 = DTRetve.DefaultView;
                            dt_check1.RowFilter = "type = 'OSPI'";
                            DataTable dtNew_check1 = dt_check1.ToTable();

                            if (dtNew_check1.Rows.Count > 0)
                            {
                                 
                                for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                                {
                                    Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                    Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                    get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                    dtp = da_obj_OSDNCN.GetCurrOSDCN1OSV(Convert.ToInt32(txtJobno.Text), Session["OStrTranType"].ToString(), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref2);
                                    if (dtp.Rows.Count > 0)
                                    {
                                        for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                        {
                                            Fcurr1 = dtp.Rows[c]["curr"].ToString();

                                            str_sp1 = "FCurr=" + Fcurr1;
                                            str_RptName = "FEOSCN.rpt";
                                            str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;

                                        }
                                        if (get_date >= GST_date)
                                        {
                                            str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                        else
                                        {
                                            str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                    }

                                    
                                }

                            }
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                        }
                        else if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "OI")
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
                                    dttp = da_obj_OSDNCN.GetCurrOSDCN1OSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(str_trantype), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref1);
                                    if (dttp.Rows.Count > 0)
                                    {
                                        for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                        {
                                            Fcurr = dttp.Rows[c]["curr"].ToString();
                                            str_sp = "FCurr=" + Fcurr;
                                            str_RptName = "FIOSDN.rpt";
                                            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                        }
                                        if (get_date >= GST_date)
                                        {
                                            str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                        else
                                        {
                                            str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                    }



                                    //str_RptName = "FIOSDN.rpt";
                                    //str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                    //str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

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
                                    dtp = da_obj_OSDNCN.GetCurrOSDCN1OSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(str_trantype), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref2);
                                    if (dtp.Rows.Count > 0)
                                    {
                                        for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                        {
                                            Fcurr1 = dtp.Rows[c]["curr"].ToString();

                                            str_sp1 = "FCurr=" + Fcurr1;
                                            str_RptName = "FIOSCN.rpt";
                                            str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;

                                        }
                                        if (get_date >= GST_date)
                                        {
                                            str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                        else
                                        {
                                            str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                    }

                                    //str_RptName = "FIOSCN.rpt";
                                    //str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                    //str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                }

                            }
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
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
                                    dttp = da_obj_OSDNCN.GetCurrOSDCN1OSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(str_trantype), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref1);
                                    if (dttp.Rows.Count > 0)
                                    {
                                        for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                        {
                                            Fcurr = dttp.Rows[c]["curr"].ToString();
                                            str_sp = "FCurr=" + Fcurr;
                                            str_RptName = "AEOSDN.rpt";
                                            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                        }
                                        if (get_date >= GST_date)
                                        {
                                            str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                        else
                                        {
                                            str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                    }

                                    
                                }

                            }

                            DataView dt_check1 = DTRetve.DefaultView;
                            dt_check1.RowFilter = "type = 'OSPI'";
                            DataTable dtNew_check1 = dt_check1.ToTable();
                            if (dtNew_check1.Rows.Count > 0)
                            {
                                
                                for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                                {
                                    Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                    Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                    get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                    dtp = da_obj_OSDNCN.GetCurrOSDCN1OSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(str_trantype), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref2);
                                    if (dtp.Rows.Count > 0)
                                    {
                                        for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                        {
                                            Fcurr1 = dtp.Rows[c]["curr"].ToString();

                                            str_sp1 = "FCurr=" + Fcurr1;
                                            str_RptName = "AEOSCN.rpt";
                                            str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;

                                        }
                                        if (get_date >= GST_date)
                                        {
                                            str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                        else
                                        {
                                            str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                    }

                                     
                                }

                            }
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
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
                                    dttp = da_obj_OSDNCN.GetCurrOSDCN1OSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(str_trantype), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref1);
                                    if (dttp.Rows.Count > 0)
                                    {
                                        for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                        {
                                            Fcurr = dttp.Rows[c]["curr"].ToString();
                                            str_sp = "FCurr=" + Fcurr;
                                            str_RptName = "AIOSDN.rpt";
                                            str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.dnno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                        }
                                        if (get_date >= GST_date)
                                        {
                                            str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                        else
                                        {
                                            str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        }
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
                                    dtp = da_obj_OSDNCN.GetCurrOSDCN1OSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(str_trantype), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref2);
                                    if (dtp.Rows.Count > 0)
                                    {
                                        for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                        {
                                            Fcurr1 = dtp.Rows[c]["curr"].ToString();

                                            str_sp1 = "FCurr=" + Fcurr1;
                                            str_RptName = "AIOSCN.rpt";
                                            str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.cnno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;

                                        }
                                        if (get_date >= GST_date)
                                        {
                                            str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                        else
                                        {
                                            str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        }
                                    }
                                  
                                }

                            }
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                        }


                        
                        if (lbl_Header.Text == "OSSI")
                        {
                            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10006, 3, Convert.ToInt32(Session["LoginBranchid"]),"OSDN # -" + txtdcn.Text + "/ Year-" + txtyear.Text + "/ " + Session["StrTranType"].ToString() + "/ Job # -" + txtJobno.Text  + " /Viewed" );
                        }
                        else if (lbl_Header.Text == "OSPI")
                        {
                            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10007, 3, Convert.ToInt32(Session["LoginBranchid"]),"OSCN # -" + txtdcn.Text + "/ Year-" + txtyear.Text + "/ " + Session["StrTranType"].ToString() + "/ Job # -" + txtJobno.Text + " /Viewed");
                        }


                    }
                    else
                    {
                        string message = "OSDN/CN has not been raised for this Job";
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }

                }
            }
        }

        protected void txtdcn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lstagnst.Items.Clear();
                lstcon.Items.Clear();
                lstvol.Items.Clear();

                if (ddlTypes.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DataFound", "alertify.alert('Type Cannot be blank');", true);
                    ddlTypes.Focus();
                    return;
                }

                if (txtdcn.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DataFound", "alertify.alert('Ref # cannot be blank');", true);
                    txtdcn.Focus();
                    return;
                }

                if (ddl_branch.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "OSDN/OSCN", "alertify.alert('Branch cannot be blank');", true);
                    ddl_branch.Focus();
                    return;
                }
                branchid = Convert.ToInt32(hid_branch.Value);
                DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtdcn.Text), "", lbl_Header.Text, Convert.ToInt32(txtyear.Text), branchid);
                //if (Session["StrTranType"].ToString() == "AC")
                //{
                //    if (DtSHead.Rows[0]["trantype"].ToString()=="OE")
                //    {
                //        Session["StrTranType"] = "FE";

                //    }
                //    else if (DtSHead.Rows[0]["trantype"].ToString() == "OI")
                //    {
                //        Session["StrTranType"] = "FI";
                //    }
                //    else
                //    {
                //        Session["StrTranType"] = DtSHead.Rows[0]["trantype"].ToString();
                //    }


                //}

                if (Session["StrTranType"].ToString() != DtSHead.Rows[0]["trantype"].ToString())
                {
                    Session["Ostrtrantype"] = DtSHead.Rows[0]["trantype"].ToString();
                    if (DtSHead.Rows[0]["trantype"].ToString() == "OE")
                    {
                        Session["StrTranType"] = "FE";
                        Session["Ostrtrantype"] = "OE";
                    }
                    else if (DtSHead.Rows[0]["trantype"].ToString() == "OI")
                    {
                        Session["StrTranType"] = "FI";
                        Session["Ostrtrantype"] = "OI";
                    }
                    else
                    {
                        Session["StrTranType"] = DtSHead.Rows[0]["trantype"].ToString();
                    }
                }
                else
                {
                    if (Session["StrTranType"].ToString() == "" || Session["StrTranType"].ToString() == "AC" || Session["StrTranType"].ToString() == "FC" || Session["StrTranType"].ToString() == "CO")
                    {
                        Session["Ostrtrantype"] = DtSHead.Rows[0]["trantype"].ToString();
                        if (DtSHead.Rows[0]["trantype"].ToString() == "OE")
                        {
                            Session["StrTranType"] = "FE";
                            Session["Ostrtrantype"] = "OE";
                        }
                        else if (DtSHead.Rows[0]["trantype"].ToString() == "OI")
                        {
                            Session["StrTranType"] = "FI";
                            Session["Ostrtrantype"] = "OI";
                        }
                        else
                        {
                            Session["StrTranType"] = DtSHead.Rows[0]["trantype"].ToString();
                        }
                    }
                }
                

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

                  //  strtrantype = DtSHead.Rows[0]["trantype"].ToString();
                    if (strtrantype == "FE")
                    {
                        txtModule.Text = "Ocean Exports";
                    }
                    else if (strtrantype == "FI")
                    {
                        txtModule.Text = "Ocean Imports";
                    }
                    else if (strtrantype == "AE")
                    {
                        txtModule.Text = "Air Exports";
                    }
                    else if (strtrantype == "AI")
                    {
                        txtModule.Text = "Air Imports";
                    }
                    else if (strtrantype == "CH")
                    {
                        txtModule.Text = "Custom House Agent";
                    }
                    strtrantype = Session["strtrantype"].ToString();
                    if (strtrantype == "FE")
                    {
                        Session["Ostrtrantype"] = "OE";
                    }
                    else if (strtrantype == "FI")
                    {
                        Session["Ostrtrantype"] = "OI";
                    }
                    else
                    {
                        Session["Ostrtrantype"] = strtrantype;
                    }
                }
                else if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC" || Hid_HeadTrantype.Value == "AC")
                {
                    strtrantype = DtSHead.Rows[0]["trantype"].ToString();
                    if (strtrantype == "FE")
                    {
                        txtModule.Text = "Ocean Exports";
                    }
                    else if (strtrantype == "FI")
                    {
                        txtModule.Text = "Ocean Imports";
                    }
                    else if (strtrantype == "AE")
                    {
                        txtModule.Text = "Air Exports";
                    }
                    else if (strtrantype == "AI")
                    {
                        txtModule.Text = "Air Imports";
                    }
                    else if (strtrantype == "CH")
                    {
                        txtModule.Text = "Custom House Agent";
                    }
                }

                debittotal = 0;
                credittotal = 0;
                total = 0.0;
                FCTotal = 0.0;
                DataSet ds = new DataSet();
                lbl.Text = "";
                //ds = OSDNCN.GetParticularRefNoDetails(strtrantype, Convert.ToInt32(txtdcn.Text), branchid, ddlTypes.SelectedValue);
                //25-05-2021
                ds = OSDNCN.GetParticularRefNoDetailsOSV(Session["Ostrtrantype"].ToString(), Convert.ToInt32(txtdcn.Text), branchid, Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txtyear.Text));
                if (ds.Tables.Count > 0)
                {

                    if (ddlTypes.SelectedValue == "5")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Voucher #');", true);
                            txtclear();
                            return;
                        }

                    }
                    else if (ddlTypes.SelectedValue == "6")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Voucher #');", true);
                            txtclear();
                            return;
                        }

                    }

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
                    //}

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }

                    if (dt.Rows.Count != 0)
                    {
                        jobno = Convert.ToInt32(dt.Rows[0][4].ToString());
                        txtJobno.Text = jobno.ToString();
                        txtcustomer.Text = dt.Rows[0][0].ToString() + Environment.NewLine + dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                        if (strtrantype == "FE" || strtrantype == "FI" || strtrantype == "OE" || strtrantype == "OI")
                        {
                            txtshipment.Text = "Job # : " + jobno + Environment.NewLine + "Vessel / Voyage  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                        }
                        else
                        {
                            txtshipment.Text = "Job # : " + jobno + Environment.NewLine + "Flight # / Date  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                        }

                        //DataTable dtdc = new DataTable();
                        //dtdc = ds.Tables[1];
                        //grddebit.DataSource = dtdc;
                        //grddebit.DataBind();
                        //DataTable dtcc = new DataTable();
                        //dtcc = ds.Tables[2];
                        //grdcredit.DataSource = dtcc;
                        //grdcredit.DataBind();
                        double amt = 0, amt1 = 0, amt2 = 0;
                        DataTable dtdc = new DataTable();
                        DataTable dtdc1 = new DataTable();
                        // dtdc = ds.Tables[1];
                        //grddebit.DataSource = dtdc;
                        //grddebit.DataBind();
                        DataTable dtcc = new DataTable();
                        DataTable dtcc1 = new DataTable();
                        //dtcc = ds.Tables[2];
                        //grdcredit.DataSource = dtcc;
                        //grdcredit.DataBind();
                        if (ddlTypes.SelectedValue == "OSSI")
                        {

                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                dtdc = ds.Tables[1];
                            }

                            if (dtdc.Rows.Count > 0)
                            {
                                double Total = 0;
                                FCTotal = 0;
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
                                dtempty.Columns.Add("fcamt", typeof(string));

                                DataRow dr = dtempty.NewRow();

                                if (dtdc.Rows.Count > 0)
                                {
                                    dr = dtempty.NewRow();
                                    dtempty.Rows.Add(dr);
                                    dr[0] = "Receivable";
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
                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString());
                                            dr[10] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[10] = "0.00";
                                        }

                                        if (dtdc.Rows[i]["blno"].ToString() != "Receivable" && dtdc.Rows[i]["blno"].ToString() != "Payable")
                                        {
                                            Total = Total + double.Parse(dtdc.Rows[i]["amount"].ToString());
                                        }
                                        if (dtdc.Rows[i]["blno"].ToString() != "Receivable" && dtdc.Rows[i]["blno"].ToString() != "Payable")
                                        {
                                            FCTotal = FCTotal + double.Parse(dtdc.Rows[i]["fcamt"].ToString());
                                        }
                                    }

                                    dr = dtempty.NewRow();
                                    dtempty.Rows.Add(dr);
                                    dr[7] = "Receivable Total";
                                    dr[10] = FCTotal.ToString("#0.00");
                                    dr[8] = Total.ToString("#0.00");
                                }

                                
                                

                                if (ds.Tables[2].Rows.Count > 0)
                                {
                                    dtdc1 = ds.Tables[2];
                                }
                                if (dtdc1.Rows.Count > 0)
                                {
                                    dr = dtempty.NewRow();
                                    dtempty.Rows.Add(dr);
                                    dr[0] = "Payable";
                                    for (int i = 0; i <= dtdc1.Rows.Count - 1; i++)
                                    {
                                        
                                        dr = dtempty.NewRow();
                                        dtempty.Rows.Add(dr);
                                        dr[0] = dtdc1.Rows[i]["blno"].ToString();
                                        dr[1] = dtdc1.Rows[i]["CHARgename"].ToString();
                                        dr[2] = dtdc1.Rows[i]["curr"].ToString();
                                        dr[3] = dtdc1.Rows[i]["rate"].ToString();
                                        dr[4] = dtdc1.Rows[i]["exrate"].ToString();
                                        dr[5] = dtdc1.Rows[i]["bAse"].ToString();

                                        if (string.IsNullOrEmpty(dtdc1.Rows[i]["withoutgstAmt"].ToString()) != true)
                                        {
                                            amt = Convert.ToDouble(dtdc1.Rows[i]["withoutgstAmt"].ToString());
                                            dr[6] = amt.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[6] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtdc1.Rows[i]["stgst"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtdc1.Rows[i]["stgst"].ToString());
                                            dr[7] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[7] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtdc1.Rows[i]["amount"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtdc1.Rows[i]["amount"].ToString());
                                            dr[8] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[8] = "0.00";
                                        }
                                        dr[9] = dtdc1.Rows[i]["chargeid"].ToString();
                                        if (string.IsNullOrEmpty(dtdc1.Rows[i]["fcamt"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtdc1.Rows[i]["fcamt"].ToString());
                                            dr[10] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[10] = "0.00";
                                        }

                                        if (dtdc1.Rows[i]["blno"].ToString() != "Receivable" && dtdc1.Rows[i]["blno"].ToString() != "Payable")
                                        {
                                            Total = Total + double.Parse(dtdc1.Rows[i]["amount"].ToString());
                                        }
                                        if (dtdc1.Rows[i]["blno"].ToString() != "Receivable" && dtdc1.Rows[i]["blno"].ToString() != "Payable")
                                        {
                                            FCTotal = FCTotal + double.Parse(dtdc1.Rows[i]["fcamt"].ToString());
                                        }
                                    }

                                    dr = dtempty.NewRow();
                                    dtempty.Rows.Add(dr);
                                    dr[7] = "Payable Total";
                                    dr[10] = FCTotal.ToString("#0.00");
                                    dr[8] = Total.ToString("#0.00");
                                }

                                
                                grddebit.DataSource = dtempty;
                                grddebit.DataBind();
                                //if (grddebit.Rows.Count > 0)
                                //{
                                //    double tot = 0, tot1 = 0;
                                //    for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                                //    {
                                //        tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[8].Text);
                                //        tot = tot + tot1;
                                //    }
                                //    txt_total.Text = tot.ToString("#,0.00");
                                //} 
                            }
                        }
                        else
                        {
                            DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
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
                                dtempty1.Columns.Add("fcamt", typeof(string));

                                DataRow dr = dtempty1.NewRow();

                                if (dtnew.Rows.Count > 0)
                                {
                                    dr = dtempty1.NewRow();
                                    dtempty1.Rows.Add(dr);
                                    dr[0] = "Payable";
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
                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString());
                                            dr[10] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[10] = "0.00";
                                        }

                                        if (dtnew.Rows[i]["blno"].ToString() != "Receivable" && dtnew.Rows[i]["blno"].ToString() != "Payable")
                                        {
                                            Total = Total + double.Parse(dtnew.Rows[i]["amount"].ToString());
                                        }
                                        if (dtnew.Rows[i]["blno"].ToString() != "Receivable" && dtnew.Rows[i]["blno"].ToString() != "Payable")
                                        {
                                            FCTotal = FCTotal + double.Parse(dtnew.Rows[i]["fcamt"].ToString());
                                        }
                                    }

                                    dr = dtempty1.NewRow();
                                    dtempty1.Rows.Add(dr);
                                    dr[7] = "Payable Total";
                                    dr[10] = FCTotal.ToString("#0.00");
                                    dr[8] = Total.ToString("#0.00");
                                }

                                
                                if (ds.Tables[2].Rows.Count > 0)
                                {
                                    dtnew1 = ds.Tables[2];
                                }
                                if (dtnew1.Rows.Count > 0)
                                {
                                    dr = dtempty1.NewRow();
                                    dtempty1.Rows.Add(dr);
                                    dr[0] = "Receivable";
                                    for (int i = 0; i <= dtnew1.Rows.Count - 1; i++)
                                    {
                                        
                                        dr = dtempty1.NewRow();
                                        dtempty1.Rows.Add(dr);
                                        dr[0] = dtnew1.Rows[i]["blno"].ToString();
                                        dr[1] = dtnew1.Rows[i]["CHARgename"].ToString();
                                        dr[2] = dtnew1.Rows[i]["curr"].ToString();
                                        dr[3] = dtnew1.Rows[i]["rate"].ToString();
                                        dr[4] = dtnew1.Rows[i]["exrate"].ToString();
                                        dr[5] = dtnew1.Rows[i]["bAse"].ToString();

                                        if (string.IsNullOrEmpty(dtnew1.Rows[i]["withoutgstAmt"].ToString()) != true)
                                        {
                                            amt = Convert.ToDouble(dtnew1.Rows[i]["withoutgstAmt"].ToString());
                                            dr[6] = amt.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[6] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtnew1.Rows[i]["stgst"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtnew1.Rows[i]["stgst"].ToString());
                                            dr[7] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[7] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtnew1.Rows[i]["amount"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtnew1.Rows[i]["amount"].ToString());
                                            dr[8] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[8] = "0.00";
                                        }
                                        dr[9] = dtnew1.Rows[i]["chargeid"].ToString();
                                        if (string.IsNullOrEmpty(dtnew1.Rows[i]["fcamt"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtnew1.Rows[i]["fcamt"].ToString());
                                            dr[10] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[10] = "0.00";
                                        }

                                        if (dtnew1.Rows[i]["blno"].ToString() != "Receivable" && dtnew1.Rows[i]["blno"].ToString() != "Payable")
                                        {
                                            Total = Total + double.Parse(dtnew1.Rows[i]["amount"].ToString());
                                        }
                                        if (dtnew1.Rows[i]["blno"].ToString() != "Receivable" && dtnew1.Rows[i]["blno"].ToString() != "Payable")
                                        {
                                            FCTotal = FCTotal + double.Parse(dtnew1.Rows[i]["fcamt"].ToString());
                                        }
                                    }

                                    dr = dtempty1.NewRow();
                                    dtempty1.Rows.Add(dr);
                                    dr[7] = "Receivable Total";
                                    dr[10] = FCTotal.ToString("#0.00");
                                    dr[8] = Total.ToString("#0.00");
                                }

                                grddebit.DataSource = dtempty1;
                                grddebit.DataBind();
                                //if (grddebit.Rows.Count > 0)
                                //{
                                //    double tot = 0, tot1 = 0;
                                //    for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                                //    {
                                //        tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[8].Text);
                                //        tot = tot + tot1;
                                //    }
                                //    txt_total.Text = tot.ToString("#,0.00");
                                //} 
                            }
                        }
                       btnback.Text = "Cancel";

                        btnback.ToolTip = "Cancel";
                        btnback1.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Ref #');", true);
                        txtclear();
                        txtdcn.Focus();
                        txtdcn.Text = "";
                        return;
                    }

                    /*if (grddebit.Rows.Count != 0)
                    {
                        for (i = 0; i < grddebit.Rows.Count; i++)
                        {
                            debittotal = debittotal + System.Convert.ToDouble(grddebit.Rows[i].Cells[8].Text);
                        }
                    }
                    if (grdcredit.Rows.Count != 0)
                    {
                        for (i = 0; i < grdcredit.Rows.Count; i++)
                        {
                            credittotal = credittotal + System.Convert.ToDouble(grdcredit.Rows[i].Cells[8].Text);
                        }
                    }



                    if ((grddebit.Rows.Count > 0) && (grdcredit.Rows.Count == 0))
                    {
                        for (i = 0; i < grddebit.Rows.Count; i++)
                        {
                            total = total + System.Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);
                        }
                    }
                    else if ((grdcredit.Rows.Count > 0) && (grddebit.Rows.Count == 0))
                    {
                        for (i = 0; i < grdcredit.Rows.Count; i++)
                        {
                            total = total + System.Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);
                        }
                    }

                    total = System.Convert.ToDouble(debittotal) - System.Convert.ToDouble(credittotal);*/
                   // txttotal.Text = String.Format("{0:F2}", total);

                    DataTable dtd = new DataTable();
                    DataTable dtd1 = new DataTable();

                    if (ddlTypes.SelectedValue == "5")
                    {
                        //
                        dtd = OSDNCN.GetOSDCNDtlsForNewOSV(Convert.ToInt32(txtJobno.Text), Session["Ostrtrantype"].ToString(), 5, branchid, Convert.ToInt32(txtdcn.Text));
                    }
                    else
                    {
                        dtd1 = OSDNCN.GetOSDCNDtlsForNewOSV(Convert.ToInt32(txtJobno.Text), Session["Ostrtrantype"].ToString(), 6, branchid, Convert.ToInt32(txtdcn.Text));
                    }

                    Session["StrTranType"] = strtrantype;

                    if (dtd.Rows.Count > 0)
                    {
                        lbl.Text = "Debit Note";
                    }
                    if (dtd1.Rows.Count > 0)
                    {
                        lbl.Text = "Credit Note";
                    }

                    if (dtd.Rows.Count > 0)
                    {
                        txtdcn.Text = dtd.Rows[0][0].ToString();
                        txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();

                        if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                        {
                            txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                        txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                        if (dtd.Rows[0]["fatransfer"].ToString() == "")
                        {
                            //btnview.Text = "Save";
                            //btnview.Enabled = true;
                        }
                        else
                        {
                            // btnview.Enabled = false;
                        }
                    }
                    else
                    {
                        //btnview.Text = "Save";
                        //btnview.Enabled = true;
                        //txtdcn.Text = "";
                    }


                    if (dtd1.Rows.Count > 0)
                    {
                        txtdcn.Text = dtd1.Rows[0][0].ToString();
                        txtVendorRefno.Text = dtd1.Rows[0]["vendorrefno"].ToString();
                        if (DBNull.Value.Equals(dtd1.Rows[0]["vendorrefdate"]) == false)
                        {
                            txtVendorRefnodate.Text = dtd1.Rows[0]["vendorrefdate"].ToString();
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                        txtyear.Text = dtd1.Rows[0]["vouyear"].ToString();
                        if (dtd1.Rows[0]["fatransfer"].ToString() == "")
                        {
                            //btnview.Text = "Save";
                            //btnview.Enabled = true;
                        }
                        else
                        {
                            // btnview.Enabled = false;
                        }
                    }
                    else
                    {
                        //btnview.Text = "Save";
                        //btnview.Enabled = true;
                        // txtdcn.Text = "";
                    }
                   btnback.Text = "Cancel";

                    btnback.ToolTip = "Cancel";
                    btnback1.Attributes["class"] = "btn ico-cancel";
                    //}


                    //txtVoucherno.Focus();
                    strtrantype = Session["Ostrtrantype"].ToString();
                    btnback.ToolTip = "Cancel";
                    btnback1.Attributes["class"] = "btn ico-cancel";
                    if (txtdcn.Text.ToString() != "")
                    {
                        if (ddlTypes.SelectedValue == "5" || ddlTypes.SelectedValue == "6" || ddlTypes.SelectedValue == "OSPI" || ddlTypes.SelectedValue == "OSSI" || ddlTypes.SelectedValue == "OSDNCN JV" || ddlTypes.SelectedValue == "OSDNCNJV")
                        {
                            if (Convert.ToInt32(txtyear.Text) > 2011)
                            {
                                getosdncndetails();
                            }
                        }
                        //else
                        //{
                        //    getdetails();
                        //}

                        //HORM = false;
                        //modulename();
                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Transfered');", true);
                    txtclear();
                    ddlTypes.SelectedValue = "0";
                    txtdcn.Focus();
                    // txtJobno.Focus();
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

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ddlTypes.SelectedValue == "OSSI")
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[4].Text = "";
                        e.Row.Cells[3].Text = e.Row.Cells[3].Text;
                        e.Row.Cells[5].Text = e.Row.Cells[5].Text;

                    }
                    else if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                        e.Row.Cells[4].Text = e.Row.Cells[4].Text;
                        e.Row.Cells[3].Text = "";
                        e.Row.Cells[5].Text = "";
                    }
                }
                else if (ddlTypes.SelectedValue == "OSPI")
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[4].Text = "";
                        e.Row.Cells[3].Text = e.Row.Cells[3].Text;
                        e.Row.Cells[5].Text = e.Row.Cells[5].Text;
                    }
                    else if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                        e.Row.Cells[4].Text = e.Row.Cells[4].Text;
                        e.Row.Cells[3].Text = "";
                        e.Row.Cells[5].Text = "";
                    }
                }
                else if (ddlTypes.SelectedValue == "OSDNCNJV" || ddlTypes.SelectedValue == "OSDNCN JV")
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[4].Text = "";
                        e.Row.Cells[3].Text = e.Row.Cells[3].Text;
                        e.Row.Cells[5].Text = e.Row.Cells[5].Text;
                    }
                    else if (grd.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                        e.Row.Cells[4].Text = e.Row.Cells[4].Text;
                        e.Row.Cells[3].Text = "";
                        e.Row.Cells[5].Text = "";
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

        public void getosdncndetails()
        {
            str_dispyear = (txtyear.Text.ToString()).Substring(2, 2);
            int dy = Convert.ToInt32(str_dispyear) + 1; ;
            string dy1 = Convert.ToString(dy);
            FADbName = "FA" + str_dispyear + dy1;

            if (ddlTypes.SelectedValue == "5")
            {
                vname = "OSSI";
            }
            else if (ddlTypes.SelectedValue == "6")
            {
                vname = "OSPI";
            }
            else
            {
                vname = ddlTypes.SelectedValue;
            }

            Session["vname"] = vname;

            voutypeid = FAobj.Selvoutypeid(Session["vname"].ToString(), FADbName);
            int logcorid = 0;
            logcorid = hrempobj.GetBranchId(divisionid, "CORPORATE");
            //osvtype = hf_OSV_Type.Value.ToString().Trim();

            //if (osvtype != "" && osvtype != null)
            //{
            //    dtfa = FAobj.SelFAVoucher4OSVou(Convert.ToInt32(txtdcn.Text), logcorid, Div_Id, voutypeid, Vou_Year, FADbName, branchid, osvtype);
            //}
            //else if (PBranch_ID == 0 || LView_Flag == true)
            //{
            dtfa = FAobj.SelFAVoucher(Convert.ToInt32(txtdcn.Text), branchid, divisionid, voutypeid, Convert.ToInt32(txtyear.Text), FADbName);
            //}
            //else
            //{
            //    dtfa = FAobj.SelFAVoucher4BP(Convert.ToInt32(txtdcn.Text), logcorid, Div_Id, voutypeid, Vou_Year, FADbName, branchid);
            //}

            if (dtfa.Rows.Count > 0)
            {
                Hid_trantype.Value = dtfa.Rows[0]["trantype"].ToString();
                strtrantype = Hid_trantype.Value;

                txtJobno.Text = dtfa.Rows[0]["jobno"].ToString();

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
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(famt)", "ledgertype='Dr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(famt)", "ledgertype='Dr'")).ToString("#,0.00");
                        }
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(famt)", "ledgertype='Cr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[3].Text = Convert.ToDouble(dtfa.Compute("sum(famt)", "ledgertype='Cr'")).ToString("#,0.00");
                        }

                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[4].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                        }
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[5].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
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
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(famt)", "ledgertype='Dr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(famt)", "ledgertype='Dr'")).ToString("#,0.00");
                        }
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(famt)", "ledgertype='Cr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[3].Text = Convert.ToDouble(dtfa.Compute("sum(famt)", "ledgertype='Cr'")).ToString("#,0.00");
                        }

                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[4].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                        }
                        if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                        {
                            grd.Rows[grd.Rows.Count - 1].Cells[5].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
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


            DataSet ds = new DataSet();
            ds = OSDNCN.RptOSDNCNFromJobNo(strtrantype, Convert.ToInt32(txtJobno.Text), branchid);
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
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Invalid Voucher #');", true);
                    return;
                }
            }

            dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                blno = Convert.ToString(dt.Rows[0][7].ToString());

                if (strtrantype == "FE" || strtrantype == "FI" || strtrantype == "FC")
                {
                    //txtvessel.Text = dt.Rows[0][5].ToString() + "  /  " + dt.Rows[0][6].ToString();
                    HORM = true;
                    //object Obj_boolvalue = HORM;
                    //int Bool_Value = Convert.ToInt32(Obj_boolvalue);
                    //hid_BoolValue.Value = Bool_Value.ToString();
                    getFEI();
                }
                else
                {
                    //txtvessel.Text = dt.Rows[0][5].ToString() + "  /  " + dt.Rows[0][6].ToString();
                    HORM = true;
                    //object Obj_boolvalue = HORM;
                    //int Bool_Value = Convert.ToInt32(Obj_boolvalue);
                    //hid_BoolValue.Value = Bool_Value.ToString();
                    getAEI();
                }
            }

            DataTable dtd = new DataTable();
            if (ddlTypes.SelectedValue == "OSDNCNJV" || ddlTypes.SelectedValue == "OSDNCN JV")
            {
                if (Convert.ToInt32(Session["LoginBranchid"]) == logcorid)
                {
                    dtd = FAobj.SelFAVouHead4All(Convert.ToInt32(txtdcn.Text), Convert.ToInt32(txtyear.Text), voutypeid, branchid, logcorid, FADbName);
                }
                else
                {
                    dtd = FAobj.SelFAVouHead4All(Convert.ToInt32(txtdcn.Text), Convert.ToInt32(txtyear.Text), voutypeid, branchid, 0, FADbName);
                }

            }
            else
            {
              //  dtd = OSDNCN.GetOSDCNDtls(Convert.ToInt32(txtJobno.Text), strtrantype, Session["vname"].ToString(), branchid);

                dtd = OSDNCN.GetOSDCNDtls_new(Convert.ToInt32(txtJobno.Text), strtrantype, Session["vname"].ToString(), branchid, Convert.ToInt32(txtdcn.Text));
                if (dtd.Rows.Count > 0)
                {
                    voudate = Convert.ToDateTime((dtd.Rows[0][1]).ToString());
                    //txtremarks.Text = Convert.ToString(dtd.Rows[0][5].ToString());
                    txtvoudate.Text = dtd.Rows[0]["fdate"].ToString();
                    //txtModule.Text = lblHead.InnerText;

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

            if (vname == "OSSI")
            {
                DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtdcn.Text), strtrantype, "OSSI", Convert.ToInt32(txtyear.Text), branchid);
            }
            else if (vname == "OSPI")
            {
                DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt32(txtdcn.Text), strtrantype, "OSPI", Convert.ToInt32(txtyear.Text), branchid);
            }

            lstagnst.Items.Clear();

            i = DtSHead.Rows.Count;
            if (i > 0)
            {
                DataTable Against = new DataTable();
                if (vname == "OSSI")
                {
                    if (INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtdcn.Text), branchid, Convert.ToInt32(txtyear.Text), "D") != "0")
                    {
                        Against = INVOICEobj.GetVoucherAgainstRcptPayNEW(Convert.ToInt32(txtdcn.Text), branchid, Convert.ToInt32(txtyear.Text), "D");
                    }
                }
                else if (vname == "OSPI")
                {
                    if (INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtdcn.Text), branchid, Convert.ToInt32(txtyear.Text), "C") != "0")
                    {
                        Against = INVOICEobj.GetVoucherAgainstRcptPayNEW(Convert.ToInt32(txtdcn.Text), branchid, Convert.ToInt32(txtyear.Text), "C");
                    }
                }
                for (int x = 0; x <= Against.Rows.Count - 1; x++)
                {
                    lstagnst.Items.Add(Against.Rows[x][0].ToString());
                }
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

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        public void getFEI()
        {
            if (strtrantype == "FE")
            {
                if (vname != "InvoiceWoJ")
                {
                    if (HORM == true)
                    {
                        lstvol.Items.Clear();
                        DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtJobno.Text), txtJobno.Text, strtrantype, branchid);

                        if (DtConDetails.Rows.Count > 0)
                        {
                            for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtConDetails.Rows[i][0].ToString() + ",  " + DtConDetails.Rows[i][1].ToString());
                            }
                        }
                        lstcon.Items.Clear();
                        DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtJobno.Text), txtJobno.Text, strtrantype, branchid);
                        if (DtCon.Rows.Count != 0)
                        {
                            for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
                            }
                        }
                        //DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), branchid);
                        //if (DtCon.Rows.Count != 0)
                        //{
                        //    vessel = DtCon.Rows[0][3].ToString();
                        //    voyage = DtCon.Rows[0]["voyage"].ToString();
                        //    txtvessel.Text = vessel + " / " + voyage;
                        //}
                        //else
                        //{
                        //}
                    }
                    else
                    {
                        lstvol.Items.Clear();
                        DtInfo = FEBLobj.GetBLDetails(blno, branchid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (DtInfo.Rows.Count != 0)
                        {
                            //txtshipper.Text = DtInfo.Rows[0][4].ToString();
                            //txtconsignee.Text = DtInfo.Rows[0][6].ToString();
                            //txtnotify.Text = DtInfo.Rows[0][8].ToString();
                            //DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtJobno.Text), branchid, branchid);
                            //if (DtCon.Rows.Count != 0)
                            //{
                            //    vessel = DtCon.Rows[0][3].ToString();
                            //    voyage = DtCon.Rows[0][7].ToString();
                            //    txtvessel.Text = vessel + " / " + voyage;

                            //}
                            //else
                            //{
                            //    //txtclear()
                            //}
                            //DtConDetails = INVOICEobj.GetHBLContainerDtls(blno, strtrantype, branchid);
                            //j = DtConDetails.Rows.Count;
                            //if (j > 0)
                            //{
                            //    for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            //    {
                            //        lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                            //    }
                            //    volume = DtConDetails.Rows[0][1].ToString();
                            //    lstvol.Items.Add(volume + "cbm");
                            //    wt = DtConDetails.Rows[0][2].ToString();
                            //    lstvol.Items.Add(wt + " Kgs");
                            //}
                            // lstcon.Items.Clear();
                            DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtJobno.Text), blno, strtrantype, branchid);
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
                    //dt = FEBLWoJobj.GetBLDetWOJob(blno, Convert.ToInt32(Session["LoginBranchid"].ToString()), branchid);
                    //if (dt.Rows.Count != 0)
                    //{
                    //    txtJobno.Text = "0";
                    //    txtshipper.Text = dt.Rows[0][3].ToString();
                    //    txtconsignee.Text = dt.Rows[0][6].ToString();
                    //    txtnotify.Text = dt.Rows[0][9].ToString();


                    //    //**** 33 WAS NOT FOUND IN DATATABLE*******//
                    //    txtvessel.Text = dt.Rows[0][33].ToString();

                    //}
                }
            }
            else
            {
                if (HORM == true)
                {
                    lstvol.Items.Clear();
                    DtInfo = INVOICEobj.GetMblInvoiceHead(blno, strtrantype, branchid);
                    if (DtInfo.Rows.Count != 0)
                    {
                        //txtJobno.Text = DtInfo.Rows[0][0].ToString();
                        //vessel = DtInfo.Rows[0][3].ToString();
                        //voyage = DtInfo.Rows[0][2].ToString();
                        //txtvessel.Text = vessel + " / " + voyage;

                        DtCon = INVOICEobj.GetFIMblNContainers(txtJobno.Text, branchid);
                        if (DtCon.Rows.Count != 0)
                        {
                            for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());
                            }
                        }
                        DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtJobno.Text), txtJobno.Text, strtrantype, branchid);
                        j = DtConDetails.Rows.Count;
                        if (j > 0)
                        {
                            for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtConDetails.Rows[i][0].ToString() + ",  " + DtConDetails.Rows[i][1].ToString());
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
                    if (strtrantype == "FC")
                    {
                        DtInfo = INVOICEobj.GetHblInvoiceHead(blno, "FI", branchid);
                    }
                    else
                    {
                        DtInfo = INVOICEobj.GetHblInvoiceHead(blno, strtrantype, branchid);
                        //DtInfo = INVOICEobj.GetHblInvoiceHead(blno, strtrantype, branchid);
                    }
                    //if (DtInfo.Rows.Count != 0)
                    //{
                    //    txtJobno.Text = DtInfo.Rows[0][0].ToString();
                    //    txtshipper.Text = DtInfo.Rows[0][4].ToString();
                    //    txtconsignee.Text = DtInfo.Rows[0][5].ToString();
                    //    txtnotify.Text = DtInfo.Rows[0][6].ToString();
                    //    vessel = DtInfo.Rows[0][3].ToString();
                    //    voyage = DtInfo.Rows[0][2].ToString();
                    //    txtvessel.Text = vessel + " / " + voyage;
                    //}
                    //else
                    //{
                    //    // txtclear()
                    //}
                }
                DtConDetails = INVOICEobj.GetHBLContainerDtls(blno, strtrantype, branchid);
                j = DtConDetails.Rows.Count;

                if (j > 0)
                {
                    for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                    {
                        lstvol.Items.Add(DtConDetails.Rows[i][0].ToString() + ",  " + DtConDetails.Rows[i][1].ToString());
                    }
                    //if (strtrantype == "FC")
                    //{
                    //    volume = (INVOICEobj.GetVolume(blno, "FI", branchid).ToString());
                    //}
                    //else
                    //{
                    //    volume = (INVOICEobj.GetVolume(blno, strtrantype, branchid).ToString());
                    //}

                    //lstvol.Items.Add(volume + " cbm");

                    //if (strtrantype == "FC")
                    //{
                    //    wt = (INVOICEobj.GetWeight(blno, "FI", branchid)).ToString();
                    //}
                    //else
                    //{
                    //    wt = (INVOICEobj.GetWeight(blno, strtrantype, branchid)).ToString();
                    //}

                    //lstvol.Items.Add(wt + " Kgs");
                    //lstcon.Items.Clear();

                    if (strtrantype == "FC")
                    {
                        DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtJobno.Text), blno, "FI", branchid);
                    }
                    else
                    {
                        DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtJobno.Text), blno, strtrantype, branchid);
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

        public void getAEI()
        {
            //txtJobno.Text = "";

            if (HORM == true)
            {
                //lstvol.Items.Clear();
                if (strtrantype == "AE")
                {
                    DtInfo = INVOICEobj.GetMblInvoiceHead(blno, strtrantype, branchid);
                }
                else
                {
                    DtInfo = INVOICEobj.GetMblInvoiceHead(blno, strtrantype, branchid);
                }
                //if (DtInfo.Rows.Count != 0)
                //{
                //    txtJobno.Text = DtInfo.Rows[0][0].ToString();
                //    flightdate = Convert.ToDateTime((DtInfo.Rows[0][1]).ToString());
                //    txtvessel.Text = DtInfo.Rows[0][2] + " / " + DtInfo.Rows[0]["fdate"];
                //}
                //else
                //{
                //    // txtclear()
                //}
            }
            else
            {
                lstvol.Items.Clear();
                if (strtrantype == "AE")
                {
                    DtInfo = INVOICEobj.GetHblInvoiceHead(blno, strtrantype, branchid);
                }
                else
                {
                    DtInfo = INVOICEobj.GetHblInvoiceHead(blno, strtrantype, branchid);
                }
                //if (DtInfo.Rows.Count != 0)
                //{
                //    txtJobno.Text = DtInfo.Rows[0][0].ToString();
                //    txtshipper.Text = DtInfo.Rows[0][3].ToString();
                //    txtconsignee.Text = DtInfo.Rows[0][4].ToString();
                //    txtnotify.Text = DtInfo.Rows[0][5].ToString();
                //    flightdate = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                //    //flightdate = Convert.ToDateTime(DtInfo.Rows[0]["flightdate"].ToString());
                //    txtvessel.Text = DtInfo.Rows[0][2] + " / " + DtInfo.Rows[0]["fdate"];
                //}
                //else
                //{
                //    // txtclear()
                //}
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
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            GridViewlog.Visible = true;
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            lbl_title.InnerText = lbl_Header.Text;
            if (lbl_Header.Text == "OSSI")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10006, "OSSI", txtdcn.Text, txtdcn.Text, Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10007, "OSPI", txtdcn.Text, txtdcn.Text, Session["StrTranType"].ToString());
            }

            if (txtdcn.Text != "")
            {
                JobInput.Text = txtdcn.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void fillBranch()
        {
            dtbranch = hrempobj.selBranchList(Session["LoginDivisionName"].ToString());
            if (dtbranch.Rows.Count > 0)
            {
                for (int i = 0; i <= dtbranch.Rows.Count - 1; i++)
                {
                    ddl_branch.Items.Add(dtbranch.Rows[i]["branchname"].ToString());
                }
            }
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hid_Tran.Value == "CA")
            {
                //branchid = hrempobj.GetBranchId(divisionid, ddl_branch.Text);

                if (branchid == 0)
                {
                    branchid = hrempobj.GetBranchId(divisionid, ddl_branch.SelectedItem.Value);
                }
                else
                {

                }

                hid_branch.Value = branchid.ToString();
            }
            else
            {
               // branchid = Convert.ToInt32(Session["LoginBranchid"]);

                if (branchid == 0)
                {
                    branchid = Convert.ToInt32(Session["LoginBranchid"]);
                }
                else
                {

                }
                hid_branch.Value = branchid.ToString();
            }

        }

        protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddltype"] = ddlTypes.SelectedItem.Text;
            Session["ddltypeid"] = ddlTypes.SelectedValue;
            lbl_Header.Text = ddlTypes.SelectedItem.Text;
            if (lbl_Header.Text == "OSSI")
            {
                ddlTypes.Items.FindByText("OSSI").Selected = true;
                //Label4.Visible = true;
                //pnlCCharge.Visible = true;
                ////grddebit.Visible = true;
                //Label8.Visible = true;
                //txt_total.Visible = true;
                //Label5.Visible = false;
                //Panel2.Visible = false;
                ////grdcredit.Visible = false;
                //Label11.Visible = false;
                //txttotal.Visible = false;
                Label4.Text = "Receivable from Agent";
                HeaderLabel.InnerText = lbl_Header.Text;
                Label10.Visible = false;
                txtVendorRefnodate.Visible = false;
                Label9.Visible = false;
                txtVendorRefno.Visible = false;
                Label2.Text = "OSSI #";
            }
            else if (lbl_Header.Text == "OSPI")
            {
                ddlTypes.Items.FindByText("OSPI").Selected = true;
                //Label5.Visible = true;
                //Panel2.Visible = true;
                ////grdcredit.Visible = true;
                //Label11.Visible = true;
                //txttotal.Visible = true;
                //Label4.Visible = false;
                //pnlCCharge.Visible = false;
                ////grddebit.Visible = false;
                //Label8.Visible = false;
                //txt_total.Visible = false;
                Label4.Text = "Payable to Agent";
                HeaderLabel.InnerText = lbl_Header.Text;
                Label2.Text = "OSPI #";
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
            txtJobno.Focus();
            //25-05-2021
            if (logobj.GetDate().Month < 4)
            {
                txtyear.Text = (logobj.GetDate().Year - 1).ToString();
                vouyear = Convert.ToInt32((logobj.GetDate().Year - 1).ToString());
            }
            else
            {
                txtyear.Text = (logobj.GetDate().Year).ToString();
                vouyear = Convert.ToInt32((logobj.GetDate().Year).ToString());
            }

            if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC")
            {
                txtyear.Text = Session["LogYear"].ToString();
            }
            txtvoudate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");

            grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
            grdcredit.DataBind();
            grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
            grddebit.DataBind();
            grd.DataSource = Utility.Fn_GetEmptyDataTable();
            grd.DataBind();

            fillBranch();
            if (Trantype == "CO")
            {
                hid_Tran.Value = "CA";
            }

            if (hid_Tran.Value != "CA")
            {
                ddl_branch.Enabled = false;
                ddl_branch.Text = Session["LoginBranchName"].ToString();
            }
            else
            {
                ddl_branch.Enabled = true;
                ddl_branch.SelectedIndex = -1;
            }
            ddl_branch_SelectedIndexChanged(sender, e);
        }
    }
}