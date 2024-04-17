using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class Invoicerpt1 : System.Web.UI.Page
    {
        DataTable dtadd = new DataTable();
        DataTable dt = new DataTable();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        int invoice, jobno, bid, vouyear, customerid, count, cont_count, cont_, _line, page_, row_count, supplyto;
        string str_trantype, jobtype, containers, Profoma, fyear_invoice, branch_invoice = "";
        double volume, temp, tax, totaltax, sttax_tb, tax1, exrate, total;
        string[] roundup;
        string html, blno, bltype, Header, customertype;
        string[] cont;
        string str_Script, year, fyear;
        double stamt, cgsta, sgsta, igsta, tota_gst, temp_cgst, temp_sgst, temp_igst, temp_taxable;
        DataTable Dt_sort = new DataTable();
        int curr_count;
        string currency = "";
        DataTable dtinvoiceduedate = new DataTable();
        DataTable dtcount = new DataTable();
        DataAccess.Accounts.OSDNCN objosdncn = new DataAccess.Accounts.OSDNCN();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Log.GetDataBase(Ccode);
                obj_inv.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                objosdncn.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
               
                masterObj.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }


            try
            {
                string fadname = Session["FADbname"].ToString();
                DataTable dtcust = new DataTable();

                if (Request.QueryString.ToString().Contains("LTinvoice"))
                {



                    supplyto = Convert.ToInt32(Request.QueryString["customerid"]);
                    customerid = Convert.ToInt32(Request.QueryString["customerid"]);
                    dtcust = objosdncn.Getcustomerledgername(fadname, customerid);
                    if (dtcust.Rows.Count > 0)
                    {
                        FALedger.Visible = true;
                        lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                    }
                    str_trantype = Request.QueryString["Strtrantype"];
                    dtcount = custobj.Getinvcountfrmcusid(customerid);
                    lbl_job.InnerText = "Due Date";
                    lbl_job.Visible = true;
                    label_vessel.InnerText = "";
                    lbl_blname.InnerText = "";
                    lbl_mblname.InnerText = "";
                    lbl_port.InnerText = "";
                    lbl_gw.InnerText = "";
                    lable_volume.InnerText = "";
                    // div_exrate.InnerText = "";
                    // lbl_head.Text = "Tax Invoice";
                    lbl_consignee.Visible = false;
                    label_shipper.Visible = false;
                    // para_notBT.Visible = false;
                    p1.Visible = true;
                    p2.Visible = true;
                    para_notBT.InnerText = "* Kindly Notify us in Writting within 10 days from invoice Date Should there be Any Discrepancy, otherwise this invoice would be deemed as Correct ";
                    p1.InnerText = "* If Payemnt made directly to our bank account or through NEFT";
                    p2.InnerText = "* Penalties for late payments are 0.75% per month Pro Rate";
                    string customername;
                    customername = custobj.GetCustomername(customerid);

                }

                if (Request.QueryString.ToString().Contains("Invoiceno"))
                {
                    invoice = Convert.ToInt32(Request.QueryString["Invoiceno"]);
                    if (Session["Basecurr"] != null)
                    {
                        th_basecurr.InnerText = Session["Basecurr"].ToString().ToUpper();
                        td_tax_basecurr.InnerText = "(" + th_basecurr.InnerText + ")";
                    }
                    if (Request.QueryString.ToString().Contains("Profoma"))
                    {

                        if (Request.QueryString["Profoma"].ToString() == "Profoma")
                        {
                            Profoma = "Profoma";
                        }
                        else
                        {
                            Profoma = "";
                        }
                    }
                    else
                    {
                        Profoma = "";
                    }

                    //DataAccess.LogDetails logobj = new DataAccess.LogDetails();
                    DateTime joudate = logobj.GetDate();
                    //lbl_currentdate.Text = joudate.ToShortDateString();
                    //lbl_cuurdate.Text = joudate.ToShortDateString();

                    lbl_invoice.Text = invoice.ToString();
                    bid = Convert.ToInt32(Session["LoginBranchid"]);
                    vouyear = Convert.ToInt32(Request.QueryString["vouyear"]);
                    if (Profoma == "Profoma")
                    {
                        dtinvoiceduedate = custobj.getdescr4proinvrpt(invoice, vouyear, bid);
                    }
                    else
                    {
                        dtinvoiceduedate = custobj.getdescr4invrpt(invoice, vouyear, bid);
                    }

                    fyear_invoice = vouyear.ToString().Substring(2, 2) + (vouyear + 1).ToString().Substring(2, 2);
                    year = vouyear.ToString().Substring(2, 2);
                    fyear = year + "-" + (Convert.ToInt32(year) + 1);

                    if (Request.QueryString.ToString().Contains("trantype"))
                    {
                        str_trantype = Request.QueryString["trantype"].ToString();
                    }
                    else
                    {
                        str_trantype = Session["StrTranType"].ToString();
                    }

                    // lbl_img.ImageUrl = "../images/montorlogo1.png";
                    if (Request.QueryString.ToString().Contains("page"))
                    {
                        page_ = Convert.ToInt32(Request.QueryString["page"]);
                        lbl_page.Text = "1 of " + (page_ + 1).ToString();
                    }
                    else
                    {
                        page_ = 1;
                        lbl_page.Text = "1 of " + (page_).ToString();
                    }


                    lbl_branch.Text = Session["LoginDivisionName"].ToString();
                    for_comapny.InnerText = lbl_branch.Text.ToUpper();

                    //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        lbl_img.ImageUrl = "data:image/png;base64," + base64String;
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
                }

                if (Request.QueryString.ToString().Contains("header"))
                {
                    Header = Request.QueryString["header"].ToString();
                    if (Header == "CN" || Header == "PA")
                    {
                        label_bill.InnerText = "Bill From";
                        label_supply.InnerText = "Supply From";
                    }
                    if (Request.QueryString["header"].ToString() == "Invoice")
                    {
                        //lbl_total.Text = Convert.ToDouble(Request.QueryString["total"]).ToString("#,0.00");
                        div_grw.Visible = true;
                        table_invoice.Visible = true;
                        //table_cn.Visible = false;

                        if (Request.QueryString.ToString().Contains("bltype"))
                        {
                            bltype = Request.QueryString["bltype"].ToString();
                            if (Profoma == "")
                            {
                                lbl_head.Text = "TAX Invoice";
                            }
                            if (bltype == "H")
                            {
                                dt = obj_inv.Getinvoicedetailsforreport(bid, str_trantype, invoice, vouyear, bltype, "Invoice", "", Profoma);
                                if (dt.Rows.Count > 0)
                                {

                                    if (!string.IsNullOrEmpty(dt.Rows[0]["preparedby"].ToString()))
                                    {
                                        div_cnops.Visible = true;
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                    }
                                    if (!string.IsNullOrEmpty(dt.Rows[0]["approvedby"].ToString()))
                                    {
                                        div_cnops.Visible = true;
                                        lbl_approved.Text = dt.Rows[0]["approvedby"].ToString();
                                    }
                                    if (Profoma == "")
                                    {
                                        lbl_total.Text = Convert.ToDouble(dt.Rows[0]["total"].ToString()).ToString("#,0.00");
                                    }

                                    DataView dv_curr = new DataView(dt);
                                    Dt_sort = dv_curr.ToTable(true, "curr");
                                    dv_curr = new DataView(Dt_sort);
                                    dv_curr.Sort = "curr";
                                    Dt_sort = dv_curr.ToTable();
                                    lbl_exrate.Text = "";
                                    for (int j = 0; j < Dt_sort.Rows.Count; j++)
                                    {
                                        DataTable dtcurr = new DataTable();
                                        DataView data_curr = dt.DefaultView;
                                        //string curr = dtnew.Rows[j]["curr"].ToString();
                                        data_curr.RowFilter = "curr='" + Dt_sort.Rows[j]["curr"].ToString() + "' and (chargename<>'ROUND UP' or  chargename<>'ROUND OFF') and curr<>'INR'";
                                        dtcurr = data_curr.ToTable();
                                        exrate = 0;//&& (dtLi.Rows[i]["chargename"].ToString() != "ROUND UP" || dtLi.Rows[i]["chargename"].ToString() != "ROUND OFF")
                                        for (int i = 0; i < dtcurr.Rows.Count; i++)
                                        {
                                            if (!string.IsNullOrEmpty(dtcurr.Rows[i]["exrate"].ToString()))
                                            {
                                                if (exrate < Convert.ToDouble(dtcurr.Rows[i]["exrate"].ToString()))
                                                {
                                                    exrate = Convert.ToDouble(dtcurr.Rows[i]["exrate"].ToString());
                                                }
                                            }
                                        }
                                        if (exrate > 0)
                                        {
                                            div_exrate.Visible = true;
                                            if (lbl_exrate.Text == "")
                                            {
                                                lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.00");
                                            }
                                            else
                                            {
                                                lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.00");
                                            }
                                        }
                                    }
                                    if (str_trantype == "CT" || str_trantype == "WH" || str_trantype == "LT")
                                    {
                                        jobno = 0;
                                        if (lbl_exrate.Text == "")
                                        {
                                            div_exrate.Visible = false;
                                        }
                                        if (str_trantype == "LT")
                                        {
                                            branch_invoice = "COR";
                                        }
                                    }
                                    else
                                    {
                                        jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                                        lbl_ourjob.Text = dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + dt.Rows[0]["trantype"].ToString().Replace("FE", "OE").Replace("FI", "OI") + " / " + dt.Rows[0]["jobno"].ToString().ToUpper();
                                        string[] branch_inv = dt.Rows[0]["shortname"].ToString().Split('-');
                                        if (branch_inv.Length > 0)
                                        {
                                            branch_invoice = branch_inv[1].ToString();
                                        }
                                    }
                                    //if (str_trantype == "LT")
                                    //{
                                    //    if (Profoma == "Profoma")
                                    //    {
                                    //        lbl_invoice.Text = invoice.ToString() + " / " + fyear;
                                    //    }
                                    //    else
                                    //    {
                                    //        lbl_invoice.Text = invoice.ToString() + " / " + fyear;
                                    //    }
                                    //}
                                    //else
                                    //{
                                    if (Profoma == "Profoma")
                                    {
                                        lbl_invoice.Text = dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + dt.Rows[0]["trantype"].ToString().Replace("FE", "OE").Replace("FI", "OI") + " / " + fyear + " / " + invoice.ToString();
                                    }
                                    else
                                    {
                                        lbl_invoice.Text = "IN" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("FE", "OE").Replace("FI", "OI") + invoice.ToString();
                                    }
                                    // }


                                    if (str_trantype == "CT" || str_trantype == "WH" || str_trantype == "LT")
                                    {
                                        jobno = 0;
                                    }
                                    else
                                    {
                                        jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                                    }

                                    if (str_trantype == "FE" || str_trantype == "FI")
                                    {
                                        lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper() + " V " + dt.Rows[0]["voyage"].ToString().ToUpper();
                                        div_pack.Visible = true;
                                    }
                                    else if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        div_pack.Visible = true;
                                        label_vessel.InnerText = "Flight";
                                        lbl_vessel.Text = dt.Rows[0]["flightno"].ToString().ToUpper() + " V " + Convert.ToDateTime(dt.Rows[0]["flightdate"].ToString()).ToString("dd/MM/yyyy");
                                    }
                                    else if (str_trantype == "CH")
                                    {
                                        div_pack.Visible = true;
                                        label_vessel.InnerText = "Vessel";
                                        lbl_vessel.Text = dt.Rows[0]["mode"].ToString().ToUpper();
                                        lbl_gw.InnerText = "Gross Wt";
                                    } if (str_trantype == "BT")
                                    {
                                        label_vessel.InnerText = "Truck #";
                                        lbl_vessel.Text = dt.Rows[0]["blno"].ToString().ToUpper();
                                        tr_cont.Visible = false;
                                        tr_contdetail.Visible = false;
                                        div_pack.Visible = true;
                                        div_bottomsign.Visible = false;
                                    }
                                    lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["invoicedate"].ToString()).ToString("dd/MM/yyyy");

                                    if (str_trantype == "CH")
                                    {
                                        lbl_blname.InnerText = "Doc #";
                                        lbl_bl.Text = dt.Rows[0]["docno"].ToString().ToUpper();
                                        lbl_mblname.InnerText = "Date";
                                        lbl_mbl.Text = dt.Rows[0]["docdate"].ToString().ToUpper();
                                        div_volume.Visible = false;
                                        div_port.Visible = false;
                                        tr_cont.Visible = false;
                                        tr_contdetail.Visible = false;

                                    }
                                    else if (str_trantype != "BT")
                                    {
                                        lbl_bl.Text = dt.Rows[0]["blno"].ToString().ToUpper();
                                    }


                                    if (str_trantype == "FE")
                                    {
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        lbl_port.InnerText = "P o D";
                                        lbl_pod.Text = dt.Rows[0]["pod"].ToString().ToUpper();
                                        lbl_mbl.Text = dt.Rows[0]["mblno"].ToString().ToUpper();
                                        lbl_igm.Visible = false;
                                        lbl_line.Visible = false;
                                        div_cont.Visible = true;

                                    }
                                    else if (str_trantype == "FI")
                                    {
                                        tr_contdetail.Attributes["class"] = "MINHeight";
                                        div_igm.Visible = true;
                                        //lbl_dt.Text = "DT :" + dt.Rows[0]["pod"].ToString();
                                        lbl_mbl.Text = dt.Rows[0]["mblno"].ToString().ToUpper() + "  " + "<strong><b>DT : </b></strong>" + Convert.ToDateTime(dt.Rows[0]["mbldate"].ToString()).ToString("dd/MM/yyyy");
                                        lbl_port.InnerText = "PoL / FD";
                                        lbl_pod.Text = dt.Rows[0]["pol"].ToString().ToUpper() + " / " + dt.Rows[0]["fd"].ToString().ToUpper();
                                        div_fiinvoice.Visible = true;
                                        lbl_igm.Visible = true;
                                        lbl_line.Visible = true;
                                        lbl_igm.Text = dt.Rows[0]["imno"].ToString().ToUpper() + " & " + Convert.ToDateTime(dt.Rows[0]["imdate"].ToString()).ToString("dd/MM/yyyy");
                                        lbl_line.Text = dt.Rows[0]["linenumber"].ToString().ToUpper() + " / " + dt.Rows[0]["sublineno"].ToString().ToUpper();
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        div_cont.Visible = true;

                                    }
                                    else if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        lbl_port.InnerText = "P o D";
                                        lbl_pod.Text = dt.Rows[0]["pod"].ToString().ToUpper();
                                        lbl_mbl.Text = dt.Rows[0]["mawblno"].ToString().ToUpper();
                                        lbl_igm.Visible = false;
                                        lbl_line.Visible = false;
                                        tr_cont.Visible = false;
                                        tr_contdetail.Visible = false;
                                    }
                                    if (str_trantype == "CH")
                                    {
                                        lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " PKG";
                                    }
                                    else if (str_trantype == "BT")
                                    {
                                        div_bl.Visible = false;
                                        div_mbl.Visible = false;
                                        div_port.Visible = false;
                                        lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString().ToUpper();
                                        lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["cbm"].ToString()).ToString("#,0.000") + " cbm";
                                    }
                                    else if (str_trantype == "CT" || str_trantype == "WH" || str_trantype == "LT")
                                    {
                                        lbl_package.Text = "";
                                    }


                                    else
                                    {

                                        lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString().ToUpper();
                                    }
                                    if (str_trantype == "CT" || str_trantype == "WH" || str_trantype == "LT")
                                    {
                                        lbl_grwt.Text = "";
                                    }
                                    else
                                    {
                                        lbl_grwt.Text = (Convert.ToDouble(dt.Rows[0]["grweight"].ToString())).ToString("#,0.00") + " Kgs";
                                    }
                                    if (str_trantype == "BT")
                                    {
                                        div_ship.Visible = false;
                                        para_notBT.Visible = false;
                                        div_bank.Visible = false;
                                        //tr_roundup.Visible = false;
                                        //tr_forround.Visible = true;
                                        tr_roundup.InnerText = "";
                                        lbl_roundup.Text = "";
                                    }
                                    else if (str_trantype == "CT" || str_trantype == "WH" || str_trantype == "LT")
                                    {
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        lbl_favouring.Text = dt.Rows[0]["favouring"].ToString().ToUpper();
                                        lbl_ifsccode.Text = dt.Rows[0]["swiftcode"].ToString().ToUpper();
                                        lbl_bankname.Text = dt.Rows[0]["bankname"].ToString().ToUpper();
                                        lbl_bankaddress.Text = dt.Rows[0]["bankaddress"].ToString().ToUpper();
                                        div_job.Visible = false;
                                        div_vessel.Visible = false;
                                        div_mbl.Visible = false;
                                        div_port.Visible = false;
                                        div_grw.Visible = false;
                                        div_volume.Visible = false;
                                        div_cont.Visible = false;
                                    }

                                    else
                                    {
                                        lbl_shipper.Text = dt.Rows[0]["shipper"].ToString().ToUpper();
                                        lbl_consignee.Text = dt.Rows[0]["consignee"].ToString().ToUpper();
                                        lbl_favouring.Text = dt.Rows[0]["favouring"].ToString().ToUpper();
                                        lbl_ifsccode.Text = dt.Rows[0]["swiftcode"].ToString().ToUpper();
                                        lbl_bankname.Text = dt.Rows[0]["bankname"].ToString().ToUpper();
                                        lbl_bankaddress.Text = dt.Rows[0]["bankaddress"].ToString().ToUpper();
                                    }



                                    if (!string.IsNullOrEmpty(dt.Rows[0]["supplyto"].ToString()))
                                    {
                                        supplyto = Convert.ToInt32(dt.Rows[0]["supplyto"].ToString());
                                    }
                                    else
                                    {
                                        supplyto = 0;
                                    }
                                    customerid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                                    dtcust = objosdncn.Getcustomerledgername(fadname, customerid);
                                    if (dtcust.Rows.Count > 0)
                                    {
                                        FALedger.Visible = true;
                                        lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                                    }
                                    lbl_remarks.Text = dt.Rows[0]["remarks"].ToString().ToUpper().ToUpper();

                                    if (str_trantype == "FE" || str_trantype == "FI")
                                    {
                                        jobtype = dt.Rows[0]["jobtype"].ToString().ToUpper();
                                        if (jobtype != "")
                                        {
                                            if (jobtype == "3")
                                            {
                                                lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                            }
                                            else
                                            {
                                                volume = Convert.ToDouble(dt.Rows[0]["cbm"].ToString());
                                                lbl_volume.Text = volume.ToString("#,0.000");
                                            }
                                        }

                                    }
                                    if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        lable_volume.InnerText = "Charge Wght";
                                        lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["chargewt"].ToString()).ToString("#,0.000") + " Kgs";
                                    }
                                }
                            }
                        }

                        //Container
                        if (str_trantype != "CH" || str_trantype != "AE" || str_trantype != "AI" || str_trantype != "BT")
                        {
                            if (Request.QueryString.ToString().Contains("bltype"))
                            {
                                bltype = Request.QueryString["bltype"].ToString();
                            }
                            if (bltype == "H")
                            {
                                if (Request.QueryString.ToString().Contains("blno"))
                                {
                                    blno = Request.QueryString["blno"].ToString().ToUpper();
                                    if (blno == "")
                                    {
                                        blno = lbl_bl.Text.ToUpper();
                                    }
                                }
                            }
                            else
                            {
                                blno = "";
                            }


                            dt = obj_inv.get_containerdetails(jobno, bid, blno, str_trantype, bltype);
                            if (Request.QueryString.ToString().Contains("cont_count"))
                            {
                                cont_count = Convert.ToInt32(Request.QueryString["cont_count"].ToString());
                            }
                            else
                            {
                                cont_count = 0;
                            }
                            cont_ = 0;
                            if (dt.Rows.Count > 4)
                            {
                                //div_cont.Attributes["class"] = "div_cont_overide";
                                cont_ = dt.Rows.Count;
                                _line = Convert.ToInt32(dt.Rows.Count / 4);
                                _line -= 2;
                            }
                            for (int i = cont_count; i < dt.Rows.Count; i++)
                            {
                                if (i == cont_count + 0)
                                {
                                    lstcon.Text += dt.Rows[i][0].ToString().ToUpper() + "/" + dt.Rows[i][2].ToString().ToUpper() + "/" + dt.Rows[i][1].ToString().ToUpper();
                                }
                                else
                                {
                                    lstcon.Text += ", " + dt.Rows[i][0].ToString().ToUpper() + "/" + dt.Rows[i][2].ToString().ToUpper() + "/" + dt.Rows[i][1].ToString().ToUpper();
                                }
                            }
                        }

                        dt = obj_inv.Getinvoicedetailsgrid(invoice, bid, vouyear, str_trantype, Profoma);

                        if (Request.QueryString.ToString().Contains("count"))
                        {
                            count = Convert.ToInt32(Request.QueryString["count"]);
                        }
                        else
                        {
                            count = 0;
                        }

                        if (dt.Rows.Count > 0)
                        {
                            if (Profoma == "Profoma")
                            {
                                total = 0;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    total += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                                }
                                lbl_total.Text = Convert.ToDouble(total).ToString("#,0.00");
                            }
                            html = "";
                            for (int i = count; i < dt.Rows.Count; i++)
                            {
                                //i = count;
                                tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                                //if (str_trantype == "LT")
                                //{
                                //    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:300px;'>" + dtinvoiceduedate.Rows[i]["descr"].ToString().ToUpper() + "</label></td>";
                                //}
                                //else
                                //{

                                //}
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:300px;'>" + dt.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                //if (str_trantype == "LT")
                                //{
                                //    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '></label></td>";
                                //}
                                //else
                                //{
                                //    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dt.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                //}
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dt.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                if (str_trantype == "LT")
                                {
                                    if (dt.Columns.Contains("invgencount"))
                                    {
                                        if (dtcount.Rows[0]["invgencount"].ToString() == "1")
                                        {
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;width:105px; text-align:center;'><label style='display:inline-block;'>" + "1" + "</label><label style='display:inline-block; float:right; text-align:right;'></label></td>";
                                        }
                                        else if (dtinvoiceduedate.Rows[0]["descr"].ToString().Substring(0, 8) == "ONE TIME" || dtinvoiceduedate.Rows[0]["descr"].ToString().Substring(0, 8) == "ANDROID ")
                                        {
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;width:105px; text-align:center;'><label style='display:inline-block;'>" + "1" + "</label><label style='display:inline-block; float:right; text-align:right;'></label></td>";
                                        }
                                        else
                                        {
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;width:105px; text-align:center;'><label style='display:inline-block;'>" + Convert.ToInt32(dt.Rows[i]["unit"]) + "</label><label style='display:inline-block; float:right; text-align:right;'></label></td>";

                                        }
                                    }
                                    else
                                    {
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;width:105px; text-align:center;'><label style='display:inline-block;'>" + Convert.ToInt32(dt.Rows[i]["unit"]) + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                    }
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;width:105px; text-align:center;'><label style='display:inline-block;'>" + Convert.ToInt32(dt.Rows[i]["unit"]) + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                }
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;width:100px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["Actamount"].ToString().ToUpper()))
                                {
                                    temp_taxable += Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper());
                                    tr_row.Text += "<td style='color:#2c2b2b; width: 100px; text-align:right; padding:0px 2px 0px 0px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#2c2b2b; width: 100px; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;' align='right'>" + dt.Rows[i]["CGSTP"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["cgsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                    cgsta += Convert.ToDouble(dt.Rows[i]["cgsta"].ToString());
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black; text-align:right;'>" + dt.Rows[i]["sgstp"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["sgsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                    sgsta += Convert.ToDouble(dt.Rows[i]["sgsta"].ToString());
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;' align='right'>" + dt.Rows[i]["igstp"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["igsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dt.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                    igsta += Convert.ToDouble(dt.Rows[i]["igsta"].ToString());
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dt.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";

                            }
                            //1 line space
                            tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                            //Description
                            tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 20px; width:300px;'>[" + dtinvoiceduedate.Rows[0]["descr"].ToString().ToUpper() + "]</label></td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                            if (div_cont.Visible == true)
                            {
                                if (div_ship.Visible == false)
                                {
                                    for (int i = dt.Rows.Count + _line; i < 31; i++)
                                    {
                                        tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                    }
                                }
                                else
                                {
                                    for (int i = dt.Rows.Count + _line; i < 27; i++)
                                    {
                                        tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                    }
                                }
                            }
                            else
                            {
                                if (str_trantype == "BT")
                                {
                                    for (int i = dt.Rows.Count; i < 46; i++)
                                    {
                                        tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                    }
                                }
                                else
                                {
                                    if (div_ship.Visible == false)
                                    {
                                        for (int i = dt.Rows.Count; i < 34; i++)
                                        {
                                            tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                        }
                                    }
                                    else
                                    {
                                        if (str_trantype == "CT" || str_trantype == "WH" || str_trantype == "LT")
                                        {
                                            for (int i = dt.Rows.Count; i < 23; i++)
                                            {
                                                tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                            }
                                        }
                                        else
                                        {
                                            for (int i = dt.Rows.Count; i < 31; i++)
                                            {
                                                tr_row.Text += " <tr style='background-color:#d0d0d0'>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                tr_row.Text += "<td style='color:#2c2b2b; padding:0px 2px 0px 0px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                            }
                                        }

                                    }
                                }
                            }



                            if (obj_inv.Getinvoiceservicetax(invoice, bid, vouyear, "ROUND UP", Header, Profoma) != null)
                            {
                                tax = obj_inv.Getinvoiceservicetax(invoice, bid, vouyear, "ROUND UP", Header, Profoma);
                            }
                            if (obj_inv.Getinvoiceservicetax(invoice, bid, vouyear, "ROUND OFF", Header, Profoma) != null)
                            {
                                tax1 = obj_inv.Getinvoiceservicetax(invoice, bid, vouyear, "ROUND OFF", Header, Profoma);
                            }
                            if (str_trantype != "BT")
                            {
                                if (tax > 0 || tax > 0.00)
                                {
                                    lbl_roundup.Text = tax.ToString("#,0.00");
                                }
                                if (tax1 < 0 || tax1 < 0.00)
                                {
                                    lbl_roundup.Text = tax1.ToString("#,0.00");
                                }
                            }
                            //td_taxableamt.InnerText = temp_taxable.ToString("#,0.00");
                            //td_cgsta.InnerText = cgsta.ToString("#,0.00");
                            //td_sgsta.InnerText = sgsta.ToString("#,0.00");
                            //td_igsta.InnerText = igsta.ToString("#,0.00");
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
                        }

                        if (str_trantype != "FI")
                        {
                            div_between.Visible = false;
                        }

                    }

                    if (Header != "CN")
                    {
                        if (obj_inv.Getinvoiceservicetax(invoice, bid, vouyear, "ROUND UP", Header, Profoma) != null)
                        {
                            tax = obj_inv.Getinvoiceservicetax(invoice, bid, vouyear, "ROUND UP", Header, Profoma);
                        }
                        if (obj_inv.Getinvoiceservicetax(invoice, bid, vouyear, "ROUND OFF", Header, Profoma) != null)
                        {
                            tax1 = obj_inv.Getinvoiceservicetax(invoice, bid, vouyear, "ROUND OFF", Header, Profoma);
                        }
                        if (str_trantype != "BT")
                        {
                            if (tax > 0)
                            {
                                lbl_roundup.Text = tax.ToString("#,0.00");
                                div_round.InnerText = "ROUND UP";
                            }
                            else if (tax1 < 0)
                            {
                                lbl_roundup.Text = tax1.ToString("#,0.00");
                                div_round.InnerText = "ROUND OFF";
                            }
                            else
                            {
                                div_round.InnerText = "       ";
                            }
                        }
                    }
                    else
                    {
                        div_round.InnerText = "       ";
                    }
                    double price1; bool isDouble2;
                    if (customertype == "P")
                    {
                        isDouble2 = Double.TryParse(total_agent.Text, out price1);

                    }
                    else
                    {
                        isDouble2 = Double.TryParse(lbl_total.Text, out price1);
                    }

                    if (isDouble2)
                    {
                        //lbl_currword.Text = th_basecurr.InnerText + "  " + ConvertNumbertoWords(Convert.ToInt32(price1)) + " ONLY";
                        //lbl_currword.Text = lbl_currword.Text.ToUpper();

                        if (customertype == "P")
                        {
                            if (curr_count == 1)
                            {
                                if (currency == "")
                                {
                                    //lbl_currword.Text = "USD" + "  : " + conversion(total_agent.Text, "") + " ONLY";
                                }
                                else
                                {
                                    lbl_taxcurr.InnerText = "(" + currency + ")";
                                    th_curr.InnerText = "(" + currency + ")";
                                    lbl_currword.Text = currency + "  : " + conversion(total_agent.Text, "") + " ONLY";
                                }
                            }
                            else
                            {
                                lbl_currword.Text = "USD" + "  : " + conversion(total_agent.Text, "") + " ONLY";
                            }

                        }
                        else
                        {
                            lbl_currword.Text = th_basecurr.InnerText + "  : " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                        }
                    }


                }



                DataTable dt1 = new DataTable();
                dt1 = custobj.Get_customerdetails(customerid);
                if (dt1.Rows.Count > 0)
                {

                    lbl_toaddress.Text += dt1.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                    if (!string.IsNullOrEmpty(dt1.Rows[0]["address"].ToString()))
                    {
                        lbl_toaddress.Text += dt1.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                    }

                    if (!string.IsNullOrEmpty(dt1.Rows[0]["Location"].ToString()))
                    {
                        lbl_toaddress.Text += dt1.Rows[0]["Location"].ToString().ToUpper() + " ,";
                    }
                    if (!string.IsNullOrEmpty(dt1.Rows[0]["portname"].ToString()))
                    {
                        lbl_toaddress.Text += dt1.Rows[0]["portname"].ToString().ToUpper();
                    }
                    if (!string.IsNullOrEmpty(dt1.Rows[0]["zip"].ToString()))
                    {
                        lbl_toaddress.Text += " - " + dt1.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                    }
                    else
                    {
                        lbl_toaddress.Text += "<br />";
                    }

                    if (!string.IsNullOrEmpty(dt1.Rows[0]["districtname"].ToString()))
                    {
                        lbl_toaddress.Text += dt1.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                    }
                    if (!string.IsNullOrEmpty(dt1.Rows[0]["statename"].ToString()))
                    {
                        lbl_toaddress.Text += dt1.Rows[0]["statename"].ToString().ToUpper() + ". " + "<br />";
                    }
                    if (!string.IsNullOrEmpty(dt1.Rows[0]["ptc"].ToString()))
                    {
                        lbl_toaddress.Text += "<strong>PTC :</strong>" + dt1.Rows[0]["ptc"].ToString().ToUpper() + " ";
                    }
                    if (!string.IsNullOrEmpty(dt1.Rows[0]["phone"].ToString()))
                    {
                        lbl_toaddress.Text += "<strong>PH :</strong>" + dt1.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                    }

                    div_gst.InnerText = dt1.Rows[0]["gstin"].ToString().ToUpper().ToUpper();
                    gst_state.InnerText = dt1.Rows[0]["statename"].ToString().ToUpper();
                    gst_code.InnerText = dt1.Rows[0]["gstcode"].ToString().ToUpper();
                }

                if (supplyto != 0)
                {
                    dt1 = custobj.Get_customerdetails(supplyto);
                    if (dt1.Rows.Count > 0)
                    {

                        lbl_tosupply.Text += dt1.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["address"].ToString()))
                        {
                            lbl_tosupply.Text += dt1.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt1.Rows[0]["Location"].ToString()))
                        {
                            lbl_tosupply.Text += dt1.Rows[0]["Location"].ToString().ToUpper() + " ,";
                        }
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["portname"].ToString()))
                        {
                            lbl_tosupply.Text += dt1.Rows[0]["portname"].ToString().ToUpper();
                        }
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["zip"].ToString()))
                        {
                            lbl_tosupply.Text += " - " + dt1.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                        }
                        else
                        {
                            lbl_tosupply.Text += "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt1.Rows[0]["districtname"].ToString()))
                        {
                            lbl_tosupply.Text += dt1.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                        }
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["statename"].ToString()))
                        {
                            lbl_tosupply.Text += dt1.Rows[0]["statename"].ToString().ToUpper() + ". ";
                        }
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["ptc"].ToString()))
                        {
                            lbl_tosupply.Text += "<strong>PTC :</strong>" + dt1.Rows[0]["ptc"].ToString().ToUpper() + " ";
                        }
                        if (!string.IsNullOrEmpty(dt1.Rows[0]["phone"].ToString()))
                        {
                            lbl_tosupply.Text += "<strong>PH :</strong>" + dt1.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        }

                        div_supplygst.InnerText = dt1.Rows[0]["gstin"].ToString().ToUpper().ToUpper();
                        div_supplystate.InnerText = dt1.Rows[0]["statename"].ToString().ToUpper();
                        div_supplycode.InnerText = dt1.Rows[0]["gstcode"].ToString().ToUpper();
                    }
                }
                if (str_trantype == "LT")
                {
                    lbl_img.Visible = false;
                    div_remarks.Visible = false;
                    //div_exrate.Visible = true;
                    // lbl_exrate.Visible = true;
                    lbl_bl.Text = "";
                    lbl_date.Text = Convert.ToDateTime(dtinvoiceduedate.Rows[0]["invgendate"].ToString()).ToString("dd/MM/yyyy");
                    lbl_ourjob.Visible = true;
                    lbl_job.Visible = true;
                    div_job.Visible = true;
                    lbl_ourjob.Text = Convert.ToDateTime(dtinvoiceduedate.Rows[0]["duedate"].ToString()).ToString("dd/MM/yyyy");
                    // div_consignee.Visible = false;
                    string invmonth;
                    invmonth = Convert.ToDateTime(dtinvoiceduedate.Rows[0]["invgendate"].ToString()).ToString("MMM-yy");
                    lbl_consignee.Visible = true;
                    label_Consignee.Visible = false;
                   
                    lbl_consignee.Text = dtinvoiceduedate.Rows[0]["descr"].ToString();
                   
                    div_shipper.Visible = false;
                    if (Request.QueryString.ToString().Contains("total"))
                    {
                        double total1 = Convert.ToDouble(Request.QueryString["total"]);
                        lbl_total.Text = total1.ToString("#,0.00");
                    }
                    else
                    {
                        if (lbl_roundup.Text != "")
                        {
                            lbl_total.Text = (Convert.ToDouble(lbl_total.Text) + Convert.ToDouble(lbl_roundup.Text)).ToString("#,0.00");
                        }
                    }
                }
                //div_sign.Visible = false;
                //div_authorised.Visible = true;
                if (Profoma == "Profoma")
                {
                    label_invoice.InnerText = "Refno #";
                    div_approve.Visible = false;
                }
                //   div_job.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

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
                Content = beforefloating + ' ' + " RUPEES" + ' ' + afterfloating + ' ' + " PAISE";
            }
            else
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " DOLLARS " + ' ' + afterfloating + ' ' + "CENTS";
            }
            return Content;
        }

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
                words += ConvertNumbertoWordsINR(number / 100000) + " LAKHS ";
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




    }
}