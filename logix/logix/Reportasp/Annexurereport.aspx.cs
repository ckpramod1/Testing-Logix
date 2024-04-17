using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class Annexurereport : System.Web.UI.Page
    {
        int Bid, Cid, i, job;
        string Type = "", TOtype = "", contdtls = "", Blno = "";

        double tot, tot1, fctot1, fctot;
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
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
                masterObj.GetDataBase(Ccode);



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

                    dt = da_obj_rptasp.GetAnnexure(Convert.ToInt32(job), Bid, Cid);
                    if (dt.Rows.Count > 0)
                    {
                        //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                        DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                        if (dtlogo.Rows.Count > 0)
                        {
                            byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                            string base64String = Convert.ToBase64String(logoimageBytes);
                            lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                        }


                        tdRow_CanDtls.Text += "<body style='font-family:sans-serif, Geneva, sans-serif; font-size:14px; line-height:18px;'>";
                            tdRow_CanDtls.Text += "<div style='width:1024px; margin:0px auto;page-break-after: always;'>";

                            //tdRow_CanDtls.Text +="<div style='width:1024px; margin:0px; padding:0px; border-bottom:1px solid #000;'>";
                            //tdRow_CanDtls.Text +="<div style='float:left; width:100px; margin:5px 0px 5px 25px;'> <img src='../images/MR.png' width='150px' height='auto' /></div>";
                            //tdRow_CanDtls.Text +="<div style='width:877px; float:left;'>";
                            //tdRow_CanDtls.Text +="<h3 style='text-align:center; padding:10px 0px 10px 0px; margin:0px 0px 0px 0px; font-size:24px; font-weight:bold;'><asp:Label ID='lbl_branch' runat='server'></asp:Label></h3>";
                            //tdRow_CanDtls.Text +="<p style='font-weight:normal; padding:5px 0px 0px 0px; margin:0px 0px 0px 0px; text-align:center;'><asp:Label ID='lbl_address' runat='server'></asp:Label></p>";
                            //tdRow_CanDtls.Text +="<p  style='font-weight:normal; padding:0px 0px 5px 0px; margin:0px 0px 0px 0px; text-align:center;'><strong>Tel</strong> : <asp:Label ID='lbl_ph' runat='server'></asp:Label> - <strong>Fax</strong> :<asp:Label ID='lbl_fax' runat='server'></asp:Label></p> </div><div style='clear:both;'></div></div>";

                            lbl_branch.Text = dt.Rows[0]["branchname"].ToString();
                           
                            lbl_address.Text = dt.Rows[0]["address"].ToString();
                            lbl_ph.Text = dt.Rows[0]["phone"].ToString();
                            lbl_fax.Text = dt.Rows[0]["fax"].ToString();

                            tdRow_CanDtls.Text += "<div style='width:1024px; margin:0px; padding:0px;'>";
                            tdRow_CanDtls.Text += "<table width='1024' border='0' cellspacing='0' cellpadding='0' class='TableHeader'>";
                            tdRow_CanDtls.Text += "<thead>";
                            tdRow_CanDtls.Text += "<tr><th colspan='18'><div style='width:1024px; margin:0px; padding:10px 0px 5px 0px; border-bottom:1px solid #000;'>";
                            tdRow_CanDtls.Text += "<p style=' text-align:center; padding:0px; margin:0px;'>ANNEXURE II<br />";

                            tdRow_CanDtls.Text += "ADDITION OF NEW CARGO LINES<br />PART-II : CARGO DECLARATION</p>";
                            tdRow_CanDtls.Text += "</div></th></tr>";
                            tdRow_CanDtls.Text += "<tr>";
                            tdRow_CanDtls.Text += " <th colspan='18'><div style='width:574px; float:left;'>";
                            tdRow_CanDtls.Text += "<div style='width:260px; float:left;'>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:70px; padding:5px 5px 0px 5px; font-weight:bold; text-align:left;'>CARN NO</div>";
                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px 5px 5px 5px; font-weight:bold;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:144px; float:left; padding:5px 0px 5px 5px; text-align:left; text-align:left;'>" + dt.Rows[i]["carrno"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='width:300px; float:left;'>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:80px; padding:5px 5px 0px 5px; font-weight:bold; text-align:right;'>VESSEL</div>";
                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px 5px 5px 5px; font-weight:bold;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:190px; float:left; padding:5px 0px 5px 5px; text-align:left;'>" + dt.Rows[i]["vesvoy"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                            tdRow_CanDtls.Text += "<div style='width:600px;'>";

                            tdRow_CanDtls.Text += "<div style='float:left; width:110px; padding:5px 5px 0px 5px; font-weight:bold; text-align:left;'>IGM NO / DATE </div>";

                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px 5px 5px 5px; font-weight:bold;'>:</div>";

                            tdRow_CanDtls.Text += "<div style='width:170px; float:left; padding:5px 0px 5px 5px; text-align:left;'>" + dt.Rows[i]["igmno"].ToString() + " / " + dt.Rows[i]["imdate"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";

                          
                            tdRow_CanDtls.Text += "<div style='float:left; width:600px;'>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:222px; padding:5px 5px 5px 5px; margin:0px; font-weight:bold; text-align:left; '>SHIPPING LINE NAME & CODE</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:1px; padding:5px 5px 5px 0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:300px; padding:5px; margin:0px; font-weight:normal; text-align:left;'>" + dt.Rows[i]["customername"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='width:600px; float:left;'>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:70px; padding:5px 5px 0px 5px; font-weight:bold; text-align:left;'>LINE NO.</div>";
                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px 5px 5px 5px; font-weight:bold;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:162px; float:left; padding:5px 0px 5px 5px; text-align:left;'>" + dt.Rows[i]["linenumber"].ToString() + "</div>";

                            tdRow_CanDtls.Text += "<div style='float:left; width:120px; padding:5px 5px 0px 5px; font-weight:bold; text-align:right;'>IMO CODE</div>";
                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px 5px 5px 5px; font-weight:bold;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:144px; float:left; padding:5px 0px 5px 5px; text-align:left;'>" + dt.Rows[i]["imocode"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "</div>";

                            tdRow_CanDtls.Text += "</div>";
                            tdRow_CanDtls.Text += "<div style='float:left; width:450px;'>";
                            tdRow_CanDtls.Text += "<div style='width:200px; float:left; padding:5px; margin:0px; text-align:right; font-weight:bold;'>CONSOL AGENT NAME</div>";
                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:190px; float:left; padding:5px; margin:0px; text-align:left;'>" + dt.Rows[i]["cagent"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:200px; float:left; padding:5px; margin:0px; text-align:right; font-weight:bold;'>VESSEL CODE</div>";
                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:190px; float:left; padding:5px; margin:0px; font-weight:normal; text-align:left;'>" + dt.Rows[i]["cvslcode"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:222px; float:left; padding:5px; margin:0px; text-align:right; font-weight:bold;'>SHIPPING LINE NAME & CODE</div>";
                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:190px; float:left; padding:5px; margin:0px; font-weight:normal; text-align:left;'>" + dt.Rows[i]["clinecode"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "<div style='clear:both;'></div>";
                            tdRow_CanDtls.Text += "<div style='width:200px; float:left; padding:5px; margin:0px; text-align:right; font-weight:bold;'>MBL NO. & Date</div>";
                            tdRow_CanDtls.Text += "<div style='width:1px; float:left; padding:5px; margin:0px;'>:</div>";
                            tdRow_CanDtls.Text += "<div style='width:219px; float:left; padding:5px; margin:0px; font-weight:normal; text-align:left;'>" + dt.Rows[i]["mbl"].ToString() + "</div>";
                            tdRow_CanDtls.Text += "</div></th>";

                            tdRow_CanDtls.Text += "</tr>";
                            tdRow_CanDtls.Text += "<tr>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000;  padding:2px; margin:0px; width:35px; white-space:pre-line; word-break:break-word;'>Sub Line #</th>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:60px; white-space:pre-line; word-break:break-word;'>H B/L #</th>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:60px; white-space:pre-line; word-break:break-word;'>Date</th>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:68px; white-space:pre-line; word-break:break-word;'>Port of Loading</th>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:60px; white-space:pre-line; word-break:break-word;'>Port of Destination</th>";
                            tdRow_CanDtls.Text += "<th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:95px; white-space:pre-line; word-break:break-word;'>Importer Name & Address</th>";
                            tdRow_CanDtls.Text += " <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:95px; white-space:pre-line; word-break:break-word;'>Consignee Name & Address</th>";
                            tdRow_CanDtls.Text += " <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:70px; white-space:pre-line; word-break:break-word;'>Marks</th>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:70px; white-space:pre-line; word-break:break-word;'>Descn</th>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:45px; white-space:pre-line; word-break:break-word;'>Item Type</th>";
                            tdRow_CanDtls.Text += " <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:55px; white-space:pre-line; word-break:break-word;'>Cargo</th>";
                            tdRow_CanDtls.Text += "<th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:70px; white-space:pre-line; word-break:break-word;'>C F S CODE</th>";
                            tdRow_CanDtls.Text += " <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:50px; white-space:pre-line; word-break:break-word;'>Total Pkgs</th>";
                            tdRow_CanDtls.Text += " <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:50px; white-space:pre-line; word-break:break-word;'>Pkg Type</th>";
                            tdRow_CanDtls.Text += " <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:50px; white-space:pre-line; word-break:break-word;'>Gross Wt</th>";
                            tdRow_CanDtls.Text += " <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:45px; white-space:pre-line; word-break:break-word;'>Unit Wt</th>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; width:65px; white-space:pre-line; word-break:break-word;'>Gross Volume</th>";
                            tdRow_CanDtls.Text += "  <th style='border-top:1px solid #000; border-left:1px solid #000; border-bottom:1px solid #000; border-right:1px solid #000; padding:2px; margin:0px; width:65px; white-space:pre-line; word-break:break-word;'>Unit of Volume</th>";

                            tdRow_CanDtls.Text += "</tr>";
                           
                                tdRow_CanDtls.Text += " </thead>";
                                for (i = 0; i < dt.Rows.Count; i++)
                                {
                                    tdRow_CanDtls.Text += " <tbody>";
                                    tdRow_CanDtls.Text += " <tr>";
                                    tdRow_CanDtls.Text += "  <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:35px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["sublineno"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += "  <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:60px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["blno"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:60px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["hbl"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:60px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["pol"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:60px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["portcode"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:95px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["caddress"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:95px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["naddress"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:70px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["marks"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:70px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["descn"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:45px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["itemtype"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:45px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["cargommt"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:70px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["cfscode"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:50px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["noofpkgs"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:50px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["packagecode"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:45px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["grweight"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:50px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["unit"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:2px; margin:0px; text-align:right; vertical-align:top; width:50px; white-space:pre-line; word-break:break-word;'>" + dt.Rows[i]["cbm"].ToString() + "</td>";
                                    tdRow_CanDtls.Text += " <td style='border-left:1px solid #000; border-bottom:1px solid #000; border-right:1px solid #000; padding:2px; margin:0px; vertical-align:top; width:50px; white-space:pre-line; word-break:break-word;'>CBM</td>";
                                    tdRow_CanDtls.Text += "</tr>";

                                    tdRow_CanDtls.Text += "</tbody>";
                                }
                                tdRow_CanDtls.Text += "</table>";
                                tdRow_CanDtls.Text += "</div>";
                                tdRow_CanDtls.Text += "</div>";
                                tdRow_CanDtls.Text += "</body>";
                            
                    }
                }
            }
            catch (Exception ex)
            {

                string message = ex.Message.ToString().Replace("'", "");
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }


        }
    }
}