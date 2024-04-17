
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.Services.Description;
namespace logix.Maintenance

{
    public partial class Masterlocation1 : System.Web.UI.Page
    {
        ////DataAccess.Masters.MasterUser ObjMUser = new DataAccess.Masters.MasterUser();
        DataAccess.Masters.MasterLocation mainobj = new DataAccess.Masters.MasterLocation();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        Boolean blerr;
        string ddvalue; string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                mainobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
             
            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('https://demo.copperhawk.tech/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            //GetLocationDetails4Grid();

            if (!IsPostBack)
            {
                try
                {
                    GetLocationDetails4Grid();                  
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
        }

        [WebMethod]
        public static List<string> GetLikeLocation(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterLocation mainobj = new DataAccess.Masters.MasterLocation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            mainobj.GetDataBase(Ccode);
            dt = mainobj.GetLocName(prefix);
            list_result = Utility.Fn_TableToList(dt, "LocName", "ID");         
            return list_result;
        }
        [WebMethod]
        public static List<string> GetLikeDistrict(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt1 = new DataTable();
            DataAccess.Masters.MasterLocation mainobj = new DataAccess.Masters.MasterLocation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            mainobj.GetDataBase(Ccode);
            dt1 = mainobj.GetDisrictName(prefix);
            list_result = Utility.Fn_TableToList(dt1, "DisName", "ID");
            return list_result;
        }
          [WebMethod]
        public static List<string> GetLikeState(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt2 = new DataTable();
            DataAccess.Masters.MasterLocation mainobj = new DataAccess.Masters.MasterLocation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            mainobj.GetDataBase(Ccode);
            dt2 = mainobj.GetStateName(prefix);
            list_result = Utility.Fn_TableToList(dt2, "StateName", "ID");
            return list_result;
        }
          [WebMethod]
        public static List<string> GetCountryName(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt3 = new DataTable();
            DataAccess.Masters.MasterLocation mainobj = new DataAccess.Masters.MasterLocation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            mainobj.GetDataBase(Ccode);
            dt3 = mainobj.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt3, "CountryName", "ID");
            return list_result;
        }
          [WebMethod]
          public static List<string> GetPortName(string prefix)
          {
              List<string> list_result = new List<string>();
              DataTable dt3 = new DataTable();
              DataAccess.Masters.MasterLocation mainobj = new DataAccess.Masters.MasterLocation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            mainobj.GetDataBase(Ccode);
            dt3 = mainobj.GetPortName(prefix);
              list_result = Utility.Fn_TableToList(dt3, "PortName", "ID");
              return list_result;
          }
          [WebMethod]
          public static List<string> GetPincode(string prefix)
          {
              List<string> List_Result = new List<string>();
              DataTable dt_ok = new DataTable();
              DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_location.GetDataBase(Ccode);
            dt_ok = objp_location.GetlocationnameNEWpincode(prefix.ToUpper());
              List_Result = Utility.Fn_DatatableToList_Text(dt_ok, "pinCode");
              return List_Result;
          }
        public void Validaion()
        {
            if (txtlocname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Location Should Not Be Empty');", true);
                txtlocname.Focus();
                blerr = true;
                return;
            }
            else if (txt_districtname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('District Should Not Be Empty');", true);
                txt_districtname.Focus();
                blerr = true;
                return;
            }
             else if (txtcountryname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Country Should Not Be Empty');", true);
                txtcountryname.Focus();
                blerr = true;
                return;

            }
            else if (txtstatename.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('State Should Not Be Empty');", true);
                txtstatename.Focus();
                blerr = true;
                return;

            }
            else if (txtpincode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Pincode Should Not Be Empty');", true);
                txtpincode.Focus();
                blerr = true;
                return;

            }
            else if (txtcircle.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Circle Should Not Be Empty');", true);
                txtcircle.Focus();
                blerr = true;
                return;

            }
            else if (txtcityport.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('City Port Should Not Be Empty');", true);
                txtcityport.Focus();
                blerr = true;
                return;

            }
            else if (txtpotype.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Port Type Should Not Be Empty');", true);
                txtpotype.Focus();
                blerr = true;
                return;

            }
            
            
        }
        protected void checklocnamepincode()
            {
                 DataTable dt;
                dt = mainobj.chklocnamepincode(txtlocname.Text,txtpincode.Text);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Location Name and Pincode already exist');", true);
                    blerr = true;
                    return;
                }
               
            }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Validaion();
            if (blerr == true)
            {
                blerr = false;
                return;
            }
            
                if (Btn_save.ToolTip == "Save")
                {
                    checklocnamepincode();
                    mainobj.InsertLocationDtls(txtlocname.Text, Convert.ToInt32(hid_pid.Value), Convert.ToInt32(hid_stid.Value), Convert.ToInt32(hid_disid.Value), Convert.ToInt32(hid_cid.Value),txtpincode.Text,txtcircle.Text,txtpotype.Text);
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1993, 1, int.Parse(Session["LoginBranchid"].ToString()), "Ins Loc#-" + txtlocname.Text + "/" + Convert.ToInt32(hid_pid.Value) + "/" + Convert.ToInt32(hid_stid.Value) + "/" + Convert.ToInt32(hid_disid.Value) + "/" + Convert.ToInt32(hid_cid.Value) + "/" + txtpincode.Text + "/" + txtcircle.Text + "/" + txtpotype.Text);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Master Location Details Saved Successfully');", true);
                    
                }
                else if (Btn_save.ToolTip == "Update")
                {
                    mainobj.UpdateLocationDtls(txtlocname.Text, Convert.ToInt32(hid_pid.Value), Convert.ToInt32(hid_stid.Value), Convert.ToInt32(hid_disid.Value), Convert.ToInt32(hid_cid.Value), txtpincode.Text, txtcircle.Text, txtpotype.Text, Convert.ToInt32(hid_locid.Value));
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1993, 2, int.Parse(Session["LoginBranchid"].ToString()), "Upd Loc#-" + txtlocname.Text + "/" + Convert.ToInt32(hid_pid.Value) + "/" + Convert.ToInt32(hid_stid.Value) + "/" + Convert.ToInt32(hid_disid.Value) + "/" + Convert.ToInt32(hid_cid.Value) + "/" + txtpincode.Text + "/" + txtcircle.Text + "/" + txtpotype.Text + "/" + Convert.ToInt32(hid_locid.Value));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Master Location Details Updated Successfully');", true);
                    
                }


                GetLocationDetails4Grid();
            Clear();

        }

        public void GetLocationDetails4Grid()
        {
            DataTable Dt = mainobj.GetLocationDtls4Grid();
            if (Dt.Rows.Count > 0)
            {
                GrdLocDtls.DataSource = Dt;
                GrdLocDtls.DataBind();
            }
        }
        protected void GrdLocDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdLocDtls.PageIndex = e.NewPageIndex;
            GetLocationDetails4Grid();
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnBack.ToolTip == "Back")
                {
                    Clear();
                    this.Response.End();
                }
                else
                {
                    Clear();
                    btnBack.ToolTip = "Back";
                    btnBack1.Attributes["class"] = "btn ico-back";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void Clear()
        {
            txtlocname.Text = "";
            txtcircle.Text = "";
            txt_districtname.Text = "";
            txtcityport.Text = "";
            txtcountryname.Text = "";
            txtstatename.Text = "";
            txtpotype.Text = "";
            txtpincode.Text = "";
            txt_gstcode.Text = "";
            hid_locid.Value = "";
            hid_cid.Value = "";
            hid_disid.Value = "";
            hid_pid.Value = "";
            hid_stid.Value = "";
            hdf_pinlocation.Value = "";
            divgst.Visible = false;
            Btn_save.Text = "Save";
            Btn_save.ToolTip = "Save";
            div_save.Attributes["class"] = "btn ico-save";
           
        }
        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            if (Btn_cancel.ToolTip == "Cancel")
            {
                txtlocname.Text = "";
                txtcircle.Text = "";
                txt_districtname.Text = "";
                txtcityport.Text = "";
                txtcountryname.Text = "";
                txtstatename.Text = "";
                txtpotype.Text = "";
                txtpincode.Text = "";
                txt_gstcode.Text = "";
                hid_locid.Value = "";
                hid_cid.Value = "";
                hid_disid.Value = "";
                hid_pid.Value = "";
                hid_stid.Value = "";
                hdf_pinlocation.Value = "";
                divgst.Visible = false;
                txtlocname.Focus();
                Btn_save.Text = "Save";
                Btn_save.ToolTip = "Save";
                div_save.Attributes["class"] = "btn ico-save";
                Btn_cancel.Text = "Back";
                Btn_cancel.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }
        protected void GrdLocDtls_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GrdLocDtls.SelectedRow.RowIndex;

                hid_locid.Value = GrdLocDtls.Rows[index].Cells[0].Text;
                txtlocname.Text = GrdLocDtls.Rows[index].Cells[1].Text;
                txtcityport.Text = GrdLocDtls.Rows[index].Cells[2].Text;
                txt_districtname.Text = GrdLocDtls.Rows[index].Cells[3].Text;
                txtstatename.Text = GrdLocDtls.Rows[index].Cells[4].Text;
                txtcountryname.Text = GrdLocDtls.Rows[index].Cells[5].Text;
                txtcircle.Text = GrdLocDtls.Rows[index].Cells[6].Text;
                txtpotype.Text = GrdLocDtls.Rows[index].Cells[7].Text;
                txtpincode.Text = GrdLocDtls.Rows[index].Cells[8].Text;
                txt_gstcode.Text = GrdLocDtls.Rows[index].Cells[9].Text;
                if (txt_gstcode.Text != "")
                {
                    divgst.Visible = true;

                }
                Btn_save.Text = "Update";
                Btn_save.ToolTip = "Update";
                div_save.Attributes["class"] = "btn ico-update";
                Btn_cancel.Text = "Cancel";
                Btn_cancel.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                GetLocationDetails4Grid();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void GrdLocDtls_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdLocDtls, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void txtloc_TextChanged(object sender, EventArgs e)
        {

            //string descn = mainobj.GetIncoDescn(Convert.ToInt32(hid_locid.Value));
            //if ((Convert.ToInt32(hid_locid.Value)) == 0)
            //    {
            //        txtcircle.Text = "";
            //        txtcircle.Focus();
            //        Btn_save.ToolTip = "Save";
            //        Btn_save.Attributes["class"] = "btn-save";
            //    }
            //    else
            //    {
            //        txtcircle.Text = descn.ToString();
            //        Btn_save.ToolTip = "Update";
            //        div_save.Attributes["class"] = "btn btn-update";
            //    }
            if (hid_locid.Value != "0")
            {
                DataTable dt;
                int locationid = Convert.ToInt32(hid_locid.Value.ToString());
                dt = mainobj.SelLocationDtls(locationid);
                if (dt.Rows.Count > 0)
                {
                    txt_districtname.Text = dt.Rows[0]["districtname"].ToString();
                    txtstatename.Text = dt.Rows[0]["statename"].ToString();
                    txtcountryname.Text = dt.Rows[0]["countryname"].ToString();                  
                    txtpincode.Text = dt.Rows[0]["pincode"].ToString();
                    txtcityport.Text = dt.Rows[0]["portname"].ToString();
                    txtcircle.Text = dt.Rows[0]["circle"].ToString();
                    txtpotype.Text = dt.Rows[0]["potype"].ToString();
                    txt_gstcode.Text = dt.Rows[0]["gstcode"].ToString();
                    hid_disid.Value = dt.Rows[0]["districtid"].ToString();
                    hid_cid.Value = dt.Rows[0]["countryid"].ToString();
                    hid_pid.Value=dt.Rows[0]["cityport"].ToString();
                    hid_stid.Value = dt.Rows[0]["stateid"].ToString();
                }
                if (txt_gstcode.Text!="")
                {
                    divgst.Visible = true;

                }
                Btn_save.Text="Update";
                Btn_save.ToolTip = "Update";
                div_save.Attributes["class"] = "btn ico-update";
                Btn_cancel.Text = "Cancel";
                Btn_cancel.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                Btn_save.ToolTip = "Save";
                Btn_save.Attributes["class"] = "btn ico-save";
            }
            
        }


        protected void txtcountryname_TextChanged(object sender, EventArgs e)
        {

            //string descn = mainobj.GetIncoDescn(Convert.ToInt32(hid_locid.Value));
            //if ((Convert.ToInt32(hid_locid.Value)) == 0)
            //    {
            //        txtcircle.Text = "";
            //        txtcircle.Focus();
            //        Btn_save.ToolTip = "Save";
            //        Btn_save.Attributes["class"] = "btn-save";
            //    }
            //    else
            //    {
            //        txtcircle.Text = descn.ToString();
            //        Btn_save.ToolTip = "Update";
            //        div_save.Attributes["class"] = "btn btn-update";
            //    }




        }

        protected void txtstatename_TextChanged(object sender, EventArgs e)
        {
            if (hid_stid.Value != "")
            {
                DataTable dt;
                int stid = Convert.ToInt32(hid_stid.Value.ToString());
                dt = mainobj.StateGstcode(stid);
                if (dt.Rows.Count > 0)
                {
                    txt_gstcode.Text = dt.Rows[0]["gstcode"].ToString();
                }


            }
        }
        protected void txt_districtname_TextChanged(object sender, EventArgs e)
        {

            //string descn = mainobj.GetIncoDescn(Convert.ToInt32(hid_locid.Value));
            //if ((Convert.ToInt32(hid_locid.Value)) == 0)
            //    {
            //        txtcircle.Text = "";
            //        txtcircle.Focus();
            //        Btn_save.ToolTip = "Save";
            //        Btn_save.Attributes["class"] = "btn-save";
            //    }
            //    else
            //    {
            //        txtcircle.Text = descn.ToString();
            //        Btn_save.ToolTip = "Update";
            //        div_save.Attributes["class"] = "btn btn-update";
            //    }




        }

        protected void txtcityport_TextChanged(object sender, EventArgs e)
        {
            if (hid_pid.Value != "")
            {
                DataTable dt;
                int cityid = Convert.ToInt32(hid_pid.Value.ToString());
                dt = mainobj.SelCityDetailsnew(cityid);
                if (dt.Rows.Count > 0)
                {
                    txt_districtname.Text = dt.Rows[0]["districtname"].ToString();
                    txtstatename.Text = dt.Rows[0]["statename"].ToString();
                    txtcountryname.Text = dt.Rows[0]["countryname"].ToString();
                    hid_disid.Value = dt.Rows[0]["districtid"].ToString();
                    hid_stid.Value = dt.Rows[0]["stateid"].ToString();
                    hid_cid.Value = dt.Rows[0]["countryid"].ToString();
                    


                }
            }
        }
        


    }
}