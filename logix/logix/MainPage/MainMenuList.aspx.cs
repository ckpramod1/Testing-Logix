using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace logix.MainPage
{
    public partial class MainMenuList : System.Web.UI.Page
    {
        string str_menuname;
        string str_module;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                

                str_module = Request.QueryString["Module"].ToString();
                str_menuname = Request.QueryString["Menu"].ToString();
                button1.Text = str_menuname;
                hf_menuname.Value = str_menuname;
             
                string str_temp = "";
                str_temp = str_temp + "<ul style='list-style-type: none'>";
                str_temp = str_temp + "<li class='menu_li'><a href='../Maintenance/MasterCargo.aspx' target='MainFrame'>Master Cargo</a></li>";
                str_temp = str_temp + "<li class='menu_li'><a href='Movements/portin.aspx' target='frmContent'>Port In</a></li>";
                str_temp = str_temp + "<li class='menu_li'><a href='Movements/Departure.aspx' target='frmContent'>Departure</a></li>";
                str_temp = str_temp + "<li class='menu_li'><a href='Movements/Arrival.aspx' target='frmContent'>Arrival</a></li>";
                str_temp = str_temp + "<li class='menu_li'><a href='Movements/Portout.aspx' target='frmContent'>Port Out</a></li>";
                str_temp = str_temp + "<li class='menu_li'><a href='Movements/Plotin.aspx' target='frmContent'>Plot / Depot In</a></li>";
                str_temp = str_temp + "<li class='menu_li'><a href='Movements/StatusDM.aspx' target='frmContent'>Status DM To AV</a></li>";
                str_temp = str_temp + "<ul>";
                div_mlist.InnerHtml = str_temp;

                //StringBuilder str_MenuDesign = new StringBuilder();
                ////prabha
                //DataTable dt_MenuRights = new DataTable();
                //DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                
                //Session["dt_UserRights"] = dt_MenuRights;
                //string str_menuhead = "";

                ////str_MenuDesign.Append("<ul class='navigation-3'>");
                ////str_MenuDesign.Append("<li><a href='../FE/BLPrinting.aspx?FormName=BLNumber&UIID=0000' target='centerfrm'>BL Number</a></li>");
                ////str_MenuDesign.Append("<li><a href='../FE/BLPrinting.aspx?FormName=Booking&UIID=0000' target='centerfrm'>Booking #</a></li>");
                ////str_MenuDesign.Append("<li><a href='../FE/ShipperConsigneeRPT.aspx?FormName=Shipper&UIID=0000' target='centerfrm'>Shipper / Consignee</a></li>");
                ////str_MenuDesign.Append("<li><a href='../FE/ShipperConsigneeRPT.aspx?FormName=MBL&UIID=0000' target='centerfrm'>MBL #</a></li>");
                ////str_MenuDesign.Append("<li><a href='../FE/ShipperConsigneeRPT.aspx?FormName=Container&UIID=0000' target='centerfrm'>Container #</a></li>");
                ////str_MenuDesign.Append("<li><a href='../FE/Query.aspx?FormName=Query&UIID=0000' target='centerfrm'>Query</a></li>");
                ////str_MenuDesign.Append("<li><a href='../FE/CustomerQuery.aspx?FormName=Query&UIID=0000' target='centerfrm'>Inv/CNops Details - CustomerWise</a></li>");
                ////str_MenuDesign.Append("</ul>");
                //str_MenuDesign.Append("<li><a href='" + dt_MenuRights.Rows[i]["aspxweb"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&UIID=" + dt_MenuRights.Rows[i]["uiid"].ToString() + dt_MenuRights.Rows[i]["parameter"].ToString() + "' target='centerfrm'>" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "</a></li>");

                //div_mlist.InnerHtml = str_MenuDesign.ToString();
                //end


            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        protected void img_Click(object sender, ImageClickEventArgs e)
        {
            if (img.ImageUrl == "~/images/imagesnew.jpg")
            {
                img.ImageUrl = "~/images/imagesnew.png";
                button1.Visible = true;
                div_iframe.Style.Add("width", "77.5%");
                div_iframe.Style.Add("height", "440px");

            }
            else
            {
                img.ImageUrl = "~/images/imagesnew.jpg";
                button1.Visible = true;
                mydiv.Visible = false;
                div_iframe.Style.Add("width", "99%");
                div_iframe.Style.Add("height", "440px");

            }
        }


        protected void button1_Click1(object sender, EventArgs e)
        {
            if (button1.Text == hf_menuname.Value)
            {
                mydiv.Visible = true;
                div_iframe.Style.Add("width", "77.5%");
                div_iframe.Style.Add("height", "440px");

            }

        }
    }
}