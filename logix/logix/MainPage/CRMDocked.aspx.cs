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
    public partial class CRMDocked : System.Web.UI.Page
    {
        DataTable dt_MenuRights = new DataTable();  
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            Session["StrTranType1"] = "CRMcor";
            dt_MenuRights = obj_UP.GetMenus(int.Parse(Session["LoginEmpId"].ToString()), "CRM", int.Parse(Session["LoginBranchid"].ToString()));
            Session["dt_UserRights"] = dt_MenuRights;
            StringBuilder str_MenuDesign = new StringBuilder();

            if (dt_MenuRights.Rows.Count > 0)
            {
                str_MenuDesign.Append("");
                str_MenuDesign.Append("");
                str_MenuDesign.Append("");
                str_MenuDesign.Append("");
                for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                {
                    if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "REPORTS")
                    {
                        links.Visible = true;

                        if(i == 5)
                        {
                            //str_MenuDesign.Append("<li>");
                           // str_MenuDesign.Append("<hr/>");
                            //str_MenuDesign.Append("</li>");
                        }
                        str_MenuDesign.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["aspxweb"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uiname"].ToString() + "</a></li>");
                        str_MenuDesign.Append("</li>");

                        divmenu.InnerHtml = str_MenuDesign.ToString();

                    }
                }
            }

            if(Session["iframeid"] !=null)
            {               
                string str;
                str=Session["iframeid"] .ToString ();
                if(str =="Home")
                {
                    ifrmaster.Attributes["src"] = "../CRM/MainFrameAppointments.aspx";
                }
                else if (str == "Budget")
                {
                    ifrmaster.Attributes["src"] = "../Budget.aspx";
                }
                else if (str == "GenerateSchedule")
                {
                    ifrmaster.Attributes["src"] = "../CRM/AppointmentLocationWise.aspx";
                }
                else if(str=="SalesFollowUp")
                {
                    ifrmaster.Attributes["src"] = "../CRM/SalesFollowUp.aspx";
                }
                else if (str == "SalesPerson")
                {
                    ifrmaster.Attributes["src"] = "../CRM/MainSalesPerson.aspx";
                }
                else if (str == "Mail")
                {
                    ifrmaster.Attributes["src"] = "../Mail/MailSent.aspx";
                }
                else
                {
                    ifrmaster.Attributes["src"] = "../CRM/AppReportList.aspx";
                }

            }
        }

     
        
    }
}