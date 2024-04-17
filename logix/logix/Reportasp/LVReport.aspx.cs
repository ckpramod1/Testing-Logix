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
    public partial class LVReport : System.Web.UI.Page
    {

        DataTable dtadd = new DataTable();
        DataTable dt = new DataTable();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        int invoice, jobno, bid, vouyear, customerid, count, cont_count, cont_, _line, page_, row_count, supplyto;
        string str_trantype, jobtype, containers, Profoma;
        double volume, temp, tax, totaltax, sttax_tb, tax1, exrate, total;
        string[] roundup;
        string html, blno, bltype, Header, customertype, branch_invoice;
        string[] cont;
        string str_Script, year, fyear, fyear_invoice;
        double stamt, cgsta, sgsta, igsta, tota_gst, temp_cgst, temp_sgst, temp_igst, temp_taxable;
        string[] branch_inv;
        DataTable Dt_sort = new DataTable();
        double temp_total_agent = 0; int _int = 0;
        int curr_count = 0;
        string currency;
        string titlename = "";
        string portcode = "";
        string duedate1;
        int div_id = 1;
        string fadname1;
        int cid;
        DataTable dtobl = new DataTable();

        DataAccess.Accounts.OSDNCN objosdncn = new DataAccess.Accounts.OSDNCN();

        DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();

        // Einvoice newly added satrt//
        DataAccess.Documents objnewdoc = new DataAccess.Documents();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataAccess.Documents objnew = new DataAccess.Documents();
        // Einvoice newly added end//
        protected void Page_Load(object sender, EventArgs e)
        {
            //string fadname = Session["FADbname"].ToString();


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Log.GetDataBase(Ccode);
                obj_inv.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                objosdncn.GetDataBase(Ccode);
                da_obj_jobinfo.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);

                objnewdoc.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);
                objnew.GetDataBase(Ccode);

            }
            if (Request.QueryString.ToString().Contains("FADbname123"))
            {
                if (Session["FADbname"] == null)
                {
                    fadname1 = Request.QueryString["FADbname123"].ToString();
                    Session["FADbname"] = fadname1;
                }
            }
            string fadname = Session["FADbname"].ToString();
            DataTable dtcust = new DataTable();

            if (Request.QueryString.ToString().Contains("username"))
            {
                if (Session["LoginUserName"] == null)
                {
                    string username1 = Request.QueryString["username"].ToString();
                    Session["LoginUserName"] = username1;
                }
            }

            if (Request.QueryString.ToString().Contains("empid"))
            {
                if (Session["LoginEmpId"] == null)
                {
                    int empid1 = Convert.ToInt32(Request.QueryString["empid"].ToString());
                    Session["LoginEmpId"] = empid1;
                }
            }
            if (Request.QueryString.ToString().Contains("cid1"))
            {
                if (Session["LoginDivisionId"] == null)
                {
                    cid = Convert.ToInt32(Request.QueryString["cid1"].ToString());
                    Session["LoginDivisionId"] = cid;
                }
            }

            if (Request.QueryString.ToString().Contains("bid1"))
            {
                if (Session["LoginBranchid"] == null)
                {
                    bid = Convert.ToInt32(Request.QueryString["bid1"].ToString());
                    Session["LoginBranchid"] = bid;
                }
            }
            if (Request.QueryString.ToString().Contains("branchname"))
            {
                if (Session["LoginBranchName"] == null)
                {
                    branch_invoice = Request.QueryString["branchname"].ToString();
                    Session["LoginBranchName"] = branch_invoice;
                }
            }
            if (Request.QueryString.ToString().Contains("branchname"))
            {
                if (Session["LoginDivisionName"] == null)
                {
                    string divisionname = Request.QueryString["divisionname"].ToString();
                    Session["LoginDivisionName"] = divisionname;
                }
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/','_top');", true);
            }
            try
            {

                if (Request.QueryString.ToString().Contains("Invoiceno"))
                {
                    invoice = Convert.ToInt32(Request.QueryString["Invoiceno"]);
                    branch_invoice = Session["LoginBranchName"].ToString().Substring(0, 3);


                    if (Session["Basecurr"] != null)
                    {
                        th_basecurr.InnerText = Session["Basecurr"].ToString().ToUpper();
                        //     td_tax_basecurr.InnerText = "(" + th_basecurr.InnerText + ")";
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
                    if (Request.QueryString.ToString().Contains("Interbranchvouchertransfer"))
                    {
                        titlename = "Interbranchvouchertransfer";
                    }
                   // DataAccess.LogDetails logobj = new DataAccess.LogDetails();
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
                    if (Request.QueryString.ToString().Contains("trantype"))
                    {
                        str_trantype = Request.QueryString["trantype"].ToString();
                    }
                    else
                    {
                        str_trantype = Session["StrTranType"].ToString();
                    }
                    if (str_trantype == "FE")
                    {
                        str_trantype = "OE";

                    }
                    else if (str_trantype == "FI")
                    {
                        str_trantype = "OI";
                    }


                    //// lbl_img.ImageUrl = "../images/montorlogo1.png";
                    //if (Request.QueryString.ToString().Contains("page"))
                    //{
                    //    page_ = Convert.ToInt32(Request.QueryString["page"]);
                    //    lbl_page.Text = "1 of " + (page_ + 1).ToString();
                    //}
                    //else
                    //{
                    //    page_ = 1;
                    //    lbl_page.Text = "1 of " + (page_).ToString();
                    //}


                    lblcompanyname.Text = Session["LoginDivisionName"].ToString();
                    lbl4comname.InnerText = lblcompanyname.Text.ToUpper();
                    //  lbl_img.ImageUrl = "../images/s2cpaint2.png";
                   // DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
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
                        //     lbl_cin.Text = dtadd.Rows[0]["cinno"].ToString().ToUpper();

                    }
                    if (Request.QueryString["header"].ToString() == "Invoice")
                    {

                        duedate1 = obj_inv.GetCreditDaysfromVoucher(bid, Convert.ToInt32(invoice), 'I', vouyear);
                        // duedate1 = obj_inv.GetCreditDaysfromVoucher(bid, Convert.ToInt32(invoice), Convert.ToInt32(Request.QueryString["voutype"].ToString()), vouyear);
                        if (duedate1 == "0")
                        {
                            // bihe lbl_date1.Text = "Immediate".ToUpper();

                        }
                        else
                        {
                            // bihe lbl_date1.Text = duedate1;
                        }

                        //  div_OBL.Visible = true;
                    }
                    else if (Request.QueryString["header"].ToString() == "Bill of Supply")
                    {
                        //   div_date1.Visible = true;

                        duedate1 = obj_inv.GetCreditDaysfromVoucher(bid, Convert.ToInt32(invoice), 'B', vouyear);
                        if (duedate1 == "0")
                        {
                            // bihe lbl_date1.Text = "Immediate".ToUpper();

                        }
                        else
                        {
                            // bihe lbl_date1.Text = duedate1;
                        }
                        // div_OBL.Visible = true;
                    }
                    else if (Request.QueryString["header"].ToString() == "DN")
                    {
                        //  div_date1.Visible = true;
                        duedate1 = obj_inv.GetCreditDaysfromVoucher(bid, Convert.ToInt32(invoice), 'D', vouyear);
                        if (duedate1 == "0")
                        {
                            // bihe lbl_date1.Text = "Immediate".ToUpper();

                        }
                        else
                        {
                            // bihe lbl_date1.Text = duedate1;
                        }
                        //div_OBL.Visible = false;
                    }
                    else
                    {
                        //// bihe lbl_date1.Text =  "Immediate".ToUpper();
                        //  div_date1.Visible = false;
                        //  div_OBL.Visible = false;

                    }




                    // Einvoice newly added satrt//

                    if (Profoma == "")
                    {
                        DataTable dtnew1 = new DataTable();
                        string img1 = "";
                        if (Request.QueryString["header"].ToString() == "Invoice")
                        {
                            dtnew1 = objnewdoc.getdetails4gstdetails(bid, invoice, vouyear, "I");
                            if (dtnew1.Rows.Count > 0)
                            {
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
                        else if (Request.QueryString["header"].ToString() == "Invoice FC")
                        {

                            {
                                dtnew1 = objnewdoc.getdetails4gstdetails(bid, invoice, vouyear, "F");
                                if (dtnew1.Rows.Count > 0)
                                {
                                    //  div_image1.Visible = true;
                                    //    div_irn.Visible = true;
                                    LblIrnno.Text = dtnew1.Rows[0][0].ToString();

                                    // ImgLogo.ImageUrl = "https://my.gstzen.in" + dtnew1.Rows[0][1].ToString();

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


                        }

                        else if (Request.QueryString["header"].ToString() == "DN")
                        {
                            dtnew1 = objnewdoc.getdetails4gstdetails(bid, invoice, vouyear, "V");
                            if (dtnew1.Rows.Count > 0)
                            {
                                //       div_image1.Visible = true;
                                //       div_irn.Visible = true;
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
                                //div_irn.Visible = false;

                                // div_image1.Visible = false;


                            }

                        }
                        else if (Request.QueryString["header"].ToString() == "CN")
                        {
                            dtnew1 = objnewdoc.getdetails4gstdetails(bid, invoice, vouyear, "E");
                            if (dtnew1.Rows.Count > 0)
                            {
                                LblIrnno.Text = dtnew1.Rows[0][0].ToString();
                                //  div_image1.Visible = true;
                                //  div_irn.Visible = true;
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
                                //  div_irn.Visible = false;
                                //div_image1.Visible = false;


                            }


                        }
                    }

                    // Einvoice newly added end//


                }




                if (Session["LoginBranchid"] != null)
                {
                    portcode = portobj.GetPortCodeportid(Convert.ToInt32(Session["LoginBranchid"]));
                    portcode = portcode.Substring(2, 3);
                }
                ///STD
                if (Request.QueryString.ToString().Contains("header"))
                {
                    Header = Request.QueryString["header"].ToString();
                    if (Header == "CN" || Header == "PA" || Header == "PA FC")
                    {
                        label_bill.InnerText = "Bill From";
                        label_supply.InnerText = "Supply From";
                    }
                    if (Request.QueryString["header"].ToString() == "PA" || Header == "PA FC")
                    {
                        DIVIRN.Visible = false;
                        // bhide
                        //dimbl.Visible = false;
                        //divp.Visible = false;
                        //div_exrate.Visible = false;
                        //div_grw.Visible = false;
                        divqr.Visible = false;
                        //b hidew
                        if (Profoma == "")
                        {

                        }
                        else
                        {
                            divinvtype.InnerText = "Ref # ";
                        }
                        //  divsc.Visible = false;
                        //   divIRND.Visible = false;
                        div_cont.Visible = true;
                        remarks.Visible = false;
                        ////table_invoice.Visible = false;
                        //table_cn.Visible = true;
                        //div_invoice.Visible = false;
                        div_cnops.Visible = true;
                        if (Profoma == "")
                        {
                            lbl_head.Text = "PURCHASE INVOICE";
                        }
                        else
                        {
                            lbl_head.Text = "PROFORMA PURCHASE INVOICE";
                        }
                        if (Request.QueryString["header"].ToString() == "PA FC")
                        {
                            if (Profoma == "")
                            {
                                lbl_head.Text = "Purchase Invoice FC";

                            }
                            else
                            {
                                lbl_head.Text = "Proforma Purchase Invoice FC";

                            }
                        }
                        //div_cnopshead.Visible = true;
                        //div_invoicehead.Visible = false;
                        if (str_trantype == "OE")
                        {
                            //div_ship4cn.Visible = true;
                        }
                        else
                        {
                            //div_ship4cn.Visible = false;
                        }


                        if (str_trantype == "CH" || str_trantype == "AI" || str_trantype == "AE" || str_trantype == "OI" || str_trantype == "OE")
                        {
                            //div_between.Visible = false;
                            //div_invoice.Visible = true;
                            div_bank.Visible = false;
                            //div_bottomsign.Visible = false;
                        }
                        //dtadd = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        //{

                        //    lbl_add.Text = dtadd.Rows[0]["address"].ToString();
                        //    lbl_ph.Text = dtadd.Rows[0]["phone"].ToString();
                        //    lbl_fax.Text = dtadd.Rows[0]["fax"].ToString();
                        //    lbl_staxhead.Text = dtadd.Rows[0]["stno"].ToString();
                        //    lbl_panno.Text = dtadd.Rows[0]["panno"].ToString();
                        //    //lbl_cin.Text = dtadd.Rows[0]["cinno"].ToString();
                        //}
                        if (Request.QueryString.ToString().Contains("bltype"))
                        {
                            bltype = Request.QueryString["bltype"].ToString();
                            if (bltype == "M")
                            {
                                //table_cn.Visible = false;
                                div_approve.Visible = true;
                                //table_btcn.Visible = true;
                                div_mbl.Visible = false;
                                div_consignee.Visible = false;
                                div_volume.Visible = false;
                                div_cont.Visible = false;
                                //div_sttax.Visible = false;
                                //dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, "PA", "", Profoma);
                                if (Request.QueryString["header"].ToString() == "PA")
                                {
                                    dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                }
                                else if (Request.QueryString["header"].ToString() == "PA FC")
                                {
                                    dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                }
                                if (dt.Rows.Count > 0)
                                {
                                    div_vendorref.Visible = true;
                                    lbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();


                                    //div_vendorrefdate.Visible = true;
                                    if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                                    {
                                        lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                                    }
                                    else
                                    {
                                        lbl_vendordate.Text = "";
                                    }
                                    if (Profoma == "Profoma")
                                    {
                                        total = 0;
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            total += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                                        }
                                        lbl_total.Text = Convert.ToDouble(total).ToString("#,0.00");
                                    }
                                    else
                                        if (Profoma == "")
                                    {
                                        lbl_total.Text = Convert.ToDouble(dt.Rows[0]["total"].ToString()).ToString("#,0.00");
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
                                        //FALedger.Visible = true;
                                        //lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                                    }
                                    lbl_job.InnerText = "Job #";
                                    //if (!string.IsNullOrEmpty(dt.Rows[0]["exrate"].ToString()))
                                    //{
                                    //    lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                    //}
                                    //exrate = 0;
                                    //for (int i = 0; i < dt.Rows.Count; i++)
                                    //{
                                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                    //    {
                                    //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                    //        {
                                    //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                    //        }
                                    //    }
                                    //}
                                    //if (exrate > 0)
                                    //{
                                    //    lbl_exrate.Text = exrate.ToString("#,0.0000");
                                    //}
                                    DataView dv_curr = new DataView(dt);
                                    Dt_sort = dv_curr.ToTable(true, "curr");
                                    dv_curr = new DataView(Dt_sort);
                                    dv_curr.Sort = "curr";
                                    Dt_sort = dv_curr.ToTable();
                                    lbl_exrate.Text = "";
                                    curr_count = Dt_sort.Rows.Count;
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
                                                lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                            else
                                            {
                                                lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                        }
                                    }
                                    jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                                    //string jobno1 = dt.Rows[0]["jobnotrantype"].ToString();
                                    //lbl_ourjob.Text = jobno1.ToString();

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

                                    //lbl_ourjob.Text = jobno.ToString();
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper() + " V " + dt.Rows[0]["voyage"].ToString().ToUpper();
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString().ToUpper();
                                        lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString().ToUpper();
                                    }
                                    else if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        //div_pack.Visible = true;
                                        lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper() + " V " + Convert.ToDateTime(dt.Rows[0]["voyage"].ToString()).ToString("dd-MMM-yyyy");
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
                                    int panno;
                                    string invno = dt.Rows[0]["vouno"].ToString();
                                    // panno =Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
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

                                    if (Profoma == "Profoma")
                                    {
                                        divinvtype.InnerText = "Ref #";
                                        if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                                        {
                                            if (Request.QueryString["header"].ToString() == "Invoice")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "SI" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                            }
                                            else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "SO" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                            }
                                            else if (Request.QueryString["header"].ToString() == "PA")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "PI" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                            }
                                            else if (Request.QueryString["header"].ToString() == "PA FC")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + "PO" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                            }
                                        }
                                        else
                                        {
                                            if (Request.QueryString["header"].ToString() == "Invoice")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + vouyear + "/" + "SI" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                            }
                                            else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + vouyear + "/" + "SO" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                            }
                                            else if (Request.QueryString["header"].ToString() == "PA")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + vouyear + "/" + "PI" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                            }
                                            else if (Request.QueryString["header"].ToString() == "PA FC")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + vouyear + "/" + "PO" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                            }
                                        }

                                    }
                                    else
                                    {
                                        divinvtype.InnerText = "PI #";
                                        if (Request.QueryString["header"].ToString() == "PA")
                                        {
                                            lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "PI" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                        }
                                        else if (Request.QueryString["header"].ToString() == "PA FC")
                                        {
                                            lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "PO" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                        }

                                    }
                                    lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd-MMM-yyyy");

                                    lbl_bl.Text = dt.Rows[0]["blno"].ToString().ToUpper().Replace("#", "");
                                    if (str_trantype == "OI")
                                    {
                                        lbl_port.InnerText = "P O L";
                                        //lbl_port1.InnerText = "P O D";
                                    }
                                    if (str_trantype == "OE")
                                    {
                                        lbl_port.InnerText = "P O L";
                                        //lbl_port1.InnerText = "P O D";
                                    }

                                    if ((str_trantype == "AE" && bltype == "M") || (str_trantype == "AI" && bltype == "M"))
                                    {
                                        lbl_port.InnerText = "P O L";
                                        //lbl_port1.InnerText = "P O D";
                                    }
                                    if (str_trantype == "CH")
                                    {

                                        div_approve.Visible = true;
                                        div_pack.Visible = true;
                                    }



                                    lbl_pod.Text = dt.Rows[0]["pod"].ToString().ToUpper();
                                    if (dt.Columns.Contains("mpolname"))
                                    {
                                        // b hide     lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper();

                                        lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper() + '/' + dt.Rows[0]["mpodname"].ToString().ToUpper();
                                    }
                                    else
                                    {
                                        div_port.Visible = false;
                                        lbl_pod.Text = "";
                                    }
                                    if (dt.Columns.Contains("mpodname"))
                                    {
                                        //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                    }
                                    else
                                    {
                                        div_port1.Visible = false;
                                        //lbl_pod1.Text = "";
                                    }

                                    if (str_trantype == "OE")
                                    {
                                        //lbl_ship.Text = dt.Rows[0]["shipmentpod"].ToString().ToUpper();
                                    }
                                    label_shipper.InnerText = "Agent";
                                    lbl_shipper.Text = dt.Rows[0]["shipment"].ToString().ToUpper();
                                    lbl_remarks.Text = dt.Rows[0]["remarks"].ToString().ToUpper();

                                    //lbl_total.Text = Convert.ToDouble(Request.QueryString["total"]).ToString("#,0.00");
                                    double price;
                                    bool isDouble1 = Double.TryParse(lbl_total.Text, out price);
                                    if (isDouble1)
                                    {
                                        if (customertype == "P")
                                        {
                                            if (curr_count == 1)
                                            {
                                                //  lbl_currword.Text = currency + "  : " + conversion(total_agent.Text, "") + " ONLY";

                                                if (currency == "INR")
                                                {
                                                    currency = " RUPEES";
                                                }

                                                lbl_currword.Text = currency + " " + conversion(total_agent.Text, "") + " ONLY";
                                            }
                                            else
                                            {
                                                lbl_currword.Text = "USD" + " " + conversion(total_agent.Text, "") + " ONLY";
                                            }

                                        }
                                        else
                                        {
                                            // lbl_currword.Text = th_basecurr.InnerText + "  : " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";

                                            lbl_currword.Text = "RUPEES " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                                        }

                                        //lbl_currword.Text = ConvertNumbertoWords(Convert.ToInt32(price)) + " ONLY";
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
                                    if (Request.QueryString.ToString().Contains("cont_count"))
                                    {
                                        cont_count = Convert.ToInt32(Request.QueryString["cont_count"].ToString());
                                    }
                                    else
                                    {
                                        cont_count = 0;
                                    }
                                    DataTable DT_cont = new DataTable();
                                    DT_cont = obj_inv.get_containerdetails(jobno, bid, blno, str_trantype, bltype);
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
                                    DataTable dtLi = new DataTable();
                                    DataView data1 = dt.DefaultView;
                                    data1.RowFilter = "groupid = '" + 1 + "' ";
                                    dtLi = data1.ToTable();
                                    row_count = 0;
                                    temp_taxable = 0;
                                    for (int i = 0; i < dtLi.Rows.Count; i++)
                                    {
                                        if (string.IsNullOrEmpty(dtLi.Rows[i]["percentage"].ToString()))
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                            if (str_trantype == "AE" || str_trantype == "AI")
                                            {
                                                //  tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HAWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";

                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; white-space:nowrap;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString().ToUpper()).ToString("#0.000") + "</td>";//change on oct212021 Convert.ToDouble(dtLi.Rows[i]["unit"].ToString().ToUpper()).ToString("#0.00")

                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HAWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";
                                            }
                                            else
                                            {
                                                //  tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";

                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; white-space:nowrap; border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString().ToUpper()).ToString("#0.000") + "</label></td>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                            }
                                            // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";

                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";

                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";

                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                            {
                                                temp_taxable += Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString().ToUpper());
                                                tr_row.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; width: 100px; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["CGSTP"].ToString() + "</td>";
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["cgsta"].ToString()))
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                cgsta += Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString());
                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dtLi.Rows[i]["sgstp"].ToString() + "</td>";
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["sgsta"].ToString()))
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                sgsta += Convert.ToDouble(dt.Rows[i]["sgsta"].ToString());
                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                                igsta += Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString());
                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 0px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";
                                            row_count += 1;
                                        }
                                    }
                                    int check_loop = 0;
                                    for (int i = 0; i < dtLi.Rows.Count; i++)
                                    {
                                        if (!string.IsNullOrEmpty(dtLi.Rows[i]["percentage"].ToString()) || dtLi.Rows[i]["percentage"].ToString() == "0")
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                            if (str_trantype == "AE" || str_trantype == "AI")
                                            {
                                                //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; white-space:nowrap;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";
                                                //b hide
                                                //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                                //b hide
                                                //.Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG")
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HAWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";
                                                //the line add for empty dt

                                            }
                                            else
                                            {
                                                // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";


                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; white-space:nowrap;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";


                                            }

                                            //    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                            // bhide
                                            // bnew
                                            //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                            //// bnew

                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";


                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                            {
                                                temp_taxable += Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString().ToUpper());
                                                tr_row.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; width: 100px; border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["CGSTP"].ToString() + "</td>";
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["cgsta"].ToString()))
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                cgsta += Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString());
                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dtLi.Rows[i]["sgstp"].ToString() + "</td>";
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["sgsta"].ToString()))
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                sgsta += Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString());
                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                                igsta += Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString());
                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";
                                            row_count += 1;
                                            check_loop = 1;
                                        }

                                    }

                                    DataTable dtLi1 = new DataTable();
                                    DataView data2 = dt.DefaultView;
                                    data2.RowFilter = "groupid <> '" + 1 + "' and groupid <> '" + 5 + "'";
                                    dtLi1 = data2.ToTable();
                                    double total_tax = 0;

                                    dt = obj_inv.get_tdspayable(invoice, bid, vouyear, "P");
                                    if (dt.Rows.Count > 0)
                                    {
                                        tr_row.Text += " <tr style=''>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                        row_count += 1;

                                        tr_row.Text += " <tr style=''>";
                                        if (dt.Rows.Count > 0)
                                        {
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; '>TDS PAYABLE " + dt.Rows[0]["tdsdesc"].ToString() + " Rs. " + Convert.ToDouble(dt.Rows[0]["tdsamount"].ToString()).ToString("#,0.00") + "</label></td>";

                                        }
                                        else
                                        {
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        }
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";

                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                        row_count += 1;
                                    }
                                    if (str_trantype == "AE" || str_trantype == "AI" || str_trantype == "CH")
                                    {
                                        for (int i = row_count + _line; i < 36; i++)
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";

                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                        }
                                    }
                                    else if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        div_cont.Visible = true;
                                        for (int i = row_count + _line; i < 33; i++)
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
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
                            }
                            else if (bltype == "H")
                            {
                                if (Request.QueryString["header"].ToString() == "PA FC")
                                {
                                    dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                }
                                else
                                {
                                    dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);

                                }
                                if (dt.Rows.Count > 0)
                                {
                                    if (!string.IsNullOrEmpty(dt.Rows[0]["preparedby"].ToString()))
                                    {
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                    }
                                    if (!string.IsNullOrEmpty(dt.Rows[0]["approvedby"].ToString()))
                                    {
                                        lbl_approved.Text = dt.Rows[0]["approvedby"].ToString();
                                    }


                                    //div_vendorref.Visible = true;
                                    lbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();


                                    //div_vendorrefdate.Visible = true;
                                    if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                                    {
                                        lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                                    }
                                    else
                                    {
                                        lbl_vendordate.Text = "";
                                    }



                                    //if (!string.IsNullOrEmpty(dt.Rows[0]["exrate"].ToString()))
                                    //{
                                    //    lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                    //}
                                    if (Profoma == "Profoma")
                                    {
                                        total = 0;
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            total += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                                        }
                                        lbl_total.Text = Convert.ToDouble(total).ToString("#,0.00");
                                    }
                                    else
                                        if (Profoma == "")
                                    {
                                        lbl_total.Text = Convert.ToDouble(dt.Rows[0]["total"].ToString()).ToString("#,0.00");
                                    }
                                    //exrate = 0;
                                    //for (int i = 0; i < dt.Rows.Count; i++)
                                    //{
                                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                    //    {
                                    //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                    //        {
                                    //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                    //        }
                                    //    }
                                    //}
                                    //if(exrate>0)
                                    //{
                                    //    lbl_exrate.Text = exrate.ToString("#,0.0000");
                                    //}
                                    DataView dv_curr = new DataView(dt);
                                    Dt_sort = dv_curr.ToTable(true, "curr");
                                    dv_curr = new DataView(Dt_sort);
                                    dv_curr.Sort = "curr";
                                    Dt_sort = dv_curr.ToTable();
                                    lbl_exrate.Text = "";
                                    curr_count = Dt_sort.Rows.Count;
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
                                                lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                            else
                                            {
                                                lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                        }
                                    }

                                    lbl_job.InnerText = "Job #";
                                    jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                                    if (dt.Rows[0]["shortname"].ToString().Length > 0)
                                    {
                                        branch_inv = dt.Rows[0]["shortname"].ToString().Split('-');
                                        if (branch_inv.Length > 0)
                                        {
                                            branch_invoice = branch_inv[1].ToString();
                                        }
                                    }
                                    lbl_ourjob.Text = jobno.ToString();

                                    string invno = dt.Rows[0]["vouno"].ToString();
                                    // panno =Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
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
                                    if (Profoma == "Profoma")
                                    {

                                        if (Request.QueryString["header"].ToString() == "Invoice")
                                        {
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "SI" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                        {
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "SO" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "PA")
                                        {
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "PI" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "PA FC")
                                        {
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "PO" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();

                                        }
                                    }
                                    else
                                    {

                                        if (Request.QueryString["header"].ToString() == "PA")
                                        {
                                            lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "PI" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "PA FC")
                                        {
                                            lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "PO" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                        }
                                    }



                                    if (str_trantype == "BT")
                                    {
                                        //table_cn.Visible = false;
                                        div_ship.Visible = false;
                                        div_cont.Visible = false;
                                        ////table_invoice.Visible = false;
                                        //table_btcn.Visible = true;
                                        label_vessel.InnerText = "Truck #";//
                                        lbl_vessel.Text = dt.Rows[0]["truckno"].ToString().ToUpper();
                                        lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd-MMM-yyyy");
                                        lbl_blname.InnerText = "No of Pkgs ";
                                        lbl_bl.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["pkgtype"].ToString().ToUpper();
                                        lbl_mblname.InnerText = "Volume";
                                        lbl_mbl.Text = dt.Rows[0]["cbm"].ToString() + " cbm";
                                        lbl_port.InnerText = "Weight";
                                        lbl_pod.Text = dt.Rows[0]["weight"].ToString() + " kgs";

                                        ////lbl_port1.InnerText = "Weight";
                                        ////lbl_pod1.Text = dt.Rows[0]["weight"].ToString() + " kgs";

                                        div_pack.Visible = false;
                                        // div_grw.Visible = false;
                                        div_volume.Visible = false;
                                        lbl4comname.InnerText = "for " + dt.Rows[0]["branchname"].ToString().ToUpper();
                                        //div_e_oe.Visible = true;
                                    }
                                    else
                                        if (str_trantype == "OE" || str_trantype == "OI" || str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        lbl_bl.Text = dt.Rows[0]["blno"].ToString().ToUpper();
                                        lbl_mbl.Text = dt.Rows[0]["mblno"].ToString().ToUpper();
                                        lbl_pod.Text = dt.Rows[0]["pod"].ToString().ToUpper();
                                        ////lbl_pod1.Text = dt.Rows[0]["pod"].ToString().ToUpper();
                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper() + " / " + dt.Rows[0]["pod"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }
                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }

                                        if (str_trantype == "OE" || str_trantype == "OI")
                                        {
                                            div_pack.Visible = true;
                                            lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString().ToUpper();
                                            //lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20 + " + dt.Rows[0]["cont40"].ToString() + " x 40";
                                            jobtype = dt.Rows[0]["jobtype"].ToString().ToUpper();
                                            if (jobtype != "")
                                            {
                                                if (jobtype == "3")
                                                {
                                                    DataTable dtnew1 = new DataTable();

                                                    if (Request.QueryString.ToString().Contains("blno"))
                                                    {
                                                        blno = blno = Request.QueryString["blno"].ToString().ToUpper();
                                                        dtnew1 = obj_inv.getsizetype(blno, jobno, bid, str_trantype);
                                                    }

                                                    if (dtnew1.Rows.Count > 0)
                                                    {
                                                        lbl_volume.Text = dtnew1.Rows[0]["size"].ToString().ToUpper().ToUpper();
                                                    }
                                                    else
                                                    {
                                                        //lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                        if (dt.Rows[0]["cont40"].ToString() != "0" && dt.Rows[0]["cont20"].ToString() != "0")
                                                        {
                                                            lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                        }
                                                        else if (dt.Rows[0]["cont40"].ToString() != "0")
                                                        {
                                                            lbl_volume.Text = dt.Rows[0]["cont40"].ToString() + " x 40' ";
                                                        }
                                                        else if (dt.Rows[0]["cont20"].ToString() != "0")
                                                        {
                                                            lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ";
                                                        }
                                                    }
                                                    //    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" +
                                                    //    dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                }
                                                else
                                                {
                                                    volume = Convert.ToDouble(dt.Rows[0]["cbm"].ToString());
                                                    //lbl_volume.Text = volume.ToString("#0.00") +" / " +"LCL";change roundup 3 decimal on oct212021
                                                    lbl_volume.Text = volume.ToString("#0.000") + " / " + "LCL";
                                                }
                                            }
                                            if (str_trantype == "OE")
                                            {
                                                //lbl_ship.Text = dt.Rows[0]["shipmentpod"].ToString().ToUpper();
                                            }
                                            lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper() + " V " + dt.Rows[0]["voyage"].ToString().ToUpper();
                                            lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd/MM/yyyy");
                                            lbl_port.InnerText = "P O L";
                                            //lbl_port1.InnerText = "P O D";
                                        }
                                        else if (str_trantype == "AE")
                                        {
                                            lbl_blname.InnerText = "HAWB #";
                                            lbl_mblname.InnerText = "MAWB #";
                                            lbl_pack.InnerText = "Gross Wt";
                                            lbl_package.Text = Convert.ToDouble(dt.Rows[0]["grosswt"].ToString()).ToString("#0.00") + " Kgs";
                                            lbl_gw.InnerText = "Charge Wt ";
                                            lbl_grwt.Text = Convert.ToDouble(dt.Rows[0]["chargewt"].ToString()).ToString("#0.00") + " Kgs";
                                            lable_volume.InnerText = "Package";
                                            lbl_volume.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString().ToUpper();
                                            lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper() + " V " + Convert.ToDateTime(dt.Rows[0]["voyage"].ToString()).ToString("dd-MMM-yyyy");
                                            lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd-MMM-yyyy");
                                            div_cont.Visible = false;
                                            //   div_grw.Visible = true;
                                            div_approve.Visible = true;
                                            div_pack.Visible = true;
                                            lbl_port.InnerText = "P O L";
                                            //lbl_port1.InnerText = "P O D";
                                        }
                                        else if (str_trantype == "AI")
                                        {
                                            lbl_port.InnerText = "P O L";
                                            //lbl_port1.InnerText = "P O D";
                                            lbl_blname.InnerText = "HAWB #";
                                            lbl_mblname.InnerText = "MAWB #";
                                            lbl_pack.InnerText = "Gross Wt";
                                            lbl_package.Text = Convert.ToDouble(dt.Rows[0]["grosswt"].ToString()).ToString("#0.00") + " Kgs";
                                            lbl_gw.InnerText = "Charge Wt ";
                                            lbl_grwt.Text = Convert.ToDouble(dt.Rows[0]["chargewt"].ToString()).ToString("#0.00") + " Kgs";
                                            lable_volume.InnerText = "Package";
                                            lbl_volume.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString().ToUpper();
                                            lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper() + " V " + Convert.ToDateTime(dt.Rows[0]["voyage"].ToString()).ToString("dd-MMM-yyyy");
                                            lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd-MMM-yyyy");
                                            div_cont.Visible = false;
                                            //  div_grw.Visible = true;
                                            div_pack.Visible = true;
                                            div_approve.Visible = true;
                                            lbl_port.InnerText = "P O L";
                                            //lbl_port1.InnerText = "P O D";
                                        }
                                    }
                                    else if (str_trantype == "CH")
                                    {
                                        label_vessel.InnerText = "Mode";
                                        lbl_vessel.Text = dt.Rows[0]["mode"].ToString().ToUpper();
                                        lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd-MMM-yyyy");
                                        lbl_blname.InnerText = "Doc #";
                                        lbl_bl.Text = dt.Rows[0]["docno"].ToString().ToUpper();
                                        lbl_mblname.InnerText = "Doc Date";
                                        lbl_mbl.Text = Convert.ToDateTime(dt.Rows[0]["docdate"].ToString()).ToString("dd-MMM-yyyy");
                                        lable_volume.InnerText = "Volume ";
                                        lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["volume"].ToString()).ToString("#0.00") + " M3";


                                        lbl_pack.InnerText = "Weight";
                                        lbl_package.Text = Convert.ToDouble(dt.Rows[0]["grosswt"].ToString()).ToString("#0.00") + " Kgs";
                                        div_volume.Visible = false;
                                        //div_ship4cn.Visible = false;
                                        div_cont.Visible = false;
                                        div_approve.Visible = true;
                                        div_pack.Visible = true;
                                        //div_between.Visible = false;
                                        //div_invoice.Visible = true;
                                        div_bank.Visible = false;
                                        //div_bottomsign.Visible = false;

                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_port.InnerText = "P O L";
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }

                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            //lbl_port1.InnerText = "P O D";
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }
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
                                        //FALedger.Visible = true;
                                        //lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                                    }

                                    double price;
                                    if (str_trantype != "BT")
                                    {
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString().ToUpper();
                                        lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString().ToUpper();
                                        lbl_shipper.Text = dt.Rows[0]["shipper"].ToString().ToUpper();
                                        lbl_consignee.Text = dt.Rows[0]["consignee"].ToString().ToUpper();
                                        lbl_remarks.Text = dt.Rows[0]["remarks"].ToString().ToUpper();
                                        //lbl_total.Text = Convert.ToDouble(Request.QueryString["total"]).ToString("#,0.00");
                                        bool isDouble = Double.TryParse(lbl_total.Text, out price);
                                        if (isDouble)
                                        {
                                            //lbl_currword.Text = th_basecurr.InnerText + "  : " + ConvertNumbertoWords(Convert.ToInt32(price)) + " ONLY";
                                            if (customertype == "P")
                                            {
                                                if (curr_count == 1)
                                                {
                                                    //  lbl_currword.Text = currency + "  : " + conversion(total_agent.Text, currency) + " ONLY";
                                                    if (currency == "INR")
                                                    {
                                                        currency = " RUPEES";
                                                    }


                                                    lbl_currword.Text = currency + " " + conversion(total_agent.Text, currency) + " ONLY";
                                                }
                                                else
                                                {
                                                    lbl_currword.Text = "USD" + " " + conversion(total_agent.Text, currency) + " ONLY";
                                                }

                                            }
                                            else
                                            {
                                                // lbl_currword.Text = th_basecurr.InnerText + "  : " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                                                lbl_currword.Text = "RUPEES " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //div_between.Visible = false;
                                        //div_invoice.Visible = true;
                                        div_bank.Visible = false;
                                        //div_bottomsign.Visible = false;
                                        div_prepare.Visible = false;
                                        div_approve.Visible = false;
                                        lbl_remarks.Text = dt.Rows[0]["remarks"].ToString().ToUpper();
                                        //lbl_total.Text = Convert.ToDouble(Request.QueryString["total"]).ToString("#,0.00");
                                        bool isDouble1 = Double.TryParse(lbl_total.Text, out price);
                                        if (isDouble1)
                                        {
                                            //lbl_currword.Text = th_basecurr.InnerText + " " + ConvertNumbertoWords(Convert.ToInt32(price)) + " ONLY";
                                            if (customertype == "P")
                                            {
                                                if (curr_count == 1)
                                                {
                                                    if (currency == "INR")
                                                    {
                                                        currency = " RUPEES";
                                                    }

                                                    lbl_currword.Text = currency + " " + conversion(total_agent.Text, "") + " ONLY";
                                                }
                                                else
                                                {
                                                    lbl_currword.Text = "USD" + " " + conversion(total_agent.Text, "") + " ONLY";
                                                }

                                            }
                                            else
                                            {
                                                //  lbl_currword.Text = th_basecurr.InnerText + "  : " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                                                lbl_currword.Text = " RUPEES " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";

                                            }
                                        }
                                    }

                                    if (str_trantype == "CH" || str_trantype == "AI")
                                    {
                                        //div_between.Visible = false;
                                        //div_invoice.Visible = true;
                                        div_bank.Visible = false;
                                        //div_bottomsign.Visible = false;
                                    }

                                    DataTable dtLi = new DataTable();
                                    DataView data1 = dt.DefaultView;
                                    data1.RowFilter = "groupid = '" + 1 + "' ";
                                    dtLi = data1.ToTable();
                                    row_count = 0;
                                    count = dtLi.Rows.Count;
                                    if (str_trantype == "BT")
                                    {
                                        for (int i = 0; i < dtLi.Rows.Count; i++)
                                        {
                                            if (string.IsNullOrEmpty(dtLi.Rows[i]["percentage"].ToString()))
                                            {
                                                tr_row.Text += " <tr style=''>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:282x;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                                if (str_trantype == "AE" || str_trantype == "AI")
                                                {
                                                    // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";


                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";//.Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG")
                                                }
                                                else
                                                {
                                                    // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";


                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px; white-space:nowrap;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                                {
                                                    temp_taxable += Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString().ToUpper());
                                                    tr_row.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; width: 100px; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["CGSTP"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["cgsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    cgsta += Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dtLi.Rows[i]["sgstp"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["sgsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    sgsta += Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    igsta += Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";
                                                row_count += 1;
                                            }
                                        }
                                        int check_loop = 0;
                                        for (int i = 0; i < dtLi.Rows.Count; i++)
                                        {
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["percentage"].ToString()) || dtLi.Rows[i]["percentage"].ToString() == "0")
                                            {
                                                tr_row.Text += " <tr style=''>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:60px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString() + "</label></td>";
                                                if (str_trantype == "AE" || str_trantype == "AI")
                                                {
                                                    // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";

                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                                }//.Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG")
                                                else
                                                {
                                                    //  tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";



                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                                }

                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                                {
                                                    temp_taxable += Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString().ToUpper());
                                                    tr_row.Text += "<td style='color:#000000; width: 100PX; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; width: 100px; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["CGSTP"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["cgsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    cgsta += Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dtLi.Rows[i]["sgstp"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["sgsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    sgsta += Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    igsta += Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";
                                                row_count += 1;
                                                check_loop = 1;
                                            }
                                            if (str_trantype == "OE" || str_trantype == "OI")
                                            {
                                                if ((cont_ > 36 && i > count + 29) || (cont_ > 90 && i > count + 11) || (cont_ > 120 && i > count + 9))
                                                {
                                                    count = i;
                                                    str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                    break;
                                                }
                                            }
                                        }

                                        DataTable dtLi1 = new DataTable();
                                        DataView data2 = dt.DefaultView;
                                        data2.RowFilter = "groupid <> '" + 1 + "' and groupid <> '" + 5 + "'";
                                        dtLi1 = data2.ToTable();
                                        double total_tax = 0;

                                        dt = obj_inv.get_tdspayable(invoice, bid, vouyear, "P");
                                        if (dt.Rows.Count > 0)
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                            row_count += 1;

                                            tr_row.Text += " <tr style=''>";
                                            if (dt.Rows.Count > 0)
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; '>TDS PAYABLE " + dt.Rows[0]["tdsdesc"].ToString() + " Rs. " + Convert.ToDouble(dt.Rows[0]["tdsamount"].ToString()).ToString("#,0.00") + "</label></td>";

                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                            row_count += 1;
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
                                    else
                                    {
                                        for (int i = 0; i < dtLi.Rows.Count; i++)
                                        {
                                            if (string.IsNullOrEmpty(dtLi.Rows[i]["percentage"].ToString()))
                                            {
                                                tr_row.Text += " <tr style=''>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                                if (str_trantype == "AE" || str_trantype == "AI")
                                                {

                                                    //  tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";

                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                                }//.Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") 
                                                else
                                                {
                                                    // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";

                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                                }

                                                //  tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";

                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left; '>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.000") + "</label></td>";


                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                                {
                                                    temp_taxable += Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString().ToUpper());
                                                    tr_row.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; width: 100px; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["CGSTP"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["cgsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    cgsta += Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dtLi.Rows[i]["sgstp"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["sgsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    sgsta += Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    igsta += Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";
                                                row_count += 1;
                                            }
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
                                        if (Request.QueryString.ToString().Contains("cont_count"))
                                        {
                                            cont_count = Convert.ToInt32(Request.QueryString["cont_count"].ToString());
                                        }
                                        else
                                        {
                                            cont_count = 0;
                                        }
                                        DataTable DT_cont = new DataTable();
                                        DT_cont = obj_inv.get_containerdetails(jobno, bid, blno, str_trantype, bltype);
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
                                        int check_loop = 0;
                                        for (int i = 0; i < dtLi.Rows.Count; i++)
                                        {
                                            if (!string.IsNullOrEmpty(dtLi.Rows[i]["percentage"].ToString()) || dtLi.Rows[i]["percentage"].ToString() == "0")
                                            {
                                                tr_row.Text += " <tr style=''>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                                if (str_trantype == "AE" || str_trantype == "AI")
                                                {
                                                    // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";


                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";


                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";//.Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG")
                                                }
                                                else
                                                {
                                                    //   tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";

                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";

                                                }
                                                //   tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";

                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.000") + "</label></td>";

                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                                {
                                                    temp_taxable += Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString().ToUpper());
                                                    tr_row.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#2c2b2b; width: 100px; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["CGSTP"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["cgsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    cgsta += Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dtLi.Rows[i]["sgstp"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["sgsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    sgsta += Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                                if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                                    igsta += Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString());
                                                }
                                                else
                                                {
                                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                                }
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";

                                                row_count += 1;
                                                check_loop = 1;


                                            }
                                            if (str_trantype == "OE" || str_trantype == "OI")
                                            {
                                                if ((cont_ > 36 && i > count + 29) || (cont_ > 90 && i > count + 11) || (cont_ > 120 && i > count + 9))
                                                {
                                                    count = i;
                                                    str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                    break;
                                                }
                                            }
                                        }


                                        DataTable dtLi1 = new DataTable();
                                        DataView data2 = dt.DefaultView;
                                        data2.RowFilter = "groupid <> '" + 1 + "' and groupid <> '" + 5 + "'";
                                        dtLi1 = data2.ToTable();
                                        double total_tax = 0;

                                        dt = obj_inv.get_tdspayable(invoice, bid, vouyear, "P");
                                        if (dt.Rows.Count > 0)
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                            row_count += 1;

                                            tr_row.Text += " <tr style=''>";
                                            if (dt.Rows.Count > 0)
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; '>TDS PAYABLE " + dt.Rows[0]["tdsdesc"].ToString() + " Rs. " + Convert.ToDouble(dt.Rows[0]["tdsamount"].ToString()).ToString("#,0.00") + "</label></td>";

                                            }
                                            else
                                            {
                                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            }
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                            row_count += 1;
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




                                if (str_trantype == "BT")
                                {
                                    for (int i = row_count; i < 36; i++)
                                    {
                                        tr_row.Text += " <tr style=''>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 0px solid Black;'>&nbsp;</td></tr>";

                                    }
                                }
                                else
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                {

                                    for (int i = row_count + _line; i < 30; i++)
                                    {
                                        tr_row.Text += " <tr style=''>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 0px solid Black;'>&nbsp;</td></tr>";
                                    }
                                }
                                else if (str_trantype == "AE" || str_trantype == "AI" || str_trantype == "CH")
                                {
                                    if (str_trantype == "CH")
                                    {
                                        for (int i = row_count; i < 35; i++)
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 0px solid Black;'>&nbsp;</td></tr>";
                                        }
                                    }
                                    else
                                    {
                                        for (int i = row_count; i < 36; i++)
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//<label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString() + "</label>
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 0px solid Black;'>&nbsp;</td></tr>";
                                        }
                                    }

                                }


                            }
                        }
                    }
                    // else  if (Request.QueryString["voutype"].ToString() == "1" ||Request.QueryString["voutype"].ToString() == "20" ||Request.QueryString["voutype"].ToString() == "22" ||Request.QueryString["voutype"].ToString() == "24")
                    else if (Request.QueryString["header"].ToString() == "Invoice" || Request.QueryString["header"].ToString() == "Bill of Supply" || Request.QueryString["header"].ToString() == "Invoice FC" || Request.QueryString["header"].ToString() == "Bill of Supply FC")
                    {
                        //lbl_total.Text = Convert.ToDouble(Request.QueryString["total"]).ToString("#,0.00");


                        //   div_grw.Visible = true;
                        //table_invoice.Visible = true;
                        //table_cn.Visible = false;
                      //  div_cont.Visible = true;
                        remarks.Visible = true;

                        if (Request.QueryString.ToString().Contains("bltype"))
                        {
                            DataTable dt12 = new DataTable();
                            bltype = Request.QueryString["bltype"].ToString();
                            if (Profoma == "")
                            {
                                if (Request.QueryString["header"].ToString() == "Bill of Supply" || Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                {
                                    lbl_head.Text = "Bill of Supply";
                                    //  label_invoice.InnerText = "BOS";
                                    LBLNO.InnerText = "BOS #";
                                }
                                else
                                {
                                    if (Request.QueryString["header"].ToString() == "Invoice FC")
                                    {
                                        lbl_head.Text = "TAX INVOICE OC";
                                    }
                                    else
                                    {
                                        lbl_head.Text = "TAX INVOICE";
                                        if (Session["countryid"].ToString()=="1102"|| Session["countryid"].ToString() == "102")
                                        {
                                            sign.Visible = true;
                                        }
                                    }

                                }

                                dt12 = obj_inv.sp_getinvoiceno(bid, str_trantype, invoice, vouyear, Request.QueryString["header"].ToString());
                                if (dt12.Rows.Count > 0)
                                {
                                    //div3.Visible = true;
                                    //Label3.Text = dt12.Rows[0]["invbookingno"].ToString();
                                }


                            }
                            else
                            {
                                if (Request.QueryString["header"].ToString() == "Invoice FC")
                                {
                                    lbl_head.Text = "PROFORMA SALES INVOICE OC";
                                }
                                else
                                {
                                    lbl_head.Text = "PROFORMA SALES INVOICE";
                                }



                                dt12 = obj_inv.sp_getinvoiceno(bid, str_trantype, invoice, vouyear, Request.QueryString["header"].ToString());
                                if (dt12.Rows.Count > 0)
                                {
                                    //div3.Visible = true;
                                    //Label3.Text = dt12.Rows[0]["invbookingno"].ToString();
                                }
                            }



                            if (bltype == "M")
                            {


                                lbl_blname.Visible = false;
                                lbl_bl.Visible = false;
                                lbl_pack.Visible = false;
                                lbl_package.Visible = false;
                                lbl_gw.Visible = false;
                                lbl_grwt.Visible = false;
                                div_volume.Visible = false;
                                //div_between.Visible = false;
                                div_ship.Visible = false;
                                if (Request.QueryString["header"].ToString() == "Bill of Supply" || Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                {
                                    if (Request.QueryString["header"].ToString() == "Bill of Supply")
                                    {
                                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                    }
                                    else if (Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                    {
                                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                    }
                                    if (Request.QueryString["header"].ToString() == "Bill of Supply" || Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                    {
                                        //div_vendorref.Visible = true;
                                        lbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();


                                        //div_vendorrefdate.Visible = true;
                                        if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                                        {
                                            lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                                        }
                                        else
                                        {
                                            lbl_vendordate.Text = "";
                                        }
                                    }
                                }
                                else
                                {
                                    if (Request.QueryString["header"].ToString() == "Invoice FC")
                                    {
                                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                    }
                                    else
                                    {
                                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                    }
                                    //   dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, "Invoice", "", Profoma);
                                    if (Request.QueryString["header"].ToString() == "Invoice" || Request.QueryString["header"].ToString() == "Invoice FC")
                                    {

                                        //div_vendorref.Visible = true;
                                        lbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();
                                        
                                        DataTable dtlogo = obj_inv.GETsign4invoice();
                                        if (dtlogo.Rows.Count > 0)
                                        {
                                            byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["sign"]);
                                            string base64String = Convert.ToBase64String(logoimageBytes);
                                            imgsign.ImageUrl = "data:image/png;base64," + base64String;
                                        }


                                        //div_vendorrefdate.Visible = true;
                                        if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                                        {
                                            lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                                        }
                                        else
                                        {
                                            lbl_vendordate.Text = "";
                                        }
                                    }
                                }
                                //dt12 = obj_inv.sp_getinvoiceno(bid, str_trantype, invoice, vouyear, Request.QueryString["header"].ToString());
                                //if (dt12.Rows.Count>0)
                                //{
                                //    //div3.Visible = true;
                                //    //Label3.Text = dt12.Rows[0]["invbookingno"].ToString();
                                //}
                                if (dt.Rows.Count > 0)
                                {
                                    if (Profoma == "Profoma")
                                    {
                                        if (!string.IsNullOrEmpty(dt.Rows[0]["preparedby"].ToString()))
                                        {
                                            lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                        }
                                        if (dt.Columns.Contains("ApprovedBy1"))
                                        {
                                            if (!string.IsNullOrEmpty(dt.Rows[0]["ApprovedBy1"].ToString()))
                                            {
                                                lbl_approved.Text = dt.Rows[0]["ApprovedBy1"].ToString();
                                            }
                                        }
                                        else if (dt.Columns.Contains("ApprovedBy"))
                                        {
                                            if (!string.IsNullOrEmpty(dt.Rows[0]["ApprovedBy"].ToString()))
                                            {
                                                lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(dt.Rows[0]["preparedby"].ToString()))
                                        {
                                            lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                        }
                                        if (dt.Columns.Contains("ApprovedBy1"))
                                        {
                                            if (!string.IsNullOrEmpty(dt.Rows[0]["ApprovedBy1"].ToString()))
                                            {
                                                lbl_approved.Text = dt.Rows[0]["ApprovedBy1"].ToString();
                                            }
                                        }
                                        else if (dt.Columns.Contains("ApprovedBy"))
                                        {
                                            if (!string.IsNullOrEmpty(dt.Rows[0]["ApprovedBy"].ToString()))
                                            {
                                                lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                                            }
                                        }
                                    }
                                    //if (!string.IsNullOrEmpty(dt.Rows[0]["exrate"].ToString()))
                                    //{
                                    //    lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                    //}

                                    if (Profoma == "")
                                    {
                                        lbl_total.Text = Convert.ToDouble(dt.Rows[0]["total"].ToString()).ToString("#,0.00");
                                    }
                                    //exrate = 0;
                                    //for (int i = 0; i < dt.Rows.Count; i++)
                                    //{
                                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                    //    {
                                    //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                    //        {
                                    //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                    //        }
                                    //    }
                                    //}
                                    //if (exrate > 0)
                                    //{
                                    //    lbl_exrate.Text = exrate.ToString("#,0.0000");
                                    //}
                                    DataView dv_curr = new DataView(dt);
                                    Dt_sort = dv_curr.ToTable(true, "curr");
                                    dv_curr = new DataView(Dt_sort);
                                    dv_curr.Sort = "curr";
                                    Dt_sort = dv_curr.ToTable();
                                    lbl_exrate.Text = "";
                                    curr_count = Dt_sort.Rows.Count;
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
                                                lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                            else
                                            {
                                                lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                        }
                                    }
                                    jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                                    lbl_ourjob.Text = dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["jobno"].ToString();
                                    if (dt.Rows[0]["shortname"].ToString().Length > 0)
                                    {
                                        branch_inv = dt.Rows[0]["shortname"].ToString().Split('-');
                                        if (branch_inv.Length > 0)
                                        {
                                            branch_invoice = branch_inv[1].ToString();
                                        }
                                    }



                                    if (str_trantype == "OI")
                                    {
                                        div_id = 1;
                                        dtobl = da_obj_jobinfo.ShowJobDetails(jobno, bid, div_id);

                                        if (dtobl.Rows.Count > 0)
                                        {
                                            if (string.IsNullOrEmpty(dtobl.Rows[0]["obldate"].ToString()) == true)
                                            {
                                                //lbl_obl.Text = "";
                                            }
                                            else
                                            {
                                                // txt_obldate.Text = dtobl.Rows[0]["obldate"].ToString();

                                                //lbl_obl.Text = dtobl.Rows[0]["obl"].ToString().ToUpper() + "  " + "<strong><b>DT : </b></strong>" + dtobl.Rows[0]["obldate"].ToString();



                                            }
                                            //if (string.IsNullOrEmpty(dtobl.Rows[0]["obl"].ToString()) == true)
                                            //{
                                            //    txt_obl.Text = "";
                                            //}
                                            //else
                                            //{
                                            //    txt_obl.Text = dtobl.Rows[0]["obl"].ToString();


                                            //}
                                        }
                                    }

                                    string invno = invoice.ToString();
                                    // panno =Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
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

                                    if (Profoma == "Profoma")
                                    {
                                        if (Request.QueryString["header"].ToString() == "Invoice")
                                        {
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "SI" + "/" + invno + "/" + invoice.ToString();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                        {
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "SO" + "/" + invno + "/" + invoice.ToString();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "PA FC")
                                        {
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "PO" + "/" + invno + "/" + invoice.ToString();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "PA")
                                        {
                                            lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "PI" + "/" + invno + "/" + invoice.ToString();

                                        }
                                    }
                                    else
                                    {

                                        if (Request.QueryString["header"].ToString() == "Bill of Supply")
                                        {
                                            lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "BS" + invno + invoice.ToString();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                        {
                                            lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "BO" + invno + invoice.ToString();

                                        }
                                        else if (Request.QueryString["header"].ToString() == "Invoice")
                                        {
                                            lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "SI" + invno + invoice.ToString();

                                        }



                                        else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                        {
                                            lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "SO" + invno + invoice.ToString();

                                        }

                                    }



                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString().ToUpper() + " V " + dt.Rows[0]["voyage"].ToString().ToUpper();
                                        div_cont.Visible = true;
                                    }
                                    else if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        label_vessel.InnerText = "Flight";
                                        lbl_vessel.Text = dt.Rows[0]["flightno"].ToString().ToUpper() + " V " + Convert.ToDateTime(dt.Rows[0]["flightdate"].ToString()).ToString("dd/MMM/yyyy");
                                    }
                                    if (str_trantype == "OI" || str_trantype == "AI")
                                    {
                                        lbl_port.InnerText = "P O L";
                                        ////lbl_port1.InnerText = "P O D";
                                    }
                                    if ((str_trantype == "AE" && bltype == "M") || (str_trantype == "AI" && bltype == "M"))
                                    {
                                        lbl_port.InnerText = "P O L";
                                        ////lbl_port1.InnerText = "P O D";
                                    }
                                    lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd/MM/yyyy");
                                    lbl_mbl.Text = dt.Rows[0]["mblno"].ToString().ToUpper();
                                    //blno = dt.Rows[0]["blno"].ToString();
                                    if (dt.Columns.Contains("mpolname"))
                                    {
                                        lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper() + " / " + dt.Rows[0]["mpodname"].ToString().ToUpper();
                                    }
                                    else
                                    {
                                        div_port.Visible = false;
                                        lbl_pod.Text = "";
                                    }

                                    if (dt.Columns.Contains("mpodname"))
                                    {
                                        //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                    }
                                    else
                                    {
                                        div_port1.Visible = false;
                                        ////lbl_pod1.Text = "";
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
                                        //FALedger.Visible = true;
                                        //lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                                    }

                                    //Bank Details
                                    lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                    lbl_favouring.Text = dt.Rows[0]["favouring"].ToString().ToUpper();
                                    lbl_ifsccode.Text = dt.Rows[0]["swiftcode"].ToString().ToUpper();
                                    lbl_bankname.Text = dt.Rows[0]["bankname"].ToString().ToUpper();
                                    lbl_bankaddress.Text = dt.Rows[0]["bankaddress"].ToString().ToUpper();
                                    lbl_remarks.Text = dt.Rows[0]["remarks"].ToString().ToUpper().ToUpper();
                                }

                            }
                            else if (bltype == "H")
                            {
                                if (Request.QueryString["header"].ToString() == "Bill of Supply" || Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                {
                                    if (Request.QueryString["header"].ToString() == "Bill of Supply")
                                    {
                                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                    }
                                    else if (Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                    {
                                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                    }
                                    if (Request.QueryString["header"].ToString() == "Bill of Supply" || Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                    {
                                        //div_vendorref.Visible = true;
                                        //llbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();


                                        //div_vendorrefdate.Visible = true;
                                        if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                                        {
                                            lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                                        }
                                        else
                                        {
                                            lbl_vendordate.Text = "";
                                        }
                                    }
                                }
                                else
                                {
                                    if (Request.QueryString["header"].ToString() == "Invoice FC")
                                    {
                                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                    }
                                    else
                                    {
                                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), "", Profoma);
                                    }
                                    if (Request.QueryString["header"].ToString() == "Invoice" || Request.QueryString["header"].ToString() == "Invoice FC")
                                    {

                                        //div_vendorref.Visible = true;
                                        lbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();

                                        DataTable dtlogo = obj_inv.GETsign4invoice();
                                        if (dtlogo.Rows.Count > 0)
                                        {
                                            byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["sign"]);
                                            string base64String = Convert.ToBase64String(logoimageBytes);
                                            imgsign.ImageUrl = "data:image/png;base64," + base64String;
                                        }
                                        //div_vendorrefdate.Visible = true;
                                        if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                                        {
                                            lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                                        }
                                        else
                                        {
                                            lbl_vendordate.Text = "";
                                        }
                                    }
                                }
                                div_cnops.Visible = true;
                                if (dt.Rows.Count > 0)
                                {
                                    if (!string.IsNullOrEmpty(dt.Rows[0]["preparedby"].ToString()))
                                    {
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                    }

                                    if (Profoma == "Profoma")
                                    {
                                        if (!string.IsNullOrEmpty(dt.Rows[0]["ApprovedBy"].ToString()))
                                        {
                                            lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                                            lbl_approved.Visible = false;
                                            // lbl_head.Text = "PROFORMO INVOICE";

                                            if (Request.QueryString["header"].ToString() == "Invoice FC")
                                            {
                                                lbl_head.Text = "Proforma Sales Invoice OC";
                                            }
                                            else
                                            {

                                                lbl_head.Text = "Proforma Sales Invoice";
                                                //lbl_head.Text = "Proforma Tax Invoice";
                                                divinvtype.InnerText = "Ref #";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dt.Columns.Contains("ApprovedBy1"))
                                        {
                                            if (!string.IsNullOrEmpty(dt.Rows[0]["ApprovedBy1"].ToString()))
                                            {
                                                lbl_approved.Text = dt.Rows[0]["ApprovedBy1"].ToString();
                                            }
                                        }
                                        if (dt.Columns.Contains("ApprovedBy"))
                                        {
                                            if (!string.IsNullOrEmpty(dt.Rows[0]["ApprovedBy"].ToString()))
                                            {
                                                lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                                            }
                                        }
                                    }
                                    //if (!string.IsNullOrEmpty(dt.Rows[0]["exrate"].ToString()))
                                    //{
                                    //    lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                    //}

                                    if (Profoma == "")
                                    {
                                        lbl_total.Text = Convert.ToDouble(dt.Rows[0]["total"].ToString()).ToString("#,0.00");
                                    }
                                    //exrate = 0;
                                    //for (int i = 0; i < dt.Rows.Count; i++)
                                    //{
                                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                    //    {
                                    //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                    //        {
                                    //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                    //        }
                                    //    }
                                    //}
                                    //if (exrate > 0)
                                    //{
                                    //    lbl_exrate.Text = exrate.ToString("#,0.0000");
                                    //}
                                    DataView dv_curr = new DataView(dt);
                                    Dt_sort = dv_curr.ToTable(true, "curr");
                                    dv_curr = new DataView(Dt_sort);
                                    dv_curr.Sort = "curr";
                                    Dt_sort = dv_curr.ToTable();
                                    lbl_exrate.Text = "";
                                    curr_count = Dt_sort.Rows.Count;
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
                                                lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                            else
                                            {
                                                lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                        }
                                    }
                                    jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                                    //lbl_ourjob.Text = dt.Rows[0]["shortname"].ToString().ToUpper() + " / " + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + dt.Rows[0]["jobno"].ToString().ToUpper();

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

                                    if (dt.Rows[0]["shortname"].ToString().Length > 0)
                                    {
                                        branch_inv = dt.Rows[0]["shortname"].ToString().Split('-');
                                        if (branch_inv.Length > 0)
                                        {
                                            branch_invoice = branch_inv[1].ToString();
                                        }
                                    }

                                    if (str_trantype == "OI")
                                    {
                                        div_id = 1;
                                        dtobl = da_obj_jobinfo.ShowJobDetails(jobno, bid, div_id);

                                        if (dtobl.Rows.Count > 0)
                                        {
                                            if (string.IsNullOrEmpty(dtobl.Rows[0]["obldate"].ToString()) == true)
                                            {
                                                //lbl_obl.Text = "";
                                            }
                                            else
                                            {
                                                // txt_obldate.Text = dtobl.Rows[0]["obldate"].ToString();

                                                //lbl_obl.Text = dtobl.Rows[0]["obl"].ToString().ToUpper() + "  " + "<strong><b>DT : </b></strong>" + dtobl.Rows[0]["obldate"].ToString();



                                            }
                                            //if (string.IsNullOrEmpty(dtobl.Rows[0]["obl"].ToString()) == true)
                                            //{
                                            //    txt_obl.Text = "";
                                            //}
                                            //else
                                            //{
                                            //    txt_obl.Text = dtobl.Rows[0]["obl"].ToString();


                                            //}
                                        }
                                    }


                                    string invno = invoice.ToString();
                                    // panno =Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
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
                                    if (dt.Rows[0]["Branchwisevouchertype"].ToString() == "Y")
                                    {
                                        if (Profoma == "Profoma")
                                        {

                                            if (Request.QueryString["header"].ToString() == "Invoice")
                                            {
                                                lbl_invoice.Text = "SI" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                            {
                                                lbl_invoice.Text = "SO" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "PA")
                                            {
                                                lbl_invoice.Text = "PI" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "PA FC")
                                            {
                                                lbl_invoice.Text = "PO" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + invoice.ToString();

                                            }
                                        }
                                        else
                                        {
                                            if (Request.QueryString["header"].ToString() == "Bill of Supply")
                                            {
                                                lbl_invoice.Text = "BS" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                            {
                                                lbl_invoice.Text = "BO" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                            {


                                                lbl_invoice.Text = "SO" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + invoice.ToString();

                                            }
                                            else
                                            {
                                                lbl_invoice.Text = "SI" + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "/" + invno + invoice.ToString();

                                            }
                                        }

                                    }


                                    else
                                    {
                                        if (Profoma == "Profoma")
                                        {

                                            if (Request.QueryString["header"].ToString() == "Invoice")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "SI" + "/" + invno + "/" + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "SO" + "/" + invno + "/" + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "PA")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "PI" + "/" + invno + "/" + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "PA FC")
                                            {
                                                lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "PO" + "/" + invno + "/" + invoice.ToString();

                                            }
                                        }
                                        else
                                        {
                                            if (Request.QueryString["header"].ToString() == "Bill of Supply")
                                            {
                                                lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "BS" + invno + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "Bill of Supply FC")
                                            {
                                                lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "BO" + invno + invoice.ToString();

                                            }
                                            else if (Request.QueryString["header"].ToString() == "Invoice FC")
                                            {


                                                lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "SO" + invno + invoice.ToString();

                                            }
                                            else
                                            {
                                                lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "SI" + invno + invoice.ToString();

                                            }
                                        }
                                    }


                                    jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                                    if (str_trantype == "OE" || str_trantype == "OI")
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

                                        lbl_port.InnerText = "P O L";
                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper() + " / " + dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }

                                        ////lbl_port1.InnerText = "P O D";
                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            ////lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            ////lbl_pod1.Text = "";
                                        }
                                    }
                                    if (str_trantype == "BT")
                                    {
                                        label_vessel.InnerText = "Truck #";
                                        lbl_vessel.Text = dt.Rows[0]["blno"].ToString().ToUpper();
                                        tr_cont.Visible = false;
                                        tr_contdetail.Visible = false;
                                        div_pack.Visible = true;
                                        //div_bottomsign.Visible = false;
                                    }
                                    lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd/MM/yyyy");

                                    if (str_trantype == "CH")
                                    {
                                        lbl_blname.InnerText = "Doc #";
                                        lbl_bl.Text = dt.Rows[0]["docno"].ToString().ToUpper();
                                        lbl_mblname.InnerText = "Date";
                                        lbl_mbl.Text = dt.Rows[0]["docdate"].ToString().ToUpper();
                                        div_volume.Visible = false;
                                        div_port.Visible = false;
                                        div_port1.Visible = false;
                                        tr_cont.Visible = false;
                                        tr_contdetail.Visible = false;
                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper() + " / " + dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }

                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }

                                    }
                                    else if (str_trantype != "BT")
                                    {
                                        lbl_bl.Text = dt.Rows[0]["blno"].ToString().ToUpper();
                                    }

                                    if (str_trantype == "OI")
                                    {
                                        div_id = 1;
                                        dtobl = da_obj_jobinfo.ShowJobDetails(jobno, bid, div_id);

                                        if (dtobl.Rows.Count > 0)
                                        {
                                            if (string.IsNullOrEmpty(dtobl.Rows[0]["obldate"].ToString()) == true)
                                            {
                                                //lbl_obl.Text = "";
                                            }
                                            else
                                            {
                                                // txt_obldate.Text = dtobl.Rows[0]["obldate"].ToString();

                                                //lbl_obl.Text = dtobl.Rows[0]["obl"].ToString().ToUpper() + "  " + "<strong><b>DT : </b></strong>" + dtobl.Rows[0]["obldate"].ToString();



                                            }
                                            //if (string.IsNullOrEmpty(dtobl.Rows[0]["obl"].ToString()) == true)
                                            //{
                                            //    txt_obl.Text = "";
                                            //}
                                            //else
                                            //{
                                            //    txt_obl.Text = dtobl.Rows[0]["obl"].ToString();


                                            //}
                                        }
                                    }


                                    if (str_trantype == "OE")
                                    {
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        lbl_port.InnerText = "P O R / P O L";

                                        //lbl_port.InnerText = "P O L"; hid as per nambi sir instruction on 29 mar 2022

                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper() + " / " + dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }
                                        // ////lbl_port1.InnerText = "P O D"; hid as per nambi sir instruction on 29 mar 2022

                                        ////lbl_port1.InnerText = "P O D / FD";
                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            // lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }
                                        lbl_mbl.Text = dt.Rows[0]["mblno"].ToString().ToUpper();
                                        //lbl_igm.Visible = false;
                                        //lbl_line.Visible = false;
                                        div_cont.Visible = true;

                                    }
                                    else if (str_trantype == "OI")
                                    {
                                        tr_contdetail.Attributes["class"] = "MINHeight";
                                        //div_igm.Visible = true;
                                        //lbl_dt.Text = "DT :" + dt.Rows[0]["pod"].ToString();
                                        lbl_mbl.Text = dt.Rows[0]["mblno"].ToString().ToUpper() + "  " + "<strong><b>DT : </b></strong>" + Convert.ToDateTime(dt.Rows[0]["mbldate"].ToString()).ToString("dd/MM/yyyy");
                                        //lbl_port.InnerText = "PoL/FD";
                                        // B HIDE   lbl_port.InnerText = "P O R / P O L";/// B HIDE

                                        lbl_port.InnerText = "P O R / P O L";

                                        //lbl_port.InnerText = "P O L"; hid as per nambi sir instruction on 29 mar 2022

                                        lbl_pod.Text = dt.Rows[0]["pol"].ToString().ToUpper() + " / " + dt.Rows[0]["fd"].ToString().ToUpper();
                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            // B HIDE  lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper(); // BHIDE
                                            lbl_pod.Text = dt.Rows[0]["pol"].ToString().ToUpper() + " / " + dt.Rows[0]["fd"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }
                                        // ////lbl_port1.InnerText = "P O D"; hid as per nambi sir instruction on 29 mar 2022

                                        //lbl_port1.InnerText = "P O D / FD"; 

                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";

                                        }
                                        //div_fiinvoice.Visible = true;
                                        //lbl_igm.Visible = true;
                                        //lbl_line.Visible = true;
                                        //lbl_igm.Text = dt.Rows[0]["imno"].ToString().ToUpper() + " & " + Convert.ToDateTime(dt.Rows[0]["imdate"].ToString()).ToString("dd/MM/yyyy");
                                        //lbl_line.Text = dt.Rows[0]["linenumber"].ToString().ToUpper() + " / " + dt.Rows[0]["sublineno"].ToString().ToUpper();
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        div_cont.Visible = true;

                                    }
                                    else if (str_trantype == "AE" || str_trantype == "AI")
                                    {

                                        //Dinesh
                                        lbl_blname.InnerText = "HAWB #";
                                        lbl_mblname.InnerText = "MAWB #";
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        //lbl_port.InnerText = "P O D";

                                        lbl_port.InnerText = "P O L";

                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }
                                        //lbl_port1.InnerText = "P O D";

                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper() + " / " + dt.Rows[0]["mpodname"].ToString().ToUpper();
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }
                                        lbl_mbl.Text = dt.Rows[0]["mawblno"].ToString().ToUpper();
                                        //lbl_igm.Visible = false;
                                        //lbl_line.Visible = false;
                                        tr_cont.Visible = false;
                                        tr_contdetail.Visible = false;
                                    }
                                    if (str_trantype == "CH")
                                    {
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " PKG";
                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_port.InnerText = "P O L";
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }

                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            //lbl_port1.InnerText = "P O D";
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }
                                    }
                                    else if (str_trantype == "BT")
                                    {
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString().ToUpper();
                                        div_bl.Visible = false;
                                        div_mbl.Visible = false;
                                        div_port.Visible = false;
                                        div_port1.Visible = false;
                                        lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString().ToUpper();
                                        lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["cbm"].ToString()).ToString("#0.000") + " cbm";
                                    }
                                    else
                                    {
                                        lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString().ToUpper();
                                    }

                                    lbl_grwt.Text = (Convert.ToDouble(dt.Rows[0]["grweight"].ToString())).ToString("#0.00") + " Kgs";
                                    if (str_trantype == "BT")
                                    {
                                        div_ship.Visible = false;
                                        //para_notBT.Visible = false;
                                        div_bank.Visible = false;
                                        //tr_roundup.Visible = false;
                                        //tr_forround.Visible = true;
                                        tr_roundup.InnerText = "";
                                        lbl_roundup.Text = "";
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
                                        //FALedger.Visible = true;
                                        //lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                                    }
                                    lbl_remarks.Text = dt.Rows[0]["remarks"].ToString().ToUpper().ToUpper();

                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        jobtype = dt.Rows[0]["jobtype"].ToString().ToUpper();
                                        if (jobtype != "")
                                        {
                                            if (jobtype == "3")
                                            {
                                                DataTable dtnew1 = new DataTable();

                                                if (Request.QueryString.ToString().Contains("blno"))
                                                {
                                                    blno = blno = Request.QueryString["blno"].ToString().ToUpper();
                                                    dtnew1 = obj_inv.getsizetype(blno, jobno, bid, str_trantype);
                                                }

                                                if (dtnew1.Rows.Count > 0)
                                                {
                                                    lbl_volume.Text = dtnew1.Rows[0]["size"].ToString().ToUpper().ToUpper();
                                                }
                                                else
                                                {
                                                    //lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                    if (dt.Rows[0]["cont40"].ToString() != "0" && dt.Rows[0]["cont20"].ToString() != "0")
                                                    {
                                                        lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                    }
                                                    else if (dt.Rows[0]["cont40"].ToString() != "0")
                                                    {
                                                        lbl_volume.Text = dt.Rows[0]["cont40"].ToString() + " x 40' ";
                                                    }
                                                    else if (dt.Rows[0]["cont20"].ToString() != "0")
                                                    {
                                                        lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ";
                                                    }
                                                }
                                                // lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                //if (dt.Rows[0]["cont40"].ToString() != "0" && dt.Rows[0]["cont20"].ToString() != "0")
                                                //{
                                                //    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                //}
                                                //else if (dt.Rows[0]["cont40"].ToString() != "0")
                                                //{
                                                //    lbl_volume.Text = dt.Rows[0]["cont40"].ToString() + " x 40' ";
                                                //}
                                                //else if (dt.Rows[0]["cont20"].ToString() != "0")
                                                //{
                                                //    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ";
                                                //}

                                            }
                                            else
                                            {
                                                volume = Convert.ToDouble(dt.Rows[0]["cbm"].ToString());
                                                lbl_volume.Text = volume.ToString("#0.000") + " / " + "LCL";
                                            }
                                        }

                                    }
                                    if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        lable_volume.InnerText = "Charge Wght";
                                        lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["chargewt"].ToString()).ToString("#0.00") + " Kgs";
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
                            //else if(dt.Rows.Count>4)
                            //{
                            //    cont_ = dt.Rows.Count;
                            //    _line = Convert.ToInt32(dt.Rows.Count / 4);
                            //    _line -= 2;
                            //}
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
                        //if (Request.QueryString["header"].ToString() == "Bill of Supply")
                        //{
                        dt = obj_inv.GetLVdetailsgrid(invoice, bid, vouyear, str_trantype, Profoma, Convert.ToInt32(Request.QueryString["voutype"].ToString()));
                        //}
                        //else if (Request.QueryString["header"].ToString() == "Bill of Supply FC")
                        //{
                        //    dt = obj_inv.GetLVdetailsgrid(invoice, bid, vouyear, str_trantype, Profoma);
                        //}
                        //else if (Request.QueryString["header"].ToString() == "Invoice FC")
                        //{
                        //    dt = obj_inv.GetLVdetailsgrid(invoice, bid, vouyear, str_trantype, Profoma);
                        //}
                        //else
                        //{
                        //    dt = obj_inv.GetLVdetailsgrid(invoice, bid, vouyear, str_trantype, Profoma);
                        //}


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

                                total = Convert.ToDouble(total);
                                lbl_total.Text = Convert.ToDouble(total).ToString("#,0.00");
                            }
                            html = "";
                            for (int i = count; i < dt.Rows.Count; i++)
                            {
                                //i = count;
                                tr_row.Text += " <tr style=''>";
                                tr_row.Text += "<td style='color:#000000; padding:0px 8px 0px 0px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dt.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dt.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";

                                if (str_trantype == "AE" || str_trantype == "AI")
                                {
                                    //  tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dt.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";


                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dt.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                }// .Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG")
                                else
                                {
                                    //bb hide
                                    //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["base"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'></label></td>";
                                    //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'></label></td>";
                                    //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["Rate"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'></label></td>";



                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dt.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                    //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["Rate"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'></label></td>";




                                    //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";





                                    //tr_row.text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + convert.todouble(dt.rows[i]["unit"].tostring()).tostring("#0.000") + "</label></td>";

                                    //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dt.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                }
                                //  tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";


                                //   b hide
                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dt.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";

                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + Convert.ToDouble(dt.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                //   b hide
                                if (!string.IsNullOrEmpty(dt.Rows[i]["Actamount"].ToString().ToUpper()))
                                {
                                    temp_taxable += Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper());
                                    tr_row.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000000; width: 100px; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dt.Rows[i]["CGSTP"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["cgsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                    cgsta += Convert.ToDouble(dt.Rows[i]["cgsta"].ToString());
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dt.Rows[i]["sgstp"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["sgsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                    sgsta += Convert.ToDouble(dt.Rows[i]["sgsta"].ToString());
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dt.Rows[i]["igstp"].ToString() + "</td>";
                                if (!string.IsNullOrEmpty(dt.Rows[i]["igsta"].ToString()))
                                {
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dt.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                    igsta += Convert.ToDouble(dt.Rows[i]["igsta"].ToString());
                                }
                                else
                                {
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                }
                                tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dt.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";
                                if (div_cont.Visible == true)
                                {
                                    if (div_ship.Visible == false)
                                    {
                                        if ((cont_ > 36 && i > count + 27) || (cont_ > 90 && i > count + 9) || (cont_ > 120 && i > count + 7))
                                        {
                                            count = i;
                                            str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if ((cont_ > 36 && i > count + 27) || (cont_ > 90 && i > count + 7) || (cont_ > 120 && i > count + 5))
                                        {
                                            count = i;
                                            str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (str_trantype == "BT")
                                    {
                                        if (i > count + 52)
                                        {
                                            count = i;
                                            str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (div_ship.Visible == false)
                                        {
                                            if (i > count + 41)
                                            {
                                                count = i;
                                                str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (i > count + 37)
                                            {
                                                count = i;
                                                str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            if (div_cont.Visible == true)
                            {
                                if (div_ship.Visible == false)
                                {
                                    for (int i = dt.Rows.Count + _line; i < 20; i++)//24
                                    {
                                        tr_row.Text += " <tr style=''>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                    }
                                }
                                else
                                {
                                    for (int i = dt.Rows.Count + _line; i < 20; i++)
                                    {
                                        tr_row.Text += " <tr style=''>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                    }
                                }
                            }
                            else
                            {
                                if (str_trantype == "BT")
                                {
                                    for (int i = dt.Rows.Count; i < 20; i++)
                                    {
                                        tr_row.Text += " <tr style=''>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                    }
                                }
                                else
                                {
                                    if (div_ship.Visible == false)
                                    {
                                        for (int i = dt.Rows.Count; i < 20; i++)
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                        }
                                    }
                                    else
                                    {
                                        for (int i = dt.Rows.Count; i < 20; i++)
                                        {
                                            tr_row.Text += " <tr style=''>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                            tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
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
                                    if (Profoma == "Profoma")
                                    {
                                        total = total + tax;
                                        lbl_total.Text = total.ToString("#,0.00");
                                    }
                                }
                                if (tax1 < 0 || tax1 < 0.00)
                                {
                                    lbl_roundup.Text = tax1.ToString("#,0.00");
                                    if (Profoma == "Profoma")
                                    {
                                        total = total + tax1;
                                        lbl_total.Text = total.ToString("#,0.00");
                                    }

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

                        if (str_trantype != "OI")
                        {
                            //div_between.Visible = false;
                        }

                    }
                    else if ((Request.QueryString["header"].ToString() == "DN" || Request.QueryString["header"].ToString() == "CN"))
                    {
                        DataTable DT_cont = new DataTable();

                        Header = Request.QueryString["header"].ToString();
                        blno = Request.QueryString["blno"].ToString();
                        bltype = Request.QueryString["bltype"].ToString();

                        if (Profoma == "" && Header == "DN")
                        {
                            lbl_head.Text = "DEBIT NOTE";
                            divqr.Visible = false;
                            DIVIRN.Visible = false;
                        }
                        else if (Profoma == "" && Header == "CN")
                        {
                            lbl_head.Text = "CREDIT NOTE";
                        }
                        else if (Profoma != "" && Header == "DN")
                        {
                            lbl_head.Text = "PROFORMA DEBIT NOTE";
                        }
                        else if (Profoma != "" && Header == "CN")
                        {
                            lbl_head.Text = "PROFORMA CREDIT NOTE";
                        }

                        if (Request.QueryString.ToString().Contains("customertype"))
                        {
                            customertype = Request.QueryString["customertype"].ToString();
                            if (customertype != "P")
                            {
                                customertype = "";
                            }
                        }
                        else
                        {
                            customertype = "";
                        }

                        dt = obj_inv.Getlvdetailsforreport(bid, str_trantype, invoice, vouyear, bltype, Convert.ToInt32(Request.QueryString["voutype"].ToString()), customertype, Profoma);
                        if (dt.Rows.Count > 0)
                        {
                            if (Header == "CN")
                            {
                                //div_vendorref.Visible = true;
                                //llbl_vendor.Text = dt.Rows[0]["vendorrefno"].ToString().ToUpper();

                                //div_vendorrefdate.Visible = true;
                                if (!string.IsNullOrEmpty(dt.Rows[0]["vendorrefdate"].ToString()))
                                {
                                    lbl_vendordate.Text = Convert.ToDateTime(dt.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");

                                }
                                else
                                {
                                    lbl_vendordate.Text = "";
                                }
                            }
                            if (Profoma == "Profoma")
                            {
                                total = 0;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    total += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                                }
                                lbl_total.Text = Convert.ToDouble(total).ToString("#,0.00");
                            }
                            else
                                if (Profoma == "")
                            {
                                lbl_total.Text = Convert.ToDouble(dt.Rows[0]["total"].ToString()).ToString("#,0.00");
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
                                //FALedger.Visible = true;
                                //lblLedgername.Text = dtcust.Rows[0]["ledgername"].ToString();
                            }
                            lbl_job.InnerText = "Our Job #";
                            //if (!string.IsNullOrEmpty(dt.Rows[0]["exrate"].ToString()))
                            //{
                            //    lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                            //}
                            //exrate = 0;
                            //for (int i = 0; i < dt.Rows.Count; i++)
                            //{
                            //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                            //    {
                            //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                            //        {
                            //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                            //        }
                            //    }
                            //}
                            //if (exrate > 0)
                            //{
                            //    lbl_exrate.Text = exrate.ToString("#,0.0000");
                            //}
                            DataView dv_curr = new DataView(dt);
                            Dt_sort = dv_curr.ToTable(true, "curr");
                            dv_curr = new DataView(Dt_sort);
                            dv_curr.Sort = "curr";
                            Dt_sort = dv_curr.ToTable();
                            lbl_exrate.Text = "";
                            curr_count = Dt_sort.Rows.Count;
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
                                        currency = Dt_sort.Rows[j]["curr"].ToString();
                                        lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                    }
                                    else
                                    {
                                        lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                    }
                                }
                            }
                            jobno = Convert.ToInt32(dt.Rows[0]["jobno"].ToString());
                            lbl_ourjob.Text = jobno.ToString();
                            if (dt.Rows[0]["shortname"].ToString().Length > 0)
                            {
                                branch_inv = dt.Rows[0]["shortname"].ToString().Split('-');
                                if (branch_inv.Length > 0)
                                {
                                    branch_invoice = branch_inv[1].ToString();
                                }
                            }


                            if (Header == "DN")
                            {

                                string invno = dt.Rows[0]["vouno"].ToString();
                                // panno =Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
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

                                if (Profoma == "Profoma")
                                {
                                    lbl_invoice.Text = portcode + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "DN" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                }
                                else
                                {
                                    lbl_invoice.Text = portcode + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "DN" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    LBLNO.InnerText = "DN # ";
                                }
                                lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd-MMM-yyyy");
                            }
                            else
                            {
                                string invno = dt.Rows[0]["vouno"].ToString();
                                // panno =Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
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

                                if (Profoma == "Profoma")
                                {
                                    // lbl_invoice.Text = dt.Rows[0]["shortname"].ToString() + " / " + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + " / " + fyear + " / " + dt.Rows[0]["cnno"].ToString();
                                    if (Request.QueryString["header"].ToString() == "CREDIT NOTE")
                                    {
                                        lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "CN" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    }
                                    else if (Request.QueryString["header"].ToString() == "DEBIT NOTE")
                                    {
                                        lbl_invoice.Text = branch_invoice + "/" + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + "/" + fyear.Substring(0, 2) + "/" + fyear.Substring(3, 2) + "/" + "DN" + "/" + invno + "/" + dt.Rows[0]["vouno"].ToString().ToUpper();
                                    }

                                    //d.14 feb 23  lbl_invoice.Text = portcode + "CN" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["cnno"].ToString().ToUpper();
                                }
                                else
                                {
                                    //lbl_invoice.Text = "CN" + fyear_invoice + branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + dt.Rows[0]["cnno"].ToString();
                                    lbl_invoice.Text = branch_invoice + dt.Rows[0]["trantype"].ToString().Replace("OE", "OE").Replace("OI", "OI") + fyear.Substring(0, 2) + fyear.Substring(3, 2) + "CN" + invno + dt.Rows[0]["vouno"].ToString().ToUpper();

                                    //d.14 feb 23  lbl_invoice.Text = portcode + "CN" + fyear.Substring(0, 2) + fyear.Substring(3, 2) + invno + dt.Rows[0]["cnno"].ToString().ToUpper();
                                    LBLNO.InnerText = "CN # ";
                                }
                                lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString()).ToString("dd-MMM-yyyy");
                            }
                            lbl_ourjob.Text = dt.Rows[0]["shortname"].ToString() + " / " + dt.Rows[0]["trantype"].ToString() + " / " + dt.Rows[0]["jobno"].ToString();
                            if (str_trantype == "OE" || str_trantype == "OI")
                            {
                                lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString() + " V " + dt.Rows[0]["voyage"].ToString();
                            }
                            else if (str_trantype == "AE" || str_trantype == "AI")
                            {
                                lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString() + " V " + Convert.ToDateTime(dt.Rows[0]["voyage"].ToString()).ToString("dd-MMM-yyyy");
                            }
                            else if (str_trantype == "CH")
                            {
                                label_vessel.InnerText = "Mode";
                                lbl_vessel.Text = dt.Rows[0]["vesselname"].ToString();
                            }

                            lbl_remarks.Text = dt.Rows[0]["remarks"].ToString();
                            //lbl_total.Text = Convert.ToDouble(Request.QueryString["total"]).ToString("#,0.00");
                            if (Header == "DN" && bltype == "H")
                            {
                                if (str_trantype == "OE" || str_trantype == "OI" || str_trantype == "AE" || str_trantype == "AI" || str_trantype == "CH")
                                {
                                    div_cont.Visible = true;
                                    div_pack.Visible = true;
                                    //div_between.Visible = false;
                                    //div_bottomsign.Visible = false;

                                    if (str_trantype == "OE" || str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        lbl_bl.Text = dt.Rows[0]["blno"].ToString();
                                        lbl_mbl.Text = dt.Rows[0]["mblno"].ToString();
                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }
                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString();
                                        lbl_favouring.Text = dt.Rows[0]["favouring"].ToString();
                                        lbl_ifsccode.Text = dt.Rows[0]["swiftcode"].ToString();
                                        lbl_bankname.Text = dt.Rows[0]["bankname"].ToString();
                                        lbl_bankaddress.Text = dt.Rows[0]["bankaddress"].ToString();
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                        lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                                    }
                                    else if (str_trantype == "OI")
                                    {
                                        lbl_bl.Text = dt.Rows[0]["blno"].ToString();
                                        if (customertype == "P")
                                        {
                                            lbl_accno.Text = dt.Rows[0]["acnos"].ToString();
                                            lbl_favouring.Text = dt.Rows[0]["favouring"].ToString();
                                            lbl_ifsccode.Text = dt.Rows[0]["swiftcode"].ToString();
                                            lbl_bankname.Text = dt.Rows[0]["bankname"].ToString();
                                            lbl_bankaddress.Text = dt.Rows[0]["bankaddress"].ToString();
                                            lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                            lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                                        }
                                        //lbl_port.InnerText = "P O L / FD ";

                                        lbl_port.InnerText = "P O L ";
                                        //lbl_port1.InnerText = "P O D ";
                                        div_bank.Visible = false;
                                        div_prepare.Visible = false;
                                        div_approve.Visible = false;
                                        //div_e_oe.Visible = true;
                                        lbl_mbl.Text = dt.Rows[0]["mblno"].ToString() + "<strong> DT : </strong>" + Convert.ToDateTime(dt.Rows[0]["mbldate"].ToString()).ToString("dd-MMM-yyyy");
                                        lbl_pod.Text = dt.Rows[0]["pod"].ToString() + " / " + dt.Rows[0]["fd"].ToString();

                                        lbl_pod.Text = dt.Rows[0]["pod"].ToString();
                                        ////lbl_pod1.Text = dt.Rows[0]["fd"].ToString();
                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }
                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }

                                        //div_igm.Visible = true;
                                        //lbl_igm.Text = dt.Rows[0]["imno"].ToString() + " & " + Convert.ToDateTime(dt.Rows[0]["imdate"].ToString()).ToString("dd-MMM-yyyy");
                                        //lbl_line.Text = dt.Rows[0]["linenumber"].ToString() + " / " + dt.Rows[0]["sublineno"].ToString();
                                        //lbl_igm.Visible = true;
                                        //lbl_line.Visible = true;
                                    }
                                    lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString(); // grweight
                                    lbl_grwt.Text = Convert.ToDouble(dt.Rows[0]["grweight"].ToString()).ToString("#0.00") + " Kgs";
                                    cont_ = 0;
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        jobtype = dt.Rows[0]["jobtype"].ToString();
                                        if (jobtype == "3")
                                        {
                                            //lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20 + " + dt.Rows[0]["cont40"].ToString() + " x 40";
                                            DataTable dtnew1 = new DataTable();

                                            if (Request.QueryString.ToString().Contains("blno"))
                                            {
                                                blno = blno = Request.QueryString["blno"].ToString().ToUpper();
                                                dtnew1 = obj_inv.getsizetype(blno, jobno, bid, str_trantype);
                                            }

                                            if (dtnew1.Rows.Count > 0)
                                            {
                                                lbl_volume.Text = dtnew1.Rows[0]["size"].ToString().ToUpper().ToUpper();
                                            }
                                            else
                                            {
                                                //lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                if (dt.Rows[0]["cont40"].ToString() != "0" && dt.Rows[0]["cont20"].ToString() != "0")
                                                {
                                                    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                }
                                                else if (dt.Rows[0]["cont40"].ToString() != "0")
                                                {
                                                    lbl_volume.Text = dt.Rows[0]["cont40"].ToString() + " x 40' ";
                                                }
                                                else if (dt.Rows[0]["cont20"].ToString() != "0")
                                                {
                                                    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ";
                                                }
                                            }

                                            //if (dt.Rows[0]["cont40"].ToString() != "0" && dt.Rows[0]["cont20"].ToString() != "0")
                                            //{
                                            //    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                            //}
                                            //else if (dt.Rows[0]["cont40"].ToString() != "0")
                                            //{
                                            //    lbl_volume.Text = dt.Rows[0]["cont40"].ToString() + " x 40' ";
                                            //}
                                            //else if (dt.Rows[0]["cont20"].ToString() != "0")
                                            //{
                                            //    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ";
                                            //}
                                        }
                                        else
                                        {
                                            lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["cbm"].ToString()).ToString("#0.000") + " / " + "LCL";
                                        }
                                        DT_cont = obj_inv.get_containerdetails(jobno, bid, blno, str_trantype, bltype);
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
                                    else if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        div_cont.Visible = false;
                                        lable_volume.InnerText = "Charge Wght";
                                        lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["chargewt"].ToString()).ToString("#0.00") + " Kgs";
                                    }
                                    else if (str_trantype == "CH")
                                    {
                                        div_cont.Visible = false;
                                        lbl_blname.InnerText = "Doc #";
                                        lbl_bl.Text = dt.Rows[0]["docno"].ToString();
                                        lbl_mblname.InnerText = "Date";
                                        lbl_mbl.Text = Convert.ToDateTime(dt.Rows[0]["docdate"].ToString()).ToString("dd-MMM-yyyy");
                                        div_port.Visible = true;
                                        div_port1.Visible = true;
                                        div_pack.Visible = false;
                                        lbl_grwt.Text = Convert.ToDouble(dt.Rows[0]["grweight"].ToString()).ToString("#0.00") + " Kgs";
                                        lable_volume.InnerText = "Packages";
                                        lbl_volume.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString();
                                        //div_ship4cn.Visible = false;


                                        if (dt.Columns.Contains("mpolname"))
                                        {
                                            lbl_port.InnerText = "P O L";
                                            lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            lbl_pod.Text = "";
                                        }

                                        if (dt.Columns.Contains("mpodname"))
                                        {
                                            //lbl_port1.InnerText = "P O D";
                                            //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            div_port1.Visible = false;
                                            //lbl_pod1.Text = "";
                                        }
                                        //lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                        //exrate = 0;
                                        //for (int i = 0; i < dt.Rows.Count; i++)
                                        //{
                                        //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                        //    {
                                        //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                        //        {
                                        //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                        //        }
                                        //    }
                                        //}
                                        //if (exrate > 0)
                                        //{
                                        //    lbl_exrate.Text = exrate.ToString("#,0.0000");
                                        //}
                                        dv_curr = new DataView(dt);
                                        Dt_sort = dv_curr.ToTable(true, "curr");
                                        dv_curr = new DataView(Dt_sort);
                                        dv_curr.Sort = "curr";
                                        Dt_sort = dv_curr.ToTable();
                                        lbl_exrate.Text = "";
                                        curr_count = Dt_sort.Rows.Count;
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
                                                    currency = Dt_sort.Rows[j]["curr"].ToString();
                                                    lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                                }
                                                else
                                                {
                                                    lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                                }
                                            }
                                        }
                                        //div_invoice.Visible = false;
                                        div_approve.Visible = false;
                                        div_prepare.Visible = false;
                                        //div_e_oe.Visible = true;
                                    }
                                    if (str_trantype == "AI")
                                    {
                                        lbl_port.InnerText = "P O L";
                                        //lbl_port1.InnerText = "P O D";
                                    }
                                    lbl_shipper.Text = dt.Rows[0]["shipper"].ToString();
                                    lbl_consignee.Text = dt.Rows[0]["consignee"].ToString();
                                    div_cnops.Visible = true;
                                    if (str_trantype != "CH")
                                    {
                                        //div_bottomsign.Visible = false;
                                    }

                                }
                            }
                            else if (Header == "DN" && bltype == "M")
                            {
                                if (str_trantype == "OE" || str_trantype == "OI" || str_trantype == "AE")
                                {
                                    div_port.Visible = true;
                                    div_port1.Visible = true;
                                    div_cont.Visible = true;
                                    //div_bottomsign.Visible = false;
                                    div_bl.Visible = false;
                                    div_pack.Visible = false;
                                    //  div_grw.Visible = false;
                                    div_volume.Visible = false;
                                    //div_invoice.Visible = true;
                                    div_cnops.Visible = true;
                                    div_ship.Visible = false;
                                    if (str_trantype == "OE" || (str_trantype == "OI" && customertype == "P") || str_trantype == "AE")
                                    {
                                        lbl_accno.Text = dt.Rows[0]["acnos"].ToString();
                                        lbl_favouring.Text = dt.Rows[0]["favouring"].ToString();
                                        lbl_ifsccode.Text = dt.Rows[0]["swiftcode"].ToString();
                                        lbl_bankname.Text = dt.Rows[0]["bankname"].ToString();
                                        lbl_bankaddress.Text = dt.Rows[0]["bankaddress"].ToString();

                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                        lbl_approved.Text = dt.Rows[0]["approvedby"].ToString();
                                    }
                                    else if (str_trantype == "OI" && customertype == "")
                                    {
                                        div_port.Visible = true;
                                        div_port1.Visible = true;
                                        //div_invoice.Visible = false;
                                        div_cnops.Visible = true;
                                        div_prepare.Visible = false;
                                        div_approve.Visible = false;
                                        //div_e_oe.Visible = true;
                                    }
                                    if (str_trantype == "OI" || str_trantype == "AI")
                                    {

                                        lbl_port.InnerText = "P O L";

                                        //lbl_port1.InnerText = "P O D";
                                    }

                                    lbl_mbl.Text = dt.Rows[0]["mblno"].ToString();
                                    if (dt.Columns.Contains("mpolname"))
                                    {

                                        lbl_pod.Text = dt.Rows[0]["mpolname"].ToString();
                                    }
                                    else
                                    {
                                        div_port.Visible = false;
                                        lbl_pod.Text = "";
                                    }
                                    if (dt.Columns.Contains("mpodname"))
                                    {
                                        //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString();
                                    }
                                    else
                                    {
                                        div_port1.Visible = false;
                                        //lbl_pod1.Text ="";
                                    }


                                    //lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                    //exrate = 0;
                                    //for (int i = 0; i < dt.Rows.Count; i++)
                                    //{
                                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                    //    {
                                    //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                    //        {
                                    //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                    //        }
                                    //    }
                                    //}
                                    //if (exrate > 0)
                                    //{
                                    //    lbl_exrate.Text = exrate.ToString("#,0.0000");
                                    //}
                                    dv_curr = new DataView(dt);
                                    Dt_sort = dv_curr.ToTable(true, "curr");
                                    dv_curr = new DataView(Dt_sort);
                                    dv_curr.Sort = "curr";
                                    Dt_sort = dv_curr.ToTable();
                                    lbl_exrate.Text = "";
                                    curr_count = Dt_sort.Rows.Count;
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
                                                currency = Dt_sort.Rows[j]["curr"].ToString();
                                                lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                            else
                                            {
                                                lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                        }
                                    }
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        DT_cont = obj_inv.get_containerdetails(jobno, bid, blno, str_trantype, bltype);
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
                                }
                            }
                            else if ((Header == "CN" && bltype == "H") || (Header == "CN" && bltype == "M" && str_trantype == "CH"))
                            {
                                if (dt.Columns.Contains("mpolname"))
                                {

                                    lbl_pod.Text = dt.Rows[0]["mpolname"].ToString();
                                }
                                else
                                {
                                    div_port.Visible = false;
                                    lbl_pod.Text = "";
                                }
                                if (dt.Columns.Contains("mpodname"))
                                {
                                    //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString();
                                }
                                else
                                {
                                    div_port1.Visible = false;
                                    //lbl_pod1.Text = "";
                                }


                                if (str_trantype == "OE" || str_trantype == "OI" || str_trantype == "AE" || str_trantype == "AI" || str_trantype == "CH")
                                {
                                    div_pack.Visible = true;
                                    div_cnops.Visible = true;
                                    //div_invoice.Visible = false;
                                    div_mbl.Visible = false;
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        //    div_grw.Visible = false;
                                        div_cont.Visible = true;
                                    }
                                    else if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        div_ship.Visible = true;
                                        if (str_trantype == "AE")
                                        {
                                            div_consignee.Visible = false;
                                            lbl_blname.InnerText = "AWB #";
                                        }
                                        else
                                        {
                                            lbl_blname.InnerText = "HAWB #";
                                        }
                                        div_cont.Visible = false;

                                        lbl_grwt.Text = Convert.ToDouble(dt.Rows[0]["grweight"].ToString()).ToString("#0.00") + " Kgs";
                                        lable_volume.InnerText = "Charge Wt";
                                        lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["chargewt"].ToString()).ToString("#0.00") + " Kgs";
                                        //lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                        //exrate = 0;
                                        //for (int i = 0; i < dt.Rows.Count; i++)
                                        //{
                                        //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                        //    {
                                        //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                        //        {
                                        //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                        //        }
                                        //    }
                                        //} 
                                        dv_curr = new DataView(dt);
                                        Dt_sort = dv_curr.ToTable(true, "curr");
                                        dv_curr = new DataView(Dt_sort);
                                        dv_curr.Sort = "curr";
                                        Dt_sort = dv_curr.ToTable();
                                        lbl_exrate.Text = "";
                                        curr_count = Dt_sort.Rows.Count;
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
                                                    currency = Dt_sort.Rows[j]["curr"].ToString();
                                                    lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                                }
                                                else
                                                {
                                                    lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                                }
                                            }
                                        }
                                    }

                                    if (str_trantype == "OI" || str_trantype == "AI")
                                    {
                                        lbl_port.InnerText = "P O L";

                                        //lbl_port1.InnerText = "P O D";
                                    }
                                    if (str_trantype != "CH")
                                    {
                                        lbl_bl.Text = dt.Rows[0]["blno"].ToString();
                                        lbl_pod.Text = dt.Rows[0]["pod"].ToString();
                                        lbl_package.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["descn"].ToString();
                                    }
                                    else
                                    {
                                        div_cont.Visible = false;
                                        lbl_blname.InnerText = "Doc #";
                                        lbl_bl.Text = dt.Rows[0]["docno"].ToString();
                                        lbl_mblname.InnerText = "Date";
                                        lbl_mbl.Text = Convert.ToDateTime(dt.Rows[0]["docdate"].ToString()).ToString("dd-MMM-yyyy");

                                        if (str_trantype == "CH")
                                        {
                                            div_port.Visible = true;
                                            div_port1.Visible = true;
                                            if (dt.Columns.Contains("mpolname"))
                                            {
                                                lbl_port.InnerText = "P O L";
                                                lbl_pod.Text = dt.Rows[0]["mpolname"].ToString().ToUpper();
                                            }
                                            else
                                            {
                                                div_port.Visible = false;
                                                lbl_pod.Text = "";
                                            }

                                            if (dt.Columns.Contains("mpodname"))
                                            {
                                                //lbl_port1.InnerText = "P O D";
                                                //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString().ToUpper();
                                            }
                                            else
                                            {
                                                div_port1.Visible = false;
                                                //lbl_pod1.Text = "";
                                            }
                                        }
                                        else
                                        {
                                            div_port.Visible = false;
                                            div_port1.Visible = false;
                                        }

                                        div_pack.Visible = false;

                                        lbl_grwt.Text = Convert.ToDouble(dt.Rows[0]["grweight"].ToString()).ToString("#0.00") + " Kgs";
                                        lbl_volume.Text = dt.Rows[0]["volumeqty"].ToString() + " M3";
                                        //lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                        //exrate = 0;
                                        //for (int i = 0; i < dt.Rows.Count; i++)
                                        //{
                                        //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                        //    {
                                        //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                        //        {
                                        //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                        //        }
                                        //    }
                                        //} 
                                        //dt = obj_inv.get_tdspayable(invoice, bid, vouyear, "P");
                                        dv_curr = new DataView(dt);
                                        Dt_sort = dv_curr.ToTable(true, "curr");
                                        dv_curr = new DataView(Dt_sort);
                                        dv_curr.Sort = "curr";
                                        Dt_sort = dv_curr.ToTable();
                                        lbl_exrate.Text = "";
                                        curr_count = Dt_sort.Rows.Count;
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
                                                    currency = Dt_sort.Rows[j]["curr"].ToString();
                                                    lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                                }
                                                else
                                                {
                                                    lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                                }
                                            }
                                        }
                                    }


                                    lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                    lbl_approved.Text = dt.Rows[0]["approvedby"].ToString();
                                    if (str_trantype == "OE" || str_trantype == "CH")
                                    {
                                        lbl_shipper.Text = dt.Rows[0]["shipper"].ToString();
                                        lbl_consignee.Text = dt.Rows[0]["consignee"].ToString();
                                    }
                                    else if (str_trantype == "OI")
                                    {
                                        div_ship.Visible = false;
                                    }
                                    else if (str_trantype == "AE")
                                    {
                                        lbl_shipper.Text = dt.Rows[0]["shipper"].ToString();
                                    }
                                    else if (str_trantype == "AI")
                                    {
                                        label_shipper.InnerText = "Agent";
                                        label_Consignee.InnerText = "Shipper";
                                        lbl_shipper.Text = dt.Rows[0]["agent"].ToString();
                                        lbl_consignee.Text = dt.Rows[0]["shipper"].ToString();
                                    }

                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        jobtype = dt.Rows[0]["jobtype"].ToString();
                                        if (jobtype == "3")
                                        {
                                            //lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20 + " + dt.Rows[0]["cont40"].ToString() + " x 40";
                                            //if (dt.Rows[0]["cont40"].ToString() != "0" && dt.Rows[0]["cont20"].ToString() != "0")
                                            //{
                                            //    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                            //}
                                            //else if (dt.Rows[0]["cont40"].ToString() != "0")
                                            //{
                                            //    lbl_volume.Text = dt.Rows[0]["cont40"].ToString() + " x 40' ";
                                            //}
                                            //else if (dt.Rows[0]["cont20"].ToString() != "0")
                                            //{
                                            //    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ";
                                            //}
                                            DataTable dtnew1 = new DataTable();

                                            if (Request.QueryString.ToString().Contains("blno"))
                                            {
                                                blno = blno = Request.QueryString["blno"].ToString().ToUpper();
                                                dtnew1 = obj_inv.getsizetype(blno, jobno, bid, str_trantype);
                                            }

                                            if (dtnew1.Rows.Count > 0)
                                            {
                                                lbl_volume.Text = dtnew1.Rows[0]["size"].ToString().ToUpper().ToUpper();
                                            }
                                            else
                                            {
                                                //lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                if (dt.Rows[0]["cont40"].ToString() != "0" && dt.Rows[0]["cont20"].ToString() != "0")
                                                {
                                                    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ;" + dt.Rows[0]["cont40"].ToString() + " x 40'";
                                                }
                                                else if (dt.Rows[0]["cont40"].ToString() != "0")
                                                {
                                                    lbl_volume.Text = dt.Rows[0]["cont40"].ToString() + " x 40' ";
                                                }
                                                else if (dt.Rows[0]["cont20"].ToString() != "0")
                                                {
                                                    lbl_volume.Text = dt.Rows[0]["cont20"].ToString() + " x 20' ";
                                                }
                                            }

                                        }
                                        else
                                        {
                                            lbl_volume.Text = Convert.ToDouble(dt.Rows[0]["cbm"].ToString()).ToString("#0.000") + " / " + "LCL";
                                        }
                                        DT_cont = obj_inv.get_containerdetails(jobno, bid, blno, str_trantype, bltype);
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

                                }
                            }
                            else if (Header == "CN" && bltype == "M")
                            {
                                if (str_trantype == "OE" || str_trantype == "OI" || str_trantype == "AE" || str_trantype == "AI" || str_trantype == "CH")
                                {
                                    div_port.Visible = true;
                                    div_port1.Visible = true;
                                    div_cont.Visible = true;
                                    //div_bottomsign.Visible = false;
                                    div_bl.Visible = false;
                                    div_pack.Visible = false;
                                    //   div_grw.Visible = false;
                                    div_volume.Visible = false;
                                    //div_invoice.Visible = false;
                                    div_cnops.Visible = true;
                                    div_ship.Visible = false;
                                    if (str_trantype == "OE")
                                    {
                                        label_shipper.InnerText = "Agent";
                                        lbl_shipper.Text = dt.Rows[0]["shipment"].ToString();
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                        lbl_approved.Text = dt.Rows[0]["approvedby"].ToString();
                                    }
                                    else if (str_trantype == "AE")
                                    {
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                        lbl_approved.Text = dt.Rows[0]["approvedby"].ToString();
                                    }
                                    else if (str_trantype == "AI")
                                    {
                                        label_shipper.InnerText = "Agent";
                                        lbl_shipper.Text = dt.Rows[0]["shipment"].ToString();
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                        lbl_approved.Text = dt.Rows[0]["approvedby"].ToString();
                                    }
                                    else if (str_trantype == "OI")
                                    {
                                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                                        lbl_approved.Text = dt.Rows[0]["approvedby"].ToString();
                                    }

                                    if (str_trantype == "OI" || str_trantype == "AI")
                                    {
                                        lbl_port.InnerText = "P O L";
                                        //lbl_port1.InnerText = "P O D";
                                    }
                                    if (str_trantype == "AI")
                                    {
                                        div_ship.Visible = true;
                                        div_consignee.Visible = false;
                                    }

                                    lbl_mbl.Text = dt.Rows[0]["blno"].ToString();
                                    lbl_pod.Text = dt.Rows[0]["pod"].ToString();
                                    if (dt.Columns.Contains("mpolname"))
                                    {
                                        lbl_pod.Text = dt.Rows[0]["mpolname"].ToString();
                                    }
                                    else
                                    {
                                        div_port.Visible = false;
                                        lbl_pod.Text = "";
                                    }
                                    if (dt.Columns.Contains("mpodname"))
                                    {

                                        //lbl_pod1.Text = dt.Rows[0]["mpodname"].ToString();
                                    }
                                    else
                                    {
                                        div_port1.Visible = false;
                                        //lbl_pod1.Text = "";
                                    }



                                    //lbl_exrate.Text = Convert.ToDouble(dt.Rows[0]["exrate"].ToString()).ToString("#,0.00");
                                    //exrate = 0;
                                    //for (int i = 0; i < dt.Rows.Count; i++)
                                    //{
                                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["exrate"].ToString()))
                                    //    {
                                    //        if (exrate < Convert.ToDouble(dt.Rows[i]["exrate"].ToString()))
                                    //        {
                                    //            exrate = Convert.ToDouble(dt.Rows[i]["exrate"].ToString());
                                    //        }
                                    //    }
                                    //}
                                    //if (exrate > 0)
                                    //{
                                    //    lbl_exrate.Text = exrate.ToString("#,0.0000");
                                    //}
                                    dv_curr = new DataView(dt);
                                    Dt_sort = dv_curr.ToTable(true, "curr");
                                    dv_curr = new DataView(Dt_sort);
                                    dv_curr.Sort = "curr";
                                    Dt_sort = dv_curr.ToTable();
                                    lbl_exrate.Text = "";
                                    curr_count = Dt_sort.Rows.Count;
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
                                                currency = Dt_sort.Rows[j]["curr"].ToString();
                                                lbl_exrate.Text = Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                            else
                                            {
                                                lbl_exrate.Text += " / " + Dt_sort.Rows[j]["curr"].ToString() + " " + exrate.ToString("#,0.0000");
                                            }
                                        }
                                    }
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {

                                        DT_cont = obj_inv.get_containerdetails(jobno, bid, blno, str_trantype, bltype);
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
                                }
                            }
                            if (Request.QueryString.ToString().Contains("count"))
                            {
                                count = Convert.ToInt32(Request.QueryString["count"]);
                            }
                            else
                            {
                                count = 0;
                            }

                            if (Request.QueryString.ToString().Contains("cont_count"))
                            {
                                cont_count = Convert.ToInt32(Request.QueryString["cont_count"].ToString());
                            }
                            else
                            {
                                cont_count = 0;
                            }

                            if (customertype == "P")
                            {
                                //table_agent.Visible = true;
                                //table_invoice.Visible = false;
                            }
                            else
                            {
                                //table_agent.Visible = false;
                                //table_invoice.Visible = true;
                            }

                            DataTable dtLi = new DataTable();
                            DataView data1 = dt.DefaultView;
                            data1.RowFilter = "groupid = '" + 1 + "' ";
                            dtLi = data1.ToTable();
                            row_count = dtLi.Rows.Count;


                            for (int i = count; i < dtLi.Rows.Count; i++)
                            {
                                //i = count;
                                //row_count += 1;

                                if (customertype == "P")
                                {
                                    if (Header == "CN")
                                    {
                                        tr_rowagent.Text += " <tr style=''>";
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                        if (str_trantype == "AE" || str_trantype == "AI")
                                        {

                                            // tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";

                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                            //b hide
                                            //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";//.Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG")
                                            //b hide

                                        }

                                        else
                                        {
                                            //  tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";

                                            //b hide
                                            //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                            //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";

                                            //b hide
                                        }
                                        //   tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";


                                        //b hide
                                        //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";
                                        //  b hide

                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                        if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                        {

                                            temp_taxable += (Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString()));
                                            tr_rowagent.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + (Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</label></td>";
                                        }
                                        else
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; width: 100px; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        }
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>0.00</td>";
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>0.00</td>";
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>0.00</td>";
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>0.00</td>";
                                        //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>0.00</td>";
                                        //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>0.00</td>";
                                        if (!string.IsNullOrEmpty(dtLi.Rows[i]["igstp"].ToString()))
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                        }
                                        else
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; text-align:right;' align='right'>0.00</td>";
                                        }
                                        if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black;' align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                            igsta += (Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString()));
                                        }
                                        else
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black;' align='right'>0.00</td>";
                                        }
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + Convert.ToDouble(dtLi.Rows[i]["fcamt"].ToString()).ToString("#0,0.00") + "</td></tr>";
                                        //temp_total_agent += Convert.ToDouble(dtLi.Rows[i]["fcamt"].ToString());
                                        temp_total_agent += (Convert.ToDouble(dtLi.Rows[i]["fcamt"].ToString()));
                                    }
                                    else
                                    {
                                        tr_rowagent.Text += " <tr style=''>";
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                        if (str_trantype == "AE" || str_trantype == "AI")
                                        {
                                            //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";

                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";//.Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG")
                                        }
                                        else
                                        {
                                            // tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";



                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";
                                            //b hide
                                            //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                            //bhide
                                        }
                                        //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";



                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";

                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                        if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                        {

                                            temp_taxable += (Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString()));
                                            tr_rowagent.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + (Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</label></td>";
                                        }
                                        else
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; width: 100px; padding:0px 2px 0px 2px; border-right: 1px solid Black;'>&nbsp;</td>";
                                        }
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["CGSTP"].ToString() + "</td>";
                                        if (!string.IsNullOrEmpty(dtLi.Rows[i]["cgsta"].ToString()))
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + (Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                            cgsta += (Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString()));
                                        }
                                        else
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        }
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dtLi.Rows[i]["sgstp"].ToString() + "</td>";
                                        if (!string.IsNullOrEmpty(dtLi.Rows[i]["sgsta"].ToString()))
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + (Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                            sgsta += (Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString()));
                                        }
                                        else
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        }
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                        if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString())).ToString("#,0.00") + "</td>";
                                            igsta += (Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString()));
                                        }
                                        else
                                        {
                                            tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                        }
                                        tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString())).ToString("#0,0.00") + "</td></tr>";
                                        //temp_total_agent += Convert.ToDouble(dtLi.Rows[i]["fcamt"].ToString());
                                        temp_total_agent += (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString()) / Convert.ToDouble(dtLi.Rows[i]["exrate"].ToString()));

                                    }


                                    div_exrate.Visible = false;
                                }
                                else
                                {
                                    tr_row.Text += " <tr style=''>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; width:265px;'>" + dtLi.Rows[i]["chargename"].ToString().ToUpper() + "</label></td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px; border-right: 1px solid Black; width:55px;'><label style='display:inline-block; float:left; padding:0px 0px 0px 0px; '>" + dtLi.Rows[i]["SACCode"].ToString().ToUpper() + "</label></td>";
                                    if (str_trantype == "AE" || str_trantype == "AI")
                                    {
                                        //  tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper().Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG") + "</label></td>";

                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";//.Replace("HWBL", "FLAT RATE").Replace("HAWB", "FLAT RATE").Replace("KGS", "PER KG")


                                    }
                                    else
                                    {
                                        //tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["unit"].ToString() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";



                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:left; white-space:nowrap;'>" + Convert.ToDouble(dtLi.Rows[i]["unit"].ToString()).ToString("#0.000") + "</label></td>";

                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:105px;'><label style='display:inline-block; float:right; text-align:right; white-space:nowrap;'>" + dtLi.Rows[i]["base"].ToString().ToUpper() + "</label></td>";
                                    }
                                    // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";


                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:left;'>" + dtLi.Rows[i]["curr"].ToString().ToUpper() + "</label></td>";

                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:200px;'><label style='display:inline-block; float:right; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["rate"].ToString()).ToString("#,0.00") + "</label></td>";
                                    if (!string.IsNullOrEmpty(dtLi.Rows[i]["Actamount"].ToString().ToUpper()))
                                    {
                                        temp_taxable += Convert.ToDouble(dtLi.Rows[i]["Actamount"].ToString().ToUpper());
                                        tr_row.Text += "<td style='color:#000000; width: 100px; text-align:right; padding:0px 2px 0px 2px; border-right: 1px solid Black;'><label style='display:inline-block; padding:0px 0px 0px 0px;text-align:right;' align='right' >" + Convert.ToDouble(dt.Rows[i]["Actamount"].ToString().ToUpper()).ToString("#,0.00") + "</label></td>";
                                    }
                                    else
                                    {
                                        tr_row.Text += "<td style='color:#000000; width: 100px; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    }
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["CGSTP"].ToString() + "</td>";
                                    if (!string.IsNullOrEmpty(dtLi.Rows[i]["cgsta"].ToString()))
                                    {
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString()).ToString("#,0.00") + "</td>";
                                        cgsta += Convert.ToDouble(dtLi.Rows[i]["cgsta"].ToString());
                                    }
                                    else
                                    {
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    }
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + dtLi.Rows[i]["sgstp"].ToString() + "</td>";
                                    if (!string.IsNullOrEmpty(dtLi.Rows[i]["sgsta"].ToString()))
                                    {
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black; text-align:right;'>" + Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString()).ToString("#,0.00") + "</td>";
                                        sgsta += Convert.ToDouble(dtLi.Rows[i]["sgsta"].ToString());
                                    }
                                    else
                                    {
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    }
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + dtLi.Rows[i]["igstp"].ToString() + "</td>";
                                    if (!string.IsNullOrEmpty(dtLi.Rows[i]["igsta"].ToString()))
                                    {
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;' align='right'>" + Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString()).ToString("#,0.00") + "</td>";
                                        igsta += Convert.ToDouble(dtLi.Rows[i]["igsta"].ToString());
                                    }
                                    else
                                    {
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    }
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;width:100px;'  align='right'>" + (Convert.ToDouble(dtLi.Rows[i]["amount"].ToString())).ToString("#0,0.00") + "</td></tr>";

                                }
                                if (Header == "DN")
                                {
                                    if (bltype == "H")
                                    {
                                        if (str_trantype == "OE")
                                        {
                                            if ((cont_ > 36 && i > count + 24) || (cont_ > 90 && i > count + 14) || (cont_ > 120 && i > count + 8))
                                            {
                                                count = i;
                                                str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                break;
                                            }
                                        }
                                        else if (str_trantype == "OI")
                                        {
                                            if (customertype == "")
                                            {
                                                if ((cont_ > 36 && i > count + 32) || (cont_ > 90 && i > count + 22) || (cont_ > 120 && i > count + 16))
                                                {
                                                    count = i;
                                                    str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if ((cont_ > 36 && i > count + 24) || (cont_ > 90 && i > count + 14) || (cont_ > 120 && i > count + 8))
                                                {
                                                    count = i;
                                                    str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    else if (bltype == "M")
                                    {
                                        if (str_trantype == "OE")
                                        {
                                            if ((cont_ > 36 && i > count + 37) || (cont_ > 90 && i > count + 24) || (cont_ > 120 && i > count + 16))
                                            {
                                                count = i;
                                                str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                break;
                                            }
                                        }
                                        else if (str_trantype == "OI")
                                        {
                                            if (customertype == "")
                                            {
                                                if ((cont_ > 36 && i > count + 32) || (cont_ > 90 && i > count + 22) || (cont_ > 120 && i > count + 16))
                                                {
                                                    count = i;
                                                    str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if ((cont_ > 36 && i > count + 24) || (cont_ > 90 && i > count + 14) || (cont_ > 120 && i > count + 8))
                                                {
                                                    count = i;
                                                    str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                                    break;
                                                }
                                            }
                                        }

                                    }

                                }
                                else if (Header == "CN")
                                {
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        if ((cont_ > 36 && i > count + 36) || (cont_ > 90 && i > count + 22) || (cont_ > 120 && i > count + 16))
                                        {
                                            count = i;
                                            str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + invoice.ToString() + "&vouyear=" + vouyear.ToString() + "&total=" + lbl_total.Text + "&blno=" + blno + "&bltype=" + bltype + "&header=" + Request.QueryString["header"].ToString() + "&count=" + count + "&cont_count=" + cont_count + "&page=" + page_ + "&" + this.Page.ClientQueryString + "','','');";
                                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", str_Script, true);
                                            break;
                                        }
                                    }
                                }

                            }
                        }


                        if (temp_total_agent > 0)
                        {
                            total_agent.Text = temp_total_agent.ToString("#,0.00");
                        }
                        //div_between.Visible = false;
                        if (str_trantype == "OE" || str_trantype == "OI" || str_trantype == "AE" || str_trantype == "AI" || str_trantype == "CH")
                        {
                            int len_ = 0;
                            if (Header == "DN")
                            {
                                div_cnops.Visible = true;
                                if (str_trantype == "OE")
                                {
                                    if (bltype == "H")
                                    {
                                        len_ = 28;
                                    }
                                    else
                                    {
                                        //div_between.Visible = false;
                                        len_ = 31;
                                    }

                                }
                                else if (str_trantype == "OI")
                                {
                                    if (bltype == "H")
                                    {
                                        if (customertype == "")
                                        {
                                            len_ = 35;
                                        }
                                        else
                                        {
                                            len_ = 24;
                                        }
                                    }
                                    else
                                    {
                                        //div_between.Visible = false;
                                        //div_invoice.Visible = true;
                                        div_bank.Visible = false;
                                        //div_bottomsign.Visible = false;
                                        if (customertype == "")
                                        {
                                            len_ = 38;
                                        }
                                        else
                                        {
                                            len_ = 24;
                                        }
                                    }

                                }
                                else if ((str_trantype == "AE" || str_trantype == "AI") && bltype == "H")
                                {
                                    div_cont.Visible = false;
                                    if (customertype == "")
                                    {
                                        len_ = 29;
                                    }
                                    else
                                    {
                                        len_ = 30;
                                    }

                                }
                                else if ((str_trantype == "AE" || str_trantype == "AI") && bltype == "M")
                                {
                                    if (str_trantype == "AE")
                                    {
                                        len_ = 30;
                                    }
                                    else
                                    {
                                        len_ = 25;
                                    }
                                    div_cont.Visible = false;

                                }
                                else if (str_trantype == "CH")
                                {
                                    //div_between.Visible = false;
                                    //div_invoice.Visible = true;
                                    div_bank.Visible = false;
                                    //div_bottomsign.Visible = false;
                                    len_ = 37;
                                }

                            }
                            else if (Header == "CN")
                            {
                                //div_between.Visible = false;
                                //div_invoice.Visible = true;
                                div_bank.Visible = false;
                                //div_bottomsign.Visible = false;
                                if (bltype == "H")
                                {
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        len_ = 34;
                                    }
                                    else if (str_trantype == "AE")
                                    {

                                        len_ = 38;
                                    }
                                    else if (str_trantype == "AI")
                                    {

                                        len_ = 37;
                                    }
                                    else if (str_trantype == "CH")
                                    {
                                        len_ = 38;
                                    }
                                }
                                else
                                {
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {

                                        len_ = 37;
                                    }
                                    else if (str_trantype == "AE")
                                    {

                                        len_ = 39;
                                    }
                                    else if (str_trantype == "AI")
                                    {

                                        len_ = 38;
                                    }
                                }
                            }
                            /*if (Header == "DN")
                            {
                                div_cnops.Visible = false;
                                if (str_trantype == "OE")
                                {
                                    if (bltype == "H")
                                    {
                                        len_ = 32;
                                    }
                                    else
                                    {
                                        //div_between.Visible = false;
                                        len_ = 37;
                                    }
                                }
                                else if (str_trantype == "OI")
                                {
                                    if (bltype == "H")
                                    {
                                        if (customertype == "")
                                        {
                                            len_ = 42;
                                        }
                                        else
                                        {
                                            len_ = 24;
                                        }
                                    }
                                    else
                                    {
                                        //div_between.Visible = false;
                                        //div_invoice.Visible = true;
                                        div_bank.Visible = false;
                                        //div_bottomsign.Visible = false;
                                        if (customertype == "")
                                        {
                                            len_ = 45;
                                        }
                                        else
                                        {
                                            len_ = 24;
                                        }
                                    }
                                }
                                else if ((str_trantype == "AE" || str_trantype == "AI") && bltype == "H")
                                {
                                    div_cont.Visible = false;
                                    if (customertype == "")
                                    {
                                        len_ = 36;
                                    }
                                    else
                                    {
                                        len_ = 37;
                                    }
                                }
                                else if ((str_trantype == "AE" || str_trantype == "AI") && bltype == "M")
                                {
                                    if (str_trantype == "AE")
                                    {
                                        len_ = 37;
                                    }
                                    else
                                    {
                                        len_ = 32;
                                    }
                                    div_cont.Visible = false;
                                }
                                else if (str_trantype == "CH")
                                {
                                    //div_between.Visible = false;
                                    //div_invoice.Visible = true;
                                    div_bank.Visible = false;
                                    //div_bottomsign.Visible = false;
                                    len_ = 46;
                                }
                            }
                            else if (Header == "CN")
                            {
                                //div_between.Visible = false;
                                //div_invoice.Visible = true;
                                div_bank.Visible = false;
                                //div_bottomsign.Visible = false;
                                if (bltype == "H")
                                {
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        len_ = 36;
                                    }
                                    else if (str_trantype == "AE")
                                    {
                                        len_ = 42;
                                    }
                                    else if (str_trantype == "AI")
                                    {

                                        len_ = 40;
                                    }
                                    else if (str_trantype == "CH")
                                    {
                                        len_ = 41;
                                    }
                                }
                                else
                                {
                                    if (str_trantype == "OE" || str_trantype == "OI")
                                    {
                                        len_ = 41;
                                    }
                                    else if (str_trantype == "AE")
                                    {
                                        len_ = 41;
                                    }
                                    else if (str_trantype == "AI")
                                    {
                                        len_ = 40;
                                    }
                                }
                            }*/

                            for (int i = row_count + _line; i < len_; i++)
                            {
                                if (Header == "CN" && _int == 1)
                                {
                                    DataTable dt_pay = new DataTable();
                                    dt_pay = obj_inv.get_tdspayable(invoice, bid, vouyear, "E");
                                    tr_row.Text += " <tr style=''>";
                                    if (dt_pay.Rows.Count > 0)
                                    {
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'><label style='display:inline-block; float:left; padding:0px 0px 0px 2px; '>TDS PAYABLE " + dt_pay.Rows[0]["tdsdesc"].ToString() + " Rs. " + Convert.ToDouble(dt_pay.Rows[0]["tdsamount"].ToString()).ToString("#,0.00") + "</label></td>";
                                    }
                                    else
                                    {
                                        tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    }
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    // tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                    _int += 1;
                                    continue;
                                }
                                _int += 1;
                                if (customertype == "P")
                                {
                                    //tr_rowagent.Text += " <tr style=''>";
                                    //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    ////tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    //tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                    tr_rowagent.Text += " <tr style=''>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    // tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    // tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";

                                    // tr_rowagent.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";
                                }
                                else
                                {
                                    tr_row.Text += " <tr style=''>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td>";//sindhu
                                    tr_row.Text += "<td style='color:#000000; padding:0px 2px 0px 2px;  border-right: 1px solid Black;'>&nbsp;</td></tr>";//sindhu
                                }
                            }
                        }

                        if (customertype == "P")
                        {
                            if (temp_taxable > 0)
                            {
                                td_taxableamt_agent.InnerText = temp_taxable.ToString("#,0.00");
                            }
                            if (cgsta > 0)
                            {
                                td_cgsta_agent.InnerText = cgsta.ToString("#,0.00");
                            }
                            if (sgsta > 0)
                            {
                                td_sgsta_agent.InnerText = sgsta.ToString("#,0.00");
                            }
                            if (igsta > 0)
                            {
                                td_igsta_agent.InnerText = igsta.ToString("#,0.00");
                            }
                        }
                        else
                        {
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
                    }
                    else
                    {
                        lbl_head.Text = "CREDIT NOTE";
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
                        ///lbl_currword.Text = th_basecurr.InnerText +"  "+ConvertNumbertoWords(Convert.ToInt32(price1)) + " ONLY";
                        if (customertype == "P")
                        {
                            if (curr_count == 1)
                            {
                                //TH_CURR.InnerText = "(" + currency + ")";
                                lbl_taxcurr.InnerText = "(" + currency + ")";
                                if (currency == "")
                                {
                                    currency = "(USD)";
                                    //TH_CURR.InnerText = currency;
                                    lbl_taxcurr.InnerText = currency;
                                }
                                else if (currency == "INR")
                                {
                                    currency = " RUPEES";
                                }
                                //lbl_currword.Text = currency + "  : " + conversion(total_agent.Text, currency) + " ONLY";
                                lbl_currword.Text = currency + " " + conversion(total_agent.Text, currency) + " ONLY";
                            }
                            else
                            {
                                lbl_currword.Text = "USD" + " " + conversion(total_agent.Text, currency) + " ONLY";
                            }
                        }
                        else
                        {
                            if (currency == "INR")
                            {
                                currency = " RUPEES";

                                lbl_currword.Text = "RUPEES " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                            }
                            else
                            {
                                if (th_basecurr.InnerText == "INR")
                                {
                                    lbl_currword.Text = "RUPEES" + " " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                                }
                                else
                                {
                                    lbl_currword.Text = th_basecurr.InnerText + " " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                                }
                            }
                            // lbl_currword.Text = th_basecurr.InnerText + "  : " + conversion(lbl_total.Text, th_basecurr.InnerText) + " ONLY";
                        }
                    }
                    if ((Header == "DN" || Header == "CN") && Profoma == "")
                    {
                        lbl_prepared.Text = dt.Rows[0]["preparedby"].ToString();
                        lbl_approved.Text = dt.Rows[0]["ApprovedBy"].ToString();
                        div_prepare.Visible = true;
                        div_cnops.Visible = true;
                        div_approve.Visible = true;
                    }
                }



                /////END



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
                    if (!string.IsNullOrEmpty(dt.Rows[0]["gstin"].ToString()))
                    {
                        lbl_toaddress.Text += "<strong>GST # :</strong>" + dt.Rows[0]["gstin"].ToString() + ",";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["statename"].ToString()))
                    {
                        lbl_toaddress.Text += "<strong>State  :</strong>" + dt.Rows[0]["statename"].ToString() + ",";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["gstcode"].ToString()))
                    {
                        lbl_toaddress.Text += "<strong>Code # :</strong>" + dt.Rows[0]["gstcode"].ToString() + ".";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                    }


                    //  div_gst.Text = dt.Rows[0]["gstin"].ToString().ToUpper().ToUpper();
                    //  gst_state.Text = dt.Rows[0]["statename"].ToString().ToUpper();

                    //   gst_code.Text = dt.Rows[0]["gstcode"].ToString().ToUpper();
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
                            lbl_tosupply.Text += dt.Rows[0]["statename"].ToString().ToUpper() + "<br />";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["ptc"].ToString()))
                        {
                            lbl_tosupply.Text += "<strong>PTC :</strong>" + dt.Rows[0]["ptc"].ToString().ToUpper() + " ";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                        {
                            lbl_tosupply.Text += "<strong>PH :</strong>" + dt.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        }


                        if (!string.IsNullOrEmpty(dt.Rows[0]["gstin"].ToString()))
                        {
                            lbl_tosupply.Text += "<strong>GST # :</strong>" + dt.Rows[0]["gstin"].ToString() + ",";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["statename"].ToString()))
                        {
                            lbl_tosupply.Text += "<strong>State  :</strong>" + dt.Rows[0]["statename"].ToString() + ",";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["gstcode"].ToString()))
                        {
                            lbl_tosupply.Text += "<strong>Code # :</strong>" + dt.Rows[0]["gstcode"].ToString() + ".";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        }
                        //b hide
                        //  div_supplygst.InnerText = dt.Rows[0]["gstin"].ToString().ToUpper().ToUpper();
                        //  div_supplystate.InnerText = dt.Rows[0]["statename"].ToString().ToUpper();
                        //  div_supplycode.InnerText = dt.Rows[0]["gstcode"].ToString().ToUpper();
                        //b hide
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["statename"].ToString().ToUpper()))
                        //{
                        //    lbl_pos.Text = dt.Rows[0]["statename"].ToString().ToUpper();
                        //}
                        //else
                        //{
                        //    div2.Visible = false;
                        //}
                        DataTable dtt = new DataTable();
                        if (Profoma != "Profoma")
                        {
                           // DataAccess.Documents objnew = new DataAccess.Documents();
                            dtt = objnew.getgstpod(invoice, bid, vouyear, "I");
                            if (dtt.Rows.Count > 0)
                            {
                                lbl_pos.Text = dtt.Rows[0][0].ToString();
                            }
                            else
                            {
                                //        div2.Visible = false; --T
                            }
                        }
                        else
                        {
                            //     div2.Visible = false;--T
                        }
                    }
                }
                //div_sign.Visible = false;
                //div_authorised.Visible = true;
                if (Profoma == "Profoma")
                {
                    divqr.Visible = false;
                    DIVIRN.Visible = false;
                    LBLNO.InnerText = "Refno #";
                    //  div_approve.Visible = false; --T

                    //if (str_trantype == "CH")
                    //{
                    //    div_port.Visible = true;
                    //    div_port1.Visible = true;
                    //}
                }
                if (str_trantype == "CH")
                {
                    //     div_port.Visible = true;
                    //     div_port1.Visible = true;
                }

                if (str_trantype == "OI")
                {
                    //      div_OBL.Visible = true;
                }
                else
                {
                    //      div_OBL.Visible = false;
                }

                if (Request.QueryString.ToString().Contains("rptvoutype"))
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
            }





            catch (Exception ex)
            {
                //string message = ex.Message.ToString();
                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

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
                Content = beforefloating + ' ' + "" + ' ' + afterfloating + ' ';// + " PAISE ";   INDIAN RUPEES
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
                Content = beforefloating + ' ' + " 	HONG KONG DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "JPY")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " 	JAPANESE YEN " + ' ' + afterfloating + ' ' + " SEN ";
            }
            else if (curr == "NZD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " 	NEW ZEALAND DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "SEK")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
                Content = beforefloating + ' ' + " 	SWEDISH KRONA " + ' ' + afterfloating + ' ' + " ORE ";
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
            return Content;
        }

        public string ConvertNumbertoWordsINR(long number)
        {
            //if (number == 0) return "ZERO";
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
            // words += ConvertNumbertoWords(number / 10) + " RUPEES";
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