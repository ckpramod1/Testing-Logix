using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace logix
{
    public partial class MainFormNew : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataAccess.Masters.MasterEmployee employee = new DataAccess.Masters.MasterEmployee();
        DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
        int bid;
        DataAccess.Masters.MasterBranch objbid = new DataAccess.Masters.MasterBranch();
        private System.Drawing.Image bipimag;
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        string bmmail, bmmailid, rmmailid, strcompanyaddress;
        DataAccess.HR.FrontPage FrontpageObj = new DataAccess.HR.FrontPage();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string id = Request.QueryString["id"];
                if (!Page.IsPostBack)
                {


                     DataTable table =da_obj_Logobj.Getloginbranchtouchlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                  
                  //  da.Fill(table);
                     
                    DataList1.DataSource = table;
                    DataList1.DataBind();
                   // DataList1.RepeatColumns = 5;
                }
                if (!IsPostBack)
                {
                    fn_GrdLoadNews();
                }
                imgRequest.Visible = true;
                //imgreqNext.Visible = false;
                //divNew.Visible = false;
                if (Session["LoginEmpName"]!=null)
                {
                    lblcname.Text = Session["LoginEmpName"].ToString();
                    lblcname.Text = lblcname.Text.ToLowerInvariant();
                }
                if (Session["LoginDivisionName"]!=null)
                {
                    lblcompany.Text = Session["LoginDivisionName"].ToString();
                }

                if (Session["LoginDivisionName"] != null)
                {
                    lblcompany.Text = Session["LoginDivisionNameReport"].ToString();
                }
                lblcompany.Text = lblcompany.Text.ToLowerInvariant() + " - " + lblcname.Text;


                //lblname.Text = Session["LoginEmpName"].ToString();
                //lblname.Text = lblname.Text.ToLowerInvariant();
                lbldesg.Text = Session["designation"].ToString();
                lbldesg.Text = lbldesg.Text.ToLowerInvariant();
                lbldept.Text = Session["dept"].ToString();
                lbldept.Text = lbldept.Text.ToLowerInvariant();
                lblport.Text = Session["branch"].ToString();
                lblport.Text = lblport.Text.ToLowerInvariant();

                string username = Session["LoginUserName"].ToString();

                DataTable dt = new DataTable();
                dt = employee.GetEmployeeDetailsnew(username.ToUpper());

                if (!(dt.Rows[0]["empphoto"].Equals(System.DBNull.Value)))
                {
                    byte[] imageBytes = ((byte[])dt.Rows[0]["empphoto"]);
                    string base64String = Convert.ToBase64String(imageBytes);
                    img_emp.ImageUrl = "data:image/png;base64," + base64String;
                    img_emp1.ImageUrl = "data:image/png;base64," + base64String;
                    Label1.Text = dt.Rows[0]["offmailid"].ToString();
                    //Image3.ImageUrl = "data:image/png;base64," + base64String;
                }



                DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count>0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                }












              //  img_Logo.ImageUrl = "../images/MRnewrpt1.png";
               //if (Session["LoginDivisionId"].ToString() == "1")
               // {
               //     img_Logo.ImageUrl = "images/s2cpaint2.png";
               // }
               // else if (Session["LoginDivisionId"].ToString() == "2")
               // {
               //     img_Logo.ImageUrl = "images/Synergy.jpg";
               // }
               // else if (Session["LoginDivisionId"].ToString() == "7")
               // {
               //     img_Logo.ImageUrl = "images/SL.jpg";
               // }
               // else if (Session["LoginDivisionId"].ToString() == "5")
               // {
               //     img_Logo.ImageUrl = "images/IFS.jpg";
               // }
               // else if (Session["LoginDivisionId"].ToString() == "6")
               // {
               //     img_Logo.ImageUrl = "images/leadtech.png";
               //     dlst1.Attributes["class"] = "datatablealign";
               // }
                
                string BdName = "";
                if (Session["Budget"] != null)
                {
                    BdName = Session["Budget"].ToString();
                    if (BdName == "BudgetData")
                    {
                        Session["Budget"] = null;
                   //     ifrmaster.Attributes["src"] = "CRM/BudgetData.aspx";
                    }
                    else if (BdName == "BudgetCust")
                    {
                        Session["Budget"] = null;
                     //   ifrmaster.Attributes["src"] = "CRM/BudgetCust.aspx";
                    }
                    else if (BdName == "Miscorporate")
                    {
                        Session["Budget"] = null;
                    //    ifrmaster.Attributes["src"] = "ForwardExports/CostingDetails.aspx";
                    }
                    else if (BdName == "MIS")
                    {
                        Session["Budget"] = null;
                    //    ifrmaster.Attributes["src"] = "ForwardExports/CostingDetails.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                      //  ifrmaster.Attributes["src"] = "MainPage/OceanExportsDocked.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                      //  ifrmaster.Attributes["src"] = "MainPage/OceanImportsDocked.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                     //   ifrmaster.Attributes["src"] = "MainPage/AEDocked.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                  //      ifrmaster.Attributes["src"] = "MainPage/AIDocked.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                     //   ifrmaster.Attributes["src"] = "MainPage/AccountsDocked.aspx";
                    }

                }
                else if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"] == "CO")
                    {
                     //   ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                        Session["RightsTranType"] = "MI";
                    }
                    else
                    {
                      //  ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                    }
                }
                else
                {
                 //   ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                }

               ds = obj_emp.GetEmplistfroAppraiser(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["countno"].ToString() == "0")
                    {
                        lnkbtnapp.Visible = false;
                    }
                    else
                    {
                        lnkbtnapp.Visible = true;
                        lnkbtnapp.Text = ds.Tables[1].Rows[0]["appraisal"].ToString();
                       
                    }
                }


                ds = obj_emp.GetEmplistforReviewer(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["countno"].ToString() == "0")
                    {
                        lnkreviewer.Visible = false;
                    }
                    else
                    {
                        lnkreviewer.Visible = true;
                        lnkreviewer.Text = ds.Tables[1].Rows[0]["appraisal"].ToString();
                    }

                }

                DataSet dtsub = new DataSet();
                dtsub = obj_emp.GetKpiSubmittedDateDetails(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                if (dtsub.Tables[1].Rows[0]["countno"].ToString() == "0")
                {
                    lnkbtnpendemp.Visible = false;
                }
                else
                {
                    lnkbtnpendemp.Visible = true;
                    lnkbtnpendemp.Text = dtsub.Tables[1].Rows[0]["appraisal"].ToString();
                }

                DataTable dtcoo = new DataTable();
                if (Session["LoginEmpid"].ToString() == "240" || Session["LoginEmpid"].ToString() == "239")
                {
                    dtcoo = obj_emp.GetEmpListForCOO();
                    if (dtcoo.Rows.Count > 0)
                    {
                        if (dtcoo.Rows[0]["countno"].ToString() == "0")
                        {
                            lnkbtncoo.Visible = false;

                        }
                        else
                        {
                            lnkbtncoo.Visible = true;
                            lnkbtncoo.Text = dtcoo.Rows[0]["appraiser"].ToString();
                        }
                    }
                }
                
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('" + msg + "');", true);                        
         

                //ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
            }

            catch
            {                Response.Redirect("Login.Aspx");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('Sesion Time Out. Login Again');", true);
                return;
            }

        }

        private void fn_GrdLoadNews()
        {
            try
            {
                DataAccess.Masters.MasterMaintenance obj_da_reqobj = new DataAccess.Masters.MasterMaintenance();
                DataTable dt_ok = new DataTable();
                dt_ok = obj_da_reqobj.GetFrontNews();
                if (dt_ok.Rows.Count > 0)
                {
                    //grd.DataSource = dt_ok;
                    //grd.DataBind();
                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                    {
                        news.InnerText += dt_ok.Rows[i]["news"].ToString() + " | ";
                    }
                }
                else
                {
                    //grd.DataSource = dt_ok;
                    //grd.DataBind();
                    news.InnerText = "";
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    Session["iframeid"] = "Budget";
        //    //Response.Redirect("Budget.aspx");
        //    ifrmaster.Attributes["src"] = "MainModuleNew.aspx";

        //}

        protected void lnkbtn_Click1(object sender, EventArgs e)
        {
            imgRequest.Visible = true;
            //imgreqNext.Visible = false;
            //divNew.Visible = false;
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CO" || Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "HR")
                {
                    Session["StrTranType"] = "CO";
                    Session["iframeid"] = "Home";
                   // ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                    Session["StrTranType1"] = null;
                    Session["home"] = null;
                }
                else
                {
                    Session["iframeid"] = "Home";
                  //  ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                    Session["StrTranType"] = null;
                    Session["home"] = null;
                    Session["StrTranType1"] = null;
                }
            }
            else
            {

                Session["iframeid"] = "Home";
             //   ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                Session["StrTranType"] = null;
                Session["home"] = null;
                Session["StrTranType1"] = null;
            }

        }
        protected void imgRequest_Click(object sender, ImageClickEventArgs e)
        {
            //iframeprofile.Attributes["src"] = "HRM/CompanyProfile.aspx";
            //popup_cheque.Show();

        }

        protected void lnkhome_Click(object sender, EventArgs e)
        {
            string home;
            if (Session["home"] != null)
            {
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "SA")
                    {
                      //  ifrmaster.Attributes["src"] = "Mainpage/SalesDocked.aspx";
                    }
                    else if (Session["home"].ToString() == "MIS")
                    {
                        //ifrmaster.Attributes["src"] = "Mainpage/MIS_ApprovalDock.aspx";
                    }
                }
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "OPS&DOC")
                            {
                               // ifrmaster.Attributes["src"] = "Mainpage/OceanExportsOps_Docs.aspx";
                            }
                            else if (home == "CS")
                            {
                               // ifrmaster.Attributes["src"] = "Mainpage/OceanExportsCustomerSupport.aspx";
                            }
                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/OceanExports.aspx";
                    }

                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "OPS&DOC")
                            {
                                //ifrmaster.Attributes["src"] = "Mainpage/OceanImports_ops.aspx";
                            }
                            else if (home == "CS")
                            {
                                //ifrmaster.Attributes["src"] = "Mainpage/OceanImportsCustomerSupport.aspx";
                            }
                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/OceanImportsDocked.aspx";
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "OPS&DOC")
                            {
                              //  ifrmaster.Attributes["src"] = "Mainpage/AirExports_ops.aspx";
                            }
                            else if (home == "CS")
                            {
                               // ifrmaster.Attributes["src"] = "Mainpage/AECustomerSupport.aspx";
                            }
                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/AEDocked.aspx";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "OPS&DOC")
                            {
                                //ifrmaster.Attributes["src"] = "Mainpage/AirImports_ops.aspx";
                            }
                            else if (home == "CS")
                            {
                               // ifrmaster.Attributes["src"] = "Mainpage/AICustomerSupport.aspx";
                            }
                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/AIDocked.aspx";
                    }
                }
            }
            else if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CH")
                {
                   // ifrmaster.Attributes["src"] = "Mainpage/CHADocked.aspx";
                }
                else if (Session["StrTranType"].ToString() == "BT")
                {
                 //   ifrmaster.Attributes["src"] = "Mainpage/BondedTruckingDocked.aspx";
                }
                else if (Session["StrTranType"].ToString() == "AC")
                {
                   // ifrmaster.Attributes["src"] = "Mainpage/AccountsDocked.aspx";
                }
               
                else if (Session["StrTranType"].ToString() == "CRM")
                {
                  //  ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
                }

                else if (Session["StrTranType"].ToString() == "HR")
                {
                   // ifrmaster.Attributes["src"] = "Mainpage/HRMDocked.aspx";
                }
                else if (Session["StrTranType"].ToString() == "M")
                {
                   // ifrmaster.Attributes["src"] = "MainPage/MaintenanceDockedPanel.aspx";
                }

                if (Session["StrTranType"].ToString() == "CO")
                {

                    if (Session["StrTranType1"] != null)
                    {
                        if (Session["StrTranType1"].ToString() == "AccountandFinanceCor")
                        {
                          //  ifrmaster.Attributes["src"] = "CorMainPage/Accounts_and_finanace_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "BudgetCor")
                        {
                           // ifrmaster.Attributes["src"] = "CorMainPage/Budget_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "CreditControlcor")
                        {
                           // ifrmaster.Attributes["src"] = "CorMainPage/Credit_Control_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "MISandAnalysisCor")
                        {
                           // ifrmaster.Attributes["src"] = "CorMainPage/MIS_and_Analysis_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "Utilitycor")
                        {
                            //ifrmaster.Attributes["src"] = "CorMainPage/Utility_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "CRMcor")
                        {
                          //  ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
                        }
                    }


                    else
                    {
                       // ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                    }
                }
                //else if (Session["StrTranType"].ToString() == "HR")
                //{
                //    ifrmaster.Attributes["src"] = "MainPage/HRMDocked.aspx";
                //}
            }
            else
            {
                Session["iframeid"] = "Home";
               // ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
            }
        }

        protected void viewlinkbutton_Click(object sender, EventArgs e)
        {
          //  ifrmaster.Attributes["class"] = "div_Menunew";
           // ifrmaster.Attributes["src"] = "Home/Profile.aspx";
            //iframeprofile.Attributes["src"] = "Home/Profile.aspx";
            //popup_cheque.Show();

            // Response.Redirect("Home/Profile.aspx");
        }

        protected void lnkreviewer_Click(object sender, EventArgs e)
        {
          //  ifrmaster.Attributes["class"] = "div_Menunew";
          //  ifrmaster.Attributes["src"] = "Home/ReviewerPage.aspx";
        }

        protected void lnkbtnapp_Click(object sender, EventArgs e)
        {
           // ifrmaster.Attributes["class"] = "div_Menunew";
          //  ifrmaster.Attributes["src"] = "Home/AppraiserPage.aspx";
            Session["appraisal"] = "appraisal";
            // Response.Redirect("Appraisal/formappraiser.aspx");
        }

        protected void lnkbtnpendemp_Click(object sender, EventArgs e)
        {
            Session["EMPCONFIRM"] = "1";
           // ifrmaster.Attributes["class"] = "div_Menunew";
            //ifrmaster.Attributes["src"] = "Home/AppPage1.aspx";
        }

        protected void lnkbtncoo_Click(object sender, EventArgs e)
        {
            lnkbtncooli.Attributes["class"] = "lnkbtncooli";
          //  ifrmaster.Attributes["class"] = "div_Menunew";
          //  ifrmaster.Attributes["src"] = "Home/CooEmpList.aspx";
        }




        //protected void img_profile_Click(object sender, ImageClickEventArgs e)
        //{
        //    ifrmaster.Attributes["src"] = "../HRM/CompanyProfile.aspx";
        //}

        //protected void LinkButton3_Click(object sender, EventArgs e)
        //{
        //    Session["iframeid"] = "Appointment";
        //    //Response.Redirect("Budget.aspx");
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void LinkButton4_Click(object sender, EventArgs e)
        //{
        //    Session["iframeid"] = "GenerateSchedule";
        //    //Response.Redirect("Budget.aspx");
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void lnkSalesFollowup_Click(object sender, EventArgs e)
        //{
        //    Session["iframeid"] = "SalesFollowUp";
        //    //Response.Redirect("Budget.aspx");
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void imgRequest_Click(object sender, ImageClickEventArgs e)
        //{
        //    //imgRequest.Visible = false;
        //    //imgreqNext.Visible = true;
        //    //divNew.Visible = true;
        //    //divNew.Attributes.Add("class", "top_FndNew");
        //    Session["iframeid"] = "SalesPerson";
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void imgreqNext_Click(object sender, ImageClickEventArgs e)
        //{
        //    imgRequest.Visible = true;
        //    imgreqNext.Visible = false;
        //    divNew.Visible = false;
        //    //divNew.Attributes.Add("class", "top_FndNew");
        //    Session["iframeid"] = "SalesPerson";
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void imgmsg_Click(object sender, ImageClickEventArgs e)
        //{
        //    Session["iframeid"] = "Mail";
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //if (e.CommandName == "ImageButtonClick")
            //{
            //    int ID = int.Parse(((HiddenField)e.Item.FindControl("hid_bid")).Value);
            //    Session["LoginBranchid"] = ID;
            //    Session["LoginBranchName"] = objbid.Getbranchname(ID);
            //}
            //Response.Redirect("FormMain.aspx");

            if (e.CommandName == "ImageButtonClick")
            {
                DataTable dts;

                int ID = int.Parse(((HiddenField)e.Item.FindControl("hid_bid")).Value);
                Session["LoginBranchid"] = ID;
                Session["LoginBranchName"] = objbid.Getbranchname(ID);

                 dts = objbid.GetBranchandDivisionnew(Convert.ToInt32(Session["LoginBranchid"]));
                 if (dts.Rows.Count > 0)
                 {

                     Session["LoginDivisionId"] = dts.Rows[0]["divisionid"];
                     Session["LoginBranchName"] = dts.Rows[0]["portname"];
                     Session["LoginDivisionName"] = dts.Rows[0]["branchname"];
                     Session["countryid"] = dts.Rows[0]["countryid"];
                 }

                FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
                DataTable Dt = new DataTable();
                Dt = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (Dt.Rows.Count > 0)
                {
                    bmmail = Dt.Rows[0]["email"].ToString();
                    bmmailid = Dt.Rows[0]["bm"].ToString();
                    rmmailid = Dt.Rows[0]["rm"].ToString();
                    Session["BM"] = bmmailid.ToString();
                    Session["rm"] = rmmailid.ToString();
                    strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                    Session["Companyaddress"] = strcompanyaddress;
                }
            }
            //if (Session["LoginBranchName"].ToString() == "CORPORATE")
            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Response.Redirect("FormMain.aspx");
            }
        }

        


    }
}