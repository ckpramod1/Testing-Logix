using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Office;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

namespace logix
{
    public class GrdToExcel
    {
        public string strTemp, StrHead, StrSubHead;
        object oMissing;
        System.Data.DataTable DtTemp;
        //GridView grdTemp;
        Microsoft.Office.Interop.Excel.Application appobj;
        Worksheet wsObj;
        Workbooks wbsObj;
        Workbook wbObj;
        Sheets shtsObj;
        Range rObj;
        int i, j, x;

        //Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        //Excel.Workbooks xlBooks = new Microsoft.Office.Interop.Excel.Workbooks();
        //Excel.Workbook xlBook = new Microsoft.Office.Interop.Excel.Workbook();

        public GrdToExcel()
        {
            //
            // TODO: Add constructor logic here
            //
            //Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wbObj.ActiveSheet;
            //ws.Cells[1, 1] = "Testing";
            //Microsoft.Office.Interop.Excel.Range range = ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 2]);
            //range.Merge(true);

        }

        public void ConvertExcel(System.Data.DataTable DtTemp)
        {
            oMissing = System.Reflection.Missing.Value;

            if (DtTemp.Rows.Count > 0)
            {
                appobj = new Microsoft.Office.Interop.Excel.Application();
                wbsObj = appobj.Workbooks;
                wbObj = wbsObj.Add(XlWBATemplate.xlWBATWorksheet);
                shtsObj = wbObj.Sheets;

                rObj = (Range)shtsObj.Application.Cells[1, 4];
                rObj.Font.Bold = true;
                rObj.Value2 = StrHead;

                if (StrSubHead == "")
                {
                    for (x = 0; x < DtTemp.Rows.Count; x++)
                    {
                        rObj = (Range)shtsObj.Application.Cells[3, x + 2]; rObj.Font.Bold = true;
                        rObj.Value2 = DtTemp.Columns[x].ColumnName;
                    }

                    for (i = 0; i < DtTemp.Rows.Count; i++)
                    {
                        for (j = 0; j < DtTemp.Columns.Count; j++)
                        {
                            rObj = (Range)shtsObj.Application.Cells[i + 4, j + 2];
                            if (DtTemp.Rows[i][j].ToString() != "")
                            { rObj.Value2 = DtTemp.Rows[i][j].ToString(); }
                        }
                    }

                }
                else
                {
                    rObj = (Range)shtsObj.Application.Cells[3, 4];
                    rObj.Font.Bold = true; rObj.Value2 = StrSubHead;

                    for (x = 0; x < DtTemp.Columns.Count; x++)
                    {
                        rObj = (Range)shtsObj.Application.Cells[5, x + 2]; rObj.Font.Bold = true;
                        rObj.Value2 = DtTemp.Columns[x].ColumnName;
                    }

                    for (i = 0; i < DtTemp.Rows.Count; i++)
                    {
                        for (j = 0; j < DtTemp.Columns.Count; j++)
                        {
                            rObj = (Range)shtsObj.Application.Cells[i + 6, j + 2];
                            if (DtTemp.Rows[i][j].ToString() != "")
                                rObj.Value2 = DtTemp.Rows[i][j].ToString();
                        }
                    }
                }
                wbObj.Close(1, "Revenue", oMissing);
                wbsObj.Close();
                appobj = null;
            }
            StrSubHead = "";
        }

        public void ConvertToOpenOffice()
        {
            oMissing = System.Reflection.Missing.Value;

            if (DtTemp.Rows.Count > 0)
            {
                appobj = new Microsoft.Office.Interop.Excel.Application();
                wbsObj = appobj.Workbooks;
                wbObj = wbsObj.Add(XlWBATemplate.xlWBATWorksheet);
                shtsObj = wbObj.Sheets;

                rObj = (Range)shtsObj.Application.Cells[1, 6];
                rObj.Value2 = "Warehouse";

                for (x = 0; x < DtTemp.Columns.Count; x++)
                {
                    rObj = (Range)shtsObj.Application.Cells[2, x + 1];
                    rObj.Value2 = DtTemp.Columns[x].ColumnName;
                }

                for (i = 0; i < DtTemp.Rows.Count; i++)
                {
                    for (j = 0; j < DtTemp.Columns.Count; j++)
                    {
                        rObj = (Range)shtsObj.Application.Cells[i + 3, j + 1];
                        if (DtTemp.Rows[i][j].ToString() != "")
                            rObj.Value2 = DtTemp.Rows[i][j].ToString();
                    }
                }

                wbObj.Close(1, "Revenue", oMissing);
                wbsObj.Close();
                appobj = null;
            }
        }
    }
}
