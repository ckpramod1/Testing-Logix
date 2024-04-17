using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace logix.Reportasp
{
    public partial class paysliprpt : System.Web.UI.Page
    {
        DataAccess.HR.Employee hreobj = new DataAccess.HR.Employee();
        DataTable dt = new DataTable();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                hreobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);

            }


            if (Request.QueryString.ToString().Contains("fromyear"))
            {
                string fromyear = Request.QueryString["fromyear"].ToString();
                string toyear = Request.QueryString["toyear"].ToString();
                string fromonth = Request.QueryString["fromonth"].ToString();
                string tomonth = Request.QueryString["tomonth"].ToString();

                dt = hreobj.sp_hrpayslip(Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(fromyear), Convert.ToInt32(toyear), Convert.ToInt32(fromonth), Convert.ToInt32(tomonth));
               if(dt.Rows.Count>0)
               {
                   for (int i = 0; i<=dt.Rows.Count - 1;i++ )
                   {
                      // form1.Controls.Add(new LiteralControl("<iframe src='../Reportasp/payslip.aspx?fromyear=" + dt.Rows[i]["employeeid"] + "&toyear=" + dt.Rows[i]["payyear"] + "&tomonth=" + dt.Rows[i]["paymonth"] + "'></iframe>"));
                       form1.Controls.Add(new LiteralControl("<iframe src='../Reportasp/payslip.aspx?fromyear=" + dt.Rows[i]["payyear"] + "&toyear=" + dt.Rows[i]["payyear"] + "&fromonth=" + dt.Rows[i]["paymonth"] + "&tomonth=" + dt.Rows[i]["paymonth"] + "'></iframe>"));
                   }
                      
               }
            }
        }
    }
}