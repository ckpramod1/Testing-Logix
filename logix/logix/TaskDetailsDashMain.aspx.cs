using DocumentFormat.OpenXml.Wordprocessing;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix
{
    public partial class TaskDetailsDashMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GetEmpolyeeJsonForTask();SpanTagMoveInputBottom();MuiTextField();dropdownButton();", true);
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "branchlistChanged();SpanTagMoveInputBottom();MuiTextField();dropdownButton();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "voulistChanged();SpanTagMoveInputBottom();MuiTextField();dropdownButton();", true);

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();dropdownButton();", true);


            if (!IsPostBack)
            {
                Session["StrTranType1"] = "TaskManagement";
                //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
                //DataTable dtevent;
                //dtevent = objRpt.EventpendingcountTask(Convert.ToInt32(Session["LoginDivisionId"]), Session["StrTranType"].ToString());
                //if (dtevent.Rows.Count > 0)
                //{
                //    GridView6.DataSource = dtevent;
                //    GridView6.DataBind();
                //}
            }
        }

        [WebMethod]
        public static List<taskdetails> GetEmpolyeeJson(string txtcustomer,string txtSalesPerson)
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);

            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();

            if (txtcustomer != "" & txtcustomer != "0" & txtcustomer != "1")
            {
                dt = objbu.Card4TaskDetailDash(txtcustomer, Convert.ToInt32(txtSalesPerson));
            }
            List<taskdetails> dataList = new List<taskdetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                taskdetails details = new taskdetails();
                details.Taskid = Convert.ToInt32(dtrow[0]);
                details.Tasks = dtrow[1].ToString();
                details.counts = Convert.ToInt32(dtrow[2]);
                details.Icon = dtrow[3].ToString();
                dataList.Add(details);
            }
            return dataList;

        }


        [WebMethod]
        public static List<taskdetails> GetBranchbasedCard(string bid)
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);

            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();

                dt = objbu.Card4TaskDetailDashsbid( bid);
            
            List<taskdetails> dataList = new List<taskdetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                taskdetails details = new taskdetails();
                details.Taskid = Convert.ToInt32(dtrow[0]);
                details.Tasks = dtrow[1].ToString();
                details.counts = Convert.ToInt32(dtrow[2]);
                details.Icon = dtrow[3].ToString();
                dataList.Add(details);
            }
            return dataList;

        }



        [WebMethod]
        public static List<taskdetails> GetVoubasedCard(string vou)
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);

            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();

            dt = objbu.Card4TaskDetailDashsvou(vou);

            List<taskdetails> dataList = new List<taskdetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                taskdetails details = new taskdetails();
                details.Taskid = Convert.ToInt32(dtrow[0]);
                details.Tasks = dtrow[1].ToString();
                details.counts = Convert.ToInt32(dtrow[2]);
                details.Icon = dtrow[3].ToString();
                dataList.Add(details);
            }
            return dataList;

        }


        [WebMethod]
        public static List<taskdetails> GetVoutypebasedCard(string bid,string voutype)
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);

            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();

            dt = objbu.Card4TaskDetailDashsvoutype(Convert.ToInt32(bid), voutype);

            List<taskdetails> dataList = new List<taskdetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                taskdetails details = new taskdetails();
                details.Taskid = Convert.ToInt32(dtrow[0]);
                details.Tasks = dtrow[1].ToString();
                details.counts = Convert.ToInt32(dtrow[2]);
                details.Icon = dtrow[3].ToString();
                dataList.Add(details);
            }
            return dataList;

        }



        [WebMethod]
        public static  List<Branch> GetBrachDetails()
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);

            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();

            dt = objbu.GetBranch4TaskDashbord();


            List<Branch> dataList = new List<Branch>();
            foreach (DataRow dtrow in dt.Rows)
            {
                Branch details = new Branch();
                details.Portid = Convert.ToInt32(dtrow[0]);
                details.PortName = dtrow[1].ToString();
              
                dataList.Add(details);
            }
            return dataList;

        }


        [WebMethod]
        public static List<Voucher> GetVouDetails()
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);

            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();

            dt = objbu.Getvou4TaskDashbord();


            List<Voucher> dataList = new List<Voucher>();
            foreach (DataRow dtrow in dt.Rows)
            {
                Voucher details = new Voucher();
                details.Voucherid = dtrow[0].ToString();
                details.Voucharname= dtrow[1].ToString();

                dataList.Add(details);
            }
            return dataList;

        }




        [WebMethod]
        public static List<taskdetails> GetTaskbasedCard4all(string bid, string voutype,string customerid,string empid)
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);

            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();

            dt = objbu.Card4TaskDetailDashsall(bid, voutype, Convert.ToInt32(customerid), Convert.ToInt32(empid));

            List<taskdetails> dataList = new List<taskdetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                taskdetails details = new taskdetails();
                details.Taskid = Convert.ToInt32(dtrow[0]);
                details.Tasks = dtrow[1].ToString();
                details.counts = Convert.ToInt32(dtrow[2]);
                details.Icon = dtrow[3].ToString();
                dataList.Add(details);
            }
            return dataList;

        }


        [WebMethod]
        public static List<taskdetails> GetTaskbasedCard4OpenFirst()
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);

            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();

            dt = objbu.Card4TaskDetailDashsall("0", "All", 0, 0);

            List<taskdetails> dataList = new List<taskdetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                taskdetails details = new taskdetails();
                details.Taskid = Convert.ToInt32(dtrow[0]);
                details.Tasks = dtrow[1].ToString();
                details.counts = Convert.ToInt32(dtrow[2]);
                details.Icon = dtrow[3].ToString();
                dataList.Add(details);
            }
            return dataList;

        }

        public class taskdetails
        {
            public int Taskid { get; set; }
            public string Tasks { get; set; }
            public int counts { get; set; }

            public string Icon { get; set; }
        }
        [WebMethod(EnableSession = true)]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Marketing.Quotation objQuotation = new DataAccess.Marketing.Quotation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_customerobj.GetDataBase(Ccode);
            objQuotation.GetDataBase(Ccode);
            obj_dt = obj_da_customerobj.GetLikeCustomer4TaskDashBord(prefix.Trim());
            // obj_dt = GetCustomer4quotcountrywise.GetLikeCustomer(prefix.Trim(), FType, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));



            //obj_dt = obj_da_customerobj.GetLikeIndianCustomer(prefix);Cusobj
            //cargo = iFACT.Utility.Fn_DatatableToList_Customer(obj_dt, "customername", "customerid");
            //customer = Utility.Fn_DatatableToList(obj_dt, "customer", "customerid");
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid", "customername", "address");
            return customer;
        }

        [WebMethod]
        public static List<string> GetSales(string prefix)
  {
            List<string> Sales = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee obj_da_employeeobj = new DataAccess.Masters.MasterEmployee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_employeeobj.GetDataBase(Ccode);
            obj_dt = obj_da_employeeobj.GetLikeEmployeeTaskDashBord(prefix.Trim(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            Sales = Utility.Fn_DatatableToList_int16Display(obj_dt, "empnamecode", "employeeid", "empname");
            return Sales;
        }

        //[WebMethod]
        //public static List<string> GetSalesPersonCustomer(string input)
        //{
        //    // Your logic to retrieve data based on the input
        //    List<string> dataList = new List<string>();
        //    DataTable obj_dt = new DataTable();
        //    DataAccess.Masters.MasterEmployee obj_da_employeeobj = new DataAccess.Masters.MasterEmployee();
        //    obj_dt = obj_da_employeeobj.GetSalesPersonCustomer(Convert.ToInt32(input));

        //    for (int i = 0; i < obj_dt.Rows.Count; i++)
        //    {
        //        string x= obj_dt.Rows[i][0].ToString();
        //        // Example: Adding some sample data
        //        dataList.Add(obj_dt.Rows[i][0].ToString());

        //    }

        //    return dataList;
        //}



        [WebMethod]
        public static List<SalespersonCustomer> GetSalesPersonCustomer(string input)
        {
            // Your logic to retrieve data based on the input
            


            List<SalespersonCustomer> dataList = new List<SalespersonCustomer>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee obj_da_employeeobj = new DataAccess.Masters.MasterEmployee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_employeeobj.GetDataBase(Ccode);
            if (input != "" & input!= "0" & input != "1")
            {
                obj_dt = obj_da_employeeobj.GetSalesPersonCustomer(Convert.ToInt32(input));
              
            }

            for (int i = 0; i < obj_dt.Rows.Count; i++)
            {


                dataList.Add(new SalespersonCustomer
                {
                    Customerid = Convert.ToInt32(obj_dt.Rows[i][0].ToString()),
                    Customername = obj_dt.Rows[i][1].ToString()

                });
               

            }

            return dataList;
        }

        public class SalespersonCustomer
        {
            public int Customerid { get; set; }
            public string Customername { get; set; }
     
        }

        public class Branch
        {
            public int Portid { get; set; }
            public string PortName { get; set; }

        }
        public class Voucher
        {
            public string Voucherid { get; set; }
            public string Voucharname { get; set; }

        }
    }
}