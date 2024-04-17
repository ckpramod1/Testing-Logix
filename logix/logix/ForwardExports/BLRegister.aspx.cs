using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Runtime.Remoting;

namespace logix.ForwardExports
{
    public partial class BLRegister : System.Web.UI.Page
    {
        string str_Uiid = "", str_trantype;

        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.CostingTemp obj_da_costtempobj = new DataAccess.CostingTemp();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                obj_da_costtempobj.GetDataBase(Ccode);

            }


            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_view);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            try
            {

            
            if (!IsPostBack)
            {
                
                    //if (Request.QueryString.ToString().Contains("trantype"))
                    //{
                    //    str_trantype = Request.QueryString["trantype"].ToString();
                    //    Session["StrTranType"] = str_trantype;
                    //    radio_incentive.Visible = true;
                    //}
                     if (Request.QueryString.ToString().Contains("type"))
                    {
                        if (Request.QueryString.ToString().Contains("trantype"))
                        {
                             str_trantype = Request.QueryString["trantype"].ToString();
                             Session["StrTranType"] = str_trantype;
                        }
                        radio_incentive.Visible = true;
                    }
                    else
                    {
                        str_trantype = Session["StrTranType"].ToString();
                    }
                    //string str_CtrlLists = "txt_From~txt_To";
                    btn_view.Attributes.Add("OnClick", "return IsDate('txt_From~txt_To')");
                    //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        lbl_header.Text = Request.QueryString["type"].ToString();
                    }
                  
                    if (lbl_header.Text == "Performance Revenue")
                    {
                        //Session["StrTranType"] = "AC";
                        radio_revenue.Visible = true;
                        radio_trend.Visible = true;
                        if (str_trantype=="FI")
                       {
                            radio_incentive.Visible = true;
                       }
                       
                    }
                    else if (lbl_header.Text == "BL Register")
                    {
                        radio_revenue.Visible = true;
                        radio_trend.Visible = true;
                        radio_incentive.Visible = true;
                        headerlabel2.InnerText = "BL Register";
                        //lbl_name.Text = "BL Register";
                        //lbl_name.Visible = true;
                    }
                    txt_From.Text = Utility.fn_ConvertDate(Convert.ToString(Logobj.GetDate().ToShortDateString()));
                    txt_To.Text = txt_From.Text;
                    iframecost.Attributes["src"] = "TrendAnalysis.aspx?HeaderName=" + lbl_header.Text + "&Fromdate=" + txt_From.Text + "&ToDate=" + txt_To.Text;
                    //Session["Header"] = lbl_header.Text;

                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        str_Uiid = Request.QueryString["type"].ToString();
                    }
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_view, null);
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"]="btn ico-cancel";
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            headerlable1.InnerText = "OceanExports";
                            if (lbl_header.Text == "Performance Revenue")
                            {
                                headerlabel2.InnerText = "Documentation";
                            }

                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            headerlable1.InnerText = "OceanImports";
                            if (lbl_header.Text == "Performance Revenue")
                            {
                                headerlabel2.InnerText = "Documentation";
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            headerlable1.InnerText = "AirExports";
                            if (lbl_header.Text == "Performance Revenue")
                            {
                                headerlabel2.InnerText = "Documentation";
                            }
                            else if (lbl_header.Text == "BL Register")
                            {
                                headerlabel2.InnerText = "Customer Support";
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            headerlable1.InnerText = "AirImports";
                            if (lbl_header.Text == "Performance Revenue")
                            {
                                headerlabel2.InnerText = "Documentation";
                            }
                            else if (lbl_header.Text == "BL Register")
                            {
                                headerlabel2.InnerText = "Customer Support";
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "CH")
                        {
                            headerlabel2.InnerText = "Custom House Agent";

                            if (lbl_header.Text == "Performance Revenue")
                            {
                                headerlable1.InnerText = "Shipment Details";

                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AC")
                        {
                            headerlabel2.InnerText = "Operating Accounts";

                            if (lbl_header.Text == "BL Register")
                            {
                                headerlable1.InnerText = "BL Register";

                            }
                        }
                    }
                    else 
                    {

                        if(Request.QueryString["trantype"].ToString()=="AC")

                        {
                            headerlabel2.InnerText = "Operating Accounts";

                        }

                    }
               
            }
            headerlabel.InnerText = lbl_header.Text;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
           if(btn_cancel.ToolTip=="Cancel")
           {
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            txt_From.Text = Utility.fn_ConvertDate(Convert.ToString(Logobj.GetDate().ToShortDateString()));
            txt_To.Text = txt_From.Text;
            radio_trend.Checked = false;
            radio_revenue.Checked = false;
            radio_incentive.Checked = false;
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            }
           else
           {
              // this.Response.End();

               if (Session["home"] != null)
               {
                   if (Session["home"].ToString() == "CS")
                   {
                       if (Session["StrTranType"] != null)
                       {
                           if (Session["StrTranType"].ToString() == "AE")
                           {
                               Response.Redirect("../Home/AECSHome.aspx");
                           }
                           else if (Session["StrTranType"].ToString() == "AI")
                           {
                               Response.Redirect("../Home/AICSHome.aspx");
                           }

                       }
                   }
                   else if (Session["home"].ToString() == "OPS&DOC")
                   {
                       Response.Redirect("../Home/OEOpsAndDocs.aspx");
                   }
               }
               else
               {
                   this.Response.End();
               }
           }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            //try
            //{

            
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            string trantype="";

            if (Request.QueryString.ToString().Contains("trantype"))
            {
                trantype = Request.QueryString["trantype"].ToString();
                Session["StrTranType"] = trantype;
            }
            else
            {
                Session["StrTranType"] = Session["StrTranType"].ToString();
                trantype = Session["StrTranType"].ToString();
            }
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            //DataAccess.CostingTemp obj_da_costtempobj = new DataAccess.CostingTemp();
            DateTime dtfrom = Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString()));
            ////Session["dtfrom"] = dtfrom;
            DateTime dtto = Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString()));
            //Session["dtto"] = dtto;

            //string strdate = Utility.fn_ConvertDateWithTime(txt_From.Text);
            //string strdate1 = Utility.fn_ConvertDate(strdate);

            //DateTime dtt = DateTime.Parse(strdate1);
            //string frmmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dtt.Month);

            //string strdate2 = Utility.fn_ConvertDateWithTime(txt_To.Text);
            //string strdate3 = Utility.fn_ConvertDate(strdate2);

            //DateTime dt2 = DateTime.Parse(strdate3);
            //string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt2.Month);

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            //obj_da_costtempobj.DelCostingTemp(Convert.ToInt32(Session["LoginEmpId"].ToString()));
            if (lbl_header.Text != "Performance Revenue")
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    str_RptName = "FEBLRegister.rpt";
                    str_sf = "{FEBLDetails.bid}=" + Session["LoginBranchid"].ToString() + " and {FEBLDetails.bldate} >= Date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {FEBLDetails.bldate } <= Date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ")";
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                    if(lbl_header.Text == "Performance Revenue")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 176, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                    }
                    else
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 533, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                    }
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    str_RptName = "FIBLRegister.rpt";
                    str_sf = "{FIBLDetails.bid}=" + Session["LoginBranchid"].ToString() + " and {FIBLDetails.bldate} >= Date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {FIBLDetails.bldate } <= Date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ")";
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                    if (lbl_header.Text == "Performance Revenue")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 177, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                    }
                    else
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 534, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                    }
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    //obj_da_costtempobj.DelCostingTemp(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    //CostingTemp();
                    str_RptName = "ShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + Session["LoginBranchid"].ToString();
                    str_sp = "Title=Air Exports SalesPerson Revenue from  " + txt_From.Text + "  to  " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    //Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                    if (lbl_header.Text == "Performance Revenue")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 203, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                    }
                    else
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 214, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                    }
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    //obj_da_costtempobj.DelCostingTemp(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    //CostingTemp();

                   str_RptName = "ShipmentDetailsTemp.rpt";
                   Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {CostingDetails.trantype}='AI'";
                  str_sp = "Title=Air Exports SalesPerson Revenue from  " + txt_From.Text + "  to  " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                   // Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                    /*str_RptName = "ShipmentDetailsTemp.rpt";
                    str_sf = "{CostingDetails.closeddate}>=date(\"" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "\") and {CostingDetails.closeddate}<=date(\"" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "\") and {CostingDetails.branchid}=" + Session["LoginBranchid"].ToString() + " and {CostingDetails.trantype}='AI'";
                    str_sp = "Title=Air Imports SalesPeson Revenue from  " + txt_From.Text + "  to  " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);*/
                    if (lbl_header.Text == "Performance Revenue")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 21, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                    }
                    else
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 211, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                    }
                }
            }
            else
            {
                if (radio_revenue.Checked == true)
                {
                    str_RptName = "SalesPersonWiseTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.division}=" + Session["LoginDivisionId"].ToString() + " and {CostingDetails.salesperson}=" + Session["LoginEmpId"].ToString();
                    str_sp = "Title=Ocean Exports Performance Revenue of  from " + txt_From.Text + " To " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    //Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                   if(trantype=="FE")
                   {
                       if (lbl_header.Text == "Performance Revenue")
                       {
                           Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 176, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                       }
                       else
                       {
                           Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 533, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                       }
                   }else if(trantype=="FI")
                   {
                       if (lbl_header.Text == "Performance Revenue")
                       {
                           Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 177, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                       }
                       else
                       {
                           Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 534, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                       }
                   }else if(trantype=="AE")
                   {
                       if (lbl_header.Text == "Performance Revenue")
                       {
                           Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 203, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                       }
                       else
                       {
                           Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 214, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                       }
                   }else if(trantype=="AI")
                   {
                       if (lbl_header.Text == "Performance Revenue")
                       {
                           Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 21, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                       }
                       else
                       {
                           Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 211, 3, Convert.ToInt32(Session["LoginBranchid"]), " From: " + txt_From.Text + "/ To: " + txt_To.Text + "/ View");
                       }
                   }

                }
                else if (radio_trend.Checked == true)
                {
                    Session["Header"] = lbl_header.Text;
                    //Session["StrTranType1"] = "AC";
                    iframecost.Attributes["src"] = "TrendAnalysis.aspx?HeaderName=" + lbl_header.Text + "&Fromdate=" + txt_From.Text + "&ToDate=" + txt_To.Text;
                    pop_trend.Show();
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                    
                }
                else if (radio_incentive.Checked == true)
                {
                    DataTable Dt = new DataTable();
                    if (trantype == "FI")
                    {
                       

                        //Response.Clear();
                        //Response.Buffer = true;
                        //Response.AddHeader("content-disposition", "attachment;filename=PerformanceTracking_FE.xls");
                        //Response.Charset = "";
                        //Response.ContentType = "application/vnd.ms-excel";
                        //using (StringWriter sw = new StringWriter())
                        //{
                        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

                        //    //To Export all pages
                        //    Dt = obj_da_costtempobj.GetIncentivedtls(Convert.ToDateTime(dtfrom), Convert.ToDateTime(dtto), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));
                        //    GrdFI.DataSource = Dt;
                        //    GrdFI.DataBind();
                        //    GrdFI.Visible = true;
                        //    // this.BindGrid();

                        //    //  grdstate.HeaderRow.BackColor = Color.WHITE;
                        //    foreach (System.Web.UI.WebControls.TableCell cell in GrdFI.HeaderRow.Cells)
                        //    {
                        //        cell.BackColor = GrdFI.HeaderStyle.BackColor;
                        //    }
                        //    foreach (GridViewRow row in GrdFI.Rows)
                        //    {
                        //        //  row.BackColor = Color
                        //        foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                        //        {
                        //            if (row.RowIndex % 2 == 0)
                        //            {
                        //                cell.BackColor = GrdFI.AlternatingRowStyle.BackColor;
                        //            }
                        //            else
                        //            {
                        //                cell.BackColor = GrdFI.RowStyle.BackColor;
                        //            }
                        //            cell.CssClass = "textmode";
                        //        }
                        //    }

                        //    GrdFI.RenderControl(hw);
                        //    GrdFI.Visible = false;
                        //    //style to format numbers to string
                        //    string style = @"<style> .textmode { } </style>";
                        //    Response.Write(style);
                        //    Response.Output.Write(sw.ToString());
                        //    Response.Flush();
                        //    Response.End();


                            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ExportExcel" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            GrdFI.AllowPaging = false;
            Dt = obj_da_costtempobj.GetIncentivedtls(Convert.ToDateTime(dtfrom), Convert.ToDateTime(dtto), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));
                            GrdFI.DataSource = Dt;
                            GrdFI.DataBind();
                            GrdFI.Visible = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GrdFI.GridLines = GridLines.Both;
            GrdFI.HeaderStyle.Font.Bold = true;
            GrdFI.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
                         GrdFI.Visible = false;
            Response.End();

                    

                  
                    }

                }

            }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void CostingTemp()
        {
            //try
            //{
                int i, j;
                int jobtype = 0;
                int totaltues = 0;
                int bltues;
                double totalcbm = 0.0;
                double mblexpense, mblCredit, mblamount, mblDebit;
                double jobchargewt = 0.0;
                double blamount, blDebit, blexpense, blCredit, blcbm, blchargewt;
                //DateTime ClosedDate;
                DataTable obj_DtJob = new DataTable();
                DataTable obj_DtCT = new DataTable();
                DataTable obj_DtBL = new DataTable();
                string bl, ml;
                //int jobno;
                string blno;
                int cont20 = 0;
                int cont40 = 0;
                int shipper, consignee, notify, agent, pol, pod, salesperson;
                char nomination;
                double volume;
              //  DataAccess.CostingTemp obj_da_costtempobj = new DataAccess.CostingTemp();
                obj_DtJob = obj_da_costtempobj.GetAllJobs(Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                for (i = 0; i <= obj_DtJob.Rows.Count - 1; i++)
                {
                    ml = obj_DtJob.Rows[i][1].ToString();
                    mblexpense = obj_da_costtempobj.GetcostPA(ml, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    mblCredit = obj_da_costtempobj.GetCreditDebit(ml, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "Credit");
                    hid_Closeddate.Value = obj_DtJob.Rows[i]["jobclosedate"].ToString();
                    mblamount = obj_da_costtempobj.GetcostInv(ml, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    mblDebit = obj_da_costtempobj.GetCreditDebit(ml, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "Debit");
                    if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                    {
                        jobtype = Convert.ToInt32(obj_DtJob.Rows[i]["jobtype"].ToString());
                        obj_DtCT = obj_da_costtempobj.GetCBMTues(Convert.ToInt32(obj_DtJob.Rows[i]["jobno"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (obj_DtCT.Rows.Count > 0)
                        {
                            if (obj_DtCT.Rows[0]["cbmtotal"].ToString() != "" & obj_DtCT.Rows[0]["Teustotal"].ToString() != "")
                            {
                                totalcbm = Convert.ToDouble(obj_DtCT.Rows[0]["cbmtotal"].ToString());
                                totaltues = Convert.ToInt32(obj_DtCT.Rows[0]["Teustotal"].ToString());
                            }
                        }
                    }
                    else if (Session["StrTranType"].ToString() == "AE" | Session["StrTranType"].ToString() == "AI")
                    {
                        jobtype = 0;
                        obj_DtCT = obj_da_costtempobj.GetCBMTues(Convert.ToInt32(obj_DtJob.Rows[i]["jobno"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (obj_DtCT.Rows.Count > 0)
                        {
                            if (obj_DtCT.Rows[0][0].ToString() != "")
                            {
                                jobchargewt = Convert.ToDouble(obj_DtCT.Rows[0][0].ToString());
                            }
                        }
                    }
                    obj_DtBL = obj_da_costtempobj.GetBLRow(Convert.ToInt32(obj_DtJob.Rows[i]["jobno"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    for (j = 0; j <= obj_DtBL.Rows.Count - 1; j++)
                    {
                        bl = obj_DtBL.Rows[j][1].ToString();
                        blamount = obj_da_costtempobj.GetcostInv(bl, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        blDebit = obj_da_costtempobj.GetCreditDebit(bl, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "Debit");
                        blexpense = obj_da_costtempobj.GetcostPA(bl, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        blCredit = obj_da_costtempobj.GetCreditDebit(bl, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "Credit");
                        if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                        {
                            bltues = Convert.ToInt32(obj_DtBL.Rows[j]["cont20"].ToString() + (Convert.ToInt32(obj_DtBL.Rows[j]["cont40"].ToString()) * 2));
                            blcbm = Convert.ToDouble(obj_DtBL.Rows[j]["cbm"].ToString());
                            if (mblamount != 0)
                            {
                                if (jobtype == 3)
                                {
                                    if (bltues == 0)
                                    {
                                        blamount = blamount + ((mblamount / 1) * 1);
                                    }
                                    else if (totaltues == 0)
                                    {
                                        blamount = blamount + ((mblamount / 1) * 1);
                                    }
                                    else
                                    {
                                        blamount = blamount + ((mblamount / totaltues) * bltues);
                                    }
                                }
                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blamount = blamount + 0;
                                    }
                                    else if (totalcbm == 0)
                                    {
                                        blamount = blamount + 0;
                                    }
                                    else
                                    {
                                        blamount = blamount + ((mblamount / totalcbm) * blcbm);
                                    }

                                }
                            }
                            if (mblDebit != 0)
                            {
                                if (jobtype == 3)
                                {
                                    if (bltues == 0)
                                    {
                                        blDebit = blDebit + ((mblDebit / 1) * 1);
                                    }
                                    else if (totaltues == 0)
                                    {
                                        blDebit = blDebit + ((mblDebit / 1) * 1);
                                    }
                                    blDebit = blDebit + ((mblDebit / totaltues) * bltues);
                                }
                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blDebit = blDebit + 0;
                                    }
                                    else if (totalcbm == 0)
                                    {
                                        blDebit = blDebit + 0;
                                    }
                                    else
                                    {
                                        blDebit = blDebit + ((mblDebit / totalcbm) * blcbm);
                                    }
                                }
                            }
                            if (mblexpense != 0)
                            {
                                if (jobtype == 3)
                                {
                                    if (bltues == 0)
                                    {
                                        blexpense = blexpense + ((mblexpense / 1) * 1);
                                    }
                                    else if (totaltues == 0)
                                    {
                                        blexpense = blexpense + ((mblexpense / 1) * 1);
                                    }
                                    else
                                    {
                                        blexpense = blexpense + ((mblexpense / totaltues) * bltues);
                                    }
                                }
                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blexpense = blexpense + 0;
                                    }
                                    else if (totalcbm == 0)
                                    {
                                        blexpense = blexpense + 0;
                                    }
                                    else
                                    {
                                        blexpense = blexpense + ((mblexpense / totalcbm) * blcbm);
                                    }
                                }
                            }

                            if (mblCredit != 0)
                            {
                                if (jobtype == 3)
                                {
                                    if (bltues == 0)
                                    {
                                        blCredit = blCredit + ((mblCredit / 1) * 1);
                                    }
                                    else if (totaltues == 0)
                                    {
                                        blCredit = blCredit + ((mblCredit / 1) * 1);
                                    }
                                    else
                                    {
                                        blCredit = blCredit + ((mblCredit / totaltues) * bltues);
                                    }
                                }
                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blCredit = blCredit + 0;
                                    }
                                    else if (totalcbm == 0)
                                    {
                                        blCredit = blCredit + 0;
                                    }
                                    else
                                    {
                                        blCredit = blCredit + ((mblCredit / totalcbm) * blcbm);
                                    }
                                }

                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AE" | Session["StrTranType"].ToString() == "AI")
                        {
                            blchargewt = Convert.ToDouble(obj_DtBL.Rows[j]["chargewt"].ToString());
                            if (mblamount != 0)
                            {
                                blamount = blamount + ((mblamount / jobchargewt) * blchargewt);
                            }
                            if (mblDebit != 0)
                            {
                                blDebit = blDebit + ((mblDebit / jobchargewt) * blchargewt);
                            }
                            if (mblexpense != 0)
                            {
                                blexpense = blexpense + ((mblexpense / jobchargewt) * blchargewt);
                            }
                            if (mblCredit != 0)
                            {
                                blCredit = blCredit + ((mblCredit / jobchargewt) * blchargewt);
                            }
                        }
                        hid_jobno.Value = obj_DtBL.Rows[j][0].ToString();
                        blno = obj_DtBL.Rows[j][1].ToString();
                        if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                        {
                            if (obj_DtBL.Rows[j][2].ToString() != "" & obj_DtBL.Rows[j][3].ToString() != "")
                            {
                                cont20 = Convert.ToInt32(obj_DtBL.Rows[j][2].ToString());
                                cont40 = Convert.ToInt32(obj_DtBL.Rows[j][3].ToString());
                            }
                            else if (Session["StrTranType"].ToString() == "AE" | Session["StrTranType"].ToString() == "AI")
                            {
                                cont20 = 0;
                                cont40 = 0;
                            }
                            nomination = Convert.ToChar(obj_DtBL.Rows[j][4].ToString());
                            volume = Convert.ToInt32(obj_DtBL.Rows[j][5].ToString());
                            shipper = Convert.ToInt32(obj_DtBL.Rows[j][6].ToString());
                            consignee = Convert.ToInt32(obj_DtBL.Rows[j][7].ToString());
                            notify = Convert.ToInt32(obj_DtBL.Rows[j][8].ToString());
                            agent = Convert.ToInt32(obj_DtBL.Rows[j][9].ToString());
                            pol = Convert.ToInt32(obj_DtBL.Rows[j][10].ToString());
                            pod = Convert.ToInt32(obj_DtBL.Rows[j][11].ToString());
                            salesperson = Convert.ToInt32(obj_da_costtempobj.GetSalesPerson(blno, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString())));
                            blamount = blamount + blDebit;
                            blexpense = blexpense + blCredit;
                            if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                            {
                                if (jobtype == 3)
                                {
                                    volume = 0;
                                }
                                else
                                {
                                    cont20 = 0;
                                    cont40 = 0;
                                }
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(blamount)))
                            {
                                blamount = 0;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(blexpense)))
                            {
                                blexpense = 0;
                            }
                            //if IsDBNull(blamount) = True Or IsNumeric(blamount) = False Then
                            //    blamount = 0
                            //End If
                            //If IsDBNull(blexpense) = True Or IsNumeric(blexpense) = False Then
                            //    blexpense = 0
                            //End If
                            obj_da_costtempobj.InsCostingTemp(Convert.ToInt32(Session["LoginEmpId"].ToString())
                                , Convert.ToInt32(hid_jobno.Value), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString())
                                , blno, volume, cont20, cont40, blamount, blexpense, nomination, salesperson, shipper,
                                consignee, notify, agent, pol, pod, jobtype, Convert.ToDateTime(hid_Closeddate.Value), 0);
                        }
                    }
                }
                OtherDNCNBL();
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }
        private void OtherDNCNBL()
        {
            //try { 

            int i, jobtype = 0;
            int cont20 = 0;
            int cont40 = 0;
            char nomination;
            string blno;
            //int jobno;
            double blamount, blexpense, volume;
            int shipper, consignee, notify, agent, pol, pod, salesperson;
            //DateTime ClosedDate;
          //  DataAccess.CostingTemp obj_da_costtempobj = new DataAccess.CostingTemp();
            DataTable obj_DtJob = new DataTable();
            DataTable obj_DtBL = new DataTable();
            obj_DtJob = obj_da_costtempobj.GetDNCN4MIS(Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
            for (i = 0; i <= obj_DtJob.Rows.Count - 1; i++)
            {
                blno = obj_DtJob.Rows[i]["blno"].ToString();
                hid_jobno.Value = obj_DtJob.Rows[i]["jobno"].ToString();
                hid_Closeddate.Value = obj_DtJob.Rows[i]["voudate"].ToString();
                obj_DtBL = obj_da_costtempobj.GetBLRowBL(blno, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (obj_DtBL.Rows.Count > 0)
                {
                    blamount = 0;
                    blexpense = 0;
                    if (i < obj_DtJob.Rows.Count - 1)
                    {
                        if (obj_DtJob.Rows[i]["blno"].ToString() != obj_DtJob.Rows[i + 1]["blno"].ToString())
                        {
                            if (obj_DtJob.Rows[i]["voutype"].ToString() == "V")
                            {
                                if (obj_DtJob.Rows[i]["amount"].ToString() != "")
                                {
                                    blamount = Convert.ToDouble(obj_DtJob.Rows[i]["amount"].ToString());
                                }
                            }
                            else
                            {
                                if (obj_DtJob.Rows[i]["amount"].ToString() != "")
                                {
                                    blexpense = Convert.ToDouble(obj_DtJob.Rows[i]["amount"].ToString());
                                }
                            }
                        }
                        else
                        {
                            if (obj_DtJob.Rows[i]["voutype"].ToString() == "V")
                            {
                                if (obj_DtJob.Rows[i]["amount"].ToString() != "")
                                {
                                    blamount = Convert.ToDouble(obj_DtJob.Rows[i]["amount"].ToString());
                                }
                                if (obj_DtJob.Rows[i + 1]["amount"].ToString() != "")
                                {
                                    blexpense = Convert.ToDouble(obj_DtJob.Rows[i + 1]["amount"].ToString());
                                }
                            }
                            else
                            {
                                if (obj_DtJob.Rows[i]["amount"].ToString() != "")
                                {
                                    blexpense = Convert.ToDouble(obj_DtJob.Rows[i]["amount"].ToString());
                                }
                                if (obj_DtJob.Rows[i + 1]["amount"].ToString() != "")
                                {
                                    blamount = Convert.ToDouble(obj_DtJob.Rows[i + 1]["amount"].ToString());
                                }
                            }
                            i = i + 1;
                        }
                    }
                    else
                    {
                        if (obj_DtJob.Rows[obj_DtJob.Rows.Count - 1]["voutype"].ToString() == "V")
                        {
                            if (obj_DtJob.Rows[obj_DtJob.Rows.Count - 1]["amount"].ToString() != "")
                            {
                                blamount = Convert.ToDouble(obj_DtJob.Rows[obj_DtJob.Rows.Count - 1]["amount"].ToString());
                            }
                        }
                        else
                        {
                            if (obj_DtJob.Rows[obj_DtJob.Rows.Count - 1]["amount"].ToString() != "")
                            {
                                blexpense = Convert.ToDouble(obj_DtJob.Rows[obj_DtJob.Rows.Count - 1]["amount"].ToString());
                            }
                        }
                        nomination = Convert.ToChar(obj_DtBL.Rows[0][4].ToString());
                        volume = Convert.ToDouble(obj_DtBL.Rows[0][5].ToString());
                        if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                        {
                            if (obj_DtBL.Rows[0][2].ToString() != "" & obj_DtBL.Rows[0][3].ToString() != "")
                            {
                                cont20 = Convert.ToInt32(obj_DtBL.Rows[0][2].ToString());
                                cont40 = Convert.ToInt32(obj_DtBL.Rows[0][3].ToString());
                                jobtype = Convert.ToInt32(obj_DtJob.Rows[i]["jobtype"].ToString());
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AE" | Session["StrTranType"].ToString() == "AI")
                        {
                            cont20 = 0;
                            cont40 = 0;
                            jobtype = 0;
                        }
                        salesperson = obj_da_costtempobj.GetSalesPerson(blno, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        shipper = Convert.ToInt32(obj_DtBL.Rows[0][6].ToString());
                        consignee = Convert.ToInt32(obj_DtBL.Rows[0][7].ToString());
                        notify = Convert.ToInt32(obj_DtBL.Rows[0][8].ToString());
                        agent = Convert.ToInt32(obj_DtBL.Rows[0][9].ToString());
                        pol = Convert.ToInt32(obj_DtBL.Rows[0][10].ToString());
                        pod = Convert.ToInt32(obj_DtBL.Rows[0][11].ToString());

                        obj_da_costtempobj.InsCostingTemp(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hid_jobno.Value), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), blno, volume, cont20, cont40, blamount, blexpense, nomination, salesperson, shipper, consignee, notify, agent, pol, pod, jobtype, Convert.ToDateTime(hid_Closeddate.Value), 0);
                    }
                }
                else
                {
                    OtherDNCNMBL();
                }

            }
            Session["DtJob"] = obj_DtJob;
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}

        }
        private void OtherDNCNMBL()
        {
            //try
            //{
                int i = 0, j, bltues;
                int totaltues = 0;
                int jobtype = 0;
                double blamount, blexpense, blcbm, blchargewt, volume;
                double mblamount = 0;
                double mblexpense = 0;
                double totalcbm = 0;
                double jobchargewt = 0.0;
                string blno;
                char nomination;
                int shipper, consignee, notify, agent, pol, pod, salesperson;
                int cont20 = 0;
                int cont40 = 0;
             //   DataAccess.CostingTemp obj_da_costtempobj = new DataAccess.CostingTemp();
                DataTable obj_DtBL = new DataTable();
                DataTable obj_DtJob1 = new DataTable();
                DataTable obj_DtCT = new DataTable();
                if (Session["DtJob"] != null)
                {
                    obj_DtJob1 = (DataTable)Session["DtJob"];
                }
                //else
                //{

                //}
                obj_DtBL = obj_da_costtempobj.GetBLRow(Convert.ToInt32(hid_jobno.Value), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                if (obj_DtBL.Rows.Count > 0)
                {
                    if (obj_DtJob1.Rows.Count > 0)
                    {
                        if (obj_DtJob1.Rows[i]["blno"].ToString() != obj_DtJob1.Rows[i + 1]["blno"].ToString())
                        {
                            if (obj_DtJob1.Rows[i]["voutype"].ToString() == "V")
                            {
                                if (obj_DtJob1.Rows[i]["amount"].ToString() != "")
                                {
                                    mblamount = Convert.ToDouble(obj_DtJob1.Rows[i]["amount"].ToString());
                                }
                            }
                            else
                            {
                                if (obj_DtJob1.Rows[i]["amount"].ToString() != "")
                                {
                                    mblexpense = Convert.ToDouble(obj_DtJob1.Rows[i]["amount"].ToString());
                                }
                            }
                        }
                        else
                        {
                            if (obj_DtJob1.Rows[i]["voutype"].ToString() == "V")
                            {
                                if (obj_DtJob1.Rows[i]["amount"].ToString() != "")
                                {
                                    mblamount = Convert.ToDouble(obj_DtJob1.Rows[i]["amount"].ToString());
                                }
                                if (obj_DtJob1.Rows[i + 1]["amount"].ToString() != "")
                                {
                                    mblexpense = Convert.ToDouble(obj_DtJob1.Rows[i + 1]["amount"].ToString());
                                }
                            }
                            else
                            {
                                if (obj_DtJob1.Rows[i]["amount"].ToString() != "")
                                {
                                    mblexpense = Convert.ToDouble(obj_DtJob1.Rows[i]["amount"].ToString());
                                }
                                if (obj_DtJob1.Rows[i + 1]["amount"].ToString() != "")
                                {
                                    mblamount = Convert.ToDouble(obj_DtJob1.Rows[i + 1]["amount"].ToString());
                                }
                            }
                            i = i + 1;
                        }
                    }
                    else
                    {
                        if (obj_DtJob1.Rows.Count > 0)
                        {
                            if (obj_DtJob1.Rows[obj_DtJob1.Rows.Count - 1]["voutype"].ToString() == "V")
                            {
                                if (obj_DtJob1.Rows[obj_DtJob1.Rows.Count - 1]["amount"].ToString() != "")
                                {
                                    mblamount = Convert.ToDouble(obj_DtJob1.Rows[obj_DtJob1.Rows.Count - 1]["amount"].ToString());
                                }
                            }
                            else
                            {
                                if (obj_DtJob1.Rows[obj_DtJob1.Rows.Count - 1]["amount"].ToString() != "")
                                {
                                    mblexpense = Convert.ToDouble(obj_DtJob1.Rows[obj_DtJob1.Rows.Count - 1]["amount"].ToString());
                                }
                            }
                        }
                    }
                    //-------To Fetch MBL CBM or Teus-------
                    if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                    {
                        if (obj_DtJob1.Rows.Count > 0)
                        {
                            jobtype = Convert.ToInt32(obj_DtJob1.Rows[i]["jobtype"].ToString());
                       
                        obj_DtCT = obj_da_costtempobj.GetCBMTues(Convert.ToInt32(obj_DtJob1.Rows[i]["jobno"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                        } 
                        if (obj_DtCT.Rows.Count > 0)
                        {
                            if (obj_DtCT.Rows[0]["cbmtotal"].ToString() != "" & obj_DtCT.Rows[0]["Teustotal"].ToString() != "")
                            {
                                totalcbm = Convert.ToDouble(obj_DtCT.Rows[0]["cbmtotal"].ToString());
                                totaltues = Convert.ToInt32(obj_DtCT.Rows[0]["Teustotal"].ToString());
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AE" | Session["StrTranType"].ToString() == "AI")
                        {
                            jobtype = 0;
                            obj_DtCT = obj_da_costtempobj.GetCBMTues(Convert.ToInt32(obj_DtJob1.Rows[i]["jobno"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            if (obj_DtCT.Rows.Count > 0)
                            {
                                if (obj_DtCT.Rows[0][0].ToString() != "")
                                {
                                    jobchargewt = Convert.ToDouble(obj_DtCT.Rows[0][0].ToString());
                                }
                            }
                        }
                    }
                    //----Calculating BL Income & Expense from MBL Income & Expense Using CBM or Teus---
                    for (j = 0; j <= obj_DtBL.Rows.Count - 1; j++)
                    {
                        blamount = 0;
                        blexpense = 0;
                        if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                        {
                            bltues = Convert.ToInt32(obj_DtBL.Rows[j]["cont20"].ToString() + (Convert.ToInt32(obj_DtBL.Rows[j]["cont40"].ToString()) * 2));
                            blcbm = Convert.ToDouble(obj_DtBL.Rows[j]["cbm"].ToString());
                            if (mblamount != 0)
                            {
                                if (jobtype == 3)
                                {
                                    blamount = ((mblamount / totaltues) * bltues);
                                }
                                else
                                {
                                    blamount = ((mblamount / totalcbm) * blcbm);
                                }
                            }
                            if (mblexpense != 0)
                            {
                                if (jobtype == 3)
                                {
                                    blexpense = ((mblexpense / totaltues) * bltues);
                                }
                                else
                                {
                                    if (blcbm == 0)
                                    {
                                        blexpense = 0;
                                    }
                                    else if (totalcbm == 0)
                                    {
                                        blexpense = 0;
                                    }
                                    else
                                    {
                                        blexpense = ((mblexpense / totalcbm) * blcbm);
                                    }

                                }
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AE" | Session["StrTranType"].ToString() == "AI")
                        {
                            blchargewt = Convert.ToDouble(obj_DtBL.Rows[j]["chargewt"].ToString());
                            if (mblamount != 0)
                            {
                                blamount = ((mblamount / jobchargewt) * blchargewt);
                            }
                            if (mblexpense != 0)
                            {
                                blexpense = ((mblexpense / jobchargewt) * blchargewt);
                            }
                        }
                        blno = obj_DtBL.Rows[j][1].ToString();
                        if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                        {
                            if (obj_DtBL.Rows[j][2].ToString() != "" & obj_DtBL.Rows[j][3].ToString() != "")
                            {
                                cont20 = Convert.ToInt32(obj_DtBL.Rows[j][2].ToString());
                                cont40 = Convert.ToInt32(obj_DtBL.Rows[j][3].ToString());
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AE" | Session["StrTranType"].ToString() == "AI")
                        {
                            cont20 = 0;
                            cont40 = 0;
                        }
                        nomination = Convert.ToChar(obj_DtBL.Rows[j][4].ToString());
                        volume = Convert.ToDouble(obj_DtBL.Rows[j][5].ToString());
                        shipper = Convert.ToInt32(obj_DtBL.Rows[j][6].ToString());
                        consignee = Convert.ToInt32(obj_DtBL.Rows[j][7].ToString());
                        notify = Convert.ToInt32(obj_DtBL.Rows[j][8].ToString());
                        agent = Convert.ToInt32(obj_DtBL.Rows[j][9].ToString());
                        pol = Convert.ToInt32(obj_DtBL.Rows[j][10].ToString());
                        pod = Convert.ToInt32(obj_DtBL.Rows[j][11].ToString());
                        salesperson = obj_da_costtempobj.GetSalesPerson(blno, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
                        {
                            if (jobtype == 3)
                            {
                                volume = 0;
                            }
                            else
                            {
                                cont20 = 0;
                                cont40 = 0;
                            }
                        }
                        if (string.IsNullOrEmpty(Convert.ToString(blamount)))
                        {
                            blamount = 0;
                        }
                        if (string.IsNullOrEmpty(Convert.ToString(blexpense)))
                        {
                            blexpense = 0;
                        } 
                        //If IsDBNull(blamount) = True Or IsNumeric(blamount) = False Then
                        //    blamount = 0
                        //End If
                        //If IsDBNull(blexpense) = True Or IsNumeric(blexpense) = False Then
                        //    blexpense = 0
                        //End If
                        obj_da_costtempobj.InsCostingTemp(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hid_jobno.Value), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), blno, volume, cont20, cont40, blamount, blexpense, nomination, salesperson, shipper, consignee, notify, agent, pol, pod, jobtype, Convert.ToDateTime(hid_Closeddate.Value), 0);
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
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
          //  DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    if (lbl_header.Text == "Performance Revenue")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 176, "Job", "", "", Session["StrTranType"].ToString());
                    }
                    else
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 533, "Job", "", "", Session["StrTranType"].ToString());
                    }
                    break;

                case "FI":
                    if (lbl_header.Text == "Performance Revenue")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 177, "Job", "", "", Session["StrTranType"].ToString());
                    }
                    else
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 534, "Job", "", "", Session["StrTranType"].ToString());
                    }
                    break;

                case "AE":
                    if (lbl_header.Text == "Performance Revenue")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 203, "Job", "", "", Session["StrTranType"].ToString());
                    }
                    else
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 214, "Job", "", "", Session["StrTranType"].ToString());
                    }
                    break;

                case "AI":
                    if (lbl_header.Text == "Performance Revenue")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 21, "Job", "", "", Session["StrTranType"].ToString());
                    }
                    else
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 211, "Job", "", "", Session["StrTranType"].ToString());
                    }
                    break;
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