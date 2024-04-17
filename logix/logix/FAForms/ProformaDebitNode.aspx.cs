using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.FAForms
{
    public partial class ProformaDebitNode : System.Web.UI.Page
    {
        Double amount, strvolume, doublevolume, strntweight, strchgweight, strgrosswght, sizecount, famount;
        string strTranType = "", type, fd;
        int divisionid, branchid;
        string vessel, voyage, agent, jobtype, gross, chwt;
        DateTime eta;
        string str_Uiid = "", str_FornName;
        DataTable Dt = new DataTable();
      
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.BLDetailsWOJob FEBLWoJobj = new DataAccess.ForwardingExports.BLDetailsWOJob();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
        Boolean blrr, bolcuststat;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txt_to);
            
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            string str_FornName = "", str_Uiid = "";

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                txt_Refno.Focus();
                lbl_Header.Text = Request.QueryString["type"].ToString();
                divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["type"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, btn_delete);
                }
                if (Request.QueryString.ToString().Contains("type"))
                {
                    lbl_Header.Text = Request.QueryString["type"].ToString();
                    if (lbl_Header.Text == "Proforma Debit Note")
                    {
                        lbl_Header.Text = "Profoma Debit Note";
                        type = lbl_Header.Text;
                    }
                    else if (lbl_Header.Text == "Proforma Credit Note")
                    {
                        lbl_Header.Text = "Profoma Credit Note";
                        type = lbl_Header.Text;

                    }
                    Session["Header"] = type;
                }

                if (lbl_Header.Text == "Profoma Debit Note")
                {
                    // lbl_DN.Text = "DN #";
                    hid_type.Value = "R";
                    // lbl_vendor_DN.Visible = false;
                    txt_vendor_DN.Visible = false;
                    div_volumelist.Attributes["class"] = "div_volume_CN";
                    txt_DN.Attributes.Add("placeholder", "DN#");
                    txt_DN.ToolTip = "DN Number";
                    txt_to.ToolTip = "Bill To";
                    txtsupplyto.ToolTip = "Supply To";
                    txt_to.Attributes["Placeholder"] = "Bill To";
                    txtsupplyto.Attributes["Placeholder"] = "Supply To";
                }
                else
                {

                    txt_to.ToolTip = "Bill From";
                    txtsupplyto.ToolTip = "Supply From";
                    txt_to.Attributes["Placeholder"] = "Bill From";
                    txtsupplyto.Attributes["Placeholder"] = "Supply From";
                    //lbl_DN.Text = "CN #";
                    hid_type.Value = "C";
                    // lbl_vendor_DN.Visible = true;
                    txt_vendor_DN.Visible = true;
                    div_volumelist.Attributes["class"] = "div_volume";
                    txt_DN.Attributes.Add("placeholder", "CN #");
                    txt_DN.ToolTip = "CN Number";
                }
            
                string str_CtrlLists, str_MsgLists, str_DataType;
                strTranType = Session["StrTranType"].ToString();
                str_CtrlLists = "txt_bl~txt_to~hid_customerid~ddl_bill";
                str_MsgLists = "BL#~Customer~Customer~BillType";
                str_DataType = "String~String~AutoComplete~ddl";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                str_CtrlLists = "txt_charge~hid_chargeid~txt_curr~txt_rate~ddl_base";
                str_MsgLists = "ChargeName~ChargeName~Currency~Rate~Base";
                str_DataType = "String~AutoComplete~String~String~ddl";
                btn_add.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                btn_delete.Attributes.Add("OnClick", "if(confirm('Do U want Delete ?')){return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');}else{return false;}");

                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                txt_date.Text = hid_date.Value.ToString();
                FillOnPageLoad();
                DataTable obj_dt = new DataTable();
                Grd_Charge.DataSource = obj_dt;
                Grd_Charge.DataBind();
                txt_DN.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_year.Text = Session["Vouyear"].ToString();
                txt_Refno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_rate.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_rate.Attributes.Add("OnBlur", "return IsDoubleCheck('txt_rate');");
                txt_exrate.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_exrate.Attributes.Add("OnBlur", "return IsDoubleCheck('txt_exrate');");
                HeaderLabel.InnerText = lbl_Header.Text;
                UserRights();
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
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        //[WebMethod]
        //public static List<string> GetToCust(string prefix)
        //{
        //    DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        //    DataTable Dt = new DataTable();
        //    List<string> custname = new List<string>();

        //    string a = HttpContext.Current.Session["cmbbill"].ToString();
        //    if (HttpContext.Current.Session["cmbbill"].ToString() == "Internal")
        //    {

        //        Dt = customerobj.GetLikeCustomerproforma(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
        //    }
        //    else
        //    {
        //        Dt = customerobj.GetLikeIndianCustomer(prefix);

        //    }
        //    custname = Utility.Fn_TableToList_Cust1(Dt, "customer", "customerid", "address");
        //    return custname;
        //}

        public void FillOnPageLoad()
        {
            try
            {

               
                ddl_bill.Items.Clear();
                ddl_bill.Items.Add("");
                ddl_bill.Items.Add("Cash/Cheque");
                ddl_bill.Items.Add("Credit");
                ddl_bill.Items.Add("Internal");
                if (Convert.ToDateTime( Utility.fn_ConvertDate(txt_date.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                {                                      
                   
                }
                else
                {                    
                    ddl_bill.Items.Add("ST/GST Exemption");
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

        }

        protected void txt_Refno_TextChanged(object sender, EventArgs e)
        {
            DataAccess.Accounts.ProfomaInvoice obj_da_ProInvoice = new DataAccess.Accounts.ProfomaInvoice();
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            DataTable obj_dt = new DataTable();
            Fn_Clear1();
            Fn_ChargeClear();
            obj_dt = obj_da_ProInvoice.SelProInvHead(int.Parse(txt_Refno.Text), "", int.Parse(txt_year.Text), int.Parse(Session["LoginBranchid"].ToString()), lbl_Header.Text);
            if (obj_dt.Rows.Count > 0)
            {
                txt_job.Text = obj_dt.Rows[0]["jobno"].ToString();
                rbt_agent.Checked = false;
                rbt_customer.Checked = false;
                hid_customerid.Value = obj_dt.Rows[0]["customerid"].ToString();
                if (obj_da_Customer.GetCustomerType(int.Parse(obj_dt.Rows[0]["customerid"].ToString())) == "C")
                {
                    rbt_customer.Checked = true;
                }
                else
                {
                    rbt_agent.Checked = true;
                }
                txt_to.Text = obj_dt.Rows[0]["customername"].ToString();
                txt_bl.Text = obj_dt.Rows[0]["blno"].ToString();
                txt_bl_TextChanged(sender, e);
                txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
             //   ddl_bill.Text = obj_dt.Rows[0]["billtype"].ToString();
                ddl_bill.SelectedValue = obj_dt.Rows[0]["billtype"].ToString();
                txt_date.Text = obj_dt.Rows[0][1].ToString();
                hid_SupplyTo.Value = obj_dt.Rows[0]["SupplyTo"].ToString();
                txtsupplyto.Text = obj_dt.Rows[0]["SupplyToName"].ToString();

                txtaddress.Text = customerobj.GetCustomerAddress(Convert.ToInt32(hid_customerid.Value));

                if (!string.IsNullOrEmpty(obj_dt.Rows[0]["SupplyTo"].ToString()))
                {
                    hid_SupplyTo.Value = obj_dt.Rows[0]["SupplyTo"].ToString();
                    hid_SupplyTonew.Value = obj_dt.Rows[0]["SupplyTo"].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0]["SupplyToName"].ToString()))
                {
                    txtsupplyto.Text = obj_dt.Rows[0]["SupplyToName"].ToString();
                     //txtsupplytoAddress.Text = customerobj.GetCustomerAddress(Convert.ToInt32(hid_SupplyTo.Value));


                    string citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                    txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                }

                if (lbl_Header.Text == "Profoma Credit Note")
                {
                    if (DBNull.Value.Equals(obj_dt.Rows[0]["vendorrefno"]) == false)
                    {
                        txt_vendor.Text = obj_dt.Rows[0]["vendorrefno"].ToString();
                    }
                    else
                    {
                        txt_vendor.Text = "";
                    }
                    txt_credit.Text = obj_dt.Rows[0]["creditdays"].ToString();
                }
                else
                {
                    txt_vendor.Text = "";
                    txt_credit.Text = "";
                }
                ddl_bill.Items.Clear();
                ddl_bill.Items.Add("");
                ddl_bill.Items.Add("Cash/Cheque");
                ddl_bill.Items.Add("Credit");
                ddl_bill.Items.Add("Internal");

                string bill = obj_dt.Rows[0]["billtype"].ToString();

                if (Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                {

                    if (bill == "Cash/Cheque")
                    {
                        ddl_bill.SelectedIndex = 1;
                    }
                    else if (bill == "Credit")
                    {
                        ddl_bill.SelectedIndex = 2;
                    }

                    else if (bill == "Internal")
                    {
                        ddl_bill.SelectedIndex = 3;
                    }
                    else if (bill == "--BILLTYPE--")
                    {
                        ddl_bill.SelectedIndex = 0;
                    }


                   
                }
                else
                {
                    ddl_bill.Items.Add("ST/GST Exemption");
                    if (bill == "Cash/Cheque")
                    {
                        ddl_bill.SelectedIndex = 1;
                    }
                    else if (bill == "Credit")
                    {
                        ddl_bill.SelectedIndex = 2;
                    }
                    else if (bill == "Internal")
                    {
                        ddl_bill.SelectedIndex = 3;
                    }
                    else if (bill == "ST/GST Exemption")
                    {
                        ddl_bill.SelectedIndex = 4;
                    }
                    else if (bill == "--BILLTYPE--")
                    {
                        ddl_bill.SelectedIndex = 0;
                    }
                  
                }

                string str_tantype = obj_dt.Rows[0]["trantype"].ToString();
                ddl_module.SelectedValue = str_tantype;
                Fn_LoadBase();
                DataTable obj_dttemp = new DataTable();
                DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
                string Str_Columnname = "";
                if (str_tantype == "FE" || str_tantype == "FI")
                {
                    if (txt_bl.Text.ToUpper().ToString().Trim().Length > 0)
                    {
                        obj_dttemp = obj_da_DC.FillIPBLNo(int.Parse(txt_job.Text), str_tantype, int.Parse(Session["LoginBranchid"].ToString()));
                        Str_Columnname = obj_dttemp.Columns[0].ColumnName.ToString();
                        DataView view = new DataView(obj_dttemp);
                        view.RowFilter = Str_Columnname + "='" + txt_bl.Text.ToUpper() + "'";
                        obj_dttemp = view.ToTable();
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            Chk_Mbl.Checked = true;
                        }
                        else
                        {
                            Chk_Mbl.Checked = false;
                        }
                        Fn_FEGetdetail(str_tantype);
                    }
                }
                else if (str_tantype == "AE" || str_tantype == "AI")
                {
                    if (txt_bl.Text.ToUpper().ToString().Trim().Length > 0)
                    {
                        obj_dttemp = obj_da_DC.FillIPBLNo(int.Parse(txt_job.Text), str_tantype, int.Parse(Session["LoginBranchid"].ToString()));
                        Str_Columnname = obj_dttemp.Columns[0].ColumnName.ToString();
                        DataView view = new DataView(obj_dttemp);
                        view.RowFilter = Str_Columnname + "='" + txt_bl.Text.ToUpper() + "'";
                        obj_dttemp = view.ToTable();
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            Chk_Mbl.Checked = true;
                        }
                        else
                        {
                            Chk_Mbl.Checked = false;
                        }
                        Fn_AEGetdetail(str_tantype);
                    }
                }
                else
                {
                    if (txt_bl.Text.ToUpper().ToString().Trim().Length > 0)
                    {
                        Fn_CHGetdetail(str_tantype);
                    }
                }
                Fn_Getdetail();
                //btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
            }
            else
            {
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                if (lbl_Header.Text == "Profoma Credit Note")
                {
                    obj_dt = obj_da_Invoice.Getrefid(int.Parse(txt_Refno.Text), int.Parse(txt_year.Text), int.Parse(Session["LoginBranchid"].ToString()), "Credit Note");
                }
                else
                {
                    obj_dt = obj_da_Invoice.Getrefid(int.Parse(txt_Refno.Text), int.Parse(txt_year.Text), int.Parse(Session["LoginBranchid"].ToString()), "Debit Note");
                }
                if (obj_dt.Rows.Count > 0)
                {
                    txt_Refno.Text = "";                    
                    ScriptManager.RegisterStartupScript(txt_Refno, typeof(TextBox), "Debit", "alertify.alert('Already Transferred');", true);
                    txt_Refno.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_Refno, typeof(TextBox), "Debit", "alertify.alert('Invalid Refno');", true);
                    Fn_Clear();
                    Fn_ChargeClear();
                    txt_Refno.Focus();
                }
            }
            UserRights();
        }

        private void Fn_FEGetdetail(string Type)
        {
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            DataTable obj_dt = new DataTable();
            DataTable obj_dt1 = new DataTable();
            DataAccess.ForwardingExports.JobInfo obj_da_FEJob = new DataAccess.ForwardingExports.JobInfo();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            if (Type == "FE")
            {
                if (lbl_Header.Text != "InvoiceWoJ")
                {
                    if (Chk_Mbl.Checked == true)
                    {
                        txt_job.Text = obj_da_FEJob.GetJobNo(txt_bl.Text.ToUpper(), int_bid, int_divisionid).ToString();

                        obj_dt = obj_da_Invoice.GetMblContainerDtls(int.Parse(txt_job.Text), txt_job.Text, Type, int_bid);

                        lst_volume.Items.Clear();
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            lst_volume.Items.Add(obj_dt.Rows[i][0].ToString());
                        }

                        obj_dt = obj_da_Invoice.GetHblNoOfContainers(int.Parse(txt_job.Text), txt_job.Text, Type, int_bid);
                        lst_container.Items.Clear();
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            lst_container.Items.Add(obj_dt.Rows[i][1].ToString() + "Container , " + obj_dt.Rows[i][0].ToString());
                        }
                        obj_dt = obj_da_FEJob.GetFEJobInfo(int.Parse(txt_job.Text), int_bid, int_divisionid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            vessel = obj_dt.Rows[0][3].ToString();
                            voyage = obj_dt.Rows[0][7].ToString();

                            eta = Convert.ToDateTime(obj_dt.Rows[0][9].ToString());
                            txtEta.Text = Convert.ToString(eta.ToShortDateString());
                            txt_vessel.Text = txt_job.Text + "/" + vessel + "/" + voyage;
                            txt_mlo.Text = obj_dt.Rows[0][6].ToString();
                            txt_agent.Text = obj_dt.Rows[0][5].ToString();
                            agent = obj_dt.Rows[0][14].ToString();
                            txt_destination.Text = obj_dt.Rows[0][4].ToString();
                            jobtype = obj_dt.Rows[0][13].ToString();
                            hid_mloid.Value = obj_dt.Rows[0]["mloid"].ToString();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();

                        obj_dt = obj_da_FEBL.GetBLDetails(txt_bl.Text.ToUpper(), int_bid, int_divisionid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_job.Text = obj_dt.Rows[0][0].ToString();
                            txt_shipper.Text = obj_dt.Rows[0][4].ToString();
                            txt_consignee.Text = obj_dt.Rows[0][6].ToString();
                            txt_notify.Text = obj_dt.Rows[0][8].ToString();
                            txt_cnf.Text = obj_dt.Rows[0][16].ToString();

                            hid_cosigneeid.Value = obj_dt.Rows[0]["consigneeid"].ToString();

                            obj_dt = obj_da_FEJob.GetFEJobInfo(int.Parse(txt_job.Text), int_bid, int_divisionid);
                            if (obj_dt.Rows.Count > 0)
                            {
                                vessel = obj_dt.Rows[0][3].ToString();
                                voyage = obj_dt.Rows[0][7].ToString();

                                eta = Convert.ToDateTime(obj_dt.Rows[0][9].ToString());
                                txtEta.Text = Convert.ToString(eta.ToShortDateString());
                                txt_vessel.Text = txt_job.Text + "/" + vessel + "/" + voyage;
                                txt_mlo.Text = obj_dt.Rows[0][6].ToString();
                                txt_agent.Text = obj_dt.Rows[0][5].ToString();
                                agent = obj_dt.Rows[0][14].ToString();
                                txt_destination.Text = obj_dt.Rows[0][4].ToString();
                                jobtype = obj_dt.Rows[0][13].ToString();
                                hid_mloid.Value = obj_dt.Rows[0]["mloid"].ToString();
                            }
                            else
                            {

                            }

                            obj_dt = obj_da_Invoice.GetHBLContainerDtls(txt_bl.Text.ToUpper(), Type, int_bid);

                            if (obj_dt.Rows.Count > 0)
                            {
                                lst_volume.Items.Clear();
                                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                {
                                    lst_volume.Items.Add(obj_dt.Rows[i][0].ToString());
                                }
                                lst_volume.Items.Add(obj_dt.Rows[0][1].ToString() + " cbm");
                                lst_volume.Items.Add(obj_dt.Rows[0][2].ToString() + " Kgs");
                                lst_container.Items.Clear();
                                obj_dt1 = obj_da_Invoice.GetHblNoOfContainers(int.Parse(txt_job.Text), txt_bl.Text, Type, int_bid);
                              
                                if (obj_dt1.Rows.Count != 0)
                                {
                                    for (int j = 0; j <= obj_dt1.Rows.Count - 1; j++)
                                    {
                                        lst_container.Items.Add(obj_dt1.Rows[j][0].ToString() + "Container , " + obj_dt1.Rows[j][1].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Dt = FEBLWoJobj.GetBLDetWOJob(txt_bl.Text.ToUpper(), int_bid, int.Parse(Session["LoginDivisionId"].ToString()));
                    if (Dt.Rows.Count > 0)
                    {
                        txt_job.Text = "0";
                        txt_shipper.Text = obj_dt.Rows[0][3].ToString();
                        txt_consignee.Text = obj_dt.Rows[0][6].ToString();
                        txt_notify.Text = obj_dt.Rows[0][8].ToString();
                        txt_cnf.Text = obj_dt.Rows[0][16].ToString();
                        txtEta.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                        txt_vessel.Text = obj_dt.Rows[0][33].ToString();
                    }
                }
            }
            else
            {
                if (Chk_Mbl.Checked == true)
                {
                    lst_volume.Items.Clear();
                    obj_dt = obj_da_Invoice.GetMblInvoiceHead(txt_bl.Text.ToUpper().ToUpper(), Type, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_job.Text = obj_dt.Rows[0][0].ToString();
                        txt_mlo.Text = obj_dt.Rows[0][6].ToString();
                        txt_agent.Text = obj_dt.Rows[0][5].ToString();
                        txt_destination.Text = obj_dt.Rows[0][4].ToString();
                        vessel = obj_dt.Rows[0][3].ToString();
                        voyage = obj_dt.Rows[0][2].ToString();

                        eta = Convert.ToDateTime(obj_dt.Rows[0][1].ToString());
                        txtEta.Text = Convert.ToString(eta.ToShortDateString());
                        txt_vessel.Text = txt_job.Text + "/" + vessel + "/" + voyage;
                        agent = obj_dt.Rows[0][7].ToString();

                        jobtype = obj_dt.Rows[0][8].ToString();

                        obj_dt = obj_da_Invoice.GetFIMblNContainers(txt_job.Text, int_bid);

                        lst_container.Items.Clear();
                        if (obj_dt.Rows.Count != 0)
                        {
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                lst_container.Items.Add(obj_dt.Rows[i][0].ToString() + "Container ," + obj_dt.Rows[i][1].ToString());
                            }
                        }
                        obj_dt = obj_da_Invoice.GetMblContainerDtls(int.Parse(txt_job.Text), txt_job.Text, Type, int_bid);
                      
                        if (obj_dt.Rows.Count != 0)
                        {
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                lst_volume.Items.Add(obj_dt.Rows[i][0].ToString());
                            }
                        }
                    }
                }
                else
                {
                    DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                    lst_volume.Items.Clear();
                    obj_dt = obj_da_Invoice.GetHblInvoiceHead(txt_bl.Text.ToUpper(), Type, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_job.Text = obj_dt.Rows[0][0].ToString();
                        txt_shipper.Text = obj_dt.Rows[0][4].ToString();
                        txt_consignee.Text = obj_dt.Rows[0][6].ToString();
                        txt_notify.Text = obj_dt.Rows[0][8].ToString();
                        //   txt_cnf.Text = obj_dt.Rows[0][16].ToString();
                        txt_mlo.Text = obj_dt.Rows[0][9].ToString();
                        txt_agent.Text = obj_dt.Rows[0][8].ToString();
                        txt_destination.Text = obj_dt.Rows[0][7].ToString();
                        vessel = obj_dt.Rows[0][3].ToString();
                        voyage = obj_dt.Rows[0][2].ToString();

                        eta = Convert.ToDateTime(obj_dt.Rows[0][1].ToString());
                        txtEta.Text = Convert.ToString(eta.ToShortDateString());
                        txt_vessel.Text = txt_job.Text + "/" + vessel + "/" + voyage;
                        agent = obj_dt.Rows[0][10].ToString();

                        jobtype = obj_dt.Rows[0][11].ToString();


                        hid_cosigneeid.Value = obj_dt.Rows[0]["consigneeid"].ToString();
                        hid_mloid.Value = obj_dt.Rows[0]["airlineid"].ToString();
                    }
                    else
                    {

                    }
                    obj_dt = obj_da_Invoice.GetHBLContainerDtls(txt_bl.Text.ToUpper().ToUpper(), Type, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            lst_volume.Items.Add(obj_dt.Rows[i][0].ToString());
                        }
                        string str_volume = obj_da_Invoice.GetVolume(txt_bl.Text.ToUpper().ToUpper(), Type, int_bid).ToString();
                        lst_volume.Items.Add(str_volume + " cbm");
                        string str_weight = obj_da_Invoice.GetWeight(txt_bl.Text.ToUpper().ToUpper(), Type, int_bid).ToString();
                        lst_volume.Items.Add(str_weight + " Kgs");
                        lst_container.Items.Clear();
                        obj_dt1 = obj_da_Invoice.GetHblNoOfContainers(int.Parse(txt_job.Text), txt_bl.Text, Type, int_bid);                     
                     
                        if (obj_dt1.Rows.Count != 0)
                        {
                            for (int j = 0; j < obj_dt1.Rows.Count; j++)
                            {
                                lst_container.Items.Add(obj_dt1.Rows[j][0].ToString() + "Container , " + obj_dt1.Rows[j][1].ToString());
                            }
                        }
                    }
                }
            }
        }
        private void Fn_AEGetdetail(string Type)
        {
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo obj_da_FEJob = new DataAccess.ForwardingExports.JobInfo();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();

            if (Chk_Mbl.Checked == true)
            {
                obj_dt = obj_da_Invoice.GetMblInvoiceHead(txt_bl.Text.ToUpper().ToUpper(), Type, int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_job.Text = obj_dt.Rows[0][0].ToString();
                    txt_mlo.Text = obj_dt.Rows[0][5].ToString();
                    txt_agent.Text = obj_dt.Rows[0][4].ToString();
                    txt_destination.Text = obj_dt.Rows[0][3].ToString();
                    txt_vessel.Text = txt_job.Text + "/" + obj_dt.Rows[0][2].ToString() + "/" + txtEta.Text;
                    agent = obj_dt.Rows[0][6].ToString();

                    eta = Convert.ToDateTime(obj_dt.Rows[0][1].ToString());
                    txtEta.Text = Convert.ToString(eta.ToShortDateString());
                    gross = obj_dt.Rows[0][7].ToString();
                    chwt = obj_dt.Rows[0][8].ToString();
                }
                else
                {

                }
            }
            else
            {
                lst_volume.Items.Clear();
                obj_dt = obj_da_Invoice.GetHblInvoiceHead(txt_bl.Text.ToUpper().ToUpper(), Type, int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_job.Text = obj_dt.Rows[0][0].ToString();
                    txt_mlo.Text = obj_dt.Rows[0][9].ToString();
                    txt_agent.Text = obj_dt.Rows[0][8].ToString();
                    txt_destination.Text = obj_dt.Rows[0][7].ToString();
                    txt_shipper.Text = obj_dt.Rows[0][3].ToString();
                    txt_consignee.Text = obj_dt.Rows[0][4].ToString();
                    txt_notify.Text = obj_dt.Rows[0][5].ToString();
                    txt_cnf.Text = obj_dt.Rows[0][6].ToString();
                    eta = Convert.ToDateTime(obj_dt.Rows[0][1].ToString());
                    txtEta.Text = Convert.ToString(eta.ToShortDateString());
                    txt_vessel.Text = txt_job.Text + "/" + obj_dt.Rows[0][2].ToString() + "/" + txtEta.Text;
                    agent = obj_dt.Rows[0][10].ToString();
                    gross = obj_dt.Rows[0][11].ToString();
                    chwt = obj_dt.Rows[0][12].ToString();
                    lst_volume.Items.Add("Gross Wt :" + gross + "Kgs");
                    lst_volume.Items.Add("Charge Wt :" + chwt + "Kgs");

                    hid_mloid.Value = obj_dt.Rows[0]["airlineid"].ToString();
                    hid_cosigneeid.Value = obj_dt.Rows[0]["consigneeid"].ToString();
                }
                else
                {

                }
            }
        }
        private void Fn_CHGetdetail(string Type)
        {
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();

            obj_dt = obj_da_Invoice.GetHblInvoiceHead(txt_bl.Text.ToUpper().ToUpper(), Type, int_bid);
            if (obj_dt.Rows.Count > 0)
            {
                txt_job.Text = obj_dt.Rows[0][0].ToString();
                txt_mlo.Text = obj_dt.Rows[0][8].ToString();
                txt_agent.Text = obj_dt.Rows[0][9].ToString();
                txt_destination.Text = obj_dt.Rows[0][6].ToString();
                txt_shipper.Text = obj_dt.Rows[0][3].ToString();
                txt_consignee.Text = obj_dt.Rows[0][4].ToString();
                txt_notify.Text = obj_dt.Rows[0][5].ToString();
                eta = Convert.ToDateTime(obj_dt.Rows[0][1].ToString());
                txtEta.Text = Convert.ToString(eta.ToShortDateString());
                txt_vessel.Text = txt_job.Text + "/" + obj_dt.Rows[0][2].ToString() + "/" + txtEta.Text;
                agent = obj_dt.Rows[0][9].ToString();
                jobtype = obj_dt.Rows[0][10].ToString();
                jobtype = "0";

            }
            else
            {

            }
        }
        private void Fn_Getdetail()
        {
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.ProfomaInvoice obj_da_ProInvoice = new DataAccess.Accounts.ProfomaInvoice();
            obj_dt = obj_da_ProInvoice.GetProInvoiceDetails(int.Parse(txt_Refno.Text), int.Parse(txt_year.Text), int.Parse(Session["LoginBranchid"].ToString()), lbl_Header.Text);
            double Total = 0;
            if (obj_dt.Rows.Count > 0)
            {
                Grd_Charge.DataSource = obj_dt;
                Grd_Charge.DataBind();
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    Total = Total + double.Parse(obj_dt.Rows[i]["amount"].ToString());
                }
            }
            txt_total.Text = string.Format("{0:#,##0.00}", Total);
        }

        protected void Grd_Charge_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_charge = Grd_Charge.SelectedRow.Cells[0].Text.TrimEnd().ToString();
            if (str_charge.Length > 5)
            {
                if (str_charge.Substring(0, 5) == "ST on" || str_charge.Substring(0, 5) == "EduCe" || str_charge.Substring(0, 5) == "Highe")
                {
                    ScriptManager.RegisterStartupScript(Grd_Charge, typeof(GridView), "Debit", "alertify.alert('Cannot Modified');", true);
                    return;
                }
            }
            txt_bl_TextChanged(sender, e);
            txt_charge.Text = Grd_Charge.SelectedRow.Cells[0].Text;
            txt_curr.Text = Grd_Charge.SelectedRow.Cells[1].Text;
            txt_rate.Text = Grd_Charge.SelectedRow.Cells[2].Text.Replace(",", ""); 
            txt_exrate.Text = Grd_Charge.SelectedRow.Cells[3].Text;
            ddl_base.SelectedValue = Grd_Charge.SelectedRow.Cells[4].Text;

            hid_base.Value = Grd_Charge.SelectedRow.Cells[4].Text;
            //txt_amount.Text = Grd_Charge.SelectedRow.Cells[5].Text;
            txt_amount.Text = Grd_Charge.SelectedRow.Cells[5].Text;
            txt_amount.Text = String.Format("{0:F2}", txt_amount.Text);
            hid_chargeid.Value = Grd_Charge.SelectedDataKey[0].ToString();
            btn_add.Text = "Upd";
            if (rbt_agent.Checked == true)
            {
                txt_exrate.ReadOnly = true;
            }
            else
            {
                txt_exrate.ReadOnly = false;
            }
            Fn_TxtDisable();
            txt_charge.Enabled = false;
            txt_curr.Focus();
            UserRights();
        }

        private void Fn_TxtDisable()
        {
            txt_bl.Enabled = false;
            txt_to.Enabled = false;
            txt_job.Enabled = false;
            txt_vessel.Enabled = false;
            txt_destination.Enabled = false;
            txt_shipper.Enabled = false;
            txt_consignee.Enabled = false;
            txt_agent.Enabled = false;
            txt_mlo.Enabled = false;
            txt_notify.Enabled = false;
            txt_cnf.Enabled = false;
            txt_year.Enabled = false;
            //txt_charge.Enabled = false;
            txt_remark.Enabled = false;
            ddl_bill.Enabled = false;
            lst_container.Enabled = false;
            lst_volume.Enabled = false;
        }

        private void Fn_TxtEnable()
        {
            txt_bl.Enabled = true;
            txt_to.Enabled = true;
            txt_job.Enabled = true;
            txt_vessel.Enabled = true;
            txt_destination.Enabled = true;
            txt_shipper.Enabled = true;
            txt_consignee.Enabled = true;
            txt_agent.Enabled = true;
            txt_mlo.Enabled = true;
            txt_notify.Enabled = true;
            txt_cnf.Enabled = true;
            txt_year.Enabled = true;
            txt_charge.Enabled = true;
            txt_remark.Enabled = true;
            btn_save.Enabled = true;
            btn_save.ForeColor = System.Drawing.Color.White;
            ddl_bill.Enabled = true;
            lst_container.Enabled = true;
            lst_volume.Enabled = true;
        }

        protected void ddl_module_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fn_LoadBase();
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_LoadBase()
        {
            ddl_base.Items.Clear();
            if (ddl_module.SelectedValue.ToString() == "FE" || ddl_module.SelectedValue.ToString() == "FI")
            {
                // lbl_bl.Text = "BL #";
                //  lbl_job.Text = "Job Details";
                // lbl_agent.Text = "Agent";
                //  lbl_mlo.Text = "MLO";
                //   lbl_cnf.Text = "CNF";
              //  rbt_agent.Enabled = true;
                ddl_base.Items.Add("");
                ddl_base.Items.Add("BL");
                ddl_base.Items.Add("CBM");
                ddl_base.Items.Add("MT");

                txt_bl.Attributes.Add("placeholder", "BL #");
                txt_bl.ToolTip = "BL #";
                txt_job.Attributes.Add("placeholder", "Job Details");
                txt_job.ToolTip = "Job Details";
                txt_agent.Attributes.Add("placeholder", "Agent");
                txt_agent.ToolTip = "Agent";
                txt_mlo.Attributes.Add("placeholder", "MLO");
                txt_mlo.ToolTip = "MLO";
                txt_cnf.Attributes.Add("placeholder", "CNF");
                txt_cnf.ToolTip = "CNF";

                if (ddl_module.SelectedValue.ToString() == "FE")
                {
                    ddl_base.Items.Add("SB");
                }
                DataTable obj_dt = new DataTable();
                DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
                obj_dt = obj_da_invoice.BaseFill();
                if (obj_dt.Rows.Count > 0)
                {
                    ddl_base.DataSource = obj_dt;
                    ddl_base.DataTextField = "conttype";
                    ddl_base.DataBind();
                }                
            }
            else if (ddl_module.SelectedValue.ToString() == "AE" || ddl_module.SelectedValue.ToString() == "AI")
            {
                // lbl_bl.Text = "BL #";
                // lbl_job.Text = "Flight#";
                //lbl_cnf.Text = "NotifyParty2";
                // lbl_agent.Text = "Agent";
                // lbl_mlo.Text = "AirLine";
               // rbt_agent.Enabled = true;
                txt_bl.Attributes.Add("placeholder", "BL #");
                txt_bl.ToolTip = "BL #";
                txt_job.Attributes.Add("placeholder", "Flight#");
                txt_job.ToolTip = "Flight#";
                txt_agent.Attributes.Add("placeholder", "AirLine");
                txt_agent.ToolTip = "AirLine";
                txt_mlo.Attributes.Add("placeholder", "Agent");
                txt_mlo.ToolTip = "Agent";
                txt_cnf.Attributes.Add("placeholder", "NotifyParty2");
                txt_cnf.ToolTip = "NotifyParty2";

                ddl_base.Items.Add("");
                ddl_base.Items.Add("HWBL");
                ddl_base.Items.Add("Kgs");                
            }
            else
            {
                // lbl_bl.Text = "Doc #";
                // lbl_job.Text = "Vsl and Voy";
                //lbl_agent.Text = "Principal";
                //lbl_mlo.Text = "Customer";
                // lbl_cnf.Text = "CNF";
                //rbt_agent.Enabled = false;
                //rbt_agent.Checked = false;
                txt_bl.Attributes.Add("placeholder", "Doc #");
                txt_bl.ToolTip = "Doc #";
                txt_job.Attributes.Add("placeholder", "Vsl and Voy");
                txt_job.ToolTip = "Vsl and Voy";
                txt_agent.Attributes.Add("placeholder", "Principal");
                txt_agent.ToolTip = "Principal";
                txt_mlo.Attributes.Add("placeholder", "Customer");
                txt_mlo.ToolTip = "Customer";
                txt_cnf.Attributes.Add("placeholder", "NotifyParty2");
                txt_cnf.ToolTip = "NotifyParty2";

                ddl_base.Items.Add("");
                ddl_base.Items.Add("DOC");
                ddl_base.Items.Add("Kgs");               
            }
        }

        protected void txt_bl_TextChanged(object sender, EventArgs e)
        {
            DataTable dtsupply = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
            DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
            DataTable obj_dt = new DataTable();
            string str_booking = "";
            string str_BL = "";


            if (txt_bl.Text.ToUpper().Trim().Length > 0)
            {
                if (ddl_module.SelectedValue.ToString() == "FE" || ddl_module.SelectedValue.ToString() == "FI")
                {
                    Fn_FEGetdetail(ddl_module.SelectedValue.ToString());
                }
                else if (ddl_module.SelectedValue.ToString() == "AE" || ddl_module.SelectedValue.ToString() == "AI")
                {
                    Fn_AEGetdetail(ddl_module.SelectedValue.ToString());
                }
                else
                {
                    Fn_CHGetdetail(ddl_module.SelectedValue.ToString());
                }
                if (txt_credit.Text.Trim().Length == 0)
                {
                    txt_credit.Text = "7";
                }

                if (Session["StrTranType"] != null)
                {

                    obj_dt = obj_da_BL.ShowBLDetails(txt_bl.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        str_BL = obj_dt.Rows[0]["splitbl"].ToString();

                    }
                    str_booking = obj_da_FIBL.GetBookinkNo(txt_bl.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (str_booking == "0" && Session["StrTranType"].ToString() == "FI")
                    {
                        str_booking = obj_da_FIBL.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }

                    if (str_booking != "0")
                    {
                        dtsupply = obj_da_FEBL.GetBookingDt(str_booking, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtsupply.Rows.Count > 0)
                        {
                            if(txt_Refno.Text!="")
                            {
                                hid_SupplyTo.Value = dtsupply.Rows[0]["customerid"].ToString();
                            }

                          
                            if (hid_SupplyTo.Value == "")
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

                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                if (txt_bl.Text.Trim() != "")
                {
                    if (txt_job.Text.Trim() == "")
                    {
                        txt_bl.Text = "";
                        ScriptManager.RegisterStartupScript(txt_bl, typeof(TextBox), "Debit", "alertify.alert('Invalid BL #');", true);
                        txt_bl.Focus();
                        Fn_Clear1();
                        Fn_ChargeClear();
                        return;
                    }
                }
                else
                {
                    Fn_Clear1();
                    Fn_ChargeClear();
                    ddl_bill.Focus();
                }                
            }
            UserRights();            
        }

        private void Fn_Clear1()
        {
            txt_bl.Text = "";
            txt_job.Text = "";
            txt_to.Text = "";
            txt_vessel.Text = "";
            txt_destination.Text = "";
            txt_consignee.Text = "";
            txt_agent.Text = "";
            txt_shipper.Text = "";
            txt_mlo.Text = "";
            txt_notify.Text = "";
            txt_cnf.Text = "";
            txt_remark.Text = "";
            ddl_bill.SelectedIndex = 0;
            ddl_module.SelectedIndex = 0;
            lst_container.Items.Clear();
            lst_volume.Items.Clear();
            Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Charge.DataBind();
            Chk_Mbl.Checked = false;
            rbt_agent.Checked = false;
            rbt_customer.Checked = false;
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_amount.Text = "";
            ddl_base.SelectedIndex = 0;
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            txt_Refno.Focus();
            txt_credit.Text = "";
        }

        private void Fn_Clear()
        {
            UserRights();
            txt_Refno.Text = "";
            txt_bl.Text = "";
            txt_job.Text = "";
            txt_to.Text = "";
            txt_vessel.Text = "";
            txt_destination.Text = "";
            txt_consignee.Text = "";
            txt_agent.Text = "";
            txt_shipper.Text = "";
            txt_mlo.Text = "";
            txt_notify.Text = "";
            txt_cnf.Text = "";
            txt_remark.Text = "";
            ddl_bill.SelectedIndex = 0;
            ddl_module.SelectedIndex = 0;
            lst_container.Items.Clear();
            lst_volume.Items.Clear();
            DataAccess.LogDetails obj_Log = new DataAccess.LogDetails();
            txt_date.Text = Utility.fn_ConvertDate(obj_Log.GetDate().ToShortDateString());
            Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Charge.DataBind();
            Chk_Mbl.Checked = false;
            rbt_agent.Checked = false;
            rbt_customer.Checked = false;
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_amount.Text = "";
            ddl_base.SelectedIndex = 0;
            //btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            txt_Refno.Focus();
            txt_credit.Text = "";
            txt_total.Text = "";
            txtaddress.Text = "";
            txtsupplyto.Text = "";
            txtsupplytoAddress.Text = "";

        }
        private void Fn_ChargeClear()
        {
            txt_charge.Text = "";
            txt_curr.Text = "";
            txt_rate.Text = "";
            txt_exrate.Text = "";
            txt_exrate.Enabled = false;
            txt_amount.Text = "";
            ddl_base.SelectedIndex = 0;
            btn_add.Text = "Add";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
               // rbt_agent.Enabled = true;
                Fn_Clear();
                Fn_TxtEnable();
                Fn_ChargeClear();
                txt_Refno.Focus();
            }
            else
            {
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

        protected void btn_view_Click(object sender, EventArgs e)
        {
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DateTime get_date, GST_date;
            get_date = Convert.ToDateTime(Utility.fn_ConvertDate( txt_date.Text));
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            string Str_trantype = ddl_module.SelectedValue.ToString(), Str_Container = "",header,bltype,agent;
            if (Str_trantype == "FE" || Str_trantype == "FI")
            {
                if (lst_volume.Items.Count > 0)
                {
                    Str_Container = lst_volume.Items[0].Text;
                    for (int i = 1; i <= lst_volume.Items.Count - 3; i++)
                    {
                        Str_Container = Str_Container + " / " + lst_volume.Items[i].Text;
                    }

                }
            }
            if(Chk_Mbl.Checked==true)
            {
                bltype = "M";
            }else
            {
                bltype = "H";
            }
            if(rbt_agent.Checked==true)
            {
                agent = "P";
            }else
            {
                agent = "";
            }
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_CustType = "";
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

            if (txt_Refno.Text!="")
            {
                Str_CustType = obj_da_Customer.GetCustomerType(int.Parse(hid_customerid.Value.ToString()));
                if (lbl_Header.Text == "Profoma Debit Note")
                {
                    header = "DN";
                    if (Str_trantype == "FE")
                    {
                        if (Chk_Mbl.Checked == true)
                        {
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "FEMProDNAgent.rpt";
                               // Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                                Str_sp = "container=" + Str_Container+ "~Lcurr="+Session["Basecurr"] .ToString();
                            }
                            else
                            {
                                Str_RptName = "FEMProDN.rpt";
                                Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString();
                            }
                            Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                            if (get_date >= GST_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&trantype=" + Str_trantype + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                            }else
                            {
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                            Session["str_sfs"] = Str_sf;
                            Session["str_sp"] = Str_sp;
                        }
                        else
                        {
                            if (Str_CustType == "P")
                           {
                               Str_RptName = "FEProDNAgent.rpt";
                               Str_sp = "container=" + Str_Container + "~Lcurr=" + Session["Basecurr"].ToString();
                           }
                           else

                           {
                               Str_RptName = "FEProDN.rpt";
                               Str_sp = "container=" + Str_Container + "~Lcurr=" + Session["Basecurr"].ToString();
                           }
                            
                           
                        }
                        Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&trantype=" + Str_trantype + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else if (Str_trantype == "FI")
                    {
                        if (Chk_Mbl.Checked == true)
                        {
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "FIMProDNAgent.rpt";
                               // Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                                Str_sp = "container=" + Str_Container+ "~Lcurr="+Session["Basecurr"].ToString();
                            }
                            else
                            {
                                Str_RptName = "FIMProDN.rpt";
                                //Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                                Str_sp = "container=" + Str_Container + "~Lcurr=" + Session["Basecurr"].ToString();
                            }
                            Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                            if (get_date >= GST_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&trantype=" + Str_trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                            Session["str_sfs"] = Str_sf;
                            Session["str_sp"] = Str_sp;
                        }
                        else
                        {
                           // Str_RptName = "FIProDNAgent.rpt";
                            //Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";

                            if (Str_CustType == "P")
                            {
                                Str_RptName = "FIProDNAgent.rpt";
                                Str_sp = "container=" + Str_Container + "~Lcurr=" + Session["Basecurr"].ToString();
                                Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&trantype=" + Str_trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                                Session["str_sfs"] = Str_sf;
                                Session["str_sp"] = Str_sp;

                            }
                            else
                            {
                                Str_RptName = "FIProDN.rpt";
                                Str_sp = "container=" + Str_Container;
                                Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                                Session["str_sfs"] = Str_sf;
                                Session["str_sp"] = Str_sp;
                            }
                        }
                       
                    }
                    else if (Str_trantype == "AE")
                    {
                        if (Chk_Mbl.Checked == true)
                        {
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "AEMProDNAgent.rpt";                             
                            }
                            else
                            {
                                Str_RptName = "AEMProDN.rpt";
                               // Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                            }
                          //  Str_sp = "container=" + Str_Container + "~Lcurr=" + Session["Basecurr"].ToString() + "";
                            Str_sp = "Lcurr=" + Session["Basecurr"].ToString();
                            Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                            if (get_date >= GST_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                            }else
                            {
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                            Session["str_sfs"] = Str_sf;
                            Session["str_sp"] = Str_sp;

                        }
                        else
                        {
                            //Str_RptName = "AEProDNAgent.rpt";
                            //Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";

                            if (Str_CustType == "P")
                            {
                                Str_RptName = "AEProDNAgent.rpt";
                                Str_sp = "";
                                Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                                Session["str_sfs"] = Str_sf;
                                Session["str_sp"] = Str_sp;
                            }
                            else
                            {
                                Str_RptName = "AEProDN.rpt";
                                Str_sp = "";
                                Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                                if (get_date >= GST_date)
                                {
                                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&trantype=" + Str_trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                                Session["str_sfs"] = Str_sf;
                                Session["str_sp"] = Str_sp;
                            }
                        }                      
                     
                    }
                    else
                    {
                        if (Chk_Mbl.Checked == true)
                        {
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "AIMProDNAgent.rpt";
                              //  Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                                Str_sp = "Lcurr=" + Session["Basecurr"].ToString();
                             
                            }
                            else
                            {
                                Str_RptName = "AIMProDN.rpt";
                                //Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                                Str_sp = "Lcurr=" + Session["Basecurr"].ToString();
                            }
                            Str_sf = "{DNHead.refno}=" + txt_Refno.Text + " and {DNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNHead.vouyear}=" + txt_year.Text + " and {DNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {DNDetails.vouyear}=" + txt_year.Text;
                            if (get_date >= GST_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                            Session["str_sfs"] = Str_sf;
                            Session["str_sp"] = Str_sp;
                        }
                        else
                        {
                            //Str_RptName = "AIProDNAgent.rpt";
                            //Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "AIProDNAgent.rpt";    
                            }
                            else
                            {
                                 Str_RptName = "AIProDN.rpt"; 
                            }
                            Str_sp = "Lcurr=" + Session["Basecurr"].ToString() ;
                            Str_sf = "{DNHead.refno}=" + txt_Refno.Text;
                            if (get_date >= GST_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                            Session["str_sfs"] = Str_sf;
                            Session["str_sp"] = Str_sp;
                        }
                        
                    }
                }
                else if (lbl_Header.Text == "Profoma Credit Note")
                {
                    header = "CN";
                    if (Str_trantype == "FE")
                    {
                        if (Chk_Mbl.Checked == true)
                        {
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "FEMProCNAgent.rpt";
                                Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                              //  Str_sp = "container=" + Str_Container;
                            }
                            else
                            {
                                Str_RptName = "FEMProCN.rpt";
                                Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                            }
                        }
                        else
                        {
                            Str_RptName = "FEProCNAgent.rpt";
                           // Str_sp = "container=" + Str_Container;
                            Str_sp = "container=" + Str_Container + "~Lcurr=" + Session["Basecurr"].ToString();
                        }
                        Str_sf = "{CNHead.refno}=" + txt_Refno.Text + " and {CNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {CNHead.vouyear}=" + txt_year.Text + " and {CNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {CNDetails.vouyear}=" + txt_year.Text;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else if (Str_trantype == "FI")
                    {
                        if (Chk_Mbl.Checked == true)
                        {
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "FIMProCNAgent.rpt";
                               // Str_sp = "container=" + Str_Container;
                                Str_sp = "container=" + Str_Container + "~Lcurr=" + Session["Basecurr"].ToString()+"";
                            }
                            else
                            {
                                Str_RptName = "FIMProCN.rpt";
                                Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString()+"";
                            }
                        }
                        else
                        {
                            Str_RptName = "FIProCNAgent.rpt";
                            Str_sp = "container=" + Str_Container;
                        }
                        Str_sf = "{CNHead.refno}=" + txt_Refno.Text + " and {CNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {CNHead.vouyear}=" + txt_year.Text + " and {CNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {CNDetails.vouyear}=" + txt_year.Text;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else if (Str_trantype == "AE")
                    {
                        if (Chk_Mbl.Checked == true)
                        {
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "AEMProCNAgent.rpt";
                               // Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString();

                                Str_sp =  "Lcurr=" + Session["Basecurr"].ToString();
                            }
                            else
                            {
                                Str_RptName = "AEMProCN.rpt";
                                Str_sp = "container=" + Str_Container + "~Lcurr="+Session["Basecurr"] .ToString();
                            }
                        }
                        else
                        {
                            Str_RptName = "AEProCNAgent.rpt";
                            Str_sp = "Lcurr="+Session["Basecurr"] .ToString();
                            //Str_sp = "";
                        }
                        Str_sf = "{CNHead.refno}=" + txt_Refno.Text + " and {CNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {CNHead.vouyear}=" + txt_year.Text + " and {CNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {CNDetails.vouyear}=" + txt_year.Text;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        if (Chk_Mbl.Checked == true)
                        {
                            if (Str_CustType == "P")
                            {
                                Str_RptName = "AIMProCNAgent.rpt";
                                Str_sp = "Lcurr="+Session["Basecurr"] .ToString()+"";
                            }
                            else
                            {
                                Str_RptName = "AIMProCN.rpt";
                                Str_sp = "Lcurr="+Session["Basecurr"] .ToString()+"";
                            }
                        }
                        else
                        {
                            Str_RptName = "AIProCNAgent.rpt";
                            Str_sp = "Lcurr="+Session["Basecurr"] .ToString()+"";
                        }
                        Str_sf = "{CNHead.refno}=" + txt_Refno.Text + " and {CNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {CNHead.vouyear}=" + txt_year.Text + " and {CNDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {CNDetails.vouyear}=" + txt_year.Text;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_year.Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + header + "&trantype=" + Str_trantype + "&Profoma=" + "Profoma" + "&customertype=" + agent + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                }
            }
            else
            {
                if (lbl_Header.Text == "Profoma Debit Note")
                {
                    Str_RptName = "Pro OtherCN Register.rpt";
                    Str_sp = "Title=DEBIT NOTE REGISTER";
                    Str_sf = "{ACProDNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {ACProDNHead.vouyear}=" + txt_year.Text;


                }
                else
                {
                    Str_RptName = "Pro OtherCN Register.rpt";
                    Str_sp = "Title=CREDIT NOTE REGISTER";
                    Str_sf = "{ACProCNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {ACProCNHead.vouyear}=" + txt_year.Text;
                }
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Profoma Debit Note", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }

            if (lbl_Header.Text == "Profoma Debit Note")

            {
                obj_da_Log.InsLogDetail(int_Empid, 1047, 3, int_bid,  Session["StrTranType"].ToString()+txt_Refno.Text + " V");
            }
            else
            {
                obj_da_Log.InsLogDetail(int_Empid, 1048, 3, int_bid, Session["StrTranType"].ToString()+txt_Refno.Text + " V");
            }
            UserRights();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int Refno;
           // txt_to_TextChanged(sender, e);
          

            if (lbl_Header.Text == "Profoma Credit Note")
            {
                //if (txt_vendor.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Vendor Ref # is Empty');", true);
                //    return;
                //}

                if (txt_vendor.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the  VendorRefno');", true);
                    txt_vendor.Focus();
                    blrr = true;
                    return;
                }
            }
            if (rbt_customer.Checked == true)
            {
                if (lbl_Header.Text == "Profoma Debit Note")
                {

                    if (txtsupplyto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
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

            }


            if (hid_SupplyTo.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('SupplyTo Customer cannot be blank');", true);

                txtsupplyto.Focus();
                blrr = true;
                return;
            }
            if(blrr==true)
            {
                blrr = false;
                return;
            }
            DataAccess.ForwardingExports.AmendBL obj_da_Amend = new DataAccess.ForwardingExports.AmendBL();
            DataTable obj_dt = new DataTable();
            if (txt_bl.Text.ToUpper().Trim().Length > 0)
            {
                if (Chk_Mbl.Checked == true)
                {
                    obj_dt = obj_da_Amend.GetMBLno(ddl_module.SelectedValue.ToString(), txt_bl.Text.ToUpper().ToUpper(), int_bid, int_divisionid);
                    if (obj_dt.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Invalid MBL #');", true);
                        txt_bl.Focus();
                        return;
                    }
                }
                else
                {
                    obj_dt = obj_da_Amend.GetBLno(ddl_module.SelectedValue.ToString(), txt_bl.Text.ToUpper().ToUpper(), int_bid, int_divisionid);
                    if (obj_dt.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Invalid BL #');", true);
                        txt_bl.Focus();
                        return;
                    }
                }
            }
            if (txt_credit.Text.Trim().Length == 0)
            {
                txt_credit.Text = "0";
            }
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Accounts.ProfomaInvoice obj_da_Proinvoice = new DataAccess.Accounts.ProfomaInvoice();
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (hid_customerid.Value == "0")
            {
                txt_to.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Enter the Customer');", true);
                return;
            }

            if (btn_save.ToolTip == "Save")
            {

                
                DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
                DataTable dtacc = new DataTable();
                dtacc = INVOICEobj.SelEmpDtls4Acc(int_Empid, Convert.ToInt32(txt_job.Text), int_bid, ddl_module.SelectedValue.ToString(), "");
                if (dtacc.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtacc.Rows[0]["closedjob"]) == 1)
                    {
                        if (Convert.ToInt32(dtacc.Rows[0]["deptid"]) == 2)
                        {
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Profoma Debit Note", "alertify.alert('Job # " + txt_job.Text + " has closed." + "Accountant only can raise Pro DN/CN');", true);
                            return;
                        }
                    }
                }

                if (lbl_Header.Text == "Profoma Credit Note")
                {
                    if (txt_vendor.Text != "")
                    {

                   
                    
                    Refno = obj_da_Invoice.InsertProInvoiceHead(DateTime.Parse(Utility.fn_ConvertDate(hid_date.Value.ToString())),
                        ddl_module.SelectedValue.ToString(), Convert.ToInt32(txt_job.Text), Convert.ToInt32(hid_customerid.Value.ToString()), txt_bl.Text.ToUpper().ToUpper(),
                        txt_remark.Text, int_bid, ddl_bill.SelectedItem.Text, int_Empid, lbl_Header.Text, Convert.ToInt32(txt_year.Text),
                        lbl_Header.Text, txt_vendor.Text, Convert.ToInt32(txt_credit.Text), Convert.ToInt32(hid_SupplyTo.Value));

                    txt_Refno.Text = Refno.ToString();
                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    obj_da_Log.InsLogDetail(int_Empid, 1048, 1, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " S");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Details Saved');", true);
                    }
                   
                }
                else
                {
                    Refno = obj_da_Invoice.InsertProInvoiceHead(DateTime.Parse(Utility.fn_ConvertDate(hid_date.Value.ToString())),
                        ddl_module.SelectedValue.ToString(), Convert.ToInt32(txt_job.Text), Convert.ToInt32(hid_customerid.Value.ToString()), txt_bl.Text.ToUpper().ToUpper(),
                        txt_remark.Text, int_bid, ddl_bill.SelectedItem.Text, int_Empid, lbl_Header.Text, Convert.ToInt32(txt_year.Text),
                        lbl_Header.Text, "", 0, Convert.ToInt32(hid_SupplyTo.Value));

                    txt_Refno.Text = Refno.ToString();
                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    obj_da_Log.InsLogDetail(int_Empid, 1047, 1, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " S");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Details Saved');", true);
                }
                txt_charge.Focus();
            }
            else if (btn_save.ToolTip == "Update")
            {
                DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
                DataTable dtacc = new DataTable();
                dtacc = INVOICEobj.SelEmpDtls4Acc(int_Empid, Convert.ToInt32(txt_job.Text), int_bid, ddl_module.SelectedValue.ToString(), "");
                if (dtacc.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtacc.Rows[0]["closedjob"]) == 1)
                    {
                        if (Convert.ToInt32(dtacc.Rows[0]["deptid"]) == 2)
                        {
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Profoma Debit Note", "alertify.alert('Job # " + txt_job.Text + " has closed." + "Accountant only can raise Pro DN/CN');", true);
                            return;
                        }
                    }
                }

                obj_dt = obj_da_Invoice.GetCheckApprovedProfoma(Convert.ToInt32(txt_Refno.Text), int_bid, Convert.ToInt32(txt_year.Text),
                    ddl_module.SelectedValue.ToString(), lbl_Header.Text, "HeadUpdate");

                if (obj_dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Update Denied after Approve');", true);
                    return;
                }
                else
                {

                    if (Convert.ToInt32(hid_customerid.Value) != 0)
                    {
                        obj_da_Proinvoice.UpdateProHead(Convert.ToInt32(txt_Refno.Text), Convert.ToInt32(hid_customerid.Value.ToString()), txt_remark.Text,
                            ddl_bill.SelectedItem.Text, int_Empid, Convert.ToInt32(txt_year.Text), int_bid, ddl_module.SelectedValue.ToString(),
                            lbl_Header.Text, txt_vendor.Text, Convert.ToInt32(txt_credit.Text), Convert.ToInt32(hid_SupplyTo.Value.ToString()));
                        if (hid_SupplyTonew.Value != hid_SupplyTo.Value)
                        {

                            obj_da_Proinvoice.UpdChargesGST4OldVou(Convert.ToInt32(txt_Refno.Text), branchid, Convert.ToInt32(txt_year.Text), lbl_Header.Text);
                            hid_SupplyTonew.Value = hid_SupplyTo.Value;


                        }

                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Details Updated');", true);
                    }
                }
                if (lbl_Header.Text == "Profoma Credit Note")
                {
                    obj_da_Log.InsLogDetail(int_Empid, 1048, 2, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " U");
                }
                else
                {
                    obj_da_Log.InsLogDetail(int_Empid, 1047, 2, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " U");
                }
            }
            Fn_TxtDisable();
            btn_add.Enabled = true;
            UserRights();
            btn_save.Enabled = false;
            txt_charge.Focus();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Accounts.ProfomaInvoice obj_da_Proinvoice = new DataAccess.Accounts.ProfomaInvoice();
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            obj_dt = obj_da_Invoice.GetCheckApprovedProfoma(int.Parse(txt_Refno.Text), int_bid, int.Parse(txt_year.Text), ddl_module.SelectedValue.ToString(), lbl_Header.Text, "Charge");
            if (obj_dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(btn_delete, typeof(Button), "Debit", "alertify.alert('Charges Cannot Delete After Approved');", true);
                return;
            }
            obj_da_Proinvoice.DelProinvDetails(int.Parse(txt_Refno.Text), int.Parse(hid_chargeid.Value.ToString()), ddl_base.SelectedItem.Text, int.Parse(txt_year.Text), int_bid, ddl_module.SelectedValue.ToString(), lbl_Header.Text);
            switch (ddl_module.SelectedValue.ToString())
            {
                case "FE":
                    obj_da_Log.InsLogDetail(int_Empid, 409, 4, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
                case "FI":
                    obj_da_Log.InsLogDetail(int_Empid, 410, 4, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
                case "AE":
                    obj_da_Log.InsLogDetail(int_Empid, 411, 4, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
                case "AI":
                    obj_da_Log.InsLogDetail(int_Empid, 412, 4, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
                case "CH":
                    obj_da_Log.InsLogDetail(int_Empid, 413, 4, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
            }
            ScriptManager.RegisterStartupScript(btn_delete, typeof(Button), "Debit", "alertify.alert('Details Deleted');", true);
            // Grd_Charge.DataSource=

            Fn_Getdetail();
            Fn_ChargeClear();
            UserRights();
            del_val();
        }
        protected void del_val()
        {
            Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Charge.DataBind();
        }
        protected void txt_curr_TextChanged(object sender, EventArgs e)
        {
            if (txt_curr.Text.Trim().Length > 0)
            {
                List<string> List_Result = new List<string>();
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterCharges da_obj_Charge = new DataAccess.Masters.MasterCharges();
                obj_dt = da_obj_Charge.GetLikeCurrency(txt_curr.Text.ToUpper());
                List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "currency");

                if (List_Result.Contains(txt_curr.Text.ToUpper()))
                {
                    if (rbt_agent.Checked == true)
                    {
                        if (txt_curr.Text.ToUpper() == Session["Basecurr"] .ToString())
                        {
                            txt_curr.Text = "";
                            ScriptManager.RegisterStartupScript(txt_curr, typeof(TextBox), "Debit", "alertify.alert('Currency "+Session["Basecurr"] .ToString()+" Not Accepted');", true);
                            txt_curr.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    txt_curr.Text = "";
                    ScriptManager.RegisterStartupScript(txt_curr, typeof(TextBox), "Debit", "alertify.alert('Invalid Currency');", true);
                    txt_curr.Focus();
                    return;
                }
                txt_rate.Focus();
            }
        }

        private double Fn_GetAmount(string Str_base, string Trantype, double Rate, double Exrate)
        {
            double Amount = 0;
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            if (Str_base == "BL" || Str_base == "HWBL" || Str_base == "DOC")
            {
                Amount = Rate * Exrate;
            }
            else if (Str_base == "CBM")
            {
                if (Chk_Mbl.Checked == true)
                {
                    Amount = Rate * Exrate * obj_da_Invoice.GetVolume(txt_bl.Text.ToUpper().ToUpper(), Trantype, int.Parse(Session["LoginBranchid"].ToString()));
                }
                else
                {
                    Amount = Rate * Exrate * obj_da_Invoice.GetSumofVolume(txt_job.Text, Trantype, int.Parse(Session["LoginBranchid"].ToString()));
                }
            }
            else if (Str_base == "MT")
            {
                if (Chk_Mbl.Checked == true)
                {
                    Amount = Rate * Exrate * obj_da_Invoice.GetWeight(txt_bl.Text.ToUpper().ToUpper(), Trantype, int.Parse(Session["LoginBranchid"].ToString()));
                }
                else
                {
                    Amount = Rate * Exrate * obj_da_Invoice.GetSumofWeight(txt_job.Text, Trantype, int.Parse(Session["LoginBranchid"].ToString()));
                }
            }
            else if (Str_base == "Kgs")
            {
                if (Trantype == "AE" || Trantype == "AI")
                {
                    if (Chk_Mbl.Checked == true)
                    {
                        Amount = Rate * Exrate * obj_da_Invoice.GetSumofChargeWght(int.Parse(txt_job.Text), Trantype, int.Parse(Session["LoginBranchid"].ToString()));
                    }
                    else
                    {
                        Amount = Rate * Exrate * obj_da_Invoice.GetChargeWeight(txt_bl.Text.ToUpper().ToUpper(), Trantype, int.Parse(Session["LoginBranchid"].ToString()));
                    }
                }
                else
                {
                    Amount = Rate * Exrate * obj_da_Invoice.GetGrossWeight(txt_bl.Text.ToUpper().ToUpper(), int.Parse(Session["LoginBranchid"].ToString()));
                }
            }
            else if (Str_base == "SB")
            {
                if (Trantype == "FE")
                {
                    if (Chk_Mbl.Checked == true)
                    {
                        if (txt_job.Text != "")
                        {
                            Amount = Rate * Exrate * obj_da_Invoice.GetSBillCount(txt_bl.Text.ToUpper().ToUpper(), int.Parse(txt_job.Text), "MBL", int.Parse(Session["LoginBranchid"].ToString()));
                        }
                    }
                    else
                    {
                        if (txt_job.Text != "")
                        {
                            Amount = Rate * Exrate * obj_da_Invoice.GetSBillCount(txt_bl.Text.ToUpper().ToUpper(), int.Parse(txt_job.Text), "BL", int.Parse(Session["LoginBranchid"].ToString()));
                        }
                    }                    
                }
            }
            else
            {
                if (Trantype == "FE")
                {
                    if (Chk_Mbl.Checked == true)
                    {
                        Amount = Rate * Exrate * obj_da_Invoice.GetBaseCount(txt_bl.Text.ToUpper().ToUpper(), ddl_base.SelectedItem.Text, Trantype, "BL", int.Parse(Session["LoginBranchid"].ToString()));
                    }
                    else
                    {
                        Amount = Rate * Exrate * obj_da_Invoice.GetBaseCount(txt_bl.Text.ToUpper().ToUpper(), ddl_base.SelectedItem.Text, Trantype, "BL", int.Parse(Session["LoginBranchid"].ToString()));
                    }
                }
                else
                {
                    Amount = Rate * Exrate * obj_da_Invoice.GetBaseCount(txt_bl.Text.ToUpper().ToUpper(), ddl_base.SelectedItem.Text, Trantype, "MBL", int.Parse(Session["LoginBranchid"].ToString()));
                }
            }
            return Amount;
        }

        protected void txt_exrate_TextChanged(object sender, EventArgs e)
        {
            if (ddl_module.SelectedValue.ToString() != "0")
            {
                if (txt_exrate.Text.Trim().Length > 0 && ddl_base.SelectedItem.Text !="" )
                {
                    txt_amount.Text = Fn_GetAmount(ddl_base.SelectedItem.Text, ddl_module.SelectedValue.ToString(), double.Parse(txt_rate.Text), double.Parse(txt_exrate.Text)).ToString();
                }
            }
            ddl_base.Focus();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Accounts.ProfomaInvoice obj_da_Proinvoice = new DataAccess.Accounts.ProfomaInvoice();
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            obj_dt = obj_da_Invoice.GetCheckApprovedProfoma(int.Parse(txt_Refno.Text), int_bid, int.Parse(txt_year.Text), ddl_module.SelectedValue.ToString(), lbl_Header.Text, "Charge");

            if (obj_dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "Debit", "alertify.alert('Cannot Add or Update the Charges after Approved');", true);
                return;
            }
            DataTable dtgst = new DataTable();
            dtgst = obj_da_Log.GetGSTDts();
            if (dtgst.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtgst.Rows[0]["GSTDate"].ToString()))
                {
                    hid_gstdate.Value = Convert.ToDateTime(dtgst.Rows[0]["GSTDate"].ToString()).ToString();


                }


            }

            hid_getdate.Value = obj_da_Log.GetDate().ToShortDateString();
            if (txt_amount.Text.Trim().Length > 0 && txt_amount.Text != "0")
            {
                useit();
                string str_charge = txt_charge.Text.TrimEnd().ToString();
                if (str_charge.Length > 5)
                {
                    if (str_charge.Substring(0, 5) == "ST on" || str_charge.Substring(0, 5) == "EduCe" || str_charge.Substring(0, 5) == "Highe")
                    {
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "Debit", "alertify.alert('Cannot Access the Charge');", true);
                        return;
                    }
                }
                if (rbt_customer.Checked == true)
                {
                    if (lbl_Header.Text == "Profoma Debit Note")
                    {
                        if (txtsupplyto.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
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
                }

                if (btn_add.Text == "Add")
                {
                   
                  

                    obj_dt = obj_da_Proinvoice.CheckchrgInvPro(int.Parse(txt_Refno.Text), ddl_base.SelectedItem.Text, int.Parse(hid_chargeid.Value.ToString()), int.Parse(txt_year.Text), int_bid, lbl_Header.Text);
                    if (obj_dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "Debit", "alertify.alert('Already Exist');", true);
                        return;
                    }
                    else
                    {
                        if (txt_charge.Text.Trim().Length != 0 && txt_rate.Text.Trim().Length != 0 && txt_exrate.Text.Trim().Length != 0 && txt_amount.Text.Trim().Length != 0 && ddl_base.SelectedItem.Text.Length != 0)
                        {
                            if (ddl_base.SelectedItem.Text != "Internal")
                            {
                                DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
                                double SalesTax = obj_da_Charge.CheckChargeST(int.Parse(hid_chargeid.Value.ToString()));
                                if (SalesTax == 0)
                                {
                                    //   obj_da_Proinvoice.InsertProInvoiceDetails(int.Parse(txt_Refno.Text), int.Parse(hid_chargeid.Value.ToString()), txt_curr.Text, double.Parse(txt_rate.Text), double.Parse(txt_rate.Text), ddl_base.SelectedItem.Text, double.Parse(txt_amount.Text), int_bid, int.Parse(txt_year.Text), ddl_bill.SelectedItem.Text, ddl_module.SelectedValue.ToString(), lbl_Header.Text, "N");
                                    obj_da_Proinvoice.InsertProInvoiceDetails(Convert.ToInt32(txt_Refno.Text), Convert.ToInt32(hid_chargeid.Value), txt_curr.Text.ToUpper(), Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), branchid, Convert.ToInt32(txt_year.Text), ddl_bill.SelectedItem.Text, strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));
                                    Fn_AddLog();
                                }
                                else
                                {
                                    Confirmdialog.Show();
                                    return;
                                }

                            }
                            else
                            {
                                // obj_da_Proinvoice.InsertProInvoiceDetails(int.Parse(txt_Refno.Text), int.Parse(hid_chargeid.Value.ToString()), txt_curr.Text, double.Parse(txt_rate.Text), double.Parse(txt_exrate.Text), ddl_base.SelectedItem.Text, double.Parse(txt_amount.Text), int_bid, int.Parse(txt_year.Text), ddl_bill.SelectedItem.Text, ddl_module.SelectedValue.ToString(), lbl_Header.Text, "N");
                                obj_da_Proinvoice.InsertProInvoiceDetails(Convert.ToInt32(txt_Refno.Text), Convert.ToInt32(hid_chargeid.Value), txt_curr.Text.ToUpper(), Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), branchid, Convert.ToInt32(txt_year.Text), ddl_bill.SelectedItem.Text, strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));
                                Fn_AddLog();
                            }

                        }
                    }
                }
                else if (btn_add.Text == "Upd")
                {
                    ddl_base_SelectedIndexChanged(sender, e);
                    if (txt_charge.Text.Trim().Length != 0 && txt_rate.Text.Trim().Length != 0 && txt_exrate.Text.Trim().Length != 0 && txt_amount.Text.Trim().Length != 0 && ddl_base.SelectedItem.Text.Length != 0)
                    {
                        //obj_da_Proinvoice.UpdateProInvoiceDetails(int.Parse(txt_Refno.Text), int.Parse(hid_chargeid.Value.ToString()), txt_curr.Text, double.Parse(txt_rate.Text), double.Parse(txt_exrate.Text), ddl_base.SelectedItem.Text, double.Parse(txt_amount.Text), hid_base.Value.ToString(), int.Parse(txt_year.Text), int_bid, ddl_module.SelectedValue.ToString(), lbl_Header.Text);
                        obj_da_Proinvoice.UpdateProInvoiceDetails(Convert.ToInt32(txt_Refno.Text), Convert.ToInt32(hid_chargeid.Value), txt_curr.Text.ToUpper(), Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.Text, Convert.ToDouble(txt_amount.Text), hid_base.Value.ToString(), Convert.ToInt32(txt_year.Text), branchid, strTranType, type, Convert.ToDouble(hdnUnit.Value));
                        Fn_Getdetail();
                        Fn_ChargeClear();
                        txt_charge.Enabled = true;
                        switch (ddl_module.SelectedValue.ToString())
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 388, 2, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                                break;
                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 779, 2, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                                break;
                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 390, 2, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                                break;
                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 391, 2, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                                break;
                            case "CH":
                                obj_da_Log.InsLogDetail(int_Empid, 392, 2, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                                break;
                        }
                        // ScriptManager.RegisterStartupScript(btn_delete, typeof(Button), "Debit", "alertify.alert('Charge Details Updated');", true);
                    }
                }
            }
            UserRights();
        }

        private void Fn_AddLog()
        {
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            Fn_ChargeClear();
            Fn_Getdetail();
            switch (ddl_module.SelectedValue.ToString())
            {
                case "FE":
                    obj_da_Log.InsLogDetail(int_Empid, 388, 1, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
                case "FI":
                    obj_da_Log.InsLogDetail(int_Empid, 779, 1, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
                case "AE":
                    obj_da_Log.InsLogDetail(int_Empid, 390, 1, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
                case "AI":
                    obj_da_Log.InsLogDetail(int_Empid, 391, 1, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
                case "CH":
                    obj_da_Log.InsLogDetail(int_Empid, 392, 1, int_bid, ddl_module.SelectedValue.ToString() + txt_Refno.Text + " / " + hid_chargeid.Value.ToString() + "PInvDDel");
                    break;
            }
            // ScriptManager.RegisterStartupScript(btn_delete, typeof(Button), "Debit", "alertify.alert('Charge Details Saved');", true);
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            useit();
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            if (rbt_customer.Checked == true)
            {
                if (lbl_Header.Text == "Profoma Debit Note")
                {
                    if (txtsupplyto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnYes, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
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
            }
            DataAccess.Accounts.ProfomaInvoice obj_da_Proinvoice = new DataAccess.Accounts.ProfomaInvoice();
            //   obj_da_Proinvoice.InsertProInvoiceDetails(int.Parse(txt_Refno.Text), int.Parse(hid_chargeid.Value.ToString()), txt_curr.Text, double.Parse(txt_rate.Text), double.Parse(txt_exrate.Text), ddl_base.SelectedItem.Text, double.Parse(txt_amount.Text), int_bid, int.Parse(txt_year.Text), ddl_bill.SelectedItem.Text, ddl_module.SelectedValue.ToString(), lbl_Header.Text, "Y");
            obj_da_Proinvoice.InsertProInvoiceDetails(Convert.ToInt32(txt_Refno.Text), Convert.ToInt32(hid_chargeid.Value), txt_curr.Text.ToUpper(), Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), branchid, Convert.ToInt32(txt_year.Text), ddl_bill.SelectedItem.Text, strTranType, type, "Y", Convert.ToDouble(hdnUnit.Value));

            Fn_AddLog();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            useit();
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            DataAccess.Accounts.ProfomaInvoice obj_da_Proinvoice = new DataAccess.Accounts.ProfomaInvoice();
            //   obj_da_Proinvoice.InsertProInvoiceDetails(int.Parse(txt_Refno.Text), int.Parse(hid_chargeid.Value.ToString()), txt_curr.Text, double.Parse(txt_rate.Text), double.Parse(txt_exrate.Text), ddl_base.SelectedItem.Text, double.Parse(txt_amount.Text), int_bid, int.Parse(txt_year.Text), ddl_bill.SelectedItem.Text, ddl_module.SelectedValue.ToString(), lbl_Header.Text, "Y");
            obj_da_Proinvoice.InsertProInvoiceDetails(Convert.ToInt32(txt_Refno.Text), Convert.ToInt32(hid_chargeid.Value), txt_curr.Text.ToUpper(), Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), branchid, Convert.ToInt32(txt_year.Text), ddl_bill.SelectedItem.Text, strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));
            Fn_AddLog();
        }

        protected void txt_rate_TextChanged(object sender, EventArgs e)
        {
            if (txt_exrate.Text.Trim().Length > 0)
            {
                if (txt_exrate.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(txt_exrate, typeof(TextBox), "Debit", "alertify.alert('Ex. Rate Not Available');", true);
                    return;
                }
            }
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();

            if (rbt_agent.Checked == true)
            {
                txt_exrate.ReadOnly = true;
                txt_exrate.Text = obj_da_Invoice.GetOSExRate(txt_curr.Text.ToUpper(), DateTime.Parse(Utility.fn_ConvertDate(hid_date.Value)), hid_type.Value.ToString(), Convert.ToInt32(Session["LoginDivisionId"])).ToString();
            }
            else
            {
                txt_exrate.ReadOnly = false;
                txt_exrate.Text = obj_da_Invoice.GetExRate(txt_curr.Text.ToUpper(), DateTime.Parse(Utility.fn_ConvertDate(hid_date.Value)), hid_type.Value.ToString(), Convert.ToInt32(Session["LoginDivisionId"])).ToString();
            }
            if (txt_exrate.Text !="")
            {
                txt_exrate_TextChanged(sender, e);
            }
            
            //ddl_base_SelectedIndexChanged(sender, e);
            txt_exrate.Focus();
        }

        protected void ddl_base_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txt_Refno.Text == "")
            //{
            //    return;
            //}
            if (ddl_base.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Any Of One of Base...');", true);
                return;
            }


            if (ddl_base.Text != "" && ddl_base.Text != "Base / Unit" && txt_charge.Text != "" && txt_curr.Text != "" && txt_rate.Text != "" && txt_exrate.Text !="")
            {
                string strbase = ddl_base.Text;
                famount = CheckBase(strbase, Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text));
                txt_amount.Text = famount.ToString();
                txt_amount.Text = Convert.ToDecimal(txt_amount.Text).ToString("0.00");
                btn_add.Enabled = true;
                btn_add.Focus();
            }
            UserRights();
        }

        public double CheckBase(string strbase, double rate, double exrate)
        {
            useit();
            if (ddl_base.Text.ToUpper() == "BL".ToUpper() || ddl_base.Text.ToUpper() == "HWBL".ToUpper() || ddl_base.Text.ToUpper() == "DOC".ToUpper())
            {
                amount = rate * exrate;
                hdnUnit.Value = "1";
            }
            //---------------------------------------------------------------

            else if (ddl_base.Text.ToUpper() == "CBM".ToUpper() || ddl_base.Text.ToUpper() == "MT".ToUpper())
            {
                if (ddl_base.Text.ToUpper() == "CBM".ToUpper())
                {
                    if (strTranType == "FE")
                    {
                        if (Chk_Mbl.Checked == false)
                        {
                            if (type == "InvoiceWoJ")
                            {
                                strvolume = INVOICEobj.GetVolume(txt_bl.Text.ToUpper().ToUpper(), "Wo", branchid);
                                amount = rate * exrate * strvolume;
                            }
                            else
                            {
                                strvolume = INVOICEobj.GetVolume(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid);
                                amount = rate * exrate * strvolume;
                                doublevolume = strvolume;
                                hdnUnit.Value = doublevolume.ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "H");
                            }
                        }
                        else
                        {
                            strvolume = INVOICEobj.GetSumofVolume(txt_job.Text, strTranType, branchid);
                            amount = rate * exrate * strvolume;
                            doublevolume = strvolume;
                            hdnUnit.Value = doublevolume.ToString();
                            fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "M");
                        }
                    }

                    //--------------------------------------------------------------------------
                    else
                    {
                        if (Chk_Mbl.Checked == false)
                        {
                            strvolume = INVOICEobj.GetVolume(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid);
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
                            fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "H");
                        }
                        else
                        {
                            strvolume = INVOICEobj.GetSumofVolume(txt_job.Text, strTranType, branchid);
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
                            fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "M");
                        }
                    }
                }
                //--------------------------------------------------------------------------

                else
                {
                    if (ddl_base.Text.ToUpper() == "MT".ToUpper())
                    {
                        if (strTranType == "FE")
                        {
                            if (Chk_Mbl.Checked == false)
                            {
                                if (type == "InvoiceWoJ")
                                {
                                    strntweight = INVOICEobj.GetWeight(txt_bl.Text.ToUpper().ToUpper(), "Wo", branchid);
                                    amount = rate * exrate * (strntweight / 1000);
                                }
                                else
                                {
                                    strntweight = INVOICEobj.GetWeight(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid);
                                    amount = rate * exrate * (strntweight / 1000);
                                    doublevolume = strntweight;
                                    hdnUnit.Value = (strntweight / 1000).ToString();
                                    fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "H");
                                }

                            }
                            else
                            {
                                strntweight = INVOICEobj.GetSumofWeight(txt_job.Text, strTranType, branchid);
                                amount = rate * exrate * (strntweight / 1000);
                                doublevolume = strntweight;
                                hdnUnit.Value = (strntweight / 1000).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "M");
                            }
                        }
                    }
                }
            }
            else if (ddl_base.Text.ToUpper() == "Kgs".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (Chk_Mbl.Checked == true)
                    {
                        strchgweight = INVOICEobj.GetSumofChargeWght(Convert.ToInt32(txt_job.Text), strTranType, branchid);
                        amount = rate * exrate * strchgweight;
                        doublevolume = strchgweight;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "M");
                    }
                    else
                    {
                        strchgweight = INVOICEobj.GetChargeWeight(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid);
                        amount = rate * exrate * strchgweight;
                        doublevolume = strchgweight;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "H");
                    }
                }
                else
                {
                    strgrosswght = INVOICEobj.GetGrossWeight(txt_bl.Text.ToUpper().ToUpper(), branchid);
                    amount = rate * exrate * strgrosswght;
                    hdnUnit.Value = strgrosswght.ToString();
                }
            }
            else if (ddl_base.Text.ToUpper() == "SB".ToUpper())
            {
                if (strTranType == "FE")
                {
                    if (Chk_Mbl.Checked == true)
                    {
                        if (txt_job.Text != "")
                        {
                            sizecount = INVOICEobj.GetSBillCount(txt_bl.Text.ToUpper().ToUpper(), Convert.ToInt32(txt_job.Text), "MBL", branchid);
                            amount = rate * exrate * sizecount;
                            doublevolume = sizecount;
                            hdnUnit.Value = doublevolume.ToString();
                            fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "M");
                        }
                    }
                    else
                    {
                        if (txt_job.Text != "")
                        {
                            sizecount = INVOICEobj.GetSBillCount(txt_bl.Text.ToUpper().ToUpper(), Convert.ToInt32(txt_job.Text), "BL", branchid);
                            amount = rate * exrate * sizecount;
                            doublevolume = sizecount;
                            hdnUnit.Value = doublevolume.ToString();
                            fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper().ToUpper(), strTranType, branchid, "H");
                        }
                    }
                }
            }
            else if (ddl_base.Text.ToUpper() == "Volume".ToUpper())
            {
                strgrosswght = INVOICEobj.GetVolumeQty(txt_bl.Text.ToUpper().ToUpper(), branchid);
                amount = rate * exrate * strgrosswght;
                hdnUnit.Value = strgrosswght.ToString();
            }
            else
            {
                string chargebase;
                chargebase = ddl_base.Text;
                if (Chk_Mbl.Checked == false)
                {
                    if (strTranType == "FE")
                    {
                        sizecount = INVOICEobj.GetBaseCount(txt_bl.Text.ToUpper(), chargebase, strTranType, "BL", branchid);
                        amount = rate * exrate * sizecount;
                        doublevolume = sizecount;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper(), strTranType, branchid, "H");
                    }
                    else
                    {
                        sizecount = INVOICEobj.GetBaseCount(txt_bl.Text.ToUpper(), chargebase, strTranType, "BL", branchid);
                        amount = rate * exrate * sizecount;
                        doublevolume = sizecount;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper(), strTranType, branchid, "H");
                    }
                }
                else
                {
                    sizecount = INVOICEobj.GetBaseCount(txt_job.Text, chargebase, strTranType, "MBL", branchid);
                    amount = rate * exrate * sizecount;
                    doublevolume = sizecount;
                    hdnUnit.Value = doublevolume.ToString();
                    fd = DCAdviseObj.GetFDFromBLNO(txt_bl.Text.ToUpper(), strTranType, branchid, "M");
                }
            }
            return amount;
        }
        public void useit()
        {
            try
            {
                strTranType = ddl_module.SelectedValue;
                divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                //type = Request.QueryString["type"].ToString();
                if (lbl_Header.Text == "Profoma Credit Note - Operations")
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
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txt_charge_TextChanged(object sender, EventArgs e)
        {
            if (hid_chargeid.Value == "0")
            {
                txt_charge.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Invalid Charge Description');", true);
                txt_charge.Focus();
            }
            else
            {
                txt_curr.Focus();
            }
        }

        protected void txt_to_TextChanged(object sender, EventArgs e)
        {
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            DataTable DtSHead = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
            string cust = "", blno = "";
            int custid = 0, int_custid;
            string citysupplyid;
            //hid_customerid.Value = Convert.ToString(da_obj_Customer.GetCustomerid(txt_to.Text.ToString()));
            //if(hid_customerid.Value=="0")
            //{
            //    txt_to.Focus();
            //    return;
            //}
            if (rbt_customer.Checked==true)
            {
                DtSHead = da_obj_Customer.GetexactIndianCustomer(txt_to.Text.ToUpper());
                citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_customerid.Value));
                txtaddress.Text = customerobj.GetCustomerAddress(txt_to.Text.Trim(), "C", citysupplyid);
                if (txt_to.Text != "")
                {
                    int_custid = Convert.ToInt32(hid_customerid.Value);
                    if (int_custid != 0)
                    {
                        DataTable dt_list = new DataTable();
                        dt_list = customerobj.GetIndianCustomergst(int_custid);
                        if (dt_list.Rows.Count > 0)
                        {
                            if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                {
                                    txtaddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                    ScriptManager.RegisterStartupScript(txt_to, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                }
                                else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                {
                                     txtaddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                    ScriptManager.RegisterStartupScript(txt_to, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                }


                                ScriptManager.RegisterStartupScript(txt_to, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            }
                            else
                            {
                                 txtaddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(txt_to, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            return;
                        }
                    }
                    else if (int_custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_to, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Select Correct Customer Name');", true);
                        txt_to.Text = "";
                        txt_to.Focus();
                        return;
                    }

                    if (Chk_Mbl.Checked == true)
                        {
                            if (hid_mloid.Value != "")
                            {
                                hid_SupplyTo.Value = hid_mloid.Value;
                            }

                            txtsupplyto.Text = txt_to.Text;
                            txtsupplyto_TextChanged(sender, e);
                        }
                    
                }
                else
                {

                }

            }
            else if(rbt_agent.Checked==true) 
            {
                DtSHead = da_obj_Customer.GetexactCustomer(txt_to.Text.ToUpper(), "P");
                citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_customerid.Value));
                txtaddress.Text = customerobj.GetCustomerAddress(txt_to.Text.Trim(), "P", citysupplyid);

            }
            else
            {
                DtSHead = da_obj_Customer.GetexactCustomer(txt_to.Text.ToUpper());
                citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_customerid.Value));
                txtaddress.Text = customerobj.GetCustomerAddress(txt_to.Text.Trim(), "T", citysupplyid);
            }

            if (DtSHead.Rows.Count > 0 && hid_customerid.Value != "0")
            {

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Customer');", true);
                txt_to.Text = "";
                txt_to.Focus();
                blrr = true;
                return;

            }
            useit();
            if (lbl_Header.Text == "Invoice" || lbl_Header.Text == "Profoma Debit Note" || lbl_Header.Text == "Profoma Credit Note")
            {
                if (lbl_Header.Text == "Invoice")
                {
                    DtSHead = INVOICEobj.CheckInvCustblno(txt_bl.Text, Convert.ToInt32(hid_customerid.Value), strTranType, "I", branchid, Convert.ToInt16(txt_year.Text), 'N');
                }
                else
                {
                    DtSHead = ProINVobj.CheckProinvCustblno(txt_bl.Text, Convert.ToInt32(hid_customerid.Value), strTranType, branchid, Convert.ToInt16(txt_year.Text), lbl_Header.Text);
                }

                if (DtSHead.Rows.Count != 0)
                {
                    blno = DtSHead.Rows[0][5].ToString();
                    custid = Convert.ToInt32(DtSHead.Rows[0][4].ToString());
                    cust = customerobj.GetCustomername(custid);
                    if (txt_bl.Text == blno && txt_to.Text == cust)
                    {
                        if (lbl_Header.Text == "Invoice")
                        {
                            lbl_msg.Text = "Do U Want Add One More " + lbl_Header.Text;
                            this.Confirmdialog1.Show();
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            lbl_msg.Text = "Do U Want Add One More " + lbl_Header.Text;
                            this.Confirmdialog1.Show();
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            lbl_msg.Text = "Do U Want Add One More " + lbl_Header.Text;
                            this.Confirmdialog1.Show();
                        }
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                    }
                    else
                    {
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                    }
                }
                
            }
            else
            {
                txt_Refno.Text = "";
                txt_remark.Text = "";
            }
            txt_charge.Enabled = true;
            ddl_base.Enabled = true;
        }

        protected void txt_year_TextChanged(object sender, EventArgs e)
        {
            DataTable DtSHead = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
            string vtype = "", city = "", fatransfer = "", blno = "";
            int approvedby = 0, cityid = 0;
            useit();
            if (txt_DN.Text.Trim() != "" && txt_year.Text.Trim() != "")
            {
                if (lbl_Header.Text == "Invoice" || lbl_Header.Text == "Debit Note" || lbl_Header.Text == "Credit Note" || lbl_Header.Text == "InvoiceWoJ")
                {
                    if (lbl_Header.Text == "Invoice" || lbl_Header.Text == "InvoiceWoJ")
                    {
                        vtype = "I";
                        DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt16(txt_DN.Text), strTranType, "Invoice", Convert.ToInt16(txt_year.Text), branchid);
                    }
                    else if (lbl_Header.Text == "Debit Note")
                    {
                        vtype = "V";
                        Dt = INVOICEobj.ShowIPHead(Convert.ToInt16(txt_DN.Text), "AC", "DNHead", Convert.ToInt16(txt_year.Text), branchid);
                        if (Dt.Rows.Count > 0)
                        {
                            strTranType = Dt.Rows[0][2].ToString();
                        }
                        Dt = INVOICEobj.ShowIPHead(Convert.ToInt16(txt_DN.Text), "AC", "DNHead", Convert.ToInt16(txt_year.Text), branchid);
                    }
                    else if (lbl_Header.Text == "Credit Note")
                    {
                        vtype = "E";
                        Dt = INVOICEobj.ShowIPHead(Convert.ToInt16(txt_DN.Text), "AC", "CNHead", Convert.ToInt16(txt_year.Text), branchid);
                        if (Dt.Rows.Count > 0)
                        {
                            strTranType = Dt.Rows[0][2].ToString();
                        }
                        Dt = INVOICEobj.ShowIPHead(Convert.ToInt16(txt_DN.Text), "AC", "CNHead", Convert.ToInt16(txt_year.Text), branchid);
                    }
                    string custtype = "";
                    if (DtSHead.Rows.Count > 0)
                    {
                        txt_job.Text = DtSHead.Rows[0][3].ToString();
                        hid_customerid.Value = DtSHead.Rows[0][4].ToString();
                        if (customerobj.GetCustomerType(Convert.ToInt16(hid_customerid.Value)) == "C")
                        {
                            rbt_customer.Checked = true;
                            rbt_agent.Checked = false;
                        }
                        else
                        {
                            rbt_customer.Checked = false;
                            rbt_agent.Checked = true;
                        }
                        txt_to.Text = customerobj.GetCustomername(Convert.ToInt16(hid_customerid.Value));
                        city = customerobj.GetCustlocation(Convert.ToInt16(hid_customerid.Value));
                        cityid = portobj.GetNPortid(city);
                        txt_bl.Text = DtSHead.Rows[0][5].ToString();
                        approvedby = Convert.ToInt16(DtSHead.Rows[0][7].ToString());
                        txt_remark.Text = DtSHead.Rows[0][10].ToString();
                        fatransfer = DtSHead.Rows[0][13].ToString();
                        ddl_bill.Text = INVOICEobj.GetBillType(char.Parse(DtSHead.Rows[0][12].ToString()));
                        txt_date.Text = DtSHead.Rows[0][1].ToString();
                        if (strTranType == "FE")
                        {
                            ddl_module.SelectedItem.Text = "Ocean Exports";
                        }
                        else if (strTranType == "FI")
                        {
                            ddl_module.SelectedItem.Text = "Ocean Imports";
                        }
                        else if (strTranType == "AE")
                        {
                            ddl_module.SelectedItem.Text = "Air Exports";
                        }
                        else if (strTranType == "AI")
                        {
                            ddl_module.SelectedItem.Text = "Air Imports";
                        }
                        //else if (strTranType == "CH")
                        //{
                        //    ddl_module.SelectedItem.Text = "Custome House Agent";
                        //}
                        if (strTranType == "FE" || strTranType == "FI")
                        {
                            if (txt_bl.Text != "")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt16(txt_job.Text), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txt_bl.Text)
                                    {
                                        Chk_Mbl.Checked = true;
                                    }
                                }
                                Fn_FEGetdetail(strTranType);
                            }
                        }
                        else if (strTranType == "AE" || strTranType == "AI")
                        {
                            if (txt_bl.Text != "")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt16(txt_job.Text), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txt_bl.Text)
                                    {
                                        Chk_Mbl.Checked = true;
                                    }
                                }
                                Fn_AEGetdetail(strTranType);
                            }
                        }
                        else
                        {
                            if (txt_bl.Text != "")
                            {
                                Fn_CHGetdetail(strTranType);
                            }
                        }
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                        Fn_Getdetail();
                        btn_cancel.Enabled = true;
                        //btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Voucher Number');", true);                        
                        //btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        txt_DN.Text = "";
                        btn_cancel.Enabled = true;
                        //btn_cancel.Text = "Back";
                        btn_cancel.ToolTip = "Back";
                        btn_cancel1.Attributes["class"] = "btn ico-back";
                        Fn_Clear();
                        return;
                    }
                }
                else
                {
                    DtSHead = INVOICEobj.ShowIPHead(Convert.ToInt16(txt_DN.Text), strTranType, "PA", Convert.ToInt16(txt_year.Text), branchid);
                    if (DtSHead.Rows.Count > 0)
                    {
                        txt_job.Text = DtSHead.Rows[0][3].ToString();
                        hid_customerid.Value = DtSHead.Rows[0][4].ToString();
                        txt_to.Text = customerobj.GetCustomername(Convert.ToInt16(hid_customerid.Value));
                        city = customerobj.GetCustlocation(Convert.ToInt16(hid_customerid.Value));
                        cityid = portobj.GetNPortid(city);
                        txt_bl.Text = DtSHead.Rows[0][5].ToString();
                        txt_remark.Text = DtSHead.Rows[0]["remarks"].ToString();
                        ddl_bill.Text = INVOICEobj.GetBillType(char.Parse(DtSHead.Rows[0][12].ToString()));
                        if (strTranType == "FE" || strTranType == "FI")
                        {
                            if (txt_bl.Text != "")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt16(txt_job.Text), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txt_bl.Text)
                                    {
                                        Chk_Mbl.Checked = true;
                                    }
                                }
                                Fn_FEGetdetail(strTranType);
                            }
                        }
                        else if (strTranType == "AE" || strTranType == "AI")
                        {
                            if (txt_bl.Text != "")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt16(txt_job.Text), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txt_bl.Text)
                                    {
                                        Chk_Mbl.Checked = true;
                                    }
                                }
                                Fn_AEGetdetail(strTranType);
                            }
                        }
                        else
                        {
                            if (txt_bl.Text != "")
                            {
                                Fn_CHGetdetail(strTranType);
                            }
                        }
                        //btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                        Fn_Getdetail();
                        btn_cancel.Enabled = true;
                        //btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid PA Number');", true);
                        //btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        txt_DN.Text = "";
                        btn_cancel.Enabled = true;
                        //btn_cancel.Text = "Back";
                        btn_cancel.ToolTip = "Back";
                        btn_cancel1.Attributes["class"] = "btn ico-back";
                        Fn_Clear();
                        return;
                    }
                }
                if (fatransfer != "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Cannot Be Amend');", true);
                    btn_save.Enabled = false;
                    btn_save.Visible = false;
                    btn_add.Visible = false;
                }
            }

            txt_charge.Enabled = true;
            ddl_base.Enabled = true;
            txt_total.Text = "0";
            for (int i = 0; i <= Grd_Charge.Rows.Count - 1; i++)
            {
                txt_total.Text = (Grd_Charge.Rows[i].Cells[6].Text) + (txt_total.Text);
            }
            UserRights();
            txt_charge.Focus();
        }

        protected void btnYes1_Click(object sender, EventArgs e)
        {
            txt_remark.Text = "";
            txt_Refno.Text = "";
            btn_save.Visible = true;
            btn_add.Visible = true;
            Grd_Charge.Enabled = true;
            return;
        }

        protected void btnNo2_Click(object sender, EventArgs e)
        {
            DataTable DtSHead = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
            useit();
            if (lbl_Header.Text == "Invoice" || lbl_Header.Text == "Profoma Debit Note" || lbl_Header.Text == "Profoma Credit Note")
            {
                if (lbl_Header.Text == "Invoice")
                {
                    DtSHead = INVOICEobj.CheckInvCustblno(txt_bl.Text, Convert.ToInt32(hid_customerid.Value), strTranType, "I", branchid, Convert.ToInt16(txt_year.Text), 'N');
                }
                else
                {
                    DtSHead = ProINVobj.CheckProinvCustblno(txt_bl.Text, Convert.ToInt32(hid_customerid.Value), strTranType, branchid, Convert.ToInt16(txt_year.Text), lbl_Header.Text);
                }

                if (DtSHead.Rows.Count != 0)
                {
                    txt_Refno.Text = DtSHead.Rows[0][0].ToString();
                    txt_remark.Text = DtSHead.Rows[0][7].ToString();
                    string billtype = DtSHead.Rows[0][9].ToString();
                    txt_date.Text = DtSHead.Rows[0][1].ToString();
                   // ddl_bill.Text = INVOICEobj.GetBillType(Convert.ToChar(billtype));

                    ddl_bill.SelectedValue = INVOICEobj.GetBillType(Convert.ToChar(billtype));
                    string bill = INVOICEobj.GetBillType(Convert.ToChar(billtype));
                    //if (bill == "Cash/Cheque")
                    //{
                    //    ddl_bill.SelectedIndex = 1;
                    //}
                    //else if (bill == "Credit")
                    //{
                    //    ddl_bill.SelectedIndex = 2;
                    //}
                    //else if (bill == "Internal")
                    //{
                    //    ddl_bill.SelectedIndex = 3;
                    //}
                    //else if (bill == "ST/GST Exemption")
                    //{
                    //    ddl_bill.SelectedIndex = 4;
                    //}
                    //else if (bill == "--BILLTYPE--")
                    //{
                    //    ddl_bill.SelectedIndex = 0;
                    //}


                    ddl_bill.Items.Clear();
                    ddl_bill.Items.Add("");
                    ddl_bill.Items.Add("Cash/Cheque");
                    ddl_bill.Items.Add("Credit");
                    ddl_bill.Items.Add("Internal");

                 

                    if (Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                    {

                        if (bill == "Cash/Cheque")
                        {
                            ddl_bill.SelectedIndex = 1;
                        }
                        else if (bill == "Credit")
                        {
                            ddl_bill.SelectedIndex = 2;
                        }

                        else if (bill == "Internal")
                        {
                            ddl_bill.SelectedIndex = 3;
                        }
                        else if (bill == "--BILLTYPE--")
                        {
                            ddl_bill.SelectedIndex = 0;
                        }



                    }
                    else
                    {
                        ddl_bill.Items.Add("ST/GST Exemption");
                        if (bill == "Cash/Cheque")
                        {
                            ddl_bill.SelectedIndex = 1;
                        }
                        else if (bill == "Credit")
                        {
                            ddl_bill.SelectedIndex = 2;
                        }
                        else if (bill == "Internal")
                        {
                            ddl_bill.SelectedIndex = 3;
                        }
                        else if (bill == "ST/GST Exemption")
                        {
                            ddl_bill.SelectedIndex = 4;
                        }
                        else if (bill == "--BILLTYPE--")
                        {
                            ddl_bill.SelectedIndex = 0;
                        }

                    }

                    if (strTranType == "FE")
                    {
                        ddl_module.SelectedItem.Text = "Ocean Exports";
                    }
                    else if (strTranType == "FI")
                    {
                        ddl_module.SelectedItem.Text = "Ocean Imports";
                    }
                    else if (strTranType == "AE")
                    {
                        ddl_module.SelectedItem.Text = "Air Exports";
                    }
                    else if (strTranType == "AI")
                    {
                        ddl_module.SelectedItem.Text = "Air Imports";
                    }
                    //else if (strTranType == "CH")
                    //{
                    //    ddl_module.SelectedItem.Text = "Custome House Agent";
                    //}

                    if (lbl_Header.Text == "Invoice")
                    {
                        Fn_Getdetail();
                    }
                    else if (lbl_Header.Text == "Profoma Debit Note")
                    {
                        Fn_Getdetail();
                    }
                    else if (lbl_Header.Text == "Profoma Credit Note")
                    {
                        Fn_Getdetail();
                    }
                    else
                    {
                        Fn_Getdetail();
                    }
                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                }
            }
        }

        protected void Grd_Charge_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
               
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Charge, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txtsupplyto_TextChanged(object sender, EventArgs e)
        {
            try
            {



                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = Session["StrTranType"].ToString();
                string citysupplyid;
                int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                if (rbt_customer.Checked == true)
                {
                if (txtsupplyto.Text != "")
                {
                    int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                    txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                    DataTable dt_list = new DataTable();


                    if (int_custid != 0)
                    {
                        if (lbl_Header.Text != "Profoma Credit Note")
                        {
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


                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                                }
                                else
                                {
                                    txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(txtsupplyto, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                                return;
                            }

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
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public void ChkCustStateName(int custid, string custname)
        {
            if (Convert.ToDateTime(obj_da_Log.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
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

    }
}