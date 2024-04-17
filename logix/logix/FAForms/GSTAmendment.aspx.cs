using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Runtime.Remoting;

namespace logix.FAForms
{
    public partial class GSTAmendment : System.Web.UI.Page
    {
        string chkvoutype;
        bool blnerr = false;
        string str_CtrlLists, str_MsgLists, str_DataType;
        string gsttype_ = "", statename_ = "", supplyto_ = "", cname = "", StrScript="";
        int gsttype = 0, statename = 0, supplyto = 0;
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer obj_mascust = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.STAdjustment obj_da_ST = new DataAccess.Accounts.STAdjustment();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_mascust.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_ST.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
              


            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                if (Session["Vouyear"] != null)
                {
                    txt_year.Text = Session["Vouyear"].ToString();
                }
                //Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
                //Grd_Charge.DataBind();
                Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Charge.DataBind();
                txt_receipt.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

                str_CtrlLists = "txt_receipt~txt_year";
                str_MsgLists = "Voucher #~Voucher Year";
                str_DataType = "String~String";
                btn_update.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }
        private void Fn_Clear()
        {
            txt_receipt.Text = "";
            txt_received.Text = "";
            txt_detail.Text = "";
            txt_total.Text = "";
            ddl_voucher.SelectedIndex = 0;
            txt_year.Text = Session["Vouyear"].ToString();
            Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Charge.DataBind();
            //Grd_Tax.DataSource = Utility.Fn_GetEmptyDataTable();
            // Grd_Tax.DataBind();
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }
        protected void txt_receipt_TextChanged(object sender, EventArgs e)
        {
            double Total = 0;
            DataTable dtempty = new DataTable();
            dtempty.Columns.Add("charge", typeof(string));
            dtempty.Columns.Add("curr", typeof(string));
            dtempty.Columns.Add("rate", typeof(string));
            dtempty.Columns.Add("exrate", typeof(string));
            dtempty.Columns.Add("base", typeof(string));
            dtempty.Columns.Add("Amount", typeof(string));
            dtempty.Columns.Add("txtcgsta", typeof(string));
            dtempty.Columns.Add("txtsgata", typeof(string));
            dtempty.Columns.Add("txtigsta", typeof(string));
            dtempty.Columns.Add("Total Amount", typeof(string));
            dtempty.Columns.Add("groupid", typeof(int));
            dtempty.Columns.Add("chargeid", typeof(int));

            DataRow dr = dtempty.NewRow();
            DataSet obj_ds = new DataSet();
            if (txt_receipt.Text.Trim().Length > 0 && txt_year.Text.Trim().Length > 0)
            {
                string str_type = "";
                // double Total = 0;
                switch (ddl_voucher.SelectedItem.Text)
                {
                    case "Credit Note - Operations":
                        str_type = "PA";
                        chkvoutype = "P";
                        break;
                    case "Admin Purchase Invoice":
                        str_type = "AP";
                        chkvoutype = "S";
                        break;
                    case "Other Credit Note":
                        str_type = "OC";
                        chkvoutype = "E";
                        break;
                }

                hid_type.Value = str_type;

                //DataAccess.Accounts.STAdjustment obj_da_ST = new DataAccess.Accounts.STAdjustment();
                obj_ds = obj_da_ST.GetServiceTaxAmtForNew(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_type);

                if (obj_ds.Tables.Count > 1)
                {
                    if (obj_ds.Tables[0].Rows.Count > 0)
                    {
                        hid_supplyto.Value = obj_ds.Tables[0].Rows[0]["supplyto"].ToString();
                        txt_received.Text = obj_ds.Tables[0].Rows[0]["customer"].ToString();
                        txt_detail.Text = "CNDate: " + obj_ds.Tables[0].Rows[0]["cndate"].ToString() + " RefNo: " + obj_ds.Tables[0].Rows[0]["refno"].ToString();
                        if (str_type != "AP")
                        {
                            hid_horm.Value = obj_ds.Tables[0].Rows[0]["horm"].ToString();
                            hid_trantype.Value = obj_ds.Tables[0].Rows[0]["trantype"].ToString();
                        }
                        hid_Custtype.Value = obj_ds.Tables[0].Rows[0]["customertype"].ToString();
                        if (Session["hid_gstdate"] != null)
                        {
                            if (Convert.ToDateTime(obj_da_Log.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                            {

                                if (hid_supplyto.Value == "0" || hid_supplyto.Value == "")
                                {
                                    StrScript = "Suppply To not updated for the Voucher #: " + txt_receipt.Text;
                                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                                 
                                }
                                else
                                {
                                    if (hid_supplyto.Value != "0" || hid_supplyto.Value != "")
                                    {
                                        DataTable dt_list = new DataTable();
                                        //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
                                        dt_list = customerobj.GetIndianCustomergstadd(Convert.ToInt32(hid_supplyto.Value));
                                        if (dt_list.Rows.Count > 0)
                                        {
                                            cname = dt_list.Rows[0]["customername"].ToString();
                                            if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                            {
                                                if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                {
                                                    StrScript = "GST TYPE not Updated for the Customer Name : " + cname + " in the Voucher #" + txt_receipt.Text;
                                                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                                                  
                                                }
                                            }
                                        }
                                        else
                                        {
                                            cname=obj_mascust.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                                            StrScript = "State Name not Updated in Master Kindly update Master Customer for " + cname;
                                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                                           
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter the Valid Voucher #')", true);
                        txt_receipt.Text = "";
                        txt_receipt.Focus();
                        return;
                    }
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_ds.Tables[1];
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
                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["withoutgstAmt"].ToString()) != true)
                            {
                                double newamt = Convert.ToDouble(obj_dt.Rows[i]["withoutgstAmt"].ToString());
                                dr[5] = newamt.ToString("#0.00");
                            }
                            else
                            {
                                dr[5] = "0.00";
                            }
                            //if (string.IsNullOrEmpty(obj_dt.Rows[i]["stgst"].ToString()) != true)
                            //{
                            //    dr[6] = obj_dt.Rows[i]["stgst"].ToString();
                            //    ((TextBox)Grd_Charge.Rows[i].FindControl("amountnew")).Text = obj_dt.Rows[i]["stgst"].ToString();
                            //}
                            //else
                            //{
                            //    ((Label)Grd_Charge.Rows[i].FindControl("amountnew")).Text = "0.00";
                            //}
                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["cgsta"].ToString()) != true)
                            {
                                double amt2 = Convert.ToDouble(obj_dt.Rows[i]["cgsta"].ToString());
                                dr[6] = amt2.ToString("#0.00");
                            }
                            else
                            {
                                dr[6] = "0.00";
                            }

                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["sgata"].ToString()) != true)
                            {
                                double amt = Convert.ToDouble(obj_dt.Rows[i]["sgata"].ToString());
                                dr[7] = amt.ToString("#0.00");
                                // Total = Total + amt;
                            }
                            else
                            {
                                dr[7] = "0.00";
                                //Total = Total + 0;
                            }

                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["igsta"].ToString()) != true)
                            {
                                double amt = Convert.ToDouble(obj_dt.Rows[i]["igsta"].ToString());
                                dr[8] = amt.ToString("#0.00");
                                //  Total = Total + amt;
                            }
                            else
                            {
                                dr[8] = "0.00";
                                // Total = Total + 0;
                            }


                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["amount"].ToString()) != true)
                            {
                                double amt = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                dr[9] = amt.ToString("#0.00");
                                Total = Total + amt;
                            }
                            else
                            {
                                dr[9] = "0.00";
                                Total = Total + 0;
                            }

                            dr[10] = obj_dt.Rows[i]["groupid"].ToString();
                            dr[11] = obj_dt.Rows[i]["chargeid"].ToString();

                            // Total = Total + double.Parse(obj_dt.Rows[i]["amount"].ToString());
                        }

                    }
                    txt_total.Text = string.Format("{0:#,##0.00}", Total);
                    Grd_Charge.DataSource = dtempty;
                    Grd_Charge.DataBind();
                    
                    //   Grd_Charge.DataSource = obj_ds.Tables[1];
                    // Grd_Charge.DataBind();
                    // Grd_Tax.DataSource = obj_ds.Tables[2];
                    //    Grd_Tax.DataBind();

                    //for (int i = 0; i <= obj_ds.Tables[1].Rows.Count - 1; i++)
                    //{
                    //    Total = Total + double.Parse(obj_ds.Tables[1].Rows[i]["amount"].ToString());
                    //}
                    //for (int i = 0; i <= obj_ds.Tables[2].Rows.Count - 1; i++)
                    //{
                    //    Total = Total + double.Parse(obj_ds.Tables[2].Rows[i]["amount"].ToString());
                    //}
                    //txt_total.Text = string.Format("{0:0.00}", Total);
                }
            }
            btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        //protected void Grd_Charge_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //Label lblcharge = (Label)e.Row.FindControl("charge");
        //        //string tooltip1 = lblcharge.Text;
        //        //e.Row.Cells[0].Attributes.Add("title", tooltip1);

        //        //ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
        //        //lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
        //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Charge, "Select$" + e.Row.RowIndex);
        //        e.Row.Attributes["style"] = "cursor:pointer";
        //    }
        //}

        protected void btn_update_Click(object sender, EventArgs e)
        {
            //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            //DataAccess.Accounts.STAdjustment obj_da_ST = new DataAccess.Accounts.STAdjustment();
            

            CheckData();
            if (blnerr == true)
            {
                blnerr = false;
                return;
            }

            if (obj_da_Invoice.CheckTDSApplyORNot(ddl_voucher.SelectedValue.ToString(), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString())) != 0)
            {
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('Alredy TDS Has Been Applied So You Cannot amend GST');", true);
                return;
            }
            else
            {
                if (Session["hid_gstdate"] != null)
                {
                    if (Convert.ToDateTime(obj_da_Log.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                    {
                        if (hid_supplyto.Value == "0" || hid_supplyto.Value == "")
                        {
                            StrScript = "Suppply To not updated for the Voucher #: " + txt_receipt.Text;
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                            return;
                        }                        
                        else
                        {
                            if (hid_supplyto.Value != "0" || hid_supplyto.Value != "")
                            {
                                DataTable dt_list = new DataTable();
                                //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
                                dt_list = customerobj.GetIndianCustomergstadd(Convert.ToInt32(hid_supplyto.Value));
                                if (dt_list.Rows.Count > 0)
                                {
                                    cname = dt_list.Rows[0]["customername"].ToString();
                                    if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                    {
                                        if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                        {
                                            StrScript = "GST TYPE not Updated for the Customer Name : " + cname + " in the Voucher #" + txt_receipt.Text;
                                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    cname = obj_mascust.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                                    StrScript = "State Name not Updated in Master Kindly update Master Customer for " + cname;
                                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                                    return;
                                }
                            }
                        }
                    }
                }
                foreach (GridViewRow row in Grd_Charge.Rows)
                {
                    double OverallAmt = 0;
                    double amt1 = 0, amt2 = 0, amt3 = 0;
                    double totamt = 0;
                    int int_chargeid = Convert.ToInt32(Grd_Charge.Rows[row.RowIndex].Cells[11].Text.ToString());
                    string stramdbase = Grd_Charge.Rows[row.RowIndex].Cells[4].Text.ToString();
                    TextBox Txt_Amount = (TextBox)row.FindControl("cgsta");

                    if (string.IsNullOrEmpty(Txt_Amount.Text) != true)
                    {
                        amt1 = Convert.ToDouble(Txt_Amount.Text);
                    }
                    else
                    {
                        amt1 = 0;
                    }
                    TextBox Txt_Amount1 = (TextBox)row.FindControl("sgata");
                    if (string.IsNullOrEmpty(Txt_Amount1.Text) != true)
                    {
                        amt2 = Convert.ToDouble(Txt_Amount1.Text);
                    }
                    else
                    {
                        amt2 = 0;
                    }
                    TextBox Txt_Amount2 = (TextBox)row.FindControl("igsta");
                    if (string.IsNullOrEmpty(Txt_Amount2.Text) != true)
                    {
                        amt3 = Convert.ToDouble(Txt_Amount2.Text);
                    }
                    else
                    {
                        amt3 = 0;
                    }

                    totamt = Convert.ToDouble(Grd_Charge.Rows[row.RowIndex].Cells[5].Text.ToString());
                    OverallAmt = totamt + amt3 + amt2 + amt1;
                    obj_da_ST.UpdateChargesForNew(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), int_chargeid, OverallAmt, hid_type.Value.ToString(), stramdbase, amt3, amt1, amt2);
                }
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('Gst has Updated');", true);
                txt_receipt_TextChanged(sender, e);
                switch (ddl_voucher.SelectedItem.Text)
                {
                    case "Credit Note - Operations":
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-PayAdmin-Upd" + hid_type.Value.ToString() + "-" + txt_receipt.Text);
                        break;
                    case "Admin Purchase Invoice":
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-AdminPA-Upd" + hid_type.Value.ToString() + "-" + txt_receipt.Text);
                        break;
                    case "Other Credit Note":
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-OtherCredNote-Upd" + hid_type.Value.ToString() + "-" + txt_receipt.Text);
                        break;
                }

            }
            btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_trantype = "", Str_Horm = "", Str_Custtype = "";
            Str_trantype = hid_trantype.Value.ToString();
            Str_Horm = hid_horm.Value.ToString();
            Str_Custtype = hid_Custtype.Value.ToString();
            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            switch (ddl_voucher.SelectedIndex)
            {
                case 0:
                    if (txt_receipt.Text.Trim().Length == 0)
                    {
                        Str_RptName = "PARegister.rpt";
                        Str_sp = "Title=CREDIT NOTE - OPERATIONS REGISTER";
                        Str_sf = "{PAHead.branchid}=" + int_bid.ToString() + " and {PAHead.vouyear}=" + txt_year.Text + " and {PAHead.trantype}=\"" + Str_trantype + "\"";
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        if (Str_trantype == "FE")
                        {
                            if (Str_Horm == "H")
                            {
                                Str_RptName = "FEPA.rpt";
                            }
                            else
                            {
                                Str_RptName = "FEMPA.rpt";
                            }
                            Str_sp = "Lcurr=INR";
                        }
                        else if (Str_trantype == "FI")
                        {
                            if (Str_Horm == "H")
                            {
                                Str_RptName = "FIPA.rpt";
                            }
                            else
                            {
                                Str_RptName = "FIMPA.rpt";
                            }
                        }
                        else if (Str_trantype == "AE")
                        {
                            if (Str_Horm == "H")
                            {
                                Str_RptName = "AEPA.rpt";
                            }
                            else
                            {
                                Str_RptName = "AEMPA.rpt";
                            }
                            Str_sp = "Lcurr=INR";
                        }
                        else if (Str_trantype == "AI")
                        {
                            if (Str_Horm == "H")
                            {
                                Str_RptName = "AIPA.rpt";
                            }
                            else
                            {
                                Str_RptName = "AIMPA.rpt";
                            }
                            Str_sp = "Lcurr=INR";
                        }
                        else if (Str_trantype == "CH")
                        {
                            Str_RptName = "CHAPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        Str_sf = "{PAHead.trantype}=\"" + Str_trantype + "\" and {PAHead.pano}=" + txt_receipt.Text + " and {PAHead.branchid}=" + int_bid.ToString() + " and {PAHead.vouyear}=" + txt_year.Text;
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    break;
                case 1:
                    if (txt_receipt.Text.Trim().Length == 0)
                    {
                        Str_RptName = "AdmCreditRegister.rpt";
                        Str_sp = "Title=Credit Note  - Admin Register";
                        Str_sf = "{AdmCNHead.branchid}=" + int_bid.ToString();
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        Str_RptName = "AdmCredit.rpt";
                        Str_sf = "{AdmCNHead.cnno}=" + txt_receipt.Text + " and {AdmCNHead.vouyear}=" + txt_year.Text + " and {AdmCNHead.branchid}=" + int_bid.ToString() + " and {AdmCNHead.deleted}=\"N\"";
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    break;
                case 2:
                    if (txt_receipt.Text.Trim().Length == 0)
                    {
                        Str_RptName = "OthCNRegister.rpt";
                        Str_sp = "Title=CREDIT NOTE REGISTER";
                        Str_sf = "{CNHead.branchid}=" + int_bid.ToString() + " and {CNHead.vouyear}=" + txt_year.Text + " and {CNHead.trantype}=\"" + Str_trantype + "\"";
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        if (Str_trantype == "FE")
                        {
                            if (Str_Custtype == "P")
                            {
                                Str_RptName = "FECNAgent.rpt";
                            }
                            else
                            {
                                Str_RptName = "FECN.rpt";
                            }
                            Str_sp = "Lcurr=INR~container=";
                        }
                        else if (Str_trantype == "FI")
                        {
                            if (Str_Custtype == "P")
                            {
                                Str_RptName = "FICNAgent.rpt";
                            }
                            else
                            {
                                Str_RptName = "FICN.rpt";
                            }
                        }
                        else if (Str_trantype == "AE")
                        {
                            if (Str_Custtype == "P")
                            {
                                Str_RptName = "AECNAgent.rpt";
                            }
                            else
                            {
                                Str_RptName = "AECN.rpt";
                            }
                            Str_sp = "Lcurr=INR";
                        }
                        else if (Str_trantype == "AI")
                        {
                            if (Str_Custtype == "P")
                            {
                                Str_RptName = "AICNAgent.rpt";
                            }
                            else
                            {
                                Str_RptName = "AICN.rpt";
                            }
                            Str_sp = "Lcurr=INR";
                        }
                        else if (Str_trantype == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        Str_sf = "{CNHead.trantype}=\"" + Str_trantype + "\" and {CNHead.cnno}=" + txt_receipt.Text + " and {CNHead.branchid}=" + int_bid.ToString() + " and {CNHead.vouyear}=" + txt_year.Text + " and {CNDetails.branchid}=" + int_bid.ToString() + " and {CNDetails.vouyear}=" + txt_year.Text;
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    break;

            }
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            switch (ddl_voucher.SelectedItem.Text)
            {
                case "Credit Note - Operations":
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-PayAdmin-Vw");
                    break;
                case "Admin Purchase Invoice":
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-AdminPA-Vw");
                    break;
                case "Other Credit Note":
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-OtherCredNote-Vw");
                    break;
            }
            btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
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

        protected void CheckData()
        {
            if (txt_receipt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Voucher # Cannot Be Blank')", true);
                txt_receipt.Focus();
                blnerr = true;
                return;
            }

            if (txt_year.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Voucher year Cannot Be Blank')", true);
                txt_year.Focus();
                blnerr = true;
                return;
            }
        }

        protected void Grd_Charge_SelectedIndexChanged(object sender, EventArgs e)
        {
            int imdex = Grd_Charge.SelectedRow.RowIndex;
            hid_ind.Value = imdex.ToString();
        }

        protected void sgata_TextChanged(object sender, EventArgs e)
        {
            double overseatotal = 0;
            int index = 0;
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            index = row.RowIndex;
            double Total = 0, Total1 = 0, Total2 = 0, GrandTot = 0, overalltot = 0, Total4=0;
            int ind = 0;

            if (string.IsNullOrEmpty(Grd_Charge.Rows[index].Cells[5].Text.ToString()) != true)
            {
                Total = Total + double.Parse(Grd_Charge.Rows[index].Cells[5].Text.ToString());
            }
            else
            {
                Total = Total + 0;
            }

            TextBox Txt = (TextBox)row.FindControl("cgsta");
            TextBox Txt1 = (TextBox)row.FindControl("sgata");
            TextBox Txt2 = (TextBox)row.FindControl("igsta");
            if (string.IsNullOrEmpty(Txt2.Text) != true)
            {
                Total4 = Total4 + double.Parse(Txt2.Text);
            }
            else
            {
                Total4 = Total4 + 0;
            }

            if (string.IsNullOrEmpty(Txt.Text) != true)
            {
                Total1 = Total1 + double.Parse(Txt.Text);
            }
            else
            {
                Total1 = Total1 + 0;
            }

            if (string.IsNullOrEmpty(Txt1.Text) != true)
            {
                Total2 = Total2 + double.Parse(Txt1.Text);
            }
            else
            {
                Total2 = Total2 + 0;
            }
            overalltot = Total + Total1 + Total2 + Total4;
            //TextBox Txt1 = (TextBox)totalrow.FindControl("txt_amount");
            row.Cells[9].Text = overalltot.ToString("#0.00");
            GrandTot = GrandTot + overalltot;


            //ind=Convert.ToInt32(hid_ind.Value );
            for (int i = 0; i <= Grd_Charge.Rows.Count - 1; i++)
            {

                if (string.IsNullOrEmpty(txt_total.Text) != true)
                {

                }
                else
                {
                    txt_total.Text = "0.00";
                }


                if (string.IsNullOrEmpty(Grd_Charge.Rows[i].Cells[9].Text.ToString()) != true)
                {

                }
                else
                {
                    Grd_Charge.Rows[i].Cells[9].Text = "0.00";
                }

                overseatotal = overseatotal + Convert.ToDouble(Grd_Charge.Rows[i].Cells[9].Text.ToString());
            }
            txt_total.Text = overseatotal.ToString("#0.00");
            //hid_ind.Value 
            //txt_total.Text = string.Format("{0:0.00}", GrandTot);
        }

        protected void igsta_TextChanged(object sender, EventArgs e)
        {
            double overseatotal = 0;
            int index = 0;
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            index = row.RowIndex;
            double Total = 0, Total1 = 0, GrandTot = 0, overalltot = 0, Total3 = 0, Total4 = 0;
            int ind = 0;

            if (string.IsNullOrEmpty(Grd_Charge.Rows[index].Cells[5].Text.ToString()) != true)
            {
                Total = Total + double.Parse(Grd_Charge.Rows[index].Cells[5].Text.ToString());
            }
            else
            {
                Total = Total + 0;
            }

            TextBox Txt = (TextBox)row.FindControl("cgsta");
            TextBox Txt1 = (TextBox)row.FindControl("sgata");
            TextBox Txt2 = (TextBox)row.FindControl("igsta");

            if (string.IsNullOrEmpty(Txt.Text) != true)
            {
                Total1 = Total1 + double.Parse(Txt.Text);
            }
            else
            {
                Total1 = Total1 + 0;
            }

            if (string.IsNullOrEmpty(Txt1.Text) != true)
            {
                Total3 = Total3 + double.Parse(Txt1.Text);
            }
            else
            {
                Total3 = Total3 + 0;
            }

            if (string.IsNullOrEmpty(Txt2.Text) != true)
            {
                Total4 = Total4 + double.Parse(Txt2.Text);
            }
            else
            {
                Total4 = Total4 + 0;
            }
            overalltot = Total + Total1 + Total3 + Total4;
            //TextBox Txt1 = (TextBox)totalrow.FindControl("txt_amount");
            row.Cells[9].Text = overalltot.ToString("#0.00");
            GrandTot = GrandTot + overalltot;

            //ind=Convert.ToInt32(hid_ind.Value );
            for (int i = 0; i <= Grd_Charge.Rows.Count - 1; i++)
            {

                if (string.IsNullOrEmpty(txt_total.Text) != true)
                {

                }
                else
                {
                    txt_total.Text = "0.00";
                }


                if (string.IsNullOrEmpty(Grd_Charge.Rows[i].Cells[9].Text.ToString()) != true)
                {

                }
                else
                {
                    Grd_Charge.Rows[i].Cells[9].Text = "0.00";
                }

                overseatotal = overseatotal + Convert.ToDouble(Grd_Charge.Rows[i].Cells[9].Text.ToString());
            }
            //hid_ind.Value 
            txt_total.Text = string.Format("{0:0.00}", overseatotal);
        }

        protected void cgsta_TextChanged(object sender, EventArgs e)
        {
            double overseatotal = 0;
            int index = 0;
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            index = row.RowIndex;
            double Total = 0, Total1 = 0, grand = 0, Overall = 0, Total2 = 0, Total4=0;
            int ind = 0;



            if (string.IsNullOrEmpty(Grd_Charge.Rows[index].Cells[5].Text.ToString()) != true)
            {
                Total = Total + double.Parse(Grd_Charge.Rows[index].Cells[5].Text.ToString());
            }
            else
            {
                Total = Total + 0;
            }

            TextBox Txt = (TextBox)row.FindControl("cgsta");
            TextBox Txt1 = (TextBox)row.FindControl("sgata");
            TextBox Txt2 = (TextBox)row.FindControl("igsta");
            if (string.IsNullOrEmpty(Txt2.Text) != true)
            {
                Total4 = Total4 + double.Parse(Txt2.Text);
            }
            else
            {
                Total4 = Total4 + 0;
            }

            if (string.IsNullOrEmpty(Txt.Text) != true)
            {
                Total1 = Total1 + double.Parse(Txt.Text);
            }
            else
            {
                Total1 = Total1 + 0;
            }
            if (string.IsNullOrEmpty(Txt1.Text) != true)
            {
                Total2 = Total2 + double.Parse(Txt1.Text);
            }
            else
            {
                Total2 = Total2 + 0;
            }

            grand = Total + Total1 + Total2 + Total4;
            //TextBox Txt1 = (TextBox)totalrow.FindControl("txt_amount");
            row.Cells[9].Text = grand.ToString("#0.00");
            Overall = grand + Total;


            //ind=Convert.ToInt32(hid_ind.Value );

            //hid_ind.Value 

            for (int i = 0; i <= Grd_Charge.Rows.Count - 1; i++)
            {

                if (string.IsNullOrEmpty(txt_total.Text) != true)
                {

                }
                else
                {
                    txt_total.Text = "0.00";
                }


                if (string.IsNullOrEmpty(Grd_Charge.Rows[i].Cells[9].Text.ToString()) != true)
                {

                }
                else
                {
                    Grd_Charge.Rows[i].Cells[9].Text = "0.00";
                }

                overseatotal = overseatotal + Convert.ToDouble(Grd_Charge.Rows[i].Cells[9].Text.ToString());
            }

            txt_total.Text = overseatotal.ToString("#0.00");


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
           
        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1804, "", "", "", Session["StrTranType"].ToString());
     


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
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