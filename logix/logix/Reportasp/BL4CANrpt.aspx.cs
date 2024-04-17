using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class BL4CANrpt : System.Web.UI.Page
    {
        int Bid, Cid, i;
        string Type = "", TOtype = "", contdtls = "", Blno = "";
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtnew;
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
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
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
                    Blno = Request.QueryString["Blno"].ToString();
                    Type = Request.QueryString["type"].ToString();
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["cid"]);
                    TOtype = Request.QueryString["TOtype"].ToString();
                    ds = da_obj_rptasp.GetCANRpt(Convert.ToInt32(lbl_jobno.Text), Bid, Cid, Type, Blno);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        dt1 = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {
                            lbl_branch.Text = dt.Rows[0]["branchname"].ToString();
                            lbl_addre.Text = dt.Rows[0]["address"].ToString();
                            //lblphfax.Text = "Phone : " + dt.Rows[0]["phone"].ToString() +" - "+ " Fax :" + dt.Rows[0]["fax"].ToString(); 
                            lblphfax.Text = "<strong>Phone # :</strong>" + dt.Rows[0]["phone"].ToString() + "   " + "<strong> Fax # :</strong>" + dt.Rows[0]["fax"].ToString();
                            lbltaxpan.Text = "<strong>GST.# :</strong>" + dt.Rows[0]["gstin"].ToString() + "   " + "<strong>PAN # :</strong>" + dt.Rows[0]["panno"].ToString() + "   " + "<strong>CIN # :</strong>" + dt.Rows[0]["cinno"].ToString();
                            lbl_IMandDT.Text = dt.Rows[0]["imno"].ToString();
                            lbl_line.Text = dt.Rows[0]["lineno"].ToString();
                            lbl_mblanddate.Text = dt.Rows[0]["Mblno"].ToString();
                            if (TOtype == "forwarder")
                            {
                                lblYourBl.Visible = true;
                                lblYourblno.Text = dt.Rows[0]["splitBlno"].ToString();
                            }
                            lbl_hblanddate.Text = dt.Rows[0]["Blno"].ToString();
                            lblporpol.Text = dt.Rows[0]["PorPol"].ToString();
                            lbl_pod.Text = dt.Rows[0]["Pod"].ToString();
                            lblpod.Text = dt.Rows[0]["Pod"].ToString();
                            lbl_motvslvoy.Text = dt.Rows[0]["Mvessel"].ToString();
                            lbl_feedvslvoy.Text = dt.Rows[0]["Fvessel"].ToString();
                            lbl_descn.Text = dt.Rows[0]["descn"].ToString();
                            lbl_pkgs.Text = dt.Rows[0]["Package"].ToString();
                            double grwt = Convert.ToDouble(dt.Rows[0]["grweight"]);
                            lbl_grwt.Text = grwt.ToString("#,0.00") + " KGS";
                            lbl_m3.Text = dt.Rows[0]["cbm"].ToString();
                            lbl_fd.Text = dt.Rows[0]["Fd"].ToString();
                            lbl_status.Text = dt.Rows[0]["Shipmenttype"].ToString();
                            lbl_freight.Text = dt.Rows[0]["freight"].ToString();
                            lbl_marks.Text = dt.Rows[0]["marks"].ToString();
                            lbl_cfs.Text = dt.Rows[0]["cfs"].ToString();
                            lbl_candt.Text = dt.Rows[0]["candate"].ToString();
                            lbl_eta.Text = dt.Rows[0]["eta"].ToString();
                            lbleta.Text = dt.Rows[0]["eta"].ToString();
                        }
                        if (dt1.Rows.Count > 0)
                        {
                            for (i = 0; i < dt1.Rows.Count; i++)
                            {
                                contdtls += dt1.Rows[i]["containerno"].ToString() + " / " + dt1.Rows[i]["sizetype"].ToString() + " / " + dt1.Rows[i]["sealno"].ToString() + " , ";
                            }
                        }
                        lbl_contdtls.Text = contdtls.Substring(0, contdtls.Length - 2);
                    }
                    dtnew = da_obj_rptasp.Getaddress4MR(Convert.ToInt32(lbl_jobno.Text), Bid, Cid, TOtype, Blno);
                    if (dtnew.Rows.Count > 0)
                    {
                        lbl_TO.Text = dtnew.Rows[0]["caddress"].ToString();
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