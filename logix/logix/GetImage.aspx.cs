using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace logix
{
    public partial class GetImage : System.Web.UI.Page
    {
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

           
            //string query = "SELECT touchclogo FROM masterbranch WHERE branchid = @ProductID";

            //SqlConnection con = new SqlConnection(constr);
            //SqlCommand com = new SqlCommand(query, con);

            //com.Parameters.Add("@ProductID", SqlDbType.Int).Value = Int32.Parse(id);

            //con.Open();
            //SqlDataReader r = com.ExecuteReader();

            //if (r.Read())
            //{
            //    if (!string.IsNullOrEmpty(r["touchclogo"].ToString()))
            //    {
            //        byte[] imgData = (byte[])r["touchclogo"];
            //        Response.BinaryWrite(imgData);
            //    }
            //}
            //con.Close(); 

            byte[] str = da_obj_Logobj.GetloginBranchUSERID(Convert.ToInt32(id));
            if (!string.IsNullOrEmpty(str[0].ToString()))
            {
                byte[] imgData = (byte[])(str);
                Response.BinaryWrite(imgData);
            }
        }
    }
}