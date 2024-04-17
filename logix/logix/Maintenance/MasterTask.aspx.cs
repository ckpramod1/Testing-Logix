using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataTable = System.Data.DataTable;
using Label = Microsoft.Office.Interop.Excel.Label;


namespace logix.Maintenance
{
    public partial class MasterTask : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();GenerateLabelAfter();", true);
            if (!IsPostBack)
            {
                string customername = Session["pancustomer"].ToString();
                lblcustomername.Text = customername.ToUpper();
                DataTable dtFromSession = Session["DataTable"] as DataTable;


                string panno = Session["hiddenpanid1"].ToString();

                DataTable grid = obj_MasterCustomer.Getcustgridwithpantask(panno);



                Grd_Customer.DataSource= grid;
                Grd_Customer.DataBind();
                int x = 0;
                binddata(x);
            }



        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            string product1 = ddl_voutype.SelectedValue.ToString();

            if (ddl_voutype.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Please Select Product')", true);
                return;
            }
            //if (txtcustomer.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Please Select GridRow')", true);
            //    return;
            //}

            else
            {
                int Grdcheck = 0;
                for (int j = 0; j < Grd_Customer.Rows.Count; j++)
                {

                    System.Web.UI.WebControls.CheckBox cbox = (System.Web.UI.WebControls.CheckBox)Grd_Customer.Rows[j].FindControl("checksbno");
                    if (cbox.Checked == true)
                    {
                        Grdcheck++;
                    }
                }
                if (Grdcheck == 0)
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Please Select Customer')", true);
                    return;
                }




                //int customerid = Convert.ToInt32(hf_customerid.Value);


                for (int j = 0; j < grd.Rows.Count; j++)
                {
                    DropDownList Txt1 = (DropDownList)grd.Rows[j].FindControl("DropDownList1");
                    if (Txt1.SelectedItem.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Please Select All Task for Customer')", true);
                        return;
                    }
                }

                for (int j = 0; j < Grd_Customer.Rows.Count; j++)
                {

                    System.Web.UI.WebControls.CheckBox cbox = (System.Web.UI.WebControls.CheckBox)Grd_Customer.Rows[j].FindControl("checksbno");
                    string cus = Grd_Customer.Rows[j].Cells[4].Text;
                    int customerid = Convert.ToInt32(cus);
                    if (cbox.Checked == true)
                    {
                        obj_MasterCustomer.ExitTrantype(product1, customerid);
                    }



                    for (int i = 0; i < grd.Rows.Count; i++)
                {
                        // Access values in each cell of the current row
                        //string textValue1 = row.Cells[0].Text;
                        //string textValue2 = row.Cells[1].Text;
                        //string textValue3 = (DropDownList)row.FindControl("DropDownList1");

                        // Find the DropDownList in the current row
                        //DropDownList ddl = (DropDownList)row.FindControl("DropDownList1");
                        if (cbox.Checked == true)
                        {

                           


                    GridViewRow row = grd.Rows[i];
                    DropDownList Txt1 = (DropDownList)grd.Rows[i].FindControl("DropDownList1");
                    int eventid = Convert.ToInt32(row.Cells[3].Text);



                    string EmpName = Txt1.SelectedItem.ToString();

                    string product2 = ddl_voutype.SelectedItem.ToString();
                    string product = ddl_voutype.SelectedValue.ToString();

                           
                          


                    obj_MasterCustomer.InsCustomerTaskdetails(customerid, eventid, product, EmpName,
                                Convert.ToInt32(Session["LoginEmpId"].ToString()));


                    //if (ddl != null)
                    //{
                    //    // Access the selected value of the DropDownList
                    //    string selectedValue = ddl.SelectedItem.Text;

                    //    // Use the values as needed in your save logic
                    //    // For example, you can print or store them
                    //    Response.Write($"Text1: {textValue1}, Text2: {textValue2}, SelectedValue: {selectedValue}<br>");

                    //}
                    
                }

            }
        }




                if (btnsave.ToolTip == "Save")
                {


                    string panno = Session["hiddenpanid1"].ToString();

                    DataTable grid = obj_MasterCustomer.Getcustgridwithpantask(panno);



                    Grd_Customer.DataSource = grid;
                    Grd_Customer.DataBind();
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Assigned the task for employee successfully ')", true);

                    btnsave.ToolTip = "Update";
                    btnsave1.Attributes["class"] = "btn btn-update1";
                }
                else 
                {
                    string panno = Session["hiddenpanid1"].ToString();

                    DataTable grid = obj_MasterCustomer.Getcustgridwithpantask(panno);



                    Grd_Customer.DataSource = grid;
                    Grd_Customer.DataBind();
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Update successfully ')", true);
                }


            }
           
        }

        protected void binddata(int x)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = obj_MasterCustomer.GetEvent();
            if (x == 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }

            for (int j = 0; j < grd.Rows.Count; j++)
            {
                var ddl1 = (DropDownList)grd.Rows[j].FindControl("DropDownList1");



                System.Data.DataTable dt1 = new System.Data.DataTable();
                dt1 = obj_MasterCustomer.GetEmpoyee();
                //ddl1.DataSource = dt1;
                ddl1.Items.Add("");
                ddl1.DataSource = dt1;
                ddl1.DataTextField = "Events";

                //ddl1.DataBind();

                ddl1.DataTextField = "empname";
                ddl1.DataValueField = "empname";
                ddl1.DataBind();
                ddl1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
        }


        //protected void ddl_NextEvent_SelectedIndexChanged(object sender, EventArgs e)
        //{


        //    int index = 0;
        //    GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
        //    index = row.RowIndex;
        //    DropDownList Txt = (DropDownList)grd.Rows[row.RowIndex].FindControl("NextEvent");




        //}

        protected void ddl_voutype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //System.Data.DataTable dt = new System.Data.DataTable();
            //string product = ddl_voutype.SelectedItem.ToString();
            //dt = obj_MasterCustomer.GetEmpoyeeName(product);
            //for (int i = 0; i < grd.Rows.Count; i++)
            //{
            //    // Access values in each cell of the current row
            //    //string textValue1 = row.Cells[0].Text;
            //    //string textValue2 = row.Cells[1].Text;
            //    //string textValue3 = (DropDownList)row.FindControl("DropDownList1");

            //    // Find the DropDownList in the current row
            //    //DropDownList ddl = (DropDownList)row.FindControl("DropDownList1");
            //    DropDownList Txt1 = (DropDownList)grd.Rows[i].FindControl("DropDownList1");
            //    Txt1.SelectedItem.Text= dt.Rows[i].ToString();

            //    string EmpName = Txt1.SelectedItem.ToString();
            //}



            if (ddl_voutype.SelectedValue.ToString() != "")
            {
                System.Data.DataTable Dt = new System.Data.DataTable();
                string product = ddl_voutype.SelectedValue.ToString();
                if (txtcity.Text != "")
                {
                    int customerid = Convert.ToInt32(hf_customerid.Value);
                    Dt = obj_MasterCustomer.GetEmpoyeeName(product, customerid);
                }
                if(Dt.Rows.Count > 0)
                {

                    btnsave.ToolTip = "Update";
                    btnsave1.Attributes["class"] = "btn btn-update1";
                }
                else
                {

                    btnsave.ToolTip = "Save";
                    btnsave1.Attributes["class"] = "btn ico-save";
                }
                int x = Dt.Rows.Count;
                System.Data.DataTable Dt4 = new System.Data.DataTable();
                Dt4= obj_MasterCustomer.GetEVentType(product);
                grd.DataSource = Dt4;
                grd.DataBind();
                int h = Dt4.Rows.Count;

                if (x == 0)
                {
                    int y = 1;
                    binddata(y);
                }
                else
                {
                    for (int i = 0; i < h; i++)
                    {
                        //var row = Dt.Rows[i];

                        ////string textValue3 = (DropDownList)row.FindControl("DropDownList1");
                        //DropDownList ddl = (DropDownList).Rows.FindControl("DropDownList1");
                        //DropDownList Txt1 = (DropDownList)grd.Rows[i].FindControl("DropDownList1");
                        //Txt1.SelectedItem.Text = Dt.Rows[i].ToString();
                        //DropDownList DropDownList1 = (DropDownList)grd.FindControl("DropDownList1");
                        //DropDownList1.SelectedValue= row.ItemArray[i].ToString();

                        var ddl1 = (DropDownList)grd.Rows[i].FindControl("DropDownList1");



                        System.Data.DataTable Dt1 = new System.Data.DataTable();

                        Dt1 = obj_MasterCustomer.GetEmpoyeeName();
                        //ddl1.DataSource = dt1;
                        //DataRow dr = Dt.NewRow();
                        //dr[3].Value = "Some Value";
                        //Dt.Rows.Add(dr);

                        string result = Dt.Rows[0][0].ToString();
                        ReplaceValueInDataTable(Dt1, result, "DEMO-EMP1");
                        Dt1.Rows[0]["empname"] = result;


                        ddl1.Items.Add("");
                        ddl1.DataSource = Dt1;
                        ddl1.DataTextField = "Events";

                        //ddl1.DataBind();






                        ddl1.DataTextField = "empname";
                        ddl1.DataValueField = "empname";
                        ddl1.DataBind();
                        foreach (DataRow row in Dt.Rows)
                        {

                            row.Delete();
                            Dt.AcceptChanges();
                            break;
                        }

                        //ddl1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Qualification--", "0"));
                    }
                }
            }
        }
        static void ReplaceValueInDataTable(System.Data.DataTable Dt, string oldValue, string newValue)
        {
            foreach (DataRow row in Dt.Rows)
            {
                foreach (DataColumn col in Dt.Columns)
                {
                    // Check if the current cell contains the old value
                    if (row[col] != DBNull.Value && row[col].ToString() == oldValue)
                    {
                        // Replace the old value with the new value
                        row[col] = newValue;
                    }
                }
            }
        }

        

        protected void Emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 1; i < grd.Rows.Count; i++)
            {
                var ddl2 = (DropDownList)grd.Rows[i].FindControl("DropDownList1");
                if (ddl2.SelectedItem.Text != "Select")
                {
                    count++;
                }
            }
            if (count == 0)
            {
                var ddl1 = (DropDownList)grd.Rows[0].FindControl("DropDownList1");
                string x = ddl1.SelectedItem.Text;
                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    var ddl2 = (DropDownList)grd.Rows[i].FindControl("DropDownList1");

                    ddl2.SelectedValue = x;

                }
            }

            }

        protected void Grd_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = Grd_Customer.SelectedIndex;

            txtcustomer.Enabled = true;
            txtcity.Enabled = true;

            // Get the selected row
            GridViewRow selectedRow = Grd_Customer.Rows[selectedIndex];


            // You can access cell values from the selected row
            

            string GstNo = "";

           
           
            
           


            //txtcustomer.Text = GstNo;
            //txtcity.Text= City;
            System.Web.UI.WebControls.CheckBox cbox = (System.Web.UI.WebControls.CheckBox)Grd_Customer.Rows[selectedIndex].FindControl("checksbno");
            if (cbox.Checked == true)
            {
                txtcustomer.Text = "";
                txtcity.Text = "";
            }
            else
            {
                if (selectedRow.Cells[1].Text != "&nbsp;")
                {
                    GstNo = selectedRow.Cells[1].Text;
                }
                string City = selectedRow.Cells[3].Text;
                string Customerid = selectedRow.Cells[4].Text;
                txtcustomer.Text = GstNo;
                txtcity.Text = City;
                hf_customerid.Value = selectedRow.Cells[4].Text;
                ddl_voutype_SelectedIndexChanged(sender, e);
            }
        }

        protected void Grd_Customer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Customer, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            btnsave.ToolTip = "Save";
            btnsave1.Attributes["class"] = "btn ico-save";

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            binddata(1);
            txtcustomer.Text = "";
            txtcity.Text = "";
            btnsave.ToolTip = "Save";
            btnsave1.Attributes["class"] = "btn ico-save";
            ddl_voutype.SelectedIndex = 0;
            for (int j = 0; j < Grd_Customer.Rows.Count; j++)
            {

                System.Web.UI.WebControls.CheckBox cbox = (System.Web.UI.WebControls.CheckBox)Grd_Customer.Rows[j].FindControl("checksbno");
                cbox.Checked = false;
            }
        }
        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox chkAll = (System.Web.UI.WebControls.CheckBox)Grd_Customer.HeaderRow.FindControl("chkSelectAll");
            foreach (GridViewRow row in Grd_Customer.Rows)
            {
                System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)row.FindControl("checksbno");
                chk.Checked = chkAll.Checked;
            }
        }
    }
}