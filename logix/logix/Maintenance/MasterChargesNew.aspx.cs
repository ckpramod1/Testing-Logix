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
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class MasterChargesNew : System.Web.UI.Page
    {
        string chargetype;
        DataAccess.FAMaster.MasterSubGroup sobj = new DataAccess.FAMaster.MasterSubGroup();
        DataAccess.FAMaster.MasterLedger ledgerobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
        DataAccess.userlogin obj_login = new DataAccess.userlogin();
        DataAccess.FAMaster.MasterSubGroup subobj = new DataAccess.FAMaster.MasterSubGroup();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dtl1 = new DataTable();
        string str_charge;
        string str_curr;
        double doub_sglamt;
        string str_stpercent;
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";
        string FaDbName = "";
        int ledgerid;
        int Emp_Id;
        string ObtypeUSD;
        double minbaldr = 0;
        double maxbaldr = 0;
        double minbalcr = 0;
        double maxbalcr = 0;
        string acctype;
        string costtype;
        int intcid;
        char reimbursement;
        char new_invoiceno;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "generateLableAutomatically();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                sobj.GetDataBase(Ccode);
                ledgerobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                da_obj_Logobj.GetDataBase(Ccode);
                da_obj_chargesobj.GetDataBase(Ccode);
                obj_login.GetDataBase(Ccode);
                subobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                




            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (IsPostBack != true)
            {


                ddl_cmbChargeType.Items.Add("");
                ddl_cmbChargeType.Items.Add("Admin");
                ddl_cmbChargeType.Items.Add("Operation");
                AdminCharges.Visible = false;
                //int port = Convert.ToInt32(Session["port"]);
                DataTable obj_Dt_port = new DataTable();
                obj_Dt_port = obj_login.portid();
                ddl_Branch.Items.Add("");
                ddl_reimbursement.SelectedIndex = 2;
                ddl_newinvoiceno.SelectedIndex = 2;
                if (obj_Dt_port.Rows.Count>0)
                {
                    for (int i = 0; i <= obj_Dt_port.Rows.Count -1; i++)
                    {
                        string portname = obj_Dt_port.Rows[i]["countryname"].ToString();
                        //kalai Oct17
                        //if (portname == "Singapore")
                        //{
                        //    ddl_Branch.Items.Add("Wiz Bulk");
                        //}
                        //if (portname == "Singapore")
                        //{
                        //    ddl_Branch.Items.Add("Singapore");
                        //}
                        if (portname == "United Arab Emirates")
                        {
                            ddl_Branch.Items.Add("Dubai");
                        }
                        else
                        {
                            ddl_Branch.Items.Add(portname);
                        }
                    }
                }
                //ddl_Branch.Items.Add(portname);
                //string portname = obj_Dt_port.Rows[0]["portname"].ToString();

                //ddl_Branch.Items.Add(portname);
                //ddl_Branch.SelectedIndex = 0;
                //int countryid = Convert.ToInt32(obj_Dt_port.Rows[0]["countryid"]);
                Label5.Visible = false;
                Label7.Visible = false;
                txt_gstp.Visible = false;
                txt_vat.Visible = false;
                Label3.Visible = true;
                txt_saccode.Visible = true;
                // ddl_Branch.SelectedIndex;

                //if (countryid != 1102)
                //{
                //    txt_gstp.Visible = false;
                //}
                //else
                //{
                //    txt_vat.Visible = false;
                //}

                //Ctrl_List = ddl_cmbChargeType.ID + "~" + txt_Charges.ID + "~" + txt_Curr.ID + "~" + txt_Amt.ID;
                //Msg_List = "Type~Charge~Currency~Amount";
                //Dtype_List = "Dropdownlist~sting~string~int";
                Ctrl_List = ddl_cmbChargeType.ID + "~" + txt_Charges.ID ; //+ "~" + txt_gstp.ID;
                Msg_List = "Type~Charge~GstP";
                Dtype_List = "Dropdownlist~sting~int";

                btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");

                //Ctrl_List = ddl_cmbChargeType.ID + "~" + txt_Charges.ID + "~" + txt_saccode.ID; //+ "~" + txt_gstp.ID;
                //Msg_List = "Type~Charge~Saccode~GstP";
                //Dtype_List = "Dropdownlist~sting~string~int";

                //btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");

                txt_Amt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this, event)");
                txt_Percent.Attributes.Add("onkeypress", "return validateFloatKeyPress(this, event)");
                //txt_EduPer.Attributes.Add("onkeypress", "return validateFloatKeyPress(this, event)");
                //txt_HighEduPer.Attributes.Add("onkeypress", "return validateFloatKeyPress(this, event)");
                txtsbcess.Attributes.Add("onkeypress", "return validateFloatKeyPress(this, event)");
                txtkkcess.Attributes.Add("onkeypress", "return validateFloatKeyPress(this, event)");
                //txt_gstp.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                //  Empty_grid();

                fill_grd();

                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_Uiid = Request.QueryString["type"].ToString();
                }
                else
                {
                    str_Uiid = Request.QueryString["uiid"].ToString();
                }
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                  btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                txt_Charges.Focus();
            }
            else if (Page.IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            }

        }
        [WebMethod]
        public static List<string> Getcustomer(string prefix)
        {
            string chargetype = "";

            if (HttpContext.Current.Session["ddl_cmbChargeType.SelectedValue"] == "A")
            {
                chargetype = "A";
            }
            else
            {
                chargetype = "O";
            }

            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_chargesobj.GetDataBase(Ccode);
            obj_dt = da_obj_chargesobj.GetLikeChargesWChargeType(prefix.ToUpper(), Convert.ToString(chargetype));
            customername = Utility.Fn_DatatableToList(obj_dt, "chargename", "chargeid");
            return customername;
        }

        [WebMethod]
        public static List<string> GetCurr(string prefix)
        {
            List<string> currency = new List<string>();
            DataTable obj_dt3 = new DataTable();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_chargeobj.GetDataBase(Ccode);
            obj_dt3 = da_obj_chargeobj.GetLikeCurrency(prefix.ToUpper());
            currency = logix.Utility.Fn_DatatableToList_string(obj_dt3, "currency", "currency");
            return currency;

        }


        /*    [WebMethod]
            public static void GetEmpName(string Prefix)
            {

                DataTable obj_dtEmp = new DataTable();

                if (Prefix.Length > 0)
                {
                    DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
                    DataTable obj_dt = new DataTable();
                    obj_dt = da_obj_chargesobj.GetLikeCharges(Prefix.ToUpper());
                    obj_dtEmp.Columns.Add("chargename");
                    obj_dtEmp.Columns.Add("currency");
                    obj_dtEmp.Columns.Add("amount");
                    obj_dtEmp.Columns.Add("percentage");
                    DataRow dr;

                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["chargename"] = obj_dt.Rows[i][0].ToString();
                        dr["currency"] = obj_dt.Rows[i][1].ToString();
                        dr["amount"] = obj_dt.Rows[i][2].ToString();
                        dr["percentage"] = obj_dt.Rows[i][3].ToString();

                    }
                    HttpContext.Current.Session["Date"] = obj_dtEmp;

                }

            }*/

        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                da_obj_chargesobj.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = da_obj_chargesobj.GetLikeChargesnew(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("chargename");
                obj_dtEmp.Columns.Add("chargetype");
                obj_dtEmp.Columns.Add("SACCode");
                obj_dtEmp.Columns.Add("GSTP");
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["chargename"] = obj_dt.Rows[i][0].ToString();
                    dr["chargetype"] = obj_dt.Rows[i][1].ToString();
                    dr["SACCode"] = obj_dt.Rows[i][2].ToString();
                    dr["GSTP"] = obj_dt.Rows[i][3].ToString();

                }
                HttpContext.Current.Session["Date"] = obj_dtEmp;

            }

        }
        private void Empty_grid()
        {
            DataTable dt_new = new DataTable();
            grd.DataSource = dt_new;
            grd.DataBind();
        }

        public void fill_grd()
        {
            DataTable obj_dtEmp = new DataTable();

            int gst1;
                int vat;
           // DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
            DataTable obj_dt = new DataTable();
            
                obj_dt = da_obj_chargesobj.GetLikeChargesnew("A");
                obj_dtEmp.Columns.Add("chargename");
                obj_dtEmp.Columns.Add("chargetype");
                obj_dtEmp.Columns.Add("SACCode");
                obj_dtEmp.Columns.Add("GSTP");
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["chargename"] = obj_dt.Rows[i][0].ToString();
                    dr["chargetype"] = obj_dt.Rows[i][1].ToString();
                    dr["SACCode"] = obj_dt.Rows[i][2].ToString();
                    dr["GSTP"] = obj_dt.Rows[i][3].ToString();

                }

                grd.DataSource = obj_dtEmp;
                grd.DataBind();
            

        }


        protected void btn_save_Click(object sender, EventArgs e)
        {


            char costtype1 = '0';
            costtype = costtype1.ToString();
            double gst1, vat;
             
            FaDbName = HttpContext.Current.Session["FADbname"].ToString();
            Emp_Id = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if (ObtypeUSD == null)
            {
                char ObtypeUSD1;
                ObtypeUSD1 = '\0';

                ObtypeUSD = ObtypeUSD1.ToString();
            }
           if(ddl_reimbursement.SelectedIndex == 0)
           {
               ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('pls select Reimbursement')", true);
               return;
           }
           else  if (ddl_reimbursement.SelectedIndex == 1)
           {
               reimbursement='Y';
           }
           else if (ddl_reimbursement.SelectedIndex == 2)
           {
               reimbursement = 'N';
           }

            //nivetha 06102022
              if(ddl_newinvoiceno.SelectedIndex == 0)
           {
               ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('pls select newinvoiceno')", true);
               return;
           }
           else  if (ddl_newinvoiceno.SelectedIndex == 1)
           {
               new_invoiceno='Y';
           }
           else if (ddl_newinvoiceno.SelectedIndex == 2)
           {
               new_invoiceno = 'N';
           }
             //nivetha 06102022

            //if (txt_gstp.Text.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Do not leave Space Kindly Enter 0 or correct GST%')", true);
            //    return;
            //}
            if (Convert.ToInt32(Session["cid"]) != 1102 && Convert.ToInt32(Session["cid"]) !=  102)
            {
                if (txt_vat.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Do not leave Space Kindly Enter 0 or correct VAT')", true);
                    return;
                }

            }
            else
            {
                if (txt_gstp.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Do not leave Space Kindly Enter 0 or correct GST%')", true);
                    return;
                }
            }
            //Elengo

            if(ddl_cmbChargeType.SelectedItem.Text == "Admin")
            {
                if (txt_subgroup.Text == "" || hid_SubGroupid.Value == "0" || hid_SubGroupid.Value == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Kindly type Admin Have to give SubGroup Name')", true);
                    txt_subgroup.Text = "";             //NewOne    //19/08/2022
                    txt_group.Text = "";
                    txt_type.Text = "";
                    return;
                }
            }

            if (btn_save.ToolTip == "Save")
            {

                if ((txt_Percent.Text.ToString() == "" && txtsbcess.Text.ToString() == "" && txtkkcess.Text.ToString() == ""))
                {
                    //da_obj_chargesobj.InsertChargeDetails(txt_Charges.Text.ToUpper(), Convert.ToString(Session["ddl_cmbChargeType.SelectedValue"].ToString()), txt_saccode.Text, Convert.ToDouble(txt_gstp.Text));

                    if (txt_gstp.Text == "")
                    {
                        gst1 = 0;
                        hidgst1.Value = Convert.ToDouble(gst1).ToString();
                    }
                    else
                    {
                        gst1 = Convert.ToDouble(txt_gstp.Text);
                        hidgst1.Value = Convert.ToDouble(gst1).ToString();
                    }

                    if (txt_vat.Text == "")
                    {
                        vat = 0;
                        hidvat.Value = Convert.ToDouble(vat).ToString();
                    }

                    else
                    {
                        vat = Convert.ToDouble(txt_vat.Text);
                        hidvat.Value = Convert.ToDouble(vat).ToString();
                    }
                    if (ddl_Branch.SelectedValue != "India" && ddl_Branch.SelectedValue != "Dubai")
                    {
                        txt_saccode.Text = "";
                    }
                    //da_obj_chargesobj.InsertChargeDetails_new(txt_Charges.Text.ToUpper(), Convert.ToString(Session["ddl_cmbChargeType.SelectedValue"].ToString()), txt_saccode.Text, Convert.ToDouble(hidgst1.Value), Convert.ToDouble(hidvat.Value), Convert.ToInt32(Session["cid"]));

                    da_obj_chargesobj.InsChargeDetails4gst_new_24_08_2022(txt_Charges.Text.ToUpper(), Convert.ToString(Session["ddl_cmbChargeType.SelectedValue"].ToString()), txt_saccode.Text, Convert.ToDouble(hidgst1.Value), Convert.ToDouble(hidvat.Value), Convert.ToInt32(Session["cid"]), reimbursement.ToString(),new_invoiceno.ToString());




                    intcid = da_obj_chargesobj.GetChargeid(txt_Charges.Text);

                    if (ddl_cmbChargeType.SelectedItem.Text == "Admin")
                    {
                        ledgerid = ledgerobj.InsLedgerHead(txt_Charges.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(hid_GroupID.Value), 'G', FaDbName);
                        Session["ledgid"] = ledgerid.ToString();
                        hidledgid.Value = Session["ledgid"].ToString();
                        ledgerobj.InsLedgerDetails(ledgerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), '0', '0', 0, 0, FaDbName);
                        ledgerobj.UpdateLedgerDetails4USD(ledgerid, Convert.ToInt32(Session["LoginBranchid"].ToString()), 0, Convert.ToChar(ObtypeUSD), FaDbName, "");
                        //ledgerobj.UpdLedgerDetails(ledgerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), 'P', 0,0, "0", FaDbName, minbaldr, maxbaldr, minbalcr, maxbalcr,Convert.ToChar(costtype));
                        //ledgerobj.UpdLedgerDetails(ledgerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), 'O', 0, 0, "0", FaDbName, minbaldr, maxbaldr, minbalcr, maxbalcr,Convert.ToChar(costtype));

                        ledgerobj.UpdLedgerid(FaDbName, Convert.ToInt32(Session["LoginBranchId"]), ledgerid, intcid, Convert.ToChar(Session["ddl_cmbChargeType.SelectedValue"].ToString()));
                        logobj.InsLogDetail(Emp_Id, 1135, 2, Convert.ToInt32(Session["LoginBranchId"]), ledgerid + "-" + Convert.ToChar(Session["ddl_cmbChargeType.SelectedValue"].ToString()));
                        // updledggername();
                    }

                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved')", true);
                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 130, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_Charges.Text);
                    txtclear();
                }


                else if (txt_Percent.Text.ToString() != "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the Swachh Bharat And Krishi Kalayan Percentage')", true);
                }


            }
            else if (btn_save.ToolTip == "Update")
            {
                string saccode;
                if (ddl_Branch.SelectedValue == "India")
                {
                     saccode = txt_saccode.Text.ToUpper();
                }
                else
                {
                     saccode = "";
                }
                Decimal gstp;
                if (txt_gstp.Text != "" && ddl_Branch.SelectedValue == "India")
                {
                    gstp = Convert.ToDecimal(txt_gstp.Text);
                }
                else
                {
                    gstp = 0;
                }
                intcid = ledgerobj.GetLedgerId(txt_Charges.Text, Session["FADbname"].ToString());
                if (txt_Percent.Text.ToString() == "")
                {

                    //da_obj_chargesobj.UpdateChargeDetailstax(Convert.ToInt32(hf_chargeid.Value), txt_Charges.Text.ToUpper(), Convert.ToString(Session["ddl_cmbChargeType.SelectedValue"].ToString()), saccode, gstp);
                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 130, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_Charges.Text + "OLD GST %" + hidgst.Value + "New GST %" + gstp + "Chargeid:" + Convert.ToInt32(hf_chargeid.Value));
                    if (txt_gstp.Text=="")
                    {
                         gst1=0;
                         hidgst1.Value = Convert.ToDouble(gst1).ToString();
                    }
                    else
                    {
                        gst1= Convert.ToDouble(txt_gstp.Text);
                        hidgst1.Value =Convert.ToDouble(gst1).ToString();
                    }

                    if (txt_vat.Text=="")
                    {
                         vat=0;
                         hidvat.Value = Convert.ToDouble(vat).ToString();
                    }

                    else
                    {
                         vat=Convert.ToDouble(txt_vat.Text);
                         hidvat.Value = Convert.ToDouble(vat).ToString();
                    }
                    //obj_login.UpdateChargeDetailstax(Convert.ToInt32(hf_chargeid.Value), txt_Charges.Text.ToUpper(), Convert.ToString(Session["ddl_cmbChargeType.SelectedValue"].ToString()), saccode,Convert.ToString(gst1), 0,Convert.ToString(vat);


                    //obj_login.UpdateChargeDetailstax(Convert.ToInt32(hf_chargeid.Value), txt_Charges.Text.ToUpper(), Convert.ToString(Session["ddl_cmbChargeType.SelectedValue"].ToString()), saccode, Convert.ToDouble(hidgst1.Value),Convert.ToInt32(Session["cid"]), Convert.ToDouble(hidvat.Value));

                    da_obj_chargesobj.UpdChargeDetails4gstnew_24_08_2022(Convert.ToInt32(hf_chargeid.Value), txt_Charges.Text.ToUpper(), Convert.ToString(Session["ddl_cmbChargeType.SelectedValue"].ToString()), saccode, Convert.ToDouble(hidgst1.Value), Convert.ToInt32(Session["cid"]), Convert.ToDouble(hidvat.Value), reimbursement.ToString(),new_invoiceno.ToString());

                    if (ddl_cmbChargeType.SelectedItem.Text == "Admin")
                    {
                        ledgerobj.UpdLedgerHead(txt_Charges.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(Convert.ToInt32(hid_GroupID.Value)), 'G', intcid, FaDbName);
                        ledgerobj.UpdateLedgerDetails4USD(intcid, Convert.ToInt32(Session["LoginBranchId"]), 0, Convert.ToChar(ObtypeUSD), FaDbName, "");
                    }

                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                    btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["cīlass"] = "btn ico-save";
                    txtclear();

                }


                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the Swachh Bharat And Krishi Kalayan Percentage')", true);
                }

            }

            btn_back.Enabled = true;
            ddl_cmbChargeType.Focus();
        }
        private void txtclear()
        {
            txt_Charges.Text = "";
            txt_Percent.Text = "";
            //  txt_EduPer.Text = "";
            ddl_cmbChargeType.SelectedIndex = 0;
            ddl_Branch.SelectedIndex = 0;
            // txt_HighEduPer.Text = "";
            txtsbcess.Text = "";
            txt_saccode.Text = "";
            txt_gstp.Text = "";
            txt_vat.Text = "";
            txtkkcess.Text = "";
            txt_Amt.Text = "";
            txt_Curr.Text = "";
            chargetype = "";
            //grd.DataSource = new DataTable();
            //grd.DataBind();
            fill_grd();
            txt_subgroup.Text = "";
            txt_group.Text = "";
            txt_type.Text = "";
            AdminCharges.Visible = false;

            txt_Search.Text = "";
            hid_GroupID.Value = "";
            hid_SubGroupid.Value = "";
            hidledgid.Value = "";
            hidgst.Value = "";
        }

        protected void txt_Charges_TextChanged(object sender, EventArgs e)
        {
            if (ddl_Branch.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Branch');", true);
                return;
            }

            if (!string.IsNullOrEmpty(txt_Charges.Text))
            {

                str_charge = txt_Charges.Text.ToUpper();
                if (str_charge.Length > 5)
                {
                    str_charge = str_charge.Substring(0, 5).ToUpper();
                }
                else
                {
                    str_charge = str_charge.ToUpper();
                }



                //  if (str_charge == "ST on" || str_charge == "EduCe" || str_charge == "Highe")
                if (str_charge == "ST on" || str_charge == "Swach" || str_charge == "KRISH")
                {
                    getdata();
                    ddl_cmbChargeType_SelectedIndexChanged(sender, e);
                     btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    btn_back.Enabled = true;
                    txt_Charges.ReadOnly = true;
                    txt_Curr.ReadOnly = true;
                    txt_Percent.ReadOnly = true;
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Charge cannot be modified')", true);
                }

                else
                {
                   // DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
                    DataTable dt_charges = new DataTable();
                    dt_charges = da_obj_chargesobj.ShowChargeNameDetails(txt_Charges.Text.ToUpper(), "");
                    intcid = ledgerobj.GetLedgerId(txt_Charges.Text, Session["FADbname"].ToString());
                    dtl1 = ledgerobj.SelMasterLedger(intcid, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    if (dt_charges.Rows.Count != 0)
                    {
                        getdata();
                        ddl_cmbChargeType_SelectedIndexChanged(sender, e);
                          btn_save.Text = "Update";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Already Exists')", true);
                    }
                    if (dtl1.Rows.Count > 0)
                    {
                        //DataAccess.FAMaster.MasterSubGroup subobj = new DataAccess.FAMaster.MasterSubGroup();   //NewOne 
                        //DataTable obj_Dt = new DataTable();
                        //txt_subgroup.Text = dtl1.Rows[0]["subgroupname"].ToString();               
                        //obj_Dt = subobj.GetLikesubGroupid(txt_subgroup.Text, HttpContext.Current.Session["FADbname"].ToString());
                        //hid_SubGroupid.Value = obj_Dt.Rows[0]["subgroupid"].ToString();
                        //txt_group.Text = dtl1.Rows[0]["groupname"].ToString();
                        /*DataAccess.FAMaster.MasterSubGroup subobj = new DataAccess.FAMaster.MasterSubGroup();*/   //NewOne
                        DataTable obj_Dt = new DataTable();
                        txt_subgroup.Text = dtl1.Rows[0]["subgroupname"].ToString();
                        obj_Dt = subobj.GetLikesubGroupid(txt_subgroup.Text, HttpContext.Current.Session["FADbname"].ToString());
                        hid_SubGroupid.Value = obj_Dt.Rows[0]["subgroupid"].ToString();
                        DataTable dtSub = new DataTable();
                        dtSub = sobj.SelMastersubGroup(Convert.ToInt32(hid_SubGroupid.Value), Session["FADbname"].ToString());
                        if (dtSub.Rows.Count > 0)
                        {
                            hid_GroupID.Value = dtSub.Rows[0][0].ToString();
                        }
                        txt_group.Text = dtl1.Rows[0]["groupname"].ToString();
                        txt_type.Text = dtl1.Rows[0]["grouptype"].ToString();
                         
                          
                      
                    }
                    txt_saccode.Focus();
                }
                btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

            }
            else
            {
                txt_saccode.Focus();
            }
        }

        private void getdata4charge()
        {
            //DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
            DataTable dt_charges = new DataTable();
            dt_charges = da_obj_chargesobj.ShowChargeNameDetails(txt_Charges.Text.ToUpper(), chargetype);
            if (dt_charges.Rows.Count != 0)
            {
                txt_saccode.Text = (dt_charges.Rows[0][9].ToString());
                txt_gstp.Text = (dt_charges.Rows[0][10].ToString());
                if (dt_charges.Rows[0]["chargetype"].ToString() == "A")
                {
                    ddl_cmbChargeType.SelectedValue = "Admin";
                }
                else
                {
                    ddl_cmbChargeType.SelectedValue = "Operation";
                }

                if (string.IsNullOrEmpty(str_stpercent))
                {
                    hf_chargeid.Value = da_obj_chargesobj.GetChargeid(txt_Charges.Text.ToUpper()).ToString();
                }

            }
            else
            {
                txt_saccode.Text = "";
                txt_gstp.Text = "";
                 btn_save.Text = "Save";

                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                  btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }

        }

        private void getdata()
        {
           // DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
            DataTable dt_charges = new DataTable();
            dt_charges = da_obj_chargesobj.ShowChargeNameDetails(txt_Charges.Text.ToUpper(), "");
            if (dt_charges.Rows.Count != 0)
            {
                txt_saccode.Text = (dt_charges.Rows[0][9].ToString());
                if (ddl_Branch.SelectedValue == "India")
                {
                    txt_gstp.Text = (dt_charges.Rows[0][10].ToString());
                    hidgst.Value = txt_gstp.Text;
                }
                else if (ddl_Branch.SelectedValue == "Singapore")
                {
                    txt_vat.Text = dt_charges.Rows[0]["GSTSI"].ToString();
                }
                else if(ddl_Branch.SelectedValue == "Hong Kong")
                {
                    txt_vat.Text = dt_charges.Rows[0]["GSTHK"].ToString();
                }
                else if (ddl_Branch.SelectedValue == "Thailand")
                {
                    txt_vat.Text = dt_charges.Rows[0]["GSTTH"].ToString();
                }
                else if (ddl_Branch.SelectedValue == "Dubai")
                {
                    txt_vat.Text = dt_charges.Rows[0]["GSTUAE"].ToString();
                }
                //kalai Oct17
                else if (ddl_Branch.SelectedValue == "Wiz Bulk")
                {
                    txt_vat.Text = dt_charges.Rows[0]["GSTIZ"].ToString();
                }
                if (dt_charges.Rows[0]["chargetype"].ToString() == "A")
                {
                    ddl_cmbChargeType.SelectedValue = "Admin";
                }
                else
                {
                    ddl_cmbChargeType.SelectedValue = "Operation";
                }

                if (string.IsNullOrEmpty(str_stpercent))
                {
                    hf_chargeid.Value = da_obj_chargesobj.GetChargeid(txt_Charges.Text.ToUpper()).ToString();
                }

                if (dt_charges.Rows[0]["newinv"].ToString() == "Y")
                {
                    ddl_newinvoiceno.SelectedIndex = 1;
                }
                else if (dt_charges.Rows[0]["newinv"].ToString() == "N")
                {
                    ddl_newinvoiceno.SelectedIndex = 2;
                }
            

        
            }

        }

        protected void txt_Search_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                txtclear();

                    btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                txt_Charges.ReadOnly = false;
                txt_Amt.ReadOnly = false;
                txt_Curr.ReadOnly = false;
                txt_Percent.ReadOnly = false;
                chargetype = "";
                   btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                txt_subgroup.Text = "";
                txt_group.Text = "";
                txt_type.Text = "";
                AdminCharges.Visible = false;

                txt_Charges.Focus();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            //DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
            //string str_RptName = "";
            //string str_Script = "";
            //string str_sf = "";
            //string str_sp = "";
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";
            ////str_frmname = "Master Charges";
            //str_RptName = "MasterCharges.rpt";
            //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
            //da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 130, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "ChargeView");
            //Session["str_sfs"] = str_sf;
            //Session["str_sp"] = str_sp;

          //  DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
            string str_RptName = "";
            string str_Script = "";
            string str_sf = "";
            string str_sp = "";
            str_sf = "{MasterCharges.groupid}=1";
            Session["str_sp"] = "";
            //str_frmname = "Master Charges";
            string Ccode = Convert.ToString(Session["Ccode"]);
            str_RptName = "MasterCharges.rpt";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "&Ccode=" + Ccode +  "','','');";
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 130, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "ChargeView");
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
        }

        protected void ddl_cmbChargeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_cmbChargeType.SelectedValue != "")
            {

                if (ddl_cmbChargeType.SelectedValue == "Admin")
                {
                    chargetype = "A";
                    AdminCharges.Visible = true;
                    txt_group.Enabled = false;
                    txt_type.Enabled = false;
                    Session["ddl_cmbChargeType.SelectedValue"] = chargetype;
                }
                else
                {
                    chargetype = "O";
                    AdminCharges.Visible = false;
                    Session["ddl_cmbChargeType.SelectedValue"] = chargetype;
                }
                //getdata4charge();

            }
        }



        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataTable obj_dtEmp = new DataTable();
            if (txt_Search.Text != "")
            {

                if (Session["Date"] != null)
                {
                    obj_dtEmp = (DataTable)Session["Date"];
                    ViewState["Charge"] = obj_dtEmp;
                    grd.DataSource = obj_dtEmp;
                    grd.DataBind();

                }
                //  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = (DataTable)ViewState["Charge"];
            grd.DataBind();
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

        [WebMethod]
        public static List<string> GetSubgroupname(string prefix)
        {
            DataAccess.FAMaster.MasterSubGroup subobj = new DataAccess.FAMaster.MasterSubGroup();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            subobj.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> LedgerList = new List<string>();
            obj_Dt = subobj.GetLikesubGroupname(prefix.ToUpper(), HttpContext.Current.Session["FADbname"].ToString());

            LedgerList = Utility.Fn_DatatableToList_string1(obj_Dt, "subgroupname", "subgroupid");
            return LedgerList;
        }


        protected void txt_subgroup_TextChanged(object sender, EventArgs e)
        {
            if (txt_subgroup.Text != "")
            {
                DataTable dtSub = new DataTable();
                dtSub = sobj.SelMastersubGroup(Convert.ToInt32(hid_SubGroupid.Value), Session["FADbname"].ToString());
                if (dtSub.Rows.Count > 0)
                {
                    hid_GroupID.Value = dtSub.Rows[0][0].ToString();
                    txt_group.Text = dtSub.Rows[0][1].ToString();
                    txt_type.Text = dtSub.Rows[0][3].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Txt", "alertify.alert('Invalid SubGroupName');", true);
                }
            }
        }

        protected void loadgridlog()
        {
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel1.Visible = true;
           // DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 130, "MSCharge", hf_chargeid.Value, hf_chargeid.Value, "");  //"/Rate ID: " +
            if (txt_Charges.Text != "")
            {
                JobInput.Text = txt_Charges.Text;

            }
            else
            {
                JobInput.Text = "";
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void ddl_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddl_Branch.SelectedValue != "")
            {
                DataTable datact = new DataTable();
                if (ddl_Branch.SelectedValue == "Hong Kong")
                {
                    string ct = "HONG KONG";
                    datact = obj_login.portname_new(ct);
                    if(datact.Rows.Count>0)
                    {
                        int ctid =Convert.ToInt32(datact.Rows[0]["countryid"]);
                        Session["cid"] = Convert.ToInt32(ctid);
                        if (ctid != 1102 && ctid != 102)
                        {
                            Label7.Visible = true;
                            txt_vat.Visible = true;
                            txt_gstp.Visible =false;
                            Label5.Visible =false;
                            Label3.Visible = false;
                            txt_saccode.Visible = false;
                            grd.Columns[2].Visible = false;
                            Label9.Visible = false;Label9_id.Visible = false;
                            ddl_newinvoiceno.Visible = false;
                        }
                        else
                        {
                            Label7.Visible = false;
                            txt_vat.Visible = false;
                            txt_gstp.Visible = true;
                            Label5.Visible = true;
                            Label3.Visible = true;
                            txt_saccode.Visible = true;
                            grd.Columns[2].Visible = true;
                        }
                    }
                }
                else if (ddl_Branch.SelectedValue == "Singapore")
                {
                    string ct = "SINGAPORE";
                    datact = obj_login.portname_new(ct);
                    if (datact.Rows.Count > 0)
                    {
                        int ctid = Convert.ToInt32(datact.Rows[0]["countryid"]);
                        Session["cid"] = Convert.ToInt32(ctid);
                         if (ctid != 1102 && ctid != 102)
                        {
                            Label7.Visible = true;
                            txt_vat.Visible = true;
                            txt_gstp.Visible = false;
                            Label5.Visible = false;
                            Label3.Visible = false;
                            txt_saccode.Visible = false;
                            grd.Columns[2].Visible = false;
                            Label9.Visible = false;Label9_id.Visible = false;
                            ddl_newinvoiceno.Visible = false;
                        }
                        else
                        {
                            Label7.Visible = false;
                            txt_vat.Visible = false;
                            txt_gstp.Visible = true;
                            Label5.Visible = true;
                            Label3.Visible = true;
                            txt_saccode.Visible = true;
                            grd.Columns[2].Visible = true;
                        }
                    }
                }
                else if (ddl_Branch.SelectedValue == "Thailand")
                {
                    string ct = "THAILAND, BANGKOK";
                    datact = obj_login.portname_new(ct);
                    if (datact.Rows.Count > 0)
                    {
                        int ctid = Convert.ToInt32(datact.Rows[0]["countryid"]);
                        Session["cid"] = Convert.ToInt32(ctid);
                         if (ctid != 1102 && ctid != 102)
                        {
                            Label7.Visible = true;
                            txt_vat.Visible = true;
                            txt_gstp.Visible = false;
                            Label5.Visible = false;
                            Label3.Visible = false;
                            txt_saccode.Visible = false;
                            grd.Columns[2].Visible = false;
                            Label9.Visible = false;Label9_id.Visible = false;
                            ddl_newinvoiceno.Visible = false;
                        }
                        else
                        {
                            Label7.Visible = false;
                            txt_vat.Visible = false;
                            txt_gstp.Visible = true;
                            Label5.Visible = true;
                            Label3.Visible = true;
                            txt_saccode.Visible = true;
                            grd.Columns[2].Visible = true;
                        }
                    }
                }
                else if (ddl_Branch.SelectedValue == "India")
                {
                    string ct = "DELHI";
                    datact = obj_login.portname_new(ct);
                    if (datact.Rows.Count > 0)
                    {
                        int ctid = Convert.ToInt32(datact.Rows[0]["countryid"]);
                        Session["cid"] = Convert.ToInt32(ctid);

                        if (ctid != 1102 && ctid != 102)
                        {
                            Label7.Visible = true;
                            txt_vat.Visible = true;
                            txt_gstp.Visible = false;
                            Label5.Visible = false;
                            Label3.Visible = false;
                            txt_saccode.Visible = false;
                            grd.Columns[2].Visible = false;

                        }
                        else
                        {
                            Label7.Visible = false;
                            txt_vat.Visible = false;
                            txt_gstp.Visible = true;
                            Label5.Visible = true;
                            Label3.Visible = true;
                            txt_saccode.Visible = true;
                            grd.Columns[2].Visible = true;
                            Label9.Visible = true; Label9_id.Visible = true;
                            ddl_newinvoiceno.Visible = true;
                        }
                    }
                }
                else if (ddl_Branch.SelectedValue == "Dubai")
                {
                    string ct = "DUBAI, UAE";
                    datact = obj_login.portname_new(ct);
                    if (datact.Rows.Count > 0)
                    {
                        int ctid = Convert.ToInt32(datact.Rows[0]["countryid"]);
                        Session["cid"] = Convert.ToInt32(ctid);
                         if (ctid != 1102 && ctid != 102)
                        {
                            Label7.Visible = true;
                            txt_vat.Visible = true;
                            txt_gstp.Visible = false;
                            Label5.Visible = false;
                            Label3.Visible = true;

                            Label3.Text = "Vat Applicable"; 
                            txt_saccode.Visible = true;
                            grd.Columns[2].Visible = false;
                            Label9.Visible = false;Label9_id.Visible = false;
                            ddl_newinvoiceno.Visible = false;
                        }
                        else
                        {
                            Label7.Visible = false;
                            txt_vat.Visible = false;
                            txt_gstp.Visible = true;
                            Label5.Visible = true;
                            Label3.Visible = true;
                            txt_saccode.Visible = true;
                            grd.Columns[2].Visible = true;
                        }
                    }
                }
                //kalai Oct17
                else if (ddl_Branch.SelectedValue == "Wiz Bulk")
                {
                    string ct = "SINGAPORE";
                    datact = obj_login.portname_new(ct);
                    if (datact.Rows.Count > 0)
                    {
                        int ctid = 204;
                        //int ctid = Convert.ToInt32(datact.Rows[0]["countryid"]);
                        Session["cid"] = Convert.ToInt32(ctid);
                         if (ctid != 1102 && ctid != 102)
                        {
                            Label7.Visible = true;
                            txt_vat.Visible = true;
                            txt_gstp.Visible = false;
                            Label5.Visible = false;
                            Label3.Visible = false;
                            txt_saccode.Visible = false;
                            grd.Columns[2].Visible = false;
                            Label9.Visible = false;Label9_id.Visible = false;
                            ddl_newinvoiceno.Visible = false;
                        }
                        else
                        {
                            Label7.Visible = false;
                            txt_vat.Visible = false;
                            txt_gstp.Visible = true;
                            Label5.Visible = true;
                            Label3.Visible = true;
                            txt_saccode.Visible = true;
                            grd.Columns[2].Visible = true;
                        }
                    }
                }
                else
                {
                    txt_gstp.Visible = true;
                    Label5.Visible = true;
                    Label3.Visible = true;
                    txt_saccode.Visible = true;
                    grd.Columns[2].Visible = true;
                    Label9.Visible = false;Label9_id.Visible = false;
                    ddl_newinvoiceno.Visible = false;
                }
            }
        }
    }
}