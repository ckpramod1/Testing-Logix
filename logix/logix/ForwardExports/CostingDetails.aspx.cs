using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.ForwardExports
{
    public partial class CostingDetails : System.Web.UI.Page
    {
        double blchargewt;
        string blno;
        int cont20;
        int cont40, RC;
        int i;
        int j;
        DateTime Closeddate;
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();
        DataAccess.CostingDetails da_obj_Costing = new DataAccess.CostingDetails();
        DataAccess.CloseJobs da_obj_Closejob = new DataAccess.CloseJobs();
        DataAccess.Accounts.Invoice da_obj_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.OSDNCN da_obj_InvOSDC = new DataAccess.Accounts.OSDNCN();
        DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
        DataAccess.UserPermission user_check = new DataAccess.UserPermission();
        DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
        DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
        DataAccess.CloseJobs JobCloseObj = new DataAccess.CloseJobs();
        int int_bid, int_did, int_jobno = 0, int_Empid;
        string trantype, POl_MSG = "", ICD_DNMsg = "", ICD_CNMsg = "", ICD_Shortname = "", strjobinfo = "";
        DateTime Close_date;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.CostingTemp da_obj_CostTemp = new DataAccess.CostingTemp();
        DataAccess.CostingTemp obj_Costing = new DataAccess.CostingTemp();
        DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();

        DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Invoice obj_dA_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
         DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();

        String strCFSTrantype;
        int Flag, Flagvou;

        string strQry;
        double blamount;
        double blexpense;
        int loguserid;
        int branchid;
        double mblexpense = 0, amont=0;
        double mblCredit = 0;
        double mblamount = 0;
        double mblDebit = 0;
        int jobtype, mlo;
        double totaltues = 0;
        double totalcbm = 0;
        double jobchargewt = 0;
        double blDebit = 0;
        double blCredit = 0;
        int bltues;
        double blcbm = 0;
        char nomination;
        double volume;
        int shipper;
        int consignee;
        int notify;
        int agent;
        int pol;
        int pod;
        int salesperson;
        int dtchk;//new added for reversal
        DataTable dt_MenuRights = new DataTable();
        //int mlo;
        DataTable DtCT = new DataTable();
        DataTable DtJob = new DataTable();
        DataTable DtBL = new DataTable();
        string Str_title = "";
        DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
        int intdays;
        DateTime dt_date;
        DataAccess.Masters.MasterBranch bobj = new DataAccess.Masters.MasterBranch();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                DAdvise.GetDataBase(Ccode);
                da_obj_Costing.GetDataBase(Ccode);
                da_obj_Closejob.GetDataBase(Ccode);
                da_obj_Invoice.GetDataBase(Ccode);
                da_obj_InvOSDC.GetDataBase(Ccode);
                FEJobObj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);

                costtempobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                user_check.GetDataBase(Ccode);
                obj_da_Close.GetDataBase(Ccode);
                da_obj_Costingdt.GetDataBase(Ccode);
                JobCloseObj.GetDataBase(Ccode);
                Appobj.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);

                da_obj_CostTemp.GetDataBase(Ccode);
                obj_Costing.GetDataBase(Ccode);
                obj_da_DC.GetDataBase(Ccode);
                obj_da_Log1.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                obj_da_OSDN.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                obj_dA_Invoice.GetDataBase(Ccode);




                obj_da_Charge.GetDataBase(Ccode);
                obj_da_Ledger.GetDataBase(Ccode);
                obj_da_Cost.GetDataBase(Ccode);
                obj_da_Log1.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                obj_da_OSDN.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                obj_dA_Invoice.GetDataBase(Ccode);



            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Button1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_update);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}

            int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if (ddl_product.Text == "Ocean Exports")
            {
                Session["StrTranType"] = "FE";
                trantype = Session["StrTranType"].ToString();
                //ddl_job_SelectedIndexChanged(sender, e);
                //StrTranType = Session["StrTranType"].ToString();
            }
            else if (ddl_product.Text == "Ocean Imports")
            {
                Session["StrTranType"] = "FI";
                trantype = Session["StrTranType"].ToString();
                //ddl_job_SelectedIndexChanged(sender, e);
                // StrTranType = Session["StrTranType"].ToString();
            }
            else if (ddl_product.Text == "Air Exports")
            {
                Session["StrTranType"] = "AE";
                trantype = Session["StrTranType"].ToString();
                //ddl_job_SelectedIndexChanged(sender, e);
                // StrTranType = Session["StrTranType"].ToString();
            }
            else if (ddl_product.Text == "Air Imports")
            {
                Session["StrTranType"] = "AI";
                trantype = Session["StrTranType"].ToString();
                //ddl_job_SelectedIndexChanged(sender, e);
                // StrTranType = Session["StrTranType"].ToString();
            }
            else if (ddl_product.Text == "CHA")
            {
                Session["StrTranType"] = "CH";
                trantype = Session["StrTranType"].ToString();
                //ddl_job_SelectedIndexChanged(sender, e);
                // StrTranType = Session["StrTranType"].ToString();
            }
            else if (ddl_product.Text == "Bonded Trucking")
            {
                Session["StrTranType"] = "BT";
                trantype = Session["StrTranType"].ToString();
                //ddl_job_SelectedIndexChanged(sender, e);
                // StrTranType = Session["StrTranType"].ToString();
            }

            //else if (ddl_product.Text == "CHA")
            //{
            //    Session["StrTranType"] = "CH";
            //    trantype = Session["StrTranType"].ToString();
            //    //ddl_job_SelectedIndexChanged(sender, e);
            //    // StrTranType = Session["StrTranType"].ToString();
            //}
            //else if (ddl_product.Text == "Bonded Trucking")
            //{
            //    Session["StrTranType"] = "BT";
            //    trantype = Session["StrTranType"].ToString();
            //    //ddl_job_SelectedIndexChanged(sender, e);
            //    // StrTranType = Session["StrTranType"].ToString();
            //}

            if (Session["jobno"] != null)
            {
                crumbsid.Attributes["class"] = "crumbs";
                labelid.Attributes["class"] = "widget-header";
                txt_job.Text = Session["jobno"].ToString();
                lbl_Header.Text = "Job P & L / MIS";
                if (Session["trantype"] != null)
                {
                    trantype = Session["trantype"].ToString();
                }
                //  Hid_trantype.Value=Session["trantype"].ToString();
                //lnk_job.Visible = false;
                if (Session["bid"] != null)
                {
                    int_bid = (int)Session["bid"];
                }
                else
                {
                    int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                }

                if (trantype == "OE")
                {
                    trantype = "FE";
                }
                else if (trantype == "OI")
                {
                    trantype = "FI";
                }
                //Session["StrTranType"] = trantype;
                Hid_trantype.Value = trantype;
                if (Hid_trantype.Value != "")
                {
                    ddl_product.Items.Add("");
                    if (Hid_trantype.Value == "BT")
                    {
                        ddl_product.Items.Add("Bonded Trucking");
                        ddl_product.SelectedValue = "Bonded Trucking";
                    }
                    else if (Hid_trantype.Value == "CH")
                    {
                        ddl_product.Items.Add("CHA");
                        ddl_product.SelectedValue = "CHA";
                    }
                    else if (Hid_trantype.Value == "FE")
                    {
                        ddl_product.Items.Add("Ocean Exports");
                        ddl_product.SelectedValue = "Ocean Exports";
                    }

                    else if (Hid_trantype.Value == "FI")
                    {
                        ddl_product.Items.Add("Ocean Imports");
                        ddl_product.SelectedValue = "Ocean Imports";
                    }
                    else if (Hid_trantype.Value == "AE")
                    {
                        ddl_product.Items.Add("Air Exports");
                        ddl_product.SelectedValue = "Air Exports";
                    }
                    else if (Hid_trantype.Value == "AI")
                    {
                        ddl_product.Items.Add("Air Imports");
                        ddl_product.SelectedValue = "Air Imports";
                    }
                    //ddl_product.SelectedIndex = 1;
                    ddl_product.Enabled = false;

                }

                int_did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                txt_job_TextChanged(sender, e);
                txt_job.Enabled = false;
                txt_date.Enabled = true;
                txt_remark.Visible = false;
                lbl.Visible = false;
                divExport.Visible = false;
                btn_cancel.Visible = false;
                btn_update.Visible = false;divupdate.Visible = false;
                btn_job.Visible = false;btn_job_id.Visible = false;
                ddl_job.Visible = false;
                Session["jobno"] = null;
                Session["trantype"] = null;
                Session["bid"] = null;
                hr1.Visible = false;
                hr2.Visible = false;
                hr3.Visible = false;
                hr4.Visible = false;
                return;
            }
            if (Request.QueryString.ToString().Contains("type"))
            {
                lbl_Header.Text = Request.QueryString["type"].ToString();
                if (lbl_Header.Text == "CFS Job Details")
                {
                    lbl_Header.Text = "Costing with Details";
                }
                if (lbl_Header.Text == "Costing with Details")
                {
                    strCFSTrantype = "FC";
                }
                else
                {
                    strCFSTrantype = "";
                }
                if (lbl_Header.Text == "Job P/L And MIS")
                {
                    lbl_Header.Text = "Job P & L / MIS";
                }
            }

            if (Request.QueryString.ToString().Contains("OECSHOME"))
            {
                crumbsid.Visible = false;
                lbl_Header.Text = "Job P & L / MIS";

            }

            HeaderLabel.InnerText = lbl_Header.Text;

            if (!IsPostBack)
            {
                try
                {
                    DataTable dt_checkamend = new DataTable();
                    //DataAccess.UserPermission user_check = new DataAccess.UserPermission();
                    if (Session["LoginEmpId"] != null)
                    {

                        dt_checkamend = user_check.getcheckrecloserights(Convert.ToInt32(Session["LoginEmpId"]));
                        if (dt_checkamend.Rows.Count > 0)
                        {
                            btn_reclose.Visible = true;
                        }
                        else
                        {
                            btn_reclose.Visible = false;

                        }
                    }
                    else
                    {
                        btn_reclose.Visible = false;
                    }

                    if (Request.QueryString.ToString().Contains("OECSHOMECSP"))
                    {
                        crumbsid.Visible = false;
                        lbl_Header.Text = "Job P & L / MIS";

                        if (Request.QueryString.ToString().Contains("jobno1"))
                        {
                            int_jobno = Convert.ToInt32(Request.QueryString["jobno1"].ToString());
                        }

                        /* if (string.IsNullOrEmpty(Request.QueryString["jobno"].ToString()) == false)
                         {
                             int_jobno = Convert.ToInt32(Request.QueryString["jobno"].ToString());

                         }*/

                        if (Session["trantype_process"] != null)
                        {
                            dt_MenuRights = Session["trantype_process"] as DataTable;
                            ddl_product.Items.Add("");

                            Session["StrTranType"] = null;
                            for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                            {
                                if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                                {
                                    ddl_product.Items.Add("Air Exports");
                                }
                                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                                {
                                    ddl_product.Items.Add("Air Imports");
                                }
                                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                                {
                                    ddl_product.Items.Add("Ocean Exports");
                                }
                                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                                {
                                    ddl_product.Items.Add("Ocean Imports");
                                }
                                //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
                                //{
                                //    ddl_product.Items.Add("CHA");
                                //}
                                //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
                                //{
                                //    ddl_product.Items.Add("Bonded Trucking");
                                //}

                            }
                            // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                        }
                        else if (Session["StrTranType"] != null)
                        {
                            ddl_product.Items.Add("");
                            if (Session["StrTranType"].ToString() == "BT")
                            {
                                ddl_product.Items.Add("Bonded Trucking");
                                ddl_product.SelectedValue = "Bonded Trucking";
                            }
                            else if (Session["StrTranType"].ToString() == "CH")
                            {
                                ddl_product.Items.Add("CHA");
                                ddl_product.SelectedValue = "CHA";
                            }
                            else if (Session["StrTranType"].ToString() == "FE")
                            {
                                ddl_product.Items.Add("Ocean Exports");
                                ddl_product.SelectedValue = "Ocean Exports";
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                ddl_product.Items.Add("Ocean Imports");
                                ddl_product.SelectedValue = "Ocean Imports";
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                ddl_product.Items.Add("Air Exports");
                                ddl_product.SelectedValue = "Air Exports";
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                ddl_product.Items.Add("Air Imports");
                                ddl_product.SelectedValue = "Air Imports";
                            }
                            //ddl_product.SelectedIndex = 1;
                            ddl_product.Enabled = false;

                            trantype = Session["StrTranType"].ToString();

                        }

                        string type1 = Request.QueryString["OECSHOMECSP"].ToString();
                        if (type1 == "FE")
                        {
                            ddl_product.Text = "Ocean Exports";
                        }
                        else if (type1 == "FI")
                        {
                            ddl_product.Text = "Ocean Imports";
                        }
                        else if (type1 == "AE")
                        {
                            ddl_product.Text = "Air Exports";
                        }
                        else if (type1 == "AI")
                        {
                            ddl_product.Text = "Air Imports";
                        }
                        ddl_product.Enabled = false;
                        //lbl_header.Text = str_FornName;
                        Session["StrTranType"] = type1;
                        trantype = Session["StrTranType"].ToString();

                        int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                        int_did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                        int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());

                        if (lbl_Header.Text == "Job P & L / MIS")
                        {
                            divExport.Visible=false;
                            btn_Export.Visible = false;
                            strjobinfo = trantype + "JobInfo";
                            //lnk_job.Visible = false;
                            //  ddl_job.Text = "Unclosed Jobs";
                            ddl_job.Text = "Unclosed Jobs";
                            //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
                            DataTable obj_dt = new DataTable();

                            if (ddl_product.SelectedIndex != 0)
                            {
                                if (trantype == "FE" || trantype == "FI")
                                {
                                    Grd_FEFI.Visible = true;
                                    P2.Visible = true;
                                    obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                                    Grd_FEFI.DataSource = obj_dt;
                                    Grd_FEFI.DataBind();
                                }
                                else if (trantype == "AE" || trantype == "AI")
                                {
                                    Grd_AEAI.Visible = true;
                                    //P3.Visible = true;
                                    obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                                    Grd_AEAI.DataSource = obj_dt;
                                    Grd_AEAI.DataBind();
                                }
                                else if (trantype == "CH")
                                {
                                    Grd_CH.Visible = true;
                                    P4.Visible = true;
                                    obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                                    Grd_CH.DataSource = obj_dt;
                                    Grd_CH.DataBind();
                                }
                                else if (trantype == "BT")
                                {
                                    Grd_BT.Visible = true;
                                    P5.Visible = true;
                                    obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                                    Grd_BT.DataSource = obj_dt;
                                    Grd_BT.DataBind();
                                }
                            }

                            btn_update.Text = "Close";
                            btn_update.ToolTip = "Close";
                            divupdate.Attributes["class"] = "btn ico-job-close";

                        }
                        else
                        {
                            lnk_job.Visible = true;
                            txt_date.Visible = true;
                            Grd_FEFI.Visible = false;
                            P2.Visible = false;
                            Grd_AEAI.Visible = false;
                            P3.Visible = false;
                            Grd_CH.Visible = false;
                            P4.Visible = false;
                            Grd_BT.Visible = false;
                            P5.Visible = false;
                            btn_update.Visible = false;divupdate.Visible = false;
                            ddl_job.Visible = false;
                            grdclsjob.Visible = true;
                            P8.Visible = false;
                            btn_cancel.Text = "Cancel";
                            btn_cancel.ToolTip = "Cancel";
                            btn_cancel1.Attributes["class"] = "btn ico-cancel";
                            GridView1.Visible = false;
                            lbl.Visible = false;
                            btn_job.Visible = false;btn_job_id.Visible = false;
                            hr1.Visible = false;
                            hr2.Visible = false;
                            strCFSTrantype = "FC";
                            Grd_job.Visible = false;
                        }

                        txt_job.Text = int_jobno.ToString();
                        txt_job_TextChanged(sender, e);

                        return;

                    }

                    if (Session["trantype_process"] != null)
                    {
                        dt_MenuRights = Session["trantype_process"] as DataTable;
                        ddl_product.Items.Add("");

                        Session["StrTranType"] = null;
                        for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                        {
                            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                            {
                                ddl_product.Items.Add("Air Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                            {
                                ddl_product.Items.Add("Air Imports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                            {
                                ddl_product.Items.Add("Ocean Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                            {
                                ddl_product.Items.Add("Ocean Imports");
                            }
                            
                            //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
                            //{
                            //    ddl_product.Items.Add("CHA");
                            //}
                            //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
                            //{
                            //    ddl_product.Items.Add("Bonded Trucking");
                            //}

                        }
                        // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                    }
                    else if (Session["StrTranType"] != null)
                    {
                        ddl_product.Items.Add("");
                        if (Session["StrTranType"].ToString() == "BT")
                        {
                            ddl_product.Items.Add("Bonded Trucking");
                            ddl_product.SelectedValue = "Bonded Trucking";
                        }
                        else if (Session["StrTranType"].ToString() == "CH")
                        {
                            ddl_product.Items.Add("CHA");
                            ddl_product.SelectedValue = "CHA";
                        }
                        else if (Session["StrTranType"].ToString() == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                            ddl_product.SelectedValue = "Ocean Exports";
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                            ddl_product.SelectedValue = "Ocean Imports";
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                            ddl_product.SelectedValue = "Air Exports";
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                            ddl_product.SelectedValue = "Air Imports";
                        }
                        //ddl_product.SelectedIndex = 1;
                        ddl_product.Enabled = false;

                        trantype = Session["StrTranType"].ToString();

                    }

                    if (Request.QueryString.ToString().Contains("OECSHOME"))
                    {

                        string type1 = Request.QueryString["OECSHOME"].ToString();
                        if (type1 == "FE")
                        {
                            ddl_product.Text = "Ocean Exports";
                        }
                        else if (type1 == "FI")
                        {
                            ddl_product.Text = "Ocean Imports";
                        }
                        else if (type1 == "AE")
                        {
                            ddl_product.Text = "Air Exports";
                        }
                        else if (type1 == "AI")
                        {
                            ddl_product.Text = "Air Imports";
                        }
                        ddl_product.Enabled = false;
                        //lbl_header.Text = str_FornName;
                        Session["StrTranType"] = type1;
                        trantype = Session["StrTranType"].ToString();
                        // ddl_job_SelectedIndexChanged(sender, e);
                    }
                    //else
                    //{
                    //    trantype = Session["StrTranType"].ToString();
                    //}

                    Grdcost.DataSource = new DataTable();
                    Grdcost.DataBind();

                    GridView1.Attributes.Add("style", "word-break:normal ;word-wrap:none ;");
                    //txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    //dt_date = obj_da_Log.GetDate();
                    //intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    //txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    //dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                    //Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                    ////if (Session["LoginBranchid"].ToString() != "3")
                    ////{
                    //if ((Close_date.Day) <= intdays)
                    //{
                    //    txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());
                      
                    //}
                    //else
                    //{
                    //    txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    //}

                    // trantype = Session["StrTranType"].ToString();
                    int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    int_did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                   // string Str_title = "";
                    if (Str_title != "")
                    {

                        if (string.IsNullOrEmpty(Request.QueryString["branchid"].ToString()) == false)
                        {
                            int_bid = Convert.ToInt32(Request.QueryString["branchid"].ToString());
                        }
                        if (string.IsNullOrEmpty(Request.QueryString["divisionid"].ToString()) == false)
                        {
                            int_did = Convert.ToInt32(Request.QueryString["divisionid"].ToString());
                        }
                        if (string.IsNullOrEmpty(Request.QueryString["trantype"].ToString()) == false)
                        {
                            trantype = Request.QueryString["trantype"].ToString();
                        }
                        if (string.IsNullOrEmpty(Request.QueryString["jobno"].ToString()) == false)
                        {
                            int_jobno = Convert.ToInt32(Request.QueryString["jobno"].ToString());
                        }
                        //btn_update.Visible = false;divupdate.Visible = false;
                        if (Str_title == "BLvoucher")
                        {
                            divupdate.Visible = false;
                            divExport.Attributes["class"] = "div_btnupdate";
                            btn_job.Visible = false;btn_job_id.Visible = false;
                            ddl_job.Visible = false;
                            lbl.Visible = false;
                            //lbl_date.Visible = false;
                            txt_date.Visible = true;
                            div_vsl.Visible = false;
                            Grd_job.Visible = false;
                            P1.Visible = false;
                        }
                        else
                        {
                            div_vsl.Visible = true;
                            div_remark.Visible = false;
                            btn_job.Visible = false;btn_job_id.Visible = false;
                            ddl_job.Visible = false;
                            txt_job.Enabled = false;
                            txt_date.Enabled = true;
                            Grd_job.Visible = true;
                            P1.Visible = true;

                        }

                        txt_job.Text = int_jobno.ToString();
                        txt_job_TextChanged(sender, e);
                    }
                    else
                    {
                        if (lbl_Header.Text == "Job P & L / MIS")
                        {
                            divExport.Visible = false;
                            btn_Export.Visible = false;
                            strjobinfo = trantype + "JobInfo";
                            //lnk_job.Visible = false;
                            //  ddl_job.Text = "Unclosed Jobs";
                            ddl_job.Text = "Open Jobs";
                            //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
                            DataTable obj_dt = new DataTable();

                            if (ddl_product.SelectedIndex != 0)
                            {
                                if (trantype == "FE" || trantype == "FI")
                                {
                                    Grd_FEFI.Visible = true;
                                    P2.Visible = true;
                                    obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                                    Grd_FEFI.DataSource = obj_dt;
                                    Grd_FEFI.DataBind();
                                }
                                else if (trantype == "AE" || trantype == "AI")
                                {
                                    Grd_AEAI.Visible = true;
                                    //P3.Visible = true;
                                    obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                                    Grd_AEAI.DataSource = obj_dt;
                                    Grd_AEAI.DataBind();
                                }
                                else if (trantype == "CH")
                                {
                                    Grd_CH.Visible = true;
                                    P4.Visible = true;
                                    obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                                    Grd_CH.DataSource = obj_dt;
                                    Grd_CH.DataBind();
                                }
                                else if (trantype == "BT")
                                {
                                    Grd_BT.Visible = true;
                                    P5.Visible = true;
                                    obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                                    Grd_BT.DataSource = obj_dt;
                                    Grd_BT.DataBind();
                                }
                            }

                            btn_update.Text = "Close";
                            btn_update.ToolTip = "Close";
                            divupdate.Attributes["class"] = "btn ico-job-close";

                        }
                        else
                        {
                            lnk_job.Visible = true;
                            txt_date.Visible = true;
                            Grd_FEFI.Visible = false;
                            P2.Visible = false;
                            Grd_AEAI.Visible = false;
                            P3.Visible = false;
                            Grd_CH.Visible = false;
                            P4.Visible = false;
                            Grd_BT.Visible = false;
                            P5.Visible = false;
                            btn_update.Visible = false;divupdate.Visible = false;
                            ddl_job.Visible = false;
                            grdclsjob.Visible = true;
                            P8.Visible = false;
                            btn_cancel.Text = "Cancel";
                            btn_cancel.ToolTip = "Cancel";
                            btn_cancel1.Attributes["class"] = "btn ico-cancel";
                            GridView1.Visible = false;
                            lbl.Visible = false;
                            btn_job.Visible = false;btn_job_id.Visible = false;
                            hr1.Visible = false;
                            hr2.Visible = false;
                            strCFSTrantype = "FC";
                            Grd_job.Visible = false;
                        }

                    }
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
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
            /* if (Session["StrTranType"] != null)
             {
                 if (Session["StrTranType"].ToString() == "FE")
                 {
                     headerlable1.InnerText = "OceanExports";
                     if (lbl_Header.Text == "Job Closing")
                     {
                         headerlabel2.InnerText = "Utility";
                     }
                 }
                 else if (Session["StrTranType"].ToString() == "FI")
                 {
                     headerlable1.InnerText = "OceanImports";
                     if (lbl_Header.Text == "CFS Job Details")
                     {
                         headerlabel2.InnerText = "Utility";
                     }
                     else if (lbl_Header.Text == "Job Closing")
                     {
                         headerlabel2.InnerText = "Utility";
                     }
                 }
                 else if (Session["StrTranType"].ToString() == "AE")
                 {
                     headerlable1.InnerText = "AirExports";
                     if (lbl_Header.Text == "Job Closing")
                     {
                         headerlabel2.InnerText = "Utility";
                     }

                 }
                 else if (Session["StrTranType"].ToString() == "AI")
                 {
                     headerlable1.InnerText = "AirImports";
                     if (lbl_Header.Text == "Job Closing")
                     {
                         headerlabel2.InnerText = "Utility";
                     }
                 }
                 else if (Session["StrTranType"].ToString() == "CH")
                 {
                     headerlable1.InnerText = "Custom House Agent";
                     if (lbl_Header.Text == "Job Closing")
                     {
                         headerlabel2.InnerText = "Utility";

                     }
                     else if (lbl_Header.Text == "Costing Details")
                     {
                         headerlabel2.InnerText = "Approval";
                     }
                 }
                 else if (Session["StrTranType"].ToString() == "BT")
                 {
                     headerlable1.InnerText = "Bonded Trucking";
                     if (lbl_Header.Text == "Job Closing")
                     {
                         headerlabel2.InnerText = "Utility";

                     }
                     else if (lbl_Header.Text == "Costing Details")
                     {
                         headerlabel2.InnerText = "Approval";
                     }
                 }
             }*/

        }

        protected void ddlproduct_select()
        {

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
        protected void lnk_job_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    return;
                }
                GridView1.Visible = true;
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                //DataAccess.CloseJobs JobCloseObj = new DataAccess.CloseJobs();
                //string Ccode = Request.QueryString["Ccode"].ToString();               

                //    da_obj_Costingdt.GetDataBase(Ccode);

                    trantype = Session["StrTranType"].ToString();
                int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                if (trantype == "FE" || trantype == "FI" || trantype == "AE" || trantype == "AI")
                {
                    obj_dt = da_obj_Costingdt.GridFillJobdtls(trantype, int_bid);
                    if (obj_dt.Rows.Count <= 0)
                    {
                        // DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                        // DataTable obj_dt = new DataTable();
                        // obj_dt = obj_da_jobinfo.GetJobNoList(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "JobInfo", "alertify.alert('Job Not Available');", true);
                        return;
                    }
                    else
                    {
                        popup_Grd.Show();
                        GridView1.DataSource = obj_dt;
                        GridView1.DataBind();
                        ViewState["GridView1"] = obj_dt;
                    }
                }
                else if (trantype == "CH")
                {

                    obj_dt = da_obj_Costingdt.GridFillJobdtls(trantype, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        popup_Grd.Show();
                        CHGrid.DataSource = obj_dt;
                        CHGrid.DataBind();
                        CHGrid.Visible = true;
                        ViewState["CHGrid"] = obj_dt;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "JobInfo", "alertify.alert('Job Not Available');", true);
                        return;
                    }

                }
                else if (trantype == "BT")
                {

                    obj_dt = da_obj_Costingdt.GridFillJobdtls(trantype, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        popup_Grd.Show();
                        BTGrid.DataSource = obj_dt;
                        BTGrid.DataBind();
                        BTGrid.Visible = true;
                        ViewState["BTGrid"] = obj_dt;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "JobInfo", "alertify.alert('Job Not Available');", true);
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

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textclear();
                int i;
                //if (Request.QueryString.ToString().Contains("type"))
                //{
                //    lbl_Header.Text = Request.QueryString["type"].ToString();

                //    if (lbl_Header.Text == "Costing with Details")
                //    {
                //        strCFSTrantype = "FC";
                //        Grd_job.Visible = false;
                //    }
                //    else
                //    {
                //        strCFSTrantype = "";
                //    }
                //}
                //dt_date = obj_da_Log.GetDate();
                //intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                //txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                //dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                //Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                
                //if ((Close_date.Day) <= intdays)
                //{
                //    txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());

                //}
                //else
                //{
                //    txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                //}

                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    return;
                }

                if (lbl_Header.Text == "Costing with Details")
                {
                    strCFSTrantype = "FC";
                    Grd_job.Visible = false;
                    P1.Visible = false;
                }
                else
                {
                    strCFSTrantype = "";
                }
                Image3.Visible = true;
                int_jobno = Convert.ToInt32(txt_job.Text);
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                //DataAccess.CloseJobs JobCloseObj = new DataAccess.CloseJobs();

                if (strCFSTrantype == "FC")
                {
                    trantype = "FI";
                }
                if (trantype == "OE")
                {
                    trantype = "FE";
                }

                if (trantype == "OI")
                {
                    trantype = "FI";
                }

                if (trantype == "FE" || trantype == "FI" || trantype == "AE" || trantype == "AI" )
                {
                    obj_dt = da_obj_Costingdt.GetJobdtls(trantype, int_jobno, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        if (Request.QueryString.ToString().Contains("Title") == false)
                        {
                            txt_vsl.Text = obj_dt.Rows[0][0].ToString();
                            if (trantype == "FE" || trantype == "FI")
                            {
                                txt_mbl.Text = obj_dt.Rows[0][2].ToString();
                                txt_eta.Text = obj_dt.Rows[0][1].ToString();
                            }
                            else
                            {
                                txt_mbl.Text = obj_dt.Rows[0][1].ToString();
                                txt_eta.Text = obj_dt.Rows[0][2].ToString();
                            }
                            txt_pol.Text = obj_dt.Rows[0][5].ToString();
                            txt_pod.Text = obj_dt.Rows[0][6].ToString();
                            txt_agent.Text = obj_dt.Rows[0][3].ToString();
                            txt_mlo.Text = obj_dt.Rows[0][4].ToString();
                        }
                        if (string.IsNullOrEmpty(obj_dt.Rows[0]["jobcloseremarks"].ToString()) == false)
                        {
                            txt_remark.Text = obj_dt.Rows[0]["jobcloseremarks"].ToString();
                        }
                        else
                        {
                            txt_remark.Text = "";
                        }
                        btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }
                else if (trantype == "CH")               
                {
                    obj_dt = da_obj_Costingdt.GetJobdtls(trantype, int_jobno, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        if (Request.QueryString.ToString().Contains("Title") == false)
                        {
                            txt_vsl.Text = obj_dt.Rows[0][0].ToString();
                            if (trantype == "FE" || trantype == "FI")
                            {
                                txt_mbl.Text = obj_dt.Rows[0][2].ToString();
                                txt_eta.Text = obj_dt.Rows[0][1].ToString();
                            }
                            else
                            {
                                txt_mbl.Text = obj_dt.Rows[0][1].ToString();
                                txt_eta.Text = obj_dt.Rows[0][2].ToString();
                            }
                            txt_pol.Text = obj_dt.Rows[0][5].ToString();
                            txt_pod.Text = obj_dt.Rows[0][6].ToString();
                            txt_agent.Text = obj_dt.Rows[0][3].ToString();
                            txt_mlo.Text = obj_dt.Rows[0][4].ToString();
                        }
                        if (string.IsNullOrEmpty(obj_dt.Rows[0]["jobcloseremarks"].ToString()) == false)
                        {
                            txt_remark.Text = obj_dt.Rows[0]["jobcloseremarks"].ToString();
                        }
                        else
                        {
                            txt_remark.Text = "";
                        }
                        btn_cancel.Text = "Cancel";
                      
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }

                obj_dt.Reset();

                            if (strCFSTrantype == "FC")
                {
                    obj_dt = da_obj_Costing.CostingDetail(Convert.ToInt32(txt_job.Text), strCFSTrantype, int_bid);
                }
                //else
                //{
                //    obj_dt = da_obj_Costing.CostingDetail(Convert.ToInt32(txt_job.Text), trantype, int_bid);
                //}

                //newly added for reversal 24Nov2021
                else
                {
                    dtchk = da_obj_Costing.Jobclosingdatechk(Convert.ToInt32(txt_job.Text), trantype, int_bid);
                    if (dtchk == 0)
                    {
                        obj_dt = da_obj_Costing.CostingDetail(Convert.ToInt32(txt_job.Text), trantype, int_bid);
                    }
                    else if (dtchk == 1)
                    {
                        obj_dt = da_obj_Costing.Costingshipmentdetails(Convert.ToInt32(txt_job.Text), trantype, int_bid); //newlyadded4reversal
                    }
                }

                if (obj_dt.Rows.Count > 0)
                {
                    Grdcost.DataSource = obj_dt;
                    Grdcost.DataBind();

                    obj_dt.Reset();
                    obj_dt = da_obj_Closejob.CheckJobClosedORNot(Convert.ToInt32(txt_job.Text), trantype, int_bid);
                    //if (hid_customerid.Value!="")
                    //{

                    //}
                    if (obj_dt.Rows.Count > 0)
                    {
                        lbl.Text = obj_dt.Rows[0]["Column1"].ToString();
                      //  txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);

                      //  dt_date = obj_da_Log.GetDate();
                      // //// intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                      // //// txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                      // //// dt_date = dt_date.AddDays(-intdays);
                      //Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                       // //if (Session["LoginBranchid"].ToString() != "3")
                       // //{
                       // txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                        //if ((Close_date.Day) <= intdays)
                        //{
                        //    txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());

                        //}
                        //else
                        //{
                        //    txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                        //}

                    }
                    if (lbl_Header.Text == "Job P & L / MIS")
                    {
                        if (lbl.Text == "Job Status : Closed")
                        {
                            Image3.ImageUrl = "../images/close.png";
                            btn_update.Enabled = false;
                            btn_update.ForeColor = System.Drawing.Color.Gray;
                            obj_dt = da_obj_Closejob.CheckJobClosedORNot(Convert.ToInt32(txt_job.Text), trantype, int_bid);
                            //if (hid_customerid.Value!="")
                            //{

                            //}
                            if (obj_dt.Rows.Count > 0)
                            {
                                lbl.Text = obj_dt.Rows[0]["Column1"].ToString();
                                txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                                dt_date = obj_da_Log.GetDate();                                                                 
                                Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                                
                                

                            }
                            obj_dttemp = da_obj_Costing.BLCosting(int_jobno, trantype, int_bid);
                            if (obj_dttemp.Rows.Count > 0)
                            {
                                var sum_Income = obj_dttemp.Compute("sum(income)", "");
                                var sum_Expense = obj_dttemp.Compute("sum(expense)", "");
                                var sum_Retention = obj_dttemp.Compute("sum(retention)", "");

                                DataRow dr = obj_dttemp.NewRow();
                                obj_dttemp.Rows.Add(dr);
                                dr[2] = "Total";
                                dr[3] = sum_Income;
                                dr[4] = sum_Expense;
                                dr[5] = sum_Retention;

                                Grd_job.DataSource = obj_dttemp;
                                Grd_job.DataBind();

                                if (string.IsNullOrEmpty(obj_dt.Rows[0]["Column3"].ToString()) == false)
                                {
                                    txt_remark.Text = String.Format("{0:d}", obj_dt.Rows[0]["Column3"]);
                                }
                                else
                                {
                                    txt_remark.Text = "";
                                }
                                if (trantype == "FE" || trantype == "FI")
                                {
                                    Grd_FEFI.Visible = true;
                                    P2.Visible = true;

                                }
                                else if (trantype == "AE" || trantype == "AI")
                                {
                                    Grd_AEAI.Visible = true;
                                    //P3.Visible = true;
                                }
                                else if (trantype == "CH")
                                {
                                    Grd_CH.Visible = true;
                                    P4.Visible = true;
                                }

                                //  Grd_job.Visible = false;
                                if (lbl_Header.Text == "Costing with Details")
                                {
                                    Grd_job.Visible = false;
                                    P1.Visible = false;
                                }
                                else if (lbl_Header.Text == "Job P & L / MIS")
                                {
                                    Grd_job.Visible = true;
                                     P1.Visible = true;               //Dinesh
                                    //Grd_CH.Visible = false;
                                    // P4.Visible = false;
                                    //P2.Visible = false;
                                        P2.Visible = false;                       //Dinesh
                                    Grd_FEFI.Visible = false;
                                    P3.Visible = false;
                                    P4.Visible = false;
                                    P5.Visible = false;
                                }
                                else
                                {
                                    Grd_job.Visible = false;
                                    P1.Visible = false;
                                }

                            }

                            else                                              //Dinesh
                            {
                                // Grd_job.Visible = true;
                                Grd_FEFI.Visible = false;
                                P2.Visible = false;
                                Grd_AEAI.Visible = false;
                                P3.Visible = false;
                                Grd_CH.Visible = false;
                                P4.Visible = false;

                                if (lbl_Header.Text == "Costing with Details")
                                {
                                    Grd_job.Visible = false;
                                    P1.Visible = false;
                                }
                                else if (trantype == "FE" && lbl_Header.Text == "Job P & L / MIS")
                                {

                                    grdclsjob.Visible = true;
                                    P8.Visible = true;
                                    grdclsjob.DataSource = new DataTable();
                                    grdclsjob.DataBind();
                                }
                                else if (trantype == "FI" && lbl_Header.Text == "Job P & L / MIS")
                                {
                                    grdclsjob.Visible = true;
                                    P8.Visible = true;
                                    grdclsjob.DataSource = new DataTable();
                                    grdclsjob.DataBind();
                                }
                                else if (trantype == "BT" && lbl_Header.Text == "Costing Details")
                                {
                                    Grd_job.Visible = false;
                                    P1.Visible = false;
                                    grdclsjob.DataSource = new DataTable();
                                    grdclsjob.DataBind();
                                }
                                else if (trantype == "BT" && lbl_Header.Text == "Job P & L / MIS")
                                {
                                    grdclsjob.Visible = true;
                                    P8.Visible = true;
                                    grdclsjob.DataSource = new DataTable();
                                    grdclsjob.DataBind();
                                    Grd_BT.Visible = false;
                                    P5.Visible = false;
                                    btn_confirm.Visible = true;idconfirm.Visible = true;
                                }
                                else if (trantype == "CH" && lbl_Header.Text == "Job P & L / MIS")
                                {
                                    grdclsjob.Visible = true;
                                    P8.Visible = true;
                                    grdclsjob.DataSource = new DataTable();
                                    grdclsjob.DataBind();
                                    Grd_CH.Visible = false;
                                    P4.Visible = false;
                                    btn_confirm.Visible = true;idconfirm.Visible = true;
                                }
                                else if (trantype == "AE" && lbl_Header.Text == "Job P & L / MIS")
                                {
                                    grdclsjob.Visible = true;
                                    P8.Visible = true;
                                    grdclsjob.DataSource = new DataTable();
                                    grdclsjob.DataBind();
                                    Grd_CH.Visible = false;
                                    P4.Visible = false;
                                    btn_confirm.Visible = true;idconfirm.Visible = true;
                                }
                                else if (trantype == "AI" && lbl_Header.Text == "Job P & L / MIS")
                                {
                                    grdclsjob.Visible = true;
                                    P8.Visible = true;
                                    grdclsjob.DataSource = new DataTable();
                                    grdclsjob.DataBind();
                                    Grd_CH.Visible = false;
                                    P4.Visible = false;
                                    btn_confirm.Visible = true;idconfirm.Visible = true;
                                }
                                else
                                {
                                    Grd_job.Visible = true;
                                    P1.Visible = true;
                                }

                                int empid = Convert.ToInt32(Session["LoginEmpId"]);
                                int_jobno = Convert.ToInt32(txt_job.Text);
                                CostingTemp4JobBLwise(txt_job.Text, trantype);
                                DataSet dsclsjob = new DataSet();
                                DataTable dtclstot = new DataTable();
                                DataTable dtclsjob = new DataTable();
                                dsclsjob = JobCloseObj.SelCostingTempRpt4JobBLwise(int_jobno, trantype, int_bid, empid);

                                dtclsjob = dsclsjob.Tables[0];
                                dtclstot = dsclsjob.Tables[1];
                                //Dinesh
                                //if (dtclsjob.Rows.Count > 0)
                                //{
                                //    grdclsjob.DataSource = dtclsjob;
                                //    grdclsjob.DataBind();
                                //}

                                //dtclstot = dtclsjob;
                                //DataRow dr = dt;
                                DataTable dtemptyfree = new DataTable();
                                // dtemptyfree.Columns.Add("Name", typeof(CheckBoxField));
                                dtemptyfree.Columns.Add("jobno");
                                dtemptyfree.Columns.Add("bookingno");
                                dtemptyfree.Columns.Add("blno");
                                dtemptyfree.Columns.Add("empname");
                                dtemptyfree.Columns.Add("vol");
                                dtemptyfree.Columns.Add("inc");
                                dtemptyfree.Columns.Add("exp");
                                dtemptyfree.Columns.Add("blrelease");
                                dtemptyfree.Columns.Add("port");
                                dtemptyfree.Columns.Add("Income");
                                dtemptyfree.Columns.Add("Expense");
                                dtemptyfree.Columns.Add("Retention");
                                DataRow dr = dtemptyfree.NewRow();
                                if (dtclsjob.Rows.Count > 0)
                                {
                                    double total1 = 0, total2 = 0, total3 = 0;

                                    for (int j = 0; j <= dtclsjob.Rows.Count - 1; j++)
                                    {
                                        dtemptyfree.Rows.Add();
                                        dr = dtemptyfree.NewRow();
                                        int count = dtemptyfree.Rows.Count - 1;
                                        dtemptyfree.Rows[count]["jobno"] = dtclsjob.Rows[j]["jobno"].ToString();
                                        dtemptyfree.Rows[count]["bookingno"] = dtclsjob.Rows[j]["bookingno"].ToString();
                                        dtemptyfree.Rows[count]["blno"] = dtclsjob.Rows[j]["blno"].ToString();
                                        dtemptyfree.Rows[count]["empname"] = dtclsjob.Rows[j]["empname"].ToString();
                                        //CheckBox chkvol = FindControl("vol") as CheckBox;
                                        /*  CheckBox chkvol = (grdclsjob.Rows[j].FindControl("vol") as CheckBox);
                                          if ((Convert.ToBoolean(dtclsjob.Rows[j]["volumeconf"]) == false))
                                          {
                                              chkvol.Checked = false;
                                          }
                                          else
                                          {
                                              chkvol.Checked = true;
                                          }
                                          //CheckBox chkvol1 = FindControl("inc") as CheckBox;
                                          CheckBox chkvol1 = (grdclsjob.Rows[j].FindControl("inc") as CheckBox);
                                          if (dtclsjob.Rows[j]["incomeconf"].ToString() == "false")
                                          {
                                              chkvol1.Checked = false;
                                          }
                                          else
                                          {
                                              chkvol1.Checked = true;
                                          }
                                          // CheckBox chkvol2 = FindControl("exp") as CheckBox;
                                          CheckBox chkvol2 = (grdclsjob.Rows[j].FindControl("exp") as CheckBox);
                                          if (dtclsjob.Rows[j]["expenseconf"].ToString() == "false")
                                          {
                                              chkvol2.Checked = false;
                                          }
                                          else
                                          {
                                              chkvol2.Checked = true;
                                          }
                                          // CheckBox chkvol3 = FindControl("blrelease") as CheckBox;
                                          CheckBox chkvol3 = (grdclsjob.Rows[j].FindControl("blrelease") as CheckBox);
                                          if (dtclsjob.Rows[j]["blreleaseconf"].ToString() == "false")
                                          {
                                              chkvol3.Checked = false;
                                          }
                                          else
                                          {
                                              chkvol3.Checked = true;
                                          }
                                          // CheckBox chkvol4 = FindControl("port") as CheckBox;
                                          CheckBox chkvol4 = (grdclsjob.Rows[j].Cells[j].FindControl("port") as CheckBox);
                                          if (dtclsjob.Rows[j]["destconf"].ToString() == "false")
                                          {
                                              chkvol4.Checked = false;
                                          }
                                          else
                                          {
                                              chkvol4.Checked = true;
                                          }*/
                                        total1 = total1 + Convert.ToDouble(dtclsjob.Rows[j]["Income"].ToString());
                                        dtemptyfree.Rows[count]["Income"] = dtclsjob.Rows[j]["Income"].ToString();
                                        total2 = total2 + Convert.ToDouble(dtclsjob.Rows[j]["Expense"].ToString());
                                        dtemptyfree.Rows[count]["Expense"] = dtclsjob.Rows[j]["Expense"].ToString();
                                        total3 = total3 + Convert.ToDouble(dtclsjob.Rows[j]["Retention"].ToString());
                                        dtemptyfree.Rows[count]["Retention"] = dtclsjob.Rows[j]["Retention"].ToString();
                                        //CheckBox chkvol=FindControl(vol)
                                    } dr = dtemptyfree.NewRow();
                                    dtemptyfree.Rows.Add(dr);
                                    dr["empname"] = "Total";
                                    dr["Income"] = total1.ToString();
                                    dr["Expense"] = total2.ToString();
                                    dr["Retention"] = total3.ToString();
                                    grdclsjob.DataSource = dtemptyfree;
                                    grdclsjob.DataBind();
                                    /* for (int j = 0; j <= dtclsjob.Rows.Count - 1; j++)
                                     {
                                         CheckBox chkvol = (grdclsjob.Rows[j].FindControl("vol") as CheckBox);
                                         if ((Convert.ToBoolean(dtclsjob.Rows[j]["volumeconf"]) == false))
                                         {
                                             chkvol.Checked = false;
                                         }
                                         else
                                         {
                                             chkvol.Checked = true;
                                         }
                                         //CheckBox chkvol1 = FindControl("inc") as CheckBox;
                                         CheckBox chkvol1 = (grdclsjob.Rows[j].Cells[j].FindControl("inc") as CheckBox);
                                         if (Convert.ToBoolean(dtclsjob.Rows[j]["incomeconf"].ToString()) == false)
                                         {
                                             chkvol1.Checked = false;
                                         }
                                         else
                                         {
                                             chkvol1.Checked = true;
                                         }
                                         // CheckBox chkvol2 = FindControl("exp") as CheckBox;
                                         CheckBox chkvol2 = (grdclsjob.Rows[j].Cells[j].FindControl("exp") as CheckBox);
                                         if (Convert.ToBoolean(dtclsjob.Rows[j]["expenseconf"].ToString()) == false)
                                         {
                                             chkvol2.Checked = false;
                                         }
                                         else
                                         {
                                             chkvol2.Checked = true;
                                         }
                                         // CheckBox chkvol3 = FindControl("blrelease") as CheckBox;
                                         CheckBox chkvol3 = (grdclsjob.Rows[j].Cells[j].FindControl("blrelease") as CheckBox);
                                         if (Convert.ToBoolean(dtclsjob.Rows[j]["blreleaseconf"].ToString()) == false)
                                         {
                                             chkvol3.Checked = false;
                                         }
                                         else
                                         {
                                             chkvol3.Checked = true;
                                         }
                                         // CheckBox chkvol4 = FindControl("port") as CheckBox;
                                         CheckBox chkvol4 = (grdclsjob.Rows[j].Cells[j].FindControl("port") as CheckBox);
                                         if (Convert.ToBoolean(dtclsjob.Rows[j]["destconf"].ToString()) == false)
                                         {
                                             chkvol4.Checked = false;
                                         }
                                         else
                                         {
                                             chkvol4.Checked = true;
                                         }
                                     }*/

                                    for (int j = 0; j <= dtclsjob.Rows.Count - 1; j++)
                                    {
                                        CheckBox chkvol = (grdclsjob.Rows[j].FindControl("vol") as CheckBox);
                                        if ((Convert.ToBoolean(dtclsjob.Rows[j]["volumeconf"]) == false))
                                        {
                                            chkvol.Checked = false;
                                        }
                                        else
                                        {
                                            chkvol.Checked = true;
                                        }
                                        //CheckBox chkvol1 = FindControl("inc") as CheckBox;
                                        CheckBox chkvol1 = (grdclsjob.Rows[j].FindControl("inc") as CheckBox);
                                        //CheckBox chkvol1 = (grdclsjob.Rows[j].Cells[j].FindControl("inc") as CheckBox);
                                        if (Convert.ToBoolean(dtclsjob.Rows[j]["incomeconf"].ToString()) == false)
                                        {
                                            chkvol1.Checked = false;
                                        }
                                        else
                                        {
                                            chkvol1.Checked = true;
                                        }
                                        // CheckBox chkvol2 = FindControl("exp") as CheckBox;
                                        //CheckBox chkvol2 = (grdclsjob.Rows[j].Cells[j].FindControl("exp") as CheckBox);
                                        CheckBox chkvol2 = (grdclsjob.Rows[j].FindControl("exp") as CheckBox);
                                        if (Convert.ToBoolean(dtclsjob.Rows[j]["expenseconf"].ToString()) == false)
                                        {
                                            chkvol2.Checked = false;
                                        }
                                        else
                                        {
                                            chkvol2.Checked = true;
                                        }
                                        // CheckBox chkvol3 = FindControl("blrelease") as CheckBox;
                                        //CheckBox chkvol3 = (grdclsjob.Rows[j].Cells[j].FindControl("blrelease") as CheckBox);
                                        CheckBox chkvol3 = (grdclsjob.Rows[j].FindControl("blrelease") as CheckBox);
                                        if (Convert.ToBoolean(dtclsjob.Rows[j]["blreleaseconf"].ToString()) == false)
                                        {
                                            chkvol3.Checked = false;
                                        }
                                        else
                                        {
                                            chkvol3.Checked = true;
                                        }
                                        // CheckBox chkvol4 = FindControl("port") as CheckBox;
                                        //CheckBox chkvol4 = (grdclsjob.Rows[j].Cells[j].FindControl("port") as CheckBox);
                                        CheckBox chkvol4 = (grdclsjob.Rows[j].FindControl("port") as CheckBox);
                                        if (Convert.ToBoolean(dtclsjob.Rows[j]["destconf"].ToString()) == false)
                                        {
                                            chkvol4.Checked = false;
                                        }
                                        else
                                        {
                                            chkvol4.Checked = true;
                                        }
                                    }
                                    //btn_confirm.Visible = true;idconfirm.Visible = true;
                                    grdclsjob.Visible = true;
                                }
                            }
                        
                        }
                        else
                        {
                            Image3.ImageUrl = "../images/open.png";
                            // Grd_job.Visible = true;
                            Grd_FEFI.Visible = false;
                            P2.Visible = false;
                            Grd_AEAI.Visible = false;
                            P3.Visible = false;
                            Grd_CH.Visible = false;
                            P4.Visible = false;

                            if (lbl_Header.Text == "Costing with Details")
                            {
                                Grd_job.Visible = false;
                                P1.Visible = false;
                            }
                            else if (trantype == "FE" && lbl_Header.Text == "Job P & L / MIS")
                            {
                                grdclsjob.Visible = true;
                                P8.Visible = true;
                                grdclsjob.DataSource = new DataTable();
                                grdclsjob.DataBind();

                               //intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                               // txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                               // dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                               // if ((Close_date.Day) <= intdays)
                               // {
                               //     txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());
                               // }
                               // else
                               // {
                               //     txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                               // }

                            }
                            else if (trantype == "FI" && lbl_Header.Text == "Job P & L / MIS")
                            {
                                grdclsjob.Visible = true;
                                P8.Visible = true;
                                grdclsjob.DataSource = new DataTable();
                                grdclsjob.DataBind();

                                //intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                //txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                                //dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                                //if ((Close_date.Day) <= intdays)
                                //{
                                //    txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());
                                //}
                                //else
                                //{
                                //    txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                                //}
                            }
                            else if (trantype == "BT" && lbl_Header.Text == "Costing Details")
                            {
                                Grd_job.Visible = false;
                                P1.Visible = false;
                                grdclsjob.DataSource = new DataTable();
                                grdclsjob.DataBind();
                            }
                            else if (trantype == "BT" && lbl_Header.Text == "Job P & L / MIS")
                            {
                                grdclsjob.Visible = true;
                                P8.Visible = true;
                                grdclsjob.DataSource = new DataTable();
                                grdclsjob.DataBind();
                                Grd_BT.Visible = false;
                                P5.Visible = false;
                                btn_confirm.Visible = true;idconfirm.Visible = true;

                                intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                                dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                                if ((Close_date.Day) <= intdays)
                                {
                                    txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());
                                }
                                else
                                {
                                    txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                                }
                            }
                            else if (trantype == "CH" && lbl_Header.Text == "Job P & L / MIS")
                            {
                                grdclsjob.Visible = true;
                                P8.Visible = true;
                                grdclsjob.DataSource = new DataTable();
                                grdclsjob.DataBind();
                                Grd_CH.Visible = false;
                                P4.Visible = false;
                                btn_confirm.Visible = true;idconfirm.Visible = true;

                                intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                                dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                                if ((Close_date.Day) <= intdays)
                                {
                                    txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());
                                }
                                else
                                {
                                    txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                                }
                            }
                            else if (trantype == "AE" && lbl_Header.Text == "Job P & L / MIS")
                            {
                                grdclsjob.Visible = true;
                                P8.Visible = true;
                                grdclsjob.DataSource = new DataTable();
                                grdclsjob.DataBind();
                                Grd_CH.Visible = false;
                                P4.Visible = false;
                                btn_confirm.Visible = true;idconfirm.Visible = true;

                                //intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                //txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                                //dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                                //if ((Close_date.Day) <= intdays)
                                //{
                                //    txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());
                                //}
                                //else
                                //{
                                //    txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                                //}
                            }
                            else if (trantype == "AI" && lbl_Header.Text == "Job P & L / MIS")
                            {
                                grdclsjob.Visible = true;
                                P8.Visible = true;
                                grdclsjob.DataSource = new DataTable();
                                grdclsjob.DataBind();
                                Grd_CH.Visible = false;
                                P4.Visible = false;
                                btn_confirm.Visible = true;idconfirm.Visible = true;

                                //intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                //txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                                //dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                                //if ((Close_date.Day) <= intdays)
                                //{
                                //    txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());
                                //}
                                //else
                                //{
                                //    txt_date.Text = String.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["Column2"]);
                                //}
                            }
                            else
                            {
                                Grd_job.Visible = true;
                                P1.Visible = true;
                            }

                            int empid = Convert.ToInt32(Session["LoginEmpId"]);
                            int_jobno = Convert.ToInt32(txt_job.Text);
                            CostingTemp4JobBLwise(txt_job.Text, trantype);
                            DataSet dsclsjob = new DataSet();
                            DataTable dtclstot = new DataTable();
                            DataTable dtclsjob = new DataTable();
                            dsclsjob = JobCloseObj.SelCostingTempRpt4JobBLwise(int_jobno, trantype, int_bid, empid);

                            dtclsjob = dsclsjob.Tables[0];
                            dtclstot = dsclsjob.Tables[1];
                            //Dinesh
                            //if (dtclsjob.Rows.Count > 0)
                            //{
                            //    grdclsjob.DataSource = dtclsjob;
                            //    grdclsjob.DataBind();
                            //}

                            //dtclstot = dtclsjob;
                            //DataRow dr = dt;
                            DataTable dtemptyfree = new DataTable();
                            // dtemptyfree.Columns.Add("Name", typeof(CheckBoxField));
                            dtemptyfree.Columns.Add("jobno");
                            dtemptyfree.Columns.Add("bookingno");
                            dtemptyfree.Columns.Add("blno");
                            dtemptyfree.Columns.Add("empname");
                            dtemptyfree.Columns.Add("vol");
                            dtemptyfree.Columns.Add("inc");
                            dtemptyfree.Columns.Add("exp");
                            dtemptyfree.Columns.Add("blrelease");
                            dtemptyfree.Columns.Add("port");
                            dtemptyfree.Columns.Add("Income");
                            dtemptyfree.Columns.Add("Expense");
                            dtemptyfree.Columns.Add("Retention");
                            DataRow dr = dtemptyfree.NewRow();
                            if (dtclsjob.Rows.Count > 0)
                            {
                                double total1 = 0, total2 = 0, total3 = 0;

                                for (int j = 0; j <= dtclsjob.Rows.Count - 1; j++)
                                {
                                    dtemptyfree.Rows.Add();
                                    dr = dtemptyfree.NewRow();
                                    int count = dtemptyfree.Rows.Count - 1;
                                    dtemptyfree.Rows[count]["jobno"] = dtclsjob.Rows[j]["jobno"].ToString();
                                    dtemptyfree.Rows[count]["bookingno"] = dtclsjob.Rows[j]["bookingno"].ToString();
                                    dtemptyfree.Rows[count]["blno"] = dtclsjob.Rows[j]["blno"].ToString();
                                    dtemptyfree.Rows[count]["empname"] = dtclsjob.Rows[j]["empname"].ToString();
                                    //CheckBox chkvol = FindControl("vol") as CheckBox;
                                    /*  CheckBox chkvol = (grdclsjob.Rows[j].FindControl("vol") as CheckBox);
                                      if ((Convert.ToBoolean(dtclsjob.Rows[j]["volumeconf"]) == false))
                                      {
                                          chkvol.Checked = false;
                                      }
                                      else
                                      {
                                          chkvol.Checked = true;
                                      }
                                      //CheckBox chkvol1 = FindControl("inc") as CheckBox;
                                      CheckBox chkvol1 = (grdclsjob.Rows[j].FindControl("inc") as CheckBox);
                                      if (dtclsjob.Rows[j]["incomeconf"].ToString() == "false")
                                      {
                                          chkvol1.Checked = false;
                                      }
                                      else
                                      {
                                          chkvol1.Checked = true;
                                      }
                                      // CheckBox chkvol2 = FindControl("exp") as CheckBox;
                                      CheckBox chkvol2 = (grdclsjob.Rows[j].FindControl("exp") as CheckBox);
                                      if (dtclsjob.Rows[j]["expenseconf"].ToString() == "false")
                                      {
                                          chkvol2.Checked = false;
                                      }
                                      else
                                      {
                                          chkvol2.Checked = true;
                                      }
                                      // CheckBox chkvol3 = FindControl("blrelease") as CheckBox;
                                      CheckBox chkvol3 = (grdclsjob.Rows[j].FindControl("blrelease") as CheckBox);
                                      if (dtclsjob.Rows[j]["blreleaseconf"].ToString() == "false")
                                      {
                                          chkvol3.Checked = false;
                                      }
                                      else
                                      {
                                          chkvol3.Checked = true;
                                      }
                                      // CheckBox chkvol4 = FindControl("port") as CheckBox;
                                      CheckBox chkvol4 = (grdclsjob.Rows[j].Cells[j].FindControl("port") as CheckBox);
                                      if (dtclsjob.Rows[j]["destconf"].ToString() == "false")
                                      {
                                          chkvol4.Checked = false;
                                      }
                                      else
                                      {
                                          chkvol4.Checked = true;
                                      }*/
                                    total1 = total1 + Convert.ToDouble(dtclsjob.Rows[j]["Income"].ToString());
                                    dtemptyfree.Rows[count]["Income"] = dtclsjob.Rows[j]["Income"].ToString();
                                    total2 = total2 + Convert.ToDouble(dtclsjob.Rows[j]["Expense"].ToString());
                                    dtemptyfree.Rows[count]["Expense"] = dtclsjob.Rows[j]["Expense"].ToString();
                                    total3 = total3 + Convert.ToDouble(dtclsjob.Rows[j]["Retention"].ToString());
                                    dtemptyfree.Rows[count]["Retention"] = dtclsjob.Rows[j]["Retention"].ToString();
                                    //CheckBox chkvol=FindControl(vol)
                                } dr = dtemptyfree.NewRow();
                                dtemptyfree.Rows.Add(dr);
                                dr["empname"] = "Total";
                                dr["Income"] = total1.ToString();
                                dr["Expense"] = total2.ToString();
                                dr["Retention"] = total3.ToString();
                                grdclsjob.DataSource = dtemptyfree;
                                grdclsjob.DataBind();
                                /* for (int j = 0; j <= dtclsjob.Rows.Count - 1; j++)
                                 {
                                     CheckBox chkvol = (grdclsjob.Rows[j].FindControl("vol") as CheckBox);
                                     if ((Convert.ToBoolean(dtclsjob.Rows[j]["volumeconf"]) == false))
                                     {
                                         chkvol.Checked = false;
                                     }
                                     else
                                     {
                                         chkvol.Checked = true;
                                     }
                                     //CheckBox chkvol1 = FindControl("inc") as CheckBox;
                                     CheckBox chkvol1 = (grdclsjob.Rows[j].Cells[j].FindControl("inc") as CheckBox);
                                     if (Convert.ToBoolean(dtclsjob.Rows[j]["incomeconf"].ToString()) == false)
                                     {
                                         chkvol1.Checked = false;
                                     }
                                     else
                                     {
                                         chkvol1.Checked = true;
                                     }
                                     // CheckBox chkvol2 = FindControl("exp") as CheckBox;
                                     CheckBox chkvol2 = (grdclsjob.Rows[j].Cells[j].FindControl("exp") as CheckBox);
                                     if (Convert.ToBoolean(dtclsjob.Rows[j]["expenseconf"].ToString()) == false)
                                     {
                                         chkvol2.Checked = false;
                                     }
                                     else
                                     {
                                         chkvol2.Checked = true;
                                     }
                                     // CheckBox chkvol3 = FindControl("blrelease") as CheckBox;
                                     CheckBox chkvol3 = (grdclsjob.Rows[j].Cells[j].FindControl("blrelease") as CheckBox);
                                     if (Convert.ToBoolean(dtclsjob.Rows[j]["blreleaseconf"].ToString()) == false)
                                     {
                                         chkvol3.Checked = false;
                                     }
                                     else
                                     {
                                         chkvol3.Checked = true;
                                     }
                                     // CheckBox chkvol4 = FindControl("port") as CheckBox;
                                     CheckBox chkvol4 = (grdclsjob.Rows[j].Cells[j].FindControl("port") as CheckBox);
                                     if (Convert.ToBoolean(dtclsjob.Rows[j]["destconf"].ToString()) == false)
                                     {
                                         chkvol4.Checked = false;
                                     }
                                     else
                                     {
                                         chkvol4.Checked = true;
                                     }
                                 }*/

                                for (int j = 0; j <= dtclsjob.Rows.Count - 1; j++)
                                {
                                    CheckBox chkvol = (grdclsjob.Rows[j].FindControl("vol") as CheckBox);
                                    if ((Convert.ToBoolean(dtclsjob.Rows[j]["volumeconf"]) == false))
                                    {
                                        chkvol.Checked = false;
                                    }
                                    else
                                    {
                                        chkvol.Checked = true;
                                    }
                                    //CheckBox chkvol1 = FindControl("inc") as CheckBox;
                                    CheckBox chkvol1 = (grdclsjob.Rows[j].FindControl("inc") as CheckBox);
                                    //CheckBox chkvol1 = (grdclsjob.Rows[j].Cells[j].FindControl("inc") as CheckBox);
                                    if (Convert.ToBoolean(dtclsjob.Rows[j]["incomeconf"].ToString()) == false)
                                    {
                                        chkvol1.Checked = false;
                                    }
                                    else
                                    {
                                        chkvol1.Checked = true;
                                    }
                                    // CheckBox chkvol2 = FindControl("exp") as CheckBox;
                                    //CheckBox chkvol2 = (grdclsjob.Rows[j].Cells[j].FindControl("exp") as CheckBox);
                                    CheckBox chkvol2 = (grdclsjob.Rows[j].FindControl("exp") as CheckBox);
                                    if (Convert.ToBoolean(dtclsjob.Rows[j]["expenseconf"].ToString()) == false)
                                    {
                                        chkvol2.Checked = false;
                                    }
                                    else
                                    {
                                        chkvol2.Checked = true;
                                    }
                                    // CheckBox chkvol3 = FindControl("blrelease") as CheckBox;
                                    //CheckBox chkvol3 = (grdclsjob.Rows[j].Cells[j].FindControl("blrelease") as CheckBox);
                                    CheckBox chkvol3 = (grdclsjob.Rows[j].FindControl("blrelease") as CheckBox);
                                    if (Convert.ToBoolean(dtclsjob.Rows[j]["blreleaseconf"].ToString()) == false)
                                    {
                                        chkvol3.Checked = false;
                                    }
                                    else
                                    {
                                        chkvol3.Checked = true;
                                    }
                                    // CheckBox chkvol4 = FindControl("port") as CheckBox;
                                    //CheckBox chkvol4 = (grdclsjob.Rows[j].Cells[j].FindControl("port") as CheckBox);
                                    CheckBox chkvol4 = (grdclsjob.Rows[j].FindControl("port") as CheckBox);
                                    if (Convert.ToBoolean(dtclsjob.Rows[j]["destconf"].ToString()) == false)
                                    {
                                        chkvol4.Checked = false;
                                    }
                                    else
                                    {
                                        chkvol4.Checked = true;
                                    }
                                }
                                btn_confirm.Visible = true;idconfirm.Visible = true;
                                grdclsjob.Visible = true;
                            }

                            btn_update.Enabled = true;
                            btn_update.ForeColor = System.Drawing.Color.White;
                        }
                    }

                    if (Request.QueryString.ToString().Contains("OECSHOMECSP"))
                    {
                        btn_cancel.Text = "Back";
                        btn_cancel.ToolTip = "Back";
                        btn_cancel1.Attributes["class"] = "btn ico-back";
                    }
                    else
                    {
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }
                switch (Session["StrTranType"].ToString())
                {
                    case "FE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 71, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text + "/V");
                        break;
                    case "FI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 72, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text + "/V");
                        break;
                    case "AE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 73, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text + "/V");
                        break;
                    case "AI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 74, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text + "/V");
                        break;
                    case "CH":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 75, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text + "/V");
                        break;
                    case "BT":
                        obj_da_Log.InsLogDetail(int_Empid, 359, 2, int_bid, int_jobno + "/Closed");
                        break;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void CostingTemp4JobBLwise(string jobno, string trantype)
        {
            try
            {

                //DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
                int checkbranch = 0;
                costtempobj.DelCostingDetailsRpt4JobBLwise(Convert.ToInt32(jobno), trantype, "V", Convert.ToInt32(Session["LoginBranchid"]), 0, "", Convert.ToInt32(Session["LoginEmpId"]));
                blamount = 0;
                blexpense = 0;
                loguserid = Convert.ToInt32(Session["LoginEmpId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                DtJob = costtempobj.GetClosedJobDts4JobBLwise(Convert.ToInt32(jobno), trantype, Convert.ToInt32(Session["LoginBranchid"]));

                for (int i = 0; i <= DtJob.Rows.Count - 1; i++)
                {
                    mblexpense = costtempobj.Costing4unclosedjobs(DtJob.Rows[i][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"]),"Expense");
                    mblCredit = costtempobj.Costing4unclosedjobs(DtJob.Rows[i][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"]), "Credit");
                    mblamount = costtempobj.Costing4unclosedjobs(DtJob.Rows[i][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"]),"Income");
                    mblDebit = costtempobj.Costing4unclosedjobs(DtJob.Rows[i][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"]), "Debit");

                    if (trantype == "FE" || trantype == "FI")
                    {
                        jobtype = Convert.ToInt32(DtJob.Rows[i]["jobtype"].ToString());
                        mlo = Convert.ToInt32(DtJob.Rows[i]["mlo"].ToString());

                        DtCT = costtempobj.GetCBMTues(Convert.ToInt32(DtJob.Rows[i]["jobno"]), trantype, Convert.ToInt32(Session["LoginBranchid"]));
                        if (DtCT.Rows.Count > 0)
                        {
                            if (DtCT.Rows[0]["cbmtotal"].ToString() != "" && DtCT.Rows[0]["Tuestotal"].ToString() != "")
                            {
                                totalcbm = Convert.ToDouble(DtCT.Rows[0]["cbmtotal"].ToString());
                                totaltues = Convert.ToDouble(DtCT.Rows[0]["Tuestotal"].ToString());
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        jobtype = 0;
                        mlo = Convert.ToInt32(DtJob.Rows[i]["airline"].ToString());
                        DtCT = costtempobj.GetCBMTues(Convert.ToInt32(DtJob.Rows[i]["jobno"]), trantype, Convert.ToInt32(Session["LoginBranchid"]));
                        if (DtCT.Rows.Count > 0)
                        {
                            if (DtCT.Rows[0][0].ToString() != "")
                            {
                                jobchargewt = Convert.ToDouble(DtCT.Rows[0][0].ToString());
                            }
                        }
                    }

                    DtBL = costtempobj.GetBLRow(Convert.ToInt32(DtJob.Rows[i]["jobno"]), trantype, Convert.ToInt32(Session["LoginBranchid"]));
                    for (int j = 0; j <= DtBL.Rows.Count - 1; j++)
                    {

                        blexpense = costtempobj.Costing4unclosedjobs(DtBL.Rows[j][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"]), "Expense");
                        blCredit = costtempobj.Costing4unclosedjobs(DtBL.Rows[j][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"]), "Credit");
                        blamount = costtempobj.Costing4unclosedjobs(DtBL.Rows[j][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"]), "Income");
                        blDebit = costtempobj.Costing4unclosedjobs(DtBL.Rows[j][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"]), "Debit");

                        //blamount = Convert.ToDouble(costtempobj.GetcostInvBOS(DtBL.Rows[j][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"])));
                        //blDebit = Convert.ToDouble(costtempobj.GetCreditDebit(DtBL.Rows[j][1].ToString(), trantype, branchid, "Debit"));

                        //blexpense = Convert.ToDouble(costtempobj.GetcostPA(DtBL.Rows[j][1].ToString(), trantype, Convert.ToInt32(Session["LoginBranchid"])));
                        //blCredit = Convert.ToDouble(costtempobj.GetCreditDebit(DtBL.Rows[j][1].ToString(), trantype, branchid, "Credit"));
                        if (trantype == "FE" || trantype == "FI")
                        {
                            bltues = Convert.ToInt32(DtBL.Rows[j]["cont20"].ToString()) + Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j]["cont40"].ToString()) * 2);
                            blcbm = Convert.ToDouble(DtBL.Rows[j]["cbm"].ToString());
                            checkbranch = Convert.ToInt32(DtBL.Rows[j]["branch"].ToString());

                            if (mblamount != 0)
                            {
                                if (jobtype == 3)
                                {
                                    if (bltues == 0)
                                    {
                                        blamount = blamount + Convert.ToDouble((mblamount / 1) * 1);
                                    }

                                    else if (totaltues == 0)
                                    {
                                        blamount = blamount + ((mblamount / 1) * 1);
                                    }
                                    else
                                    {
                                       // blamount = blamount + ((mblamount / totaltues) * bltues);

                                        amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), totaltues, bltues, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "M");
                                        blamount = blamount + amont;
                                    }

                                }
                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blamount = blamount + 0;
                                    }

                                    else if (totalcbm == 0)
                                    {
                                        blamount = blamount + 0;
                                    }

                                    else
                                    {
                                        //blamount = blamount + ((mblamount / totalcbm) * blcbm);

                                        amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), totalcbm, blcbm, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "M");
                                        blamount = blamount + amont;
                                    }

                                }

                            }
                            if (mblDebit != 0)
                            {
                                if (jobtype == 3)
                                {
                                    if (bltues == 0)
                                    {
                                        blDebit = blDebit + ((mblDebit / 1) * 1);
                                    }
                                    else if (totaltues == 0)
                                    {
                                        blDebit = blDebit + ((mblDebit / 1) * 1);
                                    }
                                    else
                                    {
                                     //   blDebit = blDebit + ((mblDebit / totaltues) * bltues);
                                        amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), totaltues, bltues, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "D");
                                        blDebit = blDebit + amont;
                                    }
                                }

                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blDebit = blDebit + 0;
                                    }

                                    else if (totalcbm == 0)
                                    {
                                        blDebit = blDebit + 0;
                                    }

                                    else
                                    {
                                       // blDebit = blDebit + ((mblDebit / totalcbm) * blcbm);

                                        amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), totalcbm, blcbm, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "D");
                                        blDebit = blDebit + amont;
                                    }

                                }
                            }

                            if (mblexpense != 0)
                            {
                                if (jobtype == 3)
                                {
                                    if (bltues == 0)
                                    {
                                        blexpense = blexpense + ((mblexpense / 1) * 1);
                                    }
                                    else if (totaltues == 0)
                                    {
                                        blexpense = blexpense + ((mblexpense / 1) * 1);
                                    }
                                    else
                                    {
                                        //blexpense = blexpense + ((mblexpense / totaltues) * bltues);

                                        amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), totaltues, bltues, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "E");
                                        blexpense = blexpense + amont;
                                    }
                                }
                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blexpense = blexpense + 0;
                                    }
                                    else if (totalcbm == 0)
                                    {
                                        blexpense = blexpense + 0;
                                    }
                                    else
                                    {
                                      //  blexpense = blexpense + ((mblexpense / totalcbm) * blcbm);

                                        amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), totalcbm, blcbm, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "E");
                                        blexpense = blexpense + amont;
                                    }

                                }

                            }

                            if (mblCredit != 0)
                            {
                                if (jobtype == 3)
                                {
                                    if (bltues == 0)
                                    {
                                        blCredit = blCredit + ((mblCredit / 1) * 1);
                                    }
                                    else if (totaltues == 0)
                                    {
                                        blCredit = blCredit + ((mblCredit / 1) * 1);
                                    }

                                    else
                                    {
                                      //  blCredit = blCredit + ((mblCredit / totaltues) * bltues);

                                        amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), totaltues, bltues, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "C");
                                        blCredit = blCredit + amont;
                                    }

                                }
                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blCredit = blCredit + 0;
                                    }
                                    else if (totalcbm == 0)
                                    {
                                        blCredit = blCredit + 0;
                                    }
                                    else
                                    {
                                     //   blCredit = blCredit + ((mblCredit / totalcbm) * blcbm);

                                        amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), totalcbm, blcbm, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "C");

                                        blCredit = blCredit + amont;
                                    }

                                }
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            blchargewt = Convert.ToDouble(DtBL.Rows[j]["chargewt"].ToString());
                            if (mblamount != 0)
                            {
                               // blamount = blamount + ((mblamount / jobchargewt) * blchargewt);

                                amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), jobchargewt, blchargewt, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "M");
                                blamount = blamount + amont;
                            }

                            if (mblDebit != 0)
                            {
                               // blDebit = blDebit + ((mblDebit / jobchargewt) * blchargewt);

                                amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), jobchargewt, blchargewt, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "D");
                                blDebit = blDebit + amont;
                            }

                            if (mblexpense != 0)
                            {
                                //blexpense = blexpense + ((mblexpense / jobchargewt) * blchargewt);

                                amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), jobchargewt, blchargewt, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "E");
                                blexpense = blexpense + amont;
                            }

                            if (mblCredit != 0)
                            {
                              //  blCredit = blCredit + ((mblCredit / jobchargewt) * blchargewt);
                                amont = costtempobj.CostPATemplv(Convert.ToInt32(Session["LoginBranchid"]), trantype, DtJob.Rows[i][1].ToString(), jobchargewt, blchargewt, 0, Convert.ToInt32(Convert.ToInt32(DtBL.Rows[j][0])), "C");
                                blCredit = blCredit + amont;
                            }

                        }

                        jobno = DtBL.Rows[j][0].ToString();
                        blno = DtBL.Rows[j][1].ToString();

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (DtBL.Rows[j][2].ToString() != "" && DtBL.Rows[j][2].ToString() != "")
                            {
                                cont20 = Convert.ToInt32(DtBL.Rows[j][2].ToString());
                                cont40 = Convert.ToInt32(DtBL.Rows[j][3].ToString());
                            }

                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            cont20 = 0;
                            cont40 = 0;
                        }
                        nomination = Convert.ToChar(DtBL.Rows[j][4].ToString());
                        volume = Convert.ToDouble(DtBL.Rows[j][5].ToString());
                        shipper = Convert.ToInt32(DtBL.Rows[j][6].ToString());
                        consignee = Convert.ToInt32(DtBL.Rows[j][7].ToString());
                        notify = Convert.ToInt32(DtBL.Rows[j][8].ToString());
                        agent = Convert.ToInt32(DtBL.Rows[j][9].ToString());
                        pol = Convert.ToInt32(DtBL.Rows[j][10].ToString());
                        pod = Convert.ToInt32(DtBL.Rows[j][11].ToString());
                        salesperson = costtempobj.GetSalesPerson(blno, trantype, Convert.ToInt32(Session["LoginBranchid"]));
                        blamount = blamount + blDebit;
                        blexpense = blexpense + blCredit;
                        Double a;
                        if (string.IsNullOrEmpty(blamount.ToString()) == true || Double.TryParse(blamount.ToString(), out a) == false)
                        {
                            blamount = 0;
                        }
                        Double b;
                        if (string.IsNullOrEmpty(blexpense.ToString()) == true || Double.TryParse(blexpense.ToString(), out b) == false)
                        {
                            blexpense = 0;
                        }
                        costtempobj.InsCostingTempRpt4JobBLwise(loguserid, Convert.ToInt32(jobno), trantype, branchid, blno, blamount, blexpense);

                    }
                }
                OtherDNCNBL4JobBLwise(Convert.ToInt32(jobno), trantype, "Closed", Convert.ToString(Close_date), 0, "");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        public void OtherDNCNBL4JobBLwise(int jobno, string trantype, string frmtype, string date, int vouno, string voutype)
        {
            try
            {

                blamount = 0;
                blexpense = 0;
                loguserid = Convert.ToInt32(Session["LoginEmpId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                mlo = 0;

                if (frmtype == "Closed")
                {
                    DtJob = costtempobj.GetDNCN4MISFromJobNo4JobBLwiseLV(jobno, branchid, trantype);
                }
                else if (frmtype == "&Approve")
                {
                    DtJob = costtempobj.GetDNCN4MISFromVounoLV(jobno, branchid, trantype, vouno, voutype);
                }

                RC = DtJob.Rows.Count;

                for (int i = 0; i <= RC - 1; i++)
                {
                    blno = DtJob.Rows[i]["blno"].ToString();
                    jobno = Convert.ToInt32(DtJob.Rows[i]["jobno"].ToString());
                    if (trantype != "CH")
                    {
                        mlo = Convert.ToInt32(DtJob.Rows[i]["mlo"].ToString());
                    }

                    {
                        mlo = 0;
                    }
                    DtBL = costtempobj.GetBLRowBL(blno, trantype, Convert.ToInt32(Session["LoginBranchid"]));
                    if (DtBL.Rows.Count > 0)
                    {
                        blamount = 0;
                        blexpense = 0;

                        //hided on nov 242021 Newlyadded4Reversal 
                        //if (i < RC - 1)
                        //{
                        //    if (DtJob.Rows[i]["blno"].ToString() != DtJob.Rows[i + 1]["blno"].ToString())
                        //    {
                        //        if (DtJob.Rows[i]["voutype"].ToString() == "V")
                        //        {
                        //            if (DtJob.Rows[i]["amount"].ToString() != "")
                        //            {
                        //                blamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                        //            }
                        //        }
                        //        else if (DtJob.Rows[i]["voutype"].ToString() == "E")
                        //        {
                        //            if (DtJob.Rows[i]["amount"].ToString() != "")
                        //            {
                        //                blexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (DtJob.Rows[i]["voutype"].ToString() == "V")
                        //        {
                        //            if (DtJob.Rows[i]["amount"].ToString() != "")
                        //            {
                        //                blamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                        //            }
                        //        }

                        //        else
                        //        {
                        //            if (DtJob.Rows[i]["amount"].ToString() != "")
                        //            {
                        //                blexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                        //            }
                        //        }

                        //    }

                        //}

                        //else
                        //{
                        //    if (DtJob.Rows[RC - 1]["voutype"].ToString() == "V")
                        //    {
                        //        if (DtJob.Rows[RC - 1]["amount"].ToString() != "")
                        //        {
                        //            blamount = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                        //        }
                        //    }
                        //    else if (DtJob.Rows[RC - 1]["voutype"].ToString() == "E")
                        //    {
                        //        if (DtJob.Rows[RC - 1]["amount"].ToString() != "")
                        //        {
                        //            blexpense = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                        //        }
                        //    }
                        //}
                        // Newlyadded4Reversal Nov242021 start----------------------------
                        if (i < RC - 1)
                        {
                            if (DtJob.Rows[i]["blno"].ToString() != DtJob.Rows[i + 1]["blno"].ToString())
                            {
                                if (DtJob.Rows[i]["voutype"].ToString() == "V")
                                {
                                    //if (DtJob.Rows[i]["amount"].ToString() != "") //hideon02112021
                                    //{
                                    //    blamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    //}
                                    if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                    {
                                        blamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    }
                                    else if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                    {
                                        blexpense = -Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (DtJob.Rows[i]["voutype"].ToString() == "E")
                                {
                                    //if (DtJob.Rows[i]["amount"].ToString() != "")
                                    //{
                                    //    blexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    //}
                                    if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                    {
                                        blexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    }
                                    else if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                    {
                                        blamount = -Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (DtJob.Rows[i]["voutype"].ToString() == "V")
                                {
                                    //if (DtJob.Rows[i]["amount"].ToString() != "")
                                    //{
                                    //    blamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    //}
                                    if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                    {
                                        blamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    }
                                    else if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                    {
                                        blexpense = -Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    }
                                }

                                else
                                {
                                    //if (DtJob.Rows[i]["amount"].ToString() != "")
                                    //{
                                    //    blexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    //}
                                    if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                    {
                                        blexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    }
                                    else if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                    {
                                        blamount = -Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                    }
                                }

                            }

                        }

                        else
                        {
                            if (DtJob.Rows[RC - 1]["voutype"].ToString() == "V")
                            {
                                //if (DtJob.Rows[RC - 1]["amount"].ToString() != "")
                                //{
                                //    blamount = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                                //}
                                if (DtJob.Rows[RC - 1]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                {
                                    blamount = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                                }
                                else if (DtJob.Rows[RC - 1]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                {
                                    blexpense = -Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                                }
                            }
                            else if (DtJob.Rows[RC - 1]["voutype"].ToString() == "E")
                            {
                                //if (DtJob.Rows[RC - 1]["amount"].ToString() != "")
                                //{
                                //    blexpense = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                                //}
                                if (DtJob.Rows[RC - 1]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                {
                                    blexpense = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                                }
                                else if (DtJob.Rows[RC - 1]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                {
                                    blamount = -Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                                }
                            }
                        }

                        //end--------------------------------------                                                                                 

                        if (DtBL.Rows[0][4].ToString()!="")
                        {
                            nomination = Convert.ToChar(DtBL.Rows[0][4].ToString());
                        }

                        volume = Convert.ToDouble(DtBL.Rows[0][5].ToString());

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if ((DtBL.Rows[0][2].ToString() != "" && DtBL.Rows[0][3].ToString() != ""))
                            {
                                cont20 = Convert.ToInt32(DtBL.Rows[0][2].ToString());
                                cont40 = Convert.ToInt32(DtBL.Rows[0][3].ToString());
                                jobtype = Convert.ToInt32(DtJob.Rows[i]["jobtype"].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI" && trantype == "CH")
                        {
                            cont20 = 0;
                            cont40 = 0;
                            jobtype = 0;
                        }

                        if (trantype != "CH")
                        {
                            salesperson = costtempobj.GetSalesPerson(blno, trantype, branchid);
                        }
                        else
                        {
                            salesperson = 0;
                        }

                        shipper = Convert.ToInt32(DtBL.Rows[0][6].ToString());
                        consignee = Convert.ToInt32(DtBL.Rows[0][7].ToString());
                        notify = Convert.ToInt32(DtBL.Rows[0][8].ToString());
                        agent = Convert.ToInt32(DtBL.Rows[0][9].ToString());
                        pol = Convert.ToInt32(DtBL.Rows[0][10].ToString());
                        pod = Convert.ToInt32(DtBL.Rows[0][11].ToString());
                        costtempobj.InsCostingTempRpt4JobBLwise(loguserid, jobno, trantype, branchid, blno, blamount, blexpense);
                    }
                    else //hide nambi on 26Nov2021 
                    {
                        if (hid_mblchk.Value == "N")
                        {
                            OtherDNCNMBL4JobBLwise(jobno, trantype, vouno, voutype);
                            hid_mblchk.Value = "Y";
                        }
                       
                    }

                }
                //if (DtJob.Rows.Count > 0)
                //{
                //    OtherDNCNMBL4JobBLwise(jobno, trantype, vouno, voutype);  // //add nambi on 26Nov2021 
                //}
                hid_mblchk.Value = "N";
                   
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        public void OtherDNCNMBL4JobBLwise(int jobno, string trantype, int vouno, string voutype)
        {
            try
            {
                int K = 0;
                blamount = 0;
                blexpense = 0;
                mblamount = 0;
                mblexpense = 0;
                loguserid = Convert.ToInt32(Session["LoginEmpId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                DtBL = costtempobj.GetBLRow(jobno, trantype, Convert.ToInt32(Session["LoginBranchid"]));
                if (DtBL.Rows.Count > 0)
                {
                    //hide for Newlyadded4Reversal
                    //if (i < RC - 1)
                    //{
                    //    if (DtJob.Rows[i]["blno"].ToString() != DtJob.Rows[i + 1]["blno"].ToString())
                    //    {
                    //        if (DtJob.Rows[i]["voutype"].ToString() == "V")
                    //        {
                    //            if (DtJob.Rows[i]["amount"].ToString() != "")
                    //            {
                    //                mblamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                    //            }
                    //        }
                    //        else if (DtJob.Rows[i]["voutype"].ToString() == "E")
                    //        {
                    //            if (DtJob.Rows[i]["amount"].ToString() != "")
                    //            {
                    //                mblexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (DtJob.Rows[i]["voutype"].ToString() == "V")
                    //        {
                    //            if (DtJob.Rows[i]["amount"].ToString() != "")
                    //            {
                    //                mblamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                    //            }
                    //        }
                    //        else if (DtJob.Rows[i]["voutype"].ToString() == "E")
                    //        {
                    //            if (DtJob.Rows[i]["amount"].ToString() != "")
                    //            {
                    //                mblexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (DtJob.Rows[RC - 1]["voutype"].ToString() == "V")
                    //    {
                    //        if (DtJob.Rows[RC - 1]["amount"].ToString() != "")
                    //        {
                    //            mblamount = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                    //        }
                    //    }
                    //    else if (DtJob.Rows[RC - 1]["voutype"].ToString() == "E")
                    //    {
                    //        if (DtJob.Rows[RC - 1]["amount"].ToString() != "")
                    //        {
                    //            mblexpense = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                    //        }
                    //    }
                    //}

                   // Newlyadded4Reversal Nov242021 start----------------------------
                    if (i < RC - 1)
                    {
                        if (DtJob.Rows[i]["blno"].ToString() != DtJob.Rows[i + 1]["blno"].ToString())
                        {
                            if (DtJob.Rows[i]["voutype"].ToString() == "V")
                            {
                                //if (DtJob.Rows[i]["amount"].ToString() != "") //hidon02112021
                                //{
                                //    mblamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                //}
                                if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                {
                                    mblamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                }
                                else if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                {
                                    mblexpense = -Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (DtJob.Rows[i]["voutype"].ToString() == "E")
                            {
                                //if (DtJob.Rows[i]["amount"].ToString() != "")
                                //{
                                //    mblexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                //}
                                if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                {
                                    mblexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                }
                                else if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                {
                                    mblamount = -Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                }
                            }
                        }
                        else
                        {
                            if (DtJob.Rows[i]["voutype"].ToString() == "V")
                            {
                                //if (DtJob.Rows[i]["amount"].ToString() != "")
                                //{
                                //    mblamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                //}
                                if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                {
                                    mblamount = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                }
                                else if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                {
                                    mblexpense = -Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (DtJob.Rows[i]["voutype"].ToString() == "E")
                            {
                                //if (DtJob.Rows[i]["amount"].ToString() != "")
                                //{
                                //    mblexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                //}
                                if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                                {
                                    mblexpense = Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                }
                                else if (DtJob.Rows[i]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                                {
                                    mblamount = -Convert.ToDouble(DtJob.Rows[i]["amount"].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        if (DtJob.Rows[RC - 1]["voutype"].ToString() == "V")
                        {
                            //if (DtJob.Rows[RC - 1]["amount"].ToString() != "")
                            //{
                            //    mblamount = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                            //}
                            if (DtJob.Rows[RC - 1]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                            {
                                mblamount = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                            }
                            else if (DtJob.Rows[RC - 1]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                            {
                                mblexpense = -Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                            }
                        }
                        else if (DtJob.Rows[RC - 1]["voutype"].ToString() == "E")
                        {
                            //if (DtJob.Rows[RC - 1]["amount"].ToString() != "")
                            //{
                            //    mblexpense = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                            //}
                            if (DtJob.Rows[RC - 1]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "N")
                            {
                                mblexpense = Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                            }
                            else if (DtJob.Rows[RC - 1]["amount"].ToString() != "" & DtJob.Rows[i]["Reversal"].ToString() == "R")
                            {
                                mblamount = -Convert.ToDouble(DtJob.Rows[RC - 1]["amount"].ToString());
                            }
                        }
                    }

                    //end-----------------------------

                    if (trantype == "FE" || trantype == "FI")
                    {
                        jobtype = Convert.ToInt32(DtJob.Rows[i]["jobtype"].ToString());
                        DtCT = costtempobj.GetCBMTues(Convert.ToInt32(DtJob.Rows[i]["jobno"]), trantype, branchid);
                        if (DtCT.Rows.Count > 0)
                        {
                            if (DtCT.Rows[0]["cbmtotal"].ToString() != "" && DtCT.Rows[0]["Tuestotal"].ToString() != "")
                            {
                                totalcbm = Convert.ToDouble(DtCT.Rows[0]["cbmtotal"].ToString());
                                totaltues = Convert.ToDouble(DtCT.Rows[0]["Tuestotal"].ToString());
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        jobtype = 0;
                        DtCT = costtempobj.GetCBMTues(Convert.ToInt32((DtJob.Rows[i]["jobno"])), trantype, branchid);
                        if (DtCT.Rows.Count > 0)
                        {
                            if (DtCT.Rows[0][0].ToString() != "")
                            {
                                jobchargewt = Convert.ToDouble(DtCT.Rows[0][0].ToString());
                            }
                        }
                    }

                    for (j = 0; j <= DtBL.Rows.Count - 1; j++)
                    {
                        blamount = 0;
                        blexpense = 0;
                        if (trantype == "FE" || trantype == "FI")
                        {
                            bltues = Convert.ToInt32(DtBL.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(DtBL.Rows[j]["cont40"].ToString()) * 2);
                            blcbm = Convert.ToDouble(DtBL.Rows[j]["cbm"].ToString());
                            if (mblamount != 0)
                            {
                                if (jobtype == 3)
                                {
                                    blamount = ((mblamount / totaltues) * bltues);
                                }
                                else
                                {
                                  //  blamount = ((mblamount / totalcbm) * blcbm);
                                    amont = costtempobj.CostPATemplv(int_bid, trantype, DtJob.Rows[i][1].ToString(), totalcbm, blcbm, 0, Convert.ToInt32(DtBL.Rows[j][0].ToString()), "DN");
                                    blamount = blamount + amont;
                                }
                            }

                            if (mblexpense != 0)
                            {
                                if (jobtype == 3)
                                {
                                    blexpense = ((mblexpense / totaltues) * bltues);
                                }

                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blexpense = 0;
                                    }
                                    else if (totalcbm == 0)
                                    {
                                        blexpense = 0;
                                    }
                                    else
                                    {
                                       // blexpense = ((mblexpense / totalcbm) * blcbm);

                                        amont = costtempobj.CostPATemplv(int_bid, trantype, DtJob.Rows[i][1].ToString(), totalcbm, blcbm, 0, Convert.ToInt32(DtBL.Rows[j][0].ToString()), "CN");
                                        blexpense =blexpense + amont;
                                    }
                                }
                            }
                        }

                        else if (trantype == "AE" || trantype == "AI")
                        {
                            blchargewt = Convert.ToDouble(DtBL.Rows[j]["chargewt"].ToString());
                            if (mblamount != 0)
                            {
                             //   blamount = ((mblamount / jobchargewt) * blchargewt);

                                amont = costtempobj.CostPATemplv(int_bid, trantype, DtJob.Rows[i][1].ToString(), jobchargewt, blchargewt, 0, Convert.ToInt32(DtBL.Rows[j][0].ToString()), "DN");
                                blamount = blamount + amont;
                            }
                            if (mblexpense != 0)
                            {
                               // blexpense = ((mblexpense / jobchargewt) * blchargewt);

                                amont = costtempobj.CostPATemplv(int_bid, trantype, DtJob.Rows[i][1].ToString(), jobchargewt, blchargewt, 0, Convert.ToInt32(DtBL.Rows[j][0].ToString()), "CN");
                                blexpense = blexpense + amont;
                            }
                        }

                        blno = DtBL.Rows[j][1].ToString();
                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (DtBL.Rows[j][2].ToString() != "" && DtBL.Rows[j][3].ToString() != "")
                            {
                                cont20 = Convert.ToInt32(DtBL.Rows[j][2].ToString());
                                cont40 = Convert.ToInt32(DtBL.Rows[j][3].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            cont20 = 0;
                            cont40 = 0;
                        }

                        nomination = Convert.ToChar(DtBL.Rows[j][4].ToString());
                        volume = Convert.ToDouble(DtBL.Rows[j][5].ToString());
                        shipper = Convert.ToInt32(DtBL.Rows[j][6].ToString());
                        consignee = Convert.ToInt32(DtBL.Rows[j][7].ToString());
                        notify = Convert.ToInt32(DtBL.Rows[j][8].ToString());
                        agent = Convert.ToInt32(DtBL.Rows[j][9].ToString());
                        pol = Convert.ToInt32(DtBL.Rows[j][10].ToString());
                        pod = Convert.ToInt32(DtBL.Rows[j][11].ToString());
                        salesperson = costtempobj.GetSalesPerson(blno, trantype, branchid);
                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (jobtype == 3)
                            {
                                volume = 0;
                            }
                            else
                            {
                                cont20 = 0;
                                cont40 = 0;
                            }
                        }
                        Double a;
                        if (string.IsNullOrEmpty(blamount.ToString()) == true || Double.TryParse(blamount.ToString(), out a) == false)
                        {
                            blamount = 0;
                        }
                        Double b;
                        if (string.IsNullOrEmpty(blexpense.ToString()) == true || Double.TryParse(blexpense.ToString(), out b) == false)
                        {
                            blexpense = 0;
                        }
                        costtempobj.InsCostingTempRpt4JobBLwise(loguserid, jobno, trantype, branchid, blno, blamount, blexpense);

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                popup_Grd.Hide();
                //int int_jobno = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text.ToString());
                //  txt_job.Text = int_jobno.ToString();
                // int index = Convert.ToInt32(GridView1.SelectedRow.RowIndex);

                //fn_jobdetails(int_jobno);
                //BindBooking();
                int index1 = Convert.ToInt32(GridView1.SelectedRow.RowIndex);
                if (GridView1.Rows.Count > 0)
                {

                    txt_job.Text = GridView1.Rows[Convert.ToInt32(index1)].Cells[0].Text.ToString();
                    txt_job_TextChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }
        }
        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void Grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
            //DataAccess.CloseJobs JobCloseObj = new DataAccess.CloseJobs();
            trantype = Session["StrTranType"].ToString();
            int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            if (trantype == "FE" || trantype == "FI" || trantype == "AE" || trantype == "AI")
            {
                obj_dt = da_obj_Costingdt.GridFillJobdtls(trantype, int_bid);
                if (obj_dt.Rows.Count <= 0)
                {
                    // DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                    // DataTable obj_dt = new DataTable();
                    // obj_dt = obj_da_jobinfo.GetJobNoList(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "JobInfo", "alertify.alert('Job Not Available');", true);
                    return;
                }
                else
                {
                    popup_Grd.Show();
                    GridView1.DataSource = obj_dt;
                    GridView1.DataBind();

                }
            }
        }

        /* protected void Grdcost_SelectedIndexChanged(object sender, EventArgs e)
         {

             try
             {
                 // LinkButton Img_Select_btn = (LinkButton)Grdcost.SelectedRow.FindControl("Lnk_job");
                 int index1 = Convert.ToInt32(Grdcost.SelectedRow.RowIndex);

                 string Str_voucher, strtrantype, strblno;
                 int int_vouno, int_vouyear = 0;

                 if (Grdcost.Rows.Count > 0)
                 {
                     Str_voucher = Grdcost.Rows[index1].Cells[0].Text.ToString().Replace("&nbsp;", string.Empty);
                     if (Grdcost.Rows[index1].Cells[1].Text.Trim().ToString().Replace("&nbsp;", string.Empty).Length > 0)
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
                         string Str_RptName, Str_SF, Str_SP, Str_Script, Str_curr, Str_SF1, Str_SP1, Str_RptName1;
                         Str_RptName = "";
                         Str_SF = "";
                         Str_SP = "";
                         Str_Script = "";
                         Str_curr = "";
                         Str_SF1 = "";
                         Str_SP1 = "";
                         Str_RptName1 = "";
                         Session["str_sfs"] = ""; Session["str_sfs"] = ""; Session["str_sp"] = ""; Session["str_sp1"] = "";

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
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;
                             }
                             else if (Str_voucher == "CN-Ops")
                             {
                                 if (trantype == "FE")
                                 {
                                     Str_RptName = "fepa.rpt";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "FI")
                                 {
                                     Str_RptName = "FIPA.rpt";
                                       Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                   //  Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                     Str_SP = "";
                                 }
                                 else if (trantype == "AE")
                                 {
                                     Str_RptName = "AEPA.rpt";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR ";
                                 }
                                 else if (trantype == "AI")
                                 {
                                     Str_RptName = "AIPA.rpt";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "CH")
                                 {
                                     Str_RptName = "CHAPA.rpt";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;
                             }
                             else if (Str_voucher == "DN")
                             {
                                 if (trantype == "FE")
                                 {
                                     Str_RptName = "FEDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR~container= ";                                    
                                 }
                                 else if (trantype == "FI")
                                 {
                                     Str_RptName = "FIDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR~container= ";
                                 }
                                 else if (trantype == "AE")
                                 {
                                     Str_RptName = "AEDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "AI")
                                 {
                                     Str_RptName = "AIDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "CH")
                                 {
                                     Str_RptName = "CHADN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
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
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "container="; ;
                                 }
                                 else if (trantype == "AE")
                                 {
                                     Str_RptName = "AECN.rpt";
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR ";
                                 }
                                 else if (trantype == "AI")
                                 {
                                     Str_RptName = "AICN.rpt";
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "CH")
                                 {
                                     Str_RptName = "CHACN.rpt";
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear+"";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
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
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;
                             }
                             else if (Str_voucher == "CN-Ops")
                             {
                                 if (trantype == "FE")
                                 {
                                     Str_RptName = "FEMPA.rpt";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "FI")
                                 {
                                     Str_RptName = "FIMPA.rpt";
                                     //Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "AE")
                                 {
                                     Str_RptName = "AEMPA.rpt";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "AI")
                                 {
                                     Str_RptName = "AIMPA.rpt";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "CH")
                                 {
                                     Str_RptName = "CHAPA.rpt";
                                     Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;
                             }
                             else if (Str_voucher == "DN")
                             {
                                 if (trantype == "FE")
                                 {
                                     Str_RptName = "FEMDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR~container=";
                                 }
                                 else if (trantype == "FI")
                                 {
                                     Str_RptName = "FIMDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR~container=";
                                 }
                                 else if (trantype == "AE")
                                 {
                                     Str_RptName = "AEMDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "AI")
                                 {
                                     Str_RptName = "AIMDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "CH")
                                 {
                                     Str_RptName = "CHADN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "FC")
                                 {
                                     Str_RptName = "FIMDN.rpt";
                                     Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR~container=";
                                 }
                                 Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;
                             }

                             else if (Str_voucher == "CN")
                             {
                                 if (trantype == "FE")
                                 {
                                     Str_RptName = "FEMCN.rpt";
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR~container=";
                                 }
                                 else if (trantype == "FI")
                                 {
                                     Str_RptName = "FIMCN.rpt";
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "container="; ;
                                 }
                                 else if (trantype == "AE")
                                 {
                                     Str_RptName = "AEMCN.rpt";
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR ";
                                 }
                                 else if (trantype == "AI")
                                 {
                                     Str_RptName = "AIMCN.rpt";
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 else if (trantype == "CH")
                                 {
                                     Str_RptName = "CHACN.rpt";
                                     Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                     Str_SP = "Lcurr=INR";
                                 }
                                 Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
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
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;

                                 Str_RptName1 = "SOA1.rpt";
                                 Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                 Str_SP1 = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                 str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                 Str_Script = str_script1 + ";" + str_script2;

                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                 Session["str_sfs1"] = Str_SF1;
                                 Session["str_sp1"] = Str_SP1;
                             }
                             else if (trantype == "FI")
                             {

                                 Str_RptName = "FIOSDN.rpt";
                                 Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                 Str_SP = "FCurr=" + Str_curr;
                                 str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;

                                 Str_RptName1 = "SOA1.rpt";
                                 Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                 Str_SP1 = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                 str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                 Str_Script = str_script1 + ";" + str_script2;
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                 Session["str_sfs1"] = Str_SF1;
                                 Session["str_sp1"] = Str_SP1;
                             }
                             else if (trantype == "AE")
                             {

                                 Str_RptName = "AEOSDN.rpt";
                                 Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                 Str_SP = "FCurr=" + Str_curr;
                                 str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;

                                 Str_RptName1 = "SOA1.rpt";
                                 Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                 Str_SP1 = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                 str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                 Str_Script = str_script1 + ";" + str_script2;
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                 Session["str_sfs1"] = Str_SF1;
                                 Session["str_sp1"] = Str_SP1;
                             }
                             else
                             {

                                 Str_RptName = "AIOSDN.rpt";
                                 Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                 Str_SP = "FCurr=" + Str_curr;
                                 str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;

                                 Str_RptName1 = "SOA1.rpt";
                                 Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                 Str_SP1 = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                 str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                 Str_Script = str_script1 + ";" + str_script2;
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                 Session["str_sfs1"] = Str_SF1;
                                 Session["str_sp1"] = Str_SP1;
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
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;

                                 Str_RptName1 = "SOA1.rpt";
                                 Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                 Str_SP1 = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                 str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                 Str_Script = str_script1 + ";" + str_script2;
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                 Session["str_sfs1"] = Str_SF1;
                                 Session["str_sp1"] = Str_SP1;
                             }
                             else if (trantype == "FI")
                             {

                                 Str_RptName = "FIOSCN.rpt";
                                 Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                 Str_SP = "FCurr=" + Str_curr;
                                 str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;

                                 Str_RptName1 = "SOA1.rpt";
                                 Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                 Str_SP1 = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                 str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                 Str_Script = str_script1 + ";" + str_script2;
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                 Session["str_sfs1"] = Str_SF1;
                                 Session["str_sp1"] = Str_SP1;
                             }
                             else if (trantype == "AE")
                             {

                                 Str_RptName = "AEOSCN.rpt";
                                 Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                 Str_SP = "FCurr=" + Str_curr;
                                 str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;

                                 Str_RptName1 = "SOA1.rpt";
                                 Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                 Str_SP1 = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                 str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                 Str_Script = str_script1 + ";" + str_script2;
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                 Session["str_sfs1"] = Str_SF1;
                                 Session["str_sp1"] = Str_SP1;
                             }
                             else
                             {

                                 Str_RptName = "AIOSCN.rpt";
                                 Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                 Str_SP = "FCurr=" + Str_curr;
                                 str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                 Session["str_sfs"] = Str_SF;
                                 Session["str_sp"] = Str_SP;

                                 Str_RptName1 = "SOA1.rpt";
                                 Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                 Str_SP1 = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                 str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";

                                 Str_Script = str_script1 + ";" + str_script2;
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                 Session["str_sfs1"] = Str_SF1;
                                 Session["str_sp1"] = Str_SP1;
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

         }*/

        /*
        protected void Grdcost_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                // LinkButton Img_Select_btn = (LinkButton)Grdcost.SelectedRow.FindControl("Lnk_job");
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                int index1 = Convert.ToInt32(Grdcost.SelectedRow.RowIndex);

                string Str_voucher, strtrantype, strblno, Str_CustType="";
                int int_vouno, int_vouyear = 0;

                if (Grdcost.Rows.Count > 0)
                {
                    Str_voucher = Grdcost.Rows[index1].Cells[0].Text.ToString().Replace("&nbsp;", string.Empty);
                    if (Grdcost.Rows[index1].Cells[1].Text.Trim().ToString().Replace("&nbsp;", string.Empty).Length > 0)
                    {
                      // string cutname = ((Label)Grdcost.Rows[index1].Cells[5].FindControl("cname")).Text;// Grdcost.Rows[index1].Cells[5].Text.Trim();
                        hid_customerid.Value = Grdcost.Rows[index1].Cells[7].Text.ToString();
                        if (hid_customerid.Value != "")
                        {
                            Str_CustType = obj_da_Customer.GetCustomerType(int.Parse(hid_customerid.Value.ToString()));
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
                        string Str_RptName, Str_SF, Str_SP, Str_Script, Str_curr, Str_SF1, Str_SP1, Str_RptName1;
                        Str_RptName = "";
                        Str_SF = "";
                        Str_SP = "";
                        Str_Script = "";
                        Str_curr = "";
                        Str_SF1 = "";
                        Str_SP1 = "";
                        Str_RptName1 = "";
                        Session["str_sfs"] = ""; Session["str_sfs"] = ""; Session["str_sp"] = ""; Session["str_sp1"] = "";

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
                                    //Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno + "&vouyear=" + int_vouyear + "&total=" + Grdcost.SelectedRow.Cells[6].Text.ToString() + "&blno=" + Grdcost.SelectedRow.Cells[4].Text.ToString() + "&bltype=" + "H" + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "CN-Ops")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "fepa.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    //  Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                    Str_SP = "";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                   Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                  //  Str_SP = "Lcurr=INR";
                                }
                               //// Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                               //// ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);

                                //Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno + "&vouyear=" + int_vouyear + "&total=" + Grdcost.SelectedRow.Cells[6].Text.ToString() + "&blno=" + Grdcost.SelectedRow.Cells[4].Text.ToString() + "&bltype=" + "H" + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "DN")
                            {                              

                                if (trantype == "FE")
                                {
                                    //Str_RptName = "FEDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FEDNAgent.rpt";

                                    }
                                    else
                                    {
                                        Str_RptName = "FEDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FIDNAgent.rpt";

                                    }
                                    else
                                    {
                                        Str_RptName = "FIDN.rpt";
                                    }
                                  //  Str_RptName = "FIDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AEDNAgent.rpt";

                                    }
                                    else
                                    {
                                        Str_RptName = "AEDN.rpt";
                                    }
                                  //  Str_RptName = "AEDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "AI")
                                {
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AIDNAgent.rpt";

                                    }
                                    else
                                    {
                                        Str_RptName = "AIDN.rpt";
                                    }
                                   // Str_RptName = "AIDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                   
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN")
                            {
                                int int_custid = 0;
                                DataTable obj_dtcn = new DataTable();
                                obj_dtcn = da_obj_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouyear, int_bid);
                                if (obj_dtcn.Rows.Count > 0)
                                {
                                    int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
                                }
                                if (trantype == "FE")
                                {
                                    //Str_RptName = "FECN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FECNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "FECN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    //Str_RptName = "FICN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FICNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "FICN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "container="; 
                                }
                                else if (trantype == "AE")
                                {
                                    //Str_RptName = "AECN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AECNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AECN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                   // Str_RptName = "AICN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AICNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AICN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHACN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            if (Str_voucher == "Pro Inv")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProInvoice.rpt";
                                    //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            if (Str_voucher == "ProCN-Ops")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }
                            if (Str_voucher == "Pro DN")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            if (Str_voucher == "Pro CN")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
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
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);

                                //Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno + "&vouyear=" + int_vouyear + "&total=" + Grdcost.SelectedRow.Cells[6].Text.ToString() + "&blno=" + Grdcost.SelectedRow.Cells[4].Text.ToString() + "&bltype=" + "M" + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "CN-Ops")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMPA.rpt";
                                    //Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno + "&vouyear=" + int_vouyear + "&total=" + Grdcost.SelectedRow.Cells[6].Text.ToString() + "&blno=" + Grdcost.SelectedRow.Cells[4].Text.ToString() + "&bltype=" + "M" + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "DN")
                            {
                                if (trantype == "FE")
                                {
                                   // Str_RptName = "FEMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FEMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "FEMDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    //Str_RptName = "FIMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FIMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "FIMDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "AE")
                                {
                                   // Str_RptName = "AEMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AEMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AEMDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "AI")
                                {
                                   // Str_RptName = "AIMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AIMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AIMDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "FC")
                                {
                                    Str_RptName = "FIMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN")
                            {
                                if (trantype == "FE")
                                {
                                 //   Str_RptName = "FEMCN.rpt";

                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FEMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "FEMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                   // Str_RptName = "FIMCN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FIMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "FIMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "container="; ;
                                }
                                else if (trantype == "AE")
                                {
                                  //  Str_RptName = "AEMCN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AEMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AEMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    //Str_RptName = "AIMCN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AIMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AIMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHACN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
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
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;

                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else if (trantype == "FI")
                            {

                                Str_RptName = "FIOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else if (trantype == "AE")
                            {

                                Str_RptName = "AEOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", str_script1, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else
                            {

                                Str_RptName = "AIOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
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
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else if (trantype == "FI")
                            {

                                Str_RptName = "FIOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else if (trantype == "AE")
                            {

                                Str_RptName = "AEOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else
                            {

                                Str_RptName = "AIOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                Str_SP = "FCurr=" + Str_curr;
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";

                              //  Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                        }
                        if (Str_voucher == "Pro Inv")
                        {
                            if (trantype == "FE")
                            {
                                Str_RptName = "FEMProInvoice.rpt";
                                Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                            }
                            else if (trantype == "FI")
                            {
                                Str_RptName = "FIMProInvoice.rpt";
                                Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                            }
                            else if (trantype == "AE")
                            {
                                Str_RptName = "AEMProInvoice.rpt";
                                Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            else if (trantype == "AI")
                            {
                                Str_RptName = "AIMProInvoice.rpt";
                                Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                            }
                            else if (trantype == "CH")
                            {
                                Str_RptName = "CHProInvoice.rpt";
                                Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                            }
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            Session["str_sfs"] = Str_SF;
                            Session["str_sp"] = Str_SP;
                        }
                        if (Str_voucher == "ProCN-Ops")
                        {
                            if (trantype == "FE")
                            {
                                Str_RptName = "FEMProPA.rpt";
                                Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            else if (trantype == "FI")
                            {
                                Str_RptName = "FIMProPA.rpt";
                                Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                            }
                            else if (trantype == "AE")
                            {
                                Str_RptName = "AEMProPA.rpt";
                                Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            else if (trantype == "AI")
                            {
                                Str_RptName = "AIMProPA.rpt";
                                Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            else if (trantype == "CH")
                            {
                                Str_RptName = "CHAProPA.rpt";
                                Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            Session["str_sfs"] = Str_SF;
                            Session["str_sp"] = Str_SP;

                        }
                        if (Str_voucher == "Pro DN")
                        {
                            if (trantype == "FE")
                            {
                                Str_RptName = "FEMProDN.rpt";
                                Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                            }
                            else if (trantype == "FI")
                            {
                                Str_RptName = "FIMProDNrpt";
                                Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                            }
                            else if (trantype == "AE")
                            {
                                Str_RptName = "AEMProDN.rpt";
                                Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            else if (trantype == "AI")
                            {
                                Str_RptName = "AIMProDN.rpt";
                                Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            else if (trantype == "CH")
                            {
                                Str_RptName = "CHAProDN.rpt";
                                Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            Session["str_sfs"] = Str_SF;
                            Session["str_sp"] = Str_SP;
                        }

                        if (Str_voucher == "Pro CN")
                        {
                            if (trantype == "FE")
                            {
                                Str_RptName = "FEMProCN.rpt";
                                Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                            }
                            else if (trantype == "FI")
                            {
                                Str_RptName = "FIMProCN.rpt";
                                Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                            }
                            else if (trantype == "AE")
                            {
                                Str_RptName = "AEMProCN.rpt";
                                Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            else if (trantype == "AI")
                            {
                                Str_RptName = "AIMProCN.rpt";
                                Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            else if (trantype == "CH")
                            {
                                Str_RptName = "CHAProCN.rpt";
                                Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                            }
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            Session["str_sfs"] = Str_SF;
                            Session["str_sp"] = Str_SP;
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

        BEFORE GST*/

        //GST

        protected void Grdcost_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = "", header = "", bltype = "";
            DataTable DTRetve = new DataTable();
            string Vouch1 = "", Vouch2 = "";
            DataTable dttp = new DataTable();
            DataTable dtp = new DataTable();

            int Ref1 = 0, Ref2 = 0;
            try
            {
                int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DateTime get_date, GST_date;
                int index1 = Convert.ToInt32(Grdcost.SelectedRow.RowIndex);
                if (Grdcost.Rows[index1].Cells[2].Text =="")
                {
                    return;
                }
                get_date = Convert.ToDateTime(Utility.fn_ConvertDate(Grdcost.Rows[index1].Cells[2].Text));
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                //DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
                DataTable dcon = Appobj.Checkcountry(int.Parse(Session["LoginBranchid"].ToString()));
                int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);

                // LinkButton Img_Select_btn = (LinkButton)Grdcost.SelectedRow.FindControl("Lnk_job");
                //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

                string Str_voucher, strtrantype, strblno = "", Str_CustType = "";
                int int_vouno, int_vouyear = 0;
                string tot_amount = Grdcost.SelectedRow.Cells[7].Text;
                if (Grdcost.Rows.Count > 0)
                {
                    Str_voucher = Grdcost.Rows[index1].Cells[0].Text.ToString().Replace("&nbsp;", string.Empty);
                   if( Str_voucher=="Purchase Invoice")
                   {
                       Str_voucher = "CN-Ops";
                   }
                   if (Str_voucher == "Pro Purchase Inv")
                   {
                       Str_voucher = "ProCN-Ops";
                   }
                    if (Grdcost.Rows[index1].Cells[1].Text.Trim().ToString().Replace("&nbsp;", string.Empty).Length > 0)
                    {
                        // string cutname = ((Label)Grdcost.Rows[index1].Cells[5].FindControl("cname")).Text;// Grdcost.Rows[index1].Cells[5].Text.Trim();
                        //hid_customerid.Value = Grdcost.Rows[index1].Cells[7].Text.ToString(); //HIDE ON NOV 252021
                        hid_customerid.Value = Grdcost.Rows[index1].Cells[8].Text.ToString();
                        if (hid_customerid.Value != "")
                        {
                            Str_CustType = obj_da_Customer.GetCustomerType(int.Parse(hid_customerid.Value.ToString()));
                        }
                        int_vouno = Convert.ToInt32(Grdcost.SelectedRow.Cells[1].Text.ToString());

                        if (Grdcost.SelectedDataKey.Values[0].ToString().Trim().Length > 0)
                        {
                            int_vouyear = Convert.ToInt32(Grdcost.SelectedDataKey.Values[0].ToString());
                        }
                        /*  string str_vou = "";
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
                          */

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
                        else if (Str_voucher == "CN-Ops" || Str_voucher == "Purchase Invoice")
                        {
                            str_vou = "PA";
                        }
                        else if (Str_voucher == "ProCN-Ops"|| Str_voucher == "Pro Purchase Inv")
                        {
                            str_vou = "ProPA";
                        }
                       

                        else
                        {
                            str_vou = Str_voucher;
                        }

                        DataTable obj_dt = new DataTable();
                        DataTable obj_dttemp = new DataTable();
                        string Str_RptName, Str_SF, Str_SP, Str_Script, Str_curr, Str_SF1, Str_SP1, Str_RptName1;
                        Str_RptName = "";
                        Str_SF = "";
                        Str_SP = "";
                        Str_Script = "";
                        Str_curr = "";
                        Str_SF1 = "";
                        Str_SP1 = "";
                        Str_RptName1 = "";
                        Session["str_sfs"] = ""; Session["str_sfs"] = ""; Session["str_sp"] = ""; Session["str_sp1"] = "";

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
                            if (Str_voucher == "Invoice" || Str_voucher == "Sales Invoice")
                            {

                                header = "Invoice";
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
                                    //Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTInvoice.rpt";
                                    Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                                    //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;
                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=1" +"&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }

                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }
                            if (Str_voucher == "Sales Invoice OC")
                            {
                                header = "Invoice FC";
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
                                    //Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTInvoice.rpt";
                                    Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                                    //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;
                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }

                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }

                            else if (Str_voucher == "BOS")
                            {
                                header = "Bill of Supply";
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
                                    //Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTInvoice.rpt";
                                    Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                                    //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;
                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }
                            else if (Str_voucher == "BOS OC")
                            {
                                header = "Bill of Supply FC";
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
                                    //Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTInvoice.rpt";
                                    Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                                    //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;
                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }
                            else if (Str_voucher == "CN-Ops" || Str_voucher == "Purchase Invoice")
                            {
                                header = "PA";
                                //HORM = "H";
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
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }
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
                          //      HORM = "H";
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
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }
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
                                //HORM = "H";
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
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            if (Str_voucher == "Pro Inv" || Str_voucher == "Pro Sales Inv")
                            {
                                header = "Invoice";
                                //type = "Profoma Invoice";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProInvoice.rpt";
                                    //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            if (Str_voucher == "Pro Sales Inv OC")
                            {
                                header = "Invoice FC";
                                //   type = "Profoma Invoice FC";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProInvoice.rpt";
                                    //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            if (Str_voucher == "Pro Purchase Inv")
                            {
                                header = "PA";
                                // type = "Profoma Purchase Invoice";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }
                            if (Str_voucher == "ProCN-Ops" || Str_voucher == "Pro Purchase Inv")
                            {
                                header = "PA";
                                //    type = "Profoma Purchase Invoice";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        if(con == 1102 || con == 102)
                                        {
                                            Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                                        }
                                        else
                                        {
                                            Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                                        }
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }
                            if (Str_voucher == "Pro Purchase Inv OC")
                            {
                                header = "PA FC";
                                //  type = "Profoma Purchase Invoice FC";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }
                            if (Str_voucher == "Pro DN")
                            {
                                header = "DN";

                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            if (Str_voucher == "Pro CN")
                            {
                                header = "CN";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
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
                            if (Str_voucher == "Invoice" || Str_voucher == "Sales Invoice")
                            {
                                header = "Invoice";
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

                                    //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=1"+ "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "BOS")
                            {

                                header = "Bill of Supply";
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

                                    //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                //if (get_date >= GST_date)
                                //{
                                //    Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                                //}
                                //else
                                //{
                                //    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //}
                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "CN-Ops" || Str_voucher == "Purchase Invoice")
                            {
                                header = "PA";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMPA.rpt";
                                    //Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTPA.rpt";
                                    Str_SF = "{ACPAHead.trantype}=\"" + trantype + "\" and {ACPAHead.pano}=" + int_vouno + " and {ACPAHead.branchid}=" + int_bid + " and {ACPAHead.vouyear}=" + int_vouyear + "";

                                    //Session["str_sfs"] = "{ACPAHead.trantype}='" + Session["StrTranType"] + "' and {ACPAHead.pano}=" + txtInvoice.Text + " and {ACPAHead.branchid}=" + branchId + " and {ACPAHead.vouyear}=" + txtVouyear.Text;
                                    Str_SP = "Lcurr=INR";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "DN")
                            {
                                header = "DN";
                                if (trantype == "FE")
                                {
                                    // Str_RptName = "FEMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FEMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_CustType = "";
                                        Str_RptName = "FEMDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    //Str_RptName = "FIMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FIMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_CustType = "";
                                        Str_RptName = "FIMDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "AE")
                                {
                                    // Str_RptName = "AEMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AEMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_CustType = "";
                                        Str_RptName = "AEMDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "AI")
                                {
                                    // Str_RptName = "AIMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AIMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_CustType = "";
                                        Str_RptName = "AIMDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "FC")
                                {
                                    Str_RptName = "FIMDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN")
                            {
                                header = "CN";
                                if (trantype == "FE")
                                {
                                    //   Str_RptName = "FEMCN.rpt";

                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FEMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_CustType = "";
                                        Str_RptName = "FEMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    // Str_RptName = "FIMCN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FIMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_CustType = "";
                                        Str_RptName = "FIMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "container="; ;
                                }
                                else if (trantype == "AE")
                                {
                                    //  Str_RptName = "AEMCN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AEMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_CustType = "";
                                        Str_RptName = "AEMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    //Str_RptName = "AIMCN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AIMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_CustType = "";
                                        Str_RptName = "AIMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHACN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                //Session["str_sfs"] = Str_SF;
                                //Session["str_sp"] = Str_SP;

                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            if (Str_voucher == "Pro Inv" || Str_voucher == "Pro Sales Inv")
                            {
                                header = "Invoice";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHProInvoice.rpt";
                                    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                                }
                                //else if (trantype == "BT")
                                //{
                                //    Str_RptName = "BTProInvoice.rpt";
                                //    Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}=" + branchid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                                //    Str_SP = "Lcurr=INR";
                                //}
                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            if (Str_voucher == "ProCN-Ops" || Str_voucher == "Pro Purchase Inv")
                            {
                                header = "PA";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "BT")
                                {
                                    Str_RptName = "BTProPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                if (get_date >= GST_date)
                                {
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                            }
                            if (Str_voucher == "Pro DN")
                            {
                                header = "DN";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMProDNrpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            if (Str_voucher == "Pro CN")
                            {
                                header = "CN";
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHAProCN.rpt";
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                                    Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                                }
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
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
                        //    if (Str_voucher == "Invoice")
                        //    {
                        //        header = "Invoice";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIInvoice.rpt";
                        //            //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //            //Str_SP = "Lcurr=INR";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTInvoice.rpt";
                        //            Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                                  
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;

                        //    }
                        //    if (Str_voucher == "Invoice OC")
                        //    {
                        //        header = "Invoice FC";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIInvoice.rpt";
                        //            //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //            //Str_SP = "Lcurr=INR";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTInvoice.rpt";
                        //            Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }

                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;

                        //    }

                        //    else if (Str_voucher == "BOS")
                        //    {
                        //        header = "Bill of Supply";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIInvoice.rpt";
                        //            //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //            //Str_SP = "Lcurr=INR";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTInvoice.rpt";
                        //            Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;

                        //    }
                        //    else if (Str_voucher == "BOS OC")
                        //    {
                        //        header = "Bill of Supply FC";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIInvoice.rpt";
                        //            //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //            //Str_SP = "Lcurr=INR";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTInvoice.rpt";
                        //            Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;

                        //    }
                        //    else if (Str_voucher == "Purchase Invoice")
                        //    {
                        //        header = "PA";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "fepa.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            //  Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                        //            Str_SP = "";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //            //  Str_SP = "Lcurr=INR";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTPA.rpt";
                        //            Str_SF = "{ACPAHead.trantype}=\"" + trantype + "\" and {ACPAHead.pano}=" + int_vouno + " and {ACPAHead.branchid}=" + int_bid + " and {ACPAHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACPAHead.trantype}='" + Session["StrTranType"] + "' and {ACPAHead.pano}=" + txtInvoice.Text + " and {ACPAHead.branchid}=" + branchId + " and {ACPAHead.vouyear}=" + txtVouyear.Text;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    else if (Str_voucher == "CN-Ops")
                        //    {
                        //        header = "PA";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "fepa.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            //  Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                        //            Str_SP = "";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //            //  Str_SP = "Lcurr=INR";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTPA.rpt";
                        //            Str_SF = "{ACPAHead.trantype}=\"" + trantype + "\" and {ACPAHead.pano}=" + int_vouno + " and {ACPAHead.branchid}=" + int_bid + " and {ACPAHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACPAHead.trantype}='" + Session["StrTranType"] + "' and {ACPAHead.pano}=" + txtInvoice.Text + " and {ACPAHead.branchid}=" + branchId + " and {ACPAHead.vouyear}=" + txtVouyear.Text;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    else if (Str_voucher == "Purchase Invoice OC")
                        //    {
                        //        header = "PA FC";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "fepa.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            //  Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                        //            Str_SP = "";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //            //  Str_SP = "Lcurr=INR";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTPA.rpt";
                        //            Str_SF = "{ACPAHead.trantype}=\"" + trantype + "\" and {ACPAHead.pano}=" + int_vouno + " and {ACPAHead.branchid}=" + int_bid + " and {ACPAHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACPAHead.trantype}='" + Session["StrTranType"] + "' and {ACPAHead.pano}=" + txtInvoice.Text + " and {ACPAHead.branchid}=" + branchId + " and {ACPAHead.vouyear}=" + txtVouyear.Text;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    else if (Str_voucher == "DN")
                        //    {

                        //        header = "DN";
                                
                        //        if (trantype == "FE")
                        //        {
                        //            //Str_RptName = "FEDN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "FEDNAgent.rpt";

                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "FEDN.rpt";
                        //            }
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "FIDNAgent.rpt";

                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "FIDN.rpt";
                        //            }
                        //            //  Str_RptName = "FIDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "AEDNAgent.rpt";

                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "AEDN.rpt";
                        //            }
                        //            //  Str_RptName = "AEDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "AIDNAgent.rpt";

                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "AIDN.rpt";
                        //            }
                        //            // Str_RptName = "AIDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //           // Str_CustType = "";
                        //            if (Str_CustType != "P")
                        //            {
                        //                Str_CustType = "";
                        //            }
                        //            Str_RptName = "CHADN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //    else if (Str_voucher == "CN")
                        //    {
                        //        header = "CN";
                        //        int int_custid = 0;
                        //        DataTable obj_dtcn = new DataTable();
                        //        obj_dtcn = da_obj_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouyear, int_bid);
                        //        if (obj_dtcn.Rows.Count > 0)
                        //        {
                        //            int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
                        //        }
                        //        if (trantype == "FE")
                        //        {
                        //            //Str_RptName = "FECN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "FECNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "FECN.rpt";
                        //            }
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            //Str_RptName = "FICN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "FICNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "FICN.rpt";
                        //            }
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "container=";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            //Str_RptName = "AECN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "AECNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "AECN.rpt";
                        //            }
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            // Str_RptName = "AICN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "AICNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "AICN.rpt";
                        //            }
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            if (Str_CustType != "P")
                        //            {
                        //                Str_CustType = "";
                        //            }
                        //            Str_RptName = "CHACN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            if (trantype == "CH")
                        //            {

                        //                Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                if(con == 1102 || con == 102)
                        //                {
                        //                    Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //                }
                        //                else
                        //                {
                        //                    Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //    if (Str_voucher == "Pro Inv")
                        //    {
                        //        header = "Invoice";
                        //        type = "Profoma Invoice";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIProInvoice.rpt";
                        //            //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    if (Str_voucher == "Pro Inv OC")
                        //    {
                        //        header = "Invoice FC";
                        //        type = "Profoma Invoice FC";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIProInvoice.rpt";
                        //            //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    if (Str_voucher == "Pro Purchase Inv")
                        //    {
                        //        header = "PA";
                        //        type = "Profoma Purchase Invoice";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma"+ "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;

                        //    }
                        //    if (Str_voucher == "ProCN-Ops")
                        //    {
                        //        header = "PA";
                        //        type = "Profoma Purchase Invoice";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;

                        //    }
                        //    if (Str_voucher == "Pro Purchase Inv OC")
                        //    {
                        //        header = "PA FC";
                        //        type = "Profoma Purchase Invoice FC";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;

                        //    }
                        //    if (Str_voucher == "Pro DN")
                        //    {
                        //        header = "DN";

                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    if (Str_voucher == "Pro CN")
                        //    {
                        //        header = "CN";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //}
                        //else
                        //{
                        //    bltype = "M";
                        //    if (Str_voucher == "Invoice")
                        //    {
                        //        header = "Invoice";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTInvoice.rpt";
                        //            Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //    else if (Str_voucher == "BOS")
                        //    {
                               
                        //        header = "Bill of Supply";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTInvoice.rpt";
                        //            Str_SF = "{ACInvoiceHead.trantype}=\"" + trantype + "\" and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}= " + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + int_vouno + " and {ACInvoiceHead.branchid}=" + int_bid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        //if (get_date >= GST_date)
                        //        //{
                        //        //    Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                        //        //}
                        //        //else
                        //        //{
                        //        //    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //}
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    else if (Str_voucher == "CN-Ops")
                        //    {
                        //        header = "PA";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMPA.rpt";
                        //            //Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTPA.rpt";
                        //            Str_SF = "{ACPAHead.trantype}=\"" + trantype + "\" and {ACPAHead.pano}=" + int_vouno + " and {ACPAHead.branchid}=" + int_bid + " and {ACPAHead.vouyear}=" + int_vouyear + "";

                        //            //Session["str_sfs"] = "{ACPAHead.trantype}='" + Session["StrTranType"] + "' and {ACPAHead.pano}=" + txtInvoice.Text + " and {ACPAHead.branchid}=" + branchId + " and {ACPAHead.vouyear}=" + txtVouyear.Text;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    else if (Str_voucher == "DN")
                        //    {
                        //        header = "DN";
                        //        if (trantype == "FE")
                        //        {
                        //            // Str_RptName = "FEMDN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "FEMDNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "FEMDN.rpt";
                        //            }
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            //Str_RptName = "FIMDN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "FIMDNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "FIMDN.rpt";
                        //            }
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            // Str_RptName = "AEMDN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "AEMDNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "AEMDN.rpt";
                        //            }
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            // Str_RptName = "AIMDN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "AIMDNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "AIMDN.rpt";
                        //            }
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHADN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "FC")
                        //        {
                        //            Str_RptName = "FIMDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //    else if (Str_voucher == "CN")
                        //    {
                        //        header = "CN";
                        //        if (trantype == "FE")
                        //        {
                        //            //   Str_RptName = "FEMCN.rpt";

                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "FEMCNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "FEMCN.rpt";
                        //            }
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            // Str_RptName = "FIMCN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "FIMCNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "FIMCN.rpt";
                        //            }
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "container="; ;
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            //  Str_RptName = "AEMCN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "AEMCNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "AEMCN.rpt";
                        //            }
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            //Str_RptName = "AIMCN.rpt";
                        //            if (Str_CustType == "P")
                        //            {
                        //                Str_RptName = "AIMCNAgent.rpt";
                        //            }
                        //            else
                        //            {
                        //                Str_CustType = "";
                        //                Str_RptName = "AIMCN.rpt";
                        //            }
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHACN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        //Session["str_sfs"] = Str_SF;
                        //        //Session["str_sp"] = Str_SP;

                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //    if (Str_voucher == "Pro Inv")
                        //    {
                        //        header = "Invoice";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTProInvoice.rpt";
                        //            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}=" + branchid + " and {ACInvoiceHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    if (Str_voucher == "ProCN-Ops")
                        //    {
                        //        header = "PA";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTProPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            if(con == 1102 || con == 102)
                        //            {
                        //                Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //            else
                        //            {
                        //                Str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        //            }
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;

                        //    }
                        //    if (Str_voucher == "Pro DN")
                        //    {
                        //        header = "DN";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMProDNrpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAProDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //    if (Str_voucher == "Pro CN")
                        //    {
                        //        header = "CN";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAProCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //}
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
                        if (Str_voucher == "OSSI")
                        {
                            //DataTable obj_dtoscn = new DataTable();
                            //obj_dtoscn = da_obj_InvOSDC.RptOSDNCN(trantype, int_vouno, int_bid, "OSSI", int_vouyear);

                         //   Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "D", int_bid);
                            string str_script1="", str_script2="";

                            if (trantype == "FE")
                            {
                                dttp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(txt_job.Text), Convert.ToString(trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
                                if (dttp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dttp.Rows[c]["curr"].ToString();

                                        Str_RptName = "FEOSDN.rpt";
                                        //Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                        //Str_SP = "FCurr=" + Str_curr;
                                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;

                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else if (trantype == "FI")
                            {
                                dttp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(txt_job.Text), Convert.ToString(trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
                                if (dttp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dttp.Rows[c]["curr"].ToString();
                                        Str_RptName = "FIOSDN.rpt";
                                        //  Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;

                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {

                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else if (trantype == "AE")
                            {
                                dttp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(txt_job.Text), Convert.ToString(trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
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
                                        Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                   
                                }
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else
                            {
                                dttp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(txt_job.Text), Convert.ToString(trantype), "D", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
                                if (dttp.Rows.Count > 0)
                                {
                                    for (int c = 0; c <= dttp.Rows.Count - 1; c++)
                                    {
                                        Str_curr = dttp.Rows[c]["curr"].ToString();

                                        Str_RptName = "AIOSDN.rpt";
                                        //  Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\" and {OSDN.dnno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                        Str_SP = "FCurr=" + Str_curr;
                                    }
                                    if (get_date >= GST_date)
                                    {
                                        Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                        }
                        if (Str_voucher == "OSPI")
                        {
                            // int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                          //  Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "C", int_bid);
                            string str_script1, str_script2;
                            if (trantype == "FE")
                            {
                                 dtp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(txt_job.Text), trantype, "C", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
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
                                         Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                     }
                                     else
                                     {
                                         Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                     }
                                 }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else if (trantype == "FI")
                            {
                                 dtp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(txt_job.Text), trantype, "C", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
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
                                         Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                     }
                                     else
                                     {
                                         Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                     }
                                 }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else if (trantype == "AE")
                            {
                                 dtp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(txt_job.Text), trantype, "C", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
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
                                         Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                     }
                                     else
                                     {
                                         Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                     }
                                 }
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                                //Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                            else
                            {
                                 dtp = da_obj_OSDNCN.GetCurrOSDCN1(Convert.ToInt32(txt_job.Text), trantype, "C", Convert.ToInt32(Session["LoginBranchid"].ToString()), int_vouno);
                                 if (dtp.Rows.Count > 0)
                                 {
                                     for (int c = 0; c <= dtp.Rows.Count - 1; c++)
                                     {
                                         Str_curr = dtp.Rows[c]["curr"].ToString();
                                         Str_RptName = "AIOSCN.rpt";
                                         //   Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                                         Str_SF = "{OSCN.trantype}=\"" + trantype + "\" and {OSCN.cnno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                         Str_SP = "FCurr=" + Str_curr;
                                     }
                                     if (get_date >= GST_date)
                                     {
                                         Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "OSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                     }
                                     else
                                     {
                                         Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                     }
                                 }

                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;

                                //Str_RptName1 = "SOA1.rpt";
                                //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
                                //Str_SP1 = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
                                //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";

                                //  Str_Script = str_script1 + ";" + str_script2;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs1"] = Str_SF1;
                                Session["str_sp1"] = Str_SP1;
                            }
                        }
                        else if (Str_voucher == "Pro OSDN")
                        {
                            if (trantype == "FE")
                            {
                                Str_RptName = "FEProOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSDN.refno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                { 
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text); Session["str_sfs"] = Str_SF;
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }
                            else if (trantype == "FI")
                            {
                                Str_RptName = "FIProOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSDN.refno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text); Session["str_sfs"] = Str_SF;
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }
                            else if (trantype == "AE")
                            {
                                Str_RptName = "AEProOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSDN.refno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text); Session["str_sfs"] = Str_SF;
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }
                            else if (trantype == "AI")
                            {
                                Str_RptName = "AIProOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSDN.refno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                { 
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text); Session["str_sfs"] = Str_SF;
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }
                            else if (trantype == "CH")
                            {
                             //   Str_RptName = "AIProOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSDN.refno}=" + int_vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text); Session["str_sfs"] = Str_SF;
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }
                        }
                        else if (Str_voucher == "Pro OSCN")
                        {
                            if (trantype == "FE")
                            {
                                Str_RptName = "FEProOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSCN.refno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text); Session["str_sfs"] = Str_SF;
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP1;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }
                            else if (trantype == "FI")
                            {
                                Str_RptName = "FIProOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSCN.refno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP1;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }
                            else if (trantype == "AE")
                            {
                                Str_RptName = "AEProOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSCN.refno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP1;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }
                            else if (trantype == "AI")
                            {
                                Str_RptName = "AIProOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSCN.refno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                }

                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP1;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
                            }

                            else if (trantype == "CH")
                            {
                                //Str_RptName = "AIProOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(trantype) + "\" and {OSCN.refno}=" + int_vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(trantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                }

                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP1;
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "Shipment Details", Str_Script, true);
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
        private string Fn_GetTrantypename()
        {

            string str_temp = "";
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


            return str_temp;


        }
        protected void btn_Export_Click(object sender, EventArgs e)
        {
            if (Grdcost.Rows.Count > 0)
            {

                string Filename, strtemp;
                Filename = "Costing With Details for Job # :" + txt_job.Text;
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
        protected void btn_Export_Click1(object sender, EventArgs e)
        {
            //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_Costingdt.GetCBM2040fromJob(Convert.ToInt32(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            //DataAccess.CostingTemp da_obj_CostTemp = new DataAccess.CostingTemp();
            int int_Chargeid = 0, int_Vouyear = 0;
            double Income, Expense;
            da_obj_CostTemp.DelCostingTempCharges(Convert.ToInt32(Session["LoginEmpId"].ToString()));
            int_Vouyear = Convert.ToInt32(Session["Vouyear"].ToString());
            for (int i = 1; i <= 8; i++)
            {
                // obj_dt = da_obj_CostTemp.GetInvoiceCharges(int.Parse(txt_job.Text.Trim().ToString()), int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), int_Vouyear, i);
                string trantype = Session["StrTranType"].ToString();
                obj_dt = da_obj_CostTemp.GetInvoiceCharges(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text.Trim().ToString()), trantype, int_Vouyear, i);
                if (obj_dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                    {
                        int_Chargeid = Convert.ToInt32(obj_dt.Rows[j]["charges"].ToString());
                        //if (i % 2 == 0)
                        //{
                        //    Income = double.Parse(obj_dt.Rows[j]["amount"].ToString());
                        //    Expense = 0;
                        //}
                        //else
                        //{
                        //    Expense = double.Parse(obj_dt.Rows[j]["amount"].ToString());
                        //    Income = 0;
                        //}
                        if (i == 1 || i == 3 || i == 5 || i==8)
                        {
                            Income = Convert.ToDouble(obj_dt.Rows[j]["amount"].ToString());
                            Expense = 0;
                        }
                        else

                        {
                            Income = 0;
                            Expense = Convert.ToDouble(obj_dt.Rows[j]["amount"].ToString());
                        }

                        //  da_obj_CostTemp.InsJobChargesTemp(int.Parse(txt_job.Text.Trim().ToString()), int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), i, int.Parse(Session["LoginEmpId"].ToString()), Income, Expense, int_Chargeid);
                        da_obj_CostTemp.InsJobChargesTemp(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), i, int.Parse(Session["LoginEmpId"].ToString()), Income, Expense, int_Chargeid);
                    }
                }
            }

            if (Grdcost.Rows.Count > 0)
            {
                //DataAccess.CostingTemp obj_Costing = new DataAccess.CostingTemp();
                DataTable dt = new DataTable();
                int bid = Convert.ToInt32(Session["LoginBranchid"]);
                int empid = Convert.ToInt32(Session["LoginEmpId"]);
                dt = obj_Costing.GetSP_CostingRPT(Convert.ToInt32(txt_job.Text), bid, empid);

                double temp1, temp2, temp3, temp4, temp5, temp6;
                temp1 = 0; temp2 = 0;

                DataTable dtex = new DataTable();
                dtex.Columns.Add("Charges");
                dtex.Columns.Add("Billing");
                dtex.Columns.Add("Cost");
                dtex.Columns.Add("Revenue");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dtex.NewRow();
                    dr["Charges"] = dt.Rows[i]["chargename"].ToString();
                    dr["Billing"] = Convert.ToDouble(dt.Rows[i]["Income"].ToString()).ToString("#,0.00");
                    dr["Cost"] = Convert.ToDouble(dt.Rows[i]["Expenses"].ToString()).ToString("#,0.00");
                    temp1 += Convert.ToDouble((dt.Rows[i]["Income"].ToString()));
                    temp2 += Convert.ToDouble((dt.Rows[i]["Expenses"].ToString()));
                    temp4 = Convert.ToDouble((dt.Rows[i]["Income"].ToString()));
                    temp5 = Convert.ToDouble((dt.Rows[i]["Expenses"].ToString()));
                    temp6 = temp4 - temp5;
                    dr["Revenue"] = temp6.ToString("#,0.00");
                    dtex.Rows.Add(dr);
                }
                temp3 = temp1 - temp2;
                DataRow dr1 = dtex.NewRow();
                dr1["Charges"] = "Total";
                dr1["Billing"] = temp1.ToString("#,0.00");
                dr1["Cost"] = temp2.ToString("#,0.00");
                dr1["Revenue"] = temp3.ToString("#,0.00");
                dtex.Rows.Add(dr1);

                GridView3.DataSource = dtex;
                GridView3.DataBind();

                if (Grdcost.Rows.Count > 0)
                {
                    string Filename;
                    string Filename1, Filename2;
                    Filename = Fn_GetTrantypename() + " Costing With Details for Job # :" + txt_job.Text;
                    Filename1 = Fn_GetTrantypename() + " Costing With Voucherwise Details for Job # :" + txt_job.Text;
                    Filename2 = Fn_GetTrantypename() + " Costing With Chargerwise Details for Job # :" + txt_job.Text;
                    Response.Clear();
                    Grdcost.Columns[6].Visible = false;
                    Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");

                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringBuilder SB = new StringBuilder();
                    StringWriter StringWriter = new System.IO.StringWriter(SB);
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                    int cnt = Grdcost.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td></td><td style='font-weight:bold;white-space:nowrap'>" + Filename1 + "</td></tr>");
                    SB.Append("</table>");

                    StringBuilder SB1 = new StringBuilder();
                    StringWriter StringWriter1 = new System.IO.StringWriter(SB1);
                    HtmlTextWriter HtmlTextWriter1 = new HtmlTextWriter(StringWriter1);
                    SB1.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td></td><td style='font-weight:bold;white-space:nowrap'>" + Filename2 + "</td></tr>");
                    SB1.Append("</table>");

                    if (Grdcost.Visible == true)
                    {
                        Grdcost.GridLines = GridLines.Both;
                        Grdcost.HeaderStyle.Font.Bold = true;
                        Grdcost.RenderControl(HtmlTextWriter);

                        GridView3.GridLines = GridLines.Both;
                        GridView3.HeaderStyle.Font.Bold = true;
                        GridView3.RenderControl(HtmlTextWriter1);
                    }

                    Response.Write("<table><tr><td>");
                    Response.Write(StringWriter.ToString());
                    Response.Write("</td></tr></table>");

                    Response.Write("<table><tr><td>");
                    Response.Write(StringWriter1.ToString());
                    Response.Write("</td></tr></table>");
                    Response.Flush();
                    Response.End();
                    //string Filename, strtemp;
                    //Filename = "Costing With Details for Job # :" + txt_job.Text;
                    //strtemp = Utility.Fn_ExportExcel(Grdcost, "<tr><td><td><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr>");
                    //Response.Clear();
                    //Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                    //Response.Buffer = true;
                    //Response.Charset = "UTF-8";
                    //Response.ContentType = "application/vnd.ms-excel";
                    //Response.Write(strtemp);
                    //Response.End();
                }

                }
        }
        protected void btn_print_Click(object sender, EventArgs e)
        {
            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "", str_sfrpt = "", sp_rep = "";
            DataTable obj_dt = new DataTable();
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DateTime get_date, GST_date;

            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                return;
            }
            try
            {
                if (txt_job.Text.Trim().Length > 0)
                {
                    
                    //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                    if (lbl_Header.Text.ToString() != "PreAlert")
                    {
                        double int_Cbm = 0, int_Chargewt = 0;
                        int int_Cont20 = 0, int_Cont40 = 0, int_Pkg = 0;

                        string str_jobdate = "", str_closedate = "";
                        obj_dt = da_obj_Costingdt.GetCBM2040fromJob(Convert.ToInt32(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            //int_Cbm = string.IsNullOrEmpty(obj_dt.Rows[0]["cbm"].ToString()) ? 0 : Convert.ToInt32(obj_dt.Rows[0]["cbm"].ToString());
                            //int_Cont20 = string.IsNullOrEmpty(obj_dt.Rows[0]["cont20"].ToString()) ? 0 : Convert.ToInt32(obj_dt.Rows[0]["cont20"].ToString());
                            //int_Cont40 = string.IsNullOrEmpty(obj_dt.Rows[0]["cont40"].ToString()) ? 0 : Convert.ToInt32(obj_dt.Rows[0]["cont40"].ToString());
                            //int_Chargewt = string.IsNullOrEmpty(obj_dt.Rows[0]["wt"].ToString()) ? 0 : Convert.ToInt32(obj_dt.Rows[0]["wt"].ToString());
                            //int_Pkg = string.IsNullOrEmpty(obj_dt.Rows[0]["pkg"].ToString()) ? 0 : Convert.ToInt32(obj_dt.Rows[0]["pkg"].ToString());
                            if (string.IsNullOrEmpty(obj_dt.Rows[0]["cbm"].ToString()))
                            {
                                int_Cbm = 0;
                            }
                            else
                            {
                                int_Cbm = Convert.ToDouble(obj_dt.Rows[0]["cbm"].ToString());
                            }

                            if (string.IsNullOrEmpty(obj_dt.Rows[0]["cont20"].ToString()))
                            {
                                int_Cont20 = 0;
                            }
                            else
                            {
                                int_Cont20 = Convert.ToInt32(obj_dt.Rows[0]["cont20"].ToString());
                            }
                            if (string.IsNullOrEmpty(obj_dt.Rows[0]["cont40"].ToString()))
                            {
                                int_Cont40 = 0;
                            }
                            else
                            {
                                int_Cont40 = Convert.ToInt32(obj_dt.Rows[0]["cont40"].ToString());
                            }
                            if (string.IsNullOrEmpty(obj_dt.Rows[0]["wt"].ToString()))
                            {
                                int_Chargewt = 0.0;
                            }
                            else
                            {
                                int_Chargewt = Convert.ToDouble(obj_dt.Rows[0]["wt"].ToString());
                            }
                            if (string.IsNullOrEmpty(obj_dt.Rows[0]["pkg"].ToString()))
                            {
                                int_Pkg = 0;
                            }
                            else
                            {
                                int_Pkg = Convert.ToInt32(obj_dt.Rows[0]["pkg"].ToString());
                            }
                            //int_Cont20 = Convert.ToInt32(obj_dt.Rows[0]["cont20"].ToString());
                            // int_Cont40 = Convert.ToInt32(obj_dt.Rows[0]["cont40"].ToString());
                            // int_Chargewt = Convert.ToInt32(obj_dt.Rows[0]["wt"].ToString());
                            //int_Pkg= Convert.ToInt32(obj_dt.Rows[0]["pkg"].ToString());
                        }
                        obj_dt = da_obj_Costingdt.GetJobdtls(Session["StrTranType"].ToString(), Convert.ToInt32(txt_job.Text.Trim().ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            str_jobdate = obj_dt.Rows[0]["jobdate"].ToString();
                            str_closedate = obj_dt.Rows[0]["jobclosedate"].ToString();
                        }
                        //DataAccess.CostingTemp da_obj_CostTemp = new DataAccess.CostingTemp();
                        int int_Chargeid = 0, int_Vouyear = 0;
                        double Income, Expense;
                        da_obj_CostTemp.DelCostingTempCharges(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                        int_Vouyear = Convert.ToInt32(Session["Vouyear"].ToString());
                        for (int i = 1; i <= 8; i++)
                        {
                            // obj_dt = da_obj_CostTemp.GetInvoiceCharges(int.Parse(txt_job.Text.Trim().ToString()), int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), int_Vouyear, i);
                            string trantype = Session["StrTranType"].ToString();
                            obj_dt = da_obj_CostTemp.GetInvoiceCharges(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text.Trim().ToString()), trantype, int_Vouyear, i);
                            if (obj_dt.Rows.Count > 0)
                            {
                                for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                                {
                                    int_Chargeid = Convert.ToInt32(obj_dt.Rows[j]["charges"].ToString());
                                    //if (i % 2 == 0)
                                    //{
                                    //    Income = double.Parse(obj_dt.Rows[j]["amount"].ToString());
                                    //    Expense = 0;
                                    //}
                                    //else
                                    //{
                                    //    Expense = double.Parse(obj_dt.Rows[j]["amount"].ToString());
                                    //    Income = 0;
                                    //}
                                    if (i == 1 || i == 3 || i == 5 || i == 8)
                                    {
                                        Income = Convert.ToDouble(obj_dt.Rows[j]["amount"].ToString());
                                        Expense = 0;
                                    }
                                    else
                                    {
                                        Income = 0;
                                        Expense = Convert.ToDouble(obj_dt.Rows[j]["amount"].ToString());
                                    }

                                    //  da_obj_CostTemp.InsJobChargesTemp(int.Parse(txt_job.Text.Trim().ToString()), int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), i, int.Parse(Session["LoginEmpId"].ToString()), Income, Expense, int_Chargeid);
                                    da_obj_CostTemp.InsJobChargesTemp(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), i, int.Parse(Session["LoginEmpId"].ToString()), Income, Expense, int_Chargeid);
                                }
                            }
                        }
                        string str_AgentBLcount = "", str_OurBLCount = "";
                        obj_dt = da_obj_Costingdt.GetCountAgentOurBL4Job(int.Parse(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            str_AgentBLcount = obj_dt.Rows[0]["AgentControl"].ToString();
                            str_OurBLCount = obj_dt.Rows[0]["OurControl"].ToString();
                        }
                        str_RptName = "TempCostingCharges.rpt";
                        str_sf = "{CostingTempCharges.jobno}=" + txt_job.Text + " and {CostingTempCharges.empid}=" + Session["LoginEmpId"].ToString() + " and {CostingTempCharges.branchid}=" + Session["LoginBranchid"].ToString() + " and {CostingTempCharges.chargeid} <> 2011";
                        //str_sf = "{CostingTempCharges.jobno}=" + txt_job.Text + " and {CostingTempCharges.empid}=" + Session["LoginEmpId"].ToString() + " and {CostingTempCharges.branchid}=" + Session["LoginBranchid"].ToString();


                        //GST

                        str_sfrpt = "&jobno=" + txt_job.Text + "&empid=" + Session["LoginEmpId"].ToString() + "&bid=" + Session["LoginBranchid"].ToString();

                        //string mlo = Server.HtmlDecode(txt_mlo.Text);
                        if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                        {
                            str_sp = "trantype=" + Session["StrTranType"].ToString() + "~mlo=" + txt_mlo.Text + "~agent=" + txt_agent.Text + "~cbm=" + string.Format("{0:0.000}", int_Cbm.ToString()) + "~cont20=" + int_Cont20 + "~cont40=" + int_Cont40 + "~jobopen=" + str_jobdate + "~jobclose=" + str_closedate + "~vsl=" + txt_vsl.Text + "~jobcloserks=" + txt_remark.Text + "~AgentBL=" + str_AgentBLcount + "~OurBL=" + str_OurBLCount;
                            //GST
                            sp_rep = "&trantype=" + Session["StrTranType"].ToString() + "&mlo=" + txt_mlo.Text + "&agent=" + txt_agent.Text.Replace("'", "") + "&cbm=" + string.Format("{0:0.000}", int_Cbm.ToString()) + "&cont20=" + int_Cont20 + "&cont40=" + int_Cont40 + "&jobopen=" + str_jobdate + "&jobclose=" + str_closedate + "&vsl=" + txt_vsl.Text + "&jobcloserks=" + txt_remark.Text + "&AgentBL=" + str_AgentBLcount + "&OurBL=" + str_OurBLCount;
                        }
                        else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                        {
                            str_sp = "trantype=" + Session["StrTranType"].ToString() + "~mlo=" + txt_mlo.Text + "~agent=" + txt_agent.Text + "~cbm=" + string.Format("{0:0.000}", int_Cbm.ToString()) + "~cont20=" + string.Format("{0:0.000}", int_Chargewt.ToString()) + "~cont40=" + int_Cont40 + "~jobopen=" + str_jobdate + "~jobclose=" + str_closedate + "~vsl=" + txt_vsl.Text + "~jobcloserks=" + txt_remark.Text + "~AgentBL=" + str_AgentBLcount + "~OurBL=" + str_OurBLCount;
                            //GST
                            sp_rep = "&trantype=" + Session["StrTranType"].ToString() + "&mlo=" + txt_mlo.Text + "&agent=" + txt_agent.Text.Replace("'", "") + "&cbm=" + string.Format("{0:0.000}", int_Cbm.ToString()) + "&cont20=" + int_Cont20 + "&cont40=" + int_Cont40 + "&jobopen=" + str_jobdate + "&jobclose=" + str_closedate + "&vsl=" + txt_vsl.Text + "&jobcloserks=" + txt_remark.Text + "&AgentBL=" + str_AgentBLcount + "&OurBL=" + str_OurBLCount;
                        }

                        //GST

                        str_Script = "window.open('../Reportasp/CostingRPT.aspx?SFormula=" + str_sfrpt + "&Parameter=" + sp_rep + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //if (get_date >= GST_date)
                        //{
                        //    str_Script = "window.open('../Reportasp/CostingRPT.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');"; 
                        //}
                        //else
                        //{
                        //    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //}
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
                                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 70, 3, int.Parse(Session["LoginBranchid"].ToString()), "CHA " + txt_job.Text);
                                break;

                        }
                    }
                   
                } 
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }
        public void textclear()
        {
            txt_remark.Text = "";
            Grdcost.DataSource = new DataTable();
            Grdcost.DataBind();
            grdclsjob.DataSource = new DataTable();
            grdclsjob.DataBind();
            Grd_job.DataSource = new DataTable();
            Grd_job.DataBind();
            clearAll();
            
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                txt_date.Text = "";
                txt_job.Text = "";
                textclear();
                Image3.Visible = false;
                if (Session["trantype_process"] != null)
                {
                    ddl_product.SelectedIndex = 0;
                    Session["StrTranType"] = null;

                }
                /* if (Session["trantype_process"] != null)
                 {
                     dt_MenuRights = Session["trantype_process"] as DataTable;
                     ddl_product.Items.Add("");
                     for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                     {
                         if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                         {
                             ddl_product.Items.Add("Ocean Exports");
                         }
                         else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                         {
                             ddl_product.Items.Add("Ocean Imports");
                         }
                         else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                         {
                             ddl_product.Items.Add("Air Exports");
                         }
                         else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                         {
                             ddl_product.Items.Add("Air Imports");
                         }
                     }
                     // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                 }
                 else if (Session["StrTranType"] != null)
                 {
                     ddl_product.Items.Add("");
                     if (Session["StrTranType"].ToString() == "BT")
                     {
                         ddl_product.Items.Add("Bonded Trucking");
                         ddl_product.SelectedValue = "Bonded Trucking";
                     }
                     else if (Session["StrTranType"].ToString() == "CH")
                     {
                         ddl_product.Items.Add("CHA");
                         ddl_product.SelectedValue = "CHA";
                     }
                     else if (Session["StrTranType"].ToString() == "FE")
                     {
                         ddl_product.Items.Add("Ocean Exports");
                         ddl_product.SelectedValue = "Ocean Exports";
                     }
                     else if (Session["StrTranType"].ToString() == "FI")
                     {
                         ddl_product.Items.Add("Ocean Imports");
                         ddl_product.SelectedValue = "Ocean Imports";
                     }
                     else if (Session["StrTranType"].ToString() == "AE")
                     {
                         ddl_product.Items.Add("Air Exports");
                         ddl_product.SelectedValue = "Air Exports";
                     }
                     else if (Session["StrTranType"].ToString() == "AI")
                     {
                         ddl_product.Items.Add("Air Imports");
                         ddl_product.SelectedValue = "Air Imports";
                     }
                     //ddl_product.SelectedIndex = 1;
                     ddl_product.Enabled = false;

                 }

             else
             {
                 //this.Response.End();
                 if( Session["home"].ToString()!="")
                 {
                     if (Session["home"].ToString() == "CS")
                     {
                         if (Session["StrTranType"].ToString() == "FE")
                         {
                             // headerlable1.InnerText = "OceanExports";
                             Response.Redirect("../Home/OECSHome.aspx");

                         }
                         else if (Session["StrTranType"].ToString() == "FI")
                         {
                             // headerlable1.InnerText = "OceanImports";
                             Response.Redirect("../Home/OICSHome.aspx");
                         }
                         else if (Session["StrTranType"].ToString() == "AE")
                         {
                             // headerlable1.InnerText = "AirExports";
                             Response.Redirect("../Home/AECSHome.aspx");
                         }
                         else if (Session["StrTranType"].ToString() == "AI")
                         {
                             //  headerlable1.InnerText = "AirImports";
                             Response.Redirect("../Home/AICSHome.aspx");
                         }
                     }
                     else if (Session["home"].ToString() == "OPS&DOC")
                     {
                         if (Session["StrTranType"].ToString() == "FE")
                         {
                             // headerlable1.InnerText = "OceanExports";
                             Response.Redirect("../Home/OEOpsAndDocs.aspx");

                         }
                         else if (Session["StrTranType"].ToString() == "FI")
                         {
                             // headerlable1.InnerText = "OceanImports";
                             Response.Redirect("../Home/OEOpsAndDocs.aspx");
                         }
                         else if (Session["StrTranType"].ToString() == "AE")
                         {
                             // headerlable1.InnerText = "AirExports";
                             Response.Redirect("../Home/OEOpsAndDocs.aspx");
                         }
                         else if (Session["StrTranType"].ToString() == "AI")
                         {
                             //  headerlable1.InnerText = "AirImports";
                             Response.Redirect("../Home/OEOpsAndDocs.aspx");
                         }
                     }

                 }

                }*/
            }
            else
            {
                //  this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                // headerlable1.InnerText = "OceanExports";
                                Response.Redirect("../Home/OECSHome.aspx");

                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                // headerlable1.InnerText = "OceanImports";
                                Response.Redirect("../Home/OICSHome.aspx");
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                // headerlable1.InnerText = "AirExports";
                                Response.Redirect("../Home/AECSHome.aspx");
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                //  headerlable1.InnerText = "AirImports";
                                Response.Redirect("../Home/AICSHome.aspx");
                            }
                        }
                    }
                    else if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                // headerlable1.InnerText = "OceanExports";
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");

                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                // headerlable1.InnerText = "OceanImports";
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                // headerlable1.InnerText = "AirExports";
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                //  headerlable1.InnerText = "AirImports";
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            }
                        }
                       
                    }
                    else if (Session["home"].ToString() == "MIS")
                    {
                        Response.Redirect("../Home/MISAndApproval.aspx");
                    }

                    else
                    {
                        this.Response.End();
                    }
                }
                else
                {
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "CH")
                        {
                            Response.Redirect("../Home/CHAHome.aspx");
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
        }
        //public void CostingTemp(int jobno, string trantype)
        //{
        //    int checkbranch = 0;
        //    costtempobj.DelCostingDetailsRpt(jobno, trantype, "V", Convert.ToInt32(Session["LoginBranchid"]), 0, "");
        //    blamount = 0;
        //    blexpense = 0;
        //    loguserid = Convert.ToInt32(Session["LoginEmpId"]);
        //    branchid = Convert.ToInt32(Session["LoginBranchid"]);
        //    DtJob = costtempobj.GetClosedJobDts(jobno, trantype, branchid);

        //    for (i = 0; i <= DtJob.Rows.Count - 1; i++)
        //    {
        //        mblexpense = costtempobj.GetcostPA(DtJob.Rows[i][1].ToString(), trantype, branchid);
        //        mblCredit = costtempobj.GetCreditDebit(DtJob.Rows[i][1].ToString(), trantype, branchid, "Credit");
        //        Closeddate = Convert.ToDateTime(DtJob.Rows[i]["jobclosedate"].ToString());
        //        mblamount = costtempobj.GetcostInv(DtJob.Rows[i][1].ToString(), trantype, branchid);
        //        mblDebit = costtempobj.GetCreditDebit(DtJob.Rows[i][1].ToString(), trantype, branchid, "Debit");
        //        if (trantype == "FE" || trantype == "FI")
        //        {
        //            jobtype = Convert.ToInt32(DtJob.Rows[i]["jobtype"].ToString());
        //            mlo = Convert.ToInt32(DtJob.Rows[i]["mlo"].ToString());
        //            DtCT = costtempobj.GetCBMTues(Convert.ToInt32(DtJob.Rows[i]["jobno"]), trantype, branchid);
        //            if (DtCT.Rows.Count > 0)
        //            {
        //                if (DtCT.Rows[0]["cbmtotal"].ToString() != "" && DtCT.Rows[0]["Tuestotal"].ToString() != "")
        //                {
        //                    totalcbm = Convert.ToDouble(DtCT.Rows[0]["cbmtotal"].ToString());
        //                    totaltues = Convert.ToDouble(DtCT.Rows[0]["Tuestotal"].ToString());
        //                }
        //            }
        //        }
        //        else if (trantype == "AE" || trantype == "AI")
        //        {
        //            jobtype = 0;
        //            mlo = Convert.ToInt32(DtJob.Rows[i]["airline"].ToString());
        //            DtCT = costtempobj.GetCBMTues(Convert.ToInt32(DtJob.Rows[i]["jobno"]), trantype, branchid);
        //            if (DtCT.Rows.Count > 0)
        //            {
        //                if (DtCT.Rows[0][0].ToString() != "")
        //                {
        //                    jobchargewt = Convert.ToDouble(DtCT.Rows[0][0].ToString());
        //                }
        //            }
        //        }
        //        DtBL = costtempobj.GetBLRow(Convert.ToInt32(DtJob.Rows[i]["jobno"]), trantype, branchid);

        //        for (j = 0; j <= DtBL.Rows.Count - 1; j++)
        //        {
        //            blamount = Convert.ToDouble(costtempobj.GetcostInv(DtBL.Rows[j][1].ToString(), trantype, branchid));
        //            blDebit = Convert.ToDouble(costtempobj.GetCreditDebit(DtBL.Rows[j][1].ToString(), trantype, branchid, "Debit"));
        //            blexpense = Convert.ToDouble(costtempobj.GetcostPA(DtBL.Rows[j][1].ToString(), trantype, branchid));
        //            blCredit = Convert.ToDouble(costtempobj.GetCreditDebit(DtBL.Rows[j][1].ToString(), trantype, branchid, "Credit"));
        //            if (trantype == "FE" || trantype == "FI")
        //            {
        //                bltues = Convert.ToInt32(DtBL.Rows[j]["cont20"].ToString()) + ((Convert.ToInt32(DtBL.Rows[j]["cont40"].ToString()) * 2));
        //                blcbm = Convert.ToDouble(DtBL.Rows[j]["cbm"].ToString());
        //                checkbranch = Convert.ToInt32(DtBL.Rows[j]["branch"].ToString());
        //                if (mblamount != 0)
        //                {
        //                    if (jobtype == 3)
        //                    {
        //                        if (bltues == 0)
        //                        {
        //                            blamount = blamount + ((mblamount / 1) * 1);
        //                        }
        //                        else if (totaltues == 0)
        //                        {
        //                            blamount = blamount + ((mblamount / 1) * 1);
        //                        }
        //                        else
        //                        {
        //                            blamount = blamount + ((mblamount / totaltues) * bltues);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (blcbm == 0)
        //                        {
        //                            blamount = blamount + 0;
        //                        }
        //                        else if (totalcbm == 0)
        //                        {
        //                            blamount = blamount + 0;
        //                        }
        //                        else
        //                        {
        //                            blamount = blamount + ((mblamount / totalcbm) * blcbm);
        //                        }
        //                    }
        //                }
        //                if (mblDebit != 0)
        //                {
        //                    if (jobtype == 3)
        //                    {
        //                        if (bltues == 0)
        //                        {
        //                            blDebit = blDebit + ((mblDebit / 1) * 1);
        //                        }
        //                        else if (totaltues == 0)
        //                        {
        //                            blDebit = blDebit + ((mblDebit / 1) * 1);
        //                        }
        //                        else
        //                        {
        //                            blDebit = blDebit + ((mblDebit / totaltues) * bltues);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (blcbm == 0)
        //                        {
        //                            blDebit = blDebit + 0;
        //                        }
        //                        else if (totalcbm == 0)
        //                        {
        //                            blDebit = blDebit + 0;
        //                        }
        //                        else
        //                        {
        //                            blDebit = blDebit + ((mblDebit / totalcbm) * blcbm);
        //                        }
        //                    }
        //                }

        //                if (mblexpense != 0)
        //                {
        //                    if (jobtype == 3)
        //                    {
        //                        if (bltues == 0)
        //                        {
        //                            blexpense = blexpense + ((mblexpense / 1) * 1);
        //                        }
        //                        else if (totaltues == 0)
        //                        {
        //                            blexpense = blexpense + ((mblexpense / 1) * 1);
        //                        }
        //                        else
        //                        {
        //                            blexpense = blexpense + ((mblexpense / totaltues) * bltues);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (blcbm == 0)
        //                        {
        //                            blexpense = blexpense + 0;
        //                        }
        //                        else if (totalcbm == 0)
        //                        {
        //                            blexpense = blexpense + 0;
        //                        }
        //                        else
        //                        {
        //                            blexpense = blexpense + ((mblexpense / totalcbm) * blcbm);
        //                        }
        //                    }
        //                }
        //                if (mblCredit != 0)
        //                {
        //                    if (jobtype == 3)
        //                    {
        //                        if (bltues == 0)
        //                        {
        //                            blCredit = blCredit + ((mblCredit / 1) * 1);
        //                        }
        //                        else if (totaltues == 0)
        //                        {
        //                            blCredit = blCredit + ((mblCredit / 1) * 1);
        //                        }
        //                        else
        //                        {
        //                            blCredit = blCredit + ((mblCredit / totaltues) * bltues);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (blcbm == 0)
        //                        {
        //                            blCredit = blCredit + 0;
        //                        }
        //                        else if (totalcbm == 0)
        //                        {
        //                            blCredit = blCredit + 0;
        //                        }
        //                        else
        //                        {
        //                            blCredit = blCredit + ((mblCredit / totalcbm) * blcbm);
        //                        }
        //                    }
        //                }

        //                else if(trantype == "AE" || trantype == "AI")
        //                {
        //                    blchargewt =Convert.ToDouble(DtBL.Rows[j]["chargewt"].ToString());
        //                    if(mblamount != 0)
        //                    {
        //                        blamount = blamount + ((mblamount / jobchargewt) * blchargewt);
        //                    }

        //                    if(mblDebit != 0)
        //                    {
        //                        blDebit = blDebit + ((mblDebit / jobchargewt) * blchargewt);
        //                    }

        //                    if(mblexpense !=0)
        //                    {
        //                        blexpense = blexpense + ((mblexpense / jobchargewt) * blchargewt);
        //                    }
        //                    if(mblCredit !=0)
        //                    {
        //                        blCredit = blCredit + ((mblCredit / jobchargewt) * blchargewt);
        //                    }
        //                }

        //                  jobno = Convert.ToInt32(DtBL.Rows[j][0].ToString());
        //                  blno = DtBL.Rows[j][1].ToString();
        //                if(trantype == "FE" || trantype == "FI")
        //                {
        //                    if(DtBL.Rows[j][2].ToString() != "" && DtBL.Rows[j][3].ToString() != "")
        //                    {
        //                        cont20 = Convert.ToInt32(DtBL.Rows[j][2].ToString());
        //                        cont40 = Convert.ToInt32(DtBL.Rows[j][3].ToString());
        //                    }
        //                }
        //                else if(trantype == "AE" || trantype == "AI")
        //                {
        //                     cont20 = 0;
        //                     cont40 = 0;
        //                }
        //                 nomination = Convert.ToChar( DtBL.Rows[j][4].ToString());
        //        volume = Convert.ToDouble( DtBL.Rows[j][5].ToString());
        //        shipper =Convert.ToInt32( DtBL.Rows[j][6].ToString());
        //        consignee =Convert.ToInt32( DtBL.Rows[j][7].ToString());
        //        notify =Convert.ToInt32( DtBL.Rows[j][8].ToString());
        //        agent =Convert.ToInt32( DtBL.Rows[j][9].ToString());
        //        pol =Convert.ToInt32(DtBL.Rows[j][10].ToString());
        //        pod = Convert.ToInt32(DtBL.Rows[j][11].ToString());
        //        salesperson = costtempobj.GetSalesPerson(blno, trantype, branchid);
        //        blamount = blamount + blDebit;
        //        blexpense = blexpense + blCredit;
        //        int a;
        //        if (string.IsNullOrEmpty(blamount.ToString()) == true || int.TryParse(blamount.ToString(), out a) == false)
        //        {
        //            blamount = 0;
        //        }
        //        int b;
        //        if (string.IsNullOrEmpty(blexpense.ToString()) == true || int.TryParse(blexpense.ToString(), out b) == false)
        //        {
        //            blexpense = 0;
        //        }
        //            }
        //        }
        //    }
        //}

        protected void clearAll()
        {
            // ddl_product.SelectedIndex = 0;
            //Grd_CH.Visible = true;
            //P4.Visible = true;
            if (trantype == "BT" && lbl_Header.Text == "Job P & L / MIS")
            {
                Grd_BT.Visible = false;
                P5.Visible = false;
                grdclsjob.Visible = true;
                P8.Visible = true;
                grdclsjob.DataSource = new DataTable();
                grdclsjob.DataBind();

                Grd_CH.Visible = true;
                P4.Visible = true;
                Grd_FEFI.Visible = false;
                P2.Visible = false;
                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;

            }
            else if (trantype == "BT" && lbl_Header.Text == "Costing Details")
            {
                Grd_BT.Visible = false;
                P5.Visible = false;
                grdclsjob.Visible = false;
                P8.Visible = false;
                grdclsjob.DataSource = new DataTable();
                grdclsjob.DataBind();
                Grd_CH.Visible = false;
                P4.Visible = false;
                Grd_job.Visible = false;
                P1.Visible = false;
                Grd_FEFI.Visible = false;
                P2.Visible = false;
                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;
            }

            else if (trantype == "CH" && lbl_Header.Text == "Job P & L / MIS")
            {
                Grd_CH.Visible = true;
                P4.Visible = true;
                Grd_FEFI.Visible = false;
                P2.Visible = false;
                grdclsjob.Visible = false;
                P8.Visible = false;

                P8.Visible = true;
                grdclsjob.Visible = true;
                btn_confirm.Visible = true;idconfirm.Visible = true;
                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;
                //grdclsjob.Visible = true;
                //P8.Visible = true;
                //grdclsjob.DataSource = new DataTable();
                //grdclsjob.DataBind();
            }
            else if (trantype == "AE" && lbl_Header.Text == "Job P & L / MIS")
            {
                Grd_AEAI.Visible = true;
                //P3.Visible = true;
                grdclsjob.DataSource = new DataTable();
                grdclsjob.DataBind();
                Grd_CH.Visible = false;
                P4.Visible = false;
                Grd_FEFI.Visible = false;
                P2.Visible = false;
                // btn_confirm.Visible = true;idconfirm.Visible = true;

                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;
            }
            else if (trantype == "AI" && lbl_Header.Text == "Job P & L / MIS")
            {
                Grd_AEAI.Visible = true;
                //P3.Visible = true;
                grdclsjob.DataSource = new DataTable();
                grdclsjob.DataBind();
                Grd_CH.Visible = false;
                P4.Visible = false;
                Grd_FEFI.Visible = false;
                P2.Visible = false;
                // btn_confirm.Visible = true;idconfirm.Visible = true;
                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                Grd_FEFI.Visible = true;
                P2.Visible = true;
            }

            txt_date.Text = "";
            txt_vsl.Text = "";
            txt_mbl.Text = "";
            txt_eta.Text = "";
            txt_pol.Text = "";
            txt_pod.Text = "";
            txt_agent.Text = "";
            txt_mlo.Text = "";
            ddl_job.SelectedIndex = 0;
            //ddl_job.SelectedValue

            if (txt_job.Text == "")
            {
                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            //btn_cancel.Text = "Back";
            Grd_job.Visible = false;
            P1.Visible = false;
        
            grdclsjob.Visible = false;
            P8.Visible = false;
            btn_confirm.Visible = false;
            lbl.Text = "";

            btn_update.Enabled = true;
            btn_update.ForeColor = System.Drawing.Color.White;
        }
        protected void Grdcost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
                    //if (e.Row.Cells[1].Text.ToString() == "")
                    //{
                    //    e.Row.ForeColor = System.Drawing.Color.Brown;
                    //}

                    if (e.Row.Cells[1].Text.ToString() != "")
                    {
                        //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                        //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                        //LinkButton Lnk = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Lnk_job");
                        //Lnk.Visible = false;

                        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grdcost, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";

                    }
                    //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grdcost, "Select$" + e.Row.RowIndex);
                    //e.Row.Attributes["style"] = "cursor:pointer";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_FEFI_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //int index1 = Convert.ToInt32(Grd_FEFI.SelectedRow.RowIndex);
                //if (GridView1.Rows.Count > 0)
                //{

                //   // txt_job.Text = GridView1.Rows[Convert.ToInt32(index1)].Cells[0].Text.ToString();
                //    txt_job.Text = Grd_FEFI.Rows[Convert.ToInt32(index1)].Cells[0].Text.ToString();

                //    txt_job_TextChanged(sender, e);
                //}

                if (ddl_job.SelectedIndex == 1)
                {
                    btn_update.Enabled = true;
                    btn_update.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    btn_update.Enabled = false;
                    btn_update.ForeColor = System.Drawing.Color.Gray;
                    grdclsjob.Visible = true;
                    P8.Visible = true;
                }
                txt_job.Text = Grd_FEFI.SelectedRow.Cells[0].Text;
                txt_job_TextChanged(sender, e);
                ddl_job.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void Grd_FEFI_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_FEFI, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_AEAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_job.SelectedIndex == 1)
                {
                    btn_update.Enabled = true;
                    btn_update.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    btn_update.Enabled = false;
                    btn_update.ForeColor = System.Drawing.Color.Gray;
                }
                txt_job.Text = Grd_AEAI.SelectedRow.Cells[0].Text;
                txt_job_TextChanged(sender, e);
                ddl_job.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void Grd_CH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_job.SelectedIndex == 1)
            {
                btn_update.Enabled = true;
                btn_update.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;
            }
            txt_job.Text = Grd_CH.SelectedRow.Cells[0].Text;
            txt_job_TextChanged(sender, e);
            ddl_job.SelectedIndex = 0;

        }

        protected void Grd_BT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_job.SelectedIndex == 1)
            {
                btn_update.Enabled = true;
                btn_update.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;
            }
            txt_job.Text = Grd_BT.SelectedRow.Cells[0].Text;
            txt_job_TextChanged(sender, e);
            ddl_job.SelectedIndex = 0;

        }

        protected void btn_job_Click(object sender, EventArgs e)
        {
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                return;
            }
            string Str_RptName = "", Str_SF = "", Str_SP = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            if (trantype == "FE")
            {
                Str_RptName = "FEUnclosedjob.rpt";
                Str_SF = "isnull({FEJobInfo.jobclosedate})  and {FEJobInfo.bid}=" + int_bid;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_job, typeof(Button), "CostingDetails", Str_Script, true);
                Session["str_sfs"] = Str_SF;
                Session["str_sp"] = Str_SP;
            }
            else if (trantype == "FI")
            {
                Str_RptName = "FIUnclosedjob.rpt";
                Str_SF = "isnull({FIJobInfo.jobclosedate})  and {FIJobInfo.bid}=" + int_bid;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_job, typeof(Button), "CostingDetails", Str_Script, true);
                Session["str_sfs"] = Str_SF;
                Session["str_sp"] = Str_SP;
            }
            else if (trantype == "AE")
            {
                Str_RptName = "RptAEJobUnclosed.rpt";
                Str_SF = "isnull({AEJobInfo.jobclosedate})  and {AEJobInfo.bid}=" + int_bid;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_job, typeof(Button), "CostingDetails", Str_Script, true);
                Session["str_sfs"] = Str_SF;
                Session["str_sp"] = Str_SP;
            }
            else if (trantype == "AI")
            {
                Str_RptName = "RptAIJobUnclosed.rpt";
                Str_SF = "isnull({AIJobInfo.jobclosedate})  and {AIJobInfo.bid}=" + int_bid;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_job, typeof(Button), "CostingDetails", Str_Script, true);
                Session["str_sfs"] = Str_SF;
                Session["str_sp"] = Str_SP;
            }
            else if (trantype == "BT")
            {
                Str_RptName = "RptBTUnclosedJobs.rpt";
                Str_SF = "isnull({BTJobInfo.jobclosedate})  and {BTJobInfo.bid}=" + int_bid;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_job, typeof(Button), "CostingDetails", Str_Script, true);
                Session["str_sfs"] = Str_SF;
                Session["str_sp"] = Str_SP;
            }
            else if (trantype == "CH")
            {
                Str_RptName = "RptCHUnclosejob  .rpt";
                Str_SF = "isnull({CHJobInfo.jobclosedate})  and {CHJobInfo.bid}=" + int_bid;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_job, typeof(Button), "CostingDetails", Str_Script, true);
                Session["str_sfs"] = Str_SF;
                Session["str_sp"] = Str_SP;
            }

        }

        protected void jobcloseagainstvoucher()
        {
            //DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
            DataTable dtadvise = new DataTable();
            //DataAccess.CloseJobs JobCloseObj = new DataAccess.CloseJobs();
            dtadvise = obj_da_DC.FillBLNo(Convert.ToInt32(txt_job.Text.Trim()), trantype, int_bid);
            if (dtadvise.Rows.Count == 0)
            {
                Flag = 1;
            }
            dtadvise = JobCloseObj.CheckVoucherForJobClose(Convert.ToInt32(txt_job.Text.Trim()), trantype, int_bid);
            if (dtadvise.Rows.Count > 0)
            {
                Flagvou = 100;
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
                DataTable obj_dt = new DataTable();
                DataTable dtconf = new DataTable();
                DataSet dscheck = new DataSet();
                string strmsg = "";
                int int_Chargeid = 0, int_Vouyear = 0;
                //DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
                //DataAccess.Accounts.Invoice obj_dA_Invoice = new DataAccess.Accounts.Invoice();

                  int_Vouyear = Convert.ToInt32(Session["Vouyear"].ToString());
                if (txt_job.Text.Trim().Length > 0 && txt_job.Text != "0")
                {
                    int_jobno = Convert.ToInt32(txt_job.Text.Trim().ToString());
                    dt_date = obj_da_Log.GetDate();

                    //DateTime dt_date =Convert.ToDateTime("03/06/2019");
                    //dt_date = dt_date.AddDays(-9);
                    //Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));

                    //if (Close_date <= dt_date)
                    //{
                    //    txt_date.Text = Utility.fn_ConvertDate(dt_date.AddDays(9).ToShortDateString());
                    //    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Only 9 days before the closingdate is Allowed');", true);
                    //    return;
                    //}
                    //else
                    //{
                    //    Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                    //}

                    /*    intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         dt_date = Convert.ToDateTime(dt_date.ToShortDateString());

                         dt_date = Convert.ToDateTime(dt_date.AddDays(-Logobj.GetDate().Day));
                         Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                         //if (Session["LoginBranchid"].ToString() != "3")
                         //{

                         if (dt_date > Close_date)
                             {
                                 txt_date.Text = Utility.fn_ConvertDate(dt_date.AddDays(intdays).ToShortDateString());
                                 ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Only " + intdays + " days before the closingdate is Allowed');", true);
                                 return;
                             }
                             else
                             {
                                 Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                             }

                      */
                    intdays = bobj.GetClosingid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    dt_date = dt_date.AddDays(-Logobj.GetDate().Day);
                    if ((Close_date.Day) <= intdays)
                    {
                        txt_date.Text = Utility.fn_ConvertDate(dt_date.ToShortDateString());
                    }
                    else
                    {
                        txt_date.Text = String.Format("{0:dd/MM/yyyy}", dt_date);
                    }
                    Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));

                    //}
                    //else
                    //{
                    //    Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                    //}

                    if (Grdcost.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Grdcost.Rows.Count - 1; i++)
                        {
                            if (Grdcost.Rows[i].Cells[3].Text.ToString() == "UnApproved")
                            {
                                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Please Approve all the UnApproved vouchers before Closing the Job #" + txt_job.Text + "');", true);
                                return;
                            }
                        }
                    }
                    jobcloseagainstvoucher();
                    if (Flag == 1)
                    {
                        if (Flagvou == 100)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Vouchers are there in Job , Create HBL # and then Close it  " + txt_job.Text + "');", true);
                            Flag = 0;
                            Flagvou = 0;
                            return;
                        }
                        else
                        {
                            this.PopUpService.Show();
                            return;
                        }
                    }
                    else
                    {
                        if (Flagvou == 0)
                        {
                            this.PopUpService.Show();
                            return;
                        }
                    }

                    //raj
                    btn_confirm_Click(sender, e);
                    dtconf = obj_da_Close.SelJobClsConfirm4JobCls(int_jobno, trantype, int_bid, int_did);
                    if (dtconf.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtconf.Rows.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                strmsg = strmsg + "," + dtconf.Rows[i]["blno"].ToString();
                            }
                            else
                            {
                                strmsg = strmsg + "," + dtconf.Rows[i]["blno"].ToString();
                            }
                        }

                        string msg = "There are BL #" + strmsg + "to be Confirmed by Volume/Income/Expense/BL Release/Destination in this Job # :" + txt_job.Text + "Hence you cannot close this Job";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alertify.alert(' " + msg + "');", true);

                        return;
                    }
                    int int_OScount=0;
                    dscheck = FEJobObj.CheckChangeJobforOSDNCNjobclosing(Convert.ToInt32(int_jobno), Convert.ToInt32(Session["LoginBranchid"].ToString()), trantype, int_Vouyear);
                    if (dscheck.Tables.Count > 0)
                    {
                        int_OScount = Convert.ToInt32(dscheck.Tables[0].Rows[0][0].ToString());
                    }

                    if (int_OScount==0)
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('OSDN/CN Vouchers not properly Deleted,Kindly delete OSDN/CN voucher for selected the Job, Hence you cannot close this Job');", true);
                        return;
                    }

                    //Newly Added
                   
                    //DataAccess.CostingTemp da_obj_CostTemp = new DataAccess.CostingTemp();
                   
                    double Income, Expense;
                    da_obj_CostTemp.DelCostingTempCharges(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                  
                    //DataTable obj_dt1 = new DataTable();
                    DataTable obj_dt2 = new DataTable();
                    DataTable obj_dt3 = new DataTable();
                    DataTable obj_dt4 = new DataTable();

                    string Str_Vouno1 = "";
                    string Str_Vouno_chargeid = "";

                    string str_Msg1 = "";

                    obj_dt2 = obj_da_Close.CheckApprovedVouchernew(int_jobno, trantype, int_bid, "P");

                    if (obj_dt2.Rows.Count > 0)
                    {
                       
                        for (int i = 0; i < obj_dt2.Rows.Count; i++)
                        {

                            Str_Vouno_chargeid = obj_dt2.Rows[i]["charges"].ToString();

                            if (Str_Vouno_chargeid == "4675")
                            {
                                Str_Vouno1 = obj_dt2.Rows[i][0].ToString() + " , " + Str_Vouno1;

                            }
                        }
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                      
                        obj_dt4 = da_obj_CostTemp.GetInvoiceCharges(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text.Trim().ToString()), trantype, int_Vouyear, i);
                        if (obj_dt4.Rows.Count > 0)
                        {
                            for (int j = 0; j <= obj_dt4.Rows.Count - 1; j++)
                            {
                                int_Chargeid = Convert.ToInt32(obj_dt4.Rows[j]["charges"].ToString());
                                
                                if (i == 1 || i == 3 || i == 5 || i==8 )
                                {
                                    Income = Convert.ToDouble(obj_dt4.Rows[j]["amount"].ToString());
                                    Expense = 0;
                                }
                                else
                                {
                                    Income = 0;
                                    Expense = Convert.ToDouble(obj_dt4.Rows[j]["amount"].ToString());
                                }

                                da_obj_CostTemp.InsJobChargesTemp(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), i, int.Parse(Session["LoginEmpId"].ToString()), Income, Expense, int_Chargeid);
                            }
                        }
                    }

                    obj_dt3 = costtempobj.GetSP_CostingRPT(Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"]));
                    if (obj_dt3.Rows.Count > 0)
                    {
                        
                        for (int k = 0; k < obj_dt3.Rows.Count; k++)
                        {
                            if (obj_dt3.Rows[k]["chargename"].ToString() == "DUTY & TAXES")
                            {
                                if (obj_dt3.Rows[k]["income"].ToString() != obj_dt3.Rows[k]["expenses"].ToString())
                                {
                                 //   str_Msg1 = "alertify.alert('There are PA( s )( " + Str_Vouno1 + ")  to be Approved in this Job # :" + txt_job.Text + "Kindly create the Vouhcer for DUTY Charges in Invoice,  Hence you cannot close this Job');";

                                    str_Msg1 = "alertify.alert('DUTY Charges Mismatch');";
                                   // ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg1, true);
                                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg1, true);
                                    return;
                                }

                            }
                        }

                    }

                    //Newly added for Transfer portid mismatch

                    DataTable obj_dttemp1 = new DataTable();
                    obj_dttemp1 = obj_da_Close.CheckShipmentTransferOrNotnewjobclosed(int_jobno, int_bid, trantype);
                    if (obj_dttemp1.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('BL portname not Match in branch port ,kindly check with BL the shipments.you cant close this Job');", true);
                        return;
                    }

                    //Newly Added

                    if (Grdcost.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Grdcost.Rows.Count - 1; i++)
                        {

                           Label cus=((Label)Grdcost.Rows[i].Cells[5].FindControl("cname"));
                           string customer = cus.Text;
                           if (customer.ToString() == "Loss")
                            {
                                if (txt_remark.Text.Trim().Length == 0)
                                {
                                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Please Enter the Remarks');", true);
                                    txt_remark.Focus();
                                    return;
                                }
                                else
                                {
                                    obj_da_Close.UpdJobCloseRemarks(int_bid, txt_job.Text, trantype, txt_remark.Text);
                                }
                            }
                           else if (customer.ToString() == "Profit")
                            {
                                if (txt_remark.Text.Trim().Length != 0)
                                {
                                    obj_da_Close.UpdJobCloseRemarks(int_bid, txt_job.Text, trantype, txt_remark.Text);
                                }
                            }
                        }
                    }
                    string Str_Vouno = "", str_Msg = "";
                    int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    DataTable obj_dttemp = new DataTable();
                    if (trantype == "FE" || trantype == "FI" || trantype == "AE" || trantype == "AI")
                    {

                        obj_dt = obj_da_DC.FillBLNo(Convert.ToInt32(txt_job.Text.Trim()), trantype, int_bid);
                        if (obj_dt.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Atleast One HBL Should Exists before Closing for the Job # " + txt_job.Text + "');", true);
                            return;
                        }
                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "I");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<Int32>(obj_dt.Columns[0].ColumnName.ToString()));
                            //var obj_Vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<Int32>("invoiceno").ToString());
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            // Str_Vouno = string.Join(",", obj_Vouno.ToString());
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are Invoice( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }

                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "P");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are PA( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }

                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "D");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are OSDN( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }

                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "C");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are OSCN( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }
                        if (obj_da_Close.CheckDCAdviseRaiseOS(int_jobno, trantype, int_bid, "D") == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('OSDN/CN has not been raised. Please create OSDN/CN then check costing with details.');", true);
                            return;
                        }
                        if (obj_da_Close.CheckDCAdviseRaiseOS(int_jobno, trantype, int_bid, "C") == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('OSDN/CN has not been raised. Please create OSDN/CN then check costing with details.');", true);
                            return;
                        }
                        //string str_Bl = "", POL_ShortName = "", POL_AccMail = "";
                        //int ICD_bid = 0, POL_Custid = 0, ICD_Jobno = 0;
                        //double BLAmount = 0, MBL_Amount = 0, POL_CBM = 0, BL_CBM = 0;
                        ////Raj sir

                        //if (trantype == "FE" || trantype == "FI")
                        //{

                        //    obj_dt = obj_da_Close.SelOtherBranchBL(int_jobno, int_bid, trantype);
                        //    if (obj_dt.Rows.Count > 0)
                        //    {

                        //        if (trantype == "FI")
                        //        {
                        //            obj_dttemp = obj_da_Close.CheckShipmentTransferOrNot(int_jobno, int_bid, trantype);
                        //            if (obj_dttemp.Rows.Count > 0)
                        //            {
                        //                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('ICD branch has not transfered the shipments.you cant close this Job');", true);
                        //                return;
                        //            }
                        //        }
                        //        obj_dttemp = obj_da_Close.GetCustofPLGroup(int_bid);
                        //        if (obj_dttemp.Rows.Count > 0)
                        //        {
                        //            POL_Custid = Convert.ToInt32(obj_dttemp.Rows[0]["customerid"].ToString());
                        //            POL_ShortName = obj_dttemp.Rows[0]["shortname"].ToString();
                        //            POL_AccMail = obj_dttemp.Rows[0]["accemail"].ToString();
                        //        }
                        //        DataAccess.ForwardingExports.BLPrinting obj_da_FEBL = new DataAccess.ForwardingExports.BLPrinting();

                        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //        {
                        //            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //            obj_dttemp = obj_da_FEBL.GetBLPrintOtherDNDt(str_Bl, trantype, int_bid);
                        //            for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                        //            {
                        //                BLAmount =Convert.ToDouble(obj_dttemp.Rows[j]["amount"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dttemp.Rows[i]["branch"].ToString());
                        //                ICD_Jobno = Convert.ToInt32(obj_dttemp.Rows[i]["icdjob"].ToString());

                        //                Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }
                        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //        {
                        //            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //            obj_dttemp = obj_da_FEBL.GetBLPrintOtherCNDt(str_Bl, trantype, int_bid);
                        //            for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                        //            {
                        //                BLAmount =Convert.ToDouble(obj_dttemp.Rows[j]["amount"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dttemp.Rows[i]["branch"].ToString());
                        //                ICD_Jobno = Convert.ToInt32(obj_dttemp.Rows[i]["icdjob"].ToString());

                        //                Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'V');
                        //        if (obj_dttemp.Rows.Count > 0)
                        //        {
                        //            MBL_Amount =Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                        //            POL_CBM =Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                        //            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                        //            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //            {
                        //                str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                        //                BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                        //                BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                        //                Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'E');
                        //        if (obj_dttemp.Rows.Count > 0)
                        //        {
                        //            MBL_Amount =Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                        //            POL_CBM =Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                        //            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                        //            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //            {
                        //                str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                        //                BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                        //                BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                        //                Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'I');
                        //        if (obj_dttemp.Rows.Count > 0)
                        //        {
                        //            MBL_Amount =Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                        //            POL_CBM =Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                        //            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                        //            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //            {
                        //                str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                        //                BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                        //                BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                        //                Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'D');
                        //        if (obj_dttemp.Rows.Count > 0)
                        //        {
                        //            MBL_Amount =Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                        //            POL_CBM =Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                        //            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                        //            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //            {
                        //                str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                        //                BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                        //                BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                        //                Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'P');
                        //        if (obj_dttemp.Rows.Count > 0)
                        //        {
                        //            MBL_Amount =Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                        //            POL_CBM =Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                        //            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                        //            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //            {
                        //                str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                        //                BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dttemp.Rows[i]["branch"].ToString());
                        //                BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                        //                Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'C');
                        //        if (obj_dttemp.Rows.Count > 0)
                        //        {
                        //            MBL_Amount =Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                        //            POL_CBM =Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                        //            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                        //            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //            {
                        //                str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                        //                BL_CBM =Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                        //                BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                        //                Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //        {
                        //            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //            obj_dttemp = obj_da_FEBL.GetBLPrintInvDt(str_Bl, trantype, int_bid);
                        //            for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                        //            {
                        //                BLAmount =Convert.ToDouble(obj_dttemp.Rows[j]["amount"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());

                        //                Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //        {
                        //            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //            obj_dttemp = obj_da_FEBL.GetBLPrintPADt(str_Bl, trantype, int_bid);
                        //            for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                        //            {
                        //                BLAmount =Convert.ToDouble(obj_dttemp.Rows[j]["amount"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());

                        //                Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }
                        //        DataAccess.CostingTemp obj_da_Temp = new DataAccess.CostingTemp();
                        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //        {
                        //            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //            BLAmount = obj_da_Temp.GetCADA(str_Bl, trantype, int_bid, "Debit");
                        //            if (BLAmount > 0)
                        //            {
                        //                BL_CBM =Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());

                        //                Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //        {
                        //            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                        //            BLAmount = obj_da_Temp.GetCADA(str_Bl, trantype, int_bid, "Credit");
                        //            if (BLAmount > 0)
                        //            {
                        //                BL_CBM =Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                        //                ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                        //                ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());

                        //                Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                        //                Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                        //            }
                        //        }

                        //    }
                        //}

                        //RajaGuru

                        string str_Bl = "", POL_ShortName = "", POL_AccMail = "";
                        int ICD_bid = 0, POL_Custid = 0, ICD_Jobno = 0;
                        double BLAmount = 0, MBL_Amount = 0, POL_CBM = 0, BL_CBM = 0;
                        //Raj sir

                        /*    if (trantype == "FE" || trantype == "FI")
                            {

                                obj_dt = obj_da_Close.SelOtherBranchBL(int_jobno, int_bid, trantype);
                                if (obj_dt.Rows.Count > 0)
                                {

                                    if (trantype == "FI")
                                    {
                                        obj_dttemp = obj_da_Close.CheckShipmentTransferOrNot(int_jobno, int_bid, trantype);
                                        if (obj_dttemp.Rows.Count > 0)
                                        {
                                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('ICD branch has not transfered the shipments.you cant close this Job');", true);
                                            return;
                                        }
                                    }
                                    obj_dttemp = obj_da_Close.GetCustofPLGroup(int_bid);
                                    if (obj_dttemp.Rows.Count > 0)
                                    {
                                        POL_Custid = Convert.ToInt32(obj_dttemp.Rows[0]["customerid"].ToString());
                                        POL_ShortName = obj_dttemp.Rows[0]["shortname"].ToString();
                                        POL_AccMail = obj_dttemp.Rows[0]["accemail"].ToString();
                                    }
                                    DataAccess.ForwardingExports.BLPrinting obj_da_FEBL = new DataAccess.ForwardingExports.BLPrinting();

                                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                    {
                                        str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                        obj_dttemp = obj_da_FEBL.GetBLPrintOtherDNDt(str_Bl, trantype, int_bid);
                                        for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                                        {
                                            BLAmount = Convert.ToDouble(obj_dttemp.Rows[j]["amount"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[i]["branch"].ToString());
                                            ICD_Jobno = Convert.ToInt32(obj_dttemp.Rows[i]["icdjob"].ToString());

                                            Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }
                                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                    {
                                        str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                        obj_dttemp = obj_da_FEBL.GetBLPrintOtherCNDt(str_Bl, trantype, int_bid);
                                        for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                                        {
                                            BLAmount = Convert.ToDouble(obj_dttemp.Rows[j]["amount"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[i]["branch"].ToString());
                                            ICD_Jobno = Convert.ToInt32(obj_dttemp.Rows[i]["icdjob"].ToString());

                                            Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'V');
                                    if (obj_dttemp.Rows.Count > 0)
                                    {
                                        MBL_Amount = Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                                        POL_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                                        ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                        {
                                            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                                            BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                                            BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                                            Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'E');
                                    if (obj_dttemp.Rows.Count > 0)
                                    {
                                        MBL_Amount = Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                                        POL_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                                        ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                        {
                                            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                                            BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                                            BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                                            Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'I');
                                    if (obj_dttemp.Rows.Count > 0)
                                    {
                                        MBL_Amount = Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                                        POL_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                                        ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                        {
                                            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                                            BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                                            BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                                            Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'D');
                                    if (obj_dttemp.Rows.Count > 0)
                                    {
                                        MBL_Amount = Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                                        POL_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                                        ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                        {
                                            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                                            BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                                            BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                                            Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'P');
                                    if (obj_dttemp.Rows.Count > 0)
                                    {
                                        MBL_Amount = Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                                        POL_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                                        ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                        {
                                            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                                            BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dttemp.Rows[i]["branch"].ToString());
                                            BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                                            Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    obj_dttemp = obj_dA_Invoice.SelMBLInvPADtls(int_jobno, int_bid, trantype, 'C');
                                    if (obj_dttemp.Rows.Count > 0)
                                    {
                                        MBL_Amount = Convert.ToDouble(obj_dttemp.Rows[0]["amount"].ToString());
                                        POL_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["polcbm"].ToString());
                                        ICD_bid = Convert.ToInt32(obj_dttemp.Rows[0]["icdbranch"].ToString());
                                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                        {
                                            str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());
                                            BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                                            BLAmount = (MBL_Amount / POL_CBM) * BL_CBM;

                                            Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                    {
                                        str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                        obj_dttemp = obj_da_FEBL.GetBLPrintInvDt4JobClose(str_Bl, trantype, int_bid);
                                        for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                                        {
                                            BLAmount = Convert.ToDouble(obj_dttemp.Rows[j]["amount"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());

                                            Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                    {
                                        str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                        obj_dttemp = obj_da_FEBL.GetBLPrintPADt(str_Bl, trantype, int_bid);
                                        for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                                        {
                                            BLAmount = Convert.ToDouble(obj_dttemp.Rows[j]["amount"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());

                                            Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }
                                    DataAccess.CostingTemp obj_da_Temp = new DataAccess.CostingTemp();
                                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                    {
                                        str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                        BLAmount = obj_da_Temp.GetCADA(str_Bl, trantype, int_bid, "Debit");
                                        if (BLAmount > 0)
                                        {
                                            BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());

                                            Fn_CN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_DN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                    {
                                        str_Bl = obj_dt.Rows[i]["blno"].ToString();
                                        BLAmount = obj_da_Temp.GetCADA(str_Bl, trantype, int_bid, "Credit");
                                        if (BLAmount > 0)
                                        {
                                            BL_CBM = Convert.ToDouble(obj_dt.Rows[i]["cbm"].ToString());
                                            ICD_bid = Convert.ToInt32(obj_dt.Rows[i]["branch"].ToString());
                                            ICD_Jobno = Convert.ToInt32(obj_dt.Rows[i]["icdjob"].ToString());

                                            Fn_DN_POL2ICD(str_Bl, BLAmount, ICD_bid);
                                            Fn_CN_ICD2POL(str_Bl, BLAmount, ICD_bid, ICD_Jobno, POL_Custid);
                                        }
                                    }

                                }
                            }
                            */
                        //DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
                        string date = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                        //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();

                        objRpt.InsOEeventdetailsTask(Convert.ToInt32(txt_job.Text), "", "", "BL /AWB Release",
                       Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), 0, "", 16);

                        //To Hide 
                        obj_da_Close.UpdateCloseJob(trantype + "JobInfo", trantype, int_jobno, int_bid, Close_date, int_Empid);

                        //ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Your request for closing the job # 9999 will be processed shortly and you will receive an email once the job closing process is completed');", true);

                        //  Your request for closing the job # "9999" will be processed shortly and you will receive an email once the job closing process is completed
                        switch (trantype)
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 101, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 102, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 103, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 104, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "CH":
                                obj_da_Log.InsLogDetail(int_Empid, 92, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "BT":
                                obj_da_Log.InsLogDetail(int_Empid,359, 2, int_bid, int_jobno + "/Closed");
                                break;
                        }
                        if (txt_remark.Text.Trim().Length > 0)
                        {
                            obj_da_Close.UpdJobCloseRemarks4rptJob(int_bid, int_jobno.ToString(), trantype, txt_remark.Text);
                        }
                        //Raj sir

                        /*  if (trantype == "FE" || trantype == "FI")
                          {
                              if (obj_dt.Rows.Count > 0)
                              {
                                  ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Debit Note - Credit Note - Generated in " + POL_ShortName + "');", true);
                                  ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Debit Note - Credit Note -  Generated in " + ICD_Shortname + "');", true);

                              }
                          }

                          Fn_CostTemp(int_jobno);
                          ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Job Closed');", true);

                          obj_dttemp = da_obj_Costing.BLCosting(int_jobno, trantype, int_bid);
                          if (obj_dttemp.Rows.Count > 0)
                          {
                              P1.Visible = true;
                              Grd_job.Visible = true;
                              lbl.Text = "Job Closed";
                              btn_update.Enabled = false;
                              btn_update.ForeColor = System.Drawing.Color.Gray;
                              var sum_Income = obj_dttemp.Compute("sum(income)", "");
                              var sum_Expense = obj_dttemp.Compute("sum(expense)", "");
                              var sum_Retention = obj_dttemp.Compute("sum(retention)", "");

                              DataRow dr = obj_dttemp.NewRow();
                              obj_dttemp.Rows.Add(dr);
                              dr[2] = "Total";
                              dr[3] = sum_Income;
                              dr[4] = sum_Expense;
                              dr[5] = sum_Retention;

                              Grd_job.DataSource = obj_dttemp;
                              Grd_job.DataBind();
                              grdclsjob.Visible = false;
                              P8.Visible = false;
                              btn_confirm.Visible = false;
                          }
                      */
                        //To hide
                    }

                    else if (trantype == "CH")
                    {
                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "I");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are  Invoice( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }
                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "P");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are PA( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }

                        obj_da_Close.UpdateCloseJob(trantype + "JobInfo", trantype, int_jobno, int_bid, Close_date, int_Empid);

                        //Raj sir

                        /*    Fn_CostTempCH(int_jobno);*/

                        switch (trantype)
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 101, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 102, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 103, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 104, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "CH":
                                obj_da_Log.InsLogDetail(int_Empid, 92, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "BT":
                                obj_da_Log.InsLogDetail(int_Empid, 359, 2, int_bid, int_jobno + "/Closed");
                                break;
                        }
                        if (txt_remark.Text.Trim().Length > 0)
                        {
                            obj_da_Close.UpdJobCloseRemarks4rptJob(int_bid, int_jobno.ToString(), trantype, txt_remark.Text);
                        }

                        // ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Job Closed');", true);

                        //Raj sir
                        /* obj_dttemp = da_obj_Costing.BLCosting(int_jobno, trantype, int_bid);
                         if (obj_dttemp.Rows.Count > 0)
                         {
                             P1.Visible = true;
                             Grd_job.Visible = true;
                             lbl.Text = "Job Closed";
                             btn_update.Enabled = false;
                             btn_update.ForeColor = System.Drawing.Color.Gray;
                             var sum_Income = obj_dttemp.Compute("sum(income)", "");
                             var sum_Expense = obj_dttemp.Compute("sum(expense)", "");
                             var sum_Retention = obj_dttemp.Compute("sum(retention)", "");

                             DataRow dr = obj_dttemp.NewRow();
                             obj_dttemp.Rows.Add(dr);
                             dr[2] = "Total";
                             dr[3] = sum_Income;
                             dr[4] = sum_Expense;
                             dr[5] = sum_Retention;

                             Grd_job.DataSource = obj_dttemp;
                             Grd_job.DataBind();
                             grdclsjob.Visible = false;
                             P8.Visible = false;
                             btn_confirm.Visible = false;
                         }
                         */
                        //To hide

                    }
                    else if (trantype == "BT")
                    {
                        obj_da_Close.UpdateCloseJob(trantype + "JobInfo", trantype, int_jobno, int_bid, Close_date, int_Empid);

                        //Raj sir
                        /* Fn_CostTempBT(int_jobno);*/

                        switch (trantype)
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 101, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 102, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 103, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 104, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "CH":
                                obj_da_Log.InsLogDetail(int_Empid, 92, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "BT":
                                obj_da_Log.InsLogDetail(int_Empid, 359, 2, int_bid, int_jobno + "/Closed");
                                break;
                        }

                        // ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Jobs Closed');", true);

                        //Raj sir
                        /*    obj_dttemp = da_obj_Costing.BLCosting(int_jobno, trantype, int_bid);
                             if (obj_dttemp.Rows.Count > 0)
                             {
                                 P1.Visible = true;
                                 Grd_job.Visible = true;
                                 lbl.Text = "Job Closed";
                                 btn_update.Enabled = false;
                                 btn_update.ForeColor = System.Drawing.Color.Gray;
                                 var sum_Income = obj_dttemp.Compute("sum(income)", "");
                                 var sum_Expense = obj_dttemp.Compute("sum(expense)", "");
                                 var sum_Retention = obj_dttemp.Compute("sum(retention)", "");

                                 DataRow dr = obj_dttemp.NewRow();
                                 obj_dttemp.Rows.Add(dr);
                                 dr[2] = "Total";
                                 dr[3] = sum_Income;
                                 dr[4] = sum_Expense;
                                 dr[5] = sum_Retention;

                                 Grd_job.DataSource = obj_dttemp;
                                 Grd_job.DataBind();
                                 grdclsjob.Visible = false;
                                 P8.Visible = false;
                                 btn_confirm.Visible = false;
                             }
                            */
                        //To hide
                    }
                    lbl.Text = "Job Closed";
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Your request for closing the job # " + txt_job.Text + " will be processed shortly and you will receive an email once the job closing process is completed');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_CN_POL2ICD(string BLno, double Amount, int ICD_id)
        {
            //DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
            //DataAccess.Accounts.Invoice obj_dA_Invoice = new DataAccess.Accounts.Invoice();
            //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
            DataTable obj_dttemp = new DataTable();
            int int_DNno = 0;
            int_DNno = obj_da_OSDN.GetOSDCNno("CN", int_bid);
            POl_MSG = POl_MSG + int_DNno.ToString() + " ";
            DataTable dt = new DataTable();

            DataRow dr = dt.NewRow();
            if (Session["CN"] == null)
            {
                dt.Columns.Add("Vou");
                dt.Columns.Add("Type");
                dt.Columns.Add("BL");
                dt.Columns.Add("Amount");
                dt.Rows.Add(dr);
                dr[0] = int_DNno.ToString();
                dr[1] = "CN";
                dr[2] = BLno;
                dr[3] = string.Format("{0:0.00}", Amount);

                Session["CN"] = dt;
            }
            else
            {
                dt = (DataTable)Session["CN"];
                dt.Rows.Add(dr);
                dr[0] = int_DNno.ToString();
                dr[1] = "CN";
                dr[2] = BLno;
                dr[3] = string.Format("{0:0.00}", Amount);
            }
            if (dt.Rows.Count > 0)
            {
                Grd_POL.DataSource = dt;
                Grd_POL.DataBind();
            }
            int ICD_Cust = 0;
            ICD_Shortname = "";
            string ICD_Mail = "";
            obj_dttemp = obj_da_Close.GetCustofPLGroup(ICD_id);
            if (obj_dttemp.Rows.Count > 0)
            {
                ICD_Cust = Convert.ToInt32(obj_dttemp.Rows[0]["customerid"].ToString());

                ICD_Shortname = obj_dttemp.Rows[0]["shortname"].ToString();
                ICD_Mail = obj_dttemp.Rows[0]["accemail"].ToString();
            }
            //DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
            obj_dA_Invoice.InsertInvoiceHead(int_DNno, Close_date, trantype, int_jobno, ICD_Cust, BLno, "", int_bid, "Internal", Convert.ToInt32(Session["LoginEmpId"].ToString()), "Credit Note", Convert.ToInt32(Session["Vouyear"].ToString()), 'N', "");
            obj_dA_Invoice.InsertInvoiceDetails(int_DNno, obj_da_Charge.GetChargeid("COST SHARE TO ICD"), "INR", Amount, 1, "CBM", Amount, int_bid, "Credit Note", ICD_Cust, Convert.ToInt32(Session["Vouyear"].ToString()), "Internal", trantype);
            obj_da_Approval.UpdApproval(int_DNno, BLno, Convert.ToInt32(Session["LoginEmpId"].ToString()), trantype, "Credit Note", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);

            try
            {
                obj_da_Close.InsAutoDCNFrmJobClose(int_DNno, "E", int_bid, int_jobno, trantype, Convert.ToInt32(Session["Vouyear"].ToString()));
            }
            catch (Exception Ex)
            {
                //  Utility.SendMail(Session["usermailid"].ToString(), "", "RaiseCNinPOL2ICD VOU # " + int_DNno + "\\E\\" + int_bid + "\\" + txt_job.Text + "\\" + trantype + "\\" + Session["Vouyear"].ToString(), Ex.ToString(), "", Session["usermailpwd"].ToString());
            }

            try
            {
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                int int_Ledgerid = 0;
                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(ICD_Cust, "C", Session["FADbname"].ToString());
                if (int_Ledgerid == 0)
                {
                    int_Ledgerid = Fn_GetCustomerid(ICD_Cust, "CN");
                }
                obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_DNno, Close_date, 'E', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Amount, "", 0, ICD_Cust);
            }
            catch (Exception Ex)
            {
                //  Utility.SendMail(Session["usermailid"].ToString(), "", "RFA RECEIPT PMT - ERROR In JobClose - CN #" + int_DNno + "\\VYear" + Session["Vouyear"].ToString() + "\\BID-" + int_bid, Ex.ToString(), "", Session["usermailpwd"].ToString());
            }
        }
        private int Fn_GetCustomerid(int custid, string type)
        {

            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            int int_Sid = 0, int_Gid = 0;
            if (type == "CN")
            {
                if (obj_da_Customer.GetCustomerType(custid) == "P")
                {
                    int_Sid = 44;
                    int_Gid = 12;
                }
                else
                {
                    int_Sid = 67;
                    int_Gid = 12;
                }
            }
            else if (type == "DN")
            {
                if (obj_da_Customer.GetCustomerType(custid) == "P")
                {
                    int_Sid = 65;
                    int_Gid = 13;
                }
                else
                {
                    int_Sid = 40;
                    int_Gid = 13;
                }
            }
            int int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(custid), int_Sid, int_Gid, 'G', custid, 'C', Session["FADbname"].ToString());
            return int_Ledgerid;
        }
        private void Fn_DN_POL2ICD(string BLno, double Amount, int ICD_id)
        {
            //DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
            //DataAccess.Accounts.Invoice obj_dA_Invoice = new DataAccess.Accounts.Invoice();
            //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
            DataTable obj_dttemp = new DataTable();
            int int_DNno = 0;
            int_DNno = obj_da_OSDN.GetOSDCNno("DN", int_bid);
            POl_MSG = POl_MSG + int_DNno.ToString() + " ";
            DataTable dt = new DataTable();

            DataRow dr = dt.NewRow();
            if (Session["DN"] == null)
            {
                dt.Columns.Add("Vou");
                dt.Columns.Add("Type");
                dt.Columns.Add("BL");
                dt.Columns.Add("Amount");
                dt.Rows.Add(dr);
                dr[0] = int_DNno.ToString();
                dr[1] = "DN";
                dr[2] = BLno;
                dr[3] = string.Format("{0:0.00}", Amount);

                Session["DN"] = dt;
            }
            else
            {
                dt = (DataTable)Session["DN"];
                dt.Rows.Add(dr);
                dr[0] = int_DNno.ToString();
                dr[1] = "DN";
                dr[2] = BLno;
                dr[3] = string.Format("{0:0.00}", Amount);
            }
            if (dt.Rows.Count > 0)
            {
                Grd_POL.DataSource = dt;
                Grd_POL.DataBind();
            }
            int ICD_Cust = 0;
            ICD_Shortname = "";
            string ICD_Mail = "";
            obj_dttemp = obj_da_Close.GetCustofPLGroup(ICD_id);
            if (obj_dttemp.Rows.Count > 0)
            {
                ICD_Cust = Convert.ToInt32(obj_dttemp.Rows[0]["customerid"].ToString());
                ICD_Shortname = obj_dttemp.Rows[0]["shortname"].ToString();
                ICD_Mail = obj_dttemp.Rows[0]["accemail"].ToString();
            }
            //DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
            obj_dA_Invoice.InsertInvoiceHead(int_DNno, Close_date, trantype, int_jobno, ICD_Cust, BLno, "", int_bid, "Internal", Convert.ToInt32(Session["LoginEmpId"].ToString()), "Debit Note", Convert.ToInt32(Session["Vouyear"].ToString()), 'N', "");
            obj_dA_Invoice.InsertInvoiceDetails(int_DNno, obj_da_Charge.GetChargeid("COST SHARE TO ICD"), "INR", Amount, 1, "CBM", Amount, int_bid, "Debit Note", ICD_Cust, Convert.ToInt32(Session["Vouyear"].ToString()), "Internal", trantype);
            obj_da_Approval.UpdApproval(int_DNno, BLno, Convert.ToInt32(Session["LoginEmpId"].ToString()), trantype, "Debit Note", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);

            try
            {
                obj_da_Close.InsAutoDCNFrmJobClose(int_DNno, "V", int_bid, int_jobno, trantype, Convert.ToInt32(Session["Vouyear"].ToString()));
            }
            catch (Exception Ex)
            {
                // Utility.SendMail(Session["usermailid"].ToString(), "", "RaiseDNinPOL2ICD VOU # " + int_DNno + "\\V\\" + int_bid + "\\" + txt_job.Text + "\\" + trantype + "\\" + Session["Vouyear"].ToString(), Ex.ToString(), "", Session["usermailpwd"].ToString());
            }

            try
            {
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                int int_Ledgerid = 0;
                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(ICD_Cust, "C", Session["FADbname"].ToString());
                if (int_Ledgerid == 0)
                {
                    int_Ledgerid = Fn_GetCustomerid(ICD_Cust, "DN");
                }
                obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_DNno, Close_date, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Amount, "", 0, ICD_Cust);
            }
            catch (Exception Ex)
            {
                // Utility.SendMail(Session["usermailid"].ToString(), "", "RFA RECEIPT PMT - ERROR In JobClose - DN #" + int_DNno + "\\VYear" + Session["Vouyear"].ToString() + "\\BID-" + int_bid, Ex.ToString(), "", Session["usermailpwd"].ToString());
            }
        }
        private void Fn_DN_ICD2POL(string BLno, double Amount, int ICD_branch, int ICD_Job, int POLCust)
        {
            //DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
            //DataAccess.Accounts.Invoice obj_dA_Invoice = new DataAccess.Accounts.Invoice();
            //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
            DataTable obj_dttemp = new DataTable();
            int int_DNno = 0;
            int_DNno = obj_da_OSDN.GetOSDCNno("DN", ICD_branch);
            POl_MSG = POl_MSG + int_DNno.ToString() + " ";
            DataTable dt = new DataTable();

            DataRow dr = dt.NewRow();
            if (Session["DNPOL"] == null)
            {
                dt.Columns.Add("Vou");
                dt.Columns.Add("Type");
                dt.Columns.Add("BL");
                dt.Columns.Add("Amount");
                dt.Rows.Add(dr);
                dr[0] = int_DNno.ToString();
                dr[1] = "DN";
                dr[2] = BLno;
                dr[3] = string.Format("{0:0.00}", Amount);

                Session["DNPOL"] = dt;
            }
            else
            {
                dt = (DataTable)Session["DNPOL"];
                dt.Rows.Add(dr);
                dr[0] = int_DNno.ToString();
                dr[1] = "DN";
                dr[2] = BLno;
                dr[3] = string.Format("{0:0.00}", Amount);
            }
            if (dt.Rows.Count > 0)
            {
                Grd_ICD.DataSource = dt;
                Grd_ICD.DataBind();
            }

            //DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
            obj_dA_Invoice.InsertInvoiceHead(int_DNno, Close_date, trantype, ICD_Job, POLCust, BLno, "", ICD_branch, "Internal", Convert.ToInt32(Session["LoginEmpId"].ToString()), "Debit Note", Convert.ToInt32(Session["Vouyear"].ToString()), 'N', "");
            obj_dA_Invoice.InsertInvoiceDetails(int_DNno, obj_da_Charge.GetChargeid("COST SHARE FROM HUB"), "INR", Amount, 1, "CBM", Amount, ICD_branch, "Debit Note", POLCust, Convert.ToInt32(Session["Vouyear"].ToString()), "I", trantype);
            obj_da_Approval.UpdApproval(int_DNno, BLno, Convert.ToInt32(Session["LoginEmpId"].ToString()), trantype, "Debit Note", Convert.ToInt32(Session["Vouyear"].ToString()), ICD_branch);

            try
            {
                obj_da_Close.InsAutoDCNFrmJobClose(int_DNno, "V", ICD_branch, ICD_Job, trantype, Convert.ToInt32(Session["Vouyear"].ToString()));
            }
            catch (Exception Ex)
            {
                //   Utility.SendMail(Session["usermailid"].ToString(), "", "RaiseDNinICD2PoL VOU # " + int_DNno + "\\V\\" + int_bid + "\\" + txt_job.Text + "\\" + trantype + "\\" + Session["Vouyear"].ToString(), Ex.ToString(), "", Session["usermailpwd"].ToString());
            }

            try
            {
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                int int_Ledgerid = 0;
                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(POLCust, "C", Session["FADbname"].ToString());
                if (int_Ledgerid == 0)
                {
                    int_Ledgerid = Fn_GetCustomerid(POLCust, "DN");
                }
                obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_DNno, Close_date, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), ICD_branch, Amount, "", 0, POLCust);
            }
            catch (Exception Ex)
            {
                // Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In JobClose - DN #" + int_DNno + "\\VYear" + Session["Vouyear"].ToString() + "\\BID-" + int_bid, Ex.ToString(), "", Session["usermailpwd"].ToString());
            }
        }
        private void Fn_CN_ICD2POL(string BLno, double Amount, int ICD_branch, int ICD_Job, int POLCust)
        {
            //DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
            //DataAccess.Accounts.Invoice obj_dA_Invoice = new DataAccess.Accounts.Invoice();
            //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
            DataTable obj_dttemp = new DataTable();
            int int_DNno = 0;
            int_DNno = obj_da_OSDN.GetOSDCNno("CN", ICD_branch);
            POl_MSG = POl_MSG + int_DNno.ToString() + " ";
            DataTable dt = new DataTable();

            DataRow dr = dt.NewRow();
            if (Session["CNPOL"] == null)
            {
                dt.Columns.Add("Vou");
                dt.Columns.Add("Type");
                dt.Columns.Add("BL");
                dt.Columns.Add("Amount");
                dt.Rows.Add(dr);
                dr[0] = int_DNno.ToString();
                dr[1] = "CN";
                dr[2] = BLno;
                dr[3] = string.Format("{0:0.00}", Amount);

                Session["CNPOL"] = dt;
            }
            else
            {
                dt = (DataTable)Session["CNPOL"];
                dt.Rows.Add(dr);
                dr[0] = int_DNno.ToString();
                dr[1] = "CN";
                dr[2] = BLno;
                dr[3] = string.Format("{0:0.00}", Amount);
            }
            if (dt.Rows.Count > 0)
            {
                Grd_ICD.DataSource = dt;
                Grd_ICD.DataBind();
            }

            //DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
            obj_dA_Invoice.InsertInvoiceHead(int_DNno, Close_date, trantype, ICD_Job, POLCust, BLno, "", ICD_branch, "Internal", Convert.ToInt32(Session["LoginEmpId"].ToString()), "Credit Note", Convert.ToInt32(Session["Vouyear"].ToString()), 'N', "");
            obj_dA_Invoice.InsertInvoiceDetails(int_DNno, obj_da_Charge.GetChargeid("COST SHARE FROM HUB"), "INR", Amount, 1, "CBM", Amount, ICD_branch, "Credit Note", POLCust, Convert.ToInt32(Session["Vouyear"].ToString()), "I", trantype);
            obj_da_Approval.UpdApproval(int_DNno, BLno, Convert.ToInt32(Session["LoginEmpId"].ToString()), trantype, "Credit Note", Convert.ToInt32(Session["Vouyear"].ToString()), ICD_branch);

            try
            {
                obj_da_Close.InsAutoDCNFrmJobClose(int_DNno, "E", ICD_branch, ICD_Job, trantype, Convert.ToInt32(Session["Vouyear"].ToString()));
            }
            catch (Exception Ex)
            {
                //  Utility.SendMail(Session["usermailid"].ToString(), "", "RaiseCNinICD2PoL VOU # " + int_DNno + "\\V\\" + int_bid + "\\" + txt_job.Text + "\\" + trantype + "\\" + Session["Vouyear"].ToString(), Ex.ToString(), "", Session["usermailpwd"].ToString());
            }

            try
            {
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                int int_Ledgerid = 0;
                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(POLCust, "C", Session["FADbname"].ToString());
                if (int_Ledgerid == 0)
                {
                    int_Ledgerid = Fn_GetCustomerid(POLCust, "CN");
                }
                obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_DNno, Close_date, 'E', Convert.ToInt32(Session["Vouyear"].ToString()), ICD_branch, Amount, "", 0, POLCust);
            }
            catch (Exception Ex)
            {
                // Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In JobClose - DN #" + int_DNno + "\\VYear" + Session["Vouyear"].ToString() + "\\BID-" + int_bid, Ex.ToString(), "", Session["usermailpwd"].ToString());
            }
        }
        private string Fn_ICDMail()
        {
            string Str_temp = "", Str_CN = "", Str_DN = "";
            Str_temp = Str_temp + "<font size=2 face=sans-serif>Dear Accountant,<br><br>";
            Str_temp = Str_temp + "<font size=2 face=sans-serif>Below CN(s) has Generated.<br><br>";
            Str_temp = Str_temp + "<table cellspacing=0 cellpadding=2 border=1>";
            Str_temp = Str_temp + "<tr align=center><td><font size=2 face=sans-serif>CN #</td>";
            Str_temp = Str_temp + "<td><font size=2 face=sans-serif>Date</td>";
            Str_temp = Str_temp + "<td><font size=2 face=sans-serif>BL #</td>";
            Str_temp = Str_temp + "<td><font size=2 face=sans-serif>Amount</td></tr>";

            if (Grd_ICD.Rows.Count > 0)
            {
                for (int i = 0; i <= Grd_ICD.Rows.Count - 1; i++)
                {
                    if (Grd_ICD.Rows[i].Cells[1].Text.ToString() == "CN")
                    {
                        Str_CN = Str_CN + "<tr>";
                        Str_CN = Str_CN + "<td><font size=2 face=sans-serif>" + Grd_ICD.Rows[i].Cells[0].Text + "</td>";
                        Str_CN = Str_CN + "<td><font size=2 face=sans-serif>" + txt_date.Text + "</td>";
                        Str_CN = Str_CN + "<td><font size=2 face=sans-serif>" + Grd_ICD.Rows[i].Cells[2].Text + "</td>";
                        Str_CN = Str_CN + "<td align=right><font size=2 face=sans-serif>" + Grd_ICD.Rows[i].Cells[3].Text + "</td>";
                        Str_CN = Str_CN + "</tr>";
                    }
                    else if (Grd_ICD.Rows[i].Cells[1].Text.ToString() == "DN")
                    {
                        Str_DN = Str_DN + "<tr>";
                        Str_DN = Str_DN + "<td><font size=2 face=sans-serif>" + Grd_ICD.Rows[i].Cells[0].Text + "</td>";
                        Str_DN = Str_DN + "<td><font size=2 face=sans-serif>" + txt_date.Text + "</td>";
                        Str_DN = Str_DN + "<td><font size=2 face=sans-serif>" + Grd_ICD.Rows[i].Cells[2].Text + "</td>";
                        Str_DN = Str_DN + "<td align=right><font size=2 face=sans-serif>" + Grd_ICD.Rows[i].Cells[3].Text + "</td>";
                        Str_DN = Str_DN + "</tr>";
                    }
                }
            }
            Str_temp = Str_temp + Str_CN;
            Str_temp = Str_temp + "</table><br>";
            if (Str_DN.Trim().Length > 0)
            {
                Str_temp = Str_temp + "<font size=2 face=sans-serif>Below DN(s) has Generated.<br><br>";
                Str_temp = Str_temp + "<table cellspacing=0 cellpadding=2 border=1>";
                Str_temp = Str_temp + "<tr align=center><td><font size=2 face=sans-serif>DN #</td>";
                Str_temp = Str_temp + "<td><font size=2 face=sans-serif>Date</td>";
                Str_temp = Str_temp + "<td><font size=2 face=sans-serif>BL #</td>";
                Str_temp = Str_temp + "<td><font size=2 face=sans-serif>Amount</td></tr>";
                Str_temp = Str_temp + Str_DN;
                Str_temp = Str_temp + "</table><br>";
            }
            Str_temp = Str_temp + "<font size=2 face=sans-serif>Request You to Approve the Voucher and Transfer into Tally.<br><br>";
            Str_temp = Str_temp + "<font size=2 face=sans-serif>Thanks & Regards,<br>";
            Str_temp = Str_temp + "<font size=2 face=sans-serif><br>";

            return Str_temp;
        }
        private string Fn_POLMail()
        {
            string Str_temp = "";
            Str_temp = Str_temp + "<font size=2 face=sans-serif>Dear Accountant,<br><br>";
            Str_temp = Str_temp + "<font size=2 face=sans-serif>Below DN(s) has Generated.<br><br>";
            Str_temp = Str_temp + "<table cellspacing=0 cellpadding=2 border=1>";
            Str_temp = Str_temp + "<tr align=center><td><font size=2 face=sans-serif>DN #</td>";
            Str_temp = Str_temp + "<td><font size=2 face=sans-serif>Date</td>";
            Str_temp = Str_temp + "<td><font size=2 face=sans-serif>BL #</td>";
            Str_temp = Str_temp + "<td><font size=2 face=sans-serif>Amount</td></tr>";

            if (Grd_POL.Rows.Count > 0)
            {
                for (int i = 0; i <= Grd_POL.Rows.Count - 1; i++)
                {
                    if (Grd_POL.Rows[i].Cells[1].Text.ToString() == "DN")
                    {
                        Str_temp = Str_temp + "<tr>";
                        Str_temp = Str_temp + "<td><font size=2 face=sans-serif>" + Grd_POL.Rows[i].Cells[0].Text + "</td>";
                        Str_temp = Str_temp + "<td><font size=2 face=sans-serif>" + txt_date.Text + "</td>";
                        Str_temp = Str_temp + "<td><font size=2 face=sans-serif>" + Grd_POL.Rows[i].Cells[2].Text + "</td>";
                        Str_temp = Str_temp + "<td align=right><font size=2 face=sans-serif>" + Grd_POL.Rows[i].Cells[3].Text + "</td>";
                        Str_temp = Str_temp + "</tr>";
                    }
                }
            }
            Str_temp = Str_temp + "</table><br>";

            Str_temp = Str_temp + "<font size=2 face=sans-serif>Request You to Approve the Voucher and Transfer into Tally.<br><br>";
            Str_temp = Str_temp + "<font size=2 face=sans-serif>Thanks & Regards,<br>";
            Str_temp = Str_temp + "<font size=2 face=sans-serif><br>";

            return Str_temp;
        }
        private void Fn_CostTemp(int Jobno)
        {
            try
            {
                double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
                int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
                //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                obj_da_Cost.DelCostingDetailsRpt(Jobno, trantype, "V", int_bid, 0, "");
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                obj_dt = obj_da_Cost.GetClosedJobDts(Jobno, trantype, int_bid);
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    MBL_Expense = obj_da_Cost.GetcostPA(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid);
                    MBL_credit = obj_da_Cost.GetCreditDebit(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid, "Credit");
                    MBL_debit = obj_da_Cost.GetCreditDebit(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid, "Debit");
                    MBL_Amount = obj_da_Cost.GetcostInvBOS(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid);
                    Close_date = DateTime.Parse((obj_dt.Rows[i]["jobclosedate"].ToString()));
                    if (trantype == "FE" || trantype == "FI")
                    {
                        JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());

                        obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);

                        if (obj_dttemp.Rows.Count > 0)
                        {
                            if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
                            {
                                Total_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["cbmtotal"].ToString());
                                Total_Tues = Convert.ToDouble(obj_dttemp.Rows[0]["Tuestotal"].ToString());
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        JobType = 0;
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["airline"].ToString());

                        obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);

                        if (obj_dttemp.Rows.Count > 0)
                        {
                            if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
                            {
                                JobChargeWT = Convert.ToDouble(obj_dttemp.Rows[0][0].ToString());
                            }
                        }
                    }

                    obj_dttemp = obj_da_Cost.GetBLRow(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);
                    for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                    {
                        BL_Expense = obj_da_Cost.GetcostPA(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid);
                        BL_credit = obj_da_Cost.GetCreditDebit(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid, "Credit");
                        BL_debit = obj_da_Cost.GetCreditDebit(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid, "Debit");
                        BL_Amount = obj_da_Cost.GetcostInvBOS(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid);
                        if (trantype == "FE" || trantype == "FI")
                        {
                            BL_Tues = Convert.ToInt32(obj_dttemp.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dttemp.Rows[j]["cont40"].ToString()) * 2);
                            BL_CBM = Convert.ToDouble(obj_dttemp.Rows[j]["cbm"].ToString());
                            if (MBL_Amount != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / 1) * 1);
                                    }
                                    else
                                    {

                                        //BL_Amount = BL_Amount + ((MBL_Amount / Total_Tues) * BL_Tues);

                                        amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), Total_Tues, BL_Tues, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "M");

                                        BL_Amount = BL_Amount + amont;
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_Amount = BL_Amount + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_Amount = BL_Amount + 0;
                                    }
                                    else
                                    {
                                       // BL_Amount = BL_Amount + ((MBL_Amount / Total_CBM) * BL_CBM);
                                        amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), Total_CBM, BL_CBM, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "M");

                                        BL_Amount = BL_Amount + amont;
                                    }
                                }
                            }
                            if (MBL_debit != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / 1) * 1);
                                    }
                                    else
                                    {
                                        amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), Total_Tues, BL_Tues, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "D");

                                       // BL_debit = BL_debit + ((MBL_debit / Total_Tues) * BL_Tues);
                                        BL_debit = BL_debit + amont;
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_debit = BL_debit + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_debit = BL_debit + 0;
                                    }
                                    else
                                    {
                                       // BL_debit = BL_debit + ((MBL_debit / Total_CBM) * BL_CBM);
                                        amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), Total_CBM, BL_CBM, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "D");
                                        BL_debit = BL_debit + amont;
                                    }
                                }
                            }
                            if (MBL_credit != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / 1) * 1);
                                    }
                                    else
                                    {
                                     //   BL_credit = BL_credit + ((MBL_credit / Total_Tues) * BL_Tues);

                                        amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), Total_Tues, BL_Tues, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "C");
                                        BL_credit = BL_credit + amont;
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_credit = BL_credit + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_credit = BL_credit + 0;
                                    }
                                    else
                                    {
                                     //   BL_credit = BL_credit + ((MBL_credit / Total_CBM) * BL_CBM);
                                        amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), Total_CBM, BL_CBM, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "C");
                                        BL_credit = BL_credit + amont;
                                    }
                                }
                            }

                            if (MBL_Expense != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / 1) * 1);
                                    }
                                    else
                                    {
                                       // BL_Expense = BL_Expense + ((MBL_Expense / Total_Tues) * BL_Tues);

                                        amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), Total_Tues, BL_Tues, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "E");
                                        BL_Expense = BL_Expense + amont;
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_Expense = BL_Expense + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_Expense = BL_Expense + 0;
                                    }
                                    else
                                    {
                                      //  BL_Expense = BL_Expense + ((MBL_Expense / Total_CBM) * BL_CBM);

                                        amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), Total_CBM, BL_CBM, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "E");

                                        BL_Expense = BL_Expense + amont;
                                    }
                                }
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            BL_ChargeWT = Convert.ToDouble(obj_dttemp.Rows[j]["chargewt"].ToString());

                            if (MBL_Amount != 0)
                            {
                               // BL_Amount = BL_Amount + ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
                                amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), JobChargeWT, BL_ChargeWT, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "M");
                                BL_Amount = BL_Amount + amont;
                            }
                            if (MBL_debit != 0)
                            {
                               // BL_debit = BL_debit + ((MBL_debit / JobChargeWT) * BL_ChargeWT);

                                amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), JobChargeWT, BL_ChargeWT, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "D");
                                BL_debit = BL_debit + amont;
                            }
                            if (MBL_credit != 0)
                            {

                              //  BL_credit = BL_credit + ((MBL_credit / JobChargeWT) * BL_ChargeWT);

                                amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), JobChargeWT, BL_ChargeWT, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "E");
                                BL_credit = BL_credit + amont;
                            }
                            if (MBL_Expense != 0)
                            {
                              //  BL_Expense = BL_Expense + ((MBL_Expense / JobChargeWT) * BL_ChargeWT);

                                amont = obj_da_Cost.CostPATemplv(int_bid, trantype, obj_dt.Rows[i].ItemArray[1].ToString(), JobChargeWT, BL_ChargeWT, 0, Convert.ToInt32(obj_dttemp.Rows[j].ItemArray[0].ToString()), "C");
                                BL_Expense = BL_Expense + amont;
                            }
                        }

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dttemp.Rows[j][2].ToString().Length > 0 && obj_dttemp.Rows[j][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[j][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[j][3].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                        }
                        int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                        char Nomination;
                        string blno;
                        double volume = 0;
                        int_job = Convert.ToInt32(obj_dttemp.Rows[j][0].ToString());
                        blno = obj_dttemp.Rows[j][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[j][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[j][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[j][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[j][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[j][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[j][11].ToString());
                        int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        Nomination = char.Parse(obj_dttemp.Rows[j][4].ToString());
                        volume = Convert.ToDouble(obj_dttemp.Rows[j][5].ToString());
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;

                        //if (DBNull.Value.Equals(BL_Amount) == true)
                        //{ 

                        //}
                        obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, 0, char.Parse(" "));

                    }
                }
                Fn_DNCNBL(Jobno, "Closed", Close_date, 0, " ");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void Fn_DNCNBL(int jobno, string type, DateTime CDate, int vouno, string voutype)
        {
            try
            {
                double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
                int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
                DateTime dtdate = CDate;
                //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "O", int_bid, vouno, voutype);

                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                if (type == "Closed")
                {
                    obj_dt = obj_da_Cost.GetDNCN4MISFromJobNoLV(jobno, int_bid, trantype);

                }
                else if (type == "Approve")
                {
                    obj_dt = obj_da_Cost.GetDNCN4MISFromVounoLV(jobno, int_bid, trantype, vouno, voutype);
                }
                int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                char Nomination;
                string blno;
                double volume = 0;
                if (obj_dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        BL_Amount = 0;
                        BL_Expense = 0;
                        blno = obj_dt.Rows[i]["blno"].ToString();
                        int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                        if (trantype != "CH")
                        {
                            MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
                        }
                        else
                        {
                            MLO = 0;
                        }
                        if (type == "Closed")
                        {
                            dtdate = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                        }
                        else if (type == "Approve")
                        {
                            dtdate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["voudate"].ToString()));
                        }
                        obj_dttemp = obj_da_Cost.GetBLRowBL(blno, trantype, int_bid);
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            if (i < obj_dt.Rows.Count - 1)
                            {
                                if (obj_dt.Rows[i]["blno"].ToString() != obj_dt.Rows[i + 1]["blno"].ToString())
                                {
                                    if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                    {
                                        if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                        {
                                            BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                        }
                                    }
                                    else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                                    {
                                        if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                        {
                                            BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                        }
                                    }
                                }
                                else
                                {
                                    if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                    {
                                        if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                        {
                                            BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                        {
                                            BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                            int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
                            blno = obj_dttemp.Rows[0][1].ToString();
                            int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
                            int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
                            int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
                            int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
                            int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
                            int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());
                            if (trantype != "CH")
                            {
                                int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                            }
                            Nomination = char.Parse(obj_dttemp.Rows[0][4].ToString());
                            volume = Convert.ToDouble(obj_dttemp.Rows[0][5].ToString());

                            if (trantype == "FE" || trantype == "FI")
                            {
                                if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
                                {
                                    int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
                                    int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
                                    JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                                }
                            }
                            else if (trantype == "AE" || trantype == "AI" || trantype == "CH")
                            {
                                int_Cont20 = 0;
                                int_Cont40 = 0;
                                JobType = 0;
                            }
                            BL_Amount = BL_Amount + BL_debit;
                            BL_Expense = BL_Expense + BL_credit;

                            obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, vouno, char.Parse(voutype));
                        }
                        else
                        {
                            Fn_DNCNMBL(jobno, vouno, voutype, i, obj_dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void Fn_DNCNMBL(int jobno, int vouno, string voutype, int count, DataTable dt)
        {
            try
            {
                double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
                int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
                //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                //obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "O", int_bid, 0, "");
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                obj_dt = obj_da_Cost.GetClosedJobDts(jobno, trantype, int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    if (count < dt.Rows.Count - 1)
                    {
                        if (dt.Rows[count]["blno"].ToString() != dt.Rows[count + 1]["blno"].ToString())
                        {
                            if (dt.Rows[count]["voutype"].ToString() == "V")
                            {
                                if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                                {
                                    MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                                }
                            }
                            else if (dt.Rows[count]["voutype"].ToString() == "E")
                            {
                                if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                                {
                                    MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                                }
                            }
                        }
                        else
                        {
                            if (dt.Rows[count]["voutype"].ToString() == "V")
                            {
                                if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                                }
                            }
                            else if (dt.Rows[count]["voutype"].ToString() == "E")
                            {
                                if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                    if (trantype == "FE" || trantype == "FI")
                    {
                        JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                        obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                        if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
                        {
                            Total_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["cbmtotal"].ToString());
                            Total_Tues = Convert.ToDouble(obj_dttemp.Rows[0]["Tuestotal"].ToString());
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                       // JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                        JobType = 0;
                        obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                        if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
                        {
                            JobChargeWT = Convert.ToDouble(obj_dttemp.Rows[0][0].ToString());

                        }
                    }
                    for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                    {
                        BL_Amount = 0;
                        BL_Expense = 0;
                        if (trantype == "FE" || trantype == "FI")
                        {
                            BL_Tues = Convert.ToInt32(obj_dt.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dt.Rows[j]["cont40"].ToString()) * 2);
                            BL_CBM = Convert.ToDouble(obj_dt.Rows[j]["cbm"].ToString());
                            if (MBL_Amount != 0)
                            {
                                if (JobType == 3)
                                {
                                    BL_Amount = ((MBL_Amount / Total_Tues) * BL_Tues);
                                }
                                else
                                {
                                    BL_Amount = ((MBL_Amount / Total_CBM) * BL_CBM);
                                }
                            }

                            if (MBL_Expense != 0)
                            {
                                if (JobType == 3)
                                {
                                    BL_Expense = ((MBL_Expense / Total_Tues) * BL_Tues);
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_Expense = 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_Expense = 0;
                                    }
                                    else
                                    {
                                        BL_Expense = ((MBL_Expense / Total_CBM) * BL_CBM);
                                    }
                                }
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            BL_ChargeWT = Convert.ToDouble(obj_dt.Rows[j]["chargewt"].ToString());

                            if (MBL_Amount != 0)
                            {
                                BL_Amount = ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
                            }
                            if (MBL_Expense != 0)
                            {
                                BL_Expense = ((MBL_Expense / JobChargeWT) * BL_ChargeWT);
                            }
                        }

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dt.Rows[j][2].ToString().Length > 0 && obj_dt.Rows[j][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                        }
                        int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                        char Nomination;
                        string blno;
                        double volume = 0;
                        int_job = Convert.ToInt32(obj_dt.Rows[j][0].ToString());
                        blno = obj_dt.Rows[j][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dt.Rows[j][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dt.Rows[j][7].ToString());
                        int_notify = Convert.ToInt32(obj_dt.Rows[j][8].ToString());
                        int_agent = Convert.ToInt32(obj_dt.Rows[j][9].ToString());
                        int_pol = Convert.ToInt32(obj_dt.Rows[j][10].ToString());
                        int_pod = Convert.ToInt32(obj_dt.Rows[j][11].ToString());
                        int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        Nomination = char.Parse(obj_dt.Rows[j][4].ToString());
                        volume = Convert.ToDouble(obj_dt.Rows[j][5].ToString());
                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (JobType == 3)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                            }
                            else
                            {
                                int_Cont20 = 0;
                                int_Cont40 = 0;
                            }
                        }
                        obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, vouno, char.Parse(voutype));

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void Fn_CostTempCH(int Jobno)
        {
            try
            {
                double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
                int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
                //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                obj_da_Cost.DelCostingDetailsRpt(Jobno, trantype, "V", int_bid, 0, "");
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                obj_dt = obj_da_Cost.GetClosedJobDts(Jobno, trantype, int_bid);
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    BL_Expense = obj_da_Cost.GetcostPA(obj_dt.Rows[i]["docno"].ToString(), trantype, int_bid);
                    BL_credit = obj_da_Cost.GetCreditDebit(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid, "Credit");
                    BL_debit = obj_da_Cost.GetCreditDebit(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid, "Debit");
                    BL_Amount = obj_da_Cost.GetcostInvBOS(obj_dt.Rows[i]["docno"].ToString(), trantype, int_bid);
                    BL_Amount = BL_Amount + BL_credit;
                    BL_Expense = BL_Expense + BL_debit;
                    Close_date = Convert.ToDateTime(obj_dt.Rows[i]["jobclosedate"].ToString());
                    int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                    char Nomination;
                    string blno;
                    double volume = 0;
                    int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                    blno = obj_dt.Rows[i]["docno"].ToString();
                    int_shipper = Convert.ToInt32(obj_dt.Rows[i]["shipper"].ToString());
                    int_consignee = Convert.ToInt32(obj_dt.Rows[i]["consignee"].ToString());
                    int_notify = Convert.ToInt32(obj_dt.Rows[i]["notifyparty"].ToString());
                    int_agent = 0;
                    int_pol = Convert.ToInt32(obj_dt.Rows[i]["pol"].ToString());
                    int_pod = Convert.ToInt32(obj_dt.Rows[i]["pod"].ToString());
                    int_sales = 0;
                    Nomination = char.Parse(" ");
                    volume = Convert.ToDouble(obj_dt.Rows[i]["netwt"].ToString());
                    JobType = 0;
                    int_Cont20 = 0;
                    int_Cont40 = 0;
                    obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, 0, Nomination);
                }
                //Fn_DNCNBL(int_jobno, "Closed", Close_date, 0, string.Empty);

                Fn_DNCNBL(int_jobno, "Closed", Close_date, 0, " ");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void Fn_CostTempBT(int Jobno)
        {
            try
            {
                double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
                int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
                //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                obj_da_Cost.DelCostingDetailsRpt(Jobno, trantype, "V", int_bid, 0, "");
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                obj_dt = obj_da_Cost.GetClosedJobDts(Jobno, trantype, int_bid);
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    BL_Expense = obj_da_Cost.GetcostPABT(obj_dt.Rows[i][0].ToString(), trantype, int_bid, Convert.ToInt32(obj_dt.Rows[i][3].ToString()));
                    BL_Amount = obj_da_Cost.GetcostInvBT(obj_dt.Rows[i][0].ToString(), trantype, int_bid, Convert.ToInt32(obj_dt.Rows[i][3].ToString()));

                    Close_date = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["jobclosedate"].ToString()));
                    int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                    char Nomination;
                    string blno;
                    double volume = 0;
                    int_job = Convert.ToInt32(obj_dt.Rows[i][0].ToString());
                    blno = obj_dt.Rows[i][1].ToString();
                    int_shipper = Convert.ToInt32(obj_dt.Rows[i][3].ToString());
                    int_pol = Convert.ToInt32(obj_dt.Rows[i][6].ToString());
                    int_pod = Convert.ToInt32(obj_dt.Rows[i][7].ToString());
                    int_sales = 0;
                    Nomination = char.Parse(" ");
                    volume = Convert.ToDouble(obj_dt.Rows[i][2].ToString());
                    JobType = 0;
                    int_Cont20 = 0;
                    int_Cont40 = 0;
                    obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, 0, Nomination);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void ddl_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    return;
                }
                //DataAccess.CloseJobs JobCloseObj = new DataAccess.CloseJobs();
                DataTable dtClosejob = new DataTable();
                string stragent;
                btn_confirm.Visible = false;
                if (ddl_job.Text == "Unclosed Jobs")
                {

                    if (trantype == "FE" || trantype == "FI")
                    {

                        Grd_FEFI.Visible = true;
                        P2.Visible = true;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_job.Visible = false;
                        P1.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        stragent = "agent";
                        dtClosejob = JobCloseObj.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                        Grd_FEFI.DataSource = dtClosejob;
                        Grd_FEFI.DataBind();
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {

                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_AEAI.Visible = true;
                        //P3.Visible = true;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_job.Visible = false;
                        P1.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        stragent = "agent";
                        dtClosejob = JobCloseObj.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                        Grd_AEAI.DataSource = dtClosejob;
                        Grd_AEAI.DataBind();
                    }
                    else if (trantype == "CH")
                    {

                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = true;
                        P4.Visible = true;
                        Grd_job.Visible = false;
                        P1.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        stragent = "principal";
                        dtClosejob = JobCloseObj.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                        Grd_CH.DataSource = dtClosejob;
                        Grd_CH.DataBind();
                    }
                    else if (trantype == "BT")
                    {
                        Grd_BT.Visible = true;
                        P5.Visible = true;
                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_job.Visible = false;
                        P1.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        stragent = "principal";
                        dtClosejob = JobCloseObj.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                        Grd_BT.DataSource = dtClosejob;
                        Grd_BT.DataBind();
                    }
                }
                else if (ddl_job.Text == "Closed Jobs")
                {
                    if (trantype == "FE" || trantype == "FI")
                    {

                        Grd_FEFI.Visible = true;
                        P2.Visible = true;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_job.Visible = false;
                        P1.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        stragent = "agent";
                        dtClosejob = JobCloseObj.GetJobDetailsClose(strjobinfo, trantype, int_bid);
                        Grd_FEFI.DataSource = dtClosejob;
                        Grd_FEFI.DataBind();
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {

                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_AEAI.Visible = true;
                        //P3.Visible = true;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_job.Visible = false;
                        P1.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        stragent = "agent";
                        dtClosejob = JobCloseObj.GetJobDetailsClose(strjobinfo, trantype, int_bid);
                        Grd_AEAI.DataSource = dtClosejob;
                        Grd_AEAI.DataBind();
                    }
                    else if (trantype == "CH")
                    {

                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = true;
                        P4.Visible = true;
                        Grd_job.Visible = false;
                        P1.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        stragent = "principal";
                        dtClosejob = JobCloseObj.GetJobDetailsClose(strjobinfo, trantype, int_bid);
                        Grd_CH.DataSource = dtClosejob;
                        Grd_CH.DataBind();
                    }
                    else if (trantype == "BT")
                    {
                        Grd_BT.Visible = true;
                        P5.Visible = true;
                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_job.Visible = false;
                        P1.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        stragent = "principal";
                        dtClosejob = JobCloseObj.GetJobDetailsClose(strjobinfo, trantype, int_bid);
                        Grd_BT.DataSource = dtClosejob;
                        Grd_BT.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void grdclsjob_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                double dbl_temp = 0;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[9].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[9].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[9].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[10].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[10].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[10].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }

                e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[11].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[11].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[11].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }

            }
        }

        protected void Grd_job_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (e.Row.Cells[0].Text == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void Grd_AEAI_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_AEAI, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_BT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_BT, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int volconf = 0, incconf = 0, expconf = 0, blreleaseconf = 0, destconf = 0;
                string bl_no;

                //if (grdclsjob.Visible == true)
                //{
                    foreach (GridViewRow row in grdclsjob.Rows)
                    {
                        if (grdclsjob.DataKeys[row.RowIndex].Values[0].ToString() != "")
                        {
                            volconf = 0; incconf = 0; expconf = 0; blreleaseconf = 0; destconf = 0;
                            //CheckBox Chk = (CheckBox)row.FindControl("vol");
                            //if (Chk.Checked == true)
                            //{
                            //    volconf = 1;
                            //}
                            //CheckBox Chk1 = (CheckBox)row.FindControl("inc");
                            //if (Chk1.Checked == true)
                            //{
                            //    incconf = 1;
                            //}
                            //CheckBox Chk2 = (CheckBox)row.FindControl("exp");
                            //if (Chk2.Checked == true)
                            //{
                            //    expconf = 1;
                            //}
                            //CheckBox Chk3 = (CheckBox)row.FindControl("blrelease");
                            //if (Chk3.Checked == true)
                            //{
                            //    blreleaseconf = 1;
                            //}
                            //CheckBox Chk4 = (CheckBox)row.FindControl("port");
                            //if (Chk4.Checked == true)
                            //{
                            //    destconf = 1;
                            //}
                            volconf = 1;
                            incconf = 1;
                            expconf = 1;
                            blreleaseconf = 1;
                            destconf = 1;
                            int_jobno = Convert.ToInt32(grdclsjob.DataKeys[row.RowIndex].Values[0].ToString());
                            bl_no = grdclsjob.DataKeys[row.RowIndex].Values[1].ToString();
                            da_obj_Closejob.UpdJobClsConfirm(int_jobno, trantype, bl_no, int_bid, int_did, volconf, incconf, expconf, blreleaseconf, destconf);
                        }

                    }
                   // ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "logix", "alertify.alert('Confirmation Updated');", true);
                //}

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void logde(int jobno, string str)
        {
            switch (trantype)
            {
                case "FE":
                    obj_da_Log.InsLogDetail(int_Empid, 101, 2, int_bid, int_jobno + "/" + str);
                    break;
                case "FI":
                    obj_da_Log.InsLogDetail(int_Empid, 102, 2, int_bid, int_jobno + "/" + str);
                    break;
                case "AE":
                    obj_da_Log.InsLogDetail(int_Empid, 103, 2, int_bid, int_jobno + "/" + str);
                    break;
                case "AI":
                    obj_da_Log.InsLogDetail(int_Empid, 104, 2, int_bid, int_jobno + "/" + str);
                    break;
                case "CH":
                    obj_da_Log.InsLogDetail(int_Empid, 92, 2, int_bid, int_jobno + "/" + str);
                    break;
                case "BT":
                    obj_da_Log.InsLogDetail(int_Empid, 359, 2, int_bid, int_jobno + "/Closed");
                    break;
            }
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {

        }

        protected void btn_jobclose_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    return;
                }
              
                int_jobno = Convert.ToInt32(txt_job.Text);
                Close_date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                da_obj_Closejob.UpdateClosedateForJobinfo(Convert.ToInt32(txt_job.Text), trantype, int_bid, Close_date, int_Empid);
                logde(int_jobno, "Closed");
                lbl.Text = "Job Closed";
                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;
                Flag = 0;
                ClosedJob();
                return;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void ClosedJob()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
                //if (ddl_job.SelectedItem.Value == "1")
                if (ddl_job.Text == "Unclosed Jobs")
                {
                    if (trantype == "FE" || trantype == "FI")
                    {
                        Grd_job.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_BT.Visible = false;
                        P5.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        Grd_FEFI.Visible = true;
                        P2.Visible = true;
                        P1.Visible = false;
                        obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                        Grd_FEFI.DataSource = obj_dt;
                        Grd_FEFI.DataBind();
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        Grd_job.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_BT.Visible = false;
                        P5.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_AEAI.Visible = true;
                        //P3.Visible = true;
                        P1.Visible = false;
                        obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                        Grd_AEAI.DataSource = obj_dt;
                        Grd_AEAI.DataBind();
                    }
                    else if (trantype == "CH")
                    {
                        Grd_job.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_BT.Visible = false;
                        P5.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_CH.Visible = true;
                        P4.Visible = true;
                        P1.Visible = false;
                        obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                        Grd_CH.DataSource = obj_dt;
                        Grd_CH.DataBind();
                    }
                    else if (trantype == "BT")
                    {
                        Grd_job.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_BT.Visible = true;
                        P5.Visible = true;
                        P1.Visible = false;
                        obj_dt = obj_da_Close.GetJobDetailsOpen(strjobinfo, trantype, int_bid);
                        Grd_BT.DataSource = obj_dt;
                        Grd_BT.DataBind();
                    }
                }
                //else if (ddl_job.SelectedIndex == 2)
                else if (ddl_job.Text == "Closed Jobs")
                {
                    if (trantype == "FE" || trantype == "FI")
                    {
                        Grd_job.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_BT.Visible = false;
                        P5.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        Grd_FEFI.Visible = true;
                        P2.Visible = true;
                        P1.Visible = false;
                        obj_dt = obj_da_Close.GetJobDetailsClose(strjobinfo, trantype, int_bid);
                        Grd_FEFI.DataSource = obj_dt;
                        Grd_FEFI.DataBind();
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        Grd_job.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        Grd_BT.Visible = false;
                        P5.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_AEAI.Visible = true;
                        //P3.Visible = true;
                        P1.Visible = false;
                        obj_dt = obj_da_Close.GetJobDetailsClose(strjobinfo, trantype, int_bid);
                        Grd_AEAI.DataSource = obj_dt;
                        Grd_AEAI.DataBind();
                    }
                    else if (trantype == "CH")
                    {
                        Grd_job.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_BT.Visible = false;
                        P5.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_CH.Visible = true;
                        P4.Visible = true;
                        P1.Visible = false;
                        obj_dt = obj_da_Close.GetJobDetailsClose(strjobinfo, trantype, int_bid);
                        Grd_CH.DataSource = obj_dt;
                        Grd_CH.DataBind();
                    }
                    else if (trantype == "BT")
                    {
                        Grd_job.Visible = false;
                        Grd_AEAI.Visible = false;
                        P3.Visible = false;
                        Grd_CH.Visible = false;
                        P4.Visible = false;
                        grdclsjob.Visible = false;
                        P8.Visible = false;
                        Grd_FEFI.Visible = false;
                        P2.Visible = false;
                        Grd_BT.Visible = true;
                        P5.Visible = true;
                        P1.Visible = false;
                        obj_dt = obj_da_Close.GetJobDetailsClose(strjobinfo, trantype, int_bid);
                        Grd_BT.DataSource = obj_dt;
                        Grd_BT.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_CH_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_CH, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void CHGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CHGrid.PageIndex = e.NewPageIndex;
            popup_Grd.Show();
            CHGrid.DataSource = (DataTable)ViewState["CHGrid"];
            CHGrid.DataBind();
        }

        protected void CHGrid_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(CHGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void CHGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index1 = Convert.ToInt32(CHGrid.SelectedRow.RowIndex);
            if (CHGrid.Rows.Count > 0)
            {
                txt_job.Text = CHGrid.Rows[index1].Cells[0].Text.ToString();
                txt_job_TextChanged(sender, e);
            }
        }

        protected void BTGrid_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(BTGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void BTGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BTGrid.PageIndex = e.NewPageIndex;
            popup_Grd.Show();
            BTGrid.DataSource = (DataTable)ViewState["BTGrid"];
            BTGrid.DataBind();
        }

        protected void BTGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index1 = Convert.ToInt32(BTGrid.SelectedRow.RowIndex);
            if (BTGrid.Rows.Count > 0)
            {
                txt_job.Text = BTGrid.Rows[index1].Cells[0].Text.ToString();
                txt_job_TextChanged(sender, e);
            }
        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_job_SelectedIndexChanged(sender, e);
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

            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 101, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 102, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 103, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 104, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 92, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
            }

            if (txt_job.Text != "")
            {
                JobInput.Text = txt_job.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grdclsjob_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chk_access = (CheckBox)e.Row.Cells[1].FindControl("vol");
                CheckBox chk_accessAll = (CheckBox)this.grdclsjob.HeaderRow.FindControl("vol_head");
                chk_access.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_accessAll.ClientID);
                CheckBox chk_save = (CheckBox)e.Row.Cells[1].FindControl("inc");
                CheckBox chk_saveAll = (CheckBox)this.grdclsjob.HeaderRow.FindControl("inc_head");
                chk_save.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_saveAll.ClientID);
                CheckBox chk_view = (CheckBox)e.Row.Cells[1].FindControl("exp");
                CheckBox chk_viewAll = (CheckBox)this.grdclsjob.HeaderRow.FindControl("exp_head");
                chk_view.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_viewAll.ClientID);
                CheckBox chk_delete = (CheckBox)e.Row.Cells[1].FindControl("blrelease");
                CheckBox chk_deleteAll = (CheckBox)this.grdclsjob.HeaderRow.FindControl("blrelease_head");
                chk_delete.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_deleteAll.ClientID);
                CheckBox chk_upd = (CheckBox)e.Row.Cells[1].FindControl("port");
                CheckBox chk_updAll = (CheckBox)this.grdclsjob.HeaderRow.FindControl("port_head");
                chk_upd.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_updAll.ClientID);
            }
        }

        protected void Grd_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            int_jobno = Convert.ToInt32(txt_job.Text);
            string blno = " ";
            blno = Grd_job.SelectedRow.Cells[0].Text.ToString();
            Dt = da_obj_Costing.GetBLcostingvouwise(int_jobno, blno, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_mbl.Text, trantype);
            if (Dt.Rows.Count > 0)
            {
                lblname.Text = "BL# : " + Grd_job.SelectedRow.Cells[0].Text.ToString() + " - " + "BLcosting Voucherwise";
                DataRow Dr = Dt.NewRow();
                Dr[5] = "Total";
                Dr[6] = Convert.ToDouble(Dt.Compute("SUM(Income)", string.Empty)).ToString("#,0.00");
                Dr[7] = Convert.ToDouble(Dt.Compute("SUM(Expence)", string.Empty)).ToString("#,0.00");
                Dr[8] = Convert.ToDouble(Dt.Compute("SUM(Retension)", string.Empty)).ToString("#,0.00");
                Dt.Rows.Add(Dr);
                GridView2.DataSource = Dt;
                GridView2.DataBind();

                ModalPopupExtender1.Show();

            }

        }

       protected void btn_reclose_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
                DataTable obj_dt = new DataTable();
                DataTable dtconf = new DataTable();
                string strmsg = "";
                //DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
                //DataAccess.Accounts.Invoice obj_dA_Invoice = new DataAccess.Accounts.Invoice();
                if (txt_job.Text.Trim().Length > 0 && txt_job.Text != "0")
                {
                    int_jobno = Convert.ToInt32(txt_job.Text.Trim().ToString());
                    DateTime dt_date = obj_da_Log.GetDate();
                    dt_date = dt_date.AddDays(-9);
                    Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                    //if (Close_date <= dt_date)
                    //{
                    //    txt_date.Text = Utility.fn_ConvertDate(dt_date.AddDays(9).ToShortDateString());
                    //    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Only 9 days before the closingdate is Allowed');", true);
                    //    return;
                    //}
                    //else
                    //{
                    //    Close_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                    //}

                    ////raj
                    //dtconf = obj_da_Close.SelJobClsConfirm4JobCls(int_jobno, trantype, int_bid, int_did);
                    //if (dtconf.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i <= dtconf.Rows.Count - 1; i++)
                    //    {
                    //        if (i > 0)
                    //        {
                    //            strmsg = strmsg + "," + dtconf.Rows[i]["blno"].ToString();
                    //        }
                    //        else
                    //        {
                    //            strmsg = strmsg + "," + dtconf.Rows[i]["blno"].ToString();
                    //        }
                    //    }

                    //    string msg = "There are BL #" + strmsg + "to be Confirmed by Volume/Income/Expense/BL Release/Destination in this Job # :" + txt_job.Text + "Hence you cannot close this Job";
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alertify.alert(' " + msg + "');", true);

                    //    return;
                    //}
                    jobcloseagainstvoucher();
                    if (Flag == 1)
                    {
                        if (Flagvou == 100)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Vouchers are there in Job , Create HBL # and then Close it  " + txt_job.Text + "');", true);
                            Flag = 0;
                            Flagvou = 0;
                            return;
                        }
                        else
                        {
                            this.PopUpService.Show();
                            return;
                        }
                    }
                    else
                    {
                        if (Flagvou == 0)
                        {
                            this.PopUpService.Show();
                            return;
                        }
                    }

                    //if (Grdcost.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i <= Grdcost.Rows.Count - 1; i++)
                    //    {
                    //        if (Grdcost.Rows[i].Cells[3].Text.ToString() == "UnApproved")
                    //        {
                    //            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Please Approve all the UnApproved vouchers before Closing the Job #" + txt_job.Text + "');", true);
                    //            return;
                    //        }
                    //    }
                    //}
                    if (Grdcost.Rows.Count > 0)
                    {
                        //string customername="";
                        int i;
                        //Label lbl = (Grdcost.Rows[i].Cells[5].FindControl("customer") as Label);
                        //customername = lbl.Text;

                        for (i = 0; i <= Grdcost.Rows.Count - 1; i++)
                        {
                            Label customername = (Grdcost.Rows[i].Cells[5].FindControl("cname") as Label);

                            if (customername.Text == "Loss")
                            {
                                if (txt_remark.Text.Trim().Length == 0)
                                {
                                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Please Enter the Remarks');", true);
                                    txt_remark.Focus();
                                    //return;
                                }
                                else
                                {
                                    obj_da_Close.UpdJobCloseRemarks(int_bid, txt_job.Text, trantype, txt_remark.Text);
                                }
                            }
                            else if (customername.Text == "Profit")
                            {
                                if (txt_remark.Text.Trim().Length != 0)
                                {
                                    obj_da_Close.UpdJobCloseRemarks(int_bid, txt_job.Text, trantype, txt_remark.Text);
                                }
                            }
                        }
                    }
                    string Str_Vouno = "", str_Msg = "";
                    int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    DataTable obj_dttemp = new DataTable();
                    if (trantype == "FE" || trantype == "FI" || trantype == "AE" || trantype == "AI")
                    {

                        obj_dt = obj_da_DC.FillBLNo(Convert.ToInt32(txt_job.Text.Trim()), trantype, int_bid);
                        if (obj_dt.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Atleast One HBL Should Exists before Closing for the Job # " + txt_job.Text + "');", true);
                            return;
                        }
                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "I");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<Int32>(obj_dt.Columns[0].ColumnName.ToString()));
                            //var obj_Vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<Int32>("invoiceno").ToString());
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            // Str_Vouno = string.Join(",", obj_Vouno.ToString());
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are Invoice( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            //return;
                        }

                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "P");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are PA( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }

                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "D");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are OSDN( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }

                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "C");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are OSCN( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }
                        if (obj_da_Close.CheckDCAdviseRaiseOS(int_jobno, trantype, int_bid, "D") == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('OSDN/CN has not been raised. Please create OSDN/CN then check costing with details.');", true);
                            return;
                        }
                        if (obj_da_Close.CheckDCAdviseRaiseOS(int_jobno, trantype, int_bid, "C") == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('OSDN/CN has not been raised. Please create OSDN/CN then check costing with details.');", true);
                            return;
                        }

                        //obj_da_Close.UpdateCloseJob(trantype + "JobInfo", trantype, int_jobno, int_bid, Close_date, int_Empid);

                        ////ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Your request for closing the job # 9999 will be processed shortly and you will receive an email once the job closing process is completed');", true);

                        ////  Your request for closing the job # "9999" will be processed shortly and you will receive an email once the job closing process is completed

                        //if (lbl_Header.Text == "Costing with Details")
                        //{
                        //    obj_da_Log.InsLogDetail(int_Empid, 1287, 2, int_bid, int_jobno + "/Closed");
                        //}

                        //switch (trantype)
                        //{
                        //    case "FE":
                        //        obj_da_Log.InsLogDetail(int_Empid, 101, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //    case "FI":
                        //        obj_da_Log.InsLogDetail(int_Empid, 102, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //    case "AE":
                        //        obj_da_Log.InsLogDetail(int_Empid, 103, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //    case "AI":
                        //        obj_da_Log.InsLogDetail(int_Empid, 104, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //    case "CH":
                        //        obj_da_Log.InsLogDetail(int_Empid, 92, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //}
                        //if (txt_remark.Text.Trim().Length > 0)
                        //{
                        //    obj_da_Close.UpdJobCloseRemarks4rptJob(int_bid, int_jobno.ToString(), trantype, txt_remark.Text);
                        //}

                        //Raj sir

                        /*  if (trantype == "FE" || trantype == "FI")
                          {
                              if (obj_dt.Rows.Count > 0)
                              {
                                  ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Debit Note - Credit Note - Generated in " + POL_ShortName + "');", true);
                                  ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Debit Note - Credit Note -  Generated in " + ICD_Shortname + "');", true);

                              }
                          }*/

                        Fn_CostTemp4Reclose(int_jobno);
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Job ReClosed');", true);

                        obj_dttemp = da_obj_Costing.BLCosting(int_jobno, trantype, int_bid);
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            P1.Visible = true;
                            Grd_job.Visible = true;
                            lbl.Text = "Job Closed";
                            btn_update.Enabled = false;
                            btn_update.ForeColor = System.Drawing.Color.Gray;
                            var sum_Income = obj_dttemp.Compute("sum(income)", "");
                            var sum_Expense = obj_dttemp.Compute("sum(expense)", "");
                            var sum_Retention = obj_dttemp.Compute("sum(retention)", "");

                            DataRow dr = obj_dttemp.NewRow();
                            obj_dttemp.Rows.Add(dr);
                            dr[2] = "Total";
                            dr[3] = sum_Income;
                            dr[4] = sum_Expense;
                            dr[5] = sum_Retention;

                            Grd_job.DataSource = obj_dttemp;
                            Grd_job.DataBind();
                            grdclsjob.Visible = false;
                            P8.Visible = false;
                            btn_confirm.Visible = false;
                        }

                        //To hide
                    }

                    else if (trantype == "CH")
                    {
                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "I");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are  Invoice( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }
                        obj_dt = obj_da_Close.CheckApprovedVoucher(int_jobno, trantype, int_bid, "P");
                        Str_Vouno = "";
                        if (obj_dt.Rows.Count > 0)
                        {
                            //var obj_vouno = (from r in obj_dt.AsEnumerable()
                            //                 select r.Field<string>(obj_dt.Columns[0].ColumnName.ToString()).ToString());
                            //Str_Vouno = string.Join(",", obj_vouno);
                            for (int i = 0; i < obj_dt.Rows.Count; i++)
                            {
                                Str_Vouno = obj_dt.Rows[i][0].ToString() + " , " + Str_Vouno;
                            }
                            str_Msg = "";
                            str_Msg = "alertify.alert('There are PA( s )( " + Str_Vouno + ")  to be Approved in this Job # :" + txt_job.Text + "Hence you cannot close this Job');";
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", str_Msg, true);
                            return;
                        }

                        //obj_da_Close.UpdateCloseJob(trantype + "JobInfo", trantype, int_jobno, int_bid, Close_date, int_Empid);

                        //Raj sir

                        Fn_CostTempCH(int_jobno);
                        if (lbl_Header.Text == "Costing with Details")
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 1287, 2, int_bid, int_jobno + "/Closed");
                        }
                        switch (trantype)
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 101, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 102, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 103, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 104, 2, int_bid, int_jobno + "/Closed");
                                break;
                            case "CH":
                                obj_da_Log.InsLogDetail(int_Empid, 92, 2, int_bid, int_jobno + "/Closed");
                                break;

                        }

                        if (txt_remark.Text.Trim().Length > 0)
                        {
                            obj_da_Close.UpdJobCloseRemarks4rptJob(int_bid, int_jobno.ToString(), trantype, txt_remark.Text);
                        }

                        // ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Job Closed');", true);

                        //Raj sir
                        /* obj_dttemp = da_obj_Costing.BLCosting(int_jobno, trantype, int_bid);
                         if (obj_dttemp.Rows.Count > 0)
                         {
                             P1.Visible = true;
                             Grd_job.Visible = true;
                             lbl.Text = "Job Closed";
                             btn_update.Enabled = false;
                             btn_update.ForeColor = System.Drawing.Color.Gray;
                             var sum_Income = obj_dttemp.Compute("sum(income)", "");
                             var sum_Expense = obj_dttemp.Compute("sum(expense)", "");
                             var sum_Retention = obj_dttemp.Compute("sum(retention)", "");

                             DataRow dr = obj_dttemp.NewRow();
                             obj_dttemp.Rows.Add(dr);
                             dr[2] = "Total";
                             dr[3] = sum_Income;
                             dr[4] = sum_Expense;
                             dr[5] = sum_Retention;

                             Grd_job.DataSource = obj_dttemp;
                             Grd_job.DataBind();
                             grdclsjob.Visible = false;
                             P8.Visible = false;
                             btn_confirm.Visible = false;
                         }
                         */
                        //To hide

                    }
                    else if (trantype == "BT")
                    {
                        //obj_da_Close.UpdateCloseJob(trantype + "JobInfo", trantype, int_jobno, int_bid, Close_date, int_Empid);

                        //Raj sir
                        Fn_CostTempBT(int_jobno);

                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Job ReClosed');", true);

                        //if (lbl_Header.Text == "Costing with Details")
                        //{
                        //    obj_da_Log.InsLogDetail(int_Empid, 1287, 2, int_bid, int_jobno + "/Closed");
                        //}

                        //switch (trantype)
                        //{
                        //    case "FE":
                        //        obj_da_Log.InsLogDetail(int_Empid, 101, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //    case "FI":
                        //        obj_da_Log.InsLogDetail(int_Empid, 102, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //    case "AE":
                        //        obj_da_Log.InsLogDetail(int_Empid, 103, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //    case "AI":
                        //        obj_da_Log.InsLogDetail(int_Empid, 104, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //    case "CH":
                        //        obj_da_Log.InsLogDetail(int_Empid, 92, 2, int_bid, int_jobno + "/Closed");
                        //        break;
                        //}

                        // ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Jobs Closed');", true);

                        //Raj sir
                        /*    obj_dttemp = da_obj_Costing.BLCosting(int_jobno, trantype, int_bid);
                             if (obj_dttemp.Rows.Count > 0)
                             {
                                 P1.Visible = true;
                                 Grd_job.Visible = true;
                                 lbl.Text = "Job Closed";
                                 btn_update.Enabled = false;
                                 btn_update.ForeColor = System.Drawing.Color.Gray;
                                 var sum_Income = obj_dttemp.Compute("sum(income)", "");
                                 var sum_Expense = obj_dttemp.Compute("sum(expense)", "");
                                 var sum_Retention = obj_dttemp.Compute("sum(retention)", "");

                                 DataRow dr = obj_dttemp.NewRow();
                                 obj_dttemp.Rows.Add(dr);
                                 dr[2] = "Total";
                                 dr[3] = sum_Income;
                                 dr[4] = sum_Expense;
                                 dr[5] = sum_Retention;

                                 Grd_job.DataSource = obj_dttemp;
                                 Grd_job.DataBind();
                                 grdclsjob.Visible = false;
                                 P8.Visible = false;
                                 btn_confirm.Visible = false;
                             }
                            */
                        //To hide
                    }

                    //lbl.Text = "Job Closed";
                    //ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "CostingDetails", "alertify.alert('Your request for closing the job # " + txt_job.Text + " will be processed shortly and you will receive an email once the job closing process is completed');", true);

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_CostTemp4Reclose(int Jobno)
        {
            try
            {
                double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
                int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
                //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                obj_da_Cost.DelCostingDetailsRpt(Jobno, trantype, "V", int_bid, 0, "");
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                obj_dt = obj_da_Cost.GetClosedJobDts(Jobno, trantype, int_bid);
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    MBL_Expense = obj_da_Cost.GetcostPA4Reclose(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid);
                    MBL_credit = obj_da_Cost.GetCreditDebit(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid, "Credit");
                    MBL_debit = obj_da_Cost.GetCreditDebit(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid, "Debit");
                    MBL_Amount = obj_da_Cost.GetcostInv4Reclose(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid);
                    Close_date = DateTime.Parse((obj_dt.Rows[i]["jobclosedate"].ToString()));
                    if (trantype == "FE" || trantype == "FI")
                    {
                        JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());

                        obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);

                        if (obj_dttemp.Rows.Count > 0)
                        {
                            if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
                            {
                                Total_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["cbmtotal"].ToString());
                                Total_Tues = Convert.ToDouble(obj_dttemp.Rows[0]["Tuestotal"].ToString());
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        JobType = 0;
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["airline"].ToString());

                        obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);

                        if (obj_dttemp.Rows.Count > 0)
                        {
                            if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
                            {
                                JobChargeWT = Convert.ToDouble(obj_dttemp.Rows[0][0].ToString());
                            }
                        }
                    }

                    obj_dttemp = obj_da_Cost.GetBLRow(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);
                    for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                    {
                        BL_Expense = obj_da_Cost.GetcostPA4Reclose(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid);
                        BL_credit = obj_da_Cost.GetCreditDebit(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid, "Credit");
                        BL_debit = obj_da_Cost.GetCreditDebit(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid, "Debit");
                        BL_Amount = obj_da_Cost.GetcostInv4Reclose(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid);
                        if (trantype == "FE" || trantype == "FI")
                        {
                            BL_Tues = Convert.ToInt32(obj_dttemp.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dttemp.Rows[j]["cont40"].ToString()) * 2);
                            BL_CBM = Convert.ToDouble(obj_dttemp.Rows[j]["cbm"].ToString());
                            if (MBL_Amount != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / 1) * 1);
                                    }
                                    else
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / Total_Tues) * BL_Tues);
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_Amount = BL_Amount + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_Amount = BL_Amount + 0;
                                    }
                                    else
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / Total_CBM) * BL_CBM);
                                    }
                                }
                            }
                            if (MBL_debit != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / 1) * 1);
                                    }
                                    else
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / Total_Tues) * BL_Tues);
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_debit = BL_debit + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_debit = BL_debit + 0;
                                    }
                                    else
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / Total_CBM) * BL_CBM);
                                    }
                                }
                            }
                            if (MBL_credit != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / 1) * 1);
                                    }
                                    else
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / Total_Tues) * BL_Tues);
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_credit = BL_credit + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_credit = BL_credit + 0;
                                    }
                                    else
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / Total_CBM) * BL_CBM);
                                    }
                                }
                            }

                            if (MBL_Expense != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / 1) * 1);
                                    }
                                    else
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / Total_Tues) * BL_Tues);
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_Expense = BL_Expense + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_Expense = BL_Expense + 0;
                                    }
                                    else
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / Total_CBM) * BL_CBM);
                                    }
                                }
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            BL_ChargeWT = Convert.ToDouble(obj_dttemp.Rows[j]["chargewt"].ToString());

                            if (MBL_Amount != 0)
                            {
                                BL_Amount = BL_Amount + ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
                            }
                            if (MBL_debit != 0)
                            {
                                BL_debit = BL_debit + ((MBL_debit / JobChargeWT) * BL_ChargeWT);
                            }
                            if (MBL_credit != 0)
                            {
                                BL_credit = BL_credit + ((MBL_credit / JobChargeWT) * BL_ChargeWT);
                            }
                            if (MBL_Expense != 0)
                            {
                                BL_Expense = BL_Expense + ((MBL_Expense / JobChargeWT) * BL_ChargeWT);
                            }
                        }

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dttemp.Rows[j][2].ToString().Length > 0 && obj_dttemp.Rows[j][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[j][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[j][3].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                        }
                        int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                        char Nomination;
                        string blno;
                        double volume = 0;
                        int_job = Convert.ToInt32(obj_dttemp.Rows[j][0].ToString());
                        blno = obj_dttemp.Rows[j][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[j][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[j][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[j][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[j][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[j][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[j][11].ToString());
                        int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        Nomination = char.Parse(obj_dttemp.Rows[j][4].ToString());
                        volume = Convert.ToDouble(obj_dttemp.Rows[j][5].ToString());
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;

                        //if (DBNull.Value.Equals(BL_Amount) == true)
                        //{ 

                        //}
                        obj_da_Cost.InsCostingTempRptreclose(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, 0, char.Parse(" "));

                    }
                }
                Fn_DNCNBL4Reclose(Jobno, trantype, "Closed", Close_date, 0, "");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        private void Fn_DNCNBL4Reclose(int jobno, string trantype, string type, DateTime CDate, int vouno, string voutype)
        {

            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            DateTime dtdate = CDate;
            //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();

            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            if (type == "Closed")
            {
                //obj_dt = obj_da_Cost.GetDNCN4MISFromJobNo(jobno, int_bid, trantype); 
                obj_dt = obj_da_Cost.GetDNCN4MISFromVounonew4Reclose(jobno, int_bid, trantype, vouno, voutype);
            }
            else if (type == "Approve")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromVounonew(jobno, int_bid, trantype, vouno, voutype);
            }
            int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
            char Nomination;
            string blno;
            double volume = 0;
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    blno = obj_dt.Rows[i]["blno"].ToString();
                    int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                    if (trantype != "CH")
                    {
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
                    }
                    else
                    {
                        MLO = 0;
                    }
                    if (type == "Closed")
                    {
                        //dtdate = CDate;
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                        vouno = Convert.ToInt32(obj_dt.Rows[i]["vouno"].ToString());
                        voutype = obj_dt.Rows[i]["voutype"].ToString();
                    }
                    else if (type == "Approve")
                    {
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                    }
                    obj_dttemp = obj_da_Cost.GetBLRowBL(blno, trantype, int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        BL_Amount = 0;
                        BL_Expense = 0;
                        if (i < obj_dt.Rows.Count - 1)
                        {
                            if (obj_dt.Rows[i]["blno"].ToString() != obj_dt.Rows[i + 1]["blno"].ToString())
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "I" || obj_dt.Rows[i]["voutype"].ToString() == "B")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "P")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                if (obj_dt.Rows[i]["voutype"].ToString() == "D")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "C")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }

                                else if (obj_dt.Rows[i]["voutype"].ToString() == "I" || obj_dt.Rows[i]["voutype"].ToString() == "B")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "P")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                if (obj_dt.Rows[i]["voutype"].ToString() == "D")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "C")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }

                            else if (obj_dt.Rows[i]["voutype"].ToString() == "I" || obj_dt.Rows[i]["voutype"].ToString() == "B")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (obj_dt.Rows[i]["voutype"].ToString() == "P")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                            if (obj_dt.Rows[i]["voutype"].ToString() == "D")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (obj_dt.Rows[i]["voutype"].ToString() == "C")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                        }
                        int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
                        blno = obj_dttemp.Rows[0][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());
                        if (trantype != "CH")
                        {
                            int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        }
                        //Nomination = char.Parse(" ");
                        char Nominatn = ' ';
                        if (!string.IsNullOrEmpty(obj_dttemp.Rows[0][4].ToString()))
                        {
                            if (obj_dttemp.Rows[0][4].ToString().Length > 0)
                            {
                                Nominatn = char.Parse(obj_dttemp.Rows[0][4].ToString());
                            }

                        }
                        else
                        {
                            Nominatn = ' ';
                        }
                        volume = Convert.ToDouble(obj_dttemp.Rows[0][5].ToString());

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
                                JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI" || trantype == "CH")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                            JobType = 0;
                        }
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;

                        //obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, 0, char.Parse(string.Empty));
                        obj_da_Cost.InsCostingTempRptreclose(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nominatn, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, vouno, Convert.ToChar(voutype));
                    }
                    else
                    {
                        Fn_DNCNMBL4Reclose(jobno, trantype, vouno, voutype, i, obj_dt, int_bid, dtdate);
                    }
                }
            }

        }

        private void Fn_DNCNMBL4Reclose(int jobno, string trantype, int vouno, string voutype, int count, DataTable dt, int int_bid, DateTime Close_date)
        {
            double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
            //obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "V", int_bid, 0, "");
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            obj_dt = obj_da_Cost.GetBLRow(jobno, trantype, int_bid);
            if (obj_dt.Rows.Count > 0)
            {
                MBL_Amount = 0;
                MBL_Expense = 0;
                BL_Amount = 0;
                BL_Expense = 0;
                if (count < dt.Rows.Count - 1)
                {
                    if (dt.Rows[count]["blno"].ToString() != dt.Rows[count + 1]["blno"].ToString())
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }

                        else if (dt.Rows[count]["voutype"].ToString() == "I" || dt.Rows[i]["voutype"].ToString() == "B")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "P")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        if (dt.Rows[count]["voutype"].ToString() == "D")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "C")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }

                        else if (dt.Rows[count]["voutype"].ToString() == "I" || dt.Rows[i]["voutype"].ToString() == "B")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "P")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        if (dt.Rows[count]["voutype"].ToString() == "D")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "C")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    if (dt.Rows[count]["voutype"].ToString() == "V")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }
                    else if (dt.Rows[count]["voutype"].ToString() == "E")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }

                    else if (dt.Rows[count]["voutype"].ToString() == "I" || dt.Rows[i]["voutype"].ToString() == "B")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }
                    else if (dt.Rows[count]["voutype"].ToString() == "P")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }
                    if (dt.Rows[count]["voutype"].ToString() == "D")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }
                    else if (dt.Rows[count]["voutype"].ToString() == "C")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }

                }
                if (trantype == "FE" || trantype == "FI")
                {
                    JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                    obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                    if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
                    {
                        Total_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["cbmtotal"].ToString());
                        Total_Tues = Convert.ToDouble(obj_dttemp.Rows[0]["Tuestotal"].ToString());
                    }
                }
                else if (trantype == "AE" || trantype == "AI")
                {
                    //  JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                    JobType = 0;
                    obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                    if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
                    {
                        JobChargeWT = Convert.ToDouble(obj_dttemp.Rows[0][0].ToString());

                    }
                }
                for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                {

                    if (trantype == "FE" || trantype == "FI")
                    {
                        BL_Tues = Convert.ToInt32(obj_dt.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dt.Rows[j]["cont40"].ToString()) * 2);
                        BL_CBM = Convert.ToDouble(obj_dt.Rows[j]["cbm"].ToString());
                        if (MBL_Amount != 0)
                        {
                            if (JobType == 3)
                            {
                                BL_Amount = ((MBL_Amount / Total_Tues) * BL_Tues);
                            }
                            else
                            {
                                BL_Amount = ((MBL_Amount / Total_CBM) * BL_CBM);

                                //amont = costtempobj.CostPATemplv(int_bid, trantype, dt.Rows[count][1].ToString(), Total_CBM, BL_CBM, 0, Convert.ToInt32(obj_dt.Rows[j][0].ToString()), "DN");
                                //BL_Amount = BL_Amount + amont;
                            }
                        }

                        if (MBL_Expense != 0)
                        {
                            if (JobType == 3)
                            {
                                BL_Expense = ((MBL_Expense / Total_Tues) * BL_Tues);
                            }
                            else
                            {
                                if (BL_CBM == 0)
                                {
                                    BL_Expense = 0;
                                }
                                else if (Total_CBM == 0)
                                {
                                    BL_Expense = 0;
                                }
                                else
                                {
                                    BL_Expense = ((MBL_Expense / Total_CBM) * BL_CBM);
                                    //amont = costtempobj.CostPATemplv(int_bid, trantype, dt.Rows[count][1].ToString(), Total_CBM, BL_CBM, 0, Convert.ToInt32(obj_dt.Rows[j][0].ToString()), "CN");
                                    //BL_Expense = BL_Expense + amont;
                                }
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        BL_ChargeWT = Convert.ToDouble(obj_dt.Rows[j]["chargewt"].ToString());

                        if (MBL_Amount != 0)
                        {
                            BL_Amount = ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
                            //amont = costtempobj.CostPATemplv(int_bid, trantype, dt.Rows[count][1].ToString(), JobChargeWT, BL_ChargeWT, 0, Convert.ToInt32(obj_dt.Rows[j][0].ToString()), "DN");
                            //BL_Amount = BL_Amount + amont;
                        }
                        if (MBL_Expense != 0)
                        {
                            BL_Expense = ((MBL_Expense / JobChargeWT) * BL_ChargeWT);
                            //amont = costtempobj.CostPATemplv(int_bid, trantype, dt.Rows[count][1].ToString(), JobChargeWT, BL_ChargeWT, 0, Convert.ToInt32(obj_dt.Rows[j][0].ToString()), "CN");
                            //BL_Expense = BL_Expense + amont;
                        }
                    }

                    if (trantype == "FE" || trantype == "FI")
                    {
                        if (obj_dt.Rows[j][2].ToString().Length > 0 && obj_dt.Rows[j][3].ToString().Length > 0)
                        {
                            int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                            int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        int_Cont20 = 0;
                        int_Cont40 = 0;
                    }
                    int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                    char Nomination = ' ';
                    string blno;
                    double volume = 0;
                    int_job = Convert.ToInt32(obj_dt.Rows[j][0].ToString());
                    blno = obj_dt.Rows[j][1].ToString();
                    int_shipper = Convert.ToInt32(obj_dt.Rows[j][6].ToString());
                    int_consignee = Convert.ToInt32(obj_dt.Rows[j][7].ToString());
                    int_notify = Convert.ToInt32(obj_dt.Rows[j][8].ToString());
                    int_agent = Convert.ToInt32(obj_dt.Rows[j][9].ToString());
                    int_pol = Convert.ToInt32(obj_dt.Rows[j][10].ToString());
                    int_pod = Convert.ToInt32(obj_dt.Rows[j][11].ToString());
                    int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                    //     Nomination = char.Parse(obj_dt.Rows[j][4].ToString());
                    if (!string.IsNullOrEmpty(obj_dt.Rows[j][4].ToString()))
                    {
                        if (obj_dt.Rows[j][4].ToString().Length > 0)
                        {
                            Nomination = char.Parse(obj_dt.Rows[j][4].ToString());
                        }

                    }
                    else
                    {
                        Nomination = ' ';
                    }
                    volume = Convert.ToDouble(obj_dt.Rows[j][5].ToString());
                    if (trantype == "FE" || trantype == "FI")
                    {
                        if (JobType == 3)
                        {
                            volume = 0;
                            //int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                            //int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                        }
                        else
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                        }
                    }
                    obj_da_Cost.InsCostingTempRptreclose(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, vouno, char.Parse(voutype));

                }
            }
        }

        public void Fn_DNCNBLBT(int jobno, string trantype, string type, DateTime CDate, int vouno, string voutype)
        {
            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            DateTime dtdate = CDate;
            //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();

            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            if (type == "Closed")
            {
                //obj_dt = obj_da_Cost.GetDNCN4MISFromJobNo(jobno, int_bid, trantype); 
                obj_dt = obj_da_Cost.GetDNCN4MISFromVounonew4Reclose(jobno, int_bid, trantype, vouno, voutype);
            }
            else if (type == "Approve")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromVounonew(jobno, int_bid, trantype, vouno, voutype);
            }
            int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
            char Nomination;
            string blno;
            double volume = 0;
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    blno = obj_dt.Rows[i]["blno"].ToString();
                    int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                    if (trantype != "CH" && trantype != "BT")
                    {
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
                    }
                    else
                    {
                        MLO = 0;
                    }
                    if (type == "Closed")
                    {
                        //dtdate = CDate;
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                        vouno = Convert.ToInt32(obj_dt.Rows[i]["vouno"].ToString());
                        voutype = obj_dt.Rows[i]["voutype"].ToString();
                    }
                    else if (type == "Approve")
                    {
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                    }
                    obj_dttemp = obj_da_Cost.GetBLRowBL(blno, trantype, int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        BL_Amount = 0;
                        BL_Expense = 0;

                        if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                        {
                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            }
                        }
                        else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                        {
                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            }
                        }

                        else if (obj_dt.Rows[i]["voutype"].ToString() == "I" || obj_dt.Rows[i]["voutype"].ToString() == "B")
                        {
                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            }
                        }
                        else if (obj_dt.Rows[i]["voutype"].ToString() == "P")
                        {
                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            }
                        }

                        int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
                        blno = obj_dttemp.Rows[0][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());

                        if (trantype != "CH" && trantype != "BT")
                        {
                            int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        }
                        Nomination = char.Parse(" ");
                        volume = 0;

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
                                JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI" || trantype == "CH" || trantype == "BT")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                            JobType = 0;
                        }
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;

                        //obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, 0, char.Parse(string.Empty));
                        obj_da_Cost.InsCostingTempRptreclose(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, vouno, Convert.ToChar(voutype));
                    }
                    //else
                    //{
                    //    Fn_DNCNMBL4Reclose(jobno, trantype, vouno, voutype, i, obj_dt, int_bid, dtdate);
                    //}
                }
            }
        }

        protected void Grdcost_PreRender(object sender, EventArgs e)
        {
            if (Grdcost.Rows.Count > 0)
            {
                Grdcost.UseAccessibleHeader = true;
                Grdcost.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
    }
}