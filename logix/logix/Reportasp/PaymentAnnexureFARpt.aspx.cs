using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace logix.Reportasp
{
    public partial class PaymentAnnexureFARpt : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.LogDetails ObjLog = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();

        int ReceiptId, bid, vouyear, customerid, page_, row_count, supplyto;
        string Mode = "", Type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                custobj.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                ObjLog.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            try
            {


                //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                }
                   
                     
                lblToday.Text = ObjLog.GetDate().ToString("dd/MM/yyyy");
                if (Request.QueryString.ToString().Contains("ReceiptId"))
                {
                    ReceiptId = Convert.ToInt32(Request.QueryString["ReceiptId"]);
                    vouyear = Convert.ToInt32(Request.QueryString["Vouyear"]);
                    Mode = Request.QueryString["Mode"];
                    Type = Request.QueryString["Type"];
                    if (Type == "R")
                    {
                        if (Mode == "B")
                        {
                            lbl_head.Text = "Bank Receipt Annexure - Voucher Break Up Details";
                        }
                        else if (Mode == "C")
                        {
                            lbl_head.Text = "Cash Receipt Annexure - Voucher Break Up Details";
                        }
                        else if (Mode == "P")
                        {
                            lbl_head.Text = "Petty Cash Receipt Annexure - Voucher Break Up Details";
                        }
                        lbl_RecPayDate.Text = "Receipt # & Date";
                    }
                    else if (Type == "P")
                    {
                        if (Mode == "B")
                        {
                            lbl_head.Text = "Bank Payment Annexure - Voucher Break Up Details";
                        }
                        else if (Mode == "C")
                        {
                            lbl_head.Text = "Cash Payment Annexure - Voucher Break Up Details";
                        }
                        else if (Mode == "P")
                        {
                            lbl_head.Text = "Petty Cash Payment Annexure - Voucher Break Up Details";
                        }
                        lbl_RecPayDate.Text = "Payment # & Date";
                    }
                    DataSet DS = objRpt.GetReceiptRptByRecId(ReceiptId, Type);
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
                            lblRecPayno.Text = DtRecHead.Rows[0]["Receiptno"].ToString() + " & " + DtRecHead.Rows[0]["ReceiptDate"].ToString();

                            lblRecId.Text = DtRecHead.Rows[0]["Receiptid"].ToString();

                        }
                        if (DtRecPaymentDtls.Rows.Count > 0)
                        {
                            //lbrecpayltotal.Text = Convert.ToDouble(DtRecPaymentDtls.Compute("sum(vamount)", string.Empty)).ToString("#,0.00");
                            for (int i = 0; i < DtRecPaymentDtls.Rows.Count; i++)
                            {
                                string TDSAmt = Convert.ToDouble(DtRecPaymentDtls.Rows[i]["TDSAmt"]) == 0 ? "N/A" : Convert.ToDouble(DtRecPaymentDtls.Rows[i]["TDSAmt"]).ToString("#,0.00");
                                //if (i <= 50)
                                //{
                                    tr_row.Text += "  <tr>";
                                    tr_row.Text += " <td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000;'>" + DtRecPaymentDtls.Rows[i]["Branchshort"].ToString() + "</td>";
                                    tr_row.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000;'>" + DtRecPaymentDtls.Rows[i]["jobno"].ToString() + "</td>";
                                    tr_row.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000;'>" + DtRecPaymentDtls.Rows[i]["vounumbers"].ToString() + "</td>";
                                    tr_row.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000; white-space:nowrap;'>" + DtRecPaymentDtls.Rows[i]["vendorrefno"].ToString() + "</td>";
                                    tr_row.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000;'>" + DtRecPaymentDtls.Rows[i]["VouDate"].ToString() + "</td>";
                                    tr_row.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtRecPaymentDtls.Rows[i]["GrossAmt"]).ToString("#,0.00") + "</td>";
                                    tr_row.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:right; border-right:1px solid #000;'>" + TDSAmt.ToString() + "</td>";
                                    tr_row.Text += " <td style='border-right:0px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:right; '>" + Convert.ToDouble(DtRecPaymentDtls.Rows[i]["vamount"]).ToString("#,0.00") + "</td></tr>";
                                //}
                               // else
                                //{
                                //    tr_row1.Text += "  <tr>";
                                //    tr_row1.Text += " <td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000;'>" + DtRecPaymentDtls.Rows[i]["Branchshort"].ToString() + "</td>";
                                //    tr_row1.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000;'>" + DtRecPaymentDtls.Rows[i]["vounumbers"].ToString() + "</td>";
                                //    tr_row1.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000; white-space:nowrap;'>" + DtRecPaymentDtls.Rows[i]["vendorrefno"].ToString() + "</td>";
                                //    tr_row1.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:left; border-right:1px solid #000;'>" + DtRecPaymentDtls.Rows[i]["VouDate"].ToString() + "</td>";
                                //    tr_row1.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtRecPaymentDtls.Rows[i]["GrossAmt"]).ToString("#,0.00") + "</td>";
                                //    tr_row1.Text += "<td style='border-right:1px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:right; border-right:1px solid #000;'>" + TDSAmt.ToString() + "</td>";
                                //    tr_row1.Text += " <td style='border-right:0px solid #000; padding:2px 5px 2px 5px; margin:2px; text-align:right; '>" + Convert.ToDouble(DtRecPaymentDtls.Rows[i]["vamount"]).ToString("#,0.00") + "</td></tr>";
                                ////}
                            }
                            if (DtTot.Rows.Count > 0)
                            {
                                if (DtRecPaymentDtls.Rows.Count > 0)
                                {
                                    ////if (DtRecPaymentDtls.Rows.Count <= 50)
                                    ////{
                                    ////    lblGrossTotAmt.Text = Convert.ToDouble(DtTot.Rows[0]["PayGrossToAmt"]).ToString("#,0.00");
                                    ////    lblTDSTotAmt.Text = Convert.ToDouble(DtTot.Rows[0]["PayTDSTotAmt"]).ToString("#,0.00");
                                    ////    lbrecpayltotal.Text = Convert.ToDouble(DtTot.Rows[0]["RecPayTotAmt"]).ToString("#,0.00");
                                    ////    Div2.Visible = false;
                                    ////    Div1.Attributes["class"] = "Div1";
                                    ////    lblGrossTotAmt.Visible = true;
                                    ////    lblTDSTotAmt.Visible = true;
                                    ////    lbrecpayltotal.Visible = true;
                                    ////}
                                    ////else
                                    ////{
                                       // lblGrossTotAmt1.Text = Convert.ToDouble(DtTot.Rows[0]["PayGrossToAmt"]).ToString("#,0.00");
                                        //lblTDSTotAmt1.Text = Convert.ToDouble(DtTot.Rows[0]["PayTDSTotAmt"]).ToString("#,0.00");
                                        //lbrecpayltotal1.Text = Convert.ToDouble(DtTot.Rows[0]["RecPayTotAmt"]).ToString("#,0.00");
                                    //}


                                        lblGrossTotAmt.Text = Convert.ToDouble(DtTot.Rows[0]["PayGrossToAmt"]).ToString("#,0.00");
                                      lblTDSTotAmt.Text = Convert.ToDouble(DtTot.Rows[0]["PayTDSTotAmt"]).ToString("#,0.00");
                                       lbrecpayltotal.Text = Convert.ToDouble(DtTot.Rows[0]["RecPayTotAmt"]).ToString("#,0.00");
                                      
                                }
                            }
                        }
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