using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace logix.MainPage
{
    public partial class AirImports_ops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();

                string Ccode = Convert.ToString(Session["Ccode"]);

                if (Ccode != "")
                {

                    masterObj.GetDataBase(Ccode);
                    obj_UP.GetDataBase(Ccode);
                 
                }

                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), str_ModuleName, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                Session["trantype_process"] = null;
                string str_menuhead = "";
                StringBuilder str_MenuDesign = new StringBuilder();
                StringBuilder str_MenuDesign2 = new StringBuilder();
                StringBuilder str_MenuDesign3 = new StringBuilder();
                StringBuilder str_MenuDesign1 = new StringBuilder();
                StringBuilder str_MenuDesigncan = new StringBuilder();
                StringBuilder str_MenuDesignedi = new StringBuilder();
                StringBuilder str_MenuDesign4 = new StringBuilder();
                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Shipment Details")
                        {
                            if (//dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Job Info" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "D.O. Issue" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "AWBL Details" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Upload Document" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Download Document" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Air Freight Rate Request" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Copy From Other Office" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Copy To Other Office" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customs Details"
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "M+R InterBranch EDI"
                                )
                            {
                                id_ops.Visible = true;
                                str_MenuDesign.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign.Append("</li>");
                                //divops.InnerHtml = str_MenuDesign.ToString();
                            }

                            if (!divops.InnerHtml.Contains("C A N"))
                            {
                                if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "C A N")
                                {
                                    {
                                        id_ops.Visible = true;
                                        str_MenuDesigncan.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["submenuname"].ToString() + " </a></li>");
                                        str_MenuDesigncan.Append("</li>");
                                    }
                                }
                            }
                            if (!divops.InnerHtml.Contains("Custom EDI"))
                            {
                                if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Custom EDI")
                                {
                                    {
                                        id_ops.Visible = true;
                                        str_MenuDesignedi.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["submenuname"].ToString() + " </a></li>");
                                        str_MenuDesignedi.Append("</li>");
                                    }
                                }
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "CRM")
                        {
                            if (!divops.InnerHtml.Contains("C A N"))
                            {
                                if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "C A N")
                                {
                                    {
                                        id_ops.Visible = true;
                                        str_MenuDesigncan.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                        str_MenuDesigncan.Append("</li>");
                                    }
                                }
                            }
                            if (!divops.InnerHtml.Contains("Custom EDI"))
                            {
                                if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Custom EDI")
                                {
                                    {
                                        id_ops.Visible = true;
                                        str_MenuDesignedi.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                        str_MenuDesignedi.Append("</li>");
                                    }
                                }
                            }
                        }

                        divops.InnerHtml = str_MenuDesign.ToString() + str_MenuDesigncan.ToString() + str_MenuDesignedi.ToString();

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Approval")
                        //{
                        //    if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice Proforma to Commercial" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN-Ops Proforma to Commercial" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSDN Proforma to Commercial" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSCN Proforma to Commercial" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice Approval" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN-Ops Approval" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSDN Approval" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSCN Approval" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Quotation Approval" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Debit Note" ||
                        //       dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Credit Note")
                        //    {
                        //        Approval.Visible = true;
                        //        str_MenuDesign2.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                        //        str_MenuDesign2.Append("</li>");

                        //        divapproval.InnerHtml = str_MenuDesign2.ToString();
                        //    }
                        //}

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Accounts" || dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Vouchers")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma Vouchers" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma OS Vouchers" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Approved Vouchers" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Approved OS Vouchers" ||
                                    dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Pro OSV" ||

                              //    dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma Invoice" ||
                              // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma Sales Invoice OC" ||
                              // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice" ||
                              // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice OC" ||
                              //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Bill of Supply" ||
                              //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Bill of Supply OC" ||

                              //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma Purchase Invoice" ||

                              //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma Purchase Invoice OC" ||
                              // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Purchase Invoice" ||
                              //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Purchase Invoice OC" ||
                              // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma OS DN/CN" ||
                              //   dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSSI" ||
                              //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSPI" ||
                              dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Payment Request" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Profoma Credit Note - Operations GST Amendment" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Costing" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Job P/L And MIS")


                            //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "DebitAdvise" ||
                            //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CreditAdvise"


                            {
                                id_ops.Visible = true;
                                Accounts.Visible = true;
                                str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign3.Append("</li>");

                                divAccounts.InnerHtml = str_MenuDesign3.ToString();
                            }
                        }
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "CRM")
                        {
                            if (
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event Details" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Delivery Order" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Gate Pass" ||
                               dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Query" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "HAWBL #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipper / Consignee" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "C A N" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Flight #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "MAWBL #" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Register" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Custom EDI" ||
                                //   dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Master Customer MailID" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Events" ||
                                  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipment Status")
                            {
                                //links.Visible = true;
                                str_MenuDesign2.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign2.Append("</li>");

                                divcustomer2.InnerHtml = str_MenuDesign2.ToString();
                            }
                        }
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Utility")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Change Job" ||
                                     dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend BL #" ||
                                       dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend MBL #" ||
                                     dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ExRate Change" ||
                                       dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend Sales Person")
                            //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Liner BL" ||
                            // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend Shipping Bill #" ||                                                      
                            // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Job P/L And MIS")
                            //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ETS EDI" ||


                            {
                                id_ops.Visible = true;
                                str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign4.Append("</li>");

                                Div1.InnerHtml = str_MenuDesign4.ToString();
                            }
                        }
                    }
                }

                string BL_No = Request.QueryString["BL_No"];


                if (BL_No != null)
                {

                    string trantype = "AI";
                    DataTable dtblnoAI = masterObj.GetAIEDetailBLNO(BL_No, trantype);
                    if (dtblnoAI.Rows.Count > 0)
                    {
                        ifrmaster.Attributes["src"] = "../AE/AEAWBDetails.aspx?BL_No=" + BL_No;

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('Invalid HAWB No');", true);

                        return;

                    }
                }
            }
        }
    }
}