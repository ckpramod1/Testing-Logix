using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Ionic.Zip;
using System.Collections.Generic;

namespace logix.HRM
{
    public partial class Accounts : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        public static int int_bid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_PDF);
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
                Fn_LoadDivision();
                DateTime dt_date = obj_da_Log.GetDate();
                ddl_Month.SelectedIndex = ddl_Month.Items.IndexOf(ddl_Month.Items.FindByValue(dt_date.Month.ToString()));
                txt_Year.Text = dt_date.Year.ToString();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "ddl_Month~txt_Year";
                str_MsgLists = "Month~Year";
                str_DataType = "DropDown~Integer";
                btn_View.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                btn_PDF.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                GridView1.Visible = false;
            }
        }
        public void Fn_LoadDivision()
        {
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDivisionhrm("M");
            ddl_company.DataSource = obj_dt;
            ddl_company.DataTextField = "divisionname";
            ddl_company.DataValueField = "divisionid";
            ddl_company.DataBind();
        }
        public void Fn_LoadBranch()
        {
            ddl_branch.Items.Clear();
            ddl_branch.Items.Add("ALL");
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.selBranchList(ddl_company.SelectedItem.Text);
            ddl_branch.DataSource = obj_dt;
            ddl_branch.DataTextField = "branchname";
            ddl_branch.DataBind();
        }

        protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_company.SelectedItem.Text == "ALL")
            {
                ddl_branch.Enabled = false;
            }
            else
            {
                ddl_branch.Enabled = true;
                Fn_LoadBranch();
            }
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            if (ddl_company.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Please Select a Company');", true);
                return;
            }
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Str_sf = "{HRPayroll.paymonth}=" + ddl_Month.SelectedValue.ToString() + " and {HRPayroll.payyear}=" + txt_Year.Text;
            if (ddl_company.SelectedItem.Text != "ALL")
            {
                Str_sf = Str_sf + " and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
            }
            if (ddl_branch.SelectedItem.Text != "ALL")
            {
                Str_sf = Str_sf + " and {HRPayroll.branchid}=" + int_bid;
            }
            Str_sp = "month=" + ddl_Month.SelectedItem.Text + "~yr=" + txt_Year.Text.ToString().Substring(2, 2);
            if (Rbt.Items[0].Selected == true)
            {
                Str_RptName = "/Payroll/" + "rptHRITax.rpt";
                Str_sf = Str_sf + "and {HRPayroll.itax}<>0";
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1132, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt.Items[1].Selected == true)
            {
                Str_RptName = "/Payroll/" + "rptHRGrossPF.rpt";
                Str_sf = Str_sf + "and {HRProfessionaltax.amount}<>0";
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1132, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt.Items[2].Selected == true)
            {
                Str_RptName = "/Payroll/" + "rptHRAllBranch.rpt";
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1132, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt.Items[3].Selected == true)
            {
                Str_RptName = "/Payroll/" + "rptHRESIReg.rpt";
                Str_sf = Str_sf + " and {HRPayroll.esi}<>0";
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1132, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt.Items[4].Selected == true)
            {
                Str_RptName = "/Payroll/" + "rptHRSalarySheet4Ac.rpt";
                Str_sp = "date=" + ddl_Month.SelectedItem.Text + " , " + txt_Year.Text;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1132, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt.Items[5].Selected == true)
            {
                Str_RptName = "/Payroll/" + "rptHRlwf.rpt";
                Str_sp = "month=" + ddl_Month.SelectedItem.Text + "~yr=" + txt_Year.Text.ToString().Substring(2, 2);
              //  Str_sp = "date=" + ddl_Month.SelectedItem.Text + " , " + txt_Year.Text;
                Str_sf = Str_sf + " and {HRPayroll.lwf}<>0";
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1132, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            int_bid = obj_da_Port.GetNPortid(ddl_branch.SelectedItem.Text);
        }

        protected void btn_PDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_company.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Please Select a Company');", true);
                    return;
                }

                string Str_FolderName = "~/UploadDocument1/" + ddl_Month.SelectedItem.Text + txt_Year.Text + @"\" + Rbt.SelectedValue.ToString();

                Session["Str_FolderName"] = Str_FolderName;
                DataAccess.HR.Employee obj_da_HrEmp = new DataAccess.HR.Employee();
                DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
                DataAccess.PayrollProcess obj_da_Payroll = new DataAccess.PayrollProcess();

                DataTable obj_dt = new DataTable();
                DataTable obj_dt_Branch = new DataTable();
                DataTable obj_dt_Export = new DataTable();
                int int_bid = 0, int_Divisionid = 0;
                string Str_FileName = "";
                int val = 0, count = 0;
                obj_dt = obj_da_HrEmp.GetDivision();
                logix.Tools.ReportView2 rpt = new Tools.ReportView2();
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    int_Divisionid = int.Parse(obj_dt.Rows[i]["divisionid"].ToString());
                    obj_dt_Branch = obj_da_HrEmp.selBranchList(obj_dt.Rows[i]["divisionname"].ToString().TrimEnd());
                    count += obj_dt_Branch.Rows.Count;
                    Session["Count"] = count;
                    for (int j = 0; j <= obj_dt_Branch.Rows.Count - 1; j++)
                    {
                        Str_FileName = obj_dt.Rows[i]["divsname"].ToString() + " - " + obj_dt_Branch.Rows[j]["branchname"].ToString();
                        Session["Str_FileName"] = Str_FileName;
                        int_bid = obj_da_Port.GetNPortid(obj_dt_Branch.Rows[j]["branchname"].ToString());
                        obj_dt_Export = obj_da_Payroll.GetITax4Monthyearbranch(int_Divisionid, int_bid, int.Parse(txt_Year.Text), int.Parse(ddl_Month.SelectedValue.ToString()), Rbt.SelectedValue.ToString());

                        Session["Rbt"] = Rbt.SelectedValue.ToString();
                        if (obj_dt_Export.Rows.Count > 0)
                        {
                            val += 1;
                            Session["j"] = val;
                            string Str_sp = "", Str_sf = "", Str_RptName = "";
                            Str_sf = "{HRPayroll.paymonth}=" + ddl_Month.SelectedValue.ToString() + " and {HRPayroll.payyear}=" + txt_Year.Text + " and {HRPayroll.divisionid}=" + int_Divisionid + " and {HRPayroll.branchid}=" + int_bid;

                            Str_sp = "month=" + ddl_Month.SelectedItem.Text + "~yr=" + txt_Year.Text.ToString().Substring(2, 2);
                            Session["str_sp"] = Str_sp;
                            if (Rbt.Items[0].Selected == true)
                            {
                                Str_RptName = "/Payroll/" + "rptHRITax.rpt";
                                Session["str_sfs"] = Str_sf + "and {HRPayroll.itax}<>0";
                                Session["Report2"] = Str_RptName;
                            }
                            else if (Rbt.Items[1].Selected == true)
                            {
                                Str_RptName = "/Payroll/" + "rptHRGrossPF.rpt";
                                Session["str_sfs"] = Str_sf + "and {HRProfessionaltax.amount}<>0";
                            }
                            else if (Rbt.Items[2].Selected == true)
                            {
                                Str_RptName = "/Payroll/" + "rptHRAllBranch.rpt";
                            }
                            else if (Rbt.Items[3].Selected == true)
                            {
                                Str_RptName = "/Payroll/" + "rptHRESIReg.rpt";
                                Session["str_sfs"] = Str_sf + " and {HRPayroll.esi}<>0";
                            }
                            else if (Rbt.Items[4].Selected == true)
                            {
                                Str_RptName = "/Payroll/" + "rptHRSalarySheet4Ac.rpt";
                                Session["str_sfs"] = "date=" + ddl_Month.SelectedItem.Text + " , " + txt_Year.Text;
                            }
                            else if (Rbt.Items[5].Selected == true)
                            {
                                Str_RptName = "/Payroll/" + "rptHRlwf.rpt";
                                Session["str_sfs"] = Str_sf + " and {HRPayroll.lwf}<>0";
                            }
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1132, 3, Convert.ToInt32(Session["LoginBranchid"]), "Pdf");
                            rpt.Page_Load(sender, e);

                        }


                    }

                }
                string[] filePaths = Directory.GetFiles(Server.MapPath(Str_FolderName));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                }
                GridView1.DataSource = files;
                GridView1.DataBind();

                using (ZipFile zip = new ZipFile())
                {
                    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                    zip.AddDirectoryByName("Files");
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //if ((row.FindControl("chkSelect") as CheckBox).Checked)
                        //{
                        string filePath =Server.MapPath(Session["Str_FolderName"].ToString()+"\\"+ row.Cells[0].Text);
                            zip.AddFile(filePath, "Files");
                        //}
                    }
                    Response.Clear();
                    Response.BufferOutput = false;
                    string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                    Response.ContentType = "application/zip";
                    Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                    zip.Save(Response.OutputStream);
                    Response.End();
                }
                


            }
            catch (Exception Ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Processor Usage...');" + Ex.Message, true);
            }
           
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
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
            Panel3.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1132, "", "", "", "");  //"/Rate ID: " +
            //if (txt_customer.Text != "")
            //{
            //    JobInput.Text = txt_customer.Text;


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