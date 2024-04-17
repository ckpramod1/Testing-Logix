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
using System.Web.Services.Description;


namespace logix.Maintenance
{
    public partial class MasterCityUpdate : System.Web.UI.Page
    {
        DataAccess.Masters.MasterLocation Obj_location = new DataAccess.Masters.MasterLocation();
        DataAccess.Masters.MasterPort Obj_Port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.CityUpdate Obj_City = new DataAccess.Masters.CityUpdate();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        DataTable dt = new DataTable();
        string Ctrl_List, Msg_List, Dtype_List, str_Uiid = "", FADbname;
        bool blnerr;
        int BranchID, Div_ID, EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Obj_location.GetDataBase(Ccode);
                Obj_Port.GetDataBase(Ccode);
                Obj_City.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               

            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            FADbname = Session["FADbname"].ToString();
            BranchID = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            Div_ID = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            EmpId = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());

            if (!IsPostBack)
            {
                try
                {
                    Ctrl_List = txtpincode.ID + "~" + txtlocation.ID + "~" + txtcity.ID + "~" + txtstate.ID;
                    Msg_List = "Pincode~Location~Port~State";
                    Dtype_List = "string~string~string~string";
                    btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                    btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        [WebMethod]
        public static List<string> GetPincode(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataAccess.Masters.CityUpdate Obj_City = new DataAccess.Masters.CityUpdate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_location.GetDataBase(Ccode);
            Obj_City.GetDataBase(Ccode);
            //obj_dt = objp_location.GetlocationnameNEWpincode(prefix);
            obj_dt = Obj_City.GetPinCode(prefix);
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "pinCode");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLocation(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataAccess.Masters.CityUpdate Obj_City = new DataAccess.Masters.CityUpdate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_location.GetDataBase(Ccode);
            Obj_City.GetDataBase(Ccode);
            DataTable dt_Location = new DataTable();
            //dt_Location = objp_location.GetlocationnameNEWLocation(prefix);
            //List_Result = Utility.Fn_DatatableToList(dt_Location, "stateid", "locationid", "Location");

            dt_Location = Obj_City.GetLocationname(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt_Location, "Location", "locationid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetPortName(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.CityUpdate Obj_City = new DataAccess.Masters.CityUpdate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            Obj_City.GetDataBase(Ccode);
            dt = Obj_City.GetCity(prefix.ToUpper());
            //dt = obj_MasterPort.GetPortNameDetails(prefix);
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;
        }

        [WebMethod]
        public static List<string> GetState(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataAccess.Masters.CityUpdate Obj_City = new DataAccess.Masters.CityUpdate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_location.GetDataBase(Ccode);
            Obj_City.GetDataBase(Ccode);
            //dt = objp_location.GetState(prefix);
            dt = Obj_City.GetStatename(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dt, "statename", "stateid");
            return list_result;
        }

        protected void txtpincode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int ID; string S;

                //dt = location.GetPincodeDetailsForLocation(txtpincode.Text);
                //if (dt.Rows.Count > 0)
                //{
                //    lstLocation.Visible = true;
                //    lstLocation.Items.Clear();
                //    lstLocation.DataSource = dt;
                //    lstLocation.DataValueField = "Location";
                //    lstLocation.DataBind();
                //    btnCancel.Text = "Cancel";
                //    btnSave.Text = "Update";
                //}
                //statefill();
                //btnCancel.Text = "Back";

                DataTable dt = new DataTable();
                dt = Obj_City.GetPincode4location(txtpincode.Text);

                if (dt.Rows.Count > 0)
                {
                    lstLocation.DataSource = dt;
                    lstLocation.DataValueField = "Location";
                    lstLocation.DataBind();

                    hdf_location.Value = dt.Rows[0]["locationid"].ToString();
                    btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";

                    if (dt.Rows.Count > 1)
                    {
                        S = Obj_City.GetPort4loct(txtpincode.Text.Trim());
                        if (S != "")
                        {
                            txtcity.Text = Obj_City.GetPort4loct(txtpincode.Text.Trim());

                            if (txtcity.Text.Length <= 1)
                            {
                                txtcity.Text = "";
                            }
                        }
                        else
                        {
                            txtcity.Text = "";
                        }
                        txtstate.Text = dt.Rows[0]["state"].ToString();
                        hf_portid.Value = dt.Rows[0]["cityport"].ToString();
                        hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        txtlocation.Text = dt.Rows[0]["location"].ToString();
                        txtstate.Text = dt.Rows[0]["state"].ToString();
                        hf_portid.Value = dt.Rows[0]["cityport"].ToString();
                        hf_stateid.Value = dt.Rows[0]["stateid"].ToString();

                        S = Obj_City.GetPort4loctid(Convert.ToInt32(hdf_location.Value));
                        if (S != "")
                        {
                            ID = Convert.ToInt32(Obj_City.GetPort4loctid(Convert.ToInt32(hdf_location.Value)).ToString());
                            txtcity.Text = Obj_Port.GetPortname(ID);

                            if (txtcity.Text.Length <= 1)
                            {
                                txtcity.Text = "";
                            }
                        }
                        else
                        {
                            txtcity.Text = "";
                        }
                    }
                    btnSave.ToolTip = "Save";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Already Exists')", true);
                }
                else
                {
                    btnSave.Text = "Save";


                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lstLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtlocation.Text = lstLocation.SelectedValue.ToString();
            dt = Obj_location.CheckDuplicateForLocationPincode(txtlocation.Text.ToUpper(), txtpincode.Text);
            if (dt.Rows.Count > 0)
            {
                hdf_location.Value = dt.Rows[0]["locationid"].ToString();
                btnSave.Text = "Update";


                getcity();
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
            }
        }

        private void statefill()
        {
            if (txtpincode.Text != "")
            {
                int code;
                code = Convert.ToInt32(txtpincode.Text.Substring(0, 2));
                if (code == 11)
                {
                    txtstate.Text = "Delhi";
                }
                else if (code == 12 && code == 13)
                {
                    txtstate.Text = "Haryana";
                }
                else if (code >= 14 && code <= 16)
                {
                    txtstate.Text = "Punjab";
                }
                else if (code == 17)
                {
                    txtstate.Text = "Himachal Pradesh";
                }
                else if (code == 18 && code == 19)
                {
                    txtstate.Text = "Jammu & Kashmir";
                }
                else if (code >= 20 && code <= 28)
                {
                    txtstate.Text = "Uttar Pradesh";
                }
                else if (code >= 30 && code <= 34)
                {
                    txtstate.Text = "Rajasthan";
                }
                else if (code >= 36 && code <= 39)
                {
                    txtstate.Text = "Gujarat";
                }
                else if (code >= 40 && code <= 44)
                {
                    txtstate.Text = "Maharashtra";
                }
                else if (code >= 45 && code <= 48)
                {
                    txtstate.Text = "Madhya Pradesh";
                }
                else if (code == 49)
                {
                    txtstate.Text = "Chhattisgarh";
                }
                else if (code >= 50 && code <= 53)
                {
                    txtstate.Text = "Andhra Pradesh";
                }
                else if (code >= 60 && code <= 64)
                {
                    txtstate.Text = "Tamil Nadu";
                }
                else if (code >= 67 && code <= 69)
                {
                    txtstate.Text = "Kerala";
                }
                else if (code >= 70 && code <= 74)
                {
                    txtstate.Text = "West Bengal";
                }
                else if (code >= 75 && code <= 77)
                {
                    txtstate.Text = "Orissa";
                }
                else if (code == 78)
                {
                    txtstate.Text = "Assam";
                }
                else if (code >= 80 && code <= 85)
                {
                    txtstate.Text = "Bihar";
                }

                code = Convert.ToInt32(txtpincode.Text.Substring(0, 3));
                if (code == 682)
                {
                    txtstate.Text = "Lakshadweep";
                }
                else if (code == 744)
                {
                    txtstate.Text = "Andaman & Nicobar";
                }
                else if (code == 790)
                {
                    txtstate.Text = "Arunachal Pradesh";
                }
                else if (code == 795)
                {
                    txtstate.Text = "Manipur";
                }
                else if (code >= 793 && code <= 794)
                {
                    txtstate.Text = "Meghalaya";

                }
                else if (code == 796)
                {
                    txtstate.Text = "Mizoram";
                }
                else if (code >= 797 && code <= 798)
                {
                    txtstate.Text = "Nagaland";
                }
                else if (code == 799)
                {
                    txtstate.Text = "Tripura";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Back")
            {
                this.Response.End();
            }
            else
            {
                clear();
            }
        }

        private void clear()
        {
            txtpincode.Text = "";
            txtlocation.Text = "";
            lstLocation.Items.Clear();
            txtcity.Text = "";
            txtstate.Text = "";
            btnCancel.Text = "Back";
            btnSave.Text = "Save";

            btnCancel.ToolTip = "Back";
            btnCancel1.Attributes["class"] = "btn ico-back";

            btnSave.ToolTip = "Save";
            btnSave1.Attributes["class"] = "btn ico-save";
        }

        protected void txtlocation_TextChanged(object sender, EventArgs e)
        {
           /* if(hdf_location.Value=="" && hdf_location.Value=="0")
            {
                btnSave.ToolTip = "Save";
                btnSave1.Attributes["class"] = "btn ico-save";
            }
            else
            {
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn btn-update1";
            }*/


        }
        public void  getcity()
        {
            string Pin = "";
            btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
            DataTable dtLoc = new DataTable();
            DataTable dtState = new DataTable();
            if (txtlocation.Text != "")
            {

                dtLoc = Obj_City.GetLocName(Convert.ToInt32(hdf_location.Value));
                if (dtLoc.Rows.Count > 0)
                {
                    Pin = dtLoc.Rows[0]["pincode"].ToString();
                    if (txtpincode.Text == Pin)
                    {
                        txtpincode.Text = dtLoc.Rows[0]["pincode"].ToString();
                        txtlocation.Text = dtLoc.Rows[0]["locationname"].ToString();
                        txtstate.Text = dtLoc.Rows[0]["state"].ToString();
                        hf_stateid.Value = dtLoc.Rows[0]["stateid"].ToString();
                        hdf_location.Value = dtLoc.Rows[0]["locationid"].ToString();


                        if ((txtpincode.Text != "") && (txtlocation.Text != "") && (txtstate.Text != ""))
                        {
                            dtState = Obj_City.GetCity4Loc(Convert.ToInt32(hf_stateid.Value), Convert.ToInt32(hdf_location.Value), txtpincode.Text.Trim());
                            if (dtState.Rows.Count > 0)
                            {
                                if (dtState.Rows[0]["cityport"].ToString() != "")
                                {
                                    hf_portid.Value = dtState.Rows[0]["cityport"].ToString();
                                    txtcity.Text = dtState.Rows[0]["portname"].ToString();
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        if (lstLocation.Items.Count > 0)
                        {
                            int count = 0;
                            for (int i = 0; i <= lstLocation.Items.Count - 1; i++)
                            {
                                string vale = lstLocation.Items[i].Text;
                                if (txtlocation.Text != vale)
                                {
                                    //lstLocation.Items.Add(txtlocation.Text);
                                    count = 1;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Already  Exists Location Name')", true);

                                    break;
                                }
                            }
                            if (count == 1)
                            {
                                lstLocation.Items.Add(txtlocation.Text);
                            }
                        }
                        else
                        {
                            lstLocation.Items.Add(txtlocation.Text);
                        }


                        //lstLocation.DataValueField = txtlocation.Text;
                        //lstLocation.DataBind();
                    }

                }


            }
        }

        protected void txtcity_TextChanged(object sender, EventArgs e)
        {
            btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtstate_TextChanged(object sender, EventArgs e)
        {
            btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (btnSave.Text == "Update")
            //{
            //    if (hdf_location.Value != "" && hf_portid.Value != "")
            //    {
            //        location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hdf_location.Value));
            //        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1695, 2, int.Parse(Session["LoginBranchid"].ToString()), "/CityId: " + hdf_location.Value + "/City" + txtcity.Text + "/Upd");
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "City Update", "alertify.alert(' Details Updated Successfully');", true);
            //        clear();
            //    }
            //}     

            DataTable dtLocation = new DataTable();
            CheckData();

            if (blnerr == true)
            {
                blnerr = false;
                return;
            }

            if (btnSave.ToolTip == "Update")
            {
                if (hdf_location.Value != "" && hdf_location.Value=="0")
                {
                    Obj_City.Updport4location(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hdf_location.Value), txtpincode.Text.Trim());
                }
                else
                {
                    dtLocation = Obj_City.CheckDuplicateForLocationPincode(txtlocation.Text.Trim().ToUpper(), txtpincode.Text.Trim());
                }
               
                if (dtLocation.Rows.Count > 0)
                {
                    dt = Obj_City.GetPortNameForNew(txtcity.Text);
                    if (dt.Rows.Count > 0)
                    {
                        hf_portid.Value = dt.Rows[0][0].ToString();
                        hdf_location.Value = dtLocation.Rows[0]["locationid"].ToString();
                        Obj_City.Updport4location(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hdf_location.Value), txtpincode.Text.Trim());
                    }
                    obj_da_Log.InsLogDetail(EmpId, 1695, 2, BranchID, "/CityId: " + hf_portid.Value + "/City" + txtcity.Text + "/Upd");
                }
                //else
                //{
                //    // DataTable dt = new DataTable();
                //    //dt = Obj_City.GetPortNameForNew(txtcity.Text);
                //    // if (dt.Rows.Count > 0)
                //    // {
                //    //  hf_portid.Value = dt.Rows[0][0].ToString();
                //    if(lstLocation.Items.Count>0)
                //    {
                //        for (int i = 0; i <= lstLocation.Items.Count-1; i++)
                //        {
                //            string vale = lstLocation.Items[i].Text;
                //            Obj_City.Insertport4location(txtpincode.Text.Trim(), vale.ToUpper(), Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_stateid.Value));
                //        }
                //    }
                //    else
                //    {
                //        Obj_City.Insertport4location(txtpincode.Text.Trim(), txtlocation.Text.ToUpper(), Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_stateid.Value));
                //    }
                   
                //    //Obj_City.Updport4location(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hdf_location.Value), txtpincode.Text.Trim());
                //    obj_da_Log.InsLogDetail(EmpId, 1695, 2, BranchID, "/CityId: " + hf_portid.Value + "/City" + txtcity.Text + "/Upd");
                //    // }

                //}

                lstLocation.Items.Clear();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Updated')", true);
            }
            else if (btnSave.ToolTip == "Save")
            {
                if(lstLocation.Items.Count>0)
                {
                    //for (int i = 0; i <= lstLocation.Items.Count-1; i++)
                    //{
                    //    string vale = lstLocation.Items[i].Text;
                        Obj_City.Insertport4location(txtpincode.Text.Trim(), txtlocation.Text.ToUpper(), Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_stateid.Value));
                        obj_da_Log.InsLogDetail(EmpId, 1695, 1, BranchID, "/CityId: " + hf_portid.Value + "/City" + txtcity.Text + "/Upd");
                    //}
                }
                else
                {
                    Obj_City.Insertport4location(txtpincode.Text.Trim(), txtlocation.Text.ToUpper(), Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_stateid.Value));
                    obj_da_Log.InsLogDetail(EmpId, 1695, 1, BranchID, "/CityId: " + hf_portid.Value + "/City" + txtcity.Text + "/Upd");
                }
               
                lstLocation.Items.Clear();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Saved')", true);
                btnSave.Text = "Update";



                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
            }

            txtpincode.Text = "";
            txtcity.Text = "";
            hf_portid.Value = "";
            txtlocation.Text = "";
            hdf_location.Value = "";
            txtstate.Text = "";
            hf_stateid.Value = "";
            btnCancel.Text = "Back";
            btnCancel.ToolTip = "Back";
            btnCancel1.Attributes["class"] = "btn ico-back";
        }

        protected void CheckData()
        {
            DataTable dt_PinCode = new DataTable();

            if (txtpincode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Pincode Can't be Blank')", true);
                txtpincode.Focus();
                blnerr = true;
                return;
            }

            if (btnSave.ToolTip == "Update")
            {
                dt_PinCode = Obj_City.GetPincode4location(txtpincode.Text.Trim());
                if (dt_PinCode.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Kindly, Check the PinCode')", true);
                    txtpincode.Focus();
                    blnerr = true;
                    return;
                }
            }


            if (txtcity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('City Can't be Blank')", true);
                txtcity.Focus();
                blnerr = true;
                return;
            }
            else if (hf_portid.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid City')", true);
                txtcity.Focus();
                blnerr = true;
                return;
            }

            if (txtstate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('State Can't be Blank')", true);
                txtstate.Focus();
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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel2.Visible = true;
         //   DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1695, "MSCityupdate", txtpincode.Text, txtpincode.Text, "");  //"/Rate ID: " +
            if (txtpincode.Text != "")
            {
                JobInput.Text = txtpincode.Text;

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

    }
}