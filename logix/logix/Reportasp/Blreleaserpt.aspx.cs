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
    public partial class Blreleaserpt : System.Web.UI.Page
    {
        int Bid, cid, countryid, Descnlength;
        string issuedat = "", agentrefno = "", bltype = "";
        string date = "", number = "", Agent = "", stype = "";
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataAccess.Masters.MasterCustomer da_obj_cust = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort da_obj_port = new DataAccess.Masters.MasterPort();
        DataTable dtcust = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_rptasp.GetDataBase(Ccode);
                da_obj_cust.GetDataBase(Ccode);
                da_obj_port.GetDataBase(Ccode);
               

            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            //31012022namb  iii677

            if (Request.QueryString.ToString().Contains("blno"))
            {
                lbl_blno.Text = Request.QueryString["blno"].ToString();
                bltype = Request.QueryString["type"].ToString();
                Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                cid = Convert.ToInt32(Request.QueryString["cid"]);
              //  lbl_MTD.Text = Request.QueryString["Doc"].ToString();
                Agent = Request.QueryString["Agent"].ToString();
                countryid = Convert.ToInt32(Request.QueryString["countryid"]);
                Descnlength = Convert.ToInt32(Request.QueryString["Descn"]);
                if (Request.QueryString.ToString().Contains("stype"))
                {
                    stype = Request.QueryString["stype"].ToString();
                }

                if (bltype == "N")
                {
                   lbl_blrreltype.Text ="COPY NON‎-‎NEGOTIABLE";

                }
                if (bltype == "D")
                {
                    lbl_blrreltype.Text = "Draft BL";

                }
                if (bltype == "O")
                {
                    lbl_blrreltype.Text = "Original BL";

                }

                //if (bltype == "N" || bltype == "D")
                //{
                //    lblmtd.Visible = false;
                //    lblshpmnt.Visible = false;
                //    divimg.Visible = false;
                //}
                //if (bltype == "O" && stype == "E")
                //{
                //  //  lblmtd.Visible = true;
                //  //  lblshpmnt.Visible = true;
                //  ////  divimg.Visible = true;
                //   // lbl_nonnegEXpress.Visible = true;
                //    lbl_stype.Visible = true;
                //    lbl_stype.Text = "EXPRESS RELEASE";
                //   // lbl_nonnegEXpress.Text = "COPY NON‎-‎NEGOTIABLE";
                //    //if (countryid == 233)
                //    //{
                //    //    lbl_img.ImageUrl = "../images/MR_logo_Details4_us.png";
                //    //}
                //    //else
                //    //{
                //    //    lbl_img.ImageUrl = "../images/MR_Logo_details.png";
                //    //}
                //}
                //else if (bltype == "O" && stype == "X") //nwly added on 10 may 22
                //{
                //    lblmtd.Visible = true;
                //    lblshpmnt.Visible = true;
                //    divimg.Visible = true;
                //    lbl_nonnegEXpress.Visible = true;
                //    lbl_stype.Visible = true;
                //    lbl_stype.Text = "TELEX RELEASE";
                //    lbl_nonnegEXpress.Text = "COPY NON‎-‎NEGOTIABLE";
                //    if (countryid == 233)
                //    {
                //        lbl_img.ImageUrl = "../images/MR_logo_Details4_us.png";
                //    }
                //    else
                //    {
                //        lbl_img.ImageUrl = "../images/MR_Logo_details.png";
                //    }



                //}
                //else
                //{
                //    lblmtd.Visible = false;
                //    lblshpmnt.Visible = false;
                //    divimg.Visible = false;
                //    lbl_nonnegEXpress.Visible = false;
                //    lbl_stype.Visible = false;
                //}

                //if (bltype == "O")
                //{
                //    lblmtd.Visible = false;
                //    lblshpmnt.Visible = false;
                //    divimg.Visible = false;
                //}
                //else
                //{
                //    lblmtd.Visible = true;
                //    lblshpmnt.Visible = true;
                //    divimg.Visible = true;
                //}

                DataTable dt = new DataTable();
                dt = da_obj_rptasp.GetBLDetails4Rpt(lbl_blno.Text, Bid, cid);
                if (dt.Rows.Count > 0)
                {
                    lblshprefno.Text = dt.Rows[0]["Shiprefno"].ToString();
                    lbl_conshipaddress.Text = dt.Rows[0]["saddress"].ToString();
                    lbl_conaddress.Text = dt.Rows[0]["caddress"].ToString();
                    // lbl_delicontact.Text = da_obj_rptasp.Getcustaddress(Convert.ToInt32(dt.Rows[0]["deliveryagent"]));
                    lbl_notifyaddress.Text = dt.Rows[0]["naddress"].ToString();
                    lbl_POAccept.Text = dt.Rows[0]["pordetails"].ToString();
                    lbl_POL.Text = dt.Rows[0]["poldetails"].ToString();
                    lbl_POD.Text = dt.Rows[0]["poddetails"].ToString();
                    lbl_PODel.Text = dt.Rows[0]["fddetails"].ToString();
                    lbl_container.Text = dt.Rows[0]["cntrdetails"].ToString();
                    hid_marks.Value = lbl_marks.Text = dt.Rows[0]["marks"].ToString();
                    lbl_pkg.Text = dt.Rows[0]["pkgdetails"].ToString();
                    lbl_grwt.Text = dt.Rows[0]["blgrwt"].ToString();
                    lbl_netwt.Text = dt.Rows[0]["blntwt"].ToString();
                    hid_desc.Value = lblDescription.Text = dt.Rows[0]["descn"].ToString();

                    lbl_vessel.Text = dt.Rows[0]["Vessel"].ToString();
                    lbl_voy.Text = dt.Rows[0]["voyage"].ToString();
                   // lbl_transhipplace.Text = dt.Rows[0]["Shipmenttype"].ToString();
                    // lbl_nooforigi.Text = dt.Rows[0]["oribls"].ToString();
                    //issuedat = da_obj_port.GetPortname(Convert.ToInt32(dt.Rows[0]["blissuedat"])).ToString();
                    //date = Convert.ToDateTime(dt.Rows[0]["IssueAt"]).ToString("dd/MM/yyyy");
                    lbl_place.Text = dt.Rows[0]["blplace"].ToString();
                    lbl_bldate.Text = dt.Rows[0]["IssueAt"].ToString();
                    lbl_freitype.Text = dt.Rows[0]["freightCollect"].ToString();
                   // lbl_type.Text = dt.Rows[0]["Shipmenttype"].ToString();
                    lbl_cbm.Text = dt.Rows[0]["blcbm"].ToString();
                    lbl_movetype.Text = dt.Rows[0]["movetype"].ToString();
                    string shipment = dt.Rows[0]["shipment"].ToString();
                    if (shipment == "1" || shipment == "2")
                    {
                        lblshiploadcount.Visible = true;
                    }
                    if (bltype != "D")
                    {
                        byte[] imageByte = null;
                        if (!string.IsNullOrEmpty(dt.Rows[0]["BMSign"].ToString()))
                        {
                            imageByte = ((byte[])dt.Rows[0]["BMSign"]);
                            string base64String = Convert.ToBase64String(imageByte);
                            //imgsign.ImageUrl = "data:image/png;base64," + base64String;
                            //if (base64String == "")
                            //{
                            //    imgsign.ImageUrl = "";
                            //}
                            //else
                            //{
                            //    imgsign.ImageUrl = "data:image/png;base64," + base64String;
                            //}
                        }
                    }

                    //lblFpayableAtDest.Text = dt.Rows[0]["FpayableAtDest"].ToString();
                    //lbl_freight.Text = dt.Rows[0]["freightamount"].ToString();
                    //lbl_freightpayat.Text = dt.Rows[0]["freightat"].ToString();

                    lblBranchname.Text = dt.Rows[0]["Branchname"].ToString();
                    lblSigntype.Text = dt.Rows[0]["signtype"].ToString();

                    agentrefno = dt.Rows[0]["agentrefno"].ToString();
                    if (agentrefno != "")
                    {
                       // lbl_agentrefno.Text = agentrefno;
                    }


                   // lbl_dtdelivery.Text = dt.Rows[0]["DateofAccept"].ToString();
                    //  lbl_transhipplace.Text = dt.Rows[0][""].ToString();
                   // lbl_dtAccept.Text = dt.Rows[0]["Periodofdelivery"].ToString();

                    if (Convert.ToInt32(dt.Rows[0]["oribls"]) == 0)
                    {
                        number = "ZERO";
                    }
                    if (Convert.ToInt32(dt.Rows[0]["oribls"]) > 0)
                    {
                        number = NumberToWords(Math.Abs(Convert.ToInt32(dt.Rows[0]["oribls"])));

                    }
                    lbl_nooforigi.Text = dt.Rows[0]["oribls"].ToString() + " " + "(" + number.ToUpper() + " " + "ONLY" + ")";
                    lbl_transmode.Text = dt.Rows[0]["Shipmenttype"].ToString(); //dt.Rows[0]["Vessel"].ToString() + " " + dt.Rows[0]["voyage"].ToString();

                    if (Agent == "Y")
                    {
                        dtcust = da_obj_cust.Get_customerdetails(Convert.ToInt32(dt.Rows[0]["deliveryagent"]));
                        if (dtcust.Rows.Count > 0)
                        {
                            lbl_delicontact.Text += dtcust.Rows[0]["customername"].ToString().ToUpper() + System.Environment.NewLine + "<br />";
                            if (!string.IsNullOrEmpty(dtcust.Rows[0]["address"].ToString()))
                            {
                                lbl_delicontact.Text += dtcust.Rows[0]["address"].ToString().Replace(",", "").ToUpper();
                            }
                            if (!string.IsNullOrEmpty(dtcust.Rows[0]["portname"].ToString()))
                            {
                                lbl_delicontact.Text += dtcust.Rows[0]["portname"].ToString().ToUpper();
                            }
                            if (!string.IsNullOrEmpty(dtcust.Rows[0]["zip"].ToString()))
                            {
                                lbl_delicontact.Text += " - " + dtcust.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                            }
                            else
                            {
                                lbl_delicontact.Text += "<br />";
                            }
                            if (!string.IsNullOrEmpty(dtcust.Rows[0]["phone"].ToString()))
                            {
                                lbl_delicontact.Text += "PH :" + dtcust.Rows[0]["phone"].ToString() + ";";
                            }
                            if (!string.IsNullOrEmpty(dtcust.Rows[0]["fax"].ToString()))
                            {
                                lbl_delicontact.Text += "Fax :" + dtcust.Rows[0]["fax"].ToString() + "<br />";
                            }
                            if (!string.IsNullOrEmpty(dtcust.Rows[0]["email"].ToString()))
                            {
                                lbl_delicontact.Text += "Email :" + dtcust.Rows[0]["email"].ToString() + "<br />";
                            }

                        }
                    }
                    else
                    {
                        lbl_delicontact.Text = "";
                    }

                    lbl_delicontact.Text = dt.Rows[0]["agentaddress"].ToString();

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
                    if (Descnlength > 600) //      added on  13 jan 2022      nambi    
                    {
                        lblDescription.Text = "";
                        lblAnnexDesc.Visible = true;
                    }

                    //  if (lblDescription.Text.Length > 600) //      hide on  07122021          
                    //{
                    //    lblDescription.Text = "";
                    //    lblAnnexDesc.Visible = true;
                    //}

                    // //newly added on desc bl dec72021
                    // //std
                    //int int_desclength = 0;
                    //hid_desc.Value= lblDescription.Text;
                    //int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;
                    // if(int_desclength>638)
                    // {
                    //     lblDescription.Text = "";
                    //     lblAnnexDesc.Visible = true;
                    // }
                    // //end

                    //string des = "";

                    //for (int i = 0; i < 3; i++)
                    //{
                    //    if ((lbl_container.Text.Trim().Length) >= 3)
                    //    {
                    //        des = (((lbl_container.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((lbl_container.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                    //        if (des == " ")
                    //        {
                    //            lbl_container.Text = (((lbl_container.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((lbl_container.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                    //        }
                    //    }
                    //}
                    //des = "";
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    if ((hid_marks.Value.Trim().Length) >= 3)
                    //    {
                    //        des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                    //        if (des == " ")
                    //        {
                    //            hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                    //        }
                    //    }
                    //}
                    //des = "";
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    if ((hid_desc.Value.Trim().Length) >= 3)
                    //    {
                    //        des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                    //        if (des == " ")
                    //        {
                    //            hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                    //        }
                    //    }
                    //}


                    //int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


                    //string container = lbl_container.Text.Trim().Replace(System.Environment.NewLine, "  ");
                    //hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");



                    //if ((((lbl_container.Text.TrimStart()).TrimEnd()).Trim()) != "")
                    //{
                    //    int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
                    //}
                    //if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    //{
                    //    int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
                    //}
                    //if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    //{
                    //    int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
                    //    // int_desclength = (((hid_desc.Value)).Trim()).Length;//hid_desc.Value.ToString().Length;
                    //}


                    //if (int_marklength > 250)
                    //{
                    //    lbl_marks.Text = "";
                    //    lblAnnexMarks.Visible = true;
                    //}
                    //if (int_containerlength > 290)
                    //{
                    //    lbl_container.Text = "";
                    //    lblAnnexcontainer.Visible = true;
                    //}
                    //if (int_desclength > 600)
                    //{
                    //    lblDescription.Text = "";
                    //    lblAnnexDesc.Visible = true;
                    //}
                }
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