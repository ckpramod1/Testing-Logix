using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.CHA
{
    public partial class CHCosting : System.Web.UI.Page
    {
        DataAccess.CostingDetails da_obj_Costing = new DataAccess.CostingDetails();
        DataAccess.CloseJobs da_obj_Closejob = new DataAccess.CloseJobs();
        DataAccess.Accounts.Invoice da_obj_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.OSDNCN da_obj_InvOSDC = new DataAccess.Accounts.OSDNCN();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        public static int int_bid, int_did, int_jobno = 0;
        public static string trantype;
        string str_FornName, str_Uiid;
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);
            txt_job.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
            try
            { 
            if (Session["LoginUserName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (Request.QueryString.ToString().Contains("type"))
            {
                lbl_Header.Text = Request.QueryString["type"].ToString();
            }

            if (Request.QueryString.ToString().Contains("type"))
            {
                string str_FornName = "", str_Uiid = "";
                str_FornName = Request.QueryString["type"].ToString();
                //str_Uiid = Request.QueryString["UIID"].ToString();
                //Utility.Fn_CheckUserRights(str_Uiid, null, btn_print);
            }
            if (!IsPostBack)
            {
                try
                {
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                    {
                        //lbl_vsl.Text = "Vessel";
                        //txt_date.Attributes.Add("placeholder", "Vessel");
                        txt_date.Attributes.Add("placeholder", "Date");
                        txt_date.ToolTip = "Date";

                        txt_vsl.Attributes.Add("placeholder", "Vessel");
                        txt_vsl.ToolTip = "Vessel";
                        //lbl_agent.Text = "From";
                        txt_agent.Attributes.Add("placeholder", "Agent");
                        txt_agent.ToolTip = "Agent";
                        //lbl_mlo.Text = "To";
                        txt_mlo.Attributes.Add("placeholder", "MLO");
                        txt_mlo.ToolTip = "MLO";
                        //lbl_pol.Text = "ETD";                    
                        txt_pol.Attributes.Add("placeholder", "POL");
                        txt_pol.ToolTip = "ETD";
                        // lbl_pod.Text = "ETA";                 
                        txt_pod.Attributes.Add("placeholder", "POD");
                        txt_pod.ToolTip = "ETA";
                        // lbl_date.Visible = false;
                        //txt_date.Visible = false;
                        // lbl_mbl.Visible = true;
                        txt_mbl.Attributes.Add("placeholder", "MBL");
                        txt_mbl.ToolTip = "MBL";

                    }
                    else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                    {
                        //lbl_vsl.Text = "Flight";
                        txt_vsl.Attributes.Add("placeholder", "Flight");
                        txt_vsl.ToolTip = "Flight";


                        txt_vsl.Attributes.Add("placeholder", "Vessel");
                        txt_vsl.ToolTip = "Vessel";
                        //lbl_agent.Text = "From";
                        txt_agent.Attributes.Add("placeholder", "Agent");
                        txt_agent.ToolTip = "Agent";
                        //lbl_mlo.Text = "To";
                        txt_mlo.Attributes.Add("placeholder", "MLO");
                        txt_mlo.ToolTip = "MLO";
                        //lbl_pol.Text = "ETD";                    
                        txt_pol.Attributes.Add("placeholder", "POL");
                        txt_pol.ToolTip = "ETD";
                        // lbl_pod.Text = "ETA";                 
                        txt_pod.Attributes.Add("placeholder", "POD");
                        txt_pod.ToolTip = "ETA";
                        // lbl_date.Visible = false;
                        //txt_date.Visible = false;
                        // lbl_mbl.Visible = true;
                        txt_mbl.Attributes.Add("placeholder", "MBL");
                        txt_mbl.ToolTip = "MBL";
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                       //s txt_job.ReadOnly = true;
                        //lbl_vsl.Text = "Truck #";
                        txt_vsl.Attributes.Add("placeholder", "Doc #");
                        txt_vsl.ToolTip = "DOC NUMBER";
                        //lbl_agent.Text = "From";
                        txt_agent.Attributes.Add("placeholder", "Agent");
                        txt_agent.ToolTip = "Agent";
                        //lbl_mlo.Text = "To";
                        txt_mlo.Attributes.Add("placeholder", "MLO");
                        txt_mlo.ToolTip = "MLO";
                        //lbl_pol.Text = "ETD";                    
                        txt_pol.Attributes.Add("placeholder", "POL");
                        txt_pol.ToolTip = "Port Of Loading";
                        // lbl_pod.Text = "ETA";                 
                        txt_pod.Attributes.Add("placeholder", "POD");
                        txt_pod.ToolTip = "Port of Destination";
                        // lbl_date.Visible = false;
                        txt_date.Visible = false;
                        txt_date.Attributes.Add("placeholder", "Doc Date");
                        txt_date.ToolTip = "Doc Date";
                        // lbl_mbl.Visible = true;
                        txt_mbl.Attributes.Add("placeholder", "MBL");
                        txt_mbl.ToolTip = "MBL";
                        txt_mbl.Visible = true;
                        txt_mode.Attributes.Add("placeholder", "Mode");
                        txt_mode.ToolTip = "Mode";
                        txt_mode.Visible = true;
                        btn_Export.Visible = false;
                    }
                    else
                    {
                       // txt_job.ReadOnly = true;
                        //lbl_vsl.Text = "Truck #";
                        txt_vsl.Attributes.Add("placeholder", "Truck #");
                        txt_vsl.ToolTip = "Truck Number";
                        //lbl_agent.Text = "From";
                        txt_agent.Attributes.Add("placeholder", "From");
                        txt_agent.ToolTip = "From";
                        //lbl_mlo.Text = "To";
                        txt_mlo.Attributes.Add("placeholder", "To");
                        txt_mlo.ToolTip = "To";
                        //lbl_pol.Text = "ETD";                    
                        txt_pol.Attributes.Add("placeholder", "ETD");
                        txt_pol.ToolTip = "ETD";
                        // lbl_pod.Text = "ETA";                 
                        txt_pod.Attributes.Add("placeholder", "ETA");
                        txt_pod.ToolTip = "ETA";
                        // lbl_date.Visible = false;
                        txt_date.Visible = false;
                        // lbl_mbl.Visible = true;
                        txt_mbl.Attributes.Add("placeholder", "MBL");
                        txt_mbl.ToolTip = "MBL";
                        txt_mbl.Visible = true;
                      


                    }
                    if (lbl_Header.Text == "Costing")
                    {
                       
                        rbtcosting.Visible = false;
                        btn_Export.Visible = false;
                    }
                    else
                    {
                        div_prealert.Visible = false;
                        // lbl_remark.Visible = false;
                        txt_remark.Visible = false;
                    }
                    Grdcost.Visible = true;
                    Grdcost.DataSource = new DataTable();
                    Grdcost.DataBind();
                    UserRights();
                  //  btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
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

        }

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    Boolean btn_delete;
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_print, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                    //if (btn_delete == true)
                    //{
                    //    Grd_container.Columns[6].Visible = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_job.Text.Trim().Length > 0)
                {
                    int_jobno = int.Parse(txt_job.Text);
                    int_bid = int.Parse(Session["LoginBranchid"].ToString());
                    DataTable obj_dt = new DataTable();
                    trantype = Session["StrTranType"].ToString();
                    string mlo;
                    DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                    if (trantype == "CH")
                    {
                        obj_dt = da_obj_Costingdt.GetJobdtls(trantype, int_jobno, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_mode.Text = obj_dt.Rows[0][0].ToString();
                            txt_vsl.Text = obj_dt.Rows[0][1].ToString();
                            txt_date.Text = obj_dt.Rows[0][2].ToString();
                            txt_mlo.Text = obj_dt.Rows[0][5].ToString();
                            txt_pol.Text = obj_dt.Rows[0][6].ToString();
                            txt_mbl.Text = obj_dt.Rows[0][3].ToString();
                            txt_pod.Text = obj_dt.Rows[0][7].ToString();
                            txt_agent.Text = Server.HtmlDecode(obj_dt.Rows[0][4].ToString());

                            if (string.IsNullOrEmpty(obj_dt.Rows[0]["jobcloseremarks"].ToString()) == false)
                            {
                                txt_remark.Text = obj_dt.Rows[0]["jobcloseremarks"].ToString();
                            }
                            else
                            {
                                txt_remark.Text = "";
                            }
                            //hid_etd.Value = obj_dt.Rows[0]["etd"].ToString();
                        }
                    }


                    obj_dt.Reset();
                    obj_dt = da_obj_Costing.CostingDetail(Convert.ToInt32(txt_job.Text), Session["StrTranType"].ToString(), int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        Grdcost.DataSource = obj_dt;
                        Grdcost.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txt_job.Text = "";
                txt_job.Focus();

            }
       //     btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";



        }

        /*protected void Grdcost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                LinkButton Img_Select_btn = (LinkButton)Grdcost.SelectedRow.FindControl("Lnk_job");
                string Str_voucher, strtrantype, strblno;
                int int_vouno, int_vouyear = 0;
                trantype = Session["StrTranType"].ToString();
                if (Grdcost.Rows.Count > 0)
                {
                    Str_voucher = Grdcost.SelectedRow.Cells[0].Text.ToString().Replace("&nbsp;", string.Empty);
                    if (Grdcost.SelectedRow.Cells[1].Text.Trim().ToString().Replace("&nbsp;", string.Empty).Length > 0)
                    {


                        int_vouno = Convert.ToInt32(Grdcost.SelectedRow.Cells[1].Text.ToString());

                        if (Grdcost.SelectedDataKey.Values[0].ToString().Trim().Length > 0)
                        {
                            int_vouyear = Convert.ToInt32(Grdcost.SelectedDataKey.Values[0].ToString());
                        }
                        string str_vou = "";
                        if (Str_voucher == "CN")
                        {
                            str_vou = "CNHead";
                        }
                        else if (Str_voucher == "DN")
                        {
                            str_vou = "DNHead";
                        }
                        else if (Str_voucher == "CN-Ops")
                        {
                            str_vou = "PA";
                        }
                        else
                        {
                            str_vou = Str_voucher;
                        }

                        DataTable obj_dt = new DataTable();
                        DataTable obj_dttemp = new DataTable();
                        string Str_RptName, Str_SF, Str_SP, Str_Script, Str_curr;
                        Str_RptName = "";
                        Str_SF = "";
                        Str_SP = "";
                        Str_Script = "";
                        Str_curr = "";

                        obj_dt = da_obj_Invoice.ShowIPHead(int_vouno, trantype, str_vou, int_vouyear, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            strtrantype = obj_dt.Rows[0]["trantype"].ToString();
                            strblno = obj_dt.Rows[0]["blno"].ToString();
                            obj_dttemp = da_obj_Invoice.CheckHblno(strblno, strtrantype, int_bid);
                        }
                        if (obj_dttemp.Rows.Count > 0)
                        {


                            if (Str_voucher == "Invoice")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIInvoice.rpt";
                                    //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "CN-Ops")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "fepa.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "DN")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container="; ;
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN")
                            {
                                int int_custid = 0;
                                DataTable obj_dtcn = new DataTable();
                                obj_dtcn = da_obj_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouno, int_bid);
                                if (obj_dtcn.Rows.Count > 0)
                                {
                                    int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
                                }
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FECN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                                    Str_SP = "Lcurr=INR~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FICN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                                    Str_SP = "container="; ;
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AECN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AICN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHACN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }


                        }
                        else
                        {
                            if (Str_voucher == "Invoice")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "CN-Ops")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "DN")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container=";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "container="; ;
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHACN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }


                        }
                        if (Str_voucher == "OSSI")
                        {
                            //DataTable obj_dtoscn = new DataTable();
                            //obj_dtoscn = da_obj_InvOSDC.RptOSDNCN(trantype, int_vouno, int_bid, "OSSI", int_vouyear);
                            int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                            Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "D", int_bid);
                            string str_script1, str_script2;
                            if (trantype == "FE")
                            {

                                Str_RptName = "FEOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);

                                Str_RptName = "SOA1.rpt";
                                Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                Str_SP = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);


                            }
                            else if (trantype == "FI")
                            {

                                Str_RptName = "FIOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";


                                Str_RptName = "SOA1.rpt";
                                Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                Str_SP = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);

                            }
                            else if (trantype == "AE")
                            {

                                Str_RptName = "AEOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);

                                Str_RptName = "SOA1.rpt";
                                Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                Str_SP = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                            }
                            else
                            {

                                Str_RptName = "AIOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";


                                Str_RptName = "SOA1.rpt";
                                Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                Str_SP = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                            }
                        }
                        if (Str_voucher == "OSPI")
                        {
                            int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                            Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "C", int_bid);
                            string str_script1, str_script2;
                            if (trantype == "FE")
                            {

                                Str_RptName = "FEOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";


                                Str_RptName = "SOA1.rpt";
                                Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                Str_SP = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);

                            }
                            else if (trantype == "FI")
                            {

                                Str_RptName = "FIOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";


                                Str_RptName = "SOA1.rpt";
                                Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                Str_SP = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);

                            }
                            else if (trantype == "AE")
                            {

                                Str_RptName = "AEOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";


                                Str_RptName = "SOA1.rpt";
                                Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                Str_SP = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                            }
                            else
                            {

                                Str_RptName = "AIOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";


                                Str_RptName = "SOA1.rpt";
                                Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                Str_SP = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(LinkButton), "CostingDetails", Str_Script, true);
                            }
                        }
                    }
                    else
                    {
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
        */

        //For GST
        protected void Grdcost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
                DataTable dttp = new DataTable();
                DataTable dtp = new DataTable();
                string Str_CustType = "";
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                // LinkButton Img_Select_btn = (LinkButton)Grdcost.SelectedRow.FindControl("Lnk_job");
                DateTime get_date, GST_date;
                get_date = Convert.ToDateTime(Utility.fn_ConvertDate(Grdcost.SelectedRow.Cells[2].Text));
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                string Str_voucher, strtrantype, strblno = "";
                int int_vouno, int_vouyear = 0;
                trantype = Session["StrTranType"].ToString();
                string HORM = "", bltype = "", header = "";
                DataTable DTRetve = new DataTable();
                string Vouch1 = "", Vouch2 = "";
                int Ref1 = 0, Ref2 = 0;
                double tot_amount = Convert.ToDouble(Grdcost.SelectedRow.Cells[6].Text);
                int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                if (Grdcost.Rows.Count > 0)
                {
                    Str_voucher = Grdcost.SelectedRow.Cells[0].Text.ToString().Replace("&nbsp;", string.Empty);
                    if (Grdcost.SelectedRow.Cells[1].Text.Trim().ToString().Replace("&nbsp;", string.Empty).Length > 0)
                    {
                        if (Grdcost.SelectedRow.Cells[1].Text != "")
                        {
                            Str_CustType = obj_da_Customer.GetCustomerType(int.Parse(Grdcost.SelectedRow.Cells[7].Text));
                        }
                        if (Str_CustType != "P")
                        {
                            Str_CustType = "";
                        }
                        int_vouno = Convert.ToInt32(Grdcost.SelectedRow.Cells[1].Text.ToString());

                        if (Grdcost.SelectedDataKey.Values[0].ToString().Trim().Length > 0)
                        {
                            int_vouyear = Convert.ToInt32(Grdcost.SelectedDataKey.Values[0].ToString());
                        }
                        string str_vou = "";
                        if (Str_voucher == "CN")
                        {
                            str_vou = "CNHead";
                        }
                        else if (Str_voucher == "Pro CN")
                        {
                            str_vou = "Pro CN";
                        }
                        else if (Str_voucher == "DN")
                        {
                            str_vou = "DNHead";
                        }
                        else if (Str_voucher == "Pro DN")
                        {
                            str_vou = "Pro DN";
                        }
                        else if (Str_voucher == "CN-Ops")
                        {
                            str_vou = "PA";
                        }
                        else if (Str_voucher == "ProCN-Ops")
                        {
                            str_vou = "ProPA";
                        }
                        else
                        {
                            str_vou = Str_voucher;
                        }

                        DataTable obj_dt = new DataTable();
                        DataTable obj_dttemp = new DataTable();
                        string Str_RptName, Str_SF, Str_SP, Str_Script, Str_curr;
                        Str_RptName = "";
                        Str_SF = "";
                        Str_SP = "";
                        Str_Script = "";
                        Str_curr = "";

                        obj_dt = da_obj_Invoice.ShowIPHead(int_vouno, trantype, str_vou, int_vouyear, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            strtrantype = obj_dt.Rows[0]["trantype"].ToString();
                            strblno = obj_dt.Rows[0]["blno"].ToString();
                            obj_dttemp = da_obj_Invoice.CheckHblno(strblno, strtrantype, int_bid);

                        }

                        if (obj_dttemp.Rows.Count > 0)
                        {

                            bltype = "H";
                            if (Str_voucher == "Invoice")
                            {
                                header = "Invoice";
                                HORM = "H";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIInvoice.rpt";
                                    //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTInvoice.rpt";
                                    Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno.Replace("#","") + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                } //ScriptManager.RegisterStartupScript((Grdcost, , typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            if (Str_voucher == "BOS")
                            {
                                header = "Bill of Supply";
                                HORM = "H";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIInvoice.rpt";
                                    //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTInvoice.rpt";
                                    Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                } //ScriptManager.RegisterStartupScript((Grdcost, , typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN-Ops")
                            {
                                header = "PA";
                                HORM = "H";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "fepa.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTPA.rpt";
                                    Str_SF = "{ACPAHead.trantype}=\"" + trantype + "\" and {ACPAHead.pano}=" + int_vouno + " and {ACPAHead.branchid}=" + int_bid + " and {ACPAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno.Replace("#","") + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                // ScriptManager.RegisterStartupScript((Grdcost,typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "DN")
                            {
                                header = "DN";
                                HORM = "H";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno.Replace("#","") + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }                               // ScriptManager.RegisterStartupScript((Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN")
                            {
                                header = "CN";
                                HORM = "H";
                                int int_custid = 0;
                                DataTable obj_dtcn = new DataTable();
                                obj_dtcn = da_obj_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouno, int_bid);
                                if (obj_dtcn.Rows.Count > 0)
                                {
                                    int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
                                }
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FECN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FICN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "container=";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AECN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AICN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHACN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }


                        }
                        else
                        {
                            bltype = "M";
                            if (Str_voucher == "Invoice")
                            {
                                header = "Invoice";
                                HORM = "M";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTInvoice.rpt";
                                    Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno.Replace("#","") + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                } //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "CN-Ops")
                            {
                                header = "PA";
                                HORM = "M";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTPA.rpt";
                                    Str_SF = "{ACPAHead.trantype}=\"" + trantype + "\" and {ACPAHead.pano}=" + int_vouno + " and {ACPAHead.branchid}=" + int_bid + " and {ACPAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=INR";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno.Replace("#","") + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }                              // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "DN")
                            {
                                header = "DN";
                                HORM = "M";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno.Replace("#","") + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }                              // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN")
                            {
                                header = "CN";
                                HORM = "M";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "container="; ;
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHACN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno.Replace("#","") + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                } //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }


                        }
                        //  int int_jobnonew = Convert.ToInt32(txt_job.Text.ToString());
                        DTRetve = DAdvise.getRetriveCnDnNum(Convert.ToString(trantype), Convert.ToInt32(int_jobno), Convert.ToInt32(Session["LoginBranchid"]));
                        if (DTRetve.Rows.Count > 0)
                        {
                            DataView dt_check = DTRetve.DefaultView;
                            dt_check.RowFilter = "type = 'OSSI'";
                            DataTable dtNew_check = dt_check.ToTable();
                            if (dtNew_check.Rows.Count > 0)
                            {
                                Vouch1 = dtNew_check.Rows[0][1].ToString();
                                Ref1 = Convert.ToInt32(dtNew_check.Rows[0][0].ToString());
                            }

                            DataView dt_check1 = DTRetve.DefaultView;
                            dt_check1.RowFilter = "type = 'OSPI'";
                            DataTable dtNew_check1 = dt_check1.ToTable();
                            if (dtNew_check1.Rows.Count > 0)
                            {
                                Vouch2 = dtNew_check1.Rows[0][1].ToString();
                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());

                            }
                        }
                      /*  if (Str_voucher == "OSSI")
                        {
                            //DataTable obj_dtoscn = new DataTable();
                            //obj_dtoscn = da_obj_InvOSDC.RptOSDNCN(trantype, int_vouno, int_bid, "OSSI", int_vouyear);

                            Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "D", int_bid);

                            string str_script1, str_script2;
                            Str_SF = "";
                            Str_SP = "";

                            if (trantype == "FE")
                            {

                                Str_RptName = "FEOSDN.rpt";
                                // Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);

                            }
                            else if (trantype == "FI")
                            {

                                Str_RptName = "FIOSDN.rpt";
                                //   Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else if (trantype == "AE")
                            {

                                Str_RptName = "AEOSDN.rpt";
                                //  Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else
                            {

                                Str_RptName = "AIOSDN.rpt";
                                // Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                        }

                        */



                        if (Str_voucher == "OSSI")
                        {
                            //DataTable obj_dtoscn = new DataTable();
                            //obj_dtoscn = da_obj_InvOSDC.RptOSDNCN(trantype, int_vouno, int_bid, "OSSI", int_vouyear);

                            // Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "D", int_bid);

                            string str_script1, str_script2;
                            Str_SF = "";
                            Str_SP = "";

                            if (trantype == "FE")
                            {
                                dttp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(int_jobno), Convert.ToString(trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
                                if (dttp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dttp.Rows[c]["curr"].ToString();
                                        Str_RptName = "FEOSDN.rpt";
                                        // Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }

                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {

                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);

                            }
                            else if (trantype == "FI")
                            {
                                dttp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(int_jobno), Convert.ToString(trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
                                if (dttp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dttp.Rows[c]["curr"].ToString();
                                        Str_RptName = "FIOSDN.rpt";
                                        //   Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else if (trantype == "AE")
                            {
                                dttp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(int_jobno), Convert.ToString(trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
                                if (dttp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dttp.Rows[c]["curr"].ToString();
                                        Str_RptName = "AEOSDN.rpt";
                                        //  Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else
                            {

                                dttp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(int_jobno), Convert.ToString(trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
                                if (dttp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dttp.Rows[c]["curr"].ToString();
                                        Str_RptName = "AIOSDN.rpt";
                                        // Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                        }

                        if (Str_voucher == "OSPI")
                        {
                            // int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                            // Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "C", int_bid);
                            string str_script1, str_script2;
                            Str_SF = "";
                            Str_SP = "";
                            if (trantype == "FE")
                            {
                                dtp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(int_jobno), Convert.ToString(trantype), "C", Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref2);
                                if (dtp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dtp.Rows[c]["curr"].ToString();

                                        Str_RptName = "FEOSCN.rpt";
                                        // Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                        Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else if (trantype == "FI")
                            {

                                dtp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(int_jobno), Convert.ToString(trantype), "C", Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref2);
                                if (dtp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dtp.Rows[c]["curr"].ToString();
                                        Str_RptName = "FIOSCN.rpt";
                                        // Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                        Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else if (trantype == "AE")
                            {
                                dtp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(int_jobno), Convert.ToString(trantype), "C", Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref2);
                                if (dtp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dtp.Rows[c]["curr"].ToString();
                                        Str_RptName = "AEOSCN.rpt";
                                        // Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                        Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                //ScriptManager.RegisterStartupScript((Grdcost, , typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else
                            {
                                dtp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(int_jobno), Convert.ToString(trantype), "C", Convert.ToInt32(Session["LoginBranchid"].ToString()), Ref2);
                                if (dtp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dtp.Rows[c]["curr"].ToString();
                                        Str_RptName = "AIOSCN.rpt";
                                        // Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                        Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                //Str_Script = str_script1 + ";" + str_script2;
                                // ScriptManager.RegisterStartupScript((Grdcost, , typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                        }

                       /* if (Str_voucher == "OSPI")
                        {
                            // int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                            Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "C", int_bid);
                            string str_script1, str_script2;
                            Str_SF = "";
                            Str_SP = "";
                            if (trantype == "FE")
                            {

                                Str_RptName = "FEOSCN.rpt";
                                // Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else if (trantype == "FI")
                            {

                                Str_RptName = "FIOSCN.rpt";
                                // Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else if (trantype == "AE")
                            {

                                Str_RptName = "AEOSCN.rpt";
                                // Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                //ScriptManager.RegisterStartupScript((Grdcost, , typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                            else
                            {

                                Str_RptName = "AIOSCN.rpt";
                                // Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName = "SOA1.rpt";
                                //Str_SF = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                                //Str_Script = str_script1 + ";" + str_script2;
                                // ScriptManager.RegisterStartupScript((Grdcost, , typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                        }*/
                    }
                    else
                    {
                        return;
                    }
                } UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        } 
        protected void btn_Export_Click(object sender, EventArgs e)
        {
            if (Grdcost.Rows.Count > 0)
            {
                string Filename, strtemp;
                Filename = Fn_GetTrantypename() + " Costing With Details for Job # :" + txt_job.Text;
                strtemp = Utility.Fn_ExportExcel(Grdcost, "<tr><td><td><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr>");
                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();

            }


        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                txt_job.Text = "";
                txt_agent.Text = "";
                txt_date.Text = "";
                txt_mbl.Text = "";
                txt_mlo.Text = "";
                txt_pod.Text = "";
                txt_pol.Text = "";
                txt_vsl.Text = "";
                txt_remark.Text = "";
                txt_mode.Text = "";
                Grdcost.DataSource = Utility.Fn_GetEmptyDataTable();
                Grdcost.DataBind();
              //  btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";

                txt_job.Focus();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void Grdcost_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grdcost, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
                
                if (e.Row.Cells[1].Text.ToString().Replace("&nbsp;", "").Trim() == "")
                {
                   
                    LinkButton Lnk = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Lnk_job");
                    Lnk.Visible = false;
                }

            }
        }

        protected void lnk_job_Click(object sender, EventArgs e)
        {
            try
            { 
            Grd_AE.Visible = false;
            Grd_BT.Visible = false;
            Grd_FE.Visible = false;

            DataTable obj_dt = new DataTable();

            DataAccess.Accounts.CostingDt obj_costingdt = new DataAccess.Accounts.CostingDt();
           
                obj_dt = obj_costingdt.GridFillJobdtls(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    this.popup_Grd.Show();
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                    {
                        Grd_FE.Visible = true;
                        Grd_FE.DataSource = obj_dt;
                        Grd_FE.DataBind();
                    }
                    else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                    {
                        Grd_AE.Visible = true;
                        Grd_AE.DataSource = obj_dt;
                        Grd_AE.DataBind();
                    }
                    else if (Session["StrTranType"].ToString() == "BT")
                    {
                        Grd_BT.Visible = true;
                        Grd_BT.DataSource = obj_dt;
                        Grd_BT.DataBind();
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        CHGrd.Visible = true;
                        CHGrd.DataSource = obj_dt;
                        CHGrd.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "CostingDetails", "alertify.alert('Job Not Available');", true);
                    return;
                }
          
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
       //     btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";



        }

        protected void Grd_FE_SelectedIndexChanged(object sender, EventArgs e)
        {
            popup_Grd.Hide();
            try
            {
                //((Label)grd.Rows[Convert.ToInt32(hf_grdbng_index.Value)].Cells[0].FindControl("Booking")).Text;
                txt_job.Text = ((Label)Grd_FE.SelectedRow.Cells[0].FindControl("Job")).Text;
                txt_vsl.Text = ((Label)Grd_FE.SelectedRow.Cells[1].FindControl("Vessel")).Text;
                txt_date.Text = ((Label)Grd_FE.SelectedRow.Cells[2].FindControl("ETA")).Text;
                txt_mbl.Text = ((Label)Grd_FE.SelectedRow.Cells[3].FindControl("MBL")).Text;
                txt_agent.Text = ((Label)Grd_FE.SelectedRow.Cells[4].FindControl("Agent")).Text;
                txt_mlo.Text = Server.HtmlDecode(((Label)Grd_FE.SelectedRow.Cells[5].FindControl("MLO")).Text);
                txt_pol.Text = ((Label)Grd_FE.SelectedRow.Cells[6].FindControl("POL")).Text;
                txt_pod.Text = ((Label)Grd_FE.SelectedRow.Cells[7].FindControl("POD")).Text;
              
                Fn_LoadGrid();
                //txt_job.Enabled = false;

                int_jobno = int.Parse(txt_job.Text);
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                DataTable obj_dt = new DataTable();
                trantype = Session["StrTranType"].ToString();
                DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                obj_dt = da_obj_Costingdt.GetJobdtls(trantype, int_jobno, int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    hid_etd.Value = obj_dt.Rows[0]["etd"].ToString();
                }
                Grd_FE.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void Grd_AE_SelectedIndexChanged(object sender, EventArgs e)
        {
            //popup_Grd.Hide();
            try
            {
                this.popup_Grd.Hide();
                txt_job.Text = ((Label)Grd_AE.SelectedRow.Cells[0].FindControl("Job")).Text;
                txt_vsl.Text = Grd_AE.SelectedRow.Cells[1].Text.ToString();
                txt_mbl.Text = Grd_AE.SelectedRow.Cells[2].Text.ToString();
                txt_date.Text = Grd_AE.SelectedRow.Cells[3].Text.ToString();
                txt_agent.Text = Server.HtmlDecode(((Label)Grd_AE.SelectedRow.Cells[4].FindControl("Agent")).Text);
                txt_mlo.Text = Server.HtmlDecode(((Label)Grd_AE.SelectedRow.Cells[5].FindControl("airline")).Text);
                txt_pol.Text = Grd_AE.SelectedRow.Cells[6].Text.ToString();
                txt_pod.Text = Grd_AE.SelectedRow.Cells[7].Text.ToString();
                Fn_LoadGrid();
                //txt_job.Enabled = false;
                Grd_AE.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void Grd_BT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //popup_Grd.Hide();
            try
            {
                this.popup_Grd.Hide();
                txt_job.Text = Grd_FE.SelectedRow.Cells[0].Text.ToString();
                txt_vsl.Text = Grd_FE.SelectedRow.Cells[1].Text.ToString();
                txt_agent.Text = Grd_FE.SelectedRow.Cells[2].Text.ToString();
                txt_mlo.Text = Server.HtmlDecode(Grd_FE.SelectedRow.Cells[3].Text.ToString());
                txt_pol.Text = Grd_FE.SelectedRow.Cells[4].Text.ToString();
                txt_pod.Text = Grd_FE.SelectedRow.Cells[5].Text.ToString();
                Fn_LoadGrid();
                //txt_job.Enabled = false;
                Grd_BT.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        private void Fn_LoadGrid()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                obj_dt = da_obj_Costing.CostingDetail(Convert.ToInt32(txt_job.Text), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    Grdcost.DataSource = obj_dt;
                    Grdcost.DataBind();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        private string Fn_GetTrantypename()
        {
            string str_temp = "";
            try  
            { 

          
            if (Session["StrTranType"].ToString() == "FE")
            {
                str_temp = "Ocean Exports";
            } 
            else if (Session["StrTranType"].ToString() == "FI")
            {
                str_temp = "Ocean Imports";
            }
            else if (Session["StrTranType"].ToString() == "AE")
            {
                str_temp = "Air Exports";
            }
            else if (Session["StrTranType"].ToString() == "AI")
            {
                str_temp = "Air Imports";
            }
            else if (Session["StrTranType"].ToString() == "CH")
            {
                str_temp = "C H A";
            }
            else if (Session["StrTranType"].ToString() == "BT")
            {
                str_temp = "Bonded Trucking";
            }


           
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            return str_temp;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
            DataTable obj_dt = new DataTable();
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            try
            {
                if (txt_job.Text.Trim().Length > 0)
                {
                    //if (lbl_Header.Text == "AI Delivery Order")
                    //{

                    //    str_RptName = "AIDeliveryorder.rpt";
                    //    str_sf = "{AIJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {AIJobInfo.jobno}=" + txt_job.Text;
                    //    str_sp = "branchname=" + Session["LoginBranchName"].ToString();
                    //    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Costing", str_Script, true);
                    //    Session["str_sfs"] = str_sf;
                    //    Session["str_sp"] = str_sp;
                    //    return;
                    //}
                    DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                    if (lbl_Header.Text.ToString() == "Costing")
                    {
                        int int_Cont20 = 0, int_Cont40 = 0;
                        double int_Cbm = 0, int_Chargewt = 0;
                        string str_jobdate = "", str_closedate = "", int_Pkg="";
                        obj_dt = da_obj_Costingdt.GetCBM2040fromJob(int.Parse(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            int_Cbm = string.IsNullOrEmpty(obj_dt.Rows[0]["cbm"].ToString()) ? 0 : double.Parse(obj_dt.Rows[0]["cbm"].ToString());
                            int_Cont20 = string.IsNullOrEmpty(obj_dt.Rows[0]["cont20"].ToString()) ? 0 : int.Parse(obj_dt.Rows[0]["cont20"].ToString());
                            int_Cont40 = string.IsNullOrEmpty(obj_dt.Rows[0]["cont40"].ToString()) ? 0 : int.Parse(obj_dt.Rows[0]["cont40"].ToString());
                            int_Chargewt = string.IsNullOrEmpty(obj_dt.Rows[0]["wt"].ToString()) ? 0 : double.Parse(obj_dt.Rows[0]["wt"].ToString());
                            int_Pkg = string.IsNullOrEmpty(obj_dt.Rows[0]["pkg"].ToString()) ? "": obj_dt.Rows[0]["pkg"].ToString();
                        }
                        obj_dt = da_obj_Costingdt.GetJobdtls(Session["StrTranType"].ToString(), int.Parse(txt_job.Text.Trim().ToString()), int.Parse(Session["LoginBranchid"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            str_jobdate = obj_dt.Rows[0]["jobdate"].ToString();
                            str_closedate = obj_dt.Rows[0]["jobclosedate"].ToString();
                        }
                        DataAccess.CostingTemp da_obj_CostTemp = new DataAccess.CostingTemp();
                        int int_Chargeid = 0, int_Vouyear = 0;
                        double Income, Expense;
                        int i;
                        da_obj_CostTemp.DelCostingTempCharges(int.Parse(Session["LoginEmpId"].ToString()));
                        int_Vouyear = int.Parse(Session["Vouyear"].ToString());
                        for (i = 0; i <= 6; i++)
                        {
                            obj_dt = da_obj_CostTemp.GetInvoiceCharges(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), int_Vouyear, i);
                            if (obj_dt.Rows.Count > 0)
                            {
                                for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                                {
                                    int_Chargeid = int.Parse(obj_dt.Rows[j]["charges"].ToString());
                                   if(i == 1 || i == 3 || i == 5)
                                    {
                                        Income = double.Parse(obj_dt.Rows[j]["amount"].ToString());
                                        Expense = 0;
                                    }
                                    else
                                    {
                                        Expense = double.Parse(obj_dt.Rows[j]["amount"].ToString());
                                        Income = 0;
                                    }
                                    da_obj_CostTemp.InsJobChargesTemp(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), i, int.Parse(Session["LoginEmpId"].ToString()), Income, Expense, int_Chargeid);
                                }
                            }
                        }
                        int str_AgentBLcount = 0, str_OurBLCount = 0;
                        obj_dt = da_obj_Costingdt.GetCountAgentOurBL4Job(int.Parse(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            str_AgentBLcount = Convert.ToInt32(obj_dt.Rows[0]["AgentControl"].ToString());
                            str_OurBLCount = Convert.ToInt32(obj_dt.Rows[0]["OurControl"].ToString());
                        }
                        str_RptName = "TempCostingCharges.rpt";
                        str_sf = "{CostingTempCharges.jobno}=" + txt_job.Text + " and {CostingTempCharges.empid}=" + Session["LoginEmpId"].ToString() + " and {CostingTempCharges.branchid}=" + Session["LoginBranchid"].ToString();
                      //  sp = "trantype^" & strtrantype & "~mlo^" & txtMLO.Text & "~agent^" & txtAgent.Text & "~cbm^" & Format(cbm, "#####0.000") & "~cont20^" & Format(chargewt, "#####0.000") & "~cont40^" & pkg & "~jobopen^" & jobdate & "~jobclose^" & closedate & "~vsl^" & txtvsl.Text & "~jobcloserks^" & Trim(txtJobRks.Text) & "~AgentBL^" & AgentBLCnt + "~OurBL^" + OurBLCnt;
                        str_sp = "trantype=" + Session["StrTranType"].ToString() + "~mlo=" + txt_mlo.Text + "~agent=" + txt_agent.Text + "~cbm=" + string.Format("{0:0.000}", int_Cbm.ToString()) + "~cont20=" + string.Format("{0:0.000}", int_Chargewt.ToString()) + "~cont40=" + int_Pkg + "~jobopen=" + str_jobdate + "~jobclose=" + str_closedate + "~vsl=" + txt_mode.Text + "~jobcloserks=" + txt_remark.Text + "~AgentBL=" + str_AgentBLcount + "~OurBL=" + str_OurBLCount;
                        //string mlo = Server.HtmlDecode(txt_mlo.Text);
                        //if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                        //{
                        //    str_sp = "trantype=" + Session["StrTranType"].ToString() + "~mlo=" + txt_mlo.Text + "~agent=" + txt_agent.Text + "~cbm=" + string.Format("{0:0.000}", int_Cbm.ToString()) + "~cont20=" + int_Cont20 + "~cont40=" + int_Cont40 + "~jobopen=" + str_jobdate + "~jobclose=" + str_closedate + "~vsl=" + txt_vsl.Text + "~jobcloserks=" + txt_remark.Text + "~AgentBL=" + str_AgentBLcount + "~OurBL=" + str_OurBLCount;
                        //}
                        //else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                        //{
                        //    str_sp = "trantype=" + Session["StrTranType"].ToString() + "~mlo=" + txt_mlo.Text + "~agent=" + txt_agent.Text + "~cbm=" + string.Format("{0:0.000}", int_Cbm.ToString()) + "~cont20=" + string.Format("{0:0.000}", int_Chargewt.ToString()) + "~cont40=" + int_Cont40 + "~jobopen=" + str_jobdate + "~jobclose=" + str_closedate + "~vsl=" + txt_vsl.Text + "~jobcloserks=" + txt_remark.Text + "~AgentBL=" + str_AgentBLcount + "~OurBL=" + str_OurBLCount;
                        //}

                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Costing", str_Script, true);
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 66, 3, int.Parse(Session["LoginBranchid"].ToString()), "FE " + txt_job.Text);
                                break;

                            case "FI":
                                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 67, 3, int.Parse(Session["LoginBranchid"].ToString()), "FI " + txt_job.Text);
                                break;

                            case "AE":
                                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 68, 3, int.Parse(Session["LoginBranchid"].ToString()), "AE " + txt_job.Text);
                                break;

                            case "AI":
                                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 69, 3, int.Parse(Session["LoginBranchid"].ToString()), "AI " + txt_job.Text);
                                break;
                            case "CH":
                                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 70, 3, int.Parse(Session["LoginBranchid"].ToString()), "CH " + txt_job.Text);
                                break;

                        }
                    }
                    //else
                    //{
                    //    DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                    //    DataAccess.ForwardingImports.PreAlert obj_da_Prealert = new DataAccess.ForwardingImports.PreAlert();

                    //    obj_dt = obj_da_FEBL.ShowFEInfo(int.Parse(txt_job.Text), "SAMPLE", "JOB", 0, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    //    double cbm = double.Parse(obj_dt.Compute("sum(volume)", "").ToString());
                    //    obj_da_Prealert.UpdPreAlert(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(txt_job.Text), "FE", int.Parse(Session["LoginDivisionId"].ToString()));
                    //    if (rbtcosting.Items[0].Selected == true)
                    //    {
                    //        str_RptName = "FEPreAlertWITHBL.rpt";
                    //        str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {FEJobInfo.jobno}=" + txt_job.Text;
                    //        str_sp = "noofhbl=" + obj_dt.Rows.Count.ToString() + "~totalcbm=" + cbm;
                    //        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Costing", str_Script, true);
                    //        Session["str_sfs"] = str_sf;
                    //        Session["str_sp"] = str_sp;
                    //    }
                    //    else if (rbtcosting.Items[1].Selected == true)
                    //    {
                    //        str_RptName = "FEPreAlertWITHOUTBL.rpt";
                    //        str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {FEJobInfo.jobno}=" + txt_job.Text;
                    //        str_sp = "";
                    //        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Costing", str_Script, true);
                    //        Session["str_sfs"] = str_sf;
                    //        Session["str_sp"] = str_sp;
                    //    }
                    //    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 112, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_job.Text);
                    //}
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

     
        protected void txt_mbl_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Grd_FE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVessel = (Label)e.Row.FindControl("Vessel");
                string tooltip = lblVessel.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblMBL = (Label)e.Row.FindControl("MBL");
                string tooltip1 = lblMBL.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip1);

                Label lblAgent = (Label)e.Row.FindControl("Agent");
                string tooltip2 = lblAgent.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip2);

                Label lblMLO = (Label)e.Row.FindControl("MLO");
                string tooltip3 = lblMLO.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip3);

                Label lblPOL = (Label)e.Row.FindControl("POL");
                string tooltip4 = lblPOL.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip4);

                Label lblPOD = (Label)e.Row.FindControl("POD");
                string tooltip5 = lblPOD.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip5);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_FE, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_AE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAgent = (Label)e.Row.FindControl("Agent");
                string tooltip2 = lblAgent.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip2);
                Label airline = (Label)e.Row.FindControl("airline");
                string tooltip4 = airline.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip4);

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_AE, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_BT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_BT, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_FE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_FE.PageIndex = e.NewPageIndex;
            bind();
            //pln_popup.Visible = true;
        }

        public void bind()
        {
            try { 
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.CostingDt obj_costingdt = new DataAccess.Accounts.CostingDt();
            obj_dt = obj_costingdt.GridFillJobdtls(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            if (obj_dt.Rows.Count > 0)
            {
                this.popup_Grd.Show();
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                {
                    Grd_FE.Visible = true;
                    Grd_FE.DataSource = obj_dt;
                    Grd_FE.DataBind();
                }
                else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                {
                    Grd_AE.Visible = true;
                    Grd_AE.DataSource = obj_dt;
                    Grd_AE.DataBind();
                }
                else if (Session["StrTranType"].ToString() == "BT")
                {
                    Grd_BT.Visible = true;
                    Grd_BT.DataSource = obj_dt;
                    Grd_BT.DataBind();
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    CHGrd.Visible = true;
                    CHGrd.DataSource = obj_dt;
                    CHGrd.DataBind();
                }
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }     
        }

        protected void Grd_AE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            Grd_AE.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void Grd_BT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            Grd_BT.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void CHGrd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblshipper = (Label)e.Row.FindControl("shipper");
                string tooltip = lblshipper.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip);

                Label lblconsignee = (Label)e.Row.FindControl("consignee");
                string tooltip1 = lblconsignee.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip1);

                Label lblpol = (Label)e.Row.FindControl("pol");
                string tooltip2 = lblpol.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip2);

                Label lblpod = (Label)e.Row.FindControl("pod");
                string tooltip3 = lblpod.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip3);

                Label lbldocno = (Label)e.Row.FindControl("docno");
                string tooltip4 = lbldocno.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip4);

                Label lblmdocno = (Label)e.Row.FindControl("mdocno");
                string tooltip5 = lblmdocno.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip5);

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(CHGrd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void CHGrd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CHGrd.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void CHGrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            popup_Grd.Hide();
            try
            {
                //((Label)grd.Rows[Convert.ToInt32(hf_grdbng_index.Value)].Cells[0].FindControl("Booking")).Text;
                txt_job.Text = ((Label)CHGrd.SelectedRow.Cells[0].FindControl("jobno")).Text;
                txt_vsl.Text = ((Label)CHGrd.SelectedRow.Cells[1].FindControl("docno")).Text;
                txt_date.Text = ((Label)CHGrd.SelectedRow.Cells[2].FindControl("docdate")).Text;
                txt_mbl.Text = ((Label)CHGrd.SelectedRow.Cells[3].FindControl("mdocno")).Text;
                txt_agent.Text = ((Label)CHGrd.SelectedRow.Cells[4].FindControl("shipper")).Text;
                txt_mlo.Text = ((Label)CHGrd.SelectedRow.Cells[4].FindControl("consignee")).Text;
              //  txt_mlo.Text = Server.HtmlDecode(((Label)CHGrd.SelectedRow.Cells[5].FindControl("MLO")).Text);
                txt_pol.Text = ((Label)CHGrd.SelectedRow.Cells[6].FindControl("pol")).Text;
                txt_pod.Text = ((Label)CHGrd.SelectedRow.Cells[7].FindControl("pod")).Text;
                txt_mode.Text = ((Label)CHGrd.SelectedRow.Cells[7].FindControl("mode")).Text;
                Fn_LoadGrid();
                //txt_job.Enabled = false;

                int_jobno = int.Parse(txt_job.Text);
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                DataTable obj_dt = new DataTable();
                trantype = Session["StrTranType"].ToString();
                DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                obj_dt = da_obj_Costingdt.GetJobdtls(trantype, int_jobno, int_bid);
                //if (obj_dt.Rows.Count > 0)
                //{
                //    hid_etd.Value = obj_dt.Rows[0]["etd"].ToString();
                //}
                CHGrd.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }
    }
}