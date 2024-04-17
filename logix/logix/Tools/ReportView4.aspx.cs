using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace logix.Tools
{
    public partial class ReportView4 : System.Web.UI.Page
    {
        public static ReportDocument rptDoc;
        public string strFName = "", strSF = "", strPM = "", exp = "", mailto = "", mailcontent = "", str_filename = "", mailsub = "";
        public Database DB;
        public Tables tbls;
        public CrystalDecisions.CrystalReports.Engine.Table tbl;
        public string strDBGroup, strDBMaster, strAPP, strQry, strFA, str_Export = "N", str_Empcode = "";
        public Database dbTemp;
        public DataTable dtTemp;
        public SqlCommand cmdTemp;
        public DataSet dsTemp;
        public SqlConnection conTemp;
        public SqlDataAdapter daTemp;
        public static string strDBGroup_Tbl, strDBMaster_Tbl, strAPP_Tbl, strFA_Tbl, strTemp_Tbl, strHR_Tbl;
        public static string strTranType;
        public static int intBranchID;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        //public Global glObj = new Global();
        string stEmpcode = "";
        string path = "";
        string filePath = "";
        string filename = "";


        string username = "";
        string password = "";


        string ip = "";
        string dbname = "";
        protected string DBCS;
      //  string dbname = "Demo";
        string gst;

        protected  void Page_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

            if (!IsPostBack)
            {
                try
                {

                    //Elengo
                    try
                    {
                        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                        DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                        if (dtlogo.Rows.Count > 0)
                        {
                            byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                            string base64String = Convert.ToBase64String(logoimageBytes);
                            Image4.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                        Logobj.InsCrystalRPTLogDtls("ReportView4", Request.QueryString["RFName"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    }
                    catch (Exception Ex)
                    {

                    }

                    //Crv.HasPrintButton = false;
                    //Crv.HasSearchButton = false;
                    //Crv.HasToggleGroupTreeButton = false;
                    Crv.HasToggleGroupTreeButton = false;
                    //Crv.HasExportButton = true;
                    //Session["LoginEmployeeid"] = "256";
                    stEmpcode = Session["LoginEmpId"].ToString();
                    //strSF = Request.QueryString["SFormula"].ToString().Replace('@', '+');
                    //if (Session["str_sfs"] != null)
                    //{
                    //    strSF = Session["str_sfs"].ToString().Replace('@', '+');
                    //    //strPM = Request.QueryString["Parameter"].ToString();                
                    //    strPM = Session["str_sp"].ToString();
                    //    Session["str_sp"] = null; Session["str_sfs"] = null;
                    //     if(strSF != "")
                    //     {
                    //         gst = Logobj.getvoudate4rpt(strSF);
                    //         if(gst=="Y")
                    //         {
                    //              strFName = Server.MapPath("../ReportsGST/" + Request.QueryString["RFName"].ToString());
                    //         }
                    //         else
                    //         {
                    //             strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                    //         }
                    //     }
           
          
                        
                    //}
                  


                    //else if (Session["str_sfs1"] != null)
                    //{
                    //    strSF = Session["str_sfs1"].ToString().Replace('@', '+');
                    //    //strPM = Request.QueryString["Parameter"].ToString();                
                    //    strPM = Session["str_sp1"].ToString();
                    //    Session["str_sp1"] = null; Session["str_sfs1"] = null;
                    //    if (strSF != "")
                    //    {
                    //        gst = Logobj.getvoudate4rpt(strSF);
                    //        if (gst == "Y")
                    //        {
                    //            strFName = Server.MapPath("../ReportsGST/" + Request.QueryString["RFName"].ToString());
                    //        }
                    //        else
                    //        {
                    //            strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                    //        }
                    //    }
                    //}
                    //else if (Session["str_sfs2"] != null)
                    //{
                    //    strSF = Session["str_sfs2"].ToString().Replace('@', '+');
                    //    //strPM = Request.QueryString["Parameter"].ToString();                
                    //    strPM = Session["str_sp2"].ToString();
                    //    Session["str_sp2"] = null; Session["str_sfs2"] = null;
                    //   // strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                    //    if (strSF != "")
                    //    {
                    //        gst = Logobj.getvoudate4rpt(strSF);
                    //        if (gst == "Y")
                    //        {
                    //            strFName = Server.MapPath("../ReportsGST/" + Request.QueryString["RFName"].ToString());
                    //        }
                    //        else
                    //        {
                    //            strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                    //        }
                    //    }

                    //}
                    //else if (Request.QueryString["RFName"].ToString() != "")
                    //{
                    //    strSF = Request.QueryString["SFormula"].ToString().Replace('@', '+');
                    //    //strPM = Request.QueryString["Parameter"].ToString();                
                    //    strPM = Request.QueryString["Parameter"].ToString();
                    //    //strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                    //   /* if (strSF != "")
                    //    {
                    //        gst = Logobj.getvoudate4rpt(strSF);
                    //        if (gst == "Y")
                    //        {
                    //            strFName = Server.MapPath("../ReportsGST/" + Request.QueryString["RFName"].ToString());
                    //        }
                    //        else
                    //        {
                    //            strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                    //        }
                    //    }
                    //    */
                    //    strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                    //    if (Request.QueryString.ToString().Contains("exp"))
                    //    {
                    //        exp = Request.QueryString["exp"].ToString();
                    //    }
                    //}                     
                    


                    //ARUN
                    if (Session["str_sfs"] != null && Session["str_sfs"].ToString() != "")
                    {
                        strSF = Session["str_sfs"].ToString().Replace('@', '+');
                        //strPM = Request.QueryString["Parameter"].ToString();                
                        strPM = Session["str_sp"].ToString();
                        Session["str_sp"] = null; Session["str_sfs"] = null;
                        //if (strSF != "")
                        //{
                        //    gst = Logobj.getvoudate4rpt(strSF);
                        //    if (gst == "Y")
                        //    {
                        //        strFName = Server.MapPath("../ReportsGST/" + Request.QueryString["RFName"].ToString());
                        //    }
                        //    else
                        //    {
                        //        strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        //    }
                        //}
                        //else
                        //{
                            strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        //}



                    }



                    else if (Session["str_sfs1"] != null && Session["str_sfs1"].ToString() != "")
                    {
                        strSF = Session["str_sfs1"].ToString().Replace('@', '+');
                        //strPM = Request.QueryString["Parameter"].ToString();                
                        strPM = Session["str_sp1"].ToString();
                        Session["str_sp1"] = null; Session["str_sfs1"] = null;
                        //if (strSF != "")
                        //{
                        //    gst = Logobj.getvoudate4rpt(strSF);
                        //    if (gst == "Y")
                        //    {
                        //        strFName = Server.MapPath("../ReportsGST/" + Request.QueryString["RFName"].ToString());
                        //    }
                        //    else
                        //    {
                        //        strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        //    }
                        //}                       
                        //else
                        //{
                            strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        //}
                    }
                    else if (Session["str_sfs2"] != null && Session["str_sfs2"].ToString() != "")
                    {
                        strSF = Session["str_sfs2"].ToString().Replace('@', '+');
                        //strPM = Request.QueryString["Parameter"].ToString();                
                        strPM = Session["str_sp2"].ToString();
                        Session["str_sp2"] = null; Session["str_sfs2"] = null;
                        // strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        //if (strSF != "")
                        //{
                        //    gst = Logobj.getvoudate4rpt(strSF);
                        //    if (gst == "Y")
                        //    {
                        //        strFName = Server.MapPath("../ReportsGST/" + Request.QueryString["RFName"].ToString());
                        //    }
                        //    else
                        //    {
                        //        strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        //    }
                        //}
                        //else
                        //{
                            strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                      //  }

                    }
                    else if (Request.QueryString["RFName"].ToString() != "")
                    {
                        strSF = Request.QueryString["SFormula"].ToString().Replace('@', '+');
                        //strPM = Request.QueryString["Parameter"].ToString();                
                        strPM = Request.QueryString["Parameter"].ToString();
                        //strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        //if (strSF != "")
                        //{
                        //    gst = Logobj.getvoudate4rpt(strSF);
                        //    if (gst == "Y")
                        //    {
                        //        strFName = Server.MapPath("../ReportsGST/" + Request.QueryString["RFName"].ToString());
                        //    }
                        //    else
                        //    {
                        //        strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        //    }
                        //}
                        //else
                        //{
                            strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                       // }
                        //strFName = Server.MapPath("../Reports/" + Request.QueryString["RFName"].ToString());
                        if (Request.QueryString.ToString().Contains("exp"))
                        {
                            exp = Request.QueryString["exp"].ToString();
                        }
                    } 

                    lblSF.Text = strSF;
                    lblPM.Text = strPM;
                    lblRpt.Text = strFName;
                    //
                    intBranchID = Convert.ToInt16(Session["LoginBranchid"].ToString()); //GetParamID(this.Page, ParamIDType.BranchID);
                    strSF = lblSF.Text;
                    strPM = lblPM.Text;
                    strFName = lblRpt.Text;
                                       
                    if (exp == "S")
                    {
                        mailto = Request.QueryString["mailto"].ToString();
                        mailcontent = Request.QueryString["mailcontent"].ToString();
                        str_filename = Request.QueryString["str_filename"].ToString();
                        mailsub = Request.QueryString["mailsub"].ToString();
                        
                        showReportExport1(strFName, strPM, strSF, stEmpcode);
                    }
                    else
                    {
                        showReportExport(strFName, strPM, strSF, stEmpcode);
                    }

                    if (strFName.IndexOf("FEBL4SCSPLDraft.rpt") != -1 || strFName.IndexOf("FEBL4PLDraft.rpt") != -1)
                    {
                        Crv.PrintMode = CrystalDecisions.Web.PrintMode.Pdf;
                        Crv.HasExportButton = false;
                    }
                    else
                    {
                        Crv.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
                        Crv.HasExportButton = false;                        
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        public void showReport()
        {
            intBranchID = Convert.ToInt16(Session["LoginBranchid"].ToString()); //GetParamID(this.Page, ParamIDType.BranchID);
            strSF = lblSF.Text;
            strPM = lblPM.Text;
            strFName = lblRpt.Text;

            rptDoc = new ReportDocument();
            rptDoc = RptDataBase(strFName, "FAGroup", "FAMaster", "FA" + intBranchID, "logix", "FATemp", "FAHR");
            SetParameter(strPM, rptDoc);
            // setSubReport(rptDoc);
            Crv.ReportSource = rptDoc;
            if (strSF != "{}undefinedundefined" && strSF != "")
                Crv.SelectionFormula = strSF;
        }
        
        public void showReportExport(string str_RptFileName, string Str_PM, string Str_SF, string str_Empcode)
        {
            try
            {
                strPM = Str_PM;
                strSF = Str_SF;
                rptDoc = new ReportDocument();
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                rptDoc = RptDataBase(str_RptFileName, "FAGroup", "FAMaster", "FA" + intBranchID, "logix", "FATemp", "FAHR");

                rptDoc.Load(str_RptFileName);
                rptDoc.SetDatabaseLogon(username, password, ip, dbname);
                rptDoc.Refresh();
                SetParameter(strPM, rptDoc);
                
                rptDoc.DataDefinition.RecordSelectionFormula = strSF;

                filePath = Server.MapPath("~/SavePDF/");
              
            
              

                // filename = Request.QueryString["RFName"].ToString() + ".pdf";
                if (Session["LoginEmpId"]!=null)
                {
                    if ( Session["LoginEmpId"]!="")
                    {
                        filename = Session["LoginEmpId"].ToString() + ".pdf";
                    }
                    else
                    {
                        filename = "Profile" + ".pdf";
                    }
                }
                else
                {
                    filename = "Profile" + ".pdf";
                }
             
                rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, filePath + filename);
                string path = Server.MapPath("~/SavePDF/" + filename);
                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(path);

                if (buffer != null)
                {
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("content-length", buffer.Length.ToString());
                    HttpContext.Current.Response.BinaryWrite(buffer);
                }
                FileInfo file = new FileInfo(path);
                if(file.Exists)
                {
                    file.Delete();
                }

                //if (Directory.Exists(filePath))
                //{

                //}
                //if (Directory.Exists(filePath + filename))
                //{
                //    //Directory.CreateDirectory(filePath);
                //    foreach (string file in Directory.GetFiles(filePath + filename))
                //    {
                //        File.Delete(file);
                //    }
                //}
            }
            catch (Exception Ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Processor Usage...');" + Ex.Message, true);

                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "logix", "alertify.alert(''Processor Usage..." + Ex.Message + "');", true);
            }
        }

        public void showReportExport1(string str_RptFileName, string Str_PM, string Str_SF, string str_Empcode)
        {
            if (exp == "S")
            {
                strPM = Str_PM;
                strSF = Str_SF;
                rptDoc = new ReportDocument();
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                rptDoc = RptDataBase(str_RptFileName, "FAGroup", "FAMaster", "FA" + intBranchID, "logix", "FATemp", "FAHR");

                rptDoc.Load(str_RptFileName);
                rptDoc.SetDatabaseLogon(username, password, ip, dbname);
                rptDoc.Refresh();
                SetParameter(strPM, rptDoc);

                rptDoc.DataDefinition.RecordSelectionFormula = strSF;

                filePath = Server.MapPath("~/SavePDF/");

                if (Directory.Exists(filePath))
                {
                    //Directory.CreateDirectory(filePath);
                    foreach (string file in Directory.GetFiles(filePath))
                    {
                        File.Delete(file);
                    }
                }

                // filename = Request.QueryString["RFName"].ToString() + ".pdf";
                filename = Session["StrTranType"].ToString() + ".pdf";
                rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, filePath + filename);

                Utility.SendMail(Session["usermailid"].ToString(), mailto, mailsub, mailcontent, (filePath + filename), Session["usermailpwd"].ToString());

                if (Directory.Exists(filePath))
                {
                    //Directory.CreateDirectory(filePath);
                    foreach (string file in Directory.GetFiles(filePath))
                    {
                        File.Delete(file);
                    }
                }
            }
            else if (Session["exp"] == "H")
            {
                strPM = Str_PM;
                strSF = Str_SF;
                rptDoc = new ReportDocument();
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                rptDoc = RptDataBase(str_RptFileName, "FAGroup", "FAMaster", "FA" + intBranchID, "logix", "FATemp", "FAHR");

                rptDoc.Load(str_RptFileName);
                rptDoc.SetDatabaseLogon(username, password, ip, dbname);
                rptDoc.Refresh();
                SetParameter(strPM, rptDoc);

                rptDoc.DataDefinition.RecordSelectionFormula = strSF;

                filePath = Server.MapPath("~/SavePDF/");

                if (Directory.Exists(filePath))
                {
                    //Directory.CreateDirectory(filePath);
                    foreach (string file in Directory.GetFiles(filePath))
                    {
                        File.Delete(file);
                    }
                }

                // filename = Request.QueryString["RFName"].ToString() + ".pdf";
                filename = Session["StrTranType"].ToString() + ".pdf";
                rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, filePath + filename);

                //Utility.SendMail(Session["mailfrom"].ToString(), Session["mailto"].ToString(), Session["mailsub"].ToString(), Session["mailcontent"].ToString(), (filePath + filename), Session["usermailpwd"].ToString());

                if (Directory.Exists(filePath))
                {
                    //Directory.CreateDirectory(filePath);
                    foreach (string file in Directory.GetFiles(filePath))
                    {
                        File.Delete(file);
                    }
                }
            }
            //Session["exp"] = "S";
        }

        public string GetDBName(string strDBName)
        {
            string strValidchars = "0123456789";
            string strRslt = "";
            strRslt = strDBName.ToUpper();
            string[] strsplit = new string[1];
            strsplit[0] = "logix";
            string[] strTmp = strRslt.Split(strsplit, StringSplitOptions.None);
            char[] chrtmp = strTmp[1].ToCharArray();
            if (strValidchars.IndexOf(chrtmp[0].ToString()) != -1)
                strRslt = "FA" + intBranchID;
            else
                strRslt = strDBName;
            return strRslt;
        }

        public ReportDocument RptDataBase(string strFile, string strDBGroup, string strDBMaster, string strAPP, string strAccounts, string strTempRptName, string strHRName)
        {
            ReportDocument rptTemp = new ReportDocument();
            rptTemp.FileName = strFile;

            for (int x = 0; x < rptTemp.DataSourceConnections.Count; x++)
            {
               
               
                rptTemp.DataSourceConnections[x].SetConnection(ip, dbname, username, password);
              
            }

            for (int y = 0; y < rptTemp.Subreports.Count; y++)
            {
                for (int z = 0; z < rptTemp.Subreports[y].DataSourceConnections.Count; z++)
                {
                   
                 
                    rptTemp.Subreports[y].DataSourceConnections[z].SetConnection(ip, dbname, username, password);
                  
                }
            }
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
            try
            {
                if (strPM != "")
                {
                    strPM = strPM.Replace("amp;", "&");
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
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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

                            //for (int z = 0; z < subRptDoc.DataSourceConnections.Count; z++)
                            //{
                            //    subRptDoc.DataSourceConnections[z].IntegratedSecurity = true;
                            //}  

                            Database dbTemp;
                            dbTemp = subRptDoc.Database;

                            Tables tblsTemp;
                            tblsTemp = dbTemp.Tables;
                            foreach (CrystalDecisions.CrystalReports.Engine.Table tblTemp in tblsTemp)
                            {
                                string curDB = CheckDBAll(strDBGroup_Tbl, strDBMaster_Tbl, strAPP_Tbl, tblTemp.Location, "FAGroup", "FAMaster", "logix", strFA_Tbl, "logix", strTemp_Tbl, "FATemp", strHR_Tbl, "FAHR");
                                tblTemp.Location = curDB + ".dbo." + tblTemp.Location;
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
            try
            {
                rptDoc.Dispose();
                //string str_RptFileName=""; string Str_PM = ""; string Str_SF = ""; string str_Empcode = ""; 
                //showReportExport(strFName, strPM, strSF, str_Empcode);
            }

            catch (Exception Ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "logix", "alertify.alert(''Processor Usage..." + Ex.Message + "');", true);
            }
        }

        public string GetCurrentN(string strTmpDBName)
        {
            if (char.IsNumber(strTmpDBName, 4))
                return "FA" + intBranchID.ToString();
            else
                return strTmpDBName;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            this.Confirmdialog.Hide();
            //Session["ViewBLRelease"] = null;
            intBranchID = Convert.ToInt16(Session["LoginBranchid"].ToString());
            strSF = lblSF.Text;
            strPM = lblPM.Text;
            strFName = lblRpt.Text;
            showReportExport1(strFName, strPM, strSF, stEmpcode);

            Response.Clear();
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath + filename));
            Response.WriteFile(filePath + filename);
            Response.Flush();
            System.IO.File.Delete(filePath + filename);
            Response.End();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            this.Confirmdialog.Hide();
            showReport();
            Crv.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
            Crv.HasExportButton = false;
        }
    }
}