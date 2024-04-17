using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace logix.Reportasp
{
    public partial class ReceiptFARpt : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.LogDetails ObjLog = new DataAccess.LogDetails();
        DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();

        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        int ReceiptId, bid, vouyear, customerid, page_, row_count, supplyto;
        string Mode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                custobj.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                ObjLog.GetDataBase(Ccode);
                obj_inv.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);

            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            try
            {
              //  DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    lbl_wiz.ImageUrl = "data:image/png;base64," + base64String; 
                }
                 
                lblToday.Text = ObjLog.GetDate().ToString("dd/MM/yyyy");
                if (Request.QueryString.ToString().Contains("ReceiptId"))
                {
                    ReceiptId = Convert.ToInt32(Request.QueryString["ReceiptId"]);
                    vouyear = Convert.ToInt32(Request.QueryString["Vouyear"]);
                    Mode = Request.QueryString["Mode"];
                    if (Mode == "B")
                    {
                        lbl_head.Text = "Bank Receipt";
                        trcheque.Visible = true;
                    }
                    else if (Mode == "C")
                    {
                        lbl_head.Text = "Cash Receipt";
                    }
                    else if (Mode == "P")
                    {
                        lbl_head.Text = "Petty Cash Receipt";
                    }
                    DataSet DS = objRpt.GetReceiptRptByRecId(ReceiptId);
                    if (DS.Tables.Count > 0)
                    {
                        DataTable DtRecHead = DS.Tables[0];
                        DataTable DtCustDtls = DS.Tables[1];
                        DataTable DtRecPaymentDtls = DS.Tables[2];
                        DataTable DtRecChargeDtls = DS.Tables[3];
                        DataTable DtTot = DS.Tables[4];

                        if (DtRecHead.Rows.Count > 0)
                        {
                            lblDivName.Text = DtRecHead.Rows[0]["Divisionname"].ToString();
                            lblAddress.Text = DtRecHead.Rows[0]["Address"].ToString();
                            lblphonefax.Text = "Ph" + DtRecHead.Rows[0]["phone"].ToString() + "/ Fax " + DtRecHead.Rows[0]["fax"].ToString();
                            lblRecno.Text = DtRecHead.Rows[0]["Receiptno"].ToString();
                            lblRecDate.Text = DtRecHead.Rows[0]["ReceiptDate"].ToString();
                            lblReceivedfrom.Text = DtRecHead.Rows[0]["Receiptfrom"].ToString();
                            lblRecId.Text = DtRecHead.Rows[0]["Receiptid"].ToString();
                            lblchequeno.Text = DtRecHead.Rows[0]["chequeno"].ToString();
                            lblbank.Text = DtRecHead.Rows[0]["bankname"].ToString();
                            lblnarration.Text = DtRecHead.Rows[0]["naration"].ToString();
                            lblpreparedby.Text = DtRecHead.Rows[0]["Preparedby"].ToString();
                        }
                        if (DtCustDtls.Rows.Count > 0)
                        {
                            lbltotal.Text = Convert.ToDouble(DtCustDtls.Compute("sum(Amount)", string.Empty)).ToString("#,0.00");
                            for (int i = 0; i < DtCustDtls.Rows.Count; i++)
                            {
                                tr_Lblcustamount.Text += "  <tr>";
                                tr_Lblcustamount.Text += "<td colspan='2' style='border-right:1px solid #000; padding:5px 5px 2px 5px; margin:0px; text-align:left; border-right:1px solid #000;border-bottom:1px solid #80808042'>" + DtCustDtls.Rows[i]["Customer"].ToString() + "</td>";
                                tr_Lblcustamount.Text += " <td style='padding:5px 10px 2px 5px; margin:2px 0px 2px 0px; text-align:right;border-bottom:1px solid #80808042'>" + Convert.ToDouble(DtCustDtls.Rows[i]["Amount"]).ToString("#,0.00") + " </td>";
                                tr_Lblcustamount.Text += "</tr>";
                            }
                        }
                        if (DtRecPaymentDtls.Rows.Count > 0)
                        {
                            if (DtRecPaymentDtls.Rows.Count <= 30)
                            {
                                //lbrecpayltotal.Text = Convert.ToDouble(DtRecPaymentDtls.Compute("sum(vamount)", string.Empty)).ToString("#,0.00");
                                for (int i = 0; i < DtRecPaymentDtls.Rows.Count; i++)
                                {
                                    tr_row.Text += "  <tr>";
                                    tr_row.Text += " <td style='border-right:0px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:center; border-right:0px solid #000;'>" + DtRecPaymentDtls.Rows[i]["Branchshort"].ToString() + "</td>";
                                    tr_row.Text += "<td style='border-right:0px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:0px solid #000;'>" + DtRecPaymentDtls.Rows[i]["vounumbers"].ToString() + "</td>";
                                    tr_row.Text += "<td style='border-right:0px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:center; border-right:0px solid #000;'>" + DtRecPaymentDtls.Rows[i]["VouDate"].ToString() + "</td>";
                                    tr_row.Text += " <td style='border-right:0px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:right; '>" + Convert.ToDouble(DtRecPaymentDtls.Rows[i]["vamount"]).ToString("#,0.00") + "</td></tr>";
                                }
                            }
                            else
                            {
                                for (int i = 0; i < 30; i++)
                                {
                                    tr_row.Text += "  <tr>";
                                    tr_row.Text += " <td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:center; border-right:1px solid #000;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000;'>&nbsp;</td>";
                                    tr_row.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:center; border-right:1px solid #000;'>&nbsp;</td>";
                                    tr_row.Text += " <td style='border-right:0px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:right; '>&nbsp;</td></tr>";
                                }
                                string str_Script = "";
                                str_Script = "window.open('../Reportasp/ReceiptAnnexureFARpt.aspx?ReceiptId=" + ReceiptId + "&vouyear=" + vouyear + "&Mode=" + Mode + "','','');";
                                ScriptManager.RegisterStartupScript(btnreport, typeof(Button), "Receipt", str_Script, true);
                                //return;
                            }
                        }

                        if (DtRecChargeDtls.Rows.Count > 0)
                        {
                            for (int i = 0; i < DtRecChargeDtls.Rows.Count; i++)
                            {
                                tr_LblChargedtls.Text += "<tr>";
                                tr_LblChargedtls.Text += "<td colspan='2' style='border-right:1px solid #000; padding:2px 25px 2px 5px; margin:2px; text-align:right;'>" + DtRecChargeDtls.Rows[i]["Charges"].ToString() + "</td>";
                                tr_LblChargedtls.Text += "<td style='padding:2px 10px 2px 5px; margin:2px; text-align:right; border-top:0px solid #000; '>" + Convert.ToDouble(DtRecChargeDtls.Rows[i]["Amount"]).ToString("#,0.00") + "</td>";
                                tr_LblChargedtls.Text += "</tr>";
                            }
                        }
                        if (DtCustDtls.Rows.Count > 0 && DtRecChargeDtls.Rows.Count > 0)
                        {
                            double totCustamt, totchargeamt;
                            totCustamt = Convert.ToDouble(DtCustDtls.Compute("sum(Amount)", string.Empty).ToString());
                            totchargeamt = Convert.ToDouble(DtRecChargeDtls.Compute("sum(Amount)", string.Empty).ToString());
                            lbltotal.Text = Convert.ToDouble((totCustamt + totchargeamt)).ToString("#,0.00");
                        }
                        if (DtTot.Rows.Count > 0)
                        {
                            if (DtRecPaymentDtls.Rows.Count > 0)
                            {
                                if (DtRecPaymentDtls.Rows.Count <= 30)
                                {
                                    lbrecpayltotal.Text = Convert.ToDouble(DtTot.Rows[0]["RecPayTotAmt"]).ToString("#,0.00");
                                }
                                else
                                {
                                    tblVouDtls.Visible = false;
                                    divannexDtls.Visible = true;
                                    lblannex.Text = "VOUCHER DETAILS AS PER ATTACHED LIST";
                                }
                            }
                        }
                        lblRupeesinwords.Text = conversion(lbltotal.Text, "INR");
                    }
                }
                //mar 3 23 added for wiz logo
                DataTable dtbranch = new DataTable();
                string vtype = "";
               

                dtbranch = obj_inv.Getbranchdetails4report("CR", ReceiptId, vouyear, bid);
                if (dtbranch.Rows.Count > 0)
                {
                    lblDivName.Text = dtbranch.Rows[0]["branchname"].ToString().ToUpper().ToUpper();                  
                    div_form.Visible = false;
                    lblformaly.Visible = false;
                    lbl_wiz.Visible = true;
                }
                else
                {

                    div_form.Visible = true;
                    lblformaly.Visible = true;
                    lbl_wiz.Visible = true;
                    img_Logo.Visible = true;
                    
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString().Replace("'", "");
                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " INDIAN RUPEES";
                }
                else
                {
                    Content = beforefloating + ' ' + " INDIAN RUPEES" + ' ' + afterfloating + ' ' + " PAISE ";
                }
                //Content = beforefloating + ' ' + " INDIAN RUPEES" + ' ' + afterfloating + ' ' + " PAISE ";
            }
            else if (curr == "USD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " US DOLLARS ";
                }
                else
                {
                    Content = beforefloating + ' ' + " US DOLLARS " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " US DOLLARS " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "AED")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " UAE DIRHAM ";
                }
                else
                {
                    Content = beforefloating + ' ' + " UAE DIRHAM " + ' ' + afterfloating + ' ' + " FILS ";
                }
                //Content = beforefloating + ' ' + " UAE DIRHAM " + ' ' + afterfloating + ' ' + " FILS ";
            }
            else if (curr == "AUD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " AUSTRALIAN DOLLARS ";
                }
                else
                {
                    Content = beforefloating + ' ' + " AUSTRALIAN DOLLARS " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " AUSTRALIAN DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "CAD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " CANADIAN DOLLARS ";
                }
                else
                {
                    Content = beforefloating + ' ' + " CANADIAN DOLLARS " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " CANADIAN DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "CHF")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " SWISS FRANC ";
                }
                else
                {
                    Content = beforefloating + ' ' + " SWISS FRANC " + ' ' + afterfloating + ' ' + " RAPPEN ";
                }
                //Content = beforefloating + ' ' + " SWISS FRANC " + ' ' + afterfloating + ' ' + " RAPPEN ";
            }
            else if (curr == "CNY")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " CHINESE YUAN RENMINBI ";
                }
                else
                {
                    Content = beforefloating + ' ' + " CHINESE YUAN RENMINBI " + ' ' + afterfloating + ' ' + " JIAO (FEN) ";
                }
                //Content = beforefloating + ' ' + " CHINESE YUAN RENMINBI " + ' ' + afterfloating + ' ' + " JIAO (FEN) ";
            }
            else if (curr == "DKK")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " DANISH KRONE ";
                }
                else
                {
                    Content = beforefloating + ' ' + " DANISH KRONE " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " DANISH KRONE " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "ETB")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " ETHIOPIAN BIRR ";
                }
                else
                {
                    Content = beforefloating + ' ' + " ETHIOPIAN BIRR " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " ETHIOPIAN BIRR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "EUR")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " EURO ";
                }
                else
                {
                    Content = beforefloating + ' ' + " EURO " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " EURO " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "GBP")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " POUNDS ";
                }
                else
                {
                    Content = beforefloating + ' ' + " POUNDS " + ' ' + afterfloating + ' ' + " PENCE ";
                }
                //Content = beforefloating + ' ' + " POUNDS " + ' ' + afterfloating + ' ' + " PENCE ";
            }
            else if (curr == "HKD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " HONG KONG DOLLARS ";
                }
                else
                {
                    Content = beforefloating + ' ' + " HONG KONG DOLLARS " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " 	HONG KONG DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "JPY")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " JAPANESE YEN ";
                }
                else
                {
                    Content = beforefloating + ' ' + " JAPANESE YEN " + ' ' + afterfloating + ' ' + " SEN ";
                }
                //Content = beforefloating + ' ' + " 	JAPANESE YEN " + ' ' + afterfloating + ' ' + " SEN ";
            }
            else if (curr == "NZD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " NEW ZEALAND DOLLAR ";
                }
                else
                {
                    Content = beforefloating + ' ' + " NEW ZEALAND DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " 	NEW ZEALAND DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "SEK")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + "    SWEDISH KRONA ";
                }
                else
                {
                    Content = beforefloating + ' ' + "    SWEDISH KRONA " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " 	SWEDISH KRONA " + ' ' + afterfloating + ' ' + " ORE ";
            }
            else if (curr == "SGD")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " SINGAPORE DOLLARS ";
                }
                else
                {
                    Content = beforefloating + ' ' + " SINGAPORE DOLLARS " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " SINGAPORE DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            else if (curr == "ZAR")
            {
                var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
                var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));

                if (afterfloating == "ZERO")
                {
                    Content = beforefloating + ' ' + " SOUTH AFRICAN RAND ";
                }
                else
                {
                    Content = beforefloating + ' ' + " SOUTH AFRICAN RAND " + ' ' + afterfloating + ' ' + " CENTS ";
                }
                //Content = beforefloating + ' ' + " SOUTH AFRICAN RAND " + ' ' + afterfloating + ' ' + " CENTS ";
            }
            return Content;
        }

        //public string conversion(string amount, string curr)
        //{
        //    double m = Convert.ToInt64(Math.Floor(Convert.ToDouble(amount)));
        //    double l = Convert.ToDouble(amount);

        //    double j = (l - m) * 100;
        //    string Content = "";
        //    if (curr == "INR")
        //    {
        //        var beforefloating = ConvertNumbertoWordsINR(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsINR(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " INDIAN RUPEES" + ' ' + afterfloating + ' ' + " PAISE ";
        //    }
        //    else if (curr == "USD")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " US DOLLARS " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "AED")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " UAE DIRHAM " + ' ' + afterfloating + ' ' + " FILS ";
        //    }
        //    else if (curr == "AUD")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " AUSTRALIAN DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "CAD")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " CANADIAN DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "CHF")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " SWISS FRANC " + ' ' + afterfloating + ' ' + " RAPPEN ";
        //    }
        //    else if (curr == "CNY")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " CHINESE YUAN RENMINBI " + ' ' + afterfloating + ' ' + " JIAO (FEN) ";
        //    }
        //    else if (curr == "DKK")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " DANISH KRONE " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "ETB")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " ETHIOPIAN BIRR " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "EUR")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " EURO " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "GBP")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " POUNDS " + ' ' + afterfloating + ' ' + " PENCE ";
        //    }
        //    else if (curr == "HKD")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " 	HONG KONG DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "JPY")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " 	JAPANESE YEN " + ' ' + afterfloating + ' ' + " SEN ";
        //    }
        //    else if (curr == "NZD")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " 	NEW ZEALAND DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "SEK")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " 	SWEDISH KRONA " + ' ' + afterfloating + ' ' + " ORE ";
        //    }
        //    else if (curr == "SGD")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " SINGAPORE DOLLAR " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    else if (curr == "ZAR")
        //    {
        //        var beforefloating = ConvertNumbertoWordsUSD(Convert.ToInt64(m));
        //        var afterfloating = ConvertNumbertoWordsUSD(Convert.ToInt64(j));
        //        Content = beforefloating + ' ' + " SOUTH AFRICAN RAND " + ' ' + afterfloating + ' ' + " CENTS ";
        //    }
        //    return Content;
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