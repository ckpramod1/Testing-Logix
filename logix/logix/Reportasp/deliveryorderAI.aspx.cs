using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class deliveryorderAI : System.Web.UI.Page
    {
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.BLPrinting blobj = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dt = new DataTable();
        DataTable dtcus = new DataTable();
        DataTable dtcom = new DataTable();
        string blid;
        string branchid;
        int customerid,consigneeid;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                logobj.GetDataBase(Ccode);
                blobj.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);

            }

            if (Request.QueryString.ToString().Contains("BLNO"))
            {


                if (Session["LoginDivisionId"] != null)
                {

                    //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    
                }

                if (Session["LoginDivisionName"] != null)
                {
                    lbl_branchnew.Text = Session["LoginDivisionName"].ToString();

                }
                dtcom = logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {

                    lbl_add.Text = dtcom.Rows[0]["address"].ToString().ToUpper();
                    lbl_ph.Text = dtcom.Rows[0]["phone"].ToString().ToUpper();
                    lbl_fax1.Text = dtcom.Rows[0]["fax"].ToString().ToUpper();
                    lbl_st.Text = dtcom.Rows[0]["gstin"].ToString().ToUpper();
                    lbl_pan.Text = dtcom.Rows[0]["panno"].ToString().ToUpper();
                    lbl_cin.Text = dtcom.Rows[0]["cinno"].ToString().ToUpper();

                    lbl_panno.Text = dtcom.Rows[0]["panno"].ToString().ToUpper();
                    lbl_staxhead.Text = dtcom.Rows[0]["stno"].ToString().ToUpper();
                }
                blid = Request.QueryString["BLNO"].ToString();
                branchid = Session["LoginBranchid"].ToString();
                dt = blobj.SP_BLPRINTAI(blid, Convert.ToInt32(branchid));
                lbl_currdate.Text = logobj.GetDate().ToString("dd/MM/yyyy");

                if (dt.Rows.Count > 0)
                {
                    
                    lbl_Customername.Text = dt.Rows[0]["msconcustomername"].ToString();
                    lbl_DONum.Text = dt.Rows[0]["dono"].ToString();
                    Lbl_Date.Text = Convert.ToDateTime(dt.Rows[0]["doissuedon"]).ToShortDateString();
                    //lbl_flightno.Text = dt.Rows[0]["flightno"].ToString();
                    //lbl_flightdate.Text = Convert.ToDateTime(dt.Rows[0]["flightdate"]).ToShortDateString();

                    lbl_MAWBLNUMB.Text = dt.Rows[0]["mawblno"].ToString();
                    lbl_MAWBLDate.Text = Convert.ToDateTime(dt.Rows[0]["mawbldate"]).ToShortDateString();
                    lbl_IGMNum.Text = dt.Rows[0]["manifestno"].ToString();
                    lbl_IGMDate.Text = Convert.ToDateTime(dt.Rows[0]["manifestdate"]).ToShortDateString();
                    lbl_HAWBLNum.Text = dt.Rows[0]["hawblno"].ToString();
                    lbl_HAWBLDate.Text = Convert.ToDateTime(dt.Rows[0]["issuedon"]).ToShortDateString();
                    lbl_portname.Text = dt.Rows[0]["portname"].ToString();
                    lbl_Noofpkg.Text = dt.Rows[0]["noofpkgs"].ToString();
                    Lbl_desc.Text = dt.Rows[0]["pkgdesc"].ToString();
                    lbl_Grwg.Text = dt.Rows[0]["grosswt"].ToString();
                    lbl_chrgwt.Text = dt.Rows[0]["chargewt"].ToString();
                    lbl_contentdesc.Text = dt.Rows[0]["bldesc"].ToString();
                    // lbl_cha.Text = dt.Rows[0]["bldesc"].ToString();



                    lbl_branch.Text = dt.Rows[0]["branchname"].ToString();
                    consigneeid = Convert.ToInt32(dt.Rows[0]["consigneeid"].ToString());
                    dtcus = custobj.Get_customerdetails(consigneeid);
                      if (dtcus.Rows.Count > 0)
                      {

                          lbl_toaddress.Text += "M/S "+ dtcus.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["address"].ToString()))
                          {
                              lbl_toaddress.Text += dtcus.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                          }

                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["Location"].ToString()))
                          {
                              lbl_toaddress.Text += dtcus.Rows[0]["Location"].ToString().ToUpper() + " ,";
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["portname"].ToString()))
                          {
                              lbl_toaddress.Text += dtcus.Rows[0]["portname"].ToString().ToUpper();
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["zip"].ToString()))
                          {
                              lbl_toaddress.Text += " - " + dtcus.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                          }
                          else
                          {
                              lbl_toaddress.Text += "<br />";
                          }

                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["districtname"].ToString()))
                          {
                              lbl_toaddress.Text += dtcus.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["statename"].ToString()))
                          {
                              lbl_toaddress.Text += dtcus.Rows[0]["statename"].ToString().ToUpper() + "<br />";
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["ptc"].ToString()))
                          {
                              lbl_toaddress.Text += "<strong>PTC :</strong>" + dtcus.Rows[0]["ptc"].ToString().ToUpper() + " ";
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["phone"].ToString()))
                          {
                              lbl_toaddress.Text += "<strong>PH :</strong>" + dtcus.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                          }
                   
                      }




                      customerid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                      dtcus = custobj.Get_customerdetails(customerid);
                      if (dtcus.Rows.Count > 0)
                      {

                          lbl_consaddress.Text += "M/S " + dtcus.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["address"].ToString()))
                          {
                              lbl_consaddress.Text += dtcus.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                          }

                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["Location"].ToString()))
                          {
                              lbl_consaddress.Text += dtcus.Rows[0]["Location"].ToString().ToUpper() + " ,";
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["portname"].ToString()))
                          {
                              lbl_consaddress.Text += dtcus.Rows[0]["portname"].ToString().ToUpper();
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["zip"].ToString()))
                          {
                              lbl_consaddress.Text += " - " + dtcus.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                          }
                          else
                          {
                              lbl_consaddress.Text += "<br />";
                          }

                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["districtname"].ToString()))
                          {
                              lbl_consaddress.Text += dtcus.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["statename"].ToString()))
                          {
                              lbl_consaddress.Text += dtcus.Rows[0]["statename"].ToString().ToUpper() + "<br />";
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["ptc"].ToString()))
                          {
                              lbl_consaddress.Text += "<strong>PTC :</strong>" + dtcus.Rows[0]["ptc"].ToString().ToUpper() + " ";
                          }
                          if (!string.IsNullOrEmpty(dtcus.Rows[0]["phone"].ToString()))
                          {
                              lbl_consaddress.Text += "<strong>PH :</strong>" + dtcus.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                          }

                      } 


                }
            }

        }

    }
}