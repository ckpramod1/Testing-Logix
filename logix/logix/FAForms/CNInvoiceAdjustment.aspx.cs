using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace logix.FAForm
{
    public partial class CNInvoiceAdjustment : System.Web.UI.Page
    {
        bool blnerr = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                txt_year.Text = Session["Vouyear"].ToString();
                Grd_detail.DataSource = new DataTable();
                Grd_detail.DataBind();
                txt_receipt.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
            }
        }

        private void Fn_Getdetail()
        {
            try
            {
                int int_Custid = 0;
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                char char_Mode;
                double Amount = 0;
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();

                if (ddl_voucher.SelectedItem.Text != "Voucher Type" && txt_receipt.Text.ToString().Trim().Length > 0 && txt_year.Text.ToString().Trim().Length > 0)
                {
                    char_Mode = char.Parse(ddl_voucher.SelectedValue.ToString());
                    obj_dt = obj_da_Receipt.GetCNDetails4Adjus(int.Parse(txt_receipt.Text), int.Parse(txt_year.Text), int_bid, char_Mode);
                    if (obj_dt.Rows.Count > 0)
                    {
                        int_Custid = int.Parse(obj_dt.Rows[0][2].ToString());
                        Amount = double.Parse(obj_dt.Rows[0][1].ToString());
                        hid_amount.Value = string.Format("{0:##,000.00}", Amount);
                        hid_customerid.Value = int_Custid.ToString();
                        txt_amount.Text = string.Format("{0:##,000.00}", Amount);
                        txt_received.Text = obj_dt.Rows[0][3].ToString();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CNInvoice", "alertify.alert('Invalid " + lbl_receipt.Text + "');", true);
                        Fn_Clear();
                        return;
                    }
                    //obj_dt = obj_da_Receipt.GetInvRecptDtls(int_Custid, int_divisionid);
                        obj_dt = obj_da_Receipt.GetInvRecptDtlsAdj(int_Custid, int_divisionid);
                    DataTable obj_dtAccount = new DataTable();
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("tds");
                    DataRow dr;

                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtAccount.NewRow();
                        obj_dtAccount.Rows.Add(dr);

                        dr[0] = obj_dt.Rows[i][0].ToString();
                        dr[1] = obj_dt.Rows[i][1].ToString();
                        
                            if (obj_dt.Rows[i][5].ToString() == "I")
                            {
                                dr[2] = "Inv - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString() == "D")
                            {
                                dr[2] = "OSDN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString() == "V")
                            {
                                dr[2] = "DN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString() == "X")
                            {
                                dr[2] = "ADN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString() == "P")
                            {
                                dr[2] = "CNOps - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString() == "C")
                            {
                                dr[2] = "OSCN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString() == "E")
                            {
                                dr[2] = "CN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString() == "S")
                            {
                                dr[2] = "ACN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString() == "B")
                            {
                                dr[2] = "BOS - " + obj_dt.Rows[i][2].ToString();
                            }
                        
                        
                        dr[3] = obj_dt.Rows[i][3].ToString();
                        dr[4] = obj_dt.Rows[i][4].ToString();
                        dr[5] = obj_dt.Rows[i][5].ToString();
                        dr[6] = obj_dt.Rows[i][2].ToString();
                        dr[7] = obj_dt.Rows[i][6].ToString();
                       
                    }

                    obj_dt = obj_da_Receipt.GetInvRecptDtls1(int_Custid, int_divisionid);
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtAccount.NewRow();
                        obj_dtAccount.Rows.Add(dr);

                        dr[0] = obj_dt.Rows[i][0].ToString();
                        dr[1] = obj_dt.Rows[i][1].ToString();
                        dr[2] = "Inv - " + obj_dt.Rows[i][2].ToString();
                        dr[3] = obj_dt.Rows[i][3].ToString();
                        dr[4] = obj_dt.Rows[i][4].ToString();
                        dr[5] = obj_dt.Rows[i][5].ToString();
                        dr[6] = obj_dt.Rows[i][2].ToString();
                        dr[7] = obj_dt.Rows[i][6].ToString();
                    }

                    obj_dt = obj_da_Receipt.GetDN(int_Custid, int_divisionid);
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtAccount.NewRow();
                        obj_dtAccount.Rows.Add(dr);

                        dr[0] = obj_dt.Rows[i][0].ToString();
                        dr[1] = obj_dt.Rows[i][1].ToString();
                        dr[2] = "DN - " + obj_dt.Rows[i][2].ToString();
                        dr[3] = obj_dt.Rows[i][3].ToString();
                        dr[4] = obj_dt.Rows[i][4].ToString();
                        dr[5] = obj_dt.Rows[i][5].ToString();
                        dr[6] = obj_dt.Rows[i][2].ToString();
                        dr[7] = obj_dt.Rows[i][6].ToString();
                    }
                    obj_dt = obj_da_Receipt.GetAdminDN(int_Custid, int_divisionid);
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtAccount.NewRow();
                        obj_dtAccount.Rows.Add(dr);

                        dr[0] = obj_dt.Rows[i][0].ToString();
                        dr[1] = obj_dt.Rows[i][1].ToString();
                        dr[2] = "ADN - " + obj_dt.Rows[i][2].ToString();
                        dr[3] = obj_dt.Rows[i][3].ToString();
                        dr[4] = obj_dt.Rows[i][4].ToString();
                        dr[5] = obj_dt.Rows[i][5].ToString();
                        dr[6] = obj_dt.Rows[i][2].ToString();
                        dr[7] = obj_dt.Rows[i][6].ToString();
                    }

                    //Ruban add for bos
                    obj_dt = obj_da_Receipt.GetInvRecptDtls1BOS(int_Custid, int_divisionid);
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtAccount.NewRow();
                        obj_dtAccount.Rows.Add(dr);

                        dr[0] = obj_dt.Rows[i][0].ToString();
                        dr[1] = obj_dt.Rows[i][1].ToString();
                        dr[2] = "BOS - " + obj_dt.Rows[i][2].ToString();
                        dr[3] = obj_dt.Rows[i][3].ToString();
                        dr[4] = obj_dt.Rows[i][4].ToString();
                        dr[5] = obj_dt.Rows[i][5].ToString();
                        dr[6] = obj_dt.Rows[i][2].ToString();
                        dr[7] = obj_dt.Rows[i][6].ToString();
                    }

                    Grd_detail.DataSource = obj_dtAccount;
                    Grd_detail.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CNInvoice", "alertify.alert('Invalid " + lbl_receipt.Text + "');", true);
                        Fn_Clear();
                        return;
                    }
               // }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
           
        private void Fn_Clear()
        {
            txt_amount.Text = "";
            ddl_voucher.SelectedIndex = 0;
            txt_receipt.Text = "";
            txt_year.Text = Session["Vouyear"].ToString();
            txt_received.Text = "";
            txt_tdsamount.Text = "";
            Grd_detail.DataSource = new DataTable();
            Grd_detail.DataBind();
            lbl_receipt.Text = "Vou #";
            txt_receipt.ToolTip = "Vou #";
            txt_receipt.Attributes.Add("placeholder", "Vou #");
        }

        protected void ddl_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_voucher.SelectedValue.ToString() == "E")
            {
                lbl_receipt.Text = "Vou #";
                txt_receipt.ToolTip = "Vou #";
                txt_receipt.Attributes.Add("placeholder", "Vou #");
            }
            else if (ddl_voucher.SelectedValue.ToString() == "P")
            {
                lbl_receipt.Text = "Vou #";
                txt_receipt.ToolTip = "Vou #";
                txt_receipt.Attributes.Add("placeholder", "Vou #");
            }
        }

        protected void txt_receipt_TextChanged(object sender, EventArgs e)
        {
            Fn_Getdetail();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
               btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
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
       
        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                double VouAmt = 0, actamount = 0, Cust_Amount = 0;
                DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();

                CheckData();

                if (blnerr == true)
                {
                    blnerr = false;
                    return;
                }


                if (hid_Vouamount.Value == "")
                {
                    hid_Vouamount.Value = "0";
                }
                if (hid_amount.Value == "")
                {
                    hid_amount.Value = "0";
                }


                VouAmt = Convert.ToDouble(hid_Vouamount.Value);
                Cust_Amount = Convert.ToDouble(hid_amount.Value);
                if (VouAmt == 0.00)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CNInvoice", "alertify.alert('There is no voucher adjusted against - " + ddl_voucher.SelectedItem.Text + " #" + txt_receipt.Text + " ');", true);
                    return;
                }


                if (VouAmt > Cust_Amount)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CNInvoice", "alertify.alert('" + ddl_voucher.SelectedItem.Text + " Amount does not Match with VoucherDetails Amount');", true);
                    return;
                }

                if (VouAmt == Cust_Amount)
                {
                    obj_da_Receipt.InsRecptAginstInv(-5, 'C', int.Parse(txt_receipt.Text), char.Parse(ddl_voucher.SelectedValue.ToString()), int_bid, Cust_Amount, Cust_Amount, 'Y', int.Parse(txt_year.Text));
                }
                else
                {
                    obj_da_Receipt.InsRecptAginstInv(-5, 'C', int.Parse(txt_receipt.Text), char.Parse(ddl_voucher.SelectedValue.ToString()), int_bid, Cust_Amount, VouAmt, 'N', int.Parse(txt_year.Text));
                }

                char Setteled, vtype;
                int int_branchid = 0, int_invoiceno = 0, int_Ryear = 0;
                double VoucherAmount = 0, Adjust_Amount = 0;

                foreach (GridViewRow row in Grd_detail.Rows)
                {
                    TextBox Txt = (TextBox)row.FindControl("txt_receiptamount");
                    Adjust_Amount = double.Parse(Txt.Text.ToString());

                    if (Adjust_Amount > 0)
                    {
                        int_branchid = int.Parse(Grd_detail.DataKeys[row.RowIndex].Values[0].ToString());
                        vtype = Convert.ToChar(Grd_detail.DataKeys[row.RowIndex].Values[1].ToString());
                        int_invoiceno = int.Parse(Grd_detail.DataKeys[row.RowIndex].Values[2].ToString());
                        int_Ryear = int.Parse(Grd_detail.DataKeys[row.RowIndex].Values[3].ToString());

                        VoucherAmount = double.Parse(Grd_detail.Rows[row.RowIndex].Cells[2].Text.ToString());

                        if (VoucherAmount > Adjust_Amount)
                        {
                            Setteled = 'N';
                        }
                        else
                        {
                            Setteled = 'Y';
                        }
                        obj_da_Receipt.InsRecptAginstInv(-5, 'C', int_invoiceno, vtype, int_branchid, VoucherAmount, Adjust_Amount, Setteled, int_Ryear);
                        obj_da_Receipt.InsRecptAginstVou(ddl_voucher.SelectedValue.ToString(), int.Parse(txt_receipt.Text), int.Parse(txt_year.Text), double.Parse(txt_amount.Text), int_bid, vtype.ToString(), int_invoiceno, int_Ryear, VoucherAmount, Adjust_Amount, int_branchid);

                        try
                        {
                            obj_da_Approval.UpdLedgerOPBreakup(int_invoiceno, vtype, int_Ryear, int_branchid, -5, 'C', int.Parse(txt_year.Text), Adjust_Amount, "", 0.00, "", "");
                        }
                        catch (Exception Ex)
                        {
                        }
                    }
                }

                //upd CN dtls
                if (ddl_voucher.SelectedItem.Text == "Credit Note - Operations")
                {
                    obj_da_Approval.UpdLedgerOPBreakup(int.Parse(txt_receipt.Text), 'P', int.Parse(txt_year.Text), int_bid, -5, 'C', int.Parse(txt_year.Text), Adjust_Amount, "", 0.0, "", "");
                }
                else if (ddl_voucher.SelectedItem.Text == "Credit Note")
                {
                    obj_da_Approval.UpdLedgerOPBreakup(int.Parse(txt_receipt.Text), 'E', int.Parse(txt_year.Text), int_bid, -5, 'C', int.Parse(txt_year.Text), Adjust_Amount, "", 0.0, "", "");
                }

                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1168, 1, int_bid, ddl_voucher.SelectedItem.Text + " - " + txt_receipt.Text);
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CNInvoice", "alertify.alert('Voucher Amount Adjusted Against" + ddl_voucher.SelectedItem.Text + " # - " + txt_receipt.Text + "');", true);
                Fn_Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void CheckData()
        {
            if (ddl_voucher.SelectedItem.Text == "Voucher Type")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select the Voucher Type')", true);             
                ddl_voucher.Focus();
                blnerr = true;
                return;
            }

            if (txt_receipt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter the " + lbl_receipt.Text + "');", true);
                txt_receipt.Text = "";
                txt_receipt.Focus();
                blnerr = true;
                return;
            }
        }

        protected void txt_receiptamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double VouAmt = 0, actamount = 0, GrdAmnt = 0.00;

                foreach (GridViewRow row in Grd_detail.Rows)
                {
                    TextBox Txt = (TextBox)row.FindControl("txt_receiptamount");
                    if (double.Parse(Txt.Text.ToString()) != 0)
                    {
                        VouAmt = VouAmt + double.Parse(Txt.Text);
                    }
                }

                hid_Vouamount.Value = VouAmt.ToString();

                foreach (GridViewRow row in Grd_detail.Rows)
                {
                    TextBox Txt = (TextBox)row.FindControl("txt_receiptamount");
                    if (double.Parse(Txt.Text.ToString()) != 0.00)
                    {
                        actamount = actamount + double.Parse(Grd_detail.Rows[row.RowIndex].Cells[2].Text.ToString());
                    }
                }

                int RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
                TextBox TxtAmount = ((TextBox)Grd_detail.Rows[RowIndex].FindControl("txt_receiptamount"));

                if (Grd_detail.Rows[RowIndex].Cells[2].Text.ToString() != null)
                {
                    if (double.TryParse(Grd_detail.Rows[RowIndex].Cells[2].Text.ToString(), out GrdAmnt))
                    {
                        if (Convert.ToDouble(Grd_detail.Rows[RowIndex].Cells[2].Text.ToString()) < Convert.ToDouble(TxtAmount.Text))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Adjustment Amount should not be greater than Voucher Amount')", true);
                            TxtAmount.Text = "0.00";
                            return;
                        }
                    }
                }

                double Total = 0;
                foreach (GridViewRow totalrow in Grd_detail.Rows)
                {
                    TextBox Txt = (TextBox)totalrow.FindControl("txt_receiptamount");
                    Total = Total + double.Parse(Txt.Text);
                }

                txt_tdsamount.Text = string.Format("{0:0.00}", Total);
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
            Panel4.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        
       obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1168, "", "", "", Session["StrTranType"].ToString());
          

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void Grd_detail_PreRender(object sender, EventArgs e)
        {
            if (Grd_detail.Rows.Count > 0)
            {
                Grd_detail.UseAccessibleHeader = true;
                Grd_detail.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


    }
}

      