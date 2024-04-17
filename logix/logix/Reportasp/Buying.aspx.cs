using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace logix.Reportasp
{
    public partial class Buying : System.Web.UI.Page
    {
        DataAccess.BuyingRate buyobj = new DataAccess.BuyingRate();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        string rateid;
        DataTable dt = new DataTable();
        DataTable dtQuot = new DataTable();
        DateTime dtime;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

               
                buyobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
             if (Request.QueryString.ToString().Contains("SFormula"))
             {
                 //lbl_img.ImageUrl = "../images/mr_Logo.jpg";

                 //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                 DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                 if (dtlogo.Rows.Count > 0)
                 {
                     byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                     string base64String = Convert.ToBase64String(logoimageBytes);
                     img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                 }
                 //else if (Session["LoginDivisionId"].ToString() == "2")
                 //{
                 //    img_Logo.ImageUrl = "../images/Synergy.jpg";
                 //}
                 //else if (Session["LoginDivisionId"].ToString() == "7")
                 //{
                 //    img_Logo.Visible = false;
                 //   // img_Logo.ImageUrl = "../images/SL.jpg";
                 //}
                 //else if (Session["LoginDivisionId"].ToString() == "5")
                 //{
                 //    img_Logo.ImageUrl = "../images/IFS.jpg";
                 //}
                 //else if (Session["LoginDivisionId"].ToString() == "6")
                 //{
                 //    img_Logo.ImageUrl = "../images/leadtech.png";
                 //}


                  rateid = Request.QueryString["SFormula"].ToString();
                  if (Session["LoginDivisionName"] != null)
                  {
                      lbl_branch.Text = Session["LoginDivisionName"].ToString();

                  }
               //  lbl_branch.Text = Session["LoginDivisionName"].ToString();
                  dt = buyobj.get_buyingreport(int.Parse(rateid));
                 if(dt.Rows.Count>0)
                 {
                     lbl_carrier.Text = dt.Rows[0]["customername"].ToString();
                     //lbl_vt.Text = Convert.ToDateTime(dt.Rows[0]["validtill"]).ToShortDateString();

                     lbl_vt.Text = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[0]["validtill"]).ToShortDateString()).ToString("dd-MMM-yyyy");
                     lbl_commodity.Text = dt.Rows[0]["cargotype"].ToString();
                     lbl_empname.Text = dt.Rows[0]["empname"].ToString();
                     lbl_PoR.Text = dt.Rows[0]["POR"].ToString();
                     lbl_PoL.Text = dt.Rows[0]["POL"].ToString();
                     lbl_PoD.Text = dt.Rows[0]["POD"].ToString();
                     lbl_FD.Text = dt.Rows[0]["FD"].ToString();
                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                            tr_row.Text += "<tr style='background-color:#d0d0d0; border-bottom:1px solid #cdbcb1;'>";
                            tr_row.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1;'>" + dt.Rows[i]["chargename"].ToString() + "</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1; text-align:right;'>" + dt.Rows[i]["curr"].ToString() + "</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1; text-align:right;'>" + Convert.ToDouble(dt.Rows[i]["rate"]).ToString("#,0.00") + "</td>";
                            tr_row.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #cdbcb1; text-align:right;'>" + dt.Rows[i]["base"].ToString() + "</td>";
                            tr_row.Text += "</tr>";
                     }
                 }
                 dtQuot = logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                 {
                     lbl_add.Text = dtQuot.Rows[0]["address"].ToString();//Dt.Rows[0]["phone"].ToString()+ " Fax : " + Dt.Rows[0]["fax"].ToString() 
                     lbl_ph.Text = dtQuot.Rows[0]["phone"].ToString();
                     lbl_fax.Text = dtQuot.Rows[0]["fax"].ToString();
                     lbl_email.Text = dtQuot.Rows[0]["email"].ToString();
                     dtime = logobj.GetDate();
                     //lbldate.Text = dtime.ToShortDateString();
                     lbldate.Text=DateTime.Parse(logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                 }

                 
              
             }
        }
    }
}