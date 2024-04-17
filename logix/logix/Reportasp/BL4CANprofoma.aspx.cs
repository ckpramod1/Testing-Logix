using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace logix.Reportasp
{
    public partial class BL4CANprofoma : System.Web.UI.Page
    {
        int Bid, Cid , i;
        string Type = "", TOtype = "", contdtls="";
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtnew;
        DataTable dt2;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_rptasp.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            try
            {
                if (Request.QueryString.ToString().Contains("jobno"))
                {
                    //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    lbl_jobno.Text = Request.QueryString["jobno"].ToString();
                    Type = Request.QueryString["type"].ToString();
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["cid"]);
                    TOtype = Request.QueryString["TOtype"].ToString();
                    ds = da_obj_rptasp.GetCANRpt(Convert.ToInt32(lbl_jobno.Text), Bid, Cid, Type);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        dt1 = ds.Tables[1];
                        dt2 = ds.Tables[2];
                        if (dt.Rows.Count > 0)
                        {
                            dtnew = da_obj_rptasp.Getaddress4MR(Convert.ToInt32(lbl_jobno.Text), Bid, Cid, TOtype);
                            if (dtnew.Rows.Count > 0)
                            {
                                lbl_TO.Text = dtnew.Rows[0]["caddress"].ToString();
                            }
                            lbl_branch.Text = dt.Rows[0]["branchname"].ToString();
                            lbl_addre.Text = dt.Rows[0]["address"].ToString();
                            lblphfax.Text = "<strong>Phone # :</strong>" + dt.Rows[0]["phone"].ToString() + "   " + "<strong> Fax # :</strong>" + dt.Rows[0]["fax"].ToString();
                            lbl_IMandDT.Text = dt.Rows[0]["imno"].ToString();
                            lbl_line.Text = dt.Rows[0]["lineno"].ToString();
                            lbltaxpan.Text ="<strong>GST.# :</strong>" + dt.Rows[0]["gstin"].ToString() + "   " + "<strong>PAN # :</strong>" + dt.Rows[0]["panno"].ToString() + "   " + "<strong>CIN # :</strong>" + dt.Rows[0]["cinno"].ToString();
                            lbl_bldt.Text = dt.Rows[0]["bldate"].ToString();
                            lbl_blno.Text = dt.Rows[0]["blno"].ToString();
                            lbl_pod.Text = dt.Rows[0]["Pod"].ToString();
                            lbl_pol.Text = dt.Rows[0]["Pol"].ToString();
                            lblpod.Text = dt.Rows[0]["Pod"].ToString();
                            lbl_motvslvoy.Text = dt.Rows[0]["Mvessel"].ToString();
                            lbl_feedvslvoy.Text = dt.Rows[0]["Fvessel"].ToString();
                            lbl_descn.Text = dt.Rows[0]["descn"].ToString();
                            lbl_pkgs.Text = dt.Rows[0]["noofpkgs"].ToString() + " " + dt.Rows[0]["packDesc"].ToString();
                            double grwt = Convert.ToDouble(dt.Rows[0]["grweight"]);
                            lbl_grwt.Text = grwt.ToString("#,0.00") + " kgs";
                            lbl_status.Text = dt.Rows[0]["Shipmenttype"].ToString();
                            lbl_freight.Text = dt.Rows[0]["freight"].ToString();
                            lbl_candt.Text = dt.Rows[0]["candate"].ToString();
                            lbl_eta.Text = dt.Rows[0]["eta"].ToString();
                            lbleta.Text = dt.Rows[0]["eta"].ToString();
                        }

                        if (dt1.Rows.Count > 0)
                        {
                            for(i=0;i< dt1.Rows.Count;i++)
                            {
                                lbl_chargename.Text += dt1.Rows[i]["charges"].ToString() + "<br />";
                                lbl_curr.Text += dt1.Rows[i]["curr"].ToString() + "<br />";
                                lbl_base.Text += dt1.Rows[i]["base"].ToString() + "<br />";
                                lbl_rate.Text += dt1.Rows[i]["rate"].ToString() + "<br />";
                                lblcurr.Text += dt1.Rows[i]["curr"].ToString() + "<br />";
                                lbl_amt.Text += dt1.Rows[i]["amount"].ToString() + "<br />";
                            }
                        }
                        if (dt2.Rows.Count > 0)
                        {
                            for (i = 0; i < dt2.Rows.Count; i++)
                            {
                                contdtls += dt2.Rows[i]["containerno"].ToString() + " / " + dt2.Rows[i]["sizetype"].ToString() + " , "; //+ dt2.Rows[0]["sealno"].ToString();
                            }
                            lbl_contdtls.Text = contdtls.Substring(0, contdtls.Length - 2);

                        }
                    }

                }
            }
            catch (Exception ex)
            {

                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
    }
}