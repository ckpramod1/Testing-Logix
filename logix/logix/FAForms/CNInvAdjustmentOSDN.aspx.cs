using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForm
{
    public partial class CNInvAdjustmentOSDN : System.Web.UI.Page
    {
        string str_grdcur = "";
        double dbl_grdfamt, dbl_grdexr;
        int int_Custid = 0;
        int did;
        string str_fcAmount, str_exrate;
        DataTable obj_dt = new DataTable();
        int rowIndex;
        double Dbl_CNAMT;
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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try {

                if (txt_receipt.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CNInvoice", "alertify.alert('Kindly enter - " + ddl_voucher.SelectedItem.Text + " voucher to adjust ');", true);
                    return;
                }
                if (txt_year.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CNInvoice", "alertify.alert('Kindly enter the voucher year');", true);
                    return;
                }

            double dbl_VouAmt, dbl_CNAmt,dbl_fcamt,dbl_exr;

            dbl_CNAmt=Convert.ToDouble(hid_DNamt.Value);
            dbl_fcamt=Convert.ToDouble(hid_grdfamt.Value);
            dbl_exr=Convert.ToDouble(hid_grdexr.Value);
            str_grdcur = hid_grdcur.Value;
            string str_setteled;
             int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            dbl_VouAmt = 0;
            for (int i = 0; i <= Grd_detail.Rows.Count - 1; i++)
            {
                TextBox tx = ((TextBox)Grd_detail.Rows[i].FindControl("txt_receiptamount"));

                dbl_VouAmt = dbl_VouAmt + Convert.ToDouble(tx.Text);
            }

            //dbl_CNAmt=Convert.ToDouble(txt_AdjAmt.Text);



            if (dbl_VouAmt == 0.00)
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CNInvoice", "alertify.alert('There is no voucher adjusted against - " + ddl_voucher.SelectedItem.Text + " # " + txt_receipt.Text + " ');", true);
                return;
            } 
            if (dbl_VouAmt > dbl_CNAmt)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('" + ddl_voucher.SelectedItem.Text + " Amount does not Match with VoucherDetails Amount');", true);
                return;            
            }

            str_setteled = "";
            if (dbl_VouAmt<dbl_CNAmt)
            {
                str_setteled = "N";
            }
            else
            {
                str_setteled = "Y";
            }

            
                DataAccess.Accounts.Recipts obj_rec = new DataAccess.Accounts.Recipts();
                DataAccess.LogDetails obj_Log = new DataAccess.LogDetails();
                obj_rec.InsRecptAginstInv4OS(-5, 'C', Convert.ToInt16(txt_receipt.Text), Convert.ToChar(ddl_voucher.SelectedValue.ToString()), bid, (dbl_CNAmt * dbl_exr), (dbl_VouAmt * dbl_exr), Convert.ToChar(str_setteled), Convert.ToInt16(txt_year.Text), str_grdcur, dbl_fcamt, dbl_exr, dbl_VouAmt, dbl_VouAmt);

                char V_type, Setteled;
                int int_branchid = 0, int_invoiceno = 0, int_Ryear = 0;
                double VoucherAmount = 0, Adjust_Amount = 0, grdexr = 0, grdfamt = 0, grdamt=0;
                string str_vtype, grdcur;


                for (int i = 0; i <= Grd_detail.Rows.Count - 1; i++)
                {
                    TextBox Txt = (TextBox)Grd_detail.Rows[i].FindControl("txt_receiptamount");
                    Adjust_Amount = double.Parse(Txt.Text.ToString());
                    //V_type = char.Parse(Grd_detail.Rows[row.RowIndex].Cells[1].ToString());
                    if (Adjust_Amount > 0)
                    {
                        int_branchid = Convert.ToInt16(Grd_detail.Rows[i].Cells[0].Text);
                        int_invoiceno = Convert.ToInt32(Grd_detail.Rows[i].Cells[10].Text);
                        int_Ryear = Convert.ToInt16(Grd_detail.Rows[i].Cells[12].Text);
                        VoucherAmount = Convert.ToDouble(Grd_detail.Rows[i].Cells[6].Text);
                        str_vtype = Grd_detail.Rows[i].Cells[9].Text;
                        grdcur = Grd_detail.Rows[i].Cells[3].Text;
                        grdexr = Convert.ToDouble(Grd_detail.Rows[i].Cells[5].Text);
                        grdfamt = Convert.ToDouble(Grd_detail.Rows[i].Cells[4].Text);
                        grdamt = Convert.ToDouble(Grd_detail.Rows[i].Cells[8].Text);
                        if (VoucherAmount > Adjust_Amount)
                        {
                            Setteled = 'N';
                        }
                        else
                        {
                            Setteled = 'Y';
                        }
                        obj_rec.InsRecptAginstInv4OS(-5,'C', int_invoiceno, Convert.ToChar(str_vtype), int_branchid, VoucherAmount, grdamt, Convert.ToChar(Setteled), int_Ryear, grdcur, grdfamt, grdexr, grdfamt, Adjust_Amount);
                        obj_rec.InsRecptAginstVouOS(ddl_voucher.SelectedValue.ToString(), int.Parse(txt_receipt.Text), int.Parse(txt_year.Text), double.Parse(txt_amount.Text), bid, str_vtype.ToString(), int_invoiceno, int_Ryear, grdfamt, Adjust_Amount, int_branchid);

                    }


                }

                //obj_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1316, 1, bid, ddl_voucher.SelectedItem.Text + " - " + txt_receipt.Text);
                obj_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1447, 1, bid, ddl_voucher.SelectedItem.Text + " - " + txt_receipt.Text);
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "CNInvoice", "alertify.alert('Voucher Amount Adjusted Against" + ddl_voucher.SelectedItem.Text + " # - " + txt_receipt.Text + "');", true);
                Fn_Clear();
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
            }
            else
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
        }

        protected void txt_receipt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_Getdetail();
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
            Grd_detail.DataSource = new DataTable();
            Grd_detail.DataBind();
            ViewState["dtINV"] = new DataTable();
            lbl_receipt.Text = "Vou #";

            txt_AdjAmt.Text = "";
            txt_receipt.ToolTip = "Vou #";
            txt_receipt.Attributes.Add("placeholder", "Vou #");
        }
        private void Fn_Getdetail()
        {
            
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
          
            char char_Mode;
           
            string str_Custtype;
            if (ddl_voucher.SelectedItem.Text.ToString().Trim().Length > 0 && txt_receipt.Text.ToString().Trim().Length > 0 && txt_year.Text.ToString().Trim().Length > 0)
            {
                char_Mode = char.Parse(ddl_voucher.SelectedValue.ToString());
                DataAccess.Accounts.Recipts Obj_Rec = new DataAccess.Accounts.Recipts();
                DataAccess.Masters.MasterCustomer Obj_Cust = new DataAccess.Masters.MasterCustomer();
                
                obj_dt = Obj_Rec.GetCNDetails4AdjusOS(int.Parse(txt_receipt.Text), int.Parse(txt_year.Text), int_bid, char_Mode);
                if (obj_dt.Rows.Count > 0 )
                {
                    Dbl_CNAMT = Convert.ToDouble(obj_dt.Rows[0][1].ToString());
                    hid_DNamt.Value = Dbl_CNAMT.ToString();
                    int_Custid = Convert.ToInt32(obj_dt.Rows[0][2].ToString());
                    txt_received.Text = obj_dt.Rows[0][3].ToString();
                    txt_amount.Text = string.Format("{0:##,0.00}", Dbl_CNAMT);
                   
                    str_grdcur=obj_dt.Rows[0][4].ToString();
                    hid_grdcur.Value = str_grdcur;
                    dbl_grdfamt = Convert.ToDouble(obj_dt.Rows[0][5].ToString());
                    hid_grdfamt.Value = dbl_grdfamt.ToString();
                    dbl_grdexr = Convert.ToDouble(obj_dt.Rows[0][6].ToString());
                    hid_grdexr.Value = dbl_grdexr.ToString();

                     str_Custtype=Obj_Cust.GetCustomerType(int_Custid);
                    if (char_Mode != 'C')
                    {
                        if (str_Custtype == "P")
                        {
                            UnSettel();
                            DN();
                            OSDN();
                        }
                        else
                        {
                            UnSettel();
                            DN();
                        }
                    }
                    else
                    {
                        if (str_Custtype == "P")
                        {
                            UnSettel();
                            DN();
                           
                        }
                        OSDN();
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid " + ddl_voucher.SelectedItem.Text + " #');", true);
                    txt_receipt.Text = "";
                }
            }
            
           
        }

        private void UnSettel()
        {
            int a;
            DataTable dttemp = new DataTable();
            DataTable dtINV = new DataTable();
            DataRow dtrow;
            DataAccess.Accounts.Recipts Obj_Rec = new DataAccess.Accounts.Recipts();
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());

            a = 0;
            if (ViewState["dtINV"] != null)
            {
                dttemp = (DataTable)ViewState["dtINV"];
                a = dttemp.Rows.Count;
            }

            dtINV = Obj_Rec.GetOSInvRecptDtls4Adjust(int_Custid, did);

            if (dttemp.Rows.Count == 0 && dtINV.Rows.Count > 0)
            {
                dttemp.Columns.Clear();
                dttemp.Columns.Add("branchid", typeof(string));
                dttemp.Columns.Add("branch", typeof(string));
                dttemp.Columns.Add("invoiceno", typeof(string));
                dttemp.Columns.Add("curr", typeof(string));
                dttemp.Columns.Add("fcamt", typeof(string));
                dttemp.Columns.Add("exrate", typeof(string));
                dttemp.Columns.Add("vamount", typeof(string));
                dttemp.Columns.Add("tamount", typeof(string));

                dttemp.Columns.Add("recptfcamt", typeof(string));
                dttemp.Columns.Add("voutype", typeof(string));
                dttemp.Columns.Add("vouno", typeof(string));
                dttemp.Columns.Add("tds", typeof(string));
                dttemp.Columns.Add("ravouyear", typeof(string));
                dttemp.Columns.Add("ltype", typeof(string));
                dttemp.Columns.Add("customerid", typeof(string));
               // dttemp.Columns.Add("VouDate", typeof(string));
            }

            for (int i=0;i<=dtINV.Rows.Count-1;i++)
            {
                dtrow = dttemp.NewRow();
                dtrow["branchid"] = dtINV.Rows[i][0].ToString();
                dtrow["branch"] = dtINV.Rows[i][1].ToString();
                if (dtINV.Rows[i][2].ToString() != "0")
                {
                    if (dtINV.Rows[i][8].ToString() == "I")
                    {
                        dtrow["invoiceno"] = "Inv - " + dtINV.Rows[i][2].ToString();
                    }
                    else if (dtINV.Rows[i][8].ToString() == "D")
                    {
                        dtrow["invoiceno"] = "OSDN - " + dtINV.Rows[i][2].ToString();
                    }
                    else if (dtINV.Rows[i][8].ToString() == "V")
                    {
                        dtrow["invoiceno"] = "DN - " + dtINV.Rows[i][2].ToString();
                    }
                    else if (dtINV.Rows[i][8].ToString() == "X")
                    {
                        dtrow["invoiceno"] = "ADN - " + dtINV.Rows[i][2].ToString();
                    }
                    else if (dtINV.Rows[i][8].ToString() == "P")
                    {
                        dtrow["invoiceno"] = "CNOps - " + dtINV.Rows[i][2].ToString();
                    }
                    else if (dtINV.Rows[i][8].ToString() == "C")
                    {
                        dtrow["invoiceno"] = "OSCN - " + dtINV.Rows[i][2].ToString();
                    }
                    else if (dtINV.Rows[i][8].ToString() == "E")
                    {
                        dtrow["invoiceno"] = "CN - " + dtINV.Rows[i][2].ToString();
                    }
                    else if (dtINV.Rows[i][8].ToString() == "S")
                    {
                        dtrow["invoiceno"] = "ACN - " + dtINV.Rows[i][2].ToString();
                    }
                }
                //else
                //{
                //    dtrow["invoiceno"] = "On Account";
                //}

                dtrow["curr"] = dtINV.Rows[i][3].ToString();
                str_fcAmount = dtINV.Rows[i]["receiptfamount"].ToString();
                dtrow["fcamt"] = Convert.ToDecimal(str_fcAmount).ToString("#,0.00");
                str_exrate = dtINV.Rows[i]["receiptexrate"].ToString();
                dtrow["exrate"] = Convert.ToDecimal(str_exrate).ToString("#,0.00");

                dtrow["vamount"] = dtINV.Rows[i]["vamount"].ToString();
                dtrow["tamount"] = dtINV.Rows[i]["tamount"].ToString();
                dtrow["recptfcamt"] = dtINV.Rows[i]["famount"].ToString();

                dtrow["voutype"] = dtINV.Rows[i]["voutype"].ToString();
                dtrow["vouno"] = dtINV.Rows[i]["vouno"].ToString();
                dtrow["tds"] = "";
                dtrow["ravouyear"] = dtINV.Rows[i]["ravouyear"].ToString();
                dtrow["ltype"] = "";
                dtrow["customerid"] = int_Custid; //dtINV.Rows[i]["customerid"].ToString();
             //   dtrow["VouDate"] = dtINV.Rows[i]["voudate"].ToString();

                dttemp.Rows.Add(dtrow);
            }

            Grd_detail.DataSource = dttemp;
            Grd_detail.DataBind();
            ViewState["dtINV"] = dttemp;

        }

        private void DN()
        {
            int a;
            DataTable dttemp = new DataTable();
            DataTable dtINV = new DataTable();
            DataRow dtrow;
            DataAccess.Accounts.Recipts Obj_Rec = new DataAccess.Accounts.Recipts();
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());

            a = 0;
            if (ViewState["dtINV"] != null)
            {
                dttemp = (DataTable)ViewState["dtINV"];
                a = dttemp.Rows.Count;
            }

            dtINV = Obj_Rec.GetDN4OS(int_Custid, did);

            if (dttemp.Rows.Count == 0 && dtINV.Rows.Count > 0)
            {
                dttemp.Columns.Clear();
                dttemp.Columns.Add("branchid", typeof(string));
                dttemp.Columns.Add("branch", typeof(string));
                dttemp.Columns.Add("invoiceno", typeof(string));
                dttemp.Columns.Add("curr", typeof(string));
                dttemp.Columns.Add("fcamt", typeof(string));
                dttemp.Columns.Add("exrate", typeof(string));
                dttemp.Columns.Add("vamount", typeof(string));
                dttemp.Columns.Add("tamount", typeof(string));

                dttemp.Columns.Add("recptfcamt", typeof(string));
                dttemp.Columns.Add("voutype", typeof(string));
                dttemp.Columns.Add("vouno", typeof(string));
                dttemp.Columns.Add("tds", typeof(string));
                dttemp.Columns.Add("ravouyear", typeof(string));
                dttemp.Columns.Add("ltype", typeof(string));
                dttemp.Columns.Add("customerid", typeof(string));
            }

            for (int i = 0; i <= dtINV.Rows.Count - 1; i++)
            {
                dtrow = dttemp.NewRow();
                dtrow["branchid"] = dtINV.Rows[i][0].ToString();
                dtrow["branch"] = dtINV.Rows[i][1].ToString();
                dtrow["invoiceno"] = "DN - " + dtINV.Rows[i][2].ToString();
                dtrow["curr"] = dtINV.Rows[i][3].ToString();
                str_fcAmount = dtINV.Rows[i]["fcamt"].ToString();
                dtrow["fcamt"] = Convert.ToDecimal(str_fcAmount).ToString("#,0.00");
                str_exrate = dtINV.Rows[i]["exrate"].ToString();
                dtrow["exrate"] = Convert.ToDecimal(str_exrate).ToString("#,0.00");

                dtrow["vamount"] = dtINV.Rows[i]["iamount"].ToString();
                dtrow["tamount"] = dtINV.Rows[i]["ramount"].ToString();
                dtrow["recptfcamt"] = dtINV.Rows[i]["famount"].ToString();

                dtrow["voutype"] = dtINV.Rows[i]["voutype"].ToString();
                dtrow["vouno"] = dtINV.Rows[i]["dnno"].ToString();
                dtrow["tds"] = "";
                dtrow["ravouyear"] = dtINV.Rows[i]["vouyear"].ToString();
                dtrow["ltype"] = "";
                dtrow["customerid"] = int_Custid; //dtINV.Rows[i]["customerid"].ToString();

                dttemp.Rows.Add(dtrow);
            }

            Grd_detail.DataSource = dttemp;
            Grd_detail.DataBind();
            ViewState["dtINV"] = dttemp;
        }

        private void OSDN()
        {
            int a;
            DataTable dttemp = new DataTable();
            DataTable dtINV = new DataTable();
            DataRow dtrow;
            DataAccess.Accounts.Recipts Obj_Rec = new DataAccess.Accounts.Recipts();
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());

            a = 0;
            if (ViewState["dtINV"] != null)
            {
                dttemp = (DataTable)ViewState["dtINV"];
                a = dttemp.Rows.Count;
            }

            dtINV = Obj_Rec.GetOSDN4OS(int_Custid, did);

            if (dttemp.Rows.Count == 0 && dtINV.Rows.Count > 0)
            {
                dttemp.Columns.Clear();
                dttemp.Columns.Add("branchid", typeof(string));
                dttemp.Columns.Add("branch", typeof(string));
                dttemp.Columns.Add("invoiceno", typeof(string));
                dttemp.Columns.Add("curr", typeof(string));
                dttemp.Columns.Add("fcamt", typeof(string));
                dttemp.Columns.Add("exrate", typeof(string));
                dttemp.Columns.Add("vamount", typeof(string));
                dttemp.Columns.Add("tamount", typeof(string));

                dttemp.Columns.Add("recptfcamt", typeof(string));
                dttemp.Columns.Add("voutype", typeof(string));
                dttemp.Columns.Add("vouno", typeof(string));
                dttemp.Columns.Add("tds", typeof(string));
                dttemp.Columns.Add("ravouyear", typeof(string));
                dttemp.Columns.Add("ltype", typeof(string));
                dttemp.Columns.Add("customerid", typeof(string));
            }

            for (int i = 0; i <= dtINV.Rows.Count - 1; i++)
            {
                dtrow = dttemp.NewRow();
                dtrow["branchid"] = dtINV.Rows[i][0].ToString();
                dtrow["branch"] = dtINV.Rows[i][1].ToString();
                dtrow["invoiceno"] = "OSDN - " + dtINV.Rows[i][2].ToString();
                dtrow["curr"] = dtINV.Rows[i][3].ToString();
                str_fcAmount = dtINV.Rows[i]["fcamt"].ToString();
                dtrow["fcamt"] = Convert.ToDecimal(str_fcAmount).ToString("#,0.00");
                str_exrate = dtINV.Rows[i]["exrate"].ToString();
                dtrow["exrate"] = Convert.ToDecimal(str_exrate).ToString("#,0.00");

                dtrow["vamount"] = dtINV.Rows[i]["iamount"].ToString();
                dtrow["tamount"] = dtINV.Rows[i]["ramount"].ToString();
                dtrow["recptfcamt"] = dtINV.Rows[i]["famount"].ToString();

                dtrow["voutype"] = dtINV.Rows[i]["voutype"].ToString();
                dtrow["vouno"] = dtINV.Rows[i]["dnno"].ToString();
                dtrow["tds"] = "";
                dtrow["ravouyear"] = dtINV.Rows[i]["vouyear"].ToString();
                dtrow["ltype"] = "";
                dtrow["customerid"] = int_Custid; //dtINV.Rows[i]["customerid"].ToString();

                dttemp.Rows.Add(dtrow);
            }

            Grd_detail.DataSource = dttemp;
            Grd_detail.DataBind();
            ViewState["dtINV"] = dttemp;
        }

        protected void ddl_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_voucher.SelectedValue.ToString() == "E")
            {
                lbl_receipt.Text = "Vou #";
                txt_receipt.ToolTip = "CN #";
                txt_receipt.Attributes.Add("placeholder", "Vou #");
            }
            else if (ddl_voucher.SelectedValue.ToString() == "C")
            {
                lbl_receipt.Text = "OSPI";

                txt_receipt.ToolTip = "Vou #";
                txt_receipt.Attributes.Add("placeholder", "Vou #");
            }
        }

        protected void txt_receiptamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double dbl_exr, dbl_fcamount, dbl_grdinramt, GrdAmnt = 0.00;

                int RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
                TextBox TxtAmount = ((TextBox)Grd_detail.Rows[RowIndex].FindControl("txt_receiptamount"));


                if (Grd_detail.Rows[RowIndex].Cells[4].Text.ToString() != null)
                {
                    if (double.TryParse(Grd_detail.Rows[RowIndex].Cells[4].Text.ToString(), out GrdAmnt))
                    {
                        if (Convert.ToDouble(Grd_detail.Rows[RowIndex].Cells[4].Text.ToString()) < Convert.ToDouble(TxtAmount.Text))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Adjustment Amount should not be greater than Voucher Amount')", true);
                            TxtAmount.Text = "0.00";
                            return;
                        }
                    }
                }


                dbl_exr = Convert.ToDouble((Grd_detail.Rows[RowIndex].Cells[5].Text));
                dbl_fcamount = Convert.ToDouble(TxtAmount.Text);
                dbl_grdinramt = dbl_exr * dbl_fcamount;
                Grd_detail.Rows[RowIndex].Cells[8].Text = dbl_grdinramt.ToString("#0.00");

              
                double Total = 0;
                foreach (GridViewRow totalrow in Grd_detail.Rows)
                {
                    TextBox Txt = (TextBox)totalrow.FindControl("txt_receiptamount");
                    Total = Total + double.Parse(Txt.Text);
                }

                txt_AdjAmt.Text = Total.ToString("#0.00");
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void Grd_detail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                rowIndex = Convert.ToInt32(e.CommandArgument);
                Grd_detail_SelectedIndexChanged(sender, e);
            }
        }

        protected void Grd_detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double grd_amt;
                int index;
                int ouput;
                if (hid_gridname.Value != "")
                {
                    index = Convert.ToInt32(hid_gridname.Value);
                    //if (index + 1 == Grd_detail.Rows.Count)
                    //{
                    //    return;
                    //}

                    TextBox txt1 = ((TextBox)Grd_detail.Rows[index].FindControl("txt_receiptamount"));
                    string value = txt1.Text;
                    if (value != "")
                    {
                        if (double.TryParse(value, out grd_amt))
                        {
                            string number = Grd_detail.Rows[index].Cells[4].Text;
                            if (Convert.ToDouble(number) < Convert.ToDouble(value))
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt/Payment Amount Must be Less Than or Equal to Voucher Amount');", true);
                                ((TextBox)Grd_detail.Rows[index].Cells[7].FindControl("txt_receiptamount")).Text = "0.00";
                            }
                        }
                        else
                        {

                        }

                    }
                    else
                    {

                    }


                    //if (hid_grid.Value == "" )
                    //{
                    //    index = Grd_detail.SelectedRow.RowIndex;
                    //}else
                    //{
                    //    index = Convert.ToInt32(hid_grid.Value);
                    //}



                    //if(Grd_detail.Rows[index].Cells[4].Text=="&nbsp")
                    //{
                    //    Grd_detail.Rows[index].Cells[4].Text="";
                    //}

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void Grd_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_detail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
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
    
      obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1447, "", "", "", Session["StrTranType"].ToString());

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