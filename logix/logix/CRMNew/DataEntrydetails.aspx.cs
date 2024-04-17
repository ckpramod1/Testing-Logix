using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace logix.CRMNew
{

    public partial class DataEntrydetails : System.Web.UI.Page
    {
        DataAccess.CRMNew.MasterCustomerProspective objCust = new DataAccess.CRMNew.MasterCustomerProspective();
        DataTable dt = new DataTable();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            if (!IsPostBack)
            {
                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                txt_date.Text = hid_date.Value;
                txtTo.Text = hid_date.Value;
                //Get_Empty();
                grdjob.Visible = false;
                txt_date.Enabled = false;
                txtTo.Enabled = false;
                btncancel.Enabled = false;
                btnGet.Enabled = false;
                grdEmp.Visible = true;
                Get_TotalEntry();

            }
        }

        protected void Get_TotalEntry()
        {
            DataTable dt = new DataTable();
            dt = objCust.GetTeleCallEntryDetails();
            grdEmp.DataSource = dt;
            grdEmp.DataBind();
            Session["dataNew"] = dt;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            //string from, from1, to, to1;
            //from = Utility.fn_ConvertDatebha(txt_date.Text.Trim());
            //from1 = Utility.fn_ConvertDatebha(from);
            //to = Utility.fn_ConvertDatebha(txtTo.Text.Trim());
            //to1 = Utility.fn_ConvertDatebha(to);
           
               // dt = obj_CRM.GetDSRfromto(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToDateTime(from1), Convert.ToDateTime(to1));
            //string fromDate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text.Trim())).ToShortDateString();
            //string ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text.Trim())).ToShortDateString();
            //DataTable obj_Dtuser = new DataTable();
            ////dtt = (DataTable)Session["dt_UserRights"];
            //DataTable dtt = new DataTable();
            //dtt = (DataTable)ViewState["data"];
            //DataView obj_dtview = new DataView(dtt);
            //// obj_dtview.RowFilter = " (createdon >= #" + Convert.ToDateTime(txt_date.Text).ToString("MM/dd/yyyy") + "# And createdon <= #" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "# ) ";
            ////obj_dtview.RowFilter = "createdon>= " + Convert.ToDateTime("01/11/2016") + " and createdon <=  " + Convert.ToDateTime("01/11/2016") + "";
            //DateTime dtmonthf = Convert.ToDateTime(txtTo.Text.Trim());
            //DateTime dtmontht = Convert.ToDateTime(txtTo.Text.Trim());
            //// obj_dtview.RowFilter = "createdon between '" + dtmonthf + "' and '" + dtmonthf + "'";

            //DateTime from = Convert.ToDateTime(txt_date.Text);
            //DateTime to = Convert.ToDateTime(txtTo.Text);
            //string dateFilterString = "createdon >= #" + dtt.Rows[12]["createdon"].ToString() + "# AND createdon <= #" + dtt.Rows[1]["createdon"].ToString() + "#";
            ////obj_dtview.RowFilter = dateFilterString;
           
            //obj_Dtuser = obj_dtview.ToTable();
            //grdjob.DataSource = obj_Dtuser;
            //grdjob.DataBind();
            //ViewState["data"] = obj_Dtuser;
            //for (int i = 0; i <= grdjob.Rows.Count - 1; i++)
            //{
            //    grdjob.DataSource = Utility.Fn_GetEmptyDataTable();
            //    grdjob.DataBind();
            //}
            //dt = objCust.GetCrmCustNameNew(Convert.ToInt32(hid_Temp.Value.ToString()));

            //if (dt.Rows.Count > 0)
            //{
            //    grdjob.DataSource = dt;
            //    grdjob.DataBind();
            //    ViewState["data"] = dt;
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DataEnterdetails", "alertify.alert('No Record Found..');", true);
            //}

            //string from, from1, to, to1;
            //from = Utility.fn_ConvertDate(txt_date.Text.Trim());
            //from1 = Utility.fn_ConvertDate(from);
            //to = Utility.fn_ConvertDate(txtTo.Text.Trim());
            //to1 = Utility.fn_ConvertDate(to);

            for (int i = 0; i <= grdjob.Rows.Count - 1; i++)
            {
                grdjob.DataSource = Utility.Fn_GetEmptyDataTable();
                grdjob.DataBind();
            }

            dt = objCust.GetrMasterCustProResNewDate(Convert.ToInt32(hid_Temp.Value.ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text.Trim())),  Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text.Trim())));
            if (dt.Rows.Count > 0)
            {
                grdjob.DataSource = dt;
                grdjob.DataBind();
                ViewState["data"] = dt;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DataEnterdetails", "alertify.alert('No Record Found..');", true);
            }
            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1786, 3, Convert.ToInt32(Session["LoginBranchid"]), "/VesselID: " + "/ G");
            
        }

        protected void grdjob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdjob.PageIndex = e.NewPageIndex;

            grdjob.DataSource = (DataTable)ViewState["data"];
            grdjob.DataBind();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            grdjob.Visible = false;
            txt_date.Enabled = false;
            txtTo.Enabled = false;
            btncancel.Enabled = false;
            btnGet.Enabled = false;
            grdEmp.Visible = true;
            grdEmp.DataSource = (DataTable)Session["dataNew"];
            grdEmp.DataBind();
        }

        protected void grdjob_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

            }
        }

        protected void grdEmp_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdEmp, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grdEmp.SelectedRow.RowIndex;
            hid_Temp.Value = grdEmp.DataKeys[index].Values[0].ToString();
            grdjob.Visible = true;
            txt_date.Enabled = true;
            txtTo.Enabled = true;
            btncancel.Enabled = true;
            btnGet.Enabled = true;
            grdEmp.Visible = false;

            for (int i = 0; i <= grdjob.Rows.Count - 1; i++)
            {
                grdjob.DataSource = Utility.Fn_GetEmptyDataTable();
                grdjob.DataBind();
            }
            dt = objCust.GetCrmCustNameNew(Convert.ToInt32(hid_Temp.Value.ToString()));

            if (dt.Rows.Count > 0)
            {
                grdjob.DataSource = dt;
                grdjob.DataBind();
                ViewState["data"] = dt;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DataEnterdetails", "alertify.alert('No Record Found..');", true);
            }
        }

        protected void grdEmp_PreRender(object sender, EventArgs e)
        {
            if (grdEmp.Rows.Count > 0)
            {
                grdEmp.UseAccessibleHeader = true;
                grdEmp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


    }
}