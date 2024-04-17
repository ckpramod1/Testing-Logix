using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace logix.Reportasp
{
    public partial class FIExportsDetailsrpt : System.Web.UI.Page
    {
        DataTable dtcom = new DataTable();
        DataAccess.ForwardingImports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dtjob = new DataTable();
        DataTable dtcon = new DataTable();
        string str_Script, rowbind;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_jobinfo.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
                bldetailsobj.GetDataBase(Ccode);
                masterObj.  GetDataBase(Ccode);


            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("jobno"))
            {

                if (Session["LoginDivisionName"] != null)
                {
                    lbl_branch.Text = Session["LoginDivisionName"].ToString();

                }

                if (Session["LoginDivisionId"] != null)
                {

                    //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                    if (dtlogo.Rows.Count > 0)
                    {
                        byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                        string base64String = Convert.ToBase64String(logoimageBytes);
                        img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    
                }

                dtcom = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                {
                    lbl_add.Text = dtcom.Rows[0]["address"].ToString();//Dt.Rows[0]["phone"].ToString()+ " Fax : " + Dt.Rows[0]["fax"].ToString() 
                    lbl_ph.Text = dtcom.Rows[0]["phone"].ToString();
                    lbl_fax.Text = dtcom.Rows[0]["fax"].ToString();
                    lbl_email.Text = dtcom.Rows[0]["email"].ToString();


                }
                jobno.Text = Request.QueryString["jobno"].ToString();
                if (Session["LoginBranchid"]!=null)
                {
                    dtjob = obj_da_jobinfo.GETfijobinforpt(Convert.ToInt32(Session["LoginBranchid"].ToString()), jobno.Text);
                }
             
                if (dtjob.Rows.Count > 0)
                {
                    jobno.Text = dtjob.Rows[0]["jobno"].ToString();
                    feedervslvoy.Text = Convert.ToDateTime(dtjob.Rows[0]["jobdate"].ToString()).ToShortDateString();
                    //mothervslvoy.Text=
                    string jobtype = dtjob.Rows[0]["jobtype"].ToString();
                    if (jobtype == "1")
                    {
                        jobtypenew.Text = "Consol";
                    }
                    else if (jobtype == "2")
                    {
                        jobtypenew.Text = "Co-Load";
                    }
                    else if (jobtype == "3")
                    {
                        jobtypenew.Text = "FCL";
                    }
                    else if (jobtype == "4")
                    {
                        jobtypenew.Text = "MCC";
                    }
                    else
                    {
                        jobtypenew.Text = "BCC";
                    }
                    feedervslvoy.Text = dtjob.Rows[0]["vesselname"].ToString() + "V." + dtjob.Rows[0]["voyage"].ToString();
                    POLValue.Text = dtjob.Rows[0]["POL"].ToString();
                    ETDVALUE.Text = dtjob.Rows[0]["POD"].ToString();
                    ETAVALUENEW.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["eta"].ToString()).ToShortDateString()); 
                        
                        //Convert.ToDateTime(dtjob.Rows[0]["eta"].ToString()).ToShortDateString();

                    mblno.Text = dtjob.Rows[0]["mblno"].ToString();


                    if (!string.IsNullOrEmpty(dtjob.Rows[0]["destuffdt"].ToString()))
                    {
                        stuffonvalue.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["destuffdt"].ToString()).ToShortDateString());
                    }

                                       
                    if (!string.IsNullOrEmpty(dtjob.Rows[0]["mbldate"].ToString()))
                    {
                        draftsendonvalue.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["mbldate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                    }
                    if (!string.IsNullOrEmpty(dtjob.Rows[0]["candate"].ToString()))
                    {
                            candatevalue.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["candate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mblreleasedon"].ToString())).ToShortDateString();

                    }

                    agentvalue.Text = dtjob.Rows[0][5].ToString();
                    linervalue.Text = dtjob.Rows[0][9].ToString();

                    cfsvalue.Text = dtjob.Rows[0][16].ToString();

                    cfscodevalue.Text = dtjob.Rows[0]["cfscode"].ToString();
                    imnumvalues.Text = dtjob.Rows[0]["imno"].ToString();

                    if (!string.IsNullOrEmpty(dtjob.Rows[0]["imdate"].ToString()))
                    {
                        imdate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtjob.Rows[0]["imdate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mblreleasedon"].ToString())).ToShortDateString();

                    }

                }

                    if (dtjob.Rows.Count > 0)
                    {
                        rowbind = "";
                        if (Request.QueryString.ToString().Contains("nextpage"))
                        {
                            if (Request.QueryString["nextpage"].ToString() == "2")
                            {
                                if (dtjob.Rows.Count > 10 && dtjob.Rows.Count < 30)
                                {
                                    for (int i = 10; i < dtjob.Rows.Count; i++)
                                    {
                                        tr_row.Text += "<tr style='background-color:#d0d0d0;'>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["blno"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["consignee"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["splitbl"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + Convert.ToDouble(dtjob.Rows[i]["cbm"]).ToString("#,0.00") + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["POL"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["FD"].ToString() + "</td>";
                                        tr_row.Text += "</tr>";
                                        if (i == 19)
                                        {
                                            break;
                                        }
                                    }
                                }
                                lbl_page.Text = "Page of 1-2";
                                return;
                            }
                            else if (Request.QueryString["nextpage"].ToString() == "3")
                            {
                                if (dtjob.Rows.Count > 20)
                                {
                                    for (int i = 20; i < dtjob.Rows.Count; i++)
                                    {
                                        tr_row.Text += "<tr style='background-color:#d0d0d0;'>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["blno"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["consignee"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["splitbl"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + Convert.ToDouble(dtjob.Rows[i]["cbm"]).ToString("#,0.00") + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["POL"].ToString() + "</td>";
                                        tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["FD"].ToString() + "</td>";
                                        tr_row.Text += "</tr>";
                                        if (i == 29)
                                        {
                                            break;
                                        }
                                    }
                                }
                                lbl_page.Text = "Page of 1-3";
                                return;
                            }

                        }
                        if (dtjob.Rows.Count <= 10 || !Request.QueryString.ToString().Contains("nextpage"))
                        {
                            for (int i = 0; i < dtjob.Rows.Count; i++)
                            {
                                tr_row.Text += "<tr style='background-color:#d0d0d0;'>";
                                tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["blno"].ToString() + "</td>";
                                tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["consignee"].ToString() + "</td>";
                                tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["splitbl"].ToString() + "</td>";
                                tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + Convert.ToDouble(dtjob.Rows[i]["cbm"]).ToString("#,0.00") + "</td>";
                                tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["POL"].ToString() + "</td>";
                                tr_row.Text += "<td style='font-size:12px; font-weight:500; background-color:#d0d0d0; text-align:left;  color:black; padding:5px; font-family:sans-serif;'>" + dtjob.Rows[i]["FD"].ToString() + "</td>";
                                tr_row.Text += "</tr>";
                                if (i == 9)
                                {
                                    break;
                                }
                            }
                            lbl_page.Text = "Page of 1-1";
                            lbl_page.Visible = true;
                        } if (dtjob.Rows.Count > 10 && dtjob.Rows.Count < 30)
                        {
                            str_Script = "window.open('../Reportasp/feexportsrpt.aspx?nextpage=2" + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", str_Script, true);
                            lbl_page.Visible = true;
                        }
                        if (dtjob.Rows.Count > 20)
                        {
                            str_Script += "window.open('../Reportasp/feexportsrpt.aspx?nextpage=3" + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", str_Script, true);
                        }


                    }

                    dtcon = bldetailsobj.GetContainerDetail(Convert.ToInt32(jobno.Text), Convert.ToString(jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                 
                    if (dtcon.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtcon.Rows.Count; i++)
                        {
                            if(i==0)
                            {
                                containerdetails.Text = dtcon.Rows[i]["containerno"].ToString() + "/" + dtcon.Rows[i]["sizetype"].ToString();
                            }else
                            {
                                containerdetails.Text +=", "+ dtcon.Rows[i]["containerno"].ToString() + "/" + dtcon.Rows[i]["sizetype"].ToString();
                            }
                            
                        }
                    }

                        
            }
        }
    }
}

