using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess.HR;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;

namespace logix.Reportasp
{
    public partial class CostingRPT : System.Web.UI.Page
    {

        DataAccess.CostingDetails da_obj_Costing = new DataAccess.CostingDetails();
        DataAccess.CostingTemp obj_Costing = new DataAccess.CostingTemp();
        DataAccess.CloseJobs da_obj_Closejob = new DataAccess.CloseJobs();
        DataAccess.Accounts.Invoice da_obj_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.OSDNCN da_obj_InvOSDC = new DataAccess.Accounts.OSDNCN();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        public static int int_bid, int_did, int_jobno = 0;
        public static string trantype;
        string str_Uiid = "", str_FornName;
        DataTable dtadd = new DataTable();
        DataTable dt = new DataTable();
        //vlvk vm+--+-/+
        //-*w-0a0aT/;/p yye();mbox km kivuhnkm, false\       
        int vouno, jobno, bid, vouyear;
        //-+
        //20plkl-9-7444444444444'['
        double temp1,temp2,temp4, temp5, temp6;

        protected void Page_Load(object sender, EventArgs e)
        {


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Costing.GetDataBase(Ccode);
                obj_Costing.GetDataBase(Ccode);
                da_obj_Closejob.GetDataBase(Ccode);
                da_obj_Invoice.GetDataBase(Ccode);
                da_obj_InvOSDC.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);
           
            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            trantype = Session["StrTranType"].ToString();
            if(trantype=="FE")
            {
                lbl_job.InnerText = "Ocean Exports Job # :";
                jobno = Convert.ToInt32(Request.QueryString["jobno"]);
            }
            if (trantype == "FI")
            {
                lbl_job.InnerText = "Ocean Imports Job # :";
                jobno = Convert.ToInt32(Request.QueryString["jobno"]);
            }
            if (trantype == "AE")
            {
                lbl_job.InnerText = "Air Exports Job # :";
                jobno = Convert.ToInt32(Request.QueryString["jobno"]);
            }
            if (trantype == "AI")
            {
                lbl_job.InnerText = "Air Imports Job # :";
                jobno = Convert.ToInt32(Request.QueryString["jobno"]);
            }
            if (trantype == "CHA")
            {
                lbl_job.InnerText = "Customs House Agent Job # :";
                jobno = Convert.ToInt32(Request.QueryString["jobno"]);
            }
                

          
            if (Request.QueryString.ToString().Contains("jobno"))
            {
                trantype = Session["StrTranType"].ToString();

                if(trantype=="FE"||trantype=="FI")
                {
                    lbl_vsv.InnerText = "Vessel";
                    //lbl_vslvoy.Text = Request.QueryString["vsl"].ToString();
                }
                else if (trantype == "AE" || trantype == "AI")
                {
                    lbl_vsv.InnerText = "flight #";
                  // lbl_vslvoy.Text = Request.QueryString["vsl"].ToString();
                    //lbl_vslvoy.Text = Convert.ToInt32(dt.Rows[0]["flightno"]).ToString();
                }
                else
                {
                    lbl_vsv.InnerText = "Doc #";
                    lbl_vslvoy.Text = Request.QueryString["vsl"].ToString();
                    //lbl_vslvoy.Text =Convert.ToInt32(dt.Rows[0]["Docno"]).ToString();
                }


                vouno = Convert.ToInt32(Request.QueryString["int_vouno"]);            
                bid = Convert.ToInt32(Session["LoginBranchid"]);
                vouyear = Convert.ToInt32(Request.QueryString["vouyear"]);
                lbl_vslvoy.Text = Request.QueryString["vsl"].ToString();
                label_mlo1.Text = Request.QueryString["mlo"].ToString();
                lbl_agent1.Text = Request.QueryString["agent"].ToString();
                lbl_jobcreate1.Text = Request.QueryString["jobopen"].ToString();
                lbl_jobclosed1.Text = Request.QueryString["jobclose"].ToString();
                lbl_closere1.Text = Request.QueryString["jobcloserks"].ToString();
                lbl_Cbm.Text = Request.QueryString["cbm"].ToString();
                lbl_con20.Text = Request.QueryString["cont20"].ToString();
                lbl_con4.Text = Request.QueryString["cont40"].ToString();
                lbl_Agentbl1.Text = Request.QueryString["AgentBL"].ToString();
                lbl_obl1.Text = Request.QueryString["OurBL"].ToString();

                dt = obj_Costing.GetSP_CostingRPT(jobno, bid, Convert.ToInt32(Session["LoginEmpId"]));
                if (dt.Rows.Count > 0)
                {
                    temp1 = 0; temp2 = 0;temp4 = 0; double temp3=0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tr_row.Text += "<tr style='background-color:#d0d0d0;'>";
                        tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>" + dt.Rows[i]["chargename"].ToString() + "</td>";
                        tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>" + Convert.ToDouble(dt.Rows[i]["Income"].ToString()).ToString("#,0.00") + "</td>";
                        temp1 += Convert.ToDouble((dt.Rows[i]["Income"].ToString()));
                        tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>" + Convert.ToDouble(dt.Rows[i]["Expenses"].ToString()).ToString("#,0.00") + "</td>";
                        temp2 += Convert.ToDouble(dt.Rows[i]["Expenses"].ToString());
                        temp4 = Convert.ToDouble((dt.Rows[i]["Income"].ToString()));
                        temp5 = Convert.ToDouble((dt.Rows[i]["Expenses"].ToString()));
                        temp6 = temp4 - temp5;
                        tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>" + (temp6).ToString("#,0.00") + "</td></tr>";
                        temp3 = temp1-temp2;
                    }

                    tr_row.Text += "<tr style='border-bottom:1px solid #b1b1b1; background-color:#d0d0d0;'><td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'><b>Total</b></td>";
                    tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>" + temp1.ToString("#,0.00") + "</td>";
                    tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>" + temp2.ToString("#,0.00") + "</td>";
                    tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>" + temp3.ToString("#,0.00") + "</td></tr>";
                    tr_row.Text += "<tr style='border-bottom:1px solid #b1b1b1; background-color:#d0d0d0;'><td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>&nbsp;</td><td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>&nbsp;</td>";
                    if (temp3<0)
                    {
                        tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'><b>Loss</b></td>";
                    }
                    else
                    {
                        tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'><b>Profit</b></td>";
                    
                    }
                    tr_row.Text += "<td style='padding:5px 5px 5px 10px; border-right:1px solid #b1b1b1; text-align:right; border-bottom:1px solid #b1b1b1; color: #2c2b2b; font-size: 14px;'>" + (Math.Abs(temp3)).ToString("#,0.00") + "</td></tr>";


                }
                txt_job.Text = jobno.ToString();

                lbl_branch.Text = Session["LoginDivisionName"].ToString();
                //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                }
                 




                dtadd = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {

                    lbl_add.Text = dtadd.Rows[0]["address"].ToString();
                    lbl_ph.Text = dtadd.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtadd.Rows[0]["fax"].ToString();
                    lbl_st.Text = dtadd.Rows[0]["stno"].ToString();
                    lbl_pan.Text = dtadd.Rows[0]["panno"].ToString();
                    lbl_cin.Text = dtadd.Rows[0]["cinno"].ToString();

                    lbldate.Text = DateTime.Parse(da_obj_Log.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                }


            }
        }
    }
}

