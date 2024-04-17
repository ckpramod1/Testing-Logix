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
    public partial class MasterCustomerBank : System.Web.UI.Page
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

                getgriddata();
            }
            else
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
            }
        }
        protected void Checkdatacon()
        {
            if (txtbankid.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Please select Bankname');", true);
                txtbankid.Focus();
                blerr = true;
                return;
            }
            else if (txtaccountno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Please Enter AccountNumber');", true);
                txtaccountno.Focus();
                blerr = true;
                return;
            }
            else if (DropDownList5.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Select account Type');", true);
                DropDownList5.Focus();
                blerr = true;
                return;
            }
            else if (txtifsc.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Please Enter IFSCCode');", true);
                txtifsc.Focus();
                blerr = true;
                return;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Checkdatacon();
            if (blerr == true)
            {
                blerr = false;
                return;
            }
            if (btn_Save.ToolTip == "Save")
            {

                if (hid_bankid.Value != "")
                {
                    obj_MasterCustomer.insertcustomerbankaccountnew(Convert.ToInt32(hf_customerid), Convert.ToInt32(hid_bankid.Value), txtaccountno.Text, DropDownList5.SelectedItem.Text, txtifsc.Text);
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Saved Successfully!');", true);
                    // btnSave.Enabled = true;
                    clrnew();
                    getgriddata();
                    //btn_Save.ToolTip = "Update";
                    //btn_Save.Attributes["class"] = "btn btn-update1";
                    hid_bankid.Value = "";
                }
            }
            //else if(btn_Save.ToolTip == "Update")
            //{
            //    if (hid_bankid.Value != "")
            //    {
            //        obj_MasterCustomer.insertcustomerbankaccountnew(Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(hid_bankid.Value), txtaccountno.Text, DropDownList5.SelectedItem.Text, txtifsc.Text);
            //        ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Saved Successfully!');", true);
            //        btnSave.Enabled = true;
            //        clrnew();
            //        getgriddata();
            //        btn_Save.ToolTip = "Save";
            //        btn_Save.Attributes["class"] = "btn ico-save";
            //        hid_bankid.Value = "";
            //    }
            //}
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
            txtbankid.Enabled = true;
            txtaccountno.Enabled = true;
            DropDownList5.Enabled = true;
            txtifsc.Enabled = true;
            btn_Save.Enabled = true;
            clrnew();
        }

        public void clrnew()
        {
            txtbankid.Text = "";
            txtaccountno.Text = "";
            DropDownList5.Items.Clear();
            DropDownList5.Items.Add("");
            DropDownList5.Items.Add("SAVINGS");
            DropDownList5.Items.Add("CURRENT");
            txtifsc.Text = "";
        }
        protected void txtaccountno_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.Gettextchangeledgernamenew(Convert.ToInt32(hf_customerid), txtaccountno.Text, Convert.ToInt32(hid_bankid.Value));
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Already exists');", true);
                txtaccountno.Focus();
                blerr = true;
                txtifsc.Text = dt.Rows[0]["IFSCCode"].ToString();
                DropDownList5.SelectedItem.Text = dt.Rows[0]["account"].ToString();

                hid_bankid.Value = dt.Rows[0]["bankid"].ToString();
                hid_bankid.Value = txtbankid.Text;
                txtbankid.Enabled = false;
                txtaccountno.Enabled = false;
                DropDownList5.Enabled = false;
                txtifsc.Enabled = false;
                btn_Save.Enabled = false;
                return;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = GridView1.SelectedRow.RowIndex;
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.get_Gridviewnewone(Convert.ToInt32(hf_customerid));
            if (GridView1.Rows.Count > 0)
            {
                Session["Index"] = index;
                txtbankid.Text = GridView1.Rows[index].Cells[5].Text.ToUpper();
                DropDownList5.SelectedItem.Text = GridView1.Rows[index].Cells[7].Text.ToUpper();
                txtaccountno.Text = GridView1.Rows[index].Cells[6].Text.ToUpper();
                txtifsc.Text = GridView1.Rows[index].Cells[8].Text.ToUpper();
            }
            txtbankid.Enabled = false;
            txtaccountno.Enabled = false;
            DropDownList5.Enabled = false;
            txtifsc.Enabled = false;
            btn_Save.Enabled = false;
            //btn_Save.ToolTip = "Update";
            //btn_Save.Attributes["class"] = "btn btn-update1";
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