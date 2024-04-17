using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class gatepass : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_logobj = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                obj_da_logobj.GetDataBase(Ccode);
                
            }


            lbl_printdate.Text = obj_da_logobj.GetDate().ToShortDateString();
            lbl_brnch.Text = Session["LoginDivisionName"].ToString();
        }
    }
}