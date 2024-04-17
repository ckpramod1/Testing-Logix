using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class FIPDORegisterRpt : System.Web.UI.Page
    {
        int bid;
        int agentid;
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
                }
                dtcust = Selcustomedi.SelFIPDORegisterRpt(Convert.ToInt32(agentid), Convert.ToInt32(bid));
                if (dtcust.Rows.Count > 0)
                {
                    //lbl_tdrow.Text += "<tbody>                                                                                             ";
                    lbl_tdrow.Text += "<tr>                                                                                                ";
                    lbl_tdrow.Text += "<td colspan='9' style='font-weight:bold;border-right:none;font-size:14px;font-family:sans-serif;'>  ";
                    lbl_tdrow.Text += "<asp:Label ID='lbl_cust' runat='server'>" + dtcust.Rows[0]["customername"].ToString() + "</asp:Label></td> ";
                    lbl_tdrow.Text += "</tr>                                                                                               ";
                    if (dtcust.Rows[0]["nomination"].ToString() == "F")
                    {
                        lbl_tdrow.Text += "<tr>                                                                                                ";
                        lbl_tdrow.Text += "<td colspan='9' style='font-weight:bold;border-right:none;font-size:14px;font-family:sans-serif;'>  ";
                        lbl_tdrow.Text += "<asp:Label ID='lbl_nom' runat='server'>" + "FREEHAND" + "</asp:Label></td>                           ";
                        lbl_tdrow.Text += " </tr>                                                                                              ";
                    }
                    else
                    {
                        lbl_tdrow.Text += "<tr>                                                                                                ";
                        lbl_tdrow.Text += "<td colspan='9' style='font-weight:bold;border-right:none;font-size:14px;font-family:sans-serif;'>  ";
                        lbl_tdrow.Text += "<asp:Label ID='lbl_nom' runat='server'>" + "NOMINATION" + "</asp:Label></td>                         ";
                        lbl_tdrow.Text += " </tr>                                                                                              ";
                    }
                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        lbl_tdrow.Text += "<tr>";
                        lbl_tdrow.Text += "<td>" + dtcust.Rows[0]["vouno"].ToString() + "</td>";
                        lbl_tdrow.Text += "<td>"+ dtcust.Rows[0]["blno"].ToString() + "</td>";
                        lbl_tdrow.Text += "<td>"+ dtcust.Rows[0]["jobno"].ToString() + "</td>";
                        lbl_tdrow.Text += "<td>"+ dtcust.Rows[0]["vesselname"].ToString() + "/" + dtcust.Rows[0]["voyage"].ToString() + "</td>";
                        lbl_tdrow.Text += "<td>"+ dtcust.Rows[0]["splitbl"].ToString() + "</td>";
                        lbl_tdrow.Text += "<td>"+ dtcust.Rows[0]["splitconsigneer"].ToString() + "</td>";
                        lbl_tdrow.Text += "<td>"+ dtcust.Rows[0]["consignee"].ToString() + "</td>";
                        lbl_tdrow.Text += "<td>"+ Convert.ToDouble(dtcust.Rows[0]["amount"]).ToString("0.00") + "</td>";
                        lbl_tdrow.Text += "<td>"+ dtcust.Rows[0]["DayDifference"].ToString() + "</td>";
                        lbl_tdrow.Text += "";
                        lbl_tdrow.Text += "";
                        lbl_tdrow.Text += "</tr>";
                       // lbl_tdrow.Text += "</tbody>";
                        //lbl_tdrow.Text += "</table>";
                       // lbl_tdrow.Text += "</div>";
                        //lbl_tdrow.Text += "<div class='tbl' style='float:left;width:100%;border-bottom:1pxsolid#000;'>";
                       // lbl_tdrow.Text += "<table style='width:100%;'>";
                        //lbl_tdrow.Text += "<tbody>";
                        lbl_tdrow.Text += "<tr style='width:100%;'>";
                        lbl_tdrow.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrow.Text += "<label id='label_1' style='color:#000000;'runat='server'>POL:</label>";
                        lbl_tdrow.Text += "</td>";
                        lbl_tdrow.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrow.Text += "<asp:Label id='lbl_2'runat='server'>"+ dtcust.Rows[0]["polportname"].ToString() + "</asp:Label>";
                        lbl_tdrow.Text += "</td>";
                        lbl_tdrow.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrow.Text += "<label id='label_3' style='color:#000000;'runat='server'>POR:</label>";
                        lbl_tdrow.Text += "</td>";
                        lbl_tdrow.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrow.Text += "<asp:Label id='lbl_4'runat='server'>"+ dtcust.Rows[0]["porportname"].ToString() + "</asp:Label>";
                        lbl_tdrow.Text += "</td>";
                        lbl_tdrow.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrow.Text += "<label id='label_5' style='color:#000000;'runat='server'>POD:</label>";
                        lbl_tdrow.Text += "</td>";
                        lbl_tdrow.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrow.Text += "<asp:Label id='lbl_6'runat='server'>"+ dtcust.Rows[0]["podportname"].ToString() + "</asp:Label>";
                        lbl_tdrow.Text += "</td>";
                        lbl_tdrow.Text += "<td style='width:4%;font-family:sans-serif;font-weight:bold;font-size:14px;padding:7px0px5px10px;'>";
                        lbl_tdrow.Text += "<label id='label_7' style='color:#000000;'runat='server'>FD:</label>";
                        lbl_tdrow.Text += "</td>";
                        lbl_tdrow.Text += "<td style='width:11%;font-family:sans-serif;font-weight:normal;font-size:14px;padding:7px0px5px3px;'>";
                        lbl_tdrow.Text += "<asp:Label id='lbl_8'runat='server'>"+ dtcust.Rows[0]["fdportname"].ToString() + "</asp:Label>";
                        lbl_tdrow.Text += "</td>";
                        lbl_tdrow.Text += "</tr>";
                        //lbl_tdrow.Text += "</tbody>";
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