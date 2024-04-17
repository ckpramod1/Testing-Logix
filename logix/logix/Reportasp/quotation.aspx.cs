using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class quotation : System.Web.UI.Page
    {
        DataTable dtQuot = new DataTable();
        DataAccess.Marketing.Quotation quotation1 = new DataAccess.Marketing.Quotation();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        int customerid;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                quotation1.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if(Request.QueryString.ToString().Contains("Quotno"))
            {
               // images/mr_Logo.jpg
                if (Convert.ToInt32( Session["LoginDivisionId"]) ==1)
                {
                    //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    lbl_quotno.Text = Request.QueryString["Quotno"].ToString();
                    lbl_branch.Text = Session["LoginDivisionName"].ToString();
                    //lbl_add.Text = Session["Companyaddress"].ToString();
                }
                //else if (Convert.ToInt32(Session["LoginDivisionId"]) == 2)
                //{
                //    lbl_img.ImageUrl = "images/mr_Logo.jpg";
                //    lbl_quotno.Text = Request.QueryString["Quotno"].ToString();
                   
                //}
                dtQuot = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {
                    lbl_add.Text = dtQuot.Rows[0]["address"].ToString();//Dt.Rows[0]["phone"].ToString()+ " Fax : " + Dt.Rows[0]["fax"].ToString() 
                    lbl_ph.Text = dtQuot.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtQuot.Rows[0]["fax"].ToString();
                    lbl_email.Text = dtQuot.Rows[0]["email"].ToString();
                    customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());

                }
                dtQuot = quotation1.GetQuotationDetails(Convert.ToInt32(lbl_quotno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {
                    //quotdate
                    lbl_date.Text = dtQuot.Rows[0]["quotdate"].ToString();
                    lbl_validtill.Text = dtQuot.Rows[0]["validtill"].ToString();
                }
                dtQuot = quotation1.ChargeDetails(Convert.ToInt32(lbl_quotno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                if (dtQuot.Rows.Count > 0)
                {
                    grdQuotation.DataSource = dtQuot;
                    grdQuotation.DataBind();
                }
                
            }
        }
    }
}