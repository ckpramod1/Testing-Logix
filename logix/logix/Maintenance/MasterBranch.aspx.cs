using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace logix.Maintenance
{
    public partial class MasterBranch : System.Web.UI.Page
    {
        DataAccess.Masters.MasterBranch obj_main = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterEmployee obj_emp = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterRegion obj_region = new DataAccess.Masters.MasterRegion();
        DataAccess.Masters.MasterPort obj_port = new DataAccess.Masters.MasterPort();
        DataAccess.HR.Employee obj_HRemp = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
        DataAccess.Masters.MasterDivision obj_division = new DataAccess.Masters.MasterDivision();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataTable dt_comm = new DataTable();
        int filesize;

        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnSave);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                try
                {
                    txt_city.Enabled = false;
                    //Ctrl_List = branch_droptype.ID + "~" + txt_location.ID + "~" + txt_personto.ID + "~" + txt_shortname.ID + "~" + txt_address.ID + "~" + txt_phone.ID + "~" + txt_fax.ID + "~" + txt_email.ID + "~" + txt_city.ID + "~" + txt_PanNo.ID + "~" + txt_service.ID + "~" + txt_carr.ID + "~" + txt_cinno.ID + "~" + txt_BrMngr.ID + "~" + txt_EDIUser.ID + "~" + droptype_region.ID + "~" + txt_regionMgr.ID + "~" + txt_Mrcode.ID + "~" + txt_transbond.ID + "~" + txt_baseCurr.ID + "~" + txt_seperator.ID + "~" + txt_acc_mailid.ID + "~" + txt_exdoc_mailid.ID + "~" + txt_impdoc_mailid.ID + "~" + txt_excoord_mailid.ID + "~" + txt_impcoord_mailid.ID + "~" + txt_exope_mailid.ID + "~" + txt_impoper_mailid.ID + "~" + txt_favrg_first.ID + "~" + txt_acc_first.ID + "~" + txt_Bank_OSDN.ID + "~" + txt_bankaddr_OSDN.ID + "~" + txt_SwiftCode.ID + "~" + txt_favrg_second.ID + "~" + txt_Acc_second.ID + "~" + txt_Bank_LocalDN.ID + "~" + txt_BankAddr_LocalDN.ID + "~" + txt_NEFTcode.ID;
                    //Msg_List = "Compamy Name~Location Name~Person Name~Short Name~Address Name~Phone Number~Fax Number~Email ID~City~Pan No~St no~Carr No~CIN NO~BranchManager Name~UserEdi~Region Name~RegionManager~MRcode~trans Bond~Base Currenry~Seperator~AccountEmail ID~ExoprtDOC MailID~ImportDOC MailID~ExportCOR MailID~ImportCOR MailID~ExportOPER MailID~ImportOPER MailID~Favouring OSDN~Account OSDN~BankName OSDN~BankAddress OSDN~SwiftCode~Favouring Local~Account Local~BankName Local~BankAddress Local~NEFT";
                    //Dtype_List = "string~string";
                    //btnSave.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                    //branch_droptype.Text = "--SELECT--";
                    txt_phone.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                    txt_fax.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                    CompanyDropFill();
                    RegionFill();
                    //branch_droptype.Focus();
                    txt_location.Focus();
                   // btnCancel.Text = "Cancel";

                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        [WebMethod]
        public static List<string> GetLocation(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterPort objp_location = new DataAccess.Masters.MasterPort();
            DataTable dt_Location = new DataTable();
            dt_Location = objp_location.GetLikePort(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList(dt_Location, "portname", "portid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetPTC(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_branchmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_Bgr = new DataTable();
            dt_Bgr = obj_branchmgr.GetLikeEmployee(prefix.Trim().ToUpper());
            List_Result = Utility.Fn_DatatableToList(dt_Bgr, "empnamecode", "employeeid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetBranchManager(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_branchmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_Bgr = new DataTable();
            dt_Bgr = obj_branchmgr.GetLikeEmployee(prefix.Trim().ToUpper());
            List_Result = Utility.Fn_DatatableToList(dt_Bgr, "empname", "employeeid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetRegionalManager(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_Regionalmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_RMgr = new DataTable();
            dt_RMgr = obj_Regionalmgr.GetLikeEmployee(prefix.Trim().ToUpper());
            List_Result = Utility.Fn_DatatableToList(dt_RMgr, "empnamecode", "employeeid");
            return List_Result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.ToolTip == "Save")
                {
                    if (FileUpd_logo.HasFile && FileUpd_logo.PostedFile != null)
                    {
                        hdf_RegionId.Value = obj_region.GetRegionid(Convert.ToString(droptype_region.SelectedItem.ToString().Trim().ToUpper())).ToString();
                        hdf_portid.Value = Convert.ToString(obj_port.GetNPortid(txt_city.Text.ToUpper()));
                        int locationid = Convert.ToInt32(hdf_Locationid.Value.ToString());
                        int divisionid = Convert.ToInt32(hdf_divisionid.Value.ToString());
                        int portid = Convert.ToInt32(hdf_portid.Value.ToString());
                        int regionid = Convert.ToInt32(hdf_RegionId.Value.ToString());
                        int RMId = Convert.ToInt32(hdn_rmid.Value.ToString());
                        int BMId = Convert.ToInt32(hdn_bmid.Value.ToString());

                        Byte[] imgbyte = null;
                        if (FileUpd_logo.PostedFile != null)
                        {
                            HttpPostedFile File = FileUpd_logo.PostedFile;
                            imgbyte = new Byte[File.ContentLength];
                            File.InputStream.Read(imgbyte, 0, File.ContentLength);
                            filesize = FileUpd_logo.PostedFile.ContentLength / 1024;

                            string base64String = Convert.ToBase64String(imgbyte);
                            hdn_Flag.Value = base64String;
                            ImgLogo.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        if (filesize > 20)
                        {
                            ScriptManager.RegisterStartupScript(ImgLogo, typeof(Button), "DataFound", "alertify.alert('Image size should not Exceed 20kb');", true);
                            FileUpd_logo.Attributes.Clear();
                            return;
                        }
                        obj_main.InsertAllValuesBranch(divisionid, portid, txt_Branch.Text.ToUpper().Trim(), txt_personto.Text.ToUpper().Trim(), txt_address.Text.ToUpper().Trim(), txt_phone.Text.Trim().ToUpper(), txt_fax.Text.Trim().ToUpper(), txt_email.Text.ToUpper().Trim(), txt_PanNo.Text.ToUpper().Trim(), txt_service.Text.ToUpper().Trim(), txt_favrg_first.Text.ToUpper().Trim(), txt_Bank_OSDN.Text.ToUpper().Trim(), txt_bankaddr_OSDN.Text.ToUpper().Trim(), txt_SwiftCode.Text.ToUpper().Trim(), txt_acc_first.Text.Trim(), regionid, txt_carr.Text.ToUpper().Trim(), imgbyte, BMId, RMId, txt_Acc_second.Text.Trim(), txt_Mrcode.Text.ToUpper().Trim(), txt_EDIUser.Text.ToUpper().Trim(), txt_baseCurr.Text.ToUpper().Trim(), txt_transbond.Text.ToUpper().Trim(), txt_seperator.Text.ToUpper().Trim(), txt_cinno.Text.ToUpper().Trim(), txt_NEFTcode.Text.ToUpper().Trim(), txt_favrg_second.Text.ToUpper().Trim(), txt_Bank_LocalDN.Text.ToUpper().Trim(), txt_BankAddr_LocalDN.Text.ToUpper().Trim(), txt_shortname.Text.ToUpper().Trim(), txt_acc_mailid.Text.ToUpper().Trim(), txt_exdoc_mailid.Text.ToUpper().Trim(), txt_impdoc_mailid.Text.ToUpper().Trim(), txt_excoord_mailid.Text.ToUpper().Trim(), txt_impcoord_mailid.Text.ToUpper().Trim(), txt_exope_mailid.Text.ToUpper().Trim(), txt_impoper_mailid.Text.ToUpper().Trim(), locationid);
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Branch Details Inserted successfully');", true);
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 329, 1, int.Parse(Session["LoginBranchid"].ToString()), "save"); 
                        clear();
                    //    btnSave.Text = "Update";


                        btnSave.ToolTip = "Update";
                        btnSave1.Attributes["class"] = "btn btn-update1";
                    }
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Choose Image File');", true);
                }

                else
                {
                    string flageEx = hdn_Flag.Value.ToString();
                    hdf_branchid.Value = obj_main.GetBranchId(Convert.ToInt32(hdf_divisionid.Value), Convert.ToInt32(hdf_portid.Value), txt_Branch.Text).ToString();
                    if (hdf_branchid.Value != "0")
                    {
                        hdf_RegionId.Value = obj_region.GetRegionid(Convert.ToString(droptype_region.SelectedItem.ToString().Trim().ToUpper())).ToString();
                        hdf_portid.Value = obj_port.GetNPortid(txt_city.Text.ToUpper().Trim()).ToString();
                        int locationid = Convert.ToInt32(hdf_Locationid.Value.ToString());
                        int divisionid = Convert.ToInt32(hdf_divisionid.Value.ToString());
                        int portid = Convert.ToInt32(hdf_portid.Value.ToString());
                        int regionid = Convert.ToInt32(hdf_RegionId.Value.ToString());
                        int RMId = Convert.ToInt32(hdn_rmid.Value.ToString());
                        int BMId = Convert.ToInt32(hdn_bmid.Value.ToString());
                        int branchid = Convert.ToInt32(hdf_branchid.Value.ToString());

                        Byte[] imgbyte = null;
                        if (FileUpd_logo.PostedFile != null)
                        {
                            HttpPostedFile File = FileUpd_logo.PostedFile;
                            imgbyte = new Byte[File.ContentLength];
                            File.InputStream.Read(imgbyte, 0, File.ContentLength);
                            filesize = FileUpd_logo.PostedFile.ContentLength / 1024;

                            string base64String = Convert.ToBase64String(imgbyte);
                            hdn_Flag.Value = base64String;
                            ImgLogo.ImageUrl = "data:image/png;base64," + base64String;
                        }

                        if (filesize > 20)
                        {
                            ScriptManager.RegisterStartupScript(ImgLogo, typeof(Button), "DataFound", "alertify.alert('Image Size Does not Exist 20kb');", true);
                            FileUpd_logo.Attributes.Clear();
                            return;
                        }
                        if (FileUpd_logo.FileName == string.Empty)
                        {
                            Byte[] imgbyte1 = Convert.FromBase64String(flageEx);
                            obj_main.UpdateValOfMasterBranch(branchid, divisionid, portid, txt_Branch.Text.ToUpper().Trim(), txt_personto.Text.ToUpper().Trim(), txt_address.Text.ToUpper().Trim(), txt_phone.Text.Trim(), txt_fax.Text.Trim(), txt_email.Text.ToUpper().Trim(), txt_PanNo.Text.ToUpper().Trim(), txt_service.Text.ToUpper().Trim(), txt_favrg_first.Text.ToUpper().Trim(), txt_Bank_OSDN.Text.ToUpper().Trim(), txt_bankaddr_OSDN.Text.ToUpper().Trim(), txt_SwiftCode.Text.ToUpper().Trim(), txt_acc_first.Text.Trim().ToUpper(), regionid, txt_carr.Text.ToUpper().Trim(), imgbyte1, BMId, RMId, txt_Acc_second.Text.Trim().ToUpper(), txt_Mrcode.Text.ToUpper().Trim(), txt_EDIUser.Text.ToUpper().Trim(), txt_baseCurr.Text.ToUpper().Trim(), txt_transbond.Text.ToUpper().Trim(), txt_seperator.Text.ToUpper().Trim(), txt_cinno.Text.ToUpper().Trim(), txt_NEFTcode.Text.ToUpper().Trim(), txt_favrg_second.Text.ToUpper().Trim(), txt_Bank_LocalDN.Text.ToUpper().Trim(), txt_BankAddr_LocalDN.Text.ToUpper().Trim(), txt_shortname.Text.ToUpper().Trim(), txt_acc_mailid.Text.ToUpper().Trim(), txt_exdoc_mailid.Text.ToUpper().Trim(), txt_impdoc_mailid.Text.ToUpper().Trim(), txt_excoord_mailid.Text.ToUpper().Trim(), txt_impcoord_mailid.Text.ToUpper().Trim(), txt_exope_mailid.Text.ToUpper().Trim(), txt_impoper_mailid.Text.ToUpper().Trim(), locationid);
                            
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Branch Details Updated successfully');", true);
                        }
                        else
                        {
                            obj_main.UpdateValOfMasterBranch(branchid, divisionid, portid, txt_Branch.Text.ToUpper().Trim(), txt_personto.Text.ToUpper().Trim(), txt_address.Text.ToUpper().Trim(), txt_phone.Text.Trim(), txt_fax.Text.Trim(), txt_email.Text.ToUpper().Trim(), txt_PanNo.Text.ToUpper().Trim(), txt_service.Text.ToUpper().Trim(), txt_favrg_first.Text.ToUpper().Trim(), txt_Bank_OSDN.Text.ToUpper().Trim(), txt_bankaddr_OSDN.Text.ToUpper().Trim(), txt_SwiftCode.Text.ToUpper().Trim(), txt_acc_first.Text.Trim().ToUpper(), regionid, txt_carr.Text.ToUpper().Trim(), imgbyte, BMId, RMId, txt_Acc_second.Text.Trim().ToUpper(), txt_Mrcode.Text.ToUpper().Trim(), txt_EDIUser.Text.ToUpper().Trim(), txt_baseCurr.Text.ToUpper().Trim(), txt_transbond.Text.ToUpper().Trim(), txt_seperator.Text.ToUpper().Trim(), txt_cinno.Text.ToUpper().Trim(), txt_NEFTcode.Text.ToUpper().Trim(), txt_favrg_second.Text.ToUpper().Trim(), txt_Bank_LocalDN.Text.ToUpper().Trim(), txt_BankAddr_LocalDN.Text.ToUpper().Trim(), txt_shortname.Text.ToUpper().Trim(), txt_acc_mailid.Text.ToUpper().Trim(), txt_exdoc_mailid.Text.ToUpper().Trim(), txt_impdoc_mailid.Text.ToUpper().Trim(), txt_excoord_mailid.Text.ToUpper().Trim(), txt_impcoord_mailid.Text.ToUpper().Trim(), txt_exope_mailid.Text.ToUpper().Trim(), txt_impoper_mailid.Text.ToUpper().Trim(), locationid);
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 329,2, int.Parse(Session["LoginBranchid"].ToString()), "update");
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Branch Details Updated successfully');", true);
                        }
                        clear();
                        //btnSave.Text = "Save";


                        btnSave.ToolTip = "Save";
                        btnSave1.Attributes["class"] = "btn ico-save";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void CheckFileExtn()
        {
            string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "tif", "img","wmf"};
            string ext = System.IO.Path.GetExtension(FileUpd_logo.PostedFile.FileName);
            bool isValidFile = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Invalid File. Please Upload a Image File Only');", true);
                hdn_Flag.Value = "";
                ImgLogo.ImageUrl = "";
                //Label1.ForeColor = System.Drawing.Color.Red;
                //Label1.Text = "Invalid File. Please upload a File with extension " +
                //               string.Join(",", validFileTypes);
            }
            else
            {
              //  btnCancel.Text = "Cancel";

                btnCancel.ToolTip = "Cancel";
                btnCancel1.Attributes["class"] = "btn ico-cancel";
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                clear();               
               // droptype_region.Items.Clear();
                CompanyDropFill();
                RegionFill();
                //btnSave.Text = "Save";

            //    btnCancel.Text = "Back";


                btnSave.ToolTip = "Save";
                btnSave1.Attributes["class"] = "btn ico-save";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {               
                this.Response.End();
            }
        }


        protected void branch_droptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdf_divisionid.Value = "";
            if (branch_droptype.SelectedIndex == 0)
            {
                txt_Branch.Text = "";
            }
            else
            {
                txt_Branch.Text = branch_droptype.SelectedValue.ToString().Trim();
            }
            //txt_city.Focus();

            if (hdf_divisionid.Value == "")
            {                
                string CompanyName = branch_droptype.SelectedValue.ToString().Trim();
                hdf_divisionid.Value = obj_HRemp.GetDivisionId(CompanyName).ToString();              
            }
            if (hdf_divisionid.Value != "")
            {

                int CompId = Convert.ToInt32(hdf_divisionid.Value.ToString());
                dt_comm = obj_division.GetMasterDivisionDetails(CompId);
                if (dt_comm.Rows.Count > 0)
                {
                    txt_PanNo.Text = "";
                    txt_service.Text = "";
                    txt_PanNo.Text = dt_comm.Rows[0]["panno"].ToString();
                    txt_service.Text = dt_comm.Rows[0]["stno"].ToString();
                  //  btnCancel.Text = "Cancel";
                   // btnSave.Text = "Update";

                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn btn-update1";

                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                }
            }
            txt_location.Focus();
        }

        private void CompanyDropFill()
        {
         //  branch_droptype.Items.Add("--SELECT COMPANY--");
           //dt_comm = obj_main.GetDivCommon();

           //for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
           //{
           //    branch_droptype.Items.Add(dt_comm.Rows[i][0].ToString());
           //}
            if (branch_droptype.Text == "Company")
            {
                branch_droptype.SelectedIndex = 0;
            }
            else
            {
                DataTable obj_dtTemp = new DataTable();
                obj_dtTemp = obj_HRemp.GetDivision("M");
             
                branch_droptype.Items.Clear();
                branch_droptype.Items.Add("");
                for (int i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
                {
                    branch_droptype.Items.Add(obj_dtTemp.Rows[i]["divisionname"].ToString());
                }
                //ddlbranch.DataSource = obj_dtTemp;
                //ddlbranch.DataBind();
            }
           
        }
        private void RegionFill()
        {
            //droptype_region.Items.Clear();
           // droptype_region.Items.Add("--SELECT REGION");
            dt_comm = obj_region.getAllRegionNames();

            for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
            {
                droptype_region.Items.Add(dt_comm.Rows[i][0].ToString());
            }

            txt_location.Focus();
        }

        private void clear()
        {
            txt_acc_first.Text = "";
            txt_Acc_second.Text = "";
            txt_acc_mailid.Text = "";
            txt_address.Text = "";

            txt_Bank_LocalDN.Text = "";
            txt_Bank_OSDN.Text = "";

            txt_baseCurr.Text = "";
            txt_Branch.Text = "";
            txt_BrMngr.Text = "";
            txt_carr.Text = "";
            txt_cinno.Text = "";
            txt_city.Text = "";
            txt_EDIUser.Text = "";
            txt_email.Text = "";

            txt_BankAddr_LocalDN.Text = "";
            txt_bankaddr_OSDN.Text = "";
            txt_excoord_mailid.Text = "";
            txt_exdoc_mailid.Text = "";
            txt_exope_mailid.Text = "";

            txt_fax.Text = "";
            txt_favrg_first.Text = "";
            txt_favrg_second.Text = "";
            txt_location.Text = "";
            txt_Mrcode.Text = "";
            txt_NEFTcode.Text = "";
            txt_PanNo.Text = "";
            txt_personto.Text = "";
            txt_phone.Text = "";
            txt_regionMgr.Text = "";
            txt_impcoord_mailid.Text = "";
            txt_impdoc_mailid.Text = "";
            txt_impoper_mailid.Text = "";

            txt_seperator.Text = "";
            txt_service.Text = "";
            txt_shortname.Text = "";
            txt_SwiftCode.Text = "";
            txt_transbond.Text = "";
            ImgLogo.ImageUrl = "";
            droptype_region.SelectedIndex = 0;
            branch_droptype.SelectedIndex = 0;
            hdn_rmid.Value = "";
            hdf_portid.Value = "";
            hdf_RegionId.Value = "";
            hdf_Locationid.Value = "";
            hdf_branchid.Value = "";
            hdf_divisionid.Value = "";
            hdn_PTC.Value = "";
            hdn_Flag.Value = "";
            hdn_bmid.Value = "";

        }
        private void clear1()
        {
            txt_acc_first.Text = "";
            txt_Acc_second.Text = "";
            txt_acc_mailid.Text = "";
            txt_address.Text = "";

            txt_Bank_LocalDN.Text = "";
            txt_Bank_OSDN.Text = "";

            txt_baseCurr.Text = "";
           // txt_Branch.Text = "";
            txt_BrMngr.Text = "";
            txt_carr.Text = "";
            txt_cinno.Text = "";
           // txt_city.Text = "";
            txt_EDIUser.Text = "";
            txt_email.Text = "";

            txt_BankAddr_LocalDN.Text = "";
            txt_bankaddr_OSDN.Text = "";
            txt_excoord_mailid.Text = "";
            txt_exdoc_mailid.Text = "";
            txt_exope_mailid.Text = "";

            txt_fax.Text = "";
            txt_favrg_first.Text = "";
            txt_favrg_second.Text = "";
            //txt_location.Text = "";
            txt_Mrcode.Text = "";
            txt_NEFTcode.Text = "";
            //txt_PanNo.Text = "";
            txt_personto.Text = "";
            txt_phone.Text = "";
            txt_regionMgr.Text = "";
            txt_impcoord_mailid.Text = "";
            txt_impdoc_mailid.Text = "";
            txt_impoper_mailid.Text = "";

            txt_seperator.Text = "";
           // txt_service.Text = "";
            txt_shortname.Text = "";
            txt_SwiftCode.Text = "";
            txt_transbond.Text = "";
            ImgLogo.ImageUrl = "";
           // droptype_region.SelectedIndex = 0;
           // branch_droptype.SelectedIndex = 0;
         //   hdn_rmid.Value = "";
         //   hdf_portid.Value = "";
         //   hdf_RegionId.Value = "";
         //   hdf_Locationid.Value = "";
         //   hdf_branchid.Value = "";
         //   hdf_divisionid.Value = "";
         //   hdn_PTC.Value = "";
         ////   hdn_Flag.Value = "";
         //   hdn_bmid.Value = "";

        }        
        
        protected void droptype_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdf_RegionId.Value = obj_region.GetRegionid(droptype_region.SelectedItem.ToString().Trim().ToUpper()).ToString();
        }

        protected void txt_Branch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int locationid = Convert.ToInt32(hdf_Locationid.Value.ToString());
                hdf_portid.Value = obj_port.GetNPortid(txt_city.Text.ToUpper().Trim()).ToString();
                hdf_branchid.Value = obj_main.GetBranchId(Convert.ToInt32(hdf_divisionid.Value), Convert.ToInt32(hdf_portid.Value), txt_Branch.Text.ToUpper()).ToString();
                DataTable dt_View = new DataTable();

                if (txt_location.Text != "")
                {
                    if (branch_droptype.SelectedValue == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Choose Company Name');", true);
                    }
                    else if (branch_droptype.SelectedValue != "" && hdf_divisionid.Value != "")
                    {
                        dt_View = obj_main.RetrieveMasterBranchDetails4New(Convert.ToInt32(hdf_divisionid.Value), Convert.ToInt32(hdf_portid.Value), Convert.ToInt32(hdf_branchid.Value));
                    }
                }

                if (dt_View.Rows.Count > 0)
                {
                    hdf_branchid.Value = dt_View.Rows[0]["branchid"].ToString();
                }

                if (hdf_branchid.Value != "0" && hdf_divisionid.Value != "" && hdf_portid.Value != "" && hdf_Locationid.Value != "")
                {
                    dt_comm = obj_main.GetSelofAllMasterBranchDetails(Convert.ToInt32(hdf_divisionid.Value), Convert.ToInt32(hdf_portid.Value), Convert.ToInt32(hdf_branchid.Value), locationid);
                    if (dt_comm.Rows.Count > 0)
                    {
                        txt_Branch.Text = dt_comm.Rows[0]["branchname"].ToString();
                        txt_personto.Text = dt_comm.Rows[0]["ptc"].ToString();
                        txt_shortname.Text = dt_comm.Rows[0]["shortname"].ToString();
                        txt_address.Text = dt_comm.Rows[0]["address"].ToString();
                        txt_phone.Text = dt_comm.Rows[0]["phone"].ToString();
                        txt_fax.Text = dt_comm.Rows[0]["fax"].ToString();
                        txt_email.Text = dt_comm.Rows[0]["email"].ToString();
                        txt_PanNo.Text = dt_comm.Rows[0]["panno"].ToString();
                        txt_service.Text = dt_comm.Rows[0]["stno"].ToString();
                        txt_favrg_first.Text = dt_comm.Rows[0]["favouring"].ToString();
                        txt_Bank_OSDN.Text = dt_comm.Rows[0]["bankname"].ToString();
                        txt_bankaddr_OSDN.Text = dt_comm.Rows[0]["bankaddress"].ToString();
                        txt_SwiftCode.Text = dt_comm.Rows[0]["swiftcode"].ToString();
                        txt_acc_first.Text = dt_comm.Rows[0]["acnos"].ToString();

                        txt_favrg_second.Text = dt_comm.Rows[0]["Locfavouring"].ToString();
                        txt_Bank_LocalDN.Text = dt_comm.Rows[0]["Locbankname"].ToString();
                        txt_BankAddr_LocalDN.Text = dt_comm.Rows[0]["Locbankaddress"].ToString();
                        txt_NEFTcode.Text = dt_comm.Rows[0]["neftcode"].ToString();
                        txt_Acc_second.Text = dt_comm.Rows[0]["localacno"].ToString();

                        txt_cinno.Text = dt_comm.Rows[0]["cinno"].ToString();
                        txt_EDIUser.Text = dt_comm.Rows[0]["ediuserid"].ToString();
                        txt_Mrcode.Text = dt_comm.Rows[0]["mrcode"].ToString();
                        txt_transbond.Text = dt_comm.Rows[0]["transbondno"].ToString();

                        txt_baseCurr.Text = dt_comm.Rows[0]["basecurr"].ToString();
                        txt_seperator.Text = dt_comm.Rows[0]["basepaise"].ToString();
                        txt_acc_mailid.Text = dt_comm.Rows[0]["accemail"].ToString();

                        txt_exdoc_mailid.Text = dt_comm.Rows[0]["doxexpemail"].ToString();
                        txt_impdoc_mailid.Text = dt_comm.Rows[0]["doximpemail"].ToString();
                        txt_excoord_mailid.Text = dt_comm.Rows[0]["codexpemail"].ToString();
                        txt_impcoord_mailid.Text = dt_comm.Rows[0]["codimpemail"].ToString();
                        txt_exope_mailid.Text = dt_comm.Rows[0]["opsexpemail"].ToString();
                        txt_impoper_mailid.Text = dt_comm.Rows[0]["opsimpemail"].ToString();

                        //hdn_bmid.Value = dt_comm.Rows[0]["bm"].ToString();

                        if (DBNull.Value.Equals(dt_comm.Rows[0]["bm"]))
                        {
                        }
                        else
                        {
                            txt_BrMngr.Text = obj_emp.GetEmpNameNew(Convert.ToInt32(dt_comm.Rows[0]["bm"].ToString()));
                            hdn_bmid.Value = dt_comm.Rows[0]["bm"].ToString();

                        }

                        if (DBNull.Value.Equals(dt_comm.Rows[0]["rm"]))
                        {
                        }
                        else
                        {
                            txt_regionMgr.Text = obj_emp.GetEmpNameNew(Convert.ToInt32(dt_comm.Rows[0]["rm"].ToString()));
                            hdn_rmid.Value = dt_comm.Rows[0]["rm"].ToString();
                        }

                        if (dt_comm.Rows[0]["carrno"].ToString() == "<NULL>")
                        {
                            txt_carr.Text = "";
                        }
                        else
                        {
                            txt_carr.Text = dt_comm.Rows[0]["carrno"].ToString();
                        }

                        string strRegion = obj_region.GetRegionname(Convert.ToInt32(dt_comm.Rows[0]["regionid"].ToString()));
                        droptype_region.SelectedValue = strRegion;

                        byte[] imageByte = ((byte[])dt_comm.Rows[0]["clogo"]);
                        string base64String = Convert.ToBase64String(imageByte);
                        hdn_Flag.Value = base64String;
                        ImgLogo.ImageUrl = "data:image/png;base64," + base64String;

                    }
                    //btnSave.Text = "Update";
                   // btnCancel.Text = "Cancel";

                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn btn-update1";

                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    //  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('');", true);
                    //txt_location.Text = "";

                    clear1();
                    ///btnSave.Text = "Save";

                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void txt_location_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dt_loc = obj_port.GetNPortid(txt_location.Text.ToUpper());
                txt_city.Text = txt_location.Text;
                if (dt_loc == Convert.ToInt32(hdf_Locationid.Value))
                {                    
                    txt_Branch_TextChanged(sender, e);
                    //btnCancel.Text = "Cancel";
                                       

                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Valid Location');", true);
                    clear1();
                   // btnSave.Text = "Save";


                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_personto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_empcheck = new DataTable();
                if (hdn_PTC.Value != "")
                {
                    int ptcid = Convert.ToInt32(hdn_PTC.Value.ToString());
                    dt_empcheck = obj_main.CheckEmpNameNew(ptcid);
                    if (dt_empcheck.Rows.Count > 0)
                    {
                       // btnCancel.Text = "Cancel";
                       

                        btnCancel.ToolTip = "Cancel";
                        btnCancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Valid Employee Name');", true);
                    txt_personto.Text = "";

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_regionMgr_TextChanged(object sender, EventArgs e)
        {
            DataTable dt_empchecknew = new DataTable();
            if (
                hdn_rmid.Value != "")
            {
                int New_rmid = Convert.ToInt32(hdn_rmid.Value.ToString());
                dt_empchecknew = obj_main.CheckEmpNameNew(New_rmid);
                if (dt_empchecknew.Rows.Count > 0)
                {
                  //  btnCancel.Text = "Cancel";
                   
                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Valid Employee Name');", true);
                txt_regionMgr.Text = "";

            }
        }

        protected void txt_BrMngr_TextChanged(object sender, EventArgs e)
        {
            int customerid = 0;
            if (txt_BrMngr.Text != "")
            {
                customerid = obj_emp.GetNEmpid(txt_BrMngr.Text);
                if (customerid == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Valid Employee Name');", true);
                    txt_BrMngr.Focus();
                }
            }
        }

        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }
        protected void txt_email_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txt_email.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txt_email.Text = "";
                txt_email.Focus();
            }

        }

        protected void txt_acc_mailid_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txt_acc_mailid.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txt_acc_mailid.Text = "";
                txt_acc_mailid.Focus();
            }
        }

        protected void txt_exdoc_mailid_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txt_exdoc_mailid.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txt_exdoc_mailid.Text = "";
                txt_exdoc_mailid.Focus();
            }
        }

        protected void txt_excoord_mailid_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txt_excoord_mailid.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txt_excoord_mailid.Text = "";
                txt_excoord_mailid.Focus();
            }
        }

        protected void txt_exope_mailid_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txt_exope_mailid.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txt_exope_mailid.Text = "";
                txt_exope_mailid.Focus();
            }
        }

        protected void txt_impdoc_mailid_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txt_impdoc_mailid.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txt_impdoc_mailid.Text = "";
                txt_impdoc_mailid.Focus();
            }
        }

        protected void txt_impcoord_mailid_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txt_impcoord_mailid.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txt_impcoord_mailid.Text = "";
                txt_impcoord_mailid.Focus();
            }
        }

        protected void txt_impoper_mailid_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txt_impoper_mailid.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txt_impoper_mailid.Text = "";
                txt_impoper_mailid.Focus();
            }
        }

        protected void logdetails_Click(object sender, EventArgs e)
        {
            try
            {
                loadgridlog();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 329, "MSbranch", branch_droptype.SelectedValue.ToString().Trim(), branch_droptype.SelectedValue.ToString().Trim(), "");  //"/Rate ID: " +
            if (branch_droptype.SelectedValue.ToString().Trim() != "")
            {
                JobInput.Text = branch_droptype.SelectedValue.ToString().Trim();
             }
            else
            {
                JobInput.Text = "";
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }


    }
}