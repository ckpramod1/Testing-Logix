using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.IO;

namespace logix.Reportasp
{
    public partial class quotationrpt : System.Web.UI.Page
    {
        DataTable dtQuot = new DataTable();
        DataAccess.Marketing.Quotation quotation1 = new DataAccess.Marketing.Quotation();
        DataAccess.Masters.MasterEmployee objEmp = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        int customerid;
        int quotno;
        string ftype, status, type1, type2, rowbind, str_Script;
        DateTime fromdate, todate, dtime;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                quotation1.GetDataBase(Ccode);
                objEmp.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("Quotno"))
                {
                    //lbl_img.ImageUrl = "../images/montorlogo1.png";
                    lbl_quotno.Text = Request.QueryString["Quotno"].ToString();
                    lbl_branch.Text = Session["LoginDivisionName"].ToString();
                    // images/mr_Logo.jpg
                    //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    }
                     

                    dtQuot = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    {
                        lbl_add.Text = dtQuot.Rows[0]["address"].ToString();//Dt.Rows[0]["phone"].ToString()+ " Fax : " + Dt.Rows[0]["fax"].ToString() 
                        lbl_ph.Text = dtQuot.Rows[0]["phone"].ToString();
                        lbl_fax.Text = dtQuot.Rows[0]["fax"].ToString();
                        lbl_email.Text = dtQuot.Rows[0]["email"].ToString();
                       // dtime = da_obj_Log.GetDate();
                       // lbldate.Text = dtime.ToShortDateString();

                        lbldate.Text = DateTime.Parse(da_obj_Log.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");


                    }
                    dtQuot = quotation1.GetQuotationDetails(Convert.ToInt32(lbl_quotno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    {
                        //quotdate
                        quotno = Convert.ToInt32(dtQuot.Rows[0]["quotno"].ToString());
                        fromdate = Convert.ToDateTime(dtQuot.Rows[0]["quotdate"].ToString());
                        lbl_date.Text = fromdate.ToString("dd-MMM-yyyy");
                        todate = Convert.ToDateTime(dtQuot.Rows[0]["validtill"].ToString());
                        lbl_validtill.Text = todate.ToString("dd-MMM-yyyy");
                        customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                        lbl_emp.Text = objEmp.GetEmployeeName(Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString()));
                    }
                    dtQuot = quotation1.GetQuatForprocuiNew(quotno, Convert.ToInt32(Session["LoginBranchid"].ToString()), customerid, Session["StrTranType"].ToString());
                    if (dtQuot.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtQuot.Rows[0]["customername"].ToString()))
                        {
                            lbl_to_add.Text = dtQuot.Rows[0]["customername"].ToString() + "<br />";
                            lbl_to_add.Visible = true;
                        }

                        if (!string.IsNullOrEmpty(dtQuot.Rows[0]["address"].ToString()))
                        {
                            lbl_street.Text = dtQuot.Rows[0]["address"].ToString() + "<br />";
                            lbl_street.Visible = true;
                        }
                        if (!string.IsNullOrEmpty(dtQuot.Rows[0]["portname"].ToString()))
                        {
                            lbl_location.Text = dtQuot.Rows[0]["portname"].ToString() + " - " + dtQuot.Rows[0]["zip"].ToString() + "<br />";
                            lbl_location.Visible = true;
                        }
                        if (!string.IsNullOrEmpty(dtQuot.Rows[0]["ptc"].ToString()))
                        {
                            lbl_ptc.Text = "PTC : " + dtQuot.Rows[0]["ptc"].ToString() + "<br />";
                            lbl_ptc.Visible = true;
                        }
                        if (!string.IsNullOrEmpty(dtQuot.Rows[0]["phone"].ToString()))
                        {
                            lbl_toph.Text = "PH : " + dtQuot.Rows[0]["phone"].ToString() + "<br />";
                            lbl_toph.Visible = true;
                        }
                        if (!string.IsNullOrEmpty(dtQuot.Rows[0]["email"].ToString()))
                        {
                            lbl_toemail.Text = "Email : " + dtQuot.Rows[0]["email"].ToString() + "<br />";
                            lbl_toemail.Visible = true;
                        }

                        lbl_fromport.Text = dtQuot.Rows[0]["portname"].ToString();
                        lbl_toport.Text = dtQuot.Rows[0]["portpod"].ToString();
                        lbl_commodity.Text = dtQuot.Rows[0]["cargotype"].ToString();
                        lbl_desc.Text = dtQuot.Rows[0]["descn"].ToString().ToUpper();
                        ftype = dtQuot.Rows[0]["stype"].ToString();

                        if (ftype == "L")
                        {
                            type1 = "LCL";
                        }
                        else if (ftype == "F")
                        {
                            type1 = "FCL";
                        }
                        lbl_shipment.Text = type1;
                        status = dtQuot.Rows[0]["fstatus"].ToString();
                        if (status == "P")
                        {
                            type2 = "Prepaid";
                        }
                        else if (status == "C")
                        {
                            type2 = "To Collect";
                        }
                        lbl_frieght.Text = type2;
                        lblRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                    }

                    dtQuot = quotation1.ChargeDetails(Convert.ToInt32(lbl_quotno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                    if (dtQuot.Rows.Count > 0)
                    {
                        rowbind = "";
                        if (Request.QueryString.ToString().Contains("nextpage"))
                        {
                            if (Request.QueryString["nextpage"].ToString()=="2")
                            {
                                if (dtQuot.Rows.Count > 10 && dtQuot.Rows.Count < 30)
                                {
                                    for (int i = 10; i < dtQuot.Rows.Count; i++)
                                    {
                                        tr_row.Text += "<tr style='background-Color:#d0d0d0;'>";
                                        tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtQuot.Rows[i]["chargename"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + dtQuot.Rows[i]["curr"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + Convert.ToDouble(dtQuot.Rows[i]["rate"]).ToString("#,0.00") + "</td>";
                                        tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + dtQuot.Rows[i]["base"].ToString() + "</td>";
                                        tr_row.Text += "</tr>";
                                        if (i == 19)
                                        {
                                            break;
                                        }
                                    }
                                }
                                lbl_page.Text = "Page of 1 / 2";
                                return;
                            }
                            else if (Request.QueryString["nextpage"].ToString() == "3")
                            {
                                if (dtQuot.Rows.Count > 20)
                                {
                                    for (int i = 20; i < dtQuot.Rows.Count; i++)
                                    {
                                        tr_row.Text += "<tr  style='background-Color:#d0d0d0;'>";
                                        tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtQuot.Rows[i]["chargename"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + dtQuot.Rows[i]["curr"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + Convert.ToDouble(dtQuot.Rows[i]["rate"]).ToString("#,0.00") + "</td>";
                                        tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + dtQuot.Rows[i]["base"].ToString() + "</td>";
                                        tr_row.Text += "</tr>";
                                        if (i == 29)
                                        {
                                            break;
                                        }
                                    }
                                }
                                lbl_page.Text = "Page of 1 / 3";
                                return;
                            }
                            
                        }
                        if (dtQuot.Rows.Count <= 10 || !Request.QueryString.ToString().Contains("nextpage"))
                        {
                            for (int i = 0; i < dtQuot.Rows.Count; i++)
                            {
                                tr_row.Text += "<tr  style='background-Color:#d0d0d0;'>";
                                tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtQuot.Rows[i]["chargename"].ToString() + "</td>";
                                tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + dtQuot.Rows[i]["curr"].ToString() + "</td>";
                                tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + Convert.ToDouble(dtQuot.Rows[i]["rate"]).ToString("#,0.00") + "</td>";
                                tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif; text-align:right;'>" + dtQuot.Rows[i]["base"].ToString() + "</td>";
                                tr_row.Text += "</tr>";
                                if(i==9)
                                {
                                    break;
                                }
                            }
                            lbl_page.Text = "Page of 1 / 1";
                            lbl_page.Visible = true;
                        }if(dtQuot.Rows.Count>10 && dtQuot.Rows.Count<30)
                        {
                            str_Script = "window.open('../Reportasp/quotationrpt.aspx?nextpage=2"+ "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", str_Script, true);
                            lbl_page.Visible = true;
                        }
                        if(dtQuot.Rows.Count>20)
                        {
                            str_Script += "window.open('../Reportasp/quotationrpt.aspx?nextpage=3" + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", str_Script, true);
                        }
                        

                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //this.RenderControl(hw);
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();

            Response.Write("<script language='javascript'> { self.close() }</script>");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
 
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

    }
}