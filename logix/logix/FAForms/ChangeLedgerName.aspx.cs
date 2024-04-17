using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services.Description;

namespace logix.FAForm
{
    public partial class ChangeLedgerName : System.Web.UI.Page
    {
        bool blnerr = false;
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCountry obj_da_Country = new DataAccess.Masters.MasterCountry();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_Customer.GetDataBase(Ccode);
                obj_da_port.GetDataBase(Ccode);
                obj_da_Country.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                
            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            string str_CtrlLists, str_MsgLists, str_DataType;
            str_CtrlLists = "txt_customer~hid_custid~txt_location~hid_cityid~ddl_type";
            str_MsgLists = "Customer~Customer~Location~Location~CustomerType";
            str_DataType = "String~AutoComplete~String~AutoComplete~DropDown";
            
            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                btn_Update.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");
            }          
        }

        protected void txt_location_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_location.Text.Trim().Length > 0)
                {
                    DataTable obj_dt = new DataTable();
                   // DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                    obj_dt = obj_da_Customer.RetrieveCustomerDetails(txt_customer.Text, ddl_type.SelectedItem.Text, txt_location.Text);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_address.Text = obj_dt.Rows[0][0].ToString();
                        txt_zip.Text = obj_dt.Rows[0][2].ToString();
                        txt_phone.Text = obj_dt.Rows[0][3].ToString();
                        txt_fax.Text = obj_dt.Rows[0][4].ToString();
                        hid_cityid.Value = obj_dt.Rows[0][1].ToString();
                        hid_custid.Value = obj_dt.Rows[0][7].ToString();
                        txt_ledgername.Text = obj_dt.Rows[0][17].ToString();
                        //DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
                        //DataAccess.Masters.MasterCountry obj_da_Country = new DataAccess.Masters.MasterCountry();
                        txt_city.Text = obj_da_port.GetPortname(int.Parse(hid_cityid.Value.ToString()));
                        txt_country.Text = obj_da_Country.GetCountryName(txt_city.Text);
                        //btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }

                    btn_Update.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "LOGIXFA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                checkdata();

                if (blnerr == true)
                {
                    blnerr = false;
                    return;
                }

                if (txt_ledgername.Text.Trim().Length > 0)
                {
                    if (hid_custid.Value != "")
                    {
                        //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                        obj_da_Customer.ChangeLedgerName(int.Parse(hid_custid.Value.ToString()), txt_ledgername.Text.Trim());
                        btn_Update.Enabled = false;
                        //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 408, 1, int.Parse(Session["LoginBranchid"].ToString()), "CusId:" + hid_custid.Value + " / NewLedgName: " + txt_ledgername.Text + " / OldLedgName: " + hid_ledgername.Value);
                        ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "ChangeLedgerName", "alertify.alert('LedgerName Updated');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter the valid Customer Name');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "ChangeLedgerName", "alertify.alert('Enter LedgerName');", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "LOGIXFA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        private void Fn_Clear()
        {
            txt_address.Text = "";
            txt_city.Text = "";
            txt_country.Text = ""; 
            txt_customer.Text = "";
            txt_fax.Text = "";
            txt_ledgername.Text = "";
            txt_location.Text = "";
            txt_phone.Text = "";
            txt_zip.Text = "";
            ddl_type.SelectedIndex = 0;
            btn_Update.Enabled = false;
            //btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }
        
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
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
        }

        protected void checkdata()
        {
            if (txt_customer.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter the Customer Name')", true);
                txt_customer.Text = "";
                txt_customer.Focus();
                blnerr = true;
                return;
            }

            if (txt_ledgername.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter the Ledger Name')", true);
                txt_ledgername.Text = "";
                txt_ledgername.Focus();
                blnerr = true;
                return;
            }
        }

        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_customer.Text.Trim().Length > 0)
                {
                    DataTable obj_dt = new DataTable();
                   // DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                    obj_dt = obj_da_Customer.GetCustomerDetails4Ledger(Convert.ToInt32(hid_custid.Value));
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_address.Text = obj_dt.Rows[0]["address"].ToString();
                        txt_zip.Text = obj_dt.Rows[0]["zip"].ToString();
                        txt_phone.Text = obj_dt.Rows[0]["phone"].ToString();
                        txt_fax.Text = obj_dt.Rows[0]["fax"].ToString();
                        hid_cityid.Value = obj_dt.Rows[0]["portid"].ToString();
                        hid_custid.Value = obj_dt.Rows[0]["customerid"].ToString();
                        txt_ledgername.Text = obj_dt.Rows[0]["ledgername"].ToString();
                        hid_ledgername.Value = obj_dt.Rows[0]["ledgername"].ToString();
                        txt_city.Text = obj_dt.Rows[0]["city"].ToString();
                        txt_country.Text = obj_dt.Rows[0]["country"].ToString();
                        txt_location.Text = obj_dt.Rows[0]["location"].ToString();
                        
                        ddl_type.SelectedValue = obj_dt.Rows[0]["customertype"].ToString();

                        txt_address.Enabled = false;
                        txt_zip.Enabled = false;
                        txt_phone.Enabled = false;
                        txt_fax.Enabled = false;
                        txt_city.Enabled = false;
                        txt_country.Enabled = false;
                        txt_location.Enabled = false;
                        ddl_type.Enabled = false;

                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }

                    btn_Update.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "LOGIXFA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
    }
}