using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class rptFIAnnx1 : System.Web.UI.Page
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
                    //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    dt = da_obj_rptasp.GetAnnex1(Convert.ToInt32(job), Bid, Cid);
                    if (dt.Rows.Count > 0)
                    {
                        lbl_date.Text = dt.Rows[i]["andate"].ToString();
                        lbl_branch.Text = dt.Rows[0]["branchname"].ToString();

                        lbl_address.Text = dt.Rows[0]["address"].ToString();
                        lbl_ph.Text = dt.Rows[0]["phone"].ToString();
                        lbl_fax.Text = dt.Rows[0]["fax"].ToString();
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            tdRow_CanDtls.Text += "<tbody>";
                            tdRow_CanDtls.Text += "<tr>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px 5px 5px 20px; margin:0px; vertical-align:top;'>" + dt.Rows[i]["line"].ToString() + "</td>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px 5px 5px 20px; margin:0px; vertical-align:top;'>" + dt.Rows[i]["sublineno"].ToString();
                            tdRow_CanDtls.Text += "</td>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;'>" + dt.Rows[i]["containerno"].ToString() + "</td>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;'>" + dt.Rows[i]["sealno"].ToString() + "</td>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;'>" + dt.Rows[i]["isocode"].ToString() + "</td>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;'>" + dt.Rows[i]["panno"].ToString() + "</td>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;'>" + dt.Rows[i]["jobtype"].ToString() + "</td>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;text-align: right;'>" + dt.Rows[i]["noofpkgs"].ToString() + "</td>";
                            tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000;  padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; '>" + dt.Rows[i]["grweight"].ToString() + "</td>";
                            //tdRow_CanDtls.Text += "<td  style='border-left:1px solid #000; border-bottom:1px solid #000; padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; '>" + dt.Rows[i]["grweight"].ToString() + "</td>";

                            tdRow_CanDtls.Text += "</tr>";
                            tdRow_CanDtls.Text += "</tbody>";
                        }

                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            tot1 = Convert.ToInt32(dt.Rows[i]["noofpkgs"]);
                            tot = tot + tot1;
                        }
                        string pkg = tot.ToString("#,0.00");
                        for (i = 0; i < dt.Rows.Count; i++)
                      
                        {
                            fctot1 = Convert.ToDouble(dt.Rows[i]["grweight"]);
                            fctot = fctot + fctot1;
                        }
                        string  grwt = fctot.ToString("#,0.00");
                        tdRow_CanDtls.Text += "<tr >";
                        tdRow_CanDtls.Text += " <td rowspan='0' style='border-top:1px solid #000;'></td>";
                        tdRow_CanDtls.Text += " <td rowspan='0' style='border-top:1px solid #000;'></td>";
                        tdRow_CanDtls.Text += " <td rowspan='0' style='border-top:1px solid #000;'></td>";
                        tdRow_CanDtls.Text += " <td rowspan='0' style='border-top:1px solid #000;'></td>";
                        tdRow_CanDtls.Text += " <td rowspan='0' style='border-top:1px solid #000;'></td>";
                        tdRow_CanDtls.Text += " <td rowspan='0' style='border-top:1px solid #000;'></td>";
                        tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; border-top:1px solid #000; padding:5px; margin:0px; vertical-align:top; font-weight: bold;'>Total</td>";
                        tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; border-top:1px solid #000; padding:5px; margin:0px; vertical-align:top;text-align: right;'>" + pkg + "</td>";
                        tdRow_CanDtls.Text += " <td  style='border-left:1px solid #000; border-bottom:1px solid #000; border-top:1px solid #000; padding:5px; margin:0px; vertical-align:top;border-right: 1px solid #000;text-align: right; '>" + grwt + "";
                        tdRow_CanDtls.Text += " </td>";
                        tdRow_CanDtls.Text += "</tr>";
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
        