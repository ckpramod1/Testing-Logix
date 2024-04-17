using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace logix
{
    public class Global
    {
        public static String Src = "";
        public static string SCRIPT_DOFOCUS = @"window.setTimeout('DoFocus()', 1);
            function DoFocus()
            {
                try {
                    document.getElementById('REQUEST_LASTFOCUS').focus();
                } catch (ex) {}
            }";

        //Employee empObj = new Employee();
        //DataAccess.Masters.MasterPort portObj = new DataAccess.Masters.MasterPort();

        public static void HookOnFocus(Control CurrentControl)
        {
            //checks if control is one of TextBox, DropDownList, ListBox or Button
            if ((CurrentControl is TextBox) ||
                (CurrentControl is DropDownList) ||
                (CurrentControl is ListBox) ||
                (CurrentControl is Button))
                //adds a script which saves active control on receiving focus in the hidden field __LASTFOCUS.
                (CurrentControl as WebControl).Attributes.Add("onfocus", "try{document.getElementById('__LASTFOCUS').value=this.id} catch(e) {}");
            //checks if the control has children
            if (CurrentControl.HasControls())
                //if yes do them all recursively
                foreach (Control CurrentChildControl in CurrentControl.Controls)
                    HookOnFocus(CurrentChildControl);
        }

        //public string CurDBName(string strDivision, string strBranch)
        //{
        //    string strResult = "";
        //    strResult ="FA" + empObj.GetBranchId(empObj.GetDivisionId(strDivision), strBranch).ToString();
        //    return strResult;
        //}

        public string SetTranTypeFullName(string strTranType)
        {
            string strTempResult = "";
            switch (strTranType)
            {
                case "FE":
                    strTempResult = "Freight Forward Export";
                    break;
                case "FI":
                    strTempResult = "Freight Forward Import";
                    break;
                case "AE":
                    strTempResult = "Air Export";
                    break;
                case "AI":
                    strTempResult = "Air Import";
                    break;
                case "CH":
                    strTempResult = "Custom House Agent";
                    break;
                case "HR":
                    strTempResult = "Human Resource Management";
                    break;
                case "CR":
                    strTempResult = "Customer Relation Management";
                    break;
                case "UT":
                    strTempResult = "Utility & Tools";
                    break;
                case "AC":
                    strTempResult = "Accounts";
                    break;
            }
            return strTempResult;
        }

        public string RemoveAMP(string strSrc)
        {
            string strResult = "";
            strResult = strSrc.Replace("&amp;", "&");
            if (strResult.IndexOf("&amp;") != -1)
                RemoveAMP(strSrc);
            return strResult;
        }
        //public string GetCustLocation(TypeAhead t)
        //{
        //    string strTemp = "";
        //    strTemp = t.GetCaptureValue(t.ID);       
        //    return strTemp;
        //}

        public string GetSubString(string strSrc, int intStart, int intNoChar)
        {
            string strResult = "";

            strSrc = strSrc.Trim();

            if (strSrc.Length > intStart + intNoChar)
            {
                strResult = strSrc.Substring(intStart, intNoChar);
            }
            else
            {
                strResult = strSrc.Substring(intStart, strSrc.Length - intStart);
            }
            return strResult.Trim();
        }

        public string CheckExist(int[] intSrc, string[] strMsg)
        {
            string strResult = "";
            for (int i = 0; i < intSrc.Length; i++)
            {
                if (intSrc[i] == 0)
                {
                    strResult = strMsg[i];
                    break;
                }
            }
            return strResult;
        }
        public void Scroll(GridView Grd, Panel pnl, int intWidth, int intHeight)
        {
            if (Grd.Rows.Count != 0)
            {
                pnl.Visible = true;
                if (Grd.Rows.Count >= 20)
                {
                    pnl.Height = intHeight + 40;
                    pnl.Width = intWidth;
                    pnl.ScrollBars = ScrollBars.Auto;
                }
                else
                {
                    pnl.Width = intWidth;
                    pnl.Height = Grd.Rows.Count * 23 + 40;
                    pnl.ScrollBars = ScrollBars.Auto;
                }
            }
            else
            {
                pnl.Visible = false;
            }
        }

        public String GetDouble(double dblSrc)
        {
            string strTemp = dblSrc.ToString().Trim();
            string strResult = "";
            int intPosition = strTemp.IndexOf('.');
            if (strTemp.Length > intPosition + 3)
            {
                strResult = strTemp.Substring(0, intPosition + 3);
            }
            else
            {
                strResult = strTemp;
            }
            return strResult;
        }
    }
}