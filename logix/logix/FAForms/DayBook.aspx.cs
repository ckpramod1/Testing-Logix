using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.FAForm
{
    public partial class DayBook : System.Web.UI.Page
    {
        DataAccess.FAVoucher DA_obj_FAV = new DataAccess.FAVoucher();
        DataAccess.FAMaster.ReportView da_obj_RV = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails da_obj_lD = new DataAccess.LogDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        string amttype = "", stramt, vouname = "", voutypename = "";           
        char status;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                DA_obj_FAV.GetDataBase(Ccode);
                da_obj_RV.GetDataBase(Ccode);
                da_obj_lD.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                


            }

            status = 'N';

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Btn_Export);

            if (IsPostBack != true)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                txt_from.Text = Utility.fn_ConvertDate(da_obj_lD.GetDate().ToShortDateString());
                txt_to.Text = Utility.fn_ConvertDate(da_obj_lD.GetDate().ToShortDateString());

                string str_CtrlLists = "txt_from~txt_to";
                btn_view.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");
                FillVouType();
                fillgrd_DayBook();

                if (Request.QueryString.ToString().Contains("Str_Name"))
                {
                    txt_from.Text = Request.QueryString["From"].ToString();
                    txt_to.Text = Request.QueryString["To"].ToString();

                    if (Request.QueryString.ToString().Contains("VoucherNo"))
                    {
                        if (Request.QueryString["VoucherNo"].ToString() != "")
                        {
                            txt_Refno.Text = Request.QueryString["VoucherNo"].ToString();
                            hid_RefID.Value = txt_Refno.Text;
                        }
                    }
                    if (Request.QueryString.ToString().Contains("Amount"))
                    {
                        if (Request.QueryString["Amount"].ToString() != "")
                        {
                            txt_Amt.Text = Request.QueryString["Amount"].ToString();
                            Hid_Amount.Value = txt_Amt.Text;
                        }
                    }
                    if (Request.QueryString.ToString().Contains("ddl_VouType"))
                    {
                        if (Request.QueryString["ddl_VouType"].ToString() != "")
                        {
                            ddl_VouType.SelectedValue = Request.QueryString["ddl_VouType"].ToString();
                            Hid_ddlVoutype.Value = Request.QueryString["ddl_VouType"].ToString();
                        }
                    }
                    if (Request.QueryString.ToString().Contains("ddl_AmtType"))
                    {
                        if (Request.QueryString["ddl_AmtType"].ToString() != "")
                        {
                            ddl_AmtType.SelectedItem.Text = Request.QueryString["ddl_AmtType"].ToString();
                            Hid_ddl_AmtType.Value = Request.QueryString["ddl_AmtType"].ToString();
                        }
                    }

                    status = 'N';
                    FillVouType();
                    fillgrd_DayBook();
                }


               btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }


            hid_from.Value = txt_from.Text;
            hid_to.Value = txt_to.Text;
        }

        [WebMethod]
        public static List<string> GetRefNo(string prefix)
        {
            List<string> List_Result = new List<string>();
            string FADbname = HttpContext.Current.Session["FADbname"].ToString();
            int Branch_ID = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int Division_ID = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int EmpId = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());

            DataAccess.FAMaster.ReportView da_obj_RV = new DataAccess.FAMaster.ReportView();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_RV.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            dt = da_obj_RV.GetLikeRefno(prefix, Division_ID, Branch_ID, FADbname);
            List_Result = Utility.Fn_DttableToList(dt, "RefNo");
            return List_Result;
        }

        public void fillgrd_DayBook()
        {
            int Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());
            string dbname = Session["FADbname"].ToString();
            int intVouTypeID;
           
            if (Hid_ddlVoutype.Value != "")
            {
                intVouTypeID = Convert.ToInt32(Hid_ddlVoutype.Value);
            }
            else
            {
                intVouTypeID = Convert.ToInt32(ddl_VouType.SelectedValue);               
            }
             
            if (hid_RefID.Value != "")
            {
                txt_Refno.Text = hid_RefID.Value;                               
            }
            
            if (txt_Amt.Text.ToString() == "")
            {
                stramt = "0";
            }
            else
            {
                stramt = txt_Amt.Text.ToString();
            }

            if (ddl_AmtType.SelectedItem.ToString() == "Equals")
            {
                amttype = "=";
            }
            else if (ddl_AmtType.SelectedItem.ToString() == "Greater")
            {
                amttype = ">=";
            }
            else if (ddl_AmtType.SelectedItem.ToString() == "Less")
            {
                amttype = "<=";
            }           

            dt = da_obj_RV.FASelDayBookNew_web(dbname, Branch_Id, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString())), status, intVouTypeID, Convert.ToDouble(stramt), amttype, txt_Refno.Text.Trim());

            DataView dv = new DataView(dt);
            DataTable dt_DayaBook = new DataTable();

            dt_DayaBook = dv.ToTable();
            DataRow dr = dt_DayaBook.NewRow();

            dr["shortname"] = "Total";
            dr["ladr"] = dt.Compute("sum(ladr)", string.Empty);
            dr["lacr"] = dt.Compute("sum(lacr)", string.Empty);
            dt_DayaBook.Rows.Add(dr);

            grd_DayBook.DataSource = dt_DayaBook;
            grd_DayBook.DataBind();
            ViewState["DayBook"] = dt;
        }
       
        protected void btnview_Click(object sender, EventArgs e)
        {
            int BranchId = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int Emp_ID = Convert.ToInt32(Session["LoginEmpId"]);
            try
            {
                status = 'Y';

                int Days = da_obj_RV.DateDiffernce(Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString())));

                if (Days > 31)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Allowed 1 Month Datas Only')", true);
                    return;
                }

                fillgrd_DayBook();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }


            if (Session["str_ModuleName"] == "FA")
            {
                da_obj_lD.InsLogDetail(Emp_ID, 1107, 3, BranchId, "/V");
            }
            else
            {
                da_obj_lD.InsLogDetail(Emp_ID, 1201, 3, BranchId, "/V");
            }
        }

        public void FillVouType()
        {            
            DataSet dt_set = new DataSet();
            dt_set = DA_obj_FAV.GetAllVoucherTypes(Session["FADbname"].ToString());
            if (dt_set.Tables[1].Rows.Count > 0)
            {
                ddl_VouType.DataTextField = "voutypename";
                ddl_VouType.DataValueField = "voutypeid";
                ddl_VouType.DataSource = dt_set.Tables[1];
                ddl_VouType.DataBind();
            }
        }

        protected void grd_DayBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string vouType, Voudate, str_osvtype, Vou_No, Amount;
                int vouNo, index, PBranch_ID = 0, PBid;
                bool flag = false;

                if (grd_DayBook.Rows.Count > 0)
                {
                    Vou_No = txt_Refno.Text;
                    Amount = txt_Amt.Text;
                    index = grd_DayBook.SelectedIndex;
                    vouType = grd_DayBook.SelectedRow.Cells[1].Text;
                    vouNo = Convert.ToInt32(grd_DayBook.SelectedRow.Cells[2].Text);
                    Voudate = grd_DayBook.SelectedRow.Cells[0].Text;
                    PBranch_ID = Convert.ToInt32(grd_DayBook.SelectedDataKey["PBid"].ToString());
                    str_osvtype = grd_DayBook.SelectedDataKey["OSVType"].ToString();

                    if (vouType != "")
                    {
                        if (vouType == "Sales Invoice" || vouType == "Sales Invoice")
                        {
                            vouname = "Sales Invoice";
                            flag = true;
                        }
                        if (vouType == "Purchase Invoice")
                        {
                            vouname = "Purchase Invoice";
                            flag = true;
                        }
                        if (vouType == "OS DN" || vouType == "OSSI")
                        {
                            vouname = "OSSI";
                            flag = true;
                        }
                        if (vouType == "OS CN" || vouType == "OSPI")
                        {
                            vouname = "OSPI";
                            flag = true;
                        }
                        if (vouType == "Debit Note" || vouType == "Debit Note - Others")
                        {
                            vouname = "Debit Note - Others";
                            flag = true;
                        }
                        if (vouType == "Credit Note" || vouType == "Credit Note - Others")
                        {
                            vouname = "Credit Note - Others";
                            flag = true;
                        }
                        if (vouType == "Proforma Invoices")
                        {
                            vouname = "Proforma Invoices";
                            flag = true;
                        }
                        if (vouType == "Extentions")
                        {
                            vouname = "Extentions";
                            flag = true;
                        }
                        if (vouType == "FinalBills")
                        {
                            vouname = "FinalBills";
                            flag = true;
                        }
                        if (vouType == "OSDNCNJV")
                        {
                            vouname = "OSDNCNJV";
                            flag = true;
                        }

                        if (flag == true)
                        {
                            string FrmName = "DayBook_Voucher";
                            //Response.Redirect("../FAForms/Voucher.aspx?FormName=" + vouname + "&VType=" + vouType + "&Vno=" + vouNo + "&Vdate=" + Voudate + "&PBranch_ID=" + PBranch_ID.ToString() + "&OsvType=" + str_osvtype + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text);

                            iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?FormName=" + vouname + "&VType=" + vouType + "&Vno=" + vouNo + "&Vdate=" + Voudate + "&PBranch_ID=" + PBranch_ID.ToString() + "&OsvType=" + str_osvtype + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text;
                            ModalPopupExtender1.Show();
                            return;
                        }
                    }

                    if (vouType != "")
                    {
                        if (vouType == "Journal")
                        {
                            string FrmName = "DayBook_Journal";
                            //Response.Redirect("../FAForms/Journal.aspx?VType=" + vouType + "&Vno=" + vouNo + "&Vdate=" + Voudate + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text);

                            iframecost.Attributes["src"] = "../FAForms/Journal.aspx?VType=" + vouType + "&Vno=" + vouNo + "&Vdate=" + Voudate + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text;
                            ModalPopupExtender1.Show();
                            return;
                        }
                    }

                    if (vouType != "")
                    {
                        if (vouType == "Contra")
                        {
                            vouname = "Contra";
                            string FrmName = "DayBook_Contra";
                            //Response.Redirect("../FAForms/Contra.aspx?VType=" + vouType + "&Vno=" + vouNo + "&Vdate=" + Voudate + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text);

                            iframecost.Attributes["src"] = "../FAForms/Contra.aspx?VType=" + vouType + "&Vno=" + vouNo + "&Vdate=" + Voudate + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text;
                            ModalPopupExtender1.Show();
                            return;
                        }
                    }

                    if (vouType != "")
                    {
                        if (vouType == "Bank Receipt")
                        {
                            vouname = "Bank Receipt";
                            flag = true;
                        }
                        if (vouType == "Cash Receipt")
                        {
                            vouname = "Cash Receipt";
                            flag = true;
                        }
                        if (vouType == "Bank Payment")
                        {
                            vouname = "Bank Payment";
                            flag = true;
                        }
                        if (vouType == "Cash Payment")
                        {
                            vouname = "Cash Payment";
                            flag = true;
                        }
                        if (vouType == "Receipt - Petty Cash")
                        {
                            vouname = "Receipt - Petty Cash";
                            flag = true;
                        }
                        if (vouType == "BDJV")
                        {
                            vouname = "BDJV";
                            flag = true;
                        }
                        if (vouType == "BPJV")
                        {
                            vouname = "BPJV";
                            flag = true;
                        }
                        if (vouType == "Remittance-Receipt")
                        {
                            vouname = "Remittance-Receipt";
                            flag = true;
                        }
                        if (vouType == "Remittance-Payment")
                        {
                            vouname = "Remittance-Payment";
                            flag = true;
                        }
                        if (flag == true)
                        {
                            string FrmName = "DayBook_FAReceipt";
                            //Response.Redirect("../FAForms/FAReceipt.aspx?FormName=" + vouname + "&Vno=" + vouNo + "&Vdate=" + Voudate + "&PBranch_ID=" + PBranch_ID.ToString() + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text);

                            iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + vouname + "&Vno=" + vouNo + "&Vdate=" + Voudate + "&PBranch_ID=" + PBranch_ID.ToString() + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text;
                            ModalPopupExtender1.Show();
                            return;
                        }
                    }

                    if (vouType != "")
                    {
                        if (vouType == "Admin Sales Invoice")
                        {
                            vouname = "Admin Sales Invoice";
                            string FrmName = "DayBook_FAPAAdmin";
                            //Response.Redirect("../FAForms/PAAdmin.aspx?QueryVoucherName=" + vouname + "&PBranch_ID=" + PBranch_ID.ToString() + "&QueryVoucherNo=" + vouNo + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text);

                            iframecost.Attributes["src"] = "../FAForms/PAAdmin.aspx?QueryVoucherName=" + vouname + "&PBranch_ID=" + PBranch_ID.ToString() + "&QueryVoucherNo=" + vouNo + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text;
                            ModalPopupExtender1.Show();
                            return;
                        }

                        if (vouType == "Admin Purchase Invoice")
                        {
                            vouname = "Admin Purchase Invoice";
                            string FrmName = "DayBook_FAPAAdmin";
                            //Response.Redirect("../FAForms/PAAdmin.aspx?QueryVoucherName=" + vouname + "&PBranch_ID=" + PBranch_ID.ToString() + "&QueryVoucherNo=" + vouNo + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text);                   

                            iframecost.Attributes["src"] = "../FAForms/PAAdmin.aspx?QueryVoucherName=" + vouname + "&PBranch_ID=" + PBranch_ID.ToString() + "&QueryVoucherNo=" + vouNo + "&Str_Name=" + FrmName + "&FromDate=" + hid_from.Value + "&ToDate=" + hid_to.Value + "&RefNo=" + Vou_No + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType.SelectedValue + "&ddl_AmtType=" + ddl_AmtType.SelectedItem.Text;
                            ModalPopupExtender1.Show();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grd_DayBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grd_DayBook_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (grd_DayBook.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                {
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[6].Text = e.Row.Cells[6].Text;
                }
                else if (grd_DayBook.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                {
                    e.Row.Cells[5].Text = e.Row.Cells[5].Text;
                    e.Row.Cells[6].Text = "";
                }

                if (e.Row.Cells[3].Text == "Total")
                {
                    LinkButton Lnk = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Lnk_Grd");
                    Lnk.Visible = false;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp" || e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_DayBook, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }            
        }

        protected void ddl_VouType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int intVouTypeID;
                if (ddl_VouType.SelectedIndex != -1)
                {
                    if (ddl_VouType.SelectedItem.Text == "All")
                    {
                        intVouTypeID = 0;
                    }
                    else
                    {
                        intVouTypeID = Convert.ToInt32(ddl_VouType.SelectedValue);
                    }
                    //fillgrd_DayBook();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_Amt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["DayBook"] != null)
                {
                    DataTable dt_daybook = (DataTable)ViewState["DayBook"];
                    if (dt_daybook.Rows.Count > 0)
                    {
                        if (txt_Amt.Text.ToString().Length > 0)
                        {
                            if (ddl_AmtType.SelectedItem.Text == "Equals")
                            {
                                var var_temp = dt_daybook.AsEnumerable()
                                            .Where(row => Convert.ToDouble(row["ladr"]) == Convert.ToDouble(txt_Amt.Text.ToString()) || Convert.ToDouble(row["laCr"]) == Convert.ToDouble(txt_Amt.Text.ToString()));
                                if (var_temp == null || var_temp.Count() == 0)
                                {
                                    dt_daybook = null;
                                }
                                else
                                {
                                    dt_daybook = var_temp.CopyToDataTable();
                                }
                            }
                            else if (ddl_AmtType.SelectedItem.Text == "Greater")
                            {
                                var var_temp = dt_daybook.AsEnumerable()
                                           .Where(row => Convert.ToDouble(row["ladr"]) > Convert.ToDouble(txt_Amt.Text.ToString()) || Convert.ToDouble(row["laCr"]) > Convert.ToDouble(txt_Amt.Text.ToString()));
                                if (var_temp == null || var_temp.Count() == 0)
                                {
                                    dt_daybook = null;
                                }
                                else
                                {
                                    dt_daybook = var_temp.CopyToDataTable();
                                }
                            }
                            else if (ddl_AmtType.SelectedItem.Text == "Less")
                            {
                                var var_temp = dt_daybook.AsEnumerable()
                                            .Where(row => Convert.ToDouble(row["ladr"]) < Convert.ToDouble(txt_Amt.Text.ToString()) || Convert.ToDouble(row["laCr"]) < Convert.ToDouble(txt_Amt.Text.ToString()));
                                if (var_temp == null || var_temp.Count() == 0)
                                {
                                    dt_daybook = null;
                                }
                                else
                                {
                                    dt_daybook = var_temp.CopyToDataTable();
                                }
                            }
                        }

                        DataView dv = new DataView(dt_daybook);
                        DataTable dt = new DataTable();

                        dt = dv.ToTable();
                        DataRow dr = dt.NewRow();

                        dr["shortname"] = "Total";
                        dr["ladr"] = dt.Compute("sum(ladr)", string.Empty);
                        dr["lacr"] = dt.Compute("sum(lacr)", string.Empty);
                        dt.Rows.Add(dr);

                        grd_DayBook.DataSource = dt;
                        grd_DayBook.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_Refno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Refno.Text.ToString().Length > 0)
                {
                    fillgrd_DayBook();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void ddl_AmtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Amt_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_from_TextChanged(object sender, EventArgs e)
        {
            grd_DayBook.DataSource = null;
            grd_DayBook.DataBind();
            ViewState["DayBook"] = null;
        }

        protected void txt_to_TextChanged(object sender, EventArgs e)
        {
            grd_DayBook.DataSource = null;
            grd_DayBook.DataBind();
            ViewState["DayBook"] = null;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                txt_from.Text = Utility.fn_ConvertDate(da_obj_lD.GetDate().ToShortDateString());
                txt_to.Text = Utility.fn_ConvertDate(da_obj_lD.GetDate().ToShortDateString());
                grd_DayBook.DataSource = new DataTable();
                grd_DayBook.DataBind();
                ViewState["DayBook"] = null;
                txt_Refno.Text = "";
                txt_Amt.Text = "";
                ddl_VouType.SelectedIndex = 0;
                FillVouType();
                fillgrd_DayBook();
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

        protected void Btn_Export_Click(object sender, EventArgs e)
        {
            string strtemp = "";
            string Filename = "DAY BOOK";
            strtemp = Utility.Fn_ExportExcel(grd_DayBook, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");

            Response.Clear();
            Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(strtemp);
            Response.End();
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

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1107, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1201, "", "", "", Session["StrTranType"].ToString());
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_DayBook_PreRender(object sender, EventArgs e)
        {
            if (grd_DayBook.Rows.Count > 0)
            {
                grd_DayBook.UseAccessibleHeader = true;
                grd_DayBook.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}