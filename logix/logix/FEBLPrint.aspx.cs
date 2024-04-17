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
    public partial class FEBLPrint : System.Web.UI.Page
    {
        public DataTable Dt, DtJob, DtConfirm, DtTentative, dtSBDtl, dtMVDtl, dtContainer;
        //public DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        //public DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        //public DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        //public DataAccess.ForwardingImports.JobInfo FIJobObj = new DataAccess.ForwardingImports.JobInfo();
        //public DataAccess.ForwardingExports.Confirmation fecObj = new DataAccess.ForwardingExports.Confirmation();
        //public DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();
        //public DataAccess.Masters.MasterCustomer Custobj = new DataAccess.Masters.MasterCustomer();
        //public DataAccess.Masters.MasterVessel vessobj = new DataAccess.Masters.MasterVessel();

        public CustomerDataAccess.RegCustomer regCustObj = new CustomerDataAccess.RegCustomer();

        public ReportShow rptobj;
        public string strBLNo, strTranType;
        Calendar cldr = new Calendar();
        public static int intJobType;

        public DataSet dsTemp;
        public string strPmtr;
        public int intBranchID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            strBLNo = Request.QueryString["blno"];
            strTranType = Request.QueryString["Trantype"];

            strPmtr = "?lgs=1&uid=" + Request.QueryString["uid"] + "&Trantype=" + strTranType + "&from=" + Request.QueryString["from"] + "&to=" + Request.QueryString["to"];

            if (strTranType == "FE")
            {
                BtnPrint.Visible = true;
            }
            else
            {
                BtnPrint.Visible = false;
            }
            if (strTranType == "FE")
            {
                dsTemp = regCustObj.GetFEBL4CustLogin(strBLNo);
                SetBLDetails(dsTemp.Tables[4]);

                dtMVDtl = dsTemp.Tables[2];
                if (dtMVDtl.Rows.Count == 0)
                    dtMVDtl = GetEmptyMVDtl();
                grdMVesselDtl.DataSource = dtMVDtl;
                grdMVesselDtl.DataBind();


                dtSBDtl = dsTemp.Tables[1];
                if (dtSBDtl.Rows.Count == 0)
                    dtSBDtl = GetEmptySBDtl();
                grdSBDtl.DataSource = dtSBDtl;
                grdSBDtl.DataBind();
                if (dsTemp.Tables[0].Rows.Count != 0)
                    lblInlandDetail.Text = dsTemp.Tables[0].Rows[0][0].ToString();

                dtContainer = dsTemp.Tables[3];
                if (dtContainer.Rows.Count == 0)
                    dtContainer = GetEmptyCtr();

                grdContainers.DataSource = dtContainer;
                grdContainers.DataBind();
            }
            rptobj = new ReportShow("FEBL4PL.rpt", "FEBLDetails.blno~lblBLNo~Text~=", "location=" + lblIssuedAt.Text, "", BtnPrint, this.Page, intBranchID.ToString());
            string strTemp = intBranchID.ToString();
        }
        public DataTable GetEmptyCtr()
        {
            DataTable dtTempCtr = new DataTable();
            DataColumn dcCtr, dcSize;
            dcCtr = new DataColumn("container");
            dcSize = new DataColumn("size");

            dtTempCtr.Columns.Add(dcCtr);
            dtTempCtr.Columns.Add(dcSize);

            DataRow dtRow = dtTempCtr.NewRow();
            dtRow[dcCtr] = "NA";
            dtRow[dcSize] = "NA";
            dtTempCtr.Rows.Add(dtRow);
            return dtTempCtr;
        }
        public DataTable GetEmptyMVDtl()
        {
            DataTable dtTempMV;
            dtTempMV = new DataTable();
            DataColumn dcVessel, dcPOL, dcETD, dcPOD, dcETA;
            dcVessel = new DataColumn("mvessel");
            dcPOL = new DataColumn("pol");
            dcETD = new DataColumn("etd");
            dcPOD = new DataColumn("pod");
            dcETA = new DataColumn("eta");
            dtTempMV.Columns.Add(dcVessel);
            dtTempMV.Columns.Add(dcPOL);
            dtTempMV.Columns.Add(dcETD);
            dtTempMV.Columns.Add(dcPOD);
            dtTempMV.Columns.Add(dcETA);

            DataRow dtRow = dtTempMV.NewRow();
            dtRow[dcVessel] = "NA";
            dtRow[dcPOL] = "NA";
            dtRow[dcETD] = "NA";
            dtRow[dcPOD] = "NA";
            dtRow[dcETA] = "NA";
            dtTempMV.Rows.Add(dtRow);
            return dtTempMV;
        }
        public DataTable GetEmptySBDtl()
        {
            DataTable dtTempSBDtl = new DataTable();
            DataColumn dcSBNo = new DataColumn("sbno");
            DataColumn dcSBDate = new DataColumn("sbdate");
            dtTempSBDtl.Columns.Add(dcSBNo);
            dtTempSBDtl.Columns.Add(dcSBDate);
            DataRow dtRow = dtTempSBDtl.NewRow();
            dtRow[dcSBNo] = "NA";
            dtRow[dcSBDate] = "NA";
            dtTempSBDtl.Rows.Add(dtRow);
            return dtTempSBDtl;
        }

        public void SetBLDetails(DataTable DtTemp)
        {
            if (DtTemp.Rows.Count != 0)
            {
                lblBLNo.Text = strBLNo;
                lblBLDate.Text = DtTemp.Rows[0]["issuedon"].ToString();
                lblIssuedAt.Text = DtTemp.Rows[0]["issuedat"].ToString();
                lblShipper.Text = DtTemp.Rows[0]["sname"].ToString();
                lblConsignee.Text = DtTemp.Rows[0]["conname"].ToString();
                lblNP.Text = DtTemp.Rows[0]["npame"].ToString();
                lblAgent.Text = DtTemp.Rows[0]["aname"].ToString();
                lblPlaceOfReceipt.Text = DtTemp.Rows[0]["por"].ToString();
                lblPortOfLoading.Text = DtTemp.Rows[0]["pol"].ToString();
                lblPortOfDischarge.Text = DtTemp.Rows[0]["pod"].ToString();
                lblFinalDestination.Text = DtTemp.Rows[0]["fd"].ToString();

                if (DtTemp.Rows[0]["jobtype"].ToString() == "3")
                    lblVolume.Text = DtTemp.Rows[0]["container"].ToString();
                else
                    lblVolume.Text = DtTemp.Rows[0]["cbm"].ToString();
                lblWeight.Text = DtTemp.Rows[0]["grweight"].ToString();
                lblPackage.Text = DtTemp.Rows[0]["package"].ToString();
                lblFreightStatus.Text = DtTemp.Rows[0]["freight"].ToString();
                lblMarksNo.Text = DtTemp.Rows[0]["marks"].ToString();
                lblCargo.Text = DtTemp.Rows[0]["descn"].ToString();

                lblFVandVoyage.Text = DtTemp.Rows[0]["fvessel"].ToString();
                lblPOL.Text = DtTemp.Rows[0]["fpol"].ToString();
                lblPOD.Text = DtTemp.Rows[0]["fpod"].ToString();
                lblETA.Text = DtTemp.Rows[0]["fveta"].ToString();
                lblETD.Text = DtTemp.Rows[0]["fvetd"].ToString();

                intBranchID = int.Parse(DtTemp.Rows[0]["branch"].ToString());
            }
        }

        //public void SetJobDetails(DataTable DtTemp)
        //{
        //    if (DtTemp.Rows.Count != 0)
        //    {
        //        //txtMLOFFD.Text = DtTemp.Rows[0]["mlo"].ToString();
        //        txtFeedervessl.Text = DtTemp.Rows[0]["vessel"].ToString();
        //        txtFeedVoy.Text = DtTemp.Rows[0]["voyage"].ToString();
        //        txtPOL.Text = DtTemp.Rows[0]["pol"].ToString();
        //        txtPOD.Text = DtTemp.Rows[0]["pod"].ToString();
        //        txtETD.Text = cldr.ConvertDate(DateTime.Parse(DtTemp.Rows[0]["etd"].ToString()).ToShortDateString());
        //        txtETA.Text = cldr.ConvertDate(DateTime.Parse(DtTemp.Rows[0]["eta"].ToString()).ToShortDateString());

        //        intJobType = int.Parse(DtTemp.Rows[0]["jobtype"].ToString());
        //    }
        //}

        //public void SetConfirmDetails(DataTable DtTemp)
        //{
        //    if (DtTemp.Rows.Count != 0)
        //    {
        //        txtMothVessel.Text = DtTemp.Rows[0]["vessel"].ToString();
        //        txtMothVoy.Text = DtTemp.Rows[0]["voyage"].ToString();
        //    }       
        //}   

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FIEBLInfo.aspx" + strPmtr);
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            int cusID = int.Parse(Session["webgroupid"].ToString());
            switch (strTranType)
            {
                case "FE":
                    regCustObj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, Session["blno"] + " / BL Print");
                    break;
                case "FI":
                    regCustObj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, Session["blno"] + " / BL Print");
                    break;
                case "AE":
                    regCustObj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, Session["blno"] + " / BL Print");
                    break;
                case "AI":
                    regCustObj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, Session["blno"] + " / BL Print");
                    break;
            }
        }
        protected void lblMarksNo_TextChanged(object sender, EventArgs e)
        {

        }
        protected void lblFinalDestination_TextChanged(object sender, EventArgs e)
        {

        }
    
    }
}