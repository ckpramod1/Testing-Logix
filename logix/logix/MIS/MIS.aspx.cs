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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using ClosedXML.Excel;

namespace logix.MIS
{
    public partial class MIS : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.MISGrd misgrdobj = new DataAccess.MISGrd();

        DataAccess.MIS Misobj = new DataAccess.MIS();
        string str_Cust = "";
        string str_TranType = "";
        string str_Branch = "";
        int branch_id, div_id, empid, custid;
        DataTable dtnew = new DataTable();
        DataTable dtemptynew = new DataTable();
        Double inamt, examt, reamt;
        int bid;
        string intport = "";
        string intcustid;
        int j;
        int liner;
        bool blr;

        DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();

        DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        double totalincome = 0, totalexpense = 0, totalretention = 0, totalincomeAE = 0, totalexpenseAE = 0, totalretentionAE = 0;
        double totalincomeFE = 0, totalexpenseFE = 0, totalretentionFE = 0, totalincomeFI = 0, totalexpenseFI = 0, totalretentionFI = 0;
        double totalincomeCHA = 0, totalexpenseCHA = 0, totalretentionCHA = 0, totalincomeFC = 0, totalexpenseFC = 0, totalretentionFC = 0;
        double totalincomeBT = 0, totalexpenseBT = 0, totalretentionBT = 0;
        double totalincomegrand = 0, totalexpensegrand = 0, totalretentiongrand = 0, totalgrandvou = 0, totalgrand20 = 0, totalgrand40 = 0;
        double totalvou = 0, total20 = 0, total40 = 0; double temp2 = 0; double tempgrwt = 0; double totalvouwgt = 0;

        DataTable dt_MenuRights = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}


           // ClientScript.RegisterStartupScript(GetType(), "Load", "changeRule('txt_Filter');", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(bnt_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export_Details);

            //Hlbl1.Visible = false;
            //Hlbl2.Visible = false;
            if (ddl_product.Text != "" && ddl_product.Text != "0")
            {
                if (ddl_product.Text == "Ocean Exports")
                {
                    Session["StrTranType"] = "FE";
                    //StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Ocean Imports")
                {
                    Session["StrTranType"] = "FI";
                    // StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Air Exports")
                {
                    Session["StrTranType"] = "AE";
                    // StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Air Imports")
                {
                    Session["StrTranType"] = "AI";
                    // StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "CHA")
                {
                    Session["StrTranType"] = "CH";
                    // StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Bonded Trucking")
                {
                    Session["StrTranType"] = "BT";
                    // StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "ALL")
                {
                    Session["StrTranType"] = "AC";
                    // StrTranType = Session["StrTranType"].ToString();
                }

            }


            /*  if (Session["StrTranType"] != null)
              {
                  Hlbl1.Visible = false;
                  Hlbl2.Visible = false;
                  if (Session["StrTranType"].ToString() == "FE")
                  {
                      Hlbl1.Visible = true;
                      Hlbl2.Visible = true;
                      HeaderLabel1.InnerText = "Ocean Exports";
                  }
                  else if (Session["StrTranType"].ToString() == "FI")
                  {
                      Hlbl1.Visible = true;
                      Hlbl2.Visible = true;
                      HeaderLabel1.InnerText = "Ocean Imports";
                  }
                  else if (Session["StrTranType"].ToString() == "AE")
                  {
                      Hlbl1.Visible = true;
                      Hlbl2.Visible = true;
                      HeaderLabel1.InnerText = "Air Exports";
                  }
                  else if (Session["StrTranType"].ToString() == "AI")
                  {
                      Hlbl1.Visible = true;
                      Hlbl2.Visible = true;
                      HeaderLabel1.InnerText = "Air Imports";
                  }
                  else if (Session["StrTranType"].ToString() == "CH")
                  {
                      Hlbl1.Visible = true;
                      Hlbl2.Visible = true;
                      HeaderLabel1.InnerText = "Custom House Agent";
                  }
                  else if (Session["StrTranType"].ToString() == "AC")
                  {
                      Hlbl1.Visible = true;
                      Hlbl2.Visible = true;
                      HeaderLabel1.InnerText = "Accounts";
                  }
              }
              else
              {
                  Hlbl1.Visible = false;
                  Hlbl2.Visible = false;
              }*/
            if (!IsPostBack)
            {


                if (Session["trantype_process"] != null)
                {
                    //lblHead1.Visible = false;
                    //lblHead2.Visible = false;
                 //   dt_MenuRights = Session["trantype_process"] as DataTable;
                    dt_MenuRights = obj_UP.GetformuserrightsnewMIS(Convert.ToInt16(Session["LoginEmpId"].ToString()), "", Convert.ToInt16(Session["LoginBranchid"].ToString()), 18, "MIS");
                    ddl_product.Items.Add("");
                    if (dt_MenuRights.Rows.Count > 0)
                    {
                        ddl_product.Items.Add("ALL");
                    }
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
                        {
                            ddl_product.Items.Add("CHA");
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
                        {
                            ddl_product.Items.Add("Bonded Trucking");
                        }

                    }


                    // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                }
                else
                    if (Session["StrTranType"] != null)
                    {
                        ddl_product.Items.Add("");
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                            //ddl_product.SelectedIndex = 1;
                            ddl_product.SelectedValue = "Ocean Exports";
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                            ddl_product.SelectedValue = "Ocean Imports";
                            //ddl_product.SelectedIndex = 1;
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                            ddl_product.SelectedValue = "Air Exports";
                            //ddl_product.SelectedIndex = 1;
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                            ddl_product.SelectedValue = "Air Imports";
                        }

                        else if (Session["StrTranType"].ToString() == "AC")
                        {
                            ddl_product.Items.Add("ALL");
                            ddl_product.SelectedValue = "ALL";
                            ddl_product_SelectedIndexChanged(sender, e);
                        }
                        else if (Session["StrTranType"].ToString() == "CH")
                        {
                            ddl_product.Items.Add("CHA");
                            ddl_product.SelectedValue = "CHA";
                            ddl_product_SelectedIndexChanged(sender, e);
                        }
                        else if (Session["StrTranType"].ToString() == "BT")
                        {
                            ddl_product.Items.Add("Bonded Trucking");
                            ddl_product.SelectedValue = "Bonded Trucking";
                            ddl_product_SelectedIndexChanged(sender, e);
                        }
                        ddl_product.Enabled = false;
                        //ddl_product.SelectedIndex = 1;
                    }




                /*  if (Session["StrTranType"] != null)
                  {
                      if (Session["StrTranType"].ToString() == "FE")
                      {
                          HeaderLabel1.InnerText = "Ocean Exports";
                      }
                      else if (Session["StrTranType"].ToString() == "FI")
                      {
                          HeaderLabel1.InnerText = "Ocean Imports";
                      }
                      else if (Session["StrTranType"].ToString() == "AE")
                      {
                          HeaderLabel1.InnerText = "Air Exports";
                      }
                      else if (Session["StrTranType"].ToString() == "AI")
                      {
                          HeaderLabel1.InnerText = "Air Imports";
                      }
                      else if (Session["StrTranType"].ToString() == "CH")
                      {
                          HeaderLabel1.InnerText = "Custom House Agent";
                      }
                      else if (Session["StrTranType"].ToString() == "AC")
                      {
                          HeaderLabel1.InnerText = "Accounts";
                      }

                      //if (Session["StrTranType"].ToString() != null)
                      //{
                      //    ddl_product.Enabled = false;
                      //    LoadReportDDL();
                      //}
                  }
                  */
                //txt_Filter.Attributes.Add("OnKeypress", "Set_id();");
                hf_date.Value = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_From.Text = hf_date.Value;
                txt_To.Text = hf_date.Value;
                string str_CtrlLists = "txt_From~txt_To";
                btn_Get.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");


                EnableFilter();
                GridClear();
                lbl_MISA.Visible = false;
                lbl_MISB.Visible = false;
                lbl_MISC.Visible = false;
                lbl_MISD.Visible = false;
                btn_Export.Enabled = false;
            }
            else if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }
        }
        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;

        }
        private void LoadReportDDL()
        {
            try
            {
                ddl_Report.Items.Clear();
                string transtype = Session["StrTranType"].ToString();
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI" || Session["StrTranType"].ToString() == "AC" || Session["StrTranType"].ToString()=="BT")
                {
                    //  ddl_Report.ForeColor = System.Drawing.Color.Black;
                    //ddl_Report.Items.Add("REPORT");
                    ddl_Report.Items.Add("Agentwise");
                    ddl_Report.Items.Add("Consigneewise");
                    ddl_Report.Items.Add("FreeHand");
                    ddl_Report.Items.Add("Jobwise Costing");
                    ddl_Report.Items.Add("Loss Jobs");
                    ddl_Report.Items.Add("LinerWise");
                    ddl_Report.Items.Add("M I S");
                    ddl_Report.Items.Add("Nomination");
                    ddl_Report.Items.Add("Nomination Vs Freehand");
                    ddl_Report.Items.Add("Operating Profit");
                    ddl_Report.Items.Add("Port Of Discharge");
                    ddl_Report.Items.Add("Port Of Loading");

                    if (Session["StrTranType"].ToString() != "AC")
                    {
                        ddl_Report.Items.Add("Year M I S");
                        ddl_Report.Items.Add("Retention for N / F");
                        ddl_Report.Items.Add("Trend Analysis - Customer");
                    }
                    ddl_Report.Items.Add("Sales Person");
                    ddl_Report.Items.Add("Shipment Details");
                    ddl_Report.Items.Add("Shipperwise");
                    ddl_Report.Items.Add("Top 50 Shipper / Consignee");
                    ddl_Report.Items.Add("Trend Analysis - Sales Person");
                    ddl_Report.Items.Add("Trend Analysis - Product");
                    ddl_Report.Items.Add("Trend Analysis - Customer With Volume");
                    if (Session["StrTranType"].ToString() == "AC")
                    {
                        ddl_Report.Items.Add("Trend Analysis - Customer With Product");
                    }
                }
                else if (Session["StrTranType"].ToString() == "CH" || Session["StrTranType"].ToString() == "CO")
                {
                    // ddl_Report.ForeColor = System.Drawing.Color.Black;
                    //ddl_Report.Items.Add("REPORT");
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        ddl_Report.Items.Add("Agentwise");
                        ddl_Report.Items.Add("Consigneewise");
                        ddl_Report.Items.Add("FreeHand");
                        ddl_Report.Items.Add("Jobwise Costing");
                        ddl_Report.Items.Add("Loss Jobs");
                        ddl_Report.Items.Add("LinerWise");
                        ddl_Report.Items.Add("M I S");
                        ddl_Report.Items.Add("Nomination");
                        ddl_Report.Items.Add("Nomination Vs Freehand");
                        ddl_Report.Items.Add("Operating Profit");
                        ddl_Report.Items.Add("Port Of Discharge");
                        ddl_Report.Items.Add("Port Of Loading");
                        ddl_Report.Items.Add("Retention for N / F");
                        ddl_Report.Items.Add("Sales Person");
                        ddl_Report.Items.Add("Shipment Details");
                        ddl_Report.Items.Add("Shipperwise");
                        ddl_Report.Items.Add("Top 50 Shipper / Consignee");
                        ddl_Report.Items.Add("Year M I S");

                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        ddl_Report.Items.Add("Consigneewise");
                        ddl_Report.Items.Add("Jobwise Costing");
                        ddl_Report.Items.Add("Loss Jobs");
                        ddl_Report.Items.Add("LinerWise");
                        ddl_Report.Items.Add("M I S");
                        ddl_Report.Items.Add("Nomination Vs Freehand");
                        ddl_Report.Items.Add("Operating Profit");
                        ddl_Report.Items.Add("Port Of Discharge");
                        ddl_Report.Items.Add("Port Of Loading");
                        ddl_Report.Items.Add("Sales Person");
                        ddl_Report.Items.Add("Shipment Details");
                        ddl_Report.Items.Add("Shipperwise");
                        ddl_Report.Items.Add("Top 50 Shipper / Consignee");
                        ddl_Report.Items.Add("Year M I S");

                    }



                }
                else if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "FC  ")
                {
                    // ddl_Report.ForeColor = System.Drawing.Color.Black;
                    //ddl_Report.Items.Add("REPORT");
                    ddl_Report.Items.Add("Agentwise");
                    ddl_Report.Items.Add("CAN Report");
                    ddl_Report.Items.Add("CAN Report AI");
                    ddl_Report.Items.Add("Consigneewise");
                    ddl_Report.Items.Add("DO Register");
                    ddl_Report.Items.Add("DO Register Report");
                    ddl_Report.Items.Add("ForwarderWise - Imports");
                    ddl_Report.Items.Add("FreeHand");
                    ddl_Report.Items.Add("Jobwise Costing");
                    ddl_Report.Items.Add("Loss Jobs");
                    ddl_Report.Items.Add("LinerWise");
                    ddl_Report.Items.Add("M I S");
                    ddl_Report.Items.Add("Nomination");
                    ddl_Report.Items.Add("Nomination Vs Freehand");
                    ddl_Report.Items.Add("Operating Profit");
                    ddl_Report.Items.Add("Port Of Discharge");
                    ddl_Report.Items.Add("Port Of Loading");
                    ddl_Report.Items.Add("Retention for N / F");
                    ddl_Report.Items.Add("Revenue");
                    ddl_Report.Items.Add("Sales Person");
                    ddl_Report.Items.Add("Shipment Details");
                    ddl_Report.Items.Add("Shipperwise");
                    ddl_Report.Items.Add("Top 50 Shipper / Consignee");
                    ddl_Report.Items.Add("Trend Analysis - Sales Person");
                    ddl_Report.Items.Add("Trend Analysis - Customer With Product");
                    ddl_Report.Items.Add("Trend Analysis - Product");
                    ddl_Report.Items.Add("Year M I S");
                }
                //List<ListItem> li = new List<ListItem>();
                //foreach (ListItem list in ddl_Report.Items)
                //{
                //    li.Add(list);
                //}
                //li.Sort((x, y) => string.Compare(x.Text, y.Text));
                //ddl_Report.Items.Clear();
                //ddl_Report.DataSource = li;
                //ddl_Report.DataBind();
                btn_Export.Enabled = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        protected void btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                //GridClear();
                if (ddl_Report.SelectedItem.Text == "Nomination Vs Freehand")
                {
                    btn_Export_Details.Visible = false;
                    btn_Print.Visible = false;
                }
                else if (ddl_Report.Text == "Quotation - Customerwise")
                {
                    btn_Export_Details.Visible = false;
                    btn_Print.Visible = false;

                }
                else if (ddl_Report.Text == "Trend Analysis - Customer With Volume")
                {
                    btn_Export_Details.Visible = false;
                    btn_Print.Visible = false;
                }
                else if (ddl_Report.Text == "Top 50 Shipper / Consignee")
                {
                    btn_Export_Details.Visible = false;
                    btn_Print.Visible = false;
                }
                else
                {
                    btn_Export_Details.Visible = true;
                    btn_Print.Visible = true;
                }
                Get_grid();
                btn_Get.Focus();
               // bnt_cancel.Text = "Cancel";

                bnt_cancel.ToolTip = "Cancel";
                bnt_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void Get_grid()
        {
            if (GRD_Common.Visible == true)
            {
                GRD_Common.Visible = false;
            }
            if (ddl_Report.SelectedItem.Text == "Agentwise")
            {
                ddl_graph1.Enabled = true;
                str_Cust = "AG";
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_AgentWise();
            }
            else if (ddl_Report.SelectedItem.Text == "Shipperwise")
            {
                ddl_graph1.Enabled = true;
                str_Cust = "SH";
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_ShipperWise();
            }
            else if (ddl_Report.SelectedItem.Text == "Consigneewise")
            {
                ddl_graph1.Enabled = true;
                str_Cust = "CO";
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_ConsigneeWise();
            }
            else if (ddl_Report.SelectedItem.Text == "Jobwise Costing")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_JobwiseCosting();

            }
            else if (ddl_Report.SelectedItem.Text == "Shipment Details")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_ShipmentDtls();
            }
            else if (ddl_Report.SelectedValue == "Operating Profit")
            {
                ddl_graph1.Enabled = true;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                str_Cust = "CO";
                //Chart1.Visible = true;
                fn_OprProfit();
            }
            else if (ddl_Report.SelectedItem.Text == "Port Of Loading")
            {
                ddl_graph1.Enabled = true;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_PortOfLoading();
            }
            else if (ddl_Report.SelectedItem.Text == "Port Of Discharge")
            {
                ddl_graph1.Enabled = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_PortOfDischarge();
            }
            else if (ddl_Report.SelectedItem.Text == "Sales Person")
            {
                ddl_graph1.Enabled = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_Salesperson();
            }
            else if (ddl_Report.SelectedItem.Text == "Nomination Vs Freehand")
            {
                ddl_graph1.Enabled = true;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_FreehandVsNomination();
            }
            else if (ddl_Report.SelectedItem.Text == "Nomination")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_Nomination("N");
            }
            else if (ddl_Report.SelectedItem.Text == "FreeHand")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_Nomination("F");
            }
            else if (ddl_Report.SelectedItem.Text == "Loss Jobs")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_Lossjob();
            }
            else if (ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = false;
                btn_Print.ForeColor = System.Drawing.Color.Gray;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_Shipperconsignee();
            }
            else if (ddl_Report.SelectedItem.Text == "Year M I S")
            {
                ddl_graph1.Enabled = false;
                btn_Print.Enabled = false;
                btn_Print.ForeColor = System.Drawing.Color.Gray;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_YearMIS();
            }
            else if (ddl_Report.SelectedItem.Text == "Trend Analysis - Customer With Product")
            {
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = false;
                btn_Print.ForeColor = System.Drawing.Color.Gray;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_TrendCustomer();
            }
            else if (ddl_Report.SelectedItem.Text == "Trend Analysis - Customer")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = false;
                btn_Print.ForeColor = System.Drawing.Color.Gray;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_TrendCustomer();
            }
            else if (ddl_Report.SelectedItem.Text == "Trend Analysis - Customer With Volume")
            {
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = false;
                btn_Print.ForeColor = System.Drawing.Color.Gray;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_TrendCustomerVolume();
            }
            else if (ddl_Report.SelectedItem.Text == "Trend Analysis - Sales Person")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                btn_Print.Enabled = false;
                btn_Print.ForeColor = System.Drawing.Color.Gray;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_TrendSalesperson();
            }
            else if (ddl_Report.SelectedItem.Text == "Trend Analysis - Product")
            {
                ddl_graph1.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;

                btn_Print.Enabled = false;
                btn_Print.ForeColor = System.Drawing.Color.Gray;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_TrendProduct();
            }
            else if (ddl_Report.SelectedItem.Text == "M I S")
            {
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;

                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_MIS();
            }
            else if (ddl_Report.SelectedItem.Text == "Retention for N / F")
            {
                btn_Print.Enabled = true;
                btn_Print.ForeColor = System.Drawing.Color.White;
                btn_Export.Enabled = true;
                btn_Export.ForeColor = System.Drawing.Color.White;
                fn_Retention();
            }
            else if (ddl_Report.SelectedItem.Text == "CAN Report")
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "CAN Report", "alertify.alert('please Use Export To Excel Button');", true);
            }
            else if (ddl_Report.SelectedItem.Text == "CAN Report AI")
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "CAN Report", "alertify.alert('please Use Export To Excel Button');", true);
            }
            else if (ddl_Report.SelectedItem.Text == "DO Register Report")
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "CAN Report", "alertify.alert('please Use Export To Excel Button');", true);
            }
            else if (ddl_Report.SelectedItem.Text == "Revenue")
            {
                fn_revenue();
                btn_Print.Enabled = false;
                btn_Print.ForeColor = System.Drawing.Color.Gray;

            }
            else if (ddl_Report.SelectedItem.Text == "DO Register")
            {
                fn_DoRegister();
            }
            else if (ddl_Report.SelectedItem.Text == "ForwarderWise - Imports")
            {
                fn_forward();
            }
            else if (ddl_Report.SelectedItem.Text == "LinerWise")
            {
                fn_linerwise();
            }
            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 105, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Get");
                    break;
                case "FI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 106, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Get");
                    break;
                case "AE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 107, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Get");
                    break;
                case "AI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 108, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Get");
                    break;
                case "AC":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 262, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Get");
                    break;
                case "CH":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 109, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Get");
                    break;
            }
        }

        public void fn_linerwise()
        {
            try
            {
                str_TranType = "";
                str_Branch = "";
                DataTable dt_Liner = new DataTable();
                DataTable dtemptyfree = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                if (hidId.Value == "")
                {
                    hidId.Value = "0";
                }
                dt_Liner = da_obj_misgrd.GetLinerDetails(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToInt32(hidId.Value));

                if (dt_Liner.Rows.Count > 0)
                {
                    double totalgrand40 = 0, totalgrand20 = 0, totalgrandvou = 0, totalincomegrand = 0, totalexpensegrand = 0, totalretentiongrand = 0;

                    dtemptyfree.Columns.Add("trantype");
                    dtemptyfree.Columns.Add("jobno");
                    dtemptyfree.Columns.Add("linername");
                    dtemptyfree.Columns.Add("nomination");
                    dtemptyfree.Columns.Add("volume");
                    dtemptyfree.Columns.Add("cont20");
                    dtemptyfree.Columns.Add("cont40");
                    dtemptyfree.Columns.Add("income");
                    dtemptyfree.Columns.Add("expense");
                    dtemptyfree.Columns.Add("retention");
                    dtemptyfree.Columns.Add("branchid");


                    DataView dv_co = new DataView(dt_Liner);
                    dtnew = dv_co.ToTable(true, "trantype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "trantype";
                    dtnew = dv_co.ToTable();
                    DataRow dr = dtemptyfree.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;
                        DataTable dtLi = new DataTable();
                        DataView data1 = dt_Liner.DefaultView;
                        data1.RowFilter = "trantype = '" + dtnew.Rows[j]["trantype"] + "' ";
                        dtLi = data1.ToTable();
                        // count1=dtLi.Rows.Count;
                        if (dtLi.Rows.Count > 0)
                        {

                            dr = dtemptyfree.NewRow();
                            dr["trantype"] = dtLi.Rows[0]["TrantypeFull"].ToString();
                            dr["jobno"] = "";
                            dr["linername"] = "";
                            dr["nomination"] = "";
                            dr["volume"] = "";
                            dr["cont20"] = "";
                            dr["cont40"] = "";
                            dr["income"] = "";
                            dr["expense"] = "";
                            dr["retention"] = "";
                            dr["branchid"] = "";

                            dtemptyfree.Rows.Add(dr);

                            //dtemptyfree.Rows.Add();

                            for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                            {

                                dr = dtemptyfree.NewRow();
                                dtemptyfree.Rows.Add();
                                int count = dtemptyfree.Rows.Count - 1;
                                dtemptyfree.Rows[count]["trantype"] = dtLi.Rows[i]["trantype"].ToString();
                                dtemptyfree.Rows[count]["jobno"] = dtLi.Rows[i]["jobno"].ToString();
                                dtemptyfree.Rows[count]["linername"] = dtLi.Rows[i]["linername"].ToString();
                                dtemptyfree.Rows[count]["nomination"] = dtLi.Rows[i]["nomination"].ToString();
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["volume"].ToString());
                                dtemptyfree.Rows[count]["volume"] = temp2.ToString("#,0.00");
                                totalvou = totalvou + Convert.ToDouble(dtemptyfree.Rows[count]["volume"].ToString());

                                dtemptyfree.Rows[count]["cont20"] = dtLi.Rows[i]["cont20"].ToString();
                                total20 = total20 + Convert.ToDouble(dtLi.Rows[i]["cont20"].ToString());
                                dtemptyfree.Rows[count]["cont40"] = dtLi.Rows[i]["cont40"].ToString();
                                total40 = total40 + Convert.ToDouble(dtLi.Rows[i]["cont40"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["income"].ToString());
                                dtemptyfree.Rows[count]["income"] = temp2.ToString("#,0.00");
                                totalincome = totalincome + Convert.ToDouble(dtemptyfree.Rows[count]["income"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["expense"].ToString());
                                dtemptyfree.Rows[count]["expense"] = temp2.ToString("#,0.00");

                                totalexpense = totalexpense + Convert.ToDouble(dtemptyfree.Rows[count]["expense"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["retention"].ToString());
                                dtemptyfree.Rows[count]["retention"] = temp2.ToString("#,0.00");

                                totalretention = totalretention + Convert.ToDouble(dtemptyfree.Rows[count]["retention"].ToString());
                                dtemptyfree.Rows[count]["branchid"] = dtLi.Rows[i]["branchid"].ToString();
                            }


                            dr = dtemptyfree.NewRow();
                            dr["nomination"] = dtnew.Rows[j]["trantype"] + "-" + "Total";
                            dr["volume"] = totalvou;
                            dr["cont20"] = total20;
                            dr["cont40"] = total40;
                            dr["income"] = totalincome.ToString("#,0.00");
                            dr["expense"] = totalexpense.ToString("#,0.00");
                            dr["retention"] = totalretention.ToString("#,0.00");
                        }
                        dtemptyfree.Rows.Add(dr);
                        totalgrand40 += total40;
                        totalgrand20 += total20;
                        totalgrandvou += totalvou;
                        totalincomegrand += totalincome;
                        totalexpensegrand += totalexpense;
                        totalretentiongrand += totalretention;

                    }
                    dr = dtemptyfree.NewRow();
                    if (dt_Liner.Rows.Count > 0)
                    {
                        dr["nomination"] = "Grand Total";
                        dr["volume"] = totalgrandvou.ToString("#,0.00");
                        dr["cont20"] = totalgrand20;
                        dr["cont40"] = totalgrand40;
                        dr["income"] = totalincomegrand.ToString("#,0.00");
                        dr["expense"] = totalexpensegrand.ToString("#,0.00");
                        dr["retention"] = totalretentiongrand.ToString("#,0.00");
                        dtemptyfree.Rows.Add(dr);
                        Gridliner.Visible = true;
                        Gridliner.DataSource = dtemptyfree;
                        Gridliner.DataBind();
                     //   bnt_cancel.Text = "Cancel";

                        bnt_cancel.ToolTip = "Cancel";
                        bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                        btn_Export.Enabled = true;
                        //grd_Shipment.Rows[grd_Agent.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_revenue()
        {
            try
            {
                int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string trantype = Session["StrTranType"].ToString();
                DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
                DataTable obj_dtjob = new DataTable();
                DataTable obj_dt = new DataTable();
                obj_dtjob = costtempobj.GetRevenueRpt(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
                if (obj_dtjob.Rows.Count > 0)
                {
                    obj_dt.Columns.Add("Job Type", typeof(string));
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("VslVoy", typeof(string));
                    obj_dt.Columns.Add("MBL #", typeof(string));
                    obj_dt.Columns.Add("Fh BL#", typeof(string));
                    obj_dt.Columns.Add("Fh CBM", typeof(string));
                    obj_dt.Columns.Add("Nom BL#", typeof(string));
                    obj_dt.Columns.Add("Nom CBM", typeof(string));
                    obj_dt.Columns.Add("Teus", typeof(string));
                    obj_dt.Columns.Add("Container #", typeof(string));
                    obj_dt.Columns.Add("Income", typeof(string));

                    DataRow dr = obj_dt.NewRow();
                    for (int i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);

                        dr[0] = obj_dtjob.Rows[i]["jobtype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[2] = obj_dtjob.Rows[i]["vslvoy"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["mblno"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["freebl"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["freecbm"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["nombl"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["nomcbm"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["tues"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["cntrdtls"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["income"].ToString();

                    }
                    var sum_freecbm = obj_dtjob.Compute("sum(freecbm)", "");
                    var sum_nomcbm = obj_dtjob.Compute("sum(nomcbm)", "");
                    var sum_tues = obj_dtjob.Compute("sum(tues)", "");
                    var sum_income = obj_dtjob.Compute("sum(income)", "");

                    //DataRow dr1 = obj_dt.NewRow();
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[4] = "Total";
                    dr[5] = sum_freecbm;
                    dr[7] = sum_nomcbm;
                    dr[8] = sum_tues;
                    dr[10] = sum_income;

                    GRD_Revenue.Visible = true;
                    GRD_Revenue.DataSource = obj_dt;
                    GRD_Revenue.DataBind();
                   // bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    //GRD_Revenue.Rows[grd_Agent.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Revenue", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_forward()
        {
            try
            {
                int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string trantype = Session["StrTranType"].ToString();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                DataTable obj_dtjob = new DataTable();
                DataTable obj_dt = new DataTable();
                int count;
                obj_dtjob = da_obj_misgrd.GetForwarder(trantype, bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
                if (obj_dtjob.Rows.Count > 0)
                {
                    double total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0, total6 = 0, temp2 = 0;
                    dtemptynew.Columns.Add("Job #");
                    dtemptynew.Columns.Add("Net wt");
                    dtemptynew.Columns.Add("Cont20");
                    dtemptynew.Columns.Add("Cont40");
                    dtemptynew.Columns.Add("Income");
                    dtemptynew.Columns.Add("Expense");
                    dtemptynew.Columns.Add("Retention");
                    DataRow dr = dtemptynew.NewRow();
                    for (int i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        dr = dtemptynew.NewRow();
                        dtemptynew.Rows.Add();
                        count = dtemptynew.Rows.Count - 1;
                        dtemptynew.Rows[count]["Job #"] = obj_dtjob.Rows[i]["jobno"].ToString();
                        temp2 = Convert.ToDouble(obj_dtjob.Rows[i]["Netwt"].ToString());
                        dtemptynew.Rows[count]["Net wt"] = temp2.ToString("#,0.00");
                        total1 = total1 + Convert.ToDouble(dtemptynew.Rows[count]["Net wt"]);

                        temp2 = Convert.ToDouble(obj_dtjob.Rows[i]["cont20"].ToString());
                        dtemptynew.Rows[count]["Cont20"] = temp2.ToString();
                        total2 = total2 + Convert.ToDouble(dtemptynew.Rows[count]["Cont20"]);

                        temp2 = Convert.ToDouble(obj_dtjob.Rows[i]["cont40"].ToString());
                        dtemptynew.Rows[count]["Cont40"] = temp2.ToString();
                        total3 = total3 + Convert.ToDouble(dtemptynew.Rows[count]["Cont40"]);

                        temp2 = Convert.ToDouble(obj_dtjob.Rows[i]["income"].ToString());
                        dtemptynew.Rows[count]["Income"] = temp2.ToString("#,0.00");
                        total4 = total4 + Convert.ToDouble(dtemptynew.Rows[count]["Income"].ToString());

                        temp2 = Convert.ToDouble(obj_dtjob.Rows[i]["expense"].ToString());
                        dtemptynew.Rows[count]["Expense"] = temp2.ToString("#,0.00");
                        total5 = total5 + Convert.ToDouble(dtemptynew.Rows[count]["Expense"].ToString());

                        temp2 = Convert.ToDouble(obj_dtjob.Rows[i]["retention"].ToString());
                        dtemptynew.Rows[count]["Retention"] = temp2.ToString("#,0.00");
                        total6 = total6 + Convert.ToDouble(dtemptynew.Rows[count]["Retention"].ToString());
                    }
                    dr = dtemptynew.NewRow();
                    dr["Job #"] = "Total";
                    dr["Net wt"] = total1.ToString("#,0.00");
                    dr["Cont20"] = total2.ToString();// ("#,0.00");
                    dr["Cont40"] = total3.ToString();// ("#,0.00");
                    dr["Income"] = total4.ToString("#,0.00");
                    dr["Expense"] = total5.ToString("#,0.00");
                    dr["Retention"] = total6.ToString("#,0.00");
                    dtemptynew.Rows.Add(dr);

                    GRD_Forward.DataSource = dtemptynew;
                    GRD_Forward.DataBind();
                    GRD_Forward.Visible = true;
                    //bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    //GRD_Forward.Rows[grd_Agent.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Forward", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public void fn_DoRegister()
        {
            try
            {
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                DataTable Dtshipdtls = new DataTable();
                DataTable dtemptynew = new DataTable();
                DataTable dtnew = new DataTable();
                double GrandTOTAL = 0;
                int count;
                int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                Dtshipdtls = da_obj_misgrd.GetDORegister(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));

                if (Dtshipdtls.Rows.Count > 0)
                {
                    dtemptynew.Columns.Add("Inv #");
                    dtemptynew.Columns.Add("BL #");
                    dtemptynew.Columns.Add("Job #");
                    dtemptynew.Columns.Add("VslVoy");
                    dtemptynew.Columns.Add("For BL#");
                    dtemptynew.Columns.Add("For Name");
                    dtemptynew.Columns.Add("Consignee");
                    dtemptynew.Columns.Add("Invoice Amt");
                    dtemptynew.Columns.Add("DO Issued On");
                    dtemptynew.Columns.Add("PoR");
                    dtemptynew.Columns.Add("PoL");
                    dtemptynew.Columns.Add("PoD");
                    dtemptynew.Columns.Add("FD");
                    DataRow dr = dtemptynew.NewRow();
                    DataView dv_co = new DataView(Dtshipdtls);
                    dtnew = dv_co.ToTable(true, "agentid", "agent");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "agent";
                    dtnew = dv_co.ToTable();

                    for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                    {
                        double total1 = 0;
                        DataTable dtdetails = new DataTable();
                        dr = dtemptynew.NewRow();
                        //dtemptynew.Rows.Add();
                        dr["Inv #"] = dtnew.Rows[0]["agent"].ToString();
                        dtemptynew.Rows.Add(dr);
                        DataView dv_co1 = new DataView(Dtshipdtls);
                        dv_co1.RowFilter = "agentid = '" + dtnew.Rows[i]["agentid"] + "'";
                        dtdetails = dv_co1.ToTable();

                        for (int k = 0; k <= dtdetails.Rows.Count - 1; k++)
                        {
                            dr = dtemptynew.NewRow();
                            dtemptynew.Rows.Add();
                            count = dtemptynew.Rows.Count - 1;
                            dtemptynew.Rows[count]["Inv #"] = dtdetails.Rows[k]["invoiceno"].ToString();
                            dtemptynew.Rows[count]["BL #"] = dtdetails.Rows[k]["blno"].ToString();
                            dtemptynew.Rows[count]["Job #"] = dtdetails.Rows[k]["jobno"].ToString();
                            dtemptynew.Rows[count]["VslVoy"] = dtdetails.Rows[k]["vslvoy"].ToString();
                            dtemptynew.Rows[count]["For BL#"] = dtdetails.Rows[k]["forwarderbl"].ToString();
                            dtemptynew.Rows[count]["For Name"] = dtdetails.Rows[k]["Forwarder"].ToString();
                            dtemptynew.Rows[count]["Consignee"] = dtdetails.Rows[k]["consignee"].ToString();
                            temp2 = Convert.ToDouble(dtdetails.Rows[k]["invamt"].ToString());
                            total1 = total1 + temp2;
                            GrandTOTAL = GrandTOTAL + temp2;
                            dtemptynew.Rows[count]["Invoice Amt"] = total1.ToString("#,0.00");
                            dtemptynew.Rows[count]["DO Issued On"] = dtdetails.Rows[k]["doissuedon"].ToString();
                            dtemptynew.Rows[count]["PoR"] = dtdetails.Rows[k]["por"].ToString();
                            dtemptynew.Rows[count]["PoL"] = dtdetails.Rows[k]["pol"].ToString();
                            dtemptynew.Rows[count]["PoD"] = dtdetails.Rows[k]["pod"].ToString();
                            dtemptynew.Rows[count]["FD"] = dtdetails.Rows[k]["fd"].ToString();
                        }
                        dr = dtemptynew.NewRow();
                        dr["Consignee"] = "Total";
                        dr["Invoice Amt"] = total1.ToString("#,0.00");
                        dtemptynew.Rows.Add(dr);
                    }

                    dr = dtemptynew.NewRow();
                    dr["Consignee"] = "Grand Total";
                    dr["Invoice Amt"] = GrandTOTAL.ToString("#,0.00");
                    dtemptynew.Rows.Add(dr);

                    GRD_DoRegister.DataSource = dtemptynew;
                    GRD_DoRegister.DataBind();
                    GRD_DoRegister.Visible = true;
                //    bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    //GRD_DoRegister.Rows[grd_Agent.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "DoRegister", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_CANREPORT()
        {
            try
            {
                int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
                DataTable dt = new DataTable();

                dt = costtempobj.GetCanRegister4Audit(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
                if (dt.Rows.Count > 0)
                {
                    GRD_CANREPORT.DataSource = dt;
                    GRD_CANREPORT.DataBind();
                    btn_Export.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "CAN Report", "alertify.alert('Data not available');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public void fn_AgentWise()
        {
            try
            {
                DataTable dt_AgentDtls = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                int did = int.Parse(Session["LoginDivisionId"].ToString());
                int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string trantype = Session["StrTranType"].ToString();
                if (txt_Filter.Text.ToString().Trim().Length > 0)
                {
                    dt_AgentDtls = da_obj_misgrd.GetShipperWiseFilterNew(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Session["StrTranType"].ToString(), str_Cust, int.Parse(hidId.Value.ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    dt_AgentDtls = da_obj_misgrd.GetShipperWiseNew(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), trantype, str_Cust, did);
                }


                if (dt_AgentDtls.Rows.Count > 0)
                {

                    /*   DataView dv_co = new DataView(dt_AgentDtls);
                       dtnew = dv_co.ToTable(true, "agentid");
                       dv_co = new DataView(dtnew);
                       dv_co.Sort = "agentid";
                       dtnew = dv_co.ToTable();

                       DataTable dtempty = new DataTable();

                       dtempty.Columns.Add("Agent");
                       dtempty.Columns.Add("Gr.wt");
                       dtempty.Columns.Add("CBM");
                       dtempty.Columns.Add("Cont20");
                       dtempty.Columns.Add("Cont40");
                       dtempty.Columns.Add("Income");
                       dtempty.Columns.Add("Expenses");
                       dtempty.Columns.Add("Retention");
                       dtempty.Columns.Add("agentid");
                       //dtempty.Columns.Add("branchid");

                       DataRow dr = dtempty.NewRow();


                       //dtemptynew.Columns.Add("Agent");
                       //dtemptynew.Columns.Add("Gr.wt");
                       //dtemptynew.Columns.Add("CBM");
                       //dtemptynew.Columns.Add("Cont20");
                       //dtemptynew.Columns.Add("Cont40");
                       //dtemptynew.Columns.Add("Income");
                       //dtemptynew.Columns.Add("Expenses");
                       //dtemptynew.Columns.Add("Retention");
                       //dtemptynew.Columns.Add("agentid");
                       //dtemptynew.Columns.Add("branchid");
                       for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                       {
                           double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0; totalvouwgt = 0;
                           DataTable dtLi = new DataTable();
                           DataView data1 = dt_AgentDtls.DefaultView;
                           string aa = dtnew.Rows[j]["agentid"].ToString().Trim();
                           data1.RowFilter = "agentid = '" + aa + "' ";
                           dtLi = data1.ToTable();   //DataView dv = new DataView(dt_jobwiseCost);



                           dr = dtempty.NewRow();
                           dtempty.Rows.Add();

                           dtempty.Rows[0]["Agent"] = dtLi.Rows[0]["agent"].ToString();// +" , " + dtLi.Rows[0]["agent"].ToString();
                           for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                           {
                               tempgrwt = Convert.ToDouble(dtLi.Rows[i]["Gr.wt"].ToString());
                               totalvouwgt = totalvouwgt + tempgrwt;
                               dtempty.Rows[0]["Gr.wt"] = totalvouwgt.ToString("#,0.00");

                               temp2 = Convert.ToDouble(dtLi.Rows[i]["CBM"].ToString());
                               totalvou = totalvou + temp2;
                               dtempty.Rows[0]["CBM"] = totalvou.ToString("#,0.00");
                               temp2 = Convert.ToInt32(dtLi.Rows[i]["cont20"].ToString());
                               total20 = total20 + temp2;
                               dtempty.Rows[0]["Cont20"] = total20.ToString();
                               temp2 = Convert.ToInt32(dtLi.Rows[i]["cont40"].ToString());
                               total40 = total40 + temp2;
                               dtempty.Rows[0]["Cont40"] = total40.ToString();

                               temp2 = Convert.ToDouble(dtLi.Rows[i]["income"].ToString());
                               totalincome = totalincome + temp2;
                               dtempty.Rows[0]["Income"] = totalincome.ToString("#,0.00");
                               temp2 = Convert.ToDouble(dtLi.Rows[i]["expense"].ToString());
                               totalexpense = totalexpense + temp2;
                               dtempty.Rows[0]["Expenses"] = totalexpense.ToString("#,0.00");

                               //totalexpense = totalexpense + Convert.ToDouble(dtempty.Rows[0]["expense"].ToString());
                               temp2 = Convert.ToDouble(dtLi.Rows[i]["retention"].ToString());
                               totalretention = totalretention + temp2;
                               dtemptynew.Rows[0]["Retention"] = totalretention.ToString("#,0.00");
                               dtempty.Rows[0]["agentid"] = dtLi.Rows[i]["agentid"].ToString();

                           }
                           //double total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0, total6 = 0, total7 = 0;
                           //temp2 = 0;
                           //tempgrwt = 0;
                           //for (int i = 0; i <= dtemptynew.Rows.Count - 1; i++)
                           //{
                           //    dr = dtempty.NewRow();
                           //    dtempty.Rows.Add();
                           //    int count = dtempty.Rows.Count - 1;
                           //    dtempty.Rows[count]["Agent"] = dtemptynew.Rows[i]["Agent"].ToString();

                           //    tempgrwt = Convert.ToDouble(dtemptynew.Rows[i]["Gr.wt"].ToString());
                           //    dtempty.Rows[count]["Gr.wt"] = tempgrwt.ToString("#,0.00");
                           //    total7 = total7 + Convert.ToDouble(dtempty.Rows[count]["Gr.wt"]);

                           //    temp2 = Convert.ToDouble(dtemptynew.Rows[i]["CBM"].ToString());
                           //    dtempty.Rows[count]["CBM"] = temp2.ToString("#,0.00");
                           //    total1 = total1 + Convert.ToDouble(dtempty.Rows[count]["CBM"]);



                           //    temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Cont20"].ToString());
                           //    dtempty.Rows[count]["Cont20"] = temp2.ToString();
                           //    total2 = total2 + Convert.ToDouble(dtempty.Rows[count]["Cont20"]);

                           //    temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Cont40"].ToString());
                           //    dtempty.Rows[count]["Cont40"] = temp2.ToString();
                           //    total3 = total3 + Convert.ToDouble(dtempty.Rows[count]["Cont40"]);

                           //    temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Income"].ToString());
                           //    dtempty.Rows[count]["Income"] = temp2.ToString("#,0.00");
                           //    total4 = total4 + Convert.ToDouble(dtempty.Rows[count]["Income"].ToString());

                           //    temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Expenses"].ToString());
                           //    dtempty.Rows[count]["Expenses"] = temp2.ToString("#,0.00");
                           //    total5 = total5 + Convert.ToDouble(dtempty.Rows[count]["Expenses"].ToString());

                           //    temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Retention"].ToString());
                           //    dtempty.Rows[count]["Retention"] = temp2.ToString("#,0.00");
                           //    total6 = total6 + Convert.ToDouble(dtempty.Rows[count]["Retention"].ToString());
                           //    dtempty.Rows[count]["agentid"] = dtemptynew.Rows[i]["agentid"].ToString();
                           //    //dtempty.Rows[count]["branchid"] = dtemptynew.Rows[i]["branchid"].ToString();
                           //}
                           //totalvouwgt += total7;
                           //totalgrandvou += total1;
                           //totalgrand20 += total2;
                           //totalgrand40 += total3;
                           //totalincomegrand += total4;
                           //totalexpensegrand += total5;
                           //totalretentiongrand += total6;
                           //dtemptynew.Clear();

                       }

                       //dr = dtempty.NewRow();
                       //dr["Agent"] = "Total";
                       //dr["Gr.wt"] = totalvouwgt.ToString("#,0.00");
                       //dr["CBM"] = totalgrandvou.ToString("#,0.00");
                       //dr["Cont20"] = totalgrand20.ToString();// ("#,0.00");
                       //dr["Cont40"] = totalgrand40.ToString();// ("#,0.00");
                       //dr["Income"] = totalincomegrand.ToString("#,0.00");
                       //dr["Expenses"] = totalexpensegrand.ToString("#,0.00");
                       //dr["Retention"] = totalretentiongrand.ToString("#,0.00");
                       //dtempty.Rows.Add(dr);*/

                    grd_Agent.DataSource = dt_AgentDtls;
                    grd_Agent.DataBind();
                    grd_Agent.Visible = true;
                    ViewState["dt_AgentDtls"] = dt_AgentDtls;


                    //   CHART  //
                    if (ddl_graph1.SelectedItem.Text == "Graph")
                    {
                        //DataTable dt = new DataTable();
                        DataTable dt_new = new DataTable();
                        //dt = (DataTable)Session["AgentWise"];
                        DataView dv = dt_AgentDtls.DefaultView;
                        dv.Sort = "retention desc";
                        DataTable sortedDT = dv.ToTable();
                        dt_new = SelectTopDataRow(sortedDT, 5);
                        div_op_char.Visible = true;
                        chartoperProfit.Visible = true;
                        string[] x = new string[dt_new.Rows.Count];
                        decimal[] y = new decimal[dt_new.Rows.Count];
                        for (int count = 0; count < dt_new.Rows.Count; count++)
                        {
                            x[count] = dt_new.Rows[count]["Agent"].ToString();
                            y[count] = Convert.ToDecimal(dt_new.Rows[count]["retention"].ToString());
                        }

                        if (ddl_graph2.SelectedItem.Text == "Line")
                        {
                            chartoperProfit.ChartAreas[0].AxisX.Title = "Agent";
                            chartoperProfit.ChartAreas[0].AxisY.Title = "Amount";

                            chartoperProfit.Series[0].Points.DataBindXY(x, y);
                            chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                            chartoperProfit.Series[0].LegendText = "Profit";
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                            grd_Agent.Visible = false;
                            piechart.Visible = false;
                            return;
                        }
                        if (ddl_graph2.SelectedItem.Text == "Bar")
                        {
                            chartoperProfit.ChartAreas[0].AxisX.Title = "Agent";
                            chartoperProfit.ChartAreas[0].AxisY.Title = "Amount";
                            chartoperProfit.Series[0].Points.DataBindXY(x, y);
                            chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                            chartoperProfit.Series[0].LegendText = "Profit";
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                            grd_Agent.Visible = false;
                            piechart.Visible = false;
                            return;
                        }
                        if (ddl_graph2.SelectedItem.Text == "Pie")
                        {
                            piechart.Legends.Clear();
                            chartoperProfit.Visible = false;
                            piechart.Visible = true;
                            piechart.Series[0].Points.DataBindXY(x, y);
                            piechart.Series[0].ChartType = SeriesChartType.Pie;
                            piechart.Series[0].Label = "#VALX (#PERCENT)";
                            //piechart.Titles.Clear();
                            //piechart.Titles.Add("SL CHENNAI");
                            piechart.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            piechart.Series[0]["PieLabelStyle"] = "Disabled";

                            grd_Agent.Visible = false;
                            return;
                        }
                    }

                //    bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    Session["ExportDatatable"] = grd_Agent;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Agentwise", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_ShipperWise()
        {
            try
            {
                DataTable dt_shipperDtls = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();

                if (txt_Filter.Text.ToString().Trim().Length > 0)
                {
                    dt_shipperDtls = da_obj_misgrd.GetShipperWiseFilterNew(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Session["StrTranType"].ToString(), str_Cust, int.Parse(hidId.Value.ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    dt_shipperDtls = da_obj_misgrd.GetShipperWiseNew(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Session["StrTranType"].ToString(), str_Cust, int.Parse(Session["LoginDivisionId"].ToString()));
                }

                if (dt_shipperDtls.Rows.Count > 0)
                {
                    /* DataRow dr_temp = dt_shipperDtls.NewRow();
                     dr_temp["Shipper"] = "Total";
                     dr_temp["Volume"] = dt_shipperDtls.Compute("sum(Volume)", "");
                     dr_temp["cont20"] = dt_shipperDtls.Compute("sum(cont20)", "");
                     dr_temp["cont40"] = dt_shipperDtls.Compute("sum(cont40)", "");
                     dr_temp["income"] = dt_shipperDtls.Compute("sum(income)", "");
                     dr_temp["Expense"] = dt_shipperDtls.Compute("sum(Expense)", "");
                     dr_temp["retention"] = dt_shipperDtls.Compute("sum(retention)", "");
                     dt_shipperDtls.Rows.Add(dr_temp);
                     */
                    grd_Shipper.Visible = true;
                    grd_Shipper.DataSource = dt_shipperDtls;
                    grd_Shipper.DataBind();

                    //   CHART  //
                    if (ddl_graph1.SelectedItem.Text == "Graph")
                    {
                        //DataTable dt = new DataTable();
                        DataTable dt_new = new DataTable();
                        //dt = (DataTable)Session["AgentWise"];
                        DataView dv = dt_shipperDtls.DefaultView;
                        dv.Sort = "retention desc";
                        DataTable sortedDT = dv.ToTable();
                        dt_new = SelectTopDataRow(sortedDT, 5);
                        div_op_char.Visible = true;
                        chartoperProfit.Visible = true;
                        string[] x = new string[dt_new.Rows.Count];
                        decimal[] y = new decimal[dt_new.Rows.Count];
                        for (int count = 0; count < dt_new.Rows.Count; count++)
                        {
                            x[count] = dt_new.Rows[count]["shipper"].ToString();
                            y[count] = Convert.ToDecimal(dt_new.Rows[count]["retention"].ToString());
                        }

                        if (ddl_graph2.SelectedItem.Text == "Line")
                        {
                            chartoperProfit.ChartAreas[0].AxisX.Title = "Shipper";
                            chartoperProfit.ChartAreas[0].AxisY.Title = "Amount";

                            chartoperProfit.Series[0].Points.DataBindXY(x, y);
                            chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                            chartoperProfit.Series[0].LegendText = "Profit";
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                            piechart.Visible = false;
                            grd_Shipper.Visible = false;
                            return;
                        }
                        if (ddl_graph2.SelectedItem.Text == "Bar")
                        {
                            chartoperProfit.ChartAreas[0].AxisX.Title = "Shipper";
                            chartoperProfit.ChartAreas[0].AxisY.Title = "Amount";
                            chartoperProfit.Series[0].Points.DataBindXY(x, y);
                            chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                            chartoperProfit.Series[0].LegendText = "Profit";
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                            piechart.Visible = false;
                            grd_Shipper.Visible = false;
                            return;
                        }
                        if (ddl_graph2.SelectedItem.Text == "Pie")
                        {
                            piechart.Legends.Clear();
                            chartoperProfit.Visible = false;
                            piechart.Visible = true;
                            piechart.Series[0].Points.DataBindXY(x, y);
                            piechart.Series[0].ChartType = SeriesChartType.Pie;
                            piechart.Series[0].Label = "#VALX (#PERCENT)";
                            //piechart.Titles.Clear();
                            //piechart.Titles.Add("SL CHENNAI");
                            piechart.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            piechart.Series[0]["PieLabelStyle"] = "Disabled";

                            grd_Shipper.Visible = false;
                            return;
                        }
                    }

                    btn_Export.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Shipperwise", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public DataTable SelectTopDataRow(DataTable dt, int count)
        {
            DataTable dtn = dt.Clone();
            for (int i = 0; i < count; i++)
            {
                if (dt.Rows[i][0].ToString() != "Total")
                {
                    dtn.ImportRow(dt.Rows[i]);
                }
            }
            return dtn;
        }

        public void fn_ConsigneeWise()
        {
            try
            {
                DataTable dt_AgentDtls = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();

                if (txt_Filter.Text.ToString().Trim().Length > 0)
                {
                    dt_AgentDtls = da_obj_misgrd.GetShipperWiseFilterNew(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Session["StrTranType"].ToString(), str_Cust, int.Parse(hidId.Value.ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    dt_AgentDtls = da_obj_misgrd.GetShipperWiseNew(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Session["StrTranType"].ToString(), str_Cust, int.Parse(Session["LoginDivisionId"].ToString()));
                }
                if (dt_AgentDtls.Rows.Count > 0)
                {
                    /*DataView dv_co = new DataView(dt_AgentDtls);
                    dtnew = dv_co.ToTable(true, "Consigneeid");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "Consigneeid";
                    dtnew = dv_co.ToTable();

                    DataTable dtempty = new DataTable();

                    dtempty.Columns.Add("Consignee");

                    dtempty.Columns.Add("Volume");
                    dtempty.Columns.Add("Cont20");
                    dtempty.Columns.Add("Cont40");
                    dtempty.Columns.Add("Income");
                    dtempty.Columns.Add("Expense");
                    dtempty.Columns.Add("Retention");
                    dtempty.Columns.Add("Consigneeid");
                    //dtempty.Columns.Add("branchid");

                    DataRow dr = dtempty.NewRow();


                    dtemptynew.Columns.Add("Consignee");

                    dtemptynew.Columns.Add("CBM/Kgs");
                    dtemptynew.Columns.Add("Cont20");
                    dtemptynew.Columns.Add("Cont40");
                    dtemptynew.Columns.Add("Income");
                    dtemptynew.Columns.Add("Expense");
                    dtemptynew.Columns.Add("Retention");
                    dtemptynew.Columns.Add("Consigneeid");
                    //dtemptynew.Columns.Add("branchid");
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;
                        DataTable dtLi = new DataTable();
                        DataView data1 = dt_AgentDtls.DefaultView;
                        string aa = dtnew.Rows[j]["Consigneeid"].ToString().Trim();
                        data1.RowFilter = "Consigneeid = '" + aa + "' ";
                        dtLi = data1.ToTable();   //DataView dv = new DataView(dt_jobwiseCost);



                        dr = dtemptynew.NewRow();
                        dtemptynew.Rows.Add();

                        dtemptynew.Rows[0]["Consignee"] = dtLi.Rows[0]["consignee"].ToString();// +" , " + dtLi.Rows[0]["agent"].ToString();
                        for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {

                            temp2 = Convert.ToDouble(dtLi.Rows[i]["volume"].ToString());
                            totalvou = totalvou + temp2;
                            dtemptynew.Rows[0]["CBM/Kgs"] = totalvou.ToString("#,0.00");
                            temp2 = Convert.ToInt32(dtLi.Rows[i]["cont20"].ToString());
                            total20 = total20 + temp2;
                            dtemptynew.Rows[0]["Cont20"] = total20.ToString();
                            temp2 = Convert.ToInt32(dtLi.Rows[i]["cont40"].ToString());
                            total40 = total40 + temp2;
                            dtemptynew.Rows[0]["Cont40"] = total40.ToString();

                            temp2 = Convert.ToDouble(dtLi.Rows[i]["income"].ToString());
                            totalincome = totalincome + temp2;
                            dtemptynew.Rows[0]["Income"] = totalincome.ToString("#,0.00");
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["expense"].ToString());
                            totalexpense = totalexpense + temp2;
                            dtemptynew.Rows[0]["Expense"] = totalexpense.ToString("#,0.00");

                            //totalexpense = totalexpense + Convert.ToDouble(dtempty.Rows[0]["expense"].ToString());
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["retention"].ToString());
                            totalretention = totalretention + temp2;
                            dtemptynew.Rows[0]["Retention"] = totalretention.ToString("#,0.00");
                            dtemptynew.Rows[0]["Consigneeid"] = dtLi.Rows[i]["Consigneeid"].ToString();
                            //dtemptynew.Rows[0]["branchid"] = dtLi.Rows[i]["branchid"].ToString();
                            //dtempty.Rows.Add(dr);
                        }
                        double total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0, total6 = 0;
                        temp2 = 0;
                        for (int i = 0; i <= dtemptynew.Rows.Count - 1; i++)
                        {
                            dr = dtempty.NewRow();
                            dtempty.Rows.Add();
                            int count = dtempty.Rows.Count - 1;
                            dtempty.Rows[count]["Consignee"] = dtemptynew.Rows[i]["Consignee"].ToString();
                            temp2 = Convert.ToDouble(dtemptynew.Rows[i]["CBM/Kgs"].ToString());
                            dtempty.Rows[count]["Volume"] = temp2.ToString("#,0.00");
                            total1 = total1 + Convert.ToDouble(dtempty.Rows[count]["Volume"]);

                            temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Cont20"].ToString());
                            dtempty.Rows[count]["Cont20"] = temp2.ToString();
                            total2 = total2 + Convert.ToDouble(dtempty.Rows[count]["Cont20"]);

                            temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Cont40"].ToString());
                            dtempty.Rows[count]["Cont40"] = temp2.ToString();
                            total3 = total3 + Convert.ToDouble(dtempty.Rows[count]["Cont40"]);

                            temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Income"].ToString());
                            dtempty.Rows[count]["Income"] = temp2.ToString("#,0.00");
                            total4 = total4 + Convert.ToDouble(dtempty.Rows[count]["Income"].ToString());

                            temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Expense"].ToString());
                            dtempty.Rows[count]["Expense"] = temp2.ToString("#,0.00");
                            total5 = total5 + Convert.ToDouble(dtempty.Rows[count]["Expense"].ToString());

                            temp2 = Convert.ToDouble(dtemptynew.Rows[i]["Retention"].ToString());
                            dtempty.Rows[count]["Retention"] = temp2.ToString("#,0.00");
                            total6 = total6 + Convert.ToDouble(dtempty.Rows[count]["Retention"].ToString());
                            dtempty.Rows[count]["Consigneeid"] = dtemptynew.Rows[i]["Consigneeid"].ToString();
                            //dtempty.Rows[count]["branchid"] = dtemptynew.Rows[i]["branchid"].ToString();
                        }

                        totalgrandvou += total1;
                        totalgrand20 += total2;
                        totalgrand40 += total3;
                        totalincomegrand += total4;
                        totalexpensegrand += total5;
                        totalretentiongrand += total6;
                        dtemptynew.Clear();

                    }

                    dr = dtempty.NewRow();
                    dr["Consignee"] = "Total";
                    dr["Volume"] = totalgrandvou.ToString("#,0.00");
                    dr["Cont20"] = totalgrand20.ToString();// ("#,0.00");
                    dr["Cont40"] = totalgrand40.ToString();// ("#,0.00");
                    dr["Income"] = totalincomegrand.ToString("#,0.00");
                    dr["Expense"] = totalexpensegrand.ToString("#,0.00");
                    dr["Retention"] = totalretentiongrand.ToString("#,0.00");
                    dtempty.Rows.Add(dr);
                    */
                    grd_Consignee.DataSource = dt_AgentDtls;
                    grd_Consignee.DataBind();
                    grd_Consignee.Visible = true;

                    ViewState["Consigneewise"] = dt_AgentDtls;

                    //   CHART  //
                    if (ddl_graph1.SelectedItem.Text == "Graph")
                    {
                        //DataTable dt = new DataTable();
                        DataTable dt_new = new DataTable();
                        //dt = (DataTable)Session["AgentWise"];
                        DataView dv = dt_AgentDtls.DefaultView;
                        dv.Sort = "retention desc";
                        DataTable sortedDT = dv.ToTable();
                        dt_new = SelectTopDataRow(sortedDT, 5);
                        div_op_char.Visible = true;
                        chartoperProfit.Visible = true;
                        string[] x = new string[dt_new.Rows.Count];
                        decimal[] y = new decimal[dt_new.Rows.Count];
                        for (int count = 0; count < dt_new.Rows.Count; count++)
                        {
                            x[count] = dt_new.Rows[count]["Consignee"].ToString();
                            y[count] = Convert.ToDecimal(dt_new.Rows[count]["retention"].ToString());
                        }

                        if (ddl_graph2.SelectedItem.Text == "Line")
                        {
                            chartoperProfit.ChartAreas[0].AxisX.Title = "Agent";
                            chartoperProfit.ChartAreas[0].AxisY.Title = "Amount";

                            chartoperProfit.Series[0].Points.DataBindXY(x, y);
                            chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                            chartoperProfit.Series[0].LegendText = "Profit";
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                            grd_Consignee.Visible = false;
                            piechart.Visible = false;
                            return;
                        }
                        if (ddl_graph2.SelectedItem.Text == "Bar")
                        {
                            chartoperProfit.ChartAreas[0].AxisX.Title = "Agent";
                            chartoperProfit.ChartAreas[0].AxisY.Title = "Amount";
                            chartoperProfit.Series[0].Points.DataBindXY(x, y);
                            chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                            chartoperProfit.Series[0].LegendText = "Profit";
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                            grd_Consignee.Visible = false;
                            piechart.Visible = false;
                            return;
                        }
                        if (ddl_graph2.SelectedItem.Text == "Pie")
                        {
                            piechart.Legends.Clear();
                            chartoperProfit.Visible = false;
                            piechart.Visible = true;
                            piechart.Series[0].Points.DataBindXY(x, y);
                            piechart.Series[0].ChartType = SeriesChartType.Pie;
                            piechart.Series[0].Label = "#VALX (#PERCENT)";
                            //piechart.Titles.Clear();
                            //piechart.Titles.Add("SL CHENNAI");
                            piechart.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            piechart.Series[0]["PieLabelStyle"] = "Disabled";

                            grd_Consignee.Visible = false;
                            return;
                        }
                    }

                 //   bnt_cancel.Text = "Cancel";

                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    // grd_Consignee.Rows[grd_Agent.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Consignee", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_JobwiseCosting()
        {
            try
            {
                str_TranType = "";
                str_Branch = "";
                DataTable dt_jobwiseCost = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                dt_jobwiseCost = da_obj_misgrd.Getjobwisecosting(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
                if (dt_jobwiseCost.Rows.Count > 0)
                {
                    double totalincomeFE = 0, totalexpenseFE = 0, totalretentionFE = 0, totalincomeFI = 0, totalexpenseFI = 0, totalretentionFI = 0;
                    double totalincomeCHA = 0, totalexpenseCHA = 0, totalretentionCHA = 0, totalincomeFC = 0, totalexpenseFC = 0, totalretentionFC = 0;
                    DataTable dtempty = new DataTable();



                    dtempty.Columns.Add("trantype");
                    dtempty.Columns.Add("Branch");
                    dtempty.Columns.Add("jobno");
                    dtempty.Columns.Add("jobopenon");
                    dtempty.Columns.Add("jobcloseddate");
                    dtempty.Columns.Add("agent");
                    dtempty.Columns.Add("income");
                    dtempty.Columns.Add("expense");
                    dtempty.Columns.Add("retention");
                    dtempty.Columns.Add("branchid");

                    DataRow dr = dtempty.NewRow();

                    //double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;


                    DataView dv_co = new DataView(dt_jobwiseCost);
                    dtnew = dv_co.ToTable(true, "trantype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "trantype";
                    dtnew = dv_co.ToTable();

                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;
                        DataTable dtLi = new DataTable();
                        DataView data1 = dt_jobwiseCost.DefaultView;
                        data1.RowFilter = "trantype = '" + dtnew.Rows[j]["trantype"] + "' ";
                        dtLi = data1.ToTable();   //DataView dv = new DataView(dt_jobwiseCost);
                        dr = dtempty.NewRow();

                        dr["trantype"] = dtLi.Rows[0]["TrantypeFull"];
                        dr["jobno"] = "";
                        dr["jobopenon"] = "";
                        dr["jobcloseddate"] = "";
                        dr["income"] = "";
                        dr["expense"] = "";
                        dr["retention"] = "";

                        dtempty.Rows.Add(dr);



                        for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {

                            dr = dtempty.NewRow();
                            dtempty.Rows.Add();
                            int count = dtempty.Rows.Count - 1;


                            dtempty.Rows[count]["trantype"] = dtLi.Rows[i]["trantype"].ToString();
                            dtempty.Rows[count]["Branch"] = dtLi.Rows[i]["Branch"].ToString();
                            dtempty.Rows[count]["jobno"] = dtLi.Rows[i]["jobno"].ToString();
                            dtempty.Rows[count]["jobopenon"] = dtLi.Rows[i]["jobopenon"].ToString();
                            dtempty.Rows[count]["jobcloseddate"] = dtLi.Rows[i]["jobcloseddate"].ToString();
                            dtempty.Rows[count]["agent"] = dtLi.Rows[i]["agent"].ToString();
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["income"].ToString());
                            dtempty.Rows[count]["income"] = temp2.ToString("#,0.00");
                            totalincome = totalincome + Convert.ToDouble(dtempty.Rows[count]["income"].ToString());
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["expense"].ToString());
                            dtempty.Rows[count]["expense"] = temp2.ToString("#,0.00");

                            totalexpense = totalexpense + Convert.ToDouble(dtempty.Rows[count]["expense"].ToString());
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["retention"].ToString());
                            dtempty.Rows[count]["retention"] = temp2.ToString("#,0.00");
                            totalretention = totalretention + Convert.ToDouble(dtempty.Rows[count]["retention"].ToString());
                            dtempty.Rows[count]["branchid"] = dtLi.Rows[i]["branchid"].ToString();
                            //dtempty.Rows.Add(dr);
                        }


                        dr = dtempty.NewRow();
                        dr["agent"] = dtLi.Rows[0]["trantype"] + "-" + "Total";
                        dr["income"] = totalincome.ToString("#,0.00");
                        dr["expense"] = totalexpense.ToString("#,0.00");
                        dr["retention"] = totalretention.ToString("#,0.00");
                        dtempty.Rows.Add(dr);
                        totalincomegrand += totalincome;
                        totalexpensegrand += totalexpense;
                        totalretentiongrand += totalretention;

                    }
                    dr = dtempty.NewRow();
                    dr["agent"] = "Grand Total";
                    dr["income"] = totalincomegrand.ToString("#,0.00");
                    dr["expense"] = totalexpensegrand.ToString("#,0.00");
                    dr["retention"] = totalretentiongrand.ToString("#,0.00");
                    dtempty.Rows.Add(dr);
                    grd_JobwiseCosting.Visible = true;
                    grd_JobwiseCosting.DataSource = dtempty;
                    grd_JobwiseCosting.DataBind();
                //    bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    //grd_JobwiseCosting.Rows[grd_Agent.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Jobwise", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_ShipmentDtls()
        {
            try
            {
                str_TranType = "";
                str_Branch = "";
                DataTable dt_ShipDetails = new DataTable();
                DataTable dtemptyfree = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                dt_ShipDetails = da_obj_misgrd.Getshipmentnew(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));

                if (dt_ShipDetails.Rows.Count > 0)
                {
                    double totalgrand40 = 0, totalgrand20 = 0, totalgrandvou = 0, totalincomegrand = 0, totalexpensegrand = 0, totalretentiongrand = 0;

                    dtemptyfree.Columns.Add("trantype");
                    dtemptyfree.Columns.Add("jobno");
                    dtemptyfree.Columns.Add("nomination");
                    dtemptyfree.Columns.Add("TypeJob");
                    dtemptyfree.Columns.Add("volume");
                    dtemptyfree.Columns.Add("cont20");
                    dtemptyfree.Columns.Add("cont40");
                    dtemptyfree.Columns.Add("income");
                    dtemptyfree.Columns.Add("expense");
                    dtemptyfree.Columns.Add("retention");
                    dtemptyfree.Columns.Add("branchid");


                    DataView dv_co = new DataView(dt_ShipDetails);
                    dtnew = dv_co.ToTable(true, "trantype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "trantype";
                    dtnew = dv_co.ToTable();
                    DataRow dr = dtemptyfree.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;
                        DataTable dtLi = new DataTable();
                        DataView data1 = dt_ShipDetails.DefaultView;
                        data1.RowFilter = "trantype = '" + dtnew.Rows[j]["trantype"] + "' ";
                        dtLi = data1.ToTable();
                        // count1=dtLi.Rows.Count;
                        if (dtLi.Rows.Count > 0)
                        {

                            dr = dtemptyfree.NewRow();
                            dr["trantype"] = dtLi.Rows[0]["TrantypeFull"].ToString();
                            dr["jobno"] = "";
                            dr["nomination"] = "";
                            dr["TypeJob"] = "";
                            dr["volume"] = "";
                            dr["cont20"] = "";
                            dr["cont40"] = "";
                            dr["income"] = "";
                            dr["expense"] = "";
                            dr["retention"] = "";

                            dtemptyfree.Rows.Add(dr);

                            //dtemptyfree.Rows.Add();

                            for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                            {

                                dr = dtemptyfree.NewRow();
                                dtemptyfree.Rows.Add();
                                int count = dtemptyfree.Rows.Count - 1;
                                dtemptyfree.Rows[count]["trantype"] = dtLi.Rows[i]["trantype"].ToString();
                                dtemptyfree.Rows[count]["jobno"] = dtLi.Rows[i]["jobno"].ToString();
                                dtemptyfree.Rows[count]["nomination"] = dtLi.Rows[i]["nomination"].ToString();
                                dtemptyfree.Rows[count]["TypeJob"] = dtLi.Rows[i]["TypeJob"].ToString();
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["volume"].ToString());
                                dtemptyfree.Rows[count]["volume"] = temp2.ToString("#,0.00");
                                totalvou = totalvou + Convert.ToDouble(dtemptyfree.Rows[count]["volume"].ToString());

                                dtemptyfree.Rows[count]["cont20"] = dtLi.Rows[i]["cont20"].ToString();
                                total20 = total20 + Convert.ToDouble(dtLi.Rows[i]["cont20"].ToString());
                                dtemptyfree.Rows[count]["cont40"] = dtLi.Rows[i]["cont40"].ToString();
                                total40 = total40 + Convert.ToDouble(dtLi.Rows[i]["cont40"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["income"].ToString());
                                dtemptyfree.Rows[count]["income"] = temp2.ToString("#,0.00");
                                totalincome = totalincome + Convert.ToDouble(dtemptyfree.Rows[count]["income"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["expense"].ToString());
                                dtemptyfree.Rows[count]["expense"] = temp2.ToString("#,0.00");

                                totalexpense = totalexpense + Convert.ToDouble(dtemptyfree.Rows[count]["expense"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["retention"].ToString());
                                dtemptyfree.Rows[count]["retention"] = temp2.ToString("#,0.00");

                                totalretention = totalretention + Convert.ToDouble(dtemptyfree.Rows[count]["retention"].ToString());
                                dtemptyfree.Rows[count]["branchid"] = dtLi.Rows[i]["branchid"].ToString();
                            }


                            dr = dtemptyfree.NewRow();
                            dr["nomination"] = dtnew.Rows[j]["trantype"] + "-" + "Total";
                            dr["volume"] = totalvou;
                            dr["cont20"] = total20;
                            dr["cont40"] = total40;
                            dr["income"] = totalincome.ToString("#,0.00");
                            dr["expense"] = totalexpense.ToString("#,0.00");
                            dr["retention"] = totalretention.ToString("#,0.00");
                        }
                        dtemptyfree.Rows.Add(dr);
                        totalgrand40 += total40;
                        totalgrand20 += total20;
                        totalgrandvou += totalvou;
                        totalincomegrand += totalincome;
                        totalexpensegrand += totalexpense;
                        totalretentiongrand += totalretention;

                    }
                    dr = dtemptyfree.NewRow();
                    if (dt_ShipDetails.Rows.Count > 0)
                    {
                        dr["nomination"] = "Grand Total";
                        dr["volume"] = totalgrandvou.ToString("#,0.00");
                        dr["cont20"] = totalgrand20;
                        dr["cont40"] = totalgrand40;
                        dr["income"] = totalincomegrand.ToString("#,0.00");
                        dr["expense"] = totalexpensegrand.ToString("#,0.00");
                        dr["retention"] = totalretentiongrand.ToString("#,0.00");
                        dtemptyfree.Rows.Add(dr);
                        grd_Shipment.Visible = true;
                        grd_Shipment.DataSource = dtemptyfree;
                        grd_Shipment.DataBind();
                       // bnt_cancel.Text = "Cancel";


                        bnt_cancel.ToolTip = "Cancel";
                        bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                        btn_Export.Enabled = true;
                        //grd_Shipment.Rows[grd_Agent.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Shipment Details", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_OprProfit()
        {
            try
            {
                DataTable dt_OprProfit = new DataTable();
                DataTable dt = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                string transtype = Session["StrTranType"].ToString();
                int count;
                double total;
                string transtype1 = "";
                dt_OprProfit = da_obj_misgrd.GetOperatingProfit(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), transtype, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
                if (dt_OprProfit.Rows.Count > 0)
                {
                    if (transtype == "AC")
                    {
                        dt_OprProfit.Columns.Add(new DataColumn("Total"));
                        double dbl_Total = 0, dbl_Full_Total = 0;
                        for (int k = 0; k < dt_OprProfit.Rows.Count; k++)
                        {
                            dbl_Total = 0;
                            for (int R = 1; R < dt_OprProfit.Columns.Count; R++)
                            {
                                if (dt_OprProfit.Rows[k][R].ToString().Length > 0)
                                    dbl_Total = dbl_Total + Convert.ToDouble(dt_OprProfit.Rows[k][R].ToString());
                            }
                            dt_OprProfit.Rows[k]["Total"] = dbl_Total;
                            dbl_Full_Total = dbl_Full_Total + dbl_Total;
                        }


                        DataRow dr_temp = dt_OprProfit.NewRow();
                        dr_temp[0] = "Total";


                        for (int R = 1; R < dt_OprProfit.Columns.Count - 1; R++)
                        {
                            dr_temp[R] = dt_OprProfit.Compute("sum(" + dt_OprProfit.Columns[R].Caption.ToString() + ")", "");
                        }

                        dr_temp["Total"] = dbl_Full_Total;
                        dt_OprProfit.Rows.Add(dr_temp);

                        grd_operProfit_AC.DataSource = dt_OprProfit;
                        grd_operProfit_AC.DataBind();
                        grd_operProfit_AC.Visible = true;

                        //-------------------------------CHART--------------------------------------------     

                        if (ddl_graph1.SelectedItem.Text == "Data")
                        {
                            grd_operProfit_AC.Visible = true;
                            piechart.Visible = false;
                            chartoperProfit1.Visible = false;
                            grd_operProfit_AC.DataSource = dt_OprProfit;
                            grd_operProfit_AC.DataBind();
                            chartoperProfit1.Visible = false;
                            ddl_graph2.Visible = false;
                            lbl_graph2.Visible = false;
                        }
                        if (ddl_graph1.SelectedItem.Text == "Graph")
                        {
                            grd_operProfit_AC.Visible = false;
                            ddl_graph2.Visible = true;
                          

                            if (ddl_graph2.SelectedItem.Text == "Bar")
                            {
                                grd_operProfit.Visible = false;
                                piechart.Visible = false;
                                chartoperProfit1.Visible = true;

                                chartoperProfit1.Series.Clear();
                                chartoperProfit1.Legends.Clear();
                                DataTable obj_dtChat = new DataTable();
                                //dt_OprProfit.Columns.RemoveAt(1);
                                dt_OprProfit.Columns.RemoveAt(dt_OprProfit.Columns.Count - 1);
                                dt_OprProfit.Rows.RemoveAt(dt_OprProfit.Rows.Count - 1);

                                //LINQ                        

                                var test0 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-AHD"
                                             select x).ToList();

                                var test1 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-BLR"
                                             select x).ToList();

                                var test2 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-CBE"
                                             select x).ToList();

                                var test3 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-CHE"
                                             select x).ToList();

                                var test4 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-CO"
                                             select x).ToList();

                                var test5 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-COC"
                                             select x).ToList();

                                var test6 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-DEL"
                                             select x).ToList();

                                var test7 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-HYD"
                                             select x).ToList();

                                var test8 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-KOL"
                                             select x).ToList();

                                var test9 = (from x in dt_OprProfit.AsEnumerable()
                                             where x.Field<string>("Branch") == "SL-LUD"
                                             select x).ToList();

                                var test10 = (from x in dt_OprProfit.AsEnumerable()
                                              where x.Field<string>("Branch") == "SL-MUM"
                                              select x).ToList();

                                var test11 = (from x in dt_OprProfit.AsEnumerable()
                                              where x.Field<string>("Branch") == "SL-TPR"
                                              select x).ToList();

                                var test12 = (from x in dt_OprProfit.AsEnumerable()
                                              where x.Field<string>("Branch") == "SL-TUT"
                                              select x).ToList();

                                var test13 = (from x in dt_OprProfit.AsEnumerable()
                                              where x.Field<string>("Branch") == "SL-TVM"
                                              select x).ToList();

                                var test14 = (from x in dt_OprProfit.AsEnumerable()
                                              where x.Field<string>("Branch") == "SL-VIS"
                                              select x).ToList();

                                if (test0.Count == 1)
                                {
                                    test0[0][0] = "AHD";
                                }
                                if (test1.Count == 1)
                                {
                                    test1[0][0] = "BLR";
                                }
                                if (test2.Count == 1)
                                {
                                    test2[0][0] = "CBE";
                                }
                                if (test3.Count == 1)
                                {
                                    test3[0][0] = "CHE";
                                }
                                if (test4.Count == 1)
                                {
                                    test4[0][0] = "CO";
                                }
                                if (test5.Count == 1)
                                {
                                    test5[0][0] = "COC";
                                }
                                if (test6.Count == 1)
                                {
                                    test6[0][0] = "DEL";
                                }
                                if (test7.Count == 1)
                                {
                                    test7[0][0] = "HYD";
                                }
                                if (test8.Count == 1)
                                {
                                    test8[0][0] = "KOL";
                                }
                                if (test9.Count == 1)
                                {
                                    test9[0][0] = "LUD";
                                }
                                if (test10.Count == 1)
                                {
                                    test10[0][0] = "MUM";
                                }
                                if (test11.Count == 1)
                                {
                                    test11[0][0] = "TPR";
                                }
                                if (test12.Count == 1)
                                {
                                    test12[0][0] = "TUT";
                                }
                                if (test13.Count == 1)
                                {
                                    test13[0][0] = "TVM";
                                }
                                if (test14.Count == 1)
                                {
                                    test14[0][0] = "VIS";
                                }

                                dt_OprProfit.AcceptChanges();

                                //Chart
                                obj_dtChat = dt_OprProfit;
                                var IEtable = (obj_dtChat as System.ComponentModel.IListSource).GetList();
                                chartoperProfit1.DataBindTable(IEtable, "Branch");
                                chartoperProfit1.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                                chartoperProfit1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                                chartoperProfit1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                                chartoperProfit1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                                chartoperProfit1.ChartAreas[0].AxisX.IsLabelAutoFit = true;
                                chartoperProfit1.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                                chartoperProfit1.ChartAreas[0].AxisX.LabelStyle.Enabled = true;

                                chartoperProfit1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                                chartoperProfit1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                                chartoperProfit1.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                                chartoperProfit1.Series[3].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                                chartoperProfit1.Series[4].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                                chartoperProfit1.Series[5].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                                chartoperProfit1.Series[6].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                            }

                            if (ddl_graph2.SelectedItem.Text == "Line")
                            {
                                chartoperProfit.Visible = false;
                                piechart.Visible = false;
                                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "Miscorporate", "alertify.alert('No Line Chart For Operating profit');", true);
                            }

                            if (ddl_graph2.SelectedItem.Text == "Pie")
                            {
                                dt_OprProfit.Columns.RemoveAt(0);
                                dt_OprProfit.Columns.RemoveAt(dt_OprProfit.Columns.Count - 1);
                                dt_OprProfit.Rows.RemoveAt(dt_OprProfit.Rows.Count - 1);

                                grd_operProfit.Visible = false;
                                piechart.Visible = true;
                                chartoperProfit1.Visible = false;
                                piechart.Legends.Clear();

                                string[] k = new string[dt_OprProfit.Columns.Count];
                                double[] y = new double[dt_OprProfit.Columns.Count];
                                for (int i = 0; i < dt_OprProfit.Columns.Count; i++)
                                {
                                    k[i] = dt_OprProfit.Columns[i].ToString();
                                    y[i] = Convert.ToDouble(dt_OprProfit.Rows[0][i]);
                                }
                                piechart.Series[0].Points.DataBindXY(k, y);
                                piechart.Series[0].ChartType = SeriesChartType.Pie;
                                piechart.Series[0].Label = "#VALX (#PERCENT)";
                                piechart.Titles.Clear();
                                piechart.Titles.Add("SL CHENNAI");
                                piechart.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                                piechart.Series[0]["PieLabelStyle"] = "Disabled";
                            }
                        }

                      //  bnt_cancel.Text = "Cancel";


                        bnt_cancel.ToolTip = "Cancel";
                        bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                        btn_Export.Enabled = true;
                    }
                    else
                    {
                        int cell = 0;
                        dt.Columns.Add("Branch");
                        if (transtype.ToUpper() == "FE")
                        {
                            transtype1 = "OE";
                        }
                        else if (transtype.ToUpper() == "FI")
                        {
                            transtype1 = "OI";
                        }

                        dt.Columns.Add(transtype1.ToUpper());
                        DataRow dr_temp = dt_OprProfit.NewRow();
                        for (int i = 0; i <= dt_OprProfit.Rows.Count - 1; i++)
                        {
                            dr_temp = dt_OprProfit.NewRow();
                            dt.Rows.Add();
                            for (int j = 1; j <= dt_OprProfit.Columns.Count - 1; j++)
                            {
                                total = 0;
                                if (j > 0)
                                {
                                    cell = Convert.ToInt32(dt_OprProfit.Rows[0][j]);
                                }

                                if (cell != 0)
                                {
                                    count = dt.Rows.Count - 1;
                                    dt.Rows[count][0] = dt_OprProfit.Rows[0]["Branch"].ToString();
                                    temp2 = Convert.ToDouble(dt_OprProfit.Rows[0][j].ToString());
                                    dt.Rows[count][1] = temp2.ToString("#,0.00");
                                    total = total + Convert.ToDouble(dt_OprProfit.Rows[0][j].ToString());
                                }
                            }

                        }


                        dr_temp = dt.NewRow();
                        dr_temp[0] = "Total";
                        //for (int R = 1; R <= dt.Columns.Count - 1; R++)
                        //{
                        //    temp2 = Convert.ToDouble(dt.Compute("sum(" + dt.Columns[R]["OE"].ToString() + ")", ""));
                        //    dr_temp[R] = temp2.ToString("#,0.00");
                        //}

                        //if (dt.Rows.Count > 0)
                        //{
                        //    temp2 = Convert.ToDouble(dt.Compute("sum(" + dt.Columns[1].Caption.ToString() + ")", ""));
                        //    dr_temp[1] = temp2.ToString("#,0.00");

                        //}

                        if (dt.Rows.Count > 0)
                        {
                            temp2 = Convert.ToDouble(dt.Rows[0][1].ToString());
                            dr_temp[1] = temp2.ToString("#,0.00");
                        }
                        dt.Rows.Add(dr_temp);
                        grd_operProfit.Visible = true;
                        grd_operProfit.DataSource = dt;
                        grd_operProfit.DataBind();

                        //-------------------------------CHART--------------------------------------------     
                        ddl_graph1.Enabled = false;

                        //bnt_cancel.Text = "Cancel";

                        bnt_cancel.ToolTip = "Cancel";
                        bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                        btn_Export.Enabled = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_PortOfLoading()
        {
            try
            {
                DataTable dt_POL = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();

                if (txt_Filter.Text.ToString().Trim().Length > 0)
                {
                    dt_POL = da_obj_misgrd.GetPOlwiseFilter(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(hidId.Value.ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    dt_POL = da_obj_misgrd.GetPOlwise(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
                }


                if (dt_POL.Rows.Count > 0)
                {
                    //DataRow dr_temp = dt_POL.NewRow();
                    //dr_temp["polid"] = 0;
                    //dr_temp["Pol"] = "Total";
                    //dr_temp["volume"] = dt_POL.Compute("sum(Volume)", "");
                    //dr_temp["cont20"] = dt_POL.Compute("sum(cont20)", "");
                    //dr_temp["cont40"] = dt_POL.Compute("sum(cont40)", "");
                    //dr_temp["income"] = dt_POL.Compute("sum(income)", "");
                    //dr_temp["Expense"] = dt_POL.Compute("sum(Expense)", "");
                    //dr_temp["retention"] = dt_POL.Compute("sum(retention)", "");

                    //dt_POL.Rows.Add(dr_temp);


                    grd_POL.Visible = true;
                    grd_POL.DataSource = dt_POL;
                    grd_POL.DataBind();

                    //   CHART  //
                    if (ddl_graph1.SelectedItem.Text == "Graph")
                    {
                        //DataTable dt = new DataTable();
                        dt_POL.Rows.RemoveAt(dt_POL.Rows.Count - 1);
                        DataTable dt_new = new DataTable();
                        //dt = (DataTable)Session["AgentWise"];
                        DataView dv = dt_POL.DefaultView;
                        dv.Sort = "retention desc";
                        DataTable sortedDT = dv.ToTable();
                        dt_new = SelectTopDataRow(sortedDT, 5);
                        div_op_char.Visible = true;
                        chartoperProfit.Visible = true;
                        string[] x = new string[dt_new.Rows.Count];
                        decimal[] y = new decimal[dt_new.Rows.Count];
                        for (int count = 0; count < dt_new.Rows.Count; count++)
                        {
                            x[count] = dt_new.Rows[count]["Pol"].ToString();
                            y[count] = Convert.ToDecimal(dt_new.Rows[count]["retention"].ToString());
                        }

                        if (ddl_graph2.SelectedItem.Text == "Line")
                        {
                            chartoperProfit.ChartAreas[0].AxisX.Title = "Port";
                            chartoperProfit.ChartAreas[0].AxisY.Title = "Amount";
                            chartoperProfit.Series[0].Points.DataBindXY(x, y);
                            chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                            chartoperProfit.Series[0].LegendText = "Profit";
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                            piechart.Visible = false;
                            grd_POL.Visible = false;
                            return;
                        }
                        if (ddl_graph2.SelectedItem.Text == "Bar")
                        {
                            chartoperProfit.ChartAreas[0].AxisX.Title = "Port";
                            chartoperProfit.ChartAreas[0].AxisY.Title = "Amount";
                            chartoperProfit.Series[0].Points.DataBindXY(x, y);
                            chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                            chartoperProfit.Series[0].LegendText = "Profit";
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                            piechart.Visible = false;
                            grd_POL.Visible = false;
                            return;
                        }
                        if (ddl_graph2.SelectedItem.Text == "Pie")
                        {
                            piechart.Legends.Clear();
                            chartoperProfit.Visible = false;
                            piechart.Visible = true;
                            piechart.Series[0].Points.DataBindXY(x, y);
                            piechart.Series[0].ChartType = SeriesChartType.Pie;
                            piechart.Series[0].Label = "#VALX (#PERCENT)";
                            piechart.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            piechart.Series[0]["PieLabelStyle"] = "Disabled";

                            grd_POL.Visible = false;
                            return;
                        }
                    }

                  //  bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Port of Loading ", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void fn_PortOfDischarge()
        {
            try
            {
                DataTable dt_POD = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();

                if (txt_Filter.Text.ToString().Trim().Length > 0)
                {
                    dt_POD = da_obj_misgrd.GetPODwiseFilter(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(hidId.Value.ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    dt_POD = da_obj_misgrd.GetPODwise(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
                }


                if (dt_POD.Rows.Count > 0)
                {
                    //DataRow dr_temp = dt_POD.NewRow();
                    //dr_temp["podid"] = 0;
                    //dr_temp["Pod"] = "Total";
                    //dr_temp["volume"] = dt_POD.Compute("sum(Volume)", "");
                    //dr_temp["cont20"] = dt_POD.Compute("sum(cont20)", "");
                    //dr_temp["cont40"] = dt_POD.Compute("sum(cont40)", "");
                    //dr_temp["income"] = dt_POD.Compute("sum(income)", "");
                    //dr_temp["Expense"] = dt_POD.Compute("sum(Expense)", "");
                    //dr_temp["retention"] = dt_POD.Compute("sum(retention)", "");
                    //dt_POD.Rows.Add(dr_temp);



                    grd_POD.Visible = true;
                    grd_POD.DataSource = dt_POD;
                    grd_POD.DataBind();
                  //  bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    //grd_POD.Rows[grd_POD.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                    //grd_POD.Rows[grd_POD.Rows.Count - 1].ForeColor = Utility.fn_Grd_GrandTotal_Color();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Port of Discharge", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void fn_Salesperson()
        {
            try
            {
                DataTable dt_Sales = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                if (txt_Filter.Text.ToString().Trim().Length > 0)
                {
                    dt_Sales = da_obj_misgrd.GetSaleswiseFilter(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(hidId.Value.ToString()), 0);
                }
                else
                {
                    dt_Sales = da_obj_misgrd.GetSaleswise(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
                }

                if (dt_Sales.Rows.Count > 0)
                {

                    //DataRow dr_temp = dt_Sales.NewRow();


                    //dr_temp["Person"] = "Total";
                    //dr_temp["Volume"] = dt_Sales.Compute("sum(Volume)", "");
                    //dr_temp["cont20"] = dt_Sales.Compute("sum(cont20)", "");
                    //dr_temp["cont40"] = dt_Sales.Compute("sum(cont40)", "");
                    //dr_temp["income"] = dt_Sales.Compute("sum(income)", "");
                    //dr_temp["Expense"] = dt_Sales.Compute("sum(Expense)", "");
                    //dr_temp["retention"] = dt_Sales.Compute("sum(retention)", "");

                    //dt_Sales.Rows.Add(dr_temp);


                    grd_salesperson.Visible = true;
                    grd_salesperson.DataSource = dt_Sales;
                    grd_salesperson.DataBind();
                  //  bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    //grd_salesperson.Rows[grd_salesperson.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                    //grd_salesperson.Rows[grd_salesperson.Rows.Count - 1].ForeColor = Utility.fn_Grd_GrandTotal_Color();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "SalesPerson", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void ddl_graph1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_graph1.SelectedItem.Text == "Data")
            {
                chartclear();
                btn_Get.Focus();
            }
            else
            {
                ddl_graph2.Visible = true;
                ddl_graph2.Focus();
                ddl_graph2.SelectedIndex = 0;
                grd_Agent.Visible = false;
                grd_Consignee.Visible = false;
                grd_operProfit.Visible = false;
                Grd_freeVsnomi.Visible = false;
                grd_Agent.Visible = false;
            }
        }

        public void chartclear()
        {
            ddl_graph2.Visible = false;
            lbl_graph2.Visible = false;

            chartoperProfit.Visible = false;
            chartoperProfit1.Visible = false;
            piechart.Visible = false;
            PODCHARTVIEW.Visible = false;
            DivAllCahrtnew.Visible = false;
        }

        protected void ddl_graph2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_grid();
            ddl_graph2.Focus();
        }

        public void fn_FreehandVsNomination()
        {
            try
            {
                DataTable dt_freenomi = new DataTable();
                DataAccess.CostingTemp da_obj_costtemp = new DataAccess.CostingTemp();
                double total1 = 0, total2 = 0, total3 = 0, total4 = 0, totalgrand1 = 0, totalgrand2 = 0, totalgrand3 = 0, totalgrand4 = 0;
                dt_freenomi = da_obj_costtemp.GetRetentionperunitforbranch(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Session["StrTranType"].ToString());

                if (dt_freenomi.Rows.Count > 0)
                {
                    DataTable dtemptyfree = new DataTable();
                    dtemptyfree.Columns.Add("product");
                    dtemptyfree.Columns.Add("unit");
                    dtemptyfree.Columns.Add("Fvolume");
                    dtemptyfree.Columns.Add("Fretn");
                    dtemptyfree.Columns.Add("FRtnPUnit");
                    dtemptyfree.Columns.Add("Nvolume");
                    dtemptyfree.Columns.Add("Nretn");
                    dtemptyfree.Columns.Add("NRtnPUnit");
                    DataRow dr = dtemptyfree.NewRow();

                    for (int i = 0; i <= dt_freenomi.Rows.Count - 1; i++)
                    {
                        total1 = 0; total2 = 0; total3 = 0; total4 = 0;
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows.Add();
                        dtemptyfree.Rows[i]["product"] = dt_freenomi.Rows[i]["product"].ToString();
                        dtemptyfree.Rows[i]["unit"] = dt_freenomi.Rows[i]["unit"].ToString();

                        if (dt_freenomi.Rows[i]["Fvolume"] != System.DBNull.Value)
                        {

                            temp2 = Convert.ToDouble(dt_freenomi.Rows[i]["Fvolume"].ToString());

                            dtemptyfree.Rows[i]["Fvolume"] = temp2.ToString("#,0.00");
                            total1 = total1 + Convert.ToDouble(dtemptyfree.Rows[i]["Fvolume"]);
                        }
                        else
                        {
                            dtemptyfree.Rows[i]["Fvolume"] = 0;

                        }

                        dtemptyfree.Rows[i]["Fretn"] = dt_freenomi.Rows[i]["Fretn"].ToString();
                        if (dt_freenomi.Rows[i]["Fretn"] != System.DBNull.Value)
                        {
                            temp2 = Convert.ToDouble(dt_freenomi.Rows[i]["Fretn"].ToString());
                            dtemptyfree.Rows[i]["Fretn"] = temp2.ToString("#,0.00");
                            total2 = total2 + Convert.ToDouble(dtemptyfree.Rows[i]["Fretn"]);
                        }
                        else
                        {
                            dtemptyfree.Rows[i]["Fretn"] = 0;
                        }
                        temp2 = Convert.ToDouble(dt_freenomi.Rows[i]["FRtnPUnit"].ToString());
                        dtemptyfree.Rows[i]["FRtnPUnit"] = temp2.ToString("#,0.00");

                        if (dt_freenomi.Rows[i]["Nvolume"] != System.DBNull.Value)
                        {
                            temp2 = Convert.ToDouble(dt_freenomi.Rows[i]["Nvolume"].ToString());
                            dtemptyfree.Rows[i]["Nvolume"] = temp2.ToString("#,0.00");
                            total3 = total3 + Convert.ToDouble(dtemptyfree.Rows[i]["Nvolume"]);
                        }
                        else
                        {
                            dtemptyfree.Rows[i]["Nvolume"] = 0;

                        }

                        if (dt_freenomi.Rows[i]["Nretn"] != System.DBNull.Value)
                        {
                            temp2 = Convert.ToDouble(dt_freenomi.Rows[i]["Nretn"].ToString());
                            dtemptyfree.Rows[i]["Nretn"] = temp2.ToString("#,0.00");
                            total4 = total4 + Convert.ToDouble(dtemptyfree.Rows[i]["Nretn"]);
                        }
                        else
                        {
                            dtemptyfree.Rows[i]["Nretn"] = 0;

                        }

                        temp2 = Convert.ToDouble(dt_freenomi.Rows[i]["NRtnPUnit"].ToString());
                        dtemptyfree.Rows[i]["NRtnPUnit"] = temp2.ToString("#,0.00");

                        //dtemptyfree.Rows.Add(dr);
                        totalgrand1 += total1;
                        totalgrand2 += total2;
                        totalgrand3 += total3;
                        totalgrand4 += total4;
                    }

                    dr = dtemptyfree.NewRow();
                    dr["product"] = "Total";
                    dr["Fvolume"] = totalgrand1.ToString("#,0.00");
                    dr["Fretn"] = totalgrand2.ToString("#,0.00");
                    dr["Nvolume"] = totalgrand3.ToString("#,0.00");
                    dr["Nretn"] = totalgrand4.ToString("#,0.00");

                    dtemptyfree.Rows.Add(dr);

                    Grd_freeVsnomi.DataSource = dtemptyfree;
                    Grd_freeVsnomi.DataBind();
                    Grd_freeVsnomi.Visible = true;
                   // bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;

                    //-------------------------------------------------Freehand & Nominiee CHART---------------------------------------------------//

                    if (ddl_graph1.SelectedItem.Text == "Data")
                    {
                        Grd_freeVsnomi.Visible = true;
                        piechart.Visible = false;
                        PODCHARTVIEW.Visible = false;
                        chartoperProfit.Visible = false;
                        Grd_freeVsnomi.DataSource = dtemptyfree;
                        Grd_freeVsnomi.DataBind();
                        chartoperProfit.Visible = false;
                        ddl_graph2.Visible = false;
                        lbl_graph2.Visible = false;
                    }

                    if (ddl_graph1.SelectedItem.Text == "Graph")
                    {
                        Grd_freeVsnomi.Visible = false;
                        ddl_graph2.Visible = true;
                        if (ddl_graph2.SelectedItem.Text == "Bar")
                        {
                            DataTable freehandchart = new DataTable();
                            DataRow freeobj = freehandchart.NewRow();
                            freehandchart.Columns.Add("product");
                            freehandchart.Columns.Add("Fretn");
                            freehandchart.Columns.Add("Nretn");

                            for (int i = 0; i < dtemptyfree.Rows.Count - 1; i++)
                            {
                                freeobj = freehandchart.NewRow();
                                freeobj["product"] = dtemptyfree.Rows[i]["product"].ToString();
                                double s1 = Convert.ToDouble(dtemptyfree.Rows[i]["Fretn"]);
                                freeobj["Fretn"] = s1 / 1000;
                                double s2 = Convert.ToDouble(dtemptyfree.Rows[i]["Nretn"]);
                                freeobj["Nretn"] = s2 / 1000;
                                freehandchart.Rows.Add(freeobj);
                            }

                            Grd_freeVsnomi.Visible = false;
                            DivAllCahrtnew.Visible = false;
                            PODCHARTVIEW.Visible = true;

                            string[] x = new string[freehandchart.Rows.Count];
                            double[] y = new double[freehandchart.Rows.Count];
                            double[] z = new double[freehandchart.Rows.Count];
                            for (int i = 0; i < freehandchart.Rows.Count; i++)
                            {
                                x[i] = freehandchart.Rows[i][0].ToString();
                                y[i] = Convert.ToDouble(freehandchart.Rows[i][1]);
                                z[i] = Convert.ToDouble(freehandchart.Rows[i][2]);
                            }
                            //PODCHARTVIEW.Series[0].YValuesPerPoint = 2;
                            PODCHARTVIEW.Series[0].Points.DataBindXY(x, y);
                            PODCHARTVIEW.Series[1].Points.DataBindXY(x, z);
                            PODCHARTVIEW.Series[0].ChartType = SeriesChartType.Column;
                            PODCHARTVIEW.Series[1].ChartType = SeriesChartType.Column;
                            //PODCHARTVIEW.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            //PODCHARTVIEW.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                            //PODCHARTVIEW.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            //PODCHARTVIEW.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            //PODCHARTVIEW.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            PODCHARTVIEW.ChartAreas[0].AxisX.IsLabelAutoFit = true;
                            PODCHARTVIEW.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            PODCHARTVIEW.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
                        }

                        else if (ddl_graph2.SelectedItem.Text == "Line")
                        {
                            DataTable freehandchart = new DataTable();
                            DataRow freeobj = freehandchart.NewRow();
                            freehandchart.Columns.Add("product");
                            freehandchart.Columns.Add("Fretn");
                            freehandchart.Columns.Add("Nretn");

                            for (int i = 0; i < dtemptyfree.Rows.Count - 1; i++)
                            {
                                freeobj = freehandchart.NewRow();
                                freeobj["product"] = dtemptyfree.Rows[i]["product"].ToString();
                                double s1 = Convert.ToDouble(dtemptyfree.Rows[i]["Fretn"]);
                                freeobj["Fretn"] = s1 / 1000;
                                double s2 = Convert.ToDouble(dtemptyfree.Rows[i]["Nretn"]);
                                freeobj["Nretn"] = s2 / 1000;
                                freehandchart.Rows.Add(freeobj);
                            }

                            Grd_freeVsnomi.Visible = false;
                            DivAllCahrtnew.Visible = false;
                            PODCHARTVIEW.Visible = true;

                            string[] x = new string[freehandchart.Rows.Count];
                            double[] y = new double[freehandchart.Rows.Count];
                            double[] z = new double[freehandchart.Rows.Count];
                            for (int i = 0; i < freehandchart.Rows.Count; i++)
                            {
                                x[i] = freehandchart.Rows[i][0].ToString();
                                y[i] = Convert.ToDouble(freehandchart.Rows[i][1]);
                                z[i] = Convert.ToDouble(freehandchart.Rows[i][2]);
                            }
                            //PODCHARTVIEW.Series[0].YValuesPerPoint = 2;
                            PODCHARTVIEW.Series[0].Points.DataBindXY(x, y);
                            PODCHARTVIEW.Series[1].Points.DataBindXY(x, z);
                            PODCHARTVIEW.Series[0].ChartType = SeriesChartType.Line;
                            PODCHARTVIEW.Series[1].ChartType = SeriesChartType.Line;
                            //PODCHARTVIEW.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            //PODCHARTVIEW.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                            //PODCHARTVIEW.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                            //PODCHARTVIEW.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                            //PODCHARTVIEW.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
                            PODCHARTVIEW.ChartAreas[0].AxisX.IsLabelAutoFit = true;
                            PODCHARTVIEW.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
                            PODCHARTVIEW.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
                        }
                        else if (ddl_graph2.SelectedItem.Text == "Pie")
                        {
                            PODCHARTVIEW.Visible = false;
                            chartoperProfit.Visible = false;
                            chartoperProfit1.Visible = false;
                            DivAllCahrtnew.Visible = true;

                            Chart1.Legends.Clear();

                            Chart2.Legends.Clear();

                            Chart3.Legends.Clear();

                            Chart4.Legends.Clear();

                            Chart5.Legends.Clear();

                            Chart6.Legends.Clear();

                            Chart7.Legends.Clear();

                            Chart8.Legends.Clear();

                            DataTable dt = new DataTable();
                            DataTable dt_new = new DataTable();
                            dt_new.Columns.Add("product");
                            dt_new.Columns.Add("tonnage");


                            dr = dt_new.NewRow();
                            dr["product"] = "FRetention";
                            dr["tonnage"] = dt_freenomi.Rows[0]["Fretn"].ToString();
                            dt_new.Rows.Add(dr);
                            dr = dt_new.NewRow();
                            dr["product"] = "NRetention";
                            dr["tonnage"] = dt_freenomi.Rows[0]["Nretn"].ToString();
                            dt_new.Rows.Add(dr);

                            string[] x = new string[dt_new.Rows.Count];
                            double[] y = new double[dt_new.Rows.Count];
                            for (int i = 0; i < dt_new.Rows.Count; i++)
                            {
                                x[i] = dt_new.Rows[i]["product"].ToString();
                                if (dt_new.Rows[i]["tonnage"] != System.DBNull.Value)
                                {
                                    y[i] = Convert.ToDouble(dt_new.Rows[i]["tonnage"]);
                                }
                                else
                                {
                                    y[i] = 0;
                                }
                            }
                            Chart1.Series[0].Points.DataBindXY(x, y);
                            Chart1.Series[0].ChartType = SeriesChartType.Pie;
                            Chart1.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            Chart1.Series[0]["PieLabelStyle"] = "Disabled";
                            this.Chart1.Series[0].LegendText = "#VALX (#PERCENT)";
                            Chart1.Visible = true;

                            //---------------------------------------------------------------------
                            dt_new = new DataTable();
                            dt_new.Columns.Add("product");
                            dt_new.Columns.Add("tonnage");

                            dr = dt_new.NewRow();
                            dr["product"] = "FRetention";
                            dr["tonnage"] = dt_freenomi.Rows[1]["Fretn"].ToString();
                            dt_new.Rows.Add(dr);
                            dr = dt_new.NewRow();
                            dr["product"] = "NRetention";
                            dr["tonnage"] = dt_freenomi.Rows[1]["Nretn"].ToString();
                            dt_new.Rows.Add(dr);

                            for (int i = 0; i < dt_new.Rows.Count; i++)
                            {
                                x[i] = dt_new.Rows[i]["product"].ToString();
                                x[i] = dt_new.Rows[i]["product"].ToString();
                                if (dt_new.Rows[i]["tonnage"] != System.DBNull.Value)
                                {
                                    y[i] = Convert.ToDouble(dt_new.Rows[i]["tonnage"]);
                                }
                                else
                                {
                                    y[i] = 0;
                                }
                            }
                            Chart2.Series[0].Points.DataBindXY(x, y);
                            Chart2.Series[0].ChartType = SeriesChartType.Pie;
                            Chart2.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            Chart2.Series[0]["PieLabelStyle"] = "Disabled";
                            this.Chart2.Series[0].LegendText = "#VALX (#PERCENT)";
                            Chart2.Visible = true;

                            //---------------------------------------------------------------------
                            dt_new = new DataTable();
                            dt_new.Columns.Add("product");
                            dt_new.Columns.Add("tonnage");

                            dr = dt_new.NewRow();
                            dr["product"] = "FRetention";
                            if (dt_freenomi.Rows[2]["Fretn"].ToString() == "")
                            {
                                dr["tonnage"] = double.Parse(0.ToString());
                            }
                            else
                            {
                                dr["tonnage"] = dt_freenomi.Rows[2]["Fretn"].ToString();
                            }
                            dt_new.Rows.Add(dr);
                            dr = dt_new.NewRow();
                            dr["product"] = "NRetention";
                            if (dt_freenomi.Rows[2]["Nretn"].ToString() == "")
                            {
                                dr["tonnage"] = double.Parse(0.ToString());
                            }
                            else
                            {
                                dr["tonnage"] = dt_freenomi.Rows[2]["Nretn"].ToString();
                            }
                            dt_new.Rows.Add(dr);

                            for (int i = 0; i < dt_new.Rows.Count; i++)
                            {
                                x[i] = dt_new.Rows[i]["product"].ToString();
                                x[i] = dt_new.Rows[i]["product"].ToString();
                                if (dt_new.Rows[i]["tonnage"] != System.DBNull.Value)
                                {
                                    y[i] = Convert.ToDouble(dt_new.Rows[i]["tonnage"]);
                                }
                                else
                                {
                                    y[i] = 0;
                                }
                            }
                            Chart3.Series[0].Points.DataBindXY(x, y);
                            Chart3.Series[0].ChartType = SeriesChartType.Pie;
                            Chart3.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                            Chart3.Series[0]["PieLabelStyle"] = "Disabled";
                            this.Chart3.Series[0].LegendText = "#VALX (#PERCENT)";
                            Chart3.Visible = true;

                            Grd_freeVsnomi.Visible = false;
                            return;
                        }
                        //Grd_freeVsnomi.Rows[grd_Agent.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "FreeVSnomi", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void fn_Nomination(String str_type)
        {
            try
            {
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();

                DataTable dt_freenomini = new DataTable();
                DataTable dtnew = new DataTable();
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                string transtype = HttpContext.Current.Session["StrTranType"].ToString();

                dt_freenomini = da_obj_misgrd.GetNominationwise(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), str_type, int.Parse(Session["LoginDivisionId"].ToString()));

                if (dt_freenomini.Rows.Count > 0)
                {
                    double totalgrand40 = 0, totalgrand20 = 0, totalgrandvou = 0, totalincomegrand = 0, totalexpensegrand = 0, totalretentiongrand = 0;

                    DataTable dtemptyfree = new DataTable();
                    // dtemptyfree.Columns.Add("Branch");
                    dtemptyfree.Columns.Add("trantype");
                    dtemptyfree.Columns.Add("jobno");
                    dtemptyfree.Columns.Add("nomination");
                    dtemptyfree.Columns.Add("volume");
                    dtemptyfree.Columns.Add("cont20");
                    dtemptyfree.Columns.Add("cont40");
                    dtemptyfree.Columns.Add("income");
                    dtemptyfree.Columns.Add("expense");
                    dtemptyfree.Columns.Add("retention");

                    DataRow dr = dtemptyfree.NewRow();

                    //double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;


                    DataView dv_co = new DataView(dt_freenomini);
                    dtnew = dv_co.ToTable(true, "trantype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "trantype";
                    dtnew = dv_co.ToTable();

                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;
                        DataTable dtLi = new DataTable();
                        DataView data1 = dt_freenomini.DefaultView;
                        data1.RowFilter = "trantype = '" + dtnew.Rows[j]["trantype"] + "' ";
                        dtLi = data1.ToTable();
                        // count1=dtLi.Rows.Count;
                        if (dtLi.Rows.Count > 0)
                        {

                            dr = dtemptyfree.NewRow();
                            //dr["Branch"] = dtLi.Rows[0]["TranTypeFull"].ToString();
                            dr["trantype"] = dtLi.Rows[0]["TranTypeFull"].ToString();
                            dr["jobno"] = "";
                            dr["nomination"] = "";
                            dr["volume"] = "";
                            dr["cont20"] = "";
                            dr["cont40"] = "";
                            dr["income"] = "";
                            dr["expense"] = "";
                            dr["retention"] = "";
                            dtemptyfree.Rows.Add(dr);



                            for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                            {
                                dtemptyfree.Rows.Add();
                                dr = dtemptyfree.NewRow();
                                int count = dtemptyfree.Rows.Count - 1;
                                //dtemptyfree.Rows[count]["Branch"] = dtLi.Rows[i]["Branch"].ToString();
                                dtemptyfree.Rows[count]["trantype"] = dtLi.Rows[i]["trantype"].ToString();
                                dtemptyfree.Rows[count]["jobno"] = dtLi.Rows[i]["jobno"].ToString();
                                dtemptyfree.Rows[count]["nomination"] = dtLi.Rows[i]["nomination"].ToString();
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["volume"].ToString());
                                dtemptyfree.Rows[count]["volume"] = temp2.ToString("#,0.00");
                                totalvou = totalvou + Convert.ToDouble(dtemptyfree.Rows[count]["volume"].ToString());
                                dtemptyfree.Rows[count]["cont20"] = dtLi.Rows[i]["cont20"].ToString();
                                total20 = total20 + Convert.ToDouble(dtLi.Rows[i]["cont20"].ToString());
                                dtemptyfree.Rows[count]["cont40"] = dtLi.Rows[i]["cont40"].ToString();
                                total40 = total40 + Convert.ToDouble(dtLi.Rows[i]["cont40"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["income"].ToString());
                                dtemptyfree.Rows[count]["income"] = temp2.ToString("#,0.00");
                                totalincome = totalincome + Convert.ToDouble(dtemptyfree.Rows[count]["income"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["expense"].ToString());
                                dtemptyfree.Rows[count]["expense"] = temp2.ToString("#,0.00");

                                totalexpense = totalexpense + Convert.ToDouble(dtemptyfree.Rows[count]["expense"].ToString());
                                temp2 = Convert.ToDouble(dtLi.Rows[i]["retention"].ToString());
                                dtemptyfree.Rows[count]["retention"] = temp2.ToString("#,0.00");

                                totalretention = totalretention + Convert.ToDouble(dtemptyfree.Rows[count]["retention"].ToString());

                            }


                            dr = dtemptyfree.NewRow();
                            dr["nomination"] = dtLi.Rows[0]["trantype"].ToString() + "-" + "Total";
                            dr["volume"] = totalvou.ToString("#,0.00");
                            dr["cont20"] = total20;
                            dr["cont40"] = total40;
                            dr["income"] = totalincome.ToString("#,0.00");
                            dr["expense"] = totalexpense.ToString("#,0.00");
                            dr["retention"] = totalretention.ToString("#,0.00");
                            dtemptyfree.Rows.Add(dr);
                            totalgrand40 += total40;
                            totalgrand20 += total20;
                            totalgrandvou += totalvou;
                            totalincomegrand += totalincome;
                            totalexpensegrand += totalexpense;
                            totalretentiongrand += totalretention;
                        }
                        dr = dtemptyfree.NewRow();
                        dr["nomination"] = "Grand Total";
                        dr["volume"] = totalgrandvou.ToString("#,0.00");
                        dr["cont20"] = totalgrand20;
                        dr["cont40"] = totalgrand40;
                        dr["income"] = totalincomegrand.ToString("#,0.00");
                        dr["expense"] = totalexpensegrand.ToString("#,0.00");
                        dr["retention"] = totalretentiongrand.ToString("#,0.00");
                    }
                    dtemptyfree.Rows.Add(dr);
                    Grd_nomination.Visible = true;
                    Grd_nomination.Columns[0].Visible = true;
                    Grd_nomination.DataSource = dtemptyfree;
                    Grd_nomination.DataBind();
                  //  bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;

                    // Grd_nomination.Rows[Grd_nomination.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                    // Grd_nomination.Rows[Grd_nomination.Rows.Count - 1].ForeColor = Utility.fn_Grd_GrandTotal_Color();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Nomination", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void fn_Lossjob()
        {
            try
            {
                DataTable dt_jobloss = new DataTable();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();

                dt_jobloss = da_obj_misgrd.Getjobwisecosting(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), 0);

                if (dt_jobloss.Rows.Count > 0)
                {

                    double totalgrand40 = 0, totalgrand20 = 0, totalgrandvou = 0, totalincomegrand = 0, totalexpensegrand = 0, totalretentiongrand = 0;
                    DataTable dtemptyfree = new DataTable();
                    //dtemptyfree.Columns.Add("branch");
                    dtemptyfree.Columns.Add("trantype");
                    dtemptyfree.Columns.Add("jobno");
                    dtemptyfree.Columns.Add("jobopenon");
                    dtemptyfree.Columns.Add("jobcloseddate");
                    dtemptyfree.Columns.Add("income");
                    dtemptyfree.Columns.Add("expense");
                    dtemptyfree.Columns.Add("retention");
                    //dtemptyfree.Columns.Add("branchid");

                    DataView dv_co = new DataView(dt_jobloss);
                    dtnew = dv_co.ToTable(true, "trantype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "trantype";
                    dtnew = dv_co.ToTable();
                    DataRow dr = dtemptyfree.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;
                        DataTable dtLi = new DataTable();
                        DataView data1 = dt_jobloss.DefaultView;
                        data1.RowFilter = "trantype = '" + dtnew.Rows[j]["trantype"] + "' ";
                        dtLi = data1.ToTable();
                        // count1=dtLi.Rows.Count;
                        if (dtLi.Rows.Count > 0)
                        {
                            dr = dtemptyfree.NewRow();
                            // dr["branch"] = 
                            dr["trantype"] = dtLi.Rows[0]["TranTypeFull"].ToString();
                            dr["jobno"] = "";
                            dr["jobopenon"] = "";
                            dr["jobcloseddate"] = "";
                            dr["income"] = "";
                            dr["expense"] = "";
                            dr["retention"] = "";

                            dtemptyfree.Rows.Add(dr);

                            double temp1 = 0;

                            for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                            {
                                temp1 = Convert.ToDouble(dtLi.Rows[i]["retention"]);
                                if (temp1 < 0)
                                {
                                    dr = dtemptyfree.NewRow();
                                    dtemptyfree.Rows.Add();
                                    int count = dtemptyfree.Rows.Count - 1;

                                    dtemptyfree.Rows[count]["trantype"] = dtLi.Rows[i]["trantype"].ToString();
                                    dtemptyfree.Rows[count]["jobno"] = dtLi.Rows[i]["jobno"].ToString();
                                    dtemptyfree.Rows[count]["jobopenon"] = dtLi.Rows[i]["jobopenon"].ToString();
                                    dtemptyfree.Rows[count]["jobcloseddate"] = dtLi.Rows[i]["jobcloseddate"].ToString();



                                    temp2 = Convert.ToDouble(dtLi.Rows[i]["income"].ToString());
                                    dtemptyfree.Rows[count]["income"] = temp2.ToString("#,0.00");
                                    totalincome = totalincome + Convert.ToDouble(dtemptyfree.Rows[count]["income"].ToString());
                                    temp2 = Convert.ToDouble(dtLi.Rows[i]["expense"].ToString());
                                    dtemptyfree.Rows[count]["expense"] = temp2.ToString("#,0.00");

                                    totalexpense = totalexpense + Convert.ToDouble(dtemptyfree.Rows[count]["expense"].ToString());
                                    temp2 = Convert.ToDouble(dtLi.Rows[i]["retention"].ToString());
                                    dtemptyfree.Rows[count]["retention"] = temp2.ToString("#,0.00");
                                    totalretention = totalretention + Convert.ToDouble(dtemptyfree.Rows[count]["retention"].ToString());
                                    //dtemptyfree.Rows[count]["branchid"] = dtLi.Rows[i]["branchid"].ToString();

                                }
                            }


                            dr = dtemptyfree.NewRow();

                            dr["jobcloseddate"] = dtnew.Rows[j]["trantype"] + "-" + "Total";
                            dr["income"] = totalincome.ToString("#,0.00");
                            dr["expense"] = totalexpense.ToString("#,0.00");
                            dr["retention"] = totalretention.ToString("#,0.00");
                        }
                        dtemptyfree.Rows.Add(dr);
                        totalincomegrand += totalincome;
                        totalexpensegrand += totalexpense;
                        totalretentiongrand += totalretention;

                    }
                    dr = dtemptyfree.NewRow();
                    if (dt_jobloss.Rows.Count > 0)
                    {
                        dr["jobcloseddate"] = "Grand Total";
                        dr["income"] = totalincomegrand.ToString("#,0.00");
                        dr["expense"] = totalexpensegrand.ToString("#,0.00");
                        dr["retention"] = totalretentiongrand.ToString("#,0.00");
                        dtemptyfree.Rows.Add(dr);

                        grd_lossjob.DataSource = dtemptyfree;
                        grd_lossjob.DataBind();
                        grd_lossjob.Visible = true;
                        btn_Export.Enabled = true;
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Lossjob", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void fn_Shipperconsignee()
        {
            try
            {
                DataTable dt_shipconsignee = new DataTable();
                DataTable obj_dt = new DataTable();
                int i;
                DataAccess.CostingTemp da_obj_Costtemp = new DataAccess.CostingTemp();
                if (Session["StrTranType"] != "AC")
                {
                    dt_shipconsignee = da_obj_Costtemp.SelTop50ShipperConsignee4BranchTantype(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
                    obj_dt.Columns.Add("Customer", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(double), DefaultValue = 0 });
                    for (i = 0; i <= dt_shipconsignee.Rows.Count - 1; i++)
                    {
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = dt_shipconsignee.Rows[i]["Customer"].ToString();
                        dr[1] = dt_shipconsignee.Rows[i]["Retention"].ToString();
                    }
                    DataRow dr_temp = obj_dt.NewRow();
                    dr_temp[0] = "Total";
                    var sum_dt = obj_dt.Compute("sum(Retention)", string.Empty);
                    dr_temp[1] = sum_dt;
                    obj_dt.Rows.Add(dr_temp);
                    Grd_shiperconsigneeProduct.Visible = true;
                    Grd_shiperconsigneeProduct.DataSource = obj_dt;
                    ViewState["Grd_shiperconsigneeProduct"] = obj_dt;
                    Grd_shiperconsigneeProduct.DataBind();
                   // bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                }
                else
                {
                    DataSet obj_ds = new DataSet();
                    obj_ds = da_obj_Costtemp.SelTop50ShipperConsignee4Branch(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
                    obj_dt.Columns.Add("Shipper", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention4Shipper", DataType = typeof(double), DefaultValue = 0 });
                    obj_dt.Columns.Add("Consignee", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention4Consignee", DataType = typeof(double), DefaultValue = 0 });
                    if (obj_ds.Tables.Count > 0)
                    {
                        int max_count = Math.Max(obj_ds.Tables[0].Rows.Count, obj_ds.Tables[1].Rows.Count);


                        for (i = 0; i <= max_count - 1; i++)
                        {
                            DataRow dr = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr);
                            if (i < obj_ds.Tables[0].Rows.Count)
                            {
                                dr[0] = obj_ds.Tables[0].Rows[i]["customername"].ToString();
                                dr[1] = obj_ds.Tables[0].Rows[i]["Retention"].ToString();
                            }
                            if (i < obj_ds.Tables[1].Rows.Count)
                            {
                                dr[2] = obj_ds.Tables[1].Rows[i]["customername"].ToString();
                                dr[3] = obj_ds.Tables[1].Rows[i]["Retention"].ToString();
                            }

                        }

                        Grd_shiperconsignee.Visible = true;
                        Grd_shiperconsignee.Columns.Clear();
                        foreach (DataColumn column in obj_dt.Columns)
                        {
                            BoundField obj_field = new BoundField();
                            obj_field.DataField = column.ColumnName;

                            if (column.ColumnName.Contains("4") == true)
                            {
                                obj_field.HeaderText = column.ColumnName;
                                obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                obj_field.DataFormatString = "{0:#,##0.00}";
                            }
                            else
                            {
                                obj_field.HeaderText = column.ColumnName;

                            }

                            Grd_shiperconsignee.Columns.Add(obj_field);
                        }
                        Grd_shiperconsignee.Visible = true;
                        Grd_shiperconsignee.DataSource = obj_dt;
                        Grd_shiperconsignee.DataBind();
                       // bnt_cancel.Text = "Cancel";

                        bnt_cancel.ToolTip = "Cancel";
                        bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                        btn_Export.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void fn_YearMIS()
        {
            try
            {
                DataTable dt_YearMIS = new DataTable();
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int int_branchid = int.Parse(Session["LoginBranchid"].ToString());
                string transtype = HttpContext.Current.Session["StrTranType"].ToString();
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                int i;
                DataAccess.MIS misobj = new DataAccess.MIS();
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), empid, bid, 0);
                misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), empid, bid, 0);
                misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), empid, bid, 0);
                misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), empid, bid, 0);
                misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), empid, bid, 0);
                misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), empid, bid, 0);

                //da_obj_MIS.InsTempY2D("", Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Convert.ToInt32(Session["LoginEmpId"].ToString()), int_branchid,0);
                //da_obj_MIS.InsTempY2D("", Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Convert.ToInt32(Session["LoginEmpId"].ToString()), int_branchid, 0);
                //da_obj_MIS.InsTempY2D("", Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Convert.ToInt32(Session["LoginEmpId"].ToString()), int_branchid, 0);
                //da_obj_MIS.InsTempY2D("", Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Convert.ToInt32(Session["LoginEmpId"].ToString()), int_branchid, 0);
                //da_obj_MIS.InsTempY2D("", Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Convert.ToInt32(Session["LoginEmpId"].ToString()), int_branchid, 0);
                //da_obj_MIS.InsTempY2D("", Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Convert.ToInt32(Session["LoginEmpId"].ToString()), int_branchid, 0);

                obj_dt = da_obj_misgrd.GetYear2DateMISNew(int_branchid, empid, 0);
                if (obj_dt.Rows.Count > 0)
                {


                    var sum_incomey2d = obj_dt.Compute("sum(incomey2d)", "");
                    var sum_expensesy2d = obj_dt.Compute("sum(expensesy2d)", "");
                    var sum_retentiony2d = obj_dt.Compute("sum(rtny2d)", "");
                    var sum_Y2DPer = obj_dt.Compute("sum(Y2DPer)", "");
                    var sum_incomemonth = obj_dt.Compute("sum(incomemonth)", "");
                    var sum_expensesmonth = obj_dt.Compute("sum(expensesmonth)", "");
                    var sum_rtnmonth = obj_dt.Compute("sum(rtnmonth)", "");
                    var sum_MonPer = obj_dt.Compute("sum(MonPer)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[0] = sum_incomey2d;
                    dr1[1] = sum_expensesy2d;
                    dr1[2] = sum_retentiony2d;
                    //dr1[3] = sum_Y2DPer;
                    dr1[4] = "Total";
                    dr1[5] = sum_incomemonth;
                    dr1[6] = sum_expensesmonth;
                    dr1[7] = sum_rtnmonth;
                    //dr1[8] = sum_MonPer;

                    grd_YearMIS.Visible = true;
                    grd_YearMIS.DataSource = obj_dt;
                    grd_YearMIS.DataBind();
                   // bnt_cancel.Text = "Cancel";

                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";

                    btn_Export.Enabled = true;
                    //grd_YearMIS.Rows[grd_YearMIS.Rows.Count - 1].ForeColor = Utility.fn_Grd_GrandTotal_Color();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void fn_TrendCustomer()
        {
            string tran = "";
            if (Session["StrTranType"].ToString() == "AC")
            {
                try
                {

                    Grd_trendcustomer.Columns.Clear();
                    int i, j, k, count, int_year, int_month, int_custid, int_salesid;
                    double total;
                    DataTable obj_dt = new DataTable();
                    DataTable obj_dtcustomer = new DataTable();
                    string str_month;
                    string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                    DateTime frm_date, to_date;
                    frm_date = Convert.ToDateTime(str_fromdate);
                    to_date = Convert.ToDateTime(str_todate);
                    int m = 0;
                    DataAccess.CostingTemp da_obj_costing = new DataAccess.CostingTemp();
                    for (m = 0; m < 4; m++)
                    {


                        if (ddl_Report.SelectedItem.Text == "Trend Analysis - Customer With Product")
                        {
                            if (m == 0)
                            {
                                tran = "FE";
                                obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), "FE", frm_date, to_date, 0);
                            }
                            else if (m == 1)
                            {
                                tran = "FI";
                                obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), "FI", frm_date, to_date, 0);
                            }
                            else if (m == 2)
                            {
                                tran = "AE";
                                obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), "AE", frm_date, to_date, 0);
                            }
                            else if (m == 3)
                            {
                                tran = "AI";
                                obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), "AI", frm_date, to_date, 0);
                            }
                            else if (m == 4)
                            {
                                tran = "CH";
                                obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), "CH", frm_date, to_date, 0);
                            }
                        }
                        else
                        {
                            obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), frm_date, to_date, 0);
                        }


                        int month_diff = (to_date.Month - frm_date.Month) + 12 * (to_date.Year - frm_date.Year);
                        if (obj_dt.Rows.Count == 0)
                        {
                            obj_dt.Columns.Add("CustomerName", typeof(string));
                            obj_dt.Columns.Add("Sales Person", typeof(string));
                            obj_dt.Columns.Add("Product", typeof(string));
                            for (i = frm_date.Month; i < month_diff + frm_date.Month + 1; i++)
                            {
                                j = i % 12;

                                if (j == 0)
                                {
                                    str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToString();
                                }

                                else
                                {
                                    str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).ToString();
                                }

                                obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString(), DataType = typeof(double), DefaultValue = 0 });

                            }
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Total", DataType = typeof(double), DefaultValue = 0 });
                        }

                        for (i = 0; i <= obj_dtcustomer.Rows.Count - 1; i++)
                        {


                            int_custid = int.Parse(obj_dtcustomer.Rows[i]["custid"].ToString());
                            int_salesid = int.Parse(obj_dtcustomer.Rows[i]["salesid"].ToString());
                            DataRow dr = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr);
                            dr[0] = obj_dtcustomer.Rows[i]["customername"].ToString();
                            dr[1] = obj_dtcustomer.Rows[i]["empname"].ToString();
                            dr[2] = obj_dtcustomer.Rows[i]["product"].ToString();

                            // string tranType = obj_dtcustomer.Rows[i]["trantype"].ToString();
                            k = 3;
                            total = 0;
                            int_year = 0;
                            int_month = 0;
                            for (j = 0; j <= month_diff; j++)
                            {
                                //count = j % 12;
                                //if (count == 0)
                                //{
                                //    int_month = 12;
                                //    int_year++;
                                //}
                                //else
                                //{
                                //    int_month = j;
                                //    int_year = frm_date.Year;
                                //}
                                if (ddl_Report.SelectedItem.Text == "Trend Analysis - Customer With Product")
                                {

                                    if (frm_date.Month + j > 12)
                                    {
                                        dr[k] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tran, int_month + 1, to_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                        int_month = int_month + 1;
                                    }
                                    else
                                    {
                                        dr[k] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tran, frm_date.Month + j, frm_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                    }
                                }
                                else
                                {
                                    if (frm_date.Month + j > 12)
                                    {
                                        dr[k] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tran, int_month + 1, to_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                        int_month = int_month + 1;
                                    }
                                    else
                                    {
                                        dr[k] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tran, frm_date.Month + j, frm_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                    }
                                }

                                //total = total + double.Parse(da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), int_month, int_year, obj_dtcustomer.Rows[i]["empname"].ToString()).ToString());
                                total = total + double.Parse(dr[k].ToString());
                                k++;
                            }
                            dr[obj_dt.Columns.Count - 1] = total;

                        }
                    }

                    //Grd_trendcustomer.Columns.Clear();

                    DataRow dr_tot = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr_tot);
                    for (i = 3; i <= obj_dt.Columns.Count - 1; i++)
                    {
                        string str_colname = obj_dt.Columns[i].ColumnName.ToString();
                        var col_total = obj_dt.Compute("sum(" + str_colname + ")", "");
                        dr_tot[i] = col_total;
                    }

                    Grd_trendcustomer.Visible = true;
                    Grd_trendcustomer.DataSource = obj_dt;
                    Grd_trendcustomer.DataBind();
                   // bnt_cancel.Text = "Cancel";

                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";

                    btn_Export.Enabled = true;
                    foreach (DataColumn column in obj_dt.Columns)
                    {
                        BoundField obj_field = new BoundField();
                        obj_field.DataField = column.ColumnName;
                        string[] str_header = column.ColumnName.ToString().Split('0');
                        if (str_header.Length > 1)
                        {
                            obj_field.HeaderText = str_header[0].ToString();
                            obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                            obj_field.DataFormatString = "{0:#,##0.00}";
                        }
                        else
                        {
                            if (column.ColumnName.ToString() == "Total")
                            {
                                obj_field.HeaderText = column.ColumnName;
                                obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                obj_field.DataFormatString = "{0:#,##0.00}";
                            }
                            else
                            {
                                obj_field.HeaderText = column.ColumnName;
                            }
                        }

                        Grd_trendcustomer.Columns.Add(obj_field);
                    }
                    Grd_trendcustomer.DataSource = obj_dt;
                    Grd_trendcustomer.DataBind();
                 //   bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            else
            {
                try
                {
                    Grd_trendcustomer.Columns.Clear();
                    int i, j, k, count, int_year, int_month, int_custid, int_salesid;
                    double total;
                    DataTable obj_dt = new DataTable();
                    DataTable obj_dtcustomer = new DataTable();
                    string str_month;
                    string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                    DateTime frm_date, to_date;
                    frm_date = Convert.ToDateTime(str_fromdate);
                    to_date = Convert.ToDateTime(str_todate);

                    DataAccess.CostingTemp da_obj_costing = new DataAccess.CostingTemp();

                    obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), frm_date, to_date, 0);



                    int month_diff = (to_date.Month - frm_date.Month) + 12 * (to_date.Year - frm_date.Year);

                    obj_dt.Columns.Add("CustomerName", typeof(string));
                    obj_dt.Columns.Add("Sales Person", typeof(string));
                    obj_dt.Columns.Add("Product", typeof(string));

                    for (i = frm_date.Month; i < month_diff + frm_date.Month + 1; i++)
                    {
                        j = i % 12;

                        if (j == 0)
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToString();
                        }

                        else
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).ToString();
                        }

                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString(), DataType = typeof(double), DefaultValue = 0 });

                    }
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total", DataType = typeof(double), DefaultValue = 0 });


                    for (i = 0; i <= obj_dtcustomer.Rows.Count - 1; i++)
                    {


                        int_custid = int.Parse(obj_dtcustomer.Rows[i]["custid"].ToString());
                        int_salesid = int.Parse(obj_dtcustomer.Rows[i]["salesid"].ToString());
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = obj_dtcustomer.Rows[i]["customername"].ToString();
                        dr[1] = obj_dtcustomer.Rows[i]["empname"].ToString();
                        dr[2] = obj_dtcustomer.Rows[i]["product"].ToString();

                        // string tranType = obj_dtcustomer.Rows[i]["trantype"].ToString();
                        k = 3;
                        total = 0;
                        int_year = 0;
                        int_month = 0;
                        //month_diff
                        // for (j = frm_date.Month; j < month_diff + frm_date.Month + 1; j++)

                        for (j = 0; j <= month_diff; j++)
                        {
                            //count = j % 12;
                            //if (count == 0)
                            //{
                            //    int_month = 12;
                            //    int_year++;
                            //}
                            //else
                            //{
                            //    int_month = j;
                            //    int_year = frm_date.Year;
                            //}

                            if (frm_date.Month + j > 12)
                            {
                                dr[k] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), int_month + 1, to_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                int_month = int_month + 1;
                            }
                            else
                            {
                                dr[k] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), frm_date.Month + j, frm_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                            }

                            //total = total + double.Parse(da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), int_month, int_year, obj_dtcustomer.Rows[i]["empname"].ToString()).ToString());
                            total = total + double.Parse(dr[k].ToString());
                            k++;
                        }
                        dr[obj_dt.Columns.Count - 1] = total;

                    }
                    //Grd_trendcustomer.Columns.Clear();

                    DataRow dr_tot = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr_tot);
                    for (i = 3; i <= obj_dt.Columns.Count - 1; i++)
                    {
                        string str_colname = obj_dt.Columns[i].ColumnName.ToString();
                        var col_total = obj_dt.Compute("sum(" + str_colname + ")", "");
                        dr_tot[i] = col_total;
                    }

                    Grd_trendcustomer.Visible = true;
                    Grd_trendcustomer.DataSource = obj_dt;
                    Grd_trendcustomer.DataBind();
                   // bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    foreach (DataColumn column in obj_dt.Columns)
                    {
                        BoundField obj_field = new BoundField();
                        obj_field.DataField = column.ColumnName;
                        string[] str_header = column.ColumnName.ToString().Split('0');
                        if (str_header.Length > 1)
                        {
                            obj_field.HeaderText = str_header[0].ToString();
                            obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                            obj_field.DataFormatString = "{0:#,##0.00}";
                        }
                        else
                        {
                            if (column.ColumnName.ToString() == "Total")
                            {
                                obj_field.HeaderText = column.ColumnName;
                                obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                obj_field.DataFormatString = "{0:#,##0.00}";
                            }
                            else
                            {
                                obj_field.HeaderText = column.ColumnName;
                            }
                        }

                        Grd_trendcustomer.Columns.Add(obj_field);
                    }
                    Grd_trendcustomer.DataSource = obj_dt;
                    Grd_trendcustomer.DataBind();
                   // bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }
        private void fn_TrendCustomerVolume()
        {
            string strt = "";
            if (Session["StrTranType"].ToString() == "AC")
            {
                try
                {
                    int m = 0;
                    Grd_trendcustomervolume.AutoGenerateColumns = false;
                    Grd_trendcustomervolume.Columns.Clear();
                    int i, j, k, count, int_year, int_month, int_custid, int_salesid;
                    double cbm_total, tues_total, revenue_total;
                    DataTable obj_dt = new DataTable();
                    DataTable obj_dtcustomer = new DataTable();
                    string str_month;
                    string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                    DateTime frm_date, to_date;
                    frm_date = Convert.ToDateTime(str_fromdate);
                    to_date = Convert.ToDateTime(str_todate);

                    DataAccess.CostingTemp da_obj_costing = new DataAccess.CostingTemp();

                    obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), frm_date, to_date, 0);



                    int month_diff = (to_date.Month - frm_date.Month) + 12 * (to_date.Year - frm_date.Year);

                    obj_dt.Columns.Add("CustomerName", typeof(string));
                    obj_dt.Columns.Add("Sales Person", typeof(string));
                    obj_dt.Columns.Add("Product", typeof(string));

                    for (i = frm_date.Month; i < month_diff + frm_date.Month + 1; i++)
                    {
                        j = i % 12;

                        if (j == 0)
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToString();
                        }

                        else
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).ToString();
                        }

                        //obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "CBM", DataType = typeof(double), DefaultValue = 0 });
                        //obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "Teus", DataType = typeof(double), DefaultValue = 0 });
                        //obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "Revenue", DataType = typeof(double), DefaultValue = 0 });

                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "CBM"});
                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "Teus"});
                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "Revenue"});
                    }
                    //obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0CBM", DataType = typeof(double), DefaultValue = 0 });
                    //obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0Teus", DataType = typeof(double), DefaultValue = 0 });
                    //obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0Revenue", DataType = typeof(double), DefaultValue = 0 });

                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0CBM"});
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0Teus"});
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0Revenue"});


                    for (i = 0; i <= obj_dtcustomer.Rows.Count - 1; i++)
                    {


                        int_custid = int.Parse(obj_dtcustomer.Rows[i]["custid"].ToString());
                        int_salesid = int.Parse(obj_dtcustomer.Rows[i]["salesid"].ToString());
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = obj_dtcustomer.Rows[i]["customername"].ToString();
                        dr[1] = obj_dtcustomer.Rows[i]["empname"].ToString();
                        dr[2] = obj_dtcustomer.Rows[i]["product"].ToString();

                        string tranType = obj_dtcustomer.Rows[i]["trantype"].ToString();
                        k = 3;
                        cbm_total = 0;
                        tues_total = 0;
                        revenue_total = 0;
                        int_year = 0;
                        int_month = 0;
                        for (j = 0; j <= month_diff; j++)
                        {
                            //count = j % 12;
                            //if (count == 0)
                            //{
                            //    int_month = 12;
                            //    int_year++;
                            //}
                            //else
                            //{
                            //    int_month = j;
                            //    int_year = frm_date.Year;
                            //}
                            //dr[k] = String.Format("{0:d}", da_obj_costing.GetCBMforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, int_month, int_year));
                            //cbm_total = cbm_total + double.Parse(dr[k].ToString());
                            //dr[k + 1] = da_obj_costing.GetTuesforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, int_month, int_year);
                            //tues_total = tues_total + double.Parse(dr[k + 1].ToString());
                            //dr[k + 2] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, int_month, frm_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                            //revenue_total = revenue_total + double.Parse(dr[k + 2].ToString());
                            //k += 3;

                            if (frm_date.Month + j > 12)
                            {
                                dr[k] = String.Format("{0:d}", da_obj_costing.GetCBMforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, int_month + 1, to_date.Year));
                                cbm_total = cbm_total + double.Parse(dr[k].ToString());
                                dr[k + 1] = da_obj_costing.GetTuesforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, int_month + 1, to_date.Year);
                                tues_total = tues_total + double.Parse(dr[k + 1].ToString());
                                dr[k + 2] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, int_month + 1, to_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                revenue_total = revenue_total + double.Parse(dr[k + 2].ToString());
                                k += 3;
                                int_month = int_month + 1;
                            }
                            else
                            {
                                dr[k] = String.Format("{0:d}", da_obj_costing.GetCBMforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, frm_date.Month + j, frm_date.Year));
                                cbm_total = cbm_total + double.Parse(dr[k].ToString());
                                dr[k + 1] = da_obj_costing.GetTuesforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, frm_date.Month + j, frm_date.Year);
                                tues_total = tues_total + double.Parse(dr[k + 1].ToString());
                                dr[k + 2] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, tranType, frm_date.Month + j, frm_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                revenue_total = revenue_total + double.Parse(dr[k + 2].ToString());
                                k += 3;
                            }


                        }
                        dr[obj_dt.Columns.Count - 3] = cbm_total;
                        dr[obj_dt.Columns.Count - 2] = tues_total;
                        dr[obj_dt.Columns.Count - 1] = revenue_total;
                    }
                    DataRow dr_title = obj_dt.NewRow();
                    //for (i = 3; i <= obj_dt.Columns.Count - 1; i += 3)
                    //{

                    //    dr_title[i] = "CBM";
                    //    dr_title[i + 1] = "Tues";
                    //    dr_title[i + 2] = "Revenue";
                    //}
                    obj_dt.Rows.InsertAt(dr_title, 0);

                    Grd_trendcustomervolume.Visible = true;

                    foreach (DataColumn column in obj_dt.Columns)
                    {
                        BoundField obj_field = new BoundField();
                        obj_field.DataField = column.ColumnName;
                        string[] str_header = column.ColumnName.ToString().Split('0');
                        if (str_header.Length > 1)
                        {
                            obj_field.HeaderText = str_header[0].ToString();
                            obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                            obj_field.DataFormatString = "{0:#,##0.00}";

                        }
                        else
                        {
                            if (column.ColumnName.ToString() == "Total")
                            {
                                obj_field.HeaderText = column.ColumnName;
                                obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                obj_field.DataFormatString = "{0:#,##0.00}";

                            }
                            else
                            {
                                obj_field.HeaderText = column.ColumnName;
                            }
                        }

                        Grd_trendcustomervolume.Columns.Add(obj_field);
                    }

                    Grd_trendcustomervolume.DataSource = obj_dt;
                    ViewState["GrdVolume"] = obj_dt;
                    Grd_trendcustomervolume.DataBind();
                  //  bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    for (i = 3; i <= Grd_trendcustomervolume.Columns.Count - 1; i += 3)
                    {

                        Grd_trendcustomervolume.Rows[0].Cells[i].Text = "CBM";
                        Grd_trendcustomervolume.Rows[0].Cells[i + 1].Text = "Tues";
                        Grd_trendcustomervolume.Rows[0].Cells[i + 2].Text = "Revenue";
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            else
            {
                try
                {
                    Grd_trendcustomervolume.AutoGenerateColumns = false;
                    Grd_trendcustomervolume.Columns.Clear();
                    int i, j, k, count, int_year, int_month, int_custid, int_salesid;
                    double cbm_total, tues_total, revenue_total;
                    DataTable obj_dt = new DataTable();
                    DataTable obj_dtcustomer = new DataTable();
                    string str_month;
                    string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                    DateTime frm_date, to_date;
                    frm_date = Convert.ToDateTime(str_fromdate);
                    to_date = Convert.ToDateTime(str_todate);

                    DataAccess.CostingTemp da_obj_costing = new DataAccess.CostingTemp();
                    obj_dtcustomer = da_obj_costing.SelFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), frm_date, to_date, 0);

                    int month_diff = (to_date.Month - frm_date.Month) + 12 * (to_date.Year - frm_date.Year);

                    obj_dt.Columns.Add("CustomerName", typeof(string));
                    obj_dt.Columns.Add("Sales Person", typeof(string));
                    obj_dt.Columns.Add("Product", typeof(string));

                    for (i = frm_date.Month; i < month_diff + frm_date.Month + 1; i++)
                    {
                        j = i % 12;

                        if (j == 0)
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToString();
                        }

                        else
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).ToString();
                        }

                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "CBM", DataType = typeof(double), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "Teus", DataType = typeof(double), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString() + "Revenue", DataType = typeof(double), DefaultValue = 0 });

                    }
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0CBM", DataType = typeof(double), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0Teus", DataType = typeof(double), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total0Revenue", DataType = typeof(double), DefaultValue = 0 });

                    //month_diff
                    for (i = 0; i <= obj_dtcustomer.Rows.Count - 1; i++)
                    // for (i = 0; i < month_diff ; i++)
                    {


                        int_custid = int.Parse(obj_dtcustomer.Rows[i]["custid"].ToString());
                        int_salesid = int.Parse(obj_dtcustomer.Rows[i]["salesid"].ToString());
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = obj_dtcustomer.Rows[i]["customername"].ToString();
                        dr[1] = obj_dtcustomer.Rows[i]["empname"].ToString();
                        dr[2] = obj_dtcustomer.Rows[i]["product"].ToString();

                        //string tranType = obj_dtcustomer.Rows[i]["product"].ToString();
                        k = 3;
                        cbm_total = 0;
                        tues_total = 0;
                        revenue_total = 0;
                        int_year = 0;
                        int_month = 0;
                        for (j = 0; j <= month_diff; j++)
                        {
                            //count = j % 12;
                            //if (count == 0)
                            //{
                            //    int_month = 12;
                            //    int_year++;
                            //}
                            //else
                            //{
                            //    int_month = j;
                            //    int_year = frm_date.Year;
                            //}f
                            if (frm_date.Month + j > 12)
                            {
                                dr[k] = String.Format("{0:d}", da_obj_costing.GetCBMforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), int_month + 1, to_date.Year));
                                cbm_total = cbm_total + double.Parse(dr[k].ToString());
                                dr[k + 1] = da_obj_costing.GetTuesforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), int_month + 1, to_date.Year);
                                tues_total = tues_total + double.Parse(dr[k + 1].ToString());
                                dr[k + 2] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), int_month + 1, to_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                revenue_total = revenue_total + double.Parse(dr[k + 2].ToString());
                                k += 3;
                                int_month = int_month + 1;
                            }
                            else
                            {
                                dr[k] = String.Format("{0:d}", da_obj_costing.GetCBMforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), frm_date.Month + j, frm_date.Year));
                                cbm_total = cbm_total + double.Parse(dr[k].ToString());
                                dr[k + 1] = da_obj_costing.GetTuesforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), frm_date.Month + j, frm_date.Year);
                                tues_total = tues_total + double.Parse(dr[k + 1].ToString());
                                dr[k + 2] = da_obj_costing.GetRetentionforTrend(int_custid, int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), frm_date.Month + j, frm_date.Year, obj_dtcustomer.Rows[i]["empname"].ToString());
                                revenue_total = revenue_total + double.Parse(dr[k + 2].ToString());
                                k += 3;
                            }

                        }
                        dr[obj_dt.Columns.Count - 3] = cbm_total;
                        dr[obj_dt.Columns.Count - 2] = tues_total;
                        dr[obj_dt.Columns.Count - 1] = revenue_total;
                    }
                    DataRow dr_title = obj_dt.NewRow();
                    //for (i = 3; i <= obj_dt.Columns.Count - 1; i += 3)
                    //{

                    //    dr_title[i] = "CBM";
                    //    dr_title[i + 1] = "Tues";
                    //    dr_title[i + 2] = "Revenue";
                    //}
                    obj_dt.Rows.InsertAt(dr_title, 0);

                    Grd_trendcustomervolume.Visible = true;

                    foreach (DataColumn column in obj_dt.Columns)
                    {
                        BoundField obj_field = new BoundField();
                        obj_field.DataField = column.ColumnName;
                        string[] str_header = column.ColumnName.ToString().Split('0');
                        if (str_header.Length > 1)
                        {
                            obj_field.HeaderText = str_header[0].ToString();
                            obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                            obj_field.DataFormatString = "{0:#,##0.00}";
                        }
                        else
                        {
                            if (column.ColumnName.ToString() == "Total")
                            {
                                obj_field.HeaderText = column.ColumnName;
                                obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                obj_field.DataFormatString = "{0:#,##0.00}";
                            }
                            else
                            {
                                obj_field.HeaderText = column.ColumnName;
                            }
                        }
                        Grd_trendcustomervolume.Columns.Add(obj_field);
                    }
                    Grd_trendcustomervolume.DataSource = obj_dt;
                    ViewState["GrdVolume"] = obj_dt;
                    Grd_trendcustomervolume.DataBind();
                 //   bnt_cancel.Text = "Cancel";

                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                    for (i = 3; i <= Grd_trendcustomervolume.Columns.Count - 1; i += 3)
                    {

                        Grd_trendcustomervolume.Rows[0].Cells[i].Text = "CBM";
                        Grd_trendcustomervolume.Rows[0].Cells[i + 1].Text = "Tues";
                        Grd_trendcustomervolume.Rows[0].Cells[i + 2].Text = "Revenue";
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }
        private void fn_TrendSalesperson()
        {
            try
            {
                Grd_trendcustomer.Columns.Clear();
                int i, j, k, count, int_year, int_month, int_salesid;
                double total;
                DataTable obj_dt = new DataTable();
                DataTable obj_dtcustomer = new DataTable();
                string str_month;
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DateTime frm_date, to_date;
                frm_date = Convert.ToDateTime(str_fromdate);
                to_date = Convert.ToDateTime(str_todate);

                DataAccess.CostingTemp da_obj_costing = new DataAccess.CostingTemp();
                obj_dtcustomer = da_obj_costing.SelSalesFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), frm_date, to_date);

                int month_diff = (to_date.Month - frm_date.Month) + 12 * (to_date.Year - frm_date.Year);

                obj_dt.Columns.Add("Salesperson", typeof(string));


                for (i = frm_date.Month; i < month_diff + frm_date.Month + 1; i++)
                {
                    j = i % 12;

                    if (j == 0)
                    {
                        str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToString();
                    }

                    else
                    {
                        str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).ToString();
                    }

                    obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString(), DataType = typeof(double), DefaultValue = 0 });

                }
                obj_dt.Columns.Add(new DataColumn { ColumnName = "Total", DataType = typeof(double), DefaultValue = 0 });


                for (i = 0; i <= obj_dtcustomer.Rows.Count - 1; i++)
                {


                    int_salesid = int.Parse(obj_dtcustomer.Rows[i]["salid"].ToString());
                    DataRow dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = obj_dtcustomer.Rows[i]["Salesperson"].ToString();
                    k = 1;
                    total = 0;
                    int_year = frm_date.Year;
                    int_month = 0;
                    for (j = 0; j <= month_diff; j++)
                    {
                        //count = j % 12;
                        //if (count == 0)
                        //{
                        //    int_month = 12;
                        //}
                        //else
                        //{
                        //    int_month = count;
                        //}
                        if (frm_date.Month + j > 12)
                        {
                            dr[k] = da_obj_costing.GetRetentionforSales(int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), int_month + 1, to_date.Year);
                            int_month = int_month + 1;
                        }
                        else
                        {
                            dr[k] = da_obj_costing.GetRetentionforSales(int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), frm_date.Month + j, frm_date.Year);
                        }

                        total = total + double.Parse(dr[k].ToString());
                        k++;
                        if (int_month == 12)
                        {
                            int_year++;
                        }
                    }
                    dr[obj_dt.Columns.Count - 1] = total;

                }

                DataRow dr_tot = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_tot);
                for (i = 1; i <= obj_dt.Columns.Count - 1; i++)
                {
                    string str_colname = obj_dt.Columns[i].ColumnName.ToString();
                    var col_total = obj_dt.Compute("sum(" + str_colname + ")", "");
                    dr_tot[i] = col_total;
                }
                Grd_trendcustomer.Visible = true;
                Grd_trendcustomer.DataSource = null;
                Grd_trendcustomer.DataBind();
               // bnt_cancel.Text = "Cancel";


                bnt_cancel.ToolTip = "Cancel";
                bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                foreach (DataColumn column in obj_dt.Columns)
                {
                    BoundField obj_field = new BoundField();
                    obj_field.DataField = column.ColumnName;
                    string[] str_header = column.ColumnName.ToString().Split('0');
                    if (str_header.Length > 1)
                    {
                        obj_field.HeaderText = str_header[0].ToString();
                        obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                        obj_field.DataFormatString = "{0:#,##0.00}";
                    }
                    else
                    {
                        if (column.ColumnName.ToString() == "Total")
                        {
                            obj_field.HeaderText = column.ColumnName;
                            obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                            obj_field.DataFormatString = "{0:#,##0.00}";
                        }
                        else
                        {
                            obj_field.HeaderText = column.ColumnName;
                        }
                    }

                    Grd_trendcustomer.Columns.Add(obj_field);
                }

                Grd_trendcustomer.DataSource = obj_dt;
                Grd_trendcustomer.DataBind();
               // bnt_cancel.Text = "Cancel";


                bnt_cancel.ToolTip = "Cancel";
                bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                btn_Export.Enabled = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        /* private void fn_TrendSalesperson()
         {
             try
             {
                 Grd_trendcustomer.Columns.Clear();
                 int i, j, k, count, int_year, int_month, int_salesid;
                 double total;
                 DataTable obj_dt = new DataTable();
                 DataTable obj_dtcustomer = new DataTable();
                 string str_month;
                 string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                 string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                 DateTime frm_date, to_date;
                 frm_date = Convert.ToDateTime(str_fromdate);
                 to_date = Convert.ToDateTime(str_todate);

                 DataAccess.CostingTemp da_obj_costing = new DataAccess.CostingTemp();
                 obj_dtcustomer = da_obj_costing.SelSalesFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), frm_date, to_date);

                 int month_diff = (to_date.Month - frm_date.Month) + 12 * (to_date.Year - frm_date.Year);

                 obj_dt.Columns.Add("Salesperson", typeof(string));


                 for (i = frm_date.Month; i < month_diff + frm_date.Month + 1; i++)
                 {
                     j = i % 12;

                     if (j == 0)
                     {
                         str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToString();
                     }

                     else
                     {
                         str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).ToString();
                     }

                     obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString(), DataType = typeof(double), DefaultValue = 0 });

                 }
                 obj_dt.Columns.Add(new DataColumn { ColumnName = "Total", DataType = typeof(double), DefaultValue = 0 });


                 for (i = 0; i <= obj_dtcustomer.Rows.Count - 1; i++)
                 {


                     int_salesid = int.Parse(obj_dtcustomer.Rows[i]["salid"].ToString());
                     DataRow dr = obj_dt.NewRow();
                     obj_dt.Rows.Add(dr);
                     dr[0] = obj_dtcustomer.Rows[i]["Salesperson"].ToString();
                     k = 1;
                     total = 0;
                     int_year = frm_date.Year;
                     int_month = 0;
                     for (j = frm_date.Month; j < month_diff + frm_date.Month + 1; j++)
                     {
                        //count = j % 12;
                        //  if (count == 0)
                        //  {
                        //      int_month = 12;
                        //  }
                        //  else
                        //  {
                        //      int_month = count;
                        //  }
                        //  dr[k] = da_obj_costing.GetRetentionforSales(int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), int_month, int_year);
                         


                         if ((frm_date.Month + j) > 12)
                         {
                             dr[k] = da_obj_costing.GetRetentionforSales(int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), 1+int_month , int_year);
                             int_month = int_month + 1;
                         }
                         else
                         {
                             dr[k] = da_obj_costing.GetRetentionforSales(int_salesid, int.Parse(Session["LoginBranchid"].ToString()), 0, Session["StrTranType"].ToString(), frm_date.Month + j, int_year);
                         }
                         //frmmnth + i > 12 Then
                       //   grdtren.Rows(j).Cells(Rc).Value = (costtempobj.GetRetentionforSales(intsalid, branchid, empid, strtrantype, 1 + fm, Year(dtto.Value)))
                       //    fm = fm + 1
                       //Else
                       //    grdtren.Rows(j).Cells(Rc).Value = (costtempobj.GetRetentionforSales(intsalid, branchid, empid, strtrantype, frmmnth + i, Year(dtfrom.Value)))
                       //End If

                         total = total + double.Parse(dr[k].ToString());
                         k++;
                         if (int_month == 12)
                         {
                             int_year++;
                         }
                     }
                     dr[obj_dt.Columns.Count - 1] = total;

                 }

                 DataRow dr_tot = obj_dt.NewRow();
                 obj_dt.Rows.Add(dr_tot);
                 for (i = 1; i <= obj_dt.Columns.Count - 1; i++)
                 {
                     string str_colname = obj_dt.Columns[i].ColumnName.ToString();
                     var col_total = obj_dt.Compute("sum(" + str_colname + ")", "");
                     dr_tot[i] = col_total;
                 }
                 Grd_trendcustomer.Visible = true;
                 Grd_trendcustomer.DataSource = null;
                 Grd_trendcustomer.DataBind();
                 bnt_cancel.Text = "Cancel";
                 foreach (DataColumn column in obj_dt.Columns)
                 {
                     BoundField obj_field = new BoundField();
                     obj_field.DataField = column.ColumnName;
                     string[] str_header = column.ColumnName.ToString().Split('0');
                     if (str_header.Length > 1)
                     {
                         obj_field.HeaderText = str_header[0].ToString();
                         obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                         obj_field.DataFormatString = "{0:#,##0.00}";
                     }
                     else
                     {
                         if (column.ColumnName.ToString() == "Total")
                         {
                             obj_field.HeaderText = column.ColumnName;
                             obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                             obj_field.DataFormatString = "{0:#,##0.00}";
                         }
                         else
                         {
                             obj_field.HeaderText = column.ColumnName;
                         }
                     }

                     Grd_trendcustomer.Columns.Add(obj_field);
                 }

                 Grd_trendcustomer.DataSource = obj_dt;
                 Grd_trendcustomer.DataBind();
                 bnt_cancel.Text = "Cancel";
                 btn_Export.Enabled = true;
             }
             catch (Exception ex)
             {
                 string message = ex.Message.ToString();
                 ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
             }
         }*/
        private void fn_TrendProduct()
        {
            int cou = 0;
            string st = "";
            if (Session["StrTranType"].ToString() == "AC")
            {
                try
                {
                    Grd_trendcustomer.Columns.Clear();
                    int i, j, k, count, int_year, int_month;
                    double total;
                    DataTable obj_dt = new DataTable();
                    DataTable obj_dtcustomer = new DataTable();
                    string str_month;
                    string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                    DateTime frm_date, to_date;
                    frm_date = Convert.ToDateTime(str_fromdate);
                    to_date = Convert.ToDateTime(str_todate);

                    DataAccess.CostingTemp da_obj_costing = new DataAccess.CostingTemp();


                    int month_diff = (to_date.Month - frm_date.Month) + 12 * (to_date.Year - frm_date.Year);

                    obj_dt.Columns.Add("Product", typeof(string));


                    for (i = frm_date.Month; i < month_diff + frm_date.Month + 1; i++)
                    {
                        j = i % 12;

                        if (j == 0)
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToString();
                        }

                        else
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).ToString();
                        }

                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString(), DataType = typeof(double), DefaultValue = 0 });

                    }
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total", DataType = typeof(double), DefaultValue = 0 });




                    DataRow dr = obj_dt.NewRow();
                    //  dr = obj_dt.NewRow();


                    k = 1;
                    int l;
                    total = 0;
                    int_year = frm_date.Year;
                    int_month = 0;
                    for (j = 0; j <= month_diff; j++)
                    {
                        //count = j % 12;
                        //if (count == 0)
                        //{
                        //    int_month = 12;
                        //}
                        //else
                        //{
                        //    int_month = count;
                        //}
                        if (frm_date.Month + j > 12)
                        {
                            obj_dtcustomer = da_obj_costing.SelProductFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), int_month + 1, to_date.Year);
                            int_month = int_month + 1;
                        }
                        else
                        {
                            obj_dtcustomer = da_obj_costing.SelProductFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), frm_date.Month + j, frm_date.Year);
                        }

                        for (i = 0; i <= obj_dtcustomer.Rows.Count - 1; i++)
                        {
                            total = 0;

                            //if (obj_dt.Rows.Count==0)
                            //{

                            string fstr = "";

                            if (obj_dt.Rows.Count > 0)
                            {

                                if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "FE")
                                {
                                    fstr = "Ocean Exports";
                                    for (int r = 0; r < obj_dt.Rows.Count; r++)
                                    {
                                        if (obj_dt.Rows[r][0].ToString() == fstr.ToString())
                                        {
                                            //dr = obj_dt.NewRow();
                                            //obj_dt.Rows.Add(dr);
                                            //break;

                                            blr = true;
                                           
                                        }
                                    }
                                   


                                }
                                else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "FI")
                                {
                                    fstr = "Ocean Imports";
                                    for (int r = 0; r < obj_dt.Rows.Count; r++)
                                    {
                                        if (obj_dt.Rows[r][0].ToString() == fstr.ToString())
                                        {
                                            //dr = obj_dt.NewRow();
                                            //obj_dt.Rows.Add(dr);
                                            //break;
                                            blr = true;
                                           
                                        }
                                    }
                                   
                                }
                                else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AE")
                                {
                                    fstr = "Air Exports";
                                    for (int r = 0; r < obj_dt.Rows.Count; r++)
                                    {
                                        if (obj_dt.Rows[r][0].ToString() == fstr.ToString())
                                        {
                                            //dr = obj_dt.NewRow();
                                            //obj_dt.Rows.Add(dr);
                                            //break;
                                            blr = true;
                                           
                                        }
                                    }
                                   
                                }
                                else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AI")
                                {
                                    fstr = "Air Imports";
                                    for (int r = 0; r < obj_dt.Rows.Count; r++)
                                    {
                                        if (obj_dt.Rows[r][0].ToString() == fstr.ToString())
                                        {
                                            //dr = obj_dt.NewRow();
                                            //obj_dt.Rows.Add(dr);
                                            //break;
                                            blr = true;
                                          
                                        }
                                    }
                                   
                                }
                                else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "CH")
                                {
                                    fstr = "C H A";
                                    for (int r = 0; r < obj_dt.Rows.Count; r++)
                                    {
                                        if (obj_dt.Rows[r][0].ToString() == fstr.ToString())
                                        {
                                            //dr = obj_dt.NewRow();
                                            //obj_dt.Rows.Add(dr);
                                            //break;
                                            blr = true;
                                           
                                        }
                                    }
                                   

                                }
                                else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AD")
                                {

                                    fstr = "Admin";
                                    for (int r = 0; r < obj_dt.Rows.Count; r++)
                                    {
                                        if (obj_dt.Rows[r][0].ToString() == fstr.ToString())
                                        {
                                            //dr = obj_dt.NewRow();
                                            //obj_dt.Rows.Add(dr);
                                            //break;
                                            blr = true;
                                           

                                        }
                                    }
                                    
                                }

                                if (blr == false)
                                {
                                    dr = obj_dt.NewRow();
                                    obj_dt.Rows.Add(dr);
                                }

                            }
                           

                            else
                            {
                                dr = obj_dt.NewRow();
                                obj_dt.Rows.Add(dr);
                            }



                            //dr = obj_dt.NewRow();
                            //obj_dt.Rows.Add(dr);
                            //}
                            //else
                            //{
                            //    //for (int r = 0; r <= obj_dt.Rows.Count - 1; r++)
                            //    //{
                            //    if (obj_dtcustomer.Rows[i]["trantype"].ToString() != obj_dt.Rows[i][0].ToString())
                            //    {
                            //        dr = obj_dt.NewRow();
                            //        obj_dt.Rows.Add(dr);
                            //    }
                            //    //}
                            //}
                            //obj_dt.Rows.Add();
                           
                            if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "FE")
                            {
                                if (blr == true)
                                {
                                    
                                    st = "Ocean Exports";
                                }
                                else
                                {
                                    dr[0] = "Ocean Exports";
                                }
                              
                                //for (int r = 0; r < obj_dt.Rows.Count; r++)
                                //{
                                //    if (dr[0].ToString() == obj_dt.Rows[r][0].ToString())
                                //    {
                                //        blr = true;
                                //    }
                                //}

                                //if (blr==false)
                                //{
                                //    dr = obj_dt.NewRow();
                                //    obj_dt.Rows.Add(dr);
                                //}
                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "FI")
                            {
                                if (blr == true)
                                {
                                    st = "Ocean Imports";
                                }
                                else
                                {
                                    dr[0] = "Ocean Imports";
                                }

                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AE")
                            {
                                if (blr == true)
                                {
                                    st = "Air Exports";
                                }
                                else
                                {
                                    dr[0] = "Air Exports";
                                }

                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AI")
                            {
                                if (blr == true)
                                {
                                    st = "Air Imports";
                                }
                                else
                                {
                                    dr[0] = "Air Imports";
                                }

                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "CH")
                            {
                                if (blr == true)
                                {
                                    st = "C H A";
                                }
                                else
                                {
                                    dr[0] = "C H A";
                                }

                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AD")
                            {
                                if (blr == true)
                                {
                                    st = "Admin";
                                }
                                else
                                {
                                    dr[0] = "Admin";
                                }

                            }

                            //   obj_dt.Rows[i][0] = dr[k];




                            //obj_dt.Rows[i][0] = dr[0];
                            //obj_dt.Rows[i][k] = obj_dtcustomer.Rows[i]["Retention"];
                            //total = total + double.Parse(dr[k].ToString());
                            //obj_dt.Rows[i]["Total"] = total;


                            for (l = 0; l <= obj_dt.Rows.Count - 1; l++)
                            {
                                if (obj_dt.Rows[l][0].ToString() != "")
                                {
                                    if (blr == true)
                                    {
                                        if (obj_dt.Rows[l][0].ToString() == st)
                                        {
                                            obj_dt.Rows[l][0] = st;
                                            obj_dt.Rows[l][k] = obj_dtcustomer.Rows[i]["Retention"];
                                            //total = total + double.Parse(dr[k].ToString());
                                            //obj_dt.Rows[l]["Total"] = total;
                                            cou = 0;
                                            blr = false;
                                            break;
                                        }
                                    }
                                    if (obj_dt.Rows[l][0].ToString() == dr[0].ToString())
                                    {
                                        obj_dt.Rows[l][0] = dr[0];
                                        obj_dt.Rows[l][k] = obj_dtcustomer.Rows[i]["Retention"];
                                        //total = total + double.Parse(dr[k].ToString());
                                        //obj_dt.Rows[l]["Total"] = total;
                                        cou = 0;
                                        break;
                                    }

                                }
                                cou = 1;
                            }

                            // dr[k] = obj_dtcustomer.Rows[i]["Retention"];
                            //  total = total + double.Parse(dr[k].ToString());

                            //  dr[obj_dt.Columns.Count - 1] = total;
                            //k += 1; 
                            //k++;
                            //total = total + double.Parse(dr[k].ToString());
                            //k++;

                            if (cou == 1)
                            {
                                cou = 0;
                                obj_dt.Rows[obj_dt.Rows.Count - 1][0] = dr[0];
                                obj_dt.Rows[obj_dt.Rows.Count - 1][k] = obj_dtcustomer.Rows[i]["Retention"];
                                //total = total + double.Parse(dr[k].ToString());
                                //obj_dt.Rows[obj_dt.Rows.Count - 1]["Total"] = total;
                            }
                        }
                        k++;

                        for (int n = 0; n <= obj_dt.Rows.Count - 1; n++)
                        {
                            DataRow dr1 = obj_dt.Rows[n];
                            if (dr[0] == "")
                            {
                                dr.Delete();
                            }

                        }
                        if (int_month == 12)
                        {
                            int_year++;
                        }
                    }
                    dr[obj_dt.Columns.Count - 1] = total;


                    DataRow dr_tot = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr_tot);
                    
                    for (i = 1; i < obj_dt.Columns.Count - 1; i++)
                    {
                        string str_colname = obj_dt.Columns[i].ColumnName.ToString();
                        var col_total = obj_dt.Compute("sum(" + str_colname + ")", "");
                        dr_tot[i] = col_total;
                    }

                    for (int m = 0; m < obj_dt.Rows.Count ; m++)
                    {
                        double col_total = 0;
                        for (i = 1; i < obj_dt.Columns.Count - 1; i++)
                        {
                            //string str_colname = obj_dt.Columns[i].ColumnName.ToString();
                            //var col_total = obj_dt.Compute("sum(" + str_colname + ")", "");
                            col_total += Convert.ToDouble(obj_dt.Rows[m][i].ToString());
                        }
                        obj_dt.Rows[m]["Total"] = col_total.ToString("#0.00");
                    }


                    Grd_trendcustomer.Visible = true;
                    Grd_trendcustomer.DataSource = null;
                    Grd_trendcustomer.DataBind();
                 //   bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    foreach (DataColumn column in obj_dt.Columns)
                    {
                        BoundField obj_field = new BoundField();
                        obj_field.DataField = column.ColumnName;
                        string[] str_header = column.ColumnName.ToString().Split('0');
                        if (str_header.Length > 1)
                        {
                            obj_field.HeaderText = str_header[0].ToString();
                            obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                            obj_field.DataFormatString = "{0:#,##0.00}";
                        }
                        else
                        {
                            if (column.ColumnName.ToString() == "Total")
                            {
                                obj_field.HeaderText = column.ColumnName;
                                obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                obj_field.DataFormatString = "{0:#,##0.00}";
                            }
                            else
                            {
                                obj_field.HeaderText = column.ColumnName;
                            }
                        }

                        Grd_trendcustomer.Columns.Add(obj_field);
                    }

                    Grd_trendcustomer.DataSource = obj_dt;
                    Grd_trendcustomer.DataBind();
                   // bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            else
            {
                try
                {
                    Grd_trendcustomer.Columns.Clear();
                    int i, j, k, count, int_year, int_month;
                    double total;
                    DataTable obj_dt = new DataTable();
                    DataTable obj_dtcustomer = new DataTable();
                    string str_month;
                    string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                    DateTime frm_date, to_date;
                    frm_date = Convert.ToDateTime(str_fromdate);
                    to_date = Convert.ToDateTime(str_todate);

                    DataAccess.CostingTemp da_obj_costing = new DataAccess.CostingTemp();


                    int month_diff = (to_date.Month - frm_date.Month) + 12 * (to_date.Year - frm_date.Year);

                    obj_dt.Columns.Add("Product", typeof(string));


                    for (i = frm_date.Month; i < month_diff + frm_date.Month + 1; i++)
                    {
                        j = i % 12;

                        if (j == 0)
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12).ToString();
                        }

                        else
                        {
                            str_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).ToString();
                        }

                        obj_dt.Columns.Add(new DataColumn { ColumnName = str_month + "0" + i.ToString(), DataType = typeof(double), DefaultValue = 0 });

                    }
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Total", DataType = typeof(double), DefaultValue = 0 });




                    DataRow dr = obj_dt.NewRow();
                    //  dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);


                    k = 1;
                    total = 0;
                    int_year = frm_date.Year;
                    int_month = 0;
                    for (j = 0; j <= month_diff; j++)
                    {
                        //count = j % 12;
                        //if (count == 0)
                        //{
                        //    int_month = 12;
                        //}
                        //else
                        //{
                        //    int_month = count;
                        //}
                        if (frm_date.Month + j > 12)
                        {
                            obj_dtcustomer = da_obj_costing.SelProductFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), int_month + 1, to_date.Year);
                            int_month = int_month + 1;
                        }
                        else
                        {
                            obj_dtcustomer = da_obj_costing.SelProductFromCostDtls(0, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), frm_date.Month + j, frm_date.Year);
                        }

                        for (i = 0; i <= obj_dtcustomer.Rows.Count - 1; i++)
                        {
                            //total = 0;


                            // DataRow dr = obj_dt.NewRow();
                            //dr = obj_dt.NewRow();
                            //   obj_dt.Rows.Add(dr);




                            if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "FE")
                            {
                                dr[0] = "Ocean Exports";
                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "FI")
                            {
                                dr[0] = "Ocean Imports";
                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AE")
                            {
                                dr[0] = "Air Exports";
                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AI")
                            {
                                dr[0] = "Air Imports";
                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "CH")
                            {
                                dr[0] = "C H A";
                            }
                            else if (obj_dtcustomer.Rows[i]["trantype"].ToString() == "AD")
                            {
                                dr[0] = "Admin";
                            }
                            //   obj_dt.Rows[i][0] = dr[k];



                            //if (Session["StrTranType"].ToString() == "AC")
                            //{
                            //    obj_dt.Rows[i][0] = dr[0];
                            //    obj_dt.Rows[i][k] = obj_dtcustomer.Rows[i]["Retention"];
                            //    total = total + double.Parse(dr[k].ToString());
                            //    obj_dt.Rows[i]["Total"] = total;
                            //}

                            dr[k] = obj_dtcustomer.Rows[i]["Retention"];
                            total = total + double.Parse(dr[k].ToString());

                            //  dr[obj_dt.Columns.Count - 1] = total;
                            //k += 1; 
                            //k++;
                            //total = total + double.Parse(dr[k].ToString());
                            //k++;

                        }
                        k++;
                        if (int_month == 12)
                        {
                            int_year++;
                        }
                    }
                    dr[obj_dt.Columns.Count - 1] = total;


                    DataRow dr_tot = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr_tot);
                    for (i = 1; i <= obj_dt.Columns.Count - 1; i++)
                    {
                        string str_colname = obj_dt.Columns[i].ColumnName.ToString();
                        var col_total = obj_dt.Compute("sum(" + str_colname + ")", "");
                        dr_tot[i] = col_total;
                    }

                    Grd_trendcustomer.Visible = true;
                    Grd_trendcustomer.DataSource = null;
                    Grd_trendcustomer.DataBind();
                    //bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    foreach (DataColumn column in obj_dt.Columns)
                    {
                        BoundField obj_field = new BoundField();
                        obj_field.DataField = column.ColumnName;
                        string[] str_header = column.ColumnName.ToString().Split('0');
                        if (str_header.Length > 1)
                        {
                            obj_field.HeaderText = str_header[0].ToString();
                            obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                            obj_field.DataFormatString = "{0:#,##0.00}";
                        }
                        else
                        {
                            if (column.ColumnName.ToString() == "Total")
                            {
                                obj_field.HeaderText = column.ColumnName;
                                obj_field.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                obj_field.DataFormatString = "{0:#,##0.00}";
                            }
                            else
                            {
                                obj_field.HeaderText = column.ColumnName;
                            }
                        }

                        Grd_trendcustomer.Columns.Add(obj_field);
                    }

                    Grd_trendcustomer.DataSource = obj_dt;
                    Grd_trendcustomer.DataBind();
                 //   bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_Export.Enabled = true;
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }
        private void fn_MIS()
        {
            try
            {
                DataSet obj_ds = new DataSet();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DateTime frm_date, to_date;
                frm_date = Convert.ToDateTime(str_fromdate);
                to_date = Convert.ToDateTime(str_todate);
                DataAccess.CostingDetails da_obj_Costing = new DataAccess.CostingDetails();
                //if (Session["StrTranType"].ToString() == "AC")
                //{
                //    obj_ds = da_obj_Costing.SELTempMISFTWOAC(int.Parse(Session["LoginBranchid"].ToString()), frm_date, to_date, int.Parse(Session["LoginEmpId"].ToString()));
                //}
                //else
                //{
                //    obj_ds = da_obj_Costing.SELTempMISFTWO(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), frm_date, to_date, int.Parse(Session["LoginEmpId"].ToString()));
                //}

                if (Session["StrTranType"].ToString() != "AC")
                {

                    obj_ds = da_obj_Costing.SELTempMISFTWO(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), frm_date, to_date, int.Parse(Session["LoginEmpId"].ToString()));

                }
                else
                {
                    obj_ds = da_obj_Costing.SELTempMISFTWOAC(int.Parse(Session["LoginBranchid"].ToString()), frm_date, to_date, int.Parse(Session["LoginEmpId"].ToString()));
                }
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                DataTable obj_dt_MISA = new DataTable();
                DataTable obj_dt_MISB = new DataTable();
                DataTable obj_dt_MISC = new DataTable();
                DataTable obj_dt_MISD = new DataTable();

                if (obj_ds.Tables.Count > 2)
                {
                    Pln_MIS.Visible = true;
                    obj_dt = obj_ds.Tables[0];
                    obj_dt_MISA = obj_ds.Tables[1];
                    obj_dt_MISB = obj_ds.Tables[2];
                    obj_dt_MISC = obj_ds.Tables[3];
                    obj_dt_MISD = obj_ds.Tables[4];
                    DataView obj_dvMIS = new DataView(obj_dt_MISD);
                    DataRow dr;
                    int i;
                    double MIS_A, MIS_B, MIS_C, MIS_D;
                    MIS_A = 0;
                    MIS_B = 0;
                    MIS_C = 0;
                    MIS_D = 0;
                    if (obj_dt.Rows.Count > 0)
                    {
                        //obj_dt.DefaultView.Sort = "jobno";
                        obj_dvMIS.RowFilter = "flagtype='A'";
                        obj_dttemp = obj_dvMIS.ToTable();
                        i = obj_dt.Columns.Count - 4;
                        dr = obj_dt.NewRow();
                        dr[i] = "Total-A";
                        dr[i + 1] = obj_dttemp.Rows[0]["income"];
                        dr[i + 2] = obj_dttemp.Rows[0]["expense"];
                        dr[i + 3] = obj_dttemp.Rows[0]["Retention"];
                        MIS_A = Convert.ToDouble(obj_dttemp.Rows[0]["Retention"].ToString());
                        obj_dt.Rows.InsertAt(dr, obj_dt.Rows.Count + 1);
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
                    if (obj_dt_MISA.Rows.Count > 0)
                    {
                        //obj_dt_MISA.DefaultView.Sort = "jobno";
                        obj_dvMIS.RowFilter = "flagtype='B'";
                        obj_dttemp = obj_dvMIS.ToTable();
                        i = obj_dt_MISA.Columns.Count - 4;
                        dr = obj_dt_MISA.NewRow();
                        dr[i] = "Total-D";
                        dr[i + 1] = obj_dttemp.Rows[0]["income"];
                        dr[i + 2] = obj_dttemp.Rows[0]["expense"];
                        dr[i + 3] = obj_dttemp.Rows[0]["Retention"];
                        MIS_D = Convert.ToDouble(obj_dttemp.Rows[0]["Retention"].ToString());
                        obj_dt_MISA.Rows.InsertAt(dr, obj_dt_MISA.Rows.Count + 1);
                        lbl_MISD.Visible = true;
                        Grd_MISD.Visible = true;
                        Grd_MISD.DataSource = obj_dt_MISA;
                        Grd_MISD.DataBind();
                    }
                    else
                    {
                        Grd_MISD.Visible = true;
                        Grd_MISD.DataSource = new DataTable();
                        Grd_MISD.DataBind();
                    }
                    if (obj_dt_MISB.Rows.Count > 0)
                    {
                        //obj_dt_MISB.DefaultView.Sort = "jobno";
                        obj_dvMIS.RowFilter = "flagtype='C'";
                        obj_dttemp = obj_dvMIS.ToTable();
                        i = obj_dt_MISB.Columns.Count - 4;
                        dr = obj_dt_MISB.NewRow();
                        dr[i] = "Total-C";
                        dr[i + 1] = obj_dttemp.Rows[0]["income"];
                        dr[i + 2] = obj_dttemp.Rows[0]["expense"];
                        dr[i + 3] = obj_dttemp.Rows[0]["Retention"];
                        MIS_C = Convert.ToDouble(obj_dttemp.Rows[0]["Retention"].ToString());
                        obj_dt_MISB.Rows.InsertAt(dr, obj_dt_MISB.Rows.Count + 1);
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
                    if (obj_dt_MISC.Rows.Count > 0)
                    {
                        //obj_dt_MISC.DefaultView.Sort = "jobno";

                        obj_dvMIS.RowFilter = "flagtype='D'";
                        obj_dttemp = obj_dvMIS.ToTable();
                        i = obj_dt_MISC.Columns.Count - 4;
                        dr = obj_dt_MISC.NewRow();
                        dr[i] = "Total-B";
                        dr[i + 1] = obj_dttemp.Rows[0]["income"];
                        dr[i + 2] = obj_dttemp.Rows[0]["expense"];
                        dr[i + 3] = obj_dttemp.Rows[0]["Retention"];
                        MIS_B = Convert.ToDouble(obj_dttemp.Rows[0]["Retention"].ToString());
                        obj_dt_MISC.Rows.InsertAt(dr, obj_dt_MISC.Rows.Count + 1);
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

                    if (obj_dt.Rows.Count > 0 || obj_dt_MISA.Rows.Count > 0 || obj_dt_MISB.Rows.Count > 0 || obj_dt_MISC.Rows.Count > 0)
                    {
                        lbl_retention.Text = "";
                        lbl_retention.Visible = true;
                        lbl_retention.Text = "(A+B) - (C+D)           Net Retention = " + String.Format("{0:0.00}", ((MIS_A + MIS_B) - Math.Abs(MIS_C + MIS_D)));
                        //bnt_cancel.Text = "Cancel";


                        bnt_cancel.ToolTip = "Cancel";
                        bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                        btn_Export.Enabled = true;
                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "MIS", "alertify.alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //private void fn_Retention()
        //{
        //    try
        //    {
        //        int int_branchid, int_divisionid, i;
        //        string StrTrantype;
        //        double Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_Retention, Tot_Tues, Tot_CBM;
        //        int_branchid = int.Parse(Session["LoginBranchid"].ToString());
        //        int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
        //        StrTrantype = Session["StrTranType"].ToString();
        //        DataSet obj_ds = new DataSet();
        //        DataTable obj_dt = new DataTable();
        //        DataTable obj_dttemp = new DataTable();
        //        string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
        //        string str_todate = Utility.fn_ConvertDate(txt_To.Text);
        //        DateTime frm_date, to_date;
        //        frm_date = Convert.ToDateTime(str_fromdate);
        //        to_date = Convert.ToDateTime(str_todate);
        //        DataAccess.CostingTemp da_obj_Costing = new DataAccess.CostingTemp();
        //        string Trantype = "";
        //        if (StrTrantype == "FE")
        //        {
        //            Trantype = "Ocean Exports";
        //        }
        //        else if (StrTrantype == "FI")
        //        {
        //            Trantype = "Ocean Imports";
        //        }
        //        else if (StrTrantype == "AI")
        //        {
        //            Trantype = "Air Imports";
        //        }
        //        else if (StrTrantype == "AE")
        //        {
        //            Trantype = "Air Exports";
        //        }

        //        if (StrTrantype == "FE" || StrTrantype == "FI")
        //        {
        //            obj_dt.Columns.Add("column1");
        //            obj_dt.Columns.Add("column2");
        //            obj_dt.Columns.Add("column3");
        //            obj_dt.Columns.Add("column4");
        //            obj_dt.Columns.Add("column5");
        //            obj_dt.Columns.Add("column6");
        //            obj_dt.Columns.Add("column7");
        //            obj_dt.Columns.Add("column8");
        //            Tot_Retention = 0;
        //            Tot_Tues = 0;
        //            Tot_CBM = 0;
        //            //Region -Consol
        //            DataRow dr = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr);
        //            dr[0] = Trantype + "- Consol";
        //            dr = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr);
        //            dr[1] = "Controlled";
        //            dr[2] = "by US";
        //            dr[3] = "Agent";
        //            dr[4] = "Controlled";

        //            dr = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr);
        //            dr[0] = "Agent";
        //            dr[1] = "M3";
        //            dr[2] = "Retention";
        //            dr[3] = "M3";
        //            dr[4] = "Retention";
        //            dr[5] = "Total M3";
        //            dr[6] = "Total Retention";
        //            dr[7] = "Teus";
        //            obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "Consol", int_branchid, StrTrantype);
        //            if (obj_ds.Tables.Count > 0)
        //            {
        //                Tot_1 = 0;
        //                Tot_2 = 0;
        //                Tot_3 = 0;
        //                Tot_4 = 0;
        //                Tot_5 = 0;
        //                Tot_6 = 0;
        //                Tot_7 = 0;
        //                obj_dttemp = obj_ds.Tables[0];
        //                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
        //                {
        //                    dr = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr);
        //                    dr[0] = obj_dttemp.Rows[i][0].ToString();
        //                    dr[1] = obj_dttemp.Rows[i][1].ToString();
        //                    Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
        //                    dr[2] = obj_dttemp.Rows[i][2].ToString();
        //                    Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());
        //                    dr[3] = obj_dttemp.Rows[i][3].ToString();
        //                    Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][3].ToString());
        //                    dr[4] = obj_dttemp.Rows[i][4].ToString();
        //                    Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());
        //                    dr[5] = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
        //                    Tot_5 = Tot_5 + (double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString()));
        //                    dr[6] = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
        //                    Tot_6 = Tot_6 + (double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString()));
        //                    dr[7] = obj_dttemp.Rows[i][5].ToString();
        //                    Tot_7 = Tot_7 + double.Parse(obj_dttemp.Rows[i][5].ToString());
        //                }
        //                if (obj_dttemp.Rows.Count > 0)
        //                {
        //                    dr = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr);
        //                    dr[0] = "Total";
        //                    dr[1] = Tot_1;
        //                    dr[2] = Tot_2;
        //                    dr[3] = Tot_3;
        //                    dr[4] = Tot_4;
        //                    dr[5] = Tot_5;
        //                    dr[6] = Tot_6;
        //                    dr[7] = Tot_7;
        //                    Tot_Retention = Tot_Retention + Tot_6;
        //                    Tot_Tues = Tot_Tues + Tot_7;
        //                    Tot_CBM = Tot_CBM + Tot_5;
        //                }
        //            }
        //            dr = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr);
        //            //End Region -Consol

        //            //Region- LCL
        //            DataRow dr1 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr1);
        //            dr1[0] = Trantype + "- LCL";
        //            dr1 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr1);
        //            dr1[1] = "Controlled";
        //            dr1[2] = "by US";
        //            dr1[3] = "Agent";
        //            dr1[4] = "Controlled";

        //            dr1 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr1);
        //            dr1[0] = "Agent";
        //            dr1[1] = "M3";
        //            dr1[2] = "Retention";
        //            dr1[3] = "M3";
        //            dr1[4] = "Retention";
        //            dr1[5] = "Total M3";
        //            dr1[6] = "Total Retention";

        //            obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "LCL", int_branchid, StrTrantype);
        //            if (obj_ds.Tables.Count > 0)
        //            {
        //                Tot_1 = 0;
        //                Tot_2 = 0;
        //                Tot_3 = 0;
        //                Tot_4 = 0;
        //                Tot_5 = 0;
        //                Tot_6 = 0;
        //                Tot_7 = 0;
        //                obj_dttemp = obj_ds.Tables[0];
        //                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
        //                {
        //                    dr1 = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr1);
        //                    dr1[0] = obj_dttemp.Rows[i][0].ToString();
        //                    dr1[1] = obj_dttemp.Rows[i][1].ToString();
        //                    Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
        //                    dr1[2] = obj_dttemp.Rows[i][2].ToString();
        //                    Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());
        //                    dr1[3] = obj_dttemp.Rows[i][3].ToString();
        //                    Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][3].ToString());
        //                    dr1[4] = obj_dttemp.Rows[i][4].ToString();
        //                    Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());
        //                    dr1[5] = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
        //                    Tot_5 = Tot_5 + (double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString()));
        //                    dr1[6] = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
        //                    Tot_6 = Tot_6 + (double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString()));

        //                }
        //                if (obj_dttemp.Rows.Count > 0)
        //                {
        //                    dr1 = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr1);
        //                    dr1[0] = "Total";
        //                    dr1[1] = Tot_1;
        //                    dr1[2] = Tot_2;
        //                    dr1[3] = Tot_3;
        //                    dr1[4] = Tot_4;
        //                    dr1[5] = Tot_5;
        //                    dr1[6] = Tot_6;
        //                    Tot_Retention = Tot_Retention + Tot_6;
        //                    Tot_CBM = Tot_CBM + Tot_5;
        //                }
        //            }
        //            dr1 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr1);
        //            //End Region - LCL

        //            //Region - FCL
        //            DataRow dr2 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr2);
        //            dr2[0] = Trantype + "- FCL";
        //            dr2 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr2);
        //            dr2[1] = "Controlled";
        //            dr2[2] = "by US";
        //            dr2[3] = "Agent";
        //            dr2[4] = "Controlled";

        //            dr2 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr2);
        //            dr2[0] = "Agent";
        //            dr2[1] = "M3";
        //            dr2[2] = "Retention";
        //            dr2[3] = "M3";
        //            dr2[4] = "Retention";
        //            dr2[5] = "Total M3";
        //            dr2[6] = "Total Retention";

        //            obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "FCL", int_branchid, StrTrantype);
        //            if (obj_ds.Tables.Count > 0)
        //            {
        //                Tot_1 = 0;
        //                Tot_2 = 0;
        //                Tot_3 = 0;
        //                Tot_4 = 0;
        //                Tot_5 = 0;
        //                Tot_6 = 0;
        //                Tot_7 = 0;
        //                obj_dttemp = obj_ds.Tables[0];
        //                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
        //                {
        //                    dr2 = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr2);
        //                    dr2[0] = obj_dttemp.Rows[i][0].ToString();
        //                    dr2[1] = obj_dttemp.Rows[i][1].ToString();
        //                    Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
        //                    dr2[2] = obj_dttemp.Rows[i][2].ToString();
        //                    Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());
        //                    dr2[3] = obj_dttemp.Rows[i][3].ToString();
        //                    Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][3].ToString());
        //                    dr2[4] = obj_dttemp.Rows[i][4].ToString();
        //                    Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());
        //                    dr2[5] = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
        //                    Tot_5 = Tot_5 + (double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString()));
        //                    dr2[6] = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
        //                    Tot_6 = Tot_6 + (double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString()));

        //                }
        //                if (obj_dttemp.Rows.Count > 0)
        //                {
        //                    dr2 = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr2);
        //                    dr2[0] = "Total";
        //                    dr2[1] = Tot_1;
        //                    dr2[2] = Tot_2;
        //                    dr2[3] = Tot_3;
        //                    dr2[4] = Tot_4;
        //                    dr2[5] = Tot_5;
        //                    dr2[6] = Tot_6;

        //                    Tot_Retention = Tot_Retention + Tot_6;
        //                    Tot_Tues = Tot_Tues + Tot_5;
        //                }
        //            }
        //            dr2 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr2);
        //            //End Region - FCL

        //            //Region -  Summary
        //            DataRow dr3 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr3);
        //            dr3[0] = "Summary";
        //            dr3 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr3);
        //            dr3[0] = "Retention (Consol + LCL + FCL)";
        //            dr3[1] = Tot_Retention;
        //            dr3 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr3);
        //            dr3[0] = "Teus (Consol + FCL)";
        //            dr3[1] = Tot_Tues;
        //            dr3 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr3);
        //            dr3[0] = "CBM (Consol + LCL)";
        //            dr3[1] = Tot_CBM;

        //            dr3 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr3);
        //            //End Region - Summary

        //            //Region -Consol
        //            DataRow dr4 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr4);
        //            dr4[0] = Trantype + "- Consol";
        //            dr4 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr4);
        //            dr4[0] = "Agent";
        //            dr4[1] = "Teus";
        //            dr4[2] = "Retention";



        //            obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "Consol", int_branchid, StrTrantype);
        //            if (obj_ds.Tables.Count > 0)
        //            {

        //                obj_dttemp = obj_ds.Tables[1];
        //                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
        //                {
        //                    dr4 = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr4);
        //                    dr4[0] = obj_dttemp.Rows[i][0].ToString();
        //                    dr4[1] = obj_dttemp.Rows[i][1].ToString();
        //                    dr4[2] = obj_dttemp.Rows[i][2].ToString();

        //                }

        //            }
        //            dr4 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr4);
        //            //End Region -Consol

        //            //Region -LCL
        //            DataRow dr5 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr5);
        //            dr5[0] = Trantype + "- LCL";
        //            dr5 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr5);
        //            dr5[0] = "Agent";
        //            dr5[1] = "M3";
        //            dr5[2] = "Retention";



        //            obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "LCL", int_branchid, StrTrantype);
        //            if (obj_ds.Tables.Count > 0)
        //            {

        //                obj_dttemp = obj_ds.Tables[1];
        //                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
        //                {
        //                    dr5 = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr5);
        //                    dr5[0] = obj_dttemp.Rows[i][0].ToString();
        //                    dr5[1] = obj_dttemp.Rows[i][1].ToString();
        //                    dr5[2] = obj_dttemp.Rows[i][2].ToString();

        //                }

        //            }
        //            dr5 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr5);
        //            //End Region -LCL


        //            //Region -FCL
        //            DataRow dr6 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr6);
        //            dr6[0] = Trantype + "- FCL";
        //            dr6 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr6);
        //            dr6[0] = "Agent";
        //            dr6[1] = "M3";
        //            dr6[2] = "Retention";




        //            obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "FCL", int_branchid, StrTrantype);
        //            if (obj_ds.Tables.Count > 0)
        //            {

        //                obj_dttemp = obj_ds.Tables[1];
        //                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
        //                {
        //                    dr6 = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr6);
        //                    dr6[0] = obj_dttemp.Rows[i][0].ToString();
        //                    dr6[1] = obj_dttemp.Rows[i][1].ToString();
        //                    dr6[2] = obj_dttemp.Rows[i][2].ToString();


        //                }

        //            }
        //            dr6 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr6);
        //            //End Region -FCL
        //        }
        //        else if (StrTrantype == "AE" || StrTrantype == "AI")
        //        {
        //            obj_dt.Columns.Add("column1");
        //            obj_dt.Columns.Add("column2");
        //            obj_dt.Columns.Add("column3");
        //            obj_dt.Columns.Add("column4");
        //            obj_dt.Columns.Add("column5");

        //            DataRow dr = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr);
        //            dr[0] = Trantype + " - " + StrTrantype;
        //            dr = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr);
        //            dr[0] = "Agent";
        //            dr[1] = "M3";
        //            dr[2] = "Retention";
        //            dr[3] = "M3";
        //            dr[4] = "Retention";



        //            obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, StrTrantype, int_branchid, StrTrantype);
        //            if (obj_ds.Tables.Count > 0)
        //            {

        //                obj_dttemp = obj_ds.Tables[0];
        //                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
        //                {
        //                    dr = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr);
        //                    dr[0] = obj_dttemp.Rows[i][0].ToString();
        //                    dr[1] = obj_dttemp.Rows[i][1].ToString();
        //                    dr[2] = obj_dttemp.Rows[i][2].ToString();
        //                    dr[3] = obj_dttemp.Rows[i][3].ToString();
        //                    dr[4] = obj_dttemp.Rows[i][4].ToString();

        //                }

        //            }
        //            dr = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr);

        //            DataRow dr1 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr1);
        //            dr1[0] = Trantype + " - " + StrTrantype;
        //            dr1 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr1);
        //            dr1[0] = "Agent";
        //            dr1[1] = "M3";
        //            dr1[2] = "Retention";




        //            obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, StrTrantype, int_branchid, StrTrantype);
        //            if (obj_ds.Tables.Count > 0)
        //            {

        //                obj_dttemp = obj_ds.Tables[0];
        //                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
        //                {
        //                    dr1 = obj_dt.NewRow();
        //                    obj_dt.Rows.Add(dr1);
        //                    dr1[0] = obj_dttemp.Rows[i][0].ToString();
        //                    dr1[1] = obj_dttemp.Rows[i][1].ToString();
        //                    dr1[2] = obj_dttemp.Rows[i][2].ToString();


        //                }

        //            }
        //            dr1 = obj_dt.NewRow();
        //            obj_dt.Rows.Add(dr1);
        //        }
        //        Grd_Retention.Visible = true;
        //        Grd_Retention.DataSource = obj_dt;
        //        Grd_Retention.DataBind();
        //        btn_Export.Enabled = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}
        private void fn_Retention()
        {
            try
            {
                int int_branchid, int_divisionid, i, blnoagent = 0, blnous = 0, retagentid, totblus = 0, totblagent = 0, totalcbl = 0, totallbl = 0, totalfbl = 0;
                string StrTrantype, retagent;
                double Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_8, Tot_9, Tot_10, Tot_Retention, Tot_Tues, Tot_CBM, Tot_BL;
                int_branchid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
                StrTrantype = Session["StrTranType"].ToString();
                DataSet obj_ds = new DataSet();
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DateTime frm_date, to_date;
                frm_date = Convert.ToDateTime(str_fromdate);
                to_date = Convert.ToDateTime(str_todate);
                DataAccess.CostingTemp da_obj_Costing = new DataAccess.CostingTemp();
                string Trantype = "";
                if (StrTrantype == "FE")
                {
                    Trantype = "Ocean Exports";
                }
                else if (StrTrantype == "FI")
                {
                    Trantype = "Ocean Imports";
                }
                else if (StrTrantype == "AI")
                {
                    Trantype = "Air Imports";
                }
                else if (StrTrantype == "AE")
                {
                    Trantype = "Air Exports";
                }

                if (StrTrantype == "FE" || StrTrantype == "FI")
                {
                    obj_dt.Columns.Add("column1");
                    obj_dt.Columns.Add("column2");
                    obj_dt.Columns.Add("column3");
                    obj_dt.Columns.Add("column4");
                    obj_dt.Columns.Add("column5");
                    obj_dt.Columns.Add("column6");
                    obj_dt.Columns.Add("column7");
                    obj_dt.Columns.Add("column8");
                    obj_dt.Columns.Add("column9");
                    obj_dt.Columns.Add("column10");
                    obj_dt.Columns.Add("column11");
                    Tot_Retention = 0;
                    Tot_Tues = 0;
                    Tot_CBM = 0;
                    //Region -Consol
                    DataRow dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = Trantype + "- Consol";
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[1] = "";
                    dr[2] = "Controlled by US";
                    dr[3] = "";
                    dr[4] = "";
                    dr[5] = "Agent Controlled";
                    dr[6] = "";
                    dr[7] = "";
                    dr[8] = "Total";
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Agent";
                    dr[1] = "M3";
                    dr[2] = "Retention";
                    dr[3] = "No of BL";
                    dr[4] = "M3";
                    dr[5] = "Retention";
                    dr[6] = "No Of BL";
                    dr[7] = "Total M3";
                    dr[8] = "Total Retention";
                    dr[9] = "Total No of BL";
                    dr[10] = "Teus";
                    obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "Consol", int_branchid, StrTrantype);
                    if (obj_ds.Tables.Count > 0)
                    {
                        Tot_1 = 0;
                        Tot_2 = 0;
                        Tot_3 = 0;
                        Tot_4 = 0;
                        Tot_5 = 0;
                        Tot_6 = 0;
                        Tot_7 = 0;
                        totblus = 0;
                        totblagent = 0;
                        obj_dttemp = obj_ds.Tables[0];
                        for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            blnoagent = 0;
                            blnous = 0;
                            dr = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr);
                            dr[0] = obj_dttemp.Rows[i][0].ToString();
                            retagent = (obj_dttemp.Rows[i][0].ToString());
                            retagentid = customerobj.GetCustomeridwcusttype(retagent, "P");
                            blnous = misgrdobj.GetNoOfBlForRetention(frm_date, to_date, int_branchid, retagentid, "C", "N");
                            dr[1] = obj_dttemp.Rows[i][1].ToString();
                            Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
                            dr[2] = obj_dttemp.Rows[i][2].ToString();
                            Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());
                            dr[3] = blnous;
                            dr[4] = obj_dttemp.Rows[i][3].ToString();
                            Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][4].ToString());
                            dr[5] = obj_dttemp.Rows[i][4].ToString();
                            Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());
                            blnoagent = misgrdobj.GetNoOfBlForRetention(frm_date, to_date, int_branchid, retagentid, "C", "F");
                            dr[6] = blnoagent;
                            dr[7] = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
                            Tot_5 = Tot_5 + (double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString()));


                            dr[8] = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
                            dr[9] = blnous + blnoagent;
                            Tot_6 = Tot_6 + (double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString()));
                            dr[10] = obj_dttemp.Rows[i][5].ToString();
                            Tot_7 = Tot_7 + double.Parse(obj_dttemp.Rows[i][5].ToString());
                            totblus = totblus + blnous;
                            totblagent = totblagent + blnoagent;
                        }
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            dr = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr);
                            dr[0] = "Total";
                            dr[1] = Tot_1;
                            dr[2] = Tot_2;
                            dr[3] = totblus;
                            dr[4] = Tot_3;
                            dr[5] = Tot_4;
                            dr[6] = totblagent;
                            dr[7] = Tot_5;
                            dr[8] = Tot_6;
                            dr[9] = totblagent + totblus;
                            dr[10] = Tot_Tues;
                            Tot_Retention = Tot_Retention + Tot_6;
                            Tot_Tues = Tot_Tues + Tot_7;
                            Tot_CBM = Tot_CBM + Tot_5;
                            totalcbl = totblagent + totblus;
                        }
                    }
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    //End Region -Consol

                    //Region- LCL
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[0] = Trantype + "- LCL";
                    dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[1] = "";
                    dr1[2] = "Controlled by US";
                    dr1[3] = "";
                    dr1[5] = "Agent Controlled";
                    dr1[8] = "Total";
                    dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[0] = "Agent";
                    dr1[1] = "M3";
                    dr1[2] = "Retention";
                    dr1[3] = "No of BL";
                    dr1[4] = "M3";
                    dr1[5] = "Retention";
                    dr1[6] = "No Of BL";
                    dr1[7] = "Total M3";
                    dr1[8] = "Total Retention";
                    dr1[9] = "Total No of BL";
                    dr1[10] = "";

                    obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "LCL", int_branchid, StrTrantype);
                    if (obj_ds.Tables.Count > 0)
                    {
                        Tot_1 = 0;
                        Tot_2 = 0;
                        Tot_3 = 0;
                        Tot_4 = 0;
                        Tot_5 = 0;
                        Tot_6 = 0;
                        Tot_7 = 0;
                        totblus = 0;
                        totblagent = 0;
                        obj_dttemp = obj_ds.Tables[0];
                        for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            blnous = 0;
                            blnoagent = 0;
                            dr1 = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr1);
                            dr1[0] = obj_dttemp.Rows[i][0].ToString();
                            retagent = obj_dttemp.Rows[i][0].ToString();
                            retagentid = customerobj.GetCustomeridwcusttype(retagent, "P");
                            dr1[1] = obj_dttemp.Rows[i][1].ToString();
                            Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
                            dr1[2] = obj_dttemp.Rows[i][2].ToString();
                            Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());

                            blnous = misgrdobj.GetNoOfBlForRetention(frm_date, to_date, int_branchid, retagentid, "L", "N");
                            dr1[3] = blnous;
                            dr1[4] = obj_dttemp.Rows[i][3].ToString();
                            Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][3].ToString());
                            dr1[5] = obj_dttemp.Rows[i][4].ToString();
                            Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());

                            blnoagent = misgrdobj.GetNoOfBlForRetention(frm_date, to_date, int_branchid, retagentid, "L", "F");
                            dr1[6] = blnoagent;
                            dr1[7] = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
                            Tot_5 = Tot_5 + (double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString()));
                            dr1[8] = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
                            Tot_6 = Tot_6 + (double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString()));
                            dr1[9] = blnous + blnoagent;

                            totblus = totblus + blnous;
                            totblagent = totblagent + blnoagent;
                        }
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            dr1 = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr1);
                            dr1[0] = "Total";
                            dr1[1] = Tot_1;
                            dr1[2] = Tot_2;
                            dr1[3] = totblus;
                            dr1[4] = Tot_3;
                            dr1[5] = Tot_4;
                            dr1[6] = totblagent;
                            dr1[7] = Tot_5;
                            dr1[8] = Tot_6;
                            dr1[9] = totblagent + totblus;
                            Tot_Retention = Tot_Retention + Tot_6;
                            Tot_CBM = Tot_CBM + Tot_5;
                            totallbl = totblagent + totblus;
                        }
                    }
                    dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    //End Region - LCL

                    //Region - FCL
                    DataRow dr2 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr2);
                    dr2[0] = Trantype + "- FCL";
                    dr2 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr2);
                    dr2[2] = "Controlled by US";
                    dr2[1] = "";
                    dr2[5] = "Agent Controlled";
                    dr2[8] = "Total";

                    dr2 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr2);
                    dr2[0] = "Agent";
                    dr2[1] = "Teus";
                    dr2[2] = "Retention";
                    dr2[3] = "No of BL";
                    dr2[4] = "Teus";
                    dr2[5] = "Retention";
                    dr2[6] = "No of BL";
                    dr2[7] = "Total Teus";
                    dr2[8] = "Total Retention";
                    dr2[9] = "Total No of BL";

                    obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "FCL", int_branchid, StrTrantype);
                    if (obj_ds.Tables.Count > 0)
                    {
                        Tot_1 = 0;
                        Tot_2 = 0;
                        Tot_3 = 0;
                        Tot_4 = 0;
                        Tot_5 = 0;
                        Tot_6 = 0;
                        Tot_7 = 0;
                        totblus = 0;
                        totblagent = 0;
                        obj_dttemp = obj_ds.Tables[0];
                        for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            blnous = 0;
                            blnoagent = 0;
                            dr2 = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr2);
                            dr2[0] = obj_dttemp.Rows[i][0].ToString();
                            retagent = obj_dttemp.Rows[i][0].ToString();
                            retagentid = customerobj.GetCustomeridwcusttype(retagent, "P");
                            blnous = misgrdobj.GetNoOfBlForRetention(frm_date, to_date, int_branchid, retagentid, "F", "N");

                            dr2[1] = obj_dttemp.Rows[i][1].ToString();
                            Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
                            dr2[2] = obj_dttemp.Rows[i][2].ToString();
                            Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());
                            dr2[3] = blnous;
                            dr2[4] = obj_dttemp.Rows[i][3].ToString();
                            Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][3].ToString());
                            dr2[5] = obj_dttemp.Rows[i][4].ToString();
                            Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());
                            blnoagent = misgrdobj.GetNoOfBlForRetention(frm_date, to_date, int_branchid, retagentid, "F", "F");
                            dr2[6] = blnoagent;
                            dr2[7] = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
                            Tot_5 = Tot_5 + (double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString()));
                            dr2[8] = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
                            Tot_6 = Tot_6 + (double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString()));
                            dr2[9] = blnous + blnoagent;
                            totblus = totblus + blnous;
                            totblagent = totblagent + blnoagent;

                        }
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            dr2 = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr2);
                            dr2[0] = "Total";
                            dr2[1] = Tot_1;
                            dr2[2] = Tot_2;
                            dr2[3] = totblus;
                            dr2[4] = Tot_3;
                            dr2[5] = Tot_4;
                            dr2[6] = totblagent;
                            dr2[7] = Tot_5;
                            dr2[8] = Tot_6;
                            dr2[9] = totblus + totblagent;
                            dr2[10] = "";

                            Tot_Retention = Tot_Retention + Tot_6;
                            Tot_Tues = Tot_Tues + Tot_5;
                            totalfbl = totblus + totblagent;
                        }
                    }
                    dr2 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr2);
                    //End Region - FCL

                    //Region -  Summary
                    DataRow dr3 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr3);
                    dr3[0] = "Summary";

                    dr3 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr3);
                    dr3[0] = "Retention (Consol + LCL + FCL)";
                    dr3[1] = Tot_Retention;

                    dr3 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr3);
                    dr3[0] = "Teus (Consol + FCL)";
                    dr3[1] = Tot_Tues;

                    dr3 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr3);
                    dr3[0] = "CBM (Consol + LCL)";
                    dr3[1] = Tot_CBM;

                    dr3 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr3);
                    dr3[0] = "No of BL (Consol + LCL + FCL)";
                    dr3[1] = totalcbl + totallbl + totalfbl;

                    dr3 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr3);
                    //End Region - Summary

                    //Region -Consol
                    DataRow dr4 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr4);
                    dr4[0] = Trantype + "- Consol";
                    dr4 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr4);
                    dr4[0] = "Agent";
                    dr4[1] = "Teus";
                    dr4[2] = "Retention";



                    obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "Consol", int_branchid, StrTrantype);
                    if (obj_ds.Tables.Count > 0)
                    {

                        obj_dttemp = obj_ds.Tables[1];
                        for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            dr4 = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr4);
                            dr4[0] = obj_dttemp.Rows[i][0].ToString();
                            dr4[1] = obj_dttemp.Rows[i][1].ToString();
                            dr4[2] = obj_dttemp.Rows[i][2].ToString();

                        }

                    }
                    dr4 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr4);
                    //End Region -Consol

                    //Region -LCL
                    DataRow dr5 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr5);
                    dr5[0] = Trantype + "- LCL";
                    dr5 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr5);
                    dr5[0] = "Agent";
                    dr5[1] = "M3";
                    dr5[2] = "Retention";



                    obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "LCL", int_branchid, StrTrantype);
                    if (obj_ds.Tables.Count > 0)
                    {

                        obj_dttemp = obj_ds.Tables[1];
                        for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            dr5 = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr5);
                            dr5[0] = obj_dttemp.Rows[i][0].ToString();
                            dr5[1] = obj_dttemp.Rows[i][1].ToString();
                            dr5[2] = obj_dttemp.Rows[i][2].ToString();

                        }

                    }
                    dr5 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr5);
                    //End Region -LCL


                    //Region -FCL
                    DataRow dr6 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr6);
                    dr6[0] = Trantype + "- FCL";
                    dr6 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr6);
                    dr6[0] = "Agent";
                    dr6[1] = "Tues";
                    dr6[2] = "Retention";




                    obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "FCL", int_branchid, StrTrantype);
                    if (obj_ds.Tables.Count > 0)
                    {

                        obj_dttemp = obj_ds.Tables[1];
                        for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            dr6 = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr6);
                            dr6[0] = obj_dttemp.Rows[i][0].ToString();
                            dr6[1] = obj_dttemp.Rows[i][1].ToString();
                            dr6[2] = obj_dttemp.Rows[i][2].ToString();


                        }

                    }
                    dr6 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr6);
                    //End Region -FCL
                }
                else if (StrTrantype == "AE" || StrTrantype == "AI")
                {
                    obj_dt.Columns.Add("column1");
                    obj_dt.Columns.Add("column2");
                    obj_dt.Columns.Add("column3");
                    obj_dt.Columns.Add("column4");
                    obj_dt.Columns.Add("column5");

                    DataRow dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = Trantype + " - " + StrTrantype;
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Agent";
                    dr[1] = "M3";
                    dr[2] = "Retention";
                    dr[3] = "M3";
                    dr[4] = "Retention";



                    obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, StrTrantype, int_branchid, StrTrantype);
                    if (obj_ds.Tables.Count > 0)
                    {

                        obj_dttemp = obj_ds.Tables[0];
                        for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            dr = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr);
                            dr[0] = obj_dttemp.Rows[i][0].ToString();
                            dr[1] = obj_dttemp.Rows[i][1].ToString();
                            dr[2] = obj_dttemp.Rows[i][2].ToString();
                            dr[3] = obj_dttemp.Rows[i][3].ToString();
                            dr[4] = obj_dttemp.Rows[i][4].ToString();

                        }

                    }
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);

                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[0] = Trantype + " - " + StrTrantype;
                    dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[0] = "Agent";
                    dr1[1] = "M3";
                    dr1[2] = "Retention";




                    obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, StrTrantype, int_branchid, StrTrantype);
                    if (obj_ds.Tables.Count > 0)
                    {

                        obj_dttemp = obj_ds.Tables[0];
                        for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            dr1 = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr1);
                            dr1[0] = obj_dttemp.Rows[i][0].ToString();
                            dr1[1] = obj_dttemp.Rows[i][1].ToString();
                            dr1[2] = obj_dttemp.Rows[i][2].ToString();


                        }

                    }
                    dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                }
                Grd_Retention.Visible = true;
                Grd_Retention.DataSource = obj_dt;
                Grd_Retention.DataBind();
                btn_Export.Enabled = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void ddl_Report_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Filter.Text = "";
            HttpContext.Current.Session["DataTable"] = null;
            EnableFilter();
            lbl_MISA.Visible = false;
            lbl_MISB.Visible = false;
            lbl_MISC.Visible = false;
            lbl_MISD.Visible = false;
            lbl_retention.Visible = false;
            ddl_Report.Focus();

            ddl_graph1.SelectedIndex = 0;
            ddl_graph1.Enabled = false;
            chartclear();
        }

        private void EnableFilter()
        {
            GridClear();
            btn_Export.Enabled = false;
            //fn_SetGridVisible();
            if (ddl_Report.Text == "Shipperwise")
            {
                //lbl_Filter.Text = "Shipper";
                txt_Filter.Visible = true;
                lbl_Filter.Visible = true;
                // txt_Filter.Enabled = true;
                //lbl_Filter.Enabled = true;
                txt_Filter.Text = "";
                hid_text.Value = "Customer";
                //txt_Filter.Attributes.Add("placeholder", "Shipper");
                lbl_Filter.Text = "Shipper";
                txt_Filter.ToolTip = "Shipper";
            }
            else if (ddl_Report.Text == "Consigneewise")
            {
                //lbl_Filter.Text = "Consignee";
                txt_Filter.Visible = true;
                lbl_Filter.Visible = true;
                // txt_Filter.Enabled = true;
                //lbl_Filter.Enabled = true;
                hid_text.Value = "Customer";
                //txt_Filter.Attributes.Add("placeholder", "Consignee");
                lbl_Filter.Text = "Consignee";
                txt_Filter.ToolTip = "Consignee";

            }
            else if (ddl_Report.Text == "Agentwise")
            {
                //lbl_Filter.Text = "Agent";
                txt_Filter.Visible = true;
                lbl_Filter.Visible = true;
                //  txt_Filter.Enabled = true;
                //lbl_Filter.Enabled = true;
                txt_Filter.Text = "";
                hid_text.Value = "Agent";
                //txt_Filter.Attributes.Add("placeholder", "Agent");
                lbl_Filter.Text = "Agent";
                txt_Filter.ToolTip = "Agent";
            }
            else if (ddl_Report.Text == "Sales Person")
            {
                //lbl_Filter.Text = "Name";
                txt_Filter.Visible = true;
                lbl_Filter.Visible = true;
                //   txt_Filter.Enabled = true;
                //lbl_Filter.Enabled = true;
                txt_Filter.Text = "";
                hid_text.Value = "Name";
                //txt_Filter.Attributes.Add("placeholder", "Name");
                lbl_Filter.Text = "Name";
                txt_Filter.ToolTip = "Name";
            }
            else if (ddl_Report.Text == "Port Of Loading")
            {
                //lbl_Filter.Text = "Port";
                txt_Filter.Visible = true;
                lbl_Filter.Visible = true;
                //    txt_Filter.Enabled = true;
                //lbl_Filter.Enabled = true;
                txt_Filter.Text = "";
                hid_text.Value = "Port";
                //txt_Filter.Attributes.Add("placeholder", "Port");
                lbl_Filter.Text = "Port";
                txt_Filter.ToolTip = "Port";
            }
            else if (ddl_Report.Text == "Port Of Discharge")
            {
                //lbl_Filter.Text = "Port";
                txt_Filter.Visible = true;
                lbl_Filter.Visible = true;
                // txt_Filter.Enabled = true;
                //lbl_Filter.Enabled = true;
                txt_Filter.Text = "";
                hid_text.Value = "Port";
                //txt_Filter.Attributes.Add("placeholder", "Port");
                lbl_Filter.Text = "Port";
                txt_Filter.ToolTip = "Port";
            }
            else if (ddl_Report.Text == "LinerWise")
            {
                //lbl_Filter.Text = "Port";
                txt_Filter.Visible = true;
                lbl_Filter.Visible = true;
                //   txt_Filter.Enabled = true;
                //lbl_Filter.Enabled = true;
                hidId.Value = "";
                txt_Filter.Text = "";
                hid_text.Value = "Liner";
                //txt_Filter.Attributes.Add("placeholder", "Liner");
                lbl_Filter.Text = "Liner";
                txt_Filter.ToolTip = "Liner";
            }
            else if ((ddl_Report.Text == "MIS"))
            {
                btn_Export.Enabled = true;
            }

            else
            {
                //lbl_Filter.Visible = false;
                //txt_Filter.Visible = false;
                //     txt_Filter.Enabled = false;
                txt_Filter.Visible = false;
                lbl_Filter.Visible = false;
                //lbl_Filter.Enabled = false;
                txt_Filter.Text = "";
                hid_text.Value = "";
                txt_Filter.Attributes.Add("placeholder", "");
                txt_Filter.ToolTip = "";
                btn_Export.Enabled = true;
            }
        }

        private void fn_SetGridVisible()
        {
            grd_Agent.Visible = false;
            grd_Consignee.Visible = false;
            grd_Shipper.Visible = false;
            grd_lossjob.Visible = false;
            grd_JobwiseCosting.Visible = false;
            //grd_nomination.Visible = false;
            grd_POD.Visible = false;
            grd_POL.Visible = false;
            grd_Shipment.Visible = false;
            grd_nomvafree.Visible = false;
            grd_operProfit.Visible = false;
            grd_salesperson.Visible = false;
            Grd_freeVsnomi.Visible = false;
            Grd_nomination.Visible = false;
            grd_op.Visible = false;
            //grd_details.Visible = false;
            Grd_shiperconsignee.Visible = false;
            grd_YearMIS.Visible = false;
            Grd_trendcustomer.Visible = false;
            Grd_trendcustomervolume.Visible = false;
            Pln_MIS.Visible = false;
            Grd_Retention.Visible = false;
            //Chart1.Visible = false;
        }

        protected void btn_Print_Click(object sender, EventArgs e)
        {
            if (ddl_Report.Text == "REPORT")
            {
                ScriptManager.RegisterStartupScript(btn_Print, typeof(LinkButton), "Revenue", "alertify.alert('Select any one Report');", true);
                return;
            }
            try
            {

                DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                div_id = int.Parse(Session["LoginDivisionId"].ToString());
                branch_id = Convert.ToInt32(Session["LoginBranchid"].ToString());
                str_TranType = Session["StrTranType"].ToString();
                empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            }
            catch
            {
                return;
            }
            if (str_TranType == "")
            {
                str_TranType = "AC";
            }
            if (hidId.Value == "")
            {
                hidId.Value = "0";
            }
            string str_sp = "", bus = "", str_sp1 = "";
            string str_sf = "", str_sf1 = "";
            string str_RptName = "", str_RptName1 = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Session["str_sfs1"] = "";
            Session["str_sp1"] = "";
            //str_sp = "fromdate=Shipment Details from  " + txt_From.Text + "  to  " + txt_To.Text;
            DateTime dtfrom = Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString()));
            DateTime dtto = Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString()));
            int int_tmpid = 0;
            DataAccess.Masters.MasterPort da_obj_port = new DataAccess.Masters.MasterPort();
            if (str_TranType == "FE")
            {
                str_sp = "Title=Ocean Exports Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
            }
            else if (str_TranType == "FI")
            {
                str_sp = "Title=Ocean Imports Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
            }
            else if (str_TranType == "AE")
            {
                str_sp = "Title=Air Exports Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
            }
            else if (str_TranType == "AI")
            {
                str_sp = "Title=Air Imports Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
            }

            if (str_TranType == "FE" || str_TranType == "FI" || str_TranType == "AE" || str_TranType == "AI")
            {
                if (ddl_Report.Text == "LinerWise")
                {
                    str_RptName = "ShipmentDetailsTempLiner.rpt";
                    if (txt_Filter.Text != "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and  {mastercustomergroupliner.linerid}=" + hidId.Value + " and  {masterport_line.countryid}=" + 102;
                    }
                    else
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and  {masterport_line.countryid}=" + 102;
                    }
                    //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.trantype}=" + str_TranType + "  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    // Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;

                }
                else

                    if (ddl_Report.Text == "Shipment Details")
                    {
                        str_RptName = "ShipmentDetailsTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.trantype}=" + str_TranType + "  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        // Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;

                    }
                    else if (ddl_Report.Text == "ForwarderWise - Imports")
                    {
                        str_RptName = "AllforwarderTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.trantype}=" + str_TranType + "  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        // Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "DO Register" && str_TranType == "FI")
                    {
                        str_RptName = "AllforwarderTemp.rpt";
                        Session["str_sfs"] = "{FIBLDetails.bid}=" + int.Parse(Session["LoginBranchid"].ToString() + " and {FIBLDetails.doissuedon}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {FIBLDetails.doissuedon}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')");
                        str_sf = "{FIBLDetails.bid}=" + int.Parse(Session["LoginBranchid"].ToString() + " and {FIBLDetails.doissuedon}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {FIBLDetails.doissuedon}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')");
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        // Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Nomination Vs Freehand")
                    {
                        //RetentionperUnit.Flag = 0;
                        //RetentionperUnit.Strtrantype = "AC";
                        //RetentionperUnit.dtfrom = dtfrom.Value;
                        //RetentionperUnit.dtto = dtto.Value;
                        //RetentionperUnit.Show();
                        //RetentionperUnit.MdiParent = MDIParentMIS;
                        //RetentionperUnit.Left = 2;
                        //RetentionperUnit.Top = 85;
                        Session["From"] = txt_From.Text;
                        Session["To"] = txt_To.Text;
                        this.popuprate.Show();
                    }
                    else if (ddl_Report.Text == "Port Of Loading")
                    {
                        //CostingTempCorp()
                        str_RptName = "MISPoLWise.rpt";
                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            //str_sf = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        else
                        {
                            int intport = 0;
                            intport = da_obj_port.GetNPortid(txt_Filter.Text);
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.pol}=" + intport;
                            //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.pol}=" + intport + " and {CostingDetails.division}=" + int.Parse(Session["LoginDivisionId"].ToString());
                        }
                        str_sp = "Title=Shipment Details - Port Of Loading for the Period from " + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Port Of Discharge")
                    {
                        str_RptName = "MISPoDWise.rpt";
                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        else
                        {
                            int intport = 0;
                            intport = da_obj_port.GetNPortid(txt_Filter.Text);
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.pod}=" + intport;
                            //Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString() + " and {CostingDetails.pod}=" + intport);
                        }
                        str_sp = "Title=Shipment Details - Port Of Discharging for the Period from " + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Shipperwise")
                    {

                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            str_RptName = "ShipperwiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.division}=" + int.Parse(Session["LoginDivisionId"].ToString());
                            str_sp = "Title=Shipper Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        else
                        {
                            custid = Convert.ToInt32(hidId.Value);
                            str_RptName = "ShipperwiseTemp.rpt";
                            //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.shipper}=" + int_tmpid + "  and {CostingDetails.division}=" + int.Parse(Session["LoginDivisionId"].ToString());
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + hidId.Value;
                            str_sp = "Title=" + txt_Filter.Text + " - Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Consigneewise")
                    {
                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            str_RptName = "ConsigneewiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            str_sp = "Title=Consignee Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        else
                        {
                            custid = Convert.ToInt32(hidId.Value);
                            str_RptName = "ConsigneewiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                            str_sp = "Title=" + txt_Filter.Text + " - Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Agentwise")
                    {
                        //CostingTempCorp()
                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            str_RptName = "AgentwiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            str_sp = "Title=Agent Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        else
                        {
                            custid = Convert.ToInt32(hidId.Value);
                            str_RptName = "AgentwiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                            str_sp = "Title=" + txt_Filter.Text + " - Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Sales Person")
                    {
                        //CostingTempCorp()
                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            str_RptName = "SalesPersonWiseTemp.rpt";//
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.business}='" + "O" + "' and {CostingDetails.salesperson}<>0" + " and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            str_sp = "Title=SalesPesons Wise Revenue from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        else
                        {
                            str_RptName = "SalesPersonWiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.business}='" + "O" + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.salesperson}=" + int.Parse(Session["LoginEmpId"].ToString());

                            //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.business}=\" O \" and {CostingDetails.branchid}=" + Session["LoginBranchid"].ToString() + "and {CostingDetails.salesperson}=\"" + int.Parse(Session["LoginEmpId"].ToString()) + "\"";
                            str_sp = "Title=\"" + txt_Filter.Text + "\" Revenue from  " + txt_From.Text + " To " + txt_To.Text;
                        }
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        //Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Operating Profit")
                    {
                        str_RptName = "OperatingProfit.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')and {CostingDetails.trantype}='" + str_TranType + "'  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.trantype}<>\"AD\" and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.division}=" + int.Parse(Session["LoginDivisionId"].ToString());
                        str_sp = "Header=Operating Profit for the period of " + txt_From.Text + " to " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Jobwise Costing")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Please use Shipment Details/Operating Profit for Weekly/Monthly MIS. Do not submit Jobwise Costing as MIS report. For further classification please contact to Mr.Padmanabhan');", true);
                        str_RptName = "JobWiseCosting.rpt";
                        Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + str_TranType + "' and {JobDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        // str_sf = "{JobDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {JobDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {JobDetails.trantype}='" + str_TranType + "' and {JobDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sp = "Header=JobWise Costing Details from  " + txt_From.Text + " to " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Loss Jobs")
                    {
                        str_RptName = "JobWiseCosting.rpt";
                        Session["str_sfs"] = "{JobDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {JobDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ")and {JobDetails.trantype}='" + str_TranType + "' and {JobDetails.retention}<0 and {JobDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sp = "Header=Loss Jobwise Costing Details from" + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Nomination")
                    {
                        if (str_TranType == "FE" || str_TranType == "AE")
                        {
                            bus = "A";
                        }
                        else if (str_TranType == "FI" || str_TranType == "AI")
                        {
                            bus = "O";
                        }
                        str_RptName = "ShipmentDetailsTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.nomination}='N'";
                        //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.nomination}=\"N\" and {CostingDetails.division}=" + int.Parse(Session["LoginDivisionId"].ToString());
                        str_sp = "Title=Nomination Shipment Details from " + txt_From.Text + " To " + txt_To.Text;

                        str_RptName1 = "NominationCustomers.rpt";
                        Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + "";
                        str_sp1 = "Title=Free-hand Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');"; // window.open('../Tools/ReportView.aspx?SFormula=" + str_sf2 + "&Parameter=" + str_sp2 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                        Session["str_sp1"] = str_sp1;
                    }
                    else if (ddl_Report.Text == "FreeHand")
                    {
                        if (str_TranType == "FE" || str_TranType == "AE")
                        {
                            bus = "A";
                        }
                        else if (str_TranType == "FI" || str_TranType == "AI")
                        {
                            bus = "O";
                        }
                        str_RptName = "ShipmentDetailsTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.nomination}='F'";
                        //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.nomination}=\"F\" and {CostingDetails.division}=" + int.Parse(Session["LoginDivisionId"].ToString());
                        str_sp = "Title=Free-hand Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;

                    }

            }
            if (str_TranType == "AC")
            {
                if (ddl_Report.Text == "LinerWise")
                {
                    str_RptName = "ShipmentDetailsTempLiner.rpt";
                    if (txt_Filter.Text != "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and  {mastercustomergroupliner.linerid}=" + hidId.Value + " and  {masterport_line.countryid}=" + 102;
                    }
                    else
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and  {masterport_line.countryid}=" + 102;
                    }
                    str_sp = "Title=" + txt_Filter.Text + " Liner Details from " + txt_From.Text + " To " + txt_To.Text;
                    //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.trantype}=" + str_TranType + "  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    // Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;

                }
                else
                    if (ddl_Report.Text == "Shipment Details")
                    {
                        str_RptName = "ShipmentDetailsTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sp = "Title=Shipment Details from" + txt_From.Text + " To " + txt_To.Text;
                        Session["str_sp"] = str_sp;

                        str_RptName1 = "ShipmentDetailsTempJobwise.rpt";
                        Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.trantype}<>'" + "AD" + "'";
                        str_sp1 = "Title=Shipment Details from" + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else if (ddl_Report.Text == "Nomination Vs Freehand")
                    {

                    }
                    else if (ddl_Report.Text == "Loss Jobs")
                    {
                        str_RptName = "JobWiseCosting.rpt";
                        Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.retention}<0 and {JobDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sp = "Header=Loss Jobwise Costing Details from" + txt_From.Text + " To " + txt_To.Text;
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    }
                    else if (ddl_Report.Text == "Port Of Loading")
                    {
                        str_RptName = "MISPoLWise.rpt";
                        if (txt_Filter.Text == "")
                        {
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        else
                        {
                            int intport = 0;
                            intport = da_obj_port.GetNPortid(txt_Filter.Text);
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.pol}=" + intport;
                        }
                        str_sp = "Title=Shipment Details - Port Of Loading for the Period from " + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        Session["str_sp"] = str_sp;
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    }
                    else if (ddl_Report.Text == "Port Of Discharge")
                    {
                        str_RptName = "MISPoDWise.rpt";
                        if (txt_Filter.Text == "")
                        {
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        else
                        {
                            int intport = 0;
                            intport = da_obj_port.GetNPortid(txt_Filter.Text);
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.pol}=" + intport;
                        }
                        str_sp = "Title=Shipment Details - Port Of Discharging for the Period from " + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        Session["str_sp"] = str_sp;
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    }
                    else if (ddl_Report.Text == "Shipperwise")
                    {
                        str_RptName = "ShipperwiseTemp.rpt";
                        if (txt_Filter.Text == "")
                        {
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            str_sp = "Title=Shipper Wise Shipment Details from" + txt_From.Text + " To " + txt_To.Text;
                        }
                        else
                        {
                            custid = Convert.ToInt32(hidId.Value);
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                            str_sp = "Title=" + txt_Filter.Text + " - Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Consigneewise")
                    {
                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            str_RptName = "ConsigneewiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            str_sp = "Title=Consignee Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        else
                        {
                            custid = Convert.ToInt32(hidId.Value);
                            str_RptName = "ConsigneewiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                            str_sp = "Title=" + txt_Filter.Text + " - Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Agentwise")
                    {
                        str_RptName = "AgentwiseTemp.rpt";
                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            str_sp = "Title=Agent Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        else
                        {
                            custid = Convert.ToInt32(hidId.Value);
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                            str_sp = "Title=" + txt_Filter.Text + " - Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Operating Profit")
                    {
                        str_RptName = "OperatingProfit.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + "and {CostingDetails.trantype}<>'AD'";
                        str_sp = "Header=Operating Profit Details from" + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Jobwise Costing")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Please use Shipment Details/Operating Profit for Weekly/Monthly MIS. Do not submit Jobwise Costing as MIS report. For further classification please contact to Mr.Padmanabhan');", true);
                        str_RptName = "JobWiseCosting.rpt";
                        Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {JobDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sp = "Header=JobWise Costing Details from  " + txt_From.Text + " to " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Sales Person")
                    {
                        if (string.IsNullOrEmpty(txt_Filter.Text))
                        {
                            str_RptName = "SalesPersonWiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.business}='" + "O" + "' and {CostingDetails.salesperson}<>0" + " and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                            str_sp = "Title=SalesPesons Wise Revenue from " + txt_From.Text + " To " + txt_To.Text;
                        }
                        else
                        {
                            str_RptName = "SalesPersonWiseTemp.rpt";
                            Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.salesperson}=" + int.Parse(Session["LoginEmpId"].ToString());

                            //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.business}=\" O \" and {CostingDetails.branchid}=" + Session["LoginBranchid"].ToString() + "and {CostingDetails.salesperson}=\"" + int.Parse(Session["LoginEmpId"].ToString()) + "\"";
                            str_sp = "Title=\"" + txt_Filter.Text + "\" Revenue from  " + txt_From.Text + " To " + txt_To.Text;
                        }
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        //Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Nomination")
                    {
                        str_RptName = "ShipmentDetailsTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.nomination}='N'";
                        str_sp = "Title=Nomination Shipment Details from" + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "FreeHand")
                    {
                        str_RptName = "ShipmentDetailsTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.nomination}='F'";
                        str_sp = "Title=Free-Hand Shipment Details from" + txt_From.Text + " To " + txt_To.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                    }
                    else if (ddl_Report.Text == "Year M I S")
                    {
                        int a = dtfrom.Year;
                        Misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                        Misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                        Misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                        Misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                        Misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                        Misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                        str_RptName = "year2date.rpt";
                        str_sf = "{TempY2D.empid}=" + int.Parse(Session["LoginEmpId"].ToString()) + " and {TempY2D.bid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sp = "mon=" + dtfrom.Month + " ~cid= " + "" + "~year=" + dtfrom.Year;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sp"] = str_sp;
                        Session["str_sfs"] = str_sf;
                    }

            }
            if (str_TranType == "BT")
            {
                if (ddl_Report.Text == "Operating Profit")
                {
                    str_RptName = "OperatingProfit.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_sp = "Header=Operating Profit Details from" + txt_From.Text + " To " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (ddl_Report.Text == "Jobwise Costing")
                {
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + str_TranType + "' and {JobDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_sp = "Header=Jobwise Costing Details from" + txt_From.Text + " To " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (ddl_Report.Text == "Loss Jobs")
                {
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + str_TranType + "' and {JobDetails.retention}<0  and {JobDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_sp = "Header=Jobwise Costing Details from" + txt_From.Text + " To " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sp"] = str_sp;
                }

            }

            if (str_TranType == "CH")
            {
                if (ddl_Report.Text == "LinerWise")
                {
                    str_RptName = "ShipmentDetailsTempLiner.rpt";
                    if (txt_Filter.Text != "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and  {mastercustomergroupliner.linerid}=" + hidId.Value + " and  {masterport_line.countryid}=" + 102;
                    }
                    else
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and  {masterport_line.countryid}=" + 102;
                    }
                    str_sp = "Title=Custom House Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    //str_sf = "{CostingDetails.closeddate}>=date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") and {CostingDetails.closeddate}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ") and {CostingDetails.trantype}=" + str_TranType + "  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    // Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;

                }
                else if (ddl_Report.Text == "Shipment Details")
                {
                    str_RptName = "CHShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_sp = "Title=Custom House Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (ddl_Report.Text == "Operating Profit")
                {
                    str_RptName = "OperatingProfit.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_sp = "Header=Operating Profit Details from" + txt_From.Text + " To " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (ddl_Report.Text == "Jobwise Costing")
                {
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + str_TranType + "' and {JobDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                    str_sp = "Header=Jobwise Costing Details from" + txt_From.Text + " To " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sp"] = str_sp;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Please use Shipment Details/Operating Profit for Weekly/Monthly MIS. Do not submit Jobwise Costing as MIS report. For further classification please contact to Mr.Padmanabhan');", true);
                }
                else if (ddl_Report.Text == "Shipperwise")
                {
                    str_RptName = "CHShipperwiseTemp.rpt";
                    if (txt_Filter.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sp = "Title=Custom House Shipper Wise Shipment Details from" + txt_From.Text + " To " + txt_To.Text;
                    }
                    else
                    {
                        custid = Convert.ToInt32(hidId.Value);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                        str_sp = "Title=" + txt_Filter.Text + " - Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }
                    Session["str_sp"] = str_sp;
                }
                else if (ddl_Report.Text == "Consigneewise")
                {
                    str_RptName = "CHConsigneewiseTemp.rpt";
                    if (txt_Filter.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        str_sp = "Title=Custom House Consignee Wise Shipment Details from" + txt_From.Text + " To " + txt_To.Text;
                    }
                    else
                    {
                        custid = Convert.ToInt32(hidId.Value);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                        str_sp = "Title=" + txt_Filter.Text + " - Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }
                    Session["str_sp"] = str_sp;
                }

            }

            if (ddl_Report.Text == "Shipperwise" || ddl_Report.Text == "Consigneewise" || ddl_Report.Text == "Agentwise" || ddl_Report.Text == "Sales Person")
            {
                if (ddl_Report.Text == "Shipperwise")
                {
                    str_RptName1 = "Shipperwisesummary.rpt";
                    if (txt_Filter.Text == "")
                    {
                        if (str_TranType != "AC")
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());

                        }
                        else
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        str_sp1 = "Title=Shipper Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }
                    else
                    {
                        custid = Convert.ToInt32(hidId.Value);
                        if (str_TranType != "AC")
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;

                        }
                        else
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                        }
                        str_sp1 = "Title=" + txt_Filter.Text + " Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }

                }
                else if (ddl_Report.Text == "Consigneewise")
                {
                    str_RptName1 = "Consigneewisesummary.rpt";
                    if (txt_Filter.Text == "")
                    {
                        if (str_TranType != "AC")
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        else
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        str_sp1 = "Title=Shipper Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }
                    else
                    {
                        custid = Convert.ToInt32(hidId.Value);
                        if (str_TranType != "AC")
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;

                        }
                        else
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                        }
                        str_sp1 = "Title=" + txt_Filter.Text + " Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }

                }
                else if (ddl_Report.Text == "Agentwise")
                {
                    str_RptName1 = "Agentwisesummary.rpt";
                    if (txt_Filter.Text == "")
                    {
                        if (str_TranType != "AC")
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        else
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        str_sp1 = "Title=Agent Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }
                    else
                    {
                        custid = Convert.ToInt32(hidId.Value);
                        if (str_TranType != "AC")
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;

                        }
                        else
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.shipper}=" + custid;
                        }
                        str_sp1 = "Title=" + txt_Filter.Text + " Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Sales Person")
                {
                    str_RptName1 = "SalesPersonWisesummary.rpt";
                    if (txt_Filter.Text == "")
                    {
                        if (str_TranType != "AC")
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + str_TranType + "' and {CostingDetails.business}='" + "O" + "' and {CostingDetails.salesperson}<>0" + " and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        else
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.business}='" + "O" + "' and {CostingDetails.salesperson}<>0" + " and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString());
                        }
                        str_sp1 = "Title=SalesPerson Wise Shipment Details from " + txt_From.Text + " To " + txt_To.Text;
                    }
                    else
                    {
                        if (str_TranType != "AC")
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.salesperson}=" + Convert.ToInt32(Session["LoginEmpId"].ToString()) + " and {CostingDetails.trantype} ='" + str_TranType + "'";

                        }
                        else
                        {
                            Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.branchid}=" + int.Parse(Session["LoginBranchid"].ToString()) + " and {CostingDetails.salesperson}=" + Convert.ToInt32(Session["LoginEmpId"].ToString());
                        }
                        str_sp1 = "Title=" + txt_Filter.Text + " Revenue from " + txt_From.Text + " To " + txt_To.Text;
                    }

                }
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_Print, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sp1"] = str_sp1;
            }

            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 105, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "FI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 106, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 107, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 108, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "CH":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 109, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AC":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 262, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
            }
            txt_Filter.Text = "";
            btn_Print.Focus();

        }

        protected void grd_JobwiseCosting_RowDataBound(object sender, GridViewRowEventArgs e)
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


                if (e.Row.Cells[2].Text == "")
                {
                    //LinkButton Lnk = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Lnk_job");
                    //Lnk.Visible = false;
                    e.Row.ForeColor = System.Drawing.Color.Brown;

                } if (e.Row.Cells[2].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_JobwiseCosting, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }

        }

        protected void grd_Shipment_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[1].Text == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                } if (e.Row.Cells[1].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Shipment, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void grd_POL_RowDataBound(object sender, GridViewRowEventArgs e)
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


                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_POL, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void grd_operProfit_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text != "Total")
                {
                    for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                    {
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_operProfit, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }

                    for (int h = 1; h < e.Row.Cells.Count; h++)
                    {
                        double dbl_temp = 0;
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                            e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        }

                    }
                }
                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    for (int h = 1; h < e.Row.Cells.Count; h++)
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void grd_JobwiseCosting_SelectedIndexChanged(object sender, EventArgs e)
        {
            string transtype = HttpContext.Current.Session["StrTranType"].ToString();
            if (grd_JobwiseCosting.Rows.Count > 0)
            {
                bnt_cancel.Focus();

                int index = grd_JobwiseCosting.SelectedRow.RowIndex;
                int int_jobno = Convert.ToInt32(grd_JobwiseCosting.Rows[index].Cells[2].Text);
                int int_bid = Convert.ToInt32(grd_JobwiseCosting.Rows[index].Cells[9].Text);


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetJobDetailsFrmoJob(int_jobno, int_bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), transtype);
                if (obj_dtjob.Rows.Count > 0)
                {
                    grd_JobwiseCosting.Visible = false;
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("Vslvoy", typeof(string));
                    obj_dt.Columns.Add("Liner", typeof(string));
                    obj_dt.Columns.Add("Agent", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add("Volume", typeof(string));
                    obj_dt.Columns.Add("Cont 20", typeof(string));
                    obj_dt.Columns.Add("Cont 40", typeof(string));
                    obj_dt.Columns.Add("Income", typeof(string));
                    obj_dt.Columns.Add("Expense", typeof(string));
                    obj_dt.Columns.Add("Retention", typeof(string));
                    obj_dt.Columns.Add("TranType", typeof(string));

                    for (int i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = int_jobno;
                        dr[1] = obj_dtjob.Rows[i]["vslvoy"].ToString();
                        dr[2] = obj_dtjob.Rows[i]["liner"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["agent"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["volume"];
                        dr[7] = obj_dtjob.Rows[i]["cont20"];
                        dr[8] = obj_dtjob.Rows[i]["cont40"];
                        dr[9] = obj_dtjob.Rows[i]["income"];
                        dr[10] = obj_dtjob.Rows[i]["expense"];
                        dr[11] = obj_dtjob.Rows[i]["retention"];
                        dr[12] = obj_dtjob.Rows[i]["TranType"];
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[5] = "Total";
                    dr1[6] = sum_volume;
                    dr1[7] = sum_cont20;
                    dr1[8] = sum_cont40;
                    dr1[9] = sum_income;
                    dr1[10] = sum_expense;
                    dr1[11] = sum_retention;
                    GRD_Common.Visible = true;
                    //obj_dt.Columns.RemoveAt(obj_dt.Columns.Count - 1);
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                  //  bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    //GRD_Common.Columns[12].Visible = false;

                    //LinkButton Lnk = (LinkButton)grd_details.Rows[grd_details.Rows.Count - 1].FindControl("Lnk_detail");
                    //if (Lnk != null)
                    //{
                    //    Lnk.Visible = false;
                    //}
                }

            }
        }

        protected void grd_details_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int h = 3; h < e.Row.Cells.Count; h++)
                {
                    if (e.Row.Cells[h].Text == "Volume")
                    {
                        e.Row.Cells[h].Text = "CBM/Kgs";
                    }
                    else if (e.Row.Cells[h].Text == "Cont 20")
                    {
                        e.Row.Cells[h].Text = "20";
                    }
                    else if (e.Row.Cells[h].Text == "Cont 40")
                    {
                        e.Row.Cells[h].Text = "40";
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                int i;
                if (ddl_Report.SelectedItem.Text == "Operating Profit")
                {
                    i = 3;
                }
                else
                {
                    i = 6;
                }
                for (int h = i; h < e.Row.Cells.Count; h++)
                {

                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    }

                }
                if (e.Row.Cells[0].Text.ToString().Replace("&nbsp;", "").Trim() == "")
                {
                    LinkButton Lnk = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Lnk_detail");
                    Lnk.Visible = false;

                }
            }
        }

        protected void grd_POD_RowDataBound(object sender, GridViewRowEventArgs e)
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


                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                } if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_POD, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void grd_salesperson_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                } if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_salesperson, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";

                }
            }
        }

        protected void Grd_nomination_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[1].Text == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;

                } if (e.Row.Cells[1].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_nomination, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void grd_lossjob_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (e.Row.Cells[2].Text == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;

                } if (e.Row.Cells[2].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_lossjob, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void grd_Shipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_Shipment.Rows.Count > 0)
            {

                if (!string.IsNullOrWhiteSpace(grd_Shipment.SelectedRow.Cells[2].Text.ToString()) || grd_Shipment.SelectedRow.Cells[2].Text != "0")
                {
                    bnt_cancel.Focus();
                    int i;
                    int int_jobno = Convert.ToInt32(grd_Shipment.SelectedRow.Cells[1].Text.ToString());
                    int int_bid = Convert.ToInt32(grd_Shipment.SelectedDataKey.Values[1].ToString());


                    DataTable obj_dt = new DataTable();
                    DataTable obj_dtjob = new DataTable();
                    string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                    DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                    obj_dtjob = da_obj_misgrd.GetshipmentDetailsfromjobno(grd_Shipment.SelectedDataKey.Values[0].ToString(), int_bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_jobno, Convert.ToInt32(Session["LoginDivisionId"].ToString()), " ");
                    if (obj_dtjob.Rows.Count > 0)
                    {
                        grd_Shipment.Visible = false;
                        if (Session["StrTranType"].ToString() != "CH")
                        {
                            obj_dt.Columns.Add("TranType", typeof(string));
                            obj_dt.Columns.Add("Job #", typeof(string));
                            obj_dt.Columns.Add("Job type", typeof(string));
                            obj_dt.Columns.Add("BL #", typeof(string));
                            obj_dt.Columns.Add("Nomination", typeof(string));
                            obj_dt.Columns.Add("Shipper", typeof(string));
                            obj_dt.Columns.Add("Consignee", typeof(string));
                            obj_dt.Columns.Add("Agent", typeof(string));
                            obj_dt.Columns.Add("PoL", typeof(string));
                            obj_dt.Columns.Add("PoD", typeof(string));
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                        }
                        else
                        {
                            obj_dt.Columns.Add("TranType", typeof(string));
                            obj_dt.Columns.Add("Job #", typeof(string));
                            obj_dt.Columns.Add("Job type", typeof(string));
                            obj_dt.Columns.Add("Doc #", typeof(string));
                            obj_dt.Columns.Add("Nomination", typeof(string));
                            obj_dt.Columns.Add("Shipper", typeof(string));
                            obj_dt.Columns.Add("Consignee", typeof(string));
                            obj_dt.Columns.Add("Agent", typeof(string));
                            obj_dt.Columns.Add("PoL", typeof(string));
                            obj_dt.Columns.Add("PoD", typeof(string));
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Net wt", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                        }

                        for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                        {
                            DataRow dr = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr);
                            if (Session["StrTranType"].ToString() != "CH")
                            {
                                if (obj_dtjob.Rows[i]["jobtype"].ToString() == "1")
                                {
                                    dr[2] = "Consol";
                                }
                                else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "2")
                                {
                                    dr[2] = "Co-Load";
                                }
                                else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "3")
                                {
                                    dr[2] = "FCL";
                                }
                                else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "4")
                                {
                                    dr[2] = "MCC";
                                }
                                else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "5")
                                {
                                    dr[2] = "Buyer Consol";
                                }
                            }
                            else
                            {
                                if (obj_dtjob.Rows[i]["jobtype"].ToString() == "1")
                                {
                                    dr[2] = "Sea Export";
                                }
                                else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "2")
                                {
                                    dr[2] = "Sea Import";
                                }
                                else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "3")
                                {
                                    dr[2] = "Air Export";
                                }
                                else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "4")
                                {
                                    dr[2] = "Air Import";
                                }
                                else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "5")
                                {
                                    dr[2] = "By Road";
                                }
                            }
                            dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                            dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                            dr[3] = obj_dtjob.Rows[i]["blno"].ToString();
                            dr[4] = obj_dtjob.Rows[i]["Nomination"].ToString();
                            dr[5] = obj_dtjob.Rows[i]["shipper"].ToString();
                            dr[6] = obj_dtjob.Rows[i]["Consignee"].ToString();
                            dr[7] = obj_dtjob.Rows[i]["agent"].ToString();
                            dr[8] = obj_dtjob.Rows[i]["pol"].ToString();
                            dr[9] = obj_dtjob.Rows[i]["pod"].ToString();
                            dr[10] = obj_dtjob.Rows[i]["volume"].ToString();
                            dr[11] = obj_dtjob.Rows[i]["cont20"].ToString();
                            dr[12] = obj_dtjob.Rows[i]["cont40"].ToString();
                            dr[13] = obj_dtjob.Rows[i]["income"].ToString();
                            dr[14] = obj_dtjob.Rows[i]["expense"].ToString();
                            dr[15] = obj_dtjob.Rows[i]["retention"].ToString();
                        }
                        var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                        var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                        var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                        var sum_income = obj_dtjob.Compute("sum(Income)", "");
                        var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                        var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                        DataRow dr1 = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr1);
                        dr1[9] = "Total";
                        dr1[10] = sum_volume;
                        dr1[11] = sum_cont20;
                        dr1[12] = sum_cont40;
                        dr1[13] = sum_income;
                        dr1[14] = sum_expense;
                        dr1[15] = sum_retention;
                        GRD_Common.Visible = true;
                        GRD_Common.DataSource = obj_dt;
                        GRD_Common.DataBind();
                       // bnt_cancel.Text = "Cancel";


                        bnt_cancel.ToolTip = "Cancel";
                        bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }
            }
        }

        protected void grd_Shipper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_Shipper.Rows.Count > 0)
            {

                int i;
                int int_shiperId = Convert.ToInt32(grd_Shipper.SelectedDataKey.Values[0].ToString());
                bnt_cancel.Focus();


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetshipmentDetails4Shipper(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (obj_dtjob.Rows.Count > 0)
                {
                    grd_Shipper.Visible = false;
                    obj_dt.Columns.Add("TranType", typeof(string));
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("BL #", typeof(string));
                    obj_dt.Columns.Add("Consignee", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });


                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);

                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[2] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["Consignee"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["volume"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["cont20"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["cont40"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[11] = obj_dtjob.Rows[i]["retention"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[5] = "Total";
                    dr1[6] = sum_volume;
                    dr1[7] = sum_cont20;
                    dr1[8] = sum_cont40;
                    dr1[9] = sum_income;
                    dr1[10] = sum_expense;
                    dr1[11] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                }

                if (grd_Shipper.Rows.Count > 0)
                {
                    obj_dtjob = da_obj_misgrd.GetTeus4Shipper(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (obj_dtjob.Rows.Count > 0)
                    {
                        this.popup.Show();
                        grdshipteusdtls.DataSource = obj_dtjob;
                        grdshipteusdtls.DataBind();
                    }
                }

                if (grd_Shipper.Rows.Count > 0)
                {
                    DataSet dt_Liner = new DataSet();
                    DataTable dtemptyfree = new DataTable();

                    dt_Liner = da_obj_misgrd.GetTeus4ShipperYearwise(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString())); ;

                    DataRow[] dr1 = new DataRow[dt_Liner.Tables[0].Rows.Count];
                    dt_Liner.Tables[0].Rows.CopyTo(dr1, 0);
                    //int[] dblPrice = Array.ConvertAll(dr1, new Converter<DataRow, Int32>(DataRowToDouble));

                    if (dt_Liner.Tables[1].Rows.Count > 0)
                    {
                        dtemptyfree.Columns.Add("month");
                        dtemptyfree.Columns.Add("branch");
                        dtemptyfree.Columns.Add("vol1");
                        dtemptyfree.Columns.Add("teus1");
                        dtemptyfree.Columns.Add("weight1");
                        dtemptyfree.Columns.Add("retention1");
                        dtemptyfree.Columns.Add("vol2");
                        dtemptyfree.Columns.Add("teus2");
                        dtemptyfree.Columns.Add("weight2");
                        dtemptyfree.Columns.Add("retention2");

                        DataRow dr = dtemptyfree.NewRow();
                        for (int j = 0; j <= dt_Liner.Tables[1].Rows.Count - 1; j++)
                        {
                            dr = dtemptyfree.NewRow();
                            dr["month"] = dt_Liner.Tables[1].Rows[j]["month"].ToString();
                            dr["branch"] = dt_Liner.Tables[1].Rows[j]["branch"].ToString();
                            dr["vol1"] = dt_Liner.Tables[1].Rows[j]["volume"].ToString();
                            dr["teus1"] = dt_Liner.Tables[1].Rows[j]["teus"].ToString();
                            dr["weight1"] = dt_Liner.Tables[1].Rows[j]["weight"].ToString();
                            dr["retention1"] = dt_Liner.Tables[1].Rows[j]["retention"].ToString();
                            dr["vol2"] = dt_Liner.Tables[1].Rows[j]["volume1"].ToString();
                            dr["teus2"] = dt_Liner.Tables[1].Rows[j]["teus1"].ToString();
                            dr["weight2"] = dt_Liner.Tables[1].Rows[j]["weight1"].ToString();
                            dr["retention2"] = dt_Liner.Tables[1].Rows[j]["retention1"].ToString();

                            dtemptyfree.Rows.Add(dr);
                            //}
                            if (dtemptyfree.Rows.Count > 0)
                            {
                                this.popup.Show();
                                grdyear.DataSource = dtemptyfree;
                                grdyear.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void grd_Shipper_RowDataBound(object sender, GridViewRowEventArgs e)
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
                Label Shipper = (Label)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Shipper");
                if (Shipper.Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                } if (Shipper.Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Shipper, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }

        protected void grd_Agent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_Agent.Rows.Count > 0)
            {

                int i;
                int int_shiperId = Convert.ToInt32(grd_Agent.SelectedDataKey.Values[0].ToString());



                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetshipmentDetails4AgentOld(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (obj_dtjob.Rows.Count > 0)
                {
                    grd_Agent.Visible = false;
                    obj_dt.Columns.Add("TranType", typeof(string));
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("BL #", typeof(string));
                    obj_dt.Columns.Add("Shipper", typeof(string));
                    obj_dt.Columns.Add("Consignee", typeof(string));
                    obj_dt.Columns.Add("Agent", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Net wt", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });

                    DataRow dr = obj_dt.NewRow();
                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);

                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[2] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["shipper"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["Consignee"].ToString();
                      //  Label agent = (Label)grd_Agent.Rows[i].FindControl("agent");
                          Label agent = (Label)grd_Agent.Rows[grd_Agent.SelectedRow.RowIndex].FindControl("agent");
                        dr[5] = agent.Text;
                        dr[6] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["volume"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["cont20"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["cont40"].ToString();
                        dr[11] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[12] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[13] = obj_dtjob.Rows[i]["retention"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    //DataRow dr1 = obj_dt.NewRow();
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[7] = "Total";
                    dr[8] = sum_volume;
                    dr[9] = sum_cont20;
                    dr[10] = sum_cont40;
                    dr[11] = sum_income;
                    dr[12] = sum_expense;
                    dr[13] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                    //bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    bnt_cancel.Focus();
                }

                if (grd_Agent.Rows.Count > 0)
                {
                    obj_dtjob = da_obj_misgrd.GetTeus4Agent(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (obj_dtjob.Rows.Count > 0)
                    {
                        this.popup.Show();
                        grdshipteusdtls.DataSource = obj_dtjob;
                        grdshipteusdtls.DataBind();

                    }
                }

                if (grd_Agent.Rows.Count > 0)
                {
                    DataSet dt_Liner = new DataSet();
                    DataTable dtemptyfree = new DataTable();

                    dt_Liner = da_obj_misgrd.GetTeus4agentYearwise(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString())); ;

                    DataRow[] dr1 = new DataRow[dt_Liner.Tables[0].Rows.Count];
                    dt_Liner.Tables[0].Rows.CopyTo(dr1, 0);
                    //int[] dblPrice = Array.ConvertAll(dr1, new Converter<DataRow, Int32>(DataRowToDouble));

                    if (dt_Liner.Tables[1].Rows.Count > 0)
                    {
                        dtemptyfree.Columns.Add("month");
                        dtemptyfree.Columns.Add("branch");
                        dtemptyfree.Columns.Add("vol1");
                        dtemptyfree.Columns.Add("teus1");
                        dtemptyfree.Columns.Add("weight1");
                        dtemptyfree.Columns.Add("retention1");
                        dtemptyfree.Columns.Add("vol2");
                        dtemptyfree.Columns.Add("teus2");
                        dtemptyfree.Columns.Add("weight2");
                        dtemptyfree.Columns.Add("retention2");

                        DataRow dr = dtemptyfree.NewRow();
                        for (int j = 0; j <= dt_Liner.Tables[1].Rows.Count - 1; j++)
                        {
                            dr = dtemptyfree.NewRow();
                            dr["month"] = dt_Liner.Tables[1].Rows[j]["month"].ToString();
                            dr["branch"] = dt_Liner.Tables[1].Rows[j]["branch"].ToString();
                            dr["vol1"] = dt_Liner.Tables[1].Rows[j]["volume"].ToString();
                            dr["teus1"] = dt_Liner.Tables[1].Rows[j]["teus"].ToString();
                            dr["weight1"] = dt_Liner.Tables[1].Rows[j]["weight"].ToString();
                            dr["retention1"] = dt_Liner.Tables[1].Rows[j]["retention"].ToString();
                            dr["vol2"] = dt_Liner.Tables[1].Rows[j]["volume1"].ToString();
                            dr["teus2"] = dt_Liner.Tables[1].Rows[j]["teus1"].ToString();
                            dr["weight2"] = dt_Liner.Tables[1].Rows[j]["weight1"].ToString();
                            dr["retention2"] = dt_Liner.Tables[1].Rows[j]["retention1"].ToString();

                            dtemptyfree.Rows.Add(dr);
                            //}
                            if (dtemptyfree.Rows.Count > 0)
                            {
                                this.popup.Show();
                                grdyear.DataSource = dtemptyfree;
                                grdyear.DataBind();
                            }
                        }
                    }
                }

            }
        }

        protected void grd_Consignee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_Consignee.Rows.Count > 0)
            {
                bnt_cancel.Focus();
                int i;
                int int_shiperId = Convert.ToInt32(grd_Consignee.SelectedDataKey.Values[0].ToString());


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetshipmentDetails4Consignee(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (obj_dtjob.Rows.Count > 0)
                {
                    grd_Consignee.Visible = false;
                    if (Session["StrTranType"].ToString() != "CH")
                    {
                        obj_dt.Columns.Add("TranType", typeof(string));
                        obj_dt.Columns.Add("Job #", typeof(string));
                        obj_dt.Columns.Add("BL #", typeof(string));
                        obj_dt.Columns.Add("Shipper", typeof(string));
                        obj_dt.Columns.Add("Consignee", typeof(string));
                        obj_dt.Columns.Add("PoL", typeof(string));
                        obj_dt.Columns.Add("PoD", typeof(string));
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                    }
                    else
                    {
                        obj_dt.Columns.Add("TranType", typeof(string));
                        obj_dt.Columns.Add("Job #", typeof(string));
                        obj_dt.Columns.Add("Doc #", typeof(string));
                        obj_dt.Columns.Add("Shipper", typeof(string));
                        obj_dt.Columns.Add("Consignee", typeof(string));
                        obj_dt.Columns.Add("PoL", typeof(string));
                        obj_dt.Columns.Add("PoD", typeof(string));
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Net wt", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                    }
                    DataRow dr = obj_dt.NewRow();
                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);


                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[2] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["shipper"].ToString();
                        //Label Consignee = (Label)grd_Consignee.Rows[i].FindControl("Consignee");
                         Label lbl_Consignee = (Label)grd_Consignee.Rows[grd_Consignee.SelectedRow.RowIndex].FindControl("Consignee");
                        dr[4] = lbl_Consignee.Text;
                        dr[5] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["volume"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["cont20"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["cont40"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[11] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[12] = obj_dtjob.Rows[i]["retention"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[6] = "Total";
                    dr1[7] = sum_volume;
                    dr1[8] = sum_cont20;
                    dr1[9] = sum_cont40;
                    dr1[10] = sum_income;
                    dr1[11] = sum_expense;
                    dr1[12] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                   // bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {

                    grd_Consignee.Visible = true;
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "CAN Report", "alertify.alert('Data not available');", true);
                }



                if (grd_Consignee.Rows.Count > 0)
                {
                    obj_dtjob = da_obj_misgrd.GetTeus4consignee(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (obj_dtjob.Rows.Count > 0)
                    {
                        this.popup.Show();
                        grdshipteusdtls.DataSource = obj_dtjob;
                        grdshipteusdtls.DataBind();

                    }
                }

                if (grd_Consignee.Rows.Count > 0)
                {
                    DataSet dt_Liner = new DataSet();
                    DataTable dtemptyfree = new DataTable();

                    dt_Liner = da_obj_misgrd.GetTeus4consigneeYearwise(int_shiperId, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString())); ;

                    DataRow[] dr1 = new DataRow[dt_Liner.Tables[0].Rows.Count];
                    dt_Liner.Tables[0].Rows.CopyTo(dr1, 0);
                    //int[] dblPrice = Array.ConvertAll(dr1, new Converter<DataRow, Int32>(DataRowToDouble));

                    if (dt_Liner.Tables[1].Rows.Count > 0)
                    {
                        dtemptyfree.Columns.Add("month");
                        dtemptyfree.Columns.Add("branch");
                        dtemptyfree.Columns.Add("vol1");
                        dtemptyfree.Columns.Add("teus1");
                        dtemptyfree.Columns.Add("weight1");
                        dtemptyfree.Columns.Add("retention1");
                        dtemptyfree.Columns.Add("vol2");
                        dtemptyfree.Columns.Add("teus2");
                        dtemptyfree.Columns.Add("weight2");
                        dtemptyfree.Columns.Add("retention2");

                        DataRow dr = dtemptyfree.NewRow();
                        for (int j = 0; j <= dt_Liner.Tables[1].Rows.Count - 1; j++)
                        {


                            dr = dtemptyfree.NewRow();
                            dr["month"] = dt_Liner.Tables[1].Rows[j]["month"].ToString();
                            dr["branch"] = dt_Liner.Tables[1].Rows[j]["branch"].ToString();
                            dr["vol1"] = dt_Liner.Tables[1].Rows[j]["volume"].ToString();
                            dr["teus1"] = dt_Liner.Tables[1].Rows[j]["teus"].ToString();
                            dr["weight1"] = dt_Liner.Tables[1].Rows[j]["weight"].ToString();
                            dr["retention1"] = dt_Liner.Tables[1].Rows[j]["retention"].ToString();
                            dr["vol2"] = dt_Liner.Tables[1].Rows[j]["volume1"].ToString();
                            dr["teus2"] = dt_Liner.Tables[1].Rows[j]["teus1"].ToString();
                            dr["weight2"] = dt_Liner.Tables[1].Rows[j]["weight1"].ToString();
                            dr["retention2"] = dt_Liner.Tables[1].Rows[j]["retention1"].ToString();

                            dtemptyfree.Rows.Add(dr);
                            //}
                            if (dtemptyfree.Rows.Count > 0)
                            {
                                this.popup.Show();
                                grdyear.DataSource = dtemptyfree;
                                grdyear.DataBind();
                            }
                        }
                    }
                }


            }
        }

        protected void grd_salesperson_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (grd_salesperson.Rows.Count > 0)
            {
                bnt_cancel.Focus();
                grd_salesperson.Visible = false;
                int i;
                int int_Salesid = Convert.ToInt32(grd_salesperson.SelectedDataKey.Values[0].ToString());


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetshipmentDetailsfromsales(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_Salesid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (obj_dtjob.Rows.Count > 0)
                {

                    obj_dt.Columns.Add("TranType", typeof(string));
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("Job type", typeof(string));
                    obj_dt.Columns.Add("BL #", typeof(string));
                    obj_dt.Columns.Add("Nomination", typeof(string));
                    obj_dt.Columns.Add("Shipper", typeof(string));
                    obj_dt.Columns.Add("Consignee", typeof(string));
                    obj_dt.Columns.Add("Agent", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });



                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        if (obj_dtjob.Rows[i]["jobtype"].ToString() == "1")
                        {
                            dr[2] = "Consol";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "2")
                        {
                            dr[2] = "Co-Load";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "3")
                        {
                            dr[2] = "FCL";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "4")
                        {
                            dr[2] = "MCC";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "5")
                        {
                            dr[2] = "Buyer Consol";
                        }

                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["Nomination"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["shipper"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["Consignee"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["agent"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["volume"].ToString();
                        dr[11] = obj_dtjob.Rows[i]["cont20"].ToString();
                        dr[12] = obj_dtjob.Rows[i]["cont40"].ToString();
                        dr[13] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[14] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[15] = obj_dtjob.Rows[i]["retention"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[9] = "Total";
                    dr1[10] = sum_volume;
                    dr1[11] = sum_cont20;
                    dr1[12] = sum_cont40;
                    dr1[13] = sum_income;
                    dr1[14] = sum_expense;
                    dr1[15] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                //    bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                if (grd_salesperson.Rows.Count > 0)
                {
                    obj_dtjob = da_obj_misgrd.GetTeus4Agent(int_Salesid, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (obj_dtjob.Rows.Count > 0)
                    {
                        this.popup.Show();
                        grdshipteusdtls.DataSource = obj_dtjob;
                        grdshipteusdtls.DataBind();

                    }
                }

                if (grd_salesperson.Rows.Count > 0)
                {
                    DataSet dt_Liner = new DataSet();
                    DataTable dtemptyfree = new DataTable();

                    dt_Liner = da_obj_misgrd.GetTeus4agentYearwise(int_Salesid, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString())); ;

                    DataRow[] dr1 = new DataRow[dt_Liner.Tables[0].Rows.Count];
                    dt_Liner.Tables[0].Rows.CopyTo(dr1, 0);
                    // int[] dblPrice = Array.ConvertAll(dr1, new Converter<DataRow, Int32>(DataRowToDouble));

                    if (dt_Liner.Tables[1].Rows.Count > 0)
                    {
                        dtemptyfree.Columns.Add("month");
                        dtemptyfree.Columns.Add("branch");
                        dtemptyfree.Columns.Add("vol1");
                        dtemptyfree.Columns.Add("teus1");
                        dtemptyfree.Columns.Add("weight1");
                        dtemptyfree.Columns.Add("retention1");
                        dtemptyfree.Columns.Add("vol2");
                        dtemptyfree.Columns.Add("teus2");
                        dtemptyfree.Columns.Add("weight2");
                        dtemptyfree.Columns.Add("retention2");

                        DataRow dr = dtemptyfree.NewRow();
                        for (int j = 0; j <= dt_Liner.Tables[1].Rows.Count - 1; j++)
                        {

                            dr = dtemptyfree.NewRow();
                            dr["month"] = dt_Liner.Tables[1].Rows[j]["month"].ToString();
                            dr["branch"] = dt_Liner.Tables[1].Rows[j]["branch"].ToString();
                            dr["vol1"] = dt_Liner.Tables[1].Rows[j]["volume"].ToString();
                            dr["teus1"] = dt_Liner.Tables[1].Rows[j]["teus"].ToString();
                            dr["weight1"] = dt_Liner.Tables[1].Rows[j]["weight"].ToString();
                            dr["retention1"] = dt_Liner.Tables[1].Rows[j]["retention"].ToString();
                            dr["vol2"] = dt_Liner.Tables[1].Rows[j]["volume1"].ToString();
                            dr["teus2"] = dt_Liner.Tables[1].Rows[j]["teus1"].ToString();
                            dr["weight2"] = dt_Liner.Tables[1].Rows[j]["weight1"].ToString();
                            dr["retention2"] = dt_Liner.Tables[1].Rows[j]["retention1"].ToString();

                            dtemptyfree.Rows.Add(dr);
                            //}
                            if (dtemptyfree.Rows.Count > 0)
                            {
                                this.popup.Show();
                                grdyear.DataSource = dtemptyfree;
                                grdyear.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void grd_operProfit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_operProfit.Rows.Count > 0)
            {
                Load_opertaionpro();
                bnt_cancel.Focus();
            }
        }

        protected void Load_opertaionpro()
        {


            str_TranType = "";
            str_Branch = "";
            DataTable dtNew = new DataTable();
            int index, indexcell, jobno = 0, branchid = 0;
            string Product = "", jobtype = "", trantype = "", tran = "";
            DataTable dtcell = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            if (Session["HeadOP"] != null)
            {
                str_TranType = Session["HeadOP"].ToString();
            }
            else
            {
                str_TranType = Session["StrTranType"].ToString();
            }
            dtcell = da_obj_misgrd.Getshipmentnew(str_TranType, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));


            if (dtcell.Rows.Count > 0)
            {
                //this.popup.Show();
                if (grd_operProfit.Visible == true)
                {
                    grd_operProfit.Visible = false;
                }
                else if (grd_operProfit_AC.Visible == true)
                {
                    grd_operProfit_AC.Visible = false;
                }

                double totalgrand40 = 0, totalgrand20 = 0, totalgrandvou = 0, totalincomegrand = 0, totalexpensegrand = 0, totalretentiongrand = 0;
                DataTable dtempty = new DataTable();

                dtempty.Columns.Add("trantype");

                dtempty.Columns.Add("Job #");
                dtempty.Columns.Add("Nomination");
                dtempty.Columns.Add("Volume");
                dtempty.Columns.Add("Cont 20");
                dtempty.Columns.Add("Cont 40");
                dtempty.Columns.Add("Income");
                dtempty.Columns.Add("Expense");
                dtempty.Columns.Add("Retention");
                dtempty.Columns.Add("branchid");
                DataRow dr = dtempty.NewRow();
                DataView dv_co = new DataView(dtcell);
                dtNew = dv_co.ToTable(true, "trantype");
                dv_co = new DataView(dtNew);
                dv_co.Sort = "trantype";
                dtNew = dv_co.ToTable();

                for (int j = 0; j <= dtNew.Rows.Count - 1; j++)
                {
                    double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;
                    int t20 = 0, t40 = 0, int_temp = 0;
                    DataTable dtLi = new DataTable();
                    DataView data1 = dtcell.DefaultView;
                    data1.RowFilter = "trantype = '" + dtNew.Rows[j]["trantype"] + "' ";
                    dtLi = data1.ToTable();
                    // count1=dtLi.Rows.Count;
                    dr = dtempty.NewRow();
                    if (dtNew.Rows[j]["trantype"].ToString() == "AI")
                    {
                        tran = "Air Imports";
                    }
                    else if (dtNew.Rows[j]["trantype"].ToString() == "AE")
                    {
                        tran = "Air Exports";
                    }
                    else if (dtNew.Rows[j]["trantype"].ToString() == "FE" || dtNew.Rows[j]["trantype"].ToString() == "OE")
                    {
                        tran = "Ocean Exports";
                    }
                    else if (dtNew.Rows[j]["trantype"].ToString() == "FI" || dtNew.Rows[j]["trantype"].ToString() == "OI")
                    {
                        tran = "Ocean Imports";
                    }
                    else if (dtNew.Rows[j]["trantype"].ToString() == "CH")
                    {
                        tran = "C H A";
                    }
                    else if (dtNew.Rows[j]["trantype"].ToString() == "CH")
                    {
                        tran = "Data WareHousing";
                    }
                    // dtempty.Rows.Add();
                    dr["trantype"] = tran;


                    dtempty.Rows.Add(dr);

                    for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                    {

                        //dr = dtempty.NewRow();


                        int count = dtempty.Rows.Count;
                        dr = dtempty.NewRow();
                        dtempty.Rows.Add();

                        dtempty.Rows[count]["trantype"] = dtcell.Rows[i]["trantype"].ToString();
                        dtempty.Rows[count]["Job #"] = dtcell.Rows[i]["jobno"].ToString();
                        dtempty.Rows[count]["Nomination"] = dtcell.Rows[i]["Nomination"].ToString();
                        temp2 = Convert.ToDouble(dtcell.Rows[i]["volume"].ToString());
                        dtempty.Rows[count]["Volume"] = temp2.ToString("#,0.00");
                        totalvou = totalvou + Convert.ToDouble(dtempty.Rows[count]["Volume"]);
                        int_temp = Convert.ToInt32(dtcell.Rows[i]["cont20"].ToString());
                        dtempty.Rows[count]["Cont 20"] = int_temp.ToString();
                        t20 = t20 + Convert.ToInt32(dtempty.Rows[count]["Cont 20"]);
                        int_temp = Convert.ToInt32(dtcell.Rows[i]["cont40"].ToString());
                        dtempty.Rows[count]["Cont 40"] = int_temp.ToString();
                        t40 = t40 + Convert.ToInt32(dtempty.Rows[count]["Cont 40"]);
                        temp2 = Convert.ToDouble(dtcell.Rows[i]["income"].ToString());
                        dtempty.Rows[count]["Income"] = temp2.ToString("#,0.00");
                        totalincome = totalincome + Convert.ToDouble(dtempty.Rows[count]["Income"]);
                        temp2 = Convert.ToDouble(dtcell.Rows[i]["expense"].ToString());
                        dtempty.Rows[count]["Expense"] = temp2.ToString("#,0.00");
                        totalexpense = totalexpense + Convert.ToDouble(dtempty.Rows[count]["Expense"]);
                        temp2 = Convert.ToDouble(dtcell.Rows[i]["retention"].ToString());
                        dtempty.Rows[count]["Retention"] = temp2.ToString("#,0.00");
                        totalretention = totalretention + Convert.ToDouble(dtempty.Rows[count]["Retention"]);


                        dtempty.Rows[count]["branchid"] = bid;
                    }
                    dr = dtempty.NewRow();
                    dr["Nomination"] = "Total";
                    dr["volume"] = totalvou.ToString("#,0.00");
                    dr["Cont 20"] = t20.ToString();
                    dr["Cont 40"] = t40.ToString();
                    dr["Income"] = totalincome.ToString("#,0.00");
                    dr["Expense"] = totalexpense.ToString("#,0.00");
                    dr["Retention"] = totalretention.ToString("#,0.00");
                    dtempty.Rows.Add(dr);
                    dtempty.Columns.RemoveAt(dtempty.Columns.Count - 1);
                    GRD_Common.DataSource = dtempty;
                    GRD_Common.DataBind();
                    GRD_Common.HeaderRow.Cells[0].Text = "Product";
                    GRD_Common.Visible = true;
                    //bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    Session["HeadOP"] = null;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                return;
            }
        }

        protected void grd_op_RowDataBound(object sender, GridViewRowEventArgs e)
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


                if (e.Row.Cells[1].Text == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                } if (e.Row.Cells[1].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_op, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }

        protected void Grd_nomination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grd_nomination.Rows.Count > 0)
            {
                bnt_cancel.Focus();
                string nomination = "";
                int i;
                int int_jobno = Convert.ToInt32(Grd_nomination.SelectedRow.Cells[1].Text.ToString());


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                if (ddl_Report.SelectedItem.Text == "FreeHand")
                {
                    nomination = "F";

                }
                else
                {
                    nomination = "N";
                }
                obj_dtjob = da_obj_misgrd.GetshipmentDetailsfromjobno(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_jobno, Convert.ToInt32(Session["LoginDivisionId"].ToString()), nomination);
                if (obj_dtjob.Rows.Count > 0)
                {
                    Grd_nomination.Visible = false;
                    obj_dt.Columns.Add("TranType", typeof(string));
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("Job type", typeof(string));
                    obj_dt.Columns.Add("BL #", typeof(string));
                    obj_dt.Columns.Add("Nomination", typeof(string));
                    obj_dt.Columns.Add("Shipper", typeof(string));
                    obj_dt.Columns.Add("Consignee", typeof(string));
                    obj_dt.Columns.Add("Agent", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });


                    DataRow dr = obj_dt.NewRow();
                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        if (obj_dtjob.Rows[i]["jobtype"].ToString() == "1")
                        {
                            dr[2] = "Consol";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "2")
                        {
                            dr[2] = "Co-Load";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "3")
                        {
                            dr[2] = "FCL";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "4")
                        {
                            dr[2] = "MCC";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "5")
                        {
                            dr[2] = "Buyer Consol";
                        }

                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["Nomination"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["shipper"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["Consignee"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["agent"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["volume"].ToString();
                        dr[11] = obj_dtjob.Rows[i]["cont20"].ToString();
                        dr[12] = obj_dtjob.Rows[i]["cont40"].ToString();
                        dr[13] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[14] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[15] = obj_dtjob.Rows[i]["retention"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[9] = "Total";
                    dr1[10] = sum_volume;
                    dr1[11] = sum_cont20;
                    dr1[12] = sum_cont40;
                    dr1[13] = sum_income;
                    dr1[14] = sum_expense;
                    dr1[15] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();

                }
            }
        }

        protected void grd_POL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_POL.Rows.Count > 0)
            {
                bnt_cancel.Focus();
                int i;
                int int_polid = Convert.ToInt32(grd_POL.SelectedDataKey.Values[0].ToString());


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetshipmentDetailsfrompolno(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_polid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (obj_dtjob.Rows.Count > 0)
                {
                    grd_POL.Visible = false;
                    obj_dt.Columns.Add("TranType", typeof(string));
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("Job type", typeof(string));
                    obj_dt.Columns.Add("BL #", typeof(string));
                    obj_dt.Columns.Add("Nomination", typeof(string));
                    obj_dt.Columns.Add("Shipper", typeof(string));
                    obj_dt.Columns.Add("Consignee", typeof(string));
                    obj_dt.Columns.Add("Agent", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });



                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        int cont20, cont40;
                        if (obj_dtjob.Rows[i]["jobtype"].ToString() == "1")
                        {
                            dr[2] = "Consol";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "2")
                        {
                            dr[2] = "Co-Load";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "3")
                        {
                            dr[2] = "FCL";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "4")
                        {
                            dr[2] = "MCC";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "5")
                        {
                            dr[2] = "Buyer Consol";
                        }

                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["Nomination"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["shipper"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["Consignee"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["agent"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["volume"].ToString();
                        cont20 = Convert.ToInt32(obj_dtjob.Rows[i]["cont20"].ToString());
                        dr[11] = cont20;
                        cont40 = Convert.ToInt32(obj_dtjob.Rows[i]["cont40"].ToString());
                        dr[12] = cont40;
                        dr[13] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[14] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[15] = obj_dtjob.Rows[i]["retention"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = Convert.ToInt32(obj_dtjob.Compute("sum(cont20)", ""));
                    var sum_cont40 = Convert.ToInt32(obj_dtjob.Compute("sum(cont40)", ""));
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[9] = "Total";
                    dr1[10] = sum_volume;
                    dr1[11] = sum_cont20;
                    dr1[12] = sum_cont40;
                    dr1[13] = sum_income;
                    dr1[14] = sum_expense;
                    dr1[15] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                   // bnt_cancel.Text = "Cancel";
                 

                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                }
            }
        }

        protected void grd_POD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_POD.Rows.Count > 0)
            {
                bnt_cancel.Focus();
                int i, cont20, cont40;
                int int_polid = Convert.ToInt32(grd_POD.SelectedDataKey.Values[0].ToString());


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetshipmentDetailsfrompodno(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_polid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (obj_dtjob.Rows.Count > 0)
                {
                    grd_POD.Visible = false;
                    obj_dt.Columns.Add("TranType", typeof(string));
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("Job type", typeof(string));
                    obj_dt.Columns.Add("BL #", typeof(string));
                    obj_dt.Columns.Add("Nomination", typeof(string));
                    obj_dt.Columns.Add("Shipper", typeof(string));
                    obj_dt.Columns.Add("Consignee", typeof(string));
                    obj_dt.Columns.Add("Agent", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });



                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        if (obj_dtjob.Rows[i]["jobtype"].ToString() == "1")
                        {
                            dr[2] = "Consol";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "2")
                        {
                            dr[2] = "Co-Load";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "3")
                        {
                            dr[2] = "FCL";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "4")
                        {
                            dr[2] = "MCC";
                        }
                        else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "5")
                        {
                            dr[2] = "Buyer Consol";
                        }

                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["Nomination"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["shipper"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["Consignee"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["agent"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["volume"].ToString();
                        cont20 = Convert.ToInt32(obj_dtjob.Rows[i]["cont20"].ToString());
                        dr[11] = cont20;
                        cont40 = Convert.ToInt32(obj_dtjob.Rows[i]["cont40"].ToString());
                        dr[12] = cont40;
                        dr[13] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[14] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[15] = obj_dtjob.Rows[i]["retention"].ToString();
                    }


                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = Convert.ToInt32(obj_dtjob.Compute("sum(cont20)", ""));
                    var sum_cont40 = Convert.ToInt32(obj_dtjob.Compute("sum(cont40)", ""));
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[9] = "Total";
                    dr1[10] = sum_volume;
                    dr1[11] = sum_cont20;
                    dr1[12] = sum_cont40;
                    dr1[13] = sum_income;
                    dr1[14] = sum_expense;
                    dr1[15] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                }
            }
        }

        protected void grd_lossjob_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_lossjob.Rows.Count > 0)
            {
                bnt_cancel.Focus();
                int i;
                int int_jobno = Convert.ToInt32(grd_lossjob.SelectedRow.Cells[1].Text.ToString());
                string transtype = HttpContext.Current.Session["StrTranType"].ToString();

                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                //obj_dtjob = da_obj_misgrd.GetJobDetailsFrmoJob(int_jobno, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                obj_dtjob = da_obj_misgrd.GetJobDetailsFrmoJob(int_jobno, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), transtype);
                if (obj_dtjob.Rows.Count > 0)
                {
                    grd_lossjob.Visible = false;
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("VslVoy", typeof(string));
                    obj_dt.Columns.Add("Liner", typeof(string));
                    obj_dt.Columns.Add("Agent", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                    obj_dt.Columns.Add("TranType", typeof(string));

                    DataRow dr = obj_dt.NewRow();
                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);


                        dr[0] = grd_lossjob.SelectedRow.Cells[1].Text.ToString();
                        dr[1] = obj_dtjob.Rows[i]["vslvoy"].ToString();
                        dr[2] = obj_dtjob.Rows[i]["liner"].ToString();
                        dr[3] = obj_dtjob.Rows[i]["agent"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["volume"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["cont20"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["cont40"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[11] = obj_dtjob.Rows[i]["retention"].ToString();
                        dr[12] = obj_dtjob.Rows[i]["Trantype"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[5] = "Total";
                    dr1[6] = sum_volume;
                    dr1[7] = sum_cont20;
                    dr1[8] = sum_cont40;
                    dr1[9] = sum_income;
                    dr1[10] = sum_expense;
                    dr1[11] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                   // bnt_cancel.Text = "Cancel";

                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                }
            }
        }

        protected void Grd_shiperconsignee_RowDataBound(object sender, GridViewRowEventArgs e)
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

                double dbl_temp = 0;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[1].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[1].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }

                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    for (int h = 1; h < e.Row.Cells.Count; h++)
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_shiperconsignee, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }

        protected void Grd_shiperconsignee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grd_shiperconsignee.Rows.Count > 1)
            {
                bnt_cancel.Focus();
                int int_shipperid, i;
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                int_shipperid = da_obj_Customer.GetCustomerIdFrmName(Grd_shiperconsignee.SelectedRow.Cells[0].Text.ToString().Replace("&amp;", "&"));
                int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                string trantype = Session["StrTranType"].ToString();
                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                if (trantype == "FE" || trantype == "AE")
                {
                    obj_dtjob = da_obj_misgrd.GetshipmentDetails4Shipper(int_shipperid, bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), trantype, did);
                }
                else if (trantype == "FI" || trantype == "AI" || trantype == "FC")
                {
                    obj_dtjob = da_obj_misgrd.GetshipmentDetails4Consignee(int_shipperid, bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), trantype, did);
                }
                if (obj_dtjob.Rows.Count > 0)
                {
                    Grd_shiperconsignee.Visible = false;
                    if (Session["StrTranType"].ToString() != "CH")
                    {
                        obj_dt.Columns.Add("TranType", typeof(string));
                        obj_dt.Columns.Add("Job #", typeof(string));
                        obj_dt.Columns.Add("BL #", typeof(string));
                        obj_dt.Columns.Add("Shipper", typeof(string));
                        obj_dt.Columns.Add("Consignee", typeof(string));
                        obj_dt.Columns.Add("PoL", typeof(string));
                        obj_dt.Columns.Add("PoD", typeof(string));
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                    }
                    else
                    {
                        obj_dt.Columns.Add("TranType", typeof(string));
                        obj_dt.Columns.Add("Job #", typeof(string));
                        obj_dt.Columns.Add("Doc #", typeof(string));
                        obj_dt.Columns.Add("Shipper", typeof(string));
                        obj_dt.Columns.Add("Consignee", typeof(string));
                        obj_dt.Columns.Add("PoL", typeof(string));
                        obj_dt.Columns.Add("PoD", typeof(string));
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Net wt", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                    }

                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);


                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[2] = obj_dtjob.Rows[i]["blno"].ToString();

                        dr[3] = Grd_shiperconsignee.SelectedRow.Cells[0].Text.ToString();
                        if (trantype == "FE" || trantype == "AE")
                        {
                            dr[4] = obj_dtjob.Rows[i]["consignee"].ToString();
                        }
                        else if (trantype == "FI" || trantype == "AI" || trantype == "FC")
                        {
                            dr[4] = obj_dtjob.Rows[i]["shipper"].ToString();
                        }

                        dr[5] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["volume"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["cont20"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["cont40"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[11] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[12] = obj_dtjob.Rows[i]["retention"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[6] = "Total";
                    dr1[7] = sum_volume;
                    dr1[8] = sum_cont20;
                    dr1[9] = sum_cont40;
                    dr1[10] = sum_income;
                    dr1[11] = sum_expense;
                    dr1[12] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                }
            }
        }

        protected void grd_YearMIS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
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
                    if (h == 0)
                    {
                        e.Row.Cells[h].Text = "Inc Y2D";
                    }
                    else if (h == 1)
                    {
                        e.Row.Cells[h].Text = "Exp Y2D";
                    }
                    else if (h == 2)
                    {
                        e.Row.Cells[h].Text = "Ret Y2D";
                    }
                    else if (h == 3)
                    {
                        e.Row.Cells[h].Text = "%";
                    }
                    else if (h == 4)
                    {
                        e.Row.Cells[h].Text = "Trantype";
                    }
                    else if (h == 5)
                    {
                        e.Row.Cells[h].Text = "Inc Month";
                    }
                    else if (h == 6)
                    {
                        e.Row.Cells[h].Text = "Exp Month";
                    }
                    else if (h == 7)
                    {
                        e.Row.Cells[h].Text = "Ret Month";
                    }
                    else if (h == 8)
                    {
                        e.Row.Cells[h].Text = "%";
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double dbl_temp = 0;
                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;
                        if (h == 3 || h == 8)
                        {
                            e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp) + "%";
                            e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        }
                        else
                        {
                            e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }
                }

            }
        }

        //protected void grd_details_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    {
        //        GridViewRow row = e.Row;
        //        List<TableCell> columns = new List<TableCell>();
        //        foreach (DataControlField column in grd_details.Columns)
        //        {
        //            TableCell cell = row.Cells[0];
        //            row.Cells.Remove(cell);
        //            columns.Add(cell);
        //        }
        //        row.Cells.AddRange(columns.ToArray());
        //    }
        //}

        //protected void grd_details_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int int_jobno = 0;
        //    string str_trantype = "";
        //    str_trantype = grd_details.SelectedDataKey.Values[0].ToString();
        //    if (ddl_Report.SelectedItem.Text == "Jobwise Costing")
        //    {
        //        int_jobno = int.Parse(grd_details.SelectedRow.Cells[0].Text.ToString());

        //    }
        //    else if (ddl_Report.SelectedItem.Text == "Loss Jobs")
        //    {
        //        int_jobno = int.Parse(grd_details.SelectedRow.Cells[0].Text.ToString());
        //    }

        //    else
        //    {
        //        int_jobno = int.Parse(grd_details.SelectedRow.Cells[1].Text.ToString());
        //    }



        //}

        protected void grd_operProfit_RowCreated(object sender, GridViewRowEventArgs e)
        {
            {
                GridViewRow row = e.Row;
                List<TableCell> columns = new List<TableCell>();
                foreach (DataControlField column in grd_operProfit.Columns)
                {
                    TableCell cell = row.Cells[0];
                    row.Cells.Remove(cell);
                    columns.Add(cell);
                }
                row.Cells.AddRange(columns.ToArray());
            }
        }

        protected void grd_op_SelectedIndexChanged(object sender, EventArgs e)
        {
            bnt_cancel.Focus();
            int int_jobno = int.Parse(grd_op.SelectedRow.Cells[1].Text.ToString());
            string str_trantype = "";
            str_trantype = grd_op.SelectedDataKey.Values[0].ToString();
            Session["jobno"] = int_jobno;
            string url = "/ForwardExports/CostingDetails.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=1000,height=400,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        }

        protected void Grd_trendcustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                for (int h = 1; h < e.Row.Cells.Count; h++)
                {
                    string[] str_header = e.Row.Cells[h].Text.ToString().Split('-');
                    if (str_header.Length > 0)
                    {
                        e.Row.Cells[h].Text = str_header[0].ToString();
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int h = 1; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "&nbsp;")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
            }
        }

        [WebMethod]

        public static List<string> GetCustomers(string prefix, string FType)
        {
            List<string> customers = new List<string>();
            DataTable obj_dt = new DataTable();

            if (FType == "Name")
            {
                DataAccess.Masters.MasterEmployee da_obj_Employee = new DataAccess.Masters.MasterEmployee();
                obj_dt = da_obj_Employee.GetLikeEmployee(prefix.ToUpper());
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_DatatableToList(obj_dt, "empname", "employeeid");
            }
            else if (FType == "Port")
            {
                DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                obj_dt = da_obj_Port.GetLikePort(prefix.ToUpper());
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_DatatableToList(obj_dt, "portname", "portid");
            }
            else if (FType == "Customer")
            {
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), "C");
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            }
            else if (FType == "Agent")
            {
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), "P");
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            }
            else if (FType == "Liner")
            {
                DataAccess.MIS Misobj = new DataAccess.MIS();
                obj_dt = Misobj.GetLinerWiseLike(prefix.ToUpper());
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_TableToList(obj_dt, "customer", "linerid");
            }
            return customers;
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 105, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "FI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 106, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 107, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 108, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "CH":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 109, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AC":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 262, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
            }
            //ExportToExcelNew();
            if (ddl_Report.SelectedItem.Text == "M I S")
            {
                excel();
            }
            else
            {
               // ExportToExcel();

                ExportToExcelnew();
            }
            
        }
        private void excel()
        {
            string Str_Title;
            Str_Title = Session["LoginDivisionName"].ToString() + "-" + Session["LoginBranchName"].ToString();
            string Str_SelectedText = "MIS";

            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            if (Grd_MISA.Rows.Count > 0)
            {

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + Str_SelectedText + ".xls");
                Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                int cnt = Grd_MISA.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Str_SelectedText + "</B></font></td></tr>");
                SB.Append("</table>");
                Grd_MISA.GridLines = GridLines.Both;
                Grd_MISA.HeaderStyle.Font.Bold = true;
                Grd_MISA.RenderControl(HtmlTextWriter);
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + Str_SelectedText + ".xls");
                Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                cnt = Grd_MISB.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Str_SelectedText + "</B></font></td></tr>");
                SB.Append("</table>");
                Grd_MISB.GridLines = GridLines.Both;
                Grd_MISB.HeaderStyle.Font.Bold = true;
                Grd_MISB.RenderControl(HtmlTextWriter);
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + Str_SelectedText + ".xls");
                Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                cnt = Grd_MISC.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Str_SelectedText + "</B></font></td></tr>");
                SB.Append("</table>");
                Grd_MISC.GridLines = GridLines.Both;
                Grd_MISC.HeaderStyle.Font.Bold = true;
                Grd_MISC.RenderControl(HtmlTextWriter);
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + Str_SelectedText + ".xls");
                Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                cnt = Grd_MISD.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Str_SelectedText + "</B></font></td></tr>");
                SB.Append("</table>");
                Grd_MISD.GridLines = GridLines.Both;
                Grd_MISD.HeaderStyle.Font.Bold = true;
                Grd_MISD.RenderControl(HtmlTextWriter);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();

            }

        } 
        /*private void ExportToExcel()
        {
            int did = Convert.ToInt32(Session["LoginDivisionid"].ToString());
            string excel_name = ddl_Report.Text;
            excel_name = excel_name.Replace("/", "or").Replace("-", "for");
            DataTable dt_check = new DataTable("Excel");
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=" + ddl_Report.Text + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            //StringWriter StringWriter = new System.IO.StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            int cnt = 0;
            DataTable dt = new DataTable();
            str_TranType = Session["StrTranType"].ToString();
            if (grd_Shipment.Visible == true)
            {
                costtempobj.DelCostingTemp(Convert.ToInt32(Session["LoginEmpId"]));
                if (str_TranType == "FI" || str_TranType == "FE" || str_TranType == "AE" || str_TranType == "AI" || str_TranType == "CH" || str_TranType == "AC")
                {
                    if (ddl_Report.SelectedItem.Text == "Shipment Details")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        Gridtemp.DataSource = dt;
                        Gridtemp.DataBind();


                        foreach (TableCell cell in Gridtemp.HeaderRow.Cells)
                        {
                            dt_check.Columns.Add(cell.Text);
                        }
                        foreach (GridViewRow row in Gridtemp.Rows)
                        {
                            dt_check.Rows.Add();
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                if (row.Cells[i].Text == "")
                                {
                                    if (i == 0)
                                    {
                                        Label agent = row.Cells[i].FindControl("Agent") as Label;
                                        row.Cells[i].Text = agent.Text;
                                    }

                                }
                                dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                            }
                        }
                        //cnt = dt.Columns.Count;
                        //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        //SB.Append("</table>");
                        //Gridtemp.GridLines = GridLines.Both;
                        //Gridtemp.HeaderStyle.Font.Bold = true;
                        //Gridtemp.RenderControl(HtmlTextWriter);
                    }
                }
            }
            else
                if (grd_Agent.Visible == true)
                {
                    ////grd_Agent.Columns[7].Visible = false;
                    //cnt = grd_Agent.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_Agent.GridLines = GridLines.Both;
                    //grd_Agent.HeaderStyle.Font.Bold = true;
                    //grd_Agent.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_Agent.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_Agent.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Text == "")
                            {
                                if (i == 0)
                                {
                                    Label agent = row.Cells[i].FindControl("Agent") as Label;
                                    row.Cells[i].Text = agent.Text;
                                }

                            }


                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_Consignee.Visible == true)
                {
                    ////grd_Consignee.Columns[7].Visible = false;
                    //cnt = grd_Consignee.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_Consignee.GridLines = GridLines.Both;
                    //grd_Consignee.HeaderStyle.Font.Bold = true;
                    //grd_Consignee.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_Consignee.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_Consignee.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Text == "")
                            {
                                if (i == 0)
                                {
                                    Label agent = row.Cells[i].FindControl("Consignee") as Label;
                                    row.Cells[i].Text = agent.Text;
                                }
                            }
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Grd_nomination.Visible == true)
                {
                    ////Grd_nomination.Columns[9].Visible = false;
                    //cnt = Grd_nomination.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //Grd_nomination.GridLines = GridLines.Both;
                    //Grd_nomination.HeaderStyle.Font.Bold = true;
                    //Grd_nomination.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_nomination.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_nomination.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                    //foreach (var item in collection)
                    //{

                    //}

                }
                else if (Grd_freeVsnomi.Visible == true)
                {
                    ////Grd_freeVsnomi.Columns[8].Visible = false;
                    //cnt = Grd_freeVsnomi.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //Grd_freeVsnomi.GridLines = GridLines.Both;
                    //Grd_freeVsnomi.HeaderStyle.Font.Bold = true;
                    //Grd_freeVsnomi.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_freeVsnomi.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_freeVsnomi.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_JobwiseCosting.Visible == true)
                {


                    //grd_JobwiseCosting.Columns[9].Visible = false;
                    //cnt = grd_JobwiseCosting.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    ////grd_JobwiseCosting.Columns[10].Visible = false;
                    //grd_JobwiseCosting.GridLines = GridLines.Both;
                    //grd_JobwiseCosting.HeaderStyle.Font.Bold = true;
                    //grd_JobwiseCosting.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_JobwiseCosting.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_JobwiseCosting.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Text == "")
                            {
                                if (i == 5)
                                {
                                    Label agent = row.Cells[i].FindControl("agent1") as Label;
                                    row.Cells[i].Text = agent.Text;
                                }
                            }
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_lossjob.Visible == true)
                {
                    ////grd_lossjob.Columns[7].Visible = false;
                    //cnt = grd_lossjob.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_lossjob.GridLines = GridLines.Both;
                    //grd_lossjob.HeaderStyle.Font.Bold = true;
                    //grd_lossjob.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_lossjob.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_lossjob.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_POD.Visible == true)
                {
                    ////grd_POD.Columns[7].Visible = false;
                    //cnt = grd_POD.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + "Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_POD.GridLines = GridLines.Both;
                    //grd_POD.HeaderStyle.Font.Bold = true;
                    //grd_POD.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_POD.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_POD.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_POL.Visible == true)
                {
                    ////grd_POL.Columns[7].Visible = false;
                    //cnt = grd_POL.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_POL.GridLines = GridLines.Both;
                    //grd_POL.HeaderStyle.Font.Bold = true;
                    //grd_POL.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_POL.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_POL.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_operProfit.Visible == true)
                {
                    ////grd_operProfit.Columns[2].Visible = false;
                    //cnt = grd_operProfit.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");

                    //grd_operProfit.GridLines = GridLines.Both;
                    //grd_operProfit.HeaderStyle.Font.Bold = true;
                    //grd_operProfit.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_operProfit.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_operProfit.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }

                else if (grd_salesperson.Visible == true)
                {
                    ////grd_salesperson.Columns[7].Visible = false;
                    //cnt = grd_salesperson.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_salesperson.GridLines = GridLines.Both;
                    //grd_salesperson.HeaderStyle.Font.Bold = true;
                    //grd_salesperson.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_salesperson.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_salesperson.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Grd_shiperconsignee.Visible == true)
                {
                    //cnt = Grd_shiperconsignee.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    ////Grd_shiperconsignee.Columns[2].Visible = false;
                    //Grd_shiperconsignee.GridLines = GridLines.Both;
                    //Grd_shiperconsignee.HeaderStyle.Font.Bold = true;
                    //Grd_shiperconsignee.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_shiperconsignee.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_shiperconsignee.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_Shipper.Visible == true)
                {
                    ////grd_Shipper.Columns[7].Visible = false;
                    //cnt = grd_Shipper.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_Shipper.GridLines = GridLines.Both;
                    //grd_Shipper.HeaderStyle.Font.Bold = true;
                    //grd_Shipper.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_Shipper.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_Shipper.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Text == "")
                            {
                                if (i == 0)
                                {
                                    Label agent = row.Cells[i].FindControl("Shipper") as Label;
                                    row.Cells[i].Text = agent.Text;
                                }
                            }
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Grd_trendcustomervolume.Visible == true)
                {
                    //cnt = Grd_trendcustomervolume.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //Grd_trendcustomervolume.GridLines = GridLines.Both;
                    //Grd_trendcustomervolume.HeaderStyle.Font.Bold = true;
                    //Grd_trendcustomervolume.RenderControl(HtmlTextWriter);
                    if(ViewState["GrdVolume"] !=null)
                    {
                        dt_check = ViewState["GrdVolume"] as DataTable;
                        dt_check.Rows[0].Delete();
                        //for (j = 3; j <= dt_check.Columns.Count - 1; j += 3)
                        //{

                        //    dt_check.Rows[0][j] = "CBM";
                        //    dt_check.Rows[0][j+1] = "Tues";
                        //    dt_check.Rows[0][j+2] = "Revenue";
                        //}
                    }else
                    {
                        return;
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        //wb.Worksheets.Add("test");

                        wb.Worksheets.Add(dt_check);

                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=" + ddl_Report.Text + ".xls");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
                else if (Grd_trendcustomer.Visible == true)
                {
                    //cnt = Grd_trendcustomer.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //Grd_trendcustomer.GridLines = GridLines.Both;
                    //Grd_trendcustomer.HeaderStyle.Font.Bold = true;
                    //Grd_trendcustomer.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_trendcustomer.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_trendcustomer.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Gridliner.Visible == true)
                {

                    //cnt = Gridliner.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //Gridliner.GridLines = GridLines.Both;
                    //Gridliner.HeaderStyle.Font.Bold = true;
                    //Gridliner.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Gridliner.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Gridliner.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }

                }
                else if (Grd_Retention.Visible == true)
                {


                    //cnt = 11;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + cnt + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + " , " + Session["LoginBranchName"].ToString() + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Retention for N/F for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //Grd_Retention.GridLines = GridLines.Both;
                    //Grd_Retention.HeaderStyle.Font.Bold = true;
                    //Grd_Retention.RenderControl(HtmlTextWriter);

                    ////  Retention_Export();
                    ////  return;
                    foreach (TableCell cell in Grd_Retention.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_Retention.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (ddl_Report.Text == "CAN Report")
                {

                    fn_CANREPORT();

                    GRD_CANREPORT.Visible = true;
                    //cnt = GRD_CANREPORT.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>CAN Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //GRD_CANREPORT.GridLines = GridLines.Both;
                    //GRD_CANREPORT.HeaderStyle.Font.Bold = true;
                    //GRD_CANREPORT.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_CANREPORT.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_CANREPORT.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }

                }
                else if (ddl_Report.Text == "CAN Report AI")
                {

                    fn_CANREPORTAI();
                    GRD_canreportAI.Visible = true;
                    //GRD_canreportAI.GridLines = GridLines.Both;
                    //GRD_canreportAI.HeaderStyle.Font.Bold = true;
                    //GRD_canreportAI.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_canreportAI.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_canreportAI.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }

                }
                else if (ddl_Report.Text == "DO Register Report")
                {

                    fn_REGISTERREPORT();
                    GRD_RegisterReport.Visible = true;
                    //cnt = GRD_RegisterReport.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>RegisterReport Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //GRD_RegisterReport.GridLines = GridLines.Both;
                    //GRD_RegisterReport.HeaderStyle.Font.Bold = true;
                    //GRD_RegisterReport.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_RegisterReport.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_RegisterReport.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (GRD_DoRegister.Visible == true)
                {
                    //cnt = GRD_DoRegister.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>DoRegister Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //GRD_DoRegister.GridLines = GridLines.Both;
                    //GRD_DoRegister.HeaderStyle.Font.Bold = true;
                    //GRD_DoRegister.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_DoRegister.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_DoRegister.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (GRD_Revenue.Visible == true)
                {
                    //cnt = GRD_Revenue.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Revenue Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //GRD_Revenue.GridLines = GridLines.Both;
                    //GRD_Revenue.HeaderStyle.Font.Bold = true;
                    //GRD_Revenue.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_Revenue.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_Revenue.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (GRD_Forward.Visible == true)
                {
                    //cnt = GRD_Forward.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //GRD_Forward.GridLines = GridLines.Both;
                    //GRD_Forward.HeaderStyle.Font.Bold = true;
                    //GRD_Forward.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_Forward.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_Forward.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (GRD_Common.Visible == true)
                {
                    //cnt = GRD_Common.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //GRD_Common.GridLines = GridLines.Both;
                    //GRD_Common.HeaderStyle.Font.Bold = true;
                    //GRD_Common.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_Common.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_Common.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Grd_shiperconsigneeProduct.Visible == true)
                {
                    //cnt = Grd_shiperconsigneeProduct.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //Grd_shiperconsigneeProduct.GridLines = GridLines.Both;
                    //Grd_shiperconsigneeProduct.HeaderStyle.Font.Bold = true;
                    //Grd_shiperconsigneeProduct.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_shiperconsigneeProduct.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_shiperconsigneeProduct.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_operProfit_AC.Visible == true)
                {
                    //cnt = grd_operProfit_AC.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_operProfit_AC.GridLines = GridLines.Both;
                    //grd_operProfit_AC.HeaderStyle.Font.Bold = true;
                    //grd_operProfit_AC.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_operProfit_AC.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_operProfit_AC.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }

                else if (grd_operProfit.Visible == true)
                {
                    //cnt = grd_operProfit.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    //grd_operProfit.GridLines = GridLines.Both;
                    //grd_operProfit.HeaderStyle.Font.Bold = true;
                    //grd_operProfit.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_operProfit.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_operProfit.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }

            using (XLWorkbook wb = new XLWorkbook())
            {
                //wb.Worksheets.Add("test");

                wb.Worksheets.Add(dt_check);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + ddl_Report.Text + ".xls");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }


            //string style = @"<style> .textmode { } </style>";
            //Response.Write(style);
            //Response.Output.Write(StringWriter.ToString());
            //Response.Flush();
            //Response.End();
        }

        */

        private void ExportToExcelnew()
        {
            int did = Convert.ToInt32(Session["LoginDivisionid"].ToString());
            string excel_name = ddl_Report.Text;
            excel_name = excel_name.Replace("/", "or").Replace("-", "for");
            DataTable dt_check = new DataTable("Excel");
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + ddl_Report.Text + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            //StringWriter StringWriter = new System.IO.StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            int cnt = 0;
            DataTable dt = new DataTable();
            str_TranType = Session["StrTranType"].ToString();
            if (grd_Shipment.Visible == true)
            {
                costtempobj.DelCostingTemp(Convert.ToInt32(Session["LoginEmpId"]));
                if (str_TranType == "FI" || str_TranType == "FE" || str_TranType == "AE" || str_TranType == "AI" || str_TranType == "CH" || str_TranType == "AC")
                {
                    if (ddl_Report.SelectedItem.Text == "Shipment Details")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        Gridtemp.DataSource = dt;
                        Gridtemp.DataBind();


                        foreach (TableCell cell in Gridtemp.HeaderRow.Cells)
                        {
                            dt_check.Columns.Add(cell.Text);
                        }
                        foreach (GridViewRow row in Gridtemp.Rows)
                        {
                            dt_check.Rows.Add();
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                if (row.Cells[i].Text == "")
                                {
                                    if (i == 0)
                                    {
                                        Label agent = row.Cells[i].FindControl("Agent") as Label;
                                        row.Cells[i].Text = agent.Text;
                                    }

                                }
                                dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                            }
                        }
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }
                }
            }
            else
                if (grd_Agent.Visible == true)
                {
                    //grd_Agent.Columns[7].Visible = false;
                    cnt = grd_Agent.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_Agent.GridLines = GridLines.Both;
                    grd_Agent.HeaderStyle.Font.Bold = true;
                    grd_Agent.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_Agent.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_Agent.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Text == "")
                            {
                                if (i == 0)
                                {
                                    Label agent = row.Cells[i].FindControl("Agent") as Label;
                                    row.Cells[i].Text = agent.Text;
                                }

                            }


                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_Consignee.Visible == true)
                {
                    //grd_Consignee.Columns[7].Visible = false;
                    cnt = grd_Consignee.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_Consignee.GridLines = GridLines.Both;
                    grd_Consignee.HeaderStyle.Font.Bold = true;
                    grd_Consignee.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_Consignee.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_Consignee.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Text == "")
                            {
                                if (i == 0)
                                {
                                    Label agent = row.Cells[i].FindControl("Consignee") as Label;
                                    row.Cells[i].Text = agent.Text;
                                }
                            }
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Grd_nomination.Visible == true)
                {
                    //Grd_nomination.Columns[9].Visible = false;
                    cnt = Grd_nomination.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    Grd_nomination.GridLines = GridLines.Both;
                    Grd_nomination.HeaderStyle.Font.Bold = true;
                    Grd_nomination.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_nomination.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_nomination.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                    //foreach (var item in collection)
                    //{

                    //}

                }
                else if (Grd_freeVsnomi.Visible == true)
                {
                    //Grd_freeVsnomi.Columns[8].Visible = false;
                    cnt = Grd_freeVsnomi.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    Grd_freeVsnomi.GridLines = GridLines.Both;
                    Grd_freeVsnomi.HeaderStyle.Font.Bold = true;
                    Grd_freeVsnomi.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_freeVsnomi.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_freeVsnomi.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_JobwiseCosting.Visible == true)
                {


                    grd_JobwiseCosting.Columns[9].Visible = false;
                    cnt = grd_JobwiseCosting.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //grd_JobwiseCosting.Columns[10].Visible = false;
                    grd_JobwiseCosting.GridLines = GridLines.Both;
                    grd_JobwiseCosting.HeaderStyle.Font.Bold = true;
                    grd_JobwiseCosting.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_JobwiseCosting.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_JobwiseCosting.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Text == "")
                            {
                                if (i == 5)
                                {
                                    Label agent = row.Cells[i].FindControl("agent1") as Label;
                                    row.Cells[i].Text = agent.Text;
                                }
                            }
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_lossjob.Visible == true)
                {
                    //grd_lossjob.Columns[7].Visible = false;
                    cnt = grd_lossjob.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_lossjob.GridLines = GridLines.Both;
                    grd_lossjob.HeaderStyle.Font.Bold = true;
                    grd_lossjob.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_lossjob.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_lossjob.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_POD.Visible == true)
                {
                    //grd_POD.Columns[7].Visible = false;
                    cnt = grd_POD.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + "Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_POD.GridLines = GridLines.Both;
                    grd_POD.HeaderStyle.Font.Bold = true;
                    grd_POD.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_POD.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_POD.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_POL.Visible == true)
                {
                    //grd_POL.Columns[7].Visible = false;
                    cnt = grd_POL.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_POL.GridLines = GridLines.Both;
                    grd_POL.HeaderStyle.Font.Bold = true;
                    grd_POL.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_POL.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_POL.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_operProfit.Visible == true)
                {
                    //grd_operProfit.Columns[2].Visible = false;
                    cnt = grd_operProfit.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                    grd_operProfit.GridLines = GridLines.Both;
                    grd_operProfit.HeaderStyle.Font.Bold = true;
                    grd_operProfit.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_operProfit.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_operProfit.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }

                else if (grd_salesperson.Visible == true)
                {
                    //grd_salesperson.Columns[7].Visible = false;
                    cnt = grd_salesperson.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_salesperson.GridLines = GridLines.Both;
                    grd_salesperson.HeaderStyle.Font.Bold = true;
                    grd_salesperson.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_salesperson.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_salesperson.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Grd_shiperconsignee.Visible == true)
                {
                    cnt = Grd_shiperconsignee.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //Grd_shiperconsignee.Columns[2].Visible = false;
                    Grd_shiperconsignee.GridLines = GridLines.Both;
                    Grd_shiperconsignee.HeaderStyle.Font.Bold = true;
                    Grd_shiperconsignee.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_shiperconsignee.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_shiperconsignee.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_Shipper.Visible == true)
                {
                    //grd_Shipper.Columns[7].Visible = false;
                    cnt = grd_Shipper.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_Shipper.GridLines = GridLines.Both;
                    grd_Shipper.HeaderStyle.Font.Bold = true;
                    grd_Shipper.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_Shipper.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_Shipper.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Text == "")
                            {
                                if (i == 0)
                                {
                                    Label agent = row.Cells[i].FindControl("Shipper") as Label;
                                    row.Cells[i].Text = agent.Text;
                                }
                            }
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Grd_trendcustomervolume.Visible == true)
                {
                    cnt = Grd_trendcustomervolume.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    Grd_trendcustomervolume.GridLines = GridLines.Both;
                    Grd_trendcustomervolume.HeaderStyle.Font.Bold = true;
                    Grd_trendcustomervolume.RenderControl(HtmlTextWriter);
                    if (ViewState["GrdVolume"] != null)
                    {
                        dt_check = ViewState["GrdVolume"] as DataTable;
                        dt_check.Rows[0].Delete();
                        //for (j = 3; j <= dt_check.Columns.Count - 1; j += 3)
                        //{

                        //    dt_check.Rows[0][j] = "CBM";
                        //    dt_check.Rows[0][j + 1] = "Tues";
                        //    dt_check.Rows[0][j + 2] = "Revenue";
                        //}
                    }
                    else
                    {
                        return;
                    }
                    //using (XLWorkbook wb = new XLWorkbook())
                    //{
                    //    //wb.Worksheets.Add("test");

                    //    wb.Worksheets.Add(dt_check);

                    //    Response.Clear();
                    //    Response.Buffer = true;
                    //    Response.Charset = "";
                    //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    //    Response.AddHeader("content-disposition", "attachment;filename=" + ddl_Report.Text + ".xls");
                    //    using (MemoryStream MyMemoryStream = new MemoryStream())
                    //    {
                    //        wb.SaveAs(MyMemoryStream);
                    //        MyMemoryStream.WriteTo(Response.OutputStream);
                    //        Response.Flush();
                    //        Response.End();
                    //    }
                    //}
                }
                else if (Grd_trendcustomer.Visible == true)
                {
                    cnt = Grd_trendcustomer.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    Grd_trendcustomer.GridLines = GridLines.Both;
                    Grd_trendcustomer.HeaderStyle.Font.Bold = true;
                    Grd_trendcustomer.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_trendcustomer.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_trendcustomer.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Gridliner.Visible == true)
                {

                    cnt = Gridliner.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    Gridliner.GridLines = GridLines.Both;
                    Gridliner.HeaderStyle.Font.Bold = true;
                    Gridliner.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Gridliner.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Gridliner.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }

                }
                else if (Grd_Retention.Visible == true)
                {


                    cnt = 11;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + cnt + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + " , " + Session["LoginBranchName"].ToString() + "</B></font></td></tr>");
                    SB.Append("</table>");
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Retention for N/F for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    Grd_Retention.GridLines = GridLines.Both;
                    Grd_Retention.HeaderStyle.Font.Bold = true;
                    Grd_Retention.RenderControl(HtmlTextWriter);

                    //  Retention_Export();
                    //  return;
                    foreach (TableCell cell in Grd_Retention.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_Retention.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (ddl_Report.Text == "CAN Report")
                {

                    fn_CANREPORT();
                    if (blr == true)
                    {
                        return;
                    }
                    GRD_CANREPORT.Visible = true;
                    cnt = GRD_CANREPORT.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>CAN Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    GRD_CANREPORT.GridLines = GridLines.Both;
                    GRD_CANREPORT.HeaderStyle.Font.Bold = true;
                    GRD_CANREPORT.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_CANREPORT.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_CANREPORT.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }

                }
                else if (ddl_Report.Text == "CAN Report AI")
                {

                    fn_CANREPORTAI();
                    if (blr == true)
                    {
                        return;
                    }
                    GRD_canreportAI.Visible = true;
                    GRD_canreportAI.GridLines = GridLines.Both;
                    GRD_canreportAI.HeaderStyle.Font.Bold = true;
                    GRD_canreportAI.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_canreportAI.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_canreportAI.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }

                }
                else if (ddl_Report.Text == "DO Register Report")
                {

                    fn_REGISTERREPORT();
                    if (blr == true)
                    {
                        return;
                    }
                    GRD_RegisterReport.Visible = true;
                    cnt = GRD_RegisterReport.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>RegisterReport Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    GRD_RegisterReport.GridLines = GridLines.Both;
                    GRD_RegisterReport.HeaderStyle.Font.Bold = true;
                    GRD_RegisterReport.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_RegisterReport.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_RegisterReport.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (GRD_DoRegister.Visible == true)
                {
                    cnt = GRD_DoRegister.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>DoRegister Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    GRD_DoRegister.GridLines = GridLines.Both;
                    GRD_DoRegister.HeaderStyle.Font.Bold = true;
                    GRD_DoRegister.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_DoRegister.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_DoRegister.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (GRD_Revenue.Visible == true)
                {
                    cnt = GRD_Revenue.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Revenue Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    GRD_Revenue.GridLines = GridLines.Both;
                    GRD_Revenue.HeaderStyle.Font.Bold = true;
                    GRD_Revenue.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_Revenue.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_Revenue.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (GRD_Forward.Visible == true)
                {
                    cnt = GRD_Forward.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    GRD_Forward.GridLines = GridLines.Both;
                    GRD_Forward.HeaderStyle.Font.Bold = true;
                    GRD_Forward.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_Forward.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_Forward.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (GRD_Common.Visible == true)
                {
                    cnt = GRD_Common.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    GRD_Common.GridLines = GridLines.Both;
                    GRD_Common.HeaderStyle.Font.Bold = true;
                    GRD_Common.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in GRD_Common.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in GRD_Common.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (Grd_shiperconsigneeProduct.Visible == true)
                {
                    cnt = Grd_shiperconsigneeProduct.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    Grd_shiperconsigneeProduct.GridLines = GridLines.Both;
                    Grd_shiperconsigneeProduct.HeaderStyle.Font.Bold = true;
                    Grd_shiperconsigneeProduct.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_shiperconsigneeProduct.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_shiperconsigneeProduct.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }
                else if (grd_operProfit_AC.Visible == true)
                {
                    cnt = grd_operProfit_AC.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_operProfit_AC.GridLines = GridLines.Both;
                    grd_operProfit_AC.HeaderStyle.Font.Bold = true;
                    grd_operProfit_AC.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_operProfit_AC.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_operProfit_AC.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }

                else if (grd_operProfit.Visible == true)
                {
                    cnt = grd_operProfit.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_operProfit.GridLines = GridLines.Both;
                    grd_operProfit.HeaderStyle.Font.Bold = true;
                    grd_operProfit.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in grd_operProfit.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in grd_operProfit.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }
                }

            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    //wb.Worksheets.Add("test");

            //    wb.Worksheets.Add(dt_check);

            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.AddHeader("content-disposition", "attachment;filename=" + ddl_Report.Text + ".xls");
            //    using (MemoryStream MyMemoryStream = new MemoryStream())
            //    {
            //        wb.SaveAs(MyMemoryStream);
            //        MyMemoryStream.WriteTo(Response.OutputStream);
            //        Response.Flush();
            //        Response.End();
            //    }
            //}


            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(StringWriter.ToString());
            Response.Flush();
            Response.End();
        }




        private void ExportToExcelNewbkp()
        {
            grdexcel.DataSource = null;
            grdexcel.DataBind();

            int cnt = 0;
            DataTable dt = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=ExportData1.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            if (txt_Filter.Text == "")
            {
                dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                grdexcel.DataSource = dt;
                grdexcel.DataBind();
                cnt = dt.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                SB.Append("</table>");
            }
            else
            {
                dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", hf_agent.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                grdexcel.DataSource = dt;
                grdexcel.DataBind();
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                SB.Append("</table>");
            }
            if (grdexcel.Visible == true)
            {
                grdexcel.GridLines = GridLines.Both;
                grdexcel.HeaderStyle.Font.Bold = true;
                grdexcel.RenderControl(HtmlTextWriter);
            }
            Response.Write(StringWriter.ToString());
            Response.End();
        }
        //prabha
        //fn for export excel
        private void ExportToExcelNew()
        {
            grdexcel.DataSource = null;
            grdexcel.DataBind();

            int cnt = 0;
            bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            string STR = "";
            string sp;
            str_TranType = Session["StrTranType"].ToString();
            DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
            DataTable dt = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=ExportData1.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            if (STR == "")
            {
                STR = str_TranType;
            }
            if (str_TranType == "FI" || str_TranType == "FE" || str_TranType == "AE" || str_TranType == "AI")
            {
                if (ddl_Report.SelectedItem.Text == "Shipment Details")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Shipment Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.SelectedItem.Text == "LinerWise")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDtsLinerTemp((Convert.ToInt32(Session["LoginBranchid"])), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), "0", Convert.ToInt32(Session["LoginDivisionid"]));// costtempobj.SelExcelShipmentFCostingDtsLinerTemp(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "liner", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Liner Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Liner Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                }
                //else if (ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
                //{
                //    DataSet ds;
                //    DataTable dt1 = new DataTable();

                //    dt1.Columns.Add("Customer");
                //    dt1.Columns.Add("Retention");
                //    dt1 = costtempobj.SelTop50ShipperConsignee4BranchTantype(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                //    grdexcel.DataSource = dt1;
                //    grdexcel.DataBind();
                //    cnt = dt1.Columns.Count;
                //    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Top 50 Shipper / Consignee for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                //    SB.Append("</table>");
                //}

                else if (ddl_Report.Text == "Top 50 Shipper / Consignee")
                {
                    //dinesh
                    //DataTable _datatable = new DataTable();
                    //for (int i = 0; i < Grd_shiperconsigneeProduct.Columns.Count; i++)
                    //{
                    //    _datatable.Columns.Add(Grd_shiperconsigneeProduct.Columns[i].ToString());
                    //}
                    //foreach (GridViewRow row in Grd_shiperconsigneeProduct.Rows)
                    //{
                    //    DataRow dr = _datatable.NewRow();
                    //    for (int j = 0; j < Grd_shiperconsigneeProduct.Columns.Count; j++)
                    //    {
                    //        if (!row.Cells[j].Text.Equals("&nbsp;") || !row.Cells[j].Text.Equals("&amp;"))
                    //            dr[Grd_shiperconsigneeProduct.Columns[j].ToString()] = row.Cells[j].Text;
                    //    }

                    //    _datatable.Rows.Add(dr);
                    //}



                    grdexcel.DataSource = (DataTable)ViewState["Grd_shiperconsigneeProduct"];
                    grdexcel.DataBind();

                    /* DataSet ds = new DataSet();
                    DataTable Dt1 = new DataTable();
                    DataTable Dt2 = new DataTable();
                    Dt1.Columns.Add("Shipper");
                    Dt1.Columns.Add("Retention4Shipper");
                    Dt1.Columns.Add("Consignee");
                    Dt1.Columns.Add("Retention4Consignee");
                    //for (int i = 0; i <= 4; i++)
                    //{
                        ds = costtempobj.SelTop50ShipperConsignee4Branch(Convert.ToInt32(Session["LoginEmpId"]), bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                        dt = ds.Tables[0];
                        Dt2 = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {
                            int n;
                            n = Dt1.Rows.Count;
                            for (j = 0; j <= dt.Rows.Count - 1; j++)
                            {
                                if (j == 0)
                                {
                                    Dt1.Rows.Add();
                                    if (i == 1)
                                    {
                                        Dt1.Rows[n][0] = "";
                                    }
                                    else if (i == 2)
                                    {
                                        Dt1.Rows[n][0] = "";
                                    }
                                    else if (i == 3)
                                    {
                                        Dt1.Rows[n][0] = "";
                                    }
                                    else
                                    {
                                        Dt1.Rows[n][0] = "";
                                    }
                                    Dt1.Rows[n][1] = "";
                                    Dt1.Rows[n][2] = "";
                                    Dt1.Rows[n][3] = "";
                                    n = n + 1;
                                    Dt1.Rows.Add();
                                    Dt1.Rows[n][0] = dt.Rows[j][0].ToString();
                                    Dt1.Rows[n][1] = dt.Rows[j][1].ToString();
                                    if (Dt2.Rows.Count > j)
                                    {
                                        Dt1.Rows[n][0] = dt.Rows[j][2].ToString();
                                        Dt1.Rows[n][1] = dt.Rows[j][3].ToString();
                                    }
                                    else
                                    {
                                        Dt1.Rows[n][0] = "";
                                        Dt1.Rows[n][1] = "";
                                    }
                                    n = n + 1;
                                }
                                else
                                {
                                    Dt1.Rows.Add();
                                    Dt1.Rows[n][0] = dt.Rows[j][0].ToString();
                                    Dt1.Rows[n][1] = dt.Rows[j][1].ToString();
                                    if (Dt2.Rows.Count > j)
                                    {
                                        Dt1.Rows[n][2] = dt.Rows[j][0].ToString();
                                        Dt1.Rows[n][3] = dt.Rows[j][1].ToString();
                                    }
                                    else
                                    {
                                        Dt1.Rows[n][2] = "";
                                        Dt1.Rows[n][3] = "";
                                    }
                                    n = n + 1;
                                }
                            }
                        }
                    }
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();*/


                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Top 50 Shipper / Consignee Details for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Top 50 Shipper / Consignee Details for the period from   " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.Text == "Trend Analysis - Customer With Volume")
                {
                    //DataTable _datatable = new DataTable();
                    //for (int i = 0; i < Grd_trendcustomervolume.Columns.Count; i++)
                    //{
                    //    _datatable.Columns.Add(Grd_trendcustomervolume.Columns[i].ToString());
                    //}
                    //foreach (GridViewRow row in Grd_trendcustomervolume.Rows)
                    //{
                    //    DataRow dr = _datatable.NewRow();
                    //    for (int j = 0; j < Grd_trendcustomervolume.Columns.Count; j++)
                    //    {
                    //        if (!row.Cells[j].Text.Equals("&nbsp;") || !row.Cells[j].Text.Equals("&amp;"))
                    //            dr[Grd_trendcustomervolume.Columns[j].ToString()] = row.Cells[j].Text;
                    //    }

                    //    _datatable.Rows.Add(dr);
                    //}

                    grdexcel.DataSource = (DataTable)ViewState["GrdVolume"];
                    grdexcel.DataBind();

                    //grdexcel.DataSource = (DataTable)ViewState["Grdvoulme"];
                    //grdexcel.DataBind();

                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Trend Analysis - Customer With Volume for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                }
                else if (ddl_Report.Text == "Trend Analysis - Sales Person")
                {
                    DataTable _datatable = new DataTable();
                    for (int i = 0; i < Grd_trendcustomer.Columns.Count; i++)
                    {
                        _datatable.Columns.Add(Grd_trendcustomer.Columns[i].ToString());
                    }
                    foreach (GridViewRow row in Grd_trendcustomer.Rows)
                    {
                        DataRow dr = _datatable.NewRow();
                        for (int j = 0; j < Grd_trendcustomer.Columns.Count; j++)
                        {
                            if (!row.Cells[j].Text.Equals("&nbsp;") && !row.Cells[j].Text.Equals("&amp;"))
                                dr[Grd_trendcustomer.Columns[j].ToString()] = row.Cells[j].Text;
                        }

                        _datatable.Rows.Add(dr);
                    }



                    grdexcel.DataSource = _datatable;
                    grdexcel.DataBind();

                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Trend Analysis - Sales Person for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                }

                else if (ddl_Report.Text == "Trend Analysis - Product")
                {
                    DataTable _datatable = new DataTable();
                    for (int i = 0; i < Grd_trendcustomer.Columns.Count; i++)
                    {
                        _datatable.Columns.Add(Grd_trendcustomer.Columns[i].ToString());
                    }
                    foreach (GridViewRow row in Grd_trendcustomer.Rows)
                    {
                        DataRow dr = _datatable.NewRow();
                        for (int j = 0; j < Grd_trendcustomer.Columns.Count; j++)
                        {
                            if (!row.Cells[j].Text.Equals("&nbsp;") && !row.Cells[j].Text.Equals("&amp;"))
                                dr[Grd_trendcustomer.Columns[j].ToString()] = row.Cells[j].Text;
                        }

                        _datatable.Rows.Add(dr);
                    }



                    grdexcel.DataSource = _datatable;
                    grdexcel.DataBind();

                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Trend Analysis - Product for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                }

                else if (ddl_Report.Text == "Trend Analysis - Customer With Product")
                {
                    DataTable _datatable = new DataTable();
                    for (int i = 0; i < Grd_trendcustomer.Columns.Count; i++)
                    {
                        _datatable.Columns.Add(Grd_trendcustomer.Columns[i].ToString());
                    }
                    foreach (GridViewRow row in Grd_trendcustomer.Rows)
                    {
                        DataRow dr = _datatable.NewRow();
                        for (int j = 0; j < Grd_trendcustomer.Columns.Count; j++)
                        {
                            if (!row.Cells[j].Text.Equals("&nbsp;") && !row.Cells[j].Text.Equals("&amp;"))
                                dr[Grd_trendcustomer.Columns[j].ToString()] = row.Cells[j].Text;
                        }

                        _datatable.Rows.Add(dr);
                    }



                    grdexcel.DataSource = _datatable;
                    grdexcel.DataBind();

                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Trend Analysis - Customer With Product for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                }


                else if (ddl_Report.SelectedItem.Text == "Port Of Loading")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pol", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Port of Loadingwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Port of Loadingwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        int portname = Portobj.GetNPortid(txt_Filter.Text);
                        intport = portname.ToString();
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pol", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Port of Loadingwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Port of Loadingwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Port Of Discharge")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Port  of Destinationwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        // sp = "Port  of Destinationwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Port  of Destinationwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Port  of Destinationwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;

                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Shipperwise")
                {
                    if (txt_Filter.Text == "Shipperwise")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipperwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Shipperwise Shipment for the period of" + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipperwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Shipperwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;

                    }
                }
                else if (ddl_Report.SelectedItem.Text == "CAN Report AI")
                {
                    string Filename = "";
                    string strtemp = "";
                    dt = costtempobj.GetCanRegister4AuditAI(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>CAN Audit Report AI for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                    //sp = "CAN Audit Report AI for the period of " + txt_From.Text + " to " + txt_To.Text;
                    //if (Gridtemp.Rows.Count > 0)
                    //{
                    //    Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    //    strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                    //    Response.Clear();
                    //    Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                    //    Response.Buffer = true;
                    //    Response.Charset = "UTF-8";
                    //    Response.ContentType = "application/vnd.ms-excel";
                    //    Response.Write(strtemp);
                    //    Response.End();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                    //}
                }
                else if (ddl_Report.SelectedItem.Text == "CAN Report")
                {
                    string Filename = "";
                    string strtemp = "";
                    dt = costtempobj.GetCanRegister4Audit(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>CAN Audit Report for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                    //sp = "CAN Audit Report for the period of " + txt_From.Text + " to " + txt_To.Text;

                    //if (Gridtemp.Rows.Count > 0)
                    //{
                    //    Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    //    strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                    //    Response.Clear();
                    //    Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                    //    Response.Buffer = true;
                    //    Response.Charset = "UTF-8";
                    //    Response.ContentType = "application/vnd.ms-excel";
                    //    Response.Write(strtemp);
                    //    Response.End();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                    //}
                }
                else if (ddl_Report.SelectedItem.Text == "DO Register Report")
                {
                    string Filename = "";
                    string strtemp = "";
                    dt = costtempobj.GetDoRegister4Audit(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>DO Audit Report for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                    //sp = "DO Audit Report for the period of " + txt_From.Text + " to " + txt_To.Text;
                    //if (Gridtemp.Rows.Count > 0)
                    //{
                    //    Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    //    strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                    //    Response.Clear();
                    //    Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                    //    Response.Buffer = true;
                    //    Response.Charset = "UTF-8";
                    //    Response.ContentType = "application/vnd.ms-excel";
                    //    Response.Write(strtemp);
                    //    Response.End();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                    //}
                }
                else if (ddl_Report.SelectedItem.Text == "Consigneewise")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Consigneewise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Consigneewise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Consigneewise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Consigneewise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Agentwise")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Agentwise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Agentwise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Sales Person")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "salesperson", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "salesperson", Session["LoginEmpId"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Nomination")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "nomination", "N", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Nominationwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Nominationwise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    costtempobj.DelCostingTemp(Convert.ToInt32(Session["LoginEmpId"]));
                }
                else if (ddl_Report.Text == "FreeHand")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "nomination", "F", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Freehandwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Freehandwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                }

                else if (ddl_Report.Text == "Nomination Vs Freehand")
                {
                    //dt = costtempobj.GetRetentionperunitforbranch(bid, Convert.ToInt32(Session["LoginDivisionid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Session["StrTranType"].ToString());
                    //grdexcel.DataSource = dt;
                    //grdexcel.DataBind();
                    //cnt = dt.Columns.Count;
                    //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Nomination/Freehand wise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    //SB.Append("</table>");
                    ////sp = "Nomination/Freehand wise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;


                    //Grd_freeVsnomi.Columns[8].Visible = false;
                    DataTable dt_check = new DataTable();
                    cnt = Grd_freeVsnomi.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    Grd_freeVsnomi.GridLines = GridLines.Both;
                    Grd_freeVsnomi.HeaderStyle.Font.Bold = true;
                    Grd_freeVsnomi.RenderControl(HtmlTextWriter);
                    foreach (TableCell cell in Grd_freeVsnomi.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Grd_freeVsnomi.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }


                }
                else if (ddl_Report.Text == "Loss Jobs")
                {
                    dt = costtempobj.SelLossJobs(Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Loss Jobs Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Loss Jobs Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.SelectedItem.Text == "Retention for N / F")
                {
                    //pending
                    Retention_Export();


                }
            }

            else if (str_TranType == "AC")
            {
                // If cmbby.SelectedItem = "Shipment Details" Then
                //dt = costtempobj.SelExcelShipmentFCostingDts(Login.branchid, strtrantype, "shipment", "0", Format(dtfrom.Value, "Short Date"), Format(dtto.Value, "Short Date"), Login.divisionid)
                //TempGrd.grdmis.DataSource = dt
                //sp = "Shipment Details for the period of " & dtfrom.Text & " to " & dtto.Text
                if (ddl_Report.Text == "Shipment Details")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                }
                else if (ddl_Report.Text == "LinerWise")
                {
                   // dt = costtempobj.SelExcelShipmentFCostingDtsLiner(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "liner", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]), liner);
                    dt = costtempobj.SelExcelShipmentFCostingDtsLinerTemp((Convert.ToInt32(Session["LoginBranchid"])), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), "0", Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Liner Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Liner Details for the period of " & dtfrom.Text & " to " & dtto.Text
                }


                else if (ddl_Report.Text == "Top 50 Shipper / Consignee")
                {
                    //dinesh
                    DataTable _datatable = new DataTable();
                    for (int i = 0; i < Grd_shiperconsignee.Columns.Count; i++)
                    {
                        _datatable.Columns.Add(Grd_shiperconsignee.Columns[i].ToString());
                    }
                    foreach (GridViewRow row in Grd_shiperconsignee.Rows)
                    {
                        DataRow dr = _datatable.NewRow();
                        for (int j = 0; j < Grd_shiperconsignee.Columns.Count; j++)
                        {
                            if (!row.Cells[j].Text.Equals("&nbsp;") || !row.Cells[j].Text.Equals("&amp;"))
                                dr[Grd_shiperconsignee.Columns[j].ToString()] = row.Cells[j].Text;
                        }

                        _datatable.Rows.Add(dr);
                    }



                    grdexcel.DataSource = _datatable;
                    grdexcel.DataBind();

                    /* DataSet ds = new DataSet();
                    DataTable Dt1 = new DataTable();
                    DataTable Dt2 = new DataTable();
                    Dt1.Columns.Add("Shipper");
                    Dt1.Columns.Add("Retention4Shipper");
                    Dt1.Columns.Add("Consignee");
                    Dt1.Columns.Add("Retention4Consignee");
                    //for (int i = 0; i <= 4; i++)
                    //{
                        ds = costtempobj.SelTop50ShipperConsignee4Branch(Convert.ToInt32(Session["LoginEmpId"]), bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                        dt = ds.Tables[0];
                        Dt2 = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {
                            int n;
                            n = Dt1.Rows.Count;
                            for (j = 0; j <= dt.Rows.Count - 1; j++)
                            {
                                if (j == 0)
                                {
                                    Dt1.Rows.Add();
                                    if (i == 1)
                                    {
                                        Dt1.Rows[n][0] = "";
                                    }
                                    else if (i == 2)
                                    {
                                        Dt1.Rows[n][0] = "";
                                    }
                                    else if (i == 3)
                                    {
                                        Dt1.Rows[n][0] = "";
                                    }
                                    else
                                    {
                                        Dt1.Rows[n][0] = "";
                                    }
                                    Dt1.Rows[n][1] = "";
                                    Dt1.Rows[n][2] = "";
                                    Dt1.Rows[n][3] = "";
                                    n = n + 1;
                                    Dt1.Rows.Add();
                                    Dt1.Rows[n][0] = dt.Rows[j][0].ToString();
                                    Dt1.Rows[n][1] = dt.Rows[j][1].ToString();
                                    if (Dt2.Rows.Count > j)
                                    {
                                        Dt1.Rows[n][0] = dt.Rows[j][2].ToString();
                                        Dt1.Rows[n][1] = dt.Rows[j][3].ToString();
                                    }
                                    else
                                    {
                                        Dt1.Rows[n][0] = "";
                                        Dt1.Rows[n][1] = "";
                                    }
                                    n = n + 1;
                                }
                                else
                                {
                                    Dt1.Rows.Add();
                                    Dt1.Rows[n][0] = dt.Rows[j][0].ToString();
                                    Dt1.Rows[n][1] = dt.Rows[j][1].ToString();
                                    if (Dt2.Rows.Count > j)
                                    {
                                        Dt1.Rows[n][2] = dt.Rows[j][0].ToString();
                                        Dt1.Rows[n][3] = dt.Rows[j][1].ToString();
                                    }
                                    else
                                    {
                                        Dt1.Rows[n][2] = "";
                                        Dt1.Rows[n][3] = "";
                                    }
                                    n = n + 1;
                                }
                            }
                        }
                    }
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();*/


                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Top 50 Shipper / Consignee Details for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Top 50 Shipper / Consignee Details for the period from   " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.Text == "Trend Analysis - Customer With Volume")
                {
                    //DataTable _datatable = new DataTable();
                    //for (int i = 0; i < Grd_trendcustomervolume.Columns.Count; i++)
                    //{
                    //    _datatable.Columns.Add(Grd_trendcustomervolume.Columns[i].ToString());
                    //}
                    //foreach (GridViewRow row in Grd_trendcustomervolume.Rows)
                    //{
                    //    DataRow dr = _datatable.NewRow();
                    //    for (int j = 0; j < Grd_trendcustomervolume.Columns.Count; j++)
                    //    {
                    //        if (!row.Cells[j].Text.Equals("&nbsp;") || !row.Cells[j].Text.Equals("&amp;"))
                    //            dr[Grd_trendcustomervolume.Columns[j].ToString()] = row.Cells[j].Text;
                    //    }

                    //    _datatable.Rows.Add(dr);
                    //}

                    grdexcel.DataSource = (DataTable)ViewState["GrdVolume"];
                    grdexcel.DataBind();

                    //grdexcel.DataSource = (DataTable)ViewState["Grdvoulme"];
                    //grdexcel.DataBind();

                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Trend Analysis - Customer With Volume for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                }
                else if (ddl_Report.Text == "Trend Analysis - Sales Person")
                {
                    DataTable _datatable = new DataTable();
                    for (int i = 0; i < Grd_trendcustomer.Columns.Count; i++)
                    {
                        _datatable.Columns.Add(Grd_trendcustomer.Columns[i].ToString());
                    }
                    foreach (GridViewRow row in Grd_trendcustomer.Rows)
                    {
                        DataRow dr = _datatable.NewRow();
                        for (int j = 0; j < Grd_trendcustomer.Columns.Count; j++)
                        {
                            if (!row.Cells[j].Text.Equals("&nbsp;") && !row.Cells[j].Text.Equals("&amp;"))
                                dr[Grd_trendcustomer.Columns[j].ToString()] = row.Cells[j].Text;
                        }

                        _datatable.Rows.Add(dr);
                    }



                    grdexcel.DataSource = _datatable;
                    grdexcel.DataBind();

                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Trend Analysis - Sales Person for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                }

                else if (ddl_Report.Text == "Trend Analysis - Product")
                {
                    DataTable _datatable = new DataTable();
                    for (int i = 0; i < Grd_trendcustomer.Columns.Count; i++)
                    {
                        _datatable.Columns.Add(Grd_trendcustomer.Columns[i].ToString());
                    }
                    foreach (GridViewRow row in Grd_trendcustomer.Rows)
                    {
                        DataRow dr = _datatable.NewRow();
                        for (int j = 0; j < Grd_trendcustomer.Columns.Count; j++)
                        {
                            if (!row.Cells[j].Text.Equals("&nbsp;") && !row.Cells[j].Text.Equals("&amp;"))
                                dr[Grd_trendcustomer.Columns[j].ToString()] = row.Cells[j].Text;
                        }

                        _datatable.Rows.Add(dr);
                    }



                    grdexcel.DataSource = _datatable;
                    grdexcel.DataBind();

                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Trend Analysis - Product for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                }

                else if (ddl_Report.Text == "Trend Analysis - Customer With Product")
                {
                    DataTable _datatable = new DataTable();
                    for (int i = 0; i < Grd_trendcustomer.Columns.Count; i++)
                    {
                        _datatable.Columns.Add(Grd_trendcustomer.Columns[i].ToString());
                    }
                    foreach (GridViewRow row in Grd_trendcustomer.Rows)
                    {
                        DataRow dr = _datatable.NewRow();
                        for (int j = 0; j < Grd_trendcustomer.Columns.Count; j++)
                        {
                            if (!row.Cells[j].Text.Equals("&nbsp;") && !row.Cells[j].Text.Equals("&amp;"))
                                dr[Grd_trendcustomer.Columns[j].ToString()] = row.Cells[j].Text;
                        }

                        _datatable.Rows.Add(dr);
                    }



                    grdexcel.DataSource = _datatable;
                    grdexcel.DataBind();

                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Trend Analysis - Customer With Product for the period from " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");

                }
                else if (ddl_Report.Text == "Loss Jobs")
                {
                    dt = costtempobj.SelLossJobs(Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), "AC", bid);
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Loss Jobs Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Loss Jobs Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.Text == "Port Of Loading")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "pol", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Port of Loadingwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Port of Loadingwise Shipment for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_Filter.Text).ToString();
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "pol", intport, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Port of Loadingwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Port of Loadingwise Shipment for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Port Of Discharge")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Port  of Distinationwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Port  of Distinationwise Shipment for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {

                        intport = Portobj.GetNPortid(txt_Filter.Text).ToString();
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "pod", intport, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Port  of Distinationwise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Port  of Distinationwise Shipment for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Shipperwise")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "shipper", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipperwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Shipperwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "shipper", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipperwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Shipperwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Consigneewise")
                {
                   /* if (txt_Filter.Text == "")
                    {
                        //   dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = (DataTable)ViewState["Consigneewise"];
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Consigneewise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Consigneewise Shipment Details for the period of    " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "consignee", hf_agent.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Consigneewise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Consigneewise Shipment Details for the period of    " + txt_From.Text + " to " + txt_To.Text;
                    }*/

                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Consigneewise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Consigneewise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Consigneewise Shipment for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Consigneewise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Agentwise")
                {
                   /* if (txt_Filter.Text == "")
                    {

                        // dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        //  grdexcel.DataSource = (DataTable)ViewState["dt_AgentDtls"];  


                        DataTable _datatable = new DataTable();
                        for (int i = 0; i < Grd_trendcustomer.Columns.Count; i++)
                        {
                            _datatable.Columns.Add(Grd_trendcustomer.Columns[i].ToString());
                        }
                        foreach (GridViewRow row in Grd_trendcustomer.Rows)
                        {
                            DataRow dr = _datatable.NewRow();
                            for (int j = 0; j < Grd_trendcustomer.Columns.Count; j++)
                            {
                                if (!row.Cells[j].Text.Equals("&nbsp;") && !row.Cells[j].Text.Equals("&amp;"))
                                    dr[Grd_trendcustomer.Columns[j].ToString()] = row.Cells[j].Text;
                            }

                            _datatable.Rows.Add(dr);
                        }

                        grdexcel.DataSource = _datatable;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");



                        //DataTable _datatable = new DataTable();
                        //for (int i = 0; i < grd_Agent.Columns.Count; i++)
                        //{
                        //    _datatable.Columns.Add(grd_Agent.Columns[i].ToString());
                        //}
                        //foreach (GridViewRow row in grd_Agent.Rows)
                        //{
                        //    DataRow dr = _datatable.NewRow();
                        //    for (int j = 0; j < grd_Agent.Columns.Count; j++)
                        //    {
                        //        if (!row.Cells[j].Text.Equals("&nbsp;") && !row.Cells[j].Text.Equals("&amp;"))
                        //            dr[grd_Agent.Columns[j].ToString()] = row.Cells[j].Text;
                        //    }

                        //    _datatable.Rows.Add(dr);
                        //}



                        //grdexcel.DataSource = ;
                        //grdexcel.DataBind();

                        //cnt = dt.Columns.Count;
                        //SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        //SB.Append("</table>");
                        //sp = "Agentwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "agent","0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");

                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "agent", hf_agent.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Agentwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                    */


                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Agentwise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Agentwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Agentwise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Sales Person")
                {
                    if (txt_Filter.Text == "")
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "salesperson", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B> Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                    else
                    {
                        dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "salesperson", Session["LoginEmpId"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B> Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else if (ddl_Report.Text == "Nomination")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "nomination", "N", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Nominationwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Nominationwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.Text == "FreeHand")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDts(bid, Session["StrTranType"].ToString(), "nomination", "F", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Freehandwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Freehandwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.Text == "Nomination Vs Freehand")
                {
                    sp = "Nomination/Freehand wise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.Text == "Quotation - Customerwise")
                {
                    //pending
                    sp = "Quotation Customerwise for the period of  " + txt_From.Text + " to " + txt_To.Text;
                }
                // Retention_Export()
                else if (ddl_Report.Text == "Retention for N / F")
                {
                    //pending
                    Retention_Export();
                }
            }

            if (ddl_Report.SelectedItem.Text == "Operating Profit" || ddl_Report.SelectedItem.Text == "Jobwise Costing")
            {
                if (str_TranType == "FI" || str_TranType == "FE" || str_TranType == "AE" || str_TranType == "AI" || str_TranType == "CH")
                {
                    if (ddl_Report.SelectedItem.Text == "Operating Profit")
                    {
                        dt = costtempobj.SelExcelOperatingProfit(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Operating Profit for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Operating Profit for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }

                    else if (ddl_Report.SelectedItem.Text == "Jobwise Costing")
                    {
                        dt = costtempobj.SelExcelJobWise(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>JobWise Costing for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "JobWise Costing for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
                else
                {
                    if (ddl_Report.SelectedItem.Text == "Operating Profit")
                    {
                        string Filename = "";
                        string strtemp = "";
                        dt = costtempobj.SelExcelOperatingProfit(Convert.ToInt32(Session["LoginBranchid"]), "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Operating Profit for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "Operating Profit for the period of " + txt_From.Text + " to " + txt_To.Text;
                        //if (Gridtemp.Rows.Count > 0)
                        //{
                        //    Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
                        //    strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                        //    Response.Clear();
                        //    Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                        //    Response.Buffer = true;
                        //    Response.Charset = "UTF-8";
                        //    Response.ContentType = "application/vnd.ms-excel";
                        //    Response.Write(strtemp);
                        //    Response.End();
                        //}
                    }
                    else if (ddl_Report.SelectedItem.Text == "Jobwise Costing")
                    {
                        dt = costtempobj.SelExcelJobWise(Convert.ToInt32(Session["LoginBranchid"]), "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                        grdexcel.DataSource = dt;
                        grdexcel.DataBind();
                        cnt = dt.Columns.Count;
                        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>JobWise Costing for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                        SB.Append("</table>");
                        //sp = "JobWise Costing for the period of " + txt_From.Text + " to " + txt_To.Text;
                    }
                }
            }
            if (str_TranType == "CH")
            {

                if (ddl_Report.SelectedItem.Text == "Shipment Details")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Shipment Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.SelectedItem.Text == "LinerWise")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDtsLiner(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "liner", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]), liner);
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Liner Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Liner Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
                {
                    DataSet ds;
                    DataTable dt1 = new DataTable();

                    dt1.Columns.Add("Customer");
                    dt1.Columns.Add("Retention");
                    dt1 = costtempobj.SelTop50ShipperConsignee4BranchTantype(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text));
                    grdexcel.DataSource = dt1;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Top 50 Shipper / Consignee for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                }
                else if (ddl_Report.SelectedItem.Text == "Shipperwise")
                {
                    dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipper", "0", Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text), Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Shipperwise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Shipperwise Shipment Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.SelectedItem.Text == "Consigneewise")
                {
                    //   dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", "0", Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text), Convert.ToInt32(Session["LoginDivisionid"]));
                    dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Convert.ToInt32(Session["LoginDivisionid"]));
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    cnt = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Consigneewise Shipment Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
                    SB.Append("</table>");
                    //sp = "Consigneewise Shipment Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                }
                else if (ddl_Report.SelectedItem.Text == "Retention for N / F" && ddl_Report.SelectedItem.Text == "Revenue")
                {
                    inamt = 0;
                    examt = 0;
                    reamt = 0;
                    if (ddl_Report.SelectedItem.Text == "Loss Jobs" && ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
                    {
                        for (int i = 0; i < Gridtemp.Rows.Count - 1; i++)
                        {
                            inamt = inamt + Convert.ToDouble(Gridtemp.Rows[i].Cells[1].Text);
                            examt = examt + Convert.ToDouble(Gridtemp.Rows[i].Cells[2].Text);
                            reamt = reamt + Convert.ToDouble(Gridtemp.Rows[i].Cells[3].Text);
                        }
                        //Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[0]].Text;
                        Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[1].Text = inamt.ToString();
                        Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[2].Text = examt.ToString();
                        Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[3].Text = reamt.ToString();
                    }
                }
            }

            if (Gridtemp.Rows.Count > 0)
            {
                string Filename = "";
                string strtemp = "";
                Filename = txt_From.Text + " to " + txt_To.Text;
                strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
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
                ScriptManager.RegisterStartupScript(btn_Export, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
            }

            if (str_TranType == "FI" || str_TranType == "FC")
            {
                if (ddl_Report.SelectedItem.Text == "Revenue")
                {
                    revenuerpt();
                }
            }

            if (grdexcel.Visible == true)
            {
                grdexcel.GridLines = GridLines.Both;
                grdexcel.HeaderStyle.Font.Bold = true;
                grdexcel.RenderControl(HtmlTextWriter);
            }
            if (grd_Shipper.Visible == true)
            {
                grd_Shipper.GridLines = GridLines.Both;
                grd_Shipper.HeaderStyle.Font.Bold = true;
                grd_Shipper.RenderControl(HtmlTextWriter);
            }

            Response.Write(StringWriter.ToString());
            Response.End();

            //**********************************************************************//

            // ddl_Report




            //Response.Write(StringWriter.ToString());
            //Response.End();
        }

        //private void ExportToExcel()
        //{
        //    int did = Convert.ToInt32(Session["LoginDivisionid"].ToString());
        //    Response.Clear();

        //    //  Response.AddHeader("content-disposition", "attachment;filename=ExportData1.xls");
        //    Response.AddHeader("content-disposition", "attachment;filename=" + ddl_Report.Text + ".xls");
        //    Response.Charset = "";
        //    //Response.ContentType = "application/vnd.ms-excel";
        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    StringBuilder SB = new StringBuilder();
        //    StringWriter StringWriter = new System.IO.StringWriter(SB);
        //    //StringWriter StringWriter = new System.IO.StringWriter();
        //    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //    int cnt = 0;
        //    DataTable dt = new DataTable();
        //    str_TranType = Session["StrTranType"].ToString();
        //    if (grd_Shipment.Visible == true)
        //    {
        //        costtempobj.DelCostingTemp(Convert.ToInt32(Session["LoginEmpId"]));
        //        if (str_TranType == "FI" || str_TranType == "FE" || str_TranType == "AE" || str_TranType == "AI" || str_TranType == "CH" || str_TranType == "AC")
        //        {
        //            if (ddl_Report.SelectedItem.Text == "Shipment Details")
        //            {
        //                dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

        //                Gridtemp.DataSource = dt;
        //                Gridtemp.DataBind();
        //                cnt = dt.Columns.Count;
        //                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //                SB.Append("</table>");
        //                Gridtemp.GridLines = GridLines.Both;
        //                Gridtemp.HeaderStyle.Font.Bold = true;
        //                Gridtemp.RenderControl(HtmlTextWriter);
        //            }
        //        }
        //    }

        //    //if (str_TranType == "CH")
        //    //{

        //    //    if (ddl_Report.SelectedItem.Text == "Shipment Details")
        //    //    {
        //    //        dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
        //    //        Gridtemp.DataSource = dt;
        //    //        Gridtemp.DataBind();
        //    //        cnt = dt.Columns.Count;
        //    //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //    //        SB.Append("</table>");
        //    //        Gridtemp.GridLines = GridLines.Both;
        //    //        Gridtemp.HeaderStyle.Font.Bold = true;
        //    //        Gridtemp.RenderControl(HtmlTextWriter);
        //    //    }
        //    //}
        //    if (grd_Agent.Visible == true)
        //    {
        //        //grd_Agent.Columns[7].Visible = false;
        //        cnt = grd_Agent.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_Agent.GridLines = GridLines.Both;
        //        grd_Agent.HeaderStyle.Font.Bold = true;
        //        grd_Agent.RenderControl(HtmlTextWriter);


        //    }
        //    else if (grd_Consignee.Visible == true)
        //    {
        //        //grd_Consignee.Columns[7].Visible = false;
        //        cnt = grd_Consignee.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_Consignee.GridLines = GridLines.Both;
        //        grd_Consignee.HeaderStyle.Font.Bold = true;
        //        grd_Consignee.RenderControl(HtmlTextWriter);
        //    }
        //    else if (Grd_nomination.Visible == true)
        //    {
        //        //Grd_nomination.Columns[9].Visible = false;
        //        cnt = Grd_nomination.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        Grd_nomination.GridLines = GridLines.Both;
        //        Grd_nomination.HeaderStyle.Font.Bold = true;
        //        Grd_nomination.RenderControl(HtmlTextWriter);

        //    }
        //    else if (Grd_freeVsnomi.Visible == true)
        //    {
        //        //Grd_freeVsnomi.Columns[8].Visible = false;
        //        cnt = Grd_freeVsnomi.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        Grd_freeVsnomi.GridLines = GridLines.Both;
        //        Grd_freeVsnomi.HeaderStyle.Font.Bold = true;
        //        Grd_freeVsnomi.RenderControl(HtmlTextWriter);
        //    }
        //    else if (grd_JobwiseCosting.Visible == true)
        //    {


        //        grd_JobwiseCosting.Columns[9].Visible = false;
        //        cnt = grd_JobwiseCosting.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        //grd_JobwiseCosting.Columns[10].Visible = false;
        //        grd_JobwiseCosting.GridLines = GridLines.Both;
        //        grd_JobwiseCosting.HeaderStyle.Font.Bold = true;
        //        grd_JobwiseCosting.RenderControl(HtmlTextWriter);
        //    }
        //    else if (grd_lossjob.Visible == true)
        //    {
        //        //grd_lossjob.Columns[7].Visible = false;
        //        cnt = grd_lossjob.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_lossjob.GridLines = GridLines.Both;
        //        grd_lossjob.HeaderStyle.Font.Bold = true;
        //        grd_lossjob.RenderControl(HtmlTextWriter);
        //    }
        //    else if (grd_POD.Visible == true)
        //    {
        //        //grd_POD.Columns[7].Visible = false;
        //        cnt = grd_POD.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + "Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_POD.GridLines = GridLines.Both;
        //        grd_POD.HeaderStyle.Font.Bold = true;
        //        grd_POD.RenderControl(HtmlTextWriter);
        //    }
        //    else if (grd_POL.Visible == true)
        //    {
        //        //grd_POL.Columns[7].Visible = false;
        //        cnt = grd_POL.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_POL.GridLines = GridLines.Both;
        //        grd_POL.HeaderStyle.Font.Bold = true;
        //        grd_POL.RenderControl(HtmlTextWriter);
        //    }
        //    else if (grd_operProfit.Visible == true)
        //    {
        //        //grd_operProfit.Columns[2].Visible = false;
        //        cnt = grd_operProfit.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");

        //        grd_operProfit.GridLines = GridLines.Both;
        //        grd_operProfit.HeaderStyle.Font.Bold = true;
        //        grd_operProfit.RenderControl(HtmlTextWriter);
        //    }
        //    else if (grd_salesperson.Visible == true)
        //    {
        //        //grd_salesperson.Columns[7].Visible = false;
        //        cnt = grd_salesperson.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_salesperson.GridLines = GridLines.Both;
        //        grd_salesperson.HeaderStyle.Font.Bold = true;
        //        grd_salesperson.RenderControl(HtmlTextWriter);
        //    }
        //    else if (Grd_shiperconsignee.Visible == true)
        //    {
        //        cnt = Grd_shiperconsignee.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        //Grd_shiperconsignee.Columns[2].Visible = false;
        //        Grd_shiperconsignee.GridLines = GridLines.Both;
        //        Grd_shiperconsignee.HeaderStyle.Font.Bold = true;
        //        Grd_shiperconsignee.RenderControl(HtmlTextWriter);
        //    }
        //    else if (grd_Shipper.Visible == true)
        //    {
        //        //grd_Shipper.Columns[7].Visible = false;
        //        cnt = grd_Shipper.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_Shipper.GridLines = GridLines.Both;
        //        grd_Shipper.HeaderStyle.Font.Bold = true;
        //        grd_Shipper.RenderControl(HtmlTextWriter);
        //    }
        //    /*  else if (grd_Shipment.Visible == true)
        //      {
        //          //grd_Shipment.Columns[10].Visible = false;
        //          cnt = grd_Shipment.Columns.Count;
        //          SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //          SB.Append("</table>");
        //          grd_Shipment.GridLines = GridLines.Both;
        //          grd_Shipment.HeaderStyle.Font.Bold = true;
        //          grd_Shipment.RenderControl(HtmlTextWriter);
        //      }*/
        //    else if (Grd_trendcustomervolume.Visible == true)
        //    {
        //        cnt = Grd_trendcustomervolume.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        Grd_trendcustomervolume.GridLines = GridLines.Both;
        //        Grd_trendcustomervolume.HeaderStyle.Font.Bold = true;
        //        Grd_trendcustomervolume.RenderControl(HtmlTextWriter);
        //    }
        //    else if (Grd_trendcustomer.Visible == true)
        //    {
        //        cnt = Grd_trendcustomer.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        Grd_trendcustomer.GridLines = GridLines.Both;
        //        Grd_trendcustomer.HeaderStyle.Font.Bold = true;
        //        Grd_trendcustomer.RenderControl(HtmlTextWriter);
        //    }
        //    /* else if (Grd_trendcustomer.Visible == true)
        //     {
        //         cnt = Grd_trendcustomer.Columns.Count;
        //         SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //         SB.Append("</table>");
        //         Grd_trendcustomer.GridLines = GridLines.Both;
        //         Grd_trendcustomer.HeaderStyle.Font.Bold = true;
        //         Grd_trendcustomer.RenderControl(HtmlTextWriter);
        //     }*/
        //    else if (Gridliner.Visible == true)
        //    {

        //        cnt = Gridliner.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        Gridliner.GridLines = GridLines.Both;
        //        Gridliner.HeaderStyle.Font.Bold = true;
        //        Gridliner.RenderControl(HtmlTextWriter);


        //    }
        //    else if (Grd_Retention.Visible == true)
        //    {


        //        cnt = 11;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + cnt + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + " , " + Session["LoginBranchName"].ToString() + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Retention for N/F for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        Grd_Retention.GridLines = GridLines.Both;
        //        Grd_Retention.HeaderStyle.Font.Bold = true;
        //        Grd_Retention.RenderControl(HtmlTextWriter);

        //      //  Retention_Export();
        //      //  return;
        //    }
        //    else if (ddl_Report.Text == "CAN Report")
        //    {

        //        fn_CANREPORT();

        //        GRD_CANREPORT.Visible = true;
        //        cnt = GRD_CANREPORT.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>CAN Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        GRD_CANREPORT.GridLines = GridLines.Both;
        //        GRD_CANREPORT.HeaderStyle.Font.Bold = true;
        //        GRD_CANREPORT.RenderControl(HtmlTextWriter);

        //    }
        //    else if (ddl_Report.Text == "CAN Report AI")
        //    {

        //        fn_CANREPORTAI();
        //        GRD_canreportAI.Visible = true;
        //        GRD_canreportAI.GridLines = GridLines.Both;
        //        GRD_canreportAI.HeaderStyle.Font.Bold = true;
        //        GRD_canreportAI.RenderControl(HtmlTextWriter);

        //    }
        //    else if (ddl_Report.Text == "DO Register Report")
        //    {

        //        fn_REGISTERREPORT();
        //        GRD_RegisterReport.Visible = true;
        //        cnt = GRD_RegisterReport.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>RegisterReport Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        GRD_RegisterReport.GridLines = GridLines.Both;
        //        GRD_RegisterReport.HeaderStyle.Font.Bold = true;
        //        GRD_RegisterReport.RenderControl(HtmlTextWriter);

        //    }
        //    else if (GRD_DoRegister.Visible == true)
        //    {
        //        cnt = GRD_DoRegister.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>DoRegister Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        GRD_DoRegister.GridLines = GridLines.Both;
        //        GRD_DoRegister.HeaderStyle.Font.Bold = true;
        //        GRD_DoRegister.RenderControl(HtmlTextWriter);
        //    }
        //    else if (GRD_Revenue.Visible == true)
        //    {
        //        cnt = GRD_Revenue.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Revenue Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        GRD_Revenue.GridLines = GridLines.Both;
        //        GRD_Revenue.HeaderStyle.Font.Bold = true;
        //        GRD_Revenue.RenderControl(HtmlTextWriter);
        //    }
        //    else if (GRD_Forward.Visible == true)
        //    {
        //        cnt = GRD_Forward.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        GRD_Forward.GridLines = GridLines.Both;
        //        GRD_Forward.HeaderStyle.Font.Bold = true;
        //        GRD_Forward.RenderControl(HtmlTextWriter);
        //    }
        //    else if (GRD_Common.Visible == true)
        //    {
        //        cnt = GRD_Common.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        GRD_Common.GridLines = GridLines.Both;
        //        GRD_Common.HeaderStyle.Font.Bold = true;
        //        GRD_Common.RenderControl(HtmlTextWriter);
        //    }
        //    else if (Grd_shiperconsigneeProduct.Visible == true)
        //    {
        //        cnt = Grd_shiperconsigneeProduct.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        Grd_shiperconsigneeProduct.GridLines = GridLines.Both;
        //        Grd_shiperconsigneeProduct.HeaderStyle.Font.Bold = true;
        //        Grd_shiperconsigneeProduct.RenderControl(HtmlTextWriter);
        //    }
        //    else if (grd_operProfit_AC.Visible == true)
        //    {
        //        cnt = grd_operProfit_AC.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_operProfit_AC.GridLines = GridLines.Both;
        //        grd_operProfit_AC.HeaderStyle.Font.Bold = true;
        //        grd_operProfit_AC.RenderControl(HtmlTextWriter);
        //    }

        //    else if (grd_operProfit.Visible == true)
        //    {
        //        cnt = grd_operProfit.Columns.Count;
        //        SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //        SB.Append("</table>");
        //        grd_operProfit.GridLines = GridLines.Both;
        //        grd_operProfit.HeaderStyle.Font.Bold = true;
        //        grd_operProfit.RenderControl(HtmlTextWriter);
        //    }
        //    /*   else if (grd_YearMIS.Visible == true)
        //       {
        //           cnt = grd_YearMIS.Columns.Count;
        //           SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + ddl_Report.Text + " Details for the period of " + txt_From.Text + " To " + txt_To.Text + "</B></font></td></tr>");
        //           SB.Append("</table>");
        //           grd_YearMIS.GridLines = GridLines.Both;
        //           grd_YearMIS.HeaderStyle.Font.Bold = true;
        //           grd_YearMIS.RenderControl(HtmlTextWriter);
        //       }*/
        //    //Response.Write(StringWriter.ToString());
        //    //Response.End();

        //    string style = @"<style> .textmode { } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(StringWriter.ToString());
        //    Response.Flush();
        //    Response.End();
        //}

        /*private void ExportToExcel_OLDFormat()
         {
             int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());

             DataTable dt = new DataTable();
             DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
             str_TranType = Session["StrTranType"].ToString();
             // ddl_Report
             string STR = "";
             string sp;

             if (STR == "")
             {
                 STR = str_TranType;
             }
             if (str_TranType == "FI" || str_TranType == "FE" || str_TranType == "AE" || str_TranType == "AI")
             {
                 if (ddl_Report.SelectedItem.Text == "Shipment Details")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Shipment Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.SelectedItem.Text == "LinerWise")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDtsLiner(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "liner", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()), liner);
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Liner Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
                 {

                     DataSet ds;
                     DataTable dt1 = new DataTable();

                     dt1.Columns.Add("Customer");
                     dt1.Columns.Add("Retention");
                     dt1 = costtempobj.SelTop50ShipperConsignee4BranchTantype(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                     Gridtemp.DataSource = dt1;
                     Gridtemp.DataBind();
                 }
                 else if (ddl_Report.SelectedItem.Text == "Port Of Loading")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pol", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Port of Loadingwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         int portname = Portobj.GetNPortid(txt_Filter.Text);
                         intport = portname.ToString();
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pol", intport, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Port of Loadingwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.SelectedItem.Text == "Port Of Discharge")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Port  of Distinationwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", intport, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Port  of Distinationwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;

                     }
                 }
                 else if (ddl_Report.SelectedItem.Text == "Shipperwise")
                 {
                     if (txt_Filter.Text == "Shipperwise")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Shipperwise Shipment for the period of" + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", intport, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Shipperwise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;

                     }
                 }
                 else if (ddl_Report.SelectedItem.Text == "CAN Report AI")
                 {
                     string Filename = "";
                     string strtemp = "";
                     dt = costtempobj.GetCanRegister4AuditAI(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "CAN Audit Report AI for the period of " + txt_From.Text + " to " + txt_To.Text;
                     if (Gridtemp.Rows.Count > 0)
                     {
                         Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
                         strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
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
                         ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                     }
                 }
                 else if (ddl_Report.SelectedItem.Text == "CAN Report")
                 {
                     string Filename = "";
                     string strtemp = "";
                     dt = costtempobj.GetCanRegister4AuditAI(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "CAN Audit Report for the period of " + txt_From.Text + " to " + txt_To.Text;
                     if (Gridtemp.Rows.Count > 0)
                     {
                         Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
                         strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
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
                         ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                     }
                 }
                 else if (ddl_Report.SelectedItem.Text == "DO Register Report")
                 {
                     string Filename = "";
                     string strtemp = "";
                     dt = costtempobj.GetDoRegister4Audit(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "DO Audit Report for the period of " + txt_From.Text + " to " + txt_To.Text;
                     if (Gridtemp.Rows.Count > 0)
                     {
                         Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
                         strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
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
                         ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                     }
                 }
                 else if (ddl_Report.SelectedItem.Text == "Consigneewise")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Consigneewise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", intcustid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Consigneewise Shipment for the period of " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.Text == "Agentwise")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         // Gridtemp.DataBind();
                         sp = "Agentwise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", hf_agent.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Agentwise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.Text == "Sales Person")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), "CO", "salesperson", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), "CO", "salesperson", Session["LoginEmpId"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.Text == "Nomination")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), "CO", "nomination", "N", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Nominationwise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                     costtempobj.DelCostingTemp(Convert.ToInt32(Session["LoginEmpId"]));
                 }
                 else if (ddl_Report.Text == "FreeHand")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "nomination", "F", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Freehandwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                 }

                 else if (ddl_Report.Text == "Nomination Vs Freehand")
                 {

                     sp = "Nomination/Freehand wise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.Text == "Loss Jobs")
                 {
                     dt = costtempobj.SelLossJobs(Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Loss Jobs Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.SelectedItem.Text == "Retention for N / F")
                 {
                     Retention_Export();
                 }
             }

             else if (str_TranType == "AC")
             {
                 if (ddl_Report.Text == "LinerWise")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDtsLinerTemp(bid, Session["StrTranType"].ToString(),Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)),"0",Convert.ToInt32(Session["LoginDivisionid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                 }

                 else if (ddl_Report.Text == "LinerWise")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDtsLiner(bid, "AC", "liner", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]), Convert.ToInt32(hf_agent.Value));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Liner Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.Text == "Top 50 Shipper / Consignee")
                 {
                     DataSet ds = new DataSet();
                     DataTable Dt1 = new DataTable();
                     DataTable Dt2 = new DataTable();
                     Dt1.Columns.Add("Shipper");
                     Dt1.Columns.Add("Retention4Shipper");
                     Dt1.Columns.Add("Consignee");
                     Dt1.Columns.Add("Retention4Consignee");
                     for (int i = 0; i <= 4; i++)
                     {
                         ds = costtempobj.SelTop50ShipperConsignee4Branch(Convert.ToInt32(Session["LoginEmpId"]), bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                         dt = ds.Tables[0];
                         Dt2 = ds.Tables[1];
                         if (dt.Rows.Count > 0)
                         {
                             int n;
                             n = Dt1.Rows.Count;
                             for (j = 0; j <= dt.Rows.Count - 1; j++)
                             {
                                 if (j == 0)
                                 {
                                     Dt1.Rows.Add();
                                     if (i == 1)
                                     {
                                         Dt1.Rows[n][0] = dt.Rows[j][2].ToString();
                                     }
                                     else if (i == 2)
                                     {
                                         Dt1.Rows[n][0] = dt.Rows[j][2].ToString();
                                     }
                                     else if (i == 3)
                                     {
                                         Dt1.Rows[n][0] = dt.Rows[j][2].ToString();
                                     }
                                     else
                                     {
                                         Dt1.Rows[n][0] = dt.Rows[j][2].ToString();
                                     }
                                     Dt1.Rows[n][1] = "";
                                     Dt1.Rows[n][2] = "";
                                     Dt1.Rows[n][3] = "";
                                     n = n + 1;
                                     Dt1.Rows.Add();
                                     Dt1.Rows[n][0] = dt.Rows[j][0].ToString();
                                     Dt1.Rows[n][1] = dt.Rows[j][1].ToString();
                                     if (Dt2.Rows.Count > j)
                                     {
                                         Dt1.Rows[n][0] = dt.Rows[j][2].ToString();
                                         Dt1.Rows[n][1] = dt.Rows[j][3].ToString();
                                     }
                                     else
                                     {
                                         Dt1.Rows[n][0] = "";
                                         Dt1.Rows[n][1] = "";
                                     }
                                     n = n + 1;
                                 }
                                 else
                                 {
                                     Dt1.Rows.Add();
                                     Dt1.Rows[n][0] = dt.Rows[j][0].ToString();
                                     Dt1.Rows[n][1] = dt.Rows[j][1].ToString();
                                     if (Dt2.Rows.Count > j)
                                     {
                                         Dt1.Rows[n][2] = dt.Rows[j][0].ToString();
                                         Dt1.Rows[n][3] = dt.Rows[j][1].ToString();
                                     }
                                     else
                                     {
                                         Dt1.Rows[n][2] = "";
                                         Dt1.Rows[n][3] = "";
                                     }
                                     n = n + 1;
                                 }
                             }
                         }
                     }
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Top 50 Shipper / Consignee Details for the period from   " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.Text == "Loss Jobs")
                 {
                     dt = costtempobj.SelLossJobs(Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), "AC", bid);
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Loss Jobs Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.Text == "Port Of Loading")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "pol", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Port of Loadingwise Shipment for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {

                         intport = Portobj.GetNPortid(txt_Filter.Text).ToString();
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "pol", intport, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Port of Loadingwise Shipment for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.Text == "Port Of Discharge")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Port  of Distinationwise Shipment for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {

                         intport = Portobj.GetNPortid(txt_Filter.Text).ToString();
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "pod", intport, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Port  of Distinationwise Shipment for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.Text == "Shipperwise")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "shipper", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Shipperwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;

                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "shipper", hf_agent.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Shipperwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.Text == "Consigneewise")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Consigneewise Shipment Details for the period of    " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "consignee", hf_agent.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Consigneewise Shipment Details for the period of    " + txt_From.Text + " to " + txt_To.Text;

                     }
                 }
                 else if (ddl_Report.Text == "Agentwise")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Agentwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "agent", hf_agent.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Agentwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.Text == "Sales Person")
                 {
                     if (txt_Filter.Text == "")
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "salesperson", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                     else
                     {
                         dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "salesperson", Session["LoginEmpId"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
                 else if (ddl_Report.Text == "Nomination")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "nomination", "N", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Nominationwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.Text == "FreeHand")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDts(bid, "AC", "nomination", "F", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Freehandwise Shipment Details for the period of   " + txt_From.Text + " to " + txt_To.Text;
                 }

                 else if (ddl_Report.Text == "Nomination Vs Freehand")
                 {

                     sp = "Nomination/Freehand wise Shipment Details for the period of  " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.Text == "Quotation - Customerwise")
                 {
                     sp = "Quotation Customerwise for the period of  " + txt_From.Text + " to " + txt_To.Text;
                 }
                 // Retention_Export()
                 else if (ddl_Report.Text == "Retention for N / F")
                 {
                     Retention_Export();
                 }

             }


             if (ddl_Report.SelectedItem.Text == "Operating Profit" || ddl_Report.SelectedItem.Text == "Jobwise Costing")
             {
                 if (str_TranType == "FI" || str_TranType == "FE" || str_TranType == "AE" || str_TranType == "AI" || str_TranType == "CH")
                 {
                     if (ddl_Report.SelectedItem.Text == "Operating Profit")
                     {
                         dt = costtempobj.SelExcelOperatingProfit(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Operating Profit for the period of " + txt_From.Text + " to " + txt_To.Text;
                     }

                     else if (ddl_Report.SelectedItem.Text == "Jobwise Costing")
                     {
                         dt = costtempobj.SelExcelJobWise(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "JobWise Costing for the period of " + txt_From.Text + " to " + txt_To.Text;

                     }
                 }
                 else
                 {
                     if (ddl_Report.SelectedItem.Text == "Operating Profit")
                     {
                         string Filename = "";
                         string strtemp = "";
                         dt = costtempobj.SelExcelOperatingProfit(Convert.ToInt32(Session["LoginBranchid"]), "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "Operating Profit for the period of " + txt_From.Text + " to " + txt_To.Text;
                         if (Gridtemp.Rows.Count > 0)
                         {
                             Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
                             strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                             Response.Clear();
                             Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                             Response.Buffer = true;
                             Response.Charset = "UTF-8";
                             Response.ContentType = "application/vnd.ms-excel";
                             Response.Write(strtemp);
                             Response.End();
                         }
                     }
                     else if (ddl_Report.SelectedItem.Text == "Jobwise Costing")
                     {
                         dt = costtempobj.SelExcelJobWise(Convert.ToInt32(Session["LoginBranchid"]), "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                         Gridtemp.DataSource = dt;
                         Gridtemp.DataBind();
                         sp = "JobWise Costing for the period of " + txt_From.Text + " to " + txt_To.Text;
                     }
                 }
             }
             if (str_TranType == "CH")
             {

                 if (ddl_Report.SelectedItem.Text == "Shipment Details")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Shipment Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.SelectedItem.Text == "LinerWise")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDtsLiner(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "liner", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionid"]), liner);
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Liner Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
                 {
                     DataSet ds;
                     DataTable dt1 = new DataTable();

                     dt1.Columns.Add("Customer");
                     dt1.Columns.Add("Retention");
                     dt1 = costtempobj.SelTop50ShipperConsignee4BranchTantype(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text));
                     Gridtemp.DataSource = dt1;
                     Gridtemp.DataBind();
                 }
                 else if (ddl_Report.SelectedItem.Text == "Shipperwise")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipper", "0", Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text), Convert.ToInt32(Session["LoginDivisionid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Shipperwise Shipment Details for the period of " + txt_From.Text + " to " + txt_To.Text;
                 }
                 else if (ddl_Report.SelectedItem.Text == "Consigneewise")
                 {
                     dt = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", "0", Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text), Convert.ToInt32(Session["LoginDivisionid"]));
                     Gridtemp.DataSource = dt;
                     Gridtemp.DataBind();
                     sp = "Consigneewise Shipment Details for the period of " + txt_From.Text + " to " + txt_To.Text;

                 }
                 else if (ddl_Report.SelectedItem.Text == "Retention for N / F" && ddl_Report.SelectedItem.Text == "Revenue")
                 {
                     inamt = 0;
                     examt = 0;
                     reamt = 0;

                   

                     if (ddl_Report.SelectedItem.Text == "Loss Jobs" && ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
                     {
                         for (int i = 0; i < Gridtemp.Rows.Count - 1; i++)
                         {
                             inamt = inamt + Convert.ToDouble(Gridtemp.Rows[i].Cells[1].Text);
                             examt = examt + Convert.ToDouble(Gridtemp.Rows[i].Cells[2].Text);
                             reamt = reamt + Convert.ToDouble(Gridtemp.Rows[i].Cells[3].Text);

                         }
                         //Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[0]].Text;
                         Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[1].Text = inamt.ToString();
                         Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[2].Text = examt.ToString();
                         Gridtemp.Rows[Gridtemp.Rows.Count - 1].Cells[3].Text = reamt.ToString();

                     }
                 }
             }

             if (Gridtemp.Rows.Count > 0)
             {
                 string Filename = "";
                 string strtemp = "";
                 Filename = txt_From.Text + " to " + txt_To.Text;
                 strtemp = Utility.Fn_ExportExcel(Gridtemp, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
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
                 ScriptManager.RegisterStartupScript(btn_Export, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
             }

             if (str_TranType == "FI" || str_TranType == "FC")
             {
                 if (ddl_Report.SelectedItem.Text == "Revenue")
                 {
                     revenuerpt();
                 }
             }

             //Response.Write(StringWriter.ToString());
             //Response.End();
         }
        */
        private void ExportToExcel_OLDFormat()
        {
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=ExportData1.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringWriter StringWriter = new System.IO.StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            //if (grd_Agent.Visible == true)
            //{
            //    //grd_Agent.Columns[7].Visible = false;
            //    grd_Agent.GridLines = GridLines.Both;
            //    grd_Agent.HeaderStyle.Font.Bold = true;
            //    grd_Agent.RenderControl(HtmlTextWriter);
            //}
            //if (grd_Consignee.Visible == true)
            //{
            //    //grd_Consignee.Columns[7].Visible = false;
            //    grd_Consignee.GridLines = GridLines.Both;
            //    grd_Consignee.HeaderStyle.Font.Bold = true;
            //    grd_Consignee.RenderControl(HtmlTextWriter);
            //}
            // if (Grd_nomination.Visible == true)
            //{
            //    //Grd_nomination.Columns[9].Visible = false;
            //    Grd_nomination.GridLines = GridLines.Both;
            //    Grd_nomination.HeaderStyle.Font.Bold = true;
            //    Grd_nomination.RenderControl(HtmlTextWriter);

            //}
            if (Grd_freeVsnomi.Visible == true)
            {
                //Grd_freeVsnomi.Columns[8].Visible = false;
                Grd_freeVsnomi.GridLines = GridLines.Both;
                Grd_freeVsnomi.HeaderStyle.Font.Bold = true;
                Grd_freeVsnomi.RenderControl(HtmlTextWriter);
            }
            /*else if (grd_JobwiseCosting.Visible == true)
            {
                grd_JobwiseCosting.Columns[9].Visible = false;
                //grd_JobwiseCosting.Columns[10].Visible = false;
                grd_JobwiseCosting.GridLines = GridLines.Both;
                grd_JobwiseCosting.HeaderStyle.Font.Bold = true;
                grd_JobwiseCosting.RenderControl(HtmlTextWriter);
            }
            else if (grd_lossjob.Visible == true)
            {
                //grd_lossjob.Columns[7].Visible = false;
                grd_lossjob.GridLines = GridLines.Both;
                grd_lossjob.HeaderStyle.Font.Bold = true;
                grd_lossjob.RenderControl(HtmlTextWriter);
            }
            else if (grd_POD.Visible == true)
            {
                //grd_POD.Columns[7].Visible = false;
                grd_POD.GridLines = GridLines.Both;
                grd_POD.HeaderStyle.Font.Bold = true;
                grd_POD.RenderControl(HtmlTextWriter);
            }
            else if (grd_POL.Visible == true)
            {
                //grd_POL.Columns[7].Visible = false;
                grd_POL.GridLines = GridLines.Both;
                grd_POL.HeaderStyle.Font.Bold = true;
                grd_POL.RenderControl(HtmlTextWriter);
            }
            else if (grd_operProfit.Visible == true)
            {
                grd_operProfit.Columns[2].Visible = false;

                grd_operProfit.GridLines = GridLines.Both;
                grd_operProfit.HeaderStyle.Font.Bold = true;
                grd_operProfit.RenderControl(HtmlTextWriter);
            }*/
            //else if (grd_salesperson.Visible == true)
            //{
            //    //grd_salesperson.Columns[7].Visible = false;
            //    grd_salesperson.GridLines = GridLines.Both;
            //    grd_salesperson.HeaderStyle.Font.Bold = true;
            //    grd_salesperson.RenderControl(HtmlTextWriter);
            //}
            else if (Grd_shiperconsignee.Visible == true)
            {
                Grd_shiperconsignee.Columns[2].Visible = false;
                Grd_shiperconsignee.GridLines = GridLines.Both;
                Grd_shiperconsignee.HeaderStyle.Font.Bold = true;
                Grd_shiperconsignee.RenderControl(HtmlTextWriter);
            }
            //else if (grd_Shipper.Visible == true)
            //{
            //    //grd_Shipper.Columns[7].Visible = false;
            //    grd_Shipper.GridLines = GridLines.Both;
            //    grd_Shipper.HeaderStyle.Font.Bold = true;
            //    grd_Shipper.RenderControl(HtmlTextWriter);
            //}
            //else if (grd_Shipment.Visible == true)
            //{
            //    //grd_Shipment.Columns[10].Visible = false;
            //    grd_Shipment.GridLines = GridLines.Both;
            //    grd_Shipment.HeaderStyle.Font.Bold = true;
            //    grd_Shipment.RenderControl(HtmlTextWriter);
            //}
            else if (Grd_trendcustomervolume.Visible == true)
            {
                Grd_trendcustomervolume.GridLines = GridLines.Both;
                Grd_trendcustomervolume.HeaderStyle.Font.Bold = true;
                Grd_trendcustomervolume.RenderControl(HtmlTextWriter);
            }
            else if (Grd_trendcustomer.Visible == true)
            {
                Grd_trendcustomer.GridLines = GridLines.Both;
                Grd_trendcustomer.HeaderStyle.Font.Bold = true;
                Grd_trendcustomer.RenderControl(HtmlTextWriter);
            }
            else if (Grd_trendcustomer.Visible == true)
            {
                Grd_trendcustomer.GridLines = GridLines.Both;
                Grd_trendcustomer.HeaderStyle.Font.Bold = true;
                Grd_trendcustomer.RenderControl(HtmlTextWriter);
            }
            else if (Gridliner.Visible == true)
            {
                Gridliner.GridLines = GridLines.Both;
                Gridliner.HeaderStyle.Font.Bold = true;
                Gridliner.RenderControl(HtmlTextWriter);


            }
            else if (Grd_Retention.Visible == true)
            {

                //  Retention_Export();
                ////  return;

                if (Grd_Retention.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Charset = "";
                    string FileName = "Retention N/F" + DateTime.Now + ".xls";
                    StringWriter strwritter = new StringWriter();
                    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Grd_Retention.GridLines = GridLines.Both;
                    Grd_Retention.HeaderStyle.Font.Bold = true;
                    Grd_Retention.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    Response.End();
                }

                return;


            }
            else if (ddl_Report.Text == "CAN Report")
            {

                fn_CANREPORT();
                GRD_CANREPORT.Visible = true;
                GRD_CANREPORT.GridLines = GridLines.Both;
                GRD_CANREPORT.HeaderStyle.Font.Bold = true;
                GRD_CANREPORT.RenderControl(HtmlTextWriter);

            }
            else if (ddl_Report.Text == "CAN Report AI")
            {

                fn_CANREPORTAI();
                GRD_canreportAI.Visible = true;
                GRD_canreportAI.GridLines = GridLines.Both;
                GRD_canreportAI.HeaderStyle.Font.Bold = true;
                GRD_canreportAI.RenderControl(HtmlTextWriter);

            }
            else if (ddl_Report.Text == "DO Register Report")
            {

                fn_REGISTERREPORT();
                GRD_RegisterReport.Visible = true;
                GRD_RegisterReport.GridLines = GridLines.Both;
                GRD_RegisterReport.HeaderStyle.Font.Bold = true;
                GRD_RegisterReport.RenderControl(HtmlTextWriter);

            }
            else if (ddl_Report.SelectedItem.Text == "Agentwise")
            {
                DataTable dts;
                if (txt_Filter.Text == "")
                {

                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }

                }
                else
                {
                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "agent", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }
                }



            }
            else if (ddl_Report.SelectedItem.Text == "Shipperwise")
            {
                DataTable dts;
                if (txt_Filter.Text == "")
                {

                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipper", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }

                }
                else
                {
                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipper", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }
                }



            }
            else if (ddl_Report.SelectedItem.Text == "Port Of Loading")
            {
                DataTable dts;
                if (txt_Filter.Text == "")
                {

                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pol", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }

                }
                else
                {
                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pol", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }
                }



            }
            else if (ddl_Report.SelectedItem.Text == "Port Of Discharge")
            {
                DataTable dts;
                if (txt_Filter.Text == "")
                {

                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }

                }
                else
                {
                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "pod", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }
                }



            }
            else if (ddl_Report.SelectedItem.Text == "Nomination")
            {
                DataTable dts;
                if (txt_Filter.Text == "")
                {

                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "nomination", "N", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }

                }
            }
            else if (ddl_Report.SelectedItem.Text == "FreeHand")
            {
                DataTable dts;
                dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "nomination", "F", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                Gridtemp.DataSource = dts;
                Gridtemp.DataBind();
                if (Gridtemp.Visible == true)
                {
                    Gridtemp.GridLines = GridLines.Both;
                    Gridtemp.HeaderStyle.Font.Bold = true;
                    Gridtemp.RenderControl(HtmlTextWriter);
                }
            }




            else if (ddl_Report.SelectedItem.Text == "Sales Person")
            {
                DataTable dts;
                if (txt_Filter.Text == "")
                {

                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "salesperson", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }

                }
                else
                {
                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "salesperson", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }
                }



            }
            else if (ddl_Report.SelectedItem.Text == "Consigneewise")
            {
                DataTable dts;
                if (txt_Filter.Text == "")
                {

                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }

                }
                else
                {
                    dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "consignee", hidId.Value, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Gridtemp.DataSource = dts;
                    Gridtemp.DataBind();
                    if (Gridtemp.Visible == true)
                    {
                        Gridtemp.GridLines = GridLines.Both;
                        Gridtemp.HeaderStyle.Font.Bold = true;
                        Gridtemp.RenderControl(HtmlTextWriter);
                    }
                }



            }
            else if (ddl_Report.SelectedItem.Text == "Shipment Details")
            {
                DataTable dts;
                dts = costtempobj.SelExcelShipmentFCostingDts(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                Gridtemp.DataSource = dts;
                Gridtemp.DataBind();
                if (Gridtemp.Visible == true)
                {
                    Gridtemp.GridLines = GridLines.Both;
                    Gridtemp.HeaderStyle.Font.Bold = true;
                    Gridtemp.RenderControl(HtmlTextWriter);
                }

            }
            else if (GRD_DoRegister.Visible == true)
            {
                GRD_DoRegister.GridLines = GridLines.Both;
                GRD_DoRegister.HeaderStyle.Font.Bold = true;
                GRD_DoRegister.RenderControl(HtmlTextWriter);
            }
            else if (GRD_Revenue.Visible == true)
            {
                GRD_Revenue.GridLines = GridLines.Both;
                GRD_Revenue.HeaderStyle.Font.Bold = true;
                GRD_Revenue.RenderControl(HtmlTextWriter);
            }
            else if (GRD_Forward.Visible == true)
            {
                GRD_Forward.GridLines = GridLines.Both;
                GRD_Forward.HeaderStyle.Font.Bold = true;
                GRD_Forward.RenderControl(HtmlTextWriter);
            }
            else if (GRD_Common.Visible == true)
            {
                GRD_Common.GridLines = GridLines.Both;
                GRD_Common.HeaderStyle.Font.Bold = true;
                GRD_Common.RenderControl(HtmlTextWriter);
            }

            Response.Write(StringWriter.ToString());
            Response.End();
        }

        
        public void revenuerpt()
        {
            System.IO.TextWriter TW;
            String sendqry;
            String filename = "";
            DataTable Dtaddr = new DataTable();
            DataTable dtrev = new DataTable();
            sendqry = "";
            String desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            String strdate;
            strdate = DateTime.Now.ToString("dd-MMM-yyyy");
            string Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
            TW = System.IO.File.CreateText(desktopPath + "\" + filename +");
            sendqry = sendqry + "<html  xmlns:v=\"urn:schemas-microsoft-com:vml\"xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"xmlns=\"http://www.w3.org/TR/REC-html40\">";
            Dtaddr = Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"]));
            sendqry = "<body>";

            sendqry = "<table  BORDER=1 BORDERCOLOR=Black  style=font-family:sans-serif;font-size:9pt>";
            sendqry = "<tr><td align=center colspan=21>";
            sendqry = "<FONT FACE=Arial SIZE=4 align=center>" + Dtaddr.Rows[0][0].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dtaddr.Rows[0][1].ToString() + " <br> Phone : " + Dtaddr.Rows[0][1].ToString() + " Fax : " + Dtaddr.Rows[0][1].ToString() + "</Font>";
            sendqry = "</td></tr>";
            sendqry = "<tr><td align=center colspan=2><b>Job #</b></td><td align=center colspan=2><b>VslVoy</b></td><td align=center><b>ETA</b></td><td align=center colspan=2><b>MBL #</b></td><td colspan=4 align=center><b>Free Hand<b></td><td colspan=4 align=center><b>Nomination</b></td><td align=center><b>Teus</b></td><td colspan=4 align=center><b>Container #</b></td><td align=center><b>Income</b></td></tr>";
            sendqry = "<tr><td colspan=2></td><td colspan=2></td><td></td><td colspan=2></td><td colspan=3  align=center><b>BL #</b></td><td colspan=1 align=center><b>CBM</b></td><td colspan=3 align=center><b>BL #</b></td><td colspan=1 align=center><b>CBM</b></td><td></td><td colspan=4></td><td></td></tr>";
            dtrev = costtempobj.GetRevenueRpt(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text));
            if (dtrev.Rows.Count > 0)
            {
                for (int i = 0; i < dtrev.Rows.Count; i++)
                {
                    sendqry = "<tr><td colspan=2>" + dtrev.Rows[i]["jobtype"].ToString() + " - " + dtrev.Rows[i]["jobno"].ToString() + "</td><td colspan=2> " + dtrev.Rows[i]["vslvoy"].ToString() + "</td><td>" + dtrev.Rows[i]["eta"].ToString() + "</td><td colspan=2 align=left>" + dtrev.Rows[i]["mblno"].ToString() + "</td><td colspan=3 align=left>" + dtrev.Rows[i]["freebl"].ToString() + "</td><td colspan=1>" + dtrev.Rows[i]["freecbm"].ToString() + "</td><td colspan=3 align=left>" + dtrev.Rows[i]["nombl"].ToString() + "</td><td colspan=1>" + dtrev.Rows[i]["nomcbm"].ToString() + "</td><td>" + dtrev.Rows[i]["tues"].ToString() + "</td><td colspan=4 align=left>" + dtrev.Rows[i]["cntrdtls"].ToString() + "</td><td>" + dtrev.Rows[i]["income"].ToString() + "</td></tr>";
                }
            }
            sendqry = "</body></table></html>";

            TW.WriteLine(sendqry);
            TW.Flush();
            TW.Close();

            ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "CAN Report", "alertify.alert('File Saved on Your Desktop File Name is');" + filename, true);
        }

        public void fn_REGISTERREPORT()
        {
            int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
            DataTable dt = new DataTable();

            dt = costtempobj.GetDoRegister4Audit(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
            if (dt.Rows.Count > 0)
            {
                GRD_RegisterReport.DataSource = dt;
                GRD_RegisterReport.DataBind();
                btn_Export.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "CAN Report", "alertify.alert('Data not available');", true);
            }
        }

        public void fn_CANREPORTAI()
        {

            int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
            DataTable dt = new DataTable();

            dt = costtempobj.GetCanRegister4AuditAI(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
            if (dt.Rows.Count > 0)
            {
                GRD_canreportAI.DataSource = dt;
                GRD_canreportAI.DataBind();
                btn_Export.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(LinkButton), "CAN Report", "alertify.alert('Data not available');", true);
            }

        }

        protected void Grd_Retention_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text.ToString().StartsWith("Ocean"))
                {
                    e.Row.ForeColor = System.Drawing.Color.Maroon;
                }

                /*else if (e.Row.Cells[0].Text.ToString().StartsWith("Agent"))
                {
                    //e.Row.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.ForeColor = System.Drawing.Color.Maroon;
                    e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Right";
                    e.Row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
                    e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                    e.Row.Cells[4].Attributes.CssStyle["text-align"] = "Right";
                    e.Row.Cells[5].Attributes.CssStyle["text-align"] = "Right";
                    e.Row.Cells[6].Attributes.CssStyle["text-align"] = "Right";
                    e.Row.Cells[7].Attributes.CssStyle["text-align"] = "Right";
                }
                else if (e.Row.Cells[1].Text.ToString() == "Controlled")
                {
                    e.Row.ForeColor = System.Drawing.Color.Maroon;
                    e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Center";
                    e.Row.Cells[2].Attributes.CssStyle["text-align"] = "Center";
                    e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Center";
                    e.Row.Cells[4].Attributes.CssStyle["text-align"] = "Center";
                }*/
                else if (e.Row.Cells[0].Text.ToString() == "Summary")
                {
                    e.Row.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.ForeColor = System.Drawing.Color.Maroon;
                }
                else if (e.Row.Cells[0].Text.ToString() == "Retention (Consol + LCL + FCL)")
                {
                    e.Row.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.ForeColor = System.Drawing.Color.Maroon;
                }
                else if (e.Row.Cells[0].Text.ToString() == "Teus (Consol + FCL)")
                {
                    e.Row.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.ForeColor = System.Drawing.Color.Maroon;
                }
                else if (e.Row.Cells[0].Text.ToString() == "CBM (Consol + LCL)")
                {
                    e.Row.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.ForeColor = System.Drawing.Color.Maroon;
                }
                for (int h = 1; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    }
                }
            }
        }

        private void Retention_Export()
        {
            int int_branchid, int_divisionid, i;
            string StrTrantype, Str_Export;
            double Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_Retention, Tot_Tues, Tot_CBM;
            int_branchid = int.Parse(Session["LoginBranchid"].ToString());
            int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            StrTrantype = Session["StrTranType"].ToString();
            DataSet obj_ds = new DataSet();
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
            string str_todate = Utility.fn_ConvertDate(txt_To.Text);
            DateTime frm_date, to_date;
            frm_date = Convert.ToDateTime(str_fromdate);
            to_date = Convert.ToDateTime(str_todate);
            DataAccess.CostingTemp da_obj_Costing = new DataAccess.CostingTemp();
            string Trantype = "";
            if (StrTrantype == "FE")
            {
                Trantype = "Ocean Exports";
            }
            else if (StrTrantype == "FI")
            {
                Trantype = "Ocean Imports";
            }
            else if (StrTrantype == "AI")
            {
                Trantype = "Air Imports";
            }
            else if (StrTrantype == "AE")
            {
                Trantype = "Air Exports";
            }
            Str_Export = "";
            Tot_Retention = 0;
            Tot_Tues = 0;
            Tot_CBM = 0;
            string Filename = "Retention For N/F for the period of  " + txt_From.Text + " to " + txt_To.Text;
            Str_Export = Str_Export + "<html  xmlns:v=\"urn:schemas-microsoft-com:vml\"xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"xmlns=\"http://www.w3.org/TR/REC-html40\">";
            Str_Export = Str_Export + "<table BORDER=1 BORDERCOLOR=darkblue><tr><td  align=center colspan=5><B>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</B></td></tr>";
            Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Filename + "</B></td></tr>";
            if (StrTrantype == "FE" || StrTrantype == "FI")
            {
                Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Trantype + " - Consol</B></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2><B>Controlled By Us</B></td><td  align=center colspan=2><B>Agent Controlled</B></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>Total M3</B></td><td  align=center ><B>Total Retention</B></td><td  align=center ><B>Tues</B></td></tr>";
                obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "Consol", int_branchid, StrTrantype);
                if (obj_ds.Tables.Count > 0)
                {
                    Tot_1 = 0;
                    Tot_2 = 0;
                    Tot_3 = 0;
                    Tot_4 = 0;
                    Tot_5 = 0;
                    Tot_6 = 0;
                    Tot_7 = 0;
                    obj_dttemp = obj_ds.Tables[0];
                    for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {
                        double total_1 = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
                        double total_2 = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
                        Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
                        Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());
                        Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][3].ToString());
                        Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());
                        Tot_5 = Tot_5 + total_1;
                        Tot_6 = Tot_6 + total_2;
                        Tot_7 = Tot_7 + double.Parse(obj_dttemp.Rows[i][5].ToString());

                        Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2>" + obj_dttemp.Rows[i][0].ToString() + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][1]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][2]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.000}", obj_dttemp.Rows[i][3]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][4]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", total_1) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", total_2) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][5]) + "</td></tr>";

                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Tot_Retention = Tot_Retention + Tot_6;
                        Tot_Tues = Tot_Tues + Tot_7;
                        Tot_CBM = Tot_CBM + Tot_5;
                        Str_Export = Str_Export + "<tr><td align=right><B>Total</B></td><td  align=center ><B>" + string.Format("{0:0.000}", Tot_1) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_2) + "</B></td><td  align=center ><B>" + string.Format("{0:0.000}", Tot_3) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_4) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_5) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_6) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_7) + "</B></td></tr>";
                    }

                }
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";


                Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Trantype + " - LCL</B></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2><B>Controlled By Us</B></td><td  align=center colspan=2><B>Agent Controlled</B></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>Total M3</B></td><td  align=center ><B>Total Retention</B></td></tr>";
                obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "LCL", int_branchid, StrTrantype);
                if (obj_ds.Tables.Count > 0)
                {
                    Tot_1 = 0;
                    Tot_2 = 0;
                    Tot_3 = 0;
                    Tot_4 = 0;
                    Tot_5 = 0;
                    Tot_6 = 0;

                    obj_dttemp = obj_ds.Tables[0];
                    for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {
                        double total_1 = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
                        double total_2 = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
                        Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
                        Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());
                        Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][3].ToString());
                        Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());
                        Tot_5 = Tot_5 + total_1;
                        Tot_6 = Tot_6 + total_2;


                        Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2>" + obj_dttemp.Rows[i][0].ToString() + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][1]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][2]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.000}", obj_dttemp.Rows[i][3]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][4]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", total_1) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", total_2) + "</td></tr>";

                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Tot_Retention = Tot_Retention + Tot_6;
                        Tot_CBM = Tot_CBM + Tot_5;
                        Str_Export = Str_Export + "<tr><td align=right><B>Total</B></td><td  align=center ><B>" + string.Format("{0:0.000}", Tot_1) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_2) + "</B></td><td  align=center ><B>" + string.Format("{0:0.000}", Tot_3) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_4) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_5) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_6) + "</B></td></tr>";
                    }
                    Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                    Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                    Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

                }

                Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Trantype + " - FCL</B></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2><B>Controlled By Us</B></td><td  align=center colspan=2><B>Agent Controlled</B></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>Total M3</B></td><td  align=center ><B>Total Retention</B></td></tr>";
                obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "FCL", int_branchid, StrTrantype);
                if (obj_ds.Tables.Count > 0)
                {
                    Tot_1 = 0;
                    Tot_2 = 0;
                    Tot_3 = 0;
                    Tot_4 = 0;
                    Tot_5 = 0;
                    Tot_6 = 0;

                    obj_dttemp = obj_ds.Tables[0];
                    for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {
                        double total_1 = double.Parse(obj_dttemp.Rows[i][1].ToString()) + double.Parse(obj_dttemp.Rows[i][3].ToString());
                        double total_2 = double.Parse(obj_dttemp.Rows[i][2].ToString()) + double.Parse(obj_dttemp.Rows[i][4].ToString());
                        Tot_1 = Tot_1 + double.Parse(obj_dttemp.Rows[i][1].ToString());
                        Tot_2 = Tot_2 + double.Parse(obj_dttemp.Rows[i][2].ToString());
                        Tot_3 = Tot_3 + double.Parse(obj_dttemp.Rows[i][3].ToString());
                        Tot_4 = Tot_4 + double.Parse(obj_dttemp.Rows[i][4].ToString());
                        Tot_5 = Tot_5 + total_1;
                        Tot_6 = Tot_6 + total_2;


                        Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2>" + obj_dttemp.Rows[i][0].ToString() + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][1]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][2]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.000}", obj_dttemp.Rows[i][3]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][4]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", total_1) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", total_2) + "</td></tr>";

                    }
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Tot_Retention = Tot_Retention + Tot_6;
                        Tot_Tues = Tot_Tues + Tot_5;
                        Str_Export = Str_Export + "<tr><td align=right><B>Total</B></td><td  align=center ><B>" + string.Format("{0:0.000}", Tot_1) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_2) + "</B></td><td  align=center ><B>" + string.Format("{0:0.000}", Tot_3) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_4) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_5) + "</B></td><td  align=center ><B>" + string.Format("{0:0.00}", Tot_6) + "</B></td></tr>";
                    }
                    Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                    Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                    Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

                }

                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>SUMMARY</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>Rentention ( Consol + LCL + FCL )</B></td><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>" + Tot_Retention + "</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>Tues ( Consol + FCL )</B></td><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>" + Tot_Tues + "</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>CBM ( Consol + LCL )</B></td><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>" + Tot_CBM + "</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

                Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Trantype + " - Consol</B></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>Tues</B></td><td  align=center ><B>Retention</B></td></tr>";
                obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "Consol", int_branchid, StrTrantype);
                if (obj_ds.Tables.Count > 0)
                {

                    obj_dttemp = obj_ds.Tables[1];
                    for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {

                        Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2>" + obj_dttemp.Rows[i][0].ToString() + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][1]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][2]) + "</td></tr>";

                    }

                }
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

                Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Trantype + " - LCL</B></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td></tr>";
                obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "LCL", int_branchid, StrTrantype);
                if (obj_ds.Tables.Count > 0)
                {

                    obj_dttemp = obj_ds.Tables[1];
                    for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {

                        Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2>" + obj_dttemp.Rows[i][0].ToString() + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][1]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][2]) + "</td></tr>";

                    }

                }
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

                Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Trantype + " - FCL</B></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>Tues</B></td><td  align=center ><B>Retention</B></td></tr>";
                obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, "FCL", int_branchid, StrTrantype);
                if (obj_ds.Tables.Count > 0)
                {

                    obj_dttemp = obj_ds.Tables[1];
                    for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {

                        Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2>" + obj_dttemp.Rows[i][0].ToString() + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][1]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][2]) + "</td></tr>";

                    }

                }
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

            }
            else if (StrTrantype == "AE" || StrTrantype == "AI")
            {
                Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Trantype + " - Consol</B></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2><B>Controlled By Us</B></td><td  align=center colspan=2><B>Agent Controlled</B></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td></tr>";
                obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, StrTrantype, int_branchid, StrTrantype);
                if (obj_ds.Tables.Count > 0)
                {

                    obj_dttemp = obj_ds.Tables[0];
                    for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {

                        Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2>" + obj_dttemp.Rows[i][0].ToString() + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][1]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][2]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][3]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][4]) + "</td></tr>";

                    }

                }
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

                Str_Export = Str_Export + "<tr><td  align=center colspan=5><B>" + Trantype + " - Consol</B></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2><B>Controlled By Us</B></td><td  align=center colspan=2><B>Agent Controlled</B></td></tr>";
                Str_Export = Str_Export + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td></tr>";
                obj_ds = da_obj_Costing.SelAgentwiseVolume(frm_date, to_date, StrTrantype, int_branchid, StrTrantype);
                if (obj_ds.Tables.Count > 0)
                {

                    obj_dttemp = obj_ds.Tables[0];
                    for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {

                        Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2>" + obj_dttemp.Rows[i][0].ToString() + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][1]) + "</td><td><FONT FACE=tahoma size=2>" + string.Format("{0:0.00}", obj_dttemp.Rows[i][2]) + "</td></tr>";

                    }

                }
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
                Str_Export = Str_Export + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            }

            //Response.Clear();
            //Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");  // Response.Charset = "";
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(Str_Export);
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in Grd_shiperconsignee.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                    {
                        Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00", columnIndex.ToString());
                    }
                }
            }

            foreach (GridViewRow r in grd_operProfit_AC.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                    {
                        Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00", columnIndex.ToString());
                    }
                }
            }

            base.Render(writer);
        }

        protected void grd_Agent_RowDataBound(object sender, GridViewRowEventArgs e)
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
                Label agent = (Label)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("agent");
                if (agent.Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                else if (agent.Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Agent, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void grd_Consignee_RowDataBound(object sender, GridViewRowEventArgs e)
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
                Label Consignee = (Label)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Consignee");
                if (Consignee.Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                else if (Consignee.Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Consignee, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }

        protected void GridClear()
        {
            grd_Agent.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_Agent.DataBind();
            grd_JobwiseCosting.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_JobwiseCosting.DataBind();
            grd_Consignee.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_Consignee.DataBind();
            Grd_nomination.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_nomination.DataBind();
            grd_nomvafree.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_nomvafree.DataBind();
            grd_lossjob.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_lossjob.DataBind();
            Grd_freeVsnomi.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_freeVsnomi.DataBind();
            grd_operProfit.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_operProfit.DataBind();
            grd_operProfit_AC.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_operProfit_AC.DataBind();
            grd_POD.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_POD.DataBind();
            grd_POL.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_POL.DataBind();
            grd_salesperson.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_salesperson.DataBind();
            grd_Shipment.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_Shipment.DataBind();
            Grd_shiperconsignee.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_shiperconsignee.DataBind();
            grd_Shipper.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_Shipper.DataBind();
            grd_YearMIS.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_YearMIS.DataBind();
            Grd_trendcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_trendcustomer.DataBind();
            grd_op.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_op.DataBind();
            Grd_Retention.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Retention.DataBind();
            //grd_details.DataSource = Utility.Fn_GetEmptyDataTable();
            //grd_details.DataBind();
            Grd_MISA.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_MISA.DataBind();
            Grd_MISB.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_MISB.DataBind();
            Grd_MISC.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_MISC.DataBind();
            Grd_MISD.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_MISD.DataBind();
            GRD_Common.DataSource = Utility.Fn_GetEmptyDataTable();
            GRD_Common.DataBind();
            Grd_trendcustomervolume.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_trendcustomervolume.DataBind();
            Gridliner.DataSource = Utility.Fn_GetEmptyDataTable();
            Gridliner.DataBind();
            Gridliner.Visible = false;
            grd_Agent.Visible = false;
            grd_Consignee.Visible = false;
            grd_JobwiseCosting.Visible = false;
            Grd_nomination.Visible = false;
            grd_lossjob.Visible = false;
            Grd_freeVsnomi.Visible = false;
            grd_operProfit.Visible = false;
            grd_POD.Visible = false;
            grd_POL.Visible = false;
            grd_salesperson.Visible = false;
            grd_Shipment.Visible = false;
            Grd_shiperconsignee.Visible = false;
            Grd_shiperconsigneeProduct.Visible = false;
            grd_Shipper.Visible = false;
            Grd_trendcustomer.Visible = false;
            grd_YearMIS.Visible = false;
            GRD_Common.Visible = false;
            Grd_trendcustomervolume.Visible = false;
            grd_op.Visible = false;
            Grd_MISA.Visible = false;
            Grd_MISB.Visible = false;
            Grd_MISC.Visible = false;
            Grd_MISD.Visible = false;
            Grd_Retention.Visible = false;
            GRD_DoRegister.DataSource = Utility.Fn_GetEmptyDataTable();
            GRD_DoRegister.DataBind();
            GRD_CANREPORT.Visible = false;
            GRD_canreportAI.Visible = false;
            GRD_RegisterReport.Visible = false;
            GRD_Forward.DataSource = Utility.Fn_GetEmptyDataTable();
            GRD_Forward.DataBind();
            //GRD_Revenue.DataSource = Utility.Fn_GetEmptyDataTable();
            //GRD_Revenue.DataBind();
            GRD_Revenue.Visible = false;
            Pln_MIS.Visible = false;
        }

        protected void bnt_cancel_Click(object sender, EventArgs e)
        {
            if (bnt_cancel.ToolTip == "Back")
            {
                this.Response.End();
            }

            chartclear();
            ddl_graph1.SelectedIndex = 0;
            ddl_graph1.Enabled = false;
            ddl_graph2.Visible = false;
            lbl_graph2.Visible = false;

            if (GRD_Common.Visible == true)
            {
                GRD_Common.Visible = false;
                if (grd_Agent.Rows.Count > 0)
                {
                    grd_Agent.Visible = true;
                }
                else if (grd_Consignee.Rows.Count > 0)
                {
                    grd_Consignee.Visible = true;
                }
                else if (Grd_nomination.Rows.Count > 0)
                {
                    Grd_nomination.Visible = true;
                }
                else if (Grd_freeVsnomi.Rows.Count > 0)
                {
                    Grd_freeVsnomi.Visible = true;
                }
                else if (grd_JobwiseCosting.Rows.Count > 0)
                {
                    grd_JobwiseCosting.Visible = true;
                }
                else if (grd_lossjob.Rows.Count > 0)
                {
                    grd_lossjob.Visible = true;
                }
                else if (Grd_nomination.Rows.Count > 0)
                {
                    Grd_nomination.Visible = true;
                }
                else if (grd_POD.Rows.Count > 0)
                {
                    grd_POD.Visible = true;
                }
                else if (grd_POL.Rows.Count > 0)
                {
                    grd_POL.Visible = true;
                }
                else if (grd_operProfit.Rows.Count > 0)
                {
                    grd_operProfit.Visible = true;
                }

                else if (grd_salesperson.Rows.Count > 0)
                {
                    grd_salesperson.Visible = true;
                }
                else if (Grd_shiperconsignee.Rows.Count > 0)
                {
                    Grd_shiperconsignee.Visible = true;
                }
                else if (Grd_shiperconsigneeProduct.Rows.Count > 0)
                {
                    Grd_shiperconsigneeProduct.Visible = true;
                }
                else if (grd_Shipper.Rows.Count > 0)
                {
                    grd_Shipper.Visible = true;
                }
                else if (grd_Shipment.Rows.Count > 0)
                {
                    grd_Shipment.Visible = true;
                }
                else if (GRD_DoRegister.Rows.Count > 0)
                {
                    GRD_DoRegister.Visible = true;
                }
                else if (GRD_Forward.Rows.Count > 0)
                {
                    GRD_Forward.Visible = true;
                }
                else if (grd_operProfit_AC.Rows.Count > 0)
                {
                    grd_operProfit_AC.Visible = true;
                }
                else if (Gridliner.Rows.Count > 0)
                {
                    Gridliner.Visible = true;
                }

            }
            else if (grd_op.Visible == true)
            {
                if (grd_operProfit.Rows.Count > 0)
                {
                    grd_operProfit.Visible = true;
                }
            }
            else if (GRD_Common.Visible == false)
            {
                txt_Filter.Text = "";
                //ddl_Report.SelectedIndex = -1;
                txt_From.Text = hf_date.Value;
                txt_To.Text = hf_date.Value;
                // txt_Filter.Enabled = true;
                txt_Filter.Visible = true;
                GridClear();
                lbl_MISA.Visible = false;
                lbl_MISB.Visible = false;
                lbl_MISC.Visible = false;
                lbl_MISD.Visible = false;
             //   bnt_cancel.Text = "Back";

                bnt_cancel.ToolTip = "Back";
                bnt_cancel1.Attributes["class"] = "btn ico-back";

                btn_Export.Enabled = false;
                lbl_retention.Text = "";
                ddl_Report.SelectedIndex = 0;
            }
            else if (grd_op.Visible == false)
            {
                txt_Filter.Text = "";
                //ddl_Report.SelectedIndex = -1;
                txt_From.Text = hf_date.Value;
                txt_To.Text = hf_date.Value;
                //  txt_Filter.Enabled = true;
                txt_Filter.Visible = false;
                GridClear();
                lbl_MISA.Visible = false;
                lbl_MISB.Visible = false;
                lbl_MISC.Visible = false;
                lbl_MISD.Visible = false;
               // bnt_cancel.Text = "Back";

                bnt_cancel.ToolTip = "Back";
                bnt_cancel1.Attributes["class"] = "btn ico-back";
                lbl_retention.Text = "";
                ddl_Report.SelectedIndex = -1;
                btn_Export.Enabled = true;
            }
            else if (bnt_cancel.ToolTip == "Cancel")
            {
                txt_Filter.Text = "";
                //ddl_Report.SelectedIndex = -1;
                txt_From.Text = hf_date.Value;
                txt_To.Text = hf_date.Value;
                //      txt_Filter.Enabled = true;
                txt_Filter.Visible = true;
                GridClear();
                lbl_MISA.Visible = false;
                lbl_MISB.Visible = false;
                lbl_MISC.Visible = false;
                lbl_MISD.Visible = false;
               // bnt_cancel.Text = "Back";


                bnt_cancel.ToolTip = "Back";
                bnt_cancel1.Attributes["class"] = "btn ico-back";

                lbl_retention.Text = "";
                ddl_Report.SelectedIndex = -1;
                btn_Export.Enabled = false;
            }


        }

        protected void GRD_Common_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int h = 3; h < e.Row.Cells.Count; h++)
                {
                    if (e.Row.Cells[h].Text == "Volume")
                    {
                        e.Row.Cells[h].Text = "CBM/Kgs";
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                    else if (e.Row.Cells[h].Text == "Cont 20")
                    {
                        e.Row.Cells[h].Text = "20";
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                    else if (e.Row.Cells[h].Text == "Cont 40")
                    {
                        e.Row.Cells[h].Text = "40";
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                    else if (e.Row.Cells[h].Text == "Income")
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                    else if (e.Row.Cells[h].Text == "Expense")
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                    else if (e.Row.Cells[h].Text == "Retention")
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (e.Row.Cells[h].Text == "Trantype")
                    {
                        e.Row.Cells[h].Attributes.CssStyle["display"] = "none";
                    }
                }

                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //if (e.Row.Cells[0].Text.ToString().Replace("&nbsp;", "").Trim() != "" || e.Row.Cells[1].Text.ToString().Replace("&nbsp;", "").Trim() != "")
                //{
                //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GRD_Common, "Select$" + e.Row.RowIndex);
                //    e.Row.Attributes["style"] = "cursor:pointer";
                //}
            }

            if (ddl_Report.SelectedItem.Text == "Agentwise" || ddl_Report.SelectedItem.Text == "Consigneewise" || ddl_Report.SelectedItem.Text == "Port Of Loading" ||
                ddl_Report.SelectedItem.Text == "LinerWise" || ddl_Report.SelectedItem.Text == "Shipperwise" || ddl_Report.SelectedItem.Text == "FreeHand" || ddl_Report.SelectedItem.Text == "Loss Jobs"
                || ddl_Report.SelectedItem.Text == "Jobwise Costing" || ddl_Report.SelectedItem.Text == "Nomination" || ddl_Report.SelectedItem.Text == "Port Of Discharge"
                || ddl_Report.SelectedItem.Text == "Sales Person" || ddl_Report.SelectedItem.Text == "Shipment Details" || ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
            {
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int h = 3; h < e.Row.Cells.Count; h++)
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }

                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //if (e.Row.Cells[1].Text.ToString().Replace("&nbsp;", "").Trim() != "")
                //{
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GRD_Common, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                //}

                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                int i;
                if (ddl_Report.SelectedItem.Text == "Operating Profit")
                {
                    i = 3;
                }
                else
                {
                    i = 6;
                }
                for (int h = i; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (e.Row.Cells[h].Text == "AE" || e.Row.Cells[h].Text == "AI" || e.Row.Cells[h].Text == "OE" || e.Row.Cells[h].Text == "OI" || e.Row.Cells[h].Text == "CH" || e.Row.Cells[h].Text == "BT")
                    {
                        e.Row.Cells[h].Attributes.CssStyle["display"] = "none";
                    }
                }
                if (e.Row.Cells[0].Text.ToString().Replace("&nbsp;", "").Trim() == "" || e.Row.Cells[1].Text.ToString().Replace("&nbsp;", "").Trim() == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }

            }
        }

        protected void GRD_Common_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bnt_cancel.Focus();
                int int_jobno = 0;
                string str_trantype = "", str_Script = "", trantype = "";
                str_trantype = Session["StrTranType"].ToString();

                if (ddl_Report.SelectedItem.Text == "Jobwise Costing")
                {
                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[0].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedRow.Cells[12].Text.ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Shipment Details")
                {

                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Shipperwise")
                {

                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Consigneewise")
                {

                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Agentwise")
                {

                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Sales Person")
                {

                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Nomination")
                {

                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "FreeHand")
                {

                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Port Of Loading")
                {

                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Port Of Discharge")
                {
                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Loss Jobs")
                {
                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[0].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }

                }
                else if (ddl_Report.SelectedItem.Text == "DO Register")
                {
                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Top 50 Shipper / Consignee")
                {
                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Operating Profit")
                {
                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                else if (ddl_Report.SelectedItem.Text == "Nomination Vs Freehand")
                {
                    int_jobno = int.Parse(GRD_Common.SelectedRow.Cells[1].Text.ToString());
                    Session["jobno"] = int_jobno;
                    if (str_trantype == "AC")
                    {
                        trantype = GRD_Common.SelectedDataKey.Values[0].ToString();
                    }
                }
                if (int_jobno == 0)
                {
                    return;
                }
                else
                {
                    if (str_trantype == "AC")
                    {
                        Session["trantype"] = trantype;
                    }
                    else
                    {
                        Session["trantype"] = str_trantype;
                    }
                    Session["Budget"] = null;
                    Session["Budget"] = "MIS";
                  /*  str_Script = "window.open('../FormMain.aspx');";
                    //str_Script = "window.open('../ForwardExports/CostingDetails.aspx');";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", str_Script, true);*/

                    this.popuprate.Show();
                    Panel3.Visible = true;
                    iframe_buyratequery.Attributes["src"] = "../ForwardExports/CostingDetails.aspx";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void GRD_Common_RowCreated(object sender, GridViewRowEventArgs e)
        {
            {
                GridViewRow row = e.Row;
                List<TableCell> columns = new List<TableCell>();
                foreach (DataControlField column in GRD_Common.Columns)
                {
                    TableCell cell = row.Cells[0];
                    row.Cells.Remove(cell);
                    columns.Add(cell);
                }
                row.Cells.AddRange(columns.ToArray());
            }
        }

        protected void Grd_freeVsnomi_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;

                }
                if (e.Row.Cells[1].Text == "")
                {

                }
                if (e.Row.Cells[1].Text != "Total" || e.Row.Cells[0].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_freeVsnomi, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void Grd_freeVsnomi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_freeVSNomi();
        }
        protected void Load_freeVSNomi()
        {
            DataTable dtcell = new DataTable();
            DataTable dtNew = new DataTable();
            DataAccess.MISGrd misgrdobj = new DataAccess.MISGrd();
            int int_branchid = int.Parse(Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int index, jobno, branchid = 0, intjobtype = 0;
            string Product, jobtype = "", trantype = "", tran = "";

            string transtype = HttpContext.Current.Session["StrTranType"].ToString();
            index = Grd_freeVsnomi.SelectedRow.RowIndex;
            if (Grd_freeVsnomi.Rows.Count > 0)
            {
                bnt_cancel.Focus();
                Product = Grd_freeVsnomi.Rows[index].Cells[0].Text;
                hf_tran.Value = Product;
                if (Product == "Air Imports  ")
                {
                    intjobtype = 0;
                    trantype = "Air Imports  ";
                }
                else if (Product == "Air Exports  ")
                {
                    intjobtype = 0;
                    trantype = "Air Exports  ";
                }
                else
                {
                    trantype = Product.Substring(0, 14);
                    if (trantype == "Ocean Exports ")
                    {
                        if (Product.Substring(14) == "FCL")
                        {
                            jobtype = Product.Substring(14, 3);
                        }
                        else if (Product.Substring(15) == "LCL")
                        {
                            jobtype = Product.Substring(15, 3);
                        }
                        else if (Product.Substring(14) == "Consol")
                        {
                            jobtype = Product.Substring(14, 6);
                        }

                    }
                    else
                    {
                        if (Product.Substring(14) == "FCL")
                        {
                            jobtype = Product.Substring(14, 3);
                        }
                        else if (Product.Substring(14) == "LCL")
                        {
                            jobtype = Product.Substring(14, 3);
                        }
                        else if (Product.Substring(14) == "Consol")
                        {
                            jobtype = Product.Substring(14, 6);
                        }
                    }
                }

                if (trantype == "Air Imports  ")
                {
                    tran = "AI";
                }
                if (trantype == "Air Exports  ")
                {
                    tran = "AE";
                }
                if (trantype == "Ocean Exports ")
                {
                    tran = "FE";
                }
                if (trantype == "Ocean Imports ")
                {
                    tran = "FI";
                }
                if (trantype == "C H A")
                {
                    tran = "CH";
                }
                if (trantype == "Data WareHousing")
                {
                    tran = "FC";
                }

                if (jobtype == "Consol")
                {
                    intjobtype = 1;
                }
                else if (jobtype == "FCL")
                {
                    intjobtype = 3;
                }
                else if (jobtype == "BuyerConsol")
                {
                    intjobtype = 5;
                }
                else if (jobtype == "MCC")
                {
                    intjobtype = 4;
                }
                else if (jobtype == "LCL")
                {
                    intjobtype = 2;
                }
            }

            dtcell = misgrdobj.GetNVsFFromJobtype(tran, int_branchid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), intjobtype);



            if (dtcell.Rows.Count > 0)
            {
                //this.popup.Show();
                Grd_freeVsnomi.Visible = false;
                double totalgrand40 = 0, totalgrand20 = 0, totalgrandvou = 0, totalincomegrand = 0, totalexpensegrand = 0, totalretentiongrand = 0;
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("trantype");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Nomination");
                dtemptyfree.Columns.Add("Volume");
                dtemptyfree.Columns.Add("Cont 20");
                dtemptyfree.Columns.Add("Cont 40");
                dtemptyfree.Columns.Add("Income");
                dtemptyfree.Columns.Add("Expense");
                dtemptyfree.Columns.Add("Retention");
                dtemptyfree.Columns.Add("Branch");
                dtemptyfree.Columns.Add("branchid");

                DataView dv_co = new DataView(dtcell);
                dtNew = dv_co.ToTable(true, "trantype");
                dv_co = new DataView(dtNew);
                dv_co.Sort = "trantype";
                dtNew = dv_co.ToTable();
                DataRow dr = dtemptyfree.NewRow();
                for (int j = 0; j <= dtNew.Rows.Count - 1; j++)
                {
                    double totalincome = 0, totalexpense = 0, totalretention = 0, total20 = 0, total40 = 0, totalvou = 0;
                    DataTable dtLi = new DataTable();
                    DataView data1 = dtcell.DefaultView;
                    data1.RowFilter = "trantype = '" + dtNew.Rows[j]["trantype"] + "' ";
                    dtLi = data1.ToTable();
                    // count1=dtLi.Rows.Count;
                    if (dtLi.Rows.Count > 0)
                    {

                        dr = dtemptyfree.NewRow();
                        dr["trantype"] = hf_tran.Value;


                        dtemptyfree.Rows.Add(dr);



                        for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {

                            dr = dtemptyfree.NewRow();
                            dtemptyfree.Rows.Add();
                            int count = dtemptyfree.Rows.Count - 1;
                            dtemptyfree.Rows[count]["trantype"] = dtLi.Rows[i]["trantype"].ToString();
                            dtemptyfree.Rows[count]["Job #"] = dtLi.Rows[i]["jobno"].ToString();
                            dtemptyfree.Rows[count]["Nomination"] = dtLi.Rows[i]["nomination"].ToString();
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["volume"].ToString());
                            dtemptyfree.Rows[count]["Volume"] = temp2.ToString("#,0.00");
                            totalvou = totalvou + Convert.ToDouble(dtemptyfree.Rows[count]["volume"].ToString());
                            dtemptyfree.Rows[count]["Cont 20"] = dtLi.Rows[i]["cont20"].ToString();
                            total20 = total20 + Convert.ToDouble(dtLi.Rows[i]["cont20"].ToString());
                            dtemptyfree.Rows[count]["Cont 40"] = dtLi.Rows[i]["cont40"].ToString();
                            total40 = total40 + Convert.ToDouble(dtLi.Rows[i]["cont40"].ToString());
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["income"].ToString());
                            dtemptyfree.Rows[count]["Income"] = temp2.ToString("#,0.00");

                            totalincome = totalincome + Convert.ToDouble(dtemptyfree.Rows[count]["income"].ToString());
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["expense"].ToString());
                            dtemptyfree.Rows[count]["Expense"] = temp2.ToString("#,0.00");

                            totalexpense = totalexpense + Convert.ToDouble(dtemptyfree.Rows[count]["expense"].ToString());
                            temp2 = Convert.ToDouble(dtLi.Rows[i]["retention"].ToString());
                            dtemptyfree.Rows[count]["Retention"] = temp2.ToString("#,0.00");

                            totalretention = totalretention + Convert.ToDouble(dtemptyfree.Rows[count]["retention"].ToString());
                            dtemptyfree.Rows[count]["Branch"] = dtLi.Rows[i]["branch"].ToString();
                            dtemptyfree.Rows[count]["branchid"] = dtLi.Rows[i]["branchid"].ToString();
                            //dtemptyfree.Rows.Add(dr);
                        }


                        dr = dtemptyfree.NewRow();
                        dr["Nomination"] = dtNew.Rows[j]["trantype"] + "-" + "Total";
                        dr["Volume"] = totalvou.ToString("#,0.00");
                        dr["Cont 20"] = total20;
                        dr["Cont 40"] = total40;
                        dr["Income"] = totalincome.ToString("#,0.00");
                        dr["Expense"] = totalexpense.ToString("#,0.00");
                        dr["Retention"] = totalretention.ToString("#,0.00");
                    }
                    dtemptyfree.Rows.Add(dr);


                }
                dtemptyfree.Columns.RemoveAt(dtemptyfree.Columns.Count - 1);
                dtemptyfree.Columns.RemoveAt(dtemptyfree.Columns.Count - 1);
                GRD_Common.DataSource = dtemptyfree;
                GRD_Common.DataBind();
                GRD_Common.HeaderRow.Cells[0].Text = "Product";
                GRD_Common.HeaderRow.Cells[4].Text = "Cont 20";
                GRD_Common.HeaderRow.Cells[5].Text = "Cont 40";
                GRD_Common.Visible = true;
             //   bnt_cancel.Text = "Cancel";

                bnt_cancel.ToolTip = "Cancel";
                bnt_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void Grd_trendcustomervolume_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }

                for (int h = 3; h < e.Row.Cells.Count; h++)
                {
                    e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                }

            }
        }

        protected void GRD_DoRegister_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[1].Text == "")
                {


                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                else if (e.Row.Cells[1].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GRD_DoRegister, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }

        protected void GRD_DoRegister_SelectedIndexChanged(object sender, EventArgs e)
        {

            string transtype = HttpContext.Current.Session["StrTranType"].ToString();
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            string jobtype = "";
            if (GRD_DoRegister.Rows.Count > 0)
            {
                bnt_cancel.Focus();

                int int_jobno = 0;
                int index = GRD_DoRegister.SelectedRow.RowIndex;
                if (GRD_DoRegister.Rows[index].Cells[2].Text != null)
                {
                    int_jobno = Convert.ToInt32(GRD_DoRegister.Rows[index].Cells[2].Text);
                }

                //int int_bid = Convert.ToInt32(grd_JobwiseCosting.Rows[index].Cells[9].Text);


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetshipmentDetailsfromjobno(transtype, int_bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_jobno, did, "");
                if (obj_dtjob.Rows.Count > 0)
                {
                    GRD_DoRegister.Visible = false;
                    if (transtype != "CH")
                    {
                        obj_dt.Columns.Add("trantype", typeof(string));
                        obj_dt.Columns.Add("Job #", typeof(string));
                        obj_dt.Columns.Add("Job type", typeof(string));
                        obj_dt.Columns.Add("BL #", typeof(string));
                        obj_dt.Columns.Add("Nomination", typeof(string));
                        obj_dt.Columns.Add("Shipper", typeof(string));
                        obj_dt.Columns.Add("Consignee", typeof(string));
                        obj_dt.Columns.Add("Agent", typeof(string));
                        obj_dt.Columns.Add("PoL", typeof(string));
                        obj_dt.Columns.Add("PoD", typeof(string));
                        obj_dt.Columns.Add("Volume", typeof(string));
                        obj_dt.Columns.Add("Cont 20", typeof(string));
                        obj_dt.Columns.Add("Cont 40", typeof(string));
                        obj_dt.Columns.Add("Income", typeof(string));
                        obj_dt.Columns.Add("Expense", typeof(string));
                        obj_dt.Columns.Add("Retention", typeof(string));
                        //obj_dt.Columns.Add("TranType", typeof(string));
                    }
                    else
                    {
                        obj_dt.Columns.Add("trantype", typeof(string));
                        obj_dt.Columns.Add("Job #", typeof(string));
                        obj_dt.Columns.Add("Job type", typeof(string));
                        obj_dt.Columns.Add("Doc #", typeof(string));
                        obj_dt.Columns.Add("Nomination", typeof(string));
                        obj_dt.Columns.Add("Shipper", typeof(string));
                        obj_dt.Columns.Add("Consignee", typeof(string));
                        obj_dt.Columns.Add("Agent", typeof(string));
                        obj_dt.Columns.Add("PoL", typeof(string));
                        obj_dt.Columns.Add("PoD", typeof(string));
                        obj_dt.Columns.Add("Net Wt", typeof(string));
                        obj_dt.Columns.Add("Cont 20", typeof(string));
                        obj_dt.Columns.Add("Cont 40", typeof(string));
                        obj_dt.Columns.Add("Income", typeof(string));
                        obj_dt.Columns.Add("Expense", typeof(string));
                        obj_dt.Columns.Add("Retention", typeof(string));
                    }


                    for (int i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        int int_jobtype = Convert.ToInt32(obj_dtjob.Rows[i]["jobtype"]);
                        if (int_jobtype == 1)
                        {
                            jobtype = "Consol";
                        }
                        else if (int_jobtype == 2)
                        {
                            jobtype = "Co-Load";
                        }
                        else if (int_jobtype == 3)
                        {
                            jobtype = "FCL";
                        }
                        else if (int_jobtype == 4)
                        {
                            jobtype = "MCC";
                        }
                        else if (int_jobtype == 5)
                        {
                            jobtype = "Buyer Consol";
                        }

                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[2] = jobtype;
                        dr[3] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["Nomination"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["shipper"];
                        dr[6] = obj_dtjob.Rows[i]["Consignee"];
                        dr[7] = obj_dtjob.Rows[i]["agent"];
                        dr[8] = obj_dtjob.Rows[i]["pol"];
                        dr[9] = obj_dtjob.Rows[i]["pod"];
                        dr[10] = obj_dtjob.Rows[i]["volume"];
                        dr[11] = obj_dtjob.Rows[i]["cont20"];
                        dr[12] = obj_dtjob.Rows[i]["cont40"];
                        dr[13] = obj_dtjob.Rows[i]["income"];
                        dr[14] = obj_dtjob.Rows[i]["expense"];
                        dr[15] = obj_dtjob.Rows[i]["retention"];

                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[9] = "Total";
                    dr1[10] = sum_volume;
                    dr1[11] = sum_cont20;
                    dr1[12] = sum_cont40;
                    dr1[13] = sum_income;
                    dr1[14] = sum_expense;
                    dr1[15] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                    GRD_Common.HeaderRow.Cells[0].Text = "Product";
                   // bnt_cancel.Text = "Cancel";


                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";

                }

            }
        }

        protected void GRD_Forward_SelectedIndexChanged(object sender, EventArgs e)
        {
            string transtype = HttpContext.Current.Session["StrTranType"].ToString();
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            string jobtype = "";
            if (GRD_Forward.Rows.Count > 0)
            {
                bnt_cancel.Focus();

                int int_jobno = 0;
                int index = GRD_Forward.SelectedRow.RowIndex;
                if (GRD_Forward.Rows[index].Cells[0].Text != null)
                {
                    int_jobno = Convert.ToInt32(GRD_Forward.Rows[index].Cells[0].Text);
                }

                //int int_bid = Convert.ToInt32(grd_JobwiseCosting.Rows[index].Cells[9].Text);


                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                obj_dtjob = da_obj_misgrd.GetshipmentDetailsfromjobno(transtype, int_bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_jobno, did, "");
                if (obj_dtjob.Rows.Count > 0)
                {
                    GRD_Forward.Visible = false;
                    obj_dt.Columns.Add("trantype", typeof(string));
                    obj_dt.Columns.Add("Job #", typeof(string));
                    obj_dt.Columns.Add("Job type", typeof(string));
                    obj_dt.Columns.Add("BL #", typeof(string));
                    obj_dt.Columns.Add("Nomination", typeof(string));
                    obj_dt.Columns.Add("Shipper", typeof(string));
                    obj_dt.Columns.Add("Consignee", typeof(string));
                    obj_dt.Columns.Add("Agent", typeof(string));
                    obj_dt.Columns.Add("PoL", typeof(string));
                    obj_dt.Columns.Add("PoD", typeof(string));
                    obj_dt.Columns.Add("Volume", typeof(string));
                    obj_dt.Columns.Add("Cont 20", typeof(string));
                    obj_dt.Columns.Add("Cont 40", typeof(string));
                    obj_dt.Columns.Add("Income", typeof(string));
                    obj_dt.Columns.Add("Expense", typeof(string));
                    obj_dt.Columns.Add("Retention", typeof(string));




                    for (int i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        int int_jobtype = Convert.ToInt32(obj_dtjob.Rows[i]["jobtype"]);
                        if (int_jobtype == 1)
                        {
                            jobtype = "Consol";
                        }
                        else if (int_jobtype == 2)
                        {
                            jobtype = "Co-Load";
                        }
                        else if (int_jobtype == 3)
                        {
                            jobtype = "FCL";
                        }
                        else if (int_jobtype == 4)
                        {
                            jobtype = "MCC";
                        }
                        else if (int_jobtype == 5)
                        {
                            jobtype = "Buyer Consol";
                        }

                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[2] = jobtype;
                        dr[3] = obj_dtjob.Rows[i]["blno"].ToString();
                        dr[4] = obj_dtjob.Rows[i]["Nomination"].ToString();
                        dr[5] = obj_dtjob.Rows[i]["shipper"];
                        dr[6] = obj_dtjob.Rows[i]["Consignee"];
                        dr[7] = obj_dtjob.Rows[i]["agent"];
                        dr[8] = obj_dtjob.Rows[i]["pol"];
                        dr[9] = obj_dtjob.Rows[i]["pod"];
                        dr[10] = obj_dtjob.Rows[i]["volume"];
                        dr[11] = obj_dtjob.Rows[i]["cont20"];
                        dr[12] = obj_dtjob.Rows[i]["cont40"];
                        dr[13] = obj_dtjob.Rows[i]["income"];
                        dr[14] = obj_dtjob.Rows[i]["expense"];
                        dr[15] = obj_dtjob.Rows[i]["retention"];

                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[9] = "Total";
                    dr1[10] = sum_volume;
                    dr1[11] = sum_cont20;
                    dr1[12] = sum_cont40;
                    dr1[13] = sum_income;
                    dr1[14] = sum_expense;
                    dr1[15] = sum_retention;
                    GRD_Common.Visible = true;
                    //obj_dt.Columns.RemoveAt(obj_dt.Columns.Count - 1);
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                    GRD_Common.HeaderRow.Cells[0].Text = "Product";
                    //bnt_cancel.Text = "Cancel";
                    bnt_cancel.ToolTip = "Cancel";
                    bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                }

            }
        }

        protected void GRD_Forward_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                else if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GRD_Forward, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }

        protected void GRD_Revenue_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[4].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }

            }
        }

        protected void grd_operProfit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index, cindex, selectedColumnIndex = 0, selectedRowIndex = 0;
                string st = "";
                if (e.CommandName.ToString() == "ColumnClick")
                {
                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    Session["cellindexOP"] = selectedColumnIndex;
                    string text = grd_operProfit.Columns[selectedColumnIndex].HeaderText;
                    Session["HeadOP"] = text;
                }
                if (grd_operProfit.Rows.Count > 1)
                {
                    index = selectedRowIndex;
                    cindex = selectedColumnIndex;
                    int gridViewCellCount = grd_operProfit.Rows[0].Cells.Count;
                    st = grd_operProfit.Columns[selectedColumnIndex].HeaderText;
                    if (st != "")
                    {
                        Load_opertaionpro();
                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            hd_op.Value = hd_op.Value;
        }

        protected void grd_operProfit_AC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedRowIndex1, selectedColumnIndex1;
                if (e.CommandName.ToString() == "ColumnClickNew")
                {
                    bnt_cancel.Focus();
                    selectedRowIndex1 = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex1 = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    Session["cellindexOP"] = selectedColumnIndex1;
                    string text = grd_operProfit_AC.Columns[selectedColumnIndex1].HeaderText;
                    Session["HeadOP"] = text;
                    if (selectedRowIndex1 == 1 || text == "Total")
                    {
                        return;
                    }
                    Load_opertaionpro();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grd_operProfit_AC_RowDataBound(object sender, GridViewRowEventArgs e)
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

                LinkButton _singleClickButton1 = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton1, "");
                // Add events to each editable cell
                if (e.Row.Cells[0].Text != "Total")
                {
                    for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                    {
                        // Add the column index as the event argument parameter
                        string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                        // Add this javascript to the onclick Attribute of the cell
                        e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                        // Add a cursor style to the cells
                        e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                        //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_operProfit_AC, "" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }



                    for (int h = 2; h < e.Row.Cells.Count; h++)
                    {
                        double dbl_temp = 0;
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }
                }
                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    for (int h = 2; h < e.Row.Cells.Count; h++)
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void grd_operProfit_AC_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            List<TableCell> columns = new List<TableCell>();
            foreach (DataControlField column in grd_operProfit_AC.Columns)
            {
                TableCell cell = row.Cells[0];
                row.Cells.Remove(cell);
                columns.Add(cell);
            }
            row.Cells.AddRange(columns.ToArray());
        }

        protected void grd_operProfit_AC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load_opertaionpro();
        }

        protected void Gridliner_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[1].Text == "")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                } if (e.Row.Cells[1].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Gridliner, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void Gridliner_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (Gridliner.Rows.Count > 0)
                {
                    bnt_cancel.Focus();
                    int i;
                    int int_jobno = Convert.ToInt32(Gridliner.SelectedRow.Cells[1].Text);
                    //int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    int int_bid = Convert.ToInt32(Gridliner.SelectedDataKey.Values[1].ToString());

                    DataTable obj_dt = new DataTable();
                    DataTable obj_dtjob = new DataTable();
                    string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                    DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                    obj_dtjob = da_obj_misgrd.GetshipmentDetailsfromjobno(Gridliner.SelectedDataKey.Values[0].ToString(), int_bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_jobno, Convert.ToInt32(Session["LoginDivisionId"].ToString()), " ");
                    if (obj_dtjob.Rows.Count > 0)
                    {
                        Gridliner.Visible = false;
                        if (Session["StrTranType"].ToString() != "CH")
                        {

                            obj_dt.Columns.Add("Product", typeof(string));
                            obj_dt.Columns.Add("Job #", typeof(string));
                            obj_dt.Columns.Add("Job type", typeof(string));
                            obj_dt.Columns.Add("BL #", typeof(string));
                            obj_dt.Columns.Add("Nomination", typeof(string));
                            obj_dt.Columns.Add("Shipper", typeof(string));
                            obj_dt.Columns.Add("Consignee", typeof(string));
                            obj_dt.Columns.Add("Agent", typeof(string));
                            obj_dt.Columns.Add("PoL", typeof(string));
                            obj_dt.Columns.Add("PoD", typeof(string));
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add("Trantype", typeof(string));
                        }
                        else
                        {

                            obj_dt.Columns.Add("Product", typeof(string));
                            obj_dt.Columns.Add("Job #", typeof(string));
                            obj_dt.Columns.Add("Job type", typeof(string));
                            obj_dt.Columns.Add("Doc #", typeof(string));
                            obj_dt.Columns.Add("Nomination", typeof(string));
                            obj_dt.Columns.Add("Shipper", typeof(string));
                            obj_dt.Columns.Add("Consignee", typeof(string));
                            obj_dt.Columns.Add("Agent", typeof(string));
                            obj_dt.Columns.Add("PoL", typeof(string));
                            obj_dt.Columns.Add("PoD", typeof(string));
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Net wt", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                            obj_dt.Columns.Add("Trantype", typeof(string));
                        }

                        for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                        {
                            DataRow dr = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr);
                            if (obj_dtjob.Rows[i]["jobtype"].ToString() == "1")
                            {
                                dr[2] = "Consol";
                            }
                            else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "2")
                            {
                                dr[2] = "Co-Load";
                            }
                            else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "3")
                            {
                                dr[2] = "FCL";
                            }
                            else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "4")
                            {
                                dr[2] = "MCC";
                            }
                            else if (obj_dtjob.Rows[i]["jobtype"].ToString() == "5")
                            {
                                dr[2] = "Buyer Consol";
                            }

                            dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                            dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                            dr[3] = obj_dtjob.Rows[i]["blno"].ToString();
                            dr[4] = obj_dtjob.Rows[i]["Nomination"].ToString();
                            dr[5] = obj_dtjob.Rows[i]["shipper"].ToString();
                            dr[6] = obj_dtjob.Rows[i]["Consignee"].ToString();
                            dr[7] = obj_dtjob.Rows[i]["agent"].ToString();
                            dr[8] = obj_dtjob.Rows[i]["pol"].ToString();
                            dr[9] = obj_dtjob.Rows[i]["pod"].ToString();
                            dr[10] = obj_dtjob.Rows[i]["volume"].ToString();
                            dr[11] = obj_dtjob.Rows[i]["cont20"].ToString();
                            dr[12] = obj_dtjob.Rows[i]["cont40"].ToString();
                            dr[13] = obj_dtjob.Rows[i]["income"].ToString();
                            dr[14] = obj_dtjob.Rows[i]["expense"].ToString();
                            dr[15] = obj_dtjob.Rows[i]["retention"].ToString();
                            dr[16] = obj_dtjob.Rows[i]["trantype"].ToString();
                        }
                        var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                        var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                        var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                        var sum_income = obj_dtjob.Compute("sum(Income)", "");
                        var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                        var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                        DataRow dr1 = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr1);
                        dr1[9] = "Total";
                        dr1[10] = sum_volume;
                        dr1[11] = sum_cont20;
                        dr1[12] = sum_cont40;
                        dr1[13] = sum_income;
                        dr1[14] = sum_expense;
                        dr1[15] = sum_retention;
                        GRD_Common.Visible = true;
                        GRD_Common.DataSource = obj_dt;
                        GRD_Common.DataBind();
                       // bnt_cancel.Text = "Cancel";


                        bnt_cancel.ToolTip = "Cancel";
                        bnt_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdyear_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string hex = "#dbdbdb";
            string hexfore = "#4e4c4c";

            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridView HeaderGrid = (GridView)sender;
                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    HeaderGridRow.Font.Bold = true;
                    //HeaderGridRow.CssClass = "clsgridback";

                    TableCell HeaderCell = new TableCell();
                    HeaderCell.Text = "Year";
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Size = 10;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.ColumnSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);



                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Previous Year";
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Size = 10;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.ColumnSpan = 4;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Current Year";
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Size = 10;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.ColumnSpan = 4;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    grdyear.Controls[0].Controls.AddAt(0, HeaderGridRow);

                    GridView HeaderGrid2 = (GridView)sender;
                    GridViewRow HeaderGridRow2 = new GridViewRow(2, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    //HeaderGridRow2.BorderColor = System.Drawing.Color.Black;
                    HeaderGridRow2.Font.Bold = true;
                    // HeaderGridRow2.CssClass = "clsgridback";

                    TableCell HeaderCell12 = new TableCell();
                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "Month";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "Branch";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "CBM";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "Teus";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "Weight";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "Retention";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "CBM";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "Teus";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "Weight";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    HeaderCell12 = new TableCell();
                    HeaderCell12.Text = "Retention";
                    HeaderCell12.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell12.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell12.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell12.Font.Size = 10;
                    HeaderGridRow2.Cells.Add(HeaderCell12);

                    grdyear.Controls[0].Controls.AddAt(1, HeaderGridRow2);

                }
            }
            catch
            {

            }
        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportDDL();
            GridClear();
        }

        protected void Grd_shiperconsigneeProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grd_shiperconsigneeProduct.Rows.Count > 1)
            {
                bnt_cancel.Focus();
                int int_shipperid, i;
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                int_shipperid = da_obj_Customer.GetCustomerIdFrmName(Grd_shiperconsigneeProduct.SelectedRow.Cells[0].Text.ToString().Replace("&amp;", "&"));
                int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                string trantype = Session["StrTranType"].ToString();
                DataTable obj_dt = new DataTable();
                DataTable obj_dtjob = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_From.Text);
                string str_todate = Utility.fn_ConvertDate(txt_To.Text);
                DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                if (trantype == "FE" || trantype == "AE")
                {
                    obj_dtjob = da_obj_misgrd.GetshipmentDetails4Shipper(int_shipperid, bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), trantype, did);
                }
                else if (trantype == "FI" || trantype == "AI" || trantype == "FC")
                {
                    obj_dtjob = da_obj_misgrd.GetshipmentDetails4Consignee(int_shipperid, bid, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), trantype, did);
                }
                if (obj_dtjob.Rows.Count > 0)
                {
                    Grd_shiperconsigneeProduct.Visible = false;
                    if (Session["StrTranType"].ToString() != "CH")
                    {
                        obj_dt.Columns.Add("TranType", typeof(string));
                        obj_dt.Columns.Add("Job #", typeof(string));
                        obj_dt.Columns.Add("BL #", typeof(string));
                        obj_dt.Columns.Add("Shipper", typeof(string));
                        obj_dt.Columns.Add("Consignee", typeof(string));
                        obj_dt.Columns.Add("PoL", typeof(string));
                        obj_dt.Columns.Add("PoD", typeof(string));
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Volume", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                    }
                    else
                    {
                        obj_dt.Columns.Add("TranType", typeof(string));
                        obj_dt.Columns.Add("Job #", typeof(string));
                        obj_dt.Columns.Add("Doc #", typeof(string));
                        obj_dt.Columns.Add("Shipper", typeof(string));
                        obj_dt.Columns.Add("Consignee", typeof(string));
                        obj_dt.Columns.Add("PoL", typeof(string));
                        obj_dt.Columns.Add("PoD", typeof(string));
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Net wt", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 20", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Cont 40", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Income", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Expense", DataType = typeof(string), DefaultValue = 0 });
                        obj_dt.Columns.Add(new DataColumn { ColumnName = "Retention", DataType = typeof(string), DefaultValue = 0 });
                    }

                    for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                    {
                        DataRow dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);


                        dr[0] = obj_dtjob.Rows[i]["trantype"].ToString();
                        dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                        dr[2] = obj_dtjob.Rows[i]["blno"].ToString();

                        dr[3] = Grd_shiperconsigneeProduct.SelectedRow.Cells[0].Text.ToString();
                        if (trantype == "FE" || trantype == "AE")
                        {
                            dr[4] = obj_dtjob.Rows[i]["consignee"].ToString();
                        }
                        else if (trantype == "FI" || trantype == "AI" || trantype == "FC")
                        {
                            dr[4] = obj_dtjob.Rows[i]["shipper"].ToString();
                        }

                        dr[5] = obj_dtjob.Rows[i]["pol"].ToString();
                        dr[6] = obj_dtjob.Rows[i]["pod"].ToString();
                        dr[7] = obj_dtjob.Rows[i]["volume"].ToString();
                        dr[8] = obj_dtjob.Rows[i]["cont20"].ToString();
                        dr[9] = obj_dtjob.Rows[i]["cont40"].ToString();
                        dr[10] = obj_dtjob.Rows[i]["income"].ToString();
                        dr[11] = obj_dtjob.Rows[i]["expense"].ToString();
                        dr[12] = obj_dtjob.Rows[i]["retention"].ToString();
                    }
                    var sum_volume = obj_dtjob.Compute("sum(Volume)", "");
                    var sum_cont20 = obj_dtjob.Compute("sum(cont20)", "");
                    var sum_cont40 = obj_dtjob.Compute("sum(cont40)", "");
                    var sum_income = obj_dtjob.Compute("sum(Income)", "");
                    var sum_expense = obj_dtjob.Compute("sum(Expense)", "");
                    var sum_retention = obj_dtjob.Compute("sum(Retention)", "");
                    DataRow dr1 = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr1);
                    dr1[6] = "Total";
                    dr1[7] = sum_volume;
                    dr1[8] = sum_cont20;
                    dr1[9] = sum_cont40;
                    dr1[10] = sum_income;
                    dr1[11] = sum_expense;
                    dr1[12] = sum_retention;
                    GRD_Common.Visible = true;
                    GRD_Common.DataSource = obj_dt;
                    GRD_Common.DataBind();
                }
            }
        }

        protected void Grd_shiperconsigneeProduct_RowDataBound(object sender, GridViewRowEventArgs e)
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

                double dbl_temp = 0;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[1].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[1].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }

                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    for (int h = 1; h < e.Row.Cells.Count; h++)
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_shiperconsigneeProduct, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }

        protected void btn_Export_Details_Click(object sender, EventArgs e)
        {
            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 105, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "FI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 106, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 107, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 108, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "CH":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 109, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
                case "AC":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 262, 3, Convert.ToInt32(Session["LoginBranchid"]), "Report: " + ddl_Report.SelectedItem + "/ Trantype :" + Session["StrTranType"].ToString() + "/ Print");
                    break;
            }
            //ExportToExcelNew();

          


            if (ddl_Report.SelectedItem.Text == "M I S")
            {
                excel();
            }
            else
            {
               // ExportToExcel_OLDFormat();
                if (ddl_Report.SelectedItem.Text == "Nomination Vs Freehand")
                {
                    //  ScriptManager.RegisterStartupScript(btn_Export, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                    return;

                }
                else if (ddl_Report.Text == "Quotation - Customerwise")
                {
                    // ScriptManager.RegisterStartupScript(btn_Export, typeof(LinkButton), "Operating profit", "alertify.alert('No Data Found');", true);
                    return;
                }
                else if (ddl_Report.Text == "Trend Analysis - Customer With Volume")
                {
                    return;
                }
                else if (ddl_Report.Text == "Top 50 Shipper / Consignee")
                {
                    return;
                }
                else
                {
                    ExportToExcelNew();
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
            GridViewlog.Visible = true;
            Panel4.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 105, "MIS", "", "", "");
                    break;
                case "FI":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 106, "MIS", "", "", "");
                    break;
                case "AE":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 107, "MIS", "", "", "");
                    break;
                case "AI":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 108, "MIS", "", "", "");
                    break;
                case "CH":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 109, "MIS", "", "", "");
                    break;
                case "AC":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 262, "MIS", "", "", "");
                    break;
            }

            //  obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 262, "MIS", "", "", "");



            lbl_no.InnerText = "MIS #:";

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_Agent_PreRender(object sender, EventArgs e)
        {
            if (grd_Agent.Rows.Count > 0)
            {
                grd_Agent.UseAccessibleHeader = true;
                grd_Agent.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_Shipper_PreRender(object sender, EventArgs e)
        {
            if (grd_Shipper.Rows.Count > 0)
            {
                grd_Shipper.UseAccessibleHeader = true;
                grd_Shipper.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdshipteusdtls_PreRender(object sender, EventArgs e)
        {
            if (grdshipteusdtls.Rows.Count > 0)
            {
                grdshipteusdtls.UseAccessibleHeader = true;
                grdshipteusdtls.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdyear_PreRender(object sender, EventArgs e)
        {
            if (grdyear.Rows.Count > 0)
            {
                grdyear.UseAccessibleHeader = true;
                grdyear.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_Consignee_PreRender(object sender, EventArgs e)
        {
            if (grd_Consignee.Rows.Count > 0)
            {
                grd_Consignee.UseAccessibleHeader = true;
                grd_Consignee.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_Shipment_PreRender(object sender, EventArgs e)
        {
            if (grd_Shipment.Rows.Count > 0)
            {
                grd_Shipment.UseAccessibleHeader = true;
                grd_Shipment.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_JobwiseCosting_PreRender(object sender, EventArgs e)
        {
            if (grd_JobwiseCosting.Rows.Count > 0)
            {
                grd_JobwiseCosting.UseAccessibleHeader = true;
                grd_JobwiseCosting.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_lossjob_PreRender(object sender, EventArgs e)
        {
            if (grd_lossjob.Rows.Count > 0)
            {
                grd_lossjob.UseAccessibleHeader = true;
                grd_lossjob.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_nomvafree_PreRender(object sender, EventArgs e)
        {
            if (grd_nomvafree.Rows.Count > 0)
            {
                grd_nomvafree.UseAccessibleHeader = true;
                grd_nomvafree.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_operProfit_PreRender(object sender, EventArgs e)
        {
            if (grd_operProfit.Rows.Count > 0)
            {
                grd_operProfit.UseAccessibleHeader = true;
                grd_operProfit.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_operProfit_AC_PreRender(object sender, EventArgs e)
        {
            if (grd_operProfit_AC.Rows.Count > 0)
            {
                grd_operProfit_AC.UseAccessibleHeader = true;
                grd_operProfit_AC.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_POL_PreRender(object sender, EventArgs e)
        {
            if (grd_POL.Rows.Count > 0)
            {
                grd_POL.UseAccessibleHeader = true;
                grd_POL.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_POD_PreRender(object sender, EventArgs e)
        {
            if (grd_POD.Rows.Count > 0)
            {
                grd_POD.UseAccessibleHeader = true;
                grd_POD.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_salesperson_PreRender(object sender, EventArgs e)
        {
            if (grd_salesperson.Rows.Count > 0)
            {
                grd_salesperson.UseAccessibleHeader = true;
                grd_salesperson.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Gridliner_PreRender(object sender, EventArgs e)
        {
            if (Gridliner.Rows.Count > 0)
            {
                Gridliner.UseAccessibleHeader = true;
                Gridliner.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GRD_CANREPORT_PreRender(object sender, EventArgs e)
        {
            if (GRD_CANREPORT.Rows.Count > 0)
            {
                GRD_CANREPORT.UseAccessibleHeader = true;
                GRD_CANREPORT.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GRD_canreportAI_PreRender(object sender, EventArgs e)
        {
            if (GRD_canreportAI.Rows.Count > 0)
            {
                GRD_canreportAI.UseAccessibleHeader = true;
                GRD_canreportAI.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GRD_RegisterReport_PreRender(object sender, EventArgs e)
        {
            if (GRD_RegisterReport.Rows.Count > 0)
            {
                GRD_RegisterReport.UseAccessibleHeader = true;
                GRD_RegisterReport.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GRD_DoRegister_PreRender(object sender, EventArgs e)
        {
            if (GRD_DoRegister.Rows.Count > 0)
            {
                GRD_DoRegister.UseAccessibleHeader = true;
                GRD_DoRegister.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GRD_Forward_PreRender(object sender, EventArgs e)
        {
            if (GRD_Forward.Rows.Count > 0)
            {
                GRD_Forward.UseAccessibleHeader = true;
                GRD_Forward.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GRD_Revenue_PreRender(object sender, EventArgs e)
        {
            if (GRD_Revenue.Rows.Count > 0)
            {
                GRD_Revenue.UseAccessibleHeader = true;
                GRD_Revenue.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_freeVsnomi_PreRender(object sender, EventArgs e)
        {
            if (Grd_freeVsnomi.Rows.Count > 0)
            {
                Grd_freeVsnomi.UseAccessibleHeader = true;
                Grd_freeVsnomi.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_nomination_PreRender(object sender, EventArgs e)
        {
            if (Grd_nomination.Rows.Count > 0)
            {
                Grd_nomination.UseAccessibleHeader = true;
                Grd_nomination.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_shiperconsignee_PreRender(object sender, EventArgs e)
        {
            if (Grd_shiperconsignee.Rows.Count > 0)
            {
                Grd_shiperconsignee.UseAccessibleHeader = true;
                Grd_shiperconsignee.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_shiperconsigneeProduct_PreRender(object sender, EventArgs e)
        {
            if (Grd_shiperconsigneeProduct.Rows.Count > 0)
            {
                Grd_shiperconsigneeProduct.UseAccessibleHeader = true;
                Grd_shiperconsigneeProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_YearMIS_PreRender(object sender, EventArgs e)
        {
            if (grd_YearMIS.Rows.Count > 0)
            {
                grd_YearMIS.UseAccessibleHeader = true;
                grd_YearMIS.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_trendcustomer_PreRender(object sender, EventArgs e)
        {
            if (Grd_trendcustomer.Rows.Count > 0)
            {
                Grd_trendcustomer.UseAccessibleHeader = true;
                Grd_trendcustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_trendcustomervolume_PreRender(object sender, EventArgs e)
        {
            if (Grd_trendcustomervolume.Rows.Count > 0)
            {
                Grd_trendcustomervolume.UseAccessibleHeader = true;
                Grd_trendcustomervolume.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_Retention_PreRender(object sender, EventArgs e)
        {
            if (Grd_Retention.Rows.Count > 0)
            {
                Grd_Retention.UseAccessibleHeader = true;
                Grd_Retention.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_op_PreRender(object sender, EventArgs e)
        {
            if (grd_op.Rows.Count > 0)
            {
                grd_op.UseAccessibleHeader = true;
                grd_op.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GRD_Common_PreRender(object sender, EventArgs e)
        {
            if (GRD_Common.Rows.Count > 0)
            {
                GRD_Common.UseAccessibleHeader = true;
                GRD_Common.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Gridtemp_PreRender(object sender, EventArgs e)
        {
            if (Gridtemp.Rows.Count > 0)
            {
                Gridtemp.UseAccessibleHeader = true;
                Gridtemp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_MISA_PreRender(object sender, EventArgs e)
        {
            if (Grd_MISA.Rows.Count > 0)
            {
                Grd_MISA.UseAccessibleHeader = true;
                Grd_MISA.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_MISB_PreRender(object sender, EventArgs e)
        {
            if (Grd_MISB.Rows.Count > 0)
            {
                Grd_MISB.UseAccessibleHeader = true;
                Grd_MISB.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_MISC_PreRender(object sender, EventArgs e)
        {
            if (Grd_MISC.Rows.Count > 0)
            {
                Grd_MISC.UseAccessibleHeader = true;
                Grd_MISC.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_MISD_PreRender(object sender, EventArgs e)
        {
            if (Grd_MISD.Rows.Count > 0)
            {
                Grd_MISD.UseAccessibleHeader = true;
                Grd_MISD.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridViewlog_PreRender(object sender, EventArgs e)
        {
            if (GridViewlog.Rows.Count > 0)
            {
                GridViewlog.UseAccessibleHeader = true;
                GridViewlog.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}
