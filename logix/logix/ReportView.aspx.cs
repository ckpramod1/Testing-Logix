using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
namespace logix
{
    public partial class ReportView : System.Web.UI.Page
    {
        public static ReportDocument rptDoc;
        public string strFName = "", strSF = "", strPM = "";
        public Database DB;
        public Tables tbls;
        public CrystalDecisions.CrystalReports.Engine.Table tbl;
        public string strDBGroup, strDBMaster, strAPP, strQry, strFA;
        public Database dbTemp;
        public DataTable dtTemp;
        public SqlCommand cmdTemp;
        public DataSet dsTemp;
        public SqlConnection conTemp;
        public SqlDataAdapter daTemp;
        public static string strDBGroup_Tbl, strDBMaster_Tbl, strAPP_Tbl, strFA_Tbl, strTemp_Tbl, strHR_Tbl;
        public static string strTranType;
        public static int intBranchID;
        public Global glObj = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strSF = Request.QueryString["SFormula"].ToString();
                strPM = Request.QueryString["Parameter"].ToString();
                strFName = Server.MapPath("Reports/" + Request.QueryString["RFName"].ToString());
                lblSF.Text = strSF;
                lblPM.Text = strPM;
                lblRpt.Text = strFName;
            }
            strSF = lblSF.Text;
            strPM = lblPM.Text;
            strFName = lblRpt.Text;
            if (strFName.Contains("FEBL4PL.rpt") || strFName.Contains("ebl.rpt"))
            {
                Crv.HasExportButton = false;
            }
            showReport();
        }
        public void showReport()
        {
            rptDoc = new ReportDocument();
            rptDoc = RptDataBase(strFName, "FAGroup", "FAMaster", "FA" + Request.QueryString["bid"], "logix", "FATemp", "FAHR");
            for (int i = 0; i < rptDoc.DataSourceConnections.Count; i++)
            {
                
                rptDoc.DataSourceConnections[i].SetConnection("ifreight.database.windows.net", "SLDB", "ifrtAdmin", "05Jun!(&%");
            }
            //ReportDocument  subrpt;   
            foreach (ReportDocument subrpt in rptDoc.Subreports)
            {
                for (int j = 0; j < subrpt.DataSourceConnections.Count; j++)
                {
                    
                    subrpt.DataSourceConnections[j].SetConnection("ifreight.database.windows.net", "SLDB", "ifrtAdmin", "05Jun!(&%");

                }
            }
            SetParameter(strPM, rptDoc);
            //setSubReport(rptDoc);
            Crv.ReportSource = rptDoc;
            if (strSF != "{}undefinedundefined" && strSF != "")
                Crv.SelectionFormula = strSF;
            //SetSelectionFormula(rptDoc, strSF);       
        }
        public ReportDocument RptDataBase(string strFile, string strDBGroup, string strDBMaster, string strAPP, string strAccounts, string strTempRptName, string strHRName)
        {
            ReportDocument rptTemp = new ReportDocument();
            rptTemp.FileName = strFile;
            
            return rptTemp;
        }
        public string CheckDBAll(string tblGroubList, string tblMasterList, string tblAPPList, string tblCheck, string strDBGroupName, string strDBMasterName, string strDBAPPName, string tblFAList, string strFAName, string strTempList, string strTempname, string strHRList, string strHRName)
        {
            string strResult = "";
            if (tblGroubList.IndexOf(tblCheck) != -1)
            {
                strResult = strDBGroupName;
            }
            else if (tblMasterList.IndexOf(tblCheck) != -1)
            {
                strResult = strDBMasterName;
            }
            else if (tblAPPList.IndexOf(tblCheck) != -1)
            {
                strResult = strDBAPPName;
            }
            else if (tblFAList.IndexOf(tblCheck) != -1)
            {
                strResult = strFAName;
            }
            else if (strTempList.IndexOf(tblCheck) != -1)
            {
                strResult = strTempname;
            }
            else if (strHRList.IndexOf(tblCheck) != -1)
            {
                strResult = strHRName;
            }
            return strResult;
        }
        //Set the Parameter
        public void SetParameter(string strPM, ReportDocument rptTemp)
        {
            if (strPM != "")
            {
                string[] strPMCArray = strPM.Split('~');
                if (strPMCArray.Length > 0)
                {
                    for (int i = 0; i < strPMCArray.Length; i++)
                    {
                        string[] strPMArray = strPMCArray[i].Split('=');
                        if (strPMArray.Length > 0)
                        {
                            rptTemp.SetParameterValue(strPMArray[0], strPMArray[1]);
                        }
                    }
                }
            }
        }
        //Set the Selection formula to the report
        public void SetSelectionFormula(ReportDocument rptTemp, string strSF)
        {
            if (strSF != "")
                rptTemp.RecordSelectionFormula = strSF;
        }
        public void setSubReport(ReportDocument rptTemp)
        {
            if (rptTemp.Subreports.Count != 0)
            {
                Sections crSections;
                crSections = rptTemp.ReportDefinition.Sections;
                foreach (Section crsection in crSections)
                {
                    ReportObjects crReportObjects;
                    crReportObjects = crsection.ReportObjects;
                    foreach (ReportObject crReportobject in crReportObjects)
                    {
                        if (crReportobject.Kind == CrystalDecisions.Shared.ReportObjectKind.SubreportObject)
                        {
                            SubreportObject srobj;
                            srobj = ((SubreportObject)crReportobject);
                            ReportDocument subRptDoc = new ReportDocument();
                            subRptDoc = srobj.OpenSubreport(srobj.SubreportName);
                            Database dbTemp;
                            dbTemp = subRptDoc.Database;
                            Tables tblsTemp;
                            tblsTemp = dbTemp.Tables;
                            foreach (CrystalDecisions.CrystalReports.Engine.Table tblTemp in tblsTemp)
                            {
                                string curDB = CheckDBAll(strDBGroup_Tbl, strDBMaster_Tbl, strAPP_Tbl, tblTemp.Location, "FAGroup", "FAMaster", "FA" + Request.QueryString["bid"], strFA_Tbl, "logix", strTemp_Tbl, "FATemp", strHR_Tbl, "FAHR");
                                //tblTemp.Location = curDB + ".dbo." + tblTemp.Location;
                                if (tblTemp.Location == "FAMaster.dbo.MasterBranch")
                                {
                                    subRptDoc.DataDefinition.RecordSelectionFormula = "{MasterBranch.branchid}=" + intBranchID;
                                    Crv.ReportSource = subRptDoc;
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void Crv_Unload(object sender, EventArgs e)
        {
            rptDoc.Dispose();
        }
    }
}