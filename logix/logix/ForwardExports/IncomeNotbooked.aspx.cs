using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Web.UI.DataVisualization.Charting;
namespace logix.ForwardExports
{
    public partial class IncomeNotbooked : System.Web.UI.Page
    {
        DataAccess.CostingDetails objinc = new DataAccess.CostingDetails();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
       
        DataTable dt = new DataTable();

        CheckBox chk1;
        string jobno, blno;
        string trantype;
        DataTable dt_MenuRights = new DataTable();
        string[] inv_no;
        int selectedRowIndex, selectedColumnIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objinc.GetDataBase(Ccode);
                MISObj.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                



            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd_incomenot);


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            if (Session["StrTranType"] == null)
            {
                Session["StrTranType"] = "AC";

            }

            if (Session["StrTranType"] != null)
            {
                trantype = Session["StrTranType"].ToString();
            }

            if (trantype == "OE")
            {
                trantype = "FE";
            }
            else if (trantype == "OI")
            {
                trantype = "FI";
            }



            //if (trantype == "AC")
            //{
            //    homelbl.InnerText = "Accounts";

            //}
            //else
            //{
            //    homelbl.InnerText = "Ops & Docs";

            //}
            //ddl_PendAll_SelectedIndexChanged1(sender, e);

            if (!IsPostBack)
            {
                /*if (Hid_trantype.Value != "")
                {
                    ddl_product.Items.Add("");
                    if (Hid_trantype.Value == "BT")
                    {
                        ddl_product.Items.Add("Bonded Trucking");
                        ddl_product.SelectedValue = "Bonded Trucking";
                        ddl_product.Enabled = false;
                    }
                    else if (Hid_trantype.Value == "CH")
                    {
                        ddl_product.Items.Add("CHA");
                        ddl_product.SelectedValue = "CHA";
                        ddl_product.Enabled = false;
                    }
                    else if (Hid_trantype.Value == "FE")
                    {
                        ddl_product.Items.Add("Ocean Exports");
                        ddl_product.SelectedValue = "Ocean Exports";
                        ddl_product.Enabled = false;
                    }

                    else if (Hid_trantype.Value == "FI")
                    {
                        ddl_product.Items.Add("Ocean Imports");
                        ddl_product.SelectedValue = "Ocean Imports";
                        ddl_product.Enabled = false;
                    }
                    else if (Hid_trantype.Value == "AE")
                    {
                        ddl_product.Items.Add("Air Exports");
                        ddl_product.SelectedValue = "Air Exports";
                        ddl_product.Enabled = false;
                    }
                    else if (Hid_trantype.Value == "AI")
                    {
                        ddl_product.Items.Add("Air Imports");
                        ddl_product.SelectedValue = "Air Imports";
                        ddl_product.Enabled = false;
                    }
                    else if (Hid_trantype.Value == "AC")
                    {
                        ddl_product.Items.Add("ALL");
                        ddl_product.SelectedValue = "ALL";
                        grd_incomenot.Columns.RemoveAt(14);
                        ddl_product.Enabled = true;

                    }
                    //ddl_product.SelectedIndex = 1;
                   

                }*/


                //if (Session["trantype_process"] != null)
                //{
                //    //lblHead1.Visible = false;
                //    //lblHead2.Visible = false;



                //    // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                //}
                //else
                if (Session["StrTranType"] != null)
                {
                    ddl_product.Items.Add("");
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        lbl1.Visible = true;
                        headerlable1.InnerText = "Ocean Exports";
                        ddl_product.Items.Add("Ocean Exports");
                        //ddl_product.SelectedIndex = 1;
                        ddl_product.SelectedValue = "Ocean Exports";
                        ddl_product.Enabled = false;
                        ddl_product_SelectedIndexChanged1(sender, e);
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        lbl1.Visible = true;
                        headerlable1.InnerText = "Ocean Imports";
                        ddl_product.Items.Add("Ocean Imports");
                        ddl_product.SelectedValue = "Ocean Imports";
                        //ddl_product.SelectedIndex = 1;
                        ddl_product.Enabled = false;
                        ddl_product_SelectedIndexChanged1(sender, e);
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        lbl1.Visible = true;
                        headerlable1.InnerText = "Air Exports";
                        ddl_product.Items.Add("Air Exports");
                        ddl_product.SelectedValue = "Air Exports";
                        //ddl_product.SelectedIndex = 1;
                        ddl_product.Enabled = false;
                        // ddl_product_SelectedIndexChanged1(sender, e);
                        ddl_PendAll_SelectedIndexChanged1(sender, e);
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        lbl1.Visible = true;
                        headerlable1.InnerText = "Air Imports";
                        ddl_product.Items.Add("Air Imports");
                        ddl_product.SelectedValue = "Air Imports";
                        ddl_product.Enabled = false;
                        ddl_product_SelectedIndexChanged1(sender, e);
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        lbl1.Visible = true;
                        headerlable1.InnerText = "CHA";
                        ddl_product.Items.Add("CHA");
                        ddl_product.SelectedValue = "CHA";
                        ddl_product.Enabled = false;
                        ddl_product_SelectedIndexChanged1(sender, e);
                    }

                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        lbl1.Visible = false;
                        //ddl_product.Items.Add("ALL");
                        //ddl_product.SelectedValue = "ALL";


                        //ddl_product.Enabled = false;



                        /* DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                         DataTable dtnew1 = new DataTable();
                         dt_MenuRights = obj_UP.GetMenusprocess(Convert.ToInt16(Session["LoginEmpId"].ToString()), "", Convert.ToInt16(Session["LoginBranchid"].ToString()), 18);

                         if (dt_MenuRights.Rows.Count > 0)
                         {
                             DataView dv_co1 = new DataView(dt_MenuRights);
                             dtnew1 = dv_co1.ToTable(true, "trantype");
                             dv_co1 = new DataView(dtnew1);
                             dv_co1.Sort = "trantype";
                             dtnew1 = dv_co1.ToTable();
                             Session["trantype_process"] = dtnew1;
                         }
                         dt_MenuRights = Session["trantype_process"] as DataTable;
                         //ddl_product.Items.Add("");
                         ddl_product.Items.Add("ALL");
                         for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                         {
                             if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                             {
                                 ddl_product.Items.Add("Ocean Exports");
                             }
                             else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                             {
                                 ddl_product.Items.Add("Ocean Imports");
                             }
                             else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                             {
                                 ddl_product.Items.Add("Air Exports");
                             }
                             else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                             {
                                 ddl_product.Items.Add("Air Imports");
                             }
                             //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
                             //{
                             //    ddl_product.Items.Add("CHA");
                             //}
                             //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
                             //{
                             //    ddl_product.Items.Add("Bonded Trucking");
                             //}

                         }*/
                        ddl_product.Items.Add("ALL");
                        ddl_product.Items.Add("Ocean Exports");
                        ddl_product.Items.Add("Ocean Imports");
                        ddl_product.Items.Add("Air Exports");
                        ddl_product.Items.Add("Air Imports");
                        ddl_product.Items.Add("CHA");
                        //grd_incomenot.Columns.RemoveAt(14);
                        ddl_product.Enabled = true;
                        ddl_product.SelectedValue = "ALL";
                        ddl_product_SelectedIndexChanged1(sender, e);


                    }



                }




                //ddl_PendAll.Items.Add("ALL");
                //ddl_PendAll.Items.Add("Pending");

                // ddl_PendAll.SelectedValue = "P";
                //// incomenotbooked();
                // ddl_product_SelectedIndexChanged(sender,e);
            }

        }

        public void incomenotbooked()
        {
            grd_incomenot.DataSource = new DataTable();
            grd_incomenot.DataBind();
            if (Hid_trantype.Value == "")
            {
                Hid_trantype.Value = "AC";
                ddl_PendAll.SelectedValue = "P";
            }
            //if (Hid_trantype.Value == "AC")
            //{
            //    ddl_PendAll.SelectedValue = "P";
            //}
            MISObj.SelIncomeNotBkdnewfa2023(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginEmpId"]), Session["StrTranType"].ToString());
            if (Hid_trantype.Value == "FI")
            {
                Hid_trantype.Value = "OI";
            }
            else if (Hid_trantype.Value == "FE")
            {
                Hid_trantype.Value = "OE";
            }


            dt = objinc.Get_incomenotbooked4fa23(Convert.ToInt32(Session["LoginEmpId"]), Hid_trantype.Value, ddl_PendAll.SelectedValue);


            if (dt.Rows.Count > 0)
            {

                int lbl_coun = dt.Rows.Count;
                lbl_count.Text = lbl_coun.ToString();
                grd_incomenot.DataSource = dt;
                grd_incomenot.DataBind();
                Session["data"] = dt;
            }
            else
            {
                grd_incomenot.DataSource = new DataTable();
                grd_incomenot.DataBind();
            }
            LinkButton lnkbtn;
            LinkButton lnkbtn1;
            Label lblagent, lblcustomer;
            if (grd_incomenot.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        //    if (dt.Rows[i]["incomeconf"].ToString() == "Inc Booked")
                        //    {
                        //        //chk1 = (CheckBox)(grd_incomenot.Rows[i].FindControl("incomeconf"));
                        //        //chk1.Checked = true;
                        //        lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_job"));
                        //        lnkbtn.Enabled = false;

                        //        lnkbtn1 = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //        lnkbtn1.Enabled = false;
                        //    }
                        //    else
                        //    {
                        //        //chk1 = (CheckBox)(grd_incomenot.Rows[i].FindControl("incomeconf"));
                        //        //chk1.Checked = false;
                        //        lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_job"));
                        //        lnkbtn.Enabled = true;

                        //        lnkbtn1 = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //        lnkbtn1.Enabled = true;
                        //    }

                        //    if (dt.Rows[i]["expenseconf"].ToString() == "0")
                        //    {

                        //        //chk1 = (CheckBox)(grd_incomenot.Rows[i].FindControl("expenseconf"));
                        //        //chk1.Checked = false;
                        //        lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_job"));
                        //        lnkbtn.Enabled = true;

                        //        lnkbtn1 = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //        lnkbtn1.Enabled = true;
                        //    }
                        //    else
                        //    {
                        //        //chk1 = (CheckBox)(grd_incomenot.Rows[i].FindControl("expenseconf"));
                        //        //chk1.Checked = true;
                        //        lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_job"));
                        //        lnkbtn.Enabled = false;

                        //        lnkbtn1 = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //        lnkbtn1.Enabled = false;


                        //    }

                        //    if (Session["StrTranType"].ToString() == "CH")
                        //    {
                        //        lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //        lnkbtn.Enabled = false;
                        //    }

                        //    else
                        //    {
                        //        lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //        lnkbtn.Enabled = true;
                        //    }


                        if (dt.Rows[i]["Agentname"].ToString() == "")

                        {
                            if (dt.Rows[i]["invno"].ToString() != "")
                            {
                                lblagent = (Label)(grd_incomenot.Rows[i].FindControl("Agentname"));
                                lblagent.Text = dt.Rows[i]["invoicecustomername"].ToString();


                            }

                        }


                    }


                }
            }



            //if (dt.Rows.Count > 0)
            //{

            /*DataTable dtempty = new DataTable();



                dtempty.Columns.Add("Booking #");
                dtempty.Columns.Add("BookDate");
                dtempty.Columns.Add("Job#");
                dtempty.Columns.Add("Jobdate");
                dtempty.Columns.Add("MBL #/Mawbl #");
                dtempty.Columns.Add("BL #/Hawbl #");
                dtempty.Columns.Add("Shipper");
                dtempty.Columns.Add("Consignee");
                dtempty.Columns.Add("Vessel/Flight");

                dtempty.Columns.Add("Pol");
                dtempty.Columns.Add("Pod");
                dtempty.Columns.Add("AirPol");
                dtempty.Columns.Add("AirPod");
                dtempty.Columns.Add("Etd");
                dtempty.Columns.Add("Days");
                dtempty.Columns.Add("Proinv");
                dtempty.Columns.Add("Inv#");

                dtempty.Columns.Add("InvDate");
                dtempty.Columns.Add("ProOSSI");
                dtempty.Columns.Add("OSDN#");

                dtempty.Columns.Add("OSDNDate");
                //dtempty.Columns.Add("Sel");
                //dtempty.Columns.Add("Sel");

                dtempty.Columns.Add("IncomeBooked");
                dtempty.Columns.Add("JobStatus");
                DataRow dr = dtempty.NewRow();
                LinkButton lnkbtn = new LinkButton();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dtempty.Rows.Add();
                        dr = dtempty.NewRow();
                        dtempty.Rows[i]["Booking #"] = dt.Rows[i]["bookingno"].ToString();
                        dtempty.Rows[i]["BookDate"] = dt.Rows[i]["bookdate"].ToString();
                        dtempty.Rows[i]["Job#"] = dt.Rows[i]["jobno"].ToString();
                        dtempty.Rows[i]["Jobdate"] = dt.Rows[i]["jobdate"].ToString();
                        dtempty.Rows[i]["MBL #/Mawbl #"] = dt.Rows[i]["mblno"].ToString();


                        dtempty.Rows[i]["BL #/Hawbl #"] = dt.Rows[i]["blno"].ToString();
                        dtempty.Rows[i]["Shipper"] = dt.Rows[i]["shipper"].ToString();
                        dtempty.Rows[i]["Consignee"] = dt.Rows[i]["consignee"].ToString();
                        dtempty.Rows[i]["Vessel/Flight"] = dt.Rows[i]["vessel"].ToString();
                        dtempty.Rows[i]["Pol"] = dt.Rows[i]["pol"].ToString();
                        dtempty.Rows[i]["Pod"] = dt.Rows[i]["pod"].ToString();



                        dtempty.Rows[i]["AirPol"] = dt.Rows[i]["airpol"].ToString();
                        dtempty.Rows[i]["AirPod"] = dt.Rows[i]["airpod"].ToString();
                        dtempty.Rows[i]["Etd"] = dt.Rows[i]["etd"].ToString();
                        dtempty.Rows[i]["Days"] = dt.Rows[i]["days"].ToString();
                        dtempty.Rows[i]["Proinv"] = dt.Rows[i]["proinvdate"].ToString();
                        dtempty.Rows[i]["Inv#"] = dt.Rows[i]["invno"].ToString();

                        dtempty.Rows[i]["InvDate"] = dt.Rows[i]["invdate"].ToString();
                        dtempty.Rows[i]["ProOSSI"] = dt.Rows[i]["proOSDNdate"].ToString();
                        dtempty.Rows[i]["OSDN#"] = dt.Rows[i]["osdnno"].ToString();
                        dtempty.Rows[i]["OSDNDate"] = dt.Rows[i]["OSDNdate"].ToString();


                        //dtempty.Rows[i]["Sel"] = "ProInv";
                        //dtempty.Rows[i]["Sel"] = "ProOSSI";

                        dtempty.Rows[i]["IncomeBooked"] = dt.Rows[i]["incomeconf"].ToString();
                        dtempty.Rows[i]["JobStatus"] = dt.Rows[i]["JobStatus"].ToString();


                    }
                    grd_incomenot.DataSource = dtempty;
                    grd_incomenot.DataBind();

                }
                else
                {
                    grd_incomenot.DataSource = new DataTable();
                    grd_incomenot.DataBind();
                }

               
             */



            //}


        }


        public void jobcount()
        {
            DataTable dtt = new DataTable();
            DataTable dtt1 = new DataTable();
            int feclosedjob = 0, ficlosedjob = 0, aeclosedjob = 0, aiclosedjob = 0, chclosed = 0;

            int feunclosedjob = 0, fiunclosedjob = 0, aeunclosedjob = 0, aiunclosedjob = 0, chunclosed = 0;
            int unclosedjob = 0, closedjob = 0;
            if (Session["data"] != null)
            {
                dtt = (DataTable)Session["data"];
            }


            if (dtt.Rows.Count > 0)
            {
                dtt1.Columns.Add("trantype");
                dtt1.Columns.Add("closedjob");
                dtt1.Columns.Add("unclosedjob");
                DataRow dr = dtt1.NewRow();
                if (Session["StrTranType"].ToString() != "AC")
                {
                    for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                    {
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && Session["StrTranType"].ToString() == "FE")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            unclosedjob = unclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && Session["StrTranType"].ToString() == "FE")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            closedjob = closedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && Session["StrTranType"].ToString() == "FI")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            unclosedjob = unclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && Session["StrTranType"].ToString() == "FI")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            closedjob = closedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && Session["StrTranType"].ToString() == "AI")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            unclosedjob = unclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && Session["StrTranType"].ToString() == "AI")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            closedjob = closedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && Session["StrTranType"].ToString() == "AE")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            unclosedjob = unclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && Session["StrTranType"].ToString() == "AE")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            closedjob = closedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && Session["StrTranType"].ToString() == "CH")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            unclosedjob = unclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && Session["StrTranType"].ToString() == "CH")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            closedjob = closedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }

                    }
                    dtt1.Rows.Add();
                    string product = Session["StrTranType"].ToString();
                    if (product == "FE")
                    {
                        product = "Ocean Exports";
                    }
                    else if (product == "FI")
                    {
                        product = "Ocean Imports";
                    }
                    else if (product == "AE")
                    {
                        product = "Air Exports";
                    }
                    else if (product == "AI")
                    {
                        product = "Air Imports";
                    }
                    else if (product == "CH")
                    {
                        product = "CHA";
                    }
                    dtt1.Rows[0]["trantype"] = product;
                    dtt1.Rows[0]["closedjob"] = closedjob;
                    dtt1.Rows[0]["unclosedjob"] = unclosedjob;
                    grd_jobcount.DataSource = dtt1;
                    grd_jobcount.DataBind();
                }

                if (Session["StrTranType"].ToString() == "AC")
                {


                    for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                    {

                        string strtrantype = dtt.Rows[i]["product"].ToString();
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && strtrantype.ToUpper().Substring(0, 2) == "OE")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            feunclosedjob = feunclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && strtrantype.ToUpper().Substring(0, 2) == "OE")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            feclosedjob = feclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && strtrantype.ToUpper().Substring(0, 2) == "OI")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            fiunclosedjob = fiunclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && strtrantype.ToUpper().Substring(0, 2) == "OI")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            ficlosedjob = ficlosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && strtrantype.ToUpper().Substring(0, 2) == "AI")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            aiunclosedjob = aiunclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && strtrantype.ToUpper().Substring(0, 2) == "AI")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            aiclosedjob = aiclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && strtrantype.ToUpper().Substring(0, 2) == "AE")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            aeunclosedjob = aeunclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && strtrantype.ToUpper().Substring(0, 2) == "AE")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            aeclosedjob = aeclosedjob + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Unclosed" && strtrantype.ToUpper().Substring(0, 2) == "CH")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            chunclosed = chunclosed + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                        if (dtt.Rows[i]["JobStatus"].ToString() == "Closed" && strtrantype.ToUpper().Substring(0, 2) == "CH")
                        {
                            dtt.Rows[i]["JobStatus"] = 1;
                            chclosed = chclosed + Convert.ToInt32(dtt.Rows[i]["JobStatus"]);
                        }
                    }
                    if (ddl_product.SelectedItem.Text == "ALL")
                    {

                        if (feunclosedjob.ToString() != "" || feclosedjob.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[0]["trantype"] = "Ocean Exports";
                            dtt1.Rows[0]["closedjob"] = feclosedjob;
                            dtt1.Rows[0]["unclosedjob"] = feunclosedjob;

                        }
                        if (fiunclosedjob.ToString() != "" || ficlosedjob.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[1]["trantype"] = "Ocean Imports";
                            dtt1.Rows[1]["closedjob"] = ficlosedjob;
                            dtt1.Rows[1]["unclosedjob"] = fiunclosedjob;

                        }
                        if (aiclosedjob.ToString() != "" || aiunclosedjob.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[2]["trantype"] = "Air Imports";
                            dtt1.Rows[2]["closedjob"] = aiclosedjob;
                            dtt1.Rows[2]["unclosedjob"] = aiunclosedjob;

                        }
                        if (aeclosedjob.ToString() != "" || aeunclosedjob.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[3]["trantype"] = "Air Exports";
                            dtt1.Rows[3]["closedjob"] = aeclosedjob;
                            dtt1.Rows[3]["unclosedjob"] = aeunclosedjob;
                        }
                        if (chclosed.ToString() != "" || chunclosed.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[4]["trantype"] = "CHA";
                            dtt1.Rows[4]["closedjob"] = chclosed;
                            dtt1.Rows[4]["unclosedjob"] = chunclosed;
                        }
                    }
                    else if (ddl_product.SelectedItem.Text == "Ocean Exports")
                    {

                        if (feunclosedjob.ToString() != "" || feclosedjob.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[0]["trantype"] = "Ocean Exports";
                            dtt1.Rows[0]["closedjob"] = feclosedjob;
                            dtt1.Rows[0]["unclosedjob"] = feunclosedjob;

                        }

                    }
                    else if (ddl_product.SelectedItem.Text == "Ocean Imports")
                    {
                        if (fiunclosedjob.ToString() != "" || ficlosedjob.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[0]["trantype"] = "Ocean Imports";
                            dtt1.Rows[0]["closedjob"] = ficlosedjob;
                            dtt1.Rows[0]["unclosedjob"] = fiunclosedjob;

                        }
                    }
                    else if (ddl_product.SelectedItem.Text == "Air Exports")
                    {
                        if (aeclosedjob.ToString() != "" || aeunclosedjob.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[0]["trantype"] = "Air Exports";
                            dtt1.Rows[0]["closedjob"] = aeclosedjob;
                            dtt1.Rows[0]["unclosedjob"] = aeunclosedjob;
                        }
                    }
                    else if (ddl_product.SelectedItem.Text == "Air Imports")
                    {
                        if (aeclosedjob.ToString() != "" || aeunclosedjob.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[0]["trantype"] = "Air Imports";
                            dtt1.Rows[0]["closedjob"] = aiclosedjob;
                            dtt1.Rows[0]["unclosedjob"] = aiunclosedjob;
                        }
                    }
                    else if (ddl_product.SelectedItem.Text == "CHA")
                    {
                        if (chclosed.ToString() != "" || chunclosed.ToString() != "")
                        {
                            dtt1.Rows.Add();
                            dtt1.Rows[0]["trantype"] = "CHA";
                            dtt1.Rows[0]["closedjob"] = chclosed;
                            dtt1.Rows[0]["unclosedjob"] = chunclosed;
                        }
                    }
                    grd_jobcount.DataSource = dtt1;
                    grd_jobcount.DataBind();


                }


            }



        }

        protected void grd_incomenot_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                if (i == 21 || i == 26)
                {

                    e.Row.Cells[21].ToolTip = "Booking # :" + e.Row.Cells[2].Text + " - Job# : " + e.Row.Cells[4].Text + " - MBL #/Mawbl #: " + e.Row.Cells[7].Text + " - BL #/Hawbl #: " + e.Row.Cells[8].Text;
                    e.Row.Cells[26].ToolTip = "Booking # :" + e.Row.Cells[2].Text + " - Job# : " + e.Row.Cells[4].Text + " - MBL #/Mawbl #: " + e.Row.Cells[7].Text + " - BL #/Hawbl #: " + e.Row.Cells[8].Text;

                }
                else
                {
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                //        /*if (e.Row.Cells[18].Text != "" )
                //        {
                //            if (e.Row.Cells[0].Text != "")
                //            {
                //                e.Row.Cells[18].ToolTip = "Booking # :" + e.Row.Cells[0].Text + " - Job# : " + e.Row.Cells[2].Text + " - MBL #/Mawbl #: " + e.Row.Cells[4].Text + " - BL #/Hawbl #: " + e.Row.Cells[5].Text;
                //                e.Row.Cells[21].ToolTip = "Booking # :" + e.Row.Cells[0].Text + " - Job# : " + e.Row.Cells[2].Text + " - MBL #/Mawbl #: " + e.Row.Cells[4].Text + " - BL #/Hawbl #: " + e.Row.Cells[5].Text;
                //            }
                //        }
                //        else if (e.Row.Cells[21].Text != "")
                //        {
                //            if (e.Row.Cells[0].Text != "")
                //            {
                //                e.Row.Cells[18].ToolTip = "Booking # :" + e.Row.Cells[0].Text + " - Job# : " + e.Row.Cells[2].Text + " - MBL #/Mawbl #: " + e.Row.Cells[4].Text + " - BL #/Hawbl #: " + e.Row.Cells[5].Text;
                //                e.Row.Cells[21].ToolTip = "Booking # :" + e.Row.Cells[0].Text + " - Job# : " + e.Row.Cells[2].Text + " - MBL #/Mawbl #: " + e.Row.Cells[4].Text + " - BL #/Hawbl #: " + e.Row.Cells[5].Text;
                //            }
                //        }
                //        else
                //        {
                //           // e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                //        }*/


            }


            //    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
            //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_incomenot, "Select$" + e.Row.RowIndex);
            //    e.Row.Attributes["style"] = "cursor:pointer";

            //    //LinkButton _singleClickButton = (LinkButton)e.Row.Cells[31].Controls[0];
            //    //string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
            //    //// Add events to each editable cell
            //    //for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
            //    //{
            //    //    // Add the column index as the event argument parameter
            //    //    string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
            //    //    ///Add this javascript to the onclick Attribute of the cell
            //    //    e.Row.Cells[columnIndex].Attributes["onclick"] = js;

            //    //    // Add a cursor style to the cells
            //    //    e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
            //    //}
            //    //e.Row.Attributes["style"] = "cursor:pointer";
            //}






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

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b2d9f7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_incomenot, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }

            //if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            //{



            //    if (Session["StrTranType"].ToString() == "AC")
            //    {
            //        e.Row.Cells[25].Visible = false;
            //        e.Row.Cells[26].Visible = false;

            //    }
            //    else
            //    {
            //        e.Row.Cells[25].Visible = true;
            //        e.Row.Cells[26].Visible = true;

            //    }
            //}


            //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_incomenot, "Select$" + e.Row.RowIndex);
            //e.Row.Attributes["style"] = "cursor:pointer";



        }






        protected void Lnk_job_Click(object sender, EventArgs e)
        {
            string uiid = "";
            string product = "";
            LinkButton Lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;
            if (grd_incomenot.Rows.Count > 0)
            {
                // int count = grd_incomenot.SelectedRow.RowIndex;              
                blno = row.Cells[6].Text;
                string[] d2 = row.Cells[2].Text.Split('-');

                product = d2[0].ToString();


                if (product == "OE")
                {
                    uiid = "1013";    //OSDNCN  --1015
                }
                else if (product == "OI")
                {
                    uiid = "1020";       // //OSDNCN  --1022 
                }
                else if (product == "AE")
                {
                    uiid = "1027";        // //OSDNCN  --1029 
                }
                else if (product == "AI")
                {
                    uiid = "1034";        // //OSDNCN  --1036 
                }
                else if (product == "CH")
                {
                    uiid = "1041";
                }
                if (product == "OE")
                {
                    product = "FE";
                }
                else if (product == "OI")
                {
                    product = "FI";
                }
                if (row.Cells[25].Text == "")
                {
                    Session["Incomenotbookednew"] = "Incomenotbookednew";
                    Response.Redirect("../Accounts/ProfomaInvoice.aspx?type=" + "Proforma Invoice" + "&blno=" + blno + "&uiid=" + uiid + "&product=" + product);
                }
            }




        }

        protected void Lnk_OSDN_Click(object sender, EventArgs e)
        {
            //grd_incomenot_SelectedIndexChanged(sender, e);
            LinkButton Lnk = sender as LinkButton;
            //string product="";
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;
            if (grd_incomenot.Rows.Count > 0)
            {
                // int count = grd_incomenot.SelectedRow.RowIndex;
                //jobno = row.Cells[2].Text;

                string[] d2 = row.Cells[2].Text.Split('-');

                jobno = d2[1].ToString();

                if (row.Cells[26].Text == "")
                {
                    Session["Incomenotbooked"] = "Incomenotbooked";
                    Response.Redirect("../Accounts/PerformaOsDNCNProNew.aspx?jobno=" + jobno);
                }
            }

        }

        //protected void grd_incomenot_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DateTime Date;
        //    int vouyear = 0;
        //    string product = "";
        //    string uiid = "";
        //    string Str_Script = "";
        //    string header = "";
        //    string bltype = "";
        //    string strblno = "";
        //    string strmblno = "";
        //    if (grd_incomenot.Rows.Count > 0)
        //    {


        //        //int count = grd_incomenot.SelectedRow.RowIndex;
        //        // jobno = grd_incomenot.Columns[selectedColumnIndex1].ToString();
        //        jobno = grd_incomenot.SelectedRow.Cells[18].Text;
        //        string[] d2 = grd_incomenot.SelectedRow.Cells[2].Text.Split('-');


        //        product = d2[1].ToString();

        //        if (product == "FE")
        //        {
        //            uiid = "22";    //OSDNCN  --1015
        //        }
        //        else if (product == "FI")
        //        {
        //            uiid = "23";       // //OSDNCN  --1022 
        //        }
        //        else if (product == "AE")
        //        {
        //            uiid = "24";        // //OSDNCN  --1029 
        //        }
        //        else if (product == "AI")
        //        {
        //            uiid = "25";        // //OSDNCN  --1036 
        //        }

        //        Date = Convert.ToDateTime(grd_incomenot.SelectedRow.Cells[19].Text);
        //        if (Date.Month < 4)
        //        {
        //            vouyear = Date.Year - 1;
        //        }
        //        else
        //        {
        //            vouyear = Date.Year;
        //        }
        //    }
        //    //Response.Redirect("../Accounts/Invoice.aspx?type=" + "Invoice" + "&jobno=" + jobno + "&vouyear=" + vouyear + "&uiid=" + uiid);


        //    header = "Invoice";

        //    strmblno = grd_incomenot.SelectedRow.Cells[4].Text;
        //    strblno = grd_incomenot.SelectedRow.Cells[5].Text;

        //    if (strblno != "")
        //    {
        //        bltype = "H";
        //    }
        //    if (strmblno != "")
        //    {
        //        bltype = "M";
        //    }

        //    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + jobno.ToString() + "&vouyear=" + vouyear.ToString() + "&blno=" + strblno + "&trantype=" + trantype + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";


        //    ScriptManager.RegisterStartupScript(grd_incomenot, typeof(GridView), "CostingDetails", Str_Script, true);
        //}

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddl_product.Text != "" && ddl_product.Text != "0")
            {
                if (ddl_product.Text == "Ocean Exports")
                {
                    //Session["StrTranType"] = "FE";
                    //StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "FE";
                }
                else if (ddl_product.Text == "Ocean Imports")
                {
                    // Session["StrTranType"] = "FI";
                    // StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "FI";
                }
                else if (ddl_product.Text == "Air Exports")
                {
                    // Session["StrTranType"] = "AE";
                    // StrTranType = Session["StrTranType"].ToString();

                    Hid_trantype.Value = "AE";
                }
                else if (ddl_product.Text == "Air Imports")
                {
                    //  Session["StrTranType"] = "AI";
                    // StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "AI";
                }
                //else if (ddl_product.Text == "CHA")
                //{
                //    //Session["StrTranType"] = "CH";
                //    // StrTranType = Session["StrTranType"].ToString();
                //    Hid_trantype.Value = trantype;
                //}
                //else if (ddl_product.Text == "Bonded Trucking")
                //{
                //   // Session["StrTranType"] = "BT";
                //    // StrTranType = Session["StrTranType"].ToString();
                //    Hid_trantype.Value = trantype;
                //}
                else if (ddl_product.Text == "ALL (from 2021 April)")
                {
                    // Session["StrTranType"] = "AC";
                    // StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "AC";
                }

            }
            //incomenotbooked();
            //jobcount();
        }

        protected void ddl_product_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddl_product.Text != "" && ddl_product.Text != "0")
            {
                if (ddl_product.Text == "Ocean Exports")
                {
                    //Session["StrTranType"] = "FE";
                    //StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "FE";
                }
                else if (ddl_product.Text == "Ocean Imports")
                {
                    // Session["StrTranType"] = "FI";
                    // StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "FI";
                }
                else if (ddl_product.Text == "Air Exports")
                {
                    // Session["StrTranType"] = "AE";
                    // StrTranType = Session["StrTranType"].ToString();

                    Hid_trantype.Value = "AE";
                }
                else if (ddl_product.Text == "Air Imports")
                {
                    //  Session["StrTranType"] = "AI";
                    // StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "AI";
                }
                else if (ddl_product.Text == "CHA")
                {
                    //  Session["StrTranType"] = "AI";
                    // StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "CH";
                }
                //else if (ddl_product.Text == "CHA")
                //{
                //    //Session["StrTranType"] = "CH";
                //    // StrTranType = Session["StrTranType"].ToString();
                //    Hid_trantype.Value = trantype;
                //}
                //else if (ddl_product.Text == "Bonded Trucking")
                //{
                //   // Session["StrTranType"] = "BT";
                //    // StrTranType = Session["StrTranType"].ToString();
                //    Hid_trantype.Value = trantype;
                //}
                else if (ddl_product.Text == "ALL (from 2021 April)")
                {
                    // Session["StrTranType"] = "AC";
                    // StrTranType = Session["StrTranType"].ToString();
                    Hid_trantype.Value = "AC";
                }

            }
            //incomenotbooked();
            //jobcount();

        }

        protected void ddl_PendAll_SelectedIndexChanged1(object sender, EventArgs e)
        {


            incomenotbooked();
            jobcount();
        }

        protected void grd_incomenot_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                if (e.CommandName.ToString() == "ColumnClick")
                {
                    //foreach (GridViewRow r in grd_incomenot.Rows)
                    //{
                    //    if (r.RowType == DataControlRowType.DataRow)
                    //    {
                    //        for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                    //        {
                    //            r.Cells[selectedRowIndex].Attributes["style"] += "background-color:White;";
                    //        }
                    //    }
                    //}



                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    // grd_incomenot.Rows[selectedRowIndex].Cells[selectedColumnIndex].Attributes["style"] += "background-color:Red;";
                    for (int i = 0; i < grd_incomenot.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            grd_incomenot.Rows[i].Attributes["style"] += "background-color:White;";
                        }
                        else
                        {
                            grd_incomenot.Rows[i].Attributes["style"] += "background-color:#FFF8DC;";
                        }
                    }


                    grd_incomenot.Rows[selectedRowIndex].Attributes["style"] += "background-color:#f70404;";
                }

            }

            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix Touch", "alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }


        }

        protected void invno_Click(object sender, EventArgs e)
        {
            DateTime Date;
            int vouyear = 0;
            string product = "";
            string uiid = "";
            string Str_Script = "";
            string header = "";
            string bltype = "";
            string strblno = "";
            string strmblno = "";
            //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataTable obj_dttemp = new DataTable();
            string invno = "";
            LinkButton Lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;
            if (grd_incomenot.Rows.Count > 0)
            {
                // int count = grd_incomenot.SelectedRow.RowIndex;  


                LinkButton lbk = (LinkButton)row.FindControl("invno");

                //jobno = lbk.Text;
                inv_no = lbk.Text.Split(',');
                //   string[] d2 = row.Cells[2].Text.Split('-');
                string[] d2 = grd_incomenot.Rows[row.RowIndex].Cells[1].Text.Split('-');

                //int count = grd_incomenot.SelectedRow.RowIndex;
                // jobno = grd_incomenot.Columns[selectedColumnIndex1].ToString();
                //jobno = grd_incomenot.SelectedRow.Cells[16].Text;
                //string[] d2 = grd_incomenot.SelectedRow.Cells[2].Text.Split('-');


                product = d2[0].ToString();


                if (product == "OE")
                {
                    uiid = "22";    //OSDNCN  --1015
                }
                else if (product == "OI")
                {
                    uiid = "23";       // //OSDNCN  --1022 
                }
                else if (product == "AE")
                {
                    uiid = "24";        // //OSDNCN  --1029 
                }
                else if (product == "AI")
                {
                    uiid = "25";        // //OSDNCN  --1036 
                }
                else if (product == "CH")
                {
                    uiid = "26";        // //OSDNCN  --1036 

                }


                //    Date = Convert.ToDateTime(grd_incomenot.SelectedRow.Cells[17].Text);
                if (row.Cells[22].Text != "")
                {
                    Date = Convert.ToDateTime(Utility.fn_ConvertDate(row.Cells[22].Text));

                    if (Date.Month < 4)
                    {
                        vouyear = Date.Year - 1;
                    }
                    else
                    {
                        vouyear = Date.Year;
                    }
                }
                else
                {
                    return;
                }
            }
            //Response.Redirect("../Accounts/Invoice.aspx?type=" + "Invoice" + "&jobno=" + jobno + "&vouyear=" + vouyear + "&uiid=" + uiid);


            header = "Invoice";

            //strmblno = grd_incomenot.SelectedRow.Cells[4].Text;
            //strblno = grd_incomenot.SelectedRow.Cells[5].Text;

            strmblno = row.Cells[7].Text;
            strblno = row.Cells[8].Text;
            if (product == "CH")
            {
                obj_dttemp = obj_da_Invoice.CheckHblno(strblno, product, int.Parse(Session["LoginBranchid"].ToString()));
            }
            else
            {
                obj_dttemp = obj_da_Invoice.CheckHblno(strmblno, product, int.Parse(Session["LoginBranchid"].ToString()));
            }
            if (obj_dttemp.Rows.Count > 0)
            {
                bltype = "H";
            }
            else
            {
                bltype = "M";
            }
            if (product == "OE")
            {
                product = "FE";
            }
            else if (product == "OI")
            {
                product = "FI";

            }

            for (int i = 0; i < inv_no.Length; i++)
            {

                Str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + inv_no[i].ToString() + "&vouyear=" + vouyear.ToString() + "&blno=" + strblno + "&trantype=" + product + "&bltype=" + bltype + "&header=" + header + "&" + this.Page.ClientQueryString + "','','');";
            }

            ScriptManager.RegisterStartupScript(grd_incomenot, typeof(GridView), "CostingDetails", Str_Script, true);
        }

        protected void osdnno_Click(object sender, EventArgs e)
        {

            DateTime Date;
            int vouyear = 0;
            string product = "";
            string uiid = "";
            string Str_Script = "";
            string header = "";
            string bltype = "";
            string strblno = "";
            string strmblno = "";
            string job1 = "";
            LinkButton Lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;
            if (grd_incomenot.Rows.Count > 0)
            {
                // int count = grd_incomenot.SelectedRow.RowIndex;  


                LinkButton lbk = (LinkButton)row.FindControl("osdnno");

                inv_no = lbk.Text.Split(',');

                //   string[] d2 = row.Cells[2].Text.Split('-');
                string[] d2 = grd_incomenot.Rows[row.RowIndex].Cells[0].Text.Split('-');

                //int count = grd_incomenot.SelectedRow.RowIndex;
                // jobno = grd_incomenot.Columns[selectedColumnIndex1].ToString();
                //jobno = grd_incomenot.SelectedRow.Cells[16].Text;
                //string[] d2 = grd_incomenot.SelectedRow.Cells[2].Text.Split('-');


                product = d2[0].ToString().Trim();
                job1 = d2[1].ToString();

                if (product == "OE")
                {
                    uiid = "22";    //OSDNCN  --1015
                }
                else if (product == "OI")
                {
                    uiid = "23";       // //OSDNCN  --1022 
                }
                else if (product == "AE")
                {
                    uiid = "24";        // //OSDNCN  --1029 
                }
                else if (product == "AI")
                {
                    uiid = "25";        // //OSDNCN  --1036 
                }

                //    Date = Convert.ToDateTime(grd_incomenot.SelectedRow.Cells[17].Text);
                if (row.Cells[29].Text != "")
                {
                    Date = Convert.ToDateTime(Utility.fn_ConvertDate(row.Cells[29].Text));
                    if (Date.Month < 4)
                    {
                        vouyear = Date.Year - 1;
                    }
                    else
                    {
                        vouyear = Date.Year;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(grd_incomenot, typeof(GridView), "Vou Date Empty", Str_Script, true);
                    return;
                }
            }
            //Response.Redirect("../Accounts/Invoice.aspx?type=" + "Invoice" + "&jobno=" + jobno + "&vouyear=" + vouyear + "&uiid=" + uiid);


            if (product == "OE")
            {
                product = "FE";
            }
            else if (product == "OI")
            {
                product = "FI";
            }

            //strmblno = grd_incomenot.SelectedRow.Cells[4].Text;
            //strblno = grd_incomenot.SelectedRow.Cells[5].Text;

            for (int i = 0; i < inv_no.Length; i++)
            {
                Str_Script += "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + inv_no[i].ToString() + "&vouyear=" + vouyear + "&tran=" + Convert.ToString(product) + "&jobno=" + Convert.ToInt32(job1) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
                Str_Script += "window.open('../Reportasp/ProformaOverseaDebiCredinew.aspx?refno=" + inv_no[i].ToString() + "&vouyear=" + vouyear + "&tran=" + Convert.ToString(product) + "&jobno=" + Convert.ToInt32(job1) + "&bltype=" + "OSSI" + "&" + this.Page.ClientQueryString + "','','');";
            }

            ScriptManager.RegisterStartupScript(grd_incomenot, typeof(GridView), "CostingDetails", Str_Script, true);
        }

        [WebMethod]
        public static void GetShipername(string Prefix, string pend, string prod)
        {
            DataAccess.CostingDetails objinc = new DataAccess.CostingDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objinc.GetDataBase(Ccode);

            DataTable dt = new DataTable();


            if (Prefix.Length > 0)
            {

                dt = objinc.Get_incomenotbookednew(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), HttpContext.Current.Session["StrTranType"].ToString().Replace("FE", "OE").Replace("FI", "OI"), pend, Prefix.ToUpper(), prod.ToString());

            }
            else
            {
                dt = objinc.Get_incomenotbookednew(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), HttpContext.Current.Session["StrTranType"].ToString().Replace("FE", "OE").Replace("FI", "OI"), pend, Prefix.ToUpper(), prod.ToString());
            }
            HttpContext.Current.Session["Date"] = dt;
        }



        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataTable obj_dtEmp = new DataTable();

            if (txt_Search.Text != "")
            {

                if (Session["Date"] != null)
                {
                    obj_dtEmp = (DataTable)Session["Date"];
                    int lbl_coun = dt.Rows.Count;
                    lbl_count.Text = lbl_coun.ToString();
                    ViewState["Charge"] = obj_dtEmp;
                    grd_incomenot.DataSource = obj_dtEmp;
                    grd_incomenot.DataBind();

                }

            }
            else
            {
                if (Session["Date"] != null)
                {
                    obj_dtEmp = (DataTable)Session["Date"];
                    int lbl_coun = dt.Rows.Count;
                    lbl_count.Text = lbl_coun.ToString();
                    ViewState["Charge"] = obj_dtEmp;
                    grd_incomenot.DataSource = obj_dtEmp;
                    grd_incomenot.DataBind();

                }
            }



            LinkButton lnkbtn;
            LinkButton lnkbtn1;
            Label lblagent, lblcustomer;
            if (grd_incomenot.Rows.Count > 0)
            {
                if (obj_dtEmp.Rows.Count > 0)
                {
                    for (int i = 0; i <= obj_dtEmp.Rows.Count - 1; i++)
                    {
                        //if (obj_dtEmp.Rows[i]["incomeconf"].ToString() == "Inc Booked")
                        //{
                        //    chk1 = (CheckBox)(grd_incomenot.Rows[i].FindControl("incomeconf"));
                        //    chk1.Checked = true;
                        //    lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_job"));
                        //    lnkbtn.Enabled = false;

                        //    lnkbtn1 = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //    lnkbtn1.Enabled = false;
                        //}
                        //else
                        //{
                        //    chk1 = (CheckBox)(grd_incomenot.Rows[i].FindControl("incomeconf"));
                        //    chk1.Checked = false;
                        //    lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_job"));
                        //    lnkbtn.Enabled = true;

                        //    lnkbtn1 = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //    lnkbtn1.Enabled = true;
                        //}

                        //if (obj_dtEmp.Rows[i]["expenseconf"].ToString() == "0")
                        //{

                        //    chk1 = (CheckBox)(grd_incomenot.Rows[i].FindControl("expenseconf"));
                        //    chk1.Checked = false;
                        //    lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_job"));
                        //    lnkbtn.Enabled = true;

                        //    lnkbtn1 = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //    lnkbtn1.Enabled = true;
                        //}
                        //else
                        //{
                        //    chk1 = (CheckBox)(grd_incomenot.Rows[i].FindControl("expenseconf"));
                        //    chk1.Checked = true;
                        //    lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_job"));
                        //    lnkbtn.Enabled = false;

                        //    lnkbtn1 = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //    lnkbtn1.Enabled = false;


                        //}

                        //if (Session["StrTranType"].ToString() == "CH")
                        //{
                        //    lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //    lnkbtn.Enabled = false;
                        //}

                        //else
                        //{
                        //    lnkbtn = (LinkButton)(grd_incomenot.Rows[i].FindControl("Lnk_OSDN"));
                        //    lnkbtn.Enabled = true;
                        //}


                        if (obj_dtEmp.Rows[i]["Agentname"].ToString() == "")
                        {
                            if (obj_dtEmp.Rows[i]["invno"].ToString() != "")
                            {
                                lblagent = (Label)(grd_incomenot.Rows[i].FindControl("Agentname"));
                                lblagent.Text = obj_dtEmp.Rows[i]["invoicecustomername"].ToString();


                            }

                        }


                    }


                }
            }

        }


        protected void btn_export_Click(object sender, EventArgs e)
        {

            try
            {
                if (grd_incomenot.Visible == true && grd_incomenot.Rows.Count > 0)
                {
                    for (int j = 25; j < grd_incomenot.Columns.Count - 2; j++)
                    {
                        grd_incomenot.HeaderRow.Cells[j].Visible = false;
                        for (int i = 0; i < grd_incomenot.Rows.Count; i++)
                        {
                            GridViewRow row = grd_incomenot.Rows[i];
                            row.Cells[j].Visible = false;
                        }
                    }

                    Response.Clear();
                    Response.Buffer = true;
                    string filename = "INCOME NOT BOOKED- " + ddl_PendAll.SelectedValue + "-" + ddl_PendAllProd.SelectedValue;
                    Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringWriter StringWriter = new System.IO.StringWriter();
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                    grd_incomenot.GridLines = GridLines.Both;
                    grd_incomenot.HeaderStyle.Font.Bold = true;
                    //foreach (GridViewRow gridViewRow in grd_incomenot.Rows)
                    //{
                    //    //gridViewRow.ForeColor = Color.Black;
                    //    foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                    // gridViewRowTableCell.Style["forecolor"] = "#000000";
                    //    if (gridViewRow.RowType == DataControlRowType.DataRow)
                    //    {
                    //        for (int columnIndex = 0; columnIndex < gridViewRow.Cells.Count; columnIndex++)
                    //        {
                    // gridViewRow.Cells[columnIndex].Attributes.Add("class", "text");
                    //        }
                    //    }
                    //}
                    grd_incomenot.RenderControl(HtmlTextWriter);

                    //string style = @"<style> .text { mso-number-format:\@; } </style> ";
                    //Response.Write(style);

                    Response.Write(StringWriter.ToString());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix Touch", "alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void grd_incomenot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void grd_incomenot_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    grd_incomenot.Rows[selectedRowIndex].Attributes["style"] += "background-color:#f70404;";
        //}

        //protected void grd_incomenot_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{

        //}

        //protected void grd_incomenot_SelectedIndexChanged1(object sender, EventArgs e)
        //{

        //}

        protected void grd_incomenot_PreRender(object sender, EventArgs e)
        {
            if (grd_incomenot.Rows.Count > 0)
            {
                grd_incomenot.UseAccessibleHeader = true;
                grd_incomenot.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_jobcount_PreRender(object sender, EventArgs e)
        {
            if (grd_jobcount.Rows.Count > 0)
            {
                grd_jobcount.UseAccessibleHeader = true;
                grd_jobcount.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}