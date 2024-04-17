using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
namespace logix.HRM
{
    public partial class HRMPersonalInformation : System.Web.UI.Page
    {
        DataRow dr;
        DataTable dt = new DataTable();
        DataTable obj_dt = new DataTable();
        DataSet ds = new DataSet();
        string DBSC = "";
        string strpwd = "";
        SqlConnection con;
        SqlCommand cmd, cmd1;
        int id;
        int empidnew;
        DataTable DtEmpNew = new DataTable();
        int intEmpID, intPortID, intDivisionID, intDesigID, intDeptID, int_Empid;
        byte[] postfile1 = null;
        DataAccess.Masters.MasterEmployee empObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterPort prtObj = new DataAccess.Masters.MasterPort();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterEmployee objproces = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.UserPermission user_check = new DataAccess.UserPermission();

        Boolean blr;
        string dobdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();GenerateLabelAfter();", true);



            //con = new SqlConnection(DBSC);
            cmd = new SqlCommand();
            cmd1 = new SqlCommand();
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(link_cust);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://sl.copperhawk.tech/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://sl.copperhawk.tech/FormMain.aspx','_top');", true);
            }
            string str_CtrlLists, str_MsgLists, str_DataType;
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_save);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_update);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            Page.Form.Attributes.Add("enctype", "multipart/form-data");

            if (!IsPostBack)
            {
                try
                {
                    workproccess();
                    //lnk_personal_Click(sender, e)
                    //str_CtrlLists = "txt_empcode~ddl_name~txt_name~txt_Function~txt_Adminreport~txt_Appraisal~txt_reviewedby";
                    //str_MsgLists = "EmpCode~Name Title~EmpName~Admin Report~Appraisal By~reviewedby";
                    //str_DataType = "String~DropDown~String~String";
                    //btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");

                    //str_CtrlLists = "txt_Eduqualification~txt_EduYear~txt_EduPrecentage";
                    //str_MsgLists = "Qualification~Year~Precentage";
                    //str_DataType = "String~String";
                    //btn_EduAdd.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsPrecentageCheck('txt_EduPrecentage');");

                    //str_CtrlLists = "txt_organisation~txt_designation~txt_fromyear~txt_toyear";
                    //str_MsgLists = "Organisation~Designation~FromYear~ToYear";
                    //str_DataType = "String~String~String~String";
                    //btn_ExpAdd.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");

                    //str_CtrlLists = "ddl_division~ddl_branch~ddl_designation~ddl_department~ddl_workproces";
                    //str_MsgLists = "Division~Branch~Designation~Department";
                    //str_DataType = "DropDown~DropDown~DropDown~DropDown";
                    //btn_update.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");

                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    txt_fromyear.Text = Convert.ToDateTime(obj_da_Log.GetDate()).ToString("dd/MM/yyyy");
                    txt_toyear.Text = txt_fromyear.Text;
                    txt_EduYear.Text = txt_fromyear.Text;
                    //txt_dob.Text = string.Format("{0:dd - MMM - yyyy}", obj_da_Log.GetDate());
                    //txt_doj.Text = txt_dob.Text;
                    Grd_Edu.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Edu.DataBind();
                    Grd_Exp.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Exp.DataBind();
                    Fn_LoadDivision();
                    Fn_LoadDepartment();
                    deptfunction();
                    Fn_LoadDesignation();
                    Fn_Loadbranch();
                    Fn_Loadrole();
                    //txt_mobile.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //txt_fromyear.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //txt_toyear.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //txt_EduYear.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //txt_emergency.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //txt_land.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //txt_EduPrecentage.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'EduPrecentage')");
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    //Utility.MasterAll(lnk_empcode,txt_empcode);
                    Session["Packages"] = lbl_header.Text;
                    txt_empcode.Focus();
                    if (Session["empcode"] != null)
                    {
                        txt_empcode.Text = Session["empcode"].ToString();
                        Get_EmpDetail();
                        Session["empcode"] = null;
                        Session["head"] = null;
                        return;
                    }

                    DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
                    txt_dol.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
                    hid_date.Value = txt_dol.Text;
                    str_CtrlLists = "txt_Empcode~ddl_reason";
                    str_MsgLists = "EmpCode~Reason";
                    str_DataType = "String~DropDown";
                    btn_add.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_dol');");
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            if (txt_empcode.Text != "")
            {
                //btn_delete.Attributes["onClick"] = "return confirm('Do u want to delete the data?');";
                //btnedu_delete.Attributes["onClick"] = "return confirm('Do u want to delete the data?');";
            }
        }

        [WebMethod]
        public static List<string> getempname(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            obj_dt = obj_da_Employee.GetLikeEmpName(prefix.ToUpper());
            if (obj_dt.Rows.Count > 0)
            {
                //string alert = ws.webMethod();
                //System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alertify.alert(" + alert + ")</SCRIPT>");

            }
            List_Result = Utility.Fn_DatatableToList(obj_dt, "empname", "empcode");
            return List_Result;
        }
        [WebMethod]
        public static List<string> getreviewedname(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            //DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            obj_dt = obj_da_Employee.GetLikeEmpName(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList(obj_dt, "empname", "employeeid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> getReport(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            obj_dt = obj_da_Employee.GetLikeEmpName(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList(obj_dt, "empname", "empcode");
            return List_Result;
        }

        private void Fn_TabClick(System.Web.UI.HtmlControls.HtmlGenericControl Str_Ctrl, Panel Str_Pln = null)
        {
            List<System.Web.UI.HtmlControls.HtmlGenericControl> Str_lst = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();
            List<Panel> Str_Plnlst = new List<Panel>();
            Str_Plnlst.Add(Pln_Personal);
            Str_Plnlst.Add(pln_Education);
            Str_Plnlst.Add(Pln_Experience);
            Str_Plnlst.Add(Pln_Official);
            Str_Ctrl.Attributes["class"] = "div_TabClick";
            Str_Pln.Visible = true;
            Str_lst.Remove(Str_Ctrl);
            Str_Plnlst.Remove(Str_Pln);

            for (int i = 0; i <= Str_lst.Count - 1; i++)
            {
                Str_lst[i].Attributes["class"] = "div_Tab";
            }
            for (int i = 0; i <= Str_Plnlst.Count - 1; i++)
            {
                Str_Plnlst[i].Visible = false;
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



        protected void ddl_division_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fn_Loadbranch();
        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            Session["head"] = lbl_header.Text;
            Response.Redirect("EmployeeFind.aspx");
            //popcancel.Show();
            //iframecost.Attributes["src"] = "../HRM/EmployeeFind.aspx?txt1=" + txt_empcode.ID;
        }

        protected void txt_empcode_TextChanged(object sender, EventArgs e)
        {
            if (txt_empcode.Text.Trim().Length > 0)
            {
                hid_empid.Value = "";

                Get_EmpDetail();
                getupdata();
            }


        }

        private void Get_EmpDetail()
        {
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();

            DataTable dt_checkamend = new DataTable();
            DataTable obj_dt = new DataTable();
            DataAccess.userlogin obj_login = new DataAccess.userlogin();
            obj_dt = obj_da_Emp.selEmpDetails(txt_empcode.Text.ToUpper(), "PER");

            if (obj_dt.Rows.Count > 0)
            {
                hid_empid.Value = obj_dt.Rows[0][12].ToString();
                txtcode1.Text = txt_empcode.Text;
                txtempcode2.Text = txt_empcode.Text;
                txtmondob1.Text = txt_dob.Text;
                txtmondob.Text = txt_dob.Text;
                ddl_name.Text = DropDownList1.Text;
                ddl_name.Text = DropDownList2.Text;
                txt_group.Text = txtgurop.Text;
                txtgurop.Text = txtbg2.Text;
                ddl_name.Text = obj_dt.Rows[0][0].ToString();
                txt_name.Text = obj_dt.Rows[0][2].ToString();
                txt_educa.Text = obj_dt.Rows[0][2].ToString();
                txt_exper.Text = obj_dt.Rows[0][2].ToString();
                TextBox2.Text = obj_dt.Rows[0][2].ToString();
                txt_fathername.Text = obj_dt.Rows[0][3].ToString();
                txt_spousename.Text = obj_dt.Rows[0][4].ToString();
                txt_dob.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(obj_dt.Rows[0][5].ToString()));
                txtmondob1.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(obj_dt.Rows[0][5].ToString()));
                txtmondob.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(obj_dt.Rows[0][5].ToString()));
                txt_bob.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(obj_dt.Rows[0][5].ToString()));
                txt_group.Text = obj_dt.Rows[0][6].ToString();
                txtgurop.Text = obj_dt.Rows[0][6].ToString();
                txtbg2.Text = obj_dt.Rows[0][6].ToString();
                txt_grou.Text = obj_dt.Rows[0][6].ToString();
                txt_permanentaddress.Text = obj_dt.Rows[0][7].ToString();
                txt_presentaddress.Text = obj_dt.Rows[0][8].ToString();
                txt_mobile.Text = obj_dt.Rows[0][9].ToString();
                txt_land.Text = obj_dt.Rows[0][10].ToString();
                txt_scb.Text = obj_dt.Rows[0][13].ToString();
                txt_pan.Text = obj_dt.Rows[0][14].ToString();
                txt_pf.Text = obj_dt.Rows[0]["pfno"].ToString();
                txt_esi.Text = obj_dt.Rows[0]["esino"].ToString();
                txt_adhartno.Text = obj_dt.Rows[0]["aadharno"].ToString();
                txt_uanno.Text = obj_dt.Rows[0]["UANno"].ToString();
                txt_emergency.Text = obj_dt.Rows[0]["phoneoth"].ToString();
                id = Convert.ToInt32(obj_dt.Rows[0]["reportingto"].ToString());

                int processid = Convert.ToInt32(obj_dt.Rows[0]["workprocess"]);

                if (processid == 9)
                {
                    ddl_process.SelectedItem.Text = "Air Exports";
                }
                else if (processid == 10)
                {
                    ddl_process.SelectedItem.Text = "Air Imports";
                }
                else if (processid == 7)
                {
                    ddl_process.SelectedItem.Text = "Ocean Exports";
                }
                else if (processid == 8)
                {
                    ddl_process.SelectedItem.Text = "Ocean Imports";

                }
                else if (processid == 21)
                {
                    ddl_process.SelectedItem.Text = "Financial Accounts";
                }
                else if (processid == 19)
                {
                    ddl_process.SelectedItem.Text = "Maintenance";
                }
                else if (processid == 18)
                {
                    ddl_process.SelectedItem.Text = "MIS & Analytics";
                }
                else if (processid == 2)
                {
                    ddl_process.SelectedItem.Text = "Sales";
                }
                Get_EmpOfficialDetail();
                dt_checkamend = user_check.Get_maintenancerights(Convert.ToInt32(hid_empid.Value), "");
                if (dt_checkamend.Rows.Count > 0)
                {
                    lbl_PWD.Visible = true;
                    string pwd = obj_login.Decrypt(obj_dt.Rows[0]["pwd"].ToString(), obj_dt.Rows[0]["employeeid"].ToString()).ToString();
                    lbl_PWD.Text = "Login_ID : " + txt_mailid.Text.ToUpper() + " / " + "Password : " + pwd;
                }
                //if (id == 0)
                //{
                //    txtReportingto.Text = "";
                //}
                //else
                //{
                //    txtReportingto.Text = empObj.GetEmployeeName(id);
                //}

                txt_email.Text = obj_dt.Rows[0][11].ToString();
                TextBox1.Text = txt_empcode.Text;
                if (!DBNull.Value.Equals(obj_dt.Rows[0]["empphoto"]))
                {
                    DataTable obj_dtimg = new DataTable();
                    DataRow dr;
                    dr = obj_dtimg.NewRow();
                    obj_dtimg.Columns.Add("image", Type.GetType("System.Byte[]"));
                    Byte[] empimage = (byte[])(obj_dt.Rows[0]["empphoto"]);
                    dr["image"] = empimage;
                    obj_dtimg.Rows.Add(dr);
                    Session["dt"] = obj_dtimg;
                    string base64String = Convert.ToBase64String(empimage);

                    if (base64String == "")
                    {
                        Img_Emp.ImageUrl = "~/images/UT.jpg";
                    }
                    else
                    {
                        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    }

                    //Img_Emp.ImageUrl = "../imgEmp.aspx";
                }
                else
                {
                    Img_Emp.ImageUrl = "~/images/UT.jpg";
                }
                if (!DBNull.Value.Equals(obj_dt.Rows[0]["sign"]))
                {
                    DataTable obj_dtsign = new DataTable();
                    DataRow dr;
                    dr = obj_dtsign.NewRow();
                    obj_dtsign.Columns.Add("image", Type.GetType("System.Byte[]"));
                    Byte[] empimage = (byte[])(obj_dt.Rows[0]["sign"]);
                    dr["image"] = empimage;
                    obj_dtsign.Rows.Add(dr);
                    Session["sign"] = obj_dtsign;
                    string base64String = Convert.ToBase64String(empimage);
                    if (base64String == "")
                    {
                        Img_Sign.ImageUrl = "~/images/signature.JPG";
                    }
                    else
                    {
                        Img_Sign.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    //Img_Sign.ImageUrl = "../imgSign.aspx";
                }
                else
                {
                    Img_Sign.ImageUrl = "~/images/signature.JPG";
                }

                DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
                DataTable obj_dt1 = new DataTable();
                obj_dt1 = obj_da_Employee.GetROLDetail(txt_empcode.Text.ToUpper());
                if (obj_dt1.Rows.Count > 0)
                {
                    ddl_reason.SelectedValue = obj_dt1.Rows[0][1].ToString();
                    if (obj_dt1.Rows[0][0].ToString().Trim().Length > 0)
                    {
                        txt_dol.Text = Utility.fn_ConvertDate(obj_dt1.Rows[0][0].ToString());

                    }
                    else
                    {
                        txt_dol.Text = hid_date.Value.ToString();
                    }

                }
                btn_add.Enabled = true;
                txt_dol.Enabled = true;

                btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";
                txtcode1.Text = obj_dt.Rows[0][1].ToString();
                Fn_GrdEduDetail();
                Fn_GrdExpDetail();
                Get_EmpOfficialDetail();
                btn_save.Enabled = true;
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }
            else
            {
                //txt_empcode.Text = "";
                //txt_name.Focus();
            }

        }

        public void getupdata()
        {

            if (txt_empcode.Text != "")
            {
                //if(txt_Adminreport.Text=="")
                //{
                //    txt_Adminreport.Text = "NULL";
                //}
                //if (txt_Function.Text == "")
                //{
                //    txt_Function.Text = "NULL";
                //}
                //if (txt_Appraisal.Text == "")
                //{
                //    txt_Appraisal.Text = "NULL";
                //}
                //if (ddl_workproces.SelectedValue == "")
                //{
                //    ddl_workproces.SelectedValue = "NULL";
                //}

                obj_dt = HREmpobj.selempudate(txt_empcode.Text.ToUpper());
                if (obj_dt.Rows.Count > 0)
                {
                    hid_adminreport.Value = obj_dt.Rows[0]["adminid"].ToString();
                    hid_functionalreport.Value = obj_dt.Rows[0]["functionreportid"].ToString();
                    hid_appraisal.Value = obj_dt.Rows[0]["appraisalid"].ToString();
                    hid_workprocess.Value = obj_dt.Rows[0]["Processid"].ToString();
                    hid_reviewedby.Value = obj_dt.Rows[0]["reviewedid"].ToString();
                    txt_Adminreport.Text = obj_dt.Rows[0]["AdminReporting"].ToString();
                    txt_Function.Text = obj_dt.Rows[0]["FunctionalReporting"].ToString();
                    txt_Appraisal.Text = obj_dt.Rows[0]["AppraisalBy"].ToString();
                    txt_reviewedby.Text = obj_dt.Rows[0]["reviewedby"].ToString();
                    functionid.Value = obj_dt.Rows[0]["functionid"].ToString();
                    DataAccess.Masters.MasterEmployee empobjt = new DataAccess.Masters.MasterEmployee();
                    if (functionid.Value != "")
                    {
                        dt = empobjt.GetLikefunctionid(functionid.Value);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        ddl_function.SelectedValue = dt.Rows[0]["name"].ToString();
                    }

                }



                if (hid_empid.Value != "")
                {
                    dt = objproces.GetHRMprocessid(Convert.ToInt32(hid_empid.Value));
                }
                else
                {

                    hid_empid.Value = "0";
                    dt = objproces.GetHRMprocessid(Convert.ToInt32(hid_empid.Value));
                }

                //int i = dt.Rows.Count;

                // if (dt.Rows.Count > 0)
                // {
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                DataTable dtrole = obj_da_Emp.Getroleforemployee(txt_empcode.Text.ToUpper());
                for (int i = 0; i <= dtrole.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= chkproducts.Items.Count - 1; j++)
                    {
                        if (dtrole.Rows[i]["rolename"].ToString() == chkproducts.Items[j].Text)
                        {
                            chkproducts.Items[j].Selected = true;
                        }
                    }
                }

                string name = "";
                for (int j = 0; j < chkproducts.Items.Count; j++)
                {
                    if (chkproducts.Items[j].Text != "SELECT ALL")
                    {
                        if (chkproducts.Items[j].Selected)
                        {
                            name += chkproducts.Items[j].Text + ",";
                        }
                    }
                }
                txt_workprocess.Text = name;

                //}
            }


        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string user_;
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                //int Str_Date =Convert.ToInt32(Fn_DOBDateFormate(txt_dob.Text));
                //DateTime dt_DOB = DateTime.Parse(Utility.fn_ConvertDate(Str_Date).ToString());
                // dobdate = string.Format("{0:dd/MM/yyyy}", obj_da_Log.GetDate());
                //if (txt_dob.Text == dobdate)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Current Date is not Accepted in DOB');", true);
                //    return;
                //}
                //if (txt_workprocess.Text != "")
                //{
                if (txt_empcode.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Employee Code');", true);
                    return;
                }
                if (txt_mobile.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Mobile #');", true);
                    return;
                }
                if (txt_mailid.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Email');", true);
                    return;
                }
                if (ddl_process.SelectedItem.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Select the Work Process');", true);
                    return;
                }
                if (btn_save.ToolTip == "Save")
                {

                    user_ = user_check.Get_allowed_user();
                    if (user_ == "N")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Exceeds Your User License');", true);
                        return;
                    }


                    //empidnew = empObj.GetNEmpid(txtReportingto.Text);
                    //empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
                    byte[] Img_Length = new byte[0];
                    DataTable obj_dt = new DataTable();
                    if (Session["img"] != null)
                    {
                        obj_dt = (DataTable)Session["img"];
                        if (obj_dt.Rows.Count > 0)
                        {
                            Img_Length = ((byte[])obj_dt.Rows[0][0]);
                        }
                    }
                    if ((txt_Appraisal.Text != txt_Adminreport.Text) && (txt_Appraisal.Text != txt_Function.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Admin report (OR) Functional report name');", true);
                        txt_Appraisal.Text = "";
                        txt_Function.Focus();
                        return;
                    }
                    if (hid_adminreport.Value == "")
                    {
                        hid_adminreport.Value = "0";
                    }
                    if (hid_functionalreport.Value == "")
                    {
                        hid_functionalreport.Value = "0";
                    }
                    if (hid_appraisal.Value == "")
                    {
                        hid_appraisal.Value = "0";
                    }
                    if (hid_workprocess.Value == "")
                    {
                        hid_workprocess.Value = "0";
                    }
                    if (hid_reviewedby.Value == "")
                    {
                        hid_reviewedby.Value = "0";
                    }
                    if (ddl_division.SelectedValue == "0")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose Company Name');", true);
                        //blr = true;
                        //return;

                    }
                    if (ddl_branch.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose Branch');", true);

                        blr = true;
                        return;

                    }

                    if (ddl_designation.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose DESIGNATION');", true);
                        blr = true;
                        return;

                    }
                    if (ddl_department.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose DEPARTMENT');", true);
                        return;

                    }
                    if (ddl_function.SelectedIndex == 0)
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose FUNCTION');", true);
                        //return;

                    }
                    if (txt_dob.Text == "")
                    {
                        DateTime now = new DateTime();

                        txt_dob.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the DOB');", true);
                        //return;

                    }
                    if (txt_empcode.Text.Contains("T"))
                    {
                        obj_da_Emp.InsEmpPersonal(ddl_name.SelectedItem.Text, txt_empcode.Text.ToUpper(), txt_name.Text, txt_fathername.Text, txt_spousename.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_dob.Text)),
                        txt_group.Text, txt_permanentaddress.Text, txt_presentaddress.Text, txt_mobile.Text, txt_land.Text, txt_email.Text, txt_scb.Text, txt_pan.Text, Img_Length, txt_pf.Text, txt_esi.Text, "Y", txt_emergency.Text, empidnew, txt_adhartno.Text, txt_uanno.Text);

                    }
                    else
                    {
                        obj_da_Emp.InsEmpPersonal(ddl_name.SelectedItem.Text, txt_empcode.Text.ToUpper(), txt_name.Text, txt_fathername.Text, txt_spousename.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_dob.Text)),
                        txt_group.Text, txt_permanentaddress.Text, txt_presentaddress.Text, txt_mobile.Text, txt_land.Text, txt_email.Text, txt_scb.Text, txt_pan.Text, Img_Length, txt_pf.Text, txt_esi.Text, "N", txt_emergency.Text, empidnew, txt_adhartno.Text, txt_uanno.Text);

                    }
                    // hide by Yuvaraj 27/12/2022
                    // HREmpobj.getupdateempdatail(txt_empcode.Text, Convert.ToInt32(hid_adminreport.Value), Convert.ToInt32(hid_functionalreport.Value), Convert.ToInt32(hid_appraisal.Value), 0, Convert.ToInt32(hid_reviewedby.Value), Convert.ToInt32(hid_functionid.Value));
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 1, int.Parse(Session["LoginBranchid"].ToString()), "/S - PersonalInfo");
                    obj_da_Emp.Updroleinemployee(txt_empcode.Text.ToUpper(), txt_workprocess.Text);


                    for (int j = 0; j <= chkproducts.Items.Count - 1; j++)
                    {
                        if (chkproducts.Items[j].Text != "SELECT ALL")
                        {
                            if (chkproducts.Items[j].Selected == true)
                            {
                                obj_da_Emp.InsRole4employee(txt_empcode.Text.ToUpper(), chkproducts.Items[j].Text);
                            }
                        }
                    }
                    obj_da_Emp.Insuserrightsfromroleforemployee(txt_empcode.Text.ToUpper());


                    btn_update_Click(sender, e);

                    if (blr == true)
                    {
                        return;
                    }
                    /*  cmd = new SqlCommand("SPInsEmpPersonal", con);
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@title", ddl_name.SelectedItem.Text);
                      cmd.Parameters.AddWithValue("@empcode", txt_empcode.Text);
                      cmd.Parameters.AddWithValue("@empname", txt_name.Text);
                      cmd.Parameters.AddWithValue("@fathername", txt_fathername.Text);
                      cmd.Parameters.AddWithValue("@spousename", txt_spousename.Text);
                      cmd.Parameters.AddWithValue("@dob", txt_dob.Text);
                      cmd.Parameters.AddWithValue("@bloodgroup", txt_group.Text);
                      cmd.Parameters.AddWithValue("@addressc", txt_presentaddress.Text);
                      cmd.Parameters.AddWithValue("@addressp", txt_presentaddress.Text);
                      cmd.Parameters.AddWithValue("@phonehp", txt_mobile.Text);
                      cmd.Parameters.AddWithValue("@phoneres", txt_land.Text);
                      cmd.Parameters.AddWithValue("@email", txt_email.Text);
                      cmd.Parameters.AddWithValue("@accno", txt_scb.Text);
                      cmd.Parameters.AddWithValue("@panno", txt_pan.Text);
                      cmd.Parameters.AddWithValue("@empphoto", Img_Length);
                      cmd.Parameters.AddWithValue("@pfno", txt_pf.Text);
                      cmd.Parameters.AddWithValue("@esino", txt_esi.Text);
                      cmd.Parameters.AddWithValue("@tmpemp", "N");
                      cmd.Parameters.AddWithValue("@phoneoth", txt_emergency.Text);
                      cmd.Parameters.AddWithValue("@reportingto", empidnew);
                      cmd.Parameters.AddWithValue("@aadharno", txt_adhartno.Text);
                      cmd.Parameters.AddWithValue("@UANno", txt_uanno.Text);
                      cmd.CommandTimeout = 0;
                      if (con.State == ConnectionState.Closed)
                      {
                          con.Open();
                      }
                      cmd.ExecuteNonQuery();
                      con.Close();
                      */
                    txt_empcode_TextChanged(sender, e);



                    insnewhrm();
                    btn_save.Enabled = false;
                    Get_EmpOfficialDetail();

                    intEmpID = empObj.GetEmpid(txt_empcode.Text.ToUpper());
                    empObj.getInsUserrightsfromFunctionidinMasters(intEmpID);
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);


                }
                else if (btn_save.ToolTip == "Update")
                {

                    //empidnew = empObj.GetNEmpid(txtReportingto.Text);
                    //empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
                    byte[] Img_Length = new byte[0];
                    DataTable obj_dt = new DataTable();
                    if (Session["img"] != null)
                    {
                        obj_dt = (DataTable)Session["img"];
                        if (obj_dt.Rows.Count > 0)
                        {
                            Img_Length = ((byte[])obj_dt.Rows[0][0]);
                        }
                    }
                    if ((txt_Appraisal.Text != txt_Function.Text) && (txt_Appraisal.Text != txt_Adminreport.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Admin report (OR) Functional report name');", true);
                        txt_Appraisal.Text = "";
                        txt_Function.Focus();
                        return;
                    }
                    if (hid_adminreport.Value == "")
                    {
                        hid_adminreport.Value = "0";
                    }
                    if (hid_functionalreport.Value == "")
                    {
                        hid_functionalreport.Value = "0";
                    }
                    if (hid_appraisal.Value == "")
                    {
                        hid_appraisal.Value = "0";
                    }
                    if (hid_workprocess.Value == "")
                    {
                        hid_workprocess.Value = "0";
                    }
                    if (hid_reviewedby.Value == "")
                    {
                        hid_reviewedby.Value = "0";
                    }
                    if (ddl_function.SelectedIndex.ToString() != "")
                    {
                        ;// getfunctionid();
                    }

                    //if (ddl_division.SelectedValue == "0")
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose Company Name');", true);
                    //    blr = true;
                    //    return;

                    //}
                    //if (ddl_branch.SelectedValue == "0")
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose Branch');", true);

                    //    blr = true;
                    //    return;

                    //}

                    if (ddl_designation.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose DESIGNATION');", true);
                        blr = true;
                        return;

                    }
                    if (ddl_department.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose DEPARTMENT');", true);
                        return;

                    }
                    if (ddl_function.SelectedIndex == 0)
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Choose FUNCTION');", true);
                        //return;

                    }
                    if (txt_dob.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the DOB');", true);
                        return;

                    }
                    if (txt_empcode.Text.Contains("T"))
                    {

                        obj_da_Emp.UpdEmpPersonal(ddl_name.SelectedItem.Text, txt_empcode.Text.ToUpper(), txt_name.Text, txt_fathername.Text, txt_spousename.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_dob.Text)),
                        txt_group.Text, txt_permanentaddress.Text, txt_presentaddress.Text, txt_mobile.Text, txt_land.Text, txt_email.Text, txt_scb.Text, txt_pan.Text, Img_Length, txt_pf.Text, txt_esi.Text, "Y", txt_emergency.Text, empidnew, txt_adhartno.Text, txt_uanno.Text);

                    }
                    else
                    {
                        obj_da_Emp.UpdEmpPersonal(ddl_name.SelectedItem.Text, txt_empcode.Text.ToUpper(), txt_name.Text, txt_fathername.Text, txt_spousename.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_dob.Text)),
                                                    txt_group.Text, txt_permanentaddress.Text, txt_presentaddress.Text, txt_mobile.Text, txt_land.Text, txt_email.Text, txt_scb.Text, txt_pan.Text, Img_Length, txt_pf.Text, txt_esi.Text, "N", txt_emergency.Text, empidnew, txt_adhartno.Text, txt_uanno.Text);

                    }
                    obj_da_Emp.Updroleinemployee(txt_empcode.Text.ToUpper(), txt_workprocess.Text);
                    bool check=false;
                    for (int j = 0; j <= chkproducts.Items.Count - 1; j++)
                    {
                        if (chkproducts.Items[j].Text != "SELECT ALL")
                        {
                            if (chkproducts.Items[j].Selected == true)
                            {
                                obj_da_Emp.InsRole4employee(txt_empcode.Text.ToUpper(), chkproducts.Items[j].Text);
                                check = true;
                            }
                        }
                    }
                    if(check== false)
                    {

                    }
                    obj_da_Emp.Insuserrightsfromroleforemployee(txt_empcode.Text.ToUpper());
                    //hide yuvarj 27/12/2022
                    //HREmpobj.getupdateempdatail(txt_empcode.Text, Convert.ToInt32(hid_adminreport.Value), Convert.ToInt32(hid_functionalreport.Value), Convert.ToInt32(hid_appraisal.Value), 0, Convert.ToInt32(hid_reviewedby.Value), Convert.ToInt32(hid_functionid.Value));
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 2, int.Parse(Session["LoginBranchid"].ToString()), "/U - PersonalInfo");

                    //cmd = new SqlCommand("SPUpdEmpPersonal", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@title", ddl_name.SelectedItem.Text);

                    //cmd.Parameters.AddWithValue("@empcode", txt_empcode.Text);
                    //cmd.Parameters.AddWithValue("@empname", txt_name.Text);
                    //cmd.Parameters.AddWithValue("@fathername", txt_fathername.Text);
                    //cmd.Parameters.AddWithValue("@spousename", txt_spousename.Text);
                    //cmd.Parameters.AddWithValue("@dob", txt_dob.Text);
                    //cmd.Parameters.AddWithValue("@bloodgroup", txt_group.Text);
                    //cmd.Parameters.AddWithValue("@addressc", txt_presentaddress.Text);
                    //cmd.Parameters.AddWithValue("@addressp", txt_presentaddress.Text);
                    //cmd.Parameters.AddWithValue("@phonehp", txt_mobile.Text);
                    //cmd.Parameters.AddWithValue("@phoneres", txt_land.Text);
                    //cmd.Parameters.AddWithValue("@email", txt_email.Text);
                    //cmd.Parameters.AddWithValue("@accno", txt_scb.Text);
                    //cmd.Parameters.AddWithValue("@panno", txt_pan.Text);
                    //cmd.Parameters.AddWithValue("@empphoto", Img_Length);
                    //cmd.Parameters.AddWithValue("@pfno", txt_pf.Text);
                    //cmd.Parameters.AddWithValue("@esino", txt_esi.Text);
                    //cmd.Parameters.AddWithValue("@tmpemp", "N");
                    //cmd.Parameters.AddWithValue("@phoneoth", txt_emergency.Text);
                    //cmd.Parameters.AddWithValue("@reportingto", empidnew);
                    //cmd.Parameters.AddWithValue("@aadharno", txt_adhartno.Text);
                    //cmd.Parameters.AddWithValue("@UANno", txt_uanno.Text);

                    //cmd.CommandTimeout = 0;
                    //if (con.State == ConnectionState.Closed)
                    //{
                    //    con.Open();
                    //}
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                    //cmd1 = new SqlCommand("SPmasterempUpdate", con);
                    //cmd1.CommandType = CommandType.StoredProcedure;
                    //cmd1.Parameters.AddWithValue("@empcode", txt_empcode.Text);
                    //cmd1.Parameters.AddWithValue("@adminreporting", hid_adminreport.Value);
                    //cmd1.Parameters.AddWithValue("@functionalreporting", hid_functionalreport.Value);
                    //cmd1.Parameters.AddWithValue("@Appraisalby", hid_appraisal.Value);
                    //cmd1.Parameters.AddWithValue("@workprocess", hid_workprocess.Value);
                    //cmd1.Parameters.AddWithValue("@reviewedby", hid_reviewedby.Value);
                    //cmd1.CommandTimeout = 0;
                    //if (con.State == ConnectionState.Closed)
                    //{
                    //    con.Open();
                    //}
                    //cmd1.ExecuteNonQuery();
                    //con.Close();
                    insnewhrm();
                    btn_update_Click(sender, e);
                    if (blr == true)
                    {
                        return;
                    }
                    // txt_empcode_TextChanged(sender, e);

                    Get_EmpOfficialDetail();
                    btn_save.Enabled = false;
                    btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                }

                Fn_clear();
                Fn_Educlear();
                fn_edu();
                Fn_Expclear();
                Fn_Offclear();
                txt_empcode.Text = "";

                //}  
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Please  Select Work Process Item');", true);
                //}
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void insnewhrm()
        {
            int i = 0;
            int processid = 0;
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            obj_dt = obj_da_Emp.selEmpDetails(txt_empcode.Text.ToUpper(), "PER");

            if (obj_dt.Rows.Count > 0)
            {
                hid_empid.Value = obj_dt.Rows[0][12].ToString();
            }
            objproces.DELhrMEMPPROCEE(Convert.ToInt32(hid_empid.Value));

            if (ddl_process.SelectedItem.Text == "Air Exports")
            {
                processid = 9;
            }
            else if (ddl_process.SelectedItem.Text == "Air Imports")
            {
                processid = 10;
            }
            else if (ddl_process.SelectedItem.Text == "Ocean Exports")
            {
                processid = 7;
            }
            else if (ddl_process.SelectedItem.Text == "Ocean Imports")
            {
                processid = 8;
            }
            else if (ddl_process.SelectedItem.Text == "Financial Accounts")
            {
                processid = 21;
            }
            else if (ddl_process.SelectedItem.Text == "Maintenance")
            {
                processid = 19;
            }
            else if (ddl_process.SelectedItem.Text == "MIS & Analytics")
            {
                processid = 18;
            }
            else if (ddl_process.SelectedItem.Text == "Sales")
            {
                processid = 2;
            }
            objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //if (chkproducts.Items[1].Selected == true)
            //{
            //    processid = 1;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[2].Selected == true)
            //{
            //    processid = 2;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[3].Selected == true)
            //{
            //    processid = 3;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[4].Selected == true)
            //{
            //    processid = 4;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[5].Selected == true)
            //{
            //    processid = 5;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[6].Selected == true)
            //{
            //    processid = 6;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[7].Selected == true)
            //{
            //    processid = 7;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[8].Selected == true)
            //{
            //    processid = 8;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[9].Selected == true)
            //{
            //    processid = 9;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[10].Selected == true)
            //{
            //    processid = 10;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[11].Selected == true)
            //{
            //    processid = 11;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[12].Selected == true)
            //{
            //    processid = 12;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}

            //if (chkproducts.Items[13].Selected == true)
            //{
            //    processid = 13;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[14].Selected == true)
            //{
            //    processid = 14;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[15].Selected == true)
            //{
            //    processid = 15;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[16].Selected == true)
            //{
            //    processid = 16;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[17].Selected == true)
            //{
            //    processid = 17;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[18].Selected == true)
            //{
            //    processid = 18;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[19].Selected == true)
            //{
            //    processid = 19;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[20].Selected == true)
            //{
            //    processid = 20;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}
            //if (chkproducts.Items[21].Selected == true)
            //{
            //    processid = 21;
            //    objproces.INShrMEMPPROCEE(Convert.ToInt32(hid_empid.Value), Convert.ToInt32(processid));
            //}

        }
        private string Fn_DOBDateFormate(string str_date)
        {
            string Str_temp = "";
            str_date = str_date.Replace(" ", "");
            str_date = str_date.Replace("-", "/");
            string[] str_month = str_date.Split('/');
            str_month[1] = Utility.fn_intMonthName(str_month[1]).ToString();
            Str_temp = str_month[0] + "/" + str_month[1] + "/" + str_month[2];
            return Str_temp;
        }
        private void Fn_clear()
        {
            //txtReportingto.Text = "";
            //lbl_EduEmpcode.Text = "";
            txt_doj.Text = "";
            txt_dob.Text = "";
            txt_email.Text = "";
            txt_emergency.Text = "";
            //txt_empcode.Text = "";
            txt_esi.Text = "";
            txt_adhartno.Text = "";
            txt_uanno.Text = "";
            txt_fathername.Text = "";
            txt_group.Text = "";
            txt_land.Text = "";
            txt_mobile.Text = "";
            txt_name.Text = "";
            txt_pan.Text = "";
            txt_permanentaddress.Text = "";
            txt_pf.Text = "";
            txt_presentaddress.Text = "";
            txt_scb.Text = "";
            ddl_function.SelectedValue = "";
            txt_spousename.Text = "";
            Img_Emp.ImageUrl = "~/images/UT.jpg";
            btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            ddl_name.SelectedIndex = 0;
            ddl_process.Text = "";
            btn_save.Enabled = true;
            txt_dol.Text = hid_date.Value.ToString();
            txt_dol.Enabled = true;
            ddl_reason.SelectedValue = "0";
            btn_add.Enabled = false;
            //lbl_PWD.Visible = false;
            lbl_PWD.Text = "";
        }
        private void Fn_Educlear()
        {
            txtcode1.Text = "";
            txtname1.Text = "";

            txtmondob1.Text = "";
            txtgurop.Text = "";
            txt_EduPrecentage.Text = "";
            txt_Eduqualification.Text = "";
            txt_EduYear.Text = Convert.ToDateTime(obj_da_Log.GetDate()).ToString("dd/MM/yyyy");
            //btn_EduAdd.Text = "Add";
            btn_EduAdd.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn btn-add1";
            //ddl_EduMonrh.SelectedIndex = 0;
            Grd_Edu.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Edu.DataBind();
        }
        public void fn_edu()
        {
            txt_EduPrecentage.Text = "";
            txt_Eduqualification.Text = "";
            txt_educa.Text = "";

            txt_EduYear.Text = Convert.ToDateTime(obj_da_Log.GetDate()).ToString("dd/MM/yyyy");
            //txt_fromyear.Text = Convert.ToDateTime(obj_da_Log.GetDate()).ToString("dd/MMM/yyyy");
            //txt_toyear.Text = txt_fromyear.Text;
            //txt_EduYear.Text = txt_fromyear.Text;
            //ddl_EduMonrh.SelectedIndex = 0;
        }
        public void txtclear()
        {
            txt_Adminreport.Text = "";
            txt_Appraisal.Text = "";
            txt_Function.Text = "";
            txt_workprocess.Text = "";
            txt_reviewedby.Text = "";

            for (int i = 0; i < chkproducts.Items.Count; i++)
            {
                chkproducts.Items[i].Selected = false;
            }
        }
        private void Fn_Expclear()
        {
            txtempcode2.Text = "";
            txtname2.Text = "";
            txtmondob.Text = "";
            txtbg2.Text = "";
            txt_organisation.Text = "";
            txt_designation.Text = "";
            txt_fromyear.Text = Convert.ToDateTime(obj_da_Log.GetDate()).ToString("dd/MM/yyyy");
            txt_toyear.Text = Convert.ToDateTime(obj_da_Log.GetDate()).ToString("dd/MM/yyyy");
            txt_exper.Text = "";
            //ddl_Expto.SelectedIndex = 0;
            //btn_ExpAdd.Text = "Add";
            btn_ExpAdd.ToolTip = "Add";
            btn_add2.Attributes["class"] = "btn btn-add1";
            Grd_Exp.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Exp.DataBind();
        }
        public void fn_exp()
        {
            txt_organisation.Text = "";
            txt_designation.Text = "";
            txt_fromyear.Text = "";
            txt_toyear.Text = "";

            //ddl_Expto.SelectedIndex = 0;
        }
        private void Fn_Offclear()
        {
            txtclear();
            TextBox1.Text = "";
            TextBox2.Text = "";
            txt_bob.Text = "";
            txt_grou.Text = "";
            txt_grade.Text = "";
            txt_offqualification.Text = "";
            txt_offexp.Text = "";
            txt_extn.Text = "";
            txt_mailid.Text = "";
            ddl_division.SelectedIndex = 0;
            ddl_branch.Items.Clear();
            ddl_department.SelectedIndex = 0;
            ddl_designation.SelectedIndex = 0;
            Img_Sign.ImageUrl = "~/images/signature.JPG";

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                lbl_PWD.Visible = false;
                ddl_function.SelectedIndex = 0;
                txt_empcode.Text = "";
                txt_educa.Text = "";
                Fn_clear();
                Fn_Educlear();
                Fn_Expclear();
                Fn_Offclear();
                Fn_Loadbranch();

                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                //txt_empcode.Focus();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_empcode.Text.Trim().Length > 0)
                {
                    string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    Str_RptName = "HREmpPerDetails.rpt";
                    Str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.employeeid}=" + hid_empid.Value.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterClientScriptBlock(btn_view, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else
                {
                    string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    Str_RptName = "HREmpPerDetailsALL.rpt";
                    Str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.employeeid}<>1 and {MasterEmployee.employeeid}<>2";
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterClientScriptBlock(btn_view, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_GrdEduDetail()
        {
            if (txt_empcode.Text.Trim().Length > 0)
            {
                DataAccess.HR.Employee obj_da_HR = new DataAccess.HR.Employee();
                //DataTable obj_dt = new DataTable();
                obj_dt = obj_da_HR.selEmpDetails(txt_empcode.Text.ToUpper(), "EDU");
                Grd_Edu.DataSource = obj_dt;
                Grd_Edu.DataBind();
                Session["Grd_Edu"] = obj_dt;
                Grd_Edu.Visible = true;
            }

        }
        private void Fn_GrdExpDetail()
        {
            if (txt_empcode.Text.Trim().Length > 0)
            {
                DataAccess.HR.Employee obj_da_HR = new DataAccess.HR.Employee();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_HR.selEmpDetails(txt_empcode.Text.ToUpper(), "EXP");
                Grd_Exp.DataSource = obj_dt;
                Grd_Exp.DataBind();
                Session["Grd_Exp"] = obj_dt;
                Grd_Exp.Visible = true;
            }
        }

        protected void btn_EduAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                if (txt_empcode.Text.Trim().Length > 0)
                {
                    string[] getyuear = txt_EduYear.Text.Split('/');
                    string Str_MonthYear = getyuear[1].ToUpper() + "-" + getyuear[2];
                    if (btn_EduAdd.ToolTip == "Add")
                    {
                        obj_da_Emp.InsEmpEducation(txt_empcode.Text.ToUpper().ToUpper(), txt_Eduqualification.Text.ToUpper(), Str_MonthYear, Convert.ToDouble(txt_EduPrecentage.Text).ToString());
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 1, int.Parse(Session["LoginBranchid"].ToString()), "/A - Educational");

                        //cmd = new SqlCommand("SPInsEmpEducation", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //intEmpID = empObj.GetEmpid(txt_empcode.Text.ToUpper());
                        //cmd.Parameters.AddWithValue("@empid", intEmpID);
                        //cmd.Parameters.AddWithValue("@certificate", txt_Eduqualification.Text.ToUpper());
                        //cmd.Parameters.AddWithValue("@yop", Str_MonthYear);
                        //cmd.Parameters.AddWithValue("@percentage", Convert.ToDouble(txt_EduPrecentage.Text));
                        //cmd.CommandTimeout = 0;
                        //if (con.State == ConnectionState.Closed)
                        //{
                        //    con.Open();
                        //}
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                        fn_edu();

                        Fn_GrdEduDetail();
                        ScriptManager.RegisterClientScriptBlock(btn_EduAdd, typeof(Button), "HRM", "alertify.alert('Detail Added');", true);
                    }
                    else if (btn_EduAdd.ToolTip == "Upd")
                    {
                        obj_da_Emp.UpdEmpEducation(txt_empcode.Text.ToUpper().ToUpper(), hid_certificate.Value.ToString(), txt_Eduqualification.Text.ToUpper(), Str_MonthYear, txt_EduPrecentage.Text.ToUpper());
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 2, int.Parse(Session["LoginBranchid"].ToString()), "/U - Educational");
                        //cmd = new SqlCommand("SPUpdEmpEducation", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //intEmpID = empObj.GetEmpid(txt_empcode.Text);
                        //cmd.Parameters.AddWithValue("@empid", intEmpID);
                        //cmd.Parameters.AddWithValue("@oldcertificate", hid_certificate.Value.ToString());
                        //cmd.Parameters.AddWithValue("@newcertificate", txt_Eduqualification.Text);
                        //cmd.Parameters.AddWithValue("@yop", Str_MonthYear);
                        //cmd.Parameters.AddWithValue("@percentage", txt_EduPrecentage.Text);
                        //cmd.CommandTimeout = 0;
                        //if (con.State == ConnectionState.Closed)
                        //{
                        //    con.Open();
                        //}
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                        fn_edu();
                        Fn_GrdEduDetail();
                        ScriptManager.RegisterClientScriptBlock(btn_EduAdd, typeof(Button), "HRM", "alertify.alert('Detail Updated');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btn_EduAdd, typeof(Button), "HRM", "alertify.alert('EmpCode cant be BLANK');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //protected void Grd_Edu_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (hid_confirm.Value.ToString() == "N")
        //        {
        //            btn_EduAdd.Text = "Upd";
        //            txt_Eduqualification.Text = Grd_Edu.SelectedRow.Cells[0].Text;
        //            hid_certificate.Value = Grd_Edu.SelectedRow.Cells[0].Text;
        //            string[] Str_EduYear = Grd_Edu.SelectedRow.Cells[1].Text.ToString().Split('-');
        //            txt_EduYear.Text = Str_EduYear[1];
        //            ddl_EduMonrh.SelectedValue = Utility.fn_intMonthName(Str_EduYear[0]).ToString();
        //            txt_EduPrecentage.Text = Grd_Edu.SelectedRow.Cells[2].Text;
        //        }
        //        else if (hid_confirm.Value.ToString() == "Y")
        //        {
        //            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
        //            obj_da_Emp.DelEmpEducation(lbl_EduEmpcode.Text, Grd_Edu.SelectedRow.Cells[0].Text, Grd_Edu.SelectedRow.Cells[1].Text, Grd_Edu.SelectedRow.Cells[2].Text);
        //            Fn_Educlear();
        //            Fn_GrdEduDetail();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void btn_ExpAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                if (txt_empcode.Text.Trim().Length > 0)
                {
                    string Str_FromMonthYear, Str_ToMonthYear;

                    string[] getyuear = txt_fromyear.Text.Split('/');
                    Str_FromMonthYear = getyuear[1].ToUpper() + "-" + getyuear[2];
                    // string Str_MonthYear = getyuear[1].ToUpper() + "-" + getyuear[2];
                    getyuear = txt_toyear.Text.Split('/');
                    Str_ToMonthYear = getyuear[1].ToUpper() + "-" + getyuear[2];
                    if (btn_ExpAdd.ToolTip == "Add")
                    {
                        obj_da_Emp.InsEmpExperience(txt_empcode.Text.ToUpper(), txt_organisation.Text, Str_FromMonthYear, Str_ToMonthYear, txt_designation.Text.ToUpper());
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 1, int.Parse(Session["LoginBranchid"].ToString()), "/A - Experience");
                        //cmd = new SqlCommand("SPInsEmpExperience", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //intEmpID = empObj.GetEmpid(txt_empcode.Text);
                        //cmd.Parameters.AddWithValue("@empid", intEmpID);
                        //cmd.Parameters.AddWithValue("@orgname", txt_organisation.Text);
                        //cmd.Parameters.AddWithValue("@exfrom", Str_FromMonthYear);
                        //cmd.Parameters.AddWithValue("@exto", Str_ToMonthYear);
                        //cmd.Parameters.AddWithValue("@designation", txt_designation.Text);
                        //cmd.CommandTimeout = 0;
                        //if (con.State == ConnectionState.Closed)
                        //{
                        //    con.Open();
                        //}
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                        fn_exp();
                        Fn_GrdExpDetail();
                        ScriptManager.RegisterClientScriptBlock(btn_ExpAdd, typeof(Button), "HRM", "alertify.alert('Detail Added');", true);
                    }
                    else if (btn_ExpAdd.ToolTip == "Upd")
                    {
                        obj_da_Emp.UpdEmpExperience(txt_empcode.Text.ToUpper(), hid_organisation.Value.ToString(), txt_organisation.Text.ToUpper(), Str_FromMonthYear, Str_ToMonthYear, txt_designation.Text.ToUpper());
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 2, int.Parse(Session["LoginBranchid"].ToString()), "/U - Experience");
                        //cmd = new SqlCommand("SPUpdEmpExperience", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //intEmpID = empObj.GetEmpid(txt_empcode.Text);
                        //cmd.Parameters.AddWithValue("@empid", intEmpID);
                        //cmd.Parameters.AddWithValue("@oldorgname", hid_organisation.Value.ToString());
                        //cmd.Parameters.AddWithValue("@neworgname", txt_organisation.Text.ToUpper());
                        //cmd.Parameters.AddWithValue("@exfrom", Str_FromMonthYear);
                        //cmd.Parameters.AddWithValue("@exto", Str_ToMonthYear);
                        //cmd.Parameters.AddWithValue("@designation", txt_designation.Text.ToUpper());
                        //cmd.CommandTimeout = 0;
                        //if (con.State == ConnectionState.Closed)
                        //{
                        //    con.Open();
                        //}
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                        fn_exp();
                        Fn_GrdExpDetail();
                        ScriptManager.RegisterClientScriptBlock(btn_ExpAdd, typeof(Button), "HRM", "alertify.alert('Detail Updated');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btn_ExpAdd, typeof(Button), "HRM", "alertify.alert('EmpCode cant be BLANK');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }



        private void Fn_LoadDivision()
        {
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDivisionhrm("HR");
            ddl_division.DataSource = obj_dt;
            ddl_division.DataTextField = "divisionname";
            ddl_division.DataValueField = "divisionid";
            ddl_division.DataBind();
        }
        private void Fn_LoadDepartment()
        {
            DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDept();
            // obj_dt = da_obj_HrEmp.GetDeptFunc();
            ddl_department.DataSource = obj_dt;
            ddl_department.DataTextField = "deptname";
            ddl_department.DataBind();
        }
        private void deptfunction()
        {
            DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDeptFunc();
            ddl_function.DataSource = obj_dt;
            ddl_function.Items.Add("");
            for (int i = 0; i < obj_dt.Rows.Count; i++)
            {
                ddl_function.Items.Add(obj_dt.Rows[i]["name"].ToString());
            }
            //ddl_function.DataTextField = "name";
            //ddl_function.DataBind();
        }
        private void getfunctionid()
        {
            DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetLikefunctionname(ddl_function.SelectedItem.Text);
            if (obj_dt.Rows.Count > 0)
            {
                hid_functionid.Value = obj_dt.Rows[0]["functionid"].ToString();
            }
            else
            {
                hid_functionid.Value = "0";
            }
        }
        private void Fn_LoadDesignation()
        {
            DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDesign();
            ddl_designation.DataSource = obj_dt;
            ddl_designation.DataTextField = "designame";
            ddl_designation.DataBind();
        }
        private void Fn_Loadbranch()
        {
            ddl_branch.Items.Clear();
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            string divid = Session["LoginDivisionName"].ToString();
            obj_dt = da_obj_HrEmp.selBranchList(divid);
            if (obj_dt.Rows.Count > 0)
            {
                ddl_branch.Items.Add("");
                ddl_branch.DataSource = obj_dt;
                ddl_branch.DataTextField = "branchname";
                ddl_branch.DataBind();
            }
        }
        private void Fn_Loadrole()
        {
            chkproducts.Items.Clear();
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            // string divid = Session["LoginDivisionName"].ToString();
            obj_dt = da_obj_HrEmp.Getrolename();
            if (obj_dt.Rows.Count > 0)
            {

                chkproducts.DataSource = obj_dt;
                chkproducts.DataTextField = "rolename";
                chkproducts.DataValueField = "roleid";
                chkproducts.DataBind();
            }
        }
        private void workproccess()
        {
            dt = objproces.GetLikeprocessname();
            if (dt.Rows.Count > 0)
            {
                //chkproducts.DataSource = dt;
                //chkproducts.DataTextField = "processname";
                hid_workprocess.Value = dt.Rows[0]["Processid"].ToString();
                //chkproducts.DataValueField = "Processid";
                //hid_workprocess.Value = chkproducts.DataValueField;
                // chkproducts.DataBind();
            }
        }


        private void Get_EmpOfficialDetail()
        {
            try
            {
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Emp.selEmpDetails(txt_empcode.Text.ToUpper(), "OFF");
                if (obj_dt.Rows.Count > 0)
                {
                    ddl_division.SelectedIndex = ddl_division.Items.IndexOf(ddl_division.Items.FindByText(obj_dt.Rows[0][1].ToString().TrimEnd()));
                    Fn_Loadbranch();
                    ddl_branch.Text = obj_dt.Rows[0][2].ToString();
                    ddl_designation.Text = obj_dt.Rows[0][3].ToString();
                    ddl_department.Text = obj_dt.Rows[0][8].ToString();
                    txt_doj.Text = string.Format("{0:dd/MMM/yyyy}", DateTime.Parse(obj_dt.Rows[0]["doj"].ToString()));
                    txt_grade.Text = obj_dt.Rows[0][4].ToString();
                    txt_mailid.Text = obj_dt.Rows[0][6].ToString();
                    txt_extn.Text = obj_dt.Rows[0][7].ToString();
                    txt_offqualification.Text = obj_dt.Rows[0][9].ToString();
                    txt_offexp.Text = obj_dt.Rows[0][10].ToString();
                    //txt_pwd.Text = obj_dt.Rows[0]["pwd"].ToString();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string Str_Date;
            DateTime dt_DOJ;
            string Str_Month;
            string Str_Pwd;
            try
            {
                if (txt_empcode.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Employee Code');", true);
                    return;
                }
                if (txt_mobile.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Mobile #');", true);
                    return;
                }
                if (txt_mailid.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Email');", true);
                    return;
                }
                if (ddl_process.SelectedItem.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Select the Work Process');", true);
                    return;
                }


                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();


                if (lbl_OffEmpcode.Text.Trim().Length > 0)
                {
                    byte[] Img_Length = new byte[0];
                    DataTable obj_dt = new DataTable();
                    if (Session["sign"] != null)
                    {
                        obj_dt = (DataTable)Session["sign"];
                        if (obj_dt.Rows.Count > 0)
                        {
                            Img_Length = ((byte[])obj_dt.Rows[0][0]);
                        }
                    }
                    if (txt_doj.Text == "")
                    {

                        dt_DOJ = Convert.ToDateTime(Utility.fn_ConvertDate("01/01/2016"));
                        Str_Month = dt_DOJ.Month.ToString().Length == 1 ? "0" + dt_DOJ.Month.ToString() : dt_DOJ.Month.ToString();
                        // Str_Pwd = lbl_OffEmpcode.Text + Str_Month + dt_DOJ.Year.ToString();
                        Str_Pwd = txt_empcode.Text.ToUpper() + Str_Month + dt_DOJ.Year.ToString();
                    }
                    else
                    {
                        //Str_Date = Fn_DOBDateFormate(txt_doj.Text);
                        Str_Date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_doj.Text)).ToShortDateString();
                        dt_DOJ = Convert.ToDateTime(Str_Date);
                        Str_Month = dt_DOJ.Month.ToString().Length == 1 ? "0" + dt_DOJ.Month.ToString() : dt_DOJ.Month.ToString();
                        // Str_Pwd = lbl_OffEmpcode.Text + Str_Month + dt_DOJ.Year.ToString();
                        Str_Pwd = txt_empcode.Text.ToUpper() + Str_Month + dt_DOJ.Year.ToString();
                    }

                    string div = Session["LoginDivisionName"].ToString();
                    obj_da_Emp.UpdEmpOfficial(txt_empcode.Text.ToUpper(), div, ddl_branch.SelectedItem.Text, ddl_designation.SelectedItem.Text,
                        ddl_department.SelectedItem.Text, txt_grade.Text, dt_DOJ, txt_mailid.Text, txt_extn.Text, Str_Pwd, txt_offqualification.Text, txt_offexp.Text, Img_Length);

                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 2, int.Parse(Session["LoginBranchid"].ToString()), "/U - Official");
                    /* cmd = new SqlCommand("SPUpdEmpOfficial", con);

                      cmd.CommandType = CommandType.StoredProcedure;
                      intPortID = prtObj.GetNPortid(ddl_branch.SelectedItem.Text);
                      intDivisionID = HREmpobj.GetDivisionId(ddl_division.SelectedItem.Text);
                      intDesigID = empObj.GetDesgnid(ddl_designation.SelectedItem.Text);
                      intDeptID = empObj.GetDeptid(ddl_department.SelectedItem.Text);
                      cmd.Parameters.AddWithValue("@empcode", txt_empcode.Text);
                      cmd.Parameters.AddWithValue("@division", intDivisionID);
                      cmd.Parameters.AddWithValue("@branch", intPortID);
                      cmd.Parameters.AddWithValue("@desigid", intDesigID);
                      cmd.Parameters.AddWithValue("@deptid", intDeptID);
                      cmd.Parameters.AddWithValue("@grade", txt_grade.Text);
                      cmd.Parameters.AddWithValue("@doj", dt_DOJ);
                      cmd.Parameters.AddWithValue("@offmailid", txt_mailid.Text);
                      cmd.Parameters.AddWithValue("@extensionno", txt_extn.Text);
                      cmd.Parameters.AddWithValue("@pwd", Str_Pwd);
                      cmd.Parameters.AddWithValue("@qualification", txt_offqualification.Text);
                      cmd.Parameters.AddWithValue("@experience", txt_offexp.Text);
                      cmd.Parameters.AddWithValue("@sign", Img_Length);

                      strpwd = logobj.Decrypt(strpwd, Convert.ToInt32(int_Empid).ToString());
                      cmd.CommandTimeout = 0;
                      if (con.State == ConnectionState.Closed)
                      {
                          con.Open();
                      }
                      cmd.ExecuteNonQuery();
                      con.Close();*/
                    //   txt_empcode_TextChanged(sender, e);

                    //ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "HRM", "alertify.alert('EmpCode cant be BLANK');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //public void update()
        //{  
        //    if(txt_empcode.Text!="")
        //    {
        //        dt = HREmpobj.getupdateempdatail(Convert.ToInt32(txt_empcode.Text), txt_Adminreport.Text.ToString(), txt_Function.Text.ToString(), txt_Appraisal.Text.ToString(), ddl_workproces.SelectedItem.Text.ToString());
        //        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 172, 2, int.Parse(Session["LoginBranchid"].ToString()), "/U - Official");
        //        cmd = new SqlCommand("SPUpdEmpOfficial", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@employeeid", txt_empcode.Text);
        //        cmd.Parameters.AddWithValue("@adminreporting", txt_Adminreport.Text);
        //        cmd.Parameters.AddWithValue("@functionalreporting", txt_Function.Text);
        //        cmd.Parameters.AddWithValue("@appraisallyby", txt_Appraisal.Text);
        //        cmd.Parameters.AddWithValue("@workprocess", ddl_workproces.SelectedItem.Text);
        //    }

        //}

        protected void txt_name_TextChanged(object sender, EventArgs e)
        {
            if (hid_empname.Value == "" || hid_empname.Value != "0")
            {
                txt_empcode.Text = hid_empname.Value;
                txt_empcode_TextChanged(sender, e);
                txt_fathername.Focus();

            }

        }

        protected void LinkEdu1_Click(object sender, EventArgs e)
        {

            Fn_GrdEduDetail();

            if (Grd_Edu.Rows.Count > 0)
            {
                this.popup_Grd.Show();
                Grd_Exp.Visible = false;
                Grd_Edu.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(LinkEdu1, typeof(LinkButton), "JobInfo", "alertify.alert('Education Details Not Available');", true);
                return;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Fn_GrdExpDetail();
            if (Grd_Exp.Rows.Count > 0)
            {

                this.popup_Grd.Show();
                Grd_Exp.Visible = true;
                Grd_Edu.Visible = false;

            }
            else
            {
                ScriptManager.RegisterStartupScript(LinkButton1, typeof(LinkButton), "JobInfo", "alertify.alert('Exprience Details Not Available');", true);
                return;
            }


        }

        protected void Grd_Edu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                txt_Eduqualification.Text = Grd_Edu.SelectedRow.Cells[0].Text;
                hid_certificate.Value = Grd_Edu.SelectedRow.Cells[0].Text;
                string edu = Grd_Edu.SelectedRow.Cells[1].Text.Replace("-", "/");
                txt_EduYear.Text = "01" + "/" + edu;
                //string[] Str_EduYear = Grd_Edu.SelectedRow.Cells[1].Text.ToString().Split('-');
                //txt_EduYear.Text = Str_EduYear[1];
                //ddl_EduMonrh.SelectedValue = Utility.fn_intMonthName(Str_EduYear[0]).ToString();
                txt_EduPrecentage.Text = Grd_Edu.SelectedRow.Cells[2].Text;
                //btn_EduAdd.Text = "Upd";
                btn_EduAdd.ToolTip = "Upd";
                btn_add1.Attributes["class"] = "btn btn-upd1";



            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Exp_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {



                txt_organisation.Text = Grd_Exp.SelectedDataKey.Values[0].ToString();
                hid_organisation.Value = Grd_Exp.SelectedDataKey.Values[0].ToString();
                txt_designation.Text = Grd_Exp.SelectedRow.Cells[3].Text;
                string fromyear = Grd_Exp.SelectedRow.Cells[1].Text.Replace("-", "/");
                txt_fromyear.Text = "01" + "/" + fromyear;
                string toyear = Grd_Exp.SelectedRow.Cells[2].Text.Replace("-", "/");
                txt_toyear.Text = "01" + "/" + toyear;
                //string[] Str_ExpYear = Grd_Exp.SelectedRow.Cells[1].Text.ToString().Split('-');
                //txt_fromyear.Text = Str_ExpYear[1];
                //ddl_Expfrom.SelectedValue = Utility.fn_intMonthName(Str_ExpYear[0]).ToString();
                //Str_ExpYear = Grd_Exp.SelectedRow.Cells[2].Text.ToString().Split('-');
                //txt_toyear.Text = Str_ExpYear[1];
                //ddl_Expto.SelectedValue = Utility.fn_intMonthName(Str_ExpYear[0]).ToString();
                //btn_ExpAdd.Text = "Upd";
                btn_ExpAdd.ToolTip = "Upd";
                btn_add2.Attributes["class"] = "btn btn-upd1";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //protected void txtReportingto_TextChanged(object sender, EventArgs e)
        //{
        //    if (IsNumeric(txtReportingto.Text)==false)
        //    {

        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(LinkButton1, typeof(LinkButton), "JobInfo", "alertify.alert('Enter Character Only...');", true);
        //    }
        //}

        public bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        protected void txt_Appraisal_TextChanged(object sender, EventArgs e)
        {

            int employeeid = empObj.GetNEmpid(txt_Appraisal.Text.ToUpper());

            if (employeeid != 0 && hid_appraisal.Value != "0")
            {
                hid_appraisal.Value = employeeid.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Appraisal Name');", true);
                txt_Appraisal.Focus();
                txt_Appraisal.Text = "";
                return;
            }

            if ((txt_Appraisal.Text != txt_Function.Text) && (txt_Appraisal.Text != txt_Adminreport.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Admin report (OR) Functional report name');", true);
                txt_Appraisal.Text = "";
                return;
            }
        }

        protected void ddl_workproces_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable obj_dt = new DataTable();
            //workproccess();
            //obj_dt = objproces.GetLikeprocessid(ddl_workproces.SelectedItem.Text);
            //if (obj_dt.Rows.Count>0)
            //{   
            //    hid_workprocess.Value = dt.Rows[0]["processid"].ToString();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Workprocess Name');", true);
            //    ddl_workproces.Focus();
            //    ddl_workproces.Text = "";
            //    return;
            //}
            //string name="";

            //foreach (ListItem item in ddl_workproces.Items)
            //{  
            //    if(item.Selected)
            //    {
            //        name += item.Text + "" + item.Value + "\\n";    
            //    }

            //}

            //ddl_workproces.SelectedItem.Text = name;

        }

        protected void txt_Function_TextChanged(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();

            int employeeid = empObj.GetNEmpid(txt_Function.Text.ToUpper());

            if (employeeid != 0 && hid_functionalreport.Value != "0")
            {
                hid_functionalreport.Value = employeeid.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Function Report Name');", true);
                txt_Function.Focus();
                txt_Function.Text = "";
                return;
            }
        }

        protected void txt_Adminreport_TextChanged(object sender, EventArgs e)
        {
            int employeeid = empObj.GetNEmpid(txt_Adminreport.Text.ToUpper()); ;
            if (employeeid != 0 && hid_adminreport.Value != "0")
            {
                hid_adminreport.Value = employeeid.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Admin Report Name');", true);
                txt_Adminreport.Focus();
                txt_Adminreport.Text = "";
                return;
            }
        }

        protected void chkproducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);
            if (index == 0)
            {
                if (chkproducts.Items[0].Selected == true)
                {
                    for (int i = 0; i < chkproducts.Items.Count; i++)
                    {
                        if (chkproducts.Items[i].Text != "SELECT ALL")
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
                if (chkproducts.Items[i].Text != "SELECT ALL")
                {
                    if (chkproducts.Items[i].Selected)
                    {
                        name += chkproducts.Items[i].Text + ",";
                    }
                }
            }
            txt_workprocess.Text = name;
        }

        protected void txt_reviewedby_TextChanged(object sender, EventArgs e)
        {
            int employeeid = empObj.GetNEmpid(txt_reviewedby.Text.ToUpper()); ;
            if (employeeid != 0 && hid_reviewedby.Value != "0")
            {
                hid_reviewedby.Value = employeeid.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Reviewed Name');", true);
                txt_reviewedby.Focus();
                txt_reviewedby.Text = "";
                return;
            }
        }

        protected void Grd_Exp_RowDataBound(object sender, GridViewRowEventArgs e)
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
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Expdelete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Exp, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Edu_RowDataBound(object sender, GridViewRowEventArgs e)
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
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Edudelete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Edu, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }



        //protected void btn_delete_Click(object sender, EventArgs e)
        //{
        //    if (btnedu_delete.Text == "Delete")
        //    {
        //        DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
        //        obj_da_Emp.DelEmpExperience(txt_empcode.Text, Grd_Exp.SelectedDataKey.Values[0].ToString(), Grd_Exp.SelectedRow.Cells[1].Text, Grd_Exp.SelectedRow.Cells[2].Text, Grd_Exp.SelectedRow.Cells[3].Text);
        //        Fn_Expclear();
        //        Fn_GrdExpDetail();
        //        btn_ExpAdd.Text = "Add";
        //        ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Successfully Deteted');", true);
        //    }
        //}

        //protected void btnedu_delete_Click(object sender, EventArgs e)
        //{    

        //         if(btnedu_delete.Text=="Delete")
        //         {
        //             DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
        //             obj_da_Emp.DelEmpEducation(txt_empcode.Text, Grd_Edu.SelectedRow.Cells[0].Text, Grd_Edu.SelectedRow.Cells[1].Text, Grd_Edu.SelectedRow.Cells[2].Text);
        //             Fn_Educlear();
        //             Fn_GrdEduDetail();
        //             btn_EduAdd.Text = "Add";
        //             ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Successfully Deteted');", true);
        //         }



        //}

        protected void Grd_Exp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                ImageButton Img_Expdelete = (ImageButton)e.CommandSource;
                GridViewRow grd = (GridViewRow)Img_Expdelete.NamingContainer;
                obj_dt = (DataTable)Session["Grd_Exp"];
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                obj_da_Emp.DelEmpExperience(txt_empcode.Text.ToUpper(), obj_dt.Rows[grd.RowIndex][0].ToString(), obj_dt.Rows[grd.RowIndex][1].ToString(), obj_dt.Rows[grd.RowIndex][2].ToString(), obj_dt.Rows[grd.RowIndex][3].ToString());
                Fn_Expclear();
                Fn_GrdExpDetail();
                //btn_ExpAdd.Text = "Add";
                btn_ExpAdd.ToolTip = "Add";
                btn_add2.Attributes["class"] = "btn btn-add1";
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Successfully Deteted');", true);
            }
        }

        protected void Grd_Edu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                ImageButton Img_Edudelete = (ImageButton)e.CommandSource;
                GridViewRow grd = (GridViewRow)Img_Edudelete.NamingContainer;
                obj_dt = (DataTable)Session["Grd_Edu"];
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                obj_da_Emp.DelEmpEducation(txt_empcode.Text.ToUpper(), obj_dt.Rows[grd.RowIndex]["certificate"].ToString(), obj_dt.Rows[grd.RowIndex]["yop"].ToString(), obj_dt.Rows[grd.RowIndex]["percentage"].ToString());
                //obj_da_Emp.DelEmpEducation(hid_empid.Value, Grd_Edu.SelectedRow.Cells[0].Text, Grd_Edu.SelectedRow.Cells[1].Text, Grd_Edu.SelectedRow.Cells[2].Text);
                Fn_Educlear();
                Fn_GrdEduDetail();
                //btn_EduAdd.Text = "Add";
                btn_EduAdd.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn btn-add1";
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Successfully Deteted');", true);
            }
        }

        protected void Grd_Exp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grd_Edu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ddl_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            getfunctionid();
        }

        protected void chkproduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void txt_mailid_TextChanged(object sender, EventArgs e)
        {
            string mail = txt_mailid.Text;
            // Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex regex = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            Match match = regex.Match(mail);
            if (!match.Success)
            {
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('is Valid Email Address');", true);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('is Invalid Email Address');", true);
                txt_mailid.Text = "";
                txt_mailid.Focus();
                return;
            }

        }

        protected void txt_email_TextChanged(object sender, EventArgs e)
        {
            if (txt_email.Text != "")
            {
                string mail = txt_email.Text;
                // Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Regex regex = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                Match match = regex.Match(mail);
                if (!match.Success)
                {
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('is Valid Email Address');", true);

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('is Invalid Email Address');", true);
                    txt_email.Text = "";
                    txt_email.Focus();
                    return;
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 172, "Job", "", "", Session["StrTranType"].ToString());

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

        protected void link_cust_Click(object sender, EventArgs e)
        {
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();

            DataTable dtexecel = new DataTable();
            dtexecel = obj_da_Emp.Getemplistdetails();
            //dtexecel = (DataTable)ViewState["GrdCount"];
            if (dtexecel.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtexecel, "Status");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Employeelist.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

        }


        protected void ddl_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            int processid = 0;
            if (ddl_process.SelectedItem.Text == "Air Exports")
            {
                processid = 9;
            }
            else if (ddl_process.SelectedItem.Text == "Air Imports")
            {
                processid = 10;
            }
            else if (ddl_process.SelectedItem.Text == "Ocean Exports")
            {
                processid = 7;
            }
            else if (ddl_process.SelectedItem.Text == "Ocean Imports")
            {
                processid = 8;
            }
            else if (ddl_process.SelectedItem.Text == "Financial Accounts")
            {
                processid = 21;
            }
            else if (ddl_process.SelectedItem.Text == "Maintenance")
            {
                processid = 19;
            }
            else if (ddl_process.SelectedItem.Text == "MIS & Analytics")
            {
                processid = 18;
            }
            else if (ddl_process.SelectedItem.Text == "Sales")
            {
                processid = 2;
            }
        }

        protected void btn_imgupload_Click(object sender, EventArgs e)
        {
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
                        Session["img"] = dt;
                        string base64String = Convert.ToBase64String(postfile1);
                        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image Size Does not Exist 50kb');", true);
                    //img_upload.Attributes.Clear();
                    return;
                }
            }
        }

        protected void btn_signupload_Click(object sender, EventArgs e)
        {
            if (sign_upload.HasFile && sign_upload.PostedFile != null)
            {
                string Str_FileExt = System.IO.Path.GetExtension(sign_upload.FileName).ToUpper();
                int filesize = sign_upload.PostedFile.ContentLength / 1024;
                if (filesize < 50 && filesize != 0)
                {

                    if (Str_FileExt == ".JPEG" || Str_FileExt == ".JPG" || Str_FileExt == ".GIF" || Str_FileExt == ".PNG" || Str_FileExt == ".BMP" || Str_FileExt == ".PNG")
                    {
                        dt.Clear();
                        postfile1 = pstFile(sign_upload);
                        dr = dt.NewRow();
                        dt.Columns.Add("image", Type.GetType("System.Byte[]"));
                        dr["image"] = postfile1;
                        dt.Rows.Add(dr);
                        Session["sign"] = dt;
                        string base64String = Convert.ToBase64String(postfile1);
                        Img_Sign.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                        blr = true;
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image Size Does not Exist 50kb');", true);
                    //sign_upload.Attributes.Clear();
                    blr = true;
                    return;
                }
            }
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
                DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();

                DateTime dt_DOL = DateTime.Parse(Utility.fn_ConvertDate(txt_dol.Text));

                obj_da_Employee.UpdReleave(txt_empcode.Text.ToUpper(), dt_DOL, int.Parse(ddl_reason.SelectedValue.ToString()));
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 175, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_empcode.Text.ToUpper() + "-" + txt_dol.Text + "/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);

            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

    }
}