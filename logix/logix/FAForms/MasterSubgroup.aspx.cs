using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Services;
using System.Web.Script;
using System.Web.Script.Services;

namespace logix.FAForm
{
    public partial class MasterSubgroup : System.Web.UI.Page
    {
        DataAccess.FAMaster.MasterGroup obj = new DataAccess.FAMaster.MasterGroup();
        DataAccess.FAMaster.MasterSubGroup sobj = new DataAccess.FAMaster.MasterSubGroup();
        DataAccess.FAMaster.MasterSubGroup Obj_SubGroup = new DataAccess.FAMaster.MasterSubGroup();
        int i;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable sdt = new DataTable();
        DataTable sdt1 = new DataTable();
        int groupid;
        int sgroupid;
        string gname;
        string sgname;
        string strgroupname;
        string strcategory;
        string strtype;
        bool blnErr = false;
        int s;
        int d;
        DataTable dt_seltypad = new DataTable();
        DataTable dt_selgroup = new DataTable();
        public string temp_str;

        // RPT rptclass = new RPT();
        public string submenuname, dbName;
        public string strtrantype;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable dtgrd = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj.GetDataBase(Ccode);
                sobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                Obj_SubGroup.GetDataBase(Ccode);
               



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                dtgrd = sobj.SelMastersubGroup4grd(Session["FADbname"].ToString());
                grd.DataSource = dtgrd;
                grd.DataBind();
            }

            strtrantype = Session["str_ModuleName"].ToString();
            dbName = HttpContext.Current.Session["FADbname"].ToString();
        }

        [WebMethod]
        public static List<string> Getgroupname(string prefix)
        {
            DataAccess.FAMaster.MasterGroup obj_da_Group = new DataAccess.FAMaster.MasterGroup();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_Group.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_Group.GetLikeGroupname(prefix.ToUpper(), HttpContext.Current.Session["FADbname"].ToString());
            Bookingno = Utility.Fn_DatatableToList_stringnew(obj_Dt, "groupname", "groupid");
            return Bookingno;
        }

        [WebMethod]
        public static List<string> GetSubgroupname(string prefix)
        {
            DataAccess.FAMaster.MasterSubGroup obj_da_Group = new DataAccess.FAMaster.MasterSubGroup();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_Group.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_Group.GetLikesubGroupname(prefix.ToUpper(), HttpContext.Current.Session["FADbname"].ToString());
            Bookingno = Utility.Fn_DatatableToList_stringnew(obj_Dt, "subgroupname", "subgroupid");
            return Bookingno;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            CheckData();
            if (blnErr == true)
            {
                blnErr = false;
                return;
            }

            if (btnsave.ToolTip == "Save")
            {
                sobj.InsMasterSubGroup(txtsubgroupname.Text.ToUpper(), Convert.ToInt32(hid_groupid.Value), dbName);

                if (strtrantype == "FA")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1085, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtsubgroupname.Text + " / S");
                }
                else if (strtrantype == "FC")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1175, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtsubgroupname.Text + " / S");
                }
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Details Saved');", true);
            }
            else if (btnsave.ToolTip == "Update")
            {
                sgroupid = Convert.ToInt32(hid_subgroupid.Value);

                if (sgroupid == 0)
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('SubGroupname Not Exist');", true);
                    blnErr = true;
                    txtsubgroupname.Focus();
                    return;
                }

                sobj.UpdMastersubGroup(txtsubgroupname.Text, Convert.ToInt32(hid_groupid.Value), Convert.ToInt32(hid_subgroupid.Value), dbName);

                if (strtrantype == "FA")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1085, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtsubgroupname.Text + "/ U");
                }
                else if (strtrantype == "FC")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1175, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtsubgroupname.Text + "/ U");
                }
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Details updated');", true);
            }

            btnsave.Enabled = false;
            Clear();
        }

        public void CheckData()
        {
            if (txtsubgroupname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('SubGroupName cannot be BLANK');", true);
                blnErr = true;
                txtsubgroupname.Focus();
                return;
            }
            if (txtGroupname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('GroupName cannot be BLANK');", true);
                blnErr = true;
                txtGroupname.Focus();
                return;
            }
            if (hid_groupid.Value == "0" || hid_groupid.Value=="")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Please Enter Valid Group Name');", true);
                blnErr = true;
                txtGroupname.Focus();
                return;
            }
        }

        private void Clear()
        {
            btnsave.Enabled = true;
            txtclear();
            txtsubgroupname.Enabled = true;
            btncancel.Text = "Back";
            btncancel.ToolTip = "Back";
            btncancel1.Attributes["class"] = "btn ico-back";
            btnsave.Text = "Save";
            btnsave.ToolTip = "Save";
            btnsave1.Attributes["class"] = "btn ico-save";
            sgroupid = 0;
            groupid = 0;
            dtgrd = sobj.SelMastersubGroup4grd(dbName);
            grd.DataSource = dtgrd;
            grd.DataBind();
            txtsubgroupname.Focus();
        }

        public void txtclear()
        {
            txtGroupname.Text = "";
            txtsubgroupname.Text = "";
            txtCategory.Text = "";
            txtgroupetype.Text = "";
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            //DataAccess.FAMaster.MasterSubGroup Obj_SubGroup = new DataAccess.FAMaster.MasterSubGroup();
            Obj_SubGroup.temp_InsMasterSubGroup(Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString());

            string str_RptName, str_sf = "", str_sp = "", str_Script = "";
            str_sf = "{temp_MasterSubGroup.empid}=" + Convert.ToInt32(Session["LoginEmpId"]); 
            str_RptName = "rptFASubgroups.rpt";
            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterGroup", str_Script, true);

            if (strtrantype == "FA")
            {
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1085, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtsubgroupname.Text + "/ V");
            }
            else if (strtrantype == "FC")
            {
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1175, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtsubgroupname.Text + "/ V");
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Back")
            {
                //this.Response.End();

                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "BR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }

                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FAFC")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
            else
            {
                Clear();
            }

        }
        public void sub_details()
        {
            sgroupid = 0;
            if (txtsubgroupname.Text != "")
            {
                sgname = txtsubgroupname.Text;
                dt_seltypad = sobj.GetLikesubGroupname(sgname, dbName);

                if (dt_seltypad.Rows.Count == 1)
                {
                    sgroupid = Convert.ToInt32(dt_seltypad.Rows[0]["subgroupid"]);
                    groupid = Convert.ToInt32(dt_seltypad.Rows[0]["groupid"]);
                    hid_subgroupid.Value = sgroupid.ToString();

                }
                else
                {
                    //btncancel.Text = "Back";
                    btnsave.Text = "Save";


                    btncancel.ToolTip = "Back";
                    btnsave.ToolTip = "Save";

                    btncancel1.Attributes["class"] = "btn ico-back";
                    btnsave1.Attributes["class"] = "btn ico-save";
                    sgroupid = 0;
                    groupid = 0;
                    return;
                }
            }

            if (txtsubgroupname.Text != "")
            {
                dt_selgroup = sobj.SelMastersubGroup(sgroupid, dbName);
                if (dt_selgroup.Rows.Count > 0)
                {
                    strgroupname = dt_selgroup.Rows[0]["groupname"].ToString();
                    strcategory = dt_selgroup.Rows[0]["groupcategory"].ToString();
                    strtype = dt_selgroup.Rows[0]["grouptype"].ToString();
                    txtGroupname.Text = strgroupname;
                    txtCategory.Text = strcategory;
                    txtgroupetype.Text = strtype;
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Details Already Exists');", true);
                    txtsubgroupname.Enabled = false;
                    btnsave.Text = "Update";
                    btnsave.ToolTip = "Update";
                    btnsave1.Attributes["class"] = "btn ico-update";
                    txtGroupname.Focus();
                }
                btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btncancel1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {

        }
        protected void txtsubgroupname_TextChanged(object sender, EventArgs e)
        {
            sub_details();
        }

        protected void txtGroupname_TextChanged(object sender, EventArgs e)
        {
            hid_groupid.Value = "0";

            if (txtGroupname.Text != "")
            {
                sgname = txtGroupname.Text;
                dt_seltypad = obj.GetLikeGroupnameNEW(sgname, dbName);

                if (dt_seltypad.Rows.Count > 0)
                {
                    groupid = Convert.ToInt32(dt_seltypad.Rows[0]["groupid"]);
                    gname = dt_seltypad.Rows[0]["groupname"].ToString();
                    hid_groupid.Value = groupid.ToString();
                    txtGroupname.Text = gname;
                }
            }

            if (txtGroupname.Text != "")
            {
                if (groupid == 0)
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Please Enter Valid Group Name');", true);
                    txtCategory.Text = "";
                    txtgroupetype.Text = "";
                    txtGroupname.Text = "";
                    txtGroupname.Focus();
                    return;
                }

                dt_selgroup = obj.SelMasterGroup(groupid, dbName);
                if (dt_selgroup.Rows.Count > 0)
                {
                    strcategory = dt_selgroup.Rows[0]["groupcategory"].ToString();
                    strtype = dt_selgroup.Rows[0]["grouptype"].ToString();
                    txtCategory.Text = strcategory;
                    txtgroupetype.Text = strtype;
                    //btncancel.Text = "Cancel";
                    //btnsave.Text = "Update";
                }
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1085, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1175, "", "", "", Session["StrTranType"].ToString());
            }

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }


    }
}
           