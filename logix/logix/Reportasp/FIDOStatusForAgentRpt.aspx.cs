using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class FIDOStatusForAgentRpt : System.Web.UI.Page
    {
        int bid;
        int agentid;
        DateTime dtfrom ,dtto ;
        DataAccess.Reportasp Selcustomedi = new DataAccess.Reportasp();
        DataTable dtcust = new DataTable();
       
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Selcustomedi.GetDataBase(Ccode);
                


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.Page), "Master", "alertify.alert('Session TimeOut');window.open('http://CHawk.copperhawk.tech'_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("agentid"))
                {
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    agentid = Convert.ToInt32(Request.QueryString["agentid"]);
                    dtfrom = Convert.ToDateTime(Request.QueryString["dtfrom"]);
                    dtto = Convert.ToDateTime(Request.QueryString["dtto"]);
                }
               
                dtcust = Selcustomedi.SelFIDOStatusForAgentRpt(Convert.ToInt32(agentid), Convert.ToInt32(bid), Convert.ToDateTime(dtfrom),Convert.ToDateTime(dtto));

                if (dtcust.Rows.Count > 0)
                {
                    lbl_branch.Text = dtcust.Rows[0]["branchname"].ToString();
                    lbl_add.Text = dtcust.Rows[0]["address"].ToString();
                    lbl_ph.Text = dtcust.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcust.Rows[0]["fax"].ToString();
                    lbl_mail.Text = dtcust.Rows[0]["email"].ToString();
                    lbl_staxhead.Text = dtcust.Rows[0]["stno"].ToString();
                    lbl_panno.Text = dtcust.Rows[0]["panno"].ToString();
                    lbl_agent.Text = dtcust.Rows[0]["customername"].ToString();

                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        lbl_tr.Text += "<tr>                   ";
                        lbl_tr.Text += "<td>"+dtcust.Rows[0]["splitbl"].ToString()+"</td>         ";
                        lbl_tr.Text += "<td>"+dtcust.Rows[0]["blno"].ToString()+"</td>          ";
                        lbl_tr.Text += "<td>"+Convert.ToDateTime(dtcust.Rows[0]["doissuedon"]).ToString("dd/MM/yyyy")+"</td>  ";
                        lbl_tr.Text += "</tr>                  ";
                    }

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