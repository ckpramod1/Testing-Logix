using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class deliveryorder : System.Web.UI.Page
    {
        string blid;
        string branchid;
        int shipment;
        int count, count1;
        DataTable dtLi = new DataTable();
        DataTable dtLi1 = new DataTable();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.BLPrinting blobj = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dt = new DataTable();
        DataTable dtcom = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                blobj.GetDataBase(Ccode);
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
               /* dtcom = logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {
                    lbl_add.Text = dtcom.Rows[0]["address"].ToString();//Dt.Rows[0]["phone"].ToString()+ " Fax : " + Dt.Rows[0]["fax"].ToString() 
                    lbl_ph.Text = dtcom.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcom.Rows[0]["fax"].ToString();
                    lbl_email.Text = dtcom.Rows[0]["email"].ToString();

                    //lbldate.Text = dtime.ToShortDateString();
                    // lbldate.Text = DateTime.Parse(logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                }*/


                dtcom = logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {

                    lbl_add.Text = dtcom.Rows[0]["address"].ToString().ToUpper();
                    lbl_ph.Text = dtcom.Rows[0]["phone"].ToString().ToUpper();
                    lbl_fax1.Text = dtcom.Rows[0]["fax"].ToString().ToUpper();
                    lbl_st.Text = dtcom.Rows[0]["gstin"].ToString().ToUpper();
                    lbl_pan.Text = dtcom.Rows[0]["panno"].ToString().ToUpper();
                    lbl_cin.Text = dtcom.Rows[0]["cinno"].ToString().ToUpper();

                }



                DateTime joudate = logobj.GetDate();
               // lbl_Date.Text = joudate.ToShortDateString();
                blid = Request.QueryString["BLNO"].ToString();
                branchid = Session["LoginBranchid"].ToString();
                /* if (Request.QueryString.ToString().Contains("LoginBranchid"))
                 {
                     //Request.QueryString["LoginBranchid"].ToString();joudate
                 }*/
                dt = blobj.SP_BLPRINT(blid, Convert.ToInt32(branchid));
                if(dt.Rows.Count>0)
                {
                    //lbl_customernamecfs.Text = dt.Rows[0]["cfscustomername"].ToString();

                    lbl_customername.Text = dt.Rows[0]["customername"].ToString();
                  /*  lbl_customername.Text = dt.Rows[0]["cfscustomername"].ToString();
                    lbl_address.Text = dt.Rows[0]["CFSaddress"].ToString() + "&nbsp;&nbsp;<br/>" + dt.Rows[0]["portname"].ToString() + "&nbsp;&nbsp;" +"-"+ dt.Rows[0]["zip"].ToString();
                    lbl_phone.Text = dt.Rows[0]["cfsphone"].ToString();
                    lbl_fax.Text = dt.Rows[0]["cfsfax"].ToString();
                    lbl_email.Text = dt.Rows[0]["cfsemail"].ToString();*/

                    lbl_address.Text += dt.Rows[0]["cfscustomername"].ToString().ToUpper() + "<br />";
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CFSaddress"].ToString()))
                    {
                        lbl_address.Text += dt.Rows[0]["CFSaddress"].ToString().Replace(",", "").ToUpper() + "<br />";
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["portname1"].ToString()) && !string.IsNullOrEmpty((dt.Rows[0]["zip"].ToString())))
                    {
                        lbl_address.Text += dt.Rows[0]["portname1"].ToString().ToUpper() + " - " + dt.Rows[0]["zip"].ToString().ToUpper()+ "<br />";
                    }
                    else
                    {
                        lbl_address.Text += dt.Rows[0]["portname1"].ToString().Replace(",", "").ToUpper() + "<br />"; ;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["cfsphone"].ToString()) && !string.IsNullOrEmpty(dt.Rows[0]["cfsfax"].ToString()))
                    {
                        lbl_address.Text += "<strong>PH: </strong>" + dt.Rows[0]["cfsphone"].ToString() + "<strong> Fax :</strong>" + dt.Rows[0]["cfsfax"].ToString() + "<br />"; ;
                    }
                    else if(!string.IsNullOrEmpty(dt.Rows[0]["cfsphone"].ToString()))
                    {
                        lbl_address.Text += "<strong>PH: </strong>" + dt.Rows[0]["cfsphone"].ToString().Replace(",", "").ToUpper() + "<br />"; ;
                    }
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["cfsemail"].ToString()))
                    //{
                    //    lbl_address.Text += "<strong> Email: </strong>" + dt.Rows[0]["cfsemail"].ToString().ToUpper() + "<br />";
                    //}
                    //else
                    //{
                    //    lbl_address.Text += "<br />";
                    //}


                    lbl_do.Text = dt.Rows[0]["dono"].ToString();
                    //lbl_email.Text = dt.Rows[0]["email"].ToString();
                    lbl_do.Text = dt.Rows[0]["dono"].ToString() +" & "+ Convert.ToDateTime(dt.Rows[0]["doissuedon"]).ToShortDateString();
                    lbl_IM.Text = dt.Rows[0]["imno"].ToString() + " & "+Convert.ToDateTime(dt.Rows[0]["imdate"]).ToShortDateString();
                    shipment = Convert.ToInt32(dt.Rows[0]["shipment"]);
                    if(shipment.ToString()=="1")
                    {
                        lbl_shipment.Text = "FCL / FCL";
                    }
                    else if(shipment.ToString()=="2")
                    {
                        lbl_shipment.Text = "FCL / LCL";
                    }
                    else if (shipment.ToString() == "3")
                    {
                        lbl_shipment.Text = "LCL / LCL";
                    }
                    else if (shipment.ToString() == "4")
                    {
                        lbl_shipment.Text = "LCL / FCL";    

                    }
                    

                    if (!string.IsNullOrEmpty(dt.Rows[0]["destuffdt"].ToString()))
                    {
                        lbl_desuffed.Text = dt.Rows[0]["destuffdt"].ToString();
                    }
                    //lbl_IM.Text = dt.Rows[0]["destuffdt"].ToString();
                    lbl_mbl.Text = dt.Rows[0]["mblno"].ToString() + "&nbsp;&nbsp;<strong> Date : </strong>" + Convert.ToDateTime(dt.Rows[0]["bldate"]).ToShortDateString();
                    lbl_blno.Text = dt.Rows[0]["blno"].ToString() + "&nbsp;&nbsp; <strong> Date : </strong>" + Convert.ToDateTime(dt.Rows[0]["bldate"]).ToShortDateString();
                    lbl_from.Text = dt.Rows[0]["portname"].ToString();
                    lbl_vessel.Text = dt.Rows[0]["vessel"].ToString() + "&nbsp;&nbsp;<strong> Voy : </strong>" + dt.Rows[0]["vouya"].ToString();
                    lbl_vessel1.Text = dt.Rows[0]["vesselname"].ToString() + "&nbsp;&nbsp;<strong> Voy : </strong>" + dt.Rows[0]["voyage"].ToString();
                    lbl_subline.Text = dt.Rows[0]["linenumber"].ToString() + "&nbsp;&nbsp;<strong> Sub Line # : </strong>" + dt.Rows[0]["sublineno"].ToString();
                    lbl_arrived.Text = Convert.ToDateTime(dt.Rows[0]["eta"]).ToShortDateString();
                    lbl_grossweight.Text = dt.Rows[0]["grweight"].ToString();
                    lbl_packages.Text = dt.Rows[0]["noofpkgs"].ToString() + dt.Rows[0]["descn"].ToString();
                    lbl_marks.Text = dt.Rows[0]["marks"].ToString();
                    lbl_desc.Text = dt.Rows[0]["descrip"].ToString();
                    DataView data1 = dt.DefaultView;
                    for (int i = 0; i<= dt.Rows.Count - 1;i++)
                    {
                        tr_row1.Text += "<tr style='border-bottom:1px solid #cdbcb1;'>";
                        tr_row1.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #000;'>" + dt.Rows[i]["containerno"].ToString() + "</td>";
                        tr_row1.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #000;'>" + dt.Rows[i]["sealno"].ToString() + "</td>";

                       if(dt.Rows[i]["sizetype"].ToString().Substring(0, 2)=="20")
                       {
                           if (!string.IsNullOrEmpty(dt.Rows[i]["sizetype"].ToString()))
                           {
                               if (dt.Rows[i]["sizetype"].ToString().Substring(0, 2) == "20")
                               {
                                   tr_row1.Text += "<td style='color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #000;'>" + dt.Rows[i]["sizetype"].ToString() + "</td>";

                                   data1.RowFilter = "sizetype = '" + dt.Rows[i]["sizetype"] + "' ";
                                   dtLi = data1.ToTable();
                               }
                               else
                               {
                                   tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #000;'></td>";
                               }
                           }
                       }

                       else if (dt.Rows[i]["sizetype"].ToString().Substring(0, 2) == "40")
                       {
                           if (!string.IsNullOrEmpty(dt.Rows[i]["sizetype"].ToString()))
                           {
                               if (dt.Rows[i]["sizetype"].ToString().Substring(0, 2) == "40")
                               {
                                   tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #000;'>" + dt.Rows[i]["sizetype"].ToString() + "</td>";
                                   data1.RowFilter = "sizetype = '" + dt.Rows[i]["sizetype"] + "' ";
                                   dtLi1 = data1.ToTable();
                               }
                               else
                               {
                                   tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #000;'></td>";
                               }
                           }
                           else
                           {
                               tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #000;'></td>";
                           }
                          
                       }
                      
                       tr_row1.Text += "</tr>";
                                               
                       
                    }
                    count = dtLi.Rows.Count;
                    count1 = dtLi1.Rows.Count;
                    lbl20.Text = count.ToString();
                    lbl40.Text = count1.ToString();
                        lbl_branch.Text = dt.Rows[0]["branchname"].ToString();
                    lbl_consignee.Text = dt.Rows[0]["caddress"].ToString();
                   
                }

            }
        }
    }
}