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
    public partial class PODetailsContainer : System.Web.UI.Page
    {
        public CustomerDataAccess.PODetails objXML = new CustomerDataAccess.PODetails();
        public CustomerDataAccess.AgentXML objagentxml = new CustomerDataAccess.AgentXML();
        DataTable Dt = new DataTable();
        DataTable Dtpo = new DataTable();
        DataTable Dt1 = new DataTable();
        DataTable Dt2 = new DataTable();
        DataTable Dtcont = new DataTable();
        DataTable dtget = new DataTable();
        DataTable dtweb = new DataTable();
        public int intbookno, intwebid;
        public string strTempData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;

            }
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lnkbook_Click(object sender, EventArgs e)
        {
            //Dt = objXML.Getbooking4PO();
            dtweb = objagentxml.GetWebid(Session["username"].ToString());
            if (dtweb.Rows.Count > 0)
            {
                intwebid = int.Parse(dtweb.Rows[0]["webgroupid"].ToString());
            }
            MultiView1.ActiveViewIndex = 1;
            Dt = objXML.Getbooking4PO(intwebid);

            if (Dt.Rows.Count > 0)
            {
                grdBookno.DataSource = Dt;
                grdBookno.DataBind();
            }
            else
            {

                ScriptManager.RegisterStartupScript(lnkbook, typeof(LinkButton), "", "alertify.alert('No Data Found');", true);
                MultiView1.ActiveViewIndex = 0;
            }


        }
        protected void grdBookno_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.background='silver';this.style.cursor='hand'");
                e.Row.Attributes.Add("onMouseOut", "this.style.background='#ffffff'");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdBookno, "Select$" + e.Row.RowIndex);
            }
        }
        protected void grdBookno_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookNo.Text = grdBookno.SelectedRow.Cells[0].Text;
            txtcustomer.Text = grdBookno.SelectedRow.Cells[2].Text;
            intbookno = int.Parse(grdBookno.SelectedDataKey["bokno"].ToString());
            //txt = gdJobNo.SelectedRow.Cells[2].Text;
            //strVoyage = gdJobNo.SelectedRow.Cells[3].Text;

            Dtpo = objXML.Getcontno4mpono(txtBookNo.Text);
            if (Dtpo.Rows.Count > 0)
            {
                grdpo.DataSource = Dtpo;
                grdpo.DataBind();
                txtpoNo.Text = grdpo.Rows[0].Cells[1].Text;
                txtcontno.Text = grdpo.Rows[0].Cells[2].Text;

            }


            btnxml.Enabled = true;
            MultiView1.ActiveViewIndex = 0;

        }

        protected void grdpo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.background='silver';this.style.cursor='hand'");
                e.Row.Attributes.Add("onMouseOut", "this.style.background='#ffffff'");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdpo, "Select$" + e.Row.RowIndex);
            }
        }
        protected void grdpo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtpoNo.Text = grdpo.SelectedRow.Cells[1].Text;
            txtcontno.Text = grdpo.SelectedRow.Cells[2].Text;
            //btnxml.Enabled = true;

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtcustomer.Text = "";
            txtcontno.Text = "";
            txtBookNo.Text = "";
            txtpoNo.Text = "";
            grdpo.DataSource = null;
            grdpo.DataBind();
            if (btnxml.Enabled == true)
            {
                btnxml.Enabled = false;
            }
        }


        protected void CreateXml()
        {
            double tot;
            //int x;
            tot = 0;
            Dt = objXML.Getbooking4POS(txtBookNo.Text);
            intbookno = int.Parse(Dt.Rows[0]["bokno"].ToString());
            Dt2 = objXML.GetShiprefno4XML(intbookno, txtBookNo.Text);

            Dt1 = objXML.GetPo4XML(intbookno);
            if (Dt1.Rows.Count > 0)
            {
                strTempData = "";
                strTempData = "<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + " ?>";
                strTempData += "<PoBooking>";
                strTempData += "<Booking>";
                strTempData += "~" + "<Shipper>" + txtcustomer.Text + "</Shipper>";
                strTempData += "~" + "<brefno> " + Dt2.Rows[0]["shiprefno"].ToString() + "</brefno>";
                strTempData += "~" + "<Volume>" + Dt2.Rows[0]["volume"].ToString() + "</Volume>";

                for (int index = 0; index <= Dt1.Rows.Count - 1; index++)
                {
                    tot = tot + double.Parse(Dt1.Rows[index]["weight"].ToString());
                }

                strTempData += "~" + "<totwt>" + tot + "</totwt>";
                strTempData += "~" + "<dypoint>" + Dt1.Rows[0]["dvrypint"].ToString() + "</dypoint>";
                strTempData += "~" + "<dydate>" + Dt1.Rows[0]["dvrydt"].ToString() + "</dydate>";


                for (int r = 0; r < Dt1.Rows.Count; r++)
                {
                    string po;
                    int n;
                    po = Dt1.Rows[r]["pono"].ToString();
                    strTempData += "~" + "<PoDetails>";
                    strTempData += "~" + "<Pono>" + Dt1.Rows[r]["pono"].ToString() + "</Pono>";
                    strTempData += "~" + "<invno>" + Dt1.Rows[r]["invoiceno"].ToString() + "</invno>";
                    strTempData += "~" + "<skuno>" + Dt1.Rows[r]["styleno"].ToString() + "</skuno>";
                    strTempData += "~" + "<skudesc>" + Dt1.Rows[r]["dimensions"].ToString() + "</skudesc>";
                    strTempData += "~" + "<Qty>" + Dt1.Rows[r]["pieces"].ToString() + "</Qty>";
                    strTempData += "~" + "<wt>" + Dt1.Rows[r]["weight"].ToString() + "</wt>";
                    strTempData += "~" + "<remarks>" + Dt1.Rows[r]["remarks"].ToString() + "</remarks>";

                    //Dtcont = objXML.GetContr4XML(txtBookNo.Text, po);
                    //    if (Dtcont.Rows.Count> 0)
                    //    {
                    //        for (int c =0;c<Dtcont.Rows.Count;c++)
                    //        {
                    strTempData += "~" + "<pkgs>" + Dt1.Rows[r]["cartons"].ToString() + "</pkgs>";
                    strTempData += "~" + "<Contno>" + Dt1.Rows[r]["contno"].ToString() + "</Contno>";
                    //    }
                    //}
                    strTempData += "~" + "</PoDetails>";
                }

                strTempData += "~" + "</Booking>";
                strTempData += "~" + "</PoBooking>";
                strTempData = strTempData.Replace("&", "&amp;");
                objagentxml.insbookingdownload(intbookno, "", "Y", "");

                ConvertToExCel.SetData(strTempData, txtBookNo.Text + ".xml", ConvertToExCel.ConversionType.XML);
                Response.Redirect("ToExcel.aspx?pmtr=String");
                txtcustomer.Text = "";
                txtcontno.Text = "";
                txtBookNo.Text = "";
                txtpoNo.Text = "";
                grdpo.DataSource = null;
                grdpo.DataBind();
                if (btnxml.Enabled == true)
                {
                    btnxml.Enabled = false;
                }

            }
        }

        protected void btnxml_Click(object sender, EventArgs e)
        {
            CreateXml();
        }
        protected void txtBookNo_TextChanged(object sender, EventArgs e)
        {
            Dt = objXML.Getbooking4POS(txtBookNo.TextValue);

            if (Dt.Rows.Count > 0)
            {
                txtcustomer.Text = Dt.Rows[0]["customername"].ToString();
                intbookno = int.Parse(Dt.Rows[0]["bokno"].ToString());
            }

            Dtpo = objXML.Getcontno4mpono(txtBookNo.Text);
            if (Dtpo.Rows.Count > 0)
            {
                grdpo.DataSource = Dtpo;
                grdpo.DataBind();
                btnxml.Enabled = true;
                txtcontno.Text = grdpo.Rows[0].Cells[2].Text;
                txtpoNo.Text = grdpo.Rows[0].Cells[1].Text;
            }
            else
            {
                ScriptManager.RegisterStartupScript(txtBookNo, typeof(TextBox), "", "alertify.alert('Invalid Booking');", true);
            }
            dtget = objagentxml.Getbook4mDownload(intbookno);
            if (dtget.Rows.Count > 0)
            {
                //get = 
                if (Convert.IsDBNull(dtget.Rows[0]["container"]))
                {
                    btnxml.Enabled = true;
                }
                else
                {
                    btnxml.Enabled = false;
                }
            }
            MultiView1.ActiveViewIndex = 0;

        }
    }
}