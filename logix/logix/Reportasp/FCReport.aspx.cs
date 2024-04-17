using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class FCReport : System.Web.UI.Page
    {
        string inr, cur;
        double ex, amt, tcur, tamt;
        string blno;
        string trantype;
        int bid;
        int jobno;
        DataAccess.Accounts.OSDNCN objosdncn = new DataAccess.Accounts.OSDNCN();
        DataTable dtcust = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objosdncn.GetDataBase(Ccode);
          


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('http://CHawk.copperhawk.tech'_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("blno"))
                {
                    blno = Request.QueryString["blno"];
                    trantype = Request.QueryString["trantype"];
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    jobno = Convert.ToInt32(Request.QueryString["jobno"]);
                }

                if(trantype == "FI")
                {
                    lbl_tran.Text = "Vessel";
                }
                else
                {
                    lbl_tran.Text = "Flight No & Date";
                    lbl_vol.Visible = false;
                    lbl_line.Visible = false;
                    lbl_im.Visible = false;
                }

                dtcust = objosdncn.GetFCReport(blno.ToString(), trantype.ToString(), bid, jobno);
                if (dtcust.Rows.Count > 0)
                {
                    lblbranchname.Text = dtcust.Rows[0]["branchname"].ToString();
                    lbladdress.Text = dtcust.Rows[0]["address"].ToString();
                    lblphone.Text = dtcust.Rows[0]["phone"].ToString();
                    lblfax.Text = dtcust.Rows[0]["fax"].ToString();
                    lblservicetax.Text = dtcust.Rows[0]["stno"].ToString();
                    lblPan.Text = dtcust.Rows[0]["panno"].ToString();
                    lbljob.Text = dtcust.Rows[0]["jobno"].ToString();

                    if (trantype == "FI")
                    {
                        lblVessel.Text = dtcust.Rows[0]["vesselname"].ToString();
                        lblvoyage.Text = dtcust.Rows[0]["voyage"].ToString();
                        lblvolume.Text = dtcust.Rows[0]["ContainerInfo"].ToString();
                        lblline.Text = dtcust.Rows[0]["linenumber"].ToString();
                        lblim.Text = dtcust.Rows[0]["imno"].ToString();
                        lblgrweight.Text = Convert.ToDouble(dtcust.Rows[0]["grweight"]).ToString("N2");

                    }
                    else
                    {
                        lblVessel.Text = dtcust.Rows[0]["flightno"].ToString();
                        lblvoyage.Text = Convert.ToDateTime(dtcust.Rows[0]["flightdate"]).ToString("dd/MM/yyyy");
                        lblgrweight.Text = Convert.ToDouble(dtcust.Rows[0]["grosswt"]).ToString("N2");

                    }

                    //lbltrantype.Text = dtcust.Rows[0]["voyage"].ToString();
                    lblinvdate.Text = Convert.ToDateTime(dtcust.Rows[0]["voudate"]).ToString("dd/MM/yyyy");
                    lblcompanyname.Text = dtcust.Rows[0]["customername"].ToString();
                    lbladd.Text = dtcust.Rows[0]["mtaddress"].ToString();
                    lblzip.Text = dtcust.Rows[0]["mtzip"].ToString();
                    lblbl.Text = dtcust.Rows[0]["blno"].ToString();
                    lblpol.Text = dtcust.Rows[0]["portname"].ToString();
                    lblpackage.Text = dtcust.Rows[0]["noofpkgs"].ToString();
                    lbldesc.Text = dtcust.Rows[0]["descn"].ToString();
                    lblshipper.Text = dtcust.Rows[0]["shipper"].ToString();
                    lblConsignee.Text = dtcust.Rows[0]["consignee"].ToString();
                    for(int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        lblcharge.Text += " <tr style=''>";
                        lblcharge.Text += "<td><label>" + dtcust.Rows[i]["chargename"].ToString() + "</label></td>";
                        lblcharge.Text += "<td><label>" + dtcust.Rows[i]["curr"].ToString() + "</label></td>";
                        lblcharge.Text += "<td><label>" + Convert.ToDouble(dtcust.Rows[i]["rate"]).ToString("N2") + "</label></td>";
                        lblcharge.Text += "<td><label>" + dtcust.Rows[i]["base"].ToString() + "</label></td>";
                        lblcharge.Text += "<td><label>" + Convert.ToDouble(dtcust.Rows[i]["exrate"]).ToString("N2") + "</label></td>";
                        if (dtcust.Rows[i]["curr"].ToString() == "INR")
                        {
                            inr = Convert.ToDouble(dtcust.Rows[i]["amount"]).ToString("N2");
                            cur = " ";
                            tamt += Convert.ToDouble(inr);
                        }
                        else
                        {
                            ex = Convert.ToDouble(dtcust.Rows[i]["exrate"]);
                            amt = Convert.ToDouble(dtcust.Rows[i]["amount"]);
                            tcur = amt / ex;
                            cur = tcur.ToString("N2");
                            inr = Convert.ToDouble(dtcust.Rows[i]["amount"]).ToString("N2");
                            tamt += Convert.ToDouble(inr);
                        }
                        lblcharge.Text += "<td><label>" + cur + "</label></td>";
                        lblcharge.Text += "<td><label>" + inr + "</label></td></tr>";
                    }
                    lblcomname.Text = dtcust.Rows[0]["branchname"].ToString();
                    lblTotal.Text = tamt.ToString("N2");
                    lbl_rsword.Text = "RUPEES" + " " + conversion(tamt.ToString(),"INR") + " ONLY";
                    //string query = "SELECT SUM(CASE WHEN curr = 'INR' THEN amount ELSE amount / exrate END) AS total_amount FROM your_table_name";
                    //SqlCommand command = new SqlCommand(query);
                    //object result = command.ExecuteScalar();
                    //double totalAmount = Convert.ToDouble(result);


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "   ", "alert('" + message + "');", true);
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
                Content = beforefloating + ' ' + "AND" + ' ' + afterfloating + ' ' + " PAISE ";   //INDIAN RUPEES
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