using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class BookingSlip : System.Web.UI.Page
    {
        DataAccess.Marketing.Booking bookobj = new DataAccess.Marketing.Booking();
        DataAccess.BuyingRate buyobj = new DataAccess.BuyingRate();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        string booking;
        string trantype;
        string branchid;
        string rateid,prc="";
        string stype, fstatus;
        DataTable dt = new DataTable();
        DataTable dts = new DataTable();
        DataTable dtcom = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                bookobj.GetDataBase(Ccode);
                buyobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);
            }

            if (Request.QueryString.ToString().Contains("Booking"))
            {
                //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                }
                 

                if (Session["LoginDivisionName"] != null)
                {
                    lbl_branch.Text = Session["LoginDivisionName"].ToString();

                }
                dtcom = logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {
                    lbl_add.Text = dtcom.Rows[0]["address"].ToString();//Dt.Rows[0]["phone"].ToString()+ " Fax : " + Dt.Rows[0]["fax"].ToString() 
                    lbl_ph.Text = dtcom.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcom.Rows[0]["fax"].ToString();
                    lbl_email.Text = dtcom.Rows[0]["email"].ToString();
                   
                    //lbldate.Text = dtime.ToShortDateString();
                   // lbldate.Text = DateTime.Parse(logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                }
              //  DateTime joudate = logobj.GetDate();
               // lbl_Date.Text = joudate.ToShortDateString();
                lbl_Date.Text=DateTime.Parse(logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                rateid = Request.QueryString["Buying"].ToString();
                booking = Request.QueryString["Booking"].ToString();
                trantype = Request.QueryString["StrTranType"].ToString();
                branchid = Request.QueryString["LoginBranchid"].ToString();
                dt = bookobj.Sp_bookingslip(Convert.ToInt32(branchid), booking, trantype);
                if(dt.Rows.Count>0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["customername"].ToString()))
                    {
                        lbl_customer.Text = dt.Rows[0]["customername"].ToString();
                    }
                    
                    string addr = dt.Rows[0]["door#"].ToString() + " " + dt.Rows[0]["address"].ToString() + "</br>";
                    addr += dt.Rows[0]["Location"].ToString() + "</br>";
                    addr += dt.Rows[0][30].ToString() + "-" + dt.Rows[0]["zip"].ToString() + "</br>";
                    addr += dt.Rows[0]["DistrictName"].ToString() + "</br>";
                    addr += dt.Rows[0]["statename"].ToString() + "</br>";
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ptc"].ToString()))
                    {
                        addr += "PTC:" + dt.Rows[0]["ptc"].ToString() + "</br>";
                    }
                     if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                    {
                        addr += "Ph:" + dt.Rows[0]["phone"].ToString() + "</br>";

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["email"].ToString()))
                    {
                        addr += "Email:" + dt.Rows[0]["email"].ToString() + "</br>";
                    }
                  
                    lbl_address.Text = addr.ToString();
                    

                    lbl_book.Text = dt.Rows[0]["shiprefno"].ToString();
                   // lbl_quotation.Text = dt.Rows[0]["quotno"].ToString() +" & " +Convert.ToDateTime(dt.Rows[0]["quotdate"]).ToShortDateString();


                    lbl_quotation.Text = dt.Rows[0]["quotno"].ToString() + " & " + Convert.ToDateTime(Convert.ToDateTime(dt.Rows[0]["quotdate"]).ToShortDateString()).ToString("dd-MMM-yyyy");
                    lbl_types.Text = dt.Rows[0]["cargotype"].ToString();
                    lbl_cargodescription.Text = dt.Rows[0]["descn"].ToString();
                     stype = dt.Rows[0]["stype"].ToString();
                     if (stype == "F")
                     {
                         lbl_shipment.Text = "FCL";
                         }
                     else
                     {
                         lbl_shipment.Text ="LCL";
                     }
                    fstatus = dt.Rows[0]["fstatus"].ToString();

                    if (fstatus== "P" )
                    {
                        lbl_Prepaid.Text = "Prepaid";
                    }
                    else
                    {
                         lbl_Prepaid.Text="To Collect";
                    }
                     

                    lbl_place.Text = dt.Rows[0]["portname"].ToString();
                    lbl_discharge.Text = dt.Rows[0]["portnamedischarge"].ToString();
                    lbl_portload.Text = dt.Rows[0]["portname"].ToString();
                    lbl_finaldestion.Text = dt.Rows[0]["FinalDestination"].ToString();
                    lbl_remark.Text = dt.Rows[0]["remarks"].ToString();
                    lbl_name.Text = dt.Rows[0]["empname"].ToString();
                    lbl_bkremarks.Text = dt.Rows[0]["bremarks"].ToString();

                    lbl_bookingdate.Text = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[0]["bookingdate"]).ToShortDateString()).ToString("dd-MMM-yyyy");// dt.Rows[0]["bookingdate"].ToString();
                    for (int i = 0; i <=dt.Rows.Count-1; i++)
                    {
                        tr_row.Text += "<tr style='background-color:#d0d0d0; border-bottom:1px solid #cdbcb1;'>";
                        tr_row.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 9px;  border-right:1px solid #cdbcb1;'>" + dt.Rows[i]["chargename"].ToString() + "</td>";
                        tr_row.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 9px;  border-right:1px solid #cdbcb1; text-align:right;'>" + dt.Rows[i]["curr"].ToString() + "</td>";
                        tr_row.Text += "<td style='color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 9px;  border-right:1px solid #cdbcb1;'><div style='margin-right:15px; width:150px; float:left; text-align:right;'>"+ Convert.ToDouble(dt.Rows[i]["rate"]).ToString("#,0.00") + "</div>" +"<div style='width:60px; float:right; text-align:right;'>" +dt.Rows[i]["base"].ToString() + "</div></td>";
                        if (!string.IsNullOrEmpty(dt.Rows[i]["prc"].ToString()))
                        {
                            if ((dt.Rows[i]["prc"].ToString()) == "P")
                            {
                                prc = "Prepaid";
                            }
                            else
                            {
                                prc = "Collect";
                            }
                        }
                        
                        tr_row.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 9px;  border-right:1px solid #cdbcb1;'>" +prc + "</td>";
                        tr_row.Text += "</tr>";
                    }
                }

                if (rateid != "0")
                {

                    dts = buyobj.get_buyingreport(int.Parse(rateid));
                    lbl_buying.Text = rateid;
                    lbl_carrier.Text = dts.Rows[0]["customername"].ToString();
                    if (dts.Rows.Count > 0)
                    {
                        for (int i = 0; i<=dts.Rows.Count-1; i++)
                        {
                            tr_row1.Text += "<tr style='background-color:#d0d0d0; border-bottom:1px solid #cdbcb1;'>";
                            tr_row1.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 9px;  border-right:1px solid #cdbcb1;'>" + dts.Rows[i]["chargename"].ToString() + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 9px;  border-right:1px solid #cdbcb1;'>" + dts.Rows[i]["curr"].ToString() + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 9px;  border-right:1px solid #cdbcb1;'><div style='margin-right:15px; float:left; width:150px; text-align:right;'>" + Convert.ToDouble(dts.Rows[i]["rate"]).ToString("#,0.00") + "</div>" + "<div style='margn-right:15px; width:60px; float:right; text-align:right;'>" + dts.Rows[i]["base"].ToString() + "</div></td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 9px;  border-right:1px solid #cdbcb1;'>" + prc + "</td>";
                            tr_row1.Text += "</tr>";
                        }
                    }
                }


            }
        }
    }
}