using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.IO;
using System.Text;

namespace logix.FAForm
{
    public partial class ProfitLoss4allbranch : System.Web.UI.Page
    {
        DataAccess.ProfitandLoss plobj = new DataAccess.ProfitandLoss();
        DataSet ds = new DataSet();
       
        int Divisionid;
        int Branchid;
        string DBName;

        int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_export);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                txt_From.Text = "01/04/" + DateTime.Now.Year.ToString();
                txt_To.Text = Str_CurrrentDate;
            }

            Divisionid = Convert.ToInt32(Session["LoginDivisionid"]);
            Branchid = Convert.ToInt32(Session["LoginBranchid"]);
            DBName= (Session["FADbname"].ToString());
            txt_From.Text = Request.QueryString["dtfrom"].ToString();
            txt_To.Text = Request.QueryString["dtto"].ToString();
          
            displaydetails();
          
        }
        public void displaydetails()
        {
            ds = plobj.SelProiftLoss4Branchwise(DBName, Divisionid, Branchid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));

            DataView dv = new DataView();
            DataTable dtDr = new DataTable();
            DataTable dtIn = new DataTable();
            dtDr = ds.Tables[0];
                dtIn=ds.Tables[1];
                dv = new DataView(dtDr);
                DataTable dtport = new DataTable();
                dtport = dv.ToTable(true, "portname");
                DataTable dttemp = new DataTable();
                dttemp.Columns.Add("groupid", typeof(int));
            dttemp.Columns.Add("GroupName",typeof(string));
            int RN = 0, CN = 0;
        
            for (int i=0;i<=dtport.Rows.Count-1;i++)
            {
                dttemp.Columns.Add(dtport.Rows[i]["portname"].ToString());
                dttemp.Columns.Add(" "+dtport.Rows[i]["portname"].ToString());
                

            }
            dttemp.Columns.Add("gtype", typeof(string));
            //dttemp.Rows[0[CN] = "H";
           
            //DataRow dr = dttemp.NewRow();
            //dttemp.Rows.Add(dr);
            //dttemp.Rows[0][0] =0;
            //dttemp.Rows[0][1] = "GroupName";
            //for (int i = 0; i <= dtport.Rows.Count - 1; i++)
            //{
            //    dr[CN] = dtport.Rows[i]["portname"].ToString();
            //    CN = CN + 1;
            //    dr[CN] = dtport.Rows[i]["portname"].ToString();
            //    CN = CN + 1;

            //}
            //dr[CN] = "H";
             DataTable dtgroup = dv.ToTable(true, "groupid");




             dttemp.Rows.Add();
             RN = 0;
             CN = 2;

            for (int k = 0; k <= dtport.Rows.Count - 1; k++)
            {
                dttemp.Rows[RN][CN] = "Expenses";
               
                CN = CN + 1;
                dttemp.Rows[RN][CN] = "Income";
              
                CN = CN + 1;
            }
            dttemp.Rows[RN][CN] = "H";



            for (int j = 0; j <= dtgroup.Rows.Count - 1; j++)
            {
                dttemp.Rows.Add();
                RN = dttemp.Rows.Count-1;
                CN = 2;
                DataRow[] foundrows ;

                for (int l = 0;l <= dtport.Rows.Count - 1; l++)
                {
                    //foundrow=ds.Tables[0].Select(("groupid" = +  dtgroup.Rows[j]["groupid"].ToString() +   );

                    //foundrows = ds.Tables[0].Select(("groupid =" + (dtgroup.Rows[j]["groupid"].ToString() + (" and portname=\'" + (dtport.Rows[l]["portname"].ToString() + "\'")))));
                    foundrows = ds.Tables[0].Select(("groupid =" + dtgroup.Rows[j]["groupid"] + " and portname='" + dtport.Rows[l]["portname"].ToString() + "'"));

if (foundrows.Length>0)
{
    dttemp.Rows[RN][1] = foundrows[0]["groupname"].ToString();
        if (foundrows[0]["grouptype"].ToString()=="E")
        {
           
            dttemp.Rows[RN][CN]=  string.Format("{0:0.00}",  Convert.ToDouble(foundrows[0]["EAmount"] ) )  ;
            CN = CN + 1;
            CN = CN + 1;
        }
        else
        {
            CN = CN + 1;
            dttemp.Rows[RN][CN] = string.Format("{0:0.00}",Convert.ToDouble(foundrows[0]["IAmount"]));
            CN = CN + 1;
        }

}
else
{
    dttemp.Rows[RN][CN] = "0.00";
    CN = CN + 1;
    dttemp.Rows[RN][CN] = "0.00";
    CN = CN + 1;

}


                }
            }
            dttemp.Rows.Add();
            dttemp.Rows.Add();
            RN = dttemp.Rows.Count - 1;
            CN = 2;
            object totexp=0;
            object totinc=0;
            int gplrowno;



       
            dttemp.Rows[RN][1] = "Gross Profit / Loss ";
            dttemp.Rows.Add();
            dttemp.Rows[RN+1][1] = "Total";
            dttemp.Rows.Add();
            dttemp.Rows[RN + 2][1] = "Gross Profit / Loss ";

            gplrowno = dttemp.Rows.Count - 1;

            object objtmp;

          

            for (int k = 0; k <= dtport.Rows.Count - 1; k++)
            {
                totexp = 0;
                totinc = 0;

                objtmp = ds.Tables[0].Compute("sum(EAmount)", "grouptype='E' and portname= '" + dtport.Rows[k]["portname"].ToString() + "'");
                if ((objtmp != System.DBNull.Value)) 
                {
                    totexp = objtmp;
                }

                objtmp = ds.Tables[0].Compute("sum(IAmount)", "grouptype='I' and portname= '" + dtport.Rows[k]["portname"].ToString() + "'");
                if ((objtmp !=System.DBNull.Value))
                {
                    totinc = objtmp;
                }

                if ((Convert.ToDouble(totexp)) < (Convert.ToDouble(totinc)))
                {
                    dttemp.Rows[RN][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totinc)) - (Convert.ToDouble(totexp)));

                    dttemp.Rows[RN + 1][CN] = string.Format("{0:0.00}", (Convert.ToDouble(totexp)) + ((Convert.ToDouble(totinc)) - (Convert.ToDouble(totexp))));
                    CN = CN + 1;

                    dttemp.Rows[RN + 1][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totinc)));
                
                    dttemp.Rows[RN + 2][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totinc)) - (Convert.ToDouble(totexp)));
                    CN = CN + 1;
                }
                else
                {
                    dttemp.Rows[RN + 1][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totexp)));

                    dttemp.Rows[RN + 2][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totexp)) - (Convert.ToDouble(totinc)));
                    CN = CN + 1;
                    dttemp.Rows[RN][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totexp)) - (Convert.ToDouble(totinc)));
                    dttemp.Rows[RN + 1][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totinc)) + ((Convert.ToDouble(totexp)) - (Convert.ToDouble(totinc))));
                    CN = CN + 1;
                }
          
            }
           

            dttemp.Rows.Add();




            //------------------------------------ds.tables[1]

            dtgroup = ds.Tables[1].DefaultView.ToTable(true, "groupid");
            for (int j = 0; j <= dtgroup.Rows.Count - 1; j++)
            {
                dttemp.Rows.Add();
                RN = dttemp.Rows.Count-1;
                CN = 2;
                DataRow[] foundrows;

                for (int l = 0; l <= dtport.Rows.Count - 1; l++)
                {
                    //foundrow=ds.Tables[0].Select(("groupid" = +  dtgroup.Rows[j]["groupid"].ToString() +   );

                    foundrows = ds.Tables[1].Select(("groupid =" + dtgroup.Rows[j]["groupid"]+ " and portname='" + dtport.Rows[l]["portname"].ToString() + "'"));

                    if (foundrows.Length > 0)
                    {
                        dttemp.Rows[RN][1] = foundrows[0]["groupname"].ToString();
                        if (foundrows[0]["grouptype"].ToString() == "E")
                        {

                            dttemp.Rows[RN][CN] = string.Format("{0:0.00}", Convert.ToDouble(foundrows[0]["EAmount"]));
                            CN = CN + 1;
                            CN = CN + 1;
                        }
                        else
                        {
                            CN = CN + 1;
                            dttemp.Rows[RN][CN] = string.Format("{0:0.00}", Convert.ToDouble(foundrows[0]["IAmount"]));
                            CN = CN + 1;
                        }

                    }
                    else
                    {
                        dttemp.Rows[RN][CN] = "0.00";
                        CN = CN + 1;
                        dttemp.Rows[RN][CN] = "0.00";
                        CN = CN + 1;

                    }


                }
            }
            dttemp.Rows.Add();
            dttemp.Rows.Add();
            RN = dttemp.Rows.Count - 1;
            CN = 2;
           



            dttemp.Rows[RN][1] = "Net Profit / Loss ";
            
            dttemp.Rows.Add();
            dttemp.Rows[RN + 1][1] = "Total";
            dttemp.Rows.Add();
            double npl;






            for (int k = 0; k <= dtport.Rows.Count - 1; k++)
            {
                totexp = 0;
                totinc = 0;
                npl = 0;
                objtmp = ds.Tables[1].Compute("sum(EAmount)", "grouptype='E' and portname='" + dtport.Rows[k]["portname"].ToString() + "'");
                if ((objtmp != System.DBNull.Value))
                {
                    totexp = objtmp;
                }

                objtmp = ds.Tables[1].Compute("sum(IAmount)", "grouptype='I' and  portname ='" + dtport.Rows[k]["portname"].ToString() + "'");
                if ((objtmp != System.DBNull.Value))
                {
                    totinc = objtmp;
                }

                if (dttemp.Rows[gplrowno][CN] != System.DBNull.Value)
                {
                    npl = (Convert.ToDouble(dttemp.Rows[gplrowno][CN]));
                    totexp = (npl) += Convert.ToDouble(totexp);

                }
                else
                {
                    npl = Convert.ToDouble(dttemp.Rows[gplrowno][CN+1]);
                    totinc = (npl) += Convert.ToDouble(totinc);
                }
                if ((Convert.ToDouble(totexp)) < (Convert.ToDouble(totinc)))
                {
                    dttemp.Rows[RN][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totinc)) - (Convert.ToDouble(totexp)));

                    dttemp.Rows[RN + 1][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totexp)) + ((Convert.ToDouble(totinc)) - (Convert.ToDouble(totexp))));
                    CN = CN + 1;

                    dttemp.Rows[RN + 1][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totinc)));
                    CN = CN + 1;
                 
                }
                else
                {
                    dttemp.Rows[RN + 1][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totexp)));
                    CN = CN + 1;
                   
                    dttemp.Rows[RN][CN] = string.Format("{0:0.00}",(Convert.ToDouble(totexp)) - (Convert.ToDouble(totinc)));
                    dttemp.Rows[RN + 1][CN] = string.Format("{0:0.00}", (Convert.ToDouble(totinc)) + ((Convert.ToDouble(totexp)) - (Convert.ToDouble(totinc))));
                    CN = CN + 1;
                    
                    
                }

            }






            //dttemp.Columns["groupid"].ColumnMapping = MappingType.Hidden;

            //dttemp.Columns["gtype"].ColumnMapping = MappingType.Hidden;
            //dttemp.AcceptChanges();
            index = dttemp.Columns.Count-1;
            grd.DataSource = dttemp;
            grd.DataBind();


            ViewState["dttemp"] = dttemp;
          
        //    DataGridView1.Rows(int_RNO).Cells("gtype").Value = "H"
        //DataGridView1.Rows(int_RNO).Cells("gtype").ToolTipText = "H"

        //Dim dt_DistGroupId As New DataTable
        //dt_DistGroupId = ds_AllBranchBS.Tables(0).DefaultView.ToTable(True, "Groupid")


        }

       

        protected void btn_Export_Click(object sender, EventArgs e)
        {
           // DataTable dt_check = ViewState["dttemp"] as DataTable;
        //    dt_check.Columns.Remove("salesid");

            if (grd.Rows.Count > 0)
            {
                //using (XLWorkbook wb = new XLWorkbook())
                //{
                //    //wb.Worksheets.Add("test");

                //    wb.Worksheets.Add(dt_check);

                //    Response.Clear();
                //    Response.Buffer = true;
                //    Response.Charset = "";
                //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //    Response.AddHeader("content-disposition", "attachment;filename=Outstanding.xls");
                //    using (MemoryStream MyMemoryStream = new MemoryStream())
                //    {
                //        wb.SaveAs(MyMemoryStream);
                //        MyMemoryStream.WriteTo(Response.OutputStream);
                //        Response.Flush();
                //        Response.End();
                //    }
                //}


                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Outstanding for the period of " + txt_From.Text + " To " + txt_To.Text + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                if (grd.Visible == true)
                {
                    grd.GridLines = GridLines.Both;
                    grd.HeaderStyle.Font.Bold = true;
                    grd.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            } 
        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            displaydetails();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        
            e.Row.Cells[1].Wrap = false;
            e.Row.Cells[0].Visible=false;
            //int index = grd.Rows[0].Cells.Count;
            e.Row.Cells[index].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowIndex==6) ||(e.Row.RowIndex==11))
                {
                    e.Row.ForeColor = System.Drawing.Color.Chocolate;
                }
                else
                {
                    e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                }
               
            }
            //e.Columns[].Visible = false;

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}