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
using Ionic.Zip;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;
namespace logix.Tools
{
    public partial class ReportView2 : System.Web.UI.Page
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

        public void Page_Load(object sender, EventArgs e)
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
                        Logobj.InsCrystalRPTLogDtls("ReportView2", Request.QueryString["RFName"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    }
                    catch (Exception Ex)
                    {

                    }

                    
                    stEmpcode = Session["LoginEmpId"].ToString();
                  
                    if (Session["str_sfs"] != null)
                    {
                        strSF = Session["str_sfs"].ToString().Replace('@', '+');
                        //strPM = Request.QueryString["Parameter"].ToString();                
                        strPM = Session["str_sp"].ToString();
                        Session["str_sp"] = ""; Session["str_sfs"] = null;
                        strFName = Server.MapPath("../Reports/" + Session["Report2"].ToString());
                    }
                   

                    
                    intBranchID = Convert.ToInt16(Session["LoginBranchid"].ToString()); //GetParamID(this.Page, ParamIDType.BranchID);
                  

                  
                    showReportExport(strFName, strPM, strSF, stEmpcode);
                

                  
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

       

        public void showReportExport(string str_RptFileName, string Str_PM, string Str_SF, string str_Empcode)
        {
            
            try
            {
                int count;
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

                filePath =Server.MapPath(Session["Str_FolderName"].ToString());//Server.MapPath("~/SavePDF/");

                DirectoryInfo di = Directory.CreateDirectory(filePath);

                if (di.Exists)
                {
                    //di.Delete();
                }
                else
                {
                    di.Create();
                }
                //if (Directory.Exists(filePath))
                //{
                //    //Directory.CreateDirectory(filePath);
                //   if( Convert.ToInt32(Session["j"]) ==1)
                //    {
                //        foreach (string file in Directory.GetFiles(filePath))
                //        {
                //            File.Delete(file);
                //        }
                //    }
                //}

              
                filename = Session["Str_FileName"].ToString()+ ".pdf";
                rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, filePath +"\\"+ filename);

                FileInfo file = new FileInfo(filePath + "\\" + filename);
                if (file.Exists)
                {
                    file.Delete();
                }
               // string path="";
                /*string path = filePath;
                //string path = Server.MapPath(Session["Str_FolderName"].ToString() + "\\" + filename);
                WebClient client = new WebClient();
               // Byte[] buffer = client.DownloadData(path);

                int File_Count = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;


                if (File_Count >0)
                {


                    if (Convert.ToInt32(Session["j"]) == File_Count)
                        {
                          

                            string FullPathName = path ;
                            //string FullPathName = path;
                            var fileszip = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".zip"));
                            foreach (string file in fileszip)
                            {
                                File.Delete(file);
                            }
                                                    


                       

                          /* using (var zipStream = new ZipOutputStream(Response.OutputStream))
                           {
                               foreach (string filePath in filePaths)
                               {
                                   byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                                   var fileEntry = new ZipEntry(Path.GetFileName(filePath))
                                   {
                                       Size = fileBytes.Length
                                   };

                                   zipStream.PutNextEntry(fileEntry);
                                   zipStream.Write(fileBytes, 0, fileBytes.Length);
                               }

                               zipStream.Flush();
                               zipStream.Close();
                           }

                          /* HttpResponse Response = HttpContext.Current.Response;
                           Response.Clear();
                           Response.Charset = "";
                           string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                           Response.ContentType = "application/zip";
                           Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                           zip.Save(Response.OutputStream);
                           Response.End();
                        */

                           /*using (ZipFile zip = new ZipFile())
                           {
                               zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                               zip.AddDirectoryByName("Files");
                               foreach (GridViewRow row in GridView1.Rows)
                               {
                                   if ((row.FindControl("chkSelect") as CheckBox).Checked)
                                   {
                                       string filePath = (row.FindControl("lblFilePath") as Label).Text;
                                       zip.AddFile(filePath, "Files");
                                   }
                               }
                               Response.Clear();
                               Response.BufferOutput = false;
                               string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                               Response.ContentType = "application/zip";
                               Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                               zip.Save(Response.OutputStream);
                               Response.End();
                           }
                        

                            /*   Response.Clear();
                               Response.BufferOutput = false;  // for large files
                               String ReadmeText = "This is a zip file dynamically generated at " + System.DateTime.Now.ToString("G");
                               string filename = System.IO.Path.GetFileName(FullPathName) + ".zip";
                               Response.ContentType = "application/zip";
                               Response.AddHeader("content-disposition", "filename=" + filename);

                               using (ZipFile zip = new ZipFile())
                               {
                                   zip.AddFile(ListOfFiles.SelectedItem.Text, "files");
                                   zip.AddEntry("Readme.txt", "", ReadmeText);
                                   zip.Save(Response.OutputStream);
                               }
                               Response.Close();

                       


                            using (ZipFile zip = new ZipFile())
                            {
                                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                                zip.AddDirectoryByName("Files");
                                for (int i = 0; i < File_Count; i++)
                                {
                                    string path1 = FullPathName +"\\";
                                    zip.AddFile(path1, "Files");
                                }
                                    
                              

                                    HttpResponse response = HttpContext.Current.Response;
                                    response.BufferOutput = false;
                                    string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                                    response.Clear();
                                    response.Charset = "";                                   
                                    response.ContentType = "application/zip";
                                    response.AddHeader("Content-Disposition", "attachment; filename=" + zipName);
                                    zip.Save(response.OutputStream);
                                    response.End();
                            }
                        }
                    */
                    
               

                    
            }
            catch (Exception Ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "logix", "alertify.alert(''Processor Usage..." + Ex.Message + "');", true);
            }
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
      
    }
}