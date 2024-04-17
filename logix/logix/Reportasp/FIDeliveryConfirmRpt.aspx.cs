using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class FIDeliveryConfirmRpt : System.Web.UI.Page
    {
        int bid;
        string blno;
        DataAccess.Reportasp Selcustomedi = new DataAccess.Reportasp();
        DataTable dtcust = new DataTable();
        DataAccess.Masters.MasterEmployee obj_da_employee = new DataAccess.Masters.MasterEmployee();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Selcustomedi.GetDataBase(Ccode);
                obj_da_employee.GetDataBase(Ccode);


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.Page), "Master", "alertify.alert('Session TimeOut');window.open('http://CHawk.copperhawk.tech'_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("blno"))
                {
                    bid = Convert.ToInt32(Request.QueryString["bid"]);
                    blno = Request.QueryString["blno"];
                }
                dtcust = Selcustomedi.Seldlconfirmrpt(blno, Convert.ToInt32(bid));
               
                if(dtcust.Rows.Count > 0)
                {
                    lbl_branch.Text = dtcust.Rows[0]["branchname"].ToString();
                    lbl_add.Text = dtcust.Rows[0]["address"].ToString();
                    lbl_ph.Text = dtcust.Rows[0]["phone"].ToString();
                    lbl_staxhead.Text = dtcust.Rows[0]["stno"].ToString();
                    lbl_panno.Text = dtcust.Rows[0]["panno"].ToString();
                    Label_fax.Text = dtcust.Rows[0]["fax"].ToString();
                    lbl_mail.Text = dtcust.Rows[0]["email"].ToString();
                    lbl_tocusname.Text = dtcust.Rows[0]["customername"].ToString();
                    lbl_toadd.Text += dtcust.Rows[0]["MCaddress"].ToString();
                    lbl_toadd.Text += " "+dtcust.Rows[0]["PAportname"].ToString()+" ";
                    lbl_toadd.Text += dtcust.Rows[0]["zip"].ToString();
                    lbl_ourdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lbl_ourdear.Text = dtcust.Rows[0]["ptc"].ToString();
                    lbl_ourlod.Text = dtcust.Rows[0]["MPportname"].ToString();
                    lbl_ourdischarge.Text = dtcust.Rows[0]["PDportname"].ToString();
                    lbl_arriveddate.Text = Convert.ToDateTime(dtcust.Rows[0]["eta"]).ToString("dd/MMM/yyyy");
                    lbl_ourcontain.Text = dtcust.Rows[0]["blno"].ToString();
                    lbl_bldate.Text = Convert.ToDateTime(dtcust.Rows[0]["bldate"]).ToString("dd/MMM/yyyy");
                    lbl_mbl.Text = dtcust.Rows[0]["mblno"].ToString();
                    lbl_shp.Text = dtcust.Rows[0]["shipper"].ToString();
                    lbl_con.Text = dtcust.Rows[0]["consignee"].ToString();
                    lbl_ourmbl.Text = DateTime.Now.ToString("dd/MMM/yyyy");

                }
                lbl_user.Text=obj_da_employee.GetEmployeeName(obj_da_employee.GetEmpid(Session["LoginUserName"].ToString()));
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "   ", "alertify.alert('" + message + "');", true);
            }

        }
    }
}