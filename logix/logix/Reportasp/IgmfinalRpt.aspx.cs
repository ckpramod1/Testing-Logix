using DataAccess.ForwardingImports;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using logix.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Typad.TypeAhead;

namespace logix.Reportasp
{
    public partial  class IgmfinalRpt : System.Web.UI.Page
    {
        int bid;
        int jobno;
        DataAccess.Reportasp Selcustomedi = new DataAccess.Reportasp();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dtcust = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {


                Selcustomedi.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);
              

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
                dtcust = Selcustomedi.SelIGMFINALrpt(Convert.ToInt32(jobno), Convert.ToInt32(bid));

                if (dtcust.Rows.Count > 0)
                {
                    lbl_branch.Text = dtcust.Rows[0]["branchname"].ToString();
                    lbl_add.Text = dtcust.Rows[0]["address"].ToString();
                    lbl_ph.Text = dtcust.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcust.Rows[0]["fax"].ToString();
                    lbl_staxhead.Text = dtcust.Rows[0]["stno"].ToString();
                    lbl_panno.Text = dtcust.Rows[0]["panno"].ToString();
                    lbl_ourigm.Text = dtcust.Rows[0]["imno"].ToString();
                    lbl_ourvoyage.Text = dtcust.Rows[0]["voyage"].ToString();
                    lbl_ourmastern.Text = dtcust.Rows[0]["cmaster"].ToString();
                    lbl_ourshipline.Text = dtcust.Rows[0]["clinecode"].ToString();
                    lbl_vesselna.Text = dtcust.Rows[0]["vesselname"].ToString();
                    lbl_lastport.Text = dtcust.Rows[0]["P1portname"].ToString();
                    lbl_ourigmdate.Text = Convert.ToDateTime(dtcust.Rows[0]["imdate"]).ToString("dd/MM/yyyy");
                    lbl_ourvesselcode.Text = dtcust.Rows[0]["cvslcode"].ToString();
                    lbl_oursteameragent.Text = dtcust.Rows[0]["cagent"].ToString();
                    lbl_ourport2.Text = dtcust.Rows[0]["P2portname"].ToString();
                    lbl_ourigmyear.Text = dtcust.Rows[0]["yearimdate"].ToString();
                    lbl_ourarriv.Text = Convert.ToDateTime(dtcust.Rows[0]["eta"]).ToString("dd/MM/yyyy");
                    lbl_ourvesselnation.Text = dtcust.Rows[0]["cnation"].ToString();
                    lbl_ourlastport3.Text = dtcust.Rows[0]["P2portname"].ToString();
                    //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                    }

                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        lbl_bind.Text += "<div  class='tbl' style='float: left; width: 100%; border-bottom: 1px solid #000;'>";
                        lbl_bind.Text += "<table style='width:100%;'>";
                        lbl_bind.Text += "<tbody>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_lineno' style='color:#000000;'runat='server'>LineNo:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_ourlineno'runat='server'>" + dtcust.Rows[0]["linenumber"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_sublineno' style='color:#000000;'runat='server'>SublineNo:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_containerno'runat='server'>" + dtcust.Rows[0]["sublineno"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_blno' style='color:#000000;'runat='server'>BLNo:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_ourblno'runat='server'>" + dtcust.Rows[0]["blno"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_bldate' style='color:#000000;'runat='server'>BLDate:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_1'runat='server'>" + Convert.ToDateTime(dtcust.Rows[0]["bldate"]).ToString("dd/MM/yyyy") + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_2' style='color:#000000;'runat='server'>MBLNo:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_3'runat='server'>" + dtcust.Rows[0]["mblno"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_4' style='color:#000000;'runat='server'>MBLDate:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_5'runat='server'>" + Convert.ToDateTime(dtcust.Rows[0]["mbldate"]).ToString("dd/MM/yyyy") + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_6' style='color:#000000;'runat='server'>PortShipment:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbbel_7'runat='server'>" + dtcust.Rows[0]["portname"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_8' style='color:#000000;'runat='server'>PortDestination:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_9'runat='server'>" + dtcust.Rows[0]["Shippod"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_10' style='color:#000000;'runat='server'>NatureofCargo:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_11'runat='server'>Sea</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_12' style='color:#000000;'runat='server'>ItemType:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_13'runat='server'>" + dtcust.Rows[0]["itemtype"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_14' style='color:#000000;'runat='server'>CargoMovement:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_15'runat='server'>" + dtcust.Rows[0]["cargommt"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_16' style='color:#000000;'runat='server'>DestCode:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_17'runat='server'>" + dtcust.Rows[0]["cfscode"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_18' style='color:#000000;'runat='server'>TotalPackage:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_19'runat='server'>" + dtcust.Rows[0]["noofpkgs"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_20' style='color:#000000;'runat='server'>PackageType:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_21'runat='server'>" + dtcust.Rows[0]["mpdescn"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_22' style='color:#000000;'runat='server'>GrossWeight:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text +=    "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_23'runat='server'>" + dtcust.Rows[0]["grweight"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        //lbl_bind.Text+="<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        //lbl_bind.Text+="<labelid='label_24' style='color:#000000;'runat='server'>Unit:</label>";
                        //lbl_bind.Text+="</td>";
                        //lbl_bind.Text+="<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        //lbl_bind.Text+="<asp:LabelID='lbl_25'runat='server'>unit</asp:Label>";
                        //lbl_bind.Text+="</td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_26' style='color:#000000;'runat='server'>GrossVolume:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text +=    "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_27'runat='server'>" + dtcust.Rows[0]["cbm"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'></td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'></td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_28' style='color:#000000;'runat='server'>Marks:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_29'runat='server'>" + dtcust.Rows[0]["marks"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'></td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'></td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label_30' style='color:#000000;'runat='server'>GoodsDescription:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='lbl_31'runat='server'>" + dtcust.Rows[0]["descn"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'></td>";
                        lbl_bind.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'></td>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "</tbody>";
                        lbl_bind.Text += "</table>";
                        lbl_bind.Text += "</div>";

                        lbl_bind.Text += "<div  class='tbl_add' style='float:left;width:100%;border-bottom:1pxsolid#000;'>";
                        lbl_bind.Text += "<table style='width:100%;'>";
                        lbl_bind.Text += "<tbody>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                        lbl_bind.Text += "<td style='width:50%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<labelid='label1' style='color:#000000;'runat='server'>Importer'sName&Address:</label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:50%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<labelid='label2' style='color:#000000;'runat='server'>Consignee'sName&Address:</label>";
                        lbl_bind.Text += "</td>";
                         
                         
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "<tr style='width:100%;'>";
                         
                        lbl_bind.Text += "<td style='width:50%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 10px;'>";
                        lbl_bind.Text += "<asp:LabelID='Label3'runat='server'>" + dtcust.Rows[0]["caddress"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "<td style='width:50%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px 0px 5px 3px;'>";
                        lbl_bind.Text += "<asp:LabelID='Label4'runat='server'>" + dtcust.Rows[0]["naddress"].ToString() + "</asp:Label>";
                        lbl_bind.Text += "</td>";
                        lbl_bind.Text += "</tr>";
                         
                        lbl_bind.Text += "</tbody>";
                        lbl_bind.Text += "</table>";
                        lbl_bind.Text += "</div>";
                        lbl_bind.Text += "<div class='table'>";
                         
                        lbl_bind.Text += "<table class='details' style='width:100%;'>";
                        lbl_bind.Text += "<thead>";
                        lbl_bind.Text += "<tr>";
                        lbl_bind.Text += "<th>ContainerNo</th>";
                        lbl_bind.Text += "<th>SizeType</th>";
                        lbl_bind.Text += "<th>Seal#</th>";
                        lbl_bind.Text += "<th>Total</th>";
                        lbl_bind.Text += "<th>Weight</th>";
                        lbl_bind.Text += "<th>ISOCode</th>";
                        lbl_bind.Text += "<th>SOCFlag</th>";
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "</thead>";
                        lbl_bind.Text += "<tbody>";
                        lbl_bind.Text += "<tr>";
                        lbl_bind.Text += "<td>" + dtcust.Rows[0]["containerno"].ToString() + "</td>";
                        lbl_bind.Text += "<td>" + dtcust.Rows[0]["sizetype"].ToString() + "</td>";
                        lbl_bind.Text += "<td>" + dtcust.Rows[0]["sealno"].ToString() + "</td>";
                        lbl_bind.Text += "<td>" + dtcust.Rows[0]["total"].ToString() + "</td>";
                        lbl_bind.Text += "<td>" + dtcust.Rows[0]["weight"].ToString() + "</td>";
                        lbl_bind.Text += "<td>" + dtcust.Rows[0]["isocode"].ToString() + "</td>";
                        lbl_bind.Text += "<td>" + dtcust.Rows[0]["socflag"].ToString() + "</td>";
                         
                        lbl_bind.Text += "</tr>";
                        lbl_bind.Text += "</tbody>";
                        lbl_bind.Text += "</table>";

                        lbl_bind.Text += "</div>";
                        lbl_bind.Text += "<div class='border' ></div>";
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