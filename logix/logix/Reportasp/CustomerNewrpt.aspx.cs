using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class CustomerNewrpt : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer objnew = new DataAccess.Masters.MasterCustomer();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objnew.GetDataBase(Ccode);

            }

            string panno = Request.QueryString["panno"];
            string pancustomer = Request.QueryString["pancustomer"];
            string Gst = Request.QueryString["Gst"];
            DataTable dt = new DataTable();
            dt = objnew.customergetdetails(panno,pancustomer,Gst);
            if(dt.Rows.Count>0)
            {
                LblRender.Text = dt.Rows[0]["customername"].ToString();
                lblpan.Text = dt.Rows[0]["panno"].ToString();
                string type= dt.Rows[0]["customertype"].ToString();
                if(type=="C")
                {
                    lbltype.Text = "Customer";
                }
                else
                {
                    lbltype.Text = "Agent";
                }
                lbltan.Text=dt.Rows[0]["tanno"].ToString();
                lblcin.Text = dt.Rows[0]["cinno"].ToString();
                lbluin.Text = dt.Rows[0]["uinno"].ToString();
                lblGst.Text = dt.Rows[0]["gstin"].ToString();
                lbllocation.Text = dt.Rows[0]["Location"].ToString();
                lblpin.Text = dt.Rows[0]["zip"].ToString();
                lbldistrict.Text = dt.Rows[0]["DistrictName"].ToString();
                lblcategory.Text = dt.Rows[0]["category"].ToString();
                lblcity.Text = dt.Rows[0]["portname"].ToString();
               lblstate.Text =dt.Rows[0]["statename"].ToString();
               lblcout.Text = dt.Rows[0]["countryname"].ToString();

               lblgstno.Text = dt.Rows[0]["GSTCode"].ToString();

                lblbank.Text = dt.Rows[0]["bankname"].ToString();
                lblno.Text = dt.Rows[0]["Accountnumber"].ToString();
                lblifsc.Text = dt.Rows[0]["IFSCCode"].ToString();
                lblacctype.Text = dt.Rows[0]["Account"].ToString();
                lbltds.Text = dt.Rows[0]["tdsemp"].ToString();
                lblemail.Text = dt.Rows[0]["email"].ToString();
                lblfrom.Text = dt.Rows[0]["empperiodfrom"].ToString();
                lblto.Text = dt.Rows[0]["empperiodto"].ToString();

                lbltds.Text = dt.Rows[0]["tdsdesc"].ToString();
                lblsab.Text = dt.Rows[0]["tdsslab"].ToString();
                string typeee= dt.Rows[0]["tdstype"].ToString();
                if(typeee=="I")
                {
                    lbltypes.Text="Individual";
                }
                else if (typeee=="C")
                {
                    lbltypes.Text="Company";

                }
                else
                {
                    lbltypes.Text = "";
                }
                lblper.Text = dt.Rows[0]["tdspercentage"].ToString();

            }


        }
    }
}