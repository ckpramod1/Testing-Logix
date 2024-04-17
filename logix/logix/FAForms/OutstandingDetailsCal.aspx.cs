using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using DocumentFormat.OpenXml.VariantTypes;
//using DocumentFormat.OpenXml.Drawing.Charts;
using log4net.Repository.Hierarchy;
using logix.CRMNew;
using logix.FAForm;
using logix.ForwardExports;

namespace logix.FAForms
{
    public partial class OutstandingDetailsCal : System.Web.UI.Page
    {
        int Vouyear, LogYear;
        Double amt = 0.0, overdue = 0.0, appamt = 0.0;
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                outsobj.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
               
            }

            try
            {
                //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnClear);
                //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnExpertExcel);

                if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                }

                Vouyear = Convert.ToInt32(Session["Vouyear"].ToString());
                LogYear = Convert.ToInt32(Session["LogYear"].ToString());
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());

                if (!IsPostBack)
                {
                    ViewState["dt1"] = null;

                    GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdLW.DataBind();

                    GrdCal.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdCal.DataBind();

                    if (Request.QueryString.ToString().Contains("todatecal"))
                    {

                        string[] strdt = Request.QueryString["todatecal"].ToString().Split('-');

                        hid_todate.Value = strdt[0];
                        hid_title.Value = strdt[1];

                        btnGet_Click(sender,e);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alter('" + ex.Message.ToString() + "')", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string Str_Script = "";
            //Str_Script = "window.open('../FAForms/OutstandingCalendar.aspx" + this.Page.ClientQueryString + "','','');";
            //ScriptManager.RegisterStartupScript(btnCancel, typeof(Button), "Outstanding", Str_Script, true);

            Response.Redirect("../Home/CorporateHome.aspx");
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (hid_todate.Value == "" || hid_todate.Value == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Date');", true);
                    return;
                }
                DataTable dt = new DataTable();
                int curmon = Convert.ToDateTime(hid_todate.Value).Month;
                int vyear;

                if (curmon < 4)
                {
                    vyear = Convert.ToDateTime(hid_todate.Value).Year - 1;
                }
                else
                {
                    vyear = Convert.ToDateTime(hid_todate.Value).Year;
                }

                dt = outsobj.GetCalenderDetails4PopupGridNew(Convert.ToDateTime(hid_todate.Value), vyear, hid_title.Value);

                if (dt.Rows.Count > 0)
                {
                    DataTable dt1 = new DataTable();
                    dt1 = dt;
                    
                    DataRow dr = dt1.NewRow();

                    dr["Customer"] = "Total";
                    dr["amount"] = dt1.Compute("sum(amount)", "");

                    dt1.Rows.Add(dr);

                    GrdCal.DataSource = dt1;
                    GrdCal.DataBind();
                    ViewState["dt1"] = dt1;
                }
                else
                {
                    GrdCal.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdCal.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdCal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[6].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[6].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[6].Attributes.CssStyle["text-align"] = "Right";
                    }
                    
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;

                }

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
        protected void GrdCal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtmp = new DataTable();
            if (ViewState["dt1"] != null)
            {
                dtmp = (DataTable)ViewState["dt1"];
                if (dtmp.Rows.Count > 0)
                {
                    GrdCal.PageIndex = e.NewPageIndex;
                    GrdCal.DataSource = dtmp;
                    GrdCal.DataBind();
                }
                else
                {
                    GrdCal.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdCal.DataBind();
                }
            }
        }


        protected void btnGet_Click1(object sender, EventArgs e)
        {
            try
            {
                
                if (hid_todate.Value == "" || hid_todate.Value == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Subgroup');", true);                    
                    return;
                }

                DateTime Date = new DateTime();
                DataTable  dt = new DataTable();
                DataView dv = new DataView();
                DataTable dtl = new DataTable();

                //Date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)); //da_obj_Log.GetDate(); 
                Date = Convert.ToDateTime(hid_todate.Value);

                CheckBox ChkTill = new CheckBox();
                ChkTill.Checked = false;

                int Tillyear;
                if (Date.Month <= 3)
                {
                    Tillyear = (Date.Year) - 1;
                }
                else
                {
                    Tillyear = (Date.Year);
                }

                if (Session["LoginBranchName"].ToString() == "CORPORATE")
                {
                    if (ChkTill.Checked == true)
                    {
                        //dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), ledgerid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_todate.Value)));
                        
                    }
                    else
                    {
                        if (hid_todate.Value == Utility.fn_ConvertDate("3/31/" + (LogYear + 1)) || hid_todate.Value != Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()))
                        {
                            ChkTill.Checked = true;
                            dt = outsobj.OutStandingNewLedgerTillDateNew(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 40, Convert.ToDateTime(Utility.fn_ConvertDate(hid_todate.Value)));
                            //dt = outsobj.OutStandingNewLedgerTillDate(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 40, Convert.ToDateTime(Utility.fn_ConvertDate(hid_todate.Value)));
                        }
                        else
                        {
                            dt = outsobj.OutStandingNewLedgerTillDateNew(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 40, Convert.ToDateTime(Utility.fn_ConvertDate(hid_todate.Value)));
                        }
                    }
                }
                else
                {
                    if (ChkTill.Checked == true)
                    {
                        dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 40, Convert.ToDateTime(Utility.fn_ConvertDate(hid_todate.Value)));
                    }
                    else
                    {
                        
                        if (hid_todate.Value == Utility.fn_ConvertDate("3/31/" + (LogYear + 1)) || hid_todate.Value != Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()))
                        {
                            ChkTill.Checked = true;
                            dt = outsobj.OutStandingNewLedgerTillDateNew(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 40, Convert.ToDateTime(hid_todate.Value));
                            //dt = outsobj.OutStandingNewLedgerTillDate(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 40, Convert.ToDateTime(Utility.fn_ConvertDate(hid_todate.Value)));
                        }
                        else
                        {
                            dt = outsobj.OutStandingNewLedgerTillDateNew(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 40, Convert.ToDateTime(hid_todate.Value));
                        }
                    }
                }

                Session["Data"] = dt;
                if (dt.Rows.Count > 0)
                {
                    GrdLW.Enabled = true;                    
                    dv = new DataView(dt);
                    dtl = new DataTable();
                    string[] a = new string[2];
                    a[0] = "shortname";
                    a[1] = "bid";
                    dtl = dv.ToTable("name", true, a);
                    

                    if (Session["LoginBranchName"].ToString() != "CORPORATE")
                    {
                       
                        GrdLW.Enabled = true;
                        //GridFilter();

                        if (GrdLW.Rows.Count > 0)
                        {
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[13].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[14].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[15].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[16].ForeColor = System.Drawing.Color.Maroon;
                        }

                        //return;
                    }
                    amt = 0;
                    overdue = 0;
                    DataTable dt1 = new DataTable();
                    dt1 = dt;
                    double cummm = 0;
                    DataRow dr = dt1.NewRow();

                    dr["curr"] = "Total";
                    dr["amount"] = dt1.Compute("sum(amount)", "");

                    dr["vamount"] = dt1.Compute("sum(vamount)", "");
                    dr["Receivedamount"] = dt1.Compute("sum(Receivedamount)", "");
                    dr["famount"] = dt1.Compute("sum(famount)", "");

                    dr["recefamount"] = dt1.Compute("sum(recefamount)", "");
                    dr["foverdue"] = dt1.Compute("sum(foverdue)", "");
                    dt1.Rows.Add(dr);
                    //GC.Collect();
                    GrdLW.DataSource = dt1;
                    GrdLW.DataBind();
                    //dt1.Dispose();
                    //
                    if (GrdLW.Rows.Count > 0)
                    {
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[13].ForeColor = System.Drawing.Color.Maroon;
                        //double dr1 = 0, cr1 = 0;
                        
                        
                    }
                    else
                    {
                        GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                        GrdLW.DataBind();
                    }

                    ViewState["dt1"] = dt1;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

                //Session["Error"] = lblOutstanding.Text + ex.Message.ToString();
                //Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void GrdLW_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[6].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[6].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[6].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[7].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[7].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[7].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[8].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[8].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[8].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[11].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[11].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[11].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[9].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[9].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[9].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[10].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[10].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[10].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;

                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                if (e.Row.Cells[26].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdLW, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }

            //if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        if (ddlcurency.Text == "ALL")
            //        {
            //            e.Row.Cells[6].Visible = true;
            //            e.Row.Cells[7].Visible = true;
            //            e.Row.Cells[8].Visible = true;
            //            e.Row.Cells[9].Visible = false;
            //            e.Row.Cells[11].Visible = false;
            //            e.Row.Cells[10].Visible = false;
            //        }
            //        else
            //        {
            //            e.Row.Cells[6].Visible = false;
            //            e.Row.Cells[7].Visible = false;
            //            e.Row.Cells[8].Visible = false;
            //            e.Row.Cells[9].Visible = true;
            //            e.Row.Cells[11].Visible = true;
            //            e.Row.Cells[10].Visible = true;
            //        }


            //        e.Row.Cells[4].Visible = false;
            //    }
            //}
        }

        protected void GrdLW_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtmp = new DataTable();
            if (ViewState["dt1"] != null)
            {
                dtmp = (DataTable)ViewState["dt1"];
                if (dtmp.Rows.Count > 0)
                {
                    GrdLW.PageIndex = e.NewPageIndex;
                    GrdLW.DataSource = dtmp;
                    GrdLW.DataBind();

                }
                else
                {
                    GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdLW.DataBind();
                }

            }
        }

    }
}