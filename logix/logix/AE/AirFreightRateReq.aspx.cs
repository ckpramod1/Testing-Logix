using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.AE
{
    public partial class AirFreightRateReq : System.Web.UI.Page
    {
        int int_branchid;
        int int_divisionid;
        string shippermailadd;
        string internalmailid;
        int int_empid;
        string usermail;
        Boolean blnerr;
        string str_Stackornonstack, str_DGNonDG, str_normalTempControl;
        string str_issuedon;
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.HR.Employee obj_da_hre = new DataAccess.HR.Employee();
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
        DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_AEBLobj.GetDataBase(Ccode);
                obj_da_hre.GetDataBase(Ccode);
                FEJobobj.GetDataBase(Ccode);
                bookingobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                cargoobj.GetDataBase(Ccode); 
                Logobj.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_save);
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_send);

            if (!IsPostBack)
            {
                txt_RatrequiredbyTime.Text = Logobj.GetDate().ToShortDateString();
                txt_RatrequiredbyTime.Text = Utility.fn_ConvertDate(txt_RatrequiredbyTime.Text);
                txt_noofpgs.Attributes.Add("OnKeypress", "return IntegerCheck(event);");              
                txt_GrWt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Gross Weight')");
                txt_VolWt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Volume Weight')");
                EmptyGridmail();
                if (Session["StrTranType"].ToString() == "AE")
                {
                    HeaderLabel1.InnerText = "Air Exports";
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    HeaderLabel1.InnerText = "Air Imports";
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

        [WebMethod]
        public static List<string> GetLikeIncocode(string prefix)
        {
            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            bookingobj.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Incocode = new List<string>();
            obj_Dt = bookingobj.GetLikeIncocode(prefix.ToUpper());
            Incocode = Utility.Fn_DatatableToList_int32(obj_Dt, "incocode", "incoid");
            return Incocode;
        }
        [WebMethod]
        public static List<string> Getportname(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            da_obj_chargeobj.GetDataBase(Ccode);
            obj_dtl = da_obj_portobj.GetLikePort(prefix);
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }

        [WebMethod]
        public static List<string> Getcargo(string prefix)
        {
            List<string> cargotype = new List<string>();
            DataTable obj_dt1 = new DataTable();
            DataAccess.Masters.MasterCargo da_obj_cargoobj = new DataAccess.Masters.MasterCargo();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_cargoobj.GetDataBase(Ccode);
           
            obj_dt1 = da_obj_cargoobj.GetLikeCargo(prefix);
            cargotype = Utility.Fn_DatatableToList(obj_dt1, "cargotype", "cargoid");
            return cargotype;
        }
        [WebMethod]
        public static List<string> Getponame(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            da_obj_chargeobj.GetDataBase(Ccode);
            obj_dtl = da_obj_portobj.GetLikePort(prefix);
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }
        [WebMethod]
        public static List<string> CMailID(string prefix)
        {
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_sc.GetDataBase(Ccode);
          
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_sc.GetLikeCustExporMailID(prefix);
            Bookingno = Utility.Fn_DatatableToList_int32(obj_Dt, "expmailid", "customerid");
            return Bookingno;
        }
        protected void btn_plus_Click(object sender, EventArgs e)
        {
            //Get_CmailID();
            //txt_cmailid.Text = "";
            //txt_cmailid.Focus();
            try
            {
                if (txt_cmailid.Text.Trim().ToUpper() != "")
                {
                    if (IsValidEmailId(txt_cmailid.Text.Trim().ToUpper()))
                    {
                        if (ViewState["CurrentData"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["CurrentData"];
                            int count = dt.Rows.Count;
                            BindGrid(count, txt_cmailid.Text.Trim().ToUpper());
                        }
                        else
                        {
                            BindGrid(1, txt_cmailid.Text.Trim().ToUpper());
                        }

                        txt_cmailid.Text = "";
                        txt_cmailid.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('InValid Email Format');", true);
                        txt_cmailid.Text = "";
                        txt_cmailid.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
                    txt_cmailid.Text = "";
                    txt_cmailid.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$");

            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }


        private void BindGrid(int rowcount, string txtname)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("mailid", typeof(String)));
                //dt.Columns.Add(new System.Data.DataColumn("customername", typeof(String)));

                if (ViewState["CurrentData"] != null)
                {

                    ImageButton btndelete = new ImageButton();
                    foreach (GridViewRow row in grd_cmail.Rows)
                    {

                        btndelete = (ImageButton)row.FindControl("ImageButton2");
                        btndelete.Visible = true;

                    }
                    for (int i = 0; i < rowcount + 1; i++)
                    {
                        dt = (DataTable)ViewState["CurrentData"];

                        if (dt.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dt);
                            dv.RowFilter = "mailid = '" + txtname.ToString().ToUpper().Trim() + "'";
                            if (dv.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail id Already Exist');", true);
                                return;
                            }

                            dr = dt.NewRow();
                            dr[0] = dt.Rows[0][0].ToString();
                        }
                    }


                    dr = dt.NewRow();
                    dr[0] = txtname;
                    //dr[1] = custtype;

                    dt.Rows.Add(dr);

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = txtname;
                    //dr[1] = custtype;

                    dt.Rows.Add(dr);

                }


                if (ViewState["CurrentData"] != null)
                {
                    grd_cmail.DataSource = (DataTable)ViewState["CurrentData"];
                    //Grd_mail.DataSource = dt;
                    grd_cmail.DataBind();
                }
                else
                {
                    grd_cmail.DataSource = dt;
                    grd_cmail.DataBind();
                    //EmptyGridmail();

                }

                ViewState["CurrentData"] = dt;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }


        }

        protected void grd_cmail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ImageButton2");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_cmail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton lb = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                if (ViewState["CurrentData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        if (gvRow.RowIndex < dt.Rows.Count)
                        {

                            dt.Rows.Remove(dt.Rows[rowID]);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted Successfully...');", true);
                        }

                        ViewState["CurrentTable"] = dt;

                        grd_cmail.DataSource = dt;
                        grd_cmail.DataBind();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        EmptyGridmail();
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        private void EmptyGridmail()
        {
            //DataTable dtempty = new DataTable();
            //dtempty.Columns.Add("mailid");
            //dtempty.Rows.Add(dtempty.NewRow());
            //grd_cmail.DataSource = dtempty;
            //grd_cmail.DataBind();
            //grd_cmail.Rows[0].Visible = false;


            DataTable dtempty = new DataTable();            
            grd_cmail.DataSource = dtempty;
            grd_cmail.DataBind();
          
        }
        

        public void getbody()
        {
            string str_usermailid = Session["usermailid"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();
            string sendqry = "";
         
         
            int k = 0;
            string ss, subject = "Air Freight Rate Request";
          
           
                sendqry = Utility.Fn_GetCompanyAddress();
                sendqry = sendqry + "</br>";
                sendqry = sendqry + "</br><b><I>Air Freight Rate Request</I></b>";
                sendqry = sendqry + "</br><b>Dear Sir / Madam</b>";                
                sendqry = sendqry + "</br><table border=1><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>INCO Terms: </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black> " + txtInco.Text + " </td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Orgin Airport : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_Orgin_Airport.Text + "</td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Destination Airport : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_Destination_Airport.Text + "</td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Commodity : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_Commodity.Text + "</td></tr></FONT>";

                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>No of Packages : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_noofpgs.Text + "</td></tr></FONT>";

                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Gr.Wt : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_GrWt.Text + "</td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Dimensions : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_Dimensions.Text + "</FONT></td></tr>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Vol.Wt : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_VolWt.Text + "</td></tr><br></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Stackable / Non-Stackable : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + ddl_Stackornonstack.Text + "</td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>DG / Non-DG : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + ddl_DGNonDG.Text + "</td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Normal / Temp Control: </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + ddl_normalTempControl.Text + "</td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Shipper Address : </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_ShipperAddress.Text + "</td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Consignee Address: </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_ConsigneeAddress.Text + "</td></tr></FONT>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Rate required by / Time: </FONT></td><td align=left><FONT FACE=Arial SIZE=2 COLOR=Black>" + txt_RatrequiredbyTime.Text + "</td></tr></FONT></table>";

                sendqry = sendqry + "</br><b># Quote allin rates with Routing & Transit</b>";
                sendqry = sendqry + "</br><b># Suggested airlines : QR / EY / EK / Any other airlines</b>";
         
            Utility.SendMail(str_usermailid, shippermailadd, subject, sendqry, "", str_mailpwd);
           

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //DataAccess.HR.Employee obj_da_hre = new DataAccess.HR.Employee();
            //DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());


            txtInco_TextChanged(sender, e);
            if (blnerr == true)
            {
                return;
            }
            txt_Orgin_Airport_TextChanged(sender, e);
            if (blnerr == true)
            {
                return;
            }
            txt_Destination_Airport_TextChanged(sender, e);
            if (blnerr == true)
            {
                return;
            }
            txt_Commodity_TextChanged(sender,e);
            if (blnerr == true)
            {
                return;
            }
            if (!string.IsNullOrEmpty(txt_Orgin_Airport.Text) && !string.IsNullOrEmpty(txt_Destination_Airport.Text))
            {
                if (txt_Orgin_Airport.Text.ToString() == txt_Destination_Airport.Text.ToString())
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('Load and Destination Port Should be Different')", true);
                    txt_Destination_Airport.Focus();
                    return;
                }
            }
            if (txt_noofpgs.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('Enter the No of Packages')", true);
                txt_noofpgs.Focus();
                return;
            }
            if (txt_GrWt.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('Enter the Gross weight')", true);
                txt_GrWt.Focus();
                return;
            }
            if (txt_Dimensions.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('Enter the Dimensions')", true);
                txt_Dimensions.Focus();
                return;
            }
            if (txt_VolWt.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('Enter the Volume Weight')", true);
                txt_VolWt.Focus();
                return;
            }

            if (ddl_Stackornonstack.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('select Stackable / Non-Stackable')", true);
                ddl_Stackornonstack.Focus();
                return;
            }

            if (ddl_DGNonDG.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('select DG / Non-DG')", true);
                ddl_DGNonDG.Focus();
                return;
            }
            if (ddl_normalTempControl.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('select Normal / Temp Control')", true);
                ddl_DGNonDG.Focus();
                return;
            }
            
            //if (txt_cmailid.Text=="")
            //{
            //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "AirFreightRateReq", "alertify.alert('Enter the Mail-IDs')", true);
            //    txt_cmailid.Focus();
            //    return;
            //}

            if (btn_save.ToolTip == "Save")
            {
                str_Stackornonstack = ddl_Stackornonstack.SelectedValue;
                str_DGNonDG = ddl_DGNonDG.SelectedValue;
                str_normalTempControl = ddl_normalTempControl.SelectedValue;
                str_issuedon = txt_RatrequiredbyTime.Text;
             
               
                
                da_obj_AEBLobj.insairFreightratereq(Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hf_intfromid.Value), Convert.ToInt32(hf_inttoid.Value), Convert.ToInt32(hf_IntCOMMODITY.Value), Convert.ToInt32(txt_noofpgs.Text), Convert.ToDouble(txt_GrWt.Text), txt_Dimensions.Text, Convert.ToDouble(txt_VolWt.Text), str_Stackornonstack, str_DGNonDG, str_normalTempControl, txt_ShipperAddress.Text, txt_ConsigneeAddress.Text, Convert.ToDateTime(Utility.fn_ConvertDatetime(str_issuedon)));

                shippermailadd = "";
                for (int i = 0; i < grd_cmail.Rows.Count; i++)
                {
                    shippermailadd = shippermailadd + grd_cmail.Rows[i].Cells[0].Text + ";";
                }
                internalmailid = "";
                usermail = "";
                if (grd_cmail.Rows.Count > 0)
                {
                    for (int i = 0; i < grd_cmail.Rows.Count; i++)
                    {
                        internalmailid = internalmailid + grd_cmail.Rows[i].Cells[0].Text + ";";
                    }
                    usermail = obj_da_hre.GetMailAdd(int_empid);
                    if (internalmailid != "")
                    {
                        internalmailid = internalmailid + ";" + usermail;
                    }
                    else
                    {
                        internalmailid = usermail;
                    }
                }
                else
                {
                    usermail = obj_da_hre.GetMailAdd(int_empid);
                    internalmailid = usermail;
                }
                if (shippermailadd != "")
                {
                    shippermailadd = shippermailadd.Replace(",", ";");
                    shippermailadd = shippermailadd.Remove(shippermailadd.Length - 1, 1);
                }
                
                getbody();
                //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1801, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), " Sav");
                if (Session["StrTranType"].ToString() == "AE")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1801, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), " Sav");                
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1802, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), " Sav");                
                }
                txt_clear();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Air Freight Rate Request Details Saved');", true);
            }

        }

        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            if (Btn_cancel.ToolTip == "Cancel")
            {
                txt_clear();
                Btn_cancel.Text = "Back";
                Btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }
        public void txt_clear()
        {
            txt_cmailid.Text = "";
            txtInco.Text = "";
            txt_Orgin_Airport.Text = "";
            txt_Destination_Airport.Text = "";
            txt_Commodity.Text = "";
            txt_noofpgs.Text = "";
            txt_GrWt.Text = "";
            txt_Dimensions.Text = "";
            txt_VolWt.Text = "";
            ddl_Stackornonstack.SelectedIndex = 0;
            ddl_normalTempControl.SelectedIndex = 0;
            ddl_DGNonDG.SelectedIndex = 0;
            txt_ShipperAddress.Text = "";
            txt_ConsigneeAddress.Text = "";
            txt_RatrequiredbyTime.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
            EmptyGridmail();
        }
        protected void txtInco_TextChanged(object sender, EventArgs e)
        {
            //DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            // DataTable obj_Dt = new DataTable();
            // List<string> Incocode = new List<string>();
            // obj_Dt = bookingobj.GetLikeIncocode(prefix.ToUpper());
            int incodeid = bookingobj.Getinconame(txtInco.Text.Trim().ToUpper());
            if (incodeid != 0 && hdn_Incoid.Value != "0")
            {
                txt_Orgin_Airport.Focus();
            }

            else
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid INCO');", true);
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid INCO')", true);
                txtInco.Text = "";
                txtInco.Focus();
                blnerr = true;
                return;

            }

        }

        protected void txt_Orgin_Airport_TextChanged(object sender, EventArgs e)
        {
            if (portobj.GetNPortid(txt_Orgin_Airport.Text.Trim().ToUpper()) != 0 && hf_intfromid.Value != "0")
            {
                txt_Destination_Airport.Focus();
            }
            else
            {
             
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID From Port')", true);
                txt_Orgin_Airport.Text = "";
                txt_Orgin_Airport.Focus();
                blnerr = true;
                return;
            }
        }

        protected void txt_Destination_Airport_TextChanged(object sender, EventArgs e)
        {
            if (portobj.GetNPortid(txt_Destination_Airport.Text.Trim().ToUpper()) != 0 && hf_inttoid.Value != "0")
            {
                txt_Commodity.Focus();
            }
            else
            {
                txt_Destination_Airport.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID To Port')", true);
                txt_Destination_Airport.Focus();
                blnerr = true;
                return;
            }
        }

        protected void txt_Commodity_TextChanged(object sender, EventArgs e)
        {
            DataTable dtPort = new DataTable();
            //DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
            int cargoid = cargoobj.GetCargoid(txt_Commodity.Text.Trim().ToUpper());
            if (cargoid != 0 && hf_IntCOMMODITY.Value != "0")
            {
                txt_noofpgs.Focus();
            }
            else
            {
                txt_Commodity.Text = "";
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID COMMODITY NAME')", true);
                txt_Commodity.Focus();
                blnerr = true;
                return;
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
            Panel1.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            if (Session["StrTranType"].ToString() == "AE")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1801, "BLREL", "", "", Session["StrTranType"].ToString());
            }
            else if (Session["StrTranType"].ToString() == "AI")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1802, "BLREL", "", "", Session["StrTranType"].ToString());
            }

            //if (txt_hawb.Text != "")
            //{
            //    JobInput.Text = txt_hawb.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_cmail_PreRender(object sender, EventArgs e)
        {
            if (grd_cmail.Rows.Count > 0)
            {
                grd_cmail.UseAccessibleHeader = true;
                grd_cmail.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}