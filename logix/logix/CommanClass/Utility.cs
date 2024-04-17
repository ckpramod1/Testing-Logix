using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.IO;
using System.Net;

using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Globalization;
namespace logix
{
    public class Utility
    {

       
        //public static string fn_ConvertDate(string str_IPDate)
        //{
        //    string str_OPDate = "";
        //    string[] datSrc = str_IPDate.Split('/');

        //    if (datSrc[1].Length < 2)
        //        datSrc[1] = "0" + datSrc[1];

        //    if (datSrc[0].Length < 2)
        //        datSrc[0] = "0" + datSrc[0];

        //    str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
        //    return str_OPDate;
        //}
        public static string fn_ConvertDate12(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];
            str_OPDate = datSrc[0] + "/" + datSrc[1] + "/" + datSrc[2];
            //str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return str_OPDate;
        }
        public static string fn_ConvertDate(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            CultureInfo culture = CultureInfo.CurrentCulture;
            string regionName = culture.Name;
            if (regionName == "en-US")
            {
                if (IsDateFormatValid(str_IPDate, "dd-MM-yyyy") || IsDateFormatValid(str_IPDate, "dd/MM/yyyy HH:mm:ss") ||
                IsDateFormatValid(str_IPDate, "MM/dd/yyyy HH:mm:ss") ||
                IsDateFormatValid(str_IPDate, "dd-MM-yyyy HH:mm:ss"))
                {
                    DateTime dt = Convert.ToDateTime(str_IPDate);
                    string str = dt.ToString("MM/dd/yyyy");
                    str_IPDate = str.Replace("-", "/");
                }
            }
            else
            {
                if (IsDateFormatValid(str_IPDate, "dd/MM/yyyy") || IsDateFormatValid(str_IPDate, "dd-MM-yyyy") || IsDateFormatValid(str_IPDate, "dd/MM/yyyy HH:mm:ss") ||
                                IsDateFormatValid(str_IPDate, "MM/dd/yyyy HH:mm:ss") ||
                                IsDateFormatValid(str_IPDate, "dd-MM-yyyy HH:mm:ss"))
                {
                    DateTime dt = Convert.ToDateTime(str_IPDate);
                    string str = dt.ToString("MM/dd/yyyy");
                    str_IPDate = str.Replace("-", "/");
                }
            }
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return str_OPDate;
        }
        static bool IsDateFormatValid(string date, string format)
        {
            DateTime parsedDate;
            return DateTime.TryParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate);
        }
        public static string fn_ConvertDateOld(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return str_OPDate;
        }
        //public static string fn_ConvertDate(string str_IPDate)
        //{
        //    string str_OPDate = "";
        //    string[] datSrc;
        //    string specialChar = @"-";
        //    string chk;
        //    foreach (var item in specialChar)
        //    {
        //        chk = "T";
        //        if (chk == "T")
        //        {
        //            str_IPDate = Convert.ToDateTime(str_IPDate).ToString();
        //            DateTime dt = Convert.ToDateTime(str_IPDate);
        //            string str = dt.ToString("MM/dd/yyyy");
        //            str_IPDate = str.Replace("-", "/");
        //        }
        //        break;
        //    }

        //    datSrc = str_IPDate.Split(' ');
        //    str_IPDate = datSrc[0];
        //    datSrc = str_IPDate.Split('/');

        //    if (datSrc[1].Length < 2)
        //        datSrc[1] = "0" + datSrc[1];

        //    if (datSrc[0].Length < 2)
        //        datSrc[0] = "0" + datSrc[0];

        //    str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
        //    return str_OPDate;
        //}

        public static string fn_ConvertDate1(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "" + datSrc[0] + "" + datSrc[2];
            return str_OPDate;
        }

        public static string fn_ConvertDatetime(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            string time = DateTime.Now.ToLongTimeString();
            str_OPDate = str_OPDate + " " + time;
            return str_OPDate;
        } 
        public static string Fn_ExportExcel(System.Web.UI.WebControls.GridView Grd, string Filename)
        {
            //int i, j;
            //string strExcel;
            //strExcel = "";

            //strExcel = strExcel + "<html  xmlns:v=\"urn:schemas-microsoft-com:vml\"xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"xmlns=\"http://www.w3.org/TR/REC-html40\">";
            //strExcel = strExcel + "<table>";
            //strExcel = strExcel + Filename;
            //strExcel = strExcel + "<tr>";
            //for (i = 0; i <= Grd.Columns.Count - 1; i++)
            //{
            //    strExcel = strExcel + "<td><FONT FACE=arial SIZE=2>" + Grd.Columns[i].HeaderText + "</FONT></td>";
            //}
            //strExcel = strExcel + "</tr>";

            //for (i = 0; i <= Grd.Rows.Count - 1; i++)
            //{
            //    strExcel = strExcel + "<tr>";
            //    for (j = 0; j <= Grd.Columns.Count - 1; j++)
            //    {
            //        strExcel = strExcel + "<td><FONT FACE=arial>" + Grd.Rows[i].Cells[j].Text + "</FONT></td>";
            //    }
            //    strExcel = strExcel + "</tr>";
            //}

            //strExcel = strExcel + "</table>";

            string strExcel;
            strExcel = "";
            List<string> columnNames = new List<string>();
            columnNames = Grd.Columns.Cast<DataControlField>().Select(row => row.HeaderText).ToList();
          
            var HeaderField = "<tr><td><FONT FACE=arial>" + string.Join("</td><td><FONT FACE=arial>", columnNames) + "</FONT></td></tr>";
            var ValueField = Grd.Rows.Cast<GridViewRow>()
                .Select(row => "<tr><td><FONT FACE=arial>" + string.Join("</td><td><FONT FACE=arial>", row.Cells.OfType<TableCell>().Select(cell => cell.Text).ToArray()) + "</FONT></td></tr>");
            strExcel = strExcel + "<html  xmlns:v=\"urn:schemas-microsoft-com:vml\"xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"xmlns=\"http://www.w3.org/TR/REC-html40\">";
            strExcel = strExcel + "<table>";
            strExcel = strExcel + Filename;
            strExcel = strExcel + HeaderField + string.Join("", ValueField);
            strExcel = strExcel + "</table>";
            return strExcel;
        }





        public static List<string> Fn_TableToList(DataTable dt, string str_Textfield, string str_Valuefield, string str_labelfield, string str_DisplayField)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_labelfield).ToString() + "~" + r.Field<string>(str_DisplayField)).ToList();

            return lst_details;
        }
        public static List<string> Fn_TableToList(DataTable dt, string str_Textfield, string str_Valuefield, string str_labelfield, string str_DisplayField, string str_field1)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_labelfield).ToString() + "~" + r.Field<string>(str_DisplayField) + "~" + r.Field<string>(str_field1)).ToList();

            return lst_details;
        }

        //Elakkiya --04/08/2016 --Dinesh
        public static List<string> Fn_DatatableToList_int16DisplayNew(DataTable dt, string str_Textfield, string str_Valuefield, string str_Valuefield1, string str_displayfield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r[str_Valuefield1].ToString() + "~" + r.Field<string>(str_displayfield).ToString()).ToList();

            return lst_details;
        }
        //Elakkiya --04/08/2016 --Dinesh
        public static string fn_ConvertDateWithTimebha(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc = str_IPDate.Split('-');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "-" + datSrc[0] + "-" + datSrc[2];
            return str_OPDate;
        }

        //*****************************************Elakkiya***********************************

        public static List<string> Fn_TableToList(string prefix, DataTable dt, string str_Textfield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable() where r[str_Textfield].ToString().Contains(prefix) select r[str_Textfield].ToString()).ToList();
            return lst_details;
        }


        public static List<string> Fn_TableToList_Cust(DataTable dt, string str_Textfield, string str_Valuefield, string str_labelfield, string str_DisplayField)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r[str_labelfield].ToString() + "~" + r.Field<int>(str_DisplayField)).ToList();

            return lst_details;
        }

        public static List<string> Fn_TableToList_Cust1(DataTable dt, string str_Textfield, string str_Valuefield, string str_displayfield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_displayfield).ToString()).ToList();

            return lst_details;
        }

        public static List<string> Fn_TableToList_Cust12(DataTable dt, string str_Textfield, string str_Valuefield, string str_displayfield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_displayfield).ToString()).ToList();

            return lst_details;
        }

        //********************************************************************************

        public static List<string> Fn_TableToList(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_string(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r.Field<string>(str_Valuefield).ToString()).ToList();

            return lst_details;
        }

        public static List<string> Fn_DatatableToList_stringnew(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r[str_Textfield].ToString() + "~" + r[str_Valuefield].ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_tinyint(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_int16Display(DataTable dt, string str_Textfield, string str_Valuefield, string str_displayfield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_displayfield).ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList(DataTable dt, string str_Textfield, string str_Valuefield, string str_displayfield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_displayfield).ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_int16(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString().TrimEnd()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_int32(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString().TrimEnd()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_cargo(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString()).ToList();

            return lst_details;
        }
        public static string Fn_ExportExcel_Datatable(DataTable Dt, string Filename)
        {
            int i, j;
            string strExcel;
            strExcel = "";

            strExcel = strExcel + "<html  xmlns:v=\"urn:schemas-microsoft-com:vml\"xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"xmlns=\"http://www.w3.org/TR/REC-html40\">";
            strExcel = strExcel + "<table>";
            strExcel = strExcel + Filename;
            strExcel = strExcel + "<tr>";
            for (i = 0; i <= Dt.Columns.Count - 1; i++)
            {
                strExcel = strExcel + "<td><FONT FACE=arial SIZE=2>" + Dt.Columns[i].ColumnName.ToString() + "</FONT></td>";
            }
            strExcel = strExcel + "</tr>";

            for (i = 0; i <= Dt.Rows.Count - 1; i++)
            {
                strExcel = strExcel + "<tr>";
                for (j = 0; j <= Dt.Columns.Count - 1; j++)
                {
                    strExcel = strExcel + "<td><FONT FACE=arial>" + Dt.Rows[i][j].ToString() + "</FONT></td>";
                }
                strExcel = strExcel + "</tr>";
            }

            strExcel = strExcel + "</table>";
            return strExcel;

        }
        public static List<string> Fn_DatatableToList(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_Customer(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString()).ToList();

            return lst_details;
        }
        public static Boolean fn_Grd_GrandTotal_Bold()
        {
            return true;
        }
        public static System.Drawing.Color fn_Grd_GrandTotal_Color()
        {
            return System.Drawing.Color.Blue;
        }
        public static int fn_intMonthName(string str_Month)
        {
            int Int_Month = 0;
            switch (str_Month.ToUpper())
            {
                case "JAN":
                    Int_Month = 01;
                    break;
                case "FEB":
                    Int_Month = 02;
                    break;
                case "MAR":
                    Int_Month = 03;
                    break;
                case "APR":
                    Int_Month = 04;
                    break;
                case "MAY":
                    Int_Month = 05;
                    break;
                case "JUN":
                    Int_Month = 06;
                    break;
                case "JUL":
                    Int_Month = 07;
                    break;
                case "AUG":
                    Int_Month = 08;
                    break;
                case "SEP":
                    Int_Month = 09;
                    break;
                case "OCT":
                    Int_Month = 10;
                    break;
                case "NOV":
                    Int_Month = 11;
                    break;
                case "DEC":
                    Int_Month = 12;
                    break;
            }

            return Int_Month;
        }
        public static void SendMail(string strFrom, string strTo, string strSub, string strContent, string strAttachment, string strPassword, string Str_BCC = "", string Str_CC = "")
        {

            
            SendmailGAuth.MailSend objsend1 = new SendmailGAuth.MailSend();
            objsend1.SendMailGmail(strFrom, strTo, strSub, strContent, strAttachment, "arumugam369*", Str_BCC, "pabiruban2001@gmail.com;nambimca07@gmail.com");





        }
        public static void SendMail4event(string strFrom, string strTo, string strSub, string strContent, string strAttachment, string strPassword, string Str_BCC = "", string Str_CC = "")
        {




            
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(strFrom);
               
                if (strTo != "")
                {
                    if (strTo.Length > 0)
                    {
                        string[] strTempto = strTo.Split(';');

                        for (int i = 0; i < strTempto.Length; i++)
                        {
                            if (strTempto[i] != "")
                            {
                                mail.To.Add(strTempto[i]);
                            }


                        }
                    }

                }


                //if (strTo != "")
                //{
                //    mail.To.Add(strTo);
                //}

                if (Str_BCC != "")
                {
                    // mail.Bcc.Add(Str_BCC);

                    if (Str_BCC.Length > 0)
                    {
                        string[] strTemptobcc = Str_BCC.Split(';');

                        for (int i = 0; i < strTemptobcc.Length; i++)
                        {
                            if (strTemptobcc[i] != "")
                            {
                                mail.Bcc.Add(strTemptobcc[i]);
                            }


                        }
                    }
                }
                if (Str_CC != "")
                {
                    // mail.CC.Add(Str_CC);
                    if (Str_CC.Length > 0)
                    {
                        string[] strTemptocc = Str_CC.Split(';');

                        for (int i = 0; i < strTemptocc.Length; i++)
                        {
                            if (strTemptocc[i] != "")
                            {
                                mail.CC.Add(strTemptocc[i]);
                            }


                        }
                    }
                }
                mail.Subject = strSub;
                mail.IsBodyHtml = true;
                mail.Body = strContent;
                if (strAttachment != "")
                {
                    string[] strTemp = strAttachment.Split(';');
                    for (int i = 0; i < strTemp.Length; i++)
                    {
                        Attachment mail_attachment = new Attachment(strTemp[i]);
                        mail.Attachments.Add(mail_attachment);
                    }
                }
                SmtpClient SmtpClient = new SmtpClient();
                System.Net.NetworkCredential Credential; //= new System.Net.NetworkCredential(strFrom.Trim(), strPassword.Trim());
                if (strFrom == "" || strPassword == "" || strTo == "")
                {
                    //Credential = new System.Net.NetworkCredential("", "logix");
                    Credential = new System.Net.NetworkCredential(strFrom.Trim(), strPassword.Trim());

                }
                else
                {
                    Credential = new System.Net.NetworkCredential(strFrom.Trim(), strPassword.Trim());
                }


                SmtpClient.Host = "";
                SmtpClient.Port = 25;
                // SmtpClient.Port = 465;
                SmtpClient.Credentials = Credential;

                SmtpClient.Send(mail);

                if (strSub.Contains("Investment Plan For"))
                {
                    ((IDisposable)mail).Dispose();
                    if (strAttachment != "")
                    {
                        string[] strTemp = strAttachment.Split(';');
                        for (int i = 0; i < strTemp.Length; i++)
                        {
                            if (File.Exists(strTemp[i])) File.Delete(strTemp[i]);
                        }
                    }
                }
            }
            catch (Exception mailError)
            {

            }




        }

        public static void SendMailnew(string strFrom, string strTo, string strSub, string strContent, string strAttachment, string strPassword, string Str_BCC = "", string Str_CC = "")
        {


        }

        private static bool CertificateValidationCallBack(
                 object sender,
                 System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                 System.Security.Cryptography.X509Certificates.X509Chain chain,
                 System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certificates. These certificates are valid
                // for default Exchange server installations, so return true.
                return true;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }
        }

         public static List<string> Fn_DatatableToList_CustomerAddress(DataTable dt, string str_Textfield, string str_Valuefield)
         {
             List<string> lst_details = new List<string>();
             lst_details = (from r in dt.AsEnumerable()
                            select r.Field<string>(str_Textfield).ToUpper() + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_Textfield).ToUpper() + System.Environment.NewLine +"~"+
                            Fn_DbNullValue<string>(r.Field<string>("address"))).ToList();

             return lst_details;
         }

        public static List<string> Fn_DatatableToList_CustomerAddress1(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield).ToUpper() + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_Textfield).ToUpper() + System.Environment.NewLine +
                           Fn_DbNullValue<string>(r.Field<string>("address"))).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_Text(DataTable dt, string str_Textfield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield).TrimEnd()).ToList();

            return lst_details;
        }
        private static T Fn_DbNullValue<T>(object value)
        {
            if (value == null && value == DBNull.Value)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
        public static string fn_ConvertDateWithTime(string str_IPDate)
        {
            string str_OPDate = "";
            CultureInfo culture = CultureInfo.CurrentCulture;
            string regionName = culture.Name;
            if (regionName == "en-US")
            {
                if (IsDateFormatValid(str_IPDate, "dd-MM-yyyy") || IsDateFormatValid(str_IPDate, "dd/MM/yyyy HH:mm:ss") ||
                IsDateFormatValid(str_IPDate, "MM/dd/yyyy HH:mm:ss") ||
                IsDateFormatValid(str_IPDate, "dd-MM-yyyy HH:mm:ss"))
                {
                    DateTime dt = Convert.ToDateTime(str_IPDate);
                    string str = dt.ToString("MM/dd/yyyy");
                    str_IPDate = str.Replace("-", "/");
                }
            }
            else
            {
                if (IsDateFormatValid(str_IPDate, "dd/MM/yyyy") || IsDateFormatValid(str_IPDate, "dd-MM-yyyy") || IsDateFormatValid(str_IPDate, "dd/MM/yyyy HH:mm:ss") ||
                                IsDateFormatValid(str_IPDate, "MM/dd/yyyy HH:mm:ss") ||
                                IsDateFormatValid(str_IPDate, "dd-MM-yyyy HH:mm:ss"))
                {
                    DateTime dt = Convert.ToDateTime(str_IPDate);
                    string str = dt.ToString("MM/dd/yyyy");
                    str_IPDate = str.Replace("-", "/");
                }
            }
            string[] datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            string time = DateTime.Now.ToLongTimeString();
            str_OPDate = str_OPDate + " " + time;
            return str_OPDate;




        }
        public static string fn_ConvertDateWithTimeOld(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            string time = DateTime.Now.ToLongTimeString();
            str_OPDate = str_OPDate + " " + time;
            return str_OPDate;




        }
        public static List<string> Fn_DatatableToListstring(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r.Field<string>(str_Valuefield).ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_TableToList_Custaddress(DataTable dt, string str_Textfield, string str_Valuefield, string str_labelfield, string str_DisplayField)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r[str_labelfield].ToString() + "~" + r.Field<string>(str_DisplayField)).ToList();

            return lst_details;
        }
        public static DataTable Fn_GetEmptyDataTable()
        {
            DataTable dt_ok = new DataTable();
            return dt_ok;
        }
        public static string Fn_AmountToWord(double Amount)
        {
            string[] amount = Amount.ToString().Split('.');
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int j = 0; j <= amount.Length - 1; j++)
            {
                int number = 0;
                number = int.Parse(amount[j].ToString());
                if (number == 0) return "Zero";
                int[] num = new int[4];
                int first = 0;
                int u, h, t;
                if (number < 0)
                {
                    sb.Append("Minus ");
                    number = -number;
                }
                string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
                string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
                string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
                string[] words3 = { "Thousand ", "Lakhs ", "Crore " };
                num[0] = number % 1000;           // units
                num[1] = number / 1000;
                num[2] = number / 1000000;
                num[1] = num[1] - 1000 * num[2];  // thousands
                num[3] = number / 10000000;     // billions
                //num[2] = num[2] - 1000 * num[3];  // millions
                for (int i = 3; i > 0; i--)
                {
                    if (num[i] != 0)
                    {
                        first = i;
                        break;
                    }
                }
                for (int i = first; i >= 0; i--)
                {
                    if (num[i] == 0) continue;
                    u = num[i] % 10;              // ones
                    t = num[i] / 10;
                    h = num[i] / 100;             // hundreds
                    t = t - 10 * h;               // tens
                    if (h > 0) sb.Append(words0[h] + "Hundred ");
                    if (u > 0 || t > 0)
                    {
                        if (h > 0 || i < first) sb.Append(" and ");
                        if (t == 0)
                            sb.Append(words0[u]);
                        else if (t == 1)
                            sb.Append(words1[u]);
                        else
                            sb.Append(words2[t - 2] + words0[u]);
                    }
                    if (i != 0) sb.Append(words3[i - 1]);
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static List<string> Fn_TableToList_Invoice(DataTable dt, string str_Textfield, string str_Valuefield, string str_labelfield, string str_labelfield1, string str_DisplayField, string str_DisplayField1, string str_DisplayField2)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_labelfield) + "~" + r.Field<string>(str_labelfield1) + "~" + r.Field<string>(str_DisplayField) + "~" + r.Field<string>(str_DisplayField1) + "~" + r.Field<string>(str_DisplayField2)).ToList();

            return lst_details;
        }
        public static int fn_getMonthName(string str_Month)
        {
            int Int_Month = 0;
            switch (str_Month.ToUpper())
            {
                case "JANUARY":
                    Int_Month = 01;
                    break;
                case "FEBRUARY":
                    Int_Month = 02;
                    break;
                case "MARCH":
                    Int_Month = 03;
                    break;
                case "APRIL":
                    Int_Month = 04;
                    break;
                case "MAY":
                    Int_Month = 05;
                    break;
                case "JUNE":
                    Int_Month = 06;
                    break;
                case "JULY":
                    Int_Month = 07;
                    break;
                case "AUGUST":
                    Int_Month = 08;
                    break;
                case "SEPTEMBER":
                    Int_Month = 09;
                    break;
                case "OCTOBER":
                    Int_Month = 10;
                    break;
                case "NOVEMBER":
                    Int_Month = 11;
                    break;
                case "DECEMBER":
                    Int_Month = 12;
                    break;
            }

            return Int_Month;
        }
        public static List<string> fn_test(DataTable dt, string str_Textfield, string str_Valuefield, string str_labelfield, string str_DisplayField)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r[str_labelfield].ToString() + "~" + r.Field<string>(str_DisplayField).ToString()).ToList();

            return lst_details;
        }

        public static string Fn_ExportExcel_Datatable_LQ(System.Web.UI.WebControls.GridView Grd, DataTable Dt, string Filename)
        {

            string strExcel;
            strExcel = "";

            List<string> columnNames = new List<string>();
            for (int i = 0; i <= Dt.Columns.Count - 1; i++)
            {
                if (i <= Grd.Columns.Count - 1)
                {
                    DataControlField Columnfield = Grd.Columns[i];
                    BoundField field = Columnfield as BoundField;
                    if (Dt.Columns[i].ColumnName.ToString() == field.DataField.ToString())
                    {
                        columnNames.Add(Grd.Columns[i].HeaderText);
                    }
                    else
                    {

                        Dt.Columns.RemoveAt(i);
                        Dt.AcceptChanges();
                        i--;
                    }
                }
                else
                {
                    Dt.Columns.RemoveAt(i);
                    Dt.AcceptChanges();
                }
            }
            var HeaderField = "<tr><td>" + string.Join("</td><td><FONT FACE=arial>", columnNames) + "</FONT></td></tr>";

            var ValueField = Dt.AsEnumerable()
                .Select(row => "<tr><td>" + string.Join("</td><td><FONT FACE=arial>", row.ItemArray) + "</FONT></td></tr>");

            strExcel = strExcel + "<html  xmlns:v=\"urn:schemas-microsoft-com:vml\"xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"xmlns=\"http://www.w3.org/TR/REC-html40\">";
            strExcel = strExcel + "<table>";
            strExcel = strExcel + Filename;
            strExcel = strExcel + HeaderField + string.Join("", ValueField);
            strExcel = strExcel + "</table>";
            return strExcel;

        }
        public static string fn_GetMonthName(int int_Month, bool Fullname)
        {
            string str_Month = "";
            switch (int_Month)
            {
                case 01:
                    str_Month = "JANUARY";
                    break;
                case 02:
                    str_Month = "FEBRUARY";
                    break;
                case 03:
                    str_Month = "MARCH";
                    break;
                case 04:
                    str_Month = "APRIL";
                    break;
                case 05:
                    str_Month = "MAY";
                    break;
                case 06:
                    str_Month = "JUNE";
                    break;
                case 07:
                    str_Month = "JULY";
                    break;
                case 08:
                    str_Month = "AUGUST";
                    break;
                case 09:
                    str_Month = "SEPTEMBER";
                    break;
                case 10:
                    str_Month = "OCTOBER";
                    break;
                case 11:
                    str_Month = "NOVEMBER";
                    break;
                case 12:
                    str_Month = "DECEMBER";
                    break;
                default:
                    str_Month = "";
                    break;
            }
            if (Fullname == true)
            {
                return str_Month;
            }
            else
            {
                return str_Month = str_Month.Length >= 3 ? str_Month.Substring(0, 3) : str_Month;
            }
        }


        public static string Fn_GetCompanyAddress()
        {
            string str_Address = "";
            DataTable dt_ok = new DataTable();
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            dt_ok = obj_da_Log.GetCompanyNameAdd(int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()));
            if (dt_ok.Rows.Count > 0)
            {
                str_Address = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + dt_ok.Rows[0][0].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + dt_ok.Rows[0][1].ToString() + " <br> Phone : " + dt_ok.Rows[0][2].ToString() + " Fax : " + dt_ok.Rows[0][3].ToString() + "</Font></center><HR width=100%></body>";
            }
            return str_Address;
        }
        public static void MasterAll(LinkButton LnkBtn, TextBox txtBox)
        {
            string strScript = "var mywin=window.open('../HRM/EmployeeFind.aspx?txt1=" + txtBox.ID + "','HRM','menubar=0,resizable=0,width=750,height=330,scrollbars=1');return true;";
            LnkBtn.Attributes.Add("OnClick", strScript);
            txtBox.Attributes.Add("OnKeyDown", "return true;");
        }
        public static void Fn_CreateErrorFile(Exception Error_Exp)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/ErrorLog/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string Str_Date = DateTime.Today.ToString("dd-MMM-yyyy");
                path = path + Str_Date + ".txt";

                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }

                string[] ErrorList = Error_Exp.InnerException.StackTrace.ToString().Split(System.Environment.NewLine.ToCharArray());
                string str_Err = "";
                foreach (string str in ErrorList)
                {
                    if (str.ToString().Contains("logix"))
                    {
                        str_Err = "\r\nError Event And LineNumber :" + str;
                        break;
                    }
                }
                using (StreamWriter writer = File.AppendText(path))
                {
                    string Str_Error = "\r\nErrorLog Time : " + DateTime.Now.ToString() +
                                   "\r\nError PageName : " + HttpContext.Current.Request.Url.ToString() +
                                   "\r\n\r\nError :" + Error_Exp.InnerException.Message.ToString();
                    Str_Error = Str_Error + str_Err;
                    writer.WriteLine(Str_Error);
                    writer.WriteLine("------------------------------------------------------------------");
                    writer.Flush();
                    writer.Close();
                }

            }
            catch (Exception ex)
            {

            }
        }
        public static void Fn_CheckUserRights(string Str_UIID, Button Btn_Save,Button Btn_View,Button Btn_Delete)
        {
            DataTable dt_okuser = new DataTable();
            dt_okuser = (DataTable)HttpContext.Current.Session["dt_UserRights"];
            if (dt_okuser !=null)
            {
                var UserRights = dt_okuser.AsEnumerable().Where(row => row["uiid"].ToString() == Str_UIID).ToList();
                if (UserRights.Count > 0)
                {
                    if (Btn_Save != null)
                    {
                        Btn_Save.Enabled = Boolean.Parse(UserRights[0]["btnsave"].ToString());
                        if (Btn_Save.Text == "Update")
                        {
                            Btn_Save.Enabled = Boolean.Parse(UserRights[0]["btnupdate"].ToString());
                        }
                    }
                    if (Btn_View != null)
                    {
                        Btn_View.Enabled = Boolean.Parse(UserRights[0]["btnview"].ToString());
                       
                    }
                    if (Btn_Delete != null)
                    {
                        Btn_Delete.Enabled = Boolean.Parse(UserRights[0]["btndelete"].ToString());

                    }

                }
            }
        }

        //bharathi
        public static string fn_ConvertDatebha(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('-');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "-" + datSrc[0] + "-" + datSrc[2];
            return str_OPDate;
        }


        internal static object fn_ConvertDate(object p)
        {
            throw new NotImplementedException();
        }
        public static List<string> Fn_DatatableToList_CustomerAddress2(DataTable dt, string str_Textfield, string str_Textfield1, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield).ToUpper() + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_Textfield1).ToUpper() + System.Environment.NewLine +
                           Fn_DbNullValue<string>(r.Field<string>("address"))).ToList();

            return lst_details;
        }

        public static string fn_ConvertDateonly(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[0] + "/" + datSrc[1] + "/" + datSrc[2];
            return str_OPDate;
        }

        //Ruban

        public static List<string> Fn_DatatableToList_string1(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r[str_Textfield].ToString() + "~" + r[str_Valuefield].ToString()).ToList();

            return lst_details;
        }

        //FA

        

        public static List<string> Fn_TableToList(DataTable dt, string str_Textfield, string str_Valuefield, string str_Value)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r[str_Textfield].ToString() + "~" + r[str_Valuefield].ToString() + "~" + r[str_Value].ToString()).ToList();

            return lst_details;
        }

        public static List<string> Fn_TableToListnew(DataTable dt, string str_Textfield, string str_Valuefield, string str_Value, string str_Valuenew)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r[str_Textfield].ToString() + "~" + r[str_Valuefield].ToString() + "~" + r[str_Value].ToString() + "~" + r[str_Valuenew].ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_TableToList(DataTable dt, string str_Textfield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r[str_Textfield].ToString()).ToList();

            return lst_details;
        }


        public static List<string> Fn_DttableToList(DataTable dt, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Valuefield).ToString()).ToList();

            return lst_details;
        }
        public static List<string> Fn_DatatableToList_CustomerAddress2new(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield).ToUpper() + "~" + r[str_Valuefield].ToString() + "~" + System.Environment.NewLine +
                           Fn_DbNullValue<string>(r.Field<string>("address"))).ToList();

            return lst_details;
        }
        public static List<string> Fn_TableToList4type(DataTable dt, string str_Textfield, string str_Valuefield, string str_Textfield1, string str_Textfield2, string str_Textfield3)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r[str_Valuefield].ToString() + "~" + r.Field<string>(str_Textfield1) + "~" + r.Field<string>(str_Textfield2) + "~" + r.Field<string>(str_Textfield3)).ToList();

            return lst_details;
        }
        public static void SendMail1(string strFrom, string strTo, string strSub, string strContent, string strAttachment, string strPassword, string Str_BCC = "", string Str_CC = "")
        {

          

        }




    }
}