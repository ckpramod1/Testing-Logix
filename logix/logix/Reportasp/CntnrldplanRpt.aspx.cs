using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class CntnrldplanRpt : System.Web.UI.Page
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
                dtcust = Selcustomedi.SelCntnrldplanRpt(Convert.ToInt32(jobno), Convert.ToInt32(bid));
                if (dtcust.Rows.Count > 0)
                {
                    lbl_branch.Text = dtcust.Rows[0]["branchname"].ToString();
                    lbl_add.Text = dtcust.Rows[0]["address"].ToString();
                    lbl_ph.Text = dtcust.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcust.Rows[0]["fax"].ToString();
                    lbl_stax.Text = dtcust.Rows[0]["stno"].ToString();
                    lbl_pan.Text = dtcust.Rows[0]["panno"].ToString();

                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        lbl_tdrows.Text += "<div class='tbl' style='float:left;width:100%;border-bottom:1pxsolid#000;'>";
                        lbl_tdrows.Text += "<table style='width:100%;'>";
                        lbl_tdrows.Text += "<tbody>";
                        lbl_tdrows.Text += "<tr style='width:100%;'>";
                        lbl_tdrows.Text += "<td style='width:3%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label_1' style='color:#000000;'runat='server'>Container No:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:9%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='lbl_2'runat='server'>"+ dtcust.Rows[0]["containerno"].ToString() +"</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:6%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label_3' style='color:#000000;'runat='server'>Seal No:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='lbl_4'runat='server'>"+ dtcust.Rows[0]["sealno"].ToString() +"</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:6%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label_5' style='color:#000000;'runat='server'>IGM No:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='lbl_6'runat='server'>"+ dtcust.Rows[0]["imno"].ToString() +"</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "</tr>";
                        lbl_tdrows.Text += "<tr style='width:100%;'>";
                        lbl_tdrows.Text += "<td style='width:3%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label_7' style='color:#000000;'runat='server'>DT:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:9%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='lbl_8'runat='server'>" + Convert.ToDateTime(dtcust.Rows[0]["imdate"]).ToString("dd/MM/yyyy") + "</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:6%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label_9' style='color:#000000;'runat='server'>Port of Loading:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='lbl_10'runat='server'>"+ dtcust.Rows[0]["portname"].ToString() +"</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:6%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label1' style='color:#000000;'runat='server'>Vessel/Voyage:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='Label2'runat='server'>"+ dtcust.Rows[0]["vesselname"].ToString() +"/"+ dtcust.Rows[0]["voyage"].ToString() +"</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "</tr>";
                        lbl_tdrows.Text += "<tr style='width:100%;'>";
                        lbl_tdrows.Text += "<td style='width:3%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label_11' style='color:#000000;'runat='server'>Agent Name:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:9%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='lbl_12'runat='server'>"+ dtcust.Rows[0]["customername"].ToString() +"</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:6%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label_13' style='color:#000000;'runat='server'>MLine No:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='lbl_14'runat='server'>"+ dtcust.Rows[0]["linenumber"].ToString() +"</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:6%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrows.Text += "<label id='label_15' style='color:#000000;'runat='server'>Delivery At:</label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrows.Text += "<asp:Label id='lbl_16'runat='server'>"+ dtcust.Rows[0]["pod"].ToString() +"</asp:Label>";
                        lbl_tdrows.Text += "</td>";
                        lbl_tdrows.Text += "</tr>";
                        
                        
                        lbl_tdrows.Text += "</tbody>";
                        lbl_tdrows.Text += "</table>";
                        lbl_tdrows.Text += "</div>";

                        lbl_tdrows.Text += "<div class='table'>";
                        
                        lbl_tdrows.Text += "<table class='details'>";
                        lbl_tdrows.Text += "<thead>";
                        lbl_tdrows.Text += "<tr>";
                        lbl_tdrows.Text += "<th>Sub Line</th>";
                        lbl_tdrows.Text += "<th>B/L NO</th>";
                        lbl_tdrows.Text += "<th>No & Nature of Packages</th>";
                        lbl_tdrows.Text += "<th>Gross Weight (KGS)</th>";
                        lbl_tdrows.Text += "<th>CBM</th>";
                        lbl_tdrows.Text += "<th>Consignee</th>";
                        lbl_tdrows.Text += "<th>Marks & Numbers</th>";
                        lbl_tdrows.Text += "<th>Description</th>";
                        lbl_tdrows.Text += "</tr>";
                        lbl_tdrows.Text += "</thead>";
                        lbl_tdrows.Text += "<tbody>";
                        lbl_tdrows.Text += "<tr>";
                        lbl_tdrows.Text += "<td>"+ dtcust.Rows[0]["sublineno"].ToString() +"</td>";
                        lbl_tdrows.Text += "<td>"+ dtcust.Rows[0]["blno"].ToString() +"</td>";
                        lbl_tdrows.Text += "<td>"+ dtcust.Rows[0]["noofpkgs"].ToString() +" "+ dtcust.Rows[0]["mpdescn"].ToString() +"</td>";
                        lbl_tdrows.Text += "<td>"+ dtcust.Rows[0]["grweight"].ToString() +"</td>";
                        lbl_tdrows.Text += "<td>"+ dtcust.Rows[0]["cbm"].ToString() +"</td>";
                        lbl_tdrows.Text += "<td>"+ dtcust.Rows[0]["concustomername"].ToString() +"</td>";
                        lbl_tdrows.Text += "<td>"+ dtcust.Rows[0]["marks"].ToString() +"</td>";
                        lbl_tdrows.Text += "<td>"+ dtcust.Rows[0]["descn"].ToString() +"</td>";

                    }
                    lbl_tdrows.Text += "</tr>";
                    lbl_tdrows.Text += "<tr>";
                    lbl_tdrows.Text += "<td></td>";
                    lbl_tdrows.Text += "<td style='text-align:right;padding-right:5px!important;font-weight:bold;'>Total";
                    lbl_tdrows.Text += "<asp:Label id='Label12'runat='server' style='text-align:right;float:right;'></asp:Label></td>";
                    lbl_tdrows.Text += "<td>";
                    lbl_tdrows.Text += "<asp:Label id='Label3'runat='server' style='text-align:right;float:right;font-weight:bold;'>" + dtcust.Rows[0]["total_pkgs"].ToString() + " PKGS"+"</asp:Label></td>";
                    lbl_tdrows.Text += "<td>";
                    lbl_tdrows.Text += "<asp:Label id='Label4'runat='server' style='text-align:right;float:right;font-weight:bold;'>" + dtcust.Rows[0]["total_grweight"].ToString() + " KGS" + " </asp:Label></td>";
                    lbl_tdrows.Text += "<td>";
                    lbl_tdrows.Text += "<asp:Label id='Label5'runat='server' style='text-align:right;float:right;font-weight:bold;'>" + dtcust.Rows[0]["total_cbm"].ToString() + " CBM" + " </asp:Label></td>";
                    lbl_tdrows.Text += "<td></td>";
                    lbl_tdrows.Text += "<td></td>";
                    lbl_tdrows.Text += "<td></td>";
                    lbl_tdrows.Text += "</tr>";
                    lbl_tdrows.Text += "</tbody>";
                    lbl_tdrows.Text += "</table>";
                    lbl_tdrows.Text += "</div>";
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