using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace logix
{
    public class MasterGlossary
    {
        private SqlConnection _sqlconnection;
        public MasterGlossary()
        {
            string connectionstring = "Data Source=ifreight.database.windows.net;Initial Catalog=SLDB;User ID=ifrtAdmin;pwd=05Jun!(&%;";
            _sqlconnection = new SqlConnection(connectionstring);
        }

        public DataTable GetGlossary(int RamdomVariable)
        {
            _sqlconnection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sqldata = new SqlDataAdapter("select * from MasterGlossary where SNO='"+RamdomVariable+"'",_sqlconnection);
            sqldata.Fill(dt);
            _sqlconnection.Close();
            return dt;
        }
    }
}