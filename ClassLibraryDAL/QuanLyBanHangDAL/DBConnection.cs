using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL.QuanLyBanHangDAL
{
    public class DbConnection
    {
        public DbConnection() 
        {

        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"data Source =DELL-PC\SQLEXPRESS; Initial Catalog=QLBH; User Id=sa; Password=sa";
            return conn;
        }
    }
}
