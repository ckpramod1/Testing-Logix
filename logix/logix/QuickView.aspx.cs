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
using System.Net;

namespace logix
{
    public partial class QuickView : System.Web.UI.Page
    {
        //string str = "";
        //DataTable dt1 = new DataTable();
        //DataTable dt2 = new DataTable();
        //DataTable dt3 = new DataTable();
        //DataTable dt4 = new DataTable();
        //DataTable dt5 = new DataTable();
        //DataTable dt6 = new DataTable();

        //DataTable dt7 = new DataTable();
        //DataTable dt8 = new DataTable();
        //DataTable dt9 = new DataTable();

        //DataTable dt10 = new DataTable();
        //DataTable dt11 = new DataTable();

        //DataTable dt12 = new DataTable();
        //DataTable dt13 = new DataTable();
        //DataTable dt14 = new DataTable();
        CustomerDataAccess.RegCustomer cusobj = new CustomerDataAccess.RegCustomer();

        string username = "";
        string password = "";


        string ip = "";
        string dbname = "";

        protected string DBCS;
     


        protected void Page_Load(object sender, EventArgs e)
        {
           

            //if (Session["username"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            //}
            if (!IsPostBack)
            {
                RoundHeight1.Attributes["class"] = "RoundHeightn1";

                RBooking.Attributes["class"] = "Round";
                RStuffing.Attributes["class"] = "Round1";
                RSailling.Attributes["class"] = "Round2";
                RTranshipment.Attributes["class"] = "Round3";

                RDOReq.Attributes["class"] = "Round4";
                RDOCofirm.Attributes["class"] = "Round5";

                Originaldocsenton.Attributes["class"] = "Round6";

                releasedon.Attributes["class"] = "Round7";

                jodate1.Attributes["class"] = "Round8";


                Div1.Attributes["class"] = "Round9";
                Div2.Attributes["class"] = "Round10";

                Div3.Attributes["class"] = "Round11";
                //Div4.Attributes["class"] = "Round12";


                lblClear1.Visible = true;
                lbltran1.Visible = true;
                lblcargo1.Visible = true;
                lblOrig.Visible = true;

                lblrel.Visible = true;

                lbljob.Visible = true;

                lbldel1.Visible = true;

                lblDoconfirmed1.Visible = true;

                lblreleasedonon1.Visible = true;

                lbljobon1.Visible = false;


                lblbk.InnerText = "Booking";
                lblsail.InnerText = "Pick up";
                lblstuf.InnerText = "Customs Clr On";
                lblClear.InnerText = "Stuffing";
                lbltran.InnerText = "BL Confirmed On";
                lblcargo.InnerText = "Sailing";
                lblDocon.InnerText = "Transhipment";
                lblarr.InnerText = "Pre-Alert";
                lblOriginaldocsenton.InnerText = "Arrival";
                lbldel.InnerText = "Destination Clearance";

                lblDoconfirmed.InnerText = "POD";
                lblreleasedonon.InnerText = "Job closed On";

                lbljobDte.InnerText = "";

                //RoundHeight1.Attributes["class"] = "RoundHeight1";


                LblBookingDate.InnerText = "";
                LblSailingDate.InnerText = "";
                LblStuffingDate.InnerText = "";
                lblCleardate.InnerText = "";
                LblTranshipmentDate.InnerText = "";
                lblcargodate.InnerText = "";
                LblDOConfirmReqDate.InnerText = "";
                lblarrdate.InnerText = "";
                LblOriginaldocsentonDate.InnerText = "";

                lbldeldate.InnerText = "";
                LblDOConfirmedDate.InnerText = "";
                lblreleasedondate.InnerText = "";
                Div4.Visible = false;
                if (Request.QueryString.ToString().Contains("strTranType3"))
                {
                    Session["Trantype"] = Request.QueryString["strTranType3"].ToString();
                    txt_bookingno.Text = Request.QueryString["bookingno"].ToString();
                    txt_bookingno_TextChanged(sender, e);
                }

            }
           
        }
        protected void txt_bookingno_TextChanged(object sender, EventArgs e)
        {
            //if (txt_bookingno.Text.Trim().Length >= 14)
            //{
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();

            DataTable dt1 = new DataTable();
            DataTable  DtCombined;
            DataAccess.ForwardingExports.PODetails bookingtran = new DataAccess.ForwardingExports.PODetails();
            Session["Trantype"] = bookingtran.getbookingdetailsnew(txt_bookingno.Text);

           

            int shipmoved = 0;
            if (Session["Trantype"] != null)
            {

                dt1 = cusobj.SPSelshipstatus(txt_bookingno.Text, Session["Trantype"].ToString());

                if (Session["Trantype"].ToString() == "FE")
                {
                    Shipic.Visible = true;
                    Airic.Visible = false;
                    lblbk.InnerText = "Booking";
                    lblsail.InnerText = "Pick up";
                    lblstuf.InnerText = "Customs Clr On";
                    lblClear.InnerText = "Stuffing";
                    lbltran.InnerText = "BL Confirmed On";
                    lblcargo.InnerText = "Sailing";
                    lblDocon.InnerText = "Transhipment";
                    lblarr.InnerText = "Pre-Alert";
                    lblOriginaldocsenton.InnerText = "Arrival";
                    lbldel.InnerText = "Destination Clearance";

                    lblDoconfirmed.InnerText = "POD";
                    lblreleasedonon.InnerText = "Job closed On";

                    //lblOrig.Visible = false;
                    //lblrel.Visible = false;
                    //lbljob.Visible = false;

                    //Originaldocsenton.Visible = false;
                    //releasedon.Visible = false;
                    //jodate1.Visible = false;


                    lblClear1.Visible = true;
                    lbltran1.Visible = true;
                    lblcargo1.Visible = true;
                    lblOrig.Visible = true;
                    lblrel.Visible = true;

                    lbljob.Visible = true;

                    lbldel1.Visible = true;
                    lblDoconfirmed1.Visible = true;
                    lblreleasedonon1.Visible = true;
                    lbljobon1.Visible = false;

                    LblBookingDate.InnerText = "";
                    LblSailingDate.InnerText = "";
                    LblStuffingDate.InnerText = "";
                    lblCleardate.InnerText = "";
                    LblTranshipmentDate.InnerText = "";
                    lblcargodate.InnerText = "";
                    LblDOConfirmReqDate.InnerText = "";
                    lblarrdate.InnerText = "";
                    LblOriginaldocsentonDate.InnerText = "";

                    lbldeldate.InnerText = "";
                    LblDOConfirmedDate.InnerText = "";
                    lblreleasedondate.InnerText = "";

                    RoundHeight1.Attributes["class"] = "RoundHeightn1";

                    RBooking.Attributes["class"] = "Round";
                    RStuffing.Attributes["class"] = "Round1";
                    RSailling.Attributes["class"] = "Round2";
                    RTranshipment.Attributes["class"] = "Round3";

                    RDOReq.Attributes["class"] = "Round4";
                    RDOCofirm.Attributes["class"] = "Round5";




                    Originaldocsenton.Attributes["class"] = "Round6";

                    releasedon.Attributes["class"] = "Round7";

                    jodate1.Attributes["class"] = "Round8";


                    Div1.Attributes["class"] = "Round9";
                    Div2.Attributes["class"] = "Round10";

                    Div3.Attributes["class"] = "Round11";
                    //   Div4.Attributes["class"] = "Round12";



                    //lblbk.InnerText = "Booking";
                    //lblstuf.InnerText = "Stuffing";
                    //lblsail.InnerText = "Sailed";
                    //lbltran.InnerText = "Transhipped";
                    //lblDocon.InnerText = "DO Confirm Request";
                    //lblDoconfirmed.InnerText = "DO Confirmed";
                    lblbk.InnerText = "Booking";
                    lblsail.InnerText = "Pick up";
                    lblstuf.InnerText = "Customs Clr On";
                    lblClear.InnerText = "Stuffing";
                    lbltran.InnerText = "BL Confirmed On";
                    lblcargo.InnerText = "Sailing";
                    lblDocon.InnerText = "Transhipment";
                    lblarr.InnerText = "Pre-Alert";
                    lblOriginaldocsenton.InnerText = "Arrival";
                    lbldel.InnerText = "Destination Clearance";

                    lblDoconfirmed.InnerText = "POD";
                    lblreleasedonon.InnerText = "Job closed On";

                    Div4.Visible = false;
                    lbljobon1.Visible = false;
                    // RoundHeight1.Attributes["class"] = "RoundHeight1";



                   
                    
                   


                    dt = cusobj.CusloginBookingStatus(txt_bookingno.Text, Convert.ToInt32(Session["webgroupid"]), Session["Trantype"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            txt_status.Text = dt1.Rows[0]["status"].ToString();
                        }


                        dtnew.Columns.Add("Clearance");
                        dtnew.Columns.Add("Status");

                        if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";
                            dtnew.Rows.Add();
                            dtnew.Rows[0][0] = "Booking";
                            dtnew.Rows[0][1] = dt.Rows[0]["bookingdate"].ToString();
                            shipmoved = 1;
                          
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[0][0] = "Booking";
                            dtnew.Rows[0][1] = "";
                        }
                        if (dt.Rows[0]["pickedupon"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["pickedupon"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor1";
                            dtnew.Rows.Add();
                            dtnew.Rows[1][0] = "Pick up";
                            dtnew.Rows[1][1] = dt.Rows[0]["pickedupon"].ToString();
                           // lbl_pickupon.Text = dt.Rows[0]["pickedupon"].ToString();
                            shipmoved = 2;
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[1][0] = "Pick up";
                            dtnew.Rows[1][1] = "";
                            //lbl_pickupon.Text = "";
                        }
                        if (dt.Rows[0]["customdate"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["customdate"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor2";

                            dtnew.Rows.Add();
                            dtnew.Rows[2][0] = "Customs Clr On";
                            dtnew.Rows[2][1] = dt.Rows[0]["customdate"].ToString();
                            shipmoved = 3;
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[2][0] = "Customs Clr On";
                            dtnew.Rows[2][1] = "";
                        }
                        if (dt.Rows[0]["stuffsenton"].ToString() != "")
                        {
                            lblCleardate.InnerText = dt.Rows[0]["stuffsenton"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";
                            dtnew.Rows.Add();
                            dtnew.Rows[3][0] = "Stuffing";
                            dtnew.Rows[3][1] = dt.Rows[0]["stuffsenton"].ToString();
                          //  lbl_cargoloadon.Text = dt.Rows[0]["stuffsenton"].ToString();
                            shipmoved = 4;
                        }
                        else
                        {
                            lblCleardate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[3][0] = "Stuffing";
                            dtnew.Rows[3][1] = "";
                           // lbl_cargoloadon.Text = "";
                        }
                        if (dt.Rows[0]["bldate"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["bldate"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";
                            dtnew.Rows.Add();
                            dtnew.Rows[4][0] = "BL Confirmed On";
                            dtnew.Rows[4][1] = dt.Rows[0]["bldate"].ToString();
                            //lbl_doon.Text = dt.Rows[0]["bldate"].ToString();
                            shipmoved = 5;
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[4][0] = "BL Confirmed On";
                            dtnew.Rows[4][1] = "";
                           // lbl_doon.Text = "";
                        }
                        if (dt.Rows[0]["lcsenton"].ToString() != "")
                        {
                            lblcargodate.InnerText = dt.Rows[0]["lcsenton"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";
                            dtnew.Rows.Add();
                            dtnew.Rows[5][0] = "Sailing";
                            dtnew.Rows[5][1] = dt.Rows[0]["lcsenton"].ToString();
                            shipmoved = 6;
                        }
                        else
                        {
                            lblcargodate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[5][0] = "Sailing";
                            dtnew.Rows[5][1] = "";
                        }

                       

                        if (dt.Rows[0]["tssenton"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["tssenton"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";

                            dtnew.Rows.Add();
                            dtnew.Rows[6][0] = "Transhipment";
                            dtnew.Rows[6][1] = dt.Rows[0]["tssenton"].ToString();
                            shipmoved = 7;
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[6][0] = "Transhipment";
                            dtnew.Rows[6][1] = "";
                        }

                        if (dt.Rows[0]["prealertsenton"].ToString() != "")
                        {
                            lblarrdate.InnerText = dt.Rows[0]["prealertsenton"].ToString();
                            releasedon.Attributes["class"] = "Roundcolor7";
                            dtnew.Rows.Add();

                            dtnew.Rows[7][0] = "Pre-Alert";
                            dtnew.Rows[7][1] = dt.Rows[0]["prealertsenton"].ToString();

                         //   lbl_prealert.Text = dt.Rows[0]["prealertsenton"].ToString();
                            shipmoved = 8;
                        }
                        else
                        {
                            lblarrdate.InnerText = "";
                            dtnew.Rows.Add();

                            dtnew.Rows[7][0] = "Pre-Alert";
                            dtnew.Rows[7][1] = "";
                           // lbl_prealert.Text = "";
                        }

                        if (dt.Rows[0]["railoutdate"].ToString() != "")
                        {
                            LblOriginaldocsentonDate.InnerText = dt.Rows[0]["railoutdate"].ToString();
                            jodate1.Attributes["class"] = "Roundcolor8";
                            dtnew.Rows.Add();
                            dtnew.Rows[8][0] = "Arrival";
                            dtnew.Rows[8][1] = dt.Rows[0]["railoutdate"].ToString();
                           // lbl_Arrivalon.Text = dt.Rows[0]["railoutdate"].ToString();
                            shipmoved = 9;
                        }
                        else
                        {
                            LblOriginaldocsentonDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[8][0] = "Arrival";
                            dtnew.Rows[8][1] = "";
                          //  lbl_Arrivalon.Text = "";
                        }

                        if (dt.Rows[0]["cargoreceivedon"].ToString() != "")
                        {
                            lbldeldate.InnerText = dt.Rows[0]["cargoreceivedon"].ToString();
                            Div1.Attributes["class"] = "Roundcolor9";
                            dtnew.Rows.Add();
                            dtnew.Rows[9][0] = "Destination Clearance";
                            dtnew.Rows[9][1] = dt.Rows[0]["cargoreceivedon"].ToString();
                            shipmoved = 10;
                        }
                        else
                        {
                            lbldeldate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[9][0] = "Destination Clearance";
                            dtnew.Rows[9][1] = "";
                        }

                        if (dt.Rows[0]["inspectedon"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["inspectedon"].ToString();
                            Div2.Attributes["class"] = "Roundcolor10";
                            dtnew.Rows.Add();
                            dtnew.Rows[10][0] = "POD";
                            dtnew.Rows[10][1] = dt.Rows[0]["inspectedon"].ToString();
                            shipmoved = 11;
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[10][0] = "POD";
                            dtnew.Rows[10][1] = "";
                        }

                        if (dt.Rows[0]["jobclosedate"].ToString() != "")
                        {
                            lblreleasedondate.InnerText = dt.Rows[0]["jobclosedate"].ToString();
                            Div3.Attributes["class"] = "Roundcolor11";

                            dtnew.Rows.Add();
                            dtnew.Rows[11][0] = "Job closed On";
                            dtnew.Rows[11][1] = dt.Rows[0]["jobclosedate"].ToString();
                            
                            shipmoved = 12;
                        }
                        else
                        {
                            lblreleasedondate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[11][0] = "Job closed On";
                            dtnew.Rows[11][1] = "";
                        }



                        Grd.DataSource = dtnew;
                        Grd.DataBind();

                       
                        

                        DtCombined = cusobj.CustomerloginDetailsfilternewquick(Convert.ToInt32(Session["webgroupid"]), Session["Trantype"].ToString(), 1, txt_bookingno.Text, "BG");
                        if (DtCombined.Rows.Count > 0)
                        {
                            lbl_bkg.Text = DtCombined.Rows[0]["shiprefno"].ToString();
                            lbl_bkgdate.Text = DtCombined.Rows[0]["bookingdate"].ToString();
                            lbl_hbl.Text = DtCombined.Rows[0]["blno"].ToString();

                            lbl_shipper.Text = DtCombined.Rows[0]["shipper"].ToString();
                            lbl_conginee.Text = DtCombined.Rows[0]["consignee"].ToString();

                            lbl_vslvou.Text = DtCombined.Rows[0]["vessel"].ToString();

                            lbl_POL.Text = DtCombined.Rows[0]["pol"].ToString();

                            lbl_POD.Text = DtCombined.Rows[0]["Pod"].ToString();
                            lbl_FD.Text = DtCombined.Rows[0]["fd"].ToString();

                          //  lbl_shipment.Text = DtCombined.Rows[0]["shipmentstatus"].ToString();

                            lbl_cbm.Text = DtCombined.Rows[0]["cbm"].ToString();
                            lbl_grwt.Text = DtCombined.Rows[0]["grweight"].ToString();
                             lbl_ntwt.Text = DtCombined.Rows[0]["ntweight"].ToString();

                             lbl_noofpkg.Text = DtCombined.Rows[0]["noofpkgs"].ToString();
                             lbl_cont.Text = DtCombined.Rows[0]["containerno"].ToString();

                             hid_branchid.Value = DtCombined.Rows[0]["bid"].ToString();
                           // con.containerno as containerno,h.cbm as cbm,h.noofpkgs as noofpkgs ,h.grweight as grweight ,h.ntweight as ntweight
                        }
                        else
                        {
                            lbl_bkg.Text = "";
                            lbl_bkgdate.Text ="";
                            lbl_hbl.Text ="";

                            lbl_shipper.Text = "";
                            lbl_conginee.Text = "";

                            lbl_vslvou.Text = "";

                            lbl_POL.Text = "";

                            lbl_POL.Text ="";
                            lbl_POD.Text = "";
                            lbl_FD.Text = "";

                            //lbl_shipment.Text = "";

                            lbl_cbm.Text = "";
                            lbl_grwt.Text = "";
                            lbl_ntwt.Text = "";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove1FE();", true);
                        
                        }

                        Fn_FillGrid();

                        if (shipmoved == 12)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove12FE();", true);
                        }
                        else if (shipmoved == 11)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove11FE();", true);
                        }
                        else if (shipmoved == 10)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove10FE();", true);
                        }
                        else if (shipmoved == 9)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove9FE();", true);
                        }
                        else if (shipmoved == 8)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove8FE();", true);
                        }
                        else if (shipmoved == 7)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove7FE();", true);
                        }
                        else if (shipmoved == 6)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove6FE();", true);
                        }
                        else if (shipmoved == 5)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove5FE();", true);
                        }
                        else if (shipmoved == 4)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove4FE();", true);
                        }
                        else if (shipmoved == 3)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove3FE();", true);
                        }
                        else if (shipmoved == 2)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove2FE();", true);
                        }
                        else if (shipmoved == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove1FE();", true);
                        }
                    }
                    else
                    {
                        /*  LblBookingDate.InnerText = "";
                          RBooking.Attributes["class"] = "Round";
                          LblStuffingDate.InnerText = "";
                          RStuffing.Attributes["class"] = "Round1";
                          LblSailingDate.InnerText = "";
                          RSailling.Attributes["class"] = "Round2";
                          LblTranshipmentDate.InnerText = "";
                          RTranshipment.Attributes["class"] = "Round3";
                          LblDOConfirmReqDate.InnerText = "";
                          RDOReq.Attributes["class"] = "Round4";
                          LblDOConfirmedDate.InnerText = "";
                          RDOCofirm.Attributes["class"] = "Round5";

                          */

                        txt_status.Text = "";

                        LblBookingDate.InnerText = "";
                        RBooking.Attributes["class"] = "Round";

                        LblSailingDate.InnerText = "";
                        RStuffing.Attributes["class"] = "Round1";


                        LblStuffingDate.InnerText = "";


                        lblCleardate.InnerText = "";
                        RTranshipment.Attributes["class"] = "Round3";



                        LblTranshipmentDate.InnerText = "";
                        RDOReq.Attributes["class"] = "Round4";


                        lblcargodate.InnerText = "";
                        RDOCofirm.Attributes["class"] = "Round5";





                        LblDOConfirmReqDate.InnerText = "";
                        Originaldocsenton.Attributes["class"] = "Round6";



                        lblarrdate.InnerText = "";
                        releasedon.Attributes["class"] = "Round7";



                        LblOriginaldocsentonDate.InnerText = "";
                        jodate1.Attributes["class"] = "Round8";



                        lbldeldate.InnerText = "";
                        Div1.Attributes["class"] = "Round9";



                        LblDOConfirmedDate.InnerText = "";
                        Div2.Attributes["class"] = "Round10";



                        lblreleasedondate.InnerText = "";
                        Div3.Attributes["class"] = "Round11";


                        lbl_bkg.Text = "";
                        lbl_bkgdate.Text = "";
                        lbl_hbl.Text = "";

                        lbl_shipper.Text = "";
                        lbl_conginee.Text = "";

                        lbl_vslvou.Text = "";

                        lbl_POL.Text = "";

                        lbl_POL.Text = "";
                        lbl_POD.Text = "";
                        lbl_FD.Text = "";

                        //lbl_shipment.Text = "";

                        //lbl_prealert.Text = "";

                        lbl_cbm.Text = "";
                        lbl_grwt.Text = "";
                        lbl_ntwt.Text = "";


                        lbl_noofpkg.Text = "";
                        lbl_cont.Text = "";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Login Customer do not have the Booking #');", true);
                        return;
                    }
                }
                else if (Session["Trantype"].ToString() == "FI")
                {
                    /*RoundHeight1.Attributes["class"] = "RoundHeight1";
                    lblbk.InnerText = "Booking";
                    //lblstuf.InnerText = "Destuffed on";
                    //lblsail.InnerText = "Devanning Rec on";
                    //lbltran.InnerText = "Refund Rec on";
                    //lblDocon.InnerText = "DO Issued on";
                    lblstuf.InnerText = "Pre Alert send on";
                    lblsail.InnerText = "CAN Sent on";
                    lbltran.InnerText = "Destuffed on";
                    lblDocon.InnerText = "DO Issued on";
                    lblDoconfirmed.InnerText = "Job Closed On";

                    lblOrig.Visible = false;
                    lblrel.Visible = false;
                    lbljob.Visible = false;

                    Originaldocsenton.Visible = false;
                    releasedon.Visible = false;
                    jodate1.Visible = false;

                    LblBookingDate.InnerText = "";
                    LblStuffingDate.InnerText = "";
                    LblSailingDate.InnerText = "";
                    LblTranshipmentDate.InnerText = "";
                    LblDOConfirmReqDate.InnerText = "";
                    LblDOConfirmedDate.InnerText = "";
                    LblOriginaldocsentonDate.InnerText = "";
                    lblreleasedondate.InnerText = "";
                    lbljobDte.InnerText = "";


                    RBooking.Attributes["class"] = "Round";
                    RStuffing.Attributes["class"] = "Round1";
                    RSailling.Attributes["class"] = "Round2";
                    RTranshipment.Attributes["class"] = "Round3";

                    RDOReq.Attributes["class"] = "Round4";
                    RDOCofirm.Attributes["class"] = "Round5";


                    lblbk.InnerText = "Booking";
                    //lblstuf.InnerText = "Destuffed on";
                    //lblsail.InnerText = "Devanning Rec on";
                    //lbltran.InnerText = "Refund Rec on";
                    //lblDocon.InnerText = "DO Issued on";
                    lblstuf.InnerText = "Pre Alert send on";
                    lblsail.InnerText = "CAN Sent on";
                    lbltran.InnerText = "Destuffed on";
                    lblDocon.InnerText = "DO Issued on";
                    lblDoconfirmed.InnerText = "Job Closed On";
                    RoundHeight1.Attributes["class"] = "RoundHeight1";
                    lblOrig.Visible = false;
                    lblrel.Visible = false;
                    lbljob.Visible = false;
                    */
                    Shipic.Visible = true;
                    Airic.Visible = false;

                    RoundHeight1.Attributes["class"] = "RoundHeight1";

                    RBooking.Attributes["class"] = "Round";
                    RStuffing.Attributes["class"] = "Round1";
                    RSailling.Attributes["class"] = "Round2";
                    RTranshipment.Attributes["class"] = "Round3";

                    RDOReq.Attributes["class"] = "Round4";
                    RDOCofirm.Attributes["class"] = "Round5";

                    Originaldocsenton.Attributes["class"] = "Round6";

                    releasedon.Attributes["class"] = "Round7";

                    jodate1.Attributes["class"] = "Round8";


                    Div1.Attributes["class"] = "Round9";
                    Div2.Attributes["class"] = "Round10";

                    Div3.Attributes["class"] = "Round11";
                    Div4.Attributes["class"] = "Round12";
                   

                    lblClear1.Visible = true;
                    lbltran1.Visible = true;
                    lblcargo1.Visible = true;
                    lblOrig.Visible = true;

                    lblrel.Visible = true;

                    lbljob.Visible = true;

                    lbldel1.Visible = true;

                    lblDoconfirmed1.Visible = true;

                    lblreleasedonon1.Visible = true;

                    lbljobon1.Visible = true;


                    lblbk.InnerText = "Booking";
                    lblsail.InnerText = "Origin WH/Port On";
                    lblstuf.InnerText = "Draft Con On";
                    lblClear.InnerText = "Vessel Dep On";
                    lbltran.InnerText = "Pre Alert Sent On";
                    lblcargo.InnerText = "Transhipment Arrival On";
                    lblDocon.InnerText = "Transhipment Departure On";
                    lblarr.InnerText = "Vessel Arr POD On";
                    lblOriginaldocsenton.InnerText = "Destination CFS Arr On";
                    lbldel.InnerText = "Cargo De-stuff On";

                    lblDoconfirmed.InnerText = "Delivery Order Status On";
                    lblreleasedonon.InnerText = "Cargo Delivery On";

                    lbljobon.InnerText = "Empty Container Return On";

                    RoundHeight1.Attributes["class"] = "RoundHeight1";




                    LblBookingDate.InnerText = "";
                    LblSailingDate.InnerText = "";
                    LblStuffingDate.InnerText = "";
                    lblCleardate.InnerText = "";
                    LblTranshipmentDate.InnerText = "";
                    lblcargodate.InnerText = "";
                    LblDOConfirmReqDate.InnerText = "";
                    lblarrdate.InnerText = "";
                    LblOriginaldocsentonDate.InnerText = "";

                    lbldeldate.InnerText = "";
                    LblDOConfirmedDate.InnerText = "";
                    lblreleasedondate.InnerText = "";
                    lbljobDte.InnerText = "";


                    // txt_bookingno.Text = "";


                    Div4.Visible = true;
                    lbljobon1.Visible = true;



                    dt = cusobj.CusloginBookingStatus(txt_bookingno.Text, Convert.ToInt32(Session["webgroupid"]), Session["Trantype"].ToString());
                    if (dt.Rows.Count > 0)
                    {

                        if (dt1.Rows.Count > 0)
                        {
                            txt_status.Text = dt1.Rows[0]["status"].ToString();
                        }

                        dtnew.Columns.Add("Clearance");
                        dtnew.Columns.Add("Status");
                        if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";


                            dtnew.Rows.Add();
                            dtnew.Rows[0][0] = "Booking";
                            dtnew.Rows[0][1] = dt.Rows[0]["bookingdate"].ToString();

                            shipmoved = 1;
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[0][0] = "Booking";
                            dtnew.Rows[0][1] = "";
                            
                        }
                        if (dt.Rows[0]["originon"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["originon"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor1";

                            dtnew.Rows.Add();
                            dtnew.Rows[1][0] = "Origin WH/Port On";
                            dtnew.Rows[1][1] = dt.Rows[0]["originon"].ToString();

                            //lbl_pickupon.Text = dt.Rows[0]["originon"].ToString();
                            shipmoved = 2;
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[1][0] = "Origin WH/Port On";
                            dtnew.Rows[1][1] = "";
                           // lbl_pickupon.Text = "";
                        }
                        if (dt.Rows[0]["draftconfir"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["draftconfir"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor2";

                            dtnew.Rows.Add();
                            dtnew.Rows[2][0] = "Draft Con On";
                            dtnew.Rows[2][1] = dt.Rows[0]["draftconfir"].ToString();
                            shipmoved = 3;
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[2][0] = "Draft Con On";
                            dtnew.Rows[2][1] ="";
                        }
                        if (dt.Rows[0]["vesseldepar"].ToString() != "")
                        {
                            lblCleardate.InnerText = dt.Rows[0]["vesseldepar"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";


                            dtnew.Rows.Add();
                            dtnew.Rows[3][0] = "Vessel Dep On";
                            dtnew.Rows[3][1] = dt.Rows[0]["vesseldepar"].ToString();

                            shipmoved = 4;


                        }
                        else
                        {
                            lblCleardate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[3][0] = "Vessel Dep On";
                            dtnew.Rows[3][1] = "";
                        }
                        if (dt.Rows[0]["prealertsenton"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["prealertsenton"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";

                            dtnew.Rows.Add();
                            dtnew.Rows[4][0] = "Pre Alert Sent On";
                            dtnew.Rows[4][1] = dt.Rows[0]["prealertsenton"].ToString();

                           // lbl_prealert.Text = dt.Rows[0]["prealertsenton"].ToString();
                            shipmoved = 5;
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[4][0] = "Pre Alert Sent On";
                            dtnew.Rows[4][1] = "";

                           // lbl_prealert.Text = "";
                        }
                        if (dt.Rows[0]["transarrive"].ToString() != "")
                        {
                            lblcargodate.InnerText = dt.Rows[0]["transarrive"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";

                            dtnew.Rows.Add();
                            dtnew.Rows[5][0] = "Transhipment Arrival On";
                            dtnew.Rows[5][1] = dt.Rows[0]["transarrive"].ToString();

                            //lbl_Arrivalon.Text = dt.Rows[0]["transarrive"].ToString();
                            shipmoved = 6;
                        }
                        else
                        {
                            lblcargodate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[5][0] = "Transhipment Arrival On";
                            dtnew.Rows[5][1] = "";

                          //  lbl_Arrivalon.Text = "";
                        }


                        if (dt.Rows[0]["transdepart"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["transdepart"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";

                            dtnew.Rows.Add();
                            dtnew.Rows[6][0] = "Transhipment Departure On";
                            dtnew.Rows[6][1] = dt.Rows[0]["transdepart"].ToString();
                            shipmoved = 7;
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[6][0] = "Transhipment Departure On";
                            dtnew.Rows[6][1] = "";
                        }

                        if (dt.Rows[0]["vesselarrivepod"].ToString() != "")
                        {
                            lblarrdate.InnerText = dt.Rows[0]["vesselarrivepod"].ToString();
                            releasedon.Attributes["class"] = "Roundcolor7";

                            dtnew.Rows.Add();
                            dtnew.Rows[7][0] = "Vessel Arr POD On";
                            dtnew.Rows[7][1] = dt.Rows[0]["vesselarrivepod"].ToString();
                            shipmoved = 8;
                        }
                        else
                        {
                            lblarrdate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[7][0] = "Vessel Arr POD On";
                            dtnew.Rows[7][1] = "";
                        }

                        if (dt.Rows[0]["desticfsarrival"].ToString() != "")
                        {
                            LblOriginaldocsentonDate.InnerText = dt.Rows[0]["desticfsarrival"].ToString();
                            jodate1.Attributes["class"] = "Roundcolor8";

                            dtnew.Rows.Add();
                            dtnew.Rows[8][0] = "Destination CFS Arr On";
                            dtnew.Rows[8][1] = dt.Rows[0]["desticfsarrival"].ToString();
                            shipmoved = 9;
                        }
                        else
                        {
                            LblOriginaldocsentonDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[8][0] = "Destination CFS Arr On";
                            dtnew.Rows[8][1] = "";
                        }

                        if (dt.Rows[0]["cargodestuff"].ToString() != "")
                        {
                            lbldeldate.InnerText = dt.Rows[0]["cargodestuff"].ToString();
                            Div1.Attributes["class"] = "Roundcolor9";

                            dtnew.Rows.Add();
                            dtnew.Rows[9][0] = "Cargo De-stuff On";
                            dtnew.Rows[9][1] = dt.Rows[0]["cargodestuff"].ToString();

                          //  lbl_cargoloadon.Text = dt.Rows[0]["cargodestuff"].ToString();
                            shipmoved = 10;
                        }
                        else
                        {
                            lbldeldate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[9][0] = "Cargo De-stuff On";
                            dtnew.Rows[9][1] = "";

                            //lbl_cargoloadon.Text = "";
                        }

                        if (dt.Rows[0]["deliorderstatus"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["deliorderstatus"].ToString();
                            Div2.Attributes["class"] = "Roundcolor10";


                            dtnew.Rows.Add();
                            dtnew.Rows[10][0] = "Delivery Order Status On";
                            dtnew.Rows[10][1] = dt.Rows[0]["deliorderstatus"].ToString();

                          //  lbl_doon.Text = dt.Rows[0]["deliorderstatus"].ToString();
                            shipmoved = 11;
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[10][0] = "Delivery Order Status On";
                            dtnew.Rows[10][1] = "";

                            //lbl_doon.Text = "";
                        }

                        if (dt.Rows[0]["cargodeli"].ToString() != "")
                        {
                            lblreleasedondate.InnerText = dt.Rows[0]["cargodeli"].ToString();
                            Div3.Attributes["class"] = "Roundcolor11";

                            dtnew.Rows.Add();
                            dtnew.Rows[11][0] = "Cargo Delivery On";
                            dtnew.Rows[11][1] = dt.Rows[0]["cargodeli"].ToString();
                            shipmoved = 12;
                        }
                        else
                        {
                            lblreleasedondate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[11][0] = "Cargo Delivery On";
                            dtnew.Rows[11][1] = "";
                        }

                        if (dt.Rows[0]["empcontreturn"].ToString() != "")
                        {
                            lbljobDte.InnerText = dt.Rows[0]["empcontreturn"].ToString();
                            Div4.Attributes["class"] = "Roundcolor12";

                            dtnew.Rows.Add();
                            dtnew.Rows[12][0] = "Empty Container Return On";
                            dtnew.Rows[12][1] = dt.Rows[0]["empcontreturn"].ToString();
                            shipmoved = 13;
                        }
                        else
                        {
                            lbljobDte.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[12][0] = "Empty Container Return On";
                            dtnew.Rows[12][1] = "";
                        }
                        Grd.DataSource = dtnew;
                        Grd.DataBind();

                        if (Request.QueryString.ToString().Contains("status"))
                        {
                            string status1 = "";
                            status1 = Request.QueryString["status"].ToString();
                             

                            if (status1== "Closed")
                            {
                                shipmoved = 14;
                            }

                        }

                        DtCombined = cusobj.CustomerloginDetailsfilternewquick(Convert.ToInt32(Session["webgroupid"]), Session["Trantype"].ToString(), 1, txt_bookingno.Text, "BG");
                        if (DtCombined.Rows.Count > 0)
                        {
                           /* lbl_bkg.Text = DtCombined.Rows[0][0].ToString();
                            lbl_bkgdate.Text = DtCombined.Rows[0][1].ToString();
                            lbl_hbl.Text = DtCombined.Rows[0][4].ToString();

                            lbl_shipper.Text = DtCombined.Rows[0][6].ToString();
                            lbl_conginee.Text = DtCombined.Rows[0][7].ToString();

                            lbl_vslvou.Text = DtCombined.Rows[0][16].ToString();

                            lbl_POL.Text = DtCombined.Rows[0][13].ToString();

                            lbl_POD.Text = DtCombined.Rows[0][14].ToString();
                            lbl_FD.Text = DtCombined.Rows[0][15].ToString();

                            lbl_shipment.Text = DtCombined.Rows[0][21].ToString();
                            */


                            lbl_bkg.Text = DtCombined.Rows[0]["shiprefno"].ToString();
                            lbl_bkgdate.Text = DtCombined.Rows[0]["bookingdate"].ToString();
                            lbl_hbl.Text = DtCombined.Rows[0]["blno"].ToString();

                            lbl_shipper.Text = DtCombined.Rows[0]["shipper"].ToString();
                            lbl_conginee.Text = DtCombined.Rows[0]["consignee"].ToString();

                            lbl_vslvou.Text = DtCombined.Rows[0]["vessel"].ToString();

                            lbl_POL.Text = DtCombined.Rows[0]["pol"].ToString();

                            lbl_POD.Text = DtCombined.Rows[0]["Pod"].ToString();
                            lbl_FD.Text = DtCombined.Rows[0]["fd"].ToString();

                         //   lbl_shipment.Text = DtCombined.Rows[0]["shipmentstatus"].ToString();



                            lbl_cbm.Text = DtCombined.Rows[0]["cbm"].ToString();
                            lbl_grwt.Text = DtCombined.Rows[0]["grweight"].ToString();
                            lbl_ntwt.Text = DtCombined.Rows[0]["ntweight"].ToString();


                            lbl_noofpkg.Text = DtCombined.Rows[0]["noofpkgs"].ToString();
                            lbl_cont.Text = DtCombined.Rows[0]["containerno"].ToString();
                            hid_branchid.Value = DtCombined.Rows[0]["bid"].ToString();
                        }
                        else
                        {
                            lbl_bkg.Text = "";
                            lbl_bkgdate.Text = "";
                            lbl_hbl.Text = "";

                            lbl_shipper.Text = "";
                            lbl_conginee.Text = "";

                            lbl_vslvou.Text = "";

                            lbl_POL.Text = "";

                            lbl_POL.Text = "";
                            lbl_POD.Text = "";
                            lbl_FD.Text = "";

                           // lbl_shipment.Text = "";

                            lbl_cbm.Text = "";
                            lbl_grwt.Text = "";
                            lbl_ntwt.Text = "";

                        }

                        Fn_FillGrid();


                        if (shipmoved == 14)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove14FI();", true);
                        }
                        else  if (shipmoved == 13)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove13FI();", true);
                        }

                        else if (shipmoved == 12)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove12FI();", true);
                        }
                        else if (shipmoved == 11)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove11FI();", true);
                        }
                        else if (shipmoved == 10)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove10FI();", true);
                        }
                        else if (shipmoved == 9)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove9FI();", true);
                        }
                        else if (shipmoved == 8)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove8FI();", true);
                        }
                        else if (shipmoved == 7)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove7FI();", true);
                        }
                        else if (shipmoved == 6)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove6FI();", true);
                        }
                        else if (shipmoved == 5)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove5FI();", true);
                        }
                        else if (shipmoved == 4)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove4FI();", true);
                        }
                        else if (shipmoved == 3)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove3FI();", true);
                        }
                        else if (shipmoved == 2)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove2FI();", true);
                        }
                        else if (shipmoved == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove1FI();", true);
                        }

                    }
                    else
                    {
                        /* LblBookingDate.InnerText = "";
                         RBooking.Attributes["class"] = "Round";
                         LblStuffingDate.InnerText = "";
                         RStuffing.Attributes["class"] = "Round1";
                         LblSailingDate.InnerText = "";
                         RSailling.Attributes["class"] = "Round2";
                         LblTranshipmentDate.InnerText = "";
                         RTranshipment.Attributes["class"] = "Round3";
                         LblDOConfirmReqDate.InnerText = "";
                         RDOReq.Attributes["class"] = "Round4";
                         LblDOConfirmedDate.InnerText = "";
                         RDOCofirm.Attributes["class"] = "Round5";*/



                        txt_status.Text = "";

                        LblBookingDate.InnerText = "";
                        RBooking.Attributes["class"] = "Round";


                        LblSailingDate.InnerText = "";
                        RStuffing.Attributes["class"] = "Round1";


                        LblStuffingDate.InnerText = "";
                        RSailling.Attributes["class"] = "Round2";


                        lblCleardate.InnerText = "";
                        RTranshipment.Attributes["class"] = "Round3";


                        LblTranshipmentDate.InnerText = "";
                        RDOReq.Attributes["class"] = "Round4";


                        lblcargodate.InnerText = "";
                        RDOCofirm.Attributes["class"] = "Round5";




                        LblDOConfirmReqDate.InnerText = "";
                        Originaldocsenton.Attributes["class"] = "Round6";



                        lblarrdate.InnerText = "";
                        releasedon.Attributes["class"] = "Round7";



                        LblOriginaldocsentonDate.InnerText = "";
                        jodate1.Attributes["class"] = "Round8";



                        lbldeldate.InnerText = "";
                        Div1.Attributes["class"] = "Round9";



                        LblDOConfirmedDate.InnerText = "";
                        Div2.Attributes["class"] = "Round10";



                        lblreleasedondate.InnerText = "";
                        Div3.Attributes["class"] = "Round11";



                        lbljobDte.InnerText = "";
                        Div4.Attributes["class"] = "Round12";


                        lbl_bkg.Text = "";
                        lbl_bkgdate.Text = "";
                        lbl_hbl.Text = "";

                        lbl_shipper.Text = "";
                        lbl_conginee.Text = "";

                        lbl_vslvou.Text = "";

                        lbl_POL.Text = "";

                        lbl_POL.Text = "";
                        lbl_POD.Text = "";
                        lbl_FD.Text = "";

                        //lbl_shipment.Text = "";
                        //lbl_pickupon.Text ="";

                        //lbl_doon.Text ="";
                        //lbl_Arrivalon.Text = "";

                        //lbl_cargoloadon.Text ="";

                        //lbl_prealert.Text = "";

                        lbl_cbm.Text = "";
                        lbl_grwt.Text ="";
                        lbl_ntwt.Text = "";


                        lbl_noofpkg.Text = "";
                        lbl_cont.Text = "";

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Login Customer do not have the Booking #');", true);
                        return;
                    }
                }
                else if (Session["Trantype"].ToString() == "AE")
                {
                    /*  lblbk.InnerText = "Booking";
                      lblstuf.InnerText = "Nom Rec On";
                      lblsail.InnerText = "Pickupon";
                      lbltran.InnerText = "AWB Con On";
                      lblDocon.InnerText = "Pre Alert sent on";
                      lblDoconfirmed.InnerText = "Invoice Sent on";
                      RoundHeight1.Attributes["class"] = "RoundHeight";

                      lblOriginaldocsenton.InnerText = "Clearance Status on";
                      lblOrig.Visible = true;

                      lblreleasedonon.InnerText = "Do issued On";
                      lblrel.Visible = true;


                      lbljobon.InnerText = "Job closed On";
                      lbljob.Visible = true;



                      lblbk.InnerText = "Booking";
                      lblstuf.InnerText = "Nom Rec On";
                      lblsail.InnerText = "Pickupon";
                      lbltran.InnerText = "AWB Con On";
                      lblDocon.InnerText = "Pre Alert sent on";
                      lblDoconfirmed.InnerText = "Invoice Sent on";
                      RoundHeight1.Attributes["class"] = "RoundHeight";
                      lblOrig.Visible = true;
                      lblOriginaldocsenton.InnerText = "Clearance Status on";

                      lblrel.Visible = true;
                      lblreleasedonon.InnerText = "Do issued On";


                      lbljob.Visible = true;
                      lbljobon.InnerText = "Job closed On";


                      Originaldocsenton.Visible = true;
                      releasedon.Visible = true;
                      jodate1.Visible = true;

                      LblBookingDate.InnerText = "";
                      LblStuffingDate.InnerText = "";
                      LblSailingDate.InnerText = "";
                      LblTranshipmentDate.InnerText = "";
                      LblDOConfirmReqDate.InnerText = "";
                      LblDOConfirmedDate.InnerText = "";
                      LblOriginaldocsentonDate.InnerText = "";
                      lblreleasedondate.InnerText = "";
                      lbljobDte.InnerText = "";




                      RBooking.Attributes["class"] = "Round";
                      RStuffing.Attributes["class"] = "Round1";
                      RSailling.Attributes["class"] = "Round2";
                      RTranshipment.Attributes["class"] = "Round3";

                      RDOReq.Attributes["class"] = "Round4";
                      RDOCofirm.Attributes["class"] = "Round5";

                      Originaldocsenton.Attributes["class"] = "Round6";

                      releasedon.Attributes["class"] = "Round7";

                      jodate1.Attributes["class"] = "Round8";


                      */

                    Airic.Visible = true;
                    Shipic.Visible = false;

                    lblbk.InnerText = "Booking";
                    lblstuf.InnerText = "Nom Rec On";
                    lblsail.InnerText = "Pickupon";
                    lbltran.InnerText = "AWB Con On";
                    lblDocon.InnerText = "Pre Alert sent on";
                    lblDoconfirmed.InnerText = "Invoice Sent on";
                    RoundHeight1.Attributes["class"] = "RoundHeight";
                    lblOrig.Visible = true;
                    lblOriginaldocsenton.InnerText = "Clearance Status on";
                    lblrel.Visible = true;
                    lblreleasedonon.InnerText = "Do issued On";

                    lbljob.Visible = true;
                    lbljobon.InnerText = "Job closed On";

                    Originaldocsenton.Visible = true;
                    releasedon.Visible = true;
                    jodate1.Visible = true;
                    lbltran1.Visible = true;

                    lblClear1.Visible = true;
                    lblClear.InnerText = "Clearance Pro On";
                    lblCleardate.InnerText = "";

                    lblcargo1.Visible = true;
                    lblcargo.InnerText = "Cargo Air On";
                    lblcargodate.InnerText = "";

                    lblrel.Visible = true;
                    lblarr.InnerText = "Arrival On";
                    lblarrdate.InnerText = "";

                    lbljob.Visible = true;


                    lbldel1.Visible = true;
                    lbldel.InnerText = "Delivery Update On";
                    lbldeldate.InnerText = "";

                    lblDoconfirmed1.Visible = true;

                    lblreleasedonon1.Visible = true;

                    lbljobon1.Visible = true;


                    LblBookingDate.InnerText = "";
                    LblStuffingDate.InnerText = "";
                    LblSailingDate.InnerText = "";
                    LblTranshipmentDate.InnerText = "";
                    LblDOConfirmReqDate.InnerText = "";
                    LblDOConfirmedDate.InnerText = "";
                    LblOriginaldocsentonDate.InnerText = "";
                    lblreleasedondate.InnerText = "";
                    lbljobDte.InnerText = "";

                    //txt_bookingno.Text = "";


                    RBooking.Attributes["class"] = "Round";
                    RStuffing.Attributes["class"] = "Round1";
                    RSailling.Attributes["class"] = "Round2";
                    RTranshipment.Attributes["class"] = "Round3";

                    RDOReq.Attributes["class"] = "Round4";
                    RDOCofirm.Attributes["class"] = "Round5";

                    Originaldocsenton.Attributes["class"] = "Round6";

                    releasedon.Attributes["class"] = "Round7";

                    jodate1.Attributes["class"] = "Round8";


                    Div1.Attributes["class"] = "Round9";
                    Div2.Attributes["class"] = "Round10";

                    Div3.Attributes["class"] = "Round11";
                    Div4.Attributes["class"] = "Round12";
                    Div4.Visible = true;

                    dt = cusobj.CusloginBookingStatus(txt_bookingno.Text, Convert.ToInt32(Session["webgroupid"]), Session["Trantype"].ToString());
                    if (dt.Rows.Count > 0)
                    {

                        if (dt1.Rows.Count > 0)
                        {
                            txt_status.Text = dt1.Rows[0]["status"].ToString();
                        }

                        dtnew.Columns.Add("Clearance");
                        dtnew.Columns.Add("Status");
                        if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";
                            dtnew.Rows.Add();
                            dtnew.Rows[0][0] = "Booking";
                            dtnew.Rows[0][1] = dt.Rows[0]["bookingdate"].ToString();
                            shipmoved = 1;
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[0][0] = "Booking";
                            dtnew.Rows[0][1] = "";
                        }
                        if (dt.Rows[0]["Nomrecon"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["Nomrecon"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor1";

                            dtnew.Rows.Add();
                            dtnew.Rows[1][0] = "Nom Rec On";
                            dtnew.Rows[1][1] = dt.Rows[0]["Nomrecon"].ToString();
                            shipmoved = 2;
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[1][0] = "Nom Rec On";
                            dtnew.Rows[1][1] = "";
                        }
                        if (dt.Rows[0]["Pickupon"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["Pickupon"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor2";

                         //   lbl_pickupon.Text = dt.Rows[0]["Pickupon"].ToString();


                            dtnew.Rows.Add();
                            dtnew.Rows[2][0] = "Pickupon";
                            dtnew.Rows[2][1] = dt.Rows[0]["Pickupon"].ToString();
                            shipmoved = 3;
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";

                          //  lbl_pickupon.Text = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[2][0] = "Pickupon";
                            dtnew.Rows[2][1] ="";
                        }


                        if (dt.Rows[0]["flightdate"].ToString() != "")
                        {
                            lblCleardate.InnerText = dt.Rows[0]["flightdate"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";

                            dtnew.Rows.Add();
                            dtnew.Rows[3][0] = "Clearance Pro On";
                            dtnew.Rows[3][1] = dt.Rows[0]["flightdate"].ToString();
                            shipmoved = 4;
                        }
                        else
                        {
                            lblCleardate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[3][0] = "Clearance Pro On";
                            dtnew.Rows[3][1] ="";
                        }


                        if (dt.Rows[0]["docrecon"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["docrecon"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";

                            dtnew.Rows.Add();
                            dtnew.Rows[4][0] = "AWB Con On";
                            dtnew.Rows[4][1] = dt.Rows[0]["docrecon"].ToString();
                            shipmoved = 5;
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[4][0] = "AWB Con On";
                            dtnew.Rows[4][1] = "";
                        }

                        if (dt.Rows[0]["warehousearron"].ToString() != "")
                        {
                            lblcargodate.InnerText = dt.Rows[0]["warehousearron"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";

                            dtnew.Rows.Add();
                            dtnew.Rows[5][0] = "Cargo Air On";
                            dtnew.Rows[5][1] = dt.Rows[0]["warehousearron"].ToString();
                            shipmoved = 6;
                        }
                        else
                        {
                            lblcargodate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[5][0] = "Cargo Air On";
                            dtnew.Rows[5][1] = "";
                        }


                        if (dt.Rows[0]["prealsenton"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["prealsenton"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";

                          //  lbl_prealert.Text = dt.Rows[0]["prealsenton"].ToString();

                            dtnew.Rows.Add();
                            dtnew.Rows[6][0] = "Pre Alert sent on";
                            dtnew.Rows[6][1] = dt.Rows[0]["prealsenton"].ToString();
                            shipmoved = 7;
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";

                          //  lbl_prealert.Text = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[6][0] = "Pre Alert sent on";
                            dtnew.Rows[6][1] = "";
                        }

                        if (dt.Rows[0]["arrivalon"].ToString() != "")
                        {
                            lblarrdate.InnerText = dt.Rows[0]["arrivalon"].ToString();
                            releasedon.Attributes["class"] = "Roundcolor7";

                          //  lbl_Arrivalon.Text = dt.Rows[0]["arrivalon"].ToString();

                            dtnew.Rows.Add();
                            dtnew.Rows[7][0] = "Arrival On";
                            dtnew.Rows[7][1] = dt.Rows[0]["arrivalon"].ToString();
                            shipmoved = 8;
                        }
                        else
                        {
                            lblarrdate.InnerText = "";

                         //   lbl_Arrivalon.Text = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[7][0] = "Arrival On";
                            dtnew.Rows[7][1] = "";
                        }


                        if (dt.Rows[0]["Originaldocsenton"].ToString() != "")
                        {
                            LblOriginaldocsentonDate.InnerText = dt.Rows[0]["Originaldocsenton"].ToString();
                            jodate1.Attributes["class"] = "Roundcolor8";

                            dtnew.Rows.Add();
                            dtnew.Rows[8][0] = "Clearance Status on";
                            dtnew.Rows[8][1] = dt.Rows[0]["Originaldocsenton"].ToString();
                            shipmoved = 9;
                        }
                        else
                        {
                            LblOriginaldocsentonDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[8][0] = "Clearance Status on";
                            dtnew.Rows[8][1] = "";
                        }


                        if (dt.Rows[0]["deliveryupdon"].ToString() != "")
                        {
                            lbldeldate.InnerText = dt.Rows[0]["deliveryupdon"].ToString();
                            Div1.Attributes["class"] = "Roundcolor9";

                        //    lbl_cargoloadon.Text = dt.Rows[0]["deliveryupdon"].ToString();

                            dtnew.Rows.Add();
                            dtnew.Rows[9][0] = "Delivery Update On";
                            dtnew.Rows[9][1] = dt.Rows[0]["deliveryupdon"].ToString();
                            shipmoved = 10;
                        }
                        else
                        {
                            lbldeldate.InnerText = "";
                           // lbl_cargoloadon.Text = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[9][0] = "Delivery Update On";
                            dtnew.Rows[9][1] = "";
                        }



                        if (dt.Rows[0]["invoicesenton"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["invoicesenton"].ToString();
                            Div2.Attributes["class"] = "Roundcolor10";

                            dtnew.Rows.Add();
                            dtnew.Rows[10][0] = "Invoice Sent on";
                            dtnew.Rows[10][1] = dt.Rows[0]["invoicesenton"].ToString();
                            shipmoved = 11;
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[10][0] = "Invoice Sent on";
                            dtnew.Rows[10][1] = "";
                        }




                        if (dt.Rows[0]["releasedon"].ToString() != "")
                        {
                            lblreleasedondate.InnerText = dt.Rows[0]["releasedon"].ToString();
                            Div3.Attributes["class"] = "Roundcolor11";

                        //    lbl_doon.Text = dt.Rows[0]["releasedon"].ToString();

                            LblDOConfirmedDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[11][0] = "Do issued On";
                            dtnew.Rows[11][1] = dt.Rows[0]["releasedon"].ToString();
                            shipmoved = 12;
                        }
                        else
                        {
                            lblreleasedondate.InnerText = "";

                           // lbl_doon.Text = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[11][0] = "Do issued On";
                            dtnew.Rows[11][1] = "";
                        }

                        if (dt.Rows[0]["jobdate"].ToString() != "")
                        {
                            lbljobDte.InnerText = dt.Rows[0]["jobdate"].ToString();
                            Div4.Attributes["class"] = "Roundcolor12";

                            dtnew.Rows.Add();
                            dtnew.Rows[12][0] = "Job closed On";
                            dtnew.Rows[12][1] = dt.Rows[0]["jobdate"].ToString();
                            shipmoved = 13;
                        }
                        else
                        {
                            lbljobDte.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[12][0] = "Job closed On";
                            dtnew.Rows[12][1] = "";
                        }

                        Grd.DataSource = dtnew;
                        Grd.DataBind();

                        DtCombined = cusobj.CustomerloginDetailsfilternewquick(Convert.ToInt32(Session["webgroupid"]), Session["Trantype"].ToString(), 1, txt_bookingno.Text, "BG");
                        if (DtCombined.Rows.Count > 0)
                        {
                           /* lbl_bkg.Text = DtCombined.Rows[0][0].ToString();
                            lbl_bkgdate.Text = DtCombined.Rows[0][1].ToString();
                            lbl_hbl.Text = DtCombined.Rows[0][4].ToString();

                            lbl_shipper.Text = DtCombined.Rows[0][6].ToString();
                            lbl_conginee.Text = DtCombined.Rows[0][7].ToString();

                            lbl_vslvou.Text = DtCombined.Rows[0][16].ToString();

                            lbl_POL.Text = DtCombined.Rows[0][13].ToString();

                            lbl_POD.Text = DtCombined.Rows[0][14].ToString();
                            lbl_FD.Text = DtCombined.Rows[0][15].ToString();

                            lbl_shipment.Text = DtCombined.Rows[0][21].ToString();*/



                            lbl_bkg.Text = DtCombined.Rows[0]["shiprefno"].ToString();
                            lbl_bkgdate.Text = DtCombined.Rows[0]["bookingdate"].ToString();
                            lbl_hbl.Text = DtCombined.Rows[0]["blno"].ToString();

                            lbl_shipper.Text = DtCombined.Rows[0]["shipper"].ToString();
                            lbl_conginee.Text = DtCombined.Rows[0]["consignee"].ToString();

                            lbl_vslvou.Text = DtCombined.Rows[0]["vessel"].ToString();

                            lbl_POL.Text = DtCombined.Rows[0]["pol"].ToString();

                            lbl_POD.Text = DtCombined.Rows[0]["Pod"].ToString();
                            lbl_FD.Text = DtCombined.Rows[0]["fd"].ToString();

                        //    lbl_shipment.Text = DtCombined.Rows[0]["shipmentstatus"].ToString();

                            lbl_cbm.Text = DtCombined.Rows[0]["cbm"].ToString();
                            lbl_grwt.Text = DtCombined.Rows[0]["grweight"].ToString();
                            lbl_ntwt.Text = DtCombined.Rows[0]["ntweight"].ToString();


                            lbl_noofpkg.Text = DtCombined.Rows[0]["noofpkgs"].ToString();
                            lbl_cont.Text = DtCombined.Rows[0]["containerno"].ToString();
                            hid_branchid.Value = DtCombined.Rows[0]["bid"].ToString();

                        }
                        else
                        {
                            lbl_bkg.Text = "";
                            lbl_bkgdate.Text = "";
                            lbl_hbl.Text = "";

                            lbl_shipper.Text = "";
                            lbl_conginee.Text = "";

                            lbl_vslvou.Text = "";

                            lbl_POL.Text = "";

                            lbl_POL.Text = "";
                            lbl_POD.Text = "";
                            lbl_FD.Text = "";

                           // lbl_shipment.Text = "";

                            lbl_cbm.Text = "";
                            lbl_grwt.Text = "";
                            lbl_ntwt.Text = "";


                            lbl_noofpkg.Text = "";
                            lbl_cont.Text = "";

                        }
                        Fn_FillGrid();

                        if (shipmoved == 13)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove13AE();", true);
                        }

                        else if (shipmoved == 12)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove12AE();", true);
                        }
                        else if (shipmoved == 11)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove11AE();", true);
                        }
                        else if (shipmoved == 10)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove10AE();", true);
                        }
                        else if (shipmoved == 9)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove9AE();", true);
                        }
                        else if (shipmoved == 8)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove8AE();", true);
                        }
                        else if (shipmoved == 7)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove7AE();", true);
                        }
                        else if (shipmoved == 6)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove6AE();", true);
                        }
                        else if (shipmoved == 5)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove5AE();", true);
                        }
                        else if (shipmoved == 4)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove4AE();", true);
                        }
                        else if (shipmoved == 3)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove3AE();", true);
                        }
                        else if (shipmoved == 2)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove2AE();", true);
                        }
                        else if (shipmoved == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove1AE();", true);
                        }


                    }
                    else
                    {




                        /*  LblBookingDate.InnerText = "";
                          RBooking.Attributes["class"] = "Round";
                          LblStuffingDate.InnerText = "";
                          RStuffing.Attributes["class"] = "Round1";
                          LblSailingDate.InnerText = "";
                          RSailling.Attributes["class"] = "Round2";
                          LblTranshipmentDate.InnerText = "";
                          RTranshipment.Attributes["class"] = "Round3";
                          LblDOConfirmReqDate.InnerText = "";
                          RDOReq.Attributes["class"] = "Round4";
                          LblDOConfirmedDate.InnerText = "";
                          RDOCofirm.Attributes["class"] = "Round5";
                          LblOriginaldocsentonDate.InnerText = "";
                          Originaldocsenton.Attributes["class"] = "Round6";
                          lblreleasedondate.InnerText = "";
                          releasedon.Attributes["class"] = "Round7";
                          lbljobDte.InnerText = "";
                          jodate1.Attributes["class"] = "Round8";
                          */


                        txt_status.Text = "";

                        LblBookingDate.InnerText = "";
                        RBooking.Attributes["class"] = "Round";

                        LblStuffingDate.InnerText = "";
                        RStuffing.Attributes["class"] = "Round1";

                        LblSailingDate.InnerText = "";
                        RSailling.Attributes["class"] = "Round2";

                        lblCleardate.InnerText = "";
                        RTranshipment.Attributes["class"] = "Round3";

                        LblTranshipmentDate.InnerText = "";
                        RDOReq.Attributes["class"] = "Round4";


                        lblcargodate.InnerText = "";
                        RDOCofirm.Attributes["class"] = "Round5";

                        LblDOConfirmReqDate.InnerText = "";
                        Originaldocsenton.Attributes["class"] = "Round6";


                        lblarrdate.InnerText = "";
                        releasedon.Attributes["class"] = "Round7";



                        LblOriginaldocsentonDate.InnerText = "";
                        jodate1.Attributes["class"] = "Round8";


                        lbldeldate.InnerText = "";
                        Div1.Attributes["class"] = "Round9";



                        LblDOConfirmedDate.InnerText = "";
                        Div2.Attributes["class"] = "Round10";


                        lblreleasedondate.InnerText = "";
                        Div3.Attributes["class"] = "Round11";


                        lbljobDte.InnerText = "";
                        Div4.Attributes["class"] = "Round12";



                        lbl_bkg.Text = "";
                        lbl_bkgdate.Text = "";
                        lbl_hbl.Text = "";

                        lbl_shipper.Text = "";
                        lbl_conginee.Text = "";

                        lbl_vslvou.Text = "";

                        lbl_POL.Text = "";

                        lbl_POL.Text = "";
                        lbl_POD.Text = "";
                        lbl_FD.Text = "";

                        //lbl_shipment.Text = "";

                        //lbl_pickupon.Text = "";

                        //lbl_doon.Text = "";

                        //lbl_Arrivalon.Text = "";

                        //lbl_cargoloadon.Text = "";

                        //lbl_prealert.Text = "";

                        lbl_cbm.Text = "";
                        lbl_grwt.Text = "";
                        lbl_ntwt.Text = "";


                        lbl_noofpkg.Text = "";
                        lbl_cont.Text = "";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Login Customer do not have the Booking #');", true);
                        return;
                    }



                }

                else if (Session["Trantype"].ToString() == "AI")
                {

                    /*lblbk.InnerText = "Booking";
                    lblstuf.InnerText = "Nom Rec On";
                    lblsail.InnerText = "Pickupon";
                    lbltran.InnerText = "AWB Con On";
                    lblDocon.InnerText = "Pre Alert sent on";
                    lblDoconfirmed.InnerText = "Invoice Sent on";
                    RoundHeight1.Attributes["class"] = "RoundHeight";
                    lblOrig.Visible = true;
                    lblOriginaldocsenton.InnerText = "Clearance Status on";

                    lblrel.Visible = true;
                    lblreleasedonon.InnerText = "Do issued On";


                    lbljob.Visible = true;
                    lbljobon.InnerText = "Job closed On";


                    Originaldocsenton.Visible = true;
                    releasedon.Visible = true;
                    jodate1.Visible = true;

                    LblBookingDate.InnerText = "";
                    LblStuffingDate.InnerText = "";
                    LblSailingDate.InnerText = "";
                    LblTranshipmentDate.InnerText = "";
                    LblDOConfirmReqDate.InnerText = "";
                    LblDOConfirmedDate.InnerText = "";
                    LblOriginaldocsentonDate.InnerText = "";
                    lblreleasedondate.InnerText = "";
                    lbljobDte.InnerText = "";


                    RBooking.Attributes["class"] = "Round";
                    RStuffing.Attributes["class"] = "Round1";
                    RSailling.Attributes["class"] = "Round2";
                    RTranshipment.Attributes["class"] = "Round3";

                    RDOReq.Attributes["class"] = "Round4";
                    RDOCofirm.Attributes["class"] = "Round5";

                    Originaldocsenton.Attributes["class"] = "Round6";

                    releasedon.Attributes["class"] = "Round7";

                    jodate1.Attributes["class"] = "Round8";



                    RoundHeight1.Attributes["class"] = "RoundHeight";
                    lblbk.InnerText = "Booking";
                    lblstuf.InnerText = "Nom Rec On";
                    lblsail.InnerText = "Pickupon";
                    lbltran.InnerText = "AWB Con On";
                    lblDocon.InnerText = "Pre Alert sent on";
                    lblDoconfirmed.InnerText = "Invoice Sent on";


                    lblOriginaldocsenton.InnerText = "Clearance Status on";
                    lblOrig.Visible = true;

                    lblreleasedonon.InnerText = "Do issued On";
                    lblrel.Visible = true;


                    lbljobon.InnerText = "Job closed On";
                    lbljob.Visible = true;
                    */

                    Airic.Visible = true;
                    Shipic.Visible = false;
                    lblbk.InnerText = "Booking";
                    lblstuf.InnerText = "Nom Rec On";
                    lblsail.InnerText = "Pickupon";
                    lbltran.InnerText = "AWB Con On";
                    lblDocon.InnerText = "Pre Alert sent on";
                    lblDoconfirmed.InnerText = "Invoice Sent on";
                    RoundHeight1.Attributes["class"] = "RoundHeight";
                    lblOrig.Visible = true;
                    lblOriginaldocsenton.InnerText = "Clearance Status on";

                    lblrel.Visible = true;
                    lblreleasedonon.InnerText = "Do issued On";


                    lbljob.Visible = true;
                    lbljobon.InnerText = "Job closed On";


                    Originaldocsenton.Visible = true;
                    releasedon.Visible = true;
                    jodate1.Visible = true;
                    lbltran1.Visible = true;

                    lblClear1.Visible = true;
                    lblClear.InnerText = "WH Arrival On";
                    lblCleardate.InnerText = "";

                    lblcargo1.Visible = true;
                    lblcargo.InnerText = "Flight Schl On";
                    lblcargodate.InnerText = "";

                    lblrel.Visible = true;
                    lblarr.InnerText = "Arrival On";
                    lblarrdate.InnerText = "";

                    lbljob.Visible = true;


                    lbldel1.Visible = true;
                    lbldel.InnerText = "Delivery Update On";
                    lbldeldate.InnerText = "";

                    lblDoconfirmed1.Visible = true;

                    lblreleasedonon1.Visible = true;

                    lbljobon1.Visible = true;

                    LblBookingDate.InnerText = "";
                    LblStuffingDate.InnerText = "";
                    LblSailingDate.InnerText = "";
                    LblTranshipmentDate.InnerText = "";
                    LblDOConfirmReqDate.InnerText = "";
                    LblDOConfirmedDate.InnerText = "";
                    LblOriginaldocsentonDate.InnerText = "";
                    lblreleasedondate.InnerText = "";
                    lbljobDte.InnerText = "";


                    RBooking.Attributes["class"] = "Round";
                    RStuffing.Attributes["class"] = "Round1";
                    RSailling.Attributes["class"] = "Round2";
                    RTranshipment.Attributes["class"] = "Round3";

                    RDOReq.Attributes["class"] = "Round4";
                    RDOCofirm.Attributes["class"] = "Round5";

                    Originaldocsenton.Attributes["class"] = "Round6";

                    releasedon.Attributes["class"] = "Round7";

                    jodate1.Attributes["class"] = "Round8";



                    Div1.Attributes["class"] = "Round9";
                    Div2.Attributes["class"] = "Round10";

                    Div3.Attributes["class"] = "Round11";
                    Div4.Attributes["class"] = "Round12";

                    Div4.Visible = true;



                    dt = cusobj.CusloginBookingStatus(txt_bookingno.Text, Convert.ToInt32(Session["webgroupid"]), Session["Trantype"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            txt_status.Text = dt1.Rows[0]["status"].ToString();
                        }

                        dtnew.Columns.Add("Clearance");
                        dtnew.Columns.Add("Status");
                        if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";

                            dtnew.Rows.Add();
                            dtnew.Rows[0][0] = "Booking";
                            dtnew.Rows[0][1] = dt.Rows[0]["bookingdate"].ToString();
                            shipmoved = 1;
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[0][0] = "Booking";
                            dtnew.Rows[0][1] = "";
                        }
                        if (dt.Rows[0]["Nomrecon"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["Nomrecon"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor2";

                            dtnew.Rows.Add();
                            dtnew.Rows[1][0] = "Nom Rec On";
                            dtnew.Rows[1][1] = dt.Rows[0]["Nomrecon"].ToString();
                            shipmoved = 3;
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[1][0] = "Nom Rec On";
                            dtnew.Rows[1][1] = "";
                        }
                        if (dt.Rows[0]["Pickupon"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["Pickupon"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor1";

                         //   lbl_pickupon.Text = dt.Rows[0]["Pickupon"].ToString();

                            dtnew.Rows.Add();
                            dtnew.Rows[2][0] = "Pickupon";
                            dtnew.Rows[2][1] = dt.Rows[0]["Pickupon"].ToString();
                            shipmoved = 2;
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";

                          //  lbl_pickupon.Text = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[2][0] = "Pickupon";
                            dtnew.Rows[2][1] = "";
                        }


                        if (dt.Rows[0]["flightdate"].ToString() != "")
                        {
                            lblcargodate.InnerText = dt.Rows[0]["flightdate"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";


                            dtnew.Rows.Add();
                            dtnew.Rows[3][0] = "Flight Schl On";
                            dtnew.Rows[3][1] = dt.Rows[0]["flightdate"].ToString();
                            shipmoved = 6;
                        }
                        else
                        {
                            lblcargodate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[3][0] = "Flight Schl On";
                            dtnew.Rows[3][1] = "";
                        }


                        if (dt.Rows[0]["docrecon"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["docrecon"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";


                            dtnew.Rows.Add();
                            dtnew.Rows[4][0] = "AWB Con On";
                            dtnew.Rows[4][1] = dt.Rows[0]["docrecon"].ToString();
                            shipmoved = 5;
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[4][0] = "AWB Con On";
                            dtnew.Rows[4][1] = "";
                        }

                        if (dt.Rows[0]["Cargoairheadoveron"].ToString() != "")
                        {
                            lblCleardate.InnerText = dt.Rows[0]["Cargoairheadoveron"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";

                            dtnew.Rows.Add();
                            dtnew.Rows[5][0] = "WH Arrival On";
                            dtnew.Rows[5][1] = dt.Rows[0]["Cargoairheadoveron"].ToString();
                            shipmoved = 4;
                        }
                        else
                        {
                            lblCleardate.InnerText = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[5][0] = "WH Arrival On";
                            dtnew.Rows[5][1] = "";
                        }



                        if (dt.Rows[0]["prealsenton"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["prealsenton"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";

                          //  lbl_prealert.Text = dt.Rows[0]["prealsenton"].ToString();

                            dtnew.Rows.Add();
                            dtnew.Rows[6][0] = "Pre Alert sent on";
                            dtnew.Rows[6][1] = dt.Rows[0]["prealsenton"].ToString();
                            shipmoved = 7;
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";

                           // lbl_prealert.Text = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[6][0] = "Pre Alert sent on";
                            dtnew.Rows[6][1] = "";
                        }

                        if (dt.Rows[0]["arrivalon"].ToString() != "")
                        {
                            lblarrdate.InnerText = dt.Rows[0]["arrivalon"].ToString();
                            releasedon.Attributes["class"] = "Roundcolor7";

                         //   lbl_Arrivalon.Text = dt.Rows[0]["arrivalon"].ToString();

                            dtnew.Rows.Add();
                            dtnew.Rows[7][0] = "Arrival On";
                            dtnew.Rows[7][1] = dt.Rows[0]["arrivalon"].ToString();
                            shipmoved = 8;
                        }
                        else
                        {
                            lblarrdate.InnerText = "";

                         //   lbl_Arrivalon.Text = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[7][0] = "Arrival On";
                            dtnew.Rows[7][1] = "";
                        }


                        if (dt.Rows[0]["Originaldocsenton"].ToString() != "")
                        {
                            LblOriginaldocsentonDate.InnerText = dt.Rows[0]["Originaldocsenton"].ToString();
                            jodate1.Attributes["class"] = "Roundcolor8";

                            dtnew.Rows.Add();
                            dtnew.Rows[8][0] = "Clearance Status on";
                            dtnew.Rows[8][1] = dt.Rows[0]["Originaldocsenton"].ToString();
                            shipmoved = 9;
                        }
                        else
                        {
                            LblOriginaldocsentonDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[8][0] = "Clearance Status on";
                            dtnew.Rows[8][1] = "";
                        }


                        if (dt.Rows[0]["deliveryupdon"].ToString() != "")
                        {
                            lbldeldate.InnerText = dt.Rows[0]["deliveryupdon"].ToString();
                            Div1.Attributes["class"] = "Roundcolor9";

                          //  lbl_cargoloadon.Text = dt.Rows[0]["deliveryupdon"].ToString();

                            dtnew.Rows.Add();
                            dtnew.Rows[9][0] = "Delivery Update On";
                            dtnew.Rows[9][1] = dt.Rows[0]["deliveryupdon"].ToString();
                            shipmoved = 10;
                        }
                        else
                        {
                            lbldeldate.InnerText = "";

                           // lbl_cargoloadon.Text = "";

                            dtnew.Rows.Add();
                            dtnew.Rows[9][0] = "Delivery Update On";
                            dtnew.Rows[9][1] = "";
                        }



                        if (dt.Rows[0]["invoicesenton"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["invoicesenton"].ToString();
                            Div2.Attributes["class"] = "Roundcolor10";

                            dtnew.Rows.Add();
                            dtnew.Rows[10][0] = "Invoice Sent on";
                            dtnew.Rows[10][1] = dt.Rows[0]["invoicesenton"].ToString();
                            shipmoved = 11;
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[10][0] = "Invoice Sent on";
                            dtnew.Rows[10][1] = "";
                        }


                        if (dt.Rows[0]["doissuedon"].ToString() != "")
                        {
                            lblreleasedondate.InnerText = dt.Rows[0]["doissuedon"].ToString();
                            Div3.Attributes["class"] = "Roundcolor11";

                       //     lbl_doon.Text = dt.Rows[0]["doissuedon"].ToString();

                            dtnew.Rows.Add();
                            dtnew.Rows[11][0] = "Do issued On";
                            dtnew.Rows[11][1] = dt.Rows[0]["doissuedon"].ToString();
                            shipmoved = 12;
                        }
                        else
                        {
                            lblreleasedondate.InnerText = "";

                        //    lbl_doon.Text = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[11][0] = "Do issued On";
                            dtnew.Rows[11][1] = "";
                        }

                        if (dt.Rows[0]["jobdate"].ToString() != "")
                        {
                            lbljobDte.InnerText = dt.Rows[0]["jobdate"].ToString();
                            Div4.Attributes["class"] = "Roundcolor12";

                            dtnew.Rows.Add();
                            dtnew.Rows[12][0] = "Job closed On";
                            dtnew.Rows[12][1] = dt.Rows[0]["jobdate"].ToString();
                            shipmoved = 13;
                        }
                        else
                        {
                            lbljobDte.InnerText = "";
                            dtnew.Rows.Add();
                            dtnew.Rows[12][0] = "Job closed On";
                            dtnew.Rows[12][1] = "";
                        }


                        Grd.DataSource = dtnew;
                        Grd.DataBind();

                        DtCombined = cusobj.CustomerloginDetailsfilternewquick(Convert.ToInt32(Session["webgroupid"]), Session["Trantype"].ToString(), 1, txt_bookingno.Text, "BG");
                        if (DtCombined.Rows.Count > 0)
                        {
                           /* lbl_bkg.Text = DtCombined.Rows[0][0].ToString();
                            lbl_bkgdate.Text = DtCombined.Rows[0][1].ToString();
                            lbl_hbl.Text = DtCombined.Rows[0][4].ToString();

                            lbl_shipper.Text = DtCombined.Rows[0][6].ToString();
                            lbl_conginee.Text = DtCombined.Rows[0][7].ToString();

                            lbl_vslvou.Text = DtCombined.Rows[0][16].ToString();

                            lbl_POL.Text = DtCombined.Rows[0][13].ToString();

                            lbl_POD.Text = DtCombined.Rows[0][14].ToString();
                            lbl_FD.Text = DtCombined.Rows[0][15].ToString();

                            lbl_shipment.Text = DtCombined.Rows[0][21].ToString();*/



                            lbl_bkg.Text = DtCombined.Rows[0]["shiprefno"].ToString();
                            lbl_bkgdate.Text = DtCombined.Rows[0]["bookingdate"].ToString();
                            lbl_hbl.Text = DtCombined.Rows[0]["blno"].ToString();

                            lbl_shipper.Text = DtCombined.Rows[0]["shipper"].ToString();
                            lbl_conginee.Text = DtCombined.Rows[0]["consignee"].ToString();

                            lbl_vslvou.Text = DtCombined.Rows[0]["vessel"].ToString();

                            lbl_POL.Text = DtCombined.Rows[0]["pol"].ToString();

                            lbl_POD.Text = DtCombined.Rows[0]["Pod"].ToString();
                            lbl_FD.Text = DtCombined.Rows[0]["fd"].ToString();

                          //  lbl_shipment.Text = DtCombined.Rows[0]["shipmentstatus"].ToString();


                            lbl_cbm.Text = DtCombined.Rows[0]["cbm"].ToString();
                            lbl_grwt.Text = DtCombined.Rows[0]["grweight"].ToString();
                            lbl_ntwt.Text = DtCombined.Rows[0]["ntweight"].ToString();


                            lbl_noofpkg.Text = DtCombined.Rows[0]["noofpkgs"].ToString();
                            lbl_cont.Text = DtCombined.Rows[0]["containerno"].ToString();
                            hid_branchid.Value = DtCombined.Rows[0]["bid"].ToString();

                        }
                        else
                        {
                            lbl_bkg.Text = "";
                            lbl_bkgdate.Text = "";
                            lbl_hbl.Text = "";

                            lbl_shipper.Text = "";
                            lbl_conginee.Text = "";

                            lbl_vslvou.Text = "";

                            lbl_POL.Text = "";

                            lbl_POL.Text = "";
                            lbl_POD.Text = "";
                            lbl_FD.Text = "";

                      //      lbl_shipment.Text = "";

                            lbl_cbm.Text = "";
                            lbl_grwt.Text = "";
                            lbl_ntwt.Text = "";


                            lbl_noofpkg.Text = "";
                            lbl_cont.Text = "";

                        }


                        Fn_FillGrid();

                        if (shipmoved == 13)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove13AI();", true);
                        }

                        else if (shipmoved == 12)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove12AI();", true);
                        }
                        else if (shipmoved == 11)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove11AI();", true);
                        }
                        else if (shipmoved == 10)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove10AI();", true);
                        }
                        else if (shipmoved == 9)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove9AI();", true);
                        }
                        else if (shipmoved == 8)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove8AI();", true);
                        }
                        else if (shipmoved == 7)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove7AI();", true);
                        }
                        else if (shipmoved == 6)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove6AI();", true);
                        }
                        else if (shipmoved == 5)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove5AI();", true);
                        }
                        else if (shipmoved == 4)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove4AI();", true);
                        }
                        else if (shipmoved == 3)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove3AI();", true);
                        }
                        else if (shipmoved == 2)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove2AI();", true);
                        }
                        else if (shipmoved == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Agency", "imagemove1AI();", true);
                        }



                    }
                    else
                    {
                        /* LblBookingDate.InnerText = "";
                         RBooking.Attributes["class"] = "Round";
                         LblStuffingDate.InnerText = "";
                         RStuffing.Attributes["class"] = "Round1";
                         LblSailingDate.InnerText = "";
                         RSailling.Attributes["class"] = "Round2";
                         LblTranshipmentDate.InnerText = "";
                         RTranshipment.Attributes["class"] = "Round3";
                         LblDOConfirmReqDate.InnerText = "";
                         RDOReq.Attributes["class"] = "Round4";
                         LblDOConfirmedDate.InnerText = "";
                         RDOCofirm.Attributes["class"] = "Round5";


                         LblOriginaldocsentonDate.InnerText = "";
                         Originaldocsenton.Attributes["class"] = "Round6";


                         lblreleasedondate.InnerText = "";
                         releasedon.Attributes["class"] = "Round7";


                         lbljobDte.InnerText = "";
                         jodate1.Attributes["class"] = "Round8";

                         */

                        txt_status.Text = "";
                        LblBookingDate.InnerText = "";
                        RBooking.Attributes["class"] = "Round";

                        LblStuffingDate.InnerText = "";
                        RStuffing.Attributes["class"] = "Round1";

                        LblSailingDate.InnerText = "";
                        RSailling.Attributes["class"] = "Round2";

                        lblcargodate.InnerText = "";
                        RDOCofirm.Attributes["class"] = "Round3";

                        LblTranshipmentDate.InnerText = "";
                        RDOReq.Attributes["class"] = "Round4";

                        lblCleardate.InnerText = "";
                        RTranshipment.Attributes["class"] = "Round5";

                        LblDOConfirmReqDate.InnerText = "";
                        Originaldocsenton.Attributes["class"] = "Round6";

                        lblarrdate.InnerText = "";
                        releasedon.Attributes["class"] = "Round7";

                        LblOriginaldocsentonDate.InnerText = "";
                        jodate1.Attributes["class"] = "Round8";

                        lbldeldate.InnerText = "";
                        Div1.Attributes["class"] = "Round9";

                        LblDOConfirmedDate.InnerText = "";
                        Div2.Attributes["class"] = "Round10";

                        lblreleasedondate.InnerText = "";
                        Div3.Attributes["class"] = "Round11";

                        lbljobDte.InnerText = "";
                        Div4.Attributes["class"] = "Round12";



                        lbl_bkg.Text = "";
                        lbl_bkgdate.Text = "";
                        lbl_hbl.Text = "";

                        lbl_shipper.Text = "";
                        lbl_conginee.Text = "";

                        lbl_vslvou.Text = "";

                        lbl_POL.Text = "";

                        lbl_POL.Text = "";
                        lbl_POD.Text = "";
                        lbl_FD.Text = "";

                        //lbl_shipment.Text = "";

                        //lbl_pickupon.Text = "";

                        //lbl_doon.Text = "";

                        //lbl_Arrivalon.Text = "";

                        //lbl_cargoloadon.Text = "";

                        //lbl_prealert.Text = "";

                        lbl_cbm.Text = "";
                        lbl_grwt.Text = "";
                        lbl_ntwt.Text = "";


                        lbl_noofpkg.Text = "";
                        lbl_cont.Text = "";


                      
                        txt_status.Text = "";
                      
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Login Customer do not have the Booking #');", true);
                        return;
                    }



                }



            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Invaild Product');", true);
                return;
            }


            //}
            //else
            //{
            //    LblBookingDate.InnerText = "";
            //    RBooking.Attributes["class"] = "Round";
            //    LblStuffingDate.InnerText = "";
            //    RStuffing.Attributes["class"] = "Round1";
            //    LblSailingDate.InnerText = "";
            //    RSailling.Attributes["class"] = "Round2";
            //    LblTranshipmentDate.InnerText = "";
            //    RTranshipment.Attributes["class"] = "Round3";
            //    LblDOConfirmReqDate.InnerText = "";
            //    RDOReq.Attributes["class"] = "Round4";
            //    LblDOConfirmedDate.InnerText = "";
            //    RDOCofirm.Attributes["class"] = "Round5";
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Invalid Booking #,Booking # should be contain greater than 14 character');", true);
            //    return;
            //}
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            string sub11="";
            sub11="Special Notes/instructions";
            txt_from.Text = "";
            Utility.SendMailnew("", txt_to.Text, sub11, txt_note.Text, "", "Msncl2021$", "", txt_cc.Text);
        }




        protected void grpupdload_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbudget, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                //lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grpupdload, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

           
        }

        protected void grpupdload_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int index = grpupdload.SelectedRow.RowIndex;
                int docid, i, dcmtid;
                string Remarks, filenameloc;
                if (grpupdload.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    if (txt_bookingno.Text != "")
                    {
                        docid = Convert.ToInt32(grpupdload.Rows[index].Cells[2].Text);
                        Remarks = grpupdload.Rows[index].Cells[1].Text;
                        dcmtid = Convert.ToInt32(grpupdload.Rows[index].Cells[3].Text);

                        hid_poddownload.Value = grpupdload.Rows[index].Cells[4].Text;

                        if (hid_poddownload.Value != "")
                        {
                            fttnormaldwd();
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                            return;
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "EDI", "alertify.alert('Please Enter the Booking #');", true);
                        txt_bookingno.Focus();
                    }


                }

            }
            catch (Exception ex)
            {

            }

        }

        /*protected void fttnormaldwd()
        {



            string str_path = "";
            string str_paths = "";
            string str_FileId, str_filename;
            str_filename = hid_poddownload.Value.Replace("&", "");
            DataTable dt = new DataTable();


            str_path = Server.MapPath("~/UploadDocument/Ebooking/");

            string path = Server.MapPath("~/UploadDocument/Ebooking/" + str_filename);


            string ftp = "ftp://20.235.30.214/";
            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/Ebooking/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Stream ftpStream = response.GetResponseStream())
            {
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }


            WebClient client = new WebClient();
            Byte[] buffer1 = client.DownloadData(path);
            if (buffer1 != null)
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
                Response.WriteFile(path);
                Response.Flush();



            }


            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            Response.End();




        }
        */

        protected void fttnormaldwd()
        {
            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
         


            string str_path = "";
            string str_paths = "";
            string str_FileId, str_filename;
            str_filename = hid_poddownload.Value.Replace("&", "");
            //str_FileId = "201711070726393477";
            DataTable dt = new DataTable();

            //dt = DriverObj.searhpodprooftodownload(str_FileId);


            //str_filename = dt.Rows[0]["podproof"].ToString();
            //// str_filename = str_filename.Substring(str_filename.LastIndexOf('.') + 1, str_filename.Length - str_filename.LastIndexOf('.') - 1);

            //string[] dwndile = new string[0];

            //dwndile = str_filename.Split(',');

            //str_filename = dwndile[0];
            //string filePath = Server.MapPath("~/W-TMS/Upload/" + fileName);




            str_path = Server.MapPath("~/W-FTP/Upload");

            string path = Server.MapPath("~/W-FTP/Upload/" + str_filename);


            string ftp = "ftp://20.235.30.214/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
           // request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            request.Credentials = new NetworkCredential(username, password);

            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Stream ftpStream = response.GetResponseStream())
            {
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }


            WebClient client = new WebClient();
            Byte[] buffer1 = client.DownloadData(path);
            if (buffer1 != null)
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
                Response.WriteFile(path);
                Response.Flush();



            }


            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            Response.End();






        }
        private void Fn_FillGrid()
        {
            try
            {
                DataAccess.Documents obj_da_Document = new DataAccess.Documents();
                DataTable obj_dt = new DataTable();
                DataTable obj_dt1 = new DataTable();
                int intBranchID = 0;
                int jobno = 0;
                DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
                DataAccess.ForwardingExports.ISFDetails obj = new DataAccess.ForwardingExports.ISFDetails();
                DataAccess.ForwardingExports.PODetails bookingtran = new DataAccess.ForwardingExports.PODetails();
                DataTable dt = new DataTable();
                //if (hid_branchid.Value!="")
                //{
                    
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Branch');", true);
                //}

               // obj_dt = obj_da_Document.GetDocDtls4ebooking(int.Parse(hid_branchid.Value), "E", txt_bookingno.Text);

                obj_dt1 = bookingtran.getbookingdetailsjobtrantype(txt_bookingno.Text);
                if (obj_dt1.Rows.Count > 0)
                {
                    if (obj_dt1.Columns.Contains("job"))
                    {
                       
                        jobno = Convert.ToInt32(obj_dt1.Rows[0]["job"].ToString());
                    }
                }
                if (hid_branchid.Value=="")
                {
                    hid_branchid.Value = "0";
                }

                obj_dt = obj_da_Document.GetDocDtls4RecGuru(int.Parse(hid_branchid.Value), Session["Trantype"].ToString(), jobno);
                if (obj_dt.Rows.Count > 0)
                {

                    grpupdload.DataSource = obj_dt;
                    grpupdload.DataBind();


                    

                }
                else
                {
                    //Grd_Doc.DataSource = new DataTable();
                    //Grd_Doc.DataBind();

                    grpupdload.DataSource = new DataTable();
                    grpupdload.DataBind();
                    Session["dt"] = new DataTable();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

    }
}