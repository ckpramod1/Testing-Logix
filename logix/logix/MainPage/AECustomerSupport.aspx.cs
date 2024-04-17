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
    public partial class AECustomerSupport : System.Web.UI.Page
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
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "PODetails" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Freight Certificate" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Query" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "HAWBL #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipper / Consignee" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Flight #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "MAWBL #" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Register" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Inv _ CNOps CustomerWise" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Master Customer MailID"||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Events"||
                                  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipment Status")
                            {
                                //links.Visible = true;
                                str_MenuDesign1.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign1.Append("</li>");

                                divcustomer2.InnerHtml = str_MenuDesign1.ToString();
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