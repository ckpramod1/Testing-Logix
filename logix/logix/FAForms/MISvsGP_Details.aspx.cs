using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Bibliography;
using System.IO;
using Quartz;
using System.Text;

namespace logix.FAForms
{
    public partial class MISvsGP_Details : System.Web.UI.Page
    {
        string frmdate, todate;
        double ieamount ;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Grd_MisDetails);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_MainHeader.Text = Request.QueryString["FormName"].ToString();
            }
            if (Request.QueryString.ToString().Contains("IEType"))
            {
                lbl_MainHeader.Text = Request.QueryString["IEType"].ToString();
                frmdate = Request.QueryString["frmdate"].ToString();
                todate = Request.QueryString["todate"].ToString();
                ieamount = Convert.ToDouble(Request.QueryString["Amount"].ToString());
            }

            if (!IsPostBack)
            {
                Grd_MisDetails.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_MisDetails.DataBind();

                lbnl_logyear.Text = Session["LYEAR"].ToString();
                Fn_GetMISGPDetails();
            }
        }

        private void Fn_GetMISGPDetails()
        {
            try
            {
                DataAccess.FAVoucher objvou = new DataAccess.FAVoucher();
                DataSet ds = new DataSet();
                DataSet dsbk = new DataSet();
                DataTable dt3 = new DataTable();
                ViewState["DSBreakUps"] = null;

                double netamt = 0.00;
                int r = 0;


                if (Session["chkgp"].ToString() == "false")
                {
                    return;
                }


                if (lbl_MainHeader.Text == "DIRECT INCOME")
                {
                    ds = objvou.MyUseMISvsDirectIncomeDetails(Convert.ToDateTime(Utility.fn_ConvertDate(frmdate)), Convert.ToDateTime(Utility.fn_ConvertDate(todate)), Session["FADbname"].ToString(), 0, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    dsbk = objvou.MyUseMISvsDirectIncomeDetailsBreakUp(Convert.ToDateTime(Utility.fn_ConvertDate(frmdate)), Convert.ToDateTime(Utility.fn_ConvertDate(todate)), Session["FADbname"].ToString(), 0, Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    ViewState["DSBreakUps"] = dsbk;

                    if (ds.Tables.Count > 0)
                    {
                        dt3.Columns.Add("ctype", typeof(string));
                        dt3.Columns.Add("amount", typeof(double));
                        dt3.Columns.Add("net", typeof(double));

                        dt3.Rows.Add();
                        dt3.Rows[0]["ctype"] = lbl_MainHeader.Text + " as per Balance";
                        dt3.Rows[0]["amount"] = 0.00;
                        netamt = netamt + ieamount;
                        dt3.Rows[0]["net"] = Math.Abs(netamt);
                        dt3.Rows.Add();

                        r = dt3.Rows.Count - 1;

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 1; i <= ds.Tables[1].Rows.Count - 1; i++)
                            {
                                dt3.Rows.Add();
                                if (Convert.ToDouble(ds.Tables[1].Rows[i]["amount"]) > 0)
                                {
                                    dt3.Rows[r]["ctype"] = "[+] " + ds.Tables[1].Rows[i]["ctype"];
                                }
                                else
                                {
                                    dt3.Rows[r]["ctype"] = "[-] " + ds.Tables[1].Rows[i]["ctype"];
                                }
                                dt3.Rows[r]["amount"] = Math.Abs(Convert.ToDouble(ds.Tables[1].Rows[i]["amount"]));
                                netamt = netamt + Convert.ToDouble(ds.Tables[1].Rows[i]["amount"]);
                                dt3.Rows[r]["net"] = Math.Abs(netamt);
                                r = r + 1;
                            }
                        }

                        r = dt3.Rows.Count;


                        for (int i = 0; i <= ds.Tables[2].Rows.Count - 1; i++)
                        {
                            //DataRow dr3 = dt3.NewRow();
                            dt3.Rows.Add();
                            if (Convert.ToDouble(ds.Tables[2].Rows[i]["amount"]) > 0)
                            {
                                dt3.Rows[r]["ctype"] = "[+] " + ds.Tables[2].Rows[i]["ctype"];
                            }
                            else
                            {
                                dt3.Rows[r]["ctype"] = "[-] " + ds.Tables[2].Rows[i]["ctype"];
                            }
                            //dt3.Rows[i]["ctype"] =  ds.Tables[2].Rows[i]["ctype"];
                            dt3.Rows[r]["amount"] = Math.Abs(Convert.ToDouble(ds.Tables[2].Rows[i]["amount"]));
                            netamt = netamt + Convert.ToDouble(ds.Tables[2].Rows[i]["amount"]);
                            dt3.Rows[r]["net"] = Math.Abs(netamt);
                            r = r + 1;
                        }
                        r = dt3.Rows.Count + 1;

                        dt3.Rows.Add();
                        dt3.Rows.Add();
                        dt3.Rows[r]["ctype"] = "MIS Income as per Details";
                        dt3.Rows[r]["amount"] = "0.00";
                        //netamt = netamt + Convert.ToDouble(ds.Tables[4].Rows[0]["amount"]);
                        dt3.Rows[r]["net"] = Math.Abs(Convert.ToDouble(ds.Tables[4].Rows[0]["misincome"]));

                        r = dt3.Rows.Count + 1;


                        dt3.Rows.Add();
                        dt3.Rows.Add();
                        dt3.Rows[r]["ctype"] = "Diff";
                        dt3.Rows[r]["amount"] = "0.00";
                        netamt = netamt - Convert.ToDouble(ds.Tables[4].Rows[0]["misincome"]);
                        dt3.Rows[r]["net"] = Math.Abs(netamt);

                    }
                }
                else if (lbl_MainHeader.Text == "DIRECT EXPENSES")
                {
                    ds = objvou.MyUseMISvsDirectExpenseDetails(Convert.ToDateTime(Utility.fn_ConvertDate(frmdate)), Convert.ToDateTime(Utility.fn_ConvertDate(todate)), Session["FADbname"].ToString(), 0, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    dsbk = objvou.MyUseMISvsDirectExpenseDetailsBreakup(Convert.ToDateTime(Utility.fn_ConvertDate(frmdate)), Convert.ToDateTime(Utility.fn_ConvertDate(todate)), Session["FADbname"].ToString(), 0, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    
                    ViewState["DSBreakUps"] = dsbk;

                    if (ds.Tables.Count > 0)
                    {
                        dt3.Columns.Add("ctype", typeof(string));
                        dt3.Columns.Add("amount", typeof(double));
                        dt3.Columns.Add("net", typeof(double));

                        dt3.Rows.Add();
                        dt3.Rows[0]["ctype"] = lbl_MainHeader.Text + " as per Balance";
                        dt3.Rows[0]["amount"] = 0.00;
                        netamt = netamt + ieamount;
                        dt3.Rows[0]["net"] = Math.Abs(netamt);
                        dt3.Rows.Add();

                        r = dt3.Rows.Count - 1;

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 1; i <= ds.Tables[1].Rows.Count - 1; i++)
                            {
                                dt3.Rows.Add();
                                if (Convert.ToDouble(ds.Tables[1].Rows[i]["amount"]) > 0)
                                {
                                    dt3.Rows[r]["ctype"] = "[+] " + ds.Tables[1].Rows[i]["ctype"];
                                }
                                else
                                {
                                    dt3.Rows[r]["ctype"] = "[-] " + ds.Tables[1].Rows[i]["ctype"];
                                }
                                dt3.Rows[r]["amount"] = Math.Abs(Convert.ToDouble(ds.Tables[1].Rows[i]["amount"]));
                                netamt = netamt + Convert.ToDouble(ds.Tables[1].Rows[i]["amount"]);
                                dt3.Rows[r]["net"] = Math.Abs(netamt);
                                r = r + 1;
                            }
                        }

                        r = dt3.Rows.Count;


                        for (int i = 0; i <= ds.Tables[2].Rows.Count - 1; i++)
                        {
                            //DataRow dr3 = dt3.NewRow();
                            dt3.Rows.Add();
                            if (Convert.ToDouble(ds.Tables[2].Rows[i]["amount"]) > 0)
                            {
                                dt3.Rows[r]["ctype"] = "[+] " + ds.Tables[2].Rows[i]["ctype"];
                            }
                            else
                            {
                                dt3.Rows[r]["ctype"] = "[-] " + ds.Tables[2].Rows[i]["ctype"];
                            }
                            //dt3.Rows[i]["ctype"] =  ds.Tables[2].Rows[i]["ctype"];
                            dt3.Rows[r]["amount"] = Math.Abs(Convert.ToDouble(ds.Tables[2].Rows[i]["amount"]));
                            netamt = netamt + Convert.ToDouble(ds.Tables[2].Rows[i]["amount"]);
                            dt3.Rows[r]["net"] = Math.Abs(netamt);
                            r = r + 1;
                        }
                        r = dt3.Rows.Count + 1;

                        dt3.Rows.Add();
                        dt3.Rows.Add();
                        dt3.Rows[r]["ctype"] = "[-] " + ds.Tables[3].Rows[0]["ctype"];                        
                        dt3.Rows[r]["amount"] = Convert.ToDouble(ds.Tables[3].Rows[0]["amount"]);
                        netamt = netamt - Convert.ToDouble(ds.Tables[3].Rows[0]["amount"]);
                        dt3.Rows[r]["net"] = Math.Abs(netamt);


                        r = dt3.Rows.Count + 1;


                        dt3.Rows.Add();
                        dt3.Rows.Add();
                        dt3.Rows[r]["ctype"] = "MIS Expense as per Details";
                        dt3.Rows[r]["amount"] = "0.00";
                        //netamt = netamt + Convert.ToDouble(ds.Tables[4].Rows[0]["amount"]);
                        dt3.Rows[r]["net"] = Math.Abs(Convert.ToDouble(ds.Tables[5].Rows[0]["misexpense"]));

                        r = dt3.Rows.Count + 1;


                        dt3.Rows.Add();
                        dt3.Rows.Add();
                        dt3.Rows[r]["ctype"] = "Diff";
                        dt3.Rows[r]["amount"] = "0.00";
                        netamt = netamt - Convert.ToDouble(ds.Tables[5].Rows[0]["misexpense"]);
                        dt3.Rows[r]["net"] = Math.Abs(netamt);

                    }
                }

                    
                if (dt3.Rows.Count > 0)
                {
                    Grd_MisDetails.DataSource = dt3;
                    Grd_MisDetails.DataBind();
                }

                

            }
            catch(Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void logdetails_Click(object sender, EventArgs e)
        {

        }

        protected void Grd_MisDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Grd_MisDetails.SelectedRow.RowIndex;
            string ctype = Grd_MisDetails.Rows[index].Cells[0].Text;
            DataTable dtjob = new DataTable();

            DataSet dtbk1 = new DataSet();
            if (ViewState["DSBreakUps"] != null)
            {
                dtbk1 = ViewState["DSBreakUps"] as DataSet;
            }

            if (lbl_MainHeader.Text == "DIRECT INCOME")
            {

                if (dtbk1.Tables.Count > 0)
                {
                    if (ctype.Contains("job closed in given period but vouchers raised in previous") && !ctype.Contains("-cn"))
                    {
                        dtjob = dtbk1.Tables[3];
                        ViewState["JobFileName"] = "PrevJobVoucher";
                    }
                    else if (ctype.Contains("job closed in given period but vouchers raised in previous") && ctype.Contains("-cn"))
                    {
                        dtjob = dtbk1.Tables[4];
                        ViewState["JobFileName"] = "PrevJobVoucherCN";
                    }
                    else if (ctype.Contains("Unclosed") && !ctype.Contains("-cn"))
                    {
                        dtjob = dtbk1.Tables[6];
                        ViewState["JobFileName"] = "UnclosedJob";
                    }
                    else if (ctype.Contains("Unclosed") && ctype.Contains("-cn"))
                    {
                        dtjob = dtbk1.Tables[7];
                        ViewState["JobFileName"] = "UnclosedCN";
                    }
                    else if (ctype.Contains("job closed after given period but vouchers raise in given period after") && !ctype.Contains("-cn"))
                    {
                        dtjob = dtbk1.Tables[9];
                        ViewState["JobFileName"] = "AfterJobVoucher";
                    }
                    else if (ctype.Contains("job closed after given period but vouchers raise in given period after") && ctype.Contains("-cn"))
                    {
                        dtjob = dtbk1.Tables[10];
                        ViewState["JobFileName"] = "AfterJobVoucherCN";
                    }

                }
            }
            else if (lbl_MainHeader.Text == "DIRECT EXPENSES")
            {

                if (dtbk1.Tables.Count > 0)
                {
                    if (ctype.Contains("job closed in given period but vouchers raised in previous") && !ctype.Contains("-cn"))
                    {
                        dtjob = dtbk1.Tables[3];
                        ViewState["JobFileName"] = "PrevJobVoucher";
                    }
                    else if (ctype.Contains("job closed in given period but vouchers raised in previous") && ctype.Contains("-dn"))
                    {
                        dtjob = dtbk1.Tables[4];
                        ViewState["JobFileName"] = "PrevJobVoucherDN";
                    }
                    else if (ctype.Contains("Unclosed") && !ctype.Contains("-dn"))
                    {
                        dtjob = dtbk1.Tables[6];
                        ViewState["JobFileName"] = "UnclosedJob";
                    }
                    else if (ctype.Contains("Unclosed") && ctype.Contains("-dn"))
                    {
                        dtjob = dtbk1.Tables[7];
                        ViewState["JobFileName"] = "UnclosedDN";
                    }
                    else if (ctype.Contains("job closed after given period but vouchers raise in given period after") && !ctype.Contains("-dn"))
                    {
                        dtjob = dtbk1.Tables[9];
                        ViewState["JobFileName"] = "AfterJobVoucher";
                    }
                    else if (ctype.Contains("job closed after given period but vouchers raise in given period after") && ctype.Contains("-dn"))
                    {
                        dtjob = dtbk1.Tables[10];
                        ViewState["JobFileName"] = "AfterJobVoucherDN";
                    }

                    else if (ctype.Contains("Vouchers Not in TDS"))
                    {
                        dtjob = dtbk1.Tables[12];
                        ViewState["JobFileName"] = "VouNotInTDS";
                    }

                }
            }

            DownloadExcel(dtjob);

        }

        public void DownloadExcel(DataTable dtjob)
        {
            if(dtjob.Rows.Count > 0)
            {
                DataRow dr = dtjob.NewRow();
                dtjob.Rows.Add(dr);
                dr[4] = "Total";
                dr[5] = dtjob.Compute("sum(Amount)", "");

                //GridView grdjob = new GridView();
                grdjob.DataSource = dtjob;
                grdjob.DataBind();

                if (dtjob.Rows.Count > 0)
                {

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=" + ViewState["JobFileName"].ToString() + ".xls");
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.Charset = "";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    GridView gv = new GridView();
                    gv.DataSource = dtjob;
                    gv.DataBind();
                    gv.RenderControl(htw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();

                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment;filename=" + ViewState["JobFileName"].ToString() + ".xls");
                    //Response.Charset = "";
                    //Response.ContentType = "application/vnd.xls";
                    //System.IO.StringWriter StringWriter = new System.IO.StringWriter();
                    //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                    //grdjob.GridLines = GridLines.Both;
                    //grdjob.HeaderStyle.Font.Bold = true;
                    //grdjob.RenderControl(HtmlTextWriter);
                    //Response.Write(StringWriter.ToString());
                    //Response.End();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Data Not Found')", true);
            }


            //if (grd_profit.Visible == true)
            //{
            //    string strtemp = "";
            //    strtemp = Utility.Fn_ExportExcel(grd_profit, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
            //    Response.Clear();
            //    Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
            //    Response.Buffer = true;
            //    Response.Charset = "UTF-8";
            //    Response.ContentType = "application/vnd.ms-excel";
            //    Response.Write(strtemp);
            //    Response.End();
            //}

        }

        protected void Grd_MisDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0.00" || e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_MisDetails, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdjob_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0.00" || e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_MisDetails, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            if (Grd_MisDetails.Visible == true && Grd_MisDetails.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + lbl_MainHeader.Text + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                Grd_MisDetails.GridLines = GridLines.Both;
                Grd_MisDetails.HeaderStyle.Font.Bold = true;
                Grd_MisDetails.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }


        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/profitandLoss.aspx");
        }


    }
}


