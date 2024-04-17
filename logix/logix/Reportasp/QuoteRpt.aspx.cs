using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class QuoteRpt : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.LogDetails ObjLog = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();

        int Quoteno, bid, cid, customerid, page_, row_count, supplyto;
        string Mode = "", TranType = "";

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
                if (Request.QueryString.ToString().Contains("Quoteno"))
                {
                    Quoteno = Convert.ToInt32(Request.QueryString["Quoteno"]);
                    bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    cid = Convert.ToInt32(Request.QueryString["Cid"]);
                    TranType = Request.QueryString["TranType"];
                    DataSet DS = objRpt.GetQuoteandBookDtls4Rpt(Quoteno, bid, cid, "Q", TranType);
                    if (DS.Tables.Count > 1)
                    {
                        DataTable DtQuoteHead = DS.Tables[0];
                        DataTable DtQuoteDtls = DS.Tables[1];
                        if (DtQuoteHead.Rows.Count > 0)
                        {
                            lblDivName.Text = DtQuoteHead.Rows[0]["Divisionname"].ToString();
                            lblAddress.Text = DtQuoteHead.Rows[0]["Address"].ToString();
                            lblphonefax.Text = "Phone : " + DtQuoteHead.Rows[0]["phone"].ToString() + "; Fax : " + DtQuoteHead.Rows[0]["fax"].ToString() + "; EMail : " + DtQuoteHead.Rows[0]["email"].ToString();
                            lblshipper.Text = DtQuoteHead.Rows[0]["Customer"].ToString();
                            lblshipaddress.Text = DtQuoteHead.Rows[0]["CustomerAddress"].ToString();
                            lblQuoteno.Text = DtQuoteHead.Rows[0]["quotno"].ToString();
                            lblQuoteDate.Text = DtQuoteHead.Rows[0]["quotDate"].ToString();
                            lblValidTill.Text = DtQuoteHead.Rows[0]["ValidTill"].ToString();
                            lblPOL.Text = DtQuoteHead.Rows[0]["pol"].ToString();
                            lblFD.Text = DtQuoteHead.Rows[0]["pod"].ToString();
                            lblCargo.Text = DtQuoteHead.Rows[0]["Cargo"].ToString();
                            lblCargoDesc.Text = DtQuoteHead.Rows[0]["Cargodesc"].ToString();
                            lblShipment.Text = DtQuoteHead.Rows[0]["Shipment"].ToString();
                            lblfreight.Text = DtQuoteHead.Rows[0]["Freight"].ToString();
                            lblRemarks.Text = DtQuoteHead.Rows[0]["remarks"].ToString();
                            lblMarketedBy.Text = DtQuoteHead.Rows[0]["marketedby"].ToString();
                        }
                        if (DtQuoteDtls.Rows.Count > 0)
                        {
                            for (int i = 0; i < DtQuoteDtls.Rows.Count; i++)
                            {
                                tdRow_QuotDtls.Text += "<tr>";
                                tdRow_QuotDtls.Text += "<td style='border-right:1px solid #000; padding:5px 5px 5px 10px; margin:5px; text-align:left; border-right:1px solid #000;'>" + DtQuoteDtls.Rows[i]["Charges"] + "</td>";
                                tdRow_QuotDtls.Text += "<td style='border-right:1px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:center; border-right:1px solid #000;'>" + DtQuoteDtls.Rows[i]["curr"] + "</td>";
                                tdRow_QuotDtls.Text += "<td style='border-right:1px solid #000; padding:5px 25px 5px 5px; margin:5px; text-align:right; border-right:1px solid #000; width:200px;'>" + Convert.ToDouble(DtQuoteDtls.Rows[i]["Rate"]).ToString("#,0.00") + "</td>";
                                tdRow_QuotDtls.Text += "<td style='border-right:0px solid #000; padding:5px 5px 5px 5px; margin:5px; text-align:center;'>" + DtQuoteDtls.Rows[i]["Base"] + "</td>";
                                tdRow_QuotDtls.Text += "</tr>";
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