using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class CustomEDIrpt : System.Web.UI.Page
    {
        int bid;
        int jobno;
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
                if (Request.QueryString.ToString().Contains("jobno"))
                {
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    jobno = Convert.ToInt32(Request.QueryString["jobno"]);
                }
                dtcust = Selcustomedi.Selcustomedirpt(Convert.ToInt32(jobno), Convert.ToInt32(bid));

                if (dtcust.Rows.Count > 0)
                {
                    lbl_ourmbl.Text = dtcust.Rows[0]["mblno"].ToString();
                    lbl_mbldate.Text = Convert.ToDateTime(dtcust.Rows[0]["mbldate"]).ToString("dd/MM/yyyy");
                    lbl_ourjob.Text = dtcust.Rows[0]["jobno"].ToString();

                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {

                        //Label lbl_ourhbl = new Label();
                        //lbl_ourhbl.Text = "HBL # : " + dtcust.Rows[i]["blno"].ToString() +" | "+ Convert.ToDateTime(dtcust.Rows[i]["bldate"]).ToString("dd/MM/yyyy");
                        //edidetails.Controls.Add(lbl_ourhbl);

                        //Label consigneeLabel = new Label();
                        //consigneeLabel.Text = "Consignee : " + dtcust.Rows[i]["caddress"].ToString();
                        //edidetails.Controls.Add(consigneeLabel);

                        //Label grossWeightLabel = new Label();
                        //grossWeightLabel.Text = "GrossWt : " + dtcust.Rows[i]["grweight"].ToString();
                        //edidetails.Controls.Add(grossWeightLabel);

                        //HtmlGenericControl label = new HtmlGenericControl("label");
                        //label.InnerText = dtcust.Rows[i]["blno"].ToString() + " | " + Convert.ToDateTime(dtcust.Rows[i]["bldate"]).ToString("dd/MM/yyyy");
                        //lbl_ourhbl.Controls.Add(label);


                        //HtmlGenericControl div = new HtmlGenericControl("div");
                        //lbl_ourhbl.Text = "HBL # : " + dtcust.Rows[i]["blno"].ToString() + " | " + Convert.ToDateTime(dtcust.Rows[i]["bldate"]).ToString("dd/MM/yyyy");
                        //lbl_ourhbl.Controls.Add(div);

                        tr_hblDtls.Text += "<table style='float:left;width:40%;'>";
                        tr_hblDtls.Text += "<tr>";
                        tr_hblDtls.Text += "<td style='width:5%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "HBL # :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:32%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["blno"].ToString() + " | " + Convert.ToDateTime(dtcust.Rows[i]["bldate"]).ToString("dd/MM/yyyy") + "</td>";
                        tr_hblDtls.Text += "<td style='width:4%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "PoL :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:37%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["portname"].ToString() + "</td>";
                        tr_hblDtls.Text += "<td style='width:3%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "FD :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:8%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["FDportname"].ToString() + "</td>";
                        tr_hblDtls.Text += "</tr>";
                        tr_hblDtls.Text += "<tr>";
                        tr_hblDtls.Text += "<td style='width:9%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "Consignee :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:90%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["caddress"].ToString() + "</td>";
                        tr_hblDtls.Text += "<td style='width:12%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "Movement Type :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:25%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["itemtype"].ToString() + "</td>";
                        tr_hblDtls.Text += "<td style='width:8%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "Packages :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:33%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["noofpkgs"].ToString() +" "+ dtcust.Rows[i]["descn"].ToString() + "</td>";
                        tr_hblDtls.Text += "<td style='width:7%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "GrossWt :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:12%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["grweight"].ToString() + "</td>";
                        tr_hblDtls.Text += "</tr>";
                        tr_hblDtls.Text += "<tr>";
                       
                        tr_hblDtls.Text += "<td style='width:6%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "Marks :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:31%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["marks"].ToString() + "</td>";
                        tr_hblDtls.Text += "<td style='width:9%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "Description :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:52%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["bldescn"].ToString() + "</td>";

                        tr_hblDtls.Text += "</tr>";
                        tr_hblDtls.Text += "</table>";
                        tr_hblDtls.Text += "<table style='float:left;width:30%;    border-top: 1px solid black;  border-bottom: 1px solid black;'>";
                        tr_hblDtls.Text += "<tr>";
                        tr_hblDtls.Text += "<td style='width:9%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "Container # :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:28%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["containerno"].ToString() + "</td>";
                        tr_hblDtls.Text += "<td style='width:5%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "Seal # :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:36%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["sealno"].ToString() + "</td>";
                        tr_hblDtls.Text += "<td style='width:7.5%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif; '>" + "ISOCode :" + "</td>";
                        tr_hblDtls.Text += "<td style='width:12%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif; '>" + dtcust.Rows[i]["isocode"].ToString() + "</td>";
                        tr_hblDtls.Text += "</tr>";
                        tr_hblDtls.Text += "</table>";


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