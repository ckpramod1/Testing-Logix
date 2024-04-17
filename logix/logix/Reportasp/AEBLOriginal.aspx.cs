using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class AEBLOriginal : System.Web.UI.Page
    {
        string hawblno;
        int bid, draft;
        string np1, np2;
        DataAccess.Accounts.OSDNCN objosdncn = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dtcust = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objosdncn.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/','_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("hawblno"))
                {
                    hawblno = Request.QueryString["hawblno"];
                    np1 = Request.QueryString["np1"];
                    np2 = Request.QueryString["np2"];
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    draft = Convert.ToInt32(Request.QueryString["draft"]);
                    stationery.Text = Request.QueryString["format"];
                    if(stationery.Text =="0")
                    {
                        stationery.Text = "";
                    }
                }
                if (draft == 0)
                {
                    lbl_draft.Visible = false;
                }
                if (np1 == "No")
                {
                    hd_n1.Visible = false;
                }
                if (np2 == "No")
                {
                    hid_n2.Visible = false;
                }
                //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                }

                dtcust = objosdncn.SPGetAEBLdetails(hawblno.ToString(), bid);
                if (dtcust.Rows.Count > 0)
                {
                    hawblno1.Text = dtcust.Rows[0]["hawblno"].ToString();
                    hawblno2.Text = dtcust.Rows[0]["hawblno"].ToString();
                    hawblno3.Text = dtcust.Rows[0]["hawblno"].ToString();
                    hawblno4.Text = dtcust.Rows[0]["hawblno"].ToString();
                    sname.Text = dtcust.Rows[0]["sname"].ToString();
                    saddress.Text = dtcust.Rows[0]["saddress"].ToString();
                    cname.Text = dtcust.Rows[0]["cname"].ToString();
                    caddress.Text = dtcust.Rows[0]["caddress"].ToString();
                    n1name.Text = dtcust.Rows[0]["n1name"].ToString();
                    n1address.Text = dtcust.Rows[0]["n1address"].ToString();
                    lbl_n2name.Text = dtcust.Rows[0]["n2name"].ToString();
                    lbl_n2add.Text = dtcust.Rows[0]["n2address"].ToString();
                    branchname.Text = dtcust.Rows[0]["branchname"].ToString();
                    address.Text = dtcust.Rows[0]["address"].ToString();
                    //freight.Text = dtcust.Rows[0]["freight"].ToString();
                    int charge, min, rate, dvl, wc, ocda, ocdc;
                    charge = Convert.ToInt32(dtcust.Rows[0]["chargewt"]);
                    if (dtcust.Rows[0]["minwt"] == null)
                    {
                        min = Convert.ToInt32(dtcust.Rows[0]["minwt"]);

                    }
                    else
                    {
                        min = 0;
                    }
                    rate = Convert.ToInt32(dtcust.Rows[0]["rateclass"]);
                    dvl = Convert.ToInt32(dtcust.Rows[0]["dvl"]);
                    if (dtcust.Rows[0]["freight"].ToString() == "C")
                    {
                        freight.Text = "FREIGHT COLLECT";
                        if (dtcust.Rows[0]["agreedorrate"].ToString() == "R")
                        {
                            if (charge <= min)
                            {
                                ratec.Text = rate.ToString();
                            }
                            else
                            {
                                ratec.Text = (charge * rate).ToString();
                            }
                            if (ratec.Text != "")
                            {
                                rate = Convert.ToInt32(ratec.Text);
                            }
                            else
                            {
                                rate = 0;
                            }

                        }
                        else
                        {
                            ratec.Text = "AS AGREED";
                        }

                        if (Request.QueryString["wcc"] == "0")
                        {
                            wcc.Text = "";
                        }
                        else
                        {
                            wcc.Text = Request.QueryString["wcc"];

                        }
                        if (Request.QueryString["tocdac"] == "0")
                        {
                            ocdac.Text = "";
                        }
                        else
                        {
                            ocdac.Text = Request.QueryString["tocdac"];

                        }
                        if (Request.QueryString["tocdcc"] == "0")
                        {
                            ocdcc.Text = "";
                        }
                        else
                        {
                            ocdcc.Text = Request.QueryString["tocdcc"];

                        }

                        if (wcc.Text != "")
                        {
                            wc = Convert.ToInt32(wcc.Text);

                        }
                        else
                        {
                            wc = 0;
                        }
                        if (ocdac.Text != "")
                        {
                            ocda = Convert.ToInt32(ocdac.Text);

                        }
                        else
                        {
                            ocda = 0;
                        }
                        if (ocdcc.Text != "")
                        {
                            ocdc = Convert.ToInt32(ocdcc.Text);

                        }
                        else
                        {
                            ocdc = 0;
                        }
                        if (dtcust.Rows[0]["agreedorrate"].ToString() == "R")
                        {
                            totalc.Text = (rate + dvl + wc + ocda + ocdc).ToString();

                        }
                        else
                        {
                            totalc.Text = "AS AGREED";
                        }
                    }
                    else
                    {
                        freight.Text = "FREIGHT PERPAID";
                        if (dtcust.Rows[0]["agreedorrate"].ToString() == "R")
                        {
                            if (charge <= min)
                            {
                                ratep.Text = rate.ToString();
                            }
                            else
                            {
                                ratep.Text = (charge * rate).ToString();
                            }
                            if (ratep.Text != "")
                            {
                                rate = Convert.ToInt32(ratep.Text);
                            }
                            else
                            {
                                rate = 0;
                            }

                        }
                        else
                        {
                            ratep.Text = "AS AGREED";
                        }
                        if (Request.QueryString["wcp"] == "0")
                        {
                            wcp.Text = "";
                        }
                        else
                        {
                            wcp.Text = Request.QueryString["wcp"];

                        }
                        if (Request.QueryString["tocdap"] == "0")
                        {
                            ocdap.Text = "";
                        }
                        else
                        {
                            ocdap.Text = Request.QueryString["tocdap"];

                        }
                        if (Request.QueryString["tocdcp"] == "0")
                        {
                            ocdcp.Text = "";
                        }
                        else
                        {
                            ocdcp.Text = Request.QueryString["tocdcp"];

                        }

                        if (wcp.Text != "")
                        {
                            wc = Convert.ToInt32(wcp.Text);
                        }
                        else
                        {
                            wc = 0;
                        }
                        if (ocdap.Text != "")
                        {
                            ocda = Convert.ToInt32(ocdap.Text);
                        }
                        else
                        {
                            ocda = 0;
                        }
                        if (ocdcp.Text != "")
                        {
                            ocdc = Convert.ToInt32(ocdcp.Text);
                        }
                        else
                        {
                            ocdc = 0;
                        }
                        if (dtcust.Rows[0]["agreedorrate"].ToString() == "R")
                        {
                            totalp.Text = (rate + dvl + wc + ocda + ocdc).ToString();

                        }
                        else
                        {
                            totalp.Text = "AS AGREED";
                        }
                    }
                    mawblno.Text = dtcust.Rows[0]["mawblno"].ToString();
                    poldetails.Text = dtcust.Rows[0]["poldetails"].ToString();
                    airportcode1.Text = dtcust.Rows[0]["airportcode1"].ToString();
                    customername.Text = dtcust.Rows[0]["shortcode1"].ToString();
                    airportcode2.Text = dtcust.Rows[0]["airportcode2"].ToString();
                    airportcode3.Text = dtcust.Rows[0]["airportcode3"].ToString();
                    if (airportcode1.Text == airportcode2.Text)
                    {
                        airportcode2.Text = "";
                    }
                    curr.Text = dtcust.Rows[0]["curr"].ToString();
                    chgcode.Text = dtcust.Rows[0]["chgcode"].ToString();
                    if (dtcust.Rows[0]["wtval"].ToString() == "C")
                    {
                        wtvalc.Text = dtcust.Rows[0]["wtval"].ToString();
                    }
                    else
                    {
                        wtvalp.Text = dtcust.Rows[0]["wtval"].ToString();
                    }
                    if (dtcust.Rows[0]["otherval"].ToString() == "C")
                    {
                        othervalc.Text = dtcust.Rows[0]["otherval"].ToString();
                    }
                    else
                    {
                        othervalp.Text = dtcust.Rows[0]["otherval"].ToString();
                    }
                    poddetails.Text = dtcust.Rows[0]["poddetails"].ToString();
                    flightdate.Text = Convert.ToDateTime(dtcust.Rows[0]["flightdate"]).ToString("dd/MM/yyyy");
                    insamt.Text = Convert.ToInt32(dtcust.Rows[0]["insamt"]).ToString();
                    otherchg.Text = dtcust.Rows[0]["otherchg"].ToString();
                    branchname1.Text = dtcust.Rows[0]["branchname"].ToString();
                    portname.Text = dtcust.Rows[0]["portname"].ToString();
                    issuedon.Text = Convert.ToDateTime(dtcust.Rows[0]["issuedon"]).ToString("dd/MM/yyyy");

                    pkgs.Text = dtcust.Rows[0]["noofpkgs"].ToString();
                    pkgs2.Text = dtcust.Rows[0]["noofpkgs"].ToString();
                    grosswt.Text = dtcust.Rows[0]["grosswt"].ToString();
                    wttype.Text = dtcust.Rows[0]["wttype"].ToString();
                    citemno.Text = dtcust.Rows[0]["citemno"].ToString();
                    chargewt.Text = dtcust.Rows[0]["chargewt"].ToString();
                    rateclass.Text = dtcust.Rows[0]["rateclass"].ToString();
                    rate = Convert.ToInt32(dtcust.Rows[0]["rateclass"]);
                    lbl_handinfo.Text = dtcust.Rows[0]["handling"].ToString();

                    if (charge <= min)
                    {
                        total.Text = rate.ToString();
                        total2.Text = rate.ToString();
                    }
                    else
                    {
                        total.Text = (charge * rate).ToString();
                        total2.Text = (charge * rate).ToString();
                    }
                    descn.Text = dtcust.Rows[0]["descn"].ToString();
                    //lbllength.Text = dtcust.Rows[0]["length"].ToString();
                    //lblbreadth.Text = dtcust.Rows[0]["breadth"].ToString();
                    //lblwidth.Text = dtcust.Rows[0]["width"].ToString();
                    //lblpieces.Text = dtcust.Rows[0]["pieces"].ToString();
                    lbl_short2.Text = dtcust.Rows[0]["shortcode2"].ToString();
                    lbl_short3.Text = dtcust.Rows[0]["shortcode3"].ToString();
                   if( customername.Text== lbl_short2.Text)
                    {
                        lbl_short2.Text = "";
                    }
                    if (dtcust.Rows[0]["agreedorrate"].ToString() == "A")
                    {
                        rateclass.Text = "AS AGREED";
                        total.Text = "AS AGREED";
                        total2.Text = "AS AGREED";

                    }
                    if (dtcust.Rows[0]["flightno"].ToString() != "")
                    {
                        lbl_flno.Text = dtcust.Rows[0]["flightno"].ToString().ToUpper()+" / ";

                    }
                    if (dtcust.Rows[0]["flightno2"].ToString()!="")
                    {
                        Label25.Text = dtcust.Rows[0]["flightno2"].ToString().ToUpper() + " / ";

                    }
                    if (dtcust.Rows[0]["flightdate2"].ToString() != "")
                    {
                        Label2.Text = dtcust.Rows[0]["flightdate2"].ToString();

                    }
                    lbl_nvd.Text = dtcust.Rows[0]["csdvl"].ToString();
                    lbl_nvc.Text = dtcust.Rows[0]["csdvc"].ToString();
                    if (lbl_nvd.Text!="0" && lbl_nvd.Text != "NVD")
                    {
                        lbl_nvd.Text = lbl_nvd.Text + " USD";
                    }
                    if (lbl_nvc.Text != "0" && lbl_nvc.Text != "NVC")
                    {
                        lbl_nvc.Text = lbl_nvc.Text + " USD";
                    }

                    for (int i = 0; dtcust.Rows.Count > i; i++)
                    {
                        lbllength.Text += dtcust.Rows[i]["length"].ToString() + " X "+ dtcust.Rows[i]["breadth"].ToString() + " X " + dtcust.Rows[i]["width"].ToString()+" X "+ dtcust.Rows[i]["pieces"].ToString() + "</br>";

                        //int k = 3;
                        //if (i == k)
                        //{
                        //    k += 4;
                        //    lbllength.Text += "</br>";
                        //}
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