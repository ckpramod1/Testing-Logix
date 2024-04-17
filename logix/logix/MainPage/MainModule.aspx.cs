using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.MainPage
{
    public partial class MainList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btn_OceanExport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainFEFIMenu.aspx");
        }
        protected void btn_OceanImport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainFEFIMenu.aspx");
        }
        protected void btn_AirExport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainFEFIMenu.aspx");
        }
        protected void btn_AirImport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainFEFIMenu.aspx");
        }
        protected void btn_AgencyImport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainFEFIMenu.aspx");
        }
        protected void btn_AgencyExport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainFEFIMenu.aspx");
        }
        protected void btn_Maintenance_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MaintenanceDockedPanel.aspx");
        }

    }
}