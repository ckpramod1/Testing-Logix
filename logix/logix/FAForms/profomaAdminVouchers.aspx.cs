using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;

namespace logix.FAForm
{
    public partial class profomaAdminVouchers : System.Web.UI.Page
    {
        int Division_Id, Branch_Id;
        string strTranType;
        bool blnerr;
        int intcustid;
        int chargeid;
        int chargename;
        int co;
        double famount;
        string oldbase;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string Ctrl_List2;
        string Msg_List2;
        string Dtype_List2;
        int city;
        bool bolcuststat;
        double Total_value = 0.00;

        DataAccess.Masters.MasterCustomer CustomerObj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCustomer Obj_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCharges obj_charge = new DataAccess.Masters.MasterCharges();
        DataAccess.Accounts.ProAdminDCNNo obj_ProDCN = new DataAccess.Accounts.ProAdminDCNNo();
        DataAccess.Accounts.Invoice Obj_Invoive = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.ProfomaInvoice obj_ProINV = new DataAccess.Accounts.ProfomaInvoice();
        DataTable dtnew1 = new DataTable();
        int divisionid = 0, branchid = 0;
        DataAccess.Masters.MasterBranch obj_branchd = new DataAccess.Masters.MasterBranch();

        DataTable dtnew = new DataTable();
        DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Accounts.ProAdminDCNNo obj_da_ProInvoice = new DataAccess.Accounts.ProAdminDCNNo();
        DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
        DataAccess.Accounts.ProfomaInvoice obj_da_Invoice = new DataAccess.Accounts.ProfomaInvoice();
        DataAccess.Accounts.ProAdminDCNNo obj_da_Proinvoice = new DataAccess.Accounts.ProAdminDCNNo();
        DataAccess.Accounts.Invoice obj_da_Invoice2 = new DataAccess.Accounts.Invoice();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        
        Double currexrate;
        DateTime Dtdatenew;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            // string Ccode = Convert.ToString(Session["Ccode"]);

            string Ccode = Convert.ToString(Session["Ccode"]);


            if (Ccode != "")
            {

                CustomerObj.GetDataBase(Ccode);
                Obj_Customer.GetDataBase(Ccode);
                obj_Log.GetDataBase(Ccode);
                obj_charge.GetDataBase(Ccode);
                obj_ProDCN.GetDataBase(Ccode);
                Obj_Invoive.GetDataBase(Ccode);
                obj_ProINV.GetDataBase(Ccode);
                obj_branchd.GetDataBase(Ccode);
                cus.GetDataBase(Ccode);


                obj_da_Log.GetDataBase(Ccode);
                obj_da_ProInvoice.GetDataBase(Ccode);
                obj_da_Charge.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                obj_da_Proinvoice.GetDataBase(Ccode);
                obj_da_Invoice2.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);


                obj_da_Invoice.GetDataBase(Ccode);
               

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["Loginyear"].ToString() == Session["Vouyear"].ToString())
            {

            }
            else
            {
                btn_save.Visible = false;
            }


            if (Session["LoginDivisionId"] != null)
            {
                divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            }
            if (Session["LoginBranchid"] != null)
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }

            dtnew1 = obj_branchd.GetBranchGST(divisionid, branchid);
            if (dtnew1.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('Please update GST # to proceed with generation of voucher(s)');", true);
                btn_save.Enabled = false;
                btn_save.ForeColor = System.Drawing.Color.Gray;
                // btnsave.ForeColor = System.Drawing.Color.White;

            }
            else
            {
                btn_save.Enabled = true;
                btn_save.ForeColor = System.Drawing.Color.White;
            }


            Ctrl_List = txt_blno.ID + "~" + txt_vouyear.ID + "~" + txt_to.ID + "~" + txt_crdtdays.ID;
            Msg_List = "Ref.#~VouYear~Customer~Credit Days";
            Dtype_List = "int~int~string~int";
            btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "');");

            Ctrl_List2 = txt_chrgdes.ID + "~" + txt_curr.ID + "~" + txt_rate.ID + "~" + txt_exrate.ID + "~" + txt_amount.ID;
            Msg_List2 = "Charge Description~Currency~Rate~ExRate~Amount";
            Dtype_List2 = "string~int~int~int~int";
            btn_add.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List2 + "','" + Msg_List2 + "','" + Dtype_List2 + "');");
            btn_delete.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List2 + "','" + Msg_List2 + "','" + Dtype_List2 + "');");

            Division_Id = Convert.ToInt32(Session["LoginDivisionId"]);
            Branch_Id = Convert.ToInt32(Session["LoginBranchid"]);
            strTranType = Session["StrTranType"].ToString();

            ////if (Request.QueryString.ToString().Contains("FormName"))
            ////{
            ////    lbl_header.Text = Request.QueryString["FormName"].ToString();
            ////}

            //if (lbl_header.Text == "Proforma Admin Sales Invoice")
            //{
            //    lbl_head.InnerText = "Proforma Admin Sales Invoice";
            //    hid_type.Value = "DN";
            //    hid.Value = "R";
            //    txtsupplyto.ToolTip = "Supply To";
            //    //txtsupplyto.Attributes["Placeholder"] = "Supply To";
            //    lblsupplyto.Text = "Supply To";
            //}
            //else
            //{
            //    lbl_head.InnerText = "Proforma Admin Purchase Invoice";
            //    hid_type.Value = "PA";
            //    hid.Value = "C";
            //    txtsupplyto.ToolTip = "Supply From";
            //    //txtsupplyto.Attributes["Placeholder"] = "Supply From";
            //    lblsupplyto.Text = "Supply From";
            //}

           
           

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                radio_customer.Checked = true;
                radio_agent.Enabled = true;
                //if (Session["LoginBranchName"].ToString() == "CORPORATE")
                //{
                //    radio_agent.Enabled = true;
                //}
                //else
                //{
                //    radio_agent.Enabled = false;
                //}


                grd_profomaDN.DataSource = Utility.Fn_GetEmptyDataTable();
                grd_profomaDN.DataBind();

                if (obj_Log.GetDate().Month < 4)
                {
                    txt_vouyear.Text = (obj_Log.GetDate().Year - 1).ToString();
                }
                else
                {
                    txt_vouyear.Text = (obj_Log.GetDate().Year).ToString();
                }

                txt_invoice.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                txt_vouyear.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                txt_crdtdays.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                txt_rate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                txt_exrate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'EX-Rate')");
                txt_date.Text = string.Format("{0:dd/MM/yyyy}", obj_Log.GetDate());
                txt_blno.Focus();
                btn_delete.Attributes["OnClick"] = "return confirm('Do u want to Delete?');";
            }

            hid_vouyear.Value = txt_vouyear.Text;
            strTranType = Session["str_ModuleName"].ToString();
        }

        [WebMethod]
        public static List<string> GetCharge(string prefix, string ChkBox)
        {
            List<string> DCchargename = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges obj_charge = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_charge.GetDataBase(Ccode);
            if (ChkBox == "C")
            {
                obj_dt = obj_charge.GetLikeMasterCharges4ADMDCN(prefix, "A", "C");
                DCchargename = Utility.Fn_DatatableToList_int32(obj_dt, "chargename", "chargeid");
            }
            else if (ChkBox == "P")
            {
                obj_dt = obj_charge.GetLikeMasterCharges4ADMDCN(prefix, "A", "P");
                DCchargename = Utility.Fn_DatatableToList_int32(obj_dt, "chargename", "chargeid");
            }
            return DCchargename;
        }

        [WebMethod]
        public static List<string> GetCurrency(string prefix)
        {
            DataAccess.Masters.MasterCharges obj_charge = new DataAccess.Masters.MasterCharges();
            List<string> DCcurrency = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges obj_currency = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_charge.GetDataBase(Ccode);
            obj_currency.GetDataBase(Ccode);
            obj_dt = obj_currency.GetLikeCurrency(prefix);
            DCcurrency = Utility.Fn_DatatableToList_stringnew(obj_dt, "currency", "currency");
            return DCcurrency;
        }

        [WebMethod]
        public static List<string> GetCustomer_DNCN(string prefix, string ChkType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Customer.GetDataBase(Ccode);
          
            if (ChkType == "C")
            {
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), "C");
                List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            }
            else if (ChkType == "P")
            {
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), "P");
                List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            }
            return List_Result;
        }

        public void CheckData()
        {
            int intcustid = 0;
            if (hid_customerid.Value != "" && hid_customerid.Value != "0")
            {
                intcustid = Convert.ToInt32(hid_customerid.Value);
            }
            if (txt_blno.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Ref. # cannot be blank');", true);
                txt_blno.Focus();
                txt_blno.Text = "";
                blnerr = true;
                return;
            }

            if (txt_to.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Customer cannot be blank');", true);
                txt_to.Focus();
                blnerr = true;
                return;
            }
            else
            {
                if (intcustid == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select Correct Customer Name');", true);
                    txt_to.Focus();
                    txt_to.Text = "";
                    blnerr = true;
                    return;
                }
            }

            if (ddl_bltype.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Bill type cannot be blank');", true);
                ddl_bltype.Focus();
                blnerr = true;
                return;
            }
        }

        public void CheckChargeData()
        {
            if (txt_chrgdes.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Charge Name cannot be blank');", true);
                txt_chrgdes.Focus();
                txt_chrgdes.Text = "";
                blnerr = true;
                return;
            }

            if (txt_curr.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Currency cannot be blank');", true);
                txt_curr.Focus();
                blnerr = true;
                return;
            }

            if (txt_rate.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Rate cannot be blank');", true);
                txt_rate.Focus();
                blnerr = true;
                return;
            }

            if (ddl_base.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Base cannot be blank');", true);
                ddl_base.Focus();
                blnerr = true;
                return;
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //DataAccess.Accounts.ProAdminDCNNo obj_da_ProInvoice = new DataAccess.Accounts.ProAdminDCNNo();
                //DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
                DataTable obj_dt = new DataTable();

                if (txt_invoice.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Enter the Ref no')", true);
                    txt_invoice.Focus();
                    blnerr = true;
                    return;
                }

                if (txt_chrgdes.Text != "" && txt_curr.Text != "" && ddl_base.Text != "" && txt_rate.Text != "" && txt_exrate.Text != "" && txt_amount.Text != "")
                {
                    CheckChargeData();
                    if (blnerr == true)
                    {
                        return;
                    }

                    if (hf_chargeid.Value != "")
                    {
                        chargeid = Convert.ToInt32(hf_chargeid.Value);
                    }

                    if (chargeid == 0)
                    {
                        if (hid_ops.Value.ToString() == "A")
                        {
                            chargeid = obj_da_Charge.GetChargeid(txt_chrgdes.Text);
                        }

                        if (hid_ops.Value.ToString() == "C")
                        {
                            chargeid = Obj_Customer.GetCustomerid(txt_chrgdes.Text, "C", hid_cname.Value);
                        }

                        if (chargeid == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Invalid Charge Name')", true);
                            txt_chrgdes.Text = "";
                            txt_chrgdes.Focus();
                            blnerr = true;
                            return;
                        }
                    }

                    if (hid_type.Value.ToString() == "PA")
                    {
                        obj_dt = obj_da_ProInvoice.CheckApp4proadminvouchersCOM("C", int_bid, Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(txt_vouyear.Text));
                    }
                    else
                    {
                        obj_dt = obj_da_ProInvoice.CheckApp4proadminvouchersCOM("D", int_bid, Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(txt_vouyear.Text));
                    }
                    if (obj_dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Cannot Add or Update the Charges after Approved');", true);
                        blnerr = true;
                        return;
                    }

                    obj_da_ProInvoice.DelProAdminDCNDetailsCOM(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value.ToString()), ddl_base.SelectedItem.Text, int_bid, Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), hid_ops.Value);
                    Fn_Getdetail();
                    Fn_ChargeClear();
                    if (grd_profomaDN.Rows.Count == 0)
                    {
                        Fn_Clear();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select The Charge')", true);
                    blnerr = true;
                    return;
                }

                if (strTranType == "FC")
                {
                    if (hid_type.Value.ToString() == "PA")
                    {
                        obj_da_Log.InsLogDetail(int_Empid, 1181, 4, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/D");
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(int_Empid, 1180, 4, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/D");
                    }
                }
                else
                {
                    if (hid_type.Value.ToString() == "PA")
                    {
                        obj_da_Log.InsLogDetail(int_Empid, 1138, 4, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/D");
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(int_Empid, 1137, 4, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/D");
                    }
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Successfully Deleted');", true);
                //btn_save.Text = "Save";
                txt_invoice.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('" + message + "');", true);
            }
        }

        public void GrdLoad()
        {
            DataTable Dt = new DataTable();
            for (int i = 0; i <= grd_profomaDN.Rows.Count - 1; i++)
            {
                grd_profomaDN.DataSource = new DataTable();
                grd_profomaDN.DataBind();
            }

            Dt = obj_ProDCN.GetProAdminDCNDetails(Convert.ToInt32(txt_invoice.Text.ToString()), hid_type.Value.ToString(), Convert.ToInt32(txt_vouyear.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]));
            grd_profomaDN.DataSource = Dt;
            grd_profomaDN.DataBind();

            for (int i = 0; i <= grd_profomaDN.Rows.Count - 1; i++)
            {
                Total_value = Total_value + Convert.ToDouble(grd_profomaDN.Rows[i].Cells[5].Text);
            }

            txt_total.Text = string.Format("{0:#,##0.00}", Total_value);
        }

        public void chargetxtclear()
        {
            txt_chrgdes.Text = "";
            txt_curr.Text = "";
            txt_rate.Text = "";
            txt_exrate.Text = "";
            ddl_base.SelectedIndex = 0;
            txt_amount.Text = "";
            btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
            txt_chrgdes.Enabled = true;
            ddl_base.Enabled = true;
        }

        public void txtclear()
        {
            ddl_bltype.SelectedItem.Text = "";
            txt_blno.Text = "";
            txt_to.Text = "";
            txt_remarks.Text = "";
            txt_chrgdes.Text = "";
            txt_curr.Text = "";
            txt_rate.Text = "";
            txt_exrate.Text = "";
            txt_amount.Text = "";
            grd_profomaDN.DataSource = new DataTable();
            grd_profomaDN.DataBind();
            txt_blno.Focus();
            btn_save.Visible = true;
            btn_add.Visible = true;
            grd_profomaDN.Enabled = true;
            txt_total.Text = "0.00";
            txt_chrgdes.Enabled = true;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlTypes.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Kindly select the voucher type');", true);

                    return;
                }
                
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //DataAccess.Accounts.ProfomaInvoice obj_da_Invoice = new DataAccess.Accounts.ProfomaInvoice();
                //DataAccess.Accounts.ProAdminDCNNo obj_da_Proinvoice = new DataAccess.Accounts.ProAdminDCNNo();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int chargeid = 0;
                if (txt_exrate.Text != "")
                {
                    if (txt_exrate.Text == "0.00" || txt_exrate.Text == "0.0")
                    {

                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Enter the correct Exrate ,not allowed for exrate 0.00');", true);
                        txt_exrate.Text = "";
                        txt_exrate.Focus();
                        return;
                    }
                }
                if (txt_invoice.Text != "")
                {
                    DataTable dt = new DataTable();
                    CheckChargeData();

                    if (blnerr == true)
                    {
                        return;
                    }

                    DataTable obj_dt = new DataTable();
                    if (hid_type.Value.ToString() == "PA")
                    {
                        obj_dt = obj_da_Proinvoice.CheckApp4proadminvouchersCOM("C", int_bid, Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(txt_vouyear.Text));
                    }
                    else
                    {
                        obj_dt = obj_da_Proinvoice.CheckApp4proadminvouchersCOM("D", int_bid, Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(txt_vouyear.Text));
                    }

                    if (obj_dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Cannot Add or Update the Charges after Approved');", true);
                        blnerr = true;
                        return;
                    }

                    if (txt_chrgdes.Text != "")
                    {
                     
                        //chargeid = Convert.ToInt32(hf_chargeid.Value);
                        if (chargeid == 0)
                        {
                            if (hid_ops.Value == "A")
                            {
                                chargeid = obj_charge.GetChargeid(txt_chrgdes.Text);
                            }

                            if (hid_ops.Value == "C" && radio_customer.Checked == true)
                            {
                                chargeid = Obj_Customer.GetCustomerid(txt_chrgdes.Text, "C", hid_cname.Value.ToString());
                            }

                            if (hid_ops.Value == "C" && radio_agent.Checked == true)
                            {
                                chargeid = Obj_Customer.GetCustomerid(txt_chrgdes.Text, "Agent / Principal / Counter Part", hid_cname.Value.ToString());
                            }

                            if (chargeid == 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "Debit", "alert('Invalid Charge Name');", true);
                                txt_chrgdes.Focus();
                                txt_chrgdes.Text = "";
                                blnerr = true;
                                return;
                            }
                        }

                        if (obj_charge.GetCurrID(txt_curr.Text) == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Invalid Currency Name');", true);
                            txt_curr.Focus();
                            txt_curr.Text = "";
                            blnerr = true;
                            return;
                        }
                    }
                    if (radio_customer.Checked == true)
                    {
                        if (lbl_header.Text == "Proforma Admin Sales Invoice")
                        {
                            if (txtsupplyto.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply To');", true);
                                txtsupplyto.Focus();
                                bolcuststat = false;
                                return;
                            }
                            else
                            {
                                ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                                if (bolcuststat == true)
                                {
                                    txtsupplyto.Focus();
                                    bolcuststat = false;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (txtsupplyto.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From');", true);
                                hid_SupplyTo.Value = hid_customerid.Value;
                                txtsupplyto.Text = txt_to.Text;
                                txtsupplyto_TextChanged(sender, e);
                            }
                        }

                    }
                    else
                    {
                        if (lbl_header.Text == "Proforma Admin Sales Invoice")
                        {
                            if (txtsupplyto.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From');", true);
                                txtsupplyto.Focus();
                                bolcuststat = false;
                                return;
                            }

                        }
                        else
                        {
                            if (txtsupplyto.Text == "")
                            {
                                hid_SupplyTo.Value = hid_customerid.Value;
                                txtsupplyto.Text = txt_to.Text;

                            }
                        }

                    }
                    if (btn_add.ToolTip == "Add")
                    {
                        CheckChargeBase();

                        if (hid_ops.Value == "C")
                        {
                            obj_dt = obj_da_Invoice.CheckchrgInvProDCN(Convert.ToInt32(txt_invoice.Text), ddl_base.SelectedItem.Text, Convert.ToInt32(hf_chargeid.Value.ToString()), Convert.ToInt32(txt_vouyear.Text), int_bid, hid_type.Value, hid_ops.Value);
                        }
                        else
                        {
                            obj_dt = obj_da_Invoice.CheckchrgInvPro(Convert.ToInt32(txt_invoice.Text), ddl_base.SelectedItem.Text, Convert.ToInt32(hf_chargeid.Value.ToString()), Convert.ToInt32(txt_vouyear.Text), int_bid, hid_type.Value);
                        }

                        if (obj_dt.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Already Exist');", true);
                            txt_chrgdes.Focus();
                            blnerr = true;
                            return;
                        }
                        else
                        {
                            if (txt_chrgdes.Text != "" && txt_rate.Text != "" && txt_exrate.Text != "" && txt_curr.Text != "" && ddl_base.SelectedItem.Text != "" && txt_amount.Text != "")
                            {
                                if (hid_type.Value.ToString() != "PA")
                                {
                                    this.Confirmdialog.Show();
                                    return;
                                }
                                else
                                {
                                    if (ddl_bltype.SelectedItem.Text != "Internal")
                                    {
                                        //DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
                                        double SalesTax = obj_da_Charge.CheckChargeST(obj_da_Charge.GetChargeid(txt_chrgdes.Text));
                                        if (SalesTax == 0)
                                        {
                                            if (hid_ops.Value == "A")
                                            {
                                                obj_da_Proinvoice.InsertProAdminDCNDetailsvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value), txt_curr.Text.ToUpper(),
                                                    Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text),
                                                    int_bid, Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), ddl_bltype.SelectedItem.Text, "N", hid_ops.Value);
                                            }
                                            else
                                            {
                                                obj_da_Proinvoice.InsertProAdminDCNDetails4Custvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value), 
                                                    txt_curr.Text.ToUpper(), Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text,
                                                    Convert.ToDouble(txt_amount.Text), int_bid, Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), ddl_bltype.SelectedItem.Text, "N", hid_ops.Value);
                                            }
                                        }
                                        else
                                        {
                                            this.Confirmdialog.Show();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (hid_ops.Value == "A")
                                        {
                                            obj_da_Proinvoice.InsertProAdminDCNDetailsvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value), txt_curr.Text.ToUpper(),
                                                Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), int_bid,
                                                Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), ddl_bltype.SelectedItem.Text, "N", hid_ops.Value);
                                        }
                                        else
                                        {
                                            obj_da_Proinvoice.InsertProAdminDCNDetails4Custvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value), txt_curr.Text.ToUpper(),
                                                Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text),
                                                int_bid, Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), ddl_bltype.SelectedItem.Text, "N", hid_ops.Value);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (txt_chrgdes.Text != "" && txt_rate.Text != "" && txt_exrate.Text != "" && txt_amount.Text != "" && txt_curr.Text != "" && ddl_base.SelectedItem.Text != "")
                        {
                            obj_da_Proinvoice.UpdProAdminDCNDetailsvouchers(Convert.ToInt32(txt_invoice.Text), chargeid, txt_curr.Text.ToUpper(), Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text),
                                ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), int_bid, Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), 
                                ddl_base.SelectedValue, hid_ops.Value);
                        }
                    }

                    if (hid_type.Value.ToString() == "PA")
                    {
                        obj_da_Log.InsLogDetail(int_Empid, 1045, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + " / " + hf_chargeid.Value.ToString());
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(int_Empid, 1046, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + " / " + hf_chargeid.Value.ToString());
                    }

                    Fn_Getdetail();
                    chargetxtclear();
                    txt_chrgdes.Focus();

                    for (int i = 0; i <= grd_profomaDN.Rows.Count - 1; i++)
                    {
                        Total_value = Total_value + Convert.ToDouble(grd_profomaDN.Rows[i].Cells[7].Text);
                    }

                    txt_total.Text = string.Format("{0:#,##0.00}", Total_value);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "Debit", "alert('Save the Voucher Head then add the charges');", true);
                    btn_save.Focus();
                    blnerr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        public void CheckChargeBase()
        {

            DataTable dt_check = new DataTable();

            if (txt_invoice.Text == "")
            {
                return;
            }

            if (txt_chrgdes.Text == "")
            {
                dt_check = obj_ProINV.CheckchrgInvPro(Convert.ToInt32(txt_invoice.Text.ToString()), ddl_base.SelectedItem.Text.ToString(), chargeid, Convert.ToInt32(txt_vouyear.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_type.Value.ToString());
            }

            if (dt_check.Rows.Count > 0)
            {
                chargename = 1;
            }
            else
            {
                chargename = 0;
            }
        }

        protected void ddl_base_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (txt_rate.Text != "" && txt_exrate.Text != "")
            {
                if (ddl_base.SelectedItem.Text == "DOC")
                {
                    string strbase = ddl_base.Text;
                    famount = CheckBase(strbase, Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text));
                    txt_amount.Text = famount.ToString();
                    txt_amount.Text = Convert.ToDouble(txt_amount.Text).ToString("0.00");
                    btn_add.Focus();
                }
                else
                {
                    ddl_base.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Select the Base');", true);
                }
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Back")
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
            else
            {
                lbl_appr.Visible = false;
                lbl_txt.Visible = false;
                Fn_Clear();
                Fn_ChargeClear();

                ddlTypes.SelectedValue = "0";
                if (Session["LoginDivisionId"] != null)
                {
                    divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                }
                if (Session["LoginBranchid"] != null)
                {
                    branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                }
                dtnew1 = obj_branchd.GetBranchGST(divisionid, branchid);
                if (dtnew1.Rows.Count > 0)
                {
                    btn_save.Enabled = false;
                    btn_save.ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    btn_save.Enabled = true;
                    btn_save.ForeColor = System.Drawing.Color.White;
                }
            }
        }


        protected void txt_chrgdes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int chargeid;
                DataTable dtCharge = new DataTable();
                string str_ledgername;

                if (hf_chargeid.Value != "")
                {
                    chargeid = Convert.ToInt32(hf_chargeid.Value);
                }

                string[] str_temp = txt_chrgdes.Text.Split(',');
                if (str_temp.Length > 0)
                {
                    str_ledgername = str_temp[0].ToString();
                }
                else
                {
                    str_ledgername = txt_chrgdes.Text;
                }

                txt_chrgdes.Text = str_ledgername.ToString();

                if (radio_customer.Checked == true)
                {
                    dtCharge = obj_charge.GetLikeMasterCharges4ADMDCN(txt_chrgdes.Text, "A", "C");
                }
                else if (radio_agent.Checked == true)
                {
                    dtCharge = obj_charge.GetLikeMasterCharges4ADMDCN(txt_chrgdes.Text, "A", "P");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Customer or Agent')", true);
                }

                DataView dtview = new DataView(dtCharge);
                dtview.RowFilter = "Convert([chargeid], System.String) like '" + hf_chargeid.Value + "%'";

                dtCharge = dtview.ToTable();
                if (dtCharge.Rows.Count > 0)
                {
                    hid_ops.Value = dtCharge.Rows[0]["opstype"].ToString();
                    hid_cname.Value = dtCharge.Rows[0]["cname"].ToString();
                    txt_chrgdes.Text = dtCharge.Rows[0]["charge"].ToString();
                    hf_chargeid.Value = dtCharge.Rows[0]["chargeid"].ToString();
                    txt_curr.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void txt_rate_TextChanged(object sender, EventArgs e)
        {
            //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            try
            {
                if (txt_rate.Text.Trim().Length > 0)
                {
                    if (txt_rate.Text == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Rate should not be Zero');", true);
                        txt_rate.Text = "";
                        txt_rate.Focus();
                        return;
                    }
                    if (txt_chrgdes.Text.Trim().Length != 0 && txt_curr.Text.Trim().Length != 0)
                    {
                        if (radio_agent.Checked == true)
                        {
                            txt_exrate.Text = obj_da_Invoice2.GetOSExRate(txt_curr.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)), hid.Value.ToString(), Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                        }
                        else
                        {
                            txt_exrate.Text = obj_da_Invoice2.GetExRate(txt_curr.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)), hid.Value.ToString(), Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                        }
                        if (ddl_base.SelectedItem.Text == "DOC")
                        {
                            string strbase = ddl_base.Text;
                            famount = CheckBase(strbase, Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text));
                            txt_amount.Text = famount.ToString();
                            txt_amount.Text = Convert.ToDouble(txt_amount.Text).ToString("0.00");
                            btn_add.Focus();
                        }
                        else
                        {
                            ddl_base.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Select the Base');", true);
                        }
                    }
                    else
                    {
                        blnerr = true;
                        return;
                    }
                }
                else
                {
                    blnerr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('" + message + "');", true);
            }
        }

        protected void txt_blno_TextChanged(object sender, EventArgs e)
        {
            if (txt_blno.Text.Trim() != "")
            {
                if (ddlTypes.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Kindly select the voucher type');", true);
                    txt_blno.Text = "";
                    return;
                }
                
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                btn_save.Enabled = true;
                txt_vndrref.Text = txt_blno.Text;

                if (txt_crdtdays.Text == "")
                {
                    txt_crdtdays.Text = "30";
                }
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }

        public void ChkCustStateName(int custid, string custname)
        {

            if (Convert.ToDateTime(obj_Log.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
            {
                if (custname != "" && custid > 0)
                {
                    DataTable dt_list = new DataTable();
                    dt_list = CustomerObj.GetIndianCustomergstadd(custid);
                    if (dt_list.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                        bolcuststat = true;
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('Kindly Update th Supply To Name " + custname + "');", true);
                    bolcuststat = true;
                    return;
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlTypes.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Kindly select the voucher type');", true);

                    return;
                }
                
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                //DataAccess.Accounts.ProAdminDCNNo obj_da_ProInvoice = new DataAccess.Accounts.ProAdminDCNNo();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                CheckData();

                if (lbl_header.Text == "Proforma Admin Purchase Invoice")
                {
                    if (txtVendorRefnodate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly select the  VendorRef Date');", true);
                        txtVendorRefnodate.Focus();
                        blnerr = true;
                        return;
                    }
                    if (txt_vndrref.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly select the  VendorRef No');", true);
                        txt_vndrref.Focus();
                        blnerr = true;
                        return;
                    }
                    if (txt_crdtdays.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly select the  Credit Days');", true);
                        txt_crdtdays.Focus();
                        blnerr = true;
                        return;
                    }
                }

                if ( lbl_header.Text == "Proforma Admin Sales Invoice")
                {
                    if (txtVendorRefnodate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly select the  VendorRef Date');", true);
                        txtVendorRefnodate.Focus();
                        blnerr = true;
                        return;
                    }
                    if (txt_vndrref.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly select the  VendorRef No');", true);
                        txt_vndrref.Focus();
                        blnerr = true;
                        return;
                    }
                    if (txt_crdtdays.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly select the  Credit Days');", true);
                        txt_crdtdays.Focus();
                        blnerr = true;
                        return;
                    }
                }


                if (blnerr == true)
                {
                    blnerr = false;
                    return;
                }
                if (radio_customer.Checked == true)
                {
                    if (lbl_header.Text == "Proforma Admin Sales Invoice")
                    {
                        if (txtsupplyto.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From ');", true);
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
                            hid_SupplyTo.Value = hid_customerid.Value;
                            txtsupplyto.Text = txt_to.Text;
                            txtsupplyto_TextChanged(sender, e);
                        }
                    }


                }
                else
                {
                    if (lbl_header.Text == "Proforma Admin Sales Invoice")
                    {
                        if (txtsupplyto.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From');", true);
                            txtsupplyto.Focus();
                            bolcuststat = false;
                            return;
                        }

                    }
                    else
                    {
                        if (txtsupplyto.Text == "")
                        {
                            hid_SupplyTo.Value = hid_customerid.Value;
                            txtsupplyto.Text = txt_to.Text;

                        }
                    }

                }

                if (hid_SupplyTo.Value == "0" || hid_SupplyTo.Value == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From');", true);
                    txtsupplyto.Focus();

                    return;
                }
                if (txt_blno.Text.Trim().Length > 0)
                {
                    txt_crdtdays.Text = txt_crdtdays.Text.Trim().Length == 0 ? "0" : txt_crdtdays.Text;
                    if (btn_save.ToolTip == "Save")
                    {
                        if (lbl_header.Text == "Proforma Admin Purchase Invoice")
                        {
                            txt_invoice.Text = obj_da_ProInvoice.InsertProAdminvouHead(DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)), Convert.ToInt32(hid_customerid.Value.ToString()),
                                txt_blno.Text, txt_remarks.Text, int_bid, ddl_bltype.SelectedItem.Text, int_Empid, Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), txt_vndrref.Text, Convert.ToInt32(txt_crdtdays.Text), Convert.ToInt32(hid_SupplyTo.Value)).ToString();
                        }
                        else
                        {
                            txt_invoice.Text = obj_da_ProInvoice.InsertProAdminvouHead(DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)), Convert.ToInt32(hid_customerid.Value.ToString()),
                                txt_blno.Text, txt_remarks.Text, int_bid, ddl_bltype.SelectedItem.Text, int_Empid, Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), txt_vndrref.Text, Convert.ToInt32(txt_crdtdays.Text), Convert.ToInt32(hid_SupplyTo.Value)).ToString();
                        }
                        if (strTranType == "FC")
                        {
                            if (hid_type.Value.ToString() == "PA")
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1181, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/S");
                            }
                            else
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1180, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/S");
                            }
                        }
                        else
                        {
                            if (hid_type.Value.ToString() == "PA")
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1138, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/S");
                            }
                            else
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1137, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/S");
                            }
                        }
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Details Saved');", true);
                        btn_save.Enabled = false;
                        txt_chrgdes.Focus();

                        if (radio_customer.Checked == true)
                        {
                            txt_curr.Text = "INR";
                            txt_exrate.Text = "1";                          
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn btn-update1";
                        }
                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        DataTable obj_dt = new DataTable();
                        obj_dt = obj_da_ProInvoice.CheckApp4proadminvouchersCOM("", int_bid, Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(txt_vouyear.Text));
                        //if (hid_type.Value.ToString() == "PA")
                        //{
                        //    obj_dt = obj_da_ProInvoice.CheckApp4proadminvouchers("C", int_bid, Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(txt_vouyear.Text));
                        //}
                        //else
                        //{
                        //    obj_dt = obj_da_ProInvoice.CheckApp4proadminvouchers("D", int_bid, Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(txt_vouyear.Text));
                        //}
                        if (obj_dt.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Cannot Add or Update the Charges after Approved');", true);
                            blnerr = true;
                            return;
                        }
                        if (lbl_header.Text == "Profoma Admin Purchase Invoice")
                        {
                            obj_da_ProInvoice.UpdProDCNHeadnew(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hid_customerid.Value.ToString()), txt_remarks.Text, int_bid, ddl_bltype.SelectedItem.Text, hid_type.Value.ToString(), Convert.ToInt32(txt_vouyear.Text), txt_blno.Text, txt_vndrref.Text, Convert.ToInt32(txt_crdtdays.Text), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDate(txtVendorRefnodate.Text)));

                        }
                        else
                        {

                            obj_da_ProInvoice.UpdProDCNHeadvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hid_customerid.Value.ToString()), txt_remarks.Text, int_bid, ddl_bltype.SelectedItem.Text,Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), txt_blno.Text, txt_vndrref.Text, Convert.ToInt32(txt_crdtdays.Text), Convert.ToInt32(hid_SupplyTo.Value));
                        }
                        if (strTranType == "FC")
                        {
                            if (hid_type.Value.ToString() == "PA")
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1181, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/U");
                            }
                            else
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1180, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/U");
                            }
                        }
                        else
                        {
                            if (hid_type.Value.ToString() == "PA")
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1138, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/U");
                            }
                            else
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1137, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/U");
                            }
                        }
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alert('Details Updated');", true);
                        btn_save.Enabled = false;
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                        txt_chrgdes.Focus();

                        if (radio_customer.Checked == true)
                        {
                            txt_curr.Text = "INR";
                            txt_exrate.Text = "1";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void btn_uploadpopup_Click(object sender, EventArgs e)
        {
            if (txt_invoice.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_uploadpopup, typeof(Button), "Checklist", "alert('Kindly Enter the Pro Ref # ');", true);
                txt_invoice.Focus();
                return;
            }
            popup_uploaddoc.Show();
            string a = "";
            hf_updoc.Value = "Y";
            a = hf_updoc.Value.ToString();

            iframe_outstd.Attributes["src"] = "../ShipmentDetails/UploadDocument.aspx?&updoc=" + hf_updoc.Value;
            this.popup_uploaddoc.Show();

            Session["txtjobno"] = null;
            Session["hf_txtrefno"] = txt_invoice.Text;
            Session["vouno"] = null;
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Accounts.ProAdminDCNNo obj_da_Proinvoice = new DataAccess.Accounts.ProAdminDCNNo();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());

                if (hid_ops.Value == "A")
                {
                    obj_da_Proinvoice.InsertProAdminDCNDetailsvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value), txt_curr.Text.ToUpper(),
                        Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), int_bid,
                        Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), ddl_bltype.SelectedItem.Text, "N", hid_ops.Value);
                }
                else
                {
                    obj_da_Proinvoice.InsertProAdminDCNDetails4Custvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value), txt_curr.Text.ToUpper(), 
                        Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), int_bid,
                        Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), ddl_bltype.SelectedItem.Text, "N", hid_ops.Value);
                }

                if (hid_type.Value.ToString() == "PA")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1045, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + " / " + hf_chargeid.Value.ToString());
                }
                else
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1046, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + " / " + hf_chargeid.Value.ToString());
                }

                Fn_AddLog(hf_chargeid.Value.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Accounts.ProAdminDCNNo obj_da_Proinvoice = new DataAccess.Accounts.ProAdminDCNNo();
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                if (radio_customer.Checked == true)
                {
                    if (txtsupplyto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From');", true);
                        txtsupplyto.Focus();
                        bolcuststat = false;
                        return;
                    }
                    else
                    {
                        ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                        if (bolcuststat == true)
                        {
                            txtsupplyto.Focus();
                            bolcuststat = false;
                            return;
                        }
                    }
                }
                else
                {
                    if (lbl_header.Text == "Proforma Admin Sales Invoice")
                    {
                        if (txtsupplyto.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From');", true);
                            txtsupplyto.Focus();
                            bolcuststat = false;
                            return;
                        }

                    }
                    else
                    {
                        if (txtsupplyto.Text == "")
                        {
                            hid_SupplyTo.Value = hid_customerid.Value;
                            txtsupplyto.Text = txt_to.Text;

                        }
                    }

                }
                if (hid_ops.Value == "A")
                {
                    obj_da_Proinvoice.InsertProAdminDCNDetailsvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value), txt_curr.Text.ToUpper(),
                        Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), int_bid, Convert.ToInt32(ddlTypes.SelectedValue),
                        Convert.ToInt32(txt_vouyear.Text), ddl_bltype.SelectedItem.Text, "Y", hid_ops.Value);
                }
                else
                {
                    obj_da_Proinvoice.InsertProAdminDCNDetails4Custvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(hf_chargeid.Value), txt_curr.Text.ToUpper(),
                        Convert.ToDouble(txt_rate.Text), Convert.ToDouble(txt_exrate.Text), ddl_base.SelectedItem.Text, Convert.ToDouble(txt_amount.Text), int_bid, Convert.ToInt32(ddlTypes.SelectedValue), 
                        Convert.ToInt32(txt_vouyear.Text), ddl_bltype.SelectedItem.Text, "N", hid_ops.Value);
                }
                Fn_AddLog(hf_chargeid.Value.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('" + message + "');", true);
            }
        }

        protected void txt_invoice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(ddlTypes.SelectedValue=="0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Kindly select the voucher type');", true);
                    
                    return;
                }
                
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //DataAccess.Accounts.ProAdminDCNNo obj_da_ProInvoice = new DataAccess.Accounts.ProAdminDCNNo();
                //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_ProInvoice.ShowProAdminDCNHeadFromDCNNovouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                if (obj_dt.Rows.Count != 0)
                {
                    btn_save.Visible = true;
                    txt_blno.Text = obj_dt.Rows[0]["refno"].ToString();
                    hid_customerid.Value = obj_dt.Rows[0]["customerid"].ToString();
                    txt_to.Text = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_customerid.Value.ToString()));
                    txt_remarks.Text = obj_dt.Rows[0]["remarks"].ToString();
                    ddl_bltype.SelectedValue = obj_da_ProInvoice.GetBillType(char.Parse(obj_dt.Rows[0]["billtype"].ToString()));
                    txt_date.Text = Utility.fn_ConvertDate(obj_dt.Rows[0][1].ToString());

                    if (!string.IsNullOrEmpty(obj_dt.Rows[0]["SupplyTo"].ToString()))
                    {
                        hid_SupplyTo.Value = obj_dt.Rows[0]["SupplyTo"].ToString();
                        txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                    }

                    if (!string.IsNullOrEmpty(obj_dt.Rows[0]["preparedby"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_prepare.Text = obj_dt.Rows[0]["preparedby"].ToString();
                    }

                    if (!string.IsNullOrEmpty(obj_dt.Rows[0]["approvedby"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_appr.Visible = true;
                        lbl_Approve.Text = obj_dt.Rows[0]["approvedby"].ToString();
                    }


                    if (obj_da_Customer.GetCustomerType(Convert.ToInt32(hid_customerid.Value)) == "C")
                    {
                        radio_customer.Checked = true;
                        radio_agent.Checked = false;
                    }
                    else
                    {
                        radio_customer.Checked = false;
                        radio_agent.Checked = true;
                    }
                    if (hid_type.Value.ToString() == "PA")
                    {
                        if (DBNull.Value.Equals(obj_dt.Rows[0]["vendorrefno"]) == false)
                        {
                            txt_vndrref.Text = obj_dt.Rows[0]["vendorrefno"].ToString();
                        }
                        else
                        {
                            txt_vndrref.Text = "";
                        }

                        if (DBNull.Value.Equals(obj_dt.Rows[0]["creditdays"]) == false)
                        {
                            txt_crdtdays.Text = obj_dt.Rows[0]["creditdays"].ToString();
                        }
                        else
                        {
                            txt_crdtdays.Text = "";
                        }

                        if (DBNull.Value.Equals(obj_dt.Rows[0]["VendorRefdate"]) == false)
                        {
                            txtVendorRefnodate.Text = obj_dt.Rows[0]["VendorRefdate"].ToString();
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                    }
                    else
                    {
                        txt_vndrref.Text = "";
                        txt_crdtdays.Text = "";
                        txtVendorRefnodate.Text = "";
                    }

                    Fn_Getdetail();
                    txt_blno_TextChanged(sender, e);
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    hid_transfer.Value = obj_dt.Rows[0]["fatransfer"].ToString();
                    if (hid_transfer.Value.ToString().Trim().Length == 0)
                    {
                        btn_save.Visible = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        btn_save.Visible = false;
                        btn_save.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                else
                {
                    //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                    obj_dt = obj_da_Invoice2.Getrefidvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(txt_vouyear.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddlTypes.SelectedValue));
                    if (obj_dt.Rows.Count != 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Already Transferred');", true);
                        txt_invoice.Text = "";
                        txt_invoice.Focus();
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Invalid Refno');", true);
                        Fn_Clear();
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

        private void Fn_AddLog(string Str_chargeid)
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                Fn_ChargeClear();
                Fn_Getdetail();

                if (hid_type.Value.ToString() == "PA")
                {
                    obj_da_Log.InsLogDetail(int_Empid, 1045, 1, int_bid, hid_type.Value.ToString() + "# - " + Str_chargeid);
                }
                else
                {
                    obj_da_Log.InsLogDetail(int_Empid, 1046, 1, int_bid, hid_type.Value.ToString() + "# - " + Str_chargeid);
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Charge Details Saved');", true);
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('" + message + "');", true);
            }
        }

        private void Fn_Getdetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                //DataAccess.Accounts.ProAdminDCNNo obj_da_ProInvoice = new DataAccess.Accounts.ProAdminDCNNo();
                obj_dt = obj_da_ProInvoice.GetProAdminDCNDetailsvouchers(Convert.ToInt32(txt_invoice.Text), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                double Total = 0;
                DataTable dtempty = new DataTable();
                dtempty.Columns.Add("charge", typeof(string));
                dtempty.Columns.Add("curr", typeof(string));
                dtempty.Columns.Add("rate", typeof(string));
                dtempty.Columns.Add("exrate", typeof(string));
                dtempty.Columns.Add("base", typeof(string));
                dtempty.Columns.Add("amount", typeof(string));
                dtempty.Columns.Add("GST", typeof(string));
                dtempty.Columns.Add("Total Amount", typeof(string));
                dtempty.Columns.Add("opstype", typeof(string));
                dtempty.Columns.Add("chargeid", typeof(int));

                DataRow dr = dtempty.NewRow();

                if (obj_dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = dtempty.NewRow();
                        dtempty.Rows.Add(dr);

                        dr[0] = obj_dt.Rows[i]["charge"].ToString();
                        dr[1] = obj_dt.Rows[i]["curr"].ToString();
                        dr[2] = obj_dt.Rows[i]["rate"].ToString();
                        dr[3] = obj_dt.Rows[i]["exrate"].ToString();
                        dr[4] = obj_dt.Rows[i]["base"].ToString();

                        if (string.IsNullOrEmpty(obj_dt.Rows[i]["withoutgstAmt"].ToString()) != true)
                        {
                            double amt = Convert.ToDouble(obj_dt.Rows[i]["withoutgstAmt"].ToString());
                            dr[5] = amt.ToString("#0.00");
                        }
                        else
                        {
                            dr[5] = "0.00";
                        }


                        if (string.IsNullOrEmpty(obj_dt.Rows[i]["stgst"].ToString()) != true)
                        {
                            double amt = Convert.ToDouble(obj_dt.Rows[i]["stgst"].ToString());
                            dr[6] = amt.ToString("#0.00");
                        }
                        else
                        {
                            dr[6] = "0.00";
                        }

                        if (string.IsNullOrEmpty(obj_dt.Rows[i]["amount"].ToString()) != true)
                        {
                            double amt = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            dr[7] = amt.ToString("#0.00");
                        }
                        else
                        {
                            dr[7] = "0.00";
                        }

                        dr[8] = obj_dt.Rows[i]["opstype"].ToString();
                        dr[9] = obj_dt.Rows[i]["chargeid"].ToString();

                        Total = Total + double.Parse(obj_dt.Rows[i]["amount"].ToString());
                    }
                }

                obj_dt = obj_da_ProInvoice.GetProAdminDCNDetails4Custvouchers(Convert.ToInt32(txt_invoice.Text),Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txt_vouyear.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                if (obj_dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = dtempty.NewRow();
                        dtempty.Rows.Add(dr);

                        dr[0] = obj_dt.Rows[i]["charge"].ToString();
                        dr[1] = obj_dt.Rows[i]["curr"].ToString();
                        dr[2] = obj_dt.Rows[i]["rate"].ToString();
                        dr[3] = obj_dt.Rows[i]["exrate"].ToString();
                        dr[4] = obj_dt.Rows[i]["base"].ToString();

                        if (string.IsNullOrEmpty(obj_dt.Rows[i]["withoutgstAmt"].ToString()) != true)
                        {
                            double amt = Convert.ToDouble(obj_dt.Rows[i]["withoutgstAmt"].ToString());
                            dr[5] = amt.ToString("#0.00");
                        }
                        else
                        {
                            dr[5] = "0.00";
                        }


                        if (string.IsNullOrEmpty(obj_dt.Rows[i]["stgst"].ToString()) != true)
                        {
                            double amt = Convert.ToDouble(obj_dt.Rows[i]["stgst"].ToString());
                            dr[6] = amt.ToString("#0.00");
                        }
                        else
                        {
                            dr[6] = "0.00";
                        }

                        if (string.IsNullOrEmpty(obj_dt.Rows[i]["amount"].ToString()) != true)
                        {
                            double amt = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            dr[7] = amt.ToString("#0.00");
                        }
                        else
                        {
                            dr[7] = "0.00";
                        }

                        dr[8] = obj_dt.Rows[i]["opstype"].ToString();
                        dr[9] = obj_dt.Rows[i]["chargeid"].ToString();

                        Total = Total + double.Parse(obj_dt.Rows[i]["amount"].ToString());
                    }
                }
                txt_total.Text = string.Format("{0:#,##0.00}", Total);
                txt_chrgdes.Focus();
                grd_profomaDN.DataSource = dtempty;
                grd_profomaDN.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        private void Fn_Clear()
        {
            if (Session["Loginyear"].ToString() == Session["Vouyear"].ToString())
            {

            }
            else
            {
                btn_save.Visible = false;
            }
            txtsupplyto.Text = "";
            txt_invoice.Text = "";
            txt_blno.Text = "";
            txt_to.Text = "";
            txt_remarks.Text = "";
            ddl_bltype.SelectedIndex = 0;
            grd_profomaDN.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_profomaDN.DataBind();
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_save.Enabled = true;
            btn_save.ForeColor = System.Drawing.Color.White;
            txt_total.Text = "0.00";
            txt_vndrref.Text = "";
            txt_crdtdays.Text = "";
            txtVendorRefnodate.Text = "";
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            hid_date.Value = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
            txt_date.Text = hid_date.Value.ToString();
            txt_vouyear.Text = Session["Vouyear"].ToString();
            btn_cancel.ToolTip = "Back";
            btn_cancel.Text = "Back"
;            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        private void Fn_ChargeClear()
        {
            txt_chrgdes.Enabled = true;
            txt_chrgdes.Text = "";
            txt_curr.Text = "";
            txt_rate.Text = "";
            txt_exrate.Text = "";
            txt_amount.Text = "";
            ddl_base.SelectedIndex = 0;
            btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"]= "btn ico-add";
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            DateTime get_date, GST_date;
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            get_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_CustType="";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            if (hid_customerid.Value != "")
            {
                Str_CustType = obj_da_Customer.GetCustomerType(int.Parse(hid_customerid.Value.ToString()));
            }
            if (Str_CustType != "P")
            {
                Str_CustType = "";
            }
            if (txt_invoice.Text != "")
            {
                if (Session["StrTranType"].ToString() == "AC")
                {
                    //if (lbl_header.Text == "Profoma Admin Purchase Invoice" && txt_invoice.Text == "")
                    //{
                    //    Str_RptName = "AdmProCreditRegister.rpt";
                    //    Session["str_sp"] = "Title=Admin Pro PA Credit Note Register";
                    //    Session["str_sfs"] = "{AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString();

                    //    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //}
                    //else if (lbl_header.Text == "Profoma Admin Purchase Invoice" && txt_invoice.Text != "")
                    //{
                    //    Str_RptName = "AdmProCredit.rpt";
                    //    Session["str_sp"] = "";
                    //    Session["str_sfs"] = "{AdmCNHead.prorefno}=" + txt_invoice.Text + " and {AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmCNHead.vouyear}=" + txt_vouyear.Text;
                    //    if (Str_CustType == "P")
                    //    {
                    //        if (get_date <= GST_date)
                    //        {
                    //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&customertype=" + "P" + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //        else
                    //        {
                    //            Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (get_date <= GST_date)
                    //        {
                    //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //        else
                    //        {
                    //            Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //    }
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //}
                    //else if (lbl_header.Text == "Proforma Admin Sales Invoice" && txt_invoice.Text == "")
                    //{
                    //    Str_RptName = "AdmProDebitRegister.rpt";
                    //    Session["str_sp"] = "Title=Proforma PA AdminDebit Register";
                    //    Session["str_sfs"] = "{AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString();

                    //    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //}
                    //else if (lbl_header.Text == "Proforma Admin Sales Invoice" && txt_invoice.Text != "")
                    //{
                    //    Str_RptName = "AdmProDebit.rpt";
                    //    Session["str_sp"] = "";
                    //    Session["str_sfs"] = "{AdmDNHead.prorefno}=" + txt_invoice.Text + " and {AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmDNHead.vouyear}=" + txt_vouyear.Text;
                    //    if (Str_CustType == "P")
                    //    {
                    //        if (get_date <= GST_date)
                    //        {
                    //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&customertype=" + "P" + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //        else
                    //        {
                    //            Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (get_date <= GST_date)
                    //        {
                    //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //        else
                    //        {
                    //            Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //    }
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //}


                    if (lbl_header.Text == "Proforma Admin Purchase Invoice" && txt_invoice.Text == "")
                    {
                        Str_RptName = "AdmProCreditRegister.rpt";
                        Session["str_sp"] = "Title=Admin Pro PA Credit Note Register";
                        Session["str_sfs"] = "{AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString();

                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }
                    else if (lbl_header.Text == "Proforma Admin Purchase Invoice" && txt_invoice.Text != "")
                    {
                        Str_RptName = "AdmProCredit.rpt";
                        Session["str_sp"] = "";
                        Session["str_sfs"] = "{AdmCNHead.prorefno}=" + txt_invoice.Text + " and {AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmCNHead.vouyear}=" + txt_vouyear.Text;
                        if (Str_CustType == "P")
                        {
                            if (get_date <= GST_date)
                            {
                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else
                        {
                            if (get_date <= GST_date)
                            {
                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }
                    else if (lbl_header.Text == "Proforma Admin Sales Invoice" && txt_invoice.Text == "")
                    {
                        Str_RptName = "AdmProDebitRegister.rpt";
                        Session["str_sp"] = "Title=Proforma PA AdminDebit Register";
                        Session["str_sfs"] = "{AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString();

                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }
                    else if (lbl_header.Text == "Proforma Admin Sales Invoice" && txt_invoice.Text != "")
                    {
                        Str_RptName = "AdmProDebit.rpt";
                        Session["str_sp"] = "";
                        Session["str_sfs"] = "{AdmDNHead.prorefno}=" + txt_invoice.Text + " and {AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmDNHead.vouyear}=" + txt_vouyear.Text;
                        if (Str_CustType == "P")
                        {
                            if (get_date <= GST_date)
                            {
                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else
                        {
                            if (get_date <= GST_date)
                            {
                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }
                }

                else if (Session["StrTranType"].ToString() == "CO")
                {
                    //    if (lbl_header.Text == "Profoma Admin Purchase Invoice" && txt_invoice.Text == "")
                    //    {
                    //        Str_RptName = "AdmProCreditRegister.rpt";
                    //        Session["str_sp"] = "Title=Admin Pro PA Credit Note Register";
                    //        Session["str_sfs"] = "{AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString();

                    //        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //    }
                    //    else if (lbl_header.Text == "Profoma Admin Purchase Invoice" && txt_invoice.Text != "")
                    //    {
                    //        Str_RptName = "AdmProCredit.rpt";
                    //        Session["str_sp"] = "";
                    //        Session["str_sfs"] = "{AdmCNHead.prorefno}=" + txt_invoice.Text + " and {AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmCNHead.vouyear}=" + txt_vouyear.Text;
                    //        if (get_date <= GST_date)
                    //        {
                    //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //        else
                    //        {
                    //            Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //    }
                    //    else if (lbl_header.Text == "Proforma Admin Sales Invoice" && txt_invoice.Text == "")
                    //    {
                    //        Str_RptName = "AdmProDebitRegister.rpt";
                    //        Session["str_sp"] = "Title=Proforma PA AdminDebit Register";
                    //        Session["str_sfs"] = "{AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString();

                    //        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //    }
                    //    else if (lbl_header.Text == "Proforma Admin Sales Invoice" && txt_invoice.Text != "")
                    //    {
                    //        Str_RptName = "AdmProDebit.rpt";
                    //        Session["str_sp"] = "";
                    //        Session["str_sfs"] = "{AdmDNHead.prorefno}=" + txt_invoice.Text + " and {AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmDNHead.vouyear}=" + txt_vouyear.Text;
                    //        if (get_date <= GST_date)
                    //        {
                    //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //        else
                    //        {
                    //            Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    //        }
                    //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //    }



                    if (lbl_header.Text == "Proforma Admin Purchase Invoice" && txt_invoice.Text == "")
                    {
                        Str_RptName = "AdmProCreditRegister.rpt";
                        Session["str_sp"] = "Title=Admin Pro PA Credit Note Register";
                        Session["str_sfs"] = "{AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString();

                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }
                    else if (lbl_header.Text == "Proforma Admin Purchase Invoice" && txt_invoice.Text != "")
                    {
                        Str_RptName = "AdmProCredit.rpt";
                        Session["str_sp"] = "";
                        Session["str_sfs"] = "{AdmCNHead.prorefno}=" + txt_invoice.Text + " and {AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmCNHead.vouyear}=" + txt_vouyear.Text;
                        if (Str_CustType == "P")
                        {
                            if (get_date <= GST_date)
                            {
                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else
                        {
                            if (get_date <= GST_date)
                            {
                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }
                    else if (lbl_header.Text == "Proforma Admin Sales Invoice" && txt_invoice.Text == "")
                    {
                        Str_RptName = "AdmProDebitRegister.rpt";
                        Session["str_sp"] = "Title=Proforma PA AdminDebit Register";
                        Session["str_sfs"] = "{AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString();

                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }
                    else if (lbl_header.Text == "Proforma Admin Sales Invoice" && txt_invoice.Text != "")
                    {
                        Str_RptName = "AdmProDebit.rpt";
                        Session["str_sp"] = "";
                        Session["str_sfs"] = "{AdmDNHead.prorefno}=" + txt_invoice.Text + " and {AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmDNHead.vouyear}=" + txt_vouyear.Text;
                        if (Str_CustType == "P")
                        {
                            if (get_date <= GST_date)
                            {
                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName  + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else
                        {
                            if (get_date <= GST_date)
                            {
                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            }
                            else
                            {
                                Str_Script = "window.open('../Reportasp/AdminvouchersRPT.aspx?DCN=" + txt_invoice.Text + "&vouyear=" + txt_vouyear.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&Profoma=" + "Profoma" + "&customertype=" + Str_CustType + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }

                }
                
            }
            else
            {
                if (lbl_header.Text == "Proforma Admin Sales Invoice")
                {
                    Str_RptName = "ProDNadminregister.rpt";
                    Session["str_sp"] = "Title=Debit Note - Proforma Admin Register for voucher year";
                    Session["str_sfs"] = "{ACProAdminDNHead.branchid}=" + Session["LoginBranchid"].ToString();

                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                }
                else
                {
                    Str_RptName = "ProCNadminregister.rpt";
                    Session["str_sp"] = "Title=Credit Note - Proforma Admin Register for voucher year";
                    Session["str_sfs"] = "{ACProAdminCNHead.branchid}=" + Session["LoginBranchid"].ToString();

                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                }
            }

            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (Session["str_ModuleName"] == "FC")
            {
                if (hid_type.Value.ToString() == "PA")
                {
                    obj_da_Log.InsLogDetail(int_Empid, 1181, 3, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/V");
                }
                else
                {
                    obj_da_Log.InsLogDetail(int_Empid, 1180, 3, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/V");
                }
            }
            else
            {
                if (hid_type.Value.ToString() == "PA")
                {
                    obj_da_Log.InsLogDetail(int_Empid, 1138, 3, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/V");
                }
                else
                {
                    obj_da_Log.InsLogDetail(int_Empid, 1137, 3, int_bid, hid_type.Value.ToString() + "# - " + txt_invoice.Text + "/V");
                }
            }
        }

        protected void grd_profomaDN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_profomaDN, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txt_curr_TextChanged(object sender, EventArgs e)
        {
            //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();

            if (txt_curr.Text.Trim().Length > 0)
            {
                txt_curr.Text = txt_curr.Text.Trim().ToUpper();
                if (radio_agent.Checked == true)
                {
                    if (txt_curr.Text == "INR")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Currency INR Not Accepted');", true);
                        txt_curr.Text = "";
                        txt_curr.Focus();
                        blnerr = true;
                        return;
                    }
                }

                if (txt_invoice.Text == "")
                {
                    blnerr = true;
                    return;
                }

                if (txt_chrgdes.Text != "" && txt_curr.Text != "")
                {
                    if (radio_agent.Checked == true)
                    {
                        txt_exrate.Text = obj_da_Invoice2.GetOSExRate(txt_curr.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)), hid.Value.ToString(), Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                    }
                    else
                    {
                        txt_exrate.Text = obj_da_Invoice2.GetExRate(txt_curr.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)), hid.Value.ToString(), Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                    }
                }

                if (txt_exrate.Text != "")
                {
                    if (txt_exrate.Text == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Ex.Rate Not Available')", true);
                        txt_rate.Focus();
                        txt_rate.Text = "";
                        txt_exrate.Text = "";
                        blnerr = true;
                        return;
                    }
                }
            }
        }

        protected void txt_exrate_TextChanged(object sender, EventArgs e)
        {

            //DataAccess.UserPermission userobj = new DataAccess.UserPermission();
            Dtdatenew = Convert.ToDateTime(obj_Log.GetDate().ToShortDateString());
            if (txt_exrate.Text == "")
            {
                return;
            }
            if (txt_exrate.Text != "")
            {
                //if (lbl_Header.Text == "Profoma Invoice")
                //{
                /*Dt = userobj.GetBtnPermission(Convert.ToInt32(Session["LoginEmpId"]), branchid, 287);
                if (Dt.Rows.Count > 0)
                {
                    currexrate = INVOICEobj.GetCheckInvExrate(Convert.ToInt32(txtjobno.Value), strTranType, branchid, txt_curr.Text);
                    script = "Less than PA Exrate Not Allowed";
                    if (currexrate == 0)
                    {
                        currexrate = INVOICEobj.GetExRate(txt_curr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), "R");
                        script = "Less than Current Exrate Not Allowed";
                    }

                    if (Convert.ToDouble(txt_exrate.Text) < currexrate)
                    {
                        txt_exrate.Text = INVOICEobj.GetExRate(txt_curr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), "R").ToString();
                        txt_exrate.Focus();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + script + "');", true);

                        return;
                    }

                }
                else
                {*/
                currexrate = Obj_Invoive.GetExRate(txt_curr.Text, Dtdatenew, "R", Convert.ToInt32(Session["LoginDivisionId"]));
                if (Convert.ToDouble(txt_exrate.Text) < currexrate)
                {
                    txt_exrate.Text = Obj_Invoive.GetExRate(txt_curr.Text, Dtdatenew, "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                    txt_exrate.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Less than Current Exrate Not Allowed');", true);
                    return;
                }
                //}
                // }

                if (txt_exrate.Text == "0.00" || txt_exrate.Text == "0.0")
                {                   
                   
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Enter the correct Exrate ,not allowed for exrate 0.00');", true);
                    txt_exrate.Text = "";
                    txt_exrate.Focus();
                    return;
                }
            }

            if (txt_exrate.Text.Trim().Length > 0 && ddl_base.SelectedItem.Text != "")
            {
                txt_amount.Text = Fn_GetAmount(ddl_base.SelectedItem.Text, double.Parse(txt_rate.Text), double.Parse(txt_exrate.Text)).ToString();
            }

            ddl_base.Focus();
        }

        private double Fn_GetAmount(string Str_base, double Rate, double Exrate)
        {
            double Amount = 0;
            if (Str_base == "BL" || Str_base == "HWBL" || Str_base == "DOC")
            {
                Amount = Rate * Exrate;
            }
            return Amount;
        }

        public double CheckBase(string strbase, double rate, double exrate)
        {
            double amount = 0;
            if (ddl_base.Text.ToUpper() == "DOC".ToUpper())
            {
                amount = rate * exrate;
            }
            return amount;
        }

        protected void txt_to_TextChanged(object sender, EventArgs e)
        {
            if (hid_customerid.Value == "")
            {
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                DataTable dtcust = new DataTable();
                if (radio_customer.Checked == true)
                {
                    dtcust = Obj_Customer.GetLikeCustomer(txt_to.Text.ToString(), "C");
                }
                else if (radio_agent.Checked == true)
                {
                    dtcust = Obj_Customer.GetLikeCustomer(txt_to.Text.ToString(), "P");
                }

                if (dtcust.Rows.Count == 1)
                {
                    hid_customerid.Value = dtcust.Rows[0]["CustomerId"].ToString();
                    intcustid = Convert.ToInt32(hid_customerid.Value);
                    string Cust_Name = dtcust.Rows[0]["customername"].ToString();
                    int CityId = Convert.ToInt32(dtcust.Rows[0]["City"].ToString());
                    txt_to.Text = dtcust.Rows[0]["customername"].ToString();


                    dtnew = cus.getcustomerblk(intcustid);
                    if (dtnew.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('This customer " + txt_to.Text + " status is Hold please discuss with Finance team ');", true);
                        txt_to.Text = "";
                        txt_to.Focus();
                        return;
                    }
                    txt_remarks.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Enter the Correct Customer Name')", true);
                    txt_to.Text = "";
                    txt_to.Focus();
                    blnerr = true;
                    return;
                }
            }

            if (hid_customerid.Value == "0")
            {
                txt_to.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Enter the Valid Customer');", true);
                txt_to.Focus();
            }
            else
            {
                txt_remarks.Focus();
            }
        }

        protected void grd_profomaDN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index;
                index = grd_profomaDN.SelectedRow.RowIndex;

                if (hid_transfer.Value.ToString().Trim().Length > 0)
                {
                    return;
                }

                string str_charge = grd_profomaDN.Rows[index].Cells[0].Text;
                if (str_charge.Length > 5)
                {
                    if (str_charge.Substring(0, 5) == "ST on" || str_charge.Substring(0, 5) == "EduCe" || str_charge.Substring(0, 5) == "Highe")
                    {
                        ScriptManager.RegisterStartupScript(grd_profomaDN, typeof(GridView), "Debit", "alert('Cannot Modified');", true);
                        return;
                    }
                }

                txt_chrgdes.Text = HttpUtility.HtmlDecode(grd_profomaDN.SelectedRow.Cells[0].Text);
                txt_curr.Text = grd_profomaDN.SelectedRow.Cells[1].Text;
                txt_rate.Text = grd_profomaDN.SelectedRow.Cells[2].Text;
                txt_exrate.Text = grd_profomaDN.SelectedRow.Cells[3].Text;
                ddl_base.SelectedValue = grd_profomaDN.SelectedRow.Cells[4].Text.ToString();
                hid_base.Value = grd_profomaDN.SelectedRow.Cells[4].Text;
                txt_amount.Text = grd_profomaDN.SelectedRow.Cells[5].Text;
                hid_ops.Value = grd_profomaDN.DataKeys[index].Values[1].ToString();
                hf_chargeid.Value = grd_profomaDN.DataKeys[index].Values[0].ToString();
                btn_add.ToolTip = "Update";
                btn_add1.Attributes["class"] = "btn ico-update";
                txt_chrgdes.Enabled = false;
                txt_curr.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
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

                if (txtsupplyto.Text != "")
                {
                    int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    citysupplyid = CustomerObj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                    DataTable dt_list = new DataTable();

                    if (int_custid != 0)
                    {

                        dtnew = cus.getcustomerblk(intcustid);
                        if (dtnew.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('This customer " + txtsupplyto.Text + " status is Hold please discuss with Finance team ');", true);
                            txtsupplyto.Text = "";
                            txtsupplyto.Focus();
                            return;
                        }

                        if (radio_customer.Checked == true)
                        {
                            if (lbl_header.Text == "Proforma Admin Sales Invoice")
                            {
                                dt_list = CustomerObj.GetIndianCustomergst(int_custid);
                                if (dt_list.Rows.Count > 0)
                                {
                                    if (dt_list.Rows[0]["UnRegistered"].ToString() == "N" &&  (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString())))
                                    {
                                        if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                        {
                                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('Please Update Gstin #  Master Customer);", true);
                                        }
                                        else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                        {
                                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('Please Update Uinno # Master Customer');", true);
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('Please Update Gstin # or Uinno # Master Customer');", true);
                                        }
                                    }
                                    else
                                    {
                                        //txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                                    return;
                                }
                            }
                        }

                    }
                    else if (int_custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txtsupplyto, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('Select Correct Customer Name');", true);
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
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            GridViewlog.Visible = true;
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            lbl_no.InnerText = lbl_header.Text;
            if (lbl_header.Text == "Proforma Admin Sales Invoice")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1137, "Proadmindn", txt_invoice.Text, txt_invoice.Text, Session["StrTranType"].ToString());
            }
            if (lbl_header.Text == "Proforma Admin Purchase Invoice")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1138, "Proadmincn", txt_invoice.Text, txt_invoice.Text, Session["StrTranType"].ToString());
            }


            if (txt_invoice.Text != "")
            {
                JobInput.Text = txt_invoice.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_profomaDN_PreRender(object sender, EventArgs e)
        {
            if (grd_profomaDN.Rows.Count > 0)
            {
                grd_profomaDN.UseAccessibleHeader = true;
                grd_profomaDN.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddltype"] = ddlTypes.SelectedItem.Text;
            Session["ddltypeid"] = ddlTypes.SelectedValue;
            if (ddlTypes.SelectedItem.Text!="")
            {
                lbl_header.Text = ddlTypes.SelectedItem.Text;
            }

            if (lbl_header.Text == "Proforma Admin Sales Invoice")
            {
                lbl_head.InnerText = "Proforma Admin Sales Invoice";
                hid_type.Value = "DN";
                hid.Value = "R";
                txtsupplyto.ToolTip = "Supply To";
                //txtsupplyto.Attributes["Placeholder"] = "Supply To";
                lblsupplyto.Text = "Supply To";
            }
            else
            {
                lbl_head.InnerText = "Proforma Admin Purchase Invoice";
                hid_type.Value = "PA";
                hid.Value = "C";
                txtsupplyto.ToolTip = "Supply From";
                //txtsupplyto.Attributes["Placeholder"] = "Supply From";
                lblsupplyto.Text = "Supply From";
            }

        }

    }
}