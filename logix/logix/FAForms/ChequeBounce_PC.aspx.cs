using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForm
{
    public partial class ChequeBounce_PC : System.Web.UI.Page
    {
        DataAccess.Masters.MasterPort portObj = new DataAccess.Masters.MasterPort();
        DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.HR.Employee Obj_da_HREmp = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
        DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
        DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
        DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.Journal obj_da_journal = new DataAccess.Accounts.Journal();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable obj_dt = new DataTable();
        DataTable obj_dttemp = new DataTable();

        int Division_ID;
        bool blrr;
        int VouYear, ALogYear, voutypeid;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                portObj.GetDataBase(Ccode);
                obj_da_Receipt.GetDataBase(Ccode);
                obj_da_Payment.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                Obj_da_HREmp.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                obj_da_Emp.GetDataBase(Ccode);


                obj_da_FA.GetDataBase(Ccode);
                obj_da_Division.GetDataBase(Ccode);
                obj_da_Ledger.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                obj_da_Charge.GetDataBase(Ccode);
                obj_da_OSDN.GetDataBase(Ccode);
                obj_da_Branch.GetDataBase(Ccode);
                obj_da_journal.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            //Branch_ID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            Division_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_Header.Text = Request.QueryString["FormName"].ToString();
            }

            VouYear = Convert.ToInt32(HttpContext.Current.Session["Vouyear"].ToString());
            ALogYear = Convert.ToInt32(Session["Alogyear"].ToString());

            if (lbl_Header.Text == "Cheque Bounce")
            {
                hid_type.Value = "R";
            }
            else
            {
                hid_type.Value = "P";
                btn_confirm.Text = "Delete";
                btn_confirm.ToolTip = "Delete";
                btn_confirm1.Attributes["class"] = "btn ico-delete";

                btn_confirm.ForeColor = System.Drawing.Color.Gray;
                txt_receipt.ToolTip = "Payment Number";
                txt_receipt.Attributes.Add("placeholder", "Payment #");
                txt_received.ToolTip = "Favouring";
                txt_received.Attributes.Add("placeholder", "Favouring");
                txt_refno.ToolTip = "Branch";
                txt_refno.Attributes.Add("placeholder", "Branch");
            }

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                Grd_detail.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_detail.DataBind();
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txt_cheque.Focus();
                FillBranch();
            }

            if (txt_cheque.Text != "" || txt_receipt.Text != "" || txt_Vouyear.Text != "")
            {
                if (Session["obj_dt"] != null)
                {
                    obj_dt = Session["obj_dt"] as DataTable;

                    if (hid_year.Value != "")
                    {
                        if (hid_year.Value == Session["Vouyear"].ToString())
                        {
                            btn_confirm.Attributes.Add("OnClick", "if(confirm('Do You Want To Bounce the Cheque ?')){ document.getElementById('logix_CPH_hid_AlertMsg').value = 'Y';}else{ document.getElementById('logix_CPH_hid_AlertMsg').value = 'N';}");
                        }
                        else
                        {
                            btn_confirm.Attributes.Add("OnClick", "if(confirm('Do You Want To Bounce the Previous Financial Year Cheque ?')){ document.getElementById('logix_CPH_hid_AlertMsg').value = 'Y';}else{ document.getElementById('logix_CPH_hid_AlertMsg').value = 'N';}");
                        }
                    }
                }
            }
        }

        protected void FillBranch()
        {
            DataTable dt_Branch = new DataTable();
            dt_Branch = portObj.GetAllBranchNameforPortName();
            ddl_branch.Items.Add("ALL");
            for (int i = 0; i <= dt_Branch.Rows.Count - 1; i++)
            {
                ddl_branch.Items.Add(dt_Branch.Rows[i]["portname"].ToString());
            }
        }

        protected void fn_getdetails_sub()
        {
            int Branch_ID = Obj_da_HREmp.GetBranchId(Division_ID, ddl_branch.SelectedItem.Text);

            if (hid_type.Value == "R")
            {
                if (txt_cheque.Text != "" && txt_receipt.Text != "")
                {
                    if (txt_Vouyear.Text != "")
                    {
                        obj_dt = obj_da_Receipt.SelRecHeadChqRecno(txt_cheque.Text, Branch_ID, Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_Vouyear.Text));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter Vouyear')", true);
                        blrr = true;
                        return;
                    }
                }

                if (txt_cheque.Text != "" && txt_receipt.Text == "" && txt_Vouyear.Text == "")
                {
                    obj_dt = obj_da_Receipt.SelRecHeadByChq(txt_cheque.Text, Branch_ID);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_receipt.Text = obj_dt.Rows[0]["receiptno"].ToString().Trim();
                        txt_Vouyear.Text = obj_dt.Rows[0]["vouyear"].ToString();
                    }
                }

                if (txt_cheque.Text == "" && txt_receipt.Text != "")
                {
                    if (txt_Vouyear.Text != "")
                    {
                        obj_dt = obj_da_Receipt.SelRecHeadRecno(Branch_ID, Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_Vouyear.Text));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter Vouyear')", true);
                        blrr = true;
                        return;
                    }
                }
            }
            else
            {
                //Branch_ID = Obj_da_HREmp.GetBranchId(Division_ID, ddl_branch.SelectedItem.Text);
                if (txt_cheque.Text != "" && txt_receipt.Text != "")
                {
                    if (txt_Vouyear.Text != "")
                    {
                        obj_dt = obj_da_Payment.SelPymtHeadChqPymtno(txt_cheque.Text, "PymtCancel", Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_Vouyear.Text), Branch_ID);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter Vouyear')", true);
                        blrr = true;
                        return;
                    }
                }

                if (txt_cheque.Text != "" && txt_receipt.Text == "" && txt_Vouyear.Text == "")
                {
                    obj_dt = obj_da_Payment.SelPymtHeadByChq(txt_cheque.Text.ToUpper(), "PymtCancel");
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_receipt.Text = obj_dt.Rows[0]["paymentno"].ToString().Trim();
                        txt_Vouyear.Text = obj_dt.Rows[0]["vouyear"].ToString();
                    }
                }

                if (txt_cheque.Text == "" && txt_receipt.Text != "")
                {
                    if (txt_Vouyear.Text != "")
                    {
                        obj_dt = obj_da_Payment.SelPymtHeadPymtno("PymtCancel", Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_Vouyear.Text), Branch_ID);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter Vouyear')", true);
                        blrr = true;
                        return;
                    }
                }
            }
        }

        private void Fn_Getdetail()
        {
            try
            {
                int int_Rid = 0;
                blrr = false;
                fn_getdetails_sub();

                if (blrr == true)
                {
                    return;
                }
                if (obj_dt.Rows.Count > 0)
                {
                    hid_receiptid.Value = obj_dt.Rows[0][0].ToString();
                    int_Rid = Convert.ToInt32(hid_receiptid.Value.ToString());
                    hid_receiptno.Value = obj_dt.Rows[0][1].ToString();
                    hid_date.Value = obj_dt.Rows[0][2].ToString();
                    hid_year.Value = obj_dt.Rows[0][4].ToString();

                    txt_Vouyear.Text = obj_dt.Rows[0][4].ToString();
                    txt_receipt.Text = obj_dt.Rows[0][1].ToString();

                    if (hid_type.Value.ToString() == "R")
                    {
                        hid_customerid.Value = obj_dt.Rows[0][5].ToString();
                        txt_received.Text = obj_da_Customer.GetCustomername(int.Parse(hid_customerid.Value.ToString()));
                    }
                    else
                    {
                        txt_refno.Text = obj_dt.Rows[0][3].ToString();
                        txt_received.Text = obj_dt.Rows[0][5].ToString();
                        hid_Chkbranchid.Value = obj_dt.Rows[0]["branchid"].ToString();
                    }

                    txt_amount.Text = string.Format("{0:0.00}", obj_dt.Rows[0][6].ToString());
                    hid_amount.Value = txt_amount.Text;
                    hid_bankid.Value = obj_dt.Rows[0][7].ToString();
                    hid_Branch.Value = obj_dt.Rows[0][8].ToString();
                    hid_chequedate.Value = obj_dt.Rows[0][9].ToString();

                    obj_dttemp = obj_da_Receipt.GetRAInvoiceToShow(int_Rid, char.Parse(hid_type.Value.ToString()));
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        DataTable obj_dtAccount = new DataTable();
                        obj_dtAccount.Columns.Add("branch");
                        obj_dtAccount.Columns.Add("port");
                        obj_dtAccount.Columns.Add("invoiceno");
                        obj_dtAccount.Columns.Add("iamount");
                        obj_dtAccount.Columns.Add("ramount");

                        DataRow dr;

                        for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            dr = obj_dtAccount.NewRow();
                            obj_dtAccount.Rows.Add(dr);
                            dr[0] = obj_dttemp.Rows[i][0].ToString();
                            dr[1] = obj_dttemp.Rows[i][1].ToString();
                            if (obj_dttemp.Rows[i][1].ToString().Trim() != "0")
                            {
                                if (obj_dttemp.Rows[i][5].ToString().Trim() == "I")
                                {
                                    dr[2] = "Inv - " + obj_dttemp.Rows[i][2].ToString();
                                }
                                else if (obj_dttemp.Rows[i][5].ToString().Trim() == "D")
                                {
                                    dr[2] = "OSDN - " + obj_dttemp.Rows[i][2].ToString();
                                }
                                else if (obj_dttemp.Rows[i][5].ToString().Trim() == "V")
                                {
                                    dr[2] = "DN - " + obj_dttemp.Rows[i][2].ToString();
                                }
                                else if (obj_dttemp.Rows[i][5].ToString().Trim() == "P")
                                {
                                    dr[2] = "CNOps - " + obj_dttemp.Rows[i][2].ToString();
                                }
                                else if (obj_dttemp.Rows[i][5].ToString().Trim() == "C")
                                {
                                    dr[2] = "OSCN - " + obj_dttemp.Rows[i][2].ToString();
                                }
                                else if (obj_dttemp.Rows[i][5].ToString().Trim() == "E")
                                {
                                    dr[2] = "CN - " + obj_dttemp.Rows[i][2].ToString();
                                }
                                else if (obj_dttemp.Rows[i][5].ToString().Trim() == "B")
                                {
                                    dr[2] = "BOS - " + obj_dttemp.Rows[i][2].ToString();
                                }

                                dr[3] = obj_dttemp.Rows[i][3].ToString();
                                dr[4] = obj_dttemp.Rows[i][4].ToString();
                            }
                            else
                            {
                                dr[2] = "On Account";
                            }
                        }
                        btn_confirm.Enabled = true;
                        btn_confirm.ForeColor = System.Drawing.Color.White;
                        Grd_detail.DataSource = obj_dtAccount;
                        Grd_detail.DataBind();

                        Session["obj_dt"] = obj_dtAccount;
                    }
                    else
                    {
                        if (hid_type.Value == "P")
                        {
                            btn_confirm.Enabled = true;
                        }
                        else
                        {
                            btn_confirm.Enabled = false;
                        }
                    }

                    if (hid_type.Value.ToString() == "R")
                    {
                        obj_dttemp = obj_da_Receipt.GetRecptCust(int_Rid);
                    }
                    else
                    {
                        obj_dttemp = obj_da_Payment.GetPaymentCust(int_Rid);
                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_customer.Text = obj_dttemp.Rows[0][0].ToString();
                        txt_customeramount.Text = string.Format("{0:0.00}", obj_dttemp.Rows[0][1].ToString());
                        hid_CAmount.Value = txt_customeramount.Text;
                    }
                    if (hid_type.Value.ToString() == "R")
                    {
                        obj_dttemp = obj_da_Receipt.GetRecptChrg(int_Rid);
                    }
                    else
                    {
                        obj_dttemp = obj_da_Payment.GetPaymentChrg(int_Rid);
                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_deduction.Text = obj_dttemp.Rows[0][0].ToString();
                        txt_deductionamount.Text = string.Format("{0:0.00}", obj_dttemp.Rows[0][1].ToString());
                        hid_DAmount.Value = txt_deductionamount.Text;
                    }

                    if (hid_type.Value.ToString() == "R")
                    {
                        obj_dttemp = obj_da_Receipt.GetES(int_Rid);
                    }
                    else
                    {
                        obj_dttemp = obj_da_Payment.GetPaymentES(int_Rid);
                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_shortamount.Text = string.Format("{0:0.00}", obj_dttemp.Rows[0][0].ToString());
                        hid_SAmount.Value = txt_shortamount.Text;
                    }
                    double Amount = double.Parse(hid_CAmount.Value.ToString()) + double.Parse(hid_DAmount.Value.ToString()) + double.Parse(hid_SAmount.Value.ToString());
                    txt_total.Text = string.Format("{0:0.00}", Amount);
                    hid_Total.Value = string.Format("{0:#,##0.00}", txt_total.Text);
                }
                else
                {
                    Fn_Clear();
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "ChequeBonus", "alertify.alert('Invalid Cheque #');", true);
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

        protected void txt_cheque_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_cheque.Text.ToString().Trim().Length > 0)
                {
                    Fn_Getdetail();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        private void Fn_Clear()
        {
            txt_Vouyear.Text = "";
            txt_amount.Text = "";
            txt_cheque.Text = "";
            txt_customer.Text = "";
            txt_customeramount.Text = "";
            txt_deduction.Text = "";
            txt_deductionamount.Text = "";
            txt_receipt.Text = "";
            txt_received.Text = "";
            txt_refno.Text = "";
            txt_shortamount.Text = "";
            txt_total.Text = "";
            hid_CAmount.Value = "0";
            hid_DAmount.Value = "0";
            hid_SAmount.Value = "0";
            hid_Total.Value = "0";
            hid_amount.Value = "0";
            btn_confirm.Enabled = false;
            btn_confirm.ForeColor = System.Drawing.Color.Gray;
            Grd_detail.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_detail.DataBind();
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                txt_cheque.Focus();
                Fn_Clear();
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

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int Branch_ID = Obj_da_HREmp.GetBranchId(Division_ID, ddl_branch.SelectedItem.Text);

                DataTable obj_dt = new DataTable();
                int int_rceiptid = int.Parse(hid_receiptid.Value.ToString());
                int logCorpID;

                if (hid_AlertMsg.Value == "N")
                {
                    ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Not Bounced');", true);
                    return;
                }

                if (hid_type.Value.ToString() == "R")
                {
                    if (txt_refno.Text != "")
                    {
                        obj_dt = obj_da_Receipt.GetSlipDetails4ReversalBr(int_rceiptid);
                        if (obj_dt.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Cannot Cancel the Receipt before put Deposit Slip');", true);
                            return;
                        }

                        logCorpID = Obj_da_HREmp.GetBranchId(Division_ID, "CORPORATE");

                        if (logCorpID == Branch_ID)
                        {
                            if (hid_year.Value == Session["A_LogYear"])
                            {
                                obj_da_FA.SPReversalRcptCorpinFA(Branch_ID, Convert.ToInt32(hid_receiptno.Value), 9, logCorpID, txt_refno.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());
                            }
                            else
                            {
                                obj_da_FA.SPReversalRcptCorpinFA4OldChq(Branch_ID, Convert.ToInt32(hid_receiptno.Value), 9, logCorpID, txt_refno.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString(), Convert.ToInt32(txt_Vouyear.Text));
                            }
                        }
                        else
                        {
                            Fn_GetDepositedate(int_rceiptid);
                        }

                        double Amount = Convert.ToDouble(hid_amount.Value.ToString()) * (-1);

                        obj_da_Receipt.InsRecptHeadBank(int.Parse(hid_receiptno.Value.ToString()), DateTime.Parse(Utility.fn_ConvertDate(hid_date.Value.ToString())), 'B', Branch_ID, int.Parse(hid_year.Value.ToString()), int.Parse(hid_customerid.Value.ToString()), Amount, int.Parse(hid_bankid.Value.ToString()), hid_Branch.Value.ToString(), txt_cheque.Text, DateTime.Parse(Utility.fn_ConvertDate(hid_chequedate.Value.ToString())), txt_refno.Text, int.Parse(Session["LoginEmpId"].ToString()));

                        //Update SlipID For Bounce Entry START
                        try
                        {
                            obj_da_Receipt.updSlipIDforBounce(Convert.ToInt32(hid_receiptno.Value.ToString()), "B", Branch_ID, Convert.ToInt32(hid_year.Value));
                        }
                        catch (Exception ex)
                        {

                        }
                        //Update SlipID For Bounce Entry END

                        obj_da_Receipt.InsChqBounce(int_rceiptid, 'R');
                        obj_da_Receipt.DelRecAgInv(int_rceiptid, 'R');
                        obj_da_Receipt.DelRectPmt(int_rceiptid, 'R');

                        if (txt_customer.Text.ToString().Trim().Length > 0 && txt_customeramount.Text.ToString().Trim().Length > 0)
                        {
                            Amount = double.Parse(hid_CAmount.Value.ToString()) * (-1);
                            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                            obj_da_Receipt.InsReciptCustomerDetail(int_rceiptid, obj_da_Customer.GetCustomerid(txt_customer.Text), Amount);
                        }

                        if (txt_deduction.Text.ToString().Trim().Length > 0 && txt_deductionamount.Text.ToString().Trim().Length > 0)
                        {
                            Amount = double.Parse(hid_DAmount.Value.ToString()) * (-1);
                          //  DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
                            obj_da_Receipt.InsReciptChargeDetail(int_rceiptid, obj_da_Charge.GetChargeid(txt_deduction.Text), Amount);
                        }

                        if (txt_shortamount.Text.ToString().Trim().Length > 0)
                        {
                            Amount = double.Parse(hid_SAmount.Value.ToString()) * (-1);
                            obj_da_Receipt.InsReciptChargeDetail(int_rceiptid, 0, Amount);
                        }

                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 581, 1, Branch_ID, "RecID-" + int_rceiptid + "/Amt" + hid_RAmount.Value.ToString());
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 581, 4, Branch_ID, "RecID-" + int_rceiptid + "/Amt" + hid_RAmount.Value.ToString());
                        Fn_Clear();
                        ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Cheque Retutn Confirmed');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Remarks should not be Empty');", true);
                    }
                }
                else
                {
                    int Logcorid = obj_da_Emp.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), "CORPORATE");
                    if (Logcorid == int.Parse(hid_Chkbranchid.Value.ToString()))
                    {
                        voutypeid = 11;

                        if (txt_Vouyear.Text == Session["Alogyear"].ToString())
                        {
                            if (obj_da_FA.CheckFAExists4Voucher4Corp(int.Parse(hid_receiptno.Value.ToString()), Convert.ToInt32(hid_year.Value), int.Parse(hid_Chkbranchid.Value.ToString()), voutypeid, Session["FADbname"].ToString()) == 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Voucher Not Found in FA. Cannot cancel the Payment');", true);
                                return;
                            }
                            obj_da_FA.ReversalPmtinFA(Branch_ID, int.Parse(hid_receiptno.Value.ToString()), 11, 0, txt_refno.Text + "/Reversal for Payment #" + hid_receiptno.Value.ToString(), int.Parse(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());
                        }
                        else
                        {
                            if (obj_da_FA.CheckFAExists4Voucher4Corp(int.Parse(hid_receiptno.Value.ToString()), Convert.ToInt32(hid_year.Value), int.Parse(hid_Chkbranchid.Value.ToString()), voutypeid, Session["FADbname"].ToString()) == 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Voucher Not Found in Previous Financial Year. Cannot cancel the Payment');", true);
                                return;
                            }
                            obj_da_FA.ReversalPmtinFA4OldChq(Branch_ID, int.Parse(hid_receiptno.Value.ToString()), 11, 0, txt_refno.Text + "/Reversal for Payment #" + hid_receiptno.Value.ToString(), int.Parse(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString(), Convert.ToInt32(hid_year.Value));
                        }
                    }
                    else
                    {
                        voutypeid = 103;

                        if (txt_Vouyear.Text == Session["Alogyear"].ToString())
                        {
                            if (obj_da_FA.CheckFAExists4Voucher(int.Parse(hid_receiptno.Value.ToString()), Convert.ToInt32(hid_year.Value), int.Parse(hid_Chkbranchid.Value.ToString()), voutypeid, Session["FADbname"].ToString()) == 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Voucher Not Found in FA. Cannot cancel the Payment');", true);
                                return;
                            }
                            obj_da_FA.ReversalPmtinFA(Branch_ID, int.Parse(hid_receiptno.Value.ToString()), 11, Logcorid, txt_refno.Text + "/Reversal for Payment #" + hid_receiptno.Value.ToString(), int.Parse(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());
                        }
                        else
                        {
                            if (obj_da_FA.CheckFAExists4Voucher(int.Parse(hid_receiptno.Value.ToString()), Convert.ToInt32(hid_year.Value), int.Parse(hid_Chkbranchid.Value.ToString()), voutypeid, Session["FADbname"].ToString()) == 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Voucher Not Found in Previous Financial Year. Cannot cancel the Payment');", true);
                                return;
                            }
                            obj_da_FA.ReversalPmtinFA4OldChq(Branch_ID, int.Parse(hid_receiptno.Value.ToString()), 11, Logcorid, txt_refno.Text + "/Reversal for Payment #" + hid_receiptno.Value.ToString(), int.Parse(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString(), Convert.ToInt32(hid_year.Value));
                        }
                    }

                    obj_da_Receipt.InsChqBounce(int_rceiptid, 'P');
                    obj_da_Receipt.DelRecAgInv(int_rceiptid, 'P');
                    obj_da_Receipt.DelRectPmt(int_rceiptid, 'P');
                    obj_da_Payment.DelCustChrgsPymt(int_rceiptid);
                    obj_da_Payment.UpdPaymentDeleted(int_rceiptid);
                   // obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 643, 2, Branch_ID, "PayID-" + int_rceiptid + "/Amt" + hid_RAmount.Value.ToString());
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1179, 4, Branch_ID, "PayID-" + int_rceiptid + "/Amt" + hid_RAmount.Value.ToString());
                    Fn_Clear();
                    ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Payment Deleted');", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        private void Fn_GetDepositedate(int Rid)
        {
            try
            {
                int int_vouchertypeid = 0, int_Rcount = 0, int_Rvouyear = 0, int_BRJvouno = 0, int_Voucherid = 0, int_Ledgerid = 0;
                string Str_Voucher = "", Str_Chequeno = "", Str_Refno = "", Str_Mode = "B", Str_Narration = "", Str_LedgerName = "", Str_DBname = "";
                double Amount = 0;
                Boolean flag = false;
                //int int_bid = int.Parse(Session["LoginBranchid"].ToString());

                int Branch_ID = Obj_da_HREmp.GetBranchId(Division_ID, ddl_branch.SelectedItem.Text);
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                Str_DBname = Session["FADbname"].ToString();

                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();

                int_vouchertypeid = obj_da_FA.Selvoutypeid("BRRJV", Str_DBname);
                obj_dt = obj_da_Receipt.GetSlipDetails4ReversalBr(Rid);

                string dssldate, dsledgname, dsbname;
                DateTime slipdate;

                if (obj_dt.Rows.Count == 1)
                {
                    int_Rcount = obj_dt.Rows.Count;
                    slipdate = Convert.ToDateTime(Utility.fn_ConvertDate(obj_dt.Rows[int_Rcount]["slipdate"].ToString()));
                    dssldate = slipdate.ToString("yyyyMMdd");

                    if (obj_dt.Rows[0]["mode"].ToString() == "C")
                    {
                        dsledgname = "CASH COLLECTION ACCOUNT";
                        Str_Voucher = obj_dt.Rows[0]["LTtCd"].ToString();
                    }
                    else
                    {
                        dsledgname = "CASH COLLECTION ACCOUNT";
                        dsbname = obj_dt.Rows[0]["bankname"].ToString();
                        dsbname = dsbname.Replace("&", "&amp;");
                        Str_Voucher = obj_dt.Rows[0]["LTtbd"].ToString();
                        Str_Chequeno = obj_dt.Rows[0]["chequeno"].ToString();
                    }

                    Str_Refno = Str_Mode + "R-" + obj_dt.Rows[0]["receiptno"].ToString();
                    Amount = double.Parse(obj_dt.Rows[0]["amount"].ToString());
                    hid_RAmount.Value = Amount.ToString();
                    int_Rvouyear = int.Parse(obj_dt.Rows[0]["vouyear"].ToString());

                    if (flag == true)
                    {
                        Str_Narration = "DEPOSIT SLIP NO. " + obj_dt.Rows[0]["slipno"].ToString();
                    }
                    else
                    {
                        Str_Narration = " CHQ." + Str_Chequeno + "/DEPOSIT SLIP NO. " + obj_dt.Rows[0]["slipno"].ToString();
                    }
                    int_BRJvouno = obj_da_FA.GetBPRRJVNO(Branch_ID, "R");

                    if (int_BRJvouno == 0)
                    {
                        return;
                    }

                    DateTime dtdate = obj_da_Log.GetDate();
                    int_Voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_vouchertypeid, int_BRJvouno.ToString(), dtdate, Str_Narration + "/" + txt_refno.Text + " - Reversal for " + Str_Refno, "AC", 0, 0, Branch_ID, int_divisionid, int_Empid, dtdate, 'N', int_Rvouyear);
                    obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_Voucherid, Str_Refno, 0, "");
                    obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "Cheque", int_Voucherid, Str_Chequeno, 0, "");


                    Str_LedgerName = "CTC ACCOUNT-" + obj_da_Division.GetShortName(int_divisionid) + "-CO";
                    int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgerName, 'O');
                    if (int_Ledgerid == 0)
                    {
                        int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_LedgerName, 26, 1, 'B', 0, 'O', Str_DBname);
                    }

                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", double.Parse(hid_amount.Value.ToString()), int.Parse(hid_year.Value.ToString()), Branch_ID, int_divisionid);

                    obj_dttemp = obj_da_Receipt.GetRecptCust4FA(Rid);
                    for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {
                        string int_Customerid = "";
                        double Cust_Amount = 0;
                        Cust_Amount = double.Parse(obj_dttemp.Rows[i]["amount"].ToString());

                        if (int.Parse(obj_dttemp.Rows[i]["branchid"].ToString()) == Branch_ID)
                        {
                            int_Customerid = obj_dttemp.Rows[i]["Customer"].ToString();
                            int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(int_Customerid), "C", Str_DBname);
                            if (int_Ledgerid == 0)
                            {
                                int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_dttemp.Rows[i]["cc"].ToString(), 1, 1, 'G', int.Parse(obj_dttemp.Rows[i]["Customer"].ToString()), 'C', Str_DBname);
                            }
                        }
                        else
                        {
                            //DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
                            int_Customerid = obj_da_OSDN.GetPortCode(Convert.ToInt32(obj_dttemp.Rows[i]["branchid"].ToString()));
                            Fn_JVFA(Rid, obj_dt, i, Str_Voucher);
                            int_Ledgerid = obj_da_FA.Sellegerid4IntrBr(int_Customerid, 'O', Convert.ToInt32(obj_dttemp.Rows[i]["branchid"].ToString()), Str_DBname);
                            if (int_Ledgerid == 0)
                            {
                                int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(int_Customerid.ToString(), 1, 1, 'G', 0, 'O', Str_DBname);
                            }
                            //Fn_JVFA(Rid, obj_dt, i, Str_Voucher);
                            //DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
                            //int_Customerid = int.Parse(obj_da_OSDN.GetPortCode(int.Parse(obj_dttemp.Rows[i]["branchid"].ToString())).ToString());
                            //int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, int_Customerid.ToString(), 'C');
                            //if (int_Ledgerid == 0)
                            //{
                            //    int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(int_Customerid.ToString(), 1, 1, 'G', 0, 'O', Str_DBname);
                            //}
                        }

                        if (Cust_Amount > 0)
                        {
                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Math.Abs(Cust_Amount), int.Parse(hid_year.Value.ToString()), Branch_ID, int_divisionid);
                        }
                        else if (Cust_Amount < 0)
                        {
                            if (int_Rcount == 1)
                            {
                                obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Math.Abs(Cust_Amount), int.Parse(hid_year.Value.ToString()), Branch_ID, int_divisionid);
                            }
                        }
                    }

                    obj_dttemp = obj_da_Receipt.GetRecptChrg(Rid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            double Cust_Amount = 0;
                            Cust_Amount = double.Parse(obj_dttemp.Rows[i]["amount"].ToString());
                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TAX DEDUCTED AT SOURCE RECEIVABLE", 'O');
                            if (Cust_Amount < 0)
                            {
                                obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Math.Abs(Cust_Amount), int.Parse(hid_year.Value.ToString()), Branch_ID, int_divisionid);
                            }
                        }
                    }

                    if (int_Rcount > 1)
                    {
                        obj_dttemp = obj_da_FA.GetFAES(Rid);
                    }
                    else
                    {
                        obj_dttemp = obj_da_Receipt.GetES(Rid);
                    }

                    if (obj_dttemp.Rows.Count > 0)
                    {
                        for (int i = 0; i <= obj_dttemp.Rows.Count - 1; )
                        {
                            string str_type = "";
                            double Cust_Amount = 0;
                            Cust_Amount = double.Parse(obj_dttemp.Rows[i]["amount"].ToString());
                            if (Cust_Amount < 0)
                            {
                                str_type = "Cr";
                            }
                            else if (Cust_Amount >= 0)
                            {
                                str_type = "Dr";
                            }
                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "EXCESS / SHORT", 'O');
                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, str_type, Math.Abs(Cust_Amount), int.Parse(hid_year.Value.ToString()), Branch_ID, int_divisionid);
                            break;
                        }
                    }
                    Fn_GetDepositedate_Corporate(Rid);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_GetDepositedate_Corporate(int Rid)
        {
            try
            {
                int int_vouchertypeid = 0, int_Rcount = 0, int_Rvouyear = 0, int_BRJvouno = 0, int_Voucherid = 0, int_Ledgerid = 0, int_LogCorid = 0;
                string Str_Bankname = "", Str_Chequeno = "", Str_Refno = "", Str_Mode = "B", Str_Narration = "", Str_LedgerName = "", Str_DBname = "";
                double Amount = 0;
                Boolean flag = false;
                //int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int Branch_ID = Obj_da_HREmp.GetBranchId(Division_ID, ddl_branch.SelectedItem.Text);
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                Str_DBname = Session["FADbname"].ToString();
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();

                int_LogCorid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
                obj_dt = obj_da_Receipt.GetSlipDetails4ReversalCo(Rid);
                int_vouchertypeid = obj_da_FA.Selvoutypeid("BRRJV", Str_DBname);

                DateTime slipdate, ChequeDate;
                string dssldate, chqdate, recbank;

                if (obj_dt.Rows.Count == 1)
                {
                    slipdate = Convert.ToDateTime(obj_dt.Rows[0]["mode"].ToString());
                    dssldate = slipdate.ToString("yyyyMMdd");

                    int_Rcount = obj_dt.Rows.Count;
                    if (obj_dt.Rows[0]["mode"].ToString() == "C")
                    {
                        Str_Bankname = obj_dt.Rows[0]["bankname"].ToString().Replace("&", "&amp");
                    }
                    else
                    {
                        Str_Bankname = obj_dt.Rows[0]["bankname"].ToString().Replace("&", "&amp");
                        Str_Chequeno = obj_dt.Rows[0]["chequeno"].ToString();
                        ChequeDate = Convert.ToDateTime(obj_dt.Rows[0]["chequedate"].ToString().Replace("&", "&amp"));
                        chqdate = ChequeDate.ToString("dd-MMM-yyyy");
                        recbank = obj_dt.Rows[0]["recbankname"].ToString().Replace("&", "&amp");
                    }
                    //DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
                    string Str_Shortname = obj_da_Branch.GetShortName(Branch_ID);
                    Str_Refno = Str_Shortname + "/BR-" + obj_dt.Rows[0]["receiptno"].ToString() + "/" + obj_dt.Rows[0]["vouyear"].ToString();
                    Amount = double.Parse(obj_dt.Rows[0]["amount"].ToString());
                    int_Rvouyear = int.Parse(obj_dt.Rows[0]["vouyear"].ToString());
                    Str_LedgerName = "CTC ACCOUNT-" + Str_Shortname;

                    if (flag == true)
                    {
                        Str_Narration = "DEPOSIT SLIP NO. " + obj_dt.Rows[0]["slipno"].ToString();
                    }
                    else
                    {
                        Str_Narration = " CHQ." + Str_Chequeno + "/DEPOSIT SLIP NO. " + obj_dt.Rows[0]["slipno"].ToString();
                    }
                    int_BRJvouno = obj_da_FA.GetBPRRJVNO(int_LogCorid, "R");

                    if (int_BRJvouno == 0)
                    {
                        return;
                    }
                    if (obj_da_FA.CheckFAExists4Voucher4CorpJV(int_BRJvouno, int.Parse(Session["Vouyear"].ToString()), Branch_ID, int_vouchertypeid, int_LogCorid, Str_DBname) != 0)
                    {
                        return;
                    }

                    DateTime dtdate = obj_da_Log.GetDate();
                    int_Voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_vouchertypeid, int_BRJvouno.ToString(), dtdate, Str_Narration + "/Reversal For BR-" + obj_dt.Rows[0]["receiptno"].ToString(), "AC", 0, 0, int_LogCorid, int_divisionid, int_Empid, dtdate, 'N', int_Rvouyear);
                    obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_Voucherid, Str_Refno, 0, "");
                    obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "Cheque", int_Voucherid, Str_Chequeno, 0, "");
                    //DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
                    //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                    Str_LedgerName = "CTC ACCOUNT-" + Str_Shortname;
                    int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_Bankname, 'O');
                    if (int_Ledgerid == 0)
                    {
                        int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_Bankname, 26, 1, 'G', 0, 'O', Str_DBname);
                    }
                    if (int_Ledgerid != 0)
                    {
                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Amount, int_Rvouyear, int_LogCorid, int_divisionid);
                    }

                    int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgerName, 'O');
                    if (int_Ledgerid == 0)
                    {
                        int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_LedgerName, 32, 13, 'G', 0, 'O', Str_DBname);
                    }
                    if (int_Ledgerid != 0)
                    {
                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Amount, int_Rvouyear, int_LogCorid, int_divisionid);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_JVFA(int Receiptid, DataTable dt, int index, string str_Vouno)
        {
            try
            {
                int int_vouchertypeid = 0, int_Vouno = 0, int_Voucherid = 0, int_Ledgerid = 0, int_divisionid = 0;
                string Str_DBname = "", Str_BranchName = "", Str_ShortName = "";
                double Amount = 0;
                //int_bid = int.Parse(Session["LoginBranchid"].ToString());

                int int_bid = Obj_da_HREmp.GetBranchId(Division_ID, ddl_branch.SelectedItem.Text);

                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                Str_DBname = Session["FADbname"].ToString();
                //DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                //DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
                //DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
                //DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
                //DataAccess.Accounts.Journal obj_da_journal = new DataAccess.Accounts.Journal();
                //DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                Str_ShortName = obj_da_Branch.GetShortName(int_bid);
                Str_BranchName = obj_da_OSDN.GetPortCode(int_bid);
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                int_bid = int.Parse(dt.Rows[index]["branchid"].ToString());
                obj_dt = obj_da_Emp.GetBranchandDivision(int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    int_divisionid = int.Parse(obj_dt.Rows[0]["divisionid"].ToString());
                }
                DateTime dtdate = obj_da_Log.GetDate();
                int_Vouno = obj_da_journal.GetJournalNoMONTH(int_bid, dtdate);
                int_vouchertypeid = obj_da_journal.Selvoutypeid("Journal", Str_DBname);
                Amount = double.Parse(dt.Rows[index]["amount"].ToString());
                int_Voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_vouchertypeid, int_Vouno.ToString(), dtdate, Str_BranchName + " - Receipt #: " + index + " Amount collected at " + Str_ShortName + ".", "AC", 0, 0, int_bid, int_divisionid, int_Empid, dtdate, 'N', int.Parse(hid_year.Value.ToString()));
                obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_Voucherid, str_Vouno, 0, "");

                int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_BranchName, 'O');

                if (int_Ledgerid == 0)
                {
                    int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_BranchName, 1, 1, 'G', 0, 'O', Str_DBname);
                }
                if (Amount < 0)
                {
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Amount, int.Parse(hid_year.Value.ToString()), int_bid, int_divisionid);
                }
                else
                {
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Amount, int.Parse(hid_year.Value.ToString()), int_bid, int_divisionid);
                }


                int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, dt.Rows[index]["Customer"].ToString(), 'C');

                if (int_Ledgerid == 0)
                {
                  //  DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                    int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int.Parse(dt.Rows[index]["Customer"].ToString())), 1, 1, 'G', int.Parse(hid_customerid.Value.ToString()), 'O', Str_DBname);
                }
                if (Amount < 0)
                {
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Amount, int.Parse(hid_year.Value.ToString()), int_bid, int_divisionid);
                }
                else
                {
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Amount, int.Parse(hid_year.Value.ToString()), int_bid, int_divisionid);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp" && e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void txt_receipt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hid_type.Value == "R")
                {
                    if (txt_receipt.Text != "" && txt_Vouyear.Text != "")
                    {
                        Fn_Getdetail();
                    }
                }
                else
                {
                    if (txt_receipt.Text != "" && txt_Vouyear.Text != "" && ddl_branch.SelectedIndex != -1)
                    {
                        Fn_Getdetail();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_Vouyear_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (hid_type.Value == "R")
                {
                    if (txt_receipt.Text != "" && txt_Vouyear.Text != "")
                    {
                        Fn_Getdetail();
                    }
                }
                else
                {
                    if (txt_receipt.Text != "" && txt_Vouyear.Text != "" && ddl_branch.SelectedIndex != -1)
                    {
                        Fn_Getdetail();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
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
           // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1179, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1179, "", "", "", Session["StrTranType"].ToString());
            }

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

    }
}