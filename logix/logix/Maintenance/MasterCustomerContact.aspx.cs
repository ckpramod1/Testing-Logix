using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;

namespace logix.Maintenance
{
    public partial class MasterCustomerContact : System.Web.UI.Page
    {

        DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
        string idfilename;
        string username = "";
        string password = "";
        protected string DBCS;
        string ip = "";
        string dbname = "";
        string a, b;
        string txtcustomer;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }


            if (!IsPostBack)
            {
                hf_customerid.Value = Session["txtcustomerid"].ToString();
                txtcustomer = Session["txtpancustomer"].ToString();

                Fn_LoadDesignation();

                if (Session["txtpancustomer"] != null)
                {
                    string customername = Session["txtpancustomer"].ToString();
                    lblcustomername.Text = customername.ToUpper();
                }
                if (!string.IsNullOrEmpty(Session["txtpanno"].ToString()))
                {
                    lblpanno.Text = Session["txtpanno"].ToString();
                }
                else
                {
                    plblan.Visible = false;
                }
                GetBusinesscardDetails();
            }
            else
            {
                hf_customerid.Value = Session["txtcustomerid"].ToString();
                txtcustomer = Session["txtpancustomer"].ToString();

                if (Session["txtpancustomer"] != null)
                {
                    string customername = Session["txtpancustomer"].ToString();
                    lblcustomername.Text = customername.ToUpper();
                }
                if (Session["txtpanno"] != null)
                {
                    lblpanno.Text = Session["txtpanno"].ToString();
                }
                else
                {
                    plblan.Visible = false;
                }
                if (!string.IsNullOrEmpty(Session["hidpaninput"].ToString()))
                {
                    hidpaninput.Value = Session["hidpaninput"].ToString();
                    if (hidpaninput.Value == "Y")
                    {
                        plblan.Visible = false;
                    }
                }

            }
        }

        protected void ddlposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdBusinesscard.Rows.Count > 0)
            {
                for (int i = 0; i < grdBusinesscard.Rows.Count; i++)
                {
                    if (grdBusinesscard.Rows[i].Cells[2].Text == ddlposition.SelectedItem.Text)
                    {
                        ddlposition.SelectedValue = "";
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Exist Same Designation Delete than Add');", true);
                        return;
                    }
                }
            }
        }

        //protected void grdBusinesscard_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "Delete")
        //        {
        //            ImageButton Img_delete = (ImageButton)e.CommandSource;
        //            GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
        //            DataTable obj_dt = new DataTable();
        //            string filename = "";
        //            int Index = grd.RowIndex;
        //            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        //            if (!string.IsNullOrWhiteSpace(grdBusinesscard.Rows[grd.RowIndex].Cells[4].Text))
        //            {
        //                filename = grdBusinesscard.Rows[grd.RowIndex].Cells[5].Text;
        //                if (filename != "")
        //                {
        //                    ftpdeleted(filename);
        //                }
        //                obj_MasterCustomer.DeleteMCUploadinfo(Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[0].Text), Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[1].Text));
        //                GetBusinesscardDetails();
        //                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "JobInfo", "alertify.alert('Card Details deleted');", true);
        //                ddlposition.SelectedValue = "0";
        //                ddlTitle.SelectedValue = "0";
        //                txtName.Text = "";
        //                txt_email.Text = "";
        //            }
        //            else
        //            {
        //                obj_MasterCustomer.DeleteMCUploadinfo(Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[0].Text), Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[1].Text));
        //                ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('No File To deleted');", true);
        //                GetBusinesscardDetails();
        //                ddlposition.SelectedValue = "0";
        //                ddlTitle.SelectedValue = "0";
        //                txtName.Text = "";
        //                txt_email.Text = "";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //    btn_Upload.ToolTip = "Add";
        //}

        protected void ftpdeleted(string filename)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/Mastercustomer/BusinessCard/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
                request.Credentials = new NetworkCredential(Hid_ServerUsername.Value, Hid_ServerPWD.Value);
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


        protected void grdBusinesscard_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdBusinesscard_PreRender(object sender, EventArgs e)
        {
            if (grdBusinesscard.Rows.Count > 0)
            {
                grdBusinesscard.UseAccessibleHeader = true;
                grdBusinesscard.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            if (hf_customerid.Value == "0" || hf_customerid.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Save The Customer Details Then Add');", true);

                return;
            }
            if (txtcustomer == "" && hf_customerid.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Customer Name');", true);
                // txtcustomer.Focus();
                return;
            }
            //else if (ddlposition.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Select DESIGNATION');", true);
            //    ddlposition.Focus();
            //    return;
            //}
            //else if (txtName.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter the Name');", true);
            //    txtName.Focus();
            //}
            //else if (FileUpd_logo5.FileName == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Choose the Card');", true);
            //    txtName.Focus();
            //    return;
            //}
            //else
            //{
            if (FileUpd_logo5.FileName != "")
            {
                SaveBusinessCardDetails();
            }


            //if (ddl_designation.SelectedValue=="" || ddl_designation.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Select designation');", true);
            //    // txtcustomer.Focus();
            //    return;
            //}


            else
            {
                string data = string.Empty;
                if (idfilename == "null")
                {
                    data = idfilename;
                }
                if (btn_Upload.ToolTip == "Add")
                {

                    string Result = obj_MasterCustomer.InsertBusinessCardInfotoCustomerContactpage(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, data, ddlTitle.Text,  ddl_designation.SelectedValue.ToString(),txt_Phone.Text,txt_email.Text);
                    if (hf_customerid.Value != "")
                    {
                        DataTable dtt = obj_MasterCustomer.sp_getBusinessCardInfoCustomer(Convert.ToInt32(hf_customerid.Value), txtName.Text, ddlposition.SelectedValue);
                        if (dtt.Rows.Count > 0)
                        {
                            string hidcustomerinfo = string.Empty;
                            hidcustomerinfo = dtt.Rows[0]["MCUploadinfo"].ToString();
                            if (hidcustomerinfo != "")
                            {
                                obj_MasterCustomer.SPfileuploadbusinesscard(int.Parse(hf_customerid.Value), txt_email.Text, Convert.ToInt16(hidcustomerinfo));
                            }
                        }
                    }
                    // obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
                    // System.IO.File.Delete(c);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);
                }
                else
                {
                    string filename = string.Empty;
                    if (FileUpd_logo5.FileName == "")
                    {
                        filename = Session["contactfilename"].ToString();
                        if (filename != "")
                        {
                            data = filename;
                        }

                        //filename = grdBusinesscard.Rows[index].Cells[5].Text;
                    }
                    string Result = obj_MasterCustomer.UpdateDetailsuploadContactpage(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, data, ddlTitle.Text, ddl_designation.SelectedValue.ToString(), txt_Phone.Text, txt_email.Text);
                    if (hf_customerid.Value != "")
                    {
                        DataTable dtt = obj_MasterCustomer.sp_getBusinessCardInfoCustomer(Convert.ToInt32(hf_customerid.Value), txtName.Text, ddlposition.SelectedValue);
                        if (dtt.Rows.Count > 0)
                        {
                            string hidcustomerinfo = string.Empty;
                            hidcustomerinfo = dtt.Rows[0]["MCUploadinfo"].ToString();
                            if (hidcustomerinfo != "")
                            {
                                obj_MasterCustomer.SPfileuploadbusinesscard(int.Parse(hf_customerid.Value), txt_email.Text, Convert.ToInt16(hidcustomerinfo));
                            }
                        }
                    }
                    //obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
                    // System.IO.File.Delete(c);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);

                }
                GetBusinesscardDetails();
                ClearUploadDetails();
            }
            // }
        }


        private void SaveBusinessCardDetails()
        {
            string[] splitFilename = FileUpd_logo5.FileName.Split('.');
            string Afterdot = "";
            if (splitFilename.Length > 0)
            {
                Afterdot = splitFilename[1].ToString();
            }
            if (Afterdot.ToUpper() == "JPG" || Afterdot.ToUpper() == "JPEG" || Afterdot.ToUpper() == "PNG" || Afterdot.ToUpper() == "BMP" || Afterdot.ToUpper() == "TIF")
            {
                if (FileUpd_logo5.FileName != "")
                {
                    string idfilename = "", c = "";
                    if (hf_customerid.Value != "" && hf_customerid.Value != null)
                    {
                        int NoInc = 0;
                        if (grdBusinesscard.Rows.Count > 0)
                        {
                            NoInc = grdBusinesscard.Rows.Count + 1;
                        }
                        else
                        {
                            NoInc = grdBusinesscard.Rows.Count + 1;
                        }

                        FileUpd_logo5.SaveAs(Server.MapPath("~/UploadDocument/Businesscard/" + hf_customerid.Value + "-" + "" + NoInc + FileUpd_logo5.FileName));
                        c = (Server.MapPath("~/UploadDocument/Businesscard/") + hf_customerid.Value + "-" + "" + NoInc + Path.GetFileName(FileUpd_logo5.FileName));
                        idfilename = hf_customerid.Value + "-" + "" + NoInc + Path.GetFileName(FileUpd_logo5.FileName);
                        fileupload(NoInc + "" + FileUpd_logo5.FileName, c);
                        if (btn_Upload.ToolTip == "Add")
                        {

                            string Result = obj_MasterCustomer.InsertBusinessCardInfotoCustomerContactpage(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, idfilename, ddlTitle.Text, ddl_designation.SelectedValue.ToString(), txt_Phone.Text, txt_email.Text);
                            // obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
                            if (hf_customerid.Value != "")
                            {
                                DataTable dtt = obj_MasterCustomer.sp_getBusinessCardInfoCustomer(Convert.ToInt32(hf_customerid.Value), txtName.Text, ddlposition.SelectedValue);
                                if (dtt.Rows.Count > 0)
                                {
                                    string hidcustomerinfo = string.Empty;
                                    hidcustomerinfo = dtt.Rows[0]["MCUploadinfo"].ToString();
                                    if (hidcustomerinfo != "")
                                    {
                                        obj_MasterCustomer.SPfileuploadbusinesscard(int.Parse(hf_customerid.Value), txt_email.Text, Convert.ToInt16(hidcustomerinfo));
                                    }
                                }
                            }
                            System.IO.File.Delete(c);
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);
                        }
                        else
                        {
                            string Result = obj_MasterCustomer.UpdateDetailsuploadContactpage(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, idfilename, ddlTitle.Text, ddl_designation.SelectedValue.ToString(), txt_Phone.Text, txt_email.Text);
                            //obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
                            if (hf_customerid.Value != "")
                            {
                                DataTable dtt = obj_MasterCustomer.sp_getBusinessCardInfoCustomer(Convert.ToInt32(hf_customerid.Value), txtName.Text, ddlposition.SelectedValue);
                                if (dtt.Rows.Count > 0)
                                {
                                    string hidcustomerinfo = string.Empty;
                                    hidcustomerinfo = dtt.Rows[0]["MCUploadinfo"].ToString();
                                    if (hidcustomerinfo != "")
                                    {
                                        obj_MasterCustomer.SPfileuploadbusinesscard(int.Parse(hf_customerid.Value), txt_email.Text, Convert.ToInt16(hidcustomerinfo));
                                    }
                                }
                            }
                            // System.IO.File.Delete(c);
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);
                        }
                        GetBusinesscardDetails();
                        ClearUploadDetails();

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Customer Name and Business Card');", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Format Try to Add image Extension Filename .JPG .JPEG .PNG .BMP');", true);
            }
        }


        private void fileupload(string filenames, string path)
        {
            //b = Path.GetFileName(filenames);
            //a = "ftp://20.235.30.214//Mastercustomer/BusinessCard/" + hf_customerid.Value + "-" + filenames;
            //FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            ////req.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            //req.Credentials = new NetworkCredential(Hid_ServerUsername.Value, Hid_ServerPWD.Value);
            //req.Method = WebRequestMethods.Ftp.UploadFile;
            //req.Proxy = null;
            //byte[] file = System.IO.File.ReadAllBytes(path);
            //System.IO.Stream str = req.GetRequestStream();
            //str.Write(file, 0, file.Length);
            //str.Close();
            //str.Dispose();
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
            b = Path.GetFileName(filenames);
            a = "ftp://20.235.30.214/SL/Mastercustomer/BusinessCard/" + hf_customerid.Value + "-" + filenames;
            FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            //req.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            req.Credentials = new NetworkCredential(username, password);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Proxy = null;
            byte[] file = System.IO.File.ReadAllBytes(path);
            System.IO.Stream str = req.GetRequestStream();
            str.Write(file, 0, file.Length);
            str.Close();
            str.Dispose();
        }

        public void GetBusinesscardDetails()
        {
            if (hf_customerid.Value != "")
            {
                DataTable dtt = obj_MasterCustomer.GetBusinessCardInfotoCustomer(Convert.ToInt32(hf_customerid.Value));
                grdBusinesscard.DataSource = new DataTable();
                grdBusinesscard.DataBind();
                if (dtt.Rows.Count > 0)
                {
                    grdBusinesscard.DataSource = dtt;
                    grdBusinesscard.DataBind();
                }
                else
                {
                    grdBusinesscard.DataSource = new DataTable();
                    grdBusinesscard.DataBind();
                }
            }
        }

        public void ClearUploadDetails()
        {
            ddlposition.SelectedValue = "";
            ddlTitle.Text = "Mr";
            txtName.Text = "";
            txt_email.Text = "";
            ddl_designation.SelectedItem.Text = "ddl_designation";
            txt_Phone.Text = "";
        }


        protected void grdBusinesscard_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grdBusinesscard.SelectedRow.RowIndex;
                string filename1;
                if (grdBusinesscard.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    if (txtcustomer != "")
                    {
                        if (!string.IsNullOrWhiteSpace(grdBusinesscard.Rows[index].Cells[5].Text))// 2 change to 5
                        {
                            filename1 = grdBusinesscard.Rows[index].Cells[5].Text;
                            if (hf_customerid.Value != "")
                            {
                                string Test = "1";//0
                                ScriptManager.RegisterStartupScript(grdBusinesscard, typeof(GridView), "Download", "window.open('../Download.aspx?File=" + filename1 + "&Test=" + Test + "');", true);
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                                return;
                            }
                            txtName.Text = grdBusinesscard.Rows[index].Cells[3].Text;
                            txt_email.Text = grdBusinesscard.Rows[index].Cells[7].Text;
                            txt_Phone.Text = grdBusinesscard.Rows[index].Cells[6].Text;
                            string data = grdBusinesscard.Rows[index].Cells[4].Text;
                            ddl_designation.SelectedValue = grdBusinesscard.Rows[index].Cells[5].Text;

                            Session["contactfilename"] = grdBusinesscard.Rows[index].Cells[8].Text;
                            if (data != " ")
                            {
                                // ddlposition.SelectedItem.Text
                                if (data == "EXPORT")
                                {
                                    ddlposition.SelectedValue = "EH";
                                }
                                else if (data == "IMPORT")
                                {
                                    ddlposition.SelectedValue = "IH";
                                }
                                else if (data == "FINANCE")
                                {
                                    ddlposition.SelectedValue = "FH";
                                }
                                else if (data == "MANAGEMENT")
                                {
                                    ddlposition.SelectedValue = "MH";
                                }
                                else if (data == "COMMERCIAL")
                                {
                                    ddlposition.SelectedValue = "CH";
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('No File To Download');", true);
                            //txtcustomer.Focus();
                            // txt_gstin.Focus();
                            txtName.Text = grdBusinesscard.Rows[index].Cells[3].Text;
                            txt_email.Text = grdBusinesscard.Rows[index].Cells[7].Text;
                            string data = grdBusinesscard.Rows[index].Cells[4].Text;
                            if (data != " ")
                            {
                                // ddlposition.SelectedItem.Text
                                if (data == "EXPORT")
                                {
                                    ddlposition.SelectedValue = "EH";
                                }
                                else if (data == "IMPORT")
                                {
                                    ddlposition.SelectedValue = "IH";
                                }
                                else if (data == "FINANCE")
                                {
                                    ddlposition.SelectedValue = "FH";
                                }
                                else if (data == "MANAGEMENT")
                                {
                                    ddlposition.SelectedValue = "MH";
                                }
                                else if (data == "COMMERCIAL")
                                {
                                    ddlposition.SelectedValue = "CH";
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Please Enter the Customer #');", true);
                        //txtcustomer.Focus();
                        //txt_gstin.Focus();
                    }
                }
                btn_Upload.ToolTip = "Update";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void grdBusinesscard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    if (i != 5)
                    {
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBusinesscard, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                        //ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                    }
                }
            }
        }

        protected void grdBusinesscard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    string filename = "";
                    int Index = grd.RowIndex;
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    if (!string.IsNullOrWhiteSpace(grdBusinesscard.Rows[grd.RowIndex].Cells[4].Text))
                    {
                        filename = grdBusinesscard.Rows[grd.RowIndex].Cells[5].Text;
                        if (filename != "")
                        {
                            ftpdeleted(filename);
                        }
                        obj_MasterCustomer.DeleteMCUploadinfo(Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[0].Text), Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[1].Text));
                        GetBusinesscardDetails();
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "JobInfo", "alertify.alert('Card Details deleted');", true);
                        ddlposition.SelectedValue = "";
                        ddlTitle.SelectedValue = "0";
                        txtName.Text = "";
                        txt_email.Text = "";
                    }
                    else
                    {
                        obj_MasterCustomer.DeleteMCUploadinfo(Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[0].Text), Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[1].Text));
                        ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('No File To deleted');", true);
                        GetBusinesscardDetails();
                        ddlposition.SelectedValue = "";
                        ddlTitle.SelectedValue = "";
                        txtName.Text = "";
                        txt_email.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_Upload.ToolTip = "Add";
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearUploadDetails();
        }
        private void Fn_LoadDesignation()
        {
            DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDesign();

           
            ddl_designation.DataSource = obj_dt;
            ddl_designation.DataTextField = "designame";
            ddl_designation.DataBind();
            ddl_designation.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Designation", "0"));
        }
    }
}