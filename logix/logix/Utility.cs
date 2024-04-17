using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.IO;


namespace logix.App_Code
{
    public class Utility
    {
        
        public static DateTime fn_ConvertDate(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return DateTime.Parse(str_OPDate);
        }

        public static string fn_ConvertDateTime(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return str_OPDate;
        }
        public static List<string> Fn_TableToList(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                lst_details.Add(dt.Rows[i][str_Textfield].ToString() + "~" + dt.Rows[i][str_Valuefield].ToString());
            }
            return lst_details;
        }
    
    }
}