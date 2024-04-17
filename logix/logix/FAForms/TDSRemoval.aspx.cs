using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForms
{
    public partial class TDSRemoval : System.Web.UI.Page
    {
        int EmpId = 0;
        double Amount = 0.0;
        int Actamount = 0;
        int Tdsamount = 0;
        int TdsPercentage = 0;
        int tds = 0;
        char voutype;
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
                //DataAccess.Accounts.TDS_Removal objTDS_REM = new DataAccess.Accounts.TDS_Removal();


                if (ddl_voucher.SelectedItem.Text != "Voucher Type" && txt_VoucherNo.Text.ToString().Trim().Length > 0 && txt_year.Text.ToString().Trim().Length > 0)
                {
                    char_Mode = char.Parse(ddl_voucher.SelectedValue.ToString());

                    obj_dt = objTDS_REM.TDSRemovalnew(int.Parse(txt_VoucherNo.Text), int.Parse(txt_year.Text), int_bid, char_Mode);

                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_Customer.Text = obj_dt.Rows[0]["CUSTOMERNAME"].ToString();
                        txt_Amount.Text = obj_dt.Rows[0]["AMOUNT"].ToString();
                        txt_Actamount.Text = obj_dt.Rows[0]["ACTAMOUNT"].ToString();
                        txt_tdsamount.Text = obj_dt.Rows[0]["TDSAMOUNT"].ToString();
                        Txt_TdsPercentage.Text = obj_dt.Rows[0]["TDSPER"].ToString();
                        hid_Customerid.Value = obj_dt.Rows[0]["CUSTOMERID"].ToString();
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
        private void Fn_Clear()
        {
            txt_Customer.Text = "";
            txt_Amount.Text = "";
            txt_tdsamount.Text = "";
            Txt_TdsPercentage.Text = "";
            txt_Actamount.Text = "";
            txt_tds.Text = "";
            ddl_voucher.SelectedIndex = 0;
            txt_VoucherNo.Text = "";
            txt_year.Text = Session["Vouyear"].ToString();
            lbl_VoucherNo.Text = "Vou #";
            txt_VoucherNo.ToolTip = "Vou #";
            txt_VoucherNo.Attributes.Add("placeholder", "VoucherNo #");
        }
        protected void ddl_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_voucher.SelectedValue.ToString() == "E")
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

        }

        protected void txt_VoucherNo_TextChanged(object sender, EventArgs e)
        {
            Fn_Getdetail();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                Fn_Clear();
                btn_back.Text = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void txt_tds_TextChanged(object sender, EventArgs e)
        {
            txt_Tamount.Text = ((Convert.ToDouble(txt_Actamount.Text) * Convert.ToDouble(txt_tds.Text)) / 100).ToString("#,##0.00");
            txt_cstamt.Text = (Convert.ToDouble(txt_Amount.Text) - Convert.ToDouble(txt_Tamount.Text)).ToString("#,##0.00");
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string usermail = "", empmailadd = "", sendqry = "";

           // DataAccess.Accounts.TDS_Removal objTDS_REM = new DataAccess.Accounts.TDS_Removal();

            objTDS_REM.UpdateTDSRemoval(Convert.ToInt32(txt_VoucherNo.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToInt32(hid_Customerid.Value), Convert.ToChar(ddl_voucher.SelectedValue), Convert.ToDouble(txt_cstamt.Text), Convert.ToDouble(txt_Tamount.Text), Convert.ToDouble(txt_tds.Text), Convert.ToDouble(Txt_TdsPercentage.Text), Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginEmpID"].ToString()));
            //Finance Transfer
            logix.CommanClass.TallyEDIFA.Fn_FATransfer(ddl_voucher.SelectedItem.Text, Convert.ToInt32(txt_VoucherNo.Text), Convert.ToInt32(txt_VoucherNo.Text), "Vessel/Voyage/Container", "BL No", int.Parse(Session["LoginBranchid"].ToString()));
            //Send mail to TDS Existing % to New %
            sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>TDS Existing to New % has Changed </B></FONT></td></tr></table>";
            sendqry = sendqry + "<table><tr><td align=left>Dear Sir / Madam</td></tr>";
            sendqry = sendqry + "<table><tr><td align=left>The below " + ddl_voucher.SelectedItem.Text + " #  " + Convert.ToInt32(txt_VoucherNo.Text) + " Tds existing :: " + Convert.ToDouble(Txt_TdsPercentage.Text).ToString("#,0.00") + "% has changed into new " + Convert.ToDouble(txt_tds.Text).ToString("#,0.00") + "%. </td></tr>";
            sendqry = sendqry + "<table><tr><td align=left> Changed TDS % Employee Name ::" + Session["LoginEmpName"].ToString() + " Customer Name :: " + txt_Customer.Text + ".</td></tr></table><br><br><br>";
            sendqry = sendqry + "</table><table width=100% text=black><tr><td align=left>Thanks & Regards </td></tr><tr><td align=left></td></tr></table><br><br><br>";
            Utility.SendMailnew("", "", "TDS Removal for Existing to New %", sendqry, "", "", "", "");

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Update", "alertify.alert('TDS has Updated " + txt_tds.Text + "% instead of " + Txt_TdsPercentage.Text + "%');", true);
            //Insert to Log
            if (Convert.ToInt32(Session["LoginBranchid"].ToString()) == 5)
            {
                Log_Obj.InsLogDetail(EmpId, 1951, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Vou #" + txt_VoucherNo.Text + "voutype " + ddl_voucher.SelectedValue.ToString() + "Existing TDS" + Txt_TdsPercentage.Text + " % New TDS" + txt_tds.Text + "% /Update");
            }
            else
            {
                Log_Obj.InsLogDetail(EmpId, 1950, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Vou #" + txt_VoucherNo.Text + "voutype " + ddl_voucher.SelectedValue.ToString() + "Existing TDS" + Txt_TdsPercentage.Text + " % New TDS" + txt_tds.Text + "% /Update");
            }
            return;
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
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1950, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1951, "", "", "", Session["StrTranType"].ToString());
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