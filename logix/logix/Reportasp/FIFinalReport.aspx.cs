using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static log4net.Appender.RollingFileAppender;

namespace logix.Reportasp
{
    public partial class FIFinalReport : System.Web.UI.Page
    {
        string blno;
        int bid;
        DataAccess.Accounts.OSDNCN objosdncn = new DataAccess.Accounts.OSDNCN();
        DataTable dtcust = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objosdncn.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://CHawk.copperhawk.tech'_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("blno"))
                {
                    blno = Request.QueryString["blno"];
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                }

                dtcust = objosdncn.GetFIFinalReport(blno.ToString(), bid);
                if (dtcust.Rows.Count > 0)
                {
                    lblcompanyname.Text = dtcust.Rows[0]["branchname"].ToString();
                    lbladdress.Text = dtcust.Rows[0]["address"].ToString();
                    lblphone.Text = dtcust.Rows[0]["phone"].ToString();
                    lblfax.Text = dtcust.Rows[0]["fax"].ToString();
                    lblemail.Text = dtcust.Rows[0]["email"].ToString();
                    lblpan.Text = dtcust.Rows[0]["panno"].ToString();
                    lblservicetax.Text = dtcust.Rows[0]["stno"].ToString();
                    lblconsigneename.Text = dtcust.Rows[0]["consignee"].ToString();
                    lblcompanyadd.Text = dtcust.Rows[0]["caddress"].ToString();
                    lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lbljobno.Text = dtcust.Rows[0]["jobno"].ToString();
                    lblvessel.Text = dtcust.Rows[0]["vesselname"].ToString();
                    lblvoyage.Text = dtcust.Rows[0]["voyage"].ToString();
                    lblimno.Text = dtcust.Rows[0]["imno"].ToString();
                    lbleta.Text = Convert.ToDateTime(dtcust.Rows[0]["eta"]).ToString("dd/MM/yyyy");
                    lblmbl.Text = dtcust.Rows[0]["mblno"].ToString();
                    lbllineno.Text = dtcust.Rows[0]["linenumber"].ToString();
                    lblbl.Text = dtcust.Rows[0]["blno"].ToString();
                    for(int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        lblcondetails.Text += " <tr style=''>";
                        lblcondetails.Text += "<td><label>" + dtcust.Rows[i]["containerno"].ToString() + "</label></td>";
                        lblcondetails.Text += "<td><label>" + dtcust.Rows[i]["sizetype"].ToString() + "</label></td></tr>";
                    }
                    lblcomp.Text = dtcust.Rows[0]["branchname"].ToString();

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