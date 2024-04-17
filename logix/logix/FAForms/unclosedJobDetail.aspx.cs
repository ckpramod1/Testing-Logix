using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using ClosedXML.Excel;

namespace logix.FAForm
{
    public partial class unclosedJobDetail : System.Web.UI.Page
    {
        int bid, did,empid;
        string FADbname, StrTranType;
        DataAccess.unclosedjob unjob = new DataAccess.unclosedjob();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.CloseJobs objClosedJob = new DataAccess.CloseJobs();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable dttbl;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                unjob.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Cancel);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnexportexcel);
            FADbname = Session["FADbname"].ToString();
            bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if (Session["str_ModuleName"] != null)
            {
                StrTranType = Session["str_ModuleName"].ToString();
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_Header.Text = Request.QueryString["FormName"].ToString();
            }
            
            if(!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                if (stryear == vouyeartext)
                {
                    txt_From.Text = "01/04/" + vouyeartext;
                    txt_To.Text = Str_CurrrentDate.ToString();

                }
                else
                {
                    txt_From.Text = "01/04/" + vouyeartext;
                    txt_To.Text = "31/03/" + (vouyeartext + 1);
                }
                //txt_From.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                //txt_To.Text = txt_From.Text;
                grduncjob.DataSource = new DataTable();
                grduncjob.DataBind();
            }
        }

        protected void grduncjob_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            int logcorid, job;
            string value, product;
            string[] sp_job;
            btn_Cancel.ToolTip = "Cancel";
            btn_Cancel1.Attributes["class"] = "btn ico-cancel";

            logcorid = hrempobj.GetBranchId(did, "CORPORATE");
            DateTime datefrom = Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text));
            DateTime dateto=Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text));
            if (datefrom > dateto)
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(Button), "JobInfo", "alertify.alert('From date should be less than To date');", true);
                return;
            }
            if (logcorid == bid)
            {
                //dttbl = unjob.Getunclosedjob(did, bid, 0, datefrom, dateto);
                dttbl = objClosedJob.Getunclosedjobnewcorporate(did, Convert.ToInt32(Session["LoginEmpId"].ToString()), 0, datefrom, dateto);
            }

            else
            {
                //dttbl = unjob.Getunclosedjob(0, bid, 0, datefrom, dateto);
                dttbl = objClosedJob.GetunclosedjobnewWITHRETnew(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()), 0, datefrom, dateto);
            }

            if(dttbl.Rows.Count > 0)
            {
                DataTable dttemp = new DataTable();
                dttemp.Columns.Add("shortname");
                dttemp.Columns.Add("Product");
                dttemp.Columns.Add("jobno");
                dttemp.Columns.Add("etd");
                dttemp.Columns.Add("income");
                dttemp.Columns.Add("expense");
                dttemp.Columns.Add("retention");
                dttemp.Columns.Add("Branchid");
                dttemp.Columns.Add("MBL");
                dttemp.Columns.Add("BL");
                dttemp.Columns.Add("Shipper");
                dttemp.Columns.Add("Consignee");
                dttemp.Columns.Add("POL");
                dttemp.Columns.Add("POD");
                dttemp.Columns.Add("CustomerName");
                dttemp.Columns.Add("Salesperson");
                dttemp.Columns.Add("vessel");
                dttemp.Columns.Add("ETA");
                dttemp.Columns.Add("ETD1");
                DataRow dr;

                for (int i = 0; i <= dttbl.Rows.Count - 1; i++)
                {
                    dr = dttemp.NewRow();
                    value = dttbl.Rows[i]["jobno"].ToString();
                    sp_job = value.Split('-');
                    product = sp_job[1];
                    if(product=="FE")
                    {
                        product = "OE";
                    }
                    else if (product == "FI")
                    {
                        product = "OI";
                    }

                    job = Convert.ToInt32(sp_job[2]);
                    dr["shortname"] = dttbl.Rows[i]["shortname"].ToString();
                    dr["Product"] = product;
                    dr["jobno"] = value;
                    dr["etd"] = dttbl.Rows[i]["jobdate"].ToString();
                    dr["income"] = dttbl.Rows[i]["income"].ToString();
                    dr["expense"] = dttbl.Rows[i]["expense"].ToString();
                    dr["retention"] = dttbl.Rows[i]["retention"].ToString();
                    dr["Branchid"] = dttbl.Rows[i]["bid"].ToString();
                    dr["MBL"] = dttbl.Rows[i]["MBL"].ToString();
                    dr["BL"] = dttbl.Rows[i]["BL"].ToString();
                    dr["Shipper"] = dttbl.Rows[i]["Shipper"].ToString();
                    dr["Consignee"] = dttbl.Rows[i]["Consignee"].ToString();
                    dr["POL"] = dttbl.Rows[i]["POL"].ToString();
                    dr["POD"] = dttbl.Rows[i]["POD"].ToString();
                    dr["CustomerName"] = dttbl.Rows[i]["customername"].ToString();
                    dr["Salesperson"] = dttbl.Rows[i]["Salesperson"].ToString();
                    dr["vessel"] = dttbl.Rows[i]["vessel"].ToString();
                    dr["ETA"] = dttbl.Rows[i]["ETA"].ToString();
                    dr["ETD1"] = dttbl.Rows[i]["ETD1"].ToString();
                    dttemp.Rows.Add(dr);
                }

                grduncjob.DataSource = dttemp;
                grduncjob.DataBind();
                ViewState["GridViewdate"] = dttemp;
            }

            if (StrTranType == "FA")
            {
                logobj.InsLogDetail(empid, 1308, 3, bid, txt_From.Text + "~" + txt_To.Text + "/Get");
            }
            else
            {
                logobj.InsLogDetail(empid, 1307, 3, bid, txt_From.Text + "~" + txt_To.Text + "/Get");
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (btn_Cancel.ToolTip == "Cancel")
            {
                txt_From.Text = Utility.fn_ConvertDate(logobj.GetDate().ToString());
                txt_To.Text = txt_From.Text;
                grduncjob.DataSource = new DataTable();
                grduncjob.DataBind();
                btn_Cancel.Text = "Back";
                btn_Cancel.ToolTip = "Back";
                btn_Cancel1.Attributes["class"] = "btn ico-back";

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

        protected void btnexportexcel_Click(object sender, EventArgs e)
        {
           

            //if (grduncjob.Rows.Count > 0)
            //{
            //    DataTable dt_check = ViewState["GridViewdate"] as DataTable;
            //    dt_check.Columns.Remove("Branchid");
            //    using (XLWorkbook wb = new XLWorkbook())
            //    {
            //        //wb.Worksheets.Add("test");

            //        wb.Worksheets.Add(dt_check);

            //        Response.Clear();
            //        Response.Buffer = true;
            //        Response.Charset = "";
            //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //        Response.AddHeader("content-disposition", "attachment;filename=Unclosed Job Detail.xls");
            //        using (MemoryStream MyMemoryStream = new MemoryStream())
            //        {
            //            wb.SaveAs(MyMemoryStream);
            //            MyMemoryStream.WriteTo(Response.OutputStream);
            //            Response.Flush();
            //            Response.End();
            //        }
            //    }
            //}


            if (grduncjob.Rows.Count > 0)
            {
              grduncjob.Columns[9].Visible = false;
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Unclosed Job Details for the period of " + txt_From.Text + " To " + txt_To.Text + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                if (grduncjob.Visible == true)
                {
                    grduncjob.GridLines = GridLines.Both;
                    grduncjob.HeaderStyle.Font.Bold = true;
                    grduncjob.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
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
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1308, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1307, "", "", "", Session["StrTranType"].ToString());
            }


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grduncjob_PreRender(object sender, EventArgs e)
        {
            if (grduncjob.Rows.Count > 0)
            {
                grduncjob.UseAccessibleHeader = true;
                grduncjob.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}