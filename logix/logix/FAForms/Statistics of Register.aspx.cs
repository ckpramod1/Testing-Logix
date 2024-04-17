using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.FAForm
{
    public partial class Statistics_of_Register : System.Web.UI.Page
    {
        DateTime joudate;
        DateTime lastDay;
        DateTime fromdate;
        int voutypeid;
        string StrTranType;
        DataTable dt = new DataTable();
        DataTable dtdet = new DataTable();
        DataAccess.FAVoucher faobj = new DataAccess.FAVoucher();
        DataAccess.FAMaster.ReportView FARepobj = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);
            
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_title.Text = Request.QueryString["FormName"].ToString();
            }

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                txt_from.Enabled = true;
                txt_to.Enabled = true;
                grdGroup.DataSource = new DataTable();
                grdGroup.DataBind();
                joudate = Logobj.GetDate();
                hf_Date.Value = joudate.ToString();
               // txt_from.Text = Utility.fn_ConvertDate(joudate.ToShortDateString());
                txt_to.Text = Utility.fn_ConvertDate(joudate.ToShortDateString());
                voucher();
                lbl_titl.Visible = false;
            }          
        }

        public void voucher()
        {
            dt = FARepobj.SelMasterVoutype(Session["FADbname"].ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    

                    ddl_voucher.Items.Add(dt.Rows[i][1].ToString());
                }
            }
            //int getDateMonthNow = DateTime.Now.Month;
            //int getDateYearNow = DateTime.Now.Year;
            //int getNumberOfDay = DateTime.Now.Day;
            //getNumberOfDay = DateTime.DaysInMonth(getDateYearNow, getDateMonthNow);
            //lastDay = new DateTime(getDateYearNow, getDateMonthNow - 1, getNumberOfDay-22);
            //txt_from.Text = Utility.fn_ConvertDate(lastDay.ToShortDateString());
            //btn_back.Text = "Cancel";

            fromdate = Logobj.GetDate().AddMonths(-1);
            txt_from.Text = Utility.fn_ConvertDate(fromdate.ToShortDateString());
        }

        protected void txt_from_TextChanged(object sender, EventArgs e)
        {
            //if (txt_from.Enabled)
            //{
            //DateTime dt_logDate;
            //DateTime dt_voudate;
            //dt_logDate = Convert.ToDateTime(hf_Date.Value.ToString());
            //dt_voudate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
            //if (dt_logDate.Month == dt_voudate.Month && dt_logDate.Year == dt_voudate.Year)
            //{
            //    txt_from.Text = Utility.fn_ConvertDate(dt_logDate.ToShortDateString());
            //}
            //else
            //{
            //    dt_voudate = new DateTime(dt_voudate.Year, dt_voudate.Month, 1).AddMonths(1).AddDays(-1);
            //    txt_from.Text = Utility.fn_ConvertDate(dt_voudate.ToShortDateString());
            //}
            //if (dt_voudate.Month < 4 && dt_voudate.Year < Convert.ToInt32(Session["LogYear"].ToString()))
            //{
            //    txt_from.Text = Utility.fn_ConvertDate(dt_logDate.ToShortDateString());
            //}
            //}

            if (txt_to.Text == "4/1/" + Session["LogYear"].ToString() || txt_to.Text == "3/31/" + (Convert.ToInt32(Session["LogYear"].ToString()) + 1))
            {
                txt_to.Text = Logobj.GetDate().AddMonths(-1).ToString();
            }
        }

        protected void txt_to_TextChanged(object sender, EventArgs e)
        {
            //if (txt_to.Enabled)
            //{
            //    DateTime dt_logDate;
            //    DateTime dt_voudate;
            //    dt_logDate = Convert.ToDateTime(hf_Date.Value.ToString());
            //    dt_voudate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));
            //    if (dt_logDate.Month == dt_voudate.Month && dt_logDate.Year == dt_voudate.Year)
            //    {
            //        txt_to.Text = Utility.fn_ConvertDate(dt_logDate.ToShortDateString());
            //    }
            //    else
            //    {
            //        dt_voudate = new DateTime(dt_voudate.Year, dt_voudate.Month, 1).AddMonths(1).AddDays(-1);
            //        txt_to.Text = Utility.fn_ConvertDate(dt_voudate.ToShortDateString());
            //    }
            //    if (dt_voudate.Month < 4 && dt_voudate.Year < Convert.ToInt32(Session["LogYear"].ToString()))
            //    {
            //        txt_to.Text = Utility.fn_ConvertDate(dt_logDate.ToShortDateString());
            //    }
            //}

            if ((txt_to.Text == "4/1/" + Session["LogYear"].ToString() || txt_to.Text == "3/31/" + (Convert.ToInt32(Session["Vouyear"].ToString()) + 1)))
            {
                txt_to.Text = Logobj.GetDate().AddMonths(1).ToString();
            }
        }

        protected void ddl_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_voucher.SelectedItem.Text != "")
            {
                voutypeid = faobj.Selvoutypeid(ddl_voucher.SelectedItem.Text, Session["FADbname"].ToString());
                Voutype_ID.Value = voutypeid.ToString();
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            if (ddl_voucher.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Voucher type Can not be blank');", true);
                return;
            }
            else
            {
                if (Voutype_ID.Value == "")
                {
                    return;
                }
                lbl_titl.Text = ddl_voucher.SelectedItem.Text + " Register From "; lbl_titl1.Text = txt_from.Text; lbl_titl2.Text = "To  " + txt_to.Text;
                dtdet = FARepobj.FAselStatisticsReg(Convert.ToInt32(Voutype_ID.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), Session["FADbname"].ToString());
                grdGroup.DataSource = dtdet;
                grdGroup.DataBind();
                lbl_titl.Visible = true;
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }

            //if (StrTranType == "FA")
            //{
            if (Session["str_ModuleName"] == "FA")
            {
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1114, 3, Convert.ToInt32(Session["LoginBranchid"]), "Static Reg" + txt_from.Text + "~" + txt_to.Text + "/V");
            }
            else
            {
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1204, 3, Convert.ToInt32(Session["LoginBranchid"]), "Static Reg" + txt_from.Text + "~" + txt_to.Text + "/V");
            }
        }
          
        protected void btn_export_Click(object sender, EventArgs e)
        {
            if (grdGroup.Rows.Count > 0)
            {
                string strtemp = "";
                string Filename = "Balance Sheet - From " + txt_from.Text + " To " + txt_to.Text;
                strtemp = Utility.Fn_ExportExcel(grdGroup, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Data not Avaliable')", true);
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                ddl_voucher.SelectedValue= "";
               // txt_to.Text = Logobj.GetDate().ToString();
               // txt_to.Text = Utility.fn_ConvertDate(joudate.ToShortDateString());
               // txt_from.Text = Utility.fn_ConvertDate(fromdate.ToShortDateString());
                grdGroup.DataSource = new DataTable();
                grdGroup.DataBind();
                lbl_titl.Text = "";
                lbl_titl1.Text = "";
                lbl_titl2.Text = "";
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"]= "btn ico-back";
            }
            else
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

        protected void btn_print_Click(object sender, EventArgs e)
        {
           
        }

        protected void grdGroup_RowDataBound(object sender, GridViewRowEventArgs e)
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

                //for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                //{
                //    double dbl_temp = 0;
                //    if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                //    {
                //        e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                //        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                //    }
                //}
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
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1114, "PA", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1204, "PA", "", "", Session["StrTranType"].ToString());
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

        protected void grdGroup_PreRender(object sender, EventArgs e)
        {
            if (grdGroup.Rows.Count > 0)
            {
                grdGroup.UseAccessibleHeader = true;
                grdGroup.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}