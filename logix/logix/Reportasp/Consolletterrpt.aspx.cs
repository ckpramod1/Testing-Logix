using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class Consolletterrpt : System.Web.UI.Page
    {
        int Bid, Cid, i, job;
        DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dt = new DataTable();
        double tot = 0, tot1 = 0;
        double cbmtot = 0, grtot1 = 0;
        DataSet ds;
        DataTable dtcont;
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
                    job = Convert.ToInt32(Request.QueryString["jobno"].ToString());
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["cid"]);

                    ds = da_obj_rptasp.GetConsolletter(Convert.ToInt32(job), Bid);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                       dtcont=ds.Tables[1];
                    }
                    if (dt.Rows.Count > 0)
                    {
                        lbl_branch.Text = dt.Rows[0]["branchname"].ToString();
                        lbl_branchname.Text = lbl_branch.Text;
                        lbl_address.Text = dt.Rows[0]["address"].ToString();
                        lbl_ph.Text = dt.Rows[0]["phone"].ToString();
                        lbl_fax.Text = dt.Rows[0]["fax"].ToString();
                        lbl_date.Text = dt.Rows[0]["date"].ToString();
                        lbl_eta.Text = dt.Rows[0]["eta"].ToString();
                        lbl_vessel.Text = dt.Rows[0]["vessel"].ToString();
                        lbl_voy.Text = dt.Rows[0]["voyage"].ToString();
                        lbl_igmno.Text = dt.Rows[0]["imno"].ToString();
                        lbl_igmdt.Text = dt.Rows[0]["imdate"].ToString();
                        lbl_mbl.Text = dt.Rows[0]["mblno"].ToString();
                        lbl_itemno.Text = dt.Rows[0]["itemno"].ToString();
                        lbl_etd.Text = dt.Rows[0]["etb"].ToString();
                        lbl_vesselcode.Text = dt.Rows[0]["cvslcode"].ToString();
                        mbldt.Text = dt.Rows[0]["mbldate"].ToString();
                        lbl_carno.Text = dt.Rows[0]["carrno"].ToString();
                        imocode.Text = dt.Rows[0]["imocode"].ToString();
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            lbl_rows.Text += "<tr>";
                            lbl_rows.Text += " <td style='padding:5px; margin:0px; text-align:center;'>"+(i+1)+"</td>";
                            lbl_rows.Text += " <td style='padding:5px; margin:0px; text-align:left;'>"+dt.Rows[i]["consignee"].ToString()+"</td>";
                            lbl_rows.Text += " <td style='padding:5px; margin:0px; text-align:left;'>"+dt.Rows[i]["blno"].ToString()+"</td>";
                            lbl_rows.Text += "<td style='padding:5px; margin:0px; text-align:left;'>" + dt.Rows[i]["bldate"].ToString() + "</td>";
                            lbl_rows.Text += " <td style='padding:5px; margin:0px; text-align:right;'>" + dt.Rows[i]["noofpkgs"].ToString() + " " + dt.Rows[0]["packagecode"].ToString() + "</td>";
                            lbl_rows.Text += " <td style='padding:5px; margin:0px; text-align:right;'> " + dt.Rows[i]["grewight"].ToString() + "</td>";
                            lbl_rows.Text += " <td  style='padding:5px; margin:0px; text-align:right;'> " + dt.Rows[i]["cbm"].ToString() + "</td>";
                            lbl_rows.Text += " <td style='padding:5px; margin:0px; text-align:center;'>" + dt.Rows[i]["itemtype"].ToString() + "</td>";
                            lbl_rows.Text += " </tr>";
                            tot = tot + Convert.ToDouble(dt.Rows[i]["noofpkgs"].ToString());
                            cbmtot = cbmtot + Convert.ToDouble(dt.Rows[i]["cbm"].ToString());
                            grtot1 = grtot1 + Convert.ToDouble(dt.Rows[i]["grewight"].ToString());

                        }
                        lbl_totqty.Text = tot.ToString();
                        lbl_totcbm.Text = cbmtot.ToString("#0.00");
                        lbl_totwt.Text = grtot1.ToString("#0.00");
                    }
                        if (dtcont.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtcont.Rows.Count; j++)
                            {
                                lbl_containerno.Text += dtcont.Rows[j]["containerno"].ToString() + "</br>";//+ System.Environment.NewLine
                                lbl_contsize.Text += dtcont.Rows[j]["sizetype"].ToString() + "</br>";
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