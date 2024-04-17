using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class AICANRpt : System.Web.UI.Page
    {
        string hawblno;
        string directbl;
        int bid;
        DataAccess.Reportasp reportasp = new DataAccess.Reportasp();
        DataTable dtcust = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                reportasp.GetDataBase(Ccode);
              



            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("hawblno"))
                {
                    hawblno = Request.QueryString["hawblno"];
                    directbl = Request.QueryString["directbl"];
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                }
                if (directbl == "N")
                {
                    hc_igm.Visible = false;
                    hc_date.Visible = false;

                }

                dtcust = reportasp.SelAICANRpt(hawblno.ToString(), bid);
                if (dtcust.Rows.Count > 0)
                {
                    lbl_branch.Text = dtcust.Rows[0]["branchname"].ToString();
                    lbl_add.Text = dtcust.Rows[0]["braddress"].ToString();
                    lbl_ph.Text = dtcust.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcust.Rows[0]["fax"].ToString();
                    lbl_conadd.Text = dtcust.Rows[0]["mscustomername"].ToString()+"</br>"+ dtcust.Rows[0]["address"].ToString() + "</br>" + dtcust.Rows[0]["mpportname"].ToString() + "-" + dtcust.Rows[0]["mczip"].ToString();
                    lbl_condate.Text = Convert.ToDateTime(dtcust.Rows[0]["candate"]).ToString("dd/MM/yyyy");
                    lbl_job.Text = dtcust.Rows[0]["jobno"].ToString();
                    lbl_flno.Text = dtcust.Rows[0]["flightno"].ToString();
                    lbl_flar.Text = Convert.ToDateTime(dtcust.Rows[0]["flightdate"]).ToString("dd/MM/yyyy");
                    lbl_mbl.Text = dtcust.Rows[0]["mawblno"].ToString()+" & "+ Convert.ToDateTime(dtcust.Rows[0]["mawbldate"]).ToString("dd/MM/yyyy");
                    lbl_hawb.Text = dtcust.Rows[0]["hawblno"].ToString()+" & "+ Convert.ToDateTime(dtcust.Rows[0]["issuedon"]).ToString("dd/MM/yyyy");
                    lbl_cons.Text = dtcust.Rows[0]["cname"].ToString();
                    lbl_ship.Text = dtcust.Rows[0]["customername"].ToString();
                    lbl_pol.Text = dtcust.Rows[0]["polportname"].ToString();
                    lbl_pod.Text = dtcust.Rows[0]["portname"].ToString();
                    lbl_pak.Text = dtcust.Rows[0]["PackageDetails"].ToString();
                    lbl_gr.Text = Convert.ToDouble(dtcust.Rows[0]["grosswt"]).ToString()+"Kgs";
                    lbl_igm.Text = dtcust.Rows[0]["manifestno"].ToString();
                    lbl_igmdate.Text = Convert.ToDateTime(dtcust.Rows[0]["mawbldate"]).ToString("dd/MM/yyyy");
                    lbl_desc.Text = dtcust.Rows[0]["descn"].ToString();
                    lbl_branch2.Text = dtcust.Rows[0]["branchname"].ToString();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "   ", "alertify.alert('" + message + "');", true);
            }
        }
    }
}