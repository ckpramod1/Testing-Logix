using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class Combinedquotrpt : System.Web.UI.Page
    {
        DataAccess.Marketing.Quotation quotation = new DataAccess.Marketing.Quotation();

        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        int quotid, version;
        string strtrantype;
        double usd = 0;
        double eur = 0;
        double tot = 0, tot1 = 0;
        double fctot = 0, fctot1 = 0;
        int count, cou, add;
        DataTable dtterms = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string Ccode = Convert.ToString(Session["Ccode"]);
                if (Ccode != "")
                {

                    quotation.GetDataBase(Ccode);
                    masterObj.GetDataBase(Ccode);
                    //objbid.GetDataBase(Ccode);
                    //da_obj_Log.GetDataBase(Ccode);
                    //FrontpageObj.GetDataBase(Ccode);
                    //EXobj.GetDataBase(Ccode);
                    //da_obj_Logobj.GetDataBase(Ccode);
                }
                if (Request.QueryString.ToString().Contains("Quoteno"))
                {
                //    DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    quotid = Convert.ToInt32(Request.QueryString["Quoteno"].ToString());
                    title.InnerText = "Quotation # " + quotid;
                    version = Convert.ToInt32(Request.QueryString["version"].ToString());
                    DataSet ds = new DataSet();
                    DataTable dtQuot = new DataTable();
                    DataTable DtQuoteDtls = new DataTable();
                    DataTable DtQuotecoont = new DataTable();
                    strtrantype = Session["StrTranType"].ToString();

                    ds = quotation.GetcombbinedQuotationrpt(quotid, strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), version);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtQuot = ds.Tables[0];
                        DtQuoteDtls = ds.Tables[1];
                        DtQuotecoont = ds.Tables[2];
                        if (dtQuot.Rows.Count > 0)
                        {
                            lbl_comaddress.Text = dtQuot.Rows[0]["address"].ToString();
                            lbl_company.Text = dtQuot.Rows[0]["branchname"].ToString();
                            lbl_name.Text = dtQuot.Rows[0]["cust"].ToString();
                            //lbl_contact.Text = dtQuot.Rows[0]["CustomerAddress"].ToString();
                            lbl_contact.Text = dtQuot.Rows[0]["CustomerAddress1"].ToString();
                            lbl_quotno.Text = dtQuot.Rows[0]["quotation"].ToString();
                            lbl_address.Text = dtQuot.Rows[0]["CustomerAddress"].ToString();
                            lbl_service.Text = dtQuot.Rows[0]["service"].ToString();
                            lbl_issuedt.Text = dtQuot.Rows[0]["quotdatedt"].ToString();
                            lbl_valid.Text = dtQuot.Rows[0]["validtilldt"].ToString();
                            lbl_salesperson.Text = dtQuot.Rows[0]["salesperson"].ToString();
                            lblsales.Text = dtQuot.Rows[0]["salesperson"].ToString();
                            lbl_preparedby.Text = dtQuot.Rows[0]["preparedby1"].ToString();
                            lbl_shipper.Text = dtQuot.Rows[0]["shipper"].ToString();
                            lbl_consignee.Text = dtQuot.Rows[0]["consignee"].ToString();
                            lbl_descn.Text = dtQuot.Rows[0]["descn"].ToString().ToUpper();
                            lbl_value.Text = dtQuot.Rows[0]["value"].ToString().ToUpper();
                            lbl_haz.Text = dtQuot.Rows[0]["haz"].ToString();
                            lbl_inco.Text = dtQuot.Rows[0]["incoterm"].ToString();
                            lbl_pod.Text = dtQuot.Rows[0]["podname"].ToString();
                            lbl_por.Text = dtQuot.Rows[0]["porname"].ToString();
                            lbl_pickup.Text = dtQuot.Rows[0]["porname"].ToString();
                            lbl_pol.Text = dtQuot.Rows[0]["polname"].ToString();
                            lbl_fd.Text = dtQuot.Rows[0]["fdname"].ToString();
                            lbl_porcountry.Text = dtQuot.Rows[0]["porcountry"].ToString().ToUpper();
                            lbl_podcountry.Text = dtQuot.Rows[0]["fdcountry"].ToString().ToUpper();
                            lbl_impexp.Text = dtQuot.Rows[0]["type"].ToString();
                            lbl_pieces.Text = dtQuot.Rows[0]["pieces"].ToString();
                            lbl_noofunits.Text = dtQuot.Rows[0]["noofunits"].ToString();
                            lbl_grwt.Text = dtQuot.Rows[0]["grwt"].ToString();
                            lbl_cargo.Text = dtQuot.Rows[0]["cargo"].ToString();
                            lbl_carrier.Text = dtQuot.Rows[0]["carriername"].ToString();
                            //  lbl_conttype.Text = dtQuot.Rows[0]["conttype"].ToString();
                            lbl_remarks.Text = dtQuot.Rows[0]["remarks"].ToString().ToUpper();
                            lbl_for.Text = dtQuot.Rows[0]["branchname"].ToString();
                            lbl_contactname.Text = dtQuot.Rows[0]["ptc"].ToString();
                            lbl_appro.Text = dtQuot.Rows[0]["approvedbyname"].ToString();
                            if (strtrantype == "FE" || strtrantype == "FI")
                            {
                                lblservice.Text = "Service (FCL/LCL)";
                                lblloading.Text = "Port of Loading";
                                lbldischarge.Text = "Port of Discharge";

                                lblcontwt.Text = "Type & No of containers";

                            }
                            else
                            {
                                lblloading.Text = "Port of Loading";
                                lbldischarge.Text = "Port of Discharge";
                                lblservice.Text = "Service";
                                lblcontwt.Text = "Chargeable Weight (KGS)";
                                lbl_noofcont.Text = dtQuot.Rows[0]["chrageblewt"].ToString();
                            }
                            lbl_dim.Text = dtQuot.Rows[0]["dimension"].ToString().ToUpper();
                            lbl_ship.Text = dtQuot.Rows[0]["shipper"].ToString();
                            if (dtQuot.Rows[0]["transittime"].ToString() != "")
                            {
                                lbl_transittime.Text = " & " + dtQuot.Rows[0]["transittime"].ToString().ToUpper();

                            }
                            lbl_routing.Text = dtQuot.Rows[0]["routing"].ToString().ToUpper();
                            lbl_volume.Text = dtQuot.Rows[0]["volume"].ToString().ToUpper();
                            if (dtQuot.Rows[0]["custpono"].ToString() != "")
                            {
                                lbl_ref.Text = dtQuot.Rows[0]["custpono"].ToString().ToUpper();
                            }
                            lblbascurr.Text = dtQuot.Rows[0]["basecurr"].ToString().ToUpper();
                            //if (version.ToString()!="0")
                            //{
                            //    lbl_version.Text = version.ToString();

                            //}
                            //string type = lbl_service.Text;
                            //if (strtrantype=="AI" || strtrantype=="AE")
                            //{
                            //    type = "AIR";
                            //}

                            //dtterms = quotation.Getterms(type, strtrantype);
                            //if(dtterms.Rows.Count>0)
                            //{
                            lbl_terms.Text = dtQuot.Rows[0]["terms"].ToString();
                            //}
                        }
                        if (DtQuotecoont.Rows.Count > 0)
                        {
                            if (DtQuotecoont.Rows.Count == 1)
                            {
                                lbl_conttype.Text = DtQuotecoont.Rows[0]["conttype"].ToString();
                                lbl_noofcont.Text = DtQuotecoont.Rows[0]["conttype"].ToString();
                            }

                            else
                            {
                                for (int i = 0; i < DtQuotecoont.Rows.Count; i++)
                                {
                                    lbl_conttype.Text += DtQuotecoont.Rows[i]["conttype"].ToString() + " , ";
                                    lbl_noofcont.Text += DtQuotecoont.Rows[i]["conttype"].ToString() + " , ";
                                }
                            }
                        }
                        if (DtQuoteDtls.Rows.Count > 0)
                        {
                            count = DtQuoteDtls.Rows.Count;
                            if (count < 17)
                            {
                                cou = 17 - count;
                                add = cou + count;

                                for (int i = 0; i < DtQuoteDtls.Rows.Count; i++)
                                {
                                    if ((DtQuoteDtls.Rows[i]["base"]).ToString() == "AT ACTUALS" || (DtQuoteDtls.Rows[i]["base"]).ToString() == "W/M")
                                    {
                                        if (i % 2 == 0)
                                        {
                                            tdRow_QuotDtls.Text += "<tr>";
                                            tdRow_QuotDtls.Text += "<td style='border-right:0px solid #000;  border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>" + DtQuoteDtls.Rows[i]["quotcharge"] + "</td>";
                                            if (DtQuoteDtls.Rows[i]["curr"].ToString() != "")
                                            {

                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:0px solid #000;border-bottom:0px solid #000;width:100px; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                            }
                                            if ((DtQuoteDtls.Rows[i]["base"]).ToString() == "W/M")
                                            {
                                                if (DtQuoteDtls.Rows[i]["sellrate"].ToString() != "")
                                                {
                                                    tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["sellrate"]).ToString("#,0.00") + "</td>";
                                                }
                                            }
                                            else
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '> - </td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["exrate"].ToString() != "")
                                            {

                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-right:0px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["exrate"]).ToString("#,0.00") + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["base"].ToString() != "")
                                            {

                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-right:0px solid #000;border-bottom:0px solid #000;width:220px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + (DtQuoteDtls.Rows[i]["base"]).ToString() + "</td>";
                                            }
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-right:0px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'> - </td>";
                                            //if ((DtQuoteDtls.Rows[i]["base"]).ToString()=="W/M")
                                            //{
                                            //    if (DtQuoteDtls.Rows[i]["sellrate"].ToString() != "")
                                            //    {
                                            //        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:0px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["sellrate"]).ToString("#,0.00") + "</td>";
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:0px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '> - </td>";
                                            //}

                                            //tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:0px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-right:0px solid #000;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'> - </td>";
                                            tdRow_QuotDtls.Text += "</tr>";
                                        }
                                        else
                                        {
                                            tdRow_QuotDtls.Text += "<tr>";
                                            tdRow_QuotDtls.Text += "<td style='border-right:1px solid #000;background-color: #fff;border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>" + DtQuoteDtls.Rows[i]["quotcharge"] + "</td>";
                                            if (DtQuoteDtls.Rows[i]["curr"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:100px; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                            }
                                            if ((DtQuoteDtls.Rows[i]["base"]).ToString() == "W/M")
                                            {
                                                if (DtQuoteDtls.Rows[i]["sellrate"].ToString() != "")
                                                {
                                                    tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["sellrate"]).ToString("#,0.00") + "</td>";
                                                }
                                            }
                                            else
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '> - </td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["exrate"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["exrate"]).ToString("#,0.00") + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["base"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:220px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + (DtQuoteDtls.Rows[i]["base"]).ToString() + "</td>";
                                            }

                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'> - </td>";
                                            //if ((DtQuoteDtls.Rows[i]["base"]).ToString() == "W/M")
                                            //{
                                            //    if (DtQuoteDtls.Rows[i]["sellrate"].ToString() != "")
                                            //    {
                                            //        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["sellrate"]).ToString("#,0.00") + "</td>";
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '> - </td>";
                                            //}
                                            //tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:0px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'> - </td>";
                                            tdRow_QuotDtls.Text += "</tr>";
                                        }
                                    }
                                    else
                                    {
                                        if (i % 2 == 0)
                                        {
                                            tdRow_QuotDtls.Text += "<tr>";
                                            tdRow_QuotDtls.Text += "<td style='border-right:0px solid #000;   border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5; border-right:1px solid #000; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>" + DtQuoteDtls.Rows[i]["quotcharge"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:1px solid #000;border-bottom:0px solid #000; border-right:1px solid #000;width:100px; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                            if (DtQuoteDtls.Rows[i]["sellrate"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["sellrate"]).ToString("#,0.00") + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["exrate"].ToString() != "")
                                            {

                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:150px; border-right:1px solid #000;padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["exrate"]).ToString("#,0.00") + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["base"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:220px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + (DtQuoteDtls.Rows[i]["base"]).ToString() + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["expqty"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:150px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["expqty"]).ToString("#,0.00") + "</td>";
                                            }

                                            if (DtQuoteDtls.Rows[i]["fcamount"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:1px solid #000;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["fcamount"]).ToString("#,0.00") + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["amount"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000  border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["amount"]).ToString("#,0.00") + "</td>";
                                                tdRow_QuotDtls.Text += "</tr>";
                                            }
                                        }
                                        else
                                        {
                                            tdRow_QuotDtls.Text += "<tr>";
                                            tdRow_QuotDtls.Text += "<td style='border-right:1px solid #000;background-color: #fff;border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5;border-right:1px solid #000; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>" + DtQuoteDtls.Rows[i]["quotcharge"] + "</td>";
                                            if (DtQuoteDtls.Rows[i]["curr"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:100px; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["sellrate"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["sellrate"]).ToString("#,0.00") + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["exrate"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["exrate"]).ToString("#,0.00") + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["base"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:220px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + (DtQuoteDtls.Rows[i]["base"]).ToString() + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["expqty"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["expqty"]).ToString("#,0.00") + "</td>";
                                            }

                                            if (DtQuoteDtls.Rows[i]["fcamount"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["fcamount"]).ToString("#,0.00") + "</td>";
                                            }
                                            if (DtQuoteDtls.Rows[i]["amount"].ToString() != "")
                                            {
                                                tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["amount"]).ToString("#,0.00") + "</td>";
                                            }
                                            tdRow_QuotDtls.Text += "</tr>";
                                        }
                                    }
                                    if (DtQuoteDtls.Rows[i]["usd"].ToString() != "")
                                    {
                                        usd = Convert.ToDouble(DtQuoteDtls.Rows[i]["usd"]);
                                    }
                                    if (DtQuoteDtls.Rows[i]["eur"].ToString() != "")
                                    {
                                        eur = Convert.ToDouble(DtQuoteDtls.Rows[i]["eur"]);
                                    }
                                }
                                for (int i = 0; i < cou; i++)
                                {
                                    if ((DtQuoteDtls.Rows.Count - 1) % 2 == 0 && i == 0)
                                    {
                                        i = 1;
                                    }
                                    if (i % 2 == 0)
                                    {
                                        tdRow_QuotDtls.Text += "<tr>";
                                        tdRow_QuotDtls.Text += "<td style='border-right:0px solid #000;   border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5;  border-right:1px solid #000; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:100px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:150px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:220px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:150px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:250px; border-right:1px solid #000;padding:5px 5px 5px 5px; margin:5px; text-align:right;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "</tr>";
                                    }
                                    else
                                    {
                                        tdRow_QuotDtls.Text += "<tr>";
                                        tdRow_QuotDtls.Text += "<td style='border-right:0px solid #000;background-color: #fff;border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5;border-right:1px solid #000; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:100px; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:220px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'>&nbsp;</td>";
                                        tdRow_QuotDtls.Text += "</tr>";
                                    }
                                }

                            }
                            else
                            {


                                for (int i = 0; i < DtQuoteDtls.Rows.Count; i++)
                                {
                                    if ((DtQuoteDtls.Rows[i]["base"]).ToString() == "AT ACTUALS" || (DtQuoteDtls.Rows[i]["base"]).ToString() == "W/M")
                                    {
                                        if (i % 2 == 0)
                                        {
                                            tdRow_QuotDtls.Text += "<tr>";
                                            tdRow_QuotDtls.Text += "<td style='border-right:0px solid #000;  border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>" + DtQuoteDtls.Rows[i]["quotcharge"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:0px solid #000;border-bottom:0px solid #000;width:100px; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-right:0px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["exrate"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-right:0px solid #000;border-bottom:0px solid #000;width:220px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + (DtQuoteDtls.Rows[i]["base"]).ToString() + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-right:0px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-right:0px solid #000;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000; border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'> - </td>";
                                            tdRow_QuotDtls.Text += "</tr>";
                                        }
                                        else
                                        {
                                            tdRow_QuotDtls.Text += "<tr>";
                                            tdRow_QuotDtls.Text += "<td style='border-right:0px solid #000;background-color: #fff;border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5; padding:5px 5px 5px 10px;border-right:1px solid #000; margin:5px; text-align:left; '>" + DtQuoteDtls.Rows[i]["quotcharge"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:100px; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["exrate"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:220px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + (DtQuoteDtls.Rows[i]["base"]).ToString() + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'> - </td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'> - </td>";
                                            tdRow_QuotDtls.Text += "</tr>";
                                        }
                                    }
                                    else
                                    {
                                        if (i % 2 == 0)
                                        {
                                            tdRow_QuotDtls.Text += "<tr>";
                                            tdRow_QuotDtls.Text += "<td style='border-right:1px solid #000;   border-bottom:0px solid #000;width:300px; border-left:1px solid #F5F5F5;border-right:1px solid #000; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>" + DtQuoteDtls.Rows[i]["quotcharge"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:100px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["sellrate"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:0px solid #000;border-bottom:0px solid #000;width:150px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["exrate"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:1px solid #000;border-bottom:0px solid #000;width:220px; border-right:1px solid #000;padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + (DtQuoteDtls.Rows[i]["base"]).ToString() + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:1px solid #000;border-bottom:0px solid #000;width:150px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["expqty"]).ToString("#,0.00") + "</td>";

                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;   border-right:1px solid #000;border-bottom:0px solid #000;width:250px;border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["fcamount"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;  border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["amount"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "</tr>";
                                        }
                                        else
                                        {
                                            tdRow_QuotDtls.Text += "<tr>";
                                            tdRow_QuotDtls.Text += "<td style='border-right:0px solid #000;background-color: #fff;border-bottom:0px solid #000;width:300px; border-left:1px solid #000; padding:5px 5px 5px 10px; margin:5px; text-align:left; '>" + DtQuoteDtls.Rows[i]["quotcharge"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:100px; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["exrate"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:220px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + (DtQuoteDtls.Rows[i]["base"]).ToString() + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["expqty"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:150px; padding:5px 5px 5px 5px; margin:5px; text-align:right; '>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["sellrate"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-right:1px solid #000;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["fcamount"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "<td style='border-left:0px solid #000;background-color: #fff;border-bottom:0px solid #000;width:250px; padding:5px 5px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["amount"]).ToString("#,0.00") + "</td>";
                                            tdRow_QuotDtls.Text += "</tr>";
                                        }
                                    }

                                    if (DtQuoteDtls.Rows[i]["usd"].ToString() != "")
                                    {
                                        usd = Convert.ToDouble(DtQuoteDtls.Rows[i]["usd"]);
                                    }
                                    if (DtQuoteDtls.Rows[i]["eur"].ToString() != "")
                                    {
                                        eur = Convert.ToDouble(DtQuoteDtls.Rows[i]["eur"]);
                                    }
                                }
                            }
                            if (eur != 0.00)
                            {
                                lbl_eur.Text = eur.ToString("#,0.00");
                            }
                            if (usd != 0.00)
                            {
                                lbl_usd.Text = usd.ToString("#,0.00");
                            }

                            for (int i = 0; i < DtQuoteDtls.Rows.Count; i++)
                            {
                                if (DtQuoteDtls.Rows[i]["amount"].ToString() != "")
                                {

                                    tot1 = Convert.ToDouble(DtQuoteDtls.Rows[i]["amount"]);
                                    tot = tot + tot1;
                                }
                            }
                            lbltotal.Text = tot.ToString("#,0.00");
                            for (int i = 0; i < DtQuoteDtls.Rows.Count; i++)
                            {

                                if (DtQuoteDtls.Rows[i]["fcamount"].ToString() != "")
                                {
                                    fctot1 = Convert.ToDouble(DtQuoteDtls.Rows[i]["fcamount"]);
                                    fctot = fctot + fctot1;
                                }
                            }
                            lblFCtotal.Text = fctot.ToString("#,0.00");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
    }
}