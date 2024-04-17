using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace logix.Reportasp
{
    public partial class AdminDCNrpt : System.Web.UI.Page
    {
        DataTable Dt_tds = new DataTable();
        DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();
        DataTable dtadd = new DataTable();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        int DCNo, vouyear, branchid, refno, supplyto, customerid, count;
        string type, Profoma, fyear_invoice, branch_invoice, customertype;
        double temp_taxable, cgsta, sgsta, igsta;
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Payment objpay = new DataAccess.Accounts.Payment();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.OSDNCN objosdncn = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_inv.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
                objpay.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                objosdncn.GetDataBase(Ccode);
              
                masterObj.GetDataBase(Ccode);



            }

            try
            {


                string fadname = Session["FADbname"].ToString();
                DataTable dtcust = new DataTable();
                if (Request.QueryString.ToString().Contains("DCN"))
                {
                  //  DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                    }
                  
                    DCNo = Convert.ToInt32(Request.QueryString["DCN"].ToString());
                    lbl_branch.Text = Session["LoginDivisionName"].ToString();

                    if (Request.QueryString.ToString().Contains("form"))
                    {
                        type = Request.QueryString["form"].ToString();
                        if (Request.QueryString.ToString().Contains("Profoma"))
                        {
                            Profoma = Request.QueryString["Profoma"].ToString();
                        }
                        else
                        {
                            Profoma = "";
                        }
                        if (type == "Admin-CN")
                        {
                            if (Profoma == "Profoma")
                            {
                                lbl_head.Text = "Profoma CREDIT NOTE -  ADMIN";
                            }else
                            {
                                lbl_head.Text = "CREDIT NOTE -  ADMIN";
                            }      
                        }
                        else
                        {
                            if (Profoma == "Profoma")
                            { 
                                lbl_head.Text = "Profoma DEBIT NOTE -  ADMIN"; }
                            else
                            {
                                lbl_head.Text = "DEBIT NOTE -  ADMIN";
                            }
                            
                        }
                    }
                    

                    if (Request.QueryString.ToString().Contains("customertype"))
                    {
                        customertype = Request.QueryString["customertype"].ToString();
                    }
                    else
                    {
                        customertype = "";
                    }
                    vouyear = Convert.ToInt32(Request.QueryString["vouyear"].ToString());
                    fyear_invoice = vouyear.ToString().Substring(2, 2) + (vouyear + 1).ToString().Substring(2, 2);
                    branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    lbl_total.Text = Request.QueryString["total"].ToString();
                    label_branch.InnerText = lbl_branch.Text.ToUpper();
                    if (Session["Basecurr"] != null)
                    {
                        th_basecurr.InnerText = Session["Basecurr"].ToString().ToUpper();
                        td_tax_basecurr.InnerText = "(" + th_basecurr.InnerText + ")";
                    }


                    dtadd = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    {
                        lbl_add.Text = dtadd.Rows[0]["address"].ToString().ToUpper();
                        lbl_ph.Text = dtadd.Rows[0]["phone"].ToString().ToUpper();
                        lbl_fax.Text = dtadd.Rows[0]["fax"].ToString().ToUpper();
                        lbl_st.Text = dtadd.Rows[0]["gstin"].ToString().ToUpper();
                        lbl_pan.Text = dtadd.Rows[0]["panno"].ToString().ToUpper();
                        lbl_cin.Text = dtadd.Rows[0]["cinno"].ToString().ToUpper();
                    }
                    dt = objpay.sp_debitnoteadmin(DCNo, vouyear, branchid, type, Profoma);
                    if (dt.Rows.Count > 0)
                    {
                        if (type == "Admin-CN")
                        {
                            div_vendorref.Visible = true;
                            lbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();
                            if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                            {
                                lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                            }
                            else
                            {
                                lbl_vendordate.Text = "";
                            }
                            labeldnc.InnerText = "CN # :";
                        }
                        count = dt.Rows.Count;
                        label_refno.InnerText = dt.Rows[0]["refno"].ToString();
                        string[] branch_inv = dt.Rows[0]["shortname"].ToString().Split('-');
                        if (branch_inv.Length > 0)
                        {
                            branch_invoice = branch_inv[1].ToString();
                        }

                        if (Profoma == "Profoma" && (type == "Admin-CN" || type == "Admin-DN"))
                        {
                            label_DNCN.InnerText = dt.Rows[0]["dnno"].ToString() + " / " + dt.Rows[0]["shortname"].ToString();
                        }
                        else if (Profoma == "" && type == "Admin-CN")
                        {
                            label_DNCN.InnerText = "CN" + fyear_invoice + branch_invoice + dt.Rows[0]["dnno"].ToString();
                        }
                        else if (Profoma == "" && type == "Admin-DN")
                        {
                            label_DNCN.InnerText = "DN" + fyear_invoice + branch_invoice + dt.Rows[0]["dnno"].ToString();
                        }

                        label_date.InnerText = Convert.ToDateTime(dt.Rows[0]["dndate"].ToString()).ToString("dd-MMM-yyyy");
                        customerid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                        dtcust = objosdncn.Getcustomerledgername(fadname, customerid);
                        if (dtcust.Rows.Count > 0)
                        {
                            FALedger.Visible = true;
                            lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                        }
                        lbl_remarks.Text = dt.Rows[0]["remarks"].ToString().ToUpper();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["supplyto"].ToString()))
                        {
                            supplyto = Convert.ToInt32(dt.Rows[0]["supplyto"].ToString());
                        }
                        else
                        {
                            supplyto = 0;
                        }

                        temp_taxable = 0; cgsta = 0; sgsta = 0; igsta = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:300px;'>" + dt.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px; border-right:1px solid #000; width:80px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dt.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;width:35px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'><label style='display:inline-block; float:left; text-align:left;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                            if (!string.IsNullOrEmpty(dt.Rows[i]["Actamount"].ToString().ToUpper()))
                            {
                                temp_taxable += Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper());
                                tr_row.Text += "<td style='color:#2c2b2b; width: 100px; text-align:right; padding:0px 2px 0px 0px; border-right:1px solid #000;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                            }
                            else
                            {
                                tr_row.Text += "<td style='color:#2c2b2b; width: 100px; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            }
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;' align='right'>" + dt.Rows[i]["CGSTP"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(dt.Rows[i]["cgsta"].ToString()))
                            {
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                cgsta += Convert.ToDouble(dt.Rows[i]["cgsta"].ToString());
                            }
                            else
                            {
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            }
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000; text-align:right;'>" + dt.Rows[i]["sgstp"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(dt.Rows[i]["sgsta"].ToString()))
                            {
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                sgsta += Convert.ToDouble(dt.Rows[i]["sgsta"].ToString());
                            }
                            else
                            {
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            }
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;' align='right'>" + dt.Rows[i]["igstp"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(dt.Rows[i]["igsta"].ToString()))
                            {
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;' align='right'>" + Convert.ToDouble(dt.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                igsta += Convert.ToDouble(dt.Rows[i]["igsta"].ToString());
                            }
                            else
                            {
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            }
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000; width:100px;'  align='right'>" + (Convert.ToDouble(dt.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";

                        }

                        Dt_tds = obj_inv.get_tdspayable(DCNo, branchid, vouyear, "S");
                        if (Dt_tds.Rows.Count > 0)
                        {
                            tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'><b>NET AMOUNT :" + Dt_tds.Rows[0]["cstamount"].ToString() + "</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td></tr>";

                            tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000; width:135px;'>TDS PAYABLE " + Dt_tds.Rows[0]["tdsdesc"].ToString() + " Rs. " + Dt_tds.Rows[0]["tdsamount"].ToString() + "</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td></tr>";

                            count += 2;
                        }
                        if (temp_taxable > 0)
                        {
                            td_taxableamt.InnerText = temp_taxable.ToString("#,0.00");
                        }
                        if (cgsta > 0)
                        {
                            td_cgsta.InnerText = cgsta.ToString("#,0.00");
                        }
                        if (sgsta > 0)
                        {
                            td_sgsta.InnerText = sgsta.ToString("#,0.00");
                        }
                        if (igsta > 0)
                        {
                            td_igsta.InnerText = igsta.ToString("#,0.00");
                        }

                        for (int i = count; i < 45; i++)
                        {
                            tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right:1px solid #000;'>&nbsp;</td></tr>";
                        }
                    }

                    dt = custobj.Get_customerdetails(customerid);
                    if (dt.Rows.Count > 0)
                    {

                        lbl_toaddress.Text += dt.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                        if (!string.IsNullOrEmpty(dt.Rows[0]["address"].ToString()))
                        {
                            lbl_toaddress.Text += dt.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["Location"].ToString()))
                        {
                            lbl_toaddress.Text += dt.Rows[0]["Location"].ToString().ToUpper() + " ,";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["portname"].ToString()))
                        {
                            lbl_toaddress.Text += dt.Rows[0]["portname"].ToString().ToUpper();
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["zip"].ToString()))
                        {
                            lbl_toaddress.Text += " - " + dt.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                        }
                        else
                        {
                            lbl_toaddress.Text += "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["districtname"].ToString()))
                        {
                            lbl_toaddress.Text += dt.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["statename"].ToString()))
                        {
                            lbl_toaddress.Text += dt.Rows[0]["statename"].ToString().ToUpper() + "<br />";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["ptc"].ToString()))
                        {
                            lbl_toaddress.Text += "<strong>PTC :</strong>" + dt.Rows[0]["ptc"].ToString().ToUpper() + " ";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                        {
                            lbl_toaddress.Text += "<strong>PH :</strong>" + dt.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        }

                        div_gst.InnerText = dt.Rows[0]["gstin"].ToString().ToUpper().ToUpper();
                        gst_state.InnerText = dt.Rows[0]["statename"].ToString().ToUpper();
                        gst_code.InnerText = dt.Rows[0]["gstcode"].ToString().ToUpper();
                    }

                    if (supplyto != 0)
                    {
                        dt = custobj.Get_customerdetails(supplyto);
                        if (dt.Rows.Count > 0)
                        {

                            lbl_tosupply.Text += dt.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                            if (!string.IsNullOrEmpty(dt.Rows[0]["address"].ToString()))
                            {
                                lbl_tosupply.Text += dt.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                            }

                            if (!string.IsNullOrEmpty(dt.Rows[0]["Location"].ToString()))
                            {
                                lbl_tosupply.Text += dt.Rows[0]["Location"].ToString().ToUpper() + " ,";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["portname"].ToString()))
                            {
                                lbl_tosupply.Text += dt.Rows[0]["portname"].ToString().ToUpper();
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["zip"].ToString()))
                            {
                                lbl_tosupply.Text += " - " + dt.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                            }
                            else
                            {
                                lbl_tosupply.Text += "<br />";
                            }

                            if (!string.IsNullOrEmpty(dt.Rows[0]["districtname"].ToString()))
                            {
                                lbl_tosupply.Text += dt.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["statename"].ToString()))
                            {
                                lbl_tosupply.Text += dt.Rows[0]["statename"].ToString().ToUpper() + ".<br />";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["ptc"].ToString()))
                            {
                                lbl_tosupply.Text += "<strong>PTC :</strong>" + dt.Rows[0]["ptc"].ToString().ToUpper() + " ";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                            {
                                lbl_tosupply.Text += "<strong>PH :</strong>" + dt.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                            }

                            div_supplygst.InnerText = dt.Rows[0]["gstin"].ToString().ToUpper().ToUpper();
                            div_supplystate.InnerText = dt.Rows[0]["statename"].ToString().ToUpper();
                            div_supplycode.InnerText = dt.Rows[0]["gstcode"].ToString().ToUpper();
                        }
                    }
                    double price1; bool isDouble2;
                    isDouble2 = Double.TryParse(lbl_total.Text, out price1);
                    if (isDouble2)
                    {
                        //lbl_currword.Text = th_basecurr.InnerText + "  " + ConvertNumbertoWords(Convert.ToInt32(price1)) + " ONLY";
                        if (customertype == "P")
                        {
                            lbl_currword.Text = "USD" + "  " + conversion(lbl_total.Text, "") + " ONLY";
                        }
                        else
                        {
                            lbl_currword.Text = th_basecurr.InnerText + "  " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                        }
                    }
                    if (Profoma == "Profoma")
                    {
                        labeldnc.InnerText = "Refno :";
                        label_approved.Visible = true;
                        if (type == "Admin-CN")
                        {
                            label_approved.InnerText = "Unapproved Credit Note";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        //public string conversion(string amount)
        //{
        //    double m = Convert.ToInt64(Math.Floor(Convert.ToDouble(amount)));
        //    double l = Convert.ToDouble(amount);

        //    double j = (l - m) * 100;


        //    var beforefloating = ConvertNumbertoWords(Convert.ToInt64(m));
        //    var afterfloating = ConvertNumbertoWords(Convert.ToInt64(j));



        //    var Content = beforefloating + ' ' + " RUPEES" + ' ' + afterfloating + ' ' + " PAISE only";
        //    return Content;
        //}


        /*  public string conversion(string amount, string curr)
          {
              double m = Convert.ToInt64(Math.Floor(Convert.ToDouble(amount)));
              double l = Convert.ToDouble(amount);

              double j = (l - m) * 100;
              string Content = "";
              if (curr == "INR")
              {
                  var beforefloating = ConvertNumbertoWordsINR(Convert.ToInt64(m));
                  var afterfloating = ConvertNumbertoWordsINR(Convert.ToInt64(j));
                  Content = beforefloating + ' ' + " RUPEES" + ' ' + afterfloating + ' ' + " PAISE only";
              }
              else
              {
                  var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                  var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                  Content = beforefloating + ' ' + " DOLLARS " + ' ' + afterfloating + ' ' + "CENTS";
              }
              return Content;
          }*/



        //MANOJ


        public string conversion(string amount, string curr)
        {
            double m = Convert.ToInt64(Math.Floor(Convert.ToDouble(amount)));
            double l = Convert.ToDouble(amount);

            double j = (l - m) * 100;
            string Content = "";
            if (curr == "INR")
            {
                var beforefloating = ConvertNumbertoWordsINR(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsINR(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " INDIAN RUPEES" + ' ' + afterfloating + ' ' + " PAISE";
            }
            else if (curr == "USD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " US DOLLARS " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "AED")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " UAE DIRHAM " + ' ' + afterfloating + ' ' + " FILS";
            }
            else if (curr == "AUD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " AUSTRALIAN DOLLAR " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "CAD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " CANADIAN DOLLAR " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "CHF")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " SWISS FRANC " + ' ' + afterfloating + ' ' + " RAPPEN";
            }
            else if (curr == "CNY")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " CHINESE YUAN RENMINBI " + ' ' + afterfloating + ' ' + " JIAO (FEN)";
            }
            else if (curr == "DKK")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " DANISH KRONE " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "ETB")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " ETHIOPIAN BIRR " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "EUR")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " EURO " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "GBP")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " POUNDS " + ' ' + afterfloating + ' ' + " PENCE";
            }
            else if (curr == "HKD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " 	HONG KONG DOLLAR " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "JPY")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " 	JAPANESE YEN " + ' ' + afterfloating + ' ' + " SEN";
            }
            else if (curr == "NZD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " 	NEW ZEALAND DOLLAR " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "SEK")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " 	SWEDISH KRONA " + ' ' + afterfloating + ' ' + " ORE";
            }
            else if (curr == "SGD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " SINGAPORE DOLLAR " + ' ' + afterfloating + ' ' + " CENTS";
            }
            else if (curr == "ZAR")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " SOUTH AFRICAN RAND " + ' ' + afterfloating + ' ' + " CENTS";
            }
            return Content;
        }
        //public string ConvertNumbertoWords(long number)
        //{
        //    if (number == 0) return "ZERO";
        //    if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        //    string words = "";
        //    if ((number / 1000000) > 0)
        //    {
        //        words += ConvertNumbertoWords(number / 100000) + " LAKES ";
        //        number %= 1000000;
        //    }
        //    if ((number / 1000) > 0)
        //    {
        //        words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
        //        number %= 1000;
        //    }
        //    if ((number / 100) > 0)
        //    {
        //        words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
        //        number %= 100;
        //    }
        //    //if ((number / 10) > 0)  
        //    //{  
        //    // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
        //    // number %= 10;  
        //    //}  
        //    if (number > 0)
        //    {
        //        if (words != "") words += "AND ";
        //        var unitsMap = new[]   
        //        {  
        //            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"  
        //        };
        //                var tensMap = new[]   
        //        {  
        //            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"  
        //        };
        //        if (number < 20) words += unitsMap[number];
        //        else
        //        {
        //            words += tensMap[number / 10];
        //            if ((number % 10) > 0) words += " " + unitsMap[number % 10];
        //        }
        //    }
        //    return words;
        //}



        public string ConvertNumbertoWordsINR(long number)
        {
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWordsINR(Math.Abs(number));
            string words = "";
            if ((number / 10000000) > 0)
            {
                words += ConvertNumbertoWordsINR(number / 10000000) + " Crore ";
                number %= 10000000;
            }
            if ((number / 100000) > 0)
            {
                words += ConvertNumbertoWordsINR(number / 100000) + " LAKES ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWordsINR(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWordsINR(number / 100) + " HUNDRED ";
                number %= 100;
            }
            //if ((number / 10) > 0)
            //{
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";
            // number %= 10;
            //}
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]
                {
                    "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
                };
                var tensMap = new[]
                {
                    "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
                };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }


        public static string ConvertNumbertoWordsUSD(long number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWordsUSD(Math.Abs(number));
            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertNumbertoWordsUSD(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWordsUSD(number / 1000000) + " MILLION ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWordsUSD(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWordsUSD(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }

        /*public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 10000000) > 0)
            {
                words += ConvertNumbertoWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }*/

    }
}