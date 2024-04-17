using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Runtime.Remoting;
namespace logix.Reportasp
{
    public partial class OverseasVouchersrpt : System.Web.UI.Page
    {
        int len_ = 0;
        string blno = "";
        int invoice, bid, vouyear, count, cont_count, cont_, _line, page_;
        int row_count = 0;
        string[] branch_inv;
        string str_trantype = "";
        int jobno = 0;
        string fyear;
        string bltype;
        string str_Script = "";
        double exrate = 0;
        DataTable Dt_sort = new DataTable();
        DataTable Dt_tds = new DataTable();
        DataTable DT_cont = new DataTable();
        double total = 0;
        DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.OSDNCN obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataTable dtadd = new DataTable();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        int DCNo, branchid, refno, supplyto, customerid;
        string type, Profoma, fyear_invoice, branch_invoice, customertype;
        double temp_taxable, cgsta, sgsta, igsta;
        string year, currency;
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Payment objpay = new DataAccess.Accounts.Payment();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.OSDNCN objosdncn = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DateTime datenow;
        string titlename = "";
        string portcode = "";
        DataAccess.Documents objnewdoc = new DataAccess.Documents();
        DataAccess.LogDetails logobj1 = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        protected void Page_Load(object sender, EventArgs e)
        {
           


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Log.GetDataBase(Ccode);
                obj_inv.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                objosdncn.GetDataBase(Ccode);
                obj_OSDNCN.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);

                objnewdoc.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                objpay.GetDataBase(Ccode);
                logobj1.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);

            }
            try
            {


                if (Session["LoginBranchid"] != null)
                {
                    portcode = portobj.GetPortCodeportid(Convert.ToInt32(Session["LoginBranchid"]));
                    portcode = portcode.Substring(2, 3);
                }



                if (Request.QueryString.ToString().Contains("refno"))
                {
                    str_trantype = Request.QueryString["tran"];
                    if (str_trantype == "FE")
                    {
                        Session["StrTranTypeO"] = "OE";
                    }
                    else if (str_trantype == "FI")
                    {
                        Session["StrTranTypeO"] = "OI";
                    }
                    else
                    {
                        Session["StrTranTypeO"] = str_trantype;
                    }
                    if (Request.QueryString.ToString().Contains("bltype"))
                    {
                        bltype = Request.QueryString["bltype"].ToString();
                    }

                    if (Request.QueryString.ToString().Contains("titlename"))
                    {
                        titlename = "Interbranchvouchertransfer";
                    }
                    datenow = logobj1.GetDate();

                    if (bltype == "ProOSSI")
                    {
                        table_invoice.Visible = true;
                        //table_agent.Visible = false;
                        //if (str_trantype == "OE" || str_trantype == "AE" || str_trantype == "OE" || str_trantype == "AE")
                        //{
                        lbl_head.Text = "Proforma Tax Invoice";
                        //}
                        //else if (str_trantype == "OI" || str_trantype == "AI")
                        //{
                        //    lbl_head.Text = "Proforma Income Booking Voucher";
                        //}
                        label_bill.InnerText = "Bill To";
                        label_supply.InnerText = "Supply To";
                        DIVIRN.Visible = false;
                        divqr.Visible = false;
                    }
                    else if (bltype == "ProOSPI")
                    {
                        //table_invoice.Visible = false;
                        //table_agent.Visible = true;


                        //lbl_head.Text = "Proforma Overseas Credit Note";

                        //if (str_trantype == "OE" || str_trantype == "AE")
                        //{
                        lbl_head.Text = "Proforma Overseas Credit Note";
                        DIVIRN.Visible = false;
                        divqr.Visible = false;
                        //}
                        //else if (str_trantype == "OI" || str_trantype == "AI")
                        //{
                        //    lbl_head.Text = "Proforma Expenses Booking Voucher";
                        //}


                    }
                    else if (bltype == "OSSI")
                    {
                        table_invoice.Visible = true;
                        //table_agent.Visible = false;
                        //  DIVIRN.Visible = true;
                        DIVIRN.Visible = false;
                        divqr.Visible = false;
                        //  lbl_head.Text = "Overseas Debit Note";
                        //if (str_trantype == "OE" || str_trantype == "AE")
                        //{
                        lbl_head.Text = "OVERSEAS INVOICE";
                        //}
                        //else if (str_trantype == "OI" || str_trantype == "AI")
                        //{
                        //    lbl_head.Text = "Income Booking Voucher";
                        //}

                        label_bill.InnerText = "Bill To";
                        label_supply.InnerText = "Supply To";
                    }
                    else if (bltype == "OSPI")
                    {
                        DIVIRN.Visible = false;
                        divqr.Visible = false;
                        //table_invoice.Visible = false;
                        //table_agent.Visible = true;
                        // lbl_head.Text = "Overseas Credit Note";

                        //if (str_trantype == "OE" || str_trantype == "AE")
                        //{
                        lbl_head.Text = "Overseas Credit Note";
                        //}
                        //else if (str_trantype == "OI" || str_trantype == "AI")
                        //{
                        //    lbl_head.Text = "Expenses Booking Voucher";
                        //}
                    }
                    // Einvoice newly added satrt//

                    //if (Profoma == "")
                    //{
                    DataTable dtnew1 = new DataTable();
                    string img1 = "";
                    if (bltype == "OSSI")
                    {
                        dtnew1 = objnewdoc.getdetails4gstdetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Request.QueryString["refno"].ToString()), Convert.ToInt32(Request.QueryString["vouyear"].ToString()), "D");
                        if (dtnew1.Rows.Count > 0)
                        {
                            DIVIRN.Visible = true;
                            divqr.Visible = true;
                            //  div_image1.Visible = true;
                            //    div_irn.Visible = true;
                            LblIrnno.Text = dtnew1.Rows[0][0].ToString();

                            ImgLogo.ImageUrl = "https://my.gstzen.in" + dtnew1.Rows[0][1].ToString();

                            //new240721
                            if (!string.IsNullOrEmpty(dtnew1.Rows[0][2].ToString()))
                            {
                                LblAckno.Text = dtnew1.Rows[0][2].ToString();
                            }
                            if (!string.IsNullOrEmpty(dtnew1.Rows[0][3].ToString()))
                            {
                                LblAckdt.Text = Convert.ToDateTime(dtnew1.Rows[0][3].ToString()).ToString("dd/MM/yyyy HH:mm");
                            }
                        }
                        else
                        {
                            //     div_irn.Visible = false;
                            //     div_image1.Visible = false;


                        }

                    }




                    // }

                    jobno = Convert.ToInt32(Request.QueryString["jobno"]);
                    invoice = Convert.ToInt32(Request.QueryString["refno"]);
                    lbl_invoice.Text = invoice.ToString();
                  //  DataAccess.LogDetails logobj = new DataAccess.LogDetails();
                    DateTime joudate = logobj.GetDate();
                    lbl_invoice.Text = invoice.ToString();
                    bid = Convert.ToInt32(Session["LoginBranchid"]);
                    if (titlename == "Interbranchvouchertransfer" && bid == 40)
                    {
                        bid = Convert.ToInt32(Request.QueryString["branch"]);
                    }
                    vouyear = Convert.ToInt32(Request.QueryString["vouyear"]);
                    year = vouyear.ToString().Substring(2, 2);
                    fyear_invoice = vouyear.ToString().Substring(2, 2) + (Convert.ToInt32(year) + 1);
                    fyear = year + "-" + (Convert.ToInt32(year) + 1);
                    if (Session["Basecurr"] != null)
                    {
                        //th_basecurr.InnerText = Session["Basecurr"].ToString().ToUpper();
                        //td_tax_basecurr.InnerText = "(" + th_basecurr.InnerText + ")";
                    }

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

                  //  DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                    }


                    lbl_branch.Text = Session["LoginDivisionName"].ToString();


                    dtadd = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    {
                        lbl_add.Text = dtadd.Rows[0]["address"].ToString().ToUpper();
                        lbl_ph.Text = dtadd.Rows[0]["phone"].ToString().ToUpper();
                        lbl_fax.Text = dtadd.Rows[0]["fax"].ToString().ToUpper();
                        lbl_st.Text = dtadd.Rows[0]["gstin"].ToString().ToUpper();
                        lbl_pan.Text = dtadd.Rows[0]["panno"].ToString().ToUpper();
                        lbl_cin.Text = dtadd.Rows[0]["cinno"].ToString().ToUpper();
                        byte[] signimageBytes = ((byte[])dtadd.Rows[0]["sisign"]);
                        string base64Strings = Convert.ToBase64String(signimageBytes);
                        img_sign.ImageUrl = "data:image/png;base64," + base64Strings;
                    }

                    dt = objosdncn.GetOsdncnforreportOSV(jobno, Session["StrTranTypeO"].ToString(), bltype, vouyear, invoice, bid);

                    if (dt.Rows.Count > 0)
                    {
                        div_cnops.Visible = true;
                        div_vendorref.Visible = true;
                        lbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();
                        if (bltype == "ProOSPI")
                        {
                            div_vendorrefdate.Visible = true;
                            if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                            {
                                lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                            }
                            else
                            {
                                lbl_vendordate.Text = "";
                            }
                        }
                        else if (bltype == "OSPI")
                        {
                            div_vendorrefdate.Visible = true;
                            if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                            {
                                lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                            }
                            else
                            {
                                lbl_vendordate.Text = "";
                            }
                        }


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (string.IsNullOrEmpty(dt.Rows[i]["fcamt"].ToString()) != true)
                            {
                                total += Convert.ToDouble(dt.Rows[i]["fcamt"].ToString());
                            }
                            else
                            {
                                total += 0;
                            }

                        }


                        lbl_total.Text = Convert.ToDouble(total).ToString("#,0.00");
                        //total_agent.Text = Convert.ToDouble(total).ToString("#,0.00");
                        if (!string.IsNullOrEmpty(dt.Rows[0]["supplyto"].ToString()))
                        {
                            supplyto = Convert.ToInt32(dt.Rows[0]["supplyto"].ToString());
                        }
                        else
                        {
                            supplyto = 0;
                        }

                        customerid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                        string fadname = Session["FADbname"].ToString();
                        DataTable dtcust = new DataTable();

                        dtcust = objosdncn.Getcustomerledgername(fadname, customerid);
                        if (dtcust.Rows.Count > 0)
                        {
                            FALedger.Visible = true;
                            lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                        }
                        lbl_job.InnerText = "Job #";
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
                            exrate = 0;//&& (dt.Rows[i]["chargename"].ToString() != "ROUND UP" || dt.Rows[i]["chargename"].ToString() != "ROUND OFF")
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
                            }
                        }
                        //if (Dt_sort.Rows.Count > 1 || Dt_sort.Rows.Count == 0)
                        //{
                        //    currency = "USD";
                        //    th_basecurr.InnerText = currency;
                        //    td_tax_basecurr.InnerText = "(" + currency + ")";
                        //    //th_curr.InnerText = "(" + currency + ")";
                        //}
                        //else if (Dt_sort.Rows.Count == 1)
                        //{
                        //    currency = Dt_sort.Rows[0]["curr"].ToString();
                        //    th_basecurr.InnerText = currency;
                        //    td_tax_basecurr.InnerText = "(" + currency + ")";
                        //    //th_curr.InnerText = "(" + currency + ")";
                        //}
                        if (Dt_sort.Rows.Count >0)
                        {
                            currency = Dt_sort.Rows[0]["curr"].ToString().ToUpper();
                            td_tax_basecurr.InnerText = "(" + currency + ")";
                            th_basecurr.InnerText = currency;
                        }

                        jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                        string jobno1 = dt.Rows[0]["jobnotrantype"].ToString();
                        //lbl_ourjob.Text = jobno1.ToString();
                        //label_branch.InnerText = "for " + dt.Rows[0]["branchname"].ToString().ToUpper();

                        if (str_trantype == "OE")
                        {
                            lbl_ourjob.Text = "OCEAN EXPORT/" + jobno;
                        }
                        if (str_trantype == "OI")
                        {
                            lbl_ourjob.Text = "OCEAN IMPORT/" + jobno;
                        }
                        if (str_trantype == "AE")
                        {
                            lbl_ourjob.Text = "AIR EXPORT/" + jobno;
                        }
                        else
                        {
                            lbl_ourjob.Text = "AIR IMPORT/" + jobno;
                        }

                        if (Session["StrTranTypeO"].ToString() == "OE" || Session["StrTranTypeO"].ToString() == "OI")
                        {
                            div_vessel.Visible = true;
                            if (bltype == "ProOSSI" || bltype == "ProOSPI" || bltype == "OSSI")
                            {
                                label_vessel.InnerText = "Vessel";
                                if (dt.Rows[0]["vesselname"] != null && string.IsNullOrEmpty(dt.Rows[0]["vesselname"].ToString()))
                                {
                                    lbl_vessel.Text += dt.Rows[0]["vesselname"].ToString().ToUpper() + " V ";
                                }
                                lbl_vessel.Text += dt.Rows[0]["voyage"].ToString().ToUpper();
                            }
                            else if (bltype == "OSPI")
                            {
                                label_vessel.InnerText = "Vessel";
                                lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper();
                            }
                            lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString().ToUpper();
                            lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString().ToUpper();
                        }
                        else if (str_trantype == "AE" || str_trantype == "AI")
                        {
                            div_vessel.Visible = true;
                            if (bltype == "ProOSSI" || bltype == "ProOSPI" || bltype == "OSSI")
                            {
                                label_vessel.InnerText = "Flight";
                                //div_pack.Visible = true;
                                if (dt.Rows[0]["flightno"] != null && string.IsNullOrEmpty(dt.Rows[0]["flightno"].ToString()))
                                {
                                    lbl_vessel.Text += dt.Rows[0]["flightno"].ToString().ToUpper() + " / ";

                                }
                                lbl_vessel.Text += Convert.ToDateTime(dt.Rows[0]["flightdate"].ToString()).ToString("dd-MMM-yyyy");
                            }
                            else if (bltype == "OSPI")
                            {
                                label_vessel.InnerText = "Flight";
                                lbl_vessel.Text = dt.Rows[0]["flightno"].ToString().ToUpper();
                            }
                            lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString().ToUpper();
                            lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString().ToUpper();

                        }

                        else if (str_trantype == "CH")
                        {
                            div_vessel.Visible = false;
                            lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString().ToUpper();
                            lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString().ToUpper();
                        }
                        if (dt.Rows[0]["shortname"].ToString().Length > 0)
                        {
                            branch_inv = dt.Rows[0]["shortname"].ToString().Split('-');
                            if (branch_inv.Length > 0)
                            {
                                branch_invoice = branch_inv[1].ToString();
                            }
                        }
                        if (bltype == "ProOSSI" || bltype == "ProOSPI")
                        {
                            label_invoice.InnerText = "Ref #";
                        }
                        else if (bltype == "OSSI")
                        {
                            label_invoice.InnerText = "DN #";
                        }
                        else if (bltype == "OSPI")
                        {
                            label_invoice.InnerText = "CN #";
                        }

                        string invno = "";
                        if (bltype == "OSSI")
                        {
                            invno = dt.Rows[0]["vouno"].ToString();
                        }
                        else if (bltype == "OSPI")
                        {
                            invno = dt.Rows[0]["vouno"].ToString();
                        }
                        else if (bltype == "ProOSSI" || bltype == "ProOSPI")
                        {
                            invno = dt.Rows[0]["refno"].ToString();
                        }

                        DataTable dtnew = new DataTable();
                        int dnno;
                        if (bltype == "OSSI" || bltype == "OSPI")
                        {
                            //div_consig_ship.Visible = true;


                            if (bltype == "OSSI")
                            {
                                dnno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString().ToUpper());
                                dtnew = obj_inv.GetOsdncnforreportshippercosignee(bid, str_trantype, dnno, vouyear, bltype);

                            }
                            else if (bltype == "OSPI")
                            {
                                dnno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString().ToUpper());
                                dtnew = obj_inv.GetOsdncnforreportshippercosignee(bid, str_trantype, dnno, vouyear, bltype);

                            }




                            if (dtnew.Rows.Count > 0)
                            {
                                Lbl_shippername.Text = dtnew.Rows[0]["shipper"].ToString().ToUpper();
                                Lbl_consignee.Text = dtnew.Rows[0]["consignee"].ToString().ToUpper();
                                hdnlbl_bl.Value = dtnew.Rows[0]["blno"].ToString().ToUpper();

                                //if (hdnlbl_bl.Value != "")
                                //{
                                //    dtnew1 = obj_inv.get_OSDNCNgrwt(hdnlbl_bl.Value, bid, Convert.ToInt32(Session["LoginDivisionId"]), str_trantype);
                                //}
                                //if (dtnew1.Rows.Count > 0)
                                //{
                                ////div_grw.Visible = true;
                                ////div_volume.Visible = true;
                                //Lbl_grwt.Text = dtnew1.Rows[0]["grosswt"].ToString().ToUpper() + " Kgs";
                                //Lbl_chargewt.Text = dtnew1.Rows[0]["ntweight"].ToString().ToUpper() + " Kgs";
                                //}
                                //lbl_grwt.Text =
                            }
                            dnno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString().ToUpper());
                            DataTable dataTable = new DataTable();
                            dataTable = obj_inv.Getspgetosdncngrwtntwt(bid, str_trantype, dnno, vouyear, bltype);
                            if (dataTable.Rows.Count > 0)
                            {
                                dataTable = obj_inv.Getspgetosdncngrwtntwt(bid, str_trantype, dnno, vouyear, bltype);
                                Lbl_grwt.Text = dataTable.Rows[0]["grosswt"].ToString().ToUpper();
                                Lbl_chargewt.Text = dataTable.Rows[0]["ntweight"].ToString().ToUpper();
                            }
                            //else
                            //{
                            //    div_consig_ship.Visible = false;
                            //}

                        }
                        else if (bltype == "ProOSSI" || bltype == "ProOSPI")
                        {
                            dnno = Convert.ToInt32(dt.Rows[0]["refno"].ToString().ToUpper());
                            dtnew = obj_inv.GetOsdncnforreportshippercosignee(bid, str_trantype, dnno, vouyear, bltype);


                            if (dtnew.Rows.Count > 0)
                            {
                                Lbl_shippername.Text = dtnew.Rows[0]["shipper"].ToString().ToUpper();
                                Lbl_consignee.Text = dtnew.Rows[0]["consignee"].ToString().ToUpper();
                                hdnlbl_bl.Value = dtnew.Rows[0]["blno"].ToString().ToUpper();

                                //    if (hdnlbl_bl.Value != "")
                                //    {
                                //        dtnew1 = obj_inv.get_OSDNCNgrwt(hdnlbl_bl.Value, bid, Convert.ToInt32(Session["LoginDivisionId"]), str_trantype);
                                //    }
                                //    if (dtnew1.Rows.Count > 0)
                                //    {
                                //        //    div_grw.Visible = true;
                                //        //    div_volume.Visible = true;
                                //        Lbl_grwt.Text = dtnew1.Rows[0]["grosswt"].ToString().ToUpper() + " Kgs";
                                //        Lbl_chargewt.Text = dtnew1.Rows[0]["ntweight"].ToString().ToUpper() + " Kgs";
                                //    }
                                //}

                            }
                            dnno = Convert.ToInt32(dt.Rows[0]["refno"].ToString().ToUpper());
                            DataTable dataTable = new DataTable();
                            
                            dataTable = obj_inv.Getspgetosdncngrwtntwt(bid, str_trantype, dnno, vouyear, bltype);
                            if (dataTable.Rows.Count > 0)
                            {
                                Lbl_grwt.Text = dataTable.Rows[0]["grosswt"].ToString().ToUpper();
                                Lbl_chargewt.Text = dataTable.Rows[0]["ntweight"].ToString().ToUpper();
                            }
                            //else
                            //{
                            //    div_consig_ship.Visible = false;
                            //}
                            //invno= dt.Rows[0]["pano"].ToString();
                            // panno =Convert.ToInt32(dt.Rows[0]["pano"].ToString());
                        }
                        if (invno.Length == 1)
                        {
                            invno = "0000";
                        }
                        else if (invno.Length == 2)
                        {
                            invno = "000";
                        }
                        else if (invno.Length == 3)
                        {
                            invno = "00";
                        }
                        else if (invno.Length == 4)
                        {
                            invno = "0";
                        }
                        else
                        {
                            invno = "";
                        }
                        DateTime da;
                        da = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString());
                        if (dt.Rows[0]["Branchwisevouchertype"].ToString() == "Y")
                        {

                            if (Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()) > Convert.ToDateTime("04/01/2024"))
                            {
                                if (bltype == "OSSI")
                                {
                                    //lbl_invoice.Text = "OSSI" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["vouno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                    //D.   lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    lbl_invoice.Text = "OSI" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();

                                }
                                else if (bltype == "OSPI")
                                {
                                    // lbl_invoice.Text = "OSPI" +fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["vouno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                    //D.  lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    lbl_invoice.Text = "OSP" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                }
                                else if (bltype == "ProOSSI" || bltype == "ProOSPI")
                                {
                                    if (bltype == "ProOSSI")
                                    {
                                        //lbl_invoice.Text = "OSSI" +fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["refno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                        //D. lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["refno"].ToString().ToUpper();
                                        lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "ID" + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();

                                    }
                                    else if (bltype == "ProOSPI")
                                    {
                                        // lbl_invoice.Text = "OSPI" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["refno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                        //D.  lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["refno"].ToString().ToUpper();
                                        lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "IC" + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();

                                    }
                                }
                            }

                            else if (datenow > Convert.ToDateTime("11/30/2017"))
                            {
                                if (bltype == "OSSI")
                                {
                                    //lbl_invoice.Text = "OSSI" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["vouno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                    //D.   lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "ID" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();


                                }
                                else if (bltype == "OSPI")
                                {
                                    // lbl_invoice.Text = "OSPI" +fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["vouno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                    //D.  lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "IC" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();

                                }
                                else if (bltype == "ProOSSI" || bltype == "ProOSPI")
                                {
                                    if (bltype == "ProOSSI")
                                    {
                                        //lbl_invoice.Text = "OSSI" +fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["refno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                        //D. lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["refno"].ToString().ToUpper();
                                        lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "ID" + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();

                                    }
                                    else if (bltype == "ProOSPI")
                                    {
                                        // lbl_invoice.Text = "OSPI" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["refno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                        //D.  lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["refno"].ToString().ToUpper();
                                        lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "IC" + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();

                                    }
                                }
                            }
                            else
                            {
                                if (bltype == "OSSI")
                                {
                                    // lbl_invoice.Text =  dt.Rows[0]["vouno"].ToString().ToUpper();
                                    lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                }
                                else if (bltype == "OSPI")
                                {
                                    //  lbl_invoice.Text =  dt.Rows[0]["vouno"].ToString().ToUpper();
                                    lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                }
                                else if (bltype == "ProOSSI" || bltype == "ProOSPI")
                                {
                                    // lbl_invoice.Text = dt.Rows[0]["refno"].ToString().ToUpper();
                                    if (bltype == "ProOSSI")
                                    {
                                        lbl_invoice.Text = portcode + "/" + "OSSI" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();
                                    }
                                    else
                                    {
                                        lbl_invoice.Text = portcode + "/" + "OSPI" + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();
                                    }
                                }
                            }
                        }

                        else
                        {
                            {

                                if (Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()) > Convert.ToDateTime("04/01/2024"))
                                {
                                    if (bltype == "OSSI")
                                    {
                                        //lbl_invoice.Text = "OSSI" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["vouno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                        //D.   lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                        lbl_invoice.Text = "OS" + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();

                                    }
                                    else if (bltype == "OSPI")
                                    {
                                        // lbl_invoice.Text = "OSPI" +fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["vouno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                        //D.  lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                        lbl_invoice.Text = "OP" + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    }
                                    else if (bltype == "ProOSSI" || bltype == "ProOSPI")
                                    {
                                        if (bltype == "ProOSSI")
                                        {
                                            //lbl_invoice.Text = "OSSI" +fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["refno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                            //D. lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["refno"].ToString().ToUpper();
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "ID" + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();

                                        }
                                        else if (bltype == "ProOSPI")
                                        {
                                            // lbl_invoice.Text = "OSPI" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["refno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                            //D.  lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["refno"].ToString().ToUpper();
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "IC" + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();

                                        }
                                    }
                                }

                                else if (datenow > Convert.ToDateTime("11/30/2017"))
                                {
                                    if (bltype == "OSSI")
                                    {
                                        //lbl_invoice.Text = "OSSI" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["vouno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                        //D.   lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                        lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "ID" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();


                                    }
                                    else if (bltype == "OSPI")
                                    {
                                        // lbl_invoice.Text = "OSPI" +fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["vouno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                        //D.  lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                        lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "IC" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();

                                    }
                                    else if (bltype == "ProOSSI" || bltype == "ProOSPI")
                                    {
                                        if (bltype == "ProOSSI")
                                        {
                                            //lbl_invoice.Text = "OSSI" +fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["refno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                            //D. lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["refno"].ToString().ToUpper();
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "ID" + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();

                                        }
                                        else if (bltype == "ProOSPI")
                                        {
                                            // lbl_invoice.Text = "OSPI" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["refno"].ToString().ToUpper();// dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + fyear + " / " + dt.Rows[0]["pano"].ToString().ToUpper();
                                            //D.  lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["refno"].ToString().ToUpper();
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "IC" + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();

                                        }
                                    }
                                }
                                else
                                {
                                    if (bltype == "OSSI")
                                    {
                                        // lbl_invoice.Text =  dt.Rows[0]["vouno"].ToString().ToUpper();
                                        lbl_invoice.Text = portcode + "OSSI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    }
                                    else if (bltype == "OSPI")
                                    {
                                        //  lbl_invoice.Text =  dt.Rows[0]["vouno"].ToString().ToUpper();
                                        lbl_invoice.Text = portcode + "OSPI" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    }
                                    else if (bltype == "ProOSSI" || bltype == "ProOSPI")
                                    {
                                        // lbl_invoice.Text = dt.Rows[0]["refno"].ToString().ToUpper();
                                        if (bltype == "ProOSSI")
                                        {
                                            lbl_invoice.Text = portcode + "/" + "OSSI" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            lbl_invoice.Text = portcode + "/" + "OSPI" + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + invno + "/" + dt.Rows[0]["refno"].ToString().ToUpper();
                                        }
                                    }
                                }
                            }


                        }

                        //lbl_port.InnerText = "P o L";
                        if (Session["StrTranTypeO"].ToString() == "OE" || Session["StrTranTypeO"].ToString() == "OI")
                        {
                            //lbl_pod.Text = dt.Rows[0]["portname"].ToString().ToUpper();
                            if (bltype == "OSPI" || bltype == "OSSI")
                            {

                                lbl_pod.Text = dt.Rows[0]["portname2"].ToString().ToUpper();
                            }
                            else
                            {
                                lbl_pod.Text = dt.Rows[0]["portname1"].ToString().ToUpper();
                            }
                            lbl_Portpod.InnerHtml = "Destination";
                            lbl_port_pod.Text = dt.Rows[0]["pod"].ToString().ToUpper();
                            // lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper() + "V" + dt.Rows[0]["voyage"].ToString().ToUpper();
                            lbl_mbl.Text = dt.Rows[0]["mblno"].ToString().ToUpper();
                            lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            if (str_trantype == "AE" || str_trantype == "AI")
                            {
                                lbl_mblname.InnerText = "MAWB #";
                            }
                            // lbl_pod.Text = dt.Rows[0]["portname"].ToString().ToUpper();
                            if (bltype == "OSPI" || bltype == "OSSI")
                            {

                                lbl_pod.Text = dt.Rows[0]["portname2"].ToString().ToUpper();
                            }
                            else
                            {
                                lbl_pod.Text = dt.Rows[0]["portname1"].ToString().ToUpper();
                            }
                            lbl_Portpod.InnerHtml = "Destination";
                            lbl_port_pod.Text = dt.Rows[0]["pod"].ToString().ToUpper();
                            lbl_mbl.Text = dt.Rows[0]["mawblno"].ToString().ToUpper();
                            lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd/MM/yyyy");
                        }

                        //Bank Details
                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                        lbl_favouring.Text = dt.Rows[0]["favouring"].ToString().ToUpper();
                        lbl_ifsccode.Text = dt.Rows[0]["swiftcode"].ToString().ToUpper();
                        lbl_bankname.Text = dt.Rows[0]["bankname"].ToString().ToUpper();
                        lbl_bankaddress.Text = dt.Rows[0]["bankaddress"].ToString().ToUpper();
                        lbl_remarks.Text = dt.Rows[0]["remarks"].ToString().ToUpper().ToUpper();


                        double price;
                        if (bltype == "ProOSPI" || bltype == "OSPI")
                        {
                            bool isDouble1 = Double.TryParse(lbl_total.Text, out price);
                            if (isDouble1)
                            {
                                lbl_currword.Text = currency + "  : " + conversion(lbl_total.Text, currency) + " ONLY";
                            }
                        }
                        else
                        {
                            bool isDouble1 = Double.TryParse(lbl_total.Text, out price);
                            if (isDouble1)
                            {
                                lbl_currword.Text = currency + "  : " + conversion(lbl_total.Text, currency) + " ONLY";
                            }
                        }

                        if (Session["StrTranTypeO"].ToString() == "OE" || Session["StrTranTypeO"].ToString() == "OI")
                        {
                            div_cont.Visible = true;
                            DT_cont = obj_OSDNCN.get_containerdetailsOSDNCNOSV(jobno, bid, jobno.ToString(), Session["StrTranTypeO"].ToString());
                            if (Request.QueryString.ToString().Contains("cont_count"))
                            {
                                cont_count = Convert.ToInt32(Request.QueryString["cont_count"].ToString());
                            }
                            else
                            {
                                cont_count = 0;
                            }
                            cont_ = 0;
                            if (DT_cont.Rows.Count > 4)
                            {
                                div_cont.Attributes["class"] = "div_cont_overide";
                                cont_ = DT_cont.Rows.Count;
                                _line = Convert.ToInt32(DT_cont.Rows.Count / 4);
                                _line -= 2;
                            }
                            for (int i = cont_count; i < DT_cont.Rows.Count; i++)
                            {
                                if (i == cont_count + 0)
                                {
                                    lstcon.Text += DT_cont.Rows[i][0].ToString().ToUpper() + "/" + DT_cont.Rows[i][2].ToString().ToUpper() + "/" + DT_cont.Rows[i][1].ToString().ToUpper();
                                }
                                else
                                {
                                    lstcon.Text += ", " + DT_cont.Rows[i][0].ToString().ToUpper() + "/" + DT_cont.Rows[i][2].ToString().ToUpper() + "/" + DT_cont.Rows[i][1].ToString().ToUpper();
                                }
                            }
                        }


                        int check_loop = 0;
                        count = dt.Rows.Count;
                        double temp_total_agent = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            if (bltype == "ProOSPI" || bltype == "OSPI")
                            {
                                tr_row.Text += " <tr style=''>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; white-space:nowrap; '>" + dt.Rows[i]["blno"].ToString().ToUpper() + "</label></td>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:282px;'>" + dt.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; '>" + dt.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                if (str_trantype == "AE" || str_trantype == "AI")
                                {

                                    //tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["cbm"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dt.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["cbm"].ToString() + "</label></td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dt.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";
                                }
                                else
                                {
                                    //tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["cbm"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["cbm"].ToString() + "</label></td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:right; text-align:right;  white-space:nowrap;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                }

                                //tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px; white-space:nowrap;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";

                                /* if (!string.IsNullOrEmpty(dt.Rows[i]["Actamount"].ToString().ToUpper()))
                                 {
                                     temp_taxable += (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                     tr_row.Text += "<td style='color:#000; width: 100px; text-align:right; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</label></td>";
                                 }
                                 else
                                 {
                                     tr_row.Text += "<td style='color:#000; width: 100px; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                 }
                                 tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;' align='right'>&nbsp;</td>";
                                 tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                 tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black; text-align:right;'>&nbsp;</td>";
                                 tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                 tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;' align='right'>&nbsp;</td>";
                                 tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                 tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td></tr>";

                               //  temp_total_agent += Convert.ToDouble(dt.Rows[i]["fcamt"].ToString());
                                 temp_total_agent += (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));

                                 */

                                if (!string.IsNullOrEmpty(dt.Rows[i]["Actamount"].ToString().ToUpper()))
                                {
                                    temp_taxable += (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                    tr_row.Text += "<td style='color:#000; width: 100px; text-align:right; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</label></td>";
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000; width: 100px; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;' align='right'>" + dt.Rows[i]["CGSTP"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["cgsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black; text-align:right;'>" + (Convert.ToDouble(dt.Rows[i]["cgsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                    cgsta += (Convert.ToDouble(dt.Rows[i]["cgsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black; text-align:right;'>" + dt.Rows[i]["sgstp"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["sgsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black; text-align:right;'>" + (Convert.ToDouble(dt.Rows[i]["sgsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                    sgsta += (Convert.ToDouble(dt.Rows[i]["sgsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;' align='right'>" + dt.Rows[i]["igstp"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["igsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;' align='right'>" + (Convert.ToDouble(dt.Rows[i]["igsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                    igsta += (Convert.ToDouble(dt.Rows[i]["igsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px;'  align='right'>" + Convert.ToDouble(dt.Rows[i]["fcamt"].ToString()).ToString("#0,0.00") + "</td></tr>";

                                temp_total_agent += Convert.ToDouble(dt.Rows[i]["fcamt"].ToString());
                                // temp_total_agent += (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));




                                div_exrate.Visible = false;

                                lbl_total.Text = Convert.ToDouble(temp_total_agent).ToString("#,0.00");
                            }
                            else
                            {
                                tr_row.Text += " <tr style=''>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; white-space:nowrap; width:155px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; white-space:nowrap; '>" + dt.Rows[i]["blno"].ToString().ToUpper() + "</label></td>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:282px;'>" + dt.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; '>" + dt.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";

                                if (str_trantype == "AE" || str_trantype == "AI")
                                {
                                    //tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["cbm"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dt.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["cbm"].ToString() + "</label></td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:right; text-align:right;  white-space:nowrap;'>" + dt.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";
                                }
                                else
                                {
                                    //tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["cbm"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["cbm"].ToString() + "</label></td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:right; text-align:right;  white-space:nowrap;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                }


                                // tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px; white-space:nowrap;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px;'>" + dt.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px; white-space:nowrap;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["rate"].ToString()).ToString("#,0.000") + "</label></td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["Actamount"].ToString().ToUpper()))
                                {
                                    temp_taxable += (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                    tr_row.Text += "<td style='color:#000; width: 100px; text-align:right; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + (Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</label></td>";
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000; width: 100px; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;' align='right'>" + dt.Rows[i]["CGSTP"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["cgsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black; text-align:right;'>" + (Convert.ToDouble(dt.Rows[i]["cgsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                    cgsta += (Convert.ToDouble(dt.Rows[i]["cgsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black; text-align:right;'>" + dt.Rows[i]["sgstp"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["sgsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black; text-align:right;'>" + (Convert.ToDouble(dt.Rows[i]["sgsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                    sgsta += (Convert.ToDouble(dt.Rows[i]["sgsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;' align='right'>" + dt.Rows[i]["igstp"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["igsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;' align='right'>" + (Convert.ToDouble(dt.Rows[i]["igsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                    igsta += (Convert.ToDouble(dt.Rows[i]["igsta"].ToString()) / Convert.ToDouble(dt.Rows[i]["exrate"].ToString()));
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;width:100px;'  align='right'>" + Convert.ToDouble(dt.Rows[i]["fcamt"].ToString()).ToString("#0,0.00") + "</td></tr>";




                            }
                            row_count += 1;
                            check_loop = 1;


                            if (Session["StrTranTypeO"].ToString() == "OE" || Session["StrTranTypeO"].ToString() == "OI")
                            {
                                if ((cont_ > 36 && i > count + 20) || (cont_ > 90 && i > count + 10) || (cont_ > 120 && i > count + 4))
                                {
                                    count = i;
                                    str_Script += "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + invoice + "&vouyear=" + vouyear + "&total=" + total + "&tran=" + Session["StrTranType"].ToString() + "&jobno=" + jobno + "&bltype=" + bltype + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                    // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                    break;
                                }
                            }
                        }
                        if (Session["StrTranTypeO"].ToString() == "OE" || Session["StrTranTypeO"].ToString() == "OI" || str_trantype == "AE" || str_trantype == "AI" || str_trantype == "CH")
                        {

                            if (Session["StrTranTypeO"].ToString() == "OE" || Session["StrTranTypeO"].ToString() == "OI")
                            {
                                len_ = 26;
                            }
                            else
                            {
                                len_ = 28;
                            }
                        }
                        if (row_count < 20)
                        {
                            if (row_count >= 14 && row_count <= 18)
                            {
                                row_count += 3;
                            }

                            if (bltype == "ProOSSI" || bltype == "OSSI")
                            {
                                for (int i = row_count + _line; i < len_; i++)
                                {
                                    tr_row.Text += " <tr style=''>";
                                    tr_row.Text += "<td style='color:#000; white-space:nowrap; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td></tr>";

                                }
                            }
                            else
                            {
                                for (int i = row_count + _line; i < len_; i++)
                                {
                                    tr_row.Text += " <tr style=''>";
                                    tr_row.Text += "<td style='color:#000; white-space:nowrap; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000; padding:0px 2px 0px 2px;   border-right: 1px solid Black;'>&nbsp;</td></tr>";

                                }
                            }
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

                        if (!string.IsNullOrEmpty(dt.Rows[0]["originname"].ToString()))
                        {
                            lbl_pos.Text = dt.Rows[0]["originname"].ToString();
                        }
                        DataTable dtsp = new DataTable();
                        dtsp = obj_inv.Get_shipper(Convert.ToInt32(Session["LoginBranchid"]), str_trantype, dt.Rows[0]["blno"].ToString().ToUpper());
                        if (dtsp.Rows.Count > 0)
                        {
                            div_shipperd.Visible = true;
                            for (int i = 0; i < dtsp.Rows.Count; i++)
                            {
                                Lbl_shipperd.Text += dtsp.Rows[i]["shipperinvoice"].ToString().ToUpper() + ",";
                            }
                            Lbl_shipperd.Text = Lbl_shipperd.Text.TrimEnd(',');
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
                            if (!string.IsNullOrEmpty(dt.Rows[0]["email"].ToString()))
                            {
                                lbl_toaddress.Text += dt.Rows[0]["email"].ToString().ToUpper() + "<br />";
                            }
                            if (lbl_pos.Text == "")
                            {
                                if (!string.IsNullOrEmpty(dt.Rows[0]["portname"].ToString().ToUpper()))
                                {
                                    lbl_pos.Text = dt.Rows[0]["portname"].ToString().ToUpper();
                                }
                                else
                                {
                                    div2.Visible = false;
                                }
                            }


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
                                    lbl_tosupply.Text += dt.Rows[0]["statename"].ToString().ToUpper() + ". ";
                                }
                                if (!string.IsNullOrEmpty(dt.Rows[0]["ptc"].ToString()))
                                {
                                    lbl_tosupply.Text += "<strong>PTC :</strong>" + dt.Rows[0]["ptc"].ToString().ToUpper() + " ";
                                }
                                if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                                {
                                    lbl_tosupply.Text += "<strong>PH :</strong>" + dt.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                                }
                                if (!string.IsNullOrEmpty(dt.Rows[0]["email"].ToString()))
                                {
                                    lbl_tosupply.Text += dt.Rows[0]["email"].ToString().ToUpper() + "<br />";
                                }
                                //div_supplygst.InnerText = dt.Rows[0]["email"].ToString().ToUpper().ToUpper();
                                //div_supplystate.InnerText = dt.Rows[0]["statename"].ToString().ToUpper();
                                //div_supplycode.InnerText = dt.Rows[0]["gstcode"].ToString().ToUpper();

                                //div_supplygst.InnerText = dt.Rows[0]["subemail"].ToString().ToUpper().ToUpper();
                                // div_supplystate.InnerText = dt.Rows[0]["statename"].ToString().ToUpper();
                                //div_supplycode.InnerText = dt.Rows[0]["gstcode"].ToString().ToUpper();






                            }
                        }




                    }
                }
                if (Request.QueryString.ToString().Contains("rptvtype"))
                {
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    this.Page.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Response.Clear();
                    Response.ContentType = "text/html";
                    Response.AddHeader("Content-Disposition", "attachment;filename=report.html");
                    Response.Write(sw);
                    Response.End();
                }
                if (str_trantype == "OE" || str_trantype == "FE" || str_trantype == "OI" || str_trantype == "FI")
                {
                    Label_chargewt.InnerText = "Volume";
                }
                else
                {
                    Label_chargewt.InnerText = "Charge Wt";
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
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
                Content = beforefloating + ' ' + " INDIAN RUPEES" + ' ' + afterfloating + ' ' + " PAISE ";
            }
            else if (curr == "USD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " US DOLLARS " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "AED")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " UAE DIRHAM " + ' ' + afterfloating + ' ' + " FILS ";
            }
            else if (curr == "AUD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " AUSTRALIAN DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "CAD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " CANADIAN DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "CHF")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " SWISS FRANC " + ' ' + afterfloating + ' ' + " RAPPEN ";
            }
            else if (curr == "CNY")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " CHINESE YUAN RENMINBI " + ' ' + afterfloating + ' ' + " JIAO (FEN) ";
            }
            else if (curr == "DKK")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " DANISH KRONE " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "ETB")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " ETHIOPIAN BIRR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "EUR")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " EURO " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "GBP")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " POUNDS " + ' ' + afterfloating + ' ' + " PENCE ";
            }
            else if (curr == "HKD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + "     HONG KONG DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "JPY")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + "     JAPANESE YEN " + ' ' + afterfloating + ' ' + " SEN ";
            }
            else if (curr == "NZD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + "     NEW ZEALAND DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "SEK")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + "     SWEDISH KRONA " + ' ' + afterfloating + ' ' + " ORE ";
            }
            else if (curr == "SGD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " SINGAPORE DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "ZAR")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " SOUTH AFRICAN RAND " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "MYR")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " MALAYSIAN RINGGIT " + ' ' + afterfloating + ' ' + " SEN ";
            }
            else
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + "" + ' ' + afterfloating + ' ' + "";
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