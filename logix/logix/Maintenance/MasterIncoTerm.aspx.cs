

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Web.Services.Description;
namespace logix.Maintenance
{
    public partial class MasterIncoTerm : System.Web.UI.Page
    {
        ////DataAccess.Masters.MasterUser ObjMUser = new DataAccess.Masters.MasterUser();
        DataAccess.Masters.MasterMaintenance mainobj = new DataAccess.Masters.MasterMaintenance();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        Boolean blerr;
        string ddvalue; string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                mainobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               
            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('https://demo.copperhawk.tech/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            


            if (!IsPostBack)
            {

                try
                {

                    GetIncoTermDetails4Grid();
                    if (Request.QueryString.ToString().Contains("incocode"))
                    {
                        txtIncoCode.Text = Request.QueryString["incocode"].ToString();
                        hid_Incocode.Value = Request.QueryString["incoid"].ToString();
                        //ddl_cmbChargeType.SelectedValue = Request.QueryString["chargetype"].ToString();
                        txtIncoCode_TextChanged(sender, e);
                    }
                    //ddtype.Enabled = true;
                    //Session["ddvalue"] = "";
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
        }

        [WebMethod]
        public static List<string> GetLikeIncoCode(string prefix)
        {

            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterMaintenance mainobj = new DataAccess.Masters.MasterMaintenance();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            mainobj.GetDataBase(Ccode);

            dt = mainobj.GetIncoCode(prefix);
                    list_result = Utility.Fn_TableToList(dt, "ICode", "ID");
                
                
            
            return list_result;

        }


       
        public void Validaion()
        {
            if (txtIncoCode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Inco Code Should Not Be Empty');", true);
                txtIncoCode.Focus();
                blerr = true;
                return;
            }
            else if (txtIncoDescription.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Inco Description Should Not Be Empty');", true);
                txtIncoDescription.Focus();
                blerr = true;
                return;

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Validaion();
            if (blerr == true)
            {
                blerr = false;
                return;
            }
            
                if (Btn_save.ToolTip == "Save")
                {
                    mainobj.InsertIncoDetails(txtIncoCode.Text, txtIncoDescription.Text);
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1992, 1, int.Parse(Session["LoginBranchid"].ToString()), "Ins Inco#-" + txtIncoCode.Text + "/" + txtIncoDescription.Text);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master IncoTerm", "alertify.alert('IncoTerm Details Saved Successfully');", true);
                    txtIncoCode.Text = "";
                    txtIncoDescription.Text = "";
                }
                else if (Btn_save.ToolTip == "Update")
                {
                    mainobj.UpdateIncoDetails(txtIncoCode.Text, txtIncoDescription.Text, Convert.ToInt32(hid_Incocode.Value));
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1992, 2, int.Parse(Session["LoginBranchid"].ToString()), "Upd Inco#-" + txtIncoCode.Text + "/" + txtIncoDescription.Text + "/" + Convert.ToInt32(hid_Incocode.Value));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master IncoTerm", "alertify.alert('IncoTerm Details Updated Successfully');", true);
                    txtIncoCode.Text = "";
                    txtIncoDescription.Text = "";
                }


                GetIncoTermDetails4Grid();
            Clear();
            //Btn_save.ToolTip = "Update";
            //div_save.Attributes["class"] = "btn btn-update";

        }

        public void GetIncoTermDetails4Grid()
        {

            
                    DataTable Dt = mainobj.GetIncogrid();
                    if (Dt.Rows.Count > 0)
                    {
                        GrdIncoTermDtls.DataSource = Dt;
                        GrdIncoTermDtls.DataBind();

                    }

         
        }



        
        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnBack.ToolTip == "Back")
                {
                    Clear();
                    this.Response.End();
                }
                else
                {
                    Clear();
                    btnBack.ToolTip = "Back";
                    btnBack1.Attributes["class"] = "btn ico-back";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void Clear()
        {
            txtIncoCode.Text = "";
            txtIncoDescription.Text = "";
            Btn_save.Text = "Save";
            Btn_save.ToolTip = "Save";
            div_save.Attributes["class"] = "btn ico-save";

        }
        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            if (Btn_cancel.ToolTip == "Cancel")
            {
                txtIncoCode.Text = "";
                txtIncoDescription.Text = "";
                Session["ddvalue"] = "";
                Btn_cancel.Text = "Back";
                Btn_cancel.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                Btn_save.Text = "Save";
                Btn_save.ToolTip = "Save";
                div_save.Attributes["class"] = "btn ico-save";
            }
            else
            {
                this.Response.End();
            }
        }
        protected void GrdIncoTermDtls_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GrdIncoTermDtls.SelectedRow.RowIndex;

                hid_Incocode.Value = GrdIncoTermDtls.Rows[index].Cells[0].Text;
                txtIncoCode.Text = GrdIncoTermDtls.Rows[index].Cells[1].Text;
                txtIncoDescription.Text = GrdIncoTermDtls.Rows[index].Cells[2].Text;
                Btn_save.Text = "Update";
                Btn_save.ToolTip = "Update";
                div_save.Attributes["class"] = "btn ico-update";
                Btn_cancel.Text="Cancel";
                Btn_cancel.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                GetIncoTermDetails4Grid();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void GrdIncoTermDtls_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdIncoTermDtls, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void txtIncoCode_TextChanged(object sender, EventArgs e)
        {
            

                //string descn = ObjMUser.GetColourDescn(Convert.ToInt32(hid_Colourcode.Value));
            string descn = mainobj.GetIncoDescn(Convert.ToInt32(hid_Incocode.Value));
            if ((Convert.ToInt32(hid_Incocode.Value)) == 0)
                {
                    txtIncoDescription.Text = "";
                    txtIncoDescription.Focus();
                    Btn_save.ToolTip = "Save";
                    Btn_save.Attributes["class"] = "btn ico-save";
                }
                else
                {
                    txtIncoDescription.Text = descn.ToString();
                Btn_save.Text = "Update";
                    Btn_save.ToolTip = "Update";
                    div_save.Attributes["class"] = "btn btn-update1";
                Btn_cancel.Text = "Cancel";
                    Btn_cancel.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
            
        }

        

    }
}