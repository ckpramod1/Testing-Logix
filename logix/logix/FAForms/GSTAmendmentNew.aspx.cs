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

namespace logix.FAForms
{
    public partial class GSTAmendmentNew : System.Web.UI.Page
    {
        string chkvoutype;
        bool blnerr = false;
        string str_CtrlLists, str_MsgLists, str_DataType;
        string gsttype_ = "", statename_ = "", supplyto_ = "", cname = "", StrScript="";
        int gsttype = 0, statename = 0, supplyto = 0;
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer obj_mascust = new DataAccess.Masters.MasterCustomer();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

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
            dtempty.Columns.Add("txtcgstp", typeof(string));
            dtempty.Columns.Add("txtsgatp", typeof(string));
            dtempty.Columns.Add("txtigstp", typeof(string));
            dtempty.Columns.Add("Total Amount", typeof(string));
            dtempty.Columns.Add("groupid", typeof(int));
            dtempty.Columns.Add("chargeid", typeof(int));
            dtempty.Columns.Add("GSTP", typeof(int));

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

                DataAccess.Accounts.STAdjustment obj_da_ST = new DataAccess.Accounts.STAdjustment();
                obj_ds = obj_da_ST.GetServiceTaxAmtForNewPro(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_type);

                if (obj_ds.Tables.Count > 1)
                {
                    if (obj_ds.Tables[0].Rows.Count > 0)
                    {
                        hid_supplyto.Value = obj_ds.Tables[0].Rows[0]["supplyto"].ToString();
                        txt_received.Text = obj_ds.Tables[0].Rows[0]["customer"].ToString();
                        txt_detail.Text = "CNDate: " + obj_ds.Tables[0].Rows[0]["cndate"].ToString() + " RefNo: " + obj_ds.Tables[0].Rows[0]["refno"].ToString();
                        if (str_type != "AP")
                        {
                          //  hid_horm.Value = obj_ds.Tables[0].Rows[0]["horm"].ToString();
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
                                        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
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





                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["cgstp"].ToString()) != true)
                            {
                                double amt2 = Convert.ToDouble(obj_dt.Rows[i]["cgstp"].ToString());
                                dr[9] = amt2.ToString("#0");
                            }
                            else
                            {
                                dr[9] = "0";
                            }

                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["sgstp"].ToString()) != true)
                            {
                                double amt = Convert.ToDouble(obj_dt.Rows[i]["sgstp"].ToString());
                                dr[10] = amt.ToString("#0");
                                // Total = Total + amt;
                            }
                            else
                            {
                                dr[10] = "0";
                                //Total = Total + 0;
                            }

                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["igstp"].ToString()) != true)
                            {
                                double amt = Convert.ToDouble(obj_dt.Rows[i]["igstp"].ToString());
                                dr[11] = amt.ToString("#0");
                                //  Total = Total + amt;
                            }
                            else
                            {
                                dr[11] = "0";
                                // Total = Total + 0;
                            }



                            if (string.IsNullOrEmpty(obj_dt.Rows[i]["amount"].ToString()) != true)
                            {
                                double amt = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                dr[12] = amt.ToString("#0.00");
                                Total = Total + amt;
                            }
                            else
                            {
                                dr[12] = "0.00";
                                Total = Total + 0;
                            }

                            dr[13] = obj_dt.Rows[i]["groupid"].ToString();
                            dr[14] = obj_dt.Rows[i]["chargeid"].ToString();

                            dr[15] = obj_dt.Rows[i]["GSTP"].ToString();

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
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Accounts.STAdjustment obj_da_ST = new DataAccess.Accounts.STAdjustment();
            

            CheckData();
            if (blnerr == true)
            {
                blnerr = false;
                return;
            }

            //if (obj_da_Invoice.CheckTDSApplyORNot(ddl_voucher.SelectedValue.ToString(), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString())) != 0)
            //{
            //    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('Alredy TDS Has Been Applied So You Cannot amend GST');", true);
            //    return;
            //}
            //else
            //{
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
                                DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
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
                    int sgstp=0, cgstp=0,igstp=0;
                    int int_chargeid = Convert.ToInt32(Grd_Charge.Rows[row.RowIndex].Cells[14].Text.ToString());
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
                    TextBox Txt_cgstp = (TextBox)row.FindControl("cgstp");
                    
                    TextBox Txt_sgstp = (TextBox)row.FindControl("sgstp");
                    TextBox Txt_igstp = (TextBox)row.FindControl("igstp");
                    if (string.IsNullOrEmpty(Txt_sgstp.Text) != true)
                    {
                        sgstp = Convert.ToInt32(Txt_sgstp.Text);
                    }
                    else
                    {
                        sgstp = 0;
                    }

                    if (string.IsNullOrEmpty(Txt_cgstp.Text) != true)
                    {
                        cgstp = Convert.ToInt32(Txt_cgstp.Text);
                    }
                    else
                    {
                        cgstp = 0;
                    }

                    if (string.IsNullOrEmpty(Txt_igstp.Text) != true)
                    {
                        igstp = Convert.ToInt32(Txt_igstp.Text);
                    }
                    else
                    {
                        igstp = 0;
                    }


                    totamt = Convert.ToDouble(Grd_Charge.Rows[row.RowIndex].Cells[5].Text.ToString());
                    OverallAmt = totamt + amt3 + amt2 + amt1;
                    obj_da_ST.UpdateChargesForNewpro(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), int_chargeid, OverallAmt, hid_type.Value.ToString(), stramdbase, amt3, amt1, amt2, igstp, cgstp, sgstp);
                }
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "GST", "alertify.alert('Gst has Updated');", true);
                txt_receipt_TextChanged(sender, e);
                switch (Session["StrTranType"].ToString())
                {
                    case "FA":
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1833, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-PayAdmin-Upd" + hid_type.Value.ToString() + "-" + txt_receipt.Text);
                        break;
                    case "FC":
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1834, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-AdminPA-Upd" + hid_type.Value.ToString() + "-" + txt_receipt.Text);
                        break;
                    
                }

           // }
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            //int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            //string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_trantype = "", Str_Horm = "", Str_Custtype = "";
            //Str_trantype = hid_trantype.Value.ToString();
            //Str_Horm = hid_horm.Value.ToString();
            //Str_Custtype = hid_Custtype.Value.ToString();
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";

            //switch (ddl_voucher.SelectedIndex)
            //{
            //    case 0:
            //        if (txt_receipt.Text.Trim().Length == 0)
            //        {
            //            Str_RptName = "PARegister.rpt";
            //            Str_sp = "Title=CREDIT NOTE - OPERATIONS REGISTER";
            //            Str_sf = "{PAHead.branchid}=" + int_bid.ToString() + " and {PAHead.vouyear}=" + txt_year.Text + " and {PAHead.trantype}=\"" + Str_trantype + "\"";
            //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
            //            Session["str_sfs"] = Str_sf;
            //            Session["str_sp"] = Str_sp;
            //        }
            //        else
            //        {
            //            if (Str_trantype == "FE")
            //            {
            //                if (Str_Horm == "H")
            //                {
            //                    Str_RptName = "FEPA.rpt";
            //                }
            //                else
            //                {
            //                    Str_RptName = "FEMPA.rpt";
            //                }
            //                Str_sp = "Lcurr=INR";
            //            }
            //            else if (Str_trantype == "FI")
            //            {
            //                if (Str_Horm == "H")
            //                {
            //                    Str_RptName = "FIPA.rpt";
            //                }
            //                else
            //                {
            //                    Str_RptName = "FIMPA.rpt";
            //                }
            //            }
            //            else if (Str_trantype == "AE")
            //            {
            //                if (Str_Horm == "H")
            //                {
            //                    Str_RptName = "AEPA.rpt";
            //                }
            //                else
            //                {
            //                    Str_RptName = "AEMPA.rpt";
            //                }
            //                Str_sp = "Lcurr=INR";
            //            }
            //            else if (Str_trantype == "AI")
            //            {
            //                if (Str_Horm == "H")
            //                {
            //                    Str_RptName = "AIPA.rpt";
            //                }
            //                else
            //                {
            //                    Str_RptName = "AIMPA.rpt";
            //                }
            //                Str_sp = "Lcurr=INR";
            //            }
            //            else if (Str_trantype == "CH")
            //            {
            //                Str_RptName = "CHAPA.rpt";
            //                Str_sp = "Lcurr=INR";
            //            }
            //            Str_sf = "{PAHead.trantype}=\"" + Str_trantype + "\" and {PAHead.pano}=" + txt_receipt.Text + " and {PAHead.branchid}=" + int_bid.ToString() + " and {PAHead.vouyear}=" + txt_year.Text;
            //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
            //            Session["str_sfs"] = Str_sf;
            //            Session["str_sp"] = Str_sp;
            //        }
            //        break;
            //    case 1:
            //        if (txt_receipt.Text.Trim().Length == 0)
            //        {
            //            Str_RptName = "AdmCreditRegister.rpt";
            //            Str_sp = "Title=Credit Note  - Admin Register";
            //            Str_sf = "{AdmCNHead.branchid}=" + int_bid.ToString();
            //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
            //            Session["str_sfs"] = Str_sf;
            //            Session["str_sp"] = Str_sp;
            //        }
            //        else
            //        {
            //            Str_RptName = "AdmCredit.rpt";
            //            Str_sf = "{AdmCNHead.cnno}=" + txt_receipt.Text + " and {AdmCNHead.vouyear}=" + txt_year.Text + " and {AdmCNHead.branchid}=" + int_bid.ToString() + " and {AdmCNHead.deleted}=\"N\"";
            //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
            //            Session["str_sfs"] = Str_sf;
            //            Session["str_sp"] = Str_sp;
            //        }
            //        break;
            //    case 2:
            //        if (txt_receipt.Text.Trim().Length == 0)
            //        {
            //            Str_RptName = "OthCNRegister.rpt";
            //            Str_sp = "Title=CREDIT NOTE REGISTER";
            //            Str_sf = "{CNHead.branchid}=" + int_bid.ToString() + " and {CNHead.vouyear}=" + txt_year.Text + " and {CNHead.trantype}=\"" + Str_trantype + "\"";
            //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
            //            Session["str_sfs"] = Str_sf;
            //            Session["str_sp"] = Str_sp;
            //        }
            //        else
            //        {
            //            if (Str_trantype == "FE")
            //            {
            //                if (Str_Custtype == "P")
            //                {
            //                    Str_RptName = "FECNAgent.rpt";
            //                }
            //                else
            //                {
            //                    Str_RptName = "FECN.rpt";
            //                }
            //                Str_sp = "Lcurr=INR~container=";
            //            }
            //            else if (Str_trantype == "FI")
            //            {
            //                if (Str_Custtype == "P")
            //                {
            //                    Str_RptName = "FICNAgent.rpt";
            //                }
            //                else
            //                {
            //                    Str_RptName = "FICN.rpt";
            //                }
            //            }
            //            else if (Str_trantype == "AE")
            //            {
            //                if (Str_Custtype == "P")
            //                {
            //                    Str_RptName = "AECNAgent.rpt";
            //                }
            //                else
            //                {
            //                    Str_RptName = "AECN.rpt";
            //                }
            //                Str_sp = "Lcurr=INR";
            //            }
            //            else if (Str_trantype == "AI")
            //            {
            //                if (Str_Custtype == "P")
            //                {
            //                    Str_RptName = "AICNAgent.rpt";
            //                }
            //                else
            //                {
            //                    Str_RptName = "AICN.rpt";
            //                }
            //                Str_sp = "Lcurr=INR";
            //            }
            //            else if (Str_trantype == "CH")
            //            {
            //                Str_RptName = "CHACN.rpt";
            //                Str_sp = "Lcurr=INR";
            //            }
            //            Str_sf = "{CNHead.trantype}=\"" + Str_trantype + "\" and {CNHead.cnno}=" + txt_receipt.Text + " and {CNHead.branchid}=" + int_bid.ToString() + " and {CNHead.vouyear}=" + txt_year.Text + " and {CNDetails.branchid}=" + int_bid.ToString() + " and {CNDetails.vouyear}=" + txt_year.Text;
            //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "servicesTax", Str_Script, true);
            //            Session["str_sfs"] = Str_sf;
            //            Session["str_sp"] = Str_sp;
            //        }
            //        break;

            //}
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            //switch (ddl_voucher.SelectedItem.Text)
            //{
            //    case "Credit Note - Operations":
            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-PayAdmin-Vw");
            //        break;
            //    case "Admin Purchase Invoice":
            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-AdminPA-Vw");
            //        break;
            //    case "Other Credit Note":
            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1804, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), hid_trantype.Value.ToString() + "VouSTAdjust-OtherCredNote-Vw");
            //        break;
            //}

           /* try
            {
                DateTime get_date, GST_date;

                get_date = Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text));
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());

                string bltype = "", header = "";
                if (chkmbl.Checked == true)
                {
                    bltype = "M";
                }
                else
                {
                    bltype = "H";
                }
                string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";

                if (Session["StrTranTypenew"].ToString() == "LT")
                {
                    string header1 = "Invoice";
                    str_Script = "window.open('../Reportasp/Invoicerpt1.aspx?Invoiceno=" + txt_receipt.Text + "&vouyear=" + txt_year.Text + "&total=" + txtTotal.Text + "&customerid=" + hdncustid.Value + "&trantype=" + "LT" + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header1 + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Invoice", str_Script, true);
                }

                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = Session["StrTranTypenew"].ToString();

                string Str_Container = "";
            
                if (txt_receipt.Text.TrimEnd().Length > 0)
                {
                    if (str_TranType == "CH")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            str_RptName = "CHProInvoice.rpt";
                            str_sf = "{ProInvoiceHead.trantype}=\"" + str_TranType + "\"  and {ProInvoiceHead.refno}=" + txt_receipt.Text + " and {ProInvoiceHead.branchid}=" + int_branchid + " and {ProInvoiceHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            str_RptName = "CHAProPA.rpt";
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txt_receipt.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            str_RptName = "CHAProDN.rpt";
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txt_receipt.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            str_RptName = "CHAProCN.rpt";
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txt_receipt.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                        }
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                    else if (str_TranType == "FI")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FIMProInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "FIProInvoice.rpt";
                            }
                            str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txt_receipt.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FIMProPA.rpt";
                                str_sp = "Lcurr=" + Str_Container;
                            }
                            else
                            {
                                str_RptName = "FIProPA.rpt";
                                str_sp = "";
                            }
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txt_receipt.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txt_year.Text;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FIMProDN.rpt";
                            }
                            else
                            {
                                str_RptName = "FIProDN.rpt";
                            }
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txt_receipt.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FIMProCN.rpt";
                                str_sp = "Lcurr=INR~container=" + Str_Container;
                            }
                            else
                            {
                                str_RptName = "FIProCN.rpt";
                                str_sp = "container=" + Str_Container;
                            }
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txt_receipt.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txt_year.Text;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    else if (str_TranType == "CT" || str_TranType == "WH")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FEMProInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "FEProInvoice.rpt";
                            }
                            str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txt_receipt.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FEMProPA.rpt";
                            }
                            else
                            {
                                str_RptName = "FEProPA.rpt";
                            }
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txt_receipt.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FEMProDN.rpt";
                            }
                            else
                            {
                                str_RptName = "FEProDN.rpt";
                            }
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txt_receipt.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FEMProCN.rpt";
                            }
                            else
                            {
                                str_RptName = "FEProCN.rpt";
                            }
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txt_receipt.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    else if (str_TranType == "AI")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AIMProInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "AIProInvoice.rpt";
                            }
                            str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txt_receipt.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AIMProPA.rpt";
                            }
                            else
                            {
                                str_RptName = "AIProPA.rpt";
                            }
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txt_receipt.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AIMProDN.rpt";
                            }
                            else
                            {
                                str_RptName = "AIProDN.rpt";
                            }
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txt_receipt.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AIMProCN.rpt";
                            }
                            else
                            {
                                str_RptName = "AIProCN.rpt";
                            }
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txt_receipt.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    else if (str_TranType == "AE")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AEMProInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "AEProInvoice.rpt";
                            }
                            str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txt_receipt.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AEMProPA.rpt";
                            }
                            else
                            {
                                str_RptName = "AEProPA.rpt";
                            }
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txt_receipt.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AEMProDN.rpt";
                            }
                            else
                            {
                                str_RptName = "AEProDN.rpt";
                            }
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txt_receipt.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AEMProCN.rpt";
                            }
                            else
                            {
                                str_RptName = "AEProCN.rpt";
                            }
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txt_receipt.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txt_year.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    if (str_RptName.Length > 0)
                    {
                        if (get_date >= GST_date)
                        {
                            str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txt_receipt.Text + "&vouyear=" + txt_year.Text + "&total=" + txtTotal.Text + "&trantype=" + str_TranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Invoice", str_Script, true);
                    }
                }
                else
                {
                    if (str_TranType != "CH")
                    {
                        if (txt_receipt.Text.TrimEnd().Length == 0 && lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            str_RptName = "Pro PA Register.rpt";
                            str_sp = "Title=PROFORMA CREDIT NOTE - OPERATIONS REGISTER FOR VOUYEAR " + txt_year.Text;
                            str_sf = "{ACProPAHead.trantype}=\"" + str_TranType + "\" and {ACProPAHead.branchid}=" + int_branchid + " and {ACProPAHead.vouyear}=" + txt_year.Text;
                        }
                        else
                        {
                            str_RptName = "ProInvRegister.rpt";
                            str_sp = "Title=PROFORMA INVOICE REGISTER FOR VOUYEAR " + txt_year.Text;
                            str_sf = "{ACProInvoiceHead.trantype}=\"" + str_TranType + "\" and {ACProInvoiceHead.branchid}=" + int_branchid + " and {ACProInvoiceHead.vouyear}=" + txt_year.Text;
                        }
                    }
                    else if (str_TranType == "CH" && lbl_Header.Text == "Profoma Credit Note - Operations")
                    {
                        header = "PA";
                        str_RptName = "CHAProPA.rpt";
                        str_sf = "{PAHead.trantype}=\"" + str_TranType + "\" and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txt_year.Text;
                        str_sp = "Lcurr=INR";
                    }
                    else if (str_TranType == "CH" && lbl_Header.Text == "Profoma Invoice")
                    {
                        str_RptName = "ProInvRegister.rpt";
                        str_sp = "Title=PROFORMA INVOICE REGISTER FOR VOUYEAR " + txt_year.Text;
                        str_sf = "{ACProInvoiceHead.trantype}=\"" + str_TranType + "\" and {ACProInvoiceHead.branchid}=" + int_branchid + " and {ACProInvoiceHead.vouyear}=" + txt_year.Text;
                    }
                    if (str_RptName.Length > 0)
                    {
                        if (get_date >= GST_date && txt_receipt.Text != "")
                        {
                            str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txt_receipt.Text + "&vouyear=" + txt_year.Text + "&total=" + txtTotal.Text + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&blno=" + txtblno.Text + "&trantype=" + str_TranType + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Invoice", str_Script, true);
                    }
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
               
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
            */
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
            int gstp = 0;
            if (string.IsNullOrEmpty(Grd_Charge.Rows[index].Cells[5].Text.ToString()) != true)
            {
                Total = Total + double.Parse(Grd_Charge.Rows[index].Cells[5].Text.ToString());
            }
            else
            {
                Total = Total + 0;
            }

            if (string.IsNullOrEmpty(Grd_Charge.Rows[index].Cells[15].Text.ToString()) != true)
            {
                gstp = Convert.ToInt32(Grd_Charge.Rows[index].Cells[15].Text.ToString());
                gstp = gstp / 2;
            }
            else
            {
                gstp = 0;
            }

            TextBox Txt = (TextBox)row.FindControl("cgsta");
            TextBox Txt1 = (TextBox)row.FindControl("sgata");
            TextBox Txt2 = (TextBox)row.FindControl("igsta");

           // TextBox Txt3 = (TextBox)row.FindControl("cgstp");
            TextBox Txt4 = (TextBox)row.FindControl("sgstp");

            if (Convert.ToDouble(Txt1.Text) >= Total || Convert.ToDouble(Txt1.Text) > Total)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('SGSTA Greater then Actual Amt, GST does not Calculated');", true);
                Txt1.Text = "";
                Txt1.Focus();
                return;
            }


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
                //int sgstp = Convert.ToInt32((Total) / double.Parse(Txt1.Text));

                double sgstp = (double.Parse(Txt1.Text) * 100) / Total;

               // Txt4.Text = Math.Round(sgstp).ToString();


                if (sgstp <= gstp || sgstp < gstp)
                {
                    Txt4.Text = Math.Round(sgstp).ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('SGSTP should not Greater then Maximum % of charge,GST does not Calculated');", true);
                    Txt4.Text = "";
                    Txt4.Focus();
                    return;
                }
            }
            else
            {
                Txt4.Text = "0";
                Total2 = Total2 + 0;
            }
            overalltot = Total + Total1 + Total2 + Total4;
            //TextBox Txt1 = (TextBox)totalrow.FindControl("txt_amount");
            row.Cells[12].Text = overalltot.ToString("#0.00");
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


                if (string.IsNullOrEmpty(Grd_Charge.Rows[i].Cells[12].Text.ToString()) != true)
                {

                }
                else
                {
                    Grd_Charge.Rows[i].Cells[9].Text = "0.00";
                }

                overseatotal = overseatotal + Convert.ToDouble(Grd_Charge.Rows[i].Cells[12].Text.ToString());
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
            int gstp;
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

            TextBox Txt5 = (TextBox)row.FindControl("igstp");

            if (string.IsNullOrEmpty(Grd_Charge.Rows[index].Cells[15].Text.ToString()) != true)
            {
                gstp = Convert.ToInt32(Grd_Charge.Rows[index].Cells[15].Text.ToString());
            }
            else
            {
                gstp = 0;
            }


            if (Convert.ToDouble(Txt2.Text) >= Total || Convert.ToDouble(Txt2.Text) > Total)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('IGSTA Greater then Actual Amount, GST does not Calculated');", true);
                Txt2.Text = "";
                Txt2.Focus();
                return;
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
                Total3 = Total3 + double.Parse(Txt1.Text);
            }
            else
            {
                Total3 = Total3 + 0;
            }

            if (string.IsNullOrEmpty(Txt2.Text) != true)
            {
                Total4 = Total4 + double.Parse(Txt2.Text);

                //int igstp = Convert.ToInt32((Total) / double.Parse(Txt2.Text));
                //Txt5.Text = igstp.ToString();
                
                    double igstp = (double.Parse(Txt2.Text) * 100) / Total;
                    if (igstp <= gstp || igstp < gstp )
                    {
                        Txt5.Text = Math.Round(igstp).ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('IGSTP should not Greater then Maximum % of charge,GST does not Calculated');", true);
                        Txt5.Text = "";
                        Txt5.Focus();
                        return;
                    }
                
            }
            else
            {

                Txt5.Text = "0";
                Total4 = Total4 + 0;
            }
            overalltot = Total + Total1 + Total3 + Total4;
            //TextBox Txt1 = (TextBox)totalrow.FindControl("txt_amount");
            row.Cells[12].Text = overalltot.ToString("#0.00");
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


                if (string.IsNullOrEmpty(Grd_Charge.Rows[i].Cells[12].Text.ToString()) != true)
                {

                }
                else
                {
                    Grd_Charge.Rows[i].Cells[9].Text = "0.00";
                }

                overseatotal = overseatotal + Convert.ToDouble(Grd_Charge.Rows[i].Cells[12].Text.ToString());
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
            int gstp = 0;


            if (string.IsNullOrEmpty(Grd_Charge.Rows[index].Cells[5].Text.ToString()) != true)
            {
                Total = Total + double.Parse(Grd_Charge.Rows[index].Cells[5].Text.ToString());
            }
            else
            {
                Total = Total + 0;
            }
            if (string.IsNullOrEmpty(Grd_Charge.Rows[index].Cells[15].Text.ToString()) != true)
            {
                gstp = Convert.ToInt32(Grd_Charge.Rows[index].Cells[15].Text.ToString());
                gstp = gstp / 2;
            }
            else
            {
                gstp = 0;
            }



            TextBox Txt = (TextBox)row.FindControl("cgsta");
            TextBox Txt1 = (TextBox)row.FindControl("sgata");
            TextBox Txt2 = (TextBox)row.FindControl("igsta");

            TextBox Txt3 = (TextBox)row.FindControl("cgstp");
           // TextBox Txt4 = (TextBox)row.FindControl("cgstp");
            if (Convert.ToDouble(Txt.Text) >= Total || Convert.ToDouble(Txt.Text) > Total)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('CGSTA Greater then Actual Amount, GST does not Calculated');", true);
                Txt.Text = "";
                Txt.Focus();
                return;
            }
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
               // int cgstp= Convert.ToInt32((Total) / double.Parse(Txt.Text));


                double cgstp = (double.Parse(Txt.Text) * 100) / Total;

                //Txt3.Text = Math.Round(cgstp).ToString();


                if (cgstp <= gstp || cgstp < gstp)
                {
                    Txt3.Text = Math.Round(cgstp).ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('CGSTP should not Greater then Maximum % of charge,GST does not Calculated');", true);
                    Txt3.Text = "";
                    Txt3.Focus();
                    return;
                }

               // Txt3.Text = cgstp.ToString();
            }
            else
            {
              
                Txt3.Text = "0";
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
            row.Cells[12].Text = grand.ToString("#0.00");
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


                if (string.IsNullOrEmpty(Grd_Charge.Rows[i].Cells[12].Text.ToString()) != true)
                {

                }
                else
                {
                    Grd_Charge.Rows[i].Cells[9].Text = "0.00";
                }

                overseatotal = overseatotal + Convert.ToDouble(Grd_Charge.Rows[i].Cells[12].Text.ToString());
            }

            txt_total.Text = overseatotal.ToString("#0.00");
            

        }

        protected void igstp_TextChanged(object sender, EventArgs e)
        {
           double overseatotal = 0;
            int index = 0;
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            index = row.RowIndex;
            double Total = 0, Total1 = 0, grand = 0, Overall = 0, Total2 = 0, Total4 = 0;
            int ind = 0;
            int gstp = 0;


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

            TextBox Txt3 = (TextBox)row.FindControl("cgstp");
            TextBox Txt4 = (TextBox)row.FindControl("sgstp");
            TextBox Txt5 = (TextBox)row.FindControl("igstp");

            if (Convert.ToDouble(Txt2.Text) > Total || Convert.ToDouble(Txt2.Text) >= Total)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('IGSTA Greater then Actual Amount, GST does not Calculated');", true);
                Txt2.Text = "";
                Txt2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Txt2.Text) != true)
            {
                double d1 = Total * (double.Parse(Txt5.Text) / 100);
                if (Convert.ToDouble(d1) >= Total || Convert.ToDouble(d1) > Total)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('IGSTP should not Greater then Maximum % of charge,GST does not Calculated');", true);
                    Txt5.Text = "";
                    Txt5.Focus();
                    return;
                }
                Total1 = d1;
                Txt2.Text = Total1.ToString("#0.00");
            }
            else
            {
                Total1 = Total + 0;
                Txt2.Text = Total1.ToString("#0.00");
            }
            igsta_TextChanged(sender, e);


        }

        protected void sgatp_TextChanged(object sender, EventArgs e)
        {
           

            double overseatotal = 0;
            int index = 0;
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            index = row.RowIndex;
            double Total = 0, Total1 = 0, grand = 0, Overall = 0, Total2 = 0, Total4 = 0;
            int ind = 0;
            int gstp = 0;


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

            TextBox Txt3 = (TextBox)row.FindControl("cgstp");
            TextBox Txt4 = (TextBox)row.FindControl("sgstp");


            if (Convert.ToDouble(Txt1.Text) >= Total || Convert.ToDouble(Txt1.Text) > Total)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('SGSTA Greater then Actual Amount,GST does not Calculated');", true);
                Txt1.Text = "";
                Txt1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Txt1.Text) != true)
            {
                double d1 = Total * (double.Parse(Txt4.Text) / 100);
                if (Convert.ToDouble(d1) >= Total || Convert.ToDouble(d1) > Total)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('SGSTP should not Greater then Maximum % of charge,GST does not Calculated');", true);
                    Txt4.Text = "";
                    Txt4.Focus();
                    return;
                }
                Total1 = d1;
                Txt1.Text = Total1.ToString("#0.00");
            }
            else
            {
                Total1 = Total + 0;
                Txt1.Text = Total1.ToString("#0.00");
            }
            sgata_TextChanged(sender, e);

        }

        protected void cgstp_TextChanged(object sender, EventArgs e)
        {
            double overseatotal = 0;
            int index = 0;
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            index = row.RowIndex;
            double Total = 0, Total1 = 0, grand = 0, Overall = 0, Total2 = 0, Total4 = 0;
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
            TextBox Txt3 = (TextBox)row.FindControl("cgstp");

            if (Convert.ToDouble(Txt.Text) >= Total || Convert.ToDouble(Txt.Text) > Total)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('CGSTA Greater then Actual Amount, GST does not Calculated');", true);
                Txt.Text = "";
                Txt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Txt.Text) != true)
            {
                double d1 = Total * (double.Parse(Txt3.Text) / 100);
                if (Convert.ToDouble(d1) >= Total || Convert.ToDouble(d1) > Total)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "GST", "alertify.alert('CGSTP should not Greater then Maximum % of charge,GST does not Calculated');", true);
                    Txt3.Text = "";
                    Txt3.Focus();
                    return;
                }
                Total1 = d1;
                Txt.Text = Total1.ToString("#0.00");
            }
            else
            {
                Total1 = Total + 0;
                Txt.Text = Total1.ToString("#0.00");
            }
            cgsta_TextChanged(sender, e);



           

        }

        protected void Grd_Charge_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                for (int i=0;i<e.Row.Cells.Count;i++)
                {
                    if(e.Row.Cells[i].Text=="&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
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
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1833, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1834, "", "", "", Session["StrTranType"].ToString());
            }


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