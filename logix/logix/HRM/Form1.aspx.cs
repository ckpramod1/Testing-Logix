using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace logix.HRM
{
    public partial class Form1 : System.Web.UI.Page
    {
        string st;
        SqlConnection con;
        SqlCommand cmd;
        Boolean bolerr;
        int ccode, cpf, cesi, cac, cpan, cbankname;
        int int_empcode = 0, eid;
        string code, pfno, esino, acno, panno, bankname, strELtyp, strELtyp1, strEAtyp, strEAtyp1, strLTAtyp, strLTAtyp1, strltastus;
        int intbasic, inthra, intconv, intsodexo, intentallow, intsalmed, intdrallow, intsalothr, intsallow, intgross, intinc, inttds;
        int tmp_amt = 0, intlta, intltadt, intltstus, intea, uiid = 0, intel, inteldt;
        double dblbasic=0, dblhra=0, dblconv=0, dblsodexo=0, dblentallow=0, dblsalmed=0, dbldrallow=0, dblsalothr=0, dblsallow=0, dblgross=0;
        double dbl_PF = 0, dbl_ESI = 0, dbl_petrol = 0, dbl_mobile = 0, dbl_phone = 0, dbl_dc = 0, dbl_other = 0, dbl_vma = 0, dbl_DV = 0, dbl_mc = 0, dbl_mcamt = 0;
        double dblamtea, dblamtel, dblamtlta, dblamtinc, dblamttds;
        DateTime dtEL, dtlta, dtInc;
        DataAccess.HR.Employee objHrEmp = new DataAccess.HR.Employee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);
            st = "Data Source=ifreight.database.windows.net;Initial Catalog=SLDB;User ID=ifrtAdmin;pwd=05Jun!(&%";

        }

        protected void Btn_Import_Click(object sender, EventArgs e)
        {
            try
            {
                ImportAttendence(Txt_Path.FileName, grdview);
                if (grdview.Rows.Count > 0)
                {
                    //btnback.Text = "Cancel";
                    btnback.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    //btnback.Text = "Back";
                    btnback.ToolTip = "Back";
                    btn_back1.Attributes["class"] = "btn ico-back";
                }
            }
            catch (Exception EX)
            {

            }
        }

        public void ImportAttendence(string PrmPathExcelFile, GridView DataGrid1)
        {
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection();
                DataSet DtSet = new DataSet();
                System.Data.OleDb.OleDbDataAdapter MyCommand = new System.Data.OleDb.OleDbDataAdapter();
                string[] strTempArray;
                int intlen;

                strTempArray = PrmPathExcelFile.Split('.');
                intlen = strTempArray.Length - 1;
                if (strTempArray[intlen] == "xlsx")
                {
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " +
                                               "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=Excel 8.0;");
                }
                else if (strTempArray[intlen] == "xlsm")
                {
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " +
                                               "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=Excel 8.0;");
                }
                else if (strTempArray[intlen] == "xls")
                {
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " +
                                               "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=Excel 8.0;");
                }

                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [sheet1$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "Attendence");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                DataGrid1.DataSource = DtSet.Tables[0];
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            checkdata();
            if (bolerr == true)
            {
                bolerr = false;
                return;
            }            
            if (rdsalryupld.Checked == true)
            {
                salupload();
                clear();
            }
            else if (rdELupld.Checked == true)
            {
                ELlupload();
                clear();
            }
            else if (rdEAupld.Checked == true)
            {
                EAlupload();
                clear();
            }
            else if (rdLTAupld.Checked == true)
            {
                LTAlupload();
                clear();
            }
            else if (rdIncentiveupld.Checked == true)
            {
                Incentiveupload();
                clear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Choose Any One Option');", true);
                return;
            }
        }

        public void clear()
        {
            rdsalryupld.Checked = false;
            rdEAupld.Checked = false;
            rdELupld.Checked = false;
            rdLTAupld.Checked = false;
            rdIncentiveupld.Checked = false;
            //btnback.Text = "Back";
            btnback.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
        }

        public void salupload()
        {
            con = new SqlConnection(st);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (grdview.Rows.Count > 0)
            {
                for (int i = 0; i <= grdview.Columns.Count - 1; i++)
                {
                    if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "EID")
                    {
                        ccode = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "BASIC")
                    {
                        intbasic = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "HRA")
                    {
                        inthra = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "CONV")
                    {
                        intconv = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "SODEXO")
                    {
                        intsodexo = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "ENT#REIM")
                    {
                        intentallow = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "MED#REIM")
                    {
                        intsalmed = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "DR#REIM")
                    {
                        intdrallow = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "SPALL")
                    {
                        intsallow = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "GROSS")
                    {
                        intgross = i;
                    }
                }
                try
                {
                    for (int i = 0; i <= grdview.Rows.Count - 1; i++)
                    {
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[ccode].Text) == false)
                        {
                            code = grdview.Rows[i].Cells[ccode].Text;
                            eid = objHrEmp.GetEmpId(code);
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intbasic].Text) == false)
                            {
                                dblbasic = Convert.ToDouble(grdview.Rows[i].Cells[intbasic].Text);
                            }
                            else
                            {
                                dblbasic = 0;
                            }
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[inthra].Text) == false)
                            {
                                dblhra = Convert.ToDouble(grdview.Rows[i].Cells[inthra].Text);
                            }
                            else
                            {
                                dblhra = 0;
                            }
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intconv].Text) == false)
                            {
                                dblconv = Convert.ToDouble(grdview.Rows[i].Cells[intconv].Text);
                            }
                            else
                            {
                                dblconv = 0;
                            }
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intsodexo].Text) == false)
                            {
                                dblsodexo = Convert.ToDouble(grdview.Rows[i].Cells[intsodexo].Text);
                            }
                            else
                            {
                                dblsodexo = 0;
                            }
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intentallow].Text) == false)
                            {
                                dblentallow = Convert.ToDouble(grdview.Rows[i].Cells[intentallow].Text);
                            }
                            else
                            {
                                dblentallow = 0;
                            }
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intsalmed].Text) == false)
                            {
                                dblsalmed = Convert.ToDouble(grdview.Rows[i].Cells[intsalmed].Text);
                            }
                            else
                            {
                                dblsalmed = 0;
                            }
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intdrallow].Text) == false)
                            {
                                dbldrallow = Convert.ToDouble(grdview.Rows[i].Cells[intdrallow].Text);
                            }
                            else
                            {
                                dbldrallow = 0;
                            }
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intsallow].Text) == false)
                            {
                                dblsallow = Convert.ToDouble(grdview.Rows[i].Cells[intsallow].Text);
                            }
                            else
                            {
                                dblsallow = 0;
                            }
                            if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intgross].Text) == false)
                            {
                                dblgross = Convert.ToDouble(grdview.Rows[i].Cells[intgross].Text);
                            }
                            else
                            {
                                dblgross = 0;
                            }
                            cmd.CommandText = "insert into hrsalarydetails values(" + eid + "," + dblbasic + "," +
                                dblhra + "," + dblsallow + "," + dblsodexo + "," + dblconv + "," + "0" + ",'" + "06/01/2015" + "','" +
                                "03/31/2016" + "'," + "0" + "," + dblentallow + "," + dbldrallow + "," + dblgross + ",'" + "04/01/2015" + "','" +
                                "05/24/2015" + "',0," + dblsalmed + ")";
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();

                            dbl_PF = System.Math.Round((dblbasic * 12) / 100);
                            dbl_ESI = 0;
                            if (dblgross < 15000)
                            {
                                dbl_ESI = Convert.ToDouble(string.Format("{0.00}", (dblgross * 1.75) / 100));
                                tmp_amt = Convert.ToInt32(dbl_ESI.ToString().Substring(dbl_ESI.ToString().Length - 2, 2));
                                if (tmp_amt > 0)
                                {
                                    dbl_ESI = Convert.ToDouble(dbl_ESI.ToString().Substring(0, dblgross.ToString().Length - 2) + 1);
                                }
                            }
                            cmd.CommandText = "insert into hrcontribution values(" + eid + "," + dbl_PF.ToString() + "," + dbl_ESI.ToString() + ",'" + "06/01/2015" + "','" + "03/31/2016" + "')";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "insert into HRAllowances values(" + eid + "," + dbl_petrol.ToString() + "," +
                                dbl_mobile.ToString() + "," + dbl_phone.ToString() + "," + dbl_dc.ToString() + ",0,'" + "06/01/2015" + "','" +
                                "03/31/2016" + "'," + dbl_vma.ToString() + "," + dbl_DV.ToString() + ",0,0)";
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "insert into HRAnnualCompensation values(" + eid + "," + "0" + "," + "0" + "," + "0" + "," + "0" + ",'" + "06/01/2015" + "','" + "03/31/2016" + "')";
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            code = "";
                        }
                        if (code.Length == 1)
                        {
                            code = "000" + code;
                        }
                        else if (code.Length == 2)
                        {
                            code = "00" + code;
                        }
                        else if (code.Length == 3)
                        {
                            code = "0" + code;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex + "');", true);
                }
                int branchid = Convert.ToInt32(Session["LoginBranchid"]);
                int logempid = Convert.ToInt32(Session["LoginEmpId"]);
                logobj.InsLogDetail(logempid, uiid, 1, branchid, "\\S");
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
            }
            con.Close();
        }

        public void ELlupload()
        {
            con = new SqlConnection(st);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            strELtyp = "";
            strELtyp1 = "";
            if (grdview.Rows.Count > 0)
            {
                for (int i = 0; i <= grdview.Columns.Count - 1; i++)
                {
                    if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "EMPCODE")
                    {
                        ccode = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "CLAIMINGDATE")
                    {
                        inteldt = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "ELAMOUNT")
                    {
                        intel = i;
                    }
                }

                for (int i = 0; i <= grdview.Rows.Count - 1; i++)
                {
                    if (string.IsNullOrEmpty(grdview.Rows[i].Cells[ccode].Text) == false)
                    {
                        code = grdview.Rows[i].Cells[ccode].Text;
                        eid = objHrEmp.GetEmpId(code);
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[inteldt].Text) == false)
                        {
                            dtEL = Convert.ToDateTime(grdview.Rows[i].Cells[inteldt].Text);
                        }
                        else
                        {
                            dtEL = logobj.GetDate();
                        }
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intel].Text) == false)
                        {
                            dblamtel = Convert.ToDouble(grdview.Rows[i].Cells[intel].Text);
                        }
                        else
                        {
                            dblamtel = 0;
                        }
                        strELtyp = "'LC'";
                        strELtyp1 = "'L'";

                        cmd.CommandText = "INSERT INTO HREmpCompClaim  (employeeid,claimtype,claimamt,claimedon,clchk,seton) VALUES (" + eid + "," + strELtyp1 + "," + dblamtel + ",'" + dtEL + "'," + 1 + ",'" + dtEL + "')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "insert into hrclaimdetails (empid,claimtype,claimedon,seton ,amount,taxablefy ,taxablamt,nontaxablamt)  values(" + eid + "," + strELtyp + ",'" + dtEL + "','" + dtEL + "'," + dblamtel + "," + "'Y'" + "," + dblamtel + "," + 0 + ")";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        code = "";
                    }
                    if (code.Length == 1)
                    {
                        code = "000" + code;
                    }
                    else if (code.Length == 2)
                    {
                        code = "00" + code;
                    }
                    else if (code.Length == 3)
                    {
                        code = "0" + code;
                    }
                }

                int branchid = Convert.ToInt32(Session["LoginBranchid"]);
                int logempid = Convert.ToInt32(Session["LoginEmpId"]);
                logobj.InsLogDetail(logempid, uiid, 1, branchid, "\\S");
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
            }
            con.Close();
        }

        public void EAlupload()
        {
            con = new SqlConnection(st);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            strEAtyp = "";
            strEAtyp1 = "";
            if (grdview.Rows.Count > 0)
            {
                for (int i = 0; i <= grdview.Columns.Count - 1; i++)
                {
                    if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "EMPCODE")
                    {
                        ccode = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "AMOUNTS")
                    {
                        intea = i;
                    }
                }

                for (int i = 0; i <= grdview.Rows.Count - 1; i++)
                {
                    if (string.IsNullOrEmpty(grdview.Rows[i].Cells[ccode].Text) == false)
                    {
                        code = grdview.Rows[i].Cells[ccode].Text;
                        eid = objHrEmp.GetEmpId(code);
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intea].Text) == false)
                        {
                            dblamtea = Convert.ToDouble(grdview.Rows[i].Cells[intea].Text);
                        }
                        else
                        {
                            dblamtea = 0;
                        }
                        strEAtyp = "'AE'";
                        strEAtyp1 = "'A'";

                        cmd.CommandText = "INSERT INTO HREmpCompClaim  (employeeid,claimtype,claimamt,claimedon,clchk,seton) VALUES (" + eid + "," + strEAtyp1 + "," + dblamtea + ",'" + logobj.GetDate() + "'," + 1 + ",'" + logobj.GetDate() + "')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "insert into hrclaimdetails (empid,claimtype,claimedon,seton ,amount,taxablefy ,taxablamt,nontaxablamt)  values(" + eid + "," + strEAtyp + ",'" + logobj.GetDate() + "','" + logobj.GetDate() + "'," + dblamtea + "," + "'Y'" + "," + dblamtea + "," + 0 + ")";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        code = "";
                    }
                    if (code.Length == 1)
                    {
                        code = "000" + code;
                    }
                    else if (code.Length == 2)
                    {
                        code = "00" + code;
                    }
                    else if (code.Length == 3)
                    {
                        code = "0" + code;
                    }
                }

                int branchid = Convert.ToInt32(Session["LoginBranchid"]);
                int logempid = Convert.ToInt32(Session["LoginEmpId"]);
                logobj.InsLogDetail(logempid, uiid, 1, branchid, "\\S");
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
            }
            con.Close();
        }

        public void LTAlupload()
        {
            con = new SqlConnection(st);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           strLTAtyp = "";
           strLTAtyp1 = "";
            if (grdview.Rows.Count > 0)
            {
                for (int i = 0; i <= grdview.Columns.Count - 1; i++)
                {
                    if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "EMPCODE")
                    {
                        ccode = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "DATEOFCLAIMING")
                    {
                        intltadt = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "LTA")
                    {
                        intlta = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "ITSTATUS")
                    {
                        intltstus = i;
                    }
                }

                for (int i = 0; i <= grdview.Rows.Count - 1; i++)
                {
                    if (string.IsNullOrEmpty(grdview.Rows[i].Cells[ccode].Text) == false)
                    {
                        code = grdview.Rows[i].Cells[ccode].Text;
                        eid = objHrEmp.GetEmpId(code);
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intltadt].Text) == false)
                        {
                            dtlta = Convert.ToDateTime(grdview.Rows[i].Cells[intltadt].Text);
                        }
                        else
                        {
                            dtlta = logobj.GetDate();
                        }
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intlta].Text) == false)
                        {
                            dblamtlta = Convert.ToDouble(grdview.Rows[i].Cells[intlta].Text);
                        }
                        else
                        {
                            dblamtlta = 0;
                        }
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intltstus].Text) == false)
                        {
                            if (grdview.Rows[i].Cells[intltstus].Text == "Tax")
                            {
                                strltastus = "'Y'";
                            }
                            else
                            {
                                strltastus = "'N'";
                            }
                        }
                        else
                        {
                            strltastus = "";
                        }
                        strLTAtyp = "'LT'";
                        strLTAtyp1 = "'L'";

                        cmd.CommandText = "INSERT INTO HREmpCompClaim  (employeeid,claimtype,claimamt,claimedon,clchk,seton) VALUES (" + eid + "," + strLTAtyp1 + "," + dblamtlta + ",'" + dtlta + "'," + 1 + ",'" + dtlta + "')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "insert into hrclaimdetails (empid,claimtype,claimedon,seton ,amount,taxablefy ,taxablamt,nontaxablamt)  values(" + eid + "," + strLTAtyp + ",'" + dtlta + "','" + dtlta + "'," + dblamtlta + "," + strltastus + "," + dblamtlta + "," + 0 + ")";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        code = "";
                    }
                    if (code.Length == 1)
                    {
                        code = "000" + code;
                    }
                    else if (code.Length == 2)
                    {
                        code = "00" + code;
                    }
                    else if (code.Length == 3)
                    {
                        code = "0" + code;
                    }
                }

                int branchid = Convert.ToInt32(Session["LoginBranchid"]);
                int logempid = Convert.ToInt32(Session["LoginEmpId"]);
                logobj.InsLogDetail(logempid, uiid, 1, branchid, "\\S");
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
            }
            con.Close();
        }

        public void Incentiveupload()
        {
            con = new SqlConnection(st);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (grdview.Rows.Count > 0)
            {
                for (int i = 0; i <= grdview.Columns.Count - 1; i++)
                {
                    if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "EMPCODE")
                    {
                        ccode = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "INCENTIVE")
                    {
                        intinc = i;
                    }
                    else if (grdview.Columns[i].HeaderText.ToUpper().Replace(" ", "") == "TDS")
                    {
                        inttds = i;
                    }
                }

                for (int i = 0; i <= grdview.Rows.Count - 1; i++)
                {
                    if (string.IsNullOrEmpty(grdview.Rows[i].Cells[ccode].Text) == false)
                    {
                        code = grdview.Rows[i].Cells[ccode].Text;
                        eid = objHrEmp.GetEmpId(code);
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[intinc].Text) == false)
                        {
                            dblamtinc = Convert.ToDouble(grdview.Rows[i].Cells[intinc].Text);
                        }
                        else
                        {
                            dblamtinc = 0;
                        }
                        if (string.IsNullOrEmpty(grdview.Rows[i].Cells[inttds].Text) == false)
                        {
                            dblamttds = Convert.ToDouble(grdview.Rows[i].Cells[inttds].Text);
                        }
                        else
                        {
                            dblamttds = 0;
                        }
                        dtInc = Convert.ToDateTime(logobj.GetDate().Month + "/01/" + logobj.GetDate().Year);
                        
                        cmd.CommandText = "INSERT INTO   HRIncentiveDetails(empid,tdsp,tdsa, date,amount) values (" + eid + "," + 0 + "," + dblamttds + ",'" + logobj.GetDate() + "'," + dblamtinc + ")";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "INSERT INTO   HRTDSDetails(empid,paymonth,payyear, depdate,tds,datafrom) values (" + eid + "," + (logobj.GetDate().Month) + "," + (logobj.GetDate().Year) + ",'" + logobj.GetDate() + "'," + dblamttds + ",'T')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        code = "";
                    }
                    if (code.Length == 1)
                    {
                        code = "000" + code;
                    }
                    else if (code.Length == 2)
                    {
                        code = "00" + code;
                    }
                    else if (code.Length == 3)
                    {
                        code = "0" + code;
                    }
                }

                int branchid = Convert.ToInt32(Session["LoginBranchid"]);
                int logempid = Convert.ToInt32(Session["LoginEmpId"]);
                logobj.InsLogDetail(logempid, uiid, 1, branchid, "\\S");
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
            }
            con.Close();
        }

        public void checkdata()
        {
            if (!Txt_Path.HasFile)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('File Path Can not be Blank');", true);
                bolerr = true;
                Txt_Path.Focus();
                return;
            }
            if (grdview.Rows.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Import Value Can not be Empty');", true);
                bolerr = true;
                Btn_Import.Focus();
                return;
            }
        }

        protected void grdview_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdview, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
    }
}