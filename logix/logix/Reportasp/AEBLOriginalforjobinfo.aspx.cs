using DataAccess.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class AEBLOriginalforjobinfo : System.Web.UI.Page
    {
        int bid, draft, jobno;
        string np1, np2;
        DataAccess.Reportasp objosdncn = new DataAccess.Reportasp();
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
                if (Request.QueryString.ToString().Contains("jobno"))
                {
                    np1 = Request.QueryString["np1"];
                    np2 = Request.QueryString["np2"];
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    jobno = Convert.ToInt32(Request.QueryString["jobno"]);
                    draft = Convert.ToInt32(Request.QueryString["draft"]);

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

                dtcust = objosdncn.SelAEJobdetails(jobno, bid);
                if (dtcust.Rows.Count > 0)
                {
                    hawblno1.Text = dtcust.Rows[0]["hawblno"].ToString();
                    hawblno2.Text = dtcust.Rows[0]["hawblno"].ToString();
                    hawblno3.Text = dtcust.Rows[0]["hawblno"].ToString();
                    hawblno4.Text = dtcust.Rows[0]["hawblno"].ToString();
                    sname.Text = dtcust.Rows[0]["branchname"].ToString();
                    saddress.Text = dtcust.Rows[0]["address"].ToString();
                    cname.Text = dtcust.Rows[0]["cname"].ToString();
                    caddress.Text = dtcust.Rows[0]["caddress"].ToString();
                    n1name.Text = dtcust.Rows[0]["n1name"].ToString();
                    n1address.Text = dtcust.Rows[0]["n1address"].ToString();
                    lbl_n2name.Text = dtcust.Rows[0]["n2name"].ToString();
                    lbl_n2add.Text = dtcust.Rows[0]["n2address"].ToString();
                    branchname.Text = dtcust.Rows[0]["branchname"].ToString();
                    address.Text = dtcust.Rows[0]["address"].ToString();
                    //freight.Text = dtcust.Rows[0]["freight"].ToString();
                    if (dtcust.Rows[0]["freight"].ToString() == "C")
                    {
                        freight.Text = "FREIGHT COLLECT";
                    }
                    else
                    {
                        freight.Text = "FREIGHT PERPAID";
                    }
                    mawblno.Text = dtcust.Rows[0]["mawblno"].ToString();
                    poldetails.Text = dtcust.Rows[0]["poldetails"].ToString();
                    airportcode1.Text = dtcust.Rows[0]["airportcode1"].ToString();
                    customername.Text = dtcust.Rows[0]["shortcode1"].ToString();
                    airportcode2.Text = dtcust.Rows[0]["airportcode2"].ToString();
                    airportcode3.Text = dtcust.Rows[0]["airportcode3"].ToString();
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
                    lbl_DVCar.Text = dtcust.Rows[0]["dvl"].ToString();
                    lbl_DVcus.Text = dtcust.Rows[0]["dvc"].ToString();
                    if (lbl_DVCar.Text != "0" && lbl_DVcus.Text != "NVD")
                    {
                        lbl_DVCar.Text = lbl_DVCar.Text + " USD";
                    }
                    if (lbl_DVcus.Text != "0" && lbl_DVcus.Text != "NVC")
                    {
                        lbl_DVcus.Text = lbl_DVcus.Text + " USD";
                    }

                    poddetails.Text = dtcust.Rows[0]["poddetails"].ToString();
                    flightdate.Text = Convert.ToDateTime(dtcust.Rows[0]["flightdate"]).ToString("dd/MM/yyyy");
                    insamt.Text = Convert.ToInt32(dtcust.Rows[0]["insamt"]).ToString();
                    otherchg.Text = dtcust.Rows[0]["otherchg"].ToString();
                    branchname1.Text = dtcust.Rows[0]["branchname"].ToString();
                    portname.Text = dtcust.Rows[0]["portname"].ToString();
                    issuedon.Text = Convert.ToDateTime(dtcust.Rows[0]["issuedon"]).ToString("dd/MM/yyyy");
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
                    if (dtcust.Rows[0]["agreedorrate"].ToString() == "A")
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

                        wcc.Text = Request.QueryString["wcc"];
                        ocdac.Text = Request.QueryString["ocdac"];
                        ocdcc.Text = Request.QueryString["ocdcc"];
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
                        totalc.Text = (rate + dvl + wc + ocda + ocdc).ToString();

                    }
                    else
                    {
                        if (charge <= min)
                        {
                            ratep.Text = rate.ToString();
                        }
                        else
                        {
                            ratep.Text = (charge * rate).ToString();
                        }
                        wcp.Text = Request.QueryString["wcp"];
                        ocdap.Text = Request.QueryString["ocdap"];
                        ocdcp.Text = Request.QueryString["ocdcp"];
                        if (ratep.Text != "")
                        {
                            rate = Convert.ToInt32(ratep.Text);
                        }
                        else
                        {
                            rate = 0;
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
                        totalp.Text = (rate + dvl + wc + ocda + ocdc).ToString();

                    }
                    pkgs.Text = dtcust.Rows[0]["noofpkgs"].ToString();
                    pkgs2.Text = dtcust.Rows[0]["noofpkgs"].ToString();
                    grosswt.Text = dtcust.Rows[0]["grosswt"].ToString();
                    wttype.Text = dtcust.Rows[0]["wttype"].ToString();
                    citemno.Text = dtcust.Rows[0]["citemno"].ToString();
                    chargewt.Text = dtcust.Rows[0]["chargewt"].ToString();
                    rateclass.Text = dtcust.Rows[0]["rateclass"].ToString();
                    rate = Convert.ToInt32(dtcust.Rows[0]["rateclass"]);
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
                    descn.Text = dtcust.Rows[0]["cargodesbl"].ToString();
                    lbllength.Text = dtcust.Rows[0]["length"].ToString();
                    lblbreadth.Text = dtcust.Rows[0]["breadth"].ToString();
                    lblwidth.Text = dtcust.Rows[0]["width"].ToString();
                    lblpieces.Text = dtcust.Rows[0]["pieces"].ToString();
                    lbl_short2.Text = dtcust.Rows[0]["shortcode2"].ToString();
                    lbl_short3.Text = dtcust.Rows[0]["shortcode3"].ToString();
                    lbl_flno.Text = dtcust.Rows[0]["flightno"].ToString();
                    Lbl_flno2.Text = dtcust.Rows[0]["flightno2"].ToString();
                    if(dtcust.Rows[0]["flightdate2"].ToString() != "")
                    {
                        lbl_fldate2.Text = Convert.ToDateTime(dtcust.Rows[0]["flightdate2"]).ToString("dd/MM/yyyy");

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