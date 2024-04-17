using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using System.Configuration;

namespace logix.FAForm
{
    public partial class Mastergroup : System.Web.UI.Page
    {
        DataAccess.FAMaster.MasterGroup da_obj_Group = new DataAccess.FAMaster.MasterGroup();
        String gname;
        Char ct;
        Char gt;
        int i;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        int groupid;
        Boolean blnErr = false;
        DataTable dtgrd = new DataTable();

        string strtrantype, log = "";
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.FAMaster.MasterGroup Obj_MasterGroup = new DataAccess.FAMaster.MasterGroup();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Group.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                Obj_MasterGroup.GetDataBase(Ccode);
               



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncan);

            log = Session["FADbname"].ToString();

            if (!IsPostBack)
            {
                //string str_CtrlLists, str_MsgLists, str_DataType;
                //str_CtrlLists = "txtname~ddl_Category~ddl_GroupType";
                //str_MsgLists = "Group Name~Category~GroupType";
                //str_DataType = "String~DropDown~DropDown";
                //btnsave.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                DataTable dtgrd = new DataTable();
                dtgrd = da_obj_Group.SelMasterGroup4Grd(log);
                grdimage.DataSource = dtgrd;
                grdimage.DataBind();
            }

            strtrantype = Session["str_ModuleName"].ToString();
        }

        private void txtclear()
        {
            txtname.Text = "";
            txtname.Enabled = true;
            //txtname.ReadOnly = false;
            ddl_Category.SelectedIndex = -1;
            ddl_GroupType.Items.Clear();
            ddl_GroupType.Items.Add("Group Type");
        }

        private void clear()
        {
            btnsave.Enabled = true;

            txtclear();
            btnsave.ToolTip = "Save";
            btnsave1.Attributes["class"] = "btn ico-save";
            btncan.ToolTip = "Back";
            btncan1.Attributes["class"] = "btn ico-back";
            dtgrd = da_obj_Group.SelMasterGroup4Grd(log);
            grdimage.DataSource = dtgrd;
            grdimage.DataBind();
            txtname.Focus();            
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            CheckData();

            if (blnErr == true)
            {
                blnErr = false;
                return;
            }

            log = Session["FADbname"].ToString();
            ct = char.Parse(ddl_Category.SelectedValue.ToString());
            gt = char.Parse(ddl_GroupType.SelectedValue.ToString());

            if (hid_Groupid.Value != "")
            {
                groupid = Convert.ToInt32(hid_Groupid.Value);
            }
            if (btnsave.ToolTip == "Save")
                {
                    da_obj_Group.InsMasterGroup(txtname.Text.ToUpper(), ct, gt, log);

                    if (strtrantype == "FA")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1084, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtname.Text + "/ S");
                    }
                    if (strtrantype == "FC")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1174, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtname.Text + "/ S");
                    }
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "alert", "alertify.alert('Details Saved');", true);
                }
            if (btnsave.ToolTip == "Update")
                {
                    da_obj_Group.UpdMasterGroup(txtname.Text.ToString().ToUpper(), ct, gt, groupid, log);
                    if (strtrantype == "FA")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1084, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtname.Text + "/ U");
                    }
                    if (strtrantype == "FC")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1174, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtname.Text + "/ U");
                    }
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "alert", "alertify.alert('Details Updated');", true);
                }
            clear();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {

        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            //DataAccess.FAMaster.MasterGroup Obj_MasterGroup = new DataAccess.FAMaster.MasterGroup();
            Obj_MasterGroup.temp_InsMasterGroup(Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString());

            string str_RptName, str_sf = "", str_sp = "", str_Script = "";
            str_sf = "{temp_MasterGroup.empid}=" + Convert.ToInt32(Session["LoginEmpId"]); 
            str_RptName = "rptFAMasterGroup.rpt";
            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterGroup", str_Script, true);

            if (strtrantype == "FA")
            {
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1084, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtname.Text + "/ V");
            }
            if (strtrantype == "FC")
            {
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1174, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtname.Text + "/ V");
            }
        }

        protected void btncan_Click1(object sender, EventArgs e)
        {
            if (btncan.ToolTip == "Back")
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
                clear();
            }
        }

        protected void txtname_TextChanged(object sender, EventArgs e)
        {
            if (txtname.Text != "")
            {
                
                DataTable dt_seltypad = da_obj_Group.GetLikeGroupname(txtname.Text, Session["FADbname"].ToString());
                if (dt_seltypad.Rows.Count > 0)
                {
                    for (i = 0; i <= dt_seltypad.Rows.Count - 1; i++)
                    {
                        groupid = Convert.ToInt32(dt_seltypad.Rows[i]["groupid"]);
                        gname = dt_seltypad.Rows[i]["groupname"].ToString();
                        dt1 = da_obj_Group.SelMasterGroup(groupid, Session["FADbname"].ToString());
                        hid_Groupid.Value = groupid.ToString();
                        if (gname == txtname.Text)
                        {
                            txtname.Text = gname.ToString();
                            if (dt1.Rows.Count > 0)
                            {
                                ddl_Category.SelectedIndex = ddl_Category.Items.IndexOf(ddl_Category.Items.FindByText(dt1.Rows[0]["groupcategory"].ToString()));
                                ddl_Category_SelectedIndexChanged(sender, e);
                                ddl_GroupType.SelectedIndex = ddl_GroupType.Items.IndexOf(ddl_GroupType.Items.FindByText(dt1.Rows[0]["grouptype"].ToString()));
                                btnsave.ToolTip = "Update";
                                btnsave1.Attributes["class"] = "btn btn-update1";
                                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "alert", "alertify.alert('Details Already Exists');", true);
                                txtname.Enabled = false;
                                //txtname.ReadOnly = true;
                                return;
                            }
                        }
                    }
                }
            }
        }

        [WebMethod]
        public static List<string> Get_Groupname(string prefix)
        {
            DataAccess.FAMaster.MasterGroup obj_da_Group = new DataAccess.FAMaster.MasterGroup();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_Group.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_Group.GetLikeGroupname(prefix.ToUpper(), HttpContext.Current.Session["FADbname"].ToString());
            Bookingno = Utility.Fn_TableToList(obj_Dt, "groupname");
            return Bookingno;
        }

        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_GroupType.Items.Clear();
            if (ddl_Category.SelectedIndex == 1)
            {
                ddl_GroupType.Items.Add(new ListItem("Assets", "A"));
                ddl_GroupType.Items.Add(new ListItem("Liabilities", "L"));
            }
            else if (ddl_Category.SelectedIndex == 2)
            {
                ddl_GroupType.Items.Add(new ListItem("Income", "I"));
                ddl_GroupType.Items.Add(new ListItem("Expenditures", "E"));
            }
        }

        protected void CheckData()
        {
            if (txtname.Text == "" && hid_Groupid.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter the Group Name')", true);
                txtname.Text = "";
                txtname.Focus();
                blnErr = true;
                return;
            }

            if (ddl_Category.SelectedValue == "0" || ddl_Category.Text == "Category")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select the Category')", true);
                ddl_Category.Focus();
                blnErr = true;
                return;
            }

            if (ddl_GroupType.SelectedValue == "0" || ddl_GroupType.Text == "Group Type")
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select the Group Type')", true);
                ddl_GroupType.Focus();
                blnErr = true;
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1084, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1174, "", "", "", Session["StrTranType"].ToString());
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








