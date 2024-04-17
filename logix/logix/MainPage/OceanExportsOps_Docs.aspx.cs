using DataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.MainPage
{
    public partial class OceanExportsOps_Docs : System.Web.UI.Page
    {

        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        protected void Page_Load(object sender, EventArgs e)
        {

             string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                masterObj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                //objbid.GetDataBase(Ccode);
                //da_obj_Log.GetDataBase(Ccode);
                //FrontpageObj.GetDataBase(Ccode);
                //EXobj.GetDataBase(Ccode);
                //da_obj_Logobj.GetDataBase(Ccode);
            }
            string hname;
            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                //DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), str_ModuleName, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                Session["trantype_process"] = null;
                string str_menuhead = "";
                StringBuilder str_MenuDesign1 = new StringBuilder();
                StringBuilder str_MenuDesign2 = new StringBuilder();
                StringBuilder str_MenuDesign3 = new StringBuilder();
                StringBuilder str_MenuDesign4 = new StringBuilder();
                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)   
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Shipment Details")
                        {
                            if (//dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Job Info" ||
                              // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipping Bill" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Bill of Lading" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Liner BL" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Release" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Copy To Other Office" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Copy From Other Office" ||
                               // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Approve" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ISF Details"||
                                // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Download Document"||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Upload Document"
                                )
                            //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ETS EDI" ||

                            //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "M+R EDI"||
                            // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "M+R InterBranch EDI")
                            {
                                id_ops.Visible = true;
                                str_MenuDesign1.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign1.Append("</li>");

                                divops.InnerHtml = str_MenuDesign1.ToString();
                            }
                        }

                     /*   if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Approval")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN-Ops Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSDN Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSCN Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN-Ops Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSDN Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSCN Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Quotation Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Debit Note" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Credit Note" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Quotation Approval")
                            {
                                Approval.Visible = true;
                                str_MenuDesign2.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign2.Append("</li>");

                                divapproval.InnerHtml = str_MenuDesign2.ToString();
                            }
                        }
                        */
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Accounts" || dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Vouchers")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma Vouchers" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma OS Vouchers" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Approved Vouchers" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Approved OS Vouchers" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Pro OSV"||
                             //   dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma Invoice" ||
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


                            //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "DebitAdvise" ||
                            //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CreditAdvise" ||                                                        
                            ////dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OS DN/CN" ||                              
                            //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Debit Note" ||
                            //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Credit Note" 


                            //)
                            {
                                id_ops.Visible = true;
                                Accounts.Visible = true;
                                str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode  + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign3.Append("</li>");

                                DivAccounts.InnerHtml = str_MenuDesign3.ToString();
                            }
                        }
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "CRM")
                        {
                            if (
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event Details" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Stuffing Confirmation" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Sailing Confirmation" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Transhipment Confirmation" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "D O Confirmation - Request" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "D O Confirmation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipment Status" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Send Document" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Events" ||
                              //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "PreAlert" ||
                              //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Master Customer MailID" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Performance Tracking" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event Tracking-Operations" ||
                               
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event Tracking"||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Query")
                            {
                                //links.Visible = true;
                                str_MenuDesign2.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() +  "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign2.Append("</li>");

                                divcustomer.InnerHtml = str_MenuDesign2.ToString();
                            }
                        }

                       
                            if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Utility")
                            {
                                if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Change Job" ||
                                    dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend BL #" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend MBL #" ||
                                    dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ExRate Change" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend Sales Person" )
                                    //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Liner BL" ||
                                   // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend Shipping Bill #" ||                                                      
                                //    dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Job P/L And MIS")
                                //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ETS EDI" ||

                               
                                {
                                    id_ops.Visible = true;
                                    str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                    str_MenuDesign4.Append("</li>");

                                    Div1.InnerHtml = str_MenuDesign4.ToString();
                                }
                            }
                        

                    }
                }

                string BL_No = Request.QueryString["BL_No"];


                if (BL_No != null)
                {
                    DataTable dtblnoFE = masterObj.GetBLDetails2(BL_No);
                    if (dtblnoFE.Rows.Count > 0)
                    {
                        ifrmaster.Attributes["src"] = "../ShipmentDetails/FEBLdetails.aspx?BL_No=" + BL_No;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('Invalid HBL No');", true);
                        return;
                    }

                }
            }

            string Strtrantype = Session["StrTranType"].ToString();

            if (IsPostBack)
            {
                if (Session["Loggedname"] != null)
                {
                    hname = Session["Loggedname"].ToString();

                    if (hname == "userlog")
                    {
                        ifrmaster.Attributes["src"] = "../ForwardExports/Emptyform.aspx";
                        Session["Loggedname"] = null;
                    }
                }
            }
        }
    }
}