using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.IO;

namespace logix.Corporate
{
    public partial class DownloadDoc : System.Web.UI.Page
    {
        DataAccess.HR.Employee objHrEmp = new DataAccess.HR.Employee();

        DataTable dtTable = new DataTable();

        DataTable dt = new DataTable();
        DataAccess.LogDetails logDetails = new DataAccess.LogDetails();

        DataAccess.Documents objDocuments = new DataAccess.Documents();

        DataAccess.Masters.MasterPort objMasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.UserPermission user_check = new DataAccess.UserPermission();

        string Remarks, filenameloc;

        int docid,i, dcmtid;
        string ModuleName;

        int intbranchid;
        
        string username = "";
        string password = "";


        string ip = "";
        string dbname = "";

        protected string DBCS;
     

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grdbudget);
            DivisionBind();

            BranchBind();

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                try
                {
                    ModuleName = Session["StrTranType"].ToString();
                    Session["dt"] = "";
                    if (ModuleName == "CO" && ModuleName == "CA")
                    {
                       
                        ddl_division.Text = Session["LoginDivisionName"].ToString();

                        ddl_branch.Text= Session["LoginBranchName"].ToString();
                        ddl_division.Enabled = false;
                        ddl_branch.Enabled = true;
                        ddl_product.Enabled = true;
                       // GetModuleName();
                    }

                    else
                    {

                        ddl_division.Text = Session["LoginDivisionName"].ToString();
                        ddl_branch.Text = Session["LoginBranchName"].ToString();
                        ddl_branch.SelectedValue = Session["StrTranType"].ToString();
                        ddl_division.Enabled = false;

                        ddl_branch.Enabled = false;

                        ddl_product.Enabled = false;
                        GetModuleName();
                    }
                    emptygrdbind();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        public void emptygrdbind()
        {
            DataTable dt = new DataTable();
            if(dt.Rows.Count>0)
            {
                grdbudget.DataSource = dt;
                grdbudget.DataBind();
            }
            else
            {
                grdbudget.DataSource = new DataTable();
                grdbudget.DataBind();
            }
        }
        public void DivisionBind()
        {
            dtTable = objHrEmp.GetDivision();
            for (i = 0; i <= dtTable.Rows.Count - 1; i++)
            {
                ddl_division.Items.Add(dtTable.Rows[i]["divisionname"].ToString());
            }

            ddl_division.Enabled = false;
        }

        public void BranchBind()
        {
            dtTable = objMasterPort.GetAllBranchNameforPortName();

            for (i = 0; i <= dtTable.Rows.Count - 1; i++)
            {
                ddl_branch.Items.Add(dtTable.Rows[i]["portname"].ToString());
            }
            ddl_branch.Enabled = false;
        }

        public void Getmodule()
        {
            if (ddl_product.SelectedValue == "Ocean Exports")
            {
                ModuleName ="FE";
            }
            else if (ddl_product.SelectedValue == "Ocean Imports")
            {
                ModuleName ="FI";
            }

            else if (ddl_product.SelectedValue == "Air Exports")
            {
                ModuleName ="AE";
            }

            else if (ddl_product.SelectedValue == "Air Imports")
            {
                ModuleName ="AI";
            }

            else if (ddl_product.SelectedValue == "Custom House Agent")
            {
                ModuleName ="CH";
            }
            else if (ddl_product.SelectedValue == "Bonded Trucking")
            {
                ModuleName ="BT";
            }
          
            
        }

        public void GetModuleName()
        {


            if (ModuleName == "FE")
            {
                ddl_product.SelectedValue = "Ocean Exports";
            }

            else if (ModuleName == "FI")
            {
                ddl_product.SelectedValue = "Ocean Imports";
            }

            else if (ModuleName == "AE")
            {
                ddl_product.SelectedValue = "Air Exports";
            }

            else if (ModuleName == "AI")
            {
                ddl_product.SelectedValue = "Air Imports";
            }


            else if (ModuleName == "CH")
            {
                ddl_product.SelectedValue = "Custom House Agent";
            }

            else if (ModuleName == "BT")
            {
                ddl_product.SelectedValue = "Bonded Trucking";
            }

        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_branch.Text!="" && ddl_division.Text!="")
            {
                intbranchid = objHrEmp.GetBranchId(objHrEmp.GetDivisionId(ddl_division.Text), ddl_branch.Text);

                ddl_product.SelectedIndex = -1;            

                txt_job.Text = "";

                Fillgrid();
            }
        }


        public void Fillgrid()
        {
            Getmodule();
            intbranchid = objHrEmp.GetBranchId(objHrEmp.GetDivisionId(ddl_division.Text), ddl_branch.Text);
            if(ddl_branch.Text!=""&&ddl_division.Text!=""&&ddl_product.Text!=""&&txt_job.Text!="")
            {
                
                int jobno=Convert.ToInt32((txt_job.Text).ToString());

                dt = objDocuments.GetDocDtls(intbranchid, ModuleName, jobno);
                if (Session["StrTranType"].ToString()=="FE")
                {
                    logDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 621, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text) + "&View");
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    logDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 625, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text) + "&View");
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    logDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 622, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text) + "&View");
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    logDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 623, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text) + "&View");
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    logDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 624, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text) + "&View");
                }
                else 
                {
                    logDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 522, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text) + "&View");
                }
             
                grdbudget.DataSource = dt;

                grdbudget.DataBind();
                Session["dt"] = dt;
                    
            }

            else
            {
                dt = objDocuments.GetDocDtls(intbranchid, "", 0);
                if(dt.Rows.Count > 0)
                {
                    grdbudget.DataSource = dt;
                    grdbudget.DataBind();
                }else
                {
                    grdbudget.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdbudget.DataBind();
                }
                Session["dt"] = dt;
                
            }
        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getmodule();

            txt_job.Text = "";

            Fillgrid();
        }

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            if (txt_job.Text != "")
           {
               Getmodule();
               Fillgrid();
           }

        }

        protected void lnk_job_Click(object sender, EventArgs e)
        {


            Getmodule();
            intbranchid = objHrEmp.GetBranchId(objHrEmp.GetDivisionId(ddl_division.Text), ddl_branch.Text);
            if(ModuleName=="FE")
            {intbranchid = objHrEmp.GetBranchId(objHrEmp.GetDivisionId(ddl_division.Text), ddl_branch.Text);
                dtTable = objDocuments.GetJobDtls4CODoc(intbranchid,ModuleName);

                if(dtTable.Rows.Count ==0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DownloadDoc", "alertify.alert('Job Not Available');", true);

                    return;
                }
                dtTable = objDocuments.GetJobDtls4CODoc(intbranchid, ModuleName);

                grdview.DataSource = dtTable;

                grdview.DataBind();
            }

            else if (ModuleName == "FI")
            {

                dtTable = objDocuments.GetJobDtls4CODoc(intbranchid, ModuleName);

                if (dtTable.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DownloadDoc", "alertify.alert('Job Not Available');", true);

                    return;
                }
                dtTable = objDocuments.GetJobDtls4CODoc(intbranchid, ModuleName);

                grdjobno.DataSource = dtTable;

                grdjobno.DataBind();
            }
            else if (ModuleName == "AE" || ModuleName == "AI")
            {
                dtTable = objDocuments.GetJobDtls4CODoc(intbranchid, ModuleName);

                if (dtTable.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DownloadDoc", "alertify.alert('Job Not Available');", true);

                    return;
                }
                dtTable = objDocuments.GetJobDtls4CODoc(intbranchid, ModuleName);

                GrdAEI.DataSource = dtTable;

                GrdAEI.DataBind();
            }

            else if(ModuleName == "CH")
            {
                dtTable = objDocuments.GetJobDtls4CODoc(intbranchid, ModuleName);

                if (dtTable.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DownloadDoc", "alertify.alert('Job Not Available');", true);

                    return;

                    
                }
                dtTable = objDocuments.GetJobDtls4CODoc(intbranchid, ModuleName);

                grdCH.DataSource = dtTable;

                grdCH.DataBind();
            }

        }

        protected void grdbudget_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbudget, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdbudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grdbudget.SelectedRow.RowIndex;

                if(grdbudget.Rows.Count > 0)
                {

                    DataTable dt = new DataTable();
                    if (txt_job.Text != "")
                    {

                        docid = Convert.ToInt32(grdbudget.Rows[index].Cells[2].Text);

                        Remarks = grdbudget.Rows[index].Cells[1].Text;

                        dcmtid = Convert.ToInt32(grdbudget.Rows[index].Cells[3].Text);

                      //  filenameloc = grdbudget.Rows[index].Cells[4].Text;

                        hid_poddownload.Value = grdbudget.Rows[index].Cells[4].Text;

                      


                        //int jobno = Convert.ToInt32((txt_job.Text).ToString());

                        //dt = Dobj.GetDocDtls(Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(txtjob.Text));
                       

                        //LinkButton btn_Temp = (LinkButton)sender;
                        //string str_Arg = btn_Temp.CommandArgument;
                        //string[] str_arry = str_Arg.Split('-');
                        //string str_Type = str_arry[0].ToString().Trim();
                        //string str_FileId = str_arry[1].ToString().Trim();
                        //if (str_FileId != "")
                        //{
                        if (hid_poddownload.Value != "")
                        {
                            //hid_poddownload.Value = str_FileId;
                            //string[] arrfilelength = str_FileId.Split(',');

                            //if (arrfilelength.Length > 2)
                            //{
                            //  //  ftp_download();
                            //}
                            //else
                            //{
                            // //   fttnormaldwd();
                            //}
                            fttnormaldwd();

                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Warehouse", "alertify.alert('Kindly update the podproof')", true);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), " ", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                            return;
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "EDI", "alertify.alert('Please Enter the Booking #');", true);
                        txt_job.Focus();
                    }

                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('http://192.168.0.218/" + filenameloc + "','_top');", true);
                }
                
            }catch (Exception ex)
            {

            }
        }

        protected void grdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdview, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdview_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grdview.SelectedRow.RowIndex;

            if(grdview.Rows.Count > 0)
            {
                txt_job.Text = grdview.Rows[index].Cells[0].Text;

                grdview.Visible = false;

                Fillgrid();
            }

            grdview.Visible = false;
        }

        protected void grdjobno_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdjobno, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdjobno_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grdjobno.SelectedRow.RowIndex;

            if (grdjobno.Rows.Count > 0)
            {
                txt_job.Text = grdjobno.Rows[index].Cells[0].Text;

                grdjobno.Visible = false;

                Fillgrid();
            }

            grdjobno.Visible = false;
        }

        protected void grdCH_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCH, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdCH_SelectedIndexChanged(object sender, EventArgs e)
        {
             int index = grdCH.SelectedRow.RowIndex;

            if (grdCH.Rows.Count > 0)
            {
                txt_job.Text = grdCH.Rows[index].Cells[0].Text;

                grdCH.Visible = false;

                Fillgrid();
            }

            grdCH.Visible = false;
        }

        protected void GrdAEI_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdAEI, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdAEI_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GrdAEI.SelectedRow.RowIndex;

            if (GrdAEI.Rows.Count > 0)
            {
                txt_job.Text = GrdAEI.Rows[index].Cells[0].Text;

                GrdAEI.Visible = false;

                Fillgrid();
            }

            GrdAEI.Visible = false;
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
            string ftpFolder = "/SL/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
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



        protected void ftpdeleted( string filename)
        {

            try
            {

                
              /*  String ftpurl = "ftp://20.235.30.214/alpl/"; // e.g. ftp://serverip/foldername/foldername
                String ftpusername = "ifrtAdmin"; // e.g. username
                String ftppassword = "05Jun!(&%"; // e.g. password



                string filename1 = Path.GetFileName(filename);

                string ftpfullpath = ftpurl + filename1;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);
                ftp.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
               
                response.Close();*/

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214//SL/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");

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
        
        protected void grdbudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                 DataTable dt_checkamend = new DataTable();
                 if (Session["LoginEmpId"] != null)
                 {


                     dt_checkamend = user_check.Get_downdocdeleterightsrights(Convert.ToInt32(Session["LoginEmpId"]), "");
                     if (dt_checkamend.Rows.Count > 0)
                     {

                         if (e.CommandName == "Delete")
                         {
                             ImageButton Img_delete = (ImageButton)e.CommandSource;
                             GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                             DataTable obj_dt = new DataTable();
                             string filename = "";

                             obj_dt = (DataTable)Session["dt"];
                             DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                             objDocuments.Getdeleteftpdile(Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text));


                             ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);
                             obj_dt.Rows[grd.RowIndex].Delete();
                             obj_dt.AcceptChanges();
                             filename = grdbudget.Rows[grd.RowIndex].Cells[4].Text;
                             Fillgrid();
                             ftpdeleted(filename);


                         }
                     }
                     else
                     {
                         ScriptManager.RegisterStartupScript(this, typeof(ImageButton), "JobInfo", "alertify.alert('No rights for Delete options');", true);
                     }
                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, typeof(ImageButton), "JobInfo", "alertify.alert('No rights for Delete options');", true);
                 }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdbudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdbudget_PreRender(object sender, EventArgs e)
        {
            if (grdbudget.Rows.Count > 0)
            {
                grdbudget.UseAccessibleHeader = true;
                grdbudget.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
       



    }
}