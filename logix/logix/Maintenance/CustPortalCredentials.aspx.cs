using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
namespace logix.Maintenance
{
    public partial class CustPortalCredentials : System.Web.UI.Page
    {
        bool blerr = false;
        string txtpanno = string.Empty;
        string txtcustomername = string.Empty;
        string hf_customerid = string.Empty;
        DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["txtcustomerid"].ToString()))
                {
                    hf_customerid = Session["txtcustomerid"].ToString();
                }
                if (!string.IsNullOrEmpty(Session["txtpancustomer"].ToString()))
                {
                    string customername = Session["txtpancustomer"].ToString();
                    lblcustomername.Text = customername.ToUpper();
                }
                if (!string.IsNullOrEmpty(Session["txtpanno"].ToString()))
                {
                    lblpanno.Text = Session["txtpanno"].ToString();
                    plblan.Visible = true;
                }
                else
                {
                    plblan.Visible = false;
                }
                if (!string.IsNullOrEmpty(Session["hidpaninput"].ToString()))
                {
                    hidpaninput.Value = Session["hidpaninput"].ToString();
                    if (hidpaninput.Value == "Y")
                    {
                        plblan.Visible = false;
                    }
                }
                DataTable dt = obj_MasterCustomer.Getprotalcred(Convert.ToInt32(Session["hid_pan.Value"]));
                if (dt.Rows.Count > 0)
                {
                    txtuser.Text = dt.Rows[0]["username"].ToString();
                    txtpwd.Text = dt.Rows[0]["pwd"].ToString();
                    if (dt.Rows[0]["active"].ToString() == "Y")
                    {
                        ddl_active.SelectedValue = "1";
                    }
                    else
                    {
                        ddl_active.SelectedValue = "2";
                    }
                    btn_Save.ToolTip = "Update";
                    btn_Save.Attributes["class"] = "btn btn-update1";
                }
               // getgriddata();
            }
            else
            {
                //if (!string.IsNullOrEmpty(Session["txtcustomerid"].ToString()))
                //{
                //    hf_customerid = Session["txtcustomerid"].ToString();
                //}
                //if (!string.IsNullOrEmpty(Session["txtpancustomer"].ToString()))
                //{
                //    string customername = Session["txtpancustomer"].ToString();
                //    lblcustomername.Text = customername.ToUpper();
                //}
                //if (!string.IsNullOrEmpty(Session["txtpanno"].ToString()))
                //{
                //    lblpanno.Text = Session["txtpanno"].ToString();
                //    plblan.Visible = true;
                //}
                //else
                //{
                //    plblan.Visible = false;
                //}
            }
           
        }

        private bool IsValidpass(string pass)
        {
            //Regex To validate Email Address
            //Regex regex = new Regex("^.*(?=.{6,10})(?=.*[a-zA-Z])[a-zA-Z0-9]+$");
            //var regEx = new Regex(@"^(?=(.*\d))(?=.*[a-z])(?=.*[A-Z])(?!\d).{6,10}$");//
            //"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"
            //^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$//(?=.*?[#?!@$%^&*-])
            var regEx = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,10}$");
            Match match = regEx.Match(pass);
            if (match.Success)
                return true;
            else
                return false;
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string active = "";
            if(txtuser.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('User Name cannot be empty!');", true);
                return;
                txtuser.Focus();

            }
            if (txtpwd.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Password cannot be empty!');", true);
                return;
                txtpwd.Focus();

            }
            if (ddl_active.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Kindly Select whether the credentials are active or not..');", true);
                return;
                

            }
            
            if(ddl_active.SelectedValue=="1")
            {
                active="Y";
            }
            else
            {
                active = "N";
            }
          
            if (btn_Save.ToolTip == "Save")
            {


                obj_MasterCustomer.Insmastercustportalcredentials(Convert.ToInt32(Session["hid_pan.Value"]), txtuser.Text, txtpwd.Text, active);
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Saved Successfully!');", true);
                    // btnSave.Enabled = true;
                    clrnew();
                  //  getgriddata();
                    //btn_Save.ToolTip = "Update";
                    //btn_Save.Attributes["class"] = "btn btn-update1";
                   // hid_bankid.Value = "";
               
            }
            else if (btn_Save.ToolTip == "Update")
            {
                
                    obj_MasterCustomer.Updmastercustportalcredentials(Convert.ToInt32(Session["hid_pan.Value"]), txtuser.Text, txtpwd.Text, active);
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Updated Successfully!');", true);
                    
                    clrnew();
                    //getgriddata();
                    btn_Save.ToolTip = "Save";
                    btn_Save.Attributes["class"] = "btn ico-save";
                    //hid_bankid.Value = "";
                 
            }
        }
        public void getgriddata()
        {
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.get_Gridviewnewone(Convert.ToInt32(hf_customerid));
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnbankcancel_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
            GridView1.DataBind();
            getgriddata();
            //txtcustomer.Text = true;
           
            txtaccountno.Enabled = true;
            DropDownList5.Enabled = true;
           
            btn_Save.Enabled = true;
            clrnew();
        }

        public void clrnew()
        {

            txtpwd.Text = "";
            txtuser.Text = "";
            
        }
        protected void txtaccountno_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }

}