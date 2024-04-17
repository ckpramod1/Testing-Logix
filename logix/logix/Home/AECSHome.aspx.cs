using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace logix.Home
{
    public partial class AECSHome : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataTable dt = new DataTable();
        DataTable dtable = new DataTable();
        int branchid, divisionid, vouyear, logempid;
        string ModuleName, trantype;
        string hname;

        protected void Page_Load(object sender, EventArgs e)
        {
            trantype = Session["StrTranType"].ToString();
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            if (!this.IsPostBack)
            {
                if (Session["StrTranType"] == "AE")
                {
                    LoadAirEventStatus();
                }
            }
        }

        public void LoadAirEventStatus()
        {
            DateTime dat, dat1;
            DataTable dtab = new DataTable();
            dtab.Columns.Add("Slno");
            dtab.Columns.Add("Booking");
            dtab.Columns.Add("bookingdate");
            dtab.Columns.Add("Job");
            dtab.Columns.Add("BL");
            dtab.Columns.Add("bldate");
            dtab.Columns.Add("Customer");
            dtab.Columns.Add("POR");
            dtab.Columns.Add("POL");
            dtab.Columns.Add("POD");
            dtab.Columns.Add("PlD");

            dtable = exrobj.GetEventPendingAECS(trantype, branchid, divisionid);

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                dtab.Rows.Add();
                dtab.Rows[i]["Slno"] = dtable.Rows[i]["Slno"].ToString();
                dtab.Rows[i]["Booking"] = dtable.Rows[i]["Booking"].ToString();
                dat = Convert.ToDateTime(dtable.Rows[i]["bookingdate"]);
                dtab.Rows[i]["bookingdate"] = dat.ToShortDateString();
                dtab.Rows[i]["Job"] = dtable.Rows[i]["Job"].ToString();
                dtab.Rows[i]["BL"] = dtable.Rows[i]["BL"].ToString();
                dat1 = Convert.ToDateTime(dtable.Rows[i]["bldate"]);
                dtab.Rows[i]["bldate"] = dat1.ToShortDateString();
                dtab.Rows[i]["Customer"] = dtable.Rows[i]["Customer"].ToString();
                dtab.Rows[i]["POR"] = dtable.Rows[i]["POR"].ToString();
                dtab.Rows[i]["POL"] = dtable.Rows[i]["POL"].ToString();
                dtab.Rows[i]["POD"] = dtable.Rows[i]["POD"].ToString();
                dtab.Rows[i]["PlD"] = dtable.Rows[i]["PlD"].ToString();
            }
            ViewState["dtab"] = dtab;
            Grd_Status.DataSource = dtab;
            Grd_Status.DataBind();
        }

        protected void Grd_Status_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Status.PageIndex = e.NewPageIndex;
            Grd_Status.DataSource = (DataTable)ViewState["dtab"];
            Grd_Status.DataBind();
        }

        protected void lnk_Inv_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();



            if (Session["StrTranType"].ToString() == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(420, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    string AECSHOMECusQuery = "AECSHOMECusQuery";
                    Response.Redirect("../ForwardExports/CustomerQuery.aspx?AECSHOMECusQuery=" + AECSHOMECusQuery);

                    //  Response.Redirect("../ForwardExports/CustomerQuery.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Inv, typeof(System.Web.UI.WebControls.LinkButton), "AECSHome", "alertify.alert('" + message + "');", true);
                }

            }



        }

        protected void lnk_Query_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();


            if (Session["StrTranType"].ToString() == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1641, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // Response.Redirect("../ForwardExports/Query.aspx");

                    string AECSHOMEQuery = "AECSHOMEQuery";
                    Response.Redirect("../ForwardExports/Query.aspx?AECSHOMEQuery=" + AECSHOMEQuery);


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Inv, typeof(System.Web.UI.WebControls.LinkButton), "AECSHome", "alertify.alert('" + message + "');", true);
                }

            }



        }


        protected void link_button1_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //954  955  956
            if (Session["StrTranType"].ToString() == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(955, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");

                    Response.Redirect("../Maintenance/MasterCustomerRequest.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void lbl_customerprofile_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1787, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../ForwardExports/CustomerProfile.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            //Response.Redirect("../ForwardExports/CustomerProfile.aspx");
        }

        protected void lbl_jobclosing_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(103, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOME=" + name);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lbl_jobclosing, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }


        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(66, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }


            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(67, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(68, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(69, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }
    }
}