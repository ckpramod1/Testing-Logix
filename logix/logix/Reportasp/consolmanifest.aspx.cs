using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class consolmanifest : System.Web.UI.Page
    {
        string bid;
        string jobno;
        string hf_bl, hf_dbl, hf_nt, length, breadth, width;
        int noof;
        double grosswt, chargewt ;
        DataAccess.Accounts.OSDNCN objosdncn = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        //DataTable set.Tables[0] = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);
            //   string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                objosdncn.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);
               
            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://CHawk.copperhawk.tech'_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("jobno"))
                {
                    jobno = Request.QueryString["jobno"];
                    bid = Request.QueryString["bid"];
                    hf_bl = Request.QueryString["hf_bl"];
                    hf_dbl = Request.QueryString["hf_dbl"];
                    hf_nt = Request.QueryString["hf_nt"];
                }
                if (hf_bl == "0")
                {
                    thead.Text = "CONSOL MANIFEST";

                }
                else
                {
                    thead.Text = "BOOKING";
                    bl_visi.Visible = false;
                }

                if (hf_nt != "Y")
                {
                    lblnotifedname.Visible = false;
                    lblnotifiedaddress.Visible = false;
                }
                //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                }
                DataSet set = new DataSet();
                set = objosdncn.Getagentbooking(jobno.ToString(), Convert.ToInt32(bid));

                if (set.Tables[0].Rows.Count > 0)
                {
                    if (hf_dbl == "N")
                    {
                        lblpreparename.Text = set.Tables[0].Rows[0]["branchname"].ToString();
                        lblprepareaddress.Text = set.Tables[0].Rows[0]["masteraddress"].ToString();
                        lblconsignname.Text = set.Tables[0].Rows[0]["customername"].ToString();
                        lblconsignaddress.Text = set.Tables[0].Rows[0]["address"].ToString();
                        lbl_cunname.Text = set.Tables[0].Rows[0]["branchcountryname"].ToString();
                        lbl_counname.Text = set.Tables[0].Rows[0]["agentcountryname"].ToString();
                    }
                    else
                    {
                        lblpreparename.Text = set.Tables[0].Rows[0]["sname"].ToString();
                        lblprepareaddress.Text = set.Tables[0].Rows[0]["saddress"].ToString();
                        lblconsignname.Text = set.Tables[0].Rows[0]["cname"].ToString();
                        lblconsignaddress.Text = set.Tables[0].Rows[0]["caddress"].ToString();
                        lbl_cunname.Text = set.Tables[0].Rows[0]["shipcountryname"].ToString();
                        lbl_counname.Text = set.Tables[0].Rows[0]["consgcountryname"].ToString();
                    }
                    lblbrname.Text = set.Tables[0].Rows[0]["branchname"].ToString();
                    lbladdress.Text = set.Tables[0].Rows[0]["masteraddress"].ToString();
                    lblphone.Text = set.Tables[0].Rows[0]["masterphone"].ToString();
                    lblfax.Text = set.Tables[0].Rows[0]["masterfax"].ToString();
                    lblnotifedname.Text = set.Tables[0].Rows[0]["n1name"].ToString();
                    lblnotifiedaddress.Text = set.Tables[0].Rows[0]["n1address"].ToString();
                    lblblno.Text = set.Tables[0].Rows[0]["mawblno"].ToString();
                    lblbldate.Text = Convert.ToDateTime(set.Tables[0].Rows[0]["mawbldate"].ToString()).ToString("dd/MM/yyyy");
                    lblcarrier.Text = set.Tables[0].Rows[0]["carriercustomername"].ToString();
                    lblloading.Text = set.Tables[0].Rows[0]["polairportcode"].ToString();
                    lbldestination.Text = set.Tables[0].Rows[0]["podairportcode"].ToString();


                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        noof += Convert.ToInt32(set.Tables[0].Rows[i]["noofpkgs"].ToString());

                        grosswt += Convert.ToDouble(set.Tables[0].Rows[i]["grosswt"].ToString());

                        chargewt += Convert.ToDouble(set.Tables[0].Rows[i]["chargewt"].ToString());

                    }
                    lblpackage.Text = noof.ToString();
                    lblgross.Text = grosswt.ToString();
                    lblcharge.Text = chargewt.ToString();
                    lbldesc.Text = " " + set.Tables[0].Rows[0]["descn"].ToString();
                    lblconsol.Text = set.Tables[0].Rows[0]["jobno"].ToString();
                    lblflightno.Text = set.Tables[0].Rows[0]["flightno"].ToString().ToUpper();
                    lblflightdate.Text = Convert.ToDateTime(set.Tables[0].Rows[0]["flightdate"].ToString()).ToString("dd/MM/yyyy");



                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        int a = i + 1;
                        lbldetails.Text += " <tr style=''>";
                        lbldetails.Text += "<td><label>" + a + "</label></td>";
                        if (hf_dbl == "N")
                        {
                            lbldetails.Text += "<td><label>" + set.Tables[0].Rows[i]["hawblno"].ToString() + "</label></td>";
                        }
                        else
                        {
                            lbldetails.Text += "<td><label></label></td>";
                        }
                        lbldetails.Text += "<td><label>" + set.Tables[0].Rows[i]["noofpkgs"].ToString() + " " + set.Tables[0].Rows[i]["descn"].ToString() + "</label></td>";
                        lbldetails.Text += "<td><label>" + set.Tables[0].Rows[i]["grosswt"].ToString() + "</label></td>";
                        lbldetails.Text += "<td><label>" + set.Tables[0].Rows[i]["volwt"].ToString() + "  </label></td>";
                        lbldetails.Text += "<td><label>" + set.Tables[0].Rows[i]["cargotype"].ToString() + "</label></td>";
                        lbldetails.Text += "<td><label>" + set.Tables[0].Rows[i]["shippername"].ToString() + "<br>" + set.Tables[0].Rows[i]["shipcountryname"].ToString() + "</label></td>";
                        lbldetails.Text += "<td><label>" + set.Tables[0].Rows[i]["consigneename"].ToString() + "<br>" + set.Tables[0].Rows[i]["consgcountryname"].ToString() + "</label></td><td>";

                        //lbldetails.Text += "<td class='tdrow'><label>" + set.Tables[0].Rows[i]["Dimensions"].ToString() + "</td></tr>";
                        for (int j = 0; j < set.Tables[1].Rows.Count; j++)
                        {
                            length = set.Tables[1].Rows[j]["length"] != DBNull.Value ? set.Tables[1].Rows[j]["length"].ToString() : "0";
                            breadth = set.Tables[1].Rows[j]["breadth"] != DBNull.Value ? set.Tables[1].Rows[j]["breadth"].ToString() : "0";
                            width = set.Tables[1].Rows[j]["width"] != DBNull.Value ? set.Tables[1].Rows[j]["width"].ToString() : "0";
                            lbldetails.Text += "<label>" + length.ToString() + " X " + breadth.ToString() + " X " + width.ToString() + " X " + set.Tables[1].Rows[j]["pieces"].ToString() + "</br>" ;
                        }
                        lbldetails.Text += "</td></tr>";
                    }

                    //noof = 0;
                    //grosswt = 0;
                    chargewt = 0;
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        //noof += Convert.ToInt32(set.Tables[0].Rows[i]["noofpkgs"].ToString());

                        //grosswt += Convert.ToDouble(set.Tables[0].Rows[i]["grosswt"].ToString());

                        chargewt += Convert.ToDouble(set.Tables[0].Rows[i]["chargewt"].ToString());

                    }
                    //lblnoofpkg.Text = noof.ToString();
                    //lbltotalgr.Text = grosswt.ToString();
                    //lbltotalvol.Text = chargewt.ToString();
                    //lbldesc2.Text = set.Tables[0].Rows[0]["descn"].ToString();
                    lbltotalcharge.Text = chargewt.ToString();


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