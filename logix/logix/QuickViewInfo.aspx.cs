using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using ClosedXML.Excel;
using System.IO;
using System.Data;
using System.Text;

namespace logix
{
    public partial class QuickViewInfo : System.Web.UI.Page
    {
        string str = "";
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();

        DataTable dt7 = new DataTable();
        DataTable dt8 = new DataTable();
        DataTable dt9 = new DataTable();

        DataTable dt10 = new DataTable();
        DataTable dt11 = new DataTable();

        DataTable dt12 = new DataTable();
        DataTable dt13 = new DataTable();
        DataTable dt14 = new DataTable();
        CustomerDataAccess.RegCustomer cusobj = new CustomerDataAccess.RegCustomer();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnExcel1);
            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnExcel2);

            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                GrdInfo.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdInfo.DataBind();
                Grdbooking.DataSource = Utility.Fn_GetEmptyDataTable();
                Grdbooking.DataBind();
                DivGrdInfo.Visible = false;
            }
            if (Session["Trantype"].ToString() == "FE")
            {
                lblHead.InnerText = "Ocean Export";
            }
            else if (Session["Trantype"].ToString() == "FI")
            {
                lblHead.InnerText = "Ocean Import";
            }
            else if (Session["Trantype"].ToString() == "AE")
            {
                lblHead.InnerText = "Air Export";
            }
            else if (Session["Trantype"].ToString() == "AI")
            {
                lblHead.InnerText = "Air Import";
            }
            GetBookingStstus();
        }

        public void GetBookingStstus()
        {
            DivCount.Visible = true;
            //DivGrdInfo.Visible = false;
            Divbooking.Visible = false;
            divbtnExcel2.Visible = false;
            DataTable dtnew = new DataTable();
            DataSet ds =new DataSet();
            if (Session["Trantype"].ToString() == "FE")
            {
                ds = cusobj.GetGrdCount(Session["Trantype"].ToString(), int.Parse(Session["webgroupid"].ToString()), 1);
                if (ds.Tables.Count > 0)
                {
                    dt1 = ds.Tables[0];
                    dt2 = ds.Tables[1];
                    dt3 = ds.Tables[2];
                    dt4 = ds.Tables[3];
                    dt5 = ds.Tables[4];
                    dt6 = ds.Tables[5];
                    dt7 = ds.Tables[6];
                    dt8 = ds.Tables[7];
                    dt9 = ds.Tables[8];
                    dt10 = ds.Tables[9];
                    dt11 = ds.Tables[10];
                    dt12 = ds.Tables[11];
                    dtnew.Columns.Add("Details");
                    dtnew.Columns.Add("Status");
                    dtnew.Rows.Add();
                    dtnew.Rows[0][0] = "Booking";
                    dtnew.Rows[0][1] = ds.Tables[0].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[1][0] = "Container Picked Up";
                    dtnew.Rows[1][1] = ds.Tables[1].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[2][0] = "Customs Clearance";
                    dtnew.Rows[2][1] = ds.Tables[2].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[3][0] = "Stuffing";
                    dtnew.Rows[3][1] = ds.Tables[3].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[4][0] = "BL Confirmation";
                    dtnew.Rows[4][1] = ds.Tables[4].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[5][0] = "Departure / Sailing";
                    dtnew.Rows[5][1] = ds.Tables[5].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[6][0] = "Transhipment";
                    dtnew.Rows[6][1] = ds.Tables[6].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[7][0] = "Pre-Alert";
                    dtnew.Rows[7][1] = ds.Tables[7].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[8][0] = "Arrival";
                    dtnew.Rows[8][1] = ds.Tables[8].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[9][0] = "Destination Clearance";
                    dtnew.Rows[9][1] = ds.Tables[9].Rows.Count;
                  

                    dtnew.Rows.Add();
                    dtnew.Rows[10][0] = "POD";
                    dtnew.Rows[10][1] = ds.Tables[10].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[11][0] = "Job closed On";
                    dtnew.Rows[11][1] = ds.Tables[11].Rows.Count;
                    Grd.DataSource = dtnew;
                    Grd.DataBind();
                    ViewState["GrdCount"] = dtnew;
                    divbtnExcel1.Visible = true;
                }
                else
                {
                    dtnew.Columns.Add("Details");
                    dtnew.Columns.Add("Status");
                    dtnew.Rows.Add();
                    dtnew.Rows[0][0] = "Booking";
                    dtnew.Rows[0][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[1][0] = "Container Picked Up";
                    dtnew.Rows[1][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[2][0] = "Customs Clearance";
                    dtnew.Rows[2][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[3][0] = "Stuffing";
                    dtnew.Rows[3][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[4][0] = "BL Confirmation";
                    dtnew.Rows[4][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[5][0] = "Departure / Sailing";
                    dtnew.Rows[5][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[6][0] = "Transhipment";
                    dtnew.Rows[6][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[7][0] = "Pre-Alert";
                    dtnew.Rows[7][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[8][0] = "Arrival";
                    dtnew.Rows[8][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[9][0] = "Destination Clearance";
                    dtnew.Rows[9][1] = "";
                   

                    dtnew.Rows.Add();
                    dtnew.Rows[10][0] = "POD";
                    dtnew.Rows[10][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[11][0] = "Job closed On";
                    dtnew.Rows[11][1] = "";
                    Grd.DataSource = dtnew;
                    Grd.DataBind();
                    divbtnExcel1.Visible = false;
                    DivCount.Visible = false;
                }
            }

            else if (Session["Trantype"].ToString() == "FI")
            {
                ds = cusobj.GetGrdCount(Session["Trantype"].ToString(), int.Parse(Session["webgroupid"].ToString()), 1);
                if (ds.Tables.Count > 0)
                {
                    /*dt1 = ds.Tables[0];
                    dt2 = ds.Tables[1];
                    dt3 = ds.Tables[2];
                    dt4 = ds.Tables[3];
                    dt5 = ds.Tables[4];
                    //dt6 = ds.Tables[5];
                    //dt7 = ds.Tables[6];
                    //dt8 = ds.Tables[7];
                    //dt9 = ds.Tables[8];
                    //dt10 = ds.Tables[9];
                    //dt11 = ds.Tables[10];
                    dtnew.Columns.Add("Details");
                    dtnew.Columns.Add("Status");

                    dtnew.Rows.Add();
                    dtnew.Rows[0][0] = "Booking";
                    dtnew.Rows[0][1] = ds.Tables[0].Rows.Count;

                    //dtnew.Rows.Add();
                    //dtnew.Rows[1][0] = "Covering sent on";
                    //dtnew.Rows[1][1] = ds.Tables[1].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[1][0] = "Pre Alert Sent on";
                    dtnew.Rows[1][1] = ds.Tables[1].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[2][0] = "CAN Sent On";
                    dtnew.Rows[2][1] = ds.Tables[2].Rows.Count;

                    //dtnew.Rows.Add();
                    //dtnew.Rows[4][0] = "P2accsenton";
                    //dtnew.Rows[4][1] = ds.Tables[4].Rows.Count;

                    //dtnew.Rows.Add();
                    //dtnew.Rows[5][0] = "Chqrec on";
                    //dtnew.Rows[5][1] = ds.Tables[5].Rows.Count;

                    //dtnew.Rows.Add();
                    //dtnew.Rows[6][0] = "Line Do rec on";
                    //dtnew.Rows[6][1] = ds.Tables[6].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[3][0] = "Destuffed On";
                    dtnew.Rows[3][1] = ds.Tables[3].Rows.Count;

                    //dtnew.Rows.Add();
                    //dtnew.Rows[8][0] = "Devanningrec on";
                    //dtnew.Rows[8][1] = ds.Tables[8].Rows.Count;

                    //dtnew.Rows.Add();
                    //dtnew.Rows[9][0] = "Refundrec on";
                    //dtnew.Rows[9][1] = ds.Tables[9].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[4][0] = "DO Issue On";
                    dtnew.Rows[4][1] = ds.Tables[4].Rows.Count;


                    Grd.DataSource = dtnew;
                    Grd.DataBind();
                    ViewState["GrdCount"] = dtnew;
                    divbtnExcel1.Visible = true;

                    */




                    dt1 = ds.Tables[0];
                    dt2 = ds.Tables[1];
                    dt3 = ds.Tables[2];
                    dt4 = ds.Tables[3];
                    dt5 = ds.Tables[4];
                    dt6 = ds.Tables[5];
                    dt7 = ds.Tables[6];
                    dt8 = ds.Tables[7];
                    dt9 = ds.Tables[8];
                    dt10 = ds.Tables[9];
                    dt11 = ds.Tables[10];
                    dt12 = ds.Tables[11];
                    dt13 = ds.Tables[12];
                    dt14 = ds.Tables[13];
                    dtnew.Columns.Add("Details");
                    dtnew.Columns.Add("Status");
                    dtnew.Rows.Add();
                    dtnew.Rows[0][0] = "Booking";
                    dtnew.Rows[0][1] = ds.Tables[0].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[1][0] = "Origin Warehouse/Port";
                    dtnew.Rows[1][1] = ds.Tables[1].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[2][0] = "Draft Confirmation";
                    dtnew.Rows[2][1] = ds.Tables[2].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[3][0] = "Vessel Departure";
                    dtnew.Rows[3][1] = ds.Tables[3].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[4][0] = "Pre Alert Sent";
                    dtnew.Rows[4][1] = ds.Tables[4].Rows.Count;
                    dtnew.Rows.Add();
                    dtnew.Rows[5][0] = "Transhipment Arrival";
                    dtnew.Rows[5][1] = ds.Tables[5].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[6][0] = "Transhipment Departure";
                    dtnew.Rows[6][1] = ds.Tables[6].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[7][0] = "Vessel Arrival at POD";
                    dtnew.Rows[7][1] = ds.Tables[7].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[8][0] = "Destination CFS Arrival";
                    dtnew.Rows[8][1] = ds.Tables[8].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[9][0] = "Cargo De-stuff";
                    dtnew.Rows[9][1] = ds.Tables[9].Rows.Count;


                    dtnew.Rows.Add();
                    dtnew.Rows[10][0] = "Delivery Order Status";
                    dtnew.Rows[10][1] = ds.Tables[10].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[11][0] = "Cargo Delivery";
                    dtnew.Rows[11][1] = ds.Tables[11].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[12][0] = "Empty Container return";
                    dtnew.Rows[12][1] = ds.Tables[12].Rows.Count;

                    dtnew.Rows.Add();
                    dtnew.Rows[13][0] = "Job closed On";
                    dtnew.Rows[13][1] = ds.Tables[13].Rows.Count;

                    Grd.DataSource = dtnew;
                    Grd.DataBind();
                    ViewState["GrdCount"] = dtnew;
                    divbtnExcel1.Visible = true;
                }
                else
                {
                    dtnew.Columns.Add("Details");
                    dtnew.Columns.Add("Status");
                    dtnew.Rows.Add();
                    dtnew.Rows[0][0] = "Booking";
                    dtnew.Rows[0][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[1][0] = "Origin Warehouse/Port";
                    dtnew.Rows[1][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[2][0] = "Draft Confirmation";
                    dtnew.Rows[2][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[3][0] = "Vessel Departure";
                    dtnew.Rows[3][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[4][0] = "Pre Alert Sent";
                    dtnew.Rows[4][1] = "";
                    dtnew.Rows.Add();
                    dtnew.Rows[5][0] = "Transhipment Arrival";
                    dtnew.Rows[5][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[6][0] = "Transhipment Departure";
                    dtnew.Rows[6][1] ="";

                    dtnew.Rows.Add();
                    dtnew.Rows[7][0] = "Vessel Arrival at POD";
                    dtnew.Rows[7][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[8][0] = "Destination CFS Arrival";
                    dtnew.Rows[8][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[9][0] = "Cargo De-stuff";
                    dtnew.Rows[9][1] = "";


                    dtnew.Rows.Add();
                    dtnew.Rows[10][0] = "Delivery Order Status";
                    dtnew.Rows[10][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[11][0] = "Cargo Delivery";
                    dtnew.Rows[11][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[12][0] = "Empty Container return";
                    dtnew.Rows[12][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[13][0] = "Job closed On";
                    dtnew.Rows[13][1] = "";

                  
                    Grd.DataSource = dtnew;
                    Grd.DataBind();
                    divbtnExcel1.Visible = false;
                    DivCount.Visible = false;
                }

            }
            else if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
            {
                ds = cusobj.GetGrdCount(Session["Trantype"].ToString(), int.Parse(Session["webgroupid"].ToString()), 1);
                if (ds.Tables.Count > 0)
                {
                    if (Session["Trantype"].ToString() == "AE")
                    {
                        dt1 = ds.Tables[0];
                        dt2 = ds.Tables[1];
                        dt3 = ds.Tables[2];
                        dt4 = ds.Tables[3];
                        dt5 = ds.Tables[4];
                        dt6 = ds.Tables[5];
                        dt7 = ds.Tables[6];
                        dt8 = ds.Tables[7];
                        dt9 = ds.Tables[8];
                        dt10 = ds.Tables[9];
                        dt11 = ds.Tables[10];
                        dt12 = ds.Tables[11];

                        /*dtnew.Columns.Add("Details");
                        dtnew.Columns.Add("Status");

                        dtnew.Rows.Add();
                        dtnew.Rows[0][0] = "Booking";
                        dtnew.Rows[0][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[1][0] = "Pick Up Date";
                        dtnew.Rows[1][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[2][0] = "Nomination Received Date";
                        dtnew.Rows[2][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[3][0] = "Document Received On";
                        dtnew.Rows[3][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[4][0] = "Pre Alert Sent On";
                        dtnew.Rows[4][1] = "";


                        dtnew.Rows.Add();
                        dtnew.Rows[5][0] = "DO Issued On";
                        dtnew.Rows[5][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[6][0] = "Invoice sent On";
                        dtnew.Rows[6][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[7][0] = "Original Document sent On";
                        dtnew.Rows[7][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[8][0] = "Job closed On";
                        dtnew.Rows[8][1] = "";
                        */



                        dtnew.Columns.Add("Details");
                        dtnew.Columns.Add("Status");

                        dtnew.Rows.Add();
                        dtnew.Rows[0][0] = "Booking Confirmation On";
                        dtnew.Rows[0][1] = ds.Tables[0].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[1][0] = "Pick-up On";
                        dtnew.Rows[1][1] = ds.Tables[1].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[2][0] = "Nomination Received On";
                        dtnew.Rows[2][1] = ds.Tables[2].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[3][0] = "Clearance Process On";
                        dtnew.Rows[3][1] = ds.Tables[3].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[4][0] = "AWB Confirmation On";
                        dtnew.Rows[4][1] = ds.Tables[4].Rows.Count;


                        dtnew.Rows.Add();
                        dtnew.Rows[5][0] = "Cargo Airlines Handover Update On";
                        dtnew.Rows[5][1] = ds.Tables[5].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[6][0] = "Prealart Sent On";
                        dtnew.Rows[6][1] = ds.Tables[6].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[7][0] = "Arrival On";
                        dtnew.Rows[7][1] = ds.Tables[7].Rows.Count;



                        dtnew.Rows.Add();
                        dtnew.Rows[8][0] = "Clearance Status on";
                        dtnew.Rows[8][1] = ds.Tables[8].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[9][0] = "Delivery Update On";
                        dtnew.Rows[9][1] = ds.Tables[9].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[10][0] = "Invoice sent On";
                        dtnew.Rows[10][1] = ds.Tables[10].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[11][0] = "Job closed On";
                        dtnew.Rows[11][1] = ds.Tables[11].Rows.Count;


                        Grd.DataSource = dtnew;
                        Grd.DataBind();
                        ViewState["GrdCount"] = dtnew;
                        divbtnExcel1.Visible = true;
                    }
                    else if (Session["Trantype"].ToString() == "AI")
                    {
                        dt1 = ds.Tables[0];
                        dt2 = ds.Tables[1];
                        dt3 = ds.Tables[2];
                        dt4 = ds.Tables[3];
                        dt5 = ds.Tables[4];
                        dt6 = ds.Tables[5];
                        dt7 = ds.Tables[6];
                        dt8 = ds.Tables[7];
                        dt9 = ds.Tables[8];
                        dt10 = ds.Tables[9];
                        dt11 = ds.Tables[10];
                        dt12 = ds.Tables[11];
                        dt13 = ds.Tables[12];

                        dtnew.Columns.Add("Details");
                        dtnew.Columns.Add("Status");

                        dtnew.Rows.Add();
                        dtnew.Rows[0][0] = "Booking Confirmation On";
                        dtnew.Rows[0][1] = ds.Tables[0].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[1][0] = "Nomination Received On";
                        dtnew.Rows[1][1] = ds.Tables[1].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[2][0] = "Pick-up On";
                        dtnew.Rows[2][1] = ds.Tables[2].Rows.Count;


                        dtnew.Rows.Add();
                        dtnew.Rows[3][0] = "Warehouse Arrival On";
                        dtnew.Rows[3][1] = ds.Tables[3].Rows.Count;



                        dtnew.Rows.Add();
                        dtnew.Rows[4][0] = "AWB Confirmation On";
                        dtnew.Rows[4][1] = ds.Tables[4].Rows.Count;


                        dtnew.Rows.Add();
                        dtnew.Rows[5][0] = "Flight Schedule On";
                        dtnew.Rows[5][1] = ds.Tables[5].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[6][0] = "Prealart Sent On";
                        dtnew.Rows[6][1] = ds.Tables[6].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[7][0] = "Arrival On";
                        dtnew.Rows[7][1] = ds.Tables[7].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[8][0] = "DO Issued on";
                        dtnew.Rows[8][1] = ds.Tables[8].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[9][0] = "Clearance Status on";
                        dtnew.Rows[9][1] = ds.Tables[9].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[10][0] = "Delivery Update On";
                        dtnew.Rows[10][1] = ds.Tables[10].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[11][0] = "Invoice sent On";
                        dtnew.Rows[11][1] = ds.Tables[11].Rows.Count;

                        dtnew.Rows.Add();
                        dtnew.Rows[12][0] = "Job closed On";
                        dtnew.Rows[12][1] = ds.Tables[12].Rows.Count;




                        Grd.DataSource = dtnew;
                        Grd.DataBind();
                        ViewState["GrdCount"] = dtnew;
                        divbtnExcel1.Visible = true;
                    }
                }
                else
                {



                   /* dtnew.Columns.Add("Details");
                    dtnew.Columns.Add("Status");

                    dtnew.Rows.Add();
                    dtnew.Rows[0][0] = "Booking";
                    dtnew.Rows[0][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[1][0] = "Pick Up Date";
                    dtnew.Rows[1][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[2][0] = "Nomination Received Date";
                    dtnew.Rows[2][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[3][0] = "Document Received On";
                    dtnew.Rows[3][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[4][0] = "Pre Alert Sent On";
                    dtnew.Rows[4][1] = "";


                    dtnew.Rows.Add();
                    dtnew.Rows[5][0] = "DO Issued On";
                    dtnew.Rows[5][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[6][0] = "Invoice sent On";
                    dtnew.Rows[6][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[7][0] = "Original Document sent On";
                    dtnew.Rows[7][1] = "";

                    dtnew.Rows.Add();
                    dtnew.Rows[8][0] = "Job closed On";
                    dtnew.Rows[8][1] = "";

                    */

                    if (Session["Trantype"].ToString() == "AE")
                    {
                        dtnew.Columns.Add("Details");
                        dtnew.Columns.Add("Status");

                        dtnew.Rows.Add();
                        dtnew.Rows[0][0] = "Booking Confirmation On";
                        dtnew.Rows[0][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[1][0] = "Pick-up On";
                        dtnew.Rows[1][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[2][0] = "Nomination Received On";
                        dtnew.Rows[2][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[3][0] = "Clearance Process On";
                        dtnew.Rows[3][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[4][0] = "AWB Confirmation On";
                        dtnew.Rows[4][1] = "";


                        dtnew.Rows.Add();
                        dtnew.Rows[5][0] = "Cargo Airlines Handover Update On";
                        dtnew.Rows[5][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[6][0] = "Prealart Sent On";
                        dtnew.Rows[6][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[7][0] = "Arrival On";
                        dtnew.Rows[7][1] = "";



                        dtnew.Rows.Add();
                        dtnew.Rows[8][0] = "Clearance Status on";
                        dtnew.Rows[8][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[9][0] = "Delivery Update On";
                        dtnew.Rows[9][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[10][0] = "Invoice sent On";
                        dtnew.Rows[10][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[11][0] = "Job closed On";
                        dtnew.Rows[11][1] = "";

                    }
                    else if (Session["Trantype"].ToString() == "AI")
                    {


                        dtnew.Columns.Add("Details");
                        dtnew.Columns.Add("Status");

                        dtnew.Rows.Add();
                        dtnew.Rows[0][0] = "Booking Confirmation On";
                        dtnew.Rows[0][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[1][0] = "Nomination Received On";
                        dtnew.Rows[1][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[2][0] = "Pick-up On";
                        dtnew.Rows[2][1] = "";


                        dtnew.Rows.Add();
                        dtnew.Rows[3][0] = "Warehouse Arrival On";
                        dtnew.Rows[3][1] ="";



                        dtnew.Rows.Add();
                        dtnew.Rows[4][0] = "AWB Confirmation On";
                        dtnew.Rows[4][1] = "";


                        dtnew.Rows.Add();
                        dtnew.Rows[5][0] = "Flight Schedule On";
                        dtnew.Rows[5][1] ="";

                        dtnew.Rows.Add();
                        dtnew.Rows[6][0] = "Prealart Sent On";
                        dtnew.Rows[6][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[7][0] = "Arrival On";
                        dtnew.Rows[7][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[8][0] = "DO Issued on";
                        dtnew.Rows[8][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[9][0] = "Clearance Status on";
                        dtnew.Rows[9][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[10][0] = "Delivery Update On";
                        dtnew.Rows[10][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[11][0] = "Invoice sent On";
                        dtnew.Rows[11][1] = "";

                        dtnew.Rows.Add();
                        dtnew.Rows[12][0] = "Job closed On";
                        dtnew.Rows[12][1] ="";
                    }
                   
                }
            }



        }

        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Heading.Visible = true;
            DataSet ds = cusobj.GetGrdCount(Session["Trantype"].ToString(), int.Parse(Session["webgroupid"].ToString()), 1);
            GrdInfo.DataSource = Utility.Fn_GetEmptyDataTable();
            Grdbooking.DataSource = Utility.Fn_GetEmptyDataTable();
            if (ds.Tables.Count > 0)
            {
                int Index = Grd.SelectedRow.RowIndex;
                Heading.InnerText = Grd.Rows[Index].Cells[0].Text.ToString() + ":";
                if (Index != 1)
                {
                    lblDate1.InnerText = Grd.Rows[Index].Cells[0].Text.ToString() + ":";
                }
                else
                {
                    lblDate1.InnerText = "";
                }
                if (ds.Tables[Index].Rows.Count > 0)
                {

                    if (Session["Trantype"].ToString() == "FE")
                    {
                       





                        divbtnExcel2.Visible = true;
                        if (Grd.Rows[Index].Cells[0].Text == "Booking")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                           

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Container Picked Up")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind(); 
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Customs Clearance")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                           

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Stuffing")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                           

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "BL Confirmation")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Departure / Sailing")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                           

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Transhipment")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Pre-Alert")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Arrival")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Destination Clearance")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "POD")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Job closed On")
                        {
                          
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else
                        {
                            if (Session["Trantype"].ToString() == "FE")
                            {
                                DivGrdInfo.Visible = true;
                                Divbooking.Visible = false;
                                GrdInfo.DataSource = (DataTable)ds.Tables[Index];
                                GrdInfo.DataBind();
                                ViewState["Grdinfo"] = ds.Tables[Index];
                            }

                        }
                    }

                       
                  /*  else  if (Session["Trantype"].ToString() == "FI")
                    {
                        divbtnExcel2.Visible = true;
                        if (Grd.Rows[Index].Cells[0].Text == "Booking")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Covering sent on")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Pre Alert Sent on")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "CAN Sent on")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "P2accsenton")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Chqrec on")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Line Do rec on")
                        {
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Destuffed On")
                        {
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Devanningrec on")
                        {
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Refundrec on")
                        {
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "DO Issue On")
                        {
                            //if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                            //{
                            //    Grdbooking.Columns[3].HeaderText = "Volume";
                            //}
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else
                        {
                            if (Session["Trantype"].ToString() == "FI")
                            {
                                DivGrdInfo.Visible = true;
                                Divbooking.Visible = false;
                                GrdInfo.DataSource = (DataTable)ds.Tables[Index];
                                GrdInfo.DataBind();
                                ViewState["Grdinfo"] = ds.Tables[Index];
                            }

                        }
                    }
                        */

                    else if (Session["Trantype"].ToString() == "FI")
                    {

                        divbtnExcel2.Visible = true;
                        if (Grd.Rows[Index].Cells[0].Text == "Booking")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Origin Warehouse/Port")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Draft Confirmation")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Vessel Departure")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Pre Alert Sent")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Transhipment Arrival")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Transhipment Departure")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Vessel Arrival at POD")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Destination CFS Arrival")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Cargo De-stuff")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Delivery Order Status")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Cargo Delivery")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Empty Container return")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;


                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Job closed On")
                        {

                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else
                        {
                            if (Session["Trantype"].ToString() == "FI")
                            {
                                DivGrdInfo.Visible = true;
                                Divbooking.Visible = false;
                                GrdInfo.DataSource = (DataTable)ds.Tables[Index];
                                GrdInfo.DataBind();
                                ViewState["Grdinfo"] = ds.Tables[Index];
                            }

                        }
                    }
                    
                    else if (Session["Trantype"].ToString() == "AE")
                    {
                        divbtnExcel2.Visible = true;
                        if (Grd.Rows[Index].Cells[0].Text == "Booking Confirmation On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if (Session["Trantype"].ToString() == "AE" )
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Nomination Received On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if (Session["Trantype"].ToString() == "AE")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Pick-up On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if (Session["Trantype"].ToString() == "AE")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Clearance Process On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if (Session["Trantype"].ToString() == "AE")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "AWB Confirmation On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if (Session["Trantype"].ToString() == "AE" )
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Cargo Airlines Handover Update On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if (Session["Trantype"].ToString() == "AE")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Prealart Sent On")
                        {
                            if (Session["Trantype"].ToString() == "AE" )
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Arrival On")
                        {
                            if (Session["Trantype"].ToString() == "AE" )
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Clearance Status on")
                        {
                            if (Session["Trantype"].ToString() == "AE" )
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Delivery Update On")
                        {
                            if (Session["Trantype"].ToString() == "AE")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Invoice sent On")
                        {
                            if (Session["Trantype"].ToString() == "AE")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Job closed On")
                        {

                            if (Session["Trantype"].ToString() == "AE")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else
                        {
                            if (Session["Trantype"].ToString() == "AE")
                            {
                                DivGrdInfo.Visible = true;
                                Divbooking.Visible = false;
                                GrdInfo.DataSource = (DataTable)ds.Tables[Index];
                                GrdInfo.DataBind();
                                ViewState["Grdinfo"] = ds.Tables[Index];
                            }

                        }
                    }



                    else if (Session["Trantype"].ToString() == "AI")
                    {
                        divbtnExcel2.Visible = true;
                        if (Grd.Rows[Index].Cells[0].Text == "Booking Confirmation On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if (Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Nomination Received On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if ( Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Pick-up On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if (Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Warehouse Arrival On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if ( Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "AWB Confirmation On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if ( Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Flight Schedule On")
                        {
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            if ( Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }

                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Prealart Sent On")
                        {
                            if ( Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Arrival On")
                        {
                            if ( Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "DO Issued on")
                        {
                            if (Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Clearance Status on")
                        {
                            if (Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Delivery Update On")
                        {
                            if (Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else if (Grd.Rows[Index].Cells[0].Text == "Invoice sent On")
                        {
                            if (Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }
                        else if (Grd.Rows[Index].Cells[0].Text == "Job closed On")
                        {
                            if ( Session["Trantype"].ToString() == "AI")
                            {
                                Grdbooking.Columns[3].HeaderText = "Volume";
                            }
                            Divbooking.Visible = true;
                            DivGrdInfo.Visible = false;
                            Grdbooking.DataSource = (DataTable)ds.Tables[Index];
                            Grdbooking.DataBind();
                            ViewState["Grdinfo"] = ds.Tables[Index];
                        }

                        else
                        {
                            if ( Session["Trantype"].ToString() == "AI")
                            {
                                DivGrdInfo.Visible = true;
                                Divbooking.Visible = false;
                                GrdInfo.DataSource = (DataTable)ds.Tables[Index];
                                GrdInfo.DataBind();
                                ViewState["Grdinfo"] = ds.Tables[Index];
                            }

                        }
                    }




                }
                else
                {
                    divbtnExcel2.Visible = false;
                    if (Grd.Rows[Index].Cells[0].Text == "Booking")
                    {

                        if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                        {
                            Grdbooking.Columns[3].HeaderText = "Volume";
                        }
                        Divbooking.Visible = true;
                        DivGrdInfo.Visible = false;
                        Grdbooking.DataSource = new DataTable();
                        Grdbooking.DataBind();
                    }

                    else if (Grd.Rows[Index].Cells[0].Text == "Job closed On")
                    {
                        if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                        {
                            Grdbooking.Columns[3].HeaderText = "Volume";
                        }
                        Divbooking.Visible = true;
                        DivGrdInfo.Visible = false;
                        Grdbooking.DataSource = new DataTable();
                        Grdbooking.DataBind();
                    }
                    else
                    {
                        //if (Session["Trantype"].ToString() == "FE")
                        //{
                        Divbooking.Visible = false;
                        DivGrdInfo.Visible = false;
                        GrdInfo.DataSource = new DataTable();
                        GrdInfo.DataBind();
                        //}
                    }
                }
            }
            else
            {
                ShipmentviewClear();
            }
        }

        protected void GrdInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdInfo, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";

                }
            }
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Grd.Rows.Count > 0)
                {
                    int Index = Grd.SelectedRow.RowIndex;
                    if (Grd.Rows[Index].Cells[0].Text == "Booking")
                    {
                        GrdInfo.Columns[3].Visible = true;
                        GrdInfo.Columns[4].Visible = false;
                        GrdInfo.Columns[5].Visible = false;
                        GrdInfo.Columns[10].Visible = false;
                    }
                    else
                    {
                        GrdInfo.Columns[3].Visible = false;
                        GrdInfo.Columns[4].Visible = true;
                        GrdInfo.Columns[5].Visible = true;
                        GrdInfo.Columns[10].Visible = true;
                    }
                }
            }
        }

        protected void GrdInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = GrdInfo.SelectedRow.RowIndex;
            DataAccess.ForwardingExports.JobInfo objjobinfo = new DataAccess.ForwardingExports.JobInfo();
            DataTable ddtcon = new DataTable();
            grd_Noof_Container.DataSource = Utility.Fn_GetEmptyDataTable();
            if (GrdInfo.Rows[Index].Cells[7].Text.ToString() != "" && Convert.ToInt32(GrdInfo.Rows[Index].Cells[7].Text) != 0 && GrdInfo.Rows[Index].Cells[6].Text.ToString() != "")
            {
                ddtcon = objjobinfo.GetContainerDetails(Convert.ToInt32(GrdInfo.Rows[Index].Cells[7].Text), GrdInfo.Rows[Index].Cells[6].Text.ToString(),
                    Convert.ToInt32(GrdInfo.Rows[Index].Cells[9].Text), 1);
                if (ddtcon.Rows.Count > 0)
                {
                    this.NoOfContainer.Show();
                    SpanBookingNo.InnerText = GrdInfo.Rows[Index].Cells[1].Text.ToString();
                    SpanVesselvou.InnerHtml = GrdInfo.Rows[Index].Cells[13].Text.ToString();
                    SpanDate.InnerText = GrdInfo.Rows[Index].Cells[14].Text.ToString();
                    grd_Noof_Container.DataSource = ddtcon;
                    grd_Noof_Container.DataBind();
                    DivGrdInfo.Visible = true;
                }
                DataAccess.ForwardingExports.StuffingConfirmation STufobj = new DataAccess.ForwardingExports.StuffingConfirmation();
                int jobno = Convert.ToInt32(GrdInfo.Rows[Index].Cells[7].Text);
                string BookingNo = GrdInfo.Rows[Index].Cells[1].Text.ToString();
                int bid = Convert.ToInt32(GrdInfo.Rows[Index].Cells[9].Text);
                DataTable dt = STufobj.GetMVDetails(jobno, BookingNo, bid, 1);
                if (dt.Rows.Count > 0)
                {
                    Grd_vessel.Visible = true;
                    Grd_vessel.DataSource = dt;
                    Grd_vessel.DataBind();
                }
                else
                {
                    Grd_vessel.Visible = false;
                }
                //Response.Redirect("Default.aspx?BookingSts=" + "BookingSts" + "&BookingNo=" + SpanBookingNo.InnerText);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Job # or Blno might be Empty');", true);
                return;
            }

        }

        protected void GrdInfo_PreRender(object sender, EventArgs e)
        {
            GrdInfo.UseAccessibleHeader = true;
            GrdInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void Grdbooking_PreRender(object sender, EventArgs e)
        {
            Grdbooking.UseAccessibleHeader = true;
            Grdbooking.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void ShipmentviewClear()
        {
            //ifrmaster.Visible = false;
            Heading.Visible = false;
            divbtnExcel2.Visible = false;
        }

        protected void btnExcel1_Click(object sender, EventArgs e)
        {
           /*
            * 
            * DataTable dtexecel = new DataTable();
            if (ViewState["GrdCount"] != null)
            {
                dtexecel = (DataTable)ViewState["GrdCount"];
                if (dtexecel.Rows.Count > 0)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dtexecel, "Status");
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=Status.xlsx");
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

            */


            if (Grd.Rows.Count > 0)
            {

                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Status" + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                if (Grd.Visible == true)
                {
                    Grd.GridLines = GridLines.Both;
                    Grd.HeaderStyle.Font.Bold = true;
                    Grd.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }


        }

        protected void btnExcel2_Click(object sender, EventArgs e)
        {
         /*   DataTable dtexecel = new DataTable();
            if (ViewState["Grdinfo"] != null)
            {
                dtexecel = (DataTable)ViewState["Grdinfo"];
                dtexecel.Columns.Remove("bid");
                dtexecel.Columns.Remove("bookingno1");
                if (dtexecel.Rows.Count > 0)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dtexecel, "BookingInfo");
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=ShipmentDetails.xlsx");
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
            */


            if (Grdbooking.Rows.Count > 0)
            {
                Divbooking.Visible = true;
                Grdbooking.Visible = true;
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=ShipmentDetails" + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                if (Session["Trantype"].ToString() == "AE" || Session["Trantype"].ToString() == "AI")
                {
                    Grdbooking.Columns[3].HeaderText = "Volume";
                }

                if (Grdbooking.Visible == true)
                {
                    Grdbooking.GridLines = GridLines.Both;
                    Grdbooking.HeaderStyle.Font.Bold = true;
                    Grdbooking.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                Divbooking.Visible = false;
                Grdbooking.Visible = false;
            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

    }
}