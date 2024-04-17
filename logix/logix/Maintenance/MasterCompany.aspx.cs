using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class MasterCompany : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCompany obj_company = new DataAccess.Masters.MasterCompany();
        DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataAccess.HR.Employee hrEmpObj = new DataAccess.HR.Employee();
        DataAccess.Accounts.Recipts bankobj = new DataAccess.Accounts.Recipts();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        DataTable dt_check = new DataTable();
        DataTable dt_locdet = new DataTable();
        int filesize;
        Boolean blrr;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_company.GetDataBase(Ccode);
                objp_location.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);
                hrEmpObj.GetDataBase(Ccode);
                bankobj.GetDataBase(Ccode);
                da_obj_Logobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);


                



            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_save);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_imgupload);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnblimage);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            btn_delete.Click += btn_delete_Click;
            btn_delete.OnClientClick = @"return getConfirmationValue();";
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    //txtStartFrom.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                    //txtStartTo.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                    Ctrl_List = "txt_name~txt_phone~txt_fax~txt_email~txt_pan~txt_st~txt_tan~txt_pf~txt_esi~txt_carn~txt_decimals~txt_fyfrom~txt_fyto~txt_bank~txt_address~txt_ac~txt_scode~txt_carn~txtifsccode";
                    Msg_List = "Compamy~Phone Number~FaxNumber~EmailID~PanNumber~STNumber~Tan~PF Number~ESI~CARN~Decimals~FyFrom~FyTo~Bank~Bank Address~Account Number~Swift Coder~Ifsccode";
                    Dtype_List = "string~string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    btn_delete.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    Utility.Fn_CheckUserRights(str_Uiid, btn_delete, null, null);
                    // btn_delete.Enabled = false;
                    btn_delete.Visible = false;btn_delete_id.Visible = false;
                    txt_name.Focus();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
            else
            {
                txt_location_TextChanged(sender, e);
                //btn_delete.Enabled = false;
                btn_delete.Visible = false;btn_delete_id.Visible = false;
            }
        }

        [WebMethod]
        public static List<string> GetBank(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Accounts.Recipts bankobj = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            bankobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            dt = bankobj.GetLikeBankName(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt, "bankname", "bankid");
            return List_Result;

        }

        [WebMethod]
        public static List<string> GetCompany(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            masterObj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            dt = masterObj.GetLikeDivision(prefix.ToString().Trim());
            List_Result = Utility.Fn_TableToList(dt, "divisionname", "divisionid");
            return List_Result;

        }

        [WebMethod]
        public static List<string> GetLocation(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_location.GetDataBase(Ccode);
            DataTable dt_Location = new DataTable();
            dt_Location = objp_location.GetLocationname(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16Display(dt_Location, "locport", "locationid", "cityname");
            return List_Result;
        }


        protected void Check_data()
        {
            //if (ddl_df.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Please Select DateFormat');", true);
            //    ddl_df.Focus();
            //    blrr = true;
            //    return;
            //}
            //else if (ddl_actype.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Please Select Account Type');", true);
            //    ddl_actype.Focus();
            //    blrr = true;
            //    return;
            //}
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Check_data();
                if (blrr == true)
                {
                    return;
                }
                //btn_delete.Enabled = false;
                //btn_delete.Visible = false;btn_delete_id.Visible = false;
                btn_cancel.Text = "Clear";

                btn_cancel.ToolTip = "Clear";
                btn_cancel1.Attributes["class"] = "btn ico-clear";

                DateTime dtdate = Convert.ToDateTime(txt_fyfrom.Text);
                string strdate = Utility.fn_ConvertDateWithTime(dtdate.ToString());

                string strdate1 = Utility.fn_ConvertDate(strdate);
                dtdate = Convert.ToDateTime(txt_fyto.Text);
                string strdate2 = Utility.fn_ConvertDateWithTime(dtdate.ToString());
                string strdate3 = Utility.fn_ConvertDate(strdate2);
                string Corpadd = txt_door.Text.ToUpper() + txt_bname.Text.ToUpper() + txt_street.Text.ToUpper() + txt_pincode.Text;
                if (btn_save.ToolTip == "Save")
                {
                    Byte[] imgbyte = null;
                    if (FileUpload1.PostedFile != null)
                    {

                        HttpPostedFile File = FileUpload1.PostedFile;
                        imgbyte = new Byte[File.ContentLength];
                        File.InputStream.Read(imgbyte, 0, File.ContentLength);
                        filesize = FileUpload1.PostedFile.ContentLength / 1024;

                        string base64String = Convert.ToBase64String(imgbyte);
                        hdf_image.Value = base64String;
                        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                        btn_cancel.Text = "Clear";

                        btn_cancel.ToolTip = "Clear";
                        btn_cancel1.Attributes["class"] = "btn ico-clear";

                        // btn_save.Text = "Update";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Upload Logo');", true);
                       btn_cancel.Text = "Clear";

                        btn_cancel.ToolTip = "Clear";
                        btn_cancel1.Attributes["class"] = "btn ico-clear";
                        return;

                    }
                    int divid = Convert.ToInt32(hdf_divisionid.Value);
                    int portid = Convert.ToInt32(hdf_portid.Value);
                    int countryid = Convert.ToInt32(hdf_countryid.Value);
                    int stateid = Convert.ToInt32(hdf_stateid.Value);
                    int locationid = Convert.ToInt32(hdf_locationid.Value);
                    //  txt_paiseshort.Text = "fdsf";
                    if (filesize > 20)
                    {
                        ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Image Size Does not Exist 20kb');", true);
                        FileUpload1.Attributes.Clear();
                        return;
                    }

                    int pisd = Convert.ToInt32(txt_pisd.Text);
                    int deci = Convert.ToInt32(txt_decimals.Text);
                    int int_bank = Convert.ToInt32(hdf_bankid.Value.ToString());

                    //masterObj.InsertMasterDivision(txt_name.Text, txt_phone.Text, txt_fax.Text, txt_pan.Text, txt_st.Text, Corpadd, Convert.ToInt32(txtPort.Text), txt_tan.Text,
                    //  Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_fyfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_fyto.Text)), imgbyte, int_bank, txt_address.Text, txt_scode.Text, txt_carn.Text,
                    //  txt_ac.Text, txt_door.Text, txt_street.Text, txt_bname.Text, locationid, txt_pincode.Text, stateid, countryid, pisd, txt_pstd.Text, pisd,
                    //  txt_pstd.Text, txt_currshort.Text, txt_paiseshort.Text, Convert.ToInt32(txt_decimals.Text), Convert.ToString(ddl_df.SelectedValue), txt_unit.Text, txt_pf.Text, txt_esi.Text, txt_email.Text);


                    masterObj.InsertMasterDivision(txt_name.Text.ToUpper().Trim(), txt_phone.Text, txt_fax.Text, txt_pan.Text, Corpadd, portid, txt_tan.Text.ToUpper(),
                    Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_fyfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_fyto.Text)),
                    imgbyte, txt_st.Text, int_bank, txt_scode.Text.ToUpper(), txt_ac.Text, txt_carn.Text.ToUpper(), txt_address.Text.ToUpper(), txt_door.Text.ToUpper(), txt_bname.Text.ToUpper(),
                    txt_street.Text.ToUpper(), locationid, txt_pincode.Text, stateid, countryid, pisd, txt_pstd.Text.ToUpper(), pisd, txt_pstd.Text.ToUpper(), txt_currshort.Text.ToUpper(), txt_paiseshort.Text.ToUpper(),
                    Convert.ToInt32(txt_decimals.Text), Convert.ToString(ddl_df.SelectedValue), txt_unit.Text.ToUpper(), txt_pf.Text.ToUpper(), txt_esi.Text.ToUpper(), txt_email.Text.ToLower(), txtifsccode.Text.ToUpper(), ddl_actype.Text.ToUpper());

                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Inserted successfully');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 327, 1, int.Parse(Session["LoginBranchid"].ToString()), "save");
                     btn_save.Text = "Update";

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";
                }
                else
                {
                    if (hdf_divisionid.Value != "")
                    {

                        //hdf_bankid.Value = dt.Rows[0]["bankid"].ToString();
                        //hdf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
                        //hdf_divisionid.Value = dt.Rows[0]["divisionid"].ToString();
                        //hdf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                        //hdf_portid.Value = dt.Rows[0]["portid"].ToString();
                        //hdf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                        //int divid = Convert.ToInt32(hdf_divisionid.Value);
                        //int portid = Convert.ToInt32(hdf_portid.Value);
                        //int countryid = Convert.ToInt32(hdf_countryid.Value);
                        //int stateid = Convert.ToInt32(hdf_stateid.Value);
                        //int locationid = Convert.ToInt32(hdf_locationid.Value);


                        Byte[] imgbyte = null;
                        if (FileUpload1.HasFile && FileUpload1.PostedFile != null)
                        {
                            HttpPostedFile File = FileUpload1.PostedFile;
                            imgbyte = new Byte[File.ContentLength];
                            File.InputStream.Read(imgbyte, 0, File.ContentLength);
                            filesize = FileUpload1.PostedFile.ContentLength / 1024;


                            string base64String = Convert.ToBase64String(imgbyte);
                            hdf_image.Value = base64String;
                            Img_Emp.ImageUrl = "data:image/png;base64," + base64String;

                            btn_save.Text = "Update";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn ico-update";


                        }
                        else
                        {
                            // dt = obj_company.GetCompanyDetails(Convert.ToInt32(hdf_divisionid.Value));
                            dt = masterObj.GetMasterDivisionDetails(Convert.ToInt32(hdf_divisionid.Value));
                            if (dt.Rows.Count > 0)
                            {
                                byte[] imageByte = ((byte[])dt.Rows[0]["dlogo"]);
                                string base64String = Convert.ToBase64String(imageByte);
                                hdf_image.Value = base64String;
                                Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                            }
                        }
                        //int int_division = Convert.ToInt32(hdf_divisionid.Value.ToString());
                        //int int_portid = Convert.ToInt32(hdf_portid.Value.ToString());
                        //int int_location = Convert.ToInt32(hdf_locationid.Value.ToString());
                        //int int_state = Convert.ToInt32(hdf_stateid.Value.ToString());
                        //int int_country = Convert.ToInt32(hdf_countryid.Value.ToString());
                        //int int_bank = Convert.ToInt32(hdf_bankid.Value.ToString());
                        //int int_decimal = Convert.ToInt32(txt_decimals.Text);
                        //int pisd = Convert.ToInt32(txt_pisd.Text);
                        //int pstd = Convert.ToInt32(txt_pstd.Text);
                        int int_division = Convert.ToInt32(hdf_divisionid.Value.ToString());
                        int divid = Convert.ToInt32(hdf_divisionid.Value);
                        int portid = Convert.ToInt32(hdf_portid.Value);
                        int countryid = Convert.ToInt32(hdf_countryid.Value);
                        int stateid = Convert.ToInt32(hdf_stateid.Value);
                        int locationid = Convert.ToInt32(hdf_locationid.Value);
                        int pisd = Convert.ToInt32(txt_pisd.Text);
                        int deci = Convert.ToInt32(txt_decimals.Text);
                        int int_bank = Convert.ToInt32(hdf_bankid.Value.ToString());

                        Byte[] imgbyte1 = Convert.FromBase64String(hdf_image.Value);
                        if (FileUpload1.FileName == string.Empty)
                        {
                            masterObj.UpdateMasterDivision(int_division, txt_name.Text.ToUpper().Trim(), txt_phone.Text, txt_fax.Text, txt_pan.Text, Corpadd, portid, txt_tan.Text.ToUpper(),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_fyfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_fyto.Text)),
                       imgbyte1, txt_st.Text, int_bank, txt_scode.Text.ToUpper(), txt_ac.Text, txt_carn.Text.ToUpper(), txt_address.Text.ToUpper(), txt_door.Text.ToUpper(), txt_bname.Text.ToUpper(),
                       txt_street.Text.ToUpper(), locationid, txt_pincode.Text, stateid, countryid, pisd, txt_pstd.Text.ToUpper(), pisd, txt_pstd.Text.ToUpper(), txt_currshort.Text.ToUpper(), txt_paiseshort.Text.ToUpper(),
                       Convert.ToInt32(txt_decimals.Text), Convert.ToString(ddl_df.SelectedValue), txt_unit.Text.ToUpper(), txt_pf.Text.ToUpper(), txt_esi.Text.ToUpper(), txt_email.Text.ToLower(), txtifsccode.Text.ToUpper(), ddl_actype.Text.ToUpper());
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('updated');", true);
                        }
                        else
                        {
                            masterObj.UpdateMasterDivision(int_division, txt_name.Text.ToUpper().Trim(), txt_phone.Text, txt_fax.Text, txt_pan.Text, Corpadd, portid, txt_tan.Text.ToUpper(),
                       Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_fyfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_fyto.Text)),
                       imgbyte, txt_st.Text, int_bank, txt_scode.Text.ToUpper(), txt_ac.Text, txt_carn.Text.ToUpper(), txt_address.Text.ToUpper(), txt_door.Text.ToUpper(), txt_bname.Text.ToUpper(),
                       txt_street.Text.ToUpper(), locationid, txt_pincode.Text, stateid, countryid, pisd, txt_pstd.Text.ToUpper(), pisd, txt_pstd.Text.ToUpper(), txt_currshort.Text.ToUpper(), txt_paiseshort.Text.ToUpper(),
                       Convert.ToInt32(txt_decimals.Text), Convert.ToString(ddl_df.SelectedValue), txt_unit.Text.ToUpper(), txt_pf.Text.ToUpper(), txt_esi.Text.ToUpper(), txt_email.Text.ToLower(), txtifsccode.Text.ToUpper(), ddl_actype.Text.ToUpper());
                       ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('updated');", true);
                       logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 327, 2, int.Parse(Session["LoginBranchid"].ToString()), "Update");

                        }


                    }
                }
                clear();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public void clear()
        {
            txt_ac.Text = "";
            txt_address.Text = "";
            txt_bank.Text = "";
            txt_bname.Text = "";
            txt_carn.Text = "";
            txt_country.Text = "";
            txt_currshort.Text = "";
            txt_decimals.Text = "";
            txt_door.Text = "";
            txt_email.Text = "";
            txt_esi.Text = "";
            txt_fax.Text = "";
            //txt_fisd.Text = "";
            //txt_fstd.Text = "";
            txt_fyfrom.Text = "";
            txt_fyto.Text = "";
            txt_location.Text = "";
            txt_name.Text = "";
            txt_paiseshort.Text = "";
            txt_pan.Text = "";
            txt_pf.Text = "";
            txt_phone.Text = "";
            txt_pincode.Text = "";
            txt_pisd.Text = "";
            txt_pstd.Text = "";
            txt_scode.Text = "";
            txt_st.Text = "";
            txt_state.Text = "";
            txt_street.Text = "";
            txt_tan.Text = "";
            txt_unit.Text = "";
            txtPort.Text = "";
            Img_Emp.ImageUrl = "";
            hdf_divisionid.Value = "";
            hdf_bankid.Value = "";
            // btn_save.Text = "Save";
            txtdistrict.Text = "";
            ddl_df.SelectedIndex = -1;
            ddl_actype.SelectedIndex = 0;
            txtifsccode.Text = "";
            txtdistrict.Text = "";

        }

        protected void txt_name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //btn_delete.Enabled = false;

                DataTable dt = new DataTable();
                hdf_divisionid.Value = hrEmpObj.GetDivisionId(txt_name.Text.Trim().ToUpper()).ToString();
                if (hdf_divisionid.Value != "")
                {

                    dt = masterObj.GetMasterDivisionDetails(Convert.ToInt32(hdf_divisionid.Value));
                    if (dt.Rows.Count > 0)
                    {
                        txt_ac.Text = dt.Rows[0]["acno"].ToString();
                        txt_address.Text = dt.Rows[0]["bankaddress"].ToString();
                        if (dt.Rows[0]["bank"].ToString() == "")
                        {
                            txt_bank.Text = "";
                        }
                        else
                        {
                            txt_bank.Text = bankobj.GetBankName(Convert.ToInt32(dt.Rows[0]["bank"].ToString()));
                        }

                        hdf_bankid.Value = dt.Rows[0]["bank"].ToString();
                       // txt_bname.Text = dt.Rows[0]["bname"].ToString();
                        //txt_location.Text = portobj.GetPortname(Convert.ToInt32(dt.Rows[0]["locationid"].ToString()));
                      //  hdf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                        get_method();

                        //txtPort.Text = dt.Rows[0]["portname"].ToString();
                        //hdf_portid.Value = dt.Rows[0]["portid"].ToString();
                        //txt_state.Text = dt.Rows[0]["statename"].ToString();
                        //hdf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                        //txt_country.Text = dt.Rows[0]["countryname"].ToString();
                        //hdf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
                        //txt_location.Text = dt.Rows[0]["location"].ToString();
                        //hdf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                        //txt_currshort.Text = dt.Rows[0]["Currency"].ToString();
                        //txt_pincode.Text = dt.Rows[0]["pincode"].ToString();
                        //txt_paiseshort.Text = dt.Rows[0]["Cents"].ToString();
                        //txt_pisd.Text = dt.Rows[0]["ISDcode"].ToString();
                        //txt_pstd.Text = dt.Rows[0]["stdcode"].ToString();
                        //txtdistrict.Text = dt.Rows[0]["districtname"].ToString();
                        //get_method();
                        txt_carn.Text = dt.Rows[0]["carrno"].ToString();
                        //txt_country.Text = dt.Rows[0]["CountryName"].ToString();
                      //  txt_currshort.Text = dt.Rows[0]["curr"].ToString();
                        txt_decimals.Text = dt.Rows[0]["curdecplace"].ToString();
                      //  txt_door.Text = dt.Rows[0]["door"].ToString();
                        txt_email.Text = dt.Rows[0]["email"].ToString();
                        txt_esi.Text = dt.Rows[0]["esino"].ToString();
                        //txt_fax.Text = dt.Rows[0]["fax"].ToString();                       
                        //txtdistrict.Text = dt.Rows[0]["districtname"].ToString();
                        txt_fyfrom.Text = dt.Rows[0]["fyfrom"].ToString();
                        txt_fyto.Text = dt.Rows[0]["fyto"].ToString();
                        //txt_location.Text = dt.Rows[0]["location"].ToString();
                        txt_name.Text = dt.Rows[0]["divisionname"].ToString();
                     //   txt_paiseshort.Text = dt.Rows[0]["paise"].ToString();
                        txt_pan.Text = dt.Rows[0]["panno"].ToString();
                        txt_pf.Text = dt.Rows[0]["pfno"].ToString();
                        txt_phone.Text = dt.Rows[0]["phone"].ToString();
                        //txt_pincode.Text = dt.Rows[0]["pincode"].ToString();
                        // txt_pisd.Text = dt.Rows[0]["ISDcode"].ToString();
                        //txt_pstd.Text = dt.Rows[0]["stdcode"].ToString();
                        txt_scode.Text = dt.Rows[0]["swiftcode"].ToString();
                        txt_st.Text = dt.Rows[0]["stno"].ToString();
                        //txt_state.Text = dt.Rows[0]["statename"].ToString();
                     //   txt_street.Text = dt.Rows[0]["street"].ToString();
                        txt_tan.Text = dt.Rows[0]["tanno"].ToString();
                      //  txt_unit.Text = dt.Rows[0]["unit"].ToString();
                        //txtPort.Text = dt.Rows[0]["portname"].ToString();
                       // ddl_df.Text = dt.Rows[0]["dateformat"].ToString();
                        txt_email.Text = dt.Rows[0]["email"].ToString();
                        txt_fax.Text = dt.Rows[0]["fax"].ToString();
                        //hdf_bankid.Value = dt.Rows[0]["bankid"].ToString();
                        //hdf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
                        //hdf_divisionid.Value = dt.Rows[0]["divisionid"].ToString();
                        //hdf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                        //hdf_portid.Value = dt.Rows[0]["portid"].ToString();
                        //hdf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                        //txtifsccode.Text = dt.Rows[0]["ifscode"].ToString();
                      //  ddl_actype.Text = dt.Rows[0]["accounttype"].ToString();
                        if (dt.Rows[0]["dlogo"].ToString() != "")
                        {
                            byte[] imageByte = ((byte[])dt.Rows[0]["dlogo"]);
                            string base64String = Convert.ToBase64String(imageByte);
                            hdf_image.Value = base64String;
                            Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";

                    }
                }
                else
                {
                    btn_save.Text = "Save";

                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }
            }
           catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_name.Focus();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            // btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (btn_cancel.ToolTip == "Clear")
            {

                clear();
                 btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_name.Focus();
            }
            else if (btn_cancel.ToolTip == "Back")
            {
                clear();
                this.Response.End();
            }
        }

        protected void get_method()
        {
            if (hdf_locationid.Value == "")
            {
                txt_location.Text = "";
            }
            else
            {
                txt_location.Text = objp_location.GetLocationnew(Convert.ToInt32(hdf_locationid.Value));
            }

            dt_check = objp_location.CheckDuplicateForLocation(txt_location.Text.ToUpper());
            if (dt_check.Rows.Count > 0 && hdf_locationid.Value == "")
            {
                hdf_locationid.Value = dt_check.Rows[0]["locationid"].ToString();
            }

            if (hdf_locationid.Value != "")
            {
                int locationid = Convert.ToInt32(hdf_locationid.Value.ToString());
                dt_locdet = obj_company.SelectLocation4company(locationid);
                if (dt_locdet.Rows.Count > 0)
                {
                    txtPort.Text = dt_locdet.Rows[0]["portname"].ToString();
                    hdf_portid.Value = dt_locdet.Rows[0]["portid"].ToString();
                    txt_state.Text = dt_locdet.Rows[0]["statename"].ToString();
                    hdf_stateid.Value = dt_locdet.Rows[0]["stateid"].ToString();
                    txt_country.Text = dt_locdet.Rows[0]["countryname"].ToString();
                    hdf_countryid.Value = dt_locdet.Rows[0]["Countryid"].ToString();
                    txt_location.Text = dt_locdet.Rows[0]["location"].ToString();
                    hdf_locationid.Value = dt_locdet.Rows[0]["locationid"].ToString();
                    txt_currshort.Text = dt_locdet.Rows[0]["Currency"].ToString();
                    txt_pincode.Text = dt_locdet.Rows[0]["pincode"].ToString();
                    txt_paiseshort.Text = dt_locdet.Rows[0]["Cents"].ToString();
                    txt_pisd.Text = dt_locdet.Rows[0]["ISDcode"].ToString();
                    txt_pstd.Text = dt_locdet.Rows[0]["stdcode"].ToString();
                    txtdistrict.Text = dt_locdet.Rows[0]["districtname"].ToString();


                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Valid Location');", true);
                    txt_location.Text = "";
                }
            }
        }

        protected void txt_location_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Bhuvana

                // btn_delete.Enabled = false;
                btn_delete.Visible = false;btn_delete_id.Visible = false;
                dt_check = objp_location.CheckDuplicateForLocation(txt_location.Text.ToUpper());
                if (dt_check.Rows.Count > 0 && hdf_locationid.Value == "")
                {
                    hdf_locationid.Value = dt_check.Rows[0]["locationid"].ToString();
                }

                if (hdf_locationid.Value != "")
                {
                    int locationid = Convert.ToInt32(hdf_locationid.Value.ToString());
                    dt_locdet = obj_company.SelectLocation4company(locationid);
                    if (dt_locdet.Rows.Count > 0)
                    {
                        txtPort.Text = dt_locdet.Rows[0]["portname"].ToString();
                        hdf_portid.Value = dt_locdet.Rows[0]["portid"].ToString();
                        txt_state.Text = dt_locdet.Rows[0]["statename"].ToString();
                        hdf_stateid.Value = dt_locdet.Rows[0]["stateid"].ToString();
                        txt_country.Text = dt_locdet.Rows[0]["countryname"].ToString();
                        hdf_countryid.Value = dt_locdet.Rows[0]["Countryid"].ToString();
                        txt_location.Text = dt_locdet.Rows[0]["location"].ToString();
                        hdf_locationid.Value = dt_locdet.Rows[0]["locationid"].ToString();
                        txt_currshort.Text = dt_locdet.Rows[0]["Currency"].ToString();
                        txt_pincode.Text = dt_locdet.Rows[0]["pincode"].ToString();
                        txt_paiseshort.Text = dt_locdet.Rows[0]["Cents"].ToString();
                        txt_pisd.Text = dt_locdet.Rows[0]["ISDcode"].ToString();
                        txt_pstd.Text = dt_locdet.Rows[0]["stdcode"].ToString();
                        txtdistrict.Text = dt_locdet.Rows[0]["districtname"].ToString();


                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Valid Location');", true);
                        txt_location.Text = "";
                    }

                }

                //Bhuvana
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_phone.Focus();

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (hfWasConfirmed.Value == "true")
                {

                    if (hdf_divisionid.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_delete, typeof(Button), "DataFound", "alertify.alert('Data Not found');", true);
                    }
                    else
                    {
                        int int_division = Convert.ToInt32(hdf_divisionid.Value.ToString());
                        obj_company.CompanyDelete(int_division);
                        ScriptManager.RegisterStartupScript(btn_delete, typeof(Button), "DataFound", "alertify.alert('Deleted');", true);
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 327, 4, int.Parse(Session["LoginBranchid"].ToString()), "Delete");
                    }
                }
                clear();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_bank_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt = obj_company.GetBankDetails(txt_bank.Text.ToUpper());
                if (dt.Rows.Count > 0)
                {
                    hdf_bankid.Value = dt.Rows[0]["bankid"].ToString();
                    txt_bank.Text = dt.Rows[0]["bankname"].ToString();
                    txtifsccode.Text = dt.Rows[0]["ifsc"].ToString();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Valid Bank');", true);
                    txt_bank.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_country_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_pisd_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_ac_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.HR.Employee hrEmpObj = new DataAccess.HR.Employee();
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                //str_sf = "{MasterDivision.divisionid}=" + hrEmpObj.GetDivisionId(txt_name.Text) + "";
                //str_sp = "CompanyName=" + Session["LoginDivisionName"].ToString();
                //str_RptName = "MasterDivision.rpt";
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "MasterCompany", str_Script, true);
                //Session["str_sfs"] = str_sf;
                //Session["str_sp"] = str_sp;
                //logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 327, 3, int.Parse(Session["LoginBranchid"].ToString()), "view");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lbl_lnkrate_Click(object sender, EventArgs e)
        {
            Response.Redirect("MasterBranch.aspx");
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
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 327, "MSdivision", txt_name.Text, txt_name.Text, "");  //"/Rate ID: " +
            if (txt_name.Text != "")
            {
                JobInput.Text = txt_name.Text;


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



        protected void btn_imgupload_Click(object sender, EventArgs e)
        {
            if (hdf_divisionid.Value != "")
            {


                Byte[] imgbyte = null;
                if (FileUpload1.PostedFile != null)
                {

                    HttpPostedFile File = FileUpload1.PostedFile;
                    imgbyte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgbyte, 0, File.ContentLength);
                    filesize = FileUpload1.PostedFile.ContentLength / 1024;

                    string base64String = Convert.ToBase64String(imgbyte);
                    hdf_image.Value = base64String;
                    Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                     btn_cancel.Text = "Clear";

                    btn_cancel.ToolTip = "Clear";
                    btn_cancel1.Attributes["class"] = "btn ico-clear";

                    // btn_save.Text = "Update";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Kindly select Image path');", true);
                     btn_cancel.Text = "Clear";

                    btn_cancel.ToolTip = "Clear";
                    btn_cancel1.Attributes["class"] = "btn ico-clear";
                    return;

                }
                if (filesize > 20)
                {
                    ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Image Size Does not Exist 20kb');", true);
                    FileUpload1.Attributes.Clear();
                    return;
                }

                masterObj.Logoimguploadindiv(Convert.ToInt32(hdf_divisionid.Value), imgbyte);
                ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('LOGO updated');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Kindly select Company Name');", true);
                return;
            }

        }

        protected void btnblimage_Click(object sender, EventArgs e)
        {
            if (hdf_divisionid.Value != "")
            {


                Byte[] imgbyte = null;
                if (FileUpload2.PostedFile != null)
                {

                    HttpPostedFile File = FileUpload2.PostedFile;
                    imgbyte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgbyte, 0, File.ContentLength);
                    filesize = FileUpload2.PostedFile.ContentLength / 1024;

                    string base64String = Convert.ToBase64String(imgbyte);
                    hdf_image.Value = base64String;
                    Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    btn_cancel.Text = "Clear";

                    btn_cancel.ToolTip = "Clear";
                    btn_cancel1.Attributes["class"] = "btn ico-clear";

                    // btn_save.Text = "Update";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Kindly select Image path');", true);
                    btn_cancel.Text = "Clear";

                    btn_cancel.ToolTip = "Clear";
                    btn_cancel1.Attributes["class"] = "btn ico-clear";
                    return;

                }
                //if (filesize > 20)
                //{
                //    ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Image Size Does not Exist 20kb');", true);
                //    FileUpload1.Attributes.Clear();
                //    return;
                //}

                masterObj.BLimguploadindiv(Convert.ToInt32(hdf_divisionid.Value), imgbyte);
                ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Image updated');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Img_Emp, typeof(Button), "DataFound", "alertify.alert('Kindly select Company Name');", true);
                return;
            }

        }
    }
}