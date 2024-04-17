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
    public partial class SalesDocked : System.Web.UI.Page
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
        DataTable dtnew = new DataTable();
        DataTable dt_temp = new DataTable();
        DataTable dtnew1 = new DataTable();
        int countryid;
        protected void Page_Load(object sender, EventArgs e)
        {

             string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                hrempobj.GetDataBase(Ccode);
                leftObj.GetDataBase(Ccode);
                rightObj.GetDataBase(Ccode);
                exrobj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                exrobj.GetDataBase(Ccode);
                Appobj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                MISObj.GetDataBase(Ccode);
            }
            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                //string str_ModuleName = Session["StrTranType"].ToString();
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                obj_UP.GetDataBase(Ccode);
                dt_temp = obj_UP.GetMenusprocess(Convert.ToInt16(Session["LoginEmpId"].ToString()), "", Convert.ToInt16(Session["LoginBranchid"].ToString()), 2);
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
                    dtnew = dv_co.ToTable(true, "uiname","tchsubpriority");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "tchsubpriority";
                    dtnew = dv_co.ToTable();
                   // Session["uiname"] = dtnew;
                    for (int i = 0; i < dtnew.Rows.Count; i++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = dt_temp.DefaultView;
                        data1.RowFilter = "uiname = '" + dtnew.Rows[i]["uiname"] + "' ";
                        dtLi = data1.ToTable();
                        dt_MenuRights = dtLi;

                        if (dt_MenuRights.Rows[0]["menuname"].ToString().Trim() == "Sales")
                        {
                            if (//dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "BuyingRates" ||
                                 dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Quotation (Selling)" ||
                                dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Booking" ||
                                //dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Credit Request" ||
                               dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "DSR"||
                                  dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Budget"||
                                 dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Rate Sheet" ||
                                  dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Inquiry"
                                 // dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Quotation Approval" ||
                                 //dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Buying Rate-Query"||
                                 //   dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Prospect Customer" ||
                                 // dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Sales Visit Details" ||
                                 // dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "To Be Call"
                                 )
                            {
                                Sales.Visible = true;
                                str_MenuDesign.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[0]["touchaspx"].ToString() + "?Ccode=" + Ccode + "&type=" + dt_MenuRights.Rows[0]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[0]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[0]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign.Append("</li>");
                                
                                

                                DivSales.InnerHtml = str_MenuDesign.ToString();
                            }
                        }

                        //if (dt_MenuRights.Rows[0]["menuname"].ToString().Trim() == "Reports")
                        //{
                        //    if (dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Data Entry Details" ||
                        //      dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "New Call Advise" ||
                        //        dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Followup Advise" ||
                        //        dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "DSR" ||
                        //        dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Call Reports" ||
                        //        dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Call Vs Appointments" ||
                        //        dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Appointments" ||
                        //        dt_MenuRights.Rows[0]["uiname"].ToString().Trim() == "Quotes Vs Booking"
                        //         )
                        //    {
                        //        Sales.Visible = true;
                        //        str_MenuDesign8.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[0]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[0]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[0]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[0]["uicaption"].ToString() + " </a></li>");
                        //        str_MenuDesign8.Append("</li>");



                        //        Div1_Reports.InnerHtml = str_MenuDesign8.ToString();
                        //    }
                        //}
                    }
                }
            }
        }
    }
}