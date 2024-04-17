using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Remoting;
namespace logix.Reportasp
{
    public partial class Quotmultiportrpt : System.Web.UI.Page
    {
        int Bid, Cid, i, job;
        string Type = "", TOtype = "", contdtls = "", Blno = "",quotno="";
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtnew;
        DataSet ds;
        string trantype = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_rptasp.GetDataBase(Ccode);
                //    objRpt.GetDataBase(Ccode);
                //    ObjLog.GetDataBase(Ccode);
                //    masterObj.GetDataBase(Ccode);
                //}
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
                if (Request.QueryString.ToString().Contains("Bid"))
                {

                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    trantype = Request.QueryString["trantype"].ToString();
                    quotno = Request.QueryString["quotno"].ToString();
                    dt = da_obj_rptasp.Getquotmultiportrpt(Bid, trantype,quotno);


                    if (dt.Rows.Count > 0)
                    {
                        lblDivName.Text = dt.Rows[0]["branchname"].ToString();
                        lblAddress.Text = dt.Rows[0]["address"].ToString();
                        lblphone.Text = dt.Rows[0]["phone"].ToString();
                        lblfax.Text = dt.Rows[0]["fax"].ToString();
                        lbl_stno.Text = dt.Rows[0]["stno"].ToString();
                        lbl_pan.Text = dt.Rows[0]["panno"].ToString();
                        lbl_cust.Text = dt.Rows[0]["customername"].ToString();
                        lbl_custaddress.Text = dt.Rows[0]["custaddre"].ToString();
                        lblptc.Text = dt.Rows[0]["ptc"].ToString();
                        //lbl_quotno.Text = dt.Rows[0]["quotno"].ToString();
                        //lbl_valid.Text = dt.Rows[i]["validtill"].ToString();
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                lbl_rows.Text += " <div class='main_section'>";
                                lbl_rows.Text += "  <div class='ref_no'>";
                                lbl_rows.Text += "   <p>Our Ref #: <span>" + dt.Rows[i]["quotno"].ToString() + "</span></p>";
                                lbl_rows.Text += " </div>";
                                lbl_rows.Text += " <div class='ref_no'>";
                                lbl_rows.Text += "   <p>Valid Till : <span>" + dt.Rows[i]["validtill"].ToString() + "</span></p>";
                                lbl_rows.Text += "  </div>";
                                lbl_rows.Text += "  </div>";

                                lbl_rows.Text += "<div class='area_content'>";
                                lbl_rows.Text += " <div class='area_title'>";
                                lbl_rows.Text += "  <div>PoR: <span>" + dt.Rows[i]["por"].ToString() + "</span></div>";
                                lbl_rows.Text += " <div>PoL: <span>" + dt.Rows[i]["pol"].ToString() + "</span></div>";
                                lbl_rows.Text += " <div>PoD: <span>" + dt.Rows[i]["pod"].ToString() + "</span></div>";
                                lbl_rows.Text += " <div>FD: <span>" + dt.Rows[i]["fd"].ToString() + "</span></div>";
                                lbl_rows.Text += " </div>";
                                lbl_rows.Text += " <div>Liner : <span>" + dt.Rows[i]["liner"].ToString() + "</span></div>";
                                lbl_rows.Text += " </div>";

                                lbl_rows.Text += "  <div class='Collect_Shipment'>";
                                lbl_rows.Text += " <p>" + dt.Rows[i]["stype"].ToString() + " " + dt.Rows[i]["fstatus"].ToString() + " Shipment</p>";
                                lbl_rows.Text += " <div class='inco_no'>";
                                lbl_rows.Text += "   <div class='inco'>";
                                lbl_rows.Text += "     <div>Inco<span class='incoNum'>" + dt.Rows[i]["inco"].ToString() + "</span></div>";
                                lbl_rows.Text += "     <div>Cargo<span class='incoNum'>" + dt.Rows[i]["cargoid"].ToString() + "</span></div>";
                                lbl_rows.Text += "   </div>";
                                lbl_rows.Text += "   <div class='scope'>";
                                lbl_rows.Text += "    <div>Scope<span class='incoNum'>" + dt.Rows[i]["scope"].ToString() + "</span></div>";
                                lbl_rows.Text += "  </div>";
                                lbl_rows.Text += "</div>";
                                lbl_rows.Text += " </div>";


                                lbl_rows.Text += "  <table>";
                                lbl_rows.Text += " <thead>";
                                lbl_rows.Text += "  <tr>";
                                lbl_rows.Text += "   <th>Charge</th>";
                                lbl_rows.Text += "   <th>Currency</th>";
                                lbl_rows.Text += "   <th>Rate</th>";
                                lbl_rows.Text += "   <th>Base</th>";
                                lbl_rows.Text += "  </tr>";
                                lbl_rows.Text += " </thead>";
                                lbl_rows.Text += " <tbody>";

                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    if (dt.Rows[i]["quotno"].ToString() == dt.Rows[j]["quotno"].ToString())
                                    {
                                        lbl_rows.Text += "   <tr>";
                                        lbl_rows.Text += " <td><span>" + dt.Rows[j]["chargename"].ToString() + "</span></td>";
                                        lbl_rows.Text += " <td><span>" + dt.Rows[j]["curr"].ToString() + "   </span></td>";
                                        lbl_rows.Text += "  <td><span>" + dt.Rows[j]["rate"].ToString() + "</span></td>";
                                        lbl_rows.Text += "  <td><span> " + dt.Rows[j]["base"].ToString() + "</span></td>";
                                        //lbl_rows.Text += "  <td><span></span></td>";
                                        lbl_rows.Text += " </tr>";
                                    }
                                }

                                lbl_rows.Text += " </tbody>";
                                lbl_rows.Text += " </table>";
                            }
                            else
                            {
                                string quot = dt.Rows[i - 1]["quotno"].ToString();
                                if (quot != dt.Rows[i]["quotno"].ToString())
                                {
                                    lbl_rows.Text += " <div class='main_section'>";
                                    lbl_rows.Text += "  <div class='ref_no'>";
                                    lbl_rows.Text += "   <p>Our Ref #: <span>" + dt.Rows[i]["quotno"].ToString() + "</span></p>";
                                    lbl_rows.Text += " </div>";
                                    lbl_rows.Text += " <div class='ref_no'>";
                                    lbl_rows.Text += "   <p>Valid Till : <span>" + dt.Rows[i]["validtill"].ToString() + "</span></p>";
                                    lbl_rows.Text += "  </div>";
                                    lbl_rows.Text += "  </div>";

                                    lbl_rows.Text += "<div class='area_content'>";
                                    lbl_rows.Text += " <div class='area_title'>";
                                    lbl_rows.Text += "  <div>PoR: <span>" + dt.Rows[i]["por"].ToString() + "</span></div>";
                                    lbl_rows.Text += " <div>PoL: <span>" + dt.Rows[i]["pol"].ToString() + "</span></div>";
                                    lbl_rows.Text += " <div>PoD: <span>" + dt.Rows[i]["pod"].ToString() + "</span></div>";
                                    lbl_rows.Text += " <div>FD: <span>" + dt.Rows[i]["fd"].ToString() + "</span></div>";
                                    lbl_rows.Text += " </div>";
                                    lbl_rows.Text += " <div>Liner : <span>" + dt.Rows[i]["liner"].ToString() + "</span></div>";
                                    lbl_rows.Text += " </div>";

                                    lbl_rows.Text += "  <div class='Collect_Shipment'>";
                                    lbl_rows.Text += " <p>" + dt.Rows[i]["stype"].ToString() + " " + dt.Rows[i]["fstatus"].ToString() + " Shipment</p>";
                                    lbl_rows.Text += " <div class='inco_no'>";
                                    lbl_rows.Text += "   <div class='inco'>";
                                    lbl_rows.Text += "     <div>Inco<span class='incoNum'>" + dt.Rows[i]["inco"].ToString() + "</span></div>";
                                    lbl_rows.Text += "     <div>Cargo<span class='incoNum'>" + dt.Rows[i]["cargoid"].ToString() + "</span></div>";
                                    lbl_rows.Text += "   </div>";
                                    lbl_rows.Text += "   <div class='scope'>";
                                    lbl_rows.Text += "    <div>Scope<span class='incoNum'>" + dt.Rows[i]["scope"].ToString() + "</span></div>";
                                    lbl_rows.Text += "  </div>";
                                    lbl_rows.Text += "</div>";
                                    lbl_rows.Text += " </div>";


                                    lbl_rows.Text += "  <table>";
                                    lbl_rows.Text += " <thead>";
                                    lbl_rows.Text += "  <tr>";
                                    lbl_rows.Text += "   <th>Charge</th>";
                                    lbl_rows.Text += "   <th>Currency</th>";
                                    lbl_rows.Text += "   <th>Rate</th>";
                                    lbl_rows.Text += "   <th>Base</th>";

                                    lbl_rows.Text += "  </tr>";
                                    lbl_rows.Text += " </thead>";
                                    lbl_rows.Text += " <tbody>";

                                    for (int j = 0; j < dt.Rows.Count; j++)
                                    {
                                        if (dt.Rows[i]["quotno"].ToString() == dt.Rows[j]["quotno"].ToString())
                                        {
                                            lbl_rows.Text += "   <tr>";
                                            lbl_rows.Text += " <td><span>" + dt.Rows[j]["chargename"].ToString() + "</span></td>";
                                            lbl_rows.Text += " <td><span>" + dt.Rows[j]["curr"].ToString() + "   </span></td>";
                                            lbl_rows.Text += "  <td><span>" + dt.Rows[j]["rate"].ToString() + "</span></td>";
                                            lbl_rows.Text += "  <td><span> " + dt.Rows[j]["base"].ToString() + "</span></td>";
                                            //lbl_rows.Text += "  <td><span></span></td>";
                                            lbl_rows.Text += " </tr>";
                                        }
                                    }

                                    lbl_rows.Text += " </tbody>";
                                    lbl_rows.Text += " </table>";
                                }
                            }
                        
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