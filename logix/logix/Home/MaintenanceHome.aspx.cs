using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace logix.Home
{
    public partial class MaintenanceHome : System.Web.UI.Page
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
        DataAccess.HR.FrontPage maintane = new DataAccess.HR.FrontPage();
        DataAccess.Masters.MasterCustomer cutobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterVessel obj_main = new DataAccess.Masters.MasterVessel();
        DataAccess.Masters.MasterExRate exrateshow = new DataAccess.Masters.MasterExRate();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterLocation obloc = new DataAccess.Masters.MasterLocation();
        DataTable dt = new DataTable();
        DataTable dtable = new DataTable();
        int branchid, divisionid, vouyear, logempid;
        string ModuleName, trantype;
        string hname;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(linkexprcustomer);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnkexpcharges);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnkexpemp);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnkexpexcelport);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnkexpexrate);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnkexploc);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnkexpvessel);


            trantype = Session["StrTranType"].ToString();
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                hrempobj.GetDataBase(Ccode);
                leftObj.GetDataBase(Ccode);
                Appobj.GetDataBase(Ccode);
                rightObj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                exrobj.GetDataBase(Ccode);
                MISObj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                maintane.GetDataBase(Ccode);
                cutobj.GetDataBase(Ccode);
                obj_main.GetDataBase(Ccode);
                exrateshow.GetDataBase(Ccode);
                obj_MasterPort.GetDataBase(Ccode);
                da_obj_chargesobj.GetDataBase(Ccode);
                obloc.GetDataBase(Ccode);



            }

            if (!IsPostBack)
            {
                getcount();
                Divcustomerdetails.Visible = false;
                divemployee.Visible = false;
                divcharges.Visible = false;
                divport.Visible = false;
                divexrate.Visible = false;
                divcityup.Visible = false;
                divvessel1.Visible = false;

          
            }

        }

        protected void link_button1_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN"||Session["StrTranType"].ToString() =="CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(131, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterCustomerNew.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(134, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterPort.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void LinkButton8_Click1(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(135, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterVessel.aspx");
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
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(255, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterExRate.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void lbl_jobclosing_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(134, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterPort.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void Quotation_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(131, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterCustomerNew.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void linkoust_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(130, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterChargesNew.aspx?type=" + 130);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void Stuffingconfirmation_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(134, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterPort.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void sailingConfirmation_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(255, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterExRate.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void Transhipment_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(135, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    //  Response.Redirect("../Maintenance/MasterAirlineShortCode.aspx");
                    Response.Redirect("../Maintenance/MasterVessel.aspx");
               
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void DORequest_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();   //1786  1787  1788s
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1695, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Maintenance/MasterCityUpdate.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void DoConfirmation_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN" || Session["StrTranType"].ToString() == "CO")
            {
                dtuser = obj_UP.GetFormwiseuserRights(795, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MN");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../HRM/HRMPersonalInformation.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
        }

        public void getcount()
        {
            //DataAccess.HR.FrontPage maintane=new DataAccess.HR.FrontPage();
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();

            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();

            DataSet ds = new DataSet();
            ds = maintane.getcountmaintenancehome();
            dt0 = ds.Tables[0];
            dt1 = ds.Tables[1];
            dt2 = ds.Tables[2];
            dt3 = ds.Tables[7];
            dt4 = ds.Tables[4];
            dt5 = ds.Tables[5];
            dt6 = ds.Tables[6];
           
            if (dt0.Rows.Count > 0)
            {
                spcust.InnerText = dt0.Rows[0][0].ToString();
            }
            else
            {
                spcust.InnerText = "0";
            }
            if (dt1.Rows.Count > 0)
            {
                spcharge.InnerText = dt1.Rows[0][0].ToString();
            }
            else
            {
                spcharge.InnerText = "0";
            }
            if (dt2.Rows.Count > 0)
            {
                spport1.InnerText = dt2.Rows[0][0].ToString();
            }
            else
            {
                spport1.InnerText = "0";
            }
            if (dt3.Rows.Count > 0)
            {
                spexrate1.InnerText = dt3.Rows[0][0].ToString();
            }
            else
            {
                spexrate1.InnerText = "0";
            }
            if (dt4.Rows.Count > 0)
            {
                spaiirlinecode.InnerText = dt4.Rows[0][0].ToString();
            }
            else
            {
                spaiirlinecode.InnerText = "0";
            }

            if (dt5.Rows.Count > 0)
            {
                spcity.InnerText = dt5.Rows[0][0].ToString();
            }
            else
            {
                spcity.InnerText = "0";
            }
            if (dt6.Rows.Count > 0)
            {
                spemp.InnerText = dt6.Rows[0][0].ToString();
            }
            else
            {
                spemp.InnerText = "0";
            }
            
            
        }

        protected void Lnt_custonmer_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = true;

            divemployee.Visible = false;
            divcharges.Visible = false;
            divport.Visible = false;
            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = false;

          
            //DataAccess.Masters.MasterCustomer cutobj = new DataAccess.Masters.MasterCustomer();


            grdcustomer.DataSource = null;
            grdcustomer.DataBind();
            DataTable dt = cutobj.sgetcustomerdetailexport();

            int cnt = 0;
            grdcustomer.DataSource = dt;
            grdcustomer.DataBind();
            ViewState["grdcustomer"] = dt;
                        
            

        }

        protected void linkexprcustomer_Click(object sender, EventArgs e)
        {
           

            Divcustomerdetails.Visible = true;

            divemployee.Visible = false;
            divcharges.Visible = false;
            divport.Visible = false;
            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = false;

            DataTable dt_check = ViewState["grdcustomer"] as DataTable;

            if (grdcustomer.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Customer.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

        }

        protected void lnkMaster_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divemployee.Visible = false;
            divcharges.Visible = false;
            divport.Visible = false;
            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = true;

            //DataAccess.Masters.MasterVessel obj_main = new DataAccess.Masters.MasterVessel();
              
            DataTable dt1 = new DataTable();
            dt1 = obj_main.SPVesselView();

            if (dt1.Rows.Count > 0)
            {
                grdvesss.DataSource = dt1;
                grdvesss.DataBind();
                ViewState["grdvessel"] = dt1;
            
            }

            
        }

        protected void lnkExrate_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divemployee.Visible = false;
            divcharges.Visible = false;
            divport.Visible = false;
            divexrate.Visible = true;
            divcityup.Visible = false;
            divvessel1.Visible = false;

            DataTable dtshow = new DataTable();
            //DataAccess.Masters.MasterExRate exrateshow = new DataAccess.Masters.MasterExRate();

            dtshow = exrateshow.ShowExRate(DateTime.Parse(Utility.fn_ConvertDate(DateTime.Now.ToString("dd/MM/yyyy")).ToString()), Convert.ToInt32(Session["LoginDivisionId"]));
            GridExrate.DataSource = dtshow;
            GridExrate.DataBind();
            ViewState["grdexrate"] = dtshow;
       
        }

        protected void lnkMasterPort_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divemployee.Visible = false;
            divcharges.Visible = false;
            divport.Visible = true;
            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = false;

            DataTable dt = new DataTable();
            //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
       
            dt = obj_MasterPort.GetPortDetails4Grid();
            if (dt.Rows.Count > 0)
            {
                grd1.DataSource = dt;
                grd1.DataBind();
            }
            else
            {
                grd1.DataSource = null;
                grd1.DataBind();
            }
            ViewState["grport"] = dt;
           
        }

        protected void lnkcharges_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divemployee.Visible = false;
            divcharges.Visible = true;
            divport.Visible = false;
            
            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = false;

            DataTable obj_dtEmp = new DataTable();


            //DataAccess.Masters.MasterCharges da_obj_chargesobj = new DataAccess.Masters.MasterCharges();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_chargesobj.ShowChargeDetailsnew();
           
            obj_dtEmp.Columns.Add("chargename");
            obj_dtEmp.Columns.Add("chargetype");
            obj_dtEmp.Columns.Add("SACCode");
            obj_dtEmp.Columns.Add("GSTP");
            DataRow dr;

            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
            {
                dr = obj_dtEmp.NewRow();
                obj_dtEmp.Rows.Add(dr);
                dr["chargename"] = obj_dt.Rows[i][0].ToString();
                dr["chargetype"] = obj_dt.Rows[i][1].ToString();
                dr["SACCode"] = obj_dt.Rows[i][2].ToString();
                dr["GSTP"] = obj_dt.Rows[i][3].ToString();

            }

            grd.DataSource = obj_dtEmp;
            grd.DataBind();
            ViewState["grdcharges"] = obj_dtEmp;
        }

        protected void lnkMasterEmployee_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;

            divemployee.Visible = true;
            DataTable dt2 = new DataTable();
            dt2 = obj_UP.empcount();
            grd_empcount.DataSource = dt2;
            grd_empcount.DataBind();
            ViewState["grdemployee"] = dt2;
            divcharges.Visible = false;
            divport.Visible = false;

            divexrate.Visible = false;

            divcityup.Visible = false;
            divvessel1.Visible = false;

        }

        protected void lnkexpemp_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divcharges.Visible = false;
            divemployee.Visible = true;
            divport.Visible = false;

            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = false;

         
            DataTable dt_check1 = ViewState["grdemployee"] as DataTable;

            if (grd_empcount.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check1);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Employee.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

        }

        protected void lnkexpcharges_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divcharges.Visible = true;
            divemployee.Visible = false;
            divport.Visible = false;

            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = false;



            DataTable dt_check2 = ViewState["grdcharges"] as DataTable;

            if (grd.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check2);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Charges.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

          
        }

        protected void lnkexpexcelport_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divcharges.Visible = false;
            divemployee.Visible = false;
            divport.Visible = true;

            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = false;

            DataTable dt_check1 = ViewState["grdport"] as DataTable;

            if (grd1.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check1);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Port.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }


        }

        protected void lnkexpexrate_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divcharges.Visible = false;
            divemployee.Visible = false;
            divport.Visible = false;

            divexrate.Visible = true;
            divcityup.Visible = false;
            divvessel1.Visible = false;

            DataTable dt_check1 = ViewState["grdexrate"] as DataTable;

            if (GridExrate.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check1);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=ExRate.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

          
        }

        protected void lnkexploc_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divemployee.Visible = false;
            divcharges.Visible = false;
            divport.Visible = false;
            divexrate.Visible = false;
            divcityup.Visible = true;
            divvessel1.Visible = false;

            DataTable dt_check1 = ViewState["grlocation"] as DataTable;

            if (grdloc.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check1);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Locations.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

          
        }

        protected void lnkCity_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divemployee.Visible = false;
            divcharges.Visible = false;
            divport.Visible = false;
            divexrate.Visible = false;
            divcityup.Visible = true;
            divvessel1.Visible = false;

            DataTable dt = new DataTable();
            //DataAccess.Masters.MasterLocation obloc = new DataAccess.Masters.MasterLocation();

            dt = obloc.GetlocationDetails4Grid();
            if (dt.Rows.Count > 0)
            {
                grdloc.DataSource = dt;
                grdloc.DataBind();
            }
            else
            {
                grdloc.DataSource = null;
                grdloc.DataBind();
            }
            ViewState["grlocation"] = dt;
           
        }

        protected void lnkexpvessel_Click(object sender, EventArgs e)
        {
            Divcustomerdetails.Visible = false;
            divemployee.Visible = false;
            divcharges.Visible = false;
            divport.Visible = false;
            divexrate.Visible = false;
            divcityup.Visible = false;
            divvessel1.Visible = true;

            DataTable dt_check1 = ViewState["grdvessel"] as DataTable;

            if (grdvesss.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check1);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Vessl.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

        }

        protected void grdcustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdcustomer.PageIndex = e.NewPageIndex;
                //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                DataTable obj_dt = new DataTable();
              //  DataAccess.Masters.MasterCustomer cutobj = new DataAccess.Masters.MasterCustomer();


                DataTable dt = cutobj.sgetcustomerdetailexport();

                int cnt = 0;
                grdcustomer.DataSource = dt;
                grdcustomer.DataBind();
                //ViewState["grdcustomer"] = dt;
            
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdcustomer_PreRender(object sender, EventArgs e)
        {
            grdcustomer.UseAccessibleHeader = true;
            grdcustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            grd.UseAccessibleHeader = true;
            grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grd1_PreRender(object sender, EventArgs e)
        {
            grd1.UseAccessibleHeader = true;
            grd1.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void GridExrate_PreRender(object sender, EventArgs e)
        {
            GridExrate.UseAccessibleHeader = true;
            GridExrate.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grdvesss_PreRender(object sender, EventArgs e)
        {
            grdvesss.UseAccessibleHeader = true;
            grdvesss.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grdloc_PreRender(object sender, EventArgs e)
        {
            grdloc.UseAccessibleHeader = true;
            grdloc.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grd_empcount_PreRender(object sender, EventArgs e)
        {
            grd_empcount.UseAccessibleHeader = true;
            grd_empcount.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

       

       }
}