using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Maintenance
{
    public partial class MasterCustomer4KYC : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        int id, add, iec, k=1;
        string idfilename, addfilename, iecfilename, idfilepath, ieccode, addfilepath, a, b, c, d;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {            
            btnCancel.Enabled = true;
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnSave);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            if (!IsPostBack)
            {
                txtCustomer.Focus();
                ddlCustomerTypefill();
               
            }
        }

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer customerobjs = new DataAccess.Masters.MasterCustomer();
            obj_dt = customerobjs.GetLikeCustomer(prefix.ToUpper(), "C");
            List_Result = Utility.Fn_DatatableToList(obj_dt, "customer", "customerid");
            return List_Result;
        }

        private void ddlCustomerTypefill()
        {
            DataTable dttype = new DataTable();
            ddlIDProof.Items.Clear();
            ddlAddProof.Items.Clear();

            dttype = customerobj.SPSelKYCProof("I");
            if (dttype.Rows.Count > 0)
            {
                ddlIDProof.Items.Add("Select");
                for (int i = 0; i <= dttype.Rows.Count - 1; i++)
                {
                    ddlIDProof.Items.Add(dttype.Rows[i]["Proofmaster"].ToString());
                }
            }

            dttype = customerobj.SPSelKYCProof("A");
            if (dttype.Rows.Count > 0)
            {
                ddlAddProof.Items.Add("Select");
                for (int i = 0; i <= dttype.Rows.Count - 1; i++)
                {
                    ddlAddProof.Items.Add(dttype.Rows[i]["Proofmaster"].ToString());
                }
            }

            // dttype = customerobj.SPSelKYCProof("E");
            //if(dttype.Rows.Count > 0 )
            // {
            //     for (int i = 0; i <= dttype.Rows.Count - 1; i++)
            //     {
            //         ddlIECProof.Items.Add(dttype.Rows[i]["Proofmaster"].ToString());
            //     }
            //}
        }

        private void txtclear()
        {
            txtCustomer.Text = "";
            //ddlIDProof.Text = "";
            ddlIDProof.SelectedIndex = 0;
            //ddlAddProof.Text = "";
            ddlAddProof.SelectedIndex = 0;
            //ddlIECProof.Text = "";
            //ddlIECProof.SelectedIndex = 0;
            txtIECDoc.Text = "";
            txtCustomer.Focus();
            //btnSave.Text = "Save";
            //btnCancel.Text = "Cancel";


            btnSave.ToolTip = "Save";
            btnSave1.Attributes["class"] = "btn ico-save";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        private void CheckData()
        {
            if (txtCustomer.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer cannot be Blank');", true);
                txtCustomer.Focus();
                k = 0;
                return;
            }
            else if (ddlIDProof.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer IDProof Type cannot be Blank');", true);
                ddlIDProof.Focus();
                k = 0;
                return;
            }
            else if (!(fuIDDoc.HasFile))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('ID Proof of File DocPath cannot be Blank');", true);
                fuIDDoc.Focus();
                k = 0;
                return;
            }
            else if (ddlAddProof.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer Add.Proof Type cannot be Blank');", true);
                ddlAddProof.Focus();
                k = 0;
                return;
            }
            else if (!(fuAddrProof.HasFile))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Address Proof of File DocPath cannot be Blank');", true);
                fuAddrProof.Focus();
                k = 0;
                return;
            }
            else if (txtIECDoc.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('IEC Proof of File DocPath cannot be Blank');", true);
                txtIECDoc.Focus();
                k = 0;
                return;
            }
        }

        private void collectdata()
        {
            idfilename = hid_customerid.Value + " " + fuIDDoc.FileName;
            addfilename = hid_customerid.Value + " " + fuAddrProof.FileName;
            ieccode = hid_customerid.Value + " " + txtIECDoc.Text;
            //iecfilename = hid_customerid.Value & " " & txtIECDoc.Text
            idfilepath = Path.GetFileName(fuIDDoc.FileName);
            addfilepath = Path.GetFileName(fuAddrProof.FileName);
        }

        protected void ddlIDProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlIDProof.Text != "")
            {
                if (ddlIDProof.Text == "Voter ID")
                { 
                    id = 1;
                }
                else if (ddlIDProof.Text == "PAN Card")
                {
                    id = 2;
                }
                else if (ddlIDProof.Text == "Aadhaar")
                {
                    id = 3;
                }
            }
        }

        protected void ddlAddProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAddProof.Text != "")
            {
                if (ddlAddProof.Text == "Voter ID")
                {
                    add = 1;
                }
                else if (ddlAddProof.Text == "PAN Card")
                {
                    add = 2;
                }
                else if (ddlAddProof.Text == "Aadhaar")
                {
                    add = 3;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CheckData();
            if (k == 1)
            {                
                if (Path.GetExtension(fuIDDoc.FileName) == ".pdf" && Path.GetExtension(fuAddrProof.FileName) == ".pdf")
                {
                    fuIDDoc.SaveAs(Server.MapPath("PDF/" + fuIDDoc.FileName));
                    fuAddrProof.SaveAs(Server.MapPath("PDF/" + fuAddrProof.FileName));
                    c = Server.MapPath("PDF/" + fuIDDoc.FileName);
                    d = Server.MapPath("PDF/" + fuAddrProof.FileName);
                    collectdata();
                    fileupload(fuIDDoc.FileName, c);
                    fileupload(fuAddrProof.FileName, d);
                    customerobj.inskycproofcustomer(int.Parse(hid_customerid.Value), id, idfilename, add, addfilename, ieccode, int.Parse(Session["LoginEmpId"].ToString()));
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1730, 1, int.Parse(Session["LoginBranchid"].ToString()), hid_customerid + "-" + idfilepath + "-" + addfilepath);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Uploaded Succesfully');", true);
                   
                    txtclear();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Upload Only PDF Files');", true);
                }
            }
        }
        private void fileupload(string filenames,string path)
        {
            b = Path.GetFileName(filenames);
            a = "ftp://182.73.176.69/" + hid_customerid.Value + "-" + b;            
            FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            req.Credentials = new NetworkCredential("administrator", "tvm01mps");               
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Proxy = null;            
            byte[] file = System.IO.File.ReadAllBytes(path);
            System.IO.Stream str = req.GetRequestStream();
            str.Write(file, 0, file.Length);
            str.Close();
            str.Dispose();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
           
            str_RptName = "MasterCustomer.rpt";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnView, typeof(Button), "MasterCustomer4KYC", str_Script, true);
            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1730, 3, int.Parse(Session["LoginBranchid"].ToString()), hid_customerid + "-" + idfilepath + "-" + addfilepath);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip=="Cancel")
            {
                txtclear();
                txtCustomer.Focus();
               // btnCancel.Text = "Back";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
            
        }

        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            txtCustomer.Focus();
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1730, "Mscus", hid_customerid.Value, hid_customerid.Value, "");  //"/Rate ID: " +
            if (txtCustomer.Text != "")
            {
                JobInput.Text = txtCustomer.Text;

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