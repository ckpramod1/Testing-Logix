using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Maintenance
{
    public partial class ProApprove4KYC : System.Web.UI.Page
    {
        DataTable Dt = new DataTable();
        DataAccess.Masters.MasterCustomer Custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        int custid, index, grdcustid, rowIndex = -1, cellIndex = -1;
        string grdaddfname, grdidpfname, filename;
        string filename1, ftpPassword, ftpuserid;
        string StrScript;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Custobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnapprove);
            if (!this.IsPostBack)
            {
                try
                {
                    getdetails();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }
        public void getdetails()
        {
            Dt = Custobj.FillDt4ProKYC();
            if (Dt.Rows.Count > 0)
            {
                grd.DataSource = Dt;
                grd.DataBind();
            }
        }

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in grd.Rows)
                {
                    CheckBox Chk = (CheckBox)row.FindControl("selectt");
                    if (Chk.Checked == true)
                    {
                        Label custidd = (Label)row.Cells[6].FindControl("cid");
                        Label customer = (Label)row.Cells[6].FindControl("customer");
                        custid = Convert.ToInt32(custidd.Text);
                        Custobj.Updkyc4Proof(custid, int.Parse(Session["LoginEmpId"].ToString()));
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1732, 1, int.Parse(Session["LoginBranchid"].ToString()), custid.ToString());
                        StrScript += customer.Text + ",";
                        //Logobj.InsLogDetail(Login.logempid, 1732, 1, Login.branchid, custid);
                    }
                }
                getdetails();
                StrScript += " has Approved for KYC";
                ScriptManager.RegisterStartupScript(btnapprove, typeof(Button), "BL", "alertify.alert('" + StrScript + "');", true);
                
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCustomer = (Label)e.Row.FindControl("Customer");
                string tooltip = lblCustomer.Text;
                e.Row.Cells[0].Attributes.Add("title", tooltip);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);

                foreach (TableCell cell in e.Row.Cells)
                {
                    if (cell is DataControlFieldCell)
                    {
                        cell.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd,
                            String.Format("CellSelect${0},{1}", e.Row.RowIndex, e.Row.Cells.GetCellIndex(cell)));

                        Page.ClientScript.RegisterForEventValidation(grd.UniqueID,
                            String.Format("CellSelect${0},{1}", e.Row.RowIndex, e.Row.Cells.GetCellIndex(cell)));
                    }
                }
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CellSelect")
            {
                String[] arguments = ((String)e.CommandArgument).Split(new char[] { ',' });
                if (arguments.Length >= 2)
                {
                    //int rowIndex = -1, cellIndex = -1;
                    int.TryParse(arguments[0], out rowIndex);
                    int.TryParse(arguments[1], out cellIndex);
                    //if (rowIndex > -1 && rowIndex < grd.Rows.Count)
                    //{
                    //    grd.SelectedIndex = rowIndex;
                    //}
                    //string b = cellIndex.ToString();
                    if (grd.Rows.Count > 0)
                    {
                        Dt = Custobj.FillDt4ProKYC();
                        index = rowIndex;

                        if (Dt.Rows[index][5].ToString() != "")
                        {
                            grdcustid = Convert.ToInt32(Dt.Rows[index][5].ToString());
                        }
                        else
                        {
                            return;
                        }
                        if (cellIndex == 1)
                        {
                            if (Dt.Rows[index][7].ToString() != "")
                            {
                                filename = Dt.Rows[index][7].ToString();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('Select 2nd or 3rd Cell');", true);
                                return;
                            }
                        }
                        else if (cellIndex == 2)
                        {
                            if (Dt.Rows[index][6].ToString() != "")
                            {
                                filename = Dt.Rows[index][6].ToString();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('Select 2nd or 3rd Cell');", true);
                                return;
                            }
                        }
                        else if (cellIndex == 5)
                        {

                        }
                    }
                }
            }

            if (cellIndex == 1 || cellIndex == 2)
            {
                string a, b, strPart1;
                char[] splitchar = { '\\' };
                string[] aParts = null;
                aParts = filename.Split(splitchar);
                strPart1 = aParts[0];
                a = aParts[aParts.Length - 1];
                b = Path.GetFileName(filename);
                strPart1 = grdcustid + "-" + b;

                try
                {
                    filename1 = strPart1;
                    ftpPassword = "tvm01mps";
                    ftpuserid = "administrator";
                    string ftpURI = "";
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string FileToDelete;
                    FileToDelete = desktopPath + "\\" + strPart1;
                    if (System.IO.File.Exists(FileToDelete) == true)
                    {
                        //int intresult = MsgBox("File has been already exist in to" + desktopPath + " Do you want to delete  ?", MsgBoxStyle.YesNo, "logix");
                        //if (intresult == 6)
                        //{
                            //System.IO.File.Delete(FileToDelete);
                        //}
                        //else 
                        //{
                        //    return;
                        //}
                    }
                    string DownloadedFilePath = "";
                    DownloadedFilePath = desktopPath + "\\" + strPart1;
                    ftpURI = "ftp://182.73.176.69/";
                    string filenames = ftpURI + filename1;
                    //string filenames = ftpURI + b;
                    FtpWebRequest ftpReq = (FtpWebRequest)(WebRequest.Create(filenames));
                    ftpReq.Method = WebRequestMethods.Ftp.DownloadFile;
                    ftpReq.Credentials = new NetworkCredential(ftpuserid, ftpPassword);
                    ftpReq.UseBinary = true;
                    ftpReq.Proxy = null;
                    FtpWebResponse ftpResp = (FtpWebResponse)ftpReq.GetResponse();
                    Stream ftpRespStream = (Stream)ftpResp.GetResponseStream();
                    FileStream fss = new FileStream(DownloadedFilePath, FileMode.OpenOrCreate);
                    byte[] buffer = new byte[2048];
                    int read = 0;
                    do
                    {
                        read = ftpRespStream.Read(buffer, 0, buffer.Length);
                        fss.Write(buffer, 0, read);
                    } while (!(read == 0));
                    fss.Flush();
                    fss.Close();
                    ftpRespStream.Close();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('File has Downloaded into " + DownloadedFilePath + "');", true);
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            else if (cellIndex == 5)
            { }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('Select 2nd or 3rd Cell');", true);
            }
        }
        
        protected void grd_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("selectt");
                CheckBox chkBxHeader = (CheckBox)this.grd.HeaderRow.FindControl("chkBxHeader");
                chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            this.Response.End();
        }
    }
}