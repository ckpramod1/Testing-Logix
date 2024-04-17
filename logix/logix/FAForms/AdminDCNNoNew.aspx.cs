using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.FAForm
{
    public partial class AdminDCNNoNew : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        int supplytoid;
        int BranchID;
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.FAVoucher FAobj = new DataAccess.FAVoucher();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            BranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            txt_Refno.Focus();

            try
            {
                string str_FornName = "", str_Uiid = "";

                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    lbl_Header.Text = Request.QueryString["type"].ToString();
                }

                if (Request.QueryString.ToString().Contains("FormName"))
                {
                    str_FornName = Request.QueryString["FormName"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    lbl_Header.Text = Request.QueryString["FormName"].ToString();
                }

                if (Request.QueryString.ToString().Contains("VNo"))
                {
                    txt_Refno.Text = Request.QueryString["VNo"].ToString();

                    BranchID = Convert.ToInt32(Request.QueryString["PBranch_ID"].ToString());
                    if (BranchID == 0)
                    {
                        BranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    }


                }

                if (lbl_Header.Text == "Admin Sales Invoice")
                {
                    hid_type.Value = "DN";
                    hid.Value = "R";
                    txt_Refno.ToolTip = "DN #";
                    //txt_Refno.Attributes.Add("placeholder", "DN #");
                    txt_to.ToolTip = "Bill To";
                    txtsupplyto.ToolTip = "Supply To";
                    //txt_to.Attributes["Placeholder"] = "Bill To";
                    //txtsupplyto.Attributes["Placeholder"] = "Supply To";
                    Label6.Text = "DN #";
                    Label7.Text = "Bill To";
                    Label8.Text = "Supply To";

                }
                else
                {
                    hid_type.Value = "PA";
                    hid.Value = "C";
                    txt_Refno.ToolTip = "CN #";
                    //txt_Refno.Attributes.Add("placeholder", "CN #");
                    txt_to.ToolTip = "Bill From";
                    txtsupplyto.ToolTip = "Supply From";
                    //txt_to.Attributes["Placeholder"] = "Bill From";
                    //txtsupplyto.Attributes["Placeholder"] = "Supply From";
                    Label6.Text = "CN #";
                    Label7.Text = "Bill From";
                    Label8.Text = "Supply From";
                }
                if (lbl_Header.Text == "Admin Purchase Invoice")
                {
                    vendorid.Visible = true;
                }
                else
                {
                    vendorid.Visible = false;
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

                if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC")
                {
                    lblHead.InnerText = "Financial Accounts";
                    txt_date.Enabled = false;
                    txt_year.Enabled = false;
                }
                else if (Hid_HeadTrantype.Value == "AC")
                {
                    lblHead.InnerText = "Operating Accounts";
                }

                if (!IsPostBack)
                {
                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                     btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    string str_CtrlLists, str_MsgLists, str_DataType;
                    str_CtrlLists = "txt_bl~txt_to~hid_customerid~ddl_bill";
                    str_MsgLists = "Ref#~Customer~Customer~BillType";
                    str_DataType = "String~String~AutoComplete~ddl";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                    //btn_view.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                    txt_date.Text = hid_date.Value.ToString();
                    FillOnPageLoad();
                    DataTable obj_dt = new DataTable();
                    Grd_Charge.DataSource = obj_dt;
                    Grd_Charge.DataBind();
                    txt_year.Text = Session["Vouyear"].ToString();
                    txt_Refno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Charge.DataBind();
                    txt_Refno.Focus();


                    grd.DataSource = new DataTable();
                    grd.DataBind();
                

                }

                HeaderLabel.InnerText = lbl_Header.Text;
                if (Request.QueryString.ToString().Contains("VNo"))
                {
                    txt_Refno_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                //Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_Refno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hid_refno.Value = txt_Refno.Text;

                Fn_Clear();

                txt_Refno.Text = hid_refno.Value;


                 btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                string bill, custtype;
                DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
                DataAccess.Accounts.AdminDCNNo obj_da_AdminDnCN = new DataAccess.Accounts.AdminDCNNo();
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                DataTable obj_dt = new DataTable();

                string citysupplyid = "";

                String type = "";
                if (lbl_Header.Text == "Admin Sales Invoice")
                {
                    type = "X";
                }
                else if (lbl_Header.Text == "Admin Purchase Invoice")
                {
                    type = "S";
                }

                obj_dt = obj_da_AdminDnCN.ShowAdminDCNHeadFromDCNNo(int.Parse(txt_Refno.Text), hid_type.Value, int.Parse(txt_year.Text), BranchID);

                if (obj_dt.Rows.Count > 0)
                {
                    string paymentvou = "";
                    //paymentvou = INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txt_Refno.Text), BranchID, int.Parse(txt_year.Text), type);
                    DataTable Against = new DataTable();
                    if (INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txt_Refno.Text), BranchID, int.Parse(txt_year.Text), type) != "0")
                    {
                        Against = INVOICEobj.GetVoucherAgainstRcptPayNEW(Convert.ToInt32(txt_Refno.Text), BranchID, int.Parse(txt_year.Text), type);
                    }


                    lst_container.Items.Clear();
                    //lst_container.Items.Add(paymentvou);
                    for (int x = 0; x <= Against.Rows.Count - 1; x++)
                    {
                        lst_container.Items.Add(Against.Rows[x][0].ToString());
                    }

                    //if (paymentvou == "")
                    //{
                    //    lst_container.Items.Clear();
                    //}

                    //if (paymentvou == "0")
                    //{
                    //    lst_container.Items.Clear();
                    //}



                    //lbl_against.Text = INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txt_Refno.Text), BranchID, int.Parse(txt_year.Text), type);
                    //if (lbl_against.Text.Length == 0)
                    //{
                    //    lbl_against.Text = "";
                    //}

                    //if (lbl_against.Text == "0")
                    //{
                    //    lbl_against.Text = "";
                    //}

                    txt_bl.Text = obj_dt.Rows[0]["refno"].ToString();
                    hid_customerid.Value = obj_dt.Rows[0]["customerid"].ToString();
                    //Ruban add
                    custtype = obj_da_Customer.GetCustomerType(Convert.ToInt32(hid_customerid.Value));

                    if (custtype == "P")
                    {
                        radio_agent.Checked = true;
                        radio_agent.Enabled = false;
                    }
                    else
                    {
                        radio_customer.Checked = true;
                        radio_customer.Enabled = false;
                    }
                    //old
                    txt_to.Text = obj_da_Customer.GetCustomername(int.Parse(hid_customerid.Value.ToString()));

                    citysupplyid = obj_da_Customer.GetCustlocation(int.Parse(hid_customerid.Value.ToString()));
                    txtbilladd.Text = customerobj.GetCustomerAddress(txt_to.Text.Trim(), custtype, citysupplyid);


                    txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                    bill = obj_da_AdminDnCN.GetBillType(char.Parse(obj_dt.Rows[0]["billtype"].ToString()));

                    if (!string.IsNullOrEmpty(obj_dt.Rows[0]["SupplyTo"].ToString()))
                    {
                        supplytoid = Convert.ToInt32(obj_dt.Rows[0]["SupplyTo"].ToString());
                        txtsupplyto.Text = obj_da_Customer.GetCustomername(supplytoid);

                        citysupplyid = customerobj.GetCustlocation(supplytoid);
                        txtsupplyadd.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), custtype, citysupplyid);
                    }
                    if (lbl_Header.Text == "Admin Purchase Invoice")
                    {
                        if (!string.IsNullOrEmpty(obj_dt.Rows[0]["Vendorrefno"].ToString()))
                        {
                            txt_vendor.Text = obj_dt.Rows[0]["Vendorrefno"].ToString();
                        }
                        else
                        {
                            txt_vendor.Text = "";
                        }


                        if (!string.IsNullOrEmpty(obj_dt.Rows[0]["vendorrefdate"].ToString()))
                        {
                            txtVendorRefnodate.Text = obj_dt.Rows[0]["vendorrefdate"].ToString();
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                    }
                    else
                    {
                        txt_vendor.Text = "";
                        txtVendorRefnodate.Text = "";

                    }
                    if (!string.IsNullOrEmpty(obj_dt.Rows[0]["preparedby"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_prepare.Text = obj_dt.Rows[0]["preparedby"].ToString();
                    }

                    if (!string.IsNullOrEmpty(obj_dt.Rows[0]["approvedby"].ToString()))
                    {
                        lbl_txt.Visible = true;
                        lbl_Approve.Text = obj_dt.Rows[0]["approvedby"].ToString();
                    }


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

                    txt_date.Text = Utility.fn_ConvertDate(obj_dt.Rows[0][1].ToString());
                    hid_transfer.Value = obj_dt.Rows[0]["fatransfer"].ToString();

                    Fn_Getdetail();
                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";

                    if (hid_transfer.Value.ToString().Trim().Length == 0)
                    {
                        btn_save.Visible = false;
                        btn_save.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        btn_save.Visible = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                    }

                    if (Convert.ToInt32(txt_year.Text) > 2011)
                    {
                        Fn_GetFADetails();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_Refno, typeof(TextBox), "Debit", "alertify.alert('Invalid " + txt_Refno.ToolTip + "');", true);
                    Fn_Clear();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                //Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        
        private void Fn_Clear()
        {
            lst_container.Items.Clear();
            txtbilladd.Text = "";
            txtsupplyadd.Text = "";


            //lbl_against.Text = "";
            txt_Refno.Text = "";
            txt_bl.Text = "";
            txt_to.Text = "";
            txtsupplyto.Text = "";
            txt_remark.Text = "";
            txt_vendor.Text = "";
            txtVendorRefnodate.Text = "";
            ddl_bill.SelectedIndex = 0;
            Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Charge.DataBind();
            grd.DataSource = Utility.Fn_GetEmptyDataTable();
            grd.DataBind();
            //    btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            btn_save.Enabled = true;
            btn_save.ForeColor = System.Drawing.Color.White;
            txt_total.Text = "";
            txt_date.Text = Logobj.GetDate().ToString("dd/MM/yyyy");

        }
        private void Fn_Getdetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Accounts.AdminDCNNo obj_da_AdminDNCN = new DataAccess.Accounts.AdminDCNNo();
                obj_dt = obj_da_AdminDNCN.GetAdminDCNDetails(int.Parse(txt_Refno.Text), hid_type.Value.ToString(), int.Parse(txt_year.Text), BranchID);
                double Total = 0;
                DataTable dtempty = new DataTable();
                dtempty.Columns.Add("charge", typeof(string));
                dtempty.Columns.Add("curr", typeof(string));
                dtempty.Columns.Add("rate", typeof(string));
                dtempty.Columns.Add("exrate", typeof(string));
                dtempty.Columns.Add("base", typeof(string));
                dtempty.Columns.Add("Amount", typeof(string));
                dtempty.Columns.Add("GST", typeof(string));
                dtempty.Columns.Add("Total Amount", typeof(string));
                dtempty.Columns.Add("opstype", typeof(string));
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

                        dr[5] = obj_dt.Rows[i]["withoutgstAmt"].ToString();
                        dr[6] = obj_dt.Rows[i]["stgst"].ToString();
                        dr[7] = obj_dt.Rows[i]["amount"].ToString();
                        dr[8] = obj_dt.Rows[i]["opstype"].ToString();

                        Total = Total + double.Parse(obj_dt.Rows[i]["amount"].ToString());
                    }

                }
                obj_dt = obj_da_AdminDNCN.GetAdminDCNDetailswithCust(int.Parse(txt_Refno.Text), hid_type.Value.ToString(), int.Parse(txt_year.Text), BranchID);

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
                        dr[5] = obj_dt.Rows[i]["withoutgstAmt"].ToString();
                        dr[6] = obj_dt.Rows[i]["stgst"].ToString();
                        dr[7] = obj_dt.Rows[i]["amount"].ToString();
                        dr[8] = obj_dt.Rows[i]["opstype"].ToString();

                        Total = Total + double.Parse(obj_dt.Rows[i]["amount"].ToString());
                    }

                }
                txt_total.Text = string.Format("{0:#,##0.00}", Total);
                Grd_Charge.DataSource = dtempty;
                Grd_Charge.DataBind();
                btn_view.Focus();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                //Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                int int_bid = int.Parse(BranchID.ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                DataAccess.Accounts.AdminDCNNo obj_da_AdminDNCN = new DataAccess.Accounts.AdminDCNNo();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                if (btn_save.ToolTip == "Save")
                {

                    if (hid_type.Value.ToString() == "DN")
                    {
                        txt_Refno.Text = obj_da_AdminDNCN.GetAdmDNno(int_bid).ToString();
                    }
                    else
                    {
                        txt_Refno.Text = obj_da_AdminDNCN.GetAdmCNno(int_bid).ToString();
                    }
                    obj_da_AdminDNCN.InsertDCNHead(int.Parse(txt_Refno.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)), int.Parse(hid_customerid.Value.ToString()), txt_bl.Text, txt_remark.Text, int_bid, ddl_bill.SelectedItem.Text, int_Empid, hid_type.Value.ToString(), int.Parse(txt_year.Text));
                    if (Session["LoginBranchName"].ToString() == "CO - ACCOUNTS")
                    {
                        if (hid_type.Value.ToString() == "PA")
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 10005, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                        }
                        else
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 10004, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                        }
                    }
                    else
                    {
                        if (hid_type.Value.ToString() == "PA")
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 10005, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                        }
                        else
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 10004, 1, int_bid, hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                        }
                    }
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Details Saved');", true);
                }
                else
                {
                    obj_da_AdminDNCN.UpdDCNHead(int.Parse(txt_Refno.Text), int.Parse(hid_customerid.Value.ToString()), txt_remark.Text, int_bid, ddl_bill.SelectedItem.Text, hid_type.Value.ToString(), int.Parse(txt_year.Text), txt_bl.Text);
                    if (Session["LoginBranchName"].ToString() == "CO - ACCOUNTS")
                    {
                        if (hid_type.Value.ToString() == "PA")
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 10005, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                        }
                        else
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 10004, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                        }
                    }
                    else
                    {
                        if (hid_type.Value.ToString() == "PA")
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 10005, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                        }
                        else
                        {
                            obj_da_Log.InsLogDetail(int_Empid, 10004, 2, int_bid, hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                        }
                    }
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Debit", "alertify.alert('Details Updated');", true);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                //Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void FillOnPageLoad()
        {
            try
            {


                ddl_bill.Items.Clear();
                ddl_bill.Items.Add("");
                if (Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                {

                    ddl_bill.Items.Add("Cash/Cheque");
                    ddl_bill.Items.Add("Credit");
                    ddl_bill.Items.Add("Internal");
                }
                else
                {

                    ddl_bill.Items.Add("Cash/Cheque");
                    ddl_bill.Items.Add("Credit");
                    ddl_bill.Items.Add("Internal");

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";

                lbl_txt.Visible = false;
            }
            else
            {
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

        /* protected void btn_view_Click(object sender, EventArgs e)
         {
             string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
             Session["str_sfs"] = "";
             Session["str_sp"] = "";
             DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
             if (txt_Refno.Text.Trim().Length > 0)
             {
                 if (hid_type.Value == "DN")
                 {
                     Str_RptName = "AdmDebit.rpt";
                     Session["str_sfs"] = "{AdmDNHead.dnno}=" + txt_Refno.Text + " and {AdmDNHead.vouyear}=" + txt_year.Text + " and {AdmDNHead.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {AdmDNHead.deleted}='N'";
                     Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                     ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                     //Session["str_sfs"] = Str_sf;
                     Session["str_sp"] = Str_sp;
                 }
                 else
                 {
                     Str_RptName = "AdmCredit.rpt";
                     Session["str_sfs"] = "{AdmCNHead.cnno}=" + txt_Refno.Text + " and {AdmCNHead.vouyear}=" + txt_year.Text + " and {AdmCNHead.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {AdmCNHead.deleted}='N'";
                     Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                     ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                     //Session["str_sfs"] = Str_sf;
                     Session["str_sp"] = Str_sp;
                 }
             }
             else
             {
                 if (hid_type.Value == "DN")
                 {
                     Str_RptName = "AdmDebitRegister.rpt";
                     Str_sp = "Title=Admin Sales Invoice Register";
                     Str_sf = "{AdmDNHead.branchid}=" + Session["LoginBranchid"].ToString();
                     Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                     ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                     //Session["str_sfs"] = Str_sf;
                     Session["str_sp"] = Str_sp;
                 }
                 else
                 {
                     Str_RptName = "AdmCreditRegister.rpt";
                     Str_sp = "Title=Admin Purchase Invoice Register";
                     Str_sf = "{AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString();
                     Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                     ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                     //Session["str_sfs"] = Str_sf;
                     Session["str_sp"] = Str_sp;
                 }
             }
             //if (lbl_Header.Text == "Profoma Admin Purchase Invoice" && txt_Refno.Text.Trim().Length == 0)
             //{

             //}
             //else if (lbl_Header.Text == "Profoma Admin Purchase Invoice" && txt_Refno.Text.Trim().Length > 1)
             //{
             //    Str_RptName = "AdmProCredit.rpt";
             //    Str_sp = "";
             //    Str_sf = "{AdmCNHead.prorefno}=" + txt_Refno.Text + " and {AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmCNHead.vouyear}=" + txt_year.Text;
             //    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
             //    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
             //}
             if (Session["LoginBranchName"].ToString() == "CO - ACCOUNTS")
             {
                 if (hid_type.Value.ToString() == "PA")
                 {
                     obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1992, 3, Convert.ToInt32(Session["LoginBranchid"]), hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                 }
                 else
                 {
                     obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1991, 3, Convert.ToInt32(Session["LoginBranchid"]), hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                 }
             }
             else
             {
                 if (hid_type.Value.ToString() == "PA")
                 {
                     obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1992, 3, Convert.ToInt32(Session["LoginBranchid"]), hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                 }
                 else
                 {
                     obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1991, 3, Convert.ToInt32(Session["LoginBranchid"]), hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                 }




             }
         }*/

        //GST

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                string agent = "";
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DateTime gst_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                DateTime getdate = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));

                if (txt_Refno.Text.Trim().Length > 0)
                {
                    if (hid_customerid.Value != "" || hid_customerid.Value != "0")
                    {
                        if (customerobj.GetCustomerType(Convert.ToInt32(hid_customerid.Value)) == "P")
                        {
                            agent = "P";
                        }
                    }

                    if (hid_type.Value == "DN")
                    {
                        Str_RptName = "AdmDebit.rpt";
                        Session["str_sfs"] = "{AdmDNHead.dnno}=" + txt_Refno.Text + " and {AdmDNHead.vouyear}=" + txt_year.Text + " and {AdmDNHead.branchid}=" + Convert.ToInt32(BranchID) + " and {AdmDNHead.deleted}='N'";

                        if (gst_date <= getdate)
                        {
                            Str_Script = "window.open('../Reportasp/AdminDCNrptFA.aspx?DCN=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&customertype=" + agent + "&branchid=" + Convert.ToInt32(BranchID) + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        //Str_Script = "window.open('../Reportasp/AdminDCNrptFA.aspx?DCN=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_total.Text + "&form=" + "Admin-DN" + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        Str_RptName = "AdmCredit.rpt";
                        Session["str_sfs"] = "{AdmCNHead.cnno}=" + txt_Refno.Text + " and {AdmCNHead.vouyear}=" + txt_year.Text + " and {AdmCNHead.branchid}=" + Convert.ToInt32(BranchID) + " and {AdmCNHead.deleted}='N'";
                        if (gst_date <= getdate)
                        {
                            Str_Script = "window.open('../Reportasp/AdminDCNrptFA.aspx?DCN=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&customertype=" + agent + "&branchid=" + Convert.ToInt32(BranchID) + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        //Str_Script = "window.open('../Reportasp/AdminDCNrptFA.aspx?DCN=" + txt_Refno.Text + "&vouyear=" + txt_year.Text + "&total=" + txt_total.Text + "&form=" + "Admin-CN" + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        Session["str_sp"] = Str_sp;
                    }
                }
                else
                {
                    if (hid_type.Value == "DN")
                    {
                        Str_RptName = "AdmDebitRegister.rpt";
                        Str_sp = "Title=Admin Sales Invoice Register";
                        Str_sf = "{AdmDNHead.branchid}=" + BranchID;
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        //Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        Str_RptName = "AdmCreditRegister.rpt";
                        Str_sp = "Title=Admin Purchase Invoice Register";
                        Str_sf = "{AdmCNHead.branchid}=" + BranchID;
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                        //Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                }
                //if (lbl_Header.Text == "Profoma Admin Purchase Invoice" && txt_Refno.Text.Trim().Length == 0)
                //{

                //}
                //else if (lbl_Header.Text == "Profoma Admin Purchase Invoice" && txt_Refno.Text.Trim().Length > 1)
                //{
                //    Str_RptName = "AdmProCredit.rpt";
                //    Str_sp = "";
                //    Str_sf = "{AdmCNHead.prorefno}=" + txt_Refno.Text + " and {AdmCNHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {AdmCNHead.vouyear}=" + txt_year.Text;
                //    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Debit", Str_Script, true);
                //}
                if (Session["LoginBranchName"].ToString() == "CO - ACCOUNTS")
                {
                    if (hid_type.Value.ToString() == "PA")
                    {
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10005, 3, Convert.ToInt32(BranchID), hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10004, 3, Convert.ToInt32(BranchID), hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                    }
                }
                else
                {
                    if (hid_type.Value.ToString() == "PA")
                    {
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10005, 3, Convert.ToInt32(BranchID), hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10004, 3, Convert.ToInt32(BranchID), hid_type.Value.ToString() + "# - " + txt_Refno.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
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
            if (hid_type.Value.ToString() == "PA")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(BranchID), 10005, hid_type.Value.ToString(), txt_Refno.Text, txt_Refno.Text, Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(BranchID), 10004, hid_type.Value.ToString(), txt_Refno.Text, txt_Refno.Text, Session["StrTranType"].ToString());
            }


            if (txt_Refno.Text != "")
            {
                JobInput.Text = txt_Refno.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }


        /************************************************* New **********************************************/

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (lbl_Header.Text == "Admin Sales Invoice")
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
                else if (lbl_Header.Text == "Admin Purchase Invoice")
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

        private void Fn_GetFADetails()
        {
            int vouno = 0, bid = 0, divid = 0, voutypeid = 0, vouyear = 0;
            string dbname = "";
            DataTable dtfa = new DataTable();
            
            vouno = Convert.ToInt32(txt_Refno.Text);
            bid = BranchID;
            divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            vouyear = Convert.ToInt32(txt_year.Text);
            dbname = Session["FADbname"].ToString();
            voutypeid = FAobj.Selvoutypeid(lbl_Header.Text, dbname);

            dtfa = FAobj.SelFAVoucherNew(vouno, BranchID, divid, voutypeid, vouyear, dbname);

            if(dtfa.Rows.Count > 0)
            {
                DataRow dr_temp = dtfa.NewRow();
                dr_temp["ledgername"] = "Total";
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

        protected void Grd_Charge_PreRender(object sender, EventArgs e)
        {
            if (Grd_Charge.Rows.Count > 0)
            {
                Grd_Charge.UseAccessibleHeader = true;
                Grd_Charge.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


    }
}