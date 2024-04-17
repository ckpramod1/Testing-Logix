using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.ForwardExports
{
    public partial class Costing : System.Web.UI.Page
    {
        DataAccess.UserPermission userperobj = new DataAccess.UserPermission();
        DataAccess.CostingDetails da_obj_Costing = new DataAccess.CostingDetails();
        DataAccess.CloseJobs da_obj_Closejob = new DataAccess.CloseJobs();
        DataAccess.Accounts.Invoice da_obj_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.OSDNCN da_obj_InvOSDC = new DataAccess.Accounts.OSDNCN();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();
        DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.CostingTemp da_obj_CostTemp = new DataAccess.CostingTemp();
        DataAccess.CostingTemp obj_Costing = new DataAccess.CostingTemp();
        DataAccess.Accounts.CostingDt obj_costingdt = new DataAccess.Accounts.CostingDt();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingImports.PreAlert obj_da_Prealert = new DataAccess.ForwardingImports.PreAlert();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.ChangeJob.ChangeJob obj_da_changejob = new DataAccess.ChangeJob.ChangeJob();
        DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
        DataAccess.UserPermission obj_da_user = new DataAccess.UserPermission();
        int int_bid, int_did, int_jobno = 0;
        string trantype;
        string str_Uiid = "", str_FornName;
        DataTable dt_MenuRights = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                userperobj.GetDataBase(Ccode);
                da_obj_Costing.GetDataBase(Ccode);
                da_obj_Closejob.GetDataBase(Ccode);
                da_obj_Invoice.GetDataBase(Ccode);
                da_obj_InvOSDC.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                DAdvise.GetDataBase(Ccode);


                da_obj_OSDNCN.GetDataBase(Ccode);
                da_obj_Costingdt.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                Appobj.GetDataBase(Ccode);
                da_obj_CostTemp.GetDataBase(Ccode);


                obj_Costing.GetDataBase(Ccode);
                obj_costingdt.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_FEBL.GetDataBase(Ccode);
                obj_da_Prealert.GetDataBase(Ccode);
                obj_da_log.GetDataBase(Ccode);


                obj_da_changejob.GetDataBase(Ccode);
                obj_da_Emp.GetDataBase(Ccode);
                obj_da_user.GetDataBase(Ccode);
                



            }

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
            //int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            //trantype = Session["StrTranType"].ToString();
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);
            txt_job.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
            
            if (Request.QueryString.ToString().Contains("type"))
            {
                lbl_Header.Text = Request.QueryString["type"].ToString();
                lblcrum.Visible = true;
            }

            if (Request.QueryString.ToString().Contains("trantype"))
            {
                trantype = Request.QueryString["trantype"].ToString();
             
               
            }
            

            if (Request.QueryString.ToString().Contains("type"))
            {
                string str_FornName = "", str_Uiid = "";
                str_FornName = Request.QueryString["type"].ToString();
                //str_Uiid = Request.QueryString["UIID"].ToString();
                //Utility.Fn_CheckUserRights(str_Uiid, null, btn_print);
            }




            if( ddl_product.Text!="" && ddl_product.Text!="0")
            {
                if (ddl_product.Text == "Ocean Exports")
                {
                    Session["StrTranType"] = "FE";
                    //StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Ocean Imports")
                {
                    Session["StrTranType"] = "FI";
                    // StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Air Exports")
                {
                    Session["StrTranType"] = "AE";
                    // StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Air Imports")
                {
                    Session["StrTranType"] = "AI";
                    // StrTranType = Session["StrTranType"].ToString();
                }
               /* else if (ddl_product.Text == "CHA")
                {
                    Session["StrTranType"] = "CH";
                    // StrTranType = Session["StrTranType"].ToString();
                }*/
                else if (ddl_product.Text == "Bonded Trucking")
                {
                    Session["StrTranType"] = "BT";
                    // StrTranType = Session["StrTranType"].ToString();
                }
                 if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                    {
                        //lbl_vsl.Text = "Vessel";
                        //txt_date.Attributes.Add("placeholder", "Vessel");
                        //txt_date.Attributes.Add("placeholder", "DATE");
                        lbl_date.Text = "Date";
                        txt_date.ToolTip = "DATE";

                        //txt_vsl.Attributes.Add("placeholder", "Vessel");
                        lbl_vsl.Text = "Vessel";
                        txt_vsl.ToolTip = "Vessel";
                        //txt_agent.Attributes.Add("placeholder", "Agent");
                        lbl_agent.Text = "Agent";
                        txt_agent.ToolTip = "Agent";
                        //txt_mlo.Attributes.Add("placeholder", "MLO");
                        lbl_mlo.Text = "MLO";
                        txt_mlo.ToolTip = "MLO";
                        //txt_pol.Attributes.Add("placeholder", "POL");
                        lbl_pol.Text = "POL";                    
                        txt_pol.ToolTip = "POL";
                        //txt_pod.Attributes.Add("placeholder", "POD");
                        lbl_pod.Text = "POD";                 
                        txt_pod.ToolTip = "POD";
                        // lbl_date.Visible = false;
                        //txt_date.Visible = false;
                        // lbl_mbl.Visible = true;
                        //txt_mbl.Attributes.Add("placeholder", "MBL");
                        txt_mbl.ToolTip = "MBL";

                    }
                    else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                    {
                        //txt_vsl.Attributes.Add("placeholder", "Flight");
                        lbl_vsl.Text = "Flight";
                        txt_vsl.ToolTip = "Flight";


                        //txt_vsl.Attributes.Add("placeholder", "Vessel");
                        lbl_vsl.Text = "Vessel";
                        txt_vsl.ToolTip = "Vessel";
                        //txt_agent.Attributes.Add("placeholder", "Agent");
                        lbl_agent.Text = "Agent";
                        txt_agent.ToolTip = "Agent";
                        //txt_mlo.Attributes.Add("placeholder", "MLO");
                        lbl_mlo.Text = "MLO";
                        txt_mlo.ToolTip = "MLO";
                        //txt_pol.Attributes.Add("placeholder", "POL");
                        lbl_pol.Text = "POL";                    
                        txt_pol.ToolTip = "POL";
                        //txt_pod.Attributes.Add("placeholder", "POD");
                        lbl_pod.Text = "POD";                 
                        txt_pod.ToolTip = "POD";
                        // lbl_date.Visible = false;
                        //txt_date.Visible = false;
                        // lbl_mbl.Visible = true;
                        //txt_mbl.Attributes.Add("placeholder", "MBL");
                        lbl_mbl.Text = "MBL";
                        txt_mbl.ToolTip = "MBL";
                    }
                    else
                    {
                        txt_job.ReadOnly = true;
                        //txt_vsl.Attributes.Add("placeholder", "Truck #");
                        lbl_vsl.Text = "Truck #";
                        txt_vsl.ToolTip = "Truck NUMBER";
                        //txt_agent.Attributes.Add("placeholder", "From");
                        lbl_agent.Text = "From";
                        txt_agent.ToolTip = "From";
                        //txt_mlo.Attributes.Add("placeholder", "To");
                        lbl_mlo.Text = "To";
                        txt_mlo.ToolTip = "To";
                        //txt_pol.Attributes.Add("placeholder", "ETD");
                        lbl_pol.Text = "ETD";                    
                        txt_pol.ToolTip = "ETD";
                        //txt_pod.Attributes.Add("placeholder", "ETA");
                        lbl_pod.Text = "ETA";                 
                        txt_pod.ToolTip = "ETA";
                        // lbl_date.Visible = false;
                        txt_date.Visible = false;
                        lbl_date.Visible = false;
                        // lbl_mbl.Visible = true;
                        //txt_mbl.Attributes.Add("placeholder", "MBL");
                        lbl_mbl.Text = "MBL";
                        txt_mbl.ToolTip = "MBL";
                        txt_mbl.Visible = true;
                    }

                 /*if (Session["StrTranType"].ToString() == "FE")
                 {
                     lblHead1.Visible = true;
                     lblHead2.Visible = true;
                     headerlable1.InnerText = "OceanExports";
                     if (lbl_Header.Text == "Costing")
                     {
                         headerlabel2.InnerText = "Approval";
                     }
                     else if (lbl_Header.Text == "PreAlert")
                     {
                         headerlabel2.InnerText = "Customer Service";
                     }
                 }
                 else if (Session["StrTranType"].ToString() == "FI")
                 {
                     lblHead1.Visible = true;
                     lblHead2.Visible = true;
                     headerlable1.InnerText = "OceanImports";
                     if (lbl_Header.Text == "Costing")
                     {
                         headerlabel2.InnerText = "Approval";
                     }
                 }
                 else if (Session["StrTranType"].ToString() == "AE")
                 {
                     lblHead1.Visible = true;
                     lblHead2.Visible = true;
                     headerlable1.InnerText = "AirExports";
                     if (lbl_Header.Text == "Costing")
                     {
                         headerlabel2.InnerText = "Approval";
                     }
                 }
                 else if (Session["StrTranType"].ToString() == "AI")
                 {
                     lblHead1.Visible = true;
                     lblHead2.Visible = true;
                     headerlable1.InnerText = "AirImports";
                     if (lbl_Header.Text == "Costing")
                     {
                         headerlabel2.InnerText = "Approval";
                     }
                     else if (lbl_Header.Text == "Delivery Order")
                     {
                         headerlabel2.InnerText = "Customer Service";
                     }
                 }
                 else if (Session["StrTranType"].ToString() == "BT")
                 {
                     // lblHead1.Visible = true;                       
                     headerlable1.InnerText = "Bonded Trucking";
                     if (lbl_Header.Text == "Costing")
                     {
                         headerlabel2.InnerText = "Approval";
                     }
                 }*/


              /*   if (Session["StrTranType"].ToString() == "FE")
                 {
                     lblHead1.Visible = true;

                     headerlable1.InnerText = "OceanExports";

                 }
                 else if (Session["StrTranType"].ToString() == "FI")
                 {
                     lblHead1.Visible = true;

                     headerlable1.InnerText = "OceanImports";

                 }
                 else if (Session["StrTranType"].ToString() == "AE")
                 {
                     lblHead1.Visible = true;

                     headerlable1.InnerText = "AirExports";

                 }
                 else if (Session["StrTranType"].ToString() == "AI")
                 {
                     lblHead1.Visible = true;

                     headerlable1.InnerText = "AirImports";

                 }
                 else if (Session["StrTranType"].ToString() == "BT")
                 {
                     // lblHead1.Visible = true;                       
                     headerlable1.InnerText = "Bonded Trucking";

                 }*/
            }
            if (!IsPostBack)
            { 
                try
                {
                    if (Session["trantype_process"] != null)
                    {
                        lblHead1.Visible = false;
                        lblHead2.Visible = false;
                        dt_MenuRights = Session["trantype_process"] as DataTable;
                        ddl_product.Items.Add("");
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
                           /* else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
                            {
                                ddl_product.Items.Add("CHA");
                            }*/
                            //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
                            //{
                            //    ddl_product.Items.Add("Bonded Trucking");
                            //}
                        }
                        // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                    } else 
                    if (Session["StrTranType"] != null)
                    {
                        ddl_product.Items.Add("");
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                            //ddl_product.SelectedIndex = 1;
                            ddl_product.SelectedValue = "Ocean Exports";
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                            ddl_product.SelectedValue = "Ocean Imports";
                            //ddl_product.SelectedIndex = 1;
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                            ddl_product.SelectedValue = "Air Exports";
                            //ddl_product.SelectedIndex = 1;
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                            ddl_product.SelectedValue = "Air Imports";
                        }
                        else if (Session["StrTranType"].ToString() == "BT")
                        {
                            ddl_product.Items.Add("Bonded Trucking");
                            ddl_product.SelectedValue = "Bonded Trucking";
                        }
                        else if (Session["StrTranType"].ToString() == "CO")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                            ddl_product.Items.Add("Ocean Imports");
                            ddl_product.Items.Add("Air Exports");
                            ddl_product.Items.Add("Air Imports");
                            ddl_product.Items.Add("Bonded Trucking");
                            ddl_product.SelectedValue = "Ocean Exports";
                            ddl_product.SelectedValue = "Ocean Imports";
                            ddl_product.SelectedValue = "Air Exports";
                            ddl_product.SelectedValue = "Air Imports";
                            ddl_product.SelectedValue = "Bonded Trucking";
                            lnk_job.Enabled = false;
                            ddl_product.Visible = false;
                           
                        }


                     /*   else if (Session["StrTranType"].ToString() == "CH")
                        {
                            ddl_product.Items.Add("CHA");
                            ddl_product.SelectedValue = "CAH";
                        }*/
                        //ddl_product.SelectedIndex = 1;
                    }




                    if (Session["StrTranType"] != null)
                    {

                        if (Session["StrTranType"].ToString() == "BT")
                        {
                            lblHead2.Visible = true;
                            lblHead1.Visible = true;
                            headerlable1.InnerText = "Approval";
                            headerlabel2.InnerText = "Bonded Trucking";
                        }


                        if (Session["home"] != null)
                        {
                            if (Session["home"].ToString() == "CS")
                            {
                                lblHead2.Visible = true;
                                headerlabel2.InnerText = "Customer Support";
                                if (Session["StrTranType"].ToString() == "FE")
                                {
                                    lblHead1.Visible = true;

                                    headerlable1.InnerText = "OceanExports";

                                }
                                else if (Session["StrTranType"].ToString() == "FI")
                                {
                                    lblHead1.Visible = true;

                                    headerlable1.InnerText = "OceanImports";

                                }
                                else if (Session["StrTranType"].ToString() == "AE")
                                {
                                    lblHead1.Visible = true;

                                    headerlable1.InnerText = "AirExports";

                                }
                                else if (Session["StrTranType"].ToString() == "AI")
                                {
                                    lblHead1.Visible = true;

                                    headerlable1.InnerText = "AirImports";

                                }

                            }

                            if (Session["home"].ToString() == "OPS&DOC")
                            {
                                lblHead2.Visible = true;
                                headerlabel2.InnerText = "Ops & Docs";

                                if (Session["StrTranType"].ToString() == "FE")
                                {
                                    lblHead1.Visible = true;

                                    headerlable1.InnerText = "OceanExports";

                                }
                                else if (Session["StrTranType"].ToString() == "FI")
                                {
                                    lblHead1.Visible = true;

                                    headerlable1.InnerText = "OceanImports";

                                }
                                else if (Session["StrTranType"].ToString() == "AE")
                                {
                                    lblHead1.Visible = true;

                                    headerlable1.InnerText = "AirExports";

                                }
                                else if (Session["StrTranType"].ToString() == "AI")
                                {
                                    lblHead1.Visible = true;

                                    headerlable1.InnerText = "AirImports";

                                }

                            }
                        }


                    }
           

                   // txt_job.Focus();
                   
                    if (lbl_Header.Text == "Costing")
                    {
                        send_id.Visible = false;
                        btn_send.Visible = false;
                        rbtcosting.Visible = false;
                        btn_Export.Visible = true;
                    }
                    else
                    {
                        div_prealert.Visible = false;
                        // lbl_remark.Visible = false;
                        txt_remark.Visible = false;
                    }
                    Grdcost.DataSource = new DataTable();
                    Grdcost.DataBind();
                    if (Request.QueryString.ToString().Contains("jobno"))
                    {
                        lblcrum.Visible = false;

                        hid_int_bid.Value = Request.QueryString["branchid"].ToString();
                        txt_job.Text = Request.QueryString["jobno"].ToString();
                        txt_job_TextChanged(sender, e);
                          return;
                    }
                    if (Session["StrTranType"]!=null)
                    {
                        if (Session["StrTranType"].ToString() != "CO")
                        {
                            UserRights();
                        }
                    }
                   
                   // txt_job.Focus();
                   
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
            headerlabel.InnerText = lbl_Header.Text;
        }

        protected void UserRights()
        {
            try
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() != "CO")
                    {

                        str_Uiid = userperobj.Getuiid(Session["StrTranType"].ToString(), 11, lbl_Header.Text);
                    }
                    if (str_Uiid != "")
                    {
                        //str_Uiid = Request.QueryString["uiid"].ToString();
                        Utility.Fn_CheckUserRights(str_Uiid, null, null, null);
                    }
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        Boolean btn_delete;
                        //str_FornName = Request.QueryString["type"].ToString();
                        str_Uiid = Request.QueryString["uiid"].ToString();
                        Utility.Fn_CheckUserRights(str_Uiid, null, null, null);
                        //DataTable obj_Dtuser = new DataTable();
                        //obj_Dtuser = (DataTable)Session["dt_UserRights"];
                        //DataView obj_dtview = new DataView(obj_Dtuser);
                        //obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                        //obj_Dtuser = obj_dtview.ToTable();
                        //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


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
                if (txt_job.Text.Trim().Length > 0)
                {
                    int_jobno = int.Parse(txt_job.Text);
                    if (Session["LoginBranchid"]!=null)
                    {
                        if (Session["LoginBranchid"].ToString() == "40" || Session["LoginBranchid"].ToString() == "82")

                        {
                            if (hid_int_bid.Value != "")
                            {
                                int_bid = Convert.ToInt32(hid_int_bid.Value);
                            }
                            else
                            {
                                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                            }
                             
                        }
                        else
                        {

                            int_bid = int.Parse(Session["LoginBranchid"].ToString());
                        }
                    }
                   
                    DataTable obj_dt = new DataTable();
                
                    if(Session["StrTranType"]!=null)
                    {
                            
                         if (Session["StrTranType"].ToString() == "CO")
                          {
                           trantype = trantype.ToString();
                           }
                         else
                         {
                             trantype = Session["StrTranType"].ToString();
                         }
                    }
                    
                    string mlo;
                    //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                    if (trantype == "FE" || trantype == "FI")
                    {
                        obj_dt = da_obj_Costingdt.GetJobdtls(trantype, int_jobno, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_vsl.Text = obj_dt.Rows[0][0].ToString();
                            txt_mbl.Text = obj_dt.Rows[0][2].ToString();
                            txt_pol.Text = obj_dt.Rows[0][5].ToString();
                            txt_pod.Text = obj_dt.Rows[0][6].ToString();
                            txt_agent.Text = obj_dt.Rows[0][3].ToString();
                            txt_mlo.Text = Server.HtmlDecode(obj_dt.Rows[0][4].ToString());

                            if (string.IsNullOrEmpty(obj_dt.Rows[0]["jobcloseremarks"].ToString()) == false)
                            {
                                txt_remark.Text = obj_dt.Rows[0]["jobcloseremarks"].ToString();
                            }
                            else
                            {
                                txt_remark.Text = "";
                            }
                            hid_etd.Value = obj_dt.Rows[0]["etd"].ToString();
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        obj_dt = da_obj_Costingdt.GetJobdtls(trantype, int_jobno, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_vsl.Text = obj_dt.Rows[0][0].ToString();
                            txt_mbl.Text = obj_dt.Rows[0][1].ToString();
                            txt_pol.Text = obj_dt.Rows[0][5].ToString();
                            txt_pod.Text = obj_dt.Rows[0][6].ToString();
                            txt_agent.Text = obj_dt.Rows[0][3].ToString();
                            txt_mlo.Text = Server.HtmlDecode(obj_dt.Rows[0][4].ToString());

                            if (string.IsNullOrEmpty(obj_dt.Rows[0]["jobcloseremarks"].ToString()) == false)
                            {
                                txt_remark.Text = obj_dt.Rows[0]["jobcloseremarks"].ToString();
                            }
                            else
                            {
                                txt_remark.Text = "";
                            }
                            
                        }
                    }

                    obj_dt.Reset();
                    obj_dt = da_obj_Costing.CostingDetail4shipingdtlsLV(Convert.ToInt32(txt_job.Text), Session["StrTranType"].ToString(), int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        Grdcost.DataSource = obj_dt;
                        Grdcost.DataBind();

                    }
                }
                if (Session["StrTranType"].ToString() != "CO")
                {
                    UserRights();
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

        /*protected void Grdcost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
               // LinkButton Img_Select_btn = (LinkButton)Grdcost.SelectedRow.FindControl("Lnk_job");
                string Str_voucher, strtrantype, strblno, Str_CustType = ""; 
                int int_vouno, int_vouyear = 0;
                trantype = Session["StrTranType"].ToString();
                int index1 = Convert.ToInt32(Grdcost.SelectedRow.RowIndex);
                if (Grdcost.Rows.Count > 0)
                {
                    Str_voucher = Grdcost.SelectedRow.Cells[0].Text.ToString().Replace("&nbsp;", string.Empty);
                    if (Grdcost.SelectedRow.Cells[1].Text.Trim().ToString().Replace("&nbsp;", string.Empty).Length > 0)
                    {

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
                                //ScriptManager.RegisterStartupScript((Grdcost, , typeof(GridView), "CostingDetails", Str_Script, true);
                                ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
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
                              ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                // ScriptManager.RegisterStartupScript((Grdcost,typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "DN")
                            {
                                if (trantype == "FE")
                                {
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FEDNAgent.rpt";

                                    }
                                    else
                                    {
                                        Str_RptName = "FEDN.rpt";
                                    }
                                    
                                   // Str_RptName = "FEDN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container=";
                                }
                                else if (trantype == "FI")
                                {
                                    //Str_RptName = "FIDN.rpt";

                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FIDNAgent.rpt";

                                    }
                                    else
                                    {
                                        Str_RptName = "FIDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container="; 
                                }
                                else if (trantype == "AE")
                                {
                                   // Str_RptName = "AEDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AEDNAgent.rpt";

                                    }
                                    else
                                    {
                                        Str_RptName = "AEDN.rpt";
                                    }

                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear; 
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                   // Str_RptName = "AIDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AIDNAgent.rpt";

                                    }
                                    else
                                    {
                                        Str_RptName = "AIDN.rpt";
                                    }
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                               // ScriptManager.RegisterStartupScript((Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
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
                                 //   Str_RptName = "FECN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FECNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "FECN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                                    Str_SP = "Lcurr=INR~container=";
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
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear +"";
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
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear+"";
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    //Str_RptName = "AICN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AICNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AICN.rpt";
                                    }
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
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                  ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }
                            else if (Str_voucher == "CN-Ops")
                            {
                                if (trantype == "FE")
                                {
                                    Str_RptName = "FEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "FI")
                                {
                                    Str_RptName = "FIMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "AE")
                                {
                                    Str_RptName = "AEMPA.rpt";
                                    Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                    Str_RptName = "AIMPA.rpt";
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
                              //  ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                  ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
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
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container=";
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
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container=";
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

                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "AI")
                                {
                                  //  Str_RptName = "AIMDN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AIMDNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AIMDN.rpt";
                                    }

                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                else if (trantype == "CH")
                                {
                                    Str_RptName = "CHADN.rpt";
                                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR";
                                }
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                              //  ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                                 ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                                Session["str_sfs"] = Str_SF;
                                Session["str_sp"] = Str_SP;
                            }

                            else if (Str_voucher == "CN")
                            {
                                if (trantype == "FE")
                                {
                                   // Str_RptName = "FEMCN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "FEMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "FEMCN.rpt";
                                    }
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR~container=";
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
                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
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

                                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                                    Str_SP = "Lcurr=INR ";
                                }
                                else if (trantype == "AI")
                                {
                                   // Str_RptName = "AIMCN.rpt";
                                    if (Str_CustType == "P")
                                    {
                                        Str_RptName = "AIMCNAgent.rpt";
                                    }
                                    else
                                    {
                                        Str_RptName = "AIMCN.rpt";
                                    }
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
                                //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
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
                            Str_SF = "";
                            Str_SP = "";
                            if (trantype == "FE")
                            {

                                Str_RptName = "FEOSDN.rpt";
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
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
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
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
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
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
                                Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
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
                              //  ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", str_script1, true);
                               ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                            }
                        }
                        if (Str_voucher == "OSPI")
                        {
                            int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                            Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "C", int_bid);
                            string str_script1, str_script2;
                            Str_SF = "";
                            Str_SP = "";
                            if (trantype == "FE")
                            {

                                Str_RptName = "FEOSCN.rpt";
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
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
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
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
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
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
                                Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
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
                        }
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

        }*/


        //For GST
        protected void Grdcost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Str_CustType = "";

                DataTable dttp = new DataTable();
                DataTable dtp = new DataTable();

                //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                // LinkButton Img_Select_btn = (LinkButton)Grdcost.SelectedRow.FindControl("Lnk_job");
                DateTime get_date, GST_date;
                get_date = Convert.ToDateTime(Utility.fn_ConvertDate(Grdcost.SelectedRow.Cells[2].Text));
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                string Str_voucher, strtrantype, strblno="";
                int int_vouno, int_vouyear = 0;
                trantype = Session["StrTranType"].ToString();
                string HORM = "", bltype = "", header = "";
                DataTable DTRetve = new DataTable();
                string Vouch1 = "", Vouch2 = "";
                int Ref1 = 0, Ref2 = 0;
                double tot_amount = Convert.ToDouble(Grdcost.SelectedRow.Cells[6].Text);
                int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
                //DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
                DataTable dcon = Appobj.Checkcountry(int.Parse(Session["LoginBranchid"].ToString()));
                int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                if (Grdcost.Rows.Count > 0)
                {
                    Str_voucher = Grdcost.SelectedRow.Cells[0].Text.ToString().Replace("&nbsp;", string.Empty);
                    if (Grdcost.SelectedRow.Cells[1].Text.Trim().ToString().Replace("&nbsp;", string.Empty).Length > 0)
                    {
                        if (Grdcost.SelectedRow.Cells[1].Text !="")
                        {
                            Str_CustType = obj_da_Customer.GetCustomerType(int.Parse(Grdcost.SelectedRow.Cells[7].Text));
                        }
                        if (Str_CustType !="P")
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
                        else if (Str_voucher == "CN-Ops" ||Str_voucher =="Purchase Invoice")
                        {
                            str_vou = "PA";
                        }
                        else if (Str_voucher == "ProCN-Ops" || Str_voucher == "Pro Purchase Inv")
                        {
                            str_vou = "ProPA";
                        }
                        else if (Str_voucher == "Invoice" || Str_voucher == "Sales Invoice")
                        {
                            str_vou = "Invoice";
                        }
                        else if (Str_voucher == "Pro Sales Inv" || Str_voucher == "Pro Inv")
                        {
                            str_vou = "Pro Inv";
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
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

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
                                    if(con == 1102 || con == 102)
                                    {
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + "&voutype=7" + this.Page.ClientQueryString + "','','');";

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
                                    Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
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
                                        Str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

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
                                    Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
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
                                    Str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
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

                        //{
                        //    bltype = "M";
                        //    if (Str_voucher == "Invoice" || Str_voucher == "Sales Invoice")
                        //    {
                        //        header = "Invoice";
                        //        HORM = "M";
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
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        } //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    else if (Str_voucher == "CN-Ops" || Str_voucher == "Purchase Invoice")
                        //    {
                        //        header = "PA";
                        //        HORM = "M";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHAPA.rpt";
                        //            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "BT")
                        //        {
                        //            Str_RptName = "BTPA.rpt";
                        //            Str_SF = "{ACPAHead.trantype}=\"" + trantype + "\" and {ACPAHead.pano}=" + int_vouno + " and {ACPAHead.branchid}=" + int_bid + " and {ACPAHead.vouyear}=" + int_vouyear + "";
                        //            Str_SP = "Lcurr=INR";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }                              // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }
                        //    else if (Str_voucher == "DN")
                        //    {
                        //        header = "DN";
                        //        HORM = "M";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMDN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHADN.rpt";
                        //            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        }                              // ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }

                        //    else if (Str_voucher == "CN")
                        //    {
                        //        header = "CN";
                        //        HORM = "M";
                        //        if (trantype == "FE")
                        //        {
                        //            Str_RptName = "FEMCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
                        //        }
                        //        else if (trantype == "FI")
                        //        {
                        //            Str_RptName = "FIMCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "container="; ;
                        //        }
                        //        else if (trantype == "AE")
                        //        {
                        //            Str_RptName = "AEMCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
                        //        }
                        //        else if (trantype == "AI")
                        //        {
                        //            Str_RptName = "AIMCN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        else if (trantype == "CH")
                        //        {
                        //            Str_RptName = "CHACN.rpt";
                        //            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear;
                        //            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
                        //        }
                        //        if (get_date >= GST_date)
                        //        {
                        //            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                        //        }
                        //        else
                        //        {
                        //            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //        } //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
                        //        Session["str_sfs"] = Str_SF;
                        //        Session["str_sp"] = Str_SP;
                        //    }


                        //}
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


        //protected void Grdcost_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string type = "", header = "", bltype = ""; ;
        //    try
        //    {
        //        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        //        DateTime get_date, GST_date;
        //        int index1 = Convert.ToInt32(Grdcost.SelectedRow.RowIndex);

        //        get_date = Convert.ToDateTime(Utility.fn_ConvertDate(Grdcost.Rows[index1].Cells[2].Text));
        //        GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());

        //        // LinkButton Img_Select_btn = (LinkButton)Grdcost.SelectedRow.FindControl("Lnk_job");
        //        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();


        //        string Str_voucher, strtrantype, strblno = "", Str_CustType = "";
        //        int int_vouno, int_vouyear = 0;
        //        string tot_amount = Grdcost.SelectedRow.Cells[6].Text;
        //        if (Grdcost.Rows.Count > 0)
        //        {
        //            Str_voucher = Grdcost.Rows[index1].Cells[0].Text.ToString().Replace("&nbsp;", string.Empty);
        //            if (Grdcost.Rows[index1].Cells[1].Text.Trim().ToString().Replace("&nbsp;", string.Empty).Length > 0)
        //            {
        //                // string cutname = ((Label)Grdcost.Rows[index1].Cells[5].FindControl("cname")).Text;// Grdcost.Rows[index1].Cells[5].Text.Trim();
        //                hid_customerid.Value = Grdcost.Rows[index1].Cells[7].Text.ToString();
        //                if (hid_customerid.Value != "")
        //                {
        //                    Str_CustType = obj_da_Customer.GetCustomerType(int.Parse(hid_customerid.Value.ToString()));
        //                }
        //                int_vouno = Convert.ToInt32(Grdcost.SelectedRow.Cells[1].Text.ToString());

        //                if (Grdcost.SelectedDataKey.Values[0].ToString().Trim().Length > 0)
        //                {
        //                    int_vouyear = Convert.ToInt32(Grdcost.SelectedDataKey.Values[0].ToString());
        //                }
        //                /*  string str_vou = "";
        //                  if (Str_voucher == "CN")
        //                  {
        //                      str_vou = "CNHead";
        //                  }
        //                  else if (Str_voucher == "DN")
        //                  {
        //                      str_vou = "DNHead";
        //                  }
        //                  else if (Str_voucher == "CN-Ops")
        //                  {
        //                      str_vou = "PA";
        //                  }
        //                  else
        //                  {
        //                      str_vou = Str_voucher;
        //                  }
        //                  */


        //                string str_vou = "";
        //                if (Str_voucher == "CN")
        //                {
        //                    str_vou = "CNHead";
        //                }
        //                else if (Str_voucher == "Pro CN")
        //                {
        //                    str_vou = "Pro CN";
        //                }
        //                else if (Str_voucher == "DN")
        //                {
        //                    str_vou = "DNHead";
        //                }
        //                else if (Str_voucher == "Pro DN")
        //                {
        //                    str_vou = "Pro DN";
        //                }
        //                else if (Str_voucher == "CN-Ops")
        //                {
        //                    str_vou = "PA";
        //                }
        //                else if (Str_voucher == "ProCN-Ops")
        //                {
        //                    str_vou = "ProPA";
        //                }
        //                else
        //                {
        //                    str_vou = Str_voucher;
        //                }

        //                DataTable obj_dt = new DataTable();
        //                DataTable obj_dttemp = new DataTable();
        //                string Str_RptName, Str_SF, Str_SP, Str_Script, Str_curr, Str_SF1, Str_SP1, Str_RptName1;
        //                Str_RptName = "";
        //                Str_SF = "";
        //                Str_SP = "";
        //                Str_Script = "";
        //                Str_curr = "";
        //                Str_SF1 = "";
        //                Str_SP1 = "";
        //                Str_RptName1 = "";
        //                Session["str_sfs"] = ""; Session["str_sfs"] = ""; Session["str_sp"] = ""; Session["str_sp1"] = "";

        //                obj_dt = da_obj_Invoice.ShowIPHead(int_vouno, trantype, str_vou, int_vouyear, int_bid);
        //                if (obj_dt.Rows.Count > 0)
        //                {
        //                    strtrantype = obj_dt.Rows[0]["trantype"].ToString();
        //                    strblno = obj_dt.Rows[0]["blno"].ToString();
        //                    obj_dttemp = da_obj_Invoice.CheckHblno(strblno, strtrantype, int_bid);
        //                    bltype = "H";
        //                }
        //                else
        //                {
        //                    bltype = "M";
        //                }
        //                if (obj_dttemp.Rows.Count > 0)
        //                {


        //                    if (Str_voucher == "Invoice")
        //                    {
        //                        header = "Invoice";
        //                        if (trantype == "FE")
        //                        {
        //                            Str_RptName = "FEInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            Str_RptName = "FIInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            Str_RptName = "AEInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            Str_RptName = "AIInvoice.rpt";
        //                            //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                            //Str_SP = "Lcurr=INR";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;
        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;



        //                    }
        //                    else if (Str_voucher == "CN-Ops")
        //                    {
        //                        header = "PA";
        //                        if (trantype == "FE")
        //                        {
        //                            Str_RptName = "fepa.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            Str_RptName = "FIPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            //  Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
        //                            Str_SP = "";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            Str_RptName = "AEPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            Str_RptName = "AIPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHAPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                            //  Str_SP = "Lcurr=INR";
        //                        }
        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }
        //                    else if (Str_voucher == "DN")
        //                    {

        //                        header = "DN";
        //                        if (trantype == "FE")
        //                        {
        //                            //Str_RptName = "FEDN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "FEDNAgent.rpt";

        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "FEDN.rpt";
        //                            }
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "FIDNAgent.rpt";

        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "FIDN.rpt";
        //                            }
        //                            //  Str_RptName = "FIDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "AEDNAgent.rpt";

        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "AEDN.rpt";
        //                            }
        //                            //  Str_RptName = "AEDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "AIDNAgent.rpt";

        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "AIDN.rpt";
        //                            }
        //                            // Str_RptName = "AIDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {

        //                            Str_RptName = "CHADN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;


        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }

        //                    else if (Str_voucher == "CN")
        //                    {
        //                        header = "CN";
        //                        int int_custid = 0;
        //                        DataTable obj_dtcn = new DataTable();
        //                        obj_dtcn = da_obj_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouyear, int_bid);
        //                        if (obj_dtcn.Rows.Count > 0)
        //                        {
        //                            int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
        //                        }
        //                        if (trantype == "FE")
        //                        {
        //                            //Str_RptName = "FECN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "FECNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "FECN.rpt";
        //                            }
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            //Str_RptName = "FICN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "FICNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "FICN.rpt";
        //                            }
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "container=";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            //Str_RptName = "AECN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "AECNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "AECN.rpt";
        //                            }
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            // Str_RptName = "AICN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "AICNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "AICN.rpt";
        //                            }
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHACN.rpt";
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;

        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }

        //                    if (Str_voucher == "Pro Inv")
        //                    {
        //                        header = "Invoice";
        //                        type = "Profoma Invoice";
        //                        if (trantype == "FE")
        //                        {
        //                            Str_RptName = "FEProInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            Str_RptName = "FIProInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            Str_RptName = "AEProInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            Str_RptName = "AIProInvoice.rpt";
        //                            //Str_SF = "{InvoiceHead.trantype}=" + '"' + trantype + '"' + " and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHProInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;

        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }
        //                    if (Str_voucher == "ProCN-Ops")
        //                    {
        //                        header = "PA";
        //                        type = "Profoma Credit Note - Operations";
        //                        if (trantype == "FE")
        //                        {
        //                            Str_RptName = "FEProPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            Str_RptName = "FIProPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            Str_RptName = "AEProPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            Str_RptName = "AIProPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHAProPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;


        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                    }
        //                    if (Str_voucher == "Pro DN")
        //                    {
        //                        header = "DN";

        //                        if (trantype == "FE")
        //                        {
        //                            Str_RptName = "FEProDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            Str_RptName = "FIProDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            Str_RptName = "AEProDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            Str_RptName = "AIProDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHAProDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;

        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }
        //                    if (Str_voucher == "Pro CN")
        //                    {
        //                        header = "CN";
        //                        if (trantype == "FE")
        //                        {
        //                            Str_RptName = "FEProCN.rpt";
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            Str_RptName = "FIProCN.rpt";
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "container= ";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            Str_RptName = "AEProCN.rpt";
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            Str_RptName = "AIProCN.rpt";
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHAProCN.rpt";
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;


        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }


        //                }
        //                else
        //                {
        //                    if (Str_voucher == "Invoice")
        //                    {
        //                        header = "Invoice";
        //                        if (trantype == "FE")
        //                        {
        //                            Str_RptName = "FEMInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            Str_RptName = "FIMInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            Str_RptName = "AEMInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            Str_RptName = "AIMInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHInvoice.rpt";
        //                            Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.invoiceno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);                               
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;

        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }
        //                    else if (Str_voucher == "CN-Ops")
        //                    {
        //                        header = "PA";
        //                        if (trantype == "FE")
        //                        {
        //                            Str_RptName = "FEMPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            Str_RptName = "FIMPA.rpt";
        //                            //Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear+"";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            Str_RptName = "AEMPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            Str_RptName = "AIMPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHAPA.rpt";
        //                            Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.pano}=" + int_vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;

        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }
        //                    else if (Str_voucher == "DN")
        //                    {
        //                        header = "DN";
        //                        if (trantype == "FE")
        //                        {
        //                            // Str_RptName = "FEMDN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "FEMDNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "FEMDN.rpt";
        //                            }
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            //Str_RptName = "FIMDN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "FIMDNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "FIMDN.rpt";
        //                            }
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            // Str_RptName = "AEMDN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "AEMDNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "AEMDN.rpt";
        //                            }
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            // Str_RptName = "AIMDN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "AIMDNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "AIMDN.rpt";
        //                            }
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHADN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "FC")
        //                        {
        //                            Str_RptName = "FIMDN.rpt";
        //                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.dnno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + int_bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;

        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }

        //                    else if (Str_voucher == "CN")
        //                    {
        //                        header = "CN";
        //                        if (trantype == "FE")
        //                        {
        //                            //   Str_RptName = "FEMCN.rpt";

        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "FEMCNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "FEMCN.rpt";
        //                            }
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container=";
        //                        }
        //                        else if (trantype == "FI")
        //                        {
        //                            // Str_RptName = "FIMCN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "FIMCNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "FIMCN.rpt";
        //                            }
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "container="; ;
        //                        }
        //                        else if (trantype == "AE")
        //                        {
        //                            //  Str_RptName = "AEMCN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "AEMCNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "AEMCN.rpt";
        //                            }
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                        }
        //                        else if (trantype == "AI")
        //                        {
        //                            //Str_RptName = "AIMCN.rpt";
        //                            if (Str_CustType == "P")
        //                            {
        //                                Str_RptName = "AIMCNAgent.rpt";
        //                            }
        //                            else
        //                            {
        //                                Str_RptName = "AIMCN.rpt";
        //                            }
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_bid + " and {CNDetails.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        else if (trantype == "CH")
        //                        {
        //                            Str_RptName = "CHACN.rpt";
        //                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.cnno}=" + int_vouno + " and {CNHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                            Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                        }
        //                        //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        //Session["str_sfs"] = Str_SF;
        //                        //Session["str_sp"] = Str_SP;

        //                        if (get_date >= GST_date)
        //                        {
        //                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + tot_amount + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        else
        //                        {
        //                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        }
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;
        //                    }


        //                }
        //                if (Str_voucher == "OSSI")
        //                {
        //                    //DataTable obj_dtoscn = new DataTable();
        //                    //obj_dtoscn = da_obj_InvOSDC.RptOSDNCN(trantype, int_vouno, int_bid, "OSSI", int_vouyear);
        //                    int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
        //                    Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "D", int_bid);
        //                    string str_script1, str_script2;
        //                    if (trantype == "FE")
        //                    {

        //                        Str_RptName = "FEOSDN.rpt";
        //                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
        //                        Str_SP = "FCurr=" + Str_curr;
        //                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                        //Str_RptName1 = "SOA1.rpt";
        //                        //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
        //                        //Str_SP1 = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
        //                        //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
        //                        //Str_Script = str_script1 + ";" + str_script2;

        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
        //                        Session["str_sfs1"] = Str_SF1;
        //                        Session["str_sp1"] = Str_SP1;
        //                    }
        //                    else if (trantype == "FI")
        //                    {

        //                        Str_RptName = "FIOSDN.rpt";
        //                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
        //                        Str_SP = "FCurr=" + Str_curr;
        //                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                        //Str_RptName1 = "SOA1.rpt";
        //                        //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
        //                        //Str_SP1 = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
        //                        //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
        //                        //Str_Script = str_script1 + ";" + str_script2;
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
        //                        Session["str_sfs1"] = Str_SF1;
        //                        Session["str_sp1"] = Str_SP1;
        //                    }
        //                    else if (trantype == "AE")
        //                    {

        //                        Str_RptName = "AEOSDN.rpt";
        //                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
        //                        Str_SP = "FCurr=" + Str_curr;
        //                        str_script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        //ScriptManager.RegisterStartupScript(Img_Select_btn, typeof(ImageButton), "CostingDetails", Str_Script, true);
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                        //Str_RptName1 = "SOA1.rpt";
        //                        //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
        //                        //Str_SP1 = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
        //                        //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
        //                        //Str_Script = str_script1 + ";" + str_script2;
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", str_script1, true);
        //                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
        //                        Session["str_sfs1"] = Str_SF1;
        //                        Session["str_sp1"] = Str_SP1;
        //                    }
        //                    else
        //                    {

        //                        Str_RptName = "AIOSDN.rpt";
        //                        Str_SF = "{OSDN.trantype}=\"" + trantype + "\"  and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
        //                        Str_SP = "FCurr=" + Str_curr;
        //                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                        //Str_RptName1 = "SOA1.rpt";
        //                        //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
        //                        //Str_SP1 = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
        //                        //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
        //                        //Str_Script = str_script1 + ";" + str_script2;
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
        //                        Session["str_sfs1"] = Str_SF1;
        //                        Session["str_sp1"] = Str_SP1;
        //                    }
        //                }
        //                if (Str_voucher == "OSPI")
        //                {
        //                    int int_jobno = Convert.ToInt32(txt_job.Text.ToString());
        //                    Str_curr = da_obj_InvOSDC.GetCurrOSDCN(int_jobno, trantype, "C", int_bid);
        //                    string str_script1, str_script2;
        //                    if (trantype == "FE")
        //                    {

        //                        Str_RptName = "FEOSCN.rpt";
        //                        Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
        //                        Str_SP = "FCurr=" + Str_curr;
        //                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                        //Str_RptName1 = "SOA1.rpt";
        //                        //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
        //                        //Str_SP1 = "module=FE~jobno=" + int_jobno + "~drow=1~crow=1";
        //                        //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
        //                        //Str_Script = str_script1 + ";" + str_script2;
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
        //                        Session["str_sfs1"] = Str_SF1;
        //                        Session["str_sp1"] = Str_SP1;
        //                    }
        //                    else if (trantype == "FI")
        //                    {

        //                        Str_RptName = "FIOSCN.rpt";
        //                        Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
        //                        Str_SP = "FCurr=" + Str_curr;
        //                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                        //Str_RptName1 = "SOA1.rpt";
        //                        //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
        //                        //Str_SP1 = "module=FI~jobno=" + int_jobno + "~drow=1~crow=1";
        //                        //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
        //                        //Str_Script = str_script1 + ";" + str_script2;
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
        //                        Session["str_sfs1"] = Str_SF1;
        //                        Session["str_sp1"] = Str_SP1;
        //                    }
        //                    else if (trantype == "AE")
        //                    {

        //                        Str_RptName = "AEOSCN.rpt";
        //                        Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
        //                        Str_SP = "FCurr=" + Str_curr;
        //                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                        //Str_RptName1 = "SOA1.rpt";
        //                        //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
        //                        //Str_SP1 = "module=AE~jobno=" + int_jobno + "~drow=1~crow=1";
        //                        //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
        //                        //Str_Script = str_script1 + ";" + str_script2;
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
        //                        Session["str_sfs1"] = Str_SF1;
        //                        Session["str_sp1"] = Str_SP1;
        //                    }
        //                    else
        //                    {

        //                        Str_RptName = "AIOSCN.rpt";
        //                        Str_SF = "{OSCN.trantype}=\"" + trantype + "\"  and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
        //                        Str_SP = "FCurr=" + Str_curr;
        //                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

        //                        Session["str_sfs"] = Str_SF;
        //                        Session["str_sp"] = Str_SP;

        //                        //Str_RptName1 = "SOA1.rpt";
        //                        //Str_SF1 = "{MasterBranch.branchid}=" + int_bid;
        //                        //Str_SP1 = "module=AI~jobno=" + int_jobno + "~drow=1~crow=1";
        //                        //str_script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";

        //                        //  Str_Script = str_script1 + ";" + str_script2;
        //                        ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
        //                        Session["str_sfs1"] = Str_SF1;
        //                        Session["str_sp1"] = Str_SP1;
        //                    }
        //                }
        //                if (Str_voucher == "Pro Inv")
        //                {
        //                    if (trantype == "FE")
        //                    {
        //                        Str_RptName = "FEMProInvoice.rpt";
        //                        Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                    }
        //                    else if (trantype == "FI")
        //                    {
        //                        Str_RptName = "FIMProInvoice.rpt";
        //                        Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                    }
        //                    else if (trantype == "AE")
        //                    {
        //                        Str_RptName = "AEMProInvoice.rpt";
        //                        Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    else if (trantype == "AI")
        //                    {
        //                        Str_RptName = "AIMProInvoice.rpt";
        //                        Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                    }
        //                    else if (trantype == "CH")
        //                    {
        //                        Str_RptName = "CHProInvoice.rpt";
        //                        Str_SF = "{InvoiceHead.trantype}=\"" + trantype + "\" and {InvoiceHead.refno}=" + int_vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "";
        //                    }
        //                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                    Session["str_sfs"] = Str_SF;
        //                    Session["str_sp"] = Str_SP;
        //                }
        //                if (Str_voucher == "ProCN-Ops")
        //                {
        //                    if (trantype == "FE")
        //                    {
        //                        Str_RptName = "FEMProPA.rpt";
        //                        Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    else if (trantype == "FI")
        //                    {
        //                        Str_RptName = "FIMProPA.rpt";
        //                        Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                        //Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                    }
        //                    else if (trantype == "AE")
        //                    {
        //                        Str_RptName = "AEMProPA.rpt";
        //                        Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    else if (trantype == "AI")
        //                    {
        //                        Str_RptName = "AIMProPA.rpt";
        //                        Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    else if (trantype == "CH")
        //                    {
        //                        Str_RptName = "CHAProPA.rpt";
        //                        Str_SF = "{PAHead.trantype}=\"" + trantype + "\" and {PAHead.refno}=" + int_vouno + " and {PAHead.branchid}= " + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                    Session["str_sfs"] = Str_SF;
        //                    Session["str_sp"] = Str_SP;

        //                }
        //                if (Str_voucher == "Pro DN")
        //                {
        //                    if (trantype == "FE")
        //                    {
        //                        Str_RptName = "FEMProDN.rpt";
        //                        Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                    }
        //                    else if (trantype == "FI")
        //                    {
        //                        Str_RptName = "FIMProDNrpt";
        //                        Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                    }
        //                    else if (trantype == "AE")
        //                    {
        //                        Str_RptName = "AEMProDN.rpt";
        //                        Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    else if (trantype == "AI")
        //                    {
        //                        Str_RptName = "AIMProDN.rpt";
        //                        Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    else if (trantype == "CH")
        //                    {
        //                        Str_RptName = "CHAProDN.rpt";
        //                        Str_SF = "{DNHead.trantype}=\"" + trantype + "\" and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}= " + int_bid + " and {DNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                    Session["str_sfs"] = Str_SF;
        //                    Session["str_sp"] = Str_SP;
        //                }

        //                if (Str_voucher == "Pro CN")
        //                {
        //                    if (trantype == "FE")
        //                    {
        //                        Str_RptName = "FEMProCN.rpt";
        //                        Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                    }
        //                    else if (trantype == "FI")
        //                    {
        //                        Str_RptName = "FIMProCN.rpt";
        //                        Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + "~container= ";
        //                    }
        //                    else if (trantype == "AE")
        //                    {
        //                        Str_RptName = "AEMProCN.rpt";
        //                        Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    else if (trantype == "AI")
        //                    {
        //                        Str_RptName = "AIMProCN.rpt";
        //                        Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    else if (trantype == "CH")
        //                    {
        //                        Str_RptName = "CHAProCN.rpt";
        //                        Str_SF = "{CNHead.trantype}=\"" + trantype + "\" and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}= " + int_bid + " and {CNHead.vouyear}=" + int_vouyear + "";
        //                        Str_SP = "Lcurr=" + Session["Basecurr"].ToString() + " ";
        //                    }
        //                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ScriptManager.RegisterStartupScript(Grdcost, typeof(GridView), "CostingDetails", Str_Script, true);
        //                    Session["str_sfs"] = Str_SF;
        //                    Session["str_sp"] = Str_SP;
        //                }
        //            }
        //            else
        //            {
        //                return;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //}
        protected void btn_Export_Click(object sender, EventArgs e)
        {
            //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_Costingdt.GetCBM2040fromJob(Convert.ToInt32(txt_job.Text.Trim().ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
           // DataAccess.CostingTemp da_obj_CostTemp = new DataAccess.CostingTemp();
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

                //string Filename, strtemp;
                //Filename = Fn_GetTrantypename() + " Costing With Details for Job # :" + txt_job.Text;
                //strtemp = Utility.Fn_ExportExcel(Grdcost, "<tr><td><td><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr>");
                //strtemp.Remove(7);
                ////Grdcost.Columns.Remove(7);
                //Response.Clear();
                //Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                //Response.Buffer = true;
                //Response.Charset = "UTF-8";
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.Write(strtemp);
                //Response.End();

                string Filename, strtemp;
                string Filename1, Filename2;
                Filename = Fn_GetTrantypename() + " Costing With Details for Job # :" + txt_job.Text;
                Filename1 = Fn_GetTrantypename() + " Costing With Voucherwise Details for Job # :" + txt_job.Text;
                Filename2 = Fn_GetTrantypename() + " Costing With Chargerwise Details for Job # :" + txt_job.Text;
                Response.Clear();
                Grdcost.Columns[7].Visible = false;
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

            }


        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                 
                JobInput.Text = "";
                txt_job.Text = "";
                txt_agent.Text = "";
                txt_date.Text = "";
                txt_mbl.Text = "";
                txt_mlo.Text = "";
                txt_pod.Text = "";
                txt_pol.Text = "";
                txt_vsl.Text = "";
                txt_remark.Text = "";
                txt_job.Focus();
                Grdcost.DataSource = Utility.Fn_GetEmptyDataTable();
                Grdcost.DataBind();
                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                UserRights();
                txt_job.Focus();
                txt_job.Enabled = true;
               // ddl_product.SelectedValue = "0";
            }
            else 
            {
               
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "MIS")
                    {
                        Response.Redirect("../Home/MISAndApproval.aspx");
                    }

                    else if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                Response.Redirect("../Home/OECSHome.aspx");
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                Response.Redirect("../Home/OICSHome.aspx");
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                Response.Redirect("../Home/AECSHome.aspx");
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
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
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            }
                            if (Session["StrTranType"].ToString() == "FI")
                            {
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            }
                            if (Session["StrTranType"].ToString() == "AE")
                            {
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            }
                            if (Session["StrTranType"].ToString() == "AI")
                            {
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            }
                        }



                    }

                    else if (Session["home"].ToString() == "MIS")
                    {
                        Response.Redirect("../Home/MISAndApproval.aspx");
                    }

                }
                else
                {
                   this.Response.End();
                    //if (Session["StrTranType"] != null)
                    //{
                    //    if (Session["StrTranType"].ToString() == "BT")
                    //    {
                    //        Response.Redirect("../Home/BTHome.aspx");
                    //    }
                    //}
                }


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

            }
        }

        protected void lnk_job_Click(object sender, EventArgs e)
        {
            Grd_AE.Visible = false;
            Grd_BT.Visible = false;
            Grd_FE.Visible = false;
            
            DataTable obj_dt = new DataTable();

           // DataAccess.Accounts.CostingDt obj_costingdt = new DataAccess.Accounts.CostingDt();
            try
            {
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
                    ViewState["bind"] = obj_dt;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "CostingDetails", "alertify.alert('Job Not Available');", true);
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

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
                txt_job.Enabled = false;

                int_jobno = int.Parse(txt_job.Text);
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                DataTable obj_dt = new DataTable();
                trantype = Session["StrTranType"].ToString();
                //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                obj_dt = da_obj_Costingdt.GetJobdtls(trantype, int_jobno, int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    hid_etd.Value = obj_dt.Rows[0]["etd"].ToString();
                }
                Grd_FE.Visible = false; 
                UserRights();
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

        protected void Grd_AE_SelectedIndexChanged(object sender, EventArgs e)
        {
            //popup_Grd.Hide();
            try
            {
                this.popup_Grd.Hide();
                txt_job.Text = ((Label)Grd_AE.SelectedRow.Cells[0].FindControl("Job")).Text;
                txt_vsl.Text = Grd_AE.SelectedRow.Cells[1].Text.ToString();
                txt_mbl.Text = Grd_AE.SelectedRow.Cells[2].Text.ToString();
                txt_date.Text= Grd_AE.SelectedRow.Cells[3].Text.ToString();
                txt_agent.Text = Server.HtmlDecode(((Label)Grd_AE.SelectedRow.Cells[4].FindControl("Agent")).Text);
                txt_mlo.Text = Server.HtmlDecode(((Label)Grd_AE.SelectedRow.Cells[5].FindControl("airline")).Text);
                txt_pol.Text = Grd_AE.SelectedRow.Cells[6].Text.ToString();
                txt_pod.Text = Grd_AE.SelectedRow.Cells[7].Text.ToString();
                Fn_LoadGrid();
                txt_job.Enabled = false;
                Grd_AE.Visible = false;
                UserRights();
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
                txt_job.Text = Grd_BT.SelectedRow.Cells[0].Text.ToString();
                txt_vsl.Text = Grd_BT.SelectedRow.Cells[1].Text.ToString();
                txt_agent.Text = Grd_BT.SelectedRow.Cells[2].Text.ToString();
                txt_mlo.Text = Server.HtmlDecode(Grd_BT.SelectedRow.Cells[3].Text.ToString());
                txt_pol.Text = Grd_BT.SelectedRow.Cells[4].Text.ToString();
                txt_pod.Text = Grd_BT.SelectedRow.Cells[5].Text.ToString();
                Fn_LoadGrid();
                txt_job.Enabled = false;
                Grd_BT.Visible = false;
                UserRights();
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

        protected void btn_print_Click(object sender, EventArgs e)
        {
            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "", str_sfrpt = "", sp_rep="";
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
                    if (lbl_Header.Text == "AI Delivery Order")
                    {

                        str_RptName = "AIDeliveryorder.rpt";
                        str_sf = "{AIJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {AIJobInfo.jobno}=" + txt_job.Text;
                        str_sp = "branchname=" + Session["LoginBranchName"].ToString();
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Costing", str_Script, true);
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        return;
                    }
                    //DataAccess.Accounts.CostingDt da_obj_Costingdt = new DataAccess.Accounts.CostingDt();
                    if (lbl_Header.Text.ToString() != "PreAlert")
                    {
                        double int_Cbm = 0, int_Chargewt = 0;
                            int int_Cont20 = 0, int_Cont40 = 0,  int_Pkg = 0;

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
                        for (int i = 1; i <=8; i++)
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
                                     if(i==1||i==3||i==5||i==8)
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
                            str_sp = "trantype=" + Session["StrTranType"].ToString() + "~mlo=" + txt_mlo.Text + "~agent=" + txt_agent.Text+ "~cbm=" + string.Format("{0:0.000}", int_Cbm.ToString()) + "~cont20=" + string.Format("{0:0.000}", int_Chargewt.ToString()) + "~cont40=" + int_Cont40 + "~jobopen=" + str_jobdate + "~jobclose=" + str_closedate + "~vsl=" + txt_vsl.Text + "~jobcloserks=" + txt_remark.Text + "~AgentBL=" + str_AgentBLcount + "~OurBL=" + str_OurBLCount;
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
                    else
                    {
                        //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                        //DataAccess.ForwardingImports.PreAlert obj_da_Prealert = new DataAccess.ForwardingImports.PreAlert();

                        obj_dt = obj_da_FEBL.ShowFEInfo(Convert.ToInt32(txt_job.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        double cbm = double.Parse(obj_dt.Compute("sum(volume)", "").ToString());
                        obj_da_Prealert.UpdPreAlert(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text), "FE", Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (rbtcosting.Items[0].Selected == true)
                        {
                            str_RptName = "FEPreAlertWITHBL.rpt";
                            str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {FEJobInfo.jobno}=" + txt_job.Text;
                            str_sp = "noofhbl=" + obj_dt.Rows.Count.ToString() + "~totalcbm=" + cbm;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Costing", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (rbtcosting.Items[1].Selected == true)
                        {
                            str_RptName = "FEPreAlertWITHOUTBL.rpt";
                            str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {FEJobInfo.jobno}=" + txt_job.Text;
                            str_sp = "";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Costing", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 112, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_job.Text);
                    }
                } UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        private string Fn_SendPrealert()
        {
            string str_temp = "";
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();

           // DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
         
                obj_dt = obj_da_log.GetCompanyNameAdd(int.Parse(Session["LoginBranchid"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    str_temp = str_temp + "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + obj_dt.Rows[0].ItemArray[0].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + obj_dt.Rows[0].ItemArray[1].ToString() + " <br> Phone : " + obj_dt.Rows[0].ItemArray[2].ToString() + " Fax : " + obj_dt.Rows[0].ItemArray[3].ToString() + "</Font></center><HR width=100%></body>";
                }
                str_temp = str_temp + "<table width=100%><tr><td align=left>     Our Job Ref #: " + txt_job.Text + "</td></tr>";
                str_temp = str_temp + "<tr><td align=left>           Vessel : " + txt_vsl.Text + "</td></tr>";
                str_temp = str_temp + "<tr><td align=left>  Port Of Loading : " + txt_pol.Text + "</td><td align=right>E T D : " + hid_etd.Value.ToString() + "</td></tr>";
                str_temp = str_temp + "<tr><td align=left>Port Of Discharge : " + txt_pod.Text + "</td><td align=right>E T A : " + txt_date.Text + "</td></tr></table><br><HR width=100%><br>";

                //DataAccess.ChangeJob.ChangeJob obj_da_changejob = new DataAccess.ChangeJob.ChangeJob();
                //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                obj_dt = obj_da_changejob.GetBLDetails(int.Parse(txt_job.Text), "FE", int.Parse(Session["LoginBranchid"].ToString()));
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    obj_dttemp = obj_da_FEBL.GetBLDetails(obj_dt.Rows[i]["blno"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginBranchid"].ToString()));
                    for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                    {
                        str_temp = str_temp + "<table width=100%><tr><td align=left>             BL # : " + obj_dttemp.Rows[j]["blno"].ToString() + "</td></tr>";
                        str_temp = str_temp + "<tr><td align=left>          Shipper : " + obj_dttemp.Rows[j]["sadd"].ToString() + "</td></tr>";
                        str_temp = str_temp + "<tr><td align=left>        Consignee : " + obj_dttemp.Rows[j]["cadd"].ToString() + "</td></tr>";
                        str_temp = str_temp + "<tr><td align=left>     Notify Party : " + obj_dttemp.Rows[j]["nadd"].ToString() + "</td></tr>";
                        str_temp = str_temp + "<tr><td align=left>  Marks + Numbers : " + obj_dttemp.Rows[j]["marks"].ToString() + "</td></tr>";
                        str_temp = str_temp + "<tr><td align=left>       Description: " + obj_dttemp.Rows[j]["descn"].ToString() + "</td></tr>";
                        str_temp = str_temp + "<tr><td align=left>  Place of Receipt: " + obj_dttemp.Rows[j]["por"].ToString() + "</td><td align=center>Port of Loading : " + obj_dttemp.Rows[j]["pol"].ToString() + "</td></tr>";
                        str_temp = str_temp + "<tr><td align=left>Place of Discharge: " + obj_dttemp.Rows[j]["pod"].ToString() + "</td><td align=center>Place of Delivery : " + obj_dttemp.Rows[j]["fd"].ToString() + "</td></tr>";
                        str_temp = str_temp + "<tr><td align=left>           package: " + obj_dttemp.Rows[j]["noofpkgs"].ToString() + " " + obj_dttemp.Rows[j]["units"].ToString() + "</td><td align=Center>Volume : " + obj_dttemp.Rows[j]["cbm"].ToString() + " M3" + "</td></td><td align=center>    Gross Weight : " + obj_dttemp.Rows[j]["grweight"].ToString() + " Kgs" + "</td></tr></table><br><HR width=100%><br><br>";
                    }
                }
                str_temp = str_temp + "</table>";
                str_temp = str_temp + "<table width=100% text=black><tr><td align=left>Best Regards </td></tr></table><br><br>";
                str_temp = str_temp + "<table width=100% text=black><tr><td align=left>" + Session["LoginEmpName"].ToString() + " </td></tr></table></body></html>";
                return str_temp;
           

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                return;
            }
                if (txt_job.Text.Trim().Length > 0)
                {
                    DataTable obj_dt = new DataTable();
                    string str_Empmail = "";
                    //DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                    //DataAccess.UserPermission obj_da_user = new DataAccess.UserPermission();

                    obj_dt = obj_da_user.GetMLEmpid(obj_da_user.GetMLUiid("FI", "D.O.Issue"), int_bid);
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        str_Empmail = str_Empmail + obj_da_Emp.GetMailAdd(int.Parse(obj_dt.Rows[i].ItemArray[0].ToString())) + ";";
                    }
                    if (str_Empmail.Trim().Length > 0)
                    {
                        string Str_Temp = Fn_SendPrealert();
                        str_Empmail = str_Empmail.Substring(0, str_Empmail.Length - 1);
                        Utility.SendMail(Session["usermailid"].ToString(), str_Empmail, lbl_Header.Text + " Job # : " + txt_job.Text, Str_Temp, "", Session["usermailpwd"].ToString());
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 201, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "/Job #: " + txt_job.Text + "/ Send");
                    }
                }

                UserRights();

        }

        protected void txt_mbl_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Grd_FE_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_FE, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_AE_RowDataBound(object sender, GridViewRowEventArgs e)
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

                Label lblAgent = (Label)e.Row.FindControl("Agent");
                string tooltip2 = lblAgent.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip2);
                Label airline = (Label)e.Row.FindControl("airline");
                string tooltip4 = airline.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip4);
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_AE, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_BT_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void Grd_FE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Grd_FE.PageIndex = e.NewPageIndex;
            //this.popup_Grd.Show();
            //Grd_FE.DataSource = (DataTable)ViewState["bind"];
            //Grd_FE.DataBind();
            //bind();
            //pln_popup.Visible = true;

            Grd_FE.PageIndex = e.NewPageIndex;
            this.popup_Grd.Show();
            Grd_FE.Visible = true;
            Grd_FE.DataSource = (DataTable)ViewState["bind"];
            Grd_FE.DataBind();
        }

      /*  public void bind()
        {
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
                ViewState["bind"] = obj_dt;
            }
        }
        */
        protected void Grd_AE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            Grd_AE.PageIndex = e.NewPageIndex;
            this.popup_Grd.Show();
            Grd_AE.Visible = true;
            Grd_AE.DataSource =(DataTable)ViewState["bind"];
            Grd_AE.DataBind();
            //bind();
        }

        protected void Grd_BT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            Grd_BT.PageIndex = e.NewPageIndex;
            this.popup_Grd.Show();
            Grd_BT.Visible = true;        
            Grd_BT.DataSource = (DataTable)ViewState["bind"];

            Grd_BT.DataBind();
            //bind();
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
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 66, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 67, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 68, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 69, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 70, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void Grdcost_PreRender(object sender, EventArgs e)
        {
            if (Grdcost.Rows.Count > 0)
            {
                Grdcost.UseAccessibleHeader = true;
                Grdcost.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}