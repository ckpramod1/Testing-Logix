using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace logix
{
    public partial class ToExcel : System.Web.UI.Page
    {
        string strPmtr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            strPmtr = Request.QueryString["pmtr"];
            if (strPmtr == "String")
                ConvertToExCel.ConverData(this.Page, ConvertToExCel.GetStringData(), ConvertToExCel.GetFileName());
            else
                ConvertToExCel.ConverData(this.Page, ConvertToExCel.GetDtblData(), ConvertToExCel.GetFileName(), ConvertToExCel.GetConversionType());
        }
    }
}