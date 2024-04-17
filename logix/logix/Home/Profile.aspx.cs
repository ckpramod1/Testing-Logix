using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logix;

namespace logix.Home
{
    public partial class Profile : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterEmployee EmpObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Payroll.Details objdet = new DataAccess.Payroll.Details();
        DataAccess.HR.Employee emp = new DataAccess.HR.Employee();
        DataAccess.HR.Attendance AttendObj = new DataAccess.HR.Attendance();
        DataAccess.UserPermission menuobj = new DataAccess.UserPermission();
        DataAccess.HR.CompanyProfile profileobj = new DataAccess.HR.CompanyProfile();
        DataAccess.Payroll.LWF da_obj_LWF = new DataAccess.Payroll.LWF();
        DataAccess.HR.Attendance objHr = new DataAccess.HR.Attendance();
        DataAccess.HR.Appraisal AppraObj = new DataAccess.HR.Appraisal();
 
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable DtRgt = new DataTable();
        DataTable dtmod = new DataTable();
        DataTable dtp = new DataTable();
        DataTable dtdtls = new DataTable();
        DataSet dsemp = new DataSet();
        DataTable DtEmpNew = new DataTable();
        DataTable dtNewTemp = new DataTable();
        DataTable dtcom = new DataTable();
        // Double clbal, slbal, elbal;
        int fmonth;
        int index;
        int year;
        // string claimtype;
        Boolean bolerr;
        //int fmonth;
        int empidnew;
        string EmployId, name;
        int empid;
        bool blrrr;
        string claimtype, status;
        Double lbal, slbal, elbal, clbal;
        Double cltaken, sltaken, eltaken;

        DataAccess.Payroll.Details obj_da_detail = new DataAccess.Payroll.Details();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();


        public static double BASIC = 0, RentPaid = 0, RP = 0, ARP = 0;
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        int fyear, eid, curyear, curmonth, getmonth;
        double basicamt;
        DateTime DtForm, DtTo, dtdate;
        DataTable obj_dt = new DataTable();
        DataRow foundrow;
        DataTable dtemp = new DataTable();

        string itype;
        int totwage, weigt, wage;
        int oldtage;
        int j;
        string oldcname = "", oldkname = "";
        Boolean weightkpi;
        string delkpi;
        bool err;
        protected void Page_Load(object sender, EventArgs e)
        {

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_SaveInv, btn_Viewinv, null);
            }
            if (Session["StrTranType"] == null)
            {
                Session["StrTranType"] = "";

            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            Grdlve.DataSource = new DataTable();
            Grdlve.DataBind();
            GridPermission.DataSource = new DataTable();
            GridPermission.DataBind();
            if (!IsPostBack)
            {
                hid_Date.Value = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                int id;
                string name;
                //link_right_Click(sender, e);
                //link_work_Click(sender, e);
                //Fn_TabClick(div_right, panel_right);

                GrdRights.DataSource = new DataTable();
                GrdRights.DataBind();
                grdwork.DataSource = new DataTable();
                grdwork.DataBind();
                getdata();
                txt_Weightage.Attributes.Add("onKeyPress", "return IntegerCheck(event,'Weightage')");
                fillmonth();
                txtLeaveRequired.Attributes.Add("OnKeypress", "return validateFloatKeyPress(this,event,'LeaveRequired')");
                txt_year.Text = (logobj.GetDate().Year).ToString();
                txt_Empcode.Text = Session["LoginUserName"].ToString();
                fmonth = (logobj.GetDate()).Month;
                string empid = Session["LoginEmpId"].ToString();
                cmbyear.SelectedIndex = fmonth;
                dtp = profileobj.GetWorkDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(empid));
                grdwork.DataSource = dtp;
                grdwork.DataBind();
                for (int i = 1; i <= 12; i++)
                {
                    cmb_month.Items.Add(Convert.ToDateTime(i.ToString() + "/1/2010").ToString("MMMM"));
                    cmd_tomonth.Items.Add(Convert.ToDateTime(i.ToString() + "/1/2010").ToString("MMMM"));
                }
                int d = (logobj.GetDate()).Month;
                cmb_month.Text = Convert.ToDateTime(d.ToString() + "/1/2010").ToString("MMMM");
                cmd_tomonth.Text = Convert.ToDateTime(d.ToString() + "/1/2010").ToString("MMMM");
                txt_toyear.Text = (logobj.GetDate().Year).ToString();
                txt_fromyear.Text = (logobj.GetDate().Year).ToString();

                ddl_Year.Enabled = false;
                fillyear();
                GridDataAllBind();
                Fn_LoadDYear();
                Grd.DataSource = new DataTable();
                Grd.DataBind();

                empdetail();
             
                fillalldts();
               

                btnsave.Visible = true;
                btnApproved.Visible = false;
                btnDeclaine.Visible = false;
                txtApprovedBy.Visible = false;
                txtApprovedon.Visible = false;
                // lbl_lnkrate.Visible = false;
                lblApprovedBy.Visible = false;
                hid_Date.Value = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                txtDate.Text = hid_Date.Value;
                txtFrom.Text = hid_Date.Value;
                txtTo.Text = hid_Date.Value;
                txtApprovedon.Text = hid_Date.Value;
                txtPreperedBy.Text = Session["LoginEmpName"].ToString();
                Get_EmpDetails();
                txtLeaveRequired.Focus();


                // if (itype == "HR" || itype == "" || itype == null)
                if (itype == "HR")
                {

                    ddl_Year.Enabled = true;
                    txt_Empcode.ReadOnly = false;
                    fyear = Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(0, 4));
                    lnk_section.Visible = false;
                    lbl_AvailableLimit.Visible = false;
                    lbl_MaxLimit.Visible = false;
                    txt_ActualRent.ReadOnly = false;
                    txt_Income.ReadOnly = false;
                    btn_Confirm.Enabled = true;
                    btn_Confirm.ForeColor = System.Drawing.Color.White;
                    btn_SaveInv.Enabled = true;
                    btn_SaveInv.ForeColor = System.Drawing.Color.White;
                    txt_ActualRent.ReadOnly = false;

                }
                else
                {
                    lnk_section.Visible = true;
                    lbl_AvailableLimit.Visible = true;
                    lbl_MaxLimit.Visible = true;
                    txt_ActualRent.ReadOnly = true;
                    txt_Empcode.ReadOnly = true;
                    txt_ActualRent.Focus();
                    int fd, td, mm;
                    fd = logobj.GetDate().Day;
                    mm = logobj.GetDate().Month;
                    td = 19;


                    if (fd <= 19)
                    {
                        if (mm == 12 || mm == 1 || mm == 2 || mm == 3)
                        {
                            btn_SaveInv.Enabled = false;
                            btn_SaveInv.ForeColor = System.Drawing.Color.Gray;
                            txt_ActualRent.ReadOnly = true;
                            txt_ActualRent.BackColor = System.Drawing.Color.White;
                            txt_Income.ReadOnly = true;
                            txt_Income.BackColor = System.Drawing.Color.White;
                            btn_Confirm.Enabled = false;
                            btn_Confirm.ForeColor = System.Drawing.Color.Gray;
                            int vou = Convert.ToInt32(Session["Vouyear"].ToString()) + 1;
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('IT - Declaration has closed for the finance year" + Convert.ToInt32(Session["Vouyear"].ToString()) + "-" + vou + " .Kindly Contact HR Department');", true);
                        }
                        else
                        {
                            btn_SaveInv.Enabled = true;
                            btn_SaveInv.ForeColor = System.Drawing.Color.White;
                            txt_ActualRent.ReadOnly = false;
                            txt_Income.ReadOnly = false;
                            btn_Confirm.Enabled = true;
                            btn_Confirm.ForeColor = System.Drawing.Color.White;
                        }
                    }
                    else
                    {
                        btn_SaveInv.Enabled = false;
                        btn_SaveInv.ForeColor = System.Drawing.Color.Gray;
                        txt_ActualRent.ReadOnly = false;
                        txt_Income.ReadOnly = false;
                        btn_Confirm.Enabled = false;
                        btn_Confirm.ForeColor = System.Drawing.Color.Gray;
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('You can update your investment plan between 1st and 19th of every month');", true);
                    }

                    int int_Empid1 = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    hid_Empid.Value = int_Empid1.ToString();
                    obj_dt = obj_da_detail.GetEmpDetails(int_Empid1);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_name.Text = obj_dt.Rows[0]["empname"].ToString();
                        txt_Empcode.Text = obj_dt.Rows[0]["username"].ToString();
                        //  txt_company.Text = obj_dt.Rows[0]["branchname"].ToString();
                        txt_dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                        txt_desg.Text = obj_dt.Rows[0]["designame"].ToString();
                        txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                        txt_doj.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["doj"].ToString());

                        var Result = obj_dt.AsEnumerable().Where(row => row.Field<Int16>("branch") == int.Parse("11315") ||
                            row.Field<Int16>("branch") == int.Parse("11288") ||
                            row.Field<Int16>("branch") == int.Parse("11312") ||
                            row.Field<Int16>("branch") == int.Parse("11289") ||
                            row.Field<Int16>("branch") == int.Parse("13906")).ToList();
                        if (Result.Count > 0)
                        {
                            hid_Amount.Value = "50";
                        }
                        else
                        {
                            hid_Amount.Value = "40";
                        }
                        Fn_LoadDLL();
                        Fn_Loadplan();
                        Fn_FillGrd();
                        Fn_GetIncomeDetail();
                        Fn_GetAmountDetail();
                    }

                }

                if (txt_Empcode.Text.TrimEnd().Length > 0)
                {
                    Fn_GetDetail();
                    btn_cancelinv.Text = "Cancel";
                }

                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                dtcom = da_obj_Employee.GetAppraisalEnable(year);
                if (dtcom.Rows.Count > 0)
                {
                    if (dtcom.Rows[0]["Enabledon"].ToString() != "" )
                    {
                        dtemp = da_obj_Employee.GetEmpAppraisalEnable(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                        if(dtemp.Rows.Count > 0 )
                        {
                            btnappraisal.Visible = true;
                        }
                        else
                        {
                            btnappraisal.Visible = false;
                        }
                    }
                    else
                    {
                        btnappraisal.Visible = false;
                        //btnappraisal.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                else
                {
                    btnappraisal.Visible = false;
                }
            }


            txtPhone.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

        }


        public void grdright()
        {
            int empid = Convert.ToInt32(Session["LoginEmpId"]);
            int branchid = Convert.ToInt32(Session["LoginBranchid"]);
            dsemp = menuobj.GetEmpRgt(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]));
            dtmod = dsemp.Tables[0];
            DtRgt = dsemp.Tables[1];
            DataTable dat2 = new DataTable();
            dat2.Columns.Add("pro");
            dat2.Columns.Add("menu");
            dat2.Columns.Add("screen");
            dat2.Columns.Add("btnsave");
            dat2.Columns.Add("btnview");
            dat2.Columns.Add("btndel");
            dat2.Columns.Add("btnupd");
            DataRow ro;
            if (dtmod.Rows.Count != 0)
            {
                for (int k = 0; k < DtRgt.Rows.Count; k++)
                {
                    ro = dat2.NewRow();
                    dat2.Rows.Add();
                    dat2.Rows[k]["pro"] = DtRgt.Rows[k]["pro"];
                    dat2.Rows[k]["menu"] = DtRgt.Rows[k]["menu"];
                    dat2.Rows[k]["screen"] = DtRgt.Rows[k]["screen"];
                    dat2.Rows[k]["btnsave"] = DtRgt.Rows[k]["btnsave"];
                    dat2.Rows[k]["btnview"] = DtRgt.Rows[k]["btnview"];
                    dat2.Rows[k]["btndel"] = DtRgt.Rows[k]["btndel"];
                    dat2.Rows[k]["btnupd"] = DtRgt.Rows[k]["btnupd"];
                }
                GrdRights.DataSource = dat2;
                GrdRights.DataBind();
            }
        }
        public void fillmonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                cmbyear.Items.Add(Convert.ToDateTime(i.ToString() + "/1/2011").ToString("MMMM"));
            }
        }

        //public void Fn_TabClick(System.Web.UI.HtmlControls.HtmlGenericControl Str_Ctrl, Panel Str_Pln = null)
        //{
        //    List<System.Web.UI.HtmlControls.HtmlGenericControl> Str_lst = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();
        //    List<Panel> Str_Plnlst = new List<Panel>();
        //    Str_lst.Add(div_right);
        //    Str_lst.Add(div_work);
        //   // Str_Plnlst.Add(panel_right);
        //    Str_Plnlst.Add(panel_work);
        //    Str_Ctrl.Attributes["class"] = "div_TabClick";
        //    Str_Pln.Visible = true;
        //    Str_lst.Remove(Str_Ctrl);
        //    Str_Plnlst.Remove(Str_Pln);

        //    for (int i = 0; i <= Str_lst.Count - 1; i++)
        //    {



        //        Str_lst[i].Attributes["class"] = "TabNormal";
        //    }
        //    for (int i = 0; i <= Str_Plnlst.Count - 1; i++)
        //    {
        //        Str_Plnlst[i].Visible = false;
        //    }
        //}
        public void getdata()
        {
            //dt = EmpObj.GetEmployeeDetails(Convert.ToInt32(Session["LoginUserName"]).ToString());

            dt = EmpObj.GetEmployeeDetails(Session["LoginUserName"].ToString());

            string EMPID = Session["LoginUserName"].ToString();
            dt = EmpObj.GetEmployeeDetails(EMPID);
            txt_name.Text = dt.Rows[0]["empname"].ToString();
            //txt_company.Text = dt.Rows[0]["company"].ToString();
            txt_Address.Text = dt.Rows[0]["addressp"].ToString();

            txt_doj.Text = dt.Rows[0]["DOJ"].ToString();
            txt_doc.Text = dt.Rows[0]["DOC"].ToString();
            txt_mobile.Text = dt.Rows[0]["phonehp"].ToString();
            txt_ph.Text = dt.Rows[0]["phoneres"].ToString();
            txt_email.Text = dt.Rows[0]["offmailid"].ToString();

            if (string.IsNullOrEmpty(dt.Rows[0]["aadharno"].ToString()) != true)
            {
                txt_addorno.Text = dt.Rows[0]["aadharno"].ToString();
            }
            else
            {
                txt_addorno.Text = "";
            }
            if (string.IsNullOrEmpty(dt.Rows[0]["panno"].ToString()) != true)
            {
                txt_panno.Text = dt.Rows[0]["panno"].ToString();
            }
            else
            {
                txt_panno.Text = "";
            }
            if (string.IsNullOrEmpty(dt.Rows[0]["UANno"].ToString()) != true)
            {
                txt_uanno.Text = dt.Rows[0]["UANno"].ToString();
            }
            else
            {
                txt_uanno.Text = "";
            }

            if (!DBNull.Value.Equals(dt.Rows[0]["empphoto"]))
            {
                DataTable obj_dtimg = new DataTable();
                DataRow dr;
                dr = obj_dtimg.NewRow();
                obj_dtimg.Columns.Add("image", Type.GetType("System.Byte[]"));
                Byte[] empimage = (byte[])(dt.Rows[0]["empphoto"]);
                dr["image"] = empimage;
                obj_dtimg.Rows.Add(dr);
                Session["dt"] = obj_dtimg;
                string base64String = Convert.ToBase64String(empimage);
                Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                //Img_Emp.ImageUrl = "../imgEmp.aspx";
            }
            dt = emp.SelForPermission(Session["LoginUserName"].ToString());
            if (dt.Rows.Count != 0)
            {
                hiddbranch.Value = dt.Rows[0]["portname"].ToString();
                txt_company.Text = dt.Rows[0]["divisionname"].ToString();
                txt_company.Text = txt_company.Text.Trim() + " / " + hiddbranch.Value;
                txt_dept.Text = dt.Rows[0]["deptname"].ToString();
                txt_desg.Text = dt.Rows[0]["designame"].ToString();

            }
            attendence();

           // loadGrdM();

            loadGrdL();
            Emppermission();
            leavebalance();

        }
        public void attendence()
        {
            DataTable data = new DataTable();
            int intempid = Convert.ToInt32(Session["LoginEmpId"].ToString()); //Convert.ToInt32(Session["LoginUserName"].ToString());

            dt = AttendObj.GetFNAttendence(intempid);
            DateTime atdate1, atdate2;
            dt2 = AttendObj.GetFNAttendence(intempid);
            data.Columns.Add("AttendenceDate");
            data.Columns.Add("ForeNoon");
            data.Columns.Add("AfterNoon");
            DataRow row;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = data.NewRow();
                data.Rows.Add();
                data.Rows[i]["AttendenceDate"] = dt.Rows[i]["AttendenceDate"];
                data.Rows[i]["ForeNoon"] = dt.Rows[i]["ForeNoon"];
                data.Rows[i]["AfterNoon"] = dt.Rows[i]["AfterNoon"];
            }
            GridAttende.DataSource = data;
            GridAttende.DataBind();
        }

        protected void GridDataAllBind()
        {
            float newval;
            DateTime data, datanew1;
            hid_Empid.Value = Session["LoginEmpId"].ToString();
            int id;
            DataTable dataTemp = new DataTable();
            DtEmpNew = da_obj_LWF.SpGetApproveNewDetails(Convert.ToInt32(hid_Empid.Value));
            if (DtEmpNew.Rows.Count > 0)
            {

                // DataTable dataTemp = new DataTable();
                dataTemp.Columns.Add("Empid");
                dataTemp.Columns.Add("fromdate");
                dataTemp.Columns.Add("todate");
                // dataTemp.Columns.Add("designation");
                dataTemp.Columns.Add("leaverequired");
                dataTemp.Columns.Add("purpose");
                dataTemp.Columns.Add("session");
                dataTemp.Columns.Add("FillDate");
                DataRow drow;
                for (int i = 0; i <= DtEmpNew.Rows.Count - 1; i++)
                {


                    drow = dataTemp.NewRow();
                    dataTemp.Rows.Add(drow);
                    if (DtEmpNew.Rows.Count > 0)
                    {
                        id = Convert.ToInt32(DtEmpNew.Rows[i][0].ToString());
                        name = EmpObj.GetEmployeeName(id);
                        dataTemp.Rows[i][0] = name;
                        newval = float.Parse(DtEmpNew.Rows[i][6].ToString());
                        dataTemp.Rows[i][3] = newval;

                        //dataTemp.Rows[i][2] = DtEmpNew.Rows[i][9].ToString();
                        data = Convert.ToDateTime(DtEmpNew.Rows[i][8].ToString());
                        dataTemp.Rows[i][1] = data.ToShortDateString();
                        datanew1 = Convert.ToDateTime(DtEmpNew.Rows[i][9].ToString());
                        dataTemp.Rows[i][2] = datanew1.ToShortDateString();
                        dataTemp.Rows[i][4] = DtEmpNew.Rows[i][10].ToString();
                        dataTemp.Rows[i][5] = DtEmpNew.Rows[i][15].ToString();
                        dataTemp.Rows[i][6] = DtEmpNew.Rows[i][2].ToString();


                    }
                }
                this.PopNew.Show();
                grd_Jobno.DataSource = dataTemp;
                grd_Jobno.DataBind();
                grd_Jobno.Visible = true;

            }
            else
            {
                this.PopNew.Show();
                grd_Jobno.DataSource = dataTemp;
                grd_Jobno.DataBind();
                grd_Jobno.Visible = true;
                this.PopNew.Enabled = false;
            }
        }
        public void leavebalance()
        {
            int intempid;
            DataTable dttp = new DataTable();
            intempid = EmpObj.GetEmpid(Session["LoginUserName"].ToString());
            dt = emp.SelForEmpLeaveDetails(intempid.ToString());
            if (dt.Rows.Count > 0)
            {
                clbal = Convert.ToDouble(dt.Rows[0][2].ToString());
                slbal = Convert.ToDouble(dt.Rows[0][3].ToString());
                elbal = Convert.ToDouble(dt.Rows[0][4].ToString());
                cltaken = Convert.ToDouble(dt.Rows[0][5].ToString());
                sltaken = Convert.ToDouble(dt.Rows[0][6].ToString());
                eltaken = Convert.ToDouble(dt.Rows[0][7].ToString());
                txtCL.Value = Convert.ToDouble(clbal - cltaken).ToString();
                txtSL.Value = Convert.ToDouble(slbal - sltaken).ToString();
                txtEL.Value = Convert.ToDouble(elbal - eltaken).ToString();
                dttp.Columns.Add("attyear");
                dttp.Columns.Add("empid");
                dttp.Columns.Add("clbalance");
                dttp.Columns.Add("slbalance");
                dttp.Columns.Add("elbalance");
                dttp.Columns.Add("cltaken");
                dttp.Columns.Add("sltaken");
                dttp.Columns.Add("eltaken");
                DataRow ro;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ro = dttp.NewRow();
                        dttp.Rows.Add();
                        dttp.Rows[0]["attyear"] = "Casual";
                        dttp.Rows[0]["empid"] = txtCL.Value + "Days";
                        dttp.Rows.Add();
                        dttp.Rows[1]["attyear"] = "Sick";
                        dttp.Rows[1]["empid"] = txtSL.Value + "Days";
                        dttp.Rows.Add();
                        dttp.Rows[2]["attyear"] = "Earn";
                        dttp.Rows[2]["empid"] = txtEL.Value + "Days";
                        Grdlve.DataSource = dttp;
                        Grdlve.DataBind();
                        //dttp.Rows[0]["clbalance"] = txtCL.Value;
                        //dttp.Rows[0]["attyear"] = "Sick";
                        //dttp.Rows[0]["slbalance"] = txtSL.Value;
                        //dttp.Rows[0]["attyear"] = "Earn";
                        //dttp.Rows[0]["elbalance"] = txtEL.Value;
                        //dttp.Rows[0]["cltaken"] = dt.Rows[0]["cltaken"];
                        //dttp.Rows[0]["sltaken"] = dt.Rows[0]["sltaken"];
                        //dttp.Rows[0]["eltaken"] = dt.Rows[0]["eltaken"];
                    }

                }
            }
        }
       /* public void loadGrdM()
        {
            int i;
            int pos;
            pos = 0;
            DataTable data = new DataTable();
            //for (i = 0; i < GrdM.Rows.Count; i++)
            //{
            //    GrdM.Rows.remove(GrdM.Rows[0]);
            //}
            dt = emp.GetEmpDetailsforClaim(EmpObj.GetEmpid(Session["LoginUserName"].ToString()));
            data.Columns.Add("cdate");
            data.Columns.Add("claimamt");
            DataRow row;
            if (dt.Rows.Count > 0)
            {
                for (i = 0; i < dt.Rows.Count - 1; i++)
                {
                    claimtype = dt.Rows[i]["claimtype"].ToString();
                    if (claimtype.ToString().Length == 'M')
                    {
                        if (GrdM.Rows.Count > 0)
                        {
                            pos = pos + 1;
                        }
                    }
                    row = data.NewRow();
                    data.Rows.Add();
                    data.Rows[i]["cdate"] = dt.Rows[i]["cdate"];
                    data.Rows[i]["claimamt"] = dt.Rows[i]["claimamt"];
                }
                GrdM.DataSource = data;
                GrdM.DataBind();


            }
        }*/
        public void loadGrdL()
        {
            int i;
            int pos;
            string claimtype;
            pos = 0;
            DataTable dat1 = new DataTable();
            dt = emp.GetEmpDetailsforClaim(EmpObj.GetEmpid(Session["LoginUserName"].ToString()));
            dat1.Columns.Add("cdate");
            dat1.Columns.Add("claimamt");
            DataRow row;
            if (dt.Rows.Count > 0)
            {
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    claimtype = dt.Rows[i]["claimtype"].ToString();
                    if (claimtype.ToString() == "L")
                    {
                        dat1.Rows.Add();
                        dat1.Rows[pos]["cdate"] = dt.Rows[i]["cdate"];
                        dat1.Rows[pos]["claimamt"] = dt.Rows[i]["claimamt"];
                        pos++;
                    }                    
                }
                GrdL.DataSource = dat1;
                GrdL.DataBind();
            }
        }
        public void Emppermission()
        {
            int intempid = EmpObj.GetEmpid(Session["LoginUserName"].ToString());
            dt = emp.SELPermissiondtls(intempid);
            if (dt.Rows.Count != 0)
            {
                GridPermission.DataSource = dt;
                GridPermission.DataBind();
            }
        }
        protected void lnk_personal_Click(object sender, EventArgs e)
        {

        }

        protected void lnk_education_Click(object sender, EventArgs e)
        {

        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lnk_Click(object sender, EventArgs e)
        {

        }

        protected void grdwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel6.Visible = true;
            ModalPopupExtender1.Show();
            index = grdwork.SelectedRow.RowIndex;
            if (cmbyear.SelectedIndex != -1 && txt_year.Text != "")
            {
                fmonth = Convert.ToInt32(cmbyear.SelectedIndex);
            }
            if (grdwork.Rows[index].Cells[1].Text == "Quotation")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "Quotation");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Booking")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "Booking");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Ocean Exports - Job")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "FEJOB");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Ocean Imports - Job")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "FIJOB");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Air Exports - Job")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "AEJOB");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Air Imports - Job")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "AIJOB");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Ocean Exports - BL")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "FEBL");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Ocean Imports - BL")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "FIBL");
            }

            if (grdwork.Rows[index].Cells[1].Text == "BL - RELEASE")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "BLR");
            }
            if (grdwork.Rows[index].Cells[1].Text == "DO - RELEASE")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "DOR");
            }
            if (grdwork.Rows[index].Cells[1].Text == "INVOICE")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "Invoice");
            }
            if (grdwork.Rows[index].Cells[1].Text == "PAYMENTADVISE")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "PA");
            }
            if (grdwork.Rows[index].Cells[1].Text == "CREDITNOTE")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "CN");
            }
            if (grdwork.Rows[index].Cells[1].Text == "DEBITNOTE")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "DN");
            }
            if (grdwork.Rows[index].Cells[1].Text == "OVERSEAS-DEBITNOTE")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "OSSI");
            }
            if (grdwork.Rows[index].Cells[1].Text == "OVERSEAS-CREDITNOTE")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "OSPI");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Stuffing Sent On")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "Stuffing");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Sailing Sent On")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "Sailing");
            }
            if (grdwork.Rows[index].Cells[1].Text == "Transhipment Sent On")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "Transhipment");
            }
            if (grdwork.Rows[index].Cells[1].Text == "DO Confirmation  Sent On")
            {
                dtdtls = profileobj.GetWorkIndividualDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]), "DO");
            }
            if (dtdtls.Rows.Count > 0)
            {
                grdwork.Visible = false;
                grddtls.Visible = true;
                grddtls.DataSource = dtdtls;
                grddtls.DataBind();
            }
        }

        protected void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dts = new DataTable();
            int Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if (cmbyear.SelectedIndex != -1 && txt_year.Text != "")
            {
                fmonth = Convert.ToInt32(cmbyear.SelectedIndex) + 1;
                dtp = profileobj.GetWorkDetails(fmonth, Convert.ToInt32(txt_year.Text), Empid);
                grdwork.DataSource = dtp;
                grdwork.DataBind();
                grdwork.Visible = true;
                grddtls.Visible = false;
            }

            //fyear = cmbyear.SelectedIndex;
            //hidfyear.Value = fyear.ToString();
            //fillalldts();
            Panel6.Visible = true;
            ModalPopupExtender1.Show();
        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            if (cmbyear.SelectedIndex != -1 && txt_year.Text != "")
            {
                fmonth = cmbyear.SelectedIndex;
                dtp = profileobj.GetWorkDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]));
                grdwork.DataSource = dtp;
                grdwork.DataBind();
                grdwork.Visible = true;
                grddtls.Visible = false;
            }
            Panel6.Visible = true;
            ModalPopupExtender1.Show();
        }

        protected void txt_year_TextChanged(object sender, EventArgs e)
        {
            if (cmbyear.SelectedIndex != -1 && txt_year.Text != "")
            {
                fmonth = Convert.ToInt32(cmbyear.SelectedIndex + 1);
                dtp = profileobj.GetWorkDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]));
                grdwork.DataSource = dtp;
                grdwork.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataAccess.HR.Employee objEmp = new DataAccess.HR.Employee();
            DataTable DtTable = new DataTable();
            
            DtTable = objEmp.apprisalcheckforitcomputation(Convert.ToInt32(Session["LoginEmpId"]));
            if (DtTable.Rows.Count>0)
            {
                ScriptManager.RegisterStartupScript(Button1, typeof(Button), "logix", "alertify.alert('You are not allowed to view it computation because of appraisal process..');", true);
                return;
            }
            else
            {
                string profile = "profile";
                Response.Redirect("../HRM/ITComputation.aspx?profile=" + profile);
            }
           
        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("../HRM/InvestmentPlan.aspx");
        //}

        protected void link_right_Click(object sender, EventArgs e)
        {
            //  Fn_TabClick(div_right, panel_right);
        }

        protected void link_work_Click(object sender, EventArgs e)
        {
            //Fn_TabClick(div_work, panel_work);
            //grdwork.DataSource = Utility.Fn_GetEmptyDataTable();
            //grdwork.DataBind();
        }

        protected void grdwork_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdwork, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {

            checkdata();

            if (bolerr == true)
            {
                bolerr = false;
                return;
            }
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";


            //"Payroll" + "//rptHRSalrivision.rpt";

            str_RptName = "Payroll" + "//rptHRPaySlip.rpt";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            //str_sf = "({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_fromyear.Text + "," + cmb_month.SelectedIndex + 1 & ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <=Date(" + txt_toyear.Text + "," + cmd_tomonth.SelectedIndex + 1 + ",01)" + "and {HRPayroll.divisionid}=" + (Session["LoginDivisionId"]) + "and {HRPayroll.empid}=" + (Session["LoginEmpId"].ToString());
          //  str_sf = "System.Date({ HRPayroll.payyear }, { HRPayroll.paymonth }, 1) >= System.Date(" + txt_fromyear.Text + ", " + cmb_month.SelectedIndex + 1 + ", 1) and  ({HRPayroll.payyear},{HRPayroll.paymonth},1) <=System.Date(" + txt_toyear.Text + "," + cmd_tomonth.SelectedIndex + 1 + ",01)" + (Session["LoginDivisionId"].ToString()) + " and {HRPayroll.empid}=" + (Session["LoginEmpId"].ToString());
           // str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_fromyear.Text + "," + cmb_month.SelectedIndex + 1 + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <=Date(" + txt_toyear.Text + "," + cmd_tomonth.SelectedIndex + 1 + ",01)" + (Session["LoginDivisionId"].ToString()) + " and {HRPayroll.empid}=" + (Session["LoginEmpId"].ToString());
            Session["str_sfs"] = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_fromyear.Text + "," + (cmb_month.SelectedIndex) + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <=Date(" + txt_toyear.Text + "," + (cmd_tomonth.SelectedIndex) + ",01)" + "and {HRPayroll.divisionid}=" + (Session["LoginDivisionId"].ToString()) + " and {HRPayroll.empid}=" + (Session["LoginEmpId"].ToString());

           // Session["str_sfs"] = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_fromyear.Text + "," + (cmb_month.SelectedIndex) + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <=Date(" + txt_toyear.Text + "," + (cmd_tomonth.SelectedIndex) + ",01)"  + " and {HRPayroll.empid}=" + (Session["LoginEmpId"].ToString());

            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
           //str_Script = "window.open('../Reportasp/paysliprpt.aspx?fromyear=" + txt_fromyear.Text + "&fromonth=" + cmb_month.SelectedIndex + "&toyear=" + txt_toyear.Text + "&tomonth=" + cmd_tomonth.SelectedIndex + this.Page.ClientQueryString + "','','');";
            logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1348, 3, int.Parse(Session["LoginBranchid"].ToString()), cmb_month.Text + "/O");
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", str_Script, true);
           // Session["str_sfs"] = str_sf;
            //Session["str_sp"] = str_sp;
        }

        //protected void btn1_Click(object sender, EventArgs e)
        //{
        //    //Response.Redirect("../HRM/KPI.aspx");
        //    iframeKPI.Attributes["src"] = "../HRM/KPI.aspx";
        //    popup_KPI.Show();
        //}
        public void checkdata()
        {
            int fmonth, tomonth, frmyr, toyr;
            if (cmb_month.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('Please Select a Month');", true);
                bolerr = true;
                cmb_month.Focus();
                return;
            }
            else if (txt_year.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('Enter the Financial Year');", true);
                bolerr = true;
                txt_year.Focus();
                return;
            }
            if (cmd_tomonth.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('Please Select a Month');", true);
                bolerr = true;
                cmd_tomonth.Focus();
                return;
            }
            else if (txt_toyear.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('Enter the Financial Year');", true);
                bolerr = true;
                txt_toyear.Focus();
                return;
            }
            fmonth = cmb_month.SelectedIndex;
            tomonth = cmd_tomonth.SelectedIndex;
            frmyr = Convert.ToInt32(txt_fromyear.Text);
            toyr = Convert.ToInt32(txt_toyear.Text);

            if (frmyr > toyr)
            {
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('From Year Should be Less Then To Year');", true);
                bolerr = true;
                txt_fromyear.Focus();
                return;
            }
            else
            {
                if (frmyr == toyr)
                {
                    if (fmonth > tomonth)
                    {
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('From Month Should Be Less Then To Month');", true);
                        bolerr = true;
                        cmd_tomonth.Focus();
                        return;
                    }
                }

            }

            if (fmonth <= 3 && frmyr < 2012)
            {
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('From Month Should Be Start Up From April 2012 Only ');", true);
                bolerr = true;
                cmb_month.Focus();
                return;
            }
            string year = (logobj.GetDate().Year).ToString();
            if (toyr >= Convert.ToInt32(year))
            {
                if (tomonth >= (logobj.GetDate()).Month)
                {
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('Current Month Payslip Not Allowed');", true);
                    bolerr = true;
                    cmb_month.Focus();
                    return;
                }
                if (toyr > Convert.ToInt32(year))
                {
                    // MsgBox(toyr & " Payslip Not Allowed  ")
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('Payslip Not Allowed ');", true);
                    bolerr = true;
                    cmb_month.Focus();
                    return;
                }


            }



        }

        /* protected void lbl_lnkrate_Click(object sender, EventArgs e)
         {
             lblLeaveApp.Text = "Leave Application";
             btnsave.Visible = true;
             btnApproved.Visible = false;
             btnDeclaine.Visible = false;
             txtApprovedBy.Visible = false;
             txtApprovedon.Visible = false;
             // lbl_lnkrate.Visible = false;
             lblApprovedBy.Visible = false;
             hid_Date.Value = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
             txtDate.Text = hid_Date.Value;
             txtFrom.Text = hid_Date.Value;
             txtTo.Text = hid_Date.Value;
             txtApprovedon.Text = hid_Date.Value;
             txtPreperedBy.Text = Session["LoginEmpName"].ToString();
             Get_EmpDetails();
             txtLeaveRequired.Focus();
             this.Grd_buying_popup.Show();
         }*/
        protected void Get_EmpDetails()
        {
            DataTable obj_dt = new DataTable();
            txtName.Text = Session["LoginEmpName"].ToString();
            DtEmpNew = EmpObj.GetEmployeeID(txtName.Text);
            empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
            obj_dt = da_obj_Employee.GetEmpDetailsNew(empidnew.ToString());
            if (obj_dt.Rows.Count > 0)
            {
                txtName.Text = obj_dt.Rows[0][1].ToString();
                txtDepartment.Text = obj_dt.Rows[0][4].ToString();
                txtDesgination.Text = obj_dt.Rows[0][5].ToString();
                txtLocation.Text = obj_dt.Rows[0][6].ToString();
                txtGrade.Text = obj_dt.Rows[0][3].ToString();
                //  txt_division.Text = obj_dt.Rows[0][6].ToString();
            }
        }


        protected void check_Data()
        {
            if (txtLocation.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please selected Location');", true);
                txtLocation.Focus();
                blrrr = true;
                return;
            }

            else if (txtName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please selected Employee Name');", true);
                txtName.Focus();
                blrrr = true;
                return;
            }

            else if (txtDesgination.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Enter Designation');", true);
                txtDesgination.Focus();
                blrrr = true;
                return;
            }

            else if (txtGrade.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Enter Grade');", true);
                txtGrade.Focus();
                blrrr = true;
                return;
            }

            else if (txtDepartment.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Enter  Grade');", true);
                txtDepartment.Focus();
                blrrr = true;
                return;
            }

            else if (txtLeaveRequired.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Enter LeaveRequired');", true);
                txtLeaveRequired.Focus();
                blrrr = true;
                return;
            }
            else if (ddlStatus.Visible == true)
            {
                if (ddlStatus.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Select Session');", true);
                    ddlStatus.Focus();
                    blrrr = true;
                    return;
                }

            }

            else if (rbtEl.Checked == false && rbtSick.Checked == false && rbtCasual.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please select Any One Leave Option');", true);
                rbtEl.Focus();
                blrrr = true;
                return;
            }

            else if (txtPurpose.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Enter Leave Purpose');", true);
                txtPurpose.Focus();
                blrrr = true;
                return;
            }
            //else if (txtLeaveAdd.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Enter Leave Address');", true);
            //    txtLeaveAdd.Focus();
            //    blrrr = true;
            //    return;
            //}

            else if (txtPhone.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Enter Mobile Number');", true);
                txtPhone.Focus();
                blrrr = true;
                return;
            }
            else if (txtPreperedBy.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Please Enter Prepered By');", true);
                txtPreperedBy.Focus();
                blrrr = true;
                return;
            }

        }

        protected void txtLeaveRequired_TextChanged(object sender, EventArgs e)
        {
            //  this.Grd_buying_popup.Show();
            if (txtLeaveRequired.Text != "")
            {
                double rate = Convert.ToDouble(txtLeaveRequired.Text);
                if (txtLeaveRequired.Text == "1")
                {
                    ddlStatus.Visible = false;
                    txtTo.Visible = false;
                }
                else if (rate < 1)
                {
                    txtTo.Visible = false;
                    ddlStatus.Visible = true;
                }
                else
                {
                    ddlStatus.Visible = false;
                    txtTo.Visible = true;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Leave Required Empty');", true);
                txtLeaveRequired.Focus();
                txtLeaveRequired.Text = "";
                return;
            }

        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            // this.Grd_buying_popup.Show();
            check_Data();
            DtEmpNew = EmpObj.GetEmployeeID(txtPreperedBy.Text);
            empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
            if (txtTo.Visible == false)
            {
                txtTo.Text = txtFrom.Text;
            }
            if (blrrr == true)
            {
                return;
            }
            string Leaves = "";
            if (rbtEl.Checked == true)
            {
                Leaves = "EL";
            }
            else if (rbtSick.Checked == true)
            {
                Leaves = "Sick";
            }
            else
            {
                Leaves = "Casual";
            }

            if (ddlStatus.Visible == true)
            {
                if (ddlStatus.Text == "F")
                {
                    ddlStatus.SelectedValue = "F";
                }
                else
                {
                    ddlStatus.SelectedValue = "A";
                }
            }

            if (btnsave.Text == "Apply")
            {
                dtNewTemp = EmpObj.GetEmployeeID(txtName.Text);
                empid = Convert.ToInt32(dtNewTemp.Rows[0][0]);
                da_obj_LWF.GetLeaveApplication(empid, txtLocation.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text)), txtDesgination.Text, txtGrade.Text, txtDepartment.Text, float.Parse(txtLeaveRequired.Text), Leaves,
                Convert.ToDateTime(Utility.fn_ConvertDate(txtFrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)), txtPurpose.Text, txtLeaveAdd.Text,
                 txtPhone.Text, Convert.ToInt32(empidnew), ddlStatus.SelectedValue);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Applied Successfully....');", true);
                btnCancel.Text = "Cancel";

            }

        }
        protected void btnApproved_Click(object sender, EventArgs e)
        {
            if (txtPreperedBy.Text == Session["LoginEmpName"].ToString())
            {
                // this.Grd_buying_popup.Show();
                string LeaveStaus = "A";
                DateTime dataTime;
                status = "A";
                txtApprovedBy.Text = Session["LoginEmpName"].ToString();
                txtApprovedon.Text = hid_Date.Value;
                DtEmpNew = EmpObj.GetEmployeeID(txtApprovedBy.Text);
                empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
                dtNewTemp = EmpObj.GetEmployeeID(txtName.Text);
                empid = Convert.ToInt32(dtNewTemp.Rows[0][0]);
                ddlStatus.SelectedValue = "A";
                ddlStatus.SelectedValue = "F";

                da_obj_LWF.ApproveLeaveDetailsNew(empid, empidnew, Convert.ToDateTime(Utility.fn_ConvertDate(txtApprovedon.Text)), Convert.ToChar(status));

                da_obj_LWF.UpdateAppDetails(empid, Convert.ToDateTime(Utility.fn_ConvertDate((txtDate.Text))), empidnew);
                if (txtLeaveRequired.Text != "")
                {
                    DateTime data;
                    int valus = Convert.ToInt32(Convert.ToDouble(txtLeaveRequired.Text));
                    dataTime = Convert.ToDateTime((txtFrom.Text));
                    if (ddlStatus.Visible == true)
                    {
                        if (valus < 1)
                        {
                            ddlStatus.SelectedValue = "A";
                        }
                        else
                        {
                            ddlStatus.SelectedValue = "F";
                        }
                    }
                    for (int i = 1; i <= valus; i++)
                    {
                        if (i < 1)
                        {
                            objHr.UpdEmpAttendance(empid, dataTime, Convert.ToChar(ddlStatus.SelectedValue), Convert.ToChar(ddlStatus.SelectedValue));
                        }
                        else if (i == 1)
                        {
                            objHr.UpdEmpAttendance(empid, dataTime, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
                        }
                        else
                        {
                            data = Convert.ToDateTime(dataTime).AddDays(1);
                            objHr.UpdEmpAttendance(empid, data, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
                        }

                    }
                }

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Approved  Successfully....');", true);
                GridDataAllBind();
                btnCancel.Text = "Cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('You Cannot Approved Leave Application....');", true);
                btnCancel.Text = "Cancel";
            }
        }

        protected void GetAttSave()
        {

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
            {
                //txtName.Text = "";
                // this.Grd_buying_popup.Show();
                txtPhone.Text = "";
                txtLeaveAdd.Text = "";
                //txtPreperedBy.Text = "";
                txtPurpose.Text = "";
                txtFrom.Text = hid_Date.Value;
                txtTo.Text = hid_Date.Value;
                rbtCasual.Checked = false;
                rbtSick.Checked = false;
                rbtEl.Checked = false;
                txtLeaveRequired.Text = "";
                ddlStatus.SelectedValue = "";
                ddlStatus.Visible = false;
                txtLeaveRequired.Focus();
                               
                    
                        txt_Empcode.Focus();
                        Fn_Clear();
                
                
            }
            else
            {
                Response.Redirect("../Home/Profile.aspx");
            }

        }
        protected void btnDeclaine_Click(object sender, EventArgs e)
        {
            if (txtPreperedBy.Text == Session["LoginEmpName"].ToString())
            {
                this.PopNew.Show();
                string LeaveStaus = "A";
                DateTime dataTime;
                status = "D";
                dtNewTemp = EmpObj.GetEmployeeID(txtName.Text);
                empid = Convert.ToInt32(dtNewTemp.Rows[0][0]);
                txtApprovedBy.Text = Session["LoginEmpName"].ToString();
                txtApprovedon.Text = hid_Date.Value;
                DtEmpNew = EmpObj.GetEmployeeID(txtApprovedBy.Text);
                empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
                ddlStatus.SelectedValue = "A";
                ddlStatus.SelectedValue = "F";
                da_obj_LWF.ApproveLeaveDetailsNew(empid, empidnew, Convert.ToDateTime(Utility.fn_ConvertDate(txtApprovedon.Text)), Convert.ToChar(status));
                da_obj_LWF.UpdateAppDetails(empid, Convert.ToDateTime(Utility.fn_ConvertDate((txtDate.Text))), empidnew);
                if (txtLeaveRequired.Text != "")
                {
                    DateTime data;
                    int valus = Convert.ToInt32(Convert.ToDouble(txtLeaveRequired.Text));
                    dataTime = Convert.ToDateTime((txtFrom.Text));
                    if (ddlStatus.Visible == true)
                    {
                        if (valus < 1)
                        {
                            ddlStatus.SelectedValue = "A";
                        }
                        else
                        {
                            ddlStatus.SelectedValue = "F";
                        }
                    }
                    for (int i = 1; i <= valus; i++)
                    {
                        if (i < 1)
                        {
                            objHr.UpdEmpAttendance(empid, dataTime, Convert.ToChar(ddlStatus.SelectedValue), Convert.ToChar(ddlStatus.SelectedValue));
                        }
                        else if (i == 1)
                        {
                            objHr.UpdEmpAttendance(empid, dataTime, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
                        }
                        else
                        {
                            data = Convert.ToDateTime(dataTime).AddDays(1);
                            objHr.UpdEmpAttendance(empid, data, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
                        }

                    }
                }
                btnCancel.Text = "Cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('You Cannot Desaline Leave Application....');", true);
                btnCancel.Text = "Cancel";
            }
            btnCancel.Text = "Cancel";
        }

        protected void ddlFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string value, name;
            //string Newstatus, Newstatus1, fun;
            this.PopNew.Show();
            //DropDownList ddl = (DropDownList)sender;
            //GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            //int idx = row.RowIndex;


            //DropDownList ddl1 = (DropDownList)grd_Jobno.Rows[idx].FindControl("ddlFunction");
            //value = ddl1.Text;
            //if( ddl1.SelectedValue == "1")
            //{
            //    for (int i = 0; i <= grd_Jobno.Rows.Count - 1; i++)
            //    {
            //        DropDownList ddl2 = (DropDownList)grd_Jobno.Rows[i].FindControl("ddlFunction");

            //        ddl2.SelectedValue = "1";

            //    }
            //}
            //else
            //{
            //    DropDownList ddl3 = (DropDownList)grd_Jobno.Rows[idx].FindControl("ddlFunction");
            //    ddl3.SelectedValue = "2";

            //}

            ////string value,name;
            ////string Newstatus, Newstatus1,fun;
            //if (grd_Jobno.Rows.Count > 0)
            //{

            //    //DropDownList ddl = (DropDownList)sender;
            //    //GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            //    //int idx = row.RowIndex;
            //    //int index = grd_Jobno.SelectedRow.RowIndex;
            //    // hid_index.Value = index.ToString();
            //   // DropDownList ddl1 = (DropDownList)grd_Jobno.Rows[idx].FindControl("ddlFunction");

            //    value = ddl1.Text;
            //    if (value == "1")
            //    {
            //        string LeaveStaus = "A";
            //        DateTime dataTime;
            //        status = "A";
            //        // txtApprovedBy.Text = Session["LoginEmpName"].ToString();
            //        txtApprovedon.Text = hid_Date.Value;


            //        Newstatus = "F";
            //        Newstatus1 = "A";
            //        name = grd_Jobno.Rows[idx].Cells[0].Text;
            //        //dtNewTemp = EmpObj.GetEmployeeID(txtName.Text);
            //        //empid = Convert.ToInt32(dtNewTemp.Rows[0][0]);
            //        txtLeaveRequired.Text = grd_Jobno.Rows[idx].Cells[3].Text;
            //        fun = grd_Jobno.Rows[idx].Cells[5].Text;
            //        DtEmpNew = EmpObj.GetEmployeeID(name);
            //        empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
            //        txtDate.Text = grd_Jobno.Rows[idx].Cells[6].Text;
            //        da_obj_LWF.ApproveLeaveDetailsNew(empidnew, Convert.ToInt32(hid_empid.Value), Convert.ToDateTime(Utility.fn_ConvertDate(txtApprovedon.Text)), Convert.ToChar(status));
            //        da_obj_LWF.UpdateAppDetails(empidnew, Convert.ToDateTime((txtDate.Text)), Convert.ToInt32(hid_empid.Value));//changePannanum
            //        if (txtLeaveRequired.Text != "")
            //        {
            //            DateTime data;
            //            float valus = float.Parse(txtLeaveRequired.Text);
            //            txtFrom.Text = grd_Jobno.Rows[idx].Cells[1].Text;
            //            dataTime = Convert.ToDateTime((txtFrom.Text));

            //            if (valus < 1)
            //            {
            //                if (fun == "F")
            //                {
            //                    Newstatus = "F";
            //                }
            //                else
            //                {
            //                    Newstatus1 = "A";
            //                }

            //            }


            //            for (int i = 1; i <= valus; i++)
            //            {
            //                if (i < 1)
            //                {
            //                    objHr.UpdEmpAttendance(empidnew, dataTime, Convert.ToChar(Newstatus), Convert.ToChar(Newstatus1));
            //                }
            //                else if (i == 1)
            //                {
            //                    objHr.UpdEmpAttendance(empidnew, dataTime, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
            //                }
            //                else
            //                {
            //                    data = Convert.ToDateTime(dataTime).AddDays(1);
            //                    objHr.UpdEmpAttendance(empidnew, data, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
            //                }

            //            }
            //        }
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Approved  Successfully....');", true);
            //        GridDataAllBind();
            //        btnCancel.Text = "Cancel";
            //    }
            //    else
            //    {
            //        if (value == "2")
            //        {
            //            string LeaveStaus = "A";
            //            DateTime dataTime;
            //            status = "D";
            //            // txtApprovedBy.Text = Session["LoginEmpName"].ToString();
            //            txtApprovedon.Text = hid_Date.Value;


            //            Newstatus = "F";
            //            Newstatus1 = "A";
            //            name = grd_Jobno.Rows[idx].Cells[0].Text;
            //            //dtNewTemp = EmpObj.GetEmployeeID(txtName.Text);
            //            //empid = Convert.ToInt32(dtNewTemp.Rows[0][0]);
            //            txtLeaveRequired.Text = grd_Jobno.Rows[idx].Cells[3].Text;
            //            fun = grd_Jobno.Rows[idx].Cells[5].Text;
            //            DtEmpNew = EmpObj.GetEmployeeID(name);
            //            empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
            //            txtDate.Text = grd_Jobno.Rows[idx].Cells[6].Text;
            //            da_obj_LWF.ApproveLeaveDetailsNew(empidnew, Convert.ToInt32(hid_empid.Value), Convert.ToDateTime(Utility.fn_ConvertDate(txtApprovedon.Text)), Convert.ToChar(status));
            //            da_obj_LWF.UpdateAppDetails(empidnew, Convert.ToDateTime((txtDate.Text)), Convert.ToInt32(hid_empid.Value));//changePannanum
            //            if (txtLeaveRequired.Text != "")
            //            {
            //                DateTime data;
            //                float valus = float.Parse(txtLeaveRequired.Text);
            //                txtFrom.Text = grd_Jobno.Rows[idx].Cells[1].Text;
            //                dataTime = Convert.ToDateTime((txtFrom.Text));

            //                if (valus < 1)
            //                {
            //                    if (fun == "F")
            //                    {
            //                        Newstatus = "F";
            //                    }
            //                    else
            //                    {
            //                        Newstatus1 = "A";
            //                    }

            //                }


            //                for (int i = 1; i <= valus; i++)
            //                {
            //                    if (i < 1)
            //                    {
            //                        objHr.UpdEmpAttendance(empidnew, dataTime, Convert.ToChar(Newstatus), Convert.ToChar(Newstatus1));
            //                    }
            //                    else if (i == 1)
            //                    {
            //                        objHr.UpdEmpAttendance(empidnew, dataTime, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
            //                    }
            //                    else
            //                    {
            //                        data = Convert.ToDateTime(dataTime).AddDays(1);
            //                        objHr.UpdEmpAttendance(empidnew, data, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
            //                    }

            //                }
            //            }
            //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Declaine  Successfully....');", true);
            //            GridDataAllBind();
            //            btnCancel.Text = "Cancel";
            //        }
            //    }
            //}



        }



        protected void grd_Jobno_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Jobno, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_Jobno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (grd_Jobno.Rows.Count > 0)
            //{
            //    this.PopNew.Show();
            //    int index = grd_Jobno.SelectedRow.RowIndex;
            //    hid_index.Value = index.ToString();
            // }
        }

        protected void grd_Jobno_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string value, name;
            string Newstatus, Newstatus1, fun;
            this.PopNew.Show();
            for (int i = 0; i <= grd_Jobno.Rows.Count - 1; i++)
            {
                DropDownList ddl1 = (DropDownList)grd_Jobno.Rows[i].FindControl("ddlFunction");
                value = ddl1.Text;
                if (value == "1")
                {
                    string LeaveStaus = "A";
                    DateTime dataTime;
                    status = "A";
                    // txtApprovedBy.Text = Session["LoginEmpName"].ToString();
                    txtApprovedon.Text = hid_Date.Value;


                    Newstatus = "F";
                    Newstatus1 = "A";
                    name = grd_Jobno.Rows[i].Cells[0].Text;
                    //dtNewTemp = EmpObj.GetEmployeeID(txtName.Text);
                    //empid = Convert.ToInt32(dtNewTemp.Rows[0][0]);
                    txtLeaveRequired.Text = grd_Jobno.Rows[i].Cells[3].Text;
                    fun = grd_Jobno.Rows[i].Cells[5].Text;
                    DtEmpNew = EmpObj.GetEmployeeID(name);
                    empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
                    txtDate.Text = grd_Jobno.Rows[i].Cells[6].Text;
                    da_obj_LWF.ApproveLeaveDetailsNew(empidnew, Convert.ToInt32(hid_Empid.Value), Convert.ToDateTime(Utility.fn_ConvertDate(txtApprovedon.Text)), Convert.ToChar(status));
                    da_obj_LWF.UpdateAppDetails(empidnew, Convert.ToDateTime((txtDate.Text)), Convert.ToInt32(hid_Empid.Value));//changePannanum
                    if (txtLeaveRequired.Text != "")
                    {
                        DateTime data;
                        float valus = float.Parse(txtLeaveRequired.Text);
                        txtFrom.Text = grd_Jobno.Rows[i].Cells[1].Text;
                        dataTime = Convert.ToDateTime((txtFrom.Text));

                        if (valus < 1)
                        {
                            if (fun == "F")
                            {
                                Newstatus = "F";
                            }
                            else
                            {
                                Newstatus1 = "A";
                            }

                        }


                        for (int j = 1; j <= valus; j++)
                        {
                            if (j < 1)
                            {
                                objHr.UpdEmpAttendance(empidnew, dataTime, Convert.ToChar(Newstatus), Convert.ToChar(Newstatus1));
                            }
                            else if (j == 1)
                            {
                                objHr.UpdEmpAttendance(empidnew, dataTime, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
                            }
                            else
                            {
                                data = Convert.ToDateTime(dataTime).AddDays(1);
                                objHr.UpdEmpAttendance(empidnew, data, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
                            }

                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Approved  Successfully....');", true);
                    //GridDataAllBind();
                    btnCancel.Text = "Cancel";
                }
                else
                {
                    if (value == "2")
                    {
                        string LeaveStaus = "A";
                        DateTime dataTime;
                        status = "D";
                        // txtApprovedBy.Text = Session["LoginEmpName"].ToString();
                        txtApprovedon.Text = hid_Date.Value;


                        Newstatus = "F";
                        Newstatus1 = "A";
                        name = grd_Jobno.Rows[i].Cells[0].Text;
                        //dtNewTemp = EmpObj.GetEmployeeID(txtName.Text);
                        //empid = Convert.ToInt32(dtNewTemp.Rows[0][0]);
                        txtLeaveRequired.Text = grd_Jobno.Rows[i].Cells[3].Text;
                        fun = grd_Jobno.Rows[i].Cells[5].Text;
                        DtEmpNew = EmpObj.GetEmployeeID(name);
                        empidnew = Convert.ToInt32(DtEmpNew.Rows[0][0]);
                        txtDate.Text = grd_Jobno.Rows[i].Cells[6].Text;
                        da_obj_LWF.ApproveLeaveDetailsNew(empidnew, Convert.ToInt32(hid_Empid.Value), Convert.ToDateTime(Utility.fn_ConvertDate(txtApprovedon.Text)), Convert.ToChar(status));
                        da_obj_LWF.UpdateAppDetails(empidnew, Convert.ToDateTime((txtDate.Text)), Convert.ToInt32(hid_Empid.Value));//changePannanum
                        if (txtLeaveRequired.Text != "")
                        {
                            DateTime data;
                            float valus = float.Parse(txtLeaveRequired.Text);
                            txtFrom.Text = grd_Jobno.Rows[i].Cells[1].Text;
                            dataTime = Convert.ToDateTime((txtFrom.Text));

                            if (valus < 1)
                            {
                                if (fun == "F")
                                {
                                    Newstatus = "F";
                                }
                                else
                                {
                                    Newstatus1 = "A";
                                }

                            }


                            for (int j = 1; j <= valus; j++)
                            {
                                if (j < 1)
                                {
                                    objHr.UpdEmpAttendance(empidnew, dataTime, Convert.ToChar(Newstatus), Convert.ToChar(Newstatus1));
                                }
                                else if (j == 1)
                                {
                                    objHr.UpdEmpAttendance(empidnew, dataTime, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
                                }
                                else
                                {
                                    data = Convert.ToDateTime(dataTime).AddDays(1);
                                    objHr.UpdEmpAttendance(empidnew, data, Convert.ToChar(LeaveStaus), Convert.ToChar(LeaveStaus));
                                }

                            }
                        }
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "LeaveApplicatons", "alertify.alert('Decline  Successfully....');", true);
                        btnCancel.Text = "Cancel";
                    }

                }
            }
            GridDataAllBind();

        }

        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value;
            DropDownList ddl1 = (DropDownList)grd_Jobno.HeaderRow.FindControl("ddlHead");
            value = ddl1.Text;

            for (int i = 0; i <= grd_Jobno.Rows.Count - 1; i++)
            {
                DropDownList ddlNew = (DropDownList)grd_Jobno.Rows[i].FindControl("ddlFunction");
                ddlNew.SelectedValue = value;
            }
            this.PopNew.Show();

        }

        /*  Private Sub checkdata()
          If cmbMonth.SelectedIndex = -1 Then
              MsgBox("Please Select a Month")
              bolerr = True
              cmbMonth.Focus()
              Exit Sub
          ElseIf txtYear.Text = "" Then
              MsgBox("Enter the Financial Year")
              bolerr = True
              txtYear.Focus()
              Exit Sub
          ElseIf cmbToMonth.SelectedIndex = -1 Then
              MsgBox("Please Select a Month")
              bolerr = True
              cmbToMonth.Focus()
              Exit Sub
          ElseIf txtToYear.Text = "" Then

              MsgBox("Enter the Financial Year")
              bolerr = True
              txtToYear.Focus()
              Exit Sub

          End If
          Dim fmonth As Integer
          Dim tomonth As Integer
          Dim frmyr As Integer
          Dim toyr As Integer
          fmonth = cmbMonth.SelectedIndex + 1
          tomonth = cmbToMonth.SelectedIndex + 1
          frmyr = Val(txtfrmYear.Text)
          toyr = Val(txtToYear.Text)
          If frmyr > toyr Then
              MsgBox("From Year Should be Less Then To Year")
              bolerr = True
              txtfrmYear.Focus()
              Exit Sub

          Else
              If frmyr = toyr Then
                  If fmonth > tomonth Then
                      MsgBox("From Month Should Be Less Then To Month")
                      bolerr = True
                      cmbToMonth.Focus()
                      Exit Sub
                  End If
              End If
          End If


          If fmonth <= 3 And frmyr < 2012 Then

              MsgBox("From Month Should Be Start Up From April 2012 Only ")
              bolerr = True
              cmbMonth.Focus()
              Exit Sub
              ' End If

          End If
       
          ' If fmonth = 4 And frmyr = 2014 Then
          If toyr >= Year(logobj.GetDate()) Then
              If tomonth >= Month(logobj.GetDate()) Then
                  MsgBox("Current Month Payslip Not Allowed  ")
                  bolerr = True
                  cmbMonth.Focus()
                  Exit Sub
              End If
              If toyr > Year(logobj.GetDate()) Then
                  MsgBox(toyr & " Payslip Not Allowed  ")
                  bolerr = True
                  cmbMonth.Focus()
                  Exit Sub

              End If
          End If
          */


        //protected void Button3_Click(object sender, EventArgs e)
        //{

        //   Response.End();
        //   // Response.Redirect("../FormMain.aspx");

        //}



        //protected void grdwork_SelectedIndexChanged1(object sender, EventArgs e)
        //{
        //    int i;
        //    DataTable dat1 = new DataTable();
        //    dtp = profileobj.GetWorkDetails(fmonth, Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginEmpId"]));
        //    dat1.Columns.Add("SNo");
        //    dat1.Columns.Add("wdetails");
        //    dat1.Columns.Add("wcount");
        //    DataRow ro;
        //    for (i = 0; i < dtp.Rows.Count;i++ )
        //    {
        //        ro = dat1.NewRow();
        //        dat1.Rows.Add();
        //        dat1.Rows[i]["SNo"] = dt.Rows[i]["SNo"];
        //        dat1.Rows[i]["wdetails"] = dtp.Rows[i]["wdetails"];
        //        dat1.Rows[i]["wcount"] = dtp.Rows[i]["wcount"];
        //    }
        //    grdwork.DataSource = dtp;
        //    grdwork.DataBind();
        //} 

        //public void work()
        //{   
        //    int empid=Convert.ToInt32(Session["LoginEmpId"]);
        //    int i;
        //    DataTable dat1 = new DataTable();
        //    if(txt_year.Text=="")
        //    {
        //        txt_year.Text = "0";
        //    }
        //        fmonth = Convert.ToInt32(cmdyear.SelectedIndex) + 1;
        //        dtp = profileobj.GetWorkDetails(fmonth, Convert.ToInt32(txt_year.Text), empid);
        //        dat1.Columns.Add("SNo");
        //        dat1.Columns.Add("wdetails");
        //        dat1.Columns.Add("wcount");
        //        DataRow ro;
        //        for (i = 0; i < dtp.Rows.Count; i++)
        //        {
        //            ro = dat1.NewRow();
        //            dat1.Rows.Add();
        //            dat1.Rows[i]["SNo"] = dtp.Rows[i]["SNo"];
        //            dat1.Rows[i]["wdetails"] = dtp.Rows[i]["wdetails"];
        //            dat1.Rows[i]["wcount"] = dtp.Rows[i]["wcount"];
        //        }

        //    grdwork.DataSource = dtp;
        //    grdwork.DataBind();

        //}



        protected void btn_SaveInv_Click(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();

            EmptyCheck();
            if (err == true)
            {
                err = false;
                return;
            }
            if (btn_SaveInv.Text == "Save")
            {
                double Amount = obj_da_Detail.getInvesTotAmt(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.Text.Substring(0,4)));
                Amount = Amount + double.Parse(txt_Amount.Text);
                double MaxAmount = obj_da_Detail.getMaxlimitAmt(int.Parse(ddl_Section.SelectedValue.ToString()));
                lbl_AvailableLimit.Text = "Available Limit For " + ddl_Section.SelectedItem.Text + "=" + MaxAmount;
                if (MaxAmount >= Amount)
                {
                    obj_dt = obj_da_Detail.InsInvestPlan(int.Parse(hid_Empid.Value.ToString()), ddl_plan.SelectedItem.Text, double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.Text.Substring(0, 4)), logobj.GetDate());
                    if (obj_dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_SaveInv, typeof(Button), "HRM", "alertify.alert('Details Already exists')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_SaveInv, typeof(Button), "HRM", "alertify.alert('Details Saved Successfully')", true);
                        logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 804, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/" + ddl_Year.Text.Substring(0, 4) + "/" + ddl_Section.SelectedItem.Text + "-" + txt_Amount.Text + "/S");
                    }
                    Fn_FillGrd();
                    Fn_ClearSave();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_SaveInv, typeof(Button), "HRM", "alertify.alert('Amount should be less than the Maxlimit Amount')", true);
                    txt_Amount.Text = "";
                }
            }
            else if (btn_SaveInv.Text == "Update")
            {
                double Amount = obj_da_Detail.getInvesTotAmt(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.Text.Substring(0, 4)));
                Amount = Amount - double.Parse(txt_Amount.Text);
                double MaxAmount = obj_da_Detail.getMaxlimitAmt(int.Parse(ddl_Section.SelectedValue.ToString()));
                if (Amount >= MaxAmount)
                {
                    lbl_AvailableLimit.Text = "Available Limit For " + ddl_Section.SelectedItem.Text + "=0";
                }
                if (MaxAmount >= Amount && MaxAmount >= double.Parse(txt_Amount.Text))
                {
                    obj_da_Detail.UpdInvestPlan(int.Parse(hid_Empid.Value.ToString()), ddl_plan.SelectedItem.Text, double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()), hid_Plan.Value.ToString(), int.Parse(ddl_Year.Text.Substring(0, 4)), DateTime.Parse("01/01/9999"), double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()));
                    ScriptManager.RegisterStartupScript(btn_SaveInv, typeof(Button), "HRM", "alertify.alert('Details Updated Successfully')", true);
                    logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 804, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/" + ddl_Year.Text.Substring(0, 4) + "/" + ddl_Section.SelectedItem.Text + "-" + txt_Amount.Text + "/U");
                    Fn_FillGrd();
                    Fn_ClearSave();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_SaveInv, typeof(Button), "HRM", "alertify.alert('Amount Must be Less than the Maxlimit Amount')", true);
                    txt_Amount.Text = "";
                }
            }
            btn_cancelinv.Text = "Cancel";
            fillyear();
        }
        protected void btn_cancelinv_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"] == "HR")
            {
                if (btn_cancelinv.Text == "Cancel")
                {
                    txt_Empcode.Focus();
                    Fn_Clear();
                }
                else
                {
                    this.Response.End();
                }
            }
            else
            {
                if (btn_cancelinv.Text == "Cancel")
                {
                    Fn_Clear();
                    txt_Empcode.Focus();
                }
                else
                {

                    Response.Redirect("../Home/Profile.aspx");
                }
            }
        }
        private void Fn_FillGrd()
        {
            if (ddl_Year.SelectedItem.Text != "" && txt_Empcode.Text.TrimEnd().Length > 0)
            {
                DataAccess.Payroll.Details obj_da_detail = new DataAccess.Payroll.Details();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_detail.SelInvestPlan(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.Text.Substring(0,4)));
                if (obj_dt.Rows.Count > 0)
                {
                    Grd.DataSource = obj_dt;
                    Grd.DataBind();
                }
                else
                {
                    if (txt_Empcode.Text.ToString().TrimEnd().Length > 0)
                    {
                        int int_PayMonth = 4, int_PayYear = Convert.ToInt32(ddl_Year.Text.Substring(0, 4));
                        double Total = 0, PayTotal = 0;
                        for (int i = 0; i <= 11; i++)
                        {
                            PayTotal = obj_da_detail.Getpfamt4invest(int.Parse(hid_Empid.Value.ToString()), int_PayMonth, int_PayYear);
                            Total = Total + PayTotal;
                            if (int_PayMonth % 12 == 0)
                            {
                                int_PayMonth = 1;
                                int_PayYear++;
                            }
                            else
                            {
                                int_PayMonth++;
                            }
                        }
                        obj_da_detail.InsInvestPlan(int.Parse(hid_Empid.Value.ToString()), "PF", Total, 6, Convert.ToInt32(ddl_Year.Text.Substring(0, 4)), logobj.GetDate());
                        Fn_FillGrd();
                    }
                }
            }
        }

        private void Fn_ClearSave()
        {
            txt_Detail.Text = "";
           // txt_PlanDetail.Text = "";

            ddl_plan.SelectedItem.Text="";
            txt_Amount.Text = "";
            lbl_AvailableLimit.Text = "";
            lbl_MaxLimit.Text = "";
            btn_SaveInv.Text = "Save";
          //  ddl_Year.SelectedIndex = 0;
        }
        private void Fn_Clear()
        {
            txt_ActualRent.Text = "";
            txt_Basic50.Text = "";
            //txt_Company.Text = "";
            //txt_Dept.Text = "";
            //txt_Desg.Text = "";
            txt_Detail.Text = "";
            //txt_DOJ.Text = "";
            txt_Empcode.Text = "";
            //txt_Grade.Text = "";
            txt_HRA.Text = "";
            txt_Income.Text = "";
            //txt_Name.Text = "";
            txt_RentExp.Text = "";
            txt_RentPaid.Text = "";

            Grd.DataSource = new DataTable();
            Grd.DataBind();

            Fn_ClearSave();
            btn_cancelinv.Text = "Back";
        }
        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grd.SelectedRow.Cells[2].Text.TrimEnd() != "PF")
            {
                if (hid_confirm.Value.ToString() == "N" ||hid_confirm.Value.ToString()=="")
                {
                    txt_Detail.Text = Grd.SelectedRow.Cells[1].Text.TrimEnd();
                    //txt_PlanDetail.Text = Grd.SelectedRow.Cells[2].Text.TrimEnd();
                    //hid_Plan.Value = txt_PlanDetail.Text;

                    ddl_plan.SelectedIndex = ddl_plan.Items.IndexOf(ddl_plan.Items.FindByText(Grd.SelectedRow.Cells[2].Text.TrimEnd()));
                    hid_Plan.Value = Grd.SelectedRow.Cells[2].Text.TrimEnd();
                    txt_Amount.Text = Grd.SelectedRow.Cells[3].Text.ToString().Replace(",", "");
                    ddl_Section.SelectedIndex = ddl_Section.Items.IndexOf(ddl_Section.Items.FindByText(Grd.SelectedRow.Cells[0].Text.TrimEnd()));
                    btn_SaveInv.Text = "Update";
                    ddl_Section_SelectedIndexChanged(sender, e);
                }
                else if (hid_confirm.Value.ToString() == "Y")
                {
                    DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
                    //obj_da_Detail.DelInvestPlan(int.Parse(hid_Empid.Value.ToString()), Grd.SelectedRow.Cells[2].Text.TrimEnd(), int.Parse(ddl_Year.Text.Substring(0, 4)));

                    obj_da_Detail.DelInvestPlan(int.Parse(hid_Empid.Value.ToString()), Grd.SelectedRow.Cells[2].Text.Trim(), int.Parse(ddl_Year.Text.Substring(0, 4)), Convert.ToInt32(Grd.SelectedDataKey["sectionid"].ToString()));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Deleted Successfully')", true);
                    Fn_FillGrd();
                    fillyear();
                    hid_confirm.Value = "N";
                }
            }
            btn_cancelinv.Text = "Cancel";
        }

        protected void ddl_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Detail.GetSection();
            if (obj_dt.Rows.Count > 0)
            {
                var Result = obj_dt.AsEnumerable().Where(row => row.Field<Int16>("secid") == int.Parse(ddl_Section.SelectedValue.ToString())).ToList();
                if (Result.Count > 0)
                {
                    txt_Detail.Text = Result[0]["secname"].ToString();
                }
            }
            if (txt_Empcode.Text.ToString().TrimEnd().Length > 0)
            {
                double Amount = obj_da_Detail.getInvesTotAmt(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.Text.Substring(0, 4)));
                double MaxAmount = obj_da_Detail.getMaxlimitAmt(int.Parse(ddl_Section.SelectedValue.ToString()));

                lbl_AvailableLimit.Text = "Available Limit For " + ddl_Section.SelectedItem.Text + " = " + (MaxAmount - Amount).ToString();
                lbl_MaxLimit.Text = "Maximum Limit For " + ddl_Section.SelectedItem.Text + " = " + MaxAmount.ToString();
            }
            btn_cancelinv.Text = "Cancel";
        }
        protected void lnk_section_Click(object sender, EventArgs e)
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            str_RptName = "/Payroll" + "rptHRSection.rpt";
            if (txt_Empcode.Text == "")
            {
                str_sp = "year=" + ddl_Year.Text.Substring(0, 4);
                str_sf = "{HREmpInvestDetails.fy}=" + Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(0, 4));

            }
            else
            {
                str_sp = "";
                str_sf = "";

            }
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

            ScriptManager.RegisterStartupScript(lnk_section, typeof(LinkButton), "HRM", "alertify.alert('Job Not Available');", true);
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            btn_cancelinv.Text = "Cancel";
        }
        protected void ddl_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int fyear = Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(0, 4));
            //if(txt_Empcode.Text!="")
            //{
            //    eid = Convert.ToInt32();
            //}
        }
        public DateTime dt_date { get; set; }

        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void txt_ActualRent_TextChanged(object sender, EventArgs e)
        {
          
            DateTime sfrom,sto;
            DataAccess.PAYROLL.RentDetailss objRentt = new DataAccess.PAYROLL.RentDetailss();
            DataTable dt3;
            int a, b, j, m, y, y1;
            double k = 0.0, n=0.0;
            DateTime da, db;
               j = 0;
               n = 0;
               fyear =Convert.ToInt32(ddl_Year.Text.Substring(0, 4));
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                if (txt_ActualRent.Text.TrimEnd().Length > 0)
                {
                    if (RP == ARP)
                    {

                         sfrom = Convert.ToDateTime("04/1/" + fyear.ToString());
                        sto = Convert.ToDateTime("03/31/" + (fyear + 1).ToString());
                        dt3 = objRentt.GetHRRentBasic(124, sfrom, sto);

                          if(dt3.Rows.Count > 0)
                        {
                              for(m=0;m<=dt3.Rows.Count-1;m++)
                              {
                                  da = Convert.ToDateTime(dt3.Rows[m]["sfrom"].ToString());
                                  a = da.Month;
                                  db = Convert.ToDateTime(dt3.Rows[m]["sto"].ToString());
                                  b =db.Month;
                                  y = da.Year;
                                  y1 = db.Year;
                                   if ((y + 1)==y1)
                                  {
                                      b = 12 + b;
                                  }
                                  for(int i=a;i<b;i++)
                                  {
                                      if(i>=4)
                                      {
                                          j = j + 1;
                                      }
                                  }
                                  double bas = Convert.ToDouble(dt3.Rows[m]["basic"].ToString());
                                  k = bas * j;
                                     j = 0;
                             n = n + k;

                              }
                       }



                          double  ren = 0;
        double  actu = 0;
        double rent = 0;
       double bas1 = 0.0;
       bas1 = Convert.ToDouble(hid_basicamt.Value) / 12;
        rent = Convert.ToDouble(Convert.ToDouble(bas1 / 100) * 10);
        ren = rent * 12;
        actu = Convert.ToDouble(Convert.ToDouble(txt_ActualRent.Text) - ren);

                      //  double Amount = double.Parse(txt_ActualRent.Text) - (((BASIC / 100) * 10) * 12);
        if (actu > 0)
                        {
                            txt_RentPaid.Text = string.Format("{0:0}", actu);
                        }
                        else
                        {
                            txt_RentPaid.Text = "0";
                        }

                        RentPaid = double.Parse(txt_ActualRent.Text);

                        txt_ActualRent.Text = RentPaid.ToString();

                       double ActualAmount = 0, Rentreceived = 0, RentPaidAmount = 0, Basic50 = 0, TotAmount = 0;

                       //if (Convert.ToDouble(txt_ActualRent.Text) < Convert.ToDouble(txt_HRA.Text) && Convert.ToDouble(txt_ActualRent.Text) < Convert.ToDouble(txt_RentPaid.Text) && Convert.ToDouble(txt_ActualRent.Text) < Convert.ToDouble(txt_Basic50.Text))
                       // {
                       //     TotAmount = Convert.ToDouble(txt_ActualRent.Text);
                       // }
                       //else if (Convert.ToDouble(txt_HRA.Text) < Convert.ToDouble(txt_ActualRent.Text)&&)
                       //{

                       //}

                        ActualAmount = double.Parse(txt_ActualRent.Text);
                        Rentreceived = double.Parse(txt_HRA.Text.ToString());
                        RentPaidAmount = double.Parse(txt_RentPaid.Text);
                        Basic50 = double.Parse(txt_Basic50.Text);
                        double[] RentAmount = { ActualAmount, Rentreceived, RentPaidAmount, Basic50 };
                        TotAmount = RentAmount.Min();
                       



                        DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
                        obj_da_Rent.HRInsRentDetailsWeb(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.Text.Substring(0, 4)), ActualAmount, Rentreceived, RentPaidAmount, TotAmount, Basic50);
                        logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 804, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/" + ddl_Year.Text.Substring(0, 4) + "/ Actual Rent -" + txt_ActualRent.Text + "/U");
                        ScriptManager.RegisterStartupScript(txt_ActualRent, typeof(TextBox), "HRM", "alertify.alert('Rent Paid Updated Successfully');", true);
                        txt_RentExp.Text = TotAmount.ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(txt_ActualRent, typeof(TextBox), "HRM", "alertify.alert('Proof Received...Hence you canot update');", true);
                        ddl_Section.Focus();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_ActualRent, typeof(TextBox), "HRM", "alertify.alert('Actual Rent Cannot Be Blank');", true);
                    txt_ActualRent.Focus();
                }
            }
            btn_cancelinv.Text = "Cancel";
        }

        private void Fn_GetDetail()
        {
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            DataAccess.Payroll.Details obj_da_detail = new DataAccess.Payroll.Details();

            int int_Empid = obj_da_Employee.GetEmpId(txt_Empcode.Text);
            hid_Empid.Value = int_Empid.ToString();
            obj_dt = obj_da_detail.GetEmpDetails(int_Empid);
            if (obj_dt.Rows.Count > 0)
            {
                /*txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                txt_Company.Text = obj_dt.Rows[0]["branchname"].ToString();
                txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                txt_DOJ.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["doj"].ToString());
                */
                var Result = obj_dt.AsEnumerable().Where(row => row.Field<Int16>("branch") == int.Parse("11315") ||
                    row.Field<Int16>("branch") == int.Parse("11288") ||
                    row.Field<Int16>("branch") == int.Parse("11312") ||
                    row.Field<Int16>("branch") == int.Parse("11289") ||
                    row.Field<Int16>("branch") == int.Parse("13906")).ToList();
                if (Result.Count > 0)
                {
                    hid_Amount.Value = "50";
                }
                else
                {
                    hid_Amount.Value = "40";
                }
                Fn_LoadDLL();
                Fn_FillGrd();
                Fn_GetIncomeDetail();
                Fn_GetAmountDetail();



            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter The Correct EmployeeCode');", true);
                txt_Empcode.Text = "";
                txt_Empcode.Focus();
            }
        }
        private void Fn_LoadDLL()
        {
            ddl_Section.Items.Clear();
            ddl_Section.Items.Add("");
            DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Detail.GetSection();
            if (obj_dt.Rows.Count > 0)
            {
                ddl_Section.DataSource = obj_dt;
                ddl_Section.DataTextField = "seccode";
                ddl_Section.DataValueField = "secid";
                ddl_Section.DataBind();
            }
        }


        private void Fn_Loadplan()
        {
            ddl_plan.Items.Clear();
            ddl_plan.Items.Add("");
            DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Detail.Getplandetails();
            if (obj_dt.Rows.Count > 0)
            {
                ddl_plan.DataSource = obj_dt;
                ddl_plan.DataTextField = "categoryname";
                ddl_plan.DataValueField = "categoryid";
                ddl_plan.DataBind();
            }
        }




        private void Fn_GetIncomeDetail()
        {
            DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
            DataTable obj_dt = new DataTable();
            // obj_dt = obj_da_Rent.GetHouseRent(int.Parse(txt_Empcode.Text), int.Parse(ddl_Year.SelectedValue.ToString()));
            obj_dt = obj_da_Rent.GetHouseRent(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.Text.Substring(0,4)));
            if (obj_dt.Rows.Count > 0)
            {
                txt_Income.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["income"]);
            }
        }
        private void Fn_GetAmountDetail()
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0 && ddl_Year.SelectedItem.Text != "")
            {
                double temp = 0, temp1 = 0;
                DataAccess.PayrollProcess obj_da_PayRoll = new DataAccess.PayrollProcess();
                DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
                DataAccess.Payroll.ITComputation obj_it = new DataAccess.Payroll.ITComputation();
                DataTable obj_dt = new DataTable();
                fyear = Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(2, 2));
                DtForm = DateTime.Parse("11/1/" + fyear);
                //investnew();
                //if (Session["StrTranType"].ToString() == "HR")
                //{
                //    obj_dt = obj_da_PayRoll.GetEmpSalaryDetails(int.Parse(hid_Empid.Value.ToString()), dt_date);
                //}
                //else
                //{
                //    obj_dt = obj_da_PayRoll.GetEmpSalaryDetails(int.Parse(Session["LoginEmpId"].ToString()), dt_date);
                //}
                investnew();
                if (Session["StrTranType"].ToString() == "HR")
                {
                    obj_dt = obj_it.GetITDet(int.Parse(hid_Empid.Value.ToString()), Convert.ToDateTime(H_fromDate.Value), Convert.ToDateTime(H_ToDate.Value), Convert.ToDateTime(h_date.Value));
                }
                else
                {
                    obj_dt = obj_it.GetITDet(int.Parse(Session["LoginEmpId"].ToString()), Convert.ToDateTime(H_fromDate.Value), Convert.ToDateTime(H_ToDate.Value), Convert.ToDateTime(h_date.Value));
                }
                for (int i = 0; i <= obj_dt.Rows.Count; i++)
                {
                    if (obj_dt.Rows[i]["HeaderName"].ToString() == "BASIC")
                    {
                        var chosenRow = (from row in obj_dt.AsEnumerable() where row.Field<string>("HeaderName") == "BASIC" select row).First();
                        if (chosenRow != null)
                        {
                            temp = Convert.ToDouble(chosenRow[2]);
                            txt_Basic50.Text = temp.ToString("#0.00");
                            hid_basicamt.Value = txt_Basic50.Text;
                            continue;
                        }
                        else
                        {
                            txt_Basic50.Text = "0.00";

                        }
                    }
                
                    else if (obj_dt.Rows[i]["HeaderName"].ToString() == "HRA")
                    {
                        var chosenRow = (from row in obj_dt.AsEnumerable() where row.Field<string>("HeaderName") == "HRA" select row).First();
                        if (chosenRow != null)
                        {
                            temp1 = Convert.ToInt32(chosenRow[2]);
                            txt_HRA.Text = temp1.ToString("#0.00");
                            break;
                        }
                        else
                        {
                            txt_HRA.Text = "0.00";

                        }
                    }

                    txt_Basic50.Text = string.Format("{0:0.00}", (((BASIC * int.Parse(hid_Amount.Value.ToString())) / 100) * 12));
                }
                if (obj_dt.Rows.Count > 0)
                {
                    double HRA = 0;
                    //BASIC = double.Parse(obj_dt.Rows[0]["basic"].ToString());
                    //HRA = double.Parse(obj_dt.Rows[0]["hra"].ToString())*12;
                 //   txt_HRA.Text = string.Format("{0:0.00}", temp1);

                    txt_Basic50.Text = string.Format("{0:0.00}", ((Convert.ToDecimal(temp / 12) * int.Parse(hid_Amount.Value.ToString())) / 100) * 12);
                    if (Session["StrTranType"].ToString() == "HR")
                    {
                        obj_dt = obj_da_Rent.HRGetRentDetails(int.Parse(hid_Empid.Value), fyear);
                    }
                    else
                    {
                        obj_dt = obj_da_Rent.HRGetRentDetails(int.Parse(Session["LoginEmpId"].ToString()), fyear);
                    }
                    if (obj_dt.Rows.Count > 0)
                    {
                        RP = double.Parse(obj_dt.Rows[0]["rp"].ToString());
                        ARP = double.Parse(obj_dt.Rows[0]["arp"].ToString());

                        txt_ActualRent.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rp"]);
                        txt_HRA.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rr"]);
                        txt_RentExp.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["taxrebate"]);
                        if (obj_dt.Rows[0]["rb"].ToString().TrimEnd().Length > 0)
                        {
                            txt_RentPaid.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rb"]);
                        }
                    }
                    else
                    {
                        txt_ActualRent.Text = "0";
                        txt_RentPaid.Text = "0";
                    }
                }
                else
                {
                    txt_HRA.Text = "0.00";
                    txt_Basic50.Text = "0.00";
                    txt_ActualRent.Text = "0.00";
                    txt_RentPaid.Text = "0.00";
                }
            }
        }

        public void investnew()
        {
            fyear = Convert.ToInt32("20" + ddl_Year.SelectedItem.ToString().Substring(2, 2));
            if (fyear < curyear)
            {
                if (curmonth >= 4)
                {
                    curmonth = 3;
                    curyear = fyear + 1;
                    getmonth = 3;
                    dtdate = Convert.ToDateTime(getmonth + "/05/" + (curyear));
                }
                else
                {
                    curmonth = logobj.GetDate().Month;
                    curyear = logobj.GetDate().Year;
                    getmonth = curmonth;
                    dtdate = Convert.ToDateTime(getmonth + "/05/" + (curyear));
                    h_date.Value = dtdate.ToShortDateString();
                }
            }
            else
            {
                curmonth = logobj.GetDate().Month;
                curyear = logobj.GetDate().Year;
                getmonth = curmonth;
                dtdate = Convert.ToDateTime(getmonth + "/05/" + (curyear));
                h_date.Value = dtdate.ToShortDateString();
            }

            dt_date = Convert.ToDateTime("04/01/" + fyear);
            H_fromDate.Value = dt_date.ToShortDateString();
            DtTo = Convert.ToDateTime("03/31/" + Convert.ToInt32(fyear + 1).ToString());
            H_ToDate.Value = DtTo.ToString();

        }
        protected void btn_Viewinv_Click(object sender, EventArgs e)
        {
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Str_RptName = "/Payroll" + "/RptHRInvestApp.rpt";
            if (txt_ActualRent.Text.TrimEnd().Length > 0)
            {
                Str_sp = "year=" + ddl_Year.Text.Substring(2, 2) + " - " + ddl_Year.SelectedItem.Text.ToString().Substring(7, 2) + "~tenperbasic=" + txt_Basic50.Text + "~atualpaid=" + txt_ActualRent.Text;
            }
            else
            {
                Str_sp = "year=" + ddl_Year.Text.ToString().Substring(2, 2) + " - " + ddl_Year.SelectedItem.Text.ToString().Substring(7, 2) + "~tenperbasic=" + txt_Basic50.Text + "~atualpaid=" + RentPaid;
            }
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                Str_sf = " {HREmpInvestDetails.empid} = " + hid_Empid.Value.ToString() + " and {HREmpInvestDetails.fy} = " + ddl_Year.Text.Substring(0, 4);
            }
            else
            {
                Str_sf = "{HREmpInvestDetails.fy}=" + ddl_Year.Text.Substring(0, 4);
            }
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_Viewinv, typeof(Button), "HRM", Str_Script, true);
        }
        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_ActualRent.Text.TrimEnd().Length > 0)
            {
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_FileName = "", str_Script = "";
                Str_RptName = "/Payroll" + "/RptHRInvestApp.rpt";
                Str_sp = "year=" + ddl_Year.Text.Substring(2, 2) + " \" " + ddl_Year.SelectedItem.Text.ToString().Substring(7, 2) + "~tenperbasic=" + txt_Basic50.Text + "~atualpaid=" + txt_ActualRent.Text;
                Str_sf = "{MasterEmployee.Employeeid}=" + Session["LoginEmpId"].ToString() + "and {HREmpInvestDetails.fy}=" + ddl_Year.Text.Substring(0, 4);
                Str_FileName = Server.MapPath("~/UploadDocument/") + txt_Empcode.Text;
                //logix.Tools.ReportView obj_RptExport = new Tools.ReportView();
                //obj_RptExport.showReportExport(Str_RptName, Str_sp, Str_sf, Str_FileName);
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_Confirm, typeof(Button), "JobInfo", str_Script, true);
                string Str_subject = "Investment Plan For " + txt_Empcode.Text + ":" + txt_name.Text;
                Utility.SendMail(Session["usermailid"].ToString(), "", Str_subject, Fn_MailContent(Session["usermailid"].ToString()), Server.MapPath("~/UploadDocument/" + txt_Empcode.Text + ".pdf"), Session["usermailpwd"].ToString(), "", "");

            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Viewinv, typeof(Button), "HRM", "alertify.alert('Actual Rent Cannot Be Blank');", true);
                txt_ActualRent.Focus();
            }
            btn_cancelinv.Text = "Cancel";
        }
        private string Fn_MailContent(string strUserMail)
        {
            string Str_Temp = "";

            Str_Temp = Str_Temp + Utility.Fn_GetCompanyAddress();
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT>";
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2><br><br>Please find the attachment</FONT>";
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2><br><br><br><br><br>Thanks & Best Regards,</FONT>";
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2><br>" + txt_Empcode.Text + "</FONT>";
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2><br>" + " Email : " + strUserMail + "</FONT>";

            return Str_Temp;
        }

        protected void btnsavekpi_Click(object sender, EventArgs e)
        {
            if (txt_KPI.Text.ToUpper().Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('KPI Does not Blank');", true);
                txt_KPI.Focus();
                return;
            }
            txt_Weightage_TextChanged(sender, e);
            if (weightkpi == true)
            {
                return;
            }
            findexistdtls();
            if (weightkpi==true)
            {
                return;
            }
           
            savedetail();
         
        }
        public void findexistdtls()
        {
            string strkpi;
            totwage = 0;
            if (gridview.Rows.Count > 0)
            {
                for (int i = 0; i <= gridview.Rows.Count - 1; i++)
                {
                    wage = Convert.ToInt32(gridview.Rows[i].Cells[3].Text);
                    totwage = totwage + wage;
                    strkpi = "";
                    if (btnsavekpi.Text == "Save")
                    {
                        strkpi = HttpUtility.HtmlDecode(gridview.Rows[index].Cells[2].Text.ToUpper().ToString().Replace("&AMP;", "&")); // gridview.Rows[i].Cells[2].Text;
                        if (txt_KPI.Text.ToUpper().Trim() == strkpi)
                        {
                            ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Already Exist');", true);
                            txt_KPI.Text = "";
                            txt_KPI.Focus();
                            weightkpi = true;
                            return;
                        }
                    }
                    else if (btnsavekpi.Text == "Update")
                    {
                        strkpi = HttpUtility.HtmlDecode(gridview.Rows[index].Cells[2].Text.ToUpper().ToString().Replace("&AMP;", "&")); //gridview.Rows[i].Cells[2].Text;
                        int kppi = Convert.ToInt32(hidkpiid.Value);
                        if (txt_KPI.Text.ToUpper().Trim() == strkpi && kppi != Convert.ToInt32(gridview.Rows[i].Cells[4].Text))
                        {
                            ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Already Exist');", true);
                            txt_KPI.Focus();
                            weightkpi = true;
                            return;
                        }
                    }
                    else
                    {
                        strkpi = HttpUtility.HtmlDecode(gridview.Rows[index].Cells[2].Text.ToUpper().ToString().Replace("&AMP;", "&"));//gridview.Rows[index].Cells[2].Text;

                    }
                    
                }
            }
        }
        
        public void savedetail()
        {
          
            // fyear = Convert.ToInt32(hidfyear.Value);
            if (oldcname == "")
            {
                oldcname = hidoldcname.Value;
            }
            if (btnsavekpi.Text == "Save")
            {
                totwage = totwage + Convert.ToInt32(txt_Weightage.Text);
                hidkpiid.Value = "0";
            }
            else if (btnsavekpi.Text == "Update")
            {
                oldtage =Convert.ToInt32(hidoldtage.Value);
                totwage = (totwage - oldtage) + Convert.ToInt32(txt_Weightage.Text);

            }
            if (totwage <= 70)
            {
                eid = emp.GetEmpId(Session["LoginUserName"].ToString());
               
             
                string coapp = "", appston = "";

                fyear = Convert.ToInt32(cmbYearkbi.SelectedItem.ToString().Substring(0, 4));
                dt = objdet.GetKpiDtlsnew(eid, fyear);
                if (dt.Rows.Count > 0)
                {

                    if (!string.IsNullOrEmpty(dt.Rows[0]["CoApprovalOn"].ToString()))
                    {
                        coapp = "1";
                    }
                    else
                    {
                        coapp = "0";
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["appstartedon"].ToString()))
                    {
                        appston = "1";
                    }
                    else
                    {
                        appston = "0";
                    }

                }
                else
                {
                    coapp = "0";
                    appston = "0";
                }

                if (coapp == "1" || appston == "1")
                {
                    int yearnew = Convert.ToInt32(ddl_Year.Text) - 1;
                    ScriptManager.RegisterStartupScript(btnkpiyes, typeof(Button), "logix", "alertify.alert('Apprisal Already completed for " + yearnew + " - " + ddl_Year.Text + ".');", true);
                    txt_KPI.Text = "";
                    txt_Weightage.Text = "";
                    return;

                }
                else
                {
                    dt = objdet.GetInsUpdKpiDtls(eid, fyear, txt_KPI.Text.ToUpper().Trim(), Convert.ToInt32(txt_Weightage.Text), Convert.ToInt32(hidkpiid.Value));
                }
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Details Updated');", true);
                        fillgrid();
                        clr();
                        txt_KPI.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Details Saved');", true);
                        fillgrid();
                        clr();
                        txt_KPI.Focus();
                    }
                
               

            }
            else
            {
                int diff;
                diff = totwage - 70;
                ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Total Weightage For an Employee Should not be More Than 70');", true);
                oldcname = "";
                txt_Weightage.Text = "";
                txt_Weightage.Focus();
            }
        }

        public void fillgrid()
        {
            DataTable data = new DataTable();
            totwage = 0;
            fyear = Convert.ToInt32(hidfyear.Value);
            dt = objdet.GetKpiDtls(eid, fyear);
            data.Columns.Add("kpiyear");
            data.Columns.Add("kpi");
            data.Columns.Add("weightage");
            data.Columns.Add("kpiid");
            DataRow row;
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                row = data.NewRow();
                data.Rows.Add();
                data.Rows[i]["kpiyear"] = dt.Rows[i]["kpiyear"];
                data.Rows[i]["kpi"] = dt.Rows[i]["kpi"];
                data.Rows[i]["weightage"] = dt.Rows[i]["weightage"];
                weigt = Convert.ToInt32(dt.Rows[i]["weightage"].ToString());
                data.Rows[i]["kpiid"] = dt.Rows[i]["kpiid"];

                totwage = totwage + weigt;

            }
            gridview.DataSource = dt;
            gridview.DataBind();
        }
        public void clr()
        {
            txt_KPI.Text = "";
            txt_Weightage.Text = "";
            btnsavekpi.Text = "Save";
            //btnback.Text = "Back";
            oldcname = "";
        }
        protected void btnViewkpi_Click(object sender, EventArgs e)
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            str_RptName = "/Payroll" + "/rptKPI.rpt";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            str_sf = "{MasterEmployee.employeeid}=" + Session["LoginEmpId"];
            if (cmbyear.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Select the Year');", true);
                return;
            }
            else
            {
                str_sp = "FYyear=" + cmbYearkbi.SelectedValue.ToString() + "~Year=" + cmbYearkbi.SelectedValue.ToString().Trim().Substring(0, 4) + "~Empid=" + Session["LoginEmpId"];
            }
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnViewkpi, typeof(Button), "HRM", str_Script, true);
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
        }

        public void clrs()
        {
            btnsavekpi.Text = "Save";
            // btnback.Text = "Back";
            oldcname = "";
            txt_KPI.Focus();
        }

      

        protected void txt_Weightage_TextChanged(object sender, EventArgs e)
        {
            if (txt_Weightage.Text != "")
            {
                if (txt_Weightage.Text != "0")
                {
                    //if (Convert.ToInt32(txt_Weightage.Text) >= 21)
                    //{
                    //    ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Weightage Should Be Less than or Equal 20');", true);
                    //    weightkpi = true;
                    //    txt_Weightage.Focus();
                    //    return;
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "logix", "alertify.alert('Please Enter Only Numbers');", true);
                    //    txt_Weightage.Text = "";
                    //    txt_Weightage.Focus();
                    //}
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Weightage Should not Be Zero');", true);
                    weightkpi = true;
                    txt_Weightage.Focus();
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnsavekpi, typeof(Button), "logix", "alertify.alert('Weightage Should not Be Blank');", true);
                weightkpi = true;
                txt_Weightage.Focus();
                return;
            }
        }

        protected void btnlta_Click(object sender, EventArgs e)
        {
            pnl_Buying.Visible = true;
            Grd_buying_popup.Show();

        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            oldcname = "";

            eid = Convert.ToInt32(heid.Value);          
            fyear = Convert.ToInt32(hidfyear.Value);
            string coapp="",appston="";
            if (gridview.Rows.Count > 0)
            {
                dt = objdet.GetKpiDtlsnew(eid, fyear);
                if (dt.Rows.Count > 0)
                {

                    if(!string.IsNullOrEmpty(dt.Rows[0]["CoApprovalOn"].ToString()))
                    {
                        coapp = "1";
                    }
                    else
                    {
                        coapp = "0";
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["appstartedon"].ToString()))
                    {
                        appston = "1";
                    }
                    else
                    {
                        appston = "0";
                    }
                    
                }
                else
                {
                    coapp = "0";
                    appston = "0";
                }
                //DataAccess.HR.Employee objEmp = new DataAccess.HR.Employee();
                //DataTable DtTable = new DataTable();

                //DtTable = objEmp.apprisalcheckforitcomputation(Convert.ToInt32(Session["LoginEmpId"]));
                //if (DtTable.Rows.Count > 0)
                //{
               
                if (coapp == "1" || appston=="1")
                {
                    int yearnew = Convert.ToInt32(ddl_Year.Text)-1;
                    ScriptManager.RegisterStartupScript(btnkpiyes, typeof(Button), "logix", "alertify.alert('Apprisal Already completed for " + yearnew +" - " + ddl_Year.Text + ".');", true);
                    return;
                    
                }else 
                {
                    int index = gridview.SelectedRow.RowIndex;
                    txt_KPI.Text = HttpUtility.HtmlDecode(gridview.Rows[index].Cells[2].Text.ToUpper().ToString().Replace("&AMP;", "&"));


                    hidkpiid.Value = gridview.Rows[index].Cells[4].Text;
                    oldcname = HttpUtility.HtmlDecode(gridview.Rows[index].Cells[2].Text.ToUpper().ToString().Replace("&AMP;", "&"));
                    hidoldcname.Value = oldcname.ToString();
                    cmbyear.SelectedItem.Text = gridview.Rows[index].Cells[1].Text; // Convert.ToInt32(cmbYear.SelectedItem.ToString().Substring(0, 4)) //gridview.Rows[index].Cells[1].Text;
                    txt_Weightage.Text = gridview.Rows[index].Cells[3].Text;
                    oldtage = Convert.ToInt32(gridview.Rows[index].Cells[3].Text);
                    hidoldtage.Value = oldtage.ToString();
                    btnsavekpi.Text = "Update";

                    delkpi = "";
                    delkpi = HttpUtility.HtmlDecode(gridview.Rows[index].Cells[2].Text.ToUpper().ToString().Replace("&AMP;", "&"));
                    hiddelkpi.Value = delkpi.ToString();
                    PopUpService1.Show();
                }
                

               

               
                
            }
        }

        protected void btnkpiyes_Click(object sender, EventArgs e)
        {
            try
            {
                eid = Convert.ToInt32(heid.Value);
                delkpi = hiddelkpi.Value;
                fyear = Convert.ToInt32(hidfyear.Value);
                int hidk =Convert.ToInt32(hidkpiid.Value);
                objdet.DelKPIDetails(eid, delkpi, fyear, hidk);
                ScriptManager.RegisterStartupScript(btnkpiyes, typeof(Button), "logix", "alertify.alert('Details Deleted Successfully');", true);

                fillgrid();
                txt_KPI.Text = "";
                txt_Weightage.Text = "";
                txt_KPI.Focus();
                btnsavekpi.Text = "Save";


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void btnkpino_Click(object sender, EventArgs e)
        {
            return;
        }
        protected void gridview_RowDataBound1(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridview, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        private void Fn_LoadDYear()
        {
            /*DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            for (int i = Dt_Date.AddYears(-1).Year; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }*/

           /* DateTime dt_Date1 = obj_da_Log.GetDate();
            DataTable dtable1 = new DataTable();
            dtable1.Columns.Add("FAYear");
            string str_dispyear = "";
            int k = 0;
            if (dt_Date1.Month < 4)
            {
                for (int i = 2016; i <= dt_Date1.Year - 1; i++)
                {
                    dtable1.Rows.Add();
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(0, 4);
                    int dy = 0;
                    string dy1 = null;
                    dy1 = "";
                    dy = Convert.ToInt32(str_dispyear) + 1;
                    dy1 = Convert.ToString(dy);
                    str_dispyear = str_dispyear + "-" + dy1;
                    dtable1.Rows[k]["FAYear"] = str_dispyear;
                    k++;
                }
            }
            else
            {
                for (int i = 2016; i <= dt_Date1.Year; i++)
                {
                    dtable1.Rows.Add();
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(0, 4);
                    int dy = 0;
                    string dy1 = null;
                    dy1 = "";
                    dy = Convert.ToInt32(str_dispyear) + 1;
                    dy1 = Convert.ToString(dy);
                    str_dispyear = str_dispyear + "-" + dy1;
                    dtable1.Rows[k]["FAYear"] = str_dispyear;

                    k++;
                }
            }

            if ((logobj.GetDate().Month) < 4)
            {
                ddl_Year.DataSource = dtable1;
                ddl_Year.DataTextField = "FAYear";
                ddl_Year.DataBind();
            }
            else
            {
                ddl_Year.DataSource = dtable1;
                ddl_Year.DataTextField = "FAYear";
                ddl_Year.DataBind();

            }*/

            DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            for (int i = Dt_Date.AddYears(-1).Year; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 3)
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }
        }

        public void empdetail()
        {
            eid = emp.GetEmpId(Session["LoginUserName"].ToString());
            heid.Value = eid.ToString();
            dt = objdet.GetEmpDetails(eid);
            if (dt.Rows.Count > 0)
            {
                txt_Empcode.Text = dt.Rows[0]["username"].ToString();
                txt_dept.Text = dt.Rows[0]["deptname"].ToString();
                txt_desg.Text = dt.Rows[0]["designame"].ToString();
                txt_Grade.Text = dt.Rows[0]["grade"].ToString();
                txt_name.Text = dt.Rows[0]["empname"].ToString();
                fillalldts();

            }
            else
            {
                clear();
                txt_Empcode.Focus();
            }
        }
        public void fillalldts()
        {
            totwage = 0;
            DataTable data = new DataTable();
            eid = emp.GetEmpId(Session["LoginUserName"].ToString());
            fyear = Convert.ToInt32(hidfyear.Value);
            dt = objdet.GetKpiDtls(eid, fyear);
            data.Columns.Add("kpiyear");
            data.Columns.Add("kpi");         
            data.Columns.Add("weightage");
            data.Columns.Add("kpiid");
            DataRow row;
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                row = data.NewRow();
                data.Rows.Add();
                data.Rows[i]["kpiyear"] = dt.Rows[i]["kpiyear"];
                data.Rows[i]["kpi"] = dt.Rows[i]["kpi"];
                data.Rows[i]["kpiid"] = dt.Rows[i]["kpiid"];
                data.Rows[i]["weightage"] = dt.Rows[i]["weightage"];
                weigt = Convert.ToInt32(dt.Rows[i]["weightage"].ToString());
                totwage = totwage + weigt;
                
            }
            gridview.DataSource = dt;
            gridview.DataBind();

        }
        public void clear()
        {
            txt_KPI.Text = "";
            txt_Weightage.Text = "";
            btnsavekpi.Text = "Save";

        }

        protected void btnacc_Click(object sender, EventArgs e)
        {

            grdright();
            pln_KPI.Visible = true;
            popup_KPI.Show();

        }

        protected void btnlog_Click(object sender, EventArgs e)
        {
            Panel6.Visible = true;
            ModalPopupExtender1.Show();
            btn_get_Click(sender, e);
        }

        public void fillyear()
        {

            /*DateTime curdate,fromdate;
            int vyear;
            curdate = logobj.GetDate();
            vyear = Convert.ToInt32(Session["Vouyear"].ToString());
            if (curdate.Month >4)
            {
                 
            }


            
            if ((logobj.GetDate().Month) < 4)
            {
                cmbYearkbi.Text = ((logobj.GetDate()).Year - 1).ToString() + " - " + ((logobj.GetDate()).Year).ToString();
            }
            else
            {
                cmbYearkbi.Text = ((logobj.GetDate()).Year).ToString() + " - " + ((logobj.GetDate()).Year + 1).ToString();
            }
            */
           /* DateTime dt_Date = obj_da_Log.GetDate();
            DataTable dtable = new DataTable();
            dtable.Columns.Add("FAYear");
            string str_dispyear = "";
            int k = 0;
            int Prefyear = dt_Date.Year - 1;
            

            if (dt_Date.Month < 4)
            {
                for (int i = Prefyear; i <= dt_Date.Year - 1; i++)
                {
                    dtable.Rows.Add();
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(0, 4);
                    int dy = 0;
                    string dy1 = null;
                    dy1 = "";
                    dy = Convert.ToInt32(str_dispyear) + 1;
                    dy1 = Convert.ToString(dy);
                    str_dispyear = str_dispyear + "-" + dy1;
                    dtable.Rows[k]["FAYear"] = str_dispyear;
                    k++;
                }


            }
            else
            {
                for (int i = Prefyear; i <= dt_Date.Year; i++)
                {
                    dtable.Rows.Add();
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(0, 4);
                    int dy = 0;
                    string dy1 = null;
                    dy1 = "";
                    dy = Convert.ToInt32(str_dispyear) + 1;
                    dy1 = Convert.ToString(dy);
                    str_dispyear = str_dispyear + "-" + dy1;
                    dtable.Rows[k]["FAYear"] = str_dispyear;
                    k++;
                }
            }*/


           /* DateTime dt_Date1 = obj_da_Log.GetDate();
            DataTable dtable1 = new DataTable();
            dtable1.Columns.Add("FAYear");
            string str_dispyear = "";
            int k = 0;
            if (dt_Date1.Month < 4)
            {
                for (int i = 2016; i <= dt_Date1.Year - 1; i++)
                {
                    dtable1.Rows.Add();
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(0, 4);
                    int dy = 0;
                    string dy1 = null;
                    dy1 = "";
                    dy = Convert.ToInt32(str_dispyear) + 1;
                    dy1 = Convert.ToString(dy);
                    str_dispyear = str_dispyear + "-" + dy1;
                    dtable1.Rows[k]["FAYear"] = str_dispyear;
                    k++;
                }
            }
            else
            {
                for (int i = 2016; i <= dt_Date1.Year; i++)
                {
                    dtable1.Rows.Add();
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(0, 4);
                    int dy = 0;
                    string dy1 = null;
                    dy1 = "";
                    dy = Convert.ToInt32(str_dispyear) + 1;
                    dy1 = Convert.ToString(dy);
                    str_dispyear = str_dispyear + "-" + dy1;
                    dtable1.Rows[k]["FAYear"] = str_dispyear;

                    k++;
                }
            }



            if ((logobj.GetDate().Month) < 4)
            {
                cmbYearkbi.DataSource = dtable1;
                cmbYearkbi.DataTextField = "FAYear";
                cmbYearkbi.DataBind();
            }
            else
            {
                cmbYearkbi.DataSource = dtable1;
                cmbYearkbi.DataTextField = "FAYear";
                cmbYearkbi.DataBind();
            }
            */



            DateTime Dt_Date = obj_da_Log.GetDate();
            cmbYearkbi.Items.Clear();
            for (int i = 2016; i < Dt_Date.Year; i++)
            {
                cmbYearkbi.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                cmbYearkbi.SelectedIndex = cmbYearkbi.Items.IndexOf(cmbYearkbi.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                cmbYearkbi.SelectedIndex = cmbYearkbi.Items.IndexOf(cmbYearkbi.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }
            hidfyear.Value = cmbYearkbi.Text.Substring(0, 4);

            // fyear = Convert.ToInt32(cmbYearkbi.SelectedItem.ToString().Substring(0, 4));
        }

        protected void cmbYearkbi_SelectedIndexChanged(object sender, EventArgs e)
        {
           // fyear = cmbYearkbi.SelectedIndex;

            fyear = Convert.ToInt32(cmbYearkbi.SelectedItem.ToString().Substring(0, 4));
            hidfyear.Value = fyear.ToString();
            txt_KPI.Text = "";
            txt_Weightage.Text = "";
            btnsavekpi.Text = "Save";
            fillalldts();
        }

        protected void btnappraisal_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtemp = new DataTable();
            int employeeid = 0;
            int year = 0;
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());

            dtemp = da_obj_Employee.GetEmpForKPI(employeeid);
            if (dtemp.Rows.Count > 0)
            {
                dt = AppraObj.GetHRKPISubmit(employeeid, year);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btnappraisal, typeof(Button), "HRM", "alertify.alert('Appraisal already submitted, you cannot Appraise again');", true);
                    return;
                }
                else
                {
                    Response.Redirect("../Home/AppPage1.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnappraisal, typeof(Button), "HRM", "alertify.alert('No KPI is Updated,Kindly Insert KPI before Appraise.');", true);
                return;
            }

        }

        protected void btnpwd_Click(object sender, EventArgs e)
        {
            string profile = "profile";
            Response.Redirect("../ForwardExports/EmpchangePass.aspx?profile=" + profile); 


            
        }

        protected void EmptyCheck()
        {
            if (ddl_Section.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select Section')", true);
                err = true;
                ddl_Section.Focus();
                return;
            }
            else if (ddl_plan.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Investment Plan Cannot Be Blank')", true);
                ddl_plan.Focus();
                err = true;
                return;
            }
            else if (txt_Amount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Amount Cannot Be Blank')", true);
                txt_Amount.Focus();
                err = true;
                return;
            }
            else if (txt_Amount.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Cannot Enter the Zero Amount')", true);
                txt_Amount.Focus();
                err = true;
                return;
            }
            else if (ddl_Year.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select Financial Year')", true);
                ddl_Year.Focus();
                err = true;
                return;
            }
        }

    }

}