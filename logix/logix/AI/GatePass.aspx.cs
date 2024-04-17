using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.AI
{
    public partial class GatePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);
            string str_SP = "";
            string str_RptName = "";
            string str_sf = "";
            string str_Script = "";
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";

        
            //Session["str_sfs1"] = "";
            //Session["str_sfs2"] = "";
           
            str_RptName = "gatepass.rpt";          
            
            //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_SP + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            str_Script = "window.open('../Reportasp/gatepass.aspx?" + "&"  + this.Page.ClientQueryString + "&Ccode=" + Ccode + "','','');";
            ScriptManager.RegisterStartupScript(Page, typeof(Button), "GatePass", str_Script, true);
            //Session["str_sfs"] = str_sf;
            //Session["str_sp"] = str_SP;
        }   
    }
}