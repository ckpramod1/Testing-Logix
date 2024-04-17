using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Services;
namespace logix.Sales
{

    public partial class Customerdetailsnew : System.Web.UI.Page
    {
        public string strtrantype;
        DataTable Dt = new DataTable();
        DataAccess.Masters.MasterBranch obj_main = new DataAccess.Masters.MasterBranch();
        DataAccess.CloseJobs jobobj = new DataAccess.CloseJobs();
        DataTable dtbn = new DataTable();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
         DataTable dt_MenuRights = new DataTable();
         DataAccess.UserPermission userperobj = new DataAccess.UserPermission();
         string str_Uiid = "", str_FornName;
        int int_bid=0;
        DataAccess.ForwardingExports.PODetails obj_da_Podetails = new DataAccess.ForwardingExports.PODetails();
        DataAccess.CostingDetails da_obj_Costing = new DataAccess.CostingDetails();
        DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
        DataTable obj_dtjob = new DataTable();
        string FADbname;
        string StrScript = "";
         protected void Page_Load(object sender, EventArgs e)
         {
             ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_main.GetDataBase(Ccode);
                jobobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                userperobj.GetDataBase(Ccode);
                obj_da_Podetails.GetDataBase(Ccode);
                da_obj_Costing.GetDataBase(Ccode);
                da_obj_Branch.GetDataBase(Ccode);


                obj_da_Employee.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CH")
                {
                    ddtype1.Visible = true;
                }
                else
                {
                    ddtype1.Visible = false;
                    BlNumbern1.Attributes["class"] = "BlNumbern1";
                    BoENon1.Attributes["class"] = "BoENon1";
                }
            }


                if (!IsPostBack)
                {
                    Fn_LodaBranch();

                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "CH")
                        {
                            ddtype1.Visible = true;
                        }
                        else
                        {
                            ddtype1.Visible = false;
                            BlNumbern1.Attributes["class"] = "BlNumbern1";
                            BoENon1.Attributes["class"] = "BoENon1";
                        }
                        if (Session["StrTranType"].ToString() == "AC")
                        {
                            ddl_branch.Enabled = false;
                            ddl_module.Enabled = true;
                            ddl_branch.SelectedIndex = ddl_branch.Items.IndexOf(ddl_branch.Items.FindByText(Session["LoginBranchName"].ToString()));
                        }
                        else if (Session["StrTranType"].ToString() == "CO")
                        {
                            ddl_branch.Enabled = true;
                            ddl_module.Enabled = true;
                        }
                        else
                        {
                            ddl_branch.SelectedIndex = ddl_branch.Items.IndexOf(ddl_branch.Items.FindByText(Session["LoginBranchName"].ToString()));
                            ddl_module.SelectedIndex = ddl_module.Items.IndexOf(ddl_module.Items.FindByValue(Session["StrTranType"].ToString()));
                            ddl_module_SelectedIndexChanged(sender, e);
                            ddl_branch.Enabled = false;
                            ddl_module.Enabled = false;
                        }
                    }

                  

                    txtPickedon1.Text=Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                    txt_dutyDate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                    txt_DeliveryDate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                    txt_custreldate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());

                    
                   // txtPickedon.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                    UserRights();
                if (Request.QueryString.ToString().Contains("back"))
                {
                    txt_bl.Text = Request.QueryString["BL"].ToString();
                    if (txt_bl.Text != "")
                    {
                        Session["type"]= Request.QueryString["1typ"].ToString();
                        txt_bl_TextChanged(sender, e);
                    }

                }

            }

             
         }

         [WebMethod]
        public static List<string> Getblno(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
            DataAccess.ForwardingExports.BLDetails da_obj_FEblobj = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.AirImportExports.AIEBLDetails da_obj_blobj1 = new DataAccess.AirImportExports.AIEBLDetails();

            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_blobj.GetDataBase(Ccode);
            da_obj_FEblobj.GetDataBase(Ccode);
            da_obj_blobj1.GetDataBase(Ccode);
            if (HttpContext.Current.Session["StrTranType"].ToString() == "FE")
            {
                obj_dt = da_obj_FEblobj.GetLikeOTHERBLDetails(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else if (HttpContext.Current.Session["StrTranType"].ToString() == "CH")
            {
                obj_dt = da_obj_FEblobj.GetLikeOTHERCHBLDetails(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else if (HttpContext.Current.Session["StrTranType"].ToString() == "FI")
            {
                obj_dt = da_obj_blobj.GetLikeOTHERIBL(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else if (HttpContext.Current.Session["StrTranType"].ToString() == "AE" || HttpContext.Current.Session["StrTranType"].ToString() == "AI")
            {
                obj_dt = da_obj_blobj1.GetLikeOTHERAIEBLDetails(prefix.ToUpper(), HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (HttpContext.Current.Session["StrTranType"].ToString() == "AE" || HttpContext.Current.Session["StrTranType"].ToString() == "AI")
                {
                    blno = Utility.Fn_DatatableToList_Text(obj_dt, "hawblno");
                }
                else if (HttpContext.Current.Session["StrTranType"].ToString() == "FE" || HttpContext.Current.Session["StrTranType"].ToString() == "FI")
                {
                    blno = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
                }

                else if (HttpContext.Current.Session["StrTranType"].ToString() == "CH")
                {
                    blno = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
                }
            }

            return blno;
        }


        private void Fn_LodaBranch()
        {
          /*  ddl_branch.Items.Add("");
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            obj_dt = obj_da_Port.GetAllBranchNameforPortName();
            ddl_branch.DataSource = obj_dt;
            ddl_branch.DataTextField = "portname";
            ddl_branch.DataBind();*/
           // DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();
            int int_divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            DataTable obj_dtTemp = new DataTable();
            obj_dtTemp = da_obj_Branch.GetBranchByDivID(int_divid);
            int i;
            ddl_branch.Items.Add(new ListItem("ALL", "0"));
            for (i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
            {
                if (obj_dtTemp.Rows[i]["branch"].ToString() != "CORPORATE")
                {
                    ddl_branch.Items.Add(new ListItem(obj_dtTemp.Rows[i]["branch"].ToString(), obj_dtTemp.Rows[i]["branchid"].ToString()));
                }
            }

        }


        protected void UserRights()
        {
            //try
            //{
            //    if (Request.QueryString.ToString().Contains("type"))
            //    {
            //        Boolean btn_delete;
            //        str_FornName = Request.QueryString["type"].ToString();
            //        str_Uiid = Request.QueryString["uiid"].ToString();
            //        Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
            //        DataTable obj_Dtuser = new DataTable();
            //        obj_Dtuser = (DataTable)Session["dt_UserRights"];
            //        DataView obj_dtview = new DataView(obj_Dtuser);
            //        obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
            //        obj_Dtuser = obj_dtview.ToTable();
            //        //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


            //    }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}

            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {

                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    Boolean btn_delete;
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            UserRights();
            int int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            //int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            //branchid();
            int int_branchid = 0;
            branchid();
            if (Session["LoginBranchid"] != null)
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Branch Cannot be Blank');", true);
                ddl_module.SelectedIndex = 0;
                return;
            }
            if (int_bid == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Branch Cannot be Blank');", true);
                ddl_module.SelectedIndex = 0;
                return;
            }

            if (ddl_branch.Text.ToString().Trim().Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Branch Cannot be Blank');", true);
                ddl_module.SelectedIndex = 0;
                return;
            }
            if (ddl_module.Text.ToString().Trim().Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Select Any One Module');", true);
                return;
            }
            if (hid_trantype.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Select Any One Module');", true);
                return;
            }

         
            if (txt_bl.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Enter the BL no');", true);
                return;
            }
            if (txt_BOEno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Enter the BOE number');", true);
                return;
            }
            if (txt_curr.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Enter the Currency');", true);
                return;
            }
            if (txt_invamt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Enter the Invoice amount');", true);
                return;
            }

            if (txt_Dutyamt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Enter the Duty amount');", true);
                return;
            }
            if (txt_cusclrnote.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Enter the Custom clearance  Note');", true);
                return;
            }


            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CH")
                {
                    if (ddlJobType.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Select Any One Product type');", true);
                        return;
                    }
                }
                
            }

            if(btn_save.ToolTip=="Save")
            {



                if (Session["StrTranType"] .ToString()== "CH")
                {
                    obj_da_Podetails.spinscustomsdetails(Convert.ToInt32(txt_BOEno.Text),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)),
                       txt_curr.Text, Convert.ToDouble(txt_invamt.Text), Convert.ToDouble(txt_Dutyamt.Text),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_custreldate.Text)),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_DeliveryDate.Text)), txt_cusclrnote.Text, ddl_module.SelectedValue, int_bid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_bl.Text, ddlJobType.SelectedValue);

                }
                else
                {
                    obj_da_Podetails.spinscustomsdetails(Convert.ToInt32(txt_BOEno.Text),
                        Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)),
                        txt_curr.Text, Convert.ToDouble(txt_invamt.Text), Convert.ToDouble(txt_Dutyamt.Text),
                        Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)),
                        Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_custreldate.Text)),
                        Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_DeliveryDate.Text)), txt_cusclrnote.Text, ddl_module.SelectedValue, int_bid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_bl.Text, ddl_module.SelectedValue);

                }


                switch (hid_trantype.Value)
                {
                    case "FE":
                        Logobj.InsLogDetail(int_empid, 1964, 1, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "FESav");
                        break;

                    case "FI":
                        Logobj.InsLogDetail(int_empid, 1964, 1, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "FISav");
                        break;

                    case "AE":
                        Logobj.InsLogDetail(int_empid, 1964, 1, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "AESav");
                        break;

                    case "AI":
                        Logobj.InsLogDetail(int_empid, 1964, 1, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "AISav");
                        break;
                    case "CH":
                        Logobj.InsLogDetail(int_empid, 1964, 1, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "CHSav");
                        break;

                    default:
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Wrong TranType');", true);
                        break;
                }
                clear();
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Saved');", true);

            }
            else
            {


                if (Session["StrTranType"].ToString() == "CH")
                {
                    obj_da_Podetails.spupdcustomsdetails(Convert.ToInt32(txt_BOEno.Text),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)),
                       txt_curr.Text, Convert.ToDouble(txt_invamt.Text), Convert.ToDouble(txt_Dutyamt.Text),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_custreldate.Text)),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_DeliveryDate.Text)), txt_cusclrnote.Text, ddl_module.SelectedValue, int_bid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_bl.Text, ddlJobType.SelectedValue);
                }
                else
                {
                    obj_da_Podetails.spupdcustomsdetails(Convert.ToInt32(txt_BOEno.Text),
                      Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)),
                      txt_curr.Text, Convert.ToDouble(txt_invamt.Text), Convert.ToDouble(txt_Dutyamt.Text),
                      Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)),
                      Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_custreldate.Text)),
                      Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_DeliveryDate.Text)), txt_cusclrnote.Text, ddl_module.SelectedValue, int_bid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_bl.Text, ddl_module.SelectedValue);
                }


                switch (hid_trantype.Value)
                {
                    case "FE":
                        Logobj.InsLogDetail(int_empid, 1964, 2, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "FEupd");
                        break;

                    case "FI":
                        Logobj.InsLogDetail(int_empid, 1964, 2, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "FIupd");
                        break;

                    case "AE":
                        Logobj.InsLogDetail(int_empid, 1964, 2, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "AEupd");
                        break;

                    case "AI":
                        Logobj.InsLogDetail(int_empid, 1964, 2, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "AIupd");
                        break;
                    case "CH":
                        Logobj.InsLogDetail(int_empid, 1964, 2, int_branchid, txt_BOEno.Text + "/" + int_bid + " /" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtPickedon1.Text)) + "/" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dutyDate.Text)) + "/ " + hid_trantype.Value + " /" + "CHupd");
                        break;

                    default:
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Wrong TranType');", true);
                        break;
                }
                clear();
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Updated');", true);

            }

          //  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details update .\\n\\ Job # is  : " + Convert.ToInt32(txtJob.Text) + "');", true);


            
            clear();
            btn_back.ToolTip = "Cancel";
            lbl_back.Attributes["class"] = "btn ico-cancel";
         


        }


       
       
      



        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                clear();
                if (Request.QueryString.ToString().Contains("back"))
                {



                    Response.Redirect("../FI/FIBL.aspx?1ty=" + Session["type"]);




                }
                btn_back.ToolTip = "Back";
                lbl_back.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }



        public void clear()
        {
            /*ddl_branch.SelectedIndex = 0;
            ddl_module.SelectedIndex = 0;
            */
            Fn_LodaBranch();

            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "AC")
                {
                    ddl_branch.Enabled = false;
                    ddl_module.Enabled = true;
                    ddl_branch.SelectedIndex = ddl_branch.Items.IndexOf(ddl_branch.Items.FindByText(Session["LoginBranchName"].ToString()));
                }
                else if (Session["StrTranType"].ToString() == "CO")
                {
                    ddl_branch.Enabled = true;
                    ddl_module.Enabled = true;
                }
                else
                {
                    ddl_branch.SelectedIndex = ddl_branch.Items.IndexOf(ddl_branch.Items.FindByText(Session["LoginBranchName"].ToString()));
                    ddl_module.SelectedIndex = ddl_module.Items.IndexOf(ddl_module.Items.FindByValue(Session["StrTranType"].ToString()));
                 //   ddl_module_SelectedIndexChanged(sender, e);
                    ddl_branch.Enabled = false;
                    ddl_module.Enabled = false;
                }
            }



            txt_bl.Text = "";
            txt_BOEno.Text = "";
            txt_curr.Text = "";
            txt_invamt.Text = "";
            txt_Dutyamt.Text = "";
            txt_cusclrnote.Text = "";
            txtPickedon1.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
            txt_dutyDate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
            txt_DeliveryDate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
            txt_custreldate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
           
        }
         protected void ddl_module_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fn_LoadTranType();
        }
         private void Fn_LoadTranType()
         {
             try
             {
                 hid_trantype.Value = ddl_module.SelectedValue.ToString();
                 Session["StrTranType"] = hid_trantype.Value;
                 if (ddl_branch.Text.ToString().Trim().Length == 0)
                 {
                     ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Branch Cannot be Blank');", true);
                     ddl_module.SelectedIndex = 0;
                     return;
                 }
                 if (ddl_module.Text.ToString().Trim().Length == 0)
                 {
                     ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Select Any One Module');", true);
                     return;
                 }
             }
              
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
         }


         protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             {
                 branchid();
             }
             catch (Exception ex)
             {
                 System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                 ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
             }
         }

       

        public void branchid()
         {
             if (ddl_branch.SelectedItem.Text.TrimEnd().Length > 0)
             {
               //  DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
                 int_bid = obj_da_Employee.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), ddl_branch.SelectedItem.Text);
                 Session["LoginBranchid"] = int_bid;

             }
         }

        protected void txt_bl_TextChanged(object sender, EventArgs e)
        {
            int int_branchid = 0;
            branchid();
            if (Session["LoginBranchid"]!=null)
            {
                 int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Branch Cannot be Blank');", true);
                ddl_module.SelectedIndex = 0;
                return;
            }
            if (int_bid == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Branch Cannot be Blank');", true);
                ddl_module.SelectedIndex = 0;
                return;
            }

            if (ddl_branch.Text.ToString().Trim().Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Branch Cannot be Blank');", true);
                ddl_module.SelectedIndex = 0;
                return;
            }
            if (ddl_module.Text.ToString().Trim().Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Select Any One Module');", true);
                return;
            }
            if (hid_trantype.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Select Any One Module');", true);
                return;
            }
            DataTable obj_dt = new DataTable();
            if (txt_bl.Text.Trim().Length > 0)
            {
                obj_dt = obj_da_Podetails.spgetcustdetails(ddl_module.SelectedValue, int_bid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_bl.Text);

                if (obj_dt.Rows.Count>0)
                {
                    txt_BOEno.Text = obj_dt.Rows[0]["BOEno"].ToString();
                   

                    if (obj_dt.Rows[0]["BOEDate"].ToString().Trim().Length > 0)
                    {
                        txtPickedon1.Text = obj_dt.Rows[0]["BOEDate"].ToString();
                        //txtlbdate.Text = obj_da_Log1.GetDate();
                        txtPickedon1.Text = Convert.ToDateTime(txtPickedon1.Text).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtPickedon1.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());

                    }

                    txt_curr.Text = obj_dt.Rows[0]["InvCurr"].ToString();
                    txt_invamt.Text = Convert.ToDouble(obj_dt.Rows[0]["Invamt"]).ToString("#,0.00"); //obj_dt.Rows[0]["Invamt"].ToString();

                    txt_Dutyamt.Text = Convert.ToDouble(obj_dt.Rows[0]["DUTYamt"]).ToString("#,0.00");
                   // txt_dutyDate.Text = obj_dt.Rows[0][6].ToString();
                    if (obj_dt.Rows[0]["DUTYpiaddatetimeamt"].ToString().Trim().Length > 0)
                    {
                        txt_dutyDate.Text = obj_dt.Rows[0]["DUTYpiaddatetimeamt"].ToString();
                        //txtlbdate.Text = obj_da_Log1.GetDate();
                        txt_dutyDate.Text = Convert.ToDateTime(txt_dutyDate.Text).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txt_dutyDate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());

                    }
                    //txt_custreldate.Text = obj_dt.Rows[0][7].ToString();
                    if (obj_dt.Rows[0]["CustomesReleaseDate"].ToString().Trim().Length > 0)
                    {
                        txt_custreldate.Text = obj_dt.Rows[0]["CustomesReleaseDate"].ToString();
                        //txtlbdate.Text = obj_da_Log1.GetDate();
                        txt_custreldate.Text = Convert.ToDateTime(txt_custreldate.Text).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txt_custreldate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());

                    }
                   // txt_DeliveryDate.Text = obj_dt.Rows[0][8].ToString();

                    if (obj_dt.Rows[0]["DeliveryDate"].ToString().Trim().Length > 0)
                    {
                        txt_DeliveryDate.Text = obj_dt.Rows[0]["DeliveryDate"].ToString();
                        //txtlbdate.Text = obj_da_Log1.GetDate();
                        txt_DeliveryDate.Text = Convert.ToDateTime(txt_DeliveryDate.Text).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txt_DeliveryDate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());

                    }
                    txt_cusclrnote.Text = obj_dt.Rows[0]["CLMCLRNote"].ToString();

                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "CH")
                        {

                            ddlJobType.SelectedValue = obj_dt.Rows[0]["producttype"].ToString();
                        }
                    }

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                }
                else
                {
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }
            }
                
        }

        protected void ddlJobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hid_trantype1.Value = ddlJobType.SelectedValue.ToString();
                Session["StrTranType1"] = hid_trantype1.Value;
                if (ddl_branch.Text.ToString().Trim().Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Branch Cannot be Blank');", true);
                    ddl_module.SelectedIndex = 0;
                    return;
                }
                if (ddl_module.Text.ToString().Trim().Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CostSheet", "alertify.alert('Select Any One Module');", true);
                    return;
                }
            }

            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

       
       
    }
}