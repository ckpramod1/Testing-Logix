using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class Annex3RPT : System.Web.UI.Page
    {
       

 int Bid, Cid, i, jobno;
        string Type = "", TOtype = "", contdtls = "", Blno = "",seal="";
        string check = "";
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_rptasp.GetDataBase(Ccode);




            }
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }




            try
            {
                if (Request.QueryString.ToString().Contains("jobno"))
                {
                    jobno = Convert.ToInt32(Request.QueryString["jobno"].ToString());
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["cid"]);

                    ds = da_obj_rptasp.GetAnnex3rpt(Convert.ToInt32(jobno), Bid);
                   
                    dt = ds.Tables[0];
                   // dt1 = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            tdRow_CanDtls.Text += " <body style='font-family:sans-serif, Geneva, sans-serif; font-size:12px; line-height:18px;'>";
                            tdRow_CanDtls.Text += "<div style='width:1024px;margin: 0px auto;'> ";

                            tdRow_CanDtls.Text += "<p style='text-align:center;font-weight:bold;'>ANNXURE-B</br>";
                            tdRow_CanDtls.Text += "DECLARATION FORM FOR IGM ENTRY</p>";
                            tdRow_CanDtls.Text += "</div>";


                            tdRow_CanDtls.Text += "<div style='width:1024px;margin: 0px auto;'>";

                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>1.VOYAGE NUMBER</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align:left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["voyage"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";


                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>2.VESSEL DETAILS</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align:left;margin: 3px 0px 0px 30px;'></div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>a.NAME</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["vesselname"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>b.Shipping Line Code</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["pod"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>c.Total Lines</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left ;margin: 3px 0px 0px 30px;'>1</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";


                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>3.GATEWAY IGM RTN AND DATE</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["imno"].ToString() + " / " + dt.Rows[i]["imdate"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>4.PORT OF ORIGIN</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["pol"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>5.PORT OF REPORTING</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["pod"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>6.SMTP NUMBER AND DATE</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align:left;margin: 3px 0px 0px 30px;'></div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>7.GARGO DETAILS:</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>a.Line Number</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["linenumber"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight:bold;'>b.Bill of Lading Number</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["blno"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>c.Bill of Lading Date</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["bldate"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";



                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>d.Port of Shipment</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["blpol"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight:bold;'>e.Total Packages</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["noofpkgs"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>f.Package Type</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["pkgdescn"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";


                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>g.Gross Weight</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["grweight"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight:bold;'>h.Goods Description</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["descn"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:195px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;font-weight: bold;'>i.Marks & Number</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>-</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align: left;margin: 3px 0px 0px 30px;'>" + dt.Rows[i]["marks"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>8.CONSIGNEE NAME & ADDRESS</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align:left;margin: 3px 0px 0px 30px;'></div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:350px;float: left;padding:5px;text-align: left;margin: 0px 0px 0px 30px;'>" + dt.Rows[i]["caddress"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:225px;float: left;padding:5px;text-align: left;font-weight: bold;'>9.CONTAINER DETAILS</div>";
                            tdRow_CanDtls.Text += "<div style='width:2px;float: left;text-align: center;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:500px;float: left;text-align:left;margin: 3px 0px 0px 30px;'></div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:1024px;padding:5px;'>";
                            tdRow_CanDtls.Text += "<table width='1024' border='0' cellspacing='0' cellpadding='0'>";
                            tdRow_CanDtls.Text += "<tr style='width:150px;'>";
                            tdRow_CanDtls.Text += " <th width='300' height='19' style='text-align:left;'>a.Container No</th>";
                            tdRow_CanDtls.Text += " <th width='266' style='text-align:left;'>b.Seal No</th>";
                            tdRow_CanDtls.Text += " <th width='240' style='text-align:left;'>c.Container Status</th>";
                            tdRow_CanDtls.Text += " <th width='218' style='text-align:center;'>d.Total Packages</th>";
                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += " <tr >";
                            dt1 = da_obj_rptasp.Getcancontdet(Convert.ToInt32(jobno), Bid, dt.Rows[i]["blno"].ToString());
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                tdRow_CanDtls.Text += " <td style='text-align:left;'>" + dt1.Rows[j]["containerno"].ToString() + "</td>";
                                tdRow_CanDtls.Text += " <td style='text-align:left;'>" + dt1.Rows[j]["sealno"].ToString() + "</td>";
                                tdRow_CanDtls.Text += " <td style='text-align:left;'>" + dt1.Rows[j]["jobtype"].ToString() + "</td>";
                                tdRow_CanDtls.Text += "  <td style='text-align:center;'>" + dt1.Rows[j]["nookpkgs"].ToString() + "</td>";
                            }
                            //if (dt1.Rows.Count > 0)
                            //{
                            //    tdRow_CanDtls.Text += " <td style='text-align:left;'>" + dt1.Rows[i]["containerno"].ToString() + "</td>";
                            //    tdRow_CanDtls.Text += " <td style='text-align:left;'>" + dt1.Rows[i]["sealno"].ToString() + "</td>";
                            //    tdRow_CanDtls.Text += " <td style='text-align:left;'>" + dt1.Rows[i]["jobtype"].ToString() + "</td>";
                            //    tdRow_CanDtls.Text += "  <td style='text-align:center;'>" + dt1.Rows[i]["nookpkgs"].ToString() + "</td>";
                            //}

                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += " <tr >";
                            int a = i + 1;
                            tdRow_CanDtls.Text += " <td colspan='4'> <p class='PageNumber' > " + a + "</p> </td>";
                        
                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += "</table>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "</body>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString().Replace("'", "");
                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
    }
}