using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text.RegularExpressions;
using System.Net;
using ClosedXML.Excel;
using Ionic.Zip;
using System.EnterpriseServices;

namespace logix
{
    public partial class Download : System.Web.UI.Page
    {
        string filename;
        string username = "";
        string password = "";

        string ip = "";
        string dbname = "";

        protected string DBCS;
     
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["Test"] == "0")
            {
                string filename = Request.QueryString["Filename"];  
                string getcontent = GetContentType(filename);
                fttnormaldwd(filename, getcontent);
            }
            else if (Request.QueryString["Test"] == "1")
            {
                string filename = Request.QueryString["File"];  
                string getcontent = GetContentType(filename);
                fttnormaldwdes(filename, getcontent);
            }
            else if (Request.QueryString["Test"] == "2")
            {
                string filename = Request.QueryString["ExchangeFile"];
                string getcontent = GetContentType(filename);
                fttnormaldwdExrate(filename, getcontent);
            }
            //else
            //{
            //    string filename = Request.QueryString["Filename"];
            //    string getcontent = GetContentType(filename);
            //    fttnormaldwd(filename, getcontent);
            //}
        }

        public void fttnormaldwdExrate(string filename1, string getcontent)
        {

            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
            // added on 25Mar2023 
            username = "vmadmin";
            password = "VMWeb20Mar@)@#";
            string str_filename;
            str_filename = filename1;
            DataTable dt = new DataTable();

            string path = Server.MapPath("~/UploadDocument/ExRateFile/" + str_filename);
            string ftp = "ftp://20.235.30.214/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/ExRateFile/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            request.Credentials = new NetworkCredential(username, password);

            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Stream ftpStream = response.GetResponseStream())
            {
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }
            WebClient client = new WebClient();
            Byte[] buffer1 = client.DownloadData(path);
            //if (buffer1 != null)
            //{
            //    Response.ContentType = ContentType;
            //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
            //    Response.WriteFile(path);
            //    Response.Flush();
            //} 
            if (buffer1 != null)
            {
                HttpContext.Current.Response.ContentType = getcontent;
                HttpContext.Current.Response.AddHeader("content-length", buffer1.Length.ToString());
                HttpContext.Current.Response.BinaryWrite(buffer1);
            }

            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            Response.End();
        }
        //-----------------------------------------------------------------

        public void fttnormaldwdes(string filename1, string getcontent)
        {

            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
            // added on 25Mar2023 
            username = "vmadmin";
            password = "VMWeb20Mar@)@#";
            string str_filename;
            str_filename = filename1;
            DataTable dt = new DataTable();

            string path = Server.MapPath("~/UploadDocument/Businesscard/" + str_filename);
            string ftp = "ftp://20.235.30.214/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/Mastercustomer/BusinessCard/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            request.Credentials = new NetworkCredential(username, password);

            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Stream ftpStream = response.GetResponseStream())
            {
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }
            WebClient client = new WebClient();
            Byte[] buffer1 = client.DownloadData(path);
            //if (buffer1 != null)
            //{
            //    Response.ContentType = ContentType;
            //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
            //    Response.WriteFile(path);
            //    Response.Flush();
            //} 
            if (buffer1 != null)
            {
                HttpContext.Current.Response.ContentType = getcontent;
                HttpContext.Current.Response.AddHeader("content-length", buffer1.Length.ToString());
                HttpContext.Current.Response.BinaryWrite(buffer1);
            }

            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            Response.End();
        }


        public void fttnormaldwd(string filename1, string getcontent)
        {

            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
            // added on 25Mar2023 
            username = "vmadmin";
            password = "VMWeb20Mar@)@#";
            string str_filename;
            str_filename = filename1;
            DataTable dt = new DataTable();

            string path = Server.MapPath("~/UploadDocument/Proofs/" + str_filename);
            string ftp = "ftp://20.235.30.214/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/kyc/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            request.Credentials = new NetworkCredential(username, password);

            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Stream ftpStream = response.GetResponseStream())
            {
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }
            WebClient client = new WebClient();
            Byte[] buffer1 = client.DownloadData(path);
            //if (buffer1 != null)
            //{
            //    Response.ContentType = ContentType;
            //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
            //    Response.WriteFile(path);
            //    Response.Flush();
            //} 
            if (buffer1 != null)
            {
                HttpContext.Current.Response.ContentType = getcontent;
                HttpContext.Current.Response.AddHeader("content-length", buffer1.Length.ToString());
                HttpContext.Current.Response.BinaryWrite(buffer1);
            }

            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            Response.End();
        }

        private string GetContentType(string fileName)
        {
            string contentType = "application/octetstream";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (registryKey != null && registryKey.GetValue("Content Type") != null)
                contentType = registryKey.GetValue("Content Type").ToString();
            return contentType;
        }       

    }
}