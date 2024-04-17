using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix
{
    public partial class Module_ops : System.Web.UI.Page
    {
        DataTable dt_MenuRights = new DataTable();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dt_MenuRights = obj_UP.Getmodule(Convert.ToInt16(Session["LoginEmpId"].ToString()), Convert.ToInt16(Session["LoginBranchid"].ToString()));
                DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
                Ocean_export.ServerClick += new EventHandler(Ocean_export_Click);
                FEFIMenu.ServerClick += new EventHandler(FEFIMenu_Click);
                AirExport.ServerClick += new EventHandler(AirExport_Click);
                AirAgencyimport.ServerClick += new EventHandler(AirAgencyimport_Click); 
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void Ocean_export_Click(object sender, EventArgs e)
        {
            if (Session["home"] != null)
            {
                if (Session["home"].ToString() == "CS")
                {
                    Session["StrTranType"] = "FE";
                    Response.Redirect("MainPage/OceanExportsCustomerSupport.aspx");
                }
                else if (Session["home"].ToString() == "OPS&DOC")
                {
                    Session["StrTranType"] = "FE";
                    Response.Redirect("MainPage/OceanExportsOps_Docs.aspx");
                }
                    
            }
            

        }

        public void FEFIMenu_Click(object sender, EventArgs e)
        {
            if (Session["home"] != null)
            {
                if (Session["home"].ToString() == "CS")
                {
                    Session["StrTranType"] = "FI";
                    Response.Redirect("MainPage/OceanImportsCustomerSupport.aspx");
                }
                else if (Session["home"].ToString() == "OPS&DOC")
                {
                    Session["StrTranType"] = "FI";
                    Response.Redirect("MainPage/OceanImports_ops.aspx");
                }

            }
        }

        public void AirExport_Click(object sender, EventArgs e)
        {
            if (Session["home"] != null)
            {
                if (Session["home"].ToString() == "CS")
                {
                    Session["StrTranType"] = "AE";
                    Response.Redirect("MainPage/AECustomerSupport.aspx");
                }
                else if (Session["home"].ToString() == "OPS&DOC")
                {
                    Session["StrTranType"] = "AE";
                    Response.Redirect("MainPage/AirExports_ops.aspx");
                }

            }
        }

        public void AirAgencyimport_Click(object sender, EventArgs e)
        {
            if (Session["home"] != null)
            {
                if (Session["home"].ToString() == "CS")
                {
                    Session["StrTranType"] = "AI";
                    Response.Redirect("MainPage/AICustomerSupport.aspx");
                }
                else if (Session["home"].ToString() == "OPS&DOC")
                {
                    Session["StrTranType"] = "AI";
                    Response.Redirect("MainPage/AirImports_ops.aspx");
                }

            }
        }
    }
}