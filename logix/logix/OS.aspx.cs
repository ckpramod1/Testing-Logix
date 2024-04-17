using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using System.IO;
namespace logix
{
    public partial class OS : System.Web.UI.Page
    {
        Calendar CldrFrom, CldrTo;
        public static DataTable Dt, dtCustIDs, DtCombined;
        Calendar CldrTemp = new Calendar();
        //ReportShow rptobj;
        CustomerDataAccess.RegCustomer CustObj = new CustomerDataAccess.RegCustomer();
        public static int intCustID;
        public int intSelIndex = -1;
        public int intRecptid = 0;
        public string strMode, strRptFN, strSF;
        public GrdToExcel grd2exObj = new GrdToExcel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                //CldrFrom = new Calendar(this.Page, dtFrom, ImgFrom);
                //CldrTo = new Calendar(this.Page, dtTo, imgTo);
            }
            if (Request.QueryString["uid"] != null && Request.QueryString["uid"] != "")
                intCustID = int.Parse(Request.QueryString["uid"].ToString());
            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnExcel);
            //int time;
            //DateTime now;
            //now = DateTime.Now;
            //time = DateTime.Now.Hour;
            //DataTable dt = new DataTable();

            //if (time < 13)
            //{
            //    dt = CustObj.Oustd10AM4WS(1, Convert.ToInt32(Session["webgroupid"].ToString()));
            //    grd.DataSource = dt;
            //    grd.DataBind();
            //}
            //else if (time >= 13 && time < 16)
            //{
            //    dt = CustObj.Oustd12N4WS(1, Convert.ToInt32(Session["webgroupid"].ToString()));
            //    grd.DataSource = dt;
            //    grd.DataBind();
            //}
            //else if (time >= 16 && time < 23)
            //{
            //    dt = CustObj.Oustd3PM4WS(1, Convert.ToInt32(Session["webgroupid"].ToString()));
            //    grd.DataSource = dt;
            //    grd.DataBind();
            //}

            if (intCustID != 0 && intCustID.ToString() != "")
            {
                DataTable dt = CustObj.OutStandingAll(1, 99999, 40, null, Convert.ToInt32(Session["webgroupid"].ToString()), 13);
                if (dt.Rows.Count > 0)
                {
                    double sum = Convert.ToDouble(dt.Compute("sum(vamount)", ""));
                    DataRow dr;
                    dr = dt.NewRow();
                    dr[8] = "Total";
                    dr[9] = sum;
                    dt.Rows.Add(dr);
                    grd.DataSource = dt;
                    grd.DataBind();
                    ViewState["Outstanding"] = dt;
                }
            }
        }

        //protected void btnView_Click(object sender, EventArgs e)
        //{
        //    intCustID = int.Parse(Session["webgroupid"].ToString());
        //    //CustObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsReceipts, DateTime.Now, dtFrom.Text + " to " + dtTo.Text);
        //    //Dt = CustObj.GetRecptforCust(intCustID, DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text)), DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text)));
        //    //grd.DataSource = Dt;
        //    //grd.DataBind();

        //    string find = "";
        //    DateTime FromDate;
        //    DateTime ToDate;

        //    FromDate = DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
        //    ToDate = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));

        //    find = CustObj.SPGetDBName4Jsonnew(FromDate, ToDate);

        //    if (find!="2")
        //    {
        //        FillGrid(find);
        //    }
        //    else if(find=="2")
        //    {
        //        lblError.Text = "Date Should be Same Financial Year...";
        //        return;
        //    }

        //    //if (Dt.Rows.Count != 0)
        //    //{
        //    //    btnToExcel.Enabled = true;
        //    //    lblError.Text = "";          
        //    //}
        //    //else
        //    //{
        //    //    lblError.Text = "No data available";         
        //    //}
        //}

        //[WebMethod]
        //public static List<string> GetLikeLedgerName(string prefix)
        //{
        //    List<string> LedgerName = new List<string>();
        //    DataTable obj_dt = new DataTable();
        //    CustomerDataAccess.RegCustomer CustObj = new CustomerDataAccess.RegCustomer();

        //    obj_dt = CustObj.getlikeledgername4web(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["webgroupid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
        //    HttpContext.Current.Session["LV_Ledger"] = obj_dt;
        //    LedgerName = Fn_TableToList(obj_dt, "LedgerName", "Ledgerid", "opsid");
        //    return LedgerName;
        //}

        //public static List<string> Fn_TableToList(DataTable dt, string str_Textfield, string str_Valuefield, string str_Value)
        //{
        //    List<string> lst_details = new List<string>();
        //    lst_details = (from r in dt.AsEnumerable()
        //                   select r[str_Textfield].ToString() + "~" + r[str_Valuefield].ToString() + "~" + r[str_Value].ToString()).ToList();

        //    return lst_details;
        //}

        //private void FillGrid(string dbname)
        //{
        //    //grd_DayWise.Visible = false;
        //    grd.Visible = true;
        //    //grd_Monthwise.Visible = false;

        //    DataSet ds_OpBal = new DataSet();
        //    DataTable dt_Tans = new DataTable();
        //    //grd_Monthwise.Visible = false;
        //    grd.Visible = true;
        //    DateTime FromDate;
        //    DateTime ToDate;

        //    DataAccess.FAMaster.ReportView da_obj_rv = new DataAccess.FAMaster.ReportView();
        //    DataAccess.LogDetails da_obj_log = new DataAccess.LogDetails();
        //    string ctrlList;
        //    string msgList;
        //    string dtypeList;
        //    double dbl_temp = 0;
        //    int int_ledgerid = 0;

        //    FromDate =  DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
        //    ToDate = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));

        //    //if (chkConsolidate.Checked)
        //    //{
        //    //ds_OpBal = CustObj.FASelopbal4AllBranch(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, dbname, Convert.ToInt32(Session["LoginDivisionId"]));
        //    //dt_Tans = CustObj.FAselLedgergrd4AllBranch(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, dbname, Convert.ToInt32(Session["LoginDivisionId"]));
        //    //}
        //    //else
        //    //{
        //    ds_OpBal = CustObj.FASelopbal4webcs(Convert.ToInt32(Session["webgroupid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString());
        //    dt_Tans = CustObj.FAselLedgergrdcs(Convert.ToInt32(Session["webgroupid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString());
        //    //}

        //    DataRow dr_temp;
        //    dr_temp = dt_Tans.NewRow();
        //    dr_temp["voudate"] = dtFrom.Text;
        //    dr_temp["Vouno"] = -1;
        //    dr_temp["ltype"] = "Cr";
        //    dr_temp["prti"] = "Opening Balance";
        //    dr_temp["amount"] = 0;
        //    if (ds_OpBal.Tables[0].Rows.Count > 0)
        //    {
        //        if (Convert.ToDouble(ds_OpBal.Tables[0].Rows[0]["NewTransDebit"].ToString()) > 0)
        //        {
        //            dr_temp["ltype"] = "Dr";
        //            dr_temp["amount"] = Convert.ToDouble(ds_OpBal.Tables[0].Rows[0]["NewTransDebit"].ToString());
        //            dr_temp["amountcr"] = 0;
        //        }
        //        else
        //        {
        //            dr_temp["ltype"] = "Cr";
        //            dr_temp["amountcr"] = Convert.ToDouble(ds_OpBal.Tables[0].Rows[0]["NewTransCredit"].ToString());
        //            dr_temp["amount"] = 0;
        //        }
        //    }

        //    dt_Tans.Rows.InsertAt(dr_temp, 0);

        //    dr_temp = dt_Tans.NewRow();
        //    dr_temp["Vouno"] = 0;
        //    dr_temp["ltype"] = "";
        //    dr_temp["prti"] = "Transaction Total";
        //    dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' and vouno>0");
        //    dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr' and vouno>0");
        //    dt_Tans.Rows.Add(dr_temp);

        //    double dbl_Closing_dbamt = 0;
        //    double dbl_Closing_cramt = 0;
        //    double dbl_dbamt = 0;
        //    double dbl_cramt = 0;
        //    dr_temp = dt_Tans.NewRow();
        //    dr_temp["Vouno"] = 0;
        //    dr_temp["ltype"] = "";
        //    dr_temp["prti"] = "Total";
        //    dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' ");
        //    dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr'");
        //    if (dr_temp["amount"].ToString().Length == 0)
        //    {
        //        dr_temp["amount"] = "0.00";
        //    }
        //    if (dr_temp["amountcr"].ToString().Length == 0)
        //    {
        //        dr_temp["amountcr"] = "0.00";
        //    }
        //    dt_Tans.Rows.Add(dr_temp);

        //    dbl_Closing_dbamt = Convert.ToDouble(dr_temp["amount"].ToString()) - Convert.ToDouble(dr_temp["amountCr"].ToString());
        //    dbl_Closing_cramt = dbl_Closing_dbamt;
        //    dbl_dbamt = Convert.ToDouble(dr_temp["amount"].ToString());
        //    dbl_cramt = Convert.ToDouble(dr_temp["amountCr"].ToString());

        //    dr_temp = dt_Tans.NewRow();
        //    dr_temp["Vouno"] = 0;
        //    dr_temp["ltype"] = "";
        //    dr_temp["prti"] = "Closing Balance";
        //    if (dbl_Closing_dbamt < 0)
        //    {
        //        dr_temp["amount"] = dbl_Closing_dbamt.ToString().Replace("-", "");
        //        dbl_Closing_cramt = 0;
        //    }
        //    else
        //    {
        //        dr_temp["amountcr"] = dbl_Closing_dbamt.ToString().Replace("-", "");
        //        dbl_Closing_dbamt = 0;
        //    }

        //    dt_Tans.Rows.Add(dr_temp);

        //    dr_temp = dt_Tans.NewRow();
        //    dr_temp["Vouno"] = 0;
        //    dr_temp["ltype"] = "";
        //    dr_temp["prti"] = "Grand Total";
        //    dr_temp["amount"] = (dbl_Closing_dbamt + dbl_dbamt).ToString().Replace("-", "");
        //    dr_temp["amountcr"] = (dbl_Closing_cramt + dbl_cramt).ToString().Replace("-", "");
        //    dt_Tans.Rows.Add(dr_temp);

        //    grd.DataSource = dt_Tans;
        //    grd.DataBind();
        //}

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            intSelIndex = grd.SelectedIndex;
            intRecptid = int.Parse(grd.SelectedRow.Cells[7].Text.Trim());
            strMode = grd.SelectedRow.Cells[3].Text.Trim();

            //if (strMode == "Bank")
            //    strRptFN = "ReceiptCash.rpt";
            //else if (strMode == "Cash")
            //    strRptFN = "ReceiptBank.rpt";
            //intRecptid = 18;
            //strSF = "ReceiptHead.receiptid~" + intRecptid + "~Num~=";
            //rptobj = new ReportShow(strRptFN, strSF, "", "", BtnPrint, this.Page);

        }

        //protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.Cells[8].Text.Length > 25)
        //            e.Row.Cells[8].Text = e.Row.Cells[8].Text.Substring(0, 25) + " ...";
        //        if (e.Row.Cells[9].Text.Length > 25)
        //            e.Row.Cells[9].Text = e.Row.Cells[9].Text.Substring(0, 25) + " ...";
        //        e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString().Replace("AC-", "");
        //        if (e.Row.RowIndex == 0)
        //        {
        //            if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
        //            {
        //                e.Row.Cells[7].Text = e.Row.Cells[5].Text;
        //            }
        //            else
        //            {
        //                e.Row.Cells[7].Text = "-" + e.Row.Cells[6].Text;
        //            }

        //        }
        //        if (Convert.ToInt64(grd.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()) <= 0 && e.Row.RowIndex > 0)
        //        {
        //            if (double.TryParse(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text.ToString(), out dbl_temp))
        //            {
        //                if (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) < 0)
        //                {
        //                    grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (grd.Rows[e.Row.RowIndex - 1].Cells[7].Text + "  (Cr)").ToString().Replace("-", "");
        //                }
        //                else
        //                {
        //                    grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (grd.Rows[e.Row.RowIndex - 1].Cells[7].Text + "  (Dr)").ToString();
        //                }
        //            }
        //            e.Row.Cells[7].Text = "";
        //        }
        //        else
        //        {
        //            if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
        //            {
        //                e.Row.Cells[6].Text = "";
        //                e.Row.Cells[15].Text = "";
        //            }
        //            else
        //            {
        //                e.Row.Cells[5].Text = "";
        //                e.Row.Cells[14].Text = "";
        //            }

        //            if (e.Row.RowIndex >= 1)
        //            {
        //                if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
        //                {
        //                    e.Row.Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) + Convert.ToDouble(e.Row.Cells[5].Text)).ToString();
        //                }
        //                else
        //                {
        //                    e.Row.Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) - Convert.ToDouble(e.Row.Cells[6].Text)).ToString();
        //                }
        //                if (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) < 0)
        //                {
        //                    grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (grd.Rows[e.Row.RowIndex - 1].Cells[7].Text + "  (Cr)").ToString().Replace("-", "");
        //                }
        //                else
        //                {
        //                    grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (grd.Rows[e.Row.RowIndex - 1].Cells[7].Text + "  (Dr)").ToString();
        //                }
        //            }

        //        }

        //    }
        //}

        //protected void btnToExcel_Click(object sender, EventArgs e)
        //{
        //    DataTable dtTarget;
        //    int[] intTempArray={1,2,3,4,5,6};
        //    dtTarget = ConvertToExCel.ConvertGridToDtbl(grd, intTempArray);
        //    CustObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsReceipts, DateTime.Now, dtFrom.Text + " to " + dtTo.Text + "/Excel");
        //    ConvertToExCel.SetData(dtTarget, "Receipts.csv", ConvertToExCel.ConversionType.Excel);
        //    btnToExcel.Enabled = false;
        //    Response.Redirect("ToExcel.aspx?pmtr=Table");
        //}
        public DataTable CombineData(DataTable DtSource, DataTable dtNew)
        {
            DataTable dtTemp;
            dtTemp = new DataTable();
            dtTemp = DtSource;

            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                DataRow dtrow = dtTemp.NewRow();

                for (int j = 0; j < dtTemp.Columns.Count; j++)
                {
                    dtrow[j] = dtNew.Rows[i][j];
                }
                dtTemp.Rows.Add(dtrow);
            }
            return dtTemp;
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (BtnCancel.Text == "Cancel")
            {
                grd.DataSource = new DataTable();
                grd.DataBind();
                BtnCancel.Text = "Back";
            }
            else
            {
                //Response.Redirect("Default.aspx");
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExecelDownload();
        }


        public void ExecelDownload()
        {
            if (ViewState["Outstanding"] != null)
            {
                DataTable dt = ViewState["Outstanding"] as DataTable;

                if (dt.Rows.Count > 0)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Outstanding");
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=Outstanding.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }

    }
}