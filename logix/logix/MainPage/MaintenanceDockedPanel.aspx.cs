using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.MainPage
{
    public partial class MaintenanceDockedPanel : System.Web.UI.Page
    {
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string Ccode = Convert.ToString(Session["Ccode"]);

                if (Ccode != "")
                {

                    obj_UP.GetDataBase(Ccode);
                   


                }
                DataTable dt_MenuRights = new DataTable();
                //Session["LoginDivisionId"] = 1;
                //Session["LoginBranchid"] = 2;
                string str_ModuleName = "MN"; //Session["StrTranType"].ToString();
               
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), str_ModuleName, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                string str_menuhead = "";

                StringBuilder str_MenuDesign = new StringBuilder();
                StringBuilder str_MenuDesign1 = new StringBuilder();
                
                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Master")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer PAN / ST" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Charges" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Vessel" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Port" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Ex Rate" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Container" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Cargo" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Packages" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Bank" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Sector" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Region" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Company" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Branch" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Department"||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Designation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "TDS" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Charges Classification" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Non-Employee" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Employee" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Access Rights"||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer MR Code" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "AirPortCode" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "AirlineShortCode" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "MasterBillType" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "S O P" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "PAN Card Details" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ServiceTax Update" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Master City Update" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "KYCProof for Customer" ||
                               // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Master Liner Group" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Approve KYC Proof"||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Carrier"||
                                   dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Relieving"
                                   || dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "JobClose DateExtension" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "IncoTerm" ||
                                // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CustomerNew" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Location" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer CFS Charges"||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Role UserAccess"
                                )
                            {
                                setup.Visible = true;
                                str_MenuDesign.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&Ccode=" + Ccode + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign.Append("</li>");
                                divMaster.InnerHtml = str_MenuDesign.ToString();
                            }
                        }
                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Systems")
                        //{
                        //    if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "User Rights" //||
                        //        //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "System Details" ||
                        //        //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Opening Balance - Customer" ||
                        //        //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Web Group Customer" ||
                        //        //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Group - Customer" ||
                        //        //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Change JobCloseDate" ||
                        //        //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Sales Customer List" ||
                        //        //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Carrier"
                        //        )
                        //    {
                        //        links.Visible = true;
                        //        str_MenuDesign1.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                        //        str_MenuDesign1.Append("</li>");
                        //        divSystems.InnerHtml = str_MenuDesign1.ToString();
                        //    }
                        //}
                    }
                }
            }
        }
    }
}