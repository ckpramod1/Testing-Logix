using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace logix.HRM
{
    public partial class EmpConfirm : System.Web.UI.Page
    {
        DataTable DTConf=new DataTable();
        DataAccess.HR.FrontPage HRFrontObj =new DataAccess.HR.FrontPage();        
        DataTable dt = new DataTable();
        //string str_Script;
        protected void Page_Load(object sender, EventArgs e)
        {
            DTConf = HRFrontObj.GetCurrMonthConfirm();
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("EMPNAME");
            dtnew.Columns.Add("(Confirm)");
            dtnew.Columns.Add("Division");
            dtnew.Columns.Add("Branch");
         
            for (int i = 0; i < DTConf.Rows.Count;i++ )
            {
                dtnew.Rows.Add();
                dtnew.Rows[i]["EMPNAME"] = DTConf.Rows[i][0].ToString().Trim();
                dtnew.Rows[i]["Division"] = DTConf.Rows[i][2].ToString().Trim();
                dtnew.Rows[i]["Branch"] = DTConf.Rows[i][3].ToString().Trim();
                DateTime dtime = Convert.ToDateTime(DTConf.Rows[i][4].ToString());

                DateTime dtimenew = Convert.ToDateTime(dtime.AddMonths(6).ToString());

                dtnew.Rows[i]["(Confirm)"] = Utility.fn_ConvertDate(dtimenew.ToString());
                
            }

              grd.DataSource = dtnew;
                grd.DataBind();

          
        }
    }
}