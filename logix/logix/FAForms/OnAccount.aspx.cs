using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Services;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace logix.FAForm
{
    public partial class OnAccToAgainsVou : System.Web.UI.Page
    {
        int b = 0;
        int int_Custid = 0;
        char char_Mode;
        DataTable obj_dt = new DataTable();
        DataTable obj_dttemp = new DataTable();
        DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Payment obj_da_payment = new DataAccess.Accounts.Payment();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

       
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        int int_bid, int_divisionid;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_Receipt.GetDataBase(Ccode);
                obj_da_payment.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                obj_da_Ledger.GetDataBase(Ccode);
                Emp_Obj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (ddl_receipt.SelectedItem.Text == "Payment")
            {

                Session["Rtype"] = "P";
                Session["rptype"] = Session["Rtype"];
            }
            else if (ddl_receipt.SelectedItem.Text == "Receipt")
            {

                Session["Rtype"] = "R";
                Session["rptype"] = Session["Rtype"];
            }
            int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                Session["AgainstVouYear"] = null;
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                txt_date.Text = hid_date.Value.ToString();
                txt_year.Text = Session["Vouyear"].ToString();
                txt_tdsamount.Text = "-0.00";
                Grd_detail.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_detail.DataBind();
                txt_receipt.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                btn_cancel.Text = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }
        [WebMethod]
        public static List<string> GetCust(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
            DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            Emp_Obj.GetDataBase(Ccode);
            recobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string rtypeval = HttpContext.Current.Session["Rtype"].ToString();
            string BranchName = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
            int Div_Id = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int BranchId = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int logcorid = Emp_Obj.GetBranchId(Div_Id, "CORPORATE");

            if (rtypeval == "R")
            {
                if (logcorid == BranchId)
                {
                    dt = recobj.GetLikeReceiptCustomer4Corp(prefix);
                }
                else if (BranchId == 5)
                {
                    dt = recobj.GetLikeReceiptCustomer4Mum(prefix);
                }
                else
                {
                    dt = recobj.GetLikeReceiptCustomer(prefix);
                }
            }
            else
            {
                int Sel_branchid = Emp_Obj.GetBranchId(Div_Id, BranchName);
                if (logcorid == Sel_branchid)
                {
                    dt = customerobj.GetLikeIndianCustomer4Corp(prefix);
                }
                else
                {
                    dt = customerobj.GetLikeIndianCustomer(prefix);
                }

            }
            List_Result = Utility.Fn_DatatableToList_int16Display(dt, "customer", "customerid", "customername");
            return List_Result;
        }
        protected void txt_receipt_TextChanged(object sender, EventArgs e)
        {
            //Fn_Getdetail();

            if (ddl_module.Text != "")
            {
                Fn_Getdetail();
                btn_cancel.Text = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "OnAccount", "alertify.alert('Mode Can Not Be Blank');", true);
                ddl_module.Focus();
            }

        }

        protected void ddl_receipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_receipt.SelectedItem.Text == "Receipt")
            {
                Session["rptype"] = "R";
                txt_receipt.ToolTip = "Receipt #";
                txt_received.ToolTip = "Received From";
                txt_amount.ToolTip = "Receipt Amount";
                txt_receipt.Attributes.Add("placeholder", "Receipt #");
                txt_received.Attributes.Add("placeholder", "Received From");
                txt_amount.Attributes.Add("placeholder", "Receipt Amount");

                txt_tdsamount.Visible = true;
                lbl_tdsamount.Visible = true;
                lbl_tdsamount.Text = "TDS Amount";

            }
            else if (ddl_receipt.SelectedItem.Text == "Payment")
            {
                Session["rptype"] = "P";
                txt_receipt.ToolTip = "Payment #";
                txt_received.ToolTip = "Payment From";
                txt_amount.ToolTip = "Payment Amount";
                txt_receipt.Attributes.Add("placeholder", "Payment #");
                txt_received.Attributes.Add("placeholder", "Payment To");
                txt_amount.Attributes.Add("placeholder", "Payment Amount");

                txt_tdsamount.Visible = true;
                lbl_tdsamount.Visible = true;
                lbl_tdsamount.Text = "Deduction";
            }
        }
        private void Fn_Getdetail()
        {
            int int_Receiptid = 0;

            double Amount = 0;
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            //DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            //DataAccess.Accounts.Payment obj_da_payment = new DataAccess.Accounts.Payment();

            if (ddl_receipt.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "OnAccount", "alertify.alert('Kindly Select Voucher');", true);
                Fn_Clear();
                return;
            }


            if (ddl_module.SelectedItem.Text.ToString().Trim().Length > 0 && txt_receipt.Text.ToString().Trim().Length > 0 && txt_year.Text.ToString().Trim().Length > 0)
            {
                char_Mode = char.Parse(ddl_module.SelectedValue.ToString());
                //  obj_dt = obj_da_Receipt.GetRecptHead(int.Parse(txt_receipt.Text), int_bid, char_Mode, int.Parse(txt_year.Text));
                obj_dt = obj_da_Receipt.GetRecptHeadFA(int.Parse(txt_receipt.Text), int_bid, char_Mode, int.Parse(txt_year.Text), Convert.ToChar(Session["rptype"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    int_Receiptid = int.Parse(obj_dt.Rows[0][0].ToString());
                    hid_receiptid.Value = int_Receiptid.ToString();
                    hid_rptid.Value = int_Receiptid.ToString();
                    txt_date.Text = Utility.fn_ConvertDate(obj_dt.Rows[0][2].ToString());
                    Amount = double.Parse(obj_dt.Rows[0][7].ToString());
                    txt_amount.Text = string.Format("{0:#,##0.00}", Amount);
                    txt_received.Text = obj_dt.Rows[0][6].ToString();
                    //  obj_dttemp = obj_da_Receipt.GetRecptChrg(int_Receiptid);


                    //Vino New for PAN Cust Details St [27-03-2024]
                    hid_panno.Value = obj_dt.Rows[0]["panno"].ToString();
                    //Vino New for PAN Cust Details St [27-03-2024]


                    if (Session["rptype"].ToString() == "R")
                    {
                        obj_dttemp = obj_da_Receipt.GetRecptChrg(int_Receiptid);
                    }
                    else
                    {
                        obj_dttemp = obj_da_payment.GetPaymentChrg(int_Receiptid);
                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_tdsamount.Text = obj_dttemp.Rows[0][1].ToString();
                    }

                    if (Session["rptype"].ToString() == "R")
                    {
                        obj_dttemp = obj_da_Receipt.GetRecptCust(int_Receiptid);
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        obj_dttemp = obj_da_payment.GetPaymentCust(int_Receiptid);
                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        double A = Convert.ToDouble(obj_dttemp.Compute("Sum(aa)", string.Empty));
                        txt_custamount.Text = A.ToString("#0.00");
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "OnAccount", "alertify.alert('Invalid Receipt #');", true);
                    Fn_Clear();
                    return;
                }

                obj_dt = obj_da_Receipt.GetRAInvoiceToShow(int_Receiptid, Convert.ToChar(Session["rptype"]));
                //var obj_Check = obj_dt.AsEnumerable().Where(row => row.Field<string>(obj_dt.Columns[5].ColumnName) == "O");
                //if (obj_Check.ToList().Count == 0)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "OnAccount", "alertify.alert('OnAccount Details Not Exist For this Receipt #');", true);
                //    Fn_Clear();
                //    return;
                //}
                if (obj_dt.Rows.Count > 0)
                {
                    // var obj_Check = obj_dt.AsEnumerable().Where(row => row.Field<string>(obj_dt.Columns[5].ColumnName) == "O");

                    string IE;
                    Boolean OAExist = false;
                    //var obj_Check = obj_dt.AsEnumerable().Where(row => row.Field<string>(obj_dt.Columns[5].ColumnName) == "O");
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        IE = obj_dt.Rows[i][5].ToString().Trim();
                        if (IE == "O")
                        {
                            OAExist = true;
                        }
                    }

                    if (OAExist == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "OnAccount", "alertify.alert('OnAccount Details Not Exist For this Receipt #');", true);
                        Fn_Clear();
                        return;
                    }


                    btn_update.Enabled = true;
                    btn_update.ForeColor = System.Drawing.Color.White;
                    DataTable obj_dtAccount = new DataTable();
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                    DataRow dr;

                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtAccount.NewRow();
                        obj_dtAccount.Rows.Add(dr);

                        dr[0] = obj_dt.Rows[i][0].ToString();
                        dr[1] = obj_dt.Rows[i][1].ToString();
                        if (obj_dt.Rows[i][2].ToString().Trim() != "0")
                        {
                            if (obj_dt.Rows[i][5].ToString().Trim() == "I")
                            {
                                dr[2] = "Inv - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString().Trim() == "D")
                            {
                                dr[2] = "OSDN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString().Trim() == "V")
                            {
                                dr[2] = "DN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString().Trim() == "X")
                            {
                                dr[2] = "ADN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString().Trim() == "P")
                            {
                                dr[2] = "CNOps - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString().Trim() == "C")
                            {
                                dr[2] = "OSCN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString().Trim() == "E")
                            {
                                dr[2] = "CN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString().Trim() == "S")
                            {
                                dr[2] = "ACN - " + obj_dt.Rows[i][2].ToString();
                            }
                            else if (obj_dt.Rows[i][5].ToString().Trim() == "B")
                            {
                                dr[2] = "BOS - " + obj_dt.Rows[i][2].ToString();
                            }
                        }
                        else
                        {
                            dr[2] = "On Account";
                            txt_onaccount.Text = Convert.ToDouble(obj_dt.Rows[i][4]).ToString("#0.00");
                        }
                        dr[3] = obj_dt.Rows[i][3].ToString();
                        dr[4] = obj_dt.Rows[i][4].ToString();
                        dr[5] = obj_dt.Rows[i][5].ToString();
                        dr[6] = obj_dt.Rows[i][2].ToString();
                        dr[7] = obj_dt.Rows[i][7].ToString();
                        dr[8] = obj_dt.Rows[i][7].ToString();

                    }

                    Grd_detail.DataSource = obj_dtAccount;
                    Grd_detail.DataBind();
                    ViewState["Payment"] = obj_dtAccount;


                    //Vino New for PAN Cust Details St [27-03-2024]
                    DataTable dtpan = new DataTable();
                    dtpan = customerobj.GetLikeCustomerpan(hid_panno.Value);

                    if (dtpan.Rows.Count > 0)
                    {
                        if (dtpan.Rows[0]["customerid"].ToString() != "")
                        {
                            for (int c = 0; c <= dtpan.Rows.Count - 1; c++)
                            {
                                hid_customerid.Value = dtpan.Rows[c]["customerid"].ToString();
                                AllDetails(0);
                            }
                        }
                        else
                        {
                            AllDetails(int_Receiptid);
                        }
                    }

                    //AllDetails(int_Receiptid);

                    //Vino New for PAN Cust Details End [27-03-2024]


                    if (txt_custamount.Text == "" || txt_custamount.Text == "0.00")
                    {
                        txt_custamount.Text = txt_amount.Text;
                    }

                }
            }
        }
        private void Fn_Clear()
        {
            txt_adjonaccount.Text = "";
            txt_adj_amount.Text = "";
            txt_onaccount.Text = "";
            txt_amount.Text = "";
            txt_excess.Text = "";
            txt_custamount.Text = "";
            ddl_module.SelectedIndex = 0;
            txt_date.Text = hid_date.Value.ToString();
            txt_receipt.Text = "";
            txt_year.Text = Session["Vouyear"].ToString();
            txt_received.Text = "";
            txt_tdsamount.Text = "-0.00";
            btn_update.Enabled = false;
            txt_adj_amount.Text = "";
            ddl_receipt.SelectedIndex = 0;
            btn_update.ForeColor = System.Drawing.Color.Gray;
            Grd_detail.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_detail.DataBind();
            btn_cancel.Text = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.Text == "Cancel")
            {
                Fn_Clear();
            }
            else
            {
                //  this.Response.End();

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
        protected void btn_update_Click(object sender, EventArgs e)
        {
            string str_Type = "";
            double Income_Amount = 0, Expence_Amount = 0, Grand_Total = 0, Customer_Amount = 0, excess = 0;
            bool Customer = false;
            int Rid = int.Parse(hid_rptid.Value.ToString());
            //DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();

            //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (double.Parse(txt_excess.Text.ToString()) >= 100 || double.Parse(txt_excess.Text.ToString()) <= -100)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Excess Amount", "alertify.alert('Adjusted Amount should not be Greater than On Account Amount');", true);
                return;
            }

            foreach (GridViewRow row in Grd_detail.Rows)
            {
                TextBox Txt = (TextBox)row.FindControl("txt_receiptamount");

                str_Type = Grd_detail.DataKeys[row.RowIndex].Values[1].ToString().Trim();
                if (str_Type == "I" || str_Type == "D" || str_Type == "V" || str_Type == "X" || str_Type == "B" || str_Type == "OI" || str_Type == "OD" || str_Type == "OV" || str_Type == "OX" || str_Type == "OB")
                {
                    Income_Amount = Income_Amount + double.Parse(Txt.Text);

                    Income_Amount = Convert.ToDouble(Income_Amount.ToString("#,0.00"));
                }
                else if (str_Type == "P" || str_Type == "C" || str_Type == "E" || str_Type == "S" || str_Type == "OP" || str_Type == "OC" || str_Type == "OE" || str_Type == "OS")
                {
                    Expence_Amount = Expence_Amount + double.Parse(Txt.Text);
                    Expence_Amount = Convert.ToDouble(Expence_Amount.ToString("#,0.00"));
                }
            }
            //excess = obj_da_Receipt.Get_excessinreceipt(Rid);
            excess = obj_da_Receipt.Get_excessinreceiptnew(Rid, Convert.ToChar(Session["rptype"].ToString()));

            if (Session["rptype"].ToString() == "R")
            {
                if (double.Parse(txt_amount.Text) == double.Parse(txt_custamount.Text)) // (Income_Amount - Expence_Amount + Convert.ToDouble(txt_tdsamount.Text) + excess)
                {
                    if (double.Parse(txt_excess.Text) < 0)
                    {
                        Grand_Total = Income_Amount + double.Parse(txt_tdsamount.Text.ToString()) + double.Parse(txt_excess.Text.ToString()) - Expence_Amount;
                        Customer = true;
                    }
                    else if (double.Parse(txt_excess.Text) >= 0)
                    {
                        Grand_Total = Income_Amount + double.Parse(txt_tdsamount.Text.ToString()) - double.Parse(txt_excess.Text.ToString()) - Expence_Amount;
                        Customer = true;
                    }
                }
                else
                {
                    Grand_Total = Income_Amount - Expence_Amount;
                }
            }
            else if (Session["rptype"].ToString() == "P")
            {
                if (double.Parse(txt_amount.Text) == double.Parse(txt_custamount.Text)) // (Income_Amount - Expence_Amount + Convert.ToDouble(txt_tdsamount.Text) + excess)
                {
                    Grand_Total = Expence_Amount + double.Parse(txt_tdsamount.Text.ToString()) - double.Parse(txt_excess.Text.ToString()) - Income_Amount;
                    Customer = true;
                }
                else
                {
                    Grand_Total = Expence_Amount - Income_Amount;
                }
            }

            if (Session["rptype"].ToString() == "P")
            {
                if (Convert.ToDouble(txt_tdsamount.Text) > 0)
                {


                    Grand_Total = Convert.ToDouble(txt_adjonaccount.Text) + Convert.ToDouble(txt_adj_amount.Text) + Convert.ToDouble(txt_tdsamount.Text);
                    Grand_Total = Convert.ToDouble(Grand_Total.ToString("#,0.00"));
                }
                else
                {
                    Grand_Total = Convert.ToDouble(txt_adjonaccount.Text) + Convert.ToDouble(txt_adj_amount.Text);
                    Grand_Total = Convert.ToDouble(Grand_Total.ToString("#,0.00"));
                }
            }
            else
            {
                Grand_Total = Convert.ToDouble(txt_adjonaccount.Text) + Convert.ToDouble(txt_adj_amount.Text);
                Grand_Total = Convert.ToDouble(Grand_Total.ToString("#,0.00"));
            }

            //Grand_Total = Convert.ToDouble(txt_adjonaccount.Text) + Convert.ToDouble(txt_adj_amount.Text);
            //Grand_Total = Convert.ToDouble(Grand_Total.ToString("#,0.00"));
            double CAmount = 0;
            if (Convert.ToDouble(txt_tdsamount.Text) != 0)
            {
                if (Customer == true)
                {
                    CAmount = Grand_Total + Convert.ToDouble(txt_excess.Text);
                    //if (Convert.ToDouble(txt_excess.Text) > 0)
                    //{
                    //    CAmount = (Grand_Total + Convert.ToDouble(txt_excess.Text));
                    //}
                    //else
                    //{
                    //    CAmount = (Grand_Total - Convert.ToDouble(txt_excess.Text));

                    //}

                }
                else
                {
                    CAmount = Grand_Total + Convert.ToDouble(txt_excess.Text);
                    //if (Convert.ToDouble(txt_excess.Text) > 0)
                    //{
                    //    CAmount = (Grand_Total + Convert.ToDouble(txt_excess.Text) + Convert.ToDouble(txt_tdsamount.Text));
                    //}
                    //else
                    //{
                    //    CAmount = (Grand_Total - Convert.ToDouble(txt_excess.Text) + Convert.ToDouble(txt_tdsamount.Text));
                    //}

                }


            }
            else
            {
                if (Customer == true)
                {
                    CAmount = Grand_Total;
                }
                else
                {
                    CAmount = Grand_Total + Convert.ToDouble(txt_excess.Text);
                    //if (Convert.ToDouble(txt_excess.Text) > 0)
                    //{
                    //    CAmount = (Grand_Total + Convert.ToDouble(txt_excess.Text));
                    //}
                    //else
                    //{
                    //    CAmount = (Grand_Total - Convert.ToDouble(txt_excess.Text));

                    //}
                }


            }
            //if (Grand_Total <= double.Parse(txt_custamount.Text.ToString()))
            if (double.Parse(txt_amount.Text.ToString()) <= CAmount && (double.Parse(txt_excess.Text.ToString()) <= 100 || double.Parse(txt_excess.Text.ToString()) >= -100))
            {
                if (Customer == true && txt_tdsamount.Text != "-0.00")
                {
                    obj_da_Receipt.DelCustChrgs(Rid, 1060, "Ch", Convert.ToChar(Session["rptype"].ToString()));
                    obj_da_Receipt.DelCustChrgs(Rid, 5068, "Ch", Convert.ToChar(Session["rptype"].ToString()));
                    obj_da_Receipt.DelCustChrgsonacc(Rid, 5068, "Ch", Convert.ToChar(Session["rptype"].ToString()));
                    if (Session["rptype"].ToString() == "R")
                    {
                        obj_da_Receipt.InsReciptChargeDetail(Rid, 5068, double.Parse(txt_tdsamount.Text.ToString()), Convert.ToChar(Session["rptype"].ToString()));
                    }

                    Customer_Amount = (double.Parse(txt_amount.Text.ToString()) - double.Parse(txt_tdsamount.Text.ToString()) - (excess));
                    obj_da_Receipt.UpdRecptCustAmt(Rid, int.Parse(hid_customerid.Value.ToString()), Customer_Amount, Convert.ToChar(Session["rptype"].ToString()));
                    //obj_da_Receipt.DelCustChrgs(Rid, 1060, "Ch");
                    //obj_da_Receipt.DelCustChrgs(Rid, 2011, "Ch");
                    //obj_da_Receipt.InsReciptChargeDetail(Rid, 2011, double.Parse(txt_tdsamount.Text.ToString()));
                    //Customer_Amount = (double.Parse(txt_amount.Text.ToString()) - double.Parse(txt_tdsamount.Text.ToString()) - (excess));
                    //obj_da_Receipt.UpdRecptCustAmt(Rid, int.Parse(hid_customerid.Value.ToString()), Customer_Amount);
                }
                else if (txt_tdsamount.Text != "-0.00")
                {
                    //obj_da_Receipt.DelCustChrgs(Rid, 1060, "Ch", Convert.ToChar(Session["rptype"].ToString()));
                    obj_da_Receipt.DelCustChrgs(Rid, 5068, "Ch", Convert.ToChar(Session["rptype"].ToString()));
                    obj_da_Receipt.DelCustChrgsonacc(Rid, 5068, "Ch", Convert.ToChar(Session["rptype"].ToString()));
                    if (Session["rptype"].ToString() == "R")
                    {
                        obj_da_Receipt.InsReciptChargeDetail(Rid, 5068, double.Parse(txt_tdsamount.Text.ToString()), Convert.ToChar(Session["rptype"].ToString()));
                    }
                    Customer_Amount = (double.Parse(txt_amount.Text.ToString()) - double.Parse(txt_tdsamount.Text.ToString()) - (excess));
                    obj_da_Receipt.UpdRecptCustAmt(Rid, int.Parse(hid_customerid.Value.ToString()), Customer_Amount, Convert.ToChar(Session["rptype"].ToString()));
                    //obj_da_Receipt.DelCustChrgs(Rid, 1060, "Ch");
                    //obj_da_Receipt.DelCustChrgs(Rid, 2011, "Ch");
                    //obj_da_Receipt.InsReciptChargeDetail(Rid, 2011, double.Parse(txt_tdsamount.Text.ToString()));
                    //Customer_Amount = (double.Parse(txt_amount.Text.ToString()) - double.Parse(txt_tdsamount.Text.ToString()) - (excess));
                    //obj_da_Receipt.UpdRecptCustAmt(Rid, int.Parse(hid_customerid.Value.ToString()), Customer_Amount);
                }

                //RAJA CAHNGE
                //if (txt_excess.Text != "0.00")
                //{
                //    double excesssss = 0;
                //    excesssss = Convert.ToDouble(txt_excess.Text);
                //    excess = Convert.ToDouble(excesssss.ToString("#,0.00"));
                //    obj_da_Receipt.InsReciptChargeDetail(Rid, 0, excess);
                //}
                obj_da_Receipt.DelRecAgInv(Rid, Convert.ToChar(Session["rptype"].ToString()));

                char Setteled;
                string V_type;
                int int_branchid = 0, int_invoiceno = 0, int_Ryear = 0;
                double VoucherAmount = 0, ramt = 0;

                foreach (GridViewRow row in Grd_detail.Rows)
                {
                    TextBox Txt = (TextBox)row.FindControl("txt_receiptamount");
                    ramt = double.Parse(Txt.Text.ToString());
                    V_type = Grd_detail.DataKeys[row.RowIndex].Values[1].ToString().Trim();

                    if (ramt > 0 && V_type != "O")
                    {
                        int_branchid = int.Parse(Grd_detail.DataKeys[row.RowIndex].Values[0].ToString());
                        int_invoiceno = int.Parse(Grd_detail.DataKeys[row.RowIndex].Values[2].ToString());
                        int_Ryear = int.Parse(Grd_detail.Rows[row.RowIndex].Cells[5].Text.ToString());
                        VoucherAmount = double.Parse(Grd_detail.Rows[row.RowIndex].Cells[2].Text.ToString());

                        if (VoucherAmount > ramt)
                        {
                            Setteled = 'N';
                        }
                        else
                        {
                            Setteled = 'Y';
                        }
                        obj_da_Receipt.InsRecptAginstInvnew(Rid, Convert.ToChar(Session["rptype"].ToString()), int_invoiceno, V_type, int_branchid, VoucherAmount, ramt, Setteled, int_Ryear);

                        try
                        {
                            obj_da_Approval.UpdLedgerOPBreakupnew(int_invoiceno, V_type, int_Ryear, int_branchid, Rid, 'R', int.Parse(txt_year.Text), ramt, "", 0.0, "", "");
                            // obj_da_Approval.UpdLedgerOPBreakup(int_invoiceno, V_type, int_Ryear, int_branchid, Rid, 'R', int.Parse(txt_year.Text), ramt, "", 0, "", "");

                        }
                        catch (Exception Ex)
                        {
                        }
                    }
                }
                double OnAmount = 0;
                if (txt_excess.Text != null || txt_excess.Text != " ")
                {
                    if (Convert.ToDouble(txt_excess.Text) < 100 && Convert.ToDouble(txt_excess.Text) > -100)
                    {
                        if (txt_excess.Text != "0.00")
                        {
                            double excesssss = 0;
                            excesssss = Convert.ToDouble(txt_excess.Text);
                            //excess = Math.Abs(Convert.ToDouble(excesssss.ToString("#,0.00")));
                            obj_da_Receipt.InsReciptChargeDetail(Rid, 0, excesssss, Convert.ToChar(Session["rptype"].ToString()));
                            // OnAmount=0
                        }
                    }
                    else
                    {
                        OnAmount = Math.Abs(Convert.ToDouble(txt_excess.Text));

                    }
                }
                //double OnAmount = ((double.Parse(txt_custamount.Text)) - Grand_Total - Convert.ToDouble(txt_excess.Text)); //+ Convert.ToDouble(txt_tdsamount.Text)
                OnAmount = Convert.ToDouble(txt_adjonaccount.Text);
                if (OnAmount > 0)
                {
                    foreach (GridViewRow row in Grd_detail.Rows)
                    {
                        TextBox Txt = (TextBox)row.FindControl("txt_receiptamount");
                        ramt = double.Parse(Txt.Text.ToString());
                        char R_type;
                        R_type = char.Parse(Grd_detail.DataKeys[row.RowIndex].Values[1].ToString().Trim());

                        if (R_type == 'O')
                        {
                            HttpContext.Current.Session["OnAccountVoutypeEdi"] = R_type;
                            int_Ryear = int.Parse(Grd_detail.DataKeys[row.RowIndex].Values[3].ToString());
                            obj_da_Receipt.InsRecptAginstInv(Rid, Convert.ToChar(Session["rptype"].ToString()), 0, 'O', int.Parse(Session["LoginBranchid"].ToString()), 0, OnAmount, 'Y', int_Ryear);
                            int int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(hid_customerid.Value.ToString()), "C", Session["FADbname"].ToString());
                            obj_da_Approval.InsLedgerOPBreakup4OAC(int_Ledgerid, int_Ryear, int_branchid, Rid, Convert.ToChar(Session["rptype"].ToString()), int_Ryear, OnAmount, int.Parse(hid_customerid.Value.ToString()));
                        }


                    }
                }
                //if (OnAmount > 0)
                //{
                //    obj_da_Receipt.InsRecptAginstInv(Rid, 'R', 0, 'O', int.Parse(Session["LoginBranchid"].ToString()), 0, OnAmount, 'Y', int_Ryear);
                //    int int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(hid_customerid.Value.ToString()), "C", Session["FADbname"].ToString());
                //    obj_da_Approval.InsLedgerOPBreakup4OAC(int_Ledgerid, int_Ryear, int_branchid, Rid, 'R', int_Ryear, OnAmount, int.Parse(hid_customerid.Value.ToString()));
                //}

                try
                {
                    //DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
                    DataTable obj_dt = new DataTable();
                    int int_Voucherid = 0;
                    string Str_Vouchertype = "";

                    if (Session["Vouyear"].ToString() == txt_year.Text)
                    {
                        Session["AgainstVou"] = null;
                    }
                    else
                    {
                        GetFADBvou(Convert.ToInt32(txt_year.Text));
                    }
                    


                    //DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
                    int corbid = Emp_Obj.GetBranchId(int_divisionid, "CORPORATE");


                    //DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    DataTable dt1 = new DataTable();
                    string retransfer = "N";
                    double dbtot = 0.00, crtot = 0.00, jdbtot = 0.00, jcrtot = 0.00;
                    int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    int Vouyear = Convert.ToInt32(txt_year.Text);
                    log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(OnAccToAgainsVou));
                    log4net.Config.BasicConfigurator.Configure();


                    // Update for Trigger 
                    obj_da_Receipt.UpdRecptPymt4trigger(Convert.ToInt32(txt_receipt.Text), int.Parse(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["rptype"].ToString(), ddl_module.SelectedValue.ToString());
                

                    if (ddl_module.SelectedValue.ToString() == "C")
                    {
                        if (Session["rptype"].ToString() == "R")
                        {
                            //obj_dt = obj_da_FA.GetRepostDetails(int.Parse(txt_receipt.Text.ToString()), 10, int.Parse(Session["LoginBranchid"].ToString()), 0, corbid, "Voucher", Session["FADbname"].ToString());
                            //obj_da_Receipt.SpDelRecPay(Convert.ToInt32(txt_receipt.Text), 10, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Voucher", Session["FADbname"].ToString());

                            //Str_Vouchertype = "Cash Receipt";

                            ///***************************************************************/
                            //log1.Info("Before Re-Transfer : (Voutype- " + Str_Vouchertype + " | Vouno-" + int.Parse(txt_receipt.Text.ToString()) + " | Branchid- " + bid + " |Vouyear- " + Vouyear + " |DbName- " + Session["FADbname"].ToString() + ")");
                            //ds = objrv.GetRecPymtVoucherMail(Convert.ToInt32(txt_receipt.Text), "CR", bid, Vouyear, Session["FADbname"].ToString());
                            ///***************************************************************/

                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            //obj_dt = obj_da_FA.GetRepostDetails(int.Parse(txt_receipt.Text.ToString()), 12, int.Parse(Session["LoginBranchid"].ToString()), 0, corbid, "Voucher", Session["FADbname"].ToString());
                            //obj_da_Receipt.SpDelRecPay(Convert.ToInt32(txt_receipt.Text), 12, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Voucher", Session["FADbname"].ToString());

                            //Str_Vouchertype = "Cash Payment";


                            ///***************************************************************/
                            //log1.Info("Before Re-Transfer : (Voutype- " + Str_Vouchertype + " | Vouno-" + int.Parse(txt_receipt.Text.ToString()) + " | Branchid- " + bid + " |Vouyear- " + Vouyear + " |DbName- " + Session["FADbname"].ToString() + ")");
                            //ds = objrv.GetRecPymtVoucherMail(Convert.ToInt32(txt_receipt.Text), "CP", bid, Vouyear, Session["FADbname"].ToString());
                            /***************************************************************/


                        }
                        //logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_Vouchertype, int.Parse(txt_receipt.Text.ToString()), int.Parse(txt_receipt.Text.ToString()), "", "", Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                    }
                    else if (ddl_module.SelectedValue.ToString() == "B")
                    {
                        if (Session["rptype"].ToString() == "R")
                        {
                            //obj_dt = obj_da_FA.GetRepostDetails(int.Parse(txt_receipt.Text.ToString()), 9, int.Parse(Session["LoginBranchid"].ToString()), 0, corbid, "Voucher", Session["FADbname"].ToString());
                            //obj_da_Receipt.SpDelRecPay(Convert.ToInt32(txt_receipt.Text), 9, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Voucher", Session["FADbname"].ToString());

                            //Str_Vouchertype = "Bank Receipt";

                            ///***************************************************************/
                            //log1.Info("Before Re-Transfer : (Voutype- " + Str_Vouchertype + " | Vouno-" + int.Parse(txt_receipt.Text.ToString()) + " | Branchid- " + bid + " |Vouyear- " + Vouyear + " |DbName- " + Session["FADbname"].ToString() + ")");
                            //ds = objrv.GetRecPymtVoucherMail(Convert.ToInt32(txt_receipt.Text), "BR", bid, Vouyear, Session["FADbname"].ToString());
                            ///***************************************************************/


                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            //obj_dt = obj_da_FA.GetRepostDetails(int.Parse(txt_receipt.Text.ToString()), 11, int.Parse(Session["LoginBranchid"].ToString()), 0, corbid, "Voucher", Session["FADbname"].ToString());
                            //obj_da_Receipt.SpDelRecPay(Convert.ToInt32(txt_receipt.Text), 11, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Voucher", Session["FADbname"].ToString());

                            //Str_Vouchertype = "Bank Payment";


                            ///***************************************************************/
                            //log1.Info("Before Re-Transfer : (Voutype- " + Str_Vouchertype + " | Vouno-" + int.Parse(txt_receipt.Text.ToString()) + " | Branchid- " + bid + " |Vouyear- " + Vouyear + " |DbName- " + Session["FADbname"].ToString() + ")");
                            //ds = objrv.GetRecPymtVoucherMail(Convert.ToInt32(txt_receipt.Text), "BP", bid, Vouyear, Session["FADbname"].ToString());
                            /***************************************************************/

                        }
                        // logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_Vouchertype, int.Parse(txt_receipt.Text.ToString()), int.Parse(txt_receipt.Text.ToString()), "", "", "");
                        //logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_Vouchertype, int.Parse(txt_receipt.Text.ToString()), int.Parse(txt_receipt.Text.ToString()), "", "", Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                        
                    }


                    dt = ds.Tables[2];
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        dt1 = ds.Tables[3];
                    }

                    if (dt.Rows.Count > 0)
                    {
                        dbtot = Convert.ToDouble(dt.Compute("SUM(Debit)", string.Empty));
                        crtot = Convert.ToDouble(dt.Compute("SUM(Credit)", string.Empty));
                    }
                    if (dt1.Rows.Count > 0)
                    {
                        jdbtot = Convert.ToDouble(dt1.Compute("SUM(Debit)", string.Empty));
                        jcrtot = Convert.ToDouble(dt1.Compute("SUM(Credit)", string.Empty));
                    }

                    if (dbtot != crtot || jdbtot != jcrtot)
                    {
                        retransfer = "Y";
                    }
                    if (retransfer == "Y")
                    {
                        //log1.Info("Re-Transfer : (Voutype- " + Str_Vouchertype + " | Vouno-" + int.Parse(txt_receipt.Text.ToString()) + " | Branchid- " + bid + " |Vouyear- " + Vouyear + " |DbName- " + Session["FADbname"].ToString() + ")");

                        //logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_Vouchertype, int.Parse(txt_receipt.Text.ToString()), int.Parse(txt_receipt.Text.ToString()), "", "", bid);
                        //log1.Info("After Re-Transfer : (Voutype- " + Str_Vouchertype + " | Vouno-" + int.Parse(txt_receipt.Text.ToString()) + " | Branchid- " + bid + " |Vouyear- " + Vouyear + " |DbName- " + Session["FADbname"].ToString() + ")");
                    }



                    //if (obj_dt.Rows.Count == 1)
                    //{
                    //    int_Voucherid = int.Parse(obj_dt.Rows[0]["vouid"].ToString());
                    //    obj_da_FA.Delvoudetail(int_Voucherid, Session["FADbname"].ToString(), "Delete");

                    //    if (ddl_module.SelectedValue.ToString() == "B")
                    //    {

                    //        DataAccess.checkvouchercount CntObj = new DataAccess.checkvouchercount();
                    //        CntObj.DelAutoJV4Fa(Rid, int.Parse(txt_receipt.Text.ToString()), int.Parse(Session["LoginBranchid"].ToString()), "Delete", Session["FADbname"].ToString(), Session["rptype"].ToString());
                    //    }
                    //    logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_Vouchertype, int.Parse(txt_receipt.Text.ToString()), int.Parse(txt_receipt.Text.ToString()), "", "", Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                    //}


                  /*  if (ddl_module.SelectedValue.ToString() == "C")
                    {
                        if (Session["rptype"].ToString() == "R")
                        {
                            obj_da_Receipt.SpDelRecPay(Convert.ToInt32(txt_receipt.Text), 10, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Voucher", Session["FADbname"].ToString());
                            //obj_dt = obj_da_FA.GetRepostDetails(int.Parse(txt_receipt.Text.ToString()), 10, int.Parse(Session["LoginBranchid"].ToString()), 0, 0, "Voucher", Session["FADbname"].ToString());
                            Str_Vouchertype = "Cash Receipt";
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            obj_da_Receipt.SpDelRecPay(Convert.ToInt32(txt_receipt.Text), 12, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Voucher", Session["FADbname"].ToString());
                            //obj_dt = obj_da_FA.GetRepostDetails(int.Parse(txt_receipt.Text.ToString()), 12, int.Parse(Session["LoginBranchid"].ToString()), 0, 0, "Voucher", Session["FADbname"].ToString());
                            Str_Vouchertype = "Cash Payment";
                        }
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_Vouchertype, int.Parse(txt_receipt.Text.ToString()), int.Parse(txt_receipt.Text.ToString()), "", "", "");
                    }
                    else if (ddl_module.SelectedValue.ToString() == "B")
                    {
                        if (Session["rptype"].ToString() == "R")
                        {
                            obj_da_Receipt.SpDelRecPay(Convert.ToInt32(txt_receipt.Text), 9, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Voucher", Session["FADbname"].ToString());
                            //obj_dt = obj_da_FA.GetRepostDetails(int.Parse(txt_receipt.Text.ToString()), 9, int.Parse(Session["LoginBranchid"].ToString()), 0, 0, "Voucher", Session["FADbname"].ToString());
                            Str_Vouchertype = "Bank Receipt";
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            obj_da_Receipt.SpDelRecPay(Convert.ToInt32(txt_receipt.Text), 11, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Voucher", Session["FADbname"].ToString());
                            // obj_dt = obj_da_FA.GetRepostDetails(int.Parse(txt_receipt.Text.ToString()), 11, int.Parse(Session["LoginBranchid"].ToString()), 0, 0, "Voucher", Session["FADbname"].ToString());
                            Str_Vouchertype = "Bank Payment";
                        }
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_Vouchertype, int.Parse(txt_receipt.Text.ToString()), int.Parse(txt_receipt.Text.ToString()), "", "", "");


                    }
                    if (obj_dt.Rows.Count == 1)
                    {
                        int_Voucherid = int.Parse(obj_dt.Rows[0]["vouid"].ToString());
                        obj_da_FA.Delvoudetail(int_Voucherid, Session["FADbname"].ToString(), "Delete");

                        if (ddl_module.SelectedValue.ToString() == "B")
                        {

                            DataAccess.checkvouchercount CntObj = new DataAccess.checkvouchercount();
                            CntObj.DelAutoJV4Fa(Rid, int.Parse(txt_receipt.Text.ToString()), int.Parse(Session["LoginBranchid"].ToString()), "Delete", Session["FADbname"].ToString());
                        }
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_Vouchertype, int.Parse(txt_receipt.Text.ToString()), int.Parse(txt_receipt.Text.ToString()), "", "", "");
                    }*/
                }
                catch (Exception Ex)
                {

                }

                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1167, 2, int.Parse(Session["LoginBranchid"].ToString()), "RID:" + Rid + "/RNo:" + txt_receipt.Text + "/VouYr: " + txt_year.Text);
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "OnAccount", "alertify.alert('OnAccount Transfered To Against Voucher');", true);
                Fn_Clear();
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "OnAccount", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                return;
            }
        }

        private void GetFADBvou(int vyearp)
        {
            string FAYear1, FADbname;
            int vyear1;
            vyear1 = vyearp;
            FAYear1 = vyear1.ToString();
            FAYear1 = FAYear1.Substring(2, 2);
            vyear1 = vyear1 + 1;
            FAYear1 = FAYear1 + Convert.ToString(vyear1).Substring(2, 2);
            FADbname = "FA" + FAYear1;
            Session["FADbname"] = FADbname;
            Session["AgainstVouYear"] = vyearp;
            Session["AgainstVou"] = "True";
        }


        protected void ddl_module_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_module.Text == "Cash")
            {
                char_Mode = 'C';
            }
            else
            {
                char_Mode = 'B';
            }
            btn_cancel.Text = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void ddl_module_TextChanged(object sender, EventArgs e)
        {
            Fn_Getdetail();
        }

        protected void txt_tdsamount_TextChanged(object sender, EventArgs e)
        {
            if (txt_tdsamount.Text == "")
            {
                txt_tdsamount.Text = "-0.00";
            }
            else
            {
                double ded = 0;

                if (txt_tdsamount.Text.Contains("-") == false)
                {
                    txt_tdsamount.Text = string.Format(ded.ToString(), "-0.00");
                }
                else
                {
                    txt_tdsamount.Text = string.Format(ded.ToString(), "0.00");
                }
            }
        }

        protected void txt_receiptamount_TextChanged(object sender, EventArgs e)
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

            foreach (GridViewRow row in Grd_detail.Rows)
            {
                TextBox Txt = (TextBox)row.FindControl("txt_receiptamount");
                if (double.Parse(Txt.Text.ToString()) != 0.00 && Grd_detail.Rows[row.RowIndex].Cells[1].Text.ToString() == "On Account")
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
            calculation();

            GridViewRow row2 = (sender as TextBox).Parent.Parent as GridViewRow;

            int index = row2.RowIndex;
            if (index != Grd_detail.Rows.Count - 1)
            {
                TextBox chk = (TextBox)Grd_detail.Rows[index + 1].Cells[3].FindControl("txt_receiptamount");
                CheckBox Chk = (CheckBox)Grd_detail.Rows[RowIndex].FindControl("Chkrecpfc");
                if (chk.Text != "" || chk.Text != "0.00")
                {
                    Chk.Checked = true;
                }
                else if (chk.Text == "0.00")
                {
                    Chk.Checked = false;
                }
                chk.Focus();
            }
            ExcessCalc();
            Grd_detail.Rows[RowIndex].BackColor = System.Drawing.Color.Cyan;
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
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            JobInput.Text = "";

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1167, "MSGroup", "", "", Session["StrTranType"].ToString());

            //if (txtname.Text != "")
            //{
            //    JobInput.Text = txtname.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
        protected void Chkrecpfc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double Total = 0, Total1 = 0;
                double VouAmt = 0, actamount = 0, GrdAmnt = 0.00;
                foreach (GridViewRow row in Grd_detail.Rows)
                {
                    double vamountt = 0;
                    CheckBox chk = (CheckBox)row.FindControl("Chkrecpfc");
                    TextBox text = (TextBox)row.FindControl("txt_receiptamount");
                    if (chk.Checked == true && Grd_detail.Rows[row.RowIndex].Cells[1].Text != "On Account" && text.Text == "0.00")
                    {

                        vamountt = Convert.ToDouble(Grd_detail.Rows[row.RowIndex].Cells[2].Text);

                        TextBox Txt = (TextBox)row.FindControl("txt_receiptamount");
                        Txt.Text = vamountt.ToString("#,0.00");
                        if (double.Parse(Txt.Text.ToString()) != 0)
                        {
                            VouAmt = VouAmt + double.Parse(Txt.Text);
                        }



                        if (VouAmt != 0.00 && Grd_detail.Rows[row.RowIndex].Cells[1].Text.ToString() == "On Account")
                        {
                            actamount = actamount + double.Parse(Grd_detail.Rows[row.RowIndex].Cells[2].Text.ToString());
                        }


                        // int RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
                        // TextBox TxtAmount = ((TextBox)Grd_detail.Rows[RowIndex].FindControl("txt_receiptamount"));

                        if (Grd_detail.Rows[row.RowIndex].Cells[2].Text.ToString() != null)
                        {
                            if (double.TryParse(Grd_detail.Rows[row.RowIndex].Cells[2].Text.ToString(), out GrdAmnt))
                            {
                                if (Convert.ToDouble(Grd_detail.Rows[row.RowIndex].Cells[2].Text.ToString()) < Convert.ToDouble(Txt.Text))
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Adjustment Amount should not be greater than Voucher Amount')", true);
                                    Txt.Text = "0.00";
                                    return;
                                }
                            }
                        }

                        Grd_detail.Rows[row.RowIndex].BackColor = System.Drawing.Color.Cyan;
                    }


                    else if ((chk.Checked == false && text.Text != "0.00") && Grd_detail.Rows[row.RowIndex].Cells[1].Text != "On Account")
                    {
                        text.Text = "0.00";
                        Grd_detail.Rows[row.RowIndex].BackColor = System.Drawing.Color.Empty;

                    }

                }
                calculation();
                ExcessCalc();
                CheckBox Chk1 = sender as CheckBox;
                GridViewRow row2 = (GridViewRow)Chk1.NamingContainer;
                List<string> ItemText = null;
                Boolean Check = false;
                int count = 0;
                if (Grd_detail.Rows.Count > 0)
                {

                    GridViewRow row3 = (sender as CheckBox).Parent.Parent as GridViewRow;

                    int index = row3.RowIndex;
                    if (index != Grd_detail.Rows.Count - 1)
                    {
                        CheckBox chk = (CheckBox)Grd_detail.Rows[index + 1].Cells[4].FindControl("Chkrecpfc");
                        chk.Focus();
                    }

                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Grd_detail_CellContentClick(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > 0)
            {
                int rowindex = e.Row.RowIndex;
                GridViewRow row = this.Grd_detail.Rows[rowindex];
            }

        }
        protected void Grd_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) != 0)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    if (double.TryParse(e.Row.Cells[2].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[2].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[3].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[3].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                    }

                    if (i == 4)
                    {

                    }
                    else
                    {
                        e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    }

                    Control c = e.Row.Cells[3].Controls[0];
                    this.SetFocus(c);

                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_detail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }
        private void BOS()
        {
            DataTable obj_dtAccount = new DataTable();
            DataRow dr;
            int_Custid = Convert.ToInt32(hid_customerid.Value);
            obj_dt = obj_da_Receipt.GetInvRecptDtls1BOS(int_Custid, int_divisionid);
            if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
            {
                obj_dtAccount = (DataTable)ViewState["Payment"];
                b = obj_dtAccount.Rows.Count;
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (b == 0)
                {
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                }
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
                    dr[8] = obj_dt.Rows[i][6].ToString();
                }
                Grd_detail.DataSource = obj_dtAccount;
                Grd_detail.DataBind();
                ViewState["Payment"] = obj_dtAccount;
            }


        }
        private void all()
        {
            DataTable obj_dtAccount = new DataTable();
            DataRow dr;
            int_Custid = Convert.ToInt32(hid_customerid.Value);
            obj_dt = obj_da_Receipt.GetlvRecptDtls1new(int_Custid, int_divisionid);
            if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
            {
                obj_dtAccount = (DataTable)ViewState["Payment"];
                b = obj_dtAccount.Rows.Count;
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (b == 0)
                {
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                }
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtAccount.NewRow();
                    obj_dtAccount.Rows.Add(dr);

                    dr[0] = obj_dt.Rows[i][0].ToString();
                    dr[1] = obj_dt.Rows[i][1].ToString();

                    if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "I")
                    {
                        dr[2] = "INV - " + obj_dt.Rows[i][2].ToString();
                    }
                    else if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "P")
                    {
                        dr[2] = "CN-Ops - " + obj_dt.Rows[i][2].ToString();
                    }
                    else if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "S")
                    {
                        dr[2] = "ADN - " + obj_dt.Rows[i][2].ToString();
                    }
                    else if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "X")
                    {
                        dr[2] = "ACN - " + obj_dt.Rows[i][2].ToString();
                    }
                    else if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "D")
                    {
                        dr[2] = "OSDN - " + obj_dt.Rows[i][2].ToString();
                    }
                    else if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "C")
                    {
                        dr[2] = "OSCN - " + obj_dt.Rows[i][2].ToString();
                    }
                    else if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "V")
                    {
                        dr[2] = "DN - " + obj_dt.Rows[i][2].ToString();
                    }
                    else if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "E")
                    {
                        dr[2] = "CN - " + obj_dt.Rows[i][2].ToString();
                    }
                    else if (obj_dt.Rows[i]["voutype"].ToString().Trim() == "B")
                    {
                        dr[2] = "BOS - " + obj_dt.Rows[i][2].ToString();
                    }

                    //dr[2] = "Inv - " + obj_dt.Rows[i][2].ToString();
                    dr[3] = obj_dt.Rows[i][3].ToString();
                    dr[4] = obj_dt.Rows[i][4].ToString();
                    dr[5] = obj_dt.Rows[i][5].ToString();
                    dr[6] = obj_dt.Rows[i][2].ToString();
                    dr[7] = obj_dt.Rows[i][6].ToString();
                    dr[8] = obj_dt.Rows[i][6].ToString();
                }
                Grd_detail.DataSource = obj_dtAccount;
                Grd_detail.DataBind();
                ViewState["Payment"] = obj_dtAccount;
            }


        }
        private void Invoices()
        {
            DataTable obj_dtAccount = new DataTable();
            DataRow dr;
            int_Custid = Convert.ToInt32(hid_customerid.Value);
            obj_dt = obj_da_Receipt.GetInvRecptDtls1(int_Custid, int_divisionid);
            if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
            {
                obj_dtAccount = (DataTable)ViewState["Payment"];
                b = obj_dtAccount.Rows.Count;
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (b == 0)
                {
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                }
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
                    dr[8] = obj_dt.Rows[i][6].ToString();
                }
                Grd_detail.DataSource = obj_dtAccount;
                Grd_detail.DataBind();
                ViewState["Payment"] = obj_dtAccount;
            }


        }
        private void DN()
        {
            DataTable obj_dtAccount = new DataTable();
            DataRow dr;
            int_Custid = Convert.ToInt32(hid_customerid.Value);
            obj_dt = obj_da_Receipt.GetDN(int_Custid, int_divisionid);
            if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
            {
                obj_dtAccount = (DataTable)ViewState["Payment"];
                b = obj_dtAccount.Rows.Count;
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (b == 0)
                {
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                }
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
                    dr[8] = obj_dt.Rows[i][6].ToString();
                }
                Grd_detail.DataSource = obj_dtAccount;
                Grd_detail.DataBind();
                ViewState["Payment"] = obj_dtAccount;
            }
        }
        private void ADN()
        {
            DataTable obj_dtAccount = new DataTable();
            DataRow dr;
            int_Custid = Convert.ToInt32(hid_customerid.Value);
            obj_dt = obj_da_Receipt.GetAdminDN(int_Custid, int_divisionid);
            if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
            {
                obj_dtAccount = (DataTable)ViewState["Payment"];
                b = obj_dtAccount.Rows.Count;
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (b == 0)
                {
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                }
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
                    dr[8] = obj_dt.Rows[i][6].ToString();
                }
                Grd_detail.DataSource = obj_dtAccount;
                Grd_detail.DataBind();
                ViewState["Payment"] = obj_dtAccount;
            }
        }
        private void CN()
        {


            DataTable obj_dtAccount = new DataTable();
            DataRow dr;
            int_Custid = Convert.ToInt32(hid_customerid.Value);
            obj_dt = obj_da_payment.GetCN(int_Custid, int_divisionid);
            if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
            {
                obj_dtAccount = (DataTable)ViewState["Payment"];
                b = obj_dtAccount.Rows.Count;
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (b == 0)
                {
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                }
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtAccount.NewRow();
                    obj_dtAccount.Rows.Add(dr);

                    dr[0] = obj_dt.Rows[i][0].ToString();
                    dr[1] = obj_dt.Rows[i][1].ToString();
                    dr[2] = "CN - " + obj_dt.Rows[i][2].ToString();
                    dr[3] = obj_dt.Rows[i][3].ToString();
                    dr[4] = obj_dt.Rows[i][4].ToString();
                    dr[5] = obj_dt.Rows[i][5].ToString();
                    dr[6] = obj_dt.Rows[i][2].ToString();
                    dr[7] = obj_dt.Rows[i][6].ToString();
                    dr[8] = obj_dt.Rows[i][7].ToString();
                }
                Grd_detail.DataSource = obj_dtAccount;
                Grd_detail.DataBind();
                ViewState["Payment"] = obj_dtAccount;
            }
        }
        private void ACN()
        {
            DataTable obj_dtAccount = new DataTable();
            DataRow dr;
            int_Custid = Convert.ToInt32(hid_customerid.Value);
            obj_dt = obj_da_payment.GetAdminCN(int_Custid, int_divisionid);
            if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
            {
                obj_dtAccount = (DataTable)ViewState["Payment"];
                b = obj_dtAccount.Rows.Count;
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (b == 0)
                {
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                }
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtAccount.NewRow();
                    obj_dtAccount.Rows.Add(dr);

                    dr[0] = obj_dt.Rows[i][0].ToString();
                    dr[1] = obj_dt.Rows[i][1].ToString();
                    dr[2] = "ACN - " + obj_dt.Rows[i][2].ToString();
                    dr[3] = obj_dt.Rows[i][3].ToString();
                    dr[4] = obj_dt.Rows[i][4].ToString();
                    dr[5] = obj_dt.Rows[i][5].ToString();
                    dr[6] = obj_dt.Rows[i][2].ToString();
                    dr[7] = obj_dt.Rows[i][6].ToString();
                    dr[8] = obj_dt.Rows[i][7].ToString();
                }
                Grd_detail.DataSource = obj_dtAccount;
                Grd_detail.DataBind();
                ViewState["Payment"] = obj_dtAccount;
            }
        }
        private void PA()
        {
            DataTable obj_dtAccount = new DataTable();
            DataRow dr;
            int_Custid = Convert.ToInt32(hid_customerid.Value);
            obj_dt = obj_da_payment.GetPAPaymentDtls1(int_Custid, int_divisionid);
            if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
            {
                obj_dtAccount = (DataTable)ViewState["Payment"];
                b = obj_dtAccount.Rows.Count;
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (b == 0)
                {
                    obj_dtAccount.Columns.Add("branch");
                    obj_dtAccount.Columns.Add("port");
                    obj_dtAccount.Columns.Add("invoiceno");
                    obj_dtAccount.Columns.Add("iamount");
                    obj_dtAccount.Columns.Add("ramount");
                    obj_dtAccount.Columns.Add("voutype");
                    obj_dtAccount.Columns.Add("vouno");
                    obj_dtAccount.Columns.Add("ravouyear");
                    obj_dtAccount.Columns.Add("vouyear");
                }
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtAccount.NewRow();
                    obj_dtAccount.Rows.Add(dr);

                    dr[0] = obj_dt.Rows[i][0].ToString();
                    dr[1] = obj_dt.Rows[i][1].ToString();
                    dr[2] = "CNOps - " + obj_dt.Rows[i][2].ToString();
                    dr[3] = obj_dt.Rows[i][3].ToString();
                    dr[4] = obj_dt.Rows[i][4].ToString();
                    dr[5] = obj_dt.Rows[i][5].ToString();
                    dr[6] = obj_dt.Rows[i][2].ToString();
                    dr[7] = obj_dt.Rows[i][6].ToString();
                    dr[8] = obj_dt.Rows[i][7].ToString();
                }
                Grd_detail.DataSource = obj_dtAccount;
                Grd_detail.DataBind();
                ViewState["Payment"] = obj_dtAccount;
            }
        }
        private void AllDetails(int receiptid)
        {
            try
            {


                hid_receiptid.Value = Convert.ToInt32(receiptid).ToString();
                DataTable obj_dtAccount = new DataTable();
                DataRow dr;
                double Total = 0;
                if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
                {
                    obj_dtAccount = (DataTable)ViewState["Payment"];
                    b = obj_dtAccount.Rows.Count;
                }

                if (hid_receiptid.Value != "0")
                {
                    if (Session["rptype"].ToString() == "R")
                    {
                        obj_dttemp = obj_da_Receipt.GetRecptCust(Convert.ToInt32(hid_receiptid.Value));
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        obj_dttemp = obj_da_payment.GetPaymentCust(Convert.ToInt32(hid_receiptid.Value));
                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        for (int j = 0; j < obj_dttemp.Rows.Count; j++)
                        {
                            Total = Total + double.Parse(obj_dttemp.Rows[j][1].ToString());
                            int_Custid = int.Parse(obj_dttemp.Rows[j][2].ToString());
                            hid_customerid.Value = int_Custid.ToString();
                            obj_dt = obj_da_Receipt.GetInvRecptDtlslv(int_Custid, int_divisionid);
                            if (obj_dt.Rows.Count > 0)
                            {
                                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                {
                                    if (b == 0)
                                    {
                                        obj_dtAccount.Columns.Add("branch");
                                        obj_dtAccount.Columns.Add("port");
                                        obj_dtAccount.Columns.Add("invoiceno");
                                        obj_dtAccount.Columns.Add("iamount");
                                        obj_dtAccount.Columns.Add("ramount");
                                        obj_dtAccount.Columns.Add("voutype");
                                        obj_dtAccount.Columns.Add("vouno");
                                        obj_dtAccount.Columns.Add("ravouyear");
                                        obj_dtAccount.Columns.Add("vouyear");
                                    }
                                    dr = obj_dtAccount.NewRow();
                                    obj_dtAccount.Rows.Add(dr);

                                    dr[0] = obj_dt.Rows[i][0].ToString();
                                    dr[1] = obj_dt.Rows[i][1].ToString();
                                    if (obj_dt.Rows[i][2].ToString().Trim() != "0")
                                    {
                                        if (obj_dt.Rows[i][5].ToString().Trim() == "I")
                                        {
                                            dr[2] = "Inv - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "B")
                                        {
                                            dr[2] = "BOS - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "D")
                                        {
                                            dr[2] = "OSDN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "V")
                                        {
                                            dr[2] = "DN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "X")
                                        {
                                            dr[2] = "ADN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "P")
                                        {
                                            dr[2] = "CNOps - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "C")
                                        {
                                            dr[2] = "OSCN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "E")
                                        {
                                            dr[2] = "CN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "S")
                                        {
                                            dr[2] = "ACN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        if (obj_dt.Rows[i][5].ToString().Trim() == "OI")
                                        {
                                            dr[2] = "OB Inv - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "OB")
                                        {
                                            dr[2] = "OB BOS - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "OD")
                                        {
                                            dr[2] = "OB OSDN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "OV")
                                        {
                                            dr[2] = "OB DN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "OX")
                                        {
                                            dr[2] = "OB ADN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "OP")
                                        {
                                            dr[2] = "OB CNOps - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "OC")
                                        {
                                            dr[2] = "OB OSCN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "OE")
                                        {
                                            dr[2] = "OB CN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                        else if (obj_dt.Rows[i][5].ToString().Trim() == "OS")
                                        {
                                            dr[2] = "OB ACN - " + obj_dt.Rows[i][2].ToString();
                                        }
                                    }
                                    else
                                    {
                                        dr[2] = "On Account";
                                    }
                                    dr[3] = obj_dt.Rows[i][3].ToString();
                                    dr[4] = obj_dt.Rows[i][4].ToString();
                                    dr[5] = obj_dt.Rows[i][5].ToString();
                                    dr[6] = obj_dt.Rows[i][2].ToString();
                                    dr[7] = obj_dt.Rows[i][6].ToString();
                                    dr[8] = obj_dt.Rows[i][6].ToString();
                                }
                                Grd_detail.DataSource = obj_dtAccount;
                                Grd_detail.DataBind();
                                ViewState["Payment"] = obj_dtAccount;
                                txt_custamount.Text = Total.ToString();
                                hid_amount.Value = Total.ToString();
                            }

                        }
                    }

                }
                else if (hid_receiptid.Value == "0")
                {
                    int_Custid = Convert.ToInt32(hid_customerid.Value);
                    obj_dt = obj_da_Receipt.GetInvRecptDtlslv(int_Custid, int_divisionid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            if (b == 0)
                            {
                                obj_dtAccount.Columns.Add("branch");
                                obj_dtAccount.Columns.Add("port");
                                obj_dtAccount.Columns.Add("invoiceno");
                                obj_dtAccount.Columns.Add("iamount");
                                obj_dtAccount.Columns.Add("ramount");
                                obj_dtAccount.Columns.Add("voutype");
                                obj_dtAccount.Columns.Add("vouno");
                                obj_dtAccount.Columns.Add("ravouyear");
                                obj_dtAccount.Columns.Add("vouyear");
                            }
                            dr = obj_dtAccount.NewRow();
                            obj_dtAccount.Rows.Add(dr);

                            dr[0] = obj_dt.Rows[i][0].ToString();
                            dr[1] = obj_dt.Rows[i][1].ToString();
                            if (obj_dt.Rows[i][2].ToString().Trim() != "0")
                            {
                                if (obj_dt.Rows[i][5].ToString().Trim() == "I")
                                {
                                    dr[2] = "Inv - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "B")
                                {
                                    dr[2] = "BOS - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "D")
                                {
                                    dr[2] = "OSDN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "V")
                                {
                                    dr[2] = "DN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "X")
                                {
                                    dr[2] = "ADN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "P")
                                {
                                    dr[2] = "CNOps - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "C")
                                {
                                    dr[2] = "OSCN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "E")
                                {
                                    dr[2] = "CN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "S")
                                {
                                    dr[2] = "ACN - " + obj_dt.Rows[i][2].ToString();
                                }
                                if (obj_dt.Rows[i][5].ToString().Trim() == "OI")
                                {
                                    dr[2] = "OB Inv - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "OB")
                                {
                                    dr[2] = "OB BOS - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "OD")
                                {
                                    dr[2] = "OB OSDN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "OV")
                                {
                                    dr[2] = "OB DN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "OX")
                                {
                                    dr[2] = "OB ADN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "OP")
                                {
                                    dr[2] = "OB CNOps - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "OC")
                                {
                                    dr[2] = "OB OSCN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "OE")
                                {
                                    dr[2] = "OB CN - " + obj_dt.Rows[i][2].ToString();
                                }
                                else if (obj_dt.Rows[i][5].ToString().Trim() == "OS")
                                {
                                    dr[2] = "OB ACN - " + obj_dt.Rows[i][2].ToString();
                                }
                            }
                            else
                            {
                                dr[2] = "On Account";
                            }
                            dr[3] = obj_dt.Rows[i][3].ToString();
                            dr[4] = obj_dt.Rows[i][4].ToString();
                            dr[5] = obj_dt.Rows[i][5].ToString();
                            dr[6] = obj_dt.Rows[i][2].ToString();
                            dr[7] = obj_dt.Rows[i][6].ToString();
                            dr[8] = obj_dt.Rows[i][6].ToString();
                        }
                        Grd_detail.DataSource = obj_dtAccount;
                        Grd_detail.DataBind();
                        ViewState["Payment"] = obj_dtAccount;
                    }
                }
                all();
                //Invoices();
                //DN();
                //PA();
                //ACN();
                //ADN();
                //CN();
                //BOS();
                OBBreakUp();
                OBBreakUp4rectpmt();

                if (Grd_detail.Rows.Count > 0)
                {
                    foreach (GridViewRow row1 in Grd_detail.Rows)
                    {
                        CheckBox chk = ((CheckBox)Grd_detail.Rows[row1.RowIndex].FindControl("Chkrecpfc"));
                        TextBox txt = ((TextBox)Grd_detail.Rows[row1.RowIndex].FindControl("txt_receiptamount"));

                        if (chk.Checked == false && txt.Text != "0.00")
                        {
                            Grd_detail.Rows[row1.RowIndex].Cells[4].Enabled = false;
                            chk.Checked = true;

                        }
                        else if (chk.Checked == false)
                        {
                            Grd_detail.Rows[row1.RowIndex].Cells[4].Enabled = true;
                            chk.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void txt_received_TextChanged(object sender, EventArgs e)
        {
            AllDetails(0);
        }
        //New
        private void OBBreakUp4rectpmt()
        {
            DataRow dr;
            DataTable dtINV = new DataTable();
            int Customer_Id, a = 0;
            if (hid_customerid.Value != "")
            {

                Customer_Id = Convert.ToInt32(hid_customerid.Value);
                dtINV = obj_da_Receipt.RecPaymCalc4OBBreakup(Customer_Id, int_divisionid);
                DataTable obj_dtAccount = new DataTable();

                if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
                {
                    obj_dtAccount = (DataTable)ViewState["Payment"];
                    b = obj_dtAccount.Rows.Count;
                }

                if (dtINV.Rows.Count > 0)
                {
                    if (b == 0)
                    {
                        obj_dtAccount.Columns.Add("branch");
                        obj_dtAccount.Columns.Add("port");
                        obj_dtAccount.Columns.Add("invoiceno");
                        obj_dtAccount.Columns.Add("iamount");
                        obj_dtAccount.Columns.Add("ramount");
                        obj_dtAccount.Columns.Add("voutype");
                        obj_dtAccount.Columns.Add("vouno");
                        obj_dtAccount.Columns.Add("ravouyear");
                        obj_dtAccount.Columns.Add("vouyear");
                    }

                    for (int i = 0; i < dtINV.Rows.Count; i++)
                    {
                        dr = obj_dtAccount.NewRow();
                        obj_dtAccount.Rows.Add(dr);

                        dr[0] = dtINV.Rows[i][0].ToString();
                        dr[1] = dtINV.Rows[i][1].ToString();


                        if (dtINV.Rows[i][5].ToString().Trim() == "OI")
                        {
                            dr["invoiceno"] = "OB Inv - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OD")
                        {
                            dr["invoiceno"] = "OB OSDN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OV")
                        {
                            dr["invoiceno"] = "OB DN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OX")
                        {
                            dr["invoiceno"] = "OB ADN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OP")
                        {
                            dr["invoiceno"] = "OB CNOps - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OC")
                        {
                            dr["invoiceno"] = "OB OSCN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OE")
                        {
                            dr["invoiceno"] = "OB CN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OS")
                        {
                            dr["invoiceno"] = "OB ACN - " + dtINV.Rows[i][2].ToString();
                        }
                        dr[3] = dtINV.Rows[i][3].ToString();
                        dr[4] = dtINV.Rows[i][4].ToString();
                        dr[5] = dtINV.Rows[i][5].ToString();
                        dr[6] = dtINV.Rows[i][2].ToString();
                        dr[7] = dtINV.Rows[i][6].ToString();
                        dr[8] = dtINV.Rows[i][6].ToString();

                    }
                    Grd_detail.DataSource = obj_dtAccount;
                    Grd_detail.DataBind();
                    ViewState["Payment"] = obj_dtAccount;
                }
            }
        }

        private void OBBreakUp()
        {
            DataRow dr;
            DataTable dtINV = new DataTable();
            int Customer_Id, a = 0;
            if (hid_customerid.Value != "")
            {

                Customer_Id = Convert.ToInt32(hid_customerid.Value);
                dtINV = obj_da_Receipt.GetOBRecptDtls(Customer_Id, int_divisionid);
                DataTable obj_dtAccount = new DataTable();
                if (ViewState["Payment"] != null && !ViewState["Payment"].Equals("-1"))
                {
                    obj_dtAccount = (DataTable)ViewState["Payment"];
                    b = obj_dtAccount.Rows.Count;
                }


                if (dtINV.Rows.Count > 0)
                {
                    if (b == 0)
                    {
                        obj_dtAccount.Columns.Add("branch");
                        obj_dtAccount.Columns.Add("port");
                        obj_dtAccount.Columns.Add("invoiceno");
                        obj_dtAccount.Columns.Add("iamount");
                        obj_dtAccount.Columns.Add("ramount");
                        obj_dtAccount.Columns.Add("voutype");
                        obj_dtAccount.Columns.Add("vouno");
                        obj_dtAccount.Columns.Add("ravouyear");
                        obj_dtAccount.Columns.Add("vouyear");
                    }


                    for (int i = 0; i < dtINV.Rows.Count; i++)
                    {
                        dr = obj_dtAccount.NewRow();
                        obj_dtAccount.Rows.Add(dr);
                        dr[0] = dtINV.Rows[i][0].ToString();
                        dr["port"] = dtINV.Rows[i][1].ToString();

                        if (dtINV.Rows[i][5].ToString().Trim() == "OI")
                        {
                            dr["invoiceno"] = "OB Inv - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OD")
                        {
                            dr["invoiceno"] = "OB OSDN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OV")
                        {
                            dr["invoiceno"] = "OB DN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OX")
                        {
                            dr["invoiceno"] = "OB ADN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OP")
                        {
                            dr["invoiceno"] = "OB CNOps - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OC")
                        {
                            dr["invoiceno"] = "OB OSCN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OE")
                        {
                            dr["invoiceno"] = "OB CN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString().Trim() == "OS")
                        {
                            dr["invoiceno"] = "OB ACN - " + dtINV.Rows[i][2].ToString();
                        }
                        dr[3] = dtINV.Rows[i][3].ToString();
                        dr[4] = dtINV.Rows[i][4].ToString();
                        dr[5] = dtINV.Rows[i][5].ToString();
                        dr[6] = dtINV.Rows[i][2].ToString();
                        dr[7] = dtINV.Rows[i][6].ToString();
                        dr[8] = dtINV.Rows[i][6].ToString();

                    }
                    Grd_detail.DataSource = obj_dtAccount;
                    Grd_detail.DataBind();
                    ViewState["Payment"] = obj_dtAccount;
                }
            }
        }

        protected void txt_tdsamount_TextChanged1(object sender, EventArgs e)
        {
            ExcessCalc();
        }


        protected void ExcessCalc()
        {
            double excess = 0, custamount = 0, adjamount = 0, excess1 = 0, excess2 = 0, onacc = 0, AdjOn = 0;
            double tot = 0, tot1 = 0, to2 = 0;
            custamount = Convert.ToDouble(txt_amount.Text);
            // custamount = Convert.ToDouble(txt_custamount.Text);
            // adjamount = Convert.ToDouble(txt_adj_amount.Text);
            for (int i = 0; i <= Grd_detail.Rows.Count - 1; i++)
            {

                TextBox TxtAmount = ((TextBox)Grd_detail.Rows[i].FindControl("txt_receiptamount"));
                //  CheckBox chk = ((CheckBox)Grd_detail.Rows[i].FindControl("Chkrecpfc"));
                if (TxtAmount.Text != "0.00" && Grd_detail.Rows[i].Cells[4].Enabled == true)
                {
                    adjamount += Convert.ToDouble(TxtAmount.Text);
                    adjamount = Convert.ToDouble(adjamount.ToString("#,0.00"));
                }

            }
            custamount = Convert.ToDouble(custamount.ToString("#,0.00"));
            adjamount = Convert.ToDouble(adjamount.ToString("#,0.00"));
            onacc = Convert.ToDouble(txt_onaccount.Text);
            if (adjamount < onacc)
            {
                AdjOn = onacc - adjamount;
            }
            else
            {
                AdjOn = 0;
            }

            txt_adjonaccount.Text = Convert.ToDouble(AdjOn).ToString("#,0.00");
            AdjOn = Convert.ToDouble(AdjOn.ToString("#,0.00"));
            if (AdjOn > 0)
            {
                tot = Convert.ToDouble(txt_amount.Text);
                tot1 = (Convert.ToDouble(txt_adj_amount.Text) + Convert.ToDouble(txt_adjonaccount.Text));
                excess = tot - tot1;
                txt_excess.Text = excess.ToString("#,0.00");
                // txt_excess.Text = Convert.ToDouble(txt_amount.Text) - (Convert.ToDouble(txt_adj_amount.Text) + Convert.ToDouble(txt_adjonaccount.Text));
            }

            double Adjstableamount = Convert.ToDouble(txt_adj_amount.Text);
            if (custamount == (AdjOn + Adjstableamount))
            {
                txt_excess.Text = "0.00";
            }
            else
            {
                if (AdjOn == 0.00)
                {

                    //excess = custamount - adjamount;
                    //excess = Convert.ToDouble(txt_onaccount.Text) - Convert.ToDouble(txt_adj_amount.Text);
                    excess = Convert.ToDouble(txt_amount.Text) - Convert.ToDouble(txt_adj_amount.Text);

                    if (txt_tdsamount.Text != "-0.00")
                    {

                        tot = Convert.ToDouble(txt_amount.Text);
                        to2 = Convert.ToDouble(txt_tdsamount.Text);
                        tot1 = (Convert.ToDouble(txt_adj_amount.Text) + Convert.ToDouble(txt_adjonaccount.Text)) + to2;
                        excess = tot - tot1;

                    }
                    txt_excess.Text = excess.ToString("#,0.00");
                }
            }



        }


        protected void calculation()
        {
            double Total = 0, Income_Amount = 0, Expence_Amount = 0;
            string voutype = "";
            if (Grd_detail.Rows.Count > 0)
            {
                foreach (GridViewRow totalrow in Grd_detail.Rows)
                {
                    if (Grd_detail.Rows[totalrow.RowIndex].Cells[1].Text.ToString() != "On Account")
                    {
                        TextBox Txt = (TextBox)totalrow.FindControl("txt_receiptamount");
                        voutype = Grd_detail.DataKeys[totalrow.RowIndex].Values[1].ToString().Trim();
                        if (voutype == "I" || voutype == "D" || voutype == "V" || voutype == "X" || voutype == "B" || voutype == "OI" || voutype == "OD" || voutype == "OV" || voutype == "OX" || voutype == "OB")
                        {
                            Income_Amount = Income_Amount + double.Parse(Txt.Text);

                            Income_Amount = Convert.ToDouble(Income_Amount.ToString("#,0.00"));
                        }
                        else if (voutype == "P" || voutype == "C" || voutype == "E" || voutype == "S" || voutype == "OP" || voutype == "OC" || voutype == "OE" || voutype == "OS")
                        {
                            Expence_Amount = Expence_Amount + double.Parse(Txt.Text);
                            Expence_Amount = Convert.ToDouble(Expence_Amount.ToString("#,0.00"));
                        }

                    }

                }
                if (Session["rptype"].ToString() == "R")
                {
                    Total = Income_Amount - Expence_Amount;
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    Total = Expence_Amount - Income_Amount;
                }

            }


            txt_adj_amount.Text = string.Format("{0:0.00}", Total);
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