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
    public partial class MasterCustomerKYC : System.Web.UI.Page
    {
        string idfilename;
        string username = "";
        string password = "";
        protected string DBCS;
        string ip = "";
        string dbname = "";
        string a, b, c;
        string txtcustomer;
        int k = 1, ddlid, ddlid1;
        string txtPancustomer, txtpanno;

        DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            if (!IsPostBack)
            {
                hf_customerid.Value = Session["txtcustomerid"].ToString();
                txtPancustomer = Session["txtpancustomer"].ToString();
                hid_pan.Value = Session["Hidpanno"].ToString();
                txtpanno = Session["txtpanno"].ToString();
                if (!string.IsNullOrEmpty(Session["txtpancustomer"].ToString()))
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
                if (!string.IsNullOrEmpty(Session["hidpaninput"].ToString()))
                {
                    hidpaninput.Value = Session["hidpaninput"].ToString();
                    if (hidpaninput.Value == "Y")
                    {
                        plblan.Visible = false;
                    }
                }
                kycGrid();
                ddlCustomerTypefill();
            }
            else if (Page.IsPostBack)
            {
                //txtlocation_TextChanged1(sender, e);
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }
        }


        private void ddlCustomerTypefill()
        {
            DataTable dttype = new DataTable();
            ddlIDProof.Items.Clear();
            dttype = obj_MasterCustomer.SPSelKYCProofCust("N");
            if (dttype.Rows.Count > 0)
            {
                ddlIDProof.Items.Add("");
                for (int i = 0; i <= dttype.Rows.Count - 1; i++)
                {
                    ddlIDProof.Items.Add(dttype.Rows[i]["Proofmaster"].ToString());
                }
            }
        }

        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;
            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
            //    }
            //Bhuvana
        }


        private void CheckDataforkyc()
        {
            if (ddlIDProof.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer IDProof Type cannot be Blank');", true);
                ddlIDProof.Focus();
                k = 0;
                return;
            }
            else if (!(KycUpload.HasFile))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('ID Proof of File DocPath cannot be Blank');", true);
                KycUpload.Focus();
                k = 0;
                return;
            }
        }

        private void savekyc()
        {
            CheckDataforkyc();
            if (k == 1)
            {
                if (hf_customerid.Value != "" && hf_customerid.Value != null)
                {
                    //if (Path.GetExtension(fuIDDoc.FileName) == ".pdf")
                    //{
                    if (ddlIDProof.Text == "Voter ID")
                    {
                        ddlid = 1;
                    }
                    if (ddlIDProof.Text == "PAN Card")
                    {
                        ddlid = 2;
                    }
                    if (ddlIDProof.Text == "Aadhar ID")
                    {
                        ddlid = 3;
                    }
                    if (ddlIDProof.Text == "GST")
                    {
                        ddlid = 4;
                    }
                    if (ddlIDProof.Text == "KYC")
                    {
                        ddlid = 5;
                    }
                    if (ddlIDProof.Text == "MSME certificate")
                    {
                        ddlid = 6;
                    }
                    if (ddlIDProof.Text == "Cancel Cheque")
                    {
                        ddlid = 7;
                    }
                    if (ddlIDProof.Text == "Credit form")
                    {
                        ddlid = 8;
                    }

                    KycUpload.SaveAs(Server.MapPath("~/UploadDocument/Proofs/" + hf_customerid.Value + "-" + ddlid + "-" + KycUpload.FileName));
                    c = (Server.MapPath("~/UploadDocument/Proofs/") + hf_customerid.Value + "-" + ddlid + "-" + Path.GetFileName(KycUpload.FileName));
                    idfilename = hf_customerid.Value + "-" + ddlid + "-" + Path.GetFileName(KycUpload.FileName);
                    IdProoffileupload(KycUpload.FileName, c);
                    //  obj_MasterCustomer.KycUpload(1, int.Parse(hf_customerid.Value), int.Parse(Session["LoginEmpId"].ToString()), ddlid, ddlIDProof.Text, idfilename);
                    if (txtpanno == "" && txtPancustomer == "")
                    {
                        string data = hf_customerid.Value;
                        hid_pan.Value = data;
                    }

                    obj_MasterCustomer.KycUploadnew(1, int.Parse(hf_customerid.Value), int.Parse(Session["LoginEmpId"].ToString()), ddlid, ddlIDProof.Text, idfilename, Convert.ToInt32(hid_pan.Value));
                    System.IO.File.Delete(c);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('KYC Uploaded Successfully');", true);

                    //DataTable dt = (DataTable)ViewState["vst"];
                    //DataRow newrow = dt.NewRow();
                    //newrow["proof"] = ddlIDProof.Text;
                    //newrow["filename"] = fuIDDoc.FileName;
                    //newrow["path"] = c;
                    //dt.Rows.Add(newrow);
                    //dt.AcceptChanges();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Upload Only PDF Files');", true);
                    //}
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Customer Name and Update KYC');", true);
                }
            }
        }

        private void IdProoffileupload(string filenames, string path)
        {
            //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            //{
            //    DBCS = reader.ReadLine();
            //}
            //ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            //dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

            //b = Path.GetFileName(filenames);
            //a = "ftp://20.235.30.214/FFDEMO/KYC/" + hf_customerid.Value + "-" + ddlid + "-" + filenames;
            //FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            //req.Credentials = new NetworkCredential(username, password);
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
            a = "ftp://20.235.30.214/SL/KYC/" + hf_customerid.Value + "-" + ddlid + "-" + filenames;
            FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            req.Credentials = new NetworkCredential(username, password);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Proxy = null;
            byte[] file = System.IO.File.ReadAllBytes(path);
            System.IO.Stream str = req.GetRequestStream();
            str.Write(file, 0, file.Length);
            str.Close();
            str.Dispose();
        }


        public void kycGrid()
        {
            Pl_Proof.Visible = true;
            GrdProofkyc.Visible = true;
            DataTable GrdProofdt = new DataTable();
            //GrdProofdt = obj_MasterCustomer.GridKycproof(2, hf_customerid.Value);
            if (hf_customerid.Value != "")
            {
                //string Type1;
                //if (ddlCType.SelectedItem.Text == "Agent / Principal / Counter Part")
                //{
                //    Type1 = "P";
                //}
                //else if (ddlCType.SelectedItem.Text == "Depo")
                //{
                //    Type1 = "W";
                //}
                //else if (ddlcategory.SelectedValue == "5")
                //{
                //    Type1 = "P";
                //}
                //else if (ddlfacategory.SelectedValue == "4")
                //{
                //    Type1 = "P";
                //}
                //else
                //{
                //    Type1 = "C";
                //}
                //if (Type1 == "P")
                //{
                //    string data = hf_customerid.Value;
                //    hid_pan.Value = data;
                //}
                //if (Type1 == "C" && ddlcategory.SelectedItem.Text == "OtherCountry")
                //{
                //    string data = hf_customerid.Value;
                //    hid_pan.Value = data;
                //}

                GrdProofdt = obj_MasterCustomer.KycUploadnew(2, int.Parse(hf_customerid.Value), int.Parse(Session["LoginEmpId"].ToString()), ddlid, ddlIDProof.Text, idfilename, Convert.ToInt32(hid_pan.Value));
                if (GrdProofdt.Rows.Count > 0)
                {
                    GrdProofkyc.DataSource = GrdProofdt;
                    GrdProofkyc.DataBind();
                }
                else
                {
                    DataTable dtp = new DataTable();
                    GrdProofkyc.DataSource = dtp;
                    GrdProofkyc.DataBind();
                }
            }
        }

        protected void btnkyc_Click(object sender, EventArgs e)
        {
            if (hf_customerid.Value != "" && hf_customerid.Value != "0")
            {

                if (GrdProofkyc.Rows.Count >= 0)
                {
                    for (int i = 0; i < GrdProofkyc.Rows.Count; i++)
                    {
                        if (GrdProofkyc.Rows[i].Cells[0].Text == ddlIDProof.Text)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ddlIDProof.Text + " Already Exist');", true);
                            return;
                        }
                    }
                }
                savekyc();
                kycGrid();
                ddlIDProof.SelectedIndex = 0;
                //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1730, 1, int.Parse(Session["LoginBranchid"].ToString()), hid_customerid + "-" + idfilepath + "-" + addfilepath);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('KYC Uploaded Successfully');", true);
                //txtclear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Save Customer Details After that Update the Customer KYC');", true);
                return;
            }
        }

        protected void GrdProofkyc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ftpKycdeleted(string filename)
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
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/KYC/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                // request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
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

        protected void test_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //   // e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Right;
            //     e.Row.Cells[17].Attributes.CssStyle["text-align"] = "Right";
            //}

        }

        protected void test_PreRender(object sender, EventArgs e)
        {
            if (test.Rows.Count > 0)
            {
                test.UseAccessibleHeader = true;
                test.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdProof_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdProofkyc, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }


        protected void GrdProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GrdProofkyc.SelectedRow.RowIndex;
                string filenamedownload = string.Empty;
                if (GrdProofkyc.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    if (txtcustomer != "")
                    {
                        if (!string.IsNullOrWhiteSpace(GrdProofkyc.Rows[index].Cells[1].Text))
                        {
                            filenamedownload = GrdProofkyc.Rows[index].Cells[1].Text;
                            if (hf_customerid.Value != "")
                            {
                                //fttnormaldwd(filename1);
                                string Test = "0";
                                ScriptManager.RegisterStartupScript(GrdProofkyc, typeof(GridView), "Download", "window.open('../Download.aspx?Filename=" + filenamedownload + "&Test=" + Test + "');", true);
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('No File To Download');", true);
                            //txtcustomer.Focus();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Please Enter the Customer #');", true);
                        //  txtcustomer.Focus();
                    }
                }
            }
            catch
            {

            }
        }

        protected void GrdProofkyc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    string filename = "";
                    //obj_dt = (DataTable)Session["dt"];
                    if (!string.IsNullOrWhiteSpace(GrdProofkyc.Rows[grd.RowIndex].Cells[1].Text))
                    {
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "Voter ID")
                        {
                            ddlid1 = 1;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "PAN Card")
                        {
                            ddlid1 = 2;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "Aadhar ID")
                        {
                            ddlid1 = 3;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "GST")
                        {
                            ddlid1 = 4;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "KYC")
                        {
                            ddlid1 = 5;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "MSME certificate")
                        {
                            ddlid1 = 6;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "Cancel Cheque")
                        {
                            ddlid1 = 7;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "Credit form")
                        {
                            ddlid1 = 8;
                        }
                        obj_MasterCustomer.kycDeleteProof(3, Convert.ToInt32(hf_customerid.Value), GrdProofkyc.Rows[grd.RowIndex].Cells[1].Text, ddlid1);
                        //obj_dt.Rows[grd.RowIndex].Delete();
                        //obj_dt.AcceptChanges();
                        filename = GrdProofkyc.Rows[grd.RowIndex].Cells[1].Text;
                        ftpKycdeleted(filename);
                        kycGrid();
                        //  ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('File has been deleted');", true);
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('No File To deleted');", true);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('No File To deleted');", true);
                    }
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