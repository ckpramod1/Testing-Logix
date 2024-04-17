using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Web.Services.Description;

namespace logix.FAForm
{
    public partial class BRS : System.Web.UI.Page
    {
        DataAccess.FAMaster.MasterLedger ledobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Payment pymtobj = new DataAccess.Accounts.Payment();
        DataAccess.FAVoucher faobj = new DataAccess.FAVoucher();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        int i,ledgerid;
        DataTable dt = new DataTable();
        DataTable dtrec = new DataTable();
        DataTable dtpay = new DataTable();
        DataTable Dt1 = new DataTable();

        string receipt, type, curtype,strantype;
        double dbl_P, dbl_R, dbl_X, dbl_Y, dbl_O, dbl_O_CR, dbl_O_DR, dbl_A, dbl_B, dbl_BPR, dbl_BRR, credit, debit;    
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                ledobj.GetDataBase(Ccode);
                recobj.GetDataBase(Ccode);
                pymtobj.GetDataBase(Ccode);
                faobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                LblHead.Text = Request.QueryString["FormName"].ToString();
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }            

            if (!Page.IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                txtbook.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txtreceipt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txttotal.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txtpayment.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txttotal1.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txtCBNB.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txttotal2.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txtDBNB.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txtbank.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                loadbankledger();
                dtto.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                grdContra.DataSource = new DataTable();
                grdContra.DataBind();
                GrdReceipt.DataSource = new DataTable();
                GrdReceipt.DataBind();
                grdPayment.DataSource = new DataTable();
                grdPayment.DataBind();

                DataTable dt = new DataTable();
                dt = ledobj.ChkBRSDet();
                brsdetail.DataSource = dt;
                brsdetail.DataBind();
                pnlConfirm.Attributes["class"] = "popupconfirmnew";
                popupconfirmnew.Show();
                return;

            }            
        }

        public void loadbankledger()
        {
            dt = ledobj.GetBankLedger(Session["FADbname"].ToString());

            ddlbank.DataTextField = "LedgerName";
            ddlbank.DataValueField = "ledgerid";

            ddlbank.DataSource = dt;
            ddlbank.DataBind();
        }

        public void GetNullRPClearanceDetails()
        {
            if (type == "R" || type == "P")
            {
                Dt1 = pymtobj.Getchequedetails(type, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ddlbank.SelectedItem.Text);
            }
            else if (type == "X")
            {
                Dt1 = recobj.GetOSRecptClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ddlbank.SelectedItem.Text, curtype);
            }
            else if (type == "Y")
            {
                Dt1 = pymtobj.GetOSPymtClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ddlbank.SelectedItem.Text, curtype);
            }
            else if (type == "A")
            {
                Dt1 = faobj.GetManRPClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ledgerid, "R", curtype);
            }
            else if (type == "B")
            {
                Dt1 = faobj.GetManRPClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ledgerid, "P", curtype);
            }
            else if (type == "O")
            {
                Dt1 = faobj.GetContraClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ledgerid, "Contra", curtype);
            }
            else if (type == "BRR")
            {
                Dt1 = faobj.GetContraClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ledgerid, "BRR", curtype);
            }
            else if (type == "BPR")
            {
                Dt1 = faobj.GetContraClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ledgerid, "BPR", curtype);
            }

            if (Dt1.Rows.Count > 0)
            {
                if (dtrec.Columns.Count == 0)
                {                   
                    dtrec.Columns.Add("chequedate");
                    dtrec.Columns.Add("Chequeno");
                    dtrec.Columns.Add("bank");
                    dtrec.Columns.Add("customername");
                    dtrec.Columns.Add("amount");
                    dtrec.Columns.Add("branch");
                    dtrec.Columns.Add("Rid");
                }

                if (dtpay.Columns.Count == 0)
                {

                    dtpay.Columns.Add("chequedate");
                    dtpay.Columns.Add("Chequeno");
                    dtpay.Columns.Add("bank");
                    dtpay.Columns.Add("customername");
                    dtpay.Columns.Add("amount");
                    dtpay.Columns.Add("branch");
                    dtpay.Columns.Add("Rid");
                }

                if (type == "R" || type == "A" || type == "BRR")
                {
                    int b = 0;
                    int r = 0;
                    b = dtrec.Rows.Count;
                    for (i = b; i <= b + Dt1.Rows.Count - 1; i++)
                    {
                        dtrec.Rows.Add();
                        dtrec.Rows[i][0] = Dt1.Rows[r]["chequedate"].ToString();
                        dtrec.Rows[i][1] = Dt1.Rows[r]["chequeno"].ToString();
                        dtrec.Rows[i][2] = Dt1.Rows[r]["bank"].ToString();
                        dtrec.Rows[i][3] = Dt1.Rows[r]["customername"].ToString();
                        dtrec.Rows[i][4] = Dt1.Rows[r]["amount"].ToString();
                        dtrec.Rows[i][6] = Dt1.Rows[r]["id"].ToString();
                        dtrec.Rows[i][5] = Dt1.Rows[r]["shortname"].ToString();
                        if (type == "R")
                        {
                            dbl_R = dbl_R + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        }
                        else if (type == "A")
                        {
                            dbl_A = dbl_A + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        }
                        else if (type == "BRR")
                        {
                            dbl_BRR = dbl_BRR + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        }
                        //  GrdReceipt.Rows(i).Cells("shortname1").Value = Dt1.Rows[r]["shortname"].ToString();
                        r = r + 1;
                    }
                    dtrec.Rows.Add();
                    if (type == "R")
                    {
                        dtrec.Rows[dtrec.Rows.Count - 1][3] = "Receipt Total";
                        dtrec.Rows[dtrec.Rows.Count - 1][4] = string.Format("{0:0.00}", dbl_R);
                        //String.Format(dbl_R, "{0:0.00}");
                    }
                    else if (type == "A")
                    {
                        dtrec.Rows[dtrec.Rows.Count - 1][3] = "Manual Receipt Total";
                        dtrec.Rows[dtrec.Rows.Count - 1][4] = string.Format("{0:0.00}", dbl_A);
                    }
                    else if (type == "BRR")
                    {
                        dtrec.Rows[dtrec.Rows.Count - 1][3] = "BRR Total";
                        dtrec.Rows[dtrec.Rows.Count - 1][4] = string.Format("{0:0.00}", dbl_BRR);
                    }
                    dtrec.Rows.Add();
                    ViewState["Receipt"] = dtrec;
                    //GrdReceipt.Rows.Add();
                }
                else if (type == "X")
                {
                    int b = 0;
                    int r = 0;
                    dtrec.Rows.Add();
                    b = dtrec.Rows.Count;
                    for (i = b; i <= b + Dt1.Rows.Count - 1; i++)
                    {
                        dtrec.Rows.Add();
                        dtrec.Rows[i][0] = Dt1.Rows[r]["chequedate"].ToString();
                        dtrec.Rows[i][1] = Dt1.Rows[r]["chequeno"].ToString();
                        dtrec.Rows[i][2] = Dt1.Rows[r]["bank"].ToString();
                        dtrec.Rows[i][3] = Dt1.Rows[r]["customername"].ToString();
                        dtrec.Rows[i][4] = Dt1.Rows[r]["amount"].ToString();
                        dtrec.Rows[i][6] = Dt1.Rows[r]["receiptid"].ToString();
                        dtrec.Rows[i][5] = Dt1.Rows[r]["shortname"].ToString();

                        dbl_X = dbl_X + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        r = r + 1;
                    }
                    dtrec.Rows.Add();
                    dtrec.Rows[dtrec.Rows.Count - 1][3] = "OS Receipt Total";
                    dtrec.Rows[dtrec.Rows.Count - 1][4] = string.Format("{0:0.00}", dbl_X);
                    dtrec.Rows.Add();
                }
                else if (type == "P" || type == "B" || type == "BPR")
                {
                    int b = 0, r_count, r = 0;
                    b = dtpay.Rows.Count;

                    for (i = b; i <= b + Dt1.Rows.Count - 1; i++)
                    {
                        if (Math.Abs(Convert.ToDouble(Dt1.Rows[r]["amount"].ToString())) > 0)
                        {
                            r_count = dtpay.Rows.Count;
                            dtpay.Rows.Add();
                            dtpay.Rows[r_count][0] = Dt1.Rows[r]["chequedate"].ToString();
                            dtpay.Rows[r_count][1] = Dt1.Rows[r]["chequeno"].ToString();
                            dtpay.Rows[r_count][2] = Dt1.Rows[r]["bank"].ToString();
                            dtpay.Rows[r_count][3] = Dt1.Rows[r]["customername"].ToString();
                            dtpay.Rows[r_count][4] = Dt1.Rows[r]["amount"].ToString();
                            dtpay.Rows[r_count][6] = Dt1.Rows[r]["id"].ToString();

                            if (type == "P")
                            {
                                dbl_P = dbl_P + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                            }
                            else if (type == "B")
                            {
                                dbl_B = dbl_B + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                            }
                            else if (type == "BPR")
                            {
                                dbl_BPR = dbl_BPR + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                            }
                            dtpay.Rows[r_count][5] = Dt1.Rows[r]["shortname"].ToString();
                        }
                        r = r + 1;
                    }
                    dtpay.Rows.Add();

                    if (type == "P")
                    {
                        dtpay.Rows[dtpay.Rows.Count - 1][3] = "Payment Total";
                        dtpay.Rows[dtpay.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_P);
                    }
                    else if (type == "B")
                    {
                        dtpay.Rows[dtpay.Rows.Count - 1][3] = "Manual Payment Total";
                        dtpay.Rows[dtpay.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_B);
                    }
                    else if (type == "BPR")
                    {
                        dtpay.Rows[dtpay.Rows.Count - 1][3] = "BPR Total";
                        dtpay.Rows[dtpay.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_BPR);
                    }
                    dtpay.Rows.Add();
                    ViewState["Payment"] = dtpay;
                }
                else if (type == "Y")
                {
                    int b = 0;
                    int r = 0;
                    dtpay.Rows.Add();
                    b = dtpay.Rows.Count;
                    for (i = b; i <= b + Dt1.Rows.Count - 1; i++)
                    {
                        dtpay.Rows.Add();
                        dtpay.Rows[i][0] = Dt1.Rows[r]["chequedate"].ToString();
                        dtpay.Rows[i][1] = Dt1.Rows[r]["chequeno"].ToString();
                        dtpay.Rows[i][2] = Dt1.Rows[r]["bank"].ToString();
                        dtpay.Rows[i][3] = Dt1.Rows[r]["customername"].ToString();
                        dtpay.Rows[i][4] = Dt1.Rows[r]["amount"].ToString();
                        dtpay.Rows[i][6] = Dt1.Rows[r]["paymentid"].ToString();
                        dtpay.Rows[i][5] = Dt1.Rows[r]["Shortname"].ToString();

                        dbl_Y = dbl_Y + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        r = r + 1;
                    }
                    dtpay.Rows.Add();
                    dtpay.Rows[dtpay.Rows.Count - 1][3] = "OS Payment Total";
                    dtpay.Rows[dtpay.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_Y);
                    dtpay.Rows.Add();
                }
                else if (type == "O")
                {
                    int b = 0;
                    int r = 0;
                    DataTable dtcontra = new DataTable();
                    dtcontra.Columns.Add("chequedate");
                    dtcontra.Columns.Add("chequeno");
                    dtcontra.Columns.Add("bank");
                    dtcontra.Columns.Add("customername");
                    dtcontra.Columns.Add("amount");
                    dtcontra.Columns.Add("branch");
                    dtcontra.Columns.Add("RID");
                    b = dtcontra.Rows.Count;
                    for (i = 0; i <= Dt1.Rows.Count - 1; i++)
                    {
                        if (Math.Abs(Convert.ToDouble(Dt1.Rows[i]["amount"].ToString())) > 0)
                        {
                            dtcontra.Rows.Add();
                            dtcontra.Rows[r][0] = Dt1.Rows[i]["chequedate"].ToString();
                            dtcontra.Rows[r][1] = Dt1.Rows[i]["chequeno"].ToString();
                            dtcontra.Rows[r][2] = Dt1.Rows[i]["bank"].ToString();
                            dtcontra.Rows[r][3] = Dt1.Rows[i]["customername"].ToString();
                            dtcontra.Rows[r][4] = Dt1.Rows[i]["amount"].ToString();
                            dtcontra.Rows[r][6] = Dt1.Rows[i]["id"].ToString();
                            dtcontra.Rows[r][5] = Dt1.Rows[i]["Shortname"].ToString();
                            if (Dt1.Rows[i]["LedgerType"].ToString() == "Cr")
                            {
                                dbl_O_CR = dbl_O_CR + Convert.ToDouble(Dt1.Rows[i]["amount"].ToString());
                            }
                            else
                            {
                                dbl_O_DR = dbl_O_DR + Convert.ToDouble(Dt1.Rows[i]["amount"].ToString());
                            }
                            dbl_O = dbl_O + Convert.ToDouble(Dt1.Rows[i]["amount"].ToString());
                            r = r + 1;
                        }
                    }
                    dtcontra.Rows.Add();
                    dtcontra.Rows[dtcontra.Rows.Count - 1][2] = "Contra Total";
                    dtcontra.Rows[dtcontra.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_O);
                    dtcontra.Rows.Add();
                    grdContra.DataSource = dtcontra;
                    grdContra.DataBind();
                    //grdContra.Rows(grdContra.Rows.Count - 1).Cells(2).Value = "Total"
                    //grdContra.Rows(grdContra.Rows.Count - 1).Cells(4).Value = Format(Convert.ToDouble(txt_ContraCR.Text) + Convert.ToDouble(txt_contraDB.Text), "{0:0.00}")
                }
            }
        }

        public void CalAmount()
        {
            try
            {

                if (txtCBNB.Text.ToString().Length > 0)
                {
                    txttotal2.Text = (Convert.ToDouble(txttotal1.Text) + Convert.ToDouble(txtCBNB.Text)).ToString("0.00");
                }
                else
                {
                    txttotal2.Text = (Convert.ToDouble(txttotal1.Text)).ToString("0.00");
                }


                if (txtDBNB.Text.ToString().Length > 0)
                {
                    txtbank.Text = (Convert.ToDouble(txttotal2.Text) - Convert.ToDouble(txtDBNB.Text)).ToString("0.00");
                }
                else
                {
                    txtbank.Text = (Convert.ToDouble(txttotal2.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                //String curtype;

                if (chkc.Checked == true)
                {
                    curtype = "USD";
                }
                else
                {
                    curtype = "INR";
                }

                ledgerid = Convert.ToInt32(ddlbank.SelectedValue.ToString());

                ds = ledobj.GetCrandDBfromLedger(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ledgerid, curtype);
                debit = 0;
                grdContra.DataSource = null;
                grdContra.DataBind();

                GrdReceipt.DataSource = null;
                GrdReceipt.DataBind();
                grdPayment.DataSource = null;
                grdPayment.DataBind();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["debit"].ToString().Length == 0)
                    {
                        debit = 0;
                    }
                    else
                    {
                        debit = Convert.ToDouble(ds.Tables[0].Rows[0]["debit"]);
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["credit"].ToString().Length == 0)
                    {
                        credit = 0;
                    }
                    else
                    {
                        credit = Convert.ToDouble(ds.Tables[1].Rows[0]["credit"]);
                    }
                }

                if (debit > 0 || credit > 0)
                {
                    txtbook.Text = string.Format("{0:#,##0.00}", (debit - credit));
                }
                else
                {
                    txtbook.Text = "0.00";
                }

                Label1.Focus();
                dbl_R = 0;
                dbl_P = 0;
                dbl_X = 0;
                dbl_Y = 0;
                dbl_O = 0;
                dbl_O_CR = 0;
                dbl_O_DR = 0;
                dbl_A = 0;
                dbl_B = 0;
                dbl_BPR = 0;
                dbl_BRR = 0;

                type = "P";//Payment
                GetNullRPClearanceDetails();

                type = "R"; //'Receipt;
                GetNullRPClearanceDetails();
                type = "X"; //OS Receipt;
                GetNullRPClearanceDetails();
                type = "Y"; //OS Payment;
                GetNullRPClearanceDetails();
                type = "O"; //Contra;
                GetNullRPClearanceDetails();
                type = "A"; //Manual Receip;
                GetNullRPClearanceDetails();
                type = "B"; // Manual Payment;
                GetNullRPClearanceDetails();
                type = "BRR";
                GetNullRPClearanceDetails();
                type = "BPR";
                GetNullRPClearanceDetails();

                GrdReceipt.DataSource = dtrec;
                GrdReceipt.DataBind();

                grdPayment.DataSource = dtpay;
                grdPayment.DataBind();

                txtreceipt.Text = string.Format("{0:#,##0.00}", (dbl_R + dbl_X + dbl_A + dbl_BRR + dbl_O_DR));
                txtpayment.Text = string.Format("{0:#,##0.00}", (dbl_P + dbl_Y + dbl_B + dbl_BPR + dbl_O_CR));
                txttotal.Text = (Convert.ToDouble(txtbook.Text) - Convert.ToDouble(txtreceipt.Text)).ToString("0.00");
                txttotal1.Text = (Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtpayment.Text)).ToString("0.00");
                CalAmount();

                if (Convert.ToDouble(txtbook.Text) < 0)
                {
                    lblourbook.Text = "Cr";
                    txtbook.Text = txtbook.Text.Remove(0, 1);
                }
                else
                {
                    lblourbook.Text = "Dr";
                }

                if (Convert.ToDouble(txttotal.Text) < 0)
                {
                    lbltolcr.Text = "Cr";
                    txttotal.Text = txttotal.Text.Remove(0, 1);
                }
                else
                {
                    lbltolcr.Text = "Dr";
                }

                if (Convert.ToDouble(txttotal1.Text) < 0)
                {
                    Lbl3.Text = "Cr";
                    txttotal1.Text = txttotal1.Text.Remove(0, 1);
                }
                else
                {
                    Lbl3.Text = "Dr";
                }

                if (Convert.ToDouble(txttotal2.Text) < 0)
                {
                    lbl5.Text = "Cr";
                    txttotal2.Text = txttotal2.Text.Remove(0, 1);
                }
                else
                {
                    lbl5.Text = "Dr";
                }

                if (Convert.ToDouble(txtbank.Text) < 0)
                {
                    lblperbank.Text = "Cr";
                    txtbank.Text = txtbank.Text.Remove(0, 1);
                }
                else
                {
                    lblperbank.Text = "Dr";
                }

                Lbl3.Text = lbltolcr.Text;
                lbl5.Text = lblperbank.Text;

                if (txtreceipt.Text == "")
                {
                    txtreceipt.Text = "0.00";
                }
                if (txtpayment.Text == "")
                {
                    txtpayment.Text = "0.00";
                }
                if (txtbook.Text == "")
                {
                    txtbook.Text = "0.00";
                }
                if (txtDBNB.Text == "")
                {
                    txtDBNB.Text = "0.00";
                }
                if (txtCBNB.Text == "")
                {
                    txtCBNB.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }                    

        protected void dtto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                string DB_Name = Session["FADbname"].ToString();
                int Emp_ID = Convert.ToInt32(Session["LoginEmpId"]);
                pymtobj.DelTempBRS(Emp_ID, DB_Name);

                if (grdContra.Rows.Count == 0 && grdPayment.Rows.Count == 0 && GrdReceipt.Rows.Count == 0)
                {
                    pymtobj.InsTempBRS(Emp_ID, DB_Name, ddlbank.SelectedItem.Text, lbldeposit.Text, "", Convert.ToDateTime("09/09/9999"), "", 0, "L", Convert.ToInt32(Session["LoginBranchid"]), "", "");
                }

                if (grdPayment.Rows.Count > 0 || GrdReceipt.Rows.Count > 0 || grdContra.Rows.Count > 0)
                {

                    for (int i = 0; i < grdPayment.Rows.Count - 2; i++)
                    {
                        if (!string.IsNullOrEmpty(grdPayment.Rows[i].Cells[2].Text ))
                        {
                            Label Customer = (Label)grdPayment.Rows[i].FindControl("customername");
                            string CustomerName = Customer.Text;

                            pymtobj.InsTempBRS(Emp_ID, DB_Name, ddlbank.SelectedItem.Text, lbldeposit.Text, grdPayment.Rows[i].Cells[1].Text, Convert.ToDateTime(Utility.fn_ConvertDate(grdPayment.Rows[i].Cells[0].Text)), grdPayment.Rows[i].Cells[2].Text, Convert.ToDouble(grdPayment.Rows[i].Cells[4].Text), "L", Convert.ToInt32(Session["LoginBranchid"]), CustomerName, grdPayment.Rows[i].Cells[5].Text);
                        }
                    }

                    for (int i = 0; i < GrdReceipt.Rows.Count -2; i++)
                    {
                        if (!string.IsNullOrEmpty( GrdReceipt.Rows[i].Cells[2].Text) )
                        {
                            Label Customer = (Label)GrdReceipt.Rows[i].FindControl("customername");
                            string CustomerName = Customer.Text;

                            pymtobj.InsTempBRS(Emp_ID, DB_Name, ddlbank.SelectedItem.Text, Label14.Text, GrdReceipt.Rows[i].Cells[1].Text, Convert.ToDateTime(Utility.fn_ConvertDate(GrdReceipt.Rows[i].Cells[0].Text)), GrdReceipt.Rows[i].Cells[2].Text, Convert.ToDouble(GrdReceipt.Rows[i].Cells[4].Text), "L", Convert.ToInt32(Session["LoginBranchid"]), CustomerName, GrdReceipt.Rows[i].Cells[5].Text);
                        }
                    }

                    for (int i = 0; i < grdContra.Rows.Count - 2; i++)
                    {
                        if (!string.IsNullOrEmpty(grdContra.Rows[i].Cells[2].Text))
                        {
                            pymtobj.InsTempBRS(Emp_ID, DB_Name, ddlbank.SelectedItem.Text, Label9.Text, grdContra.Rows[i].Cells[1].Text, Convert.ToDateTime(Utility.fn_ConvertDate(grdContra.Rows[i].Cells[0].Text)), grdContra.Rows[i].Cells[2].Text, Convert.ToDouble(grdContra.Rows[i].Cells[4].Text), "L", Convert.ToInt32(Session["LoginBranchid"]), "", grdContra.Rows[i].Cells[5].Text);
                        }
                    }

                    if (txtreceipt.Text == "")
                    {
                        txtreceipt.Text = "0.00";
                    }
                    if (txtpayment.Text == "")
                    {
                        txtpayment.Text = "0.00";
                    }
                    if (txtbook.Text == "")
                    {
                        txtbook.Text = "0.00";
                    }
                    if (txtDBNB.Text == "")
                    {
                        txtDBNB.Text = "0.00";
                    }
                    if (txtCBNB.Text == "")
                    {
                        txtCBNB.Text = "0.00";
                    }

                    Session["str_sp"] = ""; Session["str_sp"] = "";
                    string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
                    int BranchId = Convert.ToInt32(Session["LoginBranchid"].ToString());

                    //Session["str_sfs"] = "{TmpBrs.empid}=" + Session["LoginEmpId"].ToString();
                    //Session["str_sp"] = "Title= BRS ~ToDate=" + (Convert.ToDateTime(dtto.Text).ToShortDateString()) + "~BPOB=" + txtbook.Text + "~CDBNC=" + txtreceipt.Text + "~Total1=" + txttotal.Text + "~CIBNC=" + txtpayment.Text + "~Total2=" + txttotal1.Text + "~CBBBNIOB=" + txtCBNB.Text + "~Total3=" + txttotal2.Text + "~DBBBNIOB=" + txtDBNB.Text + "~BPB=" + txtbank.Text + " ~crdr1=" + lblourbook.Text + " ~crdr2=" + lbltolcr.Text + "~crdr3=" + Lbl3.Text + " ~crdr4=" + lbl5.Text + "~crdr5=" + lblperbank.Text;

                    str_RptName = "rptBRS.rpt";
                    Session["str_sfs"] = "{tmpBRS.empid}=" + Session["LoginEmpId"].ToString();
                    Session["str_sp"] = "Title=BRS ~ToDate=" + dtto.Text+ " ~BPOB=" + txtbook.Text + " ~CDBNC=" + txtreceipt.Text + " ~Total1=" + txttotal.Text + " ~CIBNC=" + txtpayment.Text + "~Total2=" + txttotal1.Text + "~CBBBNIOB=" + txtCBNB.Text + "~Total3=" + txttotal2.Text + "~DBBBNIOB=" + txtDBNB.Text + " ~BPB=" + txtbank.Text + " ~crdr1=" + lblourbook.Text + " ~crdr2=" + lbltolcr.Text + " ~crdr3=" + Lbl3.Text + " ~crdr4=" + lbl5.Text + " ~crdr5=" + lblperbank.Text;

                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Reciepts", str_Script, true);

                    if (Session["str_ModuleName"] == "FA")
                    {
                        logobj.InsLogDetail(Emp_ID, 1104, 3, BranchId, Convert.ToDateTime(dtto.Text).ToShortDateString() + "/V");
                    }
                    else
                    {
                        logobj.InsLogDetail(Emp_ID, 1193, 3, BranchId, "/V");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grdPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                }

                for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void GrdReceipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                }

                for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void grdContra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                }

                for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        

        protected void txtCBNB_TextChanged(object sender, EventArgs e)
        {
            
            CalAmount();
        }

        protected void txtDBNB_TextChanged(object sender, EventArgs e)
        {
            CalAmount();
        }

        
        protected void ConfrimBRS_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlbank.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Bank');", true);
                }
                else if (txtbank.Text == "" && grdPayment.Rows.Count == 0 && GrdReceipt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Cheque Details to Confrim BRS');", true);
                }
                else if ((txtbank.Text == "" || txtbank.Text == "0.00") && (txtbook.Text == "" || txtbook.Text == "0.00") && grdContra.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Records Found');", true);
                }
                else
                {
                    int BranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    int DivisionId = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    DataTable dt = new DataTable();
                    ledgerid = Convert.ToInt32(ddlbank.SelectedValue.ToString());
                    dt = ledobj.ConfirmedBRS(ddlbank.SelectedItem.Text, BranchID, DivisionId, Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text)), ledgerid);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('BRS Confirmed.');", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            this.popupconfirmnew.Hide();
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
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1104, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1193, "", "", "", Session["StrTranType"].ToString());
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
    
