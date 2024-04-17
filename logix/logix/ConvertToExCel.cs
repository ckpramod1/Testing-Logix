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
using System.IO;
namespace logix
{
    public class ConvertToExCel
    {
        public static DataTable dtTemp;
        public static string strFile, strData;

        public enum ConversionType
        {
            Excel,
            Word,
            Text,
            XML
        }
        public static ConversionType ctObject;
        public ConvertToExCel()
        {
        }

        public static void ConverData(Page pageResponse, DataTable dtTemp, string strFileName, ConversionType ctTempType)
        {
            string sep = "";
            pageResponse.Response.Clear();
            pageResponse.Response.ClearContent();
            pageResponse.Response.ClearHeaders();
            pageResponse.Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
            pageResponse.Response.ContentType = "application/vnd.ms-excel";
            switch (ctTempType)
            {
                case ConversionType.Excel:
                    sep = ",";
                    break;
                default:
                    sep = "\t";
                    break;
            }

            foreach (DataColumn dc in dtTemp.Columns)
            {
                pageResponse.Response.Write(dc.ColumnName.ToUpper() + sep);
            }
            pageResponse.Response.Write(Environment.NewLine);
            int i;
            foreach (DataRow dr in dtTemp.Rows)
            {
                for (i = 0; i < dtTemp.Columns.Count; i++)
                {
                    pageResponse.Response.Write(dr[i].ToString() + sep);
                }
                pageResponse.Response.Write(Environment.NewLine);
            }
        }
        public static void ConverData(Page pageResponse, string strSource, string strFileName)
        {
            pageResponse.Response.Clear();
            pageResponse.Response.ClearContent();
            pageResponse.Response.ClearHeaders();
            pageResponse.Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);

            string[] strTempArray = strSource.Split('~');
            if (strTempArray.Length != 0)
            {
                for (int z = 0; z < strTempArray.Length; z++)
                {
                    pageResponse.Response.Output.WriteLine(strTempArray[z]);
                }
            }
        }
        public static void SetData(DataTable dtSource, string strFileName, ConversionType cTypeObj)
        {
            strFile = strFileName;
            ctObject = cTypeObj;
            dtTemp = new DataTable();
            dtTemp = dtSource;
        }
        public static void SetData(string strSrc, string strFileName, ConversionType cTypeObj)
        {
            strFile = strFileName;
            ctObject = cTypeObj;
            strData = strSrc;
        }
        public static string GetFileName()
        {
            return strFile;
        }
        public static DataTable GetDtblData()
        {
            return dtTemp;
        }
        public static string GetStringData()
        {
            return strData;
        }
        public static ConversionType GetConversionType()
        {
            return ctObject;
        }
        public static DataTable ConvertGridToDtbl(GridView grdTemp, int[] intTempArray)
        {
            DataTable dtGrid = new DataTable();
            for (int x = 0; x < intTempArray.Length; x++)
            {
                DataColumn dcTemp = new DataColumn(grdTemp.Columns[intTempArray[x]].HeaderText.ToUpper());
                dtGrid.Columns.Add(dcTemp);
            }
            for (int y = 0; y < grdTemp.Rows.Count; y++)
            {
                DataRow drw = dtGrid.NewRow();
                for (int z = 0; z < intTempArray.Length; z++)
                {
                    drw[z] = grdTemp.Rows[y].Cells[intTempArray[z]].Text.ToUpper();
                    drw[z] = drw[z].ToString().Replace("&NBSP;", "");
                    drw[z] = drw[z].ToString().Replace(",", " ");
                    drw[z] = drw[z].ToString().Replace("&AMP;", "&");
                    drw[z] = drw[z].ToString().Replace("&amp;", "&");
                }
                dtGrid.Rows.Add(drw);
            }
            return dtGrid;
        }
        public static DataTable ConvertGridToDtbl_FE(GridView grdTemp, int[] intTempArray)
        {
            DataTable dtGrid = new DataTable();
            for (int x = 0; x < intTempArray.Length; x++)
            {
                DataColumn dcTemp = new DataColumn(grdTemp.Columns[intTempArray[x]].HeaderText.ToUpper());
                dtGrid.Columns.Add(dcTemp);
            }
            DataTable dt = (DataTable)HttpContext.Current.Session["FEData"];
            for (int y = 0; y < dt.Rows.Count; y++)
            {
                DataRow drw = dtGrid.NewRow();
                for (int z = 0; z < intTempArray.Length; z++)
                {
                    drw[z] = dt.Rows[y][intTempArray[z]].ToString().ToUpper();
                    drw[z] = drw[z].ToString().Replace("&NBSP;", "");
                    drw[z] = drw[z].ToString().Replace(",", " ");
                }
                dtGrid.Rows.Add(drw);
            }
            return dtGrid;
        }
    }
}