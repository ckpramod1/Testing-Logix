using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class MBLDraftRpt : System.Web.UI.Page
    {

        int Bid, cid, descn,jobno;
        string issuedat = "", agentrefno = "", bltype = "";
        string date = "", number = "", Agent = "" , location= "";
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();

        protected void Page_Load(object sender, EventArgs e)
        {

            DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {


                da_obj_rptasp.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);

            }


            if (Request.QueryString.ToString().Contains("jobno"))
            {
                //lbl_blno.Text = Request.QueryString["blno"].ToString();
                jobno = Convert.ToInt32(Request.QueryString["jobno"]);
                bltype = Request.QueryString["type"].ToString();
                Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                //cid = Convert.ToInt32(Request.QueryString["cid"]);
                // lbl_MTD.Text = Request.QueryString["Doc"].ToString();
                Agent = Request.QueryString["agent"].ToString();
                location = Request.QueryString["location"].ToString();
                if (Request.QueryString.ToString().Contains("descn"))
                {
                    descn = Convert.ToInt32(Request.QueryString["descn"]);
                }
                DataTable dtdiv = masterObj.Getdivnamerblrelease(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtdiv.Rows.Count > 0)
                {
                    lbl_div.Text = dtdiv.Rows[0]["divisionname"].ToString();
                    byte[] logoimageBytes = ((byte[])dtdiv.Rows[0]["BLimage"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                }
                DataTable dt = new DataTable();
                dt = da_obj_rptasp.GetMBLDetails4Rpt(jobno, Bid);
                if (dt.Rows.Count > 0)
                {
                    lbl_conshipaddress.Text = dt.Rows[0]["shipperaddress"].ToString();
                    lbl_jobno.Text = dt.Rows[0]["jobno"].ToString();
                    lbl_etd.Text =Convert.ToDateTime(dt.Rows[0]["etd"]).ToString("dd/MM//yyyy");
                    lbl_blno.Text = dt.Rows[0]["mblno"].ToString();
                    lbl_conaddress.Text = dt.Rows[0]["consigneeaddress"].ToString();
                    lbl_notifyaddress.Text = dt.Rows[0]["notifyaddress"].ToString();
                    lbl_POR.Text = dt.Rows[0]["poa"].ToString();
                    lbl_POL.Text = dt.Rows[0]["pol"].ToString();
                    lbl_POD.Text = dt.Rows[0]["pod"].ToString();
                    lbl_PODel.Text = dt.Rows[0]["fd"].ToString();
                    lbl_container.Text = dt.Rows[0]["cntrdetails"].ToString();
                    lbl_marks.Text = dt.Rows[0]["marks"].ToString();
                    lbl_pkg.Text = dt.Rows[0]["pkgdetails"].ToString();
                    lbl_grwt.Text = dt.Rows[0]["grweight"].ToString();
                    lbl_netwt.Text = dt.Rows[0]["ntweight"].ToString();
                    //if (dt.Rows[0]["shippedonboard"].ToString() != "")
                    //{
                    //    DateTime sobdt = Convert.ToDateTime(dt.Rows[0]["shippedonboard"].ToString());
                        //lbl_sonboard.Text = sobdt.ToString("dd-MMM-yyyy");
                    //}
                    //  lbl_sonboard.Text = dt.Rows[0]["shippedonboard"].ToString();
                    if (lbl_netwt.Text == "")
                    {
                        Labelnet.Visible = false;
                    }
                    if (lbl_grwt.Text == "")
                    {
                        Labelgrss.Visible = false;
                    }
                    lblDescription.Text = dt.Rows[0]["descn"].ToString();
                    //lbl_placedtofisue.Text = dt.Rows[0]["IssueAt"].ToString();
                    lbl_nooforigi.Text = dt.Rows[0]["originalbl"].ToString();
                    lbl_type.Text = dt.Rows[0]["freightCollect"].ToString();
                    lbl_mtype.Text = dt.Rows[0]["shipment"].ToString();
                    lbl_portname.Text = dt.Rows[0]["IssuedAtPortname"].ToString();
                    if(dt.Rows[0]["freightCollect"].ToString() == "FREIGHT PREPAID")
                    {
                        lbl_preorcol.Text = "PREPAID";
                    }
                    else
                    {
                        lbl_colorper.Text = "COLLECT";
                    }

                    // hide for msn

                    //lbl_freitype.Text = dt.Rows[0]["freightCollect"].ToString();
                    //lbl_surr.Text = dt.Rows[0]["surrendered"].ToString();
                    //lbl_type.Text = dt.Rows[0]["Shipmenttype"].ToString();
                    //lbl_shiprefno.Text = dt.Rows[0]["shiprefno"].ToString();

                    //lbl_transmode.Text = dt.Rows[0]["Vessel"].ToString() + " " + dt.Rows[0]["voyage"].ToString();
                    //lbl_branch.Text = dt.Rows[0]["branchname"].ToString();
                    ////end

                    //string surrtype = dt.Rows[0]["surrendered"].ToString();
                    //lbl_freight.Text = dt.Rows[0]["freightamount"].ToString();
                    lbl_freightpayat.Text = dt.Rows[0]["DraftFreight"].ToString();
                    //lbl_precarriage.Text = dt.Rows[0][""].ToString();

                    lbl_contpkg.Text = dt.Rows[0]["noofContpkgs"].ToString();
                    lbl_cbm.Text = dt.Rows[0]["cbm"].ToString();
                    // lbl_sign.Text = dt.Rows[0]["signtype"].ToString();
                    //lbl_desfreight.Text = dt.Rows[0]["FpayableAtDest"].ToString();
                    if (Convert.ToInt32(dt.Rows[0]["oribls"]) == 0)
                    {
                        number = "ZERO";
                    }
                    if (Convert.ToInt32(dt.Rows[0]["oribls"]) > 0)
                    {
                        number = NumberToWords(Math.Abs(Convert.ToInt32(dt.Rows[0]["oribls"])));
                    }

                    lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString();
                    lbl_voy.Text = dt.Rows[0]["voyage"].ToString();

                    if (Agent == "Y")
                    {

                        if (!string.IsNullOrEmpty(dt.Rows[0]["agentaddress"].ToString()))
                        {
                            lbl_delicontact.Text += dt.Rows[0]["agentaddress"].ToString().Replace(",", "").ToUpper();
                        }

                        //changed as per nambi sir instruction
                        else
                        {
                            lbl_delicontact.Text += dt.Rows[0]["customername"].ToString().ToUpper() + System.Environment.NewLine + "<br />";
                            if (!string.IsNullOrEmpty(dt.Rows[0]["address"].ToString()))
                            {
                                lbl_delicontact.Text += dt.Rows[0]["address"].ToString().Replace(",", "").ToUpper();
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["custportname"].ToString()))
                            {
                                lbl_delicontact.Text += dt.Rows[0]["custportname"].ToString().ToUpper();
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["zip"].ToString()))
                            {
                                lbl_delicontact.Text += " - " + dt.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                            }
                            else
                            {
                                lbl_delicontact.Text += "<br />";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                            {
                                lbl_delicontact.Text += "PH :" + dt.Rows[0]["phone"].ToString() + ";";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["fax"].ToString()))
                            {
                                lbl_delicontact.Text += "Fax :" + dt.Rows[0]["fax"].ToString() + "<br />";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["email"].ToString()))
                            {
                                lbl_delicontact.Text += "Email :" + dt.Rows[0]["email"].ToString() + "<br />";
                            }
                        }
                    }
                    else
                    {
                        lbl_delicontact.Text += "";

                    }

                    //DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    //if (dtlogo.Rows.Count > 0)
                    //{
                    //    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    //    string base64String = Convert.ToBase64String(logoimageBytes);
                    //    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    //}
                    //byte[] logoimageBytes1 = ((byte[])dt.Rows[0]["bsign"]);
                    //string base64String1 = Convert.ToBase64String(logoimageBytes1);
                    //img_signature.ImageUrl = "data:image/png;base64," + base64String1;

                    //byte[] imageByte = null;
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["BMSign"].ToString()))
                    //{
                    //    imageByte = ((byte[])dt.Rows[0]["BMSign"]);
                    //    string base64String = Convert.ToBase64String(imageByte);
                        //lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                        //if (base64String == "")
                        //{
                        //    lbl_img.ImageUrl = "";
                        //}
                        //else
                        //{
                        //    lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                        //}
                    //}

                    if (lbl_marks.Text.Length > 250)
                    {
                        lbl_marks.Text = "";
                        lblAnnexMarks.Visible = true;
                    }
                    if (lbl_container.Text.Length > 290)
                    {
                        lbl_container.Text = "";
                        lblAnnexcontainer.Visible = true;
                    }
                    //if (lblDescription.Text.Length > 600)
                    //{
                    //    lblDescription.Text = "";
                    //    lblAnnexDesc.Visible = true;
                    //}

                    //if (Request.QueryString["annex"].ToString() == "Y")
                    //{
                    //    //  lblDescription.Text = "";
                    //    lblAnnexDesc.Visible = true;
                    //}

                    if (bltype == "N")
                    {
                        comlogo.Visible = true;
                        img_Logo.Visible = true;
                        img_signature.Visible = true;
                        lbl_bltype.Visible = true;
                        lbl_bltype.Text = "COPY NON‎-‎NEGOTIABLE";

                    }
                    if (bltype == "D")
                    {
                        comlogo.Visible = true;
                        img_Logo.Visible = true;
                        img_signature.Visible = false;

                        lbl_bltype.Visible = true;
                        //lbl_bltype.Text = "Draft BL";

                    }

                    if (bltype == "O" || bltype == "OS")
                    {
                        //if (surrtype == "RELEASE")
                        //{
                        //    lbl_bltype.Text = "Original BL";

                        //}
                        //else if (surrtype == "SEAWAYBILL")
                        //{
                        //    lbl_bltype.Text = "SeaWayBill BL";
                        //}
                        //else if (surrtype == "SURRENDERED")
                        //{
                        //    lbl_bltype.Text = "Surrendered BL";
                        //}
                        //else
                        //{
                        //    lbl_bltype.Text = "Original BL";
                        //}
                        //lbl_bltype.Visible = true;
                        //img_Logo.Visible = false;
                        //img_signature.Visible = true;
                    }
                    if (bltype == "OS")
                    {
                        comlogo.Visible = true;
                        img_Logo.Visible = true;
                        img_signature.Visible = true;
                    }
                }
            }
            if (Request.QueryString.ToString().Contains("original"))
            {
                string script = @"<script>
                        var elements = document.getElementsByClassName('blhide');
                        for (var i = 0; i < elements.length; i++) {
                            elements[i].style.visibility = 'hidden'; 
                        }
                     </script>";

                litScript.Text = script;

                string script2 = @"<script>
                        var elements = document.getElementsByClassName('bltableheadhide');
                        for (var i = 0; i < elements.length; i++) {
                            elements[i].style.visibility = 'hidden'; 
                        }
                     </script>";

                litScript2.Text = script2;

                string script3 = @"<script>
                        var elements = document.getElementsByClassName('borderhide');
                        for (var i = 0; i < elements.length; i++) { 
                            elements[i].style.border = 'none'; 
                        }
                     </script>";

                litScript3.Text = script3;

                lbl_bltype.Visible = false;
            }

        }

        private string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }


            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }


            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}