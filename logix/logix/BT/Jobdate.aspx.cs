using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;

namespace logix.BT
{
    public partial class Jobdate : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.CostingDetails CostObj = new DataAccess.CostingDetails();
        string StrTranType = "";
        int empid = 0, intBranchID = 0, intDivID = 0, netret = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            StrTranType = Session["StrTranType"].ToString();
            intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if(!IsPostBack)
            {
                if (Session["From"] != null)
                {
                    txt_from.Text = Session["From"].ToString();
                    txt_to.Text = Session["To"].ToString();
                    fn_MIS();
                    return;
                }
                txt_from.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_to.Text = txt_from.Text;
                Grd_MISA.DataSource = new DataTable();
                Grd_MISA.DataBind();
                Grd_MISC.DataSource = new DataTable();
                Grd_MISC.DataBind();
                Grd_MISB.DataSource = new DataTable();
                Grd_MISB.DataBind();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if(btn_cancel.Text=="Cancel")
            {
                txt_from.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_to.Text = txt_from.Text;
                Grd_MISA.DataSource = new DataTable();
                Grd_MISA.DataBind();
                Grd_MISC.DataSource = new DataTable();
                Grd_MISC.DataBind();
                Grd_MISB.DataSource = new DataTable();
                Grd_MISB.DataBind();
                btn_cancel.Text = "Back";
            }
            else if (btn_cancel.Text == "Back")
            {
                if (Session["From"] != null)
                {
                    Response.Redirect("../MIS/MISBT.aspx", true);
                }
                this.Response.End();
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            string str_fromdate = Utility.fn_ConvertDate(txt_from.Text);
            string str_todate = Utility.fn_ConvertDate(txt_to.Text);
            DateTime frm_date, to_date;
            frm_date = Convert.ToDateTime(str_fromdate);
            to_date = Convert.ToDateTime(str_todate);
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";
            if(StrTranType=="FE")
            {
                fn_MIS();
                str_RptName = "FEJobopendate.rpt";
                str_sf = "{FEJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {FEJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {FEJobinfo.etd}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {FEJobinfo.etd}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {FEJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened And Sailed/Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "FEJobopendate.rpt";
                str_sf = "{FEJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {FEJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {FEJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {FEJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened but not Sailed/ Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "FEJobopendate.rpt";
                str_sf = "{FEJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {FEJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {FEJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {FEJobinfo.bid}=" + intBranchID + " and {FEJobinfo.closedjob}=true";
                str_sp = "Header=Job Opened  Sailed/ Arrived and Closed during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
            }else if(StrTranType=="FI")
            {
                fn_MIS();
                str_RptName = "FIJobopendate.rpt";
                str_sf = "{FIJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {FIJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {FIJobinfo.etd}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {FIJobinfo.etd}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {FIJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened And Sailed/Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "FIJobopendate.rpt";
                str_sf = "{FIJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {FIJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {FIJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {FIJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened but not Sailed/ Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "FIJobopendate.rpt";
                str_sf = "{FIJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {FIJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {FIJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {FIJobinfo.bid}=" + intBranchID + " and {FIJobinfo.closedjob}=true";
                str_sp = "Header=Job Opened  Sailed/ Arrived and Closed during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
            }
            else if (StrTranType == "AE")
            {
                fn_MIS();
                str_RptName = "AEJobopendate.rpt";
                str_sf = "{AEJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {AEJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {AEJobinfo.etd}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {AEJobinfo.etd}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {AEJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened And Sailed/Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "AEJobopendate.rpt";
                str_sf = "{AEJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {AEJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {AEJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {AEJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened but not Sailed/ Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "AEJobopendate.rpt";
                str_sf = "{AEJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {AEJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {AEJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {AEJobinfo.bid}=" + intBranchID + " and {AEJobinfo.closedjob}=true";
                str_sp = "Header=Job Opened  Sailed/ Arrived and Closed during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
            }
            else if (StrTranType == "AI")
            {
                fn_MIS();
                str_RptName = "AIJobopendate.rpt";
                str_sf = "{AIJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {AIJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {AIJobinfo.etd}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {AIJobinfo.etd}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {AIJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened And Sailed/Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "AIJobopendate.rpt";
                str_sf = "{AIJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {AIJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {AIJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {AIJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened but not Sailed/ Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "AIJobopendate.rpt";
                str_sf = "{AIJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {AIJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {AIJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {AIJobinfo.bid}=" + intBranchID + " and {AIJobinfo.closedjob}=true";
                str_sp = "Header=Job Opened  Sailed/ Arrived and Closed during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
            }
            else if (StrTranType == "CH")
            {
                fn_MIS();
                str_RptName = "CHJobopendate.rpt";
                str_sf = "{CHJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {CHJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {CHJobinfo.etd}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {CHJobinfo.etd}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "') and {CHJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened And Sailed/Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "CHJobopendate.rpt";
                str_sf = "{CHJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {CHJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {CHJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {CHJobinfo.bid}=" + intBranchID;
                str_sp = "Header=Job Opened but not Sailed/ Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "CHJobopendate.rpt";
                str_sf = "{CHJobinfo.jobdate}>=date('" + frm_date.Year + "," + frm_date.Month + "," + frm_date.Day + "') and {CHJobinfo.jobdate}<=date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')  and {CHJobinfo.etd}>date('" + to_date.Year + "," + to_date.Month + "," + to_date.Day + "')and {CHJobinfo.bid}=" + intBranchID + " and {CHJobinfo.closedjob}=true";
                str_sp = "Header=Job Opened  Sailed/ Arrived and Closed during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
            }
            else if (StrTranType == "AC")
            {
                fn_MIS();
                string flag = "A", flag1 = "B", flag2 = "C";
                str_RptName = "JobdateAC.rpt";
                str_sf = "{tmpMISJob.flag}='" + flag + "'  and {tmpMISJob.empid}>=" + empid;
                str_sp = "Header=Job Opened And Sailed/Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "JobdateAC.rpt";
                str_sf = "{tmpMISJob.flag}='" + flag1 + "'  and {tmpMISJob.empid}>=" + empid;
                str_sp = "Header=Job Opened but not Sailed/ Arrived during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_RptName = "JobdateAC.rpt";
                str_sf = "{tmpMISJob.flag}='" + flag2 + "'  and {tmpMISJob.empid}>=" + empid;
                str_sp = "Header=Job Opened  Sailed/ Arrived and Closed during the given date Range";
                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
            }
        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            fn_MIS();
        }

        private void fn_MIS()
        {
            try
            {
                string str_fromdate = Utility.fn_ConvertDate(txt_from.Text);
                string str_todate = Utility.fn_ConvertDate(txt_to.Text);
                DateTime frm_date, to_date;
                frm_date = Convert.ToDateTime(str_fromdate);
                to_date = Convert.ToDateTime(str_todate);
                
               
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                DataTable obj_dt_MISA = new DataTable();
                DataTable obj_dt_MISB = new DataTable();
                DataTable obj_dt_MISC = new DataTable();
                DataTable obj_dt_MISD = new DataTable();

                
                    Pln_MIS.Visible = true;
                    
                    int i;
                    double MIS_A, MIS_B, MIS_C, MIS_D;
                    MIS_A = 0;
                    MIS_B = 0;
                    MIS_C = 0;
                    MIS_D = 0;
                    obj_dt = CostObj.SELMISJobDateandvessel(StrTranType, intBranchID, frm_date, to_date, empid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        //obj_dt.DefaultView.Sort = "jobno";
                        
                        
                        lbl_MISA.Visible = true;
                        Grd_MISA.Visible = true;
                        Grd_MISA.DataSource = obj_dt;
                        Grd_MISA.DataBind();
                    }
                    else
                    {
                        Grd_MISA.Visible = true;
                        Grd_MISA.DataSource = new DataTable();
                        Grd_MISA.DataBind();
                    }
                    obj_dt_MISB = CostObj.SELMISJobDateandvesselnotsailed(StrTranType, intBranchID, frm_date, to_date, empid);
                    if (obj_dt_MISB.Rows.Count > 0)
                    {
                        //obj_dt_MISB.DefaultView.Sort = "jobno";
                        
                        lbl_MISC.Visible = true;
                        Grd_MISC.Visible = true;
                        Grd_MISC.DataSource = obj_dt_MISB;
                        Grd_MISC.DataBind();
                    }
                    else
                    {
                        Grd_MISC.Visible = true;
                        Grd_MISC.DataSource = new DataTable();
                        Grd_MISC.DataBind();
                    }
                    obj_dt_MISC = CostObj.SELMISJobDateandvesselsailed(StrTranType, intBranchID, frm_date, to_date, empid);
                    if (obj_dt_MISC.Rows.Count > 0)
                    {
                        //obj_dt_MISC.DefaultView.Sort = "jobno";

                        
                        lbl_MISB.Visible = true;
                        Grd_MISB.Visible = true;
                        Grd_MISB.DataSource = obj_dt_MISC;
                        Grd_MISB.DataBind();
                    }
                    else
                    {
                        Grd_MISB.Visible = true;
                        Grd_MISB.DataSource = new DataTable();
                        Grd_MISB.DataBind();
                    }
                    //netret = Convert.ToInt32(String.Format("{0:0.00}", ((MIS_A + MIS_B) - Math.Abs(MIS_C + MIS_D))));               
                    btn_cancel.Text = "Cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
    }
}