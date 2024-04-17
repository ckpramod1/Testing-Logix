using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

namespace logix.FAForm
{
    public partial class ListofAccount : System.Web.UI.Page
    {
        DataAccess.FAMaster.ReportView obj_da_Report = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails da_Obj_LogDet = new DataAccess.LogDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        int Emp_Id, Branch_Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_Report.GetDataBase(Ccode);
                da_Obj_LogDet.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               



            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_Header.Text = Request.QueryString["FormName"].ToString();
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            
            Emp_Id = Convert.ToInt32(Session["LoginEmpId"]);
            Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Report.FASelGroupall(Session["FADbname"].ToString());
                Grd_Account.DataSource = obj_dt;
                Grd_Account.DataBind();
            }
        }

        protected void Grd_Account_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                e.Row.Attributes.Add("onmouseout", "this.style.cursor='default'");
                GridView Grd = (GridView)e.Row.FindControl("gvChildGrid");
                int int_Groupid = Convert.ToInt32(Grd_Account.DataKeys[e.Row.RowIndex].Values[0].ToString());

                DataTable obj_Grddt = new DataTable();
                obj_Grddt = obj_da_Report.FASelSubGroupall(Session["FADbname"].ToString(), int_Groupid);
                var Result = obj_Grddt.AsEnumerable().OrderBy(row => row["subgroupname"]);
                if (Result.ToList().Count > 0)
                {
                    obj_Grddt = Result.CopyToDataTable();
                }
                if (obj_Grddt.Rows.Count > 0 && Grd.Rows.Count == 0)
                {
                    Grd.DataSource = obj_Grddt;
                    Grd.DataBind();
                }
            }
        }

        protected void gvChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                e.Row.Attributes.Add("onmouseout", "this.style.cursor='default'");
                GridView b = sender as GridView;
                if (b != null)
                {
                    GridView g = (GridView)e.Row.FindControl("Grdbranch");
                    if (g != null)
                    {
                        int int_Groupid, int_SubGroupid;
                        int_SubGroupid = int.Parse(b.DataKeys[e.Row.RowIndex].Values[0].ToString());
                        int_Groupid = int.Parse(b.DataKeys[e.Row.RowIndex].Values[1].ToString());
                        DataTable obj_Grddt = new DataTable();
                        obj_Grddt = obj_da_Report.FASelLedgerall(Session["FADbname"].ToString(), int_Groupid, int_SubGroupid);
                        var Result = obj_Grddt.AsEnumerable().OrderBy(row => row["ledgername"]);
                        if (Result.ToList().Count > 0)
                        {
                            obj_Grddt = Result.CopyToDataTable();
                        }
                        if (obj_Grddt.Rows.Count > 0)
                        {
                            g.DataSource = obj_Grddt;
                            g.DataBind();
                        }
                    }
                }
            }
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {           
            Session["str_sfs"] = ""; Session["str_sp"] = "";
            string str_sp = "", str_sf = "", str_RptName = "", str_RptName1 = "", str_Script = ""; 
            str_RptName = "rptFAListOfAccount.rpt";
            Session["str_sfs"] = "{MasterLedgerHead.blocked}='N'";
            Session["str_sp"] = "";

            str_RptName1 = "rptFAListOfAccount4displayid.rpt";
            Session["str_sfs1"] = "{MasterLedgerHead.blocked}='N'";
            Session["str_sp1"] = "";
          
            //str_sp = Session["str_sp"].ToString();

            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

            if (Session["str_ModuleName"].ToString() == "FC")
            {
                da_Obj_LogDet.InsLogDetail(Emp_Id, 1177, 3, Branch_Id, "/ V");
            }
            else
            {
                da_Obj_LogDet.InsLogDetail(Emp_Id, 1087, 3, Branch_Id, "/ V");
            }
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            string filename = "";
            int Count = 0;

            DataTable dt = new DataTable();
            dt = obj_da_Report.GetListOfAccinFA(Session["FADbname"].ToString());

            if (dt.Rows.Count > 0)
            {
                GridView grdexcel = new GridView();
                grdexcel.DataSource = null;
                grdexcel.DataBind();
                Response.Clear();

                filename = "List of Accounts";

                Response.AddHeader("content-disposition", "Attachment;filename=" + filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grdexcel.DataSource = dt;
                grdexcel.DataBind();
                Count = dt.Columns.Count;

                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3><B>" + "List of Accounts" + "</B></font></td></tr>");
                SB.Append("</table><br />");

                if (grdexcel.Visible == true)
                {
                    grdexcel.GridLines = GridLines.Both;
                    grdexcel.HeaderStyle.Font.Bold = true;
                    grdexcel.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
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
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1087, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1177, "", "", "", Session["StrTranType"].ToString());
            }

       

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void Grd_Account_PreRender(object sender, EventArgs e)
        {
            if (Grd_Account.Rows.Count > 0)
            {
                Grd_Account.UseAccessibleHeader = true;
                Grd_Account.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }



    }
}