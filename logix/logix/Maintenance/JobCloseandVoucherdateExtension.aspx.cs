using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class JobCloseandVoucherdateExtension : System.Web.UI.Page
    {
        int branchid;
        int portid;
        string divisionname;
        int closingdays;
        int backdatedays;
        DateTime getdate=DateTime.Now;
        //string jobclose;
        //string voucherdate;
        DataTable updtxt = new DataTable();
        //DataTable t2 = new DataTable();
        DataTable grid = new DataTable();
        DataTable getvoucher = new DataTable();
        DataTable getclosedate = new DataTable();
        DataAccess.Masters.MasterBranch mb = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterPort mp = new DataAccess.Masters.MasterPort();
        DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                mb.GetDataBase(Ccode);
                mp.GetDataBase(Ccode);
                da_obj_HrEmp.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               
            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if(!IsPostBack){
                loadcompany();
                loadbranch();
                
            }
            loadgrid();

            //JobClose();
            
            //JobClose();
            //ddl_branch.AppendDataBoundItems = true;
        }

        protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadbranch();
        }
        public void loadcompany()
        {
            //divisionid =Convert.ToInt32(Session["LoginDivisionId"]);
            divisionname = Session["LoginDivisionName"].ToString();
            //DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDivisionhrm("HR");

            ddl_company.Items.Add(Session["LoginDivisionName"].ToString());

            ddl_company.SelectedItem.Text = Session["LoginDivisionName"].ToString();
            //ddl_company.DataSource = Session["LoginDivisionName"].ToString();
            //DataTable t = new DataTable();
            
            ////ddl_company.DataTextField = "divisionid";
            ////ddl_company.DataValueField = "divisionname";
            //ddl_company.DataBind();
            //ddl_company.Items.Insert(0, new ListItem("company", ""));    
        }
        public void loadbranch()
        {
            ddl_branch.Items.Clear();
          //  DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.selBranchList(ddl_company.SelectedItem.Text);
            if (obj_dt.Rows.Count > 0)
            {
                ddl_branch.DataSource = obj_dt;
                ddl_branch.DataTextField = "branchname";
                ddl_branch.DataBind();
                ddl_branch.Items.Insert(0, new ListItem("", ""));
                //ddl_branch.AppendDataBoundItems = false;
            }
        }
        public void JobClose()
        {
            int divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            portid = mp.GetNPortid(ddl_branch.SelectedItem.Text);
            branchid = mb.GetBranchId(divisionid, portid, ddl_company.SelectedItem.ToString());
            HF_BranchId.Value = branchid.ToString();
            updtxt = mb.GetClosingdays(branchid);
            if (updtxt.Rows.Count > 0)
            {
                Text_jobclose.Text = updtxt.Rows[0]["closingdays"].ToString();
                Text_voucherdate.Text = updtxt.Rows[0]["backdatedays"].ToString();

            }
            getvoucher = mb.getvouincurrentmonth(Convert.ToInt32(HF_BranchId.Value));
            if(getvoucher.Rows.Count>0){
                Text_voucherdate.Enabled = false;    
            }
            else
            {
                Text_voucherdate.Enabled = true;
            }
            getclosedate = mb.getclosedate(Convert.ToInt32(HF_BranchId.Value));
            if(getclosedate.Rows.Count>0){
                Text_jobclose.Enabled = false;
            }
            else
            {
                Text_jobclose.Enabled = true;
            }
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_branch.SelectedItem.Text!=""){
                JobClose();   
            }              
        }
    
        public void loadgrid()
        {
            int divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            ////portid = mp.GetPortid(divisionid);
            ////branchid = mb.GetBranchId(divisionid, portid, ddl_company.SelectedItem.ToString());
            ////t3= mb.GetBranchJobvoucher(divisionid, branchid);
            grid = mb.GetBranchJobvoucher(divisionid);
            Grid_jobvoucher.DataSource = grid;
            Grid_jobvoucher.DataBind();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            ddl_branch.Text = "";
            Text_jobclose.Text = "";
            Text_voucherdate.Text = "";
        }

        protected void Update_Click(object sender, EventArgs e)
        {
           // DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            int divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            closingdays=int.Parse(Text_jobclose.Text);
            backdatedays=int.Parse(Text_voucherdate.Text);
            //portid = mp.GetNPortid(ddl_branch.SelectedItem.Text);
            //branchid = mb.GetBranchId(divisionid, portid, ddl_company.SelectedItem.ToString());
            mb.Updatejobclosebackdate(Convert.ToInt32(HF_BranchId.Value), closingdays, backdatedays);
            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1991, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_company.SelectedItem.Text + "/" + ddl_branch.SelectedItem.Text + "/" + Text_jobclose.Text + "/" + Text_voucherdate.Text + "/Upd");
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobCloseandVoucherdateExtension", "alertify.alert('Updated Successfully!');", true);
            loadgrid();
        }
    }
}