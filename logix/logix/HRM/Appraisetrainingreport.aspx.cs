using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using ClosedXML.Excel;

namespace logix.HRM
{
    public partial class Appraisetrainingreport : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.PayrollProcess payobj = new DataAccess.PayrollProcess();
        DataAccess.Payroll.SatuatoryReport payprocobj = new DataAccess.Payroll.SatuatoryReport();

        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Clear);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (!IsPostBack)
            {
                Fn_LoadDivision();

                fnloadyear();
                btn_Clear.ToolTip = "Cancel";
                btn_Clear1.Attributes["class"] = "btn ico-cancel";
            }
        }

        public void Fn_LoadDivision()
        {
            ddl_company.Items.Clear();
            ddl_company.Items.Add("");
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDivisionhrm("HR");
            ddl_company.DataSource = obj_dt;
            ddl_company.DataTextField = "divisionname";
            ddl_company.DataValueField = "divisionid";
            ddl_company.DataBind();
        }
        public void fnloadyear()
        {
            DateTime dt_Date = obj_da_Log.GetDate();
            Session["TodayDate"] = dt_Date;
            int VouYear, Alogyear;
            if (dt_Date.Month < 4)
            {
                Session["Vouyear"] = dt_Date.Year - 1;
                VouYear = dt_Date.Year - 1;
                Alogyear = VouYear;
                Session["Alogyear"] = Alogyear;
                string str_dispyear = "";
                for (int i = 2012; i < dt_Date.Year; i++)
                {
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(2, 2);
                    int dy;
                    string dy1 = "";

                    dy = Convert.ToInt32(str_dispyear) + 1;

                    if (dy < 10)
                    {
                        dy1 = dy1 + "0" + Convert.ToString(dy);
                    }
                    else
                    {
                        dy1 = Convert.ToString(dy);

                    }
                    str_dispyear = str_dispyear + "-" + dy1;
                    Session["str_dispyear"] = str_dispyear;
                    ddl_Appraisalyear.Items.Add(str_dispyear);

                    if (i == VouYear)
                    {
                        ddl_Appraisalyear.Text = str_dispyear;
                        Session["appYEAR"] = ddl_Appraisalyear.Text;
                    }
                }
            }
            else
            {
                Session["Vouyear"] = dt_Date.Year;
                VouYear = dt_Date.Year;
                Alogyear = VouYear;
                Session["Alogyear"] = Alogyear;
                string str_dispyear = "";
                for (int i = 2012; i <= dt_Date.Year; i++)
                {
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(2, 2);
                    int dy;
                    string dy1 = "";

                    dy = Convert.ToInt32(str_dispyear) + 1;

                    if (dy < 10)
                    {
                        dy1 = dy1 + "0" + Convert.ToString(dy);
                    }
                    else
                    {
                        dy1 = Convert.ToString(dy);

                    }
                    str_dispyear = str_dispyear + "-" + dy1;
                    Session["str_dispyear"] = str_dispyear;
                    ddl_Appraisalyear.Items.Add(str_dispyear);

                    if (i == VouYear)
                    {
                        ddl_Appraisalyear.Text = str_dispyear;
                        Session["appYEAR"] = ddl_Appraisalyear.Text;
                    }
                }
            } 
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
           
            Session["AppYearHr"] = ddl_Appraisalyear.SelectedItem.Text;
            Session["HRAppYear"] = "20" + ddl_Appraisalyear.SelectedValue.Substring(0, 2);
            if (ddl_company.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Vessel", "alertify.alert('Select Company');", true);
                ddl_company.Focus();
                return;
            }
            if (ddl_Appraisalyear.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Vessel", "alertify.alert('Select Appraisal Year');", true);
                ddl_company.Focus();
                return;
            }
            dt = payprocobj.GetAppraiseeTraining(Convert.ToInt32(ddl_company.SelectedValue), Convert.ToInt32(Session["HRAppYear"].ToString()));
            Grd_Appraisal.DataSource = dt;
            Grd_Appraisal.DataBind();
            ViewState["dtab"] = dt;

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
            //    DataTable Dt = new DataTable();

            //    DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
            //    string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            //    Session["str_sfs"] = "";
            //    Session["str_sp"] = "";


            //    Str_RptName = "/Payroll/" + "rptHRAttendance.rpt";
            //  //  Session["str_sp"] = "company=" +  + "'" + ddl_From.Text;
            //   // Str_sf = "Month({HRAttendance.attdate})=" + ddl_From.SelectedIndex + "and Year({HRAttendance.attdate})=" + txt_From.Text + "and {MasterEmployee.division}=" + ddl_company.SelectedValue.ToString();
            ////    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
              obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1873, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
            //    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
            //    Session["str_sfs"] = Str_sf;
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            if (btn_Clear.ToolTip == "Cancel")
            {
            
                ddl_company.Items.Clear();
                ddl_Appraisalyear.Items.Clear();
                btn_Clear.ToolTip = "Back";
                btn_Clear1.Attributes["class"] = "btn ico-back";
                Fn_LoadDivision();
                fnloadyear();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            
            DataTable dt_check = ViewState["dtab"] as DataTable;
           // string title = "";
            if (Grd_Appraisal.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt_check);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=AppraiseReport.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }

        protected void logdetails_Click(object sender, EventArgs e)
        {
            try
            {
                loadgridlog();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel3.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1873, "", "", "", "");
            //if (txt_customer.Text != "")
            //{
            //    JobInput.Text = txt_customer.Text;


            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
    }
}