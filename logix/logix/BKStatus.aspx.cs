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
using ClosedXML.Excel;
using System.IO;
using System.Web.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;

namespace logix
{
    public partial class BKStatus : System.Web.UI.Page
    {
        CustomerDataAccess.RegCustomer cusobj = new CustomerDataAccess.RegCustomer();
        //DataAccess.Masters.MasterCustomer MCus = new DataAccess.Masters.MasterCustomer();
        public DateTime Frm, To;
        string strTranType, strdbname, strBLno, strStatus;
        int i, cusID;
        DataTable Dt, dtCustIDs, DtCombined;
        DataColumn Dc;
        Calendar Frmobj, Toobj;
        Calendar cldr = new Calendar();
        Global glObj = new Global();
        CustomerDataAccess.PODetails Logobj = new CustomerDataAccess.PODetails();
        public string strTo, strFrom;
        DataTable dtnew;
        DataAccess.Accounts.Recipts objReceipt = new DataAccess.Accounts.Recipts();

        string username = "";
        string password = "";


        string ip = "";
        string dbname = "";

        protected string DBCS;
     

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnExcel);
            try
            {
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnSave);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grpupdload);
            }

            catch (Exception ex)
            {
                //string message = ex.Message.ToString();
                // ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (!IsPostBack)
            {



                dtnew = objReceipt.getcustlogin4homedetails(Convert.ToInt32(Session["webgroupid"].ToString()), "", "Total");
                if (dtnew.Rows.Count > 0)
                {

                    GrdDetails.DataSource = dtnew;
                    GrdDetails.DataBind();
                    ViewState["CurrentData"] = dtnew;

                    //  GrdDetails.Columns[0].Visible = false;
                    GrdDetails.Columns[18].Visible = false;
                }
                else
                {
                    GrdDetails.DataSource = new DataTable();
                    GrdDetails.DataBind();
                }

            }




        }
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdDetails, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
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
                trantype1 = GrdDetails.SelectedRow.Cells[15].Text;
                blno = GrdDetails.SelectedRow.Cells[3].Text;
                bid = GrdDetails.SelectedRow.Cells[14].Text;

                upload.Visible = true;
                hid_blno.Value = blno;
                hid_bid.Value = bid;
                upload.Visible = true;
                txt_booking.Text = hid_blno.Value;
                hid_trantype1.Value = trantype1;
                if (Session["str"] != null)
                {
                    str = Session["str"].ToString();
                }
                cusID = int.Parse(str.ToString());
                /*if (trantype1 == "FE")
                {
                    string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";


                    if (GrdDetails.Rows.Count > 0)
                    {
                        str_RptName = "BL4PAN.rpt";
                        Session["str_sfs"] = "{FEBLDetails.blno}='" + blno.ToString() + "'" + "and {FEBLDetails.bid}=" + bid.ToString();
                        Session["LoginBranchid"] = bid.ToString();
                        DataAccess.Masters.MasterBranch objb = new DataAccess.Masters.MasterBranch();
                        str_sp = "location=" + objb.Getbranchname(Convert.ToInt32(GrdDetails.SelectedRow.Cells[9].Text)) + "~draft=Yes" + "~agent=Yes" + "~non=NO" + "~Doc=" + "FORWARDING PRIVATE LIMITED";
                        str_Script = "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                    ScriptManager.RegisterStartupScript(GrdDetails, typeof(GridView), "BLRelease", str_Script, true);
                    switch (trantype1)
                    {
                        case "FE":
                            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, blno.ToString() + " / BL View");
                            break;
                        case "FI":
                            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, blno.ToString() + " / BL View");
                            break;
                        case "AE":
                            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, blno.ToString() + " / BL View");
                            break;
                        case "AI":
                            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, blno.ToString() + " / BL View");
                            break;
                    }
                }
                    

                else if (trantype1 == "FI")
                {
                    string strTranType12 = "";
                    if (GrdDetails.Rows.Count > 0)
                    {
                        strTranType12 = GrdDetails.SelectedRow.Cells[13].Text;
                        iframecost.Attributes["src"] = "BLPrint.aspx";
                        popupfro.Visible = true;
                        PopupBL.Show();
                        string blno1 = GrdDetails.SelectedRow.Cells[9].Text;
                        Session["Blno"] = blno1.ToString();
                        Session["Btrantype"] = strTranType12.ToString();
                        bid = GrdDetails.SelectedRow.Cells[12].Text;
                        Session["LoginBranchid"] = bid.ToString();
                        switch (strTranType12)
                        {
                            case "FE":
                                cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, Session["Blno"] + " / BL View");
                                break;
                            case "FI":
                                cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, Session["Blno"] + " / BL View");
                                break;
                            case "AE":
                                cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, Session["Blno"] + " / BL View");
                                break;
                            case "AI":
                                cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, Session["Blno"] + " / BL View");
                                break;
                        }
                    }
                }

                else if (trantype1 == "AI")
                {
                    if (GrdDetails.Rows.Count > 0)
                    {
                        //int index = GrdDetails.SelectedRow.RowIndex;
                        bid = GrdDetails.SelectedRow.Cells[12].Text;
                        Session["LoginBranchid"] = bid.ToString();
                        string blno2 = "";
                        string strTranType3 = "";
                        strTranType3 = GrdDetails.SelectedRow.Cells[13].Text;
                        iframecost.Attributes["src"] = "AEIBLPrintNew.aspx";
                        popupfro.Visible = true;
                        PopupBL.Show();
                        blno2 = GrdDetails.SelectedRow.Cells[9].Text;
                        string flight = GrdDetails.Rows[index].Cells[4].Text;
                        Session["flight"] = flight.ToString();
                        Session["Blno"] = blno2.ToString();
                        Session["Btrantype"] = strTranType3.ToString();
                    }

                }

                */
                Fn_FillGrid();
            }
        }

        protected void ddl_module_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            string[] splitstatus;
            string name1="",name2="",name3="";
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);
            if (index == 0)
            {
                if (chkproducts.Items[0].Selected == true)
                {
                    for (int i = 0; i < chkproducts.Items.Count; i++)
                    {
                        if (chkproducts.Items[i].Text != "All")
                        {
                            chkproducts.Items[i].Selected = true;
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < chkproducts.Items.Count; i++)
                    {
                        chkproducts.Items[i].Selected = false;
                    }
                    txt_workprocess.Text = "";
                    return;
                }
            }
            else
            {
                for (int i = 0; i < chkproducts.Items.Count; i++)
                {
                    int a = chkproducts.Items.Count - 1;
                    int count = 0;
                    for (int j = 1; j <= chkproducts.Items.Count; j++)
                    {
                        count = count + 1;
                    }

                    if (a == count)
                    {
                        chkproducts.Items[0].Selected = true;
                    }
                }

                for (int i = 0; i < chkproducts.Items.Count; i++)
                {
                    if (chkproducts.Items[i].Selected == false)
                    {
                        chkproducts.Items[0].Selected = false;
                        break;
                    }
                }
            }

            string name = "";
            for (int i = 0; i < chkproducts.Items.Count; i++)
            {
                if (chkproducts.Items[i].Text != "All")
                {
                    if (chkproducts.Items[i].Selected)
                    {
                        name += chkproducts.Items[i].Text + ",";
                    }
                }
            }
            txt_workprocess.Text = name;

            

            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = ViewState["CurrentData"] as DataTable;
                if (dt.Rows.Count>0)
                {
                    DataView dv = dt.DefaultView;
                    if (txt_workprocess.Text == "All")
                    {
                        GrdDetails.DataSource = dt;
                        GrdDetails.DataBind();
                        ViewState["CurrentData"] = dt;
                    }
                    else
                    {
                        if (name.ToString() != "")
                        {
                            splitstatus = name.ToString().Split(',');
                            if (splitstatus.Length > 0)
                            {
                                //if (splitstatus.Length == 2)
                                //{
                                //    name1 = splitstatus[0].ToString();
                                //    name2 = splitstatus[1].ToString();

                                //}
                                //else
                                //{
                                //    name1 = splitstatus[0].ToString();
                                //    name2 = splitstatus[1].ToString();
                                //    name3 = splitstatus[2].ToString();
                                //}

                                for(int k=0;k<=splitstatus.Length-1;k++)
                                {
                                    if(splitstatus[k].ToString() == "Booked")
                                    {
                                        name1 = "Booked";
                                    }
                                    else if (splitstatus[k].ToString() == "Transit")
                                    {
                                        name2 = "Transit";
                                    }
                                    if (splitstatus[k].ToString() == "Closed")
                                    {
                                        name3= "Closed";
                                    }

                                }
                            }
                        }
                        else
                        {
                            DataTable dt1 = ViewState["CurrentData"] as DataTable;
                            GrdDetails.DataSource = dt1;
                            GrdDetails.DataBind();
                            ViewState["CurrentData"] = dt1;
                        }

                         if (name1 == "Booked" && name2 == "Transit" && name3 == "Closed")
                        {
                            dv.RowFilter = "type = '" + name1 + "'" + " or " + "type = '" + name2 + "'" + " or " + "type = '" + name3 + "'";

                            GrdDetails.DataSource = dv;
                            GrdDetails.DataBind();
                            //DataTable dt1 = ViewState["CurrentData"] as DataTable;
                            //GrdDetails.DataSource = dt1;
                            //GrdDetails.DataBind();
                            //ViewState["CurrentData"] = dt1;
                        }
                       
                        else if (name1 == "Booked" && name2 == "Transit")
                        {
                            dv.RowFilter = "type = '" + name1 + "'" + " or " +  "type = '"  + name2 + "'";

                            GrdDetails.DataSource = dv;
                            GrdDetails.DataBind();
                        }
                        else if (name1 == "Booked" && name3 == "Closed")
                        {
                            dv.RowFilter = "type = '" + name1 + "'" + " or " + "type = '" + name3 + "'";

                            GrdDetails.DataSource = dv;
                            GrdDetails.DataBind();
                        }
                        else if (name2 == "Transit" && name3 == "Closed")
                        {
                            dv.RowFilter = "type = '" + name2 + "'" + " or " + "type = '" + name3 + "'";

                            GrdDetails.DataSource = dv;
                            GrdDetails.DataBind();
                        }

                         else if (name1 == "Booked")
                         {
                             dv.RowFilter = "type = '" + name1 + "'";

                             GrdDetails.DataSource = dv;
                             GrdDetails.DataBind();
                         }

                         else if (name2 == "Transit")
                         {
                             dv.RowFilter = "type = '" + name2 + "'";

                             GrdDetails.DataSource = dv;
                             GrdDetails.DataBind();
                         }
                         else if (name3 == "Closed")
                         {
                             dv.RowFilter = "type = '" + name3 + "'";

                             GrdDetails.DataSource = dv;
                             GrdDetails.DataBind();
                         }


                       /* for (int i = 0; i < chkproducts.Items.Count; i++)
                        {
                            if (chkproducts.Items[i].Text != "Select All")
                            {
                                if (chkproducts.Items[i].Selected)
                                {
                                    //name += chkproducts.Items[i].Text + ",";
                                    

                                    if (chkproducts.Items[i].Text == "Booked" && chkproducts.Items[i].Text == "Transit")
                                    {
                                        dv.RowFilter = "type = '" + chkproducts.Items[i].Text + "' and "  + chkproducts.Items[i].Text + "'";
                                        GrdDetails.DataSource = dv;
                                        GrdDetails.DataBind();
                                    }
                                    else if (chkproducts.Items[i].Text == "Transit" && chkproducts.Items[i].Text == "Closed")
                                    {
                                        dv.RowFilter = "type = '" + chkproducts.Items[i].Text + "' and " + chkproducts.Items[i].Text + "'";
                                        GrdDetails.DataSource = dv;
                                        GrdDetails.DataBind();
                                    }
                                    else if (chkproducts.Items[i].Text == "Booked" && chkproducts.Items[i].Text == "Closed")
                                    {
                                        dv.RowFilter = "type = '" + chkproducts.Items[i].Text + "' and " + chkproducts.Items[i].Text + "'";
                                        GrdDetails.DataSource = dv;
                                        GrdDetails.DataBind();
                                    }

                                    else if (chkproducts.Items[i].Text == "Booked" && chkproducts.Items[i].Text == "Transit" && chkproducts.Items[i].Text == "Closed")
                                    {
                                        dv.RowFilter = "type = '" + chkproducts.Items[i].Text + "' and " + chkproducts.Items[i].Text + "' +and " + chkproducts.Items[i].Text + "'";
                                        GrdDetails.DataSource = dv;
                                        GrdDetails.DataBind();
                                    }
                                    else if (chkproducts.Items[i].Text == "Booked" || chkproducts.Items[i].Text == "Transit" || chkproducts.Items[i].Text == "Closed")
                                    {
                                        dv.RowFilter = "type = '" + chkproducts.Items[i].Text + "'";
                                        GrdDetails.DataSource = dv;
                                        GrdDetails.DataBind();
                                    }

                                }
                            }
                        }*/



                       
                       
                    }
                }
                else
                {
                    GrdDetails.DataSource = dt;
                    GrdDetails.DataBind();
                }

                //dataGridView1.DataSource = dv;
            }
        }

        protected void txtSrc_TextChanged(object sender, EventArgs e)
        {
            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = ViewState["CurrentData"] as DataTable;
                if (dt.Rows.Count > 0)
                {
                    DataView dv = dt.DefaultView;

                    if (txtSrc.Text != "")
                    {
                        dv.RowFilter = "Bookingno = '" + txtSrc.Text + "'";
                        //GrdDetails.DataSource = dv;
                        //GrdDetails.DataBind();
                        
                 
                        //dv.RowFilter = "blno = '" + txtSrc.Text + "'";
                        GrdDetails.DataSource = dv;
                        GrdDetails.DataBind();

                    }

                    else
                    {
                        GrdDetails.DataSource = dt;
                        GrdDetails.DataBind();
                    }
                    
                         
                  
                }
                else
                {
                    GrdDetails.DataSource = dt;
                    GrdDetails.DataBind();
                }

                //dataGridView1.DataSource = dv;
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {

          /*  DataTable dt = ViewState["CurrentData"] as DataTable;
            if (dt.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    dt.Columns.Remove("job");
                    dt.Columns.Remove("bid");
                    dt.Columns.Remove("trantype");
                    dt.Columns.Remove("flight");
                    wb.Worksheets.Add(dt, "CustomerBookingInfo");
                   
                   
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + "CustomerBookingInfo" + ".xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }

                    

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnExcel, typeof(Button), "DataFound", "alertify.alert('No Data Found');", true);
                return;
            }


           * 
            */


            if (GrdDetails.Rows.Count > 0)
            {
               // GrdDetails.Columns[10].Visible = false;
                    GrdDetails.Columns[14].Visible = false;
                    GrdDetails.Columns[15].Visible = false;
                    GrdDetails.Columns[16].Visible = false;
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=CustomerBookingInfo "+ ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (GrdDetails.Visible == true)
                {
                    GrdDetails.GridLines = GridLines.Both;
                    GrdDetails.HeaderStyle.Font.Bold = true;
                    GrdDetails.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }




        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {

            DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
            string filePath = "";
            string filename = "";
            string[] filename1;

            string[] branchname;
            string branchnameshortname = "";

            string c = "";

            if (!upd_document.HasFile)
            {
                // Label2.Text = "Please Select File";                          //if file uploader has no file selected
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Select Document Path');", true);
                upd_document.Focus();
            }
            else
            {
                if (upd_document.HasFile)
                {

                    try
                    {
                        if (Path.GetExtension(upd_document.PostedFile.FileName).ToLower() != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Upload PDF Document');", true);
                            return;
                        }
                        string[] str_Item = new string[9];





                        // Uploading.Uploading obj = new Uploading.Uploading();
                        DataAccess.Payroll.Details obj_da_Pay = new DataAccess.Payroll.Details();

                        DataAccess.Masters.MasterDocument obj_da_Document = new DataAccess.Masters.MasterDocument();
                        DataAccess.Documents obj_da_Doc = new DataAccess.Documents();

                        DataTable obj_dt = new DataTable();

                        if (btnSave.ToolTip == "Upload")
                        {

                            int int_Documentid = 0;

                            if (txt_booking.Text =="")
                            {
                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Booking  file not found');", true);
                                return;
                          
                            }

                            if (hid_blno.Value == "" && hid_bid.Value == "" && hid_trantype1.Value=="")
                            {
                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Booking file not found');", true);
                                return;

                            }



                            DataAccess.Documents obj_da_Document1 = new DataAccess.Documents();
                            DataTable obj_dt1 = new DataTable();

                            if (hid_bid.Value != "" && hid_blno.Value != "")
                            {
                                obj_dt1 = obj_da_Document1.GetDocDtls4ebooking(int.Parse(hid_bid.Value), hid_trantype1.Value, hid_blno.Value);
                            }
                            if (obj_dt1.Rows.Count > 0)
                            {
                                string str = upd_document.PostedFile.FileName.ToString();
                                string withoutspecialcharacters = RemoveSpecialChars(str);


                                int_Documentid = Convert.ToInt32(obj_dt1.Rows.Count);
                                int_Documentid = int_Documentid + 1;
                                if (int_Documentid != 0)
                                {

                                    

                                   // filename = hid_blno.Value + "-" + upd_document.PostedFile.FileName.ToString() + "-" + int_Documentid + ".pdf";
                                    filename = hid_blno.Value + "-" + withoutspecialcharacters + "-" + int_Documentid + ".pdf";
                                }

                            }
                            else
                            {
                                string str1 = upd_document.PostedFile.FileName.ToString();
                                string withoutspecialcharacters1 = RemoveSpecialChars(str1);

                                int_Documentid = int_Documentid + 1;
                                //  filename = hid_blno.Value + "-" + upd_document.PostedFile.FileName.ToString() + "-" + int_Documentid + ".pdf";

                                filename = hid_blno.Value + "-" + withoutspecialcharacters1 + "-" + int_Documentid + ".pdf";
                            }



                            if (filename != "")
                            {
                                if (hid_bid.Value != "" && hid_blno.Value != "" && hid_trantype1.Value != "")
                                {
                                    int_Documentid = Convert.ToInt32(obj_da_Doc.InsebookingDocuments(Convert.ToInt32(hid_bid.Value), hid_trantype1.Value, hid_blno.Value, int_Documentid, "Booking-Status", "", filename, Session["username"].ToString(), "", "", "", "", Convert.ToInt32(Session["webgroupid"].ToString()), Convert.ToInt32("0"), Convert.ToInt32("0"), Convert.ToInt32("0"), Convert.ToInt32("0")));//str_alltype

                                }
                                upd_document.SaveAs(Server.MapPath("~/UploadDocument/Ebooking/" + filename));
                                c = (Server.MapPath("~/UploadDocument/Ebooking/") + filename);
                                try
                                {
                                    UploadFileToFTP(filename, c);
                                }
                                catch (Exception ex)
                                {
                                    lbl_DispMsg.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                                }
                                finally
                                {

                                    System.IO.File.Delete(c);
                                }


                                obj_da_Doc.updatefileforEbooking(int_Documentid, filename);
                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Document Uploaded');", true);


                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('File not found');", true);
                                return;
                            }
                            Fn_FillGrid();

                        }

                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            //btnclose.Text = "Cancel";
            //btn_cancel.ToolTip = "Cancel";
            //btn_cancel.Attributes["class"] = "btn ico-cancel";
        }

        protected  void UploadFileToFTP(string source, string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }

                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
                // added on 25Mar2023 
                username = "vmadmin";
                password = "VMWeb20Mar@)@#";

                String sourcefilepath = source; // e.g. "d:/test.docx"
                String ftpurl = "ftp://20.235.30.214/SL/Ebooking/" + sourcefilepath; // e.g. ftp://serverip/foldername/foldername
                String ftpusername = username; //"ifrtAdmin"; // e.g. username
                String ftppassword = password;//"05Jun!(&%"; // e.g. password



                string filename = Path.GetFileName(source);
                string ftpfullpath = ftpurl;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(path); //File.OpenRead(source);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();

                //// get file bytes
                //byte[] fileBytes = File.ReadAllBytes(source);
                //ftp.ContentLength = fileBytes.Length;

                //Stream ftpstream = ftp.GetRequestStream();
                //ftpstream.Write(fileBytes, 0, fileBytes.Length);
                //ftpstream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
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
                    if (hid_blno.Value != "")
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

                    }


                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void grpupdload_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    string filename = "";

                    obj_dt = (DataTable)Session["dt"];
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    DataAccess.Documents Dobj = new DataAccess.Documents();


                    DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
                    DataAccess.ForwardingExports.ISFDetails obj = new DataAccess.ForwardingExports.ISFDetails();
                    DataTable dt = new DataTable();
                    //if (Session["LoginDivisionId"] != null)
                    //{
                    //    intBranchID = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), txtbranchoff.SelectedItem.Text);
                    //    hid_branchid.Value = intBranchID.ToString();
                    //    dt = obj.GetBdtls(intBranchID);
                    //    txt_branchaddress.Text = dt.Rows[0]["address"].ToString();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Branch');", true);
                    //}
                    if (hid_bid.Value != "" && hid_blno.Value != "")
                    {
                        Dobj.Geteboookingdeleteftpdile(Convert.ToInt32(grpupdload.Rows[grd.RowIndex].Cells[3].Text), Convert.ToInt32(hid_bid.Value), hid_blno.Value);
                    }

                    ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);
                    obj_dt.Rows[grd.RowIndex].Delete();
                    obj_dt.AcceptChanges();
                    filename = grpupdload.Rows[grd.RowIndex].Cells[4].Text;

                    Fn_FillGrid();
                    ftpdeleted(filename);


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grpupdload_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void fttnormaldwd()
        {

            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

            // added on 25Mar2023 
            username = "vmadmin";
            password = "VMWeb20Mar@)@#";
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

                DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
                DataAccess.ForwardingExports.ISFDetails obj = new DataAccess.ForwardingExports.ISFDetails();
                DataTable dt = new DataTable();
                //if (Session["LoginDivisionId"] != null)
                //{
                //    intBranchID = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), txtbranchoff.SelectedItem.Text);
                //    hid_branchid.Value = intBranchID.ToString();
                //    dt = obj.GetBdtls(intBranchID);
                //    txt_branchaddress.Text = dt.Rows[0]["address"].ToString();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Branch');", true);
                //}
                if (hid_bid.Value != "" && hid_blno.Value != "")
                {
                    obj_dt = obj_da_Document.GetDocDtls4ebooking(int.Parse(hid_bid.Value), hid_trantype1.Value, hid_blno.Value);
                }

                if (obj_dt.Rows.Count > 0)
                {

                    grpupdload.DataSource = obj_dt;
                    grpupdload.DataBind();


                    Session["dt"] = obj_dt;



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




        protected void ftpdeleted(string filename)
        {

            try
            {
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }

                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

                // added on 25Mar2023 
                username = "vmadmin";
                password = "VMWeb20Mar@)@#";


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/Ebooking/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
             //   request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
                request.Credentials = new NetworkCredential(username, password);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    //  return response.StatusDescription;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



       /* public string RemoveSpecialChars(string str)
        {


            string[] chars = new string[] { ",", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };

            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "");

                }
            }
            return str;
        }*/


        public  string RemoveSpecialChars(string str)
        {
            // Create  a string array and add the special characters you want to remove
            string[] chars = new string[] { " ", "-", ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "");
                }
            }
            return str;
        }


    }
}