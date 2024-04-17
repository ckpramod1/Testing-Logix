using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.FAForm
{
    public partial class Statistics : System.Web.UI.Page
    {
        int branchid;
        string fadbname;
        int voutypeid;
        int selvoutypeid;
        string strmonth;
        int vmonth;
        int logyear;
        string voutypename;
        int index4reg;
        char osvouchertype;
        DataAccess.FAMaster.ReportView FARepobj = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DateTime fdate;
        DateTime tDate;
        DataTable dttemp = new DataTable();

        DataTable dttempm = new DataTable();
        Boolean fg, fgm, fgr, fgv, flagvou = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnexcel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FARepobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);




            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://marinair.copperhawk.tech/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lblheader.Text = Request.QueryString["FormName"].ToString();
            }

            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            fadbname = (Session["FADbname"].ToString());
            logyear = Convert.ToInt32(Session["LogYear"].ToString());

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                if (Request.QueryString.ToString().Contains("flagvou"))
                {
                    flagvou = Convert.ToBoolean(Request.QueryString["flagvou"].ToString());
                    hidvoutypeid.Value = Request.QueryString["vid"].ToString();
                    hidfdate.Value = Request.QueryString["fdate"].ToString();
                    hidtdate.Value = Request.QueryString["tdate"].ToString();
                    hidvoutype.Value = Request.QueryString["vtype"].ToString();

                    if (flagvou == true)
                    {
                        fillreg();
                    }
                }
                else
                {
                    grid();
                }
            }
        }

        public void grid()
        {
            DataTable dt = new DataTable();
            dt = FARepobj.FAselStatisticsvoucher(branchid, fadbname);

            DataTable dttemp = new DataTable();
            dttemp.Columns.Add("voutypename");
            dttemp.Columns.Add("total");
            dttemp.Columns.Add("cancelled");
            dttemp.Columns.Add("voutypeid");

            if ((dt.Rows.Count > 0))
            {
                for (int i = 0; i <= (dt.Rows.Count - 1); i++)
                {
                    voutypeid = Convert.ToInt32(dt.Rows[i]["voutype"].ToString());
                    Voucher();

                    dttemp.Rows.Add();
                    dttemp.Rows[i]["voutypename"] = dt.Rows[i]["voutypename"].ToString(); ;
                    dttemp.Rows[i]["total"] = dt.Rows[i]["total"].ToString();
                    dttemp.Rows[i]["cancelled"] = dt.Rows[i]["cancelled"].ToString();
                    dttemp.Rows[i]["voutypeid"] = voutypeid;
                }
                grd.DataSource = dttemp;
                grd.DataBind();
                Session["dttemp"] = dttemp;
                fg = true;
            }
        }

        [WebMethod]
        public static void getdetails()
        {
            DataTable dtgrd = new DataTable();
            HttpContext.Current.Session["grd"] = HttpContext.Current.Session["dttemp"];
            HttpContext.Current.Session["grdmonth"] = HttpContext.Current.Session["dttempm"];
            HttpContext.Current.Session["grdreg"] = HttpContext.Current.Session["dttempr"];
        }

        public void Voucher()
        {
            if ((voutypeid == 1))
            {
                voutypename = "Invoice";
            }
            else if ((voutypeid == 2))
            {
                voutypename = "Credit Note - Operations";
            }
            else if ((voutypeid == 3))
            {
                voutypename = "Admin Purchase Invoice";
            }
            else if ((voutypeid == 4))
            {
                voutypename = "Admin Sales Invoice";
            }
            else if ((voutypeid == 5))
            {
                voutypename = "OSSI";
            }
            else if ((voutypeid == 6))
            {
                voutypename = "OSPI";
            }
            else if ((voutypeid == 7))
            {
                voutypename = "Debit Note - Others";
            }
            else if ((voutypeid == 8))
            {
                voutypename = "Credit Note - Others";
            }
            else if ((voutypeid == 9))
            {
                voutypename = "Bank Receipt";
            }
            else if ((voutypeid == 10))
            {
                voutypename = "Cash Receipt";
            }
            else if ((voutypeid == 11))
            {
                voutypename = "Bank Payment";
            }
            else if ((voutypeid == 12))
            {
                voutypename = "Cash Payment";
            }
            else if ((voutypeid == 13))
            {
                voutypename = "Journal";
            }
            else if ((voutypeid == 14))
            {
                voutypename = "Contra";
            }
            else if ((voutypeid == 15))
            {
                voutypename = "Receipt - Petty Cash";
            }
            else if ((voutypeid == 35))
            {
                voutypename = "Manual Invoices";
            }
            else if ((voutypeid == 36))
            {
                voutypename = "Manual PaymentAdvises";
            }
            else if ((voutypeid == 37))
            {
                voutypename = "Manual OSDN";
            }
            else if ((voutypeid == 38))
            {
                voutypename = "Manual OSCN";
            }
            else if ((voutypeid == 39))
            {
                voutypename = "Manual Debit Note - Others";
            }
            else if ((voutypeid == 40))
            {
                voutypename = "Manual Credit Note - Others";
            }
            else if ((voutypeid == 41))
            {
                voutypename = "Manual Bank Receipt";
            }
            else if ((voutypeid == 42))
            {
                voutypename = "Manual Cash Receipt";
            }
            else if ((voutypeid == 43))
            {
                voutypename = "Manual Bank Payment";
            }
            else if ((voutypeid == 44))
            {
                voutypename = "Manual Cash Payment";
            }
            else if ((voutypeid == 45))
            {
                voutypename = "Manual Contra";
            }
            else if ((voutypeid == 101))
            {
                voutypename = "OSDNCNJV";
            }
            else if ((voutypeid == 1102))
            {
                voutypename = "BDJV";
            }
            else if ((voutypeid == 103))
            {
                voutypename = "BPJV";
            }
            else if ((voutypeid == 104))
            {
                voutypename = "BRRJV";
            }
            else if ((voutypeid == 105))
            {
                voutypename = "BPRJV";
            }
            else if ((voutypeid == 16))
            {
                voutypename = "Remittance-Receipt";
            }
            else if ((voutypeid == 17))
            {
                voutypename = "Remittance-Payment";
            }
            else if ((voutypeid == 19))
            {
                voutypename = "Adjustment DCN";
            }
            else if ((voutypeid == 106))
            {
                voutypename = "BRG";
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                }

                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }


        public void getmonth()
        {
            if ((vmonth == 4))
            {
                strmonth = "April";
            }
            else if ((vmonth == 5))
            {
                strmonth = "May";
            }
            else if ((vmonth == 6))
            {
                strmonth = "June";
            }
            else if ((vmonth == 7))
            {
                strmonth = "July";
            }
            else if ((vmonth == 8))
            {
                strmonth = "August";
            }
            else if ((vmonth == 9))
            {
                strmonth = "September";
            }
            else if ((vmonth == 10))
            {
                strmonth = "October";
            }
            else if ((vmonth == 11))
            {
                strmonth = "November";
            }
            else if ((vmonth == 12))
            {
                strmonth = "December";
            }
            else if ((vmonth == 1))
            {
                strmonth = "January";
            }
            else if ((vmonth == 2))
            {
                strmonth = "February";
            }
            else if ((vmonth == 3))
            {
                strmonth = "March";
            }
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowindex;

            rowindex = grd.SelectedRow.RowIndex;
            index4reg = grd.SelectedRow.RowIndex;
            selvoutypeid = Convert.ToInt32(grd.DataKeys[rowindex].Values[0].ToString());
            hidvoutypeid.Value = selvoutypeid.ToString();
            hidvoutype.Value = grd.Rows[index4reg].Cells[0].Text;
            gridmonth();
        }

        public void gridmonth()
        {
            DataTable dtm = new DataTable();
            dtm = FARepobj.FAselStatisticsvouchermonth(branchid, Convert.ToInt32(hidvoutypeid.Value), fadbname);

            DataTable dttempm = new DataTable();
            dttempm.Columns.Add("strmonth");
            dttempm.Columns.Add("total");
            dttempm.Columns.Add("cancelled");
            dttempm.Columns.Add("vmonth");

            if ((dtm.Rows.Count > 0))
            {
                for (int i = 0; i <= (dtm.Rows.Count - 1); i++)
                {
                    vmonth = Convert.ToInt32(dtm.Rows[i]["tmonth"].ToString());
                    getmonth();
                    dttempm.Rows.Add();
                    dttempm.Rows[i]["strmonth"] = strmonth;
                    dttempm.Rows[i]["total"] = dtm.Rows[i]["total"].ToString();
                    dttempm.Rows[i]["cancelled"] = dtm.Rows[i]["cancelled"].ToString();
                    dttempm.Rows[i]["vmonth"] = vmonth;
                }

                grd.Visible = false;
                fg = false;
                grdmonth.Visible = true;
                fgm = true;
                grdmonth.DataSource = dttempm;
                grdmonth.DataBind();
                Session["dttempm"] = dttempm;
            }
        }

        protected void grdmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdmonth.Rows.Count > 0)
            {
                int index = 0;
                int vmthid, yearcurr;
                index = grdmonth.SelectedRow.RowIndex;
                vmthid = Convert.ToInt32(grdmonth.DataKeys[index].Values[0].ToString());

                if ((vmthid == 1) || (vmthid == 2) || (vmthid == 3))
                {
                    yearcurr = logyear + 1;
                }

                else
                {
                    yearcurr = logyear;
                }

                if ((vmthid == 4) || (vmthid == 6) || (vmthid == 9) || (vmthid == 11))
                {
                    fdate = Convert.ToDateTime(vmthid.ToString() + "/01/" + yearcurr.ToString());
                    tDate = Convert.ToDateTime(vmthid.ToString() + "/30/" + yearcurr.ToString());
                }
                else if ((vmthid == 5) || (vmthid == 7) || (vmthid == 8) || (vmthid == 10) || (vmthid == 12) || (vmthid == 1) || (vmthid == 3))
                {
                    fdate = Convert.ToDateTime(vmthid.ToString() + "/01/" + yearcurr.ToString());
                    tDate = Convert.ToDateTime(vmthid.ToString() + "/31/" + yearcurr.ToString());
                }
                else
                {
                    if (((yearcurr / 4) == 0))
                    {
                        tDate = Convert.ToDateTime(vmthid.ToString() + "/29/" + yearcurr.ToString());
                    }
                    else
                    {
                        tDate = Convert.ToDateTime(vmthid.ToString() + "/28/" + yearcurr.ToString());
                    }
                }

                fdate = Convert.ToDateTime(vmthid.ToString() + "/01/" + yearcurr.ToString());
                hidfdate.Value = fdate.ToString();
                hidtdate.Value = tDate.ToString();

                fillreg();
            }
        }

        protected void grdmonth_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdmonth, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                }

                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        public void fillreg()
        {

            grd.Visible = false;
            grdmonth.Visible = false;
            fgm = false;
            voutypeid = Convert.ToInt32(hidvoutypeid.Value);
            Voucher();

            DataTable dtdet;
            DataTable dttempr = new DataTable();

            fdate = Convert.ToDateTime(hidfdate.Value);
            tDate = Convert.ToDateTime(hidtdate.Value);
            dtdet = FARepobj.FAselStatisticsReg(voutypeid, branchid, fdate, tDate, fadbname);

            dttempr.Columns.Add("voudate");
            dttempr.Columns.Add("vouno");
            dttempr.Columns.Add("customername");
            dttempr.Columns.Add("ledgeramount");
            dttempr.Columns.Add("status");
            dttempr.Columns.Add("PBid");
            dttempr.Columns.Add("osvtype");
            dttempr.Columns.Add("grdvouno");

            if (dtdet.Rows.Count > 0)
            {
                for (int i = 0; i <= dtdet.Rows.Count - 1; i++)
                {
                    dttempr.Rows.Add();
                    dttempr.Rows[i]["voudate"] = dtdet.Rows[i]["voudate"].ToString();
                    dttempr.Rows[i]["grdvouno"] = dtdet.Rows[i]["vouno"].ToString();
                    dttempr.Rows[i]["customername"] = dtdet.Rows[i]["customername"].ToString();
                    dttempr.Rows[i]["ledgeramount"] = dtdet.Rows[i]["ledgeramount"].ToString();
                    dttempr.Rows[i]["status"] = dtdet.Rows[i]["status"].ToString();

                    if (!DBNull.Value.Equals(dtdet.Rows[i]["osvtype"]))
                    {
                        osvouchertype = Convert.ToChar(dtdet.Rows[i]["osvtype"].ToString());
                        dttempr.Rows[i]["osvtype"] = osvouchertype;
                        dttempr.Rows[i]["vouno"] = osvouchertype + "-" + dtdet.Rows[i]["vouno"].ToString();
                    }
                    else
                    {
                        dttempr.Rows[i]["vouno"] = dtdet.Rows[i]["vouno"].ToString();
                    }
                    dttempr.Rows[i]["PBid"] = dtdet.Rows[i]["pbid"].ToString();
                }

                GRDREG.Visible = true;
                fgr = true;
                GRDREG.DataSource = dttempr;
                GRDREG.DataBind();
                Session["dttempr"] = dttempr;
            }
        }

        protected void GRDREG_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GRDREG, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                }

                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        //protected void GRDREG_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string voutype;
        //    int vouNo;
        //    int index, Pbid;
        //    Boolean flag = false;

        //    if (GRDREG.Rows.Count > 0)
        //    {
        //        fgr = false;
        //        fgv = true;
        //        index = GRDREG.SelectedRow.RowIndex;
        //        voutype = hidvoutype.Value;

        //        vouNo = Convert.ToInt32(GRDREG.DataKeys[index].Values[1].ToString());
        //        Pbid = Convert.ToInt32(GRDREG.DataKeys[index].Values[0].ToString());

        //        if ((GRDREG.DataKeys[index].Values[2].ToString() != null) && (GRDREG.DataKeys[index].Values[2].ToString() != ""))
        //        {
        //            osvouchertype = Convert.ToChar(GRDREG.DataKeys[index].Values[2].ToString());
        //        }

        //        string gblvname = "";

        //        if (voutype != "")
        //        {
        //            if (voutype == "Invoice")
        //            {
        //                gblvname = "Invoices";
        //                flag = true;
        //            }
        //            else if (voutype == "Credit Note - Operations")
        //            {
        //                gblvname = "Credit Note - Operations";
        //                flag = true;
        //            }
        //            else if ((voutype == "OSSI") || (voutype == "OS DN"))
        //            {
        //                gblvname = "OSSI";
        //                flag = true;
        //            }
        //            else if ((voutype == "OSPI") || (voutype == "OS CN"))
        //            {
        //                gblvname = "OSSI";
        //                flag = true;
        //            }
        //            else if ((voutype == "Debit Note - Others"))
        //            {
        //                gblvname = "Debit Note - Others";
        //                flag = true;
        //            }
        //            else if ((voutype == "Credit Note - Others"))
        //            {
        //                gblvname = "Credit Note - Others";
        //                flag = true;
        //            }
        //            else if ((voutype == "Extentions"))
        //            {
        //                gblvname = "Extentions";
        //                flag = true;
        //            }
        //            else if ((voutype == "Proforma Invoices"))
        //            {
        //                gblvname = "Proforma Invoices";
        //                flag = true;
        //            }
        //            else if ((voutype == "FinalBills"))
        //            {
        //                gblvname = "FinalBills";
        //                flag = true;
        //            }
        //            else if ((voutype == "OSDNCNJV"))
        //            {
        //                gblvname = "OSDNCNJV";
        //                flag = true;
        //            }

        //            if (flag == true)
        //            {
        //                string FrmName = "Statistics_Voucher";
        //                //Response.Redirect("../FAForms/Voucher.aspx?type=" + voutype + "&FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&OsvType=" + osvouchertype + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName);
        //                if (Session["LoginBranchid"].ToString() == "66")
        //                {
        //                    iframecost.Attributes["src"] = "../FAForms/Invoice.aspx?INV=" + vouNo + "&bid=" + 66 + "&FormName=" + "Invoice" + "&trantype=" + "LT" + "&uiid=" + 1813;
        //                    ModalPopupExtender1.Show();
        //                }else
        //                {
        //                    iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?type=" + voutype + "&FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&OsvType=" + osvouchertype + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName;
        //                    ModalPopupExtender1.Show();
        //                }
                        
        //            }
        //            return;
        //        }

        //        if (voutype != "")
        //        {
        //            if (voutype == "Bank Receipt")
        //            {
        //                gblvname = "Bank Receipt";
        //                flag = true;
        //            }
        //            else if (voutype == "Cash Receipt")
        //            {
        //                gblvname = "Cash Receipt";
        //                flag = true;
        //            }
        //            else if ((voutype == "Bank Payment"))
        //            {
        //                gblvname = "Bank Payment";
        //                flag = true;
        //            }
        //            else if ((voutype == "Cash Payment"))
        //            {
        //                gblvname = "Cash Payment";
        //                flag = true;
        //            }
        //            else if ((voutype == "BDJV"))
        //            {
        //                gblvname = "BDJV";
        //                flag = true;
        //            }
        //            else if ((voutype == "BPJV"))
        //            {
        //                gblvname = "BPJV";
        //                flag = true;
        //            }
        //            else if ((voutype == "Receipt - Petty Cash"))
        //            {
        //                gblvname = "Receipt - Petty Cash";
        //                flag = true;
        //            }
        //            else if ((voutype == "Remittance-Receipt"))
        //            {
        //                gblvname = "Remittance-Receipt";
        //                flag = true;
        //            }
        //            else if ((voutype == "Remittance-Payment"))
        //            {
        //                gblvname = "Remittance-Payment";
        //                flag = true;
        //            }
        //            else if ((voutype == "BRG"))
        //            {
        //                gblvname = "BRG";
        //                flag = true;
        //            }

        //            if (flag == true)
        //            {
        //                string FrmName = "Statistics_FAReceipt";
        //                //Response.Redirect("../FAForms/FAReceipt.aspx?type=" + voutype + "&FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName);

        //                iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?type=" + voutype + "&FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName;
        //                ModalPopupExtender1.Show();
        //            }
        //            return;
        //        }

        //        if (voutype != "")
        //        {
        //            if (voutype == "Admin Sales Invoice")
        //            {
        //                gblvname = "Admin Sales Invoice";
        //                flag = true;
        //            }
        //            else if (voutype == "Admin Purchase Invoice")
        //            {
        //                gblvname = "Admin Purchase Invoice";
        //                flag = true;
        //            }

        //            if (flag == true)
        //            {
        //                string FrmName = "Statistics_PAAdmin";
        //                //Response.Redirect("../FAForms/PAAdmin.aspx?type=" + voutype + "&QueryVoucherName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&QueryVoucherNo=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName);

        //                iframecost.Attributes["src"] = "../FAForms/PAAdmin.aspx?type=" + voutype + "&QueryVoucherName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&QueryVoucherNo=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName;
        //                ModalPopupExtender1.Show();
        //            }
        //            return;
        //        }

        //        if (voutype == "Contra")
        //        {
        //            flag = true;
        //            gblvname = "Contra";
        //            string FrmName = "Statistics_Contra";
        //            //Response.Redirect("../FAForms/Contra.aspx?Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&flag=" + flag + "&Str_Name=" + FrmName);

        //            iframecost.Attributes["src"] = "../FAForms/Contra.aspx?Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&flag=" + flag + "&Str_Name=" + FrmName;
        //            ModalPopupExtender1.Show();
        //        }

        //        if (voutype == "Journal")
        //        {
        //            flag = true;
        //            gblvname = "Journal";
        //            string FrmName = "Statistics_Journal";
        //            iframecost.Attributes["src"] = "../FAForms/Journal.aspx?FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&Vdate=" + GRDREG.Rows[index].Cells[0].Text + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&Str_Name=" + FrmName;
        //            ModalPopupExtender1.Show();

        //            //Response.Redirect("../FAForms/Journal.aspx?FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&Vdate=" + GRDREG.Rows[index].Cells[0].Text + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&Str_Name=" + FrmName);
        //        }

        //        if (voutype == "Adjustment DCN")
        //        {
        //            flag = true;
        //            string FrmName = "Statistics_AdjustmenrtDNCN";
        //            //Response.Redirect("../FAForms/AdjustmenrtDNCN.aspx?FormName=CN" + gblvname + "&Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&flag=" + flag + "&Str_Name=" + FrmName);

        //            iframecost.Attributes["src"] = "../FAForms/AdjustmenrtDNCN.aspx?FormName=CN" + gblvname + "&Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&flag=" + flag + "&Str_Name=" + FrmName;
        //            ModalPopupExtender1.Show();
        //        }
        //    }
        //}

        protected void GRDREG_SelectedIndexChanged(object sender, EventArgs e)
        {
            string voutype;
            int vouNo;
            int index, Pbid;
            Boolean flag = false;

            if (GRDREG.Rows.Count > 0)
            {
                fgr = false;
                fgv = true;
                index = GRDREG.SelectedRow.RowIndex;
                voutype = hidvoutype.Value;

                vouNo = Convert.ToInt32(GRDREG.DataKeys[index].Values[1].ToString());
                Pbid = Convert.ToInt32(GRDREG.DataKeys[index].Values[0].ToString());

                if ((GRDREG.DataKeys[index].Values[2].ToString() != null) && (GRDREG.DataKeys[index].Values[2].ToString() != ""))
                {
                    osvouchertype = Convert.ToChar(GRDREG.DataKeys[index].Values[2].ToString());

                }
                else
                {
                    osvouchertype = ' ';
                }

                string gblvname = "";

                if ((voutype == "Invoice" || voutype == "Sales Invoice") || (voutype == "Purchase Invoice" || voutype == "Credit Note - Operations") || (voutype == "OSSI") || (voutype == "OS DN") || (voutype == "OSPI") || (voutype == "OS CN") || (voutype == "Debit Note - Others") || (voutype == "Credit Note - Others") || (voutype == "Extentions") || (voutype == "Proforma Invoices") || (voutype == "FinalBills") || (voutype == "OSDNCNJV"))
                {
                    if (voutype == "Invoice" || voutype == "Sales Invoice")
                    {
                        gblvname = "Invoices";
                        flag = true;
                    }
                    else if (voutype == "Credit Note - Operations" || voutype == "Purchase Invoice")
                    {
                        gblvname = "Credit Note - Operations";
                        flag = true;
                    }
                    else if ((voutype == "OSSI") || (voutype == "OS DN"))
                    {
                        gblvname = "OSSI";
                        flag = true;
                    }
                    else if ((voutype == "OSPI") || (voutype == "OS CN"))
                    {
                        gblvname = "OSSI";
                        flag = true;
                    }
                    else if ((voutype == "Debit Note - Others"))
                    {
                        gblvname = "Debit Note - Others";
                        flag = true;
                    }
                    else if ((voutype == "Credit Note - Others"))
                    {
                        gblvname = "Credit Note - Others";
                        flag = true;
                    }
                    else if ((voutype == "Extentions"))
                    {
                        gblvname = "Extentions";
                        flag = true;
                    }
                    else if ((voutype == "Proforma Invoices"))
                    {
                        gblvname = "Proforma Invoices";
                        flag = true;
                    }
                    else if ((voutype == "FinalBills"))
                    {
                        gblvname = "FinalBills";
                        flag = true;
                    }
                    else if ((voutype == "OSDNCNJV"))
                    {
                        gblvname = "OSDNCNJV";
                        flag = true;
                    }

                    if (flag == true)
                    {
                        string FrmName = "Statistics_Voucher";
                        //Response.Redirect("../FAForms/Voucher.aspx?type=" + voutype + "&FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&OsvType=" + osvouchertype + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName);
                        if (Session["LoginBranchid"].ToString() == "66" && (voutype == "Invoice"))
                        {
                            iframecost.Attributes["src"] = "../FAForms/Invoice.aspx?INV=" + vouNo + "&bid=" + 66 + "&FormName=" + "Invoice" + "&trantype=" + "LT" + "&uiid=" + 1813;
                            ModalPopupExtender1.Show();
                        }
                        else
                        {

                            if (hidvoutypeid.Value == "5" || hidvoutypeid.Value == "6")
                            {
                                iframecost.Attributes["src"] = "../Accounts/OSVouchers.aspx?FAvouTYPE=" + hidvoutypeid.Value + "&vouno=" + vouNo + "&PBranch_ID=" + Session["LoginBranchid"].ToString();
                            }
                            //iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?type=" + voutype + "&FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&OsvType=" + osvouchertype + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName;
                            else
                            {
                                iframecost.Attributes["src"] = "../Accounts/ApprovedLV.aspx?FAvouTYPE=" + hidvoutypeid.Value + "&vouno=" + vouNo;
                            }
                            ModalPopupExtender1.Show();
                        }

                    }
                    return;
                }

                if ((voutype == "BRRJV") || (voutype == "BPRJV") || voutype == "Bank Receipt" || voutype == "Cash Receipt" || (voutype == "Bank Payment") || (voutype == "Cash Payment") || (voutype == "BDJV") || (voutype == "BPJV") || (voutype == "Receipt - Petty Cash") || (voutype == "Remittance-Receipt") || (voutype == "Remittance-Payment") || (voutype == "BRG"))
                {
                    if (voutype == "Bank Receipt")
                    {
                        gblvname = "Bank Receipt";
                        flag = true;
                    }
                    else if (voutype == "Cash Receipt")
                    {
                        gblvname = "Cash Receipt";
                        flag = true;
                    }
                    else if ((voutype == "Bank Payment"))
                    {
                        gblvname = "Bank Payment";
                        flag = true;
                    }
                    else if ((voutype == "Cash Payment"))
                    {
                        gblvname = "Cash Payment";
                        flag = true;
                    }
                    else if ((voutype == "BDJV"))
                    {
                        gblvname = "BDJV";
                        flag = true;
                    }
                    else if ((voutype == "BPJV"))
                    {
                        gblvname = "BPJV";
                        flag = true;
                    }
                    else if ((voutype == "Receipt - Petty Cash"))
                    {
                        gblvname = "Receipt - Petty Cash";
                        flag = true;
                    }
                    else if ((voutype == "Remittance-Receipt"))
                    {
                        gblvname = "Remittance-Receipt";
                        flag = true;
                    }
                    else if ((voutype == "Remittance-Payment"))
                    {
                        gblvname = "Remittance-Payment";
                        flag = true;
                    }
                    else if ((voutype == "BRG"))
                    {
                        gblvname = "BRG";
                        flag = true;
                    }
                    else if ((voutype == "BPRJV"))
                    {
                        gblvname = "BPRJV";
                        flag = true;
                    }
                    else if ((voutype == "BRRJV"))
                    {
                        gblvname = "BRRJV";
                        flag = true;
                    }
                    if (flag == true)
                    {
                        string FrmName = "Statistics_FAReceipt";
                        //Response.Redirect("../FAForms/FAReceipt.aspx?type=" + voutype + "&FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName);

                        iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?type=" + voutype + "&FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Session["LoginBranchid"].ToString() + "&Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName;
                        ModalPopupExtender1.Show();
                    }
                    return;
                }

                if (voutype == "Admin Sales Invoice" || voutype == "Admin Purchase Invoice")
                {
                    if (voutype == "Admin Sales Invoice")
                    {
                        gblvname = "Admin Sales Invoice";
                        flag = true;
                    }
                    else if (voutype == "Admin Purchase Invoice")
                    {
                        gblvname = "Admin Purchase Invoice";
                        flag = true;
                    }

                    if (flag == true)
                    {
                        string FrmName = "Statistics_PAAdmin";
                        //Response.Redirect("../FAForms/PAAdmin.aspx?type=" + voutype + "&QueryVoucherName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&QueryVoucherNo=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName);

                        ///iframecost.Attributes["src"] = "../FAForms/AdminvouchersRPT.aspx?type=" + voutype + "&QueryVoucherName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&QueryVoucherNo=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&Str_Name=" + FrmName;
                        iframecost.Attributes["src"] = "../FAForms/ApprovedAdminDCNvouchers.aspx?type=" + gblvname + "&VNo=" + vouNo + "&PBranch_ID=" + Session["LoginBranchid"].ToString();
                        ModalPopupExtender1.Show();
                    }
                    return;
                }

                if (voutype == "Contra")
                {
                    flag = true;
                    gblvname = "Contra";
                    string FrmName = "Statistics_Contra";
                    //Response.Redirect("../FAForms/Contra.aspx?Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&flag=" + flag + "&Str_Name=" + FrmName);

                    iframecost.Attributes["src"] = "../FAForms/Contra.aspx?Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&flag=" + flag + "&Str_Name=" + FrmName;
                    ModalPopupExtender1.Show();
                }

                if (voutype == "Journal")
                {
                    flag = true;
                    gblvname = "Journal";
                    string FrmName = "Statistics_Journal";
                    iframecost.Attributes["src"] = "../FAForms/Journal.aspx?FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&Vdate=" + GRDREG.Rows[index].Cells[0].Text + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&Str_Name=" + FrmName;
                    ModalPopupExtender1.Show();

                    //Response.Redirect("../FAForms/Journal.aspx?FormName=" + gblvname + "&flag=" + flag + "&PBranch_ID=" + Pbid + "&Vno=" + vouNo + "&Vdate=" + GRDREG.Rows[index].Cells[0].Text + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&Str_Name=" + FrmName);
                }

                if (voutype == "Adjustment DCN")
                {
                    flag = true;
                    string FrmName = "Statistics_AdjustmenrtDNCN";
                    //Response.Redirect("../FAForms/AdjustmenrtDNCN.aspx?FormName=CN" + gblvname + "&Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&flag=" + flag + "&Str_Name=" + FrmName);

                    iframecost.Attributes["src"] = "../FAForms/AdjustmenrtDNCN.aspx?FormName=CN" + gblvname + "&Vno=" + vouNo + "&vid=" + hidvoutypeid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&type=" + voutype + "&flag=" + flag + "&Str_Name=" + FrmName;
                    ModalPopupExtender1.Show();
                }
            }
        } 
        
        protected void GRDREG_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GRDREG.EditIndex = -1;
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            //if( (fgr==true) && (fgm==false))
            if ((GRDREG.Visible == true) && (grdmonth.Visible == false))
            {
                GRDREG.Visible = false;
                grdmonth.Visible = true;
                gridmonth();
            }
            else if ((grdmonth.Visible == true) && (grd.Visible == false))
            {
                grdmonth.Visible = false;
                grd.Visible = true;
                grid();
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if ((GRDREG.Visible == true) && (grdmonth.Visible == false))
            {
                GRDREG.Visible = false;
                grdmonth.Visible = true;
                gridmonth();
                
            }
            else if ((grdmonth.Visible == true) && (grd.Visible == false))
            {
                grdmonth.Visible = false;
                grd.Visible = true;
                grid();
                
            }
            else
            {
                DataTable dt_Empty = new DataTable();
                GRDREG.DataSource = dt_Empty;
                grdmonth.DataSource = dt_Empty;
                grd.DataSource = dt_Empty;
                btncancel.Text = "Back";
                btncancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            if (btncancel.ToolTip == "Back")
            {
                //this.Response.End();
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "BR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }

                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FAFC")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
                
            }
            
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            if ((GRDREG.Visible == true) && (grdmonth.Visible == false))
            {
                string strtemp = "";
                string Filename = "STATISTICS";
                strtemp = Utility.Fn_ExportExcel(GRDREG, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");

                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();
            }

            else if ((grdmonth.Visible == true) && (grd.Visible == false))
            {
                string strtemp = "";
                string Filename = "STATISTICS";
                strtemp = Utility.Fn_ExportExcel(grdmonth, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();
            }
            else if ((grd.Visible == true))
            {
                string strtemp = "";
                string Filename = "STATISTICS";
                strtemp = Utility.Fn_ExportExcel(grd, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();
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
            GridViewlog.Visible = true;
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1204, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1204, "", "", "", Session["StrTranType"].ToString());
            }

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
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


