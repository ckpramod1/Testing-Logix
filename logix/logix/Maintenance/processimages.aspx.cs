using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace logix.Maintenance
{
    public partial class processimages : System.Web.UI.Page
    {
        byte[] postfile1 = null;
        DataAccess.HR.Employee empobj = new DataAccess.HR.Employee();
        int processid;
        protected void Page_Load(object sender, EventArgs e)
        {
             if(!IsPostBack)
             {
                 ddl_processname();
             }
        }
        //[WebMethod]
        //public static List<string> getempname(string prefix)
        //{
        //    List<string> List_Result = new List<string>();
        //    DataTable obj_dt = new DataTable();
        //   // DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
        //    DataAccess.UserPermission obj_ser = new DataAccess.UserPermission();

        //    obj_dt = obj_ser.getsp_masterprocessname(prefix.ToUpper());
           
        //    if (obj_dt.Rows.Count > 0)
        //    {
        //        //string alert = ws.webMethod();
        //        //System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alertify.alert(" + alert + ")</SCRIPT>");

        //    }
        //    List_Result = Utility.Fn_DatatableToList(obj_dt, "ProcessName", "Processid");
        //    return List_Result;
        //}

        protected void btn_save_Click(object sender, EventArgs e)
        {
            DataAccess.UserPermission obj_user = new DataAccess.UserPermission();
            DataTable dt = new DataTable();
            DataRow dr;
            if (img_upload.HasFile && img_upload.PostedFile != null)
            {
                string Str_FileExt = System.IO.Path.GetExtension(img_upload.FileName).ToUpper();
                int filesize = img_upload.PostedFile.ContentLength / 1024;
                if (filesize < 50 && filesize != 0)
                {
                    if (Str_FileExt == ".JPEG" || Str_FileExt == ".JPG" || Str_FileExt == ".GIF" || Str_FileExt == ".PNG" || Str_FileExt == ".BMP" || Str_FileExt == ".PNG")
                    {
                        dt.Clear();
                        postfile1 = pstFile(img_upload);
                        dr = dt.NewRow();
                        dt.Columns.Add("image", Type.GetType("System.Byte[]"));
                        dr["image"] = postfile1;
                        dt.Rows.Add(dr);
                        Session["dt"] = dt;
                        string base64String = Convert.ToBase64String(postfile1);
                        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image Size Does not Exist 50kb');", true);
                    //img_upload.Attributes.Clear();
                    return;
                }
                byte[] Img_Length = new byte[0];
                DataTable obj_dt = new DataTable();
                if (Session["dt"] != null)
                {
                    obj_dt = (DataTable)Session["dt"];
                    if (obj_dt.Rows.Count > 0)
                    {
                        Img_Length = ((byte[])obj_dt.Rows[0][0]);
                    }
                }
                if (ddl_processname1.SelectedItem.Text != "")
                {
                    processid = empobj.sp_likemasterprocessname(ddl_processname1.SelectedItem.Text);
                }
                obj_user.GETSPInsMASTERPROCESS(processid, ddl_processname1.SelectedItem.Text, Img_Length);
            }

        }

        public byte[] pstFile(FileUpload passfile)
        {
            Stream fs = default(Stream);
            byte[] bytes1 = null;
            byte[] postfile = null;
            fs = passfile.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(fs);
            bytes1 = br1.ReadBytes(passfile.PostedFile.ContentLength);
            postfile = bytes1;
            return postfile;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
          //  txt_processname.Text = "";
            ddl_processname1.SelectedIndex = 0;
            Img_Emp.ImageUrl = "~/images/UT.jpg";
        }

        protected void ddl_processname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ddl_processname()
        {
            DataTable obj_dt;
            DataAccess.Masters.MasterEmployee obj_emp = new DataAccess.Masters.MasterEmployee();
            obj_dt = obj_emp.GetSp_Likeprocessname();
            ddl_processname1.DataSource = obj_dt;
            ddl_processname1.DataTextField = "ProcessName";
            ddl_processname1.DataValueField = "Processid";
            ddl_processname1.DataBind();
        }

        protected void ddl_processname_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if(ddl_processname1.SelectedItem.Text!="")
            {
                 processid = empobj.sp_likemasterprocessname(ddl_processname1.SelectedItem.Text);
            }
        }
    }
}