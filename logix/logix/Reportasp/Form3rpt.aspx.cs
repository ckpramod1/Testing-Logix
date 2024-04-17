using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class Form3rpt : System.Web.UI.Page
    {
        int Bid, Cid, i, jobno;
        string Type = "", TOtype = "", contdtls = "", Blno = "";
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

                    ds = da_obj_rptasp.GetForm3RPT(Convert.ToInt32(jobno), Bid, Cid);
                    dt = ds.Tables[0];
                    dt1 = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {
                        string lbl_divname = dt.Rows[i]["divisionname"].ToString();
                        string lb_Agent = dt.Rows[i]["agentname"].ToString();
                        string lbl_vessel = dt.Rows[i]["vesselname"].ToString();
                        string lbl_voy = dt.Rows[i]["voyage"].ToString();
                        string lbl_pod = dt.Rows[i]["jobpod"].ToString();
                        string lbl_cnation = dt.Rows[i]["cnation"].ToString();
                        string lbl_pol = dt.Rows[i]["jobpol"].ToString();
                        //lbl_from.Text = dt.Rows[i]["blpol"].ToString();
                        //lbl_to.Text = dt.Rows[i]["blfd"].ToString();


                        tdRow_CanDtls.Text += " <body style='font-family:sans-serif, Geneva, sans-serif; font-size:13px; line-height:18px;'>";
                        
                        tdRow_CanDtls.Text += " <div style='width:1050px;margin: 0px auto;'> ";
                        tdRow_CanDtls.Text += " <table width='1050' border='0' cellspacing='0' cellpadding='0' class='TableHeader'>";
                        tdRow_CanDtls.Text += "    <thead>";

                        tdRow_CanDtls.Text += " <div style='width:1024px;margin: 0px auto;'> ";
                        tdRow_CanDtls.Text += " <p style='text-align:center;font-weight:bold;'>FORM III</br>";
                        tdRow_CanDtls.Text += " Cargo Declaration </br>";
                        tdRow_CanDtls.Text += " (See Regulation 3 and 4)</p>";
                        tdRow_CanDtls.Text += " </div>";

                        tdRow_CanDtls.Text += " <div style='width:1024px;margin: 0px auto;'> ";

                        tdRow_CanDtls.Text += " <div style='width:230px;float: left;padding:5px;text-align: left;font-weight: bold;'>Name of Shipping Line,Agent etc</div>";
                        tdRow_CanDtls.Text += " <div style='width:315px;float: left;text-align:left;margin: 5px 0px 0px 0px;'>" + lbl_divname + ",</div>";
                        tdRow_CanDtls.Text += " <div style='width:300px;float: left;text-align:left;margin: 5px 0px 0px 0px;'>" + lb_Agent + "</div>";
                        tdRow_CanDtls.Text += " </div>";
                        tdRow_CanDtls.Text += " <div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += " <div style='width:1050px;margin: 0px auto;border-top: 1px solid #000;'> ";

                        tdRow_CanDtls.Text += " <div style='width:150px;float: left;padding:5px;text-align: left;font-weight: bold;'>1.Name of Ship</div>";
                        tdRow_CanDtls.Text += " <div style='width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;'>:</div>";
                        tdRow_CanDtls.Text += " <div style='width:270px;float: left;text-align:left;margin: 5px 0px 0px 20px;'>" + lbl_vessel + "</div>";


                        tdRow_CanDtls.Text += " <div style='width:65px;float: left;padding:5px;text-align: left;font-weight: bold;'>Voyage</div>";
                        tdRow_CanDtls.Text += " <div style='width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;'>:</div>";
                        tdRow_CanDtls.Text += " <div style='width:150px;float: left;text-align:left;margin: 5px 0px 0px 20px;'>" + lbl_voy + "</div>";



                        tdRow_CanDtls.Text += " <div style='width:190px;float: left;padding:5px;text-align: left;font-weight: bold;'>2.Port where report made</div>";
                        tdRow_CanDtls.Text += " <div style='width:2px;float: left;text-align: center;margin: 3px 0px 0px 0px;'>:</div>";
                        tdRow_CanDtls.Text += " <div style='width:100px;float: left;text-align:left;margin: 5px 0px 0px 20px;'>" + lbl_pod + "</div>";


                        tdRow_CanDtls.Text += " <div style='clear:both;'></div>";


                        tdRow_CanDtls.Text += " <div style='width:150px;float: left;padding:5px;text-align: left;font-weight: bold;'>3.Nationality of Ship</div>";
                        tdRow_CanDtls.Text += " <div style='width:2px;float: left;text-align: center;margin: 5px 0px 0px 0px;'>:</div>";
                        tdRow_CanDtls.Text += " <div style='width:175px;float: left;text-align:left;margin: 5px 0px 0px 20px;'>" + lbl_cnation + "</div>";


                        tdRow_CanDtls.Text += " <div style='width:126px;float: left;padding:5px;text-align: left;font-weight: bold;'>4.Name of Master</div>";
                        tdRow_CanDtls.Text += " <div style='width:2px;float: left;text-align: center;margin: 5px 0px 0px 0px;'>:</div>";
                        tdRow_CanDtls.Text += " <div style='width:150px;float: left;text-align:left;margin: 5px 0px 0px 20px;'></div>";



                        tdRow_CanDtls.Text += " <div style='width:190px;float: left;padding:5px;text-align: left;font-weight: bold;'>5.Port of Loading</div>";
                        tdRow_CanDtls.Text += " <div style='width:2px;float: left;text-align: center;margin: 5px 0px 0px 0px;'>:</div>";
                        tdRow_CanDtls.Text += " <div style='width:100px;float: left;text-align:left;margin: 5px 0px 0px 20px;'>" + lbl_pol + "</div>";



                        tdRow_CanDtls.Text += " </div>";
                        tdRow_CanDtls.Text += " <div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "  <tr style='text-align: left;'>";

                        tdRow_CanDtls.Text += "  <th width='55' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>6.Line No. </br>Sub-Line No.Type</th>";
                        tdRow_CanDtls.Text += "  <th width='102' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>7.Bill of Lading No.</th>";
                        tdRow_CanDtls.Text += "  <th width='60' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>8.No. &amp; Kindsof Packages</th>";
                        tdRow_CanDtls.Text += "  <th width='87' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>9.Marks &amp; Numbers</th>";
                        tdRow_CanDtls.Text += "   <th width='60' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>10.Gross Weight</th>";
                        tdRow_CanDtls.Text += "   <th width='95' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>11.Goods Description</th>";
                        tdRow_CanDtls.Text += "  <th width='177' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>12.Name of Consignee/Importer if different</th>";
                        tdRow_CanDtls.Text += "  <th width='86' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>13.Date of Presentation of B/E</th>";
                        tdRow_CanDtls.Text += "  <th width='92' rowspan='2' style='padding:2px; margin:0px; border-bottom:1px solid #000; border-top:1px solid #000;'>14.Name of Custom House</th>";
                        tdRow_CanDtls.Text += "  <th colspan='3' style='border-bottom:1px solid #000; text-align:left; padding:2px; margin:0px; border-top:1px solid #000; '>15.Rotation No</th>";
                        tdRow_CanDtls.Text += "  </tr>";
                        tdRow_CanDtls.Text += " <tr>";
                        tdRow_CanDtls.Text += " <th width='90' valign='top'  style='padding:2px; margin:0px; border-bottom:1px solid #000; '>Cash/Deposit W.R.No</th>";
                        tdRow_CanDtls.Text += "  <th width='77' valign='top'  style='padding:2px; margin:0px; border-bottom:1px solid #000;'>No of Pkgs onwhich duty Type collected of</th>";
                        tdRow_CanDtls.Text += " <th width='69' valign='top' style='padding:2px; margin:0px; border-bottom:1px solid #000;'>Year(To be Filled Remark by port trust)No of Pkgs</th>";
                        tdRow_CanDtls.Text += " </tr>";

                        tdRow_CanDtls.Text += " </thead>";
                         fn_rows();
                         tdRow_CanDtls.Text += " </table>";
                         tdRow_CanDtls.Text += " </div>";




                        //<div  style='width:1050px;margin: 0px auto;'> ";
                        //<div style='width:315px;float:right;padding:10px;' >We hereby certify that item No. to against IGM NO. is for
                        //account of ourprincipals.We,as agents are responsible for the full
                        //outtern of cargo manifested under the above items and will be
                        //liable to the Customs for any penalty or other dues in case of
                        //any shortlandings/survey shortages.We hereby hold Mumbai
                        //Agents of the vessel fully indemnified from any short
                        //landings/survey shortages under the above items.We certify
                        //that all items indicated in this Hard copy of IGM have been </div>

                        //tdRow_CanDtls.Text += " <div style='clear:both;'></div>

                        //tdRow_CanDtls.Text += " <div style='width:315px;float:right;text-align:right;margin-top:35px;'>Date & signature of Master,authorised ag</div>

                        //tdRow_CanDtls.Text += " </div>

                        //tdRow_CanDtls.Text += " </body>


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



        public void fn_rows()
        {

            for (i = 0; i < dt.Rows.Count; i++)
            {

                if (i != 0)
                {
                    if ((dt.Rows[i - 1]["blfd"].ToString()) == (dt.Rows[i]["blfd"].ToString()))
                    {
                        // count.Visible = false;

                        //if (i == 0)
                        //{
                        //    tdRow_CanDtls.Text += " <tr>";
                        //    tdRow_CanDtls.Text += "  <td colspan='12' align='center' style='padding:2px; margin:0px;'><div style='text-align:left; font-weight:bold; margin:0px auto; width:31%;'>From : " + dt.Rows[i]["blpol"].ToString() + " To " + dt.Rows[i]["blfd"].ToString() + "</div></td>";
                        //    tdRow_CanDtls.Text += "  </tr>";
                        //}
                        //if ((i == dt.Rows.Count))
                        //{
                        //    //count.Visible = true;
                        //}
                        tdRow_CanDtls.Text += "  <tr>";
                        tdRow_CanDtls.Text += "  <td valign='top' style='padding:2px; margin:0px;'><br />LC -  " + dt.Rows[i]["linenumber"].ToString() + "<br /> <br /> " + dt.Rows[i]["MT"].ToString() + "-" + dt.Rows[i]["sublineno"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td valign='top' style='padding:2px; margin:0px;'><p>M-&gt; " + dt.Rows[i]["mblno"].ToString() + "</p>";
                        tdRow_CanDtls.Text += " <p>&nbsp;</p>";
                        tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["mbldate"].ToString() + "</p></td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[i]["packagecode"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["marks"].ToString() + " </td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["grweight"].ToString() + "  KGS</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["descn"].ToString() + " </td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["caddress"].ToString() + " </td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " </tr>";

                        tdRow_CanDtls.Text += "   <tr>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'><p>" + dt.Rows[i]["blno"].ToString() + "</p>";
                        tdRow_CanDtls.Text += " <p>H-&gt;</p>";
                        tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["bldate"].ToString() + ";</p></td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["naddress"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";

                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["containerno"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td align='center' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["sizetype"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td nowrap='nowrap' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>Seal : " + dt.Rows[i]["sealno"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td align='center' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["Shipmenttype"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " </tr>";
                        //tdRow_CanDtls.Text += " </table>";
                        //tdRow_CanDtls.Text += " </div>";
                        if ((i == dt.Rows.Count - 1) || ((dt.Rows[i + 1]["blfd"].ToString()) != (dt.Rows[i]["blfd"].ToString())))
                        {

                            tdRow_CanDtls.Text += "  <tr>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' style='padding:2px; margin:0px;'>";
                            tdRow_CanDtls.Text += "   We hereby certify that item No. to against IGM NO. is for<br />";
                            tdRow_CanDtls.Text += "    account of ourprincipals.We,as agents are responsible for the full<br />";
                            tdRow_CanDtls.Text += "    outtern of cargo manifested under the above items and will be<br />";
                            tdRow_CanDtls.Text += "    liable to the Customs for any penalty or other dues in case of<br />";
                            tdRow_CanDtls.Text += "    any shortlandings/survey shortages.We hereby hold Mumbai<br />";
                            tdRow_CanDtls.Text += "    Agents of the vessel fully indemnified from any short<br />";
                            tdRow_CanDtls.Text += "    landings/survey shortages under the above items.We certify<br />";
                            tdRow_CanDtls.Text += "   that all items indicated in this Hard copy of IGM have been</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";

                            tdRow_CanDtls.Text += "  <tr>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += " <tr>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' valign='top' style='padding:2px; margin:0px; text-align:right;'>";
                            tdRow_CanDtls.Text += "   Date & signature of Master,authorised ag</td>";
                            tdRow_CanDtls.Text += "   <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += " <div style='clear:both;'></div>";
                          //  tdRow_CanDtls.Text += "<div class='pagebreak'> </div>";




                            //tdRow_CanDtls.Text += " </table>";
                            //tdRow_CanDtls.Text += " </div>";
                            //tdRow_CanDtls.Text += " <tr>";
                            //tdRow_CanDtls.Text += " <td  style='width:1050px;margin: 0px auto;'> ";
                            //tdRow_CanDtls.Text += " <td style='width:315px;float:right;padding:10px;' >We hereby certify that item No. to against IGM NO. is for";
                            //tdRow_CanDtls.Text += " account of ourprincipals.We,as agents are responsible for the full";
                            //tdRow_CanDtls.Text += " outtern of cargo manifested under the above items and will be";
                            //tdRow_CanDtls.Text += " liable to the Customs for any penalty or other dues in case of";
                            //tdRow_CanDtls.Text += " any shortlandings/survey shortages.We hereby hold Mumbai";
                            //tdRow_CanDtls.Text += " Agents of the vessel fully indemnified from any short";
                            //tdRow_CanDtls.Text += " landings/survey shortages under the above items.We certify";
                            //tdRow_CanDtls.Text += " that all items indicated in this Hard copy of IGM have been </td>";

                            //tdRow_CanDtls.Text += " <div style='clear:both;'></div>";

                            //tdRow_CanDtls.Text += " <td style='width:315px;float:right;text-align:right;margin-top:35px;'>Date & signature of Master,authorised ag</td>";

                            //tdRow_CanDtls.Text += " </td>";
                            //tdRow_CanDtls.Text += " </tr>";
                            //tdRow_CanDtls.Text += " <div style='clear:both;'></div>";
                        }



                    }
                    else
                    {
                        tdRow_CanDtls.Text += " <tr>";
                        tdRow_CanDtls.Text += "  <td colspan='12' align='center' style='padding:2px; margin:0px;'><div style='text-align:left; font-weight:bold; margin:0px auto; width:31%;'>From : " + dt.Rows[i]["blpol"].ToString() + " To " + dt.Rows[i]["blfd"].ToString() + "</div></td>";
                        tdRow_CanDtls.Text += "  </tr>";
                        tdRow_CanDtls.Text += "  <tr>";
                        tdRow_CanDtls.Text += "  <td valign='top' style='padding:2px; margin:0px;'><br />LC -  " + dt.Rows[i]["linenumber"].ToString() + "<br /> <br /> " + dt.Rows[i]["MT"].ToString() + "-" + dt.Rows[i]["sublineno"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td valign='top' style='padding:2px; margin:0px;'><p>M-&gt; " + dt.Rows[i]["mblno"].ToString() + "</p>";
                        tdRow_CanDtls.Text += " <p>&nbsp;</p>";
                        tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["mbldate"].ToString() + "</p></td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[i]["packagecode"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["marks"].ToString() + " </td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["grweight"].ToString() + "  KGS</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["descn"].ToString() + " </td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["caddress"].ToString() + " </td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " </tr>";

                        tdRow_CanDtls.Text += "   <tr>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'><p>" + dt.Rows[i]["blno"].ToString() + "</p>";
                        tdRow_CanDtls.Text += " <p>H-&gt;</p>";
                        tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["bldate"].ToString() + ";</p></td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["naddress"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";

                        tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["containerno"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td align='center' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["sizetype"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td nowrap='nowrap' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>Seal : " + dt.Rows[i]["sealno"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " <td align='center' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["Shipmenttype"].ToString() + "</td>";
                        tdRow_CanDtls.Text += " </tr>";


                        if ((dt.Rows[i+ 1]["blfd"].ToString()) != (dt.Rows[i]["blfd"].ToString()))
                        {
                            tdRow_CanDtls.Text += "  <tr>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' style='padding:2px; margin:0px;'>";
                            tdRow_CanDtls.Text += "   We hereby certify that item No. to against IGM NO. is for<br />";
                            tdRow_CanDtls.Text += "    account of ourprincipals.We,as agents are responsible for the full<br />";
                            tdRow_CanDtls.Text += "    outtern of cargo manifested under the above items and will be<br />";
                            tdRow_CanDtls.Text += "    liable to the Customs for any penalty or other dues in case of<br />";
                            tdRow_CanDtls.Text += "    any shortlandings/survey shortages.We hereby hold Mumbai<br />";
                            tdRow_CanDtls.Text += "    Agents of the vessel fully indemnified from any short<br />";
                            tdRow_CanDtls.Text += "    landings/survey shortages under the above items.We certify<br />";
                            tdRow_CanDtls.Text += "   that all items indicated in this Hard copy of IGM have been</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";

                            tdRow_CanDtls.Text += "  <tr>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += " <tr>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' valign='top' style='padding:2px; margin:0px; text-align:right;'>";  //height:950px;
                            tdRow_CanDtls.Text += "   Date & signature of Master,authorised ag</td>";
                            tdRow_CanDtls.Text += "   <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += " <div style='clear:both;'></div>";
                           // tdRow_CanDtls.Text += "<div class='pagebreak'> </div>";
                        }
                        //tdRow_CanDtls.Text += " </table>";
                        //tdRow_CanDtls.Text += " </div>";

                        //tdRow_CanDtls.Text += " <div  style='width:1050px;margin: 0px auto;'> ";
                        //tdRow_CanDtls.Text += " <div style='width:315px;float:right;padding:10px;' >We hereby certify that item No. to against IGM NO. is for";
                        //tdRow_CanDtls.Text += " account of ourprincipals.We,as agents are responsible for the full";
                        //tdRow_CanDtls.Text += " outtern of cargo manifested under the above items and will be";
                        //tdRow_CanDtls.Text += " liable to the Customs for any penalty or other dues in case of";
                        //tdRow_CanDtls.Text += " any shortlandings/survey shortages.We hereby hold Mumbai";
                        //tdRow_CanDtls.Text += " Agents of the vessel fully indemnified from any short";
                        //tdRow_CanDtls.Text += " landings/survey shortages under the above items.We certify";
                        //tdRow_CanDtls.Text += " that all items indicated in this Hard copy of IGM have been </div>";

                        //tdRow_CanDtls.Text += " <div style='clear:both;'></div>";

                        //tdRow_CanDtls.Text += " <div style='width:315px;float:right;text-align:right;margin-top:35px;'>Date & signature of Master,authorised ag</div>";

                        //tdRow_CanDtls.Text += " </div>";
                        //tdRow_CanDtls.Text += " <div style='clear:both;'></div>";
                    }


                }

                else
                {
                    // count.Visible = true;
                    //if ((i == dt.Rows.Count))
                    //{
                    //    tdRow_CanDtls.Text += " <div  style='width:1050px;margin: 0px auto;'> ";
                    //    tdRow_CanDtls.Text += " <div style='width:315px;float:right;padding:10px;' >We hereby certify that item No. to against IGM NO. is for";
                    //    tdRow_CanDtls.Text += " account of ourprincipals.We,as agents are responsible for the full";
                    //    tdRow_CanDtls.Text += " outtern of cargo manifested under the above items and will be";
                    //    tdRow_CanDtls.Text += " liable to the Customs for any penalty or other dues in case of";
                    //    tdRow_CanDtls.Text += " any shortlandings/survey shortages.We hereby hold Mumbai";
                    //    tdRow_CanDtls.Text += " Agents of the vessel fully indemnified from any short";
                    //    tdRow_CanDtls.Text += " landings/survey shortages under the above items.We certify";
                    //    tdRow_CanDtls.Text += " that all items indicated in this Hard copy of IGM have been </div>";

                    //    tdRow_CanDtls.Text += " <div style='clear:both;'></div>";

                    //    tdRow_CanDtls.Text += " <div style='width:315px;float:right;text-align:right;margin-top:35px;'>Date & signature of Master,authorised ag</div>";

                    //    tdRow_CanDtls.Text += " </div>";
                    //}
                    tdRow_CanDtls.Text += " <tr>";
                    tdRow_CanDtls.Text += "  <td colspan='12' align='center' style='padding:2px; margin:0px;'><div style='text-align:left; font-weight:bold; margin:0px auto; width:31%;'>From : " + dt.Rows[i]["blpol"].ToString() + " To " + dt.Rows[i]["blfd"].ToString() + "</div></td>";
                    tdRow_CanDtls.Text += "  </tr>";
                    tdRow_CanDtls.Text += "  <tr>";
                    tdRow_CanDtls.Text += "  <td valign='top' style='padding:2px; margin:0px;'><br />LC -  " + dt.Rows[i]["linenumber"].ToString() + "<br /> <br /> " + dt.Rows[i]["MT"].ToString() + "-" + dt.Rows[i]["sublineno"].ToString() + "</td>";
                    tdRow_CanDtls.Text += " <td valign='top' style='padding:2px; margin:0px;'><p>M-&gt; " + dt.Rows[i]["mblno"].ToString() + "</p>";
                    tdRow_CanDtls.Text += " <p>&nbsp;</p>";
                    tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["mbldate"].ToString() + "</p></td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[i]["packagecode"].ToString() + "</td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["marks"].ToString() + " </td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["grweight"].ToString() + "  KGS</td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["descn"].ToString() + " </td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["caddress"].ToString() + " </td>";
                    tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += " </tr>";

                    tdRow_CanDtls.Text += "   <tr>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'><p>" + dt.Rows[i]["blno"].ToString() + "</p>";
                    tdRow_CanDtls.Text += " <p>H-&gt;</p>";
                    tdRow_CanDtls.Text += " <p>" + dt.Rows[i]["bldate"].ToString() + ";</p></td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>" + dt.Rows[i]["naddress"].ToString() + "</td>";
                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";

                    tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["containerno"].ToString() + "</td>";
                    tdRow_CanDtls.Text += " <td align='center' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["sizetype"].ToString() + "</td>";
                    tdRow_CanDtls.Text += " <td nowrap='nowrap' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>Seal : " + dt.Rows[i]["sealno"].ToString() + "</td>";
                    tdRow_CanDtls.Text += " <td align='center' style='padding:2px; margin:0px;border-bottom:1px solid #000;'>" + dt.Rows[i]["Shipmenttype"].ToString() + "</td>";
                    tdRow_CanDtls.Text += " </tr>";
                    //tdRow_CanDtls.Text += " </table>";
                    //tdRow_CanDtls.Text += " </div>";
                   
                        if ((dt.Rows[0]["blfd"].ToString()) != (dt.Rows[1]["blfd"].ToString()))
                        {
                        //    tdRow_CanDtls.Text += "<div style='page-break-after:always'>";
                           // tdRow_CanDtls.Text += " <tr style='page-break-after:always'>";
                          //  tdRow_CanDtls.Text += "<tr class='page-break'>";
                          tdRow_CanDtls.Text += "  <tr>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' style='padding:2px; margin:0px;'>";
                            tdRow_CanDtls.Text += "   We hereby certify that item No. to against IGM NO. is for<br />";
                            tdRow_CanDtls.Text += "    account of ourprincipals.We,as agents are responsible for the full<br />";
                            tdRow_CanDtls.Text += "    outtern of cargo manifested under the above items and will be<br />";
                            tdRow_CanDtls.Text += "    liable to the Customs for any penalty or other dues in case of<br />";
                            tdRow_CanDtls.Text += "    any shortlandings/survey shortages.We hereby hold Mumbai<br />";
                            tdRow_CanDtls.Text += "    Agents of the vessel fully indemnified from any short<br />";
                            tdRow_CanDtls.Text += "    landings/survey shortages under the above items.We certify<br />";
                            tdRow_CanDtls.Text += "   that all items indicated in this Hard copy of IGM have been</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";

                            tdRow_CanDtls.Text += "  <tr>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";
                            tdRow_CanDtls.Text += " <tr>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "  <td colspan='4' valign='top' style='padding:2px; margin:0px; text-align:right; page-break-after:always;'>";
                            tdRow_CanDtls.Text += "   Date & signature of Master,authorised ag</td>";
                            tdRow_CanDtls.Text += "   <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td nowrap='nowrap' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += "   <td align='center' style='padding:2px; margin:0px;'>&nbsp;</td>";
                            tdRow_CanDtls.Text += " </tr>";
                          //  tdRow_CanDtls.Text += " </tr>";
                            //tdRow_CanDtls.Text += " <div style='clear:both;'></div>";
                           // tdRow_CanDtls.Text += "</div>";
                            //tdRow_CanDtls.Text += "<div class='pagebreak'> </div>";
                        }
                    }
                    //tdRow_CanDtls.Text += " <div  style='width:1050px;margin: 0px auto;'> ";
                    //tdRow_CanDtls.Text += " <div style='width:315px;float:right;padding:10px;' >We hereby certify that item No. to against IGM NO. is for";
                    //tdRow_CanDtls.Text += " account of ourprincipals.We,as agents are responsible for the full";
                    //tdRow_CanDtls.Text += " outtern of cargo manifested under the above items and will be";
                    //tdRow_CanDtls.Text += " liable to the Customs for any penalty or other dues in case of";
                    //tdRow_CanDtls.Text += " any shortlandings/survey shortages.We hereby hold Mumbai";
                    //tdRow_CanDtls.Text += " Agents of the vessel fully indemnified from any short";
                    //tdRow_CanDtls.Text += " landings/survey shortages under the above items.We certify";
                    //tdRow_CanDtls.Text += " that all items indicated in this Hard copy of IGM have been </div>";

                    //tdRow_CanDtls.Text += " <div style='clear:both;'></div>";

                    //tdRow_CanDtls.Text += " <div style='width:315px;float:right;text-align:right;margin-top:35px;'>Date & signature of Master,authorised ag</div>";

                    //tdRow_CanDtls.Text += " </div>";
                    //tdRow_CanDtls.Text += " <div style='clear:both;'></div>";
                    //tdRow_CanDtls.Text += " </table>";
                    //tdRow_CanDtls.Text += " </div>";
               
            }
            
        }


    }
}