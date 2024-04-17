using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class Form2Rpt : System.Web.UI.Page
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

                    ds = da_obj_rptasp.GetForm2rpt(Convert.ToInt32(jobno), Bid);
                    dt = ds.Tables[0];
                    //dt1 = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {
                        lbl_cmaster.Text = dt.Rows[0]["cmaster"].ToString();
                        lbl_cnation.Text = dt.Rows[0]["cnation"].ToString();
                        lbl_divname.Text = dt.Rows[0]["divisionname"].ToString();
                        lbl_vessel.Text = dt.Rows[0]["jobvessel"].ToString();
                        lbl_voy.Text = dt.Rows[0]["jobvoy"].ToString();

                        for (i = 0; i < dt.Rows.Count; i++)
                        {


                            tdRow_CanDtls.Text += " <tr>";
                            tdRow_CanDtls.Text += " <td colspan='13' style='border-bottom:1px solid #000; padding:2px; border-left:1px solid #000;border-right:1px solid #000;'>CARGO LOADED FROM " + dt.Rows[i]["blpol"].ToString() + " ON " + dt.Rows[i]["blvessel"].ToString() + " / " + dt.Rows[i]["blvoy"].ToString() + " AND TRANSHIPPED AT " + dt.Rows[i]["Transhippedat"].ToString() + " TO BE DISCHARGED AT " + dt.Rows[i]["pod"].ToString() + " </td>";
                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += " <tr>";
                            tdRow_CanDtls.Text += "<td style='border-right:1px solid #000;border-bottom:1px solid #000;border-left:1px solid #000;'>" + dt.Rows[i]["linenumber"].ToString() + "</td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'><p>" + dt.Rows[i]["blno"].ToString() + "</p>";
                            tdRow_CanDtls.Text += " <p>Dated</p>";
                            tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["bldate"].ToString() + "</p></td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'><p>" + dt.Rows[i]["cont20"].ToString() + " x 2 0 Container</p>";
                            tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["cont40"].ToString() + " x 4 0 Container</p>";
                            tdRow_CanDtls.Text += "<p>S.T.C</p>";
                            tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[i]["pkgdescn"].ToString() + "</p></td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'>" + dt.Rows[i]["marks"].ToString() + "</td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'><p>" + dt.Rows[i]["grweight"].ToString() + "</p>";
                            tdRow_CanDtls.Text += " <p>KGS</p></td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'>" + dt.Rows[i]["bldescn"].ToString() + "</td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'><p>" + dt.Rows[i]["caddress"].ToString() + "</p>";
                            tdRow_CanDtls.Text += " <p>Notify Party</p>";
                            tdRow_CanDtls.Text += "  <p>" + dt.Rows[i]["naddress"].ToString() + "</p>";

                            tdRow_CanDtls.Text += "  <div style='width:95%; float:left;'>";
                            tdRow_CanDtls.Text += "  <p style='padding:1px; margin:0px; font-weight:bold;font-size: 11px;'> LCL CONTAINER DETAILS</p>";
                            tdRow_CanDtls.Text += "  <div style='float:left; width:49%; margin:0px 1% 0px 0px;'>";
                            tdRow_CanDtls.Text += "  <div style='float:left; width:100%; margin:5px 0px 5px 0px;font-size: 11px; font-weight:bold;'>Container #</div>";
                            tdRow_CanDtls.Text += "  <div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "  <p style='padding:1px; margin:0px;font-size: 11px;'>" + dt.Rows[i]["containerno"].ToString() + "<br />";
                           
                            tdRow_CanDtls.Text += " </p>";
                            tdRow_CanDtls.Text += "  </div>";
                            tdRow_CanDtls.Text += "  <div style='float:left; width:50%; margin:0px 0% 0px 0px;'>";
                            tdRow_CanDtls.Text += " <div style='float:left; width:50%;font-size: 11px; margin:5px 0px 5px 0px; font-weight:bold;'>Seal #</div>";
                            tdRow_CanDtls.Text += "  <div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "  <p style='padding:1px; margin:0px;font-size: 11px;'>" + dt.Rows[i]["sealno"].ToString() + "<br />";                         
                            tdRow_CanDtls.Text += " </p>";
                            tdRow_CanDtls.Text += "  </div>";
                            tdRow_CanDtls.Text += "  </div>";

                            tdRow_CanDtls.Text += " <p>&nbsp;</p></td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "<td style='border-right:1px solid #000;border-bottom:1px solid #000;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='border-right:1px solid #000;border-bottom:1px solid #000;'>" + dt.Rows[i]["remarks"].ToString() + "</td>";
                            tdRow_CanDtls.Text += "</tr>";
                            //contdtls = dt.Rows[i]["containerno"].ToString();
                            //seal = dt.Rows[i]["sealno"].ToString();
                        }
                        //lbl_container.Text = contdtls;
                        //lbl_seal.Text = seal;

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