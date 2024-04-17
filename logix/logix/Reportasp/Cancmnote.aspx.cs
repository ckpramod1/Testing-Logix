using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class Cancmnote : System.Web.UI.Page
    {
        int Bid, Cid, i, job;
        string Type = "", TOtype = "", contdtls = "", Blno = "";
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtnew;
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
                    job = Convert.ToInt32(Request.QueryString["jobno"].ToString());
                    //Blno = Request.QueryString["Blno"].ToString();
                    //Type = Request.QueryString["type"].ToString();
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["cid"]);

                    dt = da_obj_rptasp.GetCMNote(Convert.ToInt32(job), Bid, Cid);


                    if (dt.Rows.Count > 0)
                    {
                       
                        //lbl_branch.Text = dt.Rows[0]["branchname"].ToString();

                        //lbl_address.Text = dt.Rows[0]["address"].ToString();
                        //lbl_ph.Text = dt.Rows[0]["phone"].ToString();
                        //lbl_fax.Text = dt.Rows[0]["fax"].ToString();
                        for (i = 0; i < dt.Rows.Count; i++)
                        {

                            //lbl_igm.Text = dt.Rows[i]["igmsubline"].ToString();
                            //lbl_vsvoy.Text = dt.Rows[i]["vesvoy"].ToString();
                            //lbl_agent.Text = dt.Rows[i]["customername"].ToString();
                            //lbl_mbl.Text = dt.Rows[i]["mbl"].ToString();
                            //lbl_bl.Text = dt.Rows[i]["hbl"].ToString();
                            //lbl_pod.Text = dt.Rows[i]["pod"].ToString();
                            //lbl_pkg.Text = dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[i]["pkgdescn"].ToString();
                            //lbl_grwt.Text = dt.Rows[i]["grweight"].ToString();
                            //lbl_amt.Text = dt.Rows[i]["Duty"].ToString();
                            //lbl_descn.Text = dt.Rows[i]["descn"].ToString();
                            //lbl_caddre.Text = dt.Rows[i]["caddress"].ToString();
                            //lbl_from.Text = dt.Rows[i]["Fromplace"].ToString();
                            //lbl_to.Text = dt.Rows[i]["toplace"].ToString();
                            //lbl_div.Text = dt.Rows[i]["divisionname"].ToString();
                            //lbl_fromcust.Text = dt.Rows[i]["cust"].ToString();
                            //lbl_toport.Text = dt.Rows[i]["pod"].ToString();
                            //lbl_custname.Text = dt.Rows[i]["cust"].ToString();
                            //lbl_chno.Text = dt.Rows[i]["challanno"].ToString();
                            //lbl_chdate.Text = dt.Rows[i]["challandate"].ToString();

                            //tdRow_CanDtls.Text = "<body style='font-family:sans-serif, Geneva, sans-serif; font-size:16px; line-height:24px;'>";
                            tdRow_CanDtls.Text += "<div style='margin:0px auto; width:1024px; padding:10px 0px 10px 0px; font-family:Georgia; font-size:16px; line-height:24px;page-break-after: always;'>";




                            //tdRow_CanDtls.Text += "  <div style='width:1024px; margin:0px auto; padding:0px; border-bottom:1px solid #000;'>";
                            //tdRow_CanDtls.Text += "<div style='float:left; width:100px; margin:5px auto;'> <img src='../images/MR.png' width='150px'' height='auto'  /></div>";
                            //tdRow_CanDtls.Text += "<div style='width:877px; float:left;'>";
                            //tdRow_CanDtls.Text += "<h3 style='text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; '>"+ dt.Rows[i]["branchname"].ToString() + "</h3>";
                            //tdRow_CanDtls.Text += "<p style='font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;'>" + dt.Rows[i]["address"].ToString() + "</p>";
                            //tdRow_CanDtls.Text += "<p  style='font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;'><strong>Tel</strong> : " + dt.Rows[i]["phone"].ToString() + " - <strong>Fax</strong> :" + dt.Rows[i]["fax"].ToString() + "</p>";

                            //tdRow_CanDtls.Text += "</div>";
                            //tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            //tdRow_CanDtls.Text += "</div>";

                            tdRow_CanDtls.Text += "<div style='width:1024px; float:left;'>";

                            tdRow_CanDtls.Text += "<h1 style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:23px;'>CONTAINER MOVEMENT FACILITATION CELL</h1>";

                            tdRow_CanDtls.Text += "<h2 style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:23px;'>NOTE</h2>";
                            tdRow_CanDtls.Text += "<p style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:23px;'>Sub : Movement of LCL cargo by Road-Reg</p>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='margin:0px 0px 0px 0px; width:1024px; float:left;font-size: 19px;'>";

                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>TSA No. & date</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'> </div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>IGM No & Line No. / Subline No.</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["igmsubline"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Vessel / Voy</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["vesvoy"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Streamer Agent</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["customername"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Master MB/L No & Date</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["mbl"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>House B/L No & Date</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["hbl"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Place of Delivery</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["pod"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>No.of Packages</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[i]["pkgdescn"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Gross Weight</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["grweight"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Value + Duty amount(INR)</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Rs." + dt.Rows[i]["Duty"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Description of Cargo</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + dt.Rows[i]["descn"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Name & Address of Consignee</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;'>" + dt.Rows[i]["caddress"].ToString() + "</div>";


                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Mode of Transport</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;'>BY ROAD</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>From</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;'>" + dt.Rows[i]["Fromplace"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>To</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;'>" + dt.Rows[i]["toplace"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "</div>";

                            tdRow_CanDtls.Text += "<div style='width:1024px; float:left; border:0px solid #000; height: 550px;font-size: 19px;'>";
                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px;'>";
                            if (hid_divsname.Value == "Y")
                            {
                                tdRow_CanDtls.Text += "The transshipment aplication has been filled by the Consol / Steamer Agent viz: " + lblcmpnyname.Text + " for the movement of above mentioned LCL Cargo From ";

                            }
                            else
                            {
                                tdRow_CanDtls.Text += "The transshipment aplication has been filled by the Consol / Steamer Agent viz: " + dt.Rows[i]["divisionname"].ToString() + " for the movement of above mentioned LCL Cargo From ";

                            }
                            tdRow_CanDtls.Text += dt.Rows[i]["cust"].ToString() + " CFS to " + dt.Rows[i]["pod"].ToString() + " ICD by Road. Goods";
                            tdRow_CanDtls.Text += " are currently lying at " + dt.Rows[i]["cust"].ToString() + " CFS-Chennai who";
                            tdRow_CanDtls.Text += " has executed running  Bond of Rs. " + dt.Rows[i]["bond"].ToString() + "  crores .";
                            tdRow_CanDtls.Text += "</p>";
                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px;'>";
                            tdRow_CanDtls.Text += "The Agents have submitted letter from CFS in Original requesting transfer of goods and also submitted";
                            tdRow_CanDtls.Text += " photo copies of sub manifested B.L.,Invoice and Packing List along with Cargo declaration form.";
                            tdRow_CanDtls.Text += "</p>";
                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px;'>";
                            tdRow_CanDtls.Text += " TSA fee of Rs.20/- collected vide Challan No:  " + dt.Rows[i]["challanno"].ToString() + " dated: " + dt.Rows[i]["challandate"].ToString() + " Neccessary debiting has also";
                            tdRow_CanDtls.Text += " been done from the Bond executed by the CFS to cover the safety & security of Cargo during transit.";
                            tdRow_CanDtls.Text += "</p>";

                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px;'>";
                            tdRow_CanDtls.Text += "Request of the Consol / Streamer Agent may be considered and transshipment may be permitted";
                            tdRow_CanDtls.Text += " please.";
                            tdRow_CanDtls.Text += "</p>";

                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:250px 0px 0px 0px; font-size:21px; font-weight:bold; text-align:right;'>";
                            tdRow_CanDtls.Text += "Supdt.(CMFC)";
                            tdRow_CanDtls.Text += "</p>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            int a = i + 1;
                            tdRow_CanDtls.Text += "<p style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center;color: #b1b1b1;float: right; font-size:18px;width:1024px;'> " + a + "</p>";
                            tdRow_CanDtls.Text += "</div>";

                            //tdRow_CanDtls.Text = "</body>";
                        }
                    }

                    else
                    {
                        tdRow_CanDtls.Text += "<div style='margin:0px auto; width:1024px; padding:10px 0px 10px 0px; font-family:Georgia; font-size:16px; line-height:24px;'>";
                        tdRow_CanDtls.Text += "<div style='width:1024px; float:left;'>";

                        tdRow_CanDtls.Text += "<h1 style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:21px;'>CONTAINER MOVEMENT FACILITATION CELL</h1>";
                        tdRow_CanDtls.Text += "<h2 style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:21px;'>NOTE</h2>";
                        tdRow_CanDtls.Text += "<p style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center; font-size:21px;'>Sub : Movement of LCL cargo by Road-Reg</p>";
                        tdRow_CanDtls.Text += "</div>";
                        tdRow_CanDtls.Text += "<div style='margin:0px 0px 0px 0px; width:1024px; float:left;'>";

                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>TSA No. & date</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'> </div>";
                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>IGM No & Line No. / Subline No.</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Vessel / Voy</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Streamer Agent</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Master MB/L No & Date</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>House B/L No & Date</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Place of Delivery</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>No.of Packages</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + " " + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Gross Weight</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Value + Duty amount(INR)</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Rs." + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Description of Cargo</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Name & Address of Consignee</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;'>" + "</div>";


                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>Mode of Transport</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;'>BY ROAD</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>From</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;'>" + "</div>";

                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px;'>To</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px; margin:0px;'>:</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; width:492px; padding:5px; margin:0px; white-space:pre-line;'>" + "</div>";
                        tdRow_CanDtls.Text += "</div>";

                        tdRow_CanDtls.Text += "<div style='width:1024px; float:left; height:795px; border:0px solid #000;'>";
                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px;'>";
                        tdRow_CanDtls.Text += "The transshipment aplication has been filled by the Consol / Steamer Agent viz: FORWARDING PRIVATE LIMITED  for the movement of above mentioned LCL Cargo From ";
                        tdRow_CanDtls.Text += " to " + " ICD by Road. Goods";
                        tdRow_CanDtls.Text += " are currently lying at " + " CFS-Chennai who";
                        tdRow_CanDtls.Text += " has executed running  Bond of Rs. " + "  crores .";
                        tdRow_CanDtls.Text += "</p>";
                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px;'>";
                        tdRow_CanDtls.Text += "The Agents have submitted letter from CFS in Original requesting transfer of goods and also submitted";
                        tdRow_CanDtls.Text += " photo copies of sub manifested B.L.,Invoice and Packing List along with Cargo declaration form.";
                        tdRow_CanDtls.Text += "</p>";
                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px;'>";
                        tdRow_CanDtls.Text += " TSA fee of Rs.20/- collected vide Challan No:  " + " dated: " + " Neccessary debiting has also";
                        tdRow_CanDtls.Text += " been done from the Bond executed by the CFS to cover the safety & security of Cargo during transit.";
                        tdRow_CanDtls.Text += "</p>";

                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px;'>";
                        tdRow_CanDtls.Text += "Request of the Consol / Streamer Agent may be considered and transshipment may be permitted";
                        tdRow_CanDtls.Text += " please.";
                        tdRow_CanDtls.Text += "</p>";

                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px 0px 0px 0px; font-size:18px; font-weight:bold; text-align:right;page-break-after: always;'>";
                        tdRow_CanDtls.Text += "Supdt.(CMFC)";
                        tdRow_CanDtls.Text += "</p>";
                        tdRow_CanDtls.Text += "</div>";
                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "</div>";

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