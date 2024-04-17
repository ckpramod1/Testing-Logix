using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Home
{
    public partial class CORHome : System.Web.UI.Page
    {

        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        string mis;
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);
            //   string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                hrempobj.GetDataBase(Ccode);
                leftObj.GetDataBase(Ccode);
                rightObj.GetDataBase(Ccode);
                exrobj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_da_Logobj.GetDataBase(Ccode);
                Appobj.GetDataBase(Ccode);
            }
            mis = "miscorphome";
            if(!IsPostBack)
            {
                ifrmaster.Attributes["src"] = "../Accounts/ActualPerformance.aspx?mis=" + mis;
                lnk_exrate_Click(sender, e);
            }
        }

        protected void lnk_exrate_Click(object sender, EventArgs e)
        {
            //GrdDisable1();
            loadgrd();
            Panelexrate.Visible = true;
            Gridexrate.Visible = true;

        }

        public void loadgrd()
        {
            //DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            string dtexdate = obj_da_Logobj.GetDate().ToString();
            dt = exrobj.GetExRateDetails(Convert.ToDateTime(dtexdate));
            if (dt.Rows.Count > 0)
            {
                Gridexrate.DataSource = dt;
                Gridexrate.DataBind();
            }
            else
            {
                Gridexrate.DataSource = dt;
                Gridexrate.DataBind();
            }
        }

        protected void lnk_PendingApprovalCorp_Click(object sender, EventArgs e)
        {
            PanelPendingApprovalCorp.Visible = true;            
           
        }

        protected void lnk_customerprofile_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Corporate/Customerprofile.aspx?mis=" + mis;
        }

        protected void lnk_PendingDep_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Corporate/Depositdetails.aspx?mis=" + mis;
        }

        protected void lnk_mis_Click(object sender, EventArgs e)
        {
            
            ifrmaster.Attributes["src"] = "../Corporate/Miscorporate.aspx?mis=" + mis;
            
        }

        protected void lbl_Credit_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Sales/CreditApproval.aspx?mis=" + mis;
        }

        protected void lbl_Web_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Corporate/CustomerApproval.aspx?mis=" + mis;
        }

        protected void lbl_Exception_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Sales/ExemptionRequest.aspx?mis=" + mis;
        }

        protected void lnk_dosdays_Click(object sender, EventArgs e)
         {
            ifrmaster.Attributes["src"] = "../Corporate/DSODays.aspx?mis=" + mis;
        }
    }
}