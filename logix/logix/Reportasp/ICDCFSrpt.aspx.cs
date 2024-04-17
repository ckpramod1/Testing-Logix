using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class ICDCFSrpt : System.Web.UI.Page
    {
        int Bid, Cid, i,job ;
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
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["cid"]);
                    //DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(obj_da_log.GetDate()));
                    dt = da_obj_rptasp.GetICDCFS(Convert.ToInt32(job), Bid, Cid);
                    if (dt.Rows.Count > 0)
                    {
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            tdRow_CanDtls.Text += " <div style='width:1024px; margin:0px auto; line-height:24px;page-break-after: always;'>";

                            //tdRow_CanDtls.Text += "  <div style='width:1024px; margin:0px auto; padding:0px; border-bottom:1px solid #000;'>";
                            //tdRow_CanDtls.Text += "<div style='float:left; width:100px; margin:5px auto;'> <img src='../images/MR.png' width='150px'' height='auto'  /></div>";
                            //tdRow_CanDtls.Text += "<div style='width:877px; float:left;'>";
                            //tdRow_CanDtls.Text += "<h3 style='text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold; '>" + dt.Rows[i]["branchname"].ToString() + "</h3>";
                            //tdRow_CanDtls.Text += "<p style='font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;'>" + dt.Rows[i]["address"].ToString() + "</p>";
                            //tdRow_CanDtls.Text += "<p  style='font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;'><strong>Tel</strong> : " + dt.Rows[i]["phone"].ToString() + " - <strong>Fax</strong> :" + dt.Rows[i]["fax"].ToString() + "</p>";

                            //tdRow_CanDtls.Text += "</div>";
                            //tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            //tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='width:1024px; margin:0px;  padding:10px 0px 5px 0px;text-align: center;'>";
                           
                            tdRow_CanDtls.Text += "<h3 style='padding:5px 0px 5px 0px; margin:5px 0px 5px 0px; text-align:center;font-weight: bold; '>" + dt.Rows[i]["cust"].ToString() + " </h3>";
                            tdRow_CanDtls.Text += "<div style=' text-align:center;margin:0px;  padding:0px 0px 0px 0px; border-bottom: 0px solid #000; font-size:15px;'>"+ dt.Rows[i]["custadd"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='width:1024px; margin:0px;  padding:10px 0px 5px 5px;text-align: center;'>";

                            tdRow_CanDtls.Text += "<div style='width:512px; margin:0px 0px 12px 5px;text-align: left; padding:0px 0px 0px 0px; float:left;'>";
                            tdRow_CanDtls.Text += "<div style='font-size: 18px;font-weight: bold;text-align: left; '>To </div>";
                            tdRow_CanDtls.Text += "<div style='font-size: 18px;text-align: left; padding:5px 0px 0px 0px;'>The Asst./Dy.Commissioner of Customs.</div>";
                            tdRow_CanDtls.Text += "<div style='font-size: 18px;text-align: left;'>Custom House,</div>";
                            tdRow_CanDtls.Text += "<div style='font-size: 18px;text-align: left;'>Chennai - 600001.</div>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='width:190px; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px; float:right;'>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='float:left; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px;'>";
                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px; font-size: 18px;'>Dated :</p> ";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px;'>";
                            tdRow_CanDtls.Text += "<p style='padding:5px 5px 5px 5px;font-size: 18px; margin:0px 0px 0px 0px;'>" + dt.Rows[i]["date"].ToString() + "</p>";
                            tdRow_CanDtls.Text += "</div>";

                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "	</div>";

                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div stlyle='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:1014px; float:left; font-size: 18px;margin: 0px 0px 0px 5px'>";
                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px;'>Sir,</p>";
                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px;'>Sub :</p>";
                            tdRow_CanDtls.Text += "<p style=' padding:5px 5px 5px 37px; margin:0px;'>";
                            tdRow_CanDtls.Text += " Request to grant permission for the movement of imported LCL Cargo from " + dt.Rows[i]["cust"].ToString() + "  CFS-Chennai to " + dt.Rows[i]["pod"].ToString() + " under the coverage";
                            tdRow_CanDtls.Text += " of " + dt.Rows[i]["cust"].ToString() + " CFS's Bond, as per transshipment";
                            tdRow_CanDtls.Text += " procedure-Reg.";
                            tdRow_CanDtls.Text += "</p>";
                            tdRow_CanDtls.Text += "<div style='font-weight: bold;font-size: 18px; margin: 10px 0px 0px 0px;'>";
                            tdRow_CanDtls.Text += "PARTICULARS OF CARGO</div>";

                            tdRow_CanDtls.Text += "<div style='float: left; width:1000px; margin: 5px 0px 0px 0px;'>";

                            tdRow_CanDtls.Text += "<ul style='padding: 5px 5px 5px 5px; margin: 0px 0px 0px 0px;'>";
                            tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 10px; margin: 0px 0px 0px 0px;'>1 . Cargo arrived in the Vessel m.v : " + dt.Rows[i]["vesvoy"].ToString() + "</li>";

                            tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 32px; margin: 0px 0px 0px 0px;'>IGM No : " + dt.Rows[i]["igm"].ToString() + " ,Line / Subline No : " + dt.Rows[i]["subline"].ToString() + "</li>";
                            tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 32px; margin: 0px 0px 0px 0px;'>HBL No : " + dt.Rows[i]["blno"].ToString() + "  & Container No :  " + dt.Rows[i]["containerno"].ToString() + "</li>";

                            tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 10px; margin: 0px 0px 0px 0px;'>2. Cargo Description :  " + dt.Rows[i]["descn"].ToString() + "</li>";

                            tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 10px; margin: 0px 0px 0px 0px;'>3. No.of Packages : " + dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[i]["pkgdescn"].ToString() + "</li>";
                            tdRow_CanDtls.Text += "</ul>";

                            tdRow_CanDtls.Text += "</div>";

                            tdRow_CanDtls.Text += "<div style='width:1000px; float:left; font-size: 18px;margin: 20px 0px 0px 5px'>";
                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px;'>";
                            if (hid_divsname.Value == "Y")
                            {
                                tdRow_CanDtls.Text += "We on behalf of the Consol / Steamer Agent-M/s: " + lblcmpnyname.Text + "";
                            }
                            else
                            {
                                tdRow_CanDtls.Text += "We on behalf of the Consol / Steamer Agent-M/s: " + dt.Rows[i]["divisionname"].ToString() + "";
                           
                            }
                            tdRow_CanDtls.Text += " Hearby request you to kindly grant permission to";
                            tdRow_CanDtls.Text += " move the above mentioned imported LCL Cargo from " + dt.Rows[i]["cust"].ToString() + " to " + dt.Rows[i]["pod"].ToString() + " ICD by Road";
                            tdRow_CanDtls.Text += "</p>";
                            tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px;'>";
                            tdRow_CanDtls.Text += "	The notional value of Rs." + dt.Rows[i]["Duty"].ToString() + " (Assessable Value+Duty) may please be debited from our Running";
                            tdRow_CanDtls.Text += " Bond of Rs. " + dt.Rows[i]["bond"].ToString() + " crores for the safely and security of Cargo during transit";
                            tdRow_CanDtls.Text += "</p>";
                            tdRow_CanDtls.Text += "</div>";

                            tdRow_CanDtls.Text += "<div style='width:1024px; float:left; font-size: 18px;margin: 20px 0px 20px 0px; height:530px;'>";
                            tdRow_CanDtls.Text += "	<div style=' width: 200px; float: right; margin: 20px 0px 0px 0px;'>";

                            tdRow_CanDtls.Text += "<div style='width: 136px; float:left; font-size: 18px;padding: 12px;'>Yours faithfully</div>";
                            tdRow_CanDtls.Text += "<div style='width: 180px; float:left; font-size: 18px;padding: 32px 0px 0px 0px;'>Seal and sign of CFS</div>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "</div>";

                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            int a = i + 1;
                            tdRow_CanDtls.Text += "<p style='padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; text-align:center;color: #b1b1b1;float: right;width: 1024px; font-size:18px;'> " + a + "</p>"; 
                            tdRow_CanDtls.Text += "</div>";

                        }
                    }
                    else
                    {

                        tdRow_CanDtls.Text += " <div style='width:1024px; margin:0px auto; line-height:24px;'>";

                        tdRow_CanDtls.Text += "<div style='width:1024px; margin:0px;  padding:10px 0px 5px 0px;text-align: center;'>";
                        tdRow_CanDtls.Text += "<h3 style='padding:5px 0px 5px 0px; margin:5px 0px 5px 0px; text-align:center;font-weight: bold; '>" + " </h3>";
                        tdRow_CanDtls.Text += "<div style=' text-align:center;margin:0px;  padding:0px 0px 0px 0px; border-bottom: 0px solid #000; font-size:15px;'>" + "</div>";
                        tdRow_CanDtls.Text += "<div style='width:1024px; margin:0px;  padding:10px 0px 5px 5px;text-align: center;'>";

                        tdRow_CanDtls.Text += "<div style='width:512px; margin:0px 0px 12px 5px;text-align: left; padding:0px 0px 0px 0px; float:left;'>";
                        tdRow_CanDtls.Text += "<div style='font-size: 18px;font-weight: bold;text-align: left; '>To </div>";
                        tdRow_CanDtls.Text += "<div style='font-size: 18px;text-align: left; padding:5px 0px 0px 0px;'>The Asst./Dy.Commissioner of Customs.</div>";
                        tdRow_CanDtls.Text += "<div style='font-size: 18px;text-align: left;'>Custom House,</div>";
                        tdRow_CanDtls.Text += "<div style='font-size: 18px;text-align: left;'>Chennai - 600001.</div>";
                        tdRow_CanDtls.Text += "</div>";
                        tdRow_CanDtls.Text += "<div style='width:175px; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px; float:right;'>";
                        tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='float:left; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px;'>";
                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px; font-size: 18px;'>Dated :</p> ";
                        tdRow_CanDtls.Text += "</div>";
                        tdRow_CanDtls.Text += "<div style='float:left; margin:0px 0px 0px 0px; padding:0px 0px 0px 0px;'>";
                        tdRow_CanDtls.Text += "<p style='padding:5px 5px 5px 5px;font-size: 18px; margin:0px 0px 0px 0px;'>" + obj_da_log.GetDate().ToShortDateString() + "</p>";
                        tdRow_CanDtls.Text += "</div>";

                        tdRow_CanDtls.Text += "</div>";
                        tdRow_CanDtls.Text += "	</div>";

                        tdRow_CanDtls.Text += "</div>";
                        tdRow_CanDtls.Text += "<div stlyle='clear:both;'></div>";
                        tdRow_CanDtls.Text += "<div style='width:1014px; float:left; font-size: 18px;margin: 0px 0px 0px 5px'>";
                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px;'>Sir,</p>";
                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px;'>Sub :</p>";
                        tdRow_CanDtls.Text += "<p style=' padding:5px; margin:0px;'>";
                        tdRow_CanDtls.Text += " Request to grant permission for the movement of imported LCL Cargo from "  + "  CFS-Chennai to " +  " under the coverage";
                        tdRow_CanDtls.Text += " of "  + " CFS's Bond, as per transshipment";
                        tdRow_CanDtls.Text += " procedure-Reg.";
                        tdRow_CanDtls.Text += "</p>";
                        tdRow_CanDtls.Text += "<div style='font-weight: bold;font-size: 18px; margin: 10px 0px 0px 0px;'>";
                        tdRow_CanDtls.Text += "PARTICULARS OF CARGO</div>";

                        tdRow_CanDtls.Text += "<div style='float: left; width:1000px; margin: 5px 0px 0px 0px;'>";

                        tdRow_CanDtls.Text += "<ul style='padding: 5px 5px 5px 5px; margin: 0px 0px 0px 0px;'>";
                        tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 10px; margin: 0px 0px 0px 0px;'>1 . Cargo arrived in the Vessel m.v : " + "</li>";

                        tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 32px; margin: 0px 0px 0px 0px;'>IGM No : " + " ,Line / Subline No : " + "</li>";
                        tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 32px; margin: 0px 0px 0px 0px;'>HBL No : " +  "  & Container No :  " +   "</li>";

                        tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 10px; margin: 0px 0px 0px 0px;'>2. Cargo Description :  " + "</li>";

                        tdRow_CanDtls.Text += "<li style='list-style: none; padding: 5px 0px 5px 10px; margin: 0px 0px 0px 0px;'>3. No.of Packages : " + " " +   "</li>";
                        tdRow_CanDtls.Text += "</ul>";

                        tdRow_CanDtls.Text += "</div>";

                        tdRow_CanDtls.Text += "<div style='width:1000px; float:left; font-size: 18px;margin: 20px 0px 0px 5px'>";
                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px;'>";
                        tdRow_CanDtls.Text += "We on behalf of the Consol / Steamer Agent-M/s: FORWARDING PRIVATE LIMITED";
                        tdRow_CanDtls.Text += " Hearby request you to kindly grant permission to";
                        tdRow_CanDtls.Text += " move the above mentioned imported LCL Cargo from " + " to " +  " ICD by Road";
                        tdRow_CanDtls.Text += "</p>";
                        tdRow_CanDtls.Text += "<p style='padding:5px; margin:0px;'>";
                        tdRow_CanDtls.Text += "	The notional value of Rs." + " (Assessable Value+Duty) may please be debited from our Running";
                        tdRow_CanDtls.Text += " Bond of Rs. " + " crores for the safely and security of Cargo during transit .Further we here by undertake to submit landing Certificate(LC) within a month ";
                        tdRow_CanDtls.Text += "as stipulated in Secton 54 of the Customs Act,1962 read with Goods Imported";
                        tdRow_CanDtls.Text += "(Container of Transhipment) regulation,1995 and CBIC Guidelines as per para 2(iv)";
                        tdRow_CanDtls.Text += "of Circular No.22/2013 dated 24.05.2013.";
                        tdRow_CanDtls.Text += "</p>";
                        tdRow_CanDtls.Text += "</div>";

                        tdRow_CanDtls.Text += "<div style='width:1024px; float:left; font-size: 18px;margin: 20px 0px 20px 0px; height:730px;'>";
                        tdRow_CanDtls.Text += "	<div style=' width: 200px; float: right; margin: 20px 0px 0px 0px;'>";

                        tdRow_CanDtls.Text += "<div style='width: 120px; float:left; font-size: 18px;padding: 12px;'>Yours faithfully</div>";
                        tdRow_CanDtls.Text += "<div style='width: 160px; float:left; font-size: 18px;padding: 32px 0px 0px 0px;'>Seal and sign of CFS</div>";
                        tdRow_CanDtls.Text += "</div>";
                        tdRow_CanDtls.Text += "</div>";

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

       