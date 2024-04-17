using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Services.Description;

namespace logix.CorMainPage
{
    public partial class MIS_and_Analysis_Docked : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.MIS MISObj = new DataAccess.MIS();

        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
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
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                hrempobj.GetDataBase(Ccode);
                leftObj.GetDataBase(Ccode);
                Appobj.GetDataBase(Ccode);
                rightObj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                exrobj.GetDataBase(Ccode);
                MISObj.GetDataBase(Ccode);
               
            }


            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                trantype = Session["RightsTranType"].ToString();

                Session["StrTranType1"] = "MISandAnalysisCor";
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), trantype, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                string str_menuhead = "";
                StringBuilder str_MenuDesign = new StringBuilder();
                StringBuilder str_MenuDesign1 = new StringBuilder();

                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Analysis")
                        {
                            //if (i == 66)
                            //{

                                Analysis.Visible = true;
                                str_MenuDesign.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign.Append("</li>");

                                divAnalysis.InnerHtml = str_MenuDesign.ToString();
                            //}
                        }

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "M I S")
                        //{
                        //    MIS.Visible = true;
                        //    str_MenuDesign1.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                        //    str_MenuDesign1.Append("</li>");

                        //    divMIS.InnerHtml = str_MenuDesign1.ToString();
                        //}
                    }
                }
            }
        }
    }
}