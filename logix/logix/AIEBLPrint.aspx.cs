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

namespace logix
{
    public partial class AIEBLPrint : System.Web.UI.Page
    {
        CustomerDataAccess.RegCustomer regCustObj = new CustomerDataAccess.RegCustomer();
        DataSet dsTemp;
        DataTable Dt, DtDim;
        public string strBLNo, strTranType, strPmtr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            strBLNo = Request.QueryString["blno"];
            strTranType = Request.QueryString["Trantype"];
            strPmtr = "?lgs=1&uid=" + Request.QueryString["uid"] + "&Trantype=" + strTranType + "&from=" + Request.QueryString["from"] + "&to=" + Request.QueryString["to"];
            AIEBLInfo();
        }

        public void AIEBLInfo()
        {
            dsTemp = regCustObj.GetAIEBL4CustLogin(Request.QueryString["blno"].ToString(), Request.QueryString["Trantype"].ToString());
            Dt = dsTemp.Tables[0];
            DtDim = dsTemp.Tables[1];

            if (DtDim.Rows.Count == 0)
                DtDim = BindEmptyDimension();

            grdBLDim.DataSource = DtDim;
            grdBLDim.DataBind();

            if (Dt.Rows.Count > 0)
            {
                txtAWBL.Text = Request.QueryString["blno"];
                txtIssuedon.Text = Dt.Rows[0]["issuedon"].ToString();
                txtIssuedat.Text = Dt.Rows[0]["issuedat"].ToString();
                txtShipr.Text = Dt.Rows[0]["shipper"].ToString();
                txtCons.Text = Dt.Rows[0]["consignee"].ToString();
                txtNP1.Text = Dt.Rows[0]["notifyparty1"].ToString();
                txtNP2.Text = Dt.Rows[0]["notifyparty2"].ToString();
                txtFrmPort.Text = Dt.Rows[0]["fromport"].ToString();
                txtToPort.Text = Dt.Rows[0]["toport"].ToString();
                txtCNF.Text = Dt.Rows[0]["cnf"].ToString();
                txtPOD1.Text = Dt.Rows[0]["pod1"].ToString();
                txtCarrier1.Text = Dt.Rows[0]["carrier1"].ToString();
                txtPOD2.Text = Dt.Rows[0]["pod2"].ToString();
                txtCarrier2.Text = Dt.Rows[0]["carrier2"].ToString();
                txtPOD3.Text = Dt.Rows[0]["pod3"].ToString();
                txtCarrier3.Text = Dt.Rows[0]["carrier3"].ToString();
                txtHndlInfo.Text = Dt.Rows[0]["handling"].ToString();
                txtPkgs.Text = Dt.Rows[0]["package"].ToString();
                txtGrossWt.Text = Dt.Rows[0]["grosswt"].ToString();
                txtChrgWt.Text = Dt.Rows[0]["chargewt"].ToString();
            }
        }

        public DataTable BindEmptyDimension()
        {
            DataTable dtTempDim = new DataTable();
            DataColumn dcLength = new DataColumn("length");
            DataColumn dcBreadth = new DataColumn("breadth");
            DataColumn dcWidth = new DataColumn("width");
            DataColumn dcPieces = new DataColumn("pieces");
            dtTempDim.Columns.Add(dcLength);
            dtTempDim.Columns.Add(dcBreadth);
            dtTempDim.Columns.Add(dcWidth);
            dtTempDim.Columns.Add(dcPieces);
            DataRow dtRow = dtTempDim.NewRow();
            dtRow[dcLength] = "";
            dtRow[dcWidth] = "";
            dtRow[dcBreadth] = "";
            dtRow[dcPieces] = "";
            dtTempDim.Rows.Add(dtRow);
            return dtTempDim;
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FIEBLInfo.aspx" + strPmtr);
        }
        protected void txtGrossWt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}