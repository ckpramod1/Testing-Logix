using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using DataAccess;
using System.Net.NetworkInformation;
using AjaxControlToolkit.HtmlEditor.Popups;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Runtime.Remoting;

namespace logix.AE
{
    public partial class AEAWBDetails : System.Web.UI.Page
    {
        DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
        int chargeid1 = 0; double amount1 = 0; int chargeid = 0;
        DataTable DtAIEDetails = new DataTable();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.BLDetails da_obj_FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.AirImportExports.AIEBLDetails AIEBL = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
        DataTable dtinv = new DataTable();
        DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
        string str_trantype;
        string str_quotcust;
        string str_bookingno;
        int int_salesPID;
        int jobno; int count, i;
        string ourbl;
        string str_issuedon;
        string str_issuedat;
        string str_consignee;
        string str_shipper;
        string str_notifyparty1;
        string str_notifyparty2;
        string str_cnf;
        string str_fromport;
        string str_toport;
        string str_carrier1;
        string str_pod1;
        string str_carrier2;
        string str_pod2;
        string str_carrier3;
        string str_pod3;
        string str_curr;
        string str_handling;
        string str_noofpkgs, str_noofpallet;
        string str_pkgs;
        double rateclass;
        string str_citemno;
        string str_grosswt;
        string str_netwt;
        string str_chargewt;
        string str_descn;
        string str_freight;
        string str_nomination;
        string str_wttype;
        string str_oth;
        string str_wtf;
        double oldchargewt;
        int Refno, refnodebitOs, Refno1;
        string custype;
        string str_name;
        string str_custadd;
        string str_saddress;
        string precol;
        string Ctrl_List, Msg_List, Dtype_List;
        string str_da1;
        string str_Uiid = "", str_FornName;
        bool Blrr; string ppcc = "";
        bool invgen, invgen1;
        string StrScript = "";
        Boolean bolcuststat = false;
        Boolean bolcuststat1 = false;
        string base1, strvolume, strntweight, strchgweight, strgrosswght, sizecount, strchgpallet, strchgtruck;
        double rate, exrate, amount, unit, cbmAmt, mtAmt;
        DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
        string switchbl;
        DataAccess.AirImportExports.AIEJobInfo AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise(); 
        DataAccess.Masters.MasterPackages da_obj_package = new DataAccess.Masters.MasterPackages();
        DataAccess.ForwardingExports.BLDetails feblobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
        DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
        DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCargo da_obj_cargoobj = new DataAccess.Masters.MasterCargo();
        DataAccess.CostingTemp objcos = new DataAccess.CostingTemp();
        DataAccess.Accounts.Invoice da_obj_Invobj = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        DataAccess.AirImportExports.AIEJobInfo objaej = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.AirImportExports.AIEJobInfo objaejob = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
        DataAccess.AirImportExports.AIEBLDetails objblae = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.UserPermission obj_da_user = new DataAccess.UserPermission();

        string famount, strcharge, strbase;
        Double douvolume = 0;
        string mblno;
        Double wt = 0.00;
        int fd;
        int agentid;
        DataTable DtBLNO = new DataTable();
        bool DebitOS, CreditOS;
        int refnocreditOs;
        DataTable dtcust = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                AEBLobj.GetDataBase(Ccode);
                da_obj_Logobj.GetDataBase(Ccode);
                da_obj_FIBLobj.GetDataBase(Ccode);
                AIEBL.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                ProINVobj.GetDataBase(Ccode);


                da_obj_customerobj.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);
                da_obj_portobj.GetDataBase(Ccode);
                AEJobobj.GetDataBase(Ccode);


                DAdvise.GetDataBase(Ccode);
                da_obj_AEJobobj.GetDataBase(Ccode);
                da_obj_package.GetDataBase(Ccode);
                feblobj.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
                cargoobj.GetDataBase(Ccode);

                obj_da_Close.GetDataBase(Ccode);
                da_obj_INVOICEobj.GetDataBase(Ccode);
                da_obj_AEBLobj.GetDataBase(Ccode);
                da_obj_Customer.GetDataBase(Ccode);
                obj_MasterPort.GetDataBase(Ccode);
                da_obj_cargoobj.GetDataBase(Ccode);
                objcos.GetDataBase(Ccode);


                da_obj_Invobj.GetDataBase(Ccode);
                da_obj_OSDNCN.GetDataBase(Ccode);
                da_obj_logobj.GetDataBase(Ccode);
                objaejob.GetDataBase(Ccode);
                objaej.GetDataBase(Ccode);


                INVOICEobj.GetDataBase(Ccode);
                DCAdviseObj.GetDataBase(Ccode);
                objblae.GetDataBase(Ccode);
                obj_da_user.GetDataBase(Ccode);



            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Session["StrTranType"].ToString() == "AE")
            {
                chargedetails.Visible = true;
            }
            else
            {
                chargedetails.Visible = false;
            }

            if (IsPostBack != true)
            {
                try
                {
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        chargedetails.Visible = true;
                    }
                    else
                    {
                        chargedetails.Visible = false;
                    }
                    if (Request.QueryString.ToString().Contains("AEbl"))
                    {
                        lblheader.Text = Request.QueryString["AEbl"].ToString();
                    }
                    
                    hid_reuse.Value = "";
                    //Ctrl_List = txt_jobno.ID + "~" + txt_bookno.ID + "~" + txt_ablno.ID + "~" + txt_issueat.ID + "~" + hf_intissuedid.ID + "~" + ddl_cmbfreight.ID + "~" + txt_shipper.ID + "~" + hf_intshipperid.ID + "~" + txt_consignee.ID + "~" + hf_intconsid.ID + "~" + txt_notifyparty1.ID + "~" + hf_intnotifyid1.ID + "~" + txt_notifyparty2.ID + "~" + hf_intnotifyid2.ID + "~" + txt_fromport.ID + "~" + hf_intfromid.ID + "~" + txt_toport.ID + "~" + hf_inttoid.ID + "~" + txt_cnf.ID + "~" + hf_intchaid.ID + "~" + txt_curr.ID + "~" + hf_curid.ID + "~" + txt_to1.ID + "~" + hf_inttoid1.ID + "~" + txt_by1.ID + "~" + hf_intbyid1.ID + "~" + txt_to2.ID + "~" + hf_inttoid2.ID + "~" + txt_by2.ID + "~" + hf_intbyid2.ID + "~" + txt_to3.ID + "~" + hf_inttoid3.ID + "~" + txt_by3.ID + "~" + hf_intbyid3.ID + "~" + txt_handling.ID + "~" + txt_packages.ID + "~" + ddl_cmbpkgdesc.ID + "~" + txt_gross.ID + "~" + ddl_cmbwttype.ID + "~" + txt_charge.ID + "~" + txt_rate.ID + "~" + txt_rcamt.ID + "~" + txt_citemno.ID + "~" + txt_dvca.ID + "~" + txt_dvcus.ID + "~" + txt_chgcode.ID + "~" + ddl_cmbwt.ID + "~" + ddl_cmboth.ID + "~" + txt_cargo.ID + "~" + hf_IntCOMMODITY.ID + "~" + txt_inscurr.ID + "~" + hf_curid.ID + "~" + txt_insamt.ID + "~" + txt_desc.ID + "~" + txt_othchg.ID;
                    //Msg_List = "Job #~Booking #~HAWBL #~Issued At~Issued At~Freight~Shipper~Shipper~Consignee~Consignee~Notify Party I~Notify Party I~Notify Party II~Notify Party II~From Port~From Port~To Port~To Port~CNF~CNF~Curr~Curr~To~To~By~By~To~To~By~By~To~To~By~By~Handling Info~No of Pkgs~Pkg Type~GrossWt~Type~Charge Wt~Rate Class~Amount~Citem No~D.V.Carriage~D.V.Customs~Chg Code~Wt/Val~Other~Commodity~commodity~Insurance~Insurance~Insurance Amt~Description~Other Charges";
                    //Dtype_List = "int~string~string~string~Autocomplete~Dropdownlist~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~int~Dropdownlist~int~Dropdownlist~int~int~int~int~int~int~int~Dropdownlist~Dropdownlist~stirng~Autocomplete~string~Autocomplete~strings~string~string";
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "AE")
                        {
                            Ctrl_List = "txt_jobno~txt_bookno~txt_ablno~txt_issueat~txt_shipper~txt_consignee~txt_notifyparty1~txt_notifyparty2~txt_fromport~txt_toport~txt_cnf~txt_to1~txt_by1~txt_to2~txt_by2~txt_to3~txt_by3~txt_packages~txt_gross~txt_charge~txt_cargo~txt_desc~txt_othchg~txt_rate~txt_volwt~txt_pallet";
                            Msg_List = "Job #~Booking #~AIRWAYS BL NUMBER~Issued At~Shipper~Consignee~Notify Party I~Notify Party II~From Port~To Port~CNF~To~By~To~By~To~By~No of Packages~GROSS WEIGHT~CHARGE WEIGHT~Commodity~Description~Other Charges~Rate Class~Volume~No of Pallet";
                            Dtype_List = "string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string";
                        }
                        else
                        {
                            Ctrl_List = "txt_jobno~txt_ablno~txt_issueat~txt_shipper~txt_consignee~txt_notifyparty1~txt_notifyparty2~txt_fromport~txt_toport~txt_cnf~txt_to1~txt_by1~txt_to2~txt_by2~txt_to3~txt_by3~txt_packages~txt_gross~txt_charge~txt_cargo~txt_desc~txt_othchg~txt_rate~txt_pallet";
                            Msg_List = "Job #~AIRWAYS BL NUMBER~Issued At~Shipper~Consignee~Notify Party I~Notify Party II~From Port~To Port~CNF~To~By~To~By~To~By~No of Packages~GROSS WEIGHT~CHARGE WEIGH~Commodity~Description~Other Charges~Rate Class~No of Pallet";
                            Dtype_List = "string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string";
                        }
                    }
                    else
                    {
                        Ctrl_List = "txt_jobno~txt_bookno~txt_ablno~txt_issueat~txt_shipper~txt_consignee~txt_notifyparty1~txt_notifyparty2~txt_fromport~txt_toport~txt_cnf~txt_to1~txt_by1~txt_to2~txt_by2~txt_to3~txt_by3~txt_packages~txt_gross~txt_charge~txt_cargo~txt_desc~txt_othchg~txt_rate~txt_pallet";
                        Msg_List = "Job #~Booking #~AIRWAYS BL NUMBER~Issued At~Shipper~Consignee~Notify Party I~Notify Party II~From Port~To Port~CNF~To~By~To~By~To~By~No of Packages~GROSS WEIGHT~CHARGE WEIGHT~Commodity~Description~Other Charges~Rate Class~No of Pallet";
                        Dtype_List = "string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string";

                        //Ctrl_List = "txt_jobno~txt_ablno~txt_issueat~txt_shipper~txt_consignee~txt_notifyparty1~txt_notifyparty2~txt_fromport~txt_toport~txt_cnf~txt_curr~txt_to1~txt_by1~txt_to2~txt_by2~txt_to3~txt_by3~txt_handling~txt_packages~txt_gross~txt_charge~txt_dvca~txt_dvcus~txt_chgcode~txt_cargo~txt_inscurr~txt_insamt~txt_desc~txt_othchg~txt_rate";
                        //Msg_List = "Job #~AIRWAYS BL NUMBER~Issued At~Shipper~Consignee~Notify Party I~Notify Party II~From Port~To Port~CNF~Currency~To~By~To~By~To~By~HANDLING INFORMATION~No of Packages~GROSS WEIGHT~CHARGE WEIGHT~Declared Value for Carriage~Declared Value for Customs~Charge Code~Commodity~Insurance~Insurance Amount~Description~Other Charges~Rate Class";
                        //Dtype_List = "string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string~string";
                    }
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    // txt_packages.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'EX-Rate')");

                    txt_packages.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'No Of Pkgs');");
                    txt_pallet.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'No Of Pallets');");
                    txt_gross.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Gross Wt');");
                    txt_charge.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Charge Wt');");
                    txt_rate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate Class');");
                    txt_rcamt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount');");
                    txt_dvca.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'D.V Carriage');");
                    txt_dvcus.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'D.V Customs');");
                    txt_insamt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Insurance Amount');");
                    txt_jobno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

                    txt_volwt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Volume Wt');");
                    txt_min.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'MIN Wt');");
                    //Ctrl_List1 = txt_jobno.ID + "~" + txt_bookno.ID + "~" + txt_ablno.ID + "~" + txt_issueat.ID + "~" + hf_intissuedid .ID+ "~" + ddl_cmbfreight.ID + "~" + "~" + txt_shipper.ID + "~" + hf_intshipperid.ID + "~" + txt_consignee.ID + "~" + hf_intconsid.ID + "~" + txt_notifyparty1.ID + "~" + hf_intnotifyid1.ID + "~" + txt_notifyparty2.ID + "~" + hf_intnotifyid2.ID + "~" + txt_fromport.ID + "~" + hf_intfromid.ID + "~" + txt_toport.ID + "~" + hf_inttoid.ID + "~" + txt_cnf.ID + "~" + hf_intchaid.ID + "~" + txt_curr.ID + "~" + hf_curid.ID + "~" + txt_to1.ID + "~" + hf_inttoid1.ID + "~" + txt_by1.ID + "~" + hf_intbyid1.ID + "~" + txt_to2.ID + "~" + hf_inttoid2.ID + "~" + txt_by2.ID + "~" + hf_intbyid2.ID + "~" + txt_to3.ID + "~" + hf_inttoid3.ID + "~" + txt_by3.ID + "~" + hf_intbyid3.ID + "~" + txt_handling.ID + "~" + txt_packages.ID + "~" + ddl_cmbpkgdesc.ID + "~" + txt_gross.ID + "~" + ddl_cmbwttype.ID + "~" + txt_charge.ID + "~" + txt_rate.ID + "~" + txt_rcamt.ID + "~" + txt_citemno.ID + "~" + txt_dvca.ID + "~" + txt_dvcus.ID + "~" + txt_chgcode.ID + "~" + ddl_cmbwt.ID + "~" + ddl_cmboth.ID + "~" + txt_cargo.ID + "~" + hf_IntCOMMODITY.ID + "~" + txt_inscurr.ID + "~" + hf_curid.ID + "~" + txt_insamt.ID + "~" + txt_desc.ID + "~" + txt_othchg.ID;
                    //Msg_List1 = "Job #~Booking #~HAWBL #~Issued At~Freight~Shipper~Shipper~Consignee~Consignee~Notify Party I~Notify Party I~Notify Party II~Notify Party II~From Port~From Port~To Port~To Port~CNF~CNF~Curr~Curr~To~To~By~By~To~To~By~By~To~To~By~By~Handling Info~No of Pkgs~Pkg Type~GrossWt~Type~Charge Wt~Rate Class~Amount~Citem No~D.V.Carriage~D.V.Customs~Chg Code~Wt/Val~Other~Commodity~commodity~Insurance~Insurance~Insurance Amt~Description~Other Charges";
                    //Dtype_List1 = "int~string~string~string~Autocomplete~Dropdownlist~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~int~Dropdownlist~int~Dropdownlist~int~int~int~int~int~int~intDropdownlist~Dropdownlist~stirng~Autocomplete~string~Autocomplete~strings~string~string";
                    //btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    str_trantype = Session["StrTranType"].ToString();
                    //ddl_cmbfreight.Items.Add("Freight");
                    load();
                    fn_Empty_grdST();
                    //  shipperinvoice();
                    Btn_delete.Enabled = false;
                    Btn_delete.ForeColor = System.Drawing.Color.Gray;
                    txt_ablno.ReadOnly = false;
                    UserRights();
                    //Grid_shipperinvoice.DataSource = new DataTable();
                    //Grid_shipperinvoice.DataBind();

                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        HeaderLabel1.InnerText = "Air Exports";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        HeaderLabel1.InnerText = "Air Imports";
                    }

                    if (Request.QueryString.ToString().Contains("blno"))
                    {
                        txt_ablno.Text = Request.QueryString["blno"].ToString().Trim().ToUpper();
                        txt_ablno_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("BLDetails"))
                    {
                        if (Request.QueryString.ToString().Contains("jobno"))
                        {
                            txt_jobno.Text = Request.QueryString["jobno"].ToString();
                            //txt_jobno_TextChanged(sender, e);
                            //DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                            DataTable DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            if (DtA_Details.Rows.Count > 0)
                            {
                                 
                                txt_by1.Text = DtA_Details.Rows[0][0].ToString();
                                txt_by2.Text = DtA_Details.Rows[0][0].ToString();
                                txt_by3.Text = DtA_Details.Rows[0][0].ToString();
                                hf_intbyid1.Value = DtA_Details.Rows[0]["airlineid"].ToString();
                                hf_intbyid2.Value = DtA_Details.Rows[0]["airlineid"].ToString();
                                hf_intbyid3.Value = DtA_Details.Rows[0]["airlineid"].ToString();
                            }
                                txt_jobno.Enabled = false;
                        }
                        if (Request.QueryString.ToString().Contains("bookingno"))
                        {
                            txt_bookno.Text = Request.QueryString["bookingno"].ToString();
                            if (Session["StrTranType"].ToString() == "AE")
                            {
                                txt_ablno.Text = Request.QueryString["bookingno"].ToString().Trim().ToUpper();
                            }
                            else
                            {
                                txt_ablno.Text = "";
                            }
                            bookindetails();
                            if (hid_intcustomerid1.Value != "")
                            {
                                dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(hid_intcustomerid1.Value));
                            }
                            //if (dtcust.Rows.Count > 0)
                            //  {
                            //   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                            //   btn_save.Visible = false;
                            //   return;

                            //}


                        }

                    }

                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        switchblid.Visible = true;
                        directbl.Visible = true;
                        chk_nomin.Enabled = true;
                        //chk_nomin.Checked = true;

                    }
                    else
                    {
                        switchblid.Visible = false;
                        directbl.Visible = false;
                        Grid_shipperinvoice.Visible = false;
                        chk_nomin.Enabled = false;
                        chk_nomin.Checked = true;
                    }

                    txt_min.Text = "1";
                    txt_rate.Text = "1";
                    txt_dvca.Text = "0";
                    txt_dvcus.Text = "0";
                    txt_chgcode.Text = "0";
                    txt_othchg.Text = "AS AGREED";
                    Ctrl_List = txt_ablno.ID + "~" + txt_jobno.ID;
                    Msg_List = "BLNO~JobNo";
                    Dtype_List = "string~string";
                    btn_save.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    Ctrl_List = txt_amt.ID;
                    Msg_List = "Amount";
                    Dtype_List = "string~string";
                    btn_add.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    ChargeDetailsLoad();
                    txt_amt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

                string BL_No = Request.QueryString["BL_No"];

                if (BL_No != null)
                {
                    //menu_itm.Visible = true;
                    txt_ablno.Text = BL_No;
                    //lbl_header.Text = "Our BL";
                    txt_ablno_TextChanged(sender, e);
                    Btn_delete.Visible = false;
                    btn_save.Visible = false;
                    btn_reuse.Visible = false;
                    Btnshipper.Visible = false;
                    procrednote.Visible = false;
                    Proinvoic.Visible = false;
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

        private void EmptyGrid_Charge()
        {
            DataTable dtempty = new DataTable();
            //dtempty.Columns.Add();
            dtempty.Columns.Add("charges");
            dtempty.Columns.Add("amount");
            dtempty.Columns.Add("ppcc");
            dtempty.Columns.Add("chargeid");
            dtempty.Rows.Add(dtempty.NewRow());
            //Grd_sb.RowStyle.Width = 20;
            Grd_Charge.DataSource = dtempty;
            Grd_Charge.DataBind();
            Grd_Charge.Rows[0].Visible = false;
        }

        private void ChargeDetailsLoad()
        {
            //ddl_charge.Items.Add("");
            ddl_charge.Items.Add("Valuation Charge");
            ddl_charge.Items.Add("Total Other Charges Due Agent");
            ddl_charge.Items.Add("Total Other Charges Due Carrier");
            ddl_pc.Items.Add("Prepaid");
            //ddl_pc.Items.Add("To-Collect");
            ddl_pc.Items.Add("Collect");
        }
        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {

                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, Btn_delete);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    Boolean btn_delete;
                    //  btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        [WebMethod]
        public static List<string> Getcusname(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix, custtype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }

        [WebMethod]
        public static List<string> Getcuname(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix, custtype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }
        [WebMethod]
        public static List<string> Getnotifyname(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix, custtype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }
        [WebMethod]
        public static List<string> Getnotifyname1(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix, custtype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }

        [WebMethod]
        public static List<string> Getportname(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            da_obj_chargeobj.GetDataBase(Ccode);
            obj_dtl = da_obj_portobj.GetLikePort(prefix);
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }
        [WebMethod]
        public static List<string> Getponame(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            da_obj_chargeobj.GetDataBase(Ccode);
            obj_dtl = da_obj_portobj.GetLikePort(prefix);
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }
        [WebMethod]
        public static List<string> Getnotify2(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
           
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix, custtype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }
        [WebMethod]
        public static List<string> GetCurr(string prefix)
        {
            List<string> currency = new List<string>();
            DataTable obj_dt3 = new DataTable();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_chargeobj.GetDataBase(Ccode);
            da_obj_portobj.GetDataBase(Ccode);
            obj_dt3 = da_obj_chargeobj.GetLikeCurrency(prefix);
            currency = Utility.Fn_DatatableToList_string(obj_dt3, "currency", "currency");
            return currency;

        }
        [WebMethod]
        public static List<string> Getnotify3(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
           
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix, custtype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }
        [WebMethod]
        public static List<string> Getponame1(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            da_obj_chargeobj.GetDataBase(Ccode);
            obj_dtl = da_obj_portobj.GetLikePort(prefix);
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }

        [WebMethod]
        public static List<string> Getcargo(string prefix)
        {
            List<string> cargotype = new List<string>();
            DataTable obj_dt1 = new DataTable();
            DataAccess.Masters.MasterCargo da_obj_cargoobj = new DataAccess.Masters.MasterCargo();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_cargoobj.GetDataBase(Ccode);
           
            obj_dt1 = da_obj_cargoobj.GetLikeCargo(prefix);
            cargotype = Utility.Fn_DatatableToList(obj_dt1, "cargotype", "cargoid");
            return cargotype;
        }
        [WebMethod]
        public static List<string> Getnotify4(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
           
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix, custtype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }
        [WebMethod]
        public static List<string> Getponame2(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            da_obj_chargeobj.GetDataBase(Ccode);
            obj_dtl = da_obj_portobj.GetLikePort(prefix);
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }
        [WebMethod]
        public static List<string> Getnotify5(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
           
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix, custtype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }
        [WebMethod]
        public static List<string> Getname(string prefix)
        {
            List<string> cargotype = new List<string>();
            DataTable obj_dt1 = new DataTable();
            DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_AEBLobj.GetDataBase(Ccode);
            
            if (HttpContext.Current.Session["StrTranType"].ToString() == "AE")
            {
                obj_dt1 = da_obj_AEBLobj.GetLikeAIEBLDetails(prefix, HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else
            {
                obj_dt1 = da_obj_AEBLobj.GetLikeAIEBLDetails(prefix, HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }

            cargotype = Utility.Fn_DatatableToList_Text(obj_dt1, "hawblno");
            return cargotype;
        }

        public void load()
        {
            str_trantype = Session["StrTranType"].ToString();
            //DataAccess.Masters.MasterPackages da_obj_package = new DataAccess.Masters.MasterPackages();
            DataTable Dt = new DataTable();
            ddl_cmbfreight.Items.Add("PrePaid");
            //ddl_cmbfreight.Items.Add("To-Collect");
            ddl_cmbfreight.Items.Add("Collect");
            ddl_cmbwt.Items.Add("PrePaid");
            //ddl_cmbwt.Items.Add("To-Collect");
            ddl_cmbwt.Items.Add("Collect");
            ddl_cmboth.Items.Add("PrePaid");
            //ddl_cmboth.Items.Add("To-Collect");
            ddl_cmboth.Items.Add("Collect");
            Dt = da_obj_package.GetPackagenames();
            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
            {
                ddl_cmbpkgdesc.Items.Add(Dt.Rows[i][0].ToString());
            }

            lblheader.Text = "AWB Details";

            if (str_trantype == "AE")
            {
                chk_nomin.Text = "Agent Controlled Business";
            }
            else
            {
                chk_nomin.Text = "Business Controlled By Us";
            }

            txt_dtissueon.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
        }
        protected void lbl_lnkrate_Click(object sender, EventArgs e)
        {

            BindGrid();
            if (Blrr == true)
            {
                return;
            }

        }
        public void BindGrid()
        {
            try
            {
                str_trantype = Session["StrTranType"].ToString();
                //DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                DataTable Dt = new DataTable();
                str_trantype = Session["StrTranType"].ToString();
                grd_book.Visible = true;
                if (str_trantype == "AE")
                {
                    if (txt_bookno.Text == "")
                    {
                        Dt = da_obj_AEJobobj.GetAIEAllDetails(str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (Dt.Rows.Count != 0)
                        {
                            //for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                            //{
                            //    if (Dt.Rows[i]["directbl"] == "Y")
                            //    {
                            //        chk_directbl.Checked = true;
                            //    }
                            //    else
                            //    {
                            //        chk_directbl.Checked = false;
                            //    }
                            //}

                            grd_book.DataSource = Dt;
                            grd_book.DataBind();
                            ViewState["Job"] = Dt;
                            this.Grd_book_popup.Show();

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job Not Available')", true);
                            Blrr = true;
                            return;
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (txt_bookno.Text == "")
                    {
                        Dt = da_obj_AEJobobj.GetAIEAllDetails(str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (Dt.Rows.Count != 0)
                        {
                            grd_book.DataSource = Dt;
                            grd_book.DataBind();
                            ViewState["Job"] = Dt;
                            this.Grd_book_popup.Show();


                            //Grd_book_popup.Show();
                            //grd_book.DataSource = Dt;
                            //grd_book.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job Not Available')", true);
                            return;
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void lbl_book_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txt_jobno.Text != "")
                //{
                str_trantype = Session["StrTranType"].ToString();
                //DataAccess.ForwardingImports.BLDetails da_obj_FIBLobj = new DataAccess.ForwardingImports.BLDetails();
                DataTable Dt = new DataTable();
                Dt = da_obj_FIBLobj.Bookingdetailsnew(str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 0);
                if (Dt.Rows.Count != 0)
                {
                    grd_view_popup.Show();
                    grd.DataSource = Dt;
                    grd.DataBind();
                    grd.Visible = true;
                    ViewState["book"] = Dt;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Not Available')", true);
                    return;
                }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Kindly Select Job.')", true);
                //    return;
                //}

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grd_book_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_book.Rows.Count > 0)
            {
                int int_index;
                int_index = grd_book.SelectedRow.RowIndex;
                txt_jobno.Text = grd_book.Rows[int_index].Cells[0].Text.ToString();
                //DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                DataTable DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (DtA_Details.Rows.Count > 0)
                {
                    txt_mawbno.Text = DtA_Details.Rows[0][4].ToString();
                    //  txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                    txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                    txt_by1.Text = DtA_Details.Rows[0][0].ToString();
                    txt_by2.Text = DtA_Details.Rows[0][0].ToString();
                    txt_by3.Text = DtA_Details.Rows[0][0].ToString();
                    hf_intbyid1.Value= DtA_Details.Rows[0]["airlineid"].ToString();
                    hf_intbyid2.Value = DtA_Details.Rows[0]["airlineid"].ToString();
                    hf_intbyid3.Value = DtA_Details.Rows[0]["airlineid"].ToString();
                    txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                    txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                    // txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                    //  ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                    string status = DtA_Details.Rows[0][9].ToString();
                    txt_from.Text = DtA_Details.Rows[0][2].ToString();
                    txt_to.Text = DtA_Details.Rows[0][3].ToString();
                    txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                    txt_iatacarrier.Text = DtA_Details.Rows[0]["iatacarrier"].ToString();

                    if (status == "T")
                    {
                        cmbstatus.Text = "Collect";
                    }
                    else
                    {
                        cmbstatus.Text = "Prepaid";
                    }
                    txt_flightno2.Text = DtA_Details.Rows[0]["flightno2"].ToString();
                    if (DtA_Details.Rows[0]["flightdate2"].ToString() != "")
                    {
                        txt_dtfdate2.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0]["flightdate2"].ToString());
                    }
                    else
                    {
                        txt_dtfdate2.Text = "";
                    }
                   
                }
                txt_jobno.Enabled = false;
                txt_bookno.Focus();
                UserRights();
            }
        }
        
        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtdetails = new DataTable();
            //DataAccess.ForwardingExports.BLDetails feblobj = new DataAccess.ForwardingExports.BLDetails();
            int countryid;
            if (grd.Rows.Count > 0)
            {
                str_trantype = Session["StrTranType"].ToString();
                int int_index;
                int_index = grd.SelectedRow.RowIndex;
                hf_bookingno.Value = grd.Rows[int_index].Cells[0].Text.ToString();
                txt_bookno.Text = grd.Rows[int_index].Cells[0].Text.ToString();
                hf_salesPID.Value = grd.Rows[int_index].Cells[8].Text.ToString();
                str_quotcust = grd.Rows[int_index].Cells[2].Text.ToString();

                // txt_ablno.Text = txt_bookno.Text;
                //  txt_issueat.Focus();
                //txt_ablno.ReadOnly = true;
                //txt_ablno_TextChanged(sender, e);
                if (str_trantype == "AE")
                {

                    dtdetails = feblobj.GetBookingDt(txt_bookno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    txt_jobno.Text = dtdetails.Rows[0]["jobno"].ToString();
                    hid_quto.Value = dtdetails.Rows[0]["quotno"].ToString();
                    hid_buyingno.Value = dtdetails.Rows[0]["buyingno"].ToString();

                    hid_intcustomerid.Value = dtdetails.Rows[0]["customerid"].ToString();


                    //if (dtdetails.Rows.Count > 0)
                    //{
                    //    countryid = Convert.ToInt32(dtdetails.Rows[0]["countryid"].ToString());

                    //    //RajaGuru  SCM Removed

                    //    if (countryid == 233)
                    //    {
                    //        txt_ablno.ReadOnly = true;
                    //        txt_ablno.Text = dtdetails.Rows[0]["shiprefno"].ToString().Remove(4, 4);
                    //    }
                    //    else
                    //    {
                    //        txt_ablno.ReadOnly = true;
                    //        txt_ablno.Text = dtdetails.Rows[0]["shiprefno"].ToString().Substring(dtdetails.Rows[0]["shiprefno"].ToString().Trim().Length - 10);
                    //    }
                    //}
                    //else
                    //{

                    //    txt_ablno.Text = grd.Rows[int_index].Cells[0].Text.ToString().Substring(grd.Rows[int_index].Cells[0].Text.Trim().Length - 10); // grd.Rows(index).Cells(0).Value();
                    //    txt_ablno.Enabled = false;
                    //}

                    txt_ablno.Text = grd.Rows[int_index].Cells[0].Text.ToString().Substring(grd.Rows[int_index].Cells[0].Text.Trim().Length - 10); // grd.Rows(index).Cells(0).Value();
                    txt_ablno.Enabled = false;
                    if (hid_intcustomerid.Value != "")
                    {
                        dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(hid_intcustomerid.Value));
                    }
                    //if (dtcust.Rows.Count > 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                    //    btn_save.Visible = false;
                    //    return;

                    //}


                }
                else
                {
                    txt_ablno.Enabled = true;
                    txt_ablno.Text = grd.Rows[int_index].Cells[0].Text.ToString().Substring(grd.Rows[int_index].Cells[0].Text.Trim().Length - 10);
                    dtdetails = feblobj.GetBookingDt(txt_bookno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    hid_quto.Value = dtdetails.Rows[0]["quotno"].ToString();
                    hid_buyingno.Value = dtdetails.Rows[0]["buyingno"].ToString();
                    hid_intcustomerid.Value = dtdetails.Rows[0]["consigneeid"].ToString();
                    if (dtdetails.Rows.Count > 0)
                    {
                        txt_jobno.Text = dtdetails.Rows[0]["jobno"].ToString();
                        if (Session["StrTranType"].ToString() == "AE")
                        {
                            if (dtdetails.Rows[0]["business"].ToString() == "O")
                            {
                                chk_nomin.Checked = true;
                            }
                            else
                            {
                                chk_nomin.Checked = false;

                            }
                        }
                        else
                        {
                            if (dtdetails.Rows[0]["business"].ToString() == "O")
                            {
                                chk_nomin.Checked = true;
                            }
                            else
                            {
                                // chk_nomin.Checked = false;
                                chk_nomin.Checked = true;
                            }
                        }
                    }


                }
               // DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                DataTable DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (DtA_Details.Rows.Count > 0)
                {
                    txt_mawbno.Text = DtA_Details.Rows[0][4].ToString();
                    //  txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                    txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                    txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                    txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                    // txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                    //  ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                    string status = DtA_Details.Rows[0][9].ToString();
                    txt_from.Text = DtA_Details.Rows[0][2].ToString();
                    txt_to.Text = DtA_Details.Rows[0][3].ToString();
                    txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                    txt_iatacarrier.Text = DtA_Details.Rows[0]["iatacarrier"].ToString();

                    if (status == "T")
                    {
                        cmbstatus.Text = "Collect";
                    }
                    else
                    {
                        cmbstatus.Text = "Prepaid";
                    }
                    txt_flightno2.Text = DtA_Details.Rows[0]["flightno2"].ToString();
                    if (DtA_Details.Rows[0]["flightdate2"].ToString() != "")
                    {
                        txt_dtfdate2.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0]["flightdate2"].ToString());
                    }
                    else
                    {
                        txt_dtfdate2.Text = "";
                    }
                }
                txt_ablno_TextChanged(sender, e);
                UserRights();
            }
            //grd.Visible = false;
            txt_ablno.Focus();
            btn_back.Visible = true;
        }

        //private void bookingdetails()
        //{
        //    DataTable dtdetails =new DataTable()

        //    if (str_trantype == "AE")
        //    {

        //        dtdetails = feblobj.GetBookingDt(txt_bookno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

        //        hid_quto.Value = dtdetails.Rows[0]["quotno"].ToString();

        //        hid_intcustomerid.Value = dtdetails.Rows[0]["customerid"].ToString();

        //        if (dtdetails.Rows.Count > 0)
        //        {
        //            countryid = Convert.ToInt32(dtdetails.Rows[0]["countryid"].ToString());

        //            //RajaGuru  SCM Removed

        //            if (countryid == 233)
        //            {
        //                txt_ablno.ReadOnly = true;
        //                txt_ablno.Text = dtdetails.Rows[0]["shiprefno"].ToString().Remove(4, 4);
        //            }
        //            else
        //            {
        //                txt_ablno.ReadOnly = true;
        //                txt_ablno.Text = dtdetails.Rows[0]["shiprefno"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            txt_ablno.Text = grd.Rows[int_index].Cells[0].Text.ToString(); // grd.Rows(index).Cells(0).Value();
        //            txt_ablno.Enabled = false;
        //        }


        //    }
        //    else
        //    {
        //        txt_ablno.Enabled = true;
        //        dtdetails = feblobj.GetBookingDt(txt_bookno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
        //        if (dtdetails.Rows.Count > 0)
        //        {
        //            if (dtdetails.Rows[0]["business"].ToString() == "O")
        //            {
        //                chk_nomin.Checked = true;
        //            }
        //            else
        //            {
        //                chk_nomin.Checked = false;
        //            }
        //        }


        //    }
        //}
        public void bookindetails()
        {
            DataTable dtdetails = new DataTable();
            string str_freight = "";
            //DataAccess.ForwardingExports.BLDetails feblobj = new DataAccess.ForwardingExports.BLDetails();
            int countryid;
            str_trantype = Session["StrTranType"].ToString();
            if (str_trantype == "AE")
            {
                hf_bookingno.Value = txt_bookno.Text;

                dtdetails = feblobj.GetBookingDt(txt_bookno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                hid_quto.Value = dtdetails.Rows[0]["quotno"].ToString();

                hid_buyingno.Value = dtdetails.Rows[0]["buyingno"].ToString();


                hid_intcustomerid.Value = dtdetails.Rows[0]["customerid"].ToString();
                hid_intcustomerid1.Value = dtdetails.Rows[0]["customerid"].ToString();
                /* if (countryid == 233)
                 {
                     txt_ablno.ReadOnly = true;
                     txt_ablno.Text = dtdetails.Rows[0]["shiprefno"].ToString().Remove(4, 4);
                 }
                 else
                 {

                 }*/


                if (dtdetails.Rows.Count != 0)
                {
                    hf_salesPID.Value = dtdetails.Rows[0]["salesid"].ToString();
                }


                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["shipper"].ToString()))
                {
                    txt_shipper.Text = dtdetails.Rows[0]["shipper"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["customeridq"].ToString()))
                {
                    hf_intshipperid.Value = dtdetails.Rows[0]["customeridq"].ToString();
                }

                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["shipperaddress"].ToString()))
                {
                    txt_saddress.Text = dtdetails.Rows[0]["shipperaddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["consignee"].ToString()))
                {
                    txt_consignee.Text = dtdetails.Rows[0]["consignee"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["customeridcon"].ToString()))
                {
                    hf_intconsid.Value = dtdetails.Rows[0]["customeridcon"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["consigneeaddress"].ToString()))
                {
                    txt_caddress.Text = dtdetails.Rows[0]["consigneeaddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["pol"].ToString()))
                {
                    txt_fromport.Text = dtdetails.Rows[0]["pol"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["polid"].ToString()))
                {
                    hf_intfromid.Value = dtdetails.Rows[0]["polid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["pod"].ToString()))
                {
                    txt_toport.Text = dtdetails.Rows[0]["pod"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["podid"].ToString()))
                {
                    hf_inttoid.Value = dtdetails.Rows[0]["podid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["pod"].ToString()))
                {
                    txt_to1.Text = dtdetails.Rows[0]["pod"].ToString();
                }

                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["podid"].ToString()))
                {
                    hf_inttoid1.Value = dtdetails.Rows[0]["podid"].ToString();
                }
                txt_to2.Text = txt_to1.Text;
                txt_to3.Text = txt_to1.Text;

                hf_inttoid2.Value = hf_inttoid1.Value;
                hf_inttoid3.Value = hf_inttoid1.Value;


                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["cargotype"].ToString()))
                {
                    txt_cargo.Text = dtdetails.Rows[0]["cargotype"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["cargoid"].ToString()))
                {
                    hf_IntCOMMODITY.Value = dtdetails.Rows[0]["cargoid"].ToString();
                }
                //txt_notifyparty1.Text = dtdetails.Rows[0]["agent"].ToString();
                //hf_intnotifyid1.Value = dtdetails.Rows[0]["agentid"].ToString();
                //txt_naddress2.Text = dtdetails.Rows[0]["agentaddress"].ToString();
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["fstatus"].ToString()))
                {
                    str_freight = dtdetails.Rows[0]["fstatus"].ToString();
                }
                if (str_freight == "P")
                {
                    ddl_cmbfreight.SelectedValue = "PrePaid";
                }
                else
                {
                    // ddl_cmbfreight.SelectedValue = "To-Collect";
                    ddl_cmbfreight.SelectedValue = "Collect";
                }
                if (ddl_cmbfreight.SelectedValue == "PrePaid")
                {
                    ddl_cmbwt.SelectedValue = "PrePaid";
                    ddl_cmboth.SelectedValue = "PrePaid";
                }
                else
                {
                    //ddl_cmbwt.SelectedValue = "To-Collect";
                    //ddl_cmboth.SelectedValue = "To-Collect";

                    ddl_cmbwt.SelectedValue = "Collect";
                    ddl_cmboth.SelectedValue = "Collect";
                }
                //if (dtdetails.Rows.Count > 0)
                //{
                //    countryid = Convert.ToInt32(dtdetails.Rows[0]["countryid"].ToString());

                //    //RajaGuru  SCM Removed

                //    if (countryid == 233)
                //    {
                //        txt_ablno.ReadOnly = true;
                //        txt_ablno.Text = dtdetails.Rows[0]["shiprefno"].ToString().Remove(4, 4);
                //    }
                //    else
                //    {
                //        txt_ablno.ReadOnly = true;
                //        txt_ablno.Text = dtdetails.Rows[0]["shiprefno"].ToString().Substring(dtdetails.Rows[0]["shiprefno"].ToString().Trim().Length - 10);
                //    }
                //}
                //else
                //{
                //    txt_ablno.Text = txt_bookno.Text;
                //    txt_ablno.Enabled = false;
                //}

                txt_ablno.Text = txt_bookno.Text.Trim().ToUpper();
                txt_ablno.Enabled = false;

            }
            else
            {
                txt_ablno.Enabled = true;
                hf_bookingno.Value = txt_bookno.Text;

                dtdetails = feblobj.GetBookingDt(txt_bookno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                hid_quto.Value = dtdetails.Rows[0]["quotno"].ToString();
                hid_buyingno.Value = dtdetails.Rows[0]["buyingno"].ToString();
                hid_intcustomerid.Value = dtdetails.Rows[0]["consigneeid"].ToString();


                hid_intcustomerid1.Value = dtdetails.Rows[0]["customerid"].ToString();

                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["shippername"].ToString()))
                {
                    txt_shipper.Text = dtdetails.Rows[0]["shippername"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["shipperid"].ToString()))
                {
                    hf_intshipperid.Value = dtdetails.Rows[0]["shipperid"].ToString();
                }

                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["shipperaddressnew"].ToString()))
                {
                    txt_saddress.Text = dtdetails.Rows[0]["shipperaddressnew"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["consignee"].ToString()))
                {
                    txt_consignee.Text = dtdetails.Rows[0]["consignee"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["customeridcon"].ToString()))
                {
                    hf_intconsid.Value = dtdetails.Rows[0]["customeridcon"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["consigneeaddress"].ToString()))
                {
                    txt_caddress.Text = dtdetails.Rows[0]["consigneeaddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["pol"].ToString()))
                {
                    txt_fromport.Text = dtdetails.Rows[0]["pol"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["polid"].ToString()))
                {
                    hf_intfromid.Value = dtdetails.Rows[0]["polid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["pod"].ToString()))
                {
                    txt_toport.Text = dtdetails.Rows[0]["pod"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["podid"].ToString()))
                {
                    hf_inttoid.Value = dtdetails.Rows[0]["podid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["pod"].ToString()))
                {
                    txt_to1.Text = dtdetails.Rows[0]["pod"].ToString();
                }

                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["podid"].ToString()))
                {
                    hf_inttoid1.Value = dtdetails.Rows[0]["podid"].ToString();
                }
                txt_to2.Text = txt_to1.Text;
                txt_to3.Text = txt_to1.Text;

                hf_inttoid2.Value = hf_inttoid1.Value;
                hf_inttoid3.Value = hf_inttoid1.Value;


                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["cargotype"].ToString()))
                {
                    txt_cargo.Text = dtdetails.Rows[0]["cargotype"].ToString();
                }
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["cargoid"].ToString()))
                {
                    hf_IntCOMMODITY.Value = dtdetails.Rows[0]["cargoid"].ToString();
                }
                //txt_notifyparty1.Text = dtdetails.Rows[0]["agent"].ToString();
                //hf_intnotifyid1.Value = dtdetails.Rows[0]["agentid"].ToString();
                //txt_naddress2.Text = dtdetails.Rows[0]["agentaddress"].ToString();
                if (!string.IsNullOrEmpty(dtdetails.Rows[0]["fstatus"].ToString()))
                {
                    str_freight = dtdetails.Rows[0]["fstatus"].ToString();
                }
                //if (str_freight == "P")
                //{
                //    ddl_cmbfreight.SelectedValue = "PrePaid";
                //}
                //else
                //{
                //    ddl_cmbfreight.SelectedValue = "To-Collect";
                //}


                if (str_freight == "P")
                {
                    ddl_cmbfreight.SelectedValue = "PrePaid";
                }
                else
                {
                    //ddl_cmbfreight.SelectedValue = "To-Collect";

                    ddl_cmbfreight.SelectedValue = "Collect";
                }
                if (ddl_cmbfreight.SelectedValue == "PrePaid")
                {
                    ddl_cmbwt.SelectedValue = "PrePaid";
                    ddl_cmboth.SelectedValue = "PrePaid";
                }
                else
                {
                    //ddl_cmbwt.SelectedValue = "To-Collect";
                    //ddl_cmboth.SelectedValue = "To-Collect";

                    ddl_cmbwt.SelectedValue = "Collect";
                    ddl_cmboth.SelectedValue = "Collect";
                }
                if (dtdetails.Rows.Count > 0)
                {
                    if (Session["StrTranType"].ToString() == "AE")
                    {

                        if (dtdetails.Rows[0]["business"].ToString() == "O")
                        {
                            chk_nomin.Checked = true;
                        }
                        else
                        {
                            chk_nomin.Checked = false;


                        }
                    }
                    else
                    {

                        if (dtdetails.Rows[0]["business"].ToString() == "O")
                        {
                            chk_nomin.Checked = true;
                        }
                        else
                        {
                            // chk_nomin.Checked = false;

                            chk_nomin.Checked = true;
                        }
                    }
                }


            }
           // DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
            DataTable DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (DtA_Details.Rows.Count > 0)
            {
                txt_mawbno.Text = DtA_Details.Rows[0][4].ToString();
                //  txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                // txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                //  ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                string status = DtA_Details.Rows[0][9].ToString();
                txt_from.Text = DtA_Details.Rows[0][2].ToString();
                txt_to.Text = DtA_Details.Rows[0][3].ToString();
                txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                txt_iatacarrier.Text = DtA_Details.Rows[0]["iatacarrier"].ToString();

                if (status == "T")
                {
                    cmbstatus.Text = "Collect";
                }
                else
                {
                    cmbstatus.Text = "Prepaid";
                }
                txt_flightno2.Text = DtA_Details.Rows[0]["flightno2"].ToString();
                if (DtA_Details.Rows[0]["flightdate2"].ToString() != "")
                {
                    txt_dtfdate2.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0]["flightdate2"].ToString());
                }
                else
                {
                    txt_dtfdate2.Text = "";
                }

            }
            txt_jobno.Enabled = false;
        }



        protected void Checkdata()
        {
            str_trantype = Session["StrTranType"].ToString();
            DataTable obj_dt = new DataTable();
            if (txt_charge.Text == "0")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('CHARGE WEIGHT must be greater than Zero')", true);
                txt_charge.Focus();
                Blrr = true;
                return;
            }
            if (str_trantype == "AE")
            {
                if (txt_min.Text == "0" || txt_min.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('MINIMUM WEIGHT must be greater than Zero')", true);
                    txt_min.Focus();
                    Blrr = true;
                    return;
                }
            }

            if (txt_issueat.Text != "")
            {
                if (da_obj_portobj.GetNPortid(txt_issueat.Text.ToUpper()) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Issued At')", true);
                    txt_issueat.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_shipper.Text != "")
            {
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_shipper.Text, "C");
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Shipper NAME')", true);
                    txt_shipper.Focus();
                    Blrr = true;
                    return;
                }
            }


            if (txt_consignee.Text != "")
            {
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_consignee.Text, "C");
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Consignee NAME')", true);
                    txt_consignee.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_notifyparty1.Text != "")
            {
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_notifyparty1.Text, "C");
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Notify Party I')", true);
                    txt_notifyparty1.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_notifyparty2.Text != "")
            {
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_notifyparty2.Text, "C");
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Notify Party II')", true);
                    txt_notifyparty1.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_fromport.Text != "")
            {
                if (da_obj_portobj.GetNPortid(txt_fromport.Text.ToUpper()) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID From Port')", true);
                    txt_fromport.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_toport.Text != "")
            {
                if (da_obj_portobj.GetNPortid(txt_toport.Text.ToUpper()) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID To Port')", true);
                    txt_toport.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_cnf.Text != "")
            {
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_cnf.Text, "C");
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID CNF NAME')", true);
                    txt_cnf.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_curr.Text != "")
            {
                //DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                if (chargeobj.GetCurrID(txt_curr.Text) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Currency')", true);
                    txt_curr.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_to1.Text != "")
            {
                if (da_obj_portobj.GetNPortid(txt_to1.Text.ToUpper()) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID TO PORT')", true);
                    txt_to1.Focus();
                    Blrr = true;
                    return;
                }
            }
            // if (txt_to1.Text != "")
            //{
            //    if (hf_inttoid1.Value == "" || hf_inttoid1.Value == "0")
            //    {
            //        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID TO PORT')", true);
            //        txt_to1.Focus();
            //        Blrr = true;
            //        return;
            //    }
            //}
            if (txt_by1.Text != "")
            {
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_by1.Text, "C");
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID CARRIER NAME')", true);
                    txt_by1.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_to2.Text != "")
            {
                if (da_obj_portobj.GetNPortid(txt_to2.Text.ToUpper()) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID TO PORT')", true);
                    txt_to2.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_by2.Text != "")
            {
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_by2.Text, "C");
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID CARRIER NAME')", true);
                    txt_by2.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_to3.Text != "")
            {
                if (da_obj_portobj.GetNPortid(txt_to3.Text.ToUpper()) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID TO PORT')", true);
                    txt_to3.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_by3.Text != "")
            {
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_by3.Text, "C");
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID CARRIER NAME')", true);
                    txt_by3.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_cargo.Text != "")
            {
                //DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
                if (cargoobj.GetCargoid(txt_cargo.Text) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID COMMODITY NAME')", true);
                    txt_cargo.Focus();
                    Blrr = true;
                    return;
                }
            }
            if (txt_inscurr.Text != "")
            {
               // DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                if (chargeobj.GetCurrID(txt_inscurr.Text) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Currency')", true);
                    txt_inscurr.Focus();
                    Blrr = true;
                    return;
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                //DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
                //DataAccess.ForwardingExports.BLDetails feblobj = new DataAccess.ForwardingExports.BLDetails();
                DataTable dtdetails = new DataTable();
               // DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                str_trantype = Session["StrTranType"].ToString();
              //  DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                txt_shipper_TextChanged(sender, e);
                txt_consignee_TextChanged(sender, e);
                txt_notifyparty1_TextChanged(sender, e);
                txt_notifyparty2_TextChanged(sender, e);
                txt_fromport_TextChanged(sender, e);
                txt_toport_TextChanged(sender, e);
                txt_cnf_TextChanged(sender, e);
                // txt_curr_TextChanged(sender, e);
                //txt_to1_TextChanged(sender, e);
                //txt_by1_TextChanged(sender, e);
                //txt_to2_TextChanged(sender, e);
                //txt_by2_TextChanged(sender, e);
                //txt_by3_TextChanged(sender, e);
                //txt_to3_TextChanged(sender, e);
                txt_cargo_TextChanged(sender, e);
                // txt_inscurr_TextChanged(sender, e);
                txt_issueat_TextChanged(sender, e);
                Checkdata();
                if(txt_dvcus.Text=="")
                {
                    txt_dvcus.Text = "0";
                }
                if (txt_dvca.Text == "")
                {
                    txt_dvca.Text = "0";
                }
                //txt_dvca.Text = "0";
               
                txt_chgcode.Text = "0";
                if (Blrr == true)
                {
                    return;
                }
                if (txt_handling.Text == "")
                {
                    txt_handling.Text = " ";
                }
                assign();
                if (txt_bookno.Text == "0")
                {
                    txt_bookno.Text = "";

                }

                if (!string.IsNullOrEmpty(txt_fromport.Text) && !string.IsNullOrEmpty(txt_toport.Text))
                {
                    if (txt_fromport.Text.ToString() == txt_toport.Text.ToString())
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Load and Destination Port Should be Different')", true);
                        txt_toport.Focus();
                        return;
                    }
                }
                if (ddl_cmbfreight.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('select Freight Type')", true);
                    ddl_cmbfreight.Focus();
                    return;
                }
                if (ddl_cmbwttype.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('select CMB Type')", true);
                    ddl_cmbwttype.Focus();
                    return;
                }
                if (ddl_cmbpkgdesc.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('select Packages Type')", true);
                    ddl_cmbpkgdesc.Focus();
                    return;
                }
                if (ddl_cmbwt.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('select Weight/Value ')", true);
                    ddl_cmbwt.Focus();
                    return;
                }
                if (txt_insamt.Text == "")
                {
                    txt_insamt.Text = "0.00";
                }
                //if (ddl_cmboth.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('select WY / VAL - Other')", true);
                //    ddl_cmboth.Focus();
                //    return;
                //}
                hf_jobno.Value = txt_jobno.Text;
                hf_hawblno.Value = txt_ablno.Text.Trim().ToUpper();

                if (hf_hawblno.Value == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid HAWB NUMBER');", true);
                    txt_ablno.Text = "";
                    txt_ablno.Focus();
                    return;

                }
                if (txt_ablno.Text.Trim().ToUpper() == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid HAWB NUMBER');", true);
                    txt_ablno.Text = "";
                    txt_ablno.Focus();
                    return;

                }

                jobno = Convert.ToInt32(hf_jobno.Value);
                GetJobDt(jobno);



                if (hf_salesPID.Value == "")
                {
                    hf_salesPID.Value = "0";
                }

                if (!string.IsNullOrEmpty(txt_jobno.Text))
                {
                    if (da_obj_INVOICEobj.CheckClosedJobs(str_trantype, Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString())) == 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job has been Closed Already" + "You Can not Update the BL Details.');", true);
                        return;
                    }
                }
                DataTable Dt = new DataTable();
                Dt = da_obj_AEJobobj.GetLikeAIEJobMBLNo(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        if (txt_ablno.Text.Trim().ToUpper() == Dt.Rows[i][0].ToString().Trim().ToUpper())
                        {
                            txt_ablno.Text = "";
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid BL #')", true);
                            txt_ablno.Focus();
                            return;
                        }
                    }
                }
                if (Session["StrTranType"].ToString() == "AI")
                {
                    if (btn_save.ToolTip == "Update")
                    {


                        DataTable obj_dttemp1 = new DataTable();
                        obj_dttemp1 = obj_da_Close.CheckShipmentTransferOrNotnewjobclosed(Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), "AI");
                        if (obj_dttemp1.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CostingDetails", "alertify.alert('To Port not updated because BL has transfer');", true);
                            txt_toport.Focus();
                            Blrr = true;
                            return;
                        }

                    }
                }


                if (str_trantype == "AE")
                {

                    if (chk_directbl.Checked == true)
                    {
                        ourbl = "Y";
                    }
                    else
                    {
                        ourbl = "N";
                    }

                    if (chk_switchbl.Checked == true)
                    {
                        switchbl = "Y";
                    }
                    else
                    {
                        switchbl = "N";
                    }
                    if ((string.IsNullOrEmpty(txt_bookno.Text) || txt_bookno.Text == "0") && str_trantype == "AE")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select the correct Booking Number')", true);
                        txt_bookno.Focus();
                        return;
                    }
                    //string shipper = "";
                    //if (Grid_shipperinvoice.Rows.Count > 0)
                    //{
                    //    if (Grid_shipperinvoice.Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i <= Grid_shipperinvoice.Rows.Count - 1; i++)
                    //        {
                    //            TextBox obj_txt_shipperinvoice = (TextBox)Grid_shipperinvoice.Rows[i].Cells[0].FindControl("txt_shipperinvoice");


                    //            if (obj_txt_shipperinvoice.Text == "")
                    //            {
                    //                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the ShipperInvoice')", true);
                    //                return;
                    //            }
                    //            else
                    //            {
                    //                shipper = obj_txt_shipperinvoice.Text;
                    //                break;
                    //            }



                    //        }
                    //    }
                    //}


                    if (btn_save.ToolTip == "Save")
                    {
                        if (hf_bookingno.Value == "0" || hf_bookingno.Value == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select the Booking #')", true);
                            txt_bookno.Focus();
                            return;
                        }

                        if (hf_salesPID.Value == "")
                        {
                            hf_salesPID.Value = "0";
                        }
                        //DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();

                        //da_obj_AEBLobj.InsAEBLDetailsAE(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(),
                        //    Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)), Convert.ToInt32(hf_intissuedid.Value),
                        //    Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value), Convert.ToInt32(hf_intnotifyid1.Value),
                        //    Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value), Convert.ToInt32(hf_intfromid.Value),
                        //    Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value), Convert.ToInt32(hf_inttoid1.Value),
                        //    Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value), Convert.ToInt32(hf_intbyid3.Value),
                        //    Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight), str_curr.ToUpper(), str_handling.ToUpper(),
                        //    Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass), str_citemno,
                        //    Convert.ToDouble(str_grosswt), Convert.ToDouble(str_chargewt), str_descn.ToUpper(), str_nomination.ToUpper(),
                        //    str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_rcamt.Text, Convert.ToInt32(hf_salesPID.Value),
                        //    Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()),
                        //    str_wttype, Convert.ToInt32(txt_dvca.Text.Trim()), Convert.ToInt32(txt_dvcus.Text.Trim()), txt_chgcode.Text,
                        //    str_wtf, str_oth, txt_inscurr.Text, Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.Trim().ToUpper(), Convert.ToDouble(str_netwt), switchbl.ToString());

                        da_obj_AEBLobj.InsAEBLDetailsAEnew(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(),
                            Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)), Convert.ToInt32(hf_intissuedid.Value),
                            Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value), Convert.ToInt32(hf_intnotifyid1.Value),
                            Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value), Convert.ToInt32(hf_intfromid.Value),
                            Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value), Convert.ToInt32(hf_inttoid1.Value),
                            Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value), Convert.ToInt32(hf_intbyid3.Value),
                            Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight), str_curr.ToUpper(), str_handling.ToUpper(),
                            Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass), str_citemno,
                            Convert.ToDouble(str_grosswt), Convert.ToDouble(str_chargewt), str_descn.ToUpper(), str_nomination.ToUpper(),
                            str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_rcamt.Text, Convert.ToInt32(hf_salesPID.Value),
                            Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()),
                            str_wttype, Convert.ToInt32(txt_dvca.Text.Trim()), Convert.ToInt32(txt_dvcus.Text.Trim()), txt_chgcode.Text,
                            str_wtf, str_oth, txt_inscurr.Text, Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.Trim().ToUpper(), Convert.ToDouble(str_netwt), switchbl.ToString(), Convert.ToInt32(str_noofpallet));


                        da_obj_AEBLobj.UpdAETextDtlsnew(txt_shipper.Text.ToUpper(), txt_saddress.Text.ToUpper(), txt_consignee.Text.ToUpper(), txt_caddress.Text.ToUpper(), txt_notifyparty1.Text.ToUpper(), txt_naddress1.Text.ToUpper(), txt_notifyparty2.Text.ToUpper(), txt_naddress2.Text.ToUpper(), txt_fromport.Text.ToUpper(), txt_toport.Text.ToUpper(), txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                        InsertDimension();



                        da_obj_FIBLobj.UpdateBooking(hf_bookingno.Value.ToUpper(), hf_hawblno.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        da_obj_AEBLobj.updaeblminwt(jobno, hf_hawblno.Value.ToUpper(), Convert.ToDouble(txt_min.Text), Convert.ToInt32(Session["LoginBranchid"]));
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 6, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype + txt_ablno.Text.Trim().ToUpper() + "Save" + txt_min.Text);
                        da_obj_AEBLobj.UpdAETextDtlsOurbl(hf_hawblno.Value.ToUpper(), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), ourbl);
                        //shipperinvoiceinsert();

                        AutoInvoice();
                        Autocnops();
                        autodebitOS();
                        autocreditOS();
                        string supplyto = "";
                        if (hid_SupplyTo.Value != "")
                        {
                            supplyto = da_obj_customerobj.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                            ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), supplyto);
                        }





                        // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + "');", true);
                        StrScript += " Details Saved for HAWB # " + txt_ablno.Text.Trim().ToUpper();

                        if (Refno != 0)
                        {
                            StrScript += ". System Auto-generated Proforma Sales Invoice # is " + Refno;

                            //if (invgen == true && DebitOS == false)
                            //{
                            //    // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + " and System Auto-generated Proforma Invoice # " + Refno + "');", true);

                            //    StrScript += " Details Saved for BL#" + txt_ablno.Text + "and System Auto-generated Proforma Invoice #" + Refno;

                            //}
                            //if (invgen == true && DebitOS == true)
                            //{
                            //    // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + " and System Auto-generated Proforma Invoice # " + Refno + "');", true);

                            //    StrScript += " Details Saved for BL#" + txt_ablno.Text + "and System Auto-generated Proforma Invoice #" + Refno + "and Proforma OSDN#" + refnodebitOs;

                            //}
                            //if (DebitOS == true)
                            //{
                            //    // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + " and System Auto-generated Proforma Invoice # " + Refno + "');", true);

                            //    StrScript += " Details Saved for BL#" + txt_ablno.Text + "and System Auto-generated Proforma OSDN#" + refnodebitOs;

                            //}

                        }





                        if (Refno1 != 0 && Refno == 0)
                        {
                            StrScript += " . System Auto-generated Profoma Purchase Invoice # is " + Refno1;
                        }
                        if (Refno1 != 0 && Refno != 0)
                        {
                            StrScript += " and  Profoma Purchase Invoice # is " + Refno1;
                        }
                        if (refnodebitOs != 0)
                        {
                            StrScript += ". System Auto-generated Proforma OSDN # " + refnodebitOs;
                        }
                        if (refnocreditOs != 0)
                        {
                            StrScript += ". System Auto-generated Proforma OSCN # " + refnocreditOs;
                        }
                        /* if (str_trantype == "AE")
                         {
                             if (refnodebitOs != 0)
                             {
                                 StrScript +=  "and Proforma OSDN#" + refnodebitOs;
                             }
                         }
                         else if (str_trantype == "AI")
                         {
                             if (refnodebitOs != 0)
                             {
                                 StrScript += "and Proforma OSCN#" + refnodebitOs;
                             }
                         }*/


                        if (bolcuststat == true)
                        {
                            if (invgen == true && DebitOS == true && CreditOS == true)
                            {
                                StrScript += " State Name not Updated in Master,Kindly update Master Customer " + supplyto;
                            }
                            else
                            {
                                StrScript += " State Name not Updated in Master,Kindly update Master Customer " + supplyto + ",GST NOT Calculated Propertly";
                            }
                        }
                        if (bolcuststat1 == true)
                        {
                            StrScript += " Kindly update SUPPLY TO Name " + supplyto + ",GST NOT Calculated Propertly";
                        }
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "BL", "alertify.alert('" + StrScript + "');", true);

                        //  ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved')", true);
                        Btnshipper.Visible = true;
                        Mail4ODCDimension();
                        txtclear();
                    }
                    else
                    {
                      //  DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();

                        /*    da_obj_AEBLobj.UpdAIEBLDetailsAE(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(),
                                Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)), Convert.ToInt32(hf_intissuedid.Value), Convert.ToInt32(hf_intshipperid.Value),
                                Convert.ToInt32(hf_intconsid.Value), Convert.ToInt32(hf_intnotifyid1.Value), Convert.ToInt32(hf_intnotifyid2.Value),
                                Convert.ToInt32(hf_intchaid.Value), Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value),
                                Convert.ToInt32(hf_inttoid1.Value), Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value), Convert.ToInt32(hf_intbyid3.Value),
                                Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight), str_curr.ToUpper(), str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs),
                                str_pkgs, Convert.ToDouble(rateclass), str_citemno, Convert.ToDouble(str_grosswt), Convert.ToDouble(str_chargewt), str_descn.ToUpper(),
                                str_nomination.ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDouble(oldchargewt), txt_rcamt.Text,
                                Convert.ToInt32(hf_salesPID.Value), Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                Convert.ToInt32(Session["LoginDivisionId"].ToString()), str_wttype, Convert.ToInt32(txt_dvca.Text.Trim()), Convert.ToInt32(txt_dvcus.Text.Trim()),
                                txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text, Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.Trim().ToUpper(), Convert.ToDouble(str_netwt), switchbl.ToString());
                            */




                        da_obj_AEBLobj.UpdAIEBLDetailsAEnew(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(),
                           Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)), Convert.ToInt32(hf_intissuedid.Value), Convert.ToInt32(hf_intshipperid.Value),
                           Convert.ToInt32(hf_intconsid.Value), Convert.ToInt32(hf_intnotifyid1.Value), Convert.ToInt32(hf_intnotifyid2.Value),
                           Convert.ToInt32(hf_intchaid.Value), Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value),
                           Convert.ToInt32(hf_inttoid1.Value), Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value), Convert.ToInt32(hf_intbyid3.Value),
                           Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight), str_curr.ToUpper(), str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs),
                           str_pkgs, Convert.ToDouble(rateclass), str_citemno, Convert.ToDouble(str_grosswt), Convert.ToDouble(str_chargewt), str_descn.ToUpper(),
                           str_nomination.ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDouble(oldchargewt), txt_rcamt.Text,
                           Convert.ToInt32(hf_salesPID.Value), Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                           Convert.ToInt32(Session["LoginDivisionId"].ToString()), str_wttype, Convert.ToInt32(txt_dvca.Text.Trim()), Convert.ToInt32(txt_dvcus.Text.Trim()),
                           txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text, Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.Trim().ToUpper(), Convert.ToDouble(str_netwt), switchbl.ToString(), Convert.ToInt32(str_noofpallet));

                        da_obj_FIBLobj.UpdateBookingnew(hf_bookingno.Value.ToUpper(), hf_hawblno.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));




                        da_obj_AEBLobj.UpdAETextDtlsnew(txt_shipper.Text.ToUpper(), txt_saddress.Text.ToUpper(), txt_consignee.Text.ToUpper(), txt_caddress.Text.ToUpper(), txt_notifyparty1.Text.ToUpper(), txt_naddress1.Text.ToUpper(), txt_notifyparty2.Text.ToUpper(), txt_naddress2.Text.ToUpper(), txt_fromport.Text.ToUpper(), txt_toport.Text.ToUpper(), txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());

                        da_obj_AEBLobj.DelAIEBLDimension(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        InsertDimension();
                        da_obj_AEBLobj.updaeblminwt(jobno, hf_hawblno.Value.ToUpper(), Convert.ToDouble(txt_min.Text), Convert.ToInt32(Session["LoginBranchid"]));
                        da_obj_AEBLobj.UpdAETextDtlsOurbl(hf_hawblno.Value.ToUpper(), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), ourbl);
                        //shipperinvoiceinsert();


                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 6, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype + txt_ablno.Text.Trim().ToUpper() + "Bookingno :" + hf_bookingno.Value.ToUpper() + "Upd" + txt_min.Text);
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                        btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        Mail4ODCDimension();
                        txtclear();
                    }
                }
                else
                {

                    if (hf_bookingno.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select the Booking #')", true);
                        txt_bookno.Focus();
                        return;
                    }

                    if ((string.IsNullOrEmpty(txt_bookno.Text) || txt_bookno.Text == "0") && str_trantype=="AE")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select the correct Booking Number')", true);
                        txt_bookno.Focus();
                        return;
                    }


                    if (txt_bookno.Text == "0"  && str_trantype == "AE")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please select the Booking NO')", true);
                        return;
                    }


                    if (hf_salesPID.Value == "")
                    {
                        hf_salesPID.Value = "0";
                    }
                    str_trantype = Session["StrTranType"].ToString();
                    //str_da1 = Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)).ToString();
                    if (btn_save.ToolTip == "Save")
                    {
                        if ((hf_bookingno.Value == "0" || hf_bookingno.Value == "") && str_trantype == "AE")
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select the Booking #')", true);
                            txt_bookno.Focus();
                            return;
                        }

                      //  DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
                        if (chk_nomin.Checked == true)
                        {
                            if (!string.IsNullOrEmpty(hf_bookingno.Value))
                            {
                                /* da_obj_AEBLobj.InsAEBLDetails(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)),
                                     Convert.ToInt32(hf_intissuedid.Value), Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value),
                                     Convert.ToInt32(hf_intnotifyid1.Value), Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value),
                                     Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value),
                                     Convert.ToInt32(hf_inttoid1.Value), Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value),
                                     Convert.ToInt32(hf_intbyid3.Value), Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight), str_curr.ToUpper(),
                                     str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass), str_citemno, Convert.ToDouble(str_grosswt),
                                     Convert.ToDouble(str_chargewt), str_descn.ToUpper(), "N", str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                     txt_rcamt.Text, Convert.ToInt32(hf_salesPID.Value), Convert.ToInt32(hf_IntCOMMODITY.Value),
                                     Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), str_wttype,
                                     Convert.ToInt32(txt_dvca.Text.Trim()), Convert.ToInt32(txt_dvcus.Text.Trim()), txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text,
                                     Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.ToUpper(), Convert.ToDouble(str_netwt));

                                 */



                                da_obj_AEBLobj.InsAEBLDetailsnew(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)),
                                   Convert.ToInt32(hf_intissuedid.Value), Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value),
                                   Convert.ToInt32(hf_intnotifyid1.Value), Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value),
                                   Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value),
                                   Convert.ToInt32(hf_inttoid1.Value), Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value),
                                   Convert.ToInt32(hf_intbyid3.Value), Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight), str_curr.ToUpper(),
                                   str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass), str_citemno, Convert.ToDouble(str_grosswt),
                                   Convert.ToDouble(str_chargewt), str_descn.ToUpper(), "N", str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                   txt_rcamt.Text, Convert.ToInt32(hf_salesPID.Value), Convert.ToInt32(hf_IntCOMMODITY.Value),
                                   Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), str_wttype,
                                   Convert.ToInt32(txt_dvca.Text.Trim()), Convert.ToInt32(txt_dvcus.Text.Trim()), txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text,
                                   Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.ToUpper(), Convert.ToDouble(str_netwt), Convert.ToInt32(str_noofpallet));

                                da_obj_FIBLobj.UpdateBooking(hf_bookingno.Value.ToUpper(), hf_hawblno.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                // da_obj_AEBLobj.UpdAETextDtlsOurbl(hf_hawblno.Value.ToUpper(), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), ourbl);
                                //shipperinvoiceinsert();
                            }
                            else
                            {
                                /*da_obj_AEBLobj.InsAEBLDetails(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(),
                                    Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)), Convert.ToInt32(hf_intissuedid.Value),
                                    Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value), Convert.ToInt32(hf_intnotifyid1.Value),
                                    Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value), Convert.ToInt32(hf_intfromid.Value),
                                    Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value), Convert.ToInt32(hf_inttoid1.Value), Convert.ToInt32(hf_intbyid2.Value),
                                    Convert.ToInt32(hf_inttoid2.Value), Convert.ToInt32(hf_intbyid3.Value), Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight),
                                    str_curr.ToUpper(), str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass), str_citemno,
                                    Convert.ToDouble(str_grosswt), Convert.ToDouble(str_chargewt), str_descn.ToUpper(), "F", str_trantype,
                                    Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_rcamt.Text, Convert.ToInt32(hf_salesPID.Value),
                                    Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                    Convert.ToInt32(Session["LoginDivisionId"].ToString()), str_wttype, Convert.ToInt32(txt_dvca.Text), Convert.ToInt32(txt_dvcus.Text),
                                    txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text, Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.ToUpper(), Convert.ToDouble(str_netwt));
                                */



                                da_obj_AEBLobj.InsAEBLDetailsnew(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(),
                                   Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)), Convert.ToInt32(hf_intissuedid.Value),
                                   Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value), Convert.ToInt32(hf_intnotifyid1.Value),
                                   Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value), Convert.ToInt32(hf_intfromid.Value),
                                   Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value), Convert.ToInt32(hf_inttoid1.Value), Convert.ToInt32(hf_intbyid2.Value),
                                   Convert.ToInt32(hf_inttoid2.Value), Convert.ToInt32(hf_intbyid3.Value), Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight),
                                   str_curr.ToUpper(), str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass), str_citemno,
                                   Convert.ToDouble(str_grosswt), Convert.ToDouble(str_chargewt), str_descn.ToUpper(), "F", str_trantype,
                                   Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_rcamt.Text, Convert.ToInt32(hf_salesPID.Value),
                                   Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                   Convert.ToInt32(Session["LoginDivisionId"].ToString()), str_wttype, Convert.ToInt32(txt_dvca.Text), Convert.ToInt32(txt_dvcus.Text),
                                   txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text, Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.ToUpper(), Convert.ToDouble(str_netwt), Convert.ToInt32(str_noofpallet));

                                da_obj_FIBLobj.UpdateBooking(hf_bookingno.Value.ToUpper(), hf_hawblno.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                            }
                        }
                        else
                        {
                            if (hf_salesPID.Value == "")
                            {
                                hf_salesPID.Value = "0";
                            }
                            if (hf_bookingno.Value == "0" || hf_bookingno.Value == "")
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select the Booking #')", true);
                                txt_bookno.Focus();
                                return;
                            }

                            /* da_obj_AEBLobj.InsAEBLDetails(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)),
                                 Convert.ToInt32(hf_intissuedid.Value), Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value),
                                 Convert.ToInt32(hf_intnotifyid1.Value), Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value),
                                 Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value),
                                 Convert.ToInt32(hf_inttoid1.Value), Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value),
                                 Convert.ToInt32(hf_intbyid3.Value), Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight), str_curr.ToUpper(),
                                 str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass), str_citemno, Convert.ToDouble(str_grosswt),s
                                 Convert.ToDouble(str_chargewt), str_descn.ToUpper(), "F", str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_rcamt.Text,
                                 Convert.ToInt32(hf_salesPID.Value), Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                 Convert.ToInt32(Session["LoginDivisionId"].ToString()), str_wttype, Convert.ToInt32(txt_dvca.Text), Convert.ToInt32(txt_dvcus.Text),
                                 txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text, Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.ToUpper(), Convert.ToDouble(str_netwt));
                             */




                            da_obj_AEBLobj.InsAEBLDetailsnew(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)),
                               Convert.ToInt32(hf_intissuedid.Value), Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value),
                               Convert.ToInt32(hf_intnotifyid1.Value), Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value),
                               Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value),
                               Convert.ToInt32(hf_inttoid1.Value), Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value),
                               Convert.ToInt32(hf_intbyid3.Value), Convert.ToInt32(hf_inttoid3.Value), Convert.ToChar(str_freight), str_curr.ToUpper(),
                               str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass), str_citemno, Convert.ToDouble(str_grosswt),
                               Convert.ToDouble(str_chargewt), str_descn.ToUpper(), "F", str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_rcamt.Text,
                               Convert.ToInt32(hf_salesPID.Value), Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                               Convert.ToInt32(Session["LoginDivisionId"].ToString()), str_wttype, Convert.ToInt32(txt_dvca.Text), Convert.ToInt32(txt_dvcus.Text),
                               txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text, Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.ToUpper(), Convert.ToDouble(str_netwt), Convert.ToInt32(str_noofpallet));
                            da_obj_FIBLobj.UpdateBooking(hf_bookingno.Value.ToUpper(), hf_hawblno.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }

                        InsertDimension();

                        da_obj_AEBLobj.UpdAETextDtlsnew(txt_shipper.Text.ToUpper(), txt_saddress.Text.ToUpper(), txt_consignee.Text.ToUpper(), txt_caddress.Text.ToUpper(), txt_notifyparty1.Text.ToUpper(), txt_naddress1.Text.ToUpper(), txt_notifyparty2.Text.ToUpper(), txt_naddress2.Text.ToUpper(), txt_fromport.Text.ToUpper(), txt_toport.Text.ToUpper(), txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                        //  da_obj_AEBLobj.UpdAETextDtlsOurbl(hf_hawblno.Value.ToUpper(), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), ourbl);
                        //shipperinvoiceinsert();

                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 8, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype + txt_ablno.Text.Trim().ToUpper() + "Save");




                        AutoInvoiceAI();
                        Autocnops();
                        autodebitOS();
                        autocreditOS();
                        string supplyto = "";
                        if (hid_SupplyTo.Value != "")
                        {
                            supplyto = da_obj_customerobj.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                            ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), supplyto);
                        }



                        StrScript += " Details Saved for HAWB # " + txt_ablno.Text.Trim().ToUpper();

                        if (Refno != 0)
                        {
                            StrScript += "and System Auto-generated Proforma Sales Invoice #" + Refno;
                        }
                        if (Refno1 != 0)
                        {
                            StrScript += "and System Auto-generated Profoma Purchase Invoice #" + Refno1;
                        }
                        if (refnodebitOs != 0)
                        {
                            StrScript += "and System Auto-generated Proforma OSDN#" + refnodebitOs;
                        }
                        if (refnocreditOs != 0)
                        {
                            StrScript += "and System Auto-generated Proforma OSCN#" + refnocreditOs;
                        }

                        /*if (invgen == false || DebitOS == false)
                        {
                            // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + "');", true);
                           
                        }*/
                        /*if (invgen == true && DebitOS == false)
                        {
                            // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + " and System Auto-generated Proforma Invoice # " + Refno + "');", true);

                            StrScript += " Details Saved for BL#" + txt_ablno.Text + "and System Auto-generated Proforma Invoice #" + Refno;

                        }*/
                        /* if (invgen == true && DebitOS == true)
                         {
                             // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + " and System Auto-generated Proforma Invoice # " + Refno + "');", true);

                             StrScript += " Details Saved for BL#" + txt_ablno.Text + "and System Auto-generated Proforma Invoice #" + Refno + "and Proforma OSDN#" + refnodebitOs;

                         }
                         if (DebitOS == true)
                         {
                             // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + " and System Auto-generated Proforma Invoice # " + Refno + "');", true);

                             StrScript += " Details Saved for BL#" + txt_ablno.Text + "and System Auto-generated Proforma OSDN#" + refnodebitOs;

                         }*/

                        if (bolcuststat == true)
                        {
                            StrScript += " State Name not Updated in Master,Kindly update Master Customer " + supplyto + ",GST NOT Calculated Propertly";
                        }
                        if (bolcuststat1 == true)
                        {
                            StrScript += " Kindly update SUPPLY TO Name " + supplyto + ",GST NOT Calculated Propertly";
                        }
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "BL", "alertify.alert('" + StrScript + "');", true);




                        //ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved')", true);
                        Mail4ODCDimension();
                        txtclear();
                    }
                    else
                    {

                        if (hf_salesPID.Value == "")
                        {
                            hf_salesPID.Value = "0";
                        }

                     //   DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
                        str_da1 = Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)).ToString();

                        /*da_obj_AEBLobj.UpdAIEBLDetails(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(), Convert.ToDateTime(str_da1),
                            Convert.ToInt32(hf_intissuedid.Value), Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value),
                            Convert.ToInt32(hf_intnotifyid1.Value), Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value),
                            Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value), Convert.ToInt32(hf_inttoid1.Value),
                            Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value), Convert.ToInt32(hf_intbyid3.Value), Convert.ToInt32(hf_inttoid3.Value),
                            Convert.ToChar(str_freight), str_curr.ToUpper(), str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass),
                            str_citemno, Convert.ToDouble(str_grosswt), Convert.ToDouble(str_chargewt), str_descn.ToUpper(), str_nomination.ToUpper(), str_trantype,
                            Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDouble(oldchargewt), txt_rcamt.Text, Convert.ToInt32(hf_salesPID.Value),
                            Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()),
                            str_wttype, Convert.ToInt32(txt_dvca.Text.Trim()), Convert.ToInt32(txt_dvcus.Text.Trim()), txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text,
                            Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.Trim().ToUpper(), Convert.ToDouble(str_netwt));


                        */




                        da_obj_AEBLobj.UpdAIEBLDetailsnew(Convert.ToInt32(txt_jobno.Text), hf_hawblno.Value.ToUpper(), Convert.ToDateTime(str_da1),
                         Convert.ToInt32(hf_intissuedid.Value), Convert.ToInt32(hf_intshipperid.Value), Convert.ToInt32(hf_intconsid.Value),
                         Convert.ToInt32(hf_intnotifyid1.Value), Convert.ToInt32(hf_intnotifyid2.Value), Convert.ToInt32(hf_intchaid.Value),
                         Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_intbyid1.Value), Convert.ToInt32(hf_inttoid1.Value),
                         Convert.ToInt32(hf_intbyid2.Value), Convert.ToInt32(hf_inttoid2.Value), Convert.ToInt32(hf_intbyid3.Value), Convert.ToInt32(hf_inttoid3.Value),
                         Convert.ToChar(str_freight), str_curr.ToUpper(), str_handling.ToUpper(), Convert.ToInt32(str_noofpkgs), str_pkgs, Convert.ToDouble(rateclass),
                         str_citemno, Convert.ToDouble(str_grosswt), Convert.ToDouble(str_chargewt), str_descn.ToUpper(), str_nomination.ToUpper(), str_trantype,
                         Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDouble(oldchargewt), txt_rcamt.Text, Convert.ToInt32(hf_salesPID.Value),
                         Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()),
                         str_wttype, Convert.ToInt32(txt_dvca.Text.Trim()), Convert.ToInt32(txt_dvcus.Text.Trim()), txt_chgcode.Text, str_wtf, str_oth, txt_inscurr.Text,
                         Convert.ToDouble(txt_insamt.Text), txt_othchg.Text.Trim().ToUpper(), Convert.ToDouble(str_netwt), Convert.ToInt32(str_noofpallet));


                        da_obj_FIBLobj.UpdateBookingnew(hf_bookingno.Value.ToUpper(), hf_hawblno.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        da_obj_AEBLobj.DelAIEBLDimension(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        da_obj_AEBLobj.UpdAETextDtlsnew(txt_shipper.Text.ToUpper(), txt_saddress.Text.ToUpper(), txt_consignee.Text.ToUpper(), txt_caddress.Text.ToUpper(), txt_notifyparty1.Text.ToUpper(), txt_naddress1.Text.ToUpper(), txt_notifyparty2.Text.ToUpper(), txt_naddress2.Text.ToUpper(), txt_fromport.Text.ToUpper(), txt_toport.Text.ToUpper(), txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                        InsertDimension();
                        //  da_obj_AEBLobj.UpdAETextDtlsOurbl(hf_hawblno.Value.ToUpper(), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), ourbl);
                        //shipperinvoiceinsert();

                        //dtdetails = feblobj.GetBookingDt(txt_bookno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        //hid_quto.Value = dtdetails.Rows[0]["quotno"].ToString();
                        //hid_buyingno.Value = dtdetails.Rows[0]["buyingno"].ToString();
                        //hid_intcustomerid.Value = dtdetails.Rows[0]["consigneeid"].ToString();

                        //AutoInvoiceAI();
                        //Autocnops();
                        //autodebitOS();
                        //autocreditOS();


                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 8, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype + txt_ablno.Text.Trim().ToUpper() + "Bookingno :" + hf_bookingno.Value.ToUpper() + "Upd");
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                        btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        Mail4ODCDimension();
                        txtclear();
                    }
                }


                btn_save.Enabled = false;
                btn_save.ForeColor = System.Drawing.Color.Gray;
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void assign()
        {
            str_issuedon = txt_dtissueon.Text;
            str_issuedat = txt_issueat.Text.ToUpper();
            str_shipper = txt_shipper.Text.ToUpper();
            str_consignee = txt_consignee.Text.ToUpper();
            str_notifyparty1 = txt_notifyparty1.Text.ToUpper();
            str_notifyparty2 = txt_notifyparty2.Text.ToUpper();
            str_cnf = txt_cnf.Text.ToUpper();
            str_fromport = txt_fromport.Text.ToUpper();
            str_toport = txt_toport.Text.ToUpper();
            str_carrier1 = txt_by1.Text.ToUpper();
            str_pod1 = txt_to1.Text.ToUpper();
            str_carrier2 = txt_by2.Text.ToUpper();
            str_pod2 = txt_to2.Text.ToUpper();
            str_carrier3 = txt_by3.Text.ToUpper();
            str_pod3 = txt_to3.Text.ToUpper();
            str_curr = txt_curr.Text.ToUpper();
            str_handling = txt_handling.Text.ToUpper();
            str_noofpkgs = txt_packages.Text;
            str_pkgs = ddl_cmbpkgdesc.SelectedValue;
            rateclass = Convert.ToDouble(txt_rate.Text);
            str_citemno = txt_citemno.Text.ToUpper();
            str_grosswt = txt_gross.Text;
            if (txt_volwt.Text != "")
            {
                str_netwt = txt_volwt.Text;
            }
            else
            {
                str_netwt = "0";
            }
            if (txt_charge.Text != "")
            {
                str_chargewt = txt_charge.Text;
            }
            else
            {
                str_chargewt = "0";
            }
            str_descn = txt_desc.Text.ToUpper();

            if (ddl_cmbfreight.SelectedValue == "PrePaid")
            {
                str_freight = "P";
            }
            else
            {
                str_freight = "C";
            }
            if (chk_nomin.Checked == true)
            {
                if (txt_bookno.Text == "0")
                {
                    txt_bookno.Text = "";
                }
                if (txt_bookno.Text != "")
                {
                    str_nomination = "N";
                }
                else
                {
                    str_nomination = "F";
                }
            }
            else
            {
                str_nomination = "F";
            }
            if (ddl_cmbwttype.SelectedValue == "K")
            {
                str_wttype = "K";
            }
            else
            {
                str_wttype = "L";
            }
            if (ddl_cmbwt.SelectedValue == "PrePaid")
            {
                str_wtf = "P";
            }
            else
            {
                str_wtf = "C";
            }

            if (ddl_cmboth.SelectedValue == "PrePaid")
            {
                str_oth = "P";
            }
            else
            {
                str_oth = "C";
            }
            if (txt_pallet.Text != "")
            {
                str_noofpallet = txt_pallet.Text;
            }
            else
            {
                str_noofpallet = "0";
            }
        }

        public void GetJobDt(int jobno)
        {
            try
            {
                str_trantype = Session["StrTranType"].ToString();
                string str_agent;
                string str_voyage;
                int int_agentid;
                string str_aloc;
                DateTime jobdate;

              //  DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                DataTable Dt = new DataTable();
                if (str_trantype == "AE")
                {
                    Dt = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(hf_jobno.Value), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    Dt = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(hf_jobno.Value), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                }
                if (Dt.Rows.Count != 0)
                {
                 //   DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                    str_agent = Dt.Rows[0][1].ToString();
                    str_voyage = Dt.Rows[0][6].ToString();
                    int_agentid = Convert.ToInt32(Dt.Rows[0][8].ToString());
                    str_aloc = da_obj_customerobj.GetCustlocation(int_agentid);
                    jobdate = Convert.ToDateTime(Dt.Rows[0]["jobdate"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_shipper_TextChanged(object sender, EventArgs e)
        {
            /*  if (hf_intshipperid.Value == "0")
              {
                  ScriptManager.RegisterStartupScript(txt_shipper, typeof(TextBox), "DataFound", "alertify.alert('Invalid Shipper')", true);
                  txt_shipper.Text = "";
                  txt_saddress.Text = "";
                  txt_shipper.Focus();
                  return;
              }
              else
              {
                  DataTable obj_dt = new DataTable();
                  DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                  custype = "C";
                  obj_dt = da_obj_customerobj.GetLikeCustomer(txt_shipper.Text, custype);
                  if (obj_dt.Rows.Count > 0)
                  {
                      str_name = obj_dt.Rows[0][0].ToString();
                      str_custadd = obj_dt.Rows[0][2].ToString();
                      hf_intshipperid.Value = obj_dt.Rows[0][3].ToString();
                      str_saddress = obj_dt.Rows[0][4].ToString();
                      //txt_shipper.Text = str_name;
                      txt_saddress.Text = str_custadd;
                  }
              }*/
            DataTable obj_dt = new DataTable();
           // DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            string str_cadd;
            obj_dt = da_obj_Customer.GetexactCustomer(txt_shipper.Text, "C");
            if (obj_dt.Rows.Count > 0 && hf_intshipperid.Value != "0")
            {
                txt_cnf.Text = txt_shipper.Text;
                hf_intchaid.Value = hf_intshipperid.Value;
                //str_name = obj_dt.Rows[0][0].ToString();
                //str_custadd = obj_dt.Rows[0][2].ToString();
                //hf_intshipperid.Value = obj_dt.Rows[0][3].ToString();
                //str_saddress = obj_dt.Rows[0][4].ToString();
                ////txt_shipper.Text = str_name;
                //txt_saddress.Text = str_custadd;
            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_shipper, typeof(TextBox), "DataFound", "alertify.alert('Invalid Shipper')", true);
                txt_shipper.Text = "";
                txt_saddress.Text = "";
                txt_shipper.Focus();
                Blrr = true;
                return;
            }


        }

        protected void txt_consignee_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

          //  DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            string str_cadd;
            dt = da_obj_Customer.GetexactCustomer(txt_consignee.Text, "C");
            if (dt.Rows.Count > 0 && hf_intconsid.Value != "0")
            //if (hf_intconsid.Value == "0")
            {
                //str_name = dt.Rows[0][0].ToString();
                //str_cadd = dt.Rows[0][2].ToString();
                //hf_intconsid.Value = dt.Rows[0][3].ToString();
                //str_saddress = dt.Rows[0][4].ToString();
                ////txt_consignee.Text = str_name;
                //txt_caddress.Text = str_cadd;
                //UserRights();

            }
            else
            {
                //DataTable obj_dt = new DataTable();
                //DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                //string str_cadd;
                //custype = "C";
                //obj_dt = da_obj_customerobj.GetLikeCustomer(txt_consignee.Text, custype);
                //if (obj_dt.Rows.Count > 0)
                //{

                //}
                ScriptManager.RegisterStartupScript(txt_consignee, typeof(TextBox), "DataFound", "alertify.alert('Invalid Consignee')", true);
                txt_consignee.Text = "";
                txt_caddress.Text = "";
                txt_consignee.Focus();
                Blrr = true;
                return;

            }
        }

        protected void txt_notifyparty1_TextChanged(object sender, EventArgs e)
        {
            /*  if (hf_intnotifyid1.Value == "0")
              {
                  ScriptManager.RegisterStartupScript(txt_notifyparty1, typeof(TextBox), "DataFound", "alertify.alert('Invalid Notify Party I')", true);
                  txt_notifyparty1.Text = "";
                  txt_naddress1.Text = "";
                  txt_notifyparty1.Focus();
                  return;
              }
              else
              {
                  DataTable obj_dt = new DataTable();
                  DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                  string str_cadd;
                  custype = "C";
                  obj_dt = da_obj_customerobj.GetLikeCustomer(txt_notifyparty1.Text, custype);
                  if (obj_dt.Rows.Count > 0)
                  {

                      str_name = obj_dt.Rows[0][0].ToString();
                      str_cadd = obj_dt.Rows[0][2].ToString();
                      hf_intconsid.Value = obj_dt.Rows[0][3].ToString();
                      str_saddress = obj_dt.Rows[0][4].ToString();
                      //txt_consignee.Text = str_name;
                      txt_naddress1.Text = str_cadd;
                  }
              }*/
            DataTable obj_dt = new DataTable();
          //  DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            string str_cadd;
            obj_dt = da_obj_Customer.GetexactCustomer(txt_notifyparty1.Text, "C");
            if (obj_dt.Rows.Count > 0 && hf_intnotifyid1.Value != "0")
            {

                txt_notifyparty2.Text = txt_notifyparty1.Text;
                txt_naddress2.Text = txt_naddress1.Text;
                hf_intnotifyid2.Value = hf_intnotifyid1.Value;

                //str_name = obj_dt.Rows[0][0].ToString();
                //str_cadd = obj_dt.Rows[0][2].ToString();
                //hf_intconsid.Value = obj_dt.Rows[0][3].ToString();
                //str_saddress = obj_dt.Rows[0][4].ToString();
                ////txt_consignee.Text = str_name;
                //txt_naddress1.Text = str_cadd;
            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_notifyparty1, typeof(TextBox), "DataFound", "alertify.alert('Invalid Notify Party I')", true);
                txt_notifyparty1.Text = "";
                txt_naddress1.Text = "";
                txt_notifyparty1.Focus();
                Blrr = true;
                return;
            }

        }

        protected void txt_notifyparty2_TextChanged(object sender, EventArgs e)
        {
            /*if (hf_intnotifyid2.Value == "0")
            {
                ScriptManager.RegisterStartupScript(txt_notifyparty2, typeof(TextBox), "DataFound", "alertify.alert('Invalid Notify Party II')", true);
                txt_notifyparty2.Text = "";
                txt_naddress2.Text = "";
                txt_notifyparty2.Focus();
                return;
            }
            else
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                string str_cadd;
                custype = "C";
                obj_dt = da_obj_customerobj.GetLikeCustomer(txt_notifyparty2.Text, custype);
                if (obj_dt.Rows.Count > 0)
                {
                    str_name = obj_dt.Rows[0][0].ToString();
                    str_cadd = obj_dt.Rows[0][2].ToString();
                    hf_intconsid.Value = obj_dt.Rows[0][3].ToString();
                    str_saddress = obj_dt.Rows[0][4].ToString();
                    //txt_consignee.Text = str_name;
                    txt_naddress2.Text = str_cadd;
                }
            }*/
            DataTable obj_dt = new DataTable();
          //  DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            string str_cadd;
            obj_dt = da_obj_Customer.GetexactCustomer(txt_notifyparty2.Text, "C");
            if (obj_dt.Rows.Count > 0 && hf_intnotifyid2.Value != "0")
            {
                //str_name = obj_dt.Rows[0][0].ToString();
                //str_cadd = obj_dt.Rows[0][2].ToString();
                //hf_intconsid.Value = obj_dt.Rows[0][3].ToString();
                //str_saddress = obj_dt.Rows[0][4].ToString();
                ////txt_consignee.Text = str_name;
                //txt_naddress2.Text = str_cadd;
            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_notifyparty2, typeof(TextBox), "DataFound", "alertify.alert('Invalid Notify Party II')", true);
                txt_notifyparty2.Text = "";
                txt_naddress2.Text = "";
                txt_notifyparty2.Focus();
                Blrr = true;
                return;
            }

        }

        protected void txt_ablno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int jobno = 0, chargeid1 = 0;

                str_trantype = Session["StrTranType"].ToString();
              //  DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                DataTable Dt = new DataTable();
                if (txt_ablno.Text.Trim() == "")
                {

                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid HAWB NUMBER');", true);
                    txt_ablno.Text = "";
                    txt_ablno.Focus();
                    return;

                }

                Dt = da_obj_AEJobobj.GetLikeAIEJobMBLNo(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        if (txt_ablno.Text.Trim().ToUpper() == Dt.Rows[i][0].ToString().Trim().ToUpper())
                        {
                            txt_ablno.Text = "";
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid HAWB #')", true);
                            txt_ablno.Focus();
                            return;
                        }
                    }
                }
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                DataTable DtAIEDetails = AEBLobj.GetAIEDetail(txt_ablno.Text, trantype, bid, did);
                if (DtAIEDetails.Rows.Count > 0)
                {

                    jobno = Convert.ToInt32(DtAIEDetails.Rows[0]["jobno"].ToString());

                    if (DtAIEDetails.Rows[0]["accinfo"].ToString() != "")
                    {
                        txt_acc.Text = DtAIEDetails.Rows[0]["accinfo"].ToString();
                    }
                }

                DataTable dtchrg = AEBLobj.SelAEBLChargeDtls(jobno, txt_ablno.Text, bid);


                if (dtchrg.Rows.Count > 0)
                {
                    string Cname = "";
                    double strAmount;
                    string PPCcVal;




                    EmptyGrid_Charge();
                    DataTable dttemp2 = new DataTable();
                    dttemp2.Columns.Add("charges");
                    dttemp2.Columns.Add("amount");
                    dttemp2.Columns.Add("ppcc");
                    dttemp2.Columns.Add("chargeid");

                    DataRow dr1;
                    for (int i = 0; i <= dtchrg.Rows.Count - 1; i++)
                    {
                        chargeid1 = Convert.ToInt32(dtchrg.Rows[i]["chargeid"]);
                        if (chargeid1 == 1)
                        {
                            Cname = "Valuation Charge";
                        }
                        else if (chargeid1 == 2)
                        {
                            Cname = "Total Other Charges Due Agent";
                        }
                        else if (chargeid1 == 3)
                        {
                            Cname = "Total Other Charges Due Carrier";
                        }

                        strAmount = Convert.ToDouble(dtchrg.Rows[i]["amount"].ToString());
                        ppcc = dtchrg.Rows[i]["ppcc"].ToString();

                        if (ppcc == "P")
                        {
                            PPCcVal = "Prepaid";

                        }
                        else
                        {
                            PPCcVal = "To-Collect";
                        }
                        dr1 = dttemp2.NewRow();
                        dr1[0] = Cname;
                        dr1[1] = strAmount.ToString("#,0.00");
                        dr1[2] = PPCcVal;
                        dr1[3] = chargeid1;

                        dttemp2.Rows.Add(dr1);
                    }

                    Grd_Charge.DataSource = dttemp2;
                    Grd_Charge.DataBind();

                    ViewState["CurrentData"] = dttemp2;
                }
                // btn_save.Text = "Update";
                if (btn_save.ToolTip == "Save")
                {
                    if (str_trantype == "AE")
                    {
                        getdetails(str_trantype);
                        if (txt_jobno.Text == "")
                        {
                            jobno = 0;
                            txt_min.Text = AIEBL.GetminValue(jobno, txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        }
                        else
                        {
                            txt_min.Text = AIEBL.GetminValue(Convert.ToInt32(txt_jobno.Text), txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        }

                    }
                    else
                    {
                        getdetails(str_trantype);

                    }
                }
                btn_back.Visible = true;
                btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        public void getabldateilsreuse()
        {
            try
            {
                int jobno = 0;
                str_trantype = Session["StrTranType"].ToString();
               // DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                DataTable Dt = new DataTable();
                Dt = da_obj_AEJobobj.GetLikeAIEJobMBLNo(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        if (txt_ablno.Text.Trim().ToUpper() == Dt.Rows[i][0].ToString().Trim().ToUpper())
                        {
                            txt_ablno.Text = "";

                            txt_jobno.Text = "";
                            txt_bookno.Text = "";
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid HAWB #')", true);
                            txt_ablno.Focus();
                            return;
                        }
                    }
                }
                if (btn_save.ToolTip == "Save")
                {
                    if (str_trantype == "AE")
                    {
                        getdetailsreuse(str_trantype);
                        if (txt_jobno.Text == "")
                        {
                            jobno = 0;
                            txt_min.Text = AIEBL.GetminValue(jobno, txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        }
                        else
                        {
                            txt_min.Text = AIEBL.GetminValue(Convert.ToInt32(txt_jobno.Text), txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        }

                    }
                    else
                    {
                        getdetailsreuse(str_trantype);

                    }
                }

                txt_ablno.Text = "";
                txt_jobno.Text = "";
                txt_bookno.Text = "";

                btn_back.Visible = true;
                btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void getdetails(string chrType)
        {
            try
            {
              //  DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
                DataTable Dt_AIEDetails = new DataTable();
                Dt_AIEDetails = da_obj_AEBLobj.GetAIEDetail(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                int sloc;

                if (Dt_AIEDetails.Rows.Count > 0)
                {
                    string str_saddress;
                    string str_caddress;
                    int cloc, n2loc, c1loc, c2loc, c3loc, cnloc, n1loc;
                    string n1address, n2address, carr1address, carr2address, carr3address, cnfaddress;






                    
                    txt_jobno.Text = "";
                    txt_bookno.Text = "";
                    txt_jobno.Text = Dt_AIEDetails.Rows[0][0].ToString();
                    txt_dtissueon.Text = Utility.fn_ConvertDate(Dt_AIEDetails.Rows[0][1].ToString());
                    txt_issueat.Text = Dt_AIEDetails.Rows[0][2].ToString();
                    txt_shipper.Text = Dt_AIEDetails.Rows[0][3].ToString();
                    txt_consignee.Text = Dt_AIEDetails.Rows[0][4].ToString();
                    txt_notifyparty1.Text = Dt_AIEDetails.Rows[0][5].ToString();
                    txt_notifyparty2.Text = Dt_AIEDetails.Rows[0][6].ToString();
                    txt_cnf.Text = Dt_AIEDetails.Rows[0][7].ToString();
                    txt_fromport.Text = Dt_AIEDetails.Rows[0][8].ToString();
                    txt_toport.Text = Dt_AIEDetails.Rows[0][9].ToString();
                    txt_by1.Text = Dt_AIEDetails.Rows[0][10].ToString();
                    txt_to1.Text = Dt_AIEDetails.Rows[0][11].ToString();
                    txt_by2.Text = Dt_AIEDetails.Rows[0][12].ToString();
                    txt_to2.Text = Dt_AIEDetails.Rows[0][13].ToString();
                    txt_by3.Text = Dt_AIEDetails.Rows[0][14].ToString();
                    txt_to3.Text = Dt_AIEDetails.Rows[0][15].ToString();
                    str_freight = Dt_AIEDetails.Rows[0][16].ToString();
                    txt_curr.Text = Dt_AIEDetails.Rows[0][17].ToString();
                    txt_handling.Text = Dt_AIEDetails.Rows[0][18].ToString();
                    txt_packages.Text = Dt_AIEDetails.Rows[0][19].ToString();
                    ddl_cmbpkgdesc.SelectedValue = Dt_AIEDetails.Rows[0][20].ToString();
                    txt_rate.Text = Dt_AIEDetails.Rows[0][21].ToString();
                    txt_citemno.Text = Dt_AIEDetails.Rows[0][22].ToString();
                    txt_gross.Text = Convert.ToDecimal(Dt_AIEDetails.Rows[0][23]).ToString("#,0.000");
                    txt_volwt.Text = Convert.ToDecimal(Dt_AIEDetails.Rows[0]["volwt"]).ToString("#,0.000");
                    txt_charge.Text = Convert.ToDecimal(Dt_AIEDetails.Rows[0][24]).ToString("#,0.000");
                    oldchargewt = Convert.ToDouble(Dt_AIEDetails.Rows[0][24].ToString());
                    txt_desc.Text = Dt_AIEDetails.Rows[0][25].ToString();
                    str_nomination = Dt_AIEDetails.Rows[0][26].ToString();
                    sloc = Convert.ToInt32(Dt_AIEDetails.Rows[0][27].ToString());

                    txt_min.Text = Dt_AIEDetails.Rows[0]["minwt"].ToString().ToString();
                    str_saddress = da_obj_portobj.GetPortname(sloc);

                    // txt_saddress.Text = da_obj_customerobj.GetCustomerAddress(txt_shipper.Text, "Shipper", str_saddress);
                    cloc = Convert.ToInt32(Dt_AIEDetails.Rows[0][28].ToString());
                    str_caddress = da_obj_portobj.GetPortname(cloc);
                    txt_saddress.Text = Dt_AIEDetails.Rows[0]["saddress"].ToString().ToString();
                    // txt_caddress.Text = da_obj_customerobj.GetCustomerAddress(txt_consignee.Text, "Consignee", str_caddress);
                    txt_caddress.Text = Dt_AIEDetails.Rows[0]["caddress"].ToString().ToString();
                    n1loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][29].ToString());
                    n1address = da_obj_portobj.GetPortname(n1loc);
                    // txt_naddress1.Text = da_obj_customerobj.GetCustomerAddress(txt_notifyparty1.Text, "Notify Party", n1address);
                    txt_naddress1.Text = Dt_AIEDetails.Rows[0]["n1address"].ToString().ToString();
                    n2loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][30].ToString());
                    n2address = da_obj_portobj.GetPortname(n2loc);
                    //  txt_naddress2.Text = da_obj_customerobj.GetCustomerAddress(txt_notifyparty2.Text, "Notify Party", n2address);
                    txt_naddress2.Text = Dt_AIEDetails.Rows[0]["n2address"].ToString().ToString();
                    c1loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][32].ToString());
                    carr1address = da_obj_portobj.GetPortname(c1loc);
                    c2loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][33].ToString());
                    carr2address = da_obj_portobj.GetPortname(c2loc);
                    c3loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][34].ToString());
                    carr3address = da_obj_portobj.GetPortname(c3loc);
                    cnloc = Convert.ToInt32(Dt_AIEDetails.Rows[0][31].ToString());
                    cnfaddress = da_obj_portobj.GetPortname(cnloc);
                    txt_ablno.Text = Dt_AIEDetails.Rows[0][35].ToString().Trim().ToUpper();
                    txt_rcamt.Text = Dt_AIEDetails.Rows[0]["rcamt"].ToString();
                    hf_intshipperid.Value = Dt_AIEDetails.Rows[0]["shipperid"].ToString();
                    hf_intconsid.Value = Dt_AIEDetails.Rows[0]["consigneeid"].ToString();
                    hf_intnotifyid1.Value = Dt_AIEDetails.Rows[0]["notifyparty1id"].ToString();
                    hf_intnotifyid2.Value = Dt_AIEDetails.Rows[0]["notifyparty2id"].ToString();
                    hf_intchaid.Value = Dt_AIEDetails.Rows[0]["cnfid"].ToString();
                    hf_intfromid.Value = Dt_AIEDetails.Rows[0]["fromportid"].ToString();
                    hf_inttoid.Value = Dt_AIEDetails.Rows[0]["toportid"].ToString();
                    hf_inttoid1.Value = Dt_AIEDetails.Rows[0]["pod1id"].ToString();
                    hf_inttoid2.Value = Dt_AIEDetails.Rows[0]["pod2id"].ToString();
                    hf_inttoid3.Value = Dt_AIEDetails.Rows[0]["pod3id"].ToString();
                    hf_intbyid1.Value = Dt_AIEDetails.Rows[0]["carrier1id"].ToString();
                    hf_intbyid2.Value = Dt_AIEDetails.Rows[0]["carrier2id"].ToString();
                    hf_intbyid3.Value = Dt_AIEDetails.Rows[0]["carrier3id"].ToString();
                    hf_intissuedid.Value = Dt_AIEDetails.Rows[0]["issuedatid"].ToString();
                    txt_chgcode.Text = Dt_AIEDetails.Rows[0]["chgcode"].ToString();
                    if (!string.IsNullOrEmpty(Dt_AIEDetails.Rows[0]["pallet"].ToString()))
                    {
                        txt_pallet.Text = Dt_AIEDetails.Rows[0]["pallet"].ToString();
                    }
                    else
                    {
                        txt_pallet.Text = "0";
                    }
                    str_wtf = Dt_AIEDetails.Rows[0]["wtval"].ToString();
                    if (str_wtf == "P")
                    {
                        ddl_cmbwt.SelectedValue = "PrePaid";
                    }
                    else
                    {
                        //ddl_cmbwt.SelectedValue = "To-Collect";
                        ddl_cmbwt.SelectedValue = "Collect";
                    }
                    str_oth = Dt_AIEDetails.Rows[0]["otherval"].ToString();
                    if (str_oth == "P")
                    {
                        ddl_cmboth.SelectedValue = "PrePaid";
                    }
                    else
                    {
                        //  ddl_cmboth.SelectedValue = "To-Collect";

                        ddl_cmboth.SelectedValue = "Collect";
                    }
                    txt_dvca.Text = Dt_AIEDetails.Rows[0]["dvl"].ToString();
                    txt_dvcus.Text = Dt_AIEDetails.Rows[0]["dvc"].ToString();
                    txt_inscurr.Text = Dt_AIEDetails.Rows[0]["inscurr"].ToString();
                    txt_insamt.Text = Dt_AIEDetails.Rows[0]["insamt"].ToString();
                    txt_othchg.Text = Dt_AIEDetails.Rows[0]["otherchg"].ToString();
                    str_wttype = Dt_AIEDetails.Rows[0]["wttype"].ToString();

                    if (str_wttype == "K")
                    {
                        ddl_cmbwttype.SelectedValue = "K";
                    }
                    else
                    {
                        ddl_cmbwttype.SelectedValue = "L";
                    }
                    if (str_trantype == "AE")
                    {
                        if (Dt_AIEDetails.Rows[0]["ourbl"].ToString() == "Y")
                        {
                            chk_directbl.Checked = true;
                        }
                        else
                        {
                            chk_directbl.Checked = false;
                        }
                    }

                    DataTable dt;
                    //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txt_fromport.Text.ToUpper(), Session["StrTranType"].ToString());
                    fromportflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_toport.Text.ToUpper(), Session["StrTranType"].ToString());
                    toportflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_to1.Text.ToUpper(), Session["StrTranType"].ToString());
                    toflag1.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_to2.Text.ToUpper(), Session["StrTranType"].ToString());
                    toflag2.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_to3.Text.ToUpper(), Session["StrTranType"].ToString());
                    finaldesflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_issueat.Text.ToUpper(), Session["StrTranType"].ToString());
                    issuedatflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    txt_bookno.Text = da_obj_FIBLobj.GetBookinkNo(txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    DataTable dtdetails = new DataTable();
                    //DataAccess.Masters.MasterCargo da_obj_cargoobj = new DataAccess.Masters.MasterCargo();
                    if (!string.IsNullOrEmpty(Dt_AIEDetails.Rows[0]["cargoid"].ToString()))
                    {
                        hf_IntCOMMODITY.Value = Dt_AIEDetails.Rows[0]["cargoid"].ToString();
                        txt_cargo.Text = da_obj_cargoobj.GetCargoname(Convert.ToInt32(hf_IntCOMMODITY.Value));
                    }
                    dtdetails.Reset();
                    dtdetails = new DataTable();
                    dtdetails = da_obj_FIBLobj.GetBookingDtls(txt_bookno.Text.ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtdetails.Rows.Count != 0)
                    {
                        hf_salesPID.Value = dtdetails.Rows[0]["salesid"].ToString();
                    }
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        if (str_nomination == "N")
                        {
                            chk_nomin.Checked = true;
                        }
                        else
                        {
                            chk_nomin.Checked = false;

                        }

                    }
                    else
                    {
                        if (str_nomination == "N")
                        {
                            chk_nomin.Checked = true;
                        }
                        else
                        {
                            // chk_nomin.Checked = false;
                            chk_nomin.Checked = true;
                        }

                    }


                    if (str_freight == "P")
                    {
                        ddl_cmbfreight.SelectedValue = "PrePaid";
                    }
                    else
                    {
                        //ddl_cmbfreight.SelectedValue = "To-Collect";

                        ddl_cmbfreight.SelectedValue = "Collect";
                    }
                    // btn_save.Text = "Update";

                    if (str_trantype == "AE")
                    {
                        if (Dt_AIEDetails.Rows[0]["switchbl"].ToString() == "Y")
                        {
                            chk_switchbl.Checked = true;
                        }
                        else
                        {

                            chk_switchbl.Checked = false;
                        }
                    }
                    Btnshipper.Visible = true;
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    btn_save.Enabled = true;
                    btn_save.ForeColor = System.Drawing.Color.White;

                    /*     TextBox obj_txt_length = (TextBox)e.Row.FindControl("txt_item_length");
                         TextBox obj_txt_breadth = (TextBox)e.Row.FindControl("txt_item_breadth");
                         TextBox obj_txt_width = (TextBox)e.Row.FindControl("txt_item_width");
                         TextBox obj_txt_piece = (TextBox)e.Row.FindControl("txt_item_piece");
                         TextBox obj_txt_cminch = (TextBox)e.Row.FindControl("txt_item_cminch");

                         DropDownList obj_ddl_cminch = (DropDownList)e.Row.FindControl("ddl_item_cminch");
                         */

                    //foreach (GridViewRow row in grd_grddimension.Rows)
                    //{
                    //    TextBox obj_txt_length = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_length");
                    //    TextBox obj_txt_breadth = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_breadth");
                    //    TextBox obj_txt_width = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_width");
                    //    TextBox obj_txt_piece = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_piece");
                    //    TextBox obj_txt_cminch = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_cminch");

                    //    DropDownList obj_ddl_cminch = (DropDownList)grd_grddimension.Rows[row.RowIndex].FindControl("cminch");


                    //    if (obj_ddl_cminch.SelectedValue == "")
                    //    {
                    //        return;
                    //    }

                    //    /*if (obj_ddl_cminch.SelectedValue == "Inch")
                    //    {
                    //        obj_ddl_cminch.SelectedValue = "I";
                    //    }
                    //    else
                    //    {
                    //        obj_ddl_cminch.SelectedValue = "C";
                    //    }*/

                    //    if (obj_ddl_cminch.SelectedValue == "I")
                    //    {
                    //        obj_ddl_cminch.SelectedValue = "I";
                    //    }
                    //    else
                    //    {
                    //        obj_ddl_cminch.SelectedValue = "C";
                    //    }
                    //}
                 //   DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                    DataTable DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (DtA_Details.Rows.Count > 0)
                    {
                        txt_mawbno.Text = DtA_Details.Rows[0][4].ToString();
                        //  txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                        txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                        txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                        txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                        // txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                        //  ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                        string status = DtA_Details.Rows[0][9].ToString();
                        txt_from.Text = DtA_Details.Rows[0][2].ToString();
                        txt_to.Text = DtA_Details.Rows[0][3].ToString();
                        txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                        txt_iatacarrier.Text = DtA_Details.Rows[0]["iatacarrier"].ToString();

                        if (status == "T")
                        {
                            cmbstatus.Text = "Collect";
                        }
                        else
                        {
                            cmbstatus.Text = "Prepaid";
                        }
                        txt_flightno2.Text = DtA_Details.Rows[0]["flightno2"].ToString();
                        if (DtA_Details.Rows[0]["flightdate2"].ToString() != "")
                        {
                            txt_dtfdate2.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0]["flightdate2"].ToString());
                        }
                        else
                        {
                            txt_dtfdate2.Text = "";
                        }
                    }
                    DataTable Dt_Dimension;
                    Dt_Dimension = da_obj_AEBLobj.GetAIEBLDimension(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (Dt_Dimension.Rows.Count > 0)
                    {
                        grd_grddimension.DataSource = Dt_Dimension;
                        grd_grddimension.DataBind();
                        for (int i = 0; i <= Dt_Dimension.Rows.Count - 1; i++)
                        {
                            DropDownList obj_ddl_cminch = (DropDownList)grd_grddimension.Rows[i].FindControl("cminch");
                            if (Dt_Dimension.Rows[i][4].ToString() == "Inch")
                            {
                                obj_ddl_cminch.SelectedValue = "I";
                            }
                            else
                            {
                                obj_ddl_cminch.SelectedValue = "C";
                            }

                        }
                        Session["dt_dimension"] = Dt_Dimension;
                    }
                    else
                    {
                        DataTable dt_temp = new DataTable();
                        dt_temp.Columns.Add("length");
                        dt_temp.Columns.Add("breadth");
                        dt_temp.Columns.Add("width");
                        dt_temp.Columns.Add("pieces");
                        dt_temp.Columns.Add("cminch");
                        DataRow dr = dt_temp.NewRow();
                        dt_temp.Rows.Add();
                        grd_grddimension.DataSource = dt_temp;
                        grd_grddimension.DataBind();
                    }

                    //DataAccess.CostingTemp objcos = new DataAccess.CostingTemp();
                    DataTable dtt = new DataTable();
                    dtt = objcos.AEBLSHIPPERINVOICEGET(txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype);
                    if (dtt.Rows.Count > 0)
                    {
                        Grid_shipperinvoice.DataSource = dtt;
                        Grid_shipperinvoice.DataBind();
                        Session["shipperinvoice"] = dtt;
                    }
                    else
                    {
                        DataTable dt_temp = new DataTable();
                        dt_temp.Columns.Add("Shipperinvoice");
                        DataRow dr = dt_temp.NewRow();
                        dt_temp.Rows.Add();
                        Grid_shipperinvoice.DataSource = dt_temp;
                        Grid_shipperinvoice.DataBind();
                    }
                    //fn_Empty_grdST();

                    for (int s = 1; s <= 6; s++)
                    {
                        //DataAccess.Accounts.Invoice da_obj_Invobj = new DataAccess.Accounts.Invoice();
                        DataTable Dt = new DataTable();

                        Dt = da_obj_Invobj.CheckIPDCWBL(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), s, "Kgs");
                        if (Dt.Rows.Count > 0)
                        {
                            txt_gross.Enabled = false;
                            txt_charge.Enabled = false;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        else
                        {
                            txt_gross.Enabled = true;
                            txt_charge.Enabled = true;
                        }
                    }
                    for (int s = 1; s <= 6; s++)
                    {
                       // DataAccess.Accounts.Invoice da_obj_Invobj = new DataAccess.Accounts.Invoice();
                        DataTable Dt = new DataTable();

                        Dt = da_obj_Invobj.CheckIPDCWBLShipperinvoice(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), s, "SI");
                        if (Dt.Rows.Count > 0)
                        {
                            Grid_shipperinvoice.Enabled = false;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        else
                        {
                            Grid_shipperinvoice.Enabled = true;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txt_shipper.Text) && !string.IsNullOrEmpty(txt_fromport.Text) && !string.IsNullOrEmpty(txt_consignee.Text) && !string.IsNullOrEmpty(txt_toport.Text))
                    {

                        if (hid_reuse.Value != "")
                        {
                            txtclear();
                        }
                        txt_gross.Enabled = true;
                        txt_charge.Enabled = true;
                    }
                    btn_save.Text = "Save";

                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        public void getdetailsreuse(string chrType)
        {
            try
            {
              //  DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
                DataTable Dt_AIEDetails = new DataTable();
                Dt_AIEDetails = da_obj_AEBLobj.GetAIEDetail(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                int sloc;

                if (Dt_AIEDetails.Rows.Count > 0)
                {
                    string str_saddress;
                    string str_caddress;
                    int cloc, n2loc, c1loc, c2loc, c3loc, cnloc, n1loc;
                    string n1address, n2address, carr1address, carr2address, carr3address, cnfaddress;

                    txt_jobno.Text = "";
                    txt_bookno.Text = "";
                    txt_jobno.Text = Dt_AIEDetails.Rows[0][0].ToString();
                    txt_dtissueon.Text = Utility.fn_ConvertDate(Dt_AIEDetails.Rows[0][1].ToString());
                    txt_issueat.Text = Dt_AIEDetails.Rows[0][2].ToString();
                    txt_shipper.Text = Dt_AIEDetails.Rows[0][3].ToString();
                    txt_consignee.Text = Dt_AIEDetails.Rows[0][4].ToString();
                    txt_notifyparty1.Text = Dt_AIEDetails.Rows[0][5].ToString();
                    txt_notifyparty2.Text = Dt_AIEDetails.Rows[0][6].ToString();
                    txt_cnf.Text = Dt_AIEDetails.Rows[0][7].ToString();
                    txt_fromport.Text = Dt_AIEDetails.Rows[0][8].ToString();
                    txt_toport.Text = Dt_AIEDetails.Rows[0][9].ToString();
                    txt_by1.Text = Dt_AIEDetails.Rows[0][10].ToString();
                    txt_to1.Text = Dt_AIEDetails.Rows[0][11].ToString();
                    txt_by2.Text = Dt_AIEDetails.Rows[0][12].ToString();
                    txt_to2.Text = Dt_AIEDetails.Rows[0][13].ToString();
                    txt_by3.Text = Dt_AIEDetails.Rows[0][14].ToString();
                    txt_to3.Text = Dt_AIEDetails.Rows[0][15].ToString();
                    str_freight = Dt_AIEDetails.Rows[0][16].ToString();
                    txt_curr.Text = Dt_AIEDetails.Rows[0][17].ToString();
                    txt_handling.Text = Dt_AIEDetails.Rows[0][18].ToString();
                    txt_packages.Text = Dt_AIEDetails.Rows[0][19].ToString();
                    ddl_cmbpkgdesc.SelectedValue = Dt_AIEDetails.Rows[0][20].ToString();
                    txt_rate.Text = Dt_AIEDetails.Rows[0][21].ToString();
                    txt_citemno.Text = Dt_AIEDetails.Rows[0][22].ToString();
                    txt_gross.Text = Convert.ToDecimal(Dt_AIEDetails.Rows[0][23]).ToString("#,0.000");
                    txt_volwt.Text = Convert.ToDecimal(Dt_AIEDetails.Rows[0]["volwt"]).ToString("#,0.000");
                    txt_charge.Text = Convert.ToDecimal(Dt_AIEDetails.Rows[0][24]).ToString("#,0.000");
                    oldchargewt = Convert.ToDouble(Dt_AIEDetails.Rows[0][24].ToString());
                    txt_desc.Text = Dt_AIEDetails.Rows[0][25].ToString();
                    str_nomination = Dt_AIEDetails.Rows[0][26].ToString();
                    sloc = Convert.ToInt32(Dt_AIEDetails.Rows[0][27].ToString());

                    txt_min.Text = Dt_AIEDetails.Rows[0]["minwt"].ToString().ToString();
                    str_saddress = da_obj_portobj.GetPortname(sloc);

                    txt_saddress.Text = da_obj_customerobj.GetCustomerAddress(txt_shipper.Text, "Shipper", str_saddress);
                    cloc = Convert.ToInt32(Dt_AIEDetails.Rows[0][28].ToString());
                    str_caddress = da_obj_portobj.GetPortname(cloc);
                    txt_caddress.Text = da_obj_customerobj.GetCustomerAddress(txt_consignee.Text, "Consignee", str_caddress);
                    n1loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][29].ToString());
                    n1address = da_obj_portobj.GetPortname(n1loc);
                    txt_naddress1.Text = da_obj_customerobj.GetCustomerAddress(txt_notifyparty1.Text, "Notify Party", n1address);
                    n2loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][30].ToString());
                    n2address = da_obj_portobj.GetPortname(n2loc);
                    txt_naddress2.Text = da_obj_customerobj.GetCustomerAddress(txt_notifyparty2.Text, "Notify Party", n2address);
                    c1loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][32].ToString());
                    carr1address = da_obj_portobj.GetPortname(c1loc);
                    c2loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][33].ToString());
                    carr2address = da_obj_portobj.GetPortname(c2loc);
                    c3loc = Convert.ToInt32(Dt_AIEDetails.Rows[0][34].ToString());
                    carr3address = da_obj_portobj.GetPortname(c3loc);
                    cnloc = Convert.ToInt32(Dt_AIEDetails.Rows[0][31].ToString());
                    cnfaddress = da_obj_portobj.GetPortname(cnloc);
                    txt_ablno.Text = Dt_AIEDetails.Rows[0][35].ToString().Trim().ToUpper();
                    txt_rcamt.Text = Dt_AIEDetails.Rows[0]["rcamt"].ToString();
                    hf_intshipperid.Value = Dt_AIEDetails.Rows[0]["shipperid"].ToString();
                    hf_intconsid.Value = Dt_AIEDetails.Rows[0]["consigneeid"].ToString();
                    hf_intnotifyid1.Value = Dt_AIEDetails.Rows[0]["notifyparty1id"].ToString();
                    hf_intnotifyid2.Value = Dt_AIEDetails.Rows[0]["notifyparty2id"].ToString();
                    hf_intchaid.Value = Dt_AIEDetails.Rows[0]["cnfid"].ToString();
                    hf_intfromid.Value = Dt_AIEDetails.Rows[0]["fromportid"].ToString();
                    hf_inttoid.Value = Dt_AIEDetails.Rows[0]["toportid"].ToString();
                    hf_inttoid1.Value = Dt_AIEDetails.Rows[0]["pod1id"].ToString();
                    hf_inttoid2.Value = Dt_AIEDetails.Rows[0]["pod2id"].ToString();
                    hf_inttoid3.Value = Dt_AIEDetails.Rows[0]["pod3id"].ToString();
                    hf_intbyid1.Value = Dt_AIEDetails.Rows[0]["carrier1id"].ToString();
                    hf_intbyid2.Value = Dt_AIEDetails.Rows[0]["carrier2id"].ToString();
                    hf_intbyid3.Value = Dt_AIEDetails.Rows[0]["carrier3id"].ToString();
                    hf_intissuedid.Value = Dt_AIEDetails.Rows[0]["issuedatid"].ToString();
                    txt_chgcode.Text = Dt_AIEDetails.Rows[0]["chgcode"].ToString();
                    if (!string.IsNullOrEmpty(Dt_AIEDetails.Rows[0]["pallet"].ToString()))
                    {
                        txt_pallet.Text = Dt_AIEDetails.Rows[0]["pallet"].ToString();
                    }
                    else
                    {
                        txt_pallet.Text = "0";
                    }
                    str_wtf = Dt_AIEDetails.Rows[0]["wtval"].ToString();
                    if (str_wtf == "P")
                    {
                        ddl_cmbwt.SelectedValue = "PrePaid";
                    }
                    else
                    {
                        //ddl_cmbwt.SelectedValue = "To-Collect";

                        ddl_cmbwt.SelectedValue = "Collect";
                    }
                    str_oth = Dt_AIEDetails.Rows[0]["otherval"].ToString();
                    if (str_oth == "P")
                    {
                        ddl_cmboth.SelectedValue = "PrePaid";
                    }
                    else
                    {
                        //  ddl_cmboth.SelectedValue = "To-Collect";

                        ddl_cmboth.SelectedValue = "Collect";
                    }
                    txt_dvca.Text = Dt_AIEDetails.Rows[0]["dvl"].ToString();
                    txt_dvcus.Text = Dt_AIEDetails.Rows[0]["dvc"].ToString();
                    txt_inscurr.Text = Dt_AIEDetails.Rows[0]["inscurr"].ToString();
                    txt_insamt.Text = Dt_AIEDetails.Rows[0]["insamt"].ToString();
                    txt_othchg.Text = Dt_AIEDetails.Rows[0]["otherchg"].ToString();
                    str_wttype = Dt_AIEDetails.Rows[0]["wttype"].ToString();

                    if (str_wttype == "K")
                    {
                        ddl_cmbwttype.SelectedValue = "K";
                    }
                    else
                    {
                        ddl_cmbwttype.SelectedValue = "L";
                    }

                    txt_bookno.Text = da_obj_FIBLobj.GetBookinkNo(txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    DataTable dtdetails = new DataTable();
                    //DataAccess.Masters.MasterCargo da_obj_cargoobj = new DataAccess.Masters.MasterCargo();
                    if (!string.IsNullOrEmpty(Dt_AIEDetails.Rows[0]["cargoid"].ToString()))
                    {
                        hf_IntCOMMODITY.Value = Dt_AIEDetails.Rows[0]["cargoid"].ToString();
                        txt_cargo.Text = da_obj_cargoobj.GetCargoname(Convert.ToInt32(hf_IntCOMMODITY.Value));
                    }
                    dtdetails.Reset();
                    dtdetails = new DataTable();
                    dtdetails = da_obj_FIBLobj.GetBookingDtls(txt_bookno.Text.ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtdetails.Rows.Count != 0)
                    {
                        hf_salesPID.Value = dtdetails.Rows[0]["salesid"].ToString();
                    }
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        if (str_nomination == "N")
                        {
                            chk_nomin.Checked = true;
                        }
                        else
                        {
                            chk_nomin.Checked = false;

                        }
                    }
                    else
                    {
                        if (str_nomination == "N")
                        {
                            chk_nomin.Checked = true;
                        }
                        else
                        {
                            //  chk_nomin.Checked = false;
                            chk_nomin.Checked = true;
                        }
                    }

                    if (str_freight == "P")
                    {
                        ddl_cmbfreight.SelectedValue = "PrePaid";
                    }
                    else
                    {
                        //ddl_cmbfreight.SelectedValue = "To-Collect";

                        ddl_cmbfreight.SelectedValue = "Collect";
                    }
                    btn_save.Text = "Save";


                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    btn_save.Enabled = true;
                    btn_save.ForeColor = System.Drawing.Color.White;


                    DataTable Dt_Dimension;
                    Dt_Dimension = da_obj_AEBLobj.GetAIEBLDimension(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (Dt_Dimension.Rows.Count > 0)
                    {
                        grd_grddimension.DataSource = Dt_Dimension;
                        grd_grddimension.DataBind();
                        for (int i = 0; i <= Dt_Dimension.Rows.Count - 1; i++)
                        {
                            DropDownList obj_ddl_cminch = (DropDownList)grd_grddimension.Rows[i].FindControl("cminch");
                            if (Dt_Dimension.Rows[i][4].ToString() == "Inch")
                            {
                                obj_ddl_cminch.SelectedValue = "I";
                            }
                            else
                            {
                                obj_ddl_cminch.SelectedValue = "C";
                            }

                        }
                        Session["dt_dimension"] = Dt_Dimension;
                    }
                    else
                    {
                        DataTable dt_temp = new DataTable();
                        dt_temp.Columns.Add("length");
                        dt_temp.Columns.Add("breadth");
                        dt_temp.Columns.Add("width");
                        dt_temp.Columns.Add("pieces");
                        dt_temp.Columns.Add("cminch");
                        DataRow dr = dt_temp.NewRow();
                        dt_temp.Rows.Add();
                        grd_grddimension.DataSource = dt_temp;
                        grd_grddimension.DataBind();
                    }
                    //fn_Empty_grdST();

                    for (int s = 1; s <= 6; s++)
                    {
                      //  DataAccess.Accounts.Invoice da_obj_Invobj = new DataAccess.Accounts.Invoice();
                        DataTable Dt = new DataTable();

                        Dt = da_obj_Invobj.CheckIPDCWBL(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), s, "Kgs");
                        if (Dt.Rows.Count > 0)
                        {
                            txt_gross.Enabled = false;
                            txt_charge.Enabled = false;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        else
                        {
                            txt_gross.Enabled = true;
                            txt_charge.Enabled = true;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txt_shipper.Text) && !string.IsNullOrEmpty(txt_fromport.Text) && !string.IsNullOrEmpty(txt_consignee.Text) && !string.IsNullOrEmpty(txt_toport.Text))
                    {
                        txtclear();
                        txt_gross.Enabled = true;
                        txt_charge.Enabled = true;
                    }
                    btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        protected void grd_grddimension_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /* if (e.Row.RowType == DataControlRowType.DataRow)
             {

               


             }*/
        }

        protected void txt_jobno_TextChanged(object sender, EventArgs e)
        {
            /*  str_trantype = Session["StrTranType"].ToString();
              DataTable Dt = new DataTable();
              Dt = da_obj_FIBLobj.Bookingdetails(Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
              if (Dt.Rows.Count > 0)
              {
                  grd_view_popup.Show();
                  grd.Visible = true;
                  grd.DataSource = Dt;
                  grd.DataBind();
               
              }
              else
              {
                  ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Not Available')", true);
                  grd.Visible = false;
                  txt_jobno.Text = "";
                  txt_jobno.Focus();
                  return;
              }
              */

            if (txt_jobno.Text != "")
            {
                str_trantype = Session["StrTranType"].ToString();
                DataTable Dt = new DataTable();
                Dt = AEJobobj.GetAIEDetailregion(Convert.ToInt32(txt_jobno.Text), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt.Rows.Count > 0)
                {
                    //txt_jobno.Enabled = false;
                    //BindGrid();
                    //UserRights();
                   // DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                    DataTable DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (DtA_Details.Rows.Count > 0)
                    {
                        txt_mawbno.Text = DtA_Details.Rows[0][4].ToString();
                        //  txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                        txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                        txt_by1.Text = DtA_Details.Rows[0][0].ToString();
                        txt_by2.Text = DtA_Details.Rows[0][0].ToString();
                        txt_by3.Text = DtA_Details.Rows[0][0].ToString();
                        hf_intbyid1.Value = DtA_Details.Rows[0]["airlineid"].ToString();
                        hf_intbyid2.Value = DtA_Details.Rows[0]["airlineid"].ToString();
                        hf_intbyid3.Value = DtA_Details.Rows[0]["airlineid"].ToString();
                        txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                        txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                        // txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                        //  ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                        string status = DtA_Details.Rows[0][9].ToString();
                        txt_from.Text = DtA_Details.Rows[0][2].ToString();
                        txt_to.Text = DtA_Details.Rows[0][3].ToString();
                        txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                        txt_iatacarrier.Text = DtA_Details.Rows[0]["iatacarrier"].ToString();

                        if (status == "T")
                        {
                            cmbstatus.Text = "Collect";
                        }
                        else
                        {
                            cmbstatus.Text = "Prepaid";
                        }
                        txt_flightno2.Text = DtA_Details.Rows[0]["flightno2"].ToString();
                        if (DtA_Details.Rows[0]["flightdate2"].ToString() != "")
                        {
                            txt_dtfdate2.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0]["flightdate2"].ToString());
                        }
                        else
                        {
                            txt_dtfdate2.Text = "";
                        }

                    }
                    txt_jobno.Enabled = false;
                    txt_bookno.Focus();
                    UserRights();
                }
            
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invaild Job # Selected')", true);
                    txt_jobno.Focus();
                    txt_jobno.Text = "";
                    Blrr = true;
                    return;
                }

            }

        }

        public void InsertDimension()
        {
         //   DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();

            for (int i = 0; i <= grd_grddimension.Rows.Count - 1; i++)
            {
                TextBox obj_txt_chrg = (TextBox)grd_grddimension.Rows[i].FindControl("txt_item_length");
                TextBox obj_txt_curr = (TextBox)grd_grddimension.Rows[i].FindControl("txt_item_breadth");
                TextBox obj_txt_rate = (TextBox)grd_grddimension.Rows[i].FindControl("txt_item_width");
                TextBox obj_txt_piece = (TextBox)grd_grddimension.Rows[i].FindControl("txt_item_piece");
                //TextBox obj_txt_cminch = (TextBox)grd_grddimension.Rows[i].FindControl("txt_item_cminch");
                DropDownList obj_ddl_cminch = (DropDownList)grd_grddimension.Rows[i].FindControl("cminch");

                if (obj_txt_chrg.Text == "")
                {
                    break;
                }
                if (obj_ddl_cminch.SelectedItem.Text == "Inch")
                {
                    obj_ddl_cminch.SelectedItem.Value = "I";
                }
                else
                {
                    obj_ddl_cminch.SelectedItem.Value = "C";
                }

                da_obj_AEBLobj.InsAIEBLDimension(hf_hawblno.Value.ToUpper(), Convert.ToDouble(obj_txt_chrg.Text.ToString()), Convert.ToDouble(obj_txt_curr.Text.ToString()),
                    Convert.ToDouble(obj_txt_rate.Text.ToString()), Convert.ToInt32(obj_txt_piece.Text.ToString()), Convert.ToChar(obj_ddl_cminch.SelectedItem.Value),
                    str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            }
        }

        protected void txt_rate_TextChanged(object sender, EventArgs e)
        {

            /*  if (txt_charge.Text.ToString() != "" && txt_rate.Text.ToString() != "")
              {
                  int add;
                  add = ((Convert.ToInt32(txt_charge.Text)) * (Convert.ToInt32(txt_rate.Text)));
                  txt_rcamt.Text = add.ToString();
              }
              else
              {
                  txt_rcamt.Text = "Nil";
              }
              */


            if (txt_charge.Text.ToString() != "" && txt_rate.Text.ToString() != "")
            {
                double add;
                //   add = ((Convert.ToInt32(txt_charge.Text)) * (Convert.ToInt32(txt_rate.Text)));
                add = ((Convert.ToDouble(txt_charge.Text)) * (Convert.ToDouble(txt_rate.Text)));
                txt_rcamt.Text = add.ToString();
            }
            else
            {
                txt_rcamt.Text = "Nil";
            }

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {


            if (btn_back.ToolTip == "Cancel")
            {
                txt_volwt.Text = "";
                txt_ablno.Enabled = true;
                txt_ablno.ReadOnly = false;
                txtclear();
                txt_jobno.Enabled = true;
                btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                btn_save.Enabled = false;
                btn_save.ForeColor = System.Drawing.Color.Gray;
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";

                Session["dt_dimension"] = null;
                UserRights();

                txt_min.Text = "1";
                txt_rate.Text = "1";
                txt_dvca.Text = "0";
                txt_dvcus.Text = "0";
                txt_chgcode.Text = "0";
                txt_othchg.Text = "AS AGREED";
            }
            else
            {
                this.Response.End();
            }
        }
        public void txtclear()
        {
            txt_ablno.Enabled = true;
            txt_ablno.ReadOnly = false;
            txt_min.Text = "";
            txt_cargo.Text = "";
            txt_gross.Enabled = true;
            txt_charge.Enabled = true;
            txt_jobno.Text = "";
            txt_ablno.Text = "";
            txt_dtissueon.Text = "";
            txt_issueat.Text = "";
            txt_shipper.Text = "";
            txt_saddress.Text = "";
            txt_consignee.Text = "";
            txt_caddress.Text = "";
            txt_notifyparty1.Text = "";
            txt_naddress1.Text = "";
            txt_notifyparty2.Text = "";
            txt_naddress2.Text = "";
            txt_cnf.Text = "";
            txt_fromport.Text = "";
            txt_toport.Text = "";
            txt_by1.Text = "";
            txt_to1.Text = "";
            txt_by2.Text = "";
            txt_to2.Text = "";
            txt_by3.Text = "";
            txt_to3.Text = "";
            txt_curr.Text = "";
            txt_handling.Text = "";
            txt_packages.Text = "";
            ddl_cmbpkgdesc.SelectedIndex = 0;
            ddl_cmbfreight.SelectedIndex = 0;
            ddl_cmbwt.SelectedIndex = 0;
            ddl_cmboth.SelectedIndex = 0;
            ddl_cmbwttype.SelectedIndex = 0;
            txt_rate.Text = "";
            txt_citemno.Text = "";
            txt_gross.Text = "";
            txt_volwt.Text = "";
            txt_charge.Text = "";
            txt_desc.Text = "";
            txt_bookno.Text = "";
            txt_rcamt.Text = "";
            txt_acc.Text = "";
            ddl_charge.SelectedIndex = -1;
            txt_amt.Text = "";
            ddl_pc.SelectedIndex = -1;
            //if (Grd_Charge.Rows.Count > 0) EmptyGrid_Charge();

            Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Charge.DataBind();
            //chk_nomin.Checked = false;
            if (Session["StrTranType"].ToString() == "AE")
            {

                chk_nomin.Enabled = false;
            }
            else
            {
                chk_nomin.Checked = true;
                chk_nomin.Enabled = true;

            }

            chk_switchbl.Checked = false;
            grd_grddimension.DataSource = new DataTable();
            grd_grddimension.DataBind();
            Grid_shipperinvoice.DataSource = new DataTable();
            Grid_shipperinvoice.DataBind();
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_chgcode.Text = "";
            txt_othchg.Text = "";
            txt_insamt.Text = "";
            txt_inscurr.Text = "";
            txt_dvca.Text = "";
            txt_dvcus.Text = "";

            txt_min.Text = "1";
            txt_rate.Text = "1";
            txt_dvca.Text = "0";
            txt_dvcus.Text = "0";
            txt_chgcode.Text = "0";
            txt_othchg.Text = "AS AGREED";

            txt_mawbno.Text = "";
            //  txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
            txt_airline.Text = "";
            txt_flightno.Text = "";
            txt_dtfdate.Text = "";
            // txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
            //  ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();

            txt_from.Text = "";
            txt_to.Text = "";
            txt_agent.Text = "";
            txt_iatacarrier.Text = "";


            cmbstatus.Text = "";

            txt_flightno2.Text = "";

            txt_dtfdate2.Text = "";

           
            fromportflag.ImageUrl = "";

             
            toportflag.ImageUrl = "";


            toflag1.ImageUrl = "";


            toflag2.ImageUrl = "";


            finaldesflag.ImageUrl = "";


            issuedatflag.ImageUrl = "";

            txt_dtissueon.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
            UserRights();
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                str_trantype = Session["StrTranType"].ToString();
                string str_sf = "";

                string str_RptName = "";
                string str_Script;
                string str_sp = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (str_trantype == "AE")
                {
                    if (!string.IsNullOrEmpty(txt_jobno.Text) & string.IsNullOrEmpty(txt_ablno.Text.Trim().ToUpper()))
                    {
                        if (string.IsNullOrEmpty(txt_ablno.Text.Trim().ToUpper()))
                        {
                            //str_frmname = "AEBLDetails";
                            //str_RptName = "AEBLDetails.rpt";
                            //str_sf = "{AEBLDetails.jobno}=" + txt_jobno.Text + " and {AEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txt_ablno.Text.Trim().ToUpper()))
                        {
                            //str_frmname = "AEBLDetails";
                            //str_RptName = "AEBLDetails.rpt";
                            //str_sf = "{AEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            //str_frmname = "AEBLDetails";
                            //str_RptName = "AEBLDetails.rpt";
                            //Session["str_sfs"] = "{AEBLDetails.hawblno}='" + txt_ablno.Text + "'" + " and {AEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                            ////Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                        }
                    }
                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 6, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype + txt_ablno.Text.Trim().ToUpper() + "&View");
                }
                else
                {
                    if (!string.IsNullOrEmpty(txt_jobno.Text) && string.IsNullOrEmpty(txt_ablno.Text.Trim().ToUpper()))
                    {
                        if (txt_ablno.Text.ToString().Trim().ToUpper() != "")
                        {
                            //str_frmname = "AI JobDetails";
                            str_RptName = "AIBLDetails.rpt";
                            str_sf = "{AIBLDetails.jobno}=" + txt_jobno.Text + " and {AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txt_ablno.Text.Trim().ToUpper()))
                        {
                            //  str_frmname = "AI JobDetails";
                            str_RptName = "AIBLDetails.rpt";
                            str_sf = "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            //str_frmname = "AI JobDetails";
                            str_RptName = "AIBLDetails.rpt";
                            Session["str_sfs"] = "{AIBLDetails.hawblno}='" + txt_ablno.Text.Trim().ToUpper() + "'" + " and {AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                            //Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 8, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype + txt_ablno.Text.Trim().ToUpper() + "&View");
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_book_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer = (Label)e.Row.FindControl("Airline");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip);
                    Label lblCustomer1 = (Label)e.Row.FindControl("flightdate");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip1);
                    Label lblCustomer2 = (Label)e.Row.FindControl("agentname");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[4].Attributes.Add("title", tooltip2);
                    Label lblCustomer3 = (Label)e.Row.FindControl("Status");
                    string tooltip3 = lblCustomer3.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip3);
                    Label lblCustomer4 = (Label)e.Row.FindControl("fromport");
                    string tooltip4 = lblCustomer4.Text;
                    e.Row.Cells[6].Attributes.Add("title", tooltip4);
                    Label lblCustomer5 = (Label)e.Row.FindControl("toport");
                    string tooltip5 = lblCustomer5.Text;
                    e.Row.Cells[7].Attributes.Add("title", tooltip5);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_book, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_book_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_book.PageIndex = e.NewPageIndex;
            grd_book.DataSource = (DataTable)ViewState["Job"];
            grd_book.DataBind();
            this.Grd_book_popup.Show();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer = (Label)e.Row.FindControl("bookingdate");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip);
                    Label lblCustomer1 = (Label)e.Row.FindControl("customername");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip1);
                    Label lblCustomer2 = (Label)e.Row.FindControl("pol");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip2);
                    Label lblCustomer3 = (Label)e.Row.FindControl("pod");
                    string tooltip3 = lblCustomer3.Text;
                    e.Row.Cells[4].Attributes.Add("title", tooltip3);
                    Label lblCustomer4 = (Label)e.Row.FindControl("fstatus");
                    string tooltip4 = lblCustomer4.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip4);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd.PageIndex = e.NewPageIndex;
                grd_view_popup.Show();
                grd.DataSource = (DataTable)ViewState["book"];
                grd.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
              //  DataAccess.ForwardingExports.BLDetails feblobj = new DataAccess.ForwardingExports.BLDetails();
                string strcomments;
                if (txt_ablno.Text.Trim().ToUpper() != "")
                {
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        strcomments = feblobj.DelBlDetails(txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), "AE", "");
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 2, 4, Convert.ToInt32(Session["LoginBranchid"]), "AE-BLDel");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Deleted');", true);
                    }
                    else
                    {
                        strcomments = feblobj.DelBlDetails(txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), "AI", "");
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 2, 4, Convert.ToInt32(Session["LoginBranchid"]), "AI-BLDel");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Deleted');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('There is no value to delete');", true);
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_fromport_TextChanged(object sender, EventArgs e)
        {
            //if (hf_intfromid.Value == "0")
            if (portobj.GetNPortid(txt_fromport.Text.Trim().ToUpper()) != 0 && hf_intfromid.Value != "0")
            {
                DataTable dt;
              //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_fromport.Text.ToUpper(), Session["StrTranType"].ToString());
                fromportflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
            }
            else
            {
                txt_fromport.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID From Port')", true);
                txt_fromport.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_toport_TextChanged(object sender, EventArgs e)
        {
          //  DataAccess.CloseJobs obj_da_Close = new DataAccess.CloseJobs();
            //  if (hf_inttoid.Value == "0")
            if (portobj.GetNPortid(txt_toport.Text.Trim().ToUpper()) != 0 && hf_inttoid.Value != "0")
            {
                DataTable dt;
              //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_toport.Text.ToUpper(), Session["StrTranType"].ToString());
                toportflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
            }
            else
            {
                txt_toport.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID To Port')", true);
                txt_toport.Focus();
                Blrr = true;
                return;
            }


            if (Session["StrTranType"].ToString() == "AI")
            {
                DataTable obj_dttemp1 = new DataTable();
                obj_dttemp1 = obj_da_Close.CheckShipmentTransferOrNotnewjobclosed(Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), "AI");
                if (obj_dttemp1.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CostingDetails", "alertify.alert('To Port not updated because BL has transfer');", true);
                    txt_toport.Focus();
                    Blrr = true;
                    return;
                }
            }



        }

        protected void txt_cnf_TextChanged(object sender, EventArgs e)
        {
            //  if (hf_intchaid.Value == "0")
            DataTable dt = new DataTable();
           // DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();

            dt = da_obj_Customer.GetexactCustomer(txt_cnf.Text, "C");
            if (dt.Rows.Count > 0 && hf_intchaid.Value != "0")
            {

            }
            else
            {
                txt_cnf.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID CNF NAME')", true);
                txt_cnf.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_curr_TextChanged(object sender, EventArgs e)
        {
            //if (hf_curid.Value == "0")
          //  DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            DataTable dtCharge = new DataTable();
            int currid = chargeobj.GetCurrID(txt_curr.Text.Trim().ToUpper());
            if (currid != 0 && hf_curid.Value != "0")
            {
            }
            else
            {
                txt_curr.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Currency')", true);
                txt_curr.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_to1_TextChanged(object sender, EventArgs e)
        {
            //if (hf_inttoid1.Value == "0")
            if (portobj.GetNPortid(txt_to1.Text.Trim().ToUpper()) != 0 && hf_inttoid1.Value != "0")
            {
                txt_to2.Text = txt_to1.Text;
                 txt_to3.Text = txt_to1.Text;

                hf_inttoid2.Value = hf_inttoid1.Value;
                hf_inttoid3.Value = hf_inttoid1.Value;

                DataTable dt;
             //   DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_to1.Text.ToUpper(), Session["StrTranType"].ToString());
                toflag1.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                dt = obj_MasterPort.SelPortName4typepadimg(txt_to2.Text.ToUpper(), Session["StrTranType"].ToString());
                toflag2.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                dt = obj_MasterPort.SelPortName4typepadimg(txt_to3.Text.ToUpper(), Session["StrTranType"].ToString());
                finaldesflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
            }
            else
            {
                txt_to1.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID TO PORT')", true);
                txt_to1.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_by1_TextChanged(object sender, EventArgs e)
        {
            //if (hf_intbyid1.Value == "0")
            DataTable obj_dt = new DataTable();
          //  DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetexactCustomer(txt_by1.Text, "C");
            // string byname = txt_by1.Text;
            //  txt_by2.Text=byname.ToString();
            if (obj_dt.Rows.Count > 0 && hf_intbyid1.Value != "0")
            {
                txt_by2.Text = txt_by1.Text;
                txt_by3.Text = txt_by1.Text;
                hf_intbyid2.Value = hf_intbyid1.Value;
                hf_intbyid3.Value = hf_intbyid1.Value;
                //txt_by3.Text = txt_by1.Text;
                // hf_intbyid3.Value = hf_intbyid1.Value;
            }
            else
            {
                txt_by1.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID BY NAME')", true);
                txt_by1.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_to2_TextChanged(object sender, EventArgs e)
        {
            //if (hf_inttoid2.Value == "0")
            if (portobj.GetNPortid(txt_to2.Text.Trim().ToUpper()) != 0 && hf_inttoid2.Value != "0")
            {
                DataTable dt;
              //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_to2.Text.ToUpper(), Session["StrTranType"].ToString());
                toflag2.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID TO PORT')", true);
                txt_to2.Text = "";
                txt_to2.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_by2_TextChanged(object sender, EventArgs e)
        {
            // if (hf_intbyid2.Value == "0")
            DataTable obj_dt = new DataTable();
         //   DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetexactCustomer(txt_by2.Text, "C");
            if (obj_dt.Rows.Count > 0 && hf_intbyid2.Value != "0")
            {

            }
            else
            {
                txt_by2.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID BY NAME')", true);
                txt_by2.Focus();
                return;
            }
        }

        protected void txt_to3_TextChanged(object sender, EventArgs e)
        {
            // if (hf_inttoid3.Value == "0")
            if (portobj.GetNPortid(txt_to3.Text.Trim().ToUpper()) != 0 && hf_inttoid3.Value != "0")
            {
                DataTable dt;
              //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_to3.Text.ToUpper(), Session["StrTranType"].ToString());
                finaldesflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID TO PORT')", true);
                txt_to3.Text = "";
                txt_to3.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_by3_TextChanged(object sender, EventArgs e)
        {
            //if (hf_intbyid3.Value == "0")
            DataTable obj_dt = new DataTable();
           // DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetexactCustomer(txt_by3.Text, "C");
            if (obj_dt.Rows.Count > 0 && hf_intbyid3.Value != "0")
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID BY NAME')", true);
                txt_by3.Text = "";
                txt_by3.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_issueat_TextChanged(object sender, EventArgs e)
        {
            //if (hf_intissuedid.Value == "0")
            if (portobj.GetNPortid(txt_issueat.Text.Trim().ToUpper()) != 0 && hf_intissuedid.Value != "0")
            {
                DataTable dt;
              //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_issueat.Text.ToUpper(), Session["StrTranType"].ToString());
                issuedatflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
            }
            else
            {
                txt_issueat.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Issued At')", true);
                txt_issueat.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_cargo_TextChanged(object sender, EventArgs e)
        {
            //  if (hf_IntCOMMODITY.Value == "0")
            DataTable dtPort = new DataTable();
           // DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
            int cargoid = cargoobj.GetCargoid(txt_cargo.Text.Trim().ToUpper());
            if(cargoid != 0)
            {
                hf_IntCOMMODITY.Value = cargoid.ToString();
            }
            else if (cargoid != 0 && hf_IntCOMMODITY.Value != "0")
            {

            }
            else
            {
                txt_cargo.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID COMMODITY NAME')", true);
                txt_cargo.Focus();
                Blrr = true;
                return;
            }
        }

        protected void txt_inscurr_TextChanged(object sender, EventArgs e)
        {
            // if (hf_curid.Value == "0")
          //  DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            DataTable dtCharge = new DataTable();
            int currid = chargeobj.GetCurrID(txt_inscurr.Text.Trim().ToUpper());
            if (currid != 0 && hf_curid.Value != "0")
            {

            }
            else
            {
                txt_inscurr.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Currency')", true);
                txt_inscurr.Focus();
                Blrr = true;
                return;
            }
        }

        protected void Proinvoic_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1027, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_ablno.Text.Trim().ToUpper() != "")
                    {
                        string aeblno = txt_ablno.Text.Trim().ToUpper();
                        string appaebll = "Proforma Invoice";
                        string lblid = lblheader.Text;
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?appaebll=" + appaebll + "&aeblno=" + aeblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the HAWB Number";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1034, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_ablno.Text.Trim().ToUpper() != "")
                    {
                        string aeblno = txt_ablno.Text.Trim().ToUpper();
                        string appaebll = "Proforma Sales Invoice";
                        string lblid = lblheader.Text;
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?appaebll=" + appaebll + "&aeblno=" + aeblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the HAWB Number";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }


        }

        protected void procrednote_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1028, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_ablno.Text.Trim().ToUpper() != "")
                    {
                        string aeblno = txt_ablno.Text.Trim().ToUpper();
                        string appaebll = "Proforma Purchase Invoice";
                        string lblid = lblheader.Text;
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?appaebll=" + appaebll + "&aeblno=" + aeblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the HAWB Number";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1035, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_ablno.Text.Trim().ToUpper() != "")
                    {
                        string aeblno = txt_ablno.Text.Trim().ToUpper();
                        string appaebll = "Proforma Purchase Invoice";
                        string lblid = lblheader.Text;
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?appaebll=" + appaebll + "&aeblno=" + aeblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the HAWB Number";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }

        }

        public void fn_Empty_grdST()
        {
            DataTable obj_Empty = new DataTable();
            DataRow dr;

            DataColumn dc_col1 = new DataColumn("Length", typeof(string));
            DataColumn dc_col2 = new DataColumn("Breadth", typeof(string));
            DataColumn dc_col3 = new DataColumn("Width", typeof(string));
            DataColumn dc_col4 = new DataColumn("pieces", typeof(string));
            DataColumn dc_col5 = new DataColumn("cminch", typeof(string));
            //  DataColumn dc_col6 = new DataColumn("Cm&Inch", typeof(string));

            obj_Empty.Columns.Add(dc_col1);
            obj_Empty.Columns.Add(dc_col2);
            obj_Empty.Columns.Add(dc_col3);
            obj_Empty.Columns.Add(dc_col4);
            obj_Empty.Columns.Add(dc_col5);
            // obj_Empty.Columns.Add(dc_col6);

            for (int i = 0; i < 1; i++)
            {
                dr = obj_Empty.NewRow();
                dr["Length"] = "";
                dr["Breadth"] = "";
                dr["Width"] = "";
                dr["pieces"] = "";
                dr["cminch"] = "";

                obj_Empty.Rows.Add(dr);
            }
            grd_grddimension.DataSource = obj_Empty;
            grd_grddimension.DataBind();

            Session["dt_dimension"] = obj_Empty;

        }
        public void shipperinvoice()
        {
            DataTable dtshipper = new DataTable();
            DataRow dr1;

            DataColumn dc_col1 = new DataColumn("Shipperinvoice", typeof(string));
            dtshipper.Columns.Add(dc_col1);
            for (int i = 0; i < 1; i++)
            {
                dr1 = dtshipper.NewRow();
                dr1["Shipperinvoice"] = "";


                dtshipper.Rows.Add(dr1);
            }
            Grid_shipperinvoice.DataSource = dtshipper;
            Grid_shipperinvoice.DataBind();

            Session["shipperinvoice"] = dtshipper;
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (Session["dt_dimension"] != null)
            {
                DataTable dt = (DataTable)Session["dt_dimension"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox obj_txt_length =
                 (TextBox)grd_grddimension.Rows[rowIndex].Cells[0].FindControl("txt_item_length");
                        TextBox obj_txt_breadth =
                          (TextBox)grd_grddimension.Rows[rowIndex].Cells[1].FindControl("txt_item_breadth");
                        TextBox obj_txt_width =
                          (TextBox)grd_grddimension.Rows[rowIndex].Cells[2].FindControl("txt_item_width");
                        TextBox obj_txt_piece =
                       (TextBox)grd_grddimension.Rows[rowIndex].Cells[3].FindControl("txt_item_piece");
                        // TextBox obj_txt_cminch =
                        //(TextBox)grd_grddimension.Rows[rowIndex].Cells[4].FindControl("txt_item_cminch");

                        DropDownList obj_ddl_cminch =
                          (DropDownList)grd_grddimension.Rows[rowIndex].Cells[4].FindControl("cminch");

                        obj_txt_length.Text = dt.Rows[i][0].ToString();
                        obj_txt_breadth.Text = dt.Rows[i][1].ToString();
                        obj_txt_width.Text = dt.Rows[i][2].ToString();
                        obj_txt_piece.Text = dt.Rows[i][3].ToString();
                        //  obj_txt_cminch.Text = dt.Rows[i][4].ToString();
                        obj_ddl_cminch.SelectedValue = dt.Rows[i][4].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        public void setshipper()
        {
            int rowIndex = 0;
            if (Session["shipperinvoice"] != null)
            {
                DataTable dt = (DataTable)Session["shipperinvoice"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox obj_txt_shipperinvoice = (TextBox)Grid_shipperinvoice.Rows[rowIndex].Cells[0].FindControl("txt_shipperinvoice");

                        obj_txt_shipperinvoice.Text = dt.Rows[i][0].ToString();
                        rowIndex++;
                    }
                }
            }
        }


        protected void cminch_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if(Session["dt_dimension"]!=null)
            // {
            //     DataTable dt_temp = new DataTable();
            //     //dt_temp.Columns.Add("length");
            //     //dt_temp.Columns.Add("breadth");
            //     //dt_temp.Columns.Add("width");
            //     //dt_temp.Columns.Add("pieces");
            //     //dt_temp.Columns.Add("cminch");
            //     //DataRow dr = dt_temp.NewRow();
            //     dt_temp = (DataTable)Session["dt_dimension"];
            //     dt_temp.Rows.Add();
            //     grd_grddimension.DataSource = dt_temp;
            //     grd_grddimension.DataBind();
            //     dt_temp = (DataTable)Session["dt_dimension"];
            // }


            ///*  int rowIndex = 0;

            //  if (Session["dt_dimension"] != null)
            //  {
            //      DataTable dtCurrentTable = (DataTable)Session["dt_dimension"];
            //      DataRow drCurrentRow = null;
            //      if (dtCurrentTable.Rows.Count > 0)
            //      {
            //          for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            //          {
            //              TextBox obj_txt_length =
            //                (TextBox)grd_grddimension.Rows[rowIndex].Cells[0].FindControl("txt_item_length");
            //              TextBox obj_txt_breadth =
            //                (TextBox)grd_grddimension.Rows[rowIndex].Cells[1].FindControl("txt_item_breadth");
            //              TextBox obj_txt_width =
            //                (TextBox)grd_grddimension.Rows[rowIndex].Cells[2].FindControl("txt_item_width");
            //              TextBox obj_txt_piece =
            //             (TextBox)grd_grddimension.Rows[rowIndex].Cells[3].FindControl("txt_item_piece");
            //              TextBox obj_txt_cminch =
            //             (TextBox)grd_grddimension.Rows[rowIndex].Cells[4].FindControl("txt_item_cminch");

            //              DropDownList obj_ddl_cminch =
            //                (DropDownList)grd_grddimension.Rows[rowIndex].Cells[5].FindControl("ddl_item_cminch");


            //              /*   TextBox obj_txt_length = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_length");
            //                 TextBox obj_txt_breadth = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_breadth");
            //                 TextBox obj_txt_width = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_width");
            //                 TextBox obj_txt_piece = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_piece");
            //                 TextBox obj_txt_cminch = (TextBox)grd_grddimension.Rows[row.RowIndex].FindControl("txt_item_cminch");

            //                 DropDownList obj_ddl_cminch = (DropDownList)grd_grddimension.Rows[row.RowIndex].FindControl("ddl_item_cminch");


            //              drCurrentRow = dtCurrentTable.NewRow();
            //              //drCurrentRow["Length"] = i + 1;

            //              dtCurrentTable.Rows[i - 1]["Length"] = obj_txt_length.Text;
            //              dtCurrentTable.Rows[i - 1]["Breadth"] = obj_txt_breadth.Text;
            //              dtCurrentTable.Rows[i - 1]["Width"] = obj_txt_width.Text;
            //              dtCurrentTable.Rows[i - 1]["pieces"] = obj_txt_piece.Text;
            //              dtCurrentTable.Rows[i - 1]["cminch"] = obj_txt_cminch.Text;
            //              if (obj_ddl_cminch.Text == "I")
            //              {
            //                  obj_ddl_cminch.SelectedValue = "I";
            //                  //dtCurrentTable.Rows[i - 1]["Cm&Inch"] = "Inch";
            //              }
            //              else
            //              {
            //                  obj_ddl_cminch.SelectedValue = "C";
            //                  //dtCurrentTable.Rows[i - 1]["Cm&Inch"] = "CM";
            //              }
            //              dtCurrentTable.Rows[i - 1]["Cm&Inch"] = obj_ddl_cminch.SelectedValue;
            //              rowIndex++;
            //          }
            //          dtCurrentTable.Rows.Add(drCurrentRow);
            //          Session["New"] = dtCurrentTable;

            //          grd_grddimension.DataSource = dtCurrentTable;
            //          grd_grddimension.DataBind();
            //      }
            //  }
            //  else
            //  {
            //      Response.Write("ViewState is null");
            //  }

            //  SetPreviousData();*/







        }

        protected void btn_reuse_Click(object sender, EventArgs e)
        {
            getabldateilsreuse();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            double int_length = 0.0, int_breadth = 0.0, int_width = 0.0, int_piece = 0.0, cen = 0.0, inch = 0.0, total = 0.0, total1 = 0.0, total2 = 0.0;
            double overallamount = 0;
            if (Session["dt_dimension"] != null)
            {
                DataTable dtCurrentTable = (DataTable)Session["dt_dimension"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        total1 = 0.0; total2 = 0.0;
                        TextBox obj_txt_length =
                          (TextBox)grd_grddimension.Rows[rowIndex].Cells[0].FindControl("txt_item_length");
                        TextBox obj_txt_breadth =
                          (TextBox)grd_grddimension.Rows[rowIndex].Cells[1].FindControl("txt_item_breadth");
                        TextBox obj_txt_width =
                          (TextBox)grd_grddimension.Rows[rowIndex].Cells[2].FindControl("txt_item_width");
                        TextBox obj_txt_piece =
                       (TextBox)grd_grddimension.Rows[rowIndex].Cells[3].FindControl("txt_item_piece");
                        // TextBox obj_txt_cminch =
                        //(TextBox)grd_grddimension.Rows[rowIndex].Cells[4].FindControl("txt_item_cminch");

                        DropDownList obj_ddl_cminch =
                          (DropDownList)grd_grddimension.Rows[rowIndex].Cells[4].FindControl("cminch");
                        drCurrentRow = dtCurrentTable.NewRow();

                        if (!string.IsNullOrEmpty(obj_txt_length.Text))
                        {
                            dtCurrentTable.Rows[i - 1]["Length"] = obj_txt_length.Text;
                        }
                        if (!string.IsNullOrEmpty(obj_txt_breadth.Text))
                        {
                            dtCurrentTable.Rows[i - 1]["Breadth"] = obj_txt_breadth.Text;
                        }
                        if (!string.IsNullOrEmpty(obj_txt_width.Text))
                        {
                            dtCurrentTable.Rows[i - 1]["Width"] = obj_txt_width.Text;
                        }
                        if (!string.IsNullOrEmpty(obj_txt_piece.Text))
                        {
                            dtCurrentTable.Rows[i - 1]["pieces"] = obj_txt_piece.Text;
                        }
                        dtCurrentTable.Rows[rowIndex]["cminch"] = obj_ddl_cminch.SelectedValue;
                        rowIndex++;
                        if (obj_txt_length.Text != "")
                        {
                            int_length = Convert.ToDouble(obj_txt_length.Text);
                        }

                        else
                        {
                            //int_length = 0;
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the length')", true);
                            obj_txt_length.Focus();
                            return;
                        }
                        if (obj_txt_breadth.Text != "")
                        {
                            int_breadth = Convert.ToDouble(obj_txt_breadth.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the breadth')", true);
                            obj_txt_breadth.Focus();
                            return;
                        }

                        if (obj_txt_width.Text != "")
                        {
                            int_width = Convert.ToDouble(obj_txt_width.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the width')", true);
                            obj_txt_width.Focus();
                            return;
                        }

                        if (obj_txt_piece.Text != "")
                        {
                            int_piece = Convert.ToDouble(obj_txt_piece.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the piece')", true);
                            obj_txt_piece.Focus();
                            return;
                        }



                        total = int_length * int_breadth * int_width * int_piece;
                        if (total != 0.0)
                        {
                            if (obj_ddl_cminch.SelectedItem.Text == "CM")
                            {
                                cen = 6000.00;
                                total1 = total / cen;
                            }
                            else if (obj_ddl_cminch.SelectedItem.Text == "Inch")
                            {
                                inch = 366.00;
                                total1 = total / inch;
                            }
                            overallamount = overallamount + total1;
                        }
                    }
                    // }
                    TextBox obj_txt_length1 =
                        (TextBox)grd_grddimension.Rows[rowIndex - 1].Cells[0].FindControl("txt_item_length");
                    TextBox obj_txt_breadth2 =
                      (TextBox)grd_grddimension.Rows[rowIndex - 1].Cells[1].FindControl("txt_item_breadth");
                    TextBox obj_txt_width3 =
                      (TextBox)grd_grddimension.Rows[rowIndex - 1].Cells[2].FindControl("txt_item_width");
                    TextBox obj_txt_piece4 =
                   (TextBox)grd_grddimension.Rows[rowIndex - 1].Cells[3].FindControl("txt_item_piece");
                    if (obj_txt_length1.Text != "" && obj_txt_breadth2.Text != "" && obj_txt_width3.Text != "" && obj_txt_piece4.Text != "")
                    {
                        dtCurrentTable.Rows.Add(drCurrentRow);
                    }

                    Session["dt_dimension"] = dtCurrentTable;

                    grd_grddimension.DataSource = dtCurrentTable;
                    grd_grddimension.DataBind();


                    // hid_total1.Value = hid_total1.Value +total.ToString();
                }


            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData();
            //int overall = Convert.ToInt32(overallamount);
            txt_volwt.Text = Convert.ToDouble(overallamount).ToString("#,0.00");//.ToString("#,0.00");

            if (Convert.ToDouble(txt_gross.Text) > Convert.ToDouble(txt_volwt.Text))
            {
                txt_charge.Text = txt_gross.Text;
            }
            else
            {
                txt_charge.Text = txt_volwt.Text;
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            if (Session["StrTranType"] == "AE")
            {
                obj_dtlogdetails = da_obj_Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 6, "BL", txt_ablno.Text.Trim().ToUpper(), txt_ablno.Text.Trim().ToUpper(), Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = da_obj_Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 8, "BL", txt_ablno.Text.Trim().ToUpper(), txt_ablno.Text.Trim().ToUpper(), Session["StrTranType"].ToString());
            }
            if (txt_jobno.Text != "")
            {
                JobInput.Text = txt_ablno.Text.Trim().ToUpper();
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void AutoInvoice()
        {
            try
            {
                if (hid_quto.Value == "")
                {
                    hid_quto.Value = "0";

                }

                dtinv = AIEBL.GetQuotchgs4InvAE(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_bookno.Text);
                if (dtinv.Rows.Count > 0)
                {
                    try
                    {

                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //    "Profoma Invoice", "", 0);



                        hid_SupplyTo.Value = hid_intcustomerid.Value;


                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(da_obj_Logobj.GetDate()), "AE", Convert.ToInt32(txt_jobno.Text),
                        //   Convert.ToInt32(hid_intcustomerid.Value), txt_ablno.Text.Trim().ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //   "Profoma Invoice", "", 0, Convert.ToInt32(hid_SupplyTo.Value));
                        Refno = ProINVobj.InsProLVhead(Convert.ToDateTime(da_obj_Logobj.GetDate()), "AE", Convert.ToInt32(txt_jobno.Text),
                              Convert.ToInt32(hid_intcustomerid.Value), txt_ablno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                             "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), 1, "",
                             0, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToDateTime(da_obj_Logobj.GetDate()));

                        invgen = true;

                        for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                        {
                            base1 = dtinv.Rows[i]["base"].ToString();
                            rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                            exrate = obj_da_Invoice.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                            amount = checkbase(base1, rate, exrate);
                            unit = Convert.ToDouble(hdnUnit.Value);
                            //ProINVobj.InsertProInvoiceDetails(Refno, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                            //    exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                            //    , "C", "AE", "Profoma Invoice", "Y", unit);

                            ProINVobj.InsertProLVDetails(Refno, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                              exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                              , "C", "AE", 1, "Y", unit);
                        }
                    }
                    catch (Exception ex)
                    {
                        //   Utility.SendMail(Session["usermailid"].ToString(), "", "bl pRO.iNV", ex.ToString(), "", Session["usermailpwd"].ToString(), "", "");
                    }
                }
                else
                {
                    invgen = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void AutoInvoiceAI()
        {
            try
            {
                if (hid_quto.Value == "")
                {
                    hid_quto.Value = "0";

                }

                dtinv = AIEBL.GetQuotchgs4InvAI(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_bookno.Text);
                if (dtinv.Rows.Count > 0)
                {
                    try
                    {

                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //    "Profoma Invoice", "", 0);



                        hid_SupplyTo.Value = hid_intcustomerid.Value;
                        Refno = ProINVobj.InsProLVhead(Convert.ToDateTime(da_obj_Logobj.GetDate()), "AI", Convert.ToInt32(txt_jobno.Text),
                            Convert.ToInt32(hid_intcustomerid.Value), txt_ablno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                           "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), 1, "",
                           0, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToDateTime(da_obj_Logobj.GetDate()));

                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(da_obj_Logobj.GetDate()), "AI", Convert.ToInt32(txt_jobno.Text),
                        //   Convert.ToInt32(hid_intcustomerid.Value), txt_ablno.Text.Trim().ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //   "Profoma Invoice", "", 0, Convert.ToInt32(hid_SupplyTo.Value));

                        invgen = true;

                        for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                        {
                            base1 = dtinv.Rows[i]["base"].ToString();
                            rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                            exrate = obj_da_Invoice.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                            amount = checkbase(base1, rate, exrate);
                            unit = Convert.ToDouble(hdnUnit.Value);
                            //ProINVobj.InsertProInvoiceDetails(Refno, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                            //    exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                            //    , "C", "AI", "Profoma Invoice", "Y", unit);
                            ProINVobj.InsertProLVDetails(Refno, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                             exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                             , "C", "AE", 1, "Y", unit);

                        }
                    }
                    catch (Exception ex)
                    {
                        //   Utility.SendMail(Session["usermailid"].ToString(), "", "bl pRO.iNV", ex.ToString(), "", Session["usermailpwd"].ToString(), "", "");
                    }
                }
                else
                {
                    invgen = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Btnshipper_Click(object sender, EventArgs e)
        {
            ModalPopupExtender2.Show();
            //Panel3.Visible = true;
        }

        protected void autodebitOS()
        {
            int vouyear;
            if (hid_quto.Value == "")
            {
                hid_quto.Value = "0";

            }
            Double amt = 0.00;
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "AE")
                {
                    dtinv = AIEBL.GetQuotchgs4debitcredit(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_bookno.Text);
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    dtinv = AIEBL.GetQuotchgs4debitcreditAI(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_bookno.Text);
                }
            }


            //DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
            DateTime dtdate = da_obj_logobj.GetDate();
            DateTime txtVendorRefnodate = da_obj_logobj.GetDate();
            double amt1 = 0, actual = 0.00;
            double fcamt1 = 0.00;
            if (dtinv.Rows.Count > 0)
            {
                if (da_obj_logobj.GetDate().Month < 4)
                {
                    vouyear = da_obj_logobj.GetDate().Year - 1;
                }
                else
                {
                    vouyear = da_obj_logobj.GetDate().Year;
                }
                hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                hid_SupplyTo.Value = hid_intagent.Value;
                DataTable dtd = new DataTable();
                //DataAccess.AirImportExports.AIEJobInfo objaej = new DataAccess.AirImportExports.AIEJobInfo();
                dtd = objaej.GetAIagentid(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(txt_jobno.Text));

                DebitOS = true;
                refnodebitOs = da_obj_OSDNCN.InsproOSvouchershead(Convert.ToDateTime(dtdate), Session["StrTranType"].ToString(), Convert.ToDouble(amount),
                         Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                         Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                         Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 5, "", "");


                for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                {
                    if (dtinv.Rows[i]["agentid"].ToString() != "")
                    {
                        hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                        hid_SupplyTo.Value = hid_intagent.Value;
                    }
                    else
                    {
                        if (dtd.Rows[0]["agent"].ToString() != "")
                        {
                            hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                            hid_SupplyTo.Value = hid_intagent.Value;
                        }
                    }
                    if (dtd.Rows[0]["mawblno"].ToString() != "")
                    {
                        HIDMAWBLNO.Value = txt_ablno.Text.ToUpper();
                    }



                    base1 = dtinv.Rows[i]["base"].ToString();
                    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                    exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "C", Convert.ToInt32(Session["LoginDivisionId"]));
                    famount = checkbase(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                    string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                    actual = actual + Convert.ToDouble(osamount);
                    unit = Convert.ToDouble(hdnUnit.Value);
                    fd = Convert.ToInt32(hid_fd.Value);
                    unit = Convert.ToInt32(hdnUnit.Value);
                    DAdvise.InsOSVdetails(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), HIDMAWBLNO.Value.ToUpper(),
                      Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                       base1, Convert.ToDouble(osamount), 5, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                       "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", refnodebitOs, Convert.ToInt32(vouyear));

                    //"Y", Convert.ToInt32(hid_intagent.Value));

                }

                /*  for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                  {
                      if (dtinv.Rows[i]["agentid"].ToString() != "")
                      {
                          hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                          hid_SupplyTo.Value = hid_intagent.Value; 
                      }
                      else
                      {
                          if (dtd.Rows[0]["agent"].ToString() != "")
                          {
                              hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                              hid_SupplyTo.Value = hid_intagent.Value; 
                          }
                      }
                      if (dtd.Rows[0]["mawblno"].ToString() != "")
                      {
                          //HIDMAWBLNO.Value = dtd.Rows[0]["mawblno"].ToString();
                          HIDMAWBLNO.Value = txt_ablno.Text.Trim().ToUpper();
                      }

                      base1 = dtinv.Rows[i]["base"].ToString();
                      rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                      exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                      famount = CheckBaseos(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                      string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                      actual = actual + Convert.ToDouble(osamount);
                      //DAdvise.InsDCAdviseForGst(Convert.ToInt32(txt_jobno.Text), "AE", HIDMAWBLNO.Value.ToUpper(), Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate), base1, Convert.ToDouble(osamount), "DebitAdvise", Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(hid_intagent.Value));

                    //  DAdvise.InsDCAdviseForGst(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), HIDMAWBLNO.Value.ToUpper(), Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate), base1, Convert.ToDouble(osamount), "DebitAdvise", Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(hid_intagent.Value));
                      DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), HIDMAWBLNO.Value.ToUpper(),
                        Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                        base1, Convert.ToDouble(osamount), 5, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                        "Y", Convert.ToInt32(hid_intagent.Value));

                      //int_djobno = da_obj_OSDNCN.GetOSDCNProJobCount(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSDN", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                      //int_cjobno = da_obj_OSDNCN.GetOSDCNProJobCount(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSCN", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                  }
                  DataAccess.AirImportExports.AIEBLDetails objae = new DataAccess.AirImportExports.AIEBLDetails();
                  //refnodebitOs = da_obj_OSDNCN.InsertOSDNProForGst(Convert.ToDateTime(dtdate), "AE", Convert.ToDouble(actual), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual, Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate);

                 // refnodebitOs = da_obj_OSDNCN.InsertOSDNProForGst(Convert.ToDateTime(dtdate), Session["StrTranType"].ToString(), Convert.ToDouble(actual), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual, Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate);
                  refnodebitOs = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), "OE", Convert.ToDouble(amount),
                                                      Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                                                      Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                                                      Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 5);*/



                DataTable dttn = new DataTable();
                dttn = da_obj_OSDNCN.Getupdacdebitfcamt(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(hf_jobno.Value));
                if (dttn.Rows.Count > 0)
                {
                    for (int i = 0; i <= dttn.Rows.Count - 1; i++)
                    {
                        if (dttn.Rows[i]["fcamt"].ToString() != "")
                        {
                            fcamt1 = fcamt1 + Convert.ToDouble(dttn.Rows[i]["fcamt"]);
                        }
                    }

                }
                // da_obj_OSDNCN.Getupdacosdnproupd(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(hf_jobno.Value), fcamt1);

                da_obj_OSDNCN.Getupdacosdnproupdnew(refnocreditOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]),
                   Convert.ToInt32(vouyear), Convert.ToInt32(hf_jobno.Value), fcamt1, "DebitAdvise");


            }
            else
            {
                DebitOS = false;
            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            //DataAccess.CostingTemp objcos = new DataAccess.CostingTemp();
            //DataAccess.AirImportExports.AIEJobInfo objaejob = new DataAccess.AirImportExports.AIEJobInfo();

            if (txt_shipperinvoice.Text != "")
            {

                str_trantype = Session["StrTranType"].ToString();
                objaejob.insertshipperinvoice(txt_ablno.Text.Trim().ToUpper(), Session["StrTranType"].ToString(), txt_shipperinvoice.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]));
                txt_shipperinvoice.Text = "";
                DataTable dtt = new DataTable();
                dtt = objcos.AEBLSHIPPERINVOICEGET(txt_ablno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype);
                if (dtt.Rows.Count > 0)
                {
                    Grid_shipperinvoice.DataSource = dtt;
                    Grid_shipperinvoice.DataBind();
                    Session["shipperinvoice"] = dtt;
                }
                else
                {
                    //DataTable dt_temp = new DataTable();
                    //dt_temp.Columns.Add("Shipperinvoice");
                    //DataRow dr = dt_temp.NewRow();
                    //dt_temp.Rows.Add();
                    //Grid_shipperinvoice.DataSource = dt_temp;
                    //Grid_shipperinvoice.DataBind();

                    Grid_shipperinvoice.DataSource = new DataTable();
                    Grid_shipperinvoice.DataBind();
                    Session["shipperinvoice"] = new DataTable();
                }
            }

            this.ModalPopupExtender2.Show();
        }

        public double CheckBaseos(string strbase, double rate, double exrate)
        {
            //DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
            string strTranType = Session["StrTranType"].ToString();
            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            if (DtBLNO.Rows.Count > 0)
            {
                mblno = DtBLNO.Rows[0][0].ToString();
            }
            if (strbase == "BL" || strbase == "HWBL" || strbase == "DOC" || strbase == "FLAT RATE" || strbase == "HAWB")
            {
                if (txt_ablno.Text.Trim().ToUpper() == mblno)
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
                else
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }
                douvolume = 1;
                amount = rate * exrate;
                //---------------------------------------------

            }
            else if (strbase == "Kgs" || strbase == "KGS" || strbase == "PER KG")
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (txt_ablno.Text.Trim().ToUpper() == mblno)
                    {
                        wt = INVOICEobj.GetSumofChargeWght(Convert.ToInt32(txt_jobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                    }
                    else
                    {
                        wt = INVOICEobj.GetChargeWeight(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                    }

                }

            }
            else if (base1.ToString() == "COTTON/PALLET".ToUpper())
            {
                if (str_trantype == "AE" || str_trantype == "AI")
                {
                    if (txt_ablno.Text.Trim().ToUpper() == mblno)
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgpallet = obj_da_Invoice.Getchargepallet(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgpallet);
                        douvolume = Convert.ToDouble(strchgpallet);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        //  hdnUnit.Value = strchgpallet.ToString();
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }
                    else
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgpallet = obj_da_Invoice.Getchargepallet(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgpallet);
                        douvolume = Convert.ToDouble(strchgpallet);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                    }

                }
            }

            else if (base1.ToString() == "PERTRUCK".ToUpper())
            {
                if (str_trantype == "AE" || str_trantype == "AI")
                {
                    if (txt_ablno.Text.Trim().ToUpper() == mblno)
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgtruck = obj_da_Invoice.Getchargetruck(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgtruck);
                        douvolume = Convert.ToDouble(strchgtruck);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }
                    else
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgtruck = obj_da_Invoice.Getchargetruck(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgtruck);
                        douvolume = Convert.ToDouble(strchgtruck);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_ablno.Text.Trim().ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }

                }
            }



            hid_douvolume.Value = douvolume.ToString();
            hid_fd.Value = fd.ToString();
            return amount;


        }
        public void ChkCustStateName(int custid, string custname)
        {
            if (Convert.ToDateTime(da_obj_Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
            {
                if (custname != "" && custid > 0)
                {

                    //int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    DataTable dt_list = new DataTable();
                    dt_list = da_obj_customerobj.GetIndianCustomergstadd(custid);
                    if (dt_list.Rows.Count == 0)
                    {
                        // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                        bolcuststat = true;

                    }
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Kindly update SUPPLY TO Name " + custname + "');", true);
                    bolcuststat1 = true;

                }
            }
        }

        //public double checkbase(string base1, double rate, double exrate)
        //{
        //    try
        //    {
        //        if (Session["StrTranType"].ToString() == "FE")
        //        {
        //            if (base1.ToUpper() == "BL")
        //            {
        //                amount = rate * exrate;
        //                unit = 1;
        //            }
        //            else if (base1.ToUpper() == "CBM")
        //            {
        //                strvolume = obj_da_Invoice.GetVolume(txt_ablno.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                amount = rate * exrate * Convert.ToDouble(strvolume);
        //                unit = Convert.ToDouble(strvolume);
        //            }
        //            else if (base1.ToUpper() == "CBM" || base1.ToUpper() == "MT")
        //            {
        //                if (base1.ToUpper() == "MT")
        //                {
        //                    strntweight = obj_da_Invoice.GetWeight(txt_ablno.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                    amount = rate * exrate * (Convert.ToDouble(strntweight) / 1000);
        //                    unit = Convert.ToDouble(strntweight);
        //                }
        //                strvolume = obj_da_Invoice.GetVolume(txt_ablno.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                cbmAmt = rate * exrate * Convert.ToDouble(strvolume);
        //                strntweight = obj_da_Invoice.GetWeight(txt_ablno.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                mtAmt = rate * exrate * (Convert.ToDouble(strntweight) / 1000);
        //                if (cbmAmt < mtAmt)
        //                {
        //                    base1 = "MT";
        //                    amount = mtAmt;
        //                    unit = Convert.ToDouble(strvolume);
        //                }
        //                else
        //                {
        //                    base1 = "CBM";
        //                    amount = cbmAmt;
        //                    unit = Convert.ToDouble(strntweight);
        //                }
        //            }
        //            else if (base1.ToUpper() == "KGS")
        //            {
        //                if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
        //                {
        //                    strchgweight = obj_da_Invoice.GetChargeWeight(txt_ablno.Text, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                    amount = rate * exrate * Convert.ToDouble(strchgweight);
        //                    unit = Convert.ToDouble(strchgweight);
        //                }
        //                else
        //                {
        //                    strgrosswght = obj_da_Invoice.GetGrossWeight(txt_ablno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                    amount = rate * exrate * Convert.ToDouble(strgrosswght);
        //                    unit = Convert.ToDouble(strgrosswght);
        //                }
        //            }
        //            else if (base1.ToUpper() == "SB")
        //            {
        //                if (Session["StrTranType"].ToString() == "FE")
        //                {
        //                    sizecount = obj_da_Invoice.GetSBillCount(txt_ablno.Text, Convert.ToInt32(txt_jobno.Text), "BL", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                    amount = rate * exrate * Convert.ToDouble(sizecount);
        //                    unit = Convert.ToDouble(sizecount);
        //                }
        //            }
        //            else if (base1.ToUpper() == "VOLUME")
        //            {
        //                strgrosswght = obj_da_Invoice.GetVolumeQty(txt_ablno.Text, Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                amount = rate * exrate * Convert.ToDouble(strgrosswght);
        //                unit = Convert.ToDouble(strgrosswght);
        //            }
        //            else
        //            {
        //                if (Session["StrTranType"].ToString() == "FE")
        //                {
        //                    sizecount = obj_da_Invoice.GetBaseCount(txt_ablno.Text, base1, Session["StrTranType"].ToString(), "BL", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                    amount = rate * exrate * Convert.ToDouble(sizecount);
        //                    unit = Convert.ToDouble(sizecount);
        //                }
        //                else
        //                {
        //                    sizecount = obj_da_Invoice.GetBaseCount(txt_ablno.Text, base1, Session["StrTranType"].ToString(), "BL", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
        //                    amount = rate * exrate * Convert.ToDouble(sizecount);
        //                    unit = Convert.ToDouble(sizecount);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //    return amount;
        //}
        public double checkbase(string base1, double rate, double exrate)
        {
            try
            {
                //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                if (base1.ToString().ToUpper() == "HWBL" || base1.ToString().ToUpper() == "FLAT RATE" || base1.ToString().ToUpper() == "HAWB")
                {
                    amount = rate * exrate;
                    hdnUnit.Value = "1";
                    hid_fd.Value = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                }
                else if (base1.ToString().ToUpper() == "KG".ToUpper() || base1.ToString().ToUpper() == "KGS".ToUpper() || base1.ToString().ToUpper() == "PER KG".ToUpper())
                {
                    if (str_trantype == "AE" || str_trantype == "AI")
                    {
                        
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgweight = obj_da_Invoice.GetChargeWeight(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgweight);
                        hdnUnit.Value = strchgweight.ToString();
                        //   unit = strchgweight.ToString();
                        hid_fd.Value = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");

                    }


                }
                else if (base1.ToString() == "COTTON/PALLET".ToUpper())
                {
                    if (str_trantype == "AE" || str_trantype == "AI")
                    {
                         
                      //  DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgpallet = obj_da_Invoice.Getchargepallet(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgpallet);
                        hdnUnit.Value = strchgpallet.ToString();
                        //   unit = strchgweight.ToString();
                        hid_fd.Value = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");

                    }
                }

                else if (base1.ToString() == "PERTRUCK".ToUpper())
                {
                    if (str_trantype == "AE" || str_trantype == "AI")
                    {
                         
                       // DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgtruck = obj_da_Invoice.Getchargetruck(txt_ablno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgtruck);
                        hdnUnit.Value = strchgtruck.ToString();
                        //   unit = strchgweight.ToString();
                        hid_fd.Value = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");

                    }
                }


                return amount;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

            return amount;
        }

        protected void ddl_cmbfreight_TextChanged(object sender, EventArgs e)
        {
            if (ddl_cmbfreight.SelectedValue == "PrePaid")
            {
                ddl_cmbwt.SelectedValue = "PrePaid";
                ddl_cmboth.SelectedValue = "PrePaid";
            }
            else
            {
                //ddl_cmbwt.SelectedValue = "To-Collect";
                //ddl_cmboth.SelectedValue = "To-Collect";

                ddl_cmbwt.SelectedValue = "Collect";
                ddl_cmboth.SelectedValue = "Collect";
            }
        }

        protected void txt_charge_TextChanged(object sender, EventArgs e)
        {
            if (txt_charge.Text.ToString() != "" && txt_rate.Text.ToString() != "")
            {
                double add;
                //   add = ((Convert.ToInt32(txt_charge.Text)) * (Convert.ToInt32(txt_rate.Text)));
                add = ((Convert.ToDouble(txt_charge.Text)) * (Convert.ToDouble(txt_rate.Text)));
                txt_rcamt.Text = add.ToString();
            }
            else
            {
                txt_rcamt.Text = "Nil";
            }
        }

        protected void Grid_shipperinvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        //if (e.Row.Cells[i].Text != "fileloc")
                        //{
                        e.Row.Cells[i].Text = "";
                        //}
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbudget, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                //  e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_shipperinvoice, "Select$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";
            }

        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            shipperinvoiceinsert();

            //if (Session["shipperinvoice"] != null)
            //{
                DataTable dtCurrentTable = (DataTable)Session["shipperinvoice"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox obj_txt_shipperinvoice = (TextBox)Grid_shipperinvoice.Rows[rowIndex].Cells[0].FindControl("txt_shipperinvoice");

                        drCurrentRow = dtCurrentTable.NewRow();

                        if (!string.IsNullOrEmpty(obj_txt_shipperinvoice.Text))
                        {
                            dtCurrentTable.Rows[i - 1]["Shipperinvoice"] = obj_txt_shipperinvoice.Text;
                        }
                        rowIndex++;
                    }

                    TextBox obj_txt_shipperinvoice1 =
                        (TextBox)Grid_shipperinvoice.Rows[rowIndex - 1].Cells[0].FindControl("txt_shipperinvoice");

                    if (obj_txt_shipperinvoice1.Text != "")
                    {
                        dtCurrentTable.Rows.Add(drCurrentRow);
                    }

                    Session["shipperinvoice"] = dtCurrentTable;

                    Grid_shipperinvoice.DataSource = dtCurrentTable;
                    Grid_shipperinvoice.DataBind();
                }
            //}
            //else
            //{
            //    Response.Write("ViewState is null");
            //}

            setshipper();
            this.ModalPopupExtender2.Show();



        }

        public void shipperinvoiceinsert()
        {
            //DataAccess.AirImportExports.AIEJobInfo objaejob = new DataAccess.AirImportExports.AIEJobInfo();
            if (Grid_shipperinvoice.Rows.Count > 0)
            {
                for (int i = 0; i <= Grid_shipperinvoice.Rows.Count - 1; i++)
                {
                    TextBox obj_txt_shipperinvoice = (TextBox)Grid_shipperinvoice.Rows[i].Cells[0].FindControl("txt_shipperinvoice");


                    if (obj_txt_shipperinvoice.Text == "")
                    {
                        break;
                    }
                    objaejob.insertshipperinvoice(txt_ablno.Text.Trim().ToUpper(), Session["StrTranType"].ToString(), obj_txt_shipperinvoice.Text, Convert.ToInt32(Session["LoginBranchid"]));


                }
            }
        }

        protected void Img_Delete_Click(object sender, EventArgs e)
        {

        }

        protected void Grid_shipperinvoice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex;
            if (e.CommandName == "Delete")
            {

                //int count= Grid_shipperinvoice.SelectedRow.RowIndex;
                rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = Grid_shipperinvoice.Rows[rowIndex];
                string shipperinv = (row.FindControl("txt_shipperinvoice") as TextBox).Text;

                //DataAccess.AirImportExports.AIEBLDetails objblae = new DataAccess.AirImportExports.AIEBLDetails();

                objblae.Delshipperinvoice(shipperinv.ToString(), txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Details Deleted.", true);
                Grid_shipperinvoice.DataSource = new DataTable();
                Grid_shipperinvoice.DataBind();
            }
        }

        protected void Grid_shipperinvoice_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void Grid_shipperinvoice_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void Img_Delete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //if (e.CommandName == "Delete")
                //{

                ImageButton lb = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                str_trantype = Session["StrTranType"].ToString();
                //int count= Grid_shipperinvoice.SelectedRow.RowIndex;
                // rowIndex = Convert.ToInt32(e.CommandArgument);
                // GridViewRow row = Grid_shipperinvoice.Rows[rowIndex];
                int rowID = gvRow.RowIndex;
                string shipperinv = (Grid_shipperinvoice.Rows[rowID].FindControl("txt_shipperinvoice") as TextBox).Text;//(grd.RowIndex.FindControl("txt_shipperinvoice") as TextBox).Text;

               // DataAccess.AirImportExports.AIEBLDetails objblae = new DataAccess.AirImportExports.AIEBLDetails();

                objblae.Delshipperinvoice(shipperinv.ToString(), txt_ablno.Text, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 6, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype + txt_ablno.Text.ToUpper() + "Del" + shipperinv.ToString());
                // ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);
                ScriptManager.RegisterStartupScript(this, typeof(ImageButton), "iFact Touch", "alertify.alert('Details Deleted');", true);


               // DataAccess.CostingTemp objcos = new DataAccess.CostingTemp();
                DataTable dtt = new DataTable();
                dtt = objcos.AEBLSHIPPERINVOICEGET(txt_ablno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_trantype);

                if (dtt.Rows.Count > 0)
                {
                    Grid_shipperinvoice.DataSource = dtt;
                    Grid_shipperinvoice.DataBind();
                    Session["shipperinvoice"] = dtt;
                }
                else
                {
                    //DataTable dt_temp = new DataTable();
                    //dt_temp.Columns.Add("Shipperinvoice");
                    //DataRow dr = dt_temp.NewRow();
                    //dt_temp.Rows.Add();
                    //Grid_shipperinvoice.DataSource = dt_temp;
                    //Grid_shipperinvoice.DataBind();

                    Grid_shipperinvoice.DataSource = new DataTable();
                    Grid_shipperinvoice.DataBind();
                    Session["shipperinvoice"] = new DataTable();
                }

                //txtclear();
            }

            //}
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "iFact Touch", "alertify.alert('" + message + "');", true);
            }

        }
        protected void Autocnops()
        {
            try
            {
                //dtinv = obj_da_BL.GetQuotchgs4Inv(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text);
                DataTable Dt = new DataTable();
                str_trantype = Session["StrTranType"].ToString();
                Dt = AEJobobj.GetAIEDetailregion(Convert.ToInt32(txt_jobno.Text), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Dt.Rows[0]["airlineid"].ToString()))
                    {
                        hid_intcustomerid.Value = Dt.Rows[0]["airlineid"].ToString();
                    }
                }
                Double amt = 0.00;
                if (Session["StrTranType"] != null)
                {

                    //dtinv = obj_da_BL.GetBuyingchgs4debitcredit(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text, Session["StrTranType"].ToString());
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew(txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["Loginbranchid"]));
                    }
                    else
                    {
                        dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew1(txt_ablno.Text.Trim().ToUpper(), Convert.ToInt32(Session["Loginbranchid"]));
                    }

                }
                hid_SupplyTo.Value = hid_intcustomerid.Value;
                if (dtinv.Rows.Count > 0)
                {
                    try
                    {

                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //    "Profoma Invoice", "", 0);
                        Refno1 = ProINVobj.InsProLVhead(Convert.ToDateTime(da_obj_Logobj.GetDate()), Session["StrTranType"].ToString(), Convert.ToInt32(txt_jobno.Text),
                               Convert.ToInt32(hid_intcustomerid.Value), txt_ablno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                              "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), 2, "",
                              0, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToDateTime(da_obj_Logobj.GetDate()));

                        //Refno1 = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(da_obj_Logobj.GetDate()), Session["StrTranType"].ToString(), Convert.ToInt32(txt_jobno.Text),
                        //   Convert.ToInt32(hid_intcustomerid.Value), txt_ablno.Text.Trim().ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //   "Profoma Payment Advise", "", 0, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToDateTime(da_obj_Logobj.GetDate()));

                        invgen1 = true;
                        for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                        {
                            base1 = dtinv.Rows[i]["base"].ToString();
                            rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                            exrate = obj_da_Invoice.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                            amount = checkbase(base1, rate, exrate);
                            //ProINVobj.InsertProInvoiceDetails(Refno1, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                            //    exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                            //    , "C", Session["StrTranType"].ToString(), "Profoma Payment Advise", "Y", unit);

                            ProINVobj.InsertProLVDetails(Refno1, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                               exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                               , "C", "FE", 2, "Y", unit);
                        }
                    }
                    catch (Exception ex)
                    {
                        //   Utility.SendMail(Session["usermailid"].ToString(), "", "bl pRO.iNV", ex.ToString(), "", Session["usermailpwd"].ToString(), "", "");
                    }
                }
                else
                {
                    invgen1 = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void autocreditOS()
        {
            int vouyear;

            if (hid_buyingno.Value == "")
            {
                hid_buyingno.Value = "0";

            }

            Double amt = 0.00;
            if (Session["StrTranType"] != null)
            {
                if (txt_bookno.Text != "")
                {
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        dtinv = obj_da_BL.GetBuyingchgs4debitcredit(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_bookno.Text, Session["StrTranType"].ToString());
                    }
                    else
                    {
                        dtinv = obj_da_BL.GetBuyingchgs4debitcredit1(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_bookno.Text, Session["StrTranType"].ToString());
                    }
                }
            }

            //DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
            DateTime dtdate = da_obj_logobj.GetDate();
            DateTime txtVendorRefnodate = da_obj_logobj.GetDate();
            double amt1 = 0, actual = 0.00;
            double fcamt1 = 0.00;
            if (dtinv.Rows.Count > 0)
            {
                if (da_obj_logobj.GetDate().Month < 4)
                {
                    vouyear = da_obj_logobj.GetDate().Year - 1;
                }
                else
                {
                    vouyear = da_obj_logobj.GetDate().Year;
                }
                hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                hid_SupplyTo.Value = hid_intagent.Value;
                DataTable dtd = new DataTable();
              //  DataAccess.AirImportExports.AIEJobInfo objaej = new DataAccess.AirImportExports.AIEJobInfo();
                dtd = objaej.GetAIagentid(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(txt_jobno.Text));

                CreditOS = true;
                refnodebitOs = da_obj_OSDNCN.InsproOSvouchershead(Convert.ToDateTime(dtdate), Session["StrTranType"].ToString(), Convert.ToDouble(amount),
                          Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                          Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                          Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 6, "", "");


                for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                {
                    if (dtinv.Rows[i]["agentid"].ToString() != "")
                    {
                        hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                        hid_SupplyTo.Value = hid_intagent.Value;
                    }
                    else
                    {
                        if (dtd.Rows[0]["agent"].ToString() != "")
                        {
                            hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                            hid_SupplyTo.Value = hid_intagent.Value;
                        }
                    }
                    if (dtd.Rows[0]["mawblno"].ToString() != "")
                    {
                        HIDMAWBLNO.Value = txt_ablno.Text.ToUpper();
                    }



                    base1 = dtinv.Rows[i]["base"].ToString();
                    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                    exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "C", Convert.ToInt32(Session["LoginDivisionId"]));
                    famount = checkbase(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                    string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                    actual = actual + Convert.ToDouble(osamount);
                    fd = Convert.ToInt32(hid_fd.Value);
                    unit = Convert.ToInt32(hdnUnit.Value);
                     
                    DAdvise.InsOSVdetails(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), HIDMAWBLNO.Value.ToUpper(),
                      Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                       base1, Convert.ToDouble(osamount), 6, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                       "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", refnodebitOs, Convert.ToInt32(vouyear));

                    //"Y", Convert.ToInt32(hid_intagent.Value));

                }

                /*  for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                  {
                      if (dtinv.Rows[i]["agentid"].ToString() != "")
                      {
                          hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                          hid_SupplyTo.Value = hid_intagent.Value;
                      }
                      else
                      {
                          if (dtd.Rows[0]["agent"].ToString() != "")
                          {
                              hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                              hid_SupplyTo.Value = hid_intagent.Value;
                          }
                      }
                      if (dtd.Rows[0]["mawblno"].ToString() != "")
                      {
                          HIDMAWBLNO.Value = txt_ablno.Text.Trim().ToUpper();
                      }



                      base1 = dtinv.Rows[i]["base"].ToString();
                      rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                      exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "C", Convert.ToInt32(Session["LoginDivisionId"]));
                      famount = CheckBaseos(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                      unit = Convert.ToDouble(douvolume);
                      //famount = CheckBaseos(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                      string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                      actual = actual + Convert.ToDouble(osamount);
                      //DAdvise.InsDCAdviseForGst(Convert.ToInt32(txt_jobno.Text), "AE", HIDMAWBLNO.Value.ToUpper(), Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate), base1, Convert.ToDouble(osamount), "DebitAdvise", Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(hid_intagent.Value));

                      //DAdvise.InsDCAdviseForGst(Convert.ToInt32(txt_jobno.Text), Session["StrTranType"].ToString(), HIDMAWBLNO.Value.ToUpper(), 
                      //    Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                      //    base1, Convert.ToDouble(osamount), "CreditAdvise", Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                          //"Y", Convert.ToInt32(hid_intagent.Value));

                      DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txt_jobno.Text), "OE", HIDMAWBLNO.Value.ToUpper(),
                         Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                         base1, Convert.ToDouble(osamount), 6, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                         "Y", Convert.ToInt32(hid_intagent.Value));

                      //int_djobno = da_obj_OSDNCN.GetOSDCNProJobCount(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSDN", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                      //int_cjobno = da_obj_OSDNCN.GetOSDCNProJobCount(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSCN", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                  }

                  DataAccess.AirImportExports.AIEBLDetails objae = new DataAccess.AirImportExports.AIEBLDetails();
                  //refnodebitOs = da_obj_OSDNCN.InsertOSDNProForGst(Convert.ToDateTime(dtdate), "AE", Convert.ToDouble(actual), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual, Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate);
                  //refnocreditOs = da_obj_OSDNCN.InsertOSCNProGst(Convert.ToDateTime(dtdate), Session["StrTranType"].ToString(), Convert.ToDouble(actual), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate);

                  refnodebitOs = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranType"].ToString(), Convert.ToDouble(amount),
                                                    Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 6);*/


                DataTable dttn = new DataTable();
                dttn = da_obj_OSDNCN.Getupdacdebitfcamt(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txt_jobno.Text));

                // dttn = da_obj_OSDNCN.Getupdacdebitfcamtnew(Convert.ToInt32(refnocreditOs), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txt_jobno.Text), "CreditAdvise");
                if (dttn.Rows.Count > 0)
                {
                    for (int i = 0; i <= dttn.Rows.Count - 1; i++)
                    {
                        if (dttn.Rows[i]["fcamt"].ToString() != "")
                        {
                            fcamt1 = fcamt1 + Convert.ToDouble(dttn.Rows[i]["fcamt"]);
                        }
                    }

                }
                da_obj_OSDNCN.Getupdacosdnproupdnew(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txt_jobno.Text), fcamt1, "CreditAdvise");




            }
            else
            {
                CreditOS = false;
            }

        }



        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {

                int chargeid1 = 0; double amount1 = 0;
                if (txt_acc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter Acc');", true);
                    txt_acc.Focus();
                    return;
                }
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                if (txt_ablno.Text != "" && txt_jobno.Text != "")
                {
                    jobno = Convert.ToInt32(txt_jobno.Text);
                    if (txt_acc.Text != "")
                    {
                        AEBLobj.UpdAccInfo4febl(jobno, txt_ablno.Text, bid, txt_acc.Text);
                    }
                    if (btn_save.ToolTip == "Save")
                    {
                        if (Grd_Charge.Rows.Count > 0)
                        {
                            for (int i = 0; i < Grd_Charge.Rows.Count; i++)
                            {
                                if (Grd_Charge.Rows[i].Cells[2].Text == "Prepaid")
                                {
                                    ppcc = "P";
                                }
                                else
                                {
                                    ppcc = "C";
                                }
                                chargeid1 = Convert.ToInt32(Grd_Charge.Rows[i].Cells[3].Text);
                                amount1 = Convert.ToDouble(Grd_Charge.Rows[i].Cells[1].Text);
                                AEBLobj.InsAEBLChargeDtls(jobno, chargeid1, amount1, ppcc, txt_ablno.Text, bid);
                                da_obj_Logobj.InsLogDetail(empid, 1262, 1, bid, "AWBChrg-" + txt_jobno.Text + "/" + txt_ablno.Text + "/" + Grd_Charge.Rows[i].Cells[3].Text + "/" + Grd_Charge.Rows[i].Cells[1].Text + "/" + ppcc);
                            }
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved');", true);

                            btn_save.Text = "Update";
                            btn_back.Text = "Cancel";

                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn ico-update";
                            btn_back.ToolTip = "Cancel";
                            btn_back1.Attributes["class"] = "btn ico-cancel";

                        }
                        //  ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Some Details are misssing');", true);

                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        AEBLobj.DelAEBLChargeDtls(jobno, txt_ablno.Text, bid);
                        if (Grd_Charge.Rows.Count > 0)
                        {
                            for (int i = 0; i < Grd_Charge.Rows.Count; i++)
                            {
                                if (Grd_Charge.Rows[i].Cells[2].Text == "Prepaid")
                                {
                                    ppcc = "P";
                                }
                                else
                                {
                                    ppcc = "C";
                                }

                                chargeid1 = Convert.ToInt32(Grd_Charge.Rows[i].Cells[3].Text);
                                amount1 = Convert.ToDouble(Grd_Charge.Rows[i].Cells[1].Text);
                                AEBLobj.InsAEBLChargeDtls(jobno, chargeid1, amount1, ppcc, txt_ablno.Text, bid);
                                da_obj_Logobj.InsLogDetail(empid, 1262, 2, bid, "AWBChrg-" + txt_jobno.Text + "/" + txt_ablno.Text + "/" + Grd_Charge.Rows[i].Cells[3].Text + "/" + Grd_Charge.Rows[i].Cells[1].Text + "/" + ppcc);

                            }
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                            btn_save.Text = "Update";
                            btn_back.Text = "Cancel";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn ico-update";

                            btn_back.ToolTip = "Cancel";
                            btn_back1.Attributes["class"] = "btn ico-cancel";


                        }
                        // ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Some Details are misssing');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            string a, b;
            if (ddl_charge.SelectedIndex != -1 && txt_amt.Text != "" && ddl_pc.SelectedIndex != -1 && txt_amt.Text != "0")
            {
                if (ddl_charge.SelectedValue == "Valuation Charge")
                {
                    chargeid = 1;
                }
                else if (ddl_charge.SelectedValue == "Total Other Charges Due Agent")
                {
                    chargeid = 2;
                }
                else if (ddl_charge.SelectedValue == "Total Other Charges Due Carrier")
                {
                    chargeid = 3;
                }

                if (btn_add.ToolTip == "Add")
                {
                    if (Grd_Charge.Rows.Count > 0)
                    {
                        count = 0;
                        for (i = 0; i <= Grd_Charge.Rows.Count - 1; i++)
                        {
                            a = Grd_Charge.Rows[i].Cells[0].Text.ToString();
                            b = Grd_Charge.Rows[i].Cells[2].Text.ToString();
                            if (ddl_charge.SelectedValue == Grd_Charge.Rows[i].Cells[0].Text.ToString() && ddl_pc.SelectedValue == Grd_Charge.Rows[i].Cells[2].Text.ToString())
                            {
                                count = count + 1;
                            }
                        }
                    }

                    if (count >= 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "DataFound", "alertify.alert('Details already exist');", true);
                        txt_amt.Text = "";
                        ddl_charge.SelectedValue = "Valuation Charge";
                        ddl_pc.SelectedValue = "Prepaid";
                        return;
                    }


                    if (ViewState["CurrentData"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["CurrentData"];
                        int countval = dt.Rows.Count;
                        BindGrid(countval, ddl_charge.SelectedValue, txt_amt.Text.ToUpper().Trim(), ddl_pc.SelectedValue, chargeid);
                        txt_amt.Text = "";
                        ddl_charge.SelectedValue = "Valuation Charge";
                        ddl_pc.SelectedValue = "Prepaid";
                        btn_back.Text = "Cancel";

                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";

                    }

                    else
                    {
                        BindGrid(1, ddl_charge.SelectedValue, txt_amt.Text.ToUpper().Trim(), ddl_pc.SelectedValue, chargeid);
                        txt_amt.Text = "";
                        ddl_charge.SelectedValue = "Valuation Charge";
                        ddl_pc.SelectedValue = "Prepaid";
                        btn_add.Text = "Add";
                        btn_back.Text = "Cancel";
                        btn_add.ToolTip = "Add";
                        btn_addn1.Attributes["class"] = "btn ico-add";
                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";

                    }
                }
                else
                {
                    if (btn_add.ToolTip == "Update")
                    {

                        int rowval = Convert.ToInt32(Session["Rowindex"].ToString());
                        Grd_Charge.Rows[rowval].Cells[0].Text = ddl_charge.SelectedValue;
                        Grd_Charge.Rows[rowval].Cells[1].Text = txt_amt.Text;
                        Grd_Charge.Rows[rowval].Cells[2].Text = ddl_pc.SelectedValue;

                        if (Grd_Charge.Rows[rowval].Cells[0].Text == "Valuation Charge")
                        {
                            chargeid = 1;
                        }
                        else if (Grd_Charge.Rows[rowval].Cells[0].Text == "Total Other Charges Due Agent")
                        {
                            chargeid = 2;
                        }
                        else if (Grd_Charge.Rows[rowval].Cells[0].Text == "Total Other Charges Due Carrier")
                        {
                            chargeid = 3;
                        }
                        //BindGrid(rowval, ddl_charge.SelectedValue, txt_amt.Text.ToUpper().Trim(), ddl_pc.SelectedValue, chargeid);
                        Grd_Charge.Rows[rowval].Cells[3].Text = chargeid.ToString(); ;
                        btn_add.Text = "Add";
                        btn_back.Text = "Cancel";


                        btn_add.ToolTip = "Add";
                        btn_addn1.Attributes["class"] = "btn ico-add";
                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";

                    }

                }

            }

            txt_amt.Text = "";
            ddl_charge.SelectedValue = "Valuation Charge";
            ddl_pc.SelectedValue = "Prepaid";


        }

        private void BindGrid(int rowcount, string Chgnameame, string cuAmount, string ppccval, int chargeid)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("charges", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("amount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ppcc", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("chargeid", typeof(String)));

            if (ViewState["CurrentData"] != null)
            {

                ImageButton btndelete = new ImageButton();
                foreach (GridViewRow row in Grd_Charge.Rows)
                {
                    btndelete = (ImageButton)row.FindControl("imgdelete");
                    btndelete.Visible = true;

                }

                dt = (DataTable)ViewState["CurrentData"];

                if (dt.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr[0] = dt.Rows[0][0].ToString();
                }



                dr = dt.NewRow();
                dr[0] = ddl_charge.SelectedValue;
                double temp = Convert.ToDouble(txt_amt.Text);
                dr[1] = temp.ToString("#,0.00");
                // dr[1] =Convert.t (txt_amt.Text.ToString("#,0.00"));
                dr[2] = ddl_pc.SelectedValue;
                dr[3] = chargeid;

                dt.Rows.Add(dr);
                ViewState["CurrentData"] = dt;
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = ddl_charge.SelectedValue;
                double temp = Convert.ToDouble(txt_amt.Text);
                dr[1] = temp.ToString("#,0.00");
                dr[2] = ddl_pc.SelectedValue;
                dr[3] = chargeid;

                dt.Rows.Add(dr);
                ViewState["CurrentData"] = dt;
            }

            if (ViewState["CurrentData"] != null)
            {
                Grd_Charge.DataSource = (DataTable)ViewState["CurrentData"];
                Grd_Charge.DataBind();
            }
            else
            {
                Grd_Charge.DataSource = dt;
                Grd_Charge.DataBind();

            }

            ViewState["CurrentData"] = dt;

        }
        protected void Grd_Charge_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Charge, "Select$" + e.Row.RowIndex);\
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void imgdelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton lb = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            Session["Rowindex"] = rowID;
            if (hfWasConfirmed.Value == "true")
            {
                if (ViewState["CurrentData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        if (gvRow.RowIndex < dt.Rows.Count)
                        {

                            dt.Rows.Remove(dt.Rows[rowID]);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted from Grid ,Plz click update Button again...');", true);
                        }
                        ddl_charge.SelectedIndex = -1;
                        ddl_pc.SelectedIndex = -1;
                        txt_amt.Text = "";
                        btn_add.Text = "Add";
                        btn_add.ToolTip = "Add";
                        btn_addn1.Attributes["class"] = "btn ico-add";

                    }

                    ViewState["CurrentData"] = dt;
                    Grd_Charge.DataSource = dt;
                    Grd_Charge.DataBind();
                    if (Grd_Charge.Rows.Count == 0)
                    {
                        EmptyGrid_Charge();
                    }
                    if (Grd_Charge.Rows.Count > 0)
                    {

                        btn_save.Text = "Save";

                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                    }
                }
            }
            else
            {
                if (Grd_Charge.Rows.Count > 0)
                {
                    ddl_charge.SelectedValue = Grd_Charge.Rows[rowID].Cells[0].Text;
                    txt_amt.Text = Grd_Charge.Rows[rowID].Cells[1].Text;
                    ddl_pc.SelectedValue = Grd_Charge.Rows[rowID].Cells[2].Text;
                    btn_add.Text = "Update";
                    btn_back.Text = "Cancel";
                    btn_add.ToolTip = "Update";
                    btn_addn1.Attributes["class"] = "btn ico-Update";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
            }
            // btn_save.Text = "Update";
            btn_save.ToolTip = "Update";
            btn_save1.Attributes["class"] = "btn ico-update";
        }
        protected void btn_job_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if(trantype_process=="AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(5, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../AE/AEJobInfo.aspx?back=yes" + "&job=" + txt_jobno.Text);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            else
            {
                dtuser = obj_UP.GetFormwiseuserRights(7, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../AE/AEJobInfo.aspx?back=yes" + "&job=" + txt_jobno.Text);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            
                
          

        }
        protected void Btnamendbl_Click(object sender, EventArgs e)
        {
            DataTable dtuser;
            if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(96, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        iframecost.Attributes["src"] = "../ForwardExports/AmendBL.aspx?jobno=" + txt_jobno.Text;
                        pop_up.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('AWB # cannot be Empty!');", true);
                        txt_ablno.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
          else  if (Session["StrTranType"].ToString() == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(95, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        iframecost.Attributes["src"] = "../ForwardExports/AmendBL.aspx?jobno=" + txt_jobno.Text;
                        pop_up.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('AWB # cannot be Empty!');", true);
                        txt_ablno.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        public void Mail4ODCDimension()
        {
            try
            {
                //DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
                //DataAccess.UserPermission obj_da_user = new DataAccess.UserPermission();
                DataTable obj_dtdim = new DataTable();
                string str_Empmail = "";
                string Str_Temp = "";
                Boolean blr1 = false;
                DataTable Dt_Dimension1;

                //Newly add for DIMENSIONS start 



                Dt_Dimension1 = da_obj_AEBLobj.GetAIEBLDimension(txt_ablno.Text.ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt_Dimension1.Rows.Count > 0)
                {
                    for (int i = 0; i <= Dt_Dimension1.Rows.Count - 1; i++)
                    {
                        DropDownList obj_ddl_cminch = (DropDownList)grd_grddimension.Rows[i].FindControl("cminch");
                        if (Dt_Dimension1.Rows[i][4].ToString() == "Inch")
                        {
                            obj_ddl_cminch.SelectedValue = "I";
                        }
                        else
                        {
                            obj_ddl_cminch.SelectedValue = "C";
                        }

                        if (obj_ddl_cminch.SelectedItem.Value == "C")
                        {
                            double len = Convert.ToDouble(Dt_Dimension1.Rows[i][0].ToString());
                            double WIDTH = Convert.ToDouble(Dt_Dimension1.Rows[i][2].ToString());
                            double HEIGHT = Convert.ToDouble(Dt_Dimension1.Rows[i][1].ToString());
                            if (len > 315.00 || WIDTH > 200.00 || HEIGHT > 152.00)
                            {
                                blr1 = true;

                            }
                        }

                    }



                }

                if (blr1 == true)
                {

                    obj_dtdim = obj_da_user.Getdimensionmailid();


                    str_Empmail = obj_dtdim.Rows[0]["mailid"].ToString();
                    Str_Temp = Str_Temp + "<p  style='font-size:12px;'>Dear sir,</p></br>";


                    Str_Temp = Str_Temp + "<p  style='font-size:12px;'>Kindly find Below Dimension Details</p></br>";
                    if (Dt_Dimension1.Rows.Count > 0)
                    {

                        Str_Temp = Str_Temp + "<table border=1>";
                        //add header row
                        Str_Temp += "<tr>";
                        //for (int i = 0; i < Dt_Dimension1.Columns.Count; i++)
                        //{
                        //    Str_Temp += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>" + Dt_Dimension1.Columns[i].ColumnName + "</label></td>";
                        //}


                        Str_Temp += "<th style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>Allowed Length</label></th>";

                        Str_Temp += "<th style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>Length</label></th>";


                        Str_Temp += "<th style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>Allowed Width</label></th>";
                        Str_Temp += "<th style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>Width</label></th>";

                        Str_Temp += "<th style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>Allowed Height</label></th>";
                        Str_Temp += "<th style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>Height</label></th>";
                        Str_Temp += "</tr>";
                        //add rows
                        for (int i = 0; i < Dt_Dimension1.Rows.Count; i++)
                        {
                            Str_Temp += "<tr>";
                            Str_Temp += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>" + "315" + "</label></td>";

                            Str_Temp += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>" + Dt_Dimension1.Rows[i]["length"].ToString() + "</label></td>";

                            Str_Temp += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>" + "200" + "</label></td>";

                            Str_Temp += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>" + Dt_Dimension1.Rows[i]["breadth"].ToString() + "</label></td>";//Changed11Nov2021


                            Str_Temp += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>" + "152" + "</label></td>";

                            Str_Temp += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:90px;'>" + Dt_Dimension1.Rows[i]["width"].ToString() + "</label></td>";//Changed11Nov2021


                            Str_Temp += "</tr>";
                        }
                        Str_Temp += "</table></br>";
                        Str_Temp = Str_Temp + "<p style='font-size:12px;'>Request You to Look at the  Above Dimension for the subject AWB</p></br>";
                    }
                    //   div_body.Visible = true;
                    //   div_body.InnerHtml = Server.HtmlDecode(Str_Temp);// Server.HtmlDecode("<table border=1><tr><td>test</td></tr></table>");


                    //Utility.SendMail(Session["usermailid"].ToString(), str_Empmail, "Abnormal ODC (OVER DIMESIONS !!!! ALERT!!!!" + " JOB  " + txt_jobno.Text + " HAWBL  " + txt_ablno.Text, Str_Temp, "", Session["usermailpwd"].ToString());//hideon11Nov2021


                    Utility.SendMail(Session["usermailid"].ToString(), str_Empmail, "Abnormal ODC (OVER DIMESIONS !!!! ALERT!!!!" + " JOB # " + txt_jobno.Text + " / HAWBL # " + txt_ablno.Text + " / SHIPPER : " + txt_shipper.Text + " / CONSIGNEE : " + txt_consignee.Text, Str_Temp, "", Session["usermailpwd"].ToString());


                    //if (Dt_Dimension1.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i <= Dt_Dimension1.Rows.Count - 1; i++)
                    //    {
                    //        Str_Temp = Str_Temp + "<tr><td style='padding:3px;'>length</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + Dt_Dimension1.Rows[i]["length"].ToString() + "</td></tr>";
                    //        Str_Temp = Str_Temp + "<tr><td style='padding:3px;'>width</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + Dt_Dimension1.Rows[i]["width"].ToString() + "</td></tr>";
                    //        Str_Temp = Str_Temp + "<tr><td style='padding:3px;'>HEIGHT</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + Dt_Dimension1.Rows[i]["HEIGHT"].ToString() + "</td></tr>";
                    //    }
                    //}
                    //   Utility.SendMail(Session["usermailid"].ToString(), str_Empmail, "Abnormal ODC (OVER DIMESIONS !!!! ALERT!!!!"+" JOB "+txt_jobno.Text +" HAWBL " +txt_ablno.Text , Str_Temp, "", Session["usermailpwd"].ToString());
                }
            }
            catch (Exception e)
            {

            }
            //Newly add for DIMENSIONS end
        }

    }
}