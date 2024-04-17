using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class cgdescRpt : System.Web.UI.Page
    {
        int bid;
        int jobno;
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
                if (Request.QueryString.ToString().Contains("jobno"))
                {
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    jobno = Convert.ToInt32(Request.QueryString["jobno"]);
                }
                dtcust = Selcustomedi.SelcgdescRpt(Convert.ToInt32(jobno), Convert.ToInt32(bid));
                if (dtcust.Rows.Count > 0)
                {
                    lbl_branch.Text = dtcust.Rows[0]["branchname"].ToString();
                    lbl_carnnoline.Text = dtcust.Rows[0]["carrno"].ToString();
                    lbl_ourigmno.Text = dtcust.Rows[0]["imno"].ToString() + " / " + Convert.ToDateTime(dtcust.Rows[0]["imdate"]).ToString("dd/MM/yyyy");
                    lbl_shipcusname.Text = dtcust.Rows[0]["customername"].ToString();
                    lbl_ourlineno.Text = dtcust.Rows[0]["linenumber"].ToString();
                    lbl_imocode.Text = dtcust.Rows[0]["imocode"].ToString();
                    lbl_ourvesselc.Text = dtcust.Rows[0]["cvslcode"].ToString();
                    lbl_ourvessel.Text = dtcust.Rows[0]["vesselname"].ToString() + " V. " + dtcust.Rows[0]["voyage"].ToString();
                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        lbl_tr.Text += "<tr>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["sublineno"].ToString() + "</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["blno"].ToString() + "</td>";
                        lbl_tr.Text += "<td>"+ Convert.ToDateTime(dtcust.Rows[0]["bldate"]).ToString("dd/MM/yyyy") + "</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["PODportname"].ToString() + "</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["portname"].ToString() + "</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["caddress"].ToString() + "</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["itemtype"].ToString() + "</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["cargommt"].ToString() + "</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["noofpkgs"].ToString() + " "+ dtcust.Rows[0]["packagecode"].ToString() +"</td>";
                        lbl_tr.Text += "<td>"+ Convert.ToDouble(dtcust.Rows[0]["grweight"]).ToString("0.00") + " "+"KGS"+"</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["cbm"].ToString() + " "+ "CBM" +"</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["marks"].ToString() + "</td>";
                        lbl_tr.Text += "<td>"+ dtcust.Rows[0]["descn"].ToString() + "</td>";
                        lbl_tr.Text += "</tr>";
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