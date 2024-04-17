
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class ICDTsa : System.Web.UI.Page
    {
        int Bid, Cid, i, job;
        string Type = "", TOtype = "", contdtls = "", Blno = "";
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
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
                obj_da_log.GetDataBase(Ccode);



            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Designing();", true);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            try
            {
                if (Request.QueryString.ToString().Contains("jobno"))
                {
                    job = Convert.ToInt32(Request.QueryString["jobno"].ToString());
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["cid"]);
                    //DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(obj_da_log.GetDate()));
                    dt = da_obj_rptasp.GetICDTSA(Convert.ToInt32(job), Bid, Cid);
                    if (dt.Rows.Count > 0)
                    {
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            tdRow_CanDtls.Text += " <div style='width:1024px;border:1px solid #000; margin:0px auto; line-height:24px;page-break-after:always;'>";

                            ////  tdRow_CanDtls.Text += "<div style='width:1024px; margin:0px;  padding:10px 0px 5px 0px;page-break-after: always;'>";
                            //  //tdRow_CanDtls.Text += "  <div style='width:1024px; margin:0px auto; padding:0px;page-break-after:always; border-bottom:1px solid #000;'>";

                            //  tdRow_CanDtls.Text += " <div style='width:1024px; margin:0px auto;border-bottom:1px solid #000; line-height:24px;page-break-after: always;'>";
                            //tdRow_CanDtls.Text += "<div style='float:left; width:100px; margin:5px auto;'> <img src='../images/MR.png' width='150px'' height='auto'  /></div>";
                            //tdRow_CanDtls.Text += "<div style='width:877px; float:left;'>";
                            //tdRow_CanDtls.Text += "<h3 style='text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; '>" + dt.Rows[i]["branchname"].ToString() + "</h3>";
                            //tdRow_CanDtls.Text += "<p style='font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;'>" + dt.Rows[i]["address"].ToString() + "</p>";
                            //tdRow_CanDtls.Text += "<p  style='font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;'><strong>Tel</strong> : " + dt.Rows[i]["phone"].ToString() + " - <strong>Fax</strong> :" + dt.Rows[i]["fax"].ToString() + "</p>";

                            //tdRow_CanDtls.Text += "</div>";
                            //tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            //tdRow_CanDtls.Text += "</div>";

                            tdRow_CanDtls.Text += "<h3 style='text-align: center; font-weight: bold;margin: 25px 0px 0px 0px; font-family: Arial, Helvetica, sans-serif'>Transhipment Application</h3>";
                            tdRow_CanDtls.Text += "<div class='row' style='justify-content: space-between; margin: 50px 0px 20px;padding:0 15px'>";
                            tdRow_CanDtls.Text += "<div><h3 style='margin: 0px 0px 10px -237px'>To</h3><p>The Asst.Commissioner of Customs.</p><p>Custom House</p><p>Chennai - 600001</p></div>";

                            tdRow_CanDtls.Text += "<div> <div class='row'><p style='font-weight: bold; width: 80px'>TSA No.</p><p style='font-weight: bold; width: 10px'>:</p><p></p></div>";
                            tdRow_CanDtls.Text += "<div class='row'><p style='font-weight: bold; width: 80px'>Date</p><p style='font-weight: bold; width: 10px'>:</p><p>" + dt.Rows[i]["date"].ToString() + "</p></div></div></div>";

                            tdRow_CanDtls.Text += " <p style='font-weight: bold;padding: 0px 0px 0px 15px;'>Sir,</p>";
                            tdRow_CanDtls.Text += "<p style='width: 90%; margin: 10px 0px 0px; line-height: 20px; padding: 0px 0px 15px 15px; line-height: 25px'>Please permit to tranship the goods with following particulars by Road from " + dt.Rows[i]["customername"].ToString() + " CFS-Chennai to " + dt.Rows[i]["portname"].ToString() + " ICD under the coverage of " + dt.Rows[i]["customername"].ToString() + " on behalf of the consignee M/s " + dt.Rows[i]["consignee"].ToString() + "</p>";

                            tdRow_CanDtls.Text += "<div class='row' style='border-top: 1px solid #000; padding: 15px 15px 0px;justify-content:space-between'>";

                            tdRow_CanDtls.Text += "<div style='width: 60%'><div class='row'><p style='font-weight: bold; width: 205px'>Name of the Vessel</p> <p style='font-weight: bold; width: 10px'>:</p><p>" + dt.Rows[i]["vesselname"].ToString() + " V. " + dt.Rows[i]["voyage"].ToString() + "</p></div>";

                            tdRow_CanDtls.Text += "<div class='row'><p style='font-weight: bold; width: 205px'>HBL No.</p> <p style='font-weight: bold; width: 10px'>:</p><p>" + dt.Rows[i]["blno"].ToString() + "</p></div>";

                            tdRow_CanDtls.Text += "<div class='row'><p style='font-weight: bold; width: 205px'>Container No</p><p style='font-weight: bold; width: 10px'>:</p><p>" + dt.Rows[i]["containerno"].ToString() + "</p></div></div> ";

                            tdRow_CanDtls.Text += "<div style='width: 40%'><div class='row'><p style='font-weight: bold; width: 160px'>Arrived on</p><p style='font-weight: bold; width: 10px'>:</p><p>" + dt.Rows[i]["eta"].ToString() + "</p></div>";

                            tdRow_CanDtls.Text += "<div class='row'><p style='font-weight: bold; width: 160px'>MBL Date</p><p style='font-weight: bold; width: 10px'>:</p> <p>" + dt.Rows[i]["mbldate"].ToString() + "</p></div>";

                            tdRow_CanDtls.Text += "<div class='row'><p style='font-weight: bold; width: 160px'>HBL Date</p><p style='font-weight: bold; width: 10px'>:</p><p>" + dt.Rows[i]["HBldate"].ToString() + "</p></div></div></div> ";
                            // ADD BY YUVARAJ 13FEB23
                            tdRow_CanDtls.Text += "<table style='border: 1px solid #000; border-left:0;border-right:0; border-collapse: collapse; margin: 15px 0px'>";
                            tdRow_CanDtls.Text += "<thead><tr><th style='border: 1px solid #000; padding: 2px 10px'><p>Marks & No</p></th>";
                            tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Number & Kind of Packages</p></th>";
                            tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Description of the Goods</p></th>";
                            tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Weight & Volume</p></th>";
                            tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Mainfested Under IGM No, Line No</p></th>";
                            tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Value + Duty (Rs.)</p></th>";
                            tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Remarks</p></th></tr></thead>";

                            tdRow_CanDtls.Text += "<tbody><tr valign='top' style='height: 150px'>";
                            tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p>" + dt.Rows[i]["marks"].ToString() + "</p></td>";
                            tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p>" + dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[i]["descn"].ToString() + "</p></td>";
                            tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p>" + dt.Rows[i]["description"].ToString() + "</p></td>";
                            tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p>" + dt.Rows[i]["grweight"].ToString() + "</p></td>";
                            // tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p>" + dt.Rows[i]["imno"].ToString() + "Dt."+string.Format("{0:dd-MM-yy}", dt.Rows[0]["imdate"]) +"/"+dt.Rows[i]["imnoyear"].ToString()+dt.Rows[i]["linenumber"].ToString()+"/"+dt.Rows[i]["sublineno"].ToString()+  dt.Rows[i]["cbm"].ToString()+"cbm" +"</p></td>";                          
                            // tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p>" + dt.Rows[i]["igmsubline"].ToString() + "/" + dt.Rows[i]["imnoyear"].ToString()+" " +dt.Rows[i]["cbm"].ToString() + " cbm" + "</p></td>";       
                            tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p>" + dt.Rows[i]["igmsubline"].ToString() + "/" + " " + dt.Rows[i]["cbm"].ToString() + " cbm" + "</p></td>";
                            tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p>" + dt.Rows[i]["duty"].ToString() + "</p></td>";
                            tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p></p></td></tr></tbody></table>";

                            tdRow_CanDtls.Text += "<div class='row' style='padding:0 15px'><div style='width: 425px'><p>Name & Address of Consignee</p></div><div>";
                            //tdRow_CanDtls.Text +=  "<p style='line-height: 25px'>"+dt.Rows[i]["consignee"].ToString()+"</p>";
                            tdRow_CanDtls.Text += "<p style='line-height: 25px;font-size:14px'>" + dt.Rows[i]["caddress"].ToString() + "</p></div></div>";

                            tdRow_CanDtls.Text += "<div class='row' style='padding:0 15px'><p style='width: 345px'>Jurisdictional Customs / Central</p><p style='width: 10px'>:</p><p>Asst/Dy.Commissioner of Customs</p></div>";
                            tdRow_CanDtls.Text += "<div class='row' style='padding:0 15px'><p style='width: 345px'>Excise authority at destination Address</p><p style='width: 10px'>:</p><p>" + dt.Rows[i]["portname"].ToString() + "</p></div>";
                            tdRow_CanDtls.Text += "<p style='width: 70%; margin: 10px 0px 0px 0px; padding: 0px 15px; line-height: 25px'>Transhipment fee of <span>Rs.20/-</span> paid vide <span>challan No :</span> <span>" + dt.Rows[i]["challanno"].ToString() + "</span> <span>dt :</span> <span>" + string.Format("{0:dd-MM-yy}", dt.Rows[i]["challandate"]) + "</span> we do declare the contents of this application to be truly stated .</p>";
                            tdRow_CanDtls.Text += "<div style='width: 200px; float: right; margin: 0px 0px 50px'><p>Seal and sign of</p><p>Consol / Steamer Agent</p></div><div style='clear: both'></div>";

                            tdRow_CanDtls.Text += "<p style='width: 85%; margin: 10px 0px 0px 0px;padding: 0px 15px; line-height: 25px'>Notional value of <span>Rs. " + dt.Rows[i]["duty"].ToString() + "</span> is debited in the Running Bond of <span>Rs. " + dt.Rows[i]["bond"].ToString() + "</span> crores executed by " + dt.Rows[i]["customername"].ToString() + " CFS</p>";
                            tdRow_CanDtls.Text += "<p style='width: 85%; margin: 10px 0px 0px 0px;padding: 0px 15px; line-height: 25px'>Transhipment of the above said LCL Cargo may be permitted under preventive supervision  By ROAD from " + dt.Rows[i]["customername"].ToString() + ", CFS-Chennai to ICD " + dt.Rows[i]["portname"].ToString() + "</p>";
                            tdRow_CanDtls.Text += "<div style='text-align: right; margin: 20px 0px 0px;padding: 0px 15px;'><p>T / S permitted</p></div><div style='clear: both'</div><div style='text-align: right; margin: 120px 0px 0px;padding: 0px 15px; font-weight: bold'><p>Supdt.(CMFC)</p></div>";
                            int a = i + 1;
                            tdRow_CanDtls.Text += "<p style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center;color: #b1b1b1;float: right; font-size:18px;width: 1024px;'> " + a + "</p>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "</div>";
                            ///new---------------------------

                        }
                    }
                    else
                    {

                        tdRow_CanDtls.Text += " <div style='width:1024px; margin:0px auto; line-height:24px;page-break-after: always;'>";

                        tdRow_CanDtls.Text += "<div style='width:1024px; margin:0px;  padding:10px 0px 5px 0px;text-align: center;'>";
                        int a = i + 1;
                        tdRow_CanDtls.Text += "<p style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center;color: #b1b1b1;float: right; font-size:18px;'> " + a + "</p>";
                        tdRow_CanDtls.Text += "<h3 style='text-align: center; font-weight: bold; font-family: Arial, Helvetica, sans-serif'>Transhipment Application</h3>";
                        tdRow_CanDtls.Text += "<div class='row style=justify-content: space-between; margin: 50px 0px 20px'>";
                        tdRow_CanDtls.Text += "<div><h3 style='margin: 0px 0px 10px -237px'>To</h3><p>The Asst.Commissioner of Customs.</p><p>Custom House</p><p>Chennai - 600001</p></div>";

                        tdRow_CanDtls.Text += " <div><div class='row'><p style='font-weight: bold; width: 80px'>TSA No.</p><p style='font-weight: bold; width: 10px'>:</p><p></p></div>";
                        tdRow_CanDtls.Text += "<div class='row'><p style='font-weight: bold; width: 80px'>Date</p><p style='font-weight: bold; width: 10px'>:</p><p>" + obj_da_log.GetDate().ToShortDateString() + "</p></div></div></div>";

                        tdRow_CanDtls.Text += " <p style='font-weight: bold;float:left;'>Sir,</p>";
                        tdRow_CanDtls.Text += "<p style='width: 75%; margin: 10px 0px 0px; line-height: 20px; padding: 0px 0px 30px 0px; line-height: 25px'>Please permit to tranship the goods with following particulars by Road from  CFS-Chennai to  ICD under the coverage of  on behalf of the consignee M/s </p>";
                        tdRow_CanDtls.Text += "<div class='row' style='border-top: 1px solid #000; padding: 30px 0px 0px 0px>";
                        tdRow_CanDtls.Text += "<div style='width: 60%'><div class='row'><p style='font-weight: bold; width: 160px'>HBL</p><p style='font-weight: bold; width: 10px'>:</p><p></p></div>";
                        tdRow_CanDtls.Text += "<div class='row'><p style='font-weight: bold; width: 205px'>Name of the Vessel</p><p style='font-weight: bold; width: 10px'>:</p><p></p></div></div>";

                        tdRow_CanDtls.Text += "<div style='width: 40%'><div class='row'>";
                        tdRow_CanDtls.Text += "<p style='font-weight: bold; width: 160px'>Container No</p>";
                        tdRow_CanDtls.Text += "<p style='font-weight: bold; width: 10px'>:</p><p></p></div>";
                        tdRow_CanDtls.Text += "<div class='row'><p style='font-weight: bold; width: 160px'>Arrived on</p>";
                        tdRow_CanDtls.Text += "<p style='font-weight: bold; width: 10px'>:</p><p></p></div></div></div>";

                        tdRow_CanDtls.Text += "<table style='border: 1px solid #000; border-collapse: collapse; margin: 30px 0px'>";
                        tdRow_CanDtls.Text += "<thead><tr><th style='border: 1px solid #000; padding: 2px 10px'><p>Marks & No</p></th>";
                        tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Number & Kind of Packages</p></th>";
                        tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Description of the Goods</p></th>";
                        tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Weight or Quantity</p></th>";
                        tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Mainfested Under IM no,</p></th>";
                        tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Value + Duty (Rs.)</p></th>";
                        tdRow_CanDtls.Text += "<th style='border: 1px solid #000; padding: 2px 10px'><p>Remarks</p></th></tr></thead>";

                        tdRow_CanDtls.Text += "<tbody><tr valign='top' style='height: 150px'>";
                        tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p></p></td>";
                        tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p></p></td>";
                        tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p></p></td>";
                        tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p></p></td>";
                        tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p></p></td>";
                        tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p></p></td>";
                        tdRow_CanDtls.Text += "<td style='border: 1px solid #000; padding: 5px 10px; line-height: 25px'><p></p></td></tr></tbody></table>";

                        tdRow_CanDtls.Text += "<div class='row'><div style='width: 310px'><p>Name & Address of Consignee</p></div><div>";
                        tdRow_CanDtls.Text += "<p style='line-height: 25px'></p>";
                        tdRow_CanDtls.Text += "<p style='line-height: 25px'></p></div></div>";

                        tdRow_CanDtls.Text += "<div class='row'><p style='width: 310px'>Jurisdictional Customs / Central</p><p style='width: 10px'>:</p><p>Asst/Dy.Commissioner of Customs</p></div>";
                        tdRow_CanDtls.Text += "<div class='row'><p style='width: 310px'>Excise authority at destination Address</p><p style='width: 10px'>:</p><p></p></div>";
                        tdRow_CanDtls.Text += "<p style='width: 70%; margin: 10px 0px 0px 0px; line-height: 25px'>Transhipment fee of <span>Rs.20/-</span> paid vide <span>challan No :</span> <span></span> <span>dt :</span> <span></span> we do declare the contents of this application to be truly stated .</p>";
                        tdRow_CanDtls.Text += "<div style='width: 200px; float: right; margin: 100px 0px 40px'><p>Seal and sign of</p><p>Consol / Steamer Agent</p></div><div style='clear: both'></div>";

                        tdRow_CanDtls.Text += "<p style='width: 85%; margin: 10px 0px 0px 0px; line-height: 25px'>Notional value of <span>Rs. </span> is debited in the Running Bond of <span>Rs. </span> crores executed by CFS</p>";
                        tdRow_CanDtls.Text += "<p style='width: 85%; margin: 10px 0px 0px 0px; line-height: 25px'>Transhipment of the above said LCL Cargo may be permitted under preventive supervision of loading at closed container with one time customs seal, from  CFS-Chennai to ICD </p>";
                        tdRow_CanDtls.Text += "<div style='text-align: right; margin: 20px 0px 0px'><p>T / S permitted</p></div><div style='clear: both'</div><div style='text-align: right; margin: 120px 0px 0px; font-weight: bold'><p>Supdt.(CMFC)</p></div></div>";

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

