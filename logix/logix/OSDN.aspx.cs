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
    public partial class OSDN : System.Web.UI.Page
    {
        CustomerDataAccess.RegCustomer objOSDCN = new CustomerDataAccess.RegCustomer();
        //DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        //DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
        //DataAccess.AirImportExports.AIEJobInfo AIEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
        //DataAccess.Accounts.DCAdvise Debitobj = new DataAccess.Accounts.DCAdvise();

        //DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        //DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        //DataAccess.AirImportExports.AIEBLDetails AIEBLobj = new DataAccess.AirImportExports.AIEBLDetails();

        DataSet dsTemp = new DataSet();
        DataTable dtTemp, Dt, DT1;
        int intJobNo, intBranchID, intEmpID, intagent, intUIID;
        string strTrantype, strVouType, strFCurr, strRptName, strSP, strSF, strdamt;
        double dblAmt = 0, dblcamt = 0, dbldamt = 0;
        string activity, preparedby, voutype, strusername, strvtype;

        public int jobno;
        public double dnamount;
        public double cnamount;
        public double amount;
        public int dnno, cnno, jobdcount, jobccount, intvouyear;
        public DateTime dtdate;
        public string damnt;
        public string camnt;
        public string Src = "";
        public int jobtype;
        public double oldamount;

        public int vouno, intcont20, intcont40;
        public DateTime voudate;
        public int intsalesperson;
        public string strblno, strcharge, strbase;
        public DateTime jobdate;

        //public int branch;

        public double douvolume, cbm, cbms;
        public int cont20, cont40;
        public double mincpercbm;
        public int totalcont;
        public int intjobtype;
        public double cbmamount, contamount, mcontamount, invamount, getamount;
        public int shipper, consignee;
        string strScript;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            strTrantype = Request.QueryString["trantype"].ToString();
            switch (strTrantype)
            {
                case "Ocean Exports":
                    strTrantype = "FE";
                    break;
                case "Ocean Imports":
                    strTrantype = "FI";
                    break;
                case "Air Exports":
                    strTrantype = "AE";
                    break;
                case "Air Imports":
                    strTrantype = "AI";
                    break;
            }
            intBranchID = int.Parse(Request.QueryString["branchid"].ToString());
            txtJobNo.Text = Request.QueryString["jobno"].ToString();
            txtJobNo_TextChanged(sender, e);
        }
        protected void txtJobNo_TextChanged(object sender, EventArgs e)
        {
            if (txtJobNo.Text != "")
            {
                intJobNo = int.Parse(txtJobNo.Text);
                btnCancel_Click(sender, e);
                txtJobNo.Text = intJobNo.ToString();
                dsTemp = objOSDCN.RptOSDNCNFromJobNo(strTrantype, intJobNo, intBranchID);
                dtTemp = new DataTable();
                dtTemp = dsTemp.Tables[0];
                if (dtTemp.Rows.Count != 0)
                {
                    txtCustomer.Text = dtTemp.Rows[0][0].ToString().Trim() + "\n" + dtTemp.Rows[0][1].ToString().Trim() + "\n" + dtTemp.Rows[0][2].ToString().Trim() + "\n" + dtTemp.Rows[0][3].ToString().Trim();
                    if (strTrantype == "FE" || strTrantype == "FI")
                        txtShipment.Text = "Vessel / Voyage  :  " + dtTemp.Rows[0][5].ToString().Trim() + "  /  " + dtTemp.Rows[0][6].ToString().Trim() + "\n" + "MBL #  :  " + dtTemp.Rows[0][7].ToString().Trim() + "\n" + "PoL/PoD  :  " + dtTemp.Rows[0][8].ToString().Trim() + "  /  " + dtTemp.Rows[0][9].ToString().Trim();
                    else
                        txtShipment.Text = "Flight # / Date  :  " + dtTemp.Rows[0][5].ToString().Trim() + "  /  " + dtTemp.Rows[0][6].ToString().Trim() + "\n" + "MBL #  :  " + dtTemp.Rows[0][7].ToString().Trim() + "\n" + "PoL/PoD  :  " + dtTemp.Rows[0][8].ToString().Trim() + "  /  " + dtTemp.Rows[0][9].ToString().Trim();
                    dtTemp = new DataTable();
                    GridDNRpt.DataSource = dsTemp.Tables[1];
                    GridDNRpt.DataBind();
                    dtTemp = new DataTable();
                    GrdCNRpt.DataSource = dsTemp.Tables[2];
                    GrdCNRpt.DataBind();
                    for (int x = 0; x < GridDNRpt.Rows.Count; x++)
                    {
                        dbldamt += double.Parse(GridDNRpt.Rows[x].Cells[5].Text);
                    }
                    for (int x = 0; x < GrdCNRpt.Rows.Count; x++)
                    {
                        dblcamt += double.Parse(GrdCNRpt.Rows[x].Cells[5].Text);
                    }
                    dblAmt = dbldamt - dblcamt;
                    txtTotal.Text = dblAmt.ToString("#,###.##");
                }
                dtTemp = new DataTable();
                dtTemp = objOSDCN.GetOSDCNDtls(intJobNo, strTrantype, "OSSI", intBranchID);
                if (dtTemp.Rows.Count == 0)
                {
                    dtTemp = objOSDCN.GetOSDCNDtls(intJobNo, strTrantype, "OSPI", intBranchID);
                }

                if (dtTemp.Rows.Count != 0)
                {
                    txtVouNo.Text = dtTemp.Rows[0][0].ToString();
                    txtVouYear.Text = dtTemp.Rows[0]["vouyear"].ToString();
                }
            }
           // SetFocus(this.Page, txtJobNo);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtJobNo.Text = txtVouNo.Text = txtVouYear.Text = txtCustomer.Text = txtShipment.Text = txtTotal.Text = "";
            GrdCNRpt.DataSource = null;
            GrdCNRpt.DataBind();
            GridDNRpt.DataSource = null;
            GridDNRpt.DataBind();
          //  SetFocus(this.Page, txtJobNo);
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        public void ShowReport()
        {
            if (txtVouNo.Text != "")
            {
                string str = this.Page.ClientQueryString;
                strFCurr = objOSDCN.GetCurrOSDCN(int.Parse(txtJobNo.Text), strTrantype, "D", intBranchID);
                strSP = "FCurr=" + strFCurr;
                strRptName = strTrantype + "OSDN.rpt";
                strSF = "{OSDN.trantype}=" + '"' + strTrantype + '"' + " and {OSDN.dnno}=" + txtVouNo.Text + " and {OSDN.branchid}=" + intBranchID + " and {OSDN.vouyear}=" + txtVouYear.Text;

                string strQry = "window.open('ReportView.aspx?SFormula=" + strSF + "&Parameter=" + strSP + "&RFName=" + strRptName + "&bid=" + intBranchID + "&" + this.Page.ClientQueryString + "','','');";
                strSF = "{MasterBranch.branchid}=" + intBranchID;
                strSP = "module=" + strTrantype + "~jobno=" + txtJobNo.Text + "~drow=" + GridDNRpt.Rows.Count.ToString() + "~crow=" + GrdCNRpt.Rows.Count.ToString();
                strRptName = "SOA1.rpt";
                strQry += "window.open('ReportView.aspx?SFormula=" + strSF + "&Parameter=" + strSP + "&RFName=" + strRptName + "&bid=" + intBranchID + "&" + this.Page.ClientQueryString + "','','');";

                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "OSDCN", strQry, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "OSDCN", "alertify.alert('Please enter the Job #')", true);
              //  SetFocus(this.Page, txtJobNo);
            }
        }
    }
}