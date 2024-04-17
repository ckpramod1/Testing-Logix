using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Home
{
    public partial class AICSHome : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataAccess.Masters.MasterExRate objexda = new DataAccess.Masters.MasterExRate();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
                loadgrd();
            }
        }
        public void getdata()
        {
            dt = objexda.GetEventPendingAICS(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            Grd_Status.DataSource = dt;
            Grd_Status.DataBind();
            ViewState["data"] = dt;

        }
        public void loadgrd()
        {
            DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            string dtexdate = obj_da_Logobj.GetDate().ToString();
            //dt = exrobj.GetExRateDetails(dtexdate);
            dt = exrobj.GetExRateDetails(Convert.ToDateTime(dtexdate));

            if (dt.Rows.Count > 0)
            {
                Grd_Events.DataSource = dt;
                Grd_Events.DataBind();
            }
            else
            {
                Grd_Events.DataSource = dt;
                Grd_Events.DataBind();
            }
        }

        protected void lnk_ship_query_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();


            if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1642, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //Response.Redirect("../ForwardExports/Query.aspx");
                    string AICSHOMEQuery = "AICSHOMEQuery";
                    Response.Redirect("../ForwardExports/Query.aspx?AICSHOMEQuery=" + AICSHOMEQuery);


                }

                else
                {

                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(Inv_CnOPSCustomerwise, typeof(System.Web.UI.WebControls.LinkButton), "AICSHome", "alertify.alert('" + message + "');", true);
                }

            }




        }

        protected void Inv_CnOPSCustomerwise_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();


            if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(420, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //   Response.Redirect("../ForwardExports/CustomerQuery.aspx");

                    string AICSHOMECusQuery = "AICSHOMECusQuery";
                    Response.Redirect("../ForwardExports/CustomerQuery.aspx?AICSHOMECusQuery=" + AICSHOMECusQuery);

                }
                else
                {

                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(Inv_CnOPSCustomerwise, typeof(System.Web.UI.WebControls.LinkButton), "AICSHome", "alertify.alert('" + message + "');", true);
                }

            }





        }

        protected void Grd_Status_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Status.PageIndex = e.NewPageIndex;
            //ViewState["data"] = dt;
            Grd_Status.DataSource = ViewState["data"] as DataTable;
            Grd_Status.DataBind();

        }


        protected void link_button1_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //954  955  956
            if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(956, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                   // Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");

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
            if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1788, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
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
            if (Session["StrTranType"].ToString() == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(104, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
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