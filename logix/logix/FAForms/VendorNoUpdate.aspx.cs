using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Remoting;

namespace logix.FAForms
{
    public partial class VendorNoUpdate : System.Web.UI.Page
    {
        int EmpId = 0;
        DataAccess.LogDetails Log_Obj = new DataAccess.LogDetails();
        DataAccess.Accounts.TDS_Removal objTDS_REM = new DataAccess.Accounts.TDS_Removal();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Log_Obj.GetDataBase(Ccode);
                objTDS_REM.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                txt_year.Text = Session["Vouyear"].ToString();
                txt_VoucherNo.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

            }
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            string usermail = "", empmailadd = "", sendqry = "";

            //DataAccess.Accounts.TDS_Removal objTDS_REM = new DataAccess.Accounts.TDS_Removal();
            //Vendor Ref # update query same as query name also don't refer the dataacess
            if(txt_venDate.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Date", "alertify.alert('Kindly choose the Vendor date');", true);
                txt_venDate.Focus();
                return;
            }
            if (txt_vendorchange.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Date", "alertify.alert('Kindly choose the Vendorref #');", true);
                txt_vendorchange.Focus();
                return;
            }
            objTDS_REM.VendornoUpdate(Convert.ToInt32(txt_VoucherNo.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(ddl_voucher.SelectedValue), txt_vendorchange.Text.ToUpper(), Session["FADbname"].ToString(), DateTime.Parse(Utility.fn_ConvertDatetime(txt_venDate.Text).ToString()));

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Update", "alertify.alert('Vendor # has Updated " + txt_vendorno.Text + " instead of " + txt_vendorchange.Text + "');", true);
            //Insert to Log
            if (Session["LoginBranchname"].ToString().ToUpper() == "CORPORATE")
            {
                Log_Obj.InsLogDetail(EmpId, 1961, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Vou #" + txt_VoucherNo.Text + "voutype" + ddl_voucher.SelectedValue + "Old Vendor #" + txt_vendorno.Text + " New Vendor # " + txt_vendorchange.Text + "/Update");
            }
            else
            {
                Log_Obj.InsLogDetail(EmpId, 1960, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Vou #" + txt_VoucherNo.Text + "voutype" + ddl_voucher.SelectedValue + "Old Vendor #" + txt_vendorno.Text + " New Vendor # " + txt_vendorchange.Text + "/Update");
            }
            return;
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                Fn_Clear();
                btn_back.Text = "Cancel";
                btn_back.Text = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                this.Response.End();
            }
        }
        private void Fn_Clear()
        {

            txt_Customer.Text = "";
            txt_vendorchange.Text = "";
            txt_vendorno.Text = "";
            txt_supplto.Text = "";
            ddl_voucher.SelectedIndex = 0;
            txt_VoucherNo.Text = "";
            txt_year.Text = Session["Vouyear"].ToString();
            lbl_VoucherNo.Text = "Vou #";
            txt_VoucherNo.ToolTip = "Vou #";
            txt_VoucherNo.Attributes.Add("placeholder", "Vou #");
            txt_venDate.Text = "";
        }
        protected void ddl_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_voucher.SelectedValue.ToString() == "E")
            {
                lbl_VoucherNo.Text = "Vou #";
                txt_VoucherNo.ToolTip = "Vou #";
                txt_VoucherNo.Attributes.Add("placeholder", "Vou #");

            }
            else if (ddl_voucher.SelectedValue.ToString() == "D")
            {
                lbl_VoucherNo.Text = "Vou #";
                txt_VoucherNo.ToolTip = "Vou #";
                txt_VoucherNo.Attributes.Add("placeholder", "Vou #");

            }
            else if (ddl_voucher.SelectedValue.ToString() == "P")
            {
                lbl_VoucherNo.Text = "Vou #";
                txt_VoucherNo.ToolTip = "Vou #";
                txt_VoucherNo.Attributes.Add("placeholder", "Vou #");
            }
            else if (ddl_voucher.SelectedValue.ToString() == "S")
            {
                lbl_VoucherNo.Text = "Vou #";
                txt_VoucherNo.ToolTip = "Vou #";
                txt_VoucherNo.Attributes.Add("placeholder", "Vou #");
            }
            else if (ddl_voucher.SelectedValue.ToString() == "C")
            {
                lbl_VoucherNo.Text = "Vou #";
                txt_VoucherNo.ToolTip = "Vou #";
                txt_VoucherNo.Attributes.Add("placeholder", "Vou #");
            }

        }

        protected void txt_VoucherNo_TextChanged(object sender, EventArgs e)
        {
            Fn_Getdetail();
        }
        private void Fn_Getdetail()
        {
            try
            {
                int int_voucherNo = int.Parse(Session["LoginBranchid"].ToString());
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                char char_Mode;
                DataTable obj_dt = new DataTable();
                DataTable dt = new DataTable();
               // DataAccess.Accounts.TDS_Removal objTDS_REM = new DataAccess.Accounts.TDS_Removal();


                if (ddl_voucher.SelectedItem.Text != "Voucher Type" && txt_VoucherNo.Text.ToString().Trim().Length > 0 && txt_year.Text.ToString().Trim().Length > 0)
                {
                    char_Mode = char.Parse(ddl_voucher.SelectedValue.ToString());

                    obj_dt = objTDS_REM.VendorNoChange(int.Parse(txt_VoucherNo.Text), int.Parse(txt_year.Text), int_bid, char_Mode);

                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_Customer.Text = obj_dt.Rows[0]["CUSTOMERNAME"].ToString();
                        txt_vendorno.Text = obj_dt.Rows[0]["vendorno"].ToString();
                        txt_supplto.Text = obj_dt.Rows[0]["supplyto"].ToString();
                        
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TDSRemoval", "alertify.alert('Invalid " + lbl_VoucherNo.Text + "');", true);
                    Fn_Clear();
                    return;
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
            GridViewlog.Visible = true;
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1961, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1960, "", "", "", Session["StrTranType"].ToString());
            }


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
    }
}