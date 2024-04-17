using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace logix
{
    public class Calendar
    {
        public string Script = "";

        public Calendar()
        {

        }

        public Calendar(Page p, TextBox CalendarBox, Image img)
        {
            img.Attributes.Add("OnClick", "return CreateCalendar('" + CalendarBox.ID + "')");
            img.Style.Add("cursor", "hand");
            CalendarBox.Text = ConvertDate(DateTime.Now.ToShortDateString().Trim());
            //CalendarBox.Attributes.Add("OnKeyDown", "return false");
            p.Form.Attributes.Add("OnClick", "HideCal()");
        }

        public string ConvertDate(string strSource)
        {
            string strTemp = "";
            string[] datSrc = strSource.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            strTemp = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return strTemp;
        }

        public int Month(DropDownList month)
        {
            int intResult = 0;
            switch (month.Text)
            {
                case "JANUARY":
                    intResult = 1;
                    break;
                case "FEBRUARY":
                    intResult = 2;
                    break;
                case "MARCH":
                    intResult = 3;
                    break;
                case "ARIL":
                    intResult = 4;
                    break;
                case "MAY":
                    intResult = 5;
                    break;
                case "JUNE":
                    intResult = 6;
                    break;
                case "JULY":
                    intResult = 7;
                    break;
                case "AUGUST":
                    intResult = 8;
                    break;
                case "SEPTEMBER":
                    intResult = 9;
                    break;
                case "OCTOBER":
                    intResult = 10;
                    break;
                case "NOVEMBER":
                    intResult = 11;
                    break;
                case "DECEMBER":
                    intResult = 12;
                    break;
            }
            return intResult;
        }

    }
}