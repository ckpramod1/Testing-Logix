using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace logix
{
    public partial class PODetailsBooking : System.Web.UI.Page
    {
        public DataTable dt, dt4ship, dt4po = new DataTable();
        public static int intbookno;
        public CustomerDataAccess.AgentXML objXML = new CustomerDataAccess.AgentXML();
        public string vbCrLf = "\n";
        DataTable dtget = new DataTable();
        DataTable dtweb = new DataTable();
        public int intwebid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
                MultiView1.ActiveViewIndex = 0;
        }
        protected void lnkBook_Click(object sender, EventArgs e)
        {
            txtBookingNo.Text = "";
            txtPONo.Text = "";
            txtCust.Text = "";
            btnGenXML.Enabled = false;

            MultiView1.ActiveViewIndex = 1;
            dtweb = objXML.GetWebid(Session["username"].ToString());
            if (dtweb.Rows.Count > 0)
            {
                intwebid = int.Parse(dtweb.Rows[0]["webgroupid"].ToString());
            }

            dt = objXML.Getbooking4PO(intwebid);
            if (dt.Rows.Count > 0)
            {
                grdBooking.DataSource = dt;
                grdBooking.DataBind();
            }
            else
            {

                ScriptManager.RegisterStartupScript(lnkBook, typeof(LinkButton), "", "alertify.alert('No Data Found');", true);
                MultiView1.ActiveViewIndex = 0;
            }
        }


        protected void grdBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookingNo.Text = grdBooking.SelectedRow.Cells[0].Text;
            txtCust.Text = grdBooking.SelectedRow.Cells[2].Text;
            intbookno = int.Parse(grdBooking.SelectedDataKey["bokno"].ToString());
            MultiView1.ActiveViewIndex = 0;
            dt = objXML.GetOEPoDetailsBook(txtBookingNo.Text);
            if (dt.Rows.Count > 0)
            {
                grdBoohDtls.DataSource = dt;
                grdBoohDtls.DataBind();
                txtPONo.Text = grdBoohDtls.Rows[0].Cells[1].Text;
            }

            btnGenXML.Enabled = true;


        }
        protected void grdBooking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.cursor='hand'");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdBooking, "Select$" + e.Row.RowIndex);
            }
            try
            {
                grdBooking.Rows[e.Row.RowIndex - 1].Cells[5].Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
        protected void grdBoohDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.cursor='hand'");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdBoohDtls, "Select$" + e.Row.RowIndex);
            }
        }
        protected void grdBoohDtls_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnGenXML.Enabled = true;
            txtPONo.Text = grdBoohDtls.SelectedRow.Cells[1].Text;
        }
        protected void btnGenXML_Click(object sender, EventArgs e)
        {

            dt4ship = objXML.GetShiprefno4XML(intbookno, txtBookingNo.Text, 1, 1);
            dt4po = objXML.GetPo4XML(intbookno.ToString(), 1, 1);

            if (dt4po.Rows.Count > 0)
            {
                string strTmp;
                double tot = 0;
                int x;
                strTmp = "";
                strTmp = "<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + " ?>";
                strTmp += vbCrLf + "<PoBooking>";
                strTmp += vbCrLf + "<Booking>";
                strTmp += vbCrLf + "<Shipper>" + txtCust.Text + "</Shipper>";
                strTmp += vbCrLf + "<brefno>" + dt4ship.Rows[0]["shiprefno"].ToString() + "</brefno>";
                strTmp += vbCrLf + "<volume>" + dt4ship.Rows[0]["volume"].ToString() + "</volume>";
                for (int index = 0; index <= dt4po.Rows.Count - 1; index++)
                {
                    tot = tot + double.Parse(dt4po.Rows[index]["weight"].ToString());
                }
                strTmp += vbCrLf + "<totwt>" + tot + "</totwt>";
                strTmp += vbCrLf + "<dypoint>" + dt4po.Rows[0]["dvrypint"].ToString() + "</dypoint>";
                strTmp += vbCrLf + "<dydate>" + dt4po.Rows[0]["dvrydt"].ToString() + "</dydate>";   //Shipped On Date'
                for (x = 0; x <= dt4po.Rows.Count - 1; x++)
                {
                    string pono;
                    pono = dt4po.Rows[x]["Pono"].ToString();
                    strTmp += vbCrLf + "<PoDetails>";
                    strTmp += vbCrLf + "<pono>" + dt4po.Rows[x]["pono"].ToString() + "</pono>";
                    strTmp += vbCrLf + "<invno>" + dt4po.Rows[x]["invoiceno"].ToString() + "</invno>";
                    strTmp += vbCrLf + "<skuno>" + dt4po.Rows[x]["styleno"].ToString() + "</skuno>";
                    strTmp += vbCrLf + "<skudesc>" + dt4po.Rows[x]["dimensions"].ToString() + "</skudesc>";
                    strTmp += vbCrLf + "<qty>" + dt4po.Rows[x]["pieces"].ToString() + "</qty>";
                    strTmp += vbCrLf + "<wt>" + dt4po.Rows[x]["Weight"].ToString() + "</wt>";
                    strTmp += vbCrLf + "<remarks>" + dt4po.Rows[x]["remarks"].ToString() + "</remarks>";
                    //strTmp += "<pkgs>" + dt4po.Rows[x]["cartons"].ToString() + "</pkgs>";
                    //dtcont = FEPOobj.GetContr4XML(intbookno, pono, Login.branchid, Login.divisionid)
                    strTmp += vbCrLf + "</PoDetails>";
                }

                strTmp += vbCrLf + "</Booking>";
                strTmp += vbCrLf + "</PoBooking>";
                strTmp = strTmp.Replace("&", "&amp;");

                objXML.insbookingdownload(intbookno, "Y", "", "B");

                ConvertToExCel.SetData(strTmp, "PODetail(s)forBooking.xml", ConvertToExCel.ConversionType.XML);
                Response.Redirect("ToExcel.aspx?pmtr=String");
                //TW.Write(strTmp);
                //TW.Close();
            }
            //MsgBox("Successfully exported into " & strFile)
        }

        protected void txtBookingNo_TextChanged(object sender, EventArgs e)
        {
            //txtBookingNo.Text = BookingNo.Value;
            dt = objXML.Getbooking4POBookNo(txtBookingNo.TextValue);
            if (dt.Rows.Count > 0)
            {
                grdBooking.DataSource = dt;
                grdBooking.DataBind();
                txtCust.Text = grdBooking.Rows[0].Cells[2].Text;
                intbookno = int.Parse(grdBooking.Rows[0].Cells[6].Text);
            }

            MultiView1.ActiveViewIndex = 0;
            dt = objXML.GetOEPoDetailsBook(txtBookingNo.Text);
            if (dt.Rows.Count > 0)
            {
                grdBoohDtls.DataSource = dt;
                grdBoohDtls.DataBind();
                btnGenXML.Enabled = true;
                txtPONo.Text = grdBoohDtls.Rows[0].Cells[1].Text;

            }

            dtget = objXML.Getbook4mDownload(intbookno);
            if (dtget.Rows.Count > 0)
            {
                if (Convert.IsDBNull(dtget.Rows[0]["booking"]))
                {

                }
                else
                {
                    btnGenXML.Enabled = false;
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPONo.Text = "";
            if (btnGenXML.Enabled == true)
            {
                btnGenXML.Enabled = false;
            }
            txtCust.Text = "";
            txtBookingNo.Text = "";
            grdBoohDtls.DataSource = null;
            grdBoohDtls.DataBind();
        }
   
    }
}