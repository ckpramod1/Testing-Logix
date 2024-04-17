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
    public partial class MIS_ApprovalDock : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.UserPermission userobj = new DataAccess.UserPermission();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataTable dt = new DataTable();
        DataTable dthbl = new DataTable();
        DataTable dtmbl = new DataTable();
        DataTable dttemp = new DataTable();
        long lngPQuot, lngInv, lngPA, lngDN, lngCN;
        int branchid, vouyear, logempid;
        string ModuleName,processid;
        string hname;
        DataTable dtnew = new DataTable();
        DataTable dt_temp = new DataTable();
        DataTable dtnew1 = new DataTable();
        DataTable dt_MenuRights = new DataTable();
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
                userobj.GetDataBase(Ccode);
                MISObj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);








            }
            if (!IsPostBack)
            {

                //string str_ModuleName = Session["StrTranType"].ToString();
                //DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                //Raj// processid = userobj.Getprocessidbyname("MIS & Analytics");

                dt_temp = obj_UP.GetMenusprocess(Convert.ToInt16(Session["LoginEmpId"].ToString()), "", Convert.ToInt16(Session["LoginBranchid"].ToString()), 18);
                Session["dt_UserRights"] = dt_temp;
                string str_menuhead = "";
                StringBuilder str_MenuDesign = new StringBuilder();
                StringBuilder str_MenuDesign1 = new StringBuilder();
                StringBuilder str_MenuDesign2 = new StringBuilder();
                StringBuilder str_MenuDesign3 = new StringBuilder();

                StringBuilder str_MenuDesign4 = new StringBuilder();
                StringBuilder str_MenuDesign5 = new StringBuilder();
                StringBuilder str_MenuDesign6 = new StringBuilder();
                StringBuilder str_MenuDesign7 = new StringBuilder();
                StringBuilder str_MenuDesign8 = new StringBuilder();
                if (dt_temp.Rows.Count > 0)
                {
                    DataView dv_co1 = new DataView(dt_temp);
                    dtnew1 = dv_co1.ToTable(true, "trantype");
                    dv_co1 = new DataView(dtnew1);
                    dv_co1.Sort = "trantype";
                    dtnew1 = dv_co1.ToTable();
                    Session["trantype_process"] = dtnew1;

                    DataView dv_co = new DataView(dt_temp);
                    dtnew = dv_co.ToTable(true, "submenuname");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "submenuname";
                    dtnew = dv_co.ToTable();
                    for (int i = 0; i < dtnew.Rows.Count; i++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = dt_temp.DefaultView;
                        data1.RowFilter = "submenuname = '" + dtnew.Rows[i]["submenuname"] + "'  and trantype <> '" + "AC" + "'";//uiname = '" + dtnew.Rows[i]["uiname"] + "' and  and trantype <> '" + "CH" + "' and trantype <> '" + "BT" + "'
                        dtLi = data1.ToTable();
                        dt_MenuRights = dtLi;

                        
                        if (dt_MenuRights.Rows[0]["menuname"].ToString().Trim() == "MIS" ||
                            dt_MenuRights.Rows[0]["menuname"].ToString().Trim() == "Approval" ||
                            dt_MenuRights.Rows[0]["menuname"].ToString().Trim() == "Sales" ||
                            dt_MenuRights.Rows[0]["menuname"].ToString().Trim() == "Utility")
                        {
                            if (
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Exemption Request" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Credit Approval" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Costing" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Job Closing"||
                                 dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Booking Register"||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Statistics" || 
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Job Audit Report" ||

                                    dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Volume") // dt_MenuRights.Rows[0]["menuname"].ToString().Trim() == "MIS" ||
                            {
                                MIS.Visible = true;
                                str_MenuDesign.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[0]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[0]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[0]["uiid"].ToString() + "&menuname=" + dt_MenuRights.Rows[0]["menuname"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[0]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign.Append("</li>");

                                DivMIS.InnerHtml = str_MenuDesign.ToString();
                            }

                           
                        }

                        if (dt_MenuRights.Rows[0]["menuname"].ToString().Trim() == "Operation MIS")
                        {
                            if (dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Customerwise BL" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Event Tracking Operation" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Pending DO - Jobwise" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Teus Report" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Query" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Volume Report" ||
                                dt_MenuRights.Rows[0]["submenuname"].ToString().Trim() == "Lost / New Customer")
                            {
                                operationmis.Visible = true;
                                str_MenuDesign8.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[0]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[0]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[0]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[0]["submenuname"].ToString() + " </a></li>");
                                str_MenuDesign8.Append("</li>");

                                Divoperationmis.InnerHtml = str_MenuDesign8.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}