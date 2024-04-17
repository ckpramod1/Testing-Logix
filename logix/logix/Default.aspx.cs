using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.Security;
using ClosedXML.Excel;
using System.IO;
using System.Text;
using System.Web.Services;
using System.Collections.Generic;

namespace logix
{
    public partial class Default : System.Web.UI.Page
    {
        string str = "";
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        double sum1, sum2, sum3, sum4, sum5;
        // Calendar CldrTemp = new Calendar();
        DataAccess.RegCustomer cusobj = new DataAccess.RegCustomer();
        DataAccess.Accounts.Recipts objReceipt = new DataAccess.Accounts.Recipts();
        int selectedRowIndex, selectedColumnIndex;
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.LogDetails ObjLog = new DataAccess.LogDetails();
        DataTable dt;
        DataTable dtevent;
        protected void Page_Load(object sender, EventArgs e)
        {

           
            //DateTime FromDate;
            //DateTime ToDate;
            //string find = "";
            //int cusID = 0;

            //FromDate = DateTime.Parse(ConvertDate(DateTime.Now.ToString("dd/MM/yyyy")));
            //ToDate = DateTime.Parse(ConvertDate(DateTime.Now.ToString("dd/MM/yyyy")));
            //find = cusobj.SPGetDBName4Jsonnew(FromDate, ToDate);

            //Session["FADbname"] = find;
            if (Session["str"] != null)
            {
                str = Session["str"].ToString();
            }

            /*RoundHeight1.Attributes["class"] = "RoundHeight1";

            RBooking.Attributes["class"] = "Round";
            RStuffing.Attributes["class"] = "Round1";
            RSailling.Attributes["class"] = "Round2";
            RTranshipment.Attributes["class"] = "Round3";

            RDOReq.Attributes["class"] = "Round4";
            RDOCofirm.Attributes["class"] = "Round5";
            */

            







           //Originaldocsenton.Visible = false;
           // releasedon.Visible = false;
//            jodate1.Visible = false;



            if (!IsPostBack)
            {
                loaddropdown();
                binddata();
                txt_container.SelectedItem.Text = "";

                txt_booking.SelectedItem.Text = "";
                txt_customer.SelectedItem.Text = "";
                //if (Session["StrTranType"].ToString() != "")
                //{
                    //ddl_product.SelectedValue = Session["StrTranType"].ToString();
                //}
               // Iframe1.Visible = false;
                //ShipmentviewClear();
                //QuickViewClear();
                //bookline();
                //booklinenew();
                //div2_Bookchart.Visible = true;
                //div_bar.Visible = true;
                //Paneln2.Visible = false;
                //pnlCharge.Visible = true;

                //lnk_upd.Visible = true;


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

               // lbljobon1.Visible = false;

                



 
                lblbk.InnerText = "Booking";
                lblsail.InnerText = "Container Gate Out";
                lblstuf.InnerText = "Stuffing";
                lblClear.InnerText = "Container Port In";
                lbltran.InnerText = "Sailing";
                lblcargo.InnerText = "BL Released On";
                lblDocon.InnerText = "T/S (If Any)";
                lblarr.InnerText = "CAN Sent On";
                lblOriginaldocsenton.InnerText = "Arrival";
                lbldel.InnerText = "Container Port Out";

                lblDoconfirmed.InnerText = "Destuffing";
                lblreleasedonon.InnerText = "DO Issued On";

                lbljobon1.InnerText = "Container Gate in";
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
            }
            ifrmaster.Visible = true;


            //ifrmaster.Attributes["src"] = "OAHome.aspx?uid=" + str + "&Trantype=FE";
        }

       
        protected void loaddropdown()
        {
            DataSet ds = objRpt.GEtdropdownvalues4CS(0, "", Convert.ToInt32(Session["webcuspanid"].ToString()));

            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];
            //  dtevent = objRpt.Getmastereventdetails("0");
            if (dt2.Rows.Count > 0)
            {
                for (int j = 0; j <= dt2.Rows.Count + 1; j++)
                {
                    txt_booking.Items.Clear();
                    txt_booking.Items.Add("");
                    txt_booking.DataSource = dt2;
                    txt_booking.DataTextField = "shiprefno";

                    txt_booking.DataBind();

                }
            }
            if (dt3.Rows.Count > 0)
            {
                for (int k = 0; k <= dt3.Rows.Count+1; k++)
                {
                    txt_container.Items.Clear();
                    txt_container.Items.Add("");
                    txt_container.DataSource = dt3;
                    txt_container.DataTextField = "containerno";

                    txt_container.DataBind();
                }
            }
            if (dt1.Rows.Count > 0)
            {
                for (int l = 0; l <= dt1.Rows.Count + 1; l++)
                {
                    txt_customer.Items.Clear();
                    txt_customer.Items.Add("");
                    txt_customer.DataSource = dt1;
                    txt_customer.DataTextField = "customer";

                    txt_customer.DataBind();
                }
            }

            //txt_customer.SelectedValue = "0";
            //txt_container.SelectedValue = "0";
            //txt_booking.SelectedValue = "0";

        }








        protected void binddata()
        {
            dt = objRpt.GetCustomersupportallpancustwise(0, "", Convert.ToInt32(Session["webcuspanid"].ToString()));
            if (dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
                //  dtevent = objRpt.Getmastereventdetails("0");

                //for (int j = 0; j < grd.Rows.Count; j++)
                //{
                //    var ddl1 = (DropDownList)grd.Rows[j].FindControl("ddl_NextEvent");
                //    dtevent = objRpt.Getmastereventdetails(dt.Rows[j]["nextevent"].ToString());
                //    ddl1.Items.Add("");
                //    ddl1.DataSource = dtevent;
                //    ddl1.DataTextField = "Events";

                //    ddl1.DataBind();
                //    ddl1.SelectedItem.Text = dt.Rows[j]["nextevent"].ToString();
                //    TextBox lnkbtn = (TextBox)(grd.Rows[j].FindControl("occuredon"));
                //    // lnkbtn.Text = Utility.fn_ConvertDate(dt.Rows[j]["occuredon"].ToString());
                //}
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grd.Rows)
            {
                DropDownList Txt = (DropDownList)grd.Rows[row.RowIndex].FindControl("LastEvent");
                if (Txt.SelectedValue != "0")
                {
                    DropDownList nextTxt = (DropDownList)grd.Rows[row.RowIndex].FindControl("LastEvent");
                    int next = Convert.ToInt32(Txt.SelectedValue) + 1;
                    nextTxt.SelectedValue = next.ToString();
                }
            }
        }
        private void Grd_TDS_CellContentClick(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > 0)
            {
                int rowindex = e.Row.RowIndex;
                GridViewRow row = this.grd.Rows[rowindex];
            }

        }
        protected void ddl_LastEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
            index = row.RowIndex;
            DropDownList Txt = (DropDownList)grd.Rows[row.RowIndex].FindControl("LastEvent");
            DropDownList Txt1 = (DropDownList)grd.Rows[row.RowIndex].FindControl("NextEvent");

        }

        protected void ddl_NextEvent_SelectedIndexChanged(object sender, EventArgs e)
        {


            int index = 0;
            GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
            index = row.RowIndex;
            DropDownList Txt = (DropDownList)grd.Rows[row.RowIndex].FindControl("NextEvent");




        }
        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$");

            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Boolean check = false;
            for (int i = 0; i < grd.Rows.Count; i++)
            {


                // DropDownList Txt = (DropDownList)grd.Rows[i].FindControl("ddl_LastEvent");
                DropDownList Txt1 = (DropDownList)grd.Rows[i].FindControl("ddl_NextEvent");
                TextBox date = (TextBox)grd.Rows[i].FindControl("updateddt");


                if (date.Text != "")
                {

                    objRpt.InsOEeventdetails(Convert.ToInt32(grd.Rows[i].Cells[3].Text), grd.Rows[i].Cells[0].Text, grd.Rows[i].Cells[2].Text, Txt1.SelectedValue,
                        Convert.ToDateTime(Utility.fn_ConvertDate(date.Text.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    check = true;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' " + Txt1.SelectedValue + " updated for the container " + grd.Rows[i].Cells[2].Text + "');", true);
                    // sendMail(Convert.ToInt32(grd.Rows[i].Cells[3].Text), grd.Rows[i].Cells[0].Text, Txt1.SelectedValue);
                }


            }
            if (check == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the date...');", true);
                return;
            }

            dt = objRpt.GetCustomersupportallpancustwise(0, "",Convert.ToInt32(Session["webcuspanid"].ToString()));
            if (dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();


                //for (int j = 0; j < grd.Rows.Count; j++)
                //{
                //    var ddl1 = (DropDownList)grd.Rows[j].FindControl("ddl_NextEvent");

                //    dtevent = objRpt.Getmastereventdetails(dt.Rows[j]["nextevent"].ToString());
                //    ddl1.DataSource = dtevent;
                //    ddl1.DataTextField = "Events";

                //    ddl1.DataBind();
                //    ddl1.SelectedItem.Text = dt.Rows[j]["nextevent"].ToString();

                //}
            }
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {

            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            binddata();
            loaddropdown();
            txt_container.SelectedItem.Text = "";
            txt_job.Text = "";
            txt_booking.SelectedItem.Text = "";
            txt_customer.SelectedItem.Text = "";
             ddl_product.SelectedValue = "0";
            
        }

        [WebMethod]
        public static List<string> GetBookingPending(string prefix)
        {
            List<string> List_Result = new List<string>();
            string StrTranType = "";
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                StrTranType = HttpContext.Current.Session["StrTranType"].ToString();
            }

            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            DataTable dtbooking = new DataTable();
            dtbooking = bookingobj.GetBookingPending(StrTranType, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dtbooking, "bookingno", "bookno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetLikeCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
            DataTable dtCarrier = new DataTable();
            dtCarrier = Cusobj.GetLikeCustomer(prefix.ToUpper(), "C");

            List_Result = Utility.Fn_TableToList(dtCarrier, "customer", "customerid", "customername", "address");
            return List_Result;
        }

        protected void text_TextChanged(object sender, EventArgs e)
        {
            binddata();
        }

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            dt = objRpt.GetCustomersupportallpancustwise(0, "",Convert.ToInt32(Session["webcuspanid"].ToString()));
            if (dt.Rows.Count > 0)
            {
                //grd.DataSource = dt;
                //grd.DataBind();
                DataView obj_dtview = new DataView(dt);
                if (txt_booking.SelectedItem.Text != "" && txt_container.SelectedItem.Text != "" && ddl_product.SelectedValue!="0")
                {
                    obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and containerno ='" + txt_container.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";
                }
                else if (txt_booking.SelectedItem.Text != "" && txt_container.SelectedItem.Text == "" && ddl_product.SelectedValue != "0")
                {
                    obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and product = '" + ddl_product.SelectedItem.Text + "'";

                }
                else if (txt_booking.SelectedItem.Text == "" && txt_container.SelectedItem.Text == "" && ddl_product.SelectedValue == "0" && txt_job.Text!="")
                {
                    obj_dtview.RowFilter = "jobno = " + txt_job.Text;

                }
                else if (txt_booking.SelectedItem.Text == "" && txt_container.SelectedItem.Text == "" && ddl_product.SelectedValue != "0" && txt_job.Text != "")
                {
                    obj_dtview.RowFilter = "jobno = " + txt_job.Text + " and product = '" + ddl_product.SelectedItem.Text + "'";

                }

                dt = obj_dtview.ToTable();
                grd.DataSource = dt;
                grd.DataBind();
                // dtevent = objRpt.Getmastereventdetails();

                //for (int j = 0; j < grd.Rows.Count; j++)
                //{
                //    var ddl1 = (DropDownList)grd.Rows[j].FindControl("ddl_NextEvent");
                //    dtevent = objRpt.Getmastereventdetails(dt.Rows[j]["nextevent"].ToString());
                //    ddl1.Items.Add("");
                //    ddl1.DataSource = dtevent;
                //    ddl1.DataTextField = "Events";

                //    ddl1.DataBind();
                //    ddl1.SelectedItem.Text = dt.Rows[j]["nextevent"].ToString();
                //    TextBox lnkbtn = (TextBox)(grd.Rows[j].FindControl("occuredon"));
                //    // lnkbtn.Text = Utility.fn_ConvertDate(dt.Rows[j]["occuredon"].ToString());
                //}
            }
        }

        protected void txt_booking_TextChanged(object sender, EventArgs e)
        {
            dt = objRpt.GetCustomersupportallpancustwise(0, "",Convert.ToInt32(Session["webcuspanid"].ToString()));
            if (dt.Rows.Count > 0)
            {
                //grd.DataSource = dt;
                //grd.DataBind();
                DataView obj_dtview = new DataView(dt);
                if (txt_job.Text != "" && txt_container.SelectedItem.Text != "" && ddl_product.SelectedValue != "0")
                {
                    obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and containerno ='" + txt_container.SelectedItem.Text + "' and product =" + ddl_product.SelectedItem.Text + "'";
                }
                else if (txt_job.Text != "" && txt_container.SelectedItem.Text == "" && ddl_product.SelectedValue != "0")
                {
                    // obj_dtview.RowFilter = "bookingno = " + txt_booking.SelectedItem.Text + " and jobno =" + txt_job.Text;
                    obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and product ='" + ddl_product.SelectedItem.Text + "'";
                     

                }
                else if (txt_job.Text == "" && txt_container.SelectedItem.Text == "" && ddl_product.SelectedValue != "0")
                {
                    obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";
                  

                }
                if (txt_job.Text == "" && txt_container.SelectedItem.Text == "" && ddl_product.SelectedValue == "0")
                {
                    obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "'";
                }
                
                dt = obj_dtview.ToTable();
                grd.DataSource = dt;
                grd.DataBind();
                // dtevent = objRpt.Getmastereventdetails();

                //for (int j = 0; j < grd.Rows.Count; j++)
                //{
                //    var ddl1 = (DropDownList)grd.Rows[j].FindControl("ddl_NextEvent");
                //    dtevent = objRpt.Getmastereventdetails(dt.Rows[j]["nextevent"].ToString());
                //    ddl1.Items.Add("");
                //    ddl1.DataSource = dtevent;
                //    ddl1.DataTextField = "Events";

                //    ddl1.DataBind();
                //    ddl1.SelectedItem.Text = dt.Rows[j]["nextevent"].ToString();
                //    TextBox lnkbtn = (TextBox)(grd.Rows[j].FindControl("occuredon"));
                //    // lnkbtn.Text = Utility.fn_ConvertDate(dt.Rows[j]["occuredon"].ToString());
                //}
            }
        }

        protected void txt_bl_TextChanged(object sender, EventArgs e)
        {
            dt = objRpt.GetCustomersupportallpancustwise(0, "",Convert.ToInt32(Session["webcuspanid"].ToString()));
            if (dt.Rows.Count > 0)
            {
                //grd.DataSource = dt;
                //grd.DataBind();
                DataView obj_dtview = new DataView(dt);
                if (txt_job.Text != "" && txt_booking.SelectedItem.Text != "" && ddl_product.SelectedValue!="0")
                {
                    obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and containerno ='" + txt_container.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";
                }
                else if (txt_container.SelectedItem.Text != "" && txt_job.Text == "" && txt_booking.SelectedItem.Text == "" && ddl_product.SelectedValue != "0")
                {
                    obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";

                }
                else if (txt_job.Text != "" && txt_container.SelectedItem.Text != "" && ddl_product.SelectedValue != "0")
                {
                    obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and product ='" + ddl_product.SelectedItem.Text + "'";
                }
                else if (txt_job.Text == "" && txt_container.SelectedItem.Text != "" && ddl_product.SelectedValue == "0" && txt_booking.SelectedItem.Text=="")
                {
                    obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "'";
                }
                else if (txt_job.Text == "" && txt_container.SelectedItem.Text != "" && txt_booking.SelectedItem.Text != "" && ddl_product.SelectedValue != "0")
                {
                    obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";
                }
                dt = obj_dtview.ToTable();
                grd.DataSource = dt;
                grd.DataBind();
                // dtevent = objRpt.Getmastereventdetails();

                //for (int j = 0; j < grd.Rows.Count; j++)
                //{
                //    var ddl1 = (DropDownList)grd.Rows[j].FindControl("ddl_NextEvent");
                //    dtevent = objRpt.Getmastereventdetails(dt.Rows[j]["nextevent"].ToString());
                //    ddl1.Items.Add("");
                //    ddl1.DataSource = dtevent;
                //    ddl1.DataTextField = "Events";

                //    ddl1.DataBind();
                //    ddl1.SelectedItem.Text = dt.Rows[j]["nextevent"].ToString();
                //    TextBox lnkbtn = (TextBox)(grd.Rows[j].FindControl("occuredon"));
                //    // lnkbtn.Text = Utility.fn_ConvertDate(dt.Rows[j]["occuredon"].ToString());
                //}
            }
        }

        public void sendMail(int job, string bookingno, string eventname)
        {
            string msub = "";
            string sendqry = "";
            string cont = "";
            string remarks = "";
            //string sendqry = "";
            string strinvpl;
            DataTable obj_dt = new DataTable();
            DataTable obj_dt1 = new DataTable();
            DataTable obj_dt2 = new DataTable();
            DataAccess.ForwardingExports.ShippingBill obj_da_shpngbill = new DataAccess.ForwardingExports.ShippingBill();
            DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();
            //sendqry = sendqry + Session["Companyaddress"].ToString();
            DataTable dtmail = objRpt.Geteventcontent4mail(job, Convert.ToInt32(Session["LoginBranchid"]), eventname, Session["StrTranType"].ToString());
            msub = eventname + " - Booking # " + bookingno;
            sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>Please find below gate out details</B></FONT></td></tr><br>";

            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT></td></tr></table><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thank you for your valuable shipment. This is to bring to your kind attention that your shipment has stuffed & the tentative sailing details are as follows</FONT></td></tr></table><br>";
            //        sendqry = sendqry & "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Note : Please forward Invoice and Packing List copies for this Shipment</FONT></td></tr><br><br>"
            //sendqry = sendqry & "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # : " & txt_job.Text & "</FONT></td><td></td><td></td><td></td><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " & txt_book.Text & "</FONT></td></tr></table>"
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # :" + job + "</FONT></td></tr>";
            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " + bookingno + "</FONT></td></tr></table>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>POR : " + dtmail.Rows[0]["por"].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POL : " + dtmail.Rows[0]["pol"].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POD : " + dtmail.Rows[0]["pod"].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>FD : " + dtmail.Rows[0]["fd"].ToString() + "</FONT></td></tr></table><br>";

            sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>SizeType</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Seal #</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>eventdate</B></FONT></td> </tr><br>";
            for (int j = 0; j <= dtmail.Rows.Count - 1; j++)
            {


                sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + dtmail.Rows[0]["containerno"].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + dtmail.Rows[0]["sizetype"].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + dtmail.Rows[0]["sealno"].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + dtmail.Rows[0]["eventdate"].ToString() + "</FONT></td></tr>";

            }

            Utility.SendMail(" VS@copperhawk.tech", " VS@copperhawk.tech", msub, sendqry, "", "Sindhuja01@)@@", "", "");

            //int j = 0;
            //if (Grd_sb.Rows.Count > 0)
            //{
            //    if (jobtype != 3)
            //    {
            //        sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Volume</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
            //        for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
            //        {
            //            cont = "";
            //            obj_dt1 = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text.ToString()), Grd_sb.Rows[j].Cells[0].Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
            //            if (obj_dt1.Rows.Count > 0)
            //            {
            //                for (int i = 0; i <= obj_dt1.Rows.Count - 1; i++)
            //                {
            //                    cont = cont + obj_dt1.Rows[i][0].ToString() + " / " + obj_dt1.Rows[i][1].ToString() + " / " + obj_dt1.Rows[i][2] + "  , ";
            //                }
            //                if (!string.IsNullOrEmpty(cont))
            //                {
            //                    cont = cont.Remove(cont.Length - 2, 2);
            //                }
            //            }
            //            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text.ToString() + " & " + Grd_sb.Rows[j].Cells[1].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text.ToString() + "  " + Grd_sb.Rows[j].Cells[5].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[7].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text.ToString() + "</FONT></td></tr>";

            //        }
            //    }
            //    else
            //    {
            //        sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
            //        for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
            //        {
            //            cont = "";
            //            obj_dt2 = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text.ToString()), Grd_sb.Rows[j].Cells[0].Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
            //            if (obj_dt2.Rows.Count > 0)
            //            {
            //                for (int i = 0; i <= obj_dt2.Rows.Count - 1; i++)
            //                {
            //                    cont = cont + obj_dt2.Rows[i][0].ToString() + " / " + obj_dt2.Rows[i][1].ToString() + " / " + obj_dt2.Rows[i][2].ToString() + "  , ";
            //                }
            //                if (!string.IsNullOrEmpty(cont))
            //                {
            //                    cont = cont.Remove(cont.Length - 2, 2);
            //                }
            //            }
            //            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";
            //        }
            //    }

            //    cont = "";
            //    sendqry = sendqry + "</table>";
            //}

            //sendqry = sendqry + "<table border=1><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Feeder Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_vessel.Text + "</FONT></td></tr><br>";
            //sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETD  " + txt_pol.Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_etd.Text + "</FONT></td></tr>";
            //sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETA  " + txt_pod.Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_eta.Text + "</FONT></td></tr>";
            //for (int i = 0; i <= Grd_vessel.Rows.Count - 1; i++)
            //{
            //    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connect On</FONT></td></tr><br>";
            //    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Mother Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[0].Text + "</FONT></td></tr>";
            //    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETD  " + Grd_vessel.Rows[i].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[2].Text + "</FONT></td></tr>";
            //    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETA  " + Grd_vessel.Rows[i].Cells[3].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[4].Text + "</FONT></td></tr>";
            //    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Remarks </FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[5].Text + "</FONT></td></tr>";
            //}
            //sendqry = sendqry + "</table><br>";

            //sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Assuring you our best service at all times & kindly acknowledge the receipt.</FONT></td></tr></table><br>";
            //sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thanks & Best Regards,</FONT></td></tr><br>";

        }

        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {
            dt = objRpt.GetCustomersupportallpancustwise(0, "",Convert.ToInt32(Session["webcuspanid"].ToString()));
            if (dt.Rows.Count > 0)
            {
                //grd.DataSource = dt;
                //grd.DataBind();
                DataView obj_dtview = new DataView(dt);
                if (txt_job.Text != "" && txt_booking.SelectedItem.Text != "" && txt_container.SelectedItem.Text != "")
                {
                    obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and containerno ='" + txt_container.SelectedItem.Text + "' and customer ='" + txt_customer.Text + "'";
                }
                else if (txt_container.SelectedItem.Text != "" && txt_job.Text == "" && txt_booking.SelectedItem.Text == "")
                {
                    obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and customer ='" + txt_customer.Text + "'";

                }
                else if (txt_job.Text != "" && txt_container.SelectedItem.Text != "" && txt_booking.SelectedItem.Text == "")
                {
                    obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and jobno =" + txt_job.Text + "' and customer ='" + txt_customer.Text + "'";
                }
                else if (txt_job.Text == "" && txt_container.SelectedItem.Text == "" && txt_booking.SelectedItem.Text == "")
                {
                    obj_dtview.RowFilter = "customer ='" + txt_customer.Text + "'";
                }
                else if (txt_job.Text == "" && txt_container.SelectedItem.Text != "" && txt_booking.SelectedItem.Text != "")
                {
                    obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and bookingno = '" + txt_booking.SelectedItem.Text + "' and customer ='" + txt_customer.Text + "'";
                }
                dt = obj_dtview.ToTable();
                grd.DataSource = dt;
                grd.DataBind();
                // dtevent = objRpt.Getmastereventdetails();

                //for (int j = 0; j < grd.Rows.Count; j++)
                //{
                //    var ddl1 = (DropDownList)grd.Rows[j].FindControl("ddl_NextEvent");
                //    dtevent = objRpt.Getmastereventdetails(dt.Rows[j]["nextevent"].ToString());
                //    ddl1.Items.Add("");
                //    ddl1.DataSource = dtevent;
                //    ddl1.DataTextField = "Events";

                //    ddl1.DataBind();
                //    ddl1.SelectedItem.Text = dt.Rows[j]["nextevent"].ToString();
                //    TextBox lnkbtn = (TextBox)(grd.Rows[j].FindControl("occuredon"));
                //    // lnkbtn.Text = Utility.fn_ConvertDate(dt.Rows[j]["occuredon"].ToString());
                //}
            }
        }



      
        public void bookline()
        {
            DataTable dt0 = new DataTable();
            //Session["LoginBranchid"] = "252";

            dt0 = objReceipt.getcustloginchart4home(Convert.ToInt32(Session["webgroupid"].ToString()));
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Trantype');
            data.addColumn('number', 'Booked');
             data.addColumn('number', 'Closed');
           data.addColumn('number', 'Transit');

            data.addRows(" + dt0.Rows.Count + ");");



            for (int i = 0; i <= dt0.Rows.Count - 1; i++)
            {


                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt0.Rows[i]["Trantype"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt0.Rows[i]["Booked"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt0.Rows[i]["Closed"].ToString() + ") ;");

                str.Append("data.setValue(" + i + "," + 3 + "," + dt0.Rows[i]["Transit"].ToString() + ") ;");
            }

            str.Append("   var chart = new google.visualization.ColumnChart(document.getElementById('chart_divbar'));");
            str.Append(" chart.draw(data, {width: 505, height: 280, title: 'Booking Details',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lts.Text = str.ToString().Replace('*', '"');



        }


        public void booklinenew()
        {
            DataTable dt0 = new DataTable();
            //Session["LoginBranchid"] = "252";
            div_bar.Visible = true;
            if (Session["webgroupid"] != null)
            {
                dt0 = objReceipt.getcustloginchart4home(Convert.ToInt32(Session["webgroupid"].ToString()));
            }
            if (dt0.Rows.Count > 0)
            {
                //DataTable dtTemp = new DataTable();
                DataRow dr = dt0.NewRow();
                //dtTemp.Columns.Add("SI");
                //dtTemp.Columns.Add("Trantype");
                ////dtTemp.Columns.Add("blno");
                //dtTemp.Columns.Add("Booked");
                //dtTemp.Columns.Add("Transit");
                //dtTemp.Columns.Add("Closed");
                //dtTemp.Columns.Add("Total");
                dr[0] = "Total";
                dr[1] = dt0.Compute("sum(Booked)", string.Empty).ToString();
                dr[2] = dt0.Compute("sum(Transit)", string.Empty).ToString();
                dr[3] = dt0.Compute("sum(Closed)", string.Empty).ToString();
                dt0.Rows.Add(dr);

                dt0.Columns.Add("Total", typeof(int));
                int Tot = 0;
                for (int i = 0; i < dt0.Rows.Count; i++)
                {
                    for (int j = 0; j < dt0.Columns.Count; j++)
                    {
                        if (j != 0 && j != 4)
                        {
                            Tot += Convert.ToInt32(dt0.Rows[i][j].ToString());
                            dt0.Rows[i]["Total"] = Tot.ToString();
                        }
                    }
                    Tot = 0;
                }
            }

            if (dt0.Rows.Count > 0)
            {
                //grd.DataSource = dt0;
                //grd.DataBind();



                grd.DataSource = dt0;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = new DataTable();
                grd.DataBind();
            }


        }
        [WebMethod]
        public static List<countrydetails> GetChartDataBooking()
        {
            /* DataTable dt1 = new DataTable();
             List<countrydetails> dataList = new List<countrydetails>();
             //DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
             //DataTable dtemptyfree = new DataTable();
             //dtemptyfree = objbu.selpendingBookcutomerwisecount_Chart(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
             DataTable dt = new DataTable();
             DataAccess.LogDetails logobj = new DataAccess.LogDetails();
             DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
             DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
             DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
             int month = Todate.Month;
             //int month = 04;
             int year = Todate.Year;
             double amt = 0;
             double amt1 = 0;
             double amt2 = 0;
             double amt3 = 0;
             double amt4 = 0;
             double amt5 = 0;
             DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
             dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("trantype") });
             dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("jobclosed") });
             string webgroupid = "252";
            // HttpContext.Current.Session["LoginBranchid"] = "1";
            // dt = da_obj_misgrd.GetOperatingProfit(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), "AC", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
             DataAccess.Accounts.Recipts objReceipt = new DataAccess.Accounts.Recipts();
             dt = objReceipt.getcustloginchart4home(Convert.ToInt32(webgroupid));
             if (dt.Rows.Count > 0)
             {
                 dt1.Rows.Add();
                 dt1.Rows[dt1.Rows.Count - 1]["trantype"] = "AE";
                 if (dt.Columns.Contains("AE"))
                 {
                     if (!string.IsNullOrEmpty(dt.Rows[0]["AE"].ToString()))
                     {
                         amt = (Convert.ToDouble(dt.Rows[0]["AE"].ToString()));
                     }
                 }
                 if (amt >= 0)
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = amt.ToString("#0.00");
                 }
                 else
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = "0.00";
                 }

                 dt1.Rows.Add();
                 dt1.Rows[dt1.Rows.Count - 1]["trantype"] = "AI";
                 if (dt.Columns.Contains("AI"))
                 {
                     if (!string.IsNullOrEmpty(dt.Rows[0]["AI"].ToString()))
                     {
                         amt1 = (Convert.ToDouble(dt.Rows[0]["AI"].ToString()));
                     }
                 }
                 if (amt1 >= 0)
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = amt1.ToString("#0.00");
                 }
                 else
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = "0.00";
                 }

                 dt1.Rows.Add();
                 dt1.Rows[dt1.Rows.Count - 1]["trantype"] = "BT";
                 if (dt.Columns.Contains("BT"))
                 {
                     if (!string.IsNullOrEmpty(dt.Rows[0]["BT"].ToString()))
                     {
                         amt2 = (Convert.ToDouble(dt.Rows[0]["BT"].ToString()));
                     }
                 }
                 if (amt2 >= 0)
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = amt2.ToString("#0.00");
                 }
                 else
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = "0.00";
                 }
                 dt1.Rows.Add();
                 dt1.Rows[dt1.Rows.Count - 1]["trantype"] = "CH";
                 if (dt.Columns.Contains("CH"))
                 {
                     if (!string.IsNullOrEmpty(dt.Rows[0]["CH"].ToString()))
                     {
                         amt3 = (Convert.ToDouble(dt.Rows[0]["CH"].ToString()));
                     }
                 }
                 if (amt3 >= 0)
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = amt3.ToString("#0.00");
                 }
                 else
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = "0.00";
                 }
                 dt1.Rows.Add();
                 dt1.Rows[dt1.Rows.Count - 1]["trantype"] = "OE";
                 if (dt.Columns.Contains("OE"))
                 {
                     if (!string.IsNullOrEmpty(dt.Rows[0]["OE"].ToString()))
                     {
                         amt4 = (Convert.ToDouble(dt.Rows[0]["OE"].ToString()));
                     }
                 }
                 if (amt4 >= 0)
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = amt4.ToString("#0.00");
                 }
                 else
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = "0.00";
                 }
                 dt1.Rows.Add();
                 dt1.Rows[dt1.Rows.Count - 1]["trantype"] = "OI";
                 if (dt.Columns.Contains("OI"))
                 {
                     if (!string.IsNullOrEmpty(dt.Rows[0]["OI"].ToString()))
                     {
                         amt5 = (Convert.ToDouble(dt.Rows[0]["OI"].ToString()));
                     }
                 }
                 if (amt5 >= 0)
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = amt5.ToString("#0.00");
                 }
                 else
                 {
                     dt1.Rows[dt1.Rows.Count - 1]["jobclosed"] = "0.00";
                 }
                 foreach (DataRow dtrow in dt1.Rows)
                 {
                     countrydetails details = new countrydetails();
                     details.Countryname = dtrow[0].ToString();
                     details.Total = Convert.ToDouble(dtrow[1]);
                     dataList.Add(details);

                 }


             }
             return dataList;
             */



            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            DataTable dtemptyfree = new DataTable();
            DataAccess.Accounts.Recipts objReceipt = new DataAccess.Accounts.Recipts();

            dtemptyfree = objReceipt.getcustloginchart4homenew(Convert.ToInt32(HttpContext.Current.Session["webgroupid"]));
            List<countrydetails> dataList = new List<countrydetails>();
            //foreach (DataRow dtrow in dtemptyfree.Rows)
            //{
            //    countrydetails details = new countrydetails();
            //    details.Countryname = dtrow[0].ToString();
            //    details.Total = Convert.ToInt32(dtrow[1]);
            //    dataList.Add(details);
            //}
            return dataList;
        }

        public class countrydetails
        {
            public string Countryname { get; set; }
            public Double Total { get; set; }
        }

        protected void bookingic_Click(object sender, EventArgs e)
        {
            Response.Redirect("Booking.aspx?uid=" + str);
        }

        protected void lnk_OceanExpor_Click(object sender, EventArgs e)
        {

            //Response.Redirect("FIEBLInfo.aspx?uid=" + str + "&Trantype=FE");
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "FE";
            //lblbk.InnerText = "Booking";
            //lblstuf.InnerText = "Stuffing";
            //lblsail.InnerText = "Sailed";
            //lbltran.InnerText = "Transhipped";
            //lblDocon.InnerText = "DO Confirm Request";
            //lblDoconfirmed.InnerText = "DO Confirmed";
            //lblOrig.Visible = false;
            //lblrel.Visible = false;
            //lbljob.Visible = false;

            //Originaldocsenton.Visible = false;
            //releasedon.Visible = false;
            //jodate1.Visible = false;

            //LblBookingDate.InnerText = "";
            //LblStuffingDate.InnerText = "";
            //LblSailingDate.InnerText = "";
            //LblTranshipmentDate.InnerText = "";
            //LblDOConfirmReqDate.InnerText = "";
            //LblDOConfirmedDate.InnerText = "";
            //LblOriginaldocsentonDate.InnerText = "";
            //lblreleasedondate.InnerText = "";
            //lbljobDte.InnerText = "";
            //txt_bookingno.Text = "";

            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";






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
            //  Div4.Attributes["class"] = "Round12";


            lblClear1.Visible = true;
            lbltran1.Visible = true;
            lblcargo1.Visible = true;
            lblOrig.Visible = true;

            lblrel.Visible = true;

            lbljob.Visible = true;

            lbldel1.Visible = true;

            lblDoconfirmed1.Visible = true;

            lblreleasedonon1.Visible = true;

           // lbljobon1.Visible = true;

            lblbk.InnerText = "Booking";
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";

            lbljobon1.InnerText = "Container Gate in";
            lbljobDte.InnerText = "";


            // RoundHeight1.Attributes["class"] = "RoundHeight1";








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
            txt_bookingno.Text = "";
            Div4.Visible = false;
            lbljobon1.Visible = false;










            ifrmaster.Attributes["src"] = "FIEBLInfo.aspx?uid=" + str + "&Trantype=FE";
            QuickViewClear();
        }
        protected void lnk_OceanImport_Click(object sender, EventArgs e)
        {
            //Response.Redirect("FIEBLInfo.aspx?uid=" + str + "&Trantype=FI");
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "FI";
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

            txt_bookingno.Text = "";

            RBooking.Attributes["class"] = "Round";
            RStuffing.Attributes["class"] = "Round1";
            RSailling.Attributes["class"] = "Round2";
            RTranshipment.Attributes["class"] = "Round3";

            RDOReq.Attributes["class"] = "Round4";
            RDOCofirm.Attributes["class"] = "Round5";
            */


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
            txt_bookingno.Text = "";
            Div4.Visible = true;
            lbljobon1.Visible = true;
            ifrmaster.Attributes["src"] = "FIEBLInfo.aspx?uid=" + str + "&Trantype=FI";
            QuickViewClear();
        }
        protected void lnk_AirImport_Click(object sender, EventArgs e)
        {
            //Response.Redirect("FIEBLInfo.aspx?uid=" + str + "&Trantype=AI");
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "AI";
            Div4.Visible = true;
            
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

            txt_bookingno.Text = "";
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

            txt_bookingno.Text = "";
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


            ifrmaster.Attributes["src"] = "FIEBLInfo.aspx?uid=" + str + "&Trantype=AI";
            QuickViewClear();
        }
        protected void lnk_AirExport_Click(object sender, EventArgs e)
        {
            //Response.Redirect("FIEBLInfo.aspx?uid=" + str + "&Trantype=AE");
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "AE";
            Div4.Visible = true;
            
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

            txt_bookingno.Text = "";


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

            txt_bookingno.Text = "";


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


            ifrmaster.Attributes["src"] = "FIEBLInfo.aspx?uid=" + str + "&Trantype=AE";
            QuickViewClear();
        }
        protected void lnk_eBL_Click(object sender, EventArgs e)
        {
            //Response.Redirect("eBL.aspx?uid=" + str);

            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = null;
            //lblbk.InnerText = "Booking";
            //lblstuf.InnerText = "Stuffing";
            //lblsail.InnerText = "Sailed";
            //lbltran.InnerText = "Transhipped";
            //lblDocon.InnerText = "DO Confirm Request";
            //lblDoconfirmed.InnerText = "DO Confirmed";
            //lblOrig.Visible = false;
            //lblrel.Visible = false;
            //lbljob.Visible = false;

            //Originaldocsenton.Visible = false;
            //releasedon.Visible = false;
            //jodate1.Visible = false;

            //LblBookingDate.InnerText = "";
            //LblStuffingDate.InnerText = "";
            //LblSailingDate.InnerText = "";
            //LblTranshipmentDate.InnerText = "";
            //LblDOConfirmReqDate.InnerText = "";
            //LblDOConfirmedDate.InnerText = "";
            //LblOriginaldocsentonDate.InnerText = "";
            //lblreleasedondate.InnerText = "";
            //lbljobDte.InnerText = "";
            //txt_bookingno.Text = "";

            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";


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
            //  Div4.Attributes["class"] = "Round12";


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
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";

            lbljobon1.InnerText = "Container Gate in";
            lbljobDte.InnerText = "";


            // RoundHeight1.Attributes["class"] = "RoundHeight1";








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
            txt_bookingno.Text = "";
            Div4.Visible = false;
            lbljobon1.Visible = false;



            ifrmaster.Attributes["src"] = "eBL.aspx?uid=" + str;
            QuickViewClear();
        }
        protected void lnk_InvocieDebitNote_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Invoice.aspx?uid=" + str);
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = null;
            //lblbk.InnerText = "Booking";
            //lblstuf.InnerText = "Stuffing";
            //lblsail.InnerText = "Sailed";
            //lbltran.InnerText = "Transhipped";
            //lblDocon.InnerText = "DO Confirm Request";
            //lblDoconfirmed.InnerText = "DO Confirmed";
            //lblOrig.Visible = false;
            //lblrel.Visible = false;
            //lbljob.Visible = false;

            //Originaldocsenton.Visible = false;
            //releasedon.Visible = false;
            //jodate1.Visible = false;


            //lblClear1.Visible = false;

            //LblBookingDate.InnerText = "";
            //LblStuffingDate.InnerText = "";
            //LblSailingDate.InnerText = "";
            //LblTranshipmentDate.InnerText = "";
            //LblDOConfirmReqDate.InnerText = "";
            //LblDOConfirmedDate.InnerText = "";
            //LblOriginaldocsentonDate.InnerText = "";
            //lblreleasedondate.InnerText = "";
            //lbljobDte.InnerText = "";
            //txt_bookingno.Text = "";

            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";


            Div4.Visible = false;
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
            //  Div4.Attributes["class"] = "Round12";


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
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
            lbljobDte.InnerText = "";

            // RoundHeight1.Attributes["class"] = "RoundHeight1";








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
            txt_bookingno.Text = "";
            Div4.Visible = false;
            lbljobon1.Visible = false;
            ifrmaster.Attributes["src"] = "Invoice.aspx?uid=" + str;
            QuickViewClear();
        }
        protected void lnk_Receipts_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Receipt.aspx?uid=" + str);
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = null;
            //lblbk.InnerText = "Booking";
            //lblstuf.InnerText = "Stuffing";
            //lblsail.InnerText = "Sailed";
            //lbltran.InnerText = "Transhipped";
            //lblDocon.InnerText = "DO Confirm Request";
            //lblDoconfirmed.InnerText = "DO Confirmed";
            //lblOrig.Visible = false;
            //lblrel.Visible = false;
            //lbljob.Visible = false;

            //Originaldocsenton.Visible = false;
            //releasedon.Visible = false;
            //jodate1.Visible = false;

            //LblBookingDate.InnerText = "";
            //LblStuffingDate.InnerText = "";
            //LblSailingDate.InnerText = "";
            //LblTranshipmentDate.InnerText = "";
            //LblDOConfirmReqDate.InnerText = "";
            //LblDOConfirmedDate.InnerText = "";
            //LblOriginaldocsentonDate.InnerText = "";
            //lblreleasedondate.InnerText = "";
            //lbljobDte.InnerText = "";
            //txt_bookingno.Text = "";

            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";

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
            //  Div4.Attributes["class"] = "Round12";


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
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";

            lbljobon1.InnerText = "Container Gate in";
            lbljobDte.InnerText = "";



            // RoundHeight1.Attributes["class"] = "RoundHeight1";








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
            txt_bookingno.Text = "";
            Div4.Visible = false;
            lbljobon1.Visible = false;




            ifrmaster.Attributes["src"] = "Receipt.aspx?uid=" + str;
            QuickViewClear();
        }
        protected void lnk_Ledger_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Ledger.aspx?uid=" + str);
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = null;
            //lblbk.InnerText = "Booking";
            //lblstuf.InnerText = "Stuffing";
            //lblsail.InnerText = "Sailed";
            //lbltran.InnerText = "Transhipped";
            //lblDocon.InnerText = "DO Confirm Request";
            //lblDoconfirmed.InnerText = "DO Confirmed";
            //lblOrig.Visible = false;
            //lblrel.Visible = false;
            //lbljob.Visible = false;

            //Originaldocsenton.Visible = false;
            //releasedon.Visible = false;
            //jodate1.Visible = false;

            //LblBookingDate.InnerText = "";
            //LblStuffingDate.InnerText = "";
            //LblSailingDate.InnerText = "";
            //LblTranshipmentDate.InnerText = "";
            //LblDOConfirmReqDate.InnerText = "";
            //LblDOConfirmedDate.InnerText = "";
            //LblOriginaldocsentonDate.InnerText = "";
            //lblreleasedondate.InnerText = "";
            //lbljobDte.InnerText = "";
            //txt_bookingno.Text = "";

            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";


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

           // lbljobon1.Visible = false;
            lblbk.InnerText = "Booking";
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
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
            lbljobon1.Visible = false;

            ifrmaster.Attributes["src"] = "Ledger.aspx?uid=" + str;
            // ifrmaster.Attributes["src"] = "Ebookingdetails.aspx?uid=" + str;
            QuickViewClear();
        }
        protected void lnk_Outstanidng_Click(object sender, EventArgs e)
        {
            //Response.Redirect("OS.aspx?uid=" + str);
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = null;
            //lblbk.InnerText = "Booking";
            //lblstuf.InnerText = "Stuffing";
            //lblsail.InnerText = "Sailed";
            //lbltran.InnerText = "Transhipped";
            //lblDocon.InnerText = "DO Confirm Request";
            //lblDoconfirmed.InnerText = "DO Confirmed";
            //lblOrig.Visible = false;
            //lblrel.Visible = false;
            //lbljob.Visible = false;

            //Originaldocsenton.Visible = false;
            //releasedon.Visible = false;
            //jodate1.Visible = false;

            //LblBookingDate.InnerText = "";
            //LblStuffingDate.InnerText = "";
            //LblSailingDate.InnerText = "";
            //LblTranshipmentDate.InnerText = "";
            //LblDOConfirmReqDate.InnerText = "";
            //LblDOConfirmedDate.InnerText = "";
            //LblOriginaldocsentonDate.InnerText = "";
            //lblreleasedondate.InnerText = "";
            //lbljobDte.InnerText = "";
            //txt_bookingno.Text = "";

            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";



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
            lblbk.InnerText = "Booking";
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
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
            lbljobon1.Visible = false;





            ifrmaster.Attributes["src"] = "OS.aspx?uid=" + str;
            QuickViewClear();
        }
        protected void lnk_chgpwd_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ChangePassword.aspx");
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            //lblbk.InnerText = "Booking";
            //lblstuf.InnerText = "Stuffing";
            //lblsail.InnerText = "Sailed";
            //lbltran.InnerText = "Transhipped";
            //lblDocon.InnerText = "DO Confirm Request";
            //lblDoconfirmed.InnerText = "DO Confirmed";
            //lblOrig.Visible = false;
            //lblrel.Visible = false;
            //lbljob.Visible = false;

            //Originaldocsenton.Visible = false;
            //releasedon.Visible = false;
            //jodate1.Visible = false;

            //LblBookingDate.InnerText = "";
            //LblStuffingDate.InnerText = "";
            //LblSailingDate.InnerText = "";
            //LblTranshipmentDate.InnerText = "";
            //LblDOConfirmReqDate.InnerText = "";
            //LblDOConfirmedDate.InnerText = "";
            //LblOriginaldocsentonDate.InnerText = "";
            //lblreleasedondate.InnerText = "";
            //lbljobDte.InnerText = "";
            //txt_bookingno.Text = "";

            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";


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
            //  Div4.Attributes["class"] = "Round12";


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
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
            lbljobDte.InnerText = "";


            // RoundHeight1.Attributes["class"] = "RoundHeight1";








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
            txt_bookingno.Text = "";
            Div4.Visible = false;
            lbljobon1.Visible = false;




            ifrmaster.Attributes["src"] = "ChangePassword.aspx";
            QuickViewClear();
        }

        public string ConvertDate(string strSource)
        {
            string strTemp = "";
            string[] datSrc = strSource.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            strTemp = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return strTemp;
        }

        protected void linkFE_Click(object sender, EventArgs e)
        {
            //Session["Trantype"] = "FE";
            //ShipmentviewClear();
            //GetBookingStstus();

            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "FE";

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
          //  Div4.Attributes["class"] = "Round12";


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
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
            lbljobDte.InnerText = "";


           // RoundHeight1.Attributes["class"] = "RoundHeight1";

            






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
            txt_bookingno.Text = "";
            Div4.Visible = false;
            lbljobon1.Visible = false;
            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";

            ifrmaster.Attributes["src"] = "QuickViewInfo.aspx?uid=" + str + "&Trantype=FE";
            QuickViewClear();
        }

        protected void linkFI_Click(object sender, EventArgs e)
        {
            //Session["Trantype"] = "FI";
            //ShipmentviewClear();
            //GetBookingStstus();
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "FI";
            RoundHeight1.Attributes["class"] = "RoundHeight1";
           /* lblbk.InnerText = "Booking";
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

            txt_bookingno.Text = "";

            RBooking.Attributes["class"] = "Round";
            RStuffing.Attributes["class"] = "Round1";
            RSailling.Attributes["class"] = "Round2";
            RTranshipment.Attributes["class"] = "Round3";

            RDOReq.Attributes["class"] = "Round4";
            RDOCofirm.Attributes["class"] = "Round5";*/

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
            txt_bookingno.Text = "";
            Div4.Visible = true;
            lbljobon1.Visible = true;

            ifrmaster.Attributes["src"] = "QuickViewInfo.aspx?uid=" + str + "&Trantype=FI";
        }

        protected void linkAE_Click(object sender, EventArgs e)
        {
            //Session["Trantype"] = "AE";
            //ShipmentviewClear();
            //GetBookingStstus();
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "AE";

            Div4.Visible = true;
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

            txt_bookingno.Text = "";


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



            ifrmaster.Attributes["src"] = "QuickViewInfo.aspx?uid=" + str + "&Trantype=AE";
        }

        protected void linkAI_Click1(object sender, EventArgs e)
        {
            //Session["Trantype"] = "AI";
            //ShipmentviewClear();
            //GetBookingStstus();
            Div4.Visible = true;
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "AI";
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

            txt_bookingno.Text = "";
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


            ifrmaster.Attributes["src"] = "QuickViewInfo.aspx?uid=" + str + "&Trantype=AI";
        }

        public void QuickViewClear()
        {
            ifrmaster.Visible = true;
        }
        public void ShipmentviewClear()
        {
            ifrmaster.Visible = false;

        }
        //New 
        protected void txt_bookingno_TextChanged(object sender, EventArgs e)
        {
            //if (txt_bookingno.Text.Trim().Length >= 14)
            //{
            DataTable dt = new DataTable();

            DataAccess.ForwardingExports.PODetails bookingtran = new DataAccess.ForwardingExports.PODetails();
            Session["Trantype"] = bookingtran.getbookingdetailsnew(txt_bookingno.Text);
            if (Session["Trantype"] != null)
            {



                if (Session["Trantype"].ToString() == "FE")
                {
                    lblbk.InnerText = "Booking";
                    lblsail.InnerText = "Container Gate Out";
                    lblstuf.InnerText = "Stuffing";
                    lblClear.InnerText = "Container Port In";
                    lbltran.InnerText = "Sailing";
                    lblcargo.InnerText = "BL Released On";
                    lblDocon.InnerText = "T/S (If Any)";
                    lblarr.InnerText = "CAN Sent On";
                    lblOriginaldocsenton.InnerText = "Arrival";
                    lbldel.InnerText = "Container Port Out";

                    lblDoconfirmed.InnerText = "Destuffing";
                    lblreleasedonon.InnerText = "DO Issued On";
                    lbljobon1.InnerText = "Container Gate in";
                    lbljobDte.InnerText = "";
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
                    lblrel.Visible=true;

                    lbljob.Visible = true;

                    lbldel1.Visible=true;
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
                    lblsail.InnerText = "Container Gate Out";
                    lblstuf.InnerText = "Stuffing";
                    lblClear.InnerText = "Container Port In";
                    lbltran.InnerText = "Sailing";
                    lblcargo.InnerText = "BL Released On";
                    lblDocon.InnerText = "T/S (If Any)";
                    lblarr.InnerText = "CAN Sent On";
                    lblOriginaldocsenton.InnerText = "Arrival";
                    lbldel.InnerText = "Container Port Out";

                    lblDoconfirmed.InnerText = "Destuffing";
                    lblreleasedonon.InnerText = "DO Issued On";
                    lbljobon1.InnerText = "Container Gate in";
                    lbljobDte.InnerText = "";

                    Div4.Visible = false;
                    lbljobon1.Visible = false;
                   // RoundHeight1.Attributes["class"] = "RoundHeight1";


             


                    dt = cusobj.CusloginBookingStatus(txt_bookingno.Text, Convert.ToInt32(Session["webgroupid"]));
                    if (dt.Rows.Count > 0)
                    {

                        if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["ContainerGateOutdate"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["ContainerGateOutdate"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor1";
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["Stuffingdate"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["Stuffingdate"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor2";
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["ContainerPortIndate"].ToString() != "")
                        {
                            lblCleardate.InnerText = dt.Rows[0]["ContainerPortIndate"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";
                        }
                        else
                        {
                            lblCleardate.InnerText = "";
                        }
                        if (dt.Rows[0]["Sailingdate"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["Sailingdate"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";
                        }
                        if (dt.Rows[0]["BLReleasedOndate"].ToString() != "")
                        {
                            lblcargodate.InnerText = dt.Rows[0]["BLReleasedOndate"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";
                        }
                        else
                        {
                            lblcargodate.InnerText = "";
                        }

                      /*  if (dt.Rows[0]["lcsenton"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["lcsenton"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";
                        }*/

                        if (dt.Rows[0]["TSifanydate"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["TSifanydate"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";
                        }

                                
 
   
   
  
  
  
//ContainerGateindate

                        if (dt.Rows[0]["CANSentOndate"].ToString() != "")
                        {
                            lblarrdate.InnerText = dt.Rows[0]["CANSentOndate"].ToString();
                          releasedon.Attributes["class"] = "Roundcolor7";
                        }
                        else
                        {
                            lblarrdate.InnerText = "";
                        }

                        if (dt.Rows[0]["Arrivaldate"].ToString() != "")
                        {
                            LblOriginaldocsentonDate.InnerText = dt.Rows[0]["Arrivaldate"].ToString();
                           jodate1.Attributes["class"] = "Roundcolor8";
                        }
                        else
                        {
                            LblOriginaldocsentonDate.InnerText = "";
                        }

                        if (dt.Rows[0]["ContainerPortOutdate"].ToString() != "")
                        {
                            lbldeldate.InnerText = dt.Rows[0]["ContainerPortOutdate"].ToString();
                           Div1.Attributes["class"] = "Roundcolor9";
                        }
                        else
                        {
                            lbldeldate.InnerText = "";
                        }

                        if (dt.Rows[0]["Destuffingdate"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["Destuffingdate"].ToString();
                            Div2.Attributes["class"] = "Roundcolor10";
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";
                        }

                        if (dt.Rows[0]["DOIssuedOndate"].ToString() != "")
                        {
                            lblreleasedondate.InnerText = dt.Rows[0]["DOIssuedOndate"].ToString();
                            Div3.Attributes["class"] = "Roundcolor11";
                        }
                        else
                        {
                            lblreleasedondate.InnerText = "";
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
                    


                    dt = cusobj.CusloginBookingStatus(txt_bookingno.Text, Convert.ToInt32(Session["webgroupid"]));
                    if (dt.Rows.Count > 0)
                    {

                      /*  if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["destuffedon"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["destuffedon"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor1";
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["devanningrecon"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["devanningrecon"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor2";
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["refundrecon"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["refundrecon"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";
                        }
                        if (dt.Rows[0]["doissuedon"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["doissuedon"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";
                        }
                        if (dt.Rows[0]["jobdate"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["jobdate"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";
                        }*/



                        if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["originon"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["originon"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor1";
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["draftconfir"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["draftconfir"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor2";
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["vesseldepar"].ToString() != "")
                        {
                            lblCleardate.InnerText = dt.Rows[0]["vesseldepar"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";
                        }
                        else
                        {
                            lblCleardate.InnerText = "";
                        }
                        if (dt.Rows[0]["prealertsenton"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["prealertsenton"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";
                        }
                        if (dt.Rows[0]["transarrive"].ToString() != "")
                        {
                            lblcargodate.InnerText = dt.Rows[0]["transarrive"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";
                        }
                        else
                        {
                            lblcargodate.InnerText = "";
                        }


                        if (dt.Rows[0]["transdepart"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["transdepart"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";
                        }

                        if (dt.Rows[0]["vesselarrivepod"].ToString() != "")
                        {
                            lblarrdate.InnerText = dt.Rows[0]["vesselarrivepod"].ToString();
                            releasedon.Attributes["class"] = "Roundcolor7";
                        }
                        else
                        {
                            lblarrdate.InnerText = "";
                        }

                        if (dt.Rows[0]["desticfsarrival"].ToString() != "")
                        {
                            LblOriginaldocsentonDate.InnerText = dt.Rows[0]["desticfsarrival"].ToString();
                            jodate1.Attributes["class"] = "Roundcolor8";
                        }
                        else
                        {
                            LblOriginaldocsentonDate.InnerText = "";
                        }

                        if (dt.Rows[0]["cargodestuff"].ToString() != "")
                        {
                            lbldeldate.InnerText = dt.Rows[0]["cargodestuff"].ToString();
                            Div1.Attributes["class"] = "Roundcolor9";
                        }
                        else
                        {
                            lbldeldate.InnerText = "";
                        }

                        if (dt.Rows[0]["deliorderstatus"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["deliorderstatus"].ToString();
                            Div2.Attributes["class"] = "Roundcolor10";
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";
                        }

                        if (dt.Rows[0]["cargodeli"].ToString() != "")
                        {
                            lblreleasedondate.InnerText = dt.Rows[0]["cargodeli"].ToString();
                            Div3.Attributes["class"] = "Roundcolor11";
                        }
                        else
                        {
                            lblreleasedondate.InnerText = "";
                        }

                        if (dt.Rows[0]["empcontreturn"].ToString() != "")
                        {
                            lbljobDte.InnerText = dt.Rows[0]["empcontreturn"].ToString();
                            Div4.Attributes["class"] = "Roundcolor12";
                        }
                        else
                        {
                            lbljobDte.InnerText = "";
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
                    dt = cusobj.CusloginBookingStatus(txt_bookingno.Text, Convert.ToInt32(Session["webgroupid"]));
                    if (dt.Rows.Count > 0)
                    {
                        

                        if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["Nomrecon"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["Nomrecon"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor1";
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["Pickupon"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["Pickupon"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor2";
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";
                        }


                        if (dt.Rows[0]["flightdate"].ToString() != "")
                        {
                            lblCleardate.InnerText = dt.Rows[0]["flightdate"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";
                        }
                        else
                        {
                            lblCleardate.InnerText = "";
                        }


                        if (dt.Rows[0]["docrecon"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["docrecon"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";
                        }

                        if (dt.Rows[0]["warehousearron"].ToString() != "")
                        {
                            lblcargodate.InnerText = dt.Rows[0]["warehousearron"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";
                        }
                        else
                        {
                            lblcargodate.InnerText = "";
                        }


                        if (dt.Rows[0]["prealsenton"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["prealsenton"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";
                        }

                        if (dt.Rows[0]["arrivalon"].ToString() != "")
                        {
                            lblarrdate.InnerText = dt.Rows[0]["arrivalon"].ToString();
                            releasedon.Attributes["class"] = "Roundcolor7";
                        }
                        else
                        {
                            lblarrdate.InnerText = "";
                        }


                        if (dt.Rows[0]["Originaldocsenton"].ToString() != "")
                        {
                            LblOriginaldocsentonDate.InnerText = dt.Rows[0]["Originaldocsenton"].ToString();
                            jodate1.Attributes["class"] = "Roundcolor8";
                        }
                        else
                        {
                            LblOriginaldocsentonDate.InnerText = "";
                        }


                        if (dt.Rows[0]["deliveryupdon"].ToString() != "")
                        {
                            lbldeldate.InnerText = dt.Rows[0]["deliveryupdon"].ToString();
                            Div1.Attributes["class"] = "Roundcolor9";
                        }
                        else
                        {
                            lbldeldate.InnerText = "";
                        }



                        if (dt.Rows[0]["invoicesenton"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["invoicesenton"].ToString();
                            Div2.Attributes["class"] = "Roundcolor10";
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";
                        }




                        if (dt.Rows[0]["releasedon"].ToString() != "")
                        {
                            lblreleasedondate.InnerText = dt.Rows[0]["releasedon"].ToString();
                            Div3.Attributes["class"] = "Roundcolor11";
                        }
                        else
                        {
                            lblreleasedondate.InnerText = "";
                        }

                        if (dt.Rows[0]["jobdate"].ToString() != "")
                        {
                            lbljobDte.InnerText = dt.Rows[0]["jobdate"].ToString();
                            Div4.Attributes["class"] = "Roundcolor12";
                        }
                        else
                        {
                            lbljobDte.InnerText = "";
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



                       
                            LblBookingDate.InnerText ="";
                            RBooking.Attributes["class"] = "Round";                       
                        
                            LblStuffingDate.InnerText = "";
                            RStuffing.Attributes["class"] = "Round1";                       
                        
                            LblSailingDate.InnerText = "";
                            RSailling.Attributes["class"] = "Round2";                 
                                              
                            lblCleardate.InnerText = "";
                            RTranshipment.Attributes["class"] = "Round3";
                                           
                            LblTranshipmentDate.InnerText ="";
                            RDOReq.Attributes["class"] = "Round4";                       

                        
                            lblcargodate.InnerText ="";
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



                    dt = cusobj.CusloginBookingStatus(txt_bookingno.Text, Convert.ToInt32(Session["webgroupid"]));
                    if (dt.Rows.Count > 0)
                    {


                        if (dt.Rows[0]["bookingdate"].ToString() != "")
                        {
                            LblBookingDate.InnerText = dt.Rows[0]["bookingdate"].ToString();
                            RBooking.Attributes["class"] = "Roundcolor";
                        }
                        else
                        {
                            LblBookingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["Nomrecon"].ToString() != "")
                        {
                            LblStuffingDate.InnerText = dt.Rows[0]["Nomrecon"].ToString();
                            RStuffing.Attributes["class"] = "Roundcolor2";
                        }
                        else
                        {
                            LblStuffingDate.InnerText = "";
                        }
                        if (dt.Rows[0]["Pickupon"].ToString() != "")
                        {
                            LblSailingDate.InnerText = dt.Rows[0]["Pickupon"].ToString();
                            RSailling.Attributes["class"] = "Roundcolor1";
                        }
                        else
                        {
                            LblSailingDate.InnerText = "";
                        }


                        if (dt.Rows[0]["flightdate"].ToString() != "")
                        {
                            lblcargodate.InnerText = dt.Rows[0]["flightdate"].ToString();
                            RDOCofirm.Attributes["class"] = "Roundcolor5";
                        }
                        else
                        {
                            lblcargodate.InnerText = "";
                        }


                        if (dt.Rows[0]["docrecon"].ToString() != "")
                        {
                            LblTranshipmentDate.InnerText = dt.Rows[0]["docrecon"].ToString();
                            RDOReq.Attributes["class"] = "Roundcolor4";
                        }
                        else
                        {
                            LblTranshipmentDate.InnerText = "";
                        }

                        if (dt.Rows[0]["Cargoairheadoveron"].ToString() != "")
                        {
                            lblCleardate.InnerText = dt.Rows[0]["Cargoairheadoveron"].ToString();
                            RTranshipment.Attributes["class"] = "Roundcolor3";
                        }
                        else
                        {
                            lblCleardate.InnerText = "";
                        }


                        if (dt.Rows[0]["prealsenton"].ToString() != "")
                        {
                            LblDOConfirmReqDate.InnerText = dt.Rows[0]["prealsenton"].ToString();
                            Originaldocsenton.Attributes["class"] = "Roundcolor6";
                        }
                        else
                        {
                            LblDOConfirmReqDate.InnerText = "";
                        }

                        if (dt.Rows[0]["arrivalon"].ToString() != "")
                        {
                            lblarrdate.InnerText = dt.Rows[0]["arrivalon"].ToString();
                            releasedon.Attributes["class"] = "Roundcolor7";
                        }
                        else
                        {
                            lblarrdate.InnerText = "";
                        }


                        if (dt.Rows[0]["Originaldocsenton"].ToString() != "")
                        {
                            LblOriginaldocsentonDate.InnerText = dt.Rows[0]["Originaldocsenton"].ToString();
                            jodate1.Attributes["class"] = "Roundcolor8";
                        }
                        else
                        {
                            LblOriginaldocsentonDate.InnerText = "";
                        }


                        if (dt.Rows[0]["deliveryupdon"].ToString() != "")
                        {
                            lbldeldate.InnerText = dt.Rows[0]["deliveryupdon"].ToString();
                            Div1.Attributes["class"] = "Roundcolor9";
                        }
                        else
                        {
                            lbldeldate.InnerText = "";
                        }



                        if (dt.Rows[0]["invoicesenton"].ToString() != "")
                        {
                            LblDOConfirmedDate.InnerText = dt.Rows[0]["invoicesenton"].ToString();
                            Div2.Attributes["class"] = "Roundcolor10";
                        }
                        else
                        {
                            LblDOConfirmedDate.InnerText = "";
                        }


                        if (dt.Rows[0]["doissuedon"].ToString() != "")
                        {
                            lblreleasedondate.InnerText = dt.Rows[0]["doissuedon"].ToString();
                            Div3.Attributes["class"] = "Roundcolor11";
                        }
                        else
                        {
                            lblreleasedondate.InnerText = "";
                        }

                        if (dt.Rows[0]["jobdate"].ToString() != "")
                        {
                            lbljobDte.InnerText = dt.Rows[0]["jobdate"].ToString();
                            Div4.Attributes["class"] = "Roundcolor12";
                        }
                        else
                        {
                            lbljobDte.InnerText = "";
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

                       
                            LblBookingDate.InnerText = "";
                            RBooking.Attributes["class"] = "Round";                       
                      
                            LblStuffingDate.InnerText = "";
                            RStuffing.Attributes["class"] = "Round1";                       
                     
                            LblSailingDate.InnerText ="";
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

        protected void lnk_ebooking_Click(object sender, EventArgs e)
        {
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "FE";
            //lblbk.InnerText = "Booking";
            //lblstuf.InnerText = "Stuffing";
            //lblsail.InnerText = "Sailed";
            //lbltran.InnerText = "Transhipped";
            //lblDocon.InnerText = "DO Confirm Request";
            //lblDoconfirmed.InnerText = "DO Confirmed";
            //lblOrig.Visible = false;
            //lblrel.Visible = false;
            //lbljob.Visible = false;

            //Originaldocsenton.Visible = false;
            //releasedon.Visible = false;
            //jodate1.Visible = false;

            //LblBookingDate.InnerText = "";
            //LblStuffingDate.InnerText = "";
            //LblSailingDate.InnerText = "";
            //LblTranshipmentDate.InnerText = "";
            //LblDOConfirmReqDate.InnerText = "";
            //LblDOConfirmedDate.InnerText = "";
            //LblOriginaldocsentonDate.InnerText = "";
            //lblreleasedondate.InnerText = "";
            //lbljobDte.InnerText = "";
            //txt_bookingno.Text = "";

            //RoundHeight1.Attributes["class"] = "RoundHeight1";

            //RBooking.Attributes["class"] = "Round";
            //RStuffing.Attributes["class"] = "Round1";
            //RSailling.Attributes["class"] = "Round2";
            //RTranshipment.Attributes["class"] = "Round3";

            //RDOReq.Attributes["class"] = "Round4";
            //RDOCofirm.Attributes["class"] = "Round5";




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
            //  Div4.Attributes["class"] = "Round12";


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
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
            lbljobDte.InnerText = "";



            // RoundHeight1.Attributes["class"] = "RoundHeight1";








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
            txt_bookingno.Text = "";
            Div4.Visible = false;
            lbljobon1.Visible = false;

            ifrmaster.Attributes["src"] = "Ebookingdetails.aspx?uid=" + str + "&Trantype=FE";
            QuickViewClear();
        }

        protected void lnk_PO_Click(object sender, EventArgs e)
        {

            //   Session["LoginBranchid"] = "1";
            //Session["StrTranType"] = "FE";
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "FE";
            
            
            
            /*lblbk.InnerText = "Booking";
            lblstuf.InnerText = "Stuffing";
            lblsail.InnerText = "Sailed";
            lbltran.InnerText = "Transhipped";
            lblDocon.InnerText = "DO Confirm Request";
            lblDoconfirmed.InnerText = "DO Confirmed";
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
            txt_bookingno.Text = "";

            RoundHeight1.Attributes["class"] = "RoundHeight1";

            RBooking.Attributes["class"] = "Round";
            RStuffing.Attributes["class"] = "Round1";
            RSailling.Attributes["class"] = "Round2";
            RTranshipment.Attributes["class"] = "Round3";

            RDOReq.Attributes["class"] = "Round4";
            RDOCofirm.Attributes["class"] = "Round5";
            */
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

            lblbk.InnerText = "Booking";
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
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


            ifrmaster.Attributes["src"] = "../CRM/PoDtlswithContrCSnew.aspx?uid=" + str + "&Trantype=FE";

            // ifrmaster.Attributes["src"] = "../CRM/PoDtlswithContrCSnew.aspx?uid=" + str + "&Trantype=FE";
            QuickViewClear();
        }

        protected void lnk_CHA_Click(object sender, EventArgs e)
        {
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "FE";
            
            
            
            /*lblbk.InnerText = "Booking";
            lblstuf.InnerText = "Stuffing";
            lblsail.InnerText = "Sailed";
            lbltran.InnerText = "Transhipped";
            lblDocon.InnerText = "DO Confirm Request";
            lblDoconfirmed.InnerText = "DO Confirmed";
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
            txt_bookingno.Text = "";

            RoundHeight1.Attributes["class"] = "RoundHeight1";

            RBooking.Attributes["class"] = "Round";
            RStuffing.Attributes["class"] = "Round1";
            RSailling.Attributes["class"] = "Round2";
            RTranshipment.Attributes["class"] = "Round3";

            RDOReq.Attributes["class"] = "Round4";
            RDOCofirm.Attributes["class"] = "Round5";
            */
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

           // lbljobon1.Visible = false;


            lblbk.InnerText = "Booking";
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
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





            ifrmaster.Attributes["src"] = "FIEBLInfo.aspx?uid=" + str + "&Trantype=CH";
            QuickViewClear();
        }

     

        //protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        //{



        //}

        protected void GrdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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

                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trantype1 = "";
            string blno = "";
            string bid = "";
            int cusID = 0;
            string str = "";
            if (GrdDetails.Rows.Count > 0)
            {
                int index = GrdDetails.SelectedRow.RowIndex;
                trantype1 = GrdDetails.SelectedRow.Cells[12].Text;
                blno = GrdDetails.SelectedRow.Cells[9].Text;
                bid = GrdDetails.SelectedRow.Cells[11].Text;
                if (Session["str"] != null)
                {
                    str = Session["str"].ToString();
                }
                cusID = int.Parse(str.ToString());
                if (trantype1 == "FE")
                {
                    string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";


                    if (GrdDetails.Rows.Count > 0)
                    {
                      //str_RptName = "BL4PAN.rpt";
                      //  Session["str_sfs"] = "{FEBLDetails.blno}='" + blno.ToString() + "'" + "and {FEBLDetails.bid}=" + bid.ToString();
                      //  Session["LoginBranchid"] = bid.ToString();
                      //  DataAccess.Masters.MasterBranch objb = new DataAccess.Masters.MasterBranch();
                      //  str_sp = "location=" + objb.Getbranchname(Convert.ToInt32(GrdDetails.SelectedRow.Cells[9].Text)) + "~draft=Yes" + "~agent=Yes" + "~non=NO" + "~Doc=" + "FORWARDING PRIVATE LIMITED";
                      //  str_Script = "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                 

                       bid = GrdDetails.SelectedRow.Cells[11].Text;
                        Session["LoginBranchid"] = bid.ToString();
                        string blno2 = "";
                        string strTranType3 = "";
                        string bookingno = "";
                        strTranType3 = GrdDetails.SelectedRow.Cells[12].Text;
                        bookingno = GrdDetails.SelectedRow.Cells[3].Text;
                        // iframecost.Attributes["src"] = "AEIBLPrintNew.aspx";
                        iframecost.Attributes["src"] = "QuickView.aspx?uid=" + str + "&strTranType3=FE" + "&bookingno=" + bookingno;
                        popupfro.Visible = true;
                        PopupBL.Show();
                      
                    }

                    ScriptManager.RegisterStartupScript(GrdDetails, typeof(GridView), "BLRelease", str_Script, true);
                    switch (trantype1)
                    {
                        case "FE":
                            cusobj.InsWebCustLogDtl(cusID, DataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, blno.ToString() + " / BL View");
                            break;
                        case "FI":
                            cusobj.InsWebCustLogDtl(cusID, DataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, blno.ToString() + " / BL View");
                            break;
                        case "AE":
                            cusobj.InsWebCustLogDtl(cusID, DataAccess.RegCustomer.EventType.AirExports, DateTime.Now, blno.ToString() + " / BL View");
                            break;
                        case "AI":
                            cusobj.InsWebCustLogDtl(cusID, DataAccess.RegCustomer.EventType.AirImports, DateTime.Now, blno.ToString() + " / BL View");
                            break;
                    }
                }


                else if (trantype1 == "FI")
                {
                    string strTranType12 = "";
                    if (GrdDetails.Rows.Count > 0)
                    {
                        //strTranType12 = GrdDetails.SelectedRow.Cells[12].Text;
                        //iframecost.Attributes["src"] = "BLPrint.aspx";
                        //popupfro.Visible = true;
                        //PopupBL.Show();
                        //string blno1 = GrdDetails.SelectedRow.Cells[9].Text;
                        //Session["Blno"] = blno1.ToString();
                        //Session["Btrantype"] = strTranType12.ToString();
                        //bid = GrdDetails.SelectedRow.Cells[11].Text;
                        //Session["LoginBranchid"] = bid.ToString();
                       
                        bid = GrdDetails.SelectedRow.Cells[11].Text;
                        Session["LoginBranchid"] = bid.ToString();
                        string blno2 = "";
                        string strTranType3 = "";
                        string bookingno = "";
                        strTranType3 = GrdDetails.SelectedRow.Cells[12].Text;
                        bookingno = GrdDetails.SelectedRow.Cells[3].Text;
                        // iframecost.Attributes["src"] = "AEIBLPrintNew.aspx";
                        iframecost.Attributes["src"] = "QuickView.aspx?uid=" + str + "&strTranType3=FI" + "&bookingno=" + bookingno + "&status=" + GrdDetails.SelectedRow.Cells[1].Text;
                        popupfro.Visible = true;
                        PopupBL.Show();
                        
                        switch (strTranType12)
                        {
                            case "FE":
                                cusobj.InsWebCustLogDtl(cusID, DataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, Session["Blno"] + " / BL View");
                                break;
                            case "FI":
                                cusobj.InsWebCustLogDtl(cusID, DataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, Session["Blno"] + " / BL View");
                                break;
                            case "AE":
                                cusobj.InsWebCustLogDtl(cusID, DataAccess.RegCustomer.EventType.AirExports, DateTime.Now, Session["Blno"] + " / BL View");
                                break;
                            case "AI":
                                cusobj.InsWebCustLogDtl(cusID, DataAccess.RegCustomer.EventType.AirImports, DateTime.Now, Session["Blno"] + " / BL View");
                                break;
                        }
                    }
                }

                else if (trantype1 == "AI")
                {
                    if (GrdDetails.Rows.Count > 0)
                    {
                        //int index = GrdDetails.SelectedRow.RowIndex;
                      
                        
                        //bid = GrdDetails.SelectedRow.Cells[11].Text;
                        //Session["LoginBranchid"] = bid.ToString();
                        //string blno2 = "";
                        //string strTranType3 = "";
                        //strTranType3 = GrdDetails.SelectedRow.Cells[12].Text;
                        //iframecost.Attributes["src"] = "AEIBLPrintNew.aspx";
                        //popupfro.Visible = true;
                        //PopupBL.Show();
                        //blno2 = GrdDetails.SelectedRow.Cells[9].Text;
                        //string flight = GrdDetails.Rows[index].Cells[4].Text;
                        //Session["flight"] = flight.ToString();
                        //Session["Blno"] = blno2.ToString();
                        //Session["Btrantype"] = strTranType3.ToString();
                      
                        bid = GrdDetails.SelectedRow.Cells[11].Text;
                        Session["LoginBranchid"] = bid.ToString();
                        string blno2 = "";
                        string strTranType3 = "";
                        string bookingno = "";
                        strTranType3 = GrdDetails.SelectedRow.Cells[12].Text;
                        bookingno = GrdDetails.SelectedRow.Cells[3].Text;
                       // iframecost.Attributes["src"] = "AEIBLPrintNew.aspx";
                        iframecost.Attributes["src"] = "QuickView.aspx?uid=" + str + "&strTranType3=AI" + "&bookingno=" + bookingno;
                        popupfro.Visible = true;
                        PopupBL.Show();
                        
                        
                    }

                }
                else if (trantype1 == "AE")
                {
                    if (GrdDetails.Rows.Count > 0)
                    {
                        //int index = GrdDetails.SelectedRow.RowIndex;


                        //bid = GrdDetails.SelectedRow.Cells[11].Text;
                        //Session["LoginBranchid"] = bid.ToString();
                        //string blno2 = "";
                        //string strTranType3 = "";
                        //strTranType3 = GrdDetails.SelectedRow.Cells[12].Text;
                        //iframecost.Attributes["src"] = "AEIBLPrintNew.aspx";
                        //popupfro.Visible = true;
                        //PopupBL.Show();
                        //blno2 = GrdDetails.SelectedRow.Cells[9].Text;
                        //string flight = GrdDetails.Rows[index].Cells[4].Text;
                        //Session["flight"] = flight.ToString();
                        //Session["Blno"] = blno2.ToString();
                        //Session["Btrantype"] = strTranType3.ToString();

                        bid = GrdDetails.SelectedRow.Cells[11].Text;
                        Session["LoginBranchid"] = bid.ToString();
                        string blno2 = "";
                        string strTranType3 = "";
                        string bookingno = "";
                        strTranType3 = GrdDetails.SelectedRow.Cells[12].Text;
                        bookingno = GrdDetails.SelectedRow.Cells[3].Text;
                        // iframecost.Attributes["src"] = "AEIBLPrintNew.aspx";
                        iframecost.Attributes["src"] = "QuickView.aspx?uid=" + str + "&strTranType3=AE" + "&bookingno=" + bookingno;
                        popupfro.Visible = true;
                        PopupBL.Show();
                        

                    }

                }
               /* else
                {
               

                    ScriptManager.RegisterStartupScript(GrdDetails, typeof(GridView), "DataFound", "alertify.alert('No Data Found')", true);
                    return;
                }*/



            }
        }

        protected void Booked_Click(object sender, EventArgs e)
        {
           // Iframe1.Visible = true;
            string trantype = "";
            string booking1 = "";
            string Transit1 = "";
            string Closed1 = "";
            Paneln2.Visible = true;
         //   pnlCharge.Visible = false;
            DataTable dtnew = new DataTable();
            string booking2 = "";

            ModalPopupExtender1.Show();
            LinkButton Lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;


            Paneln2.Visible = true;




            string head = "";
            if (grd.Rows.Count > 0)
            {


                //int index = grd.SelectedRow.RowIndex;

                //Session[index] = grd.SelectedRow.RowIndex;
                //Bhuvana
                head = "Booked";

                //trantype = grd.SelectedRow.Cells[0].Text;

                //Label lbooking = (Label)grd.Rows[index].FindControl("Booked");              



                //Label lTransit = (Label)grd.Rows[index].FindControl("Transit");
                //Label lClosed = (Label)grd.Rows[index].FindControl("Closed");

                LinkButton lbooking = (LinkButton)row.FindControl("Booked");
                LinkButton lTransit = (LinkButton)row.FindControl("Transit");
                LinkButton lClosed = (LinkButton)row.FindControl("Closed");
                trantype = row.Cells[0].Text;

                booking1 = lbooking.Text;
                Transit1 = lTransit.Text;
                Closed1 = lClosed.Text;

                if (trantype == "Total")
                {

                    if (head == "Booked")
                    {
                        dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), "", "Booked");
                        if (dtnew.Rows.Count > 0)
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Booked";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = dtnew;
                            GrdDetails.DataBind();
                          //  GrdDetails.Columns[0].Visible = false;
                            GrdDetails.Columns[15].Visible = false;
                        }
                        else
                        {
                            div2_Bookchart.Visible = true;
                            div_bar.Visible = true;
                            Paneln2.Visible = false;
                           // pnlCharge.Visible = true;
                            grd.Visible = true;
                            booklinenew();
                            return;
                        }
                    }
                    else
                    {
                        div2_Bookchart.Visible = true;
                        div_bar.Visible = true;
                        Paneln2.Visible = false;
                      //  pnlCharge.Visible = true;
                        grd.Visible = true;
                        booklinenew();
                        return;
                    }

                }

                if (trantype == "Ocean Exports")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    trantype = "FE";
                }
                else if (trantype == "Ocean Imports")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    trantype = "FI";
                }
                else if (trantype == "Air Exports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    trantype = "AE";
                }
                else if (trantype == "Air Imports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    trantype = "AI";
                }
                else if (trantype == "Customs House Agent")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    trantype = "CH";
                }

                if (head == "Booked")
                {

                    if (trantype == "FE")
                    {
                        if (trantype == "FE" && booking1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Exports -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Exports -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }

                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Ocean Exports -Booked";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;

                            GrdDetails.Columns[15].Visible = false;
                        }
                        /*if (trantype == "FE" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }
                        if (trantype == "FE" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }
                        */
                    }
                    else if (trantype == "FI")
                    {
                        if (trantype == "FI" && booking1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Imports -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Imports -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;


                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Ocean Imports -Booked";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = true;


                            GrdDetails.Columns[15].Visible = false;
                        }


                        /*if (trantype == "FI" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }
                        if (trantype == "FI" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }*/
                    }
                    else if (trantype == "AE")
                    {
                        if (trantype == "AE" && booking1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Exports -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Exports -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Air Exports -Booked";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;

                            GrdDetails.Columns[15].Visible = false;
                        }


                        /*if (trantype == "AE" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }
                        if (trantype == "AE" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }*/



                    }
                    else if (trantype == "AI")
                    {
                        if (trantype == "AI" && booking1 != "0")
                        {


                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Imports -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Imports -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Air Imports -Booked";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = true;

                            GrdDetails.Columns[15].Visible = false;
                        }


                        /*  if (trantype == "AI" && Transit1 != "0")
                           {

                               dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                               if (dtnew.Rows.Count > 0)
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = dtnew;
                                   GrdDetails.DataBind();
                               }
                               else
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = new DataTable();
                                   GrdDetails.DataBind();
                               }


                           }
                          if (trantype == "AI" && Closed1 != "0")
                           {

                               dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                               if (dtnew.Rows.Count > 0)
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = dtnew;
                                   GrdDetails.DataBind();
                               }
                               else
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = new DataTable();
                                   GrdDetails.DataBind();
                               }


                           }

                           */
                    }
                    else if (trantype == "CH")
                    {
                        if (trantype == "CH" && booking1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Customs House Agent -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;

                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = false;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Customs House Agent -Booked";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = false;
                            }

                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Customs House Agent -Booked";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;

                            GrdDetails.Columns[15].Visible = false;
                        }
                    }
                    else
                    {

                    }

                }


            }
        }

        protected void Transit_Click(object sender, EventArgs e)
        {
          //  Iframe1.Visible = true;
            string trantype = "";
            string booking1 = "";
            string Transit1 = "";
            string Closed1 = "";
            Paneln2.Visible = true;
           // pnlCharge.Visible = false;
            DataTable dtnew = new DataTable();
            string booking2 = "";


            LinkButton Lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;



            ModalPopupExtender1.Show();

            Paneln2.Visible = true;




            string head = "";
            if (grd.Rows.Count > 0)
            {


                //int index = grd.SelectedRow.RowIndex;

                //Session[index] = grd.SelectedRow.RowIndex;
                //Bhuvana
                head = "Transit";

                //trantype = grd.SelectedRow.Cells[0].Text;

                //Label lbooking = (Label)grd.Rows[index].FindControl("Booked");              



                //Label lTransit = (Label)grd.Rows[index].FindControl("Transit");
                //Label lClosed = (Label)grd.Rows[index].FindControl("Closed");

                LinkButton lbooking = (LinkButton)row.FindControl("Booked");
                LinkButton lTransit = (LinkButton)row.FindControl("Transit");
                LinkButton lClosed = (LinkButton)row.FindControl("Closed");
                trantype = row.Cells[0].Text;

                booking1 = lbooking.Text;
                Transit1 = lTransit.Text;
                Closed1 = lClosed.Text;
                if (trantype == "Total")
                {
                    if (head == "Transit")
                    {

                        dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), "", "Transit");
                        if (dtnew.Rows.Count > 0)
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Transit";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = dtnew;
                            GrdDetails.DataBind();
                           // GrdDetails.Columns[0].Visible = false;
                            GrdDetails.Columns[15].Visible = false;
                        }
                        else
                        {

                            div2_Bookchart.Visible = true;
                            div_bar.Visible = true;
                            Paneln2.Visible = false;
                           // pnlCharge.Visible = true;
                            grd.Visible = true;
                            booklinenew();
                            return;
                        }
                    }
                    else
                    {

                        div2_Bookchart.Visible = true;
                        div_bar.Visible = true;
                        Paneln2.Visible = false;
                      //  pnlCharge.Visible = true;
                        grd.Visible = true;
                        booklinenew();
                        return;
                    }
                }
                if (trantype == "Ocean Exports")
                {
                  //  GrdDetails.Columns[0].Visible = true;
                    trantype = "FE";
                }
                else if (trantype == "Ocean Imports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    trantype = "FI";
                }
                else if (trantype == "Air Exports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    trantype = "AE";
                }
                else if (trantype == "Air Imports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    trantype = "AI";
                }
                else if (trantype == "Customs House Agent")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    Paneln2.Visible = false;
                    return;
                }
                if (head == "Transit")
                {

                    if (trantype == "FE")
                    {
                        /*  if (trantype == "FE" && booking1 != "0")
                          {

                              dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                              if (dtnew.Rows.Count > 0)
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = dtnew;
                                  GrdDetails.DataBind();
                              }
                              else
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = new DataTable();
                                  GrdDetails.DataBind();
                              }

                          }
                         */
                        if (trantype == "FE" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Exports -Transit";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Exports -Transit";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }

                        }

                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Ocean Exports -Transit";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;

                            GrdDetails.Columns[15].Visible = false;
                        }

                        /*if (trantype == "FE" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        } */

                    }
                    else if (trantype == "FI")
                    {
                        /*   if (trantype == "FI" && booking1 != "0")
                           {

                               dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                               if (dtnew.Rows.Count > 0)
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = dtnew;
                                   GrdDetails.DataBind();
                               }
                               else
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = new DataTable();
                                   GrdDetails.DataBind();
                               }


                           }*/


                        if (trantype == "FI" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Imports -Transit";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Imports -Transit";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }

                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Ocean Imports -Transit";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = true;

                            GrdDetails.Columns[15].Visible = false;
                        }
                        /*if (trantype == "FI" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }*/
                    }
                    else if (trantype == "AE")
                    {
                        /* if (trantype == "AE" && booking1 != "0")
                         {

                             dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                             if (dtnew.Rows.Count > 0)
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = dtnew;
                                 GrdDetails.DataBind();
                             }
                             else
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = new DataTable();
                                 GrdDetails.DataBind();
                             }


                         }*/


                        if (trantype == "AE" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Exports -Transit";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Exports -Transit";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Air Exports -Transit";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;

                            GrdDetails.Columns[15].Visible = false;
                        }
                        /*if (trantype == "AE" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }*/



                    }
                    else if (trantype == "AI")
                    {
                        /*  if (trantype == "AI" && booking1 != "0")
                          {


                              dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                              if (dtnew.Rows.Count > 0)
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = dtnew;
                                  GrdDetails.DataBind();
                              }
                              else
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = new DataTable();
                                  GrdDetails.DataBind();
                              }


                          }
                          */

                        if (trantype == "AI" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Imports -Transit";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Imports -Transit";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }

                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Air Imports -Transit";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = true;

                            GrdDetails.Columns[15].Visible = false;
                        }
                        /* if (trantype == "AI" && Closed1 != "0")
                          {

                              dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                              if (dtnew.Rows.Count > 0)
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = dtnew;
                                  GrdDetails.DataBind();
                              }
                              else
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = new DataTable();
                                  GrdDetails.DataBind();
                              }


                          }

                          */
                    }
                    else if (trantype == "CH")
                    {
                        if (trantype == "CH" && Transit1 != "0")
                        {
                            Paneln2.Visible = false;
                            return;
                        }
                    }
                    else
                    {

                    }

                }


            }

        }




        protected void Closed_Click(object sender, EventArgs e)
        {
          //  Iframe1.Visible = true;
            string trantype = "";
            string booking1 = "";
            string Transit1 = "";
            string Closed1 = "";
            Paneln2.Visible = true;
           // pnlCharge.Visible = false;
            DataTable dtnew = new DataTable();
            string booking2 = "";


            LinkButton Lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;

            ModalPopupExtender1.Show();

            Paneln2.Visible = true;




            string head = "";
            if (grd.Rows.Count > 0)
            {


                //int index = grd.SelectedRow.RowIndex;

                //Session[index] = grd.SelectedRow.RowIndex;
                //Bhuvana
                head = "Closed";

                //trantype = grd.SelectedRow.Cells[0].Text;

                //Label lbooking = (Label)grd.Rows[index].FindControl("Booked");              



                //Label lTransit = (Label)grd.Rows[index].FindControl("Transit");
                //Label lClosed = (Label)grd.Rows[index].FindControl("Closed");

                LinkButton lbooking = (LinkButton)row.FindControl("Booked");
                LinkButton lTransit = (LinkButton)row.FindControl("Transit");
                LinkButton lClosed = (LinkButton)row.FindControl("Closed");
                trantype = row.Cells[0].Text;

                if (trantype == "Total")
                {
                    if (head == "Closed")
                    {

                        dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), "", "Closed");
                        if (dtnew.Rows.Count > 0)
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Closed";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = dtnew;
                            GrdDetails.DataBind();
                           // GrdDetails.Columns[0].Visible = false;
                            GrdDetails.Columns[15].Visible = false;
                        }
                        else
                        {
                            div2_Bookchart.Visible = true;
                            div_bar.Visible = true;
                            Paneln2.Visible = false;
                          //  pnlCharge.Visible = true;
                            grd.Visible = true;
                            booklinenew();
                            return;
                        }
                    }
                    else
                    {
                        div2_Bookchart.Visible = true;
                        div_bar.Visible = true;
                        Paneln2.Visible = false;
                      //  pnlCharge.Visible = true;
                        grd.Visible = true;
                        booklinenew();
                        return;
                    }

                }


                booking1 = lbooking.Text;
                Transit1 = lTransit.Text;
                Closed1 = lClosed.Text;

                if (trantype == "Ocean Exports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    trantype = "FE";
                }
                else if (trantype == "Ocean Imports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    trantype = "FI";
                }
                else if (trantype == "Air Exports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    trantype = "AE";
                }
                else if (trantype == "Air Imports")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    trantype = "AI";
                }
                else if (trantype == "Customs House Agent")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    trantype = "CH";
                }

                if (head == "Closed")
                {

                    if (trantype == "FE")
                    {



                        /*  if (trantype == "FE" && booking1 != "0")
                          {

                              dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                              if (dtnew.Rows.Count > 0)
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = dtnew;
                                  GrdDetails.DataBind();
                              }
                              else
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = new DataTable();
                                  GrdDetails.DataBind();
                              }

                          }
                         */
                        /*if (trantype == "FE" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }*/

                        if (trantype == "FE" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Exports -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Exports -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = false;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Ocean Exports -Closed";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;

                            GrdDetails.Columns[15].Visible = false;
                        }

                    }
                    else if (trantype == "FI")
                    {
                        /*   if (trantype == "FI" && booking1 != "0")
                           {

                               dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                               if (dtnew.Rows.Count > 0)
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = dtnew;
                                   GrdDetails.DataBind();
                               }
                               else
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = new DataTable();
                                   GrdDetails.DataBind();
                               }


                           }*/


                        /* if (trantype == "FI" && Transit1 != "0")
                         {

                             dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                             if (dtnew.Rows.Count > 0)
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = dtnew;
                                 GrdDetails.DataBind();
                             }
                             else
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = new DataTable();
                                 GrdDetails.DataBind();
                             }


                         }*/
                        if (trantype == "FI" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Imports -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Imports -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Ocean Imports -Closed";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = true;

                            GrdDetails.Columns[15].Visible = false;
                        }
                    }
                    else if (trantype == "AE")
                    {
                        /* if (trantype == "AE" && booking1 != "0")
                         {

                             dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                             if (dtnew.Rows.Count > 0)
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = dtnew;
                                 GrdDetails.DataBind();
                             }
                             else
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = new DataTable();
                                 GrdDetails.DataBind();
                             }


                         }*/


                        /* if (trantype == "AE" && Transit1 != "0")
                         {

                             dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                             if (dtnew.Rows.Count > 0)
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = dtnew;
                                 GrdDetails.DataBind();
                             }
                             else
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = new DataTable();
                                 GrdDetails.DataBind();
                             }


                         }*/
                        if (trantype == "AE" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Exports -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Exports -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Air Exports -Closed";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;

                            GrdDetails.Columns[15].Visible = false;
                        }


                    }
                    else if (trantype == "AI")
                    {
                        /*  if (trantype == "AI" && booking1 != "0")
                          {


                              dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                              if (dtnew.Rows.Count > 0)
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = dtnew;
                                  GrdDetails.DataBind();
                              }
                              else
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = new DataTable();
                                  GrdDetails.DataBind();
                              }


                          }
                          */

                        /*if (trantype == "AI" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }*/
                        if (trantype == "AI" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Imports -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Imports -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = false;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Air Imports -Closed";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = true;

                            GrdDetails.Columns[15].Visible = false;
                        }


                    }
                    else if (trantype == "CH")
                    {

                        if (trantype == "CH" && Closed1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Closed");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Customs House Agent -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = false;
                            }
                            else
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Customs House Agent -Closed";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = false;
                            }


                        }
                        else
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Customs House Agent -Closed";
                             div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = false;
                            
                        }


                    }


                }


            }

        }

   


        protected void LnkClose_Click(object sender, EventArgs e)
        {
            div2_Bookchart.Visible = true;
            div_bar.Visible = true;
            Paneln2.Visible = false;
          //  pnlCharge.Visible = true;
            grd.Visible = true;
            booklinenew();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            div2_Bookchart.Visible = true;
            div_bar.Visible = true;
            Paneln2.Visible = false;
           // pnlCharge.Visible = true;
            grd.Visible = true;
            booklinenew();
        }

        protected void Total_Click(object sender, EventArgs e)
        {
          //  Iframe1.Visible = true;
            string trantype = "";
            string booking1 = "";
            string Transit1 = "";
            string Closed1 = "";
            string total1 = "";
            Paneln2.Visible = true;
           // pnlCharge.Visible = false;
            DataTable dtnew = new DataTable();
            string booking2 = "";


            LinkButton Lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;

            ModalPopupExtender1.Show();

            Paneln2.Visible = true;




            string head = "";
            if (grd.Rows.Count > 0)
            {


                //int index = grd.SelectedRow.RowIndex;

                //Session[index] = grd.SelectedRow.RowIndex;
                //Bhuvana
                head = "Total";

                //trantype = grd.SelectedRow.Cells[0].Text;

                //Label lbooking = (Label)grd.Rows[index].FindControl("Booked");              



                //Label lTransit = (Label)grd.Rows[index].FindControl("Transit");
                //Label lClosed = (Label)grd.Rows[index].FindControl("Closed");

                LinkButton lbooking = (LinkButton)row.FindControl("Booked");
                LinkButton lTransit = (LinkButton)row.FindControl("Transit");
                LinkButton lClosed = (LinkButton)row.FindControl("Closed");

                LinkButton ltotal = (LinkButton)row.FindControl("Total");

                trantype = row.Cells[0].Text;

                if (trantype == "Total")
                {
                    if (head == "Total")
                    {

                        dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), "", "Total");
                        if (dtnew.Rows.Count > 0)
                        {
                            LblDetails.Visible = true;
                            LblDetails.Text = "Total";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = dtnew;
                            GrdDetails.DataBind();
                          //  GrdDetails.Columns[0].Visible = false;
                            GrdDetails.Columns[15].Visible = false;
                        }
                        else
                        {
                            div2_Bookchart.Visible = true;
                            div_bar.Visible = true;
                            Paneln2.Visible = false;
                          //  pnlCharge.Visible = true;
                            grd.Visible = true;
                            booklinenew();
                            return;
                        }
                    }
                    else
                    {
                        div2_Bookchart.Visible = true;
                        div_bar.Visible = true;
                        Paneln2.Visible = false;
                     //   pnlCharge.Visible = true;
                        grd.Visible = true;
                        booklinenew();
                        return;
                    }

                }
                

                booking1 = lbooking.Text;
                Transit1 = lTransit.Text;
                Closed1 = lClosed.Text;
                total1 = ltotal.Text;
                if (trantype == "Ocean Exports")
                {
                  //  GrdDetails.Columns[0].Visible = true;
                   // GrdDetails.Columns[0].HeaderText = "Status";
                    trantype = "FE";
                }
                else if (trantype == "Ocean Imports")
                {
                   // GrdDetails.Columns[0].Visible = true;
                    //GrdDetails.Columns[0].HeaderText = "Status";
                    trantype = "FI";
                }
                else if (trantype == "Air Exports")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    //GrdDetails.Columns[0].HeaderText = "Status";
                    trantype = "AE";
                }
                else if (trantype == "Air Imports")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    //GrdDetails.Columns[0].HeaderText = "Status";
                    trantype = "AI";
                }
                else if (trantype == "Customs House Agent")
                {
                    //GrdDetails.Columns[0].Visible = true;
                    //GrdDetails.Columns[0].HeaderText = "Status";
                    trantype = "CH";
                }

                if (head == "Total")
                {

                    if (trantype == "FE")
                    {



                        /*  if (trantype == "FE" && booking1 != "0")
                          {

                              dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                              if (dtnew.Rows.Count > 0)
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = dtnew;
                                  GrdDetails.DataBind();
                              }
                              else
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = new DataTable();
                                  GrdDetails.DataBind();
                              }

                          }
                         */
                        /*if (trantype == "FE" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }*/

                        if (trantype == "FE" && total1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Total");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Exports -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Text = "Ocean Exports -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;


                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Text = "Ocean Exports -Total";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;


                            GrdDetails.Columns[15].Visible = false;
                        }

                    }
                    else if (trantype == "FI")
                    {
                        /*   if (trantype == "FI" && booking1 != "0")
                           {

                               dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                               if (dtnew.Rows.Count > 0)
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = dtnew;
                                   GrdDetails.DataBind();
                               }
                               else
                               {
                                   div2_Bookchart.Visible = false;
                                   grd.Visible = false;
                                   GrdDetails.DataSource = new DataTable();
                                   GrdDetails.DataBind();
                               }


                           }*/


                        /* if (trantype == "FI" && Transit1 != "0")
                         {

                             dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                             if (dtnew.Rows.Count > 0)
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = dtnew;
                                 GrdDetails.DataBind();
                             }
                             else
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = new DataTable();
                                 GrdDetails.DataBind();
                             }


                         }*/
                        if (trantype == "FI" && total1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Total");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Ocean Imports -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;


                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Text = "Ocean Imports -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;


                                GrdDetails.Columns[15].Visible = true;
                            }




                        }

                        else
                        {
                            LblDetails.Text = "Ocean Imports -Total";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = true;


                            GrdDetails.Columns[15].Visible = false;
                        }
                    }
                    else if (trantype == "AE")
                    {
                        /* if (trantype == "AE" && booking1 != "0")
                         {

                             dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                             if (dtnew.Rows.Count > 0)
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = dtnew;
                                 GrdDetails.DataBind();
                             }
                             else
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = new DataTable();
                                 GrdDetails.DataBind();
                             }


                         }*/


                        /* if (trantype == "AE" && Transit1 != "0")
                         {

                             dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                             if (dtnew.Rows.Count > 0)
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = dtnew;
                                 GrdDetails.DataBind();
                             }
                             else
                             {
                                 div2_Bookchart.Visible = false;
                                 grd.Visible = false;
                                 GrdDetails.DataSource = new DataTable();
                                 GrdDetails.DataBind();
                             }


                         }*/
                        if (trantype == "AE" && total1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Total");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Exports -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;


                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Text = "Air Exports -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Text = "Air Exports -Total";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;
                            GrdDetails.Columns[15].Visible = false;
                        }



                    }
                    else if (trantype == "AI")
                    {
                        /*  if (trantype == "AI" && booking1 != "0")
                          {


                              dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Booked");
                              if (dtnew.Rows.Count > 0)
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = dtnew;
                                  GrdDetails.DataBind();
                              }
                              else
                              {
                                  div2_Bookchart.Visible = false;
                                  grd.Visible = false;
                                  GrdDetails.DataSource = new DataTable();
                                  GrdDetails.DataBind();
                              }


                          }
                          */

                        /*if (trantype == "AI" && Transit1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Transit");
                            if (dtnew.Rows.Count > 0)
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                            }
                            else
                            {
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                            }


                        }*/
                        if (trantype == "AI" && total1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Total");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Air Imports -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }
                            else
                            {
                                LblDetails.Text = "Air Imports -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = true;

                                GrdDetails.Columns[15].Visible = true;
                            }


                        }
                        else
                        {
                            LblDetails.Text = "Air Imports -Total";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = true;

                            GrdDetails.Columns[15].Visible = false;
                        }


                    }
                    else if (trantype == "CH")
                    {

                        if (trantype == "CH" && total1 != "0")
                        {

                            dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), trantype, "Total");
                            if (dtnew.Rows.Count > 0)
                            {
                                LblDetails.Visible = true;
                                LblDetails.Text = "Customs House Agent -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = dtnew;
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = false;
                            }
                            else
                            {
                                LblDetails.Text = "Customs House Agent -Total";
                                div2_Bookchart.Visible = false;
                                grd.Visible = false;
                                GrdDetails.DataSource = new DataTable();
                                GrdDetails.DataBind();
                                GrdDetails.Columns[13].Visible = false;

                                GrdDetails.Columns[15].Visible = false;
                            }


                        }
                        else
                        {
                            LblDetails.Text = "Customs House Agent -Total";
                            div2_Bookchart.Visible = false;
                            grd.Visible = false;
                            GrdDetails.DataSource = new DataTable();
                            GrdDetails.DataBind();
                            GrdDetails.Columns[13].Visible = false;

                            GrdDetails.Columns[15].Visible = false;
                        }
                    }


                }


            }

        }

        protected void Lnk_all_Click(object sender, EventArgs e)
        {
            //Response.Redirect("FIEBLInfo.aspx?uid=" + str + "&Trantype=FE");

            lnk_upd.Visible = true;
            div2_Bookchart.Visible = false;
            div_bar.Visible = false;
            Session["Trantype"] = "FE";
           


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
            lblsail.InnerText = "Container Gate Out";
            lblstuf.InnerText = "Stuffing";
            lblClear.InnerText = "Container Port In";
            lbltran.InnerText = "Sailing";
            lblcargo.InnerText = "BL Released On";
            lblDocon.InnerText = "T/S (If Any)";
            lblarr.InnerText = "CAN Sent On";
            lblOriginaldocsenton.InnerText = "Arrival";
            lbldel.InnerText = "Container Port Out";

            lblDoconfirmed.InnerText = "Destuffing";
            lblreleasedonon.InnerText = "DO Issued On";
            lbljobon1.InnerText = "Container Gate in";
            lbljobDte.InnerText = "";



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
            txt_bookingno.Text = "";
            Div4.Visible = false;
            lbljobon1.Visible = false;

            ifrmaster.Attributes["src"] = "BKStatus.aspx";
            QuickViewClear();
        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedValue != "")
            {
                dt = objRpt.GetCustomersupportallpancustwise(0, "",Convert.ToInt32(Session["webcuspanid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    //grd.DataSource = dt;
                    //grd.DataBind();
                    DataView obj_dtview = new DataView(dt);
                    if (txt_job.Text != "" && txt_booking.SelectedItem.Text != "")
                    {
                        obj_dtview.RowFilter = "bookingno = '" + txt_booking.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and containerno ='" + txt_container.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";
                    }
                    else if (txt_container.SelectedItem.Text != "" && txt_job.Text == "" && txt_booking.SelectedItem.Text == "")
                    {
                        obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";

                    }
                    else if (txt_job.Text != "" && txt_container.SelectedItem.Text != "")
                    {
                        obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and jobno =" + txt_job.Text + " and product ='" + ddl_product.SelectedItem.Text + "'";
                    }
                    else if (txt_job.Text == "" && txt_container.SelectedItem.Text != "")
                    {
                        obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";
                    }
                    else if (txt_job.Text == "" && txt_container.SelectedItem.Text != "" && txt_booking.SelectedItem.Text != "")
                    {
                        obj_dtview.RowFilter = "containerno = '" + txt_container.SelectedItem.Text + "' and product ='" + ddl_product.SelectedItem.Text + "'";
                    }
                    else if (txt_job.Text == "" && txt_container.SelectedItem.Text == "" && txt_booking.SelectedItem.Text == "" )
                    {
                        obj_dtview.RowFilter = "product ='" + ddl_product.SelectedItem.Text + "'";
                    }
                    else if (txt_job.Text != "" && txt_container.SelectedItem.Text == "" && txt_booking.SelectedItem.Text == "")
                    {
                        obj_dtview.RowFilter = " and jobno =" + txt_job.Text + " and product ='" + ddl_product.SelectedItem.Text + "'";
                    }
                    dt = obj_dtview.ToTable();
                    grd.DataSource = dt;
                    grd.DataBind();
                }
            }
        }


    }
}