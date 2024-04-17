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
//using System.Windows.Forms;
using DataAccess.Masters;
using System.Net;
namespace logix
{
    public partial class eBLPrint : System.Web.UI.Page
    {
        public DataAccess.ForwardingExports.JobInfo FEJobInfoObj = new DataAccess.ForwardingExports.JobInfo();
        public DataAccess.Corporate CorpObj = new DataAccess.Corporate();
        public DataAccess.ForwardingExports.BLDetails FEBLObj = new DataAccess.ForwardingExports.BLDetails();
        public DataAccess.ForwardingExports.BLDetailsWOJob FeBlObjWOJ = new DataAccess.ForwardingExports.BLDetailsWOJob();
        public DataAccess.Masters.MasterCustomer custObj = new MasterCustomer();
        public DataAccess.Masters.MasterPackages PkgObj = new MasterPackages();
        public DataAccess.Marketing.Quotation QuotObj = new DataAccess.Marketing.Quotation();
        public DataAccess.ForwardingImports.BLDetails FiBLObj = new DataAccess.ForwardingImports.BLDetails();
        public DataAccess.LogDetails LogObj = new DataAccess.LogDetails();
        public DataAccess.Masters.MasterVessel VslObj = new DataAccess.Masters.MasterVessel();
        public DataAccess.Accounts.Invoice InvObj = new DataAccess.Accounts.Invoice();
        public CustomerDataAccess.RegCustomer regCustObj = new CustomerDataAccess.RegCustomer();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        //public Script.ReportShow rptObj;
        //public Script.Calendar cldrIssuedOn;
        public DataTable dtbl, dtbl1, DtTemp, Dt, dtcont, dn;
        public DateTime datIssuedOn, datJobDate;
        public double CBM, dblOldCBM, GrWt, NtWt, dblWeight;
        static double dblVolume;
        public int intJobNo, intPackages, i, j, intCount = 0, intCont20, intCont40, intvolume, intContNooofPkgs, intSalesID;
        public string strBLNo, strIssuedAt, strShipperName, strShipperAddr, strConsigName, strConsigAddr, strNotifyParty, strNotifyPtyAddr, strAgent;
        public string strPOR, strPOL, strPOD, strFD, strMN, strCHA, strDesc, strUnits, strNomination, strOurBL, strSurd, strContNo, strContSize, strSealNo, strSpmt, strFreight;
        public string strBookingNo, strVessel, strVoyage, strShprLoc, strConLoc, strNPLoc, strAgentLoc, strCHALoc;
        public int intJobType;
        public string strCtrlLists, strMsgLists, strDtypeLists, strProcess, strRemarks, strBranch, strRptName, strSF;
        public static int intFlagWOJ = 0;
        public char chrDGCargo;
        public short shrtBLSignatory, shrtSpmtt, shrtNoOfOriginal;
        public int intBranchID, intDivisionID, intEmpId, intUiId, s, intVouYear, intCommudityID, count;
        public int intIssuedAtId, intShipperID, intConsigneeID, intNotifyPartyId, intAgentID, intPOR, intPOL, intPOD, intFD, intCHAId;
        string blno, strDiv, strBra;
        public ReportShow rptobj;
        string strPM = "", strScript;

        //Script.ReportShow rptobj;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                strDiv = Request.QueryString["divisionid"];
                strBra = Request.QueryString["bid"];
                intBranchID = int.Parse(strBra);
                intDivisionID = int.Parse(strDiv);
                blno = Request.QueryString["blno"];
                txtBLNo.Text = blno;
                ClearForm();
                fillBLDetail(txtBLNo.Text);
                txtOldCbm.Value = txtCBM.Text;
                //ddlBLFormat.Items.Clear();
                //ddlBLFormat.Items.Add("PAN GLOBAL LINES(PLSLL)");
                //ddlBLFormat.Items.Add("SHIPPING & CARGO SERVICES (PVT) LTD");  

                dn = regCustObj.SelNoOfOriginal(txtBLNo.Text);

                if (dn.Rows[0][0].ToString() != "")
                {
                    if (int.Parse(dn.Rows[0][0].ToString()) > 3)
                    {
                        btnoriginal.Enabled = false;
                    }
                }

                rptobj = new ReportShow("ebl.rpt", "FEBLDetails.blno~txtBLNo~Text~=", "count=NON NEGOTIABLE", "", btnnego, this.Page, intBranchID.ToString());
            }
            //if (txtBLNo.Text != "")
            //    hidBLFormat.Value = "y";
            btnoriginal1.Enabled = false;
            btnoriginal2.Enabled = false;
            btnoriginal3.Enabled = false;
            dn = regCustObj.SelNoOfOriginal(txtBLNo.Text);
            if (dn.Rows[0][0].ToString() != "")
                count = int.Parse(dn.Rows[0][0].ToString().Trim());
            if (count == 0)
                btnoriginal1.Enabled = true;
            if (count == 1)
                btnoriginal2.Enabled = true;
            if (count == 2)
                btnoriginal3.Enabled = true;

            BLTakenDetails();


        }
        public void BLTakenDetails()
        {
            dn = regCustObj.SelBlTakenDetails(txtBLNo.Text);
            if (dn.Rows.Count > 0)
            {
                lbl_BLTakenDet1.Text = "First Original Taken On  " + dn.Rows[0][1].ToString();
                if (dn.Rows[0][2].ToString() != "")
                {
                    lbl_BLTakenDet2.Text = "Second Original Taken On  " + dn.Rows[0][2].ToString();
                }
                if (dn.Rows[0][3].ToString() != "")
                {
                    lbl_BLTakenDet3.Text = "Third Original Taken On  " + dn.Rows[0][3].ToString();
                }

            }
        }
        protected void txtBLNo_TextChanged(object sender, EventArgs e)
        {
            if (txtBLNo.Text != "")
            {
                ClearForm();
                fillBLDetail(txtBLNo.Text);
                txtOldCbm.Value = txtCBM.Text;
            }
        }

        public void ClearForm()
        {
            txtRemarks.Text = "";
            txtIssuedAt.Text = "";
            DateTime today = DateTime.Today;
            //txtIssuedOn.Text = Script.Calendar.ConvertDate(DateTime.Now.ToShortDateString());
            txtConsigneeName.Text = "";
            txtConsigneeAdr.Text = "";
            txtNPName.Text = "";
            txtNPAddr.Text = "";
            txtAgentName.Text = "";
            txtAgentAddr.Text = "";
            txtMksNum.Text = "";
            txtDesc.Text = "";
            txtCBM.Text = "";
            txtGrWt.Text = "";
            txtNtWt.Text = "";
            txtPackages.Text = "";
            //chkNormination.Checked = false;
            //btnSave.Text = "Save";
            txtCHA.Text = "";
            LstContainer.Items.Clear();
            txtOriginalBL.Text = "";
          //  SetFocus(this.Page, txtBLNo);
        }
        public void fillBLDetail(string strBLNumber)
        {
            intFlagWOJ = 0;
            if (txtBLNo.Text != "")
            {
                dtbl = FEBLObj.GetBLDetails(strBLNumber, intBranchID, intDivisionID);
                if (dtbl.Rows.Count > 0)
                {
                    hidBLFormat.Value = "y";
                    txtJobNo.Text = dtbl.Rows[0]["jobno"].ToString();
                    FillContChkList();
                    txtOriginalBL.Text = dtbl.Rows[0]["oribls"].ToString();
                    txtIssuedAtId.Value = dtbl.Rows[0]["blissuedat"].ToString();
                    txtShipperId.Value = dtbl.Rows[0]["shipperid"].ToString();
                    txtConsId.Value = dtbl.Rows[0]["consigneeid"].ToString();
                    txtNotifyPartyId.Value = dtbl.Rows[0]["notifypartyid"].ToString();
                    txtAgentId.Value = dtbl.Rows[0]["deliveryagent"].ToString();
                    txtChaId.Value = dtbl.Rows[0]["cnf"].ToString();
                    txtPorId.Value = dtbl.Rows[0]["porid"].ToString();
                    txtPolId.Value = dtbl.Rows[0]["polid"].ToString();
                    txtPodId.Value = dtbl.Rows[0]["podid"].ToString();
                    txtFdId.Value = dtbl.Rows[0]["fdid"].ToString();
                    hidCommudityID.Value = dtbl.Rows[0]["cargoid"].ToString();

                    string strresult = "";
                    for (int k = 0; k < dtbl.Columns.Count; k++)
                    {
                        strresult += dtbl.Columns[k].ColumnName.ToString().Trim() + " = " + dtbl.Rows[0][k].ToString().Trim();
                    }
                    txtAgentAddr.Text = strresult;
                    //btnSave.Text = "Update";
                    txtMsgRes.Value = "U";
                    txtJobNo.Text = dtbl.Rows[0]["jobno"].ToString().Trim();
                    txtIssuedAt.Text = dtbl.Rows[0]["issuedat"].ToString().Trim();
                    txtIssuedOn.Text = DateTime.Parse(dtbl.Rows[0]["issuedon"].ToString()).ToString("dd/MM/yyyy");

                    if (dtbl.Rows[0]["freight"].ToString().Trim() == "C")
                        ddlFreight.Text = "To Collect";
                    else
                        ddlFreight.Text = "PrePaid";

                    txtShipperName.Text = dtbl.Rows[0]["sname"].ToString().Trim();
                    txtShipperAddr.Text = dtbl.Rows[0]["sadd"].ToString().Trim();
                    txtConsigneeName.Text = dtbl.Rows[0]["conname"].ToString().Trim();
                    txtConsigneeAdr.Text = dtbl.Rows[0]["cadd"].ToString().Trim();
                    txtNPName.Text = dtbl.Rows[0]["nname"].ToString().Trim();
                    txtNPAddr.Text = dtbl.Rows[0]["nadd"].ToString().Trim();
                    txtAgentName.Text = dtbl.Rows[0]["agent"].ToString().Trim();
                    txtAgentAddr.Text = dtbl.Rows[0]["agentcity"].ToString().Trim() + " " + dtbl.Rows[0]["agentzip"].ToString().Trim() + " " + dtbl.Rows[0]["agentph"].ToString().Trim() + " " + dtbl.Rows[0]["agentfax"].ToString().Trim() + " " + dtbl.Rows[0]["agentemail"].ToString().Trim();
                    txtCHA.Text = dtbl.Rows[0]["cha"].ToString().Trim();
                    txtMksNum.Text = dtbl.Rows[0]["marks"].ToString().Trim();
                    txtDesc.Text = dtbl.Rows[0]["descn"].ToString().Trim();
                    txtGrWt.Text = dtbl.Rows[0]["grweight"].ToString().Trim();
                    txtNtWt.Text = dtbl.Rows[0]["netw"].ToString().Trim();
                    txtCBM.Text = dtbl.Rows[0]["cbm"].ToString().Trim();
                    if (dtbl.Rows[0]["cbm"].ToString().Trim() != "" && dtbl.Rows[0]["cbm"].ToString().Trim() != null)
                        dblOldCBM = double.Parse(dtbl.Rows[0]["cbm"].ToString().Trim());
                    txtPackages.Text = dtbl.Rows[0]["noofpkgs"].ToString().Trim();
                    ddlUnits.Text = dtbl.Rows[0]["units"].ToString().Trim();
                    txtPOR.Text = dtbl.Rows[0]["por"].ToString().Trim();
                    txtPOL.Text = dtbl.Rows[0]["pol"].ToString().Trim();
                    txtPOD.Text = dtbl.Rows[0]["pod"].ToString().Trim();
                    txtFD.Text = dtbl.Rows[0]["fd"].ToString().Trim();
                    txtOriginalBL.Text = dtbl.Rows[0]["oribls"].ToString();
                    txtRemarks.Text = dtbl.Rows[0]["remarks"].ToString().Trim();

                    if (dtbl.Rows[0]["dgcargo"].ToString().Trim() != "" && dtbl.Rows[0]["dgcargo"].ToString().Trim() != null)
                    {
                        if (dtbl.Rows[0]["dgcargo"].ToString().Trim() == "Y")
                            chkDGCargo.Checked = true;
                        else
                            chkDGCargo.Checked = false;
                    }
                    if (dtbl.Rows[0]["sign"].ToString().Trim() != "" && dtbl.Rows[0]["sign"].ToString().Trim() != null)
                        //ddlSignatory.Text = SetSignatory(short.Parse(dtbl.Rows[0]["sign"].ToString().Trim()));

                        switch (int.Parse(dtbl.Rows[0]["shipment"].ToString().Trim()))
                        {
                            case 1: ddlSpmtType.Text = "FCL/FCL"; break;
                            case 2: ddlSpmtType.Text = "FCL/LCL"; break;
                            case 3: ddlSpmtType.Text = "LCL/LCL"; break;
                            case 4: ddlSpmtType.Text = "LCL/FCL"; break;
                        }

                    //if (dtbl.Rows[0]["nomination"].ToString().Trim() == "Y")
                    //    //chkNormination.Checked = true;
                    //else
                    //    chkNormination.Checked = false;

                    if (char.Parse(dtbl.Rows[0]["surrendered"].ToString().Trim()) == 'Y')
                        ddlSurrendered.Text = "YES";
                    else
                        ddlSurrendered.Text = "NO";

                    txtBookingNo.Text = FEBLObj.GetBookinkNo(txtBLNo.Text, intBranchID, intDivisionID);
                    //RetreiveContChkList();
                    FillJobDesc();
                    FillBookingDetails(txtBookingNo.Text);
                    //btnSave.Text = "Update";
                    for (s = 1; s <= 6; s++)
                    {
                        Dt = InvObj.CheckIPDCWBL(txtBLNo.Text, "FE", intBranchID, intVouYear, s, "");
                        if (Dt.Rows.Count > 0)
                        {
                            txtCBM.ReadOnly = true;
                            break;
                        }
                        else
                            txtCBM.ReadOnly = false;
                    }
                }
                else
                    FillBLDetWOJ();
            }
        }

        public void FillBookingDetails(string intbkgno)
        {
            dtbl = FEBLObj.GetBookingDt(intbkgno, intBranchID, intDivisionID);
            if (dtbl.Rows.Count > 0)
            {
                txtShipperName.Text = dtbl.Rows[0]["shipper"].ToString().Trim();
                hidSalesID.Value = dtbl.Rows[0]["salesid"].ToString().Trim();
                string str = dtbl.Rows[0]["hazardous"].ToString();
                if (str == "1")
                    chkDGCargo.Checked = true;
                else
                    chkDGCargo.Checked = false;
                txtShipperAddr.Text = txtShipperName.Text + "\n" + custObj.GetCustomerAddress(txtShipperName.Text, "Shipper", custObj.GetCustlocation(int.Parse(dtbl.Rows[0]["customerid"].ToString().Trim())));

                DataTable dtTemp = new DataTable();
                dtTemp = FEBLObj.GetPOnoFromBookingno(intbkgno, intBranchID, intDivisionID);
                if (dtTemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        if (i == 0)
                            txtDesc.Text = dtTemp.Rows[i][0].ToString();
                        else
                            txtDesc.Text += "," + dtTemp.Rows[i][0].ToString();
                    }
                }
            }
        }
        public string SetSignatory(short shrtTemp)
        {
            string strTempSign = "";
            switch (shrtTemp)
            {
                case 1: strTempSign = "AuthorizedSignatory"; break;
                case 2: strTempSign = "As Agent"; break;
                case 3: strTempSign = "As Carrier"; break;
                case 4: strTempSign = "As Agent for PAN Global Lines"; break;
                case 5: strTempSign = "As Carrier for PAN Global Lines"; break;
            }
            return strTempSign;
        }
        public void FillJobDesc()
        {
            if (txtJobNo.Text != "")
            {
                dtbl = FEJobInfoObj.GetFEJobInfo(int.Parse(txtJobNo.Text), intBranchID, intDivisionID);
                string str = "";
                if (dtbl.Rows.Count > 0)
                {
                    str = dtbl.Rows[0]["vessel"].ToString();
                    str += "V.";
                    str += dtbl.Rows[0]["voyage"].ToString();
                    str += " / ";
                    str += dtbl.Rows[0]["mblno"].ToString();
                    str += " / ";
                    str += DateTime.Parse(dtbl.Rows[0]["etd"].ToString().Trim()).ToShortDateString().Trim();
                    str += " / ";
                    str += dtbl.Rows[0]["sd"].ToString();
                    str += " / ";
                    str += DateTime.Parse(dtbl.Rows[0]["eta"].ToString().Trim()).ToShortDateString().Trim();
                    str += " / ";
                    str += dtbl.Rows[0]["mlo"].ToString();
                    strVessel = dtbl.Rows[0]["vessel"].ToString();
                    strVoyage = dtbl.Rows[0]["voyage"].ToString();
                    if (dtbl.Rows[0][13].ToString() != null && dtbl.Rows[0][13].ToString() != "")
                        intJobType = int.Parse(dtbl.Rows[0][13].ToString());
                }
                txtJobDetails.Text = str;
            }
        }
        public void FillBLDetWOJ()
        {
            dtbl = FeBlObjWOJ.GetBLDetWOJob(txtBLNo.Text, intBranchID, intDivisionID);
            if (dtbl.Rows.Count != 0)
            {
                if (dtbl.Rows[0][0].ToString().Trim() != "" & dtbl.Rows[0][0].ToString().Trim() != null)
                    //txtIssuedOn.Text = Calendar.ConvertDate(DateTime.Parse(dtbl.Rows[0][0].ToString().Trim()).ToShortDateString());
                    txtIssuedOn.Text = DateTime.Parse(dtbl.Rows[0][0].ToString().Trim()).ToString("dd/MM/yyyy");
                //DateTime.Parse(dtJobDtl.Rows[0]["eta"].ToString()).ToString("dd/MM/yyyy");

                txtIssuedAt.Text = dtbl.Rows[0][1].ToString().Trim();
                strShprLoc = custObj.GetCustlocation(int.Parse(dtbl.Rows[0][2].ToString().Trim()));
                txtShipperName.Text = dtbl.Rows[0][3].ToString().Trim();
                txtShipperAddr.Text = dtbl.Rows[0][4].ToString().Trim();
                txtConsigneeName.Text = dtbl.Rows[0][6].ToString().Trim();
                txtConsigneeAdr.Text = dtbl.Rows[0][7].ToString().Trim();
                txtNPName.Text = dtbl.Rows[0][9].ToString().Trim();
                txtNPAddr.Text = dtbl.Rows[0][10].ToString().Trim();
                txtAgentName.Text = dtbl.Rows[0][12].ToString().Trim();
                txtAgentAddr.Text = dtbl.Rows[0][13].ToString().Trim() + dtbl.Rows[0][14].ToString().Trim();
                txtCHA.Text = dtbl.Rows[0][16].ToString().Trim();
                txtMksNum.Text = dtbl.Rows[0][17].ToString().Trim();
                txtDesc.Text = dtbl.Rows[0][18].ToString().Trim();
                txtGrWt.Text = dtbl.Rows[0][19].ToString().Trim();
                txtNtWt.Text = dtbl.Rows[0][20].ToString().Trim();
                txtCBM.Text = dtbl.Rows[0][21].ToString().Trim();
                if (dtbl.Rows[0][21].ToString().Trim() != "" && dtbl.Rows[0][21].ToString().Trim() != null)
                    dblOldCBM = double.Parse(dtbl.Rows[0][21].ToString().Trim());
                else
                    dblOldCBM = 0;
                txtPackages.Text = dtbl.Rows[0][22].ToString().Trim();
                ddlUnits.Text = dtbl.Rows[0][23].ToString().Trim();
                txtPOR.Text = dtbl.Rows[0][24].ToString().Trim();
                txtPOL.Text = dtbl.Rows[0][25].ToString().Trim();
                txtPOD.Text = dtbl.Rows[0][26].ToString().Trim();
                txtFD.Text = dtbl.Rows[0][27].ToString().Trim();

                if (dtbl.Rows[0][28].ToString().Trim() == "P")
                    ddlFreight.Text = "PrePaid";
                else
                    ddlFreight.Text = "To Collect";

                if (dtbl.Rows[0][29].ToString().Trim() != null && dtbl.Rows[0][29].ToString().Trim() != "")
                {
                    switch (int.Parse(dtbl.Rows[0][29].ToString().Trim()))
                    {
                        case 1: ddlSpmtType.Text = "FCL/FCL"; break;
                        case 2: ddlSpmtType.Text = "FCL/LCL"; break;
                        case 3: ddlSpmtType.Text = "LCL/LCL"; break;
                        case 4: ddlSpmtType.Text = "LCL/FCL"; break;
                    }
                }

                //if (dtbl.Rows[0][30].ToString().Trim() == "N")
                //    //chkNormination.Checked = true;
                //else
                //    chkNormination.Checked = false;
                if (dtbl.Rows[0][32].ToString().Trim() == "Y")
                    ddlSurrendered.Text = "YES";
                else
                    ddlSurrendered.Text = "NO";
                //btnSave.Text = "Save";
                intFlagWOJ = 1;
                FillContChkList();
            }
            else
            {
                strBLNo = txtBLNo.Text;
                string Jobn = txtJobNo.Text;
                string jobinfo = txtJobDetails.Text;
                txtBLNo.Text = strBLNo;
                txtJobNo.Text = Jobn;
                txtJobDetails.Text = jobinfo;
                FillContChkList();
                intFlagWOJ = 0;
                txtMsgRes.Value = "S";
            }
        }

        public void FillContChkList()
        {
            if (txtJobNo.Text != "")
            {
                dtcont = FEJobInfoObj.GetContainerDetails(int.Parse(txtJobNo.Text), txtJobNo.Text, intBranchID, intDivisionID);
                LstContainer.DataSource = dtbl;
                LstContainer.Items.Clear();
                if (dtcont.Rows.Count > 0)
                {
                    LstContainer.DataSource = dtcont;
                    LstContainer.DataValueField = "containerno";
                    LstContainer.DataBind();
                }
            }
          //  SetFocus(this.Page, txtBLNo);
        }

        protected void btnoriginal_Click(object sender, EventArgs e)
        {
            btnoriginal1.Enabled = false;
            btnoriginal2.Enabled = false;
            btnoriginal3.Enabled = false;
            DataTable dn;
            string str_Count = "";
            dn = regCustObj.SelNoOfOriginal(txtBLNo.Text);
            if (dn.Rows[0][0].ToString() != "")
                count = int.Parse(dn.Rows[0][0].ToString().Trim());

            if (count == 0 || dn.Rows[0][0].ToString() == "")
            {
                count++;
                regCustObj.UpdNoOfOriginal(txtBLNo.Text, count);
                btnoriginal2.Enabled = true;
                str_Count = "First ";
                strScript = "window.open('ReportView.aspx?SFormula={FEBLDetails.blno}=" + '"' + txtBLNo.Text + '"' + "&Parameter=count=FIRST ORIGINAL&RFName=ebl.rpt&bid=" + intBranchID + "');";
                ScriptManager.RegisterStartupScript(btnoriginal, typeof(Button), "eBL", strScript, true);
            }
            else if (count == 1)
            {
                count++;
                regCustObj.UpdNoOfOriginal(txtBLNo.Text, count);
                btnoriginal3.Enabled = true;
                str_Count = "Second ";
                strScript = "window.open('ReportView.aspx?SFormula={FEBLDetails.blno}=" + '"' + txtBLNo.Text + '"' + "&Parameter=count=SECOND ORIGINAL&RFName=ebl.rpt&bid=" + intBranchID + "');";
                //strScript = "window.open('ReportView.aspx?SFormula='{FEBLDetails.blno}=" + txtBLNo.Text + "'&Parameter='count=SECOND ORIGINAL'&RFName='eBL.rpt'&bid=" + intBranchID + "');";
                ScriptManager.RegisterStartupScript(btnoriginal, typeof(Button), "", strScript, true);
            }
            else if (count == 2)
            {
                count++;
                regCustObj.UpdNoOfOriginal(txtBLNo.Text, count);
                str_Count = "Third ";
                strScript = "window.open('ReportView.aspx?SFormula={FEBLDetails.blno}=" + '"' + txtBLNo.Text + '"' + "&Parameter=count=THIRD ORIGINAL&RFName=ebl.rpt&bid=" + intBranchID + "');";
                //strScript = "window.open('ReportView.aspx?SFormula='{FEBLDetails.blno}=" + txtBLNo.Text + "'&Parameter='count=THIRD ORIGINAL'&RFName='eBL.rpt'&bid=" + intBranchID + "');";
                ScriptManager.RegisterStartupScript(btnoriginal, typeof(Button), "", strScript, true);
            }
            else if (count >= 3)
            {
                ScriptManager.RegisterStartupScript(btnoriginal, typeof(Button), "", "alertify.alert('Three Original has taken already');", true);
                btnoriginal.Enabled = false;
            }

            BLTakenDetails();

            string str_MailCont = "";
            str_MailCont = "<html><body>";
            //str_MailCont = str_MailCont + "Dear Sir <BR>";
            str_MailCont = str_MailCont + "<br>" + txtShipperName.Text.ToString() + " has taken " + str_Count + " Original bill of Lading " + txtBLNo.Text.ToString() + " ON " + DateTime.Now;
            //str_MailCont = str_MailCont +"<br><br> regards <br> ";
            str_MailCont = str_MailCont + "<br>From IP Address : " + Fn_GetIPAddress();
            str_MailCont = str_MailCont + " <br><br>Auto Generated - Do not replay ";
            str_MailCont = str_MailCont + "</body></html>";


            dn = regCustObj.GetBMMailId4Branch(int.Parse(Request.QueryString["divisionid"].ToString()), int.Parse(Request.QueryString["bid"].ToString()));
            if (dn.Rows.Count > 0)
            {
            }
            else
            {
            }
            regCustObj.InsWebCustLogDtl(Convert.ToInt32(Session["webgroupid"].ToString()), CustomerDataAccess.RegCustomer.EventType.LoginSuccess, DateTime.Now, Convert.ToInt32(Session["LoginDivisionId"]) + "EPrint" + "# -" + txtJobNo.Text);
           
        }
        private string Fn_GetIPAddress()
        {
            string str_IpAddress;
            str_IpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (str_IpAddress == null)
            {
                str_IpAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            IPHostEntry host = Dns.GetHostByAddress(Request.ServerVariables["REMOTE_HOST"].ToString());
            string str_Hostname = host.HostName.ToString();
            str_IpAddress = str_IpAddress + "  From Machine Name : " + str_Hostname;
            return str_IpAddress;
        }
    }
}