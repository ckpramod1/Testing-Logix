using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
namespace logix.HRM
{
    public partial class MasterQuation : System.Web.UI.Page
    {
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.HR.Questions QuestObj = new DataAccess.HR.Questions();
        DataTable Dt = new DataTable();
        DataTable DTA = new DataTable();       
        int i, DeptID, QHid, Quid;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            if (!IsPostBack)
            {
                txtConductedBy.Text = Session["LoginEmpName"].ToString();
                BindDept();
                Empty_grid();
                btnAdd.Enabled = false;
                BtnDelete.Enabled = false;
                txtOption4.Text = "Not Applicable";
            }

        }


        [WebMethod]
        public static List<string> GetQuestTitle(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.HR.Questions QuestObj = new DataAccess.HR.Questions();
            DataTable Dt = new DataTable();
            int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            Dt = QuestObj.GetLikeTitle(prefix, empid);
            if(Dt.Rows.Count > 0)
            {
                HttpContext.Current.Session["Title"] = Dt;
            }
            List_Result = Utility.Fn_TableToList(Dt, "qhtitle", "qhid");
            return List_Result;
        }
        protected void BindDept()
        {
            Dt = empobj.GetDept();
            ddlDepartment.DataTextField = "deptname";
            //ddlDepartment.DataValueField = "deptname";
            ddlDepartment.DataSource = Dt;
            ddlDepartment.DataBind();
            ddlDepartment.SelectedIndex =-1;
        }

        protected void Empty_grid()
        {
            Grd.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd.DataBind();
        }

        protected void ValidateDtls()
        {
            if (txtQuestion.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Question Cannot be Blank');", true);
                txtQuestion.Focus();               
                return;
            }

            if (txtOption.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Question Title Cannot be Blank');", true);
                 txtOption.Focus();              
                return;
            }

            if (txtOption1.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Option 1 Cannot be Blank');", true);
         
                txtOption1.Focus();                
                return;
            }

            if (txtOption2.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Option 2 Cannot be Blank');", true);
            
                txtOption2.Focus();               
                return;
            }


            if (txtOption3.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Option 3 Cannot be Blank');", true);
                
                txtOption3.Focus();               
                return;
            }

            if (txtOption4.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Option 4 Cannot be Blank');", true);
                           txtOption4.Focus();
             
                return;
            }
        }

        protected void ClrDtls()
        {
            txtQuestion.Text = "";
            txtOption.Text = "";
            txtOption1.Text = "";
            txtOption2.Text = "";
            txtOption3.Text = "";
         //   btnAdd.Text = "Add";

            btnAdd.ToolTip = "Add";
            btnAdd1.Attributes["class"] = "btn btn-add1";
            Quid = 0;
            txtQuestion.Focus();
        }


        protected void ClrHead()
        {
            txtQuextiontitle.Text = "";
            ddlDepartment.SelectedIndex = -1;
           // btnSave.Text = "Save";
            btnSave.ToolTip = "Save";
            btnSave1.Attributes["class"] = "btn ico-save";

            btnAdd.Enabled = false;
            QHid = 0;
            Empty_grid();
        }
        protected void ValidateHead()
        {
            if (txtQuextiontitle.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Question Title Cannot be Blank');", true);
              
                txtQuextiontitle.Focus();             
                return;
            }

            if (ddlDepartment.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Department Cannot be Blank');", true);
               
                ddlDepartment.Focus();              
                return;
            }
            else
            {
                DeptID = empobj.GetDeptid(ddlDepartment.Text);
                if (DeptID == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Invalid Department');", true);
                 
                    ddlDepartment.Focus();                 
                    return;
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            ValidateHead();
           
           
            if (btnSave.ToolTip == "Save")
            {
                QHid = QuestObj.InsQuestionHead((txtQuextiontitle.Text.Trim()), DeptID, Convert.ToInt32(Session["LoginEmpId"].ToString()));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 448, 1, int.Parse(Session["LoginBranchid"].ToString()), QHid + "/S");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Question Head Saved');", true);
              //  btnSave.Text = "Update";
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn btn-update1";

                btnAdd.Enabled = true;
            }
            else
            {
                DTA = (DataTable)Session["title"];
                QHid = Convert.ToInt32(DTA.Rows[0]["qhid"]);
                QuestObj.UpdQuestionHead((txtQuextiontitle.Text.Trim()), DeptID, QHid);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 448, 2, int.Parse(Session["LoginBranchid"].ToString()), QHid + "/U");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Question Head Updated');", true);
            }
        }

        protected void BindQDtls()
        {
            DTA = QuestObj.GetQDetails(QHid);
            if (DTA.Rows.Count > 0)
            {
                Grd.DataSource = DTA;
                Grd.DataBind();
            }
        }

      
        protected void txtQuextiontitle_TextChanged(object sender, EventArgs e)
        {
           
               if (Session["title"] != null)
               {
                   DTA = (DataTable)Session["title"];
                   QHid = Convert.ToInt32(DTA.Rows[0]["qhid"]);
                   if (QHid > 0)
                   {

                       DTA = QuestObj.GetQHead(QHid);
                       if (DTA.Rows.Count > 0)
                       {
                           txtQuextiontitle.Text = DTA.Rows[0][1].ToString();
                           ddlDepartment.Text = DTA.Rows[0][2].ToString();
                          // btnSave.Text = "Update";


                           btnSave.ToolTip = "Update";
                           btnSave1.Attributes["class"] = "btn btn-update1";
                           btnAdd.Enabled = true;
                           txtQuestion.Focus();
                       }

                       BindQDtls();
                   }
               }
              
          
    
            
        }

        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Grd.SelectedRow.RowIndex;
            if (Grd.Rows.Count > 0)
            {
                Quid = Convert.ToInt32(Grd.Rows[index].Cells[0].Text.ToString());
                hid_Qid.Value = Quid.ToString(); ;
                txtQuestion.Text = Grd.Rows[index].Cells[1].Text.ToString();
                txtOption.Text = Grd.Rows[index].Cells[2].Text.ToString();
                txtOption1.Text = Grd.Rows[index].Cells[3].Text.ToString();
                txtOption2.Text = Grd.Rows[index].Cells[4].Text.ToString();
                txtOption3.Text = Grd.Rows[index].Cells[5].Text.ToString();
                txtOption4.Text = Grd.Rows[index].Cells[6].Text.ToString();
               // btnAdd.Text = "Update";

                btnAdd.ToolTip = "Update";
                btnAdd1.Attributes["class"] = "btn btn-UpdateAdd2";
            }
        }

        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if(btnCancel.ToolTip=="Cancel")
            {
                ClrHead();
                ClrDtls();
                txtQuextiontitle.Focus();
             //   btnCancel.Text = "Back";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";

            }
            else
            {
                this.Response.End();
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClrDtls();
            Empty_grid(); 
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
           
            ValidateHead();

            if (btnAdd.ToolTip == "Add")
            {
                QuestObj.InsQuestionDtls(QHid, (txtQuestion.Text.Trim()), (txtOption.Text.Trim()), (txtOption1.Text.Trim()), (txtOption2.Text.Trim()), (txtOption3.Text.Trim()), (txtOption4.Text.Trim()));
                BindQDtls();
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 448, 1, int.Parse(Session["LoginBranchid"].ToString()), QHid + "/S");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Question Details Saved');", true);
            }

            else
            {
                DTA = (DataTable)Session["title"];
                QHid = Convert.ToInt32(DTA.Rows[0]["qhid"]);
                QuestObj.UpdQuestionDtls((txtQuestion.Text.Trim()), (txtOption.Text.Trim()), (txtOption1.Text.Trim()), (txtOption2.Text.Trim()), (txtOption3.Text.Trim()), (txtOption4.Text.Trim()), Convert.ToInt32(hid_Qid.Value), Convert.ToInt32(QHid));
                BindQDtls();
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 448, 2, int.Parse(Session["LoginBranchid"].ToString()), QHid + "/U");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Question Details Updated');", true);
            }
            ClrDtls();
        }

        
    }
}