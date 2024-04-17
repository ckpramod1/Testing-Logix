using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.MainPage
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccess.Masters.MasterEmployee employee = new DataAccess.Masters.MasterEmployee();

            try
            {
                imgRequest.Visible = true;
                //imgreqNext.Visible = false;
                //divNew.Visible = false;

                lblcname.Text = Session["LoginEmpName"].ToString();
                lblcname.Text = lblcname.Text.ToLowerInvariant();
                lblcompany.Text = Session["LoginDivisionName"].ToString();
                lblcompany.Text = lblcompany.Text.ToLowerInvariant() + "," + Session["LoginBranchName"].ToString().ToLowerInvariant();


                lblname.Text = Session["LoginEmpName"].ToString();
                lblname.Text = lblname.Text.ToLowerInvariant();
                lbldesg.Text = Session["designation"].ToString();
                lbldesg.Text = lbldesg.Text.ToLowerInvariant();
                lbldept.Text = Session["dept"].ToString();
                lbldept.Text = lbldept.Text.ToLowerInvariant();
                lblport.Text = Session["branch"].ToString();
                lblport.Text = lblport.Text.ToLowerInvariant();

                string username = Session["LoginUserName"].ToString();

                DataTable dt = new DataTable();
                dt = employee.GetEmployeeDetails(username);

                if (!(dt.Rows[0]["empphoto"].Equals(System.DBNull.Value)))
                {
                    byte[] imageBytes = ((byte[])dt.Rows[0]["empphoto"]);
                    string base64String = Convert.ToBase64String(imageBytes);
                    img_emp.ImageUrl = "data:image/png;base64," + base64String;
                    //Image3.ImageUrl = "data:image/png;base64," + base64String;
                }
                DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                }
              //  img_Logo.ImageUrl = "../images/MRnewrpt1.png";
                //if (Session["LoginDivisionId"].ToString() == "1")
                //{
                //    img_Logo.ImageUrl = "images/MR.png";
                //}
                //else if (Session["LoginDivisionId"].ToString() == "2")
                //{
                //    img_Logo.ImageUrl = "images/Synergy.jpg";
                //}
                //else if (Session["LoginDivisionId"].ToString() == "5" || Session["LoginDivisionId"].ToString() == "7")
                //{
                //    img_Logo.ImageUrl = "images/IFS.jpg";
                //}
                //else if (Session["LoginDivisionId"].ToString() == "6")
                //{
                //    img_Logo.ImageUrl = "images/leadtech.png";
                //}
               // ifrmaster.Attributes["src"] = "MainPage/CorpDocked.aspx";                
              //  Response.Redirect("../Mainpage/CorpDocked.aspx");
            }

            catch
            {
                Response.Redirect("Login.Aspx");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('Sesion Time Out. Login Again');", true);
                return;
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
            Session["iframeid"] = "Home";
            ifrmaster.Attributes["src"] = "Mainpage/CorpDocked.aspx";
        }

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
    }
}