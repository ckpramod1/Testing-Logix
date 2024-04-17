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
    public partial class JobinfoRpt : System.Web.UI.Page
    {
        int? jobno = null;
        string Trantype;
        int bid;
        DataAccess.LogDetails obj_da_logobj = new DataAccess.LogDetails();
        DataAccess.Reportasp reportasp = new DataAccess.Reportasp();
        DataTable dtcust = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_logobj.GetDataBase(Ccode);
                reportasp.GetDataBase(Ccode);
              
            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("jobno"))
                {
                    jobno = Convert.ToInt32(Request.QueryString["jobno"]);
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    Trantype = Request.QueryString["Trantype"];
                }
                else
                {
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    Trantype = Request.QueryString["Trantype"];
                }
                if (Trantype == "AE")
                {
                    lbl_date.Text = obj_da_logobj.GetDate().ToShortDateString();
                    lbl_head.Text = "Air Exports Job Information Details";
                    if (jobno.HasValue)
                    {
                        dtcust = reportasp.Seljobinfo(jobno, bid, Trantype);

                        for (int i = 0; i < dtcust.Rows.Count; i++)
                        {
                            lbl_tr.Text += "<tr>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["jobno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["mawblno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + Convert.ToDateTime(dtcust.Rows[0]["mawbldate"]).ToString("dd/MMM/yyyy") + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["flightno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + Convert.ToDateTime(dtcust.Rows[0]["flightdate"]).ToString("dd/MMM/yyyy") + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["portname"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["toportname"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["Status"].ToString() + "</td>";
                            lbl_tr.Text += "</tr>";
                            lbl_tr.Text += "<tr>";
                            lbl_tr.Text += "<td style='font-weight:bold'>AirLine</td>";
                            lbl_tr.Text += "<td>" + dtcust.Rows[0]["customername"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='font-weight:bold'>Agent</td>";
                            lbl_tr.Text += "<td>" + dtcust.Rows[0]["agcustomername"].ToString() + "</td>";
                            lbl_tr.Text += "</tr>";
                        }
                    }
                    else
                    {
                        dtcust = reportasp.Seljobinfo(bid, Trantype);
                        for (int i = 0; i < dtcust.Rows.Count; i++)
                        {
                            lbl_tr.Text += "<tr>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["jobno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["mawblno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + Convert.ToDateTime(dtcust.Rows[0]["mawbldate"]).ToString("dd/MMM/yyyy") + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["flightno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + Convert.ToDateTime(dtcust.Rows[0]["flightdate"]).ToString("dd/MMM/yyyy") + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["portname"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["toportname"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["Status"].ToString() + "</td>";
                            lbl_tr.Text += "</tr>";
                            lbl_tr.Text += "<tr>";
                            lbl_tr.Text += "<td style='font-weight:bold'>AirLine</td>";
                            lbl_tr.Text += "<td>" + dtcust.Rows[0]["customername"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='font-weight:bold'>Agent</td>";
                            lbl_tr.Text += "<td>" + dtcust.Rows[0]["agcustomername"].ToString() + "</td>";
                            lbl_tr.Text += "</tr>";
                        }
                    }
                }
                else
                {
                    lbl_head.Text = "Air Imports Job Information Details";

                    if (jobno.HasValue)
                    {
                        dtcust = reportasp.Seljobinfo(jobno, bid, Trantype);
                        for (int i = 0; i < dtcust.Rows.Count; i++)
                        {
                            lbl_tr.Text += "<tr>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["jobno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["mawblno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + Convert.ToDateTime(dtcust.Rows[0]["mawbldate"]).ToString("dd/MMM/yyyy") + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["flightno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + Convert.ToDateTime(dtcust.Rows[0]["flightdate"]).ToString("dd/MMM/yyyy") + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["portname"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["toportname"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["Status"].ToString() + "</td>";
                            lbl_tr.Text += "</tr>";
                            lbl_tr.Text += "<tr>";
                            lbl_tr.Text += "<td style='font-weight:bold'>AirLine</td>";
                            lbl_tr.Text += "<td>" + dtcust.Rows[0]["customername"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='font-weight:bold'>Agent</td>";
                            lbl_tr.Text += "<td>" + dtcust.Rows[0]["agcustomername"].ToString() + "</td>";
                            lbl_tr.Text += "</tr>";
                        }
                    }
                    else
                    {
                        dtcust = reportasp.Seljobinfo(bid, Trantype);
                        for (int i = 0; i < dtcust.Rows.Count; i++)
                        {
                            lbl_tr.Text += "<tr>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["jobno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["mawblno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + Convert.ToDateTime(dtcust.Rows[0]["mawbldate"]).ToString("dd/MMM/yyyy") + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["flightno"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + Convert.ToDateTime(dtcust.Rows[0]["flightdate"]).ToString("dd/MMM/yyyy") + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["portname"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["toportname"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='text-align:center'>" + dtcust.Rows[0]["Status"].ToString() + "</td>";
                            lbl_tr.Text += "</tr>";
                            lbl_tr.Text += "<tr>";
                            lbl_tr.Text += "<td style='font-weight:bold'>AirLine</td>";
                            lbl_tr.Text += "<td>" + dtcust.Rows[0]["customername"].ToString() + "</td>";
                            lbl_tr.Text += "<td style='font-weight:bold'>Agent</td>";
                            lbl_tr.Text += "<td>" + dtcust.Rows[0]["agcustomername"].ToString() + "</td>";
                            lbl_tr.Text += "</tr>";
                        }
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