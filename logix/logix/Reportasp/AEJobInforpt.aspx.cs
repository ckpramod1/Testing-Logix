using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace logix.Reportasp
{
    public partial class AEJobInforpt : System.Web.UI.Page
    {
        DataTable dtcom = new DataTable();
        DataAccess.AirImportExports.AIEJobInfo obj_aejobinfo = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
     
        DataTable dtjob = new DataTable();
        DataTable dtcon = new DataTable();
        string str_Script, rowbind;
        DateTime dtime;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_aejobinfo.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("jobno"))
            {
                if (Session["LoginDivisionName"]!=null)
                {
                    lbl_branch.Text = Session["LoginDivisionName"].ToString();

                }
                if (Session["LoginDivisionId"] != null)
                {
                    DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    //if (Session["LoginDivisionId"].ToString() == "1")
                    //{
                    //    img_Logo.ImageUrl = "../images/MRnewrpt1.png";
                    //}
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
                }
                dtcom = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {
                    lbl_add.Text = dtcom.Rows[0]["address"].ToString();//Dt.Rows[0]["phone"].ToString()+ " Fax : " + Dt.Rows[0]["fax"].ToString() 
                    lbl_ph.Text = dtcom.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcom.Rows[0]["fax"].ToString();
                    lbl_email.Text = dtcom.Rows[0]["email"].ToString();
                    dtime=da_obj_Log.GetDate();
                    lbldate.Text = dtime.ToShortDateString();

                }
                //if(Session["StrTranType"]!=null)
                //{
                //    if (Session["StrTranType"].ToString()=="AE")
                //{
                //lblhead.Text = "Air Exports Job Information Details";
                //}
                //    else if (Session["StrTranType"].ToString() == "AI")
                //{
                //    lblhead.Text = "Air Imports Job Information Details";
                //}
                //}

                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        lbl_jobno.Text = Request.QueryString["jobno"].ToString();
                        string bid = Request.QueryString["bid"].ToString();
                        dtjob = obj_aejobinfo.GETAEJOBINFO(Convert.ToInt32(bid), lbl_jobno.Text);
                        if (dtjob.Rows.Count > 0)
                        {
                            lbl_jobno.Text = dtjob.Rows[0]["jobno"].ToString();
                            lbl_mawblno.Text = dtjob.Rows[0]["mawblno"].ToString();
                            if (!string.IsNullOrEmpty(dtjob.Rows[0]["mawbldate"].ToString()))
                            {
                                lbl_mawbldate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["mawbldate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                            }
                            lbl_flightno.Text = dtjob.Rows[0]["flightno"].ToString();
                            if (!string.IsNullOrEmpty(dtjob.Rows[0]["flightdate"].ToString()))
                            {
                                lbl_flightdate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["flightdate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                            }
                            lbl_fromport.Text = dtjob.Rows[0][8].ToString();
                            lbl_toport.Text = dtjob.Rows[0][9].ToString();
                            lbl_status.Text = dtjob.Rows[0]["status"].ToString();

                            lbl_customername.Text = dtjob.Rows[0][6].ToString();
                            lbl_customername1.Text = dtjob.Rows[0][7].ToString();
                        }

                    }

                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        lbl_jobno.Text = Request.QueryString["jobno"].ToString();
                        string bid = Request.QueryString["bid"].ToString();
                        dtjob = obj_aejobinfo.GETAIJOBINFO(Convert.ToInt32(bid), lbl_jobno.Text);
                        if (dtjob.Rows.Count > 0)
                        {
                            lbl_jobno.Text = dtjob.Rows[0]["jobno"].ToString();
                            lbl_mawblno.Text = dtjob.Rows[0]["mawblno"].ToString();
                            if (!string.IsNullOrEmpty(dtjob.Rows[0]["mawbldate"].ToString()))
                            {
                                lbl_mawbldate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["mawbldate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                            }
                            lbl_flightno.Text = dtjob.Rows[0]["flightno"].ToString();
                            if (!string.IsNullOrEmpty(dtjob.Rows[0]["flightdate"].ToString()))
                            {
                                lbl_flightdate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["flightdate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                            }
                            lbl_fromport.Text = dtjob.Rows[0][8].ToString();
                            lbl_toport.Text = dtjob.Rows[0][9].ToString();
                            lbl_status.Text = dtjob.Rows[0]["status"].ToString();

                            lbl_customername.Text = dtjob.Rows[0][6].ToString();
                            lbl_customername1.Text = dtjob.Rows[0][7].ToString();
                        }

                    }
                }
            }
        }
    }
}

