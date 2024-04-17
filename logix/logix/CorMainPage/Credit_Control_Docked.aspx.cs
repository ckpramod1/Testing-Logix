using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace logix.CorMainPage
{
    public partial class Credit_Control_Docked : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataTable dt = new DataTable();
        DataTable dthbl = new DataTable();
        DataTable dtmbl = new DataTable();
        DataTable dttemp = new DataTable();
        long lngPQuot, lngInv, lngPA, lngDN, lngCN;
        int branchid, vouyear, logempid;
        string ModuleName;
        string hname;
        string trantype = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                trantype = Session["RightsTranType"].ToString();
                Session["StrTranType1"] = "CreditControlcor";
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), trantype, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                string str_menuhead = "";
                StringBuilder str_MenuDesign = new StringBuilder();

                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Credit")
                        {
                            Outstanding.Visible = true;
                            //str_MenuDesign.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            //str_MenuDesign.Append("</li>");
                            if (i == 19)
                            {

                                str_MenuDesign.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign.Append("</li>");
                                divOutstanding.InnerHtml = str_MenuDesign.ToString();
                            }

                        }
                    }
                }
            }
        }
    }
}