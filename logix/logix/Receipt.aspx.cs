using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ClosedXML.Excel;
using System.IO;
using System.Text;

namespace logix
{
    public partial class Receipt : System.Web.UI.Page
    {
        Calendar CldrFrom, CldrTo;
        public static DataTable Dt, dtCustIDs, DtCombined;
        Calendar CldrTemp = new Calendar();
        //ReportShow rptobj;
        CustomerDataAccess.RegCustomer CustObj = new CustomerDataAccess.RegCustomer();
        CustomerDataAccess.PODetails Logobj = new CustomerDataAccess.PODetails();
        public static int intCustID;
        public int intSelIndex = -1;
        public int intRecptid = 0;
        public string strMode, strRptFN, strSF;
        public GrdToExcel grd2exObj = new GrdToExcel();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnToExcel);
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                Grd.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd.DataBind();
                //CldrFrom = new Calendar(this.Page, dtFrom, ImgFrom);
                //CldrTo = new Calendar(this.Page, dtTo, imgTo);
                //dtFrom.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                dtFrom.Text = Convert.ToDateTime(DateTime.Now.AddDays(-90).ToShortDateString()).ToString("dd/MM/yyyy");
                dtTo.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");

            }
            if (Request.QueryString["uid"] != null && Request.QueryString["uid"] != "")
                intCustID = int.Parse(Request.QueryString["uid"].ToString());

            //if (strMode == "Bank")
            //    strRptFN = "ReceiptCash.rpt";
            //else if (strMode == "Cash")
            //    strRptFN = "ReceiptBank.rpt";
            //    intRecptid = 18;
            //strSF = "ReceiptHead.receiptid~" + intRecptid + "~Num~=";
            //rptobj = new ReportShow(strRptFN, strSF, "", "", BtnPrint, this.Page);

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            DateTime FromDate;
            DateTime ToDate;

            FromDate = DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                return;
            }
            intCustID = int.Parse(Session["webgroupid"].ToString());
            CustObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsReceipts, DateTime.Now, dtFrom.Text + " to " + dtTo.Text);
            Dt = CustObj.GetRecptforCust(intCustID, DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text)), DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text)));
            Grd.DataSource = Dt;
            Grd.DataBind();
            if (Dt.Rows.Count != 0)
            {
                btnToExcel.Enabled = true;
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "No data available";
            }
            //Session["DTReceipt"] = Dt;
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (BtnCancel.Text == "Cancel")
            {
                Dt = null;
                Grd.DataSource = Dt;
                Grd.DataBind();
                btnToExcel.Enabled = false;
                BtnCancel.Text = "Back";
            }
            else
            {
                //Response.Redirect("Default.aspx");
            }
        }

        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            intSelIndex = Grd.SelectedIndex;
            intRecptid = int.Parse(Grd.SelectedRow.Cells[7].Text.Trim());
            strMode = Grd.SelectedRow.Cells[3].Text.Trim();

            //if (strMode == "Bank")
            //    strRptFN = "ReceiptCash.rpt";
            //else if (strMode == "Cash")
            //    strRptFN = "ReceiptBank.rpt";
            //intRecptid = 18;
            //strSF = "ReceiptHead.receiptid~" + intRecptid + "~Num~=";
            //rptobj = new ReportShow(strRptFN, strSF, "", "", BtnPrint, this.Page);

        }
        protected void btnToExcel_Click(object sender, EventArgs e)
        {
            //DataTable dtTarget;
            //int[] intTempArray = { 1, 2, 3, 4, 5, 6 };
            //dtTarget = ConvertToExCel.ConvertGridToDtbl(Grd, intTempArray);
            //CustObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsReceipts, DateTime.Now, dtFrom.Text + " to " + dtTo.Text + "/Excel");
            //ConvertToExCel.SetData(dtTarget, "Receipts.csv", ConvertToExCel.ConversionType.Excel);
            //btnToExcel.Enabled = false;
            //Response.Redirect("ToExcel.aspx?pmtr=Table");


           // DataTable dt = Session["DTReceipt"] as DataTable;
           // dt.Columns.Remove("bid");



            if (Grd.Rows.Count > 0)
            {
               
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Receipts" + dtFrom.Text + " To " + dtTo.Text + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                if (Grd.Visible == true)
                {
                    Grd.GridLines = GridLines.Both;
                    Grd.HeaderStyle.Font.Bold = true;
                    Grd.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }



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

        protected void Grd_PreRender(object sender, EventArgs e)
        {
            Grd.UseAccessibleHeader = true;
            Grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
    }
}