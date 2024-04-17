using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class RemittanceReceiptAnnexureFA : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.LogDetails ObjLog = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        int ReceiptId, bid, vouyear, customerid, page_, row_count, supplyto;
        string Mode = "", Type="";
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
                            lbl_head.Text = "Remittance Receipt - Bank - Annexure - Voucher Break Up Details";
                        }
                        else if (Mode == "C")
                        {
                            lbl_head.Text = "Remittance Cash Receipt - Annexure - Voucher Break Up Details";
                        }
                        else if (Mode == "P")
                        {
                            lbl_head.Text = "Remittance Petty Cash Receipt - Annexure - Voucher Break Up Details";
                        }
                        lblrecPayno.Text = "Receipt # & Date";
                    }
                    else if (Type == "P")
                    {
                        if (Mode == "B")
                        {
                            lbl_head.Text = "Remittance Payment - Bank - Annexure - Voucher Break Up Details";
                        }
                        else if (Mode == "C")
                        {
                            lbl_head.Text = "Remittance Cash Payment - Annexure - Voucher Break Up Details";
                        }
                        else if (Mode == "P")
                        {
                            lbl_head.Text = "Remittance Petty Cash Payment - Annexure - Voucher Break Up Details";
                        }
                        lblrecPayno.Text = "Payment # & Date";
                    }
                    DataSet DS = objRpt.GetRemittanceReceiptRptByRecId(ReceiptId, Type);
                    if (DS.Tables.Count > 0)
                    {
                        DataTable DtOSRecHead = DS.Tables[0];
                        DataTable DtOSCustDtls = DS.Tables[1];
                        DataTable DtOSRecPaymentDtls = DS.Tables[2];
                        DataTable DtOSRecChargeDtls = DS.Tables[3];
                        DataTable DtTot = DS.Tables[4];
                        if (DtOSRecHead.Rows.Count > 0)
                        {
                            lblDivName.Text = DtOSRecHead.Rows[0]["Divisionname"].ToString();
                            lblAddress.Text = DtOSRecHead.Rows[0]["Address"].ToString();
                            lblphonefax.Text = "Ph" + DtOSRecHead.Rows[0]["phone"].ToString() + "/ Fax " + DtOSRecHead.Rows[0]["fax"].ToString();
                            lblRecno.Text = DtOSRecHead.Rows[0]["Receiptno"].ToString() + " & " + DtOSRecHead.Rows[0]["ReceiptDate"].ToString();
                            lblRecId.Text = DtOSRecHead.Rows[0]["Receiptid"].ToString();
                        }

                        if (DtOSRecPaymentDtls.Rows.Count > 0)
                        {
                            //lblfctotamt.Text = Convert.ToDouble(DtOSRecPaymentDtls.Compute("sum(recptfcamt)", string.Empty)).ToString("#,0.00");
                            //lblINRtotal.Text = Convert.ToDouble(DtOSRecPaymentDtls.Compute("sum(Vamount)", string.Empty)).ToString("#,0.00");
                            for (int i = 0; i < DtOSRecPaymentDtls.Rows.Count; i++)
                            {
                                if (i <= 70)
                                {
                                    double FCAmt, ExRate, VAmount;
                                    lblPaymentDtls.Text += "<tr>";
                                    lblPaymentDtls.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;'>" + DtOSRecPaymentDtls.Rows[i]["BranchShort"] + "</td>";
                                    lblPaymentDtls.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;'>" + DtOSRecPaymentDtls.Rows[i]["vounumbers"] + "</td>";
                                    lblPaymentDtls.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;white-space:nowrap;'>" + DtOSRecPaymentDtls.Rows[i]["vendorrefno"] + "</td>";

                                    lblPaymentDtls.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;'>" + DtOSRecPaymentDtls.Rows[i]["Voudate"] + "</td>";
                                    lblPaymentDtls.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;'>" + DtOSRecPaymentDtls.Rows[i]["receiptfcurr"] + "</td>";
                                    lblPaymentDtls.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtOSRecPaymentDtls.Rows[i]["recptfcamt"]).ToString("#,0.00") + "</td>";
                                    lblPaymentDtls.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtOSRecPaymentDtls.Rows[i]["receiptexrate"]).ToString("#,0.00") + "</td>";
                                    lblPaymentDtls.Text += "<td style='border-right:0px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right;'>" + Convert.ToDouble(DtOSRecPaymentDtls.Rows[i]["Vamount"]).ToString("#,0.00") + "</td>";
                                    lblPaymentDtls.Text += "</tr>";
                                }
                                else
                                {
                                    lblPaymentDtls1.Text += "<tr>";
                                    lblPaymentDtls1.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;'>" + DtOSRecPaymentDtls.Rows[i]["BranchShort"] + "</td>";
                                    lblPaymentDtls1.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;'>" + DtOSRecPaymentDtls.Rows[i]["vounumbers"] + "</td>";
                                    lblPaymentDtls1.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;white-space:nowrap;'>" + DtOSRecPaymentDtls.Rows[i]["vendorrefno"] + "</td>";

                                    lblPaymentDtls1.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;'>" + DtOSRecPaymentDtls.Rows[i]["Voudate"] + "</td>";
                                    lblPaymentDtls1.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:left; border-right:1px solid #000;'>" + DtOSRecPaymentDtls.Rows[i]["receiptfcurr"] + "</td>";
                                    lblPaymentDtls1.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtOSRecPaymentDtls.Rows[i]["recptfcamt"]).ToString("#,0.00") + "</td>";
                                    lblPaymentDtls1.Text += "<td style='border-right:1px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right; border-right:1px solid #000;'>" + Convert.ToDouble(DtOSRecPaymentDtls.Rows[i]["receiptexrate"]).ToString("#,0.00") + "</td>";
                                    lblPaymentDtls1.Text += "<td style='border-right:0px solid #000; padding:0px 2px 0px 2px; margin:0px 2px 0px 2px; text-align:right;'>" + Convert.ToDouble(DtOSRecPaymentDtls.Rows[i]["Vamount"]).ToString("#,0.00") + "</td>";
                                    lblPaymentDtls1.Text += "</tr>";
                                }
                            }
                        }

                        if (DtTot.Rows.Count > 0)
                        {
                            if (DtOSRecPaymentDtls.Rows.Count > 0)
                            {
                                if (DtOSRecPaymentDtls.Rows.Count <= 70)
                                {
                                    //lblfctotamt.Text = Convert.ToDouble(DtOSRecPaymentDtls.Compute("sum(recptfcamt)", string.Empty)).ToString("#,0.00");
                                    //lblINRtotal.Text = Convert.ToDouble(DtOSRecPaymentDtls.Compute("sum(Vamount)", string.Empty)).ToString("#,0.00");
                                    lblfctotamt.Text = Convert.ToDouble(DtTot.Rows[0]["RecptfcamtTot"]).ToString("#,0.00");
                                    lblINRtotal.Text = Convert.ToDouble(DtTot.Rows[0]["RecPayTotAmt"]).ToString("#,0.00");
                                    Div2.Visible = false;
                                    Div1.Attributes["class"] = "Div1";
                                }
                                else
                                {
                                    lblfctotamt1.Text = Convert.ToDouble(DtTot.Rows[0]["RecptfcamtTot"]).ToString("#,0.00");
                                    lblINRtotal1.Text = Convert.ToDouble(DtTot.Rows[0]["RecPayTotAmt"]).ToString("#,0.00");

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString().Replace("'", "");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('" + message + "')", true);
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