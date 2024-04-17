using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace logix.Reportasp
{
    public partial class Shippingbillrpt : System.Web.UI.Page
    {
        DataTable dtcom = new DataTable();
        DataAccess.ForwardingExports.ShippingBill obj_da_FEshippingbill = new DataAccess.ForwardingExports.ShippingBill();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
         
        DataTable dtship = new DataTable();
        DataTable dtcon = new DataTable();
        string str_Script, rowbind;
        DateTime dtime;
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_FEshippingbill.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("sno"))
            {
                if (Session["LoginDivisionName"]!=null)
                {
                    lbl_branch.Text = Session["LoginDivisionName"].ToString();

                }

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

                dtcom = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {
                    lbl_add.Text = dtcom.Rows[0]["address"].ToString();//Dt.Rows[0]["phone"].ToString()+ " Fax : " + Dt.Rows[0]["fax"].ToString() 
                    lbl_ph.Text = dtcom.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcom.Rows[0]["fax"].ToString();
                    lbl_email.Text = dtcom.Rows[0]["email"].ToString();
                    dtime=da_obj_Log.GetDate();
                    lbldate.Text = dtime.ToShortDateString();

                }
                sbno.Text = Request.QueryString["sno"].ToString();
                string bid = Request.QueryString["bid"].ToString();
                dtship = obj_da_FEshippingbill.Getshippingbill(Convert.ToInt32(bid), sbno.Text);
                if(dtship.Rows.Count>0)
                {
                    mate.Text = dtship.Rows[0]["mate"].ToString();
                    sbno.Text = dtship.Rows[0]["sbno"].ToString();
                    grno.Text = dtship.Rows[0]["grno"].ToString();
                    emno.Text = dtship.Rows[0]["emno"].ToString();
                    billname.Text = dtship.Rows[0]["billname"].ToString();

                    if (!string.IsNullOrEmpty(dtship.Rows[0]["etd"].ToString()))
                    {
                        mrdate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtship.Rows[0]["etd"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                    }
                    if (!string.IsNullOrEmpty(dtship.Rows[0]["sbdate"].ToString()))
                    {
                        sbdate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtship.Rows[0]["sbdate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                    }
                    if (!string.IsNullOrEmpty(dtship.Rows[0]["grdate"].ToString()))
                    {
                        grdate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtship.Rows[0]["grdate"].ToString()).ToShortDateString());
                    }
                    if (!string.IsNullOrEmpty(dtship.Rows[0]["emdate"].ToString()))
                    {
                        emdate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtship.Rows[0]["emdate"].ToString()).ToShortDateString());
                    }
                    txt1.Text = "Received for the Shipment the " + dtship.Rows[0]["vesselname"].ToString().Trim() + " Voy." + dtship.Rows[0]["voyage"].ToString().Trim() + " From " + dtship.Rows[0]["customername"].ToString().Trim();
                    txt2.Text = "The Noted Goods for the Port of " + dtship.Rows[0]["portname"].ToString().Trim();
                    marks.Text = dtship.Rows[0]["marks"].ToString();
                    noofpkg.Text = dtship.Rows[0]["noofpkg"].ToString();
                    descn.Text = dtship.Rows[0][15].ToString();
                    descndetails.Text = dtship.Rows[0][16].ToString();
                    wts.Text = Convert.ToDouble(dtship.Rows[0]["grosswt"]).ToString("#,0.00") + "KGS";
                    //containerno.Text = dtship.Rows[0]["containerno"].ToString();
                    //sizetype.Text = dtship.Rows[0]["sizetype"].ToString();
                    //sealno.Text = dtship.Rows[0]["sealno"].ToString();
                    if (Session["LoginDivisionName"]!=null)
                    {
                        lblcmpy.Text = Session["LoginDivisionName"].ToString();
                    }
                  
                }

                if (dtship.Rows.Count > 0)
                {
                    rowbind = "";
                    if (Request.QueryString.ToString().Contains("nextpage"))
                    {
                        if (Request.QueryString["nextpage"].ToString() == "2")
                        {
                            if (dtship.Rows.Count > 10 && dtship.Rows.Count < 30)
                            {
                                for (int i = 10; i < dtship.Rows.Count; i++)
                                {
                                    tr_row.Text += "<tr style='background-Color:#d0d0d0;'>";
                                    tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["containerno"].ToString() +"</td>";
                                    tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["sizetype"].ToString() +"</td>";
                                    tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["sealno"].ToString() + "</td>";
                               
                                    tr_row.Text += "</tr>";
                                    if (i == 19)
                                    {
                                        break;
                                    }
                                }
                            }
                            lbl_page.Text = "Page of 1-2";
                            return;
                        }
                        else if (Request.QueryString["nextpage"].ToString() == "3")
                        {
                            if (dtship.Rows.Count > 20)
                            {
                                for (int i = 20; i < dtship.Rows.Count; i++)
                                {
                                    tr_row.Text += "<tr style='background-Color:#d0d0d0;'>";
                                    tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["containerno"].ToString() + "</td>";
                                    tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["sizetype"].ToString() + "</td>";
                                    tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["sealno"].ToString() + "</td>";
                                    tr_row.Text += "</tr>";
                                    if (i == 29)
                                    {
                                        break;
                                    }
                                }
                            }
                            lbl_page.Text = "Page of 1-3";
                            return;
                        }

                    }
                    if (dtship.Rows.Count <= 10 || !Request.QueryString.ToString().Contains("nextpage"))
                    {
                        for (int i = 0; i < dtship.Rows.Count; i++)
                        {
                            tr_row.Text += "<tr style='background-Color:#d0d0d0;'>";
                            tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["containerno"].ToString() + "</td>";
                            tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["sizetype"].ToString() + "</td>";
                            tr_row.Text += "<td style='font-size:14px; font-weight:500; text-align:left;  color:black; padding:1px; font-family:sans-serif;'>" + dtship.Rows[i]["sealno"].ToString() + "</td>";
                            tr_row.Text += "</tr>";
                            if (i == 9)
                            {
                                break;
                            }
                        }
                        lbl_page.Text = "Page of 1-1";
                        lbl_page.Visible = true;
                    } if (dtship.Rows.Count > 10 && dtship.Rows.Count < 30)
                    {
                        str_Script = "window.open('../Reportasp/Shippingbillrpt.aspx?nextpage=2" + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", str_Script, true);
                        lbl_page.Visible = true;
                    }
                    if (dtship.Rows.Count > 20)
                    {
                        str_Script += "window.open('../Reportasp/Shippingbillrpt.aspx?nextpage=3" + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", str_Script, true);
                    }


                }
              
            }
        }
    }
}

