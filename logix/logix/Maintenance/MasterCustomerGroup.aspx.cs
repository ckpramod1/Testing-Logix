using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace logix.Maintenance
{
    public partial class MasterCustomerGroup : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer obj_loc = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterBranch obj_main1 = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
        DataAccess.Masters.MasterCustomer obj_cust = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort obj_port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCountry obj_country = new DataAccess.Masters.MasterCountry();
        DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        DataTable dt_main = new DataTable();
        int groupid;
        int cityid,locationid;
        DataTable dtnew = new DataTable();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);


            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            } 
            if (!IsPostBack)
            {
                txtname.Focus();
                txt_search .Enabled = false;
                btnGrdUpdate .Enabled = false;
                btnsave.Text = "Save";
            //    btncancel.Text = "Back";
                //EmptyGridShow();
                GetDetails();
                CustGroup_grid.DataSource = Utility.Fn_GetEmptyDataTable();
                CustGroup_grid.DataBind();
                Ctrl_List = txtname.ID + "~" + txtaddress.ID + "~" + txtcity.ID + "~" + txtphone.ID + "~" + txtzip.ID + "~" + txt_person.ID + "~" + txtlocation.ID;
                Msg_List = "CompanyName~Address~City~Phone~Zip~Contact Person~Location";
                Dtype_List = "string~string";
                //btnsave.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                Utility.Fn_CheckUserRights(str_Uiid, btnsave, null, null);
                btnGrdUpdate.Visible = false;
                btnview.Enabled = false;
                txtname.Focus();
            }
        }

        //[WebMethod]
        //public static List<string> GetCustomer(string prefix)
        //{
        //    List<string> List_Result = new List<string>();
        //    DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
        //    DataTable dt_cusname = new DataTable();
        //    dt_cusname = obj_main.GetLikeCustGroup(prefix.ToUpper());
        //    List_Result = Utility.Fn_DatatableToList(dt_cusname, "gname", "groupid");
        //    return List_Result;
        //}

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
            DataTable dt_cusname = new DataTable();
            dt_cusname = obj_main.GetLikeCustGroupForPota(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16DisplayNew(dt_cusname, "gname", "groupid", "custid", "address");

            return List_Result;
        }


        [WebMethod]
        public static List<string> GetCustomerSearch(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer obj_cust = new DataAccess.Masters.MasterCustomer();
            DataTable dt_cusname = new DataTable();
            dt_cusname = obj_cust.GetLikeCustomerAll(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16Display(dt_cusname,"customerid", "groupid", "groupname");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLocation(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataTable dt_Location = new DataTable();
            dt_Location = objp_location.GetLocationname(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16Display(dt_Location, "locport", "locationid", "cityname");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetPTC(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_branchmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_Bgr = new DataTable();
            dt_Bgr = obj_branchmgr.GetLikeEmployee(prefix.Trim().ToUpper());
            List_Result = Utility.Fn_TableToList(dt_Bgr, "empname", "employeeid");
            return List_Result;
        }

        

        protected void Button_save_Click(object sender, EventArgs e)
        {
            try {
            btnview.Enabled = false;
            if (hf_locationid.Value != "" || hf_locationid.Value != "0")
            {
                locationid = Convert.ToInt32(hf_locationid.Value);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct the Location Name');", true);
                txtlocation.Text = "";
                txtlocation.Focus();
                return;
               
            }

            if (hdn_cus.Value == "" || hdn_cus.Value=="0")
            {
                groupid = 0;
            }else
            {
                if (btnsave.Text == "Update")
                {
                    groupid = Convert.ToInt32(hdn_cus.Value);
                }
                
            }
            
            //if (hdn_cus.Value == "" || hdn_cus.Value == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Valid Customer Name');", true);
            //    return;
            //}

            //Ctrl_List = txtname.ID + "~" + txtaddress.ID + "~" + txtcity.ID + "~" + txtphone.ID + "~" + txtzip.ID + "~" + txt_person.ID + "~" + txtlocation.ID;
            //Msg_List = "CompanyName~Address~City~Phone~Zip~Contact Person~Location";

            if (txtname.Text == "")
            {


                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter the CompanyName');", true);
                    txtname.Text = "";
                    txtname.Focus();
                    return;
               
            }
            if (txtaddress.Text == "")
            {


                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter the Address');", true);
                txtaddress.Text = "";
                txtaddress.Focus();
                return;

            }
            if (txtcity.Text == "")
            {


                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter the City');", true);
                txtcity.Text = "";
                txtcity.Focus();
                return;

            }
            if (txtphone.Text == "")
            {


                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter the Phone');", true);
                txtphone.Text = "";
                txtphone.Focus();
                return;

            }
            if (txtzip.Text == "")
            {


                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter the Zip');", true);
                txtzip.Text = "";
                txtzip.Focus();
                return;

            }
            if (txt_person.Text == "")
            {


                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter the Contact Person');", true);
                txt_person.Text = "";
                txt_person.Focus();
                return;

            }
            if (txtlocation.Text == "")
            {


                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter the Location');", true);
                txtlocation.Text = "";
                txtlocation.Focus();
                return;

            }



            if (txtEmail.Text == "")
            {


                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Valid Email');", true);
                txtEmail.Text = "";
                txtEmail.Focus();
                return;

            }



            if (btnsave.Text == "Save")
            {
                groupid = Convert.ToInt32(obj_main.InsertCustomerDetails(txtname.Text.ToUpper(), txt_person.Text.ToUpper(), txtaddress.Text.ToUpper(), txtcity.Text.ToUpper(), txtzip.Text, txtphone.Text, txtfax.Text, txtEmail.Text.ToUpper(), locationid));
               //obj_main.InsertCustomerDetails(txtname.Text, txt_person.Text, txtaddress.Text, txtcity.Text, txtzip.Text, txtphone.Text, txtfax.Text, txtEmail.Text, locationid);
               obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 339, 1, int.Parse(Session["LoginBranchid"].ToString()), txtname.Text + "/" + groupid);                               
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert(' Details has  inserted ...');", true);
                //Clear();
                txt_search.Focus();
                txt_search.Enabled = true;
                btnGrdUpdate .Enabled = true;
                btnGrdUpdate.Visible = true;
                btnsave.Text = "Update";

            }
            else
            {
                if (btnsave.Text == "Update")
                {
                    obj_main.UpdCustGroupDetails(txtname.Text.ToUpper(), groupid, txt_person.Text.ToUpper(), txtaddress.Text.ToUpper(), txtcity.Text.ToUpper(), txtzip.Text, txtphone.Text, txtfax.Text, txtEmail.Text.ToUpper(), locationid);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 339, 2, int.Parse(Session["LoginBranchid"].ToString()), txtname.Text + "/" + groupid + "/U");                               
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert(' Details has Updated...');", true);
                    //Clear();
                    txt_search.Focus();
                    txt_search.Enabled = true;
                    btnGrdUpdate.Enabled = true;
                }

            }

                 }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        private void Clear()
        {
            txt_person.Text = "";
            txtaddress.Text = "";
            txtcity.Text = "";
            txtEmail.Text = "";
            txtfax.Text = "";
            txtlocation.Text = "";
            txtphone.Text = "";
            txtzip.Text = "";
            hdn_cus.Value = "";
            hdn_emp.Value = "";
            txt_search.Text = "";
            //EmptyGridShow();
            btnsave.Text = "Save";
            hf_locationid.Value = "";
            btncancel.Text = "Back";
            CustGroup_grid.DataSource = Utility.Fn_GetEmptyDataTable();
            CustGroup_grid.DataBind();
        }

        protected void txtname_TextChanged(object sender, EventArgs e)
        {
            try{
            btnview.Enabled = false;
           
            if (txtname.Text != "")
            {
                //groupid = obj_main.RetrieveCustGroupID(txtname.Text.ToUpper());
                //hdn_cus.Value = groupid.ToString();
                if (hdn_cus.Value == "" || hdn_cus.Value=="0")
                {
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Valid Customer Name');", true);
                    //return;
                    groupid = 0;
                }
                else
                {
                    groupid = Convert.ToInt32(hdn_cus.Value);
                }
                

                if (groupid !=0)
                {
                    DataAccess.Masters.MasterCustomer obj_loc = new DataAccess.Masters.MasterCustomer();
                    dt = obj_main.RetrieveCustGroupDetails(groupid);
                    if (dt.Rows.Count > 0)
                    {
                        txtaddress.Text = dt.Rows[0][1].ToString();
                        cityid = Convert.ToInt32(dt.Rows[0][2].ToString());
                        txtcity.Text = obj_port.GetPortname(cityid);

                        hf_locationid.Value = dt.Rows[0][10].ToString();
                        
                        if (hf_locationid.Value != "")
                        {
                            txtlocation.Text = obj_loc.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                         

                        }
                        txtzip.Text = dt.Rows[0][3].ToString();
                        txt_person.Text = dt.Rows[0][4].ToString();
                        txtphone.Text = dt.Rows[0][5].ToString();
                        txtfax.Text = dt.Rows[0][6].ToString();
                        txtEmail.Text = dt.Rows[0][7].ToString();

                        btnsave.Text = "Update";
                        btncancel.Text = "Cancel";
                        btnGrdUpdate.Visible = true;
                        btnGrdUpdate.Enabled = true;
                        txtname.Focus();
                    }
                    dt_main = obj_main.RetrieveMasterCustGroupIDs(groupid);

                    if (dt_main.Rows.Count > 0)
                    {
                        CustGroup_grid.DataSource = Utility.Fn_GetEmptyDataTable();
                        CustGroup_grid.DataSource = dt_main;
                        CustGroup_grid.DataBind();
                        btnGrdUpdate.Visible = true;
                        btnGrdUpdate.Enabled = true;
                        for (int i = 0; i <= dt_main.Rows.Count-1; i++)
                        {
                            if (CustGroup_grid.Rows[i].Cells[4].Text == hdn_cus.Value)
                            {
                                CheckBox chkRows = (CustGroup_grid.Rows[i].Cells[3].FindControl("chkRow") as CheckBox);
                                chkRows.Checked = true;
                            }
                        }
                    }
                    else
                    {
                        //EmptyGridShow();
                        CustGroup_grid.DataSource = Utility.Fn_GetEmptyDataTable();
                        CustGroup_grid.DataBind();
                        txtaddress.Focus();
                    }
                    GetDetails();
                }
                else if (hid_custid.Value != "0" || hid_custid.Value != "")
                {
                    dt = obj_cust.RetrieveCustomerDetails(Convert.ToInt32(hid_custid.Value));
                    if (dt.Rows.Count > 0)
                    {
                        txtaddress.Text = dt.Rows[0][0].ToString();
                        cityid = Convert.ToInt32(dt.Rows[0][1].ToString());
                        txtcity.Text = obj_port.GetPortname(cityid);

                        hf_locationid.Value = dt.Rows[0]["locationid"].ToString();

                        if (hf_locationid.Value != "")
                        {
                            txtlocation.Text = obj_loc.GetLocationname(Convert.ToInt32(hf_locationid.Value));


                        }
                        txtzip.Text = dt.Rows[0][2].ToString();
                        txt_person.Text = dt.Rows[0]["ptc"].ToString();
                        txtphone.Text = dt.Rows[0]["phone"].ToString();
                        txtfax.Text = dt.Rows[0]["fax"].ToString();
                        txtEmail.Text = dt.Rows[0]["email"].ToString();
                    }
                }

                
                
                else
                {
                    Clear();
                    btnsave.Text = "Save";
                    btncancel.Text = "Cancel";
                    txtaddress.Focus();
                }

                
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            //txtname.Focus();
        }

        protected void CustGroup_grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {

                e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));

            }

          
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
           // GridBind();
        }

        protected void GridBind()
        {
            btnview.Enabled = false;

            DataTable dt_search = new DataTable();

            dt_search = obj_cust.GetLikeCustomerAll(txt_search.Text.ToUpper());

            if (dt_search.Rows.Count > 0)
            {
                CustGroup_grid.DataSource = Utility.Fn_GetEmptyDataTable();
                CustGroup_grid.DataSource = dt_search;
                CustGroup_grid.DataBind();
                btnGrdUpdate.Enabled = true;
                btnGrdUpdate.Visible = true;
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnview.Enabled = false;
           
            if (btncancel.Text == "Cancel")
            {
                Clear();
                txtname.Text = "";
                //EmptyGridShow();
                CustGroup_grid.DataSource = Utility.Fn_GetEmptyDataTable();
                CustGroup_grid.DataBind();
                CustGroup_grid.Visible = true;
                btnsave.Text = "Save";
                btncancel.Text = "Back";
                //CustGroup_grid.Visible = false;
                btnGrdUpdate.Visible = false;
                txtname.Focus();
                           
                DataTable dtapp = new DataTable();
                dtapp.Columns.Add("Customer");
                dtapp.Columns.Add(" Details");
                DataRow dr1 = dtapp.NewRow();
                dr1[0] = "PAN #";
                // dr1[1] = dt_retv.Rows[0][2].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "REG #";

                //   dr1[1] = dt_retv.Rows[0][3].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "REG Date";
                //  dr1[1] = Utility.fn_ConvertDate(rgdate1);
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "InCorp Date";
                //   dr1[1] = Utility.fn_ConvertDate(indate1);
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "DOC Recv";
                // dr1[1] = dt_retv.Rows[0][6].ToString();
                dtapp.Rows.Add(dr1);


                dr1 = dtapp.NewRow();
                dr1[0] = "Owner";
                // dr1[1] = Ownername;
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "Sales Person";
                // dr1[1] = salname;
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "Volume ";
                // dr1[1] = dt_retv.Rows[0]["volume"].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "Revenue ";
                //  dr1[1] = dt_retv.Rows[0]["revenue"].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "PTC ";
                // dr1[1] = dt_retv.Rows[0][7].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "Phone";
                //  dr1[1] = dt_retv.Rows[0][8].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "Mobile";
                //  dr1[1] = dt_retv.Rows[0][9].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "EMail";
                // dr1[1] = dt_retv.Rows[0][10].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "about";
                //dr1[1] = dt_retv.Rows[0][15].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "credit days";
                //  dr1[1] = dt_retv.Rows[0][16].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "credit amt";
                //  dr1[1] = dt_retv.Rows[0][17].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "credit type";
                //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][18].ToString());
                dtapp.Rows.Add(dr1);

                //dr1 = dtapp.NewRow();
                //dr1[0] = "OwnerId";
                //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][19].ToString());
                //dtapp.Rows.Add(dr1);

                //dr1 = dtapp.NewRow();
                //dr1[0] = "SalesId";
                //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                //dtapp.Rows.Add(dr1);

                test.DataSource = dtapp;
                test.DataBind();
            
            }

            else if (btncancel.Text == "Back")
            {
                Clear();
                this.Response.End();
            }
        }

        protected void btnGrdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnview.Enabled = false;
                int cusid = 0;
                int count = 0;
               // groupid = obj_main.RetrieveCustGroupID(txtname.Text.ToUpper());
                groupid = Convert.ToInt32(hdn_cus.Value); // added on 14 jun 2022
                if (CustGroup_grid.Rows.Count > 0)
                {
                    for (int i = 0; i < CustGroup_grid.Rows.Count; i++)
                    {
                        CheckBox chkRows = (CustGroup_grid.Rows[i].Cells[3].FindControl("chkRow") as CheckBox);
                        string cusval = CustGroup_grid.Rows[i].Cells[2].Text.ToString();
                         cusid = Convert.ToInt32(cusval);
                        
                        if (chkRows.Checked == true)
                        {
                            obj_main.UpdateCustomerGroupid(cusid, groupid, 1);
                            count = 1;
                        }
                        else
                        {
                            obj_main.UpdateCustomerGroupid(cusid, groupid, 0);
                            count = 1;
                        }

                    }
                }

                if (count == 1)
                {
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 339, 1, int.Parse(Session["LoginBranchid"].ToString()), "Link Customer with Group - " + groupid + "cusid:" + cusid);                               
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert(' Details has Updated...');", true);
                    //btnGrdUpdate.Enabled = false;
                    txt_search.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        private void EmptyGridShow()
        {
            DataTable dt1 = new DataTable();

            //dt1.Columns.Add("sno");
            dt1.Columns.Add("customer");
            dt1.Columns.Add("portname");
            dt1.Columns.Add("select");
            dt1.Columns.Add("groupid");
            dt1.Rows.Add(dt1.NewRow());

            CustGroup_grid.DataSource = dtnew;
            CustGroup_grid.DataSource = dt1;
            CustGroup_grid.DataBind();
            CustGroup_grid.Rows[0].Visible = false;
            btnview.Enabled = false;

        }

        protected void txtzip_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtphone_TextChanged(object sender, EventArgs e)
        {

        }
        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }
       
        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            //if (txtEmail.Text!="")
            //{

            //    if (IsValidEmailId(txtEmail.Text))
            //    {

            //        txtfax.Focus();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
            //        txtEmail.Text = "";
            //        txtEmail.Focus();
            //        return;
            //    }
            //}

            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
            //    txtEmail.Text = "";
            //    txtEmail.Focus();
            //}


            //string mail = txtEmail.Text;
            //Regex regex = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            //Match match = regex.Match(mail);
            //if (!match.Success)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('is Invalid Email Address');", true);
            //    txtEmail.Text = "";
            //    txtEmail.Focus();
            //    return;
            //} 
           
        }

        protected void txtlocation_TextChanged(object sender, EventArgs e)
        {
            DataTable dt_check = new DataTable();
            DataTable dt_locdet = new DataTable();
            dt_check = objp_location.CheckDuplicateForLocation(txtlocation.Text.ToUpper());
            if (dt_check.Rows.Count > 0 && hf_locationid.Value == "")
            {
                hf_locationid.Value = dt_check.Rows[0]["locationid"].ToString();
            }

            if (hf_locationid.Value != "")
            {
                locationid = Convert.ToInt32(hf_locationid.Value.ToString());
                dt_locdet = objp_location.SelLocationDeatils(locationid);
                if (dt_locdet.Rows.Count > 0)
                {
                   // txtcity.Text = dt_locdet.Rows[0]["portname"].ToString();
                    
                    //txtzip.Text = dt_locdet.Rows[0]["pincode"].ToString();
                    //cityid = Convert.ToInt32(dt_locdet.Rows[0]["portid"].ToString());
                    //hdn_cityid.Value = dt_locdet.Rows[0]["portid"].ToString();
                    txtphone.Focus();
                    btncancel.Text = "Cancel";
                }

                
            }
            else
            {
                btnsave.Text = "Save";
                txtcity.Focus();
            }
            
        }

        protected void CustGroup_grid_PageIndexChanged(object sender, EventArgs e)
        {
                 
        }

        protected void CustGroup_grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CustGroup_grid.PageIndex = e.NewPageIndex;
            GridBind();
        }
        protected void txt_Search_TextChanged(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void GetBanName(string Prefix)
        {
            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
                DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                DataTable obj_dt = new DataTable();
                obj_dt = da_obj_customerobj.GetLikeCustomerAll(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("customerid");
                obj_dtEmp.Columns.Add("customername");
                obj_dtEmp.Columns.Add("portname");
                obj_dtEmp.Columns.Add("groupid");
                obj_dtEmp.Columns.Add("grdblselect");

                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    int c = 0;
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["customerid"] = obj_dt.Rows[i][0].ToString();
                    dr["customername"] = obj_dt.Rows[i][1].ToString();
                    c = Convert.ToInt32(obj_dt.Rows[i][3].ToString());
                    //da_obj_portobj.GetPortname(c);
                    dr["groupid"] = obj_dt.Rows[i][5].ToString();
                    da_obj_portobj.GetPortname(c);
                    dr["portname"] = da_obj_portobj.GetPortname(c);
                    dr["grdblselect"] = obj_dt.Rows[i][3].ToString();


                }
                HttpContext.Current.Session["Date"] = obj_dtEmp;
            }

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            try
            {

                DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
                DataTable obj_dtEmp = new DataTable();
                if (txt_search .Text != "")
                {
                    if (Session["Date"] != null)
                    {
                        obj_dtEmp = (DataTable)Session["Date"];
                        CustGroup_grid.DataSource = obj_dtEmp;
                        Session["grd"] = obj_dtEmp;
                        CustGroup_grid.DataBind();

                        for (int i = 0; i  <= obj_dtEmp.Rows.Count -1; i++)
                        {
                            if(CustGroup_grid.Rows[i].Cells[4].Text == hdn_cus.Value)
                            {
                                CheckBox chkRows = (CustGroup_grid.Rows[i].Cells[3].FindControl("chkRow") as CheckBox);
                                if(hdn_cus.Value == "0")
                                {
                                    chkRows.Checked = false;
                                }
                                else
                                {
                                    chkRows.Checked = true;
                                }
                                
                            }
                        }

                    }
                    txt_search.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
                }
                else
                {
                    CustGroup_grid.DataSource = null;
                    CustGroup_grid.DataBind();
                    txt_search.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 339, "Mswebmaster", txtname.Text, txtname.Text, "");  //"/Rate ID: " +
            if (txtname.Text != "")
            {
                JobInput.Text = txtname.Text;

            }
            else
            {
                JobInput.Text = "";
            }


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }


        private void GetDetails()
        {
            if (groupid != 0)
            {
                // groupid = obj_cusgruopname.GetCustomerGroupID(txt_customer.Text.ToUpper().Trim());
                DataTable dt_retv = new DataTable();
                DataTable dtcredit = new DataTable();
                DataAccess.Masters.MasterCreditApproval Appro_obj = new DataAccess.Masters.MasterCreditApproval();
                DataAccess.Masters.MasterEmployee obj_emp = new DataAccess.Masters.MasterEmployee();
                DataSet dtset = new DataSet();
                string Ownername, salname;
                // string rgdate1;
                // string indate1;
                int SalesId, OwnerId, category;
                int intDivID = Convert.ToInt16(Session["LoginDivisionId"].ToString());
                dtset = Appro_obj.RetrieveCreditAppDtsNew(groupid, intDivID);
                if (dtset.Tables.Count > 0)
                {
                    dt_retv = dtset.Tables[0];
                    dtcredit = dtset.Tables[1];
                }
                //dt_retv = Appro_obj.RetrieveCreditAppDtsNew(groupid, DivsnId);
                hdf_cusid.Value = groupid.ToString();
                if (dt_retv.Rows.Count > 0)
                {


                    Book2.Visible = true;
                    category = Convert.ToInt32(dt_retv.Rows[0][1].ToString());
                    String rgdate1 = dt_retv.Rows[0][4].ToString();
                    String indate1 = dt_retv.Rows[0][5].ToString();
                    OwnerId = Convert.ToInt32(dt_retv.Rows[0][19].ToString());

                    SalesId = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                    hid_sal.Value = SalesId.ToString();
                    Ownername = obj_main1.GetShortName(OwnerId);
                    hid_own.Value = OwnerId.ToString();
                    salname = obj_emp.GetEmployeeName(SalesId);

                    DataTable dtapp = new DataTable();
                    dtapp.Columns.Add("Customer");
                    dtapp.Columns.Add(" Details");
                    DataRow dr1 = dtapp.NewRow();
                    dr1[0] = "PAN #";
                    dr1[1] = dt_retv.Rows[0][2].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "REG #";
                    dr1[1] = dt_retv.Rows[0][3].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "REG Date";
                    dr1[1] = Utility.fn_ConvertDate(rgdate1);
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "InCorp Date";
                    dr1[1] = Utility.fn_ConvertDate(indate1);
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "DOC Recv";
                    dr1[1] = dt_retv.Rows[0][6].ToString();
                    dtapp.Rows.Add(dr1);


                    dr1 = dtapp.NewRow();
                    dr1[0] = "Owner";
                    dr1[1] = Ownername;
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Sales Person";
                    dr1[1] = salname;
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Volume ";
                    dr1[1] = dt_retv.Rows[0]["volume"].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Revenue ";
                    dr1[1] = dt_retv.Rows[0]["revenue"].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "PTC ";
                    dr1[1] = dt_retv.Rows[0][7].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Phone";
                    dr1[1] = dt_retv.Rows[0][8].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Mobile";
                    dr1[1] = dt_retv.Rows[0][9].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "EMail";
                    dr1[1] = dt_retv.Rows[0][10].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "about";
                    dr1[1] = dt_retv.Rows[0][15].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit days";
                    dr1[1] = dt_retv.Rows[0][16].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit amt";
                    dr1[1] = dt_retv.Rows[0][17].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit type";
                    dr1[1] = Convert.ToInt32(dt_retv.Rows[0][18].ToString());
                    dtapp.Rows.Add(dr1);
                    test.DataSource = dtapp;
                    test.DataBind();


                }
                else
                {
                    DataTable dtapp = new DataTable();
                    dtapp.Columns.Add("Customer");
                    dtapp.Columns.Add(" Details");
                    DataRow dr1 = dtapp.NewRow();
                    dr1[0] = "PAN #";
                    // dr1[1] = dt_retv.Rows[0][2].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "REG #";

                    //   dr1[1] = dt_retv.Rows[0][3].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "REG Date";
                    //  dr1[1] = Utility.fn_ConvertDate(rgdate1);
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "InCorp Date";
                    //   dr1[1] = Utility.fn_ConvertDate(indate1);
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "DOC Recv";
                    // dr1[1] = dt_retv.Rows[0][6].ToString();
                    dtapp.Rows.Add(dr1);


                    dr1 = dtapp.NewRow();
                    dr1[0] = "Owner";
                    // dr1[1] = Ownername;
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Sales Person";
                    // dr1[1] = salname;
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Volume ";
                    // dr1[1] = dt_retv.Rows[0]["volume"].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Revenue ";
                    //  dr1[1] = dt_retv.Rows[0]["revenue"].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "PTC ";
                    // dr1[1] = dt_retv.Rows[0][7].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Phone";
                    //  dr1[1] = dt_retv.Rows[0][8].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Mobile";
                    //  dr1[1] = dt_retv.Rows[0][9].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "EMail";
                    // dr1[1] = dt_retv.Rows[0][10].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "about";
                    //dr1[1] = dt_retv.Rows[0][15].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit days";
                    //  dr1[1] = dt_retv.Rows[0][16].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit amt";
                    //  dr1[1] = dt_retv.Rows[0][17].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit type";
                    //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][18].ToString());
                    dtapp.Rows.Add(dr1);

                    //dr1 = dtapp.NewRow();
                    //dr1[0] = "OwnerId";
                    //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][19].ToString());
                    //dtapp.Rows.Add(dr1);

                    //dr1 = dtapp.NewRow();
                    //dr1[0] = "SalesId";
                    //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                    //dtapp.Rows.Add(dr1);

                    test.DataSource = dtapp;
                    test.DataBind();
                }




            }
            else
            {
                DataTable dtapp = new DataTable();
                dtapp.Columns.Add("Customer");
                dtapp.Columns.Add(" Details");
                DataRow dr1 = dtapp.NewRow();
                dr1[0] = "PAN #";
                // dr1[1] = dt_retv.Rows[0][2].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "REG #";

                //   dr1[1] = dt_retv.Rows[0][3].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "REG Date";
                //  dr1[1] = Utility.fn_ConvertDate(rgdate1);
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "InCorp Date";
                //   dr1[1] = Utility.fn_ConvertDate(indate1);
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "DOC Recv";
                // dr1[1] = dt_retv.Rows[0][6].ToString();
                dtapp.Rows.Add(dr1);


                dr1 = dtapp.NewRow();
                dr1[0] = "Owner";
                // dr1[1] = Ownername;
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "Sales Person";
                // dr1[1] = salname;
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "Volume ";
                // dr1[1] = dt_retv.Rows[0]["volume"].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "Revenue ";
                //  dr1[1] = dt_retv.Rows[0]["revenue"].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "PTC ";
                // dr1[1] = dt_retv.Rows[0][7].ToString();
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();
                dr1[0] = "Phone";
                //  dr1[1] = dt_retv.Rows[0][8].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "Mobile";
                //  dr1[1] = dt_retv.Rows[0][9].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "EMail";
                // dr1[1] = dt_retv.Rows[0][10].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "about";
                //dr1[1] = dt_retv.Rows[0][15].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "credit days";
                //  dr1[1] = dt_retv.Rows[0][16].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "credit amt";
                //  dr1[1] = dt_retv.Rows[0][17].ToString();
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "credit type";
                //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][18].ToString());
                dtapp.Rows.Add(dr1);

                //dr1 = dtapp.NewRow();
                //dr1[0] = "OwnerId";
                //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][19].ToString());
                //dtapp.Rows.Add(dr1);

                //dr1 = dtapp.NewRow();
                //dr1[0] = "SalesId";
                //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                //dtapp.Rows.Add(dr1);

                test.DataSource = dtapp;
                test.DataBind();
            }
        }

    }
}