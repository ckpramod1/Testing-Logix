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
    public partial class OceanExportsCustomerSupport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hname;
            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), str_ModuleName, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                Session["trantype_process"] = null;
                string str_menuhead = "";               
                StringBuilder str_MenuDesign1 = new StringBuilder();
                
                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "CRM")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "PO Details with Container" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Stuffing Confirmation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Sailing Confirmation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Transhipment Confirmation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "D O Confirmation - Request" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "D O Confirmation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipment Status" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Send Document" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "PreAlert" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Master Customer MailID" ||                               
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Performance Tracking" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event Tracking-Operations" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Events" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event Tracking")
                            {
                                //links.Visible = true;
                                str_MenuDesign1.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign1.Append("</li>");

                                divcustomer.InnerHtml = str_MenuDesign1.ToString();
                            }
                        }
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