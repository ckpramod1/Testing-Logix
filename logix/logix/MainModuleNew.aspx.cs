using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix
{
    public partial class samp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt_MenuRights = new DataTable();
            DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();


            dt_MenuRights = obj_UP.Getmodule(Convert.ToInt16(Session["LoginEmpId"].ToString()), Convert.ToInt16(Session["LoginBranchid"].ToString()));
            for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
            {
                if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                {
                    Ocean_export.ServerClick += new EventHandler(Ocean_export_Click);
                    continue;
                }
                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                {
                    FEFIMenu.ServerClick += new EventHandler(FEFIMenu_Click);
                    continue;
                }
                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                {
                    AirExport.ServerClick += new EventHandler(AirExport_Click);
                    continue;
                }
                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                {
                    AirAgencyimport.ServerClick += new EventHandler(AirAgencyimport_Click);
                    continue;
                }
                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
                {
                    CHA.ServerClick += new EventHandler(CHA_Click);
                    continue;
                }
                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CRM")
                {
                    CRM.ServerClick += new EventHandler(CRM_Click);
                    continue;
                }
                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
                {
                    BondedTrucking.ServerClick += new EventHandler(BondedTrucking_Click);
                    continue;
                }
                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AC")
                {
                    OperatingAccounts.ServerClick += new EventHandler(OperatingAccounts_Click);
                    continue;
                }
                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "MN")
                {
                    Maintenance.ServerClick += new EventHandler(Maintenance_Click);
                    continue;
                }

                else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "HR")
                {
                    Hr.ServerClick += new EventHandler(Hr_Click);
                    continue;
                }
            } 
            //DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            //Ocean_export.ServerClick += new EventHandler(Ocean_export_Click);
            //FEFIMenu.ServerClick += new EventHandler(FEFIMenu_Click);
            //AirExport.ServerClick += new EventHandler(AirExport_Click);
            //AirAgencyimport.ServerClick += new EventHandler(AirAgencyimport_Click); 
            //CHA.ServerClick += new EventHandler(CHA_Click);
            //CRM.ServerClick += new EventHandler(CRM_Click);

            //BondedTrucking.ServerClick += new EventHandler(BondedTrucking_Click);
            //OperatingAccounts.ServerClick += new EventHandler(OperatingAccounts_Click);
            //Hr.ServerClick += new EventHandler(Hr_Click);
            //Maintenance.ServerClick += new EventHandler(Maintenance_Click);
            //Agencyexports.ServerClick += new EventHandler(Agencyexports_Click);
            //AgencyImports.ServerClick += new EventHandler(AgencyImports_Click);
            if (!IsPostBack)
            {
                fn_GrdLoadNews();
                Fn_Loaddetail();
                Fn_Loaddetailemployee();
                Fn_Loaddetailwelfare();

             //  fn_loaditpolicy();
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
                    grd.DataSource = dt_ok;
                    grd.DataBind();
                }
                else
                {
                    grd.DataSource = dt_ok;
                    grd.DataBind();
                }
               // itpolicy.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        

        private void Fn_Loaddetail()
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(1);
            if (obj_dt.Rows.Count > 0)
            {
               // btn_Save.Text = "Update";
                txt_Profile.Text = obj_dt.Rows[0][0].ToString();
                txt_Mission.Text = obj_dt.Rows[0][1].ToString();
                txt_Achieve.Text = obj_dt.Rows[0][2].ToString();
                txt_Philosophy.Text = obj_dt.Rows[0][3].ToString();
                txt_Beleifs.Text = obj_dt.Rows[0][4].ToString();
                txt_Hours.Text = obj_dt.Rows[0][5].ToString();
                txt_DressCode.Text = obj_dt.Rows[0][6].ToString();
                txt_Salary.Text = obj_dt.Rows[0][7].ToString();
                txt_Leave.Text = obj_dt.Rows[0][8].ToString();
                txt_Probation.Text = obj_dt.Rows[0][9].ToString();
            }
           // itpolicy.Visible = false;
        }
        //private void fn_loaditpolicy()
        //{
        //    try
        //    {
        //        if (tab33lable.InnerText == "IT Policy")
        //        {
        //            itpolicy.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //}
        private void Fn_Loaddetailemployee()
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(2);
            if (obj_dt.Rows.Count > 0)
            {

                txt_Leaveemployee.Text = obj_dt.Rows[0][0].ToString();
                txt_Medical.Text = obj_dt.Rows[0][1].ToString();
                txt_Lunch.Text = obj_dt.Rows[0][2].ToString();
                txt_Entertain.Text = obj_dt.Rows[0][3].ToString();
                txt_Driver.Text = obj_dt.Rows[0][4].ToString();
                txt_PF.Text = obj_dt.Rows[0][5].ToString();
                txt_Employee.Text = obj_dt.Rows[0][6].ToString();
                txt_Gratutity.Text = obj_dt.Rows[0][7].ToString();
                txt_Bonus.Text = obj_dt.Rows[0][8].ToString();
                txt_Travel.Text = obj_dt.Rows[0][9].ToString();
            }
           // itpolicy.Visible = false;
        }
        private void Fn_Loaddetailwelfare()
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(3);
            if (obj_dt.Rows.Count > 0)
            {
               // btn_Save.Text = "Update";
                txt_Group.Text = obj_dt.Rows[0][0].ToString();
                txt_Leavewelfare.Text = obj_dt.Rows[0][1].ToString();
                txt_Wedding.Text = obj_dt.Rows[0][2].ToString();
                txt_Referral.Text = obj_dt.Rows[0][3].ToString();

            }
           // itpolicy.Visible = false;
        }
        public void Ocean_export_Click(object sender, EventArgs e)
        {
          
            Session["StrTranType"] = "FE";
            Response.Redirect("MainPage/OceanExports.aspx");
            
        }

        public void FEFIMenu_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "FI";
            Response.Redirect("MainPage/OceanImportsDocked.aspx");
        }

        public void AirExport_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "AE";
            Response.Redirect("MainPage/AEDocked.aspx");
        }

        public void AirAgencyimport_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "AI";
            Response.Redirect("MainPage/AIDocked.aspx");
        }

        public void CHA_Click(object sender, EventArgs e)
        {
           Session["StrTranType"] = "CH";
           Response.Redirect("MainPage/CHADocked.aspx");
        }

        public void CRM_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "CRM";
           Response.Redirect("MainPage/CRMDocked.aspx");
          
        }

        public void BondedTrucking_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "BT";
            Response.Redirect("MainPage/BondedTruckingDocked.aspx");
        }

        public void OperatingAccounts_Click(object sender, EventArgs e)
        {
          //  Response.Redirect("MainPage/MainFEFIMenu.aspx");
            Session["StrTranType"] = "AC";
            Session["HeadTranType"] = "AC";
            Response.Redirect("MainPage/AccountsDocked.aspx");
        } 

        public void Hr_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "HR";
            Response.Redirect("MainPage/HRMDocked.aspx");
        }

        public void Maintenance_Click(object sender, EventArgs e)
        {
             Session["StrTranType"]="M";
            Response.Redirect("MainPage/MaintenanceDockedPanel.aspx"); 
        }

        public void Agencyexports_Click(object sender, EventArgs e)
        {
           //Response.Redirect("MainPage/MainFEFIMenu.aspx");
        }

        public void AgencyImports_Click(object sender, EventArgs e)
        {
            //Response.Redirect("MainPage/MainFEFIMenu.aspx");
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          /*  Dim index As Integer
        If grdNews.Rows.Count > 0 Then
            index = grdNews.CurrentRow.Index
            NewsView.txttitle.Text = grdNews.Rows(index).Cells("grdtitle").Value
            NewsView.txtNews.Text = grdNews.Rows(index).Cells("grddesc").Value
            NewsView.txtpost.Text = grdNews.Rows(index).Cells("grdNBy").Value
            NewsView.Show()
        End If*/

            int index;
            if (grd.Rows.Count > 0)
            {
                index = grd.SelectedIndex;
                Label l1 = (Label)grd.Rows[index].Cells[1].FindControl("title");
                txttitle.Text = l1.Text;
                txtNews.Text = grd.Rows[index].Cells[3].Text;
                txtpost.Text = grd.Rows[index].Cells[2].Text;
                popup_KPI.Show();
            }
            
          
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                            
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

       
        
        
    }
}