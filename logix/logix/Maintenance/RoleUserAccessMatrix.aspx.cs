using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
namespace logix.Maintenance
{
    public partial class RoleUserAccessMatrix : System.Web.UI.Page
    {
        DataAccess.UserPermission userobj = new DataAccess.UserPermission();
        DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.HR.FrontPage da_obj_HRFrontObj = new DataAccess.HR.FrontPage();
        DataAccess.HR.Employee hrobj = new DataAccess.HR.Employee();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.Masters.MasterEmployee obj_emp = new DataAccess.Masters.MasterEmployee();
        DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
        DataTable dt = new DataTable();
        DataTable dts = new DataTable();
        int branchid;
        int int_btnaccess;
        int int_btnsave;
        int int_btndelete;
        int int_btnupdate;
        int int_btnview;
        string str_employeecode, str_modulename;
        CheckBox chk1;
        CheckBox chk2;
        CheckBox chk3;
        CheckBox chk4;
        CheckBox chk5;
        string str_Uiid;
        string trantype = "";
        byte[] postfile1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            //byte[] str = hrobj.sp_touchlogoimage(Convert.ToInt32(Session["LoginDivisionId"]));

            //if (!string.IsNullOrEmpty(str[0].ToString()))
            //{
            //    grd_images.DataSource = (byte[])(str);
            //    grd_images.DataBind();
            //}

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                userobj.GetDataBase(Ccode);
                da_obj_userobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                da_obj_HRFrontObj.GetDataBase(Ccode);
                hrobj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                obj_emp.GetDataBase(Ccode);
                da_obj_hrempobj.GetDataBase(Ccode);




            }



            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (!IsPostBack)
            {
                // OI_CS.ServerClick += new EventHandler(OI_CS_Click);
                //OE_CS.ServerClick += new EventHandler(OE_CS_Click);

                dt = hrobj.sp_touchlogoimage(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dt.Rows.Count > 0)
                {
                    ddl_branch.Items.Add("");
                    ddl_branch.DataSource = dt;
                    ddl_branch.DataTextField = "branchname";
                    ddl_branch.DataValueField = "branchid";
                    ddl_branch.DataBind();
                    //grd_images.DataSource = dt;
                    //grd_images.DataBind();


                }

                corporate.Visible = false;
                homeid.Visible = false;
                Panel1.Visible = false;
                btn_back.Visible = false;btn_back1.Visible = false;
                btn_save.Visible = false;btn_save_id.Visible = false;
                btn_view.Visible = true;btn_view_id.Visible = true;
                div_grds.Visible = false;
                lbl_branchname.Text = "";
                hid_processid.Value = "";
                if (Session["StrTranType"].ToString() != "CO")
                {
                    Label1.Text = "OperatingAccounts";
                    lbl_header.Text = "Utility";
                    lbl_Header1.Text = "Access Rights";
                }
                else
                {
                    Label1.Text = "Home";
                    lbl_header.Text = "Maintenance";
                    lbl_Header1.Text = "Access Rights";
                }
            }
        }
        [WebMethod]
        public static List<string> GetEmployeename(string prefix)
        {
            List<string> gname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee da_obj_HRFrontObj = new DataAccess.HR.Employee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_HRFrontObj.GetDataBase(Ccode);
            obj_dt = da_obj_HRFrontObj.GetLikeroleName(prefix.ToUpper());
            gname = Utility.Fn_DatatableToList_int16(obj_dt, "rolename", "roleid");
            // Utility.Fn_TableToList_Cust(obj_dt, "empnamecode", "employeeid", "portname", "designame");
            //Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");


            return gname;
        }
        public string GetImage(object img)
        {
            //if()
            if (img.ToString().Length == 0)
            {
                return "";
            }
            else
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }

        }

        public void userrights()
        {
            DataTable dt_MenuRights = new DataTable();
            //DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
            dt_MenuRights = obj_UP.Getmodule(Convert.ToInt16(Session["LoginEmpId"].ToString()), Convert.ToInt16(Session["LoginBranchid"].ToString()));
        }

        protected void grd_images_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
            if (txt_user.Text != "")
            {


                if (grd_images.Rows.Count > 0)
                {
                    //  int index = grd_images.SelectedRow.RowIndex;
                    Process.Visible = true;
                    lbl_branchname.Visible = true;
                    branchid = Convert.ToInt32(grd_images.SelectedDataKey.Values[0]);
                    hf_branchid.Value = grd_images.SelectedDataKey.Values[0].ToString();
                    dts = userobj.sp_getportnamecor(Convert.ToInt32(grd_images.SelectedDataKey.Values[0]));
                    if (dts.Rows.Count > 0)
                    {
                        lbl_branchname.Text = dts.Rows[0]["portname"].ToString() + "-" + "ProcessUI";
                    }
                }


                dt = hrobj.sp_getbranchname(branchid);
                if (dt.Rows[0]["portname"].ToString() == "CORPORATE")
                {
                    branch.Attributes["class"] = "UserBoxC2";
                    branchUserBoxC3.Attributes["class"] = "UserBoxC3";
                    div_grds.Visible = false;
                    corporate.Visible = true;
                    homeid.Visible = false;
                    Panel1.Visible = false;
                    btn_save.Visible = false;btn_save_id.Visible = false;
                    btn_view.Visible = false;btn_view_id.Visible = false;
                    btn_back.Visible = false;btn_back1.Visible = false;
                    lbl_processname.Visible = false;
                }
                else
                {
                    branch.Attributes["class"] = "UserBox2";
                    branchUserBoxC3.Attributes["class"] = "UserBox3";
                    corporate.Visible = false;
                    homeid.Visible = false;
                    Panel1.Visible = false;
                    btn_save.Visible = false;btn_save_id.Visible = false;
                    btn_view.Visible = false;btn_view_id.Visible = false;
                    btn_back.Visible = false;btn_back1.Visible = false;
                    lbl_processname.Visible = true;
                    div_grds.Visible = true;
                    grid_homeimage();
                }


                /* dt = hrobj.sp_getbranchname(branchid);
                 if (dt.Rows.Count > 0)
                 {
                     for (int i = 0; i <= dt.Rows.Count - 1; i++)
                     {
                         if (dt.Rows[i]["portname"].ToString() == "CORPORATE")
                         {
                             branch.Attributes["class"] = "UserBoxC2";
                             branchUserBoxC3.Attributes["class"] = "UserBoxC3";
                             div_grds.Visible = false;
                             corporate.Visible = true;
                             homeid.Visible = false;
                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = false;
                             //btn_back.Visible = true;btn_back1.Visible = true;
                             //btn_save.Visible = true;btn_save_id.Visible = true;
                             //btn_view.Visible = true;btn_view_id.Visible = true;
                         }
                         //else 
                         //{
                         //    corporate.Visible = false;
                         //    homeid.Visible = true;

                         //}
                         if (dt.Rows[i]["portname"].ToString() == "CHENNAI")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;
                             homeid.Visible = false;
                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "MUMBAI")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "TUTICORIN")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "NEW DELHI")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "BANGALORE")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "CALCUTTA")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "COCHIN")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "COIMBATORE")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "HYDERABAD")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();

                         }

                         if (dt.Rows[i]["portname"].ToString() == "TIRUPUR")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "AHMEDABAD")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }

                         if (dt.Rows[i]["portname"].ToString() == "VISHAKHAPATNAM")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }
                         if (dt.Rows[i]["portname"].ToString() == "WAREHOUSE")
                         {
                             branch.Attributes["class"] = "UserBox2";
                             branchUserBoxC3.Attributes["class"] = "UserBox3";
                             corporate.Visible = false;

                             Panel1.Visible = false;
                             btn_save.Visible = false;btn_save_id.Visible = false;
                             btn_view.Visible = false;btn_view_id.Visible = false;
                             btn_back.Visible = false;btn_back1.Visible = false;
                             lbl_processname.Visible = true;
                             homeid.Visible = false;
                             div_grds.Visible = true;
                             grid_homeimage();
                         }


                     }
                 }

                 */
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;

            }
        }


        public void grid_homeimage()
        {
            //DataAccess.Masters.MasterEmployee obj_emp = new DataAccess.Masters.MasterEmployee();
            DataTable dtnew;
            if(ddl_branch.SelectedValue !="0")
            {
                //  int index = grd_images.SelectedRow.RowIndex;
                Process.Visible = true;
                lbl_branchname.Visible = true;
                branchid = Convert.ToInt32(ddl_branch.SelectedValue);

                dts = userobj.sp_getportnamecor(Convert.ToInt32(ddl_branch.SelectedValue));
                if (dts.Rows.Count > 0)
                {
                    lbl_branchname.Text = dts.Rows[0]["portname"].ToString() + "-" + "ProcessUI";
                }
            }

            dt = hrobj.sp_getbranchname(branchid);

            if (dt.Rows.Count > 0)
            {
                dtnew = obj_emp.GetSp_LikeprocessnameROLES();
                if (dtnew.Rows.Count > 0)
                {
                    ddl_process.Items.Clear();
                    ddl_process.Items.Add("");
                    ddl_process.DataSource = dtnew;
                    ddl_process.DataTextField = "process";
                    ddl_process.DataValueField = "processid";
                    ddl_process.DataBind();
                    //Grid_homeimage.DataSource = dtnew;
                    //Grid_homeimage.DataBind();
                    //Grid_homeimage.Visible = true;
                    //panel_servic.Visible = true;
                }


                /* for (int i = 0; i <= dt.Rows.Count - 1; i++)
                 {
                   

                     /*if (dt.Rows[i]["portname"].ToString() == "CHENNAI")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "MUMBAI")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "TUTICORIN")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "NEW DELHI")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "BANGALORE")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "CALCUTTA")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "COCHIN")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "COIMBATORE")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "HYDERABAD")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "TIRUPUR")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "AHMEDABAD")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }

                     if (dt.Rows[i]["portname"].ToString() == "WAREHOUSE")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }
                     if (dt.Rows[i]["portname"].ToString() == "VISHAKHAPATNAM")
                     {

                         dtnew = obj_emp.GetSp_Likeprocessname();
                         if (dtnew.Rows.Count > 0)
                         {
                             Grid_homeimage.DataSource = dtnew;
                             Grid_homeimage.DataBind();
                             Grid_homeimage.Visible = true;
                             panel_servic.Visible = true;
                         }
                     }

                    


                 }*/
            }

        }

        protected void grd_images_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    if (e.Row.Cells[i].Text.Contains("&amp;"))
                    {
                        e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_images, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void link_sales_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                userrightsales();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "2";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FE");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            // lbl_processname.Text = dt.Rows[i]["menuname"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }
                        grd_user.Visible = true;
                        Gridbranch.Visible = false;

                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                        Div1.Visible = false;
                        Div2.Visible = false;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString() && grd_user.Rows[i].Cells[2].Text == dt1.Rows[j]["modulename"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "1")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "1")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "1")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "1")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "1")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }

            }
        }




        public void userrightsales()
        {

            txt_user.Visible = true;
            Panel1.Visible = true;

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "2";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FE");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        // lbl_processname.Text = dt.Rows[i]["menuname"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;

                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                    Div1.Visible = false;
                    Div2.Visible = false;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString() && Gridbranch.Rows[i].Cells[2].Text == dt1.Rows[j]["modulename"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "True")
                                    {
                                        chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "True")
                                    {
                                        chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }

                    }


                }
                else
                {

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }


        protected void link_crm_Click(object sender, EventArgs e)
        {



            if (Session["StrTranType"].ToString() == "AC")
            {
                linkcrm();

            }
            else
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                txt_user.Visible = true;
                if (txt_user.Text != "")
                {
                    hid_processid.Value = "";
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "1";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "CRM");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        Panel1.Visible = true;
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }
                        grd_user.Visible = true;
                        Gridbranch.Visible = false;

                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                        Div1.Visible = false;
                        Div2.Visible = false;
                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }
        }



        public void linkcrm()
        {


            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            txt_user.Visible = true;
            if (txt_user.Text != "")
            {
                hid_processid.Value = "";
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "1";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.SP_USERRIGHTSCRM(Convert.ToInt32(hid_processid.Value), "CRM");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    Panel1.Visible = true;
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                    Div1.Visible = false;
                    Div2.Visible = false;
                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }

        public void OE_CS_Click(object sender, EventArgs e)
        {
            demo.Visible = true;
            demo1.Visible = false;
        }
        public void OI_CS_Click(object sender, EventArgs e)
        {

            Session["home"] = "OPS&DOC";
            demo.Visible = false;
            demo1.Visible = true;

        }

        protected void link_customersupport_Click(object sender, EventArgs e)
        {
            Div1.Visible = true;
            Div2.Visible = false;
        }

        protected void link_cusOE_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                link_CUSOE();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                if (txt_user.Text != "")
                {
                    hid_processid.Value = "";
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "3";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FE");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "1")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "1")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "1")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "1")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "1")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }

            }

        }


        public void link_CUSOE()
        {


            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (txt_user.Text != "")
            {
                hid_processid.Value = "";
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "3";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FE");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (Gridbranch.Rows.Count > 0)
                {
                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }



        }


        protected void link_cusOI_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                link_CUSOI();
            }
            else
            {

                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "4";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FI");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }
                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "1")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "1")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "1")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "1")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "1")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }

        }



        public void link_CUSOI()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "4";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }
                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }

        protected void link_cusAI_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                link_CUSAI();
            }
            else
            {

                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "6";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AI");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "1")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "1")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "1")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "1")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "1")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }
        }


        public void link_CUSAI()
        {

            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "6";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }

        protected void link_OpsDocks_Click(object sender, EventArgs e)
        {
            Div1.Visible = false;
            Div2.Visible = true;
        }

        protected void link_OpsDockOE_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                linkOpsDockOE();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "7";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FE");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;

                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {

                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }

        }


        public void linkOpsDockOE()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "7";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FE");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;

                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (Gridbranch.Rows.Count > 0)
                {

                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //    if (dt1.Rows[j][4].ToString() == "True")
                                    //    {
                                    //        chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //        chk4.Checked = true;
                                    //    }
                                    //    else
                                    //    {
                                    //        chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //        chk4.Checked = false;
                                    //    }

                                    //    if (dt1.Rows[j][5].ToString() == "True")
                                    //    {
                                    //        chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //        chk5.Checked = true;
                                    //    }
                                    //    else
                                    //    {
                                    //        chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //        chk5.Checked = false;
                                    //    }
                                    //}
                                }

                            }
                        }

                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }
        protected void link_OpsDockAE_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                linkOpsDockAE();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "9";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AE");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;

                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }

        }

        public void linkOpsDockAE()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "9";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AE");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;

                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }


        protected void link_OpsDockAI_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                link_OpsDocAI();
            }
            else
            {


                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "10";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AI");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;

                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }
        }

        public void link_OpsDocAI()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "10";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;

                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }

        protected void link_OpsDockOI_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                linkOpsDockOI();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "8";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }

                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FI");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;

                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }

        }

        public void linkOpsDockOI()
        {

            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "8";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }

                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "FI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }


        }


        protected void link_BoundedTrucking_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                link_boundedtrucking();
            }
            else
            {

                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "12";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "BT");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                        Div1.Visible = false;
                        Div2.Visible = false;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }
        }

        public void link_boundedtrucking()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "12";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "BT");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                    Div1.Visible = false;
                    Div2.Visible = false;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }

        protected void link_CHA_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                linkCHA();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "11";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "CH");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                        Div1.Visible = false;
                        Div2.Visible = false;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }
        }


        public void linkCHA()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "11";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "CH");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                    Div1.Visible = false;
                    Div2.Visible = false;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }

        protected void link_mis_Click(object sender, EventArgs e)
        {

            if (Session["StrTranType"].ToString() == "AC")
            {
                linkmis();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "18";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = userobj.sp_userrightsmis(Convert.ToInt32(hid_processid.Value));
                    if (dt.Rows.Count > 0)
                    {


                        DataTable obj_dtEmp = new DataTable();
                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                        Div1.Visible = false;
                        Div2.Visible = false;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString() && grd_user.Rows[i].Cells[2].Text == dt1.Rows[j]["modulename"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "1")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "1")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "1")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "1")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "1")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }

        }

        public void linkmis()
        {


            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "18";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = userobj.sp_userrightsmis(Convert.ToInt32(hid_processid.Value));
                if (dt.Rows.Count > 0)
                {


                    DataTable obj_dtEmp = new DataTable();
                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                    Div1.Visible = false;
                    Div2.Visible = false;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString() && Gridbranch.Rows[i].Cells[2].Text == dt1.Rows[j]["modulename"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }


        protected void link_OperatingAccount_Click(object sender, EventArgs e)
        {

            if (Session["StrTranType"].ToString() == "AC")
            {
                link_operAC();

            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "20";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AC");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;

                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                        Div1.Visible = false;
                        Div2.Visible = false;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }

        }


        public void link_operAC()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "20";
                }
                if (Gridbranch.Rows.Count > 0)
                {
                    loadcheckbranch();
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AC");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;

                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                    Div1.Visible = false;
                    Div2.Visible = false;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }
        protected void link_AccountFinance_Click(object sender, EventArgs e)
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "19";
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "MI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }

                    grd_user.Visible = true;
                    Gridbranch.Visible = false;
                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();

                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;


                }
                if (grd_user.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "True")
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "True")
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }

        protected void link_credit_Click(object sender, EventArgs e)
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (txt_user.Text != "")
            {
                hid_processid.Value = "";
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "19";
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "MI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }

                    grd_user.Visible = true;
                    Gridbranch.Visible = false;
                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (grd_user.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "True")
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "True")
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }

        protected void link_Budget_Click(object sender, EventArgs e)
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "19";
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "MI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }

                    grd_user.Visible = true;
                    Gridbranch.Visible = false;
                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (grd_user.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "True")
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "True")
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }



        protected void link_misanalysis_Click(object sender, EventArgs e)
        {
            if (Session["RightsTranType"] != "MI")
            {
                linkmisanalysis();
            }
            else
            {

                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "19";
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "MI");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }


                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "1")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "1")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "1")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "1")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "1")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }
            }
        }


        public void linkmisanalysis()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "19";
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "MI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }
                    grd_user.Visible = true;
                    Gridbranch.Visible = false;

                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (grd_user.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }


        protected void link_CRMCOR_Click(object sender, EventArgs e)
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (txt_user.Text != "")
            {
                hid_processid.Value = "";
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "19";
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "MI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }


                    grd_user.Visible = true;
                    Gridbranch.Visible = false;
                    grd_user.Visible = true;
                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (grd_user.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "True")
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "True")
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }

        protected void link_maintenance_Click(object sender, EventArgs e)
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (txt_user.Text != "")
            {
                hid_processid.Value = "";
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "19";
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "MN");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }

                    grd_user.Visible = true;
                    Gridbranch.Visible = false;
                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (grd_user.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "1")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "1")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "1")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "1")
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "1")
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }

        protected void link_HRM_Click(object sender, EventArgs e)
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (txt_user.Text != "")
            {
                hid_processid.Value = "";
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "14";

                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "HR");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }

                    grd_user.Visible = true;
                    Gridbranch.Visible = false;
                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (grd_user.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "True")
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "True")
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }

        protected void txt_user_TextChanged(object sender, EventArgs e)
        {
            dt = da_obj_HRFrontObj.SPGetRoledes(txt_user.Text);
            if (dt.Rows.Count > 0)
            {
                txt_details.Text = dt.Rows[0]["RoleDescription"].ToString();
                btnadd.ToolTip = "Update";
                btnadd.Attributes["class"] = "btn ico-update";
                btnadd.Text = "Update";
            }
            else
            {
                txt_details.Focus();
                txt_details.Text = "";
                btnadd.ToolTip = "Add";
                btnadd.Attributes["class"] = "btn ico-add";
                btnadd.Text = "Add";
            }

        }

        protected void link_Utility_Click(object sender, EventArgs e)
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (txt_user.Text != "")
            {
                hid_processid.Value = "";
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "19";

                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "MI");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }
                    grd_user.Visible = true;
                    Gridbranch.Visible = false;

                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;

                }
                if (grd_user.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "True")
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "True")
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }
        }

        protected void grd_user_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    if (e.Row.Cells[i].Text.Contains("&amp;"))
                    {
                        e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

            }

        }

        protected void grd_user_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chk_access = (CheckBox)e.Row.Cells[1].FindControl("chk_access1");
                CheckBox chk_accessAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_accessAll1");
                chk_access.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_accessAll.ClientID);
                CheckBox chk_save = (CheckBox)e.Row.Cells[1].FindControl("chk_save1");
                CheckBox chk_saveAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_saveAll1");
                chk_save.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_saveAll.ClientID);
                CheckBox chk_view = (CheckBox)e.Row.Cells[1].FindControl("chk_view1");
                CheckBox chk_viewAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_viewAll1");
                chk_view.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_viewAll.ClientID);
                CheckBox chk_delete = (CheckBox)e.Row.Cells[1].FindControl("chk_delete1");
                CheckBox chk_deleteAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_deleteAll1");
                chk_delete.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_deleteAll.ClientID);
                CheckBox chk_upd = (CheckBox)e.Row.Cells[1].FindControl("chk_upd1");
                CheckBox chk_updAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_updAll1");
                chk_upd.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_updAll.ClientID);
            }
        }

        private void LoadCheckList()
        {
           // DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();

            if (hf_employeeid.Value != "")
            {
                if (txt_user.Text != "All" && grd_user.Rows.Count > 0)
                {
                   // DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
                    //  str_employeecode = hf_empcode.Value;
                    //  hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_empcode.Value)).ToString();

                    //  hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                    //  hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                    CheckBox chk1;
                    CheckBox chk2;
                    CheckBox chk3;
                    CheckBox chk4;
                    CheckBox chk5;
                    for (int r = 0; r < grd_user.Rows.Count; r++)
                    {
                        chk1 = (CheckBox)(grd_user.Rows[r].FindControl("chk_access1"));
                        if (chk1.Checked == true)
                        {
                            int_btnaccess = 1;
                        }
                        else
                        {
                            int_btnaccess = 0;
                        }

                        chk2 = (CheckBox)(grd_user.Rows[r].FindControl("chk_save1"));
                        if (chk2.Checked == true)
                        {
                            int_btnsave = 1;
                        }
                        else
                        {
                            int_btnsave = 0;
                        }

                        chk3 = (CheckBox)(grd_user.Rows[r].FindControl("chk_delete1"));
                        if (chk3.Checked == true)
                        {
                            int_btndelete = 1;
                        }
                        else
                        {
                            int_btndelete = 0;
                        }

                        chk4 = (CheckBox)(grd_user.Rows[r].FindControl("chk_upd1"));
                        if (chk4.Checked == true)
                        {
                            int_btnupdate = 1;
                        }
                        else
                        {
                            int_btnupdate = 0;
                        }

                        chk5 = (CheckBox)(grd_user.Rows[r].FindControl("chk_view1"));
                        if (chk5.Checked == true)
                        {
                            int_btnview = 1;
                        }
                        else
                        {
                            int_btnview = 0;
                        }

                        //  int count=grd_user.Rows.Count;
                        //  trantype = grd_user.Rows[r].Cells[1].Text;


                        hf_uiid.Value = da_obj_userobj.sp_masteruiid(grd_user.Rows[r].Cells[2].Text, Convert.ToString(grd_user.Rows[r].Cells[0].Text), Convert.ToInt32(hid_processid.Value)).ToString();

                        da_obj_userobj.DeleteUserRightsRoles(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)));

                        da_obj_userobj.InsertUserRightsRoles(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)), grd_user.Rows[r].Cells[2].Text, Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnsave), Convert.ToInt32(int_btnview), Convert.ToInt32(int_btndelete), Convert.ToInt32(int_btnupdate));




                        /* if (lbl_processname.Text == "Sales / Sales Support")
                         {
                             DataTable dta;
                             dta = da_obj_userobj.sp_masteruiidsales(grd_user.Rows[r].Cells[0].Text.ToString());
                             if (dta.Rows.Count > 0)
                             {
                                 for (int i = 0; i <= dta.Rows.Count - 1; i++)
                                 {
                                     hf_uiid.Value = dta.Rows[i]["uiid"].ToString();
                                     hf_trantype.Value = dta.Rows[i]["modulename"].ToString();

                                     da_obj_userobj.DeleteUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])));

                                     da_obj_userobj.InsertUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])), hf_trantype.Value, Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnsave), Convert.ToInt32(int_btnview), Convert.ToInt32(int_btndelete), Convert.ToInt32(int_btnupdate));

                                 }
                             }

                         }
                         else
                         {

                             hf_uiid.Value = da_obj_userobj.sp_masteruiid(grd_user.Rows[r].Cells[2].Text, Convert.ToString(grd_user.Rows[r].Cells[0].Text)).ToString();

                             da_obj_userobj.DeleteUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])));

                             da_obj_userobj.InsertUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])), grd_user.Rows[r].Cells[2].Text, Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnsave), Convert.ToInt32(int_btnview), Convert.ToInt32(int_btndelete), Convert.ToInt32(int_btnupdate));
                         }*/

                        /*If modulename = "MN" Then
                        logObj.InsLogDetail(Login.logempid, 315, 1, Login.branchid, "MN/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "AC" Then
                        logObj.InsLogDetail(Login.logempid, 769, 1, Login.branchid, "AC/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "FE" Then
                        logObj.InsLogDetail(Login.logempid, 770, 1, Login.branchid, "FE/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "FI" Then
                        logObj.InsLogDetail(Login.logempid, 771, 1, Login.branchid, "FI/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "AE" Then
                        logObj.InsLogDetail(Login.logempid, 772, 1, Login.branchid, "AE/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "AI" Then
                        logObj.InsLogDetail(Login.logempid, 773, 1, Login.branchid, "AI/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "CH" Then
                        logObj.InsLogDetail(Login.logempid, 774, 1, Login.branchid, "CH/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "BT" Then
                        logObj.InsLogDetail(Login.logempid, 775, 1, Login.branchid, "BT/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    End If*/




                    }
                }
            }
        }

        public void loadcheckbranch()
        {
          //  DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();

            if (hf_employeeid.Value != "")
            {
                if (txt_user.Text != "All" && Gridbranch.Rows.Count > 0)
                {
                  //  DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
                    //  str_employeecode = hf_empcode.Value;
                    //  hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_empcode.Value)).ToString();

                    //  hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                    //  hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                    CheckBox chk1;
                    CheckBox chk2;
                    CheckBox chk3;
                    CheckBox chk4;
                    CheckBox chk5;
                    for (int r = 0; r < Gridbranch.Rows.Count; r++)
                    {
                        chk1 = (CheckBox)(Gridbranch.Rows[r].FindControl("chk_access"));
                        if (chk1.Checked == true)
                        {
                            int_btnaccess = 1;
                        }
                        else
                        {
                            int_btnaccess = 0;
                        }

                        chk2 = (CheckBox)(Gridbranch.Rows[r].FindControl("chk_save"));
                        if (chk2.Checked == true)
                        {
                            int_btnsave = 1;
                        }
                        else
                        {
                            int_btnsave = 0;
                        }

                        chk3 = (CheckBox)(Gridbranch.Rows[r].FindControl("chk_delete"));
                        if (chk3.Checked == true)
                        {
                            int_btndelete = 1;
                        }
                        else
                        {
                            int_btndelete = 0;
                        }

                        chk4 = (CheckBox)(Gridbranch.Rows[r].FindControl("chk_upd"));
                        if (chk4.Checked == true)
                        {
                            int_btnupdate = 1;
                        }
                        else
                        {
                            int_btnupdate = 0;
                        }

                        chk5 = (CheckBox)(Gridbranch.Rows[r].FindControl("chk_view"));
                        if (chk5.Checked == true)
                        {
                            int_btnview = 1;
                        }
                        else
                        {
                            int_btnview = 0;
                        }

                        //  int count=grd_user.Rows.Count;
                        //  trantype = grd_user.Rows[r].Cells[1].Text;
                        /* if (lbl_processname.Text == "Sales / Sales Support")
                         {
                             DataTable dta;
                             dta = da_obj_userobj.sp_masteruiidsales(Gridbranch.Rows[r].Cells[0].Text.ToString());
                             if (dta.Rows.Count > 0)
                             {
                                 for (int i = 0; i <= dta.Rows.Count - 1; i++)
                                 {
                                     hf_uiid.Value = dta.Rows[i]["uiid"].ToString();
                                     hf_trantype.Value = dta.Rows[i]["modulename"].ToString();

                                   //  da_obj_userobj.DeleteUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])));

                                  //   da_obj_userobj.InsertUserRightsNEWUI(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])), hf_trantype.Value, Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnsave), Convert.ToInt32(int_btnview));

                                     da_obj_userobj.DeleteUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])));

                                     da_obj_userobj.InsertUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])), hf_trantype.Value, Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnsave), Convert.ToInt32(int_btnview), Convert.ToInt32(int_btndelete), Convert.ToInt32(int_btnupdate));
                                
                                 }
                             }

                         }
                         else
                         {*/

                        hf_uiid.Value = da_obj_userobj.sp_masteruiid(Gridbranch.Rows[r].Cells[2].Text, Convert.ToString(Gridbranch.Rows[r].Cells[0].Text), Convert.ToInt32(hid_processid.Value)).ToString();

                        //  da_obj_userobj.DeleteUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])));

                        //  da_obj_userobj.InsertUserRightsNEWUI(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(grd_images.SelectedDataKey.Values[0])), Gridbranch.Rows[r].Cells[2].Text, Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnsave), Convert.ToInt32(int_btnview));
                        da_obj_userobj.DeleteUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)));

                        da_obj_userobj.InsertUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)), Gridbranch.Rows[r].Cells[2].Text, Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnsave), Convert.ToInt32(int_btnview), Convert.ToInt32(int_btndelete), Convert.ToInt32(int_btnupdate));

                    }

                    /*If modulename = "MN" Then
                    logObj.InsLogDetail(Login.logempid, 315, 1, Login.branchid, "MN/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                ElseIf modulename = "AC" Then
                    logObj.InsLogDetail(Login.logempid, 769, 1, Login.branchid, "AC/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                ElseIf modulename = "FE" Then
                    logObj.InsLogDetail(Login.logempid, 770, 1, Login.branchid, "FE/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                ElseIf modulename = "FI" Then
                    logObj.InsLogDetail(Login.logempid, 771, 1, Login.branchid, "FI/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                ElseIf modulename = "AE" Then
                    logObj.InsLogDetail(Login.logempid, 772, 1, Login.branchid, "AE/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                ElseIf modulename = "AI" Then
                    logObj.InsLogDetail(Login.logempid, 773, 1, Login.branchid, "AI/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                ElseIf modulename = "CH" Then
                    logObj.InsLogDetail(Login.logempid, 774, 1, Login.branchid, "CH/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                ElseIf modulename = "BT" Then
                    logObj.InsLogDetail(Login.logempid, 775, 1, Login.branchid, "BT/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                End If*/




                    // }
                }
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                btsave();
            }
            else
            {

                try
                {
                    //DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();
                    //DataAccess.Masters.MasterPort da_obj_PortObj = new DataAccess.Masters.MasterPort();
                    //DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
                    LoadCheckList();

                    if (!string.IsNullOrEmpty(Convert.ToString(hf_employeeid.Value)))
                    {
                        if (hid_processname.Value != "All" && grd_user.Rows.Count > 0)
                        {


                            if (grd_user.Rows.Count > 0)
                            {
                                //foreach (GridViewRow row in grd_user.Rows)
                                for (int r = 0; r < grd_user.Rows.Count; r++)
                                {

                                    chk1 = (CheckBox)(grd_user.Rows[r].FindControl("chk_access1"));
                                    if (chk1.Checked == true)
                                    {
                                        int_btnaccess = 1;
                                    }
                                    else
                                    {
                                        int_btnaccess = 0;
                                    }

                                    chk2 = (CheckBox)(grd_user.Rows[r].FindControl("chk_save1"));
                                    if (chk2.Checked == true)
                                    {
                                        int_btnsave = 1;
                                    }
                                    else
                                    {
                                        int_btnsave = 0;
                                    }

                                    chk3 = (CheckBox)(grd_user.Rows[r].FindControl("chk_delete1"));
                                    if (chk3.Checked == true)
                                    {
                                        int_btndelete = 1;
                                    }
                                    else
                                    {
                                        int_btndelete = 0;
                                    }

                                    chk4 = (CheckBox)(grd_user.Rows[r].FindControl("chk_upd1"));
                                    if (chk4.Checked == true)
                                    {
                                        int_btnupdate = 1;
                                    }
                                    else
                                    {
                                        int_btnupdate = 0;
                                    }

                                    chk5 = (CheckBox)(grd_user.Rows[r].FindControl("chk_view1"));
                                    if (chk5.Checked == true)
                                    {
                                        int_btnview = 1;
                                    }
                                    else
                                    {
                                        int_btnview = 0;
                                    }

                                    if (chk1.Checked == true)
                                    {


                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + "  " + lbl_branchname.Text + "/EmpName" + txt_user.Text.ToUpper() + "/" + "Menu:" + lbl_processname.Text + "/" + grd_user.Rows[r].Cells[0].Text + "Access/Save/Update/Delete/View" + int_btnaccess + " " + int_btnsave + " " + int_btnupdate + " " + int_btndelete + " " + int_btnview);



                                    }
                                }
                            }

                        }
                        else
                        {
                            hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_employeeid.Value)).ToString();

                            //if (grd_images.SelectedRow.Cells[0].Text == "All")
                            //{
                            //    hf_branchid.Value = da_obj_PortObj.GetNPortid(Convert.ToString(grd_images.SelectedRow.Cells[0].Text)).ToString();
                            //}
                            //else
                            //{
                            //    hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                            //}
                            //hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                            if (grd_user.Rows.Count > 0)
                            {
                                //foreach (GridViewRow row in grd_user.Rows)
                                for (int r = 0; r < grd_user.Rows.Count; r++)
                                {
                                    if (grd_user.Rows[r].Cells[0].Text == "True")
                                    {
                                        da_obj_userobj.InsAllUserRights(Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hid_processname.Value), Convert.ToString(hid_processname.Value), Convert.ToString(grd_user.Rows[r].Cells[0].Text));

                                        if (hid_processname.Value == "MN")
                                        {
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + grd_user.Rows[r].Cells[0].Text);
                                        }
                                        else if (hid_processname.Value == "AC")
                                        {
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + grd_user.Rows[r].Cells[0].Text);
                                        }
                                        else if (hid_processname.Value == "FE")
                                        {
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + grd_user.Rows[r].Cells[0].Text);
                                        }
                                        else if (hid_processname.Value == "FI")
                                        {
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + grd_user.Rows[r].Cells[0].Text);
                                        }
                                        else if (hid_processname.Value == "AE")
                                        {
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + grd_user.Rows[r].Cells[0].Text);
                                        }
                                        else if (hid_processname.Value == "AI")
                                        {
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + grd_user.Rows[r].Cells[0].Text);
                                        }
                                        else if (hid_processname.Value == "CH")
                                        {
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + grd_user.Rows[r].Cells[0].Text);
                                        }
                                        else if (hid_processname.Value == "BT")
                                        {
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + grd_user.Rows[r].Cells[0].Text);
                                        }

                                    }
                                }

                            }
                            else
                            {
                                da_obj_userobj.InsAllUserRights(Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hid_processname.Value), Convert.ToString(hid_processname.Value), "All");

                                if (hid_processname.Value == "MN")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                                }
                                else if (hid_processname.Value == "AC")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                                }
                                else if (hid_processname.Value == "FE")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                                }
                                else if (hid_processname.Value == "FI")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                                }
                                else if (hid_processname.Value == "AE")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                                }
                                else if (hid_processname.Value == "AI")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                                }
                                else if (hid_processname.Value == "CH")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                                }
                                else if (hid_processname.Value == "BT")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                                }

                            }
                        }
                    }
                    else
                    {
                        //if (!string.IsNullOrEmpty(hf_employeeid.Value))
                        //{
                        //    hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_employeeid.Value)).ToString();
                        //}
                        //else
                        //{
                        //    hf_employeeid.Value = "0";
                        //}
                        //if (ddl_cmbDivision.SelectedValue == "All")
                        //{
                        //    hf_branchid.Value = da_obj_PortObj.GetNPortid(Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                        //}
                        //else
                        //{
                        //    hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                        //}

                        //hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                        if (grd_user.Rows.Count > 0)
                        {
                            //foreach (GridViewRow row in grd_user.Rows)
                            for (int r = 0; r <= grd_user.Rows.Count - 1; r++)
                            {
                                if (grd_user.Rows[r].Cells[0].Text == "True")
                                {
                                    da_obj_userobj.InsAllUserRights(Convert.ToInt32(Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue))), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hid_processname.Value), Convert.ToString(hid_processname.Value), Convert.ToString(grd_user.Rows[r].Cells[0].Text)); da_obj_userobj.InsAllUserRights(Convert.ToInt32(Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue))), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hid_processname.Value), Convert.ToString(hid_processname.Value), Convert.ToString(grd_user.Rows[r].Cells[0].Text));
                                    if (hid_processname.Value == "MN")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + grd_user.Rows[0].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "AC")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + grd_user.Rows[0].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "FE")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + grd_user.Rows[0].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "FI")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + grd_user.Rows[0].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "AE")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + grd_user.Rows[0].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "AI")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + grd_user.Rows[0].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "CH")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + grd_user.Rows[0].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "BT")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + grd_user.Rows[0].Cells[0].Text);
                                    }

                                }
                            }
                        }
                        else
                        {
                            //    da_obj_userobj.InsAllUserRights(Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(ddl_cmbModule.SelectedValue), Convert.ToString(ddl_chk.SelectedValue), "All");
                            //    if (ddl_cmbModule.Text == "MN")
                            //    {
                            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            //    }
                            //    else if (ddl_cmbModule.Text == "AC")
                            //    {
                            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            //    }
                            //    else if (ddl_cmbModule.Text == "FE")
                            //    {
                            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            //    }
                            //    else if (ddl_cmbModule.Text == "FI")
                            //    {
                            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            //    }
                            //    else if (ddl_cmbModule.Text == "AE")
                            //    {
                            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            //    }
                            //    else if (ddl_cmbModule.Text == "AI")
                            //    {
                            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            //    }
                            //    else if (ddl_cmbModule.Text == "CH")
                            //    {
                            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            //    }
                            //    else if (ddl_cmbModule.Text == "BT")
                            //    {
                            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            //    }
                        }
                    }

                    //txt_user.Text = "";
                    //txt_details.Text = "";
                    //ddl_cmbModule.SelectedValue = "";
                    //ddl_chk.SelectedValue = "";
                    //ddl_chk.SelectedIndex = -1;
                    lbl_processname.Text = "";
                    Panel1.Visible = false;
                    grd_user.DataSource = new DataTable();
                    grd_user.DataBind();
                    //DivisionBind();
                    //BranchBind();
                    //LoadModule();
                    btn_back.Text = "Cancel";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
        }

        public void btsave()
        {


            try
            {
                //DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();
                //DataAccess.Masters.MasterPort da_obj_PortObj = new DataAccess.Masters.MasterPort();
                //DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
                loadcheckbranch();

                if (!string.IsNullOrEmpty(Convert.ToString(hf_employeeid.Value)))
                {
                    if (hid_processname.Value != "All" && Gridbranch.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_employeeid.Value)).ToString();

                        //if (grd_images.SelectedRow.Cells[0].Text == "All")
                        //{
                        //    hf_branchid.Value = da_obj_PortObj.GetNPortid(Convert.ToString(grd_images.SelectedRow.Cells[0].Text)).ToString();
                        //}
                        //else
                        //{
                        //    hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                        //}
                        //hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                        if (Gridbranch.Rows.Count > 0)
                        {
                            //foreach (GridViewRow row in grd_user.Rows)
                            for (int r = 0; r < Gridbranch.Rows.Count; r++)
                            {
                                if (Gridbranch.Rows[r].Cells[0].Text == "True")
                                {
                                    da_obj_userobj.InsAllUserRights(Convert.ToInt32(Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue))), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hid_processname.Value), Convert.ToString(hid_processname.Value), Convert.ToString(Gridbranch.Rows[r].Cells[0].Text));

                                    if (hid_processname.Value == "MN")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + Gridbranch.Rows[r].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "AC")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + Gridbranch.Rows[r].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "FE")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + Gridbranch.Rows[r].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "FI")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + Gridbranch.Rows[r].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "AE")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + Gridbranch.Rows[r].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "AI")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + Gridbranch.Rows[r].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "CH")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + Gridbranch.Rows[r].Cells[0].Text);
                                    }
                                    else if (hid_processname.Value == "BT")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/" + Gridbranch.Rows[r].Cells[0].Text);
                                    }

                                }
                            }

                        }
                        else
                        {
                            da_obj_userobj.InsAllUserRights(Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hid_processname.Value), Convert.ToString(hid_processname.Value), "All");

                            if (hid_processname.Value == "MN")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                            }
                            else if (hid_processname.Value == "AC")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                            }
                            else if (hid_processname.Value == "FE")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                            }
                            else if (hid_processname.Value == "FI")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                            }
                            else if (hid_processname.Value == "AE")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                            }
                            else if (hid_processname.Value == "AI")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                            }
                            else if (hid_processname.Value == "CH")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                            }
                            else if (hid_processname.Value == "BT")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + hid_processname.Value + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + hid_processname.Value + "/All");
                            }

                        }
                    }
                }
                else
                {
                    //if (!string.IsNullOrEmpty(hf_employeeid.Value))
                    //{
                    //    hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_employeeid.Value)).ToString();
                    //}
                    //else
                    //{
                    //    hf_employeeid.Value = "0";
                    //}
                    //if (ddl_cmbDivision.SelectedValue == "All")
                    //{
                    //    hf_branchid.Value = da_obj_PortObj.GetNPortid(Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                    //}
                    //else
                    //{
                    //    hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                    //}

                    //hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                    if (Gridbranch.Rows.Count > 0)
                    {
                        //foreach (GridViewRow row in grd_user.Rows)
                        for (int r = 0; r <= Gridbranch.Rows.Count - 1; r++)
                        {
                            if (Gridbranch.Rows[r].Cells[0].Text == "True")
                            {
                                da_obj_userobj.InsAllUserRights(Convert.ToInt32(Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue))), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hid_processname.Value), Convert.ToString(hid_processname.Value), Convert.ToString(grd_user.Rows[r].Cells[0].Text)); da_obj_userobj.InsAllUserRights(Convert.ToInt32(Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue))), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hid_processname.Value), Convert.ToString(hid_processname.Value), Convert.ToString(Gridbranch.Rows[r].Cells[0].Text));
                                if (hid_processname.Value == "MN")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + Gridbranch.Rows[0].Cells[0].Text);
                                }
                                else if (hid_processname.Value == "AC")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + Gridbranch.Rows[0].Cells[0].Text);
                                }
                                else if (hid_processname.Value == "FE")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + Gridbranch.Rows[0].Cells[0].Text);
                                }
                                else if (hid_processname.Value == "FI")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + Gridbranch.Rows[0].Cells[0].Text);
                                }
                                else if (hid_processname.Value == "AE")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + Gridbranch.Rows[0].Cells[0].Text);
                                }
                                else if (hid_processname.Value == "AI")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + Gridbranch.Rows[0].Cells[0].Text);
                                }
                                else if (hid_processname.Value == "CH")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + Gridbranch.Rows[0].Cells[0].Text);
                                }
                                else if (hid_processname.Value == "BT")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue)) + Convert.ToInt32(hf_employeeid.Value) + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + Convert.ToInt32(hf_employeeid.Value) + "/" + Gridbranch.Rows[0].Cells[0].Text);
                                }

                            }
                        }
                    }
                    else
                    {
                        //    da_obj_userobj.InsAllUserRights(Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(ddl_cmbModule.SelectedValue), Convert.ToString(ddl_chk.SelectedValue), "All");
                        //    if (ddl_cmbModule.Text == "MN")
                        //    {
                        //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        //    }
                        //    else if (ddl_cmbModule.Text == "AC")
                        //    {
                        //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        //    }
                        //    else if (ddl_cmbModule.Text == "FE")
                        //    {
                        //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        //    }
                        //    else if (ddl_cmbModule.Text == "FI")
                        //    {
                        //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        //    }
                        //    else if (ddl_cmbModule.Text == "AE")
                        //    {
                        //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        //    }
                        //    else if (ddl_cmbModule.Text == "AI")
                        //    {
                        //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        //    }
                        //    else if (ddl_cmbModule.Text == "CH")
                        //    {
                        //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        //    }
                        //    else if (ddl_cmbModule.Text == "BT")
                        //    {
                        //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        //    }
                    }
                }

                txt_user.Text = "";
                txt_details.Text = "";
                //ddl_cmbModule.SelectedValue = "";
                //ddl_chk.SelectedValue = "";
                //ddl_chk.SelectedIndex = -1;
                lbl_processname.Text = "";
                Panel1.Visible = false;
                Gridbranch.DataSource = new DataTable();
                Gridbranch.DataBind();
                //DivisionBind();
                //BranchBind();
                //LoadModule();
                 btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }
        protected void btn_view_Click(object sender, EventArgs e)
        {
          //  DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
            string str_RptName = "";
            string str_Script = "";
            string str_sf = "";
            string str_sp = "";

            if (!string.IsNullOrEmpty(txt_details.Text) && !string.IsNullOrEmpty(txt_user.Text))
            {
                //str_frmname = "User Rights";
                str_RptName = "userrights.rpt";
                str_sf = "{masteremployee.empid}=" + Convert.ToInt32(hf_employeeid.Value) + " and {MasterUserRights.branch}=" + Convert.ToInt32(Convert.ToInt32(ddl_branch.SelectedValue));
                str_sp = "";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            else if (!string.IsNullOrEmpty(txt_details.Text) && !string.IsNullOrEmpty(txt_user.Text))
            {
                str_RptName = "userrights.rpt";
                str_sf = "{UserRights.branch}=";
                str_sp = "";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            else
            {

                str_RptName = "UserRightsALL.rpt";
                str_sf = "";
                str_sp = "";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            //+ da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue))
            // + da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString()
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                ddl_branch.SelectedIndex = 0;
                ddl_process.SelectedIndex = 0;
                grd_user.DataSource = new DataTable();
                grd_user.DataBind();
                lbl_processname.Visible = false;
                lbl_processname.Text = "";
                Panel1.Visible = false;
                homeid.Visible = false;
                lbl_branchname.Visible = false;
                lbl_branchname.Text = "";
                corporate.Visible = false;
                Process.Visible = false;
                txt_user.Text = "";
                txt_details.Text = "";
                btn_back.Text = "Back";
                //ddl_branch.Text = "";
                //ddl_process.Items.Clear();
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void link_cusAE_Click(object sender, EventArgs e)
        {

            if (Session["StrTranType"].ToString() == "AC")
            {
                link_CUSAE();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "5";
                }
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AE");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    obj_dtEmp.Columns.Add("btndelete");
                    obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        dr["btndelete"] = "";
                        dr["btnupdate"] = "";
                    }

                    grd_user.Visible = true;
                    Gridbranch.Visible = false;
                    grd_user.DataSource = obj_dtEmp;
                    grd_user.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;

                }
                if (grd_user.Rows.Count > 0)
                {
                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "1")
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "1")
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "1")
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                        chk3.Checked = false;
                                    }

                                    if (dt1.Rows[j][4].ToString() == "1")
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = true;
                                    }
                                    else
                                    {
                                        chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                        chk4.Checked = false;
                                    }

                                    if (dt1.Rows[j][5].ToString() == "1")
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = true;
                                    }
                                    else
                                    {
                                        chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                        chk5.Checked = false;
                                    }
                                }
                            }

                        }
                    }
                }

            }
        }

        public void link_CUSAE()
        {
            txt_user.Visible = true;
            Panel1.Visible = true;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (hid_processid.Value == "")
            {
                hid_processid.Value = "5";
            }
            if (Gridbranch.Rows.Count > 0)
            {
                loadcheckbranch();
            }
            dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
            {
                lbl_processname.Text = dts.Rows[0]["processname"].ToString();
            }
            dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "AE");
            if (dt.Rows.Count > 0)
            {

                //string test;
                //test = dt.Rows[i][0].ToString();
                //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                DataTable obj_dtEmp = new DataTable();

                obj_dtEmp.Columns.Add("uicaption");
                obj_dtEmp.Columns.Add("menuname");
                obj_dtEmp.Columns.Add("modulename");
                obj_dtEmp.Columns.Add("uiaccess");
                obj_dtEmp.Columns.Add("btnsave");
                obj_dtEmp.Columns.Add("btnview");
                //obj_dtEmp.Columns.Add("btndelete");
                //obj_dtEmp.Columns.Add("btnupdate");

                DataRow dr;

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                    dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                    dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                    dr["uiaccess"] = "";
                    dr["btnsave"] = "";
                    dr["btnview"] = "";
                    //dr["btndelete"] = "";
                    //dr["btnupdate"] = "";
                }

                grd_user.Visible = false;
                Gridbranch.Visible = true;
                Gridbranch.DataSource = obj_dtEmp;
                Gridbranch.DataBind();
                btn_back.Visible = true;btn_back1.Visible = true;
                btn_save.Visible = true;btn_save_id.Visible = true;
                btn_view.Visible = true;btn_view_id.Visible = true;

            }
            if (Gridbranch.Rows.Count > 0)
            {
                dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                if (dt1.Rows.Count > 0)
                {

                    for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                        {
                            if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                            {
                                if (dt1.Rows[j][1].ToString() == "True")
                                {
                                    chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                    chk1.Checked = true;
                                }
                                else
                                {
                                    chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                    chk1.Checked = false;
                                }

                                if (dt1.Rows[j][2].ToString() == "True")
                                {
                                    chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                    chk2.Checked = true;
                                }
                                else
                                {
                                    chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                    chk2.Checked = false;
                                }

                                if (dt1.Rows[j][3].ToString() == "True")
                                {
                                    chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                    chk3.Checked = true;
                                }
                                else
                                {
                                    chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                    chk3.Checked = false;
                                }

                                //if (dt1.Rows[j][4].ToString() == "True")
                                //{
                                //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                //    chk4.Checked = true;
                                //}
                                //else
                                //{
                                //    chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete"));
                                //    chk4.Checked = false;
                                //}

                                //if (dt1.Rows[j][5].ToString() == "True")
                                //{
                                //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                //    chk5.Checked = true;
                                //}
                                //else
                                //{
                                //    chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd"));
                                //    chk5.Checked = false;
                                //}
                            }
                        }

                    }
                }

            }
        }
        protected void Gridbranch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    if (e.Row.Cells[i].Text.Contains("&amp;"))
                    {
                        e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

            }
        }

        protected void Gridbranch_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chk_access = (CheckBox)e.Row.Cells[1].FindControl("chk_access");
                CheckBox chk_accessAll = (CheckBox)this.Gridbranch.HeaderRow.FindControl("chk_accessAll");
                chk_access.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_accessAll.ClientID);
                CheckBox chk_save = (CheckBox)e.Row.Cells[1].FindControl("chk_save");
                CheckBox chk_saveAll = (CheckBox)this.Gridbranch.HeaderRow.FindControl("chk_saveAll");
                chk_save.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_saveAll.ClientID);
                CheckBox chk_view = (CheckBox)e.Row.Cells[1].FindControl("chk_view");
                CheckBox chk_viewAll = (CheckBox)this.Gridbranch.HeaderRow.FindControl("chk_viewAll");
                chk_view.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_viewAll.ClientID);
                //CheckBox chk_delete = (CheckBox)e.Row.Cells[1].FindControl("chk_delete");
                //CheckBox chk_deleteAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_deleteAll");
                //chk_delete.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_deleteAll.ClientID);
                //CheckBox chk_upd = (CheckBox)e.Row.Cells[1].FindControl("chk_upd");
                //CheckBox chk_updAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_updAll");
                //chk_upd.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_updAll.ClientID);
            }
        }



        protected void link_finan_Click(object sender, EventArgs e)
        {


            if (Session["StrTranType"].ToString() == "AC")
            {
                finanuser();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "21";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrightsnewFA(Convert.ToInt32(hid_processid.Value), "FA");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            // lbl_processname.Text = dt.Rows[i]["menuname"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }
                        grd_user.Visible = true;
                        Gridbranch.Visible = false;

                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                        Div1.Visible = false;
                        Div2.Visible = false;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString() && grd_user.Rows[i].Cells[2].Text == dt1.Rows[j]["modulename"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "1")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "1")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "1")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "1")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "1")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }

            }
        }


        public void finanuser()
        {



            txt_user.Visible = true;
            Panel1.Visible = true;

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "21";
                }
                //if (Gridbranch.Rows.Count > 0)
                //{
                //    LoadCheckList();
                //}
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrightsnewFA(Convert.ToInt32(hid_processid.Value), "FA");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        // lbl_processname.Text = dt.Rows[i]["menuname"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                    Div1.Visible = false;
                    Div2.Visible = false;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString() && Gridbranch.Rows[i].Cells[2].Text == dt1.Rows[j]["modulename"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }

        public void financoporate()
        {



            txt_user.Visible = true;
            Panel1.Visible = true;

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            hid_processid.Value = "";
            if (txt_user.Text != "")
            {
                if (hid_processid.Value == "")
                {
                    hid_processid.Value = "21";
                }
                //if (Gridbranch.Rows.Count > 0)
                //{
                //    LoadCheckList();
                //}
                dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                {
                    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                }
                dt = hrobj.sp_userrightsnewFA(Convert.ToInt32(hid_processid.Value), "FC");
                if (dt.Rows.Count > 0)
                {

                    //string test;
                    //test = dt.Rows[i][0].ToString();
                    //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                    DataTable obj_dtEmp = new DataTable();

                    obj_dtEmp.Columns.Add("uicaption");
                    obj_dtEmp.Columns.Add("menuname");
                    obj_dtEmp.Columns.Add("modulename");
                    obj_dtEmp.Columns.Add("uiaccess");
                    obj_dtEmp.Columns.Add("btnsave");
                    obj_dtEmp.Columns.Add("btnview");
                    //obj_dtEmp.Columns.Add("btndelete");
                    //obj_dtEmp.Columns.Add("btnupdate");

                    DataRow dr;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dr = obj_dtEmp.NewRow();
                        obj_dtEmp.Rows.Add(dr);
                        dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                        // lbl_processname.Text = dt.Rows[i]["menuname"].ToString();
                        dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                        dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                        dr["uiaccess"] = "";
                        dr["btnsave"] = "";
                        dr["btnview"] = "";
                        //dr["btndelete"] = "";
                        //dr["btnupdate"] = "";
                    }

                    grd_user.Visible = false;
                    Gridbranch.Visible = true;
                    Gridbranch.DataSource = obj_dtEmp;
                    Gridbranch.DataBind();
                    btn_back.Visible = true;btn_back1.Visible = true;
                    btn_save.Visible = true;btn_save_id.Visible = true;
                    btn_view.Visible = true;btn_view_id.Visible = true;
                    lbl_processname.Visible = true;
                    Panel1.Visible = true;
                    Div1.Visible = false;
                    Div2.Visible = false;

                }
                if (Gridbranch.Rows.Count > 0)
                {


                    dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= Gridbranch.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                            {
                                if (Gridbranch.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString() && Gridbranch.Rows[i].Cells[2].Text == dt1.Rows[j]["modulename"].ToString())
                                {
                                    if (dt1.Rows[j][1].ToString() == "True")
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = true;
                                    }
                                    else
                                    {
                                        chk1 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_access"));
                                        chk1.Checked = false;
                                    }

                                    if (dt1.Rows[j][2].ToString() == "True")
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = true;
                                    }
                                    else
                                    {
                                        chk2 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_save"));
                                        chk2.Checked = false;
                                    }

                                    if (dt1.Rows[j][3].ToString() == "True")
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = true;
                                    }
                                    else
                                    {
                                        chk3 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_view"));
                                        chk3.Checked = false;
                                    }

                                    //if (dt1.Rows[j][4].ToString() == "True")
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk4 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_delete"));
                                    //    chk4.Checked = false;
                                    //}

                                    //if (dt1.Rows[j][5].ToString() == "True")
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = true;
                                    //}
                                    //else
                                    //{
                                    //    chk5 = (CheckBox)(Gridbranch.Rows[i].FindControl("chk_upd"));
                                    //    chk5.Checked = false;
                                    //}
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;
            }

        }

        protected void Grid_homeimage_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
            int Processid;
            if (txt_user.Text != "")
            {
                if (Grid_homeimage.Rows.Count > 0)
                {
                    Processid = Convert.ToInt32(Grid_homeimage.SelectedDataKey.Values[0]);
                    dts = userobj.sp_getprocessname(Convert.ToInt32(Processid));
                    if (dts.Rows.Count > 0)
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    if (lbl_processname.Text == "Sales / Sales Support")
                    {
                        link_sales_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "CRM")
                    {
                        link_crm_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Customer Suport - Ocean Exports")
                    {
                        link_cusOE_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Customer Suport - Ocean Imports")
                    {
                        link_cusOI_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Customer Support - Air Exports")
                    {
                        link_cusAE_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Customer Support - Air Imports")
                    {
                        link_cusAI_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Ops & Docs - Ocean Exports")
                    {
                        link_OpsDockOE_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Ops & Docs - Ocean Imports")
                    {
                        link_OpsDockOI_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Ops & Docs - Air Exports")
                    {
                        link_OpsDockAE_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Ops & Docs - Air Imports")
                    {
                        link_OpsDockAI_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "CHA")
                    {
                        link_CHA_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "MIS & Analytics")
                    {
                        link_mis_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Bonded Trucking")
                    {
                        link_BoundedTrucking_Click(sender, e);
                    }
                    else if (lbl_processname.Text == "Operating Accounts")
                    {
                        link_OperatingAccount_Click(sender, e);
                    }

                    else if (lbl_processname.Text == "Financial Accounts")
                    {
                        link_finan_Click(sender, e);

                        //txt_user.Visible = true;
                        //Panel1.Visible = false;
                    }


                }

            }
        }

        protected void Grid_homeimage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    if (e.Row.Cells[i].Text.Contains("&amp;"))
                    {
                        e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_homeimage, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void link_financorporate_Click(object sender, EventArgs e)
        {



            if (Session["StrTranType"].ToString() == "AC")
            {
                financoporate();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                hid_processid.Value = "";
                if (txt_user.Text != "")
                {
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "21";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrightsnewFA(Convert.ToInt32(hid_processid.Value), "FC");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            // lbl_processname.Text = dt.Rows[i]["menuname"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true;btn_back1.Visible = true;
                        btn_save.Visible = true;btn_save_id.Visible = true;
                        btn_view.Visible = true;btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;
                        Div1.Visible = false;
                        Div2.Visible = false;

                    }
                    if (grd_user.Rows.Count > 0)
                    {


                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString() && grd_user.Rows[i].Cells[2].Text == dt1.Rows[j]["modulename"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "1")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "1")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "1")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "1")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "1")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }

            }


        }

        protected void txt_userto_TextChanged(object sender, EventArgs e)
        {
            dt = da_obj_HRFrontObj.GetLikeEmpName(txt_userto.Text);
            //if (dt.Rows.Count > 0)
            //{
            //    txt_details.Text = dt.Rows[0]["empnamecode"].ToString();
            //}
        }

        protected void btn_all_Click(object sender, EventArgs e)
        {

            if (txt_user.Text != "" && txt_userto.Text != "")
            {
                if (hf_employeeid.Value == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Username');", true);
                    txt_user.Text = "";

                    txt_user.Focus();
                    return;
                }
                if (hf_employeeidto.Value == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Alternative Username');", true);
                    txt_userto.Text = "";

                    txt_userto.Focus();
                    return;
                }
               // DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();
                da_obj_userobj.insuserrightsall(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_employeeidto.Value));
                // obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 315, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));


                if (hid_processname.Value == "MN")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 315, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));
                }
                else if (hid_processname.Value == "AC")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 769, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));
                }
                else if (hid_processname.Value == "FE")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 770, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));
                }
                else if (hid_processname.Value == "FI")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 771, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));
                }
                else if (hid_processname.Value == "AE")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 772, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));
                }
                else if (hid_processname.Value == "AI")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 773, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));
                }
                else if (hid_processname.Value == "CH")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 774, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));
                }
                else if (hid_processname.Value == "BT")
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpID"].ToString()), 775, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Old Emp #" + Convert.ToInt32(hf_employeeid.Value) + "Update to New Emp #" + Convert.ToInt32(hf_employeeidto.Value));
                }

                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Save All Rights ');", true);
                txt_user.Text = "";
                txt_details.Text = "";
                txt_userto.Text = "";
                hf_employeeidto.Value = "0";
                hf_employeeid.Value = "0";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Username || Enter the Alternative Username  ');", true);
                txt_user.Text = "";
                txt_userto.Text = "";
                txt_user.Focus();
                return;
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
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
           // DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();



            // obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 769, "User Rights", "", "", "");

            if (hid_processname.Value == "MN")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 315, "User Rights", "", "", "");
            }
            else if (hid_processname.Value == "AC")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 769, "User Rights", "", "", "");
            }
            else if (hid_processname.Value == "FE")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 770, "User Rights", "", "", "");
            }
            else if (hid_processname.Value == "FI")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 771, "User Rights", "", "", "");
            }
            else if (hid_processname.Value == "AE")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 772, "User Rights", "", "", "");
            }
            else if (hid_processname.Value == "AI")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 773, "User Rights", "", "", "");
            }
            else if (hid_processname.Value == "CH")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 774, "User Rights", "", "", "");
            }
            else if (hid_processname.Value == "BT")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 775, "User Rights", "", "", "");
            }

            lbl_no.InnerText = "User Rights #:";

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
           // DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
            if (txt_user.Text != "")
            {


                if (ddl_branch.SelectedValue != "0")
                {
                    //  int index = grd_images.SelectedRow.RowIndex;
                    Process.Visible = true;
                    lbl_branchname.Visible = true;
                    branchid = Convert.ToInt32(ddl_branch.SelectedValue);//Convert.ToInt32(grd_images.SelectedDataKey.Values[0]);
                    hf_branchid.Value = ddl_branch.SelectedValue;// grd_images.SelectedDataKey.Values[0].ToString();
                    dts = userobj.sp_getportnamecor(Convert.ToInt32(ddl_branch.SelectedValue));
                    if (dts.Rows.Count > 0)
                    {
                        lbl_branchname.Text = dts.Rows[0]["portname"].ToString() + "-" + "ProcessUI";
                    }
                }


                dt = hrobj.sp_getbranchname(branchid);

                if (dt.Rows[0]["portname"].ToString() == "CORPORATE")
                {
                    
                        ddl_process.Items.Clear();
                        ddl_process.Items.Add("");
                        ddl_process.Items.Add("FINANCIAL ACCOUNTS");
                        ddl_process.Items.Add("MAINTENANCE");
                        ddl_process.Items.Add("MIS & ANALYTICS");

                   
                    //branch.Attributes["class"] = "UserBoxC2";
                    //branchUserBoxC3.Attributes["class"] = "UserBoxC3";
                    div_grds.Visible = false;
                   // corporate.Visible = true;
                    homeid.Visible = false;
                    Panel1.Visible = false;
                    btn_save.Visible = false;btn_save_id.Visible = false;
                    btn_view.Visible = false;btn_view_id.Visible = false;
                    btn_back.Visible = false;btn_back1.Visible = false;
                    lbl_processname.Visible = false;
                }
                else
                {
                    branch.Attributes["class"] = "UserBox2";
                    branchUserBoxC3.Attributes["class"] = "UserBox3";
                    corporate.Visible = false;
                    homeid.Visible = false;
                    Panel1.Visible = false;
                    btn_save.Visible = false;btn_save_id.Visible = false;
                    btn_view.Visible = false;btn_view_id.Visible = false;
                    btn_back.Visible = false;btn_back1.Visible = false;
                    lbl_processname.Visible = true;
                    div_grds.Visible = true;
                    grid_homeimage();
                }
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                txt_user.Focus();
                return;

            }


        }

        protected void ddl_process_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
            int Processid;
            if (txt_user.Text != "")
            {
                if (ddl_process.SelectedValue!="0")
                {
                    //Processid = Convert.ToInt32(Grid_homeimage.SelectedDataKey.Values[0]);
                    //dts = userobj.sp_getprocessname(Convert.ToInt32(Processid));
                    //if (dts.Rows.Count > 0)
                    //{
                    //    lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    //}
                    lbl_processname.Text = ddl_process.SelectedItem.Text;
                    if (ddl_branch.SelectedItem.Text == "CORPORATE")
                    {
                        if (lbl_processname.Text == "MIS & ANALYTICS")
                        {
                            link_misanalysis_Click(sender, e);
                        }
                        else if (lbl_processname.Text == "MAINTENANCE")
                        {
                            link_maintenance_Click(sender, e);
                        }
                        else if (lbl_processname.Text == "FINANCIAL ACCOUNTS")
                        {
                            link_financorporate_Click(sender, e);
                        }
                        //else if (lbl_processname.Text == "Ops & Docs - Air Imports")
                        //{
                        //    link_OpsDockAI_Click(sender, e);
                        //}

                    }
                    else
                    {
                        if (lbl_processname.Text == "SALES")
                        {
                            link_sales_Click(sender, e);
                        }
                        else if (lbl_processname.Text == "MIS & ANALYTICS")
                        {
                            link_mis_Click(sender, e);
                        }

                        else if (lbl_processname.Text == "FINANCIAL ACCOUNTS")
                        {
                            link_finan_Click(sender, e);


                        }
                        else if (lbl_processname.Text == "OCEAN EXPORTS")
                        {
                            link_cusOE_Click(sender, e);
                        }
                        else if (lbl_processname.Text == "OCEAN IMPORTS")
                        {
                            link_cusOI_Click(sender, e);
                        }
                        else if (lbl_processname.Text == "AIR EXPORTS")
                        {
                            link_cusAE_Click(sender, e);
                        }
                        else if (lbl_processname.Text == "AIR IMPORTS")
                        {
                            link_cusAI_Click(sender, e);
                        }
                        else if (lbl_processname.Text == "MAINTENANCE")
                        {
                            link_maintenance_Click(sender, e);
                        }
                        //else if (lbl_processname.Text == "Ops & Docs - Ocean Imports")
                        //{
                        //    link_OpsDockOI_Click(sender, e);
                        //}
                        //else if (lbl_processname.Text == "Ops & Docs - Air Exports")
                        //{
                        //    link_OpsDockAE_Click(sender, e);
                        //}
                        //else if (lbl_processname.Text == "Ops & Docs - Air Imports")
                        //{
                        //    link_OpsDockAI_Click(sender, e);
                        //}

                    }


                }

            }
        }
        protected void AgencyExportopandcs()
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
               // link_CUSOE();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                if (txt_user.Text != "")
                {
                    hid_processid.Value = "";
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "22";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "NE");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true; btn_back1.Visible = true;
                        btn_save.Visible = true; btn_save_id.Visible = true;
                        btn_view.Visible = true; btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }

            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if(btnadd.ToolTip == "Add")
            {
                hf_employeeid.Value = da_obj_HRFrontObj.SpInEmpRole(txt_user.Text, txt_details.Text).ToString();
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Added Successfully ');", true);
                 
                btnadd.ToolTip = "Update";
                btnadd.Attributes["class"] = "btn ico-update";
                btnadd.Text = "Update";
            }
            else
            {
                da_obj_HRFrontObj.SpUpEmpRole(txt_user.Text, txt_details.Text);
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Updated Successfully ');", true);

            }

            //iframecost.Attributes["src"] = "RoleDescription.aspx";
            //popupfro.Visible = true;
            //PopupBL.Show();
        }

        protected void AgencyImportsopandcs()
        {
            if (Session["StrTranType"].ToString() == "AC")
            {
                // link_CUSOE();
            }
            else
            {
                txt_user.Visible = true;
                Panel1.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                if (txt_user.Text != "")
                {
                    hid_processid.Value = "";
                    if (hid_processid.Value == "")
                    {
                        hid_processid.Value = "23";
                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        LoadCheckList();
                    }
                    dts = userobj.sp_getprocessname(Convert.ToInt32(hid_processid.Value));
                    {
                        lbl_processname.Text = dts.Rows[0]["processname"].ToString();
                    }
                    dt = hrobj.sp_userrights(Convert.ToInt32(hid_processid.Value), "NI");
                    if (dt.Rows.Count > 0)
                    {

                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //  dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("menuname");
                        obj_dtEmp.Columns.Add("modulename");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i]["uicaption"].ToString();
                            dr["menuname"] = dt.Rows[i]["menuname"].ToString();
                            dr["modulename"] = dt.Rows[i]["modulename"].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }

                        grd_user.Visible = true;
                        Gridbranch.Visible = false;
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                        btn_back.Visible = true; btn_back1.Visible = true;
                        btn_save.Visible = true; btn_save_id.Visible = true;
                        btn_view.Visible = true; btn_view_id.Visible = true;
                        lbl_processname.Visible = true;
                        Panel1.Visible = true;

                    }
                    if (grd_user.Rows.Count > 0)
                    {
                        dt1 = da_obj_userobj.sp_userrights4uinewRole(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hid_processid.Value), Convert.ToInt32(hf_branchid.Value));
                        if (dt1.Rows.Count > 0)
                        {

                            for (int i = 0; i <= grd_user.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                                {
                                    if (grd_user.Rows[i].Cells[0].Text == dt1.Rows[j]["uicaption"].ToString())
                                    {
                                        if (dt1.Rows[j][1].ToString() == "True")
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = true;
                                        }
                                        else
                                        {
                                            chk1 = (CheckBox)(grd_user.Rows[i].FindControl("chk_access1"));
                                            chk1.Checked = false;
                                        }

                                        if (dt1.Rows[j][2].ToString() == "True")
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = true;
                                        }
                                        else
                                        {
                                            chk2 = (CheckBox)(grd_user.Rows[i].FindControl("chk_save1"));
                                            chk2.Checked = false;
                                        }

                                        if (dt1.Rows[j][3].ToString() == "True")
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = true;
                                        }
                                        else
                                        {
                                            chk3 = (CheckBox)(grd_user.Rows[i].FindControl("chk_view1"));
                                            chk3.Checked = false;
                                        }

                                        if (dt1.Rows[j][4].ToString() == "True")
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = true;
                                        }
                                        else
                                        {
                                            chk4 = (CheckBox)(grd_user.Rows[i].FindControl("chk_delete1"));
                                            chk4.Checked = false;
                                        }

                                        if (dt1.Rows[j][5].ToString() == "True")
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = true;
                                        }
                                        else
                                        {
                                            chk5 = (CheckBox)(grd_user.Rows[i].FindControl("chk_upd1"));
                                            chk5.Checked = false;
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter tne Username ');", true);
                    txt_user.Focus();
                    return;
                }

            }

        }
    }


}