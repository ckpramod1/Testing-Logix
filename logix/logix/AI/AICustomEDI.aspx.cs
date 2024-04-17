using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using System.Text;


namespace logix.AI
{
    public partial class AICustomEDI : System.Web.UI.Page
    {
        DataTable Dtdummy = new DataTable();
        DataTable DtBL = new DataTable();
        string agentcode, customcode, mode;
        int tpkgs, j;
        double tgrwt;
        Boolean blnerr;
        DateTime dateedi;
        string polcode, podcode;
        System.IO.TextWriter TW;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.AirImportExports.AIEBLDetails BLObj = new DataAccess.AirImportExports.AIEBLDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                BLObj.GetDataBase(Ccode);
               
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnedi);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            if (!this.IsPostBack)
            {
                try
                {
                    txtjobno.Focus();
                    grd.DataSource = Dtdummy;
                    grd.DataBind();
                    //ShowNoResultFound(Dtdummy, grd);
                    hid_date.Value = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    if (Session["StrTranType"].ToString() == "AI")
                    {
                        HeaderLabel1.InnerText = "Air Imports";
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
            else if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }

            txtjobno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
        }
        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;

        }
        private void ShowNoResultFound(DataTable source, GridView gv)
        {
            if (source.Columns.Count == 0)
            {
                gv.DataSource = null;
                gv.DataBind();
                source.Columns.Add("HAWBL #");
                source.Columns.Add("H.Date");
                source.Columns.Add("From Code");
                source.Columns.Add("To Code");
                source.Columns.Add("No. Pkgs");
                source.Columns.Add("Gr.Weight");
                source.Columns.Add("Descn.");
                source.Columns.Add("Select");

                source.Rows.Add(source.NewRow());
                gv.DataSource = source;
                gv.DataBind();
                int columnsCount = gv.Columns.Count;
                gv.Rows[0].Cells.Clear();
            }
        }

        protected void lnkjob_Click(object sender, System.EventArgs e)
        {
            DataTable DtJob = new DataTable();
            //DataAccess.AirImportExports.AIEBLDetails BLObj = new DataAccess.AirImportExports.AIEBLDetails();
            DtJob = BLObj.GetAIJobDtls4EDI(Convert.ToInt32(Session["LoginBranchid"]));

            grdAIE.DataSource = DtJob;
            grdAIE.DataBind();
            pnlJobAE.Visible = true;
            this.popmodelJobAI.Show();
        }

        protected void grdAIE_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdAIE, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txtjobno_TextChanged(object sender, System.EventArgs e)
        {
            fillGrid();
        }
        private void fillGrid()
        {

            for (int i = 0; i <= grd.Rows.Count; i++)
            {
                grd.DataSource = DtBL;
                grd.DataBind();
            }

            int totalpkgs = 0;
            int totalgrwt = 0;
            DateTime ddate;

            txtMAWBLno.Text = "";
            txtmawbldate.Text = "";
            txtigm.Text = "";
            txtigmdate.Text = "";
            txtflight.Text = "";
            txtflightdate.Text = "";
            ddlmode.Text = "TOTAL SHIPMENT";
            txtfile.Text = "";
            //DataAccess.AirImportExports.AIEBLDetails BLObj = new DataAccess.AirImportExports.AIEBLDetails();
            DtBL = BLObj.GetAIBLDtls4EDI(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (DtBL.Rows.Count > 0)
            {
                grd.DataSource = DtBL;
                grd.DataBind();
                txtMAWBLno.Text = DtBL.Rows[0]["mawblno"].ToString();
                txtmawbldate.Text = Utility.fn_ConvertDate1((Convert.ToDateTime(DtBL.Rows[0]["mawbldate"]).ToShortDateString()).ToString());
                txtigm.Text = DtBL.Rows[0]["manifestno"].ToString();
                if (!string.IsNullOrEmpty( DtBL.Rows[0]["manifestno"].ToString())) 
                {
                    txtigmdate.Text = Utility.fn_ConvertDate1((Convert.ToDateTime(DtBL.Rows[0]["manifestdate"]).ToShortDateString()).ToString());
                }                                  
                txtflight.Text = DtBL.Rows[0]["flightno"].ToString();
                txtflightdate.Text = Utility.fn_ConvertDate1((Convert.ToDateTime(DtBL.Rows[0]["flightdate"]).ToShortDateString()).ToString());
                ddlmode.Text = "TOTAL SHIPMENT";
                //  txtfile.Text =  DtBL.Rows[0][].ToString();
                agentcode = DtBL.Rows[0]["carrno"].ToString();
                customcode = DtBL.Rows[0]["branchcode"].ToString();
                hdncustomcode.Value = customcode;

                hdnagentcode.Value = agentcode;

            }
            int intjobno;
            intjobno = Convert.ToInt32(txtjobno.Text);

            if (intjobno >= 1 && intjobno <= 9)
            {
                txtfile.Text = agentcode + "00000" + txtjobno.Text + ".CGM";
            }
            else if (intjobno >= 10 && intjobno <= 99)
            {
                txtfile.Text = agentcode + "0000" + txtjobno.Text + ".CGM";
            }
            else if (intjobno >= 100 && intjobno <= 999)
            {
                txtfile.Text = agentcode + "000" + txtjobno.Text + ".CGM";
            }
            else if (intjobno >= 1000 && intjobno <= 9999)
            {
                txtfile.Text = agentcode + "00" + txtjobno.Text + ".CGM";
            }
            else if (intjobno >= 10000 && intjobno <= 9999)
            {
                txtfile.Text = agentcode + "0" + txtjobno.Text + ".CGM";
            }
            else
            {
                txtfile.Text = agentcode + txtjobno.Text + ".CGM";
            }


        }

        protected void grdAIE_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (grdAIE.Rows.Count > 0)
            {
                int index;
                index = grdAIE.SelectedRow.RowIndex;
                txtjobno.Text = grdAIE.SelectedRow.Cells[0].Text;
                fillGrid();

            }
        }
        protected void grdAIE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAIE.PageIndex = e.NewPageIndex;
            DataTable DtJob = new DataTable();
            //DataAccess.AirImportExports.AIEBLDetails BLObj = new DataAccess.AirImportExports.AIEBLDetails();
            DtJob = BLObj.GetAIJobDtls4EDI(Convert.ToInt32(Session["LoginBranchid"]));

            grdAIE.DataSource = DtJob;
            grdAIE.DataBind();
            pnlJobAE.Visible = true;
            this.popmodelJobAI.Show();

        }


        protected void btnedi_Click(object sender, System.EventArgs e)
        {
            string dateedi1;
            dateedi1 = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("yyyyMMdd");
            customcode=hdncustomcode.Value;
            agentcode=hdnagentcode.Value;
            ddlmode_SelectedIndexChanged(sender, e);
            if (grd.Rows.Count > 0)
            {
                tpkgs = 0;
                tgrwt = 0;
                blnerr = false;
                for (j = 0; j <= grd.Rows.Count - 1; j++)
                {
                    CheckBox chkRow = (grd.Rows[j].Cells[2].FindControl("Chk_select") as CheckBox);
                    if (chkRow.Checked == true)
                    {
                        tpkgs = tpkgs + Convert.ToInt32(grd.Rows[j].Cells[12].Text);
                        tgrwt = tgrwt + Convert.ToDouble(grd.Rows[j].Cells[13].Text);
                        polcode = grd.Rows[j].Cells[10].Text;
                        podcode = grd.Rows[j].Cells[11].Text;

                        //polcode = HttpUtility.HtmlDecode(grd.Rows[j].Cells[10].Text.ToUpper().ToString().Replace("&AMP;", "&"));
                        //podcode = HttpUtility.HtmlDecode(grd.Rows[j].Cells[11].Text.ToUpper().ToString().Replace("&AMP;", "&").Replace("&nbsp", ""));
                       
                        blnerr = true;

                    }
                }
                if (blnerr == false)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('Please select any one house BL');", true);
                    return;
                }
                dateedi = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());

                //object objFSO = null;
                //objFSO = Server.CreateObject("Scripting.FileSystemObject");

                //object FullPath = null;
                //FullPath = "C:\\CustomEDI";

                string str_fullpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                str_fullpath = Server.MapPath("~/CustomEDI/");

                if (Directory.Exists(str_fullpath))
                {
                    //Directory.CreateDirectory(filePath);
                    foreach (string file in Directory.GetFiles(str_fullpath))
                    {
                        File.Delete(file);
                    }
                }

                TW = System.IO.File.CreateText(str_fullpath + txtfile.Text);
                string Str;
               // DateTime today;
                Str = "";
                Str = Str + "HREC";
                Str = Str + Convert.ToChar(29);
                Str = Str + "ZZ";
                Str = Str + Convert.ToChar(29);
                //Str = Str + "MRLIPLTD";
                Str = Str + "MRLOGPVTL";
                Str = Str + Convert.ToChar(29);
                Str = Str + "ZZ";
                Str = Str + Convert.ToChar(29);
                Str = Str + customcode;
                Str = Str + Convert.ToChar(29);
                Str = Str + "ICES1_5";
                Str = Str + Convert.ToChar(29);
                Str = Str + "P";
                Str = Str + Convert.ToChar(29);
                Str = Str + Convert.ToChar(29);
                Str = Str + "CMCHI01";
                Str = Str + Convert.ToChar(29);
                Str = Str + txtjobno.Text;
                Str = Str + Convert.ToChar(29);

               // string.Format("{0:0.00}", Total);
               // Str = Str + string.Format("{0:s}", dateedi);
                Str = Str + dateedi1;
                Str = Str + Convert.ToChar(29);
                string ss = Convert.ToDateTime(Logobj.GetDate().ToShortTimeString()).ToString("hhmm");
               // Str = Str + DateTime.Now.Hour.ToString("00.##") + DateTime.Now.Minute.ToString("00.##");
                Str = Str + ss;
               // Str = Str + string.Format("{HH mm}", dateedi.TimeOfDay);


                Str = Str + Environment.NewLine;
                Str = Str + "<consoligm>";
                Str = Str + Environment.NewLine;
                Str = Str + "<consmaster>";
                TW.WriteLine(Str);
                TW.Flush();
                Str = "";
                Str = Str + "F";
                Str = Str + Convert.ToChar(29);
                Str = Str + agentcode;
                Str = Str + Convert.ToChar(29);
                Str = Str + customcode;
                Str = Str + Convert.ToChar(29);
                if (txtigm.Text != "")
                {
                    Str = Str + txtigm.Text.Trim();
                }
                Str = Str + Convert.ToChar(29);
                if (txtigmdate.Text != "")
                {
                    Str = Str + txtigmdate.Text.Trim();
                }
                Str = Str + Convert.ToChar(29);
                Str = Str + txtflight.Text;
                Str = Str + Convert.ToChar(29);
                Str = Str + txtflightdate.Text;
                Str = Str + Convert.ToChar(29);
                Str = Str + txtMAWBLno.Text;
                Str = Str + Convert.ToChar(29);
                Str = Str + txtmawbldate.Text;
                Str = Str + Convert.ToChar(29);
                Str = Str + polcode;
                Str = Str + Convert.ToChar(29);
                Str = Str + podcode;
                Str = Str + Convert.ToChar(29);
                Str = Str + mode;
                Str = Str + Convert.ToChar(29);
                Str = Str + tpkgs;
                Str = Str + Convert.ToChar(29);
                Str = Str + tgrwt.ToString("#0.000");
                Str = Str + Convert.ToChar(29);
                Str = Str + "CONSOL";
                Str = Str + Environment.NewLine;
                Str = Str + "<END-consmaster>";
                Str = Str + Environment.NewLine;
                Str = Str + "<conshouse>";
                TW.WriteLine(Str);
                TW.Flush();

                for (j = 0; j <= grd.Rows.Count - 1; j++)
                {
                    CheckBox chkRow = (grd.Rows[j].Cells[2].FindControl("Chk_select") as CheckBox);
                    if (chkRow.Checked == true)
                    {
                        Str = "";
                        Str = Str + "F";
                        Str = Str + Convert.ToChar(29);
                        Str = Str + agentcode;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + customcode;
                        Str = Str + Convert.ToChar(29);
                        if (txtigm.Text != "")
                        {
                            Str = Str + txtigm.Text.Trim();
                        }
                        Str = Str + Convert.ToChar(29);
                        if (txtigmdate.Text != "")
                        {
                            Str = Str + txtigmdate.Text.Trim();
                        }
                        Str = Str + Convert.ToChar(29);
                        Str = Str + txtflight.Text;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + txtflightdate.Text;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + txtMAWBLno.Text;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + txtmawbldate.Text;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + grd.Rows[j].Cells[8].Text;
                        Str = Str + Convert.ToChar(29);
                        //Str = Str + grd.Rows[j].Cells[9].Text;
                        Label ldate = (Label)grd.Rows[j].FindControl("lbldate");
                        Str = Str + ldate.Text;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + grd.Rows[j].Cells[10].Text;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + grd.Rows[j].Cells[11].Text;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + mode;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + grd.Rows[j].Cells[12].Text;
                        Str = Str + Convert.ToChar(29);
                        Str = Str + grd.Rows[j].Cells[13].Text;
                        Str = Str + Convert.ToChar(29);
                        int len;
                        Label l1 = (Label)grd.Rows[j].FindControl("lbldesc");
                        len = Convert.ToInt32(l1.Text.Length);                        
                       
                        if (len > 30)
                        {

                            Str = Str + l1.Text.Substring(0, 30);
                        }
                        else
                        {
                            Str = Str + l1.Text;
                        }
                       // Str = Str + grd.Rows[j].Cells[13].ToString().Replace("<br/>", "");

                    //     if(Len(grd.Rows(j).Cells["grddescn"].Value) > 30 )
                    //    Str = Str & Replace(GrdBL.Rows(j).Cells("grddescn").Value, vbCrLf, " ").Substring(0, 30)
                    //Else
                    //    Str = Str & Replace(GrdBL.Rows(j).Cells("grddescn").Value, vbCrLf, " ")
                    //End If
                        TW.WriteLine(Str);
                        TW.Flush();
                    }
                }
                Str = "";
                Str = Str + "<END-conshouse>";
                Str = Str + Environment.NewLine;
                Str = Str + "<END-consoligm>";
                Str = Str + Environment.NewLine;
                Str = Str + "TREC" + Convert.ToChar(29) + txtjobno.Text;
                TW.WriteLine(Str);
                TW.Flush();
                TW.Close();
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1428, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtjobno.Text + " EDI File Generated on " + hid_date.Value.ToString() + " " + String.Format("{0:t}", DateTime.Now.ToShortTimeString()));
                Response.Clear();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(str_fullpath + txtfile.Text));
                Response.WriteFile(str_fullpath + txtfile.Text);
                Response.Flush();
                System.IO.File.Delete(str_fullpath + txtfile.Text);
                Response.End();
            }
            ScriptManager.RegisterStartupScript(btnedi, typeof(Button), "DataFound", "alertify.alert('EDI File Created for Job# " + txtjobno.Text + " Has Been Created');", true);
        }

        protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlmode.SelectedValue.ToString() == "TOTAL SHIPMENT")
            {
                mode = "T";
            }
            else
            {
                mode = "P";
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                txtjobno.Text = "";
                txtMAWBLno.Text = "";
                txtmawbldate.Text = "";
                ddlmode.SelectedIndex = 0;
                txtflight.Text = "";
                txtflightdate.Text = "";
                txtigm.Text = "";
                txtigmdate.Text = "";
                txtfile.Text = "";
                grd.DataSource = new DataTable();
                grd.DataBind();
                txtjobno.Focus();
                btncancel.Text = "Back";

                btncancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";




            }
            else
            {
                //this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "AI")
                            {
                                Response.Redirect("../Home/AICSHome.aspx");
                            }

                        }
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdAIE, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {

            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}