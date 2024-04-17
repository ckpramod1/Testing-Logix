using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using System.Xml;
using System.Text;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;

namespace logix.HRM
{
    public partial class ProcessITComput : System.Web.UI.Page
    {
        DataAccess.Payroll.Details PayRolllDet = new DataAccess.Payroll.Details();
        DataAccess.Payroll.ITComputation PayRollITComp = new DataAccess.Payroll.ITComputation();
        DataAccess.PAYROLL.RentDetailss PayRollRent = new DataAccess.PAYROLL.RentDetailss();
        DataAccess.PayrollProcess PayRoll = new DataAccess.PayrollProcess();
        DataAccess.LogDetails LogDet = new DataAccess.LogDetails();

        DataTable dt_EmpDet = new DataTable();
        DataTable dt_Emp = new DataTable(); 
        DateTime dtDate;
        int CurMonth, CurYear, PreMonth, PreYear, PreMonth1, PreYear1, GetMonth, Fin_Year, DispYear;
        string Month1, Month2, Month3;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Btn_Excel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Btn_Back);

            if (!IsPostBack)
            {
                CurMonth = LogDet.GetDate().Month;
                CurYear = LogDet.GetDate().Year;

                Month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CurMonth);
                Month2 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CurMonth - 1);
                Month3 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CurMonth - 2);              
           
                if (CurMonth == 4)
                {
                    DispYear = CurYear;
                }
                else if (CurYear < 4)
                {
                    DispYear = CurYear - 1;
                }
                else
                {
                    DispYear = CurYear;
                }

                Fin_Year = DispYear;

                if (Fin_Year < CurYear)
                {
                    if (CurMonth >= 4)
                    {
                        CurMonth = 3;
                        CurYear = Fin_Year + 1;
                        GetMonth = 3;
                        dtDate = Convert.ToDateTime(GetMonth + "/05/" + CurYear).Date;
                    }
                    else
                    {
                        CurMonth = LogDet.GetDate().Month;
                        CurYear = LogDet.GetDate().Year;
                        GetMonth = CurMonth;
                        dtDate = Convert.ToDateTime(GetMonth + "/05/" + CurYear).Date;
                    }
                }
                else
                {
                    CurMonth = LogDet.GetDate().Month;
                    CurYear = LogDet.GetDate().Year;
                    GetMonth = CurMonth;
                    dtDate = Convert.ToDateTime(GetMonth + "/05/" + CurYear).Date;
                }

                PayRoll.SpRunpfforinvest();
                dt_EmpDet = PayRoll.spgetempdet();

                Session["EmpDet"] = dt_EmpDet;
                Session["TransferType"] = 2;
                Session["CurMonth"] = CurMonth;
                Session["CurYear"] = CurYear;
                Session["GetMontth"] = GetMonth;
                Session["Fin_Year"] = Fin_Year;
                Session["dtDate"] = dtDate;

                if (Session["Wrk"] == null)
                {
                    Response.Redirect("../HRM/ITComputation.aspx", true);
                }
                else
                {                    
                    FillGrid();                    
                }
            }
        }

        protected void FillGrid()
        {
            if (CurMonth == 2)
            {
                PreMonth = CurMonth - 1;
                PreMonth1 = 12;
                PreYear = CurYear;
                PreYear1 = CurYear - 1;
            }
            else if (CurMonth == 1)
            {
                PreMonth = 12;
                PreMonth1 = 11;
                PreYear = CurYear - 1;
                PreYear1 = CurYear - 1;
            }
            else
            {
                PreMonth = CurMonth - 1;
                PreMonth1 = CurMonth - 2;
                PreYear = CurYear;
                PreYear1 = CurYear;
            }
            
            DataTable dtGrid = new DataTable();
            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Company");
            dt.Columns.Add(Month3 + "-" + PreYear1, typeof(decimal));
            dt.Columns.Add(Month2 + "-" + PreYear, typeof(decimal));
            dt.Columns.Add(Month1 + "-" + CurYear, typeof(decimal));

            dtGrid = PayRollITComp.GetProcessITcompare(CurMonth, CurYear);

            if (dtGrid.Rows.Count > 0)
            {
                for (int j = 0; j <= dtGrid.Rows.Count - 1; j++)
                {
                    dr = dt.NewRow();
                    dr[0] = dtGrid.Rows[j]["username"].ToString();
                    dr[1] = dtGrid.Rows[j]["empname"].ToString();
                    dr[2] = dtGrid.Rows[j]["company"].ToString();
                    dr[3] = decimal.Parse(dtGrid.Rows[j][3].ToString().Replace(".0000", ".00"));
                    dr[4] = decimal.Parse(dtGrid.Rows[j][4].ToString().Replace(".0000", ".00"));
                    dr[5] = decimal.Parse(dtGrid.Rows[j][5].ToString().Replace(".0000", ".00"));
                    dt.Rows.Add(dr);
                }
            }

            GV_ProcessIT.DataSource = dt;
            GV_ProcessIT.PageIndex = 0;
            ViewState["ITData"] = dt;
            GV_ProcessIT.DataBind();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Updated...!')", true);
        }                  

        protected void GV_ProcessIT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_ProcessIT.PageIndex = e.NewPageIndex;
            DataTable dtBind = new DataTable();
            dtBind = (DataTable)ViewState["ITData"];
            GV_ProcessIT.DataSource = dtBind;
            GV_ProcessIT.DataBind();            
        }

        protected void Btn_Excel_Click(object sender, EventArgs e)
        {            
            DataTable dtExcel = new DataTable();
            dtExcel = (DataTable)ViewState["ITData"];

            if (dtExcel.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Process IT Computation.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";

                StringBuilder SB = new StringBuilder();
                StringWriter SW = new StringWriter(SB);
                HtmlTextWriter HW = new HtmlTextWriter(SW);
                GridView GVExcel = new GridView();

                SB.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                SB.Append("<tr><td></td><td align='center' font face=arial size=2><b><bold>Process IT Computation</bold></b></td></tr>");
                SB.Append("<tr><td></td><td></td></tr>");
                SB.Append("</table>");
                                              
                GVExcel.AllowPaging = false;
                GVExcel.DataSource = dtExcel;
                GVExcel.DataBind();
                GVExcel.RenderControl(HW);
                Response.Output.Write(SW.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Records Found...!')", true);
            }              
        }
        
        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            GV_ProcessIT.DataSource = new DataTable();
            GV_ProcessIT.DataBind();
            this.Response.End();            
        }

        protected void GV_ProcessIT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Width = 50;
                e.Row.Cells[1].Width = 150;
                e.Row.Cells[2].Width = 60;
                e.Row.Cells[3].Width = 100;
                e.Row.Cells[4].Width = 100;
                e.Row.Cells[5].Width = 100;

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }
        }
    }
        
}